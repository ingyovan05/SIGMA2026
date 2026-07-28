Imports PIA = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Text
Imports System.Net.Mail

Public Class FuncionesBase

    Public Shared Sub AbrirAyudaOnline(ByVal ruta As String)
        Try
            If TIPOCONEXIONLOCAL() Then
                Dim sinfo As New ProcessStartInfo("http://192.168.20.7:4040" + ruta)
                Process.Start(sinfo)
            Else
                Dim sinfo As New ProcessStartInfo("http://190.0.43.174:4040" + ruta)
                Process.Start(sinfo)
            End If
        Catch ex As Exception
            MsgBox("Existe un problema al intentar abrir la ayuda en linea, por favor comunicarlo a soporte")
        End Try
    End Sub

    Public Shared Sub EstablecerEstiloDatagrid()
        VariablesBase.VariablesBase.DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Dim fuente As System.Drawing.Font
        fuente = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VariablesBase.VariablesBase.style.Font = fuente

    End Sub


    Public Shared Function Cargar_Configuración() As Boolean
        Try
            VariablesBase.VariablesBase.TablaCorreosEnviados.Columns.Add("CorreoPara", Type.GetType("System.String"))
            VariablesBase.VariablesBase.TablaCorreosEnviados.Columns.Add("Enviado", Type.GetType("System.String"))
            VariablesBase.VariablesBase.TablaCorreosEnviados.Columns.Add("Fecha", Type.GetType("System.DateTime"))
            VariablesBase.VariablesBase.TablaCorreosEnviados.Columns.Add("CorreoOrigen", Type.GetType("System.String"))
        Catch ex As Exception
        End Try
        Try
            EstablecerEstiloDatagrid()
            'para envio de correo en bloque
            Cargar_Configuración = True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Cargar_Configuración = False
        End Try
    End Function

    Public Shared Sub RegistrarCorreoEnviado(ByVal CorreoPara As String, ByVal Enviado As String, ByVal CorreoOrigen As String)
        Dim fila As DataRow
        fila = VariablesBase.VariablesBase.TablaCorreosEnviados.NewRow
        fila("CorreoPara") = CorreoPara
        fila("Enviado") = Enviado
        fila("Fecha") = Date.Now()
        fila("CorreoOrigen") = CorreoOrigen
        VariablesBase.VariablesBase.TablaCorreosEnviados.Rows.Add(fila)
    End Sub




    Public Shared Function Encryptar(ByVal Clave As String) As String
        Dim indice As Integer = 1
        Dim largo As Integer = 0
        Dim final As String = ""
        largo = Len(Trim(Clave))
        Dim caracteres(largo) As String
        For indice = 1 To largo
            caracteres(indice) = Mid(Clave, indice, 1)
            caracteres(indice) = Chr(Asc(caracteres(indice)) + (indice + largo))
        Next indice
        For indice = largo To 1 Step -1
            final = final & caracteres(indice)
        Next indice
        Return final
    End Function


    Public Shared Function Desencryptar(ByVal Clave As String) As String
        Dim indice As Integer = 1
        Dim largo As Integer = 0
        Dim final As String = ""
        largo = Len(Trim(Clave))
        Dim caracteres(largo) As String
        Dim invert(largo) As String
        For indice = 1 To largo
            invert(indice) = Mid(Clave, indice, 1)
            final = invert(indice) & final
        Next indice
        Clave = final
        final = ""
        For indice = 1 To largo
            caracteres(indice) = Mid(Clave, indice, 1)
            caracteres(indice) = Chr(Asc(caracteres(indice)) - (indice + largo))
            final = final & caracteres(indice)
        Next indice
        Return final
    End Function


    Public Shared Function Probar_Conexion_Remota_Sql_Server() As Boolean
        Try
            VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.Open()
            VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.Close()
            Probar_Conexion_Remota_Sql_Server = True

            My.Settings.CadenaConexión = VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString

        Catch ex As Exception
            MsgBox("No se tiene acceso al origen de datos", MsgBoxStyle.Critical, _
                    "CONECTANDO A " + VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.DataSource.ToString)
            Probar_Conexion_Remota_Sql_Server = False
        End Try
    End Function


    Public Shared Function Siguiente(ByVal tabla As String, Optional ByVal VARIABLE As Integer = 0, Optional ByVal FECHA As Date = Nothing) As Integer
        Try
            Dim Cadena_Consulta As String = ""
            Select Case tabla
                Case "OBSERVACION"
                    Cadena_Consulta = "SELECT MAX(CODIGOOBSERVACION) FROM OBSERVACION"
                Case "PERSONA"
                    Cadena_Consulta = "SELECT MAX(IDPERSONA) FROM PERSONA"
                Case "SC_LEGALIZACION"
                    Cadena_Consulta = "SELECT MAX(IDLEGALIZACION) FROM SC_LEGALIZACION"
                Case "SC_COMPROBANTE"
                    Cadena_Consulta = "SELECT MAX(IDCOMPROBANTE) FROM SC_COMPROBANTE"
                Case "SC_CONCEPTOADICIONALLEGALIZACION"
                    Cadena_Consulta = "SELECT MAX(IDCONCEPTOADICIONALLEGALIZACION) FROM SC_CONCEPTOADICIONALLEGALIZACION"
                Case "SC_CONSECUTIVOLEGALIZACION"
                    Cadena_Consulta = "SELECT MAX(CONSECUTIVO) FROM SC_LEGALIZACION WHERE YEAR(FECHALEGALIZACION) ='" + Format(FECHA, "yyyy") + "'"
                Case "CONCEPTOADICIONAL"
                    Cadena_Consulta = "SELECT MAX(IDCONCEPTOADICIONALLEGALIZACION ) FROM SC_CONCEPTOADICIONALLEGALIZACION "
                Case "BODEGA"
                    Cadena_Consulta = "SELECT MAX(IDBODEGA) FROM BODEGA"
                Case "AUD_PERSONA"
                    Cadena_Consulta = "SELECT MAX(IDAUDITORIAPERSONA) FROM AUD_PERSONA"
            End Select
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            Dim ULTIMOELEMENTO As Integer = Consulta.ExecuteScalar
            Consulta.Connection.Close()

            Siguiente = ULTIMOELEMENTO + 1
        Catch ex As Exception
            Siguiente = 1
        End Try
    End Function


    Public Shared Function ExisteComprobante(ByVal CodigoComprobante As String, ByVal NumeroComprobante As Integer) As String
        Try

            Dim Cadena_Consulta As String = "SELECT l.CONSECUTIVO FROM SC_COMPROBANTE c, SC_LEGALIZACION l WHERE c.CODIGOTIPOCOMPROBANTE = " + CodigoComprobante + " AND c.NUMEROCOMPROBANTE = " + CStr(NumeroComprobante) + " AND l.IDLEGALIZACION = c.IDLEGALIZACION "
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)

            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            ExisteComprobante = CStr(Consulta.ExecuteScalar)
            Consulta.Connection.Close()
        Catch ex As Exception
            ExisteComprobante = ""
        End Try
    End Function


    Public Shared Function ExisteConsecutivo(ByVal consecutivo As String) As Boolean
        Try
            Dim Cadena_Consulta As String = "SELECT CONSECUTIVO FROM SC_LEGALIZACION WHERE CONSECUTIVO = " + consecutivo + " AND YEAR(FECHALEGALIZACION )= YEAR(GETDATE())"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            Dim valor As String = CStr(Consulta.ExecuteScalar)
            If valor = "" Then
                ExisteConsecutivo = False
            Else
                ExisteConsecutivo = True
            End If
            Consulta.Connection.Close()
        Catch ex As Exception
            ExisteConsecutivo = False
        End Try
    End Function


    Public Shared Function ConsultarIdPersona(ByVal IDENTIFICACION As String) As String
        Try
            Dim Cadena_Consulta As String = _
                "SELECT P.IDPERSONA FROM PERSONA P WHERE LTRIM ( RTRIM(IDENTIFICACION))='" + IDENTIFICACION + "'"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            ConsultarIdPersona = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception
            ConsultarIdPersona = -1
        End Try
    End Function


    Public Shared Function ConsultarLegalizacionExistente(ByVal idpersona As String, ByVal FechaDesde As Date, ByVal Estado As String, ByVal idlegalizacion As Integer, ByVal Recuperar As Boolean) As Boolean
        Dim SqlEstado As String = "IS NULL"
        Dim SqlLegalizacion As String = "  AND IDLEGALIZACION <> "
        Select Case Estado
            Case "NULL"
                SqlEstado = "IS NULL"
            Case "N"
                SqlEstado = "= 'N'"
            Case "E"
                SqlEstado = "= 'E'"
        End Select
        If Recuperar Then
            SqlLegalizacion = "  AND IDLEGALIZACION = "
        Else
            SqlLegalizacion = "  AND IDLEGALIZACION <> "
        End If

        Try
            Dim Cadena_Consulta As String = "SELECT IDLEGALIZACION FROM SC_LEGALIZACION WHERE IDPERSONA ='" + idpersona + "' AND FECHADESDE = '" + Format(FechaDesde, "yyyy-MM-dd") + "' AND ESTADOLEGALIZACION " + SqlEstado + SqlLegalizacion & idlegalizacion
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            If Consulta.ExecuteScalar() > 0 Then
                ConsultarLegalizacionExistente = True
            Else
                ConsultarLegalizacionExistente = False
            End If
            Consulta.Connection.Close()
        Catch ex As Exception
            ConsultarLegalizacionExistente = False
        End Try
    End Function


    Public Shared Function ConsultarConsecutio_idpersonaFecha(ByVal idpersona As String, ByVal FechaDesde As Date, ByVal Estado As String, ByVal idlegalizacion As Integer, ByVal Recuperar As Boolean) As String
        Dim SqlEstado As String = "IS NULL"
        Dim SqlLegalizacion As String = "  AND IDLEGALIZACION <> "
        Select Case Estado
            Case "NULL"
                SqlEstado = "IS NULL"
            Case "N"
                SqlEstado = "= 'N'"
            Case "E"
                SqlEstado = "= 'E'"
        End Select


        If Recuperar Then
            SqlLegalizacion = "  AND IDLEGALIZACION = "
        Else
            SqlLegalizacion = "  AND IDLEGALIZACION <> "
        End If

        Try
            Dim Cadena_Consulta As String = "SELECT CONSECUTIVO FROM SC_LEGALIZACION WHERE IDPERSONA ='" + idpersona + "' AND FECHADESDE = '" + Format(FechaDesde, "yyyy-MM-dd") + "' AND ESTADOLEGALIZACION " + SqlEstado + SqlLegalizacion & idlegalizacion
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            ConsultarConsecutio_idpersonaFecha = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception

        End Try
    End Function


    Public Shared Function ConsultaridentificacionPersona(ByVal IDPERSONA As String) As String
        Try
            Dim Cadena_Consulta As String = _
                "SELECT P.IDENTIFICACION FROM PERSONA P WHERE IDPERSONA='" + IDPERSONA + "'"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            ConsultaridentificacionPersona = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception
            ConsultaridentificacionPersona = -1
        End Try
    End Function


    Public Shared Function ConsultarNombrePersona(ByVal IDENTIFICACION As String) As String
        Try
            Dim Cadena_Consulta As String = _
                "SELECT dbo.Personanombrecompleto(P.IDPERSONA) FROM PERSONA P WHERE LTRIM ( RTRIM(IDENTIFICACION))='" + IDENTIFICACION + "'"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            ConsultarNombrePersona = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception
            ConsultarNombrePersona = ""
        End Try
    End Function


    Public Shared Function ConsultarIdentidadTabla(ByVal NOMBRETABLA As String) As Integer
        Try
            Dim Cadena_Consulta As String = _
                "SELECT IDENT_CURRENT('" + NOMBRETABLA + "')"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            ConsultarIdentidadTabla = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception
            ConsultarIdentidadTabla = 0
        End Try
    End Function

    Public Shared Function CONSULTARULTIMOCONTRATOACTIVOXIDPERSONA(ByVal IDPERSONA As Integer) As Integer
        Try
            Dim Cadena_Consulta As String = _
               "select isnull(IDCONTRATO,-1) from CONTRATO where IDPERSONA=" + IDPERSONA.ToString + " and ESTADOCONTRATO<>'T' and FECHAINICIOCONTRATO= (select MAX(FECHAINICIOCONTRATO) from CONTRATO where IDPERSONA=" + IDPERSONA.ToString + " and ESTADOCONTRATO<>'T')"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            CONSULTARULTIMOCONTRATOACTIVOXIDPERSONA = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception
            CONSULTARULTIMOCONTRATOACTIVOXIDPERSONA = -1
        End Try
    End Function

    Public Shared Function CONSULTARCODIGOPOBLACIONDIRECCION(ByVal IDPERSONA As Integer) As String
        Try
            Dim Cadena_Consulta As String = _
                "SELECT CODIGOLUGARDIRECCION FROM PERSONA WHERE IDPERSONA=" + IDPERSONA.ToString
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            CONSULTARCODIGOPOBLACIONDIRECCION = Consulta.ExecuteScalar()
            Consulta.Connection.Close()
        Catch ex As Exception
            CONSULTARCODIGOPOBLACIONDIRECCION = 0
        End Try
    End Function


    Public Shared Function CompararFechas(ByVal FECHAINICIAL As Date, ByVal FECHAFIN As Date) As Integer
        '1 FECHAINICIAL es MENOR a FECHA FINAL
        '0 FECHAINICIAL es IGUAL a FECHA FINAL
        '-1 FECHAINICIAL es MAYOR a FECHA FINAL
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


    Public Shared Function CARGARMAESTRAARTICULOS(ByVal ActualizarBD As Boolean) As DataTable
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim CargarBD As Boolean = False
            Dim NombreArchivo As String = VariablesBase.VariablesBase._path + "\" + "MaestraArticulos.xml"
            'VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.ReadXml(NombreArchivo)
            If IO.File.Exists(NombreArchivo) Then
                VariablesBase.VariablesBase.FechaArchivoXMLMaestroLocal = FechaModificacion(NombreArchivo)
                If VariablesBase.VariablesBase.FechaArchivoXMLMaestroLocal.AddDays(1) < Now Then
                    ActualizarBD = True
                End If
            Else
                CargarBD = True
            End If
            If CargarBD = False Then
                If IsNothing(VariablesBase.VariablesBase.TablaMAESTRAARTICULOS) = True Then
                    CargarBD = True
                Else
                    If VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Columns.Count = 0 Then
                        CargarBD = True
                    Else
                        If VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Rows.Count = 0 Then
                            CargarBD = True
                        End If
                    End If
                End If
            End If
            If CargarBD = True Then
                Dim Cadena_Consulta As String =
                "SELECT ID, DESCRIPCION, UND, FAMILIA, ESTADO, FOTOARTICULO, FECHAREGISTRO FROM " & _
                " dbo.ListarArticulos(0) AS ListarArticulos_1 " & _
                " ORDER BY ID"
                Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta.Connection = Conexión
                Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                Consulta.Connection.Open()
                VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Clear()
                Adaptador.FillSchema(VariablesBase.VariablesBase.TablaMAESTRAARTICULOS, SchemaType.Source)
                Adaptador.Fill(VariablesBase.VariablesBase.TablaMAESTRAARTICULOS)
                Consulta.Connection.Close()
                VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.WriteXml(NombreArchivo, XmlWriteMode.WriteSchema)
            Else
                If ActualizarBD = True Then
                    Dim TablaItemARTICULO As New DataTable
                    Dim Dt_TablaItemsMod As New DataTable

                    TablaItemARTICULO = VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Copy
                    While TablaItemARTICULO.Columns.Count > 1
                        TablaItemARTICULO.Columns.Remove(TablaItemARTICULO.Columns(1).ColumnName)
                    End While

                    Dim Comando As New SqlClient.SqlCommand("ListaActualizarArticulos")
                    Comando.CommandType = CommandType.StoredProcedure
                    Comando.Parameters.AddWithValue("@TIPO", 0)
                    If IO.File.Exists(NombreArchivo) Then
                        Comando.Parameters.AddWithValue("@FECHA", FechaModificacion(NombreArchivo))
                    Else
                        Comando.Parameters.AddWithValue("@FECHA", CDate("01/01/2013"))
                    End If

                    Comando.Parameters.AddWithValue("@TableIDArticulo", TablaItemARTICULO)
                    Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Comando.Connection = conn

                    Try
                        Dim Adaptador As New SqlClient.SqlDataAdapter(Comando)
                        Comando.Connection.Open()
                        Dt_TablaItemsMod = New DataTable
                        Adaptador.FillSchema(Dt_TablaItemsMod, SchemaType.Source)
                        Adaptador.Fill(Dt_TablaItemsMod)
                        Comando.Connection.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    conn.Close()

                    For k = 0 To Dt_TablaItemsMod.Rows.Count - 1
                        Dim FilaActualizar As DataRow
                        FilaActualizar = Dt_TablaItemsMod(k)
                        Dim filas() As DataRow
                        Dim fila As DataRow
                        Select Case FilaActualizar("MOVIMIENTO")
                            Case "I"
                                VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.ImportRow(FilaActualizar)
                            Case "U"
                                filas = VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Select("ID=" + FilaActualizar("ID").ToString)
                                fila = filas(0)
                                For l = 1 To VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Columns.Count - 1
                                    VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Columns(l).ReadOnly = False
                                    fila(VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Columns(l).ColumnName) = FilaActualizar(VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Columns(l).ColumnName)
                                Next
                            Case "D"
                                filas = VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Select("ID=" + FilaActualizar("ID").ToString)
                                fila = filas(0)
                                VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Rows.Remove(fila)

                        End Select
                    Next

                    VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.WriteXml(NombreArchivo, XmlWriteMode.WriteSchema)
                Else

                    'Carga local
                    If VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.Rows.Count = 0 Then
                        VariablesBase.VariablesBase.TablaMAESTRAARTICULOS.ReadXml(NombreArchivo)
                    End If

                End If
            End If

            CARGARMAESTRAARTICULOS = VariablesBase.VariablesBase.TablaMAESTRAARTICULOS
        Catch ex As Exception
            MsgBox(ex.ToString)
            CARGARMAESTRAARTICULOS = Nothing
        End Try
        Cursor.Current = Cursors.Default
    End Function


    Public Shared Function FechaModificacion(ByVal strRuta As String) As Date
        Dim fso, Archivo As Object
        fso = CreateObject("Scripting.FileSystemObject")
        Archivo = fso.GetFile(strRuta)
        FechaModificacion = Archivo.DateLastModified
        Archivo = Nothing
        fso = Nothing
    End Function ' FechaModificacion


    Function Buscar(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView) As Boolean
        Dim encontrado As Boolean = False
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
        grid.ClearSelection()
        If Columna = String.Empty Then
            For Each row As DataGridViewRow In grid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value.ToString() = TextoABuscar Then
                        row.Selected = True
                        Return True
                    End If
                Next
            Next
        Else
            For Each row As DataGridViewRow In grid.Rows
                If row.IsNewRow Then Return False
                If row.Cells(Columna).Value.ToString() = TextoABuscar Then
                    row.Selected = True
                    Return True
                End If

            Next
        End If
        Return encontrado
    End Function


    Public Shared Function Meses(ByVal x As Integer) As String
        Dim s As String = ""
        Select Case x
            Case 1 : s = "Ene"
            Case 2 : s = "Feb"
            Case 3 : s = "Mar"
            Case 4 : s = "Abr"
            Case 5 : s = "May"
            Case 6 : s = "Jun"
            Case 7 : s = "Jul"
            Case 8 : s = "Ago"
            Case 9 : s = "Sep"
            Case 10 : s = "Oct"
            Case 11 : s = "Nov"
            Case 12 : s = "Dic"
        End Select
        Meses = s
    End Function


    Public Shared Function MesesCompleto(ByVal x As Integer) As String
        Dim s As String = ""
        Select Case x
            Case 1 : s = "Enero"
            Case 2 : s = "Febrero"
            Case 3 : s = "Marzo"
            Case 4 : s = "Abril"
            Case 5 : s = "Mayo"
            Case 6 : s = "Junio"
            Case 7 : s = "Julio"
            Case 8 : s = "Agosto"
            Case 9 : s = "Septiembre"
            Case 10 : s = "Octubre"
            Case 11 : s = "Noviembre"
            Case 12 : s = "Diciembre"
        End Select
        MesesCompleto = s
    End Function


    Public Shared Function ConsultarPermiso(ByVal CODIGOFUNCIONMODULO As String) As Boolean
        Dim filas() As DataRow

        If Trim(CODIGOFUNCIONMODULO) = "" Then
            CODIGOFUNCIONMODULO = "-1"
        End If
        filas = VariablesBase.VariablesBase.PERMISOS.Select("CODIGO=" + CODIGOFUNCIONMODULO)
        If filas.Length > 0 Then
            Dim fila As DataRow = filas(0)
            If fila("TIENEPERMISO") = 1 Then
                ConsultarPermiso = True
            Else
                ConsultarPermiso = False
            End If
        Else
            'validar que no este en la lista de funciones
            ConsultarPermiso = True
        End If
    End Function


    Public Shared Function CancelarRegistro(ByVal TIPO As String, ByVal ID As Int64,
                                       ByVal IDITEM As Int32, Optional ByVal TIPOCANCELACION As String = "",
                                     Optional ByVal CANTIDAD As Double = 0) As Integer
        Dim observación As String
        observación = InputBox("Digite la observación por la cual realiza la cancelación", "OBSERVACIÓN", "")
        If Trim(observación) = "" Then
            MsgBox("Debe colocar la observación por la cual realiza la cancelación", MsgBoxStyle.Critical, "OBSERVACIÓN")
            CancelarRegistro = -1
            Exit Function
        End If

        observación = Mid(observación, 1, 100)

        'Llamar al procedimiento para crear el tipo categoría
        Dim procedimiento As String = ""
        Select Case TIPO
            Case "OC"
                procedimiento = "dbo.CancelarOrdenCompra"
            Case "IOC"
                procedimiento = "dbo.CancelarItemOrdenCompra"
            Case "RQ"
                procedimiento = "dbo.CancelarRequisición"
            Case "IRQ"
                procedimiento = "dbo.CancelarItemRequisición"
            Case "EA"
                procedimiento = "dbo.CancelarEntradaAlmacén"
            Case "IEA"
                procedimiento = "dbo.CancelarItemEntradaAlmacén"
            Case "SA"
                procedimiento = "dbo.CancelarSalidaAlmacén"
            Case "ISA"
                procedimiento = "dbo.CancelarItemSalidaAlmacén"
            Case "DP"
                procedimiento = "dbo.CancelarItemEntradaAlmacén"
            Case "DPT"
                procedimiento = "dbo.CancelarEntradaAlmacén"
        End Select
        Dim Comando As New SqlClient.SqlCommand(procedimiento)
        Comando.CommandType = CommandType.StoredProcedure
        Select Case TIPO
            Case "OC"
                Comando.Parameters.AddWithValue("@IDORDENCOMPRA", ID)
            Case "IOC"
                Comando.Parameters.AddWithValue("@IDORDENCOMPRA", ID)
                Comando.Parameters.AddWithValue("@IDITEMORDENCOMPRA", IDITEM)
                Comando.Parameters.AddWithValue("@TIPOCANCELACION", TIPOCANCELACION)
                Comando.Parameters.AddWithValue("@CANTIDADCANCELADA", CANTIDAD)
            Case "RQ"
                Comando.Parameters.AddWithValue("@IDREQUISICION", ID)
            Case "IRQ"
                Comando.Parameters.AddWithValue("@IDREQUISICION", ID)
                Comando.Parameters.AddWithValue("@IDITEMREQUISICION", IDITEM)
                Comando.Parameters.AddWithValue("@TIPOCANCELACION", TIPOCANCELACION)
                Comando.Parameters.AddWithValue("@CANTIDADCANCELADA", CANTIDAD)
            Case "EA"
                Comando.Parameters.AddWithValue("@IDENTRADAALMACEN", ID)
            Case "IEA"
                Comando.Parameters.AddWithValue("@IDENTRADAALMACEN", ID)
                Comando.Parameters.AddWithValue("@IDITEMENTRADAALMACEN", IDITEM)
            Case "SA"
                Comando.Parameters.AddWithValue("@IDSALIDAALMACEN", ID)
            Case "ISA"
                Comando.Parameters.AddWithValue("@IDSALIDAALMACEN", ID)
                Comando.Parameters.AddWithValue("@IDITEMSALIDAALMACEN", IDITEM)
            Case "DP"
                Comando.Parameters.AddWithValue("@IDENTRADAALMACEN", ID)
                Comando.Parameters.AddWithValue("@IDITEMENTRADAALMACEN", IDITEM)
            Case "DPT"
                Comando.Parameters.AddWithValue("@IDENTRADAALMACEN", ID)
        End Select
        Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)

        If TIPO = "DP" Or TIPO = "DPT" Then
            Comando.Parameters.AddWithValue("@OBSERVACION", "(DP) " + observación)
        Else
            Comando.Parameters.AddWithValue("@OBSERVACION", observación)
        End If

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim msgParam1 As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 100)
        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam1)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()
        If Comando.Parameters("@IDMENSAJE").Value <> 0 Then
            MsgBox(Comando.Parameters("@MENSAJE").Value, MsgBoxStyle.Critical, "NO SE COMPLETO LA CANCELACION")
        Else
            MsgBox(Comando.Parameters("@MENSAJE").Value, MsgBoxStyle.Information)
        End If

        CancelarRegistro = Comando.Parameters("@IDMENSAJE").Value
    End Function


    Public Shared Function ValoresxDefecto(ByVal Tipo As String, ByVal DOCUMENTO As String, _
                                            ByVal FUNCION As String, ByVal IDPERSONA As Integer) As Integer
        'Tipo, si es guardando o consultando  G o C
        'DOCUMENTO, cual documento es RQ,OC,SA,EA
        'FUNCION en el documento, Autoriza, Aprueba, Gerencia..
        'IDPERSONA, valor a guardar
        Try
            Dim NombreArchivo As String = VariablesBase.VariablesBase._path + "\" + "ValoresDefecto.xml"
            Dim Tabla As New DataTable
            If Tipo = "G" Then
                If IO.File.Exists(NombreArchivo) Then
                    Tabla.ReadXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefecto.xml")
                    Dim Filas() As DataRow
                    Dim Fila As DataRow
                    Filas = Tabla.Select("DOCUMENTO='" + DOCUMENTO + "' AND FUNCION='" + FUNCION + "' AND IDBODEGA=" + VariablesBase.VariablesBase.IdBodegaActual.ToString)
                    If Filas.Length > 0 Then
                        'existe se modifica
                        Fila = Filas(0)
                        Fila("DOCUMENTO") = DOCUMENTO
                        Fila("FUNCION") = FUNCION
                        Fila("IDPERSONA") = IDPERSONA
                        Fila("IDBODEGA") = VariablesBase.VariablesBase.IdBodegaActual
                        Tabla.WriteXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefecto.xml", XmlWriteMode.WriteSchema)
                    Else
                        'no existe se crea
                        Fila = Tabla.NewRow
                        Fila("DOCUMENTO") = DOCUMENTO
                        Fila("FUNCION") = FUNCION
                        Fila("IDPERSONA") = IDPERSONA
                        Fila("IDBODEGA") = VariablesBase.VariablesBase.IdBodegaActual
                        Tabla.Rows.Add(Fila)
                        Tabla.WriteXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefecto.xml", XmlWriteMode.WriteSchema)
                    End If
                Else
                    'crear el archivo
                    Tabla.TableName = "VALORESXDEFECTO"
                    Tabla.Columns.Add("DOCUMENTO")
                    Tabla.Columns.Add("FUNCION")
                    Tabla.Columns.Add("IDPERSONA")
                    Tabla.Columns.Add("IDBODEGA")
                    Dim Fila As DataRow
                    Fila = Tabla.NewRow
                    Fila("DOCUMENTO") = DOCUMENTO
                    Fila("FUNCION") = FUNCION
                    Fila("IDPERSONA") = IDPERSONA
                    Fila("IDBODEGA") = VariablesBase.VariablesBase.IdBodegaActual
                    Tabla.Rows.Add(Fila)
                    Tabla.WriteXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefecto.xml", XmlWriteMode.WriteSchema)
                End If
                ValoresxDefecto = -1
            Else
                'consultar
                If IO.File.Exists(NombreArchivo) Then
                    Tabla.ReadXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefecto.xml")
                    Dim Filas() As DataRow
                    Dim Fila As DataRow
                    Filas = Tabla.Select("DOCUMENTO='" + DOCUMENTO + "' AND FUNCION='" + FUNCION + "' AND IDBODEGA=" + VariablesBase.VariablesBase.IdBodegaActual.ToString)
                    If Filas.Length > 0 Then
                        'existe se modifica
                        Fila = Filas(0)
                        ValoresxDefecto = Fila("IDPERSONA")
                    Else
                        ValoresxDefecto = -1
                    End If
                Else
                    ValoresxDefecto = -1
                End If
            End If
        Catch ex As Exception
            ValoresxDefecto = -1
        End Try
    End Function


    Public Shared Function ValoresxDefectoSisControl(ByVal Tipo As String, ByVal DOCUMENTO As String, _
                                           ByVal FUNCION As String, ByVal IDPERSONA As String) As String
        'Tipo, si es guardando o consultando  G o C
        'DOCUMENTO, cual documento es RQ,OC,SA,EA
        'FUNCION en el documento, Autoriza, Aprueba, Gerencia..
        'IDPERSONA, valor a guardar
        Try
            Dim NombreArchivo As String = VariablesBase.VariablesBase._path + "\" + "ValoresDefectoSisControl.xml"
            Dim Tabla As New DataTable
            If Tipo = "G" Then
                If IO.File.Exists(NombreArchivo) Then
                    Tabla.ReadXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefectoSisControl.xml")
                    Dim Filas() As DataRow
                    Dim Fila As DataRow
                    Filas = Tabla.Select("DOCUMENTO='" + DOCUMENTO + "' AND FUNCION='" + FUNCION + "' AND IDDEPENDENCIA=" + VariablesBase.VariablesBase.IddependenciaSiscontrolActual.ToString)
                    If Filas.Length > 0 Then
                        'existe se modifica
                        Fila = Filas(0)
                        Fila("DOCUMENTO") = DOCUMENTO
                        Fila("FUNCION") = FUNCION
                        Fila("IDPERSONA") = IDPERSONA
                        Fila("IDDEPENDENCIA") = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
                        Tabla.WriteXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefectoSisControl.xml", XmlWriteMode.WriteSchema)
                    Else
                        'no existe se crea
                        Fila = Tabla.NewRow
                        Fila("DOCUMENTO") = DOCUMENTO
                        Fila("FUNCION") = FUNCION
                        Fila("IDPERSONA") = IDPERSONA
                        Fila("IDDEPENDENCIA") = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
                        Tabla.Rows.Add(Fila)
                        Tabla.WriteXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefectoSisControl.xml", XmlWriteMode.WriteSchema)
                    End If
                Else
                    'crear el archivo
                    Tabla.TableName = "VALORESXDEFECTO"
                    Tabla.Columns.Add("DOCUMENTO")
                    Tabla.Columns.Add("FUNCION")
                    Tabla.Columns.Add("IDPERSONA")
                    Tabla.Columns.Add("IDDEPENDENCIA")
                    Dim Fila As DataRow
                    Fila = Tabla.NewRow
                    Fila("DOCUMENTO") = DOCUMENTO
                    Fila("FUNCION") = FUNCION
                    Fila("IDPERSONA") = IDPERSONA
                    Fila("IDDEPENDENCIA") = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
                    Tabla.Rows.Add(Fila)
                    Tabla.WriteXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefectoSisControl.xml", XmlWriteMode.WriteSchema)
                End If
                ValoresxDefectoSisControl = -1
            Else
                'consultar
                If IO.File.Exists(NombreArchivo) Then
                    Tabla.ReadXml(VariablesBase.VariablesBase._path + "\" + "ValoresDefectoSisControl.xml")
                    Dim Filas() As DataRow
                    Dim Fila As DataRow
                    Filas = Tabla.Select("DOCUMENTO='" + DOCUMENTO + "' AND FUNCION='" + FUNCION + "' AND IDDEPENDENCIA=" + VariablesBase.VariablesBase.IddependenciaSiscontrolActual.ToString)
                    If Filas.Length > 0 Then
                        'existe se modifica
                        Fila = Filas(0)
                        ValoresxDefectoSisControl = Fila("IDPERSONA")
                    Else
                        ValoresxDefectoSisControl = -1
                    End If
                Else
                    ValoresxDefectoSisControl = -1
                End If

            End If
        Catch ex As Exception
            ValoresxDefectoSisControl = -1
        End Try
    End Function


#Region "Exportar datos"

    Public Shared Function ExportarDataGridViewADataTable(ByVal miDataGrid As DataGridView) As DataTable
        Try
            Dim filaNueva As System.Data.DataRow
            Dim numCols As Integer
            Dim Tabla As New DataTable
            For j = 0 To miDataGrid.ColumnCount - 1
                Dim columna As New DataColumn(miDataGrid.Columns(j).DataPropertyName, miDataGrid.Columns(j).ValueType)
                Tabla.Columns.Add(columna)
            Next
            numCols = miDataGrid.ColumnCount
            ' Rellenamos los valores del DataTable nuevo con los valores de las celdas del DataGridView
            For Each filaDatos As DataGridViewRow In miDataGrid.SelectedRows
                filaNueva = Tabla.NewRow()
                For i As Integer = 0 To numCols - 1
                    filaNueva(i) = filaDatos.Cells(i).Value
                Next
                Tabla.Rows.Add(filaNueva)
            Next
            ExportarDataGridViewADataTable = Tabla
        Catch ex As Exception
            ExportarDataGridViewADataTable = New DataTable
        End Try
    End Function


    Public Shared Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = Date.Now.ToLongDateString
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = titulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el borde exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub


    Public Shared Function GridAExcel(ByVal ElGrid As DataGridView, ByVal NombreArchivo As String) As Boolean
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount

            'Aquí recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Return False
        End Try

        Return True
    End Function


    Public Shared Function ExportarExcel(ByVal Tabla As DataTable, ByVal NombreArchivo As String) As Boolean
        Try
            'objPlsWait.ShowWaitScreen()
            Dim excelApplication As PIA.Application = New PIA.Application
            Dim excelWorkbook As PIA.Workbook = CType(excelApplication.Workbooks.Add(System.Reflection.Missing.Value), PIA.Workbook)
            Dim excelSheet As PIA.Worksheet = CType(excelWorkbook.Sheets(1), PIA.Worksheet)
            'add the columns
            For i As Integer = 0 To Tabla.Columns.Count - 1
                CType(excelSheet.Cells(1, i + 1), PIA.Range).Value2 = Tabla.Columns(i).ColumnName
            Next i
            'set the column styles
            excelSheet.Range(excelSheet.Cells(1, 1), excelSheet.Cells(1, Tabla.Columns.Count)).Font.Bold = True
            excelSheet.Range(excelSheet.Cells(1, 1), excelSheet.Cells(1, Tabla.Columns.Count)).HorizontalAlignment = PIA.XlHAlign.xlHAlignCenter

            For i As Integer = 0 To Tabla.Rows.Count - 1
                excelSheet.Cells.Range(excelSheet.Cells(i + 2, 1), excelSheet.Cells(i + 2, Tabla.Columns.Count)).Value2 = Tabla.Rows(i).ItemArray
            Next i
            Dim tmp As String
            tmp = excelSheet.Cells.Range(excelSheet.Cells(2, 1), excelSheet.Cells(2, 1)).Value2.ToString()

            'save the file
            'objPlsWait.CloseWaitScreen()
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.FileName = NombreArchivo
            saveFileDialog1.Filter = "Excel xls|*.xls"
            saveFileDialog1.Title = "Salvar en"
            If saveFileDialog1.ShowDialog() = DialogResult.Cancel Then
                ExportarExcel = False
                Exit Function
            End If
            ' If the file name is not an empty string open it for saving.
            If saveFileDialog1.FileName <> "" Then
                excelWorkbook.Close(True, saveFileDialog1.FileName, Nothing)

                'Dispose of the resource
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication)
                excelWorkbook = Nothing
                excelApplication = Nothing
                'Open the created file
                Dim p As Process = New Process
                p.StartInfo.FileName = saveFileDialog1.FileName
                p.Start()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Error en la exportación")
            ExportarExcel = False
            Exit Function
        End Try
        ExportarExcel = True
    End Function


