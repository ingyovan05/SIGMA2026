Public Class Fr_CategoríaMaterial


    Dim DsArtículo As New DatosArticulos.Ds_Artículos
    Dim VistaTipoUnidad As DataView
    Dim FiltroTipoUnidad As String


    Public Sub Cargar_Tablas()
        Me.MA_TIPOMEDIDATableAdapter1.Fill(DsArtículo.MA_TIPOMEDIDA)
        Me.Cb_TipoMedida.DataSource = DsArtículo.MA_TIPOMEDIDA
        Me.Cb_TipoMedida.DisplayMember = "DESCRIPCIONTIPOMEDIDA"
        Me.Cb_TipoMedida.ValueMember = "CODIGOTIPOMEDIDA"
        Me.Cb_TipoMedida.SelectedIndex = 0

        Me.MA_TIPOUNIDADTableAdapter1.Fill(DsArtículo.MA_TIPOUNIDAD)
        FiltroTipoUnidad = "CODIGOTIPOMEDIDA=" + Me.Cb_TipoMedida.SelectedValue.ToString
        VistaTipoUnidad = New DataView(DsArtículo.MA_TIPOUNIDAD)
        VistaTipoUnidad.RowFilter = FiltroTipoUnidad

        Me.Cb_Unidad.DataSource = VistaTipoUnidad
        Me.Cb_Unidad.DisplayMember = "DESCRIPCION"
        Me.Cb_Unidad.ValueMember = "CODIGOTIPOUNIDAD"
        Me.Cb_Unidad.SelectedIndex = 0

    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
            Me.Tx_NombreCategoría.Text = ""
            Me.Close()
        End If
    End Sub

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If Trim(Me.Tx_NombreCategoría.Text) = "" Then
            MsgBox("Debe digitar el nombre de la categoría", MsgBoxStyle.Critical, "Nombre Categoría")
            Exit Sub
        Else
            'validar que no exista ya la categoría
        End If
        If Trim(Me.Tx_CódigoCategoría.Text) = "" Then
            MsgBox("Debe digitar el código de la categoría (Ejemplo: 01,02,03,04)", MsgBoxStyle.Critical, "Código Categoría")
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub Cb_TipoMedida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_TipoMedida.SelectedIndexChanged
        Try
            FiltroTipoUnidad = "CODIGOTIPOMEDIDA=" + Me.Cb_TipoMedida.SelectedValue.ToString
            VistaTipoUnidad.RowFilter = FiltroTipoUnidad
            Me.Cb_Unidad.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

End Class