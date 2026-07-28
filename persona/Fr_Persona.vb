Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms

Public Class Fr_Persona
    ''' <summary>Indica si se está editando un registro de persona existente.</summary>
    ''' <value>Verdadero si se edita un registro existente. Falso si es un registro nuevo.</value>
    ''' <returns>Tipo de edición.</returns>
    Property Editando As Boolean = False
    ''' <summary>Identificador de la persona a editar.</summary>
    Property IdPersonaEditando As Integer = -1
    ''' <summary>Indica si se guardaron los datos en el formulario.</summary>
    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property
    Public GuardaFotoServidor As Boolean = True
    Private _guardado As Boolean = False
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Fila_Editar_Persona As DataRow
    Private dtParentesco As DataTable
    Private existeIdentificacion As Boolean = False
    Private tomoFoto As Boolean = False
    Private cargoFoto As Boolean = False
    Private EliminoFoto As Boolean = False
    Private fotoOriginal As Image
    Private fotoGrande As Image
    Private fotoMiniatura As Image
    Private dimensionFotoGrande As New Size(480, 640)
    Private dimensionFotoMiniatura As New Size(120, 160)
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Public Contrato As Integer
    Public EstadoContrato As String
    Public idconcepto As Integer = 0
    Private dtVacunaCopy As DataTable
    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Private Sub Fr_Persona_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Marcar_Cajas_Vacias()
    End Sub

    Private Sub Fr_Persona_Closed() Handles MyBase.FormClosed
        PictureBox_Foto_Persona.Image.Dispose()
        Dim appPath As String
        Try
            appPath = Application.StartupPath + "\Temp.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp2.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp3.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>Procedimiento para cargar las tablas maestras del formulario.</summary>
    Public Sub Cargar_Tablas()
        '-- 0 --> PERSONA
        '-- 1 --> PARIENTEPERSONA
        '-- 2 --> MA_TIPOIDENTIFICACION
        '-- 3 --> MA_TIPOESTADOCIVIL
        '-- 4 --> MA_TIPODISTRITOMILITAR
        '-- 5 --> MA_TIPOCLASELIBRETAMILITAR
        '-- 6 --> MA_TIPOCATEGORIALICENCIA
        '-- 7 --> MA_TIPOETNIA	
        '-- 8 --> MA_TIPOVIVIENDA
        '-- 9 --> MA_TIPOESTRATO
        '-- 10 --> MA_TIPOPROFESION
        '-- 11 --> MA_TIPOENTIDADEDUCATIVA
        '-- 12 --> MA_TIPONIVELEDUCATIVO
        '-- 13 --> MA_TIPOPARIENTE
        '-- 14 --> MA_TIPOOCUPACION
        '-- 15 --> MA_POBLACION
        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(1, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdPersonaEditando, IIf(IdPersonaEditando = -1, 1, 2))

        CB_TipoIdentificación.DataSource = dsCargar.Tables(2)
        CB_TipoIdentificación.ValueMember = "CODIGOTIPOIDENTIFICACION"
        CB_TipoIdentificación.DisplayMember = "NOMBRETIPOIDENTIFICACION"

        Cb_EstadoCivil.DataSource = dsCargar.Tables(3)
        Cb_EstadoCivil.ValueMember = "CODIGOTIPOESTADOCIVIL"
        Cb_EstadoCivil.DisplayMember = "NOMBRETIPOESTADOCIVIL"

        Cb_DistritoMilitar.DataSource = dsCargar.Tables(4)
        Cb_DistritoMilitar.ValueMember = "CODIGOTIPODISTRITOMILITAR"
        Cb_DistritoMilitar.DisplayMember = "NOMBRETIPODISTRITOMILITAR"

        Cb_TipoClaseLibretaMilitar.DataSource = dsCargar.Tables(5)
        Cb_TipoClaseLibretaMilitar.ValueMember = "CODIGOTIPOCLASELIBRETAMILITAR"
        Cb_TipoClaseLibretaMilitar.DisplayMember = "NOMBRETIPOCLASELIBRETAMILITAR"

        Cb_CategoríaLicencia.DataSource = dsCargar.Tables(6)
        Cb_CategoríaLicencia.ValueMember = "CODIGOTIPOCATEGORIALICENCIA"
        Cb_CategoríaLicencia.DisplayMember = "NOMBRETIPOCATEGORIALICENCIA"

        Cb_Etnia.DataSource = dsCargar.Tables(7)
        Cb_Etnia.ValueMember = "CODIGOTIPOETNIA"
        Cb_Etnia.DisplayMember = "NOMBRETIPOETNIA"

        Cb_TipoVivienda.DataSource = dsCargar.Tables(8)
        Cb_TipoVivienda.ValueMember = "CODIGOTIPOVIVIENDA"
        Cb_TipoVivienda.DisplayMember = "NOMBRETIPOVIVIENDA"

        Cb_Estrato.DataSource = dsCargar.Tables(9)
        Cb_Estrato.ValueMember = "CODIGOTIPOESTRATO"
        Cb_Estrato.DisplayMember = "NOMBRETIPOESTRARO"

        Cb_Profesión.DataSource = dsCargar.Tables(10)
        Cb_Profesión.ValueMember = "CODIGOTIPOPROFESION"
        Cb_Profesión.DisplayMember = "NOMBRETIPOPROFESION"
        Cb_Profesión.SelectedIndex = -1

        Cb_EntidadEducativa.DataSource = dsCargar.Tables(11)
        Cb_EntidadEducativa.ValueMember = "CODIGOTIPOENTIDADEDUCATIVA"
        Cb_EntidadEducativa.DisplayMember = "NOMBRETIPOENTIDADEDUCATIVA"
        Cb_EntidadEducativa.SelectedIndex = -1

        Cb_NivelEducativo.DataSource = dsCargar.Tables(12)
        Cb_NivelEducativo.ValueMember = "CODIGONIVELEDUCATIVO"
        Cb_NivelEducativo.DisplayMember = "NOMBRENIVELEDUCATIVO"

        DGVCBC_CODIGOTIPOPARIENTE.DataSource = dsCargar.Tables(13)
        DGVCBC_CODIGOTIPOPARIENTE.ValueMember = "CODIGOTIPOPARIENTE"
        DGVCBC_CODIGOTIPOPARIENTE.DisplayMember = "NOMBRETIPOPARIENTE"

        DGVCBC_CODIGOTIPOOCUPACION.DataSource = dsCargar.Tables(14)
        DGVCBC_CODIGOTIPOOCUPACION.ValueMember = "CODIGOTIPOOCUPACION"
        DGVCBC_CODIGOTIPOOCUPACION.DisplayMember = "NOMBRETIPOOCUPACION"



        DGVCBC_CODIGONACIONALIDAD.DataSource = dsCargar.Tables(21)
        DGVCBC_CODIGONACIONALIDAD.ValueMember = "CODIGONACIONALIDAD"
        DGVCBC_CODIGONACIONALIDAD.DisplayMember = "NACIONALIDAD"

        'DGVTBC_CODIGOLUGAREXPIDENTIFICACION.DataSource = dsCargar.Tables(15)
        'DGVTBC_CODIGOLUGAREXPIDENTIFICACION.ValueMember = "CODIGOPOBLACION"
        'DGVTBC_CODIGOLUGAREXPIDENTIFICACION.DisplayMember = "NOMBREPOBLACION"

        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.DataSource = dsCargar.Tables(16)
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.DataSource = dsCargar.Tables(17)
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.DataSource = dsCargar.Tables(18)
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedIndex = -1

        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.DataSource = dsCargar.Tables(19)
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedIndex = -1



        Cu_CiudadNacimiento.CargarDatos()
        Cu_CiudadExpedición.CargarDatos()
        Cu_CiudadDirección.CargarDatos()

        DTP_FechaExpedición.MaxDate = Date.Now
        DTP_FechaGraduación.MaxDate = Date.Now
        DTP_FechaNacimiento.MaxDate = Date.Now

        'Cargar parientes
        dtParentesco = dsCargar.Tables(1)
        DGV_Parentesco.DataSource = dtParentesco

        'cargar Vacunas
        Me.Cu_Vacuna.ModuloRegistro = "CONTRATO"
        Me.Cu_Vacuna.IdPersona = IdPersonaEditando
        Me.Cu_Vacuna.dtVacunaPersona = dsCargar.Tables(20)
        Me.Cu_Vacuna.contRegIni = dsCargar.Tables(20).Rows.Count

        If Editando = True Then
            Fila_Editar_Persona = dsCargar.Tables(0).Rows(0)
        Else
            Cu_CiudadExpedición.Cb_Ciudad.SelectedValue = 0
            Cu_CiudadNacimiento.Cb_Ciudad.SelectedValue = 0
            Cu_CiudadDirección.Cb_Ciudad.SelectedValue = 0
        End If
        Cb_TipoSangre.SelectedIndex = 0
    End Sub

    Private Sub Fr_Persona_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Editando Then
            Tx_PrimerNombre.Select()
        Else
            Tx_Identificacion.Select()
        End If
    End Sub

#Region "Cargar Datos Editar"
    ''' <summary>Asigna los datos de la persona a los controles del formulario.</summary>
    Public Sub CargarDatosPersona()
        Tx_PrimerNombre.Text = Trim(Fila_Editar_Persona("PRIMERNOMBRE"))
        Try
            Tx_SegundoNombre.Text = Trim(Fila_Editar_Persona("SEGUNDONOMBRE"))
        Catch
            Tx_SegundoNombre.Text = ""
        End Try
        Tx_PrimerApellido.Text = Trim(Fila_Editar_Persona("PRIMERAPELLIDO"))
        Try
            Tx_SegundoApellido.Text = Trim(Fila_Editar_Persona("SEGUNDOAPELLIDO"))
        Catch
            Tx_SegundoApellido.Text = ""
        End Try
        Try
            CB_TipoIdentificación.SelectedValue = Fila_Editar_Persona("CODIGOTIPOIDENTIFICACION")
        Catch
            CB_TipoIdentificación.SelectedIndex = -1
        End Try
        Try
            Tx_Identificacion.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(Fila_Editar_Persona("IDENTIFICACION")))
        Catch
            Tx_Identificacion.Text = ""
        End Try
        Try
            Cu_CiudadExpedición.Cb_Ciudad.SelectedValue = Fila_Editar_Persona("CODIGOLUGAREXPIDENTIFICACION")
        Catch
            Cu_CiudadExpedición.Cb_Ciudad.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHAEXPEDICIONIDENTIFICACION")) Then
            DTP_FechaExpedición.Value = DTP_FechaExpedición.MinDate
            DTP_FechaExpedición.Checked = False
        Else
            DTP_FechaExpedición.Checked = True
            DTP_FechaExpedición.Value = Fila_Editar_Persona("FECHAEXPEDICIONIDENTIFICACION")
        End If
        Try
            Cu_CiudadNacimiento.Cb_Ciudad.SelectedValue = Trim(Fila_Editar_Persona("CODIGOLUGARNACIMIENTO"))
        Catch
            Cu_CiudadNacimiento.Cb_Ciudad.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHANACIMIENTO")) Then
            DTP_FechaNacimiento.Value = DTP_FechaNacimiento.MinDate
            DTP_FechaNacimiento.Checked = False
        Else
            DTP_FechaNacimiento.Checked = True
            DTP_FechaNacimiento.Value = Fila_Editar_Persona("FECHANACIMIENTO")
        End If
        Try
            Cb_EstadoCivil.SelectedValue = Fila_Editar_Persona("CODIGOTIPOESTADOCIVIL")
        Catch
            Cb_EstadoCivil.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("GRUPOSANGUINEO")) = True Then
            Cb_TipoSangre.SelectedIndex = 0
        Else
            If Trim(Fila_Editar_Persona("GRUPOSANGUINEO")) = "SIN" Then
                Cb_TipoSangre.SelectedItem = "Sin Información"
            Else
                Cb_TipoSangre.SelectedItem = Trim(Fila_Editar_Persona("GRUPOSANGUINEO"))
            End If
        End If
        Try
            If Fila_Editar_Persona("GENERO") = "M" Then
                RadioButton_Masculino.Checked = True
            Else
                RadioButton_Femenino.Checked = True
            End If
        Catch
            RadioButton_Femenino.Checked = False
            RadioButton_Femenino.Checked = False
        End Try
        Try
            Tx_LibretaMilitar.Text = Trim(Fila_Editar_Persona("LIBRETAMILITAR"))
        Catch
            Tx_LibretaMilitar.Text = ""
        End Try
        Try
            Cb_DistritoMilitar.SelectedValue = Fila_Editar_Persona("CODIGOTIPODISTRITOMILITAR")
        Catch
            Cb_DistritoMilitar.SelectedIndex = -1
        End Try
        Try
            Cb_TipoClaseLibretaMilitar.SelectedValue = Fila_Editar_Persona("CODIGOTIPOCLASELIBRETAMILITAR")
        Catch
            Cb_TipoClaseLibretaMilitar.SelectedIndex = -1
        End Try
        Try
            Tx_licenciacondución.Text = Trim(Fila_Editar_Persona("LICENCIACONDUCCION"))
        Catch
            Tx_licenciacondución.Text = ""
        End Try
        Try
            Cb_CategoríaLicencia.SelectedValue = Fila_Editar_Persona("CODIGOTIPOCATEGORIALICENCIA")
        Catch
            Cb_CategoríaLicencia.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("VIGENCIALICENCIACONDUCCION")) Then
            DtP_VigenciaLicenciaConducción.Value = DtP_VigenciaLicenciaConducción.MinDate
            DtP_VigenciaLicenciaConducción.Checked = False
        Else
            DtP_VigenciaLicenciaConducción.Checked = True
            DtP_VigenciaLicenciaConducción.Value = Fila_Editar_Persona("VIGENCIALICENCIACONDUCCION")
        End If
        Try
            Tx_NumeroCalzado.Text = Fila_Editar_Persona("NUMEROCALZADO")
        Catch
            Tx_NumeroCalzado.Text = ""
        End Try
        Try
            Tx_TallaCamisa.Text = Fila_Editar_Persona("TALLACAMISA")
        Catch
            Tx_TallaCamisa.Text = ""
        End Try
        Try
            Tx_TallaPantalón.Text = Fila_Editar_Persona("TALLAPANTALON")
        Catch
            Tx_TallaPantalón.Text = ""
        End Try
        Try
            Tx_PesoKg.Text = Fila_Editar_Persona("PESOKILOGRAMOS")
        Catch
            Tx_PesoKg.Text = ""
        End Try
        Try
            Cb_Etnia.SelectedValue = Fila_Editar_Persona("CODIGOTIPOETNIA")
        Catch
            Cb_Etnia.SelectedIndex = -1
        End Try
        Try
            If Fila_Editar_Persona("ESEMPLEADO") = "S" Then
                Ck_Empleado.CheckState = CheckState.Checked
            Else
                Ck_Empleado.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("ESCLIENTE") = "S" Then
                Ck_Cliente.CheckState = CheckState.Checked
            Else
                Ck_Cliente.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("ESPROVEEDORCONTRATISTA") = "S" Then
                Ck_ContratistaProveedor.CheckState = CheckState.Checked
            Else
                Ck_ContratistaProveedor.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            Tx_Observación.Text = Fila_Editar_Persona("OBSERVACION")
            Tx_Observación.Tag = Fila_Editar_Persona("CODIGOOBSERVACION")
        Catch
            Tx_Observación.Text = ""
            Tx_Observación.Tag = -1
        End Try
        Try
            Tx_Dirección.Text = Trim(Fila_Editar_Persona("DIRECCION"))
        Catch
            Tx_Dirección.Text = ""
        End Try
        Try
            Cu_CiudadDirección.Cb_Ciudad.SelectedValue = Fila_Editar_Persona("CODIGOLUGARDIRECCION")
        Catch
            Cu_CiudadDirección.Cb_Ciudad.SelectedIndex = -1
        End Try
        Try
            Cb_TipoVivienda.SelectedValue = Fila_Editar_Persona("CODIGOTIPOVIVIENDA")
        Catch
            Cb_TipoVivienda.SelectedIndex = -1
        End Try
        Try
            Cb_Estrato.SelectedValue = Fila_Editar_Persona("CODIGOTIPOESTRATO")
        Catch
            Cb_Estrato.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("NUMEROCONTACTO")) = False Then
            Tx_NumeroContacto.Text = Trim(Fila_Editar_Persona("NUMEROCONTACTO"))
        Else
            Tx_NumeroContacto.Text = ""
        End If
        Try
            Tx_CorreoElectrónico.Text = Trim(Fila_Editar_Persona("CORREOELECTRONICO"))
        Catch
            Tx_CorreoElectrónico.Text = ""
        End Try
        Try
            Tx_Teléfono.Text = Trim(Fila_Editar_Persona("TELEFONO"))
        Catch
            Tx_Teléfono.Text = ""
        End Try
        Try
            Tx_TeléfonoMóvil.Text = Trim(Fila_Editar_Persona("TELEFONOMOVIL"))
        Catch
            Tx_TeléfonoMóvil.Text = ""
        End Try
        Try
            Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedValue = Fila_Editar_Persona("CODIGOENTIDADADMINEPS")
        Catch
            Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHAAFILIACIONEPS")) Then
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Value = Fila_Editar_Persona("FECHAAFILIACIONEPS")
        End If
        Try
            Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedValue = Fila_Editar_Persona("CODIGOENTIDADADMINAFP")
        Catch
            Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHAAFILIACIONAFP")) Then
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Value = Fila_Editar_Persona("FECHAAFILIACIONAFP")
        End If
        Try
            Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedValue = Fila_Editar_Persona("CODIGOENTIDADADMINAFC")
        Catch
            Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHAAFILIACIONAFC")) Then
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Value = Fila_Editar_Persona("FECHAAFILIACIONAFC")
        End If
        Try
            Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedValue = Fila_Editar_Persona("CODIGOENTIDADADMINEPV")
        Catch
            Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHAAFILIACIONEPV")) Then
            Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value = Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.MinDate
            Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = False
        Else
            Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = True
            Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value = Fila_Editar_Persona("FECHAAFILIACIONEPV")
        End If
        Try
            Cb_Profesión.SelectedValue = Fila_Editar_Persona("CODIGOPROFESION")
        Catch
            Cb_Profesión.SelectedIndex = -1
        End Try
        Try
            Cb_EntidadEducativa.SelectedValue = Fila_Editar_Persona("CODIGOTIPOENTIDADEDUCATIVA")
        Catch
            Cb_EntidadEducativa.SelectedIndex = -1
        End Try
        If IsDBNull(Fila_Editar_Persona("FECHAGRADUACION")) Then
            DTP_FechaGraduación.Value = DTP_FechaGraduación.MinDate
            DTP_FechaGraduación.Checked = False
        Else
            DTP_FechaGraduación.Checked = True
            DTP_FechaGraduación.Value = Fila_Editar_Persona("FECHAGRADUACION")
        End If
        Try
            Tx_TarjetaProfesional.Text = Trim(Fila_Editar_Persona("TARJETAPROFESIONAL"))
        Catch
            Tx_TarjetaProfesional.Text = ""
        End Try
        Try
            Cb_NivelEducativo.SelectedValue = Fila_Editar_Persona("CODIGONIVELEDUCATIVO")
        Catch
            Cb_NivelEducativo.SelectedIndex = -1
        End Try
        Try
            If Fila_Editar_Persona("CURSOINDUCCION") = "S" Then
                Ck_CursoInducción.CheckState = CheckState.Checked
            Else
                Ck_CursoInducción.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CURSOCONDUCTOR") = "S" Then
                Ck_CursoConductor.CheckState = CheckState.Checked
            Else
                Ck_CursoConductor.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CURSOOPERADOR") = "S" Then
                Ck_CursoOperador.CheckState = CheckState.Checked
            Else
                Ck_CursoOperador.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CURSOIZAJECARGAS") = "S" Then
                Ck_CursoIzajeCargas.CheckState = CheckState.Checked
            Else
                Ck_CursoIzajeCargas.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CURSOALTURAS") = "S" Then
                Ck_CursoAlturas.CheckState = CheckState.Checked
            Else
                Ck_CursoAlturas.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CURSOESPACIOSCONFINADOS") = "S" Then
                Ck_CursoEspaciosConfinados.CheckState = CheckState.Checked
            Else
                Ck_CursoEspaciosConfinados.Checked = False
            End If
        Catch
        End Try
        Try
            Tx_CursosAdicionales.Text = Trim(Fila_Editar_Persona("CURSOSADICIONALES"))
        Catch
            Tx_CursosAdicionales.Text = ""
        End Try
        Try
            If Fila_Editar_Persona("FIEBREAMARILLA") = "S" Then
                Ck_FiebreAmarilla.CheckState = CheckState.Checked
            Else
                Ck_FiebreAmarilla.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("TETANO1") = "S" Then
                Ck_Tetano1.CheckState = CheckState.Checked
            Else
                Ck_Tetano1.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("TETANO2") = "S" Then
                Ck_Tetano2.CheckState = CheckState.Checked
            Else
                Ck_Tetano2.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("TETANO3") = "S" Then
                Ck_Tetano3.CheckState = CheckState.Checked
            Else
                Ck_Tetano3.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("TETANO4") = "S" Then
                Ck_Tetano4.CheckState = CheckState.Checked
            Else
                Ck_Tetano4.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("TETANO5") = "S" Then
                Ck_Tetano5.CheckState = CheckState.Checked
            Else
                Ck_Tetano5.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CABEZAFAMILIA") = "S" Then
                Ck_CabezaHogar.CheckState = CheckState.Checked
            Else
                Ck_CabezaHogar.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            If Fila_Editar_Persona("CONDISCAPACIDAD") = "S" Then
                Ck_Discapacidad.CheckState = CheckState.Checked
            Else
                Ck_Discapacidad.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try
        Try
            Nud_PersonaCargo.Value = Fila_Editar_Persona("PERSONASACARGO")
        Catch
            Nud_PersonaCargo.Value = 0
        End Try
        Try
            NUD_NumeroHijos.Value = Fila_Editar_Persona("NUMEROHIJOS")
        Catch
            NUD_NumeroHijos.Value = 0
        End Try
        Try
            If Fila_Editar_Persona("COTIZO50SEMANASULTIMOAÑO") = "S" Then
                Ck_Cotizado50Semanas.CheckState = CheckState.Checked
            Else
                Me.Lb_FaltanSemanas.Visible = True
                Me.Nud_FaltanSemanas.Visible = True
                Ck_Cotizado50Semanas.CheckState = CheckState.Unchecked
            End If
        Catch
        End Try

        Try
            If IsDBNull(Fila_Editar_Persona("TOTALSEMANASAFP")) Then
                Nud_TotalSemanas.Value = -1
            Else
                Nud_TotalSemanas.Value = Fila_Editar_Persona("TOTALSEMANASAFP")
            End If
        Catch ex As Exception

        End Try



        If IsDBNull(Fila_Editar_Persona("SEMANASFALTAN")) OrElse Fila_Editar_Persona("SEMANASFALTAN") <= 0 Then
            Nud_FaltanSemanas.Value = 50
        Else
            Nud_FaltanSemanas.Value = Fila_Editar_Persona("SEMANASFALTAN")
        End If
        If IsDBNull(Fila_Editar_Persona("FECHAEXPEDICION50SEMANAS")) Then
            Dtp_Expedición50Semanas.Value = Dtp_Expedición50Semanas.MinDate
            Dtp_Expedición50Semanas.Checked = False
        Else
            Dtp_Expedición50Semanas.Checked = True
            Dtp_Expedición50Semanas.Value = Fila_Editar_Persona("FECHAEXPEDICION50SEMANAS")
        End If
        Try
            Dim byteBLOBData(-1) As [Byte]
            byteBLOBData = CType(Fila_Editar_Persona("FOTO"), [Byte]())
            Dim stmBLOBData As New MemoryStream(byteBLOBData)
            PictureBox_Foto_Persona.Image = Image.FromStream(stmBLOBData)
            stmBLOBData.Close()
        Catch
            PictureBox_Foto_Persona.Image = Im_Defecto.Images(0)
        End Try
        Tx_Identificacion.Enabled = False
    End Sub
