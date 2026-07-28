Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_AutorizarIngresoMultiple

    Property IdPersona As Integer
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private dsMaestras As DataSet
    Private dtPreguntas As New DataTable

    Public Sub CargarDatos()

        comando = New SqlCommand("dbo.CargarMaestrasEncuesta", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdBase", SqlDbType.Int)
        comando.Parameters.Add("@Identificador", SqlDbType.BigInt)
        comando.Parameters.Add("@Tipo", SqlDbType.TinyInt)
        comando.Parameters.Add("@Identificador2", SqlDbType.BigInt)
        comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 15)
        comando.Parameters("@Accion").Value = 5
        comando.Parameters("@IdBase").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        comando.Parameters("@Identificador").Value = DBNull.Value
        comando.Parameters("@Tipo").Value = 2
        comando.Parameters("@Identificador2").Value = IdPersona
        comando.Parameters("@Cedula").Value = ""
        adaptador = New SqlDataAdapter(comando)
        dsMaestras = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaestras)
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos de la encuesta." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

        dtPreguntas = dsMaestras.Tables(1)
        Cb_NroPregunta.DataSource = dsMaestras.Tables(1)
        Cb_NroPregunta.DisplayMember = "NROPREGUNTA"
        Cb_NroPregunta.ValueMember = "NROPREGUNTA"
        Cb_NroPregunta.SelectedIndex = -1

        Dim fila As DataRow
        fila = dsMaestras.Tables(0).Rows(0)
        Me.Label_Nombre.Text = fila("NOMBRECOMPLETO")
        Me.Label_Cedula.Text = "Identificación: " & dsMaestras.Tables(0).Rows(0).Item("IDENTIFICACION")

        DeshabilitarControles()

    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
     
        If Validar_Autorizacion() Then
            comando = New SqlCommand("SELECT * FROM AutorizadosEntreFechas(@FECHAINICIAL,@FECHAFINAL,@NROPREGUNTA,@IDPERSONA)", conexion)
            comando.Parameters.AddWithValue("@FECHAINICIAL", Dtp_FechaI.Value)
            comando.Parameters.AddWithValue("@FECHAFINAL", Dtp_FechaF.Value)
            comando.Parameters.AddWithValue("@NROPREGUNTA", Cb_NroPregunta.SelectedValue)
            comando.Parameters.AddWithValue("@IDPERSONA", IdPersona)
            adaptador = New SqlDataAdapter(comando)
            Dim dtAutorizacion As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtAutorizacion)
                conexion.Close()
                If dtAutorizacion.Rows.Count > 0 Then
                    Dim FechaI As DateTime
                    Dim FechaF As DateTime
                    FechaI = dtAutorizacion.Rows(0).Item("FECHAINICIAL")
                    FechaF = dtAutorizacion.Rows(0).Item("FECHAFINAL")
                    MsgBox("La persona tiene la pregunta Nro " & Cb_NroPregunta.SelectedValue & " autorizada en la fecha del " & FechaI.Date & " al " & FechaF.Date, MsgBoxStyle.Information, "Revisar Fechas.")
                Else
                    GuardarAutorizacion()
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            Exit Sub
        End If
    End Sub

    Private Sub GuardarAutorizacion()
        comando = New SqlCommand("dbo.GestionarEncuesta", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
        comando.Parameters.Add("@PROYECTO", SqlDbType.NVarChar, 50)
        comando.Parameters.Add("@IDBASESISCONTROL", SqlDbType.Int)
        comando.Parameters.Add("@FECHAENCUESTA", SqlDbType.Date)
        comando.Parameters.Add("@EDAD", SqlDbType.TinyInt)
        comando.Parameters.Add("@NOMBRETIPOCARGO", SqlDbType.NVarChar, 300)
        comando.Parameters.Add("@RESPUESTA1", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA2", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA3", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA4", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA5", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA6", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA7", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA8", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA9", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA10", SqlDbType.NChar, 1)
        comando.Parameters.Add("@IDPERSONARESPONDE", SqlDbType.Int)
        comando.Parameters.Add("@FECHARESPONDE", SqlDbType.DateTime)
        comando.Parameters.Add("@CLAVEACCESOWEB", SqlDbType.NChar, 8)
        comando.Parameters.Add("@LLENOVIAWEB", SqlDbType.NChar, 1)
        comando.Parameters.Add("@CORREOELECTRONICO", SqlDbType.NVarChar, 100)
        comando.Parameters.Add("@AUTORIZADOMEDICO", SqlDbType.NChar, 1)
        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)
        comando.Parameters.Add("@ID_DM_ENCUESTA", SqlDbType.BigInt)

        comando.Parameters("@ACCION").Value = 6
        comando.Parameters("@ID_DM_ENCUESTA").Value = DBNull.Value
        comando.Parameters("@FECHAENCUESTA").Value = Dtp_FechaI.Value
        comando.Parameters("@CLAVEACCESOWEB").Value = DBNull.Value
        comando.Parameters("@IDPERSONA").Value = IdPersona
        comando.Parameters("@PROYECTO").Value = DBNull.Value
        comando.Parameters("@IDBASESISCONTROL").Value = DBNull.Value
        comando.Parameters("@EDAD").Value = Cb_NroPregunta.SelectedValue
        comando.Parameters("@NOMBRETIPOCARGO").Value = DBNull.Value

        comando.Parameters("@RESPUESTA1").Value = DBNull.Value
        comando.Parameters("@RESPUESTA2").Value = DBNull.Value
        comando.Parameters("@RESPUESTA3").Value = DBNull.Value
        comando.Parameters("@RESPUESTA4").Value = DBNull.Value
        comando.Parameters("@RESPUESTA5").Value = DBNull.Value
        comando.Parameters("@RESPUESTA6").Value = DBNull.Value
        comando.Parameters("@RESPUESTA7").Value = DBNull.Value
        comando.Parameters("@RESPUESTA8").Value = DBNull.Value
        comando.Parameters("@RESPUESTA9").Value = DBNull.Value
        comando.Parameters("@RESPUESTA10").Value = DBNull.Value
        comando.Parameters("@CORREOELECTRONICO").Value = Tb_ConceptoMedico.Text
        comando.Parameters("@IDPERSONARESPONDE").Value = DBNull.Value
        comando.Parameters("@FECHARESPONDE").Value = Dtp_FechaF.Value
        comando.Parameters("@LLENOVIAWEB").Value = DBNull.Value

        comando.Parameters("@AUTORIZADOMEDICO").Value = "S"

        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona


        Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)

        Dim msgParam1 As New SqlParameter("@CONSECUTIVO", SqlDbType.NChar, 8)
        msgParam1.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam1)

        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            MsgBox("Autorización Guardada", MsgBoxStyle.Information, "Guardado")
            Close()
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        Tb_Pregunta.Enabled = False
    End Sub

    Private Sub Cb_NroPregunta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_NroPregunta.SelectedIndexChanged
        If Cb_NroPregunta.ValueMember.ToString <> "" Then
            Try
                Dim Filas() As DataRow
                Filas = dtPreguntas.Select("NROPREGUNTA=" & Cb_NroPregunta.SelectedValue)
                Dim Fila As DataRow = Filas(0)
                Tb_Pregunta.Text = Fila("PREGUNTA")
            Catch ex As Exception
                Cb_NroPregunta.SelectedIndex = -1
            End Try
        End If
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub

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

    Private Function Validar_Autorizacion() As Boolean
        If CompararFechas(Dtp_FechaF.Value, Dtp_FechaI.Value) = 1 Then
            MsgBox("La fecha  final es inferior a la fecha inicial.", MsgBoxStyle.Information, "FECHA FINAL")
            Dtp_FechaI.Focus()
            Validar_Autorizacion = False
            Exit Function
        End If
        Validar_Autorizacion = True
    End Function

End Class