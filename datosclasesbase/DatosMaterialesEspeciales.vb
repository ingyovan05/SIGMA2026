Imports System.Data.SqlClient

Public Module DatosMaterialesEspeciales
    Public Structure MTE_ISOMETRICO
        Const IdIsometrico = "Id" 'IDISOMETRICO
        Const Isometrico = "Isométrico" 'ISOMETRICO
        Const Descripcion = "Descripción" 'DESCRIPCION
        Const Abreviatura = "Abreviatura" 'ABREVIATURA
        Const Revision = "Revisión" 'REVISION
        Const NroHoja = "Nro Hoja" 'NROHOJA
        Const IdProyecto = "Id Proyecto" 'IDPROYECTO
        Const Proyecto = "Proyecto" 'PROYECTO
        Const IdLinea = "Id Línea" 'IDLINEA
        Const Linea = "Línea" 'LINEA
        Const IdUsuarioRegistra = "Id Usuario Registra" 'IDUSUARIOREGISTRA
        Const UsuarioRegistra = "Usuario Registra" 'USUARIOREGISTRA
        Const FechaRegistro = "Fecha Registro" 'FECHAREGISTRO
        Const IdUsuarioModifica = "Id Usuario Modifica" 'IDUSUARIOMODIFICA
        Const UsuarioModifica = "Usuario Modifica" 'USUARIOMODIFICA
        Const FechaModificacion = "Fecha Modificación" 'FECHAMODIFICACION
    End Structure

    Public Structure MTE_ITEMISOMETRICO
        Const IdItemIsometrico = "Ítem" 'IDITEMISOMETRICO
        Const IdIsometrico = "Id Isométrico" 'IDISOMETRICO
        Const Isometrico = "Isométrico" 'ISOMETRICO
        Const IdArticulo = "Id Artículo" 'IDARTICULO
        Const Articulo = "Artículo" 'ARTICULO.NOMBREDESCRIPTIVO
        Const Cantidad = "Cantidad" 'CANTIDAD
        Const CodigoIngenieria = "Código Ingeniería" 'CODIGOINGENIERIA
        Const Colada = "Colada" 'COLADA
        Const Estado = "Estado" 'ESTADO
        Const Ubicacion = "Ubicación" 'UBICACION
        Const IdUsuarioModifica = "Id Usuario Modifica" 'IDUSUARIOMODIFICA
        Const UsuarioModifica = "Usuario Modifica" 'USUARIOMODIFICA
        Const FechaModificacion = "Fecha Modificación" 'FECHAMODIFICACION
    End Structure

    Public Structure MTE_SPOOL
        Const IdSpool = "Id" 'IDSPOOL
        Const Spool = "Spool" 'SPOOL
        Const Descripcion = "Descripción" 'DESCRIPCION
        Const Abreviatura = "Abreviatura" 'ABREVIATURA
        Const Estado = "Estado" 'ESTADO
        Const Ubicacion = "Ubicación" 'UBICACION
        Const IdIsometrico = "Id Isométrico" 'IDISOMETRICO
        Const Isometrico = "Isométrico" 'ISOMETRICO
        Const IdUsuarioRegistra = "Id Usuario Registra" 'IDUSUARIOREGISTRA
        Const UsuarioRegistra = "Usuario Registra" 'USUARIOREGISTRA
        Const FechaRegistro = "Fecha Registro" 'FECHAREGISTRO
        Const IdUsuarioModifica = "Id Usuario Modifica" 'IDUSUARIOMODIFICA
        Const UsuarioModifica = "Usuario Modifica" 'USUARIOMODIFICA
        Const FechaModificacion = "Fecha Modificación" 'FECHAMODIFICACION
    End Structure

    Public Structure MTE_ITEMSPOOL
        Const IdItemSpool = "Ítem" 'IDITEMSPOOL
        Const IdSpool = "Id Spool" 'IDSPOOL
        Const Spool = "Spool" 'SPOOL
        Const IdArticulo = "Id Artículo" 'IDARTICULO
        Const Articulo = "Artículo" 'ARTICULO.NOMBREDESCRIPTIVO
        Const Cantidad = "Cantidad" 'CANTIDAD
        Const CodigoIngenieria = "Código Ingeniería" 'CODIGOINGENIERIA
        Const Colada = "Colada" 'COLADA
        Const Estado = "Estado" 'ESTADO
        Const Ubicacion = "Ubicación" 'UBICACION
        Const IdUsuarioRegistra = "Id Usuario Registra" 'IDUSUARIOREGISTRA
        Const UsuarioRegistra = "Usuario Registra" 'USUARIOREGISTRA
        Const FechaRegistro = "Fecha Registro" 'FECHAREGISTRO
        Const IdUsuarioModifica = "Id Usuario Modifica" 'IDUSUARIOMODIFICA
        Const UsuarioModifica = "Usuario Modifica" 'USUARIOMODIFICA
        Const FechaModificacion = "Fecha Modificación" 'FECHAMODIFICACION
    End Structure

    Public Structure MTE_LINEA
        Const IdLinea = "Id" 'IDLINEA
        Const Linea = "Línea" 'LINEA
        Const Descripcion = "Descripción" 'DESCRIPCION
        Const Abreviatura = "Abreviatura" 'ABREVIATURA
        Const CantidadHojas = "Cantidad Hojas" 'CANTIDADHOJAS
        Const IdProyecto = "Id Proyecto" 'IDPROYECTO
        Const Proyecto = "Proyecto" 'PROYECTO
        Const IdUsuarioRegistra = "Id Usuario Registra" 'IDUSUARIOREGISTRA
        Const UsuarioRegistra = "Usuario Registra" 'USUARIOREGISTRA
        Const FechaRegistro = "Fecha Registro" 'FECHAREGISTRO
        Const IdUsuarioModifica = "Id Usuario Modifica" 'IDUSUARIOMODIFICA
        Const UsuarioModifica = "Usuario Modifica" 'USUARIOMODIFICA
        Const FechaModificacion = "Fecha Modificación" 'FECHAMODIFICACION
    End Structure

    Public Structure MTE_PROYECTO
        Const IdProyecto = "Id" 'IDPROYECTO
        Const Proyecto = "Proyecto" 'PROYECTO
        Const Descripcion = "Descripción" 'DESCRIPCION
        Const Abreviatura = "Abreviatura" 'ABREVIATURA
        Const Activo = "Activo" 'ACTIVO
        Const IdUsuarioRegistra = "Id Usuario Registra" 'IDUSUARIOREGISTRA
        Const UsuarioRegistra = "Usuario Registra" 'USUARIOREGISTRA
        Const FechaRegistro = "Fecha Registro" 'FECHAREGISTRO
        Const IdUsuarioModifica = "Id Usuario Modifica" 'IDUSUARIOMODIFICA
        Const UsuarioModifica = "Usuario Modifica" 'USUARIOMODIFICA
        Const FechaModificacion = "Fecha Modificación" 'FECHAMODIFICACION
    End Structure

    Public Function GestionarIsometrico(accion As Integer, dt_ListaItems As DataTable, idIsometrico As Integer, isometrico As String, descripcion As String, abreviatura As String, _
                                     revision As Integer, nroHoja As Integer, idProyecto As Integer, idLinea As Integer, observacionCancelacion As String) As DataTable
        Dim dt_ItemIsometrico As New DataTable
        If dt_ListaItems.Rows.Count < 1 Then
            dt_ItemIsometrico.Columns.Add("IDITEMISOMETRICO")
            dt_ItemIsometrico.Columns.Add("IDISOMETRICO")
            dt_ItemIsometrico.Columns.Add("IDARTICULO")
            dt_ItemIsometrico.Columns.Add("CANTIDAD")
            dt_ItemIsometrico.Columns.Add("CODIGOINGENIERIA")
            dt_ItemIsometrico.Columns.Add("COLADA")
            dt_ItemIsometrico.Columns.Add("ESTADO")
            dt_ItemIsometrico.Columns.Add("UBICACION")
            dt_ItemIsometrico.Columns.Add("IDUSUARIOMODIFICA")
            dt_ItemIsometrico.Columns.Add("FECHAMODIFICACION")
        Else
            dt_ItemIsometrico = dt_ListaItems
        End If
        Dim comando As New SqlCommand("MTE_GestionarIsometrico")
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", accion)
        comando.Parameters.AddWithValue("@TablaItemIsometrico", dt_ItemIsometrico)
        comando.Parameters.AddWithValue("@IdIsometrico", idIsometrico)
        comando.Parameters.AddWithValue("@Isometrico", isometrico)
        comando.Parameters.AddWithValue("@Descripcion", descripcion)
        comando.Parameters.AddWithValue("@Abreviatura", abreviatura)
        comando.Parameters.AddWithValue("@Revision", revision)
        comando.Parameters.AddWithValue("@NroHoja", nroHoja)
        comando.Parameters.AddWithValue("@IdProyecto", idProyecto)
        comando.Parameters.AddWithValue("@IdLinea", idLinea)
        comando.Parameters.AddWithValue("@IdUsuario", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ObservacionCancelacion", observacionCancelacion)
        Dim ResultadoParam As New SqlParameter("@Resultado", DbType.Int32)
        ResultadoParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(ResultadoParam)
        comando.Connection = New SqlConnection(My.Settings.CadenaConexión)
        Select Case accion
            Case 1, 2, 3
                comando.Connection.Open()
                comando.ExecuteNonQuery()
                comando.Connection.Close()
                Return Nothing
            Case 4, 5, 6, 7, 8, 9
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt_Isometrico As New DataTable
                comando.Connection.Open()
                adaptador.Fill(dt_Isometrico)
                comando.Connection.Close()
                Return dt_Isometrico
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GestionarSpool(accion As Integer, dt_ListaItems As DataTable, idSpool As Integer, spool As String, descripcion As String, abreviatura As String, _
                                     estado As String, ubicacion As String, idIsometrico As Integer, observacionCancelacion As String)
        Dim dt_ItemSpool As New DataTable
        If dt_ListaItems.Rows.Count < 1 Then
            dt_ItemSpool.Columns.Add("IDITEMSPOOL")
            dt_ItemSpool.Columns.Add("IDSPOOL")
            dt_ItemSpool.Columns.Add("IDARTICULO")
            dt_ItemSpool.Columns.Add("CANTIDAD")
            dt_ItemSpool.Columns.Add("CODIGOINGENIERIA")
            dt_ItemSpool.Columns.Add("COLADA")
            dt_ItemSpool.Columns.Add("ESTADO")
            dt_ItemSpool.Columns.Add("UBICACION")
            dt_ItemSpool.Columns.Add("IDUSUARIOREGISTRA")
            dt_ItemSpool.Columns.Add("FECHAREGISTRO")
            dt_ItemSpool.Columns.Add("IDUSUARIOMODIFICA")
            dt_ItemSpool.Columns.Add("FECHAMODIFICACION")
        Else
            dt_ItemSpool = dt_ListaItems
        End If
        Dim comando As New SqlCommand("MTE_GestionarSpool")
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", accion)
        comando.Parameters.AddWithValue("@TablaItemSpool", dt_ItemSpool)
        comando.Parameters.AddWithValue("@IdSpool", idSpool)
        comando.Parameters.AddWithValue("@Spool", spool)
        comando.Parameters.AddWithValue("@Descripcion", descripcion)
        comando.Parameters.AddWithValue("@Abreviatura", abreviatura)
        comando.Parameters.AddWithValue("@Estado", estado)
        comando.Parameters.AddWithValue("@Ubicacion", ubicacion)
        comando.Parameters.AddWithValue("@IdIsometrico", idIsometrico)
        comando.Parameters.AddWithValue("@IdUsuario", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ObservacionCancelacion", observacionCancelacion)
        Dim ResultadoParam As New SqlParameter("@Resultado", DbType.Int32)
        ResultadoParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(ResultadoParam)
        comando.Connection = New SqlConnection(My.Settings.CadenaConexión)
        Select Case accion
            Case 1, 2, 3
                Try
                    comando.Connection.Open()
                    comando.ExecuteNonQuery()
                    comando.Connection.Close()
                Catch ex As Exception
                    Return Nothing
                Finally
                    comando.Connection.Close()
                End Try
                Return Nothing
            Case 4, 5, 6, 7, 8
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt_Spool As New DataTable
                Try
                    comando.Connection.Open()
                    adaptador.Fill(dt_Spool)
                    comando.Connection.Close()
                Catch ex As Exception
                    Return Nothing
                Finally
                    comando.Connection.Close()
                End Try
                Return dt_Spool
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GestionarLinea(accion As Integer, idLinea As Integer, linea As String, descripcion As String, abreviatura As String, cantidadHojas As Integer, _
                                   idProyecto As Integer)
        Dim comando As New SqlCommand("MTE_GestionarLinea")
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", accion)
        comando.Parameters.AddWithValue("@IdLinea", idLinea)
        comando.Parameters.AddWithValue("@Linea", linea)
        comando.Parameters.AddWithValue("@Descripcion", descripcion)
        comando.Parameters.AddWithValue("@Abreviatura", abreviatura)
        comando.Parameters.AddWithValue("@CantidadHojas", cantidadHojas)
        comando.Parameters.AddWithValue("@IdProyecto", idProyecto)
        comando.Parameters.AddWithValue("@IdUsuario", VariablesBase.VariablesBase.IdPersona)
        Dim ResultadoParam As New SqlParameter("@Resultado", DbType.Int32)
        ResultadoParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(ResultadoParam)
        comando.Connection = New SqlConnection(My.Settings.CadenaConexión)
        Select Case accion
            Case 1, 2, 3
                Try
                    comando.Connection.Open()
                    comando.ExecuteNonQuery()
                    comando.Connection.Close()
                Catch ex As Exception
                    Return Nothing
                Finally
                    comando.Connection.Close()
                End Try
                Return Nothing
            Case 4, 5, 6, 7, 8, 9
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt_Linea As New DataTable
                Try
                    comando.Connection.Open()
                    adaptador.Fill(dt_Linea)
                    comando.Connection.Close()
                Catch ex As Exception
                    Return Nothing
                Finally
                    comando.Connection.Close()
                End Try
                Return dt_Linea
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GestionarProyecto(accion As Integer, idProyecto As Integer, proyecto As String, descripcion As String, abreviatura As String, activo As String)
        Dim comando As New SqlCommand("MTE_GestionarProyecto")
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", accion)
        comando.Parameters.AddWithValue("@IdProyecto", idProyecto)
        comando.Parameters.AddWithValue("@Proyecto", proyecto)
        comando.Parameters.AddWithValue("@Descripcion", descripcion)
        comando.Parameters.AddWithValue("@Abreviatura", abreviatura)
        comando.Parameters.AddWithValue("@Activo", activo)
        comando.Parameters.AddWithValue("@IdUsuario", VariablesBase.VariablesBase.IdPersona)
        Dim ResultadoParam As New SqlParameter("@Resultado", DbType.Int32)
        ResultadoParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(ResultadoParam)
        comando.Connection = New SqlConnection(My.Settings.CadenaConexión)
        Select Case accion
            Case 1, 2, 3
                Try
                    comando.Connection.Open()
                    comando.ExecuteNonQuery()
                    comando.Connection.Close()
                Catch ex As Exception
                    Return Nothing
                Finally
                    comando.Connection.Close()
                End Try
                Return Nothing
            Case 4, 6, 7
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt_Proyecto As New DataTable
                Try
                    comando.Connection.Open()
                    adaptador.Fill(dt_Proyecto)
                    comando.Connection.Close()
                Catch ex As Exception
                    Return Nothing
                Finally
                    comando.Connection.Close()
                End Try
                Return dt_Proyecto
            Case Else
                Return Nothing
        End Select
    End Function

End Module