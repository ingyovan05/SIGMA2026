Imports System.Data.SqlClient

''' <summary>
''' 
''' </summary>
Public Class Fr_SeleccionarItems

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property IdLicitacion As Integer = -1

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property ListaItemsAPU As DataTable


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Comportamiento_Predeterminado()
        Dgv_Lista.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Lista.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    ' 
    Private Sub Fr_SeleccionarItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comportamiento_Predeterminado()
        CargarLicitaciones()
        If IdLicitacion > 0 Then
            Cb_Licitaciones.SelectedValue = IdLicitacion
            CargarItemsAPU()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarLicitaciones()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaLicitaciones(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 3) 'Licitaciones activas de las cuales se tiene permiso de lectura/escritura.
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtLicitaciones As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtLicitaciones, SchemaType.Source)
            adaptador.Fill(dtLicitaciones)
            conexion.Close()
            Cb_Licitaciones.DataSource = dtLicitaciones
            Cb_Licitaciones.ValueMember = "IDLICITACION"
            Cb_Licitaciones.DisplayMember = "PROYECTO"
        Catch ex As Exception
            MsgBox("No se cargó el listado de Licitaciones.", MsgBoxStyle.Critical, "Error listar Licitaciones")
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Bt_CargarItemsAPU_Click(sender As Object, e As EventArgs) Handles Bt_CargarItemsAPU.Click
        If Cb_Licitaciones.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la licitación de la cual se requiere cargar los Ítems A.P.U.", MsgBoxStyle.Information, "Seleccionar Licitación")
            Exit Sub
        Else
            IdLicitacion = Cb_Licitaciones.SelectedValue
            CargarItemsAPU()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' La columna SELECCIONADO se inicializa con todas las filas en valor falso (no seleccionado) y más adelante se les asigna el valor verdadero para desencadenar el método de cambio de estado de la casilla de selección.
    ''' </summary>
    Private Sub CargarItemsAPU()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaAPU(@TIPO, @IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1) 'Todos los Ítems A.P.U. y Capítulos activos.
        comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtAPUItems As New DataTable
        Try
            conexion.Open()
            'adaptador.FillSchema(dtAPUItems, SchemaType.Source)
            adaptador.Fill(dtAPUItems)
            conexion.Close()

            dtAPUItems.Columns.Add(DgvCk_Seleccionado.DataPropertyName)
            For i As Integer = 0 To dtAPUItems.Rows.Count - 1
                dtAPUItems.Rows(i).Item(DgvCk_Seleccionado.DataPropertyName) = DgvCk_Seleccionado.FalseValue
            Next
            Dgv_Lista.DataSource = dtAPUItems
            Pn_BusquedaLicitacion.Enabled = False
            Bt_Cancelar.Enabled = True
            Bt_Aceptar.Enabled = True
            Tsmi_MarcarTodas.PerformClick()
        Catch ex As Exception
            MsgBox("No se cargó el listado de Ítems A.P.U.", MsgBoxStyle.Critical, "Error listar Ítems A.P.U.")
        Finally
            conexion.Close()
        End Try
    End Sub


    '
    Private Sub Dgv_Lista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Lista.CellContentClick
        Dgv_Lista.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub


    '
    Private Sub Dgv_Lista_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Lista.CellValueChanged
        If Not IsNothing(Dgv_Lista.DataSource) Then
            Dim columnasSeleccionadas As Integer = 0
            For i As Integer = 0 To Dgv_Lista.Rows.Count - 1
                If Dgv_Lista.Rows(i).Cells(DgvCk_Seleccionado.Name).Value = DgvCk_Seleccionado.TrueValue Then
                    columnasSeleccionadas += 1
                End If
            Next
            Tx_Seleccion.Text = "Cantidad de Ítems A.P.U. seleccionados: " & columnasSeleccionadas & "."
        End If
    End Sub


    '
    Private Sub Dgv_Lista_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Dgv_Lista.MouseClick
        If Bt_Aceptar.Enabled = True Then
            If e.Button = MouseButtons.Right Then
                If Dgv_Lista.HitTest(e.X, e.Y).ColumnIndex = Dgv_Lista.Columns(DgvCk_Seleccionado.Name).Index Then
                    Cms_Opciones.Show(Dgv_Lista, New Point(e.X, e.Y))
                End If
            End If
        End If
    End Sub


    '
    Private Sub Tsmi_MarcarTodas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Tsmi_MarcarTodas.Click
        If Bt_Aceptar.Enabled = False Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To Dgv_Lista.Rows.Count - 1
            Dgv_Lista.Rows(i).Cells(DgvCk_Seleccionado.Name).Value = DgvCk_Seleccionado.TrueValue
        Next
        Dgv_Lista.ClearSelection()
        Dgv_Lista.RefreshEdit()
        Cursor = Cursors.Default
    End Sub


    '
    Private Sub MarcarSeleccionadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarSeleccionadasToolStripMenuItem.Click
        If Bt_Aceptar.Enabled = False Then
            Exit Sub
        End If
        If Dgv_Lista.SelectedRows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In Dgv_Lista.SelectedRows
                row.Cells(DgvCk_Seleccionado.Name).Value = DgvCk_Seleccionado.TrueValue
            Next
            Dgv_Lista.ClearSelection()
            Dgv_Lista.RefreshEdit()
            Cursor = Cursors.Default
        End If
    End Sub


    '
    Private Sub Tsmi_DemarcarTodas_Click(sender As Object, e As EventArgs) Handles Tsmi_DemarcarTodas.Click
        If Bt_Aceptar.Enabled = False Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To Dgv_Lista.Rows.Count - 1
            Dgv_Lista.Rows(i).Cells(DgvCk_Seleccionado.Name).Value = DgvCk_Seleccionado.FalseValue
        Next
        Dgv_Lista.ClearSelection()
        Dgv_Lista.RefreshEdit()
        Cursor = Cursors.Default
    End Sub


    ' 
    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Not IsNothing(Dgv_Lista.DataSource) Then
            ListaItemsAPU = New DataTable
            ListaItemsAPU.Columns.Add("IDAPU")
            Dim filas() As DataRow
            filas = Dgv_Lista.DataSource.Select(DgvCk_Seleccionado.DataPropertyName & "='" & DgvCk_Seleccionado.TrueValue & "'")
            For i = 0 To filas.Length - 1
                ListaItemsAPU.Rows.Add(filas(i).Item(DgvTx_IdAPU.DataPropertyName))
            Next
            DialogResult = Windows.Forms.DialogResult.OK
        Close()
        End If
    End Sub


    ' 
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Pn_BusquedaLicitacion.Enabled = True
        Bt_Cancelar.Enabled = False
        Bt_Aceptar.Enabled = False
        Dgv_Lista.DataSource.Clear()
    End Sub


    ' Cierre del formulario.
    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class 'Fr_SeleccionarItems