Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_AsociarUsuarioBaseHse
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private dtVacio As New DataTable

    Private Sub Fr_UsuarioBaseHse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
        CargarBases()
        dtVacio.Columns.Add("IDPERSONA")
        dtVacio.Columns.Add("IDDEPENDENCIA")
        dtVacio.Columns.Add("ASOCIADO")
        dtVacio.Columns.Add("USUARIO")
    End Sub
    Private Sub CargarUsuarios()
        CuBP_Usuario.CargarDatos()
        CuBP_Usuario.CargarCajaTexto()
    End Sub

    Private Sub CargarBases()
        Dim comando As New SqlCommand("SELECT B.IDBASEHSE, B.ABREVIATURABASE, B.NOMBREBASE fROM HSE_MA_BASE AS B", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtBases = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtBases)
            conexion.Close()
            Cb_Bases.DataSource = dtBases
            Cb_Bases.DisplayMember = "ABREVIATURABASE"
            Cb_Bases.ValueMember = "IDBASEHSE"
            Cb_Bases.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HabilitarControles()
        CuBP_Usuario.Enabled = True
        Cb_Bases.Enabled = True
        Bt_CargarUsuarios.Enabled = True
        Bt_CargarBases.Enabled = True
        DirectCast(Dgv_Pertenencia.DataSource, DataTable).Clear()
        Dgv_Pertenencia.Enabled = False
        Lb_Estado.Visible = False
        Bt_Guardar.Enabled = False
        Bt_Cancelar.Enabled = False
    End Sub
    Private Sub DeshabilitarControles()
        CuBP_Usuario.Enabled = False
        Cb_Bases.Enabled = False
        Bt_CargarUsuarios.Enabled = False
        Bt_CargarBases.Enabled = False
        Dgv_Pertenencia.Enabled = True
        Bt_Guardar.Enabled = True
        Bt_Cancelar.Enabled = True
    End Sub

    Private Sub Bt_CargarBases_Click(sender As Object, e As EventArgs) Handles Bt_CargarBases.Click
        If CuBP_Usuario.Cb_Persona.SelectedIndex > -1 Then
            Cb_Bases.SelectedIndex = -1
            CargarBases(CuBP_Usuario.Cb_Persona.SelectedValue)
            OrganizarColumnas(1)
            DeshabilitarControles()
        Else
            MessageBox.Show("Seleccione el usuario a gestionar", "No se ha seleccionado usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CargarBases(idPersona As Integer)
        Dim comando As New SqlCommand("dbo.GestionarUsuariosBasesHSE", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", 1) 'Dependencias por usuario.
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        comando.Parameters.AddWithValue("@IDBASEHSE", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@TablaUSUARIODEPENDENCIA", dtVacio)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtDependenciasUsuario = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtDependenciasUsuario)
            conexion.Close()
            Dgv_Pertenencia.DataSource = dtDependenciasUsuario
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Bases.SelectedIndexChanged
        'CargarBases()
    End Sub

    Private Sub Bt_CargarUsuarios_Click(sender As Object, e As EventArgs) Handles Bt_CargarUsuarios.Click
        If Cb_Bases.SelectedIndex > -1 Then
            CuBP_Usuario.Cb_Persona.SelectedIndex = -1
            CargarUsuarios(Cb_Bases.SelectedValue)
            OrganizarColumnas(2)
            DeshabilitarControles()
            Lb_Estado.Text = "Cantidad de usuarios: " & Dgv_Pertenencia.DataSource.Rows.Count
            Lb_Estado.Visible = True
        Else
            MessageBox.Show("Seleccione la dependencia a gestionar", "No se ha seleccionado dependencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' Cargar en la rejilla el listado de usuarios de la base.
    Private Sub CargarUsuarios(idBase As Integer)
        Dim comando As New SqlCommand("dbo.GestionarUsuariosBasesHSE", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", 2) 'Usuarios por base.
        comando.Parameters.AddWithValue("@IDPERSONA", DBNull.Value)
        comando.Parameters.AddWithValue("@IDBASEHSE", idBase)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@TablaUSUARIODEPENDENCIA", dtVacio)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtUsuariosBase = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtUsuariosBase)
            conexion.Close()
            Dgv_Pertenencia.DataSource = dtUsuariosBase
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' Habilita o deshabilita las columnas que se deben mostrar en la rejilla según el tipo de gestión.
    Private Sub OrganizarColumnas(tipo As Integer)
        Select Case tipo
            Case 1 'Cargar dependencias por usuario.
                For i = 0 To Dgv_Pertenencia.ColumnCount - 1
                    Select Case Dgv_Pertenencia.Columns(i).Name
                        Case Col_Base.Name, Col_Asociado.Name, Col_Nombre.Name
                            Dgv_Pertenencia.Columns(i).Visible = True
                        Case Else
                            Dgv_Pertenencia.Columns(i).Visible = False
                    End Select
                Next i
                Dgv_Pertenencia.AutoResizeColumns()
            Case 2 'Cargar usuarios por dependencia.
                For i = 0 To Dgv_Pertenencia.ColumnCount - 1
                    Select Case Dgv_Pertenencia.Columns(i).Name
                        Case Col_Nombre.Name, Col_Asociado.Name
                            Dgv_Pertenencia.Columns(i).Visible = True
                        Case Else
                            Dgv_Pertenencia.Columns(i).Visible = False
                    End Select
                Next i
                Dgv_Pertenencia.AutoResizeColumns()
        End Select
    End Sub



    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If Validar() Then
            Dim dtPermisos As DataTable = Dgv_Pertenencia.DataSource.Copy
            dtPermisos.Columns.Add("USUARIO")
            If dtPermisos.Columns.Contains(Col_Base.DataPropertyName) Then
                dtPermisos.Columns.Remove(Col_Base.DataPropertyName)
            End If
            If dtPermisos.Columns.Contains(Col_Nombre.DataPropertyName) Then
                dtPermisos.Columns.Remove(Col_Nombre.DataPropertyName)
            End If

            For i As Integer = 0 To dtPermisos.Rows.Count - 1
                dtPermisos.Rows(i).Item("USUARIO") = DBNull.Value
            Next

            Dim comando As New SqlCommand("dbo.GestionarUsuariosBasesHSE", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@Accion", 3) 'Guardar permisos
            If CuBP_Usuario.Cb_Persona.SelectedIndex > -1 Then
                comando.Parameters.AddWithValue("@IDPERSONA", CuBP_Usuario.Cb_Persona.SelectedValue)
                comando.Parameters.AddWithValue("@IDBASEHSE", DBNull.Value)
            ElseIf Cb_Bases.SelectedIndex > -1 Then
                comando.Parameters.AddWithValue("@IDPERSONA", DBNull.Value)
                comando.Parameters.AddWithValue("@IDBASEHSE", Cb_Bases.SelectedValue)
            End If
            comando.Parameters.AddWithValue("@IDUSUARIO", DBNull.Value)
            comando.Parameters.AddWithValue("@TablaUSUARIODEPENDENCIA", dtPermisos)
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
                If MessageBox.Show("Datos guardados." & Environment.NewLine & "¿Desea continuar gestionando usuarios?", "Continuar", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Close()
                Else
                    HabilitarControles()
                End If
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function Validar() As Boolean
        'Cantidad de dependencias
        If CuBP_Usuario.Cb_Persona.SelectedIndex > -1 Then
            Dim contBases As Integer = 0
            For Each r As DataGridViewRow In Dgv_Pertenencia.Rows
                If r.Cells(Col_Asociado.Name).Value = "S" Then
                    contBases += 1
                End If
            Next
            If contBases = 0 Then
                If MessageBox.Show("El usuario no tiene ninguna base asociada." & Environment.NewLine & "¿Desea continuar?", "Ninguna base seleccionada", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Validar = False
                    Exit Function
                End If
            End If
        End If
        Validar = True
    End Function

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        HabilitarControles()
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Try
            Dim filas() As DataRow = CuBP_Usuario.DT_BUSCARPERSONA.Select("IDENTIFICACION = '" & (CuBP_Usuario.Tx_TextoCódigo.Text) & "'")
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                CuBP_Usuario.Cb_Persona.SelectedValue = fila("IDPERSONA")
            Else
                MessageBox.Show("Este número de identificación no esta registrado.", "No se encuentra la identificación", MessageBoxButtons.OK, MessageBoxIcon.Error) 'o no esta asociada a una bodega
            End If
        Catch
            CuBP_Usuario.Tx_TextoCódigo.Text = ""
        End Try
    End Sub

    Private Sub MarcarTodas_Click(sender As Object, e As EventArgs) Handles MarcarTodas.Click
        Try
            If Not Bt_Guardar.Enabled Then
                Exit Sub
            End If
            Dim Nombre_Columna As String = ""
            Dim Indice_Columna As Integer = -1
            Nombre_Columna = Dgv_Pertenencia.Columns(Dgv_Pertenencia.CurrentCell.ColumnIndex).Name
            Indice_Columna = Dgv_Pertenencia.CurrentCell.ColumnIndex
            If Nombre_Columna = Col_Asociado.Name Then
                If MessageBox.Show("¿Desea marcar todas las casillas?", "Marcar todas", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To Dgv_Pertenencia.RowCount - 1
                    Dgv_Pertenencia.Item(Indice_Columna, i).Value = "S"
                Next
                Dgv_Pertenencia.ClearSelection()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DemarcarTodas_Click(sender As Object, e As EventArgs) Handles DemarcarTodas.Click
        Try
            If Not Bt_Guardar.Enabled Then
                Exit Sub
            End If
            Dim Nombre_Columna As String = ""
            Dim Indice_Columna As Integer = -1
            Nombre_Columna = Dgv_Pertenencia.Columns(Dgv_Pertenencia.CurrentCell.ColumnIndex).Name
            Indice_Columna = Dgv_Pertenencia.CurrentCell.ColumnIndex
            If Nombre_Columna = Col_Asociado.Name Then
                If MessageBox.Show("¿Desea desmarcar todas las casillas?", "Desmarcar todas", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To Dgv_Pertenencia.RowCount - 1
                    Dgv_Pertenencia.Item(Indice_Columna, i).Value = "N"
                Next
                Dgv_Pertenencia.ClearSelection()
                Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cms_opciones_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cms_opciones.Opening
        Dim Nombre_Columna As String = ""
        Nombre_Columna = Dgv_Pertenencia.Columns(Dgv_Pertenencia.CurrentCell.ColumnIndex).Name.ToString
        If Nombre_Columna = Col_Asociado.Name Then
            Cms_opciones.Enabled = True
        Else
            Cms_opciones.Enabled = False
        End If
    End Sub
End Class