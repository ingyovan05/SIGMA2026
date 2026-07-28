Public Class Cu_CentroCosto

  Public IdCentroCosto As Integer
  Public Editando As Integer

  Private Sub LinkLabel1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_CentroCostos.LinkClicked
    Dim FrBuscarCentroCosto As New Fr_BuscarCentroCosto
    FrBuscarCentroCosto.CargarListaCentroCostos(Editando, IdCentroCosto, VariablesBase.VariablesBase.IdBodegaActual)
    FrBuscarCentroCosto.ShowDialog()

    If FrBuscarCentroCosto.DialogResult = Windows.Forms.DialogResult.OK Then
      Me.Ll_CentroCostos.Text = FrBuscarCentroCosto.NombreCentroCosto
      Me.IdCentroCosto = FrBuscarCentroCosto.IdCentroCosto
    End If

  End Sub


  Public Sub CargarCentro()
    Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
    sqlconeccion.Open()
    Dim cmd As New SqlClient.SqlCommand(
        "select LTRIM(RTRIM(CODIGOCENTROCOSTOSSOLIN))+' - '+LTRIM(RTRIM(SUBCENTROCOSTOSSOLIN))+' - '+LTRIM(RTRIM(SISTEMA))from  MA_CENTROCOSTOSSOLIN where IDCENTROCOSTO=" + IdCentroCosto.ToString, sqlconeccion)
    Me.Ll_CentroCostos.Text = Trim(cmd.ExecuteScalar())
    sqlconeccion.Close()
  End Sub

  Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
    sqlconeccion.Open()
    Dim cmd As New SqlClient.SqlCommand(
        "select  dbo.nombrecompletosubcentro (" + IdCentroCosto.ToString + ")", sqlconeccion)
    MsgBox(Trim(cmd.ExecuteScalar()), MsgBoxStyle.Information, "DETALLE CENTRO DE COSTOS")
    sqlconeccion.Close()

  End Sub

End Class
