Public Class Fr_CaracterísticaArtículo

    Public IDARTICULO As Integer

    Dim ds As New DatosArticulos.Ds_Artículos
    Dim adap As New DatosArticulos.Ds_ArtículosTableAdapters.ARTICULOCARACTERISTICAXBODEGATableAdapter
    Dim existe As Boolean

    Public Sub CargarTabla()
        adap.FillXIDARTICULOXIDBODEGA(ds.ARTICULOCARACTERISTICAXBODEGA, IDARTICULO, VariablesBase.VariablesBase.IdBodegaActual)
        If ds.ARTICULOCARACTERISTICAXBODEGA.Rows.Count > 0 Then
            existe = True
            Dim fila As DataRow
            fila = ds.ARTICULOCARACTERISTICAXBODEGA.Rows(0)
            Me.Tx_Ubicación.Text = Trim(fila("LOCALIZACION"))
            Me.Nud_Mínimo.Value = fila("STOCKMINIMO")
            Me.Nud_Máximo.Value = fila("STOCKMAXIMO")
        Else
            existe = False
        End If
    End Sub

    Private Sub Btn_CancelarCambio_Click(sender As System.Object, e As System.EventArgs) Handles Btn_CancelarCambio.Click
        Me.Close()
    End Sub

    Private Sub Btn_AceptarCambio_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AceptarCambio.Click
        GuardarCaracterísticas()
    End Sub

    Private Sub GuardarCaracterísticas()
        Try
            If existe = True Then
                adap.Update(Trim(Tx_Ubicación.Text), Me.Nud_Mínimo.Value, Me.Nud_Máximo.Value, IDARTICULO, VariablesBase.VariablesBase.IdBodegaActual)
            Else
                adap.Insert(IDARTICULO, VariablesBase.VariablesBase.IdBodegaActual, Trim(Tx_Ubicación.Text), Me.Nud_Mínimo.Value, Me.Nud_Máximo.Value)
            End If
            MsgBox("Se realizo la operación correctamente")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al procesar la operación")
        End Try



    End Sub

End Class