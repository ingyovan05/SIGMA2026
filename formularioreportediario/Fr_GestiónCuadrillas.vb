Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient

Public Class Fr_GestiónCuadrillas

    Public Idcuadrilla As Integer = -1
    Public TipoAccion As String = "I" ' "I"-Insertar "E"-Editar  "V"-Ver

    Dim bddatos As New FuncionesBase.ClaseCargarMaestras

    Dim TPersonas As New DataTable

    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Estilo_Celda As New DataGridViewCellStyle
    Private MensajeError As String

    Public CargandoFormulario As Boolean = True

    Public Sub Cargar_Tablas()

        Me.Dgv_Integrantes.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Integrantes.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Estilo_Celda_Error.BackColor = Color.Red
        Estilo_Celda.BackColor = Color.White

        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(7, VariablesBase.VariablesBase.IdBaseSiscontrolActual, Idcuadrilla, IIf(Idcuadrilla = -1, 1, 2))


        Me.DGVTBC_IDTIPORECURSO.DataSource = dsCargar.Tables(2)
        Me.DGVTBC_IDTIPORECURSO.ValueMember = "IDTIPORECURSO"
        Me.DGVTBC_IDTIPORECURSO.DisplayMember = "NOMBRETIPORECURSO"

        'Cargar personas
        TPersonas = dsCargar.Tables(1)
        Me.Dgv_Integrantes.DataSource = TPersonas




        Select Case TipoAccion
            Case "E"
                Dim fila As DataRow = dsCargar.Tables(0).Rows(0)
                Me.Tx_NombreCuadrilla.Text = fila("NOMBRECUADRILLA")
                If fila("ESTADO") = "A" Then
                    Me.Cb_Activo.Checked = True
                Else
                    Me.Cb_Activo.Checked = False
                End If
            Case "I"

        End Select

    End Sub


    Private Sub Dgv_ListaPersonas_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Integrantes.KeyDown
        CargandoFormulario = False
        Dim selectedColumna As Integer = Dgv_Integrantes.CurrentCell.ColumnIndex
        Select Case selectedColumna 'Buscar persona
            Case 4
                If e.KeyCode = Windows.Forms.Keys.F3 Then
                    Dim FrBuscarContrato As New FormulariosClasesBase.Fr_BuscarPersona
                    FrBuscarContrato._Tipo = "PCB"
                    FrBuscarContrato.Cargar_Tabla("PCB")

                    FrBuscarContrato.ShowDialog()
                    Dim CODIGOCONTRATO As Integer
                    CODIGOCONTRATO = FrBuscarContrato.CodigoContrato

                    If ValidarItemsRDPersona(CODIGOCONTRATO, -1) = True Then
                        Dim FilasContratos As DataRow()
                        Dim contratos As New DataTable()
                        Dim Cadena_Consulta As String = "SELECT * FROM dbo.DetalleContrato(" & CODIGOCONTRATO.ToString & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                        Dim Consulta As New SqlCommand(Cadena_Consulta)
                        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Consulta.Connection = Conexión
                        Dim Adaptador As New SqlDataAdapter(Consulta)
                        Consulta.Connection.Open()
                        Adaptador.FillSchema(contratos, SchemaType.Source)
                        Adaptador.Fill(contratos)
                        Consulta.Connection.Close()
                        FilasContratos = contratos.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString)
                        If FilasContratos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                            Dim FilaContrato As DataRow
                            FilaContrato = FilasContratos(0)
                            Dim NuevaFilaItem As DataRow
                            NuevaFilaItem = TPersonas.NewRow
                            NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                            NuevaFilaItem("IDPERSONA") = FilaContrato("IDPERSONA")
                            NuevaFilaItem("IDCONTRATO") = FilaContrato("IDCONTRATO")
                            NuevaFilaItem("CODIGOCONTRATO") = FilaContrato("CODIGOCONTRATO")
                            NuevaFilaItem("NOMBREPERSONA") = FilaContrato("NOMBREPERSONA")
                            NuevaFilaItem("IDTIPORECURSO") = FilaContrato("IDTIPORECURSO")
                            TPersonas.Rows.Add(NuevaFilaItem) '
                        Else
                            'No existe un artículo con este código
                            MensajeError = "No se encontró un artículo con ese código"
                            MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                        End If
                    Else
                        MensajeError = "El item que desea ingresar, ya se encuentra incluido en la requisición"
                        MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                    End If
                    ELiminarFilaVacia("P")
                ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then 'SI PRESIONA PARA ELIMINAR FILA
                    Try
                        If Me.Dgv_Integrantes.SelectedRows Is Nothing Then Exit Sub

                        Dim selectedRowCount As Integer = Dgv_Integrantes.Rows.GetRowCount(DataGridViewElementStates.Selected)
                        For I As Integer = 0 To selectedRowCount - 1
                            Me.Dgv_Integrantes.Rows.Remove(Dgv_Integrantes.SelectedRows(0))
                        Next
                    Catch
                    End Try

                    Try
                        TPersonas.AcceptChanges() 'LISTAITEMREQUISICION
                    Catch
                    End Try

                End If
        End Select


    End Sub

    Private Function ValidarItemsRDPersona(ByVal CODIGOCONTRATO As Integer, ByVal Orden As Integer) As Boolean
        Dim filas As DataRow()
        If Orden = -1 Then
            filas = TPersonas.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString + " AND ORDEN<>0") 'LISTAITEMREQUISICION
        Else
            filas = TPersonas.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString + " AND ORDEN<>" + Orden.ToString) 'LISTAITEMREQUISICION
        End If
        If filas.Length > 0 Then
            ValidarItemsRDPersona = False
            Exit Function
        End If
        ValidarItemsRDPersona = True
    End Function

    Private Sub ELiminarFilaVacia(ByVal tipo As String)
        Try
            Select Case tipo
                Case "P"
                    For i = 0 To Dgv_Integrantes.Rows.Count - 2
                        If IsDBNull(Me.Dgv_Integrantes.Rows(i).Cells(DGVTBC_NOMBREPERSONA.Name).Value) Then
                            Me.Dgv_Integrantes.Rows.RemoveAt(i)
                        End If
                    Next
            End Select
        Catch
        End Try
    End Sub
    Private Sub Dgv_ListaPersonas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Integrantes.CellEndEdit
        If IsDBNull(Me.Dgv_Integrantes.Item(e.ColumnIndex, e.RowIndex).Value) Then
            Me.Dgv_Integrantes.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If

        If Trim(Me.Dgv_Integrantes.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
            If e.RowIndex > 0 Then
                Me.Dgv_Integrantes.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_Integrantes.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Me.Dgv_Integrantes.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
            End If
            Exit Sub
        End If

        Dim CODIGOCONTRATO As Integer = -1
        Dim ORDEN As Integer = -1

        If Not IsDBNull(Me.Dgv_Integrantes.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value) Then
            CODIGOCONTRATO = Me.Dgv_Integrantes.Item(DGVTBC_CODIGOCONTRATO.Name, e.RowIndex).Value
        End If

        If Not IsDBNull(Me.Dgv_Integrantes.Item(DGVTBC_ORDEN.Name, e.RowIndex).Value) Then
            ORDEN = Me.Dgv_Integrantes.Item(DGVTBC_ORDEN.Name, e.RowIndex).Value
        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_Integrantes.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_Integrantes.Rows(e.RowIndex).ErrorText = ""

        'Validar Artículo
        Select Case e.ColumnIndex
            Case Dgv_Integrantes.Columns(DGVTBC_CODIGOCONTRATO.Name).Index '1

                If ValidarItemsRDPersona(CODIGOCONTRATO, -1) = True Then
                    Dim FilasContratos As DataRow()
                    Dim contratos As New DataTable()
                    Dim Cadena_Consulta As String = "SELECT * FROM dbo.DetalleContrato(" & CODIGOCONTRATO.ToString & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")" 'DatosArticuloxBodega
                    Dim Consulta As New SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Adaptador.FillSchema(contratos, SchemaType.Source)
                    Adaptador.Fill(contratos)
                    Consulta.Connection.Close()
                    FilasContratos = contratos.Select("CODIGOCONTRATO=" + CODIGOCONTRATO.ToString)
                    If FilasContratos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                        Dim FilaContrato As DataRow
                        FilaContrato = FilasContratos(0)
                        Dim NuevaFilaItem As DataRow
                        NuevaFilaItem = TPersonas.NewRow
                        NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                        NuevaFilaItem("IDPERSONA") = FilaContrato("IDPERSONA")
                        NuevaFilaItem("IDCONTRATO") = FilaContrato("IDCONTRATO")
                        NuevaFilaItem("CODIGOCONTRATO") = FilaContrato("CODIGOCONTRATO")
                        NuevaFilaItem("NOMBREPERSONA") = FilaContrato("NOMBREPERSONA")
                        NuevaFilaItem("IDTIPORECURSO") = FilaContrato("IDTIPORECURSO")
                        If TPersonas.Rows.Count = Me.Dgv_Integrantes.CurrentCell.RowIndex Then '
                            Try
                                Me.Dgv_Integrantes.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                            TPersonas.Rows.Add(NuevaFilaItem) '
                        Else
                            TPersonas.Rows(e.RowIndex).Item("ORDEN") = NuevaFilaItem("ORDEN") '
                            TPersonas.Rows(e.RowIndex).Item("IDPERSONA") = NuevaFilaItem("IDPERSONA") '
                            TPersonas.Rows(e.RowIndex).Item("IDCONTRATO") = NuevaFilaItem("IDCONTRATO") '
                            TPersonas.Rows(e.RowIndex).Item("CODIGOCONTRATO") = NuevaFilaItem("CODIGOCONTRATO") '
                            TPersonas.Rows(e.RowIndex).Item("NOMBREPERSONA") = NuevaFilaItem("NOMBREPERSONA") '
                            NuevaFilaItem("IDTIPORECURSO") = FilaContrato("IDTIPORECURSO")
                        End If
                    Else
                        'No existe un artículo con este código
                        MensajeError = "No se encontró un contrato con ese código"
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Contrato no Encontrado")
                        Try
                            Me.Dgv_Integrantes.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                    End If
                Else
                    MensajeError = "El item que desea ingresar, ya se encuentra incluido en el reporte diario"
                    MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")

                    'falta validar que si esta editando uno no borre el actual
                    Try
                        Me.Dgv_Integrantes.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
        End Select
        ELiminarFilaVacia("P")
    End Sub

    Dim guardado As Boolean = False


    Private Sub OK_Guardar_Click(sender As Object, e As EventArgs) Handles OK_Guardar.Click

        TPersonas.AcceptChanges()
        'Llamar al procedimiento para crear el tipo categoría
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarCuadrillas")
        Comando.CommandType = CommandType.StoredProcedure
        Select Case TipoAccion
            Case "I"
                Comando.Parameters.AddWithValue("@ACCION", 1)
            Case "E"
                Comando.Parameters.AddWithValue("@ACCION", 2)
        End Select

        Comando.Parameters.AddWithValue("@IDCUADRILLA", Idcuadrilla)
        Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@NOMBRECUADRILLA", Me.Tx_NombreCuadrilla.Text)
        Comando.Parameters.AddWithValue("@ESTADO", IIf(Me.Cb_Activo.Checked = True, "A", "I"))
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@TablaCUADRILLAPERSONA", TPersonas)

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 0)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()

        Select Case Comando.Parameters("@IDMENSAJE").Value
            Case 0
                MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completo la operación")
                guardado = False
                Exit Sub
            Case 1
                MsgBox("EL registro a sido exitoso", MsgBoxStyle.Information, "PERSONA")
                guardado = True
                Me.Close()
        End Select

    End Sub


    Private Sub Ll_Agregardesdeportapapeles_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Ll_Agregardesdeportapapeles.LinkClicked
        Me.Cursor = Cursors.WaitCursor

        Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
        Dim words() As String = Clipboard.GetText().Split(delimiterChars)
        For i = 0 To words.Length - 1
            Dim line As String
            line = words(i)
            If line.Length > 0 Then
                Try
                    If ValidarItemsRDPersona(line, -1) = True Then
                        Dim FilasContratos As DataRow()
                        Dim contratos As New DataTable()
                        Dim Cadena_Consulta As String = "SELECT * FROM dbo.DetalleContrato(" & line.ToString & "," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")" 'DatosArticuloxBodega
                        Dim Consulta As New SqlCommand(Cadena_Consulta)
                        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                        Consulta.Connection = Conexión
                        Dim Adaptador As New SqlDataAdapter(Consulta)
                        Consulta.Connection.Open()
                        Adaptador.FillSchema(contratos, SchemaType.Source)
                        Adaptador.Fill(contratos)
                        Consulta.Connection.Close()
                        FilasContratos = contratos.Select("CODIGOCONTRATO=" + line.ToString)
                        If FilasContratos.Length > 0 Then 'se encontro un contrato activo con ese codigo
                            Dim FilaContrato As DataRow
                            FilaContrato = FilasContratos(0)
                            Dim NuevaFilaItem As DataRow
                            NuevaFilaItem = TPersonas.NewRow
                            NuevaFilaItem("ORDEN") = TPersonas.Rows.Count + 1
                            NuevaFilaItem("IDPERSONA") = FilaContrato("IDPERSONA")
                            NuevaFilaItem("IDCONTRATO") = FilaContrato("IDCONTRATO")
                            NuevaFilaItem("CODIGOCONTRATO") = FilaContrato("CODIGOCONTRATO")
                            NuevaFilaItem("NOMBREPERSONA") = FilaContrato("NOMBREPERSONA")
                            TPersonas.Rows.Add(NuevaFilaItem)
                        End If
                    End If

                Catch ex As Exception
                End Try
            End If
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Dim activocolumnasTSMI_CopiarTodas As Boolean = False
    Dim activocolumnasTSMI_LimpiarTodas As Boolean = False

    Private Function ValidarColumna() As Boolean
        Dim Nombre_Columna As String = ""
        activocolumnasTSMI_CopiarTodas = False
        activocolumnasTSMI_LimpiarTodas = False
        Nombre_Columna = Me.Dgv_Integrantes.Columns(Me.Dgv_Integrantes.CurrentCell.ColumnIndex).HeaderText
        Select Case Nombre_Columna
            Case "Tipo Recurso"
                activocolumnasTSMI_CopiarTodas = True
                activocolumnasTSMI_LimpiarTodas = True
                ValidarColumna = True
                Exit Function
            Case Else
                ValidarColumna = False
                Exit Function
        End Select
        ValidarColumna = False
    End Function

    Private Sub Cms_opciones_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Cms_opciones.Opening
        ValidarColumna()
        TSMI_CopiarTodas.Enabled = activocolumnasTSMI_CopiarTodas
        TSMI_LimpiarTodas.Enabled = activocolumnasTSMI_LimpiarTodas
    End Sub


    Private Sub CopiarEnTodasLasCeldasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CopiarTodas.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer
        Nombre_Columna = Me.Dgv_Integrantes.Columns(Me.Dgv_Integrantes.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_Integrantes.CurrentCell.ColumnIndex
        Dim valorcopiarid As Integer = -1
        Dim IndiceFilaseleccionada As Integer = Dgv_Integrantes.CurrentRow.Index
        valorcopiarid = Me.Dgv_Integrantes.Item(Indice_Columna, IndiceFilaseleccionada).Value
        If MsgBox("¿Seguro que desea copiar el valor en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        For i = 0 To Me.Dgv_Integrantes.RowCount - 1
            If Me.Dgv_Integrantes.Item(1, i).Value <> Nothing Then
                Me.Dgv_Integrantes.Item(Indice_Columna, i).Value = valorcopiarid
            End If
        Next
        Try
            Me.Dgv_Integrantes.CurrentCell = Me.Dgv_Integrantes(0, 1)
            Me.Dgv_Integrantes.CurrentCell = Me.Dgv_Integrantes(Indice_Columna, 0)
        Catch ex As Exception
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TSMI_LimpiarTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_LimpiarTodas.Click
        Dim Nombre_Columna As String = ""
        Dim Indice_Columna As Integer

        Nombre_Columna = Me.Dgv_Integrantes.Columns(Me.Dgv_Integrantes.CurrentCell.ColumnIndex).HeaderText
        Indice_Columna = Me.Dgv_Integrantes.CurrentCell.ColumnIndex
       
        Dim Valor_Copiar As String = ""
        If MsgBox("¿Seguro que desea copiar el valor " + _
            Valor_Copiar + " en la columna " + Nombre_Columna + "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        For i = 0 To Me.Dgv_Integrantes.RowCount - 1
            Me.Dgv_Integrantes.Item(Indice_Columna, i).Value = DBNull.Value
        Next
        Try
            Me.Dgv_Integrantes.CurrentCell = Me.Dgv_Integrantes(0, 1)
            Me.Dgv_Integrantes.CurrentCell = Me.Dgv_Integrantes(Indice_Columna, 0)
        Catch ex As Exception
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Bt_salir_Click(sender As Object, e As EventArgs) Handles Bt_salir.Click
        If MsgBox("¿Desea salir sin guardar?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class