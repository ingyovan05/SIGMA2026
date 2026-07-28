Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_GenerarStickers
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dtNumeroSticker As DataTable

    Private Sub Fr_GenerarStickers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Nud_CantidadHojas_ValueChanged(sender As Object, e As EventArgs) Handles Nud_CantidadHojas.ValueChanged
        Lb_CantidadStickers.Text = Nud_CantidadHojas.Value * 30
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        comando = New SqlCommand("GenerarSC_StickersRecepcion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Cantidadpaginas", Nud_CantidadHojas.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim paramMsj As New SqlParameter("@Mensaje", SqlDbType.Int)
        paramMsj.Direction = ParameterDirection.Output
        comando.Parameters.Add(paramMsj)
        adaptador = New SqlDataAdapter(comando)
        dtNumeroSticker = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtNumeroSticker)
            conexion.Close()
            If Not IsDBNull(paramMsj.Value) OrElse paramMsj.Value = 0 Then
                If dtNumeroSticker.Rows.Count > 0 Then
                    Dim clImpresion As New ImpresiónSisControl.Cl_Impresión
                    clImpresion.dtNumeroSticker = dtNumeroSticker
                    Dim formatos As New ArrayList
                    formatos.Add(77)
                    clImpresion.FormatoImprimirSisControl(formatos, True, False)
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    Throw New Exception("No se guardaron los cambios.")
                End If
            Else
                Throw New Exception("La consulta no devolvió ninguna fila.")
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al ejecutar la operación.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class