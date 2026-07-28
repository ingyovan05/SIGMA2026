Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Globalization

Public Class Fr_Contratar
    ''' <summary>Identificador de la persona a contratar.</summary>
    Property IdPersonaContratar As Integer
    ''' <summary>Identificador del contrato a gestionar.</summary>
    Property IdContrato_Modificar As Int64 = -1

    ''' <summary>Tipo de acción: "I": insertar, "E": editar, "T": terminar, "V": ver.</summary>
    Property TipoAccion As String = "I"
    ''' <summary>Indica si el contrato fue guardado.</summary>
    ''' <value>Se asigna cuando se guardan los cambios.</value>
    ''' <returns>Verdadero si el contrato fue guardado. Falso si no se guardaron cambios.</returns>
    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property
    Public Cu_padre As Object
    Private _guardado As Boolean = False
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private FilaContrato As DataRow
    Private dtConceptosContrato As DataTable
    Private dtProrrogas As DataTable
    Private dtCargos As New DataTable
    Private decimales As String = Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
    Private miles As String = Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator
    Private dsCargar As Object
    Private dtTipoDuracion As New DataTable
    Private dtTipoPago As New DataTable
    Private dtPeriodoPago As New DataTable
    Private dtTipoCuenta As New DataTable
    Private dtTipoSalario As New DataTable
    Private idConceptoDefecto As Integer

    Private Enum TipoContrato
        ICAGRALF117 = 1     'Término fijo de dirección, confianza y manejo
        ICAGRALF122 = 2     'Término fijo de dirección, confianza y manejo (convencional)
        ICAGRALF121 = 3     'Término fijo de dirección, confianza y manejo con salario integral
        ICAGRALF118 = 4     'Término fijo que no son de dirección, confianza y manejo
        ICAGRALF123 = 5     'Término fijo que no son de dirección, confianza y manejo (convencional)
        ICAGRALF119 = 6     'Por obra o labor de dirección, confianza y manejo
        ICAGRALF124 = 7     'Por obra o labor de dirección, confianza y manejo (convencional)
        ObraEsDCMSI = 8     'Por obra o labor de dirección, confianza y manejo con salario integral
        ICAGRALF120 = 9     'Por obra o labor que no son de dirección, confianza y manejo
        ICAGRALF125 = 10    'Por obra o labor que no son de dirección, confianza y manejo (convencional)
        TIEsDCM = 11        'Término indefinido de dirección, confianza y manejo
        TIEsDCMSI = 12      'Término indefinido de dirección, confianza y manejo con salario integral
        ICAGRALF182 = 13     'Término indefinido que no son  dirección, confianza y manejo con salario integral        ' Se agrega el contrato F182
    End Enum
    Private listaContratosTermFijo() As TipoContrato = {TipoContrato.ICAGRALF117, TipoContrato.ICAGRALF122, TipoContrato.ICAGRALF121, TipoContrato.ICAGRALF118, TipoContrato.ICAGRALF123}
    Private listaContratosObraLabor() As TipoContrato = {TipoContrato.ICAGRALF119, TipoContrato.ICAGRALF124, TipoContrato.ObraEsDCMSI, TipoContrato.ICAGRALF120, TipoContrato.ICAGRALF125}
    Private listaContratosTermIndef() As TipoContrato = {TipoContrato.TIEsDCM, TipoContrato.TIEsDCMSI, TipoContrato.ICAGRALF182}   ' se agrega el F-182

    Private Sub Fr_Contratar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    'Instrucciones a ejecutar cuando ya se ha cargado el formulario y se muestra en pantalla.
    Private Sub Fr_Contratar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Ck_Cotizado50Semanas.CheckStateChanged, AddressOf Ck_Cotizado50Semanas_CheckStateChanged
        AddHandler Cb_TipoContrato.SelectedIndexChanged, AddressOf ComboBox_TipoContrato_SelectedIndexChanged
    End Sub

    ''' <summary>Cargar los datos de contratación de las tablas maestras.</summary>
    Public Sub Cargar_Tablas()
        '-- 0 --> CONTRATO
        '-- 1 --> CONTRATO_CONCEPTO
        '-- 2 --> CONTRATO_PRORROGA
        '-- 3 --> MA_TIPOCONTRATO
        '-- 4 --> MA_TIPOCARGO
        '-- 5 --> MA_TIPOCATEGORIA
        '-- 6 --> MA_TIPOGRUPO
        '-- 7 --> MA_TIPOROLBASE
        '-- 8 --> MA_TIPOTURNO
        '-- 9 --> MA_TIPOENTIDADFINANCIERA
        '-- 10 --> MA_TIPOENTIDADADMINISTRADORA_EPS
        '-- 11 --> MA_TIPOENTIDADADMINISTRADORA_ARL
        '-- 12 --> MA_TIPOENTIDADADMINISTRADORA_AFP
        '-- 13 --> MA_TIPOENTIDADADMINISTRADORA_AFC
        '-- 14 --> MA_TIPOENTIDADADMINISTRADORA_CCF
        '-- 15 --> MA_TIPOENTIDADADMINISTRADORA_EPV
        '-- 16 --> MA_SINDICATO
        '-- 17 --> MA_TIPOTERMINACIONCONTRATO
        '-- 18 --> MA_LABORCONTRATO
        '-- 19 --> MA_TIPOCONCEPTOCONTRATO
        '-- 20 --> MA_TIPOCATEGORIAPERSONAL
        '-- 21 --> PERSONA
        '-- 22 --> MA_ENTIDADAFCONSTRUCCION
        '-- 23 --> AUD_CONTRATO (Reclasificación)
        '-- 24--> RD_MA_TIPORECURSO

        Dim identificador As Long
        Dim tipo As Integer
        If IdContrato_Modificar < 0 OrElse TipoAccion = "I" Then
            identificador = IdPersonaContratar
            tipo = 1 'Crear
            Cb_TipoSalario.SelectedValue = "M" 'Meses
        Else
            identificador = IdContrato_Modificar
            tipo = 2 'Editar
        End If
        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(2, VariablesBase.VariablesBase.IdBaseSiscontrolActual, identificador, tipo)
        Cargar_Combos()
        'Básico

        If dsCargar.Tables(3).Select("IDBASESISCONTROL= '" + (VariablesBase.VariablesBase.IdBaseSiscontrolActual.ToString) + "'").Count > 0 Then

            Dim tipocontrato As DataTable = dsCargar.Tables(3).Select("IDBASESISCONTROL= '" + (VariablesBase.VariablesBase.IdBaseSiscontrolActual.ToString) + "'").CopyToDataTable

            Cb_TipoContrato.DataSource = tipocontrato
        Else
            MessageBox.Show("No tiene asociados 'tipos de contratos' para realizar la contratación en esta base ", "Tipo Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If




        Cb_Cargo_Desempeña.DataSource = dsCargar.Tables(4)
        dtCargos = dsCargar.Tables(4)
        Cb_Categoría.DataSource = dsCargar.Tables(5)
        Cb_TipoGrupo.DataSource = dsCargar.Tables(6)
        Cb_RolProyecto.DataSource = dsCargar.Tables(7)
        Cb_TipoTurno.DataSource = dsCargar.Tables(8)

        Cb_TipoJornada.DataSource = dsCargar.Tables(25)
        Cb_TipoJornada.ValueMember = "TIPOJORNADA"
        Cb_TipoJornada.DisplayMember = "NOMBRE"
        Cb_TipoJornada.SelectedIndex = -1
        'Complemento
        Cb_Banco.DataSource = dsCargar.Tables(9)
        Cb_Banco.SelectedIndex = -1
        Cu_CentroCostoContrato.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
        Cu_CentroCostoContrato.Editando = 2
        Cu_CentroCostoContrato.CargarCentro()
        Cb_EntidadAFConstruccion.DataSource = dsCargar.Tables(22)
        Cb_EntidadAFConstruccion.SelectedIndex = -1
        'Entidades
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.DataSource = dsCargar.Tables(10)
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.DataSource = dsCargar.Tables(11)
        Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.DataSource = dsCargar.Tables(12)
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.DataSource = dsCargar.Tables(13)
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.DataSource = dsCargar.Tables(14)
        Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.DataSource = dsCargar.Tables(15)
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedIndex = -1

        Cb_TipoRecurso.DataSource = dsCargar.Tables(24)
        Cb_TipoRecurso.ValueMember = "IDTIPORECURSO"
        Cb_TipoRecurso.DisplayMember = "NOMBRETIPORECURSO"
        Cb_TipoRecurso.SelectedIndex = -1

        Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
            Case 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 105, 106, 107, 108, 109, 119
                Lb_TipoRecurso.Visible = True
                Cb_TipoRecurso.Visible = True
            Case Else
                Lb_TipoRecurso.Visible = False
                Cb_TipoRecurso.Visible = False
                Cb_TipoRecurso.SelectedValue = 0
        End Select

        Cb_Sindicatos.DataSource = dsCargar.Tables(16)
        Cb_Sindicatos.SelectedIndex = -1
        'Terminación Contrato
        Cb_TipoTerminaciónContrato.DataSource = dsCargar.Tables(17)
        Cb_TipoTerminaciónContrato.SelectedIndex = -1
        Cu_CiudadContratación.CargarDatos()
        Cu_CiudadLabores.CargarDatos()
        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CuBP_JefeInmediato.CargarDatos()
        CuBP_JefeInmediato.Cb_Persona.SelectedIndex = -1
        DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.DataSource = dsCargar.Tables(19)
        DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.ValueMember = "CODIGOTIPOCONCEPTOCONTRATO"
        DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.DisplayMember = "NOMBRETIPOCONCEPTOCONTRATO"
        Dim filaConceptoDefecto As DataRow = dsCargar.Tables(19).Rows(0)
        idConceptoDefecto = filaConceptoDefecto("CODIGOTIPOCONCEPTOCONTRATO")
        Cb_CategoríaPersonal.DataSource = dsCargar.Tables(20)
        'Cargar menú contextual
        CMS_Labores.Items.Clear()
        For i = 0 To dsCargar.Tables(18).Rows.Count - 1
            Dim fila As DataRow
            fila = dsCargar.Tables(18).Rows(i)
            Dim Item As New ToolStripMenuItem("LABOR", Nothing, New EventHandler(AddressOf ClickMenuIngreso))
            Item.Text = fila("DESCRIPCIONLABORCONTRATADA")
            CMS_Labores.Items.Add(Item)
        Next
        'Cargar Conceptos contrato
        dtConceptosContrato = dsCargar.Tables(1)
        Dgv_Conceptos.DataSource = dtConceptosContrato
        'Cargar prórrogas
        dtProrrogas = dsCargar.Tables(2)
        Dgv_Prorrogas.DataSource = dtProrrogas
        If TipoAccion = "I" Then 'insertar
            Tp_TerminaciónContrato.Parent = Nothing
            Cu_CiudadContratación.Cb_Ciudad.SelectedIndex = -1
            Cu_CiudadLabores.Cb_Ciudad.SelectedIndex = -1
            Dim drEntidades As DataRow = dsCargar.Tables(21).Rows(0)
            If Not IsNothing(drEntidades.Item("CODIGOENTIDADADMINEPS")) Then
                Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedValue = drEntidades.Item("CODIGOENTIDADADMINEPS")
            End If
            Try
                Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.SelectedValue = "14-25" 'Colmena
            Catch
                Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.SelectedIndex = -1
            End Try
            If Not IsNothing(drEntidades.Item("CODIGOENTIDADADMINAFP")) Then
                Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedValue = drEntidades.Item("CODIGOENTIDADADMINAFP")
            End If
            If Not IsNothing(drEntidades.Item("CODIGOENTIDADADMINAFC")) Then
                Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedValue = drEntidades.Item("CODIGOENTIDADADMINAFC")
            End If
            Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.SelectedIndex = -1
            If Not IsNothing(drEntidades.Item("CODIGOENTIDADADMINEPV")) Then
                Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedValue = drEntidades.Item("CODIGOENTIDADADMINEPV")
            End If
            'Información de semanas cotizadas
            'If Not IsDBNull(drEntidades.Item("COTIZO50SEMANASULTIMOAÑO")) Then
            'If drEntidades.Item("COTIZO50SEMANASULTIMOAÑO") = "S" Then
            'Ck_Cotizado50Semanas.CheckState = CheckState.Checked
            'Ck_RequiereColectivoVida.CheckState = CheckState.Unchecked
            'ElseIf Not IsDBNull(drEntidades.Item("SEMANASFALTAN")) Then
            'Ck_Cotizado50Semanas.CheckState = CheckState.Unchecked
            'Nud_FaltanSemanas.Value = drEntidades.Item("SEMANASFALTAN")
            'Ck_RequiereColectivoVida.CheckState = CheckState.Checked
            'End If
            'End If
        Else
            FilaContrato = dsCargar.Tables(0).Rows(0)
        End If
        'Nombre e identificación
        Label_Nombre.Text = "Nombre: " & dsCargar.Tables(21).Rows(0).Item("NOMBRE")
        Label_Cedula.Text = "Identificación: " & FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(dsCargar.Tables(21).Rows(0).Item("IDENTIFICACION")))
        If TipoAccion = "T" Then
            Dim fechaTermina As Date
            Try
                fechaTermina = ConsultarFechaFinContrato()
            Catch ex As Exception
                fechaTermina = Date.Today
            End Try
            Dtp_FechaTerminaciónContrato.Value = fechaTermina
        End If
    End Sub

    Private Function ConsultarFechaFinContrato() As Date
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.ContratoFechaFin(@IDCONTRATO)", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato_Modificar)
        conexion.Open()
        Return comando.ExecuteScalar()
        conexion.Close()
    End Function

    Private Sub ClickMenuIngreso(ByVal sender As Object, ByVal e As EventArgs)
        Tx_LaborContratada.Text = DirectCast(sender, ToolStripMenuItem).Text
    End Sub

    ''' <summary>Asigna los conjuntos de datos a los listados desplegables.</summary>
    Private Sub Cargar_Combos()
        dtTipoDuracion.Columns.Add("CODIGOTIPODURACION")
        dtTipoDuracion.Columns.Add("NOMBRETIPODURACION")
        dtTipoDuracion.Rows.Add("M", "Meses")
        dtTipoDuracion.Rows.Add("D", "Días")
        dtTipoDuracion.Rows.Add("N", "No Aplica")
        Cb_TipoDuración.DataSource = dtTipoDuracion

        dtTipoPago.Columns.Add("CODIGOTIPOPAGO")
        dtTipoPago.Columns.Add("NOMBRETIPOPAGO")
        dtTipoPago.Rows.Add("A", "Abono Cuenta")
        dtTipoPago.Rows.Add("C", "Cheque")
        Cb_TipoPago.DataSource = dtTipoPago

        dtPeriodoPago.Columns.Add("CODIGOTIPOPERIODOPAGO")
        dtPeriodoPago.Columns.Add("NOMBRETIPOPERIODOPAGO")
        dtPeriodoPago.Rows.Add("Q", "Quincena Vencida")
        dtPeriodoPago.Rows.Add("M", "Mes Vencido")
        Cb_PeriodoPago.DataSource = dtPeriodoPago

        dtTipoCuenta.Columns.Add("CODIGOTIPOCUENTA")
        dtTipoCuenta.Columns.Add("NOMBRETIPOCUENTA")
        dtTipoCuenta.Rows.Add("A", "Cuenta Ahorros")
        dtTipoCuenta.Rows.Add("C", "Cuenta Corriente")
        dtTipoCuenta.Rows.Add("N", "No Aplica")
        dtTipoCuenta.Rows.Add("S", "Sin Información")
        Cb_TipoCuenta.DataSource = dtTipoCuenta

        dtTipoSalario.Columns.Add("CODIGOTIPOSALARIO")
        dtTipoSalario.Columns.Add("NOMBRETIPOSALARIO")
        dtTipoSalario.Rows.Add("M", "Mensual")
        dtTipoSalario.Rows.Add("D", "Diario")
        Cb_TipoSalario.DataSource = dtTipoSalario
    End Sub

