Public Class ClaseDatosSisControl

    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter


    Public Function ModificarDesprendibles(ByVal accion As Integer, ByVal IDDESPRENDIBLE As Integer, ByVal NRO As Integer, ByVal CODIGO As Integer, ByVal CEDULA As Double, ByVal CARGO As String,
                                    ByVal FRENTE As Integer, ByVal N_FRENTE As String, ByVal APELLIDOS As String, ByVal NOMBRES As String, ByVal F_INGRESO As Date, ByVal S_BASICO As Double,
                                    ByVal CONCEPTO As Integer, ByVal NOMBRE_CONCEPTO As String, ByVal CANT As Integer, ByVal VALOR As Double, ByVal DETALLE As String,
                                    ByVal CORREO_ELECTRONICO As String, ByVal FECHAENVIO As Date)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarCorreosNomina"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@IDDESPRENDIBLE", SqlDbType.Int).Value = IDDESPRENDIBLE
            cmde.Parameters.Add("@NRO", SqlDbType.Int).Value = NRO
            cmde.Parameters.Add("@CODIGO", SqlDbType.Int).Value = CODIGO
            cmde.Parameters.Add("@CEDULA", SqlDbType.Float).Value = CEDULA
            cmde.Parameters.Add("@CARGO", SqlDbType.VarChar, 150).Value = CARGO
            cmde.Parameters.Add("@FRENTE", SqlDbType.Int).Value = FRENTE
            cmde.Parameters.Add("@N_FRENTE", SqlDbType.VarChar, 150).Value = N_FRENTE
            cmde.Parameters.Add("@APELLIDOS", SqlDbType.VarChar, 150).Value = APELLIDOS
            cmde.Parameters.Add("@NOMBRES", SqlDbType.VarChar, 150).Value = NOMBRES
            cmde.Parameters.Add("@F_INGRESO", SqlDbType.Date).Value = F_INGRESO
            cmde.Parameters.Add("@S_BASICO", SqlDbType.Float).Value = S_BASICO
            cmde.Parameters.Add("@CONCEPTO", SqlDbType.Int).Value = CONCEPTO
            cmde.Parameters.Add("@NOMBRE_CONCEPTO", SqlDbType.VarChar, 150).Value = NOMBRE_CONCEPTO
            cmde.Parameters.Add("@CANT", SqlDbType.Int).Value = CANT
            cmde.Parameters.Add("@VALOR", SqlDbType.Float).Value = VALOR
            cmde.Parameters.Add("@DETALLE", SqlDbType.VarChar, 150).Value = DETALLE
            cmde.Parameters.Add("@CORREO_ELECTRONICO", SqlDbType.VarChar, 150).Value = CORREO_ELECTRONICO
            cmde.Parameters.Add("@FECHAENVIO", SqlDbType.Date).Value = FECHAENVIO

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
