Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class Cu_Hse

    Dim dsReportes24H As New DataSet
    Dim dsReportesINV As New DataSet
    Dim dsResumenEst As New DataSet
    Dim dsExamenes As New DataSet

    Private bddatos As New DatosClasesBase.Busquedas
    Dim Index_Registro_Actual As Integer = -1

    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Public Enum Tablas
        REPORTES24H
        REPORTESINVESTIGACION
        RESUMENESTADISTICO
        EXAMENESMEDICOS
    End Enum

    Private tablacargada As Tablas

    Private Sub Cu_Hse_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.SplitContainer1.SplitterDistance = Me.Width * 0.7
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Comportamiento_Predeterminado()
        'tablacargada = Tablas.REPORTES24H
        DGV_ListaReportes.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        DGV_ListaReportes.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Reportes.Tag) Then
            Nbc_HSE.ActiveGroup = Nbg_Reportes
            'Poner Texto a etiqueta 
            Lb_Cargado.Text = "Reportes 24 horas"
        Else
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ExamenMedico.Tag) Then
                Nbc_HSE.ActiveGroup = Nbg_ExamenMedico
                'Poner Texto a etiqueta 
                Lb_Cargado.Text = "Exámenes médicos periódicos"
                CargarTablaxDefectoExamenes()
            End If
        End If

        'Reporte 24 Horas
        Nbg_Reportes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Reportes.Tag)
        Nbi_CargarReporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarReporte.Tag)
        Nbi_CrearReporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearReporte.Tag)
        Nbi_VerReporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerReporte.Tag)
        Nbi_EditarReporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarReporte.Tag)
        Nbi_GenerarInvestigacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_GenerarInvestigacion.Tag)
        Nbi_BuscarReporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarReporte.Tag)
        Nbi_ImprimirReporte.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirReporte.Tag)
        Nbi_HablitarImpresionR24.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HablitarImpresionR24.Tag)
        Nbi_AsociarUsuarioBaseHSE.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AsociarUsuarioBaseHSE.Tag)

        'Reporte Investigacion
        Nbg_Investigaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Investigaciones.Tag)
        Nbi_CargarInvestigaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarInvestigaciones.Tag)
        Nbi_VerInvestigacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerInvestigacion.Tag)
        Nbi_EditarInvestigacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarInvestigacion.Tag)
        Nbi_BuscarInvestigacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarInvestigacion.Tag)
        Nbi_ImprimirInvestigacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirInvestigacion.Tag)
        Nbi_HabilitarImpresionInvestigacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresionInvestigacion.Tag)
        Nbi_ImprimirAlertaSeguridad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirAlertaSeguridad.Tag)
        'Resumen Estadistico
        Nbg_ResumenEstadistico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ResumenEstadistico.Tag)
        Nbi_CargarResumenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarResumenes.Tag)
        Nbi_VerResumen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerResumen.Tag)
        Nbi_RegistrarResumenEstadistico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarResumenEstadistico.Tag)
        Nbi_BuscarResumenEstadistico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarResumenEstadistico.Tag)
        Nbi_EditarResumen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarResumen.Tag)
        Nbi_HabilitarEdicion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarEdicion.Tag)
        Nbi_ExportarResumenBase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarResumenBase.Tag)
        Nbi_ExportarResumenIsmocol.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarResumenIsmocol.Tag)
        Nbi_ResumenEstidisticoProyecto.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ResumenEstidisticoProyecto.Tag)

        'Examenes Medicos Periodicos
        Nbg_ExamenMedico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ExamenMedico.Tag)
        Nbi_CargarExamenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarExamenes.Tag)
        Nbi_RegistrarExamen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarExamen.Tag)
        Nbi_VerExamen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerExamen.Tag)
        Nbi_EditarExamen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarExamen.Tag)
        Nbi_BuscarExamen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarExamen.Tag)
        Nbi_RegistrarConcepto.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarConcepto.Tag)
        Nbi_ImprimirConceptoMedico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirConceptoMedico.Tag)
        Nbi_HabilitarImpresionConcepto.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresionConcepto.Tag)
        Nbi_EditarConcepto.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarConcepto.Tag)
        Nbi_InformeCondicionesSalud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_InformeCondicionesSalud.Tag)
        Nbi_SubirPdfEM.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfEM.Tag)
        Nbi_VerPdfEM.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfEM.Tag)
        Nbi_ImprimirHC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirHC.Tag)
        Nbi_BuscarEnfermedades.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEnfermedades.Tag)

    End Sub
    Private Sub Cu_HSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
