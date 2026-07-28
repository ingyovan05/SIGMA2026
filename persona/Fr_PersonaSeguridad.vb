Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms

Public Class Fr_PersonaSeguridad

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
    Private fotoOriginal As Image
    Private fotoGrande As Image
    Private fotoMiniatura As Image
    Private dimensionFotoGrande As New Size(640, 480)
    Private dimensionFotoMiniatura As New Size(120, 135)

    Private Sub Fr_Persona_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Marcar_Cajas_Vacias()
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
        dtParentescoVacio = dsCargar.Tables(1).Clone 'Cargar estructura de la tabla parientes.     

    End Sub

    Private Sub Fr_PersonaBasico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Tx_Identificacion.Select()
    End Sub

    ''' <summary>Asigna los datos de la persona a los controles del formulario.</summary>

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

        Comando.Parameters.Add("@CODIGOLUGAREXPIDENTIFICACION", SqlDbType.VarChar)
        Comando.Parameters("@CODIGOLUGAREXPIDENTIFICACION").Value = DBNull.Value

        Comando.Parameters.Add("@FECHAEXPEDICIONIDENTIFICACION", SqlDbType.Date)
        Comando.Parameters("@FECHAEXPEDICIONIDENTIFICACION").Value = DBNull.Value

        Comando.Parameters.Add("@CODIGOLUGARNACIMIENTO", SqlDbType.VarChar)
        Comando.Parameters("@CODIGOLUGARNACIMIENTO").Value = DBNull.Value

        Comando.Parameters.Add("@FECHANACIMIENTO", SqlDbType.Date)
        Comando.Parameters("@FECHANACIMIENTO").Value = DBNull.Value
      
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
        Comando.Parameters.AddWithValue("@PESOKILOGRAMOS", "")
        Comando.Parameters.AddWithValue("@CODIGOTIPOETNIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESEMPLEADO", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESCLIENTE", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESPROVEEDORCONTRATISTA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOOBSERVACION", "")
        Comando.Parameters.AddWithValue("@DIRECCION", "")
        Comando.Parameters.Add("@CODIGOLUGARDIRECCION", SqlDbType.VarChar)
        Comando.Parameters("@CODIGOLUGARDIRECCION").Value = "00000"
        Comando.Parameters.AddWithValue("@CODIGOTIPOVIVIENDA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTRATO", DBNull.Value)
        Comando.Parameters.AddWithValue("@NUMEROCONTACTO", "")
        Comando.Parameters.AddWithValue("@CORREOELECTRONICO", "")
        Comando.Parameters.AddWithValue("@TELEFONO", "")
        Comando.Parameters.AddWithValue("@TELEFONOMOVIL", "")
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
        Comando.Parameters.Add("@FECHAEXPEDICION50SEMANAS", SqlDbType.Date)
        Comando.Parameters.AddWithValue("@TOTALSEMANASAFP", DBNull.Value)
        Comando.Parameters("@FECHAEXPEDICION50SEMANAS").Value = DBNull.Value
        Comando.Parameters.AddWithValue("@OBSERVACION", "")
        Comando.Parameters.AddWithValue("@IDBASEREGISTRO", VariablesBase.VariablesBase.IdBaseSiscontrolActual)

        Dim Vista_Miniatura As Image

        Vista_Miniatura = PictureBox_Foto_Persona.Image

        Vista_Miniatura.Save(Application.StartupPath + "\Temp.jpg", ImageFormat.Jpeg)
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
                    'If (tomoFoto OrElse cargoFoto) AndAlso GuardaFotoServidor Then
                    '    FuncionesBase.FuncionesBase.SubirArchivoFTP(New Bitmap(fotoGrande), cedula & ".jpg", "FOTOPERSONA", True, "jpg")
                    'End If
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
    End Sub

    Private Function Devolver_BLOB() As Byte()
        Dim fs As New FileStream(Application.StartupPath + "\Temp.jpg", FileMode.OpenOrCreate, FileAccess.Read)
        Dim MyData(fs.Length) As Byte
        fs.Read(MyData, 0, fs.Length)
        fs.Close()
        Devolver_BLOB = MyData
    End Function

#End Region 'Guardar o actualizar datos

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
        Tx_SegundoApellido.GotFocus, Tx_Identificacion.GotFocus
        Try
            DirectCast(sender, TextBox).BackColor = Color.MintCream
        Catch
        End Try
    End Sub

    Private Sub Caja_Texto_LostFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Tx_PrimerNombre.LostFocus, Tx_SegundoNombre.LostFocus, Tx_PrimerApellido.LostFocus, _
        Tx_SegundoApellido.LostFocus, Tx_Identificacion.LostFocus
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
        If CB_TipoIdentificación.Text = "SIN IDENTIFICAR" Then
            CB_TipoIdentificación.BackColor = Color.Salmon
        Else
            CB_TipoIdentificación.BackColor = Color.White
        End If
    End Sub


   
    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Tx_Identificacion.KeyPress
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



End Class