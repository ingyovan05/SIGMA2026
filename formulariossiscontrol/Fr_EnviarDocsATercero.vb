Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_EnviarDocsATercero
    Private dtCorrespondencia As New DataTable
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private numeroRelacion As Integer

    Private Sub Fr_EnviarDocsATercero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dgv_Listado.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Listado.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        For Each dgvc As DataGridViewColumn In Dgv_Listado.Columns
            dtCorrespondencia.Columns.Add(dgvc.DataPropertyName)
        Next
        Dgv_Listado.DataSource = dtCorrespondencia
    End Sub

    Private Sub Tx_CodigoBarras_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_CodigoBarras.KeyDown
        Dim cantFilas As Integer = 0
        If Not IsNothing(Dgv_Listado.DataSource) Then
            cantFilas = dtCorrespondencia.Rows.Count
        End If
        Select Case e.KeyCode
            Case Keys.Enter
                Try
                    AgregarRecepcion(Tx_CodigoBarras.Text)
                    If cantFilas < dtCorrespondencia.Rows.Count Then
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
                    dtCorrespondencia.ImportRow(drRecepcion)
                    Dgv_Listado.AutoResizeColumns()
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
        For i As Integer = 0 To Dgv_Listado.Rows.Count - 1
            If Not IsDBNull(Dgv_Listado.Rows(i).Cells(Col_NumeroSticker.Name).Value) AndAlso Dgv_Listado.Rows(i).Cells(Col_NumeroSticker.Name).Value = drRecepcion.Item(Col_NumeroSticker.DataPropertyName) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Dgv_Listado.RowCount >= 1 Then
            GuardarImpresoRecepcion()
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(78)
            'climpresiones.IDDEPENDENCIA = Cb_Dependencia.SelectedValue
            climpresiones.NumeroRelacionEnvio = numeroRelacion
            climpresiones.FormatoImprimirSisControl(Array, True, False)
            If climpresiones.Impreso Then
                MessageBox.Show("Impresión finalizada.", "Fin impresión", MessageBoxButtons.OK)
            End If
            Me.Close()
        Else
            MessageBox.Show("No hay ningún dato en la lista.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    ''' <summary></summary>
    Private Sub GuardarImpresoRecepcion()
        Dim dtGuardar As DataTable = dtCorrespondencia.Copy
        If dtGuardar.Columns.Contains(Col_Consecutivo.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Consecutivo.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_FechaRecepcion.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_FechaRecepcion.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_FuncionarioPara.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_FuncionarioPara.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_De.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_De.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NombreTipo.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NombreTipo.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NumeroDocumento.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NumeroDocumento.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Valor.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Valor.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Descripcion.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Descripcion.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Memorando.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Memorando.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Etiqueta.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Etiqueta.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_DependenciaPara.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_DependenciaPara.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_Base.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_Base.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NIT.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NIT.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NombreGerencia.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NombreGerencia.DataPropertyName)
        End If
        If dtGuardar.Columns.Contains(Col_NumeroSticker.DataPropertyName) Then
            dtGuardar.Columns.Remove(Col_NumeroSticker.DataPropertyName)
        End If
        comando = New SqlCommand("MarcarSC_RecepcionTrazabilidad", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", 4) 'Enviado a Tercero.
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@NOMBRETERCERO", "")
        comando.Parameters.AddWithValue("@IDDEPENDENCIAACTUAL", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@TablaRECEPCION", dtGuardar)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
                numeroRelacion = comando.Parameters("@Mensaje").Value
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