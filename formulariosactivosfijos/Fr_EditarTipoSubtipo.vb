Public Class Fr_EditarTipoSubtipo
    'variables para usar
    Public accion As Integer = 0
    Public tipo As String = Nothing
    Public subtipo As String = Nothing
    Public nomtipo As String = Nothing
    Public nomsubtipo As String = Nothing
    Public idtipo As Integer
    Public idsubtipo As Integer


    Public actualizartipo As Boolean = False


    'declaro un dataset y la clase para los llamados a procedimientos
    Dim ds As New DataSet
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub



    Private Sub Fr_EditarTipoSubtipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If accion = 3 Then
            'crear tipo
            Tb_Tipo.Enabled = True
            Tb_NomTipo.Enabled = True
        ElseIf accion = 4 Then
            'crear subtipo
            Tb_Subtipo.Enabled = True
            Tb_Tipo.Text = tipo
            Tb_Nomsubtipo.Enabled = True
            Tb_NomTipo.Text = nomtipo
        ElseIf accion = 5 Then
            'editar tipo 
            Tb_Tipo.Enabled = True
            Tb_Tipo.Text = tipo
            Tb_NomTipo.Enabled = True
            Tb_NomTipo.Text = nomtipo
        ElseIf accion = 6 Then
            'editar subtipo
            Tb_Subtipo.Enabled = True
            Tb_Subtipo.Text = subtipo
            Tb_Tipo.Text = tipo
            Tb_Nomsubtipo.Enabled = True
            Tb_Nomsubtipo.Text = nomsubtipo
            Tb_NomTipo.Text = nomtipo
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim resultado As VariantType

        If accion = 3 Then
            'crear tipo
            If Tb_Tipo.Text = "" Or Tb_NomTipo.Text = "" Then
                MsgBox("El campo tipo ni la nomenclatura de tipo pueden estar vacios", MsgBoxStyle.OkOnly, "Faltan campos")
                Exit Sub
            End If
            ds = bddatos.ModificarTipos(3, 0, 0, UCase(Tb_Tipo.Text), UCase(Tb_NomTipo.Text), "")
            If ds.Tables(0).Rows(0)(0) = 0 Then
                resultado = MsgBox("tipo de articulo: " + UCase(Tb_Tipo.Text) + " (" + UCase(Tb_NomTipo.Text) + ") creado correctamente. Desea agregar mas Tipos de articulo?", MsgBoxStyle.YesNo, "Exito")
                Tb_Tipo.Text = ""
                Tb_NomTipo.Text = ""
                Tb_Tipo.Focus()
            Else
                MsgBox("La nomenclatura introducida ya existe para otro tipo de articulo", MsgBoxStyle.OkOnly, "Error")
            End If
        ElseIf accion = 4 Then
            If Tb_Subtipo.Text = "" Or Tb_Nomsubtipo.Text = "" Then
                MsgBox("El campo subtipo ni u nomenclatura pueden estar vacios", MsgBoxStyle.OkOnly, "Faltan campos")
                Exit Sub
            End If

            'crear subtipo
            ds = bddatos.ModificarTipos(4, idtipo, 0, UCase(Tb_Subtipo.Text), "", UCase(Tb_Nomsubtipo.Text))
            If ds.Tables(0).Rows(0)(0) = 0 Then
                resultado = MsgBox("subtipo de articulo: " + UCase(Tb_Subtipo.Text) + " (" + UCase(Tb_Nomsubtipo.Text) + ") creado correctamente. quiere agregar mas subtipos para el tipo de articulo" + Tb_Tipo.Text + "?", MsgBoxStyle.YesNo, "Exito")
                Tb_Subtipo.Text = ""
                Tb_Nomsubtipo.Text = ""
                Tb_Subtipo.Focus()
            Else
                MsgBox("La nomenclatura introducida ya existe para otro subtipo de articulo", MsgBoxStyle.OkOnly, "Error")
            End If

        ElseIf accion = 5 Then
            If Tb_Tipo.Text = "" Or Tb_NomTipo.Text = "" Then
                MsgBox("El campo tipo ni la nomenclatura de tipo pueden estar vacios", MsgBoxStyle.OkOnly, "Faltan campos")
                Exit Sub
            End If

            'editar tipo 
            ds = bddatos.ModificarTipos(5, idtipo, 0, UCase(Tb_Tipo.Text), UCase(Tb_NomTipo.Text), "")
            If ds.Tables(0).Rows(0)(0) = 0 Then
                resultado = vbNo
                MsgBox("tipo Modificado correctamente", MsgBoxStyle.OkOnly, "Tipo modificado")
            Else
                MsgBox("La nomenclatura introducida ya existe para otro tipo de articulo", MsgBoxStyle.OkOnly, "Error")
            End If


        ElseIf accion = 6 Then
            If Tb_Subtipo.Text = "" Or Tb_Nomsubtipo.Text = "" Then
                MsgBox("El campo subtipo ni u nomenclatura pueden estar vacios", MsgBoxStyle.OkOnly, "Faltan campos")
                Exit Sub
            End If

            'editar subtipo
            ds = bddatos.ModificarTipos(6, idtipo, idsubtipo, UCase(Tb_Subtipo.Text), "", UCase(Tb_Nomsubtipo.Text))
            If ds.Tables(0).Rows(0)(0) = 0 Then
                MsgBox("Subtipo Modificado correctamente", MsgBoxStyle.OkOnly, "Subtipo modificado")
                resultado = vbNo
            Else
                MsgBox("La nomenclatura introducida ya existe para otro tipo de articulo", MsgBoxStyle.OkOnly, "Error")
            End If

        Else
            Me.Close()
        End If
        actualizartipo = True
        'si no quiere agregar mas campos me salgo
        If resultado = vbNo Then
            Me.Close()
        End If
    End Sub

End Class