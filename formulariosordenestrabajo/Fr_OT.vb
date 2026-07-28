Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_OT


    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private FilaOT As DataRow

    Public tipoAccion As String = "I" ' "I"-Insertar "E"-Editar  "V"-Ver
    Public IdOrdenTrabajoModificar As Integer = -1

    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private guardado As Boolean = False
    Private DsOrdentrabajo As New DataSet

    Dim bddatos As New FuncionesBase.ClaseCargarMaestras
    Dim dsCargar As New DataSet

    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Estilo_Celda As New DataGridViewCellStyle
    Private MensajeError As String

    Private dtservicios As New DataTable
    Private dtpersonal As New DataTable
    Private dtequipos As New DataTable
    Private dtcostosindirectos As New DataTable
    Private dtarticulos As New DataTable
    Private IdBase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
    Public Proyecto As String = ""

    Public Sub CargarValores()
        Me.Dgv_ListaServicios.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaServicios.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Me.Dgv_ListaPersonal.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaPersonal.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Me.Dgv_CostosPersonal.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_CostosPersonal.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Me.Dgv_ListaEquipos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaEquipos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Me.Dgv_ListaCostosIndirectos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaCostosIndirectos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Me.Dgv_Articulos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Articulos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2


    End Sub

    Private Sub Personalizar_Datagrid()

        For i = 0 To Dgv_ListaPersonal.Columns.Count - 1
            Select Case Dgv_ListaPersonal.Columns(i).Name
                Case "DGVTBC_IDOTMAPERSONAL",
                    "DGVTBC_IDORDENTRABAJOPERSONAL",
                    "DGVTBC_NOMBREPERSONAL",
                    "DGVCBC_CODIGOTIPOUNIDADPERSONAL",
                    "DGVTBC_VALORUNITARIOPERSONAL",
                    "DGVTBC_CANTIDADPERSONAL",
                    "DGVTBC_CANTIDADCONTRATARPERSONA",
                    "DGVTBC_CANTIDADUNIDADESCONTRATARPERSONA",
                     "DGVTBC_CODIGOSERVICIO_PERSONA"
                Case "DGVTBC_VALORTOTALPERSONAL"
                    Dgv_ListaPersonal.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                Case Else
                    Dgv_ListaPersonal.Columns(i).Visible = False
            End Select
        Next

        For i = 0 To Dgv_CostosPersonal.Columns.Count - 1
            Select Case Dgv_CostosPersonal.Columns(i).Name
                Case "DGVTBC_NOMBREPERSONALCOMPLEMENTO",
                    "DGVTBC_CANTIDADCONTRATARCOMPLEMENTO",
                    "DGVTBC_CANTIDADUNIDADESCONTRATARCOMPLEMENTO",
                        "DGVTBC_DESAYUNO",
                        "DGVTBC_ALMUERZO",
                        "DGVTBC_COMIDA",
                        "DGVTBC_ALOJAMIENTO",
                        "DGVTBC_MISCELANIOS",
                        "DGVTBC_VALORDESAYUNO",
                        "DGVTBC_VALORALMUERZO",
                        "DGVTBC_VALORCOMIDA",
                        "DGVTBC_VALORALOJAMIENTO",
                        "DGVTBC_VALORMISCELANIOS"
                Case "DGVTBC_TOTALCOMPLEMENTO"
                    Dgv_CostosPersonal.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                Case Else
                    Dgv_CostosPersonal.Columns(i).Visible = False
            End Select
        Next
        Try
            If VariablesBase.VariablesBase.TipoUsuario = 26 Or VariablesBase.VariablesBase.TipoUsuario = 50 Then
                For i = 0 To Dgv_ListaServicios.Columns.Count - 1
                    Select Case Dgv_ListaServicios.Columns(i).Name
                        Case "DGVTBC_VALORUNITARIOSERVICIO", "DGVTBC_VALORTOTALSERVICIO"
                            Dgv_ListaServicios.Columns(i).Visible = False
                    End Select
                Next

                For i = 0 To Dgv_ListaPersonal.Columns.Count - 1
                    Select Case Dgv_ListaPersonal.Columns(i).Name
                        Case "DGVTBC_VALORUNITARIOPERSONAL", "DGVTBC_VALORTOTALPERSONAL"
                            Dgv_ListaPersonal.Columns(i).Visible = False
                    End Select
                Next

                For i = 0 To Dgv_ListaEquipos.Columns.Count - 1
                    Select Case Dgv_ListaEquipos.Columns(i).Name
                        Case "DGVTBC_VALORUNITARIOEQUIPO", "DGVTBC_VALORTOTALEQUIPO"
                            Dgv_ListaEquipos.Columns(i).Visible = False
                    End Select
                Next


                For i = 0 To Dgv_Articulos.Columns.Count - 1
                    Select Case Dgv_Articulos.Columns(i).Name
                        Case "DGVTBC_VALORUNITARIOARTICULO", "DGVTBC_VALORTOTALARTICULO"
                            Dgv_Articulos.Columns(i).Visible = False
                    End Select
                Next

                Me.Lb_AdministraciónAIU.Visible = False
                Me.Lb_ImpuestosAIU.Visible = False
                Me.Lb_UtilidadAIU.Visible = False
                Me.Lb_TotalAIU.Visible = False
                'Me.Lb_TextoValorTotal.Visible = False
                Me.Lb_TextoValorActividad.Visible = False
                Me.Lb_TextoValorPersonal.Visible = False
                Me.Lb_TextoValorComplemento.Visible = False
                Me.Lb_TextoValorEquipos.Visible = False
                Me.Lb_TextoValorIndirectos.Visible = False
                Me.Lb_TextoValorMateriales.Visible = False
                Me.Pn_EncabezadoOT.Enabled = False



            End If
        Catch ex As Exception
        End Try

        If tipoAccion = "V" Then
            Me.Pn_EncabezadoOT.Enabled = True
            For Each Controles In Pn_EncabezadoOT.Controls
                Dim sololectura As Boolean = False
                Try
                    Controles.readonly = True
                    sololectura = True
                Catch ex As Exception
                End Try
            Next

            Me.Bt_Guardar.Visible = False
            Me.Dgv_Articulos.ReadOnly = True
            Me.Dgv_ListaServicios.ReadOnly = True
            Me.Bt_AgregarServicio.Enabled = False
            Me.Tx_Servicio.Enabled = False
            Me.Cb_Servicio.Enabled = False
            Me.lk_AgregarPortapapelesServicios.Enabled = False
            Me.Tx_Persona.Enabled = False
            Me.Cb_Personal.Enabled = False
            Me.Bt_AgregarPersona.Enabled = False
            Me.Dgv_ListaPersonal.ReadOnly = True
            Me.Bt_LLenadoAutomático.Enabled = False
            Me.Bt_LimpiarTodo.Enabled = False
            Me.Dgv_CostosPersonal.ReadOnly = True
            Me.Tx_CodigoEquipo.Enabled = False
            Me.Cb_Equipo.Enabled = False
            Me.Bt_AgregarEquipo.Enabled = False
            Me.Dgv_ListaEquipos.ReadOnly = True
            Me.Dgv_ListaCostosIndirectos.ReadOnly = True
            Me.lk_AgregarPortapapelesMateriales.Enabled = False

        End If

        If FuncionesBase.FuncionesBase.ConsultarPermiso(770) = True Then
            Me.Tx_Factura.Enabled = True
            Me.Tx_HojaEntrada.Enabled = True
        Else
            Me.Tx_Factura.Enabled = False
            Me.Tx_HojaEntrada.Enabled = False
        End If

    End Sub


    Public Sub CargarProyecto()
        comando = New SqlCommand("SELECT PROYECTO FROM OT_ORDENTRABAJO WHERE IDORDENTRABAJO=@IDORDENTRABAJO", conexion)
        comando.Parameters.AddWithValue("@IDORDENTRABAJO", IdOrdenTrabajoModificar)
        adaptador = New SqlDataAdapter(comando)
        Dim dtProyecto As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtProyecto)
            conexion.Close()
            If dtProyecto.Rows.Count > 0 Then
                Proyecto = dtProyecto.Rows(0).Item("PROYECTO")
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Cargar_Tablas()
        Dim idbase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        Estilo_Celda_Error.BackColor = Color.Red
        Estilo_Celda.BackColor = Color.White

        '      -- 0 --> OT_ORDENTRABAJO
        '      -- 1 --> MA_OT_TIPOORDENTRABAJO
        '      -- 2 --> OT_MA_PERSONAL
        '      -- 3 --> OT_PERSONAL
        '      -- 4 --> OT_MA_EQUIPO
        '      -- 5 --> OT_EQUIPO
        '      -- 6 --> OT_COSTOINDIRECTO
        '      -- 7 --> OT_MA_SERVICIO
        '      -- 8 --> OT_SERVICIO
        '      -- 9--> OT_ARTICULO
        '      -- 10 --> MA_TIPOUNIDAD
        '      -- 11--> SC_BASE
        '      -- 12--> OT_MA_TIPOCLASEACTIVIDAD
        '      -- 13--> OT_MA_TIPOCLASEORDEN
        '      -- 14--> OT_MA_TIPOACTIVIDAD
        '      -- 15--> OT_MA_TIPOREPARACION
        '	   -- 16--> TABLA_AIU
        '      -- 17--> OT_MA_AREAATENCIONPRIMARIA
        '      -- 18--> OT_MA_UBICACIONTECNICA

        Dim identificador As Long
        Dim tipo As Integer
        If IdOrdenTrabajoModificar < 0 OrElse tipoAccion = "I" Then
            identificador = IdOrdenTrabajoModificar
            tipo = 1 'Crear
            If idbase = 121 Or idbase = 122 Or idbase = 123 Or idbase = 124 Or idbase = 125 Then
                Tx_PorAdministración.ReadOnly = False
                Tx_CódigoOrdenCliente.Enabled = True
            End If
        Else
            identificador = IdOrdenTrabajoModificar
            tipo = 2 'Editar
            If idbase = 121 Or idbase = 122 Or idbase = 123 Or idbase = 124 Or idbase = 125 Then
                Tx_PorAdministración.ReadOnly = False
                Tx_CódigoOrdenCliente.Enabled = True
            End If
        End If

        Dim idproyecto As Long
        If Proyecto = "C" Then
            idproyecto = 0
        ElseIf Proyecto = "O" Then
            idproyecto = 1
        Else
            idproyecto = 2
        End If

        dsCargar = bddatos.CargarMaestras(4, VariablesBase.VariablesBase.IdBaseSiscontrolActual, identificador, tipo, idproyecto)

        Me.Cb_Estado.DataSource = dsCargar.Tables(1)
        Me.Cb_Estado.ValueMember = "TIPO"
        Me.Cb_Estado.DisplayMember = "NOMBRE"
        Me.Cb_Estado.SelectedIndex = -1

        Me.Cb_Personal.DataSource = dsCargar.Tables(2)
        Me.Cb_Personal.ValueMember = "IDOTMAPERSONAL"
        Me.Cb_Personal.DisplayMember = "CARGO"
        Me.Cb_Personal.SelectedIndex = -1

        Me.Cb_Equipo.DataSource = dsCargar.Tables(4)
        Me.Cb_Equipo.ValueMember = "IDOTMAEQUIPO"
        Me.Cb_Equipo.DisplayMember = "NOMBREQUIPO"
        Me.Cb_Equipo.SelectedIndex = -1

        Me.Cb_Servicio.DataSource = dsCargar.Tables(7)
        Me.Cb_Servicio.ValueMember = "IDSERVICIO"
        Me.Cb_Servicio.DisplayMember = "NOMBRESERVICIO"
        Me.Cb_Servicio.SelectedIndex = -1

        Me.DGVCBC_CODIGOTIPOUNIDADSERVICIO.DataSource = dsCargar.Tables(10)
        Me.DGVCBC_CODIGOTIPOUNIDADSERVICIO.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVCBC_CODIGOTIPOUNIDADSERVICIO.DisplayMember = "ABREVIATURA"


        Me.DGVCBC_CODIGOTIPOUNIDADPERSONAL.DataSource = dsCargar.Tables(10)
        Me.DGVCBC_CODIGOTIPOUNIDADPERSONAL.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVCBC_CODIGOTIPOUNIDADPERSONAL.DisplayMember = "ABREVIATURA"

        Me.DGVCBC_CODIGOTIPOUNIDADEQUIPO.DataSource = dsCargar.Tables(10)
        Me.DGVCBC_CODIGOTIPOUNIDADEQUIPO.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVCBC_CODIGOTIPOUNIDADEQUIPO.DisplayMember = "ABREVIATURA"


        Me.DGVTBC_CODIGOTIPOUNIDADARTICULO.DataSource = dsCargar.Tables(10)
        Me.DGVTBC_CODIGOTIPOUNIDADARTICULO.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVTBC_CODIGOTIPOUNIDADARTICULO.DisplayMember = "ABREVIATURA"

        Me.DGVCBC_CODIGOTIPOUNIDADCOSTO.DataSource = dsCargar.Tables(10)
        Me.DGVCBC_CODIGOTIPOUNIDADCOSTO.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVCBC_CODIGOTIPOUNIDADCOSTO.DisplayMember = "ABREVIATURA"


        Me.Cb_Base.DataSource = dsCargar.Tables(11)
        Me.Cb_Base.ValueMember = "IDBASESISCONTROL"
        Me.Cb_Base.DisplayMember = "NOMBREBASE"


        Me.Cb_ClaseActividad.DataSource = dsCargar.Tables(12)
        Me.Cb_ClaseActividad.ValueMember = "IDTIPOCLASEACTIVIDAD"
        Me.Cb_ClaseActividad.DisplayMember = "NOMBRETIPOCLASEACTIVIDAD"
        Me.Cb_ClaseActividad.SelectedIndex = -1


        Me.Cb_Código_ClaseActividad.DataSource = dsCargar.Tables(12)
        Me.Cb_Código_ClaseActividad.ValueMember = "IDTIPOCLASEACTIVIDAD"
        Me.Cb_Código_ClaseActividad.DisplayMember = "CODIGOTIPOCLASEACTIVIDAD"
        Me.Cb_Código_ClaseActividad.SelectedIndex = -1

        Me.Cb_ClaseOrden.DataSource = dsCargar.Tables(13)
        Me.Cb_ClaseOrden.ValueMember = "IDTIPOCLASEORDEN"
        Me.Cb_ClaseOrden.DisplayMember = "NOMBRETIPOCLASEORDEN"
        Me.Cb_ClaseOrden.SelectedIndex = -1

        Me.Cb_Codigo_ClaseOrden.DataSource = dsCargar.Tables(13)
        Me.Cb_Codigo_ClaseOrden.ValueMember = "IDTIPOCLASEORDEN"
        Me.Cb_Codigo_ClaseOrden.DisplayMember = "CODIGOTIPOCLASEORDEN"
        Me.Cb_Codigo_ClaseOrden.SelectedIndex = -1

        Me.Cb_TipoActividad.DataSource = dsCargar.Tables(14)
        Me.Cb_TipoActividad.ValueMember = "CODIGOTIPOACTIVIDAD"
        Me.Cb_TipoActividad.DisplayMember = "NOMBRETIPOACTIVIDAD"
        Me.Cb_TipoActividad.SelectedIndex = -1

        Me.Cb_TipoReparación.DataSource = dsCargar.Tables(15)
        Me.Cb_TipoReparación.ValueMember = "CODIGOTIPOREPARACION"
        Me.Cb_TipoReparación.DisplayMember = "NOMBRETIPOREPARACION"
        Me.Cb_TipoReparación.SelectedIndex = -1

        Me.Cb_AtenciónPrimaria.DataSource = dsCargar.Tables(17)
        Me.Cb_AtenciónPrimaria.ValueMember = "IDAREAATENCIONPRIMARIA"
        Me.Cb_AtenciónPrimaria.DisplayMember = "AREAATENCIONPRIMARIA"
        Me.Cb_AtenciónPrimaria.SelectedIndex = -1

        Me.Cb_AtenciónPrimariaAbreviatura.DataSource = dsCargar.Tables(17)
        Me.Cb_AtenciónPrimariaAbreviatura.ValueMember = "IDAREAATENCIONPRIMARIA"
        Me.Cb_AtenciónPrimariaAbreviatura.DisplayMember = "ABREVIATURA"
        Me.Cb_AtenciónPrimariaAbreviatura.SelectedIndex = -1

        Me.Cb_ClaseAtención.DataSource = dsCargar.Tables(18)
        Me.Cb_ClaseAtención.ValueMember = "IDCLASEATENCION"
        Me.Cb_ClaseAtención.DisplayMember = "NOMBRECLASEATENCION"
        Me.Cb_ClaseAtención.SelectedIndex = -1

        Me.Cb_EstadoSAP.DataSource = dsCargar.Tables(19)
        Me.Cb_EstadoSAP.ValueMember = "TIPO"
        Me.Cb_EstadoSAP.DisplayMember = "NOMBRE"
        Me.Cb_EstadoSAP.SelectedIndex = -1


        Me.dtpersonal = dsCargar.Tables(3)
        Me.Dgv_ListaPersonal.AutoGenerateColumns = False
        Me.Dgv_CostosPersonal.AutoGenerateColumns = False
        Me.Dgv_ListaPersonal.DataSource = Me.dtpersonal
        Me.Dgv_CostosPersonal.DataSource = Me.dtpersonal

        Me.dtequipos = dsCargar.Tables(5)
        Me.Dgv_ListaEquipos.AutoGenerateColumns = False
        Me.Dgv_ListaEquipos.DataSource = Me.dtequipos

        Me.dtcostosindirectos = dsCargar.Tables(6)
        Me.Dgv_ListaCostosIndirectos.AutoGenerateColumns = False
        Me.Dgv_ListaCostosIndirectos.DataSource = Me.dtcostosindirectos

        Me.dtservicios = dsCargar.Tables(8)
        Me.Dgv_ListaServicios.AutoGenerateColumns = False
        Me.Dgv_ListaServicios.DataSource = Me.dtservicios

        Me.dtarticulos = dsCargar.Tables(9)
        Me.Dgv_Articulos.AutoGenerateColumns = False
        Me.Dgv_Articulos.DataSource = Me.dtarticulos

        DGVTBC_VALORTOTALARTICULO.DefaultCellStyle.Format = "C"
        DGVTBC_VALORTOTALCOSTOSINDIRECTOS.DefaultCellStyle.Format = "C"
        DGVTBC_VALORTOTALEQUIPO.DefaultCellStyle.Format = "C"
        DGVTBC_VALORTOTALPERSONAL.DefaultCellStyle.Format = "C"
        DGVTBC_VALORTOTALSERVICIO.DefaultCellStyle.Format = "C"
        DGVTBC_VALORUNITARIOARTICULO.DefaultCellStyle.Format = "C"
        DGVTBC_VALORUNITARIOCOSTOSINDIRECTOS.DefaultCellStyle.Format = "C"
        DGVTBC_VALORUNITARIOEQUIPO.DefaultCellStyle.Format = "C"
        DGVTBC_VALORUNITARIOPERSONAL.DefaultCellStyle.Format = "C"
        DGVTBC_VALORUNITARIOSERVICIO.DefaultCellStyle.Format = "C"

        Me.Cu_CiudadOrdenTrabajo.CargarDatos()
        Me.Cu_CiudadOrdenTrabajo.Cb_Ciudad.SelectedIndex = -1

        Me.Cu_BuscarPersonaFacturadorResponsable.CargarDatos()
        Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaSupervisorEcopetrol.CargarDatos()
        Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaSupervisorIsmocol.CargarDatos()
        Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedIndex = -1

        Select Case tipoAccion
            Case "E"
                Me.Tx_NROORDENSAP.Enabled = False
                Me.Ck_Suborden.Enabled = False
                Me.Tx_OrdenMAestra.Enabled = False
                FilaOT = dsCargar.Tables(0).Rows(0)
            Case "V"
                FilaOT = dsCargar.Tables(0).Rows(0)
            Case "I"
                Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    Case 99, 100, 105, 109
                        Me.Tx_NroContrato.Text = "8000004829"
                        Me.Nud_PosiciónContrato.Value = 27
                    Case 101, 102
                        Me.Tx_NroContrato.Text = "8000004829"
                        Me.Nud_PosiciónContrato.Value = 4
                    Case 95, 96, 97, 98, 106, 119
                        Me.Tx_NroContrato.Text = "8000004829"
                        Me.Nud_PosiciónContrato.Value = 26
                    Case 94, 103, 107, 108
                        Me.Tx_NroContrato.Text = "8000004829"
                        Me.Nud_PosiciónContrato.Value = 3
                    Case 121, 122, 123, 124, 125 'Ocensa
                        Me.Tx_NroContrato.Text = "3803257"
                        Me.Nud_PosiciónContrato.Value = 1
                End Select
                Me.Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                cargarAIU()
        End Select
        Personalizar_Datagrid()

    End Sub
