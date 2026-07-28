Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_AsociarUsuarioConsulta

    Dim dtUsuarioConsulta As New DataTable

    Private Sub Comportamiento_Predeterminado()
        Dgv_PermisosConsultas.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_PermisosConsultas.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub

    Private Sub Fr_AsociarUsuarioConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaInicial()
        Comportamiento_Predeterminado()
    End Sub

    Private Sub CargaInicial()
        Try
            Dgv_PermisosConsultas.DataSource = Nothing
            Me.Cu_BuscarPersona.CargarDatos()
            Me.Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Bt_CargarConsultas_Click(sender As Object, e As EventArgs) Handles Bt_CargarConsultas.Click
        Pn_BusquedaUsuario.Enabled = False
        Bt_Cancelar.Enabled = True
        Bt_Guardar.Enabled = True

        If Me.Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el usuario del cual requiere cargar los permisos de consultas.", MsgBoxStyle.Information, "Seleccionar Usuario")
            Exit Sub
        Else
            Dim Comando As New SqlClient.SqlCommand("dbo.GestionarUsuarioConsulta")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@ACCION", 1)
            Comando.Parameters.AddWithValue("@IDPERSONA", Me.Cu_BuscarPersona.Cb_Persona.SelectedValue)
            Dim TablaPermisosVacia As New DataTable
            TablaPermisosVacia.Columns.Add("CODIGOCONSULTASQL")
            TablaPermisosVacia.Columns.Add("IDPERSONA")
            TablaPermisosVacia.Columns.Add("TIENEPERMISO")
            Comando.Parameters.AddWithValue("@TablaUsuarioConsulta", TablaPermisosVacia)
            Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Comando.Connection = conn
            dtUsuarioConsulta.Clear()
            Dim da As New SqlClient.SqlDataAdapter
            da = New SqlClient.SqlDataAdapter(Comando)
            Try
                conn.Open()
                da.Fill(dtUsuarioConsulta)
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try
            Dgv_PermisosConsultas.DataSource = dtUsuarioConsulta
            '
            ' Esconder la columna IDCONSULTA
            '
            Dgv_PermisosConsultas.Columns("IDCONSULTA").Visible = False

            Pn_BusquedaUsuario.Enabled = False
            Bt_Cancelar.Enabled = True
            Bt_Guardar.Enabled = True
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If MsgBox("¿Seguro que desea aplicar los cambios realizados?", MsgBoxStyle.YesNo, "Realizar cambios") = MsgBoxResult.No Then
            Exit Sub
        End If
        '
        ' Arreglo que incluye únicamente las filas con permisos asignados de "Dgv_PermisosConsultas".
        '
        Dim filas() As DataRow
        filas = Dgv_PermisosConsultas.DataSource.Select("TIENEPERMISO=True")
        '
        ' Tabla a la cual se copian las filas seleccionadas de "Dgv_PermisosConsultas".
        ' Es necesaria para enviarse como parámetro en el Procedimiento Almacenado en lugar del arreglo "filas".
        '
        Dim TablaUsuarioConsulta As New DataTable
        TablaUsuarioConsulta.Columns.Add("CODIGOCONSULTASQL")
        TablaUsuarioConsulta.Columns.Add("IDPERSONA")
        TablaUsuarioConsulta.Columns.Add("TIENEPERMISO")
        Dim fila As DataRow
        For i = 0 To filas.Count - 1
            Dim filausuario As DataRow
            filausuario = filas(i)
            fila = TablaUsuarioConsulta.NewRow
            fila("CODIGOCONSULTASQL") = filausuario("IDCONSULTA")
            fila("IDPERSONA") = Me.Cu_BuscarPersona.Cb_Persona.SelectedValue
            fila("TIENEPERMISO") = If(filausuario("TIENEPERMISO") IsNot DBNull.Value, filausuario("TIENEPERMISO"), 0)
            TablaUsuarioConsulta.Rows.Add(fila)
        Next

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarUsuarioConsulta")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@ACCION", 2)
        Comando.Parameters.AddWithValue("@TablaUsuarioConsulta", TablaUsuarioConsulta)
        Comando.Parameters.AddWithValue("@IDPERSONA", Me.Cu_BuscarPersona.Cb_Persona.SelectedValue)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Comando.Connection = conn
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try

        If MsgBox("Se actualizaron correctamente los permisos del usuario " + Trim(Me.Cu_BuscarPersona.Cb_Persona.Text) + "." + Environment.NewLine _
                  + "¿Desea salir?", MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
            Close()
        Else
            Pn_BusquedaUsuario.Enabled = True
            Bt_Guardar.Enabled = False
            Bt_Cancelar.Enabled = False
            dtUsuarioConsulta.Clear()
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Pn_BusquedaUsuario.Enabled = True
        Bt_Cancelar.Enabled = False
        Bt_Guardar.Enabled = False
        dtUsuarioConsulta.Clear()
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub

    Private Sub Dgv_PermisosConsultas_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_PermisosConsultas.SelectionChanged
        Tx_NombreConsulta.Text = ""
        If Dgv_PermisosConsultas.SelectedRows.Count > 0 Then
            If Dgv_PermisosConsultas.SelectedRows(0).Cells("CONSULTA").Value <> Nothing Then
                If Dgv_PermisosConsultas.SelectedRows(0).Cells("CONSULTA").Value <> "" Then
                    Tx_NombreConsulta.AppendText("Consulta: " + Trim(Dgv_PermisosConsultas.SelectedRows(0).Cells("CONSULTA").Value) + Environment.NewLine)
                    Tx_NombreConsulta.AppendText("Módulo: " + Trim(Dgv_PermisosConsultas.SelectedRows(0).Cells("MODULO").Value) + Environment.NewLine)
                    Dim tienePermiso As String = If(Dgv_PermisosConsultas.SelectedRows(0).Cells("TIENEPERMISO").Value = 1, "Sí", "No")
                    Tx_NombreConsulta.AppendText("Tiene permiso: " + tienePermiso)
                Else
                    Tx_NombreConsulta.Text = ""
                End If
            Else
                Tx_NombreConsulta.Text = ""
            End If
        Else
            Tx_NombreConsulta.Text = ""
        End If
    End Sub

    Private Sub Dgv_PermisosConsultas_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Dgv_PermisosConsultas.MouseClick
        If Bt_Guardar.Enabled = True And e.Button = MouseButtons.Right Then
            Dim opciones As ContextMenuStrip = Cms_opciones

            Dim mouseColumna As Integer = Dgv_PermisosConsultas.HitTest(e.X, e.Y).ColumnIndex

            If mouseColumna = Dgv_PermisosConsultas.Columns("TIENEPERMISO").Index Then
                opciones.Show(Dgv_PermisosConsultas, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Tsmi_MarcarTodas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Tsmi_MarcarTodas.Click
        Try
            If Bt_Guardar.Enabled = False Then
                Exit Sub
            End If

            Dim i As Integer
            Me.Cursor = Cursors.WaitCursor
            Try
                For i = 0 To Dgv_PermisosConsultas.RowCount - 1
                    Dgv_PermisosConsultas.Rows(i).Cells("TIENEPERMISO").Value = 1
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
            Dgv_PermisosConsultas.ClearSelection()
            Dgv_PermisosConsultas.RefreshEdit()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Private Sub Tsmi_DemarcarTodas_Click(sender As Object, e As EventArgs) Handles Tsmi_DemarcarTodas.Click
        Try
            If Bt_Guardar.Enabled = False Then
                Exit Sub
            End If

            Dim i As Integer
            Me.Cursor = Cursors.WaitCursor
            Try
                For i = 0 To Dgv_PermisosConsultas.RowCount - 1
                    Dgv_PermisosConsultas.Rows(i).Cells("TIENEPERMISO").Value = 0
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
            Dgv_PermisosConsultas.ClearSelection()
            Dgv_PermisosConsultas.RefreshEdit()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Try
            filas = Cu_BuscarPersona.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersona.Tx_TextoCódigo.Text).ToString + "'")
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                Me.Cu_BuscarPersona.Cb_Persona.SelectedValue = fila("IDPERSONA")
            Else
                MsgBox("Esta identificación no esta registrada o no esta asociada a una bodega", MsgBoxStyle.Critical, "No se encuentra")
            End If
        Catch ex As Exception
            Me.Cu_BuscarPersona.Tx_TextoCódigo.Text = ""
        End Try
    End Sub
End Class