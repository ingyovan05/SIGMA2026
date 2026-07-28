Public Class DatosCompras

    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter

    Public Function GestionarRequisiciones(ByVal accion As Integer, ByVal idusuario As Integer, ByVal idrequisicion As Integer, ByVal idordencompra As Integer)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.PWM_GestionarCompras"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@idpersona", SqlDbType.Int).Value = idusuario
            cmde.Parameters.Add("@idrequisicion", SqlDbType.Int).Value = idrequisicion
            cmde.Parameters.Add("@idordencompra", SqlDbType.Int).Value = idordencompra
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
            Return datas

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()

        End Try

    End Function

    Public Function GestionarComentarios(ByVal accion As Integer, ByVal comentario As String, ByVal idcomentario As Integer, ByVal fechacomentario As DateTime,
                                         ByVal idpersonacomenta As Integer, ByVal tipodocumento As String, ByVal iddocumento As Integer)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.PWM_GestionarComentarios"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@comentario", SqlDbType.Text).Value = comentario
            cmde.Parameters.Add("@idcomentario", SqlDbType.Int).Value = idcomentario
            cmde.Parameters.Add("@fechacomentario", SqlDbType.DateTime).Value = fechacomentario
            cmde.Parameters.Add("@idpersonacomenta", SqlDbType.Int).Value = idpersonacomenta
            cmde.Parameters.Add("@tipodocumento", SqlDbType.NChar, 2).Value = tipodocumento
            cmde.Parameters.Add("@iddocumento", SqlDbType.Int).Value = iddocumento
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
            Return datas

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()

        End Try

    End Function
End Class
