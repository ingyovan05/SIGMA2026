Imports System.Data.SqlClient

Public Class Fr_CambiarBodega
    Public Idbodegaseleccionada As Integer = -1
    Public Tipo As String = ""
    Private dt_Bodega As DataTable

    Private Sub Fr_CambiarBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaBodegasPorUsuario(@IDPERSONA) ORDER BY [COMBOBODEGA]", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        dt_Bodega = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dt_Bodega)
            conexion.Close()
            Cb_NombreBodega.DataSource = dt_Bodega
            Cb_NombreBodega.DisplayMember = "COMBOBODEGA"
            Cb_NombreBodega.ValueMember = "IDBODEGA"
        Catch ex As Exception

        Finally
            conexion.Close()
        End Try

        Lb_BodegaActual.Text = VariablesBase.VariablesBase.NombreBodegaActual
    End Sub

    Private Sub Btn_AceptarCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AceptarCambio.Click
        If Me.Cb_NombreBodega.SelectedIndex = -1 Then
            Exit Sub
        End If
        Select Case Tipo
            Case "" 'se está haciendo cambio de bodega
                VariablesBase.VariablesBase.IdBodegaActual = Cb_NombreBodega.SelectedValue
                Dim filas As DataRow()
                filas = dt_Bodega.Select("IDBODEGA=" + Cb_NombreBodega.SelectedValue.ToString)
                Dim filabodega As DataRow
                filabodega = filas(0)
                VariablesBase.VariablesBase.AbreviaturaBodegaActual = Trim(filabodega("ABREVIATURA"))
                VariablesBase.VariablesBase.NombreBodegaActual = Trim(filabodega("NOMBRE"))
                VariablesBase.VariablesBase.DireccionBodegaActual = Trim(filabodega("DIRECCION"))
                VariablesBase.VariablesBase.IdCentroCostoBodegaActual = Trim(filabodega("IDCENTROCOSTO"))
                VariablesBase.VariablesBase.TipoBodegaActual = Trim(filabodega("TIPOBODEGA"))
                VariablesBase.VariablesBase.EmpresaBodegaActual = Trim(filabodega("IDEMPRESA"))

                Dim Objeto As Object
                Objeto = MdiParent
  
            Case "S" 'Solo se está seleccionando una bodega
                Idbodegaseleccionada = Cb_NombreBodega.SelectedValue
        End Select
        Me.Close()
    End Sub

    Private Sub Btn_CancelarCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CancelarCambio.Click
        Me.Close()
    End Sub

End Class