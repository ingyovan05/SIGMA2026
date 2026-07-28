Public Class Fr_RelaciónFacturas

    Dim DsFacturas As New Ds_Facturas
    Dim Adap As New Ds_FacturasTableAdapters.ASOCIARFACTURAORDENCOMPRATableAdapter
    Dim AdapFacturas As New Ds_FacturasTableAdapters.CC_DETALLEDOCUMENTOTableAdapter
    Dim fila As DataRow
    Public NroEntradasAlmacen As Integer = 0

    Public Sub CargarDatos(ByVal IDORDENCOMPRA As Int64)
        Me.Dgv_ListaItemEntrada.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaItemEntrada.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ListaItemEntrada.DataSource = Me.DsFacturas.ASOCIARFACTURAORDENCOMPRA
        Adap.FillXIDORDENCOMPRA(Me.DsFacturas.ASOCIARFACTURAORDENCOMPRA, IDORDENCOMPRA)
        NroEntradasAlmacen = Me.DsFacturas.ASOCIARFACTURAORDENCOMPRA.Rows.Count
        If NroEntradasAlmacen = 0 Then
            MsgBox("Esta Orden de compra no tienen entradas de almacén", MsgBoxStyle.Information, "No tienen Entrada de Almacén")
            Me.Close()
            Exit Sub
        End If
        fila = DsFacturas.ASOCIARFACTURAORDENCOMPRA.Rows(0)
        AdapFacturas.FillByPARARELACIONAR(Me.DsFacturas.CC_DETALLEDOCUMENTO, fila("IDPROVEEDOR"))
        Me.Cb_Facturas.DataSource = Me.DsFacturas.CC_DETALLEDOCUMENTO
        Me.Cb_Facturas.ValueMember = "Id"
        Me.Cb_Facturas.DisplayMember = "Nro Factura"

        For i = 0 To Dgv_ListaItemEntrada.ColumnCount - 1
            Select Case Dgv_ListaItemEntrada.Columns(i).Name
                Case "Orden de Compra"
                    Dgv_ListaItemEntrada.Columns(i).Width = 120
                Case "Entrada"
                    Dgv_ListaItemEntrada.Columns(i).Width = 120
                Case "Item EA"
                    Dgv_ListaItemEntrada.Columns(i).Width = 45
                Case "Código"
                    Dgv_ListaItemEntrada.Columns(i).Width = 55
                Case "Descripción"
                    Dgv_ListaItemEntrada.Columns(i).Width = Dgv_ListaItemEntrada.Width - 550
                Case "Cant"
                    Dgv_ListaItemEntrada.Columns(i).Width = 50
                Case "Factura"
                    Dgv_ListaItemEntrada.Columns(i).Width = 100
                Case Else
                    Dgv_ListaItemEntrada.Columns(i).Visible = False
            End Select
        Next

    End Sub


    Private Sub Bt_AplicarTodas_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AplicarTodas.Click
        If MsgBox("¿Desea aplicar la factura relacioanda a todos los item de las entradas de almacén?", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
            AplicarFactura("T")
        End If

    End Sub

    Private Sub Bt_AplicarVacias_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AplicarVacias.Click
        If MsgBox("¿Desea aplicar la factura relacioanda a los item de las entradas de almacén que no tienen factura asociada?", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
            AplicarFactura("V")
        End If
    End Sub

    Private Sub AplicarFactura(ByVal Tipo As String)
        If Trim(Me.Cb_Facturas.Text) <> "" Then
            For i = 0 To Dgv_ListaItemEntrada.RowCount - 1
                If Tipo = "T" Then
                    Dgv_ListaItemEntrada.Rows(i).Cells("Factura").Value = Trim(Me.Cb_Facturas.Text)
                Else
                    If Trim(IIf(IsDBNull(Dgv_ListaItemEntrada.Rows(i).Cells("Factura").Value), "", Dgv_ListaItemEntrada.Rows(i).Cells("Factura").Value)) = "" Then
                        Dgv_ListaItemEntrada.Rows(i).Cells("Factura").Value = Trim(Me.Cb_Facturas.Text)
                    End If
                End If
            Next
            Me.Cb_Facturas.SelectedItem = -1
            If MsgBox("¿Desea Guardar los cambios?", MsgBoxStyle.YesNo, "Guardar") = MsgBoxResult.Yes Then
                Guardar()
            End If
        Else
            MsgBox("Debe digitar el nro de factura que desea aplicar en bloque", MsgBoxStyle.Critical, "Factura")
        End If
    End Sub

    Private Sub Guardar()
        Dim TablaItemEA As New DataTable
        TablaItemEA.Columns.Add("IDITEMENTRADAALMACEN")
        TablaItemEA.Columns.Add("IDORDENCOMPRA")
        TablaItemEA.Columns.Add("IDITEMORDENCOMPRA")
        TablaItemEA.Columns.Add("CANTIDAD")
        TablaItemEA.Columns.Add("IDARTICULO")
        TablaItemEA.Columns.Add("IDREQUISICION")
        TablaItemEA.Columns.Add("IDITEMREQUISICION")
        TablaItemEA.Columns.Add("NUMEROFACTURA")
        TablaItemEA.Columns.Add("IDREMISION")

        Dim FilaTablaItemEA As DataRow
        For i = 0 To Me.DsFacturas.ASOCIARFACTURAORDENCOMPRA.Rows.Count - 1
            Dim FilaDGVItem As DataRow
            FilaDGVItem = Me.DsFacturas.ASOCIARFACTURAORDENCOMPRA.Rows(i)
            FilaTablaItemEA = TablaItemEA.NewRow
            FilaTablaItemEA("IDITEMENTRADAALMACEN") = FilaDGVItem("Item EA")
            FilaTablaItemEA("IDORDENCOMPRA") = FilaDGVItem("IDENTRADAALMACEN") 'Utilizar este valor para no crear otro tipo de dato
            FilaTablaItemEA("NUMEROFACTURA") = FilaDGVItem("Factura")
            TablaItemEA.Rows.Add(FilaTablaItemEA)
        Next

        Dim Comando As New SqlClient.SqlCommand("AsociarFacturaEA")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TableItemEA", TablaItemEA)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        If MsgBox("Se realizo la relación ¿Desea Salir?", MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
            Me.Close()
        End If

    End Sub

    Private Sub Bt_Cerrar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cerrar.Click
        If MsgBox("¿Desea Salir?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Guardar.Click
        Guardar()
    End Sub


    Private Sub Bt_AdicionarFactura_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AdicionarFactura.Click
        Dim fr As New Facturas.Fr_RegistrarFactura
        fr.Tx_Identificación.Text = fila("IDENTIFICACION")
        fr.Cargar_Proveedor()
        fr.Tx_Identificación.Enabled = False
        fr.ShowDialog()
        fila = DsFacturas.ASOCIARFACTURAORDENCOMPRA.Rows(0)
        AdapFacturas.FillXPROVEEDOR(Me.DsFacturas.CC_DETALLEDOCUMENTO, fila("IDPROVEEDOR"))
        Me.Cb_Facturas.DataSource = Me.DsFacturas.CC_DETALLEDOCUMENTO
        Me.Cb_Facturas.ValueMember = "Id"
        Me.Cb_Facturas.DisplayMember = "Nro Factura"
    End Sub

End Class