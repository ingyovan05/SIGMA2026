Imports System.Windows.Forms

Public Class Fr_HistorialArchivos

    Dim CarpetaDrive As String = ""
    Property DtArchivos As DataTable
    Dim RutaDescarga As String = ""
    Dim CantidadTotal As Integer = 0
    Dim CantidadDescargados As Integer = 0
    Dim GoogleDrive As New FuncionesGoogle
    Dim DrDescargar() As DataRow

    Public Sub CargarDgv()
        Bt_Cancelar.Enabled = False
        RutaDescarga = "ArchivosPDF"
        DtArchivos.Columns.Add("Descargar")
        'DtArchivos.DefaultView.Sort = "FechaCreacion DESC"
        DtArchivos.DefaultView.Sort = "Nombre ASC"
        Dgv_Archivos.DataSource = DtArchivos

        Lb_ArchivosDescargados.Left = (Lb_ArchivosDescargados.Parent.Width / 2) - (Lb_ArchivosDescargados.Width / 2)
        Lb_ArchivosDescargados.Top = (Lb_ArchivosDescargados.Parent.Height / 2) - (Lb_ArchivosDescargados.Height / 2)
    End Sub

    Private Sub Bt_Todos_Click(sender As Object, e As EventArgs) Handles Bt_Todos.Click
        For i As Integer = 0 To DtArchivos.Rows.Count - 1
            DtArchivos.Rows(i).Item("Descargar") = True
        Next
    End Sub

    Private Sub Bt_Ninguno_Click(sender As Object, e As EventArgs) Handles Bt_Ninguno.Click
        For i As Integer = 0 To DtArchivos.Rows.Count - 1
            DtArchivos.Rows(i).Item("Descargar") = False
        Next
    End Sub

    Private Sub Bt_Descargar_Click(sender As Object, e As EventArgs) Handles Bt_Descargar.Click
        DrDescargar = DtArchivos.Select("Descargar = True")
        Pb_ArchivosDescargados.Minimum = 0
        CantidadTotal = DrDescargar.Length
        Pb_ArchivosDescargados.Maximum = CantidadTotal

        If CantidadTotal = 0 Then
            MsgBox("Debe seleccionar al menos un archivo para descargar.", MsgBoxStyle.Information, "Seleccione un archivo")
            Exit Sub
        End If

        Dgv_Archivos.Enabled = False
        Bt_Ninguno.Enabled = False
        Bt_Todos.Enabled = False
        Bt_Descargar.Enabled = False
        Bt_Cancelar.Enabled = True
        Lb_ArchivosDescargados.Visible = True
        Bgw_ArchivosDescargados.RunWorkerAsync()

    End Sub

    Private Sub Bgw_ArchivosDescargados_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bgw_ArchivosDescargados.DoWork
        DescargarArchivos()
    End Sub

    Private Sub DescargarArchivos()
        Dim Porcentaje As Double = 1
        Dim i As Integer = 0
        While Bgw_ArchivosDescargados.CancellationPending = False
            If i <= DrDescargar.Length - 1 Then
                Dim Nombre As String = DrDescargar(i).Item("Nombre")
                Dim IdArchivo As String = DrDescargar(i).Item("IdArchivo")
                GoogleDrive.DescargarArchivoId(Nombre, IdArchivo, RutaDescarga)
                CantidadDescargados += 1
                i += 1
                Bgw_ArchivosDescargados.ReportProgress(Porcentaje)
            End If
            If CantidadDescargados = CantidadTotal Then
                Exit While
            End If
        End While
    End Sub

    Private Sub Bgw_ArchivosDescargados_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Bgw_ArchivosDescargados.ProgressChanged
        Lb_ArchivosDescargados.Visible = True
        Pb_ArchivosDescargados.Value += e.ProgressPercentage
        Pb_ArchivosDescargados.Refresh()
        Lb_ArchivosDescargados.Left = (Lb_ArchivosDescargados.Parent.Width / 2) - (Lb_ArchivosDescargados.Width / 2)
        Lb_ArchivosDescargados.Top = (Lb_ArchivosDescargados.Parent.Height / 2) - (Lb_ArchivosDescargados.Height / 2)
        Lb_ArchivosDescargados.Text = "Archivos descargados: " + CantidadDescargados.ToString + " de " + CantidadTotal.ToString
        Lb_ArchivosDescargados.Refresh()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If MsgBox("¿Esta seguro de que desea cancelar el proceso de descarga?", MsgBoxStyle.YesNo, "Cancelar Descarga") = MsgBoxResult.Yes Then
            Bgw_ArchivosDescargados.CancelAsync()
        End If
    End Sub

    Private Sub Bgw_ArchivosDescargados_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bgw_ArchivosDescargados.RunWorkerCompleted
        Dim appPath As String = Application.StartupPath + "\" + RutaDescarga
        MsgBox("Se han descargado los archivos en la carpeta." & vbNewLine & appPath, MsgBoxStyle.Information, "Descarga finalizada")
        Me.Close()
    End Sub

End Class
