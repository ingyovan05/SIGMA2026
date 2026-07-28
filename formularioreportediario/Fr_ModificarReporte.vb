Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_ModificarReporte
    Public IdReporteDiario_Modificar As Int64 = -1
    Public IdContratoReporteDiario_Modificar As Int64 = -1
    Public TipoAccion As String = "I" ' "I"-Insertar "E"-Editar  "V"-Ver
    Public guardado As Boolean = False
    Public CargandoFormulario As Boolean = True
    Public APROBADOENVIO As Boolean = False
    Public Cu_padre As Object
    Private FilaReporteDiario As DataRow
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private TPersonas As New DataTable
    Private TEquipos As New DataTable
    Private TActividades As New DataTable
    Private TArticulos As New DataTable
    Private TCostosIndirectos As New DataTable
    Private TIntegrantes As New DataTable
    Private TServiciosActuales As New DataTable
    Private TClaseAtencíón As New DataTable
    Private tablaunidades As New DataTable
    Private ObservacioActual As Integer = -1
    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Estilo_Celda As New DataGridViewCellStyle
    Private MensajeError As String
    Private Idbase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual

    Public Sub CargarValores()
        Me.Dgv_ListaPersonas.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaPersonas.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_CostosPersonal.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_CostosPersonal.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Equipos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Equipos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Actividades.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Actividades.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub

    Public Sub RegistrarNovedad()
        Me.Pn_Personas.Enabled = False
        Me.Pn_Básicos.Enabled = False
        Me.Pn_ObservaciónPersona.Enabled = False
        Me.Pn_ObservaciónComplemento.Enabled = False
        Me.Tc_Recursos.TabPages.Remove(Me.Tp_CostosIndirectos)
        Me.Tc_Recursos.TabPages.Remove(Me.Tp_Equipos)
        Me.Tc_Recursos.TabPages.Remove(Me.Tp_Materiales)
        Me.Tc_Recursos.TabPages.Remove(Me.Tp_Actividades)
        Me.Dgv_ListaPersonas.AllowUserToAddRows = False
        Me.Dgv_ListaPersonas.AllowUserToDeleteRows = False
        Me.Dgv_CostosPersonal.AllowUserToAddRows = False
        Me.Dgv_CostosPersonal.AllowUserToDeleteRows = False
        Me.DGVTBC_CODIGOCONTRATO.ReadOnly = True
        DGVTBC_CODIGOCONTRATO.ReadOnly = True
    End Sub

    Public Sub Cargar_Tablas()
        Estilo_Celda_Error.BackColor = Color.Red
        Estilo_Celda.BackColor = Color.White

        '-- 0 --> REPORTEDIARIO
        '-- 1 --> REPORTEDIARIOPERSONA
        '-- 2 --> REPORTEDIARIOEQUIPO
        '-- 3 --> REPORTEDIARIOACTIVIDAD
        '-- 4 --> REPORTEDIARIOARTICULOS
        '-- 5 --> MA_TIPODISCIPLINA
        '-- 6 --> MA_TIPOTIEMPO
        '-- 7 --> MA_TIPOPARO
        '-- 8 --> CUADRILLA
        '-- 9 --> MA_TIPOCARGO
        '-- 10--> MA_POBLACION
        '-- 11--> MA_TIPOUNIDAD
        '-- 12--> MA_CENTROCOSTOSSOLIN
        '-- 13--> RD_MA_CLASEATENCION
        '-- 14--> RD_MA_TIPORECURSO
        '-- 15--> CUADRILLAS
        '-- 16--> SERVICIOS ACTUALES
        '-- 17--> REPORTEDIARIOCOSTOINDIRECTO
        '-- 18--> RD_MA_TIPOCLASIFICACIONMATERIAL
        '-- 19--> MA_CONFIGURACIONBASE

        Dim dsCargar As New DataSet
        Select Case TipoAccion
            Case "N"
                dsCargar = bddatos.CargarMaestras(11, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdReporteDiario_Modificar, IIf(IdReporteDiario_Modificar = -1, 1, 2), IdContratoReporteDiario_Modificar)
            Case "E", "I"
                dsCargar = bddatos.CargarMaestras(3, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdReporteDiario_Modificar, IIf(IdReporteDiario_Modificar = -1, 1, 2))
        End Select

        Me.Cb_Disciplina.DataSource = dsCargar.Tables(5)
        Me.Cb_Disciplina.ValueMember = "CODIGOTIPODISCIPLINA"
        Me.Cb_Disciplina.DisplayMember = "NOMBRETIPODISCIPLINA"

        Me.Cb_Tiempo.DataSource = dsCargar.Tables(6)
        Me.Cb_Tiempo.ValueMember = "CODIGOTIPOTIEMPO"
        Me.Cb_Tiempo.DisplayMember = "NOMBRETIPOTIEMPO"

        Me.Cb_Paro.DataSource = dsCargar.Tables(7)
        Me.Cb_Paro.ValueMember = "CODIGOTIPOPARO"
        Me.Cb_Paro.DisplayMember = "NOMBRETIPOPARO"

        Me.Cb_Cuadrilla.DataSource = dsCargar.Tables(8)
        Me.Cb_Cuadrilla.ValueMember = "IDCUADRILLA"
        Me.Cb_Cuadrilla.DisplayMember = "NOMBRECUADRILLA"

        Me.DGVCBC_NOMBRETIPOCARGO.DataSource = dsCargar.Tables(9)
        Me.DGVCBC_NOMBRETIPOCARGO.ValueMember = "CODIGOTIPOCARGO"
        Me.DGVCBC_NOMBRETIPOCARGO.DisplayMember = "NOMBRETIPOCARGO"

        Me.DGVTBC_CODIGOPOBLACIONACTIVIDADES.DataSource = dsCargar.Tables(10)
        Me.DGVTBC_CODIGOPOBLACIONACTIVIDADES.ValueMember = "CODIGOPOBLACION"
        Me.DGVTBC_CODIGOPOBLACIONACTIVIDADES.DisplayMember = "NOMBREPOBLACION"

        Me.DGVCBC_CODIGOTIPOUNIDADACTIVIDAD.DataSource = dsCargar.Tables(11)
        Me.DGVCBC_CODIGOTIPOUNIDADACTIVIDAD.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVCBC_CODIGOTIPOUNIDADACTIVIDAD.DisplayMember = "ABREVIATURA"

        Me.DGVCBC_CODIGOTIPOUNIDADARTICULO.DataSource = dsCargar.Tables(11)
        Me.DGVCBC_CODIGOTIPOUNIDADARTICULO.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVCBC_CODIGOTIPOUNIDADARTICULO.DisplayMember = "ABREVIATURA"

        Me.DGVTBC_CODIGOTIPOUNIDADSERVICIO.DataSource = dsCargar.Tables(11)
        Me.DGVTBC_CODIGOTIPOUNIDADSERVICIO.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVTBC_CODIGOTIPOUNIDADSERVICIO.DisplayMember = "ABREVIATURA"

        Me.DGVTBC_IDCLASEATENCION1.DataSource = dsCargar.Tables(13)
        Me.DGVTBC_IDCLASEATENCION1.ValueMember = "IDCLASEATENCION"
        Me.DGVTBC_IDCLASEATENCION1.DisplayMember = "NOMBRECLASEATENCION"

        Me.DGVTBC_IDTIPORECURSO.DataSource = dsCargar.Tables(14)
        Me.DGVTBC_IDTIPORECURSO.ValueMember = "IDTIPORECURSO"
        Me.DGVTBC_IDTIPORECURSO.DisplayMember = "NOMBRETIPORECURSO"

        Me.DGVCBC_TIPOCLASIFICACIONMATERIAL.DataSource = dsCargar.Tables(18)
        Me.DGVCBC_TIPOCLASIFICACIONMATERIAL.ValueMember = "IDTIPOCLASIFICACIONMATERIAL"
        Me.DGVCBC_TIPOCLASIFICACIONMATERIAL.DisplayMember = "NOMBRETIPOCLASIFICACIONMATERIAL"

        Me.DGVTBC_IDCLASEATENCIONSERVICIO.DataSource = dsCargar.Tables(13)
        Me.DGVTBC_IDCLASEATENCIONSERVICIO.ValueMember = "IDCLASEATENCION"
        Me.DGVTBC_IDCLASEATENCIONSERVICIO.DisplayMember = "NOMBRECLASEATENCION"

        TClaseAtencíón = dsCargar.Tables(13)
        tablaunidades = dsCargar.Tables(11)

        'Cargar Integrantes
        TIntegrantes = dsCargar.Tables(15)

        'Cargar servicios actuales
        TServiciosActuales = dsCargar.Tables(16)

        Dim F_CentroCosto As DataRow
        F_CentroCosto = dsCargar.Tables(12).Rows(0)

        Me.Cu_CentroCosto1.IdCentroCosto = F_CentroCosto("IDCENTROCOSTO")
        Me.Cu_CentroCosto1.Ll_CentroCostos.Text = F_CentroCosto("NOMBRE").ToString

        Me.Cu_JefeCuadrilla.CargarDatos()
        Me.Cu_Administrador.CargarDatos()
        Me.Cu_Superintendente.CargarDatos()
        Me.Cu_DirectorObra.CargarDatos()

        Try
            Me.Cu_Administrador.Cb_Persona.SelectedValue = dsCargar.Tables(19).Rows(0).Item("IDPERSONAADMINISTRADOR")
        Catch
        End Try
        Try
            Me.Cu_Superintendente.Cb_Persona.SelectedValue = dsCargar.Tables(19).Rows(0).Item("IDPERSONARESIDENTE")
        Catch
        End Try
        Try
            Me.Cu_DirectorObra.Cb_Persona.SelectedValue = dsCargar.Tables(19).Rows(0).Item("IDPERSONARESIDENTE")
        Catch
        End Try

        Me.DGVTBC_HORAINICIALTURNO1.DataSource = dsCargar.Tables(20)
        Me.DGVTBC_HORAINICIALTURNO1.ValueMember = "IDHORARD"
        Me.DGVTBC_HORAINICIALTURNO1.DisplayMember = "HORA"

        Me.DGVTBC_HORAFINALTURNO1.DataSource = dsCargar.Tables(20)
        Me.DGVTBC_HORAFINALTURNO1.ValueMember = "IDHORARD"
        Me.DGVTBC_HORAFINALTURNO1.DisplayMember = "HORA"

        Me.DGVTBC_HORAINICIALTURNO2.DataSource = dsCargar.Tables(20)
        Me.DGVTBC_HORAINICIALTURNO2.ValueMember = "IDHORARD"
        Me.DGVTBC_HORAINICIALTURNO2.DisplayMember = "HORA"

        Me.DGVTBC_HORAFINALTURNO2.DataSource = dsCargar.Tables(20)
        Me.DGVTBC_HORAFINALTURNO2.ValueMember = "IDHORARD"
        Me.DGVTBC_HORAFINALTURNO2.DisplayMember = "HORA"


        'Cargar personas
        TPersonas = dsCargar.Tables(1)
        Me.Dgv_ListaPersonas.DataSource = TPersonas
        Me.Dgv_CostosPersonal.DataSource = TPersonas

        'Cargar equipos
        TEquipos = dsCargar.Tables(2)
        Me.Dgv_Equipos.DataSource = TEquipos

        'Cargar Actividades
        TActividades = dsCargar.Tables(3)
        Me.Dgv_Actividades.DataSource = TActividades

        'Cargar Articulos
        TArticulos = dsCargar.Tables(4)
        Me.Dgv_Articulos.DataSource = TArticulos

        'cargar costos indirectos
        TCostosIndirectos = dsCargar.Tables(17)
        Me.Dgv_ListaCostosIndirectos.DataSource = TCostosIndirectos

        Select Case TipoAccion
            Case "E", "N"
                FilaReporteDiario = dsCargar.Tables(0).Rows(0)
            Case "I"
                Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
                Cu_CentroCosto1.Editando = 2
                Me.Cu_CentroCosto1.CargarCentro()
        End Select
    End Sub

    Public Sub AplicarFormatoColumnas()
        For i = 0 To Dgv_ListaPersonas.ColumnCount - 1
            Select Case Dgv_ListaPersonas.Columns(i).Name
                Case "DGVTBC_ORDEN"
                    Dgv_ListaPersonas.Columns(i).Width = 43
                Case "DGVTBC_NOMBREPERSONA"
                    Dgv_ListaPersonas.Columns(i).Width = 150
                Case "DGVTBC_CODIGOTIPOSALARIO"
                    Dgv_ListaPersonas.Columns(i).Width = 35
                Case "DGVCBC_CODIGOTIPOCATEGORIA"
                    Dgv_ListaPersonas.Columns(i).Width = 35
                Case "DGVCBC_NOMBRETIPOCARGO"
                    Dgv_ListaPersonas.Columns(i).Width = 150
                Case "DGVTBC_HORAINICIALTURNO1"
                    Dgv_ListaPersonas.Columns(i).Width = 55
                Case "DGVTBC_HORAFINALTURNO1"
                    Dgv_ListaPersonas.Columns(i).Width = 55
                Case "DGVTBC_HORAINICIALTURNO2"
                    Dgv_ListaPersonas.Columns(i).Width = 55
                Case "DGVTBC_HORAFINALTURNO2"
                    Dgv_ListaPersonas.Columns(i).Width = 55
                Case "DGVTBC_USOHORAALMUERZO"
                    Dgv_ListaPersonas.Columns(i).Width = 40
                Case "DGVTBC_TOTAL"
                    Dgv_ListaPersonas.Columns(i).Width = 32
                Case "DGVTBC_HORASNORMALES"
                    Dgv_ListaPersonas.Columns(i).Width = 40
                Case "DGVTBC_HORASEXTRASDIURNAS"
                    Dgv_ListaPersonas.Columns(i).Width = 35
                Case "DGVTBC_HORASEXTRASNOCTURNAS"
                    Dgv_ListaPersonas.Columns(i).Width = 35
                Case "DGVTBC_HORASRECARGONOCTURNO"
                    Dgv_ListaPersonas.Columns(i).Width = 32
                Case "DGVTBC_SERVICIO"
                    Dgv_ListaPersonas.Columns(i).Width = 110
                Case "DGVTBC_CODIGOCONTRATO"
                    Dgv_ListaPersonas.Columns(i).Width = 50
                Case "DGVTBC_IDCLASEATENCION1"
                    Dgv_ListaPersonas.Columns(i).Width = 140
                Case Else
                    Dgv_ListaPersonas.Columns(i).Visible = False
            End Select
        Next

        For i = 0 To Dgv_CostosPersonal.ColumnCount - 1
            Select Case Dgv_CostosPersonal.Columns(i).Name
                Case "DGVTBC_ORDEN1"
                    Dgv_CostosPersonal.Columns(i).Width = 43
                Case "DGVTBC_CODIGOCONTRATO1"
                    Dgv_CostosPersonal.Columns(i).Width = 50
                Case "DGVTBC_NOMBREPERSONA1"
                    Dgv_CostosPersonal.Columns(i).Width = 200
                Case "DGVTBC_DESAYUNO"
                    Dgv_CostosPersonal.Columns(i).Width = 22
                Case "DGVTBC_ALMUERZO"
                    Dgv_CostosPersonal.Columns(i).Width = 22
                Case "DGVTBC_COMIDA"
                    Dgv_CostosPersonal.Columns(i).Width = 22
                Case "DGVTBC_ALOJAMIENTO"
                    Dgv_CostosPersonal.Columns(i).Width = 22
                Case "DGVTBC_MISCELANIOS"
                    Dgv_CostosPersonal.Columns(i).Width = 22
                Case "DGVTBC_VALORDESAYUNO"
                    Dgv_CostosPersonal.Columns(i).Width = 60
                Case "DGVTBC_VALORALMUERZO"
                    Dgv_CostosPersonal.Columns(i).Width = 60
                Case "DGVTBC_VALORCOMIDA"
                    Dgv_CostosPersonal.Columns(i).Width = 60
                Case "DGVTBC_VALORALOJAMIENTO"
                    Dgv_CostosPersonal.Columns(i).Width = 60
                Case "DGVTBC_VALORMISCELANIOS"
                    Dgv_CostosPersonal.Columns(i).Width = 60
                Case "DGVTBC_IDTIPORECURSO"
                    Dgv_CostosPersonal.Columns(i).Width = 200
                Case "DGVTBC_OBSERVACION"
                Case Else
                    Dgv_CostosPersonal.Columns(i).Visible = False
            End Select
        Next

        For i = 0 To Dgv_Equipos.ColumnCount - 1
            Select Case Dgv_Equipos.Columns(i).Name
                Case "DGVTBC_ORDENEQUIPO"
                    Dgv_Equipos.Columns(i).Width = 50
                Case "DGVTBC_CODIGOEQUIPO"
                    Dgv_Equipos.Columns(i).Width = 120
                Case "DGVTBC_DESCRIPCIONEQUIPO"
                    Dgv_Equipos.Columns(i).Width = 220
                Case "DGVTBC_TOTALEQUIPO"
                    Dgv_Equipos.Columns(i).Width = 50
                Case "DGVTBC_INICIAL"
                    Dgv_Equipos.Columns(i).Width = 50
                Case "DGVTBC_FINAL"
                    Dgv_Equipos.Columns(i).Width = 50
                Case "DGVCBC_DISPONIBLE"
                    Dgv_Equipos.Columns(i).Width = 30
                Case "DGVCBC_VARADO"
                    Dgv_Equipos.Columns(i).Width = 30
                Case "DGVCBC_OBSERVACION"
                    Dgv_Equipos.Columns(i).Width = 150
                Case "DGVCBC_SERVICIOEQUIPO"
                    Dgv_Equipos.Columns(i).Width = 100
                Case "DGVTBC_VALOREQUIPO"
                    Dgv_Equipos.Columns(i).Width = 80
                Case Else
                    Dgv_Equipos.Columns(i).Visible = False
            End Select
        Next

        For i = 0 To Dgv_Actividades.ColumnCount - 1
            Select Case Dgv_Actividades.Columns(i).Name
                Case "DGVTBC_SERVICIOACTIVIDAD" 'Servicio
                    Dgv_Actividades.Columns(i).Width = 105
                Case "DGVTBC_DESCRIPCIONACTIVIDAD" 'Descripción
                    Dgv_Actividades.Columns(i).Width = 240
                Case "DGVCBC_CODIGOTIPOUNIDADACTIVIDAD" 'Und
                    Dgv_Actividades.Columns(i).Width = 60
                Case "DGVTBC_AVANCE" 'Avance
                    Dgv_Actividades.Columns(i).Width = 60
                Case "DGVTBC_CODIGOPOBLACIONACTIVIDADES" 'Municipio
                    Dgv_Actividades.Columns(i).Width = 180
                Case "DGVTBC_IDCLASEATENCIONSERVICIO" 'Clase Atención
                    Dgv_Actividades.Columns(i).Width = 155
                Case "DGVTBC_AVANCETECNICO" 'Avance técnico
                    Dgv_Actividades.Columns(i).Width = 300
                Case Else
                    Dgv_Actividades.Columns(i).Visible = False
            End Select
        Next

        For i = 0 To Dgv_Articulos.ColumnCount - 1
            Select Case Dgv_Articulos.Columns(i).Name
                Case "Col_IdArticulo"
                    Dgv_Articulos.Columns(i).Width = 70
                Case "DGVTBC_DESCRIPCIONARTICULO"
                    Dgv_Articulos.Columns(i).Width = 500
                Case "DGVCBC_CODIGOTIPOUNIDADARTICULO"
                    Dgv_Articulos.Columns(i).Width = 60
                Case "DGVTBC_VALORUNITARIO"
                    Dgv_Articulos.Columns(i).Width = 90

                Case "DGVTBC_CANTIDADARTICULO"
                    Dgv_Articulos.Columns(i).Width = 50
                Case "DGVTBC_VALORTOTALARTICULO"
                    Dgv_Articulos.Columns(i).Width = 90
                Case "DGVCBC_SERVICIOARTICULO"
                    Dgv_Equipos.Columns(i).Width = 100
                Case "DGVCBC_TIPOCLASIFICACIONMATERIAL"
                    Dgv_Equipos.Columns(i).Width = 150
                Case Else
                    Dgv_Articulos.Columns(i).Visible = False
            End Select
        Next

        Personalizar_Datagrid()
    End Sub

    Private Sub Personalizar_Datagrid()

        If VariablesBase.VariablesBase.TipoUsuario = 50 Then
            For i = 0 To Dgv_Equipos.Columns.Count - 1
                Select Case Dgv_Equipos.Columns(i).Name
                    Case "DGVTBC_VALOREQUIPO"
                        Dgv_Equipos.Columns(i).Visible = False
                End Select
            Next

            For i = 0 To Dgv_Articulos.Columns.Count - 1
                Select Case Dgv_Articulos.Columns(i).Name
                    Case "DGVTBC_VALORUNITARIO", "DGVTBC_VALORTOTALARTICULO"
                        Dgv_Articulos.Columns(i).Visible = False
                End Select
            Next

            For i = 0 To Dgv_ListaCostosIndirectos.Columns.Count - 1
                Select Case Dgv_ListaCostosIndirectos.Columns(i).Name
                    Case "DGVTBC_VALORUNITARIOCOSTOSINDIRECTOS", "DGVTBC_VALORTOTALCOSTOSINDIRECTOS"
                        Dgv_ListaCostosIndirectos.Columns(i).Visible = False
                End Select
            Next

        End If
    End Sub

