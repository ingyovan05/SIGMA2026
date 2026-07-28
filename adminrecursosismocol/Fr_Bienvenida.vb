Imports System.Data.SqlClient
Imports VarBase = VariablesBase.VariablesBase
Imports System.Text

Public Class Fr_Bienvenida
    Property frPadre As Fr_Principal
    Private idPersona As Integer?
    Private tempEmailCorporativo As String
    Private tempMovilCorporativo As String
    Private idBodegaDefecto As Integer
    Private idBaseDefecto As Integer
    Private idDependenciaDefecto As Integer
    Private tempIdBodegaActual As Integer
    Private tempIdBaseActual As Integer
    Private tempIdDependenciaActual As Integer
    Private dtProyecto As New DataTable("PROYECTO")
    Private dtBodega As New DataTable("BODEGA")
    Private dtBase As New DataTable("SC_BASE")
    Private dtDependencia As New DataTable("SC_DEPENDENCIA")
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private contactoActualizado As Boolean = False
    Private estadoMostrarSiempre As Boolean

    Private Sub Fr_Bienvenida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idPersona = VarBase.IdPersona
        Lb_Nombre.Text = VarBase.Nombre_Usuario
        tempIdBodegaActual = VarBase.IdBodegaActual
        tempIdBaseActual = VarBase.IdBaseSiscontrolActual
        tempIdDependenciaActual = VarBase.IddependenciaSiscontrolActual
        CargarDatosControles()
    End Sub

    Private Sub Fr_Bienvenida_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Cb_Proyecto.SelectedIndexChanged, AddressOf Cb_Proyecto_SelectedIndexChanged
        Bt_Aceptar.Select()
    End Sub

    Private Sub Bt_ActualizarContacto_Click(sender As Object, e As EventArgs) Handles Bt_ActualizarContacto.Click
        If ActualizarContacto() Then
            contactoActualizado = True
        End If
    End Sub

    Private Sub Cb_Proyecto_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Wb_Noticias_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles Wb_Noticias.Navigating
        If Wb_Noticias.DocumentText <> "" Then
            Process.Start(e.Url.ToString)
            e.Cancel = True
        End If
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Not contactoActualizado AndAlso _
           (Tx_EmailCorporativo.Text <> tempEmailCorporativo OrElse _
           Tx_MovilCorporativo.Text <> tempMovilCorporativo) Then
            Dim dr As DialogResult
            dr = MessageBox.Show("¿Desea actualizar los datos de contacto?", "Actualizar Contacto", MessageBoxButtons.YesNo)
            If dr = DialogResult.Yes Then
                If Not ActualizarContacto() Then
                    Exit Sub
                End If
            End If
        End If
        If Cb_Proyecto.SelectedIndex >= 0 Then
            Dim filaProyecto As DataRow = dtProyecto.Select(Cb_Proyecto.ValueMember & " = " & Cb_Proyecto.SelectedValue)(0)
            If filaProyecto("IDBODEGA") <> tempIdBodegaActual Then
                CambiarBodega(filaProyecto("IDBODEGA"))
            End If
            If filaProyecto("IDDEPENDENCIA") <> tempIdDependenciaActual Then
                CambiarDependencia(filaProyecto("IDDEPENDENCIA"))
            End If
            Try
                frPadre.CargarInformacionBarraDeEstado()
            Catch ex As Exception

            End Try
        End If
        GuardarPreferencias()
        Me.Close()
    End Sub


    Private Sub CargarDatosControles()
        comando = New SqlCommand("dbo.CargarBienvenida", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        adaptador = New SqlDataAdapter(comando)
        Dim dsBienvenida As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsBienvenida)
            conexion.Close()

            ' 0 --> Persona
            ' 1 --> Contacto
            ' 2 --> Bodegas
            ' 3 --> Bases
            ' 4 --> Dependencias
            ' 5 --> Proyectos
            ' 6 --> Noticia

            Dim filaPersona As DataRow = dsBienvenida.Tables(0).Rows(0)
            Select Case filaPersona("GENERO")
                Case "F"
                    Lb_TextoBienvenido.Text = "Bienvenida,"
                Case "M"
                    Lb_TextoBienvenido.Text = "Bienvenido,"
                Case Else
                    Lb_TextoBienvenido.Text = "Bienvenido(a),"
            End Select

            'Datos de contacto y preferencias
            Dim filaContacto As DataRow = dsBienvenida.Tables(1).Rows(0)
            tempMovilCorporativo = Trim(filaContacto("TELEFONOMOVILCORPORATIVO"))
            Tx_MovilCorporativo.Text = tempMovilCorporativo
            tempEmailCorporativo = Trim(filaContacto("CORREOELECTRONICOCORPORTATIVO"))
            Tx_EmailCorporativo.Text = tempEmailCorporativo
            estadoMostrarSiempre = If(filaContacto("MOSTRARBIENVENIDA") = "S", True, False)
            Ck_MostrarSiempre.Checked = estadoMostrarSiempre

            idBodegaDefecto = filaContacto("IDBODEGA")
            idBaseDefecto = filaContacto("IDBASESISCONTROL")
            idDependenciaDefecto = filaContacto("IDDEPENDENCIA")

            'Bodegas, bases y dependencias
            dtBodega = dsBienvenida.Tables(2)
            dtBase = dsBienvenida.Tables(3)
            dtDependencia = dsBienvenida.Tables(4)
            dtProyecto = dsBienvenida.Tables(5)
            Cb_Proyecto.DataSource = dtProyecto
            If dtProyecto.Rows.Count = 0 Then
                Cb_Proyecto.Enabled = False
            End If

            If Not IsDBNull(filaContacto("IDPROYECTORECIENTE")) Then
                Cb_Proyecto.SelectedValue = filaContacto("IDPROYECTORECIENTE")
            Else
                Dim drResultados() As DataRow = dtProyecto.Select("IDBODEGA = " & VarBase.IdBodegaActual & " OR IDDEPENDENCIA = " & VarBase.IddependenciaSiscontrolActual)
                If drResultados.Length > 0 Then
                    Cb_Proyecto.SelectedValue = drResultados(0).Item("IDPROYECTO")
                Else
                    Cb_Proyecto.SelectedIndex = -1
                End If
            End If

            'Noticias y actualizaciones
            Dim filaNoticia As DataRow = dsBienvenida.Tables(6).Rows(0)
            Wb_Noticias.DocumentText = filaNoticia.Item("TEXTO")
        Catch ex As Exception
            MessageBox.Show("Error de conexión", "Bienvenida", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    Private Function ActualizarContacto() As Boolean
        If Me.Tx_EmailCorporativo.Text <> "" Then
            If Not FuncionesBase.FuncionesBase.validarCorreoCorporativo(Tx_EmailCorporativo.Text) Then
                MessageBox.Show("El correo electrónico corporativo no cumple con el formato (ejemplo@ismocol.com).", "Correo electrónico corporativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If
        comando = New SqlCommand("dbo.ActualizarContacto", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        comando.Parameters.AddWithValue("@CORREOELECTRONICO", DBNull.Value)
        comando.Parameters.AddWithValue("@TELEFONOMOVIL", DBNull.Value)
        comando.Parameters.AddWithValue("@CORREOELECTRONICOCORPORTATIVO", Trim(Tx_EmailCorporativo.Text))
        comando.Parameters.AddWithValue("@TELEFONOMOVILCORPORATIVO", Trim(Tx_MovilCorporativo.Text))
        comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", idPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show("No fue posible actualizar los datos de contacto.")
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Private Sub CambiarBodega(idBodega As Integer)
        Dim filabodega As DataRow = dtBodega.Select("IDBODEGA" & " = " & idBodega)(0)
        VarBase.IdBodegaActual = idBodega
        VarBase.AbreviaturaBodegaActual = filabodega("ABREVIATURA")
        VarBase.NombreBodegaActual = filabodega("NOMBRE")
        VarBase.DireccionBodegaActual = filabodega("DIRECCION")
        VarBase.IdCentroCostoBodegaActual = filabodega("IDCENTROCOSTO")
        VarBase.TipoBodegaActual = filabodega("TIPOBODEGA")
        VarBase.EmpresaBodegaActual = filabodega("IDEMPRESA")
    End Sub

    Private Sub CambiarDependencia(idDependencia As Integer)
        Dim filaBase As DataRow
        Dim filaDependencia As DataRow
        filaBase = dtBase.Select("IDBASESISCONTROL = " & dtDependencia.Select("IDDEPENDENCIA = " & idDependencia)(0).Item("IDBASESISCONTROL"))(0)
        VarBase.IdBaseSiscontrolActual = filaBase("IDBASESISCONTROL")
        VarBase.NombreBaseSiscontrol = filaBase("NOMBREBASE")
        VarBase.AbreviaturaBaseSiscontrol = filaBase("ABREVIATURABASE")
        If filaBase("IDBASESISCONTROL") = idBaseDefecto Then
            idDependencia = idDependenciaDefecto
        End If
        filaDependencia = dtDependencia.Select("IDDEPENDENCIA = " & idDependencia)(0)
        VarBase.IddependenciaSiscontrolActual = filaDependencia("IDDEPENDENCIA")
        VarBase.NombreDependenciaSiscontrol = filaDependencia("NOMBREDEPENDENCIA")
        VarBase.IdCentroCostoSisControl = filaDependencia("IDCENTROCOSTO")
        VarBase.EmpresaSisControlActual = filaDependencia("IDEMPRESA")
    End Sub

    Private Sub GuardarPreferencias()
        Dim cadena As String
        cadena = "UPDATE USUARIO " & _
                 "SET " & _
                 "MOSTRARBIENVENIDA = @MOSTRARBIENVENIDA, " & _
                 "IDPROYECTORECIENTE = @IDPROYECTO " & _
                 "WHERE IDPERSONA = @IDPERSONA;"
        comando = New SqlCommand(cadena, conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        comando.Parameters.AddWithValue("@MOSTRARBIENVENIDA", If(Ck_MostrarSiempre.Checked, "S", "N"))
        comando.Parameters.AddWithValue("@IDPROYECTO", Cb_Proyecto.SelectedValue)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            conexion.Close()
        End Try
    End Sub

End Class