#End Region 'Exportar datos

    Public Shared Function DatosRequisicionHTML(ByVal id As Integer, ByVal tipo As String) As String
        Try
            Dim bddatos As New DatosClasesBase.DatosCompras()
            Dim ds As New DataSet
            Dim tabladatos, tablaitems, tablacomentarios As New DataTable
            Dim check1, check2, check3, check4, check5, spanred, spanfin, spangreen, telefono As String
            Dim mensaje As String = ""
            'CONSTRUYO LA TABLA DE ITEMS
            Dim filas, columnas As Integer
            spanred = "<span style=""color:red"">"
            spangreen = "<span style=""color:green"">"
            spanfin = "</span>"

            If tipo = "OC" Then
                'extraer datos de la requisición para meterlos en la tabla            
                ds = bddatos.GestionarRequisiciones(36, 0, 0, id)
                tabladatos = ds.Tables(0)

                'INFORMACION DE LA REQUISICIÓN:
                mensaje = "Orden de Compra con ID:<strong>" + tabladatos.Rows(0)("Orden de Compra").ToString + "</strong>. Tipo <strong>" + tabladatos.Rows(0)("Tipo").ToString + "</strong><hr />"
                mensaje += "<table  style=""width:auto;"" border='1' cellpadding='7' cellspacing='0'><tbody><tr><td>Fecha de Orden:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Fecha OC").ToString + "</strong></td></tr>"
                mensaje += "<tr><td>Requisición:</td><td colspan=""3""><strong>" + "NIT." + tabladatos.Rows(0)("Nit").ToString + " - " + tabladatos.Rows(0)("proveedor").ToString.Trim + "</strong></td></tr>"
                If tabladatos.Rows(0)("Teléfono").ToString.Trim = "" Then
                    telefono = ""
                Else
                    telefono = " / " + tabladatos.Rows(0)("Teléfono").ToString
                End If
                mensaje += "<tr><td>Contacto:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Contacto").ToString.Trim + telefono + "</strong></td></tr>"
                mensaje += "<tr><td>Centro de Costo:</td><td><strong>" + tabladatos.Rows(0)("Centro Costo").ToString.Trim + "</strong></td></tr>"
                mensaje += "<tr><td>Comprador:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Comprador").ToString.Trim + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("aprobada")) Then
                    check1 = spanred + " No Aprobada" + spanfin
                Else
                    check1 = spangreen + " Aprobada" + spanfin
                End If
                mensaje += "<tr><td>Usuario Aprueba:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Aprueba").ToString.Trim + check1 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("Autorizada")) Then
                    check2 = spanred + " No Autorizada" + spanfin
                Else
                    check2 = spangreen + " Autorizada" + spanfin
                End If
                mensaje += "<tr><td>Usuario Autoriza:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Autoriza").ToString.Trim + check2 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("revisada")) Then
                    check3 = spanred + " No Revisada" + spanfin
                Else
                    check3 = spangreen + " Revisada" + spanfin
                End If
                mensaje += "<tr><td>Usuario Revisa:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Revisa").ToString.Trim + check3 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("Aprobadagerencia")) Then
                    check4 = spanred + " No Aprobada de gerencia" + spanfin
                Else
                    check4 = spangreen + " Aprobada de gerencia" + spanfin
                End If
                mensaje += "<tr><td>Usuario Gerencia:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("apruebaGerencia").ToString.Trim + check4 + "</strong></td></tr>"
                mensaje += "<tr><td>Cancelada:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Cancelada").ToString.Trim + "</strong></td></tr></tbody></table>"
                ds = bddatos.GestionarRequisiciones(23, 0, 0, id)

            ElseIf tipo = "RQ" Then
                spanred = "<span style=""color:red"">"
                spangreen = "<span style=""color:green"">"
                spanfin = "</span>"
                ds = bddatos.GestionarRequisiciones(32, 0, id, 0)
                tabladatos = ds.Tables(0)
                mensaje = "Requisición con ID:<strong>" + tabladatos.Rows(0)("Requisición").ToString + "</strong>. Tipo <strong>" + tabladatos.Rows(0)("TipoRQ").ToString + "</strong><hr />"
                mensaje += "<table  style=""width:auto;"" border='1' cellpadding='7' cellspacing='0'><tbody><tr><td>Centro Costo:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Centro Costo").ToString + "</strong></td></tr>"
                mensaje += "<tr><td>Fecha de Registro:</td><td colspan=""3""><strong>" + Date.Parse(tabladatos.Rows(0)("Fecha registro").ToString).ToShortDateString + "</strong></td></tr>"
                mensaje += "<tr><td>Fecha de Solicitud:</td><td colspan=""3""><strong>" + Date.Parse(tabladatos.Rows(0)("Fecha Solicitud").ToString).ToShortDateString + "</strong></td></tr>"
                If DBNull.Value.Equals(tabladatos.Rows(0)("Fechaasignacion")) Then
                    mensaje += "<tr><td>Fecha Asignación Comprador:</td><td colspan=""3""><strong>No Registra</strong></td></tr>"
                Else
                    mensaje += "<tr><td>Fecha Asignación Comprador:</td><td colspan=""3""><strong>" + Date.Parse(tabladatos.Rows(0)("Fechaasignacion").ToString).ToShortDateString + "</strong></td></tr>"
                End If

                mensaje += "<tr><td>Bodega de Origen:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Origen").ToString + "</strong></td></tr>"
                mensaje += "<tr><td>Justificación:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Justificación").ToString + "</strong></td></tr>"
                mensaje += "<tr><td>Usuario que registró:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Registro").ToString + "</strong></td></tr>"
                mensaje += "<tr><td>Usuario Solicita:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Solicita").ToString + "</strong></td></tr>"
                If DBNull.Value.Equals(tabladatos.Rows(0)("aut")) Then
                    check1 = spanred + " No Autorizada" + spanfin
                Else
                    check1 = spangreen + " Autorizada" + spanfin
                End If
                mensaje += "<tr><td>Usuario Autoriza:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Autoriza").ToString + check1 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("rev")) Then
                    check3 = spanred + " No Revisada" + spanfin
                Else
                    check3 = spangreen + " Revisada" + spanfin
                End If
                mensaje += "<tr><td>Usuario Revisa:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Revisa").ToString + check3 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("apr")) Then
                    check2 = spanred + " No Aprobada" + spanfin
                Else
                    check2 = spangreen + " Aprobada" + spanfin
                End If
                mensaje += "<tr><td>Usuario Aprueba:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Aprueba").ToString + check2 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("vb")) Then
                    check4 = spanred + " Sin visto bueno" + spanfin
                Else
                    If tabladatos.Rows(0)("vb").ToString = "N" Then
                        check4 = spanred + " Sin visto bueno" + spanfin
                    Else
                        check4 = spangreen + " Con visto bueno" + spanfin
                    End If
                End If
                mensaje += "<tr><td>Usuario Visto Bueno:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Visto Bueno").ToString + check4 + "</strong></td></tr>"

                If DBNull.Value.Equals(tabladatos.Rows(0)("vbsub")) Then
                    check5 = spanred + " Sin visto bueno" + spanfin
                Else
                    If tabladatos.Rows(0)("vbsub").ToString = "N" Then
                        check5 = spanred + " Sin visto bueno" + spanfin
                    Else
                        check5 = spangreen + " Con visto bueno" + spanfin
                    End If
                End If
                mensaje += "<tr><td>Usuario Visto Bueno Subgerencia:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Visto Bueno Subgerencia").ToString + check5 + "</strong></td></tr>"
                mensaje += "<tr><td>Usuario Compra:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("Compra").ToString + "</strong></td></tr>"
                mensaje += "<tr><td>Usuario Asignó Comprador:</td><td colspan=""3""><strong>" + tabladatos.Rows(0)("personaasignocomprador").ToString + "</strong></td></tr></tbody></table>"
                ds = bddatos.GestionarRequisiciones(8, 0, id, 0)
            End If

            tablaitems = ds.Tables(0)
            columnas = tablaitems.Columns.Count
            filas = tablaitems.Rows.Count
            mensaje += "<br/><h3>Elementos</h3>"
            mensaje += "<table  style=""width:auto;"" border='1' cellpadding='7' cellspacing='0'><tbody>"
            mensaje += "<thead><tr>"

            For col As Integer = 0 To (columnas - 1)
                mensaje += "<th>" + tablaitems.Columns(col).ColumnName + "</th>"
            Next
            mensaje += "</tr></thead>"

            For fil As Integer = 0 To (filas - 1)
                mensaje += "<tr>"
                For col As Integer = 0 To (columnas - 1)
                    mensaje += "<td>" + tablaitems.Rows(fil).Item(col).ToString + "</td>"
                Next
                mensaje += "</tr>"
            Next
            mensaje += "</tbody></table>"
            'armar BODY
            Dim cuerpo As String = "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN""><HTML><HEAD><TITLE>REQUISICIÓN</TITLE></HEAD><BODY><!--StartFragment-->"
            cuerpo += "<center>"
            cuerpo += mensaje
            cuerpo += "</center>"
            cuerpo += "</body>"
            cuerpo += "</html>"

            DatosRequisicionHTML = cuerpo
        Catch ex As Exception
            MsgBox("Error en la generación de BODY")
            DatosRequisicionHTML = ""
        End Try
    End Function

    Public Shared Function DatosRequisicionHTMLCotizar(ByVal id As Integer, ByVal tipo As String) As String
        Try
            Dim bddatos As New DatosClasesBase.DatosCompras()
            Dim ds As New DataSet
            Dim tabladatos, tablaitems, tablacomentarios As New DataTable
            Dim spanred, spanfin, spangreen As String
            Dim mensaje As String = ""
            'CONSTRUYO LA TABLA DE ITEMS
            Dim filas, columnas As Integer
            spanred = "<span style=""color:red"">"
            spangreen = "<span style=""color:green"">"
            spanfin = "</span>"

          
            spanred = "<span style=""color:red"">"
            spangreen = "<span style=""color:green"">"
            spanfin = "</span>"
            ds = bddatos.GestionarRequisiciones(32, 0, id, 0)
            tabladatos = ds.Tables(0)
            mensaje = "Este material deberá ser entregado directamente en: <strong style=""color:red""> (" + tabladatos.Rows(0)("Destino").ToString + ")</strong>"
            mensaje += "<br/><br/>"
            mensaje += "<h3 style=""color:red""> COTIZAR URGENTE.</h3>"
            mensaje += "Estimado Proveedor."
            mensaje += "<br/><br/>"
            mensaje += "<U> Revisar para cotizar solo los ítems dentro su línea comercial,<b style=""color:red""> ''Validez: Oferta mínimo de (45) días''. </b></U>"
            mensaje += "<br/><br/>"
            mensaje += "Por favor, enviarnos su mejor Oferta Técnica & Comercial para el material y/o equipos asociados a la requisición: <strong style=""color:red"">" + tabladatos.Rows(0)("Requisición").ToString + "</strong>" + " relacionado a continuación:"
            Dim justificación As String = tabladatos.Rows(0)("Justificación").ToString
            'cargar los item
            ds = bddatos.GestionarRequisiciones(39, 0, id, 0)

            tablaitems = ds.Tables(0)
            columnas = tablaitems.Columns.Count
            filas = tablaitems.Rows.Count
            mensaje += "<br/><br/>"
            mensaje += "<table  style=""width:auto;"" border='1' cellpadding='7' cellspacing='0'><tbody>"
            mensaje += "<thead><tr>"

            For col As Integer = 0 To (columnas - 1)
                mensaje += "<th>" + tablaitems.Columns(col).ColumnName + "</th>"
            Next
            mensaje += "</tr></thead>"

            For fil As Integer = 0 To (filas - 1)
                mensaje += "<tr>"
                For col As Integer = 0 To (columnas - 1)
                    mensaje += "<td>" + tablaitems.Rows(fil).Item(col).ToString + "</td>"
                Next
                mensaje += "</tr>"
            Next
            mensaje += "</tbody></table>"

            mensaje += "<br/><br/>"

            mensaje += "<Strong style=""color:red"">Agradezco me notifique si tiene o no interés de participar en la propuesta comercial.</strong>"

            mensaje += "<br/><br/>"
            mensaje += "En su oferta se debe tener en cuenta:"
            mensaje += "<br/><br/>"
            mensaje += "1. Fecha y lugar de expedición."
            mensaje += "<br/>2. Nombre y NIT de empresa oferente."
            mensaje += "<br/>3. Nombre y NIT de ISMCOL S.A. con NIT 890.209.174-1."
            mensaje += "<br/>4. Nombre Proyecto: Según asunto."
            mensaje += "<br/>5. Condiciones comerciales: Validez: Oferta mínimo de (45) días, Condiciones de pago (estándar ISMOCOL crédito 45 días fecha radicación factura), tiempo de entrega, lugar de entrega y demás términos Comerciales que el proveedor desee aclarar y/o especificar."
            mensaje += "<br/>6. Firma de la empresa y datos de asesor comercial."
            mensaje += "<br/>7. Condiciones de materiales: Deberán ser nuevos, de la mejor calidad y deben estar libres de defectos. *Ficha técnica y/o catálogo del material ofrecido"
            mensaje += "<br/>8. Dossier: El proveedor debe entregar, un cuadernillo técnico ( Dossier) que incluya los certificados  solicitados. (Certifica de Calidad, Prueba de fabricación, Certificado de origen, Certificados de calibración, conformidad etc.) Según tipo de material o equipo."
            mensaje += "<br/>9. De ser el adjudicado con la Orden de Compra: deberá emitir PÓLIZAS de <u>Buen manejo del anticipo  (siempre que se solicite) Cumplimiento y Calidad  según corresponda)</u>"
            mensaje += "<br/>10. Desde el momento de envió de su cotización, asumimos la seriedad y cumplimento  que su propuesta tiene conforme al material requerido de acuerdo a las especificaciones técnicas solicitadas."
            mensaje += "<br/><br/>"
            mensaje += "Plazo para recibo de ofertas para evaluación: <Strong style=""color:red"">INMEDIATA</Strong>"
            mensaje += "<br/><br/>"
            mensaje += "<br/>** REVISAR Y CONFIRMAR SU INTENCIÓN O NO DE PARTICIPAR DE ESTA OFERTA. "
            mensaje += "<br/>***CUALQUIER ACLARACIÓN TAMBIÉN SOLICITARLA SOBRE EL PRESENTE CORREO "
            mensaje += "<br/>****La adjudicación de la orden de compra puede ser total o parcial según el criterio con el que sean escogidos."






            'armar BODY
            Dim cuerpo As String = "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN""><HTML><HEAD><TITLE>REQUISICIÓN</TITLE></HEAD><BODY><!--StartFragment-->"

            cuerpo += mensaje

            cuerpo += "</body>"
            cuerpo += "</html>"

            DatosRequisicionHTMLCotizar = cuerpo
        Catch ex As Exception
            MsgBox("Error en la generación de BODY")
            DatosRequisicionHTMLCotizar = ""
        End Try
    End Function

    ''' <summary>
    ''' Recupera el valor entero de una cadena de texto con formato de moneda.
    ''' </summary>
    ''' <param name="Cadena">Cadena de texto con formato de moneda.</param>
    ''' <returns>Valor entero que representa la cadena de texto.</returns>
    Public Shared Function ValorRealInt(ByVal Cadena As String) As Integer
        Cadena = Replace(Cadena, "$", "")
        Cadena = Replace(Cadena, " ", "")
        Cadena = Replace(Cadena, ".", "")
        Dim pos As Integer = Cadena.LastIndexOf(",")
        If pos = Cadena.Length - 3 Then
            'tiene ",00"
            Try
                Cadena = Mid(Cadena, 1, Cadena.Length - 3)
            Catch

            End Try
        Else
            If pos = Cadena.Length - 2 Then
                'tiene ",0"
                Try
                    Cadena = Mid(Cadena, 1, Cadena.Length - 2)
                Catch

                End Try
            End If
        End If
        Cadena = Replace(Cadena, ",", "")
        If IsNumeric(Cadena) = True Then
            ValorRealInt = CInt(Cadena)
        Else
            ValorRealInt = -1
        End If
    End Function


    ''' <summary>
    ''' Recupera el valor decimal de una cadena de texto con formato de moneda.
    ''' </summary>
    ''' <param name="Cadena">Cadena de texto con formato de moneda.</param>
    ''' <returns>Valor decimal que representa la cadena de texto.</returns>
    Public Shared Function ValorRealDec(ByVal Cadena As String) As Decimal
        Cadena = Regex.Replace(Cadena, "[^0-9.,]", "")
        Dim posicionDecimal As Integer = Cadena.IndexOf(Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
        If posicionDecimal >= 0 Then
            Cadena = Regex.Replace(Cadena.Substring(0, posicionDecimal), "[.,]", "") + Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) + Regex.Replace(Cadena.Substring(posicionDecimal + 1), "[.,]", "")
        End If
        Dim CadenaDecimal As Decimal
        If Decimal.TryParse(Cadena, NumberStyles.Currency, CultureInfo.CurrentCulture, CadenaDecimal) = False Then
            ValorRealDec = -1
        Else
            ValorRealDec = CadenaDecimal
        End If
    End Function


    ' Evento que controla el ingreso de caracteres numéricos en cajas de texto que toman valores de tipo moneda.
    Public Shared Sub TextBoxMoneda_KeyPress(Caja As TextBox, e As KeyPressEventArgs)
        If InStr(1, "0123456789" & Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) & Convert.ToChar(Keys.Back), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
        If e.KeyChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) And Caja.SelectionStart > 0 Then
            If Caja.Text.Substring(Caja.SelectionStart - 1, 1) = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) Then
                e.Handled = True
                e.KeyChar = CChar("")
            End If
        End If
    End Sub


    ' Evento que aplica formato de moneda a la cadena en cajas de texto.
    Public Shared Sub TextBoxMoneda_Lostfocus(Caja As TextBox, e As System.EventArgs)
        Try
            Dim valorDecimal As Decimal = ValorRealDec(Caja.Text)

            If valorDecimal < 0 Then
                Caja.BackColor = Drawing.Color.Red
            Else
                Caja.Text = Format(valorDecimal, "C")
                Caja.BackColor = Drawing.Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub


    ' Evento que controla el ingreso de caracteres numéricos en cajas de texto que toman valores enteros.
    Public Shared Sub TextBoxNumericoEntero_KeyPress(Caja As TextBox, e As KeyPressEventArgs)
        If InStr(1, "0123456789" & Convert.ToChar(Keys.Back), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub


    ' Evita que se muestren dos listados (filtrado y sin filtrar) en los ComboBox con la propiedad AutoComplete SuggestAppend al empezar a digitar con el listado sin filtrar desplegado.
    Public Shared Sub ComboBoxAutocompletar_KeyDown(sender As Object, e As KeyEventArgs)
        Dim cb As ComboBox = sender
        If cb.DroppedDown Then
            cb.DroppedDown = False
        End If
    End Sub

    ''' <summary>Calcula las fechas de fecha de terminación inicial y fecha final del contrato.</summary>
    ''' <param name="FECHAINICIAL">Fecha de inicio del contrato.</param>
    ''' <param name="TIPODURACION">Unidades de tiempo de duración del contrato (días, meses)</param>
    ''' <param name="DURACION">Cantidad de días, meses, que dura el contrato.</param>
    ''' <returns>Fecha de terminación del contrato.</returns>
    Public Shared Function Calcular_Fecha_terminación_Contrato(fechaInicial As Date, ByVal tipoDuracion As String, ByVal duracion As Integer) As Date
        Dim fechaTerminacion As Date
        If tipoDuracion = "D" Then
            fechaTerminacion = fechaInicial.AddDays(duracion)
            fechaTerminacion = fechaTerminacion.AddDays(-1)
        Else
            fechaTerminacion = fechaInicial.AddMonths(duracion)
            If fechaInicial.Day = 29 Then
                fechaTerminacion = New Date(fechaTerminacion.Year, fechaTerminacion.Month, 28)
            ElseIf fechaInicial.Day = 30 Then
                Try
                    fechaTerminacion = New Date(fechaTerminacion.Year, fechaTerminacion.Month, 29)
                Catch
                    fechaTerminacion = New Date(fechaTerminacion.Year, fechaTerminacion.Month, 28)
                End Try
            ElseIf fechaInicial.Day = 31 Then
                Try
                    fechaTerminacion = New Date(fechaTerminacion.Year, fechaTerminacion.Month, 30)
                Catch
                    Try
                        fechaTerminacion = New Date(fechaTerminacion.Year, fechaTerminacion.Month, 29)
                    Catch
                        fechaTerminacion = New Date(fechaTerminacion.Year, fechaTerminacion.Month, 28)
                    End Try
                End Try
            Else
                fechaTerminacion = fechaTerminacion.AddDays(-1)
            End If
        End If
        Return fechaTerminacion
    End Function


#Region "Gestionar Imágenes en BD y FTP"

    Public Enum TipoServidorArchivos
        Articulo
        Correspondencia
        FacturaElectronica
        Persona
        Visitante
        Requisicion
        ValidacionHojaDeVida
    End Enum

    'Public Shared Function ServidorArchivosDisponible(tipoServidorFotos As TipoServidorArchivos)
    '    If Not TIPOCONEXIONLOCAL() Then
    '        Dim servidor As String
    '        Dim username As String
    '        Dim password As String

    '        Select Case tipoServidorFotos
    '            Case TipoServidorArchivos.Articulo
    '                servidor = VariablesBase.VariablesBase.RutaServidorRemotofotosarticulos
    '                username = VariablesBase.VariablesBase.UsuarioServidorRemotofotosarticulos
    '                password = VariablesBase.VariablesBase.ClaveServidorRemotofotosarticulos
    '            Case TipoServidorArchivos.Correspondencia
    '                servidor = VariablesBase.VariablesBase.RutaServidorRemotoArchivo
    '                username = VariablesBase.VariablesBase.UsuarioServidorRemotoArchivo
    '                password = VariablesBase.VariablesBase.ClaveServidorRemotoArchivo
    '            Case TipoServidorArchivos.FacturaElectronica
    '                'servidor = VariablesBase.VariablesBase.RutaServidorRemotoFacturaElectronica
    '                'username = VariablesBase.VariablesBase.UsuarioServidorRemotoFacturaElectronica
    '                'password = VariablesBase.VariablesBase.ClaveServidorRemotoFacturaElectronica
    '                'Case TipoServidorArchivos.Persona
    '                '    servidor = VariablesBase.VariablesBase.RutaServidorRemotofotosPersona
    '                '    username = VariablesBase.VariablesBase.UsuarioServidorRemotofotosPersona
    '                '    password = VariablesBase.VariablesBase.ClaveServidorRemotofotosPersona
    '            Case TipoServidorArchivos.Visitante
    '                servidor = VariablesBase.VariablesBase.RutaServidorRemotofotosvisitantes
    '                username = VariablesBase.VariablesBase.UsuarioServidorRemotofotosvisitantes
    '                password = VariablesBase.VariablesBase.ClaveServidorRemotofotosvisitantes
    '                'Case TipoServidorArchivos.Requisicion
    '                '    servidor = VariablesBase.VariablesBase.RutaServidorRemotoRequisiciones
    '                '    username = VariablesBase.VariablesBase.UsuarioServidorRemotoRequisiciones
    '                '    password = VariablesBase.VariablesBase.ClaveServidorRemotoRequisiciones
    '                'Case TipoServidorArchivos.ValidacionHojaDeVida
    '                '    servidor = VariablesBase.VariablesBase.RutaServidorRemotoValidacionHojaDeVida
    '                '    username = VariablesBase.VariablesBase.UsuarioServidorRemotoValidacionHojaDeVida
    '                '    password = VariablesBase.VariablesBase.ClaveServidorRemotoValidacionHojaDeVida
    '            Case Else
    '                Return False
    '        End Select

    '        Dim serverURI As String = "ftp://" & servidor
    '        Dim requestDir As FtpWebRequest = WebRequest.Create(serverURI)
    '        requestDir.Method = WebRequestMethods.Ftp.ListDirectoryDetails
    '        requestDir.Credentials = New NetworkCredential(username, password)
    '        Try
    '            Dim response As FtpWebResponse = requestDir.GetResponse()
    '            Return True
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    Else
    '        Return True
    '    End If
    'End Function

    Public Shared Function SubirFotoImagenMiniaturaBD(ByVal ID As Int64, ByVal FotoImagen As Image, _
                                                      ByVal TABLA As String, ByVal NOMBREARCHIVO As String, _
                            ByVal AnchoMiniatura As Integer, ByVal LargoMiniatura As Integer) As Boolean

        Dim ImagenMiniaturaGuardadaServidor As Boolean = False
        ' Dim _CadenaConexion As New System.Data.SqlClient.SqlConnection _
        '("Data Source=" + VariablesBase.VariablesBase.Servidor + ";Initial Catalog=" + "FOTOSEIMAGENES" + _
        ' ";User ID=" + VariablesBase.VariablesBase.Usuario + ";Password=" + VariablesBase.VariablesBase.Contraseña)
        Dim _CadenaConexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta As New SqlCommand("dbo.GuardarFotosImagenes", _CadenaConexion)
        Consulta.CommandType = CommandType.StoredProcedure

        Dim tipo As Integer = 0
        Select Case TABLA
            Case "FOTOPERSONA"
                tipo = 1
            Case "SC_FOTOVISITANTE"
                tipo = 2
            Case "FOTOARTICULO"
                tipo = 3
        End Select

        Consulta.Parameters.AddWithValue("@TIPO", tipo)
        Consulta.Parameters.AddWithValue("@ID", ID)
        Consulta.Parameters.Add("@FOTO", System.Data.SqlDbType.Image)
        Consulta.Parameters.AddWithValue("@NOMBREARCHIVO", NOMBREARCHIVO)
        Consulta.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Consulta.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Try
            'Asignando el valor de la imagen
            Dim imagen As New Bitmap(FotoImagen)
            Dim Vista_Miniatura As Image = imagen.GetThumbnailImage(AnchoMiniatura, LargoMiniatura, Nothing, New IntPtr())
            'Stream usado como buffer
            Dim ms As New System.IO.MemoryStream()
            ' Se guarda la imagen en el buffer
            Vista_Miniatura.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            ' Se extraen los bytes del buffer para asignarlos como valor para el  parámetro
            Consulta.Parameters("@FOTO").Value = ms.GetBuffer
            _CadenaConexion.Open()
            Consulta.ExecuteNonQuery()
            _CadenaConexion.Close()
            ImagenMiniaturaGuardadaServidor = True
        Catch ex As Exception
            MsgBox(ex.ToString)
            ImagenMiniaturaGuardadaServidor = False
        Finally
            _CadenaConexion.Close()
        End Try
        SubirFotoImagenMiniaturaBD = ImagenMiniaturaGuardadaServidor
    End Function


    'Public Shared Function SubirArchivoFTP(ByVal FotoImagen As Image, ByVal NOMBREARCHIVO As String, ByVal Tabla As String, ByVal MarcaTemporal As Boolean, ByVal TipoArchivo As String) As Boolean
    '    Try
    '        'Archivo de origen
    '        Dim FileName As String = ""

    '        If Tabla = "SC_FOTOVISITANTE" Then
    '            'Sobreponer texto con fecha y hora a la imagen
    '            Dim bmpTemp As Bitmap = New Bitmap(FotoImagen)
    '            Dim gfx As Graphics = Graphics.FromImage(bmpTemp)
    '            gfx.FillRectangle(Brushes.White, 488, 463, 148, 13)
    '            gfx.DrawString(DateTime.Now.ToString(), New Font("Calibri", 10, FontStyle.Bold), Brushes.Black, 487, 460)
    '            FotoImagen = bmpTemp
    '            gfx.Dispose()
    '        End If

    '        Select Case TipoArchivo
    '            Case "jpg"
    '                FileName = VariablesBase.VariablesBase._path + "\" + NOMBREARCHIVO
    '                If File.Exists(FileName) Then
    '                    File.Delete(FileName)
    '                End If

    '                FotoImagen.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
    '        End Select

    '        Dim ArchivoRemoto As String = ""
    '        Dim usr As String = ""
    '        Dim psw As String = ""
    '        If TIPOCONEXIONLOCAL() = True Then
    '            Select Case Tabla
    '                'Case "FOTOPERSONA"
    '                '    ArchivoRemoto = VariablesBase.VariablesBase.RutaServidorLocalfotosPersona + "\" + NOMBREARCHIVO
    '                Case "SC_FOTOVISITANTE"
    '                    ArchivoRemoto = VariablesBase.VariablesBase.RutaServidorLocalfotosvisitantes + "\" + NOMBREARCHIVO
    '                Case "FOTOARTICULO"
    '                    ArchivoRemoto = VariablesBase.VariablesBase.RutaServidorLocalfotosarticulos + "\" + NOMBREARCHIVO
    '            End Select
    '            usr = "xxxxxxxxxxxxxxx"
    '            psw = "xxxxxxxxxx"
    '        Else
    '            Select Case Tabla
    '                'Case "FOTOPERSONA"
    '                '    ArchivoRemoto = "ftp://" + VariablesBase.VariablesBase.RutaServidorRemotofotosPersona + "/" + NOMBREARCHIVO
    '                '    usr = VariablesBase.VariablesBase.UsuarioServidorRemotofotosPersona
    '                '    psw = VariablesBase.VariablesBase.ClaveServidorRemotofotosPersona
    '                Case "SC_FOTOVISITANTE"
    '                    ArchivoRemoto = "ftp://" + VariablesBase.VariablesBase.RutaServidorRemotofotosvisitantes + "/" + NOMBREARCHIVO
    '                    usr = VariablesBase.VariablesBase.UsuarioServidorRemotofotosvisitantes
    '                    psw = VariablesBase.VariablesBase.ClaveServidorRemotofotosvisitantes
    '                Case "FOTOARTICULO"
    '                    ArchivoRemoto = "ftp://" + VariablesBase.VariablesBase.RutaServidorRemotofotosarticulos + "/" + NOMBREARCHIVO
    '                    usr = VariablesBase.VariablesBase.UsuarioServidorRemotofotosarticulos
    '                    psw = VariablesBase.VariablesBase.ClaveServidorRemotofotosarticulos
    '            End Select
    '        End If

    '        My.Computer.Network.UploadFile(FileName, ArchivoRemoto, usr, psw)
    '        'File.Delete(FileName)
    '        Cursor.Current = Cursors.Default
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Cursor.Current = Cursors.Default
    '        Return False
    '    End Try
    'End Function


    Public Shared Function TIPOCONEXIONLOCAL() As Boolean
        Select Case VariablesBase.VariablesBase.Servidor
            Case "192.168.20.9", "ISMSERVER", "DESYOVAN\DESYOVAN"
                TIPOCONEXIONLOCAL = True
            Case Else
                TIPOCONEXIONLOCAL = False
        End Select
    End Function


    Public Shared Function existeObjeto(ByVal dir As String, ByVal user As String, ByVal pass As String) As Boolean
        Dim peticionFTP As FtpWebRequest
        ' Creamos una petición FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp
        peticionFTP.UsePassive = False
        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el CATCH
            ' se devolverá falso
            Return False
        End Try
    End Function


    Public Shared Function DevolverImagenMiniatura(ByVal tipo As Integer, ByVal id As Integer) As Image
        Dim dt As New DataTable
        Dim comando As New SqlCommand("CargarImagenMiniatura")
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Tipo", tipo)
        comando.Parameters.AddWithValue("@Id", id)
        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        comando.Connection = conn
        Dim adaptador As New SqlDataAdapter(comando)
        conn.Open()
        adaptador.Fill(dt)
        conn.Close()
        If dt.Rows.Count > 0 Then
            Dim Fila_Foto As DataRow = dt.Rows(0)
            Try
                Dim byteBLOBData(-1) As [Byte]
                byteBLOBData = CType(Fila_Foto("FOTO"), [Byte]())
                Dim stmBLOBData As New MemoryStream(byteBLOBData)
                DevolverImagenMiniatura = Image.FromStream(stmBLOBData)
            Catch ex As Exception
                MsgBox(ex.ToString)
                DevolverImagenMiniatura = Nothing
            End Try
        Else
            DevolverImagenMiniatura = Nothing
        End If
    End Function


    'Public Shared Function DevolverImagenOriginal(ByVal tipo As Integer, ByVal id As Integer, ByVal user As String, ByVal pass As String) As Image
    '    Dim dt As New DataTable
    '    Dim comando As New SqlCommand("CargarImagenMiniatura")
    '    comando.CommandType = CommandType.StoredProcedure
    '    comando.Parameters.AddWithValue("@Tipo", tipo)
    '    comando.Parameters.AddWithValue("@Id", id)
    '    Dim conn As New SqlConnection(My.Settings.CadenaConexión)
    '    comando.Connection = conn
    '    Dim adaptador As New SqlDataAdapter(comando)
    '    conn.Open()
    '    adaptador.Fill(dt)
    '    conn.Close()
    '    If dt.Rows.Count > 0 Then
    '        Dim Fila_Foto As DataRow = dt.Rows(0)
    '        Dim tabla As String = ""
    '        Select Case tipo
    '            Case 1
    '                tabla = "FOTOPERSONA"
    '            Case 2
    '                tabla = "SC_FOTOVISITANTE"
    '            Case 3
    '                tabla = "FOTOARTICULO"
    '        End Select
    '        DevolverImagenOriginal = DevolverImagenDesdeArchivo(Fila_Foto("NOMBREARCHIVO"), tabla, user, pass)
    '    Else
    '        DevolverImagenOriginal = Nothing
    '    End If
    'End Function


    'Private Shared Function DevolverImagenDesdeArchivo(ByVal NombreArchivo As String, ByVal Tabla As String, ByVal user As String, ByVal pass As String) As Image
    '    Cursor.Current = Cursors.WaitCursor
    '    Dim Imagen As String

    '    If NombreArchivo <> "" Then
    '        Imagen = Trim(NombreArchivo)
    '    Else
    '        Cursor.Current = Cursors.Default
    '        Return Nothing
    '    End If

    '    Try
    '        Dim ArchivoRemoto As String = ""
    '        Dim sfile As String = VariablesBase.VariablesBase._path + "\" + Imagen 'Ubicación donde se va a descargar el archivo

    '        If TIPOCONEXIONLOCAL() = True Then
    '            Select Case Tabla
    '                Case "FOTOPERSONA"
    '                    ArchivoRemoto = VariablesBase.VariablesBase.RutaServidorLocalfotosPersona + "\"
    '                Case "SC_FOTOVISITANTE"
    '                    ArchivoRemoto = VariablesBase.VariablesBase.RutaServidorLocalfotosvisitantes + "\"
    '                Case "FOTOARTICULO"
    '                    ArchivoRemoto = VariablesBase.VariablesBase.RutaServidorLocalfotosarticulos + "\"
    '            End Select
    '            ArchivoRemoto += Imagen

    '            If File.Exists(ArchivoRemoto) = False Then
    '                MsgBox("El archivo no se encuentra disponible", MsgBoxStyle.Information, "Archivo no disponible")
    '                Cursor.Current = Cursors.Default
    '                DevolverImagenDesdeArchivo = Nothing
    '                Exit Function
    '            Else
    '                File.Delete(sfile)
    '                My.Computer.Network.DownloadFile(ArchivoRemoto, sfile, "xxxxxxxxx", "xxxxxxxxxxx")
    '            End If
    '        Else
    '            Select Case Tabla
    '                Case "FOTOPERSONA"
    '                    ArchivoRemoto = "ftp://" + VariablesBase.VariablesBase.RutaServidorRemotofotosPersona + "/"
    '                Case "SC_FOTOVISITANTE"
    '                    ArchivoRemoto = "ftp://" + VariablesBase.VariablesBase.RutaServidorRemotofotosvisitantes + "/"
    '                Case "FOTOARTICULO"
    '                    ArchivoRemoto = "ftp://" + VariablesBase.VariablesBase.RutaServidorRemotofotosarticulos + "/"
    '            End Select

    '            ArchivoRemoto += Imagen
    '            'verificar si existe por vía FTP, cuando se esta fuera de la red
    '            If existeObjeto(ArchivoRemoto, user, pass) = False Then
    '                MsgBox("El archivo no se encuentra disponible", MsgBoxStyle.Information, "Archivo no disponible")
    '                DevolverImagenDesdeArchivo = Nothing
    '                Exit Function
    '            Else
    '                If File.Exists(sfile) = True Then
    '                    File.Delete(sfile)
    '                End If
    '                My.Computer.Network.DownloadFile(ArchivoRemoto, sfile, user, pass)
    '            End If
    '        End If

    '        Using fs As New FileStream(sfile, FileMode.Open, FileAccess.Read)
    '            Dim img = Image.FromStream(fs)
    '            DevolverImagenDesdeArchivo = img
    '        End Using
    '        File.Delete(sfile)
    '        Cursor.Current = Cursors.Default

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        DevolverImagenDesdeArchivo = Nothing
    '    End Try

    '    Cursor.Current = Cursors.Default
    'End Function


    Public Shared Function DevolverRutaArchivoImagen(ByVal tipo As Integer, ByVal id As Integer) As String
        Dim dt As New DataTable
        Dim comando As New SqlCommand("CargarImagenMiniatura")
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Tipo", tipo)
        comando.Parameters.AddWithValue("@Id", id)
        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        comando.Connection = conn
        Dim adaptador As New SqlDataAdapter(comando)
        conn.Open()
        adaptador.Fill(dt)
        conn.Close()
        If dt.Rows.Count > 0 Then
            Dim Fila_Foto As DataRow = dt.Rows(0)
            DevolverRutaArchivoImagen = Fila_Foto("NOMBREARCHIVO")
        Else
            DevolverRutaArchivoImagen = ""
        End If
    End Function

#End Region 'Gestionar Imágenes en BD y FTP

    ''' <summary>Generates barcode images from a string of data.</summary>
    ''' <param name="Data">Data to be encoded into the barcode.</param>
    ''' <param name="_Width">Width of the resulting image.</param>
    ''' <returns>Image representing the data generated.</returns>
    ''' <remarks>
    ''' Barcode Image Generation Library, https://www.codeproject.com/Articles/20823/Barcode-Image-Generation-Library
    ''' Author: Brad Barnhill, https://www.codeproject.com/Members/bbarnhill
    ''' Licensed under The Apache License, Version 2.0 http://www.opensource.org/licenses/apache2.0.php
    ''' </remarks>
    Public Shared Function GenerarCodigoBarras(ByVal Data As String, _Width As Integer) As Image
        'Dim BarWidth As Integer
        Dim AspectRatio As Double = 1
        'Dim _Width As Integer
        Dim _Height As Integer
        Dim _forecolor As Color = Color.Black
        Dim _backcolor As Color = Color.White

        Dim Raw_Data As String = Data
        Dim C39_Code As New System.Collections.Hashtable
        Dim Encoded_Value As String = ""

        C39_Code.Clear()
        C39_Code.Add("0"c, "101001101101")
        C39_Code.Add("1"c, "110100101011")
        C39_Code.Add("2"c, "101100101011")
        C39_Code.Add("3"c, "110110010101")
        C39_Code.Add("4"c, "101001101011")
        C39_Code.Add("5"c, "110100110101")
        C39_Code.Add("6"c, "101100110101")
        C39_Code.Add("7"c, "101001011011")
        C39_Code.Add("8"c, "110100101101")
        C39_Code.Add("9"c, "101100101101")
        C39_Code.Add("A"c, "110101001011")
        C39_Code.Add("B"c, "101101001011")
        C39_Code.Add("C"c, "110110100101")
        C39_Code.Add("D"c, "101011001011")
        C39_Code.Add("E"c, "110101100101")
        C39_Code.Add("F"c, "101101100101")
        C39_Code.Add("G"c, "101010011011")
        C39_Code.Add("H"c, "110101001101")
        C39_Code.Add("I"c, "101101001101")
        C39_Code.Add("J"c, "101011001101")
        C39_Code.Add("K"c, "110101010011")
        C39_Code.Add("L"c, "101101010011")
        C39_Code.Add("M"c, "110110101001")
        C39_Code.Add("N"c, "101011010011")
        C39_Code.Add("O"c, "110101101001")
        C39_Code.Add("P"c, "101101101001")
        C39_Code.Add("Q"c, "101010110011")
        C39_Code.Add("R"c, "110101011001")
        C39_Code.Add("S"c, "101101011001")
        C39_Code.Add("T"c, "101011011001")
        C39_Code.Add("U"c, "110010101011")
        C39_Code.Add("V"c, "100110101011")
        C39_Code.Add("W"c, "110011010101")
        C39_Code.Add("X"c, "100101101011")
        C39_Code.Add("Y"c, "110010110101")
        C39_Code.Add("Z"c, "100110110101")
        C39_Code.Add("-"c, "100101011011")
        C39_Code.Add("."c, "110010101101")
        C39_Code.Add(" "c, "100110101101")
        C39_Code.Add("$"c, "100100100101")
        C39_Code.Add("/"c, "100100101001")
        C39_Code.Add("+"c, "100101001001")
        C39_Code.Add("%"c, "101001001001")
        C39_Code.Add("*"c, "100101101101")

        Dim strNoAstr As String = Raw_Data.Replace("*", "")

        Dim Code39_Charset As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%"
        Dim sum As Integer = 0

        ' CALCULATE THE CHECKSUM
        For i As Integer = 0 To strNoAstr.Length - 1
            sum = sum + Code39_Charset.IndexOf(strNoAstr(i).ToString())
        Next

        Dim strFormattedData As String = (Convert.ToString("*") & strNoAstr) + "*"

        Dim result As String = ""
        For Each c As Char In strFormattedData
            Try
                result += C39_Code(c).ToString()
                ' WHITESPACE
                result += "0"
            Catch
                MsgBox("Datos inválidos.")
            End Try
        Next
        result = result.Substring(0, result.Length - 1)

        ' CLEAR THE HASHTABLE SO IT NO LONGER TAKES UP MEMORY
        C39_Code.Clear()
        Encoded_Value = result

        ' AUTOMATICALLY CALCULATE IF APPLICABLE.
        'Width = BarWidth * Encoded_Value.Length
        _Height = Math.Truncate(_Width / AspectRatio)

        ' GETS A BITMAP REPRESENTATION OF THE ENCODED DATA.
        Dim b As Bitmap = Nothing

        b = New Bitmap(_Width, _Height)
        Dim iBarWidth As Integer = _Width / Encoded_Value.Length
        Dim shiftAdjustment As Integer = 0
        Dim iBarWidthModifier As Integer = 1

        ' SET ALIGNMENT
        shiftAdjustment = (_Width Mod Encoded_Value.Length) / 2

        If iBarWidth <= 0 Then
            Throw New Exception("EGENERATE_IMAGE-2: Image size specified not large enough to draw image. (Bar size determined to be less than 1 pixel)")
        End If

        ' DRAW IMAGE
        Dim pos As Integer = 0
        Dim halfBarWidth As Integer = CInt(iBarWidth * 0.5)

        Using g As Graphics = Graphics.FromImage(b)
            ' CLEARS THE IMAGE AND COLORS THE ENTIRE BACKGROUND
            g.Clear(_backcolor)

            ' LINES ARE FBARWIDTH WIDE SO DRAW THE APPROPRIATE COLOR LINE VERTICALLY
            Using backpen As New Pen(_backcolor, iBarWidth \ iBarWidthModifier)
                Using pen As New Pen(_forecolor, iBarWidth \ iBarWidthModifier)
                    While pos < Encoded_Value.Length
                        If Encoded_Value(pos) = "1"c Then
                            g.DrawLine(pen, New Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, 0), New Point(pos * iBarWidth + shiftAdjustment + halfBarWidth, _Height))
                        End If
                        pos += 1
                    End While
                End Using
            End Using
        End Using

        GenerarCodigoBarras = DirectCast(b, Image)
        Return b
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdBodega"></param>
    ''' <returns></returns>
    Public Shared Function EsBodegaPrincipal(IdBodega As Integer) As Boolean
        Return If(VariablesBase.VariablesBase.TipoBodegaActual = "P", True, False)
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdBodega"></param>
    ''' <returns></returns>
    Public Shared Function EmpresaBodegaActual(IdBodega As Integer) As Integer
        Return VariablesBase.VariablesBase.EmpresaBodegaActual
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdDependencia"></param>
    ''' <returns></returns>
    Public Shared Function EmpresaSisControlActual(IdDependencia As Integer) As Integer
        Return VariablesBase.VariablesBase.EmpresaSisControlActual
    End Function


    ''' <summary>
    ''' Retira los caracteres en blanco sobrantes en una línea de texto o párrafo.
    ''' Mantiene el número de líneas no vacías o combina todo el texto en una sola línea dependiendo de la opción seleccionada.
    ''' </summary>
    ''' <param name="cadena">Cadena a la que se le retirarán los caracteres en blanco</param>
    ''' <param name="esMultiLinea">Determina si se deben mantener el número de líneas no vacías o combinar todo el texto en una sola línea</param>
    ''' <returns>Cadena sin caracteres en blanco.</returns>
    Public Shared Function QuitarCaracteresEnBlanco(ByVal cadena As String, Optional ByVal esMultiLinea As Boolean = False) As String
        If Not IsNothing(cadena) Then
            If Regex.Replace(cadena, "[\s\n]", "") <> "" Then
                Dim Sb_CadenaLimpieza As New StringBuilder
                Dim lineas As String() = Split(cadena, Environment.NewLine)
                For i = 0 To lineas.Count - 1
                    lineas(i) = Regex.Replace(lineas(i), "[\s\n]", " ") ' Caracteres blancos del texto
                    lineas(i) = Regex.Replace(lineas(i), "[ ]+", " ") ' Espacios seguidos resultado de los reemplazos anteriores
                    lineas(i) = Trim(lineas(i))
                    If lineas(i) <> "" Then
                        Sb_CadenaLimpieza.Append(lineas(i))
                        If i < lineas.Count - 1 Then
                            If esMultiLinea Then
                                Sb_CadenaLimpieza.Append(Environment.NewLine)
                            Else
                                Sb_CadenaLimpieza.Append(" ")
                            End If
                        End If
                    End If
                Next
                Dim cadenaFinal As String = Sb_CadenaLimpieza.ToString
                cadenaFinal = Regex.Replace(cadenaFinal, "[\s]+$", "")
                cadenaFinal = Trim(cadenaFinal)
                Return cadenaFinal
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function

