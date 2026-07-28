Imports System.Data.SqlClient

Public Class Fr_BuscarEmpTrasmporte

    Public IdTrasportadora As Integer
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        If ValidarTrasportador() = True Then
            GuardarTrasportador()
        End If
    End Sub

    Private Sub GuardarTrasportador()

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarTrasportador")
        Comando.CommandType = CommandType.StoredProcedure

        Comando.Parameters.AddWithValue("@TIPO", 1)
        Comando.Parameters.AddWithValue("@IDTRASPORTADORA", IdTrasportadora)
        Comando.Parameters.AddWithValue("@IDENTIFICACION", UCase(Tb_Identificacion.Text))
        Comando.Parameters.AddWithValue("@NOMBRE", UCase(Tx_Nombre.Text))
        Comando.Parameters.AddWithValue("@TELEFONO", UCase(Tx_Telefono.Text))
        Comando.Parameters.AddWithValue("@DIRRECION", UCase(Tx_Dirrecion.Text))
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
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

    Private Function ValidarTrasportador()
        If Trim(Tx_Nombre.Text) = "" Then
            MsgBox("Debe Agregar el nombre del trasportadora", MsgBoxStyle.Critical, "NOMBRE")
            Me.Tx_Nombre.Focus()
            ValidarTrasportador = False
            Exit Function
        End If
        ValidarTrasportador = True
    End Function

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class