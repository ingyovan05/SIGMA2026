Public Class Fr_HistoricoPrecio

    Dim DsArtículos As New DatosArticulos.Ds_Artículos

    Public Sub CargarTablas(ByVal TIPO As Integer, ByVal IDBODEGA As Integer, _
                                ByVal IDARTICULO As Integer, ByVal IDPROVEEDOR As Integer)
        Try
            Dim adap As New DatosArticulos.Ds_ArtículosTableAdapters.ProveedoresxArticuloTableAdapter
            adap.Fill(Me.DsArtículos.ProveedoresxArticulo, 1, VariablesBase.VariablesBase.IdBodegaActual, IDARTICULO, -1)
            Me.Dgv_TablaProveedores.DataSource = Me.DsArtículos.ProveedoresxArticulo
            Me.Dgv_TablaProveedores.AutoGenerateColumns = True
            Me.Dgv_TablaProveedores.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
        End Try
    End Sub


End Class