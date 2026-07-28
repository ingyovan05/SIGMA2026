Imports System.Text.RegularExpressions

Public Class Cu_Contacto

    Public IDPERSONA As Integer
    Private DsUsuario As New DatosClasesBase.Ds_Usuario

    Public Sub CargarTabla()
        Dim adap As New DatosClasesBase.Ds_UsuarioTableAdapters.CONTACTOPERSONATableAdapter
        adap.Fill(DsUsuario.CONTACTOPERSONA, IDPERSONA)
        If DsUsuario.CONTACTOPERSONA.Rows.Count > 0 Then
            Dim fila As DataRow
            fila = DsUsuario.CONTACTOPERSONA.Rows(0)
            Me.Tx_TeléfonoMóvilCorporativo.Text = Trim(fila("TELEFONOMOVILCORPORATIVO"))
            Me.Tx_EmailCorporativo.Text = Trim(fila("CORREOELECTRONICOCORPORTATIVO"))
            Me.Tx_TeléfonoMóvilPersonal.Text = Trim(fila("TELEFONOMOVIL"))
            Me.Tx_EmailPersonal.Text = Trim(fila("CORREOELECTRONICO"))
        End If
    End Sub

    Public Sub Actualizar()
        If Validar() = True Then
            Dim Comando As New SqlClient.SqlCommand("dbo.ActualizarContacto")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@IDPERSONA", IDPERSONA)
            Comando.Parameters.AddWithValue("@CORREOELECTRONICO", Trim(Me.Tx_EmailPersonal.Text))
            Comando.Parameters.AddWithValue("@TELEFONOMOVIL", Trim(Me.Tx_TeléfonoMóvilPersonal.Text))
            Comando.Parameters.AddWithValue("@CORREOELECTRONICOCORPORTATIVO", Trim(Me.Tx_EmailCorporativo.Text))
            Comando.Parameters.AddWithValue("@TELEFONOMOVILCORPORATIVO", Trim(Me.Tx_TeléfonoMóvilCorporativo.Text))
            Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se pudo actualizar el contacto " + Me.Gb_Contacto.Text)
            End Try
            conn.Close()
        End If

    End Sub

    Private Function Validar() As Boolean
        If Me.Tx_EmailCorporativo.Text <> "" Then
            If Not FuncionesBase.FuncionesBase.validarCorreoCorporativo(Tx_EmailCorporativo.Text) Then
                MsgBox("El correo electrónico corporativo de " + Trim(Gb_Contacto.Text) + " no cumple con el formato (ejemplo@ismocol.com).", MsgBoxStyle.Critical, "Correo Electrónico corporativo")
                Validar = False
                Exit Function
            End If
        End If
        If Me.Tx_EmailPersonal.Text <> "" Then
            If Not FuncionesBase.FuncionesBase.validarDireccionCorreo(Tx_EmailPersonal.Text) Then
                MsgBox("El correo electrónico personal de " + Trim(Gb_Contacto.Text) + " no cumple con el formato.", MsgBoxStyle.Critical, "Correo Electrónico Personal")
                Validar = False
                Exit Function
            End If
        End If
        Validar = True
    End Function

End Class
