Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_RegistrarTemperatura

    Property IdPersona As Integer
    Property IdEncuesta As Integer
    Property FechaRegistro As DateTime
    Property Base As String

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

        Dim fila As DataRow
        fila = dsMaestras.Tables(0).Rows(0)
        Me.Lb_Nombre.Text = "Nombre: " & fila("NOMBRECOMPLETO")
        Me.Lb_FechaRegistro.Text = "Fecha Registro: " & FechaRegistro.ToString
        Me.Lb_Base.Text = "Base: " & Base.ToString
    End Sub


    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click

        If ValidarTemperatura() = True Then
            GuardarTemperatura()
        End If
    End Sub

    Private Sub GuardarTemperatura()
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

        comando.Parameters("@ACCION").Value = 7
        comando.Parameters("@ID_DM_ENCUESTA").Value = IdEncuesta
        comando.Parameters("@FECHAENCUESTA").Value = DBNull.Value
        comando.Parameters("@CLAVEACCESOWEB").Value = DBNull.Value
        comando.Parameters("@IDPERSONA").Value = IdPersona
        comando.Parameters("@PROYECTO").Value = Tb_Temperatura.Text
        comando.Parameters("@IDBASESISCONTROL").Value = DBNull.Value
        comando.Parameters("@EDAD").Value = DBNull.Value
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
        comando.Parameters("@CORREOELECTRONICO").Value = DBNull.Value
        comando.Parameters("@IDPERSONARESPONDE").Value = DBNull.Value
        comando.Parameters("@FECHARESPONDE").Value = DBNull.Value
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
            MsgBox("Temperatura Guardada", MsgBoxStyle.Information, "Guardado")
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Tb_Temperatura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_Temperatura.KeyPress
        If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Function ValidarTemperatura() As Boolean
        If IsNumeric(Tb_Temperatura.Text) = False Then
            MsgBox("El valor del servicio debe ser numérico", MsgBoxStyle.Critical, "VALOR TEMPERATURA")
            Tb_Temperatura.Text = ""
            Me.Tb_Temperatura.Focus()
            ValidarTemperatura = False
            Exit Function
        End If
        If Tb_Temperatura.Text > 50 Then
            MsgBox("El valor de la temperatura debe ser menor a 50", MsgBoxStyle.Critical, "VALOR TEMPERATURA")
            Me.Tb_Temperatura.Focus()
            ValidarTemperatura = False
            Exit Function
        End If
        If Tb_Temperatura.Text < 25 Then
            MsgBox("El valor de la temperatura debe ser mayor a 25", MsgBoxStyle.Critical, "VALOR TEMPERATURA")
            Me.Tb_Temperatura.Focus()
            ValidarTemperatura = False
            Exit Function
        End If
        ValidarTemperatura = True
    End Function


 
End Class