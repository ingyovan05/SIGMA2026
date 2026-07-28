Imports System.Windows.Forms

Public Class Fr_NovedadesPersona

    Private Sub Fr_NovedadesPersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Dgv_Novedades.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        'Me.Dgv_Novedades.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        'Me.REPORTENOVEDADTableAdapter.Fill(Ds_ModificarReporteDiario.REPORTENOVEDAD, VariablesBase.VariablesBase.IdProyecto)
        'Me.Lb_errores_integrantes.Text = "Novedades pendientes para imprimir: " + Ds_ModificarReporteDiario.REPORTENOVEDAD.Rows.Count.ToString + "      Nro hojas: " + (Fix(Ds_ModificarReporteDiario.REPORTENOVEDAD.Rows.Count / 26) + 1).ToString
    End Sub


    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Eliminar.Click
        'If Dgv_Novedades.SelectedRows.Count = 0 Then
        '    MsgBox("Seleccione las novedades que desea eliminar, una vez eliminados no podra imprimirlos", MsgBoxStyle.Information, "Eliminar")
        '    Exit Sub
        'Else
        '    If MsgBox("¿Desea eliminar las " + Dgv_Novedades.SelectedRows.Count.ToString + " novedades seleccionadas?, una vez eliminados no podra imprimirlos", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If
        ''cargar Tablas
        'Dim TablaActualizarRDPN As New DataTable
        'TablaActualizarRDPN.Columns.Add("CODIGOCONTRATO")
        'TablaActualizarRDPN.Columns.Add("IDREPORTEDIARIO")
        'TablaActualizarRDPN.Columns.Add("IDPROYECTO")
        'For i = 0 To Dgv_Novedades.SelectedRows.Count - 1
        '    Dim Fila As DataRow
        '    Fila = TablaActualizarRDPN.NewRow
        '    Fila("CODIGOCONTRATO") = Dgv_Novedades.SelectedRows(i).Cells("CODIGOCONTRATODataGridViewTextBoxColumn").Value
        '    Fila("IDREPORTEDIARIO") = Dgv_Novedades.SelectedRows(i).Cells("IdReporteDataGridViewTextBoxColumn").Value
        '    Fila("IDPROYECTO") = VariablesBase.VariablesBase.IdProyecto
        '    TablaActualizarRDPN.Rows.Add(Fila)
        'Next

        ''Llamar al procedimiento para actualizar los reportes
        'Dim adapactualizarreportenovedad As New DatosReporteDiario.Ds_ModificarReporteDiarioTableAdapters.ActualizarReporteDiario

        'Dim Comando As New SqlClient.SqlCommand("dbo.ActualizarReporteDiarioNovedad")
        'Comando.CommandType = CommandType.StoredProcedure
        'Comando.Parameters.AddWithValue("@TableRDP", TablaActualizarRDPN)
        'Comando.Parameters.AddWithValue("@IMPRIMIR", "E")
        'Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        'conn.Open()
        'Comando.Connection = conn
        'Comando.ExecuteNonQuery()
        'conn.Close()
        'Me.REPORTENOVEDADTableAdapter.Fill(Ds_ModificarReporteDiario.REPORTENOVEDAD, VariablesBase.VariablesBase.IdProyecto)
        'Me.Lb_errores_integrantes.Text = "Novedades pendientes para imprimir: " + Ds_ModificarReporteDiario.REPORTENOVEDAD.Rows.Count.ToString + "      Nro hojas: " + (Fix(Ds_ModificarReporteDiario.REPORTENOVEDAD.Rows.Count / 26) + 1).ToString
    End Sub

    Private Sub Bt_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Imprimir.Click
        'If Dgv_Novedades.SelectedRows.Count = 0 Then
        '    MsgBox("Seleccione las novedades que desea imprimir", MsgBoxStyle.Information, "Imprimir")
        '    Exit Sub
        'End If
        ''Imprimir novedades


        'Dim climpresiones As New Impresión.Cl_Impresión
        'climpresiones.filasIMPRIMIRREPORTEDIARIOPERSONA = FuncionesBase.FuncionesBase.ExportarDataGridViewADataTable(Me.Dgv_Novedades).Select("", "IdReporte,CODIGOCONTRATO asc")

        'Dim Array As New ArrayList
        'Array.Add(56)
        'climpresiones.FormatosImprimir(Array, IIf(MsgBox("¿Desea ver la vista previa?", MsgBoxStyle.YesNo, "Ver vista previa") = MsgBoxResult.Yes, True, False), False)
        'MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")

        'If MsgBox("¿Desea eliminar las novedades impresas?", MsgBoxStyle.YesNo, "Borrar Novedades") = vbYes Then
        '    'cargar Tablas
        '    Dim TablaActualizarRDPN As New DataTable
        '    TablaActualizarRDPN.Columns.Add("CODIGOCONTRATO")
        '    TablaActualizarRDPN.Columns.Add("IDREPORTEDIARIO")
        '    TablaActualizarRDPN.Columns.Add("IDPROYECTO")
        '    For i = 0 To Dgv_Novedades.SelectedRows.Count - 1
        '        Dim Fila As DataRow
        '        Fila = TablaActualizarRDPN.NewRow
        '        Fila("CODIGOCONTRATO") = Dgv_Novedades.SelectedRows(i).Cells("CODIGOCONTRATODataGridViewTextBoxColumn").Value
        '        Fila("IDREPORTEDIARIO") = Dgv_Novedades.SelectedRows(i).Cells("IdReporteDataGridViewTextBoxColumn").Value
        '        Fila("IDPROYECTO") = VariablesBase.VariablesBase.IdProyecto
        '        TablaActualizarRDPN.Rows.Add(Fila)
        '    Next

        '    'Llamar al procedimiento para actualizar los reportes
        '    Dim adapactualizarreportenovedad As New DatosReporteDiario.Ds_ModificarReporteDiarioTableAdapters.ActualizarReporteDiario

        '    Dim Comando As New SqlClient.SqlCommand("dbo.ActualizarReporteDiarioNovedad")
        '    Comando.CommandType = CommandType.StoredProcedure
        '    Comando.Parameters.AddWithValue("@TableRDP", TablaActualizarRDPN)
        '    Comando.Parameters.AddWithValue("@IMPRIMIR", "I")
        '    Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        '    conn.Open()
        '    Comando.Connection = conn
        '    Comando.ExecuteNonQuery()
        '    conn.Close()

        '    Me.REPORTENOVEDADTableAdapter.Fill(Ds_ModificarReporteDiario.REPORTENOVEDAD, VariablesBase.VariablesBase.IdProyecto)
        '    Me.Lb_errores_integrantes.Text = "Novedades pendientes para imprimir: " + Ds_ModificarReporteDiario.REPORTENOVEDAD.Rows.Count.ToString + "      Nro hojas: " + (Fix(Ds_ModificarReporteDiario.REPORTENOVEDAD.Rows.Count / 26) + 1).ToString

        'End If

    End Sub


End Class