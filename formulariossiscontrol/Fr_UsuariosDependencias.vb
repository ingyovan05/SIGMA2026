Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_UsuarioDependencia
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private dtVacio As New DataTable

    Private Sub Fr_UsuarioDependencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarUsuarios()
        CargarBases()
        dtVacio.Columns.Add("IDPERSONA")
        dtVacio.Columns.Add("IDDEPENDENCIA")
        dtVacio.Columns.Add("ASOCIADO")
        dtVacio.Columns.Add("USUARIO")
    End Sub

    Private Sub HabilitarControles()
        CuBP_Usuario.Enabled = True
        Cb_Bases.Enabled = True
        Cb_Dependencias.Enabled = True
        Bt_CargarUsuarios.Enabled = True
        Bt_CargarDependencias.Enabled = True
        DirectCast(Dgv_Pertenencia.DataSource, DataTable).Clear()
        Dgv_Pertenencia.Enabled = False
        Lb_Estado.Visible = False
        Bt_Guardar.Enabled = False
        Bt_Cancelar.Enabled = False
    End Sub

    Private Sub DeshabilitarControles()
        CuBP_Usuario.Enabled = False
        Cb_Bases.Enabled = False
        Cb_Dependencias.Enabled = False
        Bt_CargarUsuarios.Enabled = False
        Bt_CargarDependencias.Enabled = False
        Dgv_Pertenencia.Enabled = True
        Bt_Guardar.Enabled = True
        Bt_Cancelar.Enabled = True
    End Sub

    Private Sub CargarUsuarios()
        CuBP_Usuario.CargarDatos()
        CuBP_Usuario.CargarCajaTexto()
    End Sub

    Private Sub CargarBases()
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 2)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtBases = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtBases)
            conexion.Close()
            Cb_Bases.DataSource = dtBases
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarDependencias()
        If Cb_Bases.SelectedIndex > -1 Then
            Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@ACCION", 3)
            comando.Parameters.AddWithValue("@IDBASESISCONTROL", Cb_Bases.SelectedValue)
            comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtDependencias = New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtDependencias)
                conexion.Close()
                Cb_Dependencias.DataSource = dtDependencias
            Catch ex As Exception
                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Bt_CargarDependencias_Click(sender As Object, e As EventArgs) Handles Bt_CargarDependencias.Click
        If CuBP_Usuario.Cb_Persona.SelectedIndex > -1 Then
            Cb_Bases.SelectedIndex = -1
            Cb_Dependencias.SelectedIndex = -1
            CargarDependencias(CuBP_Usuario.Cb_Persona.SelectedValue)
            OrganizarColumnas(1)
            DeshabilitarControles()
        Else
            MessageBox.Show("Seleccione el usuario a gestionar", "No se ha seleccionado usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Cargar en la rejilla el listado de dependencias del usuario.
    ''' </summary>
    ''' <param name="idPersona">Usuario del cual se cargan las dependencias.</param>
    Private Sub CargarDependencias(idPersona As Integer)
        Dim comando As New SqlCommand("dbo.GestionarUsuariosDependencias", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", 1) 'Dependencias por usuario.
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
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
        CargarDependencias()
    End Sub

    Private Sub Cb_Dependencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Dependencias.SelectedIndexChanged

    End Sub

    Private Sub Bt_CargarUsuarios_Click(sender As Object, e As EventArgs) Handles Bt_CargarUsuarios.Click
        If Cb_Dependencias.SelectedIndex > -1 Then
            CuBP_Usuario.Cb_Persona.SelectedIndex = -1
            CargarUsuarios(Cb_Dependencias.SelectedValue)
            OrganizarColumnas(2)
            DeshabilitarControles()
            Lb_Estado.Text = "Cantidad de usuarios: " & Dgv_Pertenencia.DataSource.Rows.Count
            Lb_Estado.Visible = True
        Else
            MessageBox.Show("Seleccione la dependencia a gestionar", "No se ha seleccionado dependencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>
    ''' Cargar en la rejilla el listado de usuarios de la dependencia.
    ''' </summary>
    ''' <param name="idDependencia">Dependencia de la cual se cargan los usuarios.</param>
    Private Sub CargarUsuarios(idDependencia As Integer)
        Dim comando As New SqlCommand("dbo.GestionarUsuariosDependencias", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Accion", 2) 'Usuarios por dependencia.
        comando.Parameters.AddWithValue("@IDPERSONA", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", idDependencia)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@TablaUSUARIODEPENDENCIA", dtVacio)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtUsuariosDependencia = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtUsuariosDependencia)
            conexion.Close()
            Dgv_Pertenencia.DataSource = dtUsuariosDependencia
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If Validar() Then
            Dim dtPermisos As DataTable = Dgv_Pertenencia.DataSource.Copy
            If dtPermisos.Columns.Contains(Col_Base.DataPropertyName) Then
                dtPermisos.Columns.Remove(Col_Base.DataPropertyName)
            End If
            If dtPermisos.Columns.Contains(Col_Dependencia.DataPropertyName) Then
                dtPermisos.Columns.Remove(Col_Dependencia.DataPropertyName)
            End If
            If dtPermisos.Columns.Contains(Col_Nombre.DataPropertyName) Then
                dtPermisos.Columns.Remove(Col_Nombre.DataPropertyName)
            End If
            Dim comando As New SqlCommand("dbo.GestionarUsuariosDependencias", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@Accion", 3) 'Guardar permisos
            If CuBP_Usuario.Cb_Persona.SelectedIndex > -1 Then
                comando.Parameters.AddWithValue("@IDPERSONA", CuBP_Usuario.Cb_Persona.SelectedValue)
                comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
            ElseIf Cb_Dependencias.SelectedIndex > -1 Then
                comando.Parameters.AddWithValue("@IDPERSONA", DBNull.Value)
                comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencias.SelectedValue)
            End If
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
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
            Dim contBasePpal As Integer = 0
            Dim contDependencias As Integer = 0
            For Each r As DataGridViewRow In Dgv_Pertenencia.Rows
                If r.Cells(Col_EsBasePrincipal.Name).Value = "S" Then
                    contBasePpal += 1
                End If
                If r.Cells(Col_Asociado.Name).Value = "S" Then
                    contDependencias += 1
                End If
            Next
            If contBasePpal = 0 Then
                MessageBox.Show("El usuario no tiene ninguna dependencia seleccionada como base principal.", "Seleccionar base principal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Validar = False
                Exit Function
            ElseIf contBasePpal > 1 Then
                MessageBox.Show("El usuario tiene más de una dependencia asociada.", "Seleccionar sólo una base principal", MessageBoxButtons.OK)
                Validar = False
                Exit Function
            End If
            If contDependencias = 0 Then
                If MessageBox.Show("El usuario no tiene ninguna dependencia asociada." & Environment.NewLine & "¿Desea continuar?", "Ninguna dependencia seleccionada", MessageBoxButtons.YesNo) = DialogResult.No Then
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

    ''' <summary>
    ''' Selecciona el registro en el listado desplegable con el valor ingresado en la caja de texto.
    ''' </summary>
    ''' <param name="NombreComponente">Control de usuario de búsqueda de personas que posee la caja de texto</param>
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

    ''' <summary>
    ''' Habilita o deshabilita las columnas que se deben mostrar en la rejilla según el tipo de gestión.
    ''' </summary>
    ''' <param name="tipo">Tipo de gestión. 1: cargar dependencias por usuario, 2: cargar usuarios por dependencia.</param>
    Private Sub OrganizarColumnas(tipo As Integer)
        Select Case tipo
            Case 1 'Cargar dependencias por usuario.
                For i = 0 To Dgv_Pertenencia.ColumnCount - 1
                    Select Case Dgv_Pertenencia.Columns(i).Name
                        Case Col_Base.Name, Col_Dependencia.Name, Col_Asociado.Name, Col_EsBasePrincipal.Name
                            Dgv_Pertenencia.Columns(i).Visible = True
                        Case Else
                            Dgv_Pertenencia.Columns(i).Visible = False
                    End Select
                Next i
                Dgv_Pertenencia.AutoResizeColumns()
            Case 2 'Cargar usuarios por dependencia.
                For i = 0 To Dgv_Pertenencia.ColumnCount - 1
                    Select Case Dgv_Pertenencia.Columns(i).Name
                        Case Col_Nombre.Name, Col_Asociado.Name, Col_EsBasePrincipal.Name
                            Dgv_Pertenencia.Columns(i).Visible = True
                        Case Else
                            Dgv_Pertenencia.Columns(i).Visible = False
                    End Select
                Next i
                Dgv_Pertenencia.AutoResizeColumns()
        End Select
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
        Nombre_Columna = Dgv_Pertenencia.Columns(Dgv_Pertenencia.CurrentCell.ColumnIndex).Name
        If Nombre_Columna = Col_Asociado.Name Then
            Cms_opciones.Enabled = True
        Else
            Cms_opciones.Enabled = False
        End If
    End Sub
End Class