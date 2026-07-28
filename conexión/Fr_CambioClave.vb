Public Class Fr_CambioClave

    Public CambioContaseña As Boolean = False

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If MsgBox("Seguro que desea cambiar la contraseña", MsgBoxStyle.YesNo, "Cambiar Contraseña") = MsgBoxResult.Yes Then
            If Me.Tx_NuevaContraseña.Text <> Me.Tx_RepetirContraseñaNueva.Text Then
                MsgBox("La nueva contraseña no coincide con la verificación.")
                Me.Tx_NuevaContraseña.Text = ""
                Me.Tx_RepetirContraseñaNueva.Text = ""
                Exit Sub
            End If
            If Me.Tx_ContraseñaAnterior.Text = Me.Tx_NuevaContraseña.Text Then
                MsgBox("La nueva contraseña es igual a la anterior")
                Me.Tx_NuevaContraseña.Text = ""
                Me.Tx_RepetirContraseñaNueva.Text = ""
                Exit Sub
            End If

            If Me.Tx_NuevaContraseña.TextLength <> 10 Then
                MsgBox("La nueva contraseña debe tener 10 digitos")
                Me.Tx_NuevaContraseña.Text = ""
                Me.Tx_RepetirContraseñaNueva.Text = ""
                Me.Tx_NuevaContraseña.Focus()
                Exit Sub
            End If

            Dim adapcontraseña As New Ds_UsuarioTableAdapters.USUARIOINGRESOTableAdapter
            If adapcontraseña.VERIFICARCONTRASEÑA(VariablesBase.VariablesBase.IdPersona, _
                                               FuncionesBase.FuncionesBase.Encryptar(Me.Tx_ContraseñaAnterior.Text)) = 0 Then
                MsgBox("La contraseña anterior no es valida")
                Exit Sub
            End If
            adapcontraseña.ACTUALIZARCONTRASEÑA(FuncionesBase.FuncionesBase.Encryptar(Me.Tx_NuevaContraseña.Text), VariablesBase.VariablesBase.IdPersona)
            CambioContaseña = True
            Me.Close()
        End If
    End Sub
End Class