#Region "Cargar Datos Editar"
    ''' <summary>Asignar los datos del contrato a los controles del formulario.</summary>
    Public Sub CargarDatosContrato()
        'Básico
        Try
            Tx_AgenciaEmpleo.Text = FilaContrato("AGENCIAEMPLEO")
        Catch
        End Try
        Try
            Tx_NumeroVacante.Text = FilaContrato("NUMEROVACANTE")
        Catch
        End Try
        Cb_TipoContrato.SelectedValue = FilaContrato("CODIGOTIPOCONTRATO")
        Cb_TipoSalario.SelectedValue = FilaContrato("CODIGOTIPOSALARIO")
        Tx_Salario.Text = FilaContrato("SALARIO")
        Cb_Cargo_Desempeña.SelectedValue = FilaContrato("CODIGOTIPOCARGO")
        Cb_Categoría.SelectedValue = FilaContrato("CODIGOTIPOCATEGORIA")
        Cb_TipoGrupo.SelectedValue = FilaContrato("CODIGOTIPOGRUPO")
        Try
            NUD_Duración.Value = FilaContrato("DURACION")
        Catch
        End Try
        Cb_TipoDuración.SelectedValue = FilaContrato("CODIGOTIPODURACION")
        Cb_CategoríaPersonal.SelectedValue = FilaContrato("CODIGOTIPOCATEGORIAPERSONAL")
        Dtp_FechaInicioContrato.Value = FilaContrato("FECHAINICIOCONTRATO")
        Dtp_FechaFirmaContrato.Value = FilaContrato("FECHAFIRMACONTRATO")
        If listaContratosTermFijo.Contains(Cb_TipoContrato.SelectedValue) Then
            If Not IsDBNull(FilaContrato("FECHATERMINOCONTRATOINICIAL")) Then
                DTP_FechaTerminaciónContratoInicial.Value = FilaContrato("FECHATERMINOCONTRATOINICIAL")
            End If
            DTP_FechaTerminaciónContratoInicial.Visible = True
        ElseIf listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) OrElse listaContratosTermIndef.Contains(Cb_TipoContrato.SelectedValue) Then
            DTP_FechaTerminaciónContratoInicial.Visible = False
        Else
            DTP_FechaTerminaciónContratoInicial.Visible = False
        End If
        Cb_RolProyecto.SelectedValue = FilaContrato("CODIGOTIPOROLBASE")
        Tx_LaborContratada.Text = FilaContrato("LABORCONTRATO")
        Cu_CiudadContratación.Cb_Ciudad.SelectedValue = FilaContrato("CODIGOLUGARCONTRATO")
        Cu_CiudadLabores.Cb_Ciudad.SelectedValue = FilaContrato("CODIGOLUGARLABORES")
        Cb_TipoTurno.SelectedValue = FilaContrato("CODIGOTIPOTURNO")
        Tx_Observación.Text = FilaContrato("OBSERVACION")
        'Complemento
        Cb_PeriodoPago.SelectedValue = FilaContrato("CODIGOTIPOPERIODOPAGO")
        Cb_TipoPago.SelectedValue = FilaContrato("CODIGOTIPOPAGO")
        Cb_Banco.SelectedValue = FilaContrato("CODIGOENTIDADFINANCIERA")
        Cb_TipoCuenta.SelectedValue = FilaContrato("CODIGOTIPOCUENTA")
        Try
            If IsDBNull(FilaContrato("NUMEROCUENTA")) = False Then
                Tx_NumeroCuenta.Text = FilaContrato("NUMEROCUENTA")
            End If
        Catch ex As Exception

        End Try
        If FilaContrato("SUMINISTROTRANSPORTE") = "S" Then
            Ck_SuministroTransporte.CheckState = CheckState.Checked
        Else
            Ck_SuministroTransporte.CheckState = CheckState.Unchecked
        End If
        If FilaContrato("SUMINISTROCAMPAMENTO") = "S" Then
            Ck_SuministroCampamento.CheckState = CheckState.Checked
        Else
            Ck_SuministroCampamento.CheckState = CheckState.Unchecked
        End If
        If FilaContrato("DECOMUNIDAD") = "S" Then
            Ck_DeLaComunidad.CheckState = CheckState.Checked
        Else
            Ck_DeLaComunidad.CheckState = CheckState.Unchecked
        End If
        Try
            Tx_ConceptoRetefuente.Text = FilaContrato("CONCEPTODEDUCIONRETEFUENTE")
        Catch
        End Try
        Tx_ValorDeducciónRetefuente.Text = FilaContrato("VALORDEDUCIONRETEFUENTE")
        If FilaContrato("DECLARARENTA") = "S" Then
            Ck_DeclaraRenta.CheckState = CheckState.Checked
        Else
            Ck_DeclaraRenta.CheckState = CheckState.Unchecked
        End If
        Try
            Cu_CentroCostoContrato.IdCentroCosto = FilaContrato("IDCENTROCOSTO")
        Catch ex As Exception
            Cu_CentroCostoContrato.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
        End Try
        Cu_CentroCostoContrato.Editando = 3
        Cu_CentroCostoContrato.CargarCentro() 'Asigna el nombre del centro de costo a la etiqueta
        If Not IsDBNull(FilaContrato("CODIGOENTIDADAFCONSTRUCCION")) Then
            Cb_EntidadAFConstruccion.SelectedValue = FilaContrato("CODIGOENTIDADAFCONSTRUCCION")
        End If
        If Not IsDBNull(FilaContrato("VALORAFCONSTRUCCION")) Then
            Tx_ValorAFConstruccion.Text = FilaContrato("VALORAFCONSTRUCCION")
        End If
        If Not IsDBNull(FilaContrato("TIPOJORNADA")) Then
            Cb_TipoJornada.SelectedValue = FilaContrato("TIPOJORNADA")
        End If
        'Entidades
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedValue = FilaContrato("CODIGOENTIDADADMINEPS")
        If IsDBNull(FilaContrato("FECHAAFILIACIONEPS")) Then
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Value = FilaContrato("FECHAAFILIACIONEPS")
        End If
        If Not IsDBNull(FilaContrato("VALORUPC")) Then
            Tx_ValorUPC.Text = FilaContrato("VALORUPC")
        End If
        Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.SelectedValue = FilaContrato("CODIGOENTIDADADMINARP")
        If IsDBNull(FilaContrato("FECHAAFILIACIONARP")) Then
            Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Value = FilaContrato("FECHAAFILIACIONARP")
        End If
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedValue = FilaContrato("CODIGOENTIDADADMINAFP")
        If IsDBNull(FilaContrato("FECHAAFILIACIONAFP")) Then
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Value = FilaContrato("FECHAAFILIACIONAFP")
        End If
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedValue = FilaContrato("CODIGOENTIDADADMINAFC")
        If IsDBNull(FilaContrato("FECHAAFILIACIONAFC")) Then
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Value = FilaContrato("FECHAAFILIACIONAFC")
        End If
        Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.SelectedValue = FilaContrato("CODIGOENTIDADADMINCCF")
        If IsDBNull(FilaContrato("FECHAAFILIACIONCCF")) Then
            Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Value = FilaContrato("FECHAAFILIACIONCCF")
        End If
        If Not IsDBNull(FilaContrato("CODIGOENTIDADADMINEPV")) Then
            Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedValue = FilaContrato("CODIGOENTIDADADMINEPV")
            If Not IsDBNull(FilaContrato("FECHAAFILIACIONEPV")) Then
                Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = True
                Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value = FilaContrato("FECHAAFILIACIONEPV")
            Else
                Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.MinDate
                Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = False
            End If
            If Not IsDBNull(FilaContrato("VALORAPORTEVOLUNTARIOPENSION")) Then
                Tx_ValorAPV.Text = FilaContrato("VALORAPORTEVOLUNTARIOPENSION")
            End If
        Else
            Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = False
        End If
        Try
            If FilaContrato("COTIZO50SEMANASULTIMOAÑO") = "S" Then
                Ck_Cotizado50Semanas.CheckState = CheckState.Checked
            Else
                Lb_FaltanSemanas.Visible = True
                Nud_FaltanSemanas.Visible = True
                Ck_Cotizado50Semanas.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try

        Try
            Nud_FaltanSemanas.Value = FilaContrato("SEMANASFALTAN")
        Catch
        End Try

        If IsDBNull(FilaContrato("FECHAEXPEDICION50SEMANAS")) Then
            Dtp_Expedición50Semanas.Value = Dtp_Expedición50Semanas.MinDate
            Dtp_Expedición50Semanas.Checked = False
        Else
            Dtp_Expedición50Semanas.Checked = True
            Dtp_Expedición50Semanas.Value = FilaContrato("FECHAEXPEDICION50SEMANAS")
        End If

        Try
            If IsDBNull(FilaContrato("TOTALSEMANASAFP")) Then
                Nud_TotalSemanas.Value = -1
            Else
                Nud_TotalSemanas.Value = FilaContrato("TOTALSEMANASAFP")
            End If
        Catch ex As Exception

        End Try


        If Not IsDBNull(FilaContrato("AFILIADOSINDICATO")) AndAlso FilaContrato("AFILIADOSINDICATO") = "S" Then
            Ck_AfiliadoSindicato.CheckState = CheckState.Checked
        Else
            Ck_AfiliadoSindicato.CheckState = CheckState.Unchecked
        End If
        If Not IsDBNull(FilaContrato("CODIGOSINDICATO")) Then
            Cb_Sindicatos.SelectedValue = FilaContrato("CODIGOSINDICATO")
        Else
            Cb_Sindicatos.SelectedIndex = -1
        End If
        Try
            If FilaContrato("DESCUENTOSINDICATO") = "S" Then
                Ck_DescuentoSindical.CheckState = CheckState.Checked
                If Not IsDBNull(FilaContrato("PORCENTAJESINDICATO")) Then
                    Nud_PorcentSindicato.Value = FilaContrato("PORCENTAJESINDICATO")
                End If
            Else
                Ck_DescuentoSindical.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If FilaContrato("APORTAFIC") = "S" Then
                Ck_AportaFIC.CheckState = CheckState.Checked
            Else
                Ck_AportaFIC.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If FilaContrato("REQUIERECOLECTIVOVIDA") = "S" Then
                Ck_RequiereColectivoVida.CheckState = CheckState.Checked
            Else
                Ck_RequiereColectivoVida.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        If Not IsDBNull(FilaContrato("IDPERSONAJEFEINMEDIATO")) Then
            CuBP_JefeInmediato.CargarDatos(FilaContrato("IDPERSONAJEFEINMEDIATO"))
            CuBP_JefeInmediato.Cb_Persona.SelectedValue = FilaContrato("IDPERSONAJEFEINMEDIATO")
            CuBP_JefeInmediato.CargarCajaTexto()
        End If
        Try
            Tx_FrenteTrabajo.Text = FilaContrato("NOMBREFRENTETRABAJO")
        Catch
        End Try
        Try
            If IsDBNull(FilaContrato("IDTIPORECURSO")) = False Then
                Cb_TipoRecurso.SelectedValue = FilaContrato("IDTIPORECURSO")
            Else
                Cb_TipoRecurso.SelectedIndex = -1
            End If

        Catch ex As Exception
            Cb_TipoRecurso.SelectedIndex = -1
        End Try
        Select Case FilaContrato("ESTADOCONTRATO")
            Case "A" 'Contrato Activo
                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     ACTIVO"
                Lb_Estado.ForeColor = Drawing.Color.Blue
                Lb_Estado.Visible = True
            Case "E" 'Contrato eextendido
                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     EXTENDIDO"
                Lb_Estado.ForeColor = Drawing.Color.DarkRed
                Lb_Estado.Visible = True
            Case "S" 'Contrato Suspendido
                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     SUSPENDIDO"
                Lb_Estado.ForeColor = Drawing.Color.Orange
                Lb_Estado.Visible = True
            Case "T" 'Contrato Terminado
                Cb_TipoTerminaciónContrato.SelectedValue = FilaContrato("CODIGOTIPOTERMINACIONCONTRATO")
                Tx_MotivoRetiro.Text = FilaContrato("DESCRIPCIONMOTIVORETIRO")
                Dtp_FechaTerminaciónContrato.Value = FilaContrato("FECHATERMINACIONCONTRATO")
                Tx_LugarReclamación.Text = FilaContrato("LUGARRECLAMALIQUIDACION")
                If FilaContrato("DEVOLUCIONCARNET") = "S" Then
                    Ck_DevolvioCarnet.CheckState = CheckState.Checked
                Else
                    Ck_DevolvioCarnet.CheckState = CheckState.Unchecked
                End If
                If FilaContrato("PAZYSALVO") = "S" Then
                    Ck_EntregoPazSalvo.CheckState = CheckState.Checked
                Else
                    Ck_EntregoPazSalvo.CheckState = CheckState.Unchecked
                End If
                If FilaContrato("CARTA_POR_IC_ACTIVO") = "S" Then
                    Ck_CartaICActivo.CheckState = CheckState.Checked
                Else
                    Ck_CartaICActivo.CheckState = CheckState.Unchecked
                End If
                Tx_GlosasOPendientes.Text = FilaContrato("GLOSASOPENDIENTES")

                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     TERMINADO"
                Lb_Estado.ForeColor = Drawing.Color.Red
                'Lb_Estado.Visible = True
                'Tc_Contrato.SelectedTab = Tp_TerminaciónContrato
        End Select
        Select Case TipoAccion
            Case "E" 'editar
                InhabilitarControlesEditar()
                Tp_TerminaciónContrato.Parent = Nothing
            Case "T" 'terminar
                InhabilitarControlesTerminar()
                Tc_Contrato.SelectedTab = Tp_TerminaciónContrato
            Case "V" 'ver
                InhabilitarControlesVer()
                If FilaContrato("ESTADOCONTRATO") = "T" Then
                    Tc_Contrato.SelectedTab = Tp_TerminaciónContrato
                Else
                    Tp_TerminaciónContrato.Parent = Nothing
                End If
        End Select
    End Sub
#End Region 'Cargar Datos Editar

#Region "Inhabilitar controles"
    ''' <summary>Deshabilita los controles del formulario de los datos que no deben cambiar cuando ya se ha registrado el contrato.</summary>
    Private Sub InhabilitarControlesEditar()
        'Básico
        Cb_TipoContrato.Enabled = False
        Cb_TipoSalario.Enabled = False
        If listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) Then
            Tx_LaborContratada.Enabled = True
        Else
            Tx_LaborContratada.Enabled = False
        End If
        If dtProrrogas.Rows.Count > 0 Then
            Dtp_FechaInicioContrato.Enabled = False
            Dtp_FechaFirmaContrato.Enabled = False
            DTP_FechaTerminaciónContratoInicial.Enabled = False
        End If
    End Sub

    ''' <summary>Deshabilita todos los controles del formulario.</summary>
    Private Sub InhabilitarControlesVer()
        Bt_Aceptar.Enabled = False
        'Básico
        Tx_AgenciaEmpleo.Enabled = False
        Tx_NumeroVacante.Enabled = False
        Cb_TipoContrato.Enabled = False
        Cb_Cargo_Desempeña.Enabled = False
        Cb_Categoría.Enabled = False
        Cb_TipoSalario.Enabled = False
        Cb_TipoGrupo.Enabled = False
        Tx_Salario.Enabled = False
        NUD_Duración.Enabled = False
        Cb_TipoDuración.Enabled = False
        Cb_CategoríaPersonal.Enabled = False
        Dtp_FechaInicioContrato.Enabled = False
        Dtp_FechaFirmaContrato.Enabled = False
        DTP_FechaTerminaciónContratoInicial.Enabled = False
        Cb_RolProyecto.Enabled = False
        Ck_DeLaComunidad.Enabled = False
        Tx_LaborContratada.Enabled = True 'Dejar habilitado para permitir el desplazamiento por la caja de texto y evitar que el párrafo se muestre incompleto.
        Tx_LaborContratada.ReadOnly = True 'Dejar habilitado para permitir el desplazamiento por la caja de texto y evitar que el párrafo se muestre incompleto.
        Cu_CiudadContratación.Enabled = False
        Cu_CiudadLabores.Enabled = False
        CuBP_JefeInmediato.Enabled = False
        Tx_FrenteTrabajo.Enabled = False
        Cb_TipoTurno.Enabled = False
        Tx_Observación.Enabled = False
        'Complemento
        Cb_PeriodoPago.Enabled = False
        Cb_TipoPago.Enabled = False
        Cb_Banco.Enabled = False
        Tx_NumeroCuenta.Enabled = False
        Cb_TipoCuenta.Enabled = False
        Ck_SuministroTransporte.Enabled = False
        Ck_SuministroCampamento.Enabled = False
        Tx_ConceptoRetefuente.Enabled = False
        Tx_ValorDeducciónRetefuente.Enabled = False
        Ck_DeclaraRenta.Enabled = False
        Cu_CentroCostoContrato.Ll_CentroCostos.Enabled = False
        Cb_EntidadAFConstruccion.Enabled = False
        Tx_ValorAFConstruccion.Enabled = False
        Bt_Agregar.Enabled = False
        Dgv_Conceptos.Enabled = False
        Cb_TipoJornada.Enabled = False
        'Entidades
        Cu_EntidadAdministradora_EPS.Tx_Codigo.Enabled = False
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.Enabled = False
        Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Enabled = False
        Cu_EntidadAdministradora_EPS.Bt_Buscar.Enabled = False
        Tx_ValorUPC.Enabled = False
        Cu_EntidadAdministradora_ARL.Tx_Codigo.Enabled = False
        Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.Enabled = False
        Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Enabled = False
        Cu_EntidadAdministradora_ARL.Bt_Buscar.Enabled = False
        Cu_EntidadAdministradora_AFP.Tx_Codigo.Enabled = False
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.Enabled = False
        Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Enabled = False
        Cu_EntidadAdministradora_AFP.Bt_Buscar.Enabled = False
        Cu_EntidadAdministradora_AFC.Tx_Codigo.Enabled = False
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.Enabled = False
        Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Enabled = False
        Cu_EntidadAdministradora_AFC.Bt_Buscar.Enabled = False
        Cu_EntidadAdministradora_CCF.Tx_Codigo.Enabled = False
        Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.Enabled = False
        Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Enabled = False
        Cu_EntidadAdministradora_CCF.Bt_Buscar.Enabled = False
        Cu_EntidadAdministradora_EPV.Tx_Codigo.Enabled = False
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.Enabled = False
        Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Enabled = False
        Cu_EntidadAdministradora_EPV.Bt_Buscar.Enabled = False
        Tx_ValorAPV.Enabled = False
        Ck_Cotizado50Semanas.Enabled = False
        Nud_FaltanSemanas.Enabled = False
        Nud_TotalSemanas.Enabled = False
        Dtp_Expedición50Semanas.Enabled = False
        Ck_RequiereColectivoVida.Enabled = False
        Ck_AportaFIC.Enabled = False
        Ck_DescuentoSindical.Enabled = False
        Cb_Sindicatos.Enabled = False
        Ck_AfiliadoSindicato.Enabled = False
        Nud_PorcentSindicato.Enabled = False
        'Terminación
        Cb_TipoTerminaciónContrato.Enabled = False
        Tx_MotivoRetiro.Enabled = False
        Dtp_FechaTerminaciónContrato.Enabled = False
        Tx_LugarReclamación.Enabled = False
        Ck_DevolvioCarnet.Enabled = False
        Ck_EntregoPazSalvo.Enabled = False
        Ck_CartaICActivo.Enabled = False
        Tx_GlosasOPendientes.Enabled = False
        Dgv_Prorrogas.Enabled = False
        Cb_TipoRecurso.Enabled = False
    End Sub

    ''' <summary>Deshabilita los controles del formulario en las pestañas diferentes a la de terminación de contrato.</summary>
    Private Sub InhabilitarControlesTerminar()
        Pn_Basico.Enabled = False
        Pn_PrincipalComplemento.Enabled = False
        Pn_Entidades.Enabled = False
    End Sub
