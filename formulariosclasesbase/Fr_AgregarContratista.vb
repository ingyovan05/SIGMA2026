Imports System.Data.SqlClient

Public Class Fr_AgregarContratista
    Public Identificacion As String
    Public IdContratista As Integer = -1
    Public Editando As Boolean = False



    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click
        If ValidarContratista() Then
            GuardarContratista()
        End If
    End Sub

    Private Sub GuardarContratista()
        Identificacion = Replace(Replace(Tb_Identificacion.Text, ",", ""), ".", "")
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarContratista")
        Comando.CommandType = CommandType.StoredProcedure
        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@IDCONSTRATISTA", IdContratista)
        Comando.Parameters.AddWithValue("@IDENTIFICACION", Identificacion)
        Comando.Parameters.AddWithValue("@NOMBRE", UCase(Tb_Nombre.Text))
        Comando.Parameters.AddWithValue("@ESTADO", "A")
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@DIRECCION", UCase(Tb_Dirrecion.Text))
        Comando.Parameters.AddWithValue("@DIGITOVERIFICACION", _Tb_DigitoVerificaion.Text)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()
        Me.Close()
    End Sub

    Private Function ValidarContratista() As Boolean
        If Tb_Identificacion.Text = "" Then
            MsgBox("Debe digitar la identificación", MsgBoxStyle.Critical, "IDENTIFICACIÓN")
            Me.Tb_Dirrecion.Focus()
            ValidarContratista = False
            Exit Function
        End If

        'If Tb_DigitoVerificaion.Text = "" Then
        '    MsgBox("Debe agregar el digito de verificación", MsgBoxStyle.Critical, "DIGITO VERIFICACIÓN")
        '    Me.Tb_DigitoVerificaion.Focus()
        '    ValidarContratista = False
        '    Exit Function
        'End If

        If Tb_Nombre.Text = "" Then
            MsgBox("Debe digitar el nombre del contratista", MsgBoxStyle.Critical, "NOMBRE")
            Me.Tb_Nombre.Focus()
            ValidarContratista = False
            Exit Function
        End If

        If Tb_Dirrecion.Text = "" Then
            MsgBox("Debe digitar la dirreción", MsgBoxStyle.Critical, "DIRRECION")
            Me.Tb_Dirrecion.Focus()
            ValidarContratista = False
            Exit Function
        End If

        ValidarContratista = True
    End Function

    Public Sub CargarContratista()

        Dim DsOrdenServicio As New DatosClasesBase.Ds_Contratista
        Dim SC_CONTRATISTATableAdapter As New DatosClasesBase.Ds_ContratistaTableAdapters.SC_CONTRATISTATableAdapter
        SC_CONTRATISTATableAdapter.FillByIDContratista(DsOrdenServicio.SC_CONTRATISTA, IdContratista)

        Dim fila As DataRow
        If DsOrdenServicio.SC_CONTRATISTA.Count > 0 Then
            fila = DsOrdenServicio.SC_CONTRATISTA.Rows(0)
            Me.Tb_Identificacion.Text = LTrim(RTrim(fila("Identificación")))
            Me.Tb_Nombre.Text = LTrim(RTrim(fila("Nombre")))
            Me.Tb_Dirrecion.Text = LTrim(RTrim(fila("Dirección")))
            Me.Tb_DigitoVerificaion.Text = LTrim(RTrim(fila("Digito Verificación")))
        End If

    End Sub

    Private Sub Tb_Identificacion_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_Identificacion.LostFocus
        If Editando = False Then
            Tb_Identificacion.Text = Replace(Replace(Tb_Identificacion.Text, ",", ""), ".", "")
            If ExisteContratista(Trim(Me.Tb_Identificacion.Text)) Then
                If MsgBox("Ya existe el contratista con esa identificacion ¿Desea cargar los datos? ", MsgBoxStyle.YesNo, "Contratista") = MsgBoxResult.Yes Then
                    Editando = True
                    CargarContratista()
                Else
                    Tb_Identificacion.Text = ""
                End If
            End If
        End If
    End Sub

    Public Function ExisteContratista(ByVal identificacion As String) As Boolean
        Try
            Dim Cadena_Consulta As String = "select IDCONSTRATISTA from SC_CONTRATISTA where IDENTIFICACION like '%" + identificacion + "%'"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            Dim valor As String = CStr(Consulta.ExecuteScalar)

            If valor = "" Then
                ExisteContratista = False
            Else
                ExisteContratista = True
                IdContratista = valor
            End If

            Consulta.Connection.Close()

        Catch ex As Exception
            ExisteContratista = False
        End Try
    End Function

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub

End Class