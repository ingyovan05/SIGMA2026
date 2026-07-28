Public Class Fr_TiposArticulos

    'declaro un string para mensajes de error, un dataset y la clase para los llamados a procedimientos
    Dim strMensaje As String
    Dim dsTipo As New DataSet
    Dim dsSubTipo As New DataSet
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
    Dim borrarconfirmacion As VariantType
    Private dtTipo As New DataTable
    Private dtSubTipo As New DataTable
    Private dvTipo As DataView
    Private dvSubTipo As DataView

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btn_AgregarCaracteristica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AgregarCaracteristica.Click
        If Cb_Subtipo.SelectedValue = 0 Then
            MsgBox("Seleccione un tipo y un subtipo primero", MsgBoxStyle.Exclamation, "no hay Subtipo Seleccionado")
            Exit Sub

        End If
        Dim formcaracteristicas As New Fr_EditarCaracteristica
        formcaracteristicas.nombretipo = Cb_Tipo.Text
        formcaracteristicas.nombresubtipo = Cb_Subtipo.Text
        formcaracteristicas.idsubtipo = Cb_Subtipo.SelectedValue
        formcaracteristicas.ShowDialog()
        If formcaracteristicas.actualizado = True Then
            CargarTablaCaracteristicas()
        End If

    End Sub

    Private Sub Btn_EditarCaracteristica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formcaracteristicas = New Fr_EditarCaracteristica
        formcaracteristicas.ShowDialog()
    End Sub

    Private Sub Btn_Agregartipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregartipo.Click
        'establezco la accion 3 crear tipo, agregar tipo es la opcion por defecto
        Dim formtipos = New Fr_EditarTipoSubtipo
        formtipos.accion = 3
        formtipos.ShowDialog()
        If formtipos.actualizartipo = True Then
            CargarTipos()
        End If
    End Sub

    Private Sub Btn_AgregarSubtipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AgregarSubtipo.Click
        'estrablezco el parametro 4 de agregar subtipo y envio el nombre y el id del tipo padre del subtipo 
        Dim formtipos = New Fr_EditarTipoSubtipo
        formtipos.accion = 4
        formtipos.tipo = Cb_Tipo.Text
        formtipos.idtipo = Cb_Tipo.SelectedValue
        formtipos.nomtipo = Tb_NomTipo.Text
        formtipos.ShowDialog()
        If formtipos.actualizartipo = True Then
            CargarTipos()
            Cb_Tipo.SelectedValue = formtipos.idtipo
        End If
    End Sub

    Private Sub Btn_Editartipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editartipo.Click
        If Cb_Tipo.SelectedValue = Nothing Or Cb_Tipo.SelectedValue = 0 Then
            MsgBox("No hay ningun tipo seleccionado", MsgBoxStyle.Exclamation, "error")
            Return
        End If

        'accion 5 editar tipo. envio el nombre del tipo y el valor para editarlo
        Dim formtipos = New Fr_EditarTipoSubtipo
        formtipos.accion = 5
        formtipos.tipo = Cb_Tipo.Text.Split(")"c)(1).Trim
        formtipos.idtipo = Cb_Tipo.SelectedValue
        formtipos.nomtipo = Tb_NomTipo.Text
        formtipos.ShowDialog()

        If formtipos.actualizartipo = True Then
            CargarTipos()
            Cb_Tipo.SelectedValue = formtipos.idtipo
        End If

    End Sub

    Private Sub Btn_EditarSubtipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EditarSubtipo.Click
        If Cb_Subtipo.SelectedValue = Nothing Or Cb_Subtipo.SelectedValue = 0 Then
            MsgBox("No hay ningun subtipo seleccionado", MsgBoxStyle.Exclamation, "error")
            Exit Sub
        End If

        'accion 6 editar subtipo, envio el nombre del tipo para moestrarlo, el id del subtipo para el registro y el nombre del subtipo para editarlo
        Dim formtipos = New Fr_EditarTipoSubtipo
        formtipos.accion = 6
        formtipos.tipo = Cb_Tipo.Text.Split(")"c)(1).Trim
        formtipos.subtipo = Cb_Subtipo.Text.Split(")"c)(1).Trim
        formtipos.idsubtipo = Cb_Subtipo.SelectedValue
        formtipos.idtipo = Cb_Tipo.SelectedValue
        formtipos.nomtipo = Tb_NomTipo.Text
        formtipos.nomsubtipo = Tb_NomSubtipo.Text
        formtipos.ShowDialog()

        If formtipos.actualizartipo = True Then
            CargarTipos()
            Cb_Tipo.SelectedValue = formtipos.idtipo
            Cb_Subtipo.SelectedValue = formtipos.idsubtipo
        End If
    End Sub

    Private Sub Fr_TiposArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cb_Tipo.DataSource = Nothing
        Dgv_Caracteristicas.AutoGenerateColumns = False
        CargarTipos()
    End Sub

    Private Sub Cb_Tipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Tipo.SelectedValueChanged
        Tb_NomTipo.Text = dsTipo.Tables(0).Rows(Cb_Tipo.SelectedIndex)("NOMENCLATURA")
        CargarSubtipo()
    End Sub

    Public Sub CargarTipos()
        Try
            'llenar la listas de tipos de articulos
            dsTipo = bddatos.ModificarTipos(1, 0, 0, "", "", "")

            dtTipo = dsTipo.Tables(0)
            dvTipo = New DataView(dtTipo)
            'Cb_Tipo.DataSource = dsTipo.Tables(0).DefaultView
            Cb_Tipo.DataSource = dvTipo
            Cb_Tipo.ValueMember = "IDTIPO"
            Cb_Tipo.DisplayMember = "DESCRIPCION"

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub CargarSubtipo()
        Dim valor As Object = Cb_Tipo.SelectedValue
        Dim a As Boolean = IsNumeric(valor)
        If a = True Then
            'si el valor seleccionado de tipo es numerico llenar la lista de subtipos de articulos
            Try
                dsSubTipo = bddatos.ModificarTipos(2, Cb_Tipo.SelectedValue, 0, "", "", "")

                dtSubTipo = dsSubTipo.Tables(0)
                dvSubTipo = New DataView(dtSubTipo)
                'Cb_Subtipo.DataSource = dsSubTipo.Tables(0).DefaultView
                Cb_Subtipo.DataSource = dvSubTipo
                Cb_Subtipo.ValueMember = "IDSUBTIPO"
                Cb_Subtipo.DisplayMember = "DESCRIPCION"
                If dsSubTipo.Tables(0).Rows.Count = 0 Then
                    Tb_NomSubtipo.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub Btn_EliminarTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarTipo.Click
        If Cb_Tipo.SelectedValue = 0 Then
            MsgBox("Seleccione un Tipo Primero", MsgBoxStyle.Exclamation, "No hay tipo seleccionado")
            Exit Sub
        End If

        borrarconfirmacion = MsgBox("ATENCIÓN, si elimina este tipo de articulo TODOS SUS SUBTIPOS TAMBIEN SERÁN ELIMINADOS. Está seguro que desea continuar?", MsgBoxStyle.YesNo, "ADVERTENCIA")
        If borrarconfirmacion = vbYes Then
            Dim ds As New DataSet
            ds = bddatos.ModificarTipos(7, Cb_Tipo.SelectedValue, 0, "", "", "")
            MsgBox("TIPO ELIMINADO", MsgBoxStyle.OkOnly, "TIPO ELIMINADO")
            CargarTipos()
        End If

    End Sub

    Private Sub Btn_EliminarSubtipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarSubtipo.Click
        If Cb_Subtipo.SelectedValue = 0 Then
            MsgBox("Seleccione un Subtipo Primero", MsgBoxStyle.Exclamation, "No hay subtipo seleccionado")
            Exit Sub
        End If
        borrarconfirmacion = MsgBox("ATENCIÓN, va a eliminar el subtipo de articulo: " + Cb_Subtipo.Text + ". Está seguro que desea continuar?", MsgBoxStyle.YesNo, "ADVERTENCIA")
        If borrarconfirmacion = vbYes Then
            Dim ds As New DataSet
            ds = bddatos.ModificarTipos(8, Cb_Tipo.SelectedValue, Cb_Subtipo.SelectedValue, "", "", "")
            MsgBox("SUBTIPO ELIMINADO", MsgBoxStyle.OkOnly, "SUBTIPO ELIMINADO")
            CargarSubtipo()
        End If
    End Sub

    Private Sub Cb_Subtipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Subtipo.SelectedValueChanged
        'llenar la tabla de caracteristicas del subtipo
        Dim valor As Object = Cb_Subtipo.SelectedValue()
        Dim a As Boolean = IsNumeric(valor)
        If a = True Then
            'si hay un valor seleccionado en el combobox subtipo llenar la tabla.
            Try
                Tb_NomSubtipo.Text = dsSubTipo.Tables(0).Rows(Cb_Subtipo.SelectedIndex)("NOMENCLATURA")
                CargarTablaCaracteristicas()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub CargarTablaCaracteristicas()
        Dim dscaracteristicas As New DataSet
        dscaracteristicas = bddatos.ModificarCaracteristicas(2, 0, Cb_Subtipo.SelectedValue, 0, 0, "", "", 0, 0, False, "", 0, Date.Now, "")
        Dgv_Caracteristicas.DataSource = dscaracteristicas.Tables(0)
    End Sub

    Private Sub Dgv_Caracteristicas_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Caracteristicas.CellDoubleClick
        If Dgv_Caracteristicas.Rows.Count > 0 Then
            Dim formcaracteristicas As New Fr_EditarCaracteristica
            formcaracteristicas.idcaracteristica = Me.Dgv_Caracteristicas.Rows(Dgv_Caracteristicas.CurrentRow.Index).Cells("ID").Value
            formcaracteristicas.edicion = True
            formcaracteristicas.ShowDialog()
            If formcaracteristicas.actualizado = True Then
                CargarTablaCaracteristicas()
            End If
        Else
            MsgBox("No hay ninguna fila seleccionada", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Bt_OrdenarTipo_Click(sender As Object, e As EventArgs) Handles Bt_OrdenarTipo.Click
        dvTipo.Sort = "NOMENCLATURA ASC"
    End Sub

    Private Sub Bt_OrdenarSubTipos_Click(sender As Object, e As EventArgs) Handles Bt_OrdenarSubTipos.Click
        dvSubTipo.Sort = "NOMENCLATURA ASC"
    End Sub
End Class