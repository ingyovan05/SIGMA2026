Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms

Public Class Fr_PersonaBasico
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
    Private dtParentescoVacio As DataTable
    Private existeIdentificacion As Boolean = False
    Private tomoFoto As Boolean = False
    Private cargoFoto As Boolean = False
    Private EliminoFoto As Boolean = False
    Private fotoOriginal As Image
    Private fotoGrande As Image
    Private fotoMiniatura As Image
    Private dimensionFotoGrande As New Size(480, 640)
    Private dimensionFotoMiniatura As New Size(120, 160)
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
        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(5, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdPersonaEditando, IIf(IdPersonaEditando = -1, 1, 2))
        CB_TipoIdentificación.DataSource = dsCargar.Tables(2)
        CB_TipoIdentificación.ValueMember = "CODIGOTIPOIDENTIFICACION"
        CB_TipoIdentificación.DisplayMember = "NOMBRETIPOIDENTIFICACION"
        Cu_CiudadNacimiento.CargarDatos()
        Cu_CiudadExpedición.CargarDatos()
        Cu_CiudadDirección.CargarDatos()
        DTP_FechaExpedición.MaxDate = Date.Now
        DTP_FechaNacimiento.MaxDate = Date.Now
        dtParentescoVacio = dsCargar.Tables(1).Clone 'Cargar estructura de la tabla parientes.
        If Editando = True Then
            Fila_Editar_Persona = dsCargar.Tables(0).Rows(0)
        Else
            Cu_CiudadExpedición.Cb_Ciudad.SelectedValue = 0
            Cu_CiudadNacimiento.Cb_Ciudad.SelectedValue = 0
            Cu_CiudadDirección.Cb_Ciudad.SelectedValue = 0
        End If
    End Sub

    Private Sub Fr_PersonaBasico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Editando Then
            Tx_PrimerNombre.Select()
        Else
            Tx_Identificacion.Select()
        End If
    End Sub

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
            Tx_PesoKg.Text = Fila_Editar_Persona("PESOKILOGRAMOS")
        Catch
            Tx_PesoKg.Text = ""
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
            Dim byteBLOBData(-1) As [Byte]
            byteBLOBData = CType(Fila_Editar_Persona("FOTO"), [Byte]())
            Dim stmBLOBData As New MemoryStream(byteBLOBData)
            PictureBox_Foto_Persona.Image = Image.FromStream(stmBLOBData)
        Catch
            PictureBox_Foto_Persona.Image = Im_Defecto.Images(0)
        End Try
        Tx_Identificacion.Enabled = False
    End Sub

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
        If Tx_PrimerNombre.Text = "" Then
            MsgBox("El primer nombre de la persona es obligatorio.", MsgBoxStyle.Information, "Primer Nombre")
            Tx_PrimerNombre.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Tx_PrimerApellido.Text = "" Then
            MsgBox("El primer apellido de la persona es obligatorio.", MsgBoxStyle.Information, "Primer Apellido")
            Tx_PrimerApellido.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If CB_TipoIdentificación.Text = "" Then
            MsgBox("Debe seleccionar un tipo de identificación.", MsgBoxStyle.Critical, "Tipo Identificación")
            CB_TipoIdentificación.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Trim(Tx_Identificacion.Text) = "" Then
            MsgBox("El número de identificación de la persona es obligatorio.", MsgBoxStyle.Critical, "Identificación")
            Tx_Identificacion.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Cu_CiudadExpedición.Cb_Ciudad.Text = "" OrElse Cu_CiudadExpedición.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad o municipio de expedición de la identificación.", MsgBoxStyle.Critical, "Ciudad de expedición de la cédula")
            Cu_CiudadExpedición.Cb_Ciudad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If DTP_FechaExpedición.Checked = True Then
            If DTP_FechaNacimiento.Checked = True Then
                If DTP_FechaNacimiento.Value > DTP_FechaExpedición.Value Then
                    MsgBox("La fecha de expedición de la identificación es menor a la fecha de nacimiento.", MsgBoxStyle.Critical, "Fecha de nacimiento")
                    DTP_FechaNacimiento.Focus()
                    Validar_Datos_Persona = False
                    Exit Function
                End If
            End If
        End If
        If Cu_CiudadDirección.Cb_Ciudad.Text = "" OrElse Cu_CiudadDirección.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad donde habita actualmente.", MsgBoxStyle.Critical, "Ciudad de residencia")
            Cu_CiudadDirección.Cb_Ciudad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If DTP_FechaNacimiento.Checked = False Then
            MsgBox("Debe seleccionar la fecha de nacimiento de la persona.", MsgBoxStyle.Critical, "Fecha de nacimiento")
            Validar_Datos_Persona = False
            DTP_FechaNacimiento.Focus()
            Exit Function
        End If
        If Cu_CiudadNacimiento.Cb_Ciudad.Text = "" OrElse Cu_CiudadNacimiento.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad de nacimiento.", MsgBoxStyle.Critical, "Ciudad de nacimiento")
            Cu_CiudadNacimiento.Cb_Ciudad.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If RadioButton_Masculino.Checked = False AndAlso RadioButton_Femenino.Checked = False Then
            MsgBox("Debe seleccionar el género de la persona.", MsgBoxStyle.Information, "Género")
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Trim(Tx_TeléfonoMóvil.Text) = "" Then
            MsgBox("El teléfono móvil no puede estar vacío.", MsgBoxStyle.Critical, "Teléfono móvil")
            Tx_TeléfonoMóvil.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If IsNumeric(Tx_TeléfonoMóvil.Text) = False Then
            MsgBox("El teléfono móvil debe ser numérico.", MsgBoxStyle.Critical, "Telefono móvil")
            Tx_TeléfonoMóvil.Focus()
            Validar_Datos_Persona = False
            Exit Function
        End If
        If Tx_CorreoElectrónico.Text <> "" Then
            If Not FuncionesBase.FuncionesBase.validarDireccionCorreo(Tx_CorreoElectrónico.Text) Then
                MsgBox("El correo electrónico no cumple con el formato.", MsgBoxStyle.Critical, "Correo electrónico")
                Tx_CorreoElectrónico.Focus()
                Validar_Datos_Persona = False
                Exit Function
            End If
        End If
        Validar_Datos_Persona = True
    End Function

    Private Sub Guardar_RegistroPersona()
        Dim cedula As String = QuitarFormatoIdentificacion(Trim(Tx_Identificacion.Text))
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarPersona")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        If Not Editando Then
            Comando.Parameters("@ACCION").Value = 1
        Else
            Comando.Parameters("@ACCION").Value = 4
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
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTADOCIVIL", DBNull.Value)
        Comando.Parameters.AddWithValue("@GRUPOSANGUINEO", "")
        Comando.Parameters.Add("@GENERO", SqlDbType.Char, 1)
        If RadioButton_Masculino.Checked Then
            Comando.Parameters("@GENERO").Value = "M"
        Else
            Comando.Parameters("@GENERO").Value = "F"
        End If
        Comando.Parameters.AddWithValue("@LIBRETAMILITAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPODISTRITOMILITAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOCLASELIBRETAMILITAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@LICENCIACONDUCCION", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOCATEGORIALICENCIA", DBNull.Value)
        Comando.Parameters.Add("@VIGENCIALICENCIACONDUCCION", SqlDbType.Date)
        Comando.Parameters("@VIGENCIALICENCIACONDUCCION").Value = DBNull.Value
        Comando.Parameters.AddWithValue("@TALLAPANTALON", "")
        Comando.Parameters.AddWithValue("@TALLACAMISA", "")
        Comando.Parameters.AddWithValue("@NUMEROCALZADO", "")
        Comando.Parameters.AddWithValue("@PESOKILOGRAMOS", Tx_PesoKg.Text)
        Comando.Parameters.AddWithValue("@CODIGOTIPOETNIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESEMPLEADO", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESCLIENTE", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESPROVEEDORCONTRATISTA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOOBSERVACION", Tx_Observación.Tag)
        Comando.Parameters.AddWithValue("@DIRECCION", Trim(Tx_Dirección.Text))
        Comando.Parameters.AddWithValue("@CODIGOLUGARDIRECCION", Cu_CiudadDirección.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOVIVIENDA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTRATO", DBNull.Value)
        Comando.Parameters.AddWithValue("@NUMEROCONTACTO", Trim(Tx_NumeroContacto.Text))
        Comando.Parameters.AddWithValue("@CORREOELECTRONICO", Trim(Tx_CorreoElectrónico.Text))
        Comando.Parameters.AddWithValue("@TELEFONO", Trim(Tx_Teléfono.Text))
        Comando.Parameters.AddWithValue("@TELEFONOMOVIL", Trim(Tx_TeléfonoMóvil.Text))
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINEPS", DBNull.Value)
        Comando.Parameters.Add("@FECHAAFILIACIONEPS", SqlDbType.Date)
        Comando.Parameters("@FECHAAFILIACIONEPS").Value = DBNull.Value
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINAFP", DBNull.Value)
        Comando.Parameters.Add("@FECHAAFILIACIONAFP", SqlDbType.Date)
        Comando.Parameters("@FECHAAFILIACIONAFP").Value = DBNull.Value
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINAFC", DBNull.Value)
        Comando.Parameters.Add("@FECHAAFILIACIONAFC", SqlDbType.Date)
        Comando.Parameters("@FECHAAFILIACIONAFC").Value = DBNull.Value
        Comando.Parameters.Add("@CODIGOENTIDADADMINEPV", SqlDbType.VarChar, 6)
        Comando.Parameters.Add("@FECHAAFILIACIONEPV", SqlDbType.Date)
        Comando.Parameters("@FECHAAFILIACIONEPV").Value = DBNull.Value
        Comando.Parameters("@CODIGOENTIDADADMINEPV").Value = DBNull.Value
        Comando.Parameters.AddWithValue("@CODIGOPROFESION", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOENTIDADEDUCATIVA", DBNull.Value)
        Comando.Parameters.AddWithValue("@FECHAGRADUACION", DBNull.Value)
        Comando.Parameters.AddWithValue("@TARJETAPROFESIONAL", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGONIVELEDUCATIVO", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOINDUCCION", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOCONDUCTOR", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOOPERADOR", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOIZAJECARGAS", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOALTURAS", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOESPACIOSCONFINADOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@CURSOSADICIONALES", "")
        Comando.Parameters.AddWithValue("@FIEBREAMARILLA", DBNull.Value)
        Comando.Parameters.AddWithValue("@TETANO1", DBNull.Value)
        Comando.Parameters.AddWithValue("@TETANO2", DBNull.Value)
        Comando.Parameters.AddWithValue("@TETANO3", DBNull.Value)
        Comando.Parameters.AddWithValue("@TETANO4", DBNull.Value)
        Comando.Parameters.AddWithValue("@TETANO5", DBNull.Value)
        Comando.Parameters.AddWithValue("@CABEZAFAMILIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CONDISCAPACIDAD", DBNull.Value)
        Comando.Parameters.AddWithValue("@PERSONASACARGO", DBNull.Value)
        Comando.Parameters.AddWithValue("@NUMEROHIJOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@COTIZO50SEMANASULTIMOAÑO", DBNull.Value)
        Comando.Parameters.AddWithValue("@SEMANASFALTAN", DBNull.Value)
        Comando.Parameters.AddWithValue("@TOTALSEMANASAFP", DBNull.Value)
        Comando.Parameters.Add("@FECHAEXPEDICION50SEMANAS", SqlDbType.Date)
        Comando.Parameters("@FECHAEXPEDICION50SEMANAS").Value = DBNull.Value
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
        Comando.Parameters.AddWithValue("@TIP_PARIENTEPERSONA", dtParentescoVacio)
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
                    End If
                    Close()
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

    Private Function Devolver_BLOB() As Byte()
        Dim fs As New FileStream(Application.StartupPath + "\Temp2.jpg", FileMode.OpenOrCreate, FileAccess.Read)
        Dim MyData(fs.Length) As Byte
        fs.Read(MyData, 0, fs.Length)
        fs.Close()
        Devolver_BLOB = MyData
    End Function
#End Region 'Guardar o actualizar datos

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
                    'Cargar Imagen en el PictureBox.
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

    Private Sub Button_Aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Aceptar.Click
        Cursor.Current = Cursors.WaitCursor
        If Guardar_Datos() = True Then
            Close()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Cancelar.Click
        Close()
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Tx_PrimerNombre.GotFocus, Tx_SegundoNombre.GotFocus, Tx_PrimerApellido.GotFocus, _
        Tx_SegundoApellido.GotFocus, Tx_Identificacion.GotFocus, _
        Tx_Dirección.GotFocus, Tx_NumeroContacto.GotFocus, Tx_TeléfonoMóvil.GotFocus, Tx_CorreoElectrónico.GotFocus, _
        Tx_Observación.GotFocus, Tx_PesoKg.GotFocus
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
            Dim Caja As TextBox = sender
            Caja.BackColor = Color.White
            If Caja.Text = "" OrElse Caja.Text = "SIN INFORMACION" OrElse Caja.Text = "SE DESCONOCE" OrElse Caja.Text = "SIN IDENTIFICAR" Then
                Caja.BackColor = Color.Salmon
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

    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Tx_Teléfono.KeyPress, Tx_TeléfonoMóvil.KeyPress, Tx_NumeroContacto.KeyPress, Tx_Identificacion.KeyPress, Tx_PesoKg.KeyPress

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

    Public Sub EventoEnterCiudad(Optional NombreComponente As String = "")
        Dim controles() As Control = Me.Controls.Find(NombreComponente, True)
        If controles.Length > 0 Then
            Dim cuCiudad As FormulariosClasesBase.Cu_Ciudad = controles(0)
            Dim filas() As DataRow
            Try
                filas = cuCiudad.Cb_Ciudad.DataSource.Select("CODIGOPOBLACION = '" + (cuCiudad.Tx_Codigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuCiudad.Cb_Ciudad.SelectedValue = fila("CODIGOPOBLACION")
                End If
            Catch
                cuCiudad.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub

End Class