#Region "Cargar Datos Editar"

    Public Sub CargarDatosOT()

        Me.Tx_NROORDENSAP.Text = FilaOT("NROORDENSAP")
        Me.Ck_Suborden.CheckState = IIf(FilaOT("ESSUBORDEN") = "S", 1, 0)
        Me.Tx_OrdenMAestra.Text = IIf(FilaOT("ESSUBORDEN") = "S", FilaOT("NROORDENSAPPADRE"), "")
        Me.Cb_Base.SelectedValue = FilaOT("IDBASE")
        If IsDBNull(FilaOT("FECHACREACIONSAP")) = True Then
            Me.Dtp_FechacreaciónSAP.Checked = False
        Else
            Me.Dtp_FechacreaciónSAP.Value = FilaOT("FECHACREACIONSAP")
            Me.Dtp_FechacreaciónSAP.Checked = True
        End If
        Me.Tx_Objeto.Text = FilaOT("OBJETO")
        Me.Cb_ClaseActividad.SelectedValue = FilaOT("IDTIPOCLASEACTIVIDAD")
        Me.Cb_ClaseOrden.SelectedValue = FilaOT("IDTIPOCLASEORDEN")
        Me.Cb_Estado.SelectedValue = FilaOT("ESTADO")

        If IsDBNull(FilaOT("ESTADOSAP")) = True Then
            Me.Cb_EstadoSAP.SelectedIndex = -1
        Else
            Me.Cb_EstadoSAP.SelectedValue = FilaOT("ESTADOSAP")
        End If

        If IsDBNull(FilaOT("FECHAINICIO")) = True Then
            Me.Dtp_FechaInicio.Checked = False
        Else
            Me.Dtp_FechaInicio.Value = FilaOT("FECHAINICIO")
            Me.Dtp_FechaInicio.Checked = True
        End If
        If IsDBNull(FilaOT("FECHAFIN")) = True Then
            Me.Dtp_FechaFin.Checked = False
        Else
            Me.Dtp_FechaFin.Value = FilaOT("FECHAFIN")
            Me.Dtp_FechaFin.Checked = True
        End If
        If IsDBNull(FilaOT("FECHAFINEXTREMO")) = True Then
            Me.Dtp_FechaInicioTardio.Checked = False
        Else
            Me.Dtp_FechaInicioTardio.Checked = True
            Me.Dtp_FechaInicioTardio.Value = FilaOT("FECHAFINEXTREMO")
        End If

        If IsDBNull(FilaOT("FECHAINICIOISMOCOL")) = True Then
            Me.Dtp_FechaInicioIsmocol.Checked = False
        Else
            Me.Dtp_FechaInicioIsmocol.Checked = True
            Me.Dtp_FechaInicioIsmocol.Value = FilaOT("FECHAINICIOISMOCOL")
        End If

        If IsDBNull(FilaOT("FECHAFINISMOCOL")) = True Then
            Me.Dtp_FechaFinalIsmocol.Checked = False
        Else
            Me.Dtp_FechaFinalIsmocol.Checked = True
            Me.Dtp_FechaFinalIsmocol.Value = FilaOT("FECHAFINISMOCOL")
        End If

        Me.Tx_UbicaciónTecnica.Text = FilaOT("CODIGOUBICACIONTECNICA")
        Me.Label7.Text = FilaOT("NOMBREUBICACIONTECNICA")
        If IsDBNull(FilaOT("IDEQUIPOSAP")) = False Then
            Me.Tx_Equipo.Text = FilaOT("IDEQUIPOSAP")
            Me.Label8.Text = FilaOT("NOMBREEQUIPOSAP")
        Else
            Me.Tx_Equipo.Text = ""
            Me.Label8.Text = ""
        End If
        Me.Tx_Abscisa.Text = FilaOT("ABSCISA")
        Me.Tx_georeferenciación.Text = FilaOT("GEOREFERENCIACION")
        Me.Tx_Latitud.Text = FilaOT("LATITUD")
        Me.Tx_Longitud.Text = FilaOT("LONGITUD")
        Me.Cu_CiudadOrdenTrabajo.Cb_Ciudad.SelectedValue = FilaOT("CODIGOPOBLACION")
        Me.Tx_Vereda.Text = FilaOT("VEREDA")
        Me.Tx_Observaciones.Text = FilaOT("OBSERVACIONOT")
        Me.Cb_TipoReparación.SelectedValue = FilaOT("CODIGOTIPOREPARACION")
        Me.Cb_TipoActividad.SelectedValue = FilaOT("CODIGOTIPOACTIVIDAD")
        Try
            Me.Cb_AtenciónPrimaria.SelectedValue = FilaOT("IDAREAATENCIONPRIMARIA")
        Catch ex As Exception
            Me.Cb_AtenciónPrimaria.SelectedIndex = -1
        End Try

        Me.Tx_PorAdministración.Text = FilaOT("PORADMINISTRACION")
        Me.Tx_PorImpuestos.Text = FilaOT("PORIMPUESTOS")
        Me.Tx_PorUtilidad.Text = FilaOT("PORUTILIDAD")
        Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedValue = FilaOT("IDPERSONASUPERVISORISMOCOL")
        Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedValue = FilaOT("IDPERSONASUPERVIDORECOPETROL")
        Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedValue = FilaOT("IDPERSONAFACTURADORRESPONSABLE")
        Try
            Me.Lb_TextoValorPersonal.Text = "VALOR TOTAL:   " + FormatCurrency(dtpersonal.Compute("Sum(VALORTOTAL)", "").ToString, 0)
        Catch ex As Exception
        End Try

        Try
            Me.Lb_TextoValorEquipos.Text = "VALOR TOTAL:   " + FormatCurrency(dtequipos.Compute("Sum(VALORTOTAL)", "").ToString, 0)
        Catch ex As Exception
        End Try
        Try
            Me.Lb_TextoValorIndirectos.Text = "VALOR TOTAL:   " + FormatCurrency(dtcostosindirectos.Compute("Sum(VALORTOTAL)", "").ToString, 0)
        Catch ex As Exception
        End Try
        Try
            Me.Lb_TextoValorMateriales.Text = "VALOR TOTAL:   " + FormatCurrency(dtarticulos.Compute("Sum(VALORTOTAL)", "").ToString, 0)
        Catch ex As Exception
        End Try
        Try
            Me.Lb_TextoValorActividad.Text = "VALOR TOTAL:   " + FormatCurrency(dtservicios.Compute("Sum(VALORTOTAL)", "").ToString, 0)
        Catch ex As Exception
        End Try

        Try
            Me.Lb_TextoValorComplemento.Text = "VALOR TOTAL:   " + FormatCurrency(dtpersonal.Compute("Sum(TOTALCOMPLEMENTO)", "").ToString, 0)
        Catch ex As Exception
        End Try

        Try
            Me.Cb_ClaseAtención.SelectedValue = FilaOT("IDCLASEATENCION")
        Catch ex As Exception
        End Try

        Try
            Me.Tx_NroContrato.Text = FilaOT("NROCONTRATO")
        Catch ex As Exception
        End Try

        Try
            Me.Nud_PosiciónContrato.Value = FilaOT("POSICIONCONTRATO")
        Catch ex As Exception
        End Try

        Try
            Me.Tx_HojaEntrada.Text = FilaOT("HOJAENTRADA")
        Catch ex As Exception
        End Try

        Try
            Me.Tx_Factura.Text = FilaOT("NROFACTURA")
        Catch ex As Exception
        End Try


        If IsDBNull(FilaOT("REQUIEREPESONAL")) = True Then
            Me.Ck_RequierePersona.CheckState = CheckState.Indeterminate
        Else
            If FilaOT("REQUIEREPESONAL") = "N" Then
                Me.Ck_RequierePersona.CheckState = CheckState.Unchecked
                Me.Ck_RequierePersona.Checked = False
            Else
                Me.Ck_RequierePersona.CheckState = CheckState.Checked
                Me.Ck_RequierePersona.Checked = True
            End If
        End If

        If IsDBNull(FilaOT("REQUIERECOMPLEMENTO")) = True Then
            Me.Ck_RequiereComplemento.CheckState = CheckState.Indeterminate
        Else
            If FilaOT("REQUIERECOMPLEMENTO") = "N" Then
                Me.Ck_RequiereComplemento.CheckState = CheckState.Unchecked
                Me.Ck_RequiereComplemento.Checked = False
            Else
                Me.Ck_RequiereComplemento.CheckState = CheckState.Checked
                Me.Ck_RequiereComplemento.Checked = True
            End If
        End If

        If IsDBNull(FilaOT("REQUIEREEQUIPOS")) = True Then
            Me.Ck_RequiereEquipos.CheckState = CheckState.Indeterminate
        Else
            If FilaOT("REQUIEREEQUIPOS") = "N" Then
                Me.Ck_RequiereEquipos.CheckState = CheckState.Unchecked
                Me.Ck_RequiereEquipos.Checked = False
            Else
                Me.Ck_RequiereEquipos.CheckState = CheckState.Checked
                Me.Ck_RequiereEquipos.Checked = True
            End If
        End If

        If IsDBNull(FilaOT("REQUIERECOSTOSDIRECTOS")) = True Then
            Me.Ck_RequiereCostosDirectos.CheckState = CheckState.Indeterminate
        Else
            If FilaOT("REQUIERECOSTOSDIRECTOS") = "N" Then
                Me.Ck_RequiereCostosDirectos.CheckState = CheckState.Unchecked
                Me.Ck_RequiereCostosDirectos.Checked = False
            Else
                Me.Ck_RequiereCostosDirectos.CheckState = CheckState.Checked
                Me.Ck_RequiereCostosDirectos.Checked = True
            End If
        End If

        If IsDBNull(FilaOT("REQUIEREMATERIALES")) = True Then
            Me.Ck_RequiereMateriales.CheckState = CheckState.Indeterminate
        Else
            If FilaOT("REQUIEREMATERIALES") = "N" Then
                Me.Ck_RequiereMateriales.CheckState = CheckState.Unchecked
                Me.Ck_RequiereMateriales.Checked = False
            Else
                Me.Ck_RequiereMateriales.CheckState = CheckState.Checked
                Me.Ck_RequiereMateriales.Checked = True
            End If
        End If

        If IsDBNull(FilaOT("CODIGOORDENCLIENTE")) = True Then
            Me.Tx_CódigoOrdenCliente.Text = ""
        Else
            Me.Tx_CódigoOrdenCliente.Text = FilaOT("CODIGOORDENCLIENTE")
        End If

        If IsDBNull(FilaOT("NROACTA")) = True Then
            Me.Tx_NroActa.Text = ""
        Else
            Me.Tx_NroActa.Text = FilaOT("NROACTA")
        End If

        TotalOT()
    End Sub

#End Region



#Region "Cargar Datos Editar"
    Public Sub LimpiarXClonación()
        Me.Tx_NROORDENSAP.Text = ""
        Me.IdOrdenTrabajoModificar = -1
        Me.tipoAccion = "I"
        Me.Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        cargarAIU()
        Me.Ck_Suborden.CheckState = CheckState.Indeterminate
        Me.Tx_Objeto.Text = ""
        Me.Tx_OrdenMAestra.Text = ""
        Me.Tx_NROORDENSAP.Enabled = True
        Me.Ck_Suborden.Enabled = True
        Me.Tx_OrdenMAestra.Enabled = True
    End Sub

#End Region



