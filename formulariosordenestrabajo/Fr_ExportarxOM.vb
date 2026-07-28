Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Imports Microsoft.Office.Interop
Public Class Fr_ExportarxOM

    Public Tipo As String
    Public TablaId As New DataTable
    Public TablaIdOE As New DataTable
    Public TablaIdE As New DataTable
    Private TEquipos As New DataTable
    Private MensajeError As String
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Dim dsCargar As New DataSet

    Dim anno As Integer
    Dim mes As Integer

    Public Sub CargarTabla()
        Select Case Tipo
            Case "S", "R", "F"
                Dgv_OrdenSap.DataSource = TablaId
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "NROORDENSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Número orden SAP"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Nro SAP"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i
                cb_Año.Visible = False
                cb_Mes.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                Cb_EstadoSAP.Visible = False
            Case "OE"
                Dgv_OrdenSap.DataSource = TablaIdOE
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "NROORDENSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Número orden SAP"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Nro SAP"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i
                Label3.Text = "Fecha Corte:"
                Bt_Aceptar.Text = "Imprimir"
                Rb_BaseActual.Visible = False
                Rb_TodasBases.Visible = False
                Ck_Fechas.Visible = False
                Label2.Visible = False
                Dtp_FechaInicial.Visible = False
                Dtp_FechaFinal.Value = Date.Today
                cb_Año.Visible = False
                cb_Mes.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                Cb_EstadoSAP.Visible = False
            Case "E"
                Dgv_OrdenSap.DataSource = TablaIdE
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "CODIGOEQUIPO"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Código Equipo"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Cód Equipo"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i
                Ck_Fechas.Text = "Ver Vista Previa"
                Ck_Fechas.CheckState = CheckState.Checked
                Label1.Text = "Lista de Códigos"
                Bt_Aceptar.Text = "Imprimir"
                Rb_BaseActual.Visible = False
                Rb_TodasBases.Visible = False
                Cb_EstadoSAP.Visible = False
            Case "I"

                dsCargar = bddatos.CargarMaestras(4, VariablesBase.VariablesBase.IdBaseSiscontrolActual, -1, 1, 0)

                Dgv_OrdenSap.DataSource = TablaId
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "NROORDENSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Número orden SAP"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Nro SAP"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i
                Label3.Text = "Est. SAP:"
                Rb_BaseActual.Visible = False
                Rb_TodasBases.Visible = False
                Ck_Fechas.Visible = False
                Label2.Visible = False
                Dtp_FechaInicial.Visible = False
                Dtp_FechaFinal.Visible = False
                cb_Año.Visible = False
                cb_Mes.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                Bt_AgregarDesdeReportes.Visible = False

                Me.Cb_EstadoSAP.DataSource = dsCargar.Tables(19)
                Me.Cb_EstadoSAP.ValueMember = "TIPO"
                Me.Cb_EstadoSAP.DisplayMember = "NOMBRE"
                Me.Cb_EstadoSAP.SelectedIndex = -1

            Case "OEF"
                Dgv_OrdenSap.DataSource = TablaIdOE
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "NROORDENSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Número orden SAP"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Nro SAP"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i
                Bt_Aceptar.Text = "Imprimir"
                Rb_BaseActual.Visible = False
                Rb_TodasBases.Visible = False
                Ck_Fechas.Visible = False
                Dtp_FechaInicial.Value = Date.Today
                Dtp_FechaFinal.Value = Date.Today
                cb_Año.Visible = False
                cb_Mes.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                Cb_EstadoSAP.Visible = False

        End Select
    End Sub


    Private Sub Bt_LimpiarTabla_Click(sender As Object, e As EventArgs) Handles Bt_LimpiarTabla.Click
        Select Case Tipo
            Case "S", "R", "F", "I"
                TablaId.Clear()
            Case "OE", "OEF"
                TablaIdOE.Clear()
            Case "E"
                TablaIdE.Clear()
        End Select

    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click

        Select Case Tipo
            Case "S"
                If MsgBox("Se procedera a Exportar a Excel El Resumen de Facturación, Este procedimiento puede tardar varios minutos", MsgBoxStyle.YesNo, "Exportar a Excel") = MsgBoxResult.Yes Then
                    ExportarExcel_ResumenFacturacionOTMultiplesHojas()
                End If
            Case "R"
                If MsgBox("Se procedera a Exportar a Excel los reportes de tiempo asociadas a la OM, Este procedimiento puede tardar varios minutos", MsgBoxStyle.YesNo, "Exportar a Excel") = MsgBoxResult.Yes Then
                    ExportarExcel_OTMultiplesHojas()
                End If
            Case "F"
                If MsgBox("Se procedera a Exportar a Excel La Sabana de Facturación, Este procedimiento puede tardar varios minutos", MsgBoxStyle.YesNo, "Exportar a Excel") = MsgBoxResult.Yes Then
                    ExportarExcel_SabanaFacturacionOTMultiplesHojas()
                End If
            Case "I"
                If MsgBox("Se procedera a Exportar a Excel Informe 246, Este procedimiento puede tardar varios minutos", MsgBoxStyle.YesNo, "Exportar a Excel") = MsgBoxResult.Yes Then
                    ExportarExcel_Informe246()
                End If
            Case "OE", "OEF"
                If MsgBox("Se procedera a Imprimir Formato de Reporte Diario de Cantidad de Obra Ejecutada", MsgBoxStyle.YesNo, "Imprimir Formato") = MsgBoxResult.Yes Then
                    Dim listaidot As New ArrayList
                    Dim climpresion As New ImprimirControlProyecto.Cl_Impresión
                    Dim Array As New ArrayList
                    Array.Add(15)
                    climpresion.FechaCorte = Dtp_FechaFinal.Value

                    For i = 0 To TablaIdOE.Rows.Count - 1
                        Dim tempTabla As New DataTable
                        tempTabla.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
                        Dim fila, fila1 As DataRow
                        fila = tempTabla.NewRow
                        fila1 = TablaIdOE.Rows(i)
                        fila(0) = fila1(0)
                        tempTabla.Rows.Add(fila)
                        climpresion.TablaIdOE = tempTabla
                        climpresion.ImprimirFormatos(Array, True, True)
                    Next
                End If
            Case "E"
                If Validar_Reportes() Then
                    If MsgBox("Se procedera a Imprimir Formato de Control Mensual de Transportes", MsgBoxStyle.YesNo, "Imprimir Formato") = MsgBoxResult.Yes Then

                        Dim listaidot As New ArrayList
                        Dim climpresion As New ImprimirControlProyecto.Cl_Impresión
                        Dim Array As New ArrayList
                        Array.Add(16)
                        climpresion.Año = cb_Año.SelectedItem
                        climpresion.Mes = cb_Mes.SelectedItem
                        climpresion.FechaI = Dtp_FechaInicial.Value
                        climpresion.FechaF = Dtp_FechaFinal.Value
                        climpresion.TablaIdE = TablaIdE
                        climpresion.ImprimirFormatos(Array, Ck_Fechas.CheckState, True)

                    End If
                Else
                    Exit Sub
                End If
        End Select

    End Sub

    Public Sub ExportarExcel_OTMultiplesHojas()

        If Ck_Fechas.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si desea filtar por fechas o no", MsgBoxStyle.Information, "Filtrar por fechas")
            Exit Sub
        End If
        Me.TablaId.AcceptChanges()

        'limpiar repetidos en la tabla
        Dim MyView As DataView = New DataView(TablaId)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, "NROORDENSAP")

        If dtSinDuplicados.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim dtPersona As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtEquipos As New DataTable
        Dim dtCostoIndirecto As New DataTable
        Dim dtAvanceObra As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ExpExcelRDxOM", conexion)
        comando.CommandType = CommandType.StoredProcedure
        If Me.Rb_BaseActual.Checked = True Then
            'base actual
            comando.Parameters.AddWithValue("@TIPOBASE", 0)
        Else
            'todas las bases
            comando.Parameters.AddWithValue("@TIPOBASE", 1)
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)

        If Me.Ck_Fechas.CheckState = CheckState.Unchecked Then
            'sin fechas
            comando.Parameters.AddWithValue("@TIPOFECHA", 0)
        Else
            'con fechas
            comando.Parameters.AddWithValue("@TIPOFECHA", 1)
        End If
        comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaInicial.Value)
        comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaFinal.Value)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@TABLAIDOT", dtSinDuplicados)

        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtPersona = dsOT.Tables(0)
                dtMateriales = dsOT.Tables(1)
                dtEquipos = dsOT.Tables(2)
                dtCostoIndirecto = dsOT.Tables(3)
                dtAvanceObra = dsOT.Tables(4)
            Else
                MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para Exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaPersona As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaMateriales As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaEquipos As Excel.Worksheet = objLibroExcel.Worksheets(3)
        Dim objHojaCostoIndirecto As Excel.Worksheet = objLibroExcel.Worksheets(4)
        Dim objHojaAvanceObra As Excel.Worksheet = objLibroExcel.Worksheets(5)

        With objHojaPersona
            .Name = ("Personas")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtPersona.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtPersona.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtPersona.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtPersona.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        With objHojaMateriales
            .Name = "Materiales"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1

            For Each dc As DataColumn In dtMateriales.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtMateriales.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtMateriales.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtMateriales.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        With objHojaEquipos
            .Name = "Equipos"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtEquipos.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtEquipos.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtEquipos.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtEquipos.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaCostoIndirecto
            .Name = "Costo Directo - OS"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtCostoIndirecto.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtCostoIndirecto.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtCostoIndirecto.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtCostoIndirecto.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With
        With objHojaAvanceObra
            .Name = "Avance de Obra"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtAvanceObra.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtAvanceObra.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtAvanceObra.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtAvanceObra.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ExportarExcel_ResumenFacturacionOTMultiplesHojas()

        If Ck_Fechas.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si desea filtar por fechas o no", MsgBoxStyle.Information, "Filtrar por fechas")
            Exit Sub
        End If
        Me.TablaId.AcceptChanges()

        'limpiar repetidos en la tabla
        Dim MyView As DataView = New DataView(TablaId)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, "NROORDENSAP")

        If dtSinDuplicados.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        Dim dtConsolidado As New DataTable
        Dim dtAvance As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ExpExcelResumenFacturacionOT", conexion)
        comando.CommandType = CommandType.StoredProcedure

        If Me.Rb_BaseActual.Checked = True Then
            'base actual
            comando.Parameters.AddWithValue("@TIPOBASE", 0)
        Else
            'todas las bases
            comando.Parameters.AddWithValue("@TIPOBASE", 1)
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)

        If Me.Ck_Fechas.CheckState = CheckState.Unchecked Then
            'sin fechas
            comando.Parameters.AddWithValue("@TIPOFECHA", 0)
        Else
            'con fechas
            comando.Parameters.AddWithValue("@TIPOFECHA", 1)
        End If
        comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaInicial.Value)
        comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaFinal.Value)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@TABLAIDOT", dtSinDuplicados)

        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtConsolidado = dsOT.Tables(0)
                dtAvance = dsOT.Tables(1)
            Else
                MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para Exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        Dim objHojaConsolidado As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaAvance As Excel.Worksheet = objLibroExcel.Worksheets(2)


        With objHojaConsolidado
            .Name = ("Consolidado")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtConsolidado.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtConsolidado.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtConsolidado.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtConsolidado.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        With objHojaAvance
            .Name = "Avance"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1

            For Each dc As DataColumn In dtAvance.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtAvance.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtAvance.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtAvance.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ExportarExcel_SabanaFacturacionOTMultiplesHojas()

        If Ck_Fechas.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si desea filtar por fechas o no", MsgBoxStyle.Information, "Filtrar por fechas")
            Exit Sub
        End If
        Me.TablaId.AcceptChanges()

        'limpiar repetidos en la tabla
        Dim MyView As DataView = New DataView(TablaId)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, "NROORDENSAP")

        If dtSinDuplicados.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        Dim dtSabana As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ExpExcelSabanaFacturacionOT", conexion)
        comando.CommandType = CommandType.StoredProcedure

        If Me.Rb_BaseActual.Checked = True Then
            'base actual
            comando.Parameters.AddWithValue("@TIPOBASE", 0)
        Else
            'todas las bases
            comando.Parameters.AddWithValue("@TIPOBASE", 1)
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)

        If Me.Ck_Fechas.CheckState = CheckState.Unchecked Then
            'sin fechas
            comando.Parameters.AddWithValue("@TIPOFECHA", 0)
        Else
            'con fechas
            comando.Parameters.AddWithValue("@TIPOFECHA", 1)
        End If
        comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaInicial.Value)
        comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaFinal.Value)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@TABLAIDOT", dtSinDuplicados)

        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtSabana = dsOT.Tables(0)

            Else
                MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para Exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaSabana As Excel.Worksheet = objLibroExcel.Worksheets(1)



        With objHojaSabana
            .Name = ("Sabana")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtSabana.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtSabana.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtSabana.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtSabana.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault

        Me.Cursor = Cursors.Default
    End Sub


    Public Sub ExportarExcel_Informe246()

        If Cb_EstadoSAP.SelectedValue = "" Then
            MsgBox("Debe seleccionar el estado SAP", MsgBoxStyle.Information, "Estado SAP")
            Cb_EstadoSAP.Focus()
            Exit Sub
        End If
        Me.TablaId.AcceptChanges()

        'limpiar repetidos en la tabla
        Dim MyView As DataView = New DataView(TablaId)
        Dim dtSinDuplicados As DataTable
        dtSinDuplicados = MyView.ToTable(True, "NROORDENSAP")

        If dtSinDuplicados.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        Dim dtConsolidado As New DataTable
        Dim dtAvance As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ExpExcelInforme246", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@ESTADOSAP", Cb_EstadoSAP.SelectedValue)
        comando.Parameters.AddWithValue("@TABLAIDOT", dtSinDuplicados)

        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtConsolidado = dsOT.Tables(0)
            Else
                MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para Exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaConsolidado As Excel.Worksheet = objLibroExcel.Worksheets(1)

        With objHojaConsolidado
            .Name = ("Consolidado")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtConsolidado.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtConsolidado.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtConsolidado.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtConsolidado.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()

        End With

        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Bt_AgregarOMPortapapeles.Click
        Select Case Tipo
            Case "S", "R", "F", "I"
                Me.Cursor = Cursors.WaitCursor
                Try
                    Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
                    Dim words() As String = Clipboard.GetText().Split(delimiterChars)
                    For i = 0 To words.Length - 1
                        Dim line As String
                        line = Replace(LTrim(RTrim(words(i))), vbLf, "")
                        If line.Length > 0 Then
                            Try
                                Dim fila As DataRow
                                fila = TablaId.NewRow
                                fila("NROORDENSAP") = line
                                TablaId.Rows.Add(fila)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                End Try

            Case "OE", "OEF"
                Me.Cursor = Cursors.WaitCursor
                Try
                    Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
                    Dim words() As String = Clipboard.GetText().Split(delimiterChars)
                    For i = 0 To words.Length - 1
                        Dim line As String
                        line = Replace(LTrim(RTrim(words(i))), vbLf, "")
                        If line.Length > 0 Then
                            Try
                                Dim fila As DataRow
                                fila = TablaIdOE.NewRow
                                fila("NROORDENSAP") = line
                                TablaIdOE.Rows.Add(fila)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                End Try
            Case "E"
                Me.Cursor = Cursors.WaitCursor
                Try
                    Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
                    Dim words() As String = Clipboard.GetText().Split(delimiterChars)
                    For i = 0 To words.Length - 1
                        Dim line As String
                        line = Replace(LTrim(RTrim(words(i))), vbLf, "")
                        If line.Length > 0 Then
                            Try
                                Dim fila As DataRow
                                fila = TablaIdE.NewRow
                                fila("CODIGOEQUIPO") = line
                                TablaIdE.Rows.Add(fila)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub Dgv_OrdenSap_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_OrdenSap.KeyDown
        Dim selectedRowCount1 As Integer = Dgv_OrdenSap.CurrentCell.ColumnIndex

        Select Case e.KeyCode
            Case Windows.Forms.Keys.F3

                Select Case selectedRowCount1 'Buscar equipo
                    Case 0
                        Dim FrBuscarEquipo As New FormulariosClasesBase.Fr_BuscarEquipo

                        FrBuscarEquipo.CargarListaEquipoBase()

                        FrBuscarEquipo.ShowDialog()

                        Dim IDEQUIPO As Integer
                        IDEQUIPO = FrBuscarEquipo.IdEquipo
                        Dim CODIGOEQUIPO As String
                        CODIGOEQUIPO = FrBuscarEquipo.NombreEquipo

                        If ValidarItemsRDEquipo(CODIGOEQUIPO, -1) = True Then
                            Dim FilasContratos As DataRow()
                            Dim equipos As New DataTable()
                            Dim Cadena_Consulta As String = "SELECT * FROM dbo.detalleEquipo('" & CODIGOEQUIPO & "'," & VariablesBase.VariablesBase.IdBaseSiscontrolActual & ")"
                            Dim Consulta As New SqlCommand(Cadena_Consulta)
                            Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                            Consulta.Connection = Conexión
                            Dim Adaptador As New SqlDataAdapter(Consulta)
                            Consulta.Connection.Open()
                            Adaptador.FillSchema(equipos, SchemaType.Source)
                            Adaptador.Fill(equipos)
                            Consulta.Connection.Close()
                            FilasContratos = equipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "'")
                            If FilasContratos.Length > 0 Then '
                                Dim FilaContrato As DataRow
                                FilaContrato = FilasContratos(0)
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TEquipos.NewRow
                                NuevaFilaItem("CODIGOEQUIPO") = FilaContrato("CODIGOEQUIPO")
                                TEquipos.Rows.Add(NuevaFilaItem) '
                            Else
                                'No existe un artículo con este código
                                MensajeError = "No se encontró un equipo con ese código"
                                MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Equipo no Encontrado")
                                Dim NuevaFilaItem As DataRow
                                NuevaFilaItem = TEquipos.NewRow
                                NuevaFilaItem("CODIGOEQUIPO") = CODIGOEQUIPO
                                TEquipos.Rows.Add(NuevaFilaItem)
                            End If
                        Else
                            MensajeError = "El item que desea ingresar, ya se encuentra incluido en el reporte diario"
                            MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                        End If

                        ELiminarFilaVacia("E")
                End Select
            Case Windows.Forms.Keys.Delete

                Try
                    If Me.Dgv_OrdenSap.SelectedRows Is Nothing Then Exit Sub

                    Dim selectedRowCount As Integer = Dgv_OrdenSap.Rows.GetRowCount(DataGridViewElementStates.Selected)
                    For I As Integer = 0 To selectedRowCount - 1
                        Me.Dgv_OrdenSap.Rows.Remove(Dgv_OrdenSap.SelectedRows(0))
                    Next
                Catch
                End Try

                Try
                    TEquipos.AcceptChanges() 'LISTAITEMREQUISICION
                Catch
                End Try

                For x As Integer = 0 To TEquipos.Rows.Count - 1
                    If Not IsDBNull(TEquipos.Rows(x).Item(0)) Then 'LISTAITEMREQUISICION
                        TEquipos.Rows(x).Item(0) = x + 1 'LISTAITEMREQUISICION
                    End If
                Next

                ELiminarFilaVacia("E")
        End Select
    End Sub

    Private Function ValidarItemsRDEquipo(ByVal CODIGOEQUIPO As String, ByVal Orden As Integer) As Boolean
        Dim filas As DataRow()
        If Orden = -1 Then
            filas = TEquipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "'") 'LISTAITEMREQUISICION
        Else
            filas = TEquipos.Select("CODIGOEQUIPO='" + CODIGOEQUIPO + "' AND ORDEN<>" + Orden.ToString) 'LISTAITEMREQUISICION
        End If
        If filas.Length > 0 Then
            ValidarItemsRDEquipo = False
            Exit Function
        End If
        ValidarItemsRDEquipo = True
    End Function

    Private Sub ELiminarFilaVacia(ByVal tipo As String)
        Try
            Select Case tipo
                Case "E"
                    For i = 0 To Dgv_OrdenSap.Rows.Count - 2
                        If IsDBNull(Me.Dgv_OrdenSap.Rows(i).Cells("CODIGOEQUIPO").Value) Then
                            Me.Dgv_OrdenSap.Rows.RemoveAt(i)
                        End If
                    Next

            End Select
        Catch
        End Try
    End Sub


    Private Sub Dgv_OrdenSap_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Dgv_OrdenSap.RowsAdded

        Select Case Tipo
            Case "E"
                Me.Lb_TotalSAP.Text = "Total Equipos: " + (Me.Dgv_OrdenSap.Rows.Count - 1).ToString
            Case Else
                Me.Lb_TotalSAP.Text = "Total Ordenes: " + (Me.Dgv_OrdenSap.Rows.Count - 1).ToString
        End Select

    End Sub

    Private Sub Dgv_OrdenSap_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Dgv_OrdenSap.RowsRemoved

        Select Case Tipo
            Case "E"
                Me.Lb_TotalSAP.Text = "Total Equipos: " + (Me.Dgv_OrdenSap.Rows.Count - 1).ToString
            Case Else
                Me.Lb_TotalSAP.Text = "Total Ordenes: " + (Me.Dgv_OrdenSap.Rows.Count - 1).ToString
        End Select
    End Sub


    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_AgregarDesdeReportes_Click(sender As Object, e As EventArgs) Handles Bt_AgregarDesdeReportes.Click

        Select Case Tipo
            Case "S", "R", "F"
                If Ck_Fechas.CheckState = CheckState.Indeterminate Or Ck_Fechas.CheckState = CheckState.Unchecked Then
                    MsgBox("Debe seleccionar un rango de fechas para los reportes de tiempo", MsgBoxStyle.Information, "Filtrar por fechas")
                    Exit Sub
                End If

                Me.TablaId.AcceptChanges()
            Case "OE", "OEF"
                Me.TablaIdOE.AcceptChanges()
            Case "E"
                Me.TablaIdE.AcceptChanges()
        End Select

        Select Case Tipo
            Case "S", "R", "F", "OE"
        If MsgBox("Se procedera a adicionar los Nro Orden SAP de los reportes de Tiempo, entre las fechas selecionadas y la base actual.", MsgBoxStyle.YesNo, "Reportes Tiempo") = MsgBoxResult.Yes Then

            Me.Cursor = Cursors.WaitCursor

            Dim dtReportes As New DataTable
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ExpExcelRDxOM", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@TIPOBASE", 3) ' Se envia para que el procedimento devuelva las ordenes de mantenimieto asociadas
            comando.Parameters.AddWithValue("@TIPOFECHA", DBNull.Value)
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            Select Case Tipo
                        Case "S", "R", "F", "OEF"
                            comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaInicial.Value)
                            comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaFinal.Value)
                        Case "OE"
                            comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaFinal.Value)
                            comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaFinal.Value)
                    End Select
            comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Select Case Tipo
                        Case "S", "R", "F", "OEF"
                            comando.Parameters.AddWithValue("@TABLAIDOT", TablaId)
                Case "OE"
                    comando.Parameters.AddWithValue("@TABLAIDOT", TablaIdOE)
            End Select

            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsRD As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
            Try
                conexion.Open()
                adaptador.Fill(dsRD)
                conexion.Close()
                If dsRD.Tables.Count > 0 Then
                    dtReportes = dsRD.Tables(0)
                Else
                    MsgBox("No se encontraron los Nro de orden Sap en los Reportes de Tiempo.", MsgBoxStyle.Information, "Nro Orden SAP")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("No se cargaron los Nro de Orden SAP", MsgBoxStyle.Critical, "Error con Nro de Orden SAP")
                Exit Sub
            Finally
                conexion.Close()
            End Try
        Select Case Tipo
            Case "S", "R", "F"
                For i = 0 To dtReportes.Rows.Count - 1
                    Dim filard As DataRow
                    filard = dtReportes.Rows(i)
                    Dim fila As DataRow
                    fila = TablaId.NewRow
                    fila("NROORDENSAP") = filard(0)
                    TablaId.Rows.Add(fila)
                Next
                        Case "OE", "OEF"
                            For i = 0 To dtReportes.Rows.Count - 1
                                Dim filard As DataRow
                                filard = dtReportes.Rows(i)
                                Dim fila As DataRow
                                fila = TablaIdOE.NewRow
                                fila("NROORDENSAP") = filard(0)
                                TablaIdOE.Rows.Add(fila)
                            Next
                    End Select
                    Me.Cursor = Cursors.Default
                End If

            Case "E"
                If MsgBox("Se procedera a adicionar los Códigos de Equipos de los reportes de Tiempo, entre el año y mes selecionado", MsgBoxStyle.YesNo, "Reportes Tiempo") = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim dtDetalle As New DataTable
                    Dim conexion1 As New SqlConnection(My.Settings.CadenaConexión)
                    Dim cmdE As New SqlCommand("dbo.ControlVehiculo", conexion1)
                    cmdE.CommandType = CommandType.StoredProcedure
                    cmdE.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                    cmdE.Parameters.AddWithValue("@AÑO", cb_Año.SelectedItem)
                    cmdE.Parameters.AddWithValue("@MES", cb_Mes.SelectedItem)
                    cmdE.Parameters.AddWithValue("@TIPO", 1)
                    cmdE.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                    cmdE.Parameters.AddWithValue("@FECHAI", Dtp_FechaInicial.Value)
                    cmdE.Parameters.AddWithValue("@FECHAF", Dtp_FechaFinal.Value)
                    cmdE.Parameters.AddWithValue("@TABLAIDE", TablaIdE)
                    Dim adaptador1 As New SqlDataAdapter(cmdE)
                    Dim dsE As New DataSet
                    Try
                        conexion1.Open()
                        adaptador1.Fill(dsE)
                        conexion1.Close()
                        If dsE.Tables.Count > 0 Then
                            dtDetalle = dsE.Tables(0)
                        Else
                            MsgBox("No se encontraron los Códigos de los equipos en los Reportes de Tiempo.", MsgBoxStyle.Information, "Código Equipo")
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MsgBox("No se cargaron los Códigos de Equipo", MsgBoxStyle.Critical, "Error con Código de Equipo")
                        Exit Sub
                    Finally
                        conexion1.Close()
                    End Try

                    For i = 0 To dtDetalle.Rows.Count - 1
                        Dim filard As DataRow
                        filard = dtDetalle.Rows(i)
                        Dim fila As DataRow
                        fila = TablaIdE.NewRow
                        fila("CODIGOEQUIPO") = filard(0)
                        TablaIdE.Rows.Add(fila)
                    Next
                    Me.Cursor = Cursors.Default
                End If
        End Select

    End Sub

    Public Shared Function CompararFechas(ByVal FECHAINICIAL As Date, ByVal FECHAFIN As Date) As Integer
        Dim TFECHAINICIAL As New Date(FECHAINICIAL.Year, FECHAINICIAL.Month, FECHAINICIAL.Day)
        Dim TFECHAFINAL As New Date(FECHAFIN.Year, FECHAFIN.Month, FECHAFIN.Day)
        Select Case DateDiff(DateInterval.Day, TFECHAINICIAL, TFECHAFINAL)
            Case 0
                CompararFechas = 0
                Exit Function
            Case Is > 0
                CompararFechas = 1
                Exit Function
            Case Is < 0
                CompararFechas = -1
                Exit Function
        End Select
        CompararFechas = 2
    End Function

    Private Function Validar_Reportes() As Boolean
        If CompararFechas(Dtp_FechaFinal.Value, Dtp_FechaInicial.Value) = 1 Then
            MsgBox("La fecha  final es inferior a la fecha inicial.", MsgBoxStyle.Information, "FECHA FINAL")
            Dtp_FechaInicial.Focus()
            Validar_Reportes = False
            Exit Function
        End If
        Validar_Reportes = True
    End Function
    Private Sub Fr_ExportarxOM_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case Tipo
            Case "E"
                Me.cb_Año.SelectedItem = Date.Now.Year.ToString

                If Date.Now.Month.ToString.Length = 1 Then
                    Me.cb_Mes.SelectedItem = "0" + Date.Now.Month.ToString
                Else
                    Me.cb_Mes.SelectedItem = Date.Now.Month.ToString
                End If
                ActualizarRangoFechas(Me.cb_Año.SelectedItem, cb_Mes.SelectedItem)
        End Select
    End Sub

    Private Sub cb_Año_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Año.SelectedIndexChanged
        Select Case Tipo
            Case "E"
                ActualizarRangoFechas(cb_Año.SelectedItem, cb_Mes.SelectedItem)
        End Select
    End Sub

    Private Sub cb_Mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Mes.SelectedIndexChanged
        Select Case Tipo
            Case "E"
                ActualizarRangoFechas(cb_Año.SelectedItem, cb_Mes.SelectedItem)
        End Select

    End Sub

    Private Sub ActualizarRangoFechas(ByVal año As Integer, ByVal mes As Integer)
        Select Case Tipo
            Case "E", "OEF"
                Dim FechaInicial As Date
                Dim FechaFinal As Date

                Try

                    Dtp_FechaInicial.MaxDate = "01/01/2030"
                    Dtp_FechaInicial.MinDate = "01/01/2018"
                    Dtp_FechaFinal.MaxDate = "01/01/2030"
                    Dtp_FechaFinal.MinDate = "01/01/2018"


                    FechaInicial = New Date(año, mes, 1)

                    FechaFinal = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, FechaInicial))

                    Dtp_FechaInicial.MaxDate = FechaFinal
                    Dtp_FechaInicial.MinDate = FechaInicial
                    Dtp_FechaInicial.Value = FechaInicial

                    Dtp_FechaFinal.MaxDate = FechaFinal
                    Dtp_FechaFinal.MinDate = FechaInicial
                    Dtp_FechaFinal.Value = FechaFinal

                    Dtp_FechaInicial.Enabled = True
                    Dtp_FechaFinal.Enabled = True
                    Me.Bt_Aceptar.Enabled = True

                Catch ex As Exception
                    Dtp_FechaInicial.Enabled = False
                    Dtp_FechaFinal.Enabled = False
                    Me.Bt_Aceptar.Enabled = False
                End Try

        End Select


    End Sub

End Class