#End Region

#Region "Guardar o actualizar datos"
    Private Function Guardar_Datos() As Boolean
        Try
            If Validar_Datos_Persona() Then
                Guardar_RegistroPersona()
            Else
                Guardar_Datos = False
                Exit Function
            End If
            Guardar_Datos = _guardado
        Catch ex As Exception
            Guardar_Datos = False
            MessageBox.Show(ex.Message, "Error al guardar los datos." & Environment.NewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function Validar_Datos_Persona() As Boolean
        'Complementario
        If Tx_PrimerNombre.Text = "" Then
            MsgBox("El primer nombre de la persona es obligatorio.", MsgBoxStyle.Information, "Primer Nombre")
            Tc_Persona.SelectedIndex = 0
            Tx_PrimerNombre.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Tx_PrimerApellido.Text = "" Then
            MsgBox("El primer apellido de la persona es obligatorio.", MsgBoxStyle.Information, "Primer Apellido")
            Tc_Persona.SelectedIndex = 0
            Tx_PrimerApellido.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If CB_TipoIdentificación.Text = "" Then
            MsgBox("Debe seleccionar un tipo de identificación.", MsgBoxStyle.Critical, "Tipo Identificación")
            Tc_Persona.SelectedIndex = 0
            CB_TipoIdentificación.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Trim(Tx_Identificacion.Text) = "" Then
            MsgBox("El número de identificación de la persona es obligatorio.", MsgBoxStyle.Critical, "Identificación")
            Tc_Persona.SelectedIndex = 0
            Tx_Identificacion.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cu_CiudadExpedición.Cb_Ciudad.Text = "" OrElse Cu_CiudadExpedición.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad o municipio de expedición de la identificación.", MsgBoxStyle.Critical, "Ciudad expedición de la cédula")
            Tc_Persona.SelectedIndex = 0
            Cu_CiudadExpedición.Cb_Ciudad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If DTP_FechaExpedición.Checked = False Then
            MsgBox("Debe seleccionar la fecha de expedición de la identificación.", MsgBoxStyle.Critical, "Fecha de expedición de la cédula")
            Tc_Persona.SelectedIndex = 0
            Validar_Datos_Persona = False
            DTP_FechaExpedición.Focus()
            Exit Function
        End If
        If DTP_FechaExpedición.Checked = True Then
            If DTP_FechaNacimiento.Checked = True Then
                If DTP_FechaNacimiento.Value > DTP_FechaExpedición.Value Then
                    MsgBox("La fecha de expedición de la identificación es menor a la fecha de nacimiento.", MsgBoxStyle.Critical, "Fecha de nacimiento")
                    Tc_Persona.SelectedIndex = 0
                    DTP_FechaNacimiento.Focus()
                    Validar_Datos_Persona = False
                    Exit Function
                End If
            End If
        End If
        If DTP_FechaNacimiento.Checked = False Then
            MsgBox("Debe seleccionar la fecha de nacimiento de la persona.", MsgBoxStyle.Critical, "Fecha de nacimiento")
            Tc_Persona.SelectedIndex = 0
            Validar_Datos_Persona = False
            DTP_FechaNacimiento.Focus()
            Exit Function
        End If
        If Cu_CiudadNacimiento.Cb_Ciudad.Text = "" OrElse Cu_CiudadNacimiento.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad de nacimiento.", MsgBoxStyle.Critical, "Ciudad de nacimiento")
            Tc_Persona.SelectedIndex = 0
            Cu_CiudadNacimiento.Cb_Ciudad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_EstadoCivil.Text = "" Then
            MsgBox("Debe seleccionar el estado civil.", MsgBoxStyle.Critical, "Estado civil")
            Tc_Persona.SelectedIndex = 0
            Cb_EstadoCivil.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_TipoSangre.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de sangre.", MsgBoxStyle.Critical, "Tipo de sangre")
            Tc_Persona.SelectedIndex = 0
            Cb_TipoSangre.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If RadioButton_Masculino.Checked = False AndAlso RadioButton_Femenino.Checked = False Then
            MsgBox("Debe seleccionar el género de la persona.", MsgBoxStyle.Information, "Género")
            Tc_Persona.SelectedIndex = 0
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_DistritoMilitar.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el distrito militar.", MsgBoxStyle.Critical, "Distrito militar")
            Tc_Persona.SelectedIndex = 0
            Cb_DistritoMilitar.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_TipoClaseLibretaMilitar.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de clase de la libreta militar.", MsgBoxStyle.Critical, "Tipo de clase Libreta militar")
            Tc_Persona.SelectedIndex = 0
            Cb_TipoClaseLibretaMilitar.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_CategoríaLicencia.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la categoría de licencia de conducción", MsgBoxStyle.Critical, "Categoría Licencia de conducción")
            Tc_Persona.SelectedIndex = 0
            Cb_CategoríaLicencia.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_Etnia.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la etnia", MsgBoxStyle.Critical, "Etnia")
            Tc_Persona.SelectedIndex = 0
            Cb_Etnia.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_Empleado.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si es o no empleado", MsgBoxStyle.Critical, "Es empleado")
            Tc_Persona.SelectedIndex = 0
            Ck_Empleado.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_Cliente.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si es o no cliente", MsgBoxStyle.Critical, "Es cliente")
            Tc_Persona.SelectedIndex = 0
            Ck_Cliente.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_ContratistaProveedor.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si es o no contratista o proveedor", MsgBoxStyle.Critical, "Es contratista o proveedor")
            Tc_Persona.SelectedIndex = 0
            Ck_ContratistaProveedor.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        'Contacto
        If Cu_CiudadDirección.Cb_Ciudad.Text = "" OrElse Cu_CiudadDirección.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad donde habita actualmente.", MsgBoxStyle.Critical, "Ciudad de residencia")
            Tc_Persona.SelectedIndex = 1
            Cu_CiudadDirección.Cb_Ciudad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_TipoVivienda.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de vivienda", MsgBoxStyle.Critical, "Tipo de vivienda")
            Tc_Persona.SelectedIndex = 1
            Cb_TipoVivienda.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_Estrato.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el nivel de estrato", MsgBoxStyle.Critical, "Nivel estrato")
            Tc_Persona.SelectedIndex = 1
            Cb_TipoVivienda.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Trim(Tx_TeléfonoMóvil.Text) = "" Then
            MsgBox("El teléfono móvil no puede estar vacío.", MsgBoxStyle.Critical, "Teléfono móvil")
            Tc_Persona.SelectedIndex = 1
            Tx_TeléfonoMóvil.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If IsNumeric(Tx_TeléfonoMóvil.Text) = False Then
            MsgBox("El teléfono móvil debe ser numérico.", MsgBoxStyle.Critical, "Telefono móvil")
            Tc_Persona.SelectedIndex = 0
            Tx_TeléfonoMóvil.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Tx_CorreoElectrónico.Text <> "" Then
            If Not FuncionesBase.FuncionesBase.validarDireccionCorreo(Tx_CorreoElectrónico.Text) Then
                MsgBox("El correo electrónico no cumple con el formato.", MsgBoxStyle.Critical, "Correo electrónico")
                Tc_Persona.SelectedIndex = 1
                Tx_CorreoElectrónico.Focus()
                Validar_Datos_Persona = False
                Exit Function
            End If
        End If
        'Competencias
        If Cb_Profesión.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la profesión.", MsgBoxStyle.Critical, "Profesión")
            Tc_Persona.SelectedIndex = 2
            Cb_Profesión.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_EntidadEducativa.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la entidad educativa.", MsgBoxStyle.Critical, "Entidad educativa")
            Tc_Persona.SelectedIndex = 2
            Cb_EntidadEducativa.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cb_NivelEducativo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el nivel educativo.", MsgBoxStyle.Critical, "Nivel educativo")
            Tc_Persona.SelectedIndex = 2
            Cb_NivelEducativo.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_CursoInducción.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene curso de inducción.", MsgBoxStyle.Critical, "Curso de inducción")
            Tc_Persona.SelectedIndex = 2
            Ck_CursoInducción.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_CursoConductor.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene curso de conductor.", MsgBoxStyle.Critical, "Curso de conductor")
            Tc_Persona.SelectedIndex = 2
            Ck_CursoConductor.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_CursoOperador.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene curso de operador.", MsgBoxStyle.Critical, "Curso de operador")
            Tc_Persona.SelectedIndex = 2
            Ck_CursoOperador.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_CursoIzajeCargas.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene curso de izaje de cargas.", MsgBoxStyle.Critical, "Curso de izaje de cargas")
            Tc_Persona.SelectedIndex = 2
            Ck_CursoIzajeCargas.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_CursoAlturas.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene curso de alturas.", MsgBoxStyle.Critical, "Curso de alturas")
            Tc_Persona.SelectedIndex = 2
            Ck_CursoAlturas.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_CursoEspaciosConfinados.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene curso de espacios confinados.", MsgBoxStyle.Critical, "Curso de espacios confinados")
            Tc_Persona.SelectedIndex = 2
            Ck_CursoEspaciosConfinados.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        'Seguridad social
        If Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.Text = "" OrElse Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar la Entidad Prestadora de Salud.", MsgBoxStyle.Critical, "Entidad Prestadora de Salud")
            Tc_Persona.SelectedIndex = 3
            Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.Text = "" OrElse Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar la Administradora de Fondo de Pensiones.", MsgBoxStyle.Critical, "Administradora de Fondo de Pensiones")
            Tc_Persona.SelectedIndex = 3
            Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.Text = "" OrElse Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar la Administradora de Fondo de Cesantías.", MsgBoxStyle.Critical, "Administradora de Fondo de Cesantías")
            Tc_Persona.SelectedIndex = 3
            Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If

        If Cu_Vacuna.dtVacunaPersona.Rows.Count > 0 Then
            dtVacunaCopy = Cu_Vacuna.dtVacunaPersona.Copy

            Dim contVacuna As Integer = 0
            'For i As Integer = 0 To dtVacunaCopy.Rows.Count - 1
            '    If dtVacunaCopy.Rows(i).Item("IDVACUNA") = 1 And dtVacunaCopy.Rows(i).Item("ACTIVA") = "S" Then
            '        contVacuna += 1
            '    ElseIf dtVacunaCopy.Rows(i).Item("IDVACUNA") = 2 And dtVacunaCopy.Rows(i).Item("ACTIVA") = "S" Then
            '        contVacuna += 1
            '    Else
            '    End If
            'Next
            'If contVacuna >= 2 Then
            '    Validar_Datos_Persona = True
            'Else
            '    MsgBox("Registro de vacunacion incompleto.", MsgBoxStyle.Critical, "Vacunas")
            '    Validar_Datos_Persona = False
            '    Tc_Persona.SelectedIndex = Tc_Persona.TabPages.IndexOf(Tp_Vacunas)
            '    Exit Function
            'End If

        Else
            Validar_Datos_Persona = False
            MsgBox("No se han registrado vacunas.", MsgBoxStyle.Critical, "Vacunas")
            Tc_Persona.SelectedIndex = Tc_Persona.TabPages.IndexOf(Tp_Vacunas)
            Exit Function
        End If

        If Ck_Cotizado50Semanas.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar ha cotizado 50 semanas en los ultimos tres años", MsgBoxStyle.Critical, "Ha cotizado 50 semanas en los ultimos tres años")
            Tc_Persona.SelectedIndex = 3
            Ck_Cotizado50Semanas.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If

        If Nud_TotalSemanas.Value = -1 Then
            MsgBox("No se han registrado el Total  semanas cotizadas en el fondo de pensiones ", MsgBoxStyle.Critical, "Total  semanas cotizadas en el fondo de pensiones")
            Tc_Persona.SelectedIndex = 3
            Nud_TotalSemanas.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If

        If IsNumeric(Nud_TotalSemanas.Text) = False Then
            MsgBox("El valor de Administración debe ser numérico", MsgBoxStyle.Critical, "Total  semanas cotizadas en el fondo de pensiones")
            Nud_TotalSemanas.Text = ""
            Me.Nud_TotalSemanas.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If

        If Nud_TotalSemanas.Value > 2500 Then
            MsgBox("EL total semanas contizadas en el fondo de pension debe ser menos a 2500 semanas", MsgBoxStyle.Critical, "Total  semanas cotizadas en el fondo de pensiones")
            Me.Nud_TotalSemanas.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If

        If Dtp_Expedición50Semanas.Checked = False Then
            MsgBox("Debe seleccionar la fecha de generación historia laboral ", MsgBoxStyle.Critical, "de generación historia laboral")
            Tc_Persona.SelectedIndex = 3
            Validar_Datos_Persona = False
            Dtp_Expedición50Semanas.Focus()
            Exit Function
        End If
        'Nucleo familiar
        If Ck_CabezaHogar.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si es cabeza de hogar.", MsgBoxStyle.Critical, "Cabeza de hogar")
            Tc_Persona.SelectedIndex = 5
            Ck_CabezaHogar.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Ck_Discapacidad.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si tiene alguna discapacidad.", MsgBoxStyle.Critical, "Discapacidad")
            Tc_Persona.SelectedIndex = 5
            Ck_Discapacidad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        'Validar Parentescos
        Validar_Datos_Persona = True
    End Function

    Private Sub Guardar_RegistroPersona()
        Dim cedula As String = QuitarFormatoIdentificacion(Trim(Tx_Identificacion.Text))
        'Llamar al procedimiento para crear el tipo categoría
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarPersona")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        If Not Editando Then
            Comando.Parameters("@ACCION").Value = 1
        Else
            Comando.Parameters("@ACCION").Value = 2
        End If
        Comando.Parameters.AddWithValue("@IDPERSONA", IdPersonaEditando)
        Comando.Parameters.AddWithValue("@PRIMERNOMBRE", Trim(Tx_PrimerNombre.Text))
        Comando.Parameters.AddWithValue("@SEGUNDONOMBRE", Trim(Tx_SegundoNombre.Text))
        Comando.Parameters.AddWithValue("@PRIMERAPELLIDO", Trim(Tx_PrimerApellido.Text))
        Comando.Parameters.AddWithValue("@SEGUNDOAPELLIDO", Trim(Tx_SegundoApellido.Text))
        Comando.Parameters.AddWithValue("@IDENTIFICACION", cedula)
        Comando.Parameters.AddWithValue("@CODIGOTIPOIDENTIFICACION", CB_TipoIdentificación.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOLUGAREXPIDENTIFICACION", Cu_CiudadExpedición.Cb_Ciudad.SelectedValue)
        Comando.Parameters.Add("@FECHAEXPEDICIONIDENTIFICACION", SqlDbType.Date)
        If DTP_FechaExpedición.Checked = False Then
            Comando.Parameters("@FECHAEXPEDICIONIDENTIFICACION").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAEXPEDICIONIDENTIFICACION").Value = DTP_FechaExpedición.Value
        End If
        Comando.Parameters.AddWithValue("@CODIGOLUGARNACIMIENTO", Cu_CiudadNacimiento.Cb_Ciudad.SelectedValue)
        Comando.Parameters.Add("@FECHANACIMIENTO", SqlDbType.Date)
        If DTP_FechaNacimiento.Checked = False Then
            Comando.Parameters("@FECHANACIMIENTO").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHANACIMIENTO").Value = DTP_FechaNacimiento.Value
        End If
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTADOCIVIL", Cb_EstadoCivil.SelectedValue)
        Comando.Parameters.AddWithValue("@GRUPOSANGUINEO", Cb_TipoSangre.Text)
        Comando.Parameters.Add("@GENERO", SqlDbType.Char, 1)
        If RadioButton_Masculino.Checked Then
            Comando.Parameters("@GENERO").Value = "M"
        Else
            Comando.Parameters("@GENERO").Value = "F"
        End If
        Comando.Parameters.AddWithValue("@LIBRETAMILITAR", Trim(Tx_LibretaMilitar.Text))
        Comando.Parameters.AddWithValue("@CODIGOTIPODISTRITOMILITAR", Cb_DistritoMilitar.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOCLASELIBRETAMILITAR", Cb_TipoClaseLibretaMilitar.SelectedValue)
        Comando.Parameters.AddWithValue("@LICENCIACONDUCCION", Trim(Tx_licenciacondución.Text))
        Comando.Parameters.AddWithValue("@CODIGOTIPOCATEGORIALICENCIA", Cb_CategoríaLicencia.SelectedValue)
        Comando.Parameters.Add("@VIGENCIALICENCIACONDUCCION", SqlDbType.Date)
        If DtP_VigenciaLicenciaConducción.Checked = False Then
            Comando.Parameters("@VIGENCIALICENCIACONDUCCION").Value = DBNull.Value
        Else
            Comando.Parameters("@VIGENCIALICENCIACONDUCCION").Value = DtP_VigenciaLicenciaConducción.Value
        End If
        Comando.Parameters.AddWithValue("@TALLAPANTALON", Trim(Tx_TallaPantalón.Text))
        Comando.Parameters.AddWithValue("@TALLACAMISA", Trim(Tx_TallaCamisa.Text))
        Comando.Parameters.AddWithValue("@NUMEROCALZADO", Trim(Tx_NumeroCalzado.Text))
        Comando.Parameters.AddWithValue("@PESOKILOGRAMOS", Trim(Tx_PesoKg.Text))
        Comando.Parameters.AddWithValue("@CODIGOTIPOETNIA", Cb_Etnia.SelectedValue)
        Comando.Parameters.AddWithValue("@ESEMPLEADO", IIf(Ck_Empleado.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@ESCLIENTE", IIf(Ck_Cliente.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@ESPROVEEDORCONTRATISTA", IIf(Ck_ContratistaProveedor.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CODIGOOBSERVACION", Tx_Observación.Tag)
        Comando.Parameters.AddWithValue("@DIRECCION", Trim(Tx_Dirección.Text))
        Comando.Parameters.AddWithValue("@CODIGOLUGARDIRECCION", Cu_CiudadDirección.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOVIVIENDA", Cb_TipoVivienda.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTRATO", Cb_Estrato.SelectedValue)
        Comando.Parameters.AddWithValue("@NUMEROCONTACTO", Trim(Tx_NumeroContacto.Text))
        Comando.Parameters.AddWithValue("@CORREOELECTRONICO", Trim(Tx_CorreoElectrónico.Text))
        Comando.Parameters.AddWithValue("@TELEFONO", Trim(Tx_Teléfono.Text))
        Comando.Parameters.AddWithValue("@TELEFONOMOVIL", Trim(Tx_TeléfonoMóvil.Text))
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINEPS", Cu_EntidadAdministradora_EPS.Cb_NombreAdministradora.SelectedValue)
        Comando.Parameters.Add("@FECHAAFILIACIONEPS", SqlDbType.Date)
        If Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONEPS").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONEPS").Value = Cu_EntidadAdministradora_EPS.Dtp_FechaAfiliacion.Value
        End If
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINAFP", Cu_EntidadAdministradora_AFP.Cb_NombreAdministradora.SelectedValue)
        Comando.Parameters.Add("@FECHAAFILIACIONAFP", SqlDbType.Date)
        If Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONAFP").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONAFP").Value = Cu_EntidadAdministradora_AFP.Dtp_FechaAfiliacion.Value
        End If
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINAFC", Cu_EntidadAdministradora_AFC.Cb_NombreAdministradora.SelectedValue)
        Comando.Parameters.Add("@FECHAAFILIACIONAFC", SqlDbType.Date)
        If Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Checked = False Then
            Comando.Parameters("@FECHAAFILIACIONAFC").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAAFILIACIONAFC").Value = Cu_EntidadAdministradora_AFC.Dtp_FechaAfiliacion.Value
        End If
        Comando.Parameters.Add("@CODIGOENTIDADADMINEPV", SqlDbType.VarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONEPV", SqlDbType.Date)
        If Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedIndex > 0 Then
            Comando.Parameters("@CODIGOENTIDADADMINEPV").Value = Cu_EntidadAdministradora_EPV.Cb_NombreAdministradora.SelectedValue
            If Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Checked = False Then
                Comando.Parameters("@FECHAAFILIACIONEPV").Value = DBNull.Value
            Else
                Comando.Parameters("@FECHAAFILIACIONEPV").Value = Cu_EntidadAdministradora_EPV.Dtp_FechaAfiliacion.Value
            End If
        Else
            Comando.Parameters("@CODIGOENTIDADADMINEPV").Value = DBNull.Value
            Comando.Parameters("@FECHAAFILIACIONEPV").Value = DBNull.Value
        End If
        Comando.Parameters.AddWithValue("@CODIGOPROFESION", Cb_Profesión.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOENTIDADEDUCATIVA", Cb_EntidadEducativa.SelectedValue)
        If DTP_FechaGraduación.Checked Then
            Comando.Parameters.AddWithValue("@FECHAGRADUACION", DTP_FechaGraduación.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAGRADUACION", DBNull.Value)
        End If
        Comando.Parameters.AddWithValue("@TARJETAPROFESIONAL", Trim(Tx_TarjetaProfesional.Text))
        Comando.Parameters.AddWithValue("@CODIGONIVELEDUCATIVO", Cb_NivelEducativo.SelectedValue)
        Comando.Parameters.AddWithValue("@CURSOINDUCCION", IIf(Ck_CursoInducción.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CURSOCONDUCTOR", IIf(Ck_CursoConductor.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CURSOOPERADOR", IIf(Ck_CursoOperador.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CURSOIZAJECARGAS", IIf(Ck_CursoIzajeCargas.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CURSOALTURAS", IIf(Ck_CursoAlturas.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CURSOESPACIOSCONFINADOS", IIf(Ck_CursoEspaciosConfinados.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CURSOSADICIONALES", Trim(Tx_CursosAdicionales.Text))
        Comando.Parameters.AddWithValue("@FIEBREAMARILLA", IIf(Ck_FiebreAmarilla.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@TETANO1", IIf(Ck_Tetano1.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@TETANO2", IIf(Ck_Tetano2.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@TETANO3", IIf(Ck_Tetano3.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@TETANO4", IIf(Ck_Tetano4.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@TETANO5", IIf(Ck_Tetano5.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CABEZAFAMILIA", IIf(Ck_CabezaHogar.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CONDISCAPACIDAD", IIf(Ck_Discapacidad.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@PERSONASACARGO", Nud_PersonaCargo.Value)
        Comando.Parameters.AddWithValue("@NUMEROHIJOS", NUD_NumeroHijos.Value)

        Comando.Parameters.AddWithValue("@COTIZO50SEMANASULTIMOAÑO", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEMANASFALTAN", DBNull.Value)
        If Ck_Cotizado50Semanas.Checked = True Then
            Comando.Parameters("@COTIZO50SEMANASULTIMOAÑO").Value = "S"
        Else
            Comando.Parameters("@COTIZO50SEMANASULTIMOAÑO").Value = "N"
            Comando.Parameters("@SEMANASFALTAN").Value = Nud_FaltanSemanas.Value
        End If
        Dim totalsemanasAFP As Decimal = Nud_TotalSemanas.Value
        Comando.Parameters.AddWithValue("@TOTALSEMANASAFP", totalsemanasAFP)
        Comando.Parameters.AddWithValue("@FECHAEXPEDICION50SEMANAS", Dtp_Expedición50Semanas.Value)
        Comando.Parameters.AddWithValue("@OBSERVACION", Trim(Tx_Observación.Text))
        Comando.Parameters.AddWithValue("@IDBASEREGISTRO", VariablesBase.VariablesBase.IdBaseSiscontrolActual)

        Dim Vista_Miniatura As Image
        If tomoFoto OrElse cargoFoto Then
            Vista_Miniatura = New Bitmap(fotoMiniatura)
        Else
            Dim imagen As New Bitmap(PictureBox_Foto_Persona.Image)
            Vista_Miniatura = imagen.GetThumbnailImage(120, 160, Nothing, New IntPtr())
        End If

        Vista_Miniatura.Save(Application.StartupPath + "\Temp2.jpg", ImageFormat.Jpeg)
        Vista_Miniatura.Dispose()
        Comando.Parameters.AddWithValue("@FOTOPERSONA", Devolver_BLOB())

        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@TIP_PARIENTEPERSONA", dtParentesco)
        Cu_Vacuna.dtVacunaPersona.AcceptChanges()
        dtVacunaCopy = Cu_Vacuna.dtVacunaPersona.Copy
        dtVacunaCopy.Columns.Remove("NOMPERSONAREGISTRO")
        dtVacunaCopy.Columns.Remove("IDPADRE")
        For i As Integer = 0 To dtVacunaCopy.Rows.Count - 1
            If dtVacunaCopy.Rows(i).Item("MODULOCREACION").ToString = "CONTRATO" Or dtVacunaCopy.Rows(i).Item("MODULOCREACION").ToString = "C" Then
                dtVacunaCopy.Rows(i).Item("MODULOCREACION") = "C"
            Else
                dtVacunaCopy.Rows(i).Item("MODULOCREACION") = "H"
            End If
        Next
        dtVacunaCopy.AcceptChanges()
        Cu_Vacuna.EsconderFilas()

        Comando.Parameters.AddWithValue("@TIP_VACUNAXPERSONA", dtVacunaCopy)

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Comando.Connection = conn
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
            Select Case Comando.Parameters("@IDMENSAJE").Value
                Case 0
                    MessageBox.Show("No se pudo realizar la operación.", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _guardado = False
                    Exit Sub
                Case 1
                    MessageBox.Show("El registro ha sido exitoso.", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _guardado = True
                    If (tomoFoto OrElse cargoFoto) AndAlso GuardaFotoServidor Then
                        Dim Vista_Foto As Image
                        If tomoFoto OrElse cargoFoto Then
                            Vista_Foto = New Bitmap(fotoGrande)
                            Vista_Foto.Save(Application.StartupPath + "\Temp3.jpg", ImageFormat.Jpeg)
                            Vista_Foto.Dispose()
                        End If
                        If Editando = False Then
                            GoogleDrive.SubirFoto(1, cedula, Application.StartupPath + "\Temp3.jpg", False)
                        Else
                            GoogleDrive.SubirFoto(1, cedula, Application.StartupPath + "\Temp3.jpg", True)
                        End If
                    Else
                        If IdPersonaEditando > 0 Then
                            If EliminoFoto Then
                                Dim CadenaConsulta As String = "DELETE FROM FOTOPERSONA WHERE IDPERSONA = " + IdPersonaEditando.ToString
                                Dim Consulta As New SqlClient.SqlCommand(CadenaConsulta)
                                Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                                Consulta.Connection = Conexion
                                Consulta.Connection.Open()
                                Consulta.ExecuteScalar()
                                Consulta.Connection.Close()
                            End If
                        End If
                    End If
                    Close()

                    If FuncionesBase.FuncionesBase.ConsultarPermiso("42") = True Then
                        If Contrato = -1 Then
                            Exit Sub
                        End If
                        If MsgBox("¿Desea registrar el contrato de la persona?", MsgBoxStyle.YesNo, "REGISTRAR CONTRATO") = MsgBoxResult.Yes Then

                            Dim adaptador As SqlDataAdapter
                            Dim dsMaestras As DataSet
                            Dim Identificacion As String = cedula
                            Comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
                            Comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
                            Comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
                            Comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
                            Comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
                            Comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
                            Comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
                            Comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
                            Comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

                            Comando.Parameters("@Accion").Value = 1
                            Comando.Parameters("@ACCESODENEGADO").Value = ""
                            Comando.Parameters("@IDPERSONA").Value = -1
                            Comando.Parameters("@IDENTIFICACION").Value = Replace(Identificacion, ".", "")
                            Comando.Parameters("@TIPOMODULO").Value = "P"
                            Comando.Parameters("@TIPOOBSERVACION").Value = ""
                            Comando.Parameters("@OBSERVACION").Value = ""
                            Comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

                            Comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

                            adaptador = New SqlDataAdapter(Comando)
                            dsMaestras = New DataSet
                            Try
                                conexion.Open()
                                adaptador.Fill(dsMaestras)
                                conexion.Close()

                                If Comando.Parameters("@IDMENSAJE").Value = 1 Then
                                    Dim fila As DataRow
                                    fila = dsMaestras.Tables(0).Rows(0)

                                    If fila("ACCESODENEGADO") = "S" Then
                                        MessageBox.Show("Esta persona tiene el acceso denegado.", "Estado Ismocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                conexion.Close()
                            End Try

                            Dim idPersona As Integer = -1
                            idPersona = IdPersonaEditando
                            Dim Comando1 As New SqlClient.SqlCommand("dbo.VerificarConceptoParaContratar")
                            Comando1.CommandType = CommandType.StoredProcedure
                            Comando1.Parameters.AddWithValue("@IDPERSONA", idPersona)
                            Dim msgParam1 As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                            msgParam1.Direction = ParameterDirection.Output
                            Comando1.Parameters.Add(msgParam1)
                            Dim conn1 As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                            Try
                                conn1.Open()
                                Comando1.Connection = conn1
                                Comando1.ExecuteNonQuery()
                                conn1.Close()
                                idconcepto = Comando1.Parameters("@IDMENSAJE").Value
                                Select Case idconcepto
                                    Case 0
                                    Case 1 '
                                        If MsgBox("El Candidato que va a Contratar no tiene registro de Ördenes de exámenes de ingreso recientes. ¿Desea Continuar?.", MsgBoxStyle.YesNo, "Conceptos  Médicos") = MsgBoxResult.Yes Then
                                        Else
                                            Exit Sub
                                        End If
                                    Case 2 '
                                        MessageBox.Show("El Candidato que va a Contratar tiene Órdenes de Exámenes de ingreso pendientes por asignar Concepto Médico. En caso de requerir ayuda deberá comunicarse con Administración Bucaramanga, para recibir indicaciones al respecto.", "Conceptos  Médicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    Case 3  ' 
                                        MessageBox.Show("El Candidato que va a Contratar tiene uno o más Conceptos Médicos recientes con indicación de ''No Continuar el Proceso''. En caso de requerir ayuda deberá comunicarse con Administración Bucaramanga, para recibir indicaciones al respecto.", "Conceptos  Médicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    Case 4
                                        If MsgBox("El Candidato tiene los Conceptos Médicos de ingreso con fechas superiores a siete (07) días, se debe verificar la vigencia de los Exámenes. ¿Desea continuar?", MsgBoxStyle.YesNo, "Conceptos  Médicos") = MsgBoxResult.Yes Then
                                        Else
                                            Exit Sub
                                        End If
                                End Select
                            Catch ex As Exception
                                MsgBox(ex.ToString)
                            End Try

                            'si aun no se le han registrado contratos o no tiene contratos activos.

                            Dim Persona As New Cu_Persona

                            If Contrato = 0 OrElse _
                               EstadoContrato = "T" OrElse _
                                EstadoContrato = "N" Then
                                Dim frcontratar As New FormularioContrato.Fr_Contratar
                                frcontratar.IdPersonaContratar = IdPersonaEditando
                                'frcontratar.Label_Nombre.Text = "nombre: " +
                                'frcontratar.Label_Cedula.Text = "identificacion: " + Identificacion
                                Select Case idconcepto
                                    Case 0
                                    Case 1 '
                                        frcontratar.Tx_Observación.Text = "El trabajador fue vinculado sin examen médico de ingreso reciente"
                                    Case 2 '
                                    Case 3 ' 
                                    Case 4 '
                                        frcontratar.Tx_Observación.Text = "El trabajador fue vinculado con un concepto médico superior a siete (07) días"
                                End Select
                                frcontratar.Cargar_Tablas()
                                frcontratar.TipoAccion = "I"
                                frcontratar.ShowDialog()
                                If frcontratar.Guardado Then
                                    Persona.Cargar_Personas()
                                End If
                            Else
                                Select Case EstadoContrato
                                    Case "A"
                                        MessageBox.Show("esta persona tiene un contrato activo.", "contrato activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Case "E"
                                        MessageBox.Show("esta persona tiene un contrato extendido.", "contrato extendido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Case "I"
                                        MessageBox.Show("esta persona tiene un contrato inactivo.", "contrato inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Case "S"
                                        MessageBox.Show("esta persona tiene un contrato suspendido.", "contrato suspendido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End Select
                            End If
                        End If
                    End If
                Case 2
                    'Cuando es nuevo y ya existe la identificación o cuando se está modificando y la identificación ya existe.
                    MessageBox.Show("No se pudo realizar la operación, ya existe una persona registrada con ese número de identificación.", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _guardado = False
                    Exit Sub
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        PictureBox_Foto_Persona.Image.Dispose()
        Dim appPath As String
        Try
            appPath = Application.StartupPath + "\Temp.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp2.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp3.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ExamenesPendientesConcepto(idPersona As Integer) As DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ExamenesPendientesConcepto(@IDPERSONA)", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtPendientes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtPendientes)
            Return dtPendientes
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Private Function Devolver_BLOB() As Byte()
        Dim fs As New FileStream(Application.StartupPath + "\Temp2.jpg", FileMode.OpenOrCreate, FileAccess.Read)
        Dim MyData(fs.Length) As Byte
        fs.Read(MyData, 0, fs.Length)
        fs.Close()
        Devolver_BLOB = MyData
    End Function
#End Region 'Guardar o actualizar datos

#Region "Foto Personal"
    Private Sub Bt_CargarFoto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_CargarFoto.Click
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = VariablesBase.VariablesBase.Directorio_Actual_Carga_Foto
        openFileDialog1.Filter = "Archivo bmp (*.bmp)|*.bmp|Archivos jpg (*.jpg)|*.jpg"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            VariablesBase.VariablesBase.Directorio_Actual_Carga_Foto = openFileDialog1.FileName
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    'Cargar Imagen en el PictureBox
                    Try
                        Cargar_foto(openFileDialog1.FileName)
                        cargoFoto = True
                    Catch ex As Exception
                        MessageBox.Show("La imagen no es valida, por favor intente nuevamente." & Environment.NewLine & ex.Message, "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("No se pudo cargar la imagen." & Environment.NewLine & ex.Message)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Button_Sin_Imagen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Sin_Imagen.Click
        PictureBox_Foto_Persona.Image = Im_Defecto.Images(0)
        tomoFoto = False
        cargoFoto = False
        EliminoFoto = True
    End Sub

    Private Function Cargar_foto(ByVal Archivo_Foto As String) As Boolean
        'Cargar la imagen
        If IO.File.Exists(Archivo_Foto) = True Then
            Dim fs As FileStream
            fs = New FileStream(Archivo_Foto, IO.FileMode.Open, IO.FileAccess.Read)
            fotoOriginal = Image.FromStream(fs)
            fotoGrande = FuncionesBase.FuncionesBase.CropCenterImage(fotoOriginal, dimensionFotoGrande)
            fotoMiniatura = FuncionesBase.FuncionesBase.CropCenterImage(fotoOriginal, dimensionFotoMiniatura)
            PictureBox_Foto_Persona.Image = fotoMiniatura
            fs.Close()
            Cargar_foto = True
        Else
            PictureBox_Foto_Persona.Image = Im_Defecto.Images(0)
            Cargar_foto = False
        End If
    End Function
#End Region 'Foto Personal

    Private Sub Button_Aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Aceptar.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Guardar_Datos() = True Then
            Close()
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Sub Button_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Cancelar.Click
        Close()
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Tx_PrimerNombre.GotFocus, Tx_SegundoNombre.GotFocus, Tx_PrimerApellido.GotFocus, _
        Tx_SegundoApellido.GotFocus, Tx_Identificacion.GotFocus, _
        Tx_Dirección.GotFocus, Tx_NumeroContacto.GotFocus, Tx_TeléfonoMóvil.GotFocus, Tx_CorreoElectrónico.GotFocus, _
        Tx_Observación.GotFocus

        Try
            DirectCast(sender, TextBox).BackColor = Color.MintCream
        Catch
        End Try
    End Sub

    Private Sub Caja_Texto_LostFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Tx_PrimerNombre.LostFocus, Tx_SegundoNombre.LostFocus, Tx_PrimerApellido.LostFocus, _
        Tx_SegundoApellido.LostFocus, Tx_Identificacion.LostFocus, _
        Tx_Dirección.LostFocus, Tx_NumeroContacto.LostFocus, Tx_TeléfonoMóvil.LostFocus, Tx_CorreoElectrónico.LostFocus, _
        Tx_Observación.LostFocus

        Try
            Dim caja As TextBox = sender
            caja.BackColor = Color.White
            If caja.Text = "" OrElse caja.Text = "SIN INFORMACION" OrElse caja.Text = "SE DESCONOCE" OrElse caja.Text = "SIN IDENTIFICAR" Then
                caja.BackColor = Color.Salmon
            End If
        Catch
        End Try
    End Sub

    Private Sub Marcar_Cajas_Vacias()
        If Cu_CiudadDirección.Cb_Ciudad.Text = "SIN INFORMACION" Then
            Cu_CiudadDirección.Cb_Ciudad.BackColor = Color.Salmon
        Else
            Cu_CiudadDirección.Cb_Ciudad.BackColor = Color.White
        End If
        If Tx_PrimerNombre.Text = "" Then
            Tx_PrimerNombre.BackColor = Color.Salmon
        Else
            Tx_PrimerNombre.BackColor = Color.White
        End If
        If Tx_SegundoNombre.Text = "" Then
            Tx_SegundoNombre.BackColor = Color.Salmon
        Else
            Tx_SegundoNombre.BackColor = Color.White
        End If
        If Tx_PrimerApellido.Text = "" Then
            Tx_PrimerApellido.BackColor = Color.Salmon
        Else
            Tx_PrimerApellido.BackColor = Color.White
        End If
        If Tx_SegundoApellido.Text = "" Then
            Tx_SegundoApellido.BackColor = Color.Salmon
        Else
            Tx_SegundoApellido.BackColor = Color.White
        End If
        If CB_TipoIdentificación.Text = "SIN INFORMACION" Then
            CB_TipoIdentificación.BackColor = Color.Salmon
        Else
            CB_TipoIdentificación.BackColor = Color.White
        End If
        If Tx_Identificacion.Text = "" Then
            Tx_Identificacion.BackColor = Color.Salmon
        Else
            Tx_Identificacion.BackColor = Color.White
        End If
        If Cu_CiudadExpedición.Cb_Ciudad.Text = "SIN INFORMACION" Then
            Cu_CiudadExpedición.BackColor = Color.Salmon
        Else
            Cu_CiudadExpedición.BackColor = Color.White
        End If
        If Tx_Dirección.Text = "" Then
            Tx_Dirección.BackColor = Color.Salmon
        Else
            Tx_Dirección.BackColor = Color.White
        End If
        If Tx_TeléfonoMóvil.Text = "" Then
            Tx_TeléfonoMóvil.BackColor = Color.Salmon
        Else
            Tx_TeléfonoMóvil.BackColor = Color.White
        End If
        If Tx_CorreoElectrónico.Text = "" Then
            Tx_CorreoElectrónico.BackColor = Color.Salmon
        Else
            Tx_CorreoElectrónico.BackColor = Color.White
        End If
        If Cu_CiudadNacimiento.Cb_Ciudad.Text = "SIN INFORMACION" Then
            Cu_CiudadNacimiento.Cb_Ciudad.BackColor = Color.Salmon
        Else
            Cu_CiudadNacimiento.Cb_Ciudad.BackColor = Color.White
        End If
        If CB_TipoIdentificación.Text = "SIN IDENTIFICAR" Then
            CB_TipoIdentificación.BackColor = Color.Salmon
        Else
            CB_TipoIdentificación.BackColor = Color.White
        End If
        If Cb_EstadoCivil.Text = "SE DESCONOCE" Then
            Cb_EstadoCivil.BackColor = Color.Salmon
        Else
            Cb_EstadoCivil.BackColor = Color.White
        End If
    End Sub

    Private Sub Bt_Agregar_Click(sender As Object, e As EventArgs) Handles Bt_Agregar.Click
        Dim fila As DataRow
        fila = dtParentesco.NewRow
        fila("CODIGOTIPOPARIENTE") = 1
        'fila("CODIGOLUGAREXPIDENTIFICACION") = "00000"
        fila("CODIGOTIPOOCUPACION") = 1
        fila("CODIGONACIONALIDAD") = 1

        dtParentesco.Rows.Add(fila)
        DGV_Parentesco.DataSource = dtParentesco
    End Sub

    Private Sub Bt_TomarFoto_Click(sender As Object, e As EventArgs) Handles Bt_TomarFoto.Click
        Dim frTomarFoto As New FormulariosClasesBase.Fr_TomarFoto
        Dim dr As DialogResult = frTomarFoto.ShowDialog()
        If dr = DialogResult.OK Then
            fotoOriginal = frTomarFoto.imagen.Image
            fotoGrande = FuncionesBase.FuncionesBase.CropCenterImage(fotoOriginal, dimensionFotoGrande)
            fotoMiniatura = FuncionesBase.FuncionesBase.CropCenterImage(fotoOriginal, dimensionFotoMiniatura)
            PictureBox_Foto_Persona.Image = fotoMiniatura
            tomoFoto = True
        End If
    End Sub

    Private Sub PictureBox_Foto_Persona_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox_Foto_Persona.DoubleClick
        If tomoFoto OrElse cargoFoto OrElse Editando Then
            Dim FrMostrarFoto As New FormulariosClasesBase.Fr_MostrarFoto
            FrMostrarFoto.Height = 679
            FrMostrarFoto.Width = 496
            If tomoFoto OrElse cargoFoto Then
                Dim img As Image = fotoGrande
                FrMostrarFoto.Set_Pb_Foto_Image(img)
                FrMostrarFoto.ShowDialog()
            Else
                If Not FuncionesBase.FuncionesBase.ImagenesIguales(PictureBox_Foto_Persona.Image, Im_Defecto.Images(0)) Then
                    Try
                        Dim Foto As Boolean = GoogleDrive.DescargarFotos(Trim(Fila_Editar_Persona("IDENTIFICACION")), "Persona")
                        If Foto Then
                            Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                            Dim filestream As New FileStream(appPath, FileMode.Open, FileAccess.Read)
                            Dim imagen As Image = Image.FromStream(filestream)
                            filestream.Close()
                            FrMostrarFoto.Set_Pb_Foto_Image(imagen)
                        Else
                            FrMostrarFoto.Set_Pb_Foto_Image(Im_Defecto.Images(0))
                        End If
                    Catch
                    End Try
                    FrMostrarFoto.ShowDialog()
                End If
            End If
        End If
    End Sub
    Private Sub Nud_TotalSemanas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nud_TotalSemanas.KeyPress
        If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub
    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Tx_Teléfono.KeyPress, Tx_TeléfonoMóvil.KeyPress, Tx_PesoKg.KeyPress, Tx_NumeroContacto.KeyPress, Tx_NumeroCalzado.KeyPress, Tx_Identificacion.KeyPress

        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_Identificacion_Enter(sender As Object, e As EventArgs) Handles Tx_Identificacion.Enter
        Tx_Identificacion.Text = QuitarFormatoIdentificacion(Trim(Tx_Identificacion.Text))
    End Sub

    Private Function QuitarFormatoIdentificacion(identificacion As String) As String
        Return Trim(Replace(identificacion, ".", ""))
    End Function

    Private Sub Tx_Identificacion_Leave(sender As Object, e As EventArgs) Handles Tx_Identificacion.Leave
        If Not Editando Then
            BuscarIdentificacion()
            If Not existeIdentificacion Then
                Tx_Identificacion.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(Tx_Identificacion.Text))
            End If
        End If
    End Sub

    Private Sub BuscarIdentificacion()
        Dim identificacion As String = Trim(Tx_Identificacion.Text)
        Dim conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.IdentificacionxIdPersona(@Identificacion)", conexion)
        comando.Parameters.AddWithValue("@Identificacion", identificacion)
        Dim resultado As Object
        Try
            conexion.Open()
            resultado = comando.ExecuteScalar()
            conexion.Close()
            If Not IsDBNull(resultado) Then
                RemoveHandler Tx_Identificacion.Leave, AddressOf Tx_Identificacion_Leave
                MessageBox.Show("La persona con identificación """ & identificacion & """ ya se encuentra registrada.", "Persona existente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                existeIdentificacion = True
                Button_Cancelar.Focus()
                AddHandler Tx_Identificacion.Leave, AddressOf Tx_Identificacion_Leave
            Else
                existeIdentificacion = False
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo validar la identificación." & Environment.NewLine & ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cb_NivelEducativo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_NivelEducativo.SelectedIndexChanged
        If Cb_NivelEducativo.SelectedIndex >= 0 AndAlso IsNumeric(Cb_NivelEducativo.SelectedValue) Then
            Select Case Cb_NivelEducativo.SelectedValue
                Case 21, 22, 23, 24 '21: No aplica, 22: Sin información, 23: Primaria, 24: Secundaria.
                    DTP_FechaGraduación.Enabled = False
                    Tx_TarjetaProfesional.Enabled = False
                Case Else
                    DTP_FechaGraduación.Enabled = True
                    Tx_TarjetaProfesional.Enabled = True
            End Select
        End If
    End Sub

    Private Sub Ck_Cotizado50Semanas_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_Cotizado50Semanas.CheckedChanged
        If Ck_Cotizado50Semanas.CheckState = CheckState.Checked Then
            Lb_FaltanSemanas.Visible = False
            Nud_FaltanSemanas.Visible = False
        Else
            Lb_FaltanSemanas.Visible = True
            Nud_FaltanSemanas.Visible = True
        End If
    End Sub

    Private Sub Bt_AdicionarEntidadEducativa_Click(sender As Object, e As EventArgs) Handles Bt_AdicionarEntidadEducativa.Click
        Dim nombreEntidad As String = InputBox("Ingrese el nombre de la entidad educativa", "Registrar entidad educativa")
        nombreEntidad = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(nombreEntidad)
        If nombreEntidad.Length > 0 Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.GestionarEntidadEducativa", conexion) With {.CommandType = CommandType.StoredProcedure}
            comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
            comando.Parameters.Add("@CODIGOTIPOENTIDADEDUCATIVA", SqlDbType.Int)
            comando.Parameters.Add("@NOMBREENTIDADEDUCATIVA", SqlDbType.NVarChar, 50)
            comando.Parameters("@Accion").Value = 1 'Crear
            comando.Parameters("@CODIGOTIPOENTIDADEDUCATIVA").Direction = ParameterDirection.InputOutput
            comando.Parameters("@CODIGOTIPOENTIDADEDUCATIVA").Value = DBNull.Value
            comando.Parameters("@NOMBREENTIDADEDUCATIVA").Value = nombreEntidad
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
                If Not IsNothing(comando.Parameters("@CODIGOTIPOENTIDADEDUCATIVA").Value) Then
                    'Agregar la fila recién creada a la tabla de entidades educativas en el formulario.
                    Dim dr As DataRow = DirectCast(Cb_EntidadEducativa.DataSource, DataTable).NewRow
                    dr.Item("CODIGOTIPOENTIDADEDUCATIVA") = comando.Parameters("@CODIGOTIPOENTIDADEDUCATIVA").Value
                    dr.Item("NOMBRETIPOENTIDADEDUCATIVA") = nombreEntidad
                    DirectCast(Cb_EntidadEducativa.DataSource, DataTable).Rows.Add(dr)
                    Cb_EntidadEducativa.SelectedValue = comando.Parameters("@CODIGOTIPOENTIDADEDUCATIVA").Value
                End If
            Catch ex As Exception
                MessageBox.Show("No se pudo registrar la entidad educativa." & Environment.NewLine, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub Bt_AdicionarProfesión_Click(sender As Object, e As EventArgs) Handles Bt_AdicionarProfesión.Click

    End Sub

    Private Sub DTP_FechaNacimiento_Leave(sender As Object, e As EventArgs) Handles DTP_FechaNacimiento.Leave
        'Ley 100 de 1993, artículo 39, parágrafo 1º:
        'Los menores de veinte (20) años de edad sólo deberán acreditar que han cotizado veintiséis (26) semanas[...]
        If CalcularEdad(DTP_FechaNacimiento.Value) >= 20 Then
            Nud_FaltanSemanas.Maximum = 50
            Nud_FaltanSemanas.Value = 50
        Else
            Nud_FaltanSemanas.Maximum = 26
        End If
    End Sub

    Private Function CalcularEdad(fechaNacimiento As Date) As UInteger
        Dim edad As UInteger = Date.Today.Year - fechaNacimiento.Year
        If edad > 0 AndAlso fechaNacimiento.AddYears(edad) > Date.Today Then
            edad -= 1
        End If
        Return edad
    End Function

    Private Sub DGV_Parentesco_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Parentesco.CellContentClick

    End Sub

    Public Sub EventoEnterCiudad(Optional NombreComponente As String = "")
        Dim controles() As Control = Me.Controls.Find(NombreComponente, True)
        If controles.Length > 0 Then
            Dim cuCiudad As FormulariosClasesBase.Cu_Ciudad = controles(0)
            Dim filas() As DataRow
            Try
                filas = cuCiudad.Cb_Ciudad.DataSource.Select("CODIGOPOBLACION='" + (cuCiudad.Tx_Codigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuCiudad.Cb_Ciudad.SelectedValue = fila("CODIGOPOBLACION")
                Else
                    'MessageBox.Show("Esta población no está registrada.", "No se encontró la ciudad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch
                cuCiudad.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub

    Public Sub EventoEnterEntidadAdmin(Optional NombreComponente As String = "")
        Dim controles() As Control = Me.Controls.Find(NombreComponente, True)
        If controles.Length > 0 Then
            Dim cuEntidadAdmin As Clasesbase.Cu_EntidadAdministradora = controles(0)
            Dim filas() As DataRow
            Try
                filas = cuEntidadAdmin.Cb_NombreAdministradora.DataSource.Select("CODIGOTIPOENTIDADADMINISTRADORA='" + (cuEntidadAdmin.Tx_Codigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuEntidadAdmin.Cb_NombreAdministradora.SelectedValue = fila("CODIGOTIPOENTIDADADMINISTRADORA")
                Else
                    MessageBox.Show("Esta entidad no está registrada o no está asociada a la base.", "No se encontró la entidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch
                cuEntidadAdmin.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub

    
End Class 'Fr_Persona