Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v3
Imports Google.Apis.Drive.v3.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient
Imports Google.Apis.Upload

Public Class FuncionesGoogle
    Public Service As DriveService = New DriveService
    Dim ArchivoRuta As String
    Public Sub CreateService()
        'Ignorar este procedimiento cuando se esta depurando
        Dim filestream As System.IO.FileStream
        filestream = New FileStream("SiscontrolDrive-Credentials.json", FileMode.Open, FileAccess.Read)
        Dim scopes As String = DriveService.Scope.Drive
        Dim credencial As GoogleCredential = GoogleCredential.FromStream(filestream).CreateScoped(scopes)
        Service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = credencial, .ApplicationName = "SiscontrolDrive"})
    End Sub

    Public Sub CrearFolder(CarpetaDrive As String, SubCarpetaDrive As String)
        CreateService()
        Dim IdPadre As String
        'CarpetaDrive -> Nombre de la carpeta donde se va a crear el folder
        'SubCarpetaDrive -> Nombre de la Subcarpeta donde se va a crear el folder
        Dim foldersrequest As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest.SupportsAllDrives = True
        foldersrequest.IncludeItemsFromAllDrives = True
        foldersrequest.Q = "mimeType = 'application/vnd.google-apps.folder' and name='" + CarpetaDrive + "'"
        'En response obtengo la lista de carpetas que coincidan con el string CarpetaDrive
        Dim response = foldersrequest.Execute()

        IdPadre = response.Files(0).Id
        Dim Folder As New Google.Apis.Drive.v3.Data.File
        Folder.Name = SubCarpetaDrive  'Nombre que se le pondra al folder
        Folder.Parents = New List(Of String)(New String() {IdPadre})
        Folder.MimeType = "application/vnd.google-apps.folder"
        Try
            Dim request As FilesResource.CreateRequest = Service.Files.Create(Folder)
            request.SupportsTeamDrives = True
            request.SupportsAllDrives = True
            request.Execute()
        Catch ex As Exception
            MsgBox(ex.Message, "Ocurrio un error al cargar el archivo")
        End Try
    End Sub

    Public Function ContarArchivosEnCarpetasDrive(CarpetaDrive As String, Año As String) As String
        'Esta funcion retorna un string con la cantidad de archivos que fueron subidos a una subcarpeta especifica del google drive 
        'Primero crear un array Dim ArrayCantidadArchivos As New List(Of String)
        'Luego llamar la funcion añadiendo inmedeiatamente su valor al array
        'ArrayCantidadArchivos.Add(GoogleDrive.ContarArchivosEnCarpetasDrive("Requisición", "2022"))
        'ArrayCantidadArchivos.Add(GoogleDrive.ContarArchivosEnCarpetasDrive("Requisición", "2021"))
        'Finalmente pasar el array a la funcion CrearTxtConCantidadArchivos(ArrayCantidadArchivos)
        CreateService()
        Cursor.Current = Cursors.WaitCursor

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
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Or response.Files.Count = 0 Then
            Return Nothing
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
            Return Nothing
            Exit Function
        End Try

        If response2 Is Nothing Or response2.Files.Count = 0 Then
            Return Nothing
            Exit Function
        End If
        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True
        listrequest.Q = "'" + response2.Files(0).Id + "' in parents"
        listrequest.Fields = "nextPageToken, files(id, name)"
        listrequest.PageSize = 1000

        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            Return Nothing
            Exit Function
        End Try
        If result.Files.Count = 0 Then
            Return Nothing
        Else
            Dim CantidadArchivos As Integer = 0
            While result.Files.Count > 0
                CantidadArchivos += result.Files.Count
                If (result.NextPageToken Is Nothing) Then
                    Exit While
                End If
                listrequest.PageToken = result.NextPageToken
                result = listrequest.Execute
            End While
            Return "Carpeta: " + CarpetaDrive + ", Año: " + Año + ", Cantidad de archivos: " + CantidadArchivos.ToString + ". Fecha verificación: " + Today.Date.ToString
        End If
    End Function

    Public Function ListarArchivosEnCarpetasDrive(CarpetaDrive As String) As List(Of String)
        'Esta funcion devuelve una lista de strings con los nombres de los archivos que fueron subidos a una carpeta especifica del google drive 
        'Se puede usar de la siguiente forma para luego usar la funcion de creartxt
        'Dim Archivos As New List(Of String)
        'Archivos.AddRange(GoogleDrive.ListarArchivosEnCarpetasDrive("FacturaciónElectrónica"))
        'GoogleDrive.CrearTxtConArchivos(Archivos,"Facturacion")
        Dim Archivos As New List(Of String)
        CreateService()
        Cursor.Current = Cursors.WaitCursor

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
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Or response.Files.Count = 0 Then
            Return Nothing
        End If

        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True
        listrequest.Q = "'" + response.Files(0).Id + "' in parents"
        listrequest.Fields = "nextPageToken, files(id, name)"
        listrequest.PageSize = 1000

        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            Return Nothing
            Exit Function
        End Try
        If result.Files.Count = 0 Then
            Return Nothing
        Else
            'Dim CantidadArchivos As Integer = 0
            While result.Files.Count > 0
                'CantidadArchivos += result.Files.Count
                For Each item As Google.Apis.Drive.v3.Data.File In result.Files
                    Archivos.Add("Archivo: " + item.Name)
                Next
                If (result.NextPageToken Is Nothing) Then
                    Exit While
                End If
                listrequest.PageToken = result.NextPageToken
                result = listrequest.Execute
            End While
            Return Archivos
        End If
    End Function

    Public Function ListarArchivosEnSubCarpetaDrive(CarpetaDrive As String, Año As String) As List(Of String)
        'Esta funcion devuelve una lista de strings con los nombres de los archivos que fueron subidos a una subcarpeta especifica del google drive 
        'Se puede usar de la siguiente forma para luego usar la funcion de creartxt
        'Dim Archivos As New List(Of String)
        'Archivos.AddRange(GoogleDrive.ListarArchivosEnSubCarpetaDrive("Correspondencia", "2015"))
        'GoogleDrive.CrearTxtConArchivos(Archivos,"Correspondencia")
        Dim Archivos As New List(Of String)
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
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Or response.Files.Count = 0 Then
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
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
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response2 Is Nothing Or response2.Files.Count = 0 Then
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End If
        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True
        'listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name = '" + Archivo + "'"
        listrequest.Q = "'" + response2.Files(0).Id + "' in parents"
        listrequest.Fields = "nextPageToken, files(id, name)"
        listrequest.PageSize = 1000
        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            'MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try
        If result.Files.Count = 0 Then
            Return Nothing
        Else
            While result.Files.Count > 0
                For Each item As Google.Apis.Drive.v3.Data.File In result.Files
                    Archivos.Add("Archivo: " + item.Name + " Año: " + Año)
                Next
                If (result.NextPageToken Is Nothing) Then
                    Exit While
                End If
                listrequest.PageToken = result.NextPageToken
                result = listrequest.Execute
            End While
            Return Archivos
        End If
    End Function

    Public Sub CrearTxtConArchivos(ArrayCantidadArchivos As List(Of String), NombreArchivo As String)
        Dim objStreamWriter As StreamWriter
        Dim appPathSubidos As String = Application.StartupPath + "\ArchivosPDF"
        If Not Directory.Exists(appPathSubidos) Then
            Directory.CreateDirectory(appPathSubidos)
        End If
        If IO.File.Exists(VariablesBase.VariablesBase._path + "\ArchivosPDF\" + NombreArchivo + ".txt") = True Then
            Try
                If My.Computer.FileSystem.FileExists(VariablesBase.VariablesBase._path + "\ArchivosPDF\" + NombreArchivo + ".txt") Then
                    My.Computer.FileSystem.DeleteFile(VariablesBase.VariablesBase._path + "\ArchivosPDF\" + NombreArchivo + ".txt")
                End If
            Catch ex As Exception
            End Try
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\ArchivosPDF\" + NombreArchivo + ".txt", True)
        Else
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\ArchivosPDF\" + NombreArchivo + ".txt")
        End If
        For i As Integer = 0 To ArrayCantidadArchivos.Count - 1
            If ArrayCantidadArchivos(i) IsNot Nothing Then
                objStreamWriter.WriteLine(ArrayCantidadArchivos(i).ToString)
            End If
        Next
        objStreamWriter.Close()
        Dim sfile As String
        sfile = VariablesBase.VariablesBase._path + "\ArchivosPDF\" + NombreArchivo + ".txt"
        Dim psi As New ProcessStartInfo()
        psi.UseShellExecute = True
        psi.FileName = sfile
        Process.Start(psi)
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
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Or response.Files.Count = 0 Then
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
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
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response2 Is Nothing Or response2.Files.Count = 0 Then
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
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
            'MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return {1, response2}
            Exit Function
        End Try
        If result.Files.Count = 0 Then
            Return {1, response2}
        Else
            Return {2, response2, result}
        End If
    End Function

    Public Function DtArchivosEnCarpetaDrive(CarpetaDrive As String, Año As String, Archivo As String) As Object
        'Funcion para crear un datatable con el listado de archivos segun el nombre del documento
        If VariablesBase.VariablesBase.NombreBaseDatos <> "ISMOCOLPRODUCCION" Then
            CarpetaDrive = "Pruebas"
            Año = "Subcarpeta"
        End If
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
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Or response.Files.Count = 0 Then
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
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
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response2 Is Nothing Or response2.Files.Count = 0 Then
            'MsgBox("Carpeta en el servidor no encontrada", MsgBoxStyle.Critical, "Error")
            Return {0}
            Exit Function
        End If
        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True
        'listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name = '" + Archivo + "'"
        listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name contains '" + Archivo + "' or name contains '" + "CAN_" + Archivo + "'"
        listrequest.Fields = "nextPageToken, files(id, name, createdTime, description)"

        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            'MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return {1, response2}
            Exit Function
        End Try
        If result.Files.Count = 0 Then
            Return {1, response2}
        Else
            Dim Dt_ListadoArchivos As New DataTable
            Dt_ListadoArchivos.Columns.Add("IdArchivo")
            Dt_ListadoArchivos.Columns.Add("Nombre")
            Dt_ListadoArchivos.Columns.Add("FechaCreacion")
            Dt_ListadoArchivos.Columns.Add("Descripcion")
            For i As Integer = 0 To result.Files.Count - 1
                Dim Row As DataRow
                Row = Dt_ListadoArchivos.NewRow
                Row("IdArchivo") = result.Files(i).Id
                Row("Nombre") = result.Files(i).Name
                Row("FechaCreacion") = result.Files(i).CreatedTime.Value
                Row("Descripcion") = result.Files(i).Description.ToString.Replace("Subido por: ", "")
                Dt_ListadoArchivos.Rows.Add(Row)
            Next
            Return {2, response2, Dt_ListadoArchivos}
        End If
    End Function

    Public Function SubirArchivo(Tipo As Integer, Id As Integer, Archivo As String, Año As String, Optional Actualizar As Boolean = False, Optional ArchivoAdjunto As String = "") As Boolean
        'Tipo 1 -> Requisicion 
        'Tipo 2 -> Orden de Compra
        'Tipo 3 -> Salidas
        'Tipo 4 -> Entradas
        'Tipo 5 -> Relacion Facturas
        'Tipo 6 -> Autorización Seguridad 
        'Tipo 7 -> Siscontrol Correspondencia
        'Tipo 8 -> Siscontrol FAX
        'Tipo 9 -> Cancelacion Requisicion
        'Tipo 10 -> Cancelacion Orden Compra
        'Tipo 11 -> Cancelacion Salida Almacen
        'Tipo 12 -> Cancelacion Entrada Almacen
        'Tipo 13 -> Examenes Medicos
        'Id -> Id del registro 
        'Archivo -> Identificador del documento ej: BGA.202100065

        Dim RutaArchivo As String = ""
        Dim OpenFileSubir As New OpenFileDialog
        'Filtrar por archivos PDF
        OpenFileSubir.Filter = "Pdf Files|*.pdf"
        Dim CarpetaDrive As String = ""
        'Dim NombreArchivo As String = ""
        Select Case Tipo
            Case 1, 9
                CarpetaDrive = "Requisición"
            Case 2, 10
                CarpetaDrive = "OrdenCompra"
            Case 3, 11
                CarpetaDrive = "SalidaAlmacén"
            Case 4, 12
                CarpetaDrive = "EntradaAlmacén"
            Case 5
                CarpetaDrive = "RelacionFactura"
            Case 6
                CarpetaDrive = "AutorizaciónDescuento"
            Case 7
                CarpetaDrive = "Correspondencia"
            Case 8
                CarpetaDrive = "FAX"
            Case 13
                CarpetaDrive = "ExámenesMédicos"
            Case Else
                Return False
        End Select
        If Trim(ArchivoAdjunto) = "" Then
            If Actualizar Then
                If MsgBox("Ya hay un archivo en el servidor, ¿Desea reemplazarlo?", MsgBoxStyle.YesNo, "Reemplazar") = MsgBoxResult.Yes Then
                    If (OpenFileSubir.ShowDialog() = DialogResult.OK) Then
                        RutaArchivo = OpenFileSubir.FileName
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                If (OpenFileSubir.ShowDialog() = DialogResult.OK) Then
                    RutaArchivo = OpenFileSubir.FileName
                Else
                    Return False
                End If
            End If
            ArchivoRuta = OpenFileSubir.FileName
        Else
            ArchivoRuta = ArchivoAdjunto
        End If

        ArchivoRuta = Replace(ArchivoRuta, "\", "/")
        Dim filetype As New IO.FileInfo(ArchivoRuta)
        If filetype.Extension.ToLower <> ".pdf" Then
            MsgBox("Error, el archivo debe ser .Pdf", MsgBoxStyle.Critical, "Archivo incompatible")
            Return False
            Exit Function
        End If

        Dim obj As Object
        obj = BuscarArchivoEnSubCarpeta(CarpetaDrive, Año, Archivo, "C")

        If obj Is Nothing Then
            Return False
            Exit Function
        End If

        Dim result As FileList = obj(0)
        Dim ListadoArchivosEliminar As New FileList
        ListadoArchivosEliminar.Files = result.Files.ToList
        Dim Idpadre As String = obj(1)

        ListadoArchivosEliminar.Files.Clear()

        For i As Integer = 0 To result.Files.Count - 1
            If result.Files(i).Name(result.Files(i).Name.Length - 6) = "-" Then
                If result.Files(i).Name.Substring(0, result.Files(i).Name.Length - 6) <> Archivo Then
                    Dim ArchivoBorrar As Google.Apis.Drive.v3.Data.File = result.Files(i)
                    ListadoArchivosEliminar.Files.Insert(0, ArchivoBorrar)
                End If
            Else
                If result.Files(i).Name.Substring(0, result.Files(i).Name.Length - 4) <> Archivo Then
                    Dim ArchivoBorrar As Google.Apis.Drive.v3.Data.File = result.Files(i)
                    ListadoArchivosEliminar.Files.Add(ArchivoBorrar)
                End If
            End If

        Next

        For i As Integer = 0 To ListadoArchivosEliminar.Files.Count - 1
            result.Files.Remove(ListadoArchivosEliminar.Files(i))

        Next

        If (result.Files.Count > 0) Then
            Cursor.Current = Cursors.Default
            'MsgBox("Se encontro un archivo existente, se procedera a actualizar", MsgBoxStyle.Information, "Archivo Existente")
            If MessageBox.Show("Se encontro un archivo existente, seguro que desea actualizar", "Actualizar archivo", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Else
                MsgBox("Se cancelo el proceso", MsgBoxStyle.Information, "Proceso cancelado")
                Return False
                Exit Function
            End If
            Cursor.Current = Cursors.WaitCursor
            Dim funcionCalcularLetra As Object = CalcularLetra(result, Archivo)
            Dim Letra As String

            If funcionCalcularLetra(2) <> 0 Then
                Return False
                Exit Function
            End If
            If Trim(funcionCalcularLetra(0)) <> "" Then
                Letra = funcionCalcularLetra(0)
            Else
                Return False
                Exit Function
            End If
            Dim CambiarNombreOk As Boolean
            'CambiarNombreOk = CambiarNombreArchivo(Service, response2.Files(0).Id, Archivo, Letra, ".pdf")
            CambiarNombreOk = CambiarNombreArchivo(Service, Idpadre, Archivo, Letra, ".pdf")
            If CambiarNombreOk Then
                Archivo = Archivo + ".pdf"
                'Dim response3 = CargarArchivo(Service, ArchivoRuta, response2.Files(0).Id, Archivo, Año)
                Dim response3 = CargarArchivo(Service, ArchivoRuta, Idpadre, Archivo, Año)
                If Not response3 Is Nothing Then
                    MsgBox("Archivo actualizado", MsgBoxStyle.Information, "Archivo Actualizado")
                    Cursor.Current = Cursors.Default
                    'Modificar subido servidor bd
                    MarcarSubidoServidor(Tipo, Id)
                Else
                    MsgBox("No se actualizó el archivo", MsgBoxStyle.Critical, "Error")
                    Cursor.Current = Cursors.Default
                End If
            Else
                MsgBox("No se pudo actualizar el archivo, pongase en contacto con soporte", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        Else
            Archivo += ".pdf"
            'Dim response3 = CargarArchivo(Service, ArchivoRuta, response2.Files(0).Id, Archivo, Año)
            Dim response3 = CargarArchivo(Service, ArchivoRuta, Idpadre, Archivo, Año)
            If Not response3 Is Nothing Then
                Cursor.Current = Cursors.Default
                MsgBox("Archivo subido", MsgBoxStyle.Information, "Archivo subido")
                'Modificar subido servidor bd
                MarcarSubidoServidor(Tipo, Id)
            Else
                MsgBox("No se subio el archivo", MsgBoxStyle.Critical, "Error")
                Cursor.Current = Cursors.Default
            End If
        End If
        Return True
    End Function

    Public Function SubirFoto(Tipo As Integer, Id As String, RutaArchivo As String, Actualizar As Boolean) As Boolean
        'Tipo 1 -> Persona 
        'Tipo 2 -> Articulo
        'Tipo 3 -> Visitante
        'Id -> Identificador del registro. En Persona documento, en Articulo el IdArticulo, en visitante el idVisita

        Dim CarpetaDrive As String = ""

        Select Case Tipo
            Case 1
                CarpetaDrive = "Persona"
            Case 2
                CarpetaDrive = "Artículos"
                Id = "art_" + Id
            Case 3
                CarpetaDrive = "Visitante"
                Id = "vis_" + Id
            Case Else
                Return False
        End Select

        Dim obj As Object
        obj = BuscarArchivoEnCarpeta(CarpetaDrive, Id, "C")

        If obj Is Nothing Then
            Return False
            Exit Function
        End If

        Dim result As FileList = obj(0)
        Dim ListadoArchivosEliminar As New FileList
        ListadoArchivosEliminar.Files = result.Files.ToList
        Dim Idpadre As String = obj(1)

        ListadoArchivosEliminar.Files.Clear()

        For i As Integer = 0 To result.Files.Count - 1
            If result.Files(i).Name(result.Files(i).Name.Length - 6) = "-" Then
                If result.Files(i).Name.Substring(0, result.Files(i).Name.Length - 6) <> Id Then
                    Dim ArchivoBorrar As Google.Apis.Drive.v3.Data.File = result.Files(i)
                    ListadoArchivosEliminar.Files.Insert(0, ArchivoBorrar)
                End If
            Else
                If result.Files(i).Name.Substring(0, result.Files(i).Name.Length - 4) <> Id Then
                    Dim ArchivoBorrar As Google.Apis.Drive.v3.Data.File = result.Files(i)
                    ListadoArchivosEliminar.Files.Add(ArchivoBorrar)
                End If
            End If

        Next

        For i As Integer = 0 To ListadoArchivosEliminar.Files.Count - 1
            result.Files.Remove(ListadoArchivosEliminar.Files(i))

        Next

        If (result.Files.Count > 0) Then
            Cursor.Current = Cursors.Default
            MsgBox("Se encontro un archivo existente, se procedera a actualizar", MsgBoxStyle.Information, "Archivo Existente")
            Cursor.Current = Cursors.WaitCursor
            Dim funcionCalcularLetra As Object = CalcularLetra(result, Id)
            Dim Letra As String
            If funcionCalcularLetra(2) <> 0 Then
                Return False
                Exit Function
            End If
            If Trim(funcionCalcularLetra(0)) <> "" Then
                Letra = funcionCalcularLetra(0)
            Else
                Return False
                Exit Function
            End If
            Dim CambiarNombreOk As Boolean
            'CambiarNombreOk = CambiarNombreArchivo(Service, response.Files(0).Id, Id, Letra, ".jpg")
            CambiarNombreOk = CambiarNombreArchivo(Service, Idpadre, Id, Letra, ".jpg")
            If CambiarNombreOk Then
                Id = Id + ".jpg"
                'Dim response2 = CargarArchivo(Service, RutaArchivo, response.Files(0).Id, Id)
                Dim response2 = CargarArchivo(Service, RutaArchivo, Idpadre, Id)
                If Not response2 Is Nothing Then
                    MsgBox("Archivo actualizado", MsgBoxStyle.Information, "Archivo Actualizado")
                    Cursor.Current = Cursors.Default
                Else
                    MsgBox("No se actualizó el archivo", MsgBoxStyle.Critical, "Error")
                    Cursor.Current = Cursors.Default
                End If
            Else
                MsgBox("No se pudo actualizar el archivo, pongase en contacto con soporte", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        Else
            Id += ".jpg"
            'Dim response2 = CargarArchivo(Service, RutaArchivo, response.Files(0).Id, Id)
            Dim response2 = CargarArchivo(Service, RutaArchivo, Idpadre, Id)
            If Not response2 Is Nothing Then
                Cursor.Current = Cursors.Default
                MsgBox("Archivo subido", MsgBoxStyle.Information, "Archivo subido")
                'Modificar subido servidor bd
            Else
                MsgBox("No se subio el archivo", MsgBoxStyle.Critical, "Error")
                Cursor.Current = Cursors.Default
            End If
        End If
        Return True
    End Function

    Public Function SubirArchivoSinSubCarpeta(Tipo As Integer, Nombre As String, Optional RutaArchivo As String = "") As Boolean
        'Tipo 1 -> FacturacionElectronica
        'Tipo 2 -> Validaciones
        'Id -> Identificador del registro. En Persona documento, en Articulo el IdArticulo, en visitante el idVisita

        Dim CarpetaDrive As String = ""
        Dim Extension As String = ""
        Dim Archivo As String = ""
        Dim OpenFileSubir As New OpenFileDialog
        'Filtrar por archivos PDF
        OpenFileSubir.Filter = "Pdf Files|*.pdf"

        Select Case Tipo
            Case 1
                CarpetaDrive = "FacturaciónElectrónica"
            Case 2
                CarpetaDrive = "Validaciones"
            Case Else
                Return False
        End Select

        If Trim(RutaArchivo) = "" Then
            If (OpenFileSubir.ShowDialog() = DialogResult.OK) Then
                Archivo = OpenFileSubir.FileName
            Else
                Return False
            End If
            'End If
            RutaArchivo = OpenFileSubir.FileName
        End If

        Dim filetype As New IO.FileInfo(RutaArchivo)
        Extension = filetype.Extension.ToLower
        Dim mimetype As String = ""
        If Extension = ".pdf" Then
            mimetype = "application/pdf"
        Else
            If Extension = ".xml" Then
                mimetype = "text/xml"
            End If
        End If

        Dim obj As Object
        obj = BuscarArchivoEnCarpeta(CarpetaDrive, Nombre, "C")

        If obj Is Nothing Then
            Return False
            Exit Function
        End If

        Dim result As FileList = obj(0)
        Dim Idpadre As String = obj(1)

        'Dim Actualizar As Boolean = False
        Dim ListaArchivosExtension As New List(Of Google.Apis.Drive.v3.Data.File)

        For i As Integer = 0 To result.Files.Count - 1
            If result.Files(i).FileExtension = Extension.Substring(1, Extension.Length - 1) Then
                'Actualizar = True
                ListaArchivosExtension.Add(result.Files(i))
            End If
        Next

        If ListaArchivosExtension.Count > 0 Then
            Dim ListaCalcularLetra As New FileList
            ListaCalcularLetra.Files = ListaArchivosExtension
            Cursor.Current = Cursors.Default

            MsgBox("Se encontro un archivo existente, se procedera a actualizar", MsgBoxStyle.Information, "Archivo Existente")
            Cursor.Current = Cursors.WaitCursor
            Dim funcionCalcularLetra As Object = CalcularLetra(ListaCalcularLetra, Nombre)
            Dim Letra As String
            If funcionCalcularLetra(2) <> 0 Then
                Return False
                Exit Function
            End If
            If Trim(funcionCalcularLetra(0)) <> "" Then
                Letra = funcionCalcularLetra(0)
            Else
                Return False
                Exit Function
            End If
            Dim CambiarNombreOk As Boolean
            'CambiarNombreOk = CambiarNombreArchivo(Service, response.Files(0).Id, Nombre, Letra, Extension)
            CambiarNombreOk = CambiarNombreArchivo(Service, Idpadre, Nombre, Letra, Extension)
            If CambiarNombreOk Then
                Nombre = Nombre + Extension
                'Dim response2 = CargarArchivo(Service, RutaArchivo, response.Files(0).Id, Nombre)
                Dim response2 = CargarArchivo(Service, RutaArchivo, Idpadre, Nombre)
                If response2 IsNot Nothing Then
                    Cursor.Current = Cursors.Default
                Else
                    Cursor.Current = Cursors.Default
                    Return False
                End If
            Else
                MsgBox("No se pudo actualizar el archivo, pongase en contacto con soporte", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        Else
            Nombre += Extension
            'Dim response2 = CargarArchivo(Service, RutaArchivo, response.Files(0).Id, Nombre)
            Dim response2 = CargarArchivo(Service, RutaArchivo, Idpadre, Nombre)
            If Not response2 Is Nothing Then
                Cursor.Current = Cursors.Default
            Else
                Cursor.Current = Cursors.Default
                Return False
            End If
        End If
        Return True
    End Function

    Public Function CalcularLetra(Lista As FileList, ByVal Archivo As String) As Object
        Dim ErrorLetra As Integer = 0 ' 0 -> Correcto, 1 --> No hay mas consecutivos, 2--> Inesperado
        Dim Palabra As String = ""
        Dim NumeroLetra As Integer = 0
        Dim Letra As String = ""
        Dim LetraMayor As Integer = 0
        For i As Integer = 0 To Lista.Files.Count - 1
            Palabra = Lista.Files(i).Name
            Dim prueba As String = Asc(Palabra(Palabra.Length - 5))
            If Palabra(Palabra.Length - 6) = "-" Then
                If Asc(Palabra(Palabra.Length - 5)) > LetraMayor Then
                    LetraMayor = Asc(Palabra(Palabra.Length - 5))
                End If
            End If
        Next
        If LetraMayor = 90 Then
            MsgBox("Consecutivo lleno para el documento " + Archivo + ", no se pueden subir mas archivos", MsgBoxStyle.Information, "Archivo lleno")
            Letra = Convert.ToChar(LetraMayor)
            ErrorLetra = 1
            Return {Letra, LetraMayor, ErrorLetra}
            Exit Function
        End If
        If LetraMayor > 64 AndAlso LetraMayor < 90 Then
            Letra = Convert.ToChar(LetraMayor + 1)
        Else
            If LetraMayor = 0 Or LetraMayor < 65 Then
                Letra = Convert.ToChar(65)
            Else
                MsgBox("Error al calcular el consecutivo para el documento " + Archivo + ", no se pudo subir el archivo", MsgBoxStyle.Information, "No se cargó el archivo")
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
            MsgBox("Error al cargar el archivo antiguo", MsgBoxStyle.Critical, "Error")
            Return False
            Exit Function
        End Try

        If result.Files.Count = 0 Then
            Return False
            Exit Function
        End If

        fileID = result.Files(0).Id

        Dim archivoDrive As Google.Apis.Drive.v3.Data.File = result.Files(0)
        archivoDrive.Name = NombreArchivo + "-" + Letra + Extension
        archivoDrive.Id = Nothing
        Dim request As FilesResource.UpdateRequest = service.Files.Update(archivoDrive, fileID)
        request.SupportsAllDrives = True
        request.SupportsTeamDrives = True
        request.Fields = "id, name, thumbnailLink"
        Try
            request.Execute()
        Catch ex As Exception
            MsgBox("Error al cambiar el nombre del archivo", MsgBoxStyle.Critical, "Error")
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function CargarArchivo(service As Google.Apis.Drive.v3.DriveService, RutaArchivo As String, IdPadre As String, NombreArchivo As String, Optional Año As String = "")
        CreateService()
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
                Else
                    If filetype.Extension.ToLower = ".xml" Then
                        body.MimeType = "text/xml"
                    End If
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
                request.ChunkSize = 100000000
                'AddHandler request.ProgressChanged, AddressOf Request_ProgressChanged

                request.Resume()
                If request.GetProgress.Status = UploadStatus.Completed Then
                    stream.Close()
                    Return True
                Else
                    If MessageBox.Show("Error, ¿Desea intentar de nuevo?", "Error", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        CargarArchivo(service, RutaArchivo, IdPadre, NombreArchivo)
                    End If
                End If
                stream.Close()
                Return request.ResponseBody()
            Catch ex As Exception
                MsgBox(ex.Message)
                stream.Close()
                Return Nothing
            End Try
        Else
            MsgBox("Error, archivo no encontrado", MsgBoxStyle.Critical, "Archivo no encontrado")
            Return Nothing
        End If
    End Function

    'Private Sub Request_ProgressChanged(ByVal obj As Google.Apis.Upload.IUploadProgress)
    '    Dim filetype As New System.IO.FileInfo(ArchivoRuta)
    '    Dim totalFileSize As Double = filetype.Length
    '    Dim Porcentaje As Double
    '    Porcentaje = (obj.BytesSent * 100) / totalFileSize
    'End Sub

    Public Function ActualizarArchivo(service As Google.Apis.Drive.v3.DriveService, RutaArchivo As String, IdArchivo As String, NombreArchivo As String)
        If (System.IO.File.Exists(RutaArchivo)) Then
            Dim body As Google.Apis.Drive.v3.Data.File = New Google.Apis.Drive.v3.Data.File
            body.Name = NombreArchivo
            body.Description = "Actualizado por: " + VariablesBase.VariablesBase.Nombre_Usuario.ToString
            Dim filetype As New IO.FileInfo(NombreArchivo)
            If filetype.Extension.ToLower = ".pdf" Then
                body.MimeType = "application/pdf"
            Else
                If filetype.Extension.ToLower = ".jpg" Then
                    body.MimeType = "image/jpeg"
                Else
                    MsgBox("Ocurrio un error al cargar el archivo")
                    Return Nothing
                End If
            End If
            body.ModifiedTime = DateTime.Now
            Dim stream As System.IO.FileStream
            stream = New FileStream(RutaArchivo, FileMode.Open, FileAccess.Read)
            Try
                Dim request As FilesResource.UpdateMediaUpload = service.Files.Update(body, IdArchivo, stream, body.MimeType)
                request.SupportsTeamDrives = True
                request.SupportsAllDrives = True
                request.ChunkSize = 100000000
                request.Upload()
                stream.Close()
                Return request.ResponseBody()
            Catch ex As Exception
                stream.Close()
                MsgBox(ex.Message, "Ocurrio un error al cargar el archivo")
                Return Nothing
            End Try
        Else
            MsgBox("Error, archivo no encontrado", MsgBoxStyle.Critical, "Archivo no encontrado")
            Return Nothing
        End If
    End Function

    Public Sub DescargarArchivoNombre(Año As String, Nombre As String, RutaCarpeta As String, CarpetaDrive As String)
        CreateService()
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)
        Nombre = Trim(Nombre)

        Dim appPath As String = Application.StartupPath + "\" + RutaCarpeta
        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim foldersrequest As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest.SupportsAllDrives = True
        foldersrequest.IncludeItemsFromAllDrives = True

        Dim obj As Object
        obj = BuscarArchivoEnSubCarpeta(CarpetaDrive, Año, Nombre, "D")
        If obj Is Nothing Then
            Exit Sub
        End If

        Dim result As FileList
        result = obj(0)
        If result Is Nothing Or result.Files.Count = 0 Then
            MessageBox.Show("No se encontro el archivo deseado.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Dim Archivo As Google.Apis.Drive.v3.Data.File = result.Files(0)

        Cursor.Current = Cursors.Default
        'Dim GuardarEn As String = appPath + "/" + Nombre
        Dim GuardarEn As String = appPath + "/" + Archivo.Name
        GuardarEn = Replace(GuardarEn, "\", "/")
        Dim filestream As System.IO.FileStream
        Try
            filestream = New FileStream(GuardarEn, FileMode.Create, FileAccess.Write)
            Dim request As Google.Apis.Drive.v3.FilesResource.GetRequest
            request = Service.Files.Get(Archivo.Id)

            Dim request3 = request.DownloadAsync(filestream)
            While (request3.Status <> Threading.Tasks.TaskStatus.RanToCompletion)
                Cursor.Current = Cursors.WaitCursor
                If (request3.Status = Threading.Tasks.TaskStatus.Running) Then
                End If
                If (request3.Status = Threading.Tasks.TaskStatus.Faulted) Then
                    Cursor.Current = Cursors.Default
                    MessageBox.Show("Error al descargar el archivo.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If (request3.Status = Threading.Tasks.TaskStatus.WaitingToRun Or request3.Status = Threading.Tasks.TaskStatus.WaitingForActivation Or request3.Status = Threading.Tasks.TaskStatus.Running) Then
                End If
            End While
            Cursor.Current = Cursors.Default
            If (request3.Status = Threading.Tasks.TaskStatus.RanToCompletion) Then
                MsgBox("Se ha descargado el archivo en la carpeta: " + appPath, MsgBoxStyle.Information, "Archivo descargado")
            End If

            filestream.Close()

            Dim sfile As String
            'sfile = IO.Path.Combine(appPath, Nombre)
            sfile = IO.Path.Combine(appPath, Archivo.Name)
            Dim psi As New ProcessStartInfo()
            psi.UseShellExecute = True
            psi.FileName = sfile
            Process.Start(psi)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function DescargarFotos(Nombre As String, CarpetaDrive As String) As Boolean
        CreateService()
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)
        Nombre = Trim(Nombre) + ".jpg"

        Dim appPath As String = Application.StartupPath
        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Dim obj As Object
        obj = BuscarArchivoEnCarpeta(CarpetaDrive, Nombre, "D")
        If obj Is Nothing Then
            Return False
            Exit Function
        End If

        Dim result As FileList
        result = obj(0)
        Dim IdPadre As String = obj(1)

        If result Is Nothing Or result.Files.Count = 0 Then
            Return False
            Exit Function
        End If

        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Dim Archivo As Google.Apis.Drive.v3.Data.File = result.Files(0)

        Cursor.Current = Cursors.Default
        Nombre = "Temp.jpg"
        Dim GuardarEn As String = appPath + "/" + Nombre 'Archivo.Name
        GuardarEn = Replace(GuardarEn, "\", "/")
        Dim filestream As System.IO.FileStream
        Try
            filestream = New FileStream(GuardarEn, FileMode.Create, FileAccess.Write)
            Dim request As Google.Apis.Drive.v3.FilesResource.GetRequest
            request = Service.Files.Get(Archivo.Id)

            Dim request3 = request.DownloadAsync(filestream)
            While (request3.Status <> Threading.Tasks.TaskStatus.RanToCompletion)
                Cursor.Current = Cursors.WaitCursor
                If (request3.Status = Threading.Tasks.TaskStatus.Running) Then
                End If
                If (request3.Status = Threading.Tasks.TaskStatus.Faulted) Then
                    Cursor.Current = Cursors.Default
                    'MessageBox.Show("Error al descargar el archivo.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                    Exit Function
                End If
                If (request3.Status = Threading.Tasks.TaskStatus.WaitingToRun Or request3.Status = Threading.Tasks.TaskStatus.WaitingForActivation Or request3.Status = Threading.Tasks.TaskStatus.Running) Then
                End If
            End While
            Cursor.Current = Cursors.Default
            If (request3.Status = Threading.Tasks.TaskStatus.RanToCompletion) Then
                'MsgBox("Se ha descargado el archivo en la carpeta: " + appPath, MsgBoxStyle.Information, "Archivo descargado")
            End If

            filestream.Close()

            Return True
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End Try
    End Function

    Public Function DescargarArchivosSinSubCarpeta(Nombre As String, CarpetaDrive As String) As Boolean
        CreateService()
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)

        Dim appPath As String = Application.StartupPath + "\ArchivosPDF"
        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Dim obj As Object
        obj = BuscarArchivoEnCarpeta(CarpetaDrive, Nombre, "D")
        If obj Is Nothing Then
            Return False
            Exit Function
        End If

        Dim result As FileList
        result = obj(0)
        Dim IdPadre As String = obj(1)

        If result Is Nothing Or result.Files.Count = 0 Then
            Return False
            Exit Function
        End If

        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Dim Archivo As Google.Apis.Drive.v3.Data.File = result.Files(0)

        Cursor.Current = Cursors.Default
        Dim GuardarEn As String = appPath + "/" + Nombre
        GuardarEn = Replace(GuardarEn, "\", "/")
        Dim filestream As System.IO.FileStream
        Try
            filestream = New FileStream(GuardarEn, FileMode.Create, FileAccess.Write)
            Dim request As Google.Apis.Drive.v3.FilesResource.GetRequest
            request = Service.Files.Get(Archivo.Id)

            Dim request3 = request.DownloadAsync(filestream)
            While (request3.Status <> Threading.Tasks.TaskStatus.RanToCompletion)
                Cursor.Current = Cursors.WaitCursor
                If (request3.Status = Threading.Tasks.TaskStatus.Running) Then
                End If
                If (request3.Status = Threading.Tasks.TaskStatus.Faulted) Then
                    Cursor.Current = Cursors.Default
                    'MessageBox.Show("Error al descargar el archivo.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                    Exit Function
                End If
                If (request3.Status = Threading.Tasks.TaskStatus.WaitingToRun Or request3.Status = Threading.Tasks.TaskStatus.WaitingForActivation Or request3.Status = Threading.Tasks.TaskStatus.Running) Then
                End If
            End While
            Cursor.Current = Cursors.Default
            If (request3.Status = Threading.Tasks.TaskStatus.RanToCompletion) Then
                'MsgBox("Se ha descargado el archivo en la carpeta: " + appPath, MsgBoxStyle.Information, "Archivo descargado")
            End If

            filestream.Close()

            Dim sfile As String
            sfile = IO.Path.Combine(appPath, Nombre)
            Dim psi As New ProcessStartInfo()
            psi.UseShellExecute = True
            psi.FileName = sfile
            Process.Start(psi)

            Return True
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End Try
    End Function

    Public Function DescargarArchivoId(Nombre As String, IdArchivo As String, RutaCarpeta As String) As Boolean
        CreateService()
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)
        Nombre = Trim(Nombre)

        Dim appPath As String = Application.StartupPath + "\" + RutaCarpeta
        If Not Directory.Exists(appPath) Then
            Directory.CreateDirectory(appPath)
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim GuardarEn As String = appPath + "/" + Nombre
        GuardarEn = Replace(GuardarEn, "\", "/")
        Dim filestream As System.IO.FileStream
        Try
            filestream = New FileStream(GuardarEn, FileMode.Create, FileAccess.Write)
            Dim request As Google.Apis.Drive.v3.FilesResource.GetRequest
            request = Service.Files.Get(IdArchivo)

            Dim request3 = request.DownloadAsync(filestream)
            While (request3.Status <> Threading.Tasks.TaskStatus.RanToCompletion)
                Cursor.Current = Cursors.WaitCursor
                If (request3.Status = Threading.Tasks.TaskStatus.Faulted) Then
                    Cursor.Current = Cursors.Default
                    Return False
                    Exit Function
                End If
            End While
            Cursor.Current = Cursors.Default
            If (request3.Status = Threading.Tasks.TaskStatus.RanToCompletion) Then
                filestream.Close()
                Return True
                Exit Function
            Else
                Return False
                Exit Function
            End If
        Catch ex As Exception
            Return False
            Exit Function
        End Try
    End Function

    Public Function VerificarArchivosEnBaseDatos(Tipo As Integer) As Boolean
        'Tipo 1 -> Requisicion 
        'Tipo 2 -> Orden de Compra
        'Tipo 3 -> Entradas
        'Tipo 4 -> Salidas
        'Tipo 5 -> Relacion Facturas
        'Tipo 6 -> Autorización Seguridad - No se cargará en bloque
        'Tipo 7 -> Correspondencia

        Dim OpenFolder As New FolderBrowserDialog
        OpenFolder.ShowNewFolderButton = False
        CreateService()
        Cursor.Current = Cursors.WaitCursor
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)
        Dim RutaCarpeta As String = ""
        If (OpenFolder.ShowDialog() = DialogResult.OK) Then
            RutaCarpeta = OpenFolder.SelectedPath
            Dim InformacionCarpeta As New DirectoryInfo(RutaCarpeta)
            If InformacionCarpeta.GetFiles.Count = 0 Then
                MsgBox("Seleccione una carpeta con archivos")
                Return False
            Else
                If MessageBox.Show("¿Desea subir " & InformacionCarpeta.GetFiles.Count & " archivos de la carpeta " & RutaCarpeta & vbNewLine & " al servidor?", "SUBIR EN EL SERVIDOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Return False
                    Exit Function
                End If
                Dim fr_BarraCarga As New Fr_BarraDeCarga
                fr_BarraCarga.Service = Service
                fr_BarraCarga.RutaCarpeta = RutaCarpeta
                fr_BarraCarga.Tipo = Tipo
                fr_BarraCarga.ShowDialog()
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function VerificarDocumentoYCancelacion(Archivo As String, ArchivoCancelacion As String, CarpetaDrive As String, Año As String) As Object
        'El objeto devuelve {Error,CantidadArchivos,Letra1, Letra2} - Error 0, Correcto 1 - CantidadArchivos Identifica si esta el documento y su cancelacion 
        'Letra1 dice si esta el documento, Letra2 dice si esta la cancelacion
        Dim ErrorArchivos As Integer = 0
        Dim CantidadArchivos As Integer = 0
        Dim Letra1 As String = ""
        Dim Letra2 As String = ""

        'SOLO PARA PRUEBAS
        'CarpetaDrive = "Pruebas"

        'Se debe crear el servicio antes de subir o descargar un archivo
        CreateService()
        Cursor.Current = Cursors.WaitCursor
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)

        Dim foldersrequest As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest.SupportsAllDrives = True
        foldersrequest.IncludeItemsFromAllDrives = True
        foldersrequest.Q = "mimeType = 'application/vnd.google-apps.folder' and name='" + CarpetaDrive + "'"
        'En response obtengo la lista de carpetas que coincidan con el string CarpetaDrive
        Dim response
        Try
            response = foldersrequest.Execute()
        Catch ex As Exception
            MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return {ErrorArchivos}
            Exit Function
        End Try

        If response Is Nothing Then
            MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
        End If

        Dim foldersrequest2 As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest2.SupportsAllDrives = True
        foldersrequest2.IncludeItemsFromAllDrives = True
        'Con el mimeType busco el tipo de archivo que sea tipo folder o carpeta y con el name del respectivo año y que este la carpeta correspondencia con su Id e in parents
        foldersrequest2.Q = "mimeType = 'application/vnd.google-apps.folder' and '" + response.Files(0).Id + "' in parents  and name='" + Año + "'"
        Dim response2
        Try
            response2 = foldersrequest2.Execute()
        Catch ex As Exception
            MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return {ErrorArchivos}
            Exit Function
        End Try

        If response2 Is Nothing Then
            MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return {ErrorArchivos}
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
            MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            Return {0}
            Exit Function
        End Try

        If result.Files.Count > 0 Then
            ErrorArchivos = 1
            CantidadArchivos += 1
            Letra1 = "S"
        End If

        Dim listrequest2 As FilesResource.ListRequest = Service.Files.List()
        listrequest2.SupportsAllDrives = True
        listrequest2.IncludeItemsFromAllDrives = True
        'listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name = '" + Archivo + "'"
        listrequest2.Q = "'" + response2.Files(0).Id + "' in parents and name contains '" + ArchivoCancelacion + "'"
        listrequest2.Fields = "nextPageToken, files(id, name)"

        Dim result2 As FileList
        Try
            result2 = listrequest2.Execute()
        Catch ex As Exception
            MsgBox("Error al cargar el archivo", MsgBoxStyle.Critical, "Error")
            If ErrorArchivos = 0 Then
                Return {0}
            Else
                Return {ErrorArchivos, CantidadArchivos, Letra1, Letra2}
            End If
        End Try

        If result2.Files.Count > 0 Then
            ErrorArchivos = 1
            CantidadArchivos += 1
            Letra2 = "S"
        End If
        Return {ErrorArchivos, CantidadArchivos, Letra1, Letra2}
    End Function

    Public Function ObtenerIDCarpetas(CarpetaDrive As String, Año As String) As Object
        CreateService()
        Dim IdCarpeta As String = ""
        Dim IdSubCarpeta As String = ""
        'Cursor.Current = Cursors.WaitCursor
        'Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)

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
            MsgBox("Error al buscar la carpeta principal", MsgBoxStyle.Critical, "Error")
            Return {0}
            Exit Function
        End Try

        If response.Files.Count = 0 Then
            MsgBox("No se encontró la carpeta principal", MsgBoxStyle.Critical, "Error")
            Return {0}
            Exit Function
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
            MsgBox("Error al buscar la subcarpeta", MsgBoxStyle.Critical, "Error")
            Return {0}
            Exit Function
        End Try

        If response2 Is Nothing Then
            MsgBox("No se encontró la subcarpeta", MsgBoxStyle.Critical, "Error")
            Return {0}
            Exit Function
        End If

        IdCarpeta = response.Files(0).Id
        IdSubCarpeta = response2.Files(0).Id

        Return {1, IdCarpeta, IdSubCarpeta}
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

    Public Function BuscarArchivoEnSubCarpeta(CarpetaDrive As String, Subcarpeta As String, Archivo As String, Tipo As String) As Object 'FileList
        'Funcion que devuelve un objeto que contiene el listado de archivos que contienen el nombre que se esta buscando y el id de la carpeta padre cuando los archivos se manejan en carpetas (RQ,OC,SA,EA ...) y subcarpetas (2022,2021,2020 ...)
        If VariablesBase.VariablesBase.NombreBaseDatos <> "ISMOCOLPRODUCCION" Then
            CarpetaDrive = "Pruebas"
            Subcarpeta = "Subcarpeta"
        End If
        'Se debe crear el servicio antes de subir o descargar un archivo
        CreateService()
        Cursor.Current = Cursors.WaitCursor
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)

        Dim foldersrequest As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest.SupportsAllDrives = True
        foldersrequest.IncludeItemsFromAllDrives = True
        foldersrequest.Q = "mimeType = 'application/vnd.google-apps.folder' and name='" + CarpetaDrive + "'"
        'En response obtengo la lista de carpetas que coincidan con el string CarpetaDrive
        Dim response
        Try
            response = foldersrequest.Execute()
        Catch ex As Exception
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Then
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
        End If

        If response.Files.Count = 0 Then
            MessageBox.Show("No se encontro el archivo deseado.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cursor.Current = Cursors.Default
            Return Nothing
            Exit Function
        End If

        Dim foldersrequest2 As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest2.SupportsAllDrives = True
        foldersrequest2.IncludeItemsFromAllDrives = True
        'Con el mimeType busco el tipo de archivo que sea tipo folder o carpeta y con el name del respectivo año y que este la carpeta correspondencia con su Id e in parents
        foldersrequest2.Q = "mimeType = 'application/vnd.google-apps.folder' and '" + response.Files(0).Id + "' in parents  and name='" + Subcarpeta + "'"
        Dim response2
        Try
            response2 = foldersrequest2.Execute()
        Catch ex As Exception
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response2 Is Nothing Then
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End If

        If response2.Files.Count = 0 Then
            MessageBox.Show("No se encontro el archivo deseado.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cursor.Current = Cursors.Default
            Return Nothing
            Exit Function
        End If

        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True

        'Carga de archivos
        If Tipo = "C" Then
            listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name contains '" + Archivo + "'"
        Else
            'Descarga de archivos
            listrequest.Q = "'" + response2.Files(0).Id + "' in parents and name = '" + Archivo + ".pdf'"
        End If

        listrequest.Fields = "nextPageToken, files(id, name, mimeType,fileExtension)"

        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If result Is Nothing Then
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End If

        Return {result, response2.Files(0).Id}

    End Function

    Public Function BuscarArchivoEnCarpeta(CarpetaDrive As String, Archivo As String, Tipo As String) As Object 'FileList
        'Funcion que devuelve un objeto que contiene el listado de archivos que contienen el nombre que se esta buscando y el id de la carpeta padre cuando los archivos se manejan en carpetas (Personas, Articulos, Visitantes ...)
        If VariablesBase.VariablesBase.NombreBaseDatos <> "ISMOCOLPRODUCCION" Then
            CarpetaDrive = "Pruebas"
        End If
        'Se debe crear el servicio antes de subir o descargar un archivo
        CreateService()
        Cursor.Current = Cursors.WaitCursor
        Service.HttpClient.Timeout = TimeSpan.FromSeconds(120)

        Cursor.Current = Cursors.WaitCursor
        Dim foldersrequest As FilesResource.ListRequest = Service.Files.List()
        'Configuro el foldersrequest para que traiga los archivos que estan en las unidades compartidas
        foldersrequest.SupportsAllDrives = True
        foldersrequest.IncludeItemsFromAllDrives = True
        'Con el mimeType busco el tipo de archivo que sea tipo folder o carpeta y con el name que tengan el nombre Correspondencia
        foldersrequest.Q = "mimeType = 'application/vnd.google-apps.folder' and name='" + CarpetaDrive + "'"
        Dim response
        Try
            response = foldersrequest.Execute()
        Catch ex As Exception
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If response Is Nothing Then
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End If

        If response.Files.Count = 0 Then
            MessageBox.Show("No se encontro el archivo deseado.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cursor.Current = Cursors.Default
            Return Nothing
            Exit Function
        End If

        Dim listrequest As FilesResource.ListRequest = Service.Files.List()
        listrequest.SupportsAllDrives = True
        listrequest.IncludeItemsFromAllDrives = True

        Dim Consulta As String = ""
        If Tipo = "C" Then
            'Consulta = "'" + response.Files(0).Id + "' in parents and name contains '" + Archivo + "'"
            listrequest.Q = "'" + response.Files(0).Id + "' in parents and name contains '" + Archivo + "'"
        Else
            'Consulta = "'" + response.Files(0).Id + "' in parents and name = '" + Archivo + "'"
            listrequest.Q = "'" + response.Files(0).Id + "' in parents and name = '" + Archivo + "'"
        End If
        'listrequest.Q = Consulta
        listrequest.Fields = "nextPageToken, files(id, name, mimeType,fileExtension)"
        Dim result As FileList
        Try
            result = listrequest.Execute()
        Catch ex As Exception
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End Try

        If result Is Nothing Then
            MsgBox("Error al buscar el archivo", MsgBoxStyle.Critical, "Error")
            Return Nothing
            Exit Function
        End If

        Return {result, response.Files(0).Id}

    End Function
End Class
