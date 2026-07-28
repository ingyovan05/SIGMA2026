Imports System.Data.SqlClient

Public Class Fr_RelacionarFacturas

    Public IdRelaciónModificando As Integer = -1
    Dim adap As New Ds_FacturasTableAdapters.RELACIONARDOCUMENTOSTableAdapter

    Public Sub CargarDatos()
        If IdRelaciónModificando = -1 Then
            'se esta creando una nueva relación
            adap.FillPENDIENTESRELACIONAR(Ds_Facturas.RELACIONARDOCUMENTOS)
            Me.Dtp_FechaDocumento.Value = Date.Now
        Else
            'se esta modificando una relación
            adap.FillByEDITANDO(Ds_Facturas.RELACIONARDOCUMENTOS, IdRelaciónModificando)
        End If

    End Sub


    Private Sub Bt_ExcluirFactura_Click(sender As System.Object, e As System.EventArgs)
        If Me.Dgv_ListaItemEntrada.SelectedRows.Count = 1 Then
            If MsgBox("Desea retirar la factura de la relación actual", MsgBoxStyle.YesNo, "Retirar Factura") = MsgBoxResult.Yes Then
                MsgBox("Pendiente")
            End If
        End If
    End Sub

    Private Sub Bt_Cerrar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Guardar.Click
        Dim TableIDDOCUMENTO As New DataTable
        TableIDDOCUMENTO.Columns.Add("IDDOCUMENTO")
        Dim FilaTablaIDDOCUMENTO As DataRow
        For i = 0 To Me.Ds_Facturas.RELACIONARDOCUMENTOS.Rows.Count - 1
            Dim FilaDGVItem As DataRow
            FilaDGVItem = Me.Ds_Facturas.RELACIONARDOCUMENTOS.Rows(i)
            If FilaDGVItem("Pertenece") = "S" Then
                FilaTablaIDDOCUMENTO = TableIDDOCUMENTO.NewRow
                FilaTablaIDDOCUMENTO("IDDOCUMENTO") = FilaDGVItem("Id")
                TableIDDOCUMENTO.Rows.Add(FilaTablaIDDOCUMENTO)
            End If
        Next

        If TableIDDOCUMENTO.Rows.Count < 1 Then
            MsgBox("Debe seleccionar al menos una factura para poder continuar", MsgBoxStyle.Critical, "Seleccione las facturas")
            Exit Sub
        End If
        Dim Comando As New SqlClient.SqlCommand("GestionarRelaciónFacturas")
        Comando.CommandType = CommandType.StoredProcedure
        If IdRelaciónModificando = -1 Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@FECHADOCUMENTO", Dtp_FechaDocumento.Value)
        Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIAORIGEN", -1)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIADESTINO", -1)
        Comando.Parameters.AddWithValue("@TableIDDOCUMENTO", TableIDDOCUMENTO)
        Comando.Parameters.AddWithValue("@IDRELACIONDOCUMENTO", IdRelaciónModificando)
        Comando.Parameters.AddWithValue("@IDBODEGAREGISTRO", VariablesBase.VariablesBase.IdBodegaActual)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Dim Idrelacion As Integer
        Try
            Comando.ExecuteNonQuery()
            Idrelacion = Comando.Parameters("@IDMENSAJE").Value
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        conn.Close()

        If IdRelaciónModificando = -1 Then
            'creando
            If MsgBox("¿Desea imprimir la relación de facturas?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(69)
                climpresiones.IDRELACIONDOCUMENTO = Idrelacion
                climpresiones.FormatoImprimirMateriales(Array, True, False)
                MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                Me.Close()
            End If
        Else
            If MsgBox("Se guardo la relación de facturas, ¿Desea Salir?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                Me.Close()
            End If

        End If

    End Sub

End Class