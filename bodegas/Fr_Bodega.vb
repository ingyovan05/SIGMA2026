Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class Fr_Bodega
    Property IdBodega As Integer
    Property EditandoBodega As Boolean
    Property SoloLectura As Boolean = False

    Public Sub New()
        InitializeComponent()
        Cu_Bp_VBSubgerencia.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_Bp_VBSubgerencia.Tag)
        Bt_CrearBase.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_CrearBase.Tag)
        Bt_CrearDependencia.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_CrearDependencia.Tag)
        Cu_CentroCosto1.Editando = 0
    End Sub


    Private Sub CargarListadoGerencias()
        Dim dt_Gerencias As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT IDGERENCIA, NOMBREGERENCIA FROM SC_GERENCIA WHERE ACTIVO = 'S'", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_Gerencias)
            conexion.Close()
            Cb_Gerencia.DataSource = dt_Gerencias
            Cb_Gerencia.DisplayMember = "NOMBREGERENCIA"
            Cb_Gerencia.ValueMember = "IDGERENCIA"
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub




    Public Sub CargarDatos()
        Cu_Ciudad_Bodega.CargarDatos()
        Cu_Ciudad_OC.CargarDatos()

        Cu_Bp_VBSubgerencia.CargarDatos()
        Cu_Bp_VBSubgerencia.Cb_Persona.SelectedIndex = -1

        Dim dt_Empresa As New DataTable
        dt_Empresa.Columns.Add("IdEmpresa")
        dt_Empresa.Columns.Add("Nombre")
        dt_Empresa.Rows.Add("0", "ISMOCOL")
        dt_Empresa.Rows.Add("2", "ZAMORANA")
        Cb_Empresa.DataSource = dt_Empresa
        Cb_Empresa.ValueMember = "IdEmpresa"
        Cb_Empresa.DisplayMember = "Nombre"

        If Not EditandoBodega Then
            CargarBasesSC()
        End If

        cargarpersonalasociadobodega()
        Marcar_Cajas_Vacias()
    End Sub

    Private Sub Fr_Bodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarListadoGerencias()
        If EditandoBodega = True Then
            CargarBodega()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        If Validar_Bodega() = True Then
            GuardarBodega()
        End If
    End Sub

    Private Sub GuardarBodega()
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarBodega")
        Comando.CommandType = CommandType.StoredProcedure
        If EditandoBodega = True Then
            ' Llamar al procedimiento para crear el tipo categoría
            Comando.Parameters.AddWithValue("@ACCION", 2)
            Comando.Parameters.AddWithValue("@IDBODEGA", IdBodega)
        Else
            Comando.Parameters.AddWithValue("@ACCION", 1)
            Comando.Parameters.AddWithValue("@IDBODEGA", -1)
        End If
        Comando.Parameters.AddWithValue("@NOMBRE", Trim(Me.Tx_Nombre.Text))
        Comando.Parameters.AddWithValue("@ABREVIATURA", Trim(Me.Tx_Abreviatura.Text))
        Comando.Parameters.AddWithValue("@DIRECCION", Trim(Me.Tx_Direccion.Text))
        Comando.Parameters.AddWithValue("@INDICACIONDIRECCION", Trim(Me.Tx_Indicaciones.Text))
        Comando.Parameters.AddWithValue("@CODIGOCIUDAD", Me.Cu_Ciudad_Bodega.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@TELEFONOBODEGA", Trim(Me.Tx_TelefonoBodega.Text))
        Comando.Parameters.AddWithValue("@CELULARBODEGA", Trim(Me.Tx_CelularBodega.Text))
        Comando.Parameters.AddWithValue("@CORREOELECTRONICOBODEGA", Trim(Me.Tx_CorreoBodega.Text))
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@TELEFONOCOMPRA", Trim(Me.Tx_TelefonoCompra.Text))
        Comando.Parameters.AddWithValue("@CELULARCOMPRA", Trim(Me.Tx_CelularCompra.Text))
        Comando.Parameters.AddWithValue("@CORREOELECTRONICOCOMPRA", Trim(Me.Tx_CorreoCompra.Text))
        Comando.Parameters.AddWithValue("@CODIGOCIUDADORDENCOMPRA", Me.Cu_Ciudad_OC.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAVBSUBGERENCIA", Cu_Bp_VBSubgerencia.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Dim tipoDeBodega As String
        If Ck_EsBodegaPrincipal.Checked = True Then
            tipoDeBodega = "P"
        Else
            tipoDeBodega = "S"
        End If
        Comando.Parameters.AddWithValue("@TIPOBODEGA", tipoDeBodega)
        Comando.Parameters.AddWithValue("@IDEMPRESA", Cb_Empresa.SelectedValue)
        Comando.Parameters.AddWithValue("@IDGERENCIA", Cb_Gerencia.SelectedValue)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Comando.Connection = conn
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            MessageBox.Show("Cambios guardados correctamente.", "GUARDAR BODEGA", MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al momento de guardar la bodega.", "NO SE GUARDÓ LA BODEGA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Me.Close()
    End Sub

    Public Sub CargarBodega()
        Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlClient.SqlCommand("SELECT * FROM DatosBodega(@IDBODEGA)", Conexion)
        Comando.Parameters.AddWithValue("@IDBODEGA", IdBodega)
        Dim adapt As New SqlDataAdapter(Comando)
        Dim dt_Bodega As New DataTable
        Try
            Conexion.Open()
            adapt.Fill(dt_Bodega)
            Conexion.Close()
            Dim Fila_Bodega As DataRow
            Fila_Bodega = dt_Bodega(0)
            Tx_Nombre.Text = Trim(UCase(Fila_Bodega("NOMBRE")))
            Tx_Abreviatura.Text = Trim(UCase(Fila_Bodega("ABREVIATURA")))
            Tx_Direccion.Text = Trim(UCase(Fila_Bodega("DIRECCION")))
            Tx_Indicaciones.Text = Trim(UCase(Fila_Bodega("INDICACIONDIRECCION")))
            Cu_Ciudad_Bodega.Cb_Ciudad.SelectedValue = Fila_Bodega("CODIGOCIUDAD")
            Tx_TelefonoBodega.Text = Trim(Fila_Bodega("TELEFONOBODEGA"))
            Tx_CelularBodega.Text = Trim(Fila_Bodega("CELULARBODEGA"))
            Tx_CorreoBodega.Text = Trim(UCase(Fila_Bodega("CORREOELECTRONICOBODEGA")))
            Tx_TelefonoCompra.Text = Trim(Fila_Bodega("TELEFONOCOMPRA"))
            Tx_CelularCompra.Text = Trim(Fila_Bodega("CELULARCOMPRA"))
            Cu_CentroCosto1.IdCentroCosto = Fila_Bodega("IDCENTROCOSTO")
            Cu_CentroCosto1.CargarCentro()
            Tx_CorreoCompra.Text = Trim(UCase(Fila_Bodega("CORREOELECTRONICOCOMPRA")))
            Cu_Ciudad_OC.Cb_Ciudad.SelectedValue = Trim(UCase(Fila_Bodega("CODIGOCIUDADORDENCOMPRA")))
            If Fila_Bodega("TIPOBODEGA") = "P" Then
                Ck_EsBodegaPrincipal.Checked = True
            Else
                Ck_EsBodegaPrincipal.Checked = False
            End If
            If EditandoBodega Then
                Ck_EsBodegaPrincipal.Enabled = False
                Cb_Empresa.Enabled = False
                If SoloLectura Then
                    Tx_Nombre.ReadOnly = True
                    Tx_Abreviatura.ReadOnly = True
                    Tx_Direccion.ReadOnly = True
                    Cu_Ciudad_Bodega.Enabled = False
                    Tx_Indicaciones.ReadOnly = True
                    Tx_CelularBodega.ReadOnly = True
                    Tx_TelefonoBodega.ReadOnly = True
                    Tx_CorreoBodega.ReadOnly = True
                    Tx_CelularCompra.ReadOnly = True
                    Tx_TelefonoCompra.ReadOnly = True
                    Tx_CorreoCompra.ReadOnly = True
                    Cu_Ciudad_OC.Enabled = False
                    Cu_Bp_VBSubgerencia.Enabled = False
                    Cu_CentroCosto1.Enabled = False
                    Cb_Base.Enabled = False
                    Bt_CrearBase.Enabled = False
                    Cb_Dependencia.Enabled = False
                    Bt_CrearDependencia.Enabled = False
                    Cb_Gerencia.Enabled = False
                    Btn_Aceptar.Enabled = False
                    Btn_Cancelar.Select()
                End If
            End If
            Cb_Empresa.SelectedValue = Fila_Bodega("IDEMPRESA")
            Cb_Gerencia.SelectedValue = Fila_Bodega("IDGERENCIA")
            Cu_Bp_VBSubgerencia.Cb_Persona.SelectedValue = Fila_Bodega("IDPERSONAVBSUBGERENCIA")
            CargarBaseXDependencia(Fila_Bodega("IDDEPENDENCIA"))
            CargarDependencia(Fila_Bodega("IDDEPENDENCIA"))
        Catch ex As Exception

        Finally
            Conexion.Close()
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Function Validar_Bodega() As Boolean
        If Cu_Ciudad_Bodega.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Seleccione el municipio donde esta ubicada la bodega", MsgBoxStyle.Information, "Municipio de la Bodega")
            Me.Cu_Ciudad_Bodega.Cb_Ciudad.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Cu_Ciudad_OC.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Seleccione el municipio donde esta ubicado el comprador", MsgBoxStyle.Information, "Municipio del comprador")
            Me.Cu_Ciudad_OC.Cb_Ciudad.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Me.Tx_Nombre.Text = "" Then
            MsgBox("Agregue un Nombre a la bodega", MsgBoxStyle.Information, "Nombre")
            Tx_Nombre.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Tx_Abreviatura.Text = "" Then
            MsgBox("Agregue una Abreviatura a la bodega", MsgBoxStyle.Information, "Abreviatura")
            Tx_Abreviatura.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Tx_Direccion.Text = "" Then
            MsgBox("Agregue una Dirección a la bodega", MsgBoxStyle.Information, "Dirección")
            Tx_Direccion.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Tx_TelefonoBodega.Text = "" And Tx_CelularBodega.Text = "" Then
            MsgBox("Agregue un número de Teléfono o Celular a la bodega", MsgBoxStyle.Information, "Teléfono o Celular")
            Tx_TelefonoBodega.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If IsNumeric(Tx_CelularBodega.Text) = False Then
            MsgBox("El Celular debe ser Numérico", MsgBoxStyle.Information, "Celular")
            Tx_CelularBodega.Text = ""
            Tx_CelularBodega.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If IsNumeric(Tx_TelefonoBodega.Text) = False Then
            MsgBox("El Teléfono debe ser Numérico", MsgBoxStyle.Information, "Teléfono")
            Tx_TelefonoBodega.Text = ""
            Tx_TelefonoBodega.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Cu_CentroCosto1.IdCentroCosto < 1 Then
            MsgBox("Debe seleccionar el Centro de Costos al cual está relacionada la bodega", MsgBoxStyle.Information, "Centro de Costos")
            Validar_Bodega = False
            Exit Function
        End If

        If Cu_Bp_VBSubgerencia.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el subgerente que da el visto bueno.", MsgBoxStyle.Information, "Visto bueno Subgerencia")
            Cu_Bp_VBSubgerencia.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        If Cb_Dependencia.SelectedIndex = -1 Then
            MsgBox("Seleccione la dependencia de SisControl al cual pertenece la bodega", MsgBoxStyle.Information, "Dependencia de SisControl")
            Me.Cb_Dependencia.Focus()
            Validar_Bodega = False
            Exit Function
        End If

        Validar_Bodega = True
    End Function

    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer

        Dim array As New ArrayList
        array.Add(Cu_Bp_VBSubgerencia.Name)

        For i = 0 To array.Count - 1
            Dim ctl As Control = Me.GetNextControl(Me, True)
            Do Until ctl Is Nothing
                If ctl.Name = array(i) Then
                    Dim obj As Object
                    obj = ctl
                    temp = obj.Cb_Persona.SelectedValue
                    obj.CargarDatos()
                    obj.Cb_Persona.SelectedValue = temp
                    If NOMBRECOMPONENTE = obj.name Then
                        obj.Cb_Persona.SelectedValue = IDPERSONA
                    End If
                End If
                ctl = Me.GetNextControl(ctl, True)
            Loop
        Next
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Cu_Bp_VBSubgerencia.Name
                Try
                    filas = Cu_Bp_VBSubgerencia.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_Bp_VBSubgerencia.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_Bp_VBSubgerencia.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_Bp_VBSubgerencia.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Tx_Nombre.GotFocus, Tx_Abreviatura.GotFocus, Tx_Direccion.GotFocus, Tx_CelularBodega.GotFocus
        Dim Objeto As Object = sender

        Select Case Objeto.name
            Case "Cu_Bp_VBSubgerencia"
                Cu_Bp_VBSubgerencia.Cb_Persona.BackColor = Color.MintCream
            Case Else
                Objeto.backcolor = Color.MintCream
        End Select
    End Sub

    Private Sub TextBox_PrimerNombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Tx_Nombre.LostFocus, Tx_Abreviatura.LostFocus, Tx_Direccion.LostFocus, Tx_CelularBodega.LostFocus, Tx_TelefonoBodega.LostFocus

        Dim Objeto As Object = sender
        Select Case Objeto.name
            Case "Cu_Bp_VBSubgerencia"
                If Cu_Bp_VBSubgerencia.Cb_Persona.Text = "" Then
                    Cu_Bp_VBSubgerencia.Cb_Persona.BackColor = Color.Salmon
                Else
                    Cu_Bp_VBSubgerencia.Cb_Persona.BackColor = Color.White
                End If
            Case Else
                Objeto.backcolor = Color.White
                If sender.text = "" Or sender.text = "SIN INFORMACION" Or
                          sender.text = "SE DESCONOCE" Or sender.text = "SIN IDENTIFICAR" Then
                    sender.backcolor = Color.Salmon
                End If
        End Select
    End Sub

    Private Sub Marcar_Cajas_Vacias()
        If Not EditandoBodega Then
            If Cu_Ciudad_Bodega.Cb_Ciudad.Text = "" Then
                Cu_Ciudad_Bodega.Cb_Ciudad.BackColor = Color.Salmon
            Else
                Cu_Ciudad_Bodega.Cb_Ciudad.BackColor = Color.White
            End If

            If Cu_Ciudad_OC.Cb_Ciudad.Text = "" Then
                Cu_Ciudad_OC.Cb_Ciudad.BackColor = Color.Salmon
            Else
                Cu_Ciudad_OC.Cb_Ciudad.BackColor = Color.White
            End If

            If Tx_Nombre.Text = "" Then
                Tx_Nombre.BackColor = Color.Salmon
            Else
                Tx_Nombre.BackColor = Color.White
            End If
            If Tx_Abreviatura.Text = "" Then
                Tx_Abreviatura.BackColor = Color.Salmon
            Else
                Tx_Abreviatura.BackColor = Color.White
            End If
            If Tx_Direccion.Text = "" Then
                Tx_Direccion.BackColor = Color.Salmon
            Else
                Tx_Direccion.BackColor = Color.White
            End If

            If Tx_TelefonoBodega.Text = "" Then
                Tx_TelefonoBodega.BackColor = Color.Salmon
            Else
                Tx_TelefonoBodega.BackColor = Color.White
            End If

            If Tx_CelularBodega.Text = "" Then
                Tx_CelularBodega.BackColor = Color.Salmon
            Else
                Tx_CelularBodega.BackColor = Color.White
            End If

            If Cu_Bp_VBSubgerencia.Cb_Persona.Text = "" Then
                Cu_Bp_VBSubgerencia.Cb_Persona.BackColor = Color.Salmon
            Else
                Cu_Bp_VBSubgerencia.Cb_Persona.BackColor = Color.White
            End If

            If Cb_Dependencia.Text = "" Then
                Cb_Dependencia.BackColor = Color.Salmon
            Else
                Cb_Dependencia.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Base.SelectedIndexChanged
        If IsNumeric(Cb_Base.SelectedValue) Then
            CargarDependenciasSC(Cb_Base.SelectedValue)
        End If
    End Sub

    ''' <summary>
    ''' Asigna el listado de todas las Bases activas al componente Cb_Base.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargarBasesSC()
        Dim dt_BaseSC As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 7)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_BaseSC)
            conexion.Close()
            Cb_Base.DataSource = dt_BaseSC
            Cb_Base.DisplayMember = "BASE"
            Cb_Base.ValueMember = "IDBASESISCONTROL"
            Cb_Base.SelectedIndex = 0
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        CargarDependenciasSC(Cb_Base.SelectedValue)
    End Sub

    ''' <summary>
    ''' Asigna el nombre de la Base a la cual pertenece la Dependencia cargada al componente Cb_Base.
    ''' </summary>
    ''' <param name="IdDependencia">Dependencia cargada</param>
    ''' <remarks></remarks>
    Private Sub CargarBaseXDependencia(ByVal IdDependencia As Integer)
        Dim dt_BaseSC As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 1)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", IdDependencia)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_BaseSC)
            conexion.Close()
            Cb_Base.DataSource = dt_BaseSC
            Cb_Base.DisplayMember = "BASE"
            Cb_Base.ValueMember = "IDBASESISCONTROL"
            Cb_Base.SelectedIndex = 0
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Asigna el listado de las dependencias de una base al componente Cb_Dependencia al cargar el listado de bases o cambiar el valor seleccionado de Cb_Base.
    ''' </summary>
    ''' <param name="IdBase">Base de la cual se cargan las dependencias</param>
    ''' <remarks></remarks>
    Private Sub CargarDependenciasSC(ByVal IdBase As Integer)
        Dim dt_DependenciaSC As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 8)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBase)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_DependenciaSC)
            conexion.Close()
            Cb_Dependencia.DataSource = dt_DependenciaSC
            Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
            Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
            Cb_Dependencia.SelectedIndex = 0
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Asigna el nombre de la Dependencia cargada al componente Cb_Dependencia.
    ''' </summary>
    ''' <param name="IdDependencia">Dependencia a asignar</param>
    ''' <remarks></remarks>
    Private Sub CargarDependencia(ByVal IdDependencia As Integer)
        Dim dt_DependenciaSC As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 4)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", IdDependencia)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_DependenciaSC)
            conexion.Close()
            Cb_Dependencia.DataSource = dt_DependenciaSC
            Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
            Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
            Cb_Dependencia.SelectedIndex = 0
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    Private Sub Bt_CrearBase_Click(sender As Object, e As EventArgs) Handles Bt_CrearBase.Click
        Dim frBase As New FormulariosSisControl.Fr_BaseDependencia
        frBase.Edicion = False
        Dim dr As DialogResult
        dr = frBase.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            CargarBaseXDependencia(frBase.IdDependencia)
            CargarDependencia(frBase.IdDependencia)
        End If
    End Sub

    Private Sub Bt_CrearDependencia_Click(sender As Object, e As EventArgs) Handles Bt_CrearDependencia.Click
        Dim frDependencia As New FormulariosSisControl.Fr_BaseDependencia
        frDependencia.IdBase = Cb_Base.SelectedValue
        frDependencia.Edicion = False
        Dim dr As DialogResult
        dr = frDependencia.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            CargarBaseXDependencia(frDependencia.IdDependencia)
            CargarDependencia(frDependencia.IdDependencia)
        End If
    End Sub

End Class