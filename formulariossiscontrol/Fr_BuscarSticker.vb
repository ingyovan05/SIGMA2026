Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_BuscarSticker
    Private _idSticker As Integer
    Private _numeroSticker As String
    Private dtFiltroColumnas As New DataTable
    Private dvStickersFiltrados As DataView

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IdSticker As Integer
        Get
            Return _idSticker
        End Get
        Private Set(value As Integer)
            _idSticker = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property NumeroSticker As Integer
        Get
            Return _numeroSticker
        End Get
        Private Set(value As Integer)
            _numeroSticker = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IdRecepcion As Integer?

    Private Sub Fr_BuscarSticker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFiltroColumnas.Columns.Add("VALOR")
        dtFiltroColumnas.Columns.Add("MOSTRAR")
        For i As Integer = 0 To Dgv_Buscar.Columns.Count - 1
            If Dgv_Buscar.Columns(i).Visible Then
                dtFiltroColumnas.Rows.Add(Dgv_Buscar.Columns(i).DataPropertyName, Dgv_Buscar.Columns(i).HeaderText)
            End If
        Next
        Cb_Filtrar.ValueMember = "VALOR"
        Cb_Filtrar.DisplayMember = "MOSTRAR"
        Cb_Filtrar.DataSource = dtFiltroColumnas
        Cb_Filtrar.SelectedValue = Col_NumeroSticker.DataPropertyName

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM SC_ListaStickers(@IdDependencia, @IdRecepcion)", conexion)
        comando.Parameters.Add("@IdDependencia", SqlDbType.Int)
        comando.Parameters.Add("@IdRecepcion", SqlDbType.BigInt)

        comando.Parameters("@IdDependencia").Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        If IdRecepcion IsNot Nothing Then
            comando.Parameters("@IdRecepcion").Value = IdRecepcion.Value
        Else
            comando.Parameters("@IdRecepcion").Value = DBNull.Value
        End If
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtStickers As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtStickers)
            conexion.Close()
            If dtStickers.Rows.Count > 0 Then
                dvStickersFiltrados = New DataView(dtStickers, "", "GRUPO, HOJA, ITEM", DataViewRowState.CurrentRows)
                Dgv_Buscar.DataSource = dvStickersFiltrados
                Dgv_Buscar.AutoResizeColumns()
            End If
        Catch ex As Exception
            Throw New Exception("Error al consultar los datos.", ex)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Ck_Filtrar_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_Filtrar.CheckedChanged

    End Sub

    Private Sub Cb_Filtrar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Filtrar.SelectedIndexChanged
        Filtrar()
    End Sub

    Private Sub Tx_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Tx_Descripcion.TextChanged
        Tm_Temporizador.Stop()
        Tm_Temporizador.Start()
    End Sub

    Private Sub Dgv_Buscar_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Buscar.CellContentDoubleClick
        Devolver()
    End Sub

    Private Sub Tm_Temporizador_Tick(sender As Object, e As EventArgs) Handles Tm_Temporizador.Tick
        Filtrar()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Devolver()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Filtrar()
        If Ck_Filtrar.Checked AndAlso Trim(Tx_Descripcion.Text).Length > 0 Then
            dvStickersFiltrados.RowFilter = Cb_Filtrar.SelectedValue & " LIKE '%" & Tx_Descripcion.Text & "%'"
        End If
    End Sub

    Private Sub Devolver()
        IdSticker = Dgv_Buscar.SelectedRows(0).Cells(Col_IdSticker.Name).Value
        NumeroSticker = Dgv_Buscar.SelectedRows(0).Cells(Col_NumeroSticker.Name).Value
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class