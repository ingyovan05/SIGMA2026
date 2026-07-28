Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_ResumenEstadistico

    Public TIPO As Integer
    Public EDITANDO As Boolean
    Public IDRESUMEN As Integer
    Public IDRESUMENMODIFICANDO As Integer = -1
    Public guardado As Boolean

    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Dim dsCargar As New DataSet
    Private dtResumen As DataTable
    Private FilaResumenEstadistico As DataRow

    Public Sub ComportamientoPredeterminado()
        If TIPO = 2 Then
            Cb_Base.Enabled = False
            Cb_Mes.Enabled = False
        End If
    End Sub
    Public Sub CargarTablas()
        Dim identificador As Long
        Dim tipo As Integer
        Dim subtipo As Integer

        If IDRESUMENMODIFICANDO < 0 Then
            identificador = IDRESUMEN
            tipo = 1 'Crear
        Else
            identificador = IDRESUMENMODIFICANDO
            tipo = 2 'Editar
            subtipo = IDRESUMEN
        End If
        dsCargar = bddatos.CargarMaestrasHSE(2, identificador, tipo, subtipo)

        Cb_Base.DataSource = dsCargar.Tables(0)
        Cb_Base.DisplayMember = "NOMBREBASE"
        Cb_Base.ValueMember = "IDBASEHSE"

        Cb_Mes.DataSource = dsCargar.Tables(1)
        Cb_Mes.DisplayMember = "NOMBRE"
        Cb_Mes.ValueMember = "MES"

        If tipo = 1 Then
            Cb_Base.SelectedIndex = -1
            Cb_Mes.SelectedIndex = -1
        End If

        If tipo = 2 Then
            dtResumen = dsCargar.Tables(2)
            FilaResumenEstadistico = dtResumen.Rows(0)
        End If
    End Sub

    Public Sub LlenarResumen()
        If TIPO = 2 Then
            'Dim Base As String = .ToString
            Me.Cb_Base.SelectedValue = FilaResumenEstadistico("IDBASEHSE")
            Me.Cb_Mes.SelectedValue = FilaResumenEstadistico("MES")
            Me.Tb_PersonalContratado.Text = FilaResumenEstadistico("PERSONALCONTRATADO").ToString
            Me.Tb_TotalHorasOrdinarias.Text = FilaResumenEstadistico("TOTALHORASORDINARIAS").ToString
            Me.Tb_TotalHorasTrabajadas.Text = FilaResumenEstadistico("TOTALHORASTRABAJADAS").ToString
            Me.Tb_DiasCargadosATEL.Text = FilaResumenEstadistico("DIASCARGADOSATEL").ToString
            Me.Tb_DIasIncapacidadATEL.Text = FilaResumenEstadistico("DIASINCAPACIDADATEL").ToString
            Me.Tb_EnfermedadLaboral.Text = FilaResumenEstadistico("ENFERMEDADLABORAL").ToString
            Me.Tb_DiasPerdidosIncapacidadGeneral.Text = FilaResumenEstadistico("DIASINCAPACIDADENFERMEDADGENERAL").ToString
            Me.Tb_NumeroDiasTrabajoProgramado.Text = FilaResumenEstadistico("NUMERODIASTRABAJOPROGRAMADO").ToString
            Me.Tb_NumeroVehiculos.Text = FilaResumenEstadistico("NUMEROVEHICULOS").ToString
            Me.Tb_Kilometros.Text = FilaResumenEstadistico("TOTALKILOMETROS").ToString
            Me.Tb_InspeccionesRealizadas.Text = FilaResumenEstadistico("NUMEROINSPECCIONES").ToString
            Me.Tb_NumeroConductores.Text = FilaResumenEstadistico("NUMEROCONDUCTORES").ToString
            Me.Tb_HorasCapacitacion.Text = FilaResumenEstadistico("HORASCAPACITACION").ToString
            Me.Tb_CostosDirectosIndirectos.Text = FilaResumenEstadistico("COSTOSDIRECTOSINDIRECTOS").ToString
            Me.Tb_CostosDaños.Text = FilaResumenEstadistico("COSTOSDAÑOS").ToString
        End If
    End Sub

    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Tb_DiasCargadosATEL.KeyPress, Tb_DIasIncapacidadATEL.KeyPress, Tb_EnfermedadLaboral.KeyPress, Tb_DiasPerdidosIncapacidadGeneral.KeyPress, Tb_Kilometros.KeyPress, Tb_NumeroConductores.KeyPress, Tb_NumeroDiasTrabajoProgramado.KeyPress, Tb_NumeroVehiculos.KeyPress, Tb_PersonalContratado.KeyPress, Tb_TotalHorasOrdinarias.KeyPress, Tb_TotalHorasTrabajadas.KeyPress, Tb_HorasCapacitacion.KeyPress, Tb_CostosDirectosIndirectos.KeyPress, Tb_CostosDaños.KeyPress, Tb_InspeccionesRealizadas.KeyPress

        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        GuardarResumenEstadistico()
        Me.Close()
    End Sub

    Public Function ValidarCasillas() As Boolean
        If Me.Cb_Base.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la base", MsgBoxStyle.Information, "Base")
            ValidarCasillas = False
            Cb_Base.Focus()
            Exit Function
        End If
        If Me.Cb_Base.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el mes", MsgBoxStyle.Information, "Mes")
            ValidarCasillas = False
            Cb_Mes.Focus()
            Exit Function
        End If
        If Trim(Tb_PersonalContratado.Text) = "" Then
            MsgBox("Debe ingresar el personal contratado", MsgBoxStyle.Information, "Personal contratado")
            ValidarCasillas = False
            Tb_PersonalContratado.Focus()
            Exit Function
        End If
        If Trim(Tb_TotalHorasOrdinarias.Text) = "" Then
            MsgBox("Debe ingresar el total de horas ordinarias", MsgBoxStyle.Information, "Total horas ordinarias")
            ValidarCasillas = False
            Tb_TotalHorasOrdinarias.Focus()
            Exit Function
        End If
        If Trim(Tb_TotalHorasTrabajadas.Text) = "" Then
            MsgBox("Debe ingresar el total de horas trabajadas", MsgBoxStyle.Information, "Total horas trabajadas")
            ValidarCasillas = False
            Tb_TotalHorasTrabajadas.Focus()
            Exit Function
        End If
        If Trim(Tb_DiasCargadosATEL.Text) = "" Then
            MsgBox("Debe ingresar los días cargados por ATEL", MsgBoxStyle.Information, "Días cargados por ATEL")
            ValidarCasillas = False
            Tb_DiasCargadosATEL.Focus()
            Exit Function
        End If
        If Trim(Tb_DIasIncapacidadATEL.Text) = "" Then
            MsgBox("Debe ingresar los días de incapacidad por ATEL", MsgBoxStyle.Information, "Dias incapacidad por ATEL")
            ValidarCasillas = False
            Tb_DIasIncapacidadATEL.Focus()
            Exit Function
        End If
