Imports System.IO
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v3
Imports Google.Apis.Drive.v3.Data
Imports Google.Apis.Services
Imports Google.Apis.Upload
Imports Google.Apis.Util.Store
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient

Public Class Fr_BarraDeCarga

    Public Service As DriveService = New DriveService
    Public RutaCarpeta As String
    Public Respuesta As Boolean
    Public Tipo As Integer

    Dim Porcentaje As Double
    Dim SumaPorcentaje As Double
    Dim CantidadTotalArchivos As Integer = 0
    Dim CantidadProcesados As Integer = 0
    Dim NombreArchivoGlobal As String = ""
    Dim ArchivoRutaGlobal As String = ""
    Dim objStreamWriter As StreamWriter

    Dim appPathSubidos As String
    Dim appPathSinSubir As String
    Dim appPathRepetidos As String
    Dim appPathArchivosSubidos As String

    Private Sub Cargado() Handles Me.Shown

        appPathSubidos = RutaCarpeta + "\ArchivosSubidos"
        appPathSinSubir = RutaCarpeta + "\ArchivosSinSubir"
        appPathRepetidos = RutaCarpeta + "\ArchivosRepetidos"
        appPathArchivosSubidos = appPathSubidos + "\ArchivosSubidos.txt"

        If Not Directory.Exists(appPathSubidos) Then
            Directory.CreateDirectory(appPathSubidos)
        End If

        If Not Directory.Exists(appPathSinSubir) Then
            Directory.CreateDirectory(appPathSinSubir)
        End If

        If Not Directory.Exists(appPathRepetidos) Then
            Directory.CreateDirectory(appPathRepetidos)
        End If

        If IO.File.Exists(appPathArchivosSubidos) = True Then
            Try
                If My.Computer.FileSystem.FileExists(appPathArchivosSubidos) Then
                    My.Computer.FileSystem.DeleteFile(appPathArchivosSubidos)
                End If
            Catch ex As Exception
            End Try

            objStreamWriter = New StreamWriter(appPathArchivosSubidos, True)
        Else
            objStreamWriter = New StreamWriter(appPathArchivosSubidos)
        End If
        Pb_ArchivosSubidos.Refresh()
        Bgw_ArchivosSubidos.RunWorkerAsync()
    End Sub

    Private Sub Cerrando() Handles Me.FormClosing
        If Respuesta <> True Then
            If MessageBox.Show("¿Seguro que desea interrumpir el proceso de subir los archivos al servidor?", "Cancelar subida archivos en bloque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Pb_ArchivosSubidos.Refresh()
                objStreamWriter.Close()
                Exit Sub
            End If
        End If
        Pb_ArchivosSubidos.Refresh()
        objStreamWriter.Close()
    End Sub

    Private Sub Cerrado() Handles Me.FormClosed
        Dim sfile As String
        sfile = appPathArchivosSubidos
        Dim psi As New ProcessStartInfo()
        psi.UseShellExecute = True
        psi.FileName = sfile
        Process.Start(psi)
    End Sub

    Public Sub CreateService()
        Dim filestream As System.IO.FileStream
        filestream = New FileStream("SiscontrolDrive-Credentials.json", FileMode.Open, FileAccess.Read)
        Dim scopes As String = DriveService.Scope.Drive
        Dim credencial As GoogleCredential = GoogleCredential.FromStream(filestream).CreateScoped(scopes)
        Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = credencial, .ApplicationName = "SiscontrolDrive"})
    End Sub

    Public Function CargarArchivosEnBloque()

        Dim Archivos() As String = IO.Directory.GetFiles(RutaCarpeta)
        Dim ListaArchivos As String = ""
        Dim ListaNombreArchivos As New List(Of String)

        CantidadTotalArchivos = Archivos.Count
        SumaPorcentaje = 1
        'Dim ListaCarpetaNoSubidos As New List(Of String)
        Dim dtCarpetaArchivosNoSubidos As New DataTable
        dtCarpetaArchivosNoSubidos.Columns.Add("NOMBRE")
        Dim dtCarpetaArchivosSubidos As New DataTable
        dtCarpetaArchivosSubidos.Columns.Add("NOMBRE")
        Dim dtCarpetaArchivosRepetidos As New DataTable
        dtCarpetaArchivosRepetidos.Columns.Add("NOMBRE")

        Dim ArchivosNoSubidos() As String = IO.Directory.GetFiles(appPathSinSubir)
        For Each Archivo As String In ArchivosNoSubidos
            Dim filetype As New IO.FileInfo(Archivo)
            Dim NombreArchivo As String = filetype.Name
            Dim FilaCarpetaArchivosNoSubidos As DataRow
            FilaCarpetaArchivosNoSubidos = dtCarpetaArchivosNoSubidos.NewRow
            dtCarpetaArchivosNoSubidos.Rows.Add(NombreArchivo)
        Next
        Dim CarpetaArchivosSubidos() As String = IO.Directory.GetFiles(appPathSubidos)
        For Each Archivo As String In CarpetaArchivosSubidos
            Dim filetype As New IO.FileInfo(Archivo)
            Dim NombreArchivo As String = filetype.Name
            Dim FilaCarpetaArchivosNoSubidos As DataRow
            FilaCarpetaArchivosNoSubidos = dtCarpetaArchivosSubidos.NewRow
            dtCarpetaArchivosSubidos.Rows.Add(NombreArchivo)
        Next
        Dim CarpetaArchivosRepetidos() As String = IO.Directory.GetFiles(appPathRepetidos)
        For Each Archivo As String In CarpetaArchivosRepetidos
            Dim filetype As New IO.FileInfo(Archivo)
            Dim NombreArchivo As String = filetype.Name
            Dim FilaCarpetaArchivosRepetidos As DataRow
            FilaCarpetaArchivosRepetidos = dtCarpetaArchivosRepetidos.NewRow
            dtCarpetaArchivosRepetidos.Rows.Add(NombreArchivo)
        Next

        'Verificar Repetidos
        For Each Archivo As String In Archivos
            Dim filetype As New IO.FileInfo(Archivo)
            Dim NombreArchivo As String = filetype.Name
            Dim ListaRepetidos() As String = IO.Directory.GetFiles(RutaCarpeta, NombreArchivo.Substring(0, NombreArchivo.Length - 4) + "*.pdf")
            If ListaRepetidos.Length > 1 Then
                For Each ArchivoRepetido As String In ListaRepetidos
                    Dim RutaArchivo As New IO.FileInfo(ArchivoRepetido)
                    Dim dtTemporal() As DataRow = Nothing
                    dtTemporal = dtCarpetaArchivosRepetidos.Select("NOMBRE LIKE '%" + RutaArchivo.Name.Substring(0, RutaArchivo.Name.Length - 4) + "%'")
                    MoverArchivos(appPathRepetidos, RutaArchivo.FullName, dtTemporal, RutaArchivo.Name, Tipo)
                    objStreamWriter.WriteLine("Archivo duplicado: " + RutaArchivo.Name + ". Fecha: " + Today.ToShortDateString)
                    CantidadProcesados += 1
                    Bgw_ArchivosSubidos.ReportProgress(SumaPorcentaje)
                Next
            End If
        Next

        Archivos = Nothing
        Archivos = IO.Directory.GetFiles(RutaCarpeta)

        For Each Archivo As String In Archivos
            Dim filetype As New IO.FileInfo(Archivo)
            Dim NombreArchivo As String = filetype.Name

            'Busco los archivos no compatibles por extension y los muevo de carpeta
            If filetype.Extension.ToLower <> ".pdf" Then
                objStreamWriter.WriteLine("Extension de archivo no compatible, archivo: " + NombreArchivo + ". Fecha: " + Today.ToShortDateString)
                Dim TamañoPalabra As Integer = NombreArchivo.Length - 4
                Dim dtTemporal() As DataRow = Nothing
                Try
                    dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + NombreArchivo.Substring(0, TamañoPalabra) + "%'")
                Catch ex As Exception
                End Try
                MoverArchivos(appPathSinSubir, Archivo, dtTemporal, NombreArchivo, Tipo)
                CantidadProcesados += 1
                Bgw_ArchivosSubidos.ReportProgress(SumaPorcentaje)
            Else
                'Agrego los archivos a una lista
                ListaNombreArchivos.Add(NombreArchivo)
                If Tipo = 1 Then
                    Dim IndicePunto As Integer = NombreArchivo.IndexOf(".")
                    Try
                        NombreArchivo = NombreArchivo.Substring(0, IndicePunto + 10)
                    Catch ex As Exception
                        NombreArchivo = NombreArchivo.Substring(0, NombreArchivo.Length - 4)
                    End Try
                Else
                    If Tipo = 9 Or Tipo = 10 Then
                        NombreArchivo = NombreArchivo.Substring(4, NombreArchivo.Length - 8)
                        'NombreArchivo = NombreArchivo.Substring(0, NombreArchivo.Length - 4)
                    Else
                        NombreArchivo = NombreArchivo.Substring(0, NombreArchivo.Length - 4)
                    End If

                End If
                'Creo el select con los nombres de los archivos a buscar en BD
                ListaArchivos += "SELECT '" + Trim(NombreArchivo) + "' UNION "
            End If
        Next

        ListaArchivos = ListaArchivos.Substring(0, ListaArchivos.Length - 7)

        Dim dsArchivos As New DataSet
        Dim dtArchivosNoEncontradosBD As New DataTable
        Dim dtArchivosEncontrados As New DataTable
        Dim FolderDrive As String = ""
        Try
            Dim cn As New SqlConnection(My.Settings.CadenaConexión)
            Dim cmd As String
            'Tipo 1 -> Requisicion 
            'Tipo 2 -> Orden de Compra
            'Tipo 3 -> Salidas
            'Tipo 4 -> Entradas
            'Tipo 5 -> Relacion Facturas
            'Tipo 6 -> Autorización Seguridad - No se cargara en bloque
            'Tipo 7 -> Correspondencia
            'Tipo 8 -> FAX
            'Tipo 9 -> Cancelacion Requisiciones Parciales y Totales
            'Tipo 10 -> Cancelacion Entradas Almacen Parciales y Totales
            If Tipo = 1 Then
                FolderDrive = "Requisición"
                cmd = "CREATE TABLE #temp(REQUISICION VARCHAR(MAX) COLLATE database_default NOT NULL);"
                cmd += "INSERT INTO #temp "
                cmd += ListaArchivos
                cmd += " SELECT T.REQUISICION FROM #temp AS T EXCEPT SELECT RQ.REQUISICION FROM REQUISICION AS RQ"
                cmd += " SELECT RQ.IDREQUISICION AS ID, RQ.REQUISICION AS DOCUMENTO, RQ.AÑO AS AÑO FROM REQUISICION AS RQ WHERE RQ.REQUISICION IN (SELECT T3.REQUISICION FROM #temp AS T3)"
            Else
                If Tipo = 2 Then
                    FolderDrive = "OrdenCompra"
                    cmd = "CREATE TABLE #temp(ORDENCOMPRA VARCHAR(MAX) COLLATE database_default NOT NULL);"
                    cmd += "INSERT INTO #temp "
                    cmd += ListaArchivos
                    cmd += " SELECT T.ORDENCOMPRA FROM #temp AS T EXCEPT SELECT OC.ORDENCOMPRA FROM ORDENCOMPRA AS OC"
                    cmd += " SELECT OC.IDORDENCOMPRA AS ID, OC.ORDENCOMPRA AS DOCUMENTO, OC.AÑO AS AÑO FROM ORDENCOMPRA AS OC WHERE OC.ORDENCOMPRA IN (SELECT T3.ORDENCOMPRA FROM #temp AS T3)"
                Else
                    If Tipo = 3 Then
                        FolderDrive = "SalidaAlmacén"
                        cmd = "CREATE TABLE #temp(SALIDAALMACEN VARCHAR(MAX) COLLATE database_default NOT NULL);"
                        cmd += "INSERT INTO #temp "
                        cmd += ListaArchivos
                        cmd += " SELECT T.SALIDAALMACEN FROM #temp AS T EXCEPT SELECT SA.SALIDAALMACEN FROM SALIDAALMACEN AS SA"
                        cmd += " SELECT SA.IDSALIDAALMACEN AS ID, SA.SALIDAALMACEN AS DOCUMENTO, SA.AÑO AS AÑO FROM SALIDAALMACEN AS SA WHERE SA.SALIDAALMACEN IN (SELECT T3.SALIDAALMACEN FROM #temp AS T3)"
                    Else
                        If Tipo = 4 Then
                            FolderDrive = "EntradaAlmacén"
                            cmd = "CREATE TABLE #temp(ENTRADAALMACEN VARCHAR(MAX) COLLATE database_default NOT NULL);"
                            cmd += "INSERT INTO #temp "
                            cmd += ListaArchivos
                            cmd += " SELECT T.ENTRADAALMACEN FROM #temp AS T EXCEPT SELECT EA.ENTRADAALMACEN FROM ENTRADAALMACEN AS EA"
                            cmd += " SELECT EA.IDENTRADAALMACEN AS ID, EA.ENTRADAALMACEN AS DOCUMENTO, EA.AÑO AS AÑO FROM ENTRADAALMACEN AS EA WHERE EA.ENTRADAALMACEN IN (SELECT T3.ENTRADAALMACEN FROM #temp AS T3)"
                        Else
                            If Tipo = 5 Then
                                FolderDrive = "RelacionFactura"
                                cmd = "CREATE TABLE #temp(RELACIONDOCUMENTO VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                cmd += "INSERT INTO #temp "
                                cmd += ListaArchivos
                                cmd += " SELECT T.RELACIONDOCUMENTO FROM #temp AS T EXCEPT SELECT RD.AÑO+RD.MES+RD.CONSECUTIVO  FROM CC_RELACIONDOCUMENTO AS RD"
                                cmd += " SELECT RD.IDRELACIONDOCUMENTO AS ID, RD.AÑO+RD.MES+RD.CONSECUTIVO AS DOCUMENTO, RD.AÑO AS AÑO FROM CC_RELACIONDOCUMENTO AS RD WHERE RD.AÑO+RD.MES+RD.CONSECUTIVO IN (SELECT T3.RELACIONDOCUMENTO FROM #temp AS T3)"
                            Else
                                If Tipo = 7 Then
                                    FolderDrive = "Correspondencia"
                                    cmd = "CREATE TABLE #temp(DOCUMENTO VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                    cmd += "INSERT INTO #temp "
                                    cmd += ListaArchivos
                                    cmd += " SELECT T.DOCUMENTO FROM #temp AS T EXCEPT SELECT C.DOCUMENTO  FROM SC_CORRESPONDENCIA AS C"
                                    cmd += " SELECT C.IDCORRESPONDENCIAEXTERNA AS ID, C.DOCUMENTO AS DOCUMENTO, C.AÑO AS AÑO FROM SC_CORRESPONDENCIA AS C WHERE C.DOCUMENTO IN (SELECT T3.DOCUMENTO FROM #temp AS T3)"
                                Else
                                    If Tipo = 8 Then
                                        FolderDrive = "Fax"
                                        cmd = "CREATE TABLE #temp(DOCUMENTO VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                        cmd += "INSERT INTO #temp "
                                        cmd += ListaArchivos
                                        cmd += " SELECT T.DOCUMENTO FROM #temp AS T EXCEPT SELECT C.DOCUMENTO  FROM SC_CORRESPONDENCIA AS C"
                                        cmd += " SELECT C.IDCORRESPONDENCIAEXTERNA AS ID, C.DOCUMENTO AS DOCUMENTO, C.AÑO AS AÑO FROM SC_CORRESPONDENCIA AS C WHERE C.DOCUMENTO IN (SELECT T3.DOCUMENTO FROM #temp AS T3)"
                                    Else
                                        If Tipo = 9 Then
                                            FolderDrive = "Requisición"
                                            cmd = "CREATE TABLE #temp(REQUISICION VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                            cmd += "INSERT INTO #temp "
                                            cmd += ListaArchivos
                                            cmd += "CREATE TABLE #temp2(REQUISICION VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                            cmd += "INSERT INTO #temp2 "
                                            cmd += " SELECT T.REQUISICION FROM #temp AS T EXCEPT SELECT RQ.REQUISICION FROM REQUISICION AS RQ;"
                                            cmd += " SELECT T.REQUISICION FROM #temp2 AS T EXCEPT SELECT RQ.REQUISICION FROM CAN_REQUISICION AS RQ"
                                            cmd += " SELECT RQ.IDREQUISICION AS ID, RQ.REQUISICION AS DOCUMENTO, RQ.AÑO AS AÑO, 'P' AS TIPOCANCELACION FROM REQUISICION AS RQ WHERE RQ.REQUISICION IN (SELECT T3.REQUISICION FROM #temp AS T3)"
                                            cmd += " UNION"
                                            cmd += " SELECT RQ.IDREQUISICION AS ID, RQ.REQUISICION AS DOCUMENTO, RQ.AÑO AS AÑO, 'T' AS TIPOCANCELACION FROM CAN_REQUISICION AS RQ WHERE RQ.REQUISICION IN (SELECT T3.REQUISICION FROM #temp2 AS T3)"
                                        Else
                                            If Tipo = 10 Then
                                                FolderDrive = "EntradaAlmacén"
                                                cmd = "CREATE TABLE #temp(ENTRADAALMACEN VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                                cmd += " INSERT INTO #temp "
                                                cmd += ListaArchivos
                                                cmd += " CREATE TABLE #temp2(ENTRADAALMACEN VARCHAR(MAX) COLLATE database_default NOT NULL);"
                                                cmd += " INSERT INTO #temp2 "
                                                cmd += " SELECT T.ENTRADAALMACEN FROM #temp AS T EXCEPT SELECT EA.ENTRADAALMACEN FROM ENTRADAALMACEN AS EA;"
                                                cmd += " SELECT T.ENTRADAALMACEN FROM #temp2 AS T EXCEPT SELECT EA.ENTRADAALMACEN FROM CAN_ENTRADAALMACEN AS EA"
                                                cmd += " SELECT EA.IDENTRADAALMACEN AS ID, EA.ENTRADAALMACEN AS DOCUMENTO, EA.AÑO AS AÑO, 'P' AS TIPOCANCELACION FROM ENTRADAALMACEN AS EA WHERE EA.ENTRADAALMACEN IN (SELECT T3.ENTRADAALMACEN FROM #temp AS T3)"
                                                cmd += " UNION"
                                                cmd += " SELECT EA.IDENTRADAALMACEN AS ID, EA.ENTRADAALMACEN AS DOCUMENTO, EA.AÑO AS AÑO, 'T' AS TIPOCANCELACION FROM CAN_ENTRADAALMACEN AS EA WHERE EA.ENTRADAALMACEN IN (SELECT T3.ENTRADAALMACEN FROM #temp2 AS T3)"
                                            Else
                                                objStreamWriter.WriteLine("Error al seleccionar la carpeta donde se subiran los archivos. Fecha: " + Today.ToShortDateString)
                                                Return False
                                                Exit Function
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            Dim da As New SqlDataAdapter(cmd, cn)
            da.Fill(dsArchivos)
        Catch ex As Exception
        End Try
        If dsArchivos.Tables.Count > 0 Then
            dtArchivosNoEncontradosBD = dsArchivos.Tables(0)
            dtArchivosEncontrados = dsArchivos.Tables(1)
        Else
            objStreamWriter.WriteLine("No se encontro ningun archivo. Fecha: " + Today.ToShortDateString)
            'objStreamWriter.Close()
            'Me.Close()
            Respuesta = False
            Me.Close()
            Return False
            Exit Function
        End If

        'Proceso para mover los archivos NO encontrados
        For i As Integer = 0 To dtArchivosNoEncontradosBD.Rows.Count - 1
            Dim RutaArchivo As String
            Dim ArchivoBuscarNBD As String = ""
            If Tipo = 9 Or Tipo = 10 Then
                ArchivoBuscarNBD = "CAN_" + dtArchivosNoEncontradosBD.Rows(i).Item(0).ToString() '+ ".pdf"
            Else
                ArchivoBuscarNBD = dtArchivosNoEncontradosBD.Rows(i).Item(0).ToString() '+ ".pdf"
            End If

            Dim NombreBuscar As String = ""
            NombreBuscar = ListaNombreArchivos.Find(Function(x) x.Contains(ArchivoBuscarNBD))
            Dim ListaNombresSemiIguales As List(Of String) = ListaNombreArchivos.FindAll(Function(x) x.Contains(ArchivoBuscarNBD))
            If ListaNombresSemiIguales.Count > 1 Then
                Dim Todos = Directory.GetFiles(RutaCarpeta, ArchivoBuscarNBD + "*.pdf").OrderByDescending(Function(f) New FileInfo(f).CreationTime).ToList
                For Each Archivo In Todos
                    RutaArchivo = Archivo
                    Dim dtTemporal() As DataRow = Nothing
                    Dim Nombre As String = New IO.FileInfo(Archivo).Name.ToString
                    Try
                        dtTemporal = dtCarpetaArchivosRepetidos.Select("NOMBRE LIKE '%" + Nombre.Substring(0, Nombre.Length - 4) + "%'")
                    Catch ex As Exception
                    End Try
                    MoverArchivos(appPathRepetidos, RutaArchivo, dtTemporal, Nombre, Tipo)
                    objStreamWriter.WriteLine("Archivo duplicado y No encontrado en base de datos: " + Nombre + ". Fecha: " + Today.ToShortDateString)
                    CantidadProcesados += 1
                    Bgw_ArchivosSubidos.ReportProgress(SumaPorcentaje)
                Next
            Else
                If NombreBuscar <> "" Then
                    RutaArchivo = RutaCarpeta + "\" + NombreBuscar
                    objStreamWriter.WriteLine("Archivo no encontrado en Base de Datos: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)
                    Dim TamañoPalabra As Integer = ArchivoBuscarNBD.Length '- 4
                    Dim dtTemporal() As DataRow = Nothing
                    Try
                        dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscarNBD.Substring(0, TamañoPalabra) + "%'")
                    Catch ex As Exception
                    End Try
                    MoverArchivos(appPathSinSubir, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                    CantidadProcesados += 1
                    Bgw_ArchivosSubidos.ReportProgress(SumaPorcentaje)
                End If
            End If
        Next

        'Proceso para subir los archivos encontrados
        Dim ListaArchivo As Object
        For i As Integer = 0 To dtArchivosEncontrados.Rows.Count - 1
            Dim ArchivoBuscar As String = Nothing

            If Tipo = 9 Or Tipo = 10 Then
                ArchivoBuscar = "CAN_" + Trim(dtArchivosEncontrados.Rows(i).Item("DOCUMENTO").ToString)
            Else
                ArchivoBuscar = Trim(dtArchivosEncontrados.Rows(i).Item("DOCUMENTO").ToString)
            End If
            Dim Año As String = dtArchivosEncontrados.Rows(i).Item("AÑO").ToString

            'FolderDrive = "Pruebas" 'Comentar luego de hacer pruebas 

            ListaArchivo = ListarArchivosEnCarpetaDrive(FolderDrive, Año, ArchivoBuscar)
            Dim RutaArchivo As String = ""
            Dim IdArchivo As Integer = dtArchivosEncontrados.Rows(i).Item("ID")
            'ArchivoBuscar += ".pdf"
            Dim NombreBuscar As String = ""
            NombreBuscar = ListaNombreArchivos.Find(Function(x) x.Contains(ArchivoBuscar))
            Dim ListaNombresSemiIguales As List(Of String) = ListaNombreArchivos.FindAll(Function(x) x.Contains(ArchivoBuscar))
            If ListaNombresSemiIguales.Count > 1 Then
                Dim Ultimo = Directory.GetFiles(RutaCarpeta, ArchivoBuscar + "*.pdf").OrderByDescending(Function(f) New FileInfo(f).CreationTime).First()
                Dim Todos = Directory.GetFiles(RutaCarpeta, ArchivoBuscar + "*.pdf").OrderByDescending(Function(f) New FileInfo(f).CreationTime).ToList
                Todos.RemoveAt(Todos.IndexOf(Ultimo))
                NombreBuscar = New IO.FileInfo(Ultimo).Name.ToString

                For Each Archivo In Todos
                    RutaArchivo = Archivo
                    Dim dtTemporal() As DataRow = Nothing
                    Dim Nombre As String = New IO.FileInfo(Archivo).Name.ToString
                    Try
                        dtTemporal = dtCarpetaArchivosRepetidos.Select("NOMBRE LIKE '%" + Nombre.Substring(0, Nombre.Length - 4) + "%'")
                    Catch ex As Exception
                    End Try
                    MoverArchivos(appPathRepetidos, RutaArchivo, dtTemporal, Nombre, Tipo)
                    objStreamWriter.WriteLine("Archivo duplicado: " + Nombre + ". Fecha: " + Today.ToShortDateString)
                    CantidadProcesados += 1
                    Bgw_ArchivosSubidos.ReportProgress(SumaPorcentaje)
                Next
            End If

            If NombreBuscar <> "" Then
                RutaArchivo = RutaCarpeta + "\" + NombreBuscar 'ArchivoBuscar
            Else
                objStreamWriter.WriteLine("Archivo no encontrado en la carpeta al momento de subirlo: " + ArchivoBuscar + ".pdf . Fecha: " + Today.ToShortDateString)
            End If
            CreateService()
            If ListaArchivo(0) = 1 Then
                'El archivo no existe, se va a crear
                Dim CarpetaDrive As FileList = ListaArchivo(1)
                Dim response3 = CargarArchivo(Service, RutaArchivo, CarpetaDrive.Files(0).Id, ArchivoBuscar + ".pdf", Año)
                If response3 = True Then
                    Cursor.Current = Cursors.Default
                    'Modificar subido servidor bd
                    If Tipo = 9 Then
                        Dim TipoCancelacion As String = dtArchivosEncontrados.Rows(i).Item("TIPOCANCELACION")
                        Dim TipoArchivo As Integer = 0
                        If TipoCancelacion = "T" Then
                            TipoArchivo = 9
                        Else
                            TipoArchivo = 1
                        End If
                        MarcarSubidoServidor(TipoArchivo, IdArchivo)
                    Else
                        If Tipo = 10 Then
                            Dim TipoCancelacion As String = dtArchivosEncontrados.Rows(i).Item("TIPOCANCELACION")
                            Dim TipoArchivo As Integer = 0
                            If TipoCancelacion = "T" Then
                                TipoArchivo = 12
                            Else
                                TipoArchivo = 1
                            End If
                            MarcarSubidoServidor(TipoArchivo, IdArchivo)
                        Else
                            MarcarSubidoServidor(Tipo, IdArchivo)
                        End If
                    End If

                    objStreamWriter.WriteLine("Se subió el archivo: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)
                    Dim ListaCarpetaSubidosTemp As New List(Of String)
                    Dim TamañoPalabra As Integer = ArchivoBuscar.Length '- 4
                    Dim dtTemporal() As DataRow = Nothing
                    Try
                        dtTemporal = dtCarpetaArchivosSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                    Catch ex As Exception
                    End Try
                    Dim Nombre As String = Trim(dtArchivosEncontrados.Rows(i).Item("DOCUMENTO").ToString)
                    MoverArchivos(appPathSubidos, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                Else
                    objStreamWriter.WriteLine("No se pudo subir el archivo: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)
                    Cursor.Current = Cursors.Default
                    Dim TamañoPalabra As Integer = ArchivoBuscar.Length - 4
                    Dim dtTemporal() As DataRow = Nothing
                    Try
                        dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                    Catch ex As Exception
                    End Try
                    Dim Nombre As String = Trim(dtArchivosEncontrados.Rows(i).Item("DOCUMENTO").ToString)
                    MoverArchivos(appPathSubidos, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                End If
            Else
                If ListaArchivo(0) = 2 Then
                    'El archivo ya existe, se debe calcular la letra y cargar el archivo
                    Dim CarpetaDrive As FileList = ListaArchivo(1)
                    Dim NombreArchivoLetra As String = ""
                    If Tipo = 9 Or Tipo = 10 Then
                        NombreArchivoLetra = "CAN_" + Trim(dtArchivosEncontrados.Rows(i).Item("DOCUMENTO").ToString)
                    Else
                        NombreArchivoLetra = Trim(dtArchivosEncontrados.Rows(i).Item("DOCUMENTO").ToString)
                    End If

                    Dim ResultadoArchivosDrive As FileList = ListaArchivo(2)
                    Dim funcionCalcularLetra As Object = CalcularLetra(ResultadoArchivosDrive, NombreArchivoLetra)
                    Dim Letra As String = ""

                    If Trim(funcionCalcularLetra(0)) <> "" Then
                        Letra = funcionCalcularLetra(0)
                        Dim CambiarNombreOk As Boolean

                        CambiarNombreOk = CambiarNombreArchivo(Service, CarpetaDrive.Files(0).Id, NombreArchivoLetra, Letra, ".pdf")
                        If CambiarNombreOk Then
                            NombreArchivoLetra = NombreArchivoLetra + ".pdf"
                            Dim response3 = CargarArchivo(Service, RutaArchivo, CarpetaDrive.Files(0).Id, NombreArchivoLetra, Año)
                            If Not response3 Is Nothing Then
                                Cursor.Current = Cursors.Default
                                'Modificar subido servidor bd
                                If Tipo = 9 Then
                                    Dim TipoCancelacion As String = dtArchivosEncontrados.Rows(i).Item("TIPOCANCELACION")
                                    Dim TipoArchivo As Integer = 0
                                    If TipoCancelacion = "T" Then
                                        TipoArchivo = 9
                                    Else
                                        TipoArchivo = 1
                                    End If
                                    MarcarSubidoServidor(TipoArchivo, IdArchivo)
                                Else
                                    If Tipo = 10 Then
                                        Dim TipoCancelacion As String = dtArchivosEncontrados.Rows(i).Item("TIPOCANCELACION")
                                        Dim TipoArchivo As Integer = 0
                                        If TipoCancelacion = "T" Then
                                            TipoArchivo = 12
                                        Else
                                            TipoArchivo = 1
                                        End If
                                        MarcarSubidoServidor(TipoArchivo, IdArchivo)
                                    Else
                                        MarcarSubidoServidor(Tipo, IdArchivo)
                                    End If
                                End If
                                objStreamWriter.WriteLine("Se subió el archivo: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)

                                Dim ListaCarpetaSubidosTemp As New List(Of String)
                                Dim TamañoPalabra As Integer = ArchivoBuscar.Length '- 4
                                Dim dtTemporal() As DataRow = Nothing
                                Try
                                    dtTemporal = dtCarpetaArchivosSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                                Catch ex As Exception
                                End Try
                                MoverArchivos(appPathSubidos, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                            Else
                                objStreamWriter.WriteLine("No se pudo subir el archivo: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)
                                Dim TamañoPalabra As Integer = ArchivoBuscar.Length - 4
                                Dim dtTemporal() As DataRow = Nothing
                                Try
                                    dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                                Catch ex As Exception
                                End Try
                                MoverArchivos(appPathSinSubir, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                            End If
                        Else
                            objStreamWriter.WriteLine("No se pudo sobreescribir el archivo: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)
                            Dim TamañoPalabra As Integer = ArchivoBuscar.Length '- 4
                            Dim dtTemporal() As DataRow = Nothing
                            Try
                                dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                            Catch ex As Exception
                            End Try
                            MoverArchivos(appPathSinSubir, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                        End If
                    Else
                        'Error al calcular la letra para el cambio de nombre de los archivos
                        objStreamWriter.WriteLine("No se pudo sobreescribir el archivo: " + NombreBuscar + ". Error al calcular el consecutivo. Fecha: " + Today.ToShortDateString)
                        Dim TamañoPalabra As Integer = ArchivoBuscar.Length - 4
                        Dim dtTemporal() As DataRow = Nothing
                        Try
                            dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                        Catch ex As Exception
                        End Try
                        MoverArchivos(appPathSinSubir, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                    End If
                Else
                    If ListaArchivo(0) = 0 Then
                        'Error
                        objStreamWriter.WriteLine("No se encontro la carpeta principal al momento de subir el archivo: " + NombreBuscar + ". Fecha: " + Today.ToShortDateString)
                        Dim TamañoPalabra As Integer = ArchivoBuscar.Length '- 4
                        Dim dtTemporal() As DataRow = Nothing
                        Try
                            dtTemporal = dtCarpetaArchivosNoSubidos.Select("NOMBRE LIKE '%" + ArchivoBuscar.Substring(0, TamañoPalabra) + "%'")
                        Catch ex As Exception
                        End Try
                        MoverArchivos(appPathSinSubir, RutaArchivo, dtTemporal, NombreBuscar, Tipo)
                    End If
                End If
            End If
            Service.Dispose()
            CantidadProcesados += 1
            Bgw_ArchivosSubidos.ReportProgress(SumaPorcentaje)
        Next
        MsgBox("Se han movido los archivos a otras carpetas." & vbNewLine & "Carpeta de archivos sin subir: " + appPathSinSubir & vbNewLine & " y " & vbNewLine & "Carpeta de archivos subidos: " + appPathSubidos, MsgBoxStyle.Information, "Archivos movidos")
        Return True
    End Function

    Public Sub MoverArchivos(RutaCarpeta As String, RutaArchivo As String, dtTemporal() As DataRow, NombreOriginal As String, Tipo As Integer)
        'RutaCarpeta - Ruta de la carpeta donde se encuentra el archivo
        'RutaArchivo - Ruta de la carpeta donde se encuentra el archivo junto con el nombre del archivo
        'dtTemporal() - Lista de archivos con nombre similar si los hay
        'NombreOriginal - Nombre del archivo que se movera o cambiara el nombre
        Try
            Dim Letra As Object
            If IO.File.Exists(RutaCarpeta + "\" + NombreOriginal) = True Then
                Dim NuevoNombre As String = NombreOriginal.Substring(0, NombreOriginal.Length - 4)
                Dim ExtensionArchivo As New IO.FileInfo(NombreOriginal)
                Letra = CalcularLetraLocales(dtTemporal, NombreOriginal)
                My.Computer.FileSystem.RenameFile(RutaCarpeta + "\" + NombreOriginal, NuevoNombre + "-" + Letra(0) + ExtensionArchivo.Extension.ToLower.ToString)
            End If
            My.Computer.FileSystem.MoveFile(RutaArchivo, RutaCarpeta + "\" + NombreOriginal)
        Catch ex As Exception
        End Try
    End Sub

    Public Function ListarArchivosEnCarpetaDrive(CarpetaDrive As String, Año As String, Archivo As String) As Object
        CreateService()
        Cursor.Current = Cursors.WaitCursor
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)

        Dim foldersrequest As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest.SupportsAllDrives = True
        foldersrequest.IncludeItemsFromAllDrives = True
        foldersrequest.Q = "mimeType = 'application/vnd.google-apps.folder' and name='" + CarpetaDrive + "'"
        'En response obtengo la lista de carpetas que coincidan con el string CarpetaDrive
        Dim response As FileList
        Try
            response = foldersrequest.Execute()
        Catch ex As Exception
            'Error inesperado
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Or response.Files.Count = 0 Then
            'No se encontro la carpeta principal
            Return {0}
        End If

        Dim foldersrequest2 As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest2.SupportsAllDrives = True
        foldersrequest2.IncludeItemsFromAllDrives = True
        'Con el mimeType busco el tipo de archivo que sea tipo folder o carpeta y con el name del respectivo año y que este la carpeta correspondencia con su Id e in parents
        foldersrequest2.Q = "mimeType = 'application/vnd.google-apps.folder' and '" + response.Files(0).Id + "' in parents  and name='" + Año + "'"
        Dim response2 As FileList
        Try
            response2 = foldersrequest2.Execute()
        Catch ex As Exception
            'Error inesperado
            Return Nothing
            Exit Function
        End Try

        If response2 Is Nothing Or response2.Files.Count = 0 Then
            'No se encontro la subcarpeta
            Return {0}
            Exit Function
        End If
        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True
        'listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name = '" + Archivo + "'"
        listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name contains '" + Archivo + "'"
        listrequest.Fields = "nextPageToken, files(id, name)"

        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            'Se devuelve la subcarpeta
            Service.Dispose()
            Return {1, response2}
            Exit Function
        End Try
        If result.Files.Count = 0 Then
            'No se encontraron coincidencias se devuelve la subcarpeta
            Service.Dispose()
            Return {1, response2}
        Else
            'Se encontraron coincidencias, se devuelve la subcarpeta y el listado de arhivos en ella que coinciden con el nombre del archivo buscado
            Service.Dispose()
            Return {2, response2, result}
        End If
    End Function

    Public Function CalcularLetra(Lista As FileList, ByVal Archivo As String) As Object
        Dim ErrorLetra As Integer = 0 ' 0 -> Correcto, 1 --> No hay mas consecutivos, 2--> Inesperado
        Dim Palabra As String = ""
        Dim NumeroLetra As Integer = 0
        Dim Letra As String = ""
        Dim LetraMayor As Integer = 0
        For i As Integer = 0 To Lista.Files.Count - 1
            Palabra = Lista.Files(i).Name
            If Palabra(Palabra.Length - 6) = "-" Then
                If Asc(Palabra(Palabra.Length - 5)) > LetraMayor Then
                    LetraMayor = Asc(Palabra(Palabra.Length - 5))
                End If
            End If
        Next
        If LetraMayor = 90 Then
            'MsgBox("Consecutivo lleno para el documento " + Archivo + ", no se pueden subir mas archivos", MsgBoxStyle.Information, "Archivo lleno")
            Letra = Convert.ToChar(LetraMayor)
            ErrorLetra = 1
            Return {Letra, LetraMayor, ErrorLetra}
            Exit Function
        End If
        If LetraMayor > 64 AndAlso LetraMayor < 90 Then
            Letra = Convert.ToChar(LetraMayor + 1)
        Else
            If LetraMayor = 0 Then
                Letra = Convert.ToChar(65)
            Else
                'MsgBox("Error al calcular el consecutivo para el documento " + Archivo + ", no se pudo subir el archivo", MsgBoxStyle.Information, "No se cargó el archivo")
                ErrorLetra = 2
                Return {"", LetraMayor, ErrorLetra}
                Exit Function
            End If
        End If
        Return {Letra, LetraMayor, ErrorLetra}
    End Function

    Public Function CalcularLetraLocales(Lista As DataRow(), ByVal Archivo As String) As Object
        Dim ErrorLetra As Integer = 0 ' 0 -> Correcto, 1 --> No hay mas consecutivos, 2--> Inesperado
        Dim Palabra As String = ""
        Dim NumeroLetra As Integer = 0
        Dim Letra As String = ""
        Dim LetraMayor As Integer = 0
        For i As Integer = 0 To Lista.Count - 1
            Palabra = Lista(i).Item(0).ToString
            If Palabra(Palabra.Length - 6) = "-" Then
                If Asc(Palabra(Palabra.Length - 5)) > LetraMayor Then
                    LetraMayor = Asc(Palabra(Palabra.Length - 5))
                End If
            End If
        Next
        If LetraMayor = 90 Then
            'MsgBox("Consecutivo lleno para el documento " + Archivo + ", no se pueden subir mas archivos", MsgBoxStyle.Information, "Archivo lleno")
            Letra = Convert.ToChar(LetraMayor)
            ErrorLetra = 1
            Return {Letra, LetraMayor, ErrorLetra}
            Exit Function
        End If
        If LetraMayor > 64 AndAlso LetraMayor < 90 Then
            Letra = Convert.ToChar(LetraMayor + 1)
        Else
            If LetraMayor = 0 Then
                Letra = Convert.ToChar(65)
            Else
                'MsgBox("Error al calcular el consecutivo para el documento " + Archivo + ", no se pudo subir el archivo", MsgBoxStyle.Information, "No se cargó el archivo")
                ErrorLetra = 2
                Return {"", LetraMayor, ErrorLetra}
                Exit Function
            End If
        End If
        Return {Letra, LetraMayor, ErrorLetra}
    End Function

    Public Function CambiarNombreArchivo(service As Google.Apis.Drive.v3.DriveService, IdPadre As String, NombreArchivo As String, Letra As String, Extension As String) As Boolean
        Dim listrequest As FilesResource.ListRequest = service.Files.List()
        Dim fileID As String = ""
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True
        listrequest.Q = "'" + IdPadre + "' in parents and name = '" + NombreArchivo + Extension + "'"
        listrequest.Fields = "nextPageToken, files(id, name)"

        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            'Error al cargar el archivo antiguo
            Return False
            Exit Function
        End Try

        fileID = result.Files(0).Id

        Dim archivoDrive As Google.Apis.Drive.v3.Data.File = result.Files(0)
        archivoDrive.Name = NombreArchivo + "-" + Letra + Extension + ""
        archivoDrive.Id = Nothing
        Dim request As FilesResource.UpdateRequest = service.Files.Update(archivoDrive, fileID)
        request.SupportsAllDrives = True
        request.SupportsTeamDrives = True
        request.Fields = "id, name, thumbnailLink"
        Try
            request.Execute()
        Catch ex As Exception
            'Error al cambiar el nombre del archivo
            Return False
            Exit Function
        End Try
        'Cambio de nombre correcto
        Return True
    End Function

    Public Function CargarArchivo(service As Google.Apis.Drive.v3.DriveService, RutaArchivo As String, IdPadre As String, NombreArchivo As String, Optional Año As String = "")
        'CreateService()
        If (System.IO.File.Exists(RutaArchivo)) Then
            Dim body As Google.Apis.Drive.v3.Data.File = New Google.Apis.Drive.v3.Data.File
            body.Name = NombreArchivo
            body.Description = "Subido por: " + VariablesBase.VariablesBase.Nombre_Usuario.ToString

            Dim filetype As New IO.FileInfo(NombreArchivo)
            If filetype.Extension.ToLower = ".pdf" Then
                body.MimeType = "application/pdf"
            Else
                If filetype.Extension.ToLower = ".jpg" Then
                    body.MimeType = "image/jpeg"
                End If
            End If

            Dim filetype2 As New IO.FileInfo(RutaArchivo)
            Dim TamañoArchivo As Double = filetype2.Length

            body.Parents = New List(Of String)(New String() {IdPadre})
            Dim stream As System.IO.FileStream
            stream = New FileStream(RutaArchivo, FileMode.Open, FileAccess.Read)
            Try
                Dim request As FilesResource.CreateMediaUpload = service.Files.Create(body, stream, body.MimeType)
                request.SupportsTeamDrives = True
                request.SupportsAllDrives = True
                request.ChunkSize = 1000000
                request.Upload()
                If request.GetProgress.Status = UploadStatus.Completed Then
                    stream.Close()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                'Error inesperado al cargar el archivo
                stream.Close()
                Return Nothing
            End Try
        Else
            'Archivo no encontrado
            Return Nothing
        End If
    End Function

    Public Sub MarcarSubidoServidor(Tipo As Integer, Id As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        'Dim conexion As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Dim comando As New SqlCommand("dbo.MarcarSubidoServidor_Requisicion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", Tipo)
        comando.Parameters.AddWithValue("@ID", Id)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Bgw_ArchivosSubidos_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Bgw_ArchivosSubidos.ProgressChanged
        Pb_ArchivosSubidos.Minimum = 0
        Pb_ArchivosSubidos.Maximum = CantidadTotalArchivos
        Pb_ArchivosSubidos.Value += SumaPorcentaje
        Pb_ArchivosSubidos.Refresh()
        Lb_ArchivosSubidos.Text = "Archivos procesados: " + CantidadProcesados.ToString + " de " + CantidadTotalArchivos.ToString
        If Pb_ArchivosSubidos.Value = CantidadTotalArchivos Then
            Respuesta = True
            Me.Close()
        End If
    End Sub

    Private Sub Bgw_ArchivosSubidos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bgw_ArchivosSubidos.DoWork
        CargarArchivosEnBloque()
    End Sub

    Private Sub Bgw_ArchivosSubidos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bgw_ArchivosSubidos.RunWorkerCompleted
    End Sub

End Class