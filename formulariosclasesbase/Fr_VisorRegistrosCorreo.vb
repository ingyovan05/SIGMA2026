Public Class Fr_VisorRegistrosCorreo

    Public _nombreArchivo As String = ""
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim CantidadCorreos As Integer
        Try
            Dim data As New DataTable
            data.Columns.Add("CorreoDestino")
            data.Columns.Add("Enviado")
            data.Columns.Add("Fecha")
            data.Columns.Add("CorreoOrigen")

            For Each line As String In System.IO.File.ReadAllLines(VariablesBase.VariablesBase._path + _nombreArchivo)
                data.Rows.Add(line.Split(">"))
                CantidadCorreos = line.Count
            Next

            Dim dataCorreosNo As DataTable
            dataCorreosNo = data.Copy
            Dgv_CorreosSinEnviar.DataSource = dataCorreosNo
            Dgv_CorreosEnviados.DataSource = data
            data.DefaultView.RowFilter = "Enviado = 'SI'"
            dataCorreosNo.DefaultView.RowFilter = "Enviado = 'NO'"

            Lb_ConteoRegistros.Text = "Cantidad de Registros: " + Str(Dgv_CorreosEnviados.RowCount + Dgv_CorreosSinEnviar.RowCount)

        Catch ex As Exception

        End Try

       

    End Sub

End Class