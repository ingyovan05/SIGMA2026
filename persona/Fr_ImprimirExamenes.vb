Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_ImprimirExamenes
    ''' <summary>
    ''' Tipo de gestión del envío a exámenes.
    ''' </summary>
    Public Enum Accion
        Crear
        Editar
        Ver
        AgregarConcepto
        Reimprimir
    End Enum
    ''' <summary>
    ''' Indica como se gestiona el envío a exámenes.
    ''' </summary>
    Property TipoAccion As Accion
    ''' <summary>
    ''' Identificador del envío a gestionar.
    ''' </summary>
    Property IdEnvioExamen As Integer = -1
    ''' <summary>
    ''' Identificador de la persona del envío a gestionar.
    ''' </summary>
    Property IdPersona As Integer
    ''' <summary>
    ''' Indica si se guardaron los cambios del envío a exámenes.
    ''' </summary>
    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property

    Private _guardado As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dsMaestras As DataSet
    Private dtExamenesImpresion As DataTable
    Private dtMotivoConsulta As DataTable
    Public IdExamen As Integer = -1

    Private Enum Tablas
        Persona = 0
        EnvioExamen = 1
        DetalleEnvioExamen = 2
        Ma_TipoCargo = 3
        Ma_CentroClinico = 4
        Ma_ExamenPreocupacional = 5
    End Enum

    Private Sub Fr_ImprimirExamenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtMotivoConsulta = New DataTable
        dtMotivoConsulta.Columns.Add("CODIGOMOTIVOCONSULTA")
        dtMotivoConsulta.Columns.Add("NOMBREMOTIVOCONSULTA")
        '        dtMotivoConsulta.Rows.Add("0", "") 'Página adicional imaginología.
        '       dtMotivoConsulta.Rows.Add("1", "Valoración Pared y Cavidad Abdominal")
        dtMotivoConsulta.Rows.Add("2", "Exámenes de Ingreso")
        dtMotivoConsulta.Rows.Add("7", "Exámenes de Ingreso Atención Emergencias")
        dtMotivoConsulta.Rows.Add("4", "Examen de Retiro")
        dtMotivoConsulta.Rows.Add("3", "Examen Periódico")
        dtMotivoConsulta.Rows.Add("6", "Examen Post - incapacidad")
        dtMotivoConsulta.Rows.Add("5", "Examen de Reubicación")
        dtMotivoConsulta.Rows.Add("8", "Otro Motivo")

        Cb_MotivoConsulta.ValueMember = "CODIGOMOTIVOCONSULTA"
        Cb_MotivoConsulta.DisplayMember = "NOMBREMOTIVOCONSULTA"
        Cb_MotivoConsulta.DataSource = dtMotivoConsulta

        'Cb_MotivoConsulta.SelectedIndex = -1
        AddHandler Cb_MotivoConsulta.SelectedIndexChanged, AddressOf Cb_MotivoConsulta_SelectedIndexChanged

        CargarDatos()


        If VariablesBase.VariablesBase.IdBaseSiscontrolActual = 0 Then
            Me.Tx_Observaciones.ContextMenuStrip = Cms_Observaciones
        End If

    End Sub


    ''' <summary>
    ''' Llena los controles del formulario con los datos del envío a exámenes.
    ''' </summary>
    Private Sub CargarDatos()
        comando = New SqlCommand("dbo.CargarMaestras", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdBase", SqlDbType.Int)
        comando.Parameters.Add("@Identificador", SqlDbType.BigInt)
        comando.Parameters.Add("@Tipo", SqlDbType.TinyInt)
        comando.Parameters("@Accion").Value = 6
        comando.Parameters("@IdBase").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        Select Case TipoAccion
            Case Accion.Crear
                comando.Parameters("@Identificador").Value = IdPersona
                comando.Parameters("@Tipo").Value = 1
            Case Else
                comando.Parameters("@Identificador").Value = IdEnvioExamen
                comando.Parameters("@Tipo").Value = 2
        End Select
        adaptador = New SqlDataAdapter(comando)
        dsMaestras = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaestras)
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos del envío a exámenes." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try


        Dgv_Examenes.DataSource = dsMaestras.Tables(Tablas.Ma_ExamenPreocupacional)

        Cb_CentroClinico.DataSource = dsMaestras.Tables(Tablas.Ma_CentroClinico)
        Cb_CentroClinico.SelectedIndex = -1

        Cb_TipoCargo.DataSource = dsMaestras.Tables(Tablas.Ma_TipoCargo)
        Cb_TipoCargo.SelectedIndex = -1

        Lb_Nombre.Text = dsMaestras.Tables(Tablas.Persona).Rows(0).Item("NOMBRE")
        Lb_Identificacion.Text = dsMaestras.Tables(Tablas.Persona).Rows(0).Item("IDENTIFICACION")

        If Not IsDBNull(dsMaestras.Tables(Tablas.Persona).Rows(0).Item("EDAD")) Then
            Tx_Edad.Text = dsMaestras.Tables(Tablas.Persona).Rows(0).Item("EDAD")
        End If

        If Not IsDBNull(dsMaestras.Tables(Tablas.Persona).Rows(0).Item("PESO")) Then
            Tx_Peso.Text = dsMaestras.Tables(Tablas.Persona).Rows(0).Item("PESO")
        End If

        Select Case TipoAccion
            Case Accion.Crear
                DesmarcarExamenes()
                Me.Pn_ConceptoMedico.Enabled = False
                Dtp_FechaEnvio.MinDate = Date.Today

           
                Me.Cu_CentroCostoExamenes.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
                Me.Cu_CentroCostoExamenes.Editando = 2
                Me.Cu_CentroCostoExamenes.CargarCentro()
          


            Case Else
                Lb_TituloExamenes.Text = "CONSECUTIVO ENVÍO: " & dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("IDENVIOEXAMEN")
                Cb_TipoCargo.SelectedValue = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CODIGOTIPOCARGO")
                Cb_CentroClinico.SelectedValue = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CODIGOCENTROCLINICO")
                Dtp_FechaEnvio.Value = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("FECHAENVIO")
                Cb_MotivoConsulta.SelectedValue = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CODIGOMOTIVOCONSULTA")
                Me.Ck_Alturas.Checked = False
                Me.Ck_EspaciosConfinados.Checked = False
                Me.Ck_Inmersiones.Checked = False
                If Not IsDBNull(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("TAREACRITICA")) Then
                    If Mid(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("TAREACRITICA"), 1, 1) = "S" Then
                        Me.Ck_Alturas.Checked = True
                    End If
                    If Mid(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("TAREACRITICA"), 2, 1) = "S" Then
                        Me.Ck_EspaciosConfinados.Checked = True
                    End If
                    If Mid(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("TAREACRITICA"), 3, 1) = "S" Then
                        Me.Ck_Inmersiones.Checked = True
                    End If
                End If
                If Not IsDBNull(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("OBSERVACIONES")) Then
                    Tx_Observaciones.Text = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("OBSERVACIONES")
                End If
                'Marcar los exámenes perteneciente al envio
                If dsMaestras.Tables(Tablas.DetalleEnvioExamen).Rows.Count > 0 Then
                    DesmarcarExamenes()
                    MarcarExamenes(dsMaestras.Tables(Tablas.DetalleEnvioExamen))
                End If
                If dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CONCEPTOMEDICO") = "S" Then

                End If
                Tx_ConceptoMedico.Text = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CONCEPTOMEDICO")
                If IsDBNull(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CONTINUAPROCESO")) = False Then
                    If dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CONTINUAPROCESO") = "S" Then
                        Rb_ConceptoSi.Checked = True
                        Dtp_FechaConcepto.Value = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("FECHACONCEPTOMEDICO")
                    Else
                        If dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("CONTINUAPROCESO") = "N" Then
                            Rb_ConceptoNo.Checked = True
                            Dtp_FechaConcepto.Value = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("FECHACONCEPTOMEDICO")
                        End If
                    End If
                End If
                Me.Dgv_Examenes.ReadOnly = True

                If IsDBNull(dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("IDCENTROCOSTO")) Then
                    Me.Cu_CentroCostoExamenes.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
                    Me.Cu_CentroCostoExamenes.Editando = 3
                    Me.Cu_CentroCostoExamenes.CargarCentro()
                Else
                    Me.Cu_CentroCostoExamenes.IdCentroCosto = dsMaestras.Tables(Tablas.EnvioExamen).Rows(0).Item("IDCENTROCOSTO")
                    Me.Cu_CentroCostoExamenes.Editando = 3
                    Me.Cu_CentroCostoExamenes.CargarCentro()
                End If


        End Select

        Select Case TipoAccion
            Case Accion.Ver
                DeshabilitarControles()
                Me.Pn_ConceptoMedico.Enabled = False
            Case Accion.AgregarConcepto
                DeshabilitarControles()
                HabilitarControlesConceptoMedico()
            Case Accion.Reimprimir
                DeshabilitarControles()
                Me.Pn_ConceptoMedico.Enabled = False
                Me.Bt_Imprimir.Visible = True
                Me.Bt_Imprimir.Enabled = True
            Case Accion.Editar
                HabilitarControles()
                Me.Dgv_Examenes.ReadOnly = False
                Me.Pn_ConceptoMedico.Enabled = False
                Me.Bt_Imprimir.Visible = True
                Me.Bt_Imprimir.Enabled = True
        End Select

    End Sub

    ''' <summary>
    ''' Deshabilita todo los controles del formulario.
    ''' </summary>
    Private Sub DeshabilitarControles()
        Cb_MotivoConsulta.Enabled = False
        Cb_TipoCargo.Enabled = False
        Cb_CentroClinico.Enabled = False
        Dtp_FechaEnvio.Enabled = False
        Tx_Observaciones.Enabled = False
        Ck_ImprFormatoDatosPersonal.Enabled = False
        Ck_ImprListadoDocumentos.Enabled = False
        Ck_ImprConsentimientoInformado.Enabled = False
        Ck_ImprTratamientoDatos.Enabled = False
        Ck_ImprPensionYSalud.Enabled = False
        Bt_Imprimir.Enabled = False
        Bt_Imprimir.Visible = False
        Me.Ck_Alturas.Enabled = False
        Me.Ck_EspaciosConfinados.Enabled = False
        Me.Ck_Inmersiones.Enabled = False
        Me.Cu_CentroCostoExamenes.Enabled = False
    End Sub


    Private Sub HabilitarControles()
        Cb_MotivoConsulta.Enabled = True
        Cb_TipoCargo.Enabled = True
        Cb_CentroClinico.Enabled = True
        Dtp_FechaEnvio.Enabled = True
        Tx_Observaciones.Enabled = True
        Ck_ImprFormatoDatosPersonal.Enabled = True
        Ck_ImprListadoDocumentos.Enabled = True
        Ck_ImprConsentimientoInformado.Enabled = True
        Ck_ImprTratamientoDatos.Enabled = True
        Ck_ImprPensionYSalud.Enabled = True
        Bt_Imprimir.Enabled = True
        Bt_Imprimir.Visible = True
        Me.Ck_Alturas.Enabled = True
        Me.Ck_EspaciosConfinados.Enabled = True
        Me.Ck_Inmersiones.Enabled = True
        Me.Cu_CentroCostoExamenes.Enabled = True
    End Sub

    ''' <summary>
    ''' Habilita los controles de registro de concepto médico y deshabilita los demás controles de ingreso de datos en el formulario.
    ''' </summary>
    Private Sub HabilitarControlesConceptoMedico()
        Me.Pn_ConceptoMedico.Enabled = True
        Bt_Imprimir.Text = "Guardar"
        Bt_Imprimir.Visible = True
        Bt_Imprimir.Enabled = True
        Dim FechaMinimo As New DateTime(Me.Dtp_FechaEnvio.Value.Year, Me.Dtp_FechaEnvio.Value.Month, Me.Dtp_FechaEnvio.Value.Day, 0, 0, 1)
        Me.Dtp_FechaConcepto.MinDate = FechaMinimo
        Me.Dtp_FechaConcepto.MaxDate = Date.Now
    End Sub

    ''' <summary>
    ''' Selecciona en la rejilla de exámenes las filas indicadas.
    ''' </summary>
    ''' <param name="dtExam">Tabla con los exámenes a marcar.</param>
    Private Sub MarcarExamenes(dtExam As DataTable)
        For i As Integer = 0 To Dgv_Examenes.Rows.Count - 1
            For j As Integer = 0 To dtExam.Rows.Count - 1
                If Dgv_Examenes.Rows(i).Cells(Col_CodExamen.Name).Value = dtExam.Rows(j).Item(Col_CodExamen.DataPropertyName) Then
                    Dgv_Examenes.Rows(i).Cells(Col_Practicar.Name).Value = "S"
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' Retira todas las marcas en la rejilla de exámenes.
    ''' </summary>
    Private Sub DesmarcarExamenes()
        For i As Integer = 0 To Dgv_Examenes.Rows.Count - 1
            Dgv_Examenes.Rows(i).Cells(Col_Practicar.Name).Value = "N"
        Next
    End Sub

    Private Sub Cb_TipoCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoCargo.SelectedIndexChanged
        If Not IsNothing(Cb_TipoCargo.SelectedValue) Then
            If Cb_MotivoConsulta.SelectedValue = 1 Then
                CargarExamenes(Cb_TipoCargo.SelectedValue)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Consulta los exámenes asignados al cargo en la matriz de exámenes.
    ''' </summary>
    ''' <param name="codigoTipoCargo">Cargo a buscar en la matriz de exámenes.</param>
    Private Sub CargarExamenes(codigoTipoCargo As Integer)
        comando = New SqlCommand("SELECT * FROM dbo.ListaExamenesPreocupacionales(@CODIGOTIPOCARGO)", conexion)
        comando.Parameters.AddWithValue("@CODIGOTIPOCARGO", codigoTipoCargo)
        adaptador = New SqlDataAdapter(comando)
        Dim dtExamenes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtExamenes)
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos de exámenes." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
        If dtExamenes.Rows.Count > 0 Then
            MarcarExamenes(dtExamenes)
        Else
            DesmarcarExamenes()
        End If
    End Sub

    Private Sub Cb_MotivoConsulta_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not IsNothing(Cb_MotivoConsulta.SelectedValue) Then
            Select Case Cb_MotivoConsulta.SelectedValue
                Case 0
                    If Dgv_Examenes.Enabled Then
                        AlmacenarExamenesEnMemoria()
                        DesmarcarExamenes()
                    End If
                Case 1
                    If Not Dgv_Examenes.Enabled AndAlso Not IsNothing(dtExamenesImpresion) Then
                        MarcarExamenes(dtExamenesImpresion)
                    End If
                Case 2, 3, 4, 5, 6
                    If Dgv_Examenes.Enabled Then
                        AlmacenarExamenesEnMemoria()
                        DesmarcarExamenes()
                    End If
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Guarda los códigos de exámenes seleccionados en la rejilla de exámenes dentro de una tabla temporal.
    ''' </summary>
    Private Sub AlmacenarExamenesEnMemoria()
        dtExamenesImpresion = New DataTable
        dtExamenesImpresion.Columns.Add(Col_CodExamen.DataPropertyName)
        For Each r As DataGridViewRow In Dgv_Examenes.Rows
            If r.Cells(Col_Practicar.Name).Value = "S" Then
                dtExamenesImpresion.Rows.Add(r.Cells(Col_CodExamen.Name).Value)
            End If
        Next
    End Sub

    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click
        Select Case TipoAccion
            Case Accion.Crear, Accion.Editar, Accion.Reimprimir
                If Validar() Then
                    GuardarEnvio()
                    Imprimir()
                    'If MessageBox.Show("¿Desea continuar con la impresión de páginas adicionales del formato de exámenes?", "Impresión de páginas adicionales", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    'Cb_CentroClinico.SelectedIndex = -1
                    'DesmarcarExamenes()
                    'Else
                    Close()
                End If
                'End If
            Case Accion.AgregarConcepto
                If ValidarConcepto() = True Then
                    GuardarEnvio()
                    Close()
                End If
        End Select

    End Sub

    Private Function ValidarConcepto()
        If Trim(Me.Tx_ConceptoMedico.Text = "") Then
            MsgBox("Debe Seleccionar el Concepto Médico para continuar", MsgBoxStyle.Critical, "Concepto Médico")
            ValidarConcepto = False
            Exit Function
        End If

        If Rb_ConceptoNo.Checked = False And Rb_ConceptoSi.Checked = False Then
            MsgBox("Debe Seleccionar si es Apto para continuar en el proceso o no", MsgBoxStyle.Critical, "Concepto Médico")
            ValidarConcepto = False
            Exit Function
        End If

        If Dtp_FechaConcepto.Checked = False Then
            MsgBox("Debe Seleccionar la Fecha en la cual fue emitido el Concepto Médico", MsgBoxStyle.Critical, "Concepto Médico")
            ValidarConcepto = False
            Exit Function
        End If

        ValidarConcepto = True

    End Function


    ''' <summary>
    ''' Valida los datos del envío a exámenes.
    ''' </summary>
    ''' <returns></returns>
    Private Function Validar()
        If Cb_MotivoConsulta.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el motivo de envío a exámenes.", "Motivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cb_MotivoConsulta.Select()
            Return False
        End If
        If Cb_TipoCargo.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el cargo.", "Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cb_TipoCargo.Select()
            Return False
        End If

        If Cb_CentroClinico.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione la IPS / CRC - CEA donde se practicaran los exámenes seleccionados.", "Centro Clinico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cb_CentroClinico.Select()
            Return False
        End If

        If Cu_CentroCostoExamenes.IdCentroCosto <= 0 Then
            MessageBox.Show("Debe seleccionar el centro de costo de la base", "CENTRO DE COSTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Dim Filas() As DataRow
        'validar que no seleccionen mas de 15 exámenes Laboratorio, Paraclinicos u Otros

        dsMaestras.Tables(Tablas.Ma_ExamenPreocupacional).AcceptChanges()

        Filas = dsMaestras.Tables(Tablas.Ma_ExamenPreocupacional).Select("(TIPO='LAB' or TIPO='PAR' or TIPO='OTR') and PRACTICAR='S'")
        If Filas.Length > 10 Then
            MsgBox("No se puede seleccionar más de 10 exámenes de tipo Laboratorio, Paraclínicos u otros.", MsgBoxStyle.Exclamation, "Envío Exámenes")
            Return False
        End If

        'validar que no selecciones mas de uno de columna
        Filas = dsMaestras.Tables(Tablas.Ma_ExamenPreocupacional).Select("TIPO='CLU' and PRACTICAR='S'")
        If Filas.Length > 1 Then
            MsgBox("No se puede seleccionar más de un tipo de examen de Columna Lumbar, por favor revise.", MsgBoxStyle.Exclamation, "Envío Exámenes")
            Return False
        End If

        'validar que se envie al menos un examen

        Filas = dsMaestras.Tables(Tablas.Ma_ExamenPreocupacional).Select("PRACTICAR='S'")
        If Filas.Length = 0 Then
            MsgBox("Debe seleccionar al menos un examen, por favor revise.", MsgBoxStyle.Exclamation, "Envío Exámenes")
            Return False
        End If
        If Cu_CentroCostoExamenes.IdCentroCosto <= 0 Then
            MessageBox.Show("Debe seleccionar el centro de costo de la base", "CENTRO DE COSTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If


        Return True
    End Function


    Dim TAREACRITICA As String
    ''' <summary>
    ''' Guarda el nuevo envío o los cambios realizados en el envío a exámenes.
    ''' </summary>
    Private Sub GuardarEnvio()
        AlmacenarExamenesEnMemoria()
        comando = New SqlCommand("dbo.GestionarEnvioExamenes", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
        comando.Parameters.Add("@IDBASE", SqlDbType.Int)
        comando.Parameters.Add("@CODIGOTIPOCARGO", SqlDbType.Int)
        comando.Parameters.Add("@CODIGOCENTROCLINICO", SqlDbType.Int)
        comando.Parameters.Add("@CODIGOMOTIVOCONSULTA", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDENVIOEXAMEN", SqlDbType.BigInt)
        comando.Parameters.Add("@DETALLEENVIOEXAMEN", SqlDbType.Structured)
        comando.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar, 200)
        comando.Parameters.Add("@FECHAENVIO", SqlDbType.Date)
        comando.Parameters.Add("@CONCEPTOMEDICO", SqlDbType.NVarChar, 200)
        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)
        comando.Parameters.Add("@TAREACRITICA", SqlDbType.NVarChar, 3)
        comando.Parameters.Add("@CONTINUAPROCESO", SqlDbType.NVarChar, 1)
        comando.Parameters.Add("@IDCENTROCOSTO", SqlDbType.Int)

        Select Case TipoAccion
            Case Accion.Crear
                comando.Parameters("@ACCION").Value = 1
                comando.Parameters("@IDENVIOEXAMEN").Value = DBNull.Value
                comando.Parameters("@FECHAENVIO").Value = Dtp_FechaEnvio.Value
                comando.Parameters("@CONCEPTOMEDICO").Value = DBNull.Value
                comando.Parameters("@CONTINUAPROCESO").Value = DBNull.Value

            Case Accion.Editar, Accion.Reimprimir
                comando.Parameters("@ACCION").Value = 2
                comando.Parameters("@IDENVIOEXAMEN").Value = IdEnvioExamen
                'comando.Parameters("@FECHAENVIO").Value = DBNull.Value     --- Ajuste para reimprimir envio de examenes
                comando.Parameters("@CONCEPTOMEDICO").Value = DBNull.Value
                comando.Parameters("@CONTINUAPROCESO").Value = DBNull.Value

            Case Accion.AgregarConcepto
                comando.Parameters("@ACCION").Value = 3
                comando.Parameters("@IDENVIOEXAMEN").Value = IdEnvioExamen
                comando.Parameters("@FECHAENVIO").Value = Me.Dtp_FechaConcepto.Value
                comando.Parameters("@CONCEPTOMEDICO").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_ConceptoMedico.Text)
                If Rb_ConceptoSi.Checked = True Then
                    comando.Parameters("@CONTINUAPROCESO").Value = "S"
                Else
                    comando.Parameters("@CONTINUAPROCESO").Value = "N"
                End If
        End Select


        If Ck_Alturas.Checked = True Then
            TAREACRITICA = "S"
        Else
            TAREACRITICA = "N"
        End If
        If Ck_EspaciosConfinados.Checked = True Then
            TAREACRITICA = TAREACRITICA & "S"
        Else
            TAREACRITICA = TAREACRITICA & "N"
        End If
        If Ck_Inmersiones.Checked = True Then
            TAREACRITICA = TAREACRITICA & "S"
        Else
            TAREACRITICA = TAREACRITICA & "N"
        End If
        comando.Parameters("@TAREACRITICA").Value = TAREACRITICA
        comando.Parameters("@IDPERSONA").Value = IdPersona
        comando.Parameters("@IDBASE").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        comando.Parameters("@CODIGOTIPOCARGO").Value = Cb_TipoCargo.SelectedValue
        If Cb_CentroClinico.SelectedIndex = -1 Then
            comando.Parameters("@CODIGOCENTROCLINICO").Value = DBNull.Value
        Else
            comando.Parameters("@CODIGOCENTROCLINICO").Value = Cb_CentroClinico.SelectedValue
        End If
        comando.Parameters("@CODIGOMOTIVOCONSULTA").Value = Cb_MotivoConsulta.SelectedValue
        comando.Parameters("@DETALLEENVIOEXAMEN").Value = dtExamenesImpresion
        comando.Parameters("@OBSERVACIONES").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Observaciones.Text)
        comando.Parameters("@IDCENTROCOSTO").Value = Cu_CentroCostoExamenes.IdCentroCosto
        Select Case TipoAccion

            Case Accion.Reimprimir
                comando.Parameters("@FECHAENVIO").Value = Dtp_FechaEnvio.Value

        End Select
        'comando.Parameters("@FECHAENVIO").Value = Dtp_FechaEnvio.Value
        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.BigInt, 1)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)

        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            IdExamen = msgParam.Value
            _guardado = True
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta la impresión del formato de autorización de exámenes y los formatos adicionales seleccionados.
    ''' </summary>
    Private Sub Imprimir()
        Dim imprimir As New ImprimirRecursoHumano.Cl_Impresión
        Dim arrayDocs As New ArrayList
        imprimir.IdExamen = IdExamen
        imprimir.Idpersona = IdPersona
        imprimir.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        imprimir.NombreCargoPropuesto = Cb_TipoCargo.Text
        imprimir.CodigoMotivoConsultaExamenes = Cb_MotivoConsulta.SelectedValue
        imprimir.TareasCriticas = TAREACRITICA
        imprimir.Centrocostoexamen = Cu_CentroCostoExamenes.Ll_CentroCostos.Text


        'imprimir.IdExamen = 
        If Cb_CentroClinico.SelectedIndex <> -1 Then
            imprimir.FilaCentroClinico = dsMaestras.Tables(Tablas.Ma_CentroClinico).Select("CODIGOCENTROCLINICO = " & Cb_CentroClinico.SelectedValue)(0)
        End If
        imprimir.FechaEnvio = Dtp_FechaEnvio.Value
        imprimir.ObservacionesEE = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Observaciones.Text)

        imprimir.dtExamenesPreocupacionales = dsMaestras.Tables(Tablas.Ma_ExamenPreocupacional)


        If Ck_ImprFormatoDatosPersonal.Checked Then
            arrayDocs.Add(4) 'ImprimirRecursoHumano.Cl_Persona
        End If
        If Ck_ImprListadoDocumentos.Checked Then
            arrayDocs.Add(2) 'ImprimirRecursoHumano.Cl_Persona
        End If
        If Ck_ImprConsentimientoInformado.Checked Then
            arrayDocs.Add(58) 'ImprimirRecursoHumano.Cl_Constancias
        End If
        If Ck_ImprTratamientoDatos.Checked Then
            arrayDocs.Add(39)
        End If
        If Ck_ImprPensionYSalud.Checked Then
            arrayDocs.Add(7)
        End If

        arrayDocs.Add(85)

        imprimir.FormatosImprimir(arrayDocs, True, False)
        If imprimir.ImpresionFinalizada Then
            MessageBox.Show("Impresión finalizada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        If TipoAccion = Accion.Ver Then
            Close()
        Else
            If MessageBox.Show("¿Desea salir sin guardar los cambios?", "Descartar cambios", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub TSMI_Observación_Click(sender As Object, e As EventArgs) Handles Tsmi_PARAFACTURARAISMOCOLGENERAL.Click, _
                        Tsmi_PARAFACTURARAISMOCOLLOOP1.Click, Tsmi_PARAFACTURARAISMOCOLLOOP2.Click, Tsmi_PARAFACTURARAISMOCOLLOOP3.Click
        Tx_Observaciones.Text = DirectCast(sender, ToolStripMenuItem).Text
    End Sub

    Private Sub Tsmi_TipoConcepto_Click(sender As Object, e As EventArgs) Handles Tsmi_1.Click, Tsmi_2.Click, Tsmi_3.Click, Tsmi_4.Click, Tsmi_5.Click, Tsmi_6.Click
        Tx_ConceptoMedico.Text = DirectCast(sender, ToolStripMenuItem).ToolTipText
    End Sub


    Friend WithEvents Tsmi_1 As New System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_2 As New System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_5 As New System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_6 As New System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_3 As New System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsmi_4 As New System.Windows.Forms.ToolStripMenuItem

    Private Sub Rb_ConceptoSi_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_ConceptoSi.CheckedChanged
        If Rb_ConceptoSi.Checked = True Then

            Me.Cms_ConceptoMedico.Items.Clear()

            Tsmi_1.Name = "Tsmi_1"
            Tsmi_1.Size = New System.Drawing.Size(309, 24)
            Tsmi_1.Text = "1 - Apto para el cargo"
            Tsmi_1.ToolTipText = "Apto para el cargo."

            Tsmi_2.Name = "Tsmi_2"
            Tsmi_2.Size = New System.Drawing.Size(309, 24)
            Tsmi_2.Text = "2 - Apto con carta preexistencias"
            Tsmi_2.ToolTipText = "Apto con carta preexistencias."


            Me.Cms_ConceptoMedico.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Tsmi_1, Tsmi_2})
        End If
    End Sub

    Private Sub Rb_ConceptoNo_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_ConceptoNo.CheckedChanged
        If Rb_ConceptoNo.Checked = True Then

            Me.Cms_ConceptoMedico.Items.Clear()

            Tsmi_5.Name = "Tsmi_1"
            Tsmi_5.Size = New System.Drawing.Size(309, 24)
            Tsmi_5.Text = "1 - No recomendado para el cargo"
            Tsmi_5.ToolTipText = "No recomendado para el cargo"

            Tsmi_6.Name = "Tsmi_2"
            Tsmi_6.Size = New System.Drawing.Size(309, 24)
            Tsmi_6.Text = "2 - Suspender el proceso (Examen realizado)"
            Tsmi_6.ToolTipText = "Suspender el proceso (Examen realizado)"

            Tsmi_3.Name = "Tsmi_3"
            Tsmi_3.Size = New System.Drawing.Size(309, 24)
            Tsmi_3.Text = "3 - Desistió del proceso (Examen realizado)"
            Tsmi_3.ToolTipText = "Desistió del proceso (Examen realizado)"

            Tsmi_4.Name = "Tsmi_4"
            Tsmi_4.Size = New System.Drawing.Size(309, 24)
            Tsmi_4.Text = "4 - Examen no realizado"
            Tsmi_4.ToolTipText = "Examen no realizado"

            Me.Cms_ConceptoMedico.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Tsmi_5, Tsmi_6, Tsmi_3, Tsmi_4})
        End If
    End Sub
    Private Sub Cb_MotivoConsulta_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Cb_MotivoConsulta.SelectedIndexChanged
        If Me.Cb_MotivoConsulta.SelectedValue = 4 Then
            Me.Ck_Alturas.Enabled = False
            Me.Ck_EspaciosConfinados.Enabled = False
            Me.Ck_Inmersiones.Enabled = False
            Me.Ck_Alturas.Checked = False
            Me.Ck_EspaciosConfinados.Checked = False
            Me.Ck_Inmersiones.Checked = False
        Else
            Me.Ck_Alturas.Enabled = True
            Me.Ck_EspaciosConfinados.Enabled = True
            Me.Ck_Inmersiones.Enabled = True

        End If
    End Sub
End Class