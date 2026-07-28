Public Class Cu_BuscarPersona

    Public _valorcajatexto As String
    Private _Tipo As String
    Private _FechaReporteDiario As Date
    Public idpersonaincluir As Integer = -1
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter
    Dim _IdPersonaIncluirCarga As Integer

    Public DT_BUSCARPERSONA As New DataTable

    Public Property valorcajatexto() As String
        Get
            Return CType(_valorcajatexto, String)
        End Get
        Set(value As String)
            _valorcajatexto = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return CType(_Tipo, String)
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property FechaReporteDiario() As Date
        Get
            Return CType(_FechaReporteDiario, Date)
        End Get
        Set(value As Date)
            _FechaReporteDiario = value
        End Set
    End Property


    Public Sub New()
        InitializeComponent()
        AddHandler Cb_Persona.KeyDown, AddressOf FuncionesBase.FuncionesBase.ComboBoxAutocompletar_KeyDown
    End Sub

    Private Sub Cu_BuscarPersona_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            CargarCajaTexto()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CargarCajaTexto()
        Try
            Dim adap As New Dscomunes.Ds_MaestrosTableAdapters.PERSONABASICOTableAdapter
            Dim dspersona As New Dscomunes.Ds_Maestros
            adap.FillIDPERSONA(dspersona.PERSONABASICO, Me.Cb_Persona.SelectedValue)
            Dim Fila As DataRow = dspersona.PERSONABASICO.Rows(0)
            Me.Tx_TextoCódigo.Text = Fila(valorcajatexto)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ExcluirLista(ByVal valor As Integer)
        Try
            Dim filas() As DataRow
            filas = DT_BUSCARPERSONA.Select("IDPERSONA=" + valor.ToString)
            Dim fila As DataRow
            fila = filas(0)
            Me.DT_BUSCARPERSONA.Rows.Remove(fila)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CargarDatos(Optional IdPersonaIncluirCarga As Integer = -1)
        Try
            Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion

            cmde.CommandText = "dbo.ListaTercerosFiltrada"

            cmde.Parameters.Add("@Tipo", SqlDbType.NChar).Value = _Tipo
            cmde.Parameters.Add("@IdbodegaActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual
            cmde.Parameters.Add("@IddependenciaSiscontrol", SqlDbType.Int).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda
            cmde.Parameters.Add("@IdBaseSiscontrolActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
            cmde.Parameters.Add("@IdPersonaIncluirCarga", SqlDbType.Int).Value = IdPersonaIncluirCarga

            _IdPersonaIncluirCarga = IdPersonaIncluirCarga

            da = New SqlClient.SqlDataAdapter(cmde)

            Me.DT_BUSCARPERSONA.Clear()

            da.Fill(DT_BUSCARPERSONA)
            sqlconeccion.Close()
            Me.Cb_Persona.DataSource = DT_BUSCARPERSONA
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarDatosPersona(Optional IdPersonaIncluirCarga As Integer = -1)
        Try
            Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion

            cmde.CommandText = "dbo.ListaTercerosCompleta"

            _IdPersonaIncluirCarga = IdPersonaIncluirCarga

            da = New SqlClient.SqlDataAdapter(cmde)

            Me.DT_BUSCARPERSONA.Clear()

            da.Fill(DT_BUSCARPERSONA)
            sqlconeccion.Close()
            Me.Cb_Persona.DataSource = DT_BUSCARPERSONA
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarDatosLocal()
        Try
            Select Case _Tipo
                Case "PAP"
                    Me.Cb_Persona.DataSource = VariablesBase.VariablesBase.TablaPERSONABUSCAR
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cb_Persona_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Persona.SelectedIndexChanged
        Try
            CargarCajaTexto()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Cb_Persona.GotFocus, Tx_TextoCódigo.GotFocus

        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.MintCream
    End Sub

    Private Sub TextBox_PrimerNombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Cb_Persona.LostFocus, Tx_TextoCódigo.LostFocus

        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.White
    End Sub

    Private Sub Bt_BuscarPersonas_Click(sender As System.Object, e As System.EventArgs) Handles Button_Buscar.Click
        Dim FrBuscarPersona As New Fr_BuscarPersona
        FrBuscarPersona.idpersonaincluir = idpersonaincluir
        FrBuscarPersona.Cargar_Tabla(Tipo, _IdPersonaIncluirCarga)
        FrBuscarPersona.Text = Me.Button_Buscar.Tag
        FrBuscarPersona.ShowDialog()
        Try
            Me.Cb_Persona.SelectedValue = FrBuscarPersona.IdPersona
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tx_TextoCódigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_TextoCódigo.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                'Buscar la persona por Código contrato o por Cédula

                Dim Padre As New Object
                Padre = Me.ParentForm
                Padre.EventoCajaEnter(Me.Name)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
