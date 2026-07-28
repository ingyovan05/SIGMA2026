Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing

Public Class Fr_NoConformidad
    Public IdNoConformidad As Integer
    Public TipoEdicion As TiposEdicion
    Public Enum TiposEdicion
        Crear
        Editar
        Ver
        Cerrar
    End Enum
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private filaNoConformidad As DataRow
    Private dtAcciones As New DataTable
    Private dtSistema As New DataTable
    Private dtTipo As New DataTable
    Private idBaseActual As Integer
    Private archivoAnexoOT As Byte()
    Private archivoAnexoAC As Byte()
    Private cargoAnexoOT As Boolean = False
    Private cargoAnexoAC As Boolean = False
    Private valorCelda As Object
    Private _guardado As Boolean = False
    ReadOnly Property Guardado As Boolean
        Get
            Return _guardado
        End Get
    End Property


    Private Sub Fr_NoConformidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idBaseActual = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        comando = New SqlCommand("dbo.NC_DatosNoConformidad", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        Select Case TipoEdicion
            Case TiposEdicion.Crear
                comando.Parameters("@Accion").Value = 1
            Case TiposEdicion.Editar
                comando.Parameters("@Accion").Value = 2
            Case TiposEdicion.Ver
                comando.Parameters("@Accion").Value = 3
            Case TiposEdicion.Cerrar
                comando.Parameters("@Accion").Value = 4
            Case Else
                comando.Parameters("@Accion").Value = DBNull.Value
        End Select
        comando.Parameters.Add("@IDNOCONFORMIDAD", SqlDbType.Int)
        If TipoEdicion <> TiposEdicion.Crear Then
            comando.Parameters("@IDNOCONFORMIDAD").Value = IdNoConformidad
        End If
        adaptador = New SqlDataAdapter(comando)
        Dim dsNoConformidad As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsNoConformidad)
            conexion.Close()
            If dsNoConformidad.Tables.Count > 0 Then
                If TipoEdicion = TiposEdicion.Crear Then

                Else
                    If dsNoConformidad.Tables(0).Rows.Count > 0 Then
                        filaNoConformidad = dsNoConformidad.Tables(0).Rows(0)
                    Else
                        MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                dtAcciones = dsNoConformidad.Tables(1)
            Else
                MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        dtSistema.Columns.Add("CODIGOSISTEMA")
        dtSistema.Columns.Add("NOMBRESISTEMA")
        dtSistema.Rows.Add("SGC", "SGC")
        dtSistema.Rows.Add("SGA", "SGA")
        dtSistema.Rows.Add("SST", "SST")
        dtSistema.Rows.Add("O", "Otras")
        Cb_Sistema.DataSource = dtSistema
        Cb_Sistema.SelectedIndex = -1
        dtTipo.Columns.Add("CODIGOTIPO")
        dtTipo.Columns.Add("NOMBRETIPO")
        dtTipo.Rows.Add("NC", "No conformodidad")
        dtTipo.Rows.Add("SNC", "Salida no conforme")
        Cb_Tipo.DataSource = dtTipo
        Cb_Tipo.SelectedIndex = -1
        Dgv_Acciones.DataSource = dtAcciones
        Dgv_Acciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        If TipoEdicion = TiposEdicion.Crear Then
            Tx_Contrato.Text = ConsultarContrato(VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Else
            VariablesBase.VariablesBase.IdBaseSiscontrolActual = filaNoConformidad("IDBASE")
            'idDependencia
            If Not IsDBNull(filaNoConformidad("SISTEMA")) Then
                Cb_Sistema.SelectedValue = filaNoConformidad("SISTEMA")
            End If
            If Not IsDBNull(filaNoConformidad("TIPONOCONFORMIDAD")) Then
                Cb_Tipo.SelectedValue = filaNoConformidad("TIPONOCONFORMIDAD")
            End If
            If Not IsDBNull(filaNoConformidad("FECHA")) Then
                Dtp_Fecha.Value = filaNoConformidad("FECHA")
            Else
                Dtp_Fecha.Checked = False
            End If
            If Not IsDBNull(filaNoConformidad("LISTAORDENESDETRABAJO")) Then
                Tx_OrdenTrabajo.Text = filaNoConformidad("LISTAORDENESDETRABAJO")
            End If
            If Not IsDBNull(filaNoConformidad("NUMEROREPORTE")) Then
                Tx_NumeroReporte.Text = filaNoConformidad("NUMEROREPORTE")
            End If
            If Not IsDBNull(filaNoConformidad("CONTRATO")) Then
                Tx_Contrato.Text = filaNoConformidad("CONTRATO")
            End If
            If Not IsDBNull(filaNoConformidad("NUMEROAUDITORIA")) Then
                Tx_NumeroAuditoria.Text = filaNoConformidad("NUMEROAUDITORIA")
            End If
            If Not IsDBNull(filaNoConformidad("PROCESO")) Then
                Tx_Proceso.Text = filaNoConformidad("PROCESO")
            End If
            If Not IsDBNull(filaNoConformidad("DETECTOR")) Then
                Tx_Detector.Text = filaNoConformidad("DETECTOR")
            End If
            If Not IsDBNull(filaNoConformidad("FUENTE")) Then
                Tx_Fuente.Text = filaNoConformidad("FUENTE")
            End If
            If Not IsDBNull(filaNoConformidad("REPRESENTANTEPROCESO")) Then
                Tx_RepProc.Text = filaNoConformidad("REPRESENTANTEPROCESO")
            End If
            If Not IsDBNull(filaNoConformidad("DESCRIPCION")) Then
                Tx_Descripcion.Text = filaNoConformidad("DESCRIPCION")
            End If
            If Not IsDBNull(filaNoConformidad("REACCION")) Then
                Tx_Reaccion.Text = filaNoConformidad("REACCION")
            End If
            If Not IsDBNull(filaNoConformidad("EXISTENSIMILARES")) Then
                If filaNoConformidad("EXISTENSIMILARES") = "S" Then
                    Ck_ExistenNC.CheckState = CheckState.Checked
                Else
                    Ck_ExistenNC.CheckState = CheckState.Unchecked
                End If
            Else
                Ck_ExistenNC.CheckState = CheckState.Indeterminate
            End If
            If Not IsDBNull(filaNoConformidad("ANEXOANALISISCAUSAS")) AndAlso Not IsDBNull(filaNoConformidad("NOMBREANEXOAC")) Then
                archivoAnexoAC = filaNoConformidad("ANEXOANALISISCAUSAS")
                Tx_AnexoAC.Text = filaNoConformidad("NOMBREANEXOAC")
            End If
            If Not IsDBNull(filaNoConformidad("VERIFICACIONEFICACIA")) Then
                Tx_VerificacionEficacia.Text = filaNoConformidad("VERIFICACIONEFICACIA")
            End If

            If TipoEdicion = TiposEdicion.Cerrar Then
                If Not IsDBNull(filaNoConformidad("FECHACIERRE")) Then
                    Dtp_FechaCierre.Value = filaNoConformidad("FECHACIERRE")
                End If
            End If
        End If
        If TipoEdicion = TiposEdicion.Crear OrElse TipoEdicion = TiposEdicion.Editar Then
            Dtp_FechaCierre.Enabled = False
        ElseIf TipoEdicion = TiposEdicion.Cerrar Then
            Cb_Sistema.Enabled = False
            Cb_Tipo.Enabled = False
            Dtp_Fecha.Enabled = False
            Tx_OrdenTrabajo.ReadOnly = True
            Tx_NumeroReporte.ReadOnly = True
            Tx_Contrato.ReadOnly = True
            Tx_NumeroAuditoria.ReadOnly = True
            Tx_Proceso.ReadOnly = True
            Tx_Detector.ReadOnly = True
            Tx_Fuente.ReadOnly = True
            Tx_RepProc.ReadOnly = True
            Tx_Descripcion.ReadOnly = True
            Tx_Reaccion.ReadOnly = True
            Ck_ExistenNC.Enabled = False
            Bt_CargarAnexoAC.Enabled = False
            'Bt_VerAnexoAC.Enabled = False
            'Bt_QuitarAnexoAC.Enabled = False
            Bt_AgregarAcciones.Enabled = False
            Dgv_Acciones.Enabled = False
            Dgv_Acciones.ReadOnly = True
            Dgv_Acciones.AllowUserToAddRows = False
            Tx_VerificacionEficacia.ReadOnly = True

            Dtp_FechaCierre.Enabled = True
        ElseIf TipoEdicion = TiposEdicion.Ver Then
            Cb_Sistema.Enabled = False
            Cb_Tipo.Enabled = False
            Dtp_Fecha.Enabled = False
            Tx_OrdenTrabajo.ReadOnly = True
            Tx_NumeroReporte.ReadOnly = True
            Tx_Contrato.ReadOnly = True
            Tx_NumeroAuditoria.ReadOnly = True
            Tx_Proceso.ReadOnly = True
            Tx_Detector.ReadOnly = True
            Tx_Fuente.ReadOnly = True
            Tx_RepProc.ReadOnly = True
            Tx_Descripcion.ReadOnly = True
            Tx_Reaccion.ReadOnly = True
            Ck_ExistenNC.Enabled = False
            Bt_CargarAnexoAC.Enabled = False
            'Bt_VerAnexoAC.Enabled = (archivoAnexoAC IsNot Nothing)
            'Bt_QuitarAnexoAC.Enabled = False
            Bt_AgregarAcciones.Enabled = False
            Dgv_Acciones.Enabled = False
            Dgv_Acciones.ReadOnly = True
            Dgv_Acciones.AllowUserToAddRows = False
            Tx_VerificacionEficacia.ReadOnly = True
            Dtp_FechaCierre.Enabled = False
            Bt_Aceptar.Visible = False
        End If
    End Sub

    Private Function ConsultarContrato(idBase As Integer) As String
        comando = New SqlCommand("SELECT dbo.CodigoProyectoCliente(@IdBase)", conexion)
        comando.Parameters.AddWithValue("@IdBase", idBase)
        Dim resultado As String
        Try
            conexion.Open()
            resultado = comando.ExecuteScalar()
            conexion.Close()
            If Not IsDBNull(resultado) Then
                Return resultado
            Else
                Return ""
            End If
        Catch ex As Exception
            conexion.Close()
            Return ""
        End Try
    End Function

    Private Sub Fr_NoConformidad_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If TipoEdicion = TiposEdicion.Ver Then
            Bt_Cancelar.Select()
        ElseIf TipoEdicion = TiposEdicion.Cerrar Then
            Dtp_FechaCierre.Select()
        Else
            Cb_Sistema.Select()
        End If
    End Sub


    Private Sub Tx_AnexoAC_TextChanged(sender As Object, e As EventArgs) Handles Tx_AnexoAC.TextChanged
        If TipoEdicion <> TiposEdicion.Cerrar Then
            If Tx_AnexoAC.Text.Length > 0 Then
                Bt_VerAnexoAC.Enabled = True
                If TipoEdicion <> TiposEdicion.Ver Then
                    Bt_QuitarAnexoAC.Enabled = True
                End If
            Else
                Bt_VerAnexoAC.Enabled = False
                Bt_QuitarAnexoAC.Enabled = False
            End If
        End If
    End Sub

    Private Sub Bt_CargarAnexoAC_Click(sender As Object, e As EventArgs) Handles Bt_CargarAnexoAC.Click
        If Ofd_AnexoAnalisisCausas.ShowDialog() = DialogResult.OK Then
            Dim archivoBinario As Byte() = File.ReadAllBytes(Ofd_AnexoAnalisisCausas.FileName)
            If archivoBinario.Length <= 10485760 Then 'Si el archivo tiene tamaño inferior a 10 MB.
                archivoAnexoAC = archivoBinario
                Tx_AnexoAC.Text = Path.GetFileName(Ofd_AnexoAnalisisCausas.FileName)
                cargoAnexoAC = True
            Else
                MessageBox.Show("El tamaño del archivo seleccionado supera los 10 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Bt_VerAnexoAC_Click(sender As Object, e As EventArgs) Handles Bt_VerAnexoAC.Click
        VerArchivo(archivoAnexoAC, Path.GetExtension(Tx_AnexoAC.Text))
    End Sub

    Private Sub Bt_QuitarAnexoAC_Click(sender As Object, e As EventArgs) Handles Bt_QuitarAnexoAC.Click
        archivoAnexoAC = Nothing
        cargoAnexoAC = False
        Tx_AnexoAC.Text = ""
    End Sub

    Private Sub VerArchivo(archivoBinario As Byte(), Optional extension As String = ".pdf")
        Dim archivoTemp As String = VariablesBase.VariablesBase._path & "\" & "temp" & extension
        If File.Exists(archivoTemp) Then
            Try
                File.Delete(archivoTemp)
            Catch ex As Exception

            End Try
        End If
        File.WriteAllBytes(archivoTemp, archivoBinario)
        Try
            Process.Start(archivoTemp)
        Catch
            MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Bt_AgregarAcciones_Click(sender As Object, e As EventArgs) Handles Bt_AgregarAcciones.Click
        Using frAgregar As New Fr_AgregarAcciones
            If frAgregar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim fila As DataRow = dtAcciones.NewRow
                If TipoEdicion = TiposEdicion.Crear Then
                    fila(Col_IdNoConformidad.DataPropertyName) = -1
                Else
                    fila(Col_IdNoConformidad.DataPropertyName) = IdNoConformidad
                End If
                fila(Col_Acciones.DataPropertyName) = frAgregar.Acciones
                fila(Col_Responsable.DataPropertyName) = frAgregar.Responsable
                fila(Col_Aprueba.DataPropertyName) = frAgregar.Aprueba
                If frAgregar.FechaPropuesta IsNot Nothing Then
                    fila(Col_FechaPropuesta.DataPropertyName) = frAgregar.FechaPropuesta.Value
                End If
                fila(Col_Seguimiento.DataPropertyName) = frAgregar.Seguimiento
                fila(Col_IdUsuarioRegistra.DataPropertyName) = VariablesBase.VariablesBase.IdPersona
                fila(Col_FechaRegistro.DataPropertyName) = DateTime.Now

                dtAcciones.Rows.Add(fila)
            End If
        End Using
    End Sub

    Private Sub Dgv_Acciones_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Dgv_Acciones.CellBeginEdit
        valorCelda = Dgv_Acciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
    End Sub

    Private Sub Dgv_Acciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Acciones.CellEndEdit
        If Not IsDBNull(Dgv_Acciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            If IsDBNull(valorCelda) OrElse Dgv_Acciones.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> valorCelda Then
                Dim fila As DataGridViewRow = Dgv_Acciones.Rows(e.RowIndex)
                If TipoEdicion = TiposEdicion.Editar Then
                    fila.Cells(Col_IdUsuarioModifica.Name).Value = VariablesBase.VariablesBase.IdPersona
                    fila.Cells(Col_FechaModificacion.Name).Value = DateTime.Now
                End If
            End If
        End If
    End Sub

    Private Sub Dgv_Acciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Acciones.KeyDown
        dtAcciones.AcceptChanges()
        If Dgv_Acciones.SelectedCells.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                Dgv_Acciones.Rows.RemoveAt(Dgv_Acciones.SelectedCells(0).RowIndex)
                dtAcciones.AcceptChanges()
                Dgv_Acciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End If
        End If
    End Sub


    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            Guardar()
            If Guardado Then
                Me.Close()
            End If
        End If
    End Sub

    Private Function Validar()
        If Cb_Sistema.SelectedIndex <= -1 OrElse Cb_Sistema.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar el sistema.", "No Conformidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cb_Sistema.Select()
            Return False
        End If
        If Cb_Tipo.SelectedIndex <= -1 OrElse Cb_Tipo.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar el tipo de No Conformidad.", "No Conformidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cb_Tipo.Select()
            Return False
        End If
        If Ck_ExistenNC.CheckState = CheckState.Indeterminate Then
            MessageBox.Show("Debe indicar si existen No Conformidades similares o que puedan ocurrir.", "No Conformidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Ck_ExistenNC.Select()
            Return False
        End If
        Return True
    End Function

    Private Sub Guardar()
        dtAcciones.AcceptChanges()
        For i As Integer = 0 To dtAcciones.Rows.Count - 1
            dtAcciones.Rows(i).Item(Col_Item.DataPropertyName) = i + 1
        Next
        Dim dtGuardaAcciones As DataTable = dtAcciones.Copy
        If dtGuardaAcciones.Columns.Contains(Col_UsuarioRegistra.DataPropertyName) Then
            dtGuardaAcciones.Columns.Remove(Col_UsuarioRegistra.DataPropertyName)
        End If
        If dtGuardaAcciones.Columns.Contains(Col_UsuarioModifica.DataPropertyName) Then
            dtGuardaAcciones.Columns.Remove(Col_UsuarioModifica.DataPropertyName)
        End If
        comando = New SqlCommand("dbo.GestionarNC_NoConformidad", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        Select Case TipoEdicion
            Case TiposEdicion.Crear
                comando.Parameters("@Accion").Value = 1
            Case TiposEdicion.Editar
                comando.Parameters("@Accion").Value = 2
            Case TiposEdicion.Cerrar
                comando.Parameters("@Accion").Value = 3
            Case Else
                comando.Parameters("@Accion").Value = DBNull.Value
        End Select
        comando.Parameters.Add("@IDNOCONFORMIDAD", SqlDbType.Int)
        If TipoEdicion <> TiposEdicion.Crear Then
            comando.Parameters("@IDNOCONFORMIDAD").Value = IdNoConformidad
        Else
            comando.Parameters("@IDNOCONFORMIDAD").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@SISTEMA", Cb_Sistema.SelectedValue)
        comando.Parameters.AddWithValue("@TIPONOCONFORMIDAD", Cb_Tipo.SelectedValue)
        comando.Parameters.Add("@FECHA", SqlDbType.Date)
        If Dtp_Fecha.Checked Then
            comando.Parameters("@FECHA").Value = Dtp_Fecha.Value
        Else
            comando.Parameters("@FECHA").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@LISTAORDENESDETRABAJO", Trim(Tx_OrdenTrabajo.Text))
        comando.Parameters.AddWithValue("@NUMEROREPORTE", Trim(Tx_NumeroReporte.Text))
        comando.Parameters.AddWithValue("@CONTRATO", Trim(Tx_Contrato.Text))
        comando.Parameters.AddWithValue("@NUMEROAUDITORIA", Trim(Tx_NumeroAuditoria.Text))
        comando.Parameters.AddWithValue("@PROCESO", Trim(Tx_Proceso.Text))
        comando.Parameters.AddWithValue("@DETECTOR", Trim(Tx_Detector.Text))
        comando.Parameters.AddWithValue("@FUENTE", Trim(Tx_Fuente.Text))
        comando.Parameters.AddWithValue("@REPRESENTANTEPROCESO", Trim(Tx_RepProc.Text))
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        comando.Parameters.AddWithValue("@REACCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Reaccion.Text))
        comando.Parameters.Add("@EXISTENSIMILARES", SqlDbType.Char, 1)
        Select Case Ck_ExistenNC.CheckState
            Case CheckState.Checked
                comando.Parameters("@EXISTENSIMILARES").Value = "S"
            Case CheckState.Unchecked
                comando.Parameters("@EXISTENSIMILARES").Value = "N"
            Case Else
                comando.Parameters("@EXISTENSIMILARES").Value = DBNull.Value
        End Select

        comando.Parameters.Add("@ANEXOANALISISCAUSAS", SqlDbType.VarBinary)
        comando.Parameters.Add("@NOMBREANEXOAC", SqlDbType.VarChar)
        If cargoAnexoAC Then
            comando.Parameters("@ANEXOANALISISCAUSAS").Value = archivoAnexoAC
            comando.Parameters("@NOMBREANEXOAC").Value = Tx_AnexoAC.Text
        ElseIf archivoAnexoAC IsNot Nothing Then
            comando.Parameters("@ANEXOANALISISCAUSAS").Value = DBNull.Value
            comando.Parameters("@NOMBREANEXOAC").Value = ""
        Else
            comando.Parameters("@ANEXOANALISISCAUSAS").Value = DBNull.Value
            comando.Parameters("@NOMBREANEXOAC").Value = DBNull.Value
        End If

        comando.Parameters.AddWithValue("@VERIFICACIONEFICACIA", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_VerificacionEficacia.Text))
        comando.Parameters.AddWithValue("@TablaACCIONES", dtGuardaAcciones)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
            Select Case comando.Parameters("@Mensaje").Value
                Case 1
                    MessageBox.Show("Se guardaron los cambios correctamente.", "Datos guardados", MessageBoxButtons.OK)
                    _guardado = True
                Case 2
                    MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Dgv_Acciones.CancelEdit()
        If TipoEdicion <> TiposEdicion.Ver AndAlso Not Guardado Then
            If MessageBox.Show("¿Desea salir sin guardar cambios?", "Salir", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Fr_NoConformidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        VariablesBase.VariablesBase.IdBaseSiscontrolActual = idBaseActual
    End Sub

    Public Function Anular() As Boolean
        If IdNoConformidad > 0 Then
            Dim dtVacio As New DataTable
            AplicarEsquemaTabla(dtVacio, Dgv_Acciones.Columns)
            If dtVacio.Columns.Contains(Col_UsuarioRegistra.DataPropertyName) Then
                dtVacio.Columns.Remove(Col_UsuarioRegistra.DataPropertyName)
            End If
            If dtVacio.Columns.Contains(Col_UsuarioModifica.DataPropertyName) Then
                dtVacio.Columns.Remove(Col_UsuarioModifica.DataPropertyName)
            End If

            comando = New SqlCommand("dbo.GestionarNC_NoConformidad", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@Accion", 4)
            comando.Parameters.AddWithValue("@IDNOCONFORMIDAD", IdNoConformidad)
            comando.Parameters.AddWithValue("@IDBASE", DBNull.Value)
            comando.Parameters.AddWithValue("@SISTEMA", DBNull.Value)
            comando.Parameters.AddWithValue("@TIPONOCONFORMIDAD", DBNull.Value)
            comando.Parameters.AddWithValue("@FECHA", DBNull.Value)
            comando.Parameters.AddWithValue("@LISTAORDENESDETRABAJO", DBNull.Value)
            comando.Parameters.AddWithValue("@NUMEROREPORTE", DBNull.Value)
            comando.Parameters.AddWithValue("@CONTRATO", DBNull.Value)
            comando.Parameters.AddWithValue("@NUMEROAUDITORIA", DBNull.Value)
            comando.Parameters.AddWithValue("@PROCESO", DBNull.Value)
            comando.Parameters.AddWithValue("@DETECTOR", DBNull.Value)
            comando.Parameters.AddWithValue("@FUENTE", DBNull.Value)
            comando.Parameters.AddWithValue("@REPRESENTANTEPROCESO", DBNull.Value)
            comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
            comando.Parameters.AddWithValue("@REACCION", DBNull.Value)
            comando.Parameters.AddWithValue("@EXISTENSIMILARES", DBNull.Value)
            comando.Parameters.AddWithValue("@ANEXOANALISISCAUSAS", DBNull.Value)
            comando.Parameters.AddWithValue("@NOMBREANEXOAC", DBNull.Value)
            comando.Parameters.AddWithValue("@VERIFICACIONEFICACIA", DBNull.Value)
            comando.Parameters.AddWithValue("@TablaACCIONES", dtVacio)
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
            If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
                Select Case comando.Parameters("@Mensaje").Value
                    Case 1
                        MessageBox.Show("Se guardaron los cambios correctamente.", "Datos guardados", MessageBoxButtons.OK)
                        Return True
                    Case 2
                        MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Case Else
                        MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                End Select
            Else
                MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("Debe indicar el registro de Material No Conforme que se va a anular.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Private Sub AplicarEsquemaTabla(dt As DataTable, dgvcc As DataGridViewColumnCollection)
        For Each col As DataGridViewColumn In dgvcc
            dt.Columns.Add(col.DataPropertyName)
        Next
    End Sub

End Class 'Fr_NoConformidad


Friend Class Fr_AgregarAcciones
    Inherits Form

    Public Acciones As String = ""
    Public Responsable As String = ""
    Public Aprueba As String = ""
    Public FechaPropuesta As DateTime?
    Public Seguimiento As String = ""
    Private WithEvents Pn_Controles As New Panel
    Private WithEvents Lb_TextoAcciones As New Label
    Private WithEvents Tx_Acciones As New TextBox
    Private WithEvents Lb_TextoResponsable As New Label
    Private WithEvents Tx_Responsable As New TextBox
    Private WithEvents Lb_TextoAprueba As New Label
    Private WithEvents Tx_Aprueba As New TextBox
    Private WithEvents Lb_TextoFecha As New Label
    Private WithEvents Dtp_Fecha As New DateTimePicker
    Private WithEvents Lb_TextoSeguimiento As New Label
    Private WithEvents Tx_Seguimiento As New TextBox
    Private WithEvents Flp_Botones As New FlowLayoutPanel
    Private WithEvents Bt_Aceptar As New Button
    Private WithEvents Bt_Cancelar As New Button


    Private Sub Fr_AgregarAcciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pn_Controles.SuspendLayout()
        Flp_Botones.SuspendLayout()
        Me.SuspendLayout()
        With Pn_Controles
            .Controls.Add(Me.Dtp_Fecha)
            .Controls.Add(Me.Tx_Seguimiento)
            .Controls.Add(Me.Tx_Aprueba)
            .Controls.Add(Me.Tx_Responsable)
            .Controls.Add(Me.Tx_Acciones)
            .Controls.Add(Me.Lb_TextoAcciones)
            .Controls.Add(Me.Lb_TextoResponsable)
            .Controls.Add(Me.Lb_TextoSeguimiento)
            .Controls.Add(Me.Lb_TextoFecha)
            .Controls.Add(Me.Lb_TextoAprueba)
            .Dock = DockStyle.Fill
            .Location = New Point(0, 0)
            .Name = "Pn_Controles"
            .Size = New Size(376, 175)
            .TabIndex = 0
        End With
        With Flp_Botones
            .BackColor = SystemColors.ControlDark
            .Controls.Add(Me.Bt_Cancelar)
            .Controls.Add(Me.Bt_Aceptar)
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Location = New Point(0, 175)
            .Name = "Flp_Botones"
            .Size = New Size(376, 30)
            .TabIndex = 1
        End With
        With Bt_Cancelar
            .Location = New Point(298, 3)
            .Name = "Bt_Cancelar"
            .Size = New Size(75, 23)
            .TabIndex = 1
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With
        With Bt_Aceptar
            .Location = New Point(217, 3)
            .Name = "Bt_Aceptar"
            .Size = New Size(75, 23)
            .TabIndex = 0
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With
        With Lb_TextoAcciones
            .AutoSize = True
            .Location = New Point(40, 15)
            .Name = "Lb_TextoAcciones"
            .Size = New Size(43, 13)
            .TabIndex = 0
            .Text = "Acciones:"
        End With
        With Lb_TextoResponsable
            .AutoSize = True
            .Location = New Point(22, 57)
            .Name = "Lb_TextoResponsable"
            .Size = New Size(72, 13)
            .TabIndex = 2
            .Text = "Responsable:"
        End With
        With Lb_TextoAprueba
            .AutoSize = True
            .Location = New Point(20, 83)
            .Name = "Lb_TextoAprueba"
            .Size = New Size(74, 13)
            .TabIndex = 4
            .Text = "Aprobado por:"
        End With
        With Lb_TextoFecha
            .AutoSize = True
            .Location = New Point(3, 109)
            .Name = "Lb_TextoFecha"
            .Size = New Size(91, 13)
            .TabIndex = 6
            .Text = "Fecha Propuesta:"
        End With
        With Lb_TextoSeguimiento
            .AutoSize = True
            .Location = New Point(26, 135)
            .Name = "Lb_TextoSeguimiento"
            .Size = New Size(68, 13)
            .TabIndex = 8
            .Text = "Seguimiento:"
        End With
        With Tx_Acciones
            .Location = New Point(97, 12)
            .MaxLength = 200
            .Multiline = True
            .Name = "Tx_Acciones"
            .Size = New Size(267, 36)
            .TabIndex = 1
        End With
        With Tx_Responsable
            .Location = New Point(97, 54)
            .MaxLength = 100
            .Name = "Tx_Responsable"
            .Size = New Size(267, 20)
            .TabIndex = 3
        End With
        With Tx_Aprueba
            .Location = New Point(97, 80)
            .MaxLength = 100
            .Name = "Tx_Aprueba"
            .Size = New Size(267, 20)
            .TabIndex = 5
        End With
        With Tx_Seguimiento
            .Location = New Point(97, 132)
            .MaxLength = 200
            .Multiline = True
            .Name = "Tx_Seguimiento"
            .Size = New Size(267, 36)
            .TabIndex = 9
        End With
        With Dtp_Fecha
            .Format = DateTimePickerFormat.[Short]
            .Location = New Point(97, 106)
            .Name = "Dtp_Fecha"
            .ShowCheckBox = True
            .Size = New Size(112, 20)
            .TabIndex = 7
        End With
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(376, 205)
        'Me.Size = New Size(392, 244)
        Me.Controls.Add(Me.Pn_Controles)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarAcciones"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Agregar Acciones"
        Pn_Controles.ResumeLayout(False)
        Pn_Controles.PerformLayout()
        Flp_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Acciones = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Acciones.Text)
        Responsable = Trim(Tx_Responsable.Text)
        Aprueba = Trim(Tx_Aprueba.Text)
        If Dtp_Fecha.Checked Then
            FechaPropuesta = Dtp_Fecha.Value
        End If
        Seguimiento = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Seguimiento.Text)
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class 'Fr_AgregarAcciones

Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property
End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null.
        If Me.Value Is Nothing OrElse Me.Value Is DBNull.Value Then 'Se añadió condición para DBNull.Value
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property
End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is 
                ' null, empty, or not in the format of a date.
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default
                ' value so we're not left with a null value.
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
End Class