#Region "Cargar Datos Editar y clonar"
    Public Sub CargarDatosReporteDiario()
        'Me.Cb_Cuadrilla.SelectedValue = FilaReporteDiario("IDCUADRILLA")
        Me.Cb_Cuadrilla.SelectedIndex = -1

        Me.Dtp_Fecha.Value = FilaReporteDiario("FECHAREPORTEDIARIO")
        'Me.Dtp_Fecha.Enabled = False

        Me.Cu_CentroCosto1.IdCentroCosto = FilaReporteDiario("IDCENTROCOSTO")
        Cu_CentroCosto1.Editando = 3
        Me.Cu_CentroCosto1.CargarCentro()

        Me.Cb_Disciplina.SelectedValue = FilaReporteDiario("CODIGOTIPODISCIPLINA")
        Me.Cb_Tiempo.SelectedValue = FilaReporteDiario("CODIGOTIPOTIEMPO")
        Me.Cb_Paro.SelectedValue = FilaReporteDiario("CODIGOTIPOPARO")
        If FilaReporteDiario("CODIGOTIPOPARO") = 0 Then
            Me.DTP_IncioParo.Value = FilaReporteDiario("FECHAREPORTEDIARIO")
            Me.DTP_FinParo.Value = FilaReporteDiario("FECHAREPORTEDIARIO")
        Else
            Me.DTP_IncioParo.Value = FilaReporteDiario("HORAINICIOPARO")
            Me.DTP_FinParo.Value = FilaReporteDiario("HORAFINPARO")
        End If
        Me.Tx_NombreFrente.Text = FilaReporteDiario("NOMBREFRENTETRABAJO")

        If IsDBNull(FilaReporteDiario("OBSERVACIONPERSONA")) = False Then
            Me.Tx_ObservaciónPersonas.Text = FilaReporteDiario("OBSERVACIONPERSONA")
        Else
            Me.Tx_ObservaciónPersonas.Text = ""
        End If

        If IsDBNull(FilaReporteDiario("OBSERVACIONCOMPLEMENTO")) = False Then
            Me.Tx_Observación_Complemento.Text = FilaReporteDiario("OBSERVACIONCOMPLEMENTO")
        Else
            Me.Tx_Observación_Complemento.Text = ""
        End If

        If IsDBNull(FilaReporteDiario("OBSERVACIONEQUIPO")) = False Then
            Me.Tx_ObservaciónEquipos.Text = FilaReporteDiario("OBSERVACIONEQUIPO")
        Else
            Me.Tx_ObservaciónEquipos.Text = ""
        End If

        If IsDBNull(FilaReporteDiario("OBSERVACIONAVANCE")) = False Then
            Me.Tx_ObservaciónAvanceObra.Text = FilaReporteDiario("OBSERVACIONAVANCE")
        Else
            Me.Tx_ObservaciónAvanceObra.Text = ""
        End If

        If IsDBNull(FilaReporteDiario("OBSERVACIONMATERIALES")) = False Then
            Me.Tx_ObservaciónMateriales.Text = FilaReporteDiario("OBSERVACIONMATERIALES")
        Else
            Me.Tx_ObservaciónMateriales.Text = ""
        End If

        If IsDBNull(FilaReporteDiario("OBSERVACIONCOSTOSINDIRECTOS")) = False Then
            Me.Tx_ObservaciónCostosIndirectos.Text = FilaReporteDiario("OBSERVACIONCOSTOSINDIRECTOS")
        Else
            Me.Tx_ObservaciónCostosIndirectos.Text = ""
        End If

        Me.Cu_JefeCuadrilla.Cb_Persona.SelectedValue = FilaReporteDiario("IDPERSONAJEFECUADRILLA")
        Me.Cu_Administrador.Cb_Persona.SelectedValue = FilaReporteDiario("IDPERSONAADMINISTRADOR")
        Me.Cu_Superintendente.Cb_Persona.SelectedValue = FilaReporteDiario("IDPERSONASUPERINTENDENTE")
        Me.Cu_DirectorObra.Cb_Persona.SelectedValue = FilaReporteDiario("IDPERSONADIRECTOROBRA")

        If APROBADOENVIO = True Then
            Me.Dgv_ListaPersonas.Enabled = False
        End If

    End Sub

    Public Sub LimpiarXClonación()
        'caundo se necesite limpiar algo al clonar
        Me.Dtp_Fecha.Enabled = True
    End Sub
#End Region

