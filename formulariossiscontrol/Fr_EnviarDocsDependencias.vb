Imports System.Data.SqlClient
Imports System.Windows.Forms

''' <summary>Crea una relación de documentos para enviar a las dependencias de la base principal desde recepción.</summary>
Public Class Fr_EnviarDocsDependencias
    Private dtCorrespondencia As New DataTable
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private numeroRelacion As Integer

    Private Sub Fr_RelacionDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dgv_Listado.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Listado.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        CargarBases()
        For Each dgvc As DataGridViewColumn In Dgv_Listado.Columns
            dtCorrespondencia.Columns.Add(dgvc.DataPropertyName)
        Next
        Dgv_Listado.DataSource = dtCorrespondencia
    End Sub

    Private Sub Fr_EnviarDocsDependencias_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Cb_Dependencia.Select()
    End Sub

    ''' <summary></summary>
    Public Sub CargarBases()
        comando = New SqlCommand("ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 2) 'Cargar todas las bases activas.
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        adaptador = New SqlDataAdapter(comando)
        Dim dtBases As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtBases)
            conexion.Close()
            Cb_Base.DataSource = dtBases
            Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary></summary>
    Public Sub CargarDependencias()
        comando = New SqlCommand("ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        If VariablesBase.VariablesBase.IdBaseSiscontrolActual = 0 Then
            comando.Parameters("@ACCION").Value = 9 'Cargar todas las dependencias activas de la base (incluyendo Gerencia y excluyendo la dependencia actual).
        Else
            comando.Parameters("@ACCION").Value = 10 'Cargar todas las dependencias activas de la base (exluyendo Gerencia y la dependencia actual).
        End If
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", Cb_Base.SelectedValue)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        adaptador = New SqlDataAdapter(comando)
        Dim dtDependencias As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtDependencias)
            conexion.Close()
            If dtDependencias.Rows.Count > 0 Then
                Cb_Dependencia.DataSource = dtDependencias
                Cb_Dependencia.SelectedIndex = 0
            Else
                Cb_Base.SelectedValue = 0
                CargarDependencias()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Base.SelectedIndexChanged
        CargarDependencias()
    End Sub

    Private Sub Cb_Dependencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Dependencia.SelectedIndexChanged
        CargarRelaciones()
    End Sub

    Private Sub Cb_NumeroRelacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_NumeroRelacion.SelectedIndexChanged

    End Sub

    ''' <summary></summary>
    Private Sub CargarRelaciones()
        comando = New SqlCommand("SELECT * FROM SC_ListaEnviarDocsRecepcion(@IDDEPENDENCIA) ORDER BY NUMERORELACION DESC", conexion)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual) 'Cb_Dependencia.SelectedValue
        adaptador = New SqlDataAdapter(comando)
        Dim dtRelacion As New DataTable
        Try
            conexion.Close()
            adaptador.Fill(dtRelacion)
            conexion.Close()
            If dtRelacion.Rows.Count > 0 Then
                Cb_NumeroRelacion.DataSource = dtRelacion
                Cb_NumeroRelacion.SelectedIndex = -1
            Else
                If Not IsNothing(Cb_NumeroRelacion.DataSource) Then
                    DirectCast(Cb_NumeroRelacion.DataSource, DataTable).Clear()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaDesde.ValueChanged, Dtp_FechaHasta.ValueChanged

    End Sub

    Private Sub Bt_Cargar_Click(sender As Object, e As EventArgs) Handles Bt_CargarPorFechas.Click
        CargarRecepcionFechas()
        If Dgv_Listado.Rows.Count > 0 Then
            DeshabilitarControles()
            Tx_CodigoBarras.Select()
        End If
    End Sub

    Private Sub Bt_CargarRelacion_Click(sender As Object, e As EventArgs) Handles Bt_CargarRelacion.Click
        CargarRelacion()
        If Dgv_Listado.Rows.Count > 0 Then
            DeshabilitarControles()
            Tx_CodigoBarras.Select()
        End If
    End Sub

    ''' <summary></summary>
    Private Sub HabilitarControles()
        Cb_Base.Enabled = True
        Cb_Dependencia.Enabled = True
        Cb_NumeroRelacion.Enabled = True
        Dtp_FechaDesde.Enabled = True
        Dtp_FechaHasta.Enabled = True
        Tx_CodigoBarras.Enabled = True
        Dgv_Listado.ReadOnly = False
        Dgv_Listado.AllowUserToDeleteRows = True
        Bt_CargarPorFechas.Enabled = True
        Bt_CargarRelacion.Enabled = True
    End Sub

    ''' <summary></summary>
    Private Sub DeshabilitarControles()
        Cb_Base.Enabled = False
        Cb_Dependencia.Enabled = False
        Cb_NumeroRelacion.Enabled = False
        Dtp_FechaDesde.Enabled = False
        Dtp_FechaHasta.Enabled = False
        If numeroRelacion > 0 Then
            Tx_CodigoBarras.Enabled = False
            Dgv_Listado.ReadOnly = True
            Dgv_Listado.AllowUserToDeleteRows = False
        End If
        Bt_CargarPorFechas.Enabled = False
        Bt_CargarRelacion.Enabled = False
    End Sub

    ''' <summary></summary>
    Private Sub CargarRecepcionFechas()
        comando = New SqlCommand("SELECT * FROM InformeRecepcion(@TIPO, @FECHAI , @FECHAF, @IDDEPENDENCIA, @IDBASE)", conexion)
        comando.Parameters.AddWithValue("@TIPO", "R") 'Recepción y envío de documentos
        comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaDesde.Value)
        comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaHasta.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        comando.Parameters.AddWithValue("@IDBASE", Cb_Base.SelectedValue)
        adaptador = New SqlDataAdapter(comando)
        Dim dtRecepcion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtRecepcion)
            conexion.Close()
            If dtRecepcion.Rows.Count > 0 Then
                If dtRecepcion.Columns.Contains(Col_Etiqueta.DataPropertyName) Then
                    For i As Integer = 0 To dtRecepcion.Rows.Count - 1
                        Dim drCorrespondencia As DataRow = dtCorrespondencia.NewRow()
                        drCorrespondencia.Item(Col_Consecutivo.DataPropertyName) = dtRecepcion.Rows(i).Item("Consecutivo")
                        drCorrespondencia.Item(Col_FechaRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("Fecha Recepción")
                        drCorrespondencia.Item(Col_FuncionarioPara.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Para"))
                        drCorrespondencia.Item(Col_De.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("De"))
                        drCorrespondencia.Item(Col_NombreTipo.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Tipo Documento"))
                        drCorrespondencia.Item(Col_NumeroDocumento.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Numero Documento"))
                        drCorrespondencia.Item(Col_Valor.DataPropertyName) = dtRecepcion.Rows(i).Item("Valor")
                        drCorrespondencia.Item(Col_Descripcion.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Descripción"))
                        drCorrespondencia.Item(Col_Memorando.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Memo"))
                        drCorrespondencia.Item(Col_IdRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("IDRECEPCION")
                        drCorrespondencia.Item(Col_DependenciaPara.DataPropertyName) = dtRecepcion.Rows(i).Item("NOMBREDEPENDENCIA")
                        If Not IsDBNull(dtRecepcion.Rows(i).Item("ETIQUETA")) Then
                            drCorrespondencia.Item(Col_Etiqueta.DataPropertyName) = dtRecepcion.Rows(i).Item("ETIQUETA")
                        End If
                        dtCorrespondencia.Rows.Add(drCorrespondencia)
                    Next
                Else
                    For i As Integer = 0 To dtRecepcion.Rows.Count - 1
                        Dim drCorrespondencia As DataRow = dtCorrespondencia.NewRow()
                        drCorrespondencia.Item(Col_Consecutivo.DataPropertyName) = dtRecepcion.Rows(i).Item("Consecutivo")
                        drCorrespondencia.Item(Col_FechaRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("Fecha Recepción")
                        drCorrespondencia.Item(Col_FuncionarioPara.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Para"))
                        drCorrespondencia.Item(Col_De.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("De"))
                        drCorrespondencia.Item(Col_NombreTipo.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Tipo Documento"))
                        drCorrespondencia.Item(Col_NumeroDocumento.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Numero Documento"))
                        drCorrespondencia.Item(Col_Valor.DataPropertyName) = dtRecepcion.Rows(i).Item("Valor")
                        drCorrespondencia.Item(Col_Descripcion.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Descripción"))
                        drCorrespondencia.Item(Col_Memorando.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Memo"))
                        drCorrespondencia.Item(Col_IdRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("IDRECEPCION")
                        drCorrespondencia.Item(Col_DependenciaPara.DataPropertyName) = dtRecepcion.Rows(i).Item("NOMBREDEPENDENCIA")

                        dtCorrespondencia.Rows.Add(drCorrespondencia)
                    Next
                End If
                Dgv_Listado.AutoResizeColumns()
                Lb_TextoCantidadRegistros.Text = "Cantidad de registros: " & Dgv_Listado.Rows.Count
                Lb_TextoCantidadRegistros.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary></summary>
    Private Sub CargarRelacion()
        If Cb_NumeroRelacion.SelectedIndex >= 0 Then
            numeroRelacion = Cb_NumeroRelacion.SelectedValue
            comando = New SqlCommand("SELECT * FROM SC_ImpresionListaEnvioDocsRecepcion(@NUMERORELACION)", conexion)
            comando.Parameters.AddWithValue("@NUMERORELACION", numeroRelacion)
            adaptador = New SqlDataAdapter(comando)
            Dim dtRecepcion As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtRecepcion)
                conexion.Close()
                If dtRecepcion.Rows.Count > 0 Then
                    If dtRecepcion.Columns.Contains(Col_Etiqueta.DataPropertyName) Then
                        For i As Integer = 0 To dtRecepcion.Rows.Count - 1
                            Dim drCorrespondencia As DataRow = dtCorrespondencia.NewRow()
                            drCorrespondencia.Item(Col_Consecutivo.DataPropertyName) = dtRecepcion.Rows(i).Item("Consecutivo")
                            drCorrespondencia.Item(Col_FechaRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("Fecha Recepción")
                            drCorrespondencia.Item(Col_FuncionarioPara.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Para"))
                            drCorrespondencia.Item(Col_De.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("De"))
                            drCorrespondencia.Item(Col_NombreTipo.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Tipo Documento"))
                            drCorrespondencia.Item(Col_NumeroDocumento.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Numero Documento"))
                            drCorrespondencia.Item(Col_Valor.DataPropertyName) = dtRecepcion.Rows(i).Item("Valor")
                            drCorrespondencia.Item(Col_Descripcion.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Descripción"))
                            drCorrespondencia.Item(Col_Memorando.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Memo"))
                            drCorrespondencia.Item(Col_IdRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("IDRECEPCION")
                            drCorrespondencia.Item(Col_DependenciaPara.DataPropertyName) = dtRecepcion.Rows(i).Item("NOMBREDEPENDENCIA")
                            If Not IsDBNull(dtRecepcion.Rows(i).Item("ETIQUETA")) Then
                                drCorrespondencia.Item(Col_Etiqueta.DataPropertyName) = dtRecepcion.Rows(i).Item("ETIQUETA")
                            End If
                            dtCorrespondencia.Rows.Add(drCorrespondencia)
                        Next
                    Else
                        For i As Integer = 0 To dtRecepcion.Rows.Count - 1
                            Dim drCorrespondencia As DataRow = dtCorrespondencia.NewRow()
                            drCorrespondencia.Item(Col_Consecutivo.DataPropertyName) = dtRecepcion.Rows(i).Item("Consecutivo")
                            drCorrespondencia.Item(Col_FechaRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("Fecha Recepción")
                            drCorrespondencia.Item(Col_FuncionarioPara.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Para"))
                            drCorrespondencia.Item(Col_De.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("De"))
                            drCorrespondencia.Item(Col_NombreTipo.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Tipo Documento"))
                            drCorrespondencia.Item(Col_NumeroDocumento.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Numero Documento"))
                            drCorrespondencia.Item(Col_Valor.DataPropertyName) = dtRecepcion.Rows(i).Item("Valor")
                            drCorrespondencia.Item(Col_Descripcion.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Descripción"))
                            drCorrespondencia.Item(Col_Memorando.DataPropertyName) = Trim(dtRecepcion.Rows(i).Item("Memo"))
                            drCorrespondencia.Item(Col_IdRecepcion.DataPropertyName) = dtRecepcion.Rows(i).Item("IDRECEPCION")
                            drCorrespondencia.Item(Col_DependenciaPara.DataPropertyName) = dtRecepcion.Rows(i).Item("NOMBREDEPENDENCIA")

                            dtCorrespondencia.Rows.Add(drCorrespondencia)
                        Next
                    End If
                    Dgv_Listado.AutoResizeColumns()
                    Lb_TextoCantidadRegistros.Text = "Cantidad de registros: " & Dgv_Listado.Rows.Count
                    Lb_TextoCantidadRegistros.Visible = True
                    DeshabilitarControles()
                    Bt_Aceptar.Text = "Imprimir"
                    Bt_Cancelar.Text = "Cerrar"
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("Seleccione un número de relación", "Número relación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cb_NumeroRelacion.Select()
        End If
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
                    dtCorrespondencia.ImportRow(drRecepcion) 'dtCorrespondencia.Rows.Add(drRecepcion)
                    Dgv_Listado.AutoResizeColumns()
                    Lb_TextoCantidadRegistros.Text = "Cantidad de registros: " & Dgv_Listado.Rows.Count
                    Lb_TextoCantidadRegistros.Visible = True
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

    Private Sub Dgv_Listado_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Dgv_Listado.RowsRemoved
        Lb_TextoCantidadRegistros.Text = "Cantidad de registros: " & Dgv_Listado.Rows.Count
    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, ByVal e As EventArgs) Handles Bt_Aceptar.Click
        If Dgv_Listado.RowCount >= 1 Then
            If numeroRelacion <= 0 Then
                GuardarImpresoRecepcion()
            End If
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(78)
            climpresiones.NumeroRelacionEnvio = numeroRelacion
            climpresiones.FormatoImprimirSisControl(Array, True, False)
            If climpresiones.Impreso Then
                MessageBox.Show("Impresión finalizada.", "Fin impresión", MessageBoxButtons.OK)
            End If
            If MessageBox.Show("¿Desea continuar con el envío de documentos?", "Cambios guardados", MessageBoxButtons.YesNo) = DialogResult.No Then
                Me.Close()
            Else
                dtCorrespondencia.Clear()
                Cb_NumeroRelacion.SelectedIndex = -1
                numeroRelacion = -1
                HabilitarControles()
                Bt_Aceptar.Text = "Guardar"
                Bt_Cancelar.Text = "Cancelar"
                Cb_Base.Select()
            End If
        Else
            MessageBox.Show("No hay ningún dato en la lista.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    ''' <summary></summary>
    Private Sub GuardarImpresoRecepcion()
        dtCorrespondencia.AcceptChanges()
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
        comando.Parameters.AddWithValue("@Accion", 2) 'Enviar documentos.
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        comando.Parameters.AddWithValue("@NOMBRETERCERO", DBNull.Value)
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

End Class 'Fr_RelacionDocumentos