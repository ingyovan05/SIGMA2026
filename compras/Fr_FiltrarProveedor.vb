Public Class Fr_FiltrarProveedor
    Dim DsSuministros As New DatosProveedores.Ds_Proveedor
    Dim SuministrosTableadapter As New DatosProveedores.Ds_ProveedorTableAdapters.MA_GRUPOSUMINISTROMATERIALTableAdapter

    Public IDSUMINISTRO As Integer
    Public SUMINISTRO As String
    Public Sub CargarSuministros()
        Me.SuministrosTableadapter.Fill(DsSuministros.MA_GRUPOSUMINISTROMATERIAL)
        Me.Cb_Suministro.DataSource = Me.DsSuministros.MA_GRUPOSUMINISTROMATERIAL
        Me.Cb_Suministro.DisplayMember = "NOMBREGRUPOSUMINISTROMATERIAL"
        Me.Cb_Suministro.ValueMember = "CODIGOGRUPOSUMINISTROMATERIAL"
    End Sub

    Private Sub Cb_Suministro_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Suministro.SelectionChangeCommitted
        If Cb_Suministro.SelectedValue = "33" Then
            Tb_Cual.Enabled = True
        Else
            Tb_Cual.Enabled = False
            Tb_Cual.Text = ""
        End If

    End Sub
    Private Function Validar() As Boolean
        If Cb_Suministro.SelectedValue = "33" And Trim(Tb_Cual.Text) = "" Then
            MsgBox("Digite el suministro ", MsgBoxStyle.Critical, "SUMINISTRO")
            Validar = False
            Tb_Cual.Focus()
            Exit Function
        End If
        Validar = True
    End Function


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        If Validar() Then
            IDSUMINISTRO = Cb_Suministro.SelectedValue
            SUMINISTRO = UCase(Tb_Cual.Text)
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        IDSUMINISTRO = 0
        Me.Close()
    End Sub
End Class