Public Class ClaseDatosActivosFijos

    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter


    Public Function ModificarTipos(ByVal accion As Integer, ByVal idtipo As Integer, ByVal idsubtipo As Integer, ByVal descripcion As String,
                                   ByVal nomenclaturatipo As String, ByVal nomenclaturasubtipo As String)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarTiposArticulos"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = idtipo
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = idsubtipo
            cmde.Parameters.Add("@descripcion", SqlDbType.VarChar, 150).Value = descripcion
            cmde.Parameters.Add("@nomtipo", SqlDbType.VarChar, 3).Value = nomenclaturatipo
            cmde.Parameters.Add("@nomsubtipo", SqlDbType.VarChar, 3).Value = nomenclaturasubtipo
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


    Public Function ModificarCaracteristicas(ByVal accion As Integer, ByVal idtipo As Integer, ByVal idsubtipo As Integer, ByVal idcaracteristica As Integer, ByVal idequipo As Integer,
                                             ByVal nombrecaracteristica As String, ByVal descripcioncaracteristica As String, ByVal idcaracteristicaequipo As Integer, ByVal tipovalor As Integer, ByVal valorbool As Boolean, ByVal valortext As String,
                                             ByVal valornum As Nullable(Of Decimal), ByVal valorfecha As Nullable(Of DateTime), ByVal irrepetible As String)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarCaracteristicasArticulos"
            'descripcion de los valores en el procedimiento.
            If valortext = Nothing Then
                valortext = ""
            End If
            If valorbool = Nothing Then
                valorbool = False
            End If
            If valornum = Nothing Then
                valornum = 0
            End If
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = idtipo
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = idsubtipo
            cmde.Parameters.Add("@idcaracteristica", SqlDbType.Int).Value = idcaracteristica
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = idequipo
            cmde.Parameters.Add("@nombrecaracteristica", SqlDbType.VarChar, 50).Value = nombrecaracteristica
            cmde.Parameters.Add("@descripcioncaracteristica", SqlDbType.VarChar, 150).Value = descripcioncaracteristica
            cmde.Parameters.Add("@idcaracteristicaequipo", SqlDbType.Int).Value = idcaracteristicaequipo
            cmde.Parameters.Add("@tipovalor", SqlDbType.Int).Value = tipovalor
            cmde.Parameters.Add("@valorbool", SqlDbType.Bit).Value = valorbool '1 = TEXTUAL, 2 = NUMERICO, 3 = SI/NO, 4 = FECHA
            cmde.Parameters.Add("@valortext", SqlDbType.VarChar, 50).Value = valortext

            If valornum Is Nothing Then
                cmde.Parameters.Add("@valornum", SqlDbType.Float).Value = DBNull.Value
            Else
                cmde.Parameters.Add("@valornum", SqlDbType.Float).Value = valornum
            End If


            If valorfecha Is Nothing Then
                cmde.Parameters.Add("@valorfecha", SqlDbType.DateTime).Value = DBNull.Value
            Else
                cmde.Parameters.Add("@valorfecha", SqlDbType.DateTime).Value = valorfecha
            End If

            cmde.Parameters.Add("@irrepetible", SqlDbType.NVarChar, 1).Value = irrepetible
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

    Public Function ModificarArticulos(ByVal TIPO As Integer, ByVal IDARTICULOMOD As Integer, ByVal CODIGOCATEGORIA As Integer, ByVal NOMBRE As String, ByVal NOMBREDESCRIPTIVO As String, ByVal CODIGOBARRAISMOCOL As String, ByVal TARIFAIVA As Double, ByVal ESTADOARTICULO As String, ByVal CODIGOTIPOUNIDAD As Integer, ByVal CODIGOACCESS As String, ByVal IDUSUARIO As Integer, ByVal IDTIPO As Integer, ByVal IDSUBTIPO As Integer, ByVal IDARTICULO As Integer)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarArtículo"
            cmde.Parameters.Add("@TIPO", SqlDbType.Int).Value = TIPO
            cmde.Parameters.Add("@IDARTICULOMOD", SqlDbType.Int).Value = IDARTICULOMOD
            cmde.Parameters.Add("@CODIGOCATEGORIA", SqlDbType.Int).Value = CODIGOCATEGORIA
            cmde.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 50).Value = NOMBRE
            cmde.Parameters.Add("@NOMBREDESCRIPTIVO", SqlDbType.NChar, 200).Value = NOMBREDESCRIPTIVO
            cmde.Parameters.Add("@CODIGOBARRAISMOCOL", SqlDbType.NChar, 100).Value = CODIGOBARRAISMOCOL
            cmde.Parameters.Add("@TARIFAIVA", SqlDbType.Float).Value = TARIFAIVA
            cmde.Parameters.Add("@ESTADOARTICULO", SqlDbType.NChar, 1).Value = ESTADOARTICULO
            cmde.Parameters.Add("@CODIGOTIPOUNIDAD", SqlDbType.Int).Value = CODIGOTIPOUNIDAD
            cmde.Parameters.Add("@CODIGOACCESS", SqlDbType.NChar, 15).Value = CODIGOACCESS
            cmde.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = IDUSUARIO
            cmde.Parameters.Add("@IDTIPO", SqlDbType.Int).Value = IDTIPO
            cmde.Parameters.Add("@IDSUBTIPO", SqlDbType.Int).Value = IDSUBTIPO
            cmde.Parameters.Add("@IDARTICULO", SqlDbType.Int).Value = IDARTICULO
            cmde.Parameters.Add("@VALORREFERENCIA", SqlDbType.Decimal).Value = DBNull.Value
            cmde.Parameters.Add("@FECHAMODIFICACIONREF", SqlDbType.DateTime).Value = DateTime.Now
            cmde.Parameters.Add("@IDUSUARIOMODIFICAREF", SqlDbType.Int).Value = DBNull.Value

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

    Public Function ModificarMarcasModelos(ByVal accion As Integer, ByVal idmodelo As Integer, ByVal idmarca As Integer, ByVal nombremodelo As String, ByVal nombremarca As String)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarModeloMarca"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@idmodelo", SqlDbType.Int).Value = idmodelo
            cmde.Parameters.Add("@idmarca", SqlDbType.Int).Value = idmarca
            cmde.Parameters.Add("@nombremodelo", SqlDbType.VarChar, 50).Value = nombremodelo
            cmde.Parameters.Add("@nombremarca", SqlDbType.VarChar, 50).Value = nombremarca
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

    Public Function ModificarEquipos(ByVal accion As Integer, ByVal idproveedor As Integer, ByVal idarticulo As Integer, ByVal idequipo As Integer,
                                     ByVal idtipo As Integer, ByVal idsubtipo As Integer, ByVal idestado As Integer, ByVal idequipopadre As Integer,
                                     ByVal idbodegaingreso As Integer, ByVal idpersonaingreso As Integer, ByVal idpersonaregistro As Integer, ByVal idpersonaactual As Integer,
                                     ByVal idbodega As Integer, ByVal idmodelo As Integer, ByVal idmarca As Integer, ByVal descripcionequipo As String,
                                     ByVal codigoismocol As String, ByVal codigoaccess As String, ByVal codigomecanico As String, ByVal activo As Boolean,
                                     ByVal fechaingreso As Date)

        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarEquipos"

            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion '--ACCION 
            cmde.Parameters.Add("@idproveedor", SqlDbType.Int).Value = idproveedor '--ID DEL PROVEEDOR
            cmde.Parameters.Add("@idarticulo", SqlDbType.Int).Value = idarticulo '--ID DEL ARTICULO AL QUE PERTENECE EL EQUIPO
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = idequipo '--ID DEL EQUIPO
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = idtipo '--ID DEL TIPO DE ARTICULO
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = idsubtipo '--ID DEL SUBTIPO DE ARTICULO
            cmde.Parameters.Add("@idestado", SqlDbType.Int).Value = idestado '--ESTADO DEL EQUIPO
            cmde.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = idequipopadre '--ID DEL EQUIPO PADRE
            cmde.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = idbodegaingreso '-- ID DE LA BODEGA EN DONDE SE REGISTRO EN FISICO POR PRIMERA VEZ	
            cmde.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = idpersonaingreso '-- ID DE LA PERSONA QUE REGISTRA EL EQUIPO EN FISICO POR PRIMERA VEZ
            cmde.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = idpersonaregistro '-- ID DE LA PERSONA QUE REGISTRA EL EQUIPO EN EL SISTEMA POR PRIMERA VEZ
            cmde.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = idpersonaactual '-- ID DE LA PERSONA ASIGNADA ACTUALMENTE AL EQUIPO
            cmde.Parameters.Add("@idmodelo", SqlDbType.Int).Value = idmodelo '-- MODELO DEL EQUIPO
            cmde.Parameters.Add("@idmarca", SqlDbType.Int).Value = idmarca '-- MARCA DEL EQUIPO
            cmde.Parameters.Add("@idbodega", SqlDbType.Int).Value = idbodega '-- ID DE BODEGA
            cmde.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = descripcionequipo ' --DESCRIPCION DEL EQUIPO
            cmde.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = codigoismocol '--CODIGO ISMOCOL VIENO
            cmde.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = codigoaccess '-- CODIGO ACCES VIEJO
            cmde.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = codigomecanico '--CODIGO MECANICO VIEJO
            cmde.Parameters.Add("@activo", SqlDbType.Bit).Value = activo '--ES ACTIVO / NO ES ACTIVO
            cmde.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = fechaingreso '-- FECHA DE REGISTRO DEL ARTICULO POR PRIMERA VEZ


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

    Public Function ModificarEntradasSalidas(ByVal accion As Integer, ByVal idregistro As Integer, ByVal idequipo As Integer, ByVal idbodegaentrada As Integer, ByVal fechaentrada As Date, ByVal idbodegasalida As Integer, ByVal fechasalida As Date, ByVal estado As String, ByVal idsalidaalmacen As Integer, ByVal identradaalmacen As Integer, Optional TABLA_IDEQUPO As DataTable = Nothing)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarEntradasSalidasBodegaEquipos"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@idregistro", SqlDbType.Int).Value = idregistro
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = idequipo
            cmde.Parameters.Add("@idbodegaentrada", SqlDbType.Int).Value = idbodegaentrada
            cmde.Parameters.Add("@fechaentrada", SqlDbType.Date).Value = fechaentrada
            cmde.Parameters.Add("@idbodegasalida", SqlDbType.Int).Value = idbodegasalida
            cmde.Parameters.Add("@fechasalida", SqlDbType.Date).Value = fechasalida
            cmde.Parameters.Add("@estado", SqlDbType.NChar, 1).Value = estado
            cmde.Parameters.Add("@idsalidaalmacen", SqlDbType.Int).Value = idsalidaalmacen
            cmde.Parameters.Add("@identradaalmacen", SqlDbType.Int).Value = identradaalmacen
            cmde.Parameters.Add("@TABLA_IDEQUPO", SqlDbType.Structured).Value = TABLA_IDEQUPO


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

    Public Function ModificarCustodias(ByVal accion As Integer, ByVal idcustodia As Integer,
                                       ByVal idequipo As Integer, ByVal idestado As Integer, ByVal idpersonaasignada As Integer,
                                       ByVal idsalida As Integer, ByVal identrada As Integer)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarCustodias"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@idcustodia", SqlDbType.Int).Value = idcustodia
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = idequipo
            cmde.Parameters.Add("@idestado", SqlDbType.Int).Value = idestado
            cmde.Parameters.Add("@idpersonaasignada", SqlDbType.Int).Value = idpersonaasignada
            cmde.Parameters.Add("@idsalida", SqlDbType.Int).Value = idsalida
            cmde.Parameters.Add("@identrada", SqlDbType.Int).Value = identrada
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
