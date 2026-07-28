''' <summary>
''' 
''' </summary>
Public Class Fr_OpcionesImpresionLicitacion

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property IdLicitacion As Integer = -1

    ''' <summary>
    ''' Contiene el listado de resúmenes disponibles para impresión.
    ''' </summary>
    Private dtResumen As DataTable


    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        dtResumen = New DataTable
    End Sub


    ' 
    Private Sub Fr_OpcionesImpresionLicitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtResumen.Columns.Add("ID", GetType(Integer))
        dtResumen.Columns.Add("RESUMEN", GetType(String))
        dtResumen.Rows.Add(1, "Presupuesto de Construcción")
        dtResumen.Rows.Add(2, "Análisis de Precios Unitarios")
        dtResumen.Rows.Add(3, "Resumen de Recursos") 'Todos los recursos
        dtResumen.Rows.Add(4, "Análisis de Precios Unitarios (una sola hoja)")
        dtResumen.Rows.Add(5, "Resumen de Recursos (una sola hoja)")

        Cb_Resumen.DataSource = dtResumen
        Cb_Resumen.ValueMember = "ID"
        Cb_Resumen.DisplayMember = "RESUMEN"
    End Sub


    ' 
    Private Sub Cb_Resumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Resumen.SelectedIndexChanged
        If Not IsNothing(Cb_Resumen.SelectedValue) AndAlso IsNumeric(Cb_Resumen.SelectedValue) Then
            Select Case Cb_Resumen.SelectedValue
                Case 1, 2, 3
                    Rb_ValoresSinAIU.Enabled = True
                    Rb_ValoresConAIU.Enabled = True
                    Bt_Imprimir.Enabled = True
                Case 4, 5
                    Rb_ValoresSinAIU.Enabled = True
                    Rb_ValoresConAIU.Enabled = True
                    Bt_Imprimir.Enabled = False
                Case Else
                    Rb_ValoresSinAIU.Enabled = False
                    Rb_ValoresConAIU.Enabled = False
                    Bt_Imprimir.Enabled = True
            End Select
        End If
    End Sub


    ' 
    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click
        If Not IsNothing(Cb_Resumen.SelectedValue) Then
            Dim climpresiones As New ImpresiónLicitaciones.Cl_Impresión
            Dim ListadoDocumentos As New ArrayList
            If IdLicitacion > 0 Then
                climpresiones.IdLicitacion = IdLicitacion
            ElseIf VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
                climpresiones.IdLicitacion = VariablesBase.VariablesBase.IdLicitacionCargada
            Else
                MsgBox("No se encontró ninguna licitación seleccionada.", MsgBoxStyle.Exclamation, "Imprimir Licitaciones")
                Exit Sub
            End If
            climpresiones.valoresConAIU = If(Rb_ValoresConAIU.Checked, True, False)
            Select Case Cb_Resumen.SelectedValue
                Case 1 'Presupuesto de Construcción
                    ListadoDocumentos.Add(1)
                Case 2 'Análisis de Precios Unitarios
                    ListadoDocumentos.Add(2)
                Case 3 'Resumen de Recursos
                    ListadoDocumentos.Add(3)
                Case Else
                    MsgBox("Seleccione una opción del listado de resúmenes.", MsgBoxStyle.Exclamation, "Impresión Licitaciones")
                    Exit Sub
            End Select
            climpresiones.FormatoImprimirLicitaciones(ListadoDocumentos, True, False)
            If climpresiones.ImpresionFinalizada Then
                MsgBox("Impresión finalizada.", MsgBoxStyle.Information, "Impresión Licitaciones")
            End If
        End If
    End Sub


    ' 
    Private Sub Bt_Exportar_Click(sender As Object, e As EventArgs) Handles Bt_Exportar.Click
        If Not IsNothing(Cb_Resumen.SelectedValue) Then
            Select Case Cb_Resumen.SelectedValue
                Case 1 'Presupuesto de Construcción
                    FormulariosLicitaciones.ExportarExcel_ListadoDePrecios(IdLicitacion)
                Case 2 'Análisis de Precios Unitarios
                    FormulariosLicitaciones.ExportarExcel_DetalleAPUsMultiplesHojas(IdLicitacion)
                Case 3 'Resumen de Recursos
                    FormulariosLicitaciones.ExportarExcel_ResumenDeRecursosMultiplesHojas(IdLicitacion)
                Case 4 'Análisis de Precios Unitarios (una sola hoja)
                    FormulariosLicitaciones.ExportarExcel_DetalleAPUsUnaHoja(IdLicitacion)
                Case 5 'Resumen de Recursos (una sola hoja)
                    FormulariosLicitaciones.ExportarExcel_ResumenDeRecursosUnaHoja(IdLicitacion)
                Case Else
                    MsgBox("Seleccione una opción del listado de resúmenes.", MsgBoxStyle.Exclamation, "Impresión Licitaciones")
                    Exit Sub
            End Select
        End If
    End Sub


    ' 
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub

End Class