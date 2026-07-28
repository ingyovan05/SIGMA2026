Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_CrearReportesDiario

    Private Sub Fr_CrearReportesDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dgv_CuadrillasCrearReporte.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_CuadrillasCrearReporte.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        'TODO: esta línea de código carga datos en la tabla 'Ds_CrearReporte.LISTAFRENTECREARREPORTE' Puede moverla o quitarla según sea necesario.



        CREARDataGridViewCheckBoxColumn.ReadOnly = False
    End Sub

    Dim ListaReporte As New ArrayList

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim CantSinFrente As Integer = FuncionesBase.FuncionesBase.ConsultarEquipoEnFrentesSinPersonasl(VariablesBase.VariablesBase.IdProyecto)

        'If CantSinFrente > 0 Then
        '    MsgBox("Hay " + CantSinFrente.ToString + " equipos en frentes sin personal, no se puede continuar hasta ubicarlos en frente con personal", MsgBoxStyle.Information, "Sin Frente de Trabajo")
        '    Exit Sub
        'End If


        ''Verificar que no se encuentren personas contratadas sin frente
        'CantSinFrente = FuncionesBase.FuncionesBase.ConsultarCantPersonasSinFrente(VariablesBase.VariablesBase.IdProyecto)

        'If CantSinFrente > 0 Then
        '    If MsgBox("Hay " + CantSinFrente.ToString + " personas contratadas sin frente de trabajo, ¿Desea continuar?", MsgBoxStyle.YesNo, "Sin Frente de Trabajo") = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If



        'Windows.Forms.Cursor.Current = Cursors.WaitCursor
        'ListaReporte.Clear()
        'Dim Fecha As New Date(Mc_FechaReporte.SelectionRange.End.Year, Mc_FechaReporte.SelectionRange.End.Month, Mc_FechaReporte.SelectionRange.End.Day, 23, 59, 59)
        ''Recorrer la tabla verificar los marcados y crear un registro en la tabla REPORTEDIARIO
        'Dim i As Integer
        'Dim StringFrente As String = ","
        'For i = 0 To Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE.Rows.Count - 1
        '    Dim fila As DataRow = Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE.Rows(i)
        '    If fila("CREAR") = "S" Then
        '        StringFrente = StringFrente + "," + CStr(fila("IDFRENTETRABAJO"))
        '    End If
        'Next
        'StringFrente = Replace(StringFrente, ",,", "")
        ''Que al menos exista uno para crear
        'If StringFrente = "," Then
        '    Exit Sub
        'End If
        ''Llamar al procedimiento para generar los reportes
        'Dim adapcrearrreporte As New DatosReporteDiario.Ds_CrearReporteTableAdapters.CrearReportesTableAdapter
        'Dim Comando As New SqlClient.SqlCommand("dbo.CrearReportes")
        'Comando.CommandType = CommandType.StoredProcedure
        'Comando.Parameters.AddWithValue("@Parametros", StringFrente)
        'Comando.Parameters.AddWithValue("@FechaReporte", Me.Mc_FechaReporte.SelectionRange.End)
        'Comando.Parameters.AddWithValue("@IDPROYECTO", VariablesBase.VariablesBase.IdProyecto)
        'Comando.Parameters.AddWithValue("@IDPERSONAUSUARIO", VariablesBase.VariablesBase.IdPersona)
        'Comando.Parameters.AddWithValue("@CREARREPORTESVACIOS", IIf(Ck_IncluirFrentesSinIntegrates.Checked = True, 1, 0))
        'Dim msgParam As New SqlParameter("@msg", SqlDbType.VarChar, 1000)
        'msgParam.Direction = ParameterDirection.Output
        'Comando.Parameters.Add(msgParam)
        'Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        'conn.Open()
        'Comando.Connection = conn
        'Comando.ExecuteNonQuery()
        'conn.Close()
        ''sacar los reportes generados para imprimir

        'Dim cadenacodigos As String = CStr(Comando.Parameters("@msg").Value)


        'While cadenacodigos.IndexOf(",") <> -1
        '    Dim pos As Integer = cadenacodigos.IndexOf(",")
        '    ListaReporte.Add(Mid(cadenacodigos, 1, pos))
        '    cadenacodigos = Mid(cadenacodigos, pos + 2, cadenacodigos.Length - pos)
        'End While



        'Windows.Forms.Cursor.Current = Cursors.Default

        ''Sugerir la impresión de los reportes creados
        'If ListaReporte.Count > 0 Then
        '    If MsgBox("Se crearon los reportes diarios exitosamente, ¿Desea imprimir los reportes?", MsgBoxStyle.YesNo, "Imprimir reportes diarios") = MsgBoxResult.Yes Then
        '        Dim climpresiones As New Impresión.Cl_Impresión
        '        climpresiones.ListaReporte = ListaReporte
        '        climpresiones.contreporte = 0
        '        Dim Array As New ArrayList
        '        Array.Add(33)
        '        climpresiones.FormatosImprimir(Array, Cb_VistaPrevia.Checked, Cb_DobleCara.Checked)
        '        MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        '    End If
        'End If

        'Me.Close()
    End Sub

    Private Sub Mc_FechaReporte_DateSelected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles Mc_FechaReporte.DateSelected
        'Me.LISTAFRENTECREARREPORTETableAdapter.Fill(Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE, VariablesBase.VariablesBase.IdProyecto, Mc_FechaReporte.SelectionRange.End)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Dgv_CuadrillasCrearReporte_RowPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles Dgv_CuadrillasCrearReporte.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If Dgv_CuadrillasCrearReporte.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_CuadrillasCrearReporte.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Dim i As Integer
        'Try
        '    For i = 0 To Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE.Rows.Count - 1
        '        Dim fila As DataRow = Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE.Rows(i)
        '        fila("CREAR") = "S"
        '    Next
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'Dim i As Integer
        'Try
        '    For i = 0 To Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE.Rows.Count - 1
        '        Dim fila As DataRow = Me.Ds_CrearReporte.LISTAFRENTECREARREPORTE.Rows(i)
        '        fila("CREAR") = "N"
        '    Next
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub Mc_FechaReporte_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles Mc_FechaReporte.DateChanged

    End Sub
End Class