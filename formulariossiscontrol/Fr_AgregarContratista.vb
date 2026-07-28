Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_AgregarContratista
    Public Identificacion As String
    Public IdContratista As Integer = -1
    Public Editando As Boolean = False

    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private _guardado As Boolean = False

    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Fila As DataRow

    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property


    Public Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Guardar_Datos() = True Then
            Close()
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        'If ValidarContratista() Then
        '    GuardarContratista()
        'End If
    End Sub

    Private Function Guardar_Datos() As Boolean
        Try
            If ValidarContratista() Then
                GuardarContratista()
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
        Comando.Parameters.AddWithValue("@TELEFONO", UCase(Tb_Telefono.Text))
        Comando.Parameters.AddWithValue("@DIGITOVERIFICACION", Tb_DigitoVerificacion.Text)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        MsgBox("Contratista Guardado", MsgBoxStyle.Information, "Guardado")
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
            MsgBox("Debe digitar la dirección", MsgBoxStyle.Critical, "DIRECCIÓN")
            Me.Tb_Dirrecion.Focus()
            ValidarContratista = False
            Exit Function
        End If

        ValidarContratista = True
    End Function

    Dim dsCargar As DataSet
    Public Sub CargarContratista()

        dsCargar = bddatos.CargarMaestrasSiscontrol(12, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdContratista, 2)

        Fila = dsCargar.Tables(0).Rows(0)
        Me.Tb_Identificacion.Text = LTrim(RTrim(Fila("Identificación")))
        Me.Tb_Nombre.Text = LTrim(RTrim(Fila("Nombre")))
        Me.Tb_Dirrecion.Text = LTrim(RTrim(Fila("Dirección")))
        Me.Tb_DigitoVerificacion.Text = LTrim(RTrim(Fila("Digito Verificación")))
        Me.Tb_Telefono.Text = LTrim(RTrim(Fila("Telefono")))
    End Sub

    Private Sub Tb_Identificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_Identificacion.KeyPress
        Dim Caja As TextBox = sender
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tb_Identificacion_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_Identificacion.LostFocus

            If Editando = False Then
                Tb_Identificacion.Text = Replace(Replace(Tb_Identificacion.Text, ",", ""), ".", "")
                If ExisteContratista(Trim(Me.Tb_Identificacion.Text)) Then
                    If Tb_Identificacion.Text = "" Then
                        Exit Sub
                    Else
                    MsgBox("Ya existe un contratista con esa identificación", MsgBoxStyle.Information, "Contratista")
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

    Private Sub Tb_Telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_Telefono.KeyPress
        Dim Caja As TextBox = sender
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tb_DigitoVerificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_DigitoVerificacion.KeyPress
        Dim Caja As TextBox = sender
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub
End Class