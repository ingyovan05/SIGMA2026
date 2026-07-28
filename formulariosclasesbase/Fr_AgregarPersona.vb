Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO

Public Class Fr_AgregarPersona
    Public IdPersona As Integer
    Private dtTipoIdentificacion As New DataTable
    Private guardado As Boolean = False

    Private Sub Fr_AgregarPersona_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Cargar_Tablas()
    End Sub

    Public Sub Cargar_Tablas()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM ListaTipoIdentificacion()", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            adaptador.Fill(dtTipoIdentificacion)
            Cb_TipoIdentificacion.DataSource = dtTipoIdentificacion
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Close()
        End Try
        Cu_CiudadDireccion.CargarDatos()
        Cu_CiudadExpedicion.CargarDatos()
    End Sub

    Private Sub Bt_Aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            IdPersona = FuncionesBase.FuncionesBase.Siguiente("PERSONA")
            Guardar()
            If guardado Then
                Close()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If Trim(Tx_PrimerNombre.Text) = "" Then
            MessageBox.Show("El primer nombre de la persona es obligatorio.", "Primer Nombre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_PrimerNombre.Focus()
            Return False
        End If
        If Trim(Tx_PrimerApellido.Text) = "" Then
            MessageBox.Show("El primer apellido de la persona es obligatorio.", "Primer Apellido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_PrimerApellido.Focus()
            Return False
        End If
        If Trim(Tx_Identificacion.Text) = "" Then
            MessageBox.Show("El número de identificación de la persona es obligatorio.", "Identificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_Identificacion.Focus()
            Return False
        End If
        If Tx_Identificacion.Text.StartsWith("0") Then
            MessageBox.Show("El número de identificación no puede comenzar en cero (0).", "Identificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_Identificacion.Focus()
            Return False
        End If
        If Tx_Identificacion.Text.Length < 6 Then
            MessageBox.Show("El número de identificación debe tener mínimo 6 dígitos.", "Identificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_Identificacion.Focus()
            Return False
        End If
        If Ck_Empleado.Checked = False AndAlso Ck_Cliente.Checked = False AndAlso Ck_ContratistaProveedor.Checked = False Then
            MessageBox.Show("Debe seleccionar al menos uno de los tipos de tercero.", "Tipo Tercero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Ck_ContratistaProveedor.Focus()
            Return False
        End If
        If Trim(Tx_CorreoElectronico.Text) <> "" AndAlso FuncionesBase.FuncionesBase.validarDireccionCorreo(Tx_CorreoElectronico.Text) = False Then
            MessageBox.Show("El correo electrónico no cumple con el formato.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_CorreoElectronico.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Guardar()
        Dim dtVacio_ParientePersona As New DataTable
        dtVacio_ParientePersona.Columns.Add("CODIGOTIPOPARIENTE")
        dtVacio_ParientePersona.Columns.Add("PRIMERNOMBRE")
        dtVacio_ParientePersona.Columns.Add("SEGUNDONOMBRE")
        dtVacio_ParientePersona.Columns.Add("PRIMERAPELLIDO")
        dtVacio_ParientePersona.Columns.Add("SEGUNDOAPELLIDO")
        dtVacio_ParientePersona.Columns.Add("FECHANACIMIENTO")
        dtVacio_ParientePersona.Columns.Add("IDENTIFICACION")
        dtVacio_ParientePersona.Columns.Add("NUMEROCONTACTO")
        dtVacio_ParientePersona.Columns.Add("CODIGOTIPOOCUPACION")
        dtVacio_ParientePersona.Columns.Add("CODIGONACIONALIDAD")
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo.GestionarPersona", conexion) With {.CommandType = CommandType.StoredProcedure}
        Comando.Parameters.AddWithValue("@ACCION", 1)
        Comando.Parameters.AddWithValue("@IDPERSONA", -1)
        Comando.Parameters.AddWithValue("@PRIMERNOMBRE", Trim(Tx_PrimerNombre.Text))
        Comando.Parameters.AddWithValue("@SEGUNDONOMBRE", Trim(Tx_SegundoNombre.Text))
        Comando.Parameters.AddWithValue("@PRIMERAPELLIDO", Trim(Tx_PrimerApellido.Text))
        Comando.Parameters.AddWithValue("@SEGUNDOAPELLIDO", Trim(Tx_SegundoApellido.Text))
        Comando.Parameters.AddWithValue("@IDENTIFICACION", Trim(Tx_Identificacion.Text))
        Comando.Parameters.AddWithValue("@CODIGOTIPOIDENTIFICACION", Cb_TipoIdentificacion.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOLUGAREXPIDENTIFICACION", Cu_CiudadExpedicion.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAEXPEDICIONIDENTIFICACION", If(Dtp_FechaExpedicion.Checked, DBNull.Value, Dtp_FechaExpedicion.Value))
        Comando.Parameters.AddWithValue("@CODIGOLUGARNACIMIENTO", DBNull.Value)
        Comando.Parameters.AddWithValue("@FECHANACIMIENTO", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTADOCIVIL", DBNull.Value)
        Comando.Parameters.AddWithValue("@GRUPOSANGUINEO", DBNull.Value)
        Comando.Parameters.AddWithValue("@GENERO", If(Rb_Masculino.Checked, "M", "F"))
        Comando.Parameters.AddWithValue("@LIBRETAMILITAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPODISTRITOMILITAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOCLASELIBRETAMILITAR", DBNull.Value)
        Comando.Parameters.AddWithValue("@LICENCIACONDUCCION", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOCATEGORIALICENCIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@VIGENCIALICENCIACONDUCCION", DBNull.Value)
        Comando.Parameters.AddWithValue("@TALLAPANTALON", DBNull.Value)
        Comando.Parameters.AddWithValue("@TALLACAMISA", DBNull.Value)
        Comando.Parameters.AddWithValue("@NUMEROCALZADO", DBNull.Value)
        Comando.Parameters.AddWithValue("@PESOKILOGRAMOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOETNIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@ESEMPLEADO", If(Ck_Empleado.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@ESCLIENTE", If(Ck_Cliente.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@ESPROVEEDORCONTRATISTA", If(Ck_ContratistaProveedor.CheckState = CheckState.Checked, "S", "N"))
        Comando.Parameters.AddWithValue("@CODIGOOBSERVACION", DBNull.Value)
        Comando.Parameters.AddWithValue("@DIRECCION", Trim(Tx_Direccion.Text))
        Comando.Parameters.AddWithValue("@CODIGOLUGARDIRECCION", Cu_CiudadDireccion.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOTIPOVIVIENDA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOTIPOESTRATO", DBNull.Value)
        Comando.Parameters.AddWithValue("@NUMEROCONTACTO", DBNull.Value)
        Comando.Parameters.AddWithValue("@CORREOELECTRONICO", Trim(Tx_CorreoElectronico.Text))
        Comando.Parameters.AddWithValue("@TELEFONO", Trim(Tx_Telefono.Text))
        Comando.Parameters.AddWithValue("@TELEFONOMOVIL", Trim(Tx_TelefonoMovil.Text))
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINEPS", DBNull.Value)
        Comando.Parameters.AddWithValue("@FECHAAFILIACIONEPS", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINAFP", DBNull.Value)
        Comando.Parameters.AddWithValue("@FECHAAFILIACIONAFP", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINAFC", DBNull.Value)
        Comando.Parameters.AddWithValue("@FECHAAFILIACIONAFC", DBNull.Value)
        Comando.Parameters.AddWithValue("@CODIGOENTIDADADMINEPV", DBNull.Value)
        Comando.Parameters.AddWithValue("@FECHAAFILIACIONEPV", DBNull.Value)
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
        Comando.Parameters.AddWithValue("@CURSOSADICIONALES", DBNull.Value)
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
        Comando.Parameters("@FECHAEXPEDICION50SEMANAS").Value = DBNull.Value
        Comando.Parameters.AddWithValue("@TOTALSEMANASAFP", DBNull.Value)
        Comando.Parameters.AddWithValue("@OBSERVACION", "")
        Comando.Parameters.AddWithValue("@IDBASEREGISTRO", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@FOTOPERSONA", Devolver_BLOB)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@TIP_PARIENTEPERSONA", dtVacio_ParientePersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
        Comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            Comando.ExecuteNonQuery()
            conexion.Close()
            Select Case Comando.Parameters("@IDMENSAJE").Value
                Case 0
                    MessageBox.Show("No se pudo realizar la operación.", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case 1
                    MessageBox.Show("El registro ha sido exitoso.", "Registro de personal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    guardado = True
                Case 2
                    'Cuando es nuevo y ya existe la identificación o cuando se está modificando y la identificación ya existe.
                    MessageBox.Show("No se pudo realizar la operación, ya existe una persona registrada con ese número de identificación.", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Function Devolver_BLOB() As Byte()
        Dim imagen As New Bitmap(New Bitmap(Im_Defecto.Images(0)))
        Dim Vista_Miniatura As Image = imagen.GetThumbnailImage(120, 135, Nothing, New IntPtr())
        Vista_Miniatura.Save(Application.StartupPath + "\Temp.jpg", ImageFormat.Jpeg)
        Dim fs As New FileStream(Application.StartupPath + "\Temp.jpg", FileMode.OpenOrCreate, FileAccess.Read)
        Dim MyData(fs.Length) As Byte
        fs.Read(MyData, 0, fs.Length)
        fs.Close()
        Devolver_BLOB = MyData
    End Function

    Private Sub Bt_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Cancelar.Click
        IdPersona = -1
        Close()
    End Sub

    Private Sub Tx_Identificación_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Identificacion.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_Identificacion_Leave(sender As Object, e As EventArgs) Handles Tx_Identificacion.Leave
        Dim valido As String = FuncionesBase.FuncionesBase.ConsultarIdPersona(Tx_Identificacion.Text)
        If Not IsNothing(valido) AndAlso valido >= 0 Then
            MessageBox.Show("El número de identificación ya está registrado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_Identificacion.Focus()
        End If
    End Sub
End Class