If Trim(Tb_EnfermedadLaboral.Text) = "" Then
            MsgBox("Debe ingresar los días perdidos por ATEL", MsgBoxStyle.Information, "Días perdidos por ATEL")
            ValidarCasillas = False
            Tb_EnfermedadLaboral.Focus()
            Exit Function
        End If
        If Trim(Tb_DiasPerdidosIncapacidadGeneral.Text) = "" Then
            MsgBox("Debe ingresar los días de incapacidad por enfermedad general", MsgBoxStyle.Information, "Días incapacidad por enfermedad general")
            ValidarCasillas = False
            Tb_DiasPerdidosIncapacidadGeneral.Focus()
            Exit Function
        End If
        If Trim(Tb_NumeroDiasTrabajoProgramado.Text) = "" Then
            MsgBox("Debe ingresar el número de días de trabajo programados", MsgBoxStyle.Information, "Días trabajo programado")
            ValidarCasillas = False
            Tb_NumeroDiasTrabajoProgramado.Focus()
            Exit Function
        End If
        If Trim(Tb_NumeroVehiculos.Text) = "" Then
            MsgBox("Debe ingresar el número de vehículos utlizados (Propios + Contratistas)", MsgBoxStyle.Information, "Vehiculos utilizados")
            ValidarCasillas = False
            Tb_NumeroVehiculos.Focus()
            Exit Function
        End If
        If Trim(Tb_Kilometros.Text) = "" Then
            MsgBox("Debe ingresar el total de kilometros recorridos (Propios + Contratistas)", MsgBoxStyle.Information, "Kilometros recorridos")
            ValidarCasillas = False
            Tb_Kilometros.Focus()
            Exit Function
        End If
        If Trim(Tb_InspeccionesRealizadas.Text) = "" Then
            MsgBox("Debe ingresar el número de inspecciones realizadas a vehículos (Propios + Contratistas)", MsgBoxStyle.Information, "Inspecciones realizadas a vehículos")
            ValidarCasillas = False
            Tb_InspeccionesRealizadas.Focus()
            Exit Function
        End If
        If Trim(Tb_NumeroConductores.Text) = "" Then
            MsgBox("Debe ingresar el número de conductores (Propios + Contratistas)", MsgBoxStyle.Information, "Número conductores")
            ValidarCasillas = False
            Tb_NumeroConductores.Focus()
            Exit Function
        End If
        If Trim(Tb_HorasCapacitacion.Text) = "" Then
            MsgBox("Debe ingresar las horas de capacitación", MsgBoxStyle.Information, "Horas de capacitación")
            ValidarCasillas = False
            Tb_HorasCapacitacion.Focus()
            Exit Function
        End If
        If Trim(Tb_CostosDirectosIndirectos.Text) = "" Then
            MsgBox("Debe ingresar los costos directos e indirectos ATEL y Casi-Accidentes", MsgBoxStyle.Information, "Costos directos e indirectos")
            ValidarCasillas = False
            Tb_CostosDirectosIndirectos.Focus()
            Exit Function
        End If
        If Trim(Tb_CostosDaños.Text) = "" Then
            MsgBox("Debe ingresar los costos por daños a la propiedad, terceros, ambiente", MsgBoxStyle.Information, "Costos por daños")
            ValidarCasillas = False
            Tb_CostosDaños.Focus()
            Exit Function
        End If
        ValidarCasillas = True
    End Function

    Private Sub GuardarResumenEstadistico()
        If ValidarCasillas() = False Then
            Exit Sub
        End If

        Dim Cadena_Consulta As String
        Cadena_Consulta = "SELECT COUNT(RE.IDRESUMENESTADISTICO) FROM HSE_RESUMENESTADISTICO AS RE WHERE RE.AÑO = @Año AND RE.MES = @Mes AND RE.IDBASEHSE = @Base"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Consulta.Parameters.AddWithValue("@Año", Today.Year)
        Consulta.Parameters.AddWithValue("@Mes", Me.Cb_Mes.SelectedValue)
        Consulta.Parameters.AddWithValue("@Base", Me.Cb_Base.SelectedValue)

        Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Consulta.Connection = Conexión

        Consulta.Connection.Open()
        Dim resultado As Integer = Consulta.ExecuteScalar
        Consulta.Connection.Close()

        If resultado > 0 And EDITANDO = False Then
            MsgBox("Ya se ha registrado la información del mes seleccionado para la base seleccionada", MsgBoxStyle.Information, "Datos ya registrados")
            Exit Sub
        End If

        Dim Comando As New SqlCommand("dbo.GestionarResumenEstadisticoHSE")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@ACCION", TIPO)
        Comando.Parameters.AddWithValue("@IDRESUMENESTADISTICO", IDRESUMENMODIFICANDO)

        'Cuando se registra en Enero los valores de diciembre del año pasado
        If Today.Month = 1 And Cb_Mes.SelectedValue = 12 Then
            Comando.Parameters.AddWithValue("@AÑO", Now.Year - 1)
        Else
            Comando.Parameters.AddWithValue("@AÑO", Now.Year)
        End If
        Comando.Parameters.AddWithValue("@MES", Me.Cb_Mes.SelectedValue)
        Comando.Parameters.AddWithValue("@IDBASEHSE", Me.Cb_Base.SelectedValue)
        Comando.Parameters.AddWithValue("@PERSONALCONTRATADO", Me.Tb_PersonalContratado.Text)
        Comando.Parameters.AddWithValue("@TOTALHORASORDINARIAS", Me.Tb_TotalHorasOrdinarias.Text)
        Comando.Parameters.AddWithValue("@TOTALHORASTRABAJADAS", Me.Tb_TotalHorasTrabajadas.Text)
        Comando.Parameters.AddWithValue("@DIASCARGADOSATEL", Me.Tb_DiasCargadosATEL.Text)
        Comando.Parameters.AddWithValue("@DIASINCAPACIDADATEL", Me.Tb_DIasIncapacidadATEL.Text)
        Comando.Parameters.AddWithValue("@ENFERMEDADLABORAL", Me.Tb_EnfermedadLaboral.Text)
        Comando.Parameters.AddWithValue("@DIASINCAPACIDADENFERMEDADGENERAL", Me.Tb_DiasPerdidosIncapacidadGeneral.Text)
        Comando.Parameters.AddWithValue("@NUMERODIASTRABAJOPROGRAMADO", Me.Tb_NumeroDiasTrabajoProgramado.Text)
        Comando.Parameters.AddWithValue("@NUMEROVEHICULOS", Me.Tb_NumeroVehiculos.Text)
        Comando.Parameters.AddWithValue("@TOTALKILOMETROS", Me.Tb_Kilometros.Text)
        Comando.Parameters.AddWithValue("@NUMEROINSPECCIONES", Me.Tb_InspeccionesRealizadas.Text)
        Comando.Parameters.AddWithValue("@NUMEROCONDUCTORES", Me.Tb_NumeroConductores.Text)
        Comando.Parameters.AddWithValue("@HORASCAPACITACION", Me.Tb_HorasCapacitacion.Text)
        Comando.Parameters.AddWithValue("@COSTOSDIRECTOSINDIRECTOS", Me.Tb_CostosDirectosIndirectos.Text)
        Comando.Parameters.AddWithValue("@COSTOSDAÑOS", Me.Tb_CostosDaños.Text)
        Comando.Parameters.AddWithValue("@BLOQUEAREDICION", "S") 'S bloqueado, N sin bloquear
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)

        Dim conexion2 As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        conexion2.Open()
        Comando.Connection = conexion2
        Try
            Comando.ExecuteNonQuery()
            conexion2.Close()
            guardado = True
        Catch ex As Exception
            conexion2.Close()
            MsgBox(ex.ToString)
            guardado = False
        End Try
    End Sub

    Private Sub Fr_ResumenEstadistico_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Bt_Guardar.Enabled = True And guardado = False Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub
End Class