#Region "Guardar Datos"
    Private Function Guardar_Datos() As Boolean
        Try
            If validarservicios() Then
                If ValidarReporteDiario() Then
                    If Validar_ValoresListaIntegrantes() Then
                        If Validar_ValoresListaEquipos() Then
                            If Validar_ValoresListaActividades() Then
                                Guardar_Registro_ReporteDiario()
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

    Private Function validarservicios() As Boolean
        'recorrer los datagrid que tienen servicios
        'validar que tengan el id servicio
        'colocar el valor en caso que no tenga
        'marcar con error si algun servicio no corresponde
        'TPersonas()
        For i = 0 To TPersonas.Rows.Count - 1
            If IsDBNull(TPersonas.Rows(i).Item("SERVICIO")) = False Then
                If LTrim(RTrim(TPersonas.Rows(i).Item("SERVICIO"))) <> "" Then
                    If IsDBNull(TPersonas.Rows(i).Item("IDOTSERVICIO")) = True Then
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TPersonas.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length > 0 Then
                            Dim fila As DataRow
                            fila = filas(0)
                            TPersonas.Rows(i).Item("IDOTSERVICIO") = fila("IDOTSERVICIO")
                            TPersonas.Rows(i).Item("IDORDENTRABAJO") = fila("IDORDENTRABAJO")
                        Else
                            MsgBox("Personal --> Se ha agregado un servicio no valido " + TPersonas.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    Else
                        'verificar que el IDOTSERVICIO corresponda con el servicio
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TPersonas.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length = 0 Then
                            MsgBox("Personal --> Se ha agregado un servicio no valido " + TPersonas.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        'TEquipos()
        For i = 0 To TEquipos.Rows.Count - 1
            If IsDBNull(TEquipos.Rows(i).Item("SERVICIO")) = False Then
                If LTrim(RTrim(TEquipos.Rows(i).Item("SERVICIO"))) <> "" Then
                    If IsDBNull(TEquipos.Rows(i).Item("IDOTSERVICIO")) = True Then
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TEquipos.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length > 0 Then
                            Dim fila As DataRow
                            fila = filas(0)
                            TEquipos.Rows(i).Item("IDOTSERVICIO") = fila("IDOTSERVICIO")
                            TEquipos.Rows(i).Item("IDORDENTRABAJO") = fila("IDORDENTRABAJO")
                        Else
                            MsgBox("Equipos --> Se ha agregado un servicio no valido " + TEquipos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    Else
                        'verificar que el IDOTSERVICIO corresponda con el servicio
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TEquipos.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length = 0 Then
                            MsgBox("Equipos --> Se ha agregado un servicio no valido " + TEquipos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    End If
                End If

            End If
        Next
        'TActividades()
        For i = 0 To TActividades.Rows.Count - 1
            If IsDBNull(TActividades.Rows(i).Item("SERVICIO")) = False Then
                If LTrim(RTrim(TActividades.Rows(i).Item("SERVICIO"))) <> "" Then
                    If IsDBNull(TActividades.Rows(i).Item("IDOTSERVICIO")) = True Then
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TActividades.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length > 0 Then
                            Dim fila As DataRow
                            fila = filas(0)
                            TActividades.Rows(i).Item("IDOTSERVICIO") = fila("IDOTSERVICIO")
                            TActividades.Rows(i).Item("IDORDENTRABAJO") = fila("IDORDENTRABAJO")
                        Else
                            MsgBox("Actividades --> Se ha agregado un servicio no valido " + TActividades.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    Else
                        'verificar que el IDOTSERVICIO corresponda con el servicio
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TActividades.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length = 0 Then
                            MsgBox("Actividades --> Se ha agregado un servicio no valido " + TActividades.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        'TArticulos()
        For i = 0 To TArticulos.Rows.Count - 1
            If IsDBNull(TArticulos.Rows(i).Item("SERVICIO")) = False Then
                If LTrim(RTrim(TArticulos.Rows(i).Item("SERVICIO"))) <> "" Then
                    If IsDBNull(TArticulos.Rows(i).Item("IDOTSERVICIO")) = True Then
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TArticulos.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length > 0 Then
                            Dim fila As DataRow
                            fila = filas(0)
                            TArticulos.Rows(i).Item("IDOTSERVICIO") = fila("IDOTSERVICIO")
                            TArticulos.Rows(i).Item("IDORDENTRABAJO") = fila("IDORDENTRABAJO")
                        Else
                            MsgBox("Articulos -- > Se ha agregado un servicio no valido " + TArticulos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    Else
                        'verificar que el IDOTSERVICIO corresponda con el servicio
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TArticulos.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length = 0 Then
                            MsgBox("Articulos -- > Se ha agregado un servicio no valido " + TArticulos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        'Costos Directos
        For i = 0 To TCostosIndirectos.Rows.Count - 1
            If IsDBNull(TCostosIndirectos.Rows(i).Item("SERVICIO")) = False Then
                If LTrim(RTrim(TCostosIndirectos.Rows(i).Item("SERVICIO"))) <> "" Then
                    If IsDBNull(TCostosIndirectos.Rows(i).Item("IDOTSERVICIO")) = True Then
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TCostosIndirectos.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length > 0 Then
                            Dim fila As DataRow
                            fila = filas(0)
                            TCostosIndirectos.Rows(i).Item("IDOTSERVICIO") = fila("IDOTSERVICIO")
                            TCostosIndirectos.Rows(i).Item("IDORDENTRABAJO") = fila("IDORDENTRABAJO")
                        Else
                            MsgBox("Costo Directo -- > Se ha agregado un servicio no valido " + TCostosIndirectos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    Else
                        'verificar que el IDOTSERVICIO corresponda con el servicio
                        Dim filas() As DataRow
                        filas = TServiciosActuales.Select("SERVICIO='" + TCostosIndirectos.Rows(i).Item("SERVICIO") + "'")
                        If filas.Length = 0 Then
                            MsgBox("Articulos -- > Se ha agregado un servicio no valido " + TCostosIndirectos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                            validarservicios = False
                            Exit Function
                        End If
                    End If

                    'verificar que el servicio corresponda con la orden de manenimiento
                    If TCostosIndirectos.Rows(i).Item("IDORDENTRABAJOPLANEADA") <> TCostosIndirectos.Rows(i).Item("IDORDENTRABAJO") Then
                        MsgBox("Articulos -- > Se ha agregado un servicio no valido, el costo no corresponde con la OM " + TCostosIndirectos.Rows(i).Item("SERVICIO").ToString + " fila " + i.ToString, MsgBoxStyle.Information, "Servicio no valido")
                        validarservicios = False
                        Exit Function
                    End If

                End If


            End If
        Next

        validarservicios = True
    End Function

    Dim MarcadoCerrado As Boolean = False
    Private Sub Guardar_Registro_ReporteDiario()
        'Llamar al procedimiento para crear el tipo categoría
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarReporteDiario")
        Comando.CommandType = CommandType.StoredProcedure
        Select Case TipoAccion
            Case "I"
                Comando.Parameters.AddWithValue("@ACCION", 1)
            Case "E"
                Comando.Parameters.AddWithValue("@ACCION", 2)
        End Select
        'Dim IntegerNullo As Nullable(Of Byte)
        'Dim FechaNula As Nullable(Of Date)

        Comando.Parameters.AddWithValue("@IDREPORTEDIARIO", IdReporteDiario_Modificar)
        Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)

        If Me.Cb_Cuadrilla.SelectedIndex = -1 Then
            Comando.Parameters.AddWithValue("@IDCUADRILLA", 0)
        Else
            Comando.Parameters.AddWithValue("@IDCUADRILLA", Me.Cb_Cuadrilla.SelectedValue)
        End If
        Comando.Parameters.AddWithValue("@FECHAREPORTEDIARIO", Me.Dtp_Fecha.Value)
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        Comando.Parameters.AddWithValue("@CODIGOTIPODISCIPLINA", Me.Cb_Disciplina.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOTIEMPO", Me.Cb_Tiempo.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOPARO", Me.Cb_Paro.SelectedValue)
        If Me.Cb_Paro.SelectedValue = 0 Then

            Comando.Parameters.AddWithValue("@HORAINICIOPARO", DBNull.Value)
            Comando.Parameters.AddWithValue("@HORAFINPARO", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@HORAINICIOPARO", Me.DTP_IncioParo.Value)
            Comando.Parameters.AddWithValue("@HORAFINPARO", Me.DTP_FinParo.Value)
        End If
        Comando.Parameters.AddWithValue("@NOMBREFRENTETRABAJO", Me.Tx_NombreFrente.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONPERSONA", Me.Tx_ObservaciónPersonas.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONCOMPLEMENTO", Me.Tx_Observación_Complemento.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONEQUIPO", Me.Tx_ObservaciónEquipos.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONAVANCE", Me.Tx_ObservaciónAvanceObra.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONMATERIALES", Me.Tx_ObservaciónMateriales.Text)
        Comando.Parameters.AddWithValue("@OBSERVACIONCOSTOSINDIRECTOS", Me.Tx_ObservaciónCostosIndirectos.Text)
        Comando.Parameters.AddWithValue("@IDPERSONAJEFECUADRILLA", Me.Cu_JefeCuadrilla.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAADMINISTRADOR", Me.Cu_Administrador.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONASUPERINTENDENTE", Me.Cu_Superintendente.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONADIRECTOROBRA", Me.Cu_DirectorObra.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@REVISADO", DBNull.Value)
        If CerrarReporteFacturación_OficinaTécnica() = True Then
            If MsgBox("¿Desea marcar el reporte como cerrado?, no se permitira la modificación del mismo una vez cerrado.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Cerrar Reporte") = MsgBoxResult.Yes Then
                Comando.Parameters.AddWithValue("@CERRADO", "S")
                MarcadoCerrado = True
            Else
                Comando.Parameters.AddWithValue("@CERRADO", "N")
                MarcadoCerrado = False
            End If
        End If
        Comando.Parameters.AddWithValue("@APROBADOENVIO", DBNull.Value)
        Comando.Parameters.AddWithValue("@TablaREPORTEDIARIOPERSONA", TPersonas)
        Comando.Parameters.AddWithValue("@TablaREPORTEDIARIOEQUIPO", TEquipos)
        Comando.Parameters.AddWithValue("@TablaREPORTEDIARIOACTIVIDAD", TActividades)
        Comando.Parameters.AddWithValue("@TablaREPORTEDIARIOARTICULOS", TArticulos)
        Comando.Parameters.AddWithValue("@TablaREPORTEDIARIOCOSTOSINDIRECTOS", TCostosIndirectos)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        Dim msgParam1 As New SqlParameter("@IDRD", SqlDbType.Int, -1)
        Dim msgParam2 As New SqlParameter("@REPORTEDIARIONUEVO", SqlDbType.NVarChar, -1)

        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam1)

        msgParam2.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam2)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
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
                MsgBox("El registro ha sido exitoso", MsgBoxStyle.Information, "REPORTE DIARIO")
                guardado = True
                Lb_ReporteEditando.Visible = True
                Lb_ReporteEditando.Text = Comando.Parameters("@REPORTEDIARIONUEVO").Value
                IdReporteDiario_Modificar = Comando.Parameters("@IDRD").Value
                TipoAccion = "E"
            Case 2
                MsgBox("En este reporte hay personal que ha sido registrado en otro reporte el mismo día", MsgBoxStyle.Exclamation, "Personal ya reportado")
                Try
                    Dim Comando1 As New SqlClient.SqlCommand("dbo.RD_ValidarPersonal")
                    Comando1.CommandType = CommandType.StoredProcedure
                    Select Case TipoAccion
                        Case "I"
                            Comando1.Parameters.AddWithValue("@ACCION", 1)
                        Case "E"
                            Comando1.Parameters.AddWithValue("@ACCION", 2)
                    End Select
                    Comando1.Parameters.AddWithValue("@IDREPORTEDIARIO", IdReporteDiario_Modificar)
                    Comando1.Parameters.AddWithValue("@FECHAREPORTEDIARIO", Me.Dtp_Fecha.Value)
                    Comando1.Parameters.AddWithValue("@TablaREPORTEDIARIOPERSONA", TPersonas)
                    Dim datas As New DataSet
                    Dim da As New SqlDataAdapter
                    Comando1.Connection = conn
                    conn.Open()
                    da = New SqlDataAdapter(Comando1)
                    datas = New DataSet()
                    da.Fill(datas)
                    MarcarReportados(datas.Tables(0), "P")
                Catch ex As Exception
                Finally
                    conn.Close()
                End Try
                guardado = False
                Exit Sub
            Case 3
                MsgBox("En este reporte hay equipos que han sido registrados en otro reporte el mismo día", MsgBoxStyle.Exclamation, "Equipo ya reportado")
                Dim Comando2 As New SqlCommand("dbo.RD_ValidarEquipos", conn)
                Comando2.CommandType = CommandType.StoredProcedure
                Select Case TipoAccion
                    Case "I"
                        Comando2.Parameters.AddWithValue("@ACCION", 1)
                    Case "E"
                        Comando2.Parameters.AddWithValue("@ACCION", 2)
                End Select
                Comando2.Parameters.AddWithValue("@IDREPORTEDIARIO", IdReporteDiario_Modificar)
                Comando2.Parameters.AddWithValue("@FECHAREPORTEDIARIO", Me.Dtp_Fecha.Value)
                Comando2.Parameters.AddWithValue("@TablaREPORTEDIARIOEQUIPO", TEquipos)
                Dim dtEquipos As New DataTable
                Dim da2 As New SqlDataAdapter
                Try
                    conn.Open()
                    da2 = New SqlDataAdapter(Comando2)
                    da2.Fill(dtEquipos)
                    MarcarReportados(dtEquipos, "E")
                Catch ex As Exception
                Finally
                    conn.Close()
                End Try
                guardado = False
                Exit Sub
            Case 4 'Cuando alguno de los contratos se encuentras en periodos que el contrato estaba inactivo
                MsgBox("En este reporte hay contratos en fechas que no corresponden, verificar los códigos", MsgBoxStyle.Exclamation, "Contratos por fuera de las fechas del reporte")
                Try
                    Dim Comando1 As New SqlClient.SqlCommand("dbo.RD_ValidarPersonal")
                    Comando1.CommandType = CommandType.StoredProcedure
                    Comando1.Parameters.AddWithValue("@ACCION", 3)
                    Comando1.Parameters.AddWithValue("@IDREPORTEDIARIO", IdReporteDiario_Modificar)
                    Comando1.Parameters.AddWithValue("@FECHAREPORTEDIARIO", Me.Dtp_Fecha.Value)
                    Comando1.Parameters.AddWithValue("@TablaREPORTEDIARIOPERSONA", TPersonas)
                    Dim datas As New DataSet
                    Dim da As New SqlDataAdapter
                    Comando1.Connection = conn
                    conn.Open()
                    da = New SqlDataAdapter(Comando1)
                    datas = New DataSet()
                    da.Fill(datas)
                    conn.Close()
                    MarcarReportados(datas.Tables(0), "F")
                Catch ex As Exception
                End Try
                guardado = False
                Exit Sub
        End Select
    End Sub

    Private Sub MarcarReportados(ByVal tabla As DataTable, ByVal tipo As String)
        Select Case tipo
            Case "P"
                Try
                    Dim ListaIntegrantes As New ArrayList
                    For j = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                        ListaIntegrantes.Add(Dgv_ListaPersonas.Rows(j).Cells("DGVTBC_IDCONTRATO").Value)
                    Next
                    Me.Dgv_ListaPersonas.SuspendLayout()
                    Me.Enabled = False
                    Me.Cursor = Cursors.WaitCursor
                    Dim i As Integer
                    'Cuando el valor no es valido
                    Dim Estilo_Celda_Error As New DataGridViewCellStyle
                    Estilo_Celda_Error.BackColor = Color.Red
                    'Cuando no corresponde con la convenció
                    Dim Estilo_Celda_convención As New DataGridViewCellStyle
                    Estilo_Celda_convención.BackColor = Color.Khaki
                    Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
                    Estilo_Celda_ValorFuera.BackColor = Color.Indigo
                    'Cuando esta bien
                    Dim Estilo_Celda As New DataGridViewCellStyle
                    Estilo_Celda.BackColor = Color.White
                    For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                        With Dgv_ListaPersonas
                            .Rows(i).DefaultCellStyle = Estilo_Celda
                            .Rows(i).ErrorText = ""
                            Dim CODIGO As String
                            CODIGO = (.Rows(i).Cells("DGVTBC_CODIGOCONTRATO").Value).ToString
                            Dim filas() As DataRow
                            filas = tabla.Select("CODIGOCONTRATO=" + CODIGO)
                            If filas.Length > 0 Then
                                Dim fila As DataRow
                                fila = filas(0)
                                Dgv_ListaPersonas.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                Dgv_ListaPersonas.Rows(i).ErrorText = "Persona registrado en el reporte Nro " + fila("REPORTEDIARIO")
                            End If
                        End With
                    Next
                    Me.Enabled = True
                    Me.Cursor = Cursors.Default
                    Me.Dgv_ListaPersonas.ResumeLayout()
                    'Validar que el total no sea mayor a 12
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    Me.Enabled = True
                End Try
            Case "F"
                Try
                    Dim ListaIntegrantes As New ArrayList
                    For j = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                        ListaIntegrantes.Add(Dgv_ListaPersonas.Rows(j).Cells("DGVTBC_IDCONTRATO").Value)
                    Next

                    Me.Dgv_ListaPersonas.SuspendLayout()
                    Me.Enabled = False
                    Me.Cursor = Cursors.WaitCursor
                    Dim i As Integer
                    'Cuando el valor no es valido
                    Dim Estilo_Celda_Error As New DataGridViewCellStyle
                    Estilo_Celda_Error.BackColor = Color.Red
                    'Cuando no corresponde con la convenció
                    Dim Estilo_Celda_convención As New DataGridViewCellStyle
                    Estilo_Celda_convención.BackColor = Color.Khaki
                    Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
                    Estilo_Celda_ValorFuera.BackColor = Color.Indigo
                    'Cuando esta bien
                    Dim Estilo_Celda As New DataGridViewCellStyle
                    Estilo_Celda.BackColor = Color.White
                    For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                        With Dgv_ListaPersonas
                            .Rows(i).DefaultCellStyle = Estilo_Celda
                            .Rows(i).ErrorText = ""
                            Dim CODIGO As String
                            CODIGO = (.Rows(i).Cells("DGVTBC_CODIGOCONTRATO").Value).ToString
                            Dim filas() As DataRow
                            filas = tabla.Select("CODIGOCONTRATO=" + CODIGO)
                            If filas.Length > 0 Then
                                Dim fila As DataRow
                                fila = filas(0)
                                Dgv_ListaPersonas.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                Dgv_ListaPersonas.Rows(i).ErrorText = "Esta persona fue contratada el " + fila("FECHAI").ToString + " y tiene fecha de terminación el " +
                                        fila("FECHAF").ToString
                            End If
                        End With
                    Next
                    Me.Enabled = True
                    Me.Cursor = Cursors.Default
                    Me.Dgv_ListaPersonas.ResumeLayout()
                    'Validar que el total no sea mayor a 12
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    Me.Enabled = True
                End Try
            Case "E"
                Try
                    Dim ListaEquipos As New ArrayList
                    For j = 0 To Dgv_Equipos.RowCount - 1
                        ListaEquipos.Add(Dgv_Equipos.Rows(j).Cells("DGVTBC_IDEQUIPO").Value)
                    Next

                    Dgv_Equipos.SuspendLayout()
                    Enabled = False
                    Cursor = Cursors.WaitCursor
                    Dim i As Integer
                    'Cuando el valor no es válido
                    Dim Estilo_Celda_Error As New DataGridViewCellStyle
                    Estilo_Celda_Error.BackColor = Color.Red
                    'Cuando no corresponde con la convención
                    Dim Estilo_Celda_convención As New DataGridViewCellStyle
                    Estilo_Celda_convención.BackColor = Color.Khaki
                    Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
                    Estilo_Celda_ValorFuera.BackColor = Color.Indigo
                    'Cuando está bien
                    Dim Estilo_Celda As New DataGridViewCellStyle
                    Estilo_Celda.BackColor = Color.White
                    For i = 0 To Dgv_Equipos.RowCount - 1
                        With Dgv_Equipos
                            .Rows(i).DefaultCellStyle = Estilo_Celda
                            .Rows(i).ErrorText = ""
                            Dim CODIGO As String
                            CODIGO = (.Rows(i).Cells("DGVTBC_IDEQUIPO").Value).ToString
                            Dim filas() As DataRow
                            filas = tabla.Select("IDEQUIPO=" & CODIGO)
                            If filas.Length > 0 Then
                                Dim fila As DataRow
                                fila = filas(0)
                                Dgv_Equipos.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                Dgv_Equipos.Rows(i).ErrorText = "Equipo registrado en el reporte Nro " & fila("REPORTEDIARIO")
                            End If
                        End With
                    Next
                    Enabled = True
                    Cursor = Cursors.Default
                    Dgv_Equipos.ResumeLayout()
                Catch ex As Exception
                    Cursor = Cursors.Default
                    Enabled = True
                End Try
        End Select
    End Sub

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If TipoAccion = "N" Then
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            Me.TIntegrantes.AcceptChanges()
            If Validar_ValoresListaIntegrantes() Then

                Dim Comando As New SqlClient.SqlCommand("dbo.GestionarReporteDiarioNovedad")
                Comando.CommandType = CommandType.StoredProcedure
                Comando.Parameters.AddWithValue("@ACCION", 1)
                Comando.Parameters.AddWithValue("@IDREPORTEDIARIO", IdReporteDiario_Modificar)
                Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                Comando.Parameters.AddWithValue("@TablaREPORTEDIARIOPERSONA", TPersonas)
                Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)

                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                Try
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
                        MsgBox("El registro ha sido exitoso", MsgBoxStyle.Information, "REPORTE DIARIO")
                        guardado = True
                End Select
                Me.Close()
            Else
                MsgBox("Existe una inconsistencia en el reporte, por favor revisar", MsgBoxStyle.Critical, "Inconsistencia Novedad")
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Else
            ELiminarFilaVacia("P")
            ELiminarFilaVacia("E")
            ELiminarFilaVacia("A")
            ELiminarFilaVacia("M")
            ELiminarFilaVacia("C")
            Me.TActividades.AcceptChanges()
            Me.TArticulos.AcceptChanges()
            Me.TEquipos.AcceptChanges()
            Me.TIntegrantes.AcceptChanges()
            Me.TCostosIndirectos.AcceptChanges()

            If Guardar_Datos() = True Then
                If MarcadoCerrado = False Then
                    If MsgBox("¿Desea salir del formulario?", MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
                        If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                            Cu_padre.Cargar_Tabla()
                        End If
                        Me.Close()
                    End If
                Else
                    If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                        Cu_padre.Cargar_Tabla()
                    End If
                    Me.Close()
                End If
            End If
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Function CerrarReporteFacturación_OficinaTécnica() As Boolean
        'Validar tabla de personal
        'Dim filas() As DataRow
        'filas = TPersonas.Select("HORASNORMALES IS NULL")
        'If filas.Length > 0 Then
        '    CerrarReporteFacturación_OficinaTécnica = False
        '    Exit Function
        'End If
        CerrarReporteFacturación_OficinaTécnica = True
    End Function

    Private Function ValidarReporteDiario() As Boolean
        If Me.TPersonas.Rows.Count = 0 Then
            MsgBox("El reporte diario debe tener al menos un integrante")
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cb_Disciplina.Text = "" Then
            MsgBox("Debe seleccionar la disciplina", MsgBoxStyle.Information, "SELECCIONAR DISCIPLINA")
            Me.Cb_Disciplina.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cb_Tiempo.Text = "" Then
            MsgBox("Debe seleccionar la tiempo", MsgBoxStyle.Information, "SELECCIONAR TIEMPO")
            Me.Cb_Tiempo.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cb_Paro.Text = "" Then
            MsgBox("Debe seleccionar si se presento paro", MsgBoxStyle.Information, "SELECCIONAR PARO")
            Me.Cb_Paro.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cu_CentroCosto1.IdCentroCosto = 1 Then
            MsgBox("Debe seleccionar si area de trabajo", MsgBoxStyle.Information, "SELECCIONAR AREA DE TRABAJO")
            Me.Cu_CentroCosto1.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cb_Paro.SelectedValue <> 0 Then
            If DTP_IncioParo.Value >= DTP_FinParo.Value Then
                MsgBox("La Hora de paro inicial debe ser inferior a la fecha de para actual", MsgBoxStyle.Critical, "HORA DE PARO")
                ValidarReporteDiario = False
                Exit Function
            End If
        End If
        If Me.Cu_JefeCuadrilla.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione la persona jefe de cuadrilla", MsgBoxStyle.Critical, "JEFE DE CUADRILLA")
            Me.Cu_JefeCuadrilla.Cb_Persona.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cu_Administrador.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione el administrador", MsgBoxStyle.Critical, "ADMINISTRADOR")
            Me.Cu_Administrador.Cb_Persona.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cu_Superintendente.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione el superintendente", MsgBoxStyle.Critical, "SUPERINTENDENTE")
            Me.Cu_Superintendente.Cb_Persona.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If
        If Me.Cu_DirectorObra.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione la persona que gerencia o director de obra", MsgBoxStyle.Critical, "GERENCIA O DIRECTOR DE OBRA")
            Me.Cu_DirectorObra.Cb_Persona.Focus()
            ValidarReporteDiario = False
            Exit Function
        End If

        ValidarReporteDiario = True
    End Function
#End Region

#Region "General"
    Private CerrarFormulario As Boolean = True
    Private Sub ELiminarFilaVacia(ByVal tipo As String)
        Try
            Select Case tipo
                Case "P"
                    For i = 0 To Dgv_ListaPersonas.Rows.Count - 2
                        If IsDBNull(Me.Dgv_ListaPersonas.Rows(i).Cells(DGVTBC_NOMBREPERSONA.Name).Value) Then
                            Me.Dgv_ListaPersonas.Rows.RemoveAt(i)
                        End If
                    Next
                Case "E"
                    For i = 0 To Dgv_Equipos.Rows.Count - 2
                        If IsDBNull(Me.Dgv_Equipos.Rows(i).Cells(DGVTBC_DESCRIPCIONEQUIPO.Name).Value) Then
                            Me.Dgv_Equipos.Rows.RemoveAt(i)
                        End If
                    Next
                Case "A"
                    For i = 0 To Dgv_Actividades.Rows.Count - 2
                        If IsDBNull(Me.Dgv_Actividades.Rows(i).Cells(DGVTBC_DESCRIPCIONACTIVIDAD.Name).Value) Then
                            Me.Dgv_Actividades.Rows.RemoveAt(i)
                        End If
                    Next
                Case "M"
                    For i = 0 To Dgv_Articulos.Rows.Count - 2
                        If IsDBNull(Me.Dgv_Articulos.Rows(i).Cells(DGVTBC_DESCRIPCIONARTICULO.Name).Value) Then
                            Me.Dgv_Articulos.Rows.RemoveAt(i)
                        End If
                    Next
                Case "C"
                    For i = 0 To Dgv_ListaCostosIndirectos.Rows.Count - 2
                        If IsDBNull(Me.Dgv_ListaCostosIndirectos.Rows(i).Cells(DGVTBC_NOMBRECOSTOINDIRECTO.Name).Value) Then
                            Me.Dgv_ListaCostosIndirectos.Rows.RemoveAt(i)
                        End If
                        If IsNothing(Me.Dgv_ListaCostosIndirectos.Rows(i).Cells(DGVTBC_NOMBRECOSTOINDIRECTO.Name).Value) Then
                            Me.Dgv_ListaCostosIndirectos.Rows.RemoveAt(i)
                        End If
                    Next
            End Select
        Catch
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        If CerrarFormulario = True Then
            If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                Cu_padre.Cargar_Tabla()
            End If
            Me.Close()
        Else
            MsgBox("Hay un valor en los integrantes que no es valido, revise el valor antes de cerrar el formulario")
        End If
    End Sub

#End Region

#Region "Pestaña Persona"

    Private Sub Dgv_ListaPersonas_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_ListaPersonas.KeyDown
        CargandoFormulario = False
        Dim selectedColumna As Integer = Dgv_ListaPersonas.CurrentCell.ColumnIndex



        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3
                Select Case selectedColumna 'Buscar persona
                    Case 4
                        Dim FrBuscarContrato As New FormulariosClasesBase.Fr_BuscarPersona
                        FrBuscarContrato._Tipo = "PCB"
                        FrBuscarContrato.Cargar_Tabla("PCB")

                        FrBuscarContrato.ShowDialog()
                        Dim CODIGOCONTRATO As Integer
                        CODIGOCONTRATO = FrBuscarContrato.CodigoContrato

                        If ValidarItemsRDPersona(CODIGOCONTRATO, -1) = True Then
                            Dim FilasContratos As DataRow()
                            Dim contratos As New DataTable()
                            Dim Cadena_Consulta As String = "SELECT * FROM dbo.DetalleContrato(" & CODIGOCONTRATO.ToString & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                            Dim Consulta As New SqlCommand(Cadena_Consulta)
                            Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                            Consulta.Connection = Conexión
                            Dim Adaptador As New SqlDataAdapter(Consulta)
                            Consulta.Connection.Open()
                            Adaptador.FillSchema(contratos, SchemaType.Source)
                            Adaptador.Fill(contratos)
                            Consulta.Connection.Close()
                            FilasContratos = contratos.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString)
                            If FilasContratos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                                Dim FilaContrato As DataRow
                                FilaContrato = FilasContratos(0)
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TPersonas.NewRow
                                NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                                NuevaFilaItem("IDPERSONA") = FilaContrato("IDPERSONA")
                                NuevaFilaItem("IDCONTRATO") = FilaContrato("IDCONTRATO")
                                NuevaFilaItem("CODIGOCONTRATO") = FilaContrato("CODIGOCONTRATO")
                                NuevaFilaItem("NOMBREPERSONA") = FilaContrato("NOMBREPERSONA")
                                NuevaFilaItem("CODIGOTIPOSALARIO") = FilaContrato("CODIGOTIPOSALARIO")
                                NuevaFilaItem("CODIGOTIPOCATEGORIAPERSONAL") = FilaContrato("CODIGOTIPOCATEGORIAPERSONAL")
                                NuevaFilaItem("CODIGOTIPOCARGO") = FilaContrato("CODIGOTIPOCARGO")
                                NuevaFilaItem("IDTIPORECURSO") = FilaContrato("IDTIPORECURSO")
                                TPersonas.Rows.Add(NuevaFilaItem) '
                            Else
                                'No existe un artículo con este código
                                MensajeError = "No se encontró un empleado con ese código"
                                MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                            End If
                        Else
                            MensajeError = "El empleado que desea ingresar, ya se encuentra incluido en el reporte de tiempo"
                            MsgBox(MensajeError, MsgBoxStyle.Critical, "Empleado Repetido")
                        End If
                        ELiminarFilaVacia("P")
                        CalcularTotalPersona()
                    Case 20 'buscar servicio
                        Dim IndiceFilaseleccionada As Integer = Dgv_ListaPersonas.CurrentRow.Index
                        If IsDBNull(Dgv_ListaPersonas.Rows(IndiceFilaseleccionada).Cells(2).Value) = False Then
                            If IsNothing(Dgv_ListaPersonas.Rows(IndiceFilaseleccionada).Cells(2).Value) = False Then
                                Dim FrBuscarServicioOTSAP As New Fr_BuscarServicioOTSAP
                                FrBuscarServicioOTSAP.tablaunidades = tablaunidades
                                FrBuscarServicioOTSAP._Tipo = "A"
                                FrBuscarServicioOTSAP.TipoBusqueda = "P"
                                FrBuscarServicioOTSAP.Cargar_Tabla("A")
                                FrBuscarServicioOTSAP.ShowDialog()
                                For j = 0 To FrBuscarServicioOTSAP.TablaServicios.Rows.Count - 1
                                    Dim FilaServicioBusqueda As DataRow
                                    FilaServicioBusqueda = FrBuscarServicioOTSAP.TablaServicios.Rows(j)
                                    Dgv_ListaPersonas.Rows(IndiceFilaseleccionada).Cells(18).Value = FilaServicioBusqueda("IDOTSERVICIO")
                                    Dgv_ListaPersonas.Rows(IndiceFilaseleccionada).Cells(19).Value = FilaServicioBusqueda("IDORDENTRABAJO")
                                    Dgv_ListaPersonas.Rows(IndiceFilaseleccionada).Cells(20).Value = FilaServicioBusqueda("SERVICIO")
                                    Try
                                        If FilaServicioBusqueda("IDCLASEATENCION") <> -1 Then
                                            Dgv_ListaPersonas.Rows(IndiceFilaseleccionada).Cells(31).Value = FilaServicioBusqueda("IDCLASEATENCION")
                                        End If
                                    Catch ex As Exception
                                    End Try
                                Next
                            Else
                                MsgBox("Debe seleccionar primero la persona contratada")
                            End If
                        Else
                            MsgBox("Debe seleccionar primero la persona contratada")
                        End If

                End Select

            Case Windows.Forms.Keys.Delete
                If TipoAccion <> "N" Then
                    Try
                        If MsgBox("¿Seguro que desea elimina el registro?", MsgBoxStyle.YesNo, "Borrar Registro") = MsgBoxResult.Yes Then
                            Me.Dgv_ListaPersonas.Rows.RemoveAt(Me.Dgv_ListaPersonas.CurrentCell.RowIndex)
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        TPersonas.AcceptChanges()
                    Catch ex As Exception
                    End Try

                    For x As Integer = 0 To TPersonas.Rows.Count - 1
                        If Not IsDBNull(TPersonas.Rows(x).Item(0)) Then 'LISTAITEMREQUISICION
                            TPersonas.Rows(x).Item(0) = x + 1 'LISTAITEMREQUISICION
                        End If
                    Next
                End If

        End Select


    End Sub

    Private Sub Dgv_Equipos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Equipos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Equipos
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dText_KeyPressDgv_Equipos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Equipos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 5, 6, 13
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
            Case 21, 22, 23, 24, 25
                e.KeyChar = Char.ToUpper(e.KeyChar)
                If e.KeyChar = "I" Or e.KeyChar = Convert.ToChar(8) Or e.KeyChar = "T" Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 26, 27, 28, 29, 30
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub Dgv_ListaPersonas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_ListaPersonas.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_ListaPersonas
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_ListaPersonas(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_ListaPersonas.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 14
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "O", "D", "A", "I", "I", "C", "S", "P", "D", "N", "V", "U", ",", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select

            Case 15, 16, 17
                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 12
                e.KeyChar = Char.ToUpper(e.KeyChar)
                If e.KeyChar = "S" Or e.KeyChar = "N" Or e.KeyChar = Convert.ToChar(8) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Case 4
                If TipoAccion = "N" Then
                    e.Handled = True
                End If
        End Select
    End Sub


    Private Sub Dgv_CostosPersonal_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dgv_CostosPersonal.CellFormatting
        If e.ColumnIndex >= 0 And e.ColumnIndex < 8 Then
            e.CellStyle.BackColor = Color.Beige
        Else
            If e.ColumnIndex > 20 And e.ColumnIndex < 26 Then
                e.CellStyle.BackColor = Color.AliceBlue
            Else
                If e.ColumnIndex > 25 Then
                    e.CellStyle.BackColor = Color.LemonChiffon
                End If
            End If
        End If
    End Sub

    Private Sub Dgv_CostosPersonal_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_CostosPersonal.KeyDown
        CargandoFormulario = False
        Dim selectedColumna As Integer = Dgv_CostosPersonal.CurrentCell.ColumnIndex

        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3
            Case Windows.Forms.Keys.Delete
                Try
                    If MsgBox("¿Seguro que desea elimina el registro?", MsgBoxStyle.YesNo, "Borrar Registro") = MsgBoxResult.Yes Then
                        Me.Dgv_CostosPersonal.Rows.RemoveAt(Me.Dgv_CostosPersonal.CurrentCell.RowIndex)
                    End If

                Catch ex As Exception
                End Try

                Try
                    TPersonas.AcceptChanges()
                Catch ex As Exception
                End Try

                For x As Integer = 0 To TPersonas.Rows.Count - 1
                    If Not IsDBNull(TPersonas.Rows(x).Item(0)) Then 'LISTAITEMREQUISICION
                        TPersonas.Rows(x).Item(0) = x + 1 'LISTAITEMREQUISICION
                    End If
                Next
        End Select

    End Sub

    Private Sub Dgv_ListaPersonas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_ListaPersonas.CellEndEdit
        Try
            If IsDBNull(Me.Dgv_ListaPersonas.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_ListaPersonas.Item(e.ColumnIndex, e.RowIndex).Value = DBNull.Value
            End If

            If IsDBNull(Me.Dgv_ListaPersonas.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value) = True Then
                'If e.RowIndex > 0 Then
                '    Me.Dgv_ListaPersonas.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                '    Me.Dgv_ListaPersonas.Rows(e.RowIndex).ErrorText = ""
                'Else
                Try
                    If Trim(Me.Dgv_ListaPersonas.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value) = "" Then
                        Me.Dgv_ListaPersonas.Rows.RemoveAt(e.RowIndex)
                    End If
                Catch
                End Try
                'End If
                Exit Sub
            End If

            If Trim(Me.Dgv_ListaPersonas.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value) = "" Then
                'If e.RowIndex > 0 Then
                '    Me.Dgv_ListaPersonas.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                '    Me.Dgv_ListaPersonas.Rows(e.RowIndex).ErrorText = ""
                'Else
                Try
                    If Trim(Me.Dgv_ListaPersonas.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value) = "" Then
                        Me.Dgv_ListaPersonas.Rows.RemoveAt(e.RowIndex)
                    End If
                Catch
                End Try
                'End If
                Exit Sub
            End If

        Catch ex As Exception
        End Try

        Dim CODIGOCONTRATO As Integer = -1
        Dim ORDEN As Integer = -1
        Dim N As Decimal

        If Not IsDBNull(Me.Dgv_ListaPersonas.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value) Then
            CODIGOCONTRATO = Me.Dgv_ListaPersonas.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value
        End If

        If Not IsDBNull(Me.Dgv_ListaPersonas.Item(DGVTBC_ORDEN.Name, e.RowIndex).Value) Then
            ORDEN = Me.Dgv_ListaPersonas.Item(DGVTBC_ORDEN.Name, e.RowIndex).Value
        End If

        If Not IsDBNull(Me.Dgv_ListaPersonas.Item(DGVTBC_HORASNORMALES.Name, e.RowIndex).Value) Then
            Try
                N = Me.Dgv_ListaPersonas.Item(DGVTBC_HORASNORMALES.Name, e.RowIndex).Value
            Catch ex As Exception
            End Try

        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_ListaPersonas.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_ListaPersonas.Rows(e.RowIndex).ErrorText = ""

        'Validar Artículo
        Select Case e.ColumnIndex
            Case Dgv_ListaPersonas.Columns(DGVTBC_CODIGOCONTRATO.Name).Index '1

                If ValidarItemsRDPersona(CODIGOCONTRATO, ORDEN) = True Then
                    Dim FilasContratos As DataRow()
                    Dim contratos As New DataTable()
                    Dim Cadena_Consulta As String = "SELECT * FROM dbo.DetalleContrato(" & CODIGOCONTRATO.ToString & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")" 'DatosArticuloxBodega
                    Dim Consulta As New SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Adaptador.FillSchema(contratos, SchemaType.Source)
                    Adaptador.Fill(contratos)
                    Consulta.Connection.Close()
                    FilasContratos = contratos.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString)
                    If FilasContratos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                        Dim FilaContrato As DataRow
                        FilaContrato = FilasContratos(0)
                        Dim NuevaFilaItem As DataRow
                        NuevaFilaItem = TPersonas.NewRow
                        If ORDEN = -1 Then
                            NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                        Else
                            NuevaFilaItem("ORDEN") = ORDEN
                        End If

                        NuevaFilaItem("IDPERSONA") = FilaContrato("IDPERSONA")
                        NuevaFilaItem("IDCONTRATO") = FilaContrato("IDCONTRATO")
                        NuevaFilaItem("CODIGOCONTRATO") = FilaContrato("CODIGOCONTRATO")
                        NuevaFilaItem("NOMBREPERSONA") = FilaContrato("NOMBREPERSONA")
                        NuevaFilaItem("CODIGOTIPOSALARIO") = FilaContrato("CODIGOTIPOSALARIO")
                        NuevaFilaItem("CODIGOTIPOCATEGORIAPERSONAL") = FilaContrato("CODIGOTIPOCATEGORIAPERSONAL")
                        NuevaFilaItem("CODIGOTIPOCARGO") = FilaContrato("CODIGOTIPOCARGO")
                        NuevaFilaItem("IDTIPORECURSO") = FilaContrato("IDTIPORECURSO")
                        If TPersonas.Rows.Count = Me.Dgv_ListaPersonas.CurrentCell.RowIndex Then '
                            Try
                                Me.Dgv_ListaPersonas.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                            TPersonas.Rows.Add(NuevaFilaItem) '
                        Else
                            TPersonas.Rows(e.RowIndex).Item("ORDEN") = NuevaFilaItem("ORDEN") '
                            TPersonas.Rows(e.RowIndex).Item("IDPERSONA") = NuevaFilaItem("IDPERSONA") '
                            TPersonas.Rows(e.RowIndex).Item("IDCONTRATO") = NuevaFilaItem("IDCONTRATO") '
                            TPersonas.Rows(e.RowIndex).Item("CODIGOCONTRATO") = NuevaFilaItem("CODIGOCONTRATO") '
                            TPersonas.Rows(e.RowIndex).Item("NOMBREPERSONA") = NuevaFilaItem("NOMBREPERSONA") '
                            TPersonas.Rows(e.RowIndex).Item("CODIGOTIPOSALARIO") = NuevaFilaItem("CODIGOTIPOSALARIO") '
                            TPersonas.Rows(e.RowIndex).Item("CODIGOTIPOCATEGORIAPERSONAL") = NuevaFilaItem("CODIGOTIPOCATEGORIAPERSONAL") '
                            TPersonas.Rows(e.RowIndex).Item("CODIGOTIPOCARGO") = NuevaFilaItem("CODIGOTIPOCARGO") '
                            TPersonas.Rows(e.RowIndex).Item("IDTIPORECURSO") = NuevaFilaItem("IDTIPORECURSO") '
                        End If
                    Else
                        'No existe un artículo con este código
                        MensajeError = "No se encontró un contrato con ese código"
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Contrato no Encontrado")
                        Try
                            Me.Dgv_ListaPersonas.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                    End If
                Else
                    MensajeError = "El empleado que desea ingresar, ya se encuentra incluido en el reporte diario"
                    MsgBox(MensajeError, MsgBoxStyle.Critical, "Empleado Repetido")

                    'falta validar que si esta editando uno no borre el actual
                    Try
                        Me.Dgv_ListaPersonas.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try

                End If
            Case Dgv_ListaPersonas.Columns(DGVTBC_HORASNORMALES.Name).Index

                'Case Dgv_ListaPersonas.Columns(DGVTBC_HORAINICIALTURNO1.Name).Index '1
                '    Dim HIT1 As String
                '    Dim posicion As Integer
                '    Dim posicion1 As Integer
                '    If Dgv_ListaPersonas.Rows.Count - 1 > 0 Then
                '        For i As Integer = 0 To Dgv_ListaPersonas.Rows.Count
                '            HIT1 = Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value
                '            posicion = InStr(Mid(HIT1, 4, 2), "00")
                '            posicion1 = InStr(Mid(HIT1, 4, 2), "30")

                '            If posicion = 1 Or posicion1 = 1 Then
                '            Else
                '                MensajeError = "prueba HI1"
                '                MsgBox(MensajeError, MsgBoxStyle.Critical, "Empleado Repetido")
                '                Dgv_ListaPersonas.CurrentCell.Value = String.Empty
                '            End If
                '        Next
                '    End If
                'Case Dgv_ListaPersonas.Columns(DGVTBC_HORAFINALTURNO1.Name).Index '1
                '    Dim HFT1 As String
                '    Dim i As Integer
                '    Dim posicion As Integer
                '    Dim posicion1 As Integer

                '    HFT1 = Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value
                '    posicion = InStr(Mid(HFT1, 4, 2), "00")
                '    posicion1 = InStr(Mid(HFT1, 4, 2), "30")

                '    If posicion = 1 Or posicion1 = 1 Then
                '    Else
                '        MensajeError = "prueba HF1"
                '        MsgBox(MensajeError, MsgBoxStyle.Critical, "Empleado Repetido")
                '        Dgv_ListaPersonas.CurrentCell.Value = String.Empty
                '    End If

                'Case Dgv_ListaPersonas.Columns(DGVTBC_HORAINICIALTURNO2.Name).Index '1
                '    Dim HIT2 As String
                '    Dim i As Integer
                '    Dim posicion As Integer
                '    Dim posicion1 As Integer

                '    HIT2 = Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value
                '    posicion = InStr(Mid(HIT2, 4, 2), "00")
                '    posicion1 = InStr(Mid(HIT2, 4, 2), "30")

                '    If posicion = 1 Or posicion1 = 1 Then
                '    Else
                '        MensajeError = "prueba HI2"
                '        MsgBox(MensajeError, MsgBoxStyle.Critical, "Empleado Repetido")
                '        Dgv_ListaPersonas.CurrentCell.Value = String.Empty
                '    End If

                'Case Dgv_ListaPersonas.Columns(DGVTBC_HORAFINALTURNO2.Name).Index '1
                '    Dim HFT2 As String
                '    Dim i As Integer
                '    Dim posicion As Integer
                '    Dim posicion1 As Integer

                '    HFT2 = Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value
                '    posicion = InStr(Mid(HFT2, 4, 2), "00")
                '    posicion1 = InStr(Mid(HFT2, 4, 2), "30")

                '    If posicion = 1 Or posicion1 = 1 Then
                '    Else
                '        MensajeError = "prueba HF2"
                '        MsgBox(MensajeError, MsgBoxStyle.Critical, "Empleado Repetido")
                '        Dgv_ListaPersonas.CurrentCell.Value = String.Empty
                '    End If
        End Select
    End Sub

    Private Function ValidarItemsRDPersona(ByVal CODIGOCONTRATO As Integer, ByVal Orden As Integer) As Boolean
        Dim filas As DataRow()
        If Orden = -1 Then
            filas = TPersonas.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString + " AND ORDEN<>0") 'LISTAITEMREQUISICION
        Else
            filas = TPersonas.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString + " AND ORDEN<>" + Orden.ToString) 'LISTAITEMREQUISICION
        End If
        If filas.Length > 0 Then
            ValidarItemsRDPersona = False
            Exit Function
        End If
        ValidarItemsRDPersona = True
    End Function

    Private Sub CalcularTotalCargar()
        For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
            Try
                Dim N As String
                Dim ED As String
                Dim EN As String
                Dim RN As String
                With Dgv_ListaPersonas

                    N = (.Rows(i).Cells("DGVTBC_HORASNORMALES").Value).ToString
                    ED = (.Rows(i).Cells("DGVTBC_HORASEXTRASDIURNAS").Value).ToString
                    EN = (.Rows(i).Cells("DGVTBC_HORASEXTRASNOCTURNAS").Value).ToString
                    RN = (.Rows(i).Cells("DGVTBC_HORASRECARGONOCTURNO").Value).ToString
                    If ValidarConvenciones(N) = True Then
                        .Rows(i).Cells("DGVTBC_TOTAL").Value = N
                    Else
                        'Sumar
                        Dim Estilo_Celda As New DataGridViewCellStyle
                        Estilo_Celda.BackColor = Color.White
                        .Rows(i).DefaultCellStyle = Estilo_Celda
                        .Rows(i).ErrorText = ""
                        ValidarValorIngresado(ED, "ED", i)
                        ValidarValorIngresado(EN, "EN", i)
                        ValidarValorIngresado(RN, "RN", i)
                        Dim total As Decimal = 0
                        If N = True Then
                            total = total + N
                        End If
                        If IsNumeric(ED) = True Then
                            total = total + CInt(ED)
                        End If
                        If IsNumeric(EN) = True Then
                            total = total + CInt(EN)
                        End If
                        .Rows(i).Cells("DGVTBC_TOTAL").Value = total
                    End If


                End With
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Sub CalcularTotalPersona()
        Try
            Dim i As Integer = Me.Dgv_ListaPersonas.CurrentRow.Index
            Dim N As String
            Dim ED As String
            Dim EN As String
            Dim RN As String
            With Dgv_ListaPersonas
                N = (.Rows(i).Cells("DGVTBC_HORASNORMALES").Value).ToString
                ED = (.Rows(i).Cells("DGVTBC_HORASEXTRASDIURNAS").Value).ToString
                EN = (.Rows(i).Cells("DGVTBC_HORASEXTRASNOCTURNAS").Value).ToString
                RN = (.Rows(i).Cells("DGVTBC_HORASRECARGONOCTURNO").Value).ToString
                If ValidarConvenciones(N) = True Then
                    .Rows(i).Cells("DGVTBC_TOTAL").Value = N
                    Exit Sub
                End If
                'Sumar
                Dim Estilo_Celda As New DataGridViewCellStyle
                Estilo_Celda.BackColor = Color.White
                .Rows(i).DefaultCellStyle = Estilo_Celda
                .Rows(i).ErrorText = ""
                ValidarValorIngresado(ED, "ED", i)
                ValidarValorIngresado(EN, "EN", i)
                ValidarValorIngresado(RN, "RN", i)
                Dim total As Decimal = 0
                If N = True Then
                    total = total + N
                End If
                If IsNumeric(ED) = True Then
                    total = total + CInt(ED)
                End If
                If IsNumeric(EN) = True Then
                    total = total + CInt(EN)
                End If
                .Rows(i).Cells("DGVTBC_TOTAL").Value = total
            End With
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
        CargandoFormulario = True
    End Sub

    Private Sub CopiarEnTodasLasCeldasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CopiarTodas.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
            Case Me.Tp_CostosPersonal.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
            Case Me.Tp_Equipos.Name
                Nombre_Columna = Me.Dgv_Equipos.Columns(Me.Dgv_Equipos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Equipos.CurrentCell.ColumnIndex
            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Articulos.CurrentCell.ColumnIndex
            Case Me.Tp_Actividades.Name
                Nombre_Columna = Me.Dgv_Actividades.Columns(Me.Dgv_Actividades.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Actividades.CurrentCell.ColumnIndex
        End Select

        Dim valorcopiarid As Integer = -1
        Dim Idservicio As Integer = -1
        Dim Valor_Copiar As String = ""
        Dim IdclaseAtención As Integer = -1
        Dim Indice_Columna_IdClaseAtencion As Integer = 31
        Try
            Select Case Tc_Recursos.SelectedTab.Name
                Case Me.Tp_Integrantes.Name
                    Select Case TipoPegado
                        Case "SP"
                            Dim IndiceFilaseleccionada As Integer = Dgv_ListaPersonas.CurrentRow.Index
                            Valor_Copiar = Me.Dgv_ListaPersonas.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Idservicio = Me.Dgv_ListaPersonas.Item(Indice_Columna - 1, IndiceFilaseleccionada).Value
                            valorcopiarid = Me.Dgv_ListaPersonas.Item(Indice_Columna - 2, IndiceFilaseleccionada).Value
                            If IsDBNull(Me.Dgv_ListaPersonas.Item(Indice_Columna_IdClaseAtencion, IndiceFilaseleccionada).Value) = False Then
                                IdclaseAtención = Me.Dgv_ListaPersonas.Item(Indice_Columna_IdClaseAtencion, IndiceFilaseleccionada).Value
                            End If

                        Case "CA"
                            Dim IndiceFilaseleccionada As Integer = Dgv_ListaPersonas.CurrentRow.Index
                            valorcopiarid = Me.Dgv_ListaPersonas.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Valor_Copiar = "CA"
                        Case "HT"
                            Dim IndiceFilaseleccionada As Integer = Dgv_ListaPersonas.CurrentRow.Index
                            valorcopiarid = Me.Dgv_ListaPersonas.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Valor_Copiar = "HT"
                    End Select
                Case Me.Tp_CostosPersonal.Name
                    Dim IndiceFilaseleccionada As Integer = Dgv_CostosPersonal.CurrentRow.Index
                    Select Case TipoPegado
                        Case "TR"
                            valorcopiarid = Me.Dgv_CostosPersonal.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Valor_Copiar = "TR"
                    End Select
                Case Me.Tp_Equipos.Name
                    Select Case TipoPegado
                        Case "SE"
                            Dim IndiceFilaseleccionada As Integer = Dgv_Equipos.CurrentRow.Index
                            Valor_Copiar = Me.Dgv_Equipos.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Idservicio = Me.Dgv_Equipos.Item(Indice_Columna - 1, IndiceFilaseleccionada).Value
                            valorcopiarid = Me.Dgv_Equipos.Item(Indice_Columna - 2, IndiceFilaseleccionada).Value
                    End Select
                Case Me.Tp_Materiales.Name
                    Select Case TipoPegado
                        Case "SA"
                            Dim IndiceFilaseleccionada As Integer = Dgv_Articulos.CurrentRow.Index
                            Valor_Copiar = Me.Dgv_Articulos.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Idservicio = Me.Dgv_Articulos.Item(Indice_Columna - 1, IndiceFilaseleccionada).Value
                            valorcopiarid = Me.Dgv_Articulos.Item(Indice_Columna - 2, IndiceFilaseleccionada).Value
                    End Select
                Case Me.Tp_CostosIndirectos.Name
                    Select Case TipoPegado
                        Case "SC"
                            Dim IndiceFilaseleccionada As Integer = Dgv_ListaCostosIndirectos.CurrentRow.Index
                            Valor_Copiar = Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Idservicio = Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna - 1, IndiceFilaseleccionada).Value
                            valorcopiarid = Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna - 2, IndiceFilaseleccionada).Value
                    End Select
                Case Me.Tp_Actividades.Name
                    Select Case TipoPegado
                        Case "CAA"
                            Dim IndiceFilaseleccionada As Integer = Dgv_Actividades.CurrentRow.Index
                            valorcopiarid = Me.Dgv_Actividades.Item(Indice_Columna, IndiceFilaseleccionada).Value
                            Valor_Copiar = "CA"
                    End Select
            End Select
        Catch ex As Exception
            Exit Sub
        End Try

        If TipoPegado = "" Then
            Valor_Copiar = InputBox("¿Que valor desea copiar en las celdas de la columna " + Nombre_Columna + "?", "Reemplazar en " + Nombre_Columna, "")
        End If

        If Valor_Copiar = "" Then
            Exit Sub
        Else
            If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor

        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Try
                    For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                        If Me.Dgv_ListaPersonas.Item(1, i).Value <> Nothing Then
                            Select Case TipoPegado
                                Case "SP"
                                    Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
                                    Me.Dgv_ListaPersonas.Item(Indice_Columna - 1, i).Value = Idservicio
                                    Me.Dgv_ListaPersonas.Item(Indice_Columna - 2, i).Value = valorcopiarid
                                    If IdclaseAtención <> -1 Then
                                        Me.Dgv_ListaPersonas.Item(Indice_Columna_IdClaseAtencion, i).Value = IdclaseAtención
                                    End If
                                Case "CA"
                                    Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = valorcopiarid
                                Case "HT"
                                    Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = valorcopiarid
                                Case Else
                                    Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
                            End Select
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
                    Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                CalcularTotalCargar()
                TIntegrantes.AcceptChanges()
            Case Me.Tp_CostosPersonal.Name
                Try

                    For i = 0 To Me.Dgv_CostosPersonal.RowCount - 1
                        If Me.Dgv_CostosPersonal.Item(1, i).Value <> Nothing Then
                            Select Case TipoPegado

                                Case "TR"
                                    Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = valorcopiarid
                                Case Else
                                    Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = Valor_Copiar
                            End Select
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
                TIntegrantes.AcceptChanges()
            Case Me.Tp_Equipos.Name
                Try
                    For i = 0 To Me.Dgv_Equipos.RowCount - 1
                        If Me.Dgv_Equipos.Item(1, i).Value <> Nothing Then
                            Select Case TipoPegado
                                Case "SE"
                                    Me.Dgv_Equipos.Item(Indice_Columna, i).Value = Valor_Copiar
                                    Me.Dgv_Equipos.Item(Indice_Columna - 1, i).Value = Idservicio
                                    Me.Dgv_Equipos.Item(Indice_Columna - 2, i).Value = valorcopiarid
                                Case Else
                                    Me.Dgv_Equipos.Item(Indice_Columna, i).Value = Valor_Copiar
                            End Select
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_Equipos.CurrentCell = Me.Dgv_Equipos(0, 1)
                    Me.Dgv_Equipos.CurrentCell = Me.Dgv_Equipos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                TEquipos.AcceptChanges()
            Case Me.Tp_Materiales.Name
                Try
                    For i = 0 To Me.Dgv_Articulos.RowCount - 1
                        If Me.Dgv_Articulos.Item(1, i).Value <> Nothing Then
                            Select Case TipoPegado
                                Case "SA"
                                    Me.Dgv_Articulos.Item(Indice_Columna, i).Value = Valor_Copiar
                                    Me.Dgv_Articulos.Item(Indice_Columna - 1, i).Value = Idservicio
                                    Me.Dgv_Articulos.Item(Indice_Columna - 2, i).Value = valorcopiarid
                                Case Else
                                    Me.Dgv_Articulos.Item(Indice_Columna, i).Value = Valor_Copiar
                            End Select
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
                TArticulos.AcceptChanges()

            Case Me.Tp_CostosIndirectos.Name
                Try
                    For i = 0 To Me.Dgv_ListaCostosIndirectos.RowCount - 1
                        If Me.Dgv_ListaCostosIndirectos.Item(1, i).Value <> Nothing Then
                            Select Case TipoPegado
                                Case "SC"
                                    Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, i).Value = Valor_Copiar
                                    Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna - 1, i).Value = Idservicio
                                    Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna - 2, i).Value = valorcopiarid
                                Case Else
                                    Me.Dgv_ListaCostosIndirectos.Item(Indice_Columna, i).Value = Valor_Copiar
                            End Select
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaCostosIndirectos.CurrentCell = Me.Dgv_Articulos(0, 1)
                    Me.Dgv_ListaCostosIndirectos.CurrentCell = Me.Dgv_Articulos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                TCostosIndirectos.AcceptChanges()
            Case Me.Tp_Actividades.Name
                Try
                    For i = 0 To Me.Dgv_Actividades.RowCount - 1
                        If Me.Dgv_Actividades.Item(1, i).Value <> Nothing Then
                            Select Case TipoPegado
                                Case "CAA"
                                    Me.Dgv_Actividades.Item(Indice_Columna, i).Value = valorcopiarid
                                Case Else
                                    Me.Dgv_Actividades.Item(Indice_Columna, i).Value = Valor_Copiar
                            End Select
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_Actividades.CurrentCell = Me.Dgv_Actividades(0, 1)
                    Me.Dgv_Actividades.CurrentCell = Me.Dgv_Actividades(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                TActividades.AcceptChanges()
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_LimpiarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_LimpiarTodas.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
            Case Me.Tp_CostosPersonal.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
            Case Me.Tp_Equipos.Name
                Nombre_Columna = Me.Dgv_Equipos.Columns(Me.Dgv_Equipos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Equipos.CurrentCell.ColumnIndex
            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Articulos.CurrentCell.ColumnIndex
        End Select
        Dim Valor_Copiar As String = ""
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor

        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Try
                    For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                        Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = DBNull.Value
                        Select Case TipoPegado
                            Case "CA"
                                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = DBNull.Value
                            Case "HT"
                                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = DBNull.Value
                            Case "SP"
                                Me.Dgv_ListaPersonas.Item(Indice_Columna - 1, i).Value = DBNull.Value
                                Me.Dgv_ListaPersonas.Item(Indice_Columna - 2, i).Value = DBNull.Value
                            Case Else
                                Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = DBNull.Value
                        End Select
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
                    Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                CalcularTotalCargar()
                TIntegrantes.AcceptChanges()
            Case Me.Tp_CostosPersonal.Name
                Try
                    For i = 0 To Me.Dgv_CostosPersonal.RowCount - 1
                        Select Case TipoPegado
                            Case "TR"
                                Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = DBNull.Value
                            Case Else
                                Me.Dgv_CostosPersonal.Item(Indice_Columna, i).Value = DBNull.Value

                        End Select
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(0, 1)
                    Me.Dgv_CostosPersonal.CurrentCell = Me.Dgv_CostosPersonal(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                TIntegrantes.AcceptChanges()
            Case Me.Tp_Equipos.Name
                Try
                    For i = 0 To Me.Dgv_Equipos.RowCount - 1
                        Me.Dgv_Equipos.Item(Indice_Columna, i).Value = DBNull.Value
                        If TipoPegado = "SE" Then
                            Me.Dgv_Equipos.Item(Indice_Columna - 1, i).Value = DBNull.Value
                            Me.Dgv_Equipos.Item(Indice_Columna - 2, i).Value = DBNull.Value
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_Equipos.CurrentCell = Me.Dgv_Equipos(0, 1)
                    Me.Dgv_Equipos.CurrentCell = Me.Dgv_Equipos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                TEquipos.AcceptChanges()
            Case Me.Tp_Materiales.Name
                Try
                    For i = 0 To Me.Dgv_Articulos.RowCount - 1
                        Me.Dgv_Articulos.Item(Indice_Columna, i).Value = DBNull.Value
                        If TipoPegado = "SA" Then
                            Me.Dgv_Articulos.Item(Indice_Columna - 1, i).Value = DBNull.Value
                            Me.Dgv_Articulos.Item(Indice_Columna - 2, i).Value = DBNull.Value
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
                TArticulos.AcceptChanges()
        End Select

        Me.Cursor = Cursors.Default
    End Sub



    Private Sub TSMI_LimpiarCelda_Click(sender As Object, e As EventArgs) Handles TSMI_LimpiarCelda.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
            Case Me.Tp_CostosPersonal.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
            Case Me.Tp_Equipos.Name
                Nombre_Columna = Me.Dgv_Equipos.Columns(Me.Dgv_Equipos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Equipos.CurrentCell.ColumnIndex
            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Articulos.CurrentCell.ColumnIndex
        End Select
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaPersonas.CurrentRow.Index
                Me.Dgv_ListaPersonas.Item(Indice_Columna, IndiceFilaseleccionada).Value = DBNull.Value
                CalcularTotalCargar()
                TIntegrantes.AcceptChanges()
            Case Me.Tp_CostosPersonal.Name
                Dim IndiceFilaseleccionada As Integer = Dgv_CostosPersonal.CurrentRow.Index
                Me.Dgv_CostosPersonal.Item(Indice_Columna, IndiceFilaseleccionada).Value = DBNull.Value
                TIntegrantes.AcceptChanges()
            Case Me.Tp_Equipos.Name
                Dim IndiceFilaseleccionada As Integer = Dgv_Equipos.CurrentRow.Index
                Me.Dgv_Equipos.Item(Indice_Columna, IndiceFilaseleccionada).Value = DBNull.Value
                TEquipos.AcceptChanges()
            Case Me.Tp_Materiales.Name
                Dim IndiceFilaseleccionada As Integer = Dgv_Articulos.CurrentRow.Index
                Me.Dgv_Articulos.Item(Indice_Columna, IndiceFilaseleccionada).Value = DBNull.Value
                TArticulos.AcceptChanges()
        End Select

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReemplazarValorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ReemplazarValor.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
            Case Me.Tp_CostosPersonal.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
            Case Me.Tp_Equipos.Name
                Nombre_Columna = Me.Dgv_Equipos.Columns(Me.Dgv_Equipos.CurrentCell.ColumnIndex).HeaderText
                Indice_Columna = Me.Dgv_Equipos.CurrentCell.ColumnIndex
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
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Try
                    For i = 0 To Me.Dgv_ListaPersonas.RowCount - 2
                        If Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value.ToString = Valor_Reemplazar Then
                            Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_PorElQue_Reemplazara
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
                    Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                CalcularTotalCargar()
                TIntegrantes.AcceptChanges()
            Case Me.Tp_CostosPersonal.Name
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
                TIntegrantes.AcceptChanges()
            Case Me.Tp_Equipos.Name
                Try
                    For i = 0 To Me.Dgv_Equipos.RowCount - 2
                        If Me.Dgv_Equipos.Item(Indice_Columna, i).Value.ToString = Valor_Reemplazar Then
                            Me.Dgv_Equipos.Item(Indice_Columna, i).Value = Valor_PorElQue_Reemplazara
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
                End Try
                Try
                    Me.Dgv_Equipos.CurrentCell = Me.Dgv_Equipos(0, 1)
                    Me.Dgv_Equipos.CurrentCell = Me.Dgv_Equipos(Indice_Columna, 0)
                Catch ex As Exception
                End Try
                TEquipos.AcceptChanges()
        End Select

        Me.Cursor = Cursors.Default
    End Sub

    Dim TipoPegado As String = "" ' SP - Servicio persona 

    Private Function ValidarColumna() As Boolean
        Dim Nombre_Columna As String = ""
        activocolumnasTSMI_CopiarTodas = False
        activocolumnasTSMI_LlenarCon = False
        activocolumnasTSMI_ReemplazarValor = False
        activocolumnasTSMI_P = False
        activocolumnasTSMI_8 = False
        activocolumnasTSMI_8_5 = False
        activocolumnasTSMI_5_5 = False
        activocolumnasTSMI_D = False
        activocolumnasTSMI_I = False
        activocolumnasTSMI_T = False
        activocolumnasTSMI_O = False
        activocolumnasTSMI_S = False
        activocolumnasTSMI_N = False
        TipoPegado = ""

        activocolumnasTSMI_LimpiarTodas = False
        Select Case Tc_Recursos.SelectedTab.Name
            Case Me.Tp_Integrantes.Name
                Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "HN"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_ReemplazarValor = True
                        activocolumnasTSMI_P = True
                        activocolumnasTSMI_8 = True
                        activocolumnasTSMI_8_5 = True
                        activocolumnasTSMI_5_5 = True
                        activocolumnasTSMI_D = True
                        activocolumnasTSMI_O = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case "HED", "HEN", "RN"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_ReemplazarValor = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case "Servicio"
                        TipoPegado = "SP" 'Indica que se esta trabajando solbre la columna de servicio en el datagrid de persona
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                    Case "HIT1", "HFT1", "HIT2", "HFT2"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        TipoPegado = "HT" 'indica que se esta trabajando sobre la columna de Clase atención en el datagrid recurso persona
                    Case "UHA"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_ReemplazarValor = True
                        activocolumnasTSMI_LimpiarTodas = True
                        activocolumnasTSMI_S = True
                        activocolumnasTSMI_N = True
                        ValidarColumna = True
                        Exit Function
                    Case "Clase Atención"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        TipoPegado = "CA" 'indica que se esta trabajando sobre la columna de Clase atención en el datagrid recurso persona
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                TIntegrantes.AcceptChanges()
            Case Me.Tp_CostosPersonal.Name
                Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "D", "A", "C", "H", "M", "Vlr Des", "Vlr Alm", "Vlr Com", "Vlr Hotel", "Vlr Misc"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LlenarCon = True
                        activocolumnasTSMI_ReemplazarValor = True
                        activocolumnasTSMI_LimpiarTodas = True
                        activocolumnasTSMI_I = True
                        activocolumnasTSMI_T = True
                        ValidarColumna = True
                        Exit Function
                    Case "Tipo Recurso"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        TipoPegado = "TR" 'indica que se esta trabajando sobre la columna de tipo recurso en el datagrid recurso persona
                    Case "Observación"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                TIntegrantes.AcceptChanges()
            Case Me.Tp_Equipos.Name
                Nombre_Columna = Me.Dgv_Equipos.Columns(Me.Dgv_Equipos.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        TipoPegado = "SE" 'Indica que se esta trabajando solbre la columna de servicio en el datagrid de equipos
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case "Observación"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                TEquipos.AcceptChanges()
            Case Me.Tp_Actividades.Name
                Nombre_Columna = Me.Dgv_Actividades.Columns(Me.Dgv_Actividades.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Clase Atención"
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        TipoPegado = "CAA" 'indica que se esta trabajando sobre la columna de Clase atención en el datagrid recurso persona
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select

            Case Me.Tp_Materiales.Name
                Nombre_Columna = Me.Dgv_Articulos.Columns(Me.Dgv_Articulos.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        TipoPegado = "SA" 'Indica que se esta trabajando solbre la columna de servicio en el datagrid de artículos
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                TArticulos.AcceptChanges()
            Case Me.Tp_CostosIndirectos.Name
                Nombre_Columna = Me.Dgv_ListaCostosIndirectos.Columns(Me.Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex).HeaderText
                Select Case Nombre_Columna
                    Case "Servicio"
                        TipoPegado = "SC" 'Indica que se esta trabajando solbre la columna de servicio en el datagrid de costos indirectos
                        activocolumnasTSMI_CopiarTodas = True
                        activocolumnasTSMI_LimpiarTodas = True
                        ValidarColumna = True
                        Exit Function
                    Case Else
                        ValidarColumna = False
                        Exit Function
                End Select
                TCostosIndirectos.AcceptChanges()
        End Select
        ValidarColumna = False
    End Function

    Private Sub TSMI_P_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_P.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer


        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "P"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
    End Sub

    Private Sub TSMI_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_8.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "8"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub TSMI_D_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_D.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "D"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_I_Click(sender As Object, e As EventArgs) Handles TSMI_I.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "I"
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
        TIntegrantes.AcceptChanges()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_T_Click(sender As Object, e As EventArgs) Handles TSMI_T.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_CostosPersonal.Columns(Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_CostosPersonal.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "T"
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
        TIntegrantes.AcceptChanges()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_O_Click(sender As Object, e As EventArgs) Handles TSMI_O.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer


        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "O"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
    End Sub


    Private Sub TSMI_S_Click(sender As Object, e As EventArgs) Handles TSMI_S.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer


        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "S"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
    End Sub

    Private Sub TSMI_N_Click(sender As Object, e As EventArgs) Handles TSMI_N.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer


        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "N"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
    End Sub

    Dim activocolumnasTSMI_CopiarTodas As Boolean = False
    Dim activocolumnasTSMI_LlenarCon As Boolean = False
    Dim activocolumnasTSMI_ReemplazarValor As Boolean = False
    Dim activocolumnasTSMI_P As Boolean = False
    Dim activocolumnasTSMI_8 As Boolean = False
    Dim activocolumnasTSMI_8_5 As Boolean = False
    Dim activocolumnasTSMI_5_5 As Boolean = False
    Dim activocolumnasTSMI_D As Boolean = False
    Dim activocolumnasTSMI_I As Boolean = False
    Dim activocolumnasTSMI_T As Boolean = False
    Dim activocolumnasTSMI_O As Boolean = False
    Dim activocolumnasTSMI_S As Boolean = False
    Dim activocolumnasTSMI_N As Boolean = False
    Dim activocolumnasTSMI_LimpiarTodas As Boolean = False

    Private Sub Cms_opciones_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Cms_opciones.Opening
        ValidarColumna()
        TSMI_CopiarTodas.Visible = activocolumnasTSMI_CopiarTodas
        TSMI_LlenarCon.Visible = activocolumnasTSMI_LlenarCon
        TSMI_ReemplazarValor.Visible = activocolumnasTSMI_ReemplazarValor
        TSMI_P.Visible = activocolumnasTSMI_P
        TSMI_8.Visible = activocolumnasTSMI_8
        TSMI_8_5.Visible = activocolumnasTSMI_8_5
        TSMI_5_5.Visible = activocolumnasTSMI_5_5
        TSMI_D.Visible = activocolumnasTSMI_D
        TSMI_I.Visible = activocolumnasTSMI_I
        TSMI_T.Visible = activocolumnasTSMI_T
        TSMI_O.Visible = activocolumnasTSMI_O
        TSMI_S.Visible = activocolumnasTSMI_S
        TSMI_N.Visible = activocolumnasTSMI_N
        TSMI_LimpiarTodas.Visible = activocolumnasTSMI_LimpiarTodas
    End Sub

    Private Sub Dgv_ListaIntegrantes_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgv_ListaPersonas.CellFormatting
        If e.ColumnIndex >= 0 And e.ColumnIndex < 8 Then
            e.CellStyle.BackColor = Color.Beige
        Else
            If e.ColumnIndex > 7 And e.ColumnIndex < 13 Then
                e.CellStyle.BackColor = Color.AliceBlue
            Else
                If e.ColumnIndex > 12 Then
                    e.CellStyle.BackColor = Color.LemonChiffon
                End If
            End If
        End If
    End Sub

    Public Function ValidarConvenciones(ByVal convención As String) As Boolean
        Dim validar As Boolean = False
        Select Case UCase(convención)
            Case "O", "D", "A", "I", "IC", "S", "ACSP", "ACCP", "P", "DIS", "NDS", "V", "VAC", "SUS"
                validar = True
        End Select
        ValidarConvenciones = validar
    End Function

    Private Function Validar_ValoresListaIntegrantes() As Boolean
        CerrarFormulario = True
        Dim Validar As Boolean = True
        Try
            Dim ListaIntegrantes As New ArrayList
            For j = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                ListaIntegrantes.Add(Dgv_ListaPersonas.Rows(j).Cells("DGVTBC_IDCONTRATO").Value)
            Next

            Me.Dgv_ListaPersonas.SuspendLayout()
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer
            'Cuando el valor no es valido
            Dim Estilo_Celda_Error As New DataGridViewCellStyle
            Estilo_Celda_Error.BackColor = Color.Red
            'Cuando no corresponde con la convenció
            Dim Estilo_Celda_convención As New DataGridViewCellStyle
            Estilo_Celda_convención.BackColor = Color.Khaki
            Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
            Estilo_Celda_ValorFuera.BackColor = Color.Indigo
            'Cuando esta bien
            Dim Estilo_Celda As New DataGridViewCellStyle
            Estilo_Celda.BackColor = Color.White
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                With Dgv_ListaPersonas

                    .Rows(i).DefaultCellStyle = Estilo_Celda
                    .Rows(i).ErrorText = ""

                    Dim N As String
                    Dim ED As String
                    Dim EN As String
                    Dim RN As String

                    N = (.Rows(i).Cells("DGVTBC_HORASNORMALES").Value).ToString
                    ED = (.Rows(i).Cells("DGVTBC_HORASEXTRASDIURNAS").Value).ToString
                    EN = (.Rows(i).Cells("DGVTBC_HORASEXTRASNOCTURNAS").Value).ToString
                    RN = (.Rows(i).Cells("DGVTBC_HORASRECARGONOCTURNO").Value).ToString

                    Dim D As String
                    Dim A As String
                    Dim C As String
                    Dim H As String
                    Dim M As String


                    D = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_DESAYUNO").Value).ToString
                    A = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_ALMUERZO").Value).ToString
                    C = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_COMIDA").Value).ToString
                    H = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_ALOJAMIENTO").Value).ToString
                    M = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_MISCELANIOS").Value).ToString

                    Select Case D
                        Case "", "I", "T"
                        Case Else
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "Verifica el valor de Desayuno solo puede ser I o T"
                    End Select

                    Select Case A
                        Case "", "I", "T"
                        Case Else
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "Verifica el valor de Almuerzo solo puede ser I o T"
                    End Select

                    Select Case C
                        Case "", "I", "T"
                        Case Else
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "Verifica el valor de Comida solo puede ser I o T"
                    End Select

                    Select Case H
                        Case "", "I", "T"
                        Case Else
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "Verifica el valor de Hospedaje solo puede ser I o T"
                    End Select

                    Select Case M
                        Case "", "I", "T"
                        Case Else
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "Verifica el valor de Miscelanios solo puede ser I o T"
                    End Select

                    Dim HIT1 As Integer
                    Dim HFT1 As Integer
                    Dim HIT2 As Integer
                    Dim HFT2 As Integer
                    Dim HA As String

                    Dim IDCONTRATO As Integer


                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value) <> "     " Then
                    '    HIT1 = .Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value
                    'Else
                    '    HIT1 = ""
                    'End If

                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value) <> "     " Then
                    '    HFT1 = .Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value
                    'Else
                    '    HFT1 = ""
                    'End If

                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value) <> "     " Then
                    '    HIT2 = .Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value
                    'Else
                    '    HIT2 = ""
                    'End If

                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value) <> "     " Then
                    '    HFT2 = .Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value
                    'Else
                    '    HFT2 = ""
                    'End If

                    If IsDBNull(.Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value) <> True Then
                        HIT1 = .Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value
                    Else
                        HIT1 = -1
                    End If

                    If IsDBNull(.Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value) <> True Then
                        HFT1 = .Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value
                    Else
                        HFT1 = -1
                    End If

                    If IsDBNull(.Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value) <> True Then
                        HIT2 = .Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value
                    Else
                        HIT2 = -1
                    End If

                    If IsDBNull(.Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value) <> True Then
                        HFT2 = .Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value
                    Else
                        HFT2 = -1
                    End If


                    If IsNothing(.Rows(i).Cells("DGVTBC_USOHORAALMUERZO").Value) <> True Then
                        HA = (.Rows(i).Cells("DGVTBC_USOHORAALMUERZO").Value).ToString
                    Else
                        HA = ""
                    End If

                    'If HIT1 = "" And HFT1 = "" Then
                    '    .Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value = DBNull.Value
                    '    .Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value = DBNull.Value
                    '    .Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value = DBNull.Value
                    '    .Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value = DBNull.Value
                    '    HIT1 = ""
                    '    HFT1 = ""
                    '    HIT2 = ""
                    '    HFT2 = ""
                    '    .Rows(i).Cells("DGVTBC_USOHORAALMUERZO").Value = ""
                    '    HA = ""
                    'End If

                    'If HIT2 = "" And HFT2 = "" Then
                    '    .Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value = DBNull.Value
                    '    .Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value = DBNull.Value
                    '    HIT2 = ""
                    '    HFT2 = ""
                    'End If

                    If HIT1 = 0 And HFT1 = 0 Then
                        .Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value = DBNull.Value
                        .Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value = DBNull.Value
                        .Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value = DBNull.Value
                        .Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value = DBNull.Value
                        HIT1 = -1
                        HFT1 = -1
                        HIT2 = -1
                        HFT2 = -1
                        .Rows(i).Cells("DGVTBC_USOHORAALMUERZO").Value = ""
                        HA = ""
                    End If

                    If HIT2 = 0 And HFT2 = 0 Then
                        .Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value = DBNull.Value
                        .Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value = DBNull.Value
                        HIT2 = -1
                        HFT2 = -1
                    End If

                    Dim VD As Double
                    Dim VA As Double
                    Dim VC As Double
                    Dim VH As Double
                    Dim VM As Double
                    If IsDBNull((Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORDESAYUNO").Value)) = False Then
                        VD = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORDESAYUNO").Value)
                        If VD > 99999 Then
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "El valor del desayuno esta fuera del valor permitido"
                        End If
                    End If

                    If IsDBNull((Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORALMUERZO").Value)) = False Then
                        VA = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORALMUERZO").Value)
                        If VA > 99999 Then
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "El valor del almuerzo esta fuera del valor permitido"
                        End If
                    End If

                    If IsDBNull((Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORCOMIDA").Value)) = False Then
                        VC = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORCOMIDA").Value)
                        If VC > 99999 Then
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "El valor de la comida esta fuera del valor permitido"
                        End If
                    End If

                    If IsDBNull((Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORALOJAMIENTO").Value)) = False Then
                        VH = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORALOJAMIENTO").Value)
                        If VH > 999999 Then
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "El valor del hospedaje esta fuera del valor permitido"
                        End If
                    End If

                    If IsDBNull((Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORMISCELANIOS").Value)) = False Then
                        VH = (Dgv_CostosPersonal.Rows(i).Cells("DGVTBC_VALORMISCELANIOS").Value)
                        If VM > 99999 Then
                            Validar = False
                            Dgv_CostosPersonal.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_CostosPersonal.Rows(i).ErrorText = "El valor de los miscelanios esta fuera del valor permitido"
                        End If
                    End If

                    IDCONTRATO = (.Rows(i).Cells("DGVTBC_IDCONTRATO").Value).ToString

                    'Verificar los horarios de trabajo y la hora de almuerzo
                    'Dim posicion As Integer = 0
                    'Dim posicion1 As Integer = 0
                    'Dim posicion2 As Integer = 0

                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value) <> "" Then
                    '    HIT1 = (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO1").Value)
                    '    posicion = InStr(HIT1, ":")
                    '    posicion1 = InStr(Mid(HIT1, 5, 1), " ")
                    '    posicion2 = InStr(Mid(HIT1, 5, 1), "")
                    '    If posicion <> 3 Or posicion1 = 1 Or posicion2 = 0 Or InStr(Mid(HIT1, 5, 1), ":") = 1 Then
                    '        Validar = False
                    '        Dgv_ListaPersonas.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '        Dgv_ListaPersonas.Rows(i).ErrorText = "Formato de hora incorrecto en HIT1, Ejemplo : 00:00"
                    '    End If
                    'End If
                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value) <> "" Then
                    '    HFT1 = (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO1").Value)
                    '    posicion = InStr(HFT1, ":")
                    '    posicion1 = InStr(Mid(HFT1, 5, 1), " ")
                    '    posicion2 = InStr(Mid(HFT1, 5, 1), "")
                    '    If posicion <> 3 Or posicion1 = 1 Or posicion2 = 0 Or InStr(Mid(HFT1, 5, 1), ":") = 1 Then
                    '        Validar = False
                    '        Dgv_ListaPersonas.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '        Dgv_ListaPersonas.Rows(i).ErrorText = "Formato de hora incorrecto en HFT1, Ejemplo : 00:00"
                    '    End If
                    'End If
                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value) <> "" Then
                    '    HIT2 = (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAINICIALTURNO2").Value)
                    '    posicion = InStr(HIT2, ":")
                    '    posicion1 = InStr(Mid(HIT2, 5, 1), " ")
                    '    posicion2 = InStr(Mid(HIT2, 5, 1), "")
                    '    If posicion <> 3 Or posicion1 = 1 Or posicion2 = 0 Or InStr(Mid(HIT2, 5, 1), ":") = 1 Then
                    '        Validar = False
                    '        Dgv_ListaPersonas.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '        Dgv_ListaPersonas.Rows(i).ErrorText = "Formato de hora incorrecto en HIT2, Ejemplo : 00:00"
                    '    End If
                    'End If
                    'If (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value) <> "" Then
                    '    HFT2 = (Dgv_ListaPersonas.Rows(i).Cells("DGVTBC_HORAFINALTURNO2").Value)
                    '    posicion = InStr(HFT2, ":")
                    '    posicion1 = InStr(Mid(HIT2, 5, 1), " ")
                    '    posicion2 = InStr(Mid(HFT2, 5, 1), "")
                    '    If posicion <> 3 Or posicion1 = 1 Or posicion2 = 0 Or InStr(Mid(HFT2, 5, 1), ":") = 1 Then
                    '        Validar = False
                    '        Dgv_ListaPersonas.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '        Dgv_ListaPersonas.Rows(i).ErrorText = "Formato de hora incorrecto en HFT2, Ejemplo : 00:00"
                    '    End If
                    'End If

                    'If HIT1 = "" And HFT1 <> "" Then
                    '    Validar = False
                    '    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '    .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                    'Else
                    '    If HIT1 <> "" And HFT1 = "" Then
                    '        Validar = False
                    '        .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '        .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                    '    Else
                    '        If HIT2 = "" And HFT2 <> "" Then
                    '            Validar = False
                    '            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '            .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                    '        Else
                    '            If HIT2 <> "" And HFT2 = "" Then
                    '                Validar = False
                    '                .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '                .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                    '            End If
                    '        End If
                    '    End If
                    'End If

                    If HIT1 = -1 And HFT1 <> -1 Then
                        Validar = False
                        .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                        .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                    Else
                        If HIT1 <> -1 And HFT1 = -1 Then
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                        Else
                            If HIT2 = -1 And HFT2 <> -1 Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                            Else
                                If HIT2 <> -1 And HFT2 = -1 Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                    .Rows(i).ErrorText = "Verifica los horarios de los turnos, esta incompleto"
                                End If
                            End If
                        End If
                    End If



                    'Dim HIT1H As String
                    'Dim HFT1H As String
                    'Dim HIT2H As String
                    'Dim HFT2H As String


                    'If HIT1 <> "" Then
                    '    posicion = InStr(HIT1, ":")
                    '    If posicion <> 1 And posicion <> 2 Then
                    '        HIT1H = Mid(HIT1, 1, 2)
                    '    Else
                    '        HIT1H = 0
                    '    End If
                    'Else
                    '    HIT1H = 0
                    'End If

                    'If HFT1 <> "" Then
                    '    posicion = InStr(HFT1, ":")
                    '    If posicion <> 1 And posicion <> 2 Then
                    '        HFT1H = Mid(HFT1, 1, 2)
                    '    Else
                    '        HFT1H = 0
                    '    End If
                    'Else
                    '    HFT1H = 0
                    'End If

                    'If HIT2 <> "" Then
                    '    posicion = InStr(HIT2, ":")
                    '    If posicion <> 1 And posicion <> 2 Then
                    '        HIT2H = Mid(HIT2, 1, 2)
                    '    Else
                    '        HIT2H = 0
                    '    End If
                    'Else
                    '    HIT2H = 0
                    'End If

                    'If HFT2 <> "" Then
                    '    posicion = InStr(HFT2, ":")
                    '    If posicion <> 1 And posicion <> 2 Then
                    '        HFT2H = Mid(HFT2, 1, 2)
                    '    Else
                    '        HFT2H = 0
                    '    End If
                    'Else
                    '    HFT2H = 0
                    'End If


                    'If HIT1H > 24 Or HFT1H > 24 Or HIT2H > 24 Or HFT2H > 24 Then
                    '    Validar = False
                    '    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '    .Rows(i).ErrorText = "Verifica los horarios de los turnos, La hora no puede ser mayor a 24"
                    'End If

                    'Dim HIT1M As String
                    'Dim HFT1M As String
                    'Dim HIT2M As String
                    'Dim HFT2M As String

                    'If HIT1 <> "" Then
                    '    posicion = InStr(Mid(HIT1, 3, 1), " ")
                    '    If posicion <> 1 Then
                    '        posicion1 = InStr(HIT1, ":")
                    '        If posicion1 <> 4 And posicion1 <> 5 Then
                    '            HIT1M = Mid(HIT1, 4, 2)
                    '        Else
                    '            HIT1M = 0
                    '        End If
                    '    Else
                    '        HIT1M = 0
                    '    End If
                    '    Else
                    '        HIT1M = 0
                    '    End If

                    'If HFT1 <> "" Then
                    '    posicion = InStr(Mid(HFT1, 3, 1), " ")
                    '    If posicion <> 1 Then
                    '        posicion1 = InStr(HFT1, ":")
                    '        If posicion1 <> 4 And posicion1 <> 5 Then
                    '            HFT1M = Mid(HFT1, 4, 2)
                    '        Else
                    '            HFT1M = 0
                    '        End If
                    '    Else
                    '        HFT1M = 0
                    '    End If
                    '    Else
                    '        HFT1M = 0
                    '    End If

                    'If HIT2 <> "" Then
                    '    posicion = InStr(Mid(HIT2, 3, 1), " ")
                    '    If posicion <> 1 Then
                    '        posicion1 = InStr(HIT2, ":")
                    '        If posicion1 <> 4 And posicion1 <> 5 Then
                    '            HIT2M = Mid(HIT2, 4, 2)
                    '        Else
                    '            HIT2M = 0
                    '        End If
                    '    Else
                    '        HIT2M = 0
                    '    End If
                    '    Else
                    '        HIT2M = 0
                    '    End If

                    'If HFT2 <> "" Then
                    '    posicion = InStr(Mid(HFT2, 3, 1), " ")
                    '    If posicion <> 1 Then
                    '        posicion1 = InStr(HFT2, ":")
                    '        If posicion1 <> 4 And posicion1 <> 5 Then
                    '            HFT2M = Mid(HFT2, 4, 2)
                    '        Else
                    '            HFT2M = 0
                    '        End If
                    '    Else
                    '        HFT2M = 0
                    '    End If
                    '    Else
                    '        HFT2M = 0
                    '    End If

                    'If HIT1M > 59 Or HFT1M > 59 Or HIT2M > 59 Or HFT2M > 59 Then
                    '    Validar = False
                    '    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '    .Rows(i).ErrorText = "Verifica los horarios de los turnos,Los minutos no pueden ser mayor a 59"
                    'End If


                    'validar siempre y cuando tengan valores en los turnos
                    'If HIT1 <> "" And HFT1 <> "" Then

                    '    posicion = InStr(HIT1, ":")
                    '    If posicion <> 1 And posicion <> 2 Then
                    '        HIT1 = Mid(HIT1, 1, 2)
                    '    Else
                    '        HIT1 = 0
                    '    End If

                    '    posicion1 = InStr(HFT1, ":")
                    '    If posicion1 <> 1 And posicion1 <> 2 Then
                    '        HFT1 = Mid(HFT1, 1, 2)
                    '    Else
                    '        HIT1 = 0
                    '    End If


                    '    If CInt(HIT1) >= CInt(HFT1) Then
                    '        Validar = False
                    '        .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '        .Rows(i).ErrorText = "Verifica los horarios del turno 1, el horario inicial turno 1 no pueden ser mayor o igual horario final del turno 1"
                    '    End If
                    '    If HIT2 <> "" And HFT2 <> "" Then

                    '        posicion = InStr(HIT2, ":")
                    '        If posicion <> 1 And posicion <> 2 Then
                    '            HIT2 = Mid(HIT2, 1, 2)
                    '        Else
                    '            HIT2 = 0
                    '        End If

                    '        posicion1 = InStr(HFT2, ":")
                    '        If posicion1 <> 1 And posicion1 <> 2 Then
                    '            HFT2 = Mid(HFT2, 1, 2)
                    '        Else
                    '            HFT2 = 0
                    '        End If

                    '        If CInt(HFT1) >= CInt(HIT2) Then
                    '            Validar = False
                    '            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '            .Rows(i).ErrorText = "Verifica los horarios del turno 2, el horario inicial turno 2 no pueden ser menor o igual horario final del turno 1"
                    '        End If
                    '        If CInt(HIT1) >= CInt(HIT2) Then
                    '            Validar = False
                    '            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '            .Rows(i).ErrorText = "Verifica los horarios del turno 2, el horario inicial turno 1 no pueden ser mayor o igual horario inicial del turno 2"
                    '        End If
                    '        If CInt(HIT2) >= CInt(HFT2) Then
                    '            Validar = False
                    '            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    '            .Rows(i).ErrorText = "Verifica los horarios del turno 2, el horario inicial turno 2 no pueden ser mayor o igual horario final del turno 2"
                    '        End If
                    '    End If
                    'End If

                    If HIT1 <> -1 And HFT1 <> -1 Then
                        If HIT1 >= HFT1 Then
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(i).ErrorText = "Verifica los horarios del turno 1, el horario inicial turno 1 no pueden ser mayor o igual horario final del turno 1"
                        End If
                        If HIT2 <> -1 And HFT2 <> -1 Then
                            If HFT1 >= HIT2 Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(i).ErrorText = "Verifica los horarios del turno 2, el horario inicial turno 2 no pueden ser menor o igual horario final del turno 1"
                            End If
                            If HIT1 >= HIT2 Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(i).ErrorText = "Verifica los horarios del turno 2, el horario inicial turno 1 no pueden ser mayor o igual horario inicial del turno 2"
                            End If
                            If HIT2 >= HFT2 Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                .Rows(i).ErrorText = "Verifica los horarios del turno 2, el horario inicial turno 2 no pueden ser mayor o igual horario final del turno 2"
                            End If
                        End If
                    End If

                        If HA <> "S" Then
                            If HA <> "N" Then
                                If HA <> "" Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                    .Rows(i).ErrorText = "Verificar utiliza hora de almuerzo, los valores permitidos son S o N"
                                End If
                            Else
                                If HIT1 = "" And HFT1 = "" And HIT2 = "" And HFT2 = "" Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                    .Rows(i).ErrorText = "Verificar utiliza hora de almuerzo, no presenta horarios para marcar su utilización"
                                End If
                            End If
                        Else
                        If HIT1 = -1 And HFT1 = -1 And HIT2 = -1 And HFT2 - 1 Then
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(i).ErrorText = "Verificar utiliza hora de almuerzo, no presenta horarios para marcar su utilización"
                        End If
                        End If

                        If IsDBNull(IDCONTRATO) = False Then
                            'verificar que es numerico
                            If IsNumeric(IDCONTRATO) = False Then
                                If ValidarConvenciones(N) = False Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                                    .Rows(i).ErrorText = "Verifica el contrato, en la columna IDCONTRATO debe tener algún valor"
                                End If
                            End If
                        Else
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(i).ErrorText = "Verifica el contrato, en la columna IDCONTRATO debe tener algún valor"
                        End If

                        If ValidarValorIngresado(ED, "ED", i) = False Then
                            Validar = False
                        End If
                        If ValidarValorIngresado(EN, "EN", i) = False Then
                            Validar = False
                        End If
                        If ValidarValorIngresado(RN, "RN", i) = False Then
                            Validar = False
                        End If
                        If IsDBNull(N) = False Then
                            'verificar que es numerico
                            If IsNumeric(N) = False Then
                                If ValidarConvenciones(N) = False Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                    .Rows(i).ErrorText = "N no esta dentro de las convenciones establecidas"
                                    If Trim(N) <> "" Then
                                        CerrarFormulario = False
                                    End If
                                End If
                            Else
                                ValidarValorIngresado(N, "N", i)
                            End If
                        Else
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            .Rows(i).ErrorText = "N debe tener algún valor"
                        End If
                        'Validar por tipo de salario
                        Dim TIPOSALARIO As String = (.Rows(i).Cells("DGVTBC_CODIGOTIPOSALARIO").Value).ToString
                        If TIPOSALARIO = "M" Then
                            If N = "8" Or N = "8,5" Or N = "5,5" Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "N no es valido para el tipo de salario"
                            End If
                        Else
                            If N = "P" Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "N no es valido para el tipo de salario"
                            End If
                        End If

                        'Validar que no metan valores cuando este en D
                        If N = "D" Or N = "IC" Or N = "ACSP" Or N = "ACCP" Or N = "VAC" Or N = "SUS" Then
                            If ED <> "" Or EN <> "" Or RN <> "" Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "Error en ED, EN o RN"
                            End If
                        End If
                        If Ck_Validar12Horas.CheckState = CheckState.Checked Then
                            If IsNumeric(.Rows(i).Cells("DGVTBC_TOTAL").Value) Then
                                Dim TOTAL As String
                                TOTAL = (.Rows(i).Cells("DGVTBC_TOTAL").Value).ToString
                                If CInt(TOTAL) > 12 Then
                                    If MsgBox("El total supera las 12 horas, ¿Desea Continuar?", MsgBoxStyle.YesNo, "SUPERA LAS 12 HORAS") = MsgBoxResult.No Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "El total no puede sumar mas de 12 horas de trabajo"
                                    End If
                                End If
                            End If
                        End If
                End With
            Next
            Me.Enabled = True
            Me.Cursor = Cursors.Default
            Me.Dgv_ListaPersonas.ResumeLayout()
            'Validar que el total no sea mayor a 12
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Validar_ValoresListaIntegrantes = Validar
    End Function

    Private Sub Dgv_ListaIntegrantes_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_ListaPersonas.CellValueChanged
        Select Case e.ColumnIndex
            Case 9, 10, 11, 12, 13 'Columnas de los turnos

            Case 14, 15, 16, 17 'columnas del resumen de tiempo trbajado
                CalcularTotalPersona()
        End Select
    End Sub

#End Region

#Region "Pestaña Equipo"

    Private Sub Dgv_Equipos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Equipos.CellEndEdit


        If IsDBNull(Me.Dgv_Equipos.Item(e.ColumnIndex, e.RowIndex).Value) Then
            Me.Dgv_Equipos.Item(e.ColumnIndex, e.RowIndex).Value = DBNull.Value
        End If

        If IsDBNull(Trim(Me.Dgv_Equipos.Item(DGVTBC_CODIGOEQUIPO.Name, e.RowIndex).Value)) = True Then
            'If e.RowIndex > 0 Then
            '    Me.Dgv_Equipos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
            '    Me.Dgv_Equipos.Rows(e.RowIndex).ErrorText = ""
            'Else
            Try
                Me.Dgv_Equipos.Rows.RemoveAt(e.RowIndex)
                TEquipos.AcceptChanges()
                For x As Integer = 0 To TEquipos.Rows.Count - 1
                    If Not IsDBNull(TEquipos.Rows(x).Item(0)) Then 'LISTAITEMREQUISICION
                        TEquipos.Rows(x).Item(0) = x + 1 'LISTAITEMREQUISICION
                    End If
                Next
            Catch
            End Try
            'End If
            Exit Sub
        End If


        If Trim(Me.Dgv_Equipos.Item(DGVTBC_CODIGOEQUIPO.Name, e.RowIndex).Value) = "" Then
            'If e.RowIndex > 0 Then
            '    Me.Dgv_Equipos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
            '    Me.Dgv_Equipos.Rows(e.RowIndex).ErrorText = ""
            'Else
            Try
                Me.Dgv_Equipos.Rows.RemoveAt(e.RowIndex)
                TEquipos.AcceptChanges()
                For x As Integer = 0 To TEquipos.Rows.Count - 1
                    If Not IsDBNull(TEquipos.Rows(x).Item(0)) Then 'LISTAITEMREQUISICION
                        TEquipos.Rows(x).Item(0) = x + 1 'LISTAITEMREQUISICION
                    End If
                Next
            Catch
            End Try
            'End If
            Exit Sub
        End If

        Dim CODIGOEQUIPO As String = ""
        Dim ORDEN As Integer = -1

        If Not IsDBNull(Me.Dgv_Equipos.Item(DGVTBC_CODIGOEQUIPO.Name, e.RowIndex).Value) Then
            CODIGOEQUIPO = Me.Dgv_Equipos.Item(DGVTBC_CODIGOEQUIPO.Name, e.RowIndex).Value
        End If

        If Not IsDBNull(Me.Dgv_Equipos.Item(DGVTBC_ORDENEQUIPO.Name, e.RowIndex).Value) Then
            ORDEN = Me.Dgv_Equipos.Item(DGVTBC_ORDENEQUIPO.Name, e.RowIndex).Value
        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_Equipos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_Equipos.Rows(e.RowIndex).ErrorText = ""

        'Validar equipo
        Select Case e.ColumnIndex
            Case Dgv_Equipos.Columns(DGVTBC_CODIGOEQUIPO.Name).Index '1

                If ValidarItemsRDEquipo(CODIGOEQUIPO, ORDEN) = True Then

                    Dim FilasEquipos As DataRow()
                    Dim equipos As New DataTable()
                    Dim Cadena_Consulta As String = "SELECT * FROM dbo.detalleEquipo('" & CODIGOEQUIPO & "'," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                    Dim Consulta As New SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Adaptador.FillSchema(equipos, SchemaType.Source)
                    Adaptador.Fill(equipos)
                    Consulta.Connection.Close()
                    FilasEquipos = equipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "'")

                    If FilasEquipos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                        Dim FilaEquipo As DataRow
                        FilaEquipo = FilasEquipos(0)
                        Dim NuevaFilaItem As DataRow
                        NuevaFilaItem = TEquipos.NewRow
                        If ORDEN = -1 Then
                            NuevaFilaItem("ORDEN") = TEquipos.Rows.Count + 1
                        Else
                            NuevaFilaItem("ORDEN") = ORDEN
                        End If
                        NuevaFilaItem("IDEQUIPO") = FilaEquipo("IDEQUIPO")
                        NuevaFilaItem("CODIGOEQUIPO") = FilaEquipo("CODIGOEQUIPO")
                        NuevaFilaItem("DESCRIPCION") = Mid(FilaEquipo("NOMBREDESCRIPTIVO"), 1, 99)
                        NuevaFilaItem("DISPONIBLE") = "N"
                        NuevaFilaItem("VARADO") = "N"
                        If TEquipos.Rows.Count = Me.Dgv_Equipos.CurrentCell.RowIndex Then '
                            Try
                                Me.Dgv_Equipos.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                            TEquipos.Rows.Add(NuevaFilaItem) '
                        Else
                            NuevaFilaItem("ORDEN") = TEquipos.Rows.Count + 1
                            NuevaFilaItem("IDEQUIPO") = FilaEquipo("IDEQUIPO")
                            NuevaFilaItem("CODIGOEQUIPO") = FilaEquipo("CODIGOEQUIPO")
                            NuevaFilaItem("DESCRIPCION") = Mid(FilaEquipo("NOMBREDESCRIPTIVO"), 1, 99)
                            NuevaFilaItem("DISPONIBLE") = "N"
                            NuevaFilaItem("VARADO") = "N"
                        End If
                    Else
                        'No existe un artículo con este código
                        MensajeError = "No se encontró un equipo con ese código"
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Equipo no Encontrado")
                        Dim NuevaFilaItem As DataRow
                        NuevaFilaItem = TEquipos.NewRow
                        NuevaFilaItem("ORDEN") = TEquipos.Rows.Count + 1
                        NuevaFilaItem("CODIGOEQUIPO") = CODIGOEQUIPO
                        NuevaFilaItem("DISPONIBLE") = "N"
                        NuevaFilaItem("VARADO") = "N"
                        Try
                            Me.Dgv_Equipos.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                        TEquipos.Rows.Add(NuevaFilaItem) '

                    End If
                Else
                    MensajeError = "El item que desea ingresar, ya se encuentra incluido en el reporte diario"
                    MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                    Try
                        Me.Dgv_Equipos.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
                ' Case Dgv_Equipos.Columns(DGVTBC_HORASNORMALES.Name).Index
        End Select

        Try
            ' TEquipos.AcceptChanges() 'LISTAITEMREQUISICION
        Catch
        End Try

        ELiminarFilaVacia("E")

    End Sub

    Private Sub Dgv_Equipos_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Equipos.KeyDown

        Dim selectedRowCount1 As Integer = Dgv_Equipos.CurrentCell.ColumnIndex

        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3

                Select Case selectedRowCount1 'Buscar equipo
                    Case 2
                        Dim FrBuscarEquipo As New FormulariosClasesBase.Fr_BuscarEquipo

                        FrBuscarEquipo.CargarListaEquipoBase()

                        FrBuscarEquipo.ShowDialog()

                        Dim IDEQUIPO As Integer
                        IDEQUIPO = FrBuscarEquipo.IdEquipo
                        Dim CODIGOEQUIPO As String
                        CODIGOEQUIPO = FrBuscarEquipo.NombreEquipo

                        If ValidarItemsRDEquipo(CODIGOEQUIPO, -1) = True Then
                            Dim FilasContratos As DataRow()
                            Dim equipos As New DataTable()
                            Dim Cadena_Consulta As String = "SELECT * FROM dbo.detalleEquipo('" & CODIGOEQUIPO & "'," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                            Dim Consulta As New SqlCommand(Cadena_Consulta)
                            Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                            Consulta.Connection = Conexión
                            Dim Adaptador As New SqlDataAdapter(Consulta)
                            Consulta.Connection.Open()
                            Adaptador.FillSchema(equipos, SchemaType.Source)
                            Adaptador.Fill(equipos)
                            Consulta.Connection.Close()
                            FilasContratos = equipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "'")
                            If FilasContratos.Length > 0 Then '
                                Dim FilaContrato As DataRow
                                FilaContrato = FilasContratos(0)
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TEquipos.NewRow
                                NuevaFilaItem("ORDEN") = TEquipos.Rows.Count + 1
                                NuevaFilaItem("IDEQUIPO") = FilaContrato("IDEQUIPO")
                                NuevaFilaItem("CODIGOEQUIPO") = FilaContrato("CODIGOEQUIPO")
                                NuevaFilaItem("DESCRIPCION") = Mid(FilaContrato("NOMBREDESCRIPTIVO"), 1, 99)
                                NuevaFilaItem("DISPONIBLE") = "N"
                                NuevaFilaItem("VARADO") = "N"
                                TEquipos.Rows.Add(NuevaFilaItem) '
                            Else
                                'No existe un artículo con este código
                                MensajeError = "No se encontró un equipo con ese código"
                                MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Equipo no Encontrado")
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TEquipos.NewRow
                                NuevaFilaItem("ORDEN") = TEquipos.Rows.Count + 1
                                NuevaFilaItem("CODIGOEQUIPO") = CODIGOEQUIPO
                                NuevaFilaItem("DISPONIBLE") = "N"
                                NuevaFilaItem("VARADO") = "N"
                                TEquipos.Rows.Add(NuevaFilaItem)
                            End If
                        Else
                            MensajeError = "El item que desea ingresar, ya se encuentra incluido en el reporte diario"
                            MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                        End If
                        ELiminarFilaVacia("E")
                    Case 12
                        Dim IndiceFilaseleccionada As Integer = Dgv_Equipos.CurrentRow.Index
                        If IsDBNull(Dgv_Equipos.Rows(IndiceFilaseleccionada).Cells(1).Value) = False Then

                            Dim FrBuscarServicioOTSAP As New Fr_BuscarServicioOTSAP
                            FrBuscarServicioOTSAP.tablaunidades = tablaunidades
                            FrBuscarServicioOTSAP._Tipo = "A"
                            FrBuscarServicioOTSAP.TipoBusqueda = "E"
                            FrBuscarServicioOTSAP.Cargar_Tabla("A")
                            FrBuscarServicioOTSAP.ShowDialog()
                            For j = 0 To FrBuscarServicioOTSAP.TablaServicios.Rows.Count - 1
                                Dim FilaServicioBusqueda As DataRow
                                FilaServicioBusqueda = FrBuscarServicioOTSAP.TablaServicios.Rows(j)
                                Dgv_Equipos.Rows(IndiceFilaseleccionada).Cells(10).Value = FilaServicioBusqueda("IDOTSERVICIO")
                                Dgv_Equipos.Rows(IndiceFilaseleccionada).Cells(11).Value = FilaServicioBusqueda("IDORDENTRABAJO")
                                Dgv_Equipos.Rows(IndiceFilaseleccionada).Cells(12).Value = FilaServicioBusqueda("SERVICIO")
                            Next
                        Else
                            MsgBox("Debe especificar primero el equipo")
                        End If
                End Select
            Case Windows.Forms.Keys.Delete

                Try
                    If Me.Dgv_Equipos.SelectedRows Is Nothing Then Exit Sub

                    Dim selectedRowCount As Integer = Dgv_Equipos.Rows.GetRowCount(DataGridViewElementStates.Selected)
                    For I As Integer = 0 To selectedRowCount - 1
                        Me.Dgv_Equipos.Rows.Remove(Dgv_Equipos.SelectedRows(0))
                    Next
                Catch
                End Try

                Try
                    TEquipos.AcceptChanges() 'LISTAITEMREQUISICION
                Catch
                End Try

                For x As Integer = 0 To TEquipos.Rows.Count - 1
                    If Not IsDBNull(TEquipos.Rows(x).Item(0)) Then 'LISTAITEMREQUISICION
                        TEquipos.Rows(x).Item(0) = x + 1 'LISTAITEMREQUISICION
                    End If
                Next

                ELiminarFilaVacia("E")
        End Select
    End Sub

    Private Sub Dgv_Equipos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Equipos.CellValueChanged
        CalcularTotalEquipo()
    End Sub

    Private Function ValidarItemsRDEquipo(ByVal CODIGOEQUIPO As String, ByVal Orden As Integer) As Boolean
        Dim filas As DataRow()
        If Orden = -1 Then
            filas = TEquipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "'") 'LISTAITEMREQUISICION
        Else
            filas = TEquipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "' AND ORDEN<>" + Orden.ToString) 'LISTAITEMREQUISICION
        End If
        If filas.Length > 0 Then
            ValidarItemsRDEquipo = False
            Exit Function
        End If
        ValidarItemsRDEquipo = True
    End Function

    Private Function Validar_ValoresListaEquipos() As Boolean
        Dim ValidarTotal As Boolean = True
        Try
            Me.Dgv_Equipos.SuspendLayout()
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer
            'Cuando el valor no es valido
            Dim Estilo_Celda_Error As New DataGridViewCellStyle
            Estilo_Celda_Error.BackColor = Color.Red
            'Cuando no corresponde con la convenció
            Dim Estilo_Celda_convención As New DataGridViewCellStyle
            Estilo_Celda_convención.BackColor = Color.Khaki
            Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
            Estilo_Celda_ValorFuera.BackColor = Color.Indigo
            'Cuando esta bien
            Dim Estilo_Celda As New DataGridViewCellStyle
            Estilo_Celda.BackColor = Color.White
            For i = 0 To Me.Dgv_Equipos.RowCount - 2
                Dim Validar As Boolean = True
                With Dgv_Equipos
                    Dim IDEQUIPO As Integer = .Rows(i).Cells("DGVTBC_IDEQUIPO").Value
                    Dim TOTAL As String = Trim((.Rows(i).Cells("DGVTBC_TOTALEQUIPO").Value).ToString)
                    Dim INICIAL As String = Trim((.Rows(i).Cells("DGVTBC_INICIAL").Value).ToString)
                    Dim FINAL As String = Trim((.Rows(i).Cells("DGVTBC_FINAL").Value).ToString)
                    Dim DIS As String = Trim((.Rows(i).Cells("DGVCBC_DISPONIBLE").Value).ToString)
                    Dim VAR As String = Trim((.Rows(i).Cells("DGVCBC_VARADO").Value).ToString)

                    TOTAL = IIf(IsDBNull(TOTAL), "", TOTAL)
                    INICIAL = IIf(IsDBNull(INICIAL), "", INICIAL)
                    FINAL = IIf(IsDBNull(FINAL), "", FINAL)
                    DIS = IIf(IsDBNull(DIS), "", DIS)
                    VAR = IIf(IsDBNull(VAR), "", VAR)

                    .Rows(i).DefaultCellStyle = Estilo_Celda
                    .Rows(i).ErrorText = ""
                    If ValidarConvencionesEquipos(TOTAL, "TOTAL") = False Then
                        Validar = False
                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                        .Rows(i).ErrorText = "TOTAL no contiene un valor valido"
                    Else
                        If ValidarConvencionesEquipos(INICIAL, "INICIAL") = False Then
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                            .Rows(i).ErrorText = "INICIAL no contiene un valor valido"
                        Else
                            If ValidarConvencionesEquipos(FINAL, "FINAL") = False Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "FINAL no contiene un valor valido"
                            Else
                                If ValidarConvencionesEquipos(DIS, "DIS") = False Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                    .Rows(i).ErrorText = "DISPONIBLE no contiene un valor valido"
                                Else
                                    If ValidarConvencionesEquipos(VAR, "VAR") = False Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "VARADO no contiene un valor valido"
                                    End If
                                End If
                            End If
                        End If
                    End If


                    If Validar = True Then
                        If TOTAL = "T" Then
                            If INICIAL <> "" Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "INICIAL debe estar en blanco"
                            Else
                                If FINAL <> "" Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                    .Rows(i).ErrorText = "FINAL debe estar en blanco"
                                Else
                                    If DIS <> "N" Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "DISPONIBLE debe estar en blanco"
                                    Else
                                        If VAR <> "N" Then
                                            Validar = False
                                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                            .Rows(i).ErrorText = "VARADO debe estar en blanco"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If Validar = True Then
                        If VAR = "S" Then
                            If DIS <> "N" Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "DISPONIBLE debe estar en blanco"
                            Else
                                If TOTAL <> "" Then
                                    If TOTAL <> "0" Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "TOTAL debe ser 0"
                                    End If
                                Else
                                    If INICIAL <> FINAL Then
                                        If FINAL <> "" Then
                                            Validar = False
                                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                            .Rows(i).ErrorText = "FINAL e INICIAL deben tener el mismo valor"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If Validar = True Then
                        If DIS = "S" Then
                            If VAR <> "N" Then
                                Validar = False
                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                .Rows(i).ErrorText = "VARADO debe estar en blanco"
                            Else
                                If TOTAL <> "" Then
                                    If TOTAL <> "0" Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "TOTAL debe ser 0"
                                    End If
                                Else
                                    If INICIAL <> FINAL Then
                                        If FINAL <> "" Then
                                            Validar = False
                                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                            .Rows(i).ErrorText = "FINAL e INICIAL deben tener el mismo valor"
                                        End If
                                    End If
                                End If
                            End If

                        End If
                    End If

                    If Validar = True Then
                        If IsDBNull(TOTAL) = True Then
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                            .Rows(i).ErrorText = "TOTAL no puede ser vacio"
                        Else
                            If TOTAL <> "T" Then
                                If TOTAL <> "" Then
                                    If CInt(TOTAL) < 0 Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "TOTAL no puede ser negativo"
                                    Else
                                        If TOTAL <> 0 Then
                                            If IsDBNull(INICIAL) = True Then
                                                Validar = False
                                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                .Rows(i).ErrorText = "INICIAL no puede estar vacio"
                                            Else
                                                If IsNumeric(INICIAL) = False Then
                                                    Validar = False
                                                    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                    .Rows(i).ErrorText = "INICIAL debe ser numerico"
                                                Else
                                                    If IsDBNull(FINAL) = True Then
                                                        Validar = False
                                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                        .Rows(i).ErrorText = "FINAL no puede estar vacio"
                                                    Else
                                                        If IsNumeric(FINAL) = False Then
                                                            Validar = False
                                                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                            .Rows(i).ErrorText = "FINAL deber ser numerico"
                                                        Else
                                                            If CInt(TOTAL) <> CInt(FINAL) - CInt(INICIAL) Then
                                                                Validar = False
                                                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                                .Rows(i).ErrorText = "TOTAL debe ser igual a la diferencia entre INICIAL y FINAL"
                                                            Else
                                                                If CInt(FINAL) < CInt(INICIAL) Then
                                                                    Validar = False
                                                                    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                                    .Rows(i).ErrorText = "FINAL no puede ser menor al INICIAL"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else 'TOTAL ES CERO
                                            If IsDBNull(INICIAL) = False Then
                                                If IsDBNull(FINAL) = False Then
                                                    If IsNumeric(INICIAL) = True Then
                                                        If IsNumeric(FINAL) = True Then
                                                            If CInt(FINAL) - CInt(INICIAL) <> 0 Then
                                                                Validar = False
                                                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                                .Rows(i).ErrorText = "TOTAL no es valido"
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Else 'total=""
                                    If VAR = "N" And DIS = "N" Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "TOTAL no es valido proque VARADO esta vacio al igual que DISPONIBLE"
                                    Else
                                        If INICIAL <> "" Then
                                            Validar = False
                                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                            .Rows(i).ErrorText = "TOTAL no es valido porque INICIAL tiene un valor"
                                        Else
                                            If FINAL <> "" Then
                                                Validar = False
                                                .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                                .Rows(i).ErrorText = "TOTAL no es valido porque FINAL tiene un valor"
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If Validar = True Then
                        'validar VARADO vs TOTAL vs DISPONIBLE cuan VAR es numerico
                        If IsDBNull(VAR) = False Then
                            If IsNumeric(VAR) = True Then ' tiena algun valor en varado
                                If IsDBNull(TOTAL) = True Then
                                    Validar = False
                                    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                    .Rows(i).ErrorText = "TOTAL no es valido porque VARADO tiene un valor"
                                Else
                                    If IsNumeric(TOTAL) = False Then
                                        Validar = False
                                        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                        .Rows(i).ErrorText = "TOTAL no es valido porque VARADO tiene un valor"
                                    Else
                                        If CInt(TOTAL) < 1 Then
                                            Validar = False
                                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                            .Rows(i).ErrorText = "TOTAL no es puede ser negativo"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If


                End With
                If ValidarTotal = True Then
                    Me.Tc_Recursos.SelectedIndex = 2
                End If
                ValidarTotal = Validar

            Next


            Me.Enabled = True
            Me.Cursor = Cursors.Default
            Me.Dgv_ListaPersonas.ResumeLayout()
            'Validar que el total no sea mayor a 12
        Catch ex As Exception
            MsgBox(ex.ToString)
            ValidarTotal = False
            Me.Lb_errores_integrantes.Text = "Error al intentar validar los equipos"
            Me.Lb_errores_integrantes.Visible = True
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Validar_ValoresListaEquipos = ValidarTotal
    End Function

    Public Function ValidarConvencionesEquipos(ByVal convención As String, ByVal Columna As String) As Boolean
        Dim validar As Boolean = False
        Select Case Columna
            Case "TOTAL"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "T" Or convención = "" Then
                        validar = True
                    End If
                End If
            Case "INICIAL", "FINAL"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "" Then
                        validar = True
                    End If
                End If

            Case "DIS"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "S" Or convención = "N" Then
                        validar = True
                    End If
                End If
            Case "VAR"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "S" Or convención = "N" Then
                        validar = True
                    End If
                End If
        End Select
        ValidarConvencionesEquipos = validar
    End Function

    Private Sub CalcularTotalEquipo()
        Try
            Dim j As Integer = Me.Dgv_Equipos.CurrentCell.ColumnIndex
            Select Case j
                Case 5, 6
                    Dim i As Integer = Me.Dgv_Equipos.CurrentRow.Index
                    With Dgv_Equipos
                        Dim TOTAL As String = Trim((.Rows(i).Cells("DGVTBC_TOTALEQUIPO").Value).ToString)
                        Dim INICIAL As String = Trim((.Rows(i).Cells("DGVTBC_INICIAL").Value).ToString)
                        Dim FINAL As String = Trim((.Rows(i).Cells("DGVTBC_FINAL").Value).ToString)
                        Dim DIS As String = Trim((.Rows(i).Cells("DGVCBC_DISPONIBLE").Value).ToString)
                        Dim VAR As String = Trim((.Rows(i).Cells("DGVCBC_VARADO").Value).ToString)
                        Try
                            If CInt(FINAL) >= CInt(INICIAL) Then
                                If CInt(FINAL) >= 0 Then
                                    If CInt(INICIAL) >= 0 Then
                                        .Rows(i).Cells("DGVTBC_TOTALEQUIPO").Value = (CInt(FINAL) - CInt(INICIAL)).ToString
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            .Rows(i).Cells("DGVTBC_TOTALEQUIPO").Value = TOTAL
                        End Try
                    End With
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgv_Equipos_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgv_Equipos.CellFormatting
        If e.ColumnIndex >= 1 And e.ColumnIndex < 8 Then
            e.CellStyle.BackColor = Color.Beige
        Else
            If e.ColumnIndex > 7 And e.ColumnIndex < 13 Then
                e.CellStyle.BackColor = Color.AliceBlue
            End If
        End If
    End Sub

#End Region

#Region "Pestaña Actividades"

    Private Sub Dgv_Actividades_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Actividades.CellValueChanged
        Try
            '
            If e.ColumnIndex = 5 Then
                '      ' Valor actual de la celda
                Dim value As String = Dgv_Actividades.CurrentCell. _
                EditedFormattedValue.ToString
                ' Reemplazamos el punto por la coma decimal.
                value = value.Replace(".", ",")
                ' Escribimos el nuevo valor.
                Dim cellValue As Decimal = CType(value, Decimal)
                Dgv_Actividades.CurrentCell.Value = cellValue
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Dgv_Actividades_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Actividades.KeyDown

        Dim selectedRowCount1 As Integer = Dgv_Actividades.CurrentCell.ColumnIndex
        Select Case selectedRowCount1
            Case 2
                If e.KeyCode = Windows.Forms.Keys.F3 Then
                    Dim FrBuscarServicioOTSAP As New Fr_BuscarServicioOTSAP
                    Dim IndiceFilaseleccionada As Integer = Dgv_Actividades.CurrentRow.Index
                    FrBuscarServicioOTSAP.tablaunidades = tablaunidades
                    FrBuscarServicioOTSAP._Tipo = "A"
                    FrBuscarServicioOTSAP.TipoBusqueda = "S"
                    FrBuscarServicioOTSAP.Cargar_Tabla("A")
                    FrBuscarServicioOTSAP.ShowDialog()
                    If FrBuscarServicioOTSAP.TablaServicios.Rows.Count = 0 Then
                        Exit Sub
                    Else
                        For j = 0 To FrBuscarServicioOTSAP.TablaServicios.Rows.Count - 1
                            Dim FilaServicioBusqueda As DataRow
                            FilaServicioBusqueda = FrBuscarServicioOTSAP.TablaServicios.Rows(j)
                            If ValidarItemsServicios(FilaServicioBusqueda("IDOTSERVICIO")) Then
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TActividades.NewRow
                                NuevaFilaItem("IDOTSERVICIO") = FilaServicioBusqueda("IDOTSERVICIO")
                                NuevaFilaItem("IDORDENTRABAJO") = FilaServicioBusqueda("IDORDENTRABAJO")
                                NuevaFilaItem("SERVICIO") = FilaServicioBusqueda("SERVICIO")
                                NuevaFilaItem("DESCRIPCION") = FilaServicioBusqueda("NOMBRESERVICIO")
                                NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaServicioBusqueda("CODIGOTIPOUNIDAD")
                                NuevaFilaItem("AVANCE") = 0
                                NuevaFilaItem("CODIGOPOBLACION") = FilaServicioBusqueda("CODIGOPOBLACION")
                                NuevaFilaItem("IDCLASEATENCION") = FilaServicioBusqueda("IDCLASEATENCION")
                                TActividades.Rows.Add(NuevaFilaItem)
                                ELiminarFilaVacia("A")
                            Else
                                MsgBox("El servicio que desea agregar ya se encuentra en la lista", MsgBoxStyle.Information, "REPETIDO")
                            End If
                        Next
                    End If
                ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then 'SI PRESIONA PARA ELIMINAR FILA
                    Try
                        If Me.Dgv_Actividades.SelectedRows Is Nothing Then Exit Sub

                        Dim selectedRowCount As Integer = Dgv_Actividades.Rows.GetRowCount(DataGridViewElementStates.Selected)
                        For I As Integer = 0 To selectedRowCount - 1
                            Me.Dgv_Actividades.Rows.Remove(Dgv_Actividades.SelectedRows(0))
                        Next
                    Catch
                    End Try
                    Try
                        TActividades.AcceptChanges() 'LISTAITEMREQUISICION
                    Catch
                    End Try
                    ELiminarFilaVacia("A")
                End If
        End Select

    End Sub

    Private Function ValidarItemsServicios(ByVal IDOTSERVICIO As Integer) As Boolean
        Dim filas As DataRow()
        filas = TActividades.Select("IDOTSERVICIO=" + IDOTSERVICIO.ToString)
        If filas.Length > 0 Then
            ValidarItemsServicios = False
            Exit Function
        End If
        ValidarItemsServicios = True
    End Function

    Private Sub Dgv_Actividades_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles Dgv_Actividades.UserDeletingRow
        'Preguntar antes de eliminar el registro de actividad
        If MsgBox("¿Seguro que desea eliminar la actividad seleccionada?", MsgBoxStyle.YesNo, "Eliminar Actividad") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Function Validar_ValoresListaActividades() As Boolean
        Dim Validar As Boolean = True
        Try
            Me.Dgv_Equipos.SuspendLayout()
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer
            'Cuando el valor no es valido
            Dim Estilo_Celda_Error As New DataGridViewCellStyle
            Estilo_Celda_Error.BackColor = Color.Red
            'Cuando no corresponde con la convenció
            Dim Estilo_Celda_convención As New DataGridViewCellStyle
            Estilo_Celda_convención.BackColor = Color.Khaki
            Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
            Estilo_Celda_ValorFuera.BackColor = Color.Indigo
            'Cuando esta bien
            Dim Estilo_Celda As New DataGridViewCellStyle
            Estilo_Celda.BackColor = Color.White
            For i = 0 To Me.Dgv_Actividades.RowCount - 1
                With Dgv_Actividades
                    Dim AVANCE As String = (.Rows(i).Cells("DGVTBC_AVANCE").Value).ToString
                    .Rows(i).DefaultCellStyle = Estilo_Celda
                    .Rows(i).ErrorText = ""

                    If IsDBNull(AVANCE) = False Then
                        'verificar que es numerico
                        If IsNumeric(AVANCE) = False Then
                            Validar = False
                            .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                            .Rows(i).ErrorText = "AVANCE no es valido"
                        End If
                    Else
                        Validar = False
                        .Rows(i).DefaultCellStyle = Estilo_Celda_Error
                        .Rows(i).ErrorText = "AVANCE debe tener algún valor"
                    End If
                End With
            Next
            Me.Enabled = True
            Me.Cursor = Cursors.Default
            Me.Dgv_ListaPersonas.ResumeLayout()
            'Validar que el total no sea mayor a 12
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Validar_ValoresListaActividades = Validar
    End Function

#End Region

#Region "Pestaña Articulos"

    Private Sub Dgv_Articulos_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Articulos.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3
                CargandoFormulario = False
                Dim selectedColumna As Integer = Dgv_Articulos.CurrentCell.ColumnIndex
                Select Case selectedColumna 'Buscar persona
                    Case 0
                        BuscarItems()
                    Case 8 'buscar servicio
                        Dim IndiceFilaseleccionada As Integer = Dgv_Articulos.CurrentRow.Index
                        If IsDBNull(Dgv_Articulos.Rows(IndiceFilaseleccionada).Cells(2).Value) = False Then
                            If IsNothing(Dgv_Articulos.Rows(IndiceFilaseleccionada).Cells(2).Value) = False Then
                                Dim FrBuscarServicioOTSAP As New Fr_BuscarServicioOTSAP
                                FrBuscarServicioOTSAP.tablaunidades = tablaunidades
                                FrBuscarServicioOTSAP._Tipo = "A"
                                FrBuscarServicioOTSAP.TipoBusqueda = "A"
                                FrBuscarServicioOTSAP.Cargar_Tabla("A")
                                FrBuscarServicioOTSAP.ShowDialog()
                                For j = 0 To FrBuscarServicioOTSAP.TablaServicios.Rows.Count - 1
                                    Dim FilaServicioBusqueda As DataRow
                                    FilaServicioBusqueda = FrBuscarServicioOTSAP.TablaServicios.Rows(j)
                                    Dgv_Articulos.Rows(IndiceFilaseleccionada).Cells(6).Value = FilaServicioBusqueda("IDOTSERVICIO")
                                    Dgv_Articulos.Rows(IndiceFilaseleccionada).Cells(7).Value = FilaServicioBusqueda("IDORDENTRABAJO")
                                    Dgv_Articulos.Rows(IndiceFilaseleccionada).Cells(8).Value = FilaServicioBusqueda("SERVICIO")
                                Next
                            Else
                                MsgBox("Debe seleccionar primero el articulo")
                            End If
                        End If
                End Select
            Case Windows.Forms.Keys.Delete
                Try
                    If MsgBox("¿Seguro que desea elimina el registro?", MsgBoxStyle.YesNo, "Borrar Registro") = MsgBoxResult.Yes Then
                        Me.Dgv_Articulos.Rows.RemoveAt(Me.Dgv_Articulos.CurrentCell.RowIndex)
                    End If
                Catch ex As Exception
                End Try

                Try
                    TArticulos.AcceptChanges()
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub Dgv_Articulos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Articulos.CellEndEdit
        Try
            If IsDBNull(Me.Dgv_Articulos.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_Articulos.Item(e.ColumnIndex, e.RowIndex).Value = DBNull.Value
            End If
            If IsDBNull(Me.Dgv_Articulos.Item(0, e.RowIndex).Value) = True Then
                'If e.RowIndex > 0 Then
                '    Me.Dgv_Articulos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                '    Me.Dgv_Articulos.Rows(e.RowIndex).ErrorText = ""
                'Else
                Try
                    Me.Dgv_Articulos.Rows.RemoveAt(e.RowIndex)
                    ELiminarFilaVacia("M")
                Catch
                End Try
                ' End If
                Exit Sub
            End If

            If Trim(Me.Dgv_Articulos.Item(0, e.RowIndex).Value) = "" Then
                'If e.RowIndex > 0 Then
                '    Me.Dgv_Articulos.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                '    Me.Dgv_Articulos.Rows(e.RowIndex).ErrorText = ""
                'Else
                Try
                    Me.Dgv_Articulos.Rows.RemoveAt(e.RowIndex)
                    ELiminarFilaVacia("M")
                Catch
                End Try
                ' End If
                Exit Sub
            End If

            Dim IDARTICULO As Integer = -1
            Dim ITEM As Integer = -1
            If Not IsDBNull(Me.Dgv_Articulos.Item(Col_IdArticulo.Name, e.RowIndex).Value) Then
                IDARTICULO = Me.Dgv_Articulos.Item(Col_IdArticulo.Name, e.RowIndex).Value
            End If
            Dim CANTIDAD As Double = -1
            If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value) Then
                CANTIDAD = Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value
            End If

            'Validar Artículo
            Select Case e.ColumnIndex
                Case Dgv_Articulos.Columns(Col_IdArticulo.Name).Index '1
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

                            NuevaFilaItem = TArticulos.NewRow 'LISTAITEMREQUISICION

                            NuevaFilaItem("IDARTICULO") = IDARTICULO
                            NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                            NuevaFilaItem("VALORUNITARIO") = FilaArticulo("VALORREFERENCIA")
                            NuevaFilaItem("CANTIDAD") = 0
                            NuevaFilaItem("VALORTOTAL") = 0
                            NuevaFilaItem("IDTIPOCLASIFICACIONMATERIAL") = 0
                            NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBREDESCRIPTIVO"))
                            If TArticulos.Rows.Count = Me.Dgv_Articulos.CurrentCell.RowIndex Then 'LISTAITEMREQUISICION
                                Try
                                    Me.Dgv_Articulos.Rows.RemoveAt(e.RowIndex)
                                Catch
                                End Try
                                TArticulos.Rows.Add(NuevaFilaItem) 'LISTAITEMREQUISICION
                            Else
                                TArticulos.Rows(e.RowIndex).Item("IDARTICULO") = NuevaFilaItem("IDARTICULO") 'LISTAITEMREQUISICION
                                TArticulos.Rows(e.RowIndex).Item("CODIGOTIPOUNIDAD") = NuevaFilaItem("CODIGOTIPOUNIDAD") 'LISTAITEMREQUISICION
                                TArticulos.Rows(e.RowIndex).Item("VALORUNITARIO") = NuevaFilaItem("VALORUNITARIO") 'LISTAITEMREQUISICION
                                TArticulos.Rows(e.RowIndex).Item("CANTIDAD") = NuevaFilaItem("CANTIDAD") 'LISTAITEMREQUISICION
                                TArticulos.Rows(e.RowIndex).Item("VALORTOTAL") = NuevaFilaItem("VALORTOTAL") 'LISTAITEMREQUISICION
                                TArticulos.Rows(e.RowIndex).Item("IDTIPOCLASIFICACIONMATERIAL") = NuevaFilaItem("IDTIPOCLASIFICACIONMATERIAL") 'LISTAITEMREQUISICION
                                TArticulos.Rows(e.RowIndex).Item("NOMBREDESCRIPTIVO") = NuevaFilaItem("NOMBREDESCRIPTIVO") 'LISTAITEMREQUISICION

                            End If
                        Else
                            'No existe un artículo con este código
                            MensajeError = "No se encontró un artículo con ese código"
                            MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                            Try
                                Me.TArticulos.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                        End If
                    Else
                        MensajeError = "El item que desea ingresar, ya se encuentra incluido en la lista"
                        MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                        Try
                            Me.TArticulos.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                    End If
                Case Dgv_Articulos.Columns(DGVTBC_VALORUNITARIO.Name).Index, Dgv_Articulos.Columns(DGVTBC_CANTIDADARTICULO.Name).Index

                    Dim VALORUNITARIO As Decimal
                    Dim CANTIDAD1 As Decimal

                    If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_VALORUNITARIO.Name, e.RowIndex).Value) Then
                        VALORUNITARIO = Me.Dgv_Articulos.Item(DGVTBC_VALORUNITARIO.Name, e.RowIndex).Value
                    End If
                    If Not IsDBNull(Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value) Then
                        CANTIDAD1 = Me.Dgv_Articulos.Item(DGVTBC_CANTIDADARTICULO.Name, e.RowIndex).Value
                    End If
                    Me.Dgv_Articulos.Item(DGVTBC_VALORTOTALARTICULO.Name, e.RowIndex).Value = VALORUNITARIO * CANTIDAD1
            End Select
            ELiminarFilaVacia("M")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function ValidarItemsArticulos(ByVal IdArticulo As Integer, ByVal ItemLista As Integer) As Boolean
        Dim filas As DataRow()
        filas = TArticulos.Select("IDARTICULO=" + IdArticulo.ToString)

        If filas.Length > 0 Then
            ValidarItemsArticulos = False
            Exit Function
        End If
        ValidarItemsArticulos = True
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


#End Region

#Region "Pestaña Costos Indirectos"


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
            ELiminarFilaVacia("C")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgv_ListaCostosIndirectos_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_ListaCostosIndirectos.KeyDown
        CargandoFormulario = False
        Dim selectedColumna As Integer = Dgv_ListaCostosIndirectos.CurrentCell.ColumnIndex

        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3
                Select Case selectedColumna
                    Case 0 'buscar costo indirecto
                        Dim IndiceFilaseleccionada As Integer = Dgv_ListaCostosIndirectos.CurrentRow.Index
                        Dim fr_buscar As New Fr_Búsqueda
                        fr_buscar.Tipo = "C"
                        fr_buscar.ComboBox_Filtrar.Items.Add("Orden Sap")
                        fr_buscar.ComboBox_Filtrar.Items.Add("Nombre")
                        fr_buscar.ComboBox_Filtrar.Items.Add("Objeto")
                        If Idbase = 121 Or Idbase = 122 Or Idbase = 123 Or Idbase = 124 Or Idbase = 125 Then
                            fr_buscar.ComboBox_Filtrar.Items.Add("Cod. Ismocol")
                        End If
                        fr_buscar.ShowDialog()
                        If fr_buscar.Resultado <> -1 Then
                            'Dim filas() As DataRow
                            'filas = TCostosIndirectos.Select("IDCOSTOINDIRECTO=" + fr_buscar.Resultado.ToString)
                            'If filas.Count = 0 Then
                            Dim NuevaFilaItem As DataRow
                            NuevaFilaItem = TCostosIndirectos.NewRow
                            NuevaFilaItem(0) = fr_buscar.Resultado
                            NuevaFilaItem(1) = fr_buscar.Resultado1
                            NuevaFilaItem(2) = fr_buscar.Resultado2
                            NuevaFilaItem(8) = fr_buscar.Resultado3
                            NuevaFilaItem(9) = fr_buscar.Resultado4
                            TCostosIndirectos.Rows.Add(NuevaFilaItem) '
                            'Else
                            '    MsgBox("El servicio que intenta agregar ya se encuentra en el reporte", MsgBoxStyle.Information, "Costo ya relacionado")
                            'End If

                        End If
                    Case 7 'buscar servicio
                        Dim IndiceFilaseleccionada As Integer = Dgv_ListaCostosIndirectos.CurrentRow.Index
                        If IsDBNull(Dgv_ListaCostosIndirectos.Rows(IndiceFilaseleccionada).Cells(0).Value) = False Then
                            If IsNothing(Dgv_ListaCostosIndirectos.Rows(IndiceFilaseleccionada).Cells(0).Value) = False Then
                                Dim FrBuscarServicioOTSAP As New Fr_BuscarServicioOTSAP
                                FrBuscarServicioOTSAP.tablaunidades = tablaunidades
                                FrBuscarServicioOTSAP._Tipo = "A"
                                FrBuscarServicioOTSAP.TipoBusqueda = "C"
                                FrBuscarServicioOTSAP.Cargar_Tabla("A")
                                FrBuscarServicioOTSAP.ShowDialog()
                                For j = 0 To FrBuscarServicioOTSAP.TablaServicios.Rows.Count - 1
                                    Dim FilaServicioBusqueda As DataRow
                                    FilaServicioBusqueda = FrBuscarServicioOTSAP.TablaServicios.Rows(j)
                                    Dgv_ListaCostosIndirectos.Rows(IndiceFilaseleccionada).Cells(5).Value = FilaServicioBusqueda("IDOTSERVICIO")
                                    Dgv_ListaCostosIndirectos.Rows(IndiceFilaseleccionada).Cells(6).Value = FilaServicioBusqueda("IDORDENTRABAJO")
                                    Dgv_ListaCostosIndirectos.Rows(IndiceFilaseleccionada).Cells(7).Value = FilaServicioBusqueda("SERVICIO")
                                Next
                            Else
                                MsgBox("Debe digitar primero el nombre del servicio indirecto")
                            End If
                        Else
                            MsgBox("Debe digitar primero el nombre del servicio indirecto")
                        End If

                End Select

            Case Windows.Forms.Keys.Delete
                Try
                    If MsgBox("¿Seguro que desea eliminar el registro?", MsgBoxStyle.YesNo, "Borrar Registro") = MsgBoxResult.Yes Then
                        Me.Dgv_ListaCostosIndirectos.Rows.RemoveAt(Me.Dgv_ListaCostosIndirectos.CurrentCell.RowIndex)
                    End If
                Catch ex As Exception
                End Try
                Try
                    TCostosIndirectos.AcceptChanges()
                Catch ex As Exception
                End Try
        End Select
        ELiminarFilaVacia("C")
    End Sub


#End Region


#Region "Pendiente revisar"

    Public Function ValidarValorIngresado(ByVal Valor As String, ByVal Columna As String, ByVal indice As Integer) As Boolean
        'Cuando el valor no es valido
        Dim Estilo_Celda_Error As New DataGridViewCellStyle
        Estilo_Celda_Error.BackColor = Color.Red
        'Cuando no corresponde con la convenció
        Dim Estilo_Celda_convención As New DataGridViewCellStyle
        Estilo_Celda_convención.BackColor = Color.Khaki
        Dim Estilo_Celda_ValorFuera As New DataGridViewCellStyle
        Estilo_Celda_ValorFuera.BackColor = Color.Indigo
        'Cuando esta bien
        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Dim validar As Boolean = True
        If IsDBNull(Valor) = False Then
            'Verificar que es numerico
            If Trim(Valor) <> "" Then
                If IsNumeric(Valor) = False Then
                    validar = False
                    Dgv_ListaPersonas.Rows(indice).DefaultCellStyle = Estilo_Celda_Error
                    Dgv_ListaPersonas.Rows(indice).ErrorText = Columna + " debe ser Numérico"
                Else
                    If ValidarValores(Valor) = False Then
                        validar = False
                        Dgv_ListaPersonas.Rows(indice).DefaultCellStyle = Estilo_Celda_ValorFuera
                        Dgv_ListaPersonas.Rows(indice).ErrorText = Columna + " no esta dentro del rango permitido"
                    End If
                End If
            End If
        End If
        ValidarValorIngresado = validar
    End Function

    Private Function ValidarValores(ByVal Valor As String) As Boolean
        Dim validar As Boolean = True
        If CInt(Valor) > 24 Then
            validar = False
        End If
        ValidarValores = validar
    End Function

    Public Sub CerrarReporte()
        Dim cerrar As Boolean = True
        If ValidarReporteDiario() = False Then
            Exit Sub
        End If
        If Validar_ValoresListaIntegrantes() = False Then
            cerrar = False
        Else
            If Validar_ValoresListaEquipos() = False Then
                cerrar = False
            Else
                If Validar_ValoresListaActividades() = False Then
                    cerrar = False
                End If
            End If
        End If

        ''validar si se puede cerrar
        'Dim adapvalidar As New DatosReporteDiario.Ds_ModificarReporteDiarioTableAdapters.REPORTEDIARIOPENDIENTESTableAdapter
        'If FuncionesBase.FuncionesBase.ValidarCierreReporte(ReporteDIariomodificando) = 0 Then
        '    If cerrar = True Then
        '        adapvalidar.CAMBIARESTADO("S", ReporteDIariomodificando, VariablesBase.VariablesBase.IdProyecto)
        '    End If
        'End If
        'Me.Close()

    End Sub


#End Region

    Public EDITANDO As Boolean

    Private Sub BuscarItems()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo.FiltrarxOM = True
        'crear tabla con los ID de OM registradas en las diferentes pestañas
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Familia = -1
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar

        Dim TablaOM As New DataTable("OM")
        TablaOM.Columns.Add("IDOTSERVICIO", System.Type.GetType("System.Int32"))

        For i = 0 To TPersonas.Rows.Count - 1
            If IsDBNull(TPersonas.Rows(i).Item("IDOTSERVICIO")) = False Then
                Dim fila As DataRow
                fila = TablaOM.NewRow
                fila("IDOTSERVICIO") = TPersonas.Rows(i).Item("IDOTSERVICIO")
                TablaOM.Rows.Add(fila)
            End If
        Next
        'TEquipos()
        For i = 0 To TEquipos.Rows.Count - 1

            If IsDBNull(TEquipos.Rows(i).Item("IDOTSERVICIO")) = False Then
                Dim fila As DataRow
                fila = TablaOM.NewRow
                fila("IDOTSERVICIO") = TEquipos.Rows(i).Item("IDOTSERVICIO")
                TablaOM.Rows.Add(fila)
            End If

        Next
        'TActividades()
        For i = 0 To TActividades.Rows.Count - 1
            If IsDBNull(TActividades.Rows(i).Item("IDOTSERVICIO")) = False Then
                Dim fila As DataRow
                fila = TablaOM.NewRow
                fila("IDOTSERVICIO") = TActividades.Rows(i).Item("IDOTSERVICIO")
                TablaOM.Rows.Add(fila)
            End If
        Next
        'TArticulos()
        For i = 0 To TArticulos.Rows.Count - 1

            If IsDBNull(TArticulos.Rows(i).Item("IDOTSERVICIO")) = False Then
                Dim fila As DataRow
                fila = TablaOM.NewRow
                fila("IDOTSERVICIO") = TArticulos.Rows(i).Item("IDOTSERVICIO")
                TablaOM.Rows.Add(fila)
            End If
        Next

        Dim dtSinRepetidos As New DataTable
        dtSinRepetidos = TablaOM.DefaultView.ToTable(True, "IDOTSERVICIO")

        FrBuscarArtículo.TablaOM = dtSinRepetidos

        Windows.Forms.Cursor.Current = Cursors.Default
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
                NuevaFilaItem = TArticulos.NewRow 'LISTAITEMREQUISICION
                NuevaFilaItem("IDARTICULO") = FrBuscarArtículo.IdArtículo.ToString
                NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                NuevaFilaItem("VALORUNITARIO") = FilaArticulo("VALORREFERENCIA")
                NuevaFilaItem("CANTIDAD") = 0
                NuevaFilaItem("VALORTOTAL") = 0
                NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBREDESCRIPTIVO"))
                TArticulos.Rows.Add(NuevaFilaItem)

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
        filas = TArticulos.Select("IDARTICULO=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItems = False
            Exit Function
        End If
        ValidarItems = True
    End Function


    Private Sub Bt_AgregarPersonal_Click(sender As Object, e As EventArgs) Handles Bt_AgregarPersonal.Click
        Dim filasintegrantes As DataRow()
        filasintegrantes = TIntegrantes.Select("IDCUADRILLA=" + Me.Cb_Cuadrilla.SelectedValue.ToString)
        For i = 0 To filasintegrantes.Count - 1
            Dim filaintegrante As DataRow
            filaintegrante = filasintegrantes(i)

            Dim filas As DataRow()
            filas = TPersonas.Select("CODIGOCONTRATO=" + filaintegrante("CODIGOCONTRATO").ToString)

            If filas.Length = 0 Then
                Dim NuevaFilaItem As DataRow
                NuevaFilaItem = TPersonas.NewRow
                NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                NuevaFilaItem("IDPERSONA") = filaintegrante("IDPERSONA")
                NuevaFilaItem("IDCONTRATO") = filaintegrante("IDCONTRATO")
                NuevaFilaItem("CODIGOCONTRATO") = filaintegrante("CODIGOCONTRATO")
                NuevaFilaItem("NOMBREPERSONA") = filaintegrante("NOMBREPERSONA")
                NuevaFilaItem("CODIGOTIPOSALARIO") = filaintegrante("CODIGOTIPOSALARIO")
                NuevaFilaItem("CODIGOTIPOCATEGORIAPERSONAL") = filaintegrante("CODIGOTIPOCATEGORIAPERSONAL")
                NuevaFilaItem("CODIGOTIPOCARGO") = filaintegrante("CODIGOTIPOCARGO")
                NuevaFilaItem("IDTIPORECURSO") = filaintegrante("IDTIPORECURSO")
                TPersonas.Rows.Add(NuevaFilaItem) '
            End If
        Next
    End Sub

    Private Sub Ll_Agregardesdeportapapeles_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lk_AgregarPortapapelesPersonal.LinkClicked
        Me.Cursor = Cursors.WaitCursor

        Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
        Dim words() As String = Clipboard.GetText().Split(delimiterChars)
        For i = 0 To words.Length - 1
            Dim line As String
            line = Replace(LTrim(RTrim(words(i))), vbLf, "")
            If IsNothing(line) = False Then
                If line.Length > 0 Then
                    Try
                        Dim FilasContratos As DataRow()
                        Dim contratos As New DataTable()
                        Dim Cadena_Consulta As String = "SELECT * FROM dbo.DetalleContrato(" & line & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                        Dim Consulta As New SqlCommand(Cadena_Consulta)
                        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Consulta.Connection = Conexión
                        Dim Adaptador As New SqlDataAdapter(Consulta)
                        Consulta.Connection.Open()
                        Adaptador.Fill(contratos)
                        Consulta.Connection.Close()
                        FilasContratos = contratos.Select("CODIGOCONTRATO=" + line)
                        If FilasContratos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                            'verificar si ya esta en la table actual
                            Dim filas1 As DataRow()
                            filas1 = TPersonas.Select("CODIGOCONTRATO=" + line)
                            If filas1.Length = 0 Then
                                Dim FilaContrato As DataRow
                                FilaContrato = FilasContratos(0)
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TPersonas.NewRow
                                NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                                NuevaFilaItem("IDPERSONA") = FilaContrato("IDPERSONA")
                                NuevaFilaItem("IDCONTRATO") = FilaContrato("IDCONTRATO")
                                NuevaFilaItem("CODIGOCONTRATO") = FilaContrato("CODIGOCONTRATO")
                                NuevaFilaItem("NOMBREPERSONA") = FilaContrato("NOMBREPERSONA")
                                NuevaFilaItem("CODIGOTIPOSALARIO") = FilaContrato("CODIGOTIPOSALARIO")
                                NuevaFilaItem("CODIGOTIPOCATEGORIAPERSONAL") = FilaContrato("CODIGOTIPOCATEGORIAPERSONAL")
                                NuevaFilaItem("CODIGOTIPOCARGO") = FilaContrato("CODIGOTIPOCARGO")
                                NuevaFilaItem("IDTIPORECURSO") = FilaContrato("IDTIPORECURSO")
                                TPersonas.Rows.Add(NuevaFilaItem) '
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
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
                If ValidarItems(line) = True Then
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
                        NuevaFilaItem = TArticulos.NewRow 'LISTAITEMREQUISICION
                        NuevaFilaItem("IDARTICULO") = line
                        NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                        NuevaFilaItem("VALORUNITARIO") = FilaArticulo("VALORREFERENCIA")
                        NuevaFilaItem("CANTIDAD") = 0
                        NuevaFilaItem("VALORTOTAL") = 0
                        NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBREDESCRIPTIVO"))
                        TArticulos.Rows.Add(NuevaFilaItem)
                    End If
                End If
                ELiminarFilaVaciaArticulo()
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lk_AgregarPortapapelesEquipos_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lk_AgregarPortapapelesEquipos.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
        Dim words() As String = Clipboard.GetText().Split(delimiterChars)
        For i = 0 To words.Length - 1
            Dim line As String
            line = Replace(LTrim(RTrim(words(i))), vbLf, "")
            If line.Length > 0 Then
                Try
                    If ValidarItemsRDEquipo(line, -1) = True Then
                        Dim FilasEquipos As DataRow()
                        Dim equipos As New DataTable()
                        Dim Cadena_Consulta As String = "SELECT * FROM dbo.detalleEquipo('" & line & "'," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                        Dim Consulta As New SqlCommand(Cadena_Consulta)
                        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Consulta.Connection = Conexión
                        Dim Adaptador As New SqlDataAdapter(Consulta)
                        Consulta.Connection.Open()
                        Adaptador.FillSchema(equipos, SchemaType.Source)
                        Adaptador.Fill(equipos)
                        Consulta.Connection.Close()
                        FilasEquipos = equipos.Select("CODIGOEQUIPO='" + line + "'")
                        If FilasEquipos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                            Dim FilaEquipo As DataRow
                            FilaEquipo = FilasEquipos(0)
                            Dim NuevaFilaItem As DataRow
                            NuevaFilaItem = TEquipos.NewRow
                            NuevaFilaItem("ORDEN") = TEquipos.Rows.Count + 1
                            NuevaFilaItem("IDEQUIPO") = FilaEquipo("IDEQUIPO")
                            NuevaFilaItem("CODIGOEQUIPO") = FilaEquipo("CODIGOEQUIPO")
                            NuevaFilaItem("DESCRIPCION") = Mid(FilaEquipo("NOMBREDESCRIPTIVO"), 1, 99)
                            NuevaFilaItem("DISPONIBLE") = "N"
                            NuevaFilaItem("VARADO") = "N"
                            TEquipos.Rows.Add(NuevaFilaItem)
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_JefeCuadrilla.Cb_Persona.SelectedValue
            Me.Cu_JefeCuadrilla.CargarDatos()
            Me.Cu_JefeCuadrilla.Cb_Persona.SelectedValue = temp
            Me.Cu_JefeCuadrilla.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_Administrador.Cb_Persona.SelectedValue
            Me.Cu_Administrador.CargarDatos()
            Me.Cu_Administrador.Cb_Persona.SelectedValue = temp
            Me.Cu_Administrador.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_Superintendente.Cb_Persona.SelectedValue
            Me.Cu_Superintendente.CargarDatos()
            Me.Cu_Superintendente.Cb_Persona.SelectedValue = temp
            Me.Cu_Superintendente.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_DirectorObra.Cb_Persona.SelectedValue
            Me.Cu_DirectorObra.CargarDatos()
            Me.Cu_DirectorObra.Cb_Persona.SelectedValue = temp
            Me.Cu_DirectorObra.CargarCajaTexto()
        Catch
        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_JefeCuadrilla.Name
                Me.Cu_JefeCuadrilla.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_Administrador.Name
                Me.Cu_Administrador.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_Superintendente.Name
                Me.Cu_Superintendente.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_DirectorObra.Name
                Me.Cu_DirectorObra.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

    Private Sub Tx_ObservaciónPersonas_TextChanged(sender As Object, e As EventArgs) Handles Tx_ObservaciónPersonas.TextChanged
        Me.Lb_ObservacionIntegrantes.Text = "Observación Integrantes: (" + Me.Tx_ObservaciónPersonas.Text.Length.ToString + "/999)"
    End Sub

    Private Sub Tx_ObservaciónEquipos_TextChanged(sender As Object, e As EventArgs) Handles Tx_ObservaciónEquipos.TextChanged
        Me.Lb_ObservacionEquipo.Text = "Observación Equipos: (" + Me.Tx_ObservaciónEquipos.Text.Length.ToString + "/999)"
    End Sub

    Private Sub Tx_ObservaciónAvanceObra_TextChanged(sender As Object, e As EventArgs) Handles Tx_ObservaciónAvanceObra.TextChanged
        Me.Lb_ObservaciónActividades.Text = "Observación Avance de Obra: (" + Me.Tx_ObservaciónAvanceObra.Text.Length.ToString + "/999)"
    End Sub

    Private Sub Tx_ObservaciónMateriales_TextChanged(sender As Object, e As EventArgs) Handles Tx_ObservaciónMateriales.TextChanged
        Me.Lb_ObservaciónMateriales.Text = "Observación Materiales: (" + Me.Tx_ObservaciónMateriales.Text.Length.ToString + "/999)"
    End Sub

    Private Sub Tx_Observación_Complemento_TextChanged(sender As Object, e As EventArgs) Handles Tx_Observación_Complemento.TextChanged
        Me.Lb_ObservaciónComplementoIntegrantes.Text = "Observación Complemento Integrantes: (" + Me.Tx_Observación_Complemento.Text.Length.ToString + "/999)"
    End Sub

    Private Sub Fr_ModificarReporte_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Width = 1230
        Catch ex As Exception

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
                    fila = TActividades.NewRow
                    Dim filasservicioseleccionado As DataRow()
                    filasservicioseleccionado = TServiciosActuales.Select("SERVICIO='" + line + "'")
                    Dim filaservicioseleccionado As DataRow
                    filaservicioseleccionado = filasservicioseleccionado(0)
                    If ValidarItemsServicios(filaservicioseleccionado("IDOTSERVICIO")) Then
                        Dim NuevaFilaItem As DataRow
                        NuevaFilaItem = TActividades.NewRow
                        NuevaFilaItem("IDOTSERVICIO") = filaservicioseleccionado("IDOTSERVICIO")
                        NuevaFilaItem("IDORDENTRABAJO") = filaservicioseleccionado("IDORDENTRABAJO")
                        NuevaFilaItem("SERVICIO") = filaservicioseleccionado("SERVICIO")
                        NuevaFilaItem("DESCRIPCION") = filaservicioseleccionado("NOMBRESERVICIO")
                        NuevaFilaItem("CODIGOTIPOUNIDAD") = filaservicioseleccionado("CODIGOTIPOUNIDAD")
                        NuevaFilaItem("AVANCE") = 0
                        NuevaFilaItem("CODIGOPOBLACION") = filaservicioseleccionado("CODIGOPOBLACION")
                        NuevaFilaItem("IDCLASEATENCION") = filaservicioseleccionado("IDCLASEATENCION")
                        TActividades.Rows.Add(NuevaFilaItem)
                        ELiminarFilaVacia("A")
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub TSMI_8_5_Click(sender As Object, e As EventArgs) Handles TSMI_8_5.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "8,5"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_5_5_Click(sender As Object, e As EventArgs) Handles TSMI_5_5.Click
        Dim Nombre_Columna As String
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_ListaPersonas.Columns(Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_ListaPersonas.CurrentCell.ColumnIndex
        Dim Valor_Copiar As String = "5,5"
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 0 To Me.Dgv_ListaPersonas.RowCount - 1
                Me.Dgv_ListaPersonas.Item(Indice_Columna, i).Value = Valor_Copiar
            Next
        Catch ex As Exception
            MsgBox("El valor que esta ingresando no es valido, por favor verificar", MsgBoxStyle.Critical, "ERROR")
        End Try
        Try
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(0, 1)
            Me.Dgv_ListaPersonas.CurrentCell = Me.Dgv_ListaPersonas(Indice_Columna, 0)
        Catch ex As Exception
        End Try
        CalcularTotalCargar()
        TIntegrantes.AcceptChanges()
        Me.Cursor = Cursors.Default
    End Sub

End Class 'Fr_ModificarReporte