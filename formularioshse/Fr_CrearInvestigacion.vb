Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_CrearInvestigacion
    Public TIPO As Integer
    Public EDITANDO As Boolean
    Public IDREPORTE As Integer
    Public IDREPORTE24H As Integer
    Public IDREPORTEMODIFICANDO As Integer = -1
    Public TIPOINCIDENTE As Integer
    Public guardado As Boolean

    Private dtReporte As DataTable
    Private dtReportePersona As DataTable
    Private dtTestigos As DataTable
    Private dtReporteInv As DataTable
    Private filareporte As DataRow
    Private filareportepersona As DataRow
    Private filatestigos As DataRow
    Private filareporteinv As DataRow

    Private dtAccionesATomar As DataTable
    Private dtLineaTiempo As DataTable
    Private dtInvestigadores As DataTable
    Private dtCausasInmediatasActos As DataTable
    Private dtCausasInmediatasCondiciones As DataTable
    Private dtCausasBasicasPersonales As DataTable
    Private dtCausasBasicasTrabajo As DataTable
    Private dtEvidencias As DataTable

    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Sub Fr_CrearInvestigacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim identificador As Long
        Dim tipo As Integer
        Dim subtipo As Integer

        If IDREPORTEMODIFICANDO < 0 Then
            identificador = -1
            tipo = 1 'Crear
        Else
            identificador = IDREPORTEMODIFICANDO
            tipo = 2 'Editar
            subtipo = TIPOINCIDENTE
        End If
        dsCargar = bddatos.CargarMaestrasHSE(1, IDREPORTE24H, tipo, TIPOINCIDENTE)
        If TIPOINCIDENTE = 1 Then
            Me.TabControl1.Controls.Remove(Me.Tp_InformacionAfectado)
            Me.TabControl1.Controls.Remove(Me.Tp_AfectacionAmbDaños)
            Me.Cb_TipoIncidente.SelectedValue = TIPOINCIDENTE
            Me.TabControl1.TabPages.Insert(1, Me.Tp_InformacionAfectado)
        Else
            'Tipo Seguridad
            If TIPOINCIDENTE = 2 Then
                Me.Cb_TipoIncidente.SelectedValue = TIPOINCIDENTE
                Me.TabControl1.Controls.Remove(Me.Tp_InformacionAfectado)
                Me.TabControl1.Controls.Remove(Me.Tp_AfectacionAmbDaños)
                Me.TabControl1.TabPages.Insert(1, Me.Tp_AfectacionAmbDaños)
                Me.Lb_UnidadSustancia.Hide()
                Me.Cb_UnidadSustancia.Hide()
                Me.Lb_CantidadSustancia.Hide()
                Me.Tb_CantidadSustancia.Hide()
                Me.Tp_AfectacionAmbDaños.Text = "Información de Pérdidas o Daños"
                Me.Lb_SustanciaProceso.Location = New Drawing.Point(90, 18)
                Me.Lb_SustanciaProceso.Text = "Proceso Afectado:"
                Me.Lb_AfectacionDaño.Location = New Drawing.Point(100, 49)
                Me.Lb_AfectacionDaño.Text = "Daño Generado:"
            Else
                'Tipo Ambiental
                If TIPOINCIDENTE = 3 Then
                    Me.Cb_TipoIncidente.SelectedValue = TIPOINCIDENTE
                    Me.TabControl1.Controls.Remove(Me.Tp_InformacionAfectado)
                    Me.TabControl1.Controls.Remove(Me.Tp_AfectacionAmbDaños)
                    Me.TabControl1.TabPages.Insert(1, Me.Tp_AfectacionAmbDaños)
                    Me.Lb_UnidadSustancia.Show()
                    Me.Cb_UnidadSustancia.Text = ""
                    Me.Cb_UnidadSustancia.Show()
                    Me.Tp_AfectacionAmbDaños.Text = "Información de la Afectación"
                    Me.Lb_SustanciaProceso.Text = "Sustancia o Elemento Involucrado:"
                    Me.Lb_AfectacionDaño.Location = New Drawing.Point(124, 49)
                    Me.Lb_AfectacionDaño.Text = "Afectación:"
                Else
                    'Tipo Casi-Accidente
                    If TIPOINCIDENTE = 4 Then
                        Me.Cb_TipoIncidente.SelectedValue = TIPOINCIDENTE
                        Me.TabControl1.Controls.Remove(Me.Tp_InformacionAfectado)
                        Me.TabControl1.Controls.Remove(Me.Tp_AfectacionAmbDaños)
                        Me.TabControl1.Controls.Remove(Me.Tp_InformacionAfectado)
                    End If
                End If
            End If
        End If
        'If dtTestigos IsNot Nothing Then
        '    If dtTestigos.Rows.Count > 0 Then
        '        Me.Dgv_Testigos.Columns("DGVCB_CargoTestigo").ReadOnly = False
        '        Me.Dgv_Testigos.Columns("DGVTB_DescripcionTestigo").ReadOnly = False
        '    End If
        'End If

        Dim empleador As String = dtReporte.Rows(0).Item("EMPLEADOR").ToString
        If empleador <> "ISMOCOL" Then
            Me.Ck_Empleador.Checked = False
            Me.Tb_Empleador.Text = empleador
        Else
            Me.Ck_Empleador.Checked = True
            Me.Tb_Empleador.Text = empleador
        End If
    End Sub

    Public Sub ComportamientoPredeterminado()

Me.Dgv_Evidencias.AllowUserToAddRows = False
        Me.Dgv_CausasInmediatasActos.AllowUserToAddRows = False
        Me.Dgv_CausasInmediatasCondiciones.AllowUserToAddRows = False
        Me.Dgv_CausasBasicasPersonales.AllowUserToAddRows = False
        Me.Dgv_CausasBasicasTrabajo.AllowUserToAddRows = False
        Me.Dgv_AccionesATomar.AllowUserToAddRows = False
        Me.Dgv_Investigadores.AllowUserToAddRows = False
        Me.Dgv_LineaTiempo.AllowUserToAddRows = False
        Me.Dgv_Testigos.AllowUserToAddRows = False

        'Bloquear campos que no cambian
        Me.Cb_Contrato.Enabled = False
        Me.Cb_Proyecto.Enabled = False
        Me.Cb_TipoIncidente.Enabled = False
        Me.Cb_Area.Enabled = False
        Me.Ck_Empleador.Enabled = False
        Me.Tb_Empleador.Enabled = False
        Me.Cb_ActividadPrincipal.Enabled = False
        Me.Cu_BuscarPersonaReporta.Enabled = False
        Me.Cb_CargoReporta.Enabled = False
        Me.Rb_ZonaRural.Enabled = False
        Me.Rb_ZonaUrbana.Enabled = False
        Me.Cu_CiudadIncidente.Enabled = False
        Me.Tb_CargoActual.Enabled = False
        Me.Tb_CategoriaResultante.Enabled = False
        Me.Tb_CategoriaResultanteReal.Enabled = False
        Me.Tb_ExperienciaOcupacional.Enabled = False
        If TIPO = 1 Or TIPO = 2 Then
            Me.Cu_BuscarPersonaAfectada.Enabled = False
            Me.DTP_FechaNacimiento.Enabled = False
            Me.Rb_Masculino.Enabled = False
            Me.Rb_Femenino.Enabled = False
            Me.DTP_InicioContrato.Enabled = False
            Me.Cb_CargoPersonaAccidente.Enabled = False
            Me.Cb_AtencionInmediata.Enabled = False
            Me.Tb_Traslado.Enabled = False
            Me.Cb_TipoVinculacion.Enabled = False
        End If

        'Esconder Campos al cargar
        Lb_OtrosAnexos.Hide()
        Tb_OtrosAnexos.Hide()
        Lb_Trasladado.Hide()
        Tb_Traslado.Hide()
        Lb_OtraEntidad.Hide()
        Tb_OtraEntidad.Hide()
        'Lb_Pregunta1.Hide()
        'Tb_Pregunta1.Hide()
        Lb_Pregunta2.Hide()
        Tb_Pregunta2.Hide()

        'Poner los Combobox en selectedindex -1
        Me.Cb_Proyecto.SelectedIndex = -1
        Me.Cb_TipoIncidente.SelectedIndex = -1
        Me.Cb_TipoConsecuencia.SelectedIndex = -1
        Me.Cb_Area.SelectedIndex = -1
        Me.Cb_ActividadPrincipal.SelectedIndex = -1
        Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedIndex = -1
        Me.Cb_CargoReporta.SelectedIndex = -1
        Me.Cb_JornadaHabitual.SelectedIndex = -1
        Me.Cb_JornadaIncidente.SelectedIndex = -1
        Me.Cu_CiudadIncidente.Cb_Ciudad.SelectedIndex = -1
        Me.Cb_CondicionClima.SelectedIndex = -1

        Me.Cb_TipoVinculacion.SelectedIndex = -1
        Me.Cb_TipoLesion.SelectedIndex = -1
        Me.Cb_ParteAfectada.SelectedIndex = -1
        Me.Cb_AgenteAccidente.SelectedIndex = -1
        Me.Cb_MecanismoAccidente.SelectedIndex = -1
        Me.Cb_AtencionInmediata.SelectedIndex = -1
        Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedIndex = -1
        Me.Cb_CargoMedico.SelectedIndex = -1

        Me.Cb_UnidadSustancia.SelectedIndex = -1
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedIndex = -1
        Me.Cb_CargoAfectacionDaños.SelectedIndex = -1

        Me.Cb_Severidad.SelectedIndex = -1
        Me.Cb_Recurrencia.SelectedIndex = -1
        Me.Cb_SeveridadReal.SelectedIndex = -1
        Me.Cb_RecurrenciaReal.SelectedIndex = -1

        Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedIndex = -1
        Me.Cb_CargoAprobo.SelectedIndex = -1

        Me.Dgv_Testigos.Columns(1).ReadOnly = True

        DTP_HorasLaboradas.Value = Date.Today
        DTP_HoraIncidente.Value = Date.Now

        'Agregar DateTimePickers a los DGV
        Dim ColumnFechaLimite = New Cl_ColumnaFecha
        Dgv_AccionesATomar.Columns.Insert(3, ColumnFechaLimite)
        Dgv_AccionesATomar.Columns(3).HeaderText = "Fecha Limite"
        Dgv_AccionesATomar.Columns(3).Name = "DGVDTP_FechaLimite"
        Dgv_AccionesATomar.Columns(3).DataPropertyName = "Fecha Limite"

        Dim ColumnFechaTerminado = New Cl_ColumnaFecha
        Dgv_AccionesATomar.Columns.Insert(4, ColumnFechaTerminado)
        Dgv_AccionesATomar.Columns(4).HeaderText = "Fecha Terminado"
        Dgv_AccionesATomar.Columns(4).Name = "DGVDTP_FechaTerminado"
        Dgv_AccionesATomar.Columns(4).DataPropertyName = "Fecha Terminado"

        Dim ColumnFechaLineaTiempo = New Cl_ColumnaFecha
        Dgv_LineaTiempo.Columns.Insert(0, ColumnFechaLineaTiempo)
        Dgv_LineaTiempo.Columns(0).HeaderText = "Fecha"
        Dgv_LineaTiempo.Columns(0).Name = "DGVDTP_FechaLineaTiempo"
        Dgv_LineaTiempo.Columns(0).DataPropertyName = "FECHA"

        Dim ColumnHoraLineaTiempo = New Cl_ColumnaHora
        Dgv_LineaTiempo.Columns.Insert(1, ColumnHoraLineaTiempo)
        Dgv_LineaTiempo.Columns(1).HeaderText = "Hora"
        Dgv_LineaTiempo.Columns(1).Name = "DGVDTP_HoraLineaTiempo"
        Dgv_LineaTiempo.Columns(1).DataPropertyName = "HORA"

        Dim ColumnInvestigadores = New Cl_ColumnaFecha
        Dgv_Investigadores.Columns.Insert(3, ColumnInvestigadores)
        Dgv_Investigadores.Columns(3).HeaderText = "Fecha"
        Dgv_Investigadores.Columns(3).Name = "DGVDTP_FechaInvestigador"
        Dgv_Investigadores.Columns(3).DataPropertyName = "Fecha"

        Me.Dgv_Investigadores.Columns(1).ReadOnly = True

