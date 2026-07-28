Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.Office.Interop
Imports FormulariosOrdenesTrabajo

Public Class Cu_ReporteDiario
    Public ReactivarPrincipal As Boolean = True
    Private Index_Registro_Actual As Integer = -1
    Private bddatos As New DatosClasesBase.Busquedas
    Private dsReportes As New DataSet
    Private dtPersonaReporteDiario As New DataTable
    Private dtEquipoReporteDiario As New DataTable
    Private dtPersonaCuadrilla As New DataTable
    Private tabla_cargada As String = ""
    Private dsCuadrilla As New DataSet
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter


    Private Enum Tablas
        Cuadrillas
    End Enum
    Private tablaCargada As Tablas

    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_ListaIntegrantes.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaIntegrantes.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Reportes.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Reportes.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaEquipos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaEquipos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Nbc_Reportes.ActiveGroup = Me.Nbg_Reportes
        'Reportes
        Nbg_Reportes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Reportes.Tag)
        Nbi_ListarReporteDiario.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarReporteDiario.Tag)
        Nbi_Nuevo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Nuevo.Tag)
        Nbi_Clonar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Clonar.Tag)
        Nbi_Modificar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Modificar.Tag)
        Nbi_Habilitar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Habilitar.Tag)
        Nbi_Buscar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Buscar.Tag)
        Nbi_ListarCuadrillas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarCuadrillas.Tag)
        Nbi_CrearCuadrilla.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearCuadrilla.Tag)
        Nbi_EditarCaudrilla.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarCaudrilla.Tag)
        Nbi_BuscarCuadrillas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCuadrillas.Tag)
        'Imprimir
        Nbg_Imprimir.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Imprimir.Tag)
        Nbi_Reporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Reporte.Tag)
        Nbi_ReporteBlanco.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ReporteBlanco.Tag)
        Nbi_ReporteSinDiligenciar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ReporteSinDiligenciar.Tag)
        Nbi_Novedades.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Novedades.Tag)
        Nbi_NovedadesEquipos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_NovedadesEquipos.Tag)
        Nbi_ReporteBasico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ReporteBasico.Tag)
        'Exportar Excel
        Nbg_ExportarExcelRD.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ExportarExcelRD.Tag)
        Nbi_RDxFechas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RDxFechas.Tag)
        Nbi_RTxCodContrato.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RTxCodContrato.Tag)
        'Informes a Nómina
        Nbg_Informes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Informes.Tag)
        Bt_GenerarSobretiempo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_GenerarSobretiempo.Tag)
        Bt_AuxTransporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_AuxTransporte.Tag)
        Bt_AuxAlimentacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_AuxAlimentacion.Tag)
        Bt_SinIncidencia.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_SinIncidencia.Tag)
        Bt_BonoTecnico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_BonoTecnico.Tag)
        Bt_ReporteIncapacidades.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_ReporteIncapacidades.Tag)
        Bt_ControlViaticos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_ControlViaticos.Tag)
        Bt_SolicitudLiquidacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_SolicitudLiquidacion.Tag)
        Bt_PerPendReportar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_PerPendReportar.Tag)
        RegistrarNovedadToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(RegistrarNovedadToolStripMenuItem.Tag)

        Nbi_ImprimirCEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirCEquipo.Tag)


        If Nbi_ListarCuadrillas.Visible = False And
            Nbi_CrearCuadrilla.Visible = False And
            Nbi_EditarCaudrilla.Visible = False And
            Nbi_BuscarCuadrillas.Visible = False Then
            Me.Separador.Visible = False
        End If


        'cargar combo de fechas y periodos
        CargarComboxNomina()


    End Sub

