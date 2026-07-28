Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Dg_CambiarConseRequisicion

    Public IDREQUISICION As Int64 = -1
    Public REQUISICION As String
    Dim CONSECUTIVO As String


    Public Sub GuardarConsecutivo()
        If Tx_Consecutivo.Text.Length = 5 Then
            CONSECUTIVO = Tx_Consecutivo.Text
        Else
            MsgBox("El consecutivo debe tener 5 digitos")
            Exit Sub
        End If

        Dim Comando As New SqlClient.SqlCommand("CambiarConsecutivoRequisicion")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TIPO", 0)
        Comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICION)
        Comando.Parameters.AddWithValue("@NUEVOCONSECUTIVO", CONSECUTIVO)
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.NChar, 100)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
            conn.Close()
            MsgBox(msgParam.Value.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        GuardarConsecutivo()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dg_CambiarConseRequisicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lb_Consecutivo.Text = "Requisicion: " + REQUISICION
        Dim longitud As Integer
        longitud = REQUISICION.Length - 4
        Tx_Consecutivo.Text = Mid(REQUISICION, longitud, 5)
    End Sub

End Class
