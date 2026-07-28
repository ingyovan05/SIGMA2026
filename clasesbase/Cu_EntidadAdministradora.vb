Public Class Cu_EntidadAdministradora

    Private TipoEntidadAdministradora As String

    Public Property _TipoEntidadAdministradora() As String
        Get
            Return CType(TipoEntidadAdministradora, String)
        End Get
        Set(value As String)
            TipoEntidadAdministradora = value
        End Set
    End Property


    Public Sub CargarDatos()
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cb_NombreAdministradora.GotFocus, Tx_Codigo.GotFocus, Tx_Codigo.GotFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.MintCream
    End Sub

    Private Sub Caja_Texto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cb_NombreAdministradora.LostFocus, Tx_Codigo.LostFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.White
    End Sub


    Private Sub Cb_NombreAdministradora_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_NombreAdministradora.SelectedIndexChanged
        Try
            Me.Tx_Codigo.Text = Me.Cb_NombreAdministradora.SelectedValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bt_Buscar_Click(sender As Object, e As EventArgs) Handles Bt_Buscar.Click

    End Sub

    Private Sub Tx_Codigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_Codigo.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                'Buscar la entidad por código

                Dim Padre As New Object
                Padre = Me.ParentForm
                Padre.EventoEnterEntidadAdmin(Me.Name)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class