Public Class VariablesBase

    Public Shared Servidor As String
    Public Shared Usuario As String
    Public Shared Contraseña As String
    Public Shared NombreBaseDatos As String
    Public Shared _path As String
    Public Shared Directorio_Actual_Carga_Foto As String

    'Usuario del Sistema
    Public Shared TipoUsuario As Integer
    Public Shared Nombre_Usuario As String
    Public Shared IdPersona As Integer = -1
    Public Shared IdentificaciónUSuario As String

    Public Shared CentrosCostos As DataTable

    Public Shared Conexion_Remota_Sql_Server As New System.Data.SqlClient.SqlConnection

    Public Shared DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

    Public Shared style As System.Windows.Forms.DataGridViewCellStyle = New Windows.Forms.DataGridViewCellStyle()

    'Para los buscadores
    Public Shared TiempoRespuestaBuscador As Integer = 500

    'Para imprimir los permisos
    Public Shared PERMISOXIDPERMISO As New DataTable("PERMISO")

    'Variable utilizada para el modulo de Cu_BuscarPersona, tabla de búsqueda local
    Public Shared TablaPERSONABUSCAR As New DataTable("PERSONABUSCAR")

    'Variable para la carga de ciudades
    Public Shared TablaPOBLACIONES As DataTable

    'Variable para cargar los permisos
    Public Shared PERMISOS As New DataTable

    'Variables Para Gestión de Materiales
    Public Shared IdBodegaActual As Integer
    Public Shared NombreBodegaActual As String
    Public Shared AbreviaturaBodegaActual As String
    Public Shared DireccionBodegaActual As String
    Public Shared IdCentroCostoBodegaActual As Integer
    Public Shared TipoBodegaActual As String
    Public Shared EmpresaBodegaActual As Integer

    'Tabla local de artículos
    Public Shared TablaMAESTRAARTICULOS As New DataTable("ListarArticulos")
    Public Shared FechaArchivoXMLMaestroLocal As DateTime

    'Variables de SisControl
    Public Shared IdBaseSiscontrolActual As Integer
    Public Shared IddependenciaSiscontrolActual As Integer
    Public Shared IdCentroCostoSisControl As Integer
    Public Shared IddependenciaSiscontrolBusqueda As Integer
    Public Shared EmpresaSisControlActual As Integer
    Public Shared AbreviaturaBaseSiscontrol As String
    Public Shared NombreBaseSiscontrol As String
    Public Shared NombreDependenciaSiscontrol As String
    Public Shared CidadActual As String

    'Variables de Licitaciones
    Public Shared IdLicitacionCargada As Integer
    Public Shared PermisoLicitacionOtorgado As String

    'Variables para el manejo de archivos en el servidor de correspondencia
    '*********************************************************************************************
    'Public Shared RutaServidorLocalArchivo As String = "\\192.168.20.7\CORRESPONDENCIA"
    'Public Shared RutaServidorRemotoArchivo As String = "190.0.43.170"

    'Public Shared UsuarioServidorLocalArchivo As String
    'Public Shared UsuarioServidorRemotoArchivo As String = "CORRESPONDENCIA"

    'Public Shared ClaveServidorLocalArchivo As String
    'Public Shared ClaveServidorRemotoArchivo As String = "CORRESPONDENCIA"
    '*********************************************************************************************

    ''Variables para el manejo de fotos e imágenes

    'Fotos de visitantes
    '*********************************************************************************************
    'Public Shared RutaServidorLocalfotosvisitantes As String = "\\192.168.20.7\FOTOSVISITANTES"
    'Public Shared RutaServidorRemotofotosvisitantes As String = "190.0.43.170"

    ''Public Shared UsuarioServidorLocalfotosvisitantes As String
    'Public Shared UsuarioServidorRemotofotosvisitantes As String = "FOTOSVISITANTES"

    ''Public Shared ClaveServidorLocalfotosvisitantes As String
    'Public Shared ClaveServidorRemotofotosvisitantes As String = "FOTOSVISITANTES"
    '*********************************************************************************************

    'Fotos de artículos
    '*********************************************************************************************
    'Public Shared RutaServidorLocalfotosarticulos As String = "\\192.168.20.7\FOTOSARTICULOS"
    'Public Shared RutaServidorRemotofotosarticulos As String = "190.0.43.170"

    ''Public Shared UsuarioServidorLocalfotosarticulos As String
    'Public Shared UsuarioServidorRemotofotosarticulos As String = "FOTOSARTICULOS"

    ''Public Shared ClaveServidorLocalfotosarticulos As String
    'Public Shared ClaveServidorRemotofotosarticulos As String = "FOTOSARTICULOS"
    '*********************************************************************************************

    'Archivos de Facturación Electrónica
    '*********************************************************************************************
    'Public Shared RutaServidorLocalFacturaElectronica As String = "\\192.168.20.7\FACTURACIONELECTRONICA"
    'Public Shared RutaServidorRemotoFacturaElectronica As String = "190.0.43.170"

    ''Public Shared UsuarioServidorLocalFacturaElectronica As String
    'Public Shared UsuarioServidorRemotoFacturaElectronica As String = "CORRESPONDENCIA"

    ''Public Shared ClaveServidorLocalFacturaElectronica As String
    'Public Shared ClaveServidorRemotoFacturaElectronica As String = "CORRESPONDENCIA"
    '*********************************************************************************************

    'Fotos de personal
    '*********************************************************************************************
    'Public Shared RutaServidorLocalfotosPersona As String = "\\192.168.20.7\FOTOPERSONA"
    'Public Shared RutaServidorRemotofotosPersona As String = "190.0.43.170"

    ''Public Shared UsuarioServidorLocalfotosPersona As String
    'Public Shared UsuarioServidorRemotofotosPersona As String = "FOTOPERSONA"

    ''Public Shared ClaveServidorLocalfotosPersona As String
    'Public Shared ClaveServidorRemotofotosPersona As String = "FOTOPERSONA"
    '*********************************************************************************************

    'PDF requisiciones con el visto bueno de gerencia
    '*********************************************************************************************
    'Public Shared RutaServidorLocalRequisiciones As String = "\\192.168.20.7\REQUISICIONES"
    'Public Shared RutaServidorRemotoRequisiciones As String = "190.0.43.170"

    ''Public Shared UsuarioServidorLocalfotosPersona As String
    'Public Shared UsuarioServidorRemotoRequisiciones As String = "REQUISICIONES"

    ''Public Shared ClaveServidorLocalfotosPersona As String
    'Public Shared ClaveServidorRemotoRequisiciones As String = "REQUISICIONES"
    '*********************************************************************************************

    'PDF requisiciones con el visto bueno de gerencia
    '*********************************************************************************************
    'Public Shared RutaServidorLocalValidacionHojaDeVida As String = "\\192.168.20.7\VALIDACIONHOJADEVIDA"
    'Public Shared RutaServidorRemotoValidacionHojaDeVida As String = "190.0.43.170"

    ''Public Shared UsuarioServidorLocalfotosPersona As String
    'Public Shared UsuarioServidorRemotoValidacionHojaDeVida As String = "VALIDACIONHOJADEVIDA"

    ''Public Shared ClaveServidorLocalfotosPersona As String
    'Public Shared ClaveServidorRemotoValidacionHojaDeVida As String = "VALIDACIONHOJADEVIDA"
    '*********************************************************************************************

    'Envío de correos
    '*********************************************************************************************
    Public Shared correoCorrespondencia As String = "correspondencia@ismocol.com"
    Public Shared correoInformacionMateriales As String = "informacion-noreplicar@ismocol.com"
    Public Shared correoInformacionCompetencias As String = "competencias@ismocol.com"

    Public Shared correoContraseña As New Dictionary(Of String, String) From _
    { _
        {"correspondencia@ismocol.com", "Cor*5590"}, _
        {"informacion-noreplicar@ismocol.com", "Sap753150"}, _
        {"competencias@ismocol.com", "COMPETENCIAS987"} _
    }
    '*********************************************************************************************

    ''' <summary>
    ''' Configuración regional del equipo al momento de iniciar la aplicación.
    ''' </summary>
    ''' <remarks>
    ''' Se usa para verificar que los datos importados desde fuentes externas a la aplicación coinciden en formato con la configuración de SIGMA.
    ''' La configuración regional de SIGMA se define en el evento Load del formulario Fr_Principal.
    ''' </remarks>
    Public Shared configRegionalSistema As System.Globalization.CultureInfo

    Public Shared TiempoEsperaEnvioCorreo As Integer = 2000
    Public Shared TablaCorreosEnviados As New DataTable("CORREOS")

End Class