For i As Integer = 0 To Me.Dgv_Evidencias.ColumnCount - 1
            Me.Dgv_Evidencias.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_CausasInmediatasActos.ColumnCount - 1
            Me.Dgv_CausasInmediatasActos.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_CausasInmediatasCondiciones.ColumnCount - 1
            Me.Dgv_CausasInmediatasCondiciones.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_CausasBasicasPersonales.ColumnCount - 1
            Me.Dgv_CausasBasicasPersonales.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_CausasBasicasTrabajo.ColumnCount - 1
            Me.Dgv_CausasBasicasTrabajo.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_AccionesATomar.ColumnCount - 1
            Me.Dgv_AccionesATomar.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_Investigadores.ColumnCount - 1
            Me.Dgv_Investigadores.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_LineaTiempo.ColumnCount - 1
            Me.Dgv_LineaTiempo.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For i As Integer = 0 To Me.Dgv_Testigos.ColumnCount - 1
            Me.Dgv_Testigos.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        If TIPOINCIDENTE = 1 Then
            Gb_Preguntas.Text = "Identificación de Peligros"

            Lb_Costo1.Text = "Lesión $"
            Tb_Costo1.Location = New Drawing.Point(133, 21)

            Lb_Especificar1.Location = New Drawing.Point(327, 25)
            Tb_Especificar1.Location = New Drawing.Point(394, 21)

            Lb_Costo2.Hide()
            Tb_Costo2.Hide()

            Lb_Costo3.Hide()
            Tb_Costo3.Hide()

            Lb_Especificar2.Hide()
            Tb_Especificar2.Hide()

            Lb_Especificar3.Hide()
            Tb_Especificar3.Hide()

            Lb_Especificar4.Location = New Drawing.Point(327, 56)
            Tb_Especificar4.Location = New Drawing.Point(394, 52)

            Lb_Costo4.Location = New Drawing.Point(45, 56)
            Tb_Costo4.Location = New Drawing.Point(133, 52)

            Lb_Especificar5.Location = New Drawing.Point(327, 87)
            Tb_Especificar5.Location = New Drawing.Point(394, 83)

            Lb_Costo5.Location = New Drawing.Point(8, 87)
            Tb_Costo5.Location = New Drawing.Point(133, 83)

            Lb_Especificar6.Location = New Drawing.Point(327, 118)
            Tb_Especificar6.Location = New Drawing.Point(394, 114)

            Lb_Costo6.Location = New Drawing.Point(83, 118)
            Tb_Costo6.Location = New Drawing.Point(133, 114)

            Lb_Costo7.Location = New Drawing.Point(25, 147)
            Tb_Costo7.Location = New Drawing.Point(133, 143)

            Gb_Pregunta1.Text = "¿Indicar si hay deficiencias en la identificación de peligros, evaluación de riesgos, e implementación de controles?"
            'Gb_Pregunta2.Text = "¿Se han evaluado los riesgos?"
        Else
            If TIPOINCIDENTE = 2 Then
                Gb_Preguntas.Text = "Identificación de Peligros"

                Lb_Costo1.Text = "Daños a la Propiedad $"
                Lb_Costo1.Location = New Drawing.Point(7, 25)
                Tb_Costo1.Location = New Drawing.Point(133, 21)

                'Lb_Especificar1.Show()
                Lb_Especificar1.Location = New Drawing.Point(327, 25)
                Tb_Especificar1.Location = New Drawing.Point(394, 21)

                Lb_Costo2.Hide()
                Tb_Costo2.Hide()

                Lb_Especificar2.Hide()
                Tb_Especificar2.Hide()

                Lb_Costo3.Location = New Drawing.Point(42, 56)
                Tb_Costo3.Location = New Drawing.Point(133, 52)

                Lb_Especificar3.Location = New Drawing.Point(327, 56)
                Tb_Especificar3.Location = New Drawing.Point(394, 52)

                Lb_Costo4.Location = New Drawing.Point(45, 87)
                Tb_Costo4.Location = New Drawing.Point(133, 83)

                Lb_Especificar4.Location = New Drawing.Point(327, 87)
                Tb_Especificar4.Location = New Drawing.Point(394, 83)

                Lb_Costo5.Location = New Drawing.Point(8, 118)
                Tb_Costo5.Location = New Drawing.Point(133, 114)

                Lb_Especificar5.Location = New Drawing.Point(327, 118)
                Tb_Especificar5.Location = New Drawing.Point(394, 114)

                Lb_Especificar6.Location = New Drawing.Point(327, 147)
                Tb_Especificar6.Location = New Drawing.Point(394, 143)

                Lb_Costo6.Location = New Drawing.Point(83, 147)
                Tb_Costo6.Location = New Drawing.Point(133, 143)

                Lb_Costo7.Location = New Drawing.Point(25, 175)
                Tb_Costo7.Location = New Drawing.Point(133, 171)

                Gb_Pregunta1.Text = "¿Indicar si hay deficiencias en la identificación de peligros, evaluación de riesgos, e implementación de controles?"
                'Gb_Pregunta2.Text = "¿Se han evaluado los riesgos?"
            Else
                If TIPOINCIDENTE = 3 Then
                    Gb_Preguntas.Text = "Identificación de Aspectos Ambientales"

                    Lb_Costo1.Text = "Daños al Ambiente $"
                    Lb_Costo1.Location = New Drawing.Point(20, 25)
                    Tb_Costo1.Location = New Drawing.Point(133, 21)

                    Tb_Costo2.Location = New Drawing.Point(133, 52)

                    Tb_Costo3.Location = New Drawing.Point(133, 83)

                    Tb_Costo4.Location = New Drawing.Point(133, 114)

                    Tb_Costo5.Location = New Drawing.Point(133, 143)

                    Tb_Costo6.Location = New Drawing.Point(133, 171)

                    Tb_Costo7.Location = New Drawing.Point(133, 201)

                    Gb_Pregunta1.Text = "¿Indicar si hay deficiencias en la identificación, evaluación de aspectos ambientales, e implementación de controles?"
                    'Gb_Pregunta2.Text = "¿Se han evaluado los impactos?"
                Else
                    If TIPOINCIDENTE = 4 Then
                        Gb_Preguntas.Text = "Identificación de Peligros"
                        Gb_Costos.Hide()
                        Gb_PerdidaReal.Hide()
                        Lb_EntidadNotificada.Hide()
                        Ck_ARL.Hide()
                        Ck_CAR.Hide()
                        Ck_EPS.Hide()
                        Ck_Organismo.Hide()
                        Ck_MinisterioTrabajo.Hide()
                        Ck_AutoridadAmbiental.Hide()
                        Ck_Cliente.Hide()
                        Ck_OtraEntidad.Hide()
                        Lb_OtraEntidad.Hide()
                        Tb_OtraEntidad.Hide()
                        Lb_AsesorJuridico.Hide()
                        Tb_ConceptoAsesorJuridico.Hide()
                        Cu_BuscarPersonaAsesorJuridico.Hide()
                        Lb_NombreAsesor.Hide()
                        Cu_AsociarPersonaBodegaAsesor.Hide()
                        Lb_FechaAsesor.Hide()
                        DTP_FechaConceptoAsesor.Hide()
                        Dgv_Evidencias.Size = New Drawing.Size(900, 245)
                        Pn_Acciones.Location = New Drawing.Point(3, 281)
                        Dgv_AccionesATomar.Size = New Drawing.Size(900, 245)
                        Dgv_AccionesATomar.Location = New Drawing.Point(3, 305)
                        Dgv_Investigadores.Size = New Drawing.Size(900, 215)
                        Gb_Concepto.Location = New Drawing.Point(6, 255)
                        Gb_Concepto.Size = New Drawing.Size(892, 165)
                        Tb_ConceptoHSE.Size = New Drawing.Size(866, 76)
                        Lb_NombreHSE.Location = New Drawing.Point(10, 131)
                        Cu_BuscarPersonaHSE.Location = New Drawing.Point(58, 126)
                        Cu_AsociarPersonaBodegaHSE.Location = New Drawing.Point(349, 128)
                        Lb_FechaHSE.Location = New Drawing.Point(409, 131)
                        DTP_FechaConceptoHSE.Location = New Drawing.Point(458, 128)
                    End If
                End If
            End If
        End If
    End Sub

    Dim dsCargar As New DataSet

    Public Sub CargarComboboxSalud()

        Cb_TipoVinculacion.DataSource = dsCargar.Tables(11)
        Cb_TipoVinculacion.ValueMember = "ID"
        Cb_TipoVinculacion.DisplayMember = "VINCULACION"

        Cb_CargoPersonaAccidente.DataSource = dsCargar.Tables(5).Copy
        Cb_CargoPersonaAccidente.ValueMember = "ID"
        Cb_CargoPersonaAccidente.DisplayMember = "NOMBRE"

        Cb_JornadaHabitual.DataSource = dsCargar.Tables(12)
        Cb_JornadaHabitual.ValueMember = "ID"
        Cb_JornadaHabitual.DisplayMember = "JORNADAHABITUAL"

        Cb_JornadaIncidente.DataSource = dsCargar.Tables(13)
        Cb_JornadaIncidente.ValueMember = "ID"
        Cb_JornadaIncidente.DisplayMember = "JORNADAINCIDENTE"

        Cb_AtencionInmediata.DataSource = dsCargar.Tables(14)
        Cb_AtencionInmediata.ValueMember = "ID"
        Cb_AtencionInmediata.DisplayMember = "ATENCIONINMEDIATA"

        DGVCB_CargoTestigo.DataSource = dsCargar.Tables(5).Copy
        DGVCB_CargoTestigo.DisplayMember = "NOMBRE"
        DGVCB_CargoTestigo.ValueMember = "ID"

        Cb_TipoLesion.DataSource = dsCargar.Tables(16)
        Cb_TipoLesion.DisplayMember = "NOMBRE"
        Cb_TipoLesion.ValueMember = "ID"

        Cb_ParteAfectada.DataSource = dsCargar.Tables(17)
        Cb_ParteAfectada.DisplayMember = "NOMBRE"
        Cb_ParteAfectada.ValueMember = "ID"

        Cb_AgenteAccidente.DataSource = dsCargar.Tables(18)
        Cb_AgenteAccidente.DisplayMember = "NOMBRE"
        Cb_AgenteAccidente.ValueMember = "ID"

        Cb_MecanismoAccidente.DataSource = dsCargar.Tables(19)
        Cb_MecanismoAccidente.DisplayMember = "NOMBRE"
        Cb_MecanismoAccidente.ValueMember = "ID"

        Me.Cb_TipoVinculacion.SelectedIndex = -1
        Me.Cb_TipoLesion.SelectedIndex = -1
        Me.Cb_ParteAfectada.SelectedIndex = -1
        Me.Cb_AgenteAccidente.SelectedIndex = -1
        Me.Cb_MecanismoAccidente.SelectedIndex = -1
        Me.Cb_AtencionInmediata.SelectedIndex = -1
        Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedIndex = -1
        Me.Cb_CargoMedico.SelectedIndex = -1

    End Sub
    Public Sub CargarTablas()
        Dim identificador As Long
        Dim tipo As Integer
        Dim subtipo As Integer

        If IDREPORTEMODIFICANDO < 0 Then
            identificador = IDREPORTE24H
            tipo = 1 'Crear
        Else
            identificador = IDREPORTEMODIFICANDO
            tipo = 2 'Editar
            subtipo = TIPOINCIDENTE
        End If

        dsCargar = bddatos.CargarMaestrasHSE(1, identificador, tipo, TIPOINCIDENTE)

        'Lleno los combobox
        Cb_Contrato.DataSource = dsCargar.Tables(40)
        Cb_Contrato.DisplayMember = "PROYECTO"
        Cb_Contrato.ValueMember = "IDPROYECTO"

        Cb_Area.DataSource = dsCargar.Tables(4)
        Cb_Area.DisplayMember = "NOMBRE"
        Cb_Area.ValueMember = "ID"

        Cb_CargoAfectacionDaños.DataSource = dsCargar.Tables(5).Copy
        Cb_CargoAfectacionDaños.DisplayMember = "NOMBRE"
        Cb_CargoAfectacionDaños.ValueMember = "ID"

        Cb_CargoPersonaAccidente.DataSource = dsCargar.Tables(5).Copy
        Cb_CargoPersonaAccidente.DisplayMember = "NOMBRE"
        Cb_CargoPersonaAccidente.ValueMember = "ID"

        DGVCB_CargoTestigo.DataSource = dsCargar.Tables(5).Copy
        DGVCB_CargoTestigo.DisplayMember = "NOMBRE"
        DGVCB_CargoTestigo.ValueMember = "ID"

        DGVCB_CargoAcciones.DataSource = dsCargar.Tables(5).Copy
        DGVCB_CargoAcciones.DisplayMember = "NOMBRE"
        DGVCB_CargoAcciones.ValueMember = "ID"

        Cb_CargoAprobo.DataSource = dsCargar.Tables(5).Copy
        Cb_CargoAprobo.DisplayMember = "NOMBRE"
        Cb_CargoAprobo.ValueMember = "ID"

        Cb_CargoReporta.DataSource = dsCargar.Tables(5).Copy
        Cb_CargoReporta.DisplayMember = "NOMBRE"
        Cb_CargoReporta.ValueMember = "ID"

        Cb_CargoMedico.DataSource = dsCargar.Tables(5).Copy
        Cb_CargoMedico.DisplayMember = "NOMBRE"
        Cb_CargoMedico.ValueMember = "ID"

        Cb_ActividadPrincipal.DataSource = dsCargar.Tables(6)
        Cb_ActividadPrincipal.DisplayMember = "NOMBRE"
        Cb_ActividadPrincipal.ValueMember = "ID"

        Cb_TipoConsecuencia.DataSource = dsCargar.Tables(7)
        Cb_TipoConsecuencia.ValueMember = "ID"
        Cb_TipoConsecuencia.DisplayMember = "NOMBRE"

        Cb_Severidad.DataSource = dsCargar.Tables(8)
        Cb_Severidad.ValueMember = "IDMATRIZPERDIDA"
        Cb_Severidad.DisplayMember = "NOMBREMATRIZPERDIDA"

        Cb_SeveridadReal.DataSource = dsCargar.Tables(8).Copy
        Cb_SeveridadReal.ValueMember = "IDMATRIZPERDIDA"
        Cb_SeveridadReal.DisplayMember = "NOMBREMATRIZPERDIDA"

        Cb_TipoIncidente.DataSource = dsCargar.Tables(9)
        Cb_TipoIncidente.DisplayMember = "NOMBRE"
        Cb_TipoIncidente.ValueMember = "ID"

        Cb_Recurrencia.DataSource = dsCargar.Tables(10)
        Cb_Recurrencia.DisplayMember = "RECURRENCIA"
        Cb_Recurrencia.ValueMember = "ID"

        Cb_RecurrenciaReal.DataSource = dsCargar.Tables(10).Copy
        Cb_RecurrenciaReal.DisplayMember = "RECURRENCIA"
        Cb_RecurrenciaReal.ValueMember = "ID"

        Cb_JornadaHabitual.DataSource = dsCargar.Tables(12)
        Cb_JornadaHabitual.ValueMember = "ID"
        Cb_JornadaHabitual.DisplayMember = "JORNADAHABITUAL"

        Cb_JornadaIncidente.DataSource = dsCargar.Tables(13)
        Cb_JornadaIncidente.ValueMember = "ID"
        Cb_JornadaIncidente.DisplayMember = "JORNADAINCIDENTE"

        Cb_Proyecto.DataSource = dsCargar.Tables(20)
        Cb_Proyecto.DisplayMember = "NOMBREBASE"
        Cb_Proyecto.ValueMember = "IDBASEHSE"

        Cb_CondicionClima.DataSource = dsCargar.Tables(23)
        Cb_CondicionClima.DisplayMember = "NOMBRE"
        Cb_CondicionClima.ValueMember = "ID"

        DGVC_RolInvestigador.DataSource = dsCargar.Tables(24)
        DGVC_RolInvestigador.DisplayMember = "NOMBRE"
        DGVC_RolInvestigador.ValueMember = "ID"

        DGVC_TipoCausaInmediataActos.DataSource = dsCargar.Tables(25)
        DGVC_TipoCausaInmediataActos.DisplayMember = "NOMBRE"
        DGVC_TipoCausaInmediataActos.ValueMember = "ID"

        DGVC_TipoCausaInmediataCondiciones.DataSource = dsCargar.Tables(26)
        DGVC_TipoCausaInmediataCondiciones.DisplayMember = "NOMBRE"
        DGVC_TipoCausaInmediataCondiciones.ValueMember = "ID"

        DGVC_TipoCausaBasicaPersonales.DataSource = dsCargar.Tables(27)
        DGVC_TipoCausaBasicaPersonales.DisplayMember = "NOMBRE"
        DGVC_TipoCausaBasicaPersonales.ValueMember = "ID"

        DGVC_TipoCausaBasicaTrabajo.DataSource = dsCargar.Tables(28)
        DGVC_TipoCausaBasicaTrabajo.DisplayMember = "NOMBRE"
        DGVC_TipoCausaBasicaTrabajo.ValueMember = "ID"

        DGVC_TipoEvidencia.DataSource = dsCargar.Tables(29).Copy
        DGVC_TipoEvidencia.DisplayMember = "NOMBRETIPOEVIDENCIAYCAUSA"
        DGVC_TipoEvidencia.ValueMember = "IDTIPOEVIDENCIAYCAUSA"

        DGVC_Prioridad.DataSource = dsCargar.Tables(30).Copy
        DGVC_Prioridad.DisplayMember = "PRIORIDAD"
        DGVC_Prioridad.ValueMember = "ID"

        Dgv_AccionesATomar.AutoGenerateColumns = False
        dtAccionesATomar = dsCargar.Tables(32)
        Dgv_AccionesATomar.DataSource = dtAccionesATomar

        Dgv_LineaTiempo.AutoGenerateColumns = False
        dtLineaTiempo = dsCargar.Tables(33)
        Dgv_LineaTiempo.DataSource = dtLineaTiempo

        Dgv_CausasInmediatasActos.AutoGenerateColumns = False
        dtCausasInmediatasActos = dsCargar.Tables(34)
        Dgv_CausasInmediatasActos.DataSource = dtCausasInmediatasActos

        Dgv_CausasInmediatasCondiciones.AutoGenerateColumns = False
        dtCausasInmediatasCondiciones = dsCargar.Tables(35)
        Dgv_CausasInmediatasCondiciones.DataSource = dtCausasInmediatasCondiciones

        Dgv_CausasBasicasPersonales.AutoGenerateColumns = False
        dtCausasBasicasPersonales = dsCargar.Tables(36)
        Dgv_CausasBasicasPersonales.DataSource = dtCausasBasicasPersonales

        Dgv_CausasBasicasTrabajo.AutoGenerateColumns = False
        dtCausasBasicasTrabajo = dsCargar.Tables(37)
        Dgv_CausasBasicasTrabajo.DataSource = dtCausasBasicasTrabajo

        Dgv_Evidencias.AutoGenerateColumns = False
        dtEvidencias = dsCargar.Tables(38)
        Dgv_Evidencias.DataSource = dtEvidencias

        Dgv_Investigadores.AutoGenerateColumns = False
        dtInvestigadores = dsCargar.Tables(39)
        Dgv_Investigadores.DataSource = dtInvestigadores

        Cb_UnidadSustancia.DataSource = dsCargar.Tables(31)
        Cb_UnidadSustancia.DisplayMember = "ABREVIATURA"
        Cb_UnidadSustancia.ValueMember = "CODIGOTIPOUNIDAD"

        Me.Cu_BuscarPersonaReporta.CargarDatos()
        Me.Cu_BuscarPersonaReporta.CargarCajaTexto()
        Me.Cu_BuscarPersonaAfectada.CargarDatos()
        Me.Cu_BuscarPersonaAfectada.CargarCajaTexto()
        Me.Cu_BuscarPersonaMedico.CargarDatos()
        Me.Cu_BuscarPersonaMedico.CargarCajaTexto()
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarDatos()
        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarCajaTexto()
        Me.Cu_BuscarPersonaHSE.CargarDatos()
        Me.Cu_BuscarPersonaHSE.CargarCajaTexto()
        Me.Cu_BuscarPersonaAprobo.CargarDatos()
        Me.Cu_BuscarPersonaAprobo.CargarCajaTexto()
        Me.Cu_BuscarPersonaAsesorJuridico.CargarDatos()
        Me.Cu_BuscarPersonaAsesorJuridico.CargarCajaTexto()
        Me.Cu_CiudadIncidente.CargarDatos()


        dtReporte = dsCargar.Tables(0)
        If dtReporte.Rows.Count > 0 Then
            filareporte = dtReporte.Rows(0)
        End If

        dtReportePersona = dsCargar.Tables(1)
        If Me.TIPOINCIDENTE = 1 Then
            filareportepersona = dtReportePersona.Rows(0)
        End If

        Me.Dgv_Testigos.AutoGenerateColumns = False
        dtTestigos = dsCargar.Tables(2)
        Dgv_Testigos.DataSource = dtTestigos
        If Me.TIPO = 2 Then
            dtReporteInv = dsCargar.Tables(3)
            If dtReporteInv.Rows.Count > 0 Then
                filareporteinv = dtReporteInv.Rows(0)
            End If
        End If

    End Sub

    Public Sub LlenarReporte()
        'Creando
        If TIPO = 1 Then
            Me.Cb_Contrato.SelectedValue = filareporte("CONTRATO")
            Me.Cb_Proyecto.SelectedValue = filareporte("IDBASE")
            Me.Cb_TipoIncidente.SelectedValue = filareporte("IDTIPOINCIDENTE")
            Me.Cb_TipoConsecuencia.SelectedValue = filareporte("IDTIPOCONSECUENCIA")
            Me.Cb_Area.SelectedValue = filareporte("IDAREA")
            If filareporte("EMPLEADOR").ToString <> "ISMOCOL" Then
                Me.Ck_Empleador.Checked = False
                Me.Tb_Empleador.Text = filareporte("EMPLEADOR").ToString
            Else
                Me.Ck_Empleador.Checked = True
                Me.Tb_Empleador.Text = filareporte("EMPLEADOR").ToString
            End If
            Me.Cb_ActividadPrincipal.SelectedValue = filareporte("ACTIVIDADPRINCIPAL")
            Me.Tb_SitioIncidente.Text = filareporte("SITIOINCIDENTE")
            If filareporte("ZONAOCURRIO").ToString = "U" Then
                Me.Rb_ZonaUrbana.Checked = True
            Else
                Me.Rb_ZonaRural.Checked = True
            End If

            Me.Cu_CiudadIncidente.Cb_Ciudad.SelectedValue = filareporte("MUNICIPIO")
            If filareporte("LUGARACCIDENTE").ToString = "D" Then
                Me.Rb_LugarDentroEmpresa.Checked = True
            Else
                Me.Rb_LugarFueraEmpresa.Checked = True
            End If
            Me.DTP_FechaIncidente.Checked = True
            Me.DTP_FechaIncidente.Value = filareporte("FECHAACCIDENTE")
            Me.DTP_HoraIncidente.Checked = True
            Me.DTP_HoraIncidente.Value = filareporte("HORAACCIDENTE")
            Me.DTP_HorasLaboradas.Checked = True
            Me.DTP_HorasLaboradas.Value = filareporte("HORASLABORADASDIA")

            Me.Tb_Descripcion.Text = filareporte("DESCRIPCIONINCIDENTE")
            Me.Cb_Severidad.SelectedValue = filareporte("SEVERIDADPERDIDAPOTENCIAL")

            Dim Recurrencia As String = filareporte("CATEGORIAPERDIDAPOTENCIAL")
            Recurrencia = Recurrencia(1)
            If Recurrencia = "1" Then
                Me.Cb_Recurrencia.SelectedValue = 1
            Else
                If Recurrencia = "2" Then
                    Me.Cb_Recurrencia.SelectedValue = 2
                Else
                    Me.Cb_Recurrencia.SelectedValue = 3
                End If
            End If

            Dim anexos As String = filareporte("ANEXOS")
            Dim ch As Char = anexos(0)
            If ch = "S" Then
                Me.Ck_AnexoDibujos.Checked = True
            Else
                Me.Ck_AnexoDibujos.Checked = False
            End If
            ch = anexos(1)
            If ch = "S" Then
                Me.Ck_AnexoFotos.Checked = True
            Else
                Me.Ck_AnexoFotos.Checked = False
            End If
            ch = anexos(2)
            If ch = "S" Then
                Me.Ck_AnexoDocumentos.Checked = True
            Else
                Me.Ck_AnexoDocumentos.Checked = False
            End If
            ch = anexos(3)
            If ch = "S" Then
                Me.Ck_OtrosAnexos.Checked = True
                Me.Tb_OtrosAnexos.Text = filareporte("OTROSANEXOS")
            Else
                Me.Ck_OtrosAnexos.Checked = False
            End If
            Me.Cu_BuscarPersonaReporta.CargarDatos()
            Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = filareporte("IDPERSONAREPORTA")
            Me.Cu_BuscarPersonaReporta.CargarCajaTexto()
            Me.Cb_CargoReporta.SelectedValue = filareporte("IDCARGOPERSONAREPORTA")


            If filareporte("IDTIPOINCIDENTE").ToString = "1" Then
                CargarComboboxSalud()
                Me.Cb_TipoVinculacion.SelectedValue = filareportepersona("TIPOVINCULACION")

                Me.Cu_BuscarPersonaAfectada.CargarDatos()
                Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = filareportepersona("IDPERSONAACCIDENTE")
                Me.Cu_BuscarPersonaAfectada.CargarCajaTexto()

                Me.Cu_BuscarPersonaMedico.CargarDatos()

                Me.DTP_FechaNacimiento.Value = filareportepersona("FECHANACIMIENTO")

                If filareportepersona("GENERO").ToString = "M" Then
                    Me.Rb_Masculino.Checked = True
                    Me.Rb_Femenino.Checked = False
                Else
                    Me.Rb_Femenino.Checked = True
                    Me.Rb_Masculino.Checked = False
                End If

                Me.Cb_CargoPersonaAccidente.SelectedValue = filareportepersona("IDCARGOPERSONACCIDENTE")
                Me.Cb_JornadaHabitual.SelectedValue = filareportepersona("JORNADAHABITUAL")
                Me.DTP_InicioContrato.Value = filareportepersona("FECHAINICIOCONTRATO")

                Dim años, meses, dias, dias_sobran As Integer
                Dim años_str, meses_str, dias_str As String
                Dim PriFec As Date = Me.DTP_InicioContrato.Value
                Dim SecFec As Date = Date.Today
                Dim DiasTotales As Long = DateDiff(DateInterval.Day, PriFec, SecFec)
                años = DiasTotales \ 365
                dias_sobran = DiasTotales Mod 365
                meses = dias_sobran \ 30
                dias = dias_sobran Mod 30
                If (años > 0) Then
                    años_str = años & " año(s) "
                Else
                    años_str = ""
                End If
                If (meses > 0) Then
                    If meses = 12 Then
                        años += 1
                        años_str = años & " año(s) "
                        meses_str = 0 & " mes(es) "
                    Else
                        meses_str = meses & " mes(es) "
                    End If
                Else
                    meses_str = ""
                End If
                If (dias > 0) Then
                    dias_str = dias & " dia(s)"
                Else
                    dias_str = ""
                End If
                Tb_CargoActual.Text = Trim(años_str & meses_str & dias_str)

                Me.Cb_JornadaIncidente.SelectedValue = filareportepersona("JORNADAINCIDENTE")
                If filareportepersona("TRABAJOHABITUAL") = "S" Then
                    Me.Rb_TrabajoHabitualSi.Checked = True
                    Me.Rb_TrabajoHabitualNo.Checked = False
                Else
                    Me.Rb_TrabajoHabitualSi.Checked = False
                    Me.Rb_TrabajoHabitualNo.Checked = True
                    Me.Tb_TrabajoHabitual.Text = filareportepersona("OTROTRABAJOHABITUAL")
                End If

                Me.Cb_TipoLesion.SelectedValue = filareportepersona("TIPOLESION")
                If filareportepersona("TIPOLESION").ToString = "252" Then
                    Me.Tb_OtroTipoLesion.Text = filareportepersona("OTROTIPOLESION")
                    Me.Tb_OtroTipoLesion.Show()
                End If

                Me.Cb_ParteAfectada.SelectedValue = filareportepersona("PARTECUERPOAFECTADA")
                If filareportepersona("PARTECUERPOAFECTADA").ToString = "287" Then
                    Me.Tb_OtraParteAfectada.Text = filareportepersona("OTRAPARTECUERPOAFECTADA").ToString
                    Me.Tb_OtraParteAfectada.Show()
                End If

                Me.Cb_AgenteAccidente.SelectedValue = filareportepersona("AGENTEACCIDENTE")
                If filareportepersona("AGENTEACCIDENTE").ToString = "297" Then
                    Me.Tb_OtroAgenteAccidente.Text = filareportepersona("OTROAGENTEACCIDENTE")
                    Me.Tb_OtroAgenteAccidente.Show()
                End If

                Me.Cb_MecanismoAccidente.SelectedValue = filareportepersona("MECANISMO")
                If filareportepersona("MECANISMO").ToString = "305" Then
                    Me.Tb_OtroMecanismoAccidente.Text = filareportepersona("OTROMECANISMO")
                    Me.Tb_OtroMecanismoAccidente.Show()
                End If

                Me.Tb_ComentarioMedico.Text = filareportepersona("DIAGNOSTICO")

                Me.Cb_AtencionInmediata.SelectedValue = filareportepersona("TIPOATENCIONINMEDIATA")
                If filareportepersona("TIPOATENCIONINMEDIATA").ToString = "5" Then
                    Me.Tb_Traslado.Text = filareportepersona("TRASLADO")
                End If
            End If

            'Seccion Testigos
            Me.TabControl1.Controls.Remove(Me.Tp_InformacionAfectado)
            Me.TabControl1.TabPages.Add(Me.Tp_InformacionAfectado)
            Me.Dgv_Testigos.Columns(0).DataPropertyName = "Cedula"
            Me.Dgv_Testigos.Columns(1).DataPropertyName = "Nombre"
            Me.Dgv_Testigos.Columns(2).DataPropertyName = "Cargo"
            Me.Dgv_Testigos.DataSource = dtTestigos
        End If

        'Editando
        If TIPO = 2 Then
            Me.Cb_Contrato.Text = filareporte("CONTRATO")
            Me.Cb_Proyecto.SelectedValue = filareporteinv("IDBASE")
            Me.Cb_TipoIncidente.SelectedValue = filareporte("IDTIPOINCIDENTE")
            Me.Cb_TipoConsecuencia.SelectedValue = filareporteinv("IDTIPOCONSECUENCIA")
            Me.Cb_Area.SelectedValue = filareporte("IDAREA")
            If filareporte("EMPLEADOR").ToString <> "ISMOCOL" Then
                Me.Ck_Empleador.Checked = False
                Me.Tb_Empleador.Text = filareporte("EMPLEADOR").ToString
            Else
                Me.Ck_Empleador.Checked = True
                Me.Tb_Empleador.Text = filareporte("EMPLEADOR").ToString
            End If

            If IsDBNull(filareporteinv("ACTIVIDAD")) Then
                Me.Cb_ActividadPrincipal.SelectedValue = filareporte("ACTIVIDADPRINCIPAL")
            Else
                Me.Cb_ActividadPrincipal.SelectedValue = filareporteinv("ACTIVIDAD")
            End If

            If IsDBNull(filareporteinv("SITIOINCIDENTE")) Then
                Me.Tb_SitioIncidente.Text = filareporte("SITIOINCIDENTE")
            Else
                Me.Tb_SitioIncidente.Text = filareporteinv("SITIOINCIDENTE")
            End If

            Me.DTP_FechaIncidente.Checked = True
            If IsDBNull(filareporteinv("FECHAACCIDENTE")) Then
                Me.DTP_FechaIncidente.Value = filareporte("FECHAACCIDENTE")
            Else
                Me.DTP_FechaIncidente.Value = filareporteinv("FECHAACCIDENTE")
            End If

            If IsDBNull(filareporteinv("HORAACCIDENTE")) Then
                Me.DTP_HoraIncidente.Checked = True
                Me.DTP_HoraIncidente.Value = filareporte("HORAACCIDENTE")
            Else
                Me.DTP_HoraIncidente.Checked = True
                Me.DTP_HoraIncidente.Value = filareporteinv("HORAACCIDENTE")
            End If
            If IsDBNull(filareporteinv("JORNADAHABITUAL")) Then
                Me.Cb_JornadaHabitual.SelectedValue = filareportepersona("JORNADAHABITUAL")
            Else
                Me.Cb_JornadaHabitual.SelectedValue = filareporteinv("JORNADAHABITUAL")
            End If
            If IsDBNull(filareporteinv("JORNADAINCIDENTE")) Then
                Me.Cb_JornadaIncidente.SelectedValue = filareportepersona("JORNADAINCIDENTE")
            Else
                Me.Cb_JornadaIncidente.SelectedValue = filareporteinv("JORNADAINCIDENTE")
            End If

            If IsDBNull(filareporte("HORASLABORADASDIA")) Then
                Me.DTP_HorasLaboradas.Checked = True
                Me.DTP_HorasLaboradas.Value = filareporte("HORASLABORADASDIA")
            Else
                Me.DTP_HorasLaboradas.Checked = True
                Me.DTP_HorasLaboradas.Value = filareporteinv("HORASLABORADASDIA")
            End If
            If IsDBNull(filareporteinv("TRABAJOHABITUAL")) Then
                If filareportepersona("TRABAJOHABITUAL") = "S" Then
                    Me.Rb_TrabajoHabitualSi.Checked = True
                    Me.Rb_TrabajoHabitualNo.Checked = False
                    Me.Tb_TrabajoHabitual.Text = filareportepersona("OTROTRABAJOHABITUAL")
                Else
                    Me.Rb_TrabajoHabitualSi.Checked = False
                    Me.Rb_TrabajoHabitualNo.Checked = True
                    Me.Tb_TrabajoHabitual.Text = filareportepersona("OTROTRABAJOHABITUAL")
                End If
            Else
                If filareporteinv("TRABAJOHABITUAL") = "S" Then
                    Me.Rb_TrabajoHabitualSi.Checked = True
                    Me.Rb_TrabajoHabitualNo.Checked = False
                    Me.Tb_TrabajoHabitual.Text = filareporteinv("OTROTRABAJOHABITUAL")
                Else
                    Me.Rb_TrabajoHabitualSi.Checked = False
                    Me.Rb_TrabajoHabitualNo.Checked = True
                    Me.Tb_TrabajoHabitual.Text = filareporteinv("OTROTRABAJOHABITUAL")
                End If
            End If

            If filareporte("ZONAOCURRIO").ToString = "U" Then
                Me.Rb_ZonaUrbana.Checked = True
            Else
                Me.Rb_ZonaRural.Checked = True
            End If

            Me.Cu_CiudadIncidente.Cb_Ciudad.SelectedValue = filareporte("MUNICIPIO")

            If IsDBNull(filareporteinv("LUGARACCIDENTE")) Then
                If filareporte("LUGARACCIDENTE").ToString = "D" Then
                    Me.Rb_LugarDentroEmpresa.Checked = True
                Else
                    Me.Rb_LugarFueraEmpresa.Checked = True
                End If
            Else
                If filareporteinv("LUGARACCIDENTE").ToString = "D" Then
                    Me.Rb_LugarDentroEmpresa.Checked = True
                Else
                    Me.Rb_LugarFueraEmpresa.Checked = True
                End If
            End If

            Me.Cu_BuscarPersonaReporta.CargarDatos()
            Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = filareporte("IDPERSONAREPORTA")
            Me.Cu_BuscarPersonaReporta.CargarCajaTexto()
            Me.Cb_CargoReporta.SelectedValue = filareporte("IDCARGOPERSONAREPORTA")
            Me.Cb_CondicionClima.SelectedValue = filareporteinv("CLIMA")

            If IsDBNull(filareporteinv("DESCRIPCIONINCIDENTE")) Then
                Me.Tb_Descripcion.Text = filareporte("DESCRIPCIONINCIDENTE")
            Else
                Me.Tb_Descripcion.Text = filareporteinv("DESCRIPCIONINCIDENTE")
            End If
            If Not IsDBNull(filareporteinv("QUEESTUVOMAL")) Then
                Me.Tb_EstuvoMal.Text = filareporteinv("QUEESTUVOMAL")
            End If

            If filareporte("IDTIPOINCIDENTE").ToString = "1" Then
                CargarComboboxSalud()

                Me.Cu_BuscarPersonaAfectada.CargarDatos()
                Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = filareportepersona("IDPERSONAACCIDENTE")
                Me.Cu_BuscarPersonaAfectada.CargarCajaTexto()
                Me.Cu_BuscarPersonaMedico.CargarDatos()
                Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedIndex = -1

                Me.Cb_CargoPersonaAccidente.SelectedValue = filareportepersona("IDCARGOPERSONACCIDENTE")
                Me.DTP_FechaNacimiento.Value = filareportepersona("FECHANACIMIENTO")

                If filareportepersona("GENERO").ToString = "M" Then
                    Me.Rb_Masculino.Checked = True
                Else
                    Me.Rb_Femenino.Checked = True
                End If

                Me.DTP_InicioContrato.Value = filareportepersona("FECHAINICIOCONTRATO")
                Me.Tb_CargoActual.Text = Today.Year - Me.DTP_InicioContrato.Value.Year

                Dim años, meses, dias, dias_sobran As Integer
                Dim años_str, meses_str, dias_str As String
                Dim PriFec As Date = Me.DTP_InicioContrato.Value
                Dim SecFec As Date = Date.Today
                Dim DiasTotales As Long = DateDiff(DateInterval.Day, PriFec, SecFec)
                años = DiasTotales \ 365
                dias_sobran = DiasTotales Mod 365
                meses = dias_sobran \ 30
                dias = dias_sobran Mod 30
                If (años > 0) Then
                    años_str = años & " año(s) "
                Else
                    años_str = ""
                End If
                If (meses > 0) Then
                    If meses = 12 Then
                        años += 1
                        años_str = años & " año(s) "
                        meses_str = 0 & " mes(es) "
                    Else
                        meses_str = meses & " mes(es) "
                    End If
                Else
                    meses_str = ""
                End If
                If (dias > 0) Then
                    dias_str = dias & " dia(s)"
                Else
                    dias_str = ""
                End If
                Tb_CargoActual.Text = Trim(años_str & meses_str & dias_str)

                Me.Cb_TipoVinculacion.SelectedValue = filareportepersona("TIPOVINCULACION")
                Me.Cb_CargoPersonaAccidente.SelectedValue = filareportepersona("IDCARGOPERSONACCIDENTE")

                If Not IsDBNull(filareporteinv("AÑOSEXPERIENCIASOCUPACIONAL")) Then
                    Me.Num_ExperienciaAños.Value = filareporteinv("AÑOSEXPERIENCIASOCUPACIONAL")
                End If

                If Not IsDBNull(filareporteinv("MESESEXPERIENCIASOCUPACIONAL")) Then
                    Me.Num_ExperienciaMeses.Value = filareporteinv("MESESEXPERIENCIASOCUPACIONAL")
                End If

                If Not IsDBNull(filareporteinv("DIASTRABAJANDOSITIO")) Then
                    Me.Num_DiasSitio.Value = filareporteinv("DIASTRABAJANDOSITIO")
                End If

                CalcularExperienciaOcupacional()

                If Not IsDBNull(filareporteinv("FECHAREGRESOTRABAJO")) Then
                    Me.DTP_FechaRegresoTrabajo.Checked = True
                    Me.DTP_FechaRegresoTrabajo.Value = filareporteinv("FECHAREGRESOTRABAJO")
                End If


                If IsDBNull(filareporteinv("TIPOLESION")) Then
                    Me.Cb_TipoLesion.SelectedValue = filareportepersona("TIPOLESION")
                    If filareportepersona("TIPOLESION").ToString = "252" Then
                        Me.Tb_OtroTipoLesion.Text = filareportepersona("OTROTIPOLESION")
                        Me.Tb_OtroTipoLesion.Show()
                    End If
                Else
                    Me.Cb_TipoLesion.SelectedValue = filareporteinv("TIPOLESION")
                    If filareporteinv("TIPOLESION").ToString = "252" Then
                        Me.Tb_OtroTipoLesion.Text = filareporteinv("OTROTIPOLESION")
                        Me.Tb_OtroTipoLesion.Show()
                    End If
                End If

                If IsDBNull(filareporteinv("PARTECUERPOAFECTADA")) Then
                    Me.Cb_ParteAfectada.SelectedValue = filareportepersona("PARTECUERPOAFECTADA")
                    If filareportepersona("PARTECUERPOAFECTADA").ToString = "287" Then
                        Me.Tb_OtraParteAfectada.Text = filareportepersona("OTRAPARTECUERPOAFECTADA").ToString
                        Me.Tb_OtraParteAfectada.Show()
                    End If
                Else
                    Me.Cb_ParteAfectada.SelectedValue = filareporteinv("PARTECUERPOAFECTADA")
                    If filareporteinv("PARTECUERPOAFECTADA").ToString = "287" Then
                        Me.Tb_OtraParteAfectada.Text = filareporteinv("OTRAPARTECUERPOAFECTADA").ToString
                        Me.Tb_OtraParteAfectada.Show()
                    End If
                End If

                If IsDBNull(filareporteinv("AGENTEACCIDENTE")) Then
                    Me.Cb_AgenteAccidente.SelectedValue = filareportepersona("AGENTEACCIDENTE")
                    If filareportepersona("AGENTEACCIDENTE").ToString = "297" Then
                        Me.Tb_OtroAgenteAccidente.Text = filareportepersona("OTROAGENTEACCIDENTE")
                        Me.Tb_OtroAgenteAccidente.Show()
                    End If
                Else
                    Me.Cb_AgenteAccidente.SelectedValue = filareporteinv("AGENTEACCIDENTE")
                    If filareporteinv("AGENTEACCIDENTE").ToString = "297" Then
                        Me.Tb_OtroAgenteAccidente.Text = filareporteinv("OTROAGENTEACCIDENTE")
                        Me.Tb_OtroAgenteAccidente.Show()
                    End If
                End If

                If IsDBNull(filareporteinv("MECANISMO")) Then
                    Me.Cb_MecanismoAccidente.SelectedValue = filareportepersona("MECANISMO")
                    If filareportepersona("MECANISMO").ToString = "305" Then
                        Me.Tb_OtroMecanismoAccidente.Text = filareportepersona("OTROMECANISMO")
                        Me.Tb_OtroMecanismoAccidente.Show()
                    End If
                Else
                    Me.Cb_MecanismoAccidente.SelectedValue = filareporteinv("MECANISMO")
                    If filareporteinv("MECANISMO").ToString = "305" Then
                        Me.Tb_OtroMecanismoAccidente.Text = filareporteinv("OTROMECANISMO")
                        Me.Tb_OtroMecanismoAccidente.Show()
                    End If
                End If

                If Not IsDBNull(filareportepersona("TIPOATENCIONINMEDIATA")) Then
                    Me.Cb_AtencionInmediata.SelectedValue = filareportepersona("TIPOATENCIONINMEDIATA")
                End If

                If filareportepersona("TIPOATENCIONINMEDIATA").ToString = "5" Then
                    Me.Tb_Traslado.Text = filareportepersona("TRASLADO")
                End If

                If IsDBNull(filareporteinv("COMENTARIOMEDICO")) Then
                    Me.Tb_ComentarioMedico.Text = filareportepersona("DIAGNOSTICO")
                Else
                    Me.Tb_ComentarioMedico.Text = filareporteinv("COMENTARIOMEDICO")
                End If

                If Not IsDBNull(filareporteinv("IDPERSONAMEDICO")) Then

                    Me.Cu_BuscarPersonaMedico.CargarDatos()
                    Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedValue = filareporteinv("IDPERSONAMEDICO")
                    Me.Cu_BuscarPersonaMedico.CargarCajaTexto()
                End If
                If Not IsDBNull(filareporteinv("IDCARGOMEDICO")) Then
                    Me.Cb_CargoMedico.SelectedValue = filareporteinv("IDCARGOMEDICO")
                End If

                If Not IsDBNull(filareporteinv("FECHAATENCION")) Then
                    Me.DTP_FechaConceptoMedico.Checked = True
                    Me.DTP_FechaConceptoMedico.Value = filareporteinv("FECHAATENCION")
                End If
                If Not IsDBNull(filareporteinv("HORAATENCION")) Then
                    Me.DTP_HoraConceptoMedico.Checked = True
                    Me.DTP_HoraConceptoMedico.Value = filareporteinv("HORAATENCION")
                End If
            Else
                If filareporte("IDTIPOINCIDENTE").ToString = "2" Then
                    If Not IsDBNull(filareporteinv("SUSTANCIA_PROCESO")) Then
                        Me.Tb_SustanciaProceso.Text = filareporteinv("SUSTANCIA_PROCESO")
                    End If
                    If Not IsDBNull(filareporteinv("OBSERVACION")) Then
                        Me.Tb_AfectacionDaño.Text = filareporteinv("OBSERVACION")
                    End If
                    If Not IsDBNull(filareporteinv("IDPERSONAINVOLUCRADA")) Then
                        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarDatos()
                        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue = filareporteinv("IDPERSONAINVOLUCRADA")
                        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarCajaTexto()
                    End If
                    If Not IsDBNull(filareporteinv("IDCARGOPERSONAINVOLUCRADA")) Then
                        Me.Cb_CargoAfectacionDaños.SelectedValue = filareporteinv("IDCARGOPERSONAINVOLUCRADA")
                    End If
                    If Not IsDBNull(filareporteinv("RESUMENATENCIONPRESTADA")) Then
                        Me.Tb_AtencionPrestadaAfectacionDaños.Text = filareporteinv("RESUMENATENCIONPRESTADA")
                    End If
                Else
                    If filareporte("IDTIPOINCIDENTE").ToString = "3" Then
                        If Not IsDBNull(filareporteinv("SUSTANCIA_PROCESO")) Then
                            Me.Tb_SustanciaProceso.Text = filareporteinv("SUSTANCIA_PROCESO")
                        End If
                        If Not IsDBNull(filareporteinv("UNIDADAFECTACIONAMBIENTAL")) Then
                            Me.Cb_UnidadSustancia.SelectedValue = filareporteinv("UNIDADAFECTACIONAMBIENTAL")
                        End If
                        If Not IsDBNull(filareporteinv("CANTIDAD")) Then
                            Me.Tb_CantidadSustancia.Text = filareporteinv("CANTIDAD")
                        End If
                        If Not IsDBNull(filareporteinv("OBSERVACION")) Then
                            Me.Tb_AfectacionDaño.Text = filareporteinv("OBSERVACION")
                        End If
                        If Not IsDBNull(filareporteinv("IDPERSONAINVOLUCRADA")) Then
                            Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarDatos()
                            Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue = filareporteinv("IDPERSONAINVOLUCRADA")
                            Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarCajaTexto()
                        End If
                        If Not IsDBNull(filareporteinv("IDCARGOPERSONAINVOLUCRADA")) Then
                            Me.Cb_CargoAfectacionDaños.SelectedValue = filareporteinv("IDCARGOPERSONAINVOLUCRADA")
                        End If
                        If Not IsDBNull(filareporteinv("RESUMENATENCIONPRESTADA")) Then
                            Me.Tb_AtencionPrestadaAfectacionDaños.Text = filareporteinv("RESUMENATENCIONPRESTADA")
                        End If
                    End If
                End If
            End If

            If IsDBNull(filareporteinv("SEVERIDADPERDIDAPOTENCIAL")) Then
                Me.Cb_Severidad.SelectedValue = filareporte("SEVERIDADPERDIDAPOTENCIAL")
            Else
                Me.Cb_Severidad.SelectedValue = filareporteinv("SEVERIDADPERDIDAPOTENCIAL")
            End If

            Dim Recurrencia As String
            If IsDBNull(filareporteinv("CATEGORIAPERDIDAPOTENCIAL")) Then
                Recurrencia = filareporte("CATEGORIAPERDIDAPOTENCIAL")
                Recurrencia = Recurrencia(1)

            Else
                Recurrencia = filareporteinv("CATEGORIAPERDIDAPOTENCIAL")
                Recurrencia = Recurrencia(1)
            End If

            If Recurrencia = "1" Then
                Me.Cb_Recurrencia.SelectedValue = 1
            Else
                If Recurrencia = "2" Then
                    Me.Cb_Recurrencia.SelectedValue = 2
                Else
                    Me.Cb_Recurrencia.SelectedValue = 3
                End If
            End If
            If Not IsDBNull(filareporteinv("PEORCONSECUENCIA")) Then
                Me.Tb_PeorConsecuencia.Text = filareporteinv("PEORCONSECUENCIA")
            End If
            If Not IsDBNull(filareporteinv("COSTOSDAÑOS")) Then
                Me.Tb_Costo1.Text = filareporteinv("COSTOSDAÑOS")
            End If

            If Not IsDBNull(filareporteinv("DESCRIPCIONCOSTOSDAÑOS")) Then
                Me.Tb_Especificar1.Text = filareporteinv("DESCRIPCIONCOSTOSDAÑOS")
            End If
            If Not IsDBNull(filareporteinv("COSTOSPERDIDA")) Then
                Me.Tb_Costo2.Text = filareporteinv("COSTOSPERDIDA")
            End If

            If Not IsDBNull(filareporteinv("DESCRIPCIONCOSTOSPERDIDA")) Then
                Me.Tb_Especificar2.Text = filareporteinv("DESCRIPCIONCOSTOSPERDIDA")
            End If
            If Not IsDBNull(filareporteinv("COSTOSREPARACIONES")) Then
                Me.Tb_Costo3.Text = filareporteinv("COSTOSREPARACIONES")
            End If

            If Not IsDBNull(filareporteinv("DESCRIPCIONCOSTOSREPARACIONES")) Then
                Me.Tb_Especificar3.Text = filareporteinv("DESCRIPCIONCOSTOSREPARACIONES")
            End If
            If Not IsDBNull(filareporteinv("COSTOSINVESTIGACION")) Then
                Me.Tb_Costo4.Text = filareporteinv("COSTOSINVESTIGACION")
            End If
            If Not IsDBNull(filareporteinv("DESCRIPCIONCOSTOSINVESTIGACION")) Then
                Me.Tb_Especificar4.Text = filareporteinv("DESCRIPCIONCOSTOSINVESTIGACION")
            End If
            If Not IsDBNull(filareporteinv("COSTOSACCIONESCORRECTIVAS")) Then
                Me.Tb_Costo5.Text = filareporteinv("COSTOSACCIONESCORRECTIVAS")
            End If
            If Not IsDBNull(filareporteinv("DESCRIPCIONCOSTOSACCIONESCORRECTIVAS")) Then
                Me.Tb_Especificar5.Text = filareporteinv("DESCRIPCIONCOSTOSACCIONESCORRECTIVAS")
            End If
            If Not IsDBNull(filareporteinv("OTROSCOSTOS")) Then
                Me.Tb_Costo6.Text = filareporteinv("OTROSCOSTOS")
            End If
            If Not IsDBNull(filareporteinv("DESCRIPCIONOTROSCOSTOS")) Then
                Me.Tb_Especificar6.Text = filareporteinv("DESCRIPCIONOTROSCOSTOS")
            End If
            If Not IsDBNull(filareporteinv("SEVERIDADPERDIDAREAL")) Then
                Me.Cb_SeveridadReal.SelectedValue = filareporteinv("SEVERIDADPERDIDAREAL")
            End If
            CalcularCostos()

            If Not IsDBNull(filareporteinv("CATEGORIAPERDIDAREAL")) Then
                Dim RecurrenciaReal As String = filareporteinv("CATEGORIAPERDIDAREAL")
                RecurrenciaReal = RecurrenciaReal(1)
                If RecurrenciaReal = "1" Then
                    Me.Cb_RecurrenciaReal.SelectedValue = 1
                Else
                    If RecurrenciaReal = "2" Then
                        Me.Cb_RecurrenciaReal.SelectedValue = 2
                    Else
                        Me.Cb_RecurrenciaReal.SelectedValue = 3
                    End If
                End If
            End If

            If Not IsDBNull(filareporteinv("RESPUESTA10_1_SI_NO")) Then
                If filareporteinv("RESPUESTA10_1_SI_NO") = "S" Then
                    Me.Rb_Pregunta1No.Checked = False
                    Me.Rb_Pregunta1Si.Checked = True
                    Me.Tb_Pregunta1.Text = filareporteinv("RESPUESTA10_1")
                Else
                    Me.Rb_Pregunta1No.Checked = True
                    Me.Rb_Pregunta1Si.Checked = False
                    Me.Tb_Pregunta1.Text = filareporteinv("RESPUESTA10_1")
                End If
            End If

            If Not IsDBNull(filareporteinv("RESPUESTA10_2_SI_NO")) Then
                If filareporteinv("RESPUESTA10_2_SI_NO") = "S" Then
                    Me.Rb_Pregunta2No.Checked = False
                    Me.Rb_Pregunta2Si.Checked = True
                    Me.Tb_Pregunta2.Text = filareporteinv("RESPUESTA10_2")
                Else
                    Me.Rb_Pregunta2No.Checked = True
                    Me.Rb_Pregunta2Si.Checked = False
                End If
            End If

            Dim entidadnotificada As String
            Dim st As Char
            If Not IsDBNull(filareporteinv("ENTIDADNOTIFICADA")) Then
                entidadnotificada = filareporteinv("ENTIDADNOTIFICADA")
                st = entidadnotificada(0)
                If st = "S" Then
                    Me.Ck_ARL.Checked = True
                Else
                    Me.Ck_ARL.Checked = False
                End If
                st = entidadnotificada(1)
                If st = "S" Then
                    Me.Ck_EPS.Checked = True
                Else
                    Me.Ck_EPS.Checked = False
                End If
                st = entidadnotificada(2)
                If st = "S" Then
                    Me.Ck_CAR.Checked = True
                Else
                    Me.Ck_CAR.Checked = False
                End If
                st = entidadnotificada(3)
                If st = "S" Then
                    Me.Ck_Organismo.Checked = True
                Else
                    Me.Ck_Organismo.Checked = False
                End If
                st = entidadnotificada(4)
                If st = "S" Then
                    Me.Ck_MinisterioTrabajo.Checked = True
                Else
                    Me.Ck_MinisterioTrabajo.Checked = False
                End If
                st = entidadnotificada(5)
                If st = "S" Then
                    Me.Ck_AutoridadAmbiental.Checked = True
                Else
                    Me.Ck_AutoridadAmbiental.Checked = False
                End If
                st = entidadnotificada(6)
                If st = "S" Then
                    Me.Ck_Cliente.Checked = True
                Else
                    Me.Ck_Cliente.Checked = False
                End If
                st = entidadnotificada(7)
                If st = "S" Then
                    Me.Ck_OtraEntidad.Checked = True
                    If Not IsDBNull(filareporteinv("OTRAENTIDADNOTIFICADA")) Then
                        Me.Tb_OtraEntidad.Text = filareporteinv("OTRAENTIDADNOTIFICADA")
                    End If
                Else
                    Me.Ck_OtraEntidad.Checked = False
                End If
            End If

            If Not IsDBNull(filareporteinv("OBSERVACIONHSE")) Then
                Me.Tb_ConceptoHSE.Text = filareporteinv("OBSERVACIONHSE")
            End If
            If Not IsDBNull(filareporteinv("IDPERSONAHSE")) Then
                Me.Cu_BuscarPersonaHSE.CargarDatos()
                Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedValue = filareporteinv("IDPERSONAHSE")
                Me.Cu_BuscarPersonaHSE.CargarCajaTexto()
            End If
            If Not IsDBNull(filareporteinv("FECHAOBSERVACIONHSE")) Then
                Me.DTP_FechaConceptoHSE.Checked = True
                Me.DTP_FechaConceptoHSE.Value = filareporteinv("FECHAOBSERVACIONHSE")
            Else
                Me.DTP_FechaConceptoHSE.Checked = False
            End If

            If Not IsDBNull(filareporteinv("OBSERVACIONASESORJURIDICO")) Then
                Me.Tb_ConceptoAsesorJuridico.Text = filareporteinv("OBSERVACIONASESORJURIDICO")
            End If
            If Not IsDBNull(filareporteinv("IDASESORJURIDICO")) Then
                Me.Cu_BuscarPersonaAsesorJuridico.CargarDatos()
                Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedValue = filareporteinv("IDASESORJURIDICO")
                Me.Cu_BuscarPersonaAsesorJuridico.CargarCajaTexto()
            End If

            If Not IsDBNull(filareporteinv("FECHAOBSERVACIONASESORJURIDICO")) Then
                Me.DTP_FechaConceptoAsesor.Checked = True
                Me.DTP_FechaConceptoAsesor.Value = filareporteinv("FECHAOBSERVACIONASESORJURIDICO")
            Else
                Me.DTP_FechaConceptoAsesor.Checked = False
            End If

            If Not IsDBNull(filareporteinv("IDPERSONAAPRUEBA")) Then
                Me.Cu_BuscarPersonaAprobo.CargarDatos()
                Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedValue = filareporteinv("IDPERSONAAPRUEBA")
                Me.Cu_BuscarPersonaAprobo.CargarCajaTexto()
            End If
            If Not IsDBNull(filareporteinv("CARGOPERSONAAPRUEBA")) Then
                Me.Cb_CargoAprobo.SelectedValue = filareporteinv("CARGOPERSONAAPRUEBA")
            End If
            If Not IsDBNull(filareporteinv("FECHAAPROBACION")) Then
                Me.DTP_FechaAprobacion.Checked = True
                Me.DTP_FechaAprobacion.Value = filareporteinv("FECHAAPROBACION")
            Else
                Me.DTP_FechaAprobacion.Checked = False
            End If

            Dim anexos As String
            Dim ch As Char
            If IsDBNull(filareporteinv("ANEXOS")) Then
                anexos = filareporte("ANEXOS")
                ch = anexos(0)
                If ch = "S" Then
                    Me.Ck_AnexoDibujos.Checked = True
                Else
                    Me.Ck_AnexoDibujos.Checked = False
                End If
                ch = anexos(1)
                If ch = "S" Then
                    Me.Ck_AnexoFotos.Checked = True
                Else
                    Me.Ck_AnexoFotos.Checked = False
                End If
                ch = anexos(2)
                If ch = "S" Then
                    Me.Ck_AnexoDocumentos.Checked = True
                Else
                    Me.Ck_AnexoDocumentos.Checked = False
                End If
                ch = anexos(3)
                If ch = "S" Then
                    Me.Ck_OtrosAnexos.Checked = True
                    Me.Tb_OtrosAnexos.Text = filareporte("OTROSANEXOS")
                Else
                    Me.Ck_OtrosAnexos.Checked = False
                End If
            Else
                anexos = filareporteinv("ANEXOS")
                ch = anexos(0)
                If ch = "S" Then
                    Me.Ck_AnexoDibujos.Checked = True
                Else
                    Me.Ck_AnexoDibujos.Checked = False
                End If
                ch = anexos(1)
                If ch = "S" Then
                    Me.Ck_AnexoFotos.Checked = True
                Else
                    Me.Ck_AnexoFotos.Checked = False
                End If
                ch = anexos(2)
                If ch = "S" Then
                    Me.Ck_AnexoDocumentos.Checked = True
                Else
                    Me.Ck_AnexoDocumentos.Checked = False
                End If
                ch = anexos(3)
                If ch = "S" Then
                    Me.Ck_AnexoReporte24H.Checked = True
                Else
                    Me.Ck_AnexoReporte24H.Checked = False
                End If
                ch = anexos(4)
                If ch = "S" Then
                    Me.Ck_AnexoAlerta.Checked = True
                Else
                    Me.Ck_AnexoAlerta.Checked = False
                End If
                ch = anexos(5)
                If ch = "S" Then
                    Me.Ck_OtrosAnexos.Checked = True
                    Me.Tb_OtrosAnexos.Text = filareporteinv("OTROSANEXOS")
                Else
                    Me.Ck_OtrosAnexos.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub Cb_TipoLesion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoLesion.SelectedIndexChanged
        If Cb_TipoLesion.Text = "Otro tipo lesion" Then
            Tb_OtroTipoLesion.Show()
            Lb_TipoLesion.Show()
        Else
            Tb_OtroTipoLesion.Hide()
            Lb_TipoLesion.Hide()
        End If
    End Sub

    Private Sub Cb_ParteAfectada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_ParteAfectada.SelectedIndexChanged
        If Cb_ParteAfectada.Text = "Otra parte del cuerpo" Then
            Tb_OtraParteAfectada.Show()
            Lb_ParteAfectada.Show()
        Else
            Tb_OtraParteAfectada.Hide()
            Lb_ParteAfectada.Hide()
        End If
    End Sub

    Private Sub Cb_AgenteAccidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AgenteAccidente.SelectedIndexChanged
        If Cb_AgenteAccidente.Text = "Otro agente accidente" Then
            Tb_OtroAgenteAccidente.Show()
            Lb_AgenteAccidente.Show()
        Else
            Tb_OtroAgenteAccidente.Hide()
            Lb_AgenteAccidente.Hide()
        End If
    End Sub

    Private Sub Cb_MecanismoAccidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_MecanismoAccidente.SelectedIndexChanged
        If Cb_MecanismoAccidente.Text = "Otro mecanismo accidente" Then
            Tb_OtroMecanismoAccidente.Show()
            Lb_Mecanismo.Show()
        Else
            Tb_OtroMecanismoAccidente.Hide()
            Lb_Mecanismo.Hide()
        End If
    End Sub

    Private Sub Cb_AtencionInmediata_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AtencionInmediata.SelectedIndexChanged
        If Cb_AtencionInmediata.Text <> "Traslado a centro de Atención" Then
            Lb_Trasladado.Hide()
            Tb_Traslado.Hide()
        Else
            Lb_Trasladado.Show()
            Tb_Traslado.Show()
        End If
    End Sub
    Private Sub Ck_OtrosAnexos_CheckedChanged(sender As Object, e As EventArgs)
        If Ck_OtrosAnexos.Checked = True Then
            Lb_OtrosAnexos.Show()
            Tb_OtrosAnexos.Text = ""
            Tb_OtrosAnexos.Show()
        End If
        If Ck_OtrosAnexos.Checked = False Then
            Lb_OtrosAnexos.Hide()
            Tb_OtrosAnexos.Hide()
        End If
    End Sub
    Private Sub EliminarFilaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        Dim row As Integer = dtTestigos.Rows.Count
        If row = 0 Then
            Exit Sub
        End If
        Dim indice As Integer
        indice = Me.Dgv_Testigos.SelectedCells(0).RowIndex
        If Me.Dgv_Testigos.Rows.Count > 1 Then
            Dgv_Testigos.Rows.RemoveAt(indice)
            dtTestigos.Rows.RemoveAt(indice)
        Else
            If Me.Dgv_Testigos.Rows.Count = 1 Then
                Dgv_Testigos.Rows.Clear()
            End If
        End If
    End Sub

    Private Function VerificarPersonaEnDGV(ByVal Cedula As String, ByVal dataTable As DataTable, ByVal dgv As DataGridView) As Boolean
        Dim filas As DataRow
        If dataTable IsNot Nothing Then
            If dataTable.Rows.Count > 0 Then
                Dim Busqueda As String = " like '%" + Cedula + "%'"
                filas = dataTable.Select("Cedula" + Busqueda).FirstOrDefault
                Dim i As Integer = dataTable.Rows.IndexOf(filas)

                If filas IsNot Nothing Then
                    If i <> dgv.CurrentRow.Index Then
                        VerificarPersonaEnDGV = False
                        Exit Function
                    End If
                End If
            End If

        End If
        VerificarPersonaEnDGV = True
    End Function
    Private Sub Dgv_Testigos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_Testigos.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim fr_BuscarPersona As FormulariosClasesBase.Fr_BuscarPersona = New FormulariosClasesBase.Fr_BuscarPersona
                fr_BuscarPersona.Cargar_Tabla("P")
                fr_BuscarPersona.ShowDialog()
                Try
                    Me.Dgv_Testigos.Rows.RemoveAt(Dgv_Testigos.CurrentCell.RowIndex)
                Catch
                End Try
                If fr_BuscarPersona.Identificacion <> "" Then
                    If VerificarPersonaEnDGV(fr_BuscarPersona.Identificacion, dtTestigos, Dgv_Testigos) Then
                        Dim fila As DataRow
                        fila = dtTestigos.NewRow
                        fila("Cedula") = fr_BuscarPersona.Identificacion
                        fila("Nombre") = fr_BuscarPersona.NombrePersona
                        fila("Cargo") = DBNull.Value
                        fila("DESCRIPCION") = DBNull.Value
                        dtTestigos.Rows.Add(fila)
                    Else
                        MsgBox("Ya se encuentra esa persona registrada", MsgBoxStyle.Exclamation, "Registro existente")
                    End If
                End If
                EliminarFilaVaciaTestigos()
        End Select
    End Sub

    Private Sub EliminarFilaVaciaTestigos()
        Try
            For i = 0 To Dgv_Testigos.Rows.Count - 2
                If IsDBNull(Me.Dgv_Testigos.Rows(i).Cells(0).Value) Then
                    Me.Dgv_Testigos.Rows.RemoveAt(i)
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub Dgv_Testigos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Testigos.CellEndEdit
        Select Case e.ColumnIndex
            Case Dgv_Testigos.Columns("DGVT_CedulaTestigo").Index
                If IsDBNull(Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value) Or Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                    MsgBox("Debe ingresar un valor")
                    Exit Sub
                End If

                For i = 0 To Dgv_Testigos.Rows.Count - 2
                    If Dgv_Testigos.Item(e.ColumnIndex, i).Value.ToString = "" Then
                        MsgBox("Hay campos de la columna cedula sin llenar anteriores a la fila actual")
                        Dgv_Testigos.Item(e.ColumnIndex, i).Value = ""
                        dtTestigos.Rows().RemoveAt(i)
                        Exit Sub
                    End If
                Next

                For i = 0 To Dgv_Testigos.Rows.Count - 2
                    If e.RowIndex <> i Then
                        If Not IsDBNull(Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value) Or Trim(Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value.ToString) = "" Or Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                            If Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value = Dgv_Testigos.Rows(i).Cells("DGVT_CedulaTestigo").Value Then
                                Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value = ""
                                MsgBox("Ya hay un testigo con ese número de documento")
                                Exit Sub
                            End If
                        End If

                    End If
                Next
                Dim Cadena_Consulta As String = "select P.IDPERSONA from PERSONA as P where P.IDENTIFICACION = '" + Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value + "'"
                Dim IdPersona As String
                Dim Consulta As New SqlCommand(Cadena_Consulta)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta.Connection = Conexión
                Consulta.Connection.Open()
                IdPersona = Consulta.ExecuteScalar()
                Consulta.Connection.Close()
                If IdPersona Is Nothing Then
                    Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value = ""
                    MsgBox("No se encontró una persona con ese documento")
                    Exit Sub
                End If
                Dim Cadena_Consulta2 As String = "SELECT dbo.Personanombrecompleto(" + IdPersona + ")"
                Dim Consulta2 As New SqlCommand(Cadena_Consulta2)
                Dim dt As New DataTable
                Consulta2.Connection = Conexión
                Dim adaptador As New SqlDataAdapter(Consulta2)
                Consulta2.Connection.Open()
                adaptador.FillSchema(dt, SchemaType.Source)
                adaptador.Fill(dt)
                Consulta2.Connection.Close()
                Dgv_Testigos.Rows(e.RowIndex).Cells("DGVT_NombreTestigo").Value = dt(0).Item(0)
                Me.Dgv_Testigos.Rows(e.RowIndex).Cells("DGVCB_CargoTestigo").ReadOnly = False
                Me.Dgv_Testigos.Rows(e.RowIndex).Cells("DGVTB_DescripcionTestigo").ReadOnly = False
        End Select
    End Sub

    Private Sub Dgv_Investigadores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_Investigadores.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim fr_BuscarPersona As FormulariosClasesBase.Fr_BuscarPersona = New FormulariosClasesBase.Fr_BuscarPersona
                fr_BuscarPersona.Cargar_Tabla("P")
                fr_BuscarPersona.ShowDialog()
                Try
                    Me.Dgv_Investigadores.Rows.RemoveAt(Dgv_Investigadores.CurrentCell.RowIndex)
                Catch
                End Try
                If fr_BuscarPersona.Identificacion <> "" Then
                    If VerificarPersonaEnDGV(fr_BuscarPersona.Identificacion, dtInvestigadores, Dgv_Investigadores) Then
                        Dim fila As DataRow
                        fila = dtInvestigadores.NewRow
                        fila("Cedula") = fr_BuscarPersona.Identificacion
                        fila("Nombre") = fr_BuscarPersona.NombrePersona
                        Me.Dgv_AccionesATomar.CancelEdit()
                        dtInvestigadores.Rows.Add(fila)
                    Else
                        MsgBox("Ya se encuentra esa persona registrada", MsgBoxStyle.Exclamation, "Registro existente")
                    End If
                End If
                EliminarFilaVaciaInvestigadores()
        End Select
    End Sub

    Private Sub EliminarFilaVaciaInvestigadores()
        Try
            For i = 0 To Dgv_Investigadores.Rows.Count - 2
                If IsDBNull(Me.Dgv_Investigadores.Rows(i).Cells(0).Value) Then
                    Me.Dgv_Investigadores.Rows.RemoveAt(i)
                End If
            Next
        Catch
        End Try
    End Sub
    Private Sub Dgv_Investigadores_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Investigadores.CellEndEdit
        Select Case e.ColumnIndex
            Case Dgv_Investigadores.Columns("DGVT_CedulaInvestigador").Index
                If IsDBNull(Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value) Or Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                    MsgBox("Debe ingresar un valor")
                    Exit Sub
                End If
                For i = 0 To Dgv_Investigadores.Rows.Count - 2
                    If Dgv_Investigadores.Item(e.ColumnIndex, i).Value.ToString = "" Then
                        MsgBox("Hay campos de la columna cedula sin llenar anteriores a la fila actual")
                        Dgv_Investigadores.Item(e.ColumnIndex, i).Value = ""
                        dtInvestigadores.Rows().RemoveAt(i)
                        Exit Sub
                    End If
                Next
                For i = 0 To Dgv_Investigadores.Rows.Count - 2
                    If e.RowIndex <> i Then
                        If Not IsDBNull(Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value) Or Trim(Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value.ToString) <> "" Or Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value IsNot Nothing Then
                            If Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value = Dgv_Investigadores.Rows(i).Cells("DGVT_CedulaInvestigador").Value Then
                                Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value = ""
                                MsgBox("Ya hay un investigador con ese número de documento")
                                Exit Sub
                            End If
                        End If

                    End If
                Next
                Dim Cadena_Consulta As String = "select P.IDPERSONA from PERSONA as P where P.IDENTIFICACION = '" + Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value + "'"
                Dim IdPersona As String
                Dim Consulta As New SqlCommand(Cadena_Consulta)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta.Connection = Conexión
                Consulta.Connection.Open()
                IdPersona = Consulta.ExecuteScalar()
                Consulta.Connection.Close()
                If IdPersona Is Nothing Then
                    Dgv_Investigadores.Item(e.ColumnIndex, e.RowIndex).Value = ""
                    MsgBox("No se encontró una persona con ese documento")
                    Exit Sub
                End If
                Dim Cadena_Consulta2 As String = "SELECT dbo.Personanombrecompleto(" + IdPersona + ")"
                Dim Consulta2 As New SqlCommand(Cadena_Consulta2)
                Dim dt As New DataTable
                Consulta2.Connection = Conexión
                Dim adaptador As New SqlDataAdapter(Consulta2)
                Consulta2.Connection.Open()
                adaptador.FillSchema(dt, SchemaType.Source)
                adaptador.Fill(dt)
                Consulta2.Connection.Close()
                Dgv_Investigadores.Rows(e.RowIndex).Cells("DGVT_NombreInvestigador").Value = dt(0).Item(0)
                Me.Dgv_Investigadores.Rows(e.RowIndex).Cells(2).ReadOnly = False
                Me.Dgv_Investigadores.Rows(e.RowIndex).Cells(3).ReadOnly = False
        End Select
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Public Function ValidarCasillas() As Boolean
        If Cb_Contrato.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el contrato.", MsgBoxStyle.Information, "Contrato")
            TabControl1.SelectedIndex = 0
            Cb_Contrato.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Proyecto.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un proyecto.", MsgBoxStyle.Information, "Proyecto")
            TabControl1.SelectedIndex = 0
            Cb_Proyecto.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_TipoIncidente.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un tipo de incidente.", MsgBoxStyle.Information, "Tipo de incidente")
            TabControl1.SelectedIndex = 0
            Cb_TipoIncidente.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_TipoConsecuencia.SelectedIndex = -1 Then
            MsgBox("Debe selecionar una consecuencia.", MsgBoxStyle.Information, "Consecuencia")
            TabControl1.SelectedIndex = 0
            Cb_TipoConsecuencia.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Area.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un área.", MsgBoxStyle.Information, "Área")
            TabControl1.SelectedIndex = 0
            Cb_Area.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_Empleador.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MsgBox("Debe indicar si el empleador es o no Ismocol, en caso de seleccionar no indique cual es.", MsgBoxStyle.Information, "Empleador (SI/NO)")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_Empleador.Checked = False Then
            If Tb_Empleador.Text = "" Then
                MsgBox("Debe escribir el nombre del empleador.", MsgBoxStyle.Information, "Nombre empleador")
                TabControl1.SelectedIndex = 0
                Tb_Empleador.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If
        If Cb_ActividadPrincipal.SelectedIndex = -1 Then
            MsgBox("Debe selecionar la actividad principal.", MsgBoxStyle.Information, "Actividad principal")
            TabControl1.SelectedIndex = 0
            Cb_ActividadPrincipal.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_SitioIncidente.Text) = "" Then
            MsgBox("Debe indicar el sitio especifico del incidente.", MsgBoxStyle.Information, "Sitio específico del incidente")
            TabControl1.SelectedIndex = 0
            Tb_SitioIncidente.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If DTP_FechaIncidente.Checked = False Then
            MsgBox("Debe seleccionar la fecha del incidente.", MsgBoxStyle.Information, "Fecha del incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            DTP_FechaIncidente.Focus()
            Exit Function
        End If

        If Cu_BuscarPersonaReporta.Cb_Persona.Text = "" OrElse Cu_BuscarPersonaReporta.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que reporta.", MsgBoxStyle.Information, "Persona reporta")
            TabControl1.SelectedIndex = 0
            Cu_BuscarPersonaReporta.Cb_Persona.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_CargoReporta.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el cargo de la persona que reporta.", MsgBoxStyle.Information, "Cargo reporta")
            TabControl1.SelectedIndex = 0
            Cb_CargoReporta.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_JornadaHabitual.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la jornada habitual de trabajo.", MsgBoxStyle.Information, "Jornada habitual")
            TabControl1.SelectedIndex = 0
            Cb_JornadaHabitual.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_JornadaIncidente.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la jornada del incidente.", MsgBoxStyle.Information, "Jornada incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Cb_JornadaIncidente.Focus()
            Exit Function
        End If

        If DTP_HorasLaboradas.Value.Hour > 10 Then
            MsgBox("No puede seleccionar mas de 10 horas", MsgBoxStyle.Information, "Horas laboradas")
            ValidarCasillas = False
            TabControl1.SelectedIndex = 0
            DTP_HorasLaboradas.Focus()
            Exit Function
        End If
        If Rb_TrabajoHabitualNo.Checked = False AndAlso Rb_TrabajoHabitualSi.Checked = False Then
            MsgBox("Debe seleccionar si estaba realizando su trabajo habitual o no.", MsgBoxStyle.Information, "Trabajo habitual [Si/No]")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_TrabajoHabitual.Text) = "" Then
            MsgBox("Debe escribir el trabajo que estaba realizando.", MsgBoxStyle.Information, "Trabajo")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Tb_TrabajoHabitual.Focus()
            Exit Function
        End If

        If Rb_ZonaRural.Checked = False AndAlso Rb_ZonaUrbana.Checked = False Then
            MsgBox("Debe seleccionar la zona donde ocurrió el incidente.", MsgBoxStyle.Information, "Zona donde ocurrió el incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Cu_CiudadIncidente.Cb_Ciudad.Text = "" OrElse Cu_CiudadIncidente.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad del incidente.", MsgBoxStyle.Information, "Ciudad del incidente")
            TabControl1.SelectedIndex = 0
            Cu_CiudadIncidente.Cb_Ciudad.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_LugarDentroEmpresa.Checked = False AndAlso Rb_LugarFueraEmpresa.Checked = False Then
            MsgBox("Debe seleccionar si el lugar donde ocurrió el incidente fue dentro o fuera de la empresa.", MsgBoxStyle.Information, "Lugar donde ocurrió el incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_CondicionClima.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el clima.", MsgBoxStyle.Information, "Clima")
            TabControl1.SelectedIndex = 0
            Cb_CondicionClima.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        dtAccionesATomar.AcceptChanges()
        For i As Integer = 0 To dtAccionesATomar.Rows.Count - 1
            For j As Integer = 0 To dtAccionesATomar.Columns.Count - 2
                If Trim(dtAccionesATomar.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_PlanAccion)
                    MsgBox("Debe ingresar un valor en todas las columnas del plan de acción.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtLineaTiempo.AcceptChanges()
        For i As Integer = 0 To dtLineaTiempo.Rows.Count - 1
            For j As Integer = 0 To dtLineaTiempo.Columns.Count - 1
                If Trim(dtLineaTiempo.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_InformacionGeneral)
                    MsgBox("Debe ingresar un valor en todas las columnas de la linea del tiempo.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtInvestigadores.AcceptChanges()
        For i As Integer = 0 To dtInvestigadores.Rows.Count - 1
            For j As Integer = 0 To dtInvestigadores.Columns.Count - 1
                If Trim(dtInvestigadores.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_Investigadores)
                    MsgBox("Debe ingresar un valor en todas las columnas de investigadores.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        dtCausasInmediatasActos.AcceptChanges()
        For i As Integer = 0 To dtCausasInmediatasActos.Rows.Count - 1
            For j As Integer = 0 To dtCausasInmediatasActos.Columns.Count - 1
                If Trim(dtCausasInmediatasActos.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_AnalisisCausas)
                    MsgBox("Debe ingresar un valor en todas las columnas de Causas Inmediatas - Actos Inseguros.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtCausasInmediatasCondiciones.AcceptChanges()
        For i As Integer = 0 To dtCausasInmediatasCondiciones.Rows.Count - 1
            For j As Integer = 0 To dtCausasInmediatasCondiciones.Columns.Count - 1
                If Trim(dtCausasInmediatasCondiciones.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_AnalisisCausas)
                    MsgBox("Debe ingresar un valor en todas las columnas de  Causas Inmediatas - Condiciones Inseguras.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtCausasBasicasPersonales.AcceptChanges()
        For i As Integer = 0 To dtCausasBasicasPersonales.Rows.Count - 1
            For j As Integer = 0 To dtCausasBasicasPersonales.Columns.Count - 1
                If Trim(dtCausasBasicasPersonales.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_AnalisisCausas)
                    MsgBox("Debe ingresar un valor en todas las columnas de  Causas Básicas - Factores Personales.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtCausasBasicasTrabajo.AcceptChanges()
        For i As Integer = 0 To dtCausasBasicasTrabajo.Rows.Count - 1
            For j As Integer = 0 To dtCausasBasicasTrabajo.Columns.Count - 1
                If Trim(dtCausasBasicasTrabajo.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_AnalisisCausas)
                    MsgBox("Debe ingresar un valor en todas las columnas de  Causas Básicas - Factores del Trabajo.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtEvidencias.AcceptChanges()
        For i As Integer = 0 To dtEvidencias.Rows.Count - 1
            For j As Integer = 0 To dtEvidencias.Columns.Count - 1
                If Trim(dtEvidencias.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_PlanAccion)
                    MsgBox("Debe ingresar un valor en todas las columnas de Evidencias.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        dtTestigos.AcceptChanges()
        For i As Integer = 0 To dtTestigos.Rows.Count - 1
            For j As Integer = 0 To dtTestigos.Columns.Count - 1
                If Trim(dtTestigos.Rows(i).Item(j).ToString) = "" Then
                    TabControl1.SelectedIndex = TabControl1.TabPages.IndexOf(Tp_Testigos)
                    MsgBox("Debe ingresar un valor en todas las columnas de Testigos.", MsgBoxStyle.Information, "Llenar todos los campos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next
        ValidarCasillas = True
    End Function

    Public Function GuardarReporteInvestigacion() As Boolean
        If ValidarCasillas() = False Then
            GuardarReporteInvestigacion = False
            Exit Function
        End If

        Dim Comando As New SqlCommand("dbo.GestionarFormatoInvestigacion")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@ACCION", TIPO)
        Comando.Parameters.AddWithValue("@IDREPORTE24H", IDREPORTE24H)
        Comando.Parameters.AddWithValue("@IDREPORTEINVESTIGACION", IDREPORTEMODIFICANDO)
        Comando.Parameters.AddWithValue("@AÑO", Now.Year)
        Comando.Parameters.AddWithValue("@IDBASE", Me.Cb_Proyecto.SelectedValue)
        Comando.Parameters.AddWithValue("@IDAREA", Me.Cb_Area.SelectedValue)
        Comando.Parameters.AddWithValue("@IDTIPOCONSECUENCIA", Me.Cb_TipoConsecuencia.SelectedValue)
        Comando.Parameters.AddWithValue("@ACTIVIDADPRINCIPAL", Me.Cb_ActividadPrincipal.SelectedValue)
        Comando.Parameters.AddWithValue("@SITIOINCIDENTE", Me.Tb_SitioIncidente.Text)
        Comando.Parameters.AddWithValue("@FECHAACCIDENTE", Me.DTP_FechaIncidente.Value.Date)
        Comando.Parameters.AddWithValue("@HORAACCIDENTE", Me.DTP_HoraIncidente.Value)
        Comando.Parameters.AddWithValue("@HORASLABORADASDIA", Me.DTP_HorasLaboradas.Value)

        If Rb_LugarDentroEmpresa.Checked Then
            Comando.Parameters.AddWithValue("@LUGARACCIDENTE", "D")
        End If
        If Rb_LugarFueraEmpresa.Checked Then
            Comando.Parameters.AddWithValue("@LUGARACCIDENTE", "F")
        End If

        Comando.Parameters.AddWithValue("@JORNADAHABITUAL", Me.Cb_JornadaHabitual.SelectedValue)
        Comando.Parameters.AddWithValue("@JORNADAINCIDENTE", Me.Cb_JornadaIncidente.SelectedValue)

        If Me.Rb_TrabajoHabitualSi.Checked = True Then
            Comando.Parameters.AddWithValue("@TRABAJOHABITUAL", "S")
            Comando.Parameters.AddWithValue("@OTROTRABAJOHABITUAL", Me.Tb_TrabajoHabitual.Text)
        Else
            Comando.Parameters.AddWithValue("@TRABAJOHABITUAL", "N")
            Comando.Parameters.AddWithValue("@OTROTRABAJOHABITUAL", Me.Tb_TrabajoHabitual.Text)
        End If

        Comando.Parameters.AddWithValue("@CLIMA", Me.Cb_CondicionClima.SelectedValue)
        Comando.Parameters.AddWithValue("@DESCRIPCIONINCIDENTE", Me.Tb_Descripcion.Text)
        Comando.Parameters.AddWithValue("@QUEESTUVOMAL", Me.Tb_EstuvoMal.Text)

        If TIPOINCIDENTE = 1 Then
            If Me.Cb_TipoLesion.Text = "Otro tipo lesion" Then
                Comando.Parameters.AddWithValue("@TIPOLESION", Me.Cb_TipoLesion.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROTIPOLESION", Me.Tb_OtroTipoLesion.Text)
            Else
                Comando.Parameters.AddWithValue("@TIPOLESION", Me.Cb_TipoLesion.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROTIPOLESION", DBNull.Value)
            End If
            If Me.Cb_ParteAfectada.Text = "Otra parte del cuerpo" Then
                Comando.Parameters.AddWithValue("@PARTECUERPOAFECTADA", Me.Cb_ParteAfectada.SelectedValue)
                Comando.Parameters.AddWithValue("@OTRAPARTECUERPOAFECTADA", Me.Tb_OtraParteAfectada.Text)
            Else
                Comando.Parameters.AddWithValue("@PARTECUERPOAFECTADA", Me.Cb_ParteAfectada.SelectedValue)
                Comando.Parameters.AddWithValue("@OTRAPARTECUERPOAFECTADA", DBNull.Value)
            End If
            If Me.Cb_AgenteAccidente.Text = "Otro agente accidente" Then
                Comando.Parameters.AddWithValue("@AGENTEACCIDENTE", Me.Cb_AgenteAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROAGENTEACCIDENTE", Me.Tb_OtroAgenteAccidente.Text)
            Else
                Comando.Parameters.AddWithValue("@AGENTEACCIDENTE", Me.Cb_AgenteAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROAGENTEACCIDENTE", DBNull.Value)
            End If
            If Me.Cb_MecanismoAccidente.Text = "Otro mecanismo accidente" Then
                Comando.Parameters.AddWithValue("@MECANISMO", Me.Cb_MecanismoAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROMECANISMO", Me.Tb_OtroMecanismoAccidente.Text)
            Else
                Comando.Parameters.AddWithValue("@MECANISMO", Me.Cb_MecanismoAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROMECANISMO", DBNull.Value)
            End If
            Comando.Parameters.AddWithValue("@AÑOSEXPERIENCIAOCUPACIONAL", Me.Num_ExperienciaAños.Value)
            Comando.Parameters.AddWithValue("@MESESEXPERIENCIAOCUPACIONAL", Me.Num_ExperienciaMeses.Value)
            Comando.Parameters.AddWithValue("@DIASTRABAJANDOSITIO", Me.Num_DiasSitio.Value)
            Comando.Parameters.AddWithValue("@IDMEDICO", Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedValue)
            Comando.Parameters.AddWithValue("@COMENTARIOMEDICO", Me.Tb_ComentarioMedico.Text)
            Comando.Parameters.AddWithValue("@IDCARGOMEDICO", Me.Cb_CargoMedico.SelectedValue)

            If Me.DTP_FechaRegresoTrabajo.Checked Then
                Comando.Parameters.AddWithValue("@FECHAREGRESOTRABAJO", Me.DTP_FechaRegresoTrabajo.Value.Date)
            End If

            If Me.DTP_HoraConceptoMedico.Checked Then
                Comando.Parameters.AddWithValue("@HORAATENCION", Me.DTP_HoraConceptoMedico.Value)
            End If
            If Me.DTP_FechaConceptoMedico.Checked Then
                Comando.Parameters.AddWithValue("@FECHAATENCION", Me.DTP_FechaConceptoMedico.Value)
            End If

            If Trim(Me.Tb_Costo1.Text) <> "" Then
                Comando.Parameters.AddWithValue("@COSTOSDAÑOS", Convert.ToDecimal(Me.Tb_Costo1.Text))
                Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSDAÑOS", Me.Tb_Especificar1.Text)
            End If
            If Trim(Me.Tb_Costo4.Text) <> "" Then
                Comando.Parameters.AddWithValue("@COSTOSINVESTIGACION", Convert.ToDecimal(Me.Tb_Costo4.Text))
                Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSINVESTIGACION", Me.Tb_Especificar4.Text)
            End If
            If Trim(Me.Tb_Costo5.Text) <> "" Then
                Comando.Parameters.AddWithValue("@COSTOSACCIONESCORRECTIVAS", Convert.ToDecimal(Me.Tb_Costo5.Text))
                Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSACCIONESCORRECTIVAS", Me.Tb_Especificar5.Text)
            End If
            If Trim(Me.Tb_Costo6.Text) <> "" Then
                Comando.Parameters.AddWithValue("@OTROSCOSTOS", Convert.ToDecimal(Me.Tb_Costo6.Text))
                Comando.Parameters.AddWithValue("@DESCRIPCIONOTROSCOSTOS", Me.Tb_Especificar6.Text)
            End If
        Else

            If TIPOINCIDENTE = 2 Then
                Comando.Parameters.AddWithValue("@SUSTANCIA_PROCESO", Me.Tb_SustanciaProceso.Text)
                Comando.Parameters.AddWithValue("@OBSERVACION", Me.Tb_AfectacionDaño.Text)
                Comando.Parameters.AddWithValue("@IDPERSONAINVOLUCRADA", Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue)
                Comando.Parameters.AddWithValue("@IDCARGOPERSONAINVOLUCRADA", Me.Cb_CargoAfectacionDaños.SelectedValue)
                Comando.Parameters.AddWithValue("@RESUMENATENCIONPRESTADA", Me.Tb_AtencionPrestadaAfectacionDaños.Text)
                If Trim(Me.Tb_Costo1.Text) <> "" Then
                    Comando.Parameters.AddWithValue("@COSTOSDAÑOS", Convert.ToDecimal(Me.Tb_Costo1.Text))
                    Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSDAÑOS", Me.Tb_Especificar1.Text)
                End If
                If Trim(Me.Tb_Costo2.Text) <> "" Then
                    Comando.Parameters.AddWithValue("@COSTOSPERDIDA", Convert.ToDecimal(Me.Tb_Costo2.Text))
                    Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSPERDIDA", Me.Tb_Especificar2.Text)
                End If
                If Trim(Me.Tb_Costo3.Text) <> "" Then
                    Comando.Parameters.AddWithValue("@COSTOSREPARACIONES", Convert.ToDecimal(Me.Tb_Costo3.Text))
                    Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSREPARACIONES", Me.Tb_Especificar3.Text)
                End If
                If Trim(Me.Tb_Costo4.Text) <> "" Then
                    Comando.Parameters.AddWithValue("@COSTOSINVESTIGACION", Convert.ToDecimal(Me.Tb_Costo4.Text))
                    Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSINVESTIGACION", Me.Tb_Especificar4.Text)
                End If
                If Trim(Me.Tb_Costo5.Text) <> "" Then
                    Comando.Parameters.AddWithValue("@COSTOSACCIONESCORRECTIVAS", Convert.ToDecimal(Me.Tb_Costo5.Text))
                    Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSACCIONESCORRECTIVAS", Me.Tb_Especificar5.Text)
                End If
                If Trim(Me.Tb_Costo6.Text) <> "" Then
                    Comando.Parameters.AddWithValue("@OTROSCOSTOS", Convert.ToDecimal(Me.Tb_Costo6.Text))
                    Comando.Parameters.AddWithValue("@DESCRIPCIONOTROSCOSTOS", Me.Tb_Especificar6.Text)
                End If
            Else
                If TIPOINCIDENTE = 3 Then
                    Comando.Parameters.AddWithValue("@SUSTANCIA_PROCESO", Me.Tb_SustanciaProceso.Text)
                    Comando.Parameters.AddWithValue("@OBSERVACION", Me.Tb_AfectacionDaño.Text)
                    Comando.Parameters.AddWithValue("@UNIDADAFECTACIONAMBIENTAL", Me.Cb_UnidadSustancia.SelectedValue)
                    If Trim(Me.Tb_CantidadSustancia.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@CANTIDAD", Convert.ToDecimal(Me.Tb_CantidadSustancia.Text))
                    End If
                    Comando.Parameters.AddWithValue("@IDPERSONAINVOLUCRADA", Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue)
                    Comando.Parameters.AddWithValue("@IDCARGOPERSONAINVOLUCRADA", Me.Cb_CargoAfectacionDaños.SelectedValue)
                    Comando.Parameters.AddWithValue("@RESUMENATENCIONPRESTADA", Me.Tb_AtencionPrestadaAfectacionDaños.Text)
                    If Trim(Me.Tb_Costo1.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@COSTOSDAÑOS", Convert.ToDecimal(Me.Tb_Costo1.Text))
                        Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSDAÑOS", Me.Tb_Especificar1.Text)
                    End If
                    If Trim(Me.Tb_Costo2.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@COSTOSPERDIDA", Convert.ToDecimal(Me.Tb_Costo2.Text))
                        Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSPERDIDA", Me.Tb_Especificar2.Text)
                    End If
                    If Trim(Me.Tb_Costo3.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@COSTOSREPARACIONES", Convert.ToDecimal(Me.Tb_Costo3.Text))
                        Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSREPARACIONES", Me.Tb_Especificar3.Text)
                    End If
                    If Trim(Me.Tb_Costo4.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@COSTOSINVESTIGACION", Convert.ToDecimal(Me.Tb_Costo4.Text))
                        Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSINVESTIGACION", Me.Tb_Especificar4.Text)
                    End If
                    If Trim(Me.Tb_Costo5.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@COSTOSACCIONESCORRECTIVAS", Convert.ToDecimal(Me.Tb_Costo5.Text))
                        Comando.Parameters.AddWithValue("@DESCRIPCIONCOSTOSACCIONESCORRECTIVAS", Me.Tb_Especificar5.Text)
                    End If
                    If Trim(Me.Tb_Costo6.Text) <> "" Then
                        Comando.Parameters.AddWithValue("@OTROSCOSTOS", Convert.ToDecimal(Me.Tb_Costo6.Text))
                        Comando.Parameters.AddWithValue("@DESCRIPCIONOTROSCOSTOS", Me.Tb_Especificar6.Text)
                    End If
                End If
            End If
        End If

        Comando.Parameters.AddWithValue("@SEVERIDADPERDIDAPOTENCIAL", Me.Cb_Severidad.SelectedValue)

Dim categoria As String = Tb_CategoriaResultante.Text.Substring(0, 2)
        Comando.Parameters.AddWithValue("@CATEGORIAPERDIDAPOTENCIAL", categoria)

        If categoria = "A4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "G") 'Muy alto
        End If
        If categoria = "A2" Or categoria = "A3" Or categoria = "B3" Or categoria = "B4" Or categoria = "C4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "A") 'Alto
        End If
        If categoria = "A1" Or categoria = "B2" Or categoria = "C2" Or categoria = "C3" Or categoria = "D3" Or categoria = "D4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "I") 'Intermedio
        End If
        If categoria = "B1" Or categoria = "C1" Or categoria = "D2" Or categoria = "E3" Or categoria = "E4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "M") 'Medio
        End If
        If categoria = "D1" Or categoria = "E1" Or categoria = "E2" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "B") 'Bajo
        End If

        Comando.Parameters.AddWithValue("@PEORCONSECUENCIA", Me.Tb_PeorConsecuencia.Text)

        Comando.Parameters.AddWithValue("@SEVERIDADPERDIDAREAL", Me.Cb_SeveridadReal.SelectedValue)
        Dim categoriareal As String = ""

        If Me.Cb_RecurrenciaReal.SelectedValue IsNot Nothing Then
            categoriareal = Tb_CategoriaResultanteReal.Text.Substring(0, 2)
            Comando.Parameters.AddWithValue("@CATEGORIAPERDIDAREAL", categoriareal)
        Else
            categoriareal = ""
        End If

        If categoriareal = "A4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAREAL", "G") 'Muy alto
        End If
        If categoriareal = "A2" Or categoriareal = "A3" Or categoriareal = "B3" Or categoriareal = "B4" Or categoriareal = "C4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAREAL", "A") 'Alto
        End If
        If categoriareal = "A1" Or categoriareal = "B2" Or categoriareal = "C2" Or categoriareal = "C3" Or categoriareal = "D3" Or categoriareal = "D4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAREAL", "I") 'Intermedio
        End If
        If categoriareal = "B1" Or categoriareal = "C1" Or categoriareal = "D2" Or categoriareal = "E3" Or categoriareal = "E4" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAREAL", "M") 'Medio
        End If
        If categoriareal = "D1" Or categoriareal = "E1" Or categoriareal = "E2" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAREAL", "B") 'Bajo
        End If

        If Rb_Pregunta1Si.Checked Then
            Comando.Parameters.AddWithValue("@RESPUESTA10_1_SI_NO", "S")
            Comando.Parameters.AddWithValue("@RESPUESTA10_1", Me.Tb_Pregunta1.Text)
        Else
            If Rb_Pregunta1No.Checked Then
                Comando.Parameters.AddWithValue("@RESPUESTA10_1_SI_NO", "N")
                Comando.Parameters.AddWithValue("@RESPUESTA10_1", Me.Tb_Pregunta1.Text)
            End If
        End If

        If Rb_Pregunta2Si.Checked Then
            Comando.Parameters.AddWithValue("@RESPUESTA10_2_SI_NO", "S")
            Comando.Parameters.AddWithValue("@RESPUESTA10_2", Me.Tb_Pregunta2.Text)
        Else
            If Rb_Pregunta2No.Checked Then
                Comando.Parameters.AddWithValue("@RESPUESTA10_2_SI_NO", "N")
                Comando.Parameters.AddWithValue("@RESPUESTA10_2", DBNull.Value)
            End If
        End If

        Dim entidades As String
        If Me.Ck_ARL.Checked Then
            entidades = "S"
        Else
            entidades = "N"
        End If
        If Me.Ck_EPS.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        If Me.Ck_CAR.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        If Me.Ck_Organismo.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        If Me.Ck_MinisterioTrabajo.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        If Me.Ck_AutoridadAmbiental.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        If Me.Ck_Cliente.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        If Me.Ck_OtraEntidad.Checked Then
            entidades = entidades + "S"
        Else
            entidades = entidades + "N"
        End If
        Comando.Parameters.AddWithValue("@ENTIDADNOTIFICADA", entidades)
        If Me.Ck_OtraEntidad.Checked Then
            Comando.Parameters.AddWithValue("@OTRAENTIDADNOTIFICADA", Me.Tb_OtraEntidad.Text)
        End If

        Comando.Parameters.AddWithValue("@IDPERSONAHSE", Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@OBSERVACIONHSE", Me.Tb_ConceptoHSE.Text)
        If Me.DTP_FechaConceptoHSE.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAOBSERVACIONHSE", Me.DTP_FechaConceptoHSE.Value.Date)
        End If

        Comando.Parameters.AddWithValue("@IDASESORJURIDICO", Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@OBSERVACIONASESORJURIDICO", Me.Tb_ConceptoAsesorJuridico.Text)
        If Me.DTP_FechaConceptoAsesor.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAOBSERVACIONASESORJURIDICO", Me.DTP_FechaConceptoAsesor.Value.Date)
        End If

        Comando.Parameters.AddWithValue("@IDPERSONAAPRUEBA", Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@CARGOPERSONAAPRUEBA", Me.Cb_CargoAprobo.SelectedValue)
        If Me.DTP_FechaAprobacion.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAAPROBACION", Me.DTP_FechaAprobacion.Value.Date)
        End If

        Dim anexos As String
        If Me.Ck_AnexoDibujos.Checked Then
            anexos = "S"
        Else
            anexos = "N"
        End If
        If Me.Ck_AnexoFotos.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        If Me.Ck_AnexoDocumentos.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        If Me.Ck_AnexoReporte24H.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        If Me.Ck_AnexoAlerta.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        If Me.Ck_OtrosAnexos.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        Comando.Parameters.AddWithValue("@ANEXOS", anexos)
        If Me.Ck_OtrosAnexos.Checked Then
            Comando.Parameters.AddWithValue("@OTROSANEXOS", Me.Tb_OtrosAnexos.Text)
        End If

        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)

        Comando.Parameters.AddWithValue("@IMPRESO", "N")

        If dtTestigos.Rows.Count > 0 Then
            Comando.Parameters.AddWithValue("@TestigosSiNo", "S")
            Dim TablaTestigos As New DataTable
            TablaTestigos.Columns.Add("IDREPORTE24H")
            TablaTestigos.Columns.Add("IDREPORTEINVESTIGACION")
            TablaTestigos.Columns.Add("IDPERSONA")
            TablaTestigos.Columns.Add("IDCARGO")
            TablaTestigos.Columns.Add("DESCRIPCION")
            Dim FilaTestigos As DataRow
            For i = 0 To dtTestigos.Rows.Count - 1
                Dim IdPersona
                Dim Cadena_Consulta3 As String = "SELECT IDPERSONA FROM PERSONA WHERE IDENTIFICACION  = '" + Dgv_Testigos.Rows(i).Cells("DGVT_CedulaTestigo").Value + "'"
                Dim Consulta3 As New SqlClient.SqlCommand(Cadena_Consulta3)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta3.Connection = Conexión
                Consulta3.Connection.Open()
                IdPersona = Consulta3.ExecuteScalar()
                Consulta3.Connection.Close()
                FilaTestigos = TablaTestigos.NewRow
                FilaTestigos("IDPERSONA") = IdPersona
                FilaTestigos("IDCARGO") = Dgv_Testigos.Rows(i).Cells("DGVCB_CargoTestigo").Value
                FilaTestigos("DESCRIPCION") = Dgv_Testigos.Rows(i).Cells("DGVTB_DescripcionTestigo").Value
                TablaTestigos.Rows.Add(FilaTestigos)
            Next
            Comando.Parameters.AddWithValue("@TableTestigos", TablaTestigos)
        Else
            Comando.Parameters.AddWithValue("@TestigosSiNo", "N")

        End If

        If dtAccionesATomar.Rows.Count > 0 Then
            Comando.Parameters.AddWithValue("@AccionesSiNo", "S")
            Dim TablaAccionesATomar As New DataTable
            TablaAccionesATomar.Columns.Add("IDREPORTEINVESTIGACION")
            TablaAccionesATomar.Columns.Add("ACCION")
            TablaAccionesATomar.Columns.Add("CARGO")
            TablaAccionesATomar.Columns.Add("PRIORIDAD")
            TablaAccionesATomar.Columns.Add("FECHALIMITE")
            TablaAccionesATomar.Columns("FECHALIMITE").DataType = GetType(DateTime)
            TablaAccionesATomar.Columns.Add("FECHATERMINADO")
            TablaAccionesATomar.Columns("FECHATERMINADO").DataType = GetType(DateTime)
            Dim FilaAcciones As DataRow
            For i = 0 To dtAccionesATomar.Rows.Count - 1
                FilaAcciones = TablaAccionesATomar.NewRow
                FilaAcciones("ACCION") = dtAccionesATomar.Rows(i).Item(1).ToString
                FilaAcciones("CARGO") = dtAccionesATomar.Rows(i).Item(0).ToString
                FilaAcciones("PRIORIDAD") = dtAccionesATomar.Rows(i).Item(2).ToString
                Dim Fechalimite As DateTime
                Fechalimite = Convert.ToDateTime(dtAccionesATomar.Rows(i).Item(3))
                FilaAcciones("FECHALIMITE") = Fechalimite
                Dim Fechaterminado As DateTime
                If dtAccionesATomar.Rows(i).Item(4).ToString <> "" Then
                    Fechaterminado = Convert.ToDateTime(dtAccionesATomar.Rows(i).Item(4))
                    FilaAcciones("FECHATERMINADO") = Fechaterminado
                Else
                    FilaAcciones("FECHATERMINADO") = DBNull.Value
                End If

                TablaAccionesATomar.Rows.Add(FilaAcciones)
            Next
            TablaAccionesATomar.AcceptChanges()
            Comando.Parameters.AddWithValue("@TableAccionesATomar", TablaAccionesATomar)
        Else
            Comando.Parameters.AddWithValue("@AccionesSiNo", "N")
        End If

        Dim TablaEvidencias As New DataTable
        TablaEvidencias.Columns.Add("IDREPORTEINVESTIGACION")
        TablaEvidencias.Columns.Add("IDTIPOEVIDENCIAYCAUSA")
        TablaEvidencias.Columns.Add("NOMBRETIPOEVIDENCIAYCAUSA")
        TablaEvidencias.Columns.Add("DESCRIPCION")

        ELiminarFilaVacia("E")
        ELiminarFilaVacia("CA")
        ELiminarFilaVacia("CC")
        ELiminarFilaVacia("CP")
        ELiminarFilaVacia("CT")

        If dtEvidencias.Rows.Count > 0 Then
            Dim FilaEvidencias As DataRow
            For i = 0 To dtEvidencias.Rows.Count - 1
                FilaEvidencias = TablaEvidencias.NewRow
                FilaEvidencias("IDTIPOEVIDENCIAYCAUSA") = Dgv_Evidencias.Rows(i).Cells("DGVC_TipoEvidencia").Value
                FilaEvidencias("NOMBRETIPOEVIDENCIAYCAUSA") = Dgv_Evidencias.Rows(i).Cells("DGVC_TipoEvidencia").FormattedValue.ToString
                FilaEvidencias("DESCRIPCION") = Dgv_Evidencias.Rows(i).Cells("DGVT_DescripcionEvidencia").Value
                TablaEvidencias.Rows.Add(FilaEvidencias)
            Next
        End If

        If dtCausasInmediatasActos.Rows.Count > 0 Then
            Dim FilaCausasInmediatasActos As DataRow
            For i = 0 To dtCausasInmediatasActos.Rows.Count - 1
                FilaCausasInmediatasActos = TablaEvidencias.NewRow
                FilaCausasInmediatasActos("IDTIPOEVIDENCIAYCAUSA") = Dgv_CausasInmediatasActos.Rows(i).Cells("DGVC_TipoCausaInmediataActos").Value
                FilaCausasInmediatasActos("NOMBRETIPOEVIDENCIAYCAUSA") = Dgv_CausasInmediatasActos.Rows(i).Cells("DGVC_TipoCausaInmediataActos").FormattedValue.ToString
                FilaCausasInmediatasActos("DESCRIPCION") = Dgv_CausasInmediatasActos.Rows(i).Cells("DGVT_DescripcionCausaInmediataActos").Value
                TablaEvidencias.Rows.Add(FilaCausasInmediatasActos)
            Next
        End If

        If dtCausasInmediatasCondiciones.Rows.Count > 0 Then
            Dim FilaCausasInmediatasCondiciones As DataRow
            For i = 0 To dtCausasInmediatasCondiciones.Rows.Count - 1
                FilaCausasInmediatasCondiciones = TablaEvidencias.NewRow
                FilaCausasInmediatasCondiciones("IDTIPOEVIDENCIAYCAUSA") = Dgv_CausasInmediatasCondiciones.Rows(i).Cells("DGVC_TipoCausaInmediataCondiciones").Value
                FilaCausasInmediatasCondiciones("NOMBRETIPOEVIDENCIAYCAUSA") = Dgv_CausasInmediatasCondiciones.Rows(i).Cells("DGVC_TipoCausaInmediataCondiciones").FormattedValue.ToString
                FilaCausasInmediatasCondiciones("DESCRIPCION") = Dgv_CausasInmediatasCondiciones.Rows(i).Cells("DGVT_DescripcionCausaInmediataCondiciones").Value
                TablaEvidencias.Rows.Add(FilaCausasInmediatasCondiciones)
            Next
        End If

        If dtCausasBasicasPersonales.Rows.Count > 0 Then
            Dim FilaCausasBasicasPersonales As DataRow
            For i = 0 To dtCausasBasicasPersonales.Rows.Count - 1
                FilaCausasBasicasPersonales = TablaEvidencias.NewRow
                FilaCausasBasicasPersonales("IDTIPOEVIDENCIAYCAUSA") = Dgv_CausasBasicasPersonales.Rows(i).Cells("DGVC_TipoCausaBasicaPersonales").Value
                FilaCausasBasicasPersonales("NOMBRETIPOEVIDENCIAYCAUSA") = Dgv_CausasBasicasPersonales.Rows(i).Cells("DGVC_TipoCausaBasicaPersonales").FormattedValue.ToString
                FilaCausasBasicasPersonales("DESCRIPCION") = Dgv_CausasBasicasPersonales.Rows(i).Cells("Dgv_DescripcionCausaBasicaPersonales").Value
                TablaEvidencias.Rows.Add(FilaCausasBasicasPersonales)
            Next
        End If

        If dtCausasBasicasTrabajo.Rows.Count > 0 Then
            Dim FilaCausasBasicasTrabajo As DataRow
            For i = 0 To dtCausasBasicasTrabajo.Rows.Count - 1
                FilaCausasBasicasTrabajo = TablaEvidencias.NewRow
                FilaCausasBasicasTrabajo("IDTIPOEVIDENCIAYCAUSA") = Dgv_CausasBasicasTrabajo.Rows(i).Cells("DGVC_TipoCausaBasicaTrabajo").Value
                FilaCausasBasicasTrabajo("NOMBRETIPOEVIDENCIAYCAUSA") = Dgv_CausasBasicasTrabajo.Rows(i).Cells("DGVC_TipoCausaBasicaTrabajo").FormattedValue.ToString
                FilaCausasBasicasTrabajo("DESCRIPCION") = Dgv_CausasBasicasTrabajo.Rows(i).Cells("DGVT_DescripcionCausaBasicaTrabajo").Value
                TablaEvidencias.Rows.Add(FilaCausasBasicasTrabajo)
            Next
        End If

        TablaEvidencias.AcceptChanges()
        If TablaEvidencias.Rows.Count > 0 Then
            Comando.Parameters.AddWithValue("@EvidenciasCausasSiNo", "S")
            Comando.Parameters.AddWithValue("@TableEvidenciasCausas", TablaEvidencias)
        Else
            Comando.Parameters.AddWithValue("@EvidenciasCausasSiNo", "N")
        End If

        If dtInvestigadores.Rows.Count > 0 Then
            Comando.Parameters.AddWithValue("@InvestigadoresSiNo", "S")
            Dim TablaInvestigadores As New DataTable
            TablaInvestigadores.Columns.Add("IDREPORTEINVESTIGACION")
            TablaInvestigadores.Columns.Add("IDPERSONAINVESTIGADOR")
            TablaInvestigadores.Columns.Add("IDROL")
            TablaInvestigadores.Columns.Add("FECHA")
            TablaInvestigadores.Columns("FECHA").DataType = GetType(DateTime)
            Dim FilaInvestigadores As DataRow
            For i = 0 To dtInvestigadores.Rows.Count - 1
                Dim IdPersona
                Dim Cadena_Consulta3 As String = "SELECT IDPERSONA FROM PERSONA WHERE IDENTIFICACION  = '" + Dgv_Investigadores.Rows(i).Cells("DGVT_CedulaInvestigador").Value + "'"
                Dim Consulta3 As New SqlClient.SqlCommand(Cadena_Consulta3)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta3.Connection = Conexión
                Consulta3.Connection.Open()
                IdPersona = Consulta3.ExecuteScalar()
                Consulta3.Connection.Close()
                FilaInvestigadores = TablaInvestigadores.NewRow
                FilaInvestigadores("IDPERSONAINVESTIGADOR") = IdPersona
                FilaInvestigadores("IDROL") = Dgv_Investigadores.Rows(i).Cells("DGVC_RolInvestigador").Value
                FilaInvestigadores("FECHA") = Dgv_Investigadores.Rows(i).Cells("DGVDTP_FechaInvestigador").Value
                TablaInvestigadores.Rows.Add(FilaInvestigadores)
            Next
            Comando.Parameters.AddWithValue("@TableInvestigadores", TablaInvestigadores)
        Else
            Comando.Parameters.AddWithValue("@InvestigadoresSiNo", "N")
        End If

        If dtLineaTiempo.Rows.Count > 0 Then
            Comando.Parameters.AddWithValue("@LineaTiempoSiNo", "S")
            Dim TablaLineaTiempo As New DataTable
            TablaLineaTiempo.Columns.Add("IDREPORTEINVESTIGACION")
            TablaLineaTiempo.Columns.Add("FECHA")
            TablaLineaTiempo.Columns("FECHA").DataType = GetType(DateTime)
            TablaLineaTiempo.Columns.Add("HORA")
            TablaLineaTiempo.Columns("HORA").DataType = GetType(DateTime)
            TablaLineaTiempo.Columns.Add("DESCRIPCION")
            Dim FilaLineaTiempo As DataRow
            For i = 0 To dtLineaTiempo.Rows.Count - 1
                FilaLineaTiempo = TablaLineaTiempo.NewRow
                FilaLineaTiempo("FECHA") = dtLineaTiempo.Rows(i).Item(0).ToString
                FilaLineaTiempo("HORA") = dtLineaTiempo.Rows(i).Item(1).ToString
                FilaLineaTiempo("DESCRIPCION") = dtLineaTiempo.Rows(i).Item(2).ToString
                TablaLineaTiempo.Rows.Add(FilaLineaTiempo)
            Next
            Comando.Parameters.AddWithValue("@TableLineaTiempo", TablaLineaTiempo)
        Else
            Comando.Parameters.AddWithValue("@LineaTiempoSiNo", "N")
        End If


        Dim conexion2 As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        conexion2.Open()
        Comando.Connection = conexion2
        Try
            Comando.ExecuteNonQuery()
            conexion2.Close()
            guardado = True
            GuardarReporteInvestigacion = True
        Catch ex As Exception
            conexion2.Close()
            MsgBox(ex.ToString)
            guardado = False
            GuardarReporteInvestigacion = False
        End Try
    End Function
    Private Sub Fr_CrearInvestigacion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Bt_Guardar.Enabled = True And guardado = False Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If GuardarReporteInvestigacion() = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Rb_Pregunta2No_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Pregunta2No.CheckedChanged
        Lb_Pregunta2.Hide()
        Tb_Pregunta2.Hide()
    End Sub

    Private Sub Rb_Pregunta2Si_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Pregunta2Si.CheckedChanged
        Lb_Pregunta2.Show()
        Tb_Pregunta2.Show()
    End Sub
    Private Sub Ck_OtrosAnexos_CheckedChanged_1(sender As Object, e As EventArgs) Handles Ck_OtrosAnexos.CheckedChanged
        If Ck_OtrosAnexos.Checked = False Then
            Lb_OtrosAnexos.Hide()
            Tb_OtrosAnexos.Hide()
        End If
        If Ck_OtrosAnexos.Checked = True Then
            Lb_OtrosAnexos.Show()
            Tb_OtrosAnexos.Text = ""
            Tb_OtrosAnexos.Show()
        End If
    End Sub

    Private Sub Ck_OtraEntidad_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_OtraEntidad.CheckedChanged
        If Ck_OtraEntidad.Checked = False Then
            Lb_OtraEntidad.Hide()
            Tb_OtraEntidad.Hide()
        End If
        If Ck_OtraEntidad.Checked = True Then
            Lb_OtraEntidad.Show()
            Tb_OtraEntidad.Text = ""
            Tb_OtraEntidad.Show()
        End If
    End Sub

    Private Function AgregarFilas_LineaTiempo()
        If Dgv_LineaTiempo.Rows.Count >= 14 Then
            Dgv_LineaTiempo.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarLineaTiempo_Click(sender As Object, e As EventArgs) Handles Bt_AgregarLineaTiempo.Click
        Dim agregarfila As Boolean = AgregarFilas_LineaTiempo()
        If AgregarFilas_LineaTiempo() Then
            Dim fila As DataRow
            fila = dtLineaTiempo.NewRow
            dtLineaTiempo.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_Acciones()
        If Dgv_AccionesATomar.Rows.Count >= 7 Then
            Dgv_AccionesATomar.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarAccion_Click(sender As Object, e As EventArgs) Handles Bt_AgregarAccion.Click
        If AgregarFilas_Acciones() Then
            Dim fila As DataRow
            fila = dtAccionesATomar.NewRow
            dtAccionesATomar.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_Testigos()
        If Dgv_Testigos.Rows.Count >= 7 Then
            Dgv_Testigos.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarTestigo_Click(sender As Object, e As EventArgs) Handles Bt_AgregarTestigo.Click
        If AgregarFilas_Testigos() Then
            Dim fila As DataRow
            fila = dtTestigos.NewRow
            dtTestigos.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_Investigadores()
        If Dgv_Investigadores.Rows.Count >= 7 Then
            Dgv_Investigadores.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarInvestigacion_Click(sender As Object, e As EventArgs) Handles Bt_AgregarInvestigacion.Click
        If AgregarFilas_Investigadores() Then
            Dim fila As DataRow
            fila = dtInvestigadores.NewRow
            dtInvestigadores.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_CausasActos()
        If Dgv_CausasInmediatasActos.Rows.Count >= 3 Then
            Dgv_CausasInmediatasActos.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarCausaInmediataActos_Click(sender As Object, e As EventArgs) Handles Bt_AgregarCausaInmediataActos.Click
        If AgregarFilas_CausasActos() Then
            Dim fila As DataRow
            fila = dtCausasInmediatasActos.NewRow
            dtCausasInmediatasActos.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_CausasCondiciones()
        If Dgv_CausasInmediatasCondiciones.Rows.Count >= 3 Then
            Dgv_CausasInmediatasCondiciones.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarCausaInmediataCondiciones_Click(sender As Object, e As EventArgs) Handles Bt_AgregarCausaInmediataCondiciones.Click
        If AgregarFilas_CausasCondiciones() Then
            Dim fila As DataRow
            fila = dtCausasInmediatasCondiciones.NewRow
            dtCausasInmediatasCondiciones.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_CausasPersonales()
        If Dgv_CausasBasicasPersonales.Rows.Count >= 3 Then
            Dgv_CausasBasicasPersonales.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarCausaBasicaPersonal_Click(sender As Object, e As EventArgs) Handles Bt_AgregarCausaBasicaPersonal.Click
        If AgregarFilas_CausasPersonales() Then
            Dim fila As DataRow
            fila = dtCausasBasicasPersonales.NewRow
            dtCausasBasicasPersonales.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_CausasTrabajo()
        If Dgv_CausasBasicasTrabajo.Rows.Count >= 3 Then
            Dgv_CausasBasicasTrabajo.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarCausaBasicaTrabajo_Click(sender As Object, e As EventArgs) Handles Bt_AgregarCausaBasicaTrabajo.Click
        If AgregarFilas_CausasTrabajo() Then
            Dim fila As DataRow
            fila = dtCausasBasicasTrabajo.NewRow
            dtCausasBasicasTrabajo.Rows.Add(fila)
        End If
    End Sub
    Private Function AgregarFilas_Evidencias()
        If Dgv_Evidencias.Rows.Count >= 20 Then
            Dgv_Evidencias.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarEvidencia_Click(sender As Object, e As EventArgs) Handles Bt_AgregarEvidencia.Click
        If AgregarFilas_Evidencias() Then
            Dim fila As DataRow
            fila = dtEvidencias.NewRow
            dtEvidencias.Rows.Add(fila)
        End If
    End Sub

    Private Sub Cb_Severidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Severidad.SelectedIndexChanged
        If Cb_Recurrencia.SelectedIndex = -1 Then
            Exit Sub
        End If
        CalcularPerdida()
    End Sub

    Private Sub Cb_Recurrencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Recurrencia.SelectedIndexChanged
        If Cb_Severidad.SelectedIndex = -1 Then
            Exit Sub
        End If
        CalcularPerdida()
    End Sub
Private Sub CalcularPerdida()
        Dim categoria As String
        Dim letratipo As String
        If Me.Cb_Severidad.SelectedValue = 1 Or Me.Cb_Severidad.SelectedValue = 6 Or Me.Cb_Severidad.SelectedValue = 11 Or Me.Cb_Severidad.SelectedValue = 16 Then
            letratipo = "A"
        Else
            If Me.Cb_Severidad.SelectedValue = 2 Or Me.Cb_Severidad.SelectedValue = 7 Or Me.Cb_Severidad.SelectedValue = 12 Or Me.Cb_Severidad.SelectedValue = 17 Then
                letratipo = "B"
            Else
                If Me.Cb_Severidad.SelectedValue = 3 Or Me.Cb_Severidad.SelectedValue = 8 Or Me.Cb_Severidad.SelectedValue = 13 Or Me.Cb_Severidad.SelectedValue = 18 Then
                    letratipo = "C"
                Else
                    If Me.Cb_Severidad.SelectedValue = 4 Or Me.Cb_Severidad.SelectedValue = 9 Or Me.Cb_Severidad.SelectedValue = 14 Or Me.Cb_Severidad.SelectedValue = 19 Then
                        letratipo = "D"
                    Else
                        letratipo = "E"
                    End If
                End If
            End If
        End If
        categoria = letratipo + Me.Cb_Recurrencia.SelectedValue
        Dim nivel As String = ""
        If categoria = "A4" Then
            nivel = "Muy Alto"
        End If
        If categoria = "A2" Or categoria = "A3" Or categoria = "B3" Or categoria = "B4" Or categoria = "C4" Then
            nivel = "Alto"
        End If
        If categoria = "A1" Or categoria = "B2" Or categoria = "C2" Or categoria = "C3" Or categoria = "D3" Or categoria = "D4" Then
            nivel = "Intermedio"
        End If
        If categoria = "B1" Or categoria = "C1" Or categoria = "D2" Or categoria = "E3" Or categoria = "E4" Then
            nivel = "Medio"
        End If
        If categoria = "D1" Or categoria = "E1" Or categoria = "E2" Then
            nivel = "Bajo"
        End If

        Tb_CategoriaResultante.Text = categoria + ", Potencial:" + nivel

    End Sub

    Private Sub Cb_SeveridadReal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_SeveridadReal.SelectedIndexChanged
        If Cb_RecurrenciaReal.SelectedIndex = -1 Then
            Exit Sub
        End If
        CalcularPerdidaReal()
    End Sub

    Private Sub Cb_RecurrenciaReal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_RecurrenciaReal.SelectedIndexChanged
        If Cb_SeveridadReal.SelectedIndex = -1 Then
            Exit Sub
        End If
        CalcularPerdidaReal()
    End Sub

    Private Sub CalcularPerdidaReal()
        Dim categoria As String
        Dim letratipo As String
        If Me.Cb_SeveridadReal.SelectedValue = 1 Or Me.Cb_SeveridadReal.SelectedValue = 6 Or Me.Cb_SeveridadReal.SelectedValue = 11 Or Me.Cb_SeveridadReal.SelectedValue = 16 Then
            letratipo = "A"
        Else
            If Me.Cb_SeveridadReal.SelectedValue = 2 Or Me.Cb_SeveridadReal.SelectedValue = 7 Or Me.Cb_SeveridadReal.SelectedValue = 12 Or Me.Cb_SeveridadReal.SelectedValue = 17 Then
                letratipo = "B"
            Else
                If Me.Cb_SeveridadReal.SelectedValue = 3 Or Me.Cb_SeveridadReal.SelectedValue = 8 Or Me.Cb_SeveridadReal.SelectedValue = 13 Or Me.Cb_SeveridadReal.SelectedValue = 18 Then
                    letratipo = "C"
                Else
                    If Me.Cb_SeveridadReal.SelectedValue = 4 Or Me.Cb_SeveridadReal.SelectedValue = 9 Or Me.Cb_SeveridadReal.SelectedValue = 14 Or Me.Cb_SeveridadReal.SelectedValue = 19 Then
                        letratipo = "D"
                    Else
                        letratipo = "E"
                    End If
                End If
            End If
        End If
        categoria = letratipo + Me.Cb_RecurrenciaReal.SelectedValue.ToString
        Dim nivel As String = ""
        If categoria = "A4" Then
            nivel = "Muy Alto"
        End If
        If categoria = "A2" Or categoria = "A3" Or categoria = "B3" Or categoria = "B4" Or categoria = "C4" Then
            nivel = "Alto"
        End If
        If categoria = "A1" Or categoria = "B2" Or categoria = "C2" Or categoria = "C3" Or categoria = "D3" Or categoria = "D4" Then
            nivel = "Intermedio"
        End If
        If categoria = "B1" Or categoria = "C1" Or categoria = "D2" Or categoria = "E3" Or categoria = "E4" Then
            nivel = "Medio"
        End If
        If categoria = "D1" Or categoria = "E1" Or categoria = "E2" Then
            nivel = "Bajo"
        End If
        Tb_CategoriaResultanteReal.Text = categoria + ", " + nivel
    End Sub

    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1,
                                Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAfectada.CargarDatos()
            Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAfectada.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaReporta.CargarDatos()
            Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaReporta.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarDatos()
            Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaHSE.CargarDatos()
            Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaHSE.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAsesorJuridico.CargarDatos()
            Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAsesorJuridico.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAprobo.CargarDatos()
            Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAprobo.CargarCajaTexto()
        Catch ex As Exception
        End Try
        Try
            temp = Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaMedico.CargarDatos()
            Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaMedico.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaAfectada.Name
                Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaReporta.Name
                Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaInvolucradaAfectacionDaños.Name
                Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaHSE.Name
                Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAsesorJuridico.Name
                Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAprobo.Name
                Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaMedico.Name
                Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaAfectada.Name
                Try
                    filas = Cu_BuscarPersonaAfectada.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAfectada.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaAfectada.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaMedico.Name
                Try
                    filas = Cu_BuscarPersonaMedico.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaMedico.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaMedico.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaMedico.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaReporta.Name
                Try
                    filas = Cu_BuscarPersonaReporta.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaReporta.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaReporta.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaAprobo.Name
                Try
                    filas = Cu_BuscarPersonaAprobo.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAprobo.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAprobo.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaAprobo.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaAsesorJuridico.Name()
                Try
                    filas = Cu_BuscarPersonaAsesorJuridico.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAsesorJuridico.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAsesorJuridico.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaAsesorJuridico.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaHSE.Name()
                Try
                    filas = Cu_BuscarPersonaHSE.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaHSE.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaHSE.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaHSE.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Name()
                Try
                    filas = Cu_BuscarPersonaInvolucradaAfectacionDaños.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaInvolucradaAfectacionDaños.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaInvolucradaAfectacionDaños.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

    Private Sub Dgv_Testigos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Testigos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Testigos
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_Testigos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Testigos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 0
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_Investigadores_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Investigadores.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Investigadores
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_Investigadores(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Investigadores.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 0
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_Acciones_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_AccionesATomar.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Acciones
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_Acciones(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_AccionesATomar.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 1
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles Tb_Costo1.KeyPress, Tb_Costo2.KeyPress, Tb_Costo3.KeyPress, Tb_Costo4.KeyPress, Tb_Costo5.KeyPress, Tb_Costo6.KeyPress, Tb_CantidadSustancia.KeyPress

        If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Caja_Texto_Costos_KeyPress_Enter(sender As Object, e As KeyPressEventArgs) _
    Handles Tb_Costo1.KeyPress, Tb_Costo2.KeyPress, Tb_Costo3.KeyPress, Tb_Costo4.KeyPress, Tb_Costo5.KeyPress, Tb_Costo6.KeyPress
        Dim nombre As String = Me.Name
        nombre = Me.ActiveControl.Name.ToString

        If Convert.ToInt32(e.KeyChar) = Convert.ToInt32(Keys.Enter) Or Convert.ToInt32(e.KeyChar) = Convert.ToInt32(Keys.Tab) Then
            CalcularCostos()
        End If
    End Sub

    Private Sub Caja_Texto_Costos_LostFocus() _
    Handles Tb_Costo1.Leave, Tb_Costo2.Leave, Tb_Costo3.Leave, Tb_Costo4.Leave, Tb_Costo5.Leave, Tb_Costo6.Leave
        CalcularCostos()
    End Sub

    Private Sub CalcularCostos()
        Dim CostoTotal As Double
        CostoTotal = Convert.ToDouble(IIf(Me.Tb_Costo1.Text = "", 0, Me.Tb_Costo1.Text)) + Convert.ToDouble(IIf(Me.Tb_Costo2.Text = "", 0, Me.Tb_Costo2.Text)) + Convert.ToDouble(IIf(Me.Tb_Costo3.Text = "", 0, Me.Tb_Costo3.Text)) + Convert.ToDouble(IIf(Me.Tb_Costo4.Text = "", 0, Me.Tb_Costo4.Text)) + Convert.ToDouble(IIf(Me.Tb_Costo5.Text = "", 0, Me.Tb_Costo5.Text)) + Convert.ToDouble(IIf(Me.Tb_Costo6.Text = "", 0, Me.Tb_Costo6.Text))
        Me.Tb_Costo7.Text = CostoTotal
    End Sub

    Private Sub Num_ExperienciaAños_ValueChanged(sender As Object, e As EventArgs) Handles Num_ExperienciaAños.ValueChanged
        CalcularExperienciaOcupacional()
    End Sub

    Private Sub Num_ExperienciaMeses_ValueChanged(sender As Object, e As EventArgs) Handles Num_ExperienciaMeses.ValueChanged
        CalcularExperienciaOcupacional()
    End Sub

    Private Sub CalcularExperienciaOcupacional()
        Dim años As Integer = Me.Num_ExperienciaAños.Value
        Dim stringaños As String = IIf(años = 1, " Año", " Años")
        Dim meses As Integer = Me.Num_ExperienciaMeses.Value
        Dim stringmeses As String = IIf((meses) = 1, " Mes", " Meses")
        Dim exp As String = años.ToString + stringaños + " " + meses.ToString + stringmeses
        Me.Tb_ExperienciaOcupacional.Text = exp
    End Sub

    Private Sub BorrarFilasdtLineaTiempo(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_LineaTiempo.UserDeletingRow
        dtLineaTiempo.Rows(e.Row.Index).Delete()
        dtLineaTiempo.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtTestigos(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_Testigos.UserDeletingRow
        dtTestigos.Rows(e.Row.Index).Delete()
        dtTestigos.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtAccionesATomar(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_AccionesATomar.UserDeletingRow
        dtAccionesATomar.Rows(e.Row.Index).Delete()
        dtAccionesATomar.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtEvidencias(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_Evidencias.UserDeletingRow
        dtEvidencias.Rows(e.Row.Index).Delete()
        dtEvidencias.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtCausasInmediatasActos(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_CausasInmediatasActos.UserDeletingRow
        dtCausasInmediatasActos.Rows(e.Row.Index).Delete()
        dtCausasInmediatasActos.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtCausasInmediatasCondiciones(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_CausasInmediatasCondiciones.UserDeletingRow
        dtCausasInmediatasCondiciones.Rows(e.Row.Index).Delete()
        dtCausasInmediatasCondiciones.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtCausasBasicasPersonales(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_CausasBasicasPersonales.UserDeletingRow
        dtCausasBasicasPersonales.Rows(e.Row.Index).Delete()
        dtCausasBasicasPersonales.AcceptChanges()
        e.Cancel = True
    End Sub

    Private Sub BorrarFilasdtCausasBasicasTrabajo(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_CausasBasicasTrabajo.UserDeletingRow
        dtCausasBasicasTrabajo.Rows(e.Row.Index).Delete()
        dtCausasBasicasTrabajo.AcceptChanges()
        e.Cancel = True
    End Sub


    Private Sub Cb_Contrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Contrato.SelectedIndexChanged
        If Cb_Contrato.SelectedIndex <> -1 Then
            Try
                Dim dtbasestemp As DataTable
                dtbasestemp = dsCargar.Tables(20)
                dtbasestemp.DefaultView.RowFilter = "IDPROYECTO = " + Cb_Contrato.SelectedValue.ToString
                Cb_Proyecto.DataSource = dtbasestemp
                Cb_Proyecto.DisplayMember = "NOMBREBASE"
                Cb_Proyecto.ValueMember = "IDBASEHSE"
            Catch ex As Exception
            End Try
        End If
    End Sub
    
    Private Sub ELiminarFilaVacia(ByVal tipo As String)
        Try
            Select Case tipo
                Case "E"
                    For i = 0 To Dgv_Evidencias.Rows.Count - 2
                        If IsDBNull(Me.Dgv_Evidencias.Rows(i).Cells("DGVT_DescripcionEvidencia").Value) Then
                            Me.Dgv_Evidencias.Rows.RemoveAt(i)
                        End If
                    Next
                Case "CA"
                    For i = 0 To Dgv_CausasInmediatasActos.Rows.Count - 2
                        If IsDBNull(Me.Dgv_CausasInmediatasActos.Rows(i).Cells("DGVT_DescripcionCausaInmediataActos").Value) Then
                            Me.Dgv_CausasInmediatasActos.Rows.RemoveAt(i)
                        End If
                    Next
                Case "CC"
                    For i = 0 To Dgv_CausasInmediatasCondiciones.Rows.Count - 2
                        If IsDBNull(Me.Dgv_CausasInmediatasCondiciones.Rows(i).Cells("DGVT_DescripcionCausaInmediataCondiciones").Value) Then
                            Me.Dgv_CausasInmediatasCondiciones.Rows.RemoveAt(i)
                        End If
                    Next
                Case "CP"
                    For i = 0 To Dgv_CausasBasicasPersonales.Rows.Count - 2
                        If IsDBNull(Me.Dgv_CausasBasicasPersonales.Rows(i).Cells("Dgv_DescripcionCausaBasicaPersonales").Value) Then
                            Me.Dgv_CausasBasicasPersonales.Rows.RemoveAt(i)
                        End If
                    Next
                Case "CT"
                    For i = 0 To Dgv_CausasBasicasTrabajo.Rows.Count - 2
                        If IsDBNull(Me.Dgv_CausasBasicasTrabajo.Rows(i).Cells("DGVT_DescripcionCausaBasicaTrabajo").Value) Then
                            Me.Dgv_CausasBasicasTrabajo.Rows.RemoveAt(i)
                        End If
                    Next
            End Select
        Catch ex As Exception

        End Try

    End Sub

   Private Sub Cb_TipoConsecuencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoConsecuencia.SelectedIndexChanged
        If Cb_TipoIncidente.SelectedValue IsNot Nothing Then
            If Cb_TipoIncidente.SelectedValue.ToString() = "2" Then
                If Me.Cb_TipoConsecuencia.SelectedValue = 221 Then
                    dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 5)
                Else
                    dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 2)
                End If
                Cb_Severidad.DataSource = dsCargar.Tables(8)
                Cb_Severidad.ValueMember = "IDMATRIZPERDIDA"
                Cb_Severidad.DisplayMember = "NOMBREMATRIZPERDIDA"

                Cb_SeveridadReal.DataSource = dsCargar.Tables(8)
                Cb_SeveridadReal.ValueMember = "IDMATRIZPERDIDA"
                Cb_SeveridadReal.DisplayMember = "NOMBREMATRIZPERDIDA"


                Me.Cb_Severidad.SelectedIndex = -1
                Me.Cb_Recurrencia.SelectedIndex = -1
                Me.Cb_SeveridadReal.SelectedIndex = -1
                Me.Cb_RecurrenciaReal.SelectedIndex = -1
            End If
        End If
    End Sub
End Class
