Public Class Fr_ActualizarContacto


    Public Sub CargarDatos()
        If Me.Cu_Contacto1.IDPERSONA <> -1 Then
            Me.Cu_Contacto1.CargarTabla()
        Else
            Me.Cu_Contacto1.Visible = False
        End If
        If Me.Cu_Contacto2.IDPERSONA <> -1 Then
            Me.Cu_Contacto2.CargarTabla()
        Else
            Me.Cu_Contacto2.Visible = False
        End If
        If Me.Cu_Contacto3.IDPERSONA <> -1 Then
            Me.Cu_Contacto3.CargarTabla()
        Else
            Me.Cu_Contacto3.Visible = False
        End If
        If Me.Cu_Contacto4.IDPERSONA <> -1 Then
            Me.Cu_Contacto4.CargarTabla()
        Else
            Me.Cu_Contacto4.Visible = False
        End If
    End Sub

    Private Sub Bt_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Aceptar.Click
        If MsgBox("¿Desea actualizar los datos del personal asociado al documento", MsgBoxStyle.Question + MsgBoxStyle.YesNo + vbDefaultButton1, "Actualizar") = MsgBoxResult.Yes Then
            Try
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
                Me.Cu_Contacto1.Actualizar()
                Me.Cu_Contacto2.Actualizar()
                Me.Cu_Contacto3.Actualizar()
                Me.Cu_Contacto4.Actualizar()
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
                Me.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub
End Class