Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_ImprimirPazYSalvos

    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Estilo_Celda As New DataGridViewCellStyle
    Private MensajeError As String


    Private Sub Bt_AgregarCedulaPortapapeles_Click(sender As Object, e As EventArgs) Handles Bt_AgregarCedulaPortapapeles.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
            Dim words() As String = Clipboard.GetText().Split(delimiterChars)
            For i = 0 To words.Length - 1
                Dim line As String
                line = Replace(LTrim(RTrim(words(i))), vbLf, "")
                If IsNothing(line) = False Then
                    If line.Length > 0 Then
                        Try
                            Dim nombre As String = ConsultarNombrePersona(line)
                            If nombre <> "" Then
                                Dgv_Cedula.Rows.Add(line, nombre)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Dim dtIdentificacion As New DataTable
    Private Sub Dgv_Cedula_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Cedula.CellEndEdit
        If IsDBNull(Me.Dgv_Cedula.Item(e.ColumnIndex, e.RowIndex).Value) Then
            Me.Dgv_Cedula.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If
        If Trim(Me.Dgv_Cedula.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
            If e.RowIndex > 0 Then
                Me.Dgv_Cedula.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_Cedula.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Me.Dgv_Cedula.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
            End If
            Exit Sub
        End If
        Dim IDENTIFICACION As Integer = -1
        If Not IsDBNull(Me.Dgv_Cedula.Item(DGVTBC_IDENTIFICACION.Name, e.RowIndex).Value) Then
            IDENTIFICACION = Me.Dgv_Cedula.Item(DGVTBC_IDENTIFICACION.Name, e.RowIndex).Value
        End If
        Dim nombre As String = ConsultarNombrePersona(IDENTIFICACION)
        If nombre = "" Then
            Me.Dgv_Cedula.Rows.Remove(Me.Dgv_Cedula.Rows(e.RowIndex))
            Me.Dgv_Cedula.CurrentCell = Me.Dgv_Cedula(0, e.RowIndex)
        Else
            Dgv_Cedula.Rows(e.RowIndex).Cells(1).Value = nombre
        End If

    End Sub

    Private Function ConsultarNombrePersona(ByVal IDENTIFICACION As String) As String
        'Consultar Valor de referencia del equipo
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("select dbo.Personanombrecompleto ( dbo.IdentificacionxIdPersona(@IDPERSONA) )", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", IDENTIFICACION)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtIdentificacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtIdentificacion)
            conexion.Close()
            If Not IsDBNull(dtIdentificacion.Rows(0).Item(0)) Then
                ConsultarNombrePersona = dtIdentificacion.Rows(0).Item(0)
            Else
                MsgBox("No se encontró el Número de Identificación", MsgBoxStyle.Exclamation, "Numero de identificación no Encontrado")
                ConsultarNombrePersona = ""
            End If
        Catch ex As Exception
            ConsultarNombrePersona = ""
        Finally
            conexion.Close()
        End Try
    End Function


    Private Sub Dgv_Cedula_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Dgv_Cedula.RowsAdded
        Me.Lb_TotalCedulla.Text = "Total Cédulas: " + (Me.Dgv_Cedula.Rows.Count - 1).ToString
    End Sub

    Private Sub Dgv_Cedula_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Dgv_Cedula.RowsRemoved
        Me.Lb_TotalCedulla.Text = "Total Cédulas: " + (Me.Dgv_Cedula.Rows.Count - 1).ToString
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If MsgBox("Se procedera a Imprimir los Paz y Salvos", MsgBoxStyle.YesNo, "Imprimir Paz y Salvos") = MsgBoxResult.Yes Then

            If Dgv_Cedula.Rows.Count = 0 Then
                MsgBox("No se especificó un número de identificación válido." + Environment.NewLine _
                                           + "Por favor ingrese el número de identificación correcto de la persona registrada en el sistema.")
                Exit Sub
            Else
                Dim Arraycedula As New ArrayList

                For i = 0 To Dgv_Cedula.Rows.Count - 1
                    Dim numeroDeCedula As String
                    numeroDeCedula = Dgv_Cedula.Rows(i).Cells(0).Value
                    numeroDeCedula = Replace(numeroDeCedula, " ", "")
                    numeroDeCedula = Replace(numeroDeCedula, "'", "")
                    numeroDeCedula = Replace(numeroDeCedula, ",", "")
                    numeroDeCedula = Replace(numeroDeCedula, ".", "")

                    If numeroDeCedula <> "" Then
                        Arraycedula.Add(numeroDeCedula)
                    End If

                Next
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                climpresiones.ArrrayCedulas = Arraycedula
                Array.Add(72)
                climpresiones.FormatoImprimirMateriales(Array, Cb_VistaPrevia.Checked, False)
            End If
        End If
    End Sub

    Private Sub Bt_LimpiarTabla_Click(sender As Object, e As EventArgs) Handles Bt_LimpiarTabla.Click
        Dgv_Cedula.Rows.Clear()
    End Sub
End Class