Public Class Fr_DatosUsuarioBD
    Property Usuario As String
        Get
            Return Tx_Usuario.Text
        End Get
        Set(value As String)
            Tx_Usuario.Text = value
        End Set
    End Property
    Property Contrasenna As String
        Get
            Return Tx_Contrasenna.Text
        End Get
        Set(value As String)
            Tx_Contrasenna.Text = value
        End Set
    End Property

    Private Sub Fr_DatosUsuarioBD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub
End Class