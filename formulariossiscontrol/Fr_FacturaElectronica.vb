Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports FormulariosClasesBase

''' <summary>
''' Formulario de registro de aprobación de borrador de factura para Facturación Electrónica.
''' </summary>
Public Class Fr_FacturaElectronica

    ''' <summary>
    ''' Tipos de edición de aprobaciones.
    ''' </summary>
    Public Enum TipoEdicion
        Crear
        Modificar
        Ver
        Clonar
    End Enum

    ''' <summary>
    ''' Tipo de edición de la aprobación actual.
    ''' </summary>
    ''' <value>Tipo de edición asignado desde la clase padre.</value>
    ''' <returns>Tipo de edición.</returns>
    Property Edicion As TipoEdicion

    ''' <summary>
    ''' Almacena la base "principal" de la empresa actual del usuario para listar las dependencias ordenadoras del gasto.
    ''' </summary>
    Private _idBaseTemp As Integer

    ''' <summary>
    ''' Contiene el Id de la aprobación a editar.
    ''' </summary>
    Public _idAprobacion As Integer

    ''' <summary>
    ''' Almacena el número de aprobación generado después del guardado o cargado al editar la aprobación.
    ''' </summary>
    Private _numAprobacion As String

    ''' <summary>
    ''' Objeto de conexión a la Base de Datos.
    ''' </summary>
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)

    ''' <summary>
    ''' Objeto de comandos de consulta.
    ''' </summary>
    Private comando As SqlCommand

    ''' <summary>
    ''' Adaptador de datos.
    ''' </summary>
    Private adaptador As SqlDataAdapter

    Public Tipo As String
    Public Identificador As Integer = -1

    Private FilaOS As DataRow
    Private FilaOC As DataRow

    ''' <summary>
    ''' Asigna el Id de la aprobación a gestionar.
    ''' </summary>
    ''' <param name="id">Identificador de la aprobación</param>
    Public Sub SetIdAprobacion(id As Integer)
        _idAprobacion = id
    End Sub


    ' Carga de datos de aprobación y habilitación de componentes.
    Private Sub Fr_FacturaElectronica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _idBaseTemp = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        CargarComponentes()
        If Edicion = TipoEdicion.Modificar OrElse Edicion = TipoEdicion.Ver OrElse Edicion = TipoEdicion.Clonar Then
            CargarAprobacion()
            If Edicion = TipoEdicion.Ver Then
                Cb_Dependencia.Enabled = False
                Cb_Subgerencia.Enabled = False
                Cb_TipoAprobacion.Enabled = False
                Cb_Consecutivo.Enabled = False
                Tx_IdentificacionNIT.ReadOnly = True
                Tx_Proveedor.ReadOnly = True
                Bt_BuscarProveedor.Enabled = False
                Tx_Descripcion.ReadOnly = True
                Cu_BuscarPersonaAprueba.Enabled = False
                CuTx_Valor.SoloLectura = True
                Cb_TipoMoneda.Enabled = False
                Bt_Guardar.Enabled = False
            End If
        End If
    End Sub


    ''' <summary>
    ''' Carga de datos a los controles del formulario.
    ''' </summary>
    Private Sub CargarComponentes()
        CargarTipoAprobacion()
        CargarDependencias()
        If VariablesBase.VariablesBase.EmpresaSisControlActual = 0 Then 'Sólo mostrar la selección de Subgerencia para las bases de Ismocol S.A.
            CargarSubgerencias()
        Else
            Lb_Subgerencia.Enabled = False
            Cb_Subgerencia.Enabled = False
            Cb_Subgerencia.SelectedIndex = -1
        End If
        CargarTipoMoneda()
        CargarPersonaAprueba()
        If FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "FE", "DEPENDENCIA", -1) >= 0 Then
            Cb_Dependencia.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "FE", "DEPENDENCIA", -1)
        Else
            Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        End If
        If FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "FE", "FUNCIONARIOAPRUEBA", -1) >= 0 Then
            Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "FE", "FUNCIONARIOAPRUEBA", -1)
        End If
    End Sub


    ''' <summary>
    ''' Carga el listado de tipos de aprobación.
    ''' </summary>
    Private Sub CargarTipoAprobacion()
        comando = New SqlCommand("SELECT * FROM SC_FE_ListarTipoAprobacion()", conexion)
        adaptador = New SqlDataAdapter(comando)
        Dim dtTipoAprobacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtTipoAprobacion)
            conexion.Close()
            If dtTipoAprobacion.Rows.Count > 0 Then
                Cb_TipoAprobacion.DataSource = dtTipoAprobacion
                Cb_TipoAprobacion.ValueMember = "CODIGOTIPOAPROBACION"
                Cb_TipoAprobacion.DisplayMember = "NOMBRETIPOAPROBACION"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga el listado de dependencias de la base Bucaramanga.
    ''' </summary>
    Private Sub CargarDependencias()
        comando = New SqlCommand("SELECT * FROM SC_FE_ListaDependencias(@TIPO, @IDDEPENDENCIA) ORDER BY IDBASESISCONTROL ASC", conexion)
        comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDDEPENDENCIA", SqlDbType.Int)
        If Edicion = TipoEdicion.Crear Then 'Cargar dependencias de base actual + base ppal. de la empresa.
            comando.Parameters("@TIPO").Value = 1
            comando.Parameters("@IDDEPENDENCIA").Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        Else 'Cargar todas las dependencias.
            comando.Parameters("@TIPO").Value = 0
            comando.Parameters("@IDDEPENDENCIA").Value = DBNull.Value
        End If
        adaptador = New SqlDataAdapter(comando)
        Dim dtDependencias As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtDependencias)
            conexion.Close()
            If dtDependencias.Rows.Count > 0 Then
                Cb_Dependencia.DataSource = dtDependencias
                Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
                Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarSubgerencias()
        comando = New SqlCommand("SELECT * FROM ListaSubgerencias()", conexion)
        adaptador = New SqlDataAdapter(comando)
        Dim dtSubgerencias As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtSubgerencias)
            conexion.Close()
            Cb_Subgerencia.DataSource = dtSubgerencias
            Cb_Subgerencia.DisplayMember = "NOMBREGERENCIA"
            Cb_Subgerencia.ValueMember = "IDGERENCIA"
            Cb_Subgerencia.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga el listado de tipos de moneda o divisas.
    ''' </summary>
    Private Sub CargarTipoMoneda()
        comando = New SqlCommand("SELECT * FROM ListarTipoMoneda()", conexion)
        adaptador = New SqlDataAdapter(comando)
        Dim dtTipoMoneda As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtTipoMoneda)
            conexion.Close()
            If dtTipoMoneda.Rows.Count > 0 Then
                Cb_TipoMoneda.DataSource = dtTipoMoneda
                Cb_TipoMoneda.ValueMember = "CODIGOTIPOMONEDA"
                Cb_TipoMoneda.DisplayMember = "MONEDA"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga los usuarios en el listado de persona que aprueba.
    ''' </summary>
    Private Sub CargarPersonaAprueba()
        'Id de la base "principal" de la empresa actual que se asignó durante la carga del formulario
        VariablesBase.VariablesBase.IdBaseSiscontrolActual = Cb_Dependencia.DataSource.Rows(Cb_Dependencia.SelectedIndex).Item("IDBASESISCONTROL")
        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Cb_Dependencia.SelectedValue
        Cu_BuscarPersonaAprueba.CargarDatos()
        Cu_BuscarPersonaAprueba.Cb_Persona.SelectedIndex = -1
    End Sub


    ''' <summary>
    ''' Carga los datos de la aprobación
    ''' </summary>
    Public Sub CargarAprobacion()
        comando = New SqlCommand("SELECT * FROM SC_FE_DatosAprobacion(@IDAPROBACION)", conexion)
        comando.Parameters.AddWithValue("@IDAPROBACION", _idAprobacion)
        adaptador = New SqlDataAdapter(comando)
        Dim dtAprobacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtAprobacion)
            conexion.Close()
            If dtAprobacion.Rows.Count > 0 Then
                Dim drAprobacion As DataRow = dtAprobacion.Rows(0)
                Cb_Dependencia.SelectedValue = drAprobacion.Item("IDDEPENDENCIA")
                Cb_Subgerencia.SelectedValue = drAprobacion.Item("IDGERENCIA")
                Cb_TipoAprobacion.SelectedValue = drAprobacion.Item("TIPOAPROBACION")
                'Cb_Consecutivo.SelectedValue = drAprobacion.Item("")
                Tx_IdentificacionNIT.Text = drAprobacion.Item("NIT")
                Tx_Proveedor.Text = drAprobacion.Item("PROVEEDOR")
                Tx_Descripcion.Text = drAprobacion.Item("DESCRIPCION")
                Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = drAprobacion.Item("IDPERSONAAPRUEBA")
                CuTx_Valor.Valor = drAprobacion.Item("VALOR")
                Cb_TipoMoneda.SelectedValue = drAprobacion.Item("CODIGOTIPOMONEDA")
                Identificador = drAprobacion("IDDOCUMENTO")
                _numAprobacion = drAprobacion.Item("APROBACION")
                Me.Text += ": " & _numAprobacion
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' Cargar los funcionarios asociados a la dependencia seleccionada en el listado de persona que aprueba.
    Private Sub Cb_Dependencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Dependencia.SelectedIndexChanged
        If IsNumeric(Cb_Dependencia.SelectedValue) AndAlso Cb_Dependencia.SelectedIndex >= 0 Then
            CargarPersonaAprueba()
        End If
        If Cb_Subgerencia.Enabled AndAlso Cb_Dependencia.SelectedIndex >= 0 AndAlso Not IsNothing(Cb_Subgerencia.DataSource) AndAlso Cb_Subgerencia.DataSource.Rows.Count > 0 Then
            CambiarSubgerencia()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CambiarSubgerencia()
        comando = New SqlCommand("SELECT dbo.IdGerenciaXDependencia(@IDDEPENDENCIA)", conexion)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Dim subgerencia As Integer
        Try
            conexion.Open()
            subgerencia = comando.ExecuteScalar()
            conexion.Close()
            Cb_Subgerencia.SelectedValue = subgerencia
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' ¿Listar Consecutivos OC/OS?
    'Private Sub Cb_TipoAprobacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoAprobacion.SelectedIndexChanged
    'End Sub


    ' Abre el cuadro de diálogo que permite ingresar un nuevo tipo de aprobación y selecciona el tipo creado en el listado de tipos de aprobación.
    Private Sub Bt_AgregarTipoAprobacion_Click(sender As Object, e As EventArgs) Handles Bt_AgregarTipoAprobacion.Click
        Select Case Tipo
            Case "OS"
                Dim FrBusqueda As New Fr_Busqueda
                FrBusqueda.Tipo = "OS"
                FrBusqueda.ComboBox_Filtrar.Items.Add("Orden Servicio")
                FrBusqueda.ComboBox_Filtrar.Items.Add("Proveedor")
                FrBusqueda.ComboBox_Filtrar.Items.Add("Nit")
                FrBusqueda.ComboBox_Filtrar.SelectedIndex = 0
                FrBusqueda.ShowDialog()
                Me.Identificador = FrBusqueda.Identificador
                Cargar_OS()
            Case "OC"
                Dim FrBusqueda As New Fr_Busqueda
                FrBusqueda.Tipo = "OC"
                FrBusqueda.ComboBox_Filtrar.Items.Add("Orden Compra")
                FrBusqueda.ComboBox_Filtrar.Items.Add("Proveedor")
                FrBusqueda.ComboBox_Filtrar.Items.Add("Nit")
                FrBusqueda.ComboBox_Filtrar.SelectedIndex = 0
                FrBusqueda.ShowDialog()
                Me.Identificador = FrBusqueda.Identificador
                Cargar_OC()
        End Select


    End Sub

    Private Sub Cargar_OS()
        comando = New SqlCommand("SELECT * FROM DatosAprobacionOS(@IDORDENSERVICIO)", conexion)
        comando.Parameters.AddWithValue("@IDORDENSERVICIO", Identificador)
        adaptador = New SqlDataAdapter(comando)
        Dim dtOS As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtOS)
            conexion.Close()
            If dtOS.Rows.Count > 0 Then
                FilaOS = dtOS.Rows(0)

                Tx_IdentificacionNIT.Text = Trim(FilaOS("Nit"))
                Tx_Proveedor.Text = Trim(FilaOS("Proveedor"))
                Tx_Descripcion.Text = "OS: " & FilaOS("OrdenServicio")
                Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = VariablesBase.VariablesBase.IdPersona
                CuTx_Valor.Valor = FilaOS("ValorTotal")
                Cb_TipoMoneda.SelectedValue = FilaOS("Moneda")
            Else

            End If
            'Marcar_Cajas_Vacias()
        Catch ex As Exception
            MessageBox.Show("No fue posible cargar los datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cargar_OC()
        comando = New SqlCommand("SELECT * FROM DatosAprobacionOC(@IDORDENSERVICIO)", conexion)
        comando.Parameters.AddWithValue("@IDORDENSERVICIO", Identificador)
        adaptador = New SqlDataAdapter(comando)
        Dim dtOC As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtOC)
            conexion.Close()
            If dtOC.Rows.Count > 0 Then
                FilaOC = dtOC.Rows(0)

                Tx_IdentificacionNIT.Text = Trim(FilaOC("Nit"))
                Tx_Proveedor.Text = Trim(FilaOC("Proveedor"))
                Tx_Descripcion.Text = "OC: " & FilaOC("OrdenCompra")
                Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = VariablesBase.VariablesBase.IdPersona
                CuTx_Valor.Valor = FilaOC("ValorTotal")
                Cb_TipoMoneda.SelectedValue = FilaOC("Moneda")
            Else

            End If
            'Marcar_Cajas_Vacias()
        Catch ex As Exception
            MessageBox.Show("No fue posible cargar los datos", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub LimpiarAprobacion()
        Tx_IdentificacionNIT.Text = Nothing
        Tx_Proveedor.Text = ""
        Tx_Descripcion.Text = ""
        Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = -1
        CuTx_Valor.Valor = 0
    End Sub





    ' Abre el cuadro de diálogo de búsqueda de proveedor o contratista dependiendo del tipo seleccionado en el listado de tipos de aprobación.
    Private Sub Bt_BuscarProveedor_Click(sender As Object, e As EventArgs) Handles Bt_BuscarProveedor.Click
        Select Case Cb_TipoAprobacion.SelectedValue
            Case "OC" 'Orden de Compra
                Using frBuscarProveedor As New Fr_BuscarProveedor
                    frBuscarProveedor.Cargar_Tabla()
                    frBuscarProveedor.ShowDialog()

                    comando = New SqlCommand("SELECT * FROM DatosBasicosProveedor(@IDPROVEEDOR)", conexion)
                    comando.Parameters.AddWithValue("@IDPROVEEDOR", frBuscarProveedor.IdProveedor)
                    adaptador = New SqlDataAdapter(comando)
                    Dim dtProveedor As New DataTable
                    Try
                        conexion.Open()
                        adaptador.Fill(dtProveedor)
                        conexion.Close()
                        If dtProveedor.Rows.Count > 0 Then
                            Dim filaProveedor As DataRow = dtProveedor.Rows(0)
                            Tx_IdentificacionNIT.Text = filaProveedor("NIT")
                            Tx_Proveedor.Text = filaProveedor("NOMBRE")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                End Using
            Case Else '"OS" 'Orden de Servicio
                Using frBuscarContratista As New Fr_BuscarContratista
                    frBuscarContratista.Cargar_Tabla()
                    frBuscarContratista.ShowDialog()

                    comando = New SqlCommand("SELECT * FROM DatosBasicosContratista(@IDCONTRATISTA)", conexion)
                    comando.Parameters.AddWithValue("@IDCONTRATISTA", frBuscarContratista.IdContratista)
                    adaptador = New SqlDataAdapter(comando)
                    Dim dtContratista As New DataTable
                    Try
                        conexion.Open()
                        adaptador.Fill(dtContratista)
                        conexion.Close()
                        If dtContratista.Rows.Count > 0 Then
                            Dim filaContratista As DataRow = dtContratista.Rows(0)
                            Tx_IdentificacionNIT.Text = filaContratista("NIT")
                            Tx_Proveedor.Text = filaContratista("NOMBRE")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                End Using
        End Select
    End Sub


    ' Agrega o retira las cifras decimales del valor de la aprobación dependiendo del tipo de moneda seleccionado.
    Private Sub Cb_TipoMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoMoneda.SelectedIndexChanged
        If IsNumeric(Cb_TipoMoneda.SelectedValue) AndAlso Cb_TipoMoneda.SelectedIndex >= 0 Then
            Select Case Cb_TipoMoneda.SelectedValue
                Case 1 'Pesos (COP)
                    CuTx_Valor.PosicionesDecimales = 0
                Case Else
                    CuTx_Valor.PosicionesDecimales = 2
            End Select
        End If
    End Sub


    ' Guardado de la aprobación.
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarAprobacion() Then
            GuardarAprobacion()
        End If
    End Sub


    ''' <summary>
    ''' Verifica que los datos ingresados sean correctos.
    ''' </summary>
    ''' <returns>
    ''' Verdadero si los datos ingresados en el formulario son válidos.
    ''' Falso si hay error(es) en los datos.
    ''' </returns>
    Private Function ValidarAprobacion() As Boolean
        If IsNothing(Cb_Dependencia.SelectedValue) OrElse Cb_Dependencia.SelectedIndex < 0 Then
            MsgBox("Debe indicar la Dependencia.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Cb_Dependencia.Focus()
            Return False
        End If
        If Cb_Subgerencia.Enabled Then
            If Cb_Subgerencia.SelectedIndex < 0 OrElse Cb_Subgerencia.SelectedValue < 0 Then
                MsgBox("Seleccione la Subgerencia.", MsgBoxStyle.Exclamation, "Subgerencia")
                Cb_Subgerencia.Focus()
                Return False
            End If
        End If
        If IsNothing(Cb_TipoAprobacion.SelectedValue) OrElse Cb_TipoAprobacion.SelectedValue = "" Then
            MsgBox("Debe indicar el Tipo de Aprobación.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Cb_TipoAprobacion.Focus()
            Return False
        End If
        If Trim(Tx_IdentificacionNIT.Text) = "" Then
            MsgBox("Debe seleccionar el Proveedor o Contratista.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Tx_IdentificacionNIT.Focus()
            Return False
        End If
        If Trim(Tx_Descripcion.Text) = "" Then
            MsgBox("Debe ingresar la descripción de la Aprobación", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Tx_Descripcion.Focus()
            Return False
        End If
        If Cu_BuscarPersonaAprueba.Cb_Persona.SelectedIndex < 0 OrElse Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue <= 0 Then
            MsgBox("Debe seleccionar la persona que aprueba.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Cu_BuscarPersonaAprueba.Cb_Persona.Focus()
            Return False
        End If
        If CuTx_Valor.Valor <= 0 Then
            MsgBox("Debe ingresar el valor de la Aprobación.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            CuTx_Valor.Select()
            Return False
        End If
        If IsNothing(Cb_TipoMoneda.SelectedValue) OrElse Cb_TipoMoneda.SelectedIndex < 0 Then
            MsgBox("Debe indicar el Tipo de Moneda o divisa.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Cb_TipoMoneda.Focus()
            Return False
        End If
        Return True
    End Function


    ''' <summary>
    ''' Guarda la aprobación en la base de datos.
    ''' Si se creó una aprobación, abre la ventana de notificación con el número de aprobación generado.
    ''' </summary>
    Private Sub GuardarAprobacion()
        comando = New SqlCommand("dbo.GestionarSC_FE_Aprobacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        If Edicion = TipoEdicion.Crear Or Edicion = TipoEdicion.Clonar Then
            comando.Parameters("@ACCION").Value = 1 'Crear
        ElseIf Edicion = TipoEdicion.Modificar Then
            comando.Parameters("@ACCION").Value = 2 'Modificar
        End If
        If Not IsNothing(_idAprobacion) Then 'Guardando aprobación existente.
            comando.Parameters.AddWithValue("@IDAPROBACION", _idAprobacion)
        Else 'Guardando nueva aprobación.
            comando.Parameters.AddWithValue("@IDAPROBACION", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        If Cb_Subgerencia.Enabled Then
            comando.Parameters.AddWithValue("@IDGERENCIA", Cb_Subgerencia.SelectedValue)
        Else
            comando.Parameters.AddWithValue("@IDGERENCIA", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@TIPOAPROBACION", Cb_TipoAprobacion.SelectedValue)
        comando.Parameters.AddWithValue("@NIT", Tx_IdentificacionNIT.Text)
        comando.Parameters.AddWithValue("@PROVEEDOR", Tx_Proveedor.Text)
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        comando.Parameters.AddWithValue("@IDPERSONAAPRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
        comando.Parameters.AddWithValue("@VALOR", CuTx_Valor.Valor)
        comando.Parameters.AddWithValue("@CODIGOTIPOMONEDA", Cb_TipoMoneda.SelectedValue)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@IDDOCUMENTO", Identificador)
            

                Dim paramMensaje As New SqlParameter("@IDMENSAJE", SqlDbType.NVarChar, 8)
                paramMensaje.Direction = ParameterDirection.Output
                comando.Parameters.Add(paramMensaje)
                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    conexion.Close()
                    If Edicion = TipoEdicion.Crear Or Edicion = TipoEdicion.Clonar Then
                        _numAprobacion = paramMensaje.Value
                        Using frNumeroAprobacion As New Fr_NumeroAprobacion(_numAprobacion)
                            frNumeroAprobacion.ShowDialog()
                        End Using
                    Else
                        MessageBox.Show("Datos guardados.", "Aprobación guardada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "FE", "DEPENDENCIA", Cb_Dependencia.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "FE", "FUNCIONARIOAPRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
                    DialogResult = Windows.Forms.DialogResult.OK
                    Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
    End Sub


    ' Cierre del formulario.
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If Edicion = TipoEdicion.Ver Then
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
        Else
            Dim dr As New DialogResult
            dr = MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "Cambios sin guardar")
            If dr = MsgBoxResult.Yes Then
                DialogResult = Windows.Forms.DialogResult.Cancel
                Close()
            End If
        End If
    End Sub


    ' Restablece la base actual del usuario.
    Private Sub Fr_FacturaElectronica_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        VariablesBase.VariablesBase.IdBaseSiscontrolActual = _idBaseTemp
    End Sub

    Private Sub Cb_TipoAprobacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoAprobacion.SelectedIndexChanged
        LimpiarAprobacion()
        If Cb_TipoAprobacion.SelectedValue.ToString = "OS" Then
            Tipo = "OS"
            Bt_AgregarTipoAprobacion.Enabled = True
        ElseIf Cb_TipoAprobacion.SelectedValue.ToString = "OC" Then
            Tipo = "OC"
            Bt_AgregarTipoAprobacion.Enabled = True
        Else
            Bt_AgregarTipoAprobacion.Enabled = False
        End If

    End Sub

End Class 'Fr_FacturaElectronica


''' <summary>
''' Permite crear un nuevo tipo de aprobación.
''' </summary>
Class Fr_AgregarTipoAprobacion
    Inherits Form

    ''' <summary>
    ''' Almacena el identificador del tipo de aprobación creado.
    ''' </summary>
    Private _tipoAprobacion

    Private Pn_Controles As New Panel
    Private Lb_Codigo As New Label
    Private Tx_Codigo As New TextBox
    Private Lb_NombreTipo As New Label
    Private Tx_NombreTipo As New TextBox
    Private Flp_Botones As New FlowLayoutPanel
    Private WithEvents Bt_Guardar As New Button
    Private WithEvents Bt_Cancelar As New Button
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand


    ''' <summary>
    ''' Retorna el identificador del tipo de aprobación creado.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetCodigoTipoAprobacion() As String
        Return _tipoAprobacion
    End Function


    ' Diseña el formulario.
    Private Sub Fr_AgregarAprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Lb_Codigo
            .AutoSize = True
            .Location = New Drawing.Point(55, 23)
            .TabIndex = 0
            .Text = "Codigo:"
        End With
        With Tx_Codigo
            .Location = New Drawing.Point(100, 20)
            .MaxLength = 2
            .TabIndex = 1
            .Width = 40
        End With
        With Lb_NombreTipo
            .AutoSize = True
            .Location = New Drawing.Point(10, 53)
            .TabIndex = 2
            .Text = "Tipo Aprobación:"
        End With
        With Tx_NombreTipo
            .Location = New Drawing.Point(100, 50)
            .MaxLength = 50
            .TabIndex = 3
        End With
        With Pn_Controles
            .Dock = DockStyle.Fill
            .TabIndex = 0
            .Controls.Add(Lb_Codigo)
            .Controls.Add(Tx_Codigo)
            .Controls.Add(Lb_NombreTipo)
            .Controls.Add(Tx_NombreTipo)
        End With
        With Bt_Guardar
            .UseVisualStyleBackColor = True
            .TabIndex = 0
            .Text = "Guardar"
        End With
        With Bt_Cancelar
            .DialogResult = Windows.Forms.DialogResult.Cancel
            .UseVisualStyleBackColor = True
            .TabIndex = 1
            .Text = "Cancelar"
        End With
        With Flp_Botones
            .BackColor = Drawing.Color.Silver
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .TabIndex = 1
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Guardar)
        End With
        With Me
            .CancelButton = Bt_Cancelar
            .Height = 155
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            .MaximizeBox = False
            .MinimizeBox = False
            .StartPosition = FormStartPosition.CenterParent
            .Text = "Agregar Tipo de Aprobación"
            .Width = 230
            .Controls.Add(Pn_Controles)
            .Controls.Add(Flp_Botones)
        End With
    End Sub


    ' Guardado del tipo de aprobación a crear.
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarTipoAprobacion() Then
            Dim tipoApr As String = Trim(Tx_Codigo.Text)
            comando = New SqlCommand("dbo.GestionarSC_FE_TipoAprobacion", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@ACCION", 1)
            comando.Parameters.AddWithValue("@CODIGOTIPOAPROBACION", tipoApr)
            comando.Parameters.AddWithValue("@NOMBRETIPOAPROBACION", Trim(Tx_NombreTipo.Text))
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
                _tipoAprobacion = tipoApr
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub


    ''' <summary>
    ''' Verifica si los datos ingresados en el formulario son correctos.
    ''' </summary>
    ''' <returns>Verdadero si los datos son válidos. Falso si se presentan errores.</returns>
    Private Function ValidarTipoAprobacion() As Boolean
        If Trim(Tx_Codigo.Text) = "" Then
            MsgBox("Debe ingresar las iniciales del tipo de Aprobación.")
            Tx_Codigo.Focus()
            Return False
        End If
        If Trim(Tx_NombreTipo.Text) = "" Then
            MsgBox("Debe ingresar el nombre del tipo de Aprobación.")
            Tx_NombreTipo.Focus()
            Return False
        End If
        Return True
    End Function


    ' Cierre del formulario.
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub

End Class 'Fr_AgregarTipoAprobacion