#Region "Cargar Tablas"

    Public Sub Cargar_Tabla()

        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Reportes.Tag) Then
            'Poner Texto a etiqueta 
            Lb_Cargado.Text = "Reportes 24 horas"
            CargarTablaxDefectoReportes24H()
        Else
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ExamenMedico.Tag) Then
                'Poner Texto a etiqueta 
                Lb_Cargado.Text = "Exámenes médicos"
                CargarTablaxDefectoExamenes()
            End If
        End If
    End Sub

    Private Sub CargarTablaxDefectoReportes24H()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dsReportes24H = bddatos.BusquedaCondiciones(55, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsReportes24H.Tables.Count > 1 Then  'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsReportes24H.Tables.Remove(dsReportes24H.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsReportes24H.Clear()
        End If
        tablacargada = Tablas.REPORTES24H
        Lb_Cargado.Text = "Reportes 24 horas"
        Lb_Filtro.Text = "Reportes 24 horas"
        CargarReporte24HFiltro(dsReportes24H)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub CargarTablaxDefectoReportesInvestigacion()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dsReportesINV = bddatos.BusquedaCondiciones(56, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsReportesINV.Tables.Count > 1 Then  'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsReportesINV.Tables.Remove(dsReportesINV.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsReportesINV.Clear()
        End If
        tablacargada = Tablas.REPORTESINVESTIGACION
        Lb_Cargado.Text = "Reportes de investigación"
        Lb_Filtro.Text = "Reportes de investigación"
        CargarReporteInvFiltro(dsReportesINV)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub CargarTablaxDefectoResumenEstadistico()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dsResumenEst = bddatos.BusquedaCondiciones(57, 1, 4, 1, "", 0, Date.Now, Date.Now, 0, 20)
        If dsResumenEst.Tables.Count > 1 Then  'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsResumenEst.Tables.Remove(dsResumenEst.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsResumenEst.Clear()
        End If
        tablacargada = Tablas.RESUMENESTADISTICO
        Lb_Cargado.Text = "Datos Para Resumen Estadístico"
        Lb_Filtro.Text = "Resumen Estadístico"
        CargarResumenEstadisticoFiltro(dsResumenEst)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "Reporte24H"

    Private Sub Nbi_CrearReporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearReporte.ItemClick
        CrearReporte24H()
    End Sub

    Private Sub CrearReporte24H()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim FrCrearReporte24H As New FormulariosHse.Fr_CrearReporte24H
        FrCrearReporte24H.TIPO = 1
        FrCrearReporte24H.EDITANDO = False
        FrCrearReporte24H.guardado = False
        FrCrearReporte24H.CargarTablas()
        FrCrearReporte24H.ComportamientoPredeterminado()
        FrCrearReporte24H.ShowDialog()
        System.Windows.Forms.Cursor.Current = Cursors.Default
        If FrCrearReporte24H.guardado Then
            CargarTablaxDefectoReportes24H()
        End If

    End Sub

    Private Sub Nbi_CargarReporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarReporte.ItemClick
        CargarTablaxDefectoReportes24H()
    End Sub

    Private Sub Nbi_VerReporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerReporte.ItemClick
        If tablacargada = Tablas.REPORTES24H Then
            VerReporte()

        Else
            MsgBox("No está cargada la tabla de reportes 24 horas")
        End If
    End Sub

    Private Sub VerReporte()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then

            Dim VerReporte As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerReporte.Tag) = True Then
                'Puede ver de todo ismocol
                If FuncionesBase.FuncionesBase.ConsultarPermiso(922) Then
                    VerReporte = True
                Else
                    'Puede ver de las bases asociadas
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(921) Then
                        Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                        comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                        Dim adaptador As New SqlDataAdapter(comando)
                        Dim dtBases = New System.Data.DataTable
                        Try
                            conexion.Open()
                            adaptador.Fill(dtBases)
                            conexion.Close()
                        Catch ex As Exception
                            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        For i As Integer = 0 To dtBases.Rows.Count - 1
                            If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                VerReporte = True
                                Exit For
                            End If
                        Next
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(923) Then
                            Dim IDRegistro As Integer = Me.DGV_ListaReportes.Item("IDPERSONAREGISTRA", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                            If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                'VerReporte = True
                                Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                                comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                                Dim adaptador As New SqlDataAdapter(comando)
                                Dim dtBases = New System.Data.DataTable
                                Try
                                    conexion.Open()
                                    adaptador.Fill(dtBases)
                                    conexion.Close()
                                Catch ex As Exception
                                    MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                                For i As Integer = 0 To dtBases.Rows.Count - 1
                                    If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                        VerReporte = True
                                        Exit For
                                    End If
                                Next
                            Else
                                VerReporte = False
                            End If
                        Else
                            VerReporte = False
                        End If
                    End If

                End If
            End If


            If VerReporte = True Then


                Dim FrReporte24H As New FormulariosHse.Fr_CrearReporte24H
                FrReporte24H.Text = "Viendo el reporte: " + Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString
                FrReporte24H.TIPO = 2
                FrReporte24H.EDITANDO = False
                FrReporte24H.IDREPORTEMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SALUD" Then
                    FrReporte24H.TIPOINCIDENTE = 1
                Else
                    If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SEGURIDAD" Then
                        FrReporte24H.TIPOINCIDENTE = 2
                    Else
                        If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "AMBIENTAL" Then
                            FrReporte24H.TIPOINCIDENTE = 3
                        Else
                            If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "CASI-ACCIDENTE" Then
                                FrReporte24H.TIPOINCIDENTE = 4
                            End If
                        End If
                    End If
                End If

                FrReporte24H.CargarTablas()
                FrReporte24H.ComportamientoPredeterminado()
                FrReporte24H.LlenarReporte()
                FrReporte24H.Bt_Guardar.Enabled = False
                FrReporte24H.ShowDialog()
                System.Windows.Forms.Cursor.Current = Cursors.Default
            Else
                MsgBox("No cuenta con los permisos para ver")
            End If

        End If
    End Sub

    Private Sub Nbi_EditarReporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarReporte.ItemClick
        If tablacargada = Tablas.REPORTES24H Then
            If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                Dim verificar As Integer = VerificarCrearInvestigacion(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value)
                If verificar > 0 Then
                    MsgBox("No se puede editar un reporte 24 horas que ya tiene una investigación en curso.", MsgBoxStyle.Information, "Investigación en curso")
                    Exit Sub
                End If
                EditarReporte24H()
            Else
                MsgBox("El reporte " + Trim(Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " ya fue impreso y no se puede editar", vbCritical, "Reporte 24 Horas")
                Exit Sub
            End If
        Else
            MsgBox("No está cargada la tabla de reportes 24 horas")
        End If
    End Sub

    Private Sub EditarReporte24H()
        Dim EditarReporte As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerReporte.Tag) = True Then
            'Puede ver de todo ismocol
            If FuncionesBase.FuncionesBase.ConsultarPermiso(919) Then
                EditarReporte = True
            Else
                'Puede ver de las bases asociadas
                If FuncionesBase.FuncionesBase.ConsultarPermiso(918) Then
                    Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                    comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim dtBases = New System.Data.DataTable
                    Try
                        conexion.Open()
                        adaptador.Fill(dtBases)
                        conexion.Close()
                    Catch ex As Exception
                        MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    For i As Integer = 0 To dtBases.Rows.Count - 1
                        If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                            EditarReporte = True
                            Exit For
                        End If
                    Next
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(920) Then
                        Dim IDRegistro As Integer = Me.DGV_ListaReportes.Item("IDPERSONAREGISTRA", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                            Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                            comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                            Dim adaptador As New SqlDataAdapter(comando)
                            Dim dtBases = New System.Data.DataTable
                            Try
                                conexion.Open()
                                adaptador.Fill(dtBases)
                                conexion.Close()
                            Catch ex As Exception
                                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                            For i As Integer = 0 To dtBases.Rows.Count - 1
                                If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                    EditarReporte = True
                                    Exit For
                                End If
                            Next
                        Else
                            EditarReporte = False
                        End If
                    Else
                        EditarReporte = False
                    End If
                End If
            End If
        End If

        If EditarReporte = True Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim FrReporte24H As New FormulariosHse.Fr_CrearReporte24H
            FrReporte24H.TIPO = 2
            FrReporte24H.EDITANDO = True
            FrReporte24H.IDREPORTEMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
            If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SALUD" Then
                FrReporte24H.TIPOINCIDENTE = 1
            Else
                If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SEGURIDAD" Then
                    FrReporte24H.TIPOINCIDENTE = 2
                Else
                    If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "AMBIENTAL" Then
                        FrReporte24H.TIPOINCIDENTE = 3
                    Else
                        If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "CASI ACCIDENTE" Then
                            FrReporte24H.TIPOINCIDENTE = 4
                        End If
                    End If
                End If
            End If

            FrReporte24H.CargarTablas()
            FrReporte24H.ComportamientoPredeterminado()
            FrReporte24H.LlenarReporte()
            FrReporte24H.ShowDialog()
            System.Windows.Forms.Cursor.Current = Cursors.Default
            If FrReporte24H.guardado Then
                CargarTablaxDefectoReportes24H()
            End If
        Else
            MsgBox("No cuenta con los permisos para editar")
        End If

    End Sub

#End Region

#Region "ReporteInvestigacion"

    Private Function VerificarCrearInvestigacion(ByVal IdReporte24H)
        Dim Resultado As Integer
        Dim Cadena_Consulta3 As String = "SELECT COUNT(RINV.IDREPORTE24H) FROM HSE_REPORTEINVESTIGACION as RINV WHERE RINV.IDREPORTE24H = @IdReporte24H"
        Dim Consulta3 As New SqlClient.SqlCommand(Cadena_Consulta3)
        'Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Consulta3.Parameters.AddWithValue("@IdReporte24H", IdReporte24H)
        Consulta3.Connection = conexion
        Consulta3.Connection.Open()
        Resultado = Consulta3.ExecuteScalar()
        Consulta3.Connection.Close()
        Return Resultado
    End Function

    Private Sub Nbi_GenerarInvestigacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_GenerarInvestigacion.ItemClick
        If tablacargada = Tablas.REPORTES24H Then
            'Dim Impreso As String = Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
            'If Impreso = "N" Then
            '    MsgBox("Para poder Abrir una invetigación el reporte 24 horas debe haber sido impreso.", MsgBoxStyle.Exclamation, "Error al abrir investigación")
            '    Exit Sub
            'End If
            Dim crear As Integer
            Try
                crear = VerificarCrearInvestigacion(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value)
            Catch ex As Exception
                crear = 0
                'MsgBox("Debe seleccionar algun Reporte 24 Horas para poder Abrir una invetigación")
                MsgBox("Debe seleccionar algun Reporte 24 Horas para poder Abrir una invetigación.", MsgBoxStyle.Exclamation, "Error al abrir investigación")
            End Try
            If crear <> 0 Then
                MsgBox("Ya hay una investigacion perteneciente al reporte 24 horas: " + Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value)
                Exit Sub
            End If
            If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Dim FrCrearInvestigacion As New FormulariosHse.Fr_CrearInvestigacion
                FrCrearInvestigacion.TIPO = 1
                FrCrearInvestigacion.IDREPORTEMODIFICANDO = -1
                FrCrearInvestigacion.guardado = False
                FrCrearInvestigacion.EDITANDO = False
                FrCrearInvestigacion.IDREPORTE24H = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "SALUD" Then
                    FrCrearInvestigacion.TIPOINCIDENTE = 1
                Else
                    If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "SEGURIDAD" Then
                        FrCrearInvestigacion.TIPOINCIDENTE = 2
                    Else
                        If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "AMBIENTAL" Then
                            FrCrearInvestigacion.TIPOINCIDENTE = 3
                        Else
                            If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "CASI-ACCIDENTE" Then
                                FrCrearInvestigacion.TIPOINCIDENTE = 4
                            End If
                        End If
                    End If
                End If

                FrCrearInvestigacion.CargarTablas()
                FrCrearInvestigacion.ComportamientoPredeterminado()
                FrCrearInvestigacion.LlenarReporte()
                FrCrearInvestigacion.ShowDialog()
                System.Windows.Forms.Cursor.Current = Cursors.Default
                If FrCrearInvestigacion.guardado Then
                    CargarTablaxDefectoReportesInvestigacion()
                End If
            End If
        Else
            MsgBox("No está cargada la tabla de reportes 24 horas")
            System.Windows.Forms.Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub Nbi_VerInvestigacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerInvestigacion.ItemClick
        If tablacargada = Tablas.REPORTESINVESTIGACION Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(927) Or FuncionesBase.FuncionesBase.ConsultarPermiso(928) Or FuncionesBase.FuncionesBase.ConsultarPermiso(929) Then
                VerReporteInvestigacion()
            Else
                MsgBox("No cuenta con los permisos para ver")
            End If
        Else
            MsgBox("No está cargada la tabla de investigaciones")
        End If
    End Sub

    Private Sub VerReporteInvestigacion()
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Dim VerReporte As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerInvestigacion.Tag) = True Then
                'Puede ver de todo ismocol
                If FuncionesBase.FuncionesBase.ConsultarPermiso(928) Then
                    VerReporte = True
                Else
                    'Puede ver de las bases asociadas
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(927) Then
                        Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                        comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                        Dim adaptador As New SqlDataAdapter(comando)
                        Dim dtBases = New System.Data.DataTable
                        Try
                            conexion.Open()
                            adaptador.Fill(dtBases)
                            conexion.Close()
                        Catch ex As Exception
                            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        For i As Integer = 0 To dtBases.Rows.Count - 1
                            If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                VerReporte = True
                                Exit For
                            End If
                        Next
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(929) Then
                            Dim IDRegistro As Integer = Me.DGV_ListaReportes.Item("IDPERSONAREGISTRA", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                            If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                'VerReporte = True
                                Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                                comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                                Dim adaptador As New SqlDataAdapter(comando)
                                Dim dtBases = New System.Data.DataTable
                                Try
                                    conexion.Open()
                                    adaptador.Fill(dtBases)
                                    conexion.Close()
                                Catch ex As Exception
                                    MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                                For i As Integer = 0 To dtBases.Rows.Count - 1
                                    If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                        VerReporte = True
                                        Exit For
                                    End If
                                Next
                            Else
                                VerReporte = False
                            End If
                        Else
                            VerReporte = False
                        End If
                    End If

                End If
            End If


            If VerReporte = True Then
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Dim FrReporteInvestigacion As New FormulariosHse.Fr_CrearInvestigacion
                FrReporteInvestigacion.Text = "Viendo el reporte: " + Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString
                FrReporteInvestigacion.TIPO = 2
                FrReporteInvestigacion.EDITANDO = False
                FrReporteInvestigacion.IDREPORTE24H = DGV_ListaReportes.CurrentRow.Cells("IdReporte24H").Value
                FrReporteInvestigacion.IDREPORTEMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SALUD" Then
                    FrReporteInvestigacion.TIPOINCIDENTE = 1
                Else
                    If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SEGURIDAD" Then
                        FrReporteInvestigacion.TIPOINCIDENTE = 2
                    Else
                        If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "AMBIENTAL" Then
                            FrReporteInvestigacion.TIPOINCIDENTE = 3
                        Else
                            If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "CASI-ACCIDENTE" Then
                                FrReporteInvestigacion.TIPOINCIDENTE = 4
                            End If
                        End If
                    End If
                End If

                FrReporteInvestigacion.CargarTablas()
                FrReporteInvestigacion.ComportamientoPredeterminado()
                FrReporteInvestigacion.LlenarReporte()
                FrReporteInvestigacion.Bt_Guardar.Enabled = False
                FrReporteInvestigacion.ShowDialog()
                System.Windows.Forms.Cursor.Current = Cursors.Default
            Else
                MsgBox("No cuenta con los permisos para ver")
            End If
        End If
    End Sub

    Private Sub Nbi_CargarInvestigaciones_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarInvestigaciones.ItemClick
        CargarTablaxDefectoReportesInvestigacion()
    End Sub

    Private Sub Nbi_EditarInvestigacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarInvestigacion.ItemClick

        If tablacargada = Tablas.REPORTESINVESTIGACION Then
            If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(924) Or FuncionesBase.FuncionesBase.ConsultarPermiso(925) Or FuncionesBase.FuncionesBase.ConsultarPermiso(926) Then
                    EditarReporteInvestigacion()
                Else
                    MsgBox("No cuenta con los permisos para editar")
                End If
            Else
                MsgBox("La investigación " + Trim(Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " ya fue impresa y no se puede editar", vbCritical, "Investigación")
                Exit Sub
            End If
        Else
            MsgBox("No está cargada la tabla de investigaciones")
        End If
    End Sub

    Private Sub EditarReporteInvestigacion()
        Dim EditarReporte As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarInvestigacion.Tag) = True Then
            'Puede ver de todo ismocol
            If FuncionesBase.FuncionesBase.ConsultarPermiso(925) Then
                EditarReporte = True
            Else
                'Puede ver de las bases asociadas
                If FuncionesBase.FuncionesBase.ConsultarPermiso(924) Then
                    Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                    comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim dtBases = New System.Data.DataTable
                    Try
                        conexion.Open()
                        adaptador.Fill(dtBases)
                        conexion.Close()
                    Catch ex As Exception
                        MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    For i As Integer = 0 To dtBases.Rows.Count - 1
                        If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                            EditarReporte = True
                            Exit For
                        End If
                    Next
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(926) Then
                        Dim IDRegistro As Integer = Me.DGV_ListaReportes.Item("IDPERSONAREGISTRA", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                            Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                            comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                            Dim adaptador As New SqlDataAdapter(comando)
                            Dim dtBases = New System.Data.DataTable
                            Try
                                conexion.Open()
                                adaptador.Fill(dtBases)
                                conexion.Close()
                            Catch ex As Exception
                                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                            For i As Integer = 0 To dtBases.Rows.Count - 1
                                If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                    EditarReporte = True
                                    Exit For
                                End If
                            Next
                        Else
                            EditarReporte = False
                        End If
                    Else
                        EditarReporte = False
                    End If
                End If
            End If
        End If

        If EditarReporte = True Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim FrReporteInv As New FormulariosHse.Fr_CrearInvestigacion
            FrReporteInv.TIPO = 2
            FrReporteInv.EDITANDO = True
            FrReporteInv.IDREPORTEMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
            If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SALUD" Then
                FrReporteInv.TIPOINCIDENTE = 1
            Else
                If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "SEGURIDAD" Then
                    FrReporteInv.TIPOINCIDENTE = 2
                Else
                    If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "AMBIENTAL" Then
                        FrReporteInv.TIPOINCIDENTE = 3
                    Else
                        If Me.DGV_ListaReportes.Item("Tipo de Incidente", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "CASI-ACCIDENTE" Then
                            FrReporteInv.TIPOINCIDENTE = 4
                        End If
                    End If
                End If
            End If
            FrReporteInv.IDREPORTE24H = DGV_ListaReportes.Item("IdReporte24H", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
            FrReporteInv.CargarTablas()
            FrReporteInv.ComportamientoPredeterminado()
            FrReporteInv.LlenarReporte()
            FrReporteInv.ShowDialog()
            System.Windows.Forms.Cursor.Current = Cursors.Default
            If FrReporteInv.guardado Then
                CargarTablaxDefectoReportesInvestigacion()
                System.Windows.Forms.Cursor.Current = Cursors.Default
            End If
        Else
            MsgBox("No cuenta con los permisos para editar")
        End If

    End Sub

#End Region

#Region "Filtro"
    Private Sub Bt_FiltrarLista_Click(sender As System.Object, e As System.EventArgs) Handles Bt_FiltrarLista.Click
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            Dim Filtro As String = "000"
            Dim filtrovista As String = ""
            Dim nombrecolumna1 As String
            Dim nombrecolumna2 As String
            Dim nombrecolumna3 As String
            nombrecolumna1 = Me.Cb_FiltrarPor1.Text
            nombrecolumna2 = Me.Cb_FiltrarPor2.Text
            nombrecolumna3 = Me.Cb_FiltrarPor3.Text

            If Ck_Filtro1.Checked = True Then
                If Trim(Me.Tx_ValorFiltro1.Text) <> "" Then
                    Filtro = "1" + Mid(Filtro, 2, 2)
                    Select Case DGV_ListaReportes.Columns(nombrecolumna1).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro1.Text).ToString) = False Then
                                MsgBox("El valor del filtro 1 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            If Ck_Filtro2.Checked = True Then
                If Trim(Me.Tx_ValorFiltro2.Text) <> "" Then
                    Filtro = Mid(Filtro, 1, 1) + "1" + Mid(Filtro, 3, 1)
                    Select Case DGV_ListaReportes.Columns(nombrecolumna2).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro2.Text).ToString) = False Then
                                MsgBox("El valor del filtro 2 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            If Ck_Filtro3.Checked = True Then
                If Trim(Me.Tx_ValorFiltro3.Text) <> "" Then
                    Filtro = Mid(Filtro, 1, 2) + "1"
                    Select Case DGV_ListaReportes.Columns(nombrecolumna3).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro3.Text).ToString) = False Then
                                MsgBox("El valor del filtro 3 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If

            'cargar tabla
            Dim vista As DataView
            Select Case tablacargada
                Case Tablas.REPORTES24H
                    vista = New DataView(dsReportes24H.Tables(0))
                    Exit Select
                Case Tablas.REPORTESINVESTIGACION
                    vista = New DataView(dsReportesINV.Tables(0))
                    Exit Select
                Case Else
                    vista = New DataView(dsReportes24H.Tables(0))
                    Exit Select
            End Select

            Select Case Filtro
                Case "000"
                    filtrovista = ""
                Case "100"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, Trim(Me.Tx_ValorFiltro1.Text).ToString)
                Case "110"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna2, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro2.Text).ToString)
                Case "111"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna2, nombrecolumna3, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro2.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "010"
                    filtrovista = ConcatenarFiltro(nombrecolumna2, Trim(Me.Tx_ValorFiltro2.Text).ToString)
                Case "011"
                    filtrovista = ConcatenarFiltro(nombrecolumna2, nombrecolumna3, Trim(Me.Tx_ValorFiltro2.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "001"
                    filtrovista = ConcatenarFiltro(nombrecolumna3, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "101"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna3, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
            End Select
            vista.RowFilter = filtrovista
            Me.DGV_ListaReportes.SuspendLayout()
            Me.DGV_ListaReportes.DataSource = vista
            Me.DGV_ListaReportes.ResumeLayout()

            'Actualizar mensaje de regsitros en pantalla 
            Select Case tablacargada
                Case Tablas.REPORTES24H
                    Me.Lb_CantidadReportes.Text = "Lista de reportes 24 horas, esta viendo  " + vista.Count.ToString + " reportes"
                    Exit Select
                Case Tablas.REPORTESINVESTIGACION
                    Me.Lb_CantidadReportes.Text = "Lista de reportes de investigación, esta viendo  " + vista.Count.ToString + " reportes"
                    Exit Select
                Case Tablas.RESUMENESTADISTICO
                    Me.Lb_CantidadReportes.Text = "Lista de datos para el resumen estadístico, esta viendo  " + vista.Count.ToString + " registros"
                Case Else
                    Exit Select
            End Select
        Catch ex As Exception
            MsgBox("Ocurrio un inconveniente al procesar la instrucción", MsgBoxStyle.Critical, "Inconveniente")
        End Try
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Valor1 As String) As String
        Select Case DGV_ListaReportes.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                ConcatenarFiltro = String.Format("[" + Columna1 + "]" + "=" + Valor1)
                Exit Select
            Case Type.GetType("System.String")
                ConcatenarFiltro = String.Format("{0} like '%{1}%'", "[" + Columna1 + "]", Valor1)
                Exit Select
            Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                ConcatenarFiltro = ""
        End Select
    End Function


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Columna2 As String, ByVal Valor1 As String, ByVal Valor2 As String) As String
        Select Case DGV_ListaReportes.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                Select Case DGV_ListaReportes.Columns(Columna2).ValueType
                    'columna 1 decimal y columna 2 decimal
                    Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                        ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                        'columna 1 decimal y columna 2 string
                    Case Type.GetType("System.String")
                        ConcatenarFiltro = String.Format("{0} = {1} AND {2} like '%{3}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                    Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                        ConcatenarFiltro = ""
                End Select
            Case Type.GetType("System.String")
                Select Case DGV_ListaReportes.Columns(Columna2).ValueType
                    'columna 1 string y columna 2 decimal
                    Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                        ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} = {3}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                        'columna 1 string y columna 2 string
                    Case Type.GetType("System.String")
                        ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                    Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                        ConcatenarFiltro = ""
                End Select
            Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                ConcatenarFiltro = ""
        End Select
    End Function

    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Columna2 As String, ByVal Columna3 As String, ByVal Valor1 As String, ByVal Valor2 As String, ByVal Valor3 As String) As String
        Dim tipocolumna1 As String
        Dim tipocolumna2 As String
        Dim tipocolumna3 As String

        Select Case DGV_ListaReportes.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna1 = "N"
            Case Type.GetType("System.String")
                tipocolumna1 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case DGV_ListaReportes.Columns(Columna2).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna2 = "N"
            Case Type.GetType("System.String")
                tipocolumna2 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case DGV_ListaReportes.Columns(Columna3).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna3 = "N"
            Case Type.GetType("System.String")
                tipocolumna3 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case tipocolumna1 + tipocolumna2 + tipocolumna3
            Case "NNN"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NNS"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3} AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NSS"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} like '%{3}%' AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SSS"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%' AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SSN"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%' AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SNN"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND  {2} = {3} AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SNS"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND  {2} = {3} AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NSN"
                ConcatenarFiltro = String.Format("{0} = {1} AND  {2} like '%{3}%' AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case Else
                ConcatenarFiltro = ""
        End Select
    End Function

#End Region 'Filtro

#Region "Aplicar estilos"
    Private Sub CargarReporte24HFiltro(ByVal DsTabla As DataSet)
        Me.DGV_ListaReportes.ReadOnly = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DGV_ListaReportes.DataSource = Nothing

        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
        Me.DGV_ListaReportes.DataSource = DsTabla.Tables(0).DefaultView
        Me.Lb_CantidadReportes.Text = "Lista de Reportes 24 horas, está viendo " + DsTabla.Tables(0).Rows.Count.ToString + " reportes"
        Me.DGV_ListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaReportes.ReadOnly = True

        For i = 0 To DGV_ListaReportes.ColumnCount - 1

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaReportes.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaReportes.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaReportes.Columns(i).Name
                Case "Id"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Id"
                Case "Tipo de Incidente"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Tipo de Incidente"
                Case "Fecha del Incidente"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Fecha del Incidente"
                    DGV_ListaReportes.Columns(i).Width = 50
                Case "Reporte"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Reporte"
                Case "Proyecto"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Proyecto"
                Case Else
                    DGV_ListaReportes.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub CargarReporteInvFiltro(ByVal DsTabla As DataSet)
        Me.DGV_ListaReportes.ReadOnly = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DGV_ListaReportes.DataSource = Nothing
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()

        Me.DGV_ListaReportes.DataSource = DsTabla.Tables(0).DefaultView
        Me.Lb_CantidadReportes.Text = "Lista de Reportes de investigacion, está viendo " + DsTabla.Tables(0).Rows.Count.ToString + " reportes"
        Me.DGV_ListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaReportes.ReadOnly = True

        For i = 0 To DGV_ListaReportes.ColumnCount - 1

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaReportes.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaReportes.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaReportes.Columns(i).Name
                Case "Id"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Id Reporte investigacion"
                    DGV_ListaReportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Tipo de Incidente"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Tipo de Incidente"
                Case "Reporte"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Reporte"
                Case "Fecha del Incidente"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Fecha del incidente"
                Case "Proyecto"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Proyecto"
                Case Else
                    DGV_ListaReportes.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub CargarResumenEstadisticoFiltro(ByVal DsTabla As DataSet)
        Me.DGV_ListaReportes.ReadOnly = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DGV_ListaReportes.DataSource = Nothing
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()

        Me.DGV_ListaReportes.DataSource = DsTabla.Tables(0).DefaultView
        Me.Lb_CantidadReportes.Text = "Lista de datos para el resumen estadístico, está viendo " + DsTabla.Tables(0).Rows.Count.ToString + " registros"
        Me.DGV_ListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaReportes.ReadOnly = True

        For i = 0 To DGV_ListaReportes.ColumnCount - 1

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaReportes.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaReportes.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaReportes.Columns(i).Name
                Case "Id"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Id"
                    DGV_ListaReportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Año"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Año"
                Case "Mes"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Mes"
                Case "Base"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).ToolTipText = "Base"
                Case Else
                    DGV_ListaReportes.Columns(i).Visible = False
            End Select
        Next
    End Sub
    Private Sub CargarExamenesFiltro(ByVal DsTabla As DataSet)
        Me.DGV_ListaReportes.ReadOnly = False
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Me.DGV_ListaReportes.DataSource = Nothing

        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
        Me.DGV_ListaReportes.DataSource = DsTabla.Tables(0).DefaultView
        Me.Lb_CantidadReportes.Text = "Lista de exámenes médicos, está viendo " + DsTabla.Tables(0).Rows.Count.ToString + " exámenes"
        Me.DGV_ListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaReportes.ReadOnly = True

        For i = 0 To DGV_ListaReportes.ColumnCount - 1

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaReportes.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaReportes.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaReportes.Columns(i).Name
                Case "Id"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).HeaderText = "Id"
                Case "Fecha del examen"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).HeaderText = "Fecha del examen"
                    DGV_ListaReportes.Columns(i).Width = 50
                Case "Persona"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).HeaderText = "Persona"
                Case "Edad"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).HeaderText = "Edad"
                    DGV_ListaReportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Base"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).HeaderText = "Base"
                Case "TIPOEXAMEN"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderText = "Tipo Examen"
                Case "UBICADOSERVIDORARCHIVO"
                    DGV_ListaReportes.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaReportes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaReportes.Columns(i).HeaderText = "Serv"
                    DGV_ListaReportes.Columns(i).ToolTipText = "Servidor"
                Case Else
                    DGV_ListaReportes.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub MostrarNombreMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim Vista As DataView
        Select Case tablacargada
            Case Tablas.REPORTES24H
                Vista = New Data.DataView(dsReportes24H.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaReportes.DataSource = Vista
            Case Tablas.REPORTESINVESTIGACION
                Vista = New Data.DataView(dsReportesINV.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaReportes.DataSource = Vista
            Case Tablas.RESUMENESTADISTICO
                Vista = New Data.DataView(dsResumenEst.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaReportes.DataSource = Vista
            Case Tablas.EXAMENESMEDICOS
                Vista = New Data.DataView(dsExamenes.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaReportes.DataSource = Vista
        End Select
    End Sub

#End Region

    'Carga la lista de seleccion antes de que se obtenga el valor de la nueva celda cuando se cambia por codigo
    'Private Sub DGV_ListaReportes_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_ListaReportes.SelectionChanged
    '    CargarListaxSeleccion()
    'End Sub

    Private Sub DGV_ListaReportes_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_ListaReportes.CurrentCellChanged
        CargarListaxSeleccion()
    End Sub
    Private Sub CargarListaxSeleccion()
        Try
            Select Case tablacargada
                Case Tablas.REPORTES24H
                    Cursor.Current = Cursors.WaitCursor
                    Dim Cadena_Consulta As String
                    Cadena_Consulta = "SELECT * FROM dbo.DetalleReporte24H(" + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + ") AS DetalleReporte24H"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    'Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = conexion
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim Dt_RP As New System.Data.DataTable
                    Adaptador.FillSchema(Dt_RP, SchemaType.Source)
                    Adaptador.Fill(Dt_RP)
                    Consulta.Connection.Close()
                    Dim xx As New Cl_Formato24H(Dt_RP.Rows(0))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Cursor.Current = Cursors.Default
                Case Tablas.REPORTESINVESTIGACION
                    Cursor.Current = Cursors.WaitCursor
                    Dim Cadena_Consulta As String
                    Cadena_Consulta = "SELECT * FROM dbo.DetalleReporteInvestigacion(" + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + ") AS DetalleReporteInvestigacion"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    'Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = conexion
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim Dt_RP As New System.Data.DataTable
                    Adaptador.FillSchema(Dt_RP, SchemaType.Source)
                    Adaptador.Fill(Dt_RP)
                    Consulta.Connection.Close()
                    Dim xx As New Cl_FormatoInvestigacion(Dt_RP.Rows(0))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Cursor.Current = Cursors.Default
                Case Tablas.RESUMENESTADISTICO
                    Cursor.Current = Cursors.WaitCursor
                    Dim Cadena_Consulta As String
                    Cadena_Consulta = "SELECT * FROM dbo.DetalleResumenEstadistico(" + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + ") AS DetalleReporteInvestigacion"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    'Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = conexion
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim Dt_RP As New System.Data.DataTable
                    Adaptador.FillSchema(Dt_RP, SchemaType.Source)
                    Adaptador.Fill(Dt_RP)
                    Consulta.Connection.Close()
                    Dim xx As New Cl_ResumenEstadistico(Dt_RP.Rows(0))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Cursor.Current = Cursors.Default
                Case Tablas.EXAMENESMEDICOS
                    Cursor.Current = Cursors.WaitCursor
                    Dim Cadena_Consulta As String
                    Cadena_Consulta = "SELECT * FROM dbo.DetalleExamenMedicoPeriodico(" + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + ") AS DetalleExamenMedicoPeriodico"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    'Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = conexion
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim Dt_RP As New System.Data.DataTable
                    Adaptador.FillSchema(Dt_RP, SchemaType.Source)
                    Adaptador.Fill(Dt_RP)
                    Consulta.Connection.Close()
                    Dim xx As New Cl_ExamenMedico(Dt_RP.Rows(0))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Cursor.Current = Cursors.Default
            End Select
        Catch ex As Exception
            Pg_DetalleLista.SelectedObject = Nothing
        End Try
    End Sub

    Private Sub Nbi_ImprimirReporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirReporte.ItemClick
        If tablacargada = Tablas.REPORTES24H Then
            IMPRIMIR()
        Else
            MsgBox("No está cargada la tabla de reportes 24 horas")
        End If
    End Sub

    Private Sub Nbi_ImprimirInvestigacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirInvestigacion.ItemClick
        If tablacargada = Tablas.REPORTESINVESTIGACION Then
            IMPRIMIR()
        Else
            MsgBox("No está cargada la tabla de reportes de investigación")
        End If
    End Sub

    Private Sub Nbi_ImprimirAlertaSeguridad_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirAlertaSeguridad.ItemClick
        If tablacargada <> Tablas.REPORTESINVESTIGACION Then
            MsgBox("No está cargada la tabla de reportes de investigación")
            Exit Sub
        End If
        Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
        Dim Array As New ArrayList
        climpresiones.IdReporte = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
        climpresiones.TipoReporte = 2
        Array.Add(100)
        climpresiones.FormatosImprimir(Array, True)
        MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
    End Sub

    Private Sub IMPRIMIR(Optional Tipo As Integer = 0)
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaReportes.CurrentCell.RowIndex
            Select Case tablacargada
                Case Tablas.REPORTES24H
                    If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                        If MsgBox("¿Desea imprimir el reporte 24 horas?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                            Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
                            Dim Array As New ArrayList
                            climpresiones.IdReporte = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                            climpresiones.TipoReporte = 1
                            Array.Add(97)
                            climpresiones.FormatosImprimir(Array, True)
                            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                        End If
                    Else
                        MsgBox("El reporte " + Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value + " ya fue impreso", vbCritical, "Reporte 24 Horas")
                    End If
                    CargarTablaxDefectoReportes24H()
                Case Tablas.REPORTESINVESTIGACION
                    If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                        If MsgBox("¿Desea imprimir el reporte investigación?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                            Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
                            Dim Array As New ArrayList
                            climpresiones.IdReporte = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                            climpresiones.TipoReporte = 2
                            Array.Add(98)
                            climpresiones.FormatosImprimir(Array, True)
                            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                        End If
                    Else
                        MsgBox("El reporte " + Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value + " ya fue impreso", vbCritical, "Reporte Investigación")
                    End If
                    CargarTablaxDefectoReportesInvestigacion()
                Case Tablas.EXAMENESMEDICOS
                    If Tipo = 2 Then
                        If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                            If Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "S" Then
                                If MsgBox("¿Desea imprimir el concepto del examen médico?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                                    Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
                                    Dim Array As New ArrayList
                                    climpresiones.IdExamen = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                                    climpresiones.TipoReporte = 3
                                    Array.Add(101)
                                    climpresiones.FormatosImprimir(Array, True)
                                    MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                                End If
                            Else
                                MsgBox("El examen médico " + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + " no tiene un concepto asociado", vbCritical, "Exámenes Médicos")
                            End If
                        Else
                            MsgBox("El examen médico " + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + " ya fue impreso", vbCritical, "Exámenes Médicos")
                        End If
                    Else
                        If Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "S" Then
                            Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
                            Dim Array As New ArrayList
                            climpresiones.IdExamen = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                            climpresiones.TipoReporte = 4
                            Array.Add(105)
                            climpresiones.FormatosImprimir(Array, True)
                            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                        Else
                            MsgBox("El examen médico " + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString + " no tiene un concepto asociado", vbCritical, "Exámenes Médicos")
                        End If
                        
                    End If
                    CargarTablaxDefectoExamenes()
            End Select
            Ubicar_Registro()
        End If
    End Sub

    Private Sub Ubicar_Registro()
        Try
            Me.DGV_ListaReportes.CurrentCell = Me.DGV_ListaReportes(0, Index_Registro_Actual)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_HablitarImpresionR24_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HablitarImpresionR24.ItemClick
        If tablacargada = Tablas.REPORTES24H Then
            HabilitarImpresion()
        Else
            MsgBox("No está cargada la tabla de investigaciones")
        End If
    End Sub

    Private Sub Nbi_HabilitarImpresionInvestigacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarImpresionInvestigacion.ItemClick
        If tablacargada = Tablas.REPORTESINVESTIGACION Then
            HabilitarImpresion()
        Else
            MsgBox("No está cargada la tabla de investigaciones")
        End If
    End Sub

    Private Sub HabilitarImpresion()
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaReportes.CurrentCell.RowIndex
            Select Case tablacargada
                Case Tablas.REPORTES24H
                    If MsgBox("¿Desea habilitar la impresion del reporte 24 horas", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "RH")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.NChar, 5)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)

                        'Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                        conn.Open()
                        Comando.Connection = conn
                        Try
                            Comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CargarTablaxDefectoReportes24H()
                    End If
                Case Tablas.REPORTESINVESTIGACION
                    If MsgBox("¿Desea habilitar la impresion del reporte de investigación", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "RI")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.NChar, 5)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)

                        'Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                        conn.Open()
                        Comando.Connection = conn
                        Try
                            Comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CargarTablaxDefectoReportesInvestigacion()
                    End If
                Case Tablas.RESUMENESTADISTICO
                    If MsgBox("¿Desea habilitar la edición de los datos del resumen estadístico", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "RE")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.NChar, 5)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)

                        'Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                        conn.Open()
                        Comando.Connection = conn
                        Try
                            Comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CargarTablaxDefectoResumenEstadistico()
                    End If
                Case Tablas.EXAMENESMEDICOS
                    If MsgBox("¿Desea habilitar la impresion del concepto del examen médico periódico", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "EM")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.NChar, 5)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)

                        'Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                        conn.Open()
                        Comando.Connection = conn
                        Try
                            Comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        CargarTablaxDefectoExamenes()
                    End If
            End Select

        End If
    End Sub

    Private Sub Nbi_BuscarReporte_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarReporte.ItemClick
        BuscarReporte24H()
    End Sub

    Private Sub BuscarReporte24H()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New System.Data.DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("B.NOMBREBASE", "Base", "1")
        campos.Rows.Add("R24.NUMEROREPORTE", "No. Reporte", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(R24.IDPERSONAREPORTA)", "Persona que reportó", "1")
        campos.Rows.Add("R24.FECHAACCIDENTE", "Fecha del accidente", "3")
        frbuscar.campos = campos
        frbuscar.tabla = 55
        frbuscar.ShowDialog()
        dsReportes24H = frbuscar.DsBuscar
        If dsReportes24H.Tables.Count > 0 Then
            If dsReportes24H.Tables(0).Rows.Count > 0 Then
                CargarReporte24HFiltro(dsReportes24H)
                tablacargada = Tablas.REPORTES24H
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
        Exit Sub
    End Sub

    Private Sub Nbi_BuscarInvestigacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarInvestigacion.ItemClick
        BuscarInvestigacion()
    End Sub

    Private Sub BuscarInvestigacion()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New System.Data.DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("B.NOMBREBASE", "Base", "1")
        campos.Rows.Add("RINV.NUMEROREPORTEINV", "No. Reporte", "1")
        campos.Rows.Add("RINV.FECHAACCIDENTE", "Fecha del accidente", "3")
        frbuscar.campos = campos
        frbuscar.tabla = 56
        frbuscar.ShowDialog()
        dsReportesINV = frbuscar.DsBuscar
        If dsReportesINV.Tables.Count > 0 Then
            If dsReportesINV.Tables(0).Rows.Count > 0 Then
                CargarReporte24HFiltro(dsReportesINV)
                tablacargada = Tablas.REPORTESINVESTIGACION
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
        Exit Sub
    End Sub

    Private Sub DGV_ListaReportes_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_ListaReportes.CellMouseDoubleClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Select Case tablacargada
                Case Tablas.REPORTES24H
                    If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                        EditarReporte24H()
                    Else
                        MsgBox("El reporte " + Trim(Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " ya fue impreso y no se puede editar", vbCritical, "Reporte 24 Horas")
                        Exit Sub
                    End If

                Case Tablas.REPORTESINVESTIGACION
                    If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                        EditarReporteInvestigacion()
                    Else
                        MsgBox("La investigación " + Trim(Me.DGV_ListaReportes.Item("Reporte", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " ya fue impresa y no se puede editar", vbCritical, "Investigación")
                        Exit Sub
                    End If
                Case Tablas.RESUMENESTADISTICO
                    If Me.DGV_ListaReportes.Item("BLOQUEAREDICION", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                        EditarResumenEstadistico()
                    Else
                        MsgBox("Los datos del resumen estadístico " + Trim(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " no se pueden editar", vbCritical, "Resumen estadístico")
                        Exit Sub
                    End If
                Case Tablas.EXAMENESMEDICOS
                    If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                        EditarExamen()
                    Else
                        MsgBox("Los datos del examen" + Trim(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " no se pueden editar", vbCritical, "Examen médico")
                        Exit Sub
                    End If
            End Select
        End If
    End Sub

#Region "Resumen Estadistico"

    Private Sub Nbi_ResumenEstadistico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarResumenEstadistico.ItemClick
        RegistrarDatosResumenEstadistico()
    End Sub

    Private Sub RegistrarDatosResumenEstadistico()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim FrRegistrarDatosResumenEstadistico As New FormulariosHse.Fr_ResumenEstadistico
        FrRegistrarDatosResumenEstadistico.TIPO = 1
        FrRegistrarDatosResumenEstadistico.EDITANDO = False
        FrRegistrarDatosResumenEstadistico.guardado = False
        FrRegistrarDatosResumenEstadistico.CargarTablas()
        FrRegistrarDatosResumenEstadistico.ComportamientoPredeterminado()
        FrRegistrarDatosResumenEstadistico.ShowDialog()
        System.Windows.Forms.Cursor.Current = Cursors.Default
        If FrRegistrarDatosResumenEstadistico.guardado Then
            CargarTablaxDefectoResumenEstadistico()
        End If
    End Sub

    Private Sub Nbi_CargarResumenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarResumenes.ItemClick
        CargarTablaxDefectoResumenEstadistico()
    End Sub



    Private Sub Nbi_VerResumen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerResumen.ItemClick
        If tablacargada = Tablas.RESUMENESTADISTICO Then
            VerResumenEstadistico()
        Else
            MsgBox("No está cargada la tabla de resumen estadistico")
        End If
    End Sub

    Private Sub VerResumenEstadistico()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Dim VerResumen As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerResumen.Tag) = True Then
                'Puede ver de todo ismocol
                If FuncionesBase.FuncionesBase.ConsultarPermiso(934) Then
                    VerResumen = True
                Else
                    'Puede ver de las bases asociadas
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(933) Then
                        Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASEHSE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                        comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                        Dim adaptador As New SqlDataAdapter(comando)
                        Dim dtBases = New System.Data.DataTable
                        Try
                            conexion.Open()
                            adaptador.Fill(dtBases)
                            conexion.Close()
                        Catch ex As Exception
                            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        For i As Integer = 0 To dtBases.Rows.Count - 1
                            If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                VerResumen = True
                                Exit For
                            End If
                        Next
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(935) Then
                            Dim IDRegistro As Integer = Me.DGV_ListaReportes.Item("IDPERSONAREGISTRA", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                            If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASEHSE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                                comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                                Dim adaptador As New SqlDataAdapter(comando)
                                Dim dtBases = New System.Data.DataTable
                                Try
                                    conexion.Open()
                                    adaptador.Fill(dtBases)
                                    conexion.Close()
                                Catch ex As Exception
                                    MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                                For i As Integer = 0 To dtBases.Rows.Count - 1
                                    If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                        VerResumen = True
                                        Exit For
                                    End If
                                Next
                            Else
                                VerResumen = False
                            End If
                        Else
                            VerResumen = False
                        End If
                    End If

                End If
            End If
            If VerResumen = True Then
                Dim FrResumenEstadistico As New FormulariosHse.Fr_ResumenEstadistico
                FrResumenEstadistico.Text = "Viendo los datos del resumen estadístico: " + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString
                FrResumenEstadistico.TIPO = 2
                FrResumenEstadistico.EDITANDO = False
                FrResumenEstadistico.IDRESUMENMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                FrResumenEstadistico.CargarTablas()
                FrResumenEstadistico.ComportamientoPredeterminado()
                FrResumenEstadistico.LlenarResumen()
                FrResumenEstadistico.Bt_Guardar.Enabled = False
                FrResumenEstadistico.ShowDialog()
                System.Windows.Forms.Cursor.Current = Cursors.Default
            Else
                MsgBox("No cuenta con los permisos para ver")
            End If


        End If
    End Sub

    Private Sub Nbi_EditarResumen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarResumen.ItemClick
        If tablacargada = Tablas.RESUMENESTADISTICO Then
            If Me.DGV_ListaReportes.Item("BLOQUEAREDICION", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                EditarResumenEstadistico()
            Else
                MsgBox("Los datos del resumen estadístico " + Trim(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " no se pueden editar", vbCritical, "Resumen estadístico")
                Exit Sub
            End If
        Else
            MsgBox("No está cargada la tabla de resumen estadístico")
        End If
    End Sub

    Private Sub EditarResumenEstadistico()
        Dim EditarResumen As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarResumen.Tag) = True Then
            'Puede ver de todo ismocol
            If FuncionesBase.FuncionesBase.ConsultarPermiso(931) Then
                EditarResumen = True
            Else
                'Puede ver de las bases asociadas
                If FuncionesBase.FuncionesBase.ConsultarPermiso(930) Then
                    Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASEHSE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                    comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim dtBases = New System.Data.DataTable
                    Try
                        conexion.Open()
                        adaptador.Fill(dtBases)
                        conexion.Close()
                    Catch ex As Exception
                        MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    For i As Integer = 0 To dtBases.Rows.Count - 1
                        If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                            EditarResumen = True
                            Exit For
                        End If
                    Next
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(932) Then
                        Dim IDRegistro As Integer = Me.DGV_ListaReportes.Item("IDPERSONAREGISTRA", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            Dim BaseHSE As String = Me.DGV_ListaReportes.Item("IDBASEHSE", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString

                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                            Dim comando As New SqlCommand("SELECT UB.IDBASEHSE FROM HSE_USUARIOBASE AS UB WHERE UB.IDPERSONA = @IDPERSONA AND UB.ACTIVO ='S'", conexion)
                            comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                            Dim adaptador As New SqlDataAdapter(comando)
                            Dim dtBases = New System.Data.DataTable
                            Try
                                conexion.Open()
                                adaptador.Fill(dtBases)
                                conexion.Close()
                            Catch ex As Exception
                                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                            For i As Integer = 0 To dtBases.Rows.Count - 1
                                If dtBases.Rows(i).Item(0).ToString = BaseHSE Then
                                    EditarResumen = True
                                    Exit For
                                End If
                            Next
                        Else
                            EditarResumen = False
                        End If
                    Else
                        EditarResumen = False
                    End If
                End If
            End If
        End If

        If EditarResumen = True Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim FrResumen As New FormulariosHse.Fr_ResumenEstadistico
            FrResumen.TIPO = 2
            FrResumen.EDITANDO = True
            FrResumen.IDRESUMENMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
            FrResumen.CargarTablas()
            FrResumen.ComportamientoPredeterminado()
            FrResumen.LlenarResumen()
            FrResumen.ShowDialog()
            System.Windows.Forms.Cursor.Current = Cursors.Default
            If FrResumen.guardado Then
                CargarTablaxDefectoResumenEstadistico()
            End If
        Else
            MsgBox("No cuenta con los permisos para editar")
        End If

    End Sub

    Private Sub Nbi_HabilitarEdicion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarEdicion.ItemClick
        If tablacargada = Tablas.RESUMENESTADISTICO Then
            HabilitarImpresion()
        Else
            MsgBox("No está cargada la tabla del resumen estadístico")
        End If
    End Sub

    Private Sub Nbi_ExportarResumenBase_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ExportarResumenBase.ItemClick
        Dim Consultar As New Boolean
        Dim Fr_Resumen As New Form
        Dim Lb_Base As New System.Windows.Forms.Label
        Dim Cb_Base As New ComboBox
        Dim Lb_Año As New System.Windows.Forms.Label
        Dim Tb_Año As New System.Windows.Forms.TextBox
        Dim Bt_Aceptar As New System.Windows.Forms.Button
        Dim Bt_Cancelar As New System.Windows.Forms.Button

        Dim Cadena_Consulta As String = "SELECT B.ABREVIATURABASE, B.NOMBREBASE FROM HSE_MA_BASE AS B "
        Cadena_Consulta += "INNER JOIN HSE_USUARIOBASE AS UB ON UB.IDBASEHSE = B.IDBASEHSE AND UB.IDPERSONA = " + VariablesBase.VariablesBase.IdPersona.ToString + " AND UB.ACTIVO = 'S'"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Dim Adaptador As New SqlDataAdapter(Consulta)
        Dim dtBase As New System.Data.DataTable
        Consulta.Connection = Conexión
        Consulta.Connection.Open()
        Adaptador.Fill(dtBase)
        Consulta.Connection.Close()

        With Lb_Base
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 37)
            .Name = "Lb_Base"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Base"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Cb_Base
            .Location = New System.Drawing.Point(60, 36)
            .Name = "Cb_Base"
            .Size = New System.Drawing.Size(200, 20)
            .TabIndex = 1
            .DataSource = dtBase
            .DisplayMember = "NOMBREBASE"
            .ValueMember = "ABREVIATURABASE"
        End With

        With Lb_Año
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 67)
            .Name = "Lb_Año"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Año"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Tb_Año
            .Location = New System.Drawing.Point(60, 66)
            .Name = "Tb_Año"
            .Size = New System.Drawing.Size(200, 20)
            .TabIndex = 2
            .MaxLength = 4
        End With
        AddHandler Tb_Año.KeyPress, AddressOf Caja_Texto_KeyPress
        With Bt_Aceptar
            .Location = New System.Drawing.Point(145, 118)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(85, 23)
            .TabIndex = 3
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(44, 118)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 4
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_Resumen
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
            .Text = "Base para el resumen estadístico"
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(Lb_Base)
            .Controls.Add(Cb_Base)
            .Controls.Add(Lb_Año)
            .Controls.Add(Tb_Año)
        End With

        AddHandler Bt_Aceptar.Click, Sub()
                                         If Trim(Tb_Año.Text) = "" Then
                                             MsgBox("Debe ingresar un año")
                                             Exit Sub
                                         End If
                                         If Trim(Tb_Año.Text).Length < 4 Then
                                             MsgBox("Debe ingresar un valor valido")
                                             Exit Sub
                                         End If
                                         If Convert.ToInt32(Tb_Año.Text) > Today.Year Then
                                             MsgBox("El año del informe a generar no puede ser mayor al año actual")
                                             Exit Sub
                                         End If
                                         If MsgBox("Seguro desea exportar el excel del resumen estadistico", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then

                                             Consultar = True
                                             Fr_Resumen.Close()
                                         End If
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()
                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                              Consultar = False
                                              Fr_Resumen.Close()
                                          End If
                                      End Sub
        Fr_Resumen.ShowDialog()

        If Consultar = True Then
        Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            climpresiones.TipoResumen = 0
            climpresiones.BasesResumen = Cb_Base.SelectedValue
            climpresiones.AñoResumen = Tb_Año.Text
            Array.Add(106)
            climpresiones.FormatosImprimir(Array, True)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If
    End Sub

    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub


    Private Sub NetBarItem1Nbi_ExportarResumenIsmocol_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ExportarResumenIsmocol.ItemClick
        Dim Consultar As New Boolean
        Dim Fr_Resumen As New Form
        Dim Lb_Base As New System.Windows.Forms.Label
        Dim Cb_Base As New ComboBox
        Dim Lb_Año As New System.Windows.Forms.Label
        Dim Tb_Año As New System.Windows.Forms.TextBox
        Dim Bt_Aceptar As New System.Windows.Forms.Button
        Dim Bt_Cancelar As New System.Windows.Forms.Button

        With Lb_Año
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 20)
            .Name = "Lb_Año"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Año"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Tb_Año
            .Location = New System.Drawing.Point(60, 19)
            .Name = "Tb_Año"
            .Size = New System.Drawing.Size(200, 20)
            .TabIndex = 1
            .MaxLength = 4
        End With
        AddHandler Tb_Año.KeyPress, AddressOf Caja_Texto_KeyPress
        With Bt_Aceptar
            .Location = New System.Drawing.Point(145, 60)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(85, 23)
            .TabIndex = 2
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(44, 60)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 3
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_Resumen
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .AcceptButton = Bt_Aceptar
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(291, 130)
            .MaximumSize = New System.Drawing.Size(291, 130)
            .MinimumSize = New System.Drawing.Size(291, 130)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Resumen estadístico"
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(Lb_Año)
            .Controls.Add(Tb_Año)
        End With


        AddHandler Bt_Aceptar.Click, Sub()
                                         If Trim(Tb_Año.Text) = "" Then
                                             MsgBox("Debe ingresar un año")
                                             Exit Sub
                                         End If
                                         If Trim(Tb_Año.Text).Length < 4 Then
                                             MsgBox("Debe ingresar un valor valido")
                                             Exit Sub
                                         End If
                                         If Convert.ToInt32(Tb_Año.Text) > Today.Year Then
                                             MsgBox("El año del informe a generar no puede ser mayor al año actual")
                                             Exit Sub
                                         End If
                                         If MsgBox("Seguro desea exportar el excel del resumen estadistico", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then

                                             Consultar = True
                                             Fr_Resumen.Close()
                                         End If
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()
                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                              Consultar = False
                                              Fr_Resumen.Close()
                                          End If
                                      End Sub
        Fr_Resumen.ShowDialog()

        If Consultar = True Then
            Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            climpresiones.TipoResumen = 1
            climpresiones.BasesResumen = "ISMOCOL"
            climpresiones.AñoResumen = Tb_Año.Text
            Array.Add(106)
            climpresiones.FormatosImprimir(Array, True)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If
    End Sub


    Private Sub Nbi_ResumenEstidisticoProyecto_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ResumenEstidisticoProyecto.ItemClick
        Dim Consultar As New Boolean
        Dim Fr_Resumen As New Form
        Dim Lb_Año As New System.Windows.Forms.Label
        Dim Tb_Año As New System.Windows.Forms.TextBox
        Dim Lb_Base As New System.Windows.Forms.Label
        Dim CLb_Bases As New CheckedListBox
        Dim Bt_Aceptar As New System.Windows.Forms.Button
        Dim Bt_Cancelar As New System.Windows.Forms.Button

        'Dim Cadena_Consulta As String = "SELECT  ABREVIATURABASE, NOMBREBASE FROM HSE_MA_BASE "
        Dim Cadena_Consulta As String = "SELECT B.ABREVIATURABASE, B.NOMBREBASE FROM HSE_MA_BASE AS B "
        Cadena_Consulta += "INNER JOIN HSE_USUARIOBASE AS UB ON UB.IDBASEHSE = B.IDBASEHSE AND UB.IDPERSONA = " + VariablesBase.VariablesBase.IdPersona.ToString + " AND UB.ACTIVO = 'S'"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Dim Adaptador As New SqlDataAdapter(Consulta)
        Dim dtBase As New System.Data.DataTable
        Consulta.Connection = Conexión
        Consulta.Connection.Open()
        Adaptador.Fill(dtBase)
        Consulta.Connection.Close()

        With Lb_Año
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 20)
            .Name = "Lb_Año"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Año"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Tb_Año
            .Location = New System.Drawing.Point(60, 19)
            .Name = "Tb_Año"
            .Size = New System.Drawing.Size(200, 20)
            .TabIndex = 1
            .MaxLength = 4
        End With
        AddHandler Tb_Año.KeyPress, AddressOf Caja_Texto_KeyPress

        With Lb_Base
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 50)
            .Name = "Lb_Base"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Base"
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With CLb_Bases
            .Size = New System.Drawing.Size(200, 300)
            .Location = New System.Drawing.Point(60, 50)
            .Name = "CLb_Bases"
            .TabIndex = 2
        End With

        For i As Integer = 0 To dtBase.Rows.Count - 1
            CLb_Bases.Items.Add(dtBase.Rows(i).Item(0))
        Next


        With Bt_Aceptar
            .Location = New System.Drawing.Point(145, 350)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(85, 23)
            .TabIndex = 3
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(44, 350)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 4
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_Resumen
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .AcceptButton = Bt_Aceptar
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(291, 420)
            '.MaximumSize = New System.Drawing.Size(291, 300)
            .MinimumSize = New System.Drawing.Size(291, 300)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Resumen estadístico"
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(Lb_Año)
            .Controls.Add(Tb_Año)
            .Controls.Add(Lb_Base)
            .Controls.Add(CLb_Bases)
        End With

        Dim Bases As String = ""

        AddHandler Bt_Aceptar.Click, Sub()
                                         If Trim(Tb_Año.Text) = "" Then
                                             MsgBox("Debe ingresar un año")
                                             Exit Sub
                                         End If
                                         If Trim(Tb_Año.Text).Length < 4 Then
                                             MsgBox("Debe ingresar un valor valido")
                                             Exit Sub
                                         End If
                                         If Convert.ToInt32(Tb_Año.Text) > Today.Year Then
                                             MsgBox("El año del informe a generar no puede ser mayor al año actual")
                                             Exit Sub
                                         End If

                                         For i As Integer = 0 To CLb_Bases.Items.Count - 1
                                             If CLb_Bases.GetItemChecked(i) = True Then
                                                 Bases += CLb_Bases.Items(i) + ","
                                             End If
                                         Next
                                         If Bases = "" Then
                                             MsgBox("Debe seleccionar las bases deseadas para generar el resumen estadístico por proyecto")
                                             Exit Sub
                                         End If
                                         If MsgBox("Seguro desea exportar el excel del resumen estadistico", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then

                                             Consultar = True
                                             Fr_Resumen.Close()
                                         End If
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()
                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                              Consultar = False
                                              Fr_Resumen.Close()
                                          End If
                                      End Sub
        Fr_Resumen.ShowDialog()

        If Consultar = True Then
            Bases = Bases.Remove(Bases.LastIndexOf(","))
            Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            climpresiones.TipoResumen = 2
            climpresiones.BasesResumen = Bases
            climpresiones.AñoResumen = Tb_Año.Text
            Array.Add(106)
            climpresiones.FormatosImprimir(Array, True)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If
    End Sub


    Private Sub Nbi_BuscarResumenEstadistico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarResumenEstadistico.ItemClick
        BuscarResumenEstadistico()
    End Sub

    Private Sub BuscarResumenEstadistico()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New System.Data.DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("RE.AÑO", "Año", "2")
        campos.Rows.Add("B.ABREVIATURABASE", "Base", "1")
        campos.Rows.Add("RE.MES", "Mes", "2")
        frbuscar.campos = campos
        frbuscar.tabla = 57
        frbuscar.ShowDialog()
        dsResumenEst = frbuscar.DsBuscar
        If dsResumenEst.Tables.Count > 0 Then
            If dsResumenEst.Tables(0).Rows.Count > 0 Then
                CargarResumenEstadisticoFiltro(dsResumenEst)
                tablacargada = Tablas.RESUMENESTADISTICO
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
        Exit Sub
    End Sub

#End Region

    Private Sub Nbi_AsociarUsuarioBaseHSE_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AsociarUsuarioBaseHSE.ItemClick
        Dim Fr_AsociarBaseHSE As New FormulariosHse.Fr_AsociarUsuarioBaseHse
        Fr_AsociarBaseHSE.ShowDialog()
    End Sub

    Private Sub Nbi_RegistrarExamen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarExamen.ItemClick
        CrearExamen()
    End Sub

    Private Sub CrearExamen()
        Dim CrearExamen As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarExamen.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(940) Then
                CrearExamen = True
            Else
                CrearExamen = False
            End If
        End If
        If CrearExamen Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim Fr_Examen As New FormulariosHse.Fr_ExamenMedicoPeriodico
            Fr_Examen.TIPO = 1
            Fr_Examen.EDITANDO = False
            Fr_Examen.guardado = False
            Fr_Examen.CargarTablas()
            Fr_Examen.ComportamientoPredeterminado()
            Fr_Examen.ShowDialog()
            System.Windows.Forms.Cursor.Current = Cursors.Default
            If Fr_Examen.guardado Then
                CargarTablaxDefectoExamenes()
            End If
        Else
            MsgBox("No cuenta con los permisos para crear")
        End If

    End Sub

    Private Sub Nbi_VerExamen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerExamen.ItemClick
        If tablacargada = Tablas.EXAMENESMEDICOS Then
            VerExamen()

        Else
            MsgBox("No está cargada la tabla de exámenes periódicos")
        End If
    End Sub

    Private Sub VerExamen()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Dim VerExamen As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerExamen.Tag) = True Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(940) Then
                    VerExamen = True
                Else
                    VerExamen = False
                End If
            End If

            If VerExamen = True Then
                Dim FrExamen As New FormulariosHse.Fr_ExamenMedicoPeriodico
                FrExamen.Text = "Viendo el reporte: " + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString
                FrExamen.TIPO = 2
                FrExamen.EDITANDO = False
                FrExamen.IDEXAMENMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value
                FrExamen.CargarTablas()
                FrExamen.ComportamientoPredeterminado()
                FrExamen.LlenarExamen()
                FrExamen.Bt_Guardar.Enabled = False
                FrExamen.ShowDialog()
                System.Windows.Forms.Cursor.Current = Cursors.Default
            Else
                MsgBox("No cuenta con los permisos para ver")
            End If

        End If
    End Sub

    Private Sub Nbi_CargarExamenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarExamenes.ItemClick
        CargarTablaxDefectoExamenes()
    End Sub

    Private Sub CargarTablaxDefectoExamenes()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        dsExamenes = bddatos.BusquedaCondiciones(58, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsExamenes.Tables.Count > 1 Then  'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsExamenes.Tables.Remove(dsExamenes.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsExamenes.Clear()
        End If
        tablacargada = Tablas.EXAMENESMEDICOS
        Lb_Cargado.Text = "Exámenes médicos"
        Lb_Filtro.Text = "Exámenes médicos"
        CargarExamenesFiltro(dsExamenes)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_EditarExamen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarExamen.ItemClick
        If tablacargada = Tablas.EXAMENESMEDICOS Then
            If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                'If Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "N" Then
                EditarExamen()
                'Else
                '    MsgBox("El examen " + Trim(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " tiene un concepto asociado y no se puede editar", vbCritical, "Examen médico periódico")
                '    Exit Sub
                'End If
            Else
                MsgBox("El examen " + Trim(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value) + " ya fue impreso y no se puede editar", vbCritical, "Examen médico periódico")
                Exit Sub
            End If
        Else
            MsgBox("No está cargada la tabla de exámenes medicos")
        End If
    End Sub

    Private Sub EditarExamen()
        Dim EditarExamen As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarExamen.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(941) Then
                EditarExamen = True
            Else
                EditarExamen = False
            End If
        End If

        EditarExamen = True
        If EditarExamen = True Then
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim FrExamen As New FormulariosHse.Fr_ExamenMedicoPeriodico
            FrExamen.TIPO = 2
            FrExamen.EDITANDO = True
            FrExamen.IDEXAMENMODIFICANDO = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value

            FrExamen.CargarTablas()
            FrExamen.ComportamientoPredeterminado()
            FrExamen.LlenarExamen()
            FrExamen.ShowDialog()
            System.Windows.Forms.Cursor.Current = Cursors.Default
            If FrExamen.guardado Then
                CargarTablaxDefectoExamenes()
            End If
        Else
            MsgBox("No cuenta con los permisos para editar")
        End If

    End Sub

    Private Sub Nbi_BuscarExamen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarExamen.ItemClick
        BuscarExamen()
    End Sub

    Private Sub BuscarExamen()
        Dim BuscarExamen As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarExamen.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(942) Then
                BuscarExamen = True
            Else
                BuscarExamen = False
            End If
        End If
        If BuscarExamen Then
            Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
            Dim campos As New System.Data.DataTable
            campos.Clear()
            campos.Columns.Add("Nombre")
            campos.Columns.Add("Descripcion")
            campos.Columns.Add("Tipo")
            'agregar campos
            campos.Rows.Add("P.IDENTIFICACION", "Identificación", "1")
            campos.Rows.Add("dbo.Personanombrecompleto(EM.IDPERSONA)", "Persona Examinada", "1")
            campos.Rows.Add("B.ABREVIATURABASE", "Abreviatura Base", "1")
            campos.Rows.Add("D.NOMBREDEPENDENCIA", "Dependencia", "1")
            campos.Rows.Add("T.NOMBRE", "Proyecto", "1")
            campos.Rows.Add("EM.TIPOEXAMEN", "Tipo de Examen", "1")
            campos.Rows.Add("EM.FECHAEXAMENMEDICO", "Fecha Examen", "3")
            campos.Rows.Add("EM.RECOMENDADOCARGO", "Apto/No Apto Cargo (S/N)", "1")
            frbuscar.campos = campos
            frbuscar.tabla = 58
            frbuscar.ShowDialog()
            dsExamenes = frbuscar.DsBuscar
            If dsExamenes.Tables.Count > 0 Then
                If dsExamenes.Tables(0).Rows.Count > 0 Then
                    CargarExamenesFiltro(dsExamenes)
                    tablacargada = Tablas.EXAMENESMEDICOS
                Else
                    MsgBox("Ningún Registro Encontrado")
                End If
            End If
        Else
            MsgBox("No cuenta con los permisos para buscar")
        End If
        Exit Sub
    End Sub
    Private Sub Nbi_RegistrarConcepto_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarConcepto.ItemClick, Nbi_EditarConcepto.ItemClick
        Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
        Dim RegistrarConcepto As Boolean = False
        Dim EditarConcepto As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarConcepto.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(943) Then
                RegistrarConcepto = True
            Else
                RegistrarConcepto = False
                MsgBox("No cuenta con los permisos para registrar conceptos.", MsgBoxStyle.Exclamation, "Permiso denegado")
                Exit Sub
            End If
        End If
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarConcepto.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(953) Then
                EditarConcepto = True
            Else
                EditarConcepto = False
                MsgBox("No cuenta con los permisos para editar conceptos.", MsgBoxStyle.Exclamation, "Permiso denegado")
                Exit Sub
            End If
        End If

        If tablacargada <> Tablas.EXAMENESMEDICOS Then
            MsgBox("No está cargada la tabla de exámenes medicos.", MsgBoxStyle.Exclamation, "Cargar Tablas")
            Exit Sub
        End If

        If Me.DGV_ListaReportes.Item("IMPRESO", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "S" Then
            MsgBox("El concepto médico ya fue impreso, no se puede editar.", MsgBoxStyle.Exclamation, "Impreso")
            Exit Sub
        End If

        If Boton.Name = "Nbi_RegistrarConcepto" Then
            If Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "S" Then
                MsgBox("Ya hay un concepto asociado a este examen médico.", MsgBoxStyle.Exclamation, "Concepto Asociado")
                Exit Sub
            End If
        End If

        If Boton.Name = "Nbi_EditarConcepto" Then
            If Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString = "N" Then
                MsgBox("No hay un concepto asociado a este examen médico para editar.", MsgBoxStyle.Exclamation, "Sin Concepto Asociado")
                Exit Sub
            End If
        End If
        Dim Titulo As String = ""
        Dim TipoExamen As String = ""
        TipoExamen = Me.DGV_ListaReportes.Item("TIPOEXAMEN", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString()

        Dim Fr_RegistrarConcepto As New Form

        Dim Gb_ProgramasVigilancia As New System.Windows.Forms.GroupBox
        Dim Ck_Biomecanico As New System.Windows.Forms.CheckBox
        Dim Ck_Auditivo As New System.Windows.Forms.CheckBox
        Dim Ck_Cardiovascular As New System.Windows.Forms.CheckBox
        Dim Ck_Respiratorio As New System.Windows.Forms.CheckBox
        Dim Ck_Dermatologico As New System.Windows.Forms.CheckBox
        Dim Ck_Psicosocial As New System.Windows.Forms.CheckBox
        Dim Ck_Visual As New System.Windows.Forms.CheckBox
        Dim Ck_RecomendadoCargo As New System.Windows.Forms.CheckBox
        Dim Ck_RecomendadoAlturas As New System.Windows.Forms.CheckBox
        Dim Ck_RecomendadoExcavaciones As New System.Windows.Forms.CheckBox
        Dim Ck_RecomendadoEspaciosConfinados As New System.Windows.Forms.CheckBox

        Dim Ck_Audiometria As New System.Windows.Forms.CheckBox
        Dim Ck_Visiometria As New System.Windows.Forms.CheckBox
        Dim Ck_Espirometria As New System.Windows.Forms.CheckBox
        Dim Ck_CuadroHematico As New System.Windows.Forms.CheckBox
        Dim Ck_PerfilLipidico As New System.Windows.Forms.CheckBox
        Dim Ck_GlicemiaBasal As New System.Windows.Forms.CheckBox
        Dim Ck_PerfilHepatico As New System.Windows.Forms.CheckBox
        Dim Ck_TestFobias As New System.Windows.Forms.CheckBox
        Dim Ck_ElectroCardiograma As New System.Windows.Forms.CheckBox
        Dim Ck_RxTorax As New System.Windows.Forms.CheckBox
        Dim Ck_KOHCoprologicoFrotisFaringeo As New System.Windows.Forms.CheckBox
        Dim Ck_RxColumna As New System.Windows.Forms.CheckBox
        Dim Ck_RmnColumna As New System.Windows.Forms.CheckBox
        Dim Ck_Sensopsicometrico As New System.Windows.Forms.CheckBox
        Dim Ck_ParcialOrina As New System.Windows.Forms.CheckBox
        Dim Ck_Otros As New System.Windows.Forms.CheckBox

        Dim Gb_Apto As New System.Windows.Forms.GroupBox
        Dim Gb_Laboratorios As New System.Windows.Forms.GroupBox
        Dim Tb_OtrosLaboratorios As New System.Windows.Forms.TextBox

        Dim Gb_Concepto As New System.Windows.Forms.GroupBox
        Dim Tb_Concepto As New System.Windows.Forms.TextBox

        Dim Gb_Recomendaciones As New System.Windows.Forms.GroupBox
        Dim Tb_Recomendaciones As New System.Windows.Forms.TextBox

        Dim Bt_Aceptar As New System.Windows.Forms.Button
        Dim Bt_Cancelar As New System.Windows.Forms.Button

        Dim UbicacionXGb As Integer = 10, UbicacionYGb As Integer = 10, UbicacionXCk As Integer = 10, UbicacionYCk As Integer = 20
        Dim TamañoX As Integer = 485, TamañoY As Integer = 370
        Dim TabIndex As Integer = 0
        If TipoExamen = "P" Then
            Titulo = " periódico"
            TamañoX = 485
            TamañoY = 530
        End If

        If TipoExamen = "E" Then
            Titulo = " de egreso"
            TamañoX = 485
            TamañoY = 300
        End If

        If TipoExamen = "I" Then
            Titulo = " de ingreso"
            TamañoX = 485
            TamañoY = 635
            TabIndex += 1
            With Gb_Apto
                .Location = New System.Drawing.Point(UbicacionXGb, UbicacionYGb)
                .Size = New System.Drawing.Size(450, 105)
                .Name = "Gb_Apto"
                .Text = "Recomendado"
                '.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .Controls.Add(Ck_RecomendadoCargo)
                .Controls.Add(Ck_RecomendadoAlturas)
                .Controls.Add(Ck_RecomendadoExcavaciones)
                .Controls.Add(Ck_RecomendadoEspaciosConfinados)
                .TabIndex = TabIndex
            End With

            With Ck_RecomendadoCargo
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RecomendadoCargo"
                .Text = "Recomendado para el cargo"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            UbicacionYCk += 20

            With Ck_RecomendadoAlturas
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RecomendadoAlturas"
                .Text = "Recomendado para trabajo en alturas"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            UbicacionYCk += 20

            With Ck_RecomendadoExcavaciones
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RecomendadoExcavaciones"
                .Text = "Recomendado para trabajo en excavaciones"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            UbicacionYCk += 20

            With Ck_RecomendadoEspaciosConfinados
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RecomendadoEspaciosConfinados"
                .Text = "Recomendado para trabajo en espacios confinados"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            UbicacionYGb += 110
            UbicacionXCk = 10
            UbicacionYCk = 20
        End If

        If TipoExamen = "I" Or TipoExamen = "P" Then
            With Gb_ProgramasVigilancia
                .Location = New System.Drawing.Point(UbicacionXGb, UbicacionYGb)
                .Size = New System.Drawing.Size(450, 70)
                .Name = "Gb_ProgramasVigilancia"
                .Text = "Programas De Vigilancia"
                .Controls.Add(Ck_Biomecanico)
                .Controls.Add(Ck_Auditivo)
                .Controls.Add(Ck_Cardiovascular)
                .Controls.Add(Ck_Respiratorio)
                .Controls.Add(Ck_Dermatologico)
                .Controls.Add(Ck_Psicosocial)
                .Controls.Add(Ck_Visual)
                .TabIndex = TabIndex
            End With
            TabIndex += 1

            With Ck_Biomecanico
                .Location = New System.Drawing.Point(10, 20)
                .Name = "Ck_Biomecanico"
                .Text = "Biomecánico"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1

            With Ck_Auditivo
                .Location = New System.Drawing.Point(115, 20)
                .Name = "Ck_Auditivo"
                .Text = "Auditivo"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            With Ck_Cardiovascular
                .Location = New System.Drawing.Point(215, 20)
                .Name = "Ck_Cardiovascular"
                .Text = "Cardiovascular"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            With Ck_Respiratorio
                .Location = New System.Drawing.Point(330, 20)
                .Name = "Ck_Respiratorio"
                .Text = "Respiratorio"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            With Ck_Dermatologico
                .Location = New System.Drawing.Point(10, 40)
                .Name = "Ck_Dermatologico"
                .Text = "Dermatológico"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            With Ck_Psicosocial
                .Location = New System.Drawing.Point(115, 40)
                .Name = "Ck_Psicosocial"
                .Text = "Psicosocial"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            With Ck_Visual
                .Location = New System.Drawing.Point(215, 40)
                .Name = "Ck_Visual"
                .Text = "Visual"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            UbicacionYGb += 75
            UbicacionXCk = 10
            UbicacionYCk = 20
            TabIndex += 1
        End If

        With Gb_Concepto
            .Location = New System.Drawing.Point(UbicacionXGb, UbicacionYGb)
            .Size = New System.Drawing.Size(450, 100)
            .Name = "Gb_Concepto"
            .Text = "Concepto"
            .Controls.Add(Tb_Concepto)
            .TabIndex = TabIndex
        End With
        TabIndex += 1
        With Tb_Concepto
            .Location = New System.Drawing.Point(10, 20)
            .Size = New System.Drawing.Size(430, 70)
            .Multiline = True
            .Name = "Tb_Concepto"
            .MaxLength = 300
            .TabIndex = TabIndex
        End With

        UbicacionYGb += 105
        UbicacionXCk = 10
        UbicacionYCk = 20
        TabIndex += 1
        With Gb_Recomendaciones
            .Location = New System.Drawing.Point(UbicacionXGb, UbicacionYGb)
            .Size = New System.Drawing.Size(450, 100)
            .Name = "Gb_Recomendaciones"
            .Text = "Recomendaciones"
            .Controls.Add(Tb_Recomendaciones)
            .TabIndex = TabIndex
        End With
        TabIndex += 1
        With Tb_Recomendaciones
            .Location = New System.Drawing.Point(10, 20)
            .Size = New System.Drawing.Size(430, 70)
            .Multiline = True
            .Name = "Tb_Recomendaciones"
            .MaxLength = 300
            .TabIndex = TabIndex
        End With

        UbicacionYGb += 105
        UbicacionXCk = 10
        UbicacionYCk = 20
        TabIndex += 1
        If TipoExamen = "I" Or TipoExamen = "P" Then
            With Gb_Laboratorios
                .Location = New System.Drawing.Point(UbicacionXGb, UbicacionYGb)
                .Size = New System.Drawing.Size(450, 155)
                .Name = "Gb_Laboratorios"
                .Text = "Examenes Paraclinicos Realizados"
                .Controls.Add(Ck_Audiometria)
                .Controls.Add(Ck_Visiometria)
                .Controls.Add(Ck_Espirometria)
                .Controls.Add(Ck_CuadroHematico)
                .Controls.Add(Ck_PerfilLipidico)
                .Controls.Add(Ck_GlicemiaBasal)
                .Controls.Add(Ck_PerfilHepatico)
                .Controls.Add(Ck_TestFobias)
                .Controls.Add(Ck_ElectroCardiograma)
                .Controls.Add(Ck_RxTorax)
                .Controls.Add(Ck_KOHCoprologicoFrotisFaringeo)
                .Controls.Add(Ck_RxColumna)
                .Controls.Add(Ck_RmnColumna)
                .Controls.Add(Ck_Sensopsicometrico)
                .Controls.Add(Ck_ParcialOrina)
                .Controls.Add(Ck_Otros)
                .Controls.Add(Tb_OtrosLaboratorios)
                .TabIndex = TabIndex
            End With
            TabIndex += 1

            With Ck_Audiometria
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_Audiometría"
                .Text = "Audiometria"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            UbicacionYCk += 20
            TabIndex += 1

            With Ck_Visiometria
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_Visiometria"
                .Text = "Visiometría"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_Espirometria
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_Espirometria"
                .Text = "Espirometría"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_CuadroHematico
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_CuadroHematico"
                .Text = "C. Hemático"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_PerfilLipidico
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_PerfilLipidico"
                .Text = "Perfil Lipídico"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk = 20
            UbicacionXCk += 120

            With Ck_GlicemiaBasal
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_GlicemiaBasal"
                .Text = "Glicemia Basal"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_PerfilHepatico
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_PerfilHepatico"
                .Text = "Perfil Hepático"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_TestFobias
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_TestFobias"
                .Text = "Test de Fobias"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_ElectroCardiograma
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_ElectroCardiograma"
                .Text = "EKG"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With
            TabIndex += 1
            UbicacionYCk += 20

            With Ck_RxTorax
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RxTorax"
                .Text = "Rx Tórax"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk = 20
            UbicacionXCk += 120

            With Ck_KOHCoprologicoFrotisFaringeo
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_KOHCoprologicoFrotisFaringeo"
                .Text = "KOH, Coprológico, Frotis Faringeo"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_RxColumna
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RxColumna"
                .Text = "Rx Columna Dinámica"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionYCk += 20

            With Ck_RmnColumna
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_RmnColumna"
                .Text = "Rmn Lumbosacra"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            UbicacionYCk += 20

            TabIndex += 1
            With Ck_Sensopsicometrico
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_Sensopsicometrico"
                .Text = "Sensopsicométrico"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            UbicacionYCk += 20

            TabIndex += 1
            With Ck_ParcialOrina
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_ParcialOrina"
                .Text = "Parcial de Orina"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionXCk = 10
            UbicacionYCk += 20

            With Ck_Otros
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Ck_Otros"
                .Text = "Otros"
                .AutoSize = True
                .CheckState = CheckState.Indeterminate
                .TabIndex = TabIndex
            End With

            TabIndex += 1
            UbicacionXCk = 130

            With Tb_OtrosLaboratorios
                .Location = New System.Drawing.Point(UbicacionXCk, UbicacionYCk)
                .Name = "Tb_OtrosLaboratorios"
                .Size = New System.Drawing.Size(140, 30)
                .MaxLength = 20
                .TabIndex = TabIndex
                .Hide()
            End With
            UbicacionYGb += 160
        End If

        TabIndex += 1
        With Bt_Aceptar
            .Location = New System.Drawing.Point(145, UbicacionYGb)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(85, 23)
            .TabIndex = TabIndex
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        TabIndex += 1
        With Bt_Cancelar
            .Location = New System.Drawing.Point(240, UbicacionYGb)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = TabIndex
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_RegistrarConcepto
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .AcceptButton = Bt_Aceptar
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(TamañoX, TamañoY)
            .MaximumSize = New System.Drawing.Size(TamañoX, TamañoY)
            .MinimumSize = New System.Drawing.Size(TamañoX, TamañoY)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Registrar concepto examen medico" + Titulo + ", Id: " + Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(Gb_Apto)
            .Controls.Add(Gb_Laboratorios)
            .Controls.Add(Gb_ProgramasVigilancia)
            .Controls.Add(Gb_Concepto)
            .Controls.Add(Gb_Recomendaciones)
        End With


        If TipoExamen = "P" Then
            Gb_Apto.Hide()
        End If
        If TipoExamen = "E" Then
            Gb_Apto.Hide()
            Gb_ProgramasVigilancia.Hide()
            Gb_Laboratorios.Hide()
        End If

        Dim Registrar As Boolean = False
        Dim vigilancia As String = ""
        Dim RecomendadoCargo As String = ""
        Dim RecomendadoTareas As String = ""
        Dim LaboratoriosEnviados As String = ""
        Dim OtrosLaboratoriosEnviados As String = ""
        Dim Guardado As Boolean = False

        Dim IdExamen As Integer = Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString
        If Boton.Name = "Nbi_EditarConcepto" Then
            Dim Examen As New System.Data.DataTable
            Dim Cadena_Consulta As String = "SELECT TIPOEXAMEN,PROGRAMASVIGILANCIA,CONCEPTO,RECOMENDACIONES,RECOMENDADOCARGO,APTOTIPOTRABAJO,LABORATORIOSREALIZADOS,OTROSLABORATORIOS  FROM HSE_HC_EXAMENMEDICOPERIODICO WHERE IDEXAMENMEDICO = @IDEXAMEN"
            Dim Consulta As New SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Parameters.AddWithValue("@IDEXAMEN", IdExamen)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Adaptador.FillSchema(Examen, SchemaType.Source)
            Adaptador.Fill(Examen)
            Consulta.Connection.Close()
            Dim FilaExamen As DataRow
            FilaExamen = Examen(0)
            If TipoExamen = "I" Or TipoExamen = "P" Then
                Dim programasvigilancia As String = FilaExamen("PROGRAMASVIGILANCIA").ToString
                Dim ch As Char = programasvigilancia(0)
                Ck_Biomecanico.CheckState = CheckState.Unchecked
                If ch = "S" Then
                    Ck_Biomecanico.Checked = True
                Else
                    Ck_Biomecanico.Checked = False
                End If
                ch = programasvigilancia(1)
                Ck_Auditivo.CheckState = CheckState.Unchecked
                If ch = "S" Then
                    Ck_Auditivo.Checked = True
                Else
                    Ck_Auditivo.Checked = False
                End If
                ch = programasvigilancia(2)
                Ck_Cardiovascular.CheckState = CheckState.Unchecked
                If ch = "S" Then
                    Ck_Cardiovascular.Checked = True
                Else
                    Ck_Cardiovascular.Checked = False
                End If
                ch = programasvigilancia(3)
                Ck_Respiratorio.CheckState = CheckState.Unchecked
                If ch = "S" Then
                    Ck_Respiratorio.Checked = True
                Else
                    Ck_Respiratorio.Checked = False
                End If
                ch = programasvigilancia(4)
                Ck_Dermatologico.CheckState = CheckState.Unchecked
                If ch = "S" Then
                    Ck_Dermatologico.Checked = True
                Else
                    Ck_Dermatologico.Checked = False
                End If
                ch = programasvigilancia(5)
                Ck_Psicosocial.CheckState = CheckState.Unchecked
                If ch = "S" Then
                    Ck_Psicosocial.Checked = True
                Else
                    Ck_Psicosocial.Checked = False
                End If

                Try
                    ch = programasvigilancia(6)
                    Ck_Visual.CheckState = CheckState.Unchecked
                    If ch = "S" Then
                        Ck_Visual.Checked = True
                    Else
                        Ck_Visual.Checked = False
                    End If
                Catch ex As Exception

                End Try

            End If

            Tb_Concepto.Text = FilaExamen("CONCEPTO").ToString
            Tb_Recomendaciones.Text = FilaExamen("RECOMENDACIONES").ToString


            If TipoExamen = "I" Then
                Dim recomendadoparacargo As String = FilaExamen("RECOMENDADOCARGO").ToString
                Ck_RecomendadoCargo.CheckState = CheckState.Unchecked
                If recomendadoparacargo(0) = "S" Then
                    Ck_RecomendadoCargo.Checked = True
                Else
                    Ck_RecomendadoCargo.Checked = False
                End If

                Dim aptotipotrabajo As String = FilaExamen("APTOTIPOTRABAJO").ToString
                Dim att As Char = aptotipotrabajo(0)
                Ck_RecomendadoAlturas.CheckState = CheckState.Unchecked
                If att = "S" Then
                    Ck_RecomendadoAlturas.Checked = True
                Else
                    Ck_RecomendadoAlturas.Checked = False
                End If
                att = aptotipotrabajo(1)
                Ck_RecomendadoExcavaciones.CheckState = CheckState.Unchecked
                If att = "S" Then
                    Ck_RecomendadoExcavaciones.Checked = True
                Else
                    Ck_RecomendadoExcavaciones.Checked = False
                End If
                att = aptotipotrabajo(2)
                Ck_RecomendadoEspaciosConfinados.CheckState = CheckState.Unchecked
                If att = "S" Then
                    Ck_RecomendadoEspaciosConfinados.Checked = True
                Else
                    Ck_RecomendadoEspaciosConfinados.Checked = False
                End If
            End If

            If TipoExamen = "I" Or TipoExamen = "P" Then
                Dim Laboratorios As String = FilaExamen("LABORATORIOSREALIZADOS").ToString
                Dim Lab As Char = Laboratorios(0)
                Ck_Audiometria.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_Audiometria.Checked = True
                Else
                    Ck_Audiometria.Checked = False
                End If

                Lab = Laboratorios(1)
                Ck_Visiometria.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_Visiometria.Checked = True
                Else
                    Ck_Visiometria.Checked = False
                End If

                Lab = Laboratorios(2)
                Ck_Espirometria.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_Espirometria.Checked = True
                Else
                    Ck_Espirometria.Checked = False
                End If

                Lab = Laboratorios(3)
                Ck_CuadroHematico.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_CuadroHematico.Checked = True
                Else
                    Ck_CuadroHematico.Checked = False
                End If

                Lab = Laboratorios(4)
                Ck_PerfilLipidico.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_PerfilLipidico.Checked = True
                Else
                    Ck_PerfilLipidico.Checked = False
                End If

                Lab = Laboratorios(5)
                Ck_GlicemiaBasal.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_GlicemiaBasal.Checked = True
                Else
                    Ck_GlicemiaBasal.Checked = False
                End If

                Lab = Laboratorios(6)
                Ck_PerfilHepatico.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_PerfilHepatico.Checked = True
                Else
                    Ck_PerfilHepatico.Checked = False
                End If

                Lab = Laboratorios(7)
                Ck_TestFobias.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_TestFobias.Checked = True
                Else
                    Ck_TestFobias.Checked = False
                End If

                Lab = Laboratorios(8)
                Ck_ElectroCardiograma.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_ElectroCardiograma.Checked = True
                Else
                    Ck_ElectroCardiograma.Checked = False
                End If

                Lab = Laboratorios(9)
                Ck_RxTorax.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_RxTorax.Checked = True
                Else
                    Ck_RxTorax.Checked = False
                End If

                Lab = Laboratorios(10)
                Ck_KOHCoprologicoFrotisFaringeo.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_KOHCoprologicoFrotisFaringeo.Checked = True
                Else
                    Ck_KOHCoprologicoFrotisFaringeo.Checked = False
                End If

                Lab = Laboratorios(11)
                Ck_RxColumna.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_RxColumna.Checked = True
                Else
                    Ck_RxColumna.Checked = False
                End If

                Lab = Laboratorios(12)
                Ck_RmnColumna.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_RmnColumna.Checked = True
                Else
                    Ck_RmnColumna.Checked = False
                End If

                Lab = Laboratorios(13)
                Ck_Sensopsicometrico.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_Sensopsicometrico.Checked = True
                Else
                    Ck_Sensopsicometrico.Checked = False
                End If

                Lab = Laboratorios(14)
                Ck_ParcialOrina.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_ParcialOrina.Checked = True
                Else
                    Ck_ParcialOrina.Checked = False
                End If

                Lab = Laboratorios(15)
                Ck_Otros.CheckState = CheckState.Unchecked
                If Lab = "S" Then
                    Ck_Otros.Checked = True
                    Tb_OtrosLaboratorios.Show()
                    Tb_OtrosLaboratorios.Text = FilaExamen("OTROSLABORATORIOS").ToString
                Else
                    Ck_Otros.Checked = False
                End If
            End If

        End If

        AddHandler Ck_Otros.CheckedChanged, Sub()
                                                If Ck_Otros.Checked Then
                                                    Tb_OtrosLaboratorios.Show()
                                                Else
                                                    Tb_OtrosLaboratorios.Hide()
                                                End If
                                            End Sub

        AddHandler Bt_Aceptar.Click, Sub()

                                         If TipoExamen = "I" Then
                                             If Ck_RecomendadoCargo.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Recomendado para el cargo.")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_RecomendadoAlturas.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Recomendado para trabajo en alturas.")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_RecomendadoExcavaciones.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Recomendado para trabajo en excavaciones")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_RecomendadoEspaciosConfinados.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Recomendado para trabajo en espacios confinados.")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                         End If

                                         If Ck_Biomecanico.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Biomecánico")
                                             Registrar = False
                                             Exit Sub
                                         End If
                                         If Ck_Auditivo.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Auditivo")
                                             Registrar = False
                                             Exit Sub
                                         End If
                                         If Ck_Cardiovascular.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Cardiovascular")
                                             Registrar = False
                                             Exit Sub
                                         End If
                                         If Ck_Respiratorio.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Respiratorio")
                                             Registrar = False
                                             Exit Sub
                                         End If
                                         If Ck_Dermatologico.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Dermatológico")
                                             Registrar = False
                                             Exit Sub
                                         End If
                                         If Ck_Psicosocial.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Psicosocial")
                                             Registrar = False
                                             Exit Sub
                                         End If
                                        If Ck_Visual.CheckState = CheckState.Indeterminate Then
                                             MsgBox("Debe seleccionar si o no para el campo Visual")
                                             Registrar = False
                                             Exit Sub
                                         End If

                                         If Trim(Tb_Concepto.Text) = "" Then
                                             MsgBox("Debe ingresar el concepto")
                                             Registrar = False
                                             Exit Sub
                                         End If

                                         If Trim(Tb_Recomendaciones.Text) = "" Then
                                             MsgBox("Debe ingresar las recomendaciones")
                                             Registrar = False
                                             Exit Sub
                                         End If

                                         If TipoExamen = "I" Or TipoExamen = "P" Then
                                             If Ck_Audiometria.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Audiometria")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_Visiometria.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Visiometria")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_Espirometria.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Espirometria")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_CuadroHematico.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Cuadro Hematico")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_PerfilLipidico.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Perfil Lipidico")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_GlicemiaBasal.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Glicemia Basal")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_TestFobias.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Test de Fobias")
                                                 Registrar = False
                                                 Exit Sub
                                             End If

                                             If Ck_ElectroCardiograma.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Electrocardiograma")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_RxTorax.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Rx Torax")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_KOHCoprologicoFrotisFaringeo.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo KOH, Coprologico, Frotis Faringeo")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_RxColumna.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Rx Columna")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_RmnColumna.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Rmn Columna")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_Sensopsicometrico.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Sensopsicometrico")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_ParcialOrina.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Parcial de Orina")
                                                 Registrar = False
                                                 Exit Sub
                                             End If
                                             If Ck_Otros.CheckState = CheckState.Indeterminate Then
                                                 MsgBox("Debe seleccionar si o no para el campo Otros")
                                                 Registrar = False
                                                 Exit Sub
                                             End If

                                             If Ck_Otros.Checked = True Then
                                                 If Trim(Tb_OtrosLaboratorios.Text) = "" Then
                                                     MsgBox("Debe indicar cuales fueron los otros laboratorios.")
                                                     Registrar = False
                                                     Exit Sub
                                                 End If
                                             End If

                                         End If


                                         Registrar = True

                                         If TipoExamen = "I" Then
                                             If Ck_RecomendadoCargo.Checked Then
                                                 RecomendadoCargo = "S"
                                             Else
                                                 RecomendadoCargo = "N"
                                             End If

                                             If Ck_RecomendadoAlturas.Checked Then
                                                 RecomendadoTareas += "S"
                                             Else
                                                 RecomendadoTareas += "N"
                                             End If
                                             If Ck_RecomendadoExcavaciones.Checked Then
                                                 RecomendadoTareas += "S"
                                             Else
                                                 RecomendadoTareas += "N"
                                             End If
                                             If Ck_RecomendadoEspaciosConfinados.Checked Then
                                                 RecomendadoTareas += "S"
                                             Else
                                                 RecomendadoTareas += "N"
                                             End If
                                         Else
                                             RecomendadoCargo = Nothing
                                             RecomendadoTareas = Nothing
                                         End If
                                         If TipoExamen = "I" Or TipoExamen = "P" Then
                                             If Ck_Audiometria.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_Visiometria.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_Espirometria.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_CuadroHematico.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_PerfilLipidico.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_GlicemiaBasal.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_PerfilHepatico.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_TestFobias.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_ElectroCardiograma.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_RxTorax.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_KOHCoprologicoFrotisFaringeo.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_RxColumna.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_RmnColumna.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_Sensopsicometrico.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_ParcialOrina.Checked Then
                                                 LaboratoriosEnviados += "S"
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                             If Ck_Otros.Checked Then
                                                 LaboratoriosEnviados += "S"
                                                 OtrosLaboratoriosEnviados = Tb_OtrosLaboratorios.Text
                                             Else
                                                 LaboratoriosEnviados += "N"
                                             End If
                                         Else
                                             LaboratoriosEnviados = Nothing
                                             OtrosLaboratoriosEnviados = Nothing
                                         End If


                                         'LaboratoriosEnviados
                                         If TipoExamen = "I" Or TipoExamen = "P" Then

                                             If Ck_Biomecanico.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If

                                             If Ck_Auditivo.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If

                                             If Ck_Cardiovascular.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If

                                             If Ck_Respiratorio.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If

                                             If Ck_Dermatologico.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If

                                             If Ck_Psicosocial.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If
                                             
                                             If Ck_Visual.Checked Then
                                                 vigilancia += "S"
                                             Else
                                                 vigilancia += "N"
                                             End If
                                         Else
                                             vigilancia = Nothing
                                         End If

                                         If Registrar = True Then
                                             Guardado = GuardarConcepto(Me.DGV_ListaReportes.Item("Id", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString, RecomendadoCargo, RecomendadoTareas, vigilancia, Tb_Concepto.Text, Tb_Recomendaciones.Text, LaboratoriosEnviados, OtrosLaboratoriosEnviados)
                                         End If
                                         Fr_RegistrarConcepto.Close()
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()
                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then
                                              Fr_RegistrarConcepto.Close()
                                              Guardado = False
                                          End If
                                      End Sub

        If RegistrarConcepto Then
            Fr_RegistrarConcepto.ShowDialog()
            CargarListaxSeleccion()
            Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value = "S"

            If Guardado = True Then
                IMPRIMIR(2)
            End If

            CargarTablaxDefectoExamenes()
        Else
            MsgBox("No cuenta con los permisos para registrar el concepto.", MsgBoxStyle.Exclamation, "Concepto Asociado")
        End If

    End Sub

    Private Function GuardarConcepto(ByVal IdExamenMedico As String, ByVal RecomendadoCargo As String, ByVal AptoTipoTrabajo As String, ByVal ProgramasVigilancia As String, ByVal Concepto As String, ByVal Recomendaciones As String, ByVal LaboratoriosRealizados As String, ByVal OtrosLaboratorios As String) As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo.GestionarExamenMedicoConcepto")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@IDEXAMENMEDICO", IdExamenMedico)
        Comando.Parameters.AddWithValue("@TIPO", 1)
        Comando.Parameters.AddWithValue("@RECOMENDADOCARGO", IIf(RecomendadoCargo Is Nothing, DBNull.Value, RecomendadoCargo))
        Comando.Parameters.AddWithValue("@APTOTIPOTRABAJO", IIf(AptoTipoTrabajo Is Nothing, DBNull.Value, AptoTipoTrabajo))
        Comando.Parameters.AddWithValue("@PROGRAMASVIGILANCIA", IIf(ProgramasVigilancia Is Nothing, DBNull.Value, ProgramasVigilancia))
        Comando.Parameters.AddWithValue("@CONCEPTO", Concepto)
        Comando.Parameters.AddWithValue("@RECOMENDACIONES", Recomendaciones)
        Comando.Parameters.AddWithValue("@LABORATORIOSREALIZADOS", IIf(LaboratoriosRealizados Is Nothing, DBNull.Value, LaboratoriosRealizados))
        Comando.Parameters.AddWithValue("@OTROSLABORATORIOS", IIf(OtrosLaboratorios Is Nothing, DBNull.Value, OtrosLaboratorios))
        Comando.Parameters.AddWithValue("@PERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDENFERMEDAD", DBNull.Value)
        Comando.Parameters.AddWithValue("@IDGRUPOENFERMEDAD", DBNull.Value)

        conexion.Open()
        Comando.Connection = conexion
        Try
            Comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.ToString)
        End Try
        MsgBox("Concepto guardado")
        Return True
    End Function

    Private Sub Nbi_ImprimirConceptoMedico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirConceptoMedico.ItemClick
        If tablacargada = Tablas.EXAMENESMEDICOS Then
            Dim ImprimirExamen As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarExamen.Tag) = True Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(944) Then
                    ImprimirExamen = True
                Else
                    ImprimirExamen = False
                End If
            End If
            If ImprimirExamen Then
                IMPRIMIR(2)
            Else
                MsgBox("No cuenta con los permisos para imprimir el examen")
            End If

        Else
            MsgBox("No está cargada la tabla de Exámenes Médicos")
        End If
    End Sub

    Private Sub Nbi_HabilitarImpresionConcepto_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarImpresionConcepto.ItemClick
        If tablacargada = Tablas.EXAMENESMEDICOS Then
            Dim Habilitar As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarExamen.Tag) = True Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(944) Then
                    Habilitar = True
                Else
                    Habilitar = False
                End If
            End If
            If Habilitar Then
                HabilitarImpresion()
            Else
                MsgBox("No cuenta con los permisos para habilitar la impresión")
            End If

        Else
            MsgBox("No está cargada la tabla de Exámenes Médicos")
        End If
    End Sub

    Private Sub Cu_Hse_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, DGV_ListaReportes.KeyDown, Nbc_HSE.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                'FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Materiales")
            Case Keys.F2
                Select Case Nbc_HSE.ActiveGroup.Name
                    'Crear
                    Case Nbg_Reportes.Name
                        CrearReporte24H()
                    Case Nbg_ResumenEstadistico.Name
                        RegistrarDatosResumenEstadistico()
                    Case Nbg_ExamenMedico.Name
                        CrearExamen()
                End Select
            Case Keys.F3
                'Buscar
                Select Case Nbc_HSE.ActiveGroup.Name
                    Case Nbg_Reportes.Name
                        BuscarReporte24H()
                    Case Nbg_Investigaciones.Name
                        BuscarInvestigacion()
                    Case Nbg_ResumenEstadistico.Name
                        BuscarResumenEstadistico()
                    Case Nbg_ExamenMedico.Name
                        BuscarExamen()
                End Select
            Case Keys.F4
                Select Case Nbc_HSE.ActiveGroup.Name
                    Case Nbg_Reportes.Name
                        CargarTablaxDefectoReportes24H()
                    Case Nbg_Investigaciones.Name
                        CargarTablaxDefectoReportesInvestigacion()
                    Case Nbg_ResumenEstadistico.Name
                        CargarTablaxDefectoResumenEstadistico()
                    Case Nbg_ExamenMedico.Name
                        CargarTablaxDefectoExamenes()
                End Select
            Case Keys.F5

            Case Keys.F6
                ExportarDatosExcel(DGV_ListaReportes)
            Case Keys.F7

            Case Keys.F8

            Case Keys.F9

            Case Keys.F10

            Case Keys.F11

            Case Keys.F12
                FuncionesBase.FuncionesBase.AbrirAccesoRemoto()
        End Select
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)

        Dim m_Excel As New Application
        m_Excel.Cursor = XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Worksheet = objLibroExcel.Worksheets(1)

        With objHojaExcel
            .Name = ("Datos Exportados")
            .Visible = XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Range
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

            Dim objRangoEncab As Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, DGV_ListaReportes.Columns.Count)).Font
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
                Dim objRangoReg As Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
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
            Dim objRango As Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = XlMousePointer.xlDefault
    End Sub

    Private Sub Nbi_InformeCondicionesSalud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_InformeCondicionesSalud.ItemClick
        Dim Consultar As New Boolean
        Dim Fr_InformeSalud As New Form
        Dim Lb_FechaInicial As New System.Windows.Forms.Label
        Dim Lb_FechaFinal As New System.Windows.Forms.Label
        Dim Lb_TipoExamen As New System.Windows.Forms.Label
        Dim Dtp_FechaInicial As New DateTimePicker
        Dim Dtp_FechaFinal As New DateTimePicker
        Dim Bt_Aceptar As New System.Windows.Forms.Button
        Dim Bt_Cancelar As New System.Windows.Forms.Button
        Dim Cb_TipoExamen As New System.Windows.Forms.ComboBox


        With Lb_FechaInicial
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 10)
            .Name = "Lb_FechaInicial"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Fecha Inicial"
            .TabIndex = 1
        End With

        With Dtp_FechaInicial
            .AutoSize = True
            .Location = New System.Drawing.Point(95, 5)
            .Format = DateTimePickerFormat.Short
            .Name = "Dtp_FechaFinal"
            .Size = New System.Drawing.Size(100, 13)
            .TabIndex = 2
        End With

        With Lb_FechaFinal
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 35)
            .Name = "Lb_FechaFinal"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Fecha Final"
            .TabIndex = 3
        End With

        With Dtp_FechaFinal
            .AutoSize = True
            .Location = New System.Drawing.Point(95, 30)
            .Name = "Dtp_FechaFinal"
            .Format = DateTimePickerFormat.Short
            .Size = New System.Drawing.Size(100, 13)
            .TabIndex = 4
        End With

        With Lb_TipoExamen
            .AutoSize = True
            .Location = New System.Drawing.Point(10, 55)
            .Name = "Lb_TipoExamen"
            .Size = New System.Drawing.Size(70, 13)
            .Text = "Tipo de Informe"
            .TabIndex = 5
        End With

        With Cb_TipoExamen
            .Location = New System.Drawing.Point(95, 55)
            .Name = "Cb_TipoExamen"
            .Size = New System.Drawing.Size(100, 13)
            .TabIndex = 6
        End With

        With Bt_Aceptar
            .Location = New System.Drawing.Point(100, 83)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(85, 23)
            .TabIndex = 7
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With


        With Bt_Cancelar
            .Location = New System.Drawing.Point(20, 83)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 8
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_InformeSalud
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(220, 150)
            .MaximumSize = New System.Drawing.Size(220, 150)
            .MinimumSize = New System.Drawing.Size(220, 150)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Informe De Condiciones De Salud"
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .Controls.Add(Lb_FechaFinal)
            .Controls.Add(Lb_FechaInicial)
            .Controls.Add(Dtp_FechaFinal)
            .Controls.Add(Dtp_FechaInicial)
            .Controls.Add(Lb_TipoExamen)
            .Controls.Add(Cb_TipoExamen)
        End With

        Cb_TipoExamen.Items.Add("Ingreso")
        Cb_TipoExamen.Items.Add("Periodico")
        Cb_TipoExamen.Items.Add("Egreso")

        AddHandler Bt_Aceptar.Click, Sub()
                                         Dim inicial As DateTime = Dtp_FechaInicial.Value
                                         Dim final As DateTime = Dtp_FechaFinal.Value
                                         If inicial > final Then
                                             Consultar = False
                                             MsgBox("La fecha final no puede ser menor a la fecha inicial")
                                             Exit Sub
                                         End If
                                         If MsgBox("Seguro desea exportar el excel del informe de condiciones de salud", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then
                                             Consultar = True
                                             Fr_InformeSalud.Close()
                                         End If
                                     End Sub

        AddHandler Bt_Cancelar.Click, Sub()
                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then
                                              Consultar = False
                                              Fr_InformeSalud.Close()
                                          End If
                                      End Sub
        Fr_InformeSalud.ShowDialog()

        If Consultar = True Then
            ExportarExcel_InformeCondicionesSalud(Dtp_FechaInicial.Value, Dtp_FechaFinal.Value, Cb_TipoExamen.SelectedItem)
        End If
    End Sub

    Private Sub ExportarExcel_InformeCondicionesSalud(ByVal FechaInicial As DateTime, ByVal FechaFinal As DateTime, ByVal TipoExamen As String)
        Dim DsInformeSalud As New DataSet
        Dim conexion As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Dim comando As New SqlCommand("dbo.InformeCondicionesSalud", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@FechaInicial", FechaInicial.ToShortDateString)
        comando.Parameters.AddWithValue("@FechaFinal", FechaFinal.ToShortDateString)
        If TipoExamen = "Periodico" Then
            comando.Parameters.AddWithValue("@TipoExamen", "P")
        Else
            If TipoExamen = "Ingreso" Then
                comando.Parameters.AddWithValue("@TipoExamen", "I")
            Else
                comando.Parameters.AddWithValue("@TipoExamen", "E")
            End If
        End If

        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(DsInformeSalud)
            conexion.Close()
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try
        If DsInformeSalud.Tables.Count = 0 Then
            MsgBox("No hay información para exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        End If

        Dim CantidadRegistrosEntreFechas As Integer = DsInformeSalud.Tables(0).Rows(0).Item(0)

        Dim m_Excel As New Application
        m_Excel.Cursor = XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Workbook = m_Excel.Workbooks.Add

        For i As Integer = 0 To 15
            objLibroExcel.Worksheets.Add()
        Next

        Dim objGenero As Worksheet = objLibroExcel.Worksheets(1)
        With objGenero
            .Name = ("Genero")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(1).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(1).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(1).Columns
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

        Dim GraficoBarras As Boolean = False
        Dim CantidadFilasCero As Integer = 0
        For i As Integer = 0 To DsInformeSalud.Tables(1).Rows.Count - 1
            If DsInformeSalud.Tables(1).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero = +1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(1).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B3", objGenero, 150, 15, 300, 250, "Genero")
            Else
                CrearGraficas("A2", "B3", objGenero, 150, 15, 300, 250, "Genero")
            End If
        Else
            CrearGraficas("A2", "B3", objGenero, 150, 15, 300, 250, "Genero")
        End If
        CantidadFilasCero = 0

        Dim objEdad As Worksheet = objLibroExcel.Worksheets(2)
        With objEdad
            .Name = ("Edad")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(2).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objEdad.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(2).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(2).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(2).Rows.Count - 1
            If DsInformeSalud.Tables(2).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(2).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B6", objEdad, 150, 15, 350, 300, "Rango de Edad")
            Else
                CrearGraficas("A2", "B6", objEdad, 150, 15, 350, 300, "Rango de Edad")
            End If
        Else
            CrearGraficas("A2", "B6", objEdad, 150, 15, 350, 300, "Rango de Edad")
        End If

        CantidadFilasCero = 0
        Dim objEstadoCivil As Worksheet = objLibroExcel.Worksheets(3)
        With objEstadoCivil
            .Name = ("Estado Civil")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(3).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(3).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(3).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(3).Rows.Count - 1
            If DsInformeSalud.Tables(3).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(3).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B6", objEstadoCivil, 150, 15, 350, 300, "Estado Civil")
            Else
                CrearGraficas("A2", "B6", objEstadoCivil, 150, 15, 350, 300, "Estado Civil")
            End If
        Else
            CrearGraficas("A2", "B6", objEstadoCivil, 150, 15, 350, 300, "Estado Civil")
        End If

        CantidadFilasCero = 0
        Dim objNivelEducativo As Worksheet = objLibroExcel.Worksheets(4)
        With objNivelEducativo
            .Name = ("Nivel Educativo")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(4).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(4).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(4).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(4).Rows.Count - 1
            If DsInformeSalud.Tables(4).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(4).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B10", objNivelEducativo, 200, 15, 350, 300, "Nivel Educativo")
            Else
                CrearGraficas("A2", "B10", objNivelEducativo, 200, 15, 350, 300, "Nivel Educativo")
            End If
        Else
            CrearGraficas("A2", "B10", objNivelEducativo, 200, 15, 350, 300, "Nivel Educativo")
        End If

        CantidadFilasCero = 0
        Dim objRiesgo As Worksheet = objLibroExcel.Worksheets(5)
        With objRiesgo
            .Name = ("Riesgo")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(5).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(5).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(5).Columns
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

        CrearGraficasBarra("A2", "B9", objRiesgo, 170, 15, 350, 300, "Clasificación del Riesgo")

        CantidadFilasCero = 0
        Dim objTipoCargo As Worksheet = objLibroExcel.Worksheets(6)
        With objTipoCargo
            .Name = ("Tipo de Cargo")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(6).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(6).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(6).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(6).Rows.Count - 1
            If DsInformeSalud.Tables(6).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(6).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B4", objTipoCargo, 170, 15, 350, 300, "Tipo de Cargo")
            Else
                CrearGraficas("A2", "B4", objTipoCargo, 170, 15, 350, 300, "Tipo de Cargo")
            End If
        Else
            CrearGraficas("A2", "B4", objTipoCargo, 170, 15, 350, 300, "Tipo de Cargo")
        End If

        CantidadFilasCero = 0
        Dim objTabaco As Worksheet = objLibroExcel.Worksheets(7)
        With objTabaco
            .Name = ("Tabaco")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(7).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(7).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(7).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(7).Rows.Count - 1
            If DsInformeSalud.Tables(7).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(7).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B4", objTabaco, 170, 15, 350, 300, "Consumo de Tabaco")
            Else
                CrearGraficas("A2", "B4", objTabaco, 170, 15, 350, 300, "Consumo de Tabaco")
            End If
        Else
            CrearGraficas("A2", "B4", objTabaco, 170, 15, 350, 300, "Consumo de Tabaco")
        End If

        CantidadFilasCero = 0
        Dim objLicor As Worksheet = objLibroExcel.Worksheets(8)
        With objLicor
            .Name = ("Licor")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(8).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(8).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(8).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(8).Rows.Count - 1
            If DsInformeSalud.Tables(8).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(8).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B3", objLicor, 200, 15, 350, 300, "Consumo de Alcohol")
            Else
                CrearGraficas("A2", "B3", objLicor, 200, 15, 350, 300, "Consumo de Alcohol")
            End If
        Else
            CrearGraficas("A2", "B3", objLicor, 200, 15, 350, 300, "Consumo de Alcohol")
        End If

        CantidadFilasCero = 0
        Dim objPsicotropicos As Worksheet = objLibroExcel.Worksheets(9)
        With objPsicotropicos
            .Name = ("Psicotrópicos")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(9).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(9).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(9).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(9).Rows.Count - 1
            If DsInformeSalud.Tables(9).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(9).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B3", objPsicotropicos, 250, 15, 350, 300, "Consumo de Psicotrópicos")
            Else
                CrearGraficas("A2", "B3", objPsicotropicos, 250, 15, 350, 300, "Consumo de Psicotrópicos")
            End If
        Else
            CrearGraficas("A2", "B3", objPsicotropicos, 250, 15, 350, 300, "Consumo de Psicotrópicos")
        End If

        CantidadFilasCero = 0
        Dim objDeportes As Worksheet = objLibroExcel.Worksheets(10)
        With objDeportes
            .Name = ("Deportes")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(10).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(10).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(10).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(10).Rows.Count - 1
            If DsInformeSalud.Tables(10).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(10).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B3", objDeportes, 250, 15, 350, 300, "Actividad Deportiva")
            Else
                CrearGraficas("A2", "B3", objDeportes, 250, 15, 350, 300, "Actividad Deportiva")
            End If
        Else
            CrearGraficas("A2", "B3", objDeportes, 250, 15, 350, 300, "Actividad Deportiva")
        End If

        CantidadFilasCero = 0
        Dim objMoto As Worksheet = objLibroExcel.Worksheets(11)
        With objMoto
            .Name = ("Moto")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(11).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(11).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(11).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(11).Rows.Count - 1
            If DsInformeSalud.Tables(11).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(11).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B3", objMoto, 200, 15, 350, 300, "Uso de Moto")
            Else
                CrearGraficas("A2", "B3", objMoto, 200, 15, 350, 300, "Uso de Moto")
            End If
        Else
            CrearGraficas("A2", "B3", objMoto, 200, 15, 350, 300, "Uso de Moto")
        End If

        CantidadFilasCero = 0
        Dim objIMC As Worksheet = objLibroExcel.Worksheets(12)
        With objIMC
            .Name = ("IMC")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(12).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(12).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(12).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(12).Rows.Count - 1
            If DsInformeSalud.Tables(12).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(12).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B7", objIMC, 200, 15, 350, 300, "Indice de Masa Corporal")
            Else
                CrearGraficas("A2", "B7", objIMC, 200, 15, 350, 300, "Indice de Masa Corporal")
            End If
        Else
            CrearGraficas("A2", "B7", objIMC, 200, 15, 350, 300, "Indice de Masa Corporal")
        End If

        CantidadFilasCero = 0
        Dim objATEL As Worksheet = objLibroExcel.Worksheets(13)
        With objATEL
            .Name = ("ATEL")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(13).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(13).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(13).Columns
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


        CrearGraficasBarra("A2", "B3", objATEL, 200, 15, 350, 300, "ATEL")
        CantidadFilasCero = 0
        Dim objInmunizacion As Worksheet = objLibroExcel.Worksheets(14)
        With objInmunizacion
            .Name = ("Inmunización")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(14).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(14).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(14).Columns
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

        CrearGraficasBarra("A2", "B4", objInmunizacion, 200, 15, 350, 300, "Inmunización")

        CantidadFilasCero = 0
        Dim objPersonalSano As Worksheet = objLibroExcel.Worksheets(15)
        With objPersonalSano
            .Name = ("Personal Sano")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(15).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(15).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(15).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(15).Rows.Count - 1
            If DsInformeSalud.Tables(9).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(15).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CrearGraficasBarra("A2", "B3", objPersonalSano, 150, 15, 350, 300, "Diagnósticos")
            Else
                CrearGraficas("A2", "B3", objPersonalSano, 150, 15, 350, 300, "Diagnósticos")
            End If
        Else
            CrearGraficas("A2", "B3", objPersonalSano, 150, 15, 350, 300, "Diagnósticos")
        End If

        CantidadFilasCero = 0
        Dim objPatologias As Worksheet = objLibroExcel.Worksheets(16)
        With objPatologias
            .Name = ("Patologías")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In DsInformeSalud.Tables(16).Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, objGenero.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In DsInformeSalud.Tables(16).Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In DsInformeSalud.Tables(16).Columns
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

        For i As Integer = 0 To DsInformeSalud.Tables(16).Rows.Count - 1
            If DsInformeSalud.Tables(16).Rows(i).Item(1) = 0 Then
                GraficoBarras = True
                CantidadFilasCero += 1
            End If
        Next

        If GraficoBarras = True Then
            If DsInformeSalud.Tables(16).Rows.Count - CantidadFilasCero <= 1 Then
                GraficoBarras = False
                CantidadFilasCero = 0
                CrearGraficasBarra("A2", "B8", objPatologias, 250, 15, 350, 300, "Patologías")
            Else
                CrearGraficas("A2", "B8", objPatologias, 250, 15, 350, 300, "Patologías")
            End If
        Else
            CrearGraficas("A2", "B8", objPatologias, 250, 15, 350, 300, "Patologías")
        End If


        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = XlMousePointer.xlDefault
    End Sub

    Private Sub CrearGraficas(Rango1 As String, Rango2 As String, Hoja As Worksheet, Left As Integer, Top As Integer, Ancho As Integer, Alto As Integer, Titulo As String)
        Dim GraficaP As Chart
        Dim Grafica As ChartObject
        Dim Graficas As ChartObjects
        Dim RangoGrafica As Range
        Graficas = Hoja.ChartObjects
        Grafica = Graficas.Add(Left, Top, Ancho, Alto)
        GraficaP = Grafica.Chart
        RangoGrafica = Hoja.Range(Rango1, Rango2)
        GraficaP.SetSourceData(Source:=RangoGrafica)
        GraficaP.ChartType = XlChartType.xlPie
        GraficaP.HasTitle = True
        GraficaP.ChartTitle.Text = Titulo
        'GraficaP.ApplyDataLabels(XlDataLabelsType.xlDataLabelsShowPercent)
        GraficaP.ApplyDataLabels(XlDataLabelsType.xlDataLabelsShowLabelAndPercent)
    End Sub

    Private Sub CrearGraficasBarra(Rango1 As String, Rango2 As String, Hoja As Worksheet, Left As Integer, Top As Integer, Ancho As Integer, Alto As Integer, Titulo As String)
        Dim GraficaP As Chart
        Dim Grafica As ChartObject
        Dim Graficas As ChartObjects
        Dim RangoGrafica As Range
        Graficas = Hoja.ChartObjects
        Grafica = Graficas.Add(Left, Top, Ancho, Alto)
        GraficaP = Grafica.Chart
        RangoGrafica = Hoja.Range(Rango1, Rango2)
        GraficaP.SetSourceData(Source:=RangoGrafica, PlotBy:=XlAxisGroup.xlPrimary)
        GraficaP.HasTitle = True
        GraficaP.ChartTitle.Text = Titulo
        GraficaP.HasAxis(XlAxisType.xlCategory) = False
    End Sub

    Private Sub SubirPdf_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfEM.ItemClick
        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaReportes.CurrentCell.RowIndex
            Dim PuedeSubir = False
            Dim Id As String = ""
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Subido As Boolean = False
            Dim TipoDocumento As Integer = Nothing
            If FuncionesBase.FuncionesBase.ConsultarPermiso(1026) Then
                PuedeSubir = True
            End If
            If tablacargada <> Tablas.EXAMENESMEDICOS Then
                MsgBox("No esta cargada la tabla de Exámenes Médicos", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If Me.DGV_ListaReportes.Item("Concepto", Me.DGV_ListaReportes.CurrentCell.RowIndex).Value.ToString <> "S" Then
                MsgBox("El exámen médico no cuenta con un concepto asociado para subir archivo.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            Id = Me.DGV_ListaReportes.Item("Id", Index_Registro_Actual).Value.ToString
            NombreDocumento = "EM_" + Id
            AñoDocumento = Convert.ToDateTime(Me.DGV_ListaReportes.Item("Fecha del examen", Index_Registro_Actual).Value).Year.ToString
            SubidoNube = Me.DGV_ListaReportes.Item("UBICADOSERVIDORARCHIVO", Index_Registro_Actual).Value.ToString
            TipoDocumento = 13
            If SubidoNube = "N" Or SubidoNube = "" Then
                Subido = GoogleDrive.SubirArchivo(TipoDocumento, Id, NombreDocumento, AñoDocumento, False)
            Else
                Subido = GoogleDrive.SubirArchivo(TipoDocumento, Id, NombreDocumento, AñoDocumento, True)
            End If

            If Subido = True Then
                CargarTablaxDefectoExamenes()
            End If
        End If
    End Sub

    Private Sub VerPdf_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerPdfEM.ItemClick

        If Me.DGV_ListaReportes.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaReportes.CurrentCell.RowIndex
            Dim PuedeVer As Boolean = False
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Descargar As String = "ArchivosPDF"
            Dim CarpetaDrive As String = ""
            If tablacargada <> Tablas.EXAMENESMEDICOS Then
                MsgBox("No esta cargada la tabla de Exámenes Médicos", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If FuncionesBase.FuncionesBase.ConsultarPermiso(1027) Then
                PuedeVer = True
            End If

            NombreDocumento = "EM_" + Me.DGV_ListaReportes.Item("Id", Index_Registro_Actual).Value.ToString
            AñoDocumento = Convert.ToDateTime(Me.DGV_ListaReportes.Item("Fecha del examen", Index_Registro_Actual).Value).Year.ToString
            CarpetaDrive = "ExámenesMédicos"
            SubidoNube = Me.DGV_ListaReportes.Item("UBICADOSERVIDORARCHIVO", Index_Registro_Actual).Value.ToString

            If SubidoNube = "S" Then
                GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
            End If

        End If
    End Sub
    
    Private Sub Nbi_ImprimirHC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirHC.ItemClick
        If tablacargada = Tablas.EXAMENESMEDICOS Then
            Dim ImprimirExamen As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarExamen.Tag) = True Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(1028) Then
                    ImprimirExamen = True
                Else
                    ImprimirExamen = False
                End If
            End If
            ImprimirExamen = True
            If ImprimirExamen Then
                IMPRIMIR(3)
            Else
                MsgBox("No cuenta con los permisos para imprimir el examen")
            End If

        Else
            MsgBox("No está cargada la tabla de Exámenes Médicos")
        End If
    End Sub

    Private Sub Nbi_BuscarEnfermedades_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarEnfermedades.ItemClick
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEnfermedades.Tag) = True Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT IDENFERMEDAD, CODIGOENFERMEDAD,NOMBREENFERMEDAD, dbo.ObtenerNombreMaestraHSE(GRUPOENFERMEDAD) as GRUPOENFERMEDAD,USADO FROM HSE_HC_MA_ENFERMEDADES ORDER BY IDENFERMEDAD, USADO  SELECT ID, NOMBRE FROM HSE_MA_TABLAS WHERE IDTIPO = 22", conexion)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsEnfermedades = New System.Data.DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsEnfermedades)
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim fr_Enfermedades As FormulariosClasesBase.Fr_BuscarEnfermedades = New FormulariosClasesBase.Fr_BuscarEnfermedades
            fr_Enfermedades.dtEnfermedades = dsEnfermedades.Tables(0)
            fr_Enfermedades.dtGrupos = dsEnfermedades.Tables(1)
            fr_Enfermedades.CargarEnfermedades()
            fr_Enfermedades.ComportamientoPredeterminado()
            fr_Enfermedades.ShowDialog()
        Else
            MsgBox("No cuenta con los permisos para buscar")
        End If
    End Sub
End Class


Public Class Cl_Formato24H
    Private _Id As Integer
    Private _NumReporte24H As String = ""
    Private _TipoReporte24H As String = ""
    Private _Consecuencia As String = ""
    Private _Proyecto As String = ""
    Private _FechaAccidente As DateTime
    Private _Actividad As String = ""
    Private _PersonaReporto As String = ""
    Private _Zona As String = ""
    Private _Impreso As String = ""
    Private _UsuarioRegistro As String = ""
    Private _FechaRegistro As DateTime
    Private _UsuarioModifico As String = ""
    Private _FechaModifico As DateTime
    Private _Investigacion As String = ""

    <Description("Identificación del Reporte 24 Horas"),
    Category("Identificación"),
    DisplayNameAttribute("Reporte No.")>
    Public ReadOnly Property NumReporte24H() As String
        Get
            Return _NumReporte24H
        End Get
    End Property

    <Description("Tipo de incidente"),
    Category("Identificación"),
    DisplayNameAttribute("Tipo")>
    Public ReadOnly Property TipoReporte24H() As String
        Get
            Return _TipoReporte24H
        End Get
    End Property

    <Description("Consecuencia del incidente"),
    Category("Identificación"),
    DisplayNameAttribute("Consecuencia")>
    Public ReadOnly Property Consecuencia() As String
        Get
            Return _Consecuencia
        End Get
    End Property
    <Description("Proyecto"),
    Category("Proyecto"),
    DisplayNameAttribute("Proyecto")>
    Public ReadOnly Property Proyecto() As String
        Get
            Return _Proyecto
        End Get
    End Property
    <Description("Fecha del Incidente"),
    Category("Identificación"),
    DisplayNameAttribute("Fecha Incidente")>
    Public ReadOnly Property FechaAccidente() As String
        Get
            Return _FechaAccidente
        End Get
    End Property
    <Description("Actividad principal"),
    Category("Identificación"),
    DisplayNameAttribute("Actividad Principal")>
    Public ReadOnly Property Actividad() As String
        Get
            Return _Actividad
        End Get
    End Property

    <Description("Persona que reporto el incidente"),
    Category("Usuarios"),
    DisplayNameAttribute("Persona reporta")>
    Public ReadOnly Property PersonaReporto() As String
        Get
            Return _PersonaReporto
        End Get
    End Property
    <Description("Zona donde ocurrio el incidente"),
    Category("Proyecto"),
    DisplayNameAttribute("Zona")>
    Public ReadOnly Property Zona() As String
        Get
            Return _Zona
        End Get
    End Property
    <Description("Indica si el documento fue impreso"),
    Category("Documento"),
    DisplayNameAttribute("Impreso")>
    Public ReadOnly Property Impreso() As String
        Get
            Return _Impreso
        End Get
    End Property
    <Description("Usuario que registro"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Registra")>
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property
    <Description("Fecha en que se registro"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property
    <Description("Usuario que modifico"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Modifica")>
    Public ReadOnly Property UsuarioModifico() As String
        Get
            Return _UsuarioModifico
        End Get
    End Property
    <Description("Fecha en que se modificó"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Modificación")>
    Public ReadOnly Property FechaModifico() As String
        Get
            Return _FechaModifico
        End Get
    End Property

    <Description("Indica si tiene o no una investigación asociada"),
    Category("Investigacion"),
    DisplayNameAttribute("Investigación asociada")>
    Public ReadOnly Property Investigacion() As String
        Get
            Return _Investigacion
        End Get
    End Property
    Public Sub New(ByVal FilaR24 As DataRow)
        _Id = FilaR24("Id")
        _NumReporte24H = FilaR24("NumReporte24H")
        _TipoReporte24H = FilaR24("Tipo de Incidente")
        _Consecuencia = FilaR24("Consecuencia")
        _Proyecto = FilaR24("Proyecto")
        _FechaAccidente = FilaR24("Fecha Accidente")
        _Actividad = FilaR24("Actividad")
        _PersonaReporto = FilaR24("PersonaReporto")
        _Zona = IIf(FilaR24("Zona") = "U", "Urbana", "Rural")
        _Impreso = IIf(FilaR24("Impreso") = "S", "Si", "No")
        _UsuarioRegistro = FilaR24("Usuario Registra")
        _FechaRegistro = FilaR24("Fecha Registro")
        _UsuarioModifico = FilaR24("Usuario Modifica")
        _FechaModifico = FilaR24("Fecha Modifico")
        _Investigacion = FilaR24("Investigacion")
    End Sub
End Class

Public Class Cl_FormatoInvestigacion
    Private _Id As Integer
    Private _NumInvestigacion As String = ""
    Private _TipoInvestigacion As String = ""
    Private _Consecuencia As String = ""
    Private _Reporte24H As String = ""
    Private _Proyecto As String = ""
    Private _FechaAccidente As DateTime
    Private _Actividad As String = ""
    Private _PersonaReporto As String = ""
    Private _Zona As String = ""
    Private _Impreso As String = ""
    Private _UsuarioRegistro As String = ""
    Private _FechaRegistro As DateTime
    Private _UsuarioModifico As String = ""
    Private _FechaModifico As DateTime

    <Description("Identificación de la Investigacion"),
    Category("Identificación"),
    DisplayNameAttribute("Reporte No.")>
    Public ReadOnly Property NumInvestigacion() As String
        Get
            Return _NumInvestigacion
        End Get
    End Property

    <Description("Tipo de incidente"),
    Category("Identificación"),
    DisplayNameAttribute("Tipo")>
    Public ReadOnly Property TipoInvestigacion() As String
        Get
            Return _TipoInvestigacion
        End Get
    End Property

    <Description("Consecuencia del incidente"),
    Category("Identificación"),
    DisplayNameAttribute("Consecuencia")>
    Public ReadOnly Property Consecuencia() As String
        Get
            Return _Consecuencia
        End Get
    End Property
    <Description("Reporte 24 horas asociada a la investigacion"),
    Category("Identificación"),
    DisplayNameAttribute("Reporte 24 Horas")>
    Public ReadOnly Property Reporte24H() As String
        Get
            Return _Reporte24H
        End Get
    End Property
    <Description("Proyecto"),
    Category("Proyecto"),
    DisplayNameAttribute("Proyecto")>
    Public ReadOnly Property Proyecto() As String
        Get
            Return _Proyecto
        End Get
    End Property
    <Description("Fecha del Incidente"),
    Category("Identificación"),
    DisplayNameAttribute("Fecha Incidente")>
    Public ReadOnly Property FechaAccidente() As String
        Get
            Return _FechaAccidente
        End Get
    End Property
    <Description("Actividad principal"),
    Category("Identificación"),
    DisplayNameAttribute("Actividad Principal")>
    Public ReadOnly Property Actividad() As String
        Get
            Return _Actividad
        End Get
    End Property

    <Description("Persona que reporto el incidente"),
    Category("Usuarios"),
    DisplayNameAttribute("Persona reporta")>
    Public ReadOnly Property PersonaReporto() As String
        Get
            Return _PersonaReporto
        End Get
    End Property
    <Description("Zona donde ocurrio el incidente"),
    Category("Proyecto"),
    DisplayNameAttribute("Zona")>
    Public ReadOnly Property Zona() As String
        Get
            Return _Zona
        End Get
    End Property
    <Description("Indica si el documento fue impreso"),
    Category("Documento"),
    DisplayNameAttribute("Impreso")>
    Public ReadOnly Property Impreso() As String
        Get
            Return _Impreso
        End Get
    End Property
    <Description("Usuario que registro"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Registra")>
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property
    <Description("Fecha en que se registro"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property
    <Description("Usuario que modifico"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Modifica")>
    Public ReadOnly Property UsuarioModifico() As String
        Get
            Return _UsuarioModifico
        End Get
    End Property
    <Description("Fecha en que se modificó"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Modificación")>
    Public ReadOnly Property FechaModifico() As String
        Get
            Return _FechaModifico
        End Get
    End Property

    Public Sub New(ByVal FilaInv As DataRow)
        _Id = FilaInv("Id")
        _NumInvestigacion = FilaInv("NumInvestigacion")
        _TipoInvestigacion = FilaInv("Tipo de Incidente")
        _Consecuencia = FilaInv("Consecuencia")
        _Reporte24H = FilaInv("Reporte24H")
        _Proyecto = FilaInv("Proyecto")
        _FechaAccidente = FilaInv("Fecha Accidente")
        _Actividad = FilaInv("Actividad")
        _PersonaReporto = FilaInv("PersonaReporto")
        _Zona = IIf(FilaInv("Zona") = "U", "Urbana", "Rural")
        _Impreso = IIf(FilaInv("Impreso") = "S", "Si", "No")
        _UsuarioRegistro = FilaInv("Usuario Registra")
        _FechaRegistro = FilaInv("Fecha Registro")
        _UsuarioModifico = FilaInv("Usuario Modifica")
        _FechaModifico = FilaInv("Fecha Modifico")
    End Sub
End Class

Public Class Cl_ResumenEstadistico
    Private _Id As Integer
    Private _Año As String = ""
    Private _Mes As String = ""
    Private _Base As String = ""
    Private _Editable As String = ""
    Private _UsuarioRegistro As String = ""
    Private _FechaRegistro As DateTime
    Private _UsuarioModifico As String = ""
    Private _FechaModifico As DateTime

    <Description("Identificación de los datos del resumen estadístico"),
    Category("Identificación"),
    DisplayNameAttribute("Id")>
    Public ReadOnly Property Id() As String
        Get
            Return _Id
        End Get
    End Property


    <Description("Año del resumen estadístico"),
    Category("Identificación"),
    DisplayNameAttribute("Año")>
    Public ReadOnly Property Año() As String
        Get
            Return _Año
        End Get
    End Property


    <Description("Mes del resumen estadístico"),
    Category("Identificación"),
    DisplayNameAttribute("Mes")>
    Public ReadOnly Property Mes() As String
        Get
            Return _Mes
        End Get
    End Property


    <Description("Base del resumen estadístico"),
    Category("Identificación"),
    DisplayNameAttribute("Base")>
    Public ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property

    <Description("Indica si el documento se puede editar"),
    Category("Documento"),
    DisplayNameAttribute("Bloqueado para Edición")>
    Public ReadOnly Property Editable() As String
        Get
            Return _Editable
        End Get
    End Property
    <Description("Usuario que registro"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Registra")>
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property
    <Description("Fecha en que se registro"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property
    <Description("Usuario que modifico"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Modifica")>
    Public ReadOnly Property UsuarioModifico() As String
        Get
            Return _UsuarioModifico
        End Get
    End Property
    <Description("Fecha en que se modificó"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Modificación")>
    Public ReadOnly Property FechaModifico() As String
        Get
            Return _FechaModifico
        End Get
    End Property

    Public Sub New(ByVal FilaResumen As DataRow)
        _Id = FilaResumen("Id")
        _Año = FilaResumen("año")
        _Mes = FilaResumen("mes")
        _Base = FilaResumen("base")
        _Editable = IIf(FilaResumen("editable") = "S", "Si", "No")
        _UsuarioRegistro = FilaResumen("Usuario Registra")
        _FechaRegistro = FilaResumen("Fecha Registro")
        _UsuarioModifico = FilaResumen("Usuario Modifica")
        _FechaModifico = FilaResumen("Fecha Modifico")
    End Sub
End Class

Public Class Cl_ExamenMedico
    Private _IdExamen As Integer
    Private _FechaExamen As String = ""
    Private _PersonaExaminada As String = ""
    Private _Base As String = ""
    Private _Concepto As String = ""
    Private _Impreso As String = ""
    Private _TipoExamen As String = ""
    Private _UsuarioRegistro As String = ""
    Private _FechaRegistro As DateTime
    Private _UsuarioModifico As String = ""
    Private _FechaModifico As DateTime

    <Description("Identificación del Examen Médico"),
    Category("Identificación"),
    DisplayNameAttribute("Id")>
    Public ReadOnly Property IdExamen() As String
        Get
            Return _IdExamen
        End Get
    End Property

    <Description("Fecha del examen médico"),
    Category("Identificación"),
    DisplayNameAttribute("Fecha examen")>
    Public ReadOnly Property FechaExamen() As String
        Get
            Return _FechaExamen
        End Get
    End Property

    <Description("Persona Examinada"),
    Category("Identificación"),
    DisplayNameAttribute("Persona Examinada")>
    Public ReadOnly Property PersonaExaminada() As String
        Get
            Return _PersonaExaminada
        End Get
    End Property
    <Description("Base"),
    Category("Identificación"),
    DisplayNameAttribute("Base")>
    Public ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property
    <Description("Concepto Asociado"),
    Category("Documento"),
    DisplayNameAttribute("Concepto Asociado")>
    Public ReadOnly Property Concepto() As String
        Get
            Return _Concepto
        End Get
    End Property
    <Description("Impreso"),
    Category("Documento"),
    DisplayNameAttribute("Impreso")>
    Public ReadOnly Property Impreso() As String
        Get
            Return _Impreso
        End Get
    End Property

    <Description("Tipo del examen"),
    Category("Documento"),
    DisplayNameAttribute("Tipo del examen")>
    Public ReadOnly Property TipoExamen() As String
        Get
            Return _TipoExamen
        End Get
    End Property

    <Description("Usuario que registro"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Registra")>
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property
    <Description("Fecha en que se registro"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property
    <Description("Usuario que modifico"),
    Category("Usuarios"),
    DisplayNameAttribute("Usuario Modifica")>
    Public ReadOnly Property UsuarioModifico() As String
        Get
            Return _UsuarioModifico
        End Get
    End Property
    <Description("Fecha en que se modificó"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha Modificación")>
    Public ReadOnly Property FechaModifico() As String
        Get
            Return _FechaModifico
        End Get
    End Property

    Public Sub New(ByVal FilaExamen As DataRow)
        _IdExamen = FilaExamen("Id")
        _FechaExamen = FilaExamen("Fecha examen")
        _PersonaExaminada = FilaExamen("Persona examinada")
        _Base = FilaExamen("Base")
        _Concepto = IIf(FilaExamen("Concepto") = "S", "Si", "No")
        _Impreso = IIf(FilaExamen("Impreso") = "S", "Si", "No")
        Dim TipoExamen As String = ""
        If FilaExamen("Tipo Examen") = "I" Then
            TipoExamen = "Ingreso"
        Else
            If FilaExamen("Tipo Examen") = "P" Then
                TipoExamen = "Periódico"
            Else
                TipoExamen = "Egreso"
            End If
        End If
        _TipoExamen = TipoExamen
        _UsuarioRegistro = FilaExamen("Usuario Registra")
        _FechaRegistro = FilaExamen("Fecha Registro")
        _UsuarioModifico = FilaExamen("Usuario Modifica")
        _FechaModifico = FilaExamen("Fecha Modifico")
    End Sub
End Class