#Region "Eventos asociados a los informes de nómina"

    Dim Tperiodos As DataTable
    Dim bddatos1 As New FuncionesBase.ClaseCargarMaestras
    Private Sub CargarComboxNomina()
        Try
            Dim dsCargar1 As New DataSet
            dsCargar1 = bddatos1.CargarMaestras(8, VariablesBase.VariablesBase.IdBaseSiscontrolActual, VariablesBase.VariablesBase.IdBaseSiscontrolActual, 0)
            '-- 0	AÑO

            Me.Cb_AñoInforme.DataSource = dsCargar1.Tables(0)
            Me.Cb_AñoInforme.ValueMember = "AÑO"
            Me.Cb_AñoInforme.DisplayMember = "AÑO"
            Me.Cb_AñoInforme.SelectedIndex = 0

            '	-- 1	MA_PERIODONOMINA

            Tperiodos = dsCargar1.Tables(1)
            Dim cortenomina As New DataView(Tperiodos)
            cortenomina.RowFilter = "AÑO='" + Me.Cb_AñoInforme.SelectedValue.ToString + "'"
            Me.Cb_CorteNómina.DataSource = cortenomina
            Me.Cb_CorteNómina.ValueMember = "IDPERIODONOMINA"
            Me.Cb_CorteNómina.DisplayMember = "PERIODO"
            Me.Cb_CorteNómina.SelectedIndex = 0

            Dim filas As DataRow()
            filas = Tperiodos.Select("IDPERIODONOMINA=" + Me.Cb_CorteNómina.SelectedValue.ToString)
            Dim fila As DataRow
            fila = filas(0)
            Me.Lb_InicioPeriodo.Text = "Fecha Inicio: " + CDate(fila("FECHAINICIO")).ToShortDateString
            Me.Lb_FinPeriodo.Text = "Fecha Fin: " + CDate(fila("FECHAFIN")).ToShortDateString

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Cb_AñoInforme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AñoInforme.SelectedIndexChanged
        Try
            Dim cortenomina As New DataView(Tperiodos)
            cortenomina.RowFilter = "AÑO='" + Me.Cb_AñoInforme.SelectedValue.ToString + "'"
            Me.Cb_CorteNómina.DataSource = cortenomina
            Me.Cb_CorteNómina.ValueMember = "IDPERIODONOMINA"
            Me.Cb_CorteNómina.DisplayMember = "PERIODO"
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Cb_CorteNómina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_CorteNómina.SelectedIndexChanged
        Try
            Dim filas As DataRow()
            filas = Tperiodos.Select("IDPERIODONOMINA=" + Me.Cb_CorteNómina.SelectedValue.ToString)
            Dim fila As DataRow
            fila = filas(0)
            Me.Lb_InicioPeriodo.Text = "Fecha Inicio: " + CDate(fila("FECHAINICIO")).ToShortDateString
            Me.Lb_FinPeriodo.Text = "Fecha Fin: " + CDate(fila("FECHAFIN")).ToShortDateString
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Public Sub Cargar_Tabla()
        ReactivarPrincipal = False
        tabla_cargada = ""
        Cursor.Current = Cursors.WaitCursor
        Try
            dsReportes = bddatos.BusquedaCondiciones(34, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
            If dsReportes.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsReportes.Tables.Remove(dsReportes.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsReportes.Clear()
            End If
            tabla_cargada = "Reporte"
            Dgv_ListaIntegrantes.DataSource = Nothing
            Dgv_ListaEquipos.DataSource = Nothing
            Dgv_Reportes.DataSource = dsReportes.Tables(0)
            Me.Lb_CantidadReportes.Text = "Cantidad de Reportes: " + Dgv_Reportes.RowCount.ToString
            AplicarFormatoColumnas()
        Catch ex As Exception
            '   MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
        End Try
        Cursor.Current = Cursors.Default
        Try
            Ubicar_Registro()
        Catch ex As Exception
        End Try
    End Sub


    Public Sub Cargar_Tabla_Cuadrillas()
        tabla_cargada = ""
        Cursor.Current = Cursors.WaitCursor
        Try
            dsReportes = bddatos.BusquedaCondiciones(38, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
            If dsReportes.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsReportes.Tables.Remove(dsReportes.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsReportes.Clear()
            End If
            tabla_cargada = "Cuadrilla"
            Dgv_ListaIntegrantes.DataSource = Nothing
            Dgv_ListaEquipos.DataSource = Nothing
            Dgv_Reportes.DataSource = dsReportes.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadReportes.Text = "Cantidad de cuadrillas: " + dsReportes.Tables(0).Rows.Count.ToString
            Ubicar_Registro()
        Catch ex As Exception
            '   MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
        End Try
        Try
            Dgv_Reportes.Rows(0).Selected = True
        Catch
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub AplicarFormatoColumnas()
        For i = 0 To Dgv_Reportes.ColumnCount - 1
            Select Case Dgv_Reportes.Columns(i).Name
                Case "Id"
                    Dgv_Reportes.Columns(i).Width = 40
                    Dgv_Reportes.Columns(i).ToolTipText = "Id Reporte"
                Case "IDBASE"
                    Dgv_Reportes.Columns(i).Visible = False
                Case "Reporte Diario"
                    Dgv_Reportes.Columns(i).ToolTipText = "Reporte Diario"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Fecha Reporte"
                    Dgv_Reportes.Columns(i).Width = 90
                    Dgv_Reportes.Columns(i).ToolTipText = "Fecha Reporte"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Frente Trabajo"
                    Dgv_Reportes.Columns(i).Width = 150
                    Dgv_Reportes.Columns(i).ToolTipText = "Frente Trabajo"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Disciplina"
                    Dgv_Reportes.Columns(i).Width = 150
                    Dgv_Reportes.Columns(i).ToolTipText = "Disciplina"
                Case "Tipo Tiempo"
                    Dgv_Reportes.Columns(i).Width = 100
                    Dgv_Reportes.Columns(i).ToolTipText = "Tipo Tiempo"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Tipo Paro"
                    Dgv_Reportes.Columns(i).Width = 100
                    Dgv_Reportes.Columns(i).ToolTipText = "Tipo Paro"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Jefe Cuadrilla"
                    Dgv_Reportes.Columns(i).Width = 150
                    Dgv_Reportes.Columns(i).ToolTipText = "Jefe Cuadrilla"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Revisado"
                    Dgv_Reportes.Columns(i).Width = 40
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Reportes.Columns(i).ToolTipText = "Revisado"
                    Dgv_Reportes.Columns(i).HeaderText = "Rev"
                Case "Cerrado"
                    Dgv_Reportes.Columns(i).Width = 40
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Reportes.Columns(i).ToolTipText = "Cerrado"
                    Dgv_Reportes.Columns(i).HeaderText = "Cerr"
                Case "Envío Aprobado"
                    Dgv_Reportes.Columns(i).Width = 40
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Reportes.Columns(i).HeaderText = "Apro"
                    Dgv_Reportes.Columns(i).ToolTipText = "Aprobado para envío"
                Case "Base"
                    Dgv_Reportes.Columns(i).Width = 120
                    Dgv_Reportes.Columns(i).ToolTipText = "Base"
                Case "Nombre Cuadrilla"
                    Dgv_Reportes.Columns(i).Width = 250
                    Dgv_Reportes.Columns(i).ToolTipText = "Nombre Cuadrilla"
                Case "Estado"
                    Dgv_Reportes.Columns(i).Width = 50
                    Dgv_Reportes.Columns(i).ToolTipText = "Estado"
                Case "Nro Integrantes"
                    Dgv_Reportes.Columns(i).Width = 80
                    Dgv_Reportes.Columns(i).ToolTipText = "Nro Integrantes"
                Case "Base"
                    Dgv_Reportes.Columns(i).Width = 80
                    Dgv_Reportes.Columns(i).ToolTipText = "Revisado"
                Case "Registra"
                    Dgv_Reportes.Columns(i).Width = 150
                    Dgv_Reportes.Columns(i).ToolTipText = "Registra"
                Case "F Registro"
                    Dgv_Reportes.Columns(i).Width = 80
                    Dgv_Reportes.Columns(i).ToolTipText = "F Registro"
                Case Else
                    Dgv_Reportes.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub Dgv_Reportes_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dgv_Reportes.SelectionChanged
        Try
            Select Case tabla_cargada
                Case "Reporte"
                    Dim xx As New Reporte(Me.Dgv_Reportes.Rows(Dgv_Reportes.CurrentRow.Index))
                    Me.PgDetalleReporte.SelectedObject = xx
                    CargarPersonas()
                    CargarEquipos()
                Case "Cuadrilla"
                    Dim xx As New Cuadrilla(Me.Dgv_Reportes.Rows(Dgv_Reportes.CurrentRow.Index))
                    Me.PgDetalleReporte.SelectedObject = xx
                    CargarPersonasCuadrilla()
            End Select
        Catch
        End Try
    End Sub

    Private Sub CargarPersonas()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM ListaReporteDiarioPersona(@IDREPORTEDIARIO)", conexion)
        comando.Parameters.AddWithValue("@IDREPORTEDIARIO", Dgv_Reportes.SelectedRows(0).Cells(0).Value)
        Dim adaptador As New SqlDataAdapter(comando)
        dtPersonaReporteDiario.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtPersonaReporteDiario)
            conexion.Close()
            Me.Dgv_ListaIntegrantes.DataSource = dtPersonaReporteDiario
            Me.Lb_CantidadIntegrantes.Text = "Lista de personas asociadas al reporte: " + Dgv_ListaIntegrantes.RowCount.ToString

            For i = 0 To Dgv_ListaIntegrantes.ColumnCount - 1
                Select Case Dgv_ListaIntegrantes.Columns(i).Name
                    Case "DGVTBC_CONTRATO", "CODIGOCONTRATO"
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Código Contrato"
                        Dgv_ListaIntegrantes.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        Dgv_ListaIntegrantes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Dgv_ListaIntegrantes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case "DGVTBC_NPERSONA", "NOMBREPERSONA"
                        Dgv_ListaIntegrantes.Columns(i).Width = 200
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Nombre"
                    Case "DVGTBC_CATEGORIA", "CODIGOTIPOCATEGORIAPERSONAL"
                        Dgv_ListaIntegrantes.Columns(i).Width = 30
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Cat"
                    Case "DGVTBC_CARGO", "NOMBRETIPOCARGO"
                        Dgv_ListaIntegrantes.Columns(i).Width = 150
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Cargo"
                    Case "DGVTBC_TOTAL", "TOTAL"
                        Dgv_ListaIntegrantes.Columns(i).Width = 40
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "T"
                    Case "DGVTBC_HNORMALES", "HN"
                        Dgv_ListaIntegrantes.Columns(i).Width = 40
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "HN"
                    Case "DGVTBC_HDIURNAS", "HED"
                        Dgv_ListaIntegrantes.Columns(i).Width = 40
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "HED"
                    Case "DGVTBC_HNOCTURNAS", "HEN"
                        Dgv_ListaIntegrantes.Columns(i).Width = 40
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "HEN"
                    Case "DGVTBC_HRNOCTURNO", "RN"
                        Dgv_ListaIntegrantes.Columns(i).Width = 40
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "HRN"
                    Case Else
                        Dgv_ListaIntegrantes.Columns(i).Visible = False
                End Select
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CargarEquipos()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM ListaReporteDiarioEquipo(@IDREPORTEDIARIO)", conexion)
        comando.Parameters.AddWithValue("@IDREPORTEDIARIO", Dgv_Reportes.SelectedRows(0).Cells(0).Value)
        Dim adaptador As New SqlDataAdapter(comando)
        dtEquipoReporteDiario.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtEquipoReporteDiario)
            conexion.Close()
            Me.Dgv_ListaEquipos.DataSource = dtEquipoReporteDiario
            Me.Lb_CantidadEquipos.Text = "Lista de equipos asociados al reporte: " + Dgv_ListaEquipos.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CargarPersonasCuadrilla()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM ListaCuadrillaPersona(@IDCUADRILLA)", conexion)
        comando.Parameters.AddWithValue("@IDCUADRILLA", Dgv_Reportes.SelectedRows(0).Cells(0).Value)
        Dim adaptador As New SqlDataAdapter(comando)
        dtPersonaCuadrilla.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtPersonaCuadrilla)
            conexion.Close()
            Pn_Detalle.Visible = True
            Me.Dgv_ListaIntegrantes.DataSource = dtPersonaCuadrilla
            Me.Lb_CantidadIntegrantes.Text = "Lista de personas asociadas a la Cuadrilla: " + Dgv_ListaIntegrantes.RowCount.ToString
            'Aplicar Formato

            For i = 0 To Dgv_ListaIntegrantes.ColumnCount - 1
                Select Case Dgv_ListaIntegrantes.Columns(i).Name
                    Case "Código Contrato"
                        Dgv_ListaIntegrantes.Columns(i).Width = 80
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Código Contrato"
                        Dim style As New DataGridViewCellStyle()
                        style.Font = New Font(Dgv_ListaIntegrantes.Font, FontStyle.Bold)
                        Dgv_ListaIntegrantes.Columns(i).DefaultCellStyle = style
                        Dgv_ListaIntegrantes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case "Nombre"
                        Dgv_ListaIntegrantes.Columns(i).Width = 250
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Nombre"
                    Case "Orden"
                        Dgv_ListaIntegrantes.Columns(i).Width = 50
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Orden"
                    Case "Tipo Recurso"
                        Dgv_ListaIntegrantes.Columns(i).Width = 200
                        Dgv_ListaIntegrantes.Columns(i).ToolTipText = "Tipo Recurso"

                    Case "Id Contrato"
                        Dgv_ListaIntegrantes.Columns(i).Visible = False
                    Case Else
                        Dgv_ListaIntegrantes.Columns(i).Visible = False
                End Select
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Dgv_Reportes_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_Reportes.DoubleClick
        If tabla_cargada = "Reporte" Then
            'MsgBox("Debe cargar la tabla de reportes para continuar")
            EditarReporteDiario()
        Else
            EditarCuadrillas()
        End If
    End Sub

    Private Sub Cu_ReporteDiario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, Dgv_Reportes.KeyDown, Nbc_Reportes.KeyDown, Dgv_ListaEquipos.KeyDown, Dgv_ListaIntegrantes.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BuscarReporte()
            Case Keys.F2
                crearreporte()
            Case Keys.F4
                Cargar_Tabla()
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Reporte")
            Case Keys.F6
                ExportarDatosExcel(Dgv_Reportes)
        End Select
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        With objHojaExcel
            .Name = ("Datos Exportados")
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Reportes.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

#Region "Reportes"
    Private Sub Nbi_ListarReporteDiario_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarReporteDiario.ItemClick

        Cargar_Tabla()
        Pn_Detalle.Visible = True

    End Sub

    Private Sub Nbi_Nuevo_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_Nuevo.ItemClick
        crearreporte()
    End Sub

    Private Sub crearreporte()
        Me.ReactivarPrincipal = False
        Me.Cursor = Cursors.WaitCursor
        Dim FrReporteDiario As New FormularioReporteDiario.Fr_ModificarReporte
        FrReporteDiario.CargarValores()
        FrReporteDiario.Cargar_Tablas()
        FrReporteDiario.AplicarFormatoColumnas()
        Me.Cursor = Cursors.Default
        FrReporteDiario.Cu_padre = New Object
        FrReporteDiario.Cu_padre = Me
        FrReporteDiario.Show()
    End Sub

    Private Sub Nbi_Clonar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Clonar.ItemClick
        If tabla_cargada <> "Reporte" Then
            MsgBox("Debe cargar la tabla de reportes para continuar")
        Else
            Try
                Me.ReactivarPrincipal = False
                Me.Cursor = Cursors.WaitCursor
                Dim IndiceFilaseleccionada As Integer = Dgv_Reportes.CurrentRow.Index
                Dim FrReporteDiario As New FormularioReporteDiario.Fr_ModificarReporte
                FrReporteDiario.IdReporteDiario_Modificar = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells(0).Value
                Dim IdbaseReporte As Integer
                IdbaseReporte = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value
                If IdbaseReporte <> VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                    MsgBox("No se puede clonar reportes desde una base diferente a la que corresponde")
                    Exit Sub
                End If
                Index_Registro_Actual = Me.Dgv_Reportes.CurrentCell.RowIndex
                FrReporteDiario.TipoAccion = "E"
                FrReporteDiario.Cargar_Tablas()
                FrReporteDiario.CargarValores()
                FrReporteDiario.CargarDatosReporteDiario()
                FrReporteDiario.AplicarFormatoColumnas()
                FrReporteDiario.TipoAccion = "I"
                FrReporteDiario.LimpiarXClonación()
                Me.Cursor = Cursors.Default
                FrReporteDiario.Cu_padre = New Object
                FrReporteDiario.Cu_padre = Me
                FrReporteDiario.Show()
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
            End Try
        End If
    End Sub

    Private Sub Nbi_Modificar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Modificar.ItemClick
        If tabla_cargada <> "Reporte" Then
            MsgBox("Debe cargar la tabla de reportes para continuar")
        Else
            Dim IndiceFilaseleccionada As Integer = Dgv_Reportes.CurrentRow.Index
            If Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("CERRADO").Value = "S" Then
                MsgBox("Este reporte se encuentra cerrado por Facturación y/o Oficina Técnica, no se puede modificar", MsgBoxStyle.Exclamation, "Reporte Cerrado")
                Exit Sub
            Else
                If Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("Envío Aprobado").Value = "S" Then
                    MsgBox("Este reporte se encuentra cerrado por nomina, no se puede modificar la información correspondeiente a Horas Hombre de Personal ", MsgBoxStyle.Information, "Reporte Aprobado para Nomina")
                End If
                EditarReporteDiario()
            End If
        End If
    End Sub

    Private Sub EditarReporteDiario()
        Try
            Me.ReactivarPrincipal = False
            Me.Cursor = Cursors.WaitCursor
            Dim IndiceFilaseleccionada As Integer = Dgv_Reportes.CurrentRow.Index
            Dim FrReporteDiario As New FormularioReporteDiario.Fr_ModificarReporte
            If Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("Envío Aprobado").Value = "S" Then
                FrReporteDiario.APROBADOENVIO = True
            End If
            FrReporteDiario.IdReporteDiario_Modificar = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells(0).Value
            Dim IdbaseReporte As Integer
            IdbaseReporte = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value
            If IdbaseReporte <> VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                MsgBox("No se puede editar reportes desde una base diferente a la que corresponde")
                Exit Sub
            End If
            Index_Registro_Actual = Me.Dgv_Reportes.CurrentCell.RowIndex
            FrReporteDiario.Lb_ReporteEditando.Visible = True
            FrReporteDiario.Lb_ReporteEditando.Text = "RD: " + Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("Reporte Diario").Value
            FrReporteDiario.TipoAccion = "E"
            FrReporteDiario.Cargar_Tablas()
            FrReporteDiario.CargarValores()
            FrReporteDiario.CargarDatosReporteDiario()
            FrReporteDiario.AplicarFormatoColumnas()
            Me.Cursor = Cursors.Default
            FrReporteDiario.Cu_padre = New Object
            FrReporteDiario.Cu_padre = Me
            FrReporteDiario.Show()
        Catch ex As Exception
            MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
        End Try
    End Sub
    Public Sub Ubicar_Registro()
        Try
            If Not IsNothing(Dgv_Reportes.DataSource) Then
                Try
                    Dgv_Reportes.CurrentCell = Dgv_Reportes.Item(0, Index_Registro_Actual)
                Catch
                    Dgv_Reportes.CurrentCell = Dgv_Reportes.Item(0, 0)
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_Buscar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Buscar.ItemClick
        BuscarReporte()
    End Sub

    Private Sub BuscarReporte()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("RD.FECHAREPORTEDIARIO", "Fecha del reporte", "3")
        campos.Rows.Add("RD.REPORTEDIARIO", "Reporte Diario", "1")
        campos.Rows.Add("2", "Nombre del frente de trabajo", "7")
        campos.Rows.Add("3", "Jefe de cuadrilla", "7")
        campos.Rows.Add("C.CODIGOCONTRATO", "Código Contrato", "1")
        campos.Rows.Add("4", "Código Contrato Todas las Bases de ISMOCOL", "7")
        campos.Rows.Add("P.IDENTIFICACION", "Identificación (sin puntos)", "2")
        campos.Rows.Add("OT.NROORDENSAP", "Código de la orden de trabajo", "2")
        campos.Rows.Add("5", "Código de la OM Todas las Bases de ISMOCOL", "7")

        'campos.Rows.Add("2", "", "4") 'Consulta especial
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de Reporte Diario"
        frbuscar.tabla = 34
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsReportes = DSbusqueda
        If dsReportes.Tables.Count > 0 Then
            If dsReportes.Tables(0).Rows.Count > 0 Then
                Dgv_Reportes.DataSource = dsReportes.Tables(0)
                AplicarFormatoColumnas()
                Me.Lb_CantidadReportes.Text = "Cantidad de Reportes: " + Dgv_Reportes.RowCount.ToString
                Dgv_Reportes.Rows(0).Selected = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub Nbi_ListarCuadrillas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarCuadrillas.ItemClick
        Cargar_Tabla_Cuadrillas()
        Pn_Detalle.Visible = True
    End Sub

    Private Sub Nbi_GestiónCuadrillas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearCuadrilla.ItemClick
        Me.ReactivarPrincipal = False
        Me.Cursor = Cursors.WaitCursor
        Dim FrGestiónCuadrillas As New FormularioReporteDiario.Fr_GestiónCuadrillas
        FrGestiónCuadrillas.Cargar_Tablas()
        Me.Cursor = Cursors.Default
        FrGestiónCuadrillas.Show()
        Cargar_Tabla_Cuadrillas()
    End Sub

    Private Sub EditarCuadrillas()
        Try
            Me.ReactivarPrincipal = False
            Dim IndiceFilaseleccionada As Integer = Dgv_Reportes.CurrentRow.Index
            Dim FrGestiónCuadrillas As New FormularioReporteDiario.Fr_GestiónCuadrillas
            FrGestiónCuadrillas.Idcuadrilla = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells(0).Value
            Dim IdbaseReporte As Integer
            IdbaseReporte = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value
            If IdbaseReporte <> VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                MsgBox("No se puede editar reportes desde una base diferente a la que corresponde")
                Exit Sub
            End If
            Index_Registro_Actual = Me.Dgv_Reportes.CurrentCell.RowIndex
            FrGestiónCuadrillas.TipoAccion = "E"
            FrGestiónCuadrillas.Cargar_Tablas()
            FrGestiónCuadrillas.Show()
            Cargar_Tabla_Cuadrillas()
        Catch ex As Exception
            MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
        End Try
    End Sub

    Private Sub Nbi_EditarCaudrilla_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarCaudrilla.ItemClick
        If tabla_cargada <> "Cuadrilla" Then
            MsgBox("Debe cargar la lista de cuadrillas")
        Else
            EditarCuadrillas()
        End If
    End Sub
#End Region 'Reportes

#Region "Imprimir"
    Private Sub Nbi_Reporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Reporte.ItemClick


        If Me.Dgv_Reportes.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim TablaId As New DataTable
        TablaId.Columns.Add("Id", System.Type.GetType("System.Int32"))

        For i = 0 To Dgv_Reportes.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = TablaId.NewRow
            fila("Id") = Dgv_Reportes.SelectedRows(i).Cells(0).Value
            TablaId.Rows.Add(fila)
        Next
        Dim listaidot As New ArrayList
        Dim climpresion As New ImprimirControlProyecto.Cl_Impresión
        Dim Array As New ArrayList

        If MsgBox("¿Desea ver la vista previa de los reportes a imprimir?", MsgBoxStyle.YesNo, "Ver vista previa") = MsgBoxResult.Yes Then
            Array.Add(10)
            For i = 0 To TablaId.Rows.Count - 1
                Dim fila As DataRow
                fila = TablaId.Rows(i)
                climpresion.IdReporteDiario = fila(0)
                climpresion.ImprimirFormatos(Array, True, True) 'Impresión a doble cara.
            Next
        Else
            If MsgBox("Va enviar a imprimir " + TablaId.Rows.Count.ToString + " reportes de tiempo en bloque a la impresora, ¿Desea continuar?", MsgBoxStyle.YesNo, "Envio en bloque") = MsgBoxResult.Yes Then
                Array.Add(13)
                climpresion.TablaIdReporte = TablaId
                climpresion.ImprimirFormatos(Array, True, True) 'Impresión e bloque
            End If
        End If
    End Sub

    Private Sub Nbi_ReporteBlanco_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ReporteBlanco.ItemClick
        Dim clImpresion As New ImprimirControlProyecto.Cl_Impresión
        Dim arrayDocumentos As New ArrayList
        arrayDocumentos.Add(12)
        clImpresion.ImprimirFormatos(arrayDocumentos, True, True) 'Impresión a doble cara.
    End Sub

    Private Sub Nbi_Novedades_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Novedades.ItemClick

    End Sub

    Private Sub Nbi_ReporteBasico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ReporteBasico.ItemClick
        If Dgv_Reportes.SelectedRows.Count > 0 Then
            If tabla_cargada = "Reporte" Then
                Dim clImpresion As New ImprimirControlProyecto.Cl_Impresión
                clImpresion.IdReporteDiario = Dgv_Reportes.SelectedRows(0).Cells("Id").Value
                Dim arrayDocumentos As New ArrayList
                arrayDocumentos.Add(11)
                clImpresion.ImprimirFormatos(arrayDocumentos, True, False) 'Impresión a doble cara.
            End If
        End If
    End Sub
#End Region 'Imprimir

    Private Sub Cu_ReporteDiario_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.SplitContainer1.SplitterDistance = Me.Width * 0.75
            Me.SplitContainer2.SplitterDistance = Me.Width * 0.5 - (Nbc_Reportes.Width / 2)
            Me.Pn_Detalle.Height = Me.Height * 0.25
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub ExportarExcel_OTMultiplesHojas(ByVal Tipo As Integer, ByVal FechaI As Date, ByVal FechaF As Date)

        Dim TablaId As New DataTable
        TablaId.Columns.Add("0", System.Type.GetType("System.Int32"))
        Dim dtPersona As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtEquipos As New DataTable
        Dim dtCostoIndirecto As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ExpExcelRDxOM", conexion)
        comando.CommandType = CommandType.StoredProcedure
        Select Case Tipo
            Case 5 'Todos los RT asociados a la OM
                comando.Parameters.AddWithValue("@TIPOBASE", 2)
        End Select
        comando.Parameters.AddWithValue("@TIPOFECHA", 1)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@FECHAI", FechaI)
        comando.Parameters.AddWithValue("@FECHAF", FechaF)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@TABLAIDOT", TablaId)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)

            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtPersona = dsOT.Tables(0)
                dtMateriales = dsOT.Tables(1)
                dtEquipos = dsOT.Tables(2)
                dtCostoIndirecto = dsOT.Tables(3)
            Else
                MsgBox("No hay datos para exportar .", MsgBoxStyle.Information, "Expotar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursospara exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaPersona As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaMateriales As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaEquipos As Excel.Worksheet = objLibroExcel.Worksheets(3)
        Dim objHojaCostoIndirecto As Excel.Worksheet = objLibroExcel.Worksheets(4)

        With objHojaPersona
            .Name = ("Personas")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtPersona.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtPersona.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtPersona.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtPersona.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        With objHojaMateriales
            .Name = "Materiales"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1

            For Each dc As DataColumn In dtMateriales.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtMateriales.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtMateriales.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtMateriales.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        With objHojaEquipos
            .Name = "Equipos"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtEquipos.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtEquipos.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtEquipos.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtEquipos.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaCostoIndirecto
            .Name = "Costo Indirecto"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtCostoIndirecto.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtCostoIndirecto.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtCostoIndirecto.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtCostoIndirecto.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub Nbi_RDxFechas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RDxFechas.ItemClick

        Dim Consultar As New Boolean
        Dim Fr_FechasOT As New Form
        Dim Lb_FechaI As New Label
        Dim Lb_FechaF As New Label
        Dim Dtp_FechaI As New DateTimePicker
        Dim Dtp_FechaF As New DateTimePicker
        Dim Bt_Aceptar As New Button
        Dim Bt_Cancelar As New Button

        With Lb_FechaI
            .AutoSize = True
            .Location = New System.Drawing.Point(22, 47)
            .Name = "Lb_FechaI"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Fecha Inicial:"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Lb_FechaF
            .AllowDrop = True
            .AutoSize = True
            .Location = New System.Drawing.Point(22, 78)
            .Name = "Lb_FechaF"
            .Size = New System.Drawing.Size(65, 13)
            .TabIndex = 1
            .Text = "Fecha Final:"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Dtp_FechaI
            .Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            .Location = New System.Drawing.Point(125, 46)
            .MinDate = New Date(2019, 1, 1, 0, 0, 0, 0)
            .Name = "Ddp_FechaI"
            .Size = New System.Drawing.Size(122, 20)
            .TabIndex = 2
        End With

        With Dtp_FechaF
            .Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            .Location = New System.Drawing.Point(125, 77)
            .MinDate = New Date(2019, 1, 1, 0, 0, 0, 0)
            .Name = "DateTimePicker2"
            .Size = New System.Drawing.Size(122, 20)
            .TabIndex = 3
        End With

        With Bt_Aceptar
            .Location = New System.Drawing.Point(156, 118)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 4
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(44, 118)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 5
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_FechasOT
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .AcceptButton = Bt_Aceptar
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(291, 156)
            .MaximumSize = New System.Drawing.Size(291, 186)
            .MinimumSize = New System.Drawing.Size(291, 186)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Fechas de la OT"
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(Dtp_FechaI)
            .Controls.Add(Dtp_FechaF)
            .Controls.Add(Lb_FechaF)
            .Controls.Add(Lb_FechaI)
        End With


        AddHandler Bt_Aceptar.Click, Sub()

                                         If MsgBox("Seguro desea exportar el excel de la OT", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then

                                             Consultar = True
                                             Fr_FechasOT.Close()
                                         End If
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()

                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                              Consultar = False
                                              Fr_FechasOT.Close()
                                          End If
                                      End Sub
        Fr_FechasOT.ShowDialog()

        If Consultar = True Then
            Dtp_FechaI.Value.ToString()
            Dtp_FechaF.Value.ToString()
            ExportarExcel_OTMultiplesHojas(5, Dtp_FechaI.Value, Dtp_FechaF.Value)
        End If
    End Sub

    Private Sub Nbi_BuscarCuadrillas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarCuadrillas.ItemClick
        BuscarCuadrilla()
    End Sub

    Private Sub BuscarCuadrilla()

        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("B.NOMBREBASE", "Nombre Base", "1")
        campos.Rows.Add("IDCUADRILLA", "Id de Cuadrilla", "2")
        campos.Rows.Add("C.NOMBRECUADRILLA", "Nombre Cuadrilla", "1")
        campos.Rows.Add("CONVERT(DATE,C.FECHAREGISTRO)", "Fecha Registro", "3")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de calificación registrada en SIGMA"
        frbuscar.tabla = 38 ' Cuadrillas
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsCuadrilla = DSbusqueda
        If Not IsNothing(dsCuadrilla) Then
            If dsCuadrilla.Tables.Count > 0 Then
                If dsCuadrilla.Tables(0).Rows.Count > 0 Then
                    CargarCuadrillasFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        End If
    End Sub

    Private Sub CargarCuadrillasFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_Reportes.DataSource = Nothing
        Dgv_Reportes.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Cuadrillas
        AplicarFormatoColumnas()
        Dgv_Reportes.ReadOnly = True
        Lb_CantidadReportes.Text = "Cantidad de Cuadrillas: " + DsTabla.Tables(0).Rows.Count.ToString
        If Dgv_Reportes.RowCount > 0 Then
            Dgv_Reportes.ClearSelection()
            Dgv_Reportes.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ExpExcelNomina(ByVal tipo As Integer)

        Dim dtSobreTiempoR As New DataTable
        Dim dtSobreTiempoD As New DataTable
        Dim dtAuxTransporte As New DataTable
        Dim dtAuxTransporteNoPropio As New DataTable
        Dim dtAuxAlimentación As New DataTable
        Dim dtAuxAlimentacionNoPropio As New DataTable
        Dim dtSinIncidencia As New DataTable
        Dim dtBonoTecnico As New DataTable
        Dim dtBonoTecnicoAllianz As New DataTable
        Dim dtBonoTecnicoPrincipal As New DataTable
        Dim dtReporteIncapacidades As New DataTable
        Dim dtViaticos As New DataTable
        Dim dtViaticosDetallado As New DataTable
        Dim dtConsolidadoViaticos As New DataTable
        Dim dtLiquidacion As New DataTable
        Dim dtLiqTransporte As New DataTable
        Dim dtLiqAlimentacion As New DataTable
        Dim dtLiqSinIncidencia As New DataTable
        Dim dtLiqBTecnico As New DataTable
        Dim dtLiqIncapacidades As New DataTable
        Dim dtLiqViaticos As New DataTable

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("Exp_Nomina", conexion)
        comando.CommandType = CommandType.StoredProcedure
        Select Case tipo
            Case 0 'Sobretiempo
                comando.Parameters.AddWithValue("@TIPO", 0)
            Case 1 'Aux. de Transporte
                comando.Parameters.AddWithValue("@TIPO", 1)
            Case 2 'Auxilio de Alimentación
                comando.Parameters.AddWithValue("@TIPO", 2)
            Case 3 'Auxilio sin incidencia
                comando.Parameters.AddWithValue("@TIPO", 3)
            Case 4 'Auxilio Bono Técnico
                comando.Parameters.AddWithValue("@TIPO", 4)
            Case 5 'Reporte de Incapacidades
                comando.Parameters.AddWithValue("@TIPO", 5)
            Case 6 'Viaticos
                comando.Parameters.AddWithValue("@TIPO", 6)
            Case 7 'Solicitud de liquidación
                comando.Parameters.AddWithValue("@TIPO", 7)
        End Select
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@IDPERIODONOMINA", Cb_CorteNómina.SelectedValue)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsRT)
            conexion.Close()
            If dsRT.Tables.Count > 0 Then
                If tipo = 0 Then
                    dtSobreTiempoR = dsRT.Tables(0)
                    dtSobreTiempoD = dsRT.Tables(1)
                End If
                If tipo = 1 Then
                    dtAuxTransporte = dsRT.Tables(0)
                    dtAuxTransporteNoPropio = dsRT.Tables(1)
                End If
                If tipo = 2 Then
                    dtAuxAlimentación = dsRT.Tables(0)
                    dtAuxAlimentacionNoPropio = dsRT.Tables(1)
                End If
                If tipo = 3 Then
                    dtSinIncidencia = dsRT.Tables(0)
                End If
                If tipo = 4 Then
                    dtBonoTecnico = dsRT.Tables(0)
                    dtBonoTecnicoAllianz = dsRT.Tables(1)
                    dtBonoTecnicoPrincipal = dsRT.Tables(2)
                End If
                If tipo = 5 Then
                    dtReporteIncapacidades = dsRT.Tables(0)
                End If
                If tipo = 6 Then
                    dtViaticos = dsRT.Tables(0)
                    dtViaticosDetallado = dsRT.Tables(1)
                    dtConsolidadoViaticos = dsRT.Tables(2)
                End If
                If tipo = 7 Then
                    dtLiquidacion = dsRT.Tables(0)
                    dtLiqTransporte = dsRT.Tables(1)
                    dtLiqAlimentacion = dsRT.Tables(2)
                    dtLiqSinIncidencia = dsRT.Tables(3)
                    dtLiqBTecnico = dsRT.Tables(4)
                    dtLiqIncapacidades = dsRT.Tables(5)
                    dtLiqViaticos = dsRT.Tables(6)
                End If

            Else
                MsgBox("No hay datos para exportar .", MsgBoxStyle.Information, "Expotar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursospara exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        If tipo = 0 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            objLibroExcel.Worksheets.Add()
            Dim objHojaSobreTiempoR As Excel.Worksheet = objLibroExcel.Worksheets(1)
            Dim objHojaSobreTiempoD As Excel.Worksheet = objLibroExcel.Worksheets(2)

            With objHojaSobreTiempoR
                .Name = ("Resumen Sobretiempo")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtSobreTiempoR.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtSobreTiempoR.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtSobreTiempoR.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtSobreTiempoR.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaSobreTiempoD
                .Name = ("Datos Sobretiempo")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtSobreTiempoD.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtSobreTiempoD.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtSobreTiempoD.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtSobreTiempoD.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 1 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            objLibroExcel.Worksheets.Add()
            Dim objHojaAuxTransporte As Excel.Worksheet = objLibroExcel.Worksheets(1)
            Dim objHojaAuxTransporteNoPropio As Excel.Worksheet = objLibroExcel.Worksheets(2)

            With objHojaAuxTransporte
                .Name = ("Aux. de Transporte")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtAuxTransporte.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtAuxTransporte.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtAuxTransporte.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtAuxTransporte.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaAuxTransporteNoPropio
                .Name = ("Aux. de Transporte No Propio")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtAuxTransporteNoPropio.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtAuxTransporteNoPropio.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtAuxTransporteNoPropio.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtAuxTransporteNoPropio.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 2 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            objLibroExcel.Worksheets.Add()
            Dim objHojaAuxAlimentacion As Excel.Worksheet = objLibroExcel.Worksheets(1)
            Dim objHojaAuxAlimentacionNoPropios As Excel.Worksheet = objLibroExcel.Worksheets(2)

            With objHojaAuxAlimentacion
                .Name = ("Aux. de Alimentación")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtAuxAlimentación.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtAuxAlimentación.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtAuxAlimentación.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtAuxAlimentación.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaAuxAlimentacionNoPropios
                .Name = ("Aux. de Alimentación No Propios")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtAuxAlimentacionNoPropio.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtAuxAlimentacionNoPropio.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtAuxAlimentacionNoPropio.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtAuxAlimentacionNoPropio.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 3 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            Dim objHojaAuxSinIncidencia As Excel.Worksheet = objLibroExcel.Worksheets(1)

            With objHojaAuxSinIncidencia
                .Name = ("Aux. Sin Incidencia")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtSinIncidencia.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtSinIncidencia.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtSinIncidencia.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtSinIncidencia.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 4 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            Dim objHojaBonoTecnico As Excel.Worksheet = objLibroExcel.Worksheets(1)
            Dim objHojaBonoTecnicoAllianz As Excel.Worksheet = objLibroExcel.Worksheets(2)
            Dim objHojaBonoTecnicoPrincipal As Excel.Worksheet = objLibroExcel.Worksheets(3)

            With objHojaBonoTecnico
                .Name = ("Aux. Bono técnico")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtBonoTecnico.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtBonoTecnico.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtBonoTecnico.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtBonoTecnico.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaBonoTecnicoAllianz
                .Name = ("Aux. Bono técnico Allianz")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtBonoTecnicoAllianz.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtBonoTecnicoAllianz.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtBonoTecnicoAllianz.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtBonoTecnicoAllianz.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaBonoTecnicoPrincipal
                .Name = ("Aux. Bono técnico Principal")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtBonoTecnicoPrincipal.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtBonoTecnicoPrincipal.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtBonoTecnicoPrincipal.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtBonoTecnicoPrincipal.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 5 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            Dim objHojaReporteIncapacidades As Excel.Worksheet = objLibroExcel.Worksheets(1)

            With objHojaReporteIncapacidades
                .Name = ("Reporte de Incapacidades")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtReporteIncapacidades.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtReporteIncapacidades.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtReporteIncapacidades.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtReporteIncapacidades.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 6 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            Dim objHojaViaticos As Excel.Worksheet = objLibroExcel.Worksheets(1)
            Dim objHojaDetallado As Excel.Worksheet = objLibroExcel.Worksheets(2)
            Dim objHojaConsolidado As Excel.Worksheet = objLibroExcel.Worksheets(3)

            With objHojaViaticos
                .Name = ("Viaticos")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtViaticos.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtViaticos.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtViaticos.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtViaticos.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaDetallado
                .Name = ("Detallado")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtViaticosDetallado.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtViaticosDetallado.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtViaticosDetallado.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtViaticosDetallado.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaConsolidado
                .Name = ("Consolidado gastos de viaje")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtConsolidadoViaticos.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtConsolidadoViaticos.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtConsolidadoViaticos.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtConsolidadoViaticos.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If

        If tipo = 7 Then

            Dim m_Excel As New Excel.Application
            m_Excel.Cursor = Excel.XlMousePointer.xlWait
            m_Excel.ScreenUpdating = False
            m_Excel.Visible = True
            Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            objLibroExcel.Worksheets.Add()
            Dim objHojaLiquidacion As Excel.Worksheet = objLibroExcel.Worksheets(1)
            Dim objHojaLiqTransporte As Excel.Worksheet = objLibroExcel.Worksheets(2)
            Dim objHojaLiqAlimentacion As Excel.Worksheet = objLibroExcel.Worksheets(3)
            Dim objHojaLiqSinIncidencia As Excel.Worksheet = objLibroExcel.Worksheets(4)
            Dim objHojaLiqBTecnico As Excel.Worksheet = objLibroExcel.Worksheets(5)
            Dim objHojaLiqIncapacidades As Excel.Worksheet = objLibroExcel.Worksheets(6)
            Dim objHojaLiqViaticos As Excel.Worksheet = objLibroExcel.Worksheets(7)

            With objHojaLiquidacion
                .Name = ("Sol. liq. Final Contrato")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiquidacion.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiquidacion.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiquidacion.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiquidacion.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaLiqTransporte
                .Name = ("Aux. Transporte")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiqTransporte.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiqTransporte.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiqTransporte.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiqTransporte.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaLiqAlimentacion
                .Name = ("Aux. Alimentación")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiqAlimentacion.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiqAlimentacion.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiqAlimentacion.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiqAlimentacion.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaLiqSinIncidencia
                .Name = ("Sin Incidencia")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiqSinIncidencia.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiqSinIncidencia.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiqSinIncidencia.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiqSinIncidencia.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaLiqBTecnico
                .Name = ("Bono Técnico")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiqBTecnico.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiqBTecnico.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiqBTecnico.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiqBTecnico.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaLiqIncapacidades
                .Name = ("Incapacidades")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiqIncapacidades.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiqIncapacidades.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiqIncapacidades.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiqIncapacidades.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            With objHojaLiqViaticos
                .Name = ("Viaticos")
                .Activate()
                .Cells.Select()
                .Cells.ClearContents()
                ' Seleccionamos la primera celda de la hoja.
                .Range("A1").Select()
                ' Escribimos los nombres de las columnas en la primera
                ' celda de la primera fila de la hoja de cálculo
                Dim fila As Integer = 1
                Dim columna As Integer = 1
                For Each dc As DataColumn In dtLiqViaticos.Columns
                    .Cells(fila, columna) = dc.ColumnName
                    columna += 1
                Next
                ' Establecemos los atributos de la fuente para las
                ' celdas de la primera fila.
                With .Range(.Cells(1, 1), .Cells(1, dtLiqViaticos.Columns.Count)).Font
                    .Name = "Calibri"
                    .Bold = True
                    .Size = 12
                End With
                ' Insertamos los datos en la hoja de cálculo, comenzando por la
                ' fila número 2, ya que la primera fila está ocupada
                ' por el nombre de las columnas.
                fila = 2
                For Each row As DataRow In dtLiqViaticos.Rows
                    ' Primera columna
                    columna = 1
                    For Each dc As DataColumn In dtLiqViaticos.Columns
                        .Cells(fila, columna) = row(dc.ColumnName)

                        ' Siguiente columna
                        columna += 1
                    Next
                    ' Siguiente fila
                    fila += 1
                Next
                ' Autoajustamos el ancho de todas las columnas utilizadas.
                .Columns().AutoFit()

            End With

            m_Excel.ScreenUpdating = True
            m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        End If
    End Sub

    Private Sub Nbi_RTxCodContrato_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RTxCodContrato.ItemClick

        Dim Consultar As New Boolean
        Dim Fr_CodContrato As New Form
        Dim Lb_CodContrato As New Label
        Dim tb_CodContrato As New TextBox
        Dim Bt_Aceptar As New Button
        Dim Bt_Cancelar As New Button

        With Lb_CodContrato
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 26)
            .Name = "Lb_CodContrato"
            .Size = New System.Drawing.Size(86, 13)
            .Text = "Código Contrato:"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With tb_CodContrato
            .Location = New System.Drawing.Point(139, 23)
            .Name = "Tb_CodContrato"
            .Size = New System.Drawing.Size(112, 20)
            .TabIndex = 2
        End With

        With Bt_Aceptar
            .Location = New System.Drawing.Point(156, 58)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 4
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(44, 58)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 5
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_CodContrato
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 8.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .AcceptButton = Bt_Aceptar
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(295, 106)
            .MaximumSize = New System.Drawing.Size(295, 136)
            .MinimumSize = New System.Drawing.Size(295, 136)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Código Contrato"
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(tb_CodContrato)
            .Controls.Add(Lb_CodContrato)
        End With


        AddHandler Bt_Aceptar.Click, Sub()

                                         If tb_CodContrato.Text = "" Then
                                             MsgBox("Debe ingresar el código de Contrato", MsgBoxStyle.Exclamation, "Código Contrato")
                                             tb_CodContrato.Focus()

                                         ElseIf MsgBox("Seguro desea exportar al excel", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then

                                             Consultar = True
                                             Fr_CodContrato.Close()
                                         End If
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()

                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                              Consultar = False
                                              Fr_CodContrato.Close()
                                          End If
                                      End Sub
        Fr_CodContrato.ShowDialog()

        If Consultar = True Then
            tb_CodContrato.Text.ToString()
            ExportarExcel_RDTrabajador(tb_CodContrato.Text)
        End If

    End Sub

    Public Sub ExportarExcel_RDTrabajador(ByVal CodContrato As Integer)

        Dim dtTrabajador As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ExpExc_RDTrabadorxCodContrato", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 0)
        comando.Parameters.AddWithValue("@CODIGOCONTRATO", CodContrato)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRD As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsRD)
            conexion.Close()
            If dsRD.Tables.Count > 0 Then
                dtTrabajador = dsRD.Tables(0)
            Else
                MsgBox("No hay datos para exportar .", MsgBoxStyle.Information, "Expotar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursospara exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaTrabajador As Excel.Worksheet = objLibroExcel.Worksheets(1)


        With objHojaTrabajador
            .Name = ("Reporte Diario del Trabajador")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtTrabajador.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtTrabajador.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtTrabajador.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtTrabajador.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
    Private Sub GenerarArchivosNomina(sender As Object, e As EventArgs) Handles Bt_GenerarSobretiempo.Click, Bt_AuxTransporte.Click, Bt_AuxAlimentacion.Click, _
            Bt_SinIncidencia.Click, Bt_BonoTecnico.Click, Bt_ReporteIncapacidades.Click, Bt_ControlViaticos.Click, Bt_SolicitudLiquidacion.Click

        Dim FechaI As Date
        Dim FechaF As Date
        Dim filas As DataRow()
        filas = Tperiodos.Select("IDPERIODONOMINA=" + Me.Cb_CorteNómina.SelectedValue.ToString)
        Dim fila As DataRow
        fila = filas(0)
        FechaI = CDate(fila("FECHAINICIO")).ToShortDateString
        FechaF = CDate(fila("FECHAFIN")).ToShortDateString

        comando = New SqlCommand("SELECT * FROM Informe_185(@IDBASESISCONTROL,@FECHAI,@FECHAF )", conexion)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@FECHAI", FechaI)
        comando.Parameters.AddWithValue("@FECHAF", FechaF)
        adaptador = New SqlDataAdapter(comando)
        Dim dtReportes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtReportes)
            conexion.Close()
            If dtReportes.Rows.Count > 0 Then
                MsgBox("Faltan personas por ser registradas en los reportes diarios de la base, Por favor agregarlos")
                Dim Opcion As Object
                Opcion = sender
                If MsgBox("¿Desea generar el archivo?", MsgBoxStyle.YesNo, "Generar el archivo") = MsgBoxResult.Yes Then
                    Windows.Forms.Cursor.Current = Cursors.WaitCursor
                    Select Case Opcion.name
                        Case "Bt_GenerarSobretiempo"
                            ExpExcelNomina(0)
                        Case "Bt_AuxTransporte"
                            ExpExcelNomina(1)
                        Case "Bt_AuxAlimentacion"
                            ExpExcelNomina(2)
                        Case "Bt_SinIncidencia"
                            ExpExcelNomina(3)
                        Case "Bt_BonoTecnico"
                            ExpExcelNomina(4)
                        Case "Bt_ReporteIncapacidades"
                            ExpExcelNomina(5)
                        Case "Bt_ControlViaticos"
                            ExpExcelNomina(6)
                        Case "Bt_SolicitudLiquidacion"
                            ExpExcelNomina(7)
                    End Select
                    Windows.Forms.Cursor.Current = Cursors.Default
                End If
            Else
                Dim Opcion As Object
                Opcion = sender
                If MsgBox("¿Desea generar el archivo?", MsgBoxStyle.YesNo, "Generar el archivo") = MsgBoxResult.Yes Then
                    Windows.Forms.Cursor.Current = Cursors.WaitCursor
                    Select Case Opcion.name
                        Case "Bt_GenerarSobretiempo"
                            ExpExcelNomina(0)
                        Case "Bt_AuxTransporte"
                            ExpExcelNomina(1)
                        Case "Bt_AuxAlimentacion"
                            ExpExcelNomina(2)
                        Case "Bt_SinIncidencia"
                            ExpExcelNomina(3)
                        Case "Bt_BonoTecnico"
                            ExpExcelNomina(4)
                        Case "Bt_ReporteIncapacidades"
                            ExpExcelNomina(5)
                        Case "Bt_ControlViaticos"
                            ExpExcelNomina(6)
                        Case "Bt_SolicitudLiquidacion"
                            ExpExcelNomina(7)
                    End Select
                    Windows.Forms.Cursor.Current = Cursors.Default
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TSMI_ClonarReporte_Click(sender As Object, e As EventArgs) Handles TSMI_ClonarReporte.Click
        If tabla_cargada <> "Reporte" Then
            MsgBox("Debe cargar la tabla de reportes para continuar")
        Else
            Try
                Me.ReactivarPrincipal = False
                Me.Cursor = Cursors.WaitCursor
                Dim IndiceFilaseleccionada As Integer = Dgv_Reportes.CurrentRow.Index
                Dim FrReporteDiario As New FormularioReporteDiario.Fr_ModificarReporte
                FrReporteDiario.IdReporteDiario_Modificar = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells(0).Value
                Dim IdbaseReporte As Integer
                IdbaseReporte = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value
                If IdbaseReporte <> VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                    MsgBox("No se puede clonar reportes desde una base diferente a la que corresponde")
                    Exit Sub
                End If
                Index_Registro_Actual = Me.Dgv_Reportes.CurrentCell.RowIndex
                FrReporteDiario.TipoAccion = "E"
                FrReporteDiario.Cargar_Tablas()
                FrReporteDiario.CargarValores()
                FrReporteDiario.CargarDatosReporteDiario()
                FrReporteDiario.AplicarFormatoColumnas()
                FrReporteDiario.TipoAccion = "I"
                FrReporteDiario.LimpiarXClonación()
                Me.Cursor = Cursors.Default
                FrReporteDiario.Cu_padre = New Object
                FrReporteDiario.Cu_padre = Me
                FrReporteDiario.Show()
                Me.ReactivarPrincipal = True
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
            End Try
        End If
    End Sub

    Private Sub Bt_PerPendReportar_Click(sender As Object, e As EventArgs) Handles Bt_PerPendReportar.Click
        Dim FechaI As Date
        Dim FechaF As Date
        Dim filas As DataRow()
        filas = Tperiodos.Select("IDPERIODONOMINA=" + Me.Cb_CorteNómina.SelectedValue.ToString)
        Dim fila As DataRow
        fila = filas(0)
        FechaI = CDate(fila("FECHAINICIO")).ToShortDateString
        FechaF = CDate(fila("FECHAFIN")).ToShortDateString

        comando = New SqlCommand("SELECT * FROM Informe_185(@IDBASESISCONTROL,@FECHAI,@FECHAF )", conexion)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@FECHAI", FechaI)
        comando.Parameters.AddWithValue("@FECHAF", FechaF)
        adaptador = New SqlDataAdapter(comando)
        Dim dtReportes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtReportes)
            conexion.Close()
            If dtReportes.Rows.Count > 0 Then
                Dgv_Reportes.DataSource = dtReportes
                'Dgv_Prorrogas.AutoResizeColumns()
                Lb_CantidadReportes.Text = "Cantidad de Personas que faltan por Reportar: " & dtReportes.Rows.Count
            Else
                If Not IsNothing(Dgv_Reportes.DataSource) Then
                    Dgv_Reportes.DataSource.Clear()
                End If
                Lb_CantidadReportes.Text = "Cantidad de Personas que faltan por Reportar: " & dtReportes.Rows.Count
            End If
        Catch
            conexion.Close()
            If Not IsNothing(Dgv_Reportes.DataSource) Then
                Dgv_Reportes.DataSource.Clear()
            End If
        End Try
        For i = 0 To Dgv_Reportes.ColumnCount - 1
            Select Case Dgv_Reportes.Columns(i).Name
                Case "Código Contrato"
                    Dgv_Reportes.Columns(i).HeaderText = "Cód"
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Nombre Completo"
                    Dgv_Reportes.Columns(i).HeaderText = "Nombre Completo"
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Cargo"
                    Dgv_Reportes.Columns(i).HeaderText = "Cargo"
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "FECHAREPORTE"
                    Dgv_Reportes.Columns(i).HeaderText = "Fecha Pend. de Reporte"
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Reportes.Columns(i).ToolTipText = "Fecha Pendiente de Reporte"
                Case "Fecha Terminación"
                    Dgv_Reportes.Columns(i).HeaderText = "Fecha Terminación"
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Estado"
                    Dgv_Reportes.Columns(i).HeaderText = "Estado"
                    Dgv_Reportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Reportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    Dgv_Reportes.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub Nbi_Habilitar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Habilitar.ItemClick
        If Me.Dgv_Reportes.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If MsgBox("¿Seguro que desea habilitar los reportes seleccionados para edición?", MsgBoxStyle.YesNo, "Habilitar Reporte") = MsgBoxResult.Yes Then
            Dim TablaId As New DataTable
            TablaId.Columns.Add("Id", System.Type.GetType("System.Int32"))
            For i = 0 To Dgv_Reportes.SelectedRows.Count - 1
                Dim fila As DataRow
                fila = TablaId.NewRow
                fila("Id") = Dgv_Reportes.SelectedRows(i).Cells(0).Value
                TablaId.Rows.Add(fila)
            Next
            'Llamar al procedimiento para crear el tipo categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.HabilitarRD")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TIPO", 1)
            Comando.Parameters.AddWithValue("@TABLAIDOT", TablaId)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Try
                conn.Open()
                Comando.Connection = conn
                Comando.ExecuteNonQuery()
                conn.Close()
                MsgBox("Reportes habilitados", MsgBoxStyle.Information)
                Cargar_Tabla()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub RegistrarNovedadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarNovedadToolStripMenuItem.Click
        If Me.Dgv_ListaIntegrantes.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If Me.Dgv_Reportes.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        '
        Try
            Me.ReactivarPrincipal = False
            Me.Cursor = Cursors.WaitCursor
            Dim IndiceFilaseleccionada As Integer = Dgv_Reportes.CurrentRow.Index
            Dim FrReporteDiario As New FormularioReporteDiario.Fr_ModificarReporte
            FrReporteDiario.IdReporteDiario_Modificar = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells(0).Value
            Dim IdbaseReporte As Integer
            IdbaseReporte = Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value
            If IdbaseReporte <> VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                MsgBox("No se puede registrar novedades desde una base diferente a la que corresponde")
                Exit Sub
            End If
            Index_Registro_Actual = Me.Dgv_Reportes.CurrentCell.RowIndex
            FrReporteDiario.Lb_ReporteEditando.Visible = True
            FrReporteDiario.Lb_ReporteEditando.Text = "RD: " + Me.Dgv_Reportes.Rows(IndiceFilaseleccionada).Cells("Reporte Diario").Value
            FrReporteDiario.TipoAccion = "N"
            IndiceFilaseleccionada = Dgv_ListaIntegrantes.CurrentRow.Index
            FrReporteDiario.IdContratoReporteDiario_Modificar = Me.Dgv_ListaIntegrantes.Rows(IndiceFilaseleccionada).Cells("IDCONTRATO").Value

            FrReporteDiario.Cargar_Tablas()
            FrReporteDiario.CargarValores()
            FrReporteDiario.CargarDatosReporteDiario()
            FrReporteDiario.AplicarFormatoColumnas()
            FrReporteDiario.RegistrarNovedad()
            Me.Cursor = Cursors.Default
            FrReporteDiario.Cu_padre = New Object
            FrReporteDiario.Cu_padre = Me
            FrReporteDiario.Show()
        Catch ex As Exception
            MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
        End Try


    End Sub


    Private Sub Nbi_ImprimirCEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirCEquipo.ItemClick

        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Tipo = "E"
        FrExportarxOM.TablaIdE.Columns.Add("CODIGOEQUIPO", System.Type.GetType("System.String"))
        If Me.Dgv_ListaEquipos.SelectedRows.Count > 0 Then
            For i = 0 To Dgv_ListaEquipos.SelectedRows.Count - 1
                Dim fila As DataRow
                fila = FrExportarxOM.TablaIdE.NewRow
                fila("CODIGOEQUIPO") = Dgv_ListaEquipos.SelectedRows(i).Cells("DGVTBC_CEQUIPO").Value
                FrExportarxOM.TablaIdE.Rows.Add(fila)
            Next
        End If

        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()

        'Dim clImpresion As New ImprimirControlProyecto.Cl_Impresión
        'Dim arrayDocumentos As New ArrayList
        'arrayDocumentos.Add(16)
        'clImpresion.ImprimirFormatos(arrayDocumentos, True, True) 'Impresión a doble cara.
    End Sub
End Class 'Cu_ReporteDiario


Friend Class Reporte
    Private _Id As Integer
    Private _Consecutivo As String
    Private _BaseNombre As String
    Private _BaseAbrev As String
    Private _JefeCuadrilla As String
    Private _ReporteDiario As String
    Private _FechaReporte As DateTime
    Private _CentroCosto As String
    Private _Disciplina As String
    Private _Tiempo As String
    Private _Paro As String
    Private _InicioParo As DateTime
    Private _FinParo As DateTime
    Private _FrenteTrabajo As String
    Private _Administrador As String
    Private _Superintendente As String
    Private _DirectorObra As String
    Private _UsuarioRegistra As String
    Private _FechaRegistro As DateTime
    Private _UsuarioModifica As String
    Private _FechaModificacion As DateTime
    Private _AprobadoEnvio As String
    Private _Revisado As String
    Private _Cerrado As String

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Id Reporte")> _
    Public ReadOnly Property Id() As String
        Get
            Return _Id
        End Get
    End Property

    <Description("Número siguiente que tiene el reporte del tiempo"), _
    Category(""),
    DisplayNameAttribute("Consecutivo")> _
    Public ReadOnly Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Nombre Base")> _
    Public ReadOnly Property NBase() As String
        Get
            Return _BaseNombre
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Abreviatura Base")> _
    Public ReadOnly Property ABase() As String
        Get
            Return _BaseAbrev
        End Get
    End Property

    <Description("Persona jefe de cuadrilla"), _
    Category("Persona"),
    DisplayNameAttribute("Jefe Cuadrilla")> _
    Public ReadOnly Property JCuadrilla() As String
        Get
            Return _JefeCuadrilla
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Reporte Diario")> _
    Public ReadOnly Property RDiario() As String
        Get
            Return _ReporteDiario
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Fecha Reporte Diario")> _
    Public ReadOnly Property FRDiario() As String
        Get
            Return _FechaReporte
        End Get
    End Property

    <Description("Lugar de ubicación"), _
    Category(""),
    DisplayNameAttribute("Centro de Costo")> _
    Public ReadOnly Property CentroCosto() As String
        Get
            Return _CentroCosto
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Disciplina")> _
    Public ReadOnly Property Disciplina() As String
        Get
            Return _Disciplina
        End Get
    End Property

    <Description("Condicion climatologica del dia(LLuvia, Sol, Tormenta, etc"), _
    Category(""),
    DisplayNameAttribute("Tiempo")> _
    Public ReadOnly Property Tiempo() As String
        Get
            Return _Tiempo
        End Get
    End Property

    <Description("Razon por la que se detiene las labores"), _
    Category("Paro"),
    DisplayNameAttribute("Paro")> _
    Public ReadOnly Property Paro() As String
        Get
            Return _Paro
        End Get
    End Property

    <Description("Hora de inicio de paro"), _
    Category("Paro"),
    DisplayNameAttribute("Inicio Paro")> _
    Public ReadOnly Property Inicio() As String
        Get
            Return _InicioParo
        End Get
    End Property

    <Description("Hora de Fin del paro"), _
    Category("Paro"),
    DisplayNameAttribute("Fin Paro")> _
    Public ReadOnly Property Fin() As String
        Get
            Return _InicioParo
        End Get
    End Property

    <Description("Lugar donde se desarrolla la actividad laboral"), _
    Category(""),
    DisplayNameAttribute("Frente Trabajo")> _
    Public ReadOnly Property FTrabajo() As String
        Get
            Return _FrenteTrabajo
        End Get
    End Property

    <Description("Administrador de la obra"), _
    Category("Persona"),
    DisplayNameAttribute("Administrador")> _
    Public ReadOnly Property Administrador() As String
        Get
            Return _Administrador
        End Get
    End Property

    <Description("Superintendente de la obra"), _
    Category("Persona"),
    DisplayNameAttribute("Superintendente")> _
    Public ReadOnly Property Superintendente() As String
        Get
            Return _Superintendente
        End Get
    End Property

    <Description("Director de la obra"), _
    Category("Persona"),
    DisplayNameAttribute("Director Obra")> _
    Public ReadOnly Property DirectorObra() As String
        Get
            Return _DirectorObra
        End Get
    End Property

    <Description("Usuario quien registra el reporte del tiempo"), _
    Category("Control"),
    DisplayNameAttribute("Usuario Registra")> _
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description("Fecha de registro del reporte del tiempo"), _
    Category("Control"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Usuario que modifica el repòrte del tiempo"), _
    Category("Control"),
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description("Fecha de modificación del reporte del tiempo"), _
    Category("Control"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property fechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Envio Aprobado")> _
    Public ReadOnly Property AprobEnvio() As String
        Get
            Return _AprobadoEnvio
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Revisado")> _
    Public ReadOnly Property revisado() As String
        Get
            Return _Revisado
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Cerrado")> _
    Public ReadOnly Property Cerrado() As String
        Get
            Return _Cerrado
        End Get
    End Property

    Public Sub New(ByVal FilaReporte As DataGridViewRow)
        Try
            _Id = FilaReporte.Cells("Id").Value
        Catch
            _Id = ""
        End Try

        Try
            _Consecutivo = FilaReporte.Cells("Consecutivo").Value
        Catch
            _Consecutivo = ""
        End Try

        Try
            _BaseNombre = FilaReporte.Cells("Nombre Base").Value
        Catch

            _BaseNombre = ""
        End Try

        Try
            _BaseAbrev = FilaReporte.Cells("Abreviatura Base").Value
        Catch

            _BaseAbrev = ""
        End Try

        Try
            _JefeCuadrilla = FilaReporte.Cells("Jefe Cuadrilla").Value
        Catch

            _JefeCuadrilla = ""
        End Try

        Try
            _ReporteDiario = FilaReporte.Cells("Reporte Diario").Value
        Catch

            _ReporteDiario = ""
        End Try

        Try
            _FechaReporte = FilaReporte.Cells("Fecha Reporte").Value
        Catch

            _FechaReporte = ""
        End Try

        Try
            _CentroCosto = FilaReporte.Cells("CentroCosto").Value
        Catch
            _CentroCosto = 0
        End Try

        Try
            _Disciplina = FilaReporte.Cells("Disciplina").Value
        Catch
            _Disciplina = 0
        End Try

        Try
            _Tiempo = FilaReporte.Cells("Tipo Tiempo").Value
        Catch
            _Tiempo = 0
        End Try

        Try
            _Paro = FilaReporte.Cells("Tipo Paro").Value
        Catch
            _Paro = 0
        End Try

        Try
            _InicioParo = FilaReporte.Cells("Hora Inicio").Value
        Catch
            _InicioParo = Nothing
        End Try

        Try
            _FinParo = FilaReporte.Cells("Hora Fin").Value
        Catch
            _FinParo = Nothing
        End Try

        Try
            _FrenteTrabajo = FilaReporte.Cells("Frente Trabajo").Value
        Catch
            _FrenteTrabajo = 0
        End Try

        Try
            _Administrador = FilaReporte.Cells("Administrador").Value
        Catch
            _Administrador = 0
        End Try

        Try
            _Superintendente = FilaReporte.Cells("Superintendente").Value
        Catch
            _Superintendente = 0
        End Try

        Try
            _DirectorObra = FilaReporte.Cells("Director Obra").Value
        Catch
            _DirectorObra = 0
        End Try

        Try
            _UsuarioRegistra = FilaReporte.Cells("Usuario Registra").Value
        Catch
            _UsuarioRegistra = 0
        End Try

        Try
            _FechaRegistro = FilaReporte.Cells("Fecha Registro").Value
        Catch
            _FechaRegistro = Nothing
        End Try

        Try
            _UsuarioModifica = FilaReporte.Cells("usuario Modifica").Value
        Catch
            _UsuarioModifica = 0
        End Try

        Try
            _FechaModificacion = FilaReporte.Cells("Fecha Modificación").Value
        Catch
            _FechaModificacion = Nothing
        End Try

        Try
            _AprobadoEnvio = FilaReporte.Cells("Envío Aprobado").Value
        Catch
            _AprobadoEnvio = Nothing
        End Try

        Try
            _Revisado = FilaReporte.Cells("Revisado").Value
        Catch
            _Revisado = Nothing
        End Try

        Try
            _Cerrado = FilaReporte.Cells("Cerrado").Value
        Catch
            _Cerrado = Nothing
        End Try
    End Sub
End Class 'Reporte


Friend Class Cuadrilla
    Private _Id As Integer
    Private _Base As String
    Private _Nombre As String
    Private _Estado As String
    Private _UsuarioRegistra As String
    Private _FechaRegistro As DateTime
    Private _UsuarioModifica As String
    Private _FechaModifica As DateTime

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Id Cuadrilla")> _
    Public ReadOnly Property Id() As String
        Get
            Return _Id
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Base")> _
    Public ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Nombre Cuadrilla")> _
    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("Estado")> _
    Public ReadOnly Property Estado() As String
        Get
            Return _Estado
        End Get
    End Property

    <Description(""), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Registro")> _
    Public ReadOnly Property URegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description(""), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FRegistra() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description(""), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description(""), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Modifica")> _
    Public ReadOnly Property FModifica() As String
        Get
            Return _FechaModifica
        End Get
    End Property

    Public Sub New(ByVal FilaCuadrilla As DataGridViewRow)
        Try
            _Id = FilaCuadrilla.Cells("Id").Value
        Catch
            _Id = ""
        End Try

        Try
            _Base = FilaCuadrilla.Cells("Base").Value
        Catch
            _Base = ""
        End Try

        Try
            _Nombre = FilaCuadrilla.Cells("Nombre Cuadrilla").Value
        Catch
            _Nombre = ""
        End Try

        Try
            _Estado = FilaCuadrilla.Cells("Estado").Value
        Catch
            _Estado = ""
        End Try

        Try
            _UsuarioRegistra = FilaCuadrilla.Cells("Registra").Value
        Catch
            _UsuarioRegistra = ""
        End Try

        Try
            _FechaRegistro = FilaCuadrilla.Cells("F Registro").Value
        Catch
            _FechaRegistro = ""
        End Try

        Try
            _UsuarioModifica = FilaCuadrilla.Cells("Usuario Modifica").Value
        Catch
            _UsuarioModifica = ""
        End Try

        Try
            _FechaModifica = FilaCuadrilla.Cells("Fecha Modifica").Value
        Catch
            _FechaModifica = ""
        End Try
    End Sub

End Class 'Cuadrilla