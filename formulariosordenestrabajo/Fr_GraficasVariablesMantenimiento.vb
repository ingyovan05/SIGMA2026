Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Fr_GraficasVariablesMantenimiento

    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private conexion As New SqlConnection()
    Private dsMaestras As DataSet

    Private Sub CargaInicial()

        conexion = New SqlConnection(My.Settings.CadenaConexión)


        comando = New SqlCommand("dbo.CargarMaestrasCalidad", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdBase", SqlDbType.Int)
        comando.Parameters("@Accion").Value = 1
        comando.Parameters("@IdBase").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        adaptador = New SqlDataAdapter(comando)
        dsMaestras = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaestras)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Cb_Año.DataSource = dsMaestras.Tables(0)
        Cb_Año.DisplayMember = "AÑO"
        Cb_Año.ValueMember = "AÑO"

        Dim vistames As DataView
        vistames = New DataView(dsMaestras.Tables(1))
        vistames.RowFilter = "AÑO=" + Cb_Año.SelectedValue.ToString

        Cb_Mes.DataSource = vistames
        Cb_Mes.DisplayMember = "NOMBREMES"
        Cb_Mes.ValueMember = "MES"

        GraficarAvance(Cb_Año.SelectedValue.ToString)


        GraficarTipoMantenimientoEmergencia(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
        GraficarTipoMantenimientoPreventivo(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
        GraficarTipoMantenimientoCorrectivo(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
        GraficarTipoMantenimientoBasadoCondición(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
        CargarDatosMesProgrmación(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)

    End Sub


    Private Sub GraficarAvance(ByVal AÑO As String)

        Dim datos As DataTable
        datos = dsMaestras.Copy.Tables(2)

        Try
            datos.Columns.Remove("Febrero")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Marzo")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Abril")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Mayo")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Junio")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Julio")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Agosto")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Septiembre")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Octubre")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Noviembre")
        Catch ex As Exception
        End Try
        Try
            datos.Columns.Remove("Diciembre")
        Catch ex As Exception
        End Try
       

        Dim data As DataView
        data = New DataView(datos)
        data.RowFilter = "AÑO=" + AÑO
        Chart_AvanceMantenimiento.Series.Clear()
        Chart_AvanceMantenimiento.DataBindCrossTable(data, "TIPO", "NOMBREMES", "AVANCE", "")
        Chart_AvanceMantenimiento.Legends(0).Title = "Tipo Mantenimiento"

        'Chart_AvanceMantenimiento.DataSource = data
        'Chart_AvanceMantenimiento.Series("Series1").XValueMember = "NOMBREMES"
        'Chart_AvanceMantenimiento.Series("Series1").YValueMembers = "AVANCE"


        Dim datos1 As DataTable
        datos1 = dsMaestras.Copy.Tables(3)

        Dim NroMes As Integer
        NroMes = datos.Compute("MAX(MES)", "")


        'For i = 0 To datos.Columns.Count - 1
        '    Select Case datos.Columns(i).ColumnName
        '        Case "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        '            If datos.Columns.Contains(datos.Columns(i).ColumnName) = False Then
        '                'no ha encontrado la columna
        '                datos1.Columns.Remove(datos.Columns(i).ColumnName)
        '            End If
        '    End Select
        'Next

        If CInt(NroMes) < 2 Then
            datos1.Columns.Remove("Febrero")
        End If

        If CInt(NroMes) < 3 Then
            datos1.Columns.Remove("Marzo")
        End If

        If CInt(NroMes) < 4 Then
            datos1.Columns.Remove("Abril")
        End If

        If CInt(NroMes) < 5 Then
            datos1.Columns.Remove("Mayo")
        End If

        If CInt(NroMes) < 6 Then
            datos1.Columns.Remove("Junio")
        End If

        If CInt(NroMes) < 7 Then
            datos1.Columns.Remove("Julio")
        End If

        If CInt(NroMes) < 8 Then
            datos1.Columns.Remove("Agosto")
        End If

        If CInt(NroMes) < 9 Then
            datos1.Columns.Remove("Septiembre")
        End If

        If CInt(NroMes) < 10 Then
            datos1.Columns.Remove("Octubre")
        End If

        If CInt(NroMes) < 11 Then
            datos1.Columns.Remove("Noviembre")
        End If

        If CInt(NroMes) < 12 Then
            datos1.Columns.Remove("Diciembre")
        End If



        Dim dataavance As DataView
        dataavance = New DataView(datos1)
        dataavance.RowFilter = "AÑO=" + AÑO
        Dgv_AvanceEjecución.DataSource = dataavance
        Dgv_AvanceEjecución.AutoGenerateColumns = True
        Dgv_AvanceEjecución.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        'Falta aplicar todo el estilo



        'Dim serie As New Series()
        'For Each dr In data
        '    Dim y As Integer
        '    y = dr("AVANCE")
        '    serie.Points.AddXY(dr("MES").ToString(), y)
        'Next dr
        'serie.Name = "AVANCE"
        'Chart_AvanceMantenimiento.Series.Add(serie)

        ''Dim serie1 As New Series()
        ''For Each dr In data
        ''    Dim y As Integer
        ''    y = dr("PROGRAMADO")
        ''    serie1.Points.AddXY(dr("TIPO").ToString(), y)
        ''Next dr
        ''serie1.Name = "PROGRAMADO"
        ''Chart_AvanceMantenimiento.Series.Add(serie1)

        ' Chart_AvanceMantenimiento.Titles.Add("TIPO MANTENIMIENTO")

        'Chart_AvanceMantenimiento.ChartAreas(0).AxisX.MajorGrid.Enabled = False  'quitar o colocar lineas verticales

        'Chart_AvanceMantenimiento.Series(0).IsValueShownAsLabel = True 'colocar valores en las barras
        'Chart_AvanceMantenimiento.Series(1).IsValueShownAsLabel = True


    End Sub

    Private Sub GraficarTipoMantenimientoEmergencia(ByVal AÑO As String, ByVal MES As String)

        Dim data As DataView
        data = New DataView(dsMaestras.Tables(2))
        data.RowFilter = "MES<=" + MES + " AND AÑO=" + AÑO + " AND TIPO='Emergencias'"

        Chart_Emergencias.Series.Clear()
        Dim serie As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("EJECUTADO")
            serie.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie.Name = "EJECUTADO"
        Chart_Emergencias.Series.Add(serie)

        Dim serie1 As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("PROGRAMADO")
            serie1.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie1.Name = "PROGRAMADO"
        Chart_Emergencias.Series.Add(serie1)
        Chart_Emergencias.Titles.Clear()
        Chart_Emergencias.Titles.Add("EMERGENCIAS")
        Chart_Emergencias.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart_Emergencias.Series(0).IsValueShownAsLabel = True
        Chart_Emergencias.Series(1).IsValueShownAsLabel = True
    End Sub


    Private Sub GraficarTipoMantenimientoPreventivo(ByVal AÑO As String, ByVal MES As String)

        Dim data As DataView
        data = New DataView(dsMaestras.Tables(2))
        data.RowFilter = "MES<=" + MES + " AND AÑO=" + AÑO + " AND TIPO='Mto. Preventivo'"

        Chart_Preventivo.Series.Clear()
        Dim serie As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("EJECUTADO")
            serie.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie.Name = "EJECUTADO"
        Chart_Preventivo.Series.Add(serie)

        Dim serie1 As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("PROGRAMADO")
            serie1.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie1.Name = "PROGRAMADO"

        Chart_Preventivo.Series.Add(serie1)
        Chart_Preventivo.Titles.Clear()
        Chart_Preventivo.Titles.Add("MANTENIMIENTO PREVENTIVO")
        Chart_Preventivo.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart_Preventivo.Series(0).IsValueShownAsLabel = True
        Chart_Preventivo.Series(1).IsValueShownAsLabel = True
    End Sub

    Private Sub GraficarTipoMantenimientoCorrectivo(ByVal AÑO As String, ByVal MES As String)

        Dim data As DataView
        data = New DataView(dsMaestras.Tables(2))
        data.RowFilter = "MES<=" + MES + " AND AÑO=" + AÑO + " AND TIPO='Mto. Correctivo'"

        Chart_Correctivo.Series.Clear()
        Dim serie As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("EJECUTADO")
            serie.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie.Name = "EJECUTADO"
        Chart_Correctivo.Series.Add(serie)

        Dim serie1 As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("PROGRAMADO")
            serie1.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie1.Name = "PROGRAMADO"

        Chart_Correctivo.Series.Add(serie1)
        Chart_Correctivo.Titles.Clear()
        Chart_Correctivo.Titles.Add("MANTENIMIENTO CORRECTIVO")
        Chart_Correctivo.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart_Correctivo.Series(0).IsValueShownAsLabel = True
        Chart_Correctivo.Series(1).IsValueShownAsLabel = True
    End Sub


    Private Sub GraficarTipoMantenimientoBasadoCondición(ByVal AÑO As String, ByVal MES As String)

        Dim data As DataView
        data = New DataView(dsMaestras.Tables(2))
        data.RowFilter = "MES<=" + MES + " AND AÑO=" + AÑO + " AND TIPO='Mto. Basado en condición'"

        Chart_BasadoCondición.Series.Clear()
        Dim serie As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("EJECUTADO")
            serie.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie.Name = "EJECUTADO"
        Chart_BasadoCondición.Series.Add(serie)

        Dim serie1 As New Series()
        For Each dr In data
            Dim y As Integer
            y = dr("PROGRAMADO")
            serie1.Points.AddXY(dr("MES").ToString(), y)
        Next dr
        serie1.Name = "PROGRAMADO"

        Chart_BasadoCondición.Series.Add(serie1)
        Chart_BasadoCondición.Titles.Clear()
        Chart_BasadoCondición.Titles.Add("MANTENIMIENTO BASADO EN CONDICIÓN")
        Chart_BasadoCondición.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart_BasadoCondición.Series(0).IsValueShownAsLabel = True
        Chart_BasadoCondición.Series(1).IsValueShownAsLabel = True
    End Sub

    Private Sub Cb_Año_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Año.SelectedIndexChanged
        Try
            Dim vistames As DataView
            vistames = New DataView(dsMaestras.Tables(1))
            vistames.RowFilter = "AÑO=" + Cb_Año.SelectedValue.ToString

            Cb_Mes.DataSource = vistames
            Cb_Mes.DisplayMember = "NOMBREMES"
            Cb_Mes.ValueMember = "MES"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarDatosMesProgrmación(ByVal AÑO As String, ByVal MES As String)
        Dim datos As DataTable
        datos = dsMaestras.Copy.Tables(4)


        If CInt(MES) < 2 Then
            datos.Columns.Remove("Febrero")
        End If

        If CInt(MES) < 3 Then
            datos.Columns.Remove("Marzo")
        End If

        If CInt(MES) < 4 Then
            datos.Columns.Remove("Abril")
        End If

        If CInt(MES) < 5 Then
            datos.Columns.Remove("Mayo")
        End If

        If CInt(MES) < 6 Then
            datos.Columns.Remove("Junio")
        End If

        If CInt(MES) < 7 Then
            datos.Columns.Remove("Julio")
        End If

        If CInt(MES) < 8 Then
            datos.Columns.Remove("Agosto")
        End If

        If CInt(MES) < 9 Then
            datos.Columns.Remove("Septiembre")
        End If

        If CInt(MES) < 10 Then
            datos.Columns.Remove("Octubre")
        End If

        If CInt(MES) < 11 Then
            datos.Columns.Remove("Noviembre")
        End If

        If CInt(MES) < 12 Then
            datos.Columns.Remove("Diciembre")
        End If

        datos.AcceptChanges()
        Dim data As DataView
        data = New DataView(datos)
        data.RowFilter = "Año=" + AÑO
        Dgv_Programación.DataSource = data
        Dgv_Programación.AutoGenerateColumns = True
        Dgv_Programación.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells


    End Sub

    Private Sub Fr_GraficasVariablesMantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaInicial()
    End Sub

    Private Sub Cb_Mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Mes.SelectedIndexChanged
        Try
            GraficarAvance(Cb_Año.SelectedValue.ToString)

            GraficarTipoMantenimientoEmergencia(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
            GraficarTipoMantenimientoPreventivo(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
            GraficarTipoMantenimientoCorrectivo(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
            GraficarTipoMantenimientoBasadoCondición(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)
            CargarDatosMesProgrmación(Cb_Año.SelectedValue.ToString, Cb_Mes.SelectedValue.ToString)

        Catch ex As Exception

        End Try

    End Sub

End Class