#Region "Envío de Correos"

    ''' <summary>
    ''' Permite el envío de correos electrónicos.
    ''' </summary>
    ''' <param name="textoContenido">Cuerpo del correo en código HTML</param>
    ''' <param name="asunto">Texto del asunto del mensaje</param>
    ''' <param name="correoOrigen">Dirección de correo desde la cual se realiza el envío.</param>
    ''' <param name="CorreoPara">Dirección de correo que recibe el mensaje como principal destinatario.</param>
    ''' <param name="correosCopia">Dirección de correo que recibe una copia del mensaje.</param>
    ''' <param name="mostrarConfirmacionEnviado">Indica si se muestra el dialogo de confirmación de envío al finalizar el envío de correos.</param>
    ''' <param name="archivoAdjunto">Ruta del archivo que se adjunta al mensaje.</param>
    ''' <param name="envioAsincrono">Indica si el envío de correos se debe realizar en segundo plano, de lo contrario el hilo de la aplicación queda bloqueado hasta que termine el envío del correo.</param>
    ''' <remarks>Revisar conteo para cambiar de correo cuando se llegue a 450 enviados.</remarks>
    Public Shared Sub EnviarCorreo(ByVal textoContenido As String, ByVal asunto As String, ByVal correoOrigen As String, ByVal CorreoPara As String, ByVal correosCopia As List(Of String), ByVal mostrarConfirmacionEnviado As Boolean, ByVal archivoAdjunto As String, Optional ByVal envioAsincrono As Boolean = False) 'ByVal conteo As Integer
        Try
            If Trim(textoContenido.Length) > 0 Then
                If validarDireccionCorreo(correoOrigen) Then
                    Dim claveCorreoOrigen As String = ""
                    If VariablesBase.VariablesBase.correoContraseña.TryGetValue(correoOrigen, claveCorreoOrigen) Then
                        If validarDireccionCorreo(CorreoPara) Then
                            Dim cuerpo As New StringBuilder
                            cuerpo.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>")
                            cuerpo.Append("<html xmlns=""http://www.w3.org/1999/xhtml"">")
                            cuerpo.Append("<head>")
                            cuerpo.Append("<meta http-equiv=""Content-Type"" content=""text/html charset=utf-8"" />")
                            cuerpo.Append("</head>")
                            cuerpo.Append("<body>")
                            cuerpo.Append("<center>")
                            cuerpo.Append(textoContenido)
                            cuerpo.Append("</center>")
                            cuerpo.Append("</body>")
                            cuerpo.Append("</html>")
                            Dim strSMTP As String = "smtp.gmail.com"
                            Dim SmtpClient As New SmtpClient("smtp.gmail.com", 587)
                            'AddHandler SmtpClient.SendCompleted, AddressOf OnSendCompletedCallback
                            SmtpClient.UseDefaultCredentials = False
                            SmtpClient.Credentials = New Net.NetworkCredential(correoOrigen, claveCorreoOrigen)
                            SmtpClient.EnableSsl = True
                            Dim mail As New MailMessage()
                            If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
                                mail.To.Add(CorreoPara)
                                If Not IsNothing(correosCopia) Then
                                    If correosCopia.Count > 0 Then
                                        For Each correoCC As String In correosCopia
                                            If validarDireccionCorreo(correoCC) Then
                                                mail.Bcc.Add(correoCC)
                                            End If
                                        Next
                                    End If
                                End If
                            Else
                                mail.To.Add("soporteaplicaciones@ismocol.com")
                            End If
                            mail.From = New MailAddress(correoOrigen)
                            If asunto.Length > 0 Then
                                mail.Subject = asunto
                            End If
                            mail.Body = cuerpo.ToString
                            If archivoAdjunto.Length > 0 Then
                                Dim att As New Attachment(archivoAdjunto, System.Net.Mime.MediaTypeNames.Application.Octet)
                                att.Name = System.IO.Path.GetFileName(archivoAdjunto)
                                mail.Attachments.Add(att)
                            End If
                            mail.IsBodyHtml = True
                            mail.Priority = MailPriority.Normal
                            If envioAsincrono Then
                                SmtpClient.SendAsync(mail, Nothing)
                            Else
                                SmtpClient.Send(mail)
                            End If
                            If mostrarConfirmacionEnviado Then
                                Dim strCorreosEnviados As New StringBuilder
                                If mail.Bcc.Count > 0 Then
                                    strCorreosEnviados.Append("a los correos: " & CorreoPara & ", ")
                                    For Each correo As MailAddress In mail.Bcc
                                        strCorreosEnviados.Append(correo.Address & ", " & correo.DisplayName & ", ")
                                    Next
                                Else
                                    strCorreosEnviados.Append("al correo" & CorreoPara & ".")
                                End If
                                MsgBox("Se envió notificación " & strCorreosEnviados.ToString, MsgBoxStyle.Information, "Envío de Correos")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    ''' <summary>
    ''' Verifica si una dirección de correo electrónico es válida.
    ''' </summary>
    ''' <param name="direccionCorreo">Dirección de correo a validar.</param>
    ''' <returns>Si la dirección es válida o no.</returns>
    Public Shared Function validarDireccionCorreo(ByVal direccionCorreo As String) As Boolean
        Dim pattern As String = "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"
        If Regex.IsMatch(direccionCorreo, pattern) = False Then
            pattern = "(^[A-Za-z]([_.-]?[A-Za-z0-9])*)([@])([A-Za-z]([.-]?[A-Za-z0-9])*)([.][a-z]{2,4})$"
            If Regex.IsMatch(direccionCorreo, pattern) = False Then
                pattern = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$"
                If Regex.IsMatch(direccionCorreo, pattern) = False Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function


    ''' <summary>
    ''' Verifica si una dirección de correo electrónico cumple con el formato de correo corporativo.
    ''' </summary>
    ''' <param name="correoCorporativo">Dirección de correo a validar.</param>
    ''' <returns>Si la dirección cumple con el formato de correo corporativo o no.</returns>
    Public Shared Function validarCorreoCorporativo(ByVal correoCorporativo As String) As Boolean
        Return Regex.IsMatch(correoCorporativo, "(^[A-Za-z]([_.-]?[A-Za-z0-9])*)(?i)(@ismocol\.com)$") +
               Regex.IsMatch(correoCorporativo, "(^[A-Za-z]([_.-]?[A-Za-z0-9])*)(?i)(@zamoranacolombia\.com)$") +
               Regex.IsMatch(correoCorporativo, "(^[A-Za-z]([_.-]?[A-Za-z0-9])*)(?i)(@consorcioisla2020berrio\.com)$")
    End Function