#Region "Manejo de tablas"
    Private Sub Bt_AgregarServicio_Click(sender As Object, e As EventArgs) Handles Bt_AgregarServicio.Click
        If Me.Cb_Base.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la base donse atendera la orden de trabajo")
            Exit Sub
        End If

        If Me.Cb_Servicio.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el servicio a agregar")
            Exit Sub
        End If
        agregarservicio(Me.Cb_Servicio.SelectedValue.ToString)
    End Sub

    Private Sub Cb_Servicio_KeyDown(sender As Object, e As KeyEventArgs) Handles Cb_Servicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Me.Cb_Base.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar la base donse atendera la orden de trabajo")
                    Exit Sub
                End If

                If Me.Cb_Servicio.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar el servicio a agregar")
                    Exit Sub
                End If
                agregarservicio(Me.Cb_Servicio.SelectedValue.ToString)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub agregarservicio(ByVal idservicio As String)
        Try
            Dim fila As DataRow
            fila = dtservicios.NewRow
            Dim filasservicioseleccionado As DataRow()
            filasservicioseleccionado = dsCargar.Tables(7).Select("IDSERVICIO=" + idservicio)
            Dim filaservicioseleccionado As DataRow
            filaservicioseleccionado = filasservicioseleccionado(0)
            fila("IDSERVICIO") = Cb_Servicio.SelectedValue
            fila("IDORDENTRABAJO") = -1
            fila("NUMPOSICIONSOLPED") = DBNull.Value
            fila("CODIGOSERVICIO") = filaservicioseleccionado("CODIGOSERVICIO")
            fila("NOMBRESERVICIO") = filaservicioseleccionado("NOMBRESERVICIO")
            fila("CODIGOTIPOUNIDAD") = filaservicioseleccionado("CODIGOTIPOUNIDAD")
            Select Case Me.Cb_Base.SelectedValue
                Case 94, 108, 107, 103 'Área Oriente 
                    fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOORIENTE")
                Case 106, 97, 95, 119, 98, 96 ' Área Norte 
                    fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIONORTE")
                Case 102, 101 'Área Magdalena 
                    fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOMAGDALENA")
                Case 100, 99, 105, 109 ' Área Andina 
                    fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOANDINA")
                Case 121, 122, 123, 124, 125 'Proyecto Ocensa
                    fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOORIENTE")
            End Select
            dtservicios.Rows.Add(fila)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Bt_AgregarPersona_Click(sender As Object, e As EventArgs) Handles Bt_AgregarPersona.Click
        AgregarPersona(Cb_Personal.SelectedValue)
    End Sub

    Private Sub Cb_Personal_KeyDown(sender As Object, e As KeyEventArgs) Handles Cb_Personal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                AgregarPersona(Cb_Personal.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Tx_Persona_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Persona.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                AgregarPersona(Me.Tx_Persona.Text)
            Catch ex As Exception
            End Try
            Me.Tx_Persona.Text = ""
            Me.Tx_Persona.Focus()
        End If

    End Sub


    Private Sub AgregarPersona(ByVal ID As Integer)
        Try
            Dim fila As DataRow
            fila = dtpersonal.NewRow
            Dim filaspersonalseleccionado As DataRow()
            filaspersonalseleccionado = dsCargar.Tables(2).Select("IDOTMAPERSONAL=" + ID.ToString)
            Dim filapersonalseleccionado As DataRow
            filapersonalseleccionado = filaspersonalseleccionado(0)
            fila("IDOTMAPERSONAL") = ID
            fila("IDORDENTRABAJO") = -1
            fila("NOMBREPERSONAL") = filapersonalseleccionado("CARGO")
            fila("CODIGOTIPOUNIDAD") = filapersonalseleccionado("CODIGOTIPOUNIDAD")
            fila("VALORUNITARIO") = filapersonalseleccionado("VALORUNITARIO")
            fila("CANTIDAD") = 0.0
            fila("VALORTOTAL") = 0.0
            dtpersonal.Rows.Add(fila)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Bt_AgregarEquipo_Click(sender As Object, e As EventArgs) Handles Bt_AgregarEquipo.Click
        AgregarEquipo(Cb_Equipo.SelectedValue)
    End Sub

    Private Sub Cb_Equipo_KeyDown(sender As Object, e As KeyEventArgs) Handles Cb_Equipo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                AgregarEquipo(Cb_Equipo.SelectedValue)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Tx_CodigoEquipo_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_CodigoEquipo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                AgregarEquipo(Me.Tx_CodigoEquipo.Text)
            Catch ex As Exception
            End Try
            Me.Tx_CodigoEquipo.Text = ""
            Me.Tx_CodigoEquipo.Focus()
        End If


    End Sub

    Private Sub AgregarEquipo(ByVal ID As Integer)
        Try
            Dim fila As DataRow
            fila = dtequipos.NewRow
            Dim filasequiposeleccionado As DataRow()
            filasequiposeleccionado = dsCargar.Tables(4).Select("IDOTMAEQUIPO=" + ID.ToString)
            Dim filaequiposeleccionado As DataRow
            filaequiposeleccionado = filasequiposeleccionado(0)
            fila("IDOTMAEQUIPO") = ID
            fila("IDORDENTRABAJO") = -1
            fila("NOMBREQUIPO") = filaequiposeleccionado("NOMBREQUIPO")
            fila("CODIGOTIPOUNIDAD") = filaequiposeleccionado("CODIGOTIPOUNIDAD")
            fila("VALORUNITARIO") = filaequiposeleccionado("VALORUNITARIO")
            fila("CANTIDAD") = 0.0
            fila("VALORTOTAL") = 0.0
            dtequipos.Rows.Add(fila)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Dgv_ListaServicios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_ListaServicios.CellEndEdit
        Try
            If IsDBNull(Me.Dgv_ListaServicios.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_ListaServicios.Item(e.ColumnIndex, e.RowIndex).Value = 0
            End If
            If Trim(Me.Dgv_ListaServicios.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                If e.RowIndex > 0 Then
                    Me.Dgv_ListaServicios.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                    Me.Dgv_ListaServicios.Rows(e.RowIndex).ErrorText = ""
                Else
                    Try
                        Me.Dgv_ListaServicios.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
                Exit Sub
            End If
            Dim VALORUNITARIO As Decimal
            Dim CANTIDAD As Decimal
            If Not IsDBNull(Me.Dgv_ListaServicios.Item(DGVTBC_VALORUNITARIOSERVICIO.Name, e.RowIndex).Value) Then
                VALORUNITARIO = Me.Dgv_ListaServicios.Item(DGVTBC_VALORUNITARIOSERVICIO.Name, e.RowIndex).Value
            End If
            If Not IsDBNull(Me.Dgv_ListaServicios.Item(DGVTBC_CANTIDADSERVICIO.Name, e.RowIndex).Value) Then
                CANTIDAD = Me.Dgv_ListaServicios.Item(DGVTBC_CANTIDADSERVICIO.Name, e.RowIndex).Value
            End If
            Me.Dgv_ListaServicios.Item(DGVTBC_VALORTOTALSERVICIO.Name, e.RowIndex).Value = VALORUNITARIO * CANTIDAD
            Me.Lb_TextoValorActividad.Text = "VALOR TOTAL:   " + FormatCurrency(dtservicios.Compute("Sum(VALORTOTAL)", "").ToString, 0)
            TotalOT()
            ELiminarFilaVacia(1)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgv_CostosPersonal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_CostosPersonal.CellEndEdit
        Select Case Dgv_CostosPersonal.Columns(e.ColumnIndex).Name
            Case "DGVTBC_DESAYUNO", "DGVTBC_ALMUERZO", "DGVTBC_COMIDA", "DGVTBC_ALOJAMIENTO", "DGVTBC_MISCELANIOS",
                "DGVTBC_VALORDESAYUNO", "DGVTBC_VALORALMUERZO", "DGVTBC_VALORCOMIDA", "DGVTBC_VALORALOJAMIENTO", "DGVTBC_VALORMISCELANIOS"
                CalculoPersonalyCostos(e)
        End Select
    End Sub

#Region "Controlar digitacion dentro de las celdas"


    Private Sub Dgv_ListaServicios_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_ListaServicios.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_ListaServicios
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dText_KeyPressDgv_ListaServicios(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_ListaServicios.CurrentCell()

        Select Case Celda.ColumnIndex
            Case 3, 4, 5
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 7, 11
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "," Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 8, 9
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "/" Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Dgv_ListaPersonal_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_ListaPersonal.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_ListaPersonal
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dText_KeyPressDgv_ListaPersonal(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_ListaPersonal.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 4, 7
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 5
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "," Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 9
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Dgv_CostosPersonal_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_CostosPersonal.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_CostosPersonal
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dText_KeyPressDgv_CostosPersonal(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_CostosPersonal.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 3, 4, 5, 6, 7
                e.KeyChar = Char.ToUpper(e.KeyChar)
                If e.KeyChar = "X" Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 8, 9, 10, 11, 12
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Dgv_ListaEquipos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_ListaEquipos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_ListaEquipos
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dText_KeyPressDgv_ListaEquipos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_ListaEquipos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 4, 7
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 5
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "," Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 9
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Dgv_ListaCostosIndirectos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_ListaCostosIndirectos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_ListaCostosIndirectos
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dText_KeyPressDgv_ListaCostosIndirectos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_ListaCostosIndirectos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 3
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 4
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "," Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 6
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Dgv_Articulos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Articulos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Articulos
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dText_KeyPressDgv_Articulos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Articulos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 4
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 5
                If e.KeyChar = "." Then
                    e.KeyChar = ","
                End If
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "," Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 7
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

#End Region



    Private Sub Dgv_ListaPersonal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_ListaPersonal.CellEndEdit
        Select Case e.ColumnIndex
            Case 4, 5, 7
                If IsDBNull(Me.Dgv_ListaPersonal.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    Me.Dgv_ListaPersonal.Item(e.ColumnIndex, e.RowIndex).Value = 0
                End If
                If Trim(Me.Dgv_ListaPersonal.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                    If e.RowIndex > 0 Then
                        Me.Dgv_ListaPersonal.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Me.Dgv_ListaPersonal.Rows(e.RowIndex).ErrorText = ""
                    Else
                        Try
                            Me.Dgv_ListaPersonal.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                    End If
                    Exit Sub
                End If
        End Select


        Select Case Dgv_ListaPersonal.Columns(e.ColumnIndex).Name
            Case "DGVTBC_CANTIDADCONTRATARPERSONA", "DGVTBC_CANTIDADPERSONAL"
                CalculoPersonalyCostos(e)
        End Select

    End Sub

    Private Sub CalculoPersonalyCostos(e As DataGridViewCellEventArgs)

        Try
            Dim VALORUNITARIO As Decimal
            Dim CANTIDAD As Decimal
            If Not IsDBNull(Me.Dgv_ListaPersonal.Item(DGVTBC_VALORUNITARIOPERSONAL.Name, e.RowIndex).Value) Then
                VALORUNITARIO = Me.Dgv_ListaPersonal.Item(DGVTBC_VALORUNITARIOPERSONAL.Name, e.RowIndex).Value
            End If
            If Not IsDBNull(Me.Dgv_ListaPersonal.Item(DGVTBC_CANTIDADPERSONAL.Name, e.RowIndex).Value) Then
                CANTIDAD = Me.Dgv_ListaPersonal.Item(DGVTBC_CANTIDADPERSONAL.Name, e.RowIndex).Value
            End If
            Me.Dgv_ListaPersonal.Item(DGVTBC_VALORTOTALPERSONAL.Name, e.RowIndex).Value = VALORUNITARIO * CANTIDAD


            Dim UNIDAD As String = ""
            If Not IsDBNull(Me.Dgv_ListaPersonal.Item(DGVCBC_CODIGOTIPOUNIDADPERSONAL.Name, e.RowIndex).Value) Then
                Dim filas() As DataRow
                filas = dsCargar.Tables(10).Select("CODIGOTIPOUNIDAD=" + Me.Dgv_ListaPersonal.Item(DGVCBC_CODIGOTIPOUNIDADPERSONAL.Name, e.RowIndex).Value.ToString)
                Dim Fila As DataRow
                Fila = filas(0)
                UNIDAD = Trim(Fila("ABREVIATURA"))
            End If

            Dim CANTIDADCONTRATAR As Integer = 0
            Dim CANTIDADUNIDADESCONTRATARPERSONA As Integer = 0

            If Not IsDBNull(Me.Dgv_ListaPersonal.Item(DGVTBC_CANTIDADCONTRATARPERSONA.Name, e.RowIndex).Value) Then
                CANTIDADCONTRATAR = Me.Dgv_ListaPersonal.Item(DGVTBC_CANTIDADCONTRATARPERSONA.Name, e.RowIndex).Value
                CANTIDADUNIDADESCONTRATARPERSONA = Redondeo((CANTIDAD / CANTIDADCONTRATAR), 0)
                Me.Dgv_ListaPersonal.Item(DGVTBC_CANTIDADUNIDADESCONTRATARPERSONA.Name, e.RowIndex).Value = CANTIDADUNIDADESCONTRATARPERSONA.ToString & " " & UNIDAD.ToString
            End If

            Dim C_D As String = ""
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_DESAYUNO.Name, e.RowIndex).Value) Then
                C_D = Me.Dgv_CostosPersonal.Item(DGVTBC_DESAYUNO.Name, e.RowIndex).Value
            End If
            Dim C_A As String = ""
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_ALMUERZO.Name, e.RowIndex).Value) Then
                C_A = Me.Dgv_CostosPersonal.Item(DGVTBC_ALMUERZO.Name, e.RowIndex).Value
            End If
            Dim C_C As String = ""
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_COMIDA.Name, e.RowIndex).Value) Then
                C_C = Me.Dgv_CostosPersonal.Item(DGVTBC_COMIDA.Name, e.RowIndex).Value
            End If
            Dim C_H As String = ""
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_ALOJAMIENTO.Name, e.RowIndex).Value) Then
                C_H = Me.Dgv_CostosPersonal.Item(DGVTBC_ALOJAMIENTO.Name, e.RowIndex).Value
            End If
            Dim C_M As String = ""
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_MISCELANIOS.Name, e.RowIndex).Value) Then
                C_M = Me.Dgv_CostosPersonal.Item(DGVTBC_MISCELANIOS.Name, e.RowIndex).Value
            End If

            Dim VALOR_DESAYUNO As Decimal = 0
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_VALORDESAYUNO.Name, e.RowIndex).Value) Then
                VALOR_DESAYUNO = Me.Dgv_CostosPersonal.Item(DGVTBC_VALORDESAYUNO.Name, e.RowIndex).Value
            End If
            Dim VALOR_ALMUERZO As Decimal = 0
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_VALORALMUERZO.Name, e.RowIndex).Value) Then
                VALOR_ALMUERZO = Me.Dgv_CostosPersonal.Item(DGVTBC_VALORALMUERZO.Name, e.RowIndex).Value
            End If
            Dim VALOR_COMIDA As Decimal = 0
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_VALORCOMIDA.Name, e.RowIndex).Value) Then
                VALOR_COMIDA = Me.Dgv_CostosPersonal.Item(DGVTBC_VALORCOMIDA.Name, e.RowIndex).Value
            End If
            Dim VALOR_HOSPEDAJE As Decimal = 0
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_VALORALOJAMIENTO.Name, e.RowIndex).Value) Then
                VALOR_HOSPEDAJE = Me.Dgv_CostosPersonal.Item(DGVTBC_VALORALOJAMIENTO.Name, e.RowIndex).Value
            End If
            Dim VALOR_MISCELANIO As Decimal = 0
            If Not IsDBNull(Me.Dgv_CostosPersonal.Item(DGVTBC_VALORMISCELANIOS.Name, e.RowIndex).Value) Then
                VALOR_MISCELANIO = Me.Dgv_CostosPersonal.Item(DGVTBC_VALORMISCELANIOS.Name, e.RowIndex).Value
            End If

            Dim TOTALCOMPLEMENTO As Decimal = 0

            If Trim(C_D) = "X" Then
                TOTALCOMPLEMENTO = CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_DESAYUNO
            End If

            If Trim(C_A) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_ALMUERZO)
            End If

            If Trim(C_C) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_COMIDA)
            End If

            If Trim(C_H) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_HOSPEDAJE)
            End If

            If Trim(C_M) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_MISCELANIO)
            End If


            Me.Dgv_CostosPersonal.Item(DGVTBC_TOTALCOMPLEMENTO.Name, e.RowIndex).Value = TOTALCOMPLEMENTO


            Me.Lb_TextoValorPersonal.Text = "VALOR TOTAL:   " + FormatCurrency(dtpersonal.Compute("Sum(VALORTOTAL)", "").ToString, 0)
            Me.Lb_TextoValorComplemento.Text = "VALOR TOTAL:   " + FormatCurrency(dtpersonal.Compute("Sum(TOTALCOMPLEMENTO)", "").ToString, 0)


            TotalOT()
            ELiminarFilaVacia(2)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CalculoPersonalyCostosfila(fila As DataRow)
        Try
            Dim VALORUNITARIO As Decimal
            Dim CANTIDAD As Decimal
            If Not IsDBNull(fila("VALORUNITARIO")) Then
                VALORUNITARIO = fila("VALORUNITARIO")
            End If
            If Not IsDBNull(fila("CANTIDAD")) Then
                CANTIDAD = fila("CANTIDAD")
            End If
            fila("VALORTOTAL") = VALORUNITARIO * CANTIDAD


            Dim UNIDAD As String = ""
            If Not IsDBNull(fila("CODIGOTIPOUNIDAD")) Then
                Dim filas() As DataRow
                filas = dsCargar.Tables(10).Select("CODIGOTIPOUNIDAD=" + fila("CODIGOTIPOUNIDAD").ToString)
                Dim Fila1 As DataRow
                Fila1 = filas(0)
                UNIDAD = Trim(Fila1("ABREVIATURA"))
            End If

            Dim CANTIDADCONTRATAR As Integer = 0
            Dim CANTIDADUNIDADESCONTRATARPERSONA As Integer = 0

            If Not IsDBNull(fila("CANTIDADCONTRATAR")) Then
                CANTIDADCONTRATAR = fila("CANTIDADCONTRATAR")
                CANTIDADUNIDADESCONTRATARPERSONA = Redondeo((CANTIDAD / CANTIDADCONTRATAR), 0)
                fila("CANTIDADUNIDADESCONTRATAR") = CANTIDADUNIDADESCONTRATARPERSONA.ToString & " " & UNIDAD.ToString
            End If

            Dim C_D As String = ""
            If Not IsDBNull(fila("DESAYUNO")) Then
                C_D = fila("DESAYUNO")
            End If
            Dim C_A As String = ""
            If Not IsDBNull(fila("ALMUERZO")) Then
                C_A = fila("ALMUERZO")
            End If
            Dim C_C As String = ""
            If Not IsDBNull(fila("COMIDA")) Then
                C_C = fila("COMIDA")
            End If
            Dim C_H As String = ""
            If Not IsDBNull(fila("ALOJAMIENTO")) Then
                C_H = fila("ALOJAMIENTO")
            End If
            Dim C_M As String = ""
            If Not IsDBNull(fila("MISCELANIOS")) Then
                C_M = fila("MISCELANIOS")
            End If

            Dim VALOR_DESAYUNO As Decimal = 0
            If Not IsDBNull(fila("VALORDESAYUNO")) Then
                VALOR_DESAYUNO = fila("VALORDESAYUNO")
            End If
            Dim VALOR_ALMUERZO As Decimal = 0
            If Not IsDBNull(fila("VALORALMUERZO")) Then
                VALOR_ALMUERZO = fila("VALORALMUERZO")
            End If
            Dim VALOR_COMIDA As Decimal = 0
            If Not IsDBNull(fila("VALORCOMIDA")) Then
                VALOR_COMIDA = fila("VALORCOMIDA")
            End If
            Dim VALOR_HOSPEDAJE As Decimal = 0
            If Not IsDBNull(fila("VALORALOJAMIENTO")) Then
                VALOR_HOSPEDAJE = fila("VALORALOJAMIENTO")
            End If
            Dim VALOR_MISCELANIO As Decimal = 0
            If Not IsDBNull(fila("VALORMISCELANIOS")) Then
                VALOR_MISCELANIO = fila("VALORMISCELANIOS")
            End If

            Dim TOTALCOMPLEMENTO As Decimal = 0

            If Trim(C_D) = "X" Then
                TOTALCOMPLEMENTO = CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_DESAYUNO
            End If

            If Trim(C_A) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_ALMUERZO)
            End If

            If Trim(C_C) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_COMIDA)
            End If

            If Trim(C_H) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_HOSPEDAJE)
            End If

            If Trim(C_M) = "X" Then
                TOTALCOMPLEMENTO = TOTALCOMPLEMENTO + (CANTIDADUNIDADESCONTRATARPERSONA * CANTIDADCONTRATAR * VALOR_MISCELANIO)
            End If
            fila("TOTALCOMPLEMENTO") = TOTALCOMPLEMENTO
            Me.Lb_TextoValorPersonal.Text = "VALOR TOTAL:   " + FormatCurrency(dtpersonal.Compute("Sum(VALORTOTAL)", "").ToString, 0)
            Me.Lb_TextoValorComplemento.Text = "VALOR TOTAL:   " + FormatCurrency(dtpersonal.Compute("Sum(TOTALCOMPLEMENTO)", "").ToString, 0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function Redondeo(ByVal Numero, ByVal Decimales)
        Redondeo = Math.Ceiling(Numero)
    End Function


    Private Sub Dgv_ListaEquipos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_ListaEquipos.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 4, 5, 7
                    If IsDBNull(Me.Dgv_ListaEquipos.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        Me.Dgv_ListaEquipos.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    End If
                    If Trim(Me.Dgv_ListaEquipos.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                        If e.RowIndex > 0 Then
                            Me.Dgv_ListaEquipos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Me.Dgv_ListaEquipos.Rows(e.RowIndex).ErrorText = ""
                        Else
                            Try
                                Me.Dgv_ListaEquipos.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                        End If
                        Exit Sub
                    End If
            End Select

            Dim VALORUNITARIO As Decimal
            Dim CANTIDAD As Decimal

            If Not IsDBNull(Me.Dgv_ListaEquipos.Item(DGVTBC_VALORUNITARIOEQUIPO.Name, e.RowIndex).Value) Then
                VALORUNITARIO = Me.Dgv_ListaEquipos.Item(DGVTBC_VALORUNITARIOEQUIPO.Name, e.RowIndex).Value
            End If
            If Not IsDBNull(Me.Dgv_ListaEquipos.Item(DGVTBC_CANTIDADEQUIPO.Name, e.RowIndex).Value) Then
                CANTIDAD = Me.Dgv_ListaEquipos.Item(DGVTBC_CANTIDADEQUIPO.Name, e.RowIndex).Value
            End If
            Me.Dgv_ListaEquipos.Item(DGVTBC_VALORTOTALEQUIPO.Name, e.RowIndex).Value = VALORUNITARIO * CANTIDAD


            Dim UNIDAD As String = ""
            If Not IsDBNull(Me.Dgv_ListaEquipos.Item(DGVCBC_CODIGOTIPOUNIDADEQUIPO.Name, e.RowIndex).Value) Then
                Dim filas() As DataRow
                filas = dsCargar.Tables(10).Select("CODIGOTIPOUNIDAD=" + Me.Dgv_ListaEquipos.Item(DGVCBC_CODIGOTIPOUNIDADEQUIPO.Name, e.RowIndex).Value.ToString)
                Dim Fila As DataRow
                Fila = filas(0)
                UNIDAD = Trim(Fila("ABREVIATURA"))
            End If
            Dim CANTIDADCONTRATAR As Integer = 0
            If Not IsDBNull(Me.Dgv_ListaEquipos.Item(DGVTBC_CANTIDADCONTRATAREQUIPO.Name, e.RowIndex).Value) Then
                CANTIDADCONTRATAR = Me.Dgv_ListaEquipos.Item(DGVTBC_CANTIDADCONTRATAREQUIPO.Name, e.RowIndex).Value
                Me.Dgv_ListaEquipos.Item(DGVTBC_CANTIDADUNIDADESCONTRATAREQUIPO.Name, e.RowIndex).Value = Redondeo((CANTIDAD / CANTIDADCONTRATAR), 0).ToString & " " & UNIDAD.ToString
            End If


            Me.Lb_TextoValorEquipos.Text = "VALOR TOTAL:   " + FormatCurrency(dtequipos.Compute("Sum(VALORTOTAL)", "").ToString, 0)
            TotalOT()
            ELiminarFilaVacia(3)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgv_ListaCostosIndirectos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_ListaCostosIndirectos.CellEndEdit
        Try
            If IsDBNull(Me.Dgv_ListaCostosIndirectos.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_ListaCostosIndirectos.Item(e.ColumnIndex, e.RowIndex).Value = 0
            End If
            If Trim(Me.Dgv_ListaCostosIndirectos.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                If e.RowIndex > 0 Then
                    Me.Dgv_ListaCostosIndirectos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                    Me.Dgv_ListaCostosIndirectos.Rows(e.RowIndex).ErrorText = ""
                Else
                    Try
                        Me.Dgv_ListaCostosIndirectos.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
                Exit Sub
            End If
            Dim VALORUNITARIO As Decimal
            Dim CANTIDAD As Decimal
            If Not IsDBNull(Me.Dgv_ListaCostosIndirectos.Item(DGVTBC_VALORUNITARIOCOSTOSINDIRECTOS.Name, e.RowIndex).Value) Then
                VALORUNITARIO = Me.Dgv_ListaCostosIndirectos.Item(DGVTBC_VALORUNITARIOCOSTOSINDIRECTOS.Name, e.RowIndex).Value
            End If
            If Not IsDBNull(Me.Dgv_ListaCostosIndirectos.Item(DGVTBC_CANTIDADCOSTOSINDIRECTOS.Name, e.RowIndex).Value) Then
                CANTIDAD = Me.Dgv_ListaCostosIndirectos.Item(DGVTBC_CANTIDADCOSTOSINDIRECTOS.Name, e.RowIndex).Value
            End If
            Me.Dgv_ListaCostosIndirectos.Item(DGVTBC_VALORTOTALCOSTOSINDIRECTOS.Name, e.RowIndex).Value = VALORUNITARIO * CANTIDAD
            Me.Lb_TextoValorIndirectos.Text = "VALOR TOTAL:   " + FormatCurrency(dtcostosindirectos.Compute("Sum(VALORTOTAL)", "").ToString, 0)
            TotalOT()
            ELiminarFilaVacia(4)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TotalOT()
        Dim TP As Decimal
        Try
            TP = dtpersonal.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TP = 0
        End Try
        Dim TE As Decimal
        Try
            TE = dtequipos.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TE = 0
        End Try
        Dim TCI As Decimal
        Try
            TCI = dtcostosindirectos.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TCI = 0
        End Try


        Dim TCA As Decimal
        Try
            TCA = dtarticulos.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TCA = 0
        End Try


        Dim TS As Decimal
        Try
            TS = dtservicios.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TS = 0
        End Try


        Dim TPC As Decimal
        Try
            TPC = dtpersonal.Compute("Sum(TOTALCOMPLEMENTO)", "")
        Catch ex As Exception
            TPC = 0
        End Try




        Dim TotalISM As Decimal = TP + TE + TCI + TCA + TPC

        Me.Lb_TextoValorTotal.Text = "VALOR TOTAL SERVICIO:   " + FormatCurrency(TS.ToString, 0) +
                                               "     VALOR COSTOS:    " + FormatCurrency(TotalISM.ToString, 0) +
                                               "     DIFERENCIA:    " + FormatCurrency(TS - TotalISM, 0) + "     "



        If TS > TotalISM Then
            If VariablesBase.VariablesBase.TipoUsuario = 26 Or VariablesBase.VariablesBase.TipoUsuario = 50 Then
                Me.Lb_TextoValorTotal.Text = "ACEPTADA PARA PLANEACION POSITIVA"
                Me.Lb_TextoValorTotal.TextAlign = ContentAlignment.MiddleCenter
            End If
            Me.Lb_TextoValorTotal.ForeColor = Color.Black
        Else
            If VariablesBase.VariablesBase.TipoUsuario = 26 Or VariablesBase.VariablesBase.TipoUsuario = 50 Then
                Me.Lb_TextoValorTotal.Text = "NEGATIVA - REVISAR CANTIDADES"
                Me.Lb_TextoValorTotal.TextAlign = ContentAlignment.MiddleCenter
            End If
            Me.Lb_TextoValorTotal.ForeColor = Color.Red
        End If

        Try
            Dim admin As Decimal = TS * (CDec(Me.Tx_PorAdministración.Text) / 100)
            Dim impuestos As Decimal = TS * (CDec(Me.Tx_PorImpuestos.Text) / 100)
            Dim utilidad As Decimal = TS * (CDec(Me.Tx_PorUtilidad.Text) / 100)
            Dim total As Decimal = admin + impuestos + utilidad
            Me.Lb_AdministraciónAIU.Text = FormatCurrency(admin.ToString, 0)
            Me.Lb_ImpuestosAIU.Text = FormatCurrency(impuestos.ToString, 0)
            Me.Lb_UtilidadAIU.Text = FormatCurrency(utilidad.ToString, 0)
            Me.Lb_TotalAIU.Text = FormatCurrency(total.ToString, 0)
        Catch ex As Exception
        End Try





    End Sub


    Private Sub ELiminarFilaVacia(ByVal tipo As Integer)
        Try
            Select Case tipo
                Case 1
                    For i = 0 To Dgv_ListaServicios.Rows.Count - 2
                        If IsDBNull(Me.Dgv_ListaServicios.Rows(i).Cells(DGVTBC_NOMBRESERVICIOSERVICIO.Name).Value) Then
                            Me.Dgv_ListaServicios.Rows.RemoveAt(i)
                        End If
                    Next
                Case 2
                    For i = 0 To Dgv_ListaPersonal.Rows.Count - 2
                        If IsDBNull(Me.Dgv_ListaPersonal.Rows(i).Cells(DGVTBC_NOMBREPERSONAL.Name).Value) Then
                            Me.Dgv_ListaPersonal.Rows.RemoveAt(i)
                        End If
                    Next
                Case 3
                    For i = 0 To Dgv_ListaEquipos.Rows.Count - 2
                        If IsDBNull(Me.Dgv_ListaEquipos.Rows(i).Cells(DGVTBC_NOMBREQUIPO.Name).Value) Then
                            Me.Dgv_ListaEquipos.Rows.RemoveAt(i)
                        End If
                    Next
                Case 4
                    For i = 0 To Dgv_ListaCostosIndirectos.Rows.Count - 2
                        If IsDBNull(Me.Dgv_ListaCostosIndirectos.Rows(i).Cells(DGVTBC_NOMBRECOSTOINDIRECTO.Name).Value) Then
                            Me.Dgv_ListaCostosIndirectos.Rows.RemoveAt(i)
                        End If
                    Next
            End Select

        Catch
        End Try
    End Sub

#End Region

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Dgv_ItemRequisicion_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Articulos.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3
                BuscarItems()
            Case Windows.Forms.Keys.Delete
                Try
                    Me.Dgv_Articulos.Rows.RemoveAt(Me.Dgv_Articulos.CurrentCell.RowIndex)
                Catch ex As Exception
                End Try
                Try
                    dtarticulos.AcceptChanges()
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub BuscarItems()
        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Familia = -1
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar

        FrBuscarArtículo.ShowDialog()
        If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
            Exit Sub
        End If

        If ValidarItems(FrBuscarArtículo.IdArtículo) = True Then
            Dim FilasArticulos As DataRow()
            Dim FilaArticulo As DataRow
            Dim NuevaFilaItem As DataRow

            Dim articulos As New DataTable()

            Dim Cadena_Consulta As String = "SELECT * FROM dbo.DatosArticuloxBasexCompra(" & FrBuscarArtículo.IdArtículo & "," _
                         & VariablesBase.VariablesBase.IdBodegaActual & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & " )"



            Dim Consulta As New SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Adaptador.FillSchema(articulos, SchemaType.Source)
            Adaptador.Fill(articulos)
            Consulta.Connection.Close()


            FilasArticulos = articulos.Select("IDARTICULO=" + FrBuscarArtículo.IdArtículo.ToString)
            If FilasArticulos.Length > 0 Then
                FilaArticulo = FilasArticulos(0)
                NuevaFilaItem = dtarticulos.NewRow 'LISTAITEMREQUISICION
                NuevaFilaItem("IDARTICULO") = FrBuscarArtículo.IdArtículo.ToString
                NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                NuevaFilaItem("VALORUNITARIO") = FilaArticulo("VALORREFERENCIA")
                NuevaFilaItem("CANTIDAD") = 0
                NuevaFilaItem("VALORTOTAL") = 0
                NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBREDESCRIPTIVO"))
                dtarticulos.Rows.Add(NuevaFilaItem)

            Else
                ' no existe un artículo con este código
                MensajeError = "No se encontró un artículo con ese código"
                MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Articulo no Encontrado")
            End If
        Else
            MensajeError = "El item que desea ingresar, ya se encuentra incluido en la requisición"
            MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")

        End If
        ELiminarFilaVaciaArticulo()
    End Sub

    Private Function ValidarItems(ByVal IdArticulo As Integer) As Boolean
        Dim filas As DataRow()
        filas = dtarticulos.Select("IDARTICULO=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItems = False
            Exit Function
        End If
        ValidarItems = True
    End Function

    Private Sub ELiminarFilaVaciaArticulo()
        Try
            For i = 0 To Dgv_Articulos.Rows.Count - 2
                If IsDBNull(Me.Dgv_Articulos.Rows(i).Cells(0).Value) = True Then
                    Me.Dgv_Articulos.Rows.RemoveAt(i)
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub Dgv_Articulos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Articulos.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 4, 5
                    If IsDBNull(Me.Dgv_Articulos.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        Me.Dgv_Articulos.Item(e.ColumnIndex, e.RowIndex).Value = 0
                    End If
                    If Trim(Me.Dgv_Articulos.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                        If e.RowIndex > 0 Then
                            Me.Dgv_Articulos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Me.Dgv_Articulos.Rows(e.RowIndex).ErrorText = ""
                        Else
                            Try
                                Me.Dgv_Articulos.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                        End If
                        Exit Sub
                    End If
            End Select



            Dim IDARTICULO As Integer = -1
            Dim ITEM As Integer = -1
            If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_IDARTICULO.Name, e.RowIndex).Value) Then
                IDARTICULO = Me.Dgv_Articulos.Item(DGVTBC_IDARTICULO.Name, e.RowIndex).Value
            End If
            Dim CANTIDAD As Double = -1
            If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value) Then
                CANTIDAD = Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value
            End If

            'Validar Artículo
            Select Case e.ColumnIndex
                Case Dgv_Articulos.Columns(DGVTBC_IDARTICULO.Name).Index '1
                    If ValidarItemsArticulos(IDARTICULO, ITEM) = True Then
                        Dim FilasArticulos As DataRow()
                        Dim FilaArticulo As DataRow
                        Dim NuevaFilaItem As DataRow

                        Dim articulos As New DataTable()
                        Dim Cadena_Consulta As String = "SELECT * FROM dbo.DatosArticuloxBasexCompra(" & IDARTICULO & "," _
                                        & VariablesBase.VariablesBase.IdBodegaActual & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & " )"
                        Dim Consulta As New SqlCommand(Cadena_Consulta)
                        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Consulta.Connection = Conexión
                        Dim Adaptador As New SqlDataAdapter(Consulta)
                        Consulta.Connection.Open()
                        Adaptador.FillSchema(articulos, SchemaType.Source)
                        Adaptador.Fill(articulos)
                        Consulta.Connection.Close()


                        FilasArticulos = articulos.Select("IDARTICULO=" + IDARTICULO.ToString)

                        If FilasArticulos.Length > 0 Then
                            FilaArticulo = FilasArticulos(0)

                            NuevaFilaItem = dtarticulos.NewRow 'LISTAITEMREQUISICION
                            NuevaFilaItem("IDARTICULO") = IDARTICULO
                            NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                            NuevaFilaItem("VALORUNITARIO") = FilaArticulo("VALORREFERENCIA")
                            NuevaFilaItem("CANTIDAD") = 0
                            NuevaFilaItem("VALORTOTAL") = 0
                            NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBREDESCRIPTIVO"))
                            If dtarticulos.Rows.Count = Me.Dgv_Articulos.CurrentCell.RowIndex Then 'LISTAITEMREQUISICION
                                Try
                                    Me.Dgv_Articulos.Rows.RemoveAt(e.RowIndex)
                                Catch
                                End Try
                                dtarticulos.Rows.Add(NuevaFilaItem) 'LISTAITEMREQUISICION
                            Else
                                dtarticulos.Rows(e.RowIndex).Item("IDARTICULO") = NuevaFilaItem("IDARTICULO") 'LISTAITEMREQUISICION
                                dtarticulos.Rows(e.RowIndex).Item("CODIGOTIPOUNIDAD") = NuevaFilaItem("CODIGOTIPOUNIDAD") 'LISTAITEMREQUISICION
                                dtarticulos.Rows(e.RowIndex).Item("VALORUNITARIO") = NuevaFilaItem("VALORUNITARIO") 'LISTAITEMREQUISICION
                                dtarticulos.Rows(e.RowIndex).Item("CANTIDAD") = NuevaFilaItem("CANTIDAD") 'LISTAITEMREQUISICION
                                dtarticulos.Rows(e.RowIndex).Item("VALORTOTAL") = NuevaFilaItem("VALORTOTAL") 'LISTAITEMREQUISICION
                                dtarticulos.Rows(e.RowIndex).Item("NOMBREDESCRIPTIVO") = NuevaFilaItem("NOMBREDESCRIPTIVO") 'LISTAITEMREQUISICION

                            End If
                        Else
                            'No existe un artículo con este código
                            MensajeError = "No se encontró un artículo con ese código"
                            MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                            Try
                                Me.dtarticulos.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                        End If
                    Else
                        MensajeError = "El item que desea ingresar, ya se encuentra incluido en la lista"
                        MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                        Try
                            Me.dtarticulos.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                    End If
                Case Dgv_Articulos.Columns(DGVTBC_VALORUNITARIOARTICULO.Name).Index, Dgv_Articulos.Columns(DGVTBC_CANTIDADARTICULO.Name).Index

                    Dim VALORUNITARIO As Decimal
                    Dim CANTIDAD1 As Decimal

                    If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_VALORUNITARIOARTICULO.Name, e.RowIndex).Value) Then
                        VALORUNITARIO = Me.Dgv_Articulos.Item(DGVTBC_VALORUNITARIOARTICULO.Name, e.RowIndex).Value
                    End If
                    If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value) Then
                        CANTIDAD1 = Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value
                    End If
                    Me.Dgv_Articulos.Item(DGVTBC_VALORTOTALARTICULO.Name, e.RowIndex).Value = VALORUNITARIO * CANTIDAD1
                    Me.Lb_TextoValorMateriales.Text = "VALOR TOTAL:   " + FormatCurrency(dtarticulos.Compute("Sum(VALORTOTAL)", "").ToString, 0)

            End Select

            TotalOT()
        Catch ex As Exception

        End Try
    End Sub



    Private Function ValidarItemsArticulos(ByVal IdArticulo As Integer, ByVal ItemLista As Integer) As Boolean
        Dim filas As DataRow()
        filas = dtarticulos.Select("IDARTICULO=" + IdArticulo.ToString)

        If filas.Length > 0 Then
            ValidarItemsArticulos = False
            Exit Function
        End If
        ValidarItemsArticulos = True
    End Function

    Public Cu_padre As Object

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If Guardar_Datos() = True Then
            If MsgBox("¿Desea salir del formulario?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Cursor.Current = Cursors.WaitCursor
                tipoAccion = "E"
                Cargar_Tablas()
                CargarDatosOT()
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

    Private Function Guardar_Datos() As Boolean
        Try
            If ValidarOT() Then
                If Validar_ValoresListaServicios() Then
                    If Validar_ValoresListaPersonal() Then
                        If Validar_ValoresListaequipo() Then
                            If Validar_ValoresListaCostoIndirecto() Then
                                If Validar_ValoresListaMateriales() Then
                                    If Validarasociarservicio() Then
                                        Guardar_Registro_OT()
                                    Else
                                        Guardar_Datos = False
                                        Exit Function
                                    End If
                                End If
                            Else
                                Guardar_Datos = False
                                Exit Function
                            End If
                        Else
                            Guardar_Datos = False
                            Exit Function
                        End If
                    Else
                        Guardar_Datos = False
                        Exit Function
                    End If
                Else
                    Guardar_Datos = False
                    Exit Function
                End If
            Else
                Guardar_Datos = False
                Exit Function
            End If
            Guardar_Datos = guardado
        Catch ex As Exception
            Guardar_Datos = False
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error al guardar los datos")
        End Try
    End Function

    Private Sub Guardar_Registro_OT()

        Me.dtpersonal.AcceptChanges()
        Me.dtequipos.AcceptChanges()
        Me.dtarticulos.AcceptChanges()
        Me.dtcostosindirectos.AcceptChanges()
        Me.dtservicios.AcceptChanges()

        'Llamar al procedimiento para crear el tipo categoría
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarOT_OrdenTrabajo")
        Comando.CommandType = CommandType.StoredProcedure
        Select Case tipoAccion
            Case "I"
                Comando.Parameters.AddWithValue("@ACCION", 1)
            Case "E"
                Comando.Parameters.AddWithValue("@ACCION", 2)
        End Select
        'Dim IntegerNullo As Nullable(Of Byte)
        ''Dim FechaNula As Nullable(Of Date)

        Comando.Parameters.AddWithValue("@IDORDENTRABAJO", IdOrdenTrabajoModificar)
        Try
            Comando.Parameters.AddWithValue("@NROORDENSAP", CInt(Me.Tx_NROORDENSAP.Text))
        Catch ex As Exception
            MsgBox("El NRO ORDEN SAP debe ser numerico")
            Exit Sub
        End Try

        Comando.Parameters.AddWithValue("@ESSUBORDEN", IIf(Me.Ck_Suborden.CheckState = CheckState.Checked, "S", "N"))
        'Comando.Parameters.AddWithValue("@NROORDENSAPPADRE", 1)

        Try
            If Me.Ck_Suborden.CheckState = CheckState.Checked Then
                Comando.Parameters.AddWithValue("@NROORDENSAPPADRE", CInt(Me.Tx_OrdenMAestra.Text))
            Else
                Comando.Parameters.AddWithValue("@NROORDENSAPPADRE", DBNull.Value)
            End If
        Catch ex As Exception
            MsgBox("El nro orden SAP padre debe ser numerico")
            Exit Sub
        End Try

        Comando.Parameters.AddWithValue("@IDBASE", Me.Cb_Base.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHACREACIONSAP", Me.Dtp_FechacreaciónSAP.Value)
        Comando.Parameters.AddWithValue("@OBJETO", Me.Tx_Objeto.Text)
        Comando.Parameters.AddWithValue("@IDTIPOCLASEACTIVIDAD", Me.Cb_ClaseActividad.SelectedValue)
        Comando.Parameters.AddWithValue("@IDTIPOCLASEORDEN", Me.Cb_ClaseOrden.SelectedValue)
        Comando.Parameters.AddWithValue("@ESTADO", Me.Cb_Estado.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAINICIO", Me.Dtp_FechaInicio.Value)
        Comando.Parameters.AddWithValue("@FECHAFIN", Me.Dtp_FechaFin.Value)

        If Me.Dtp_FechaInicioTardio.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAFINEXTREMO", Me.Dtp_FechaInicioTardio.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAFINEXTREMO", DBNull.Value)
        End If

        If Me.Dtp_FechaInicioIsmocol.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAINICIOISMOCOL", Me.Dtp_FechaInicioIsmocol.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAINICIOISMOCOL", DBNull.Value)
        End If

        If Me.Dtp_FechaFinalIsmocol.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAFINISMOCOL", Me.Dtp_FechaFinalIsmocol.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAFINISMOCOL", DBNull.Value)
        End If

        Comando.Parameters.AddWithValue("@CODIGOUBICACIONTECNICA", Me.Tx_UbicaciónTecnica.Text)
        Comando.Parameters.AddWithValue("@NOMBREEQUIPOSAP", Me.Tx_Equipo.Text)
        Comando.Parameters.AddWithValue("@ABSCISA", Me.Tx_Abscisa.Text)
        Comando.Parameters.AddWithValue("@GEOREFERENCIACION", Me.Tx_georeferenciación.Text)


        Dim LATITUD As Decimal = CDec(0.0)
        If Trim(Me.Tx_Latitud.Text) <> "" Then
            Try
                LATITUD = CDec(Me.Tx_Latitud.Text)
            Catch ex As Exception
                MsgBox("El formato de Latitud no corresponde")
            End Try
        End If
        Dim LONGITUD As Decimal = CDec(0.0)
        If Trim(Me.Tx_Longitud.Text) <> "" Then
            Try
                LONGITUD = CDec(Me.Tx_Longitud.Text)
            Catch ex As Exception
                MsgBox("El formato de longitud no corresponde")
            End Try
        End If


        Comando.Parameters.AddWithValue("@LATITUD", LATITUD)
        Comando.Parameters.AddWithValue("@LONGITUD", LONGITUD)

        Comando.Parameters.AddWithValue("@CODIGOPOBLACION", Me.Cu_CiudadOrdenTrabajo.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@VEREDA", Me.Tx_Vereda.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONOT", Me.Tx_Observaciones.Text)

        Comando.Parameters.AddWithValue("@POSICIONCONTRATO", Me.Nud_PosiciónContrato.Value)
        Comando.Parameters.AddWithValue("@NROCONTRATO", Me.Tx_NroContrato.Text)
        Comando.Parameters.AddWithValue("@HOJAENTRADA", Me.Tx_HojaEntrada.Text)
        Comando.Parameters.AddWithValue("@NROFACTURA", Me.Tx_Factura.Text)

        Dim TP As Decimal
        Try
            TP = dtpersonal.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TP = 0
        End Try
        Dim TE As Decimal
        Try
            TE = dtequipos.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TE = 0
        End Try
        Dim TCI As Decimal
        Try
            TCI = dtcostosindirectos.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TCI = 0
        End Try
        Dim TCA As Decimal
        Try
            TCA = dtarticulos.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TCA = 0
        End Try
        Dim TS As Decimal
        Try
            TS = dtservicios.Compute("Sum(VALORTOTAL)", "")
        Catch ex As Exception
            TS = 0
        End Try
        Dim TotalISM As Decimal = TP + TE + TCI + TCA

        Comando.Parameters.AddWithValue("@VALORTOTALSAP", CDec(TS))
        Comando.Parameters.AddWithValue("@VALORTOTALISMOCOL", CDec(TotalISM))
        Comando.Parameters.AddWithValue("@CODIGOTIPOREPARACION", Me.Cb_TipoReparación.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOACTIVIDAD", Me.Cb_TipoActividad.SelectedValue)
        Comando.Parameters.AddWithValue("@IDAREAATENCIONPRIMARIA", Me.Cb_AtenciónPrimaria.SelectedValue)

        Dim admin As Decimal = CDec(Me.Tx_PorAdministración.Text)
        Dim impuestos As Decimal = CDec(Me.Tx_PorImpuestos.Text)
        Dim utilidad As Decimal = CDec(Me.Tx_PorUtilidad.Text)

        Comando.Parameters.AddWithValue("@PORADMINISTRACION", admin)
        Comando.Parameters.AddWithValue("@PORIMPUESTOS", impuestos)
        Comando.Parameters.AddWithValue("@PORUTILIDAD", utilidad)

        Comando.Parameters.AddWithValue("@IDPERSONASUPERVISORISMOCOL", Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONASUPERVIDORECOPETROL", Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAFACTURADORRESPONSABLE", Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedValue)

        Comando.Parameters.AddWithValue("@IDCLASEATENCION", Me.Cb_ClaseAtención.SelectedValue)
        Comando.Parameters.AddWithValue("@ESTADOSAP", Me.Cb_EstadoSAP.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOOBSERVACIONCANCELACION", "")
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)

        Comando.Parameters.AddWithValue("@REQUIEREPESONAL", IIf(Me.Ck_RequierePersona.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@REQUIERECOMPLEMENTO", IIf(Me.Ck_RequiereComplemento.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@REQUIEREEQUIPOS", IIf(Me.Ck_RequiereEquipos.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@REQUIERECOSTOSDIRECTOS", IIf(Me.Ck_RequiereCostosDirectos.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@REQUIEREMATERIALES", IIf(Me.Ck_RequiereMateriales.Checked = True, "S", "N"))

        Comando.Parameters.AddWithValue("@CODIGOORDENCLIENTE", Me.Tx_CódigoOrdenCliente.Text)
        Comando.Parameters.AddWithValue("@NROACTA", Me.Tx_NroActa.Text)
        Comando.Parameters.AddWithValue("@PROYECTO", Proyecto)

        Comando.Parameters.AddWithValue("@TablaOT_SERVICIO", dtservicios)
        Comando.Parameters.AddWithValue("@TablaOT_PERSONAL", dtpersonal)
        Comando.Parameters.AddWithValue("@TablaOT_EQUIPO", dtequipos)
        Comando.Parameters.AddWithValue("@TablaOT_COSTOINDIRECTO", dtcostosindirectos)
        Comando.Parameters.AddWithValue("@TablaOT_ARTICULO", dtarticulos)





        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        Dim msgParam1 As New SqlParameter("@IDMENSAJE1", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Comando.Parameters.Add(msgParam1)

        'For i = 0 To Comando.Parameters.Count - 1
        '    MsgBox(Comando.Parameters(i).Value.ToString)
        'Next

        Try
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Select Case Comando.Parameters("@IDMENSAJE").Value
            Case 0
                MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completo la operación")
                guardado = False
                Exit Sub
            Case 1
                MsgBox("El registro a sido exitoso", MsgBoxStyle.Information, "ORDEN DE TRABAJO")
                Me.IdOrdenTrabajoModificar = Comando.Parameters("@IDMENSAJE1").Value
                guardado = True
                ' Me.Close()
            Case 2
                'cuando es nuevo y ya existe la OT o se esta modificando y la OT ya existe
                MsgBox("No se pudo realizar la operación, ya existe una orden SAP con ese número", MsgBoxStyle.Exclamation, "No se completo la operación")
                guardado = False
                Exit Sub
            Case 3
                MsgBox("No se pudo realizar la operación, la ubicación técnica digitada no está en la base de datos de ubicaciones técnicas, por favor verificar", MsgBoxStyle.Exclamation, "No se completo la operación")
                guardado = False
                Exit Sub
            Case 4
                MsgBox("No se pudo realizar la operación, el equipo digitado no está en la base de datos de equipos, por favor verificar", MsgBoxStyle.Exclamation, "No se completo la operación")
                guardado = False
                Exit Sub
        End Select


    End Sub

    Private Function Validar_ValoresListaServicios()
        Validar_ValoresListaServicios = True
    End Function

    Private Function Validar_ValoresListaPersonal()
        Validar_ValoresListaPersonal = True
    End Function

    Private Function Validar_ValoresListaequipo()
        Validar_ValoresListaequipo = True
    End Function

    Private Function Validar_ValoresListaCostoIndirecto()
        Dim valido As Boolean = True
        For i As Integer = 0 To Dgv_ListaCostosIndirectos.Rows.Count - 1
            Dgv_ListaCostosIndirectos.Rows(i).Cells(DGVCBC_CODIGOTIPOUNIDADCOSTO.Name).ErrorText = ""
            If Dgv_ListaCostosIndirectos.Rows(i).Cells(DGVCBC_CODIGOTIPOUNIDADCOSTO.Name).Value Is DBNull.Value Then
                Dgv_ListaCostosIndirectos.Rows(i).Cells(DGVCBC_CODIGOTIPOUNIDADCOSTO.Name).ErrorText = "Debe especificar la unidad."
                valido = False
            End If
        Next
        If Not valido Then
            MessageBox.Show("Debe especificar las unidades de los costos directos.", "Costos directos - órdenes de servicio - contratos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tc_principal.SelectedTab = Tp_Servicios
            Tc_ListaActividades.SelectedTab = Tp_CostoIndirecto
        End If
        Return valido
    End Function

    Private Function Validar_ValoresListaMateriales()
        Validar_ValoresListaMateriales = True
    End Function

    Private Function Validarasociarservicio()
        Dim filas() As DataRow
        'validar personas
        Dim servicio As String
        For i = 0 To Dgv_ListaPersonal.RowCount - 1
            If IsDBNull(Dgv_ListaPersonal.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_PERSONA").Value) = False Then
                If IsNothing(Dgv_ListaPersonal.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_PERSONA").Value) = False Then
                    If Dgv_ListaPersonal.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_PERSONA").Value <> "" Then
                        servicio = Dgv_ListaPersonal.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_PERSONA").Value
                        If servicio.Length = 7 Then
                            filas = dtservicios.Select("CODIGOSERVICIO=" + servicio)
                            If filas.Count = 0 Then
                                MsgBox("Servicio en personal no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                                Me.Tc_principal.SelectedIndex = 1
                                Me.Tc_ListaActividades.SelectedIndex = 1
                                Validarasociarservicio = False
                                Exit Function
                            End If
                        Else
                            MsgBox("Servicio en personal no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                            Me.Tc_principal.SelectedIndex = 1
                            Me.Tc_ListaActividades.SelectedIndex = 1
                            Validarasociarservicio = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        'validar equipos 
        For i = 0 To Dgv_ListaEquipos.RowCount - 1
            If IsDBNull(Dgv_ListaEquipos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_EQUIPO").Value) = False Then
                If IsNothing(Dgv_ListaEquipos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_EQUIPO").Value) = False Then
                    If Dgv_ListaEquipos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_EQUIPO").Value <> "" Then
                        servicio = Dgv_ListaEquipos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_EQUIPO").Value
                        If servicio.Length = 7 Then
                            filas = dtservicios.Select("CODIGOSERVICIO=" + servicio)
                            If filas.Count = 0 Then
                                MsgBox("Servicio en equipos no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                                Me.Tc_principal.SelectedIndex = 1
                                Me.Tc_ListaActividades.SelectedIndex = 3
                                Validarasociarservicio = False
                                Exit Function
                            End If
                        Else
                            MsgBox("Servicio en equipos no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                            Me.Tc_principal.SelectedIndex = 1
                            Me.Tc_ListaActividades.SelectedIndex = 3
                            Validarasociarservicio = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        'validar costo directo 
        For i = 0 To Dgv_ListaCostosIndirectos.RowCount - 1
            If IsDBNull(Dgv_ListaCostosIndirectos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_COSTO").Value) = False Then
                If IsNothing(Dgv_ListaCostosIndirectos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_COSTO").Value) = False Then
                    If Dgv_ListaCostosIndirectos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_COSTO").Value <> "" Then
                        servicio = Dgv_ListaCostosIndirectos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_COSTO").Value
                        If servicio.Length = 7 Then
                            filas = dtservicios.Select("CODIGOSERVICIO=" + servicio)
                            If filas.Count = 0 Then
                                MsgBox("Servicio en costos directos no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                                Me.Tc_principal.SelectedIndex = 1
                                Me.Tc_ListaActividades.SelectedIndex = 4
                                Validarasociarservicio = False
                                Exit Function
                            End If
                        Else
                            MsgBox("Servicio en costos directos no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                            Me.Tc_principal.SelectedIndex = 1
                            Me.Tc_ListaActividades.SelectedIndex = 4
                            Validarasociarservicio = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next

        'validar materiales 
        For i = 0 To Dgv_Articulos.RowCount - 1
            If IsDBNull(Dgv_Articulos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_MATERIALES").Value) = False Then
                If IsNothing(Dgv_Articulos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_MATERIALES").Value) = False Then
                    If Dgv_Articulos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_MATERIALES").Value <> "" Then
                        servicio = Dgv_Articulos.Rows(i).Cells("DGVTBC_CODIGOSERVICIO_MATERIALES").Value
                        If servicio.Length = 7 Then
                            filas = dtservicios.Select("CODIGOSERVICIO=" + servicio)
                            If filas.Count = 0 Then
                                MsgBox("Servicio en materiales no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                                Me.Tc_principal.SelectedIndex = 1
                                Me.Tc_ListaActividades.SelectedIndex = 5
                                Validarasociarservicio = False
                                Exit Function
                            End If
                        Else
                            MsgBox("Servicio en materiales no valido, debe estar incluido en los servicios de la OM", MsgBoxStyle.Information, "Error en Servicio Asociado")
                            Me.Tc_principal.SelectedIndex = 1
                            Me.Tc_ListaActividades.SelectedIndex = 5
                            Validarasociarservicio = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next

        Validarasociarservicio = True
    End Function


    Private Function ValidarOT() As Boolean

        If Me.Tx_NROORDENSAP.Text = "" Then
            MsgBox("Debe digitar el nro de orden SAP", MsgBoxStyle.Information, "NRO ORDEN SAP")
            Tc_principal.SelectedIndex = 0
            Me.Tx_NROORDENSAP.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Ck_Suborden.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si es o no Suborden", MsgBoxStyle.Information, "ES SUBORDEN SAP")
            Tc_principal.SelectedIndex = 0
            Me.Ck_Suborden.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Ck_Suborden.CheckState = CheckState.Checked Then
            If Trim(Tx_OrdenMAestra.Text) = "" Then
                MsgBox("Debe indicar el nro de la orden padre", MsgBoxStyle.Information, "ORDEN PADRE")
                Tc_principal.SelectedIndex = 0
                Me.Tx_OrdenMAestra.Focus()
                ValidarOT = False
                Exit Function
            End If
        Else
            If Trim(Tx_OrdenMAestra.Text) <> "" Then
                MsgBox("No es suborden por tal motivo la orden padres debe estar en blanco", MsgBoxStyle.Information, "ORDEN PADRE")
                Tc_principal.SelectedIndex = 0
                Me.Tx_OrdenMAestra.Focus()
                ValidarOT = False
                Exit Function
            End If
        End If

        If Me.Cb_Base.Text = "" Or Me.Cb_Base.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la base en la cual se atendera la OT", MsgBoxStyle.Information, "BASE ORDEN")
            Tc_principal.SelectedIndex = 0
            Me.Cb_Base.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Dtp_FechacreaciónSAP.Checked = False Then
            MsgBox("Debe seleccionar la fecha de creación de la OT en SAP", MsgBoxStyle.Information, "FECHA CREACION SAP ORDEN")
            Tc_principal.SelectedIndex = 0
            Me.Dtp_FechacreaciónSAP.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Trim(Me.Tx_Objeto.Text) = "" Then
            MsgBox("Debe digitar el objeto de la orden de trabajo", MsgBoxStyle.Information, "FECHA CREACION SAP ORDEN")
            Tc_principal.SelectedIndex = 0
            Me.Tx_Objeto.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_ClaseActividad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la clase de actividad de SAP", MsgBoxStyle.Information, "CLASE ACTIVIDAD SAP")
            Tc_principal.SelectedIndex = 0
            Me.Cb_ClaseActividad.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_ClaseOrden.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la clase de orden de SAP", MsgBoxStyle.Information, "CLASE ORDEN SAP")
            Tc_principal.SelectedIndex = 0
            Me.Cb_ClaseOrden.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_Estado.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el estado de la orden de SAP", MsgBoxStyle.Information, "ESTADO ORDEN")
            Tc_principal.SelectedIndex = 0
            Me.Cb_Estado.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_EstadoSAP.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el estado SAP de la orden de SAP", MsgBoxStyle.Information, "ESTADO ORDEN EN SAP")
            Tc_principal.SelectedIndex = 0
            Me.Cb_EstadoSAP.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Dtp_FechaInicio.Value > Me.Dtp_FechaFin.Value Then
            MsgBox("la fecha de inicio SAP debe ser inferior a la fecha de terminación SAP", MsgBoxStyle.Information, "FECHAS SAP INICIO / FIN")
            Tc_principal.SelectedIndex = 0
            Me.Dtp_FechaInicio.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Dtp_FechaInicioIsmocol.Checked = True And Dtp_FechaFinalIsmocol.Checked = True Then
            If Me.Dtp_FechaInicioIsmocol.Value > Me.Dtp_FechaFinalIsmocol.Value Then
                MsgBox("la fecha de inicio ismocol debe ser inferior a la fecha de terminación ismocol", MsgBoxStyle.Information, "FECHAS ISMOCOL INICIO / FIN")
                Tc_principal.SelectedIndex = 0
                Me.Dtp_FechaInicioIsmocol.Focus()
                ValidarOT = False
                Exit Function
            End If
        End If

        'If Me.Dtp_FechaInicioTardio.Value < Me.Dtp_FechaFin.Value Then
        '    MsgBox("la fecha de fin tardia no puede ser anterior a la fecha de fin programada", MsgBoxStyle.Information, "FECHAS SAP INICIO / FIN")
        '    Tc_principal.SelectedIndex = 0
        '    Me.Dtp_FechaInicioTardio.Focus()
        '    ValidarOT = False
        '    Exit Function
        'End If

        If Me.Cb_TipoActividad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de actividad", MsgBoxStyle.Information, "TIPO DE ACTIVIDAD")
            Tc_principal.SelectedIndex = 0
            Me.Cb_TipoActividad.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_TipoReparación.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de reparación", MsgBoxStyle.Information, "TIPO DE REPARACÏÓN")
            Tc_principal.SelectedIndex = 0
            Me.Cb_TipoReparación.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_ClaseAtención.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de clase de Atención", MsgBoxStyle.Information, "CLASE ATENCION")
            Tc_principal.SelectedIndex = 0
            Me.Cb_ClaseAtención.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Me.Cb_AtenciónPrimaria.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de área atención primaria", MsgBoxStyle.Information, "ÁREA ATENCIÓN PRIMARIA")
            Tc_principal.SelectedIndex = 0
            Me.Cb_AtenciónPrimaria.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Trim(Me.Tx_NroContrato.Text) = "" Then
            MsgBox("Debe digitar el número de contrato", MsgBoxStyle.Information, "NRO CONTRATO")
            Tc_principal.SelectedIndex = 0
            Me.Tx_NroContrato.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Trim(Me.Tx_UbicaciónTecnica.Text) = "" Then
            MsgBox("Debe digitar la ubicación Técnica", MsgBoxStyle.Information, "UBICACION TECNICA")
            Tc_principal.SelectedIndex = 0
            Me.Tx_UbicaciónTecnica.Focus()
            ValidarOT = False
            Exit Function
        End If

        'If Trim(Me.Tx_Equipo.Text) = "" Then
        '    MsgBox("Debe digitar el equipo", MsgBoxStyle.Information, "EQUIPO")
        '    Tc_principal.SelectedIndex = 0
        '    Me.Tx_Equipo.Focus()
        '    ValidarOT = False
        '    Exit Function
        'End If

        If Trim(Me.Tx_Abscisa.Text) = "" Then
            MsgBox("Debe digitar la abscisa", MsgBoxStyle.Information, "ABSCISA")
            Tc_principal.SelectedIndex = 0
            Me.Tx_Abscisa.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Trim(Me.Tx_georeferenciación.Text) = "" Then
            MsgBox("Debe digitar la georeferenciación", MsgBoxStyle.Information, "GEOREFERENCIACION")
            Tc_principal.SelectedIndex = 0
            Me.Tx_georeferenciación.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Cu_CiudadOrdenTrabajo.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el municipio donde se atiende la Orden de Trabajo", MsgBoxStyle.Information, "MUNICIPIO")
            Tc_principal.SelectedIndex = 0
            Me.Cu_CiudadOrdenTrabajo.Cb_Ciudad.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el supervisor por parte de ISMOCOL", MsgBoxStyle.Information, "SUPERVISOR ISMOCOL")
            Tc_principal.SelectedIndex = 0
            Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el supervisor por parte de Ecopetrol", MsgBoxStyle.Information, "SUPERVISOR ECOPETROL")
            Tc_principal.SelectedIndex = 0
            Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.Focus()
            ValidarOT = False
            Exit Function
        End If

        If Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el facturador responsable", MsgBoxStyle.Information, "FACTURADO RESPONSABLE")
            Tc_principal.SelectedIndex = 0
            Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.Focus()
            ValidarOT = False
            Exit Function
        End If

        'Validar si requiere o no persona, equipos, materiales, costos yn complemento

        If Me.Ck_RequierePersona.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si la OT requiere personal", MsgBoxStyle.Information, "Requiere Personal")
            Tc_principal.SelectedIndex = 1
            Tc_ListaActividades.SelectedIndex = 1
            Me.Ck_RequierePersona.Focus()
            ValidarOT = False
            Exit Function
        Else
            If Me.Ck_RequierePersona.CheckState = CheckState.Unchecked And dtpersonal.Rows.Count > 0 Then
                MsgBox("Si la OT no requiere personal, la tabla de personas debe estar vacia.", MsgBoxStyle.Information, "Requiere Personal")
                Tc_principal.SelectedIndex = 1
                Tc_ListaActividades.SelectedIndex = 1
                Me.Ck_RequierePersona.Focus()
                ValidarOT = False
                Exit Function
            End If
        End If

        If Me.Ck_RequiereComplemento.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si la OT requiere complemento de personal", MsgBoxStyle.Information, "Requiere Complemento de Personal")
            Tc_principal.SelectedIndex = 1
            Tc_ListaActividades.SelectedIndex = 2
            Me.Ck_RequiereComplemento.Focus()
            ValidarOT = False
            Exit Function
        Else
            If Me.Ck_RequiereComplemento.CheckState = CheckState.Unchecked Then

                Dim TPC As Decimal
                Try
                    TPC = dtpersonal.Compute("Sum(TOTALCOMPLEMENTO)", "")
                Catch ex As Exception
                    TPC = 0
                End Try

                If TPC <> 0 Then
                    MsgBox("Si la OT no requiere complemento de personal, los valores deben estar en 0", MsgBoxStyle.Information, "Requiere Complemento de Personal")
                    Tc_principal.SelectedIndex = 1
                    Tc_ListaActividades.SelectedIndex = 2
                    Me.Ck_RequiereComplemento.Focus()
                    ValidarOT = False
                    Exit Function
                End If

            End If
        End If

        If Me.Ck_RequiereEquipos.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si la OT requiere equipos", MsgBoxStyle.Information, "Requiere Equipos")
            Tc_principal.SelectedIndex = 1
            Tc_ListaActividades.SelectedIndex = 3
            Me.Ck_RequiereEquipos.Focus()
            ValidarOT = False
            Exit Function
        Else
            If Me.Ck_RequiereEquipos.CheckState = CheckState.Unchecked And dtequipos.Rows.Count > 0 Then
                MsgBox("Si la OT no requiere equipos, la tabla de equipos debe estar vacia.", MsgBoxStyle.Information, "Requiere Equipos")
                Tc_principal.SelectedIndex = 1
                Tc_ListaActividades.SelectedIndex = 3
                Me.Ck_RequiereEquipos.Focus()
                ValidarOT = False
                Exit Function
            End If
        End If

        If Me.Ck_RequiereCostosDirectos.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si la OT requiere costos directos", MsgBoxStyle.Information, "Requiere Costos Directos")
            Tc_principal.SelectedIndex = 1
            Tc_ListaActividades.SelectedIndex = 4
            Me.Ck_RequiereCostosDirectos.Focus()
            ValidarOT = False
            Exit Function
        Else
            If Me.Ck_RequiereCostosDirectos.CheckState = CheckState.Unchecked And dtcostosindirectos.Rows.Count > 0 Then
                MsgBox("Si la OT no requiere costos directos, la tabla de costos directos debe estar vacia.", MsgBoxStyle.Information, "Requiere Costos Directos")
                Tc_principal.SelectedIndex = 1
                Tc_ListaActividades.SelectedIndex = 4
                Me.Ck_RequiereCostosDirectos.Focus()
                ValidarOT = False
                Exit Function
            End If
        End If

        If Me.Ck_RequiereMateriales.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si la OT requiere materiales", MsgBoxStyle.Information, "Requiere Materiales")
            Tc_principal.SelectedIndex = 1
            Tc_ListaActividades.SelectedIndex = 5
            Me.Ck_RequiereMateriales.Focus()
            ValidarOT = False
            Exit Function
        Else
            If Me.Ck_RequiereMateriales.CheckState = CheckState.Unchecked And dtarticulos.Rows.Count > 0 Then
                MsgBox("Si la OT no requiere materiales, la tabla de materiales debe estar vacia.", MsgBoxStyle.Information, "Requiere Materiales")
                Tc_principal.SelectedIndex = 1
                Tc_ListaActividades.SelectedIndex = 5
                Me.Ck_RequiereMateriales.Focus()
                ValidarOT = False
                Exit Function
            End If

            If IsNumeric(Tx_PorAdministración.Text) = False Then
                MsgBox("El valor de Administración debe ser numérico", MsgBoxStyle.Critical, "VALOR ADMINISTRACIÓN")
                Tx_PorAdministración.Text = ""
                Me.Tx_PorAdministración.Focus()
                ValidarOT = False
                Exit Function
            End If

            If Tx_PorAdministración.Text > 99 Then
                MsgBox("El valor de la administración debe ser menor a 100", MsgBoxStyle.Critical, "VALOR ADMINISTRACIÓN")
                Me.Tx_PorAdministración.Focus()
                ValidarOT = False
                Exit Function
            End If
        End If

        ValidarOT = True

    End Function

    Private Sub Ck_Suborden_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_Suborden.CheckedChanged
        If Ck_Suborden.CheckState = CheckState.Checked Then
            Ck_Suborden.Text = "Es Suborden, Orden Padre:"
            Me.Tx_OrdenMAestra.Visible = True
        Else
            Ck_Suborden.Text = "Es Suborden..?"
            Me.Tx_OrdenMAestra.Visible = False
            Me.Tx_OrdenMAestra.Text = ""
        End If
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Base.SelectedIndexChanged
        cargarAIU()
    End Sub

    Private Sub cargarAIU()
        Try
            Dim FILAS As DataRow()
            FILAS = dsCargar.Tables(16).Select("IBBASE=" + Me.Cb_Base.SelectedValue.ToString)
            Dim fila As DataRow
            fila = FILAS(0)
            Me.Tx_PorAdministración.Text = fila("ADMINISTRACION")
            Me.Tx_PorImpuestos.Text = fila("IMPUESTOS")
            Me.Tx_PorUtilidad.Text = fila("UTILIDAD")

            Dim TS As Decimal
            Try
                TS = dtservicios.Compute("Sum(VALORTOTAL)", "")
            Catch ex As Exception
                TS = 0
            End Try

            Dim admin As Decimal = TS * (CDec(Me.Tx_PorAdministración.Text) / 100)
            Dim impuestos As Decimal = TS * (CDec(Me.Tx_PorImpuestos.Text) / 100)
            Dim utilidad As Decimal = TS * (CDec(Me.Tx_PorUtilidad.Text) / 100)
            Dim total As Decimal = admin + impuestos + utilidad

            Me.Lb_AdministraciónAIU.Text = FormatCurrency(admin.ToString, 0)
            Me.Lb_ImpuestosAIU.Text = FormatCurrency(impuestos.ToString, 0)
            Me.Lb_UtilidadAIU.Text = FormatCurrency(utilidad.ToString, 0)

            Me.Lb_TotalAIU.Text = FormatCurrency(total.ToString, 0)


        Catch ex As Exception
        End Try
    End Sub


    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaSupervisorIsmocol.CargarDatos()
            Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaSupervisorIsmocol.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaSupervisorEcopetrol.CargarDatos()
            Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaSupervisorEcopetrol.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaFacturadorResponsable.CargarDatos()
            Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaFacturadorResponsable.CargarCajaTexto()
        Catch
        End Try

        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaSupervisorIsmocol.Name
                Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaSupervisorEcopetrol.Name
                Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaFacturadorResponsable.Name
                Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub


    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaSupervisorIsmocol.Name
                Try
                    filas = Cu_BuscarPersonaSupervisorIsmocol.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaSupervisorIsmocol.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaSupervisorIsmocol.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaSupervisorIsmocol.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaSupervisorEcopetrol.Name
                Try
                    filas = Cu_BuscarPersonaSupervisorEcopetrol.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaSupervisorEcopetrol.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaSupervisorEcopetrol.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaSupervisorEcopetrol.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaFacturadorResponsable.Name
                Try
                    filas = Cu_BuscarPersonaFacturadorResponsable.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaFacturadorResponsable.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaFacturadorResponsable.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaFacturadorResponsable.Tx_TextoCódigo.Text = ""
                End Try

        End Select
    End Sub

    Private Sub Tx_Servicio_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Servicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim filas As DataRow()
                filas = dsCargar.Tables(7).Select("CODIGOSERVICIO='" + Me.Tx_Servicio.Text + "'")
                Dim fila As DataRow = filas(0)
                Me.Cb_Servicio.SelectedValue = fila("IDSERVICIO")
                Me.Bt_AgregarServicio.Focus()
            Catch ex As Exception
                Me.Tx_Servicio.Text = ""
            End Try
        End If

    End Sub



    Private Sub Cb_Servicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Servicio.SelectedIndexChanged
        Try
            Dim filas As DataRow()
            filas = dsCargar.Tables(7).Select("IDSERVICIO=" + Me.Cb_Servicio.SelectedValue.ToString)
            Dim fila As DataRow = filas(0)
            Me.Tx_Servicio.Text = fila("CODIGOSERVICIO")
        Catch ex As Exception
            Me.Tx_Servicio.Text = ""
        End Try
    End Sub


    Private Sub lk_AgregarPortapapelesServicios_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lk_AgregarPortapapelesServicios.LinkClicked
        Me.Cursor = Cursors.WaitCursor

        Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
        Dim words() As String = Clipboard.GetText().Split(delimiterChars)
        For i = 0 To words.Length - 1
            Dim line As String
            line = Replace(LTrim(RTrim(words(i))), vbLf, "")
            If line.Length > 0 Then
                Try

                    Dim fila As DataRow
                    fila = dtservicios.NewRow
                    Dim filasservicioseleccionado As DataRow()
                    filasservicioseleccionado = dsCargar.Tables(7).Select("CODIGOSERVICIO=" + line)
                    Dim filaservicioseleccionado As DataRow
                    filaservicioseleccionado = filasservicioseleccionado(0)
                    fila("IDSERVICIO") = filaservicioseleccionado("IDSERVICIO")
                    fila("IDORDENTRABAJO") = -1
                    fila("NUMPOSICIONSOLPED") = DBNull.Value
                    fila("CODIGOSERVICIO") = filaservicioseleccionado("CODIGOSERVICIO")
                    fila("NOMBRESERVICIO") = filaservicioseleccionado("NOMBRESERVICIO")
                    fila("CODIGOTIPOUNIDAD") = filaservicioseleccionado("CODIGOTIPOUNIDAD")
                    Select Case Me.Cb_Base.SelectedValue
                        Case 94, 108, 107, 103 'Área Oriente 
                            fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOORIENTE")
                        Case 106, 97, 95, 119, 98, 96 ' Área Norte 
                            fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIONORTE")
                        Case 102, 101 'Área Magdalena 
                            fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOMAGDALENA")
                        Case 100, 99, 105, 109 ' Área Andina 
                            fila("VALORUNITARIO") = filaservicioseleccionado("VALORUNITARIOANDINA")
                    End Select
                    dtservicios.Rows.Add(fila)


                Catch ex As Exception
                End Try
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub lk_AgregarPortapapelesMateriales_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lk_AgregarPortapapelesMateriales.LinkClicked

        Me.Cursor = Cursors.WaitCursor

        Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
        Dim words() As String = Clipboard.GetText().Split(delimiterChars)
        For i = 0 To words.Length - 1
            Dim line As String
            line = Replace(LTrim(RTrim(words(i))), vbLf, "")
            If IsNumeric(line) Then

                If ValidarItems(CInt(line)) = True Then
                    Dim FilasArticulos As DataRow()
                    Dim FilaArticulo As DataRow
                    Dim NuevaFilaItem As DataRow

                    Dim articulos As New DataTable()

                    Dim Cadena_Consulta As String = "SELECT * FROM dbo.DatosArticuloxBasexCompra(" & line & "," _
                    & VariablesBase.VariablesBase.IdBodegaActual & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & " )"

                    Dim Consulta As New SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Adaptador.FillSchema(articulos, SchemaType.Source)
                    Adaptador.Fill(articulos)
                    Consulta.Connection.Close()
                    FilasArticulos = articulos.Select("IDARTICULO=" + line)
                    If FilasArticulos.Length > 0 Then
                        FilaArticulo = FilasArticulos(0)
                        NuevaFilaItem = dtarticulos.NewRow 'LISTAITEMREQUISICION
                        NuevaFilaItem("IDARTICULO") = line
                        NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                        NuevaFilaItem("VALORUNITARIO") = FilaArticulo("VALORREFERENCIA")
                        NuevaFilaItem("CANTIDAD") = 0
                        NuevaFilaItem("VALORTOTAL") = 0
                        NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBREDESCRIPTIVO"))
                        dtarticulos.Rows.Add(NuevaFilaItem)
                    End If
                End If
                ELiminarFilaVaciaArticulo()
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Cb_ClaseOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_ClaseOrden.SelectedIndexChanged
        Try
            Me.Cb_Codigo_ClaseOrden.SelectedValue = Me.Cb_ClaseOrden.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cb_Codigo_ClaseOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Codigo_ClaseOrden.SelectedIndexChanged
        Try
            Me.Cb_ClaseOrden.SelectedValue = Me.Cb_Codigo_ClaseOrden.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cb_Código_ClaseActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Código_ClaseActividad.SelectedIndexChanged
        Try
            Cb_ClaseActividad.SelectedValue = Cb_Código_ClaseActividad.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cb_ClaseActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_ClaseActividad.SelectedIndexChanged
        Try
            Cb_Código_ClaseActividad.SelectedValue = Cb_ClaseActividad.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bt_BuscarUbicaciónTécnica_Click(sender As Object, e As EventArgs) Handles Bt_BuscarUbicaciónTécnica.Click
        Dim FrBusqueda As New Fr_Búsqueda
        FrBusqueda.Tipo = "U"
        FrBusqueda.ComboBox_Filtrar.Items.Add("Codigo")
        FrBusqueda.ComboBox_Filtrar.Items.Add("Nombre")
        FrBusqueda.ComboBox_Filtrar.Items.Add("Emplazamiento")
        FrBusqueda.ShowDialog()
        Me.Tx_UbicaciónTecnica.Text = FrBusqueda.Resultado 'puede ser texto o numerico dependiendo de la tabla
        Me.Label7.Text = FrBusqueda.Resultado1
    End Sub

    Private Sub Bt_BuscarEquipo_Click(sender As Object, e As EventArgs) Handles Bt_BuscarEquipo.Click
        Dim FrBusqueda As New Fr_Búsqueda
        FrBusqueda.Tipo = "E"
        FrBusqueda.ComboBox_Filtrar.Items.Add("Codigo")
        FrBusqueda.ComboBox_Filtrar.Items.Add("Nombre")
        FrBusqueda.ComboBox_Filtrar.Items.Add("Ubicación Técnica")
        FrBusqueda.ShowDialog()
        Me.Tx_Equipo.Text = FrBusqueda.Resultado 'puede ser texto o numerico dependiendo de la tabla
        Me.Label8.Text = FrBusqueda.Resultado1
    End Sub


    Public Sub EventoEnterCiudad(Optional NombreComponente As String = "")
        Dim controles() As Control = Me.Controls.Find(NombreComponente, True)
        If controles.Length > 0 Then
            Dim cuCiudad As FormulariosClasesBase.Cu_Ciudad = controles(0)
            Dim filas() As DataRow
            Try
                filas = cuCiudad.Cb_Ciudad.DataSource.Select("CODIGOPOBLACION='" + (cuCiudad.Tx_Codigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuCiudad.Cb_Ciudad.SelectedValue = fila("CODIGOPOBLACION")
                Else
                    MessageBox.Show("Esta población no está registrada.", "No se encontró la ciudad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch
                cuCiudad.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub

    Private Sub Cb_AtenciónPrimariaAbreviatura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AtenciónPrimariaAbreviatura.SelectedIndexChanged
        Try
            Cb_AtenciónPrimaria.SelectedValue = Cb_AtenciónPrimariaAbreviatura.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cb_AtenciónPrimaria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AtenciónPrimaria.SelectedIndexChanged
        Try
            Cb_AtenciónPrimariaAbreviatura.SelectedValue = Cb_AtenciónPrimaria.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bt_LLenadoAutomático_Click(sender As Object, e As EventArgs) Handles Bt_LLenadoAutomático.Click
        If MsgBox("¿Seguro que desea llenar con valores de referencia?", MsgBoxStyle.YesNo, "Valores Referencia") = MsgBoxResult.Yes Then
            Try
                Dim i As Integer
                For i = 0 To dtpersonal.Rows.Count - 1
                    Dim fila As DataRow = dtpersonal.Rows(i)
                    fila("DESAYUNO") = "X"
                    fila("ALMUERZO") = "X"
                    fila("COMIDA") = "X"
                    fila("ALOJAMIENTO") = "X"
                    fila("MISCELANIOS") = "X"
                    Dim filavalores As DataRow
                    filavalores = dsCargar.Tables(20).Rows(0)
                    fila("VALORDESAYUNO") = filavalores("VALORDESAYUNO")
                    fila("VALORALMUERZO") = filavalores("VALORALMUERZO")
                    fila("VALORCOMIDA") = filavalores("VALORCOMIDA")
                    fila("VALORALOJAMIENTO") = filavalores("VALORALOJAMIENTO")
                    fila("VALORMISCELANIOS") = filavalores("VALORMISCELANIOS")
                    Try
                        fila("TOTALCOMPLEMENTO") = filavalores("TOTALCOMPLEMENTO") * fila("CANTIDADCONTRATAR") * Redondeo((fila("CANTIDAD") / fila("CANTIDADCONTRATAR")), 0)
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
            End Try
            TotalOT()
        End If

    End Sub

    Private Sub Bt_LimpiarTodo_Click(sender As Object, e As EventArgs) Handles Bt_LimpiarTodo.Click
        If MsgBox("¿Seguro que desea limpiar los valores?", MsgBoxStyle.YesNo, "Limpiar Valores") = MsgBoxResult.Yes Then
            Try
                Dim i As Integer
                For i = 0 To dtpersonal.Rows.Count - 1
                    Dim fila As DataRow = dtpersonal.Rows(i)
                    fila("DESAYUNO") = DBNull.Value
                    fila("ALMUERZO") = DBNull.Value
                    fila("COMIDA") = DBNull.Value
                    fila("ALOJAMIENTO") = DBNull.Value
                    fila("MISCELANIOS") = DBNull.Value
                    fila("VALORDESAYUNO") = DBNull.Value
                    fila("VALORALMUERZO") = DBNull.Value
                    fila("VALORCOMIDA") = DBNull.Value
                    fila("VALORALOJAMIENTO") = DBNull.Value
                    fila("VALORMISCELANIOS") = DBNull.Value
                    Try
                        fila("TOTALCOMPLEMENTO") = DBNull.Value
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
            End Try
            TotalOT()
        End If
    End Sub

    Dim activocolumnasTSMI_CopiarTodas As Boolean = False
    Dim activocolumnasTSMI_LlenarCon As Boolean = False
    Dim activocolumnasTSMI_ReemplazarValor As Boolean = False
    Dim activocolumnasTSMI_X As Boolean = False
    Dim activocolumnasTSMI_LimpiarTodas As Boolean = False

    Private Sub Cms_opciones_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cms_opciones.Opening
        ValidarColumna()
        TSMI_CopiarTodas.Visible = activocolumnasTSMI_CopiarTodas
        TSMI_LlenarCon.Visible = activocolumnasTSMI_LlenarCon
        TSMI_ReemplazarValor.Visible = activocolumnasTSMI_ReemplazarValor
        TSMI_X.Visible = activocolumnasTSMI_X
        TSMI_LimpiarTodas.Visible = activocolumnasTSMI_LimpiarTodas
    End Sub


    Dim TipoPegado As String = "" ' 
    Private Function ValidarColumna() As Boolean
        Dim Nombre_Columna As String = ""
        activocolumnasTSMI_CopiarTodas = False
        activocolumnasTSMI_LlenarCon = False
        activocolumnasTSMI_ReemplazarValor = False
        activocolumnasTSMI_X = False
        TipoPegado = ""
        activocolumnasTSMI_LimpiarTodas = False
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Nombre_Columna = Me.Dgv_ListaServicios.Columns(Me.Dgv_ListaServicios.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Num SolPed", "Pos Ser", "F Inicial", "F Final"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                End Select
            Case Me.Tp_Complemento.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "D", "A", "C", "H", "M"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_X = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case "Vlr Des", "Vlr Alm", "Vlr Com", "Vlr Hotel", "Vlr Misc"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_ReemplazarValor = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select

                dtpersonal.AcceptChanges()
            Case Me.Tp_Personal.Name
                Nombre_Columna = Me.Dgv_ListaPersonal.Columns(Me.Dgv_ListaPersonal.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        activocolumnasTSMI_CopiarTodas = True
                        'activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                dtpersonal.AcceptChanges()
            Case Me.Tp_Equipo.Name
                Nombre_Columna = Me.Dgv_ListaEquipos.Columns(Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        activocolumnasTSMI_CopiarTodas = True
                        'activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                dtequipos.AcceptChanges()
            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        activocolumnasTSMI_CopiarTodas = True
                        'activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                dtarticulos.AcceptChanges()
            Case Me.Tp_CostoIndirecto.Name
                Nombre_Columna = Me.Dgv_ListaCostosIndirectos.Columns(Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        activocolumnasTSMI_CopiarTodas = True
                        'activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                dtcostosindirectos.AcceptChanges()
        End Select
        ValidarColumna = False
    End Function

    Private Sub CopiarEnTodasLasCeldasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CopiarTodas.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Dim Valor_Copiar As String = ""
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Nombre_Columna = Me.Dgv_ListaServicios.Columns(Me.Dgv_ListaServicios.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaServicios.CurrentCell.ColumnIndex
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaServicios.CurrentRow.Index
                Try
                    Valor_Copiar = Me.Dgv_ListaServicios.Item(Indice_Columna, IndiceFilaseleccionada).Value
                Catch ex As Exception
                End Try
            Case Me.Tp_Complemento.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
                Dim IndiceFilaseleccionada As Integer = Dgv_CostosPersonal.CurrentRow.Index
                Try
                    Valor_Copiar = Me.Dgv_CostosPersonal.Item(Indice_Columna, IndiceFilaseleccionada).Value
                Catch ex As Exception
                End Try
            Case Me.Tp_Personal.Name
                Nombre_Columna = Me.Dgv_ListaPersonal.Columns(Me.Dgv_ListaPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaPersonal.CurrentCell.ColumnIndex
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaPersonal.CurrentRow.Index
                Try
                    Valor_Copiar = Me.Dgv_ListaPersonal.Item(Indice_Columna, IndiceFilaseleccionada).Value
                Catch ex As Exception
                End Try
            Case Me.Tp_Equipo.Name
                Nombre_Columna = Me.Dgv_ListaEquipos.Columns(Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaEquipos.CurrentRow.Index
                Try
                    Valor_Copiar = Me.Dgv_ListaEquipos.Item(Indice_Columna, IndiceFilaseleccionada).Value
                Catch ex As Exception
                End Try
            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Articulos.CurrentCell.ColumnIndex
                Dim IndiceFilaseleccionada As Integer = Dgv_Articulos.CurrentRow.Index
                Try
                    Valor_Copiar = Me.Dgv_Articulos.Item(Indice_Columna, IndiceFilaseleccionada).Value
                Catch ex As Exception
                End Try
            Case Me.Tp_CostoIndirecto.Name
                Nombre_Columna = Me.Dgv_ListaCostosIndirectos.Columns(Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaCostosIndirectos.CurrentRow.Index
                Try
                    Valor_Copiar = Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, IndiceFilaseleccionada).Value
                Catch ex As Exception
                End Try

        End Select

        If Valor_Copiar = "" Then
            Exit Sub
        Else
            If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Select Case Nombre_Columna
                    Case "Num SolPed", "Pos Ser"
                        If IsNumeric(Valor_Copiar) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        Else
                            Valor_Copiar = Replace(Valor_Copiar, ".", ",")
                            Redondeo(CDec(Valor_Copiar), 0)
                        End If
                End Select
            Case Me.Tp_Complemento.Name
                Select Case Nombre_Columna
                    Case "D", "A", "C", "H", "M"
                        If UCase(Valor_Copiar) <> "X" Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        Else
                            Valor_Copiar = UCase(Valor_Copiar)
                        End If
                    Case "Vlr Des", "Vlr Alm", "Vlr Com", "Vlr Hotel", "Vlr Misc"
                        If IsNumeric(Valor_Copiar) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        Else
                            Valor_Copiar = Replace(Valor_Copiar, ".", ",")
                            Redondeo(CDec(Valor_Copiar), 0)
                        End If
                End Select
            Case Me.Tp_Personal.Name
                Select Case Nombre_Columna
                    Case "Servicio"
                        If IsNumeric(Valor_Copiar) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        End If
                End Select
            Case Me.Tp_Equipo.Name
                Select Case Nombre_Columna
                    Case "Servicio"
                        If IsNumeric(Valor_Copiar) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        End If
                End Select
            Case Me.Tp_Materiales.Name
                Select Case Nombre_Columna
                    Case "Servicio"
                        If IsNumeric(Valor_Copiar) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        End If
                End Select
            Case Me.Tp_CostoIndirecto.Name
                Select Case Nombre_Columna
                    Case "Servicio"
                        If IsNumeric(Valor_Copiar) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        End If
                End Select
        End Select

        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor

        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Try
                    For i = 0 To Me.Dgv_ListaServicios.RowCount - 1
                        If Me.Dgv_ListaServicios.Item(1, i).Value <> Nothing Then
                            Me.Dgv_ListaServicios.Item(Indice_Columna, i).Value = Valor_Copiar
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaServicios.CurrentCell = Me.Dgv_ListaServicios(0, 1)
                    Me.Dgv_ListaServicios.CurrentCell = Me.Dgv_ListaServicios(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtservicios.AcceptChanges()
            Case Me.Tp_Complemento.Name
                Try
                    For i = 0 To Me.Dgv_CostosPersonal.RowCount - 1
                        If Me.Dgv_CostosPersonal.Item(1, i).Value <> Nothing Then
                            Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = Valor_Copiar
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(0, 1)
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtpersonal.AcceptChanges()
                calcularfilasdtopersonal()
            Case Me.Tp_Personal.Name
                Try
                    For i = 0 To Me.Dgv_ListaPersonal.RowCount - 1
                        If Me.Dgv_ListaPersonal.Item(1, i).Value <> Nothing Then
                            Me.Dgv_ListaPersonal.Item(Indice_Columna, i).Value = Valor_Copiar
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaPersonal.CurrentCell = Me.Dgv_ListaPersonal(0, 1)
                    Me.Dgv_ListaPersonal.CurrentCell = Me.Dgv_ListaPersonal(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtpersonal.AcceptChanges()
                calcularfilasdtopersonal()

            Case Me.Tp_Equipo.Name
                Try
                    For i = 0 To Me.Dgv_ListaEquipos.RowCount - 1
                        If Me.Dgv_ListaEquipos.Item(1, i).Value <> Nothing Then
                            Me.Dgv_ListaEquipos.Item(Indice_Columna, i).Value = Valor_Copiar
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaEquipos.CurrentCell = Me.Dgv_ListaEquipos(0, 1)
                    Me.Dgv_ListaEquipos.CurrentCell = Me.Dgv_ListaEquipos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtequipos.AcceptChanges()


            Case Me.Tp_Materiales.Name
                Try
                    For i = 0 To Me.Dgv_Articulos.RowCount - 1
                        If Me.Dgv_Articulos.Item(2, i).Value <> Nothing Then
                            Me.Dgv_Articulos.Item(Indice_Columna, i).Value = Valor_Copiar
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_Articulos.CurrentCell = Me.Dgv_Articulos(0, 1)
                    Me.Dgv_Articulos.CurrentCell = Me.Dgv_Articulos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtarticulos.AcceptChanges()

            Case Me.Tp_CostoIndirecto.Name
                Try
                    For i = 0 To Me.Dgv_ListaCostosIndirectos.RowCount - 1
                        If Me.Dgv_ListaCostosIndirectos.Item(1, i).Value <> Nothing Then
                            Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, i).Value = Valor_Copiar
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaCostosIndirectos.CurrentCell = Me.Dgv_ListaCostosIndirectos(0, 1)
                    Me.Dgv_ListaCostosIndirectos.CurrentCell = Me.Dgv_ListaCostosIndirectos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtcostosindirectos.AcceptChanges()
        End Select

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub calcularfilasdtopersonal()
        Dim i As Integer

        For i = 0 To dtpersonal.Rows.Count - 1
            Dim fila As DataRow = dtpersonal.Rows(i)
            CalculoPersonalyCostosfila(fila)
        Next
        TotalOT()
    End Sub
    Private Sub ReemplazarValorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ReemplazarValor.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Complemento.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
        End Select
        Dim Valor_Reemplazar As String
        Dim Valor_PorElQue_Reemplazara As String
        Valor_Reemplazar = InputBox("¿Que valor desea reemplazar en las celdas de la columna " + Nombre_Columna + "?", "Valor a reemplazar" + Nombre_Columna, "")
        If Valor_Reemplazar = "" Then
            Exit Sub
        End If
        Valor_PorElQue_Reemplazara = InputBox("¿Por que valor desea reemplazar las celdas que concuerden en la columna " + Nombre_Columna + "?", "Valor que reemplazara" + Nombre_Columna, "")
        If Valor_PorElQue_Reemplazara = "" Then
            Exit Sub
        Else
            If MsgBox("¿Seguro que desea reemplazar el valor " + _
                  Valor_Reemplazar + " por el valor " + _
                  Valor_PorElQue_Reemplazara + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If


        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Complemento.Name
                Select Case Nombre_Columna
                    Case "Vlr Des", "Vlr Alm", "Vlr Com", "Vlr Hotel", "Vlr Misc"
                        If IsNumeric(Valor_PorElQue_Reemplazara) = False Then
                            MsgBox("Valor no valido")
                            Exit Sub
                        Else
                            Valor_PorElQue_Reemplazara = Replace(Valor_PorElQue_Reemplazara, ".", ",")
                            Redondeo(CDec(Valor_PorElQue_Reemplazara), 0)
                        End If
                End Select
        End Select



        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Complemento.Name
                Try
                    For i = 0 To Me.Dgv_CostosPersonal.RowCount - 2
                        If Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value.ToString = Valor_Reemplazar Then
                            Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = Valor_PorElQue_Reemplazara
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(0, 1)
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtpersonal.AcceptChanges()

        End Select
        calcularfilasdtopersonal()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub TSMI_X_Click(sender As Object, e As EventArgs) Handles TSMI_X.Click

        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer


        Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "X"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_CostosPersonal.RowCount - 1
                Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(0, 1)
            Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
        dtpersonal.AcceptChanges()
        calcularfilasdtopersonal()
    End Sub



    Private Sub TSMI_LimpiarTodas_Click(sender As Object, e As EventArgs) Handles TSMI_LimpiarTodas.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Nombre_Columna = Me.Dgv_ListaServicios.Columns(Me.Dgv_ListaServicios.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaServicios.CurrentCell.ColumnIndex
            Case Me.Tp_Complemento.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
            Case Me.Tp_Personal.Name
                Nombre_Columna = Me.Dgv_ListaPersonal.Columns(Me.Dgv_ListaPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaPersonal.CurrentCell.ColumnIndex
            Case Me.Tp_Equipo.Name
                Nombre_Columna = Me.Dgv_ListaEquipos.Columns(Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex
            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Articulos.CurrentCell.ColumnIndex
            Case Me.Tp_CostoIndirecto.Name
                Nombre_Columna = Me.Dgv_ListaCostosIndirectos.Columns(Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex
        End Select
        Dim Valor_Copiar As String = ""
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor

        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Try
                    For i = 0 To Me.Dgv_ListaServicios.RowCount - 1
                        Me.Dgv_ListaServicios.Item(Indice_Columna, i).Value = DBNull.Value

                        Me.Dgv_ListaServicios.Item(Indice_Columna, i).Value = DBNull.Value
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaServicios.CurrentCell = Me.Dgv_ListaServicios(0, 1)
                    Me.Dgv_ListaServicios.CurrentCell = Me.Dgv_ListaServicios(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtservicios.AcceptChanges()
            Case Me.Tp_Complemento.Name
                Try
                    For i = 0 To Me.Dgv_CostosPersonal.RowCount - 1
                        Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = DBNull.Value

                        Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = DBNull.Value
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(0, 1)
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtpersonal.AcceptChanges()
            Case Me.Tp_Personal.Name
                Try
                    For i = 0 To Me.Dgv_ListaPersonal.RowCount - 1
                        Me.Dgv_ListaPersonal.Item(Indice_Columna, i).Value = DBNull.Value

                        Me.Dgv_ListaPersonal.Item(Indice_Columna, i).Value = DBNull.Value
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaPersonal.CurrentCell = Me.Dgv_ListaPersonal(0, 1)
                    Me.Dgv_ListaPersonal.CurrentCell = Me.Dgv_ListaPersonal(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtpersonal.AcceptChanges()
            Case Me.Tp_Equipo.Name
                Try
                    For i = 0 To Me.Dgv_ListaEquipos.RowCount - 1
                        Me.Dgv_ListaEquipos.Item(Indice_Columna, i).Value = DBNull.Value

                        Me.Dgv_ListaEquipos.Item(Indice_Columna, i).Value = DBNull.Value
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaEquipos.CurrentCell = Me.Dgv_ListaEquipos(0, 1)
                    Me.Dgv_ListaEquipos.CurrentCell = Me.Dgv_ListaEquipos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtequipos.AcceptChanges()
            Case Me.Tp_Materiales.Name
                Try
                    For i = 0 To Me.Dgv_Articulos.RowCount - 1
                        Me.Dgv_Articulos.Item(Indice_Columna, i).Value = DBNull.Value

                        Me.Dgv_Articulos.Item(Indice_Columna, i).Value = DBNull.Value
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_Articulos.CurrentCell = Me.Dgv_Articulos(0, 1)
                    Me.Dgv_Articulos.CurrentCell = Me.Dgv_Articulos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtarticulos.AcceptChanges()
            Case Me.Tp_CostoIndirecto.Name
                Try
                    For i = 0 To Me.Dgv_ListaCostosIndirectos.RowCount - 1
                        Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, i).Value = DBNull.Value

                        Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, i).Value = DBNull.Value
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaCostosIndirectos.CurrentCell = Me.Dgv_ListaCostosIndirectos(0, 1)
                    Me.Dgv_ListaCostosIndirectos.CurrentCell = Me.Dgv_ListaCostosIndirectos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                dtcostosindirectos.AcceptChanges()
        End Select
        calcularfilasdtopersonal()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_LlenarCon_Click(sender As Object, e As EventArgs) Handles TSMI_LlenarCon.Click

        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Dim Valor_Copiar As String

        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                Nombre_Columna = Me.Dgv_ListaServicios.Columns(Me.Dgv_ListaServicios.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaServicios.CurrentCell.ColumnIndex

        End Select
        Valor_Copiar = InputBox("¿Que valor desea copiar en las celdas de la columna " + Nombre_Columna + "?", "Valor a copiar" + Nombre_Columna, "")

        If Valor_Copiar = "" Then
            Exit Sub
        End If
        Select Case Tc_ListaActividades.SelectedTab.Name
            Case Me.Tp_Servicio.Name
                If MsgBox("¿Seguro que desea copiar el valor " + _
                    Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
                Dim i As Integer
                Me.Cursor = Cursors.WaitCursor
                Try
                    For i = 0 To Me.Dgv_ListaServicios.RowCount - 1
                        Me.Dgv_ListaServicios.Item(Indice_Columna, i).Value = Valor_Copiar
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaServicios.CurrentCell = Me.Dgv_ListaServicios(0, 1)
                    Me.Dgv_ListaServicios.CurrentCell = Me.Dgv_ListaServicios(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                Me.Cursor = Cursors.Default
                dtservicios.AcceptChanges()
        End Select


    End Sub



    Private Sub Fr_OT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
            Cu_padre.ReactivarPrincipal = True
        Else
            Cu_padre.ReactivarPrincipal = False
        End If
        Cu_padre.Ubicar_Registro()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub




    Private Sub Pegar(sender As Object, e As KeyEventArgs) Handles Dgv_ListaPersonal.KeyDown, Dgv_ListaEquipos.KeyDown, Dgv_ListaCostosIndirectos.KeyDown, Dgv_Articulos.KeyDown
        Try
            Dim filaseleccionada As Integer
            Dim columnaseleccionada As Integer
            If e.Control AndAlso e.KeyCode = Keys.V Then
                Dim texto_obtenido As String = Clipboard.GetText()
                Select Case Tc_ListaActividades.SelectedTab.Name
                    Case Me.Tp_Personal.Name
                        If Me.Dgv_ListaPersonal.Columns(Me.Dgv_ListaPersonal.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                            filaseleccionada = Dgv_ListaPersonal.CurrentRow.Index
                            columnaseleccionada = Dgv_ListaPersonal.CurrentCell.ColumnIndex
                            Dgv_ListaPersonal(columnaseleccionada, filaseleccionada).Value = texto_obtenido
                        End If
                    Case Me.Tp_Equipo.Name
                        If Me.Dgv_ListaEquipos.Columns(Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                            filaseleccionada = Dgv_ListaEquipos.CurrentRow.Index
                            columnaseleccionada = Dgv_ListaEquipos.CurrentCell.ColumnIndex
                            Dgv_ListaEquipos(columnaseleccionada, filaseleccionada).Value = texto_obtenido
                        End If

                    Case Me.Tp_CostoIndirecto.Name
                        If Me.Dgv_ListaCostosIndirectos.Columns(Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                            filaseleccionada = Dgv_ListaCostosIndirectos.CurrentRow.Index
                            columnaseleccionada = Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex
                            Dgv_ListaCostosIndirectos(columnaseleccionada, filaseleccionada).Value = texto_obtenido
                        End If
                    Case Me.Tp_Materiales.Name
                        If Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                            filaseleccionada = Dgv_Articulos.CurrentRow.Index
                            columnaseleccionada = Dgv_Articulos.CurrentCell.ColumnIndex
                            Dgv_Articulos(columnaseleccionada, filaseleccionada).Value = texto_obtenido
                        End If
                End Select

            Else
                If e.KeyCode = "" Then
                    Select Case Tc_ListaActividades.SelectedTab.Name
                        Case Me.Tp_Personal.Name

                            filaseleccionada = Dgv_ListaPersonal.CurrentRow.Index
                            columnaseleccionada = Dgv_ListaPersonal.CurrentCell.ColumnIndex
                            Dgv_ListaPersonal(columnaseleccionada, filaseleccionada).Value = DBNull.Value
                        Case Me.Tp_Equipo.Name
                            If Me.Dgv_ListaEquipos.Columns(Me.Dgv_ListaEquipos.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                                filaseleccionada = Dgv_ListaEquipos.CurrentRow.Index
                                columnaseleccionada = Dgv_ListaEquipos.CurrentCell.ColumnIndex
                                Dgv_ListaEquipos(columnaseleccionada, filaseleccionada).Value = DBNull.Value
                            End If

                        Case Me.Tp_CostoIndirecto.Name
                            If Me.Dgv_ListaCostosIndirectos.Columns(Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                                filaseleccionada = Dgv_ListaCostosIndirectos.CurrentRow.Index
                                columnaseleccionada = Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex
                                Dgv_ListaCostosIndirectos(columnaseleccionada, filaseleccionada).Value = DBNull.Value
                            End If
                        Case Me.Tp_Materiales.Name
                            If Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText = "Servicio" Then
                                filaseleccionada = Dgv_Articulos.CurrentRow.Index
                                columnaseleccionada = Dgv_Articulos.CurrentCell.ColumnIndex
                                Dgv_Articulos(columnaseleccionada, filaseleccionada).Value = DBNull.Value
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tx_PorAdministración_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_PorAdministración.KeyPress
        If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub


End Class