#End Region 'Inhabilitar controles

#Region "Validar y guardar Contrato"
    ''' <summary>Validar y guardar los datos del contrato.</summary>
    ''' <returns>Verdadero si el contrato se guardó correctamente. Falso si no se guardaron los cambios.</returns>
    Private Function Guardar_Datos() As Boolean
        dtConceptosContrato.AcceptChanges()

        Try
            If Validar_Contrato() Then
                Dim dr As DialogResult

                If TipoAccion = "T" Then
                    dr = MessageBox.Show("¿Desea registrar la terminación del contrato con el Tipo y la Fecha de terminación seleccionadas?", "Terminar contrato", MessageBoxButtons.YesNo)
                    If dr = DialogResult.Yes Then
                        Try
                            Guardar_Registro_Contrato()
                        Catch
                        End Try

                    End If
                Else
                    Try
                        Guardar_Registro_Contrato()
                    Catch
                    End Try

                End If
            Else
                Guardar_Datos = False
                Exit Function
            End If
                Guardar_Datos = _guardado
        Catch ex As Exception
            Guardar_Datos = False
            MessageBox.Show("Error al guardar los datos" & Environment.NewLine & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ''' <summary>Guarda el contrato.</summary>
    Private Sub Guardar_Registro_Contrato()
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo.GestionarContrato", conn)

        'Declaración de parámetros del procedimiento
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        Comando.Parameters.Add("@IDCONTRATO", SqlDbType.BigInt)
        Comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
        Comando.Parameters.Add("@IDBASECONTRATADO", SqlDbType.Int)
        Comando.Parameters.Add("@CODIGOCONTRATO", SqlDbType.Int)
        'Básico
        Comando.Parameters.Add("@CODIGOTIPOCONTRATO", SqlDbType.TinyInt)
        Comando.Parameters.Add("@CODIGOTIPOSALARIO", SqlDbType.NChar, 1)
        Comando.Parameters.Add(New SqlParameter("@SALARIO", SqlDbType.Decimal) With {.Precision = 18, .Scale = 0})
        Comando.Parameters.Add("@CODIGOTIPOCARGO", SqlDbType.Int)
        Comando.Parameters.Add("@CODIGOTIPOCATEGORIA", SqlDbType.TinyInt)
        Comando.Parameters.Add("@CODIGOTIPOGRUPO", SqlDbType.NChar, 1)
        Comando.Parameters.Add("@DURACION", SqlDbType.Int)
        Comando.Parameters.Add("@CODIGOTIPOCATEGORIAPERSONAL", SqlDbType.NChar, 1)
        Comando.Parameters.Add("@CODIGOTIPODURACION", SqlDbType.NChar, 1)
        Comando.Parameters.Add("@FECHAINICIOCONTRATO", SqlDbType.Date)
        Comando.Parameters.Add("@FECHAFIRMACONTRATO", SqlDbType.Date)
        Comando.Parameters.Add("@FECHATERMINOCONTRATOINICIAL", SqlDbType.Date)
        Comando.Parameters.Add("@CODIGOTIPOROLBASE", SqlDbType.Int)
        Comando.Parameters.Add("@LABORCONTRATO", SqlDbType.NVarChar, 500)
        Comando.Parameters.Add("@CODIGOLUGARCONTRATO", SqlDbType.Char, 5)
        Comando.Parameters.Add("@CODIGOLUGARLABORES", SqlDbType.Char, 5)
        Comando.Parameters.Add("@CODIGOTIPOTURNO", SqlDbType.TinyInt)
        Comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
        Comando.Parameters.Add("@TIPOJORNADA", SqlDbType.NVarChar, 15)
        'Complemento
        Comando.Parameters.Add("@CODIGOTIPOPERIODOPAGO", SqlDbType.NChar, 10)
        Comando.Parameters.Add("@CODIGOTIPOPAGO", SqlDbType.NChar, 10)
        Comando.Parameters.Add("@CODIGOENTIDADFINANCIERA", SqlDbType.NVarChar, 3)
        Comando.Parameters.Add("@CODIGOTIPOCUENTA", SqlDbType.NChar, 10)
        Comando.Parameters.Add("@NUMEROCUENTA", SqlDbType.NVarChar, 20)
        Comando.Parameters.Add("@SUMINISTROTRANSPORTE", SqlDbType.NChar, 1)
        Comando.Parameters.Add("@SUMINISTROCAMPAMENTO", SqlDbType.NChar, 1)
        Comando.Parameters.Add("@DECOMUNIDAD", SqlDbType.Char, 1)
        Comando.Parameters.Add("@CONCEPTODEDUCIONRETEFUENTE", SqlDbType.NVarChar, 100)
        Comando.Parameters.Add(New SqlParameter("@VALORDEDUCIONRETEFUENTE", SqlDbType.Decimal) With {.Precision = 18, .Scale = 0})
        Comando.Parameters.Add("@DECLARARENTA", SqlDbType.Char, 1)
        Comando.Parameters.Add("@CODIGOENTIDADAFCONSTRUCCION", SqlDbType.Int)
        Comando.Parameters.Add(New SqlParameter("@VALORAFCONSTRUCCION", SqlDbType.Decimal) With {.Precision = 18, .Scale = 0})
        'Entidades
        Comando.Parameters.Add("@CODIGOENTIDADADMINEPS", SqlDbType.NVarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONEPS", SqlDbType.Date)
        Comando.Parameters.Add(New SqlParameter("@VALORUPC", SqlDbType.Decimal) With {.Precision = 18, .Scale = 0})
        Comando.Parameters.Add("@CODIGOENTIDADADMINARL", SqlDbType.NVarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONARL", SqlDbType.Date)
        Comando.Parameters.Add("@CODIGOENTIDADADMINAFP", SqlDbType.NVarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONAFP", SqlDbType.Date)
        Comando.Parameters.Add("@CODIGOENTIDADADMINAFC", SqlDbType.NVarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONAFC", SqlDbType.Date)
        Comando.Parameters.Add("@CODIGOENTIDADADMINCCF", SqlDbType.NVarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONCCF", SqlDbType.Date)
        Comando.Parameters.Add("@CODIGOENTIDADADMINEPV", SqlDbType.NVarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONEPV", SqlDbType.Date)
        Comando.Parameters.Add(New SqlParameter("@VALORAPORTEVOLUNTARIOPENSION", SqlDbType.Decimal) With {.Precision = 18, .Scale = 0})
        Comando.Parameters.Add("@COTIZO50SEMANASULTIMOAÑO", SqlDbType.Char, 1)
        Comando.Parameters.Add("@SEMANASFALTAN", SqlDbType.Int)
        Comando.Parameters.Add(New SqlParameter("@TOTALSEMANASAFP", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2})
        Comando.Parameters.Add("@FECHAEXPEDICION50SEMANAS", SqlDbType.Date)
        Comando.Parameters.Add("@REQUIERECOLECTIVOVIDA", SqlDbType.Char, 1)
        Comando.Parameters.Add("@APORTAFIC", SqlDbType.Char, 1)
        Comando.Parameters.Add("@AFILIADOSINDICATO", SqlDbType.Char, 1)
        Comando.Parameters.Add("@CODIGOSINDICATO", SqlDbType.Int)
        Comando.Parameters.Add("@DESCUENTOSINDICATO", SqlDbType.Char, 1)
        Comando.Parameters.Add(New SqlParameter("@PORCENTAJESINDICATO", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2})

        Comando.Parameters.Add("@IDPERSONAJEFEINMEDIATO", SqlDbType.Int)
        Comando.Parameters.Add("@NOMBREFRENTETRABAJO", SqlDbType.NVarChar, 100)
        Comando.Parameters.Add("@AGENCIAEMPLEO", SqlDbType.NVarChar, 50)
        Comando.Parameters.Add("@NUMEROVACANTE", SqlDbType.NVarChar, 30)
        Comando.Parameters.Add("@IDCENTROCOSTO", SqlDbType.Int)
        Comando.Parameters.Add("@CODIGOTIPOTERMINACIONCONTRATO", SqlDbType.TinyInt)
        Comando.Parameters.Add("@DESCRIPCIONMOTIVORETIRO", SqlDbType.NVarChar, 100)
        Comando.Parameters.Add("@FECHATERMINACIONCONTRATO", SqlDbType.Date)
        Comando.Parameters.Add("@FECHARETIROCONTRATO", SqlDbType.Date)
        Comando.Parameters.Add("@LUGARRECLAMALIQUIDACION", SqlDbType.NVarChar, 100)
        Comando.Parameters.Add("@DEVOLUCIONCARNET", SqlDbType.Char, 1)
        Comando.Parameters.Add("@PAZYSALVO", SqlDbType.Char, 1)
        Comando.Parameters.Add("@CARTA_POR_IC_ACTIVO", SqlDbType.Char, 1)
        Comando.Parameters.Add("@GLOSASOPENDIENTES", SqlDbType.NVarChar, 200)
        Comando.Parameters.Add("@IDTIPORECURSO", SqlDbType.TinyInt)
        Comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)
        Comando.Parameters.Add("@TIP_CONTRATO_CONCEPTO", SqlDbType.Structured)

        'Asignación de valores a los parámetros
        Select Case TipoAccion
            Case "I" 'insertar
                Comando.Parameters("@ACCION").Value = 1
            Case "E" 'editar
                Comando.Parameters("@ACCION").Value = 2
            Case "T" 'terminar
                Comando.Parameters("@ACCION").Value = 3
        End Select
        Comando.Parameters("@IDCONTRATO").Value = IdContrato_Modificar
        Comando.Parameters("@IDPERSONA").Value = IdPersonaContratar
        Comando.Parameters("@IDBASECONTRATADO").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        'Básico
        Comando.Parameters("@CODIGOCONTRATO").Value = -1
        Comando.Parameters("@CODIGOTIPOCONTRATO").Value = Cb_TipoContrato.SelectedValue
        Comando.Parameters("@CODIGOTIPOSALARIO").Value = Cb_TipoSalario.SelectedValue
        Comando.Parameters("@SALARIO").Value = ValorReal(Tx_Salario.Text)
        Comando.Parameters("@CODIGOTIPOCARGO").Value = Cb_Cargo_Desempeña.SelectedValue
        Comando.Parameters("@CODIGOTIPOCATEGORIA").Value = Cb_Categoría.SelectedValue
        Comando.Parameters("@CODIGOTIPOGRUPO").Value = Cb_TipoGrupo.SelectedValue
        Comando.Parameters("@DURACION").Value = NUD_Duración.Value
        Comando.Parameters("@CODIGOTIPOCATEGORIAPERSONAL").Value = Cb_CategoríaPersonal.SelectedValue
        Comando.Parameters("@CODIGOTIPODURACION").Value = Cb_TipoDuración.SelectedValue
        Comando.Parameters("@FECHAINICIOCONTRATO").Value = Dtp_FechaInicioContrato.Value
        Comando.Parameters("@FECHAFIRMACONTRATO").Value = Dtp_FechaFirmaContrato.Value
        If listaContratosTermFijo.Contains(Cb_TipoContrato.SelectedValue) Then
            Comando.Parameters("@FECHATERMINOCONTRATOINICIAL").Value = DTP_FechaTerminaciónContratoInicial.Value
        ElseIf listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) OrElse listaContratosTermIndef.Contains(Cb_TipoContrato.SelectedValue) Then
            Comando.Parameters("@FECHATERMINOCONTRATOINICIAL").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHATERMINOCONTRATOINICIAL").Value = DBNull.Value
        End If
        Comando.Parameters("@CODIGOTIPOROLBASE").Value = Cb_RolProyecto.SelectedValue
        Comando.Parameters("@LABORCONTRATO").Value = Trim(Tx_LaborContratada.Text)
        Comando.Parameters("@CODIGOLUGARCONTRATO").Value = Cu_CiudadContratación.Cb_Ciudad.SelectedValue
        Comando.Parameters("@CODIGOLUGARLABORES").Value = Cu_CiudadLabores.Cb_Ciudad.SelectedValue
        Comando.Parameters("@CODIGOTIPOTURNO").Value = Cb_TipoTurno.SelectedValue
        Comando.Parameters("@OBSERVACION").Value = Trim(Tx_Observación.Text)
        'Complemento
        Comando.Parameters("@CODIGOTIPOPERIODOPAGO").Value = Cb_PeriodoPago.SelectedValue
        Comando.Parameters("@CODIGOTIPOPAGO").Value = Cb_TipoPago.SelectedValue
        Select Case Cb_TipoPago.SelectedValue
            Case "A" 'Abono Cuenta
                Comando.Parameters("@CODIGOENTIDADFINANCIERA").Value = Cb_Banco.SelectedValue
                Comando.Parameters("@CODIGOTIPOCUENTA").Value = Cb_TipoCuenta.SelectedValue
                Comando.Parameters("@NUMEROCUENTA").Value = Tx_NumeroCuenta.Text
            Case "C" 'Cheque
                Comando.Parameters("@CODIGOENTIDADFINANCIERA").Value = DBNull.Value
                Comando.Parameters("@CODIGOTIPOCUENTA").Value = DBNull.Value
                Comando.Parameters("@NUMEROCUENTA").Value = DBNull.Value
        End Select
        Comando.Parameters("@SUMINISTROTRANSPORTE").Value = IIf(Ck_SuministroTransporte.CheckState = CheckState.Checked, "S", "N")
        Comando.Parameters("@SUMINISTROCAMPAMENTO").Value = IIf(Ck_SuministroCampamento.CheckState = CheckState.Checked, "S", "N")
        Comando.Parameters("@DECOMUNIDAD").Value = IIf(Ck_DeLaComunidad.CheckState = CheckState.Checked, "S", "N")
        Comando.Parameters("@CONCEPTODEDUCIONRETEFUENTE").Value = Trim(Tx_ConceptoRetefuente.Text)
        Comando.Parameters("@VALORDEDUCIONRETEFUENTE").Value = ValorReal(Tx_ValorDeducciónRetefuente.Text)
        Comando.Parameters("@DECLARARENTA").Value = IIf(Ck_DeclaraRenta.CheckState = CheckState.Checked, "S", "N")
        If Cb_EntidadAFConstruccion.SelectedValue > 0 Then
            Comando.Parameters("@CODIGOENTIDADAFCONSTRUCCION").Value = Cb_EntidadAFConstruccion.SelectedValue
        Else
            Comando.Parameters("@CODIGOENTIDADAFCONSTRUCCION").Value = DBNull.Value
        End If
        If ValorReal(Tx_ValorAFConstruccion.Text) > 0 Then
            Comando.Parameters("@VALORAFCONSTRUCCION").Value = ValorReal(Tx_ValorAFConstruccion.Text)
        Else
            Comando.Parameters("@VALORAFCONSTRUCCION").Value = DBNull.Value
        End If
        If Cb_TipoJornada.SelectedValue Is vbNullChar Then
            Comando.Parameters("@TIPOJORNADA").Value = DBNull.Value
        Else
            Comando.Parameters("@TIPOJORNADA").Value = Cb_TipoJornada.SelectedValue
        End If
        'Entidades
        Comando.Parameters("@CODIGOENTIDADADMINEPS").Value = Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedValue
        If Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONEPS").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONEPS").Value = Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Value
        End If
        If ValorReal(Tx_ValorUPC.Text) > 0 Then
            Comando.Parameters("@VALORUPC").Value = ValorReal(Tx_ValorUPC.Text)
        Else
            Comando.Parameters("@VALORUPC").Value = DBNull.Value
        End If
        Comando.Parameters("@CODIGOENTIDADADMINARL").Value = Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.SelectedValue
        If Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONARL").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONARL").Value = Cu_EntidadAdministradora_ARL.Dtp_FechaAfiliacion.Value
        End If
        Comando.Parameters("@CODIGOENTIDADADMINAFP").Value = Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedValue
        If Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONAFP").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONAFP").Value = Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Value
        End If
        Comando.Parameters("@CODIGOENTIDADADMINAFC").Value = Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedValue
        If Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONAFC").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONAFC").Value = Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Value
        End If
        Comando.Parameters("@CODIGOENTIDADADMINCCF").Value = Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.SelectedValue
        If Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONCCF").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONCCF").Value = Cu_EntidadAdministradora_CCF.Dtp_FechaAfiliacion.Value
        End If
        If Not IsNothing(Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedValue) AndAlso Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedIndex > 0 Then
            Comando.Parameters("@CODIGOENTIDADADMINEPV").Value = Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedValue
        Else
            Comando.Parameters("@CODIGOENTIDADADMINEPV").Value = DBNull.Value
        End If
        If Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONEPV").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONEPV").Value = Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value
        End If
        If ValorReal(Tx_ValorAPV.Text) > 0 Then
            Comando.Parameters("@VALORAPORTEVOLUNTARIOPENSION").Value = ValorReal(Tx_ValorAPV.Text)
        Else
            Comando.Parameters("@VALORAPORTEVOLUNTARIOPENSION").Value = DBNull.Value
        End If
        Comando.Parameters("@COTIZO50SEMANASULTIMOAÑO").Value = IIf(Ck_Cotizado50Semanas.CheckState = CheckState.Checked, "S", "N")
        Comando.Parameters("@SEMANASFALTAN").Value = Nud_FaltanSemanas.Value
        Comando.Parameters("@TOTALSEMANASAFP").Value = Nud_TotalSemanas.Value
        Comando.Parameters("@FECHAEXPEDICION50SEMANAS").Value = Dtp_Expedición50Semanas.Value
        Comando.Parameters("@REQUIERECOLECTIVOVIDA").Value = IIf(Ck_RequiereColectivoVida.CheckState = CheckState.Checked, "S", "N")
        Comando.Parameters("@APORTAFIC").Value = IIf(Ck_AportaFIC.CheckState = CheckState.Checked, "S", "N")
        If Ck_AfiliadoSindicato.Checked Then
            Comando.Parameters("@AFILIADOSINDICATO").Value = "S"
            Comando.Parameters("@CODIGOSINDICATO").Value = Cb_Sindicatos.SelectedValue
            Comando.Parameters("@DESCUENTOSINDICATO").Value = IIf(Ck_DescuentoSindical.CheckState = CheckState.Checked, "S", "N")
            If Ck_DescuentoSindical.Checked Then
                Comando.Parameters("@PORCENTAJESINDICATO").Value = Nud_PorcentSindicato.Value
            Else
                Comando.Parameters("@PORCENTAJESINDICATO").Value = DBNull.Value
            End If
        Else
            Comando.Parameters("@AFILIADOSINDICATO").Value = "N"
            Comando.Parameters("@CODIGOSINDICATO").Value = DBNull.Value
            Comando.Parameters("@DESCUENTOSINDICATO").Value = DBNull.Value
            Comando.Parameters("@PORCENTAJESINDICATO").Value = DBNull.Value
        End If
        Comando.Parameters("@DESCUENTOSINDICATO").Value = IIf(Ck_DescuentoSindical.CheckState = CheckState.Checked, "S", "N")

        If CuBP_JefeInmediato.Cb_Persona.SelectedValue > 0 Then
            Comando.Parameters("@IDPERSONAJEFEINMEDIATO").Value = CuBP_JefeInmediato.Cb_Persona.SelectedValue
        Else
            Comando.Parameters("@IDPERSONAJEFEINMEDIATO").Value = DBNull.Value
        End If
        If Trim(Tx_FrenteTrabajo.Text) <> "" Then
            Comando.Parameters("@NOMBREFRENTETRABAJO").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_FrenteTrabajo.Text)
        Else
            Comando.Parameters("@NOMBREFRENTETRABAJO").Value = DBNull.Value
        End If
        If Trim(Tx_AgenciaEmpleo.Text) <> "" Then
            Comando.Parameters("@AGENCIAEMPLEO").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_AgenciaEmpleo.Text)
        Else
            Comando.Parameters("@AGENCIAEMPLEO").Value = DBNull.Value
        End If
        If Trim(Tx_NumeroVacante.Text) <> "" Then
            Comando.Parameters("@NUMEROVACANTE").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_NumeroVacante.Text)
        Else
            Comando.Parameters("@NUMEROVACANTE").Value = DBNull.Value
        End If
        If Not IsNothing(Cu_CentroCostoContrato.IdCentroCosto) AndAlso Cu_CentroCostoContrato.IdCentroCosto > 0 Then
            Comando.Parameters("@IDCENTROCOSTO").Value = Cu_CentroCostoContrato.IdCentroCosto
        Else
            Comando.Parameters("@IDCENTROCOSTO").Value = VariablesBase.VariablesBase.IdCentroCostoSisControl
        End If
        If TipoAccion <> "T" Then 'No es terminación
            Comando.Parameters("@CODIGOTIPOTERMINACIONCONTRATO").Value = DBNull.Value
            Comando.Parameters("@DESCRIPCIONMOTIVORETIRO").Value = ""
            Comando.Parameters("@FECHATERMINACIONCONTRATO").Value = DBNull.Value
            Comando.Parameters("@FECHARETIROCONTRATO").Value = DBNull.Value
            Comando.Parameters("@LUGARRECLAMALIQUIDACION").Value = DBNull.Value
            Comando.Parameters("@DEVOLUCIONCARNET").Value = DBNull.Value
            Comando.Parameters("@PAZYSALVO").Value = DBNull.Value
            Comando.Parameters("@CARTA_POR_IC_ACTIVO").Value = DBNull.Value
            Comando.Parameters("@GLOSASOPENDIENTES").Value = DBNull.Value
        Else
            Comando.Parameters("@CODIGOTIPOTERMINACIONCONTRATO").Value = Cb_TipoTerminaciónContrato.SelectedValue
            Comando.Parameters("@DESCRIPCIONMOTIVORETIRO").Value = Trim(Tx_MotivoRetiro.Text)
            Comando.Parameters("@FECHATERMINACIONCONTRATO").Value = Dtp_FechaTerminaciónContrato.Value
            Comando.Parameters("@FECHARETIROCONTRATO").Value = Dtp_FechaTerminaciónContrato.Value
            Comando.Parameters("@LUGARRECLAMALIQUIDACION").Value = Trim(Tx_LugarReclamación.Text)
            Comando.Parameters("@DEVOLUCIONCARNET").Value = IIf(Ck_DevolvioCarnet.CheckState = CheckState.Checked, "S", "N")
            Comando.Parameters("@PAZYSALVO").Value = IIf(Ck_EntregoPazSalvo.CheckState = CheckState.Checked, "S", "N")
            Comando.Parameters("@CARTA_POR_IC_ACTIVO").Value = IIf(Ck_CartaICActivo.CheckState = CheckState.Checked, "S", "N")
            Comando.Parameters("@GLOSASOPENDIENTES").Value = Trim(Tx_GlosasOPendientes.Text)
        End If

        Comando.Parameters("@IDTIPORECURSO").Value = Cb_TipoRecurso.SelectedValue
        Comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona
        Comando.Parameters("@TIP_CONTRATO_CONCEPTO").Value = dtConceptosContrato

        Comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Comando.Parameters.Add(New SqlParameter("@IDCONTRATONUEVO", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

        'Ejecución del procedimiento
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
            Select Case Comando.Parameters("@IDMENSAJE").Value
                Case 0
                    MessageBox.Show("No se pudo realizar la operación.", "No se completo la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _guardado = False
                    Exit Sub
                Case 1
                    MessageBox.Show("El registro ha sido exitoso.", "CONTRATO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _guardado = True
                    Select Case TipoAccion
                        Case "T"
                            Dim frImprTerminacion As New Fr_ImprTerminacion(IdPersonaContratar, IdContrato_Modificar, Cb_TipoContrato.SelectedValue, Cb_Cargo_Desempeña.SelectedValue, Cb_Cargo_Desempeña.Text, Dtp_FechaTerminaciónContrato.Value, Cb_TipoTerminaciónContrato.SelectedValue)
                            frImprTerminacion.ShowDialog()
                        Case "I"
                            'Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
                            'Dim Array As New ArrayList
                            'climpresion.Idpersona = IdPersonaContratar
                            'climpresion.IdContrato = Comando.Parameters("@IDCONTRATONUEVO").Value
                            'climpresion.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                            If MessageBox.Show("¿Desea imprimir los formatos de contratación?", "IMPRIMIR FORMATOS", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                                Try
                                    Dim FrImprimirFormatos As New ImprimirRecursoHumano.Fr_ImprimirFormatos
                                    FrImprimirFormatos.IDPERSONA = IdPersonaContratar
                                    FrImprimirFormatos.IDCONTRATO = Comando.Parameters("@IDCONTRATONUEVO").Value
                                    FrImprimirFormatos.IDBASE = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                                    FrImprimirFormatos.CODIGOTIPO = Cb_TipoContrato.SelectedValue
                                    FrImprimirFormatos.cargarformatos()
                                    'Quitar Formatos segun tipo de contrato
                                    FrImprimirFormatos.Label1.Visible = False
                                    FrImprimirFormatos.ComboBox_Cargo_Desempeña.Visible = False
                                    FrImprimirFormatos.ShowDialog()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Imprimir Formatos Contratación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                                'Select Case Cb_TipoContrato.SelectedValue
                                '    Case TipoContrato.ICAGRALF117
                                '        Array.Add(20)
                                '    Case TipoContrato.ICAGRALF122
                                '        Array.Add(21)
                                '    Case TipoContrato.ICAGRALF121
                                '        Array.Add(22)
                                '    Case TipoContrato.ICAGRALF118
                                '        Array.Add(23)
                                '    Case TipoContrato.ICAGRALF123
                                '        Array.Add(24)
                                '    Case TipoContrato.ICAGRALF119
                                '        Array.Add(25)
                                '    Case TipoContrato.ICAGRALF124
                                '        Array.Add(26)
                                '    Case TipoContrato.ObraEsDCMSI
                                '        Array.Add(27)
                                '    Case TipoContrato.ICAGRALF120
                                '        Array.Add(28)
                                '    Case TipoContrato.ICAGRALF125
                                '        Array.Add(29)
                                '    Case TipoContrato.TIEsDCM
                                '        Array.Add(30)
                                '    Case TipoContrato.TIEsDCMSI
                                '        Array.Add(31)
                                'End Select
                            End If
                            'If Array.Count > 0 Then
                            '    climpresion.FormatosImprimir(Array, True)
                            'End If
                        Case "E"
                            Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
                            Dim Array As New ArrayList
                            climpresion.Idpersona = IdPersonaContratar
                            climpresion.IdContrato = IdContrato_Modificar
                            climpresion.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                            If MessageBox.Show("¿Desea imprimir el Formato F14?", "IMPRIMIR FORMATO F14", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                                Array.Add(70)
                                climpresion.inicialF14 = ""
                                climpresion.modificaciónF14 = "X"
                            End If
                            If Array.Count > 0 Then
                                climpresion.FormatosImprimir(Array, True)
                            End If
                    End Select
                    Me.Close()
                Case 2 'No hay códigos de contrato disponibles para la base.
                    MessageBox.Show("No hay códigos de contrato disponibles para la base actual.", "No se completo la operación", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    _guardado = False
                    Exit Sub
                Case 3 'No hubo cambios por guardar
                    _guardado = False
                    Me.Close()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function Validar_CodDisponibles() As Boolean
        Dim CantidadDisponible As Integer = 0
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.[ValorCodigosContratoDisponibles](@IDBASECONTRATADO , @CODIGOTIPOSALARIO)", conexion)
        comando.Parameters.AddWithValue("@IDBASECONTRATADO", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@CODIGOTIPOSALARIO", Cb_TipoSalario.SelectedValue)
        conexion.Open()

        Try

            CantidadDisponible = comando.ExecuteScalar()
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Connection.Close()
        End Try

        If (CantidadDisponible > 0) And (CantidadDisponible < 31) Then

            MsgBox("Faltan " + Str(CantidadDisponible) + " códigos de contrato para finalizar el rango asignado a la base, por favor gestionar en el área de nómina la asignación de un nuevo rango de códigos. Una vez obtenga el nuevo rango, por favor informar al área de soporte aplicaciones y consultas sigma, para la configuración del sistema", MsgBoxStyle.Information, "CÓDIGOS CONTRATO DISPONIBLES")
            Return True

        End If
        Return True
    End Function

    ''' <summary>Validación de los datos del contrato.</summary>
    ''' <returns>Verdadero si los datos son válidos. Falso si hay algún dato inválido.</returns>
    ''' 
    Private Function Validar_Contrato() As Boolean
        Select Case TipoAccion
            Case "I", "E" 'insertar, editar
                If Cb_TipoContrato.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de contrato", MsgBoxStyle.Information, "SELECCIONAR TIPO CONTRATO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_TipoContrato.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_Cargo_Desempeña.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el cargo para el cual fue contratado", MsgBoxStyle.Information, "SELECCIONAR TIPO CONTRATO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_Cargo_Desempeña.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_Categoría.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la categoría del cargo", MsgBoxStyle.Information, "SELECCIONAR CATEGORÍA DEL CARGO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_Categoría.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_TipoGrupo.SelectedIndex < 0 Then 'Seleccionar grupo para evitar error de parámetro en el procedimiento almacenado.
                    MsgBox("Debe seleccionar el grupo del cargo", MsgBoxStyle.Information, "SELECCIONAR GRUPO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_TipoGrupo.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_TipoSalario.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de salario", MsgBoxStyle.Information, "SELECCIONAR TIPO SALARIO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_TipoSalario.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_TipoSalario.SelectedValue = "D" Then 'Diario
                    If Not IsNumeric(Tx_Salario.Text) Then
                        MsgBox("El salario no es válido")
                        Tc_Contrato.SelectedTab = Tp_Basico
                        Tx_Salario.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                    If Tx_Salario.Text > 100000 Then
                        If MsgBox("El salario es elevado para el tipo de contrato, ¿Desea continuar?", MsgBoxStyle.YesNo, "SALARIO ALTO") = MsgBoxResult.No Then
                            Tc_Contrato.SelectedTab = Tp_Basico
                            Tx_Salario.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                    End If
                Else
                    If Not IsNumeric(Tx_Salario.Text) Then
                        MsgBox("El salario no es válido")
                        Tc_Contrato.SelectedTab = Tp_Basico
                        Tx_Salario.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                    If Tx_Salario.Text < 700000 Then
                        If MsgBox("El salario es muy bajo para el tipo de contrato, ¿Desea continuar?", MsgBoxStyle.YesNo, "SALARIO BAJO") = MsgBoxResult.No Then
                            Tc_Contrato.SelectedTab = Tp_Basico
                            Tx_Salario.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                    End If
                End If
                If Not IsNumeric(Tx_Salario.Text) Then
                    MsgBox("El valor del salario no es valido.", MsgBoxStyle.Critical, "SALARIO NO VÁLIDO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Tx_Salario.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_TipoDuración.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de duración del contrato", MsgBoxStyle.Information, "SELECCIONAR TIPO DURACIÓN CONTRATO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_TipoDuración.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_CategoríaPersonal.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la categoría del personal", MsgBoxStyle.Information, "SELECCIONAR CATEGORÍA DEL PERSONAL")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_CategoríaPersonal.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                If Cb_TipoRecurso.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de recurso del personal", MsgBoxStyle.Information, "SELECCIONAR TIPO RECURSO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_TipoRecurso.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                Select Case Cb_TipoDuración.SelectedValue
                    Case "M" 'Meses
                        If listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) OrElse listaContratosTermIndef.Contains(Cb_TipoContrato.SelectedValue) Then
                            MsgBox("La duración no corresponde con el tipo de contrato", MsgBoxStyle.Information, "DURACIÓN DEL CONTRATO")
                            Cb_TipoDuración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                        If NUD_Duración.Value <= 0 Then
                            MsgBox("La duración no corresponde con el tipo de contrato", MsgBoxStyle.Information, "DURACIÓN DEL CONTRATO")
                            NUD_Duración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                        If NUD_Duración.Value > 12 Then
                            MsgBox("La duración sobrepasa el año de contratación", MsgBoxStyle.Information, "SELECCIONAR TIPO DE DURACIÓN")
                            NUD_Duración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                    Case "D" 'Días
                        If listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) OrElse listaContratosTermIndef.Contains(Cb_TipoContrato.SelectedValue) Then
                            MsgBox("La duración no corresponde con el tipo de contrato", MsgBoxStyle.Information, "DURACIÓN DEL CONTRATO")
                            Cb_TipoDuración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                        If NUD_Duración.Value <= 0 Then
                            MsgBox("La duración no corresponde con el tipo de contrato", MsgBoxStyle.Information, "DURACIÓN DEL CONTRATO")
                            NUD_Duración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                    Case "N" 'No Aplica
                        If listaContratosTermFijo.Contains(Cb_TipoContrato.SelectedValue) Then
                            MsgBox("La duración no corresponde con el tipo de contrato", MsgBoxStyle.Information, "DURACIÓN DEL CONTRATO")
                            Cb_TipoDuración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                        If NUD_Duración.Value <> 0 Then
                            MsgBox("La duración no corresponde con el tipo de contrato", MsgBoxStyle.Information, "DURACIÓN DEL CONTRATO")
                            NUD_Duración.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                End Select
                If CompararFechas(Dtp_FechaInicioContrato.Value, Date.Now) = 1 Then
                    If MsgBox("La fecha de Inicio del contrato es anterior a la fecha actual, ¿Desea Continuar?", MsgBoxStyle.YesNo, "FECHA INICIO CONTRATO") = MsgBoxResult.No Then
                        Tc_Contrato.SelectedTab = Tp_Basico
                        Dtp_FechaInicioContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                Select Case CompararFechas(Dtp_FechaFirmaContrato.Value, Dtp_FechaInicioContrato.Value)
                    Case -1
                        If MsgBox("La fecha de firma del contrato es Posterior a la fecha de inicio del contrato, ¿Desea Continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA CONTRATO") = MsgBoxResult.No Then
                            Tc_Contrato.SelectedTab = Tp_Basico
                            Dtp_FechaFirmaContrato.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                    Case 1
                        If MsgBox("La fecha de firma del contrato es Anterior a la fecha de inicio del contrato, ¿Desea Continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA CONTRATO") = MsgBoxResult.No Then
                            Tc_Contrato.SelectedTab = Tp_Basico
                            Dtp_FechaFirmaContrato.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                End Select
                'Validar la fecha de terminación de acuerdo al tipo de contrato
                If listaContratosTermFijo.Contains(Cb_TipoContrato.SelectedValue) Then
                    If CompararFechas(DTP_FechaTerminaciónContratoInicial.Value, Dtp_FechaFirmaContrato.Value) = 1 Then
                        MsgBox("La fecha de terminación inicial de contrato es inferior a la fecha de contrato inicial.", MsgBoxStyle.Information, "FECHA DE FIRMA DEL CONTRATO")
                        Tc_Contrato.SelectedTab = Tp_Basico
                        DTP_FechaTerminaciónContratoInicial.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                If Cb_RolProyecto.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el rol en el proyecto.", MsgBoxStyle.Information, "SELECCIONAR EL ROL EN EL PROYECTO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_RolProyecto.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                'Si es contrato por obra o labor debe describir la labor contratada.
                If listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) Then
                    If Trim(Tx_LaborContratada.Text) = "" Then
                        MsgBox("Debe indicar la labor para la cual fue contratado.", MsgBoxStyle.Information, "INDICAR LA LABOR")
                        Tc_Contrato.SelectedTab = Tp_Basico
                        Cb_TipoContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                Else
                    'Sólo se describe la labor contratada si es contrato por obra o labor.
                    If Trim(Tx_LaborContratada.Text) <> "" Then
                        MsgBox("El tipo de contrato debe ser Contrato de Obra o labor.", MsgBoxStyle.Information, "INDICAR LA LABOR CONTRATADA")
                        Tc_Contrato.SelectedTab = Tp_Basico
                        Cb_TipoContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                If Cu_CiudadContratación.Cb_Ciudad.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la ciudad o municipio de contratación.", MsgBoxStyle.Critical, "CIUDAD DE ORIGEN")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cu_CiudadContratación.Cb_Ciudad.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cu_CiudadLabores.Cb_Ciudad.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la ciudad o municipio de labores.", MsgBoxStyle.Critical, "CIUDAD DE ORIGEN")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cu_CiudadLabores.Cb_Ciudad.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If CuBP_JefeInmediato.Cb_Persona.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el Jefe Inmediato.", MsgBoxStyle.Critical, "JEFE INMEDIATO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    CuBP_JefeInmediato.Cb_Persona.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                If Cb_TipoTurno.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de turno", MsgBoxStyle.Information, "SELECCIONAR EL TIPO DE TURNO")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Cb_TipoTurno.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_PeriodoPago.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de periodo de pago", MsgBoxStyle.Information, "SELECCIONAR TIPO CONTRATO")
                    Tc_Contrato.SelectedTab = Tp_Complemento
                    Cb_PeriodoPago.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cb_TipoPago.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar el tipo de pago", MsgBoxStyle.Information, "SELECCIONAR TIPO DE PAGO")
                    Tc_Contrato.SelectedTab = Tp_Complemento
                    Cb_TipoPago.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                If Cb_TipoPago.SelectedValue = "A" Then 'Abono Cuenta
                    If Cb_Banco.Enabled Then
                        If Cb_Banco.SelectedIndex < 0 Then
                            MsgBox("Debe seleccionar el banco", MsgBoxStyle.Information, "SELECCIONAR BANCO")
                            Tc_Contrato.SelectedTab = Tp_Complemento
                            Cb_Banco.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                    End If
                    If Tx_NumeroCuenta.Text = "" Then
                        MsgBox("Debe ingresar el número de cuenta", MsgBoxStyle.Information, "DIGITE NUMERO DE CUENTA")
                        Tc_Contrato.SelectedTab = Tp_Complemento
                        Tx_NumeroCuenta.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                    If Cb_TipoCuenta.SelectedIndex < 0 Then
                        MsgBox("Debe seleccionar el tipo de cuenta", MsgBoxStyle.Information, "SELECCIONAR TIPO CONTRATO")
                        Tc_Contrato.SelectedTab = Tp_Complemento
                        Cb_TipoCuenta.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                Else 'Pago en cheque

                End If
                If Ck_SuministroTransporte.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si se suministra transporte", MsgBoxStyle.Critical, "SUMINISTRA TRANSPORTE")
                    Tc_Contrato.SelectedTab = Tp_Complemento
                    Ck_SuministroTransporte.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_SuministroCampamento.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si se suministra campamento", MsgBoxStyle.Critical, "SUMINISTRA CAMPAMENTO")
                    Tc_Contrato.SelectedTab = Tp_Complemento
                    Ck_SuministroCampamento.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_DeLaComunidad.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si es de la comunidad", MsgBoxStyle.Critical, "ES DE LA COMUNIDAD")
                    Tc_Contrato.SelectedTab = Tp_Basico
                    Ck_DeLaComunidad.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Tx_ConceptoRetefuente.Text <> "" Then
                    If Tx_ValorDeducciónRetefuente.Text = "" Then
                        MsgBox("Debe digitar el valor de deducción en la fuente", MsgBoxStyle.Critical, "VALOR DE DEDUCCIÓN EN LA FUENTE")
                        Tc_Contrato.SelectedTab = Tp_Complemento
                        Tx_ValorDeducciónRetefuente.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                    If Not IsNumeric(Tx_ValorDeducciónRetefuente.Text) Then
                        MsgBox("La dedución en la fuente no es válido")
                        Tc_Contrato.SelectedTab = Tp_Complemento
                        Tx_ValorDeducciónRetefuente.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                If Ck_DeclaraRenta.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si declara renta", MsgBoxStyle.Critical, "DECLARA RENTA")
                    Tc_Contrato.SelectedTab = Tp_Complemento
                    Ck_DeclaraRenta.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                dtConceptosContrato.AcceptChanges()
                If dtConceptosContrato.Rows.Count = 0 Then
                    If MsgBox("No tiene conceptos asociados, ¿Desea Continuar?", MsgBoxStyle.YesNo, "SIN CONCEPTOS") = MsgBoxResult.No Then
                        Tc_Contrato.SelectedTab = Tp_Complemento
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                If Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la Entidad Prestadora de Salud.", MsgBoxStyle.Critical, "ENTIDAD PRESTADORA DE SALUD")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la Administradora de Riesgos Laborales.", MsgBoxStyle.Critical, "ADMINISTRADORA DE RIESGOS LABORALES")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Cu_EntidadAdministradora_ARL.Cb_NombreAdministradora.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la Administradora de Fondo de Pensiones.", MsgBoxStyle.Critical, "ADMINISTRADORA DE FONDO DE PENSIONES")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la Administradora de Fondo de Cesantias.", MsgBoxStyle.Critical, "ADMINISTRADORA DE FONDO DE CESANTÍAS")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar la Administradora de Caja de Compensacion Familiar.", MsgBoxStyle.Critical, "ADMINISTRADORA DE CAJA DE COMPENSACIÓN FAMILIAR")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Cu_EntidadAdministradora_CCF.Cb_NombreAdministradora.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_Cotizado50Semanas.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar ha cotizado 50 semanas en los ultimos tres años", MsgBoxStyle.Critical, "HA COTIZADO 50 SEMANAS EN LOS ÚLTIMOS TRES AÑOS")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Ck_Cotizado50Semanas.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Nud_TotalSemanas.Value = -1 Then
                    MsgBox("No se han registrado el Total  semanas cotizadas en el fondo de pensiones ", MsgBoxStyle.Critical, "Total  semanas cotizadas en el fondo de pensiones")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Nud_TotalSemanas.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If


                If Dtp_Expedición50Semanas.Checked = False Then
                    MsgBox("Debe seleccionar la fecha de generación historia laboral ", MsgBoxStyle.Critical, "Fecha de generación historia laboral")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Validar_Contrato = False
                    Dtp_Expedición50Semanas.Focus()
                    Exit Function
                End If
                If Ck_RequiereColectivoVida.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si requiere colectivo de vida", MsgBoxStyle.Critical, "REQUIERE COLECTIVO DE VIDA")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Ck_RequiereColectivoVida.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_AportaFIC.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si aporta al Fondo Nacional de Formación Profesional de la Industria de la Construcción (FIC)", MsgBoxStyle.Critical, "APORTA A FIC")
                    Tc_Contrato.SelectedTab = Tp_Entidades
                    Ck_AportaFIC.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_AfiliadoSindicato.Checked Then
                    If Cb_Sindicatos.SelectedIndex < 0 Then
                        MsgBox("Debe seleccionar un sindicato", MsgBoxStyle.Information, "SINDICATO")
                        Tc_Contrato.SelectedTab = Tp_Entidades
                        Cb_Sindicatos.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                    If Cb_Sindicatos.SelectedValue <> 1 Then
                        If Ck_DescuentoSindical.CheckState = CheckState.Indeterminate Then
                            MsgBox("Debe seleccionar si autoriza descuento sindical o no", MsgBoxStyle.Critical, "DESCUENTO SINDICAL")
                            Tc_Contrato.SelectedTab = Tp_Entidades
                            Ck_DescuentoSindical.Focus()
                            Validar_Contrato = False
                            Exit Function
                        End If
                        If Ck_DescuentoSindical.Checked Then
                            If Nud_PorcentSindicato.Value <= 0 OrElse Nud_PorcentSindicato.Value > 100 Then
                                MsgBox("Debe indicar el porcentaje de aporte sindical.", MsgBoxStyle.Critical, "DESCUENTO SINDICAL")
                                Tc_Contrato.SelectedTab = Tp_Entidades
                                Nud_PorcentSindicato.Focus()
                                Validar_Contrato = False
                                Exit Function
                            End If
                        End If
                    End If
                End If
                'Validar Fechas en dias Sabados, Domingos y festivos
                If Dtp_FechaInicioContrato.Value.DayOfWeek = DayOfWeek.Sunday Then
                    If MsgBox("La fecha de inicio de contrato es un Domingo, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                        Dtp_FechaInicioContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If

                If Dtp_FechaInicioContrato.Value.DayOfWeek = DayOfWeek.Saturday Then
                    If MsgBox("La fecha de inicio de contrato es un Sabado, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                        Dtp_FechaInicioContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If

                If ValidarFestivo(Dtp_FechaInicioContrato.Value) = True Then
                    If MsgBox("La fecha de inicio de contrato es un festivo, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                        Dtp_FechaInicioContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                If Dtp_FechaFirmaContrato.Value.DayOfWeek = DayOfWeek.Sunday Then
                    If MsgBox("La fecha de la firma del contrato es un Domingo, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                        Dtp_FechaFirmaContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If

                If Dtp_FechaFirmaContrato.Value.DayOfWeek = DayOfWeek.Saturday Then
                    If MsgBox("La fecha de la firma del contrato es un Sabado, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                        Dtp_FechaFirmaContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If

                If ValidarFestivo(Dtp_FechaFirmaContrato.Value) = True Then
                    If MsgBox("La fecha de la firma del contrato es un festivo, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                        Dtp_FechaFirmaContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If

                If IsNumeric(Nud_TotalSemanas.Text) = False Then
                    MsgBox("El valor de Administración debe ser numérico", MsgBoxStyle.Critical, "Total  semanas cotizadas en el fondo de pensiones")
                    Nud_TotalSemanas.Text = ""
                    Me.Nud_TotalSemanas.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                If Nud_TotalSemanas.Value > 2500 Then
                    MsgBox("EL total semanas contizadas en el fondo de pension debe ser menor a 2500 semanas", MsgBoxStyle.Critical, "Total  semanas cotizadas en el fondo de pensiones")
                    Me.Nud_TotalSemanas.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
            Case "T" 'terminar
                If Cb_TipoTerminaciónContrato.SelectedIndex < 0 Then
                    MsgBox("Debe seleccionar si el tipo de terminación de contrato", MsgBoxStyle.Critical, "TIPO TERMINACIÓN CONTRATO")
                    Cb_TipoTerminaciónContrato.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If CompararFechas(Dtp_FechaInicioContrato.Value, Dtp_FechaTerminaciónContrato.Value) = -1 Then
                    MsgBox("La fecha de terminación no puede ser inferior a la fecha de contrato", MsgBoxStyle.Critical, "FECHA TERMINACIÓN")
                    Dtp_FechaTerminaciónContrato.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                'validar la fecha de terminación con las prórrogas
                If dtProrrogas.Rows.Count > 0 Then 'existen prórrogas
                    Dim FechaMaximaInicioUltimaProrroga As Date
                    Dim FechaMaximaTerminaciónProrroga As Date
                    FechaMaximaInicioUltimaProrroga = dtProrrogas.Compute("MAX(FECHAINICIO)", "ESTADOPRORROGA = 'ACTIVO'")
                    FechaMaximaTerminaciónProrroga = dtProrrogas.Compute("MAX(FECHAFIN)", "ESTADOPRORROGA = 'ACTIVO'")
                    If CompararFechas(FechaMaximaInicioUltimaProrroga, Dtp_FechaTerminaciónContrato.Value) = -1 Then
                        MsgBox("La fecha de terminación no puede ser inferior a la fecha de inicio de la última prroroga", MsgBoxStyle.Critical, "FECHA TERMINACIÓN")
                        Dtp_FechaTerminaciónContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                    If CompararFechas(FechaMaximaTerminaciónProrroga, Dtp_FechaTerminaciónContrato.Value) = 1 AndAlso FilaContrato("ESTADOCONTRATO") = "A" Then 'No aplica para contratos Extendidos o Suspendidos
                        MsgBox("La fecha de terminación no puede ser superior a la fecha de fin de la última prroroga", MsgBoxStyle.Critical, "FECHA TERMINACIÓN")
                        Dtp_FechaTerminaciónContrato.Focus()
                        Validar_Contrato = False
                        Exit Function
                    End If
                End If
                If Ck_DevolvioCarnet.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si devolvió o no el carnet", MsgBoxStyle.Critical, "DEVOLUCIÓN DE CARNET")
                    Ck_DevolvioCarnet.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_EntregoPazSalvo.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar si devolvio entrego PAZ Y SALVO", MsgBoxStyle.Critical, "PAZ Y SALVO")
                    Ck_EntregoPazSalvo.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If
                If Ck_CartaICActivo.CheckState = CheckState.Indeterminate Then
                    MsgBox("Debe seleccionar tiene carta por Incapacidad Activo", MsgBoxStyle.Critical, "CARTA INCAPACIDAD ACTIVO")
                    Ck_CartaICActivo.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                If IsNumeric(Nud_TotalSemanas.Text) = False Then
                    MsgBox("El valor de Administración debe ser numérico", MsgBoxStyle.Critical, "VALOR ADMINISTRACIÓN")
                    Nud_TotalSemanas.Text = ""
                    Me.Nud_TotalSemanas.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If

                If Nud_TotalSemanas.Value > 2500 Then
                    MsgBox("EL total semanas contizadas en el fondo de pension debe ser menos a 2500 semanas", MsgBoxStyle.Critical, "VALOR ADMINISTRACIÓN")
                    Me.Nud_TotalSemanas.Focus()
                    Validar_Contrato = False
                    Exit Function
                End If


        End Select
        Validar_Contrato = True
    End Function
    Private Sub Nud_TotalSemanas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nud_TotalSemanas.KeyPress
        If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Function ValidarFestivo(fecha As Date) As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.EsFestivo(@FECHA)", conexion)
        comando.Parameters.AddWithValue("@FECHA", fecha)
        Dim esFestivo As Boolean
        Try
            comando.Connection.Open()
            esFestivo = comando.ExecuteScalar()
            comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Connection.Close()
        End Try
        If esFestivo = True Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Devuelve:
    ''' 1 si la fecha inicial es menor a la fecha final,
    ''' 0 si la fecha inicial es igual a la fecha final,
    ''' -1 si la fecha inicial es mayor a la fecha final.
    ''' </summary>
    ''' <param name="FECHAINICIAL">Fecha inicial</param>
    ''' <param name="FECHAFIN">Fecha final</param>
    ''' <returns>Si la fecha inicial es menor, igual o mayor que la fecha final</returns>
    Public Shared Function CompararFechas(ByVal FECHAINICIAL As Date, ByVal FECHAFIN As Date) As Integer
        Dim TFECHAINICIAL As New Date(FECHAINICIAL.Year, FECHAINICIAL.Month, FECHAINICIAL.Day)
        Dim TFECHAFINAL As New Date(FECHAFIN.Year, FECHAFIN.Month, FECHAFIN.Day)
        Select Case DateDiff(DateInterval.Day, TFECHAINICIAL, TFECHAFINAL)
            Case 0
                CompararFechas = 0
                Exit Function
            Case Is > 0
                CompararFechas = 1
                Exit Function
            Case Is < 0
                CompararFechas = -1
                Exit Function
        End Select
        CompararFechas = 2
    End Function
#End Region 'Validar y guardar Contrato

    ''' <summary>Dibuja en color rojo el fondo de los controles que están vacíos.</summary>
    Private Sub Marcar_Cajas_Vacias()
        If Cb_Cargo_Desempeña.SelectedIndex < 0 Then
            Cb_Cargo_Desempeña.BackColor = Drawing.Color.Salmon
        End If
        If Tx_Salario.Text = "" Then
            Tx_Salario.BackColor = Drawing.Color.Salmon
        End If
        If Cb_Banco.SelectedIndex < 0 Then
            Cb_Banco.BackColor = Drawing.Color.Salmon
        End If
        If Tx_NumeroCuenta.Text = "" Then
            Tx_NumeroCuenta.BackColor = Drawing.Color.Salmon
        End If
        If Cb_Banco.SelectedIndex < 0 Then
            Cb_Banco.BackColor = Drawing.Color.Salmon
        End If
        If Cb_TipoContrato.SelectedIndex < 0 Then
            Cb_TipoContrato.BackColor = Drawing.Color.Salmon
        End If
        If Cb_RolProyecto.SelectedIndex < 0 Then
            Cb_RolProyecto.BackColor = Drawing.Color.Salmon
        End If
        If Cb_Categoría.SelectedIndex < 0 Then
            Cb_Categoría.BackColor = Drawing.Color.Salmon
        End If
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Tx_NumeroCuenta.GotFocus, Tx_Observación.GotFocus, Tx_FrenteTrabajo.GotFocus, Tx_AgenciaEmpleo.GotFocus, Tx_NumeroVacante.GotFocus

        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.MintCream
    End Sub

    Private Sub Caja_Texto_LostFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Tx_NumeroCuenta.LostFocus, Tx_Observación.LostFocus, Tx_FrenteTrabajo.LostFocus, Tx_AgenciaEmpleo.LostFocus, Tx_NumeroVacante.LostFocus

        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.White
        Marcar_Cajas_Vacias()
    End Sub

    Private Sub Cb_TipoSalario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoSalario.SelectedIndexChanged
        If TipoAccion = "I" Then 'insertar
            If listaContratosTermFijo.Contains(Cb_TipoContrato.SelectedValue) Then
                If Cb_TipoSalario.SelectedValue = "D" Then 'Diario
                    Cb_TipoDuración.SelectedValue = "D" 'Días
                Else
                    Cb_TipoDuración.SelectedValue = "M" 'Meses
                End If
                CalcularFechaTerminacionContrato()
            Else

            End If
        End If
    End Sub

    Private Sub Cb_TipoDuración_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoDuración.SelectedIndexChanged
        If TipoAccion = "I" Then 'insertar
            CalcularFechaTerminacionContrato()
        End If
    End Sub

    Private Sub DateTimePicker_FechaInicioContrato_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaInicioContrato.ValueChanged
        If TipoAccion = "I" Then 'insertar
            CalcularFechaTerminacionContrato()
        End If
    End Sub

    Private Sub NUD_Días_ValueChanged(sender As Object, e As EventArgs) Handles NUD_Duración.ValueChanged
        If TipoAccion = "I" Then 'insertar
            CalcularFechaTerminacionContrato()
        End If
    End Sub

    ''' <summary>Calcula las fechas de fecha de terminación inicial y fecha final del contrato.</summary>
    Private Sub CalcularFechaTerminacionContrato()
        Select Case TipoAccion
            Case "I", "E" 'ingresar, editar.
                DTP_FechaTerminaciónContratoInicial.Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dtp_FechaInicioContrato.Value, Cb_TipoDuración.SelectedValue, NUD_Duración.Value)
        End Select
    End Sub

    Private Sub TextBox_Observación_TextChanged(sender As Object, e As EventArgs) Handles Tx_Observación.TextChanged
        Lb_longitudobservación.Text = "(" & Tx_Observación.Text.Length & "/" & Tx_Observación.MaxLength & ")"
    End Sub

    Private Sub TextBox_Salario_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Tx_Salario.KeyPress, Tx_ValorDeducciónRetefuente.KeyPress, Tx_ValorAFConstruccion.KeyPress, Tx_ValorUPC.KeyPress, Tx_ValorAPV.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub TextBox_Salario_LostFocus(sender As Object, e As EventArgs) _
        Handles Tx_Salario.LostFocus, Tx_ValorDeducciónRetefuente.LostFocus, Tx_ValorAFConstruccion.LostFocus, Tx_ValorUPC.LostFocus, Tx_ValorAPV.LostFocus
        Dim Caja As TextBox = sender
        Dim Cadena As String = Replace(Caja.Text, "$", "")
        Cadena = Replace(Cadena, " ", "")
        Cadena = Replace(Cadena, miles, "")
        If Not IsNumeric(Cadena) Then
            Caja.BackColor = Drawing.Color.Salmon
        Else
            Caja.Text = Format(Cadena, "Currency")
            Caja.BackColor = Drawing.Color.White
        End If
    End Sub

    ''' <summary>Valor entero de una cadena con formato de moneda.</summary>
    ''' <param name="Cadena">Cadena de texto con el valor formateado.</param>
    ''' <returns>Valor numérico de la cadena.</returns>
    Private Function ValorReal(ByVal Cadena As String) As Integer
        Cadena = Replace(Cadena, "$", "")
        Cadena = Replace(Cadena, " ", "")
        Cadena = Replace(Cadena, miles, "")
        Cadena = Replace(Cadena, decimales & "00", "")
        If IsNumeric(Cadena) Then
            ValorReal = CInt(Cadena)
        Else
            ValorReal = -1
        End If
    End Function

    Private Sub Tx_LaborContratada_TextChanged(sender As Object, e As EventArgs) Handles Tx_LaborContratada.TextChanged
        Lb_LaborContratada.Text = "(" & Tx_LaborContratada.Text.Length & "/" & Tx_LaborContratada.MaxLength & ")"
    End Sub

    Private Sub ComboBox_TipoContrato_SelectedIndexChanged(sender As Object, e As EventArgs)
        If listaContratosTermFijo.Contains(Cb_TipoContrato.SelectedValue) Then
            Tx_LaborContratada.Enabled = False
            Lb_FechaTerminaciónContratoInicial.Visible = True
            DTP_FechaTerminaciónContratoInicial.Visible = True
            DTP_FechaTerminaciónContratoInicial.Checked = True
            'If TipoAccion = "I" Then
            '    Cb_TipoSalario.SelectedValue = "M" 'Mensual
            'End If
            NUD_Duración.Enabled = True
            Cb_TipoDuración.Enabled = True

        ElseIf listaContratosObraLabor.Contains(Cb_TipoContrato.SelectedValue) Then
            Tx_LaborContratada.Enabled = True
            Lb_FechaTerminaciónContratoInicial.Visible = False
            DTP_FechaTerminaciónContratoInicial.Visible = False
            DTP_FechaTerminaciónContratoInicial.Checked = False
            'Cambiar la duración del contrato a No Aplica
            NUD_Duración.Value = 0
            Cb_TipoDuración.SelectedValue = "N"
            NUD_Duración.Enabled = False
            Cb_TipoDuración.Enabled = False

        ElseIf listaContratosTermIndef.Contains(Cb_TipoContrato.SelectedValue) Then
            Tx_LaborContratada.Enabled = False
            Lb_FechaTerminaciónContratoInicial.Visible = False
            DTP_FechaTerminaciónContratoInicial.Visible = False
            DTP_FechaTerminaciónContratoInicial.Checked = False

            'Cambiar la duración del contrato a No Aplica
            NUD_Duración.Value = 0
            Cb_TipoDuración.SelectedValue = "N"
            NUD_Duración.Enabled = False
            Cb_TipoDuración.Enabled = False
        End If
    End Sub

    Private Sub Ck_Cotizado50Semanas_CheckStateChanged(sender As Object, e As EventArgs) 'Handles Ck_Cotizado50Semanas.CheckStateChanged
        If TipoAccion = "I" Then 'insertar
            If Ck_Cotizado50Semanas.CheckState = CheckState.Unchecked Then
                Lb_FaltanSemanas.Visible = True
                Nud_FaltanSemanas.Visible = True
                Ck_RequiereColectivoVida.CheckState = CheckState.Checked
            Else
                Lb_FaltanSemanas.Visible = False
                Nud_FaltanSemanas.Visible = False
                Ck_RequiereColectivoVida.CheckState = CheckState.Unchecked
            End If
        End If
    End Sub

    Private Sub Bt_Agregar_Click(sender As Object, e As EventArgs) Handles Bt_Agregar.Click
        Dim fila As DataRow
        fila = dtConceptosContrato.NewRow
        fila("CODIGOTIPOCONCEPTOCONTRATO") = idConceptoDefecto
        fila("VALOR") = 0
        fila("PERIODICIDAD") = "Mes"
        fila("ACTIVO") = "S"
        dtConceptosContrato.Rows.Add(fila)
    End Sub


    Private Sub Button_Aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Aceptar.Click
        Cursor.Current = Cursors.WaitCursor
        If Guardar_Datos() = True Then
            If TipoAccion = "I" Then
                Validar_CodDisponibles()
                Me.Close()
            Else
                If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                    Try
                        Cu_padre.Cargar_Tabla()
                    Catch
                    End Try
                End If
                Me.Close()
            End If
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Cancelar.Click
        If TipoAccion = "V" Then 'ver
            If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                Try
                    Cu_padre.Cargar_Tabla()
                Catch
                End Try
            End If
            Me.Close()
        Else
            Dim dr As DialogResult
            dr = MessageBox.Show("¿Desea salir sin guardar los cambios?", "SALIR", MessageBoxButtons.YesNo)
            If dr = DialogResult.Yes Then
                If MsgBox("¿Desea actualizar la lista?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                    Try
                        Cu_padre.Cargar_Tabla()
                    Catch
                    End Try
                End If
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Cb_Cargo_Desempeña_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Cargo_Desempeña.SelectedIndexChanged
        If TipoAccion = "I" Then 'ingresar
            If Not IsNothing(dtCargos) AndAlso dtCargos.Rows.Count > 0 Then
                'Cargar valores preconfigurados por tipo de cargo y base.
                Dim Filas() As DataRow
                Filas = dtCargos.Select("CODIGOTIPOCARGO=" & Cb_Cargo_Desempeña.SelectedValue)
                Dim Fila As DataRow = Filas(0)
                If Not IsDBNull(Fila("CODIGOTIPOCATEGORIA")) Then
                    Cb_Categoría.SelectedValue = Fila("CODIGOTIPOCATEGORIA")
                Else
                    Cb_Categoría.SelectedIndex = -1
                End If
                If Not IsDBNull(Fila("CODIGOTIPOSALARIO")) Then
                    Cb_TipoSalario.SelectedValue = Fila("CODIGOTIPOSALARIO")
                Else
                    Cb_TipoSalario.SelectedIndex = -1
                End If
                If Not IsDBNull(Fila("CODIGOTIPOGRUPO")) Then
                    Cb_TipoGrupo.SelectedValue = Fila("CODIGOTIPOGRUPO")
                Else
                    Cb_TipoGrupo.SelectedIndex = -1
                End If
                If Not IsDBNull(Fila("SALARIO")) Then
                    Tx_Salario.Text = Format(Fila("SALARIO"), "Currency")
                Else
                    Tx_Salario.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub Cb_TipoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoPago.SelectedIndexChanged
        If TipoAccion <> "V" Then 'ver
            If Cb_TipoPago.SelectedIndex >= 0 Then
                Select Case Cb_TipoPago.SelectedValue
                    Case "A" 'Abono Cuenta
                        Cb_Banco.Enabled = True
                        Cb_TipoCuenta.Enabled = True
                        Tx_NumeroCuenta.Enabled = True
                    Case "C" 'Cheque
                        Cb_Banco.Enabled = False
                        Cb_TipoCuenta.Enabled = False
                        Tx_NumeroCuenta.Enabled = False
                End Select
            End If
        End If
    End Sub

    Private Sub Ck_Cotizado50Semanas_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_Cotizado50Semanas.CheckedChanged
        If Ck_Cotizado50Semanas.CheckState = CheckState.Checked Then
            Lb_FaltanSemanas.Visible = False
            Nud_FaltanSemanas.Visible = False
        Else
            Lb_FaltanSemanas.Visible = True
            Nud_FaltanSemanas.Visible = True
        End If
    End Sub

    Public Sub cargarpersonalasociadobodega(idPersona As Integer, componente As String)
        Select Case componente
            Case CuBP_JefeInmediato.Name
                CuBP_JefeInmediato.CargarDatos(idPersona)
                CuBP_JefeInmediato.Cb_Persona.SelectedValue = idPersona
                CuBP_JefeInmediato.CargarCajaTexto()
        End Select
    End Sub

    Private Sub Ck_AfiliadoSindicato_CheckStateChanged(sender As Object, e As EventArgs) Handles Ck_AfiliadoSindicato.CheckStateChanged
        If Ck_AfiliadoSindicato.CheckState = CheckState.Checked Then
            Cb_Sindicatos.Enabled = True
            Ck_DescuentoSindical.Enabled = True
        Else
            Cb_Sindicatos.Enabled = False
            Ck_DescuentoSindical.Enabled = False
        End If
    End Sub

    Private Sub Ck_DescuentoSindical_CheckStateChanged(sender As Object, e As EventArgs) Handles Ck_DescuentoSindical.CheckStateChanged
        If Ck_DescuentoSindical.CheckState = CheckState.Checked Then
            Nud_PorcentSindicato.Enabled = True
        Else
            Nud_PorcentSindicato.Enabled = False
        End If
    End Sub

    ''' <summary>Selecciona la persona del control Cu_BuscarPersona según el número de identificación ingresado en su caja de texto.</summary>
    ''' <param name="NombreComponente">Nombre del control que llama al evento.</param>
    Public Sub EventoCajaEnter(NombreComponente As String)
        Dim cubp() As Control = Me.Controls.Find(NombreComponente, True)
        If cubp.Length > 0 Then
            Dim cuBuscarPersona As FormulariosClasesBase.Cu_BuscarPersona = cubp(0)
            Dim filas() As DataRow
            Try
                filas = cuBuscarPersona.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (cuBuscarPersona.Tx_TextoCódigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuBuscarPersona.Cb_Persona.SelectedValue = fila("IDPERSONA")
                Else
                    MessageBox.Show("Esta identificación no esta registrada o no esta asociada a la base", "No se encuentró la identificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch
                cuBuscarPersona.Tx_TextoCódigo.Text = ""
            End Try
        End If
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

                End If
            Catch
                cuCiudad.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub

    Public Sub EventoEnterEntidadAdmin(Optional NombreComponente As String = "")
        Dim controles() As Control = Me.Controls.Find(NombreComponente, True)
        If controles.Length > 0 Then
            Dim cuEntidadAdmin As Clasesbase.Cu_EntidadAdministradora = controles(0)
            Dim filas() As DataRow
            Try
                filas = cuEntidadAdmin.Cb_NombreAdministradora.DataSource.Select("CODIGOTIPOENTIDADADMINISTRADORA='" + (cuEntidadAdmin.Tx_Codigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuEntidadAdmin.Cb_NombreAdministradora.SelectedValue = fila("CODIGOTIPOENTIDADADMINISTRADORA")
                Else
                    MessageBox.Show("Esta entidad no está registrada o no está asociada a la base.", "No se encontró la entidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch
                cuEntidadAdmin.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub
    Private Sub Cb_TipoContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoContrato.SelectedIndexChanged
        Select Case Cb_TipoContrato.SelectedValue
            Case 1, 2, 6, 7, 11
                Cb_TipoSalario.SelectedValue = "M"
                Label6.Text = "Salario:"
                Label6.Location = New System.Drawing.Point(472, 88)
            Case 3, 8, 12
                Cb_TipoSalario.SelectedValue = "M"
                Label6.Text = "Salario sin Fac. Prest:"
                Label6.Location = New System.Drawing.Point(405, 88)
            Case Else
                Cb_TipoSalario.SelectedValue = "D"
                Label6.Text = "Salario:"
                Label6.Location = New System.Drawing.Point(472, 88)

        End Select
    End Sub
End Class 'Fr_Contratar


Public Class Fr_ImprTerminacion
    Inherits Form

    Property IdPersona As Integer = -1
    Property IdContrato As Int64 = -1
    Property IdBase As Integer = -1
    Property CodigoTipoContrato As UInteger = 0
    Property CodigoTipoCargo As Integer = -1
    Property NombreTipoCargo As String = ""
    Property FechaTerminacion As Date
    Property TipoTerminaciónContrato As Integer = -1    ' Se agrega 

    Public IdExamen As Integer = -1
    Public Enum TiposContrato
        Fijo
        ObraLabor
        Indefinido
    End Enum
    Friend WithEvents Pn_Controles As New Panel
    Friend WithEvents Ck_ImprCartaTerminacionContrato As New CheckBox
    Friend WithEvents Ck_ImprCartaAceptacionRenuncia As New CheckBox
    Friend WithEvents Ck_ImprCertPazYSalvo As New CheckBox
    Friend WithEvents Ck_ImprCertPazYSalvoControl As New CheckBox  ' formato para base 0
    Friend WithEvents Ck_ImprNovedadesFinalContrato As New CheckBox   ' formato para base 0
    Friend WithEvents Ck_ImprExamenMedicoRetiro As New CheckBox
    Friend WithEvents Lb_TextoCentroClinico As New Label
    Friend WithEvents Cb_CentrosClinicos As New ComboBox
    Friend WithEvents Lb_TextoOtrosExamenes As New Label
    Friend WithEvents Tx_OtrosExamenes As New TextBox
    Friend WithEvents Flp_Botones As New FlowLayoutPanel
    Friend WithEvents Bt_Imprimir As New Button
    Friend WithEvents Bt_Cancelar As New Button
    Private dtCentrosClinicos As New DataTable

    Public Function GrupoTipoContrato() As TiposContrato
        Select Case CodigoTipoContrato
            Case 1, 2, 3, 4, 5
                Return TiposContrato.Fijo
            Case 6, 7, 8, 9, 10
                Return TiposContrato.ObraLabor
            Case 11, 12
                Return TiposContrato.Indefinido
            Case Else
                Return Nothing
        End Select
    End Function

    Public Sub New()
        InicializarControles()
    End Sub

    Public Sub New(_idPersona As Integer, _idContrato As Int64, _tipoContrato As UInteger, _tipoCargo As UInteger, _nombreCargo As String, _fechaRetiro As Date, Tipo_terminacion As Integer, Optional _idBase As Integer = -1)
        IdPersona = _idPersona
        IdContrato = _idContrato
        CodigoTipoContrato = _tipoContrato
        CodigoTipoCargo = _tipoCargo
        NombreTipoCargo = _nombreCargo
        FechaTerminacion = _fechaRetiro
        TipoTerminaciónContrato = Tipo_terminacion
        If _idBase >= 0 Then
            IdBase = _idBase
        End If
        InicializarControles()
    End Sub

    Private Sub InicializarControles()
        Dim Base As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        With Ck_ImprCartaAceptacionRenuncia     ' se agrega aceptacion de renuncia del trabajador
            .AutoSize = True
            If TipoTerminaciónContrato = 4 Then
                .Checked = True
            Else
                .Checked = False
            End If

            .Location = New System.Drawing.Point(10, 10)
            .Text = "Carta Aceptación Renuncia"

        End With

        With Ck_ImprCartaTerminacionContrato
            If TipoTerminaciónContrato = 4 Then
                .Checked = False
            Else
                .Checked = True
            End If

            .AutoSize = True

            .Location = New System.Drawing.Point(10, 30)
            .Text = "Carta de terminación de contrato"
        End With
        With Ck_ImprCertPazYSalvo
            .AutoSize = True
            .Checked = True
            .Location = New System.Drawing.Point(10, 50)
            .Text = "Paz y Salvo"
        End With
        With Ck_ImprExamenMedicoRetiro
            .AutoSize = True
            .Checked = False
            .Location = New System.Drawing.Point(10, 70)
            .Text = "Examen médico de retiro"
        End With

        With Ck_ImprCertPazYSalvoControl   ' Se agrega formato  paz y salvo + control de seguimientio,  solo para la base Bucaramnga
            If Base = 0 Then
                .Enabled = True
                .Visible = True
            Else
                .Enabled = False
                .Visible = False
            End If

            .AutoSize = True
            .Checked = False
            .Location = New System.Drawing.Point(10, 70)
            .Text = "Paz y Salvo Control Seguimiento Médico"
        End With

        With Ck_ImprNovedadesFinalContrato   ' Se agrega formato  paz y salvo + control de seguimientio,  solo para la base Bucaramnga
            If Base = 0 Then
                .Enabled = True
                .Visible = True
            Else
                .Enabled = False
                .Visible = False
            End If
            .AutoSize = True
            .Checked = False
            .Location = New System.Drawing.Point(10, 90)
            .Text = "Novedades Liquidación Final Contrato"
        End With
        With Ck_ImprExamenMedicoRetiro
            .AutoSize = True
            .Checked = False
            .Location = New System.Drawing.Point(10, 110)
            .Text = "Examen Médico de Retiro"
        End With
        With Lb_TextoCentroClinico
            .AutoSize = True
            .Enabled = False
            .Text = "Centro clínico:"
            .Location = New System.Drawing.Point(28, 130)
        End With
        With Cb_CentrosClinicos
            .DisplayMember = "NOMBRECENTROCLINICO"
            .DropDownStyle = ComboBoxStyle.DropDown
            .Enabled = False
            .Location = New System.Drawing.Point(28, 140)
            .Size = New System.Drawing.Size(275, 20)
            .ValueMember = "CODIGOCENTROCLINICO"
        End With
        With Pn_Controles
            .Dock = DockStyle.Fill
            .Controls.Add(Ck_ImprCartaAceptacionRenuncia) ' carta Aceptacion renuncia 
            .Controls.Add(Ck_ImprCartaTerminacionContrato)
            .Controls.Add(Ck_ImprCertPazYSalvo)
            .Controls.Add(Ck_ImprExamenMedicoRetiro)
            .Controls.Add(Ck_ImprNovedadesFinalContrato)
            .Controls.Add(Lb_TextoCentroClinico)
            .Controls.Add(Ck_ImprCertPazYSalvoControl)
            .Controls.Add(Cb_CentrosClinicos)
            .Controls.Add(Lb_TextoOtrosExamenes)
            .Controls.Add(Tx_OtrosExamenes)
        End With
        With Bt_Imprimir
            .AutoSize = True
            .UseVisualStyleBackColor = True
            .Text = "Imprimir"
        End With
        With Bt_Cancelar
            .AutoSize = True
            .UseVisualStyleBackColor = True
            .Text = "Cancelar"
        End With
        With Flp_Botones
            .BackColor = Drawing.Color.Silver
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .Controls.Add(Bt_Imprimir)
            .Controls.Add(Bt_Cancelar)
        End With
        With Me
            .AcceptButton = Bt_Imprimir
            .CancelButton = Bt_Cancelar
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(330, 240)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Imprimir formatos de terminación"
            .Controls.Add(Flp_Botones)
            .Controls.Add(Pn_Controles)
        End With
    End Sub

    Private Sub Fr_ImprTerminacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarCentrosClinicos()
    End Sub

    Private Sub CargarCentrosClinicos()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaCentrosClinicos() ORDER BY NOMBRECENTROCLINICO", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            adaptador.Fill(dtCentrosClinicos)
            Cb_CentrosClinicos.DataSource = dtCentrosClinicos.Copy
        Catch ex As Exception
            MessageBox.Show("Error en la impresión de formatos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Ck_ImprExamenMedicoRetiro_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_ImprExamenMedicoRetiro.CheckedChanged
        If Ck_ImprExamenMedicoRetiro.Checked Then
            Lb_TextoCentroClinico.Enabled = True
            Cb_CentrosClinicos.Enabled = True
            Lb_TextoOtrosExamenes.Enabled = True
            Tx_OtrosExamenes.Enabled = True
        Else
            Lb_TextoCentroClinico.Enabled = False
            Cb_CentrosClinicos.SelectedIndex = -1
            Cb_CentrosClinicos.Enabled = False
            Lb_TextoOtrosExamenes.Enabled = False
            Tx_OtrosExamenes.Text = ""
            Tx_OtrosExamenes.Enabled = False
        End If
    End Sub

    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click
        Dim dtExamenes As New DataTable
        dtExamenes.Columns.Add("CODIGOEXAMENPREOCUPACIONAL")
        dtExamenes.Columns.Add("PRACTICAR")
        dtExamenes.Columns.Add("TIPO")
        dtExamenes.Rows.Add("23", "S", "OME")
        Dim clImpresion As New ImprimirRecursoHumano.Cl_Impresión
        clImpresion.Idpersona = IdPersona
        clImpresion.IdContrato = IdContrato
        clImpresion.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        clImpresion.CodigoMotivoConsultaExamenes = 4 'Retiro
        clImpresion.NombreCargoPropuesto = NombreTipoCargo
        clImpresion.dtExamenesPreocupacionales = dtExamenes

        Dim centroClinico() As DataRow = dtCentrosClinicos.Select("[CODIGOCENTROCLINICO] = " & Cb_CentrosClinicos.SelectedValue)
        If Not IsNothing(centroClinico) AndAlso centroClinico.Length > 0 Then
            clImpresion.FilaCentroClinico = centroClinico(0)
        End If
        clImpresion.OtrosExamenesEE = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_OtrosExamenes.Text)
        clImpresion.FechaEnvio = FechaTerminacion
        Dim documentos As New ArrayList()
        If Ck_ImprCartaAceptacionRenuncia.Checked Then
            documentos.Add(51)  ' Carta de aceptacion de renuncia del trabajador.
        End If
        If Ck_ImprCartaTerminacionContrato.Checked Then
            Select Case GrupoTipoContrato()
                Case TiposContrato.Fijo
                    documentos.Add(13) 'ICA GRAL-F-034 CARTA DE TERMINACION DE CONTRATO A TERMINO FIJO
                Case TiposContrato.ObraLabor
                    documentos.Add(14) 'ICA GRAL-F-129 - CARTA DE TERMINACIÓN DE CONTRATO DE TRABAJO DE LABOR U OBRA DETERMINADA
                Case TiposContrato.Indefinido

            End Select
        End If
        If Ck_ImprCertPazYSalvo.Checked Then
            documentos.Add(33) 'ICA GRAL-F-046 PAZ Y SALVO PARA LIQUIDACIÓN FINAL CONTRATO
        End If
        If Ck_ImprCertPazYSalvoControl.Checked Then
            documentos.Add(95) 'ICA GRAL-F-046 PAZ Y SALVO PARA LIQUIDACIÓN FINAL CONTRATO + SEGUIMIENTO MÉDICO
        End If
        If Ck_ImprNovedadesFinalContrato.Checked Then

            documentos.Add(96) 'ICA GRAL-F-031 SECCION NOMINA NOVEDADES LIQUIDACION FINAL DEL CONTRATO
        End If
        If Ck_ImprExamenMedicoRetiro.Checked Then
            Try
                GuardarEnvioExamen()
                clImpresion.IdExamen = IdExamen
                documentos.Add(85) 'ICA GRAL-F-091 ORDEN PARA CONSULTA MÉDICA Y AUTORIZACIÓN EXÁMENES PREOCUPACIONALES)
               
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al guardar envío a examen de retiro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        clImpresion.FormatosImprimir(documentos, True)
        Me.Close()
    End Sub

    Private Sub GuardarEnvioExamen()
        Dim dtExamenesVacio As New DataTable
        dtExamenesVacio.Columns.Add("CODIGOEXAMEN")
        dtExamenesVacio.Rows.Add("23")
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("GestionarEnvioExamenes", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 1)
        comando.Parameters.AddWithValue("@IDPERSONA", IdPersona)
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@CODIGOTIPOCARGO", CodigoTipoCargo)
        comando.Parameters.AddWithValue("@CODIGOCENTROCLINICO", Cb_CentrosClinicos.SelectedValue)
        comando.Parameters.AddWithValue("@CODIGOMOTIVOCONSULTA", 4)
        comando.Parameters.AddWithValue("@IDENVIOEXAMEN", DBNull.Value)
        comando.Parameters.AddWithValue("@CONCEPTOMEDICO", DBNull.Value)
        comando.Parameters.AddWithValue("@DETALLEENVIOEXAMEN", dtExamenesVacio)
        comando.Parameters.AddWithValue("@OBSERVACIONES", "")
        comando.Parameters.AddWithValue("@FECHAENVIO", FechaTerminacion)
        comando.Parameters.AddWithValue("@TAREACRITICA", DBNull.Value)
        comando.Parameters.AddWithValue("@CONTINUAPROCESO", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.BigInt, 1)
        comando.Parameters.AddWithValue("@IDCENTROCOSTO", VariablesBase.VariablesBase.IdCentroCostoSisControl)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            IdExamen = msgParam.Value

        Catch ex As Exception
            Throw New Exception("No se pudo guardar el envío a examen médico.")
        Finally
            conexion.Close()
        End Try
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
End Class 'Fr_ImprTerminacion