#End Region 'Envío de Correos

    ''' <summary>
    ''' Consulta la configuración de idioma y formatos actual del sistema e indica que cambios a la configuración se deben realizar para evitar problemas de incompatibilidad entre formatos al momento de importar o exportar datos de la aplicación.
    ''' </summary>
    Public Shared Sub VerificarConfiguracionRegional()
        Dim cultura As CultureInfo = VariablesBase.VariablesBase.configRegionalSistema
        Dim errorStr As New StringBuilder
        Dim nError As Integer = 0

        If cultura.NumberFormat.NumberDecimalSeparator <> "," Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de decimales en Números a "","".")
            nError += 1
        End If
        If cultura.NumberFormat.NumberGroupSeparator <> "." Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de miles en Números a ""."".")
            nError += 1
        End If
        If cultura.NumberFormat.CurrencyDecimalSeparator <> "," Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de decimales en Moneda a "","".")
            nError += 1
        End If
        If cultura.NumberFormat.CurrencyGroupSeparator <> "." Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de miles en Moneda a ""."".")
            nError += 1
        End If
        If cultura.NumberFormat.CurrencySymbol <> "$" Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el símbolo de moneda a ""$"".")
            nError += 1
        End If
        'If cultura.NumberFormat.PercentDecimalSeparator <> "," Then
        '    errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de decimales en Porcentaje a "","".")
        '    nError += 1
        'End If
        'If cultura.NumberFormat.PercentGroupSeparator <> "." Then
        '    errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de miles en Porcentaje a ""."".")
        '    nError += 1
        'End If
        If cultura.NumberFormat.PercentSymbol <> "%" Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el símbolo de porcentaje a ""%"".")
            nError += 1
        End If
        If cultura.TextInfo.ListSeparator <> ";" Then
            errorStr.AppendLine(nError + 1 & ") " & "Cambie el separador de listas a "";"".")
            nError += 1
        End If
        'If cultura.Name <> "es-CO" Then
        '    errorStr.AppendLine(nError + 1 & ") " & "Cambie la configuración regional a ""Español (Colombia)"".")
        '    nError += 1
        'End If
        'If InputLanguage.CurrentInputLanguage.Culture.Name <> "es-CO" Then
        '    errorStr.AppendLine(nError + 1 & ") " & "Cambie la distribución del teclado a ""Español, Latinoamérica"".")
        '    nError += 1
        'End If

        If nError > 0 Then
            MessageBox.Show("La configuración regional actual del equipo no es compatible." & Environment.NewLine & _
                            "Por favor realice los siguientes cambios:" & Environment.NewLine & Environment.NewLine & _
                            errorStr.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ''' <summary>
    ''' Asigna el foco del formulario a la caja de texto indicada y ubica el cursor al final del texto contenido.
    ''' </summary>
    ''' <param name="cajaTexto">Caja de texto a la cual se le asigna el foco.</param>
    Public Shared Sub EnfocarCajaTexto(cajaTexto As TextBox)
        cajaTexto.Select()
        cajaTexto.SelectionLength = 0
        cajaTexto.SelectionStart = cajaTexto.Text.Length + 1
    End Sub


    ''' <summary>
    ''' Aplica estilo de Número de Identificación Tributaria (NIT).
    ''' </summary>
    ''' <param name="nit">Secuencia numérica de la identificación.</param>
    ''' <param name="dv">Dígito de verificación</param>
    ''' <returns></returns>
    Public Shared Function FormatearNIT(nit As Object, Optional dv As Object = "") As String
        Return FormatearIdentificacion(nit) & If(dv <> "", "-" & dv, "")
    End Function


    ''' <summary>
    ''' Aplica estilo de identificación a una secuencia de números.
    ''' </summary>
    ''' <param name="id">Identificación representada como un número entero.</param>
    ''' <returns>Cadena de texto con la identificación formateada.</returns>
    Public Shared Function FormatearIdentificacion(id As Integer) As String
        Dim idFormato As String = id.ToString("#,#", Globalization.CultureInfo.CurrentCulture)
        idFormato = Replace(idFormato, ",", ".")
        Return idFormato
    End Function


    ''' <summary>
    ''' Aplica estilo de identificación a una cadena de texto con números.
    ''' </summary>
    ''' <param name="id">Cadena de texto de la identificación sin formato (sólo números).</param>
    ''' <returns>Cadena de texto con la identificación formateada.</returns>
    Public Shared Function FormatearIdentificacion(id As String) As String
        Dim idFormato As String = id
        Dim i = id.Length - 3
        While i > 0
            idFormato = idFormato.Insert(i, ".")
            i = i - 3
        End While
        Return idFormato
    End Function

    Public Shared Sub AbrirAccesoRemoto()
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = Application.StartupPath + "\" + "AnyDesk.exe"
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        myProcess.Start()
    End Sub

    ''' <summary>Crops an image from its center to the given size.</summary>
    ''' <param name="img">Original image</param>
    ''' <param name="targetHeight">Height of the cropped image</param>
    ''' <param name="targetWidth">Width of the cropped image</param>
    ''' <returns>Cropped image from its center</returns>
    Public Shared Function CropCenterImage(img As Image, targetHeight As Integer, targetWidth As Integer) As Image
        Return CropCenterImage(img, New Size(targetHeight, targetWidth))
    End Function

    ''' <summary>Crops an image from its center to the given size.</summary>
    ''' <param name="img">Original image</param>
    ''' <param name="targetSize">Size of the cropped image</param>
    ''' <returns>Cropped image from its center</returns>
    Public Shared Function CropCenterImage(img As Image, targetSize As Size) As Image
        Dim cropOriginPoint As New Point(0, 0)
        Dim img2 As Image
        Dim newSize As Size
        Dim imgSize As Size = img.Size
        Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        If img.Width >= img.Height Then
            If img.Width >= targetSize.Width Then
                newSize.Height = targetSize.Height
                newSize.Width = AjustarAncho(imgSize, targetSize).Height
                imgSize.Height = targetSize.Height
                imgSize.Width = newSize.Width
                If newSize.Width < targetSize.Width Then
                    newSize.Width = targetSize.Width
                    newSize.Height = AjustarAlto(imgSize, targetSize).Height
                End If
            Else
                newSize.Width = targetSize.Width
                newSize.Height = AjustarAlto(imgSize, targetSize).Height
                imgSize.Width = targetSize.Width
                imgSize.Height = newSize.Height
                If newSize.Height < targetSize.Height Then
                    newSize.Height = targetSize.Height
                    newSize.Width = AjustarAncho(imgSize, targetSize).Width
                End If
            End If

            img2 = img.GetThumbnailImage(newSize.Width, newSize.Height, myCallback, IntPtr.Zero)
            cropOriginPoint.X = ((img2.Width / 2) - (targetSize.Width / 2))
            cropOriginPoint.Y = ((img2.Height / 2) - (targetSize.Height / 2))
        Else
            If img.Height >= targetSize.Height Then
                newSize.Width = targetSize.Width
                newSize.Height = AjustarAlto(imgSize, targetSize).Height
                imgSize.Width = targetSize.Width
                imgSize.Height = newSize.Height
                If newSize.Height < targetSize.Height Then
                    newSize.Height = targetSize.Height
                    newSize.Width = AjustarAncho(imgSize, targetSize).Width
                End If
            Else
                newSize.Height = targetSize.Height
                newSize.Width = AjustarAncho(imgSize, targetSize).Width
                imgSize.Height = targetSize.Height
                imgSize.Width = newSize.Width
                If newSize.Width < targetSize.Width Then
                    newSize.Width = targetSize.Width
                    newSize.Height = AjustarAlto(imgSize, targetSize).Height
                End If
            End If

            img2 = img.GetThumbnailImage(newSize.Width, newSize.Height, myCallback, IntPtr.Zero)
            cropOriginPoint.X = ((img2.Width / 2) - (targetSize.Width / 2))
            cropOriginPoint.Y = ((img2.Height / 2) - (targetSize.Height / 2))
        End If

        Dim cropArea As New Rectangle(cropOriginPoint.X, cropOriginPoint.Y, targetSize.Width, targetSize.Height)
        Dim bmp As New Bitmap(img2)
        Try
            img2.Dispose()
            Return bmp.Clone(cropArea, bmp.PixelFormat)
        Catch ex As Exception
            bmp.Dispose()
            Return Nothing
        End Try
    End Function

    Public Shared Function AjustarAlto(ImgSize As Size, targetSize As Size) As Size
        AjustarAlto.Width = targetSize.Width
        AjustarAlto.Height = (targetSize.Width * ImgSize.Height) / ImgSize.Width
        Return AjustarAlto
    End Function
    Public Shared Function AjustarAncho(ImgSize As Size, targetSize As Size) As Size
        AjustarAncho.Height = targetSize.Height
        AjustarAncho.Width = (targetSize.Height * ImgSize.Width) / ImgSize.Height
        Return AjustarAncho
    End Function

    Private Shared Function ThumbnailCallback() As Boolean
        Return False
    End Function

    ''' <summary>Compara dos imágenes y determina su igualdad con un margen de 5%</summary>
    ''' <param name="imagen1">Primera imagen a comparar</param>
    ''' <param name="imagen2">Segunda imagen a comparar</param>
    ''' <returns>Verdadero si las imagenes son iguales, falso si son diferentes</returns>
    Public Shared Function ImagenesIguales(imagen1 As Image, imagen2 As Image) As Boolean
        Return CompareImages(imagen1, imagen2, 20) <= 5 'Porcentaje de diferencia entre las imágenes.
    End Function

    ''' <summary>Compares two images and identify if images are equal even if they are differently sized</summary>
    ''' <param name="image1">First image to compare</param>
    ''' <param name="image2">Second image to compare</param>
    ''' <param name="tolerance">Higher values produce more strict comparisons.</param>
    ''' <returns>Difference percentage between the two images, the lower difference amount in percentage, more equal the images are and more likely for them to be equal</returns>
    ''' <remarks>https://stackoverflow.com/questions/3384967/how-to-compare-image-objects-with-c-sharp-net/21790555#21790555</remarks>
    Private Shared Function CompareImages(ByVal image1 As Image, ByVal image2 As Image, ByVal tolerance As Integer) As Double
        Dim bmp1 As Bitmap = New Bitmap(image1, New Size(128, 128))
        Dim bmp2 As Bitmap = New Bitmap(image2, New Size(128, 128))
        Dim Image1Size As Integer = bmp1.Width * bmp1.Height
        Dim Image2Size As Integer = bmp2.Width * bmp2.Height
        Dim Image3 As Bitmap
        If Image1Size > Image2Size Then
            bmp1 = New Bitmap(bmp1, bmp2.Size)
            Image3 = New Bitmap(bmp2.Width, bmp2.Height)
        Else
            bmp1 = New Bitmap(bmp1, bmp2.Size)
            Image3 = New Bitmap(bmp2.Width, bmp2.Height)
        End If
        Dim Color1 As Color
        Dim Color2 As Color
        Dim r As Integer
        Dim g As Integer
        Dim b As Integer
        For x As Integer = 0 To bmp1.Width - 1
            For y As Integer = 0 To bmp1.Height - 1
                Color1 = bmp1.GetPixel(x, y)
                Color2 = bmp2.GetPixel(x, y)
                r = If(Color1.R > Color2.R, Color1.R - Color2.R, Color2.R - Color1.R)
                g = If(Color1.G > Color2.G, Color1.G - Color2.G, Color2.G - Color1.G)
                b = If(Color1.B > Color2.B, Color1.B - Color2.B, Color2.B - Color1.B)
                Image3.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
        Dim Difference As Integer = 0
        Dim Color3 As Color
        Dim Media As Integer
        For x As Integer = 0 To bmp1.Width - 1
            For y As Integer = 0 To bmp1.Height - 1
                Color3 = Image3.GetPixel(x, y)
                Media = (Convert.ToInt32(Color3.R) + Convert.ToInt32(Color3.G) + Convert.ToInt32(Color3.B)) / 3
                If Media > tolerance Then Difference += 1
            Next
        Next
        Dim UsedSize As Double = If(Image1Size > Image2Size, Image2Size, Image1Size)
        Dim result As Double = Difference * 100 / UsedSize
        Return Difference * 100 / UsedSize
    End Function

End Class 'FuncionesBase



Public Class ClaseCargarMaestras
    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter


    Public Function CargarMaestras(ByVal accion As Integer, ByVal IdBase As Integer, _
                                   ByVal Identificador As Int64, ByVal Tipo As Int32, _
                                         Optional ByVal Identificador2 As Int64 = -1) As DataSet

        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.CargarMaestras"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@IdBase", SqlDbType.Int).Value = IdBase
            cmde.Parameters.Add("@Identificador", SqlDbType.BigInt).Value = Identificador
            cmde.Parameters.Add("@Identificador2", SqlDbType.BigInt).Value = Identificador2
            cmde.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = Tipo
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

    Public Function CargarMaestrasHSE(ByVal accion As Integer, ByVal Identificador As Int64, ByVal Tipo As Int32, ByVal Subtipo As Integer) As DataSet
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.CargarMaestrasHSE"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@Identificador", SqlDbType.BigInt).Value = Identificador
            cmde.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = Tipo
            cmde.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
            cmde.Parameters.Add("@Subtipo", SqlDbType.Int).Value = Subtipo
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

    Public Function CargarMaestrasMateriales(ByVal accion As Integer, ByVal IdBodega As Integer, ByVal Identificador As Int64, ByVal Tipo As Int32) As DataSet

        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.CargarMaestrasMateriales"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@IdBodega", SqlDbType.Int).Value = IdBodega
            cmde.Parameters.Add("@Identificador", SqlDbType.BigInt).Value = Identificador
            cmde.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = Tipo
            cmde.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
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

    Public Function CargarMaestrasSiscontrol(ByVal accion As Integer, ByVal IdDependencia As Integer, ByVal Identificador As Int64, ByVal Tipo As Int32) As DataSet

        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.CargarMaestrasSiscontrol"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = accion
            cmde.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia
            cmde.Parameters.Add("@Identificador", SqlDbType.BigInt).Value = Identificador
            cmde.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = Tipo
            cmde.Parameters.Add("@IdPersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
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
