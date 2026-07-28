Public Class Fr_BusquedaSisControl

    Public Columna As String
    Public Valor As String

    Public dt_opcionesfiltro As New DataTable("OPCIONES")

    Public Sub CargarCombo()
        ' Me.dt_opcionesfiltro.Rows.Clear()
        Me.Cb_Campo.DataSource = Me.dt_opcionesfiltro
        Me.Cb_Campo.DisplayMember = "OPCIONES"
        Me.Cb_Campo.ValueMember = "OPCIONES"
    End Sub


    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Columna = Cb_Campo.SelectedValue
        Valor = Tx_Valor.Text
        Me.Close()
    End Sub


    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
End Class