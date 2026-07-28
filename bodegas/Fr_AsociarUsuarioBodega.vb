Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_AsociarUsuarioBodega

    'Dim dsbodega As New DatosBodegas.Ds_Bodega
    'Dim adapbodega As New DatosBodegas.Ds_BodegaTableAdapters.BODEGATableAdapter
    Dim datas As New DataSet
    Dim dsCargar As New DataSet
    Private bddatos As New FuncionesBase.ClaseCargarMaestras


    Private Sub Fr_AsociarUsuarioBodega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaInicial()
        Comportamiento_Predeterminado()
    End Sub


    Private Sub CargaInicial()

        'Me.sc_DependenciaTableAdapter.Fill(DsSobre.SC_DEPENDENCIA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.Cb_Dependencia.DataSource = Me.DsSobre.SC_DEPENDENCIA
        'Me.Cb_Dependencia.DataSource = Me.dsCargar.Tables(0)
  

        Try
            dsCargar = bddatos.CargarMaestrasMateriales(9, VariablesBase.VariablesBase.IdBodegaActual, VariablesBase.VariablesBase.IdBodegaActual, 1)
            'Me.Dgv_UsuarioBodega.DataSource = Nothing
            'Me.adapbodega.Fill(dsbodega.BODEGA)
            'Me.Cb_BodegaAbreviatura.DataSource = dsbodega.BODEGA
            Me.Cb_BodegaAbreviatura.DataSource = Me.dsCargar.Tables(0)
            Me.Cb_BodegaAbreviatura.DisplayMember = "ABREVIATURA"
            Me.Cb_BodegaAbreviatura.ValueMember = "IDBODEGA"
            Me.Cb_BodegaAbreviatura.SelectedIndex = -1
            'Me.Cb_Bodega.DataSource = dsbodega.BODEGA
            Me.Cb_Bodega.DataSource = Me.dsCargar.Tables(0)
            Me.Cb_Bodega.DisplayMember = "NOMBRE"
            Me.Cb_Bodega.ValueMember = "IDBODEGA"
            Me.Cb_Bodega.SelectedIndex = -1

            Me.Cu_BuscarPersona.CargarDatos()
            Me.Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Btn_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cerrar.Click
        Me.Close()
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_UsuarioBodega.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_UsuarioBodega.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Pn_Encabezado.Enabled = True
        Me.Btn_Cancelar.Enabled = False
        Me.Btn_Guardar.Enabled = False
        Me.datas.Tables(0).Clear()
        Me.Lb_Mensaje.Visible = False
    End Sub

    Dim TipoActualizacion As Integer = 0


    Private Sub Bt_CargarBodegasxUsuario_Click(sender As Object, e As EventArgs) Handles Bt_CargarBodegasxUsuario.Click
        Try
            If Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la persona a la cual requiere cargar sus bodegas asociadas", MsgBoxStyle.Information, "Seleccionar Bodega")
                Exit Sub
            Else
                TipoActualizacion = 2
                Dim Comando As New SqlClient.SqlCommand("dbo.GestionarPermisosBodega")
                Comando.CommandType = CommandType.StoredProcedure
                Comando.Parameters.AddWithValue("@accion", 1)
                Comando.Parameters.AddWithValue("@idpersona", Me.Cu_BuscarPersona.Cb_Persona.SelectedValue)
                Comando.Parameters.AddWithValue("@idbodega", -1)
                Dim TablaPermisoBodega As New DataTable
                TablaPermisoBodega.Columns.Add("IDPERSONA")
                TablaPermisoBodega.Columns.Add("PERSONA")
                TablaPermisoBodega.Columns.Add("ABREVIATURA")
                TablaPermisoBodega.Columns.Add("IDBODEGA")
                TablaPermisoBodega.Columns.Add("BODEGA")
                TablaPermisoBodega.Columns.Add("ASOCIADO")
                TablaPermisoBodega.Columns.Add("USUARIO")
                TablaPermisoBodega.Columns.Add("BASE")
                TablaPermisoBodega.Columns.Add("ESTADO")
                TablaPermisoBodega.Columns.Add("COMPRADOR")
                Comando.Parameters.AddWithValue("@TablaPermisoBodega", TablaPermisoBodega)
                Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                conn.Open()
                Comando.Connection = conn
                datas.Clear()
                Dim da As New SqlClient.SqlDataAdapter
                da = New SqlClient.SqlDataAdapter(Comando)
                da.Fill(datas)
                conn.Close()
                Me.Dgv_UsuarioBodega.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
                Me.Dgv_UsuarioBodega.DataSource = datas.Tables(0)
                Me.Dgv_UsuarioBodega.CurrentCell = Dgv_UsuarioBodega.Rows(0).Cells(2)
                CargarFormatoDatagrid(1)
                Me.Pn_Encabezado.Enabled = False
                Me.Btn_Cancelar.Enabled = True
                Me.Btn_Guardar.Enabled = True
                Me.Lb_Mensaje.Text = "Total bodegas: " + datas.Tables(0).Rows.Count().ToString
                Me.Lb_Mensaje.Visible = Visible
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CargarFormatoDatagrid(ByVal TIPO As Integer)

        Select Case TIPO
            Case 1 'Cargar formato de bodegas asociado a usuario
                For i = 0 To Dgv_UsuarioBodega.ColumnCount - 1
                    Select Case Dgv_UsuarioBodega.Columns(i).Name
                        Case "IDPERSONA", "PERSONA", "IDBODEGA", "ESTADO", "ASOCIADO"
                            Dgv_UsuarioBodega.Columns(i).Visible = False
                        Case "ABREVIATURA", "BODEGA", "USUARIO", "BASE", "COMPRADOR"
                            Dgv_UsuarioBodega.Columns(i).Visible = True
                    End Select
                Next i
            Case 2
                For i = 0 To Dgv_UsuarioBodega.ColumnCount - 1
                    Select Case Dgv_UsuarioBodega.Columns(i).Name
                        Case "IDPERSONA", "ABREVIATURA", "BODEGA", "IDBODEGA", "ESTADO", "ASOCIADO"
                            Dgv_UsuarioBodega.Columns(i).Visible = False
                        Case "PERSONA", "USUARIO", "BASE", "COMPRADOR"
                            Dgv_UsuarioBodega.Columns(i).Visible = True
                    End Select
                Next i
        End Select

    End Sub

    Private Sub Bt_CargarUsuariosxBodega_Click(sender As Object, e As EventArgs) Handles Bt_CargarUsuariosxBodega.Click
        If Cb_BodegaAbreviatura.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una bodega para poder cargar sus usuarios asociados", MsgBoxStyle.Information, "Seleccionar Bodega")
            Exit Sub
        Else
            TipoActualizacion = 4
            Dim Comando As New SqlClient.SqlCommand("dbo.GestionarPermisosBodega")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@accion", 3)
            Comando.Parameters.AddWithValue("@idpersona", -1)
            Comando.Parameters.AddWithValue("@idbodega", Me.Cb_Bodega.SelectedValue)
            Dim TablaPermisoBodega As New DataTable
            TablaPermisoBodega.Columns.Add("IDPERSONA")
            TablaPermisoBodega.Columns.Add("PERSONA")
            TablaPermisoBodega.Columns.Add("ABREVIATURA")
            TablaPermisoBodega.Columns.Add("IDBODEGA")
            TablaPermisoBodega.Columns.Add("BODEGA")
            TablaPermisoBodega.Columns.Add("ASOCIADO")
            TablaPermisoBodega.Columns.Add("USUARIO")
            TablaPermisoBodega.Columns.Add("BASE")
            TablaPermisoBodega.Columns.Add("ESTADO")
            TablaPermisoBodega.Columns.Add("COMPRADOR")
            Comando.Parameters.AddWithValue("@TablaPermisoBodega", TablaPermisoBodega)
            Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            datas.Clear()
            Dim da As New SqlClient.SqlDataAdapter
            da = New SqlClient.SqlDataAdapter(Comando)
            da.Fill(datas)
            conn.Close()
            Me.Dgv_UsuarioBodega.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.Dgv_UsuarioBodega.DataSource = datas.Tables(0)
            CargarFormatoDatagrid(2)
            Me.Pn_Encabezado.Enabled = False
            Me.Btn_Cancelar.Enabled = True
            Me.Btn_Guardar.Enabled = True
            Me.Lb_Mensaje.Text = "Cantidad de usuarios asociados a la bodega: " + datas.Tables(0).Rows.Count().ToString
            Me.Lb_Mensaje.Visible = Visible
        End If
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

    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        'Validar que solo tenga una base marcada

        If MsgBox("¿Seguro que desea aplicar los cambios realizados?", MsgBoxStyle.YesNo, "Realizar cambios") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim filas() As DataRow

        Select Case TipoActualizacion
            Case 2 'Actualizando usuario
                filas = datas.Tables(0).Select("BASE='S'")
                If filas.Length > 1 Then
                    MsgBox("El usuario solo puede tener marcado una base", MsgBoxStyle.Information, "Marcar solo una base")
                    Exit Sub
                End If
                If filas.Length = 0 Then
                    MsgBox("EL usuario no tiene marcado ninguna base como predeterminada", MsgBoxStyle.Information, "Marcar al menos una base")
                    Exit Sub
                End If
            Case 4 'Actualizando bodegas

        End Select



        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarPermisosBodega")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@accion", TipoActualizacion)
        Select Case TipoActualizacion
            Case 2 'Actualizando usuario
                Comando.Parameters.AddWithValue("@idpersona", Me.Cu_BuscarPersona.Cb_Persona.SelectedValue)
                Comando.Parameters.AddWithValue("@idbodega", -1)
            Case 4 'Actualizando bodegas
                Comando.Parameters.AddWithValue("@idpersona", -1)
                Comando.Parameters.AddWithValue("@idbodega", Me.Cb_Bodega.SelectedValue)
        End Select




        Dim TablaPermisoBodega As New DataTable
        TablaPermisoBodega.Columns.Add("IDPERSONA")
        TablaPermisoBodega.Columns.Add("PERSONA")
        TablaPermisoBodega.Columns.Add("ABREVIATURA")
        TablaPermisoBodega.Columns.Add("IDBODEGA")
        TablaPermisoBodega.Columns.Add("BODEGA")
        TablaPermisoBodega.Columns.Add("ASOCIADO")
        TablaPermisoBodega.Columns.Add("USUARIO")
        TablaPermisoBodega.Columns.Add("BASE")
        TablaPermisoBodega.Columns.Add("ESTADO")
        TablaPermisoBodega.Columns.Add("COMPRADOR")

        Dim fila As DataRow

        For i = 0 To datas.Tables(0).Rows.Count - 1
            Dim filausuario As DataRow
            filausuario = datas.Tables(0).Rows(i)
            fila = TablaPermisoBodega.NewRow

            Select Case TipoActualizacion
                Case 2 'Actualizando usuario
                    fila("IDPERSONA") = Me.Cu_BuscarPersona.Cb_Persona.SelectedValue
                    fila("IDBODEGA") = filausuario("IDBODEGA")
                Case 4 'Actualizando Bodega
                    fila("IDPERSONA") = filausuario("IDPERSONA")
                    fila("IDBODEGA") = Me.Cb_Bodega.SelectedValue
            End Select
            fila("PERSONA") = ""
            fila("ABREVIATURA") = ""
            fila("BODEGA") = ""
            fila("ASOCIADO") = filausuario("USUARIO")
            fila("USUARIO") = filausuario("USUARIO")
            fila("COMPRADOR") = filausuario("COMPRADOR")
            If filausuario("BASE") = "S" Then
                fila("ASOCIADO") = "S"
                fila("USUARIO") = "S"
                fila("COMPRADOR") = filausuario("COMPRADOR")
            End If
            fila("BASE") = filausuario("BASE")
            fila("ESTADO") = "A"
            TablaPermisoBodega.Rows.Add(fila)
        Next


        Comando.Parameters.AddWithValue("@TablaPermisoBodega", TablaPermisoBodega)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()

        Dim Mensaje As String = ""
        Select Case TipoActualizacion
            Case 2
                Mensaje = "Se actualizo el usuario " + Trim(Me.Cu_BuscarPersona.Cb_Persona.Text) + " correctamente, ¿Desea salir?"
            Case 4
                Mensaje = "Se actualizo la bodega " + Trim(Me.Cb_Bodega.Text) + " correctamente, ¿Desea salir?"
        End Select


        If MsgBox(Mensaje, MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Me.Pn_Encabezado.Enabled = True
            Me.Btn_Guardar.Enabled = False
            Me.Btn_Cancelar.Enabled = False
            Me.Lb_Mensaje.Visible = False
            Me.datas.Tables(0).Clear()
        End If




    End Sub

    Private Sub MarcarTodas_Click(sender As Object, e As EventArgs) Handles MarcarTodas.Click
        Try
            If Btn_Guardar.Enabled = False Then
                Exit Sub
            End If
            Dim Nombre_Columna As String
            Dim Indice_Columna As Integer
            Nombre_Columna = Me.Dgv_UsuarioBodega.Columns(Me.Dgv_UsuarioBodega.CurrentCell.ColumnIndex).HeaderText
            Indice_Columna = Me.Dgv_UsuarioBodega.CurrentCell.ColumnIndex

            If Nombre_Columna = "Usuario" Or Nombre_Columna = "Comprador" Then
                If MsgBox("¿Seguro que desea marcar todas las bodegas?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
                Dim i As Integer
                Me.Cursor = Cursors.WaitCursor
                Try
                    For i = 0 To Me.Dgv_UsuarioBodega.RowCount - 1
                        Me.Dgv_UsuarioBodega.Item(Indice_Columna, i).Value = "S"
                    Next
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERROR")
                End Try

                Me.Dgv_UsuarioBodega.ClearSelection()
                Me.Dgv_UsuarioBodega.RefreshEdit()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub DemarcarTodas_Click(sender As Object, e As EventArgs) Handles DemarcarTodas.Click
        Try
            If Btn_Guardar.Enabled = False Then
                Exit Sub
            End If
            Dim Nombre_Columna As String
            Dim Indice_Columna As Integer
            Nombre_Columna = Me.Dgv_UsuarioBodega.Columns(Me.Dgv_UsuarioBodega.CurrentCell.ColumnIndex).HeaderText
            Indice_Columna = Me.Dgv_UsuarioBodega.CurrentCell.ColumnIndex

            If Nombre_Columna = "Usuario" Or Nombre_Columna = "Comprador" Then
                If MsgBox("¿Seguro que desea marcar todas las bodegas?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
                Dim i As Integer
                Me.Cursor = Cursors.WaitCursor
                Try
                    For i = 0 To Me.Dgv_UsuarioBodega.RowCount - 1
                        Me.Dgv_UsuarioBodega.Item(Indice_Columna, i).Value = "N"
                    Next
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERROR")
                End Try
                Me.Dgv_UsuarioBodega.ClearSelection()
                Me.Dgv_UsuarioBodega.RefreshEdit()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cms_opciones_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cms_opciones.Opening
        Dim Nombre_Columna As String
        'Dim Indice_Columna As Integer
        Try
            Nombre_Columna = Me.Dgv_UsuarioBodega.Columns(Me.Dgv_UsuarioBodega.CurrentCell.ColumnIndex).HeaderText
            'Indice_Columna = Me.Dgv_UsuarioBodega.CurrentCell.ColumnIndex

            If Nombre_Columna = "Usuario" Or Nombre_Columna = "Comprador" Then
                Me.Cms_opciones.Enabled = True
            Else
                Me.Cms_opciones.Enabled = False
            End If
        Catch ex As Exception
            Me.Cms_opciones.Enabled = False
        End Try
    End Sub


    Private Sub Cb_Bodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Bodega.SelectedIndexChanged
        Try
            Me.Cb_BodegaAbreviatura.SelectedValue = Me.Cb_Bodega.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cb_BodegaAbreviatura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_BodegaAbreviatura.SelectedIndexChanged
        Try
            Me.Cb_Bodega.SelectedValue = Me.Cb_BodegaAbreviatura.SelectedValue
        Catch ex As Exception

        End Try

    End Sub
End Class