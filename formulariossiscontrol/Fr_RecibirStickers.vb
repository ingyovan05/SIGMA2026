Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing

''' <summary></summary>
Public Class Fr_RecibirStickers
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dtSticker As New DataTable

    Private Sub Fr_RecibirStickersRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each dgvc As DataGridViewColumn In Dgv_StickersRecepcion.Columns
            dtSticker.Columns.Add(dgvc.DataPropertyName)
        Next
        Dgv_StickersRecepcion.DataSource = dtSticker
    End Sub

    Private Sub Fr_RecibirStickers_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Tx_CodigoBarras.Select()
    End Sub

    Private Sub Tx_CodigoBarras_TextChanged(sender As Object, e As EventArgs) Handles Tx_CodigoBarras.TextChanged
        Tx_CodigoBarras.BackColor = SystemColors.Window
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_CodigoBarras.KeyDown
        Dim cantFilas As Integer = DirectCast(Dgv_StickersRecepcion.DataSource, DataTable).Rows.Count
        Select Case e.KeyCode
            Case Keys.Enter
                Try
                    AgregarRecepcion(Tx_CodigoBarras.Text)
                    If cantFilas < DirectCast(Dgv_StickersRecepcion.DataSource, DataTable).Rows.Count Then
                        Tx_CodigoBarras.Clear()
                    Else
                        Throw New Exception("No se encontró el registro.")
                    End If
                Catch ex As Exception
                    Tx_CodigoBarras.BackColor = Drawing.Color.Red
                    System.Media.SystemSounds.Exclamation.Play()
                Finally
                    e.SuppressKeyPress = True
                    Tx_CodigoBarras.Select()
                    'Tx_CodigoBarras.SelectionStart = Tx_CodigoBarras.Text.Length
                End Try
        End Select
    End Sub

    ''' <summary>
    ''' Incluir el registro de recepción correspondiente al sticker leído.
    ''' </summary>
    ''' <param name="sticker">Número del sticker</param>
    ''' <remarks></remarks>
    Private Sub AgregarRecepcion(sticker As String)
        comando = New SqlCommand("SELECT * FROM SC_DatosRecepcionSticker(@NUMEROSTICKER)", conexion)
        comando.Parameters.AddWithValue("@NUMEROSTICKER", sticker)
        adaptador = New SqlDataAdapter(comando)
        Dim dtRecepcion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtRecepcion)
            conexion.Close()
            If dtRecepcion.Rows.Count > 0 Then
                Dim drRecepcion As DataRow = dtRecepcion.Rows(0)
                If ValidarRecepcion(drRecepcion) Then
                    DirectCast(Dgv_StickersRecepcion.DataSource, DataTable).ImportRow(drRecepcion)
                    Dgv_StickersRecepcion.AutoResizeColumns()
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Validar si el código de barras del sticker ya fue leído.
    ''' </summary>
    ''' <param name="drRecepcion">Fila del registro de recepción a agregar.</param>
    ''' <returns>Si la recepción del sticker ya se incluyó.</returns>
    ''' <remarks></remarks>
    Private Function ValidarRecepcion(drRecepcion As DataRow)
        For i As Integer = 0 To Dgv_StickersRecepcion.Rows.Count - 1
            If Dgv_StickersRecepcion.Rows(i).Cells(Col_NumeroSticker.Name).Value = drRecepcion.Item(Col_NumeroSticker.DataPropertyName) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Dim dtGuardar As DataTable = dtSticker.Copy
        If dtGuardar.Columns.Contains(Col_Etiqueta.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Etiqueta.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Base.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Base.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Consecutivo.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Consecutivo.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_De.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_De.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NIT.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NIT.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NombreTipo.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NombreTipo.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NumeroDocumento.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NumeroDocumento.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Memorando.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Memorando.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_DependenciaPara.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_DependenciaPara.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NombreGerencia.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NombreGerencia.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Descripcion.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Descripcion.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NumeroSticker.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NumeroSticker.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Valor.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Valor.DataPropertyName)
        End If
        comando = New SqlCommand("MarcarSC_RecepcionTrazabilidad", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", 1) 'Recibir documentos.
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        comando.Parameters.AddWithValue("@NOMBRETERCERO", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIAACTUAL", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@TablaRECEPCION", dtGuardar)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If MessageBox.Show("Se guardaron los cambios." & Environment.NewLine & "¿Desea continuar con la recepción de documentos?", "Cambios guardados", MessageBoxButtons.YesNo) = DialogResult.No Then
                Me.Close()
            Else
                dtSticker.Clear()
                Tx_CodigoBarras.Select()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub
End Class