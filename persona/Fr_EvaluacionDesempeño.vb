Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_EvaluacionDesempeño

    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property

    Public Editando As Boolean = False
    Public IdEvaluacion As Int64 = -1
    Public Consecutivo As Integer
    Private Año As String = Year(Date.Now)
    Private IdDependencia As Integer
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Fila_Editar_Evaluacion As DataRow
    Private _guardado As Boolean = False


    Dim dsCargar As New DataSet
    Public Sub CargarTablas()
        'IdDependencia = VariablesBase.VariablesBase.IddependenciaSiscontrolActual

        'VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CargarCombos()
        'CargarPersonas()

        dsCargar = bddatos.CargarMaestras(12, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdEvaluacion, IIf(IdEvaluacion = -1, 2, 2))

        Cb_Estado.DataSource = dsCargar.Tables(1)
        Cb_Estado.ValueMember = "CODIGO"
        Cb_Estado.DisplayMember = "NOMBRE"

        If Editando = True Then
            Fila_Editar_Evaluacion = dsCargar.Tables(0).Rows(0)
        End If
    End Sub

    Private Sub CargarCombos()
        'VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        Cu_BuscarEvaluado.CargarDatosPersona()
        'Cu_BuscarEvaluado.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "ED", "EVALUADO", -1)
        Cu_BuscarEvaluador.CargarDatosPersona()
        'Cu_BuscarEvaluador.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "ED", "EVALUADOR", -1)
    End Sub

    'Private Sub CargarPersonas()
    '    Cu_BuscarEvaluado.CargarDatosPersona()
    '    Cu_BuscarEvaluador.CargarDatosPersona()
    'End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Guardar_Datos() = True Then
            Close()
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Function Guardar_Datos() As Boolean
        Try
            If ValidarDocumento() Then
                GuardarEvaluacion()
            Else
                Guardar_Datos = False
                Exit Function
            End If
            Guardar_Datos = _guardado
        Catch ex As Exception
            Guardar_Datos = False
            MessageBox.Show(ex.Message, "Error al guardar los datos." & Environment.NewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GuardarEvaluacion()

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarEvaluaciónDesempeño")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@ACCION", 1)
        Else
            Comando.Parameters.AddWithValue("@ACCION", 6)
        End If
        Comando.Parameters.AddWithValue("@IDEVALUACIONDESEMPEÑO", IdEvaluacion)
        Comando.Parameters.AddWithValue("@IDPERSONAEVALUADO", Cu_BuscarEvaluado.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAEVALUA", Cu_BuscarEvaluador.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@PERIODO", Tx_Periodo.Text)
        Comando.Parameters.AddWithValue("@CARGOEVALUADO", Tx_CargoEvaluado.Text)
        Comando.Parameters.AddWithValue("@CARGOEVALUA", Tx_CargoEvaluador.Text)
        Comando.Parameters.AddWithValue("@CORREOELECTRONICOEVALUA", Tx_CorreoEvaluador.Text)
        Comando.Parameters.AddWithValue("@PROYECTO", Tx_Proyecto.Text)
        Comando.Parameters.AddWithValue("@CLAVEACCESOWEB", DBNull.Value)
        Comando.Parameters.AddWithValue("@COM1", DBNull.Value)
        Comando.Parameters.AddWithValue("@COM2", DBNull.Value)
        Comando.Parameters.AddWithValue("@COM3", DBNull.Value)
        Comando.Parameters.AddWithValue("@EXP1", DBNull.Value)
        Comando.Parameters.AddWithValue("@EXP2", DBNull.Value)
        Comando.Parameters.AddWithValue("@EXP3", DBNull.Value)
        Comando.Parameters.AddWithValue("@OPT1", DBNull.Value)
        Comando.Parameters.AddWithValue("@OPT2", DBNull.Value)
        Comando.Parameters.AddWithValue("@OPT3", DBNull.Value)
        Comando.Parameters.AddWithValue("@ORI1", DBNull.Value)
        Comando.Parameters.AddWithValue("@ORI2", DBNull.Value)
        Comando.Parameters.AddWithValue("@ORI3", DBNull.Value)
        Comando.Parameters.AddWithValue("@PLA1", DBNull.Value)
        Comando.Parameters.AddWithValue("@PLA2", DBNull.Value)
        Comando.Parameters.AddWithValue("@PLA3", DBNull.Value)
        Comando.Parameters.AddWithValue("@GES1", DBNull.Value)
        Comando.Parameters.AddWithValue("@GES2", DBNull.Value)
        Comando.Parameters.AddWithValue("@GES3", DBNull.Value)
        Comando.Parameters.AddWithValue("@CAP1", DBNull.Value)
        Comando.Parameters.AddWithValue("@CAP2", DBNull.Value)
        Comando.Parameters.AddWithValue("@CAP3", DBNull.Value)
        Comando.Parameters.AddWithValue("@OBS1", DBNull.Value)
        Comando.Parameters.AddWithValue("@OBS2", DBNull.Value)
        Comando.Parameters.AddWithValue("@OBS3", DBNull.Value)
        Comando.Parameters.AddWithValue("@DIN1", DBNull.Value)
        Comando.Parameters.AddWithValue("@DIN2", DBNull.Value)
        Comando.Parameters.AddWithValue("@DIN3", DBNull.Value)
        Comando.Parameters.AddWithValue("@TRA1", DBNull.Value)
        Comando.Parameters.AddWithValue("@TRA2", DBNull.Value)
        Comando.Parameters.AddWithValue("@TRA3", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG1", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG2", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG3", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG4", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG5", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG6", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG7", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG8", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG9", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG10", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG11", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG12", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG13", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG14", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG15", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG16", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG17", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG18", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG19", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEG20", DBNull.Value)
        Comando.Parameters.AddWithValue("@SST1", DBNull.Value)
        Comando.Parameters.AddWithValue("@SST2", DBNull.Value)
        Comando.Parameters.AddWithValue("@SST3", DBNull.Value)
        Comando.Parameters.AddWithValue("@SST4", DBNull.Value)
        Comando.Parameters.AddWithValue("@ASPECTOMEJORAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@NIVELDESEMPEÑOTOTAL", DBNull.Value)
        Comando.Parameters.AddWithValue("@IDUSUARIOREGISTRO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@ESTADO", Cb_Estado.SelectedValue)

        Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim msgParam1 As New SqlParameter("@CONSECUTIVO", SqlDbType.NChar, 8)
        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam1)


        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        MsgBox("Evaluación Guardada", MsgBoxStyle.Information, "Guardado")
        _guardado = True
        conn.Close()
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "ED", "EVALUADO", Cu_BuscarEvaluado.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "ED", "EVALUADOR", Cu_BuscarEvaluador.Cb_Persona.SelectedValue)
        Me.Close()

    End Sub


    Private Function ValidarDocumento() As Boolean

        If Trim(Tx_Proyecto.Text) = "" Then
            MsgBox("Agrege el proyecto", MsgBoxStyle.Critical, "PROYECTO")
            ValidarDocumento = False
            Tx_Proyecto.Focus()
            Exit Function
        End If

        If Trim(Tx_Periodo.Text) = "" Then
            MsgBox("Agregar el periodo", MsgBoxStyle.Critical, "PERIODO")
            ValidarDocumento = False
            Tx_Periodo.Focus()
            Exit Function
        End If

        If Trim(Tx_CargoEvaluador.Text) = "" Then
            MsgBox("Agregar el cargo del evaluador", MsgBoxStyle.Critical, "CARGO")
            ValidarDocumento = False
            Tx_CargoEvaluador.Focus()
            Exit Function
        End If

        If Trim(Tx_CargoEvaluado.Text) = "" Then
            MsgBox("Agregar el cargo del evaluado.", MsgBoxStyle.OkOnly, "CARGO")
            Tx_CargoEvaluado.Focus()
            Return False
        End If

        If Trim(Tx_CorreoEvaluador.Text) = "" Then
            MsgBox("Agregar el correo del evaluador.", MsgBoxStyle.OkOnly, "CORREO EVALUADOR")
            Tx_CorreoEvaluador.Focus()
            Return False
        End If

        If Trim(Tx_CorreoEvaluador.Text) <> "" And EmailValido(Tx_CorreoEvaluador.Text) = False Then
            MsgBox("Ingresar un formato valido de correo.", MsgBoxStyle.OkOnly, "CORREO EVALUADOR")
            Tx_CorreoEvaluador.Focus()
            Return False
        End If

        If IsNothing(Cu_BuscarEvaluado.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione el nombre del evaluado", MsgBoxStyle.Critical, "EVALUADO")
            ValidarDocumento = False
            Cu_BuscarEvaluado.Cb_Persona.Focus()
            Exit Function
        End If

        If IsNothing(Cu_BuscarEvaluador.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione el nombre del evaluador ", MsgBoxStyle.Critical, "EVALUADOR")
            ValidarDocumento = False
            Cu_BuscarEvaluador.Cb_Persona.Focus()
            Exit Function
        End If

        If Cu_BuscarEvaluado.Cb_Persona.SelectedValue = Cu_BuscarEvaluador.Cb_Persona.SelectedValue Then
            MsgBox("El nombre del evaluado no puede ser igual al nombre del evaluador", MsgBoxStyle.OkOnly, "NOMBRE")
            ValidarDocumento = False
            Cu_BuscarEvaluado.Cb_Persona.Focus()
            Exit Function
        End If

        ValidarDocumento = True
    End Function


    Public Sub CargarDatosEvaluacion()
        Cu_BuscarEvaluado.Cb_Persona.SelectedValue = Fila_Editar_Evaluacion("IDPERSONAEVALUADO")
        Tx_CargoEvaluado.Text = Fila_Editar_Evaluacion("CARGOEVALUADO")
        Cu_BuscarEvaluador.Cb_Persona.SelectedValue = Fila_Editar_Evaluacion("IDPERSONAEVALUA")
        Tx_CargoEvaluador.Text = Fila_Editar_Evaluacion("CARGOEVALUA")
        If Not IsDBNull(Fila_Editar_Evaluacion("CORREOELECTRONICOEVALUA")) Then
            Tx_CorreoEvaluador.Text = Fila_Editar_Evaluacion("CORREOELECTRONICOEVALUA")
        Else
            Tx_CorreoEvaluador.Text = ""
        End If
        Tx_Proyecto.Text = Fila_Editar_Evaluacion("PROYECTO")
        Tx_Periodo.Text = Fila_Editar_Evaluacion("PERIODO")
        Cb_Estado.SelectedValue = Fila_Editar_Evaluacion("ESTADO")

    End Sub

    Private Shared Function EmailValido(strEmail As String) As Boolean
        ' Retorna verdadero si strEmail es un formato de E-mail valido.
        Return System.Text.RegularExpressions.Regex.IsMatch(strEmail, "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" & "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class