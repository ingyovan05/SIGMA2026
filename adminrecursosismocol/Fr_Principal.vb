Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports VarBase = VariablesBase.VariablesBase
Imports FunBase = FuncionesBase.FuncionesBase

Public Class Fr_Principal
    ''' <summary>Control de usuario cargado actualmente.</summary>
    Public Cu_Actual As New Object
    Dim _path As String
    Dim listarchivos As New ArrayList
    Dim adapatador As New Ds_ConfiguraciónTableAdapters.DETALLEDOCUMENTOTableAdapter
    Dim DsArchivos As New Ds_Configuración

    Private Sub Fr_Administrador_Load(sender As Object, e As EventArgs) Handles Me.Load
        RutinaIngreso()
    End Sub

    Private Sub Fr_Principal_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim CuControl As Object
        Try
            CuControl = Me.Pn_Formularios.Controls.Item(0)
            If CuControl.ReactivarPrincipal = True Then
                CuControl.Cargar_Tabla()
            End If
        Catch ex As Exception
        End Try
        DiferenciarEntorno()
    End Sub

    ''' <summary>Cambia la apariencia de la aplicación dependiendo de la base de datos a la que se conecta.</summary>
    Public Sub DiferenciarEntorno()
        If IsNothing(VarBase.NombreBaseDatos) = False Then
            If VarBase.NombreBaseDatos <> "ISMOCOLPRODUCCION" Then
                Ts_Principal.BackColor = Color.Salmon
                Me.TSB_ActivosFijos.BackColor = Color.Salmon
                Me.TSB_Actualizar.BackColor = Color.Salmon
                Me.TSB_Articulos.BackColor = Color.Salmon
                Me.TSB_Auditoria.BackColor = Color.Salmon
                Me.TSB_Bodega.BackColor = Color.Salmon
                Me.TSB_Compras.BackColor = Color.Salmon
                Me.TSB_Configuración.BackColor = Color.Salmon
                Me.TSB_Contrato.BackColor = Color.Salmon
                Me.TSB_Informes.BackColor = Color.Salmon
                Me.TSB_Licitaciones.BackColor = Color.Salmon
                Me.TSB_MaterialesEspeciales.BackColor = Color.Salmon
                Me.TSB_OrdenesTrabajo.BackColor = Color.Salmon
                Me.TSB_Personal.BackColor = Color.Salmon
                Me.TSB_ReporteDiario.BackColor = Color.Salmon
                Me.TSB_SisControl.BackColor = Color.Salmon
                Me.TSB_Soporte.BackColor = Color.Salmon
                Me.TSB_AccesoRemoto.BackColor = Color.Salmon
                Me.TSB_Hse.BackColor = Color.Salmon
                Me.TSB_Sistemas.BackColor = Color.Salmon
            Else
                Ts_Principal.BackColor = Color.AliceBlue
                Me.TSB_ActivosFijos.BackColor = Color.AliceBlue
                Me.TSB_Actualizar.BackColor = Color.AliceBlue
                Me.TSB_Articulos.BackColor = Color.AliceBlue
                Me.TSB_Auditoria.BackColor = Color.AliceBlue
                Me.TSB_Bodega.BackColor = Color.AliceBlue
                Me.TSB_Compras.BackColor = Color.AliceBlue
                Me.TSB_Configuración.BackColor = Color.AliceBlue
                Me.TSB_Contrato.BackColor = Color.AliceBlue
                Me.TSB_Informes.BackColor = Color.AliceBlue
                Me.TSB_Licitaciones.BackColor = Color.AliceBlue
                Me.TSB_MaterialesEspeciales.BackColor = Color.AliceBlue
                Me.TSB_OrdenesTrabajo.BackColor = Color.AliceBlue
                Me.TSB_Personal.BackColor = Color.AliceBlue
                Me.TSB_ReporteDiario.BackColor = Color.AliceBlue
                Me.TSB_SisControl.BackColor = Color.AliceBlue
                Me.TSB_Soporte.BackColor = Color.AliceBlue
                Me.TSB_AccesoRemoto.BackColor = Color.AliceBlue
                Me.TSB_Hse.BackColor = Color.AliceBlue
                Me.TSB_Sistemas.BackColor = Color.AliceBlue
            End If
        End If
    End Sub

#Region "Verificar actualización"
    Private Function validarArchivosServidor() As Boolean
        listarchivos.Add("ActivosFijos.dll")
        listarchivos.Add("Articulos.dll")
        listarchivos.Add("Auditoria.dll")
        listarchivos.Add("Bodega.dll")
        listarchivos.Add("Bodegas.dll")
        listarchivos.Add("Clasesbase.dll")
        listarchivos.Add("Compras.dll")
        listarchivos.Add("Conexión.dll")
        listarchivos.Add("DatosArticulos.dll")
        listarchivos.Add("DatosAuditoria.dll")
        listarchivos.Add("DatosBodegas.dll")
        listarchivos.Add("DatosClasesBase.dll")
        listarchivos.Add("DatosClasesBaseBuscar.dll")
        listarchivos.Add("DatosEntradaAlmacén.dll")
        listarchivos.Add("DatosImpresión.dll")
        listarchivos.Add("DatosOrdenCompra.dll")
        listarchivos.Add("DatosPersona.dll")
        listarchivos.Add("DatosProveedores.dll")
        listarchivos.Add("DatosRequisición.dll")
        listarchivos.Add("DatosSalidaAlmacén.dll")
        listarchivos.Add("Dscomunes.dll")
        listarchivos.Add("EntradaAlmacén.dll")
        listarchivos.Add("FormulariosClasesBase.dll")
        listarchivos.Add("FuncionesBase.dll")
        listarchivos.Add("Impresión.dll")
        listarchivos.Add("ImpresiónMateriales.dll")
        listarchivos.Add("Informe.dll")
        'listarchivos.Add("NetBarControl.dll")
        'listarchivos.Add("MessagingToolkit.QRCode.dll")
        'listarchivos.Add("FREE3OF9.TTF")
        listarchivos.Add("OrdenCompra.dll")
        listarchivos.Add("Persona.dll")
        listarchivos.Add("Proveedores.dll")
        listarchivos.Add("Requisición.dll")
        listarchivos.Add("SalidaAlmacén.dll")
        listarchivos.Add("VariablesBase.dll")
        listarchivos.Add("Facturas.dll")
        listarchivos.Add("DatosSisControl.dll")
        listarchivos.Add("SisControl.dll")
        listarchivos.Add("FormulariosSisControl.dll")
        listarchivos.Add("ImpresiónSisControl.dll")
        listarchivos.Add("DatosActivosFijos.dll")
        listarchivos.Add("FormulariosActivosFijos.dll")
        listarchivos.Add("FormulariosMaterialesEspeciales.dll")
        listarchivos.Add("MaterialesEspeciales.dll")
        listarchivos.Add("FormularioLicitaciones.dll")
        listarchivos.Add("Licitaciones.dll")
        listarchivos.Add("ImpresiónLicitaciones.dll")
        listarchivos.Add("FormulariosOrdenesTrabajo.dll")
        listarchivos.Add("FormularioReporteDiario.dll")
        listarchivos.Add("ReporteDiario.dll")
        listarchivos.Add("Contrato.dll")
        listarchivos.Add("FormularioContrato.dll")
        listarchivos.Add("OrdendeTrabajo.dll")
        listarchivos.Add("ImprimirControlProyecto.dll")
        listarchivos.Add("ImprimirMasterSoldadura.dll")
        listarchivos.Add("ImprimirRecursoHumano.dll")
        listarchivos.Add("FuncionesGoogle.dll")
        listarchivos.Add("Hse.dll")
        listarchivos.Add("FormulariosHse.dll")
        listarchivos.Add("Sistemas.dll")
        listarchivos.Add("FormulariosSistemas.dll")
        listarchivos.Add("ADMINRECURSOSISMOCOL.exe.config")
        listarchivos.Add("BouncyCastle.Crypto.dll")
        listarchivos.Add("Google.Apis.Auth.dll")
        listarchivos.Add("Google.Apis.Auth.PlatformServices.dll")
        listarchivos.Add("Google.Apis.Core.dll")
        listarchivos.Add("Google.Apis.dll")
        listarchivos.Add("Google.Apis.Drive.v3.dll")
        listarchivos.Add("Microsoft.Threading.Tasks.dll")
        listarchivos.Add("Newtonsoft.Json.dll")
        listarchivos.Add("SiscontrolDrive-Credentials.json")
        listarchivos.Add("System.Net.Http.dll")
        listarchivos.Add("System.Net.Http.Primitives.dll")
        listarchivos.Add("System.Threading.Tasks.dll")
        listarchivos.Add("Zlib.Portable.dll")
        listarchivos.Add("AnyDesk.exe")
        listarchivos.Add("Servidor.xml")
        listarchivos.Add("ADMINRECURSOSISMOCOL.exe")

        'Comparar archivo
        adapatador.Connection = VarBase.Conexion_Remota_Sql_Server
        adapatador.Fill(DsArchivos.DETALLEDOCUMENTO, -1)
        If DsArchivos.DETALLEDOCUMENTO.Rows.Count > 0 Then
            Dim fila As DataRow
            For i = 0 To DsArchivos.DETALLEDOCUMENTO.Rows.Count - 1
                fila = DsArchivos.DETALLEDOCUMENTO.Rows(i)
                If IO.File.Exists(_path & "\" & Trim(fila("NOMBREARCHIVO"))) = False Then
                    'Descomprimir y copiar
                    validarArchivosServidor = True
                    Exit Function
                End If
            Next
            For j = 0 To listarchivos.Count - 1
                Dim FechaArchivoLocal As Date = FechaModificacion(_path & "\" & listarchivos(j))
                Dim filasArchivo() As DataRow
                filasArchivo = DsArchivos.DETALLEDOCUMENTO.Select("NOMBREARCHIVO='" & listarchivos(j) & "'")
                If filasArchivo.Length > 0 Then
                    Dim filaarchivo As DataRow = filasArchivo(0)
                    If DateDiff(DateInterval.Second, FechaArchivoLocal, filaarchivo("FECHAEMISION")) > 0 Then
                        validarArchivosServidor = True
                        Exit Function
                    End If
                End If
            Next
        End If
        validarArchivosServidor = False
    End Function

    Function FechaModificacion(strRuta As String) As Date
        Dim fso, Archivo As Object
        fso = CreateObject("Scripting.FileSystemObject")
        Archivo = fso.GetFile(strRuta)
        FechaModificacion = Archivo.DateLastModified
        Archivo = Nothing
        fso = Nothing
    End Function
#End Region 'Verificar actualización

    ''' <summary>Rutina de ingreso a la aplicación.</summary>
    ''' <remarks>Verifica si hay actualizaciones disponibles y carga los datos de usuario.</remarks>
    Private Sub RutinaIngreso()
        _path = Application.StartupPath
        Using FrIngreso As New Fr_Ingreso
            FrIngreso.ShowDialog()
            If VarBase.IdPersona = -1 Then
                End
            End If
        End Using
        Dim IdPersona As Integer = VarBase.IdPersona

        If IdPersona <> 23 And IdPersona <> 0 And IdPersona <> 28093 Then
            Dim appPath As String = _path + "\Actualizador_BD.exe"
            Try
                If My.Computer.FileSystem.FileExists(appPath) Then
                    My.Computer.FileSystem.DeleteFile(appPath)
                End If
            Catch ex As Exception
            End Try
        End If

        Try
            'CLimpieza de archivos formato .TXT  carpeta raiz

            Dim Total = My.Computer.FileSystem.GetFiles(_path, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
            If IsDBNull(Total) Or Total.Count = 0 Then
            Else
                For Each archivos As String In My.Computer.FileSystem.GetFiles(_path, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
                    'Dim listaArchivo As New ArrayList()
                    'listaArchivo.Add(archivos)
                    If My.Computer.FileSystem.FileExists(archivos) Then
                        My.Computer.FileSystem.DeleteFile(archivos)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("No se realizó la operación de limpieza: " & ex.Message)
        End Try
        Dim InformacionCarpeta8 As New DirectoryInfo(_path + "\ArchivosPDF")
        If InformacionCarpeta8.Exists Then
            Try
                My.Computer.FileSystem.DeleteDirectory(_path + "\ArchivosPDF", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
            End Try
        End If

        If validarArchivosServidor() = True Then
            MsgBox("El sistema requiere ser actualizado, por favor espere un momento mientras se inicia el proceso." & vbCrLf & vbCrLf &
                   "Si tiene problemas de actualización envie un correo a soporteaplicaciones@ismocol.com suministrando datos de contacto.", MsgBoxStyle.Information, "Actualización")
            Dim frmMsgBx As New SuperMessageBox
            Dim strRetorno As String
            frmMsgBx.AgregarTitulo("Elija una opción")
            frmMsgBx.AgregarBoton("Descargar BD")
            '  frmMsgBx.AgregarBoton("Descargar FTP")
            frmMsgBx.AgregarBoton("Cancelar")
            frmMsgBx.AgregarMensaje("¿Que desea hacer?")
            strRetorno = frmMsgBx.Mostrar()
            If strRetorno = "Cancelar" Then
                Application.Exit()
                Exit Sub
            End If
            'If strRetorno = "Descargar FTP" Then
            '    Dim fbd As New Windows.Forms.FolderBrowserDialog
            '    fbd.Description = "Definir ubicación de descarga del archivo comprimido"
            '    fbd.ShowDialog()
            '    Dim directorio As String = fbd.SelectedPath
            '    Try
            '        If IO.Directory.Exists(directorio) = False Then
            '            IO.Directory.CreateDirectory(directorio)
            '        End If
            '    Catch ex As Exception
            '        MsgBox("Directorio no válido", MsgBoxStyle.Critical, "Directorio no válido")
            '        Application.Exit()
            '        Exit Sub
            '    End Try
            '    If IO.File.Exists(directorio & "\ADMINRECURSOSISMOCOL.rar") Then
            '        IO.File.Delete(directorio & "\ADMINRECURSOSISMOCOL.rar")
            '    End If
            '    Cursor.Current = Cursors.WaitCursor
            '    My.Computer.Network.DownloadFile("ftp://190.0.43.170/AdminRecursosComprimido/ADMINRECURSOSISMOCOL.rar", directorio & "\ADMINRECURSOSISMOCOL.rar", "adminrecursosismocol", "materiales")
            '    Cursor.Current = Cursors.WaitCursor
            '    MsgBox("Proceda a descomprimir el archivo " & directorio & "\ADMINRECURSOSISMOCOL.rar, inmediatamente intente ingresar nuevamente a la aplicación")
            '    End
            '    Application.Exit()
            'Else
            Application.Exit()
            Dim myProcess As New Process()
            myProcess.StartInfo.FileName = _path & "\" & "Actualizador.exe"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
            myProcess.Start()
            Exit Sub
            ' End If
        Else
            VarBase._path = Application.StartupPath
            VarBase.configRegionalSistema = CultureInfo.CurrentCulture
            If FunBase.Cargar_Configuración = False Then
                MsgBox("Existen problemas al intentar cargar la configuración de la aplicación en la base")
                End
            End If
            ValidarPermisosUsuario()
            Me.Text = "Sistema Integrado de Gestión de Materiales y Administración"
            'colocar la conexión actual como primera en la lista de servidor.xml


            If MostrarBienvenida() = "S" Then 'Verificar en las preferencias del usuario si tiene activada la preferencia "Mostrar la pantalla de bienvenida".
                Using frBienvenida As New Fr_Bienvenida
                    frBienvenida.frPadre = Me
                    frBienvenida.ShowDialog()
                End Using
            End If
            CargarInformacionBarraDeEstado()
        End If
    End Sub

    ''' <summary>Verifica si el usuario tiene activa la preferencia de mostrar la ventana de bienvenida.</summary>
    ''' <returns><c>True</c> si tiene activa la preferencia de mostrar ventana, <c>False</c> en caso contrario.</returns>
    Private Function MostrarBienvenida() As String
        Dim mostrar As String
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.MostrarBienvenida(@IDPERSONA)", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", VarBase.IdPersona)
        Try
            conexion.Open()
            mostrar = comando.ExecuteScalar()
            conexion.Close()
            If mostrar IsNot Nothing Then
                Return mostrar
            Else
                Return "S"
            End If
        Catch ex As Exception
            Return "S"
        Finally
            conexion.Close()
        End Try
    End Function

    ''' <summary>Asigna la información del usuario a la barra de estado.</summary>
    Public Sub CargarInformacionBarraDeEstado()
        If VarBase.TipoUsuario = 0 Then
            TSSL_Servidor_Usuario_BD.Text = "Servidor: " & VarBase.Servidor & _
                                            " | BD: " & VarBase.NombreBaseDatos & _
                                            " | Usuario BD: " & VarBase.Usuario & _
                                            " | Usuario: " & VarBase.Nombre_Usuario & _
                                            IIf(VarBase.IdBodegaActual <> -1, " | Bodega: " & VarBase.AbreviaturaBodegaActual, "") & _
                                            IIf(VarBase.IddependenciaSiscontrolActual <> -1, " | Base Siscontrol: " & Trim(VarBase.AbreviaturaBaseSiscontrol) & "  Dependencia: " & VarBase.NombreDependenciaSiscontrol, "")
        Else
            TSSL_Servidor_Usuario_BD.Text = "Usuario: " & VarBase.Nombre_Usuario & _
                                            IIf(VarBase.IdBodegaActual <> -1, " | Bodega: " & VarBase.AbreviaturaBodegaActual, "") + _
                                            IIf(VarBase.IddependenciaSiscontrolActual <> -1, " | Base Siscontrol: " & Trim(VarBase.AbreviaturaBaseSiscontrol) & "  Dependencia: " & VarBase.NombreDependenciaSiscontrol, "")
        End If
    End Sub

#Region "Validar Permisos"
    ''' <summary>Consulta los permisos del usuario en la base de datos y los asigna a la tabla PERMISOS de <c>VariablesBase</c></summary>
    ''' <param name="IDPERSONA">Identificador del usuario</param>
    Private Sub CargarPermisosBD(IDPERSONA As Integer)
        Try
            VarBase.PERMISOS.Clear()
            Dim Cadena_Consulta As String = "SELECT UP.CODIGOFUNCIONMODULO AS CODIGO, TIENEPERMISO " & _
                                            "FROM USU_PERMISO AS UP, USU_FUNCION AS UF " & _
                                            "WHERE IDPERSONA = " & VarBase.IdPersona & " " & _
                                            "AND UP.CODIGOFUNCIONMODULO = UF.CODIGOFUNCIONMODULO " & _
                                            "UNION " & _
                                            "SELECT CODIGOFUNCIONMODULO AS CODIGO, 0 " & _
                                            "FROM USU_FUNCION " & _
                                            "WHERE CODIGOFUNCIONMODULO NOT IN " & _
                                            "(SELECT CODIGOFUNCIONMODULO " & _
                                            "FROM USU_PERMISO " & _
                                            "WHERE IDPERSONA = " & VarBase.IdPersona & ")"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VarBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Adaptador.FillSchema(VarBase.PERMISOS, SchemaType.Source)
            Adaptador.Fill(VarBase.PERMISOS)
            Consulta.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>Verifica si el usuario cuenta con el permiso indicado como parámetro.</summary>
    ''' <param name="CODIGOFUNCIONMODULO">Código del permiso.</param>
    ''' <returns><c>True</c> si cuenta con el permiso, <c>False</c> en caso contrario.</returns>
    Private Function ConsultarPermiso(CODIGOFUNCIONMODULO As String) As Boolean
        Dim filas() As DataRow
        If Trim(CODIGOFUNCIONMODULO) = "" Then
            CODIGOFUNCIONMODULO = "-1"
        End If
        filas = VarBase.PERMISOS.Select("CODIGO=" & CODIGOFUNCIONMODULO)
        If filas.Length > 0 Then
            Dim fila As DataRow = filas(0)
            If fila("TIENEPERMISO") = 1 Then
                ConsultarPermiso = True
            Else
                ConsultarPermiso = False
            End If
        Else
            'Validar que no este en la lista de funciones
            ConsultarPermiso = True
        End If
    End Function

    ''' <summary>Consulta los permisos del usuario en la base de datos y habilita o deshabilita los controles del formulario principal.</summary>
    Private Sub ValidarPermisosUsuario()
        'Cargar Permisos de la Base de datos
        CargarPermisosBD(VarBase.IdPersona)

        MS_Principal.Enabled = ConsultarPermiso(MS_Principal.Tag)
        Ts_Principal.Enabled = ConsultarPermiso(Ts_Principal.Tag)
        '******************************************************************************************************

        'Habilitar Archivo
        TSMI_Archivo.Visible = ConsultarPermiso(TSMI_Archivo.Tag)


        'Cambio de usuario
        TSMI_CambiarDeUsuario.Visible = ConsultarPermiso(TSMI_CambiarDeUsuario.Tag)
        TSMI_CambiarDeUsuario.Enabled = ConsultarPermiso(TSMI_CambiarDeUsuario.Tag)

        'Cambio de contraseña
        TSMI_CambiarContraseña.Visible = ConsultarPermiso(TSMI_CambiarContraseña.Tag)
        TSMI_CambiarContraseña.Enabled = ConsultarPermiso(TSMI_CambiarContraseña.Tag)

        'Recargar Permisos
        RecargarPermisosToolStripMenuItem.Visible = ConsultarPermiso(RecargarPermisosToolStripMenuItem.Tag)
        RecargarPermisosToolStripMenuItem.Enabled = ConsultarPermiso(RecargarPermisosToolStripMenuItem.Tag)

        'Mostrar Bienvenida 
        MostrarPantallaDeBienvenidaToolStripMenuItem.Visible = ConsultarPermiso(MostrarPantallaDeBienvenidaToolStripMenuItem.Tag)
        MostrarPantallaDeBienvenidaToolStripMenuItem.Enabled = ConsultarPermiso(MostrarPantallaDeBienvenidaToolStripMenuItem.Tag)

        'mostrar directorio 
        TSMI_DirectorioTelefónico.Visible = ConsultarPermiso(TSMI_DirectorioTelefónico.Tag)
        TSMI_DirectorioTelefónico.Enabled = ConsultarPermiso(TSMI_DirectorioTelefónico.Tag)
        'Cerrar
        TSMI_Cerrar.Visible = ConsultarPermiso(TSMI_Cerrar.Tag)
        TSMI_Cerrar.Enabled = ConsultarPermiso(TSMI_Cerrar.Tag)

        'Salir
        TSMI_Salir.Visible = ConsultarPermiso(TSMI_Salir.Tag)
        TSMI_Salir.Enabled = ConsultarPermiso(TSMI_Salir.Tag)
        '******************************************************************************************************

        'Habilitar ver
        TSMI_Ver.Visible = ConsultarPermiso(TSMI_Ver.Tag)

        'Habilitar Personal
        TSMI_Personal.Enabled = ConsultarPermiso(TSMI_Personal.Tag)
        TSB_Personal.Visible = ConsultarPermiso(TSB_Personal.Tag)
        TSB_Personal.Enabled = ConsultarPermiso(TSB_Personal.Tag)

        'Habilitar Contrato
        TSB_Contrato.Visible = ConsultarPermiso(TSB_Contrato.Tag)
        TSB_Contrato.Enabled = ConsultarPermiso(TSB_Contrato.Tag)
        TSMI_Contrato.Enabled = ConsultarPermiso(TSMI_Contrato.Tag)

        'Habilitar Ordenes de Trabajo
        TSB_OrdenesTrabajo.Visible = ConsultarPermiso(TSB_OrdenesTrabajo.Tag)
        TSB_OrdenesTrabajo.Enabled = ConsultarPermiso(TSB_OrdenesTrabajo.Tag)
        TSMI_OrdenesTrabajo.Enabled = ConsultarPermiso(TSMI_OrdenesTrabajo.Tag)

        'Habilitar Reporte Diario
        TSB_ReporteDiario.Visible = ConsultarPermiso(TSB_ReporteDiario.Tag)
        TSB_ReporteDiario.Enabled = ConsultarPermiso(TSB_ReporteDiario.Tag)
        TSMI_ReporteDiario.Enabled = ConsultarPermiso(TSMI_ReporteDiario.Tag)

        'Habilitar Auditoria
        TSB_Auditoria.Visible = ConsultarPermiso(TSB_Auditoria.Tag)
        TSB_Auditoria.Enabled = ConsultarPermiso(TSB_Auditoria.Tag)
        TSMI_Auditoria.Enabled = ConsultarPermiso(TSMI_Auditoria.Tag)

        'Habilitar Siscontrol
        TSB_SisControl.Visible = ConsultarPermiso(TSB_SisControl.Tag)
        TSB_SisControl.Enabled = ConsultarPermiso(TSB_SisControl.Tag)
        TSMI_SisControl.Enabled = ConsultarPermiso(TSMI_SisControl.Tag)

        'Habilitar Licitaciones
        TSB_Licitaciones.Visible = ConsultarPermiso(TSB_Licitaciones.Tag)
        TSB_Licitaciones.Enabled = ConsultarPermiso(TSB_Licitaciones.Tag)
        TSMI_Licitaciones.Enabled = ConsultarPermiso(TSMI_Licitaciones.Tag)

        'Habilitar Articulos
        TSB_Articulos.Visible = ConsultarPermiso(TSB_Articulos.Tag)
        TSB_Articulos.Enabled = ConsultarPermiso(TSB_Articulos.Tag)
        TSMI_Artículos.Enabled = ConsultarPermiso(TSMI_Artículos.Tag)

        'Habilitar Compras
        TSB_Compras.Visible = ConsultarPermiso(TSB_Compras.Tag)
        TSB_Compras.Enabled = ConsultarPermiso(TSB_Compras.Tag)
        TSMI_Compras.Enabled = ConsultarPermiso(TSMI_Compras.Tag)

        'Habilitar Bodega
        TSB_Bodega.Visible = ConsultarPermiso(TSB_Bodega.Tag)
        TSB_Bodega.Enabled = ConsultarPermiso(TSB_Bodega.Tag)
        TSMI_Bodega.Enabled = ConsultarPermiso(TSMI_Bodega.Tag)

        'Habilitar Activos Fijos
        TSB_ActivosFijos.Visible = ConsultarPermiso(TSB_ActivosFijos.Tag)
        TSB_ActivosFijos.Enabled = ConsultarPermiso(TSB_ActivosFijos.Tag)
        TSMI_Activos.Enabled = ConsultarPermiso(TSMI_Activos.Tag)

        'Habilitar Materiales Especiales
        TSB_MaterialesEspeciales.Visible = ConsultarPermiso(TSB_MaterialesEspeciales.Tag)
        TSB_MaterialesEspeciales.Enabled = ConsultarPermiso(TSB_MaterialesEspeciales.Tag)
        TSMI_MaterialesEspeciales.Enabled = ConsultarPermiso(TSMI_MaterialesEspeciales.Tag)

        'Habilitar Informes
        TSMI_Informes.Enabled = ConsultarPermiso(TSMI_Informes.Tag)
        TSB_Informes.Visible = ConsultarPermiso(TSB_Informes.Tag)
        TSB_Informes.Enabled = ConsultarPermiso(TSB_Informes.Tag)

        'Habilitar Sistemas
        TSMI_Sistemas.Enabled = ConsultarPermiso(TSMI_Informes.Tag)
        TSB_Sistemas.Visible = ConsultarPermiso(TSB_Informes.Tag)
        TSB_Sistemas.Enabled = ConsultarPermiso(TSB_Informes.Tag)

        'Habilitar SSTA
        TSMI_Hse.Enabled = ConsultarPermiso(TSMI_Informes.Tag)
        TSB_Hse.Visible = ConsultarPermiso(TSB_Informes.Tag)
        TSB_Hse.Enabled = ConsultarPermiso(TSB_Informes.Tag)

        '******************************************************************************************************    

        'Habilitar Herramientas
        TSMI_Herramientas.Enabled = ConsultarPermiso(TSMI_Herramientas.Tag)

        'Habilitar Editar Maestro
        TSMI_EditarMaestro.Enabled = ConsultarPermiso(TSMI_EditarMaestro.Tag)

        'habilitar directorio telefonico 
        TSMI_DirectorioTelefónico.Enabled = ConsultarPermiso(TSMI_DirectorioTelefónico.Tag)

        'Habilitar Generales
        TSMI_Generales.Enabled = ConsultarPermiso(TSMI_Generales.Tag)

        'Habilitar Examenes
        TSMI_Examenes.Enabled = ConsultarPermiso(TSMI_Examenes.Tag)

        'Habilitar Configuracion Servidor
        TSMI_ConfigurarServidor.Enabled = ConsultarPermiso(TSMI_ConfigurarServidor.Tag)

        'Habilitar Administración de usuario
        TSMI_AdministraciónDeUsuario.Enabled = ConsultarPermiso(TSMI_AdministraciónDeUsuario.Tag)

        'Habilitar Asignar Permisos Consultas
        TSMI_AsignarPermisosConsultas.Enabled = ConsultarPermiso(TSMI_AsignarPermisosConsultas.Tag)
        '******************************************************************************************************    

        'Hablilitar Actualizar
        TSMI_Actualizar.Enabled = ConsultarPermiso(TSMI_Actualizar.Tag)

        'Habilitar Actualizar sistema
        TSMI_ActualizarSistema.Enabled = ConsultarPermiso(TSMI_ActualizarSistema.Tag)
        TSB_Actualizar.Visible = ConsultarPermiso(TSB_Actualizar.Tag)
        TSB_Actualizar.Enabled = ConsultarPermiso(TSB_Actualizar.Tag)
        '******************************************************************************************************    

        'Habilitar Opciones de Siscontrol
        TSMI_SisControl_Opciones.Enabled = ConsultarPermiso(TSMI_SisControl_Opciones.Tag)
        TSMI_BoletaDeSalida.Enabled = ConsultarPermiso(TSMI_BoletaDeSalida.Tag)
        TSMI_CargarBoletaSalida.Enabled = ConsultarPermiso(TSMI_CargarBoletaSalida.Tag)
        TSMI_CrearBoletaSalida.Enabled = ConsultarPermiso(TSMI_CrearBoletaSalida.Tag)
        TSMI_EditarBoletaSalida.Enabled = ConsultarPermiso(TSMI_EditarBoletaSalida.Tag)
        TSMI_ImprimirBoletaSalida.Enabled = ConsultarPermiso(TSMI_ImprimirBoletaSalida.Tag)
        TSMI_Dependencia.Enabled = ConsultarPermiso(TSMI_Dependencia.Tag)
        TSMI_CambiarDeDependencia.Enabled = ConsultarPermiso(TSMI_CambiarDeDependencia.Tag)
        TSMI_AsociarADependencia.Enabled = ConsultarPermiso(TSMI_AsociarADependencia.Tag)
        TSMI_UsuariosDeDependencia.Enabled = ConsultarPermiso(TSMI_UsuariosDeDependencia.Tag)
        TSMI_GestionarUsuariosDependencias.Enabled = ConsultarPermiso(TSMI_GestionarUsuariosDependencias.Tag)
        TSMI_DesprendiblesDeNomina.Enabled = ConsultarPermiso(TSMI_DesprendiblesDeNomina.Tag)
        TSMI_EnviarCorreos.Enabled = ConsultarPermiso(TSMI_EnviarCorreos.Tag)
        '******************************************************************************************************   

        'Habilitar opciones de Bodega
        TSMI_BodegaMateriales.Enabled = ConsultarPermiso(TSMI_BodegaMateriales.Tag)
        TSMI_CambiarDeBodega.Enabled = ConsultarPermiso(TSMI_CambiarDeBodega.Tag)
        '******************************************************************************************************    

        'Habilitar Configurar
        TSB_Configuración.Visible = ConsultarPermiso(TSB_Configuración.Tag)
        TSB_Configuración.Enabled = ConsultarPermiso(TSB_Configuración.Tag)

        '******************************************************************************************************    

        'Habilitar Hse
        TSB_Hse.Visible = ConsultarPermiso(TSB_Hse.Tag)
        TSMI_Hse.Visible = ConsultarPermiso(TSMI_Hse.Tag)
        TSB_Hse.Enabled = ConsultarPermiso(TSB_Hse.Tag)
        '******************************************************************************************************  

        'Habilitar Sistemas
        TSB_Sistemas.Visible = ConsultarPermiso(TSB_Sistemas.Tag)
        TSB_Sistemas.Enabled = ConsultarPermiso(TSB_Sistemas.Tag)
        TSMI_Sistemas.Visible = ConsultarPermiso(TSMI_Sistemas.Tag)

        'Habilitar Soporte
        TSB_Soporte.Visible = ConsultarPermiso(TSB_Sistemas.Tag)
        TSB_Soporte.Enabled = ConsultarPermiso(TSB_Sistemas.Tag)
        '******************************************************************************************************  

        'Si no tiene bodega asociada bloquear todos los modulos

        If VarBase.IdBodegaActual = -1 Then
            'Habilitar Articulos
            TSB_Articulos.Visible = False
            TSMI_Artículos.Enabled = False

            'Habilitar Compras
            TSB_Compras.Visible = False
            TSMI_Compras.Enabled = False

            'Habilitar Bodega
            TSB_Bodega.Visible = False
            TSMI_Bodega.Enabled = False

            'Habilitar Activos Fijos
            TSB_ActivosFijos.Visible = False
            TSMI_Activos.Enabled = False

            'Habilitar Materiales Especiales
            TSB_MaterialesEspeciales.Visible = False
            TSMI_MaterialesEspeciales.Enabled = False
        End If
        '******************************************************************************************************    

        'Organizar separadores de la barra

        If TSB_Personal.Visible = False AndAlso TSB_Contrato.Visible = False Then
            TSS_Personal_Barra.Visible = False
        End If

        TSS_OrdenesBarra.Visible = False
        If TSB_OrdenesTrabajo.Visible = False AndAlso TSB_ReporteDiario.Visible = False Then
            TSS_OrdenesBarra.Visible = False
        End If

        TSS_AditoriaBarra.Visible = False
        If TSB_Auditoria.Visible = True AndAlso TSB_SisControl.Visible = True Then
            TSS_AditoriaBarra.Visible = True
        End If

        TSS_Licitaciones.Visible = False
        If TSB_Licitaciones.Visible = True Then
            TSS_Licitaciones.Visible = True
        End If

        TSS_MaterialesBarra.Visible = False
        If TSB_Articulos.Visible = True AndAlso TSB_Compras.Visible = True AndAlso TSB_Bodega.Visible = True AndAlso TSB_ActivosFijos.Visible = True AndAlso TSB_MaterialesEspeciales.Visible = True Then
            TSS_MaterialesBarra.Visible = True
        End If

        TSS_InformeBarra.Visible = False
        If TSB_Actualizar.Visible = True Then
            TSS_InformeBarra.Visible = True
        End If

        TSS_ActivoFijoBarra.Visible = False
        If TSB_Informes.Visible = True Then
            TSS_ActivoFijoBarra.Visible = True
        End If
    End Sub
#End Region 'Validar Permisos

    ''' <summary>Oculta y cierra el control de usuario y las ventanas abiertas.</summary>
    Private Sub Limpiar_Panel_Controles()
        Try
            Dim Cu_Actual As Object
            Cu_Actual = Me.Pn_Formularios.Controls.Item(0)
            Cu_Actual.Actualizar_BaseDatos()
        Catch ex As Exception
        End Try
        Try
            While Me.Pn_Formularios.Controls.Count <> 0
                Me.Pn_Formularios.Controls.RemoveAt(0)
            End While
        Catch ex As Exception
        End Try
        Try
            For Each f As Form In Application.OpenForms
                If f.Name <> "Fr_Principal" Then
                    f.Close()
                End If
            Next
        Catch ex As Exception
        End Try
        For i = 0 To Me.Ts_Principal.Items.Count - 1
            Me.Ts_Principal.Items(i).BackColor = Color.FromName("AliceBlue")
        Next
    End Sub

#Region "Menú Archivo"
    Private Sub CambiarDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_CambiarDeUsuario.Click
        Using FrIngreso As New Fr_Ingreso
            FrIngreso.ShowDialog()
        End Using
        Limpiar_Panel_Controles()
        If FunBase.Cargar_Configuración = False Then
            MsgBox("Existen problemas al intentar cargar la configuración de la aplicación en la base")
            End
        End If
        ValidarPermisosUsuario()
        Me.Text = "Sistema Integrado de Gestión de Materiales y Administración"
        CargarInformacionBarraDeEstado()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_CambiarContraseña.Click
        Dim FrCambioClave As New Conexión.Fr_CambioClave
        FrCambioClave.ShowDialog()
        If FrCambioClave.CambioContaseña = True Then
            MsgBox("Se cambió la contraseña correctamente")
        End If
    End Sub

    Private Sub RecargarPermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarPermisosToolStripMenuItem.Click
        ValidarPermisosUsuario()
        Limpiar_Panel_Controles()
        DiferenciarEntorno()
    End Sub


    Private Sub MostrarPantallaDeBienvenidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarPantallaDeBienvenidaToolStripMenuItem.Click
        Using frBienvenida As New Fr_Bienvenida
            frBienvenida.frPadre = Me
            If frBienvenida.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Limpiar_Panel_Controles()
            End If
        End Using
    End Sub


    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Cerrar.Click
        Limpiar_Panel_Controles()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Salir.Click
        End
    End Sub
#End Region 'Menú Archivo

#Region "Menú Ver y Botones de Módulos"
    Private Sub PersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Personal.Click
        MostrarControl("Cu_Persona")
    End Sub

    Private Sub ToolStripButton_Personal_Click(sender As Object, e As EventArgs) Handles TSB_Personal.Click
        MostrarControl("Cu_Persona")
    End Sub

    Private Sub ContratoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Contrato.Click
        MostrarControl("Cu_Contrato")
    End Sub

    Private Sub ToolStripButtonContrato_Click(sender As Object, e As EventArgs) Handles TSB_Contrato.Click
        MostrarControl("Cu_Contrato")
    End Sub

    Private Sub OrdenesTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_OrdenesTrabajo.Click
        MostrarControl("Cu_OrdendeTrabajo")
    End Sub

    Private Sub ToolStripButton_OrdenesTrabajo_Click(sender As Object, e As EventArgs) Handles TSB_OrdenesTrabajo.Click
        MostrarControl("Cu_OrdendeTrabajo")
    End Sub

    Private Sub ReporteDiarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_ReporteDiario.Click
        MostrarControl("Cu_ReporteDiario")
    End Sub

    Private Sub ToolStripButton_ReporteTiempo_Click(sender As Object, e As EventArgs) Handles TSB_ReporteDiario.Click
        MostrarControl("Cu_ReporteDiario")
    End Sub

    Private Sub AuditoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Auditoria.Click
        MostrarControl("Cu_Auditoria")
    End Sub

    Private Sub ToolStripButton_Auditoria_Click(sender As Object, e As EventArgs) Handles TSB_Auditoria.Click
        MostrarControl("Cu_Auditoria")
    End Sub

    Private Sub SisControlToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TSMI_SisControl.Click
        MostrarControl("Cu_SisControl")
    End Sub

    Private Sub ToolStripButton_SisControl_Click(sender As Object, e As EventArgs) Handles TSB_SisControl.Click
        MostrarControl("Cu_SisControl")
    End Sub

    Private Sub LicitacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Licitaciones.Click
        MostrarControl("Cu_Licitaciones")
    End Sub

    Private Sub ToolStripButton_Licitaciones_Click(sender As Object, e As EventArgs) Handles TSB_Licitaciones.Click
        MostrarControl("Cu_Licitaciones")
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Artículos.Click
        MostrarControl("Cu_Articulos")
    End Sub

    Private Sub ToolStripButton_Articulos_Click(sender As Object, e As EventArgs) Handles TSB_Articulos.Click
        MostrarControl("Cu_Articulos")
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Compras.Click
        MostrarControl("Cu_Compras")
    End Sub

    Private Sub ToolStripButton_Compras_Click(sender As Object, e As EventArgs) Handles TSB_Compras.Click
        MostrarControl("Cu_Compras")
    End Sub

    Private Sub BodegaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Bodega.Click
        MostrarControl("Cu_Bodega")
    End Sub

    Private Sub ToolStripButton_Bodega_Click(sender As Object, e As EventArgs) Handles TSB_Bodega.Click
        MostrarControl("Cu_Bodega")
    End Sub

    Private Sub ActivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Activos.Click
        MostrarControl("Cu_ActivosFijos")
    End Sub

    Private Sub ToolStripButton_ActivosFijos_Click(sender As Object, e As EventArgs) Handles TSB_ActivosFijos.Click
        MostrarControl("Cu_ActivosFijos")
    End Sub

    Private Sub MaterialesEspecialesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_MaterialesEspeciales.Click
        MostrarControl("Cu_MaterialesEspeciales")
    End Sub

    Private Sub ToolStripButton_MaterialesEspeciales_Click(sender As Object, e As EventArgs) Handles TSB_MaterialesEspeciales.Click
        MostrarControl("Cu_MaterialesEspeciales")
    End Sub

    Private Sub ToolStripButton_Actualizar_Click(sender As Object, e As EventArgs) Handles TSB_Actualizar.Click
        Dim CuControl As Object
        Try
            CuControl = Me.Pn_Formularios.Controls.Item(0)
            CuControl.Cargar_Tabla()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InformesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Informes.Click
        MostrarControl("Cu_Informe")
    End Sub

    Private Sub ToolStripButton_Informes_Click(sender As Object, e As EventArgs) Handles TSB_Informes.Click
        MostrarControl("Cu_Informe")
    End Sub

    Private Sub HSE_Click(sender As Object, e As EventArgs) Handles TSB_Hse.Click
        MostrarControl("Cu_Hse")
    End Sub
    Private Sub TSMI_HSE_Click(sender As Object, e As EventArgs) Handles TSMI_Hse.Click
        MostrarControl("Cu_Hse")
    End Sub

    Private Sub TSB_Sistemas_Click(sender As Object, e As EventArgs) Handles TSB_Sistemas.Click
        MostrarControl("Cu_Sistemas")
    End Sub
    Private Sub TSMI_Sistemas_Click(sender As Object, e As EventArgs) Handles TSMI_Sistemas.Click
        MostrarControl("Cu_Sistemas")
    End Sub

    Private Sub TSB_Configuración_Click(sender As Object, e As EventArgs) Handles TSB_Configuración.Click
        Dim fr_config As New Fr_ConfiguracionBase
        fr_config.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles TSB_Soporte.Click
        Dim FrAcerca As New Fr_Acerca
        FrAcerca.ShowDialog()
    End Sub

    Private Sub TSB_AccesoRemoto_Click(sender As Object, e As EventArgs) Handles TSB_AccesoRemoto.Click
        FunBase.AbrirAccesoRemoto()
    End Sub

    Private Sub MostrarControl(Control As String)
        Try
            Dim Cu_Actual As Object
            Cu_Actual = Me.Pn_Formularios.Controls.Item(0)
            If Cu_Actual.name = Control Then
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        Limpiar_Panel_Controles()
        Dim CuControl As New Object
        Select Case Control
            Case "Cu_Informe"
                Me.TSB_Informes.Select()
                Me.TSB_Informes.BackColor = Color.LightSkyBlue
                Me.Text = "Informe -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Informe.Cu_Informe
            Case "Cu_Persona"
                Me.TSB_Personal.BackColor = Color.LightSkyBlue
                Me.Text = "Persona -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Persona.Cu_Persona
            Case "Cu_AdministraciónUsuarios"
                Me.Text = "Administración de Usuarios -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Conexión.Cu_AdministraciónUsuarios
            Case "Cu_Auditoria"
                Me.Text = "Auditoria -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Auditoria.Cu_Auditoria
            Case "Cu_Compras"
                Me.Text = "Compras -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Compras.Cu_Compras
            Case "Cu_Bodega"
                Me.Text = "Bodega -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Bodega.Cu_Bodega
            Case "Cu_ActivosFijos"
                Me.Text = "Activos Fijos -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New ActivosFijos.Cu_ActivosFijos
            Case "Cu_Articulos"
                Me.Text = "Artículos -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Articulos.Cu_Articulos
            Case "Cu_SisControl"
                Me.Text = "SisControl -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New SisControl.Cu_SisControl
            Case "Cu_MaterialesEspeciales"
                Me.Text = "Materiales Especiales -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New MaterialesEspeciales.Cu_MaterialesEspeciales
            Case "Cu_Licitaciones"
                Me.Text = "Licitaciones -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Licitaciones.Cu_Licitaciones
            Case "Cu_Contrato"
                Me.Text = "Contratos -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Contrato.Cu_Contrato
            Case "Cu_OrdendeTrabajo"
                Me.Text = "Ordenes de Trabajo -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New OrdendeTrabajo.Cu_OrdendeTrabajo
            Case "Cu_ReporteDiario"
                Me.Text = "Reporte Diario -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Reportediario.Cu_ReporteDiario
            Case "Cu_Hse"
                Me.Text = "HSE -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Hse.Cu_Hse
            Case "Cu_Sistemas"
                Me.Text = "Sistemas -- Sistema Integrado de Gestión de Materiales y Administración"
                CuControl = New Sistemas.Cu_Sistemas
            Case ""
        End Select
        Try
            CuControl.Comportamiento_Predeterminado()
        Catch ex As Exception
        End Try

        CuControl.Dock = DockStyle.Fill

        Try
            CuControl.Cargar_Tabla()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If IO.Directory.Exists("C:\FotoTemp") Then
            Try
                IO.Directory.Delete("C:\FotoTemp", True)
            Catch ex As Exception
            End Try
        End If
        Me.Pn_Formularios.Controls.Add(CuControl)
        CuControl.focus()
    End Sub
#End Region 'Menú Ver y Botones de Módulos

#Region "Menú Herramientas"
#Region "Editar tablas maestras"
    Private Sub GeneralesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Generales.Click
        If VarBase.TipoUsuario = 0 Then
            Limpiar_Panel_Controles()
            Dim CuMaestro As New Clasesbase.Cu_Maestro
            CuMaestro.Dock = DockStyle.Fill
            Me.Pn_Formularios.Controls.Add(CuMaestro)
        Else
            MsgBox("Este módulo solo puede ser accesado por un administrador.", MsgBoxStyle.Information, "MODULO MAESTRO")
        End If
    End Sub

    Private Sub TSMI_Examenes_Click(sender As Object, e As EventArgs) Handles TSMI_Examenes.Click

    End Sub
#End Region 'Editar tablas maestras

    Private Sub ConfigurarServidorToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TSMI_ConfigurarServidor.Click
        If VarBase.TipoUsuario = 0 Then
            Dim FrConfigurarServidor As New Conexión.Fr_Conexión
            FrConfigurarServidor.ShowDialog()
        Else
            MsgBox("Este módulo solo puede ser accesado por un administrador.", MsgBoxStyle.Information, "MODULO SERVIDOR")
        End If
    End Sub

    Private Sub AdministraciónDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_AdministraciónDeUsuario.Click
        MostrarControl("Cu_AdministraciónUsuarios")
    End Sub

    Private Sub AsignarPermisosConsultasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_AsignarPermisosConsultas.Click
        If VarBase.TipoUsuario = 0 Then
            Dim FrAsociarUsuarioConsulta As New Conexión.Fr_AsociarUsuarioConsulta
            FrAsociarUsuarioConsulta.ShowDialog()
        Else
            MsgBox("Este módulo solo puede ser accesado por un administrador.", MsgBoxStyle.Information, "MÓDULO SERVIDOR")
        End If
    End Sub
#End Region 'Menú Herramientas

#Region "Menú Actualizar"
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Actualizar.Click

    End Sub

    Private Sub ActualizarSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_ActualizarSistema.Click
        MsgBox("El sistema se actualizará...", MsgBoxStyle.Information, "Actualización")
        Application.Exit()
        Dim myProcess As New Process()
        myProcess.StartInfo.FileName = VarBase._path & "\" & "Actualizador.exe"
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        myProcess.Start()
    End Sub
#End Region 'Menú Actualizar

#Region "Menú SisControl"
#Region "Boleta de Salida"
    Private Sub CargarTablaBoletaSalida()
        Try
            Cu_Actual = Me.Pn_Formularios.Controls.Item(0)
            If Cu_Actual.name = "Cu_SisControl" Then
                Cu_Actual.CargarBoletaSalida()
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tsmi_Cargar_Click(sender As Object, e As EventArgs) Handles TSMI_CargarBoletaSalida.Click
        MostrarControl("Cu_SisControl")
        CargarTablaBoletaSalida()
    End Sub

    Private Sub Tsmi_Crear_Click(sender As Object, e As EventArgs) Handles TSMI_CrearBoletaSalida.Click
        Dim FrBoletaSalida As New FormulariosSisControl.Fr_BoletaSalida
        FrBoletaSalida.CargarDatos()
        FrBoletaSalida.ShowDialog()
        CargarTablaBoletaSalida()
    End Sub

    Private Sub Tsmi_Editar_Click(sender As Object, e As EventArgs) Handles TSMI_EditarBoletaSalida.Click
        Dim FrBoletaSalida As New FormulariosSisControl.Fr_BoletaSalida
        FrBoletaSalida.Editando = True
        Dim idboleta As Integer
        idboleta = Cu_Actual.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrBoletaSalida.IdBoletaSalida = idboleta
        FrBoletaSalida.CargarDatos()
        FrBoletaSalida.ShowDialog()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_ImprimirBoletaSalida.Click
        If MsgBox("¿Desea imprimir la Boleta de Salida", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(74)
            climpresiones.IdBOLETASALIDA = Cu_Actual.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
            climpresiones.FormatoImprimirSisControl(Array, True, False)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If
    End Sub
#End Region 'Boleta de Salida

#Region "Dependencia"
    Private Sub CambiarDeDependenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_CambiarDeDependencia.Click
        Dim IdDependenciaActual As String = VarBase.IddependenciaSiscontrolActual
        Dim FrCambiarDependencia As New FormulariosSisControl.Fr_CambiarDependencia
        FrCambiarDependencia.CargarDatos()
        FrCambiarDependencia.ShowDialog()
        If IdDependenciaActual <> VarBase.IddependenciaSiscontrolActual Then
            CargarInformacionBarraDeEstado()
            Limpiar_Panel_Controles()
        End If
    End Sub

    Private Sub AsociarADependenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_AsociarADependencia.Click
        Dim FrAsociarDependencia As New FormulariosSisControl.Fr_AsociarDependencia
        FrAsociarDependencia.TipoMovimiento = 1
        FrAsociarDependencia.Text = "Asociar a Dependencia"
        FrAsociarDependencia.CargarDatos()
        FrAsociarDependencia.ShowDialog()
    End Sub

    Private Sub UsuariosDeDependenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_UsuariosDeDependencia.Click
        Dim FrAsociarDependencia As New FormulariosSisControl.Fr_AsociarDependencia
        FrAsociarDependencia.TipoMovimiento = 2
        FrAsociarDependencia.Text = "Usuarios Dependencia"
        FrAsociarDependencia.CargarDatos()
        FrAsociarDependencia.ShowDialog()
    End Sub

    Private Sub Tsmi_GestionarUsuariosDependencias_Click(sender As Object, e As EventArgs) Handles TSMI_GestionarUsuariosDependencias.Click
        Dim frUsuariosDependencias As New FormulariosSisControl.Fr_UsuarioDependencia
        frUsuariosDependencias.ShowDialog()
    End Sub
#End Region 'Dependencia

#Region "Envío de Correos de Nómina"
    Private Sub EnviarCorreosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_EnviarCorreos.Click
        Dim FrCorreos As New FormulariosSisControl.Fr_EnviarCorreosNomina
        FrCorreos.ShowDialog()
    End Sub
#End Region 'Envío de Correos de Nómina
#End Region 'Menú SisControl

#Region "Menú Bodega"
    Private Sub Tsmi_CambiarDeBodega_Click(sender As Object, e As EventArgs) Handles TSMI_CambiarDeBodega.Click
        Dim IdBodegaActual As String = VarBase.IdBodegaActual
        Dim frCambiarBodega As New Bodegas.Fr_CambiarBodega
        frCambiarBodega.ShowDialog()
        If IdBodegaActual <> VarBase.IdBodegaActual Then
            CargarInformacionBarraDeEstado()
            Limpiar_Panel_Controles()
        End If
    End Sub
#End Region 'Menú Bodega

    Private Sub TSB_Actualizar_Paint(sender As Object, e As PaintEventArgs) Handles TSB_Actualizar.Paint
        If VarBase.NombreBaseDatos = "001_DESARROLLOISMOCOL" Then
            Ts_Principal.BackColor = Color.Salmon
            Me.TSB_ActivosFijos.BackColor = Color.Salmon
            Me.TSB_Actualizar.BackColor = Color.Salmon
            Me.TSB_Articulos.BackColor = Color.Salmon
            Me.TSB_Auditoria.BackColor = Color.Salmon
            Me.TSB_Bodega.BackColor = Color.Salmon
            Me.TSB_Compras.BackColor = Color.Salmon
            Me.TSB_Configuración.BackColor = Color.Salmon
            Me.TSB_Contrato.BackColor = Color.Salmon
            Me.TSB_Informes.BackColor = Color.Salmon
            Me.TSB_Licitaciones.BackColor = Color.Salmon
            Me.TSB_MaterialesEspeciales.BackColor = Color.Salmon
            Me.TSB_OrdenesTrabajo.BackColor = Color.Salmon
            Me.TSB_Personal.BackColor = Color.Salmon
            Me.TSB_ReporteDiario.BackColor = Color.Salmon
            Me.TSB_SisControl.BackColor = Color.Salmon
            Me.TSB_Soporte.BackColor = Color.Salmon
            Me.TSB_AccesoRemoto.BackColor = Color.Salmon
            Me.TSB_Hse.BackColor = Color.Salmon
            Me.TSB_Sistemas.BackColor = Color.Salmon
        End If
    End Sub

    Private Sub TSMI_DirectorioTelefónico_Click(sender As Object, e As EventArgs) Handles TSMI_DirectorioTelefónico.Click

        Limpiar_Panel_Controles()
        Dim CuDirectorio As New Clasesbase.Cu_DirectorioTelefonico
        CuDirectorio.Dock = DockStyle.Fill
        Me.Pn_Formularios.Controls.Add(CuDirectorio)
       
    End Sub

 
End Class


Public Class SuperMessageBox
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(7, 13)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(427, 42)
        Me.lblMensaje.TabIndex = 0
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SuperMessageBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 100)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblMensaje)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SuperMessageBox"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "SuperMessageBox"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim mintAncho As Integer = 100
    Dim alstBotones As New ArrayList
    Dim mstrRetorno As String


    '''<summary> Agrega un titulo al formulario </summary>
    '''<param name="Cadena">El titulo a agregar</param>
    Public Sub AgregarTitulo(Cadena As String)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Autor: angell
        'Fecha de Creación: 16/12/2004
        'Modificaciones:
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                DESCRIPCION DE LAS VARIABLES LOCALES
        '    (agregar nombre de variables y su descripción) 
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.Text = Cadena
    End Sub

    '''<summary> Agrega un boton al formulario </summary>
    '''<param name="Cadena">El titulo del boton</param>
    Public Sub AgregarBoton(Cadena As String)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Autor: angell
        'Fecha de Creación: 16/12/2004
        'Modificaciones:
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                DESCRIPCION DE LAS VARIABLES LOCALES
        '    (agregar nombre de variables y su descripción) 
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Dim cmdBoton As New System.Windows.Forms.Button

        cmdBoton.Text = Cadena
        cmdBoton.Height = 30 : cmdBoton.Width = mintAncho
        alstBotones.Add(cmdBoton)
    End Sub

    '''<summary> Agrega un mensaje al Formulario </summary>
    '''<param name="cadena">El texto del mensaje</param>
    Public Sub AgregarMensaje(cadena As String)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Autor: angell
        'Fecha de Creación: 16/12/2004
        'Modificaciones:
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                DESCRIPCION DE LAS VARIABLES LOCALES
        '    (agregar nombre de variables y su descripción) 
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        lblMensaje.Text = cadena
    End Sub

    '''<summary> Diseña el MessageBox </summary>
    '''<returns> Devuelve el campo TEXT del botón presionado</returns>
    Public Function Mostrar() As String
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Autor: angell
        'Fecha de Creación: 16/12/2004
        'Modificaciones:
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                DESCRIPCION DE LAS VARIABLES LOCALES
        '   cmdBoton        : un objeto boton temporal
        '   intContador     : la cantidad de botones del formulario
        '   intLargo        : la suma del largo de todos los botones mas sus espacios
        '   intI            : contador para el FOR-NEXT
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim cmdBoton As System.Windows.Forms.Button
        Dim intContador As Integer = alstBotones.Count
        Dim intLargo As Integer = intContador * (mintAncho + 10)
        Dim intI As Integer

        'seteamos el largo del formulario + 50 unidades
        Me.Width = intLargo + 50
        'seteamos el largo de la etiqueta del formulario
        Me.lblMensaje.Width = intLargo
        'centramos la etiqueta haciendola comensar en la posicion 25 (pues se agrego 50, 25 de cada lado al formulario)
        lblMensaje.Left = 25

        'para cada boton del arraylist, iteramos y lo agregamos al formulario 
        'asignándole el evento EVENTOCLICK que cargara en la variable
        'de retorno el contenido del campo TEXT del botón
        For intI = 0 To intContador - 1
            cmdBoton = CType(alstBotones(intI), Button)
            'situamos la posicion del boton en base a su orden
            cmdBoton.Location = New System.Drawing.Point((mintAncho + 10) * intI + 25, 60)

            'agregamos el controlador del evento click al boton
            AddHandler cmdBoton.Click, AddressOf EventoClick

            'seteamos al formulario como padre del control.
            Me.Controls.Add(cmdBoton)
        Next

        'centramos en la pantalla el formulario
        Me.CenterToScreen()
        'lo mostramos y esperamos hasta que se haya presionado un boton 
        'evento que cerrará el formulario
        Me.ShowDialog()

        'retornamos el valor de la variable de retorno
        Return mstrRetorno
    End Function

    '''<sumary>El evento que controla el click de los botones </sumary>
    Private Sub EventoClick(Sender As System.Object, e As EventArgs)
        mstrRetorno = CType(Sender, Button).Text
        Me.Close()
    End Sub

End Class 'SuperMessageBox