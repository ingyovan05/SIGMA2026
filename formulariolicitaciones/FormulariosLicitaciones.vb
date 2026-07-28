Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

''' <summary>
''' Contiene las estructuras e implementaciones comunes a los formularios del módulo Licitaciones.
''' </summary>
Public Class FormulariosLicitaciones
    ''' <summary>
    ''' Indica el tipo de recurso que se gestiona.
    ''' </summary>
    Public Enum TipoRecurso
        Licitacion
        Material
        MaquinariaEquipo
        ManoDeObra
    End Enum

    ''' <summary>
    ''' Indica el tipo de permiso de acceso que se otorga a los usuarios sobre las licitaciones.
    ''' </summary>
    Public Structure TipoPermiso
        ''' <summary>
        ''' Permiso de escritura. Permite gestionar los datos de la licitación y los Ítems A.P.U.
        ''' </summary>
        Const Escritura As String = "E"
        ''' <summary>
        ''' Permiso de lectura. Permite visualizar los datos de la licitación y los Ítems A.P.U. No permite gestionar los datos.
        ''' </summary>
        Const Lectura As String = "L"
    End Structure

    ''' <summary>
    ''' Indica el tipo de gestión que se realiza a un recurso.
    ''' </summary>
    Public Enum TipoEdicion
        ''' <summary>
        ''' Indica que se crea un nuevo recurso.
        ''' </summary>
        Crear
        ''' <summary>
        ''' Indica que se visualizan los datos del recurso.
        ''' </summary>
        Ver
        ''' <summary>
        ''' Indica que se edita un recurso.
        ''' </summary>
        Editar
        ''' <summary>
        ''' Indica que se duplica un recurso.
        ''' </summary>
        Clonar
    End Enum

#Region "Exportar a Excel"

    ''' <summary>
    ''' Contiene las cadenas de formatos usados en la exportación a archivo Xls.
    ''' </summary>
    Private Structure XlFormat
        ''' <summary>
        ''' General
        ''' </summary>
        Const General As String = "General"
        ''' <summary>
        ''' Número
        ''' </summary>
        Const Number As String = "#,##0.0#"
        ''' <summary>
        ''' Moneda
        ''' </summary>
        Const Currency As String = "_-$ * #,##0_-;-$ * #,##0_-;_-$ * ""-""_-;_-@_-" '"_($ * #.##0_);_($ * (#.##0);_($ * "" - ""??_);_(@_)"
        ''' <summary>
        ''' Contabilidad
        ''' </summary>
        Const Accounting As String = "_-$ * #,##0_-;-$ * #,##0_-;_-$ * "" - ""_-;_-@_-"
        ''' <summary>
        ''' Fecha corta
        ''' </summary>
        Const DateShort As String = "d/MM/yyyy"
        ''' <summary>
        ''' Fecha larga
        ''' </summary>
        Const DateLong As String = "dddd, d ""de"" MMMM ""de"" yyyy"
        ''' <summary>
        ''' Hora
        ''' </summary>
        Const Time As String = "h:mm AM/PM"
        ''' <summary>
        ''' Porcentaje
        ''' </summary>
        Const Percentage As String = "0.##%"
        ''' <summary>
        ''' Fracción
        ''' </summary>
        Const Fraction As String = "# ??/??"
        ''' <summary>
        ''' Científica
        ''' </summary>
        Const Scientific As String = "0,0#E+#0"
        ''' <summary>
        ''' Texto
        ''' </summary>
        Const Text As String = "@"
        ' Especial
        'Const Special As String = "Special"

        ' Personalizada
        'Const Custom As String = ""
    End Structure


    ''' <summary>
    ''' Exporta el listado de Ítems A.P.U. de la licitación a una ventana de la aplicación MS Excel.
    ''' </summary>
    ''' <param name="idLicitacion"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportarExcel_ListadoDePrecios(Optional idLicitacion As Integer = -1)
        Dim costoDirecto As Decimal = 0
        Dim porcentajeAdministracion As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim porcentajeImprevistos As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim porcentajeUtilidad As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim totalCosto As Decimal = 0
        Dim dtLicitacion As New DataTable
        Dim dtItemsAPU As New DataTable
        Dim drLicitacion As DataRow

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImprExpLIC_ListadoDePrecios", conexion) 'LIC_ExportarItems
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 0) 'Ítems sin A.I.U.
        If idLicitacion > 0 Then
            comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        ElseIf VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
            comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        Else
            MsgBox("No se encontró ninguna licitación seleccionada.", MsgBoxStyle.Exclamation, "Exportar Licitaciones")
            Exit Sub
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsExportar As New DataSet
        Try
            conexion.Open()
            adaptador.FillSchema(dsExportar, SchemaType.Source)
            adaptador.Fill(dsExportar)
            conexion.Close()
            If dsExportar.Tables.Count > 0 Then
                dtLicitacion = dsExportar.Tables(0)
                dtItemsAPU = dsExportar.Tables(1)
                dsExportar.Tables(0).TableName = "LICITACION"
                dsExportar.Tables(1).TableName = "APU"
                If dtLicitacion.Rows.Count > 0 Then
                    If dtItemsAPU.Rows.Count > 0 Then
                        dtItemsAPU.Columns.Remove("ESCAPITULO") 'Retira la columna sobrante para la impresión
                    Else
                        MsgBox("No hay ítems para exportar.", MsgBoxStyle.Information, "Exportar Ítems A.P.U.")
                        Exit Sub
                    End If
                Else
                    MsgBox("No hay ítems para exportar.", MsgBoxStyle.Information, "Exportar Ítems A.P.U.")
                    Exit Sub
                End If
            Else
                MsgBox("No hay ítems para exportar.", MsgBoxStyle.Information, "Exportar Ítems A.P.U.")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No fue posible cargar los Ítems A.P.U. a exportar.", MsgBoxStyle.Critical, "Error Exportar Ítems A.P.U.")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        drLicitacion = dtLicitacion.Rows(0)
        porcentajeAdministracion = drLicitacion.Item("PORCENTAJEADMINISTRACION")
        porcentajeImprevistos = drLicitacion.Item("PORCENTAJEIMPREVISTOS")
        porcentajeUtilidad = drLicitacion.Item("PORCENTAJEUTILIDAD")

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()

            'Título
            .Range("B2:G2").Merge()
            .Range("B2:G2").Value = drLicitacion.Item("CONTRATISTA").ToString.ToUpper
            .Range("B2:G2").Font.Bold = True
            .Range("B2:G2").Font.Size = 20
            .Range("B2:G2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            'Subtítulo
            .Range("B4:G4").Merge()
            .Range("B4:G4").Value = "PRESUPUESTO DE CONSTRUCCIÓN"
            .Range("B4:G4").Font.Bold = True
            .Range("B4:G4").Font.Size = 16
            .Range("B4:G4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            'Encabezado
            .Range("B7").Value = "PROPONENTE:"
            .Range("B7").Font.Bold = True
            .Range("C7:G7").Merge()
            .Range("C7:G7").Value = drLicitacion.Item("CLIENTE")
            .Range("C7:G7").Font.Size = 8
            .Range("B8").Value = "OBRA:"
            .Range("B8").Font.Bold = True
            .Range("C8").Value = drLicitacion.Item("PROYECTO")
            .Range("E8").Value = "FECHA:"
            .Range("E8").Font.Bold = True
            .Range("F8:G8").Merge()
            .Range("F8:G8").Value = Date.Today
            .Range("F8:G8").NumberFormat = XlFormat.DateShort
            .Range("F8:G8").Font.Size = 8
            .Range("F8:G8").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 10
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtItemsAPU.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtItemsAPU.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtItemsAPU.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra & i, strColumna & i)
                'Opcional: si es capítulo entonces combinar celdas
                If IsDBNull(reg.Item("UNIDAD")) OrElse Trim(reg.Item("UNIDAD")) = "" Then 'Verifica si es capítulo
                    objRangoReg.Font.Bold = True
                End If

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("COSTO PARCIAL")) Then
                    costoDirecto += reg.Item("COSTO PARCIAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("E" & primerNumero, "E" & UltimoNumero).NumberFormat = XlFormat.Currency 'Valor Unitario"
            .Range("F" & primerNumero, "F" & UltimoNumero).NumberFormat = XlFormat.Currency 'Costo Parcial, Totales

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            .Range("D" & primerNumero, "D" & UltimoNumero).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter 'Unidad

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("C" & primerNumero, "C" & UltimoNumero).WrapText = True 'Descripción
            .Range("A1", "A" & UltimoNumero).ColumnWidth = 2.3 'Borde izquierdo
            .Range("H1", "H" & UltimoNumero).ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub


    ''' <summary>
    ''' Crea un archivo XLS con el Desglose de A.P.U. Ubica todos los datos en una sola hoja del libro.
    ''' </summary>
    ''' <param name="idLicitacion"></param>
    Public Shared Sub ExportarExcel_DetalleAPUsUnaHoja(idLicitacion As Integer, Optional listadoAPU As DataTable = Nothing)
        Dim subtotalMaquinaria As Decimal = 0
        Dim subtotalMateriales As Decimal = 0
        Dim subtotalManoObra As Decimal = 0
        Dim costoDirecto As Decimal = 0
        Dim porcentajeAdministracion As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim porcentajeImprevistos As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim porcentajeUtilidad As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim totalCosto As Decimal = 0
        Dim dsExportar As New DataSet
        Dim dtLicitacion As New DataTable
        Dim dtItemsAPU As New DataTable
        Dim dtMaquinariaEquipo As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtManoDeObra As New DataTable
        Dim drLicitacion As DataRow
        Dim drItemAPU As DataRow
        Dim filasManoDeObra As DataTable
        Dim filasMaquinariaEquipo As DataTable
        Dim filasMateriales As DataTable

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImprExpLIC_DesgloseAPU", conexion)
        comando.CommandType = CommandType.StoredProcedure
        If listadoAPU Is Nothing Then
            comando.Parameters.AddWithValue("@TIPO", 0) 'Todos los ítems de la Licitación.
        Else
            comando.Parameters.AddWithValue("@TIPO", 1) 'Listado de ítems seleccionados en tabla parámetro
        End If
        comando.Parameters.AddWithValue("@TablaItemsAPU", listadoAPU)
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRecursos As New DataSet 'Contiene las tablas con los datos de la licitación, ítems A.P.U. y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsRecursos)
            conexion.Close()
            If dsRecursos.Tables.Count > 0 Then
                dtLicitacion = dsRecursos.Tables(0)
                dtItemsAPU = dsRecursos.Tables(1)
                dtMaquinariaEquipo = dsRecursos.Tables(2)
                dtMateriales = dsRecursos.Tables(3)
                dtManoDeObra = dsRecursos.Tables(4)
                If dtItemsAPU.Rows.Count <= 0 Then
                    MsgBox("No hay ítems para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                    Exit Sub
                End If
            Else
                MsgBox("No hay  ítems para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los ítems A.P.U. a imprimir.", MsgBoxStyle.Critical, "Error Impresión Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        drLicitacion = dtLicitacion.Rows(0)
        porcentajeAdministracion = drLicitacion.Item("PORCENTAJEADMINISTRACION")
        porcentajeImprevistos = drLicitacion.Item("PORCENTAJEIMPREVISTOS")
        porcentajeUtilidad = drLicitacion.Item("PORCENTAJEUTILIDAD")

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add()
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objRangoEncab As Excel.Range
        Dim objCelda As Excel.Range
        Dim objRango As Excel.Range

        Dim primeraLetra As Char = "A"
        Dim primerNumero As Short = 2
        Dim Letra As Char = primeraLetra
        Dim UltimaLetra As Char
        Dim Numero As Integer = primerNumero
        Dim UltimoNumeroME As Integer = 0
        Dim UltimoNumeroMa As Integer = 0
        Dim UltimoNumeroMO As Integer = 0
        Dim UltimoNumero As Integer = 0
        Dim cod_letra As Byte = Asc(primeraLetra) - 1
        Dim UltimaLetraIzq As String = ""
        Dim strColumna As String = ""
        Dim LetraIzq As String = ""
        Dim cod_LetraIzq As Byte
        Dim i As Integer = 0
        Dim numeroPiePagina As Integer = 0

        filasMaquinariaEquipo = dtMaquinariaEquipo.Clone
        filasMateriales = dtMateriales.Clone
        filasManoDeObra = dtManoDeObra.Clone
        Dim filasME As DataRow()
        Dim filasMa As DataRow()
        Dim filasMO As DataRow()

        With objHojaExcel
            For n As Integer = 0 To dtItemsAPU.Rows.Count - 1
                drItemAPU = dtItemsAPU.Rows(n)

                filasME = dtMaquinariaEquipo.Select("IDAPU=" & dtItemsAPU.Rows(n).Item("IDAPU"))
                filasMa = dtMateriales.Select("IDAPU=" & dtItemsAPU.Rows(n).Item("IDAPU"))
                filasMO = dtManoDeObra.Select("IDAPU=" & dtItemsAPU.Rows(n).Item("IDAPU"))

                If filasME.Length > 0 Then
                    filasMaquinariaEquipo = filasME.CopyToDataTable
                End If
                If filasMa.Length > 0 Then
                    filasMateriales = filasMa.CopyToDataTable
                End If
                If filasMO.Length > 0 Then
                    filasManoDeObra = filasMO.CopyToDataTable
                End If

                'Título
                .Range("B" & primerNumero & ":G" & primerNumero).Merge()
                .Range("B" & primerNumero & ":G" & primerNumero).Value = drLicitacion.Item("CONTRATISTA").ToString.ToUpper
                .Range("B" & primerNumero & ":G" & primerNumero).Font.Bold = True
                .Range("B" & primerNumero & ":G" & primerNumero).Font.Size = 20
                .Range("B" & primerNumero & ":G" & primerNumero).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Subtítulo
                .Range("B" & (primerNumero + 2) & ":G" & (primerNumero + 2)).Merge()
                .Range("B" & (primerNumero + 2) & ":G" & (primerNumero + 2)).Value = drLicitacion.Item("PROYECTO")
                .Range("B" & (primerNumero + 2) & ":G" & (primerNumero + 2)).Font.Bold = True
                .Range("B" & (primerNumero + 2) & ":G" & (primerNumero + 2)).Font.Size = 16
                .Range("B" & (primerNumero + 2) & ":G" & (primerNumero + 2)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("B" & (primerNumero + 3) & ":G" & (primerNumero + 3)).Merge()
                .Range("B" & (primerNumero + 3) & ":G" & (primerNumero + 3)).Value = "DESGLOSE DE PRECIOS"
                .Range("B" & (primerNumero + 3) & ":G" & (primerNumero + 3)).Font.Bold = True
                .Range("B" & (primerNumero + 3) & ":G" & (primerNumero + 3)).Font.Size = 16
                .Range("B" & (primerNumero + 3) & ":G" & (primerNumero + 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Encabezado
                .Range("B" & (primerNumero + 6)).Value = "PROPONENTE:"
                .Range("B" & (primerNumero + 6)).Font.Bold = True
                .Range("C" & (primerNumero + 6) & ":D" & (primerNumero + 6)).Merge()
                .Range("C" & (primerNumero + 6) & ":D" & (primerNumero + 6)).Value = drLicitacion.Item("CLIENTE")
                .Range("C" & (primerNumero + 6) & ":D" & (primerNumero + 6)).Font.Size = 8
                .Range("F" & (primerNumero + 6)).Value = "FECHA:"
                .Range("F" & (primerNumero + 6)).Font.Bold = True
                .Range("G" & (primerNumero + 6)).Value = Date.Today
                .Range("G" & (primerNumero + 6)).NumberFormat = XlFormat.DateShort
                .Range("G" & (primerNumero + 6)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("B" & (primerNumero + 7)).Value = "UNIDAD DE MEDIDA:"
                .Range("B" & (primerNumero + 7)).Font.Bold = True
                .Range("C" & (primerNumero + 7)).Value = drItemAPU.Item("ABREVIATURA")
                .Range("B" & (primerNumero + 8)).Value = "ÍTEM:"
                .Range("B" & (primerNumero + 8)).Font.Bold = True
                .Range("C" & (primerNumero + 8)).Value = drItemAPU.Item("NROITEMCLIENTE")
                .Range("D" & (primerNumero + 8)).Value = "DESCRIPCIÓN:"
                .Range("D" & (primerNumero + 8)).Font.Bold = True
                .Range("E" & (primerNumero + 8)).Value = drItemAPU.Item("DESCRIPCION")
                .Range("F" & (primerNumero + 8)).Value = "CANTIDAD:"
                .Range("F" & (primerNumero + 8)).Font.Bold = True
                .Range("G" & (primerNumero + 8)).Value = Format(drItemAPU.Item("CANTIDADESTIMADA"), "0.####")

                .Range("B" & (primerNumero + 10)).Value = "MAQUINARIA Y EQUIPO"
                .Range("B" & (primerNumero + 10)).Font.Bold = True

                'Cuerpo
                i = 0
                primerNumero += 11
                Numero = primerNumero

                'Establecer formatos de las columnas de la hoja de cálculo
                For Each c As DataColumn In filasMaquinariaEquipo.Columns
                    If c.ColumnName <> "IDAPU" Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq & Letra & Numero
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                        objCelda.Font.Bold = True
                        objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    End If
                Next

                objRangoEncab = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                UltimaLetra = Letra
                UltimaLetraIzq = LetraIzq
                i = Numero + 1

                For Each reg As DataRow In filasMaquinariaEquipo.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataColumn In filasMaquinariaEquipo.Columns
                        If c.ColumnName <> "IDAPU" Then
                            If Letra = "Z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                        End If
                    Next

                    If Not IsDBNull(reg.Item("VALOR PARCIAL")) Then
                        subtotalMaquinaria += reg.Item("VALOR PARCIAL")
                    End If

                    i += 1
                Next
                UltimoNumeroME = i - 1
                Numero = i + 1


                .Range(primeraLetra & Numero).Value = "MATERIALES"
                .Range(primeraLetra & Numero).Font.Bold = True
                Numero += 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                cod_LetraIzq = Asc(primeraLetra) - 1
                For Each c As DataColumn In filasMateriales.Columns
                    If c.ColumnName <> "IDAPU" Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq & Letra & Numero
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                        objCelda.Font.Bold = True
                        objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    End If
                Next
                objRangoEncab = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                UltimaLetra = Letra
                UltimaLetraIzq = LetraIzq
                i = Numero + 1
                For Each reg As DataRow In filasMateriales.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataColumn In filasMateriales.Columns
                        If c.ColumnName <> "IDAPU" Then
                            If Letra = "Z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                        End If
                    Next

                    If Not IsDBNull(reg.Item("VALOR PARCIAL")) Then
                        subtotalMateriales += reg.Item("VALOR PARCIAL")
                    End If

                    i += 1
                Next
                UltimoNumeroMa = i - 1
                Numero = i + 1


                .Range(primeraLetra & Numero).Value = "MANO DE OBRA"
                .Range(primeraLetra & Numero).Font.Bold = True
                Numero += 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                cod_LetraIzq = Asc(primeraLetra) - 1
                For Each c As DataColumn In filasManoDeObra.Columns
                    If c.ColumnName <> "IDAPU" Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq & Letra & Numero
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                        objCelda.Font.Bold = True
                        objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    End If
                Next
                objRangoEncab = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                UltimaLetra = Letra
                UltimaLetraIzq = LetraIzq
                i = Numero + 1
                For Each reg As DataRow In filasManoDeObra.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataColumn In filasManoDeObra.Columns
                        If c.ColumnName <> "IDAPU" Then
                            If Letra = "z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'valor de la celda
                        End If
                    Next

                    If Not IsDBNull(reg.Item("VALOR PARCIAL")) Then
                        costoDirecto += reg.Item("VALOR PARCIAL")
                    End If

                    i += 1
                Next
                UltimoNumeroMO = i - 1
                UltimoNumero = UltimoNumeroMO
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                cod_LetraIzq = Asc(primeraLetra) - 1

                'Cálculo del Costo Directo
                costoDirecto = subtotalMaquinaria + subtotalMateriales + subtotalManoObra
                valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
                valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
                valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
                totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

                'Formato de columnas
                .Range("C" & primerNumero, "C" & UltimoNumero).NumberFormat = XlFormat.Currency 'Tarifa/Hora
                .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

                'Pie de página
                numeroPiePagina = UltimoNumero + 2
                .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
                .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
                .Range("G" & numeroPiePagina).Value = costoDirecto
                .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
                .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
                .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
                .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
                .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
                .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
                .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
                .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
                .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
                .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
                .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
                .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
                .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
                .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
                .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

                .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
                .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

                .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
                .Range("A" & primerNumero, "B" & UltimoNumero).Merge(True)

                .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
                .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
                .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

                UltimoNumero += 7
                .Range("A" & (primerNumero - 5), "H" & UltimoNumero).Font.Size = 8

                'Dibujar el borde exterior grueso
                objRango = .Range("A1", "H" & (UltimoNumero))
                objRango.Font.Name = "Arial"

                .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
                objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)

                primerNumero = UltimoNumero + 2
                costoDirecto = 0
                valorAdministracion = 0
                valorImprevistos = 0
                valorUtilidad = 0
                totalCosto = 0

                filasMaquinariaEquipo.Clear()
                filasMateriales.Clear()
                filasManoDeObra.Clear()
            Next

            .Columns.AutoFit()
            .Range("A:A").ColumnWidth = 2.3 'Borde izquierdo
            .Range("H:H").ColumnWidth = 2.3 'Borde derecho
        End With

        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub


    ''' <summary>
    ''' Crea un archivo XLS con el Resumen de Recursos. Ubica todos los datos en una sola hoja del libro.
    ''' </summary>
    ''' <param name="idLicitacion"></param>
    Public Shared Sub ExportarExcel_ResumenDeRecursosUnaHoja(Optional idLicitacion As Integer = -1)
        Dim costoDirecto As Decimal = 0
        Dim porcentajeAdministracion As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim porcentajeImprevistos As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim porcentajeUtilidad As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim totalCosto As Decimal = 0
        Dim dsExportar As New DataSet
        Dim dtLicitacion As New DataTable
        Dim dtMaquinariaEquipo As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtManoDeObra As New DataTable
        Dim drLicitacion As DataRow

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImprExpLIC_ResumenDeRecursos", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", DBNull.Value)
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRecursos As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsRecursos)
            conexion.Close()
            If dsRecursos.Tables.Count > 0 Then
                dtLicitacion = dsRecursos.Tables(0)
                dtMaquinariaEquipo = dsRecursos.Tables(1)
                dtMateriales = dsRecursos.Tables(2)
                dtManoDeObra = dsRecursos.Tables(3)
                If dtMaquinariaEquipo.Rows.Count <= 0 OrElse dtMateriales.Rows.Count <= 0 OrElse dtManoDeObra.Rows.Count <= 0 Then
                    MsgBox("No hay recursos para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                    Exit Sub
                End If
            Else
                MsgBox("No hay recursos para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos a imprimir.", MsgBoxStyle.Critical, "Error Impresión Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        drLicitacion = dtLicitacion.Rows(0)
        porcentajeAdministracion = drLicitacion.Item("PORCENTAJEADMINISTRACION")
        porcentajeImprevistos = drLicitacion.Item("PORCENTAJEIMPREVISTOS")
        porcentajeUtilidad = drLicitacion.Item("PORCENTAJEUTILIDAD")

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaMaquinaria As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaMateriales As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaManoObra As Excel.Worksheet = objLibroExcel.Worksheets(3)

        For Each sheet In objLibroExcel.Worksheets
            With sheet
                'Título
                .Range("B2:G2").Merge()
                .Range("B2:G2").Value = drLicitacion.Item("CONTRATISTA").ToString.ToUpper
                .Range("B2:G2").Font.Bold = True
                .Range("B2:G2").Font.Size = 20
                .Range("B2:G2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Subtítulo
                .Range("B4:G4").Merge()
                .Range("B4:G4").Value = "RESUMEN DE RECURSOS"
                .Range("B4:G4").Font.Bold = True
                .Range("B4:G4").Font.Size = 16
                .Range("B4:G4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Encabezado
                .Range("B7").Value = "PROPONENTE:"
                .Range("B7").Font.Bold = True
                .Range("C7:G7").Merge()
                .Range("C7:G7").Value = drLicitacion.Item("CLIENTE")
                .Range("C7:G7").Font.Size = 8
                .Range("B8").Value = "OBRA:"
                .Range("B8").Font.Bold = True
                .Range("C8").Value = drLicitacion.Item("PROYECTO")
                .Range("E8").Value = "FECHA:"
                .Range("E8").Font.Bold = True
                .Range("F8:G8").Merge()
                .Range("F8:G8").Value = Date.Today
                .Range("F8:G8").NumberFormat = XlFormat.DateShort
                .Range("F8:G8").Font.Size = 8
                .Range("F8:G8").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            End With
        Next

        With objHojaMaquinaria
            .Name = "Maquinaria y Equipo"

            .Activate()
            .Range("B10").Value = "MAQUINARIA Y EQUIPO"
            .Range("B10").Font.Bold = True

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 11
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtMaquinariaEquipo.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtMaquinariaEquipo.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtMaquinariaEquipo.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("SUBTOTAL")) Then
                    costoDirecto += reg.Item("SUBTOTAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("C" & primerNumero, "C" & UltimoNumero).NumberFormat = XlFormat.Currency 'Tarifa/Hora
            .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "c" & UltimoNumero).Merge(True)

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
            .Range("A:A").ColumnWidth = 2.3 'Borde izquierdo
            .Range("H:H").ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        costoDirecto = 0
        valorAdministracion = 0
        valorImprevistos = 0
        valorUtilidad = 0
        totalCosto = 0

        With objHojaMateriales
            .Name = "Materiales"

            .Activate()
            .Range("B10").Value = "MATERIALES"
            .Range("B10").Font.Bold = True

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 11
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtMateriales.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtMateriales.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtMateriales.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("SUBTOTAL")) Then
                    costoDirecto += reg.Item("SUBTOTAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Valor
            .Range("E" & primerNumero, "E" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "B" & UltimoNumero).Merge(True)

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            .Range("D" & primerNumero, "D" & UltimoNumero).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter 'Unidad

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
            .Range("A:A").ColumnWidth = 2.3 'Borde izquierdo
            .Range("H:H").ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        costoDirecto = 0
        valorAdministracion = 0
        valorImprevistos = 0
        valorUtilidad = 0
        totalCosto = 0

        With objHojaManoObra
            .Name = "Mano de Obra"

            .Activate()
            .Range("B10").Value = "MANO DE OBRA"
            .Range("B10").Font.Bold = True

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 11
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtManoDeObra.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtManoDeObra.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtManoDeObra.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("SUBTOTAL")) Then
                    costoDirecto += reg.Item("SUBTOTAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("C" & primerNumero, "C" & UltimoNumero).NumberFormat = XlFormat.Currency 'Tarifa/HH
            .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("C" & primerNumero, "C" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "C" & UltimoNumero).Merge(True)

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
            .Range("A1", "A" & UltimoNumero).ColumnWidth = 2.3 'Borde izquierdo
            .Range("H1", "H" & UltimoNumero).ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub


    ''' <summary>
    ''' Crea un archivo XLS con el Desglose de A.P.U.s ubicando cada A.P.U. en hojas aparte.
    ''' </summary>
    ''' <param name="idLicitacion"></param>
    Public Shared Sub ExportarExcel_DetalleAPUsMultiplesHojas(Optional ByVal idLicitacion As Integer = -1, Optional dtListadoItems As DataTable = Nothing)
        Dim subtotalMaquinaria As Decimal = 0
        Dim subtotalMateriales As Decimal = 0
        Dim subtotalManoObra As Decimal = 0
        Dim costoDirecto As Decimal = 0
        Dim porcentajeAdministracion As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim porcentajeImprevistos As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim porcentajeUtilidad As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim totalCosto As Decimal = 0
        Dim dsExportar As New DataSet
        Dim dtLicitacion As New DataTable
        Dim dtItemsAPU As New DataTable
        Dim dtMaquinariaEquipo As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtManoDeObra As New DataTable
        Dim drLicitacion As DataRow
        Dim drItemAPU As DataRow
        Dim filasManoDeObra As DataTable
        Dim filasMaquinariaEquipo As DataTable
        Dim filasMateriales As DataTable

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImprExpLIC_DesgloseAPU", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 0) 'Todos los ítems de la Licitación.
        comando.Parameters.AddWithValue("@TablaItemsAPU", Nothing)
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRecursos As New DataSet 'Contiene las tablas con los datos de la licitación, ítems A.P.U. y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsRecursos)
            conexion.Close()
            If dsRecursos.Tables.Count > 0 Then
                dtLicitacion = dsRecursos.Tables(0)
                Dim filasAPU As DataRow()
                filasAPU = dsRecursos.Tables(1).Select("", "NROITEMLICITACION DESC")
                dtItemsAPU = filasAPU.CopyToDataTable 'dsRecursos.Tables(1)
                dtMaquinariaEquipo = dsRecursos.Tables(2)
                dtMateriales = dsRecursos.Tables(3)
                dtManoDeObra = dsRecursos.Tables(4)
                If dtItemsAPU.Rows.Count <= 0 Then
                    MsgBox("No hay ítems para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                    Exit Sub
                End If
            Else
                MsgBox("No hay  ítems para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los ítems A.P.U. a imprimir.", MsgBoxStyle.Critical, "Error Impresión Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        drLicitacion = dtLicitacion.Rows(0)
        porcentajeAdministracion = drLicitacion.Item("PORCENTAJEADMINISTRACION")
        porcentajeImprevistos = drLicitacion.Item("PORCENTAJEIMPREVISTOS")
        porcentajeUtilidad = drLicitacion.Item("PORCENTAJEUTILIDAD")

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add()
        Dim objRangoEncab As Excel.Range
        Dim sheet As Excel.Worksheet

        filasMaquinariaEquipo = dtMaquinariaEquipo.Clone
        filasMateriales = dtMateriales.Clone
        filasManoDeObra = dtManoDeObra.Clone
        Dim filasME As DataRow()
        Dim filasMa As DataRow()
        Dim filasMO As DataRow()

        For n As Integer = 0 To dtItemsAPU.Rows.Count - 1
            drItemAPU = dtItemsAPU.Rows(n)

            filasME = dtMaquinariaEquipo.Select("IDAPU=" & dtItemsAPU.Rows(n).Item("IDAPU"))
            filasMa = dtMateriales.Select("IDAPU=" & dtItemsAPU.Rows(n).Item("IDAPU"))
            filasMO = dtManoDeObra.Select("IDAPU=" & dtItemsAPU.Rows(n).Item("IDAPU"))

            If filasME.Length > 0 Then
                filasMaquinariaEquipo = filasME.CopyToDataTable
            End If
            If filasMa.Length > 0 Then
                filasMateriales = filasMa.CopyToDataTable
            End If
            If filasMO.Length > 0 Then
                filasManoDeObra = filasMO.CopyToDataTable
            End If

            If n = 0 AndAlso m_Excel.Worksheets.Count = 1 Then
                sheet = m_Excel.Worksheets(1)
            Else
                sheet = m_Excel.Worksheets.Add()
            End If

            With sheet
                .Name = drItemAPU.Item("NROITEMCLIENTE")
                .Activate()

                'Título
                .Range("B2:G2").Merge()
                .Range("B2:G2").Value = drLicitacion.Item("CONTRATISTA").ToString.ToUpper
                .Range("B2:G2").Font.Bold = True
                .Range("B2:G2").Font.Size = 20
                .Range("B2:G2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Subtítulo
                .Range("B4:G4").Merge()
                .Range("B4:G4").Value = drLicitacion.Item("PROYECTO")
                .Range("B4:G4").Font.Bold = True
                .Range("B4:G4").Font.Size = 16
                .Range("B4:G4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                .Range("B5:G5").Merge()
                .Range("B5:G5").Value = "DESGLOSE DE PRECIOS"
                .Range("B5:G5").Font.Bold = True
                .Range("B5:G5").Font.Size = 16
                .Range("B5:G5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Encabezado
                .Range("B8").Value = "PROPONENTE:"
                .Range("B8").Font.Bold = True
                .Range("C8:D8").Merge()
                .Range("C8:D8").Value = drLicitacion.Item("CLIENTE")
                .Range("C8:D8").Font.Size = 8
                .Range("F8").Value = "FECHA:"
                .Range("F8").Font.Bold = True
                .Range("G8").Value = Date.Today
                .Range("G8").NumberFormat = XlFormat.DateShort
                .Range("G8").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                .Range("B9").Value = "UNIDAD DE MEDIDA:"
                .Range("B9").Font.Bold = True
                .Range("C9").Value = drItemAPU.Item("ABREVIATURA")
                .Range("B10").Value = "ÍTEM:"
                .Range("B10").Font.Bold = True
                .Range("C10").Value = drItemAPU.Item("NROITEMCLIENTE")
                .Range("D10").Value = "DESCRIPCIÓN:"
                .Range("D10").Font.Bold = True
                .Range("E10").Value = drItemAPU.Item("DESCRIPCION")
                .Range("F10").Value = "CANTIDAD:"
                .Range("F10").Font.Bold = True
                .Range("G10").Value = Format(drItemAPU.Item("CANTIDADESTIMADA"), "0.####")

                .Range("B12").Value = "MAQUINARIA Y EQUIPO"
                .Range("B12").Font.Bold = True

                'Cuerpo
                Dim primeraLetra As Char = "A"
                Dim primerNumero As Short = 13
                Dim Letra As Char
                Dim UltimaLetra As Char
                Dim Numero As Integer = 0
                Dim UltimoNumeroME As Integer = 0
                Dim UltimoNumeroMa As Integer = 0
                Dim UltimoNumeroMO As Integer = 0
                Dim UltimoNumero As Integer = 0
                Dim cod_letra As Byte = Asc(primeraLetra) - 1
                Dim UltimaLetraIzq As String = ""
                Dim strColumna As String = ""
                Dim LetraIzq As String = ""
                Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
                Letra = primeraLetra
                Numero = primerNumero
                Dim objCelda As Excel.Range
                Dim i As Integer = 0

                'Establecer formatos de las columnas de la hoja de cálculo
                For Each c As DataColumn In filasMaquinariaEquipo.Columns
                    If c.ColumnName <> "IDAPU" Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq & Letra & Numero
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                        objCelda.Font.Bold = True
                        objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                        Select Case c.DataType
                            Case GetType(String)
                                objCelda.EntireColumn.NumberFormat = XlFormat.Text
                            Case GetType(Decimal), GetType(Double)
                                objCelda.EntireColumn.NumberFormat = XlFormat.General
                            Case Else
                                objCelda.EntireColumn.NumberFormat = XlFormat.General
                        End Select
                    End If
                Next

                objRangoEncab = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                UltimaLetra = Letra
                UltimaLetraIzq = LetraIzq
                i = Numero + 1

                For Each reg As DataRow In filasMaquinariaEquipo.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataColumn In filasMaquinariaEquipo.Columns
                        If c.ColumnName <> "IDAPU" Then
                            If Letra = "Z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                        End If
                    Next

                    If Not IsDBNull(reg.Item("VALOR PARCIAL")) Then
                        subtotalMaquinaria += reg.Item("VALOR PARCIAL")
                    End If

                    i += 1
                Next
                UltimoNumeroME = i - 1
                Numero = i + 1


                .Range(primeraLetra & Numero).Value = "MATERIALES"
                .Range(primeraLetra & Numero).Font.Bold = True
                Numero += 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                cod_LetraIzq = Asc(primeraLetra) - 1
                For Each c As DataColumn In filasMateriales.Columns
                    If c.ColumnName <> "IDAPU" Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq & Letra & Numero
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                        objCelda.Font.Bold = True
                        objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    End If
                Next

                objRangoEncab = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                UltimaLetra = Letra
                UltimaLetraIzq = LetraIzq
                i = Numero + 1

                For Each reg As DataRow In filasMateriales.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataColumn In filasMateriales.Columns
                        If c.ColumnName <> "IDAPU" Then
                            If Letra = "Z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                        End If
                    Next

                    If Not IsDBNull(reg.Item("VALOR PARCIAL")) Then
                        subtotalMateriales += reg.Item("VALOR PARCIAL")
                    End If

                    i += 1
                Next
                UltimoNumeroMa = i - 1
                Numero = i + 1


                .Range(primeraLetra & Numero).Value = "MANO DE OBRA"
                .Range(primeraLetra & Numero).Font.Bold = True
                Numero += 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                cod_LetraIzq = Asc(primeraLetra) - 1
                For Each c As DataColumn In filasManoDeObra.Columns
                    If c.ColumnName <> "IDAPU" Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq & Letra & Numero
                        objCelda = .Range(strColumna, Type.Missing)
                        objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                        objCelda.Font.Bold = True
                        objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    End If
                Next

                objRangoEncab = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                UltimaLetra = Letra
                UltimaLetraIzq = LetraIzq
                i = Numero + 1

                For Each reg As DataRow In filasManoDeObra.Rows
                    LetraIzq = ""
                    cod_LetraIzq = Asc(primeraLetra) - 1
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra) - 1
                    For Each c As DataColumn In filasManoDeObra.Columns
                        If c.ColumnName <> "IDAPU" Then
                            If Letra = "z" Then
                                Letra = primeraLetra
                                cod_letra = Asc(primeraLetra)
                                cod_LetraIzq += 1
                                LetraIzq = Chr(cod_LetraIzq)
                            Else
                                cod_letra += 1
                                Letra = Chr(cod_letra)
                            End If
                            strColumna = LetraIzq + Letra
                            .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'valor de la celda
                        End If
                    Next

                    If Not IsDBNull(reg.Item("VALOR PARCIAL")) Then
                        costoDirecto += reg.Item("VALOR PARCIAL")
                    End If

                    i += 1
                Next
                UltimoNumeroMO = i - 1
                UltimoNumero = UltimoNumeroMO


                'Cálculo del Costo Directo
                costoDirecto = subtotalMaquinaria + subtotalMateriales + subtotalManoObra

                valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
                valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
                valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
                totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

                'Formato de columnas
                .Range("C" & primerNumero, "C" & UltimoNumero).NumberFormat = XlFormat.Currency 'Tarifa/Hora
                .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

                'Pie de página
                Dim numeroPiePagina As Integer = UltimoNumero + 2
                .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
                .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
                .Range("G" & numeroPiePagina).Value = costoDirecto
                .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
                .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
                .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
                .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
                .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
                .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
                .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
                .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
                .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
                .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
                .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
                .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
                .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
                .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
                .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

                .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
                .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

                .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
                .Range("A" & primerNumero, "B" & UltimoNumero).Merge(True)

                .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
                .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
                .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

                UltimoNumero += 7
                .Range("A" & 6, "H" & UltimoNumero).Font.Size = 8

                'Dibujar el borde exterior grueso
                Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
                objRango.Font.Name = "Arial"
                objRango.Columns.AutoFit()

                .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
                .Range("A:A").ColumnWidth = 2.3 'Borde izquierdo
                .Range("H:H").ColumnWidth = 2.3 'Borde derecho

                objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            End With
            costoDirecto = 0
            valorAdministracion = 0
            valorImprevistos = 0
            valorUtilidad = 0
            totalCosto = 0

            filasMaquinariaEquipo.Clear()
            filasMateriales.Clear()
            filasManoDeObra.Clear()
        Next

        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub


    ''' <summary>
    ''' Crea un archivo XLS con el Resumen de Recursos ubicando cada tipo de recurso en hojas por aparte.
    ''' </summary>
    ''' <param name="idLicitacion"></param>
    Public Shared Sub ExportarExcel_ResumenDeRecursosMultiplesHojas(Optional ByVal idLicitacion As Integer = -1)
        Dim costoDirecto As Decimal = 0
        Dim porcentajeAdministracion As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim porcentajeImprevistos As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim porcentajeUtilidad As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim totalCosto As Decimal = 0
        Dim dsExportar As New DataSet
        Dim dtLicitacion As New DataTable
        Dim dtMaquinariaEquipo As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtManoDeObra As New DataTable
        Dim drLicitacion As DataRow

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImprExpLIC_ResumenDeRecursos", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", DBNull.Value)
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRecursos As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsRecursos)
            conexion.Close()
            If dsRecursos.Tables.Count > 0 Then
                dtLicitacion = dsRecursos.Tables(0)
                dtMaquinariaEquipo = dsRecursos.Tables(1)
                dtMateriales = dsRecursos.Tables(2)
                dtManoDeObra = dsRecursos.Tables(3)
                If dtMaquinariaEquipo.Rows.Count <= 0 OrElse dtMateriales.Rows.Count <= 0 OrElse dtManoDeObra.Rows.Count <= 0 Then
                    MsgBox("No hay recursos para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                    Exit Sub
                End If
            Else
                MsgBox("No hay recursos para imprimir.", MsgBoxStyle.Information, "Impresión Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos a imprimir.", MsgBoxStyle.Critical, "Error Impresión Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        drLicitacion = dtLicitacion.Rows(0)
        porcentajeAdministracion = drLicitacion.Item("PORCENTAJEADMINISTRACION")
        porcentajeImprevistos = drLicitacion.Item("PORCENTAJEIMPREVISTOS")
        porcentajeUtilidad = drLicitacion.Item("PORCENTAJEUTILIDAD")

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaMaquinaria As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaMateriales As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaManoObra As Excel.Worksheet = objLibroExcel.Worksheets(3)

        For Each sheet In objLibroExcel.Worksheets
            With sheet
                'Título
                .Range("B2:G2").Merge()
                .Range("B2:G2").Value = drLicitacion.Item("CONTRATISTA").ToString.ToUpper
                .Range("B2:G2").Font.Bold = True
                .Range("B2:G2").Font.Size = 20
                .Range("B2:G2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Subtítulo
                .Range("B4:G4").Merge()
                .Range("B4:G4").Value = "RESUMEN DE RECURSOS"
                .Range("B4:G4").Font.Bold = True
                .Range("B4:G4").Font.Size = 16
                .Range("B4:G4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                'Encabezado
                .Range("B7").Value = "PROPONENTE:"
                .Range("B7").Font.Bold = True
                .Range("C7:G7").Merge()
                .Range("C7:G7").Value = drLicitacion.Item("CLIENTE")
                .Range("C7:G7").Font.Size = 8
                .Range("B8").Value = "OBRA:"
                .Range("B8").Font.Bold = True
                .Range("C8").Value = drLicitacion.Item("PROYECTO")
                .Range("E8").Value = "FECHA:"
                .Range("E8").Font.Bold = True
                .Range("F8:G8").Merge()
                .Range("F8:G8").Value = Date.Today
                .Range("F8:G8").NumberFormat = XlFormat.DateShort
                .Range("F8:G8").Font.Size = 8
                .Range("F8:G8").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            End With
        Next

        With objHojaMaquinaria
            .Name = "Maquinaria y Equipo"

            .Activate()
            .Range("B10").Value = "MAQUINARIA Y EQUIPO"
            .Range("B10").Font.Bold = True

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 11
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtMaquinariaEquipo.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtMaquinariaEquipo.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtMaquinariaEquipo.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("SUBTOTAL")) Then
                    costoDirecto += reg.Item("SUBTOTAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("C" & primerNumero, "C" & UltimoNumero).NumberFormat = XlFormat.Currency 'Tarifa/Hora
            .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "c" & UltimoNumero).Merge(True)

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
            .Range("A:A").ColumnWidth = 2.3 'Borde izquierdo
            .Range("H:H").ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        costoDirecto = 0
        valorAdministracion = 0
        valorImprevistos = 0
        valorUtilidad = 0
        totalCosto = 0

        With objHojaMateriales
            .Name = "Materiales"

            .Activate()
            .Range("B10").Value = "MATERIALES"
            .Range("B10").Font.Bold = True

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 11
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtMateriales.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtMateriales.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtMateriales.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("SUBTOTAL")) Then
                    costoDirecto += reg.Item("SUBTOTAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Valor
            .Range("E" & primerNumero, "E" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "B" & UltimoNumero).Merge(True)

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            .Range("D" & primerNumero, "D" & UltimoNumero).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter 'Unidad

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
            .Range("A:A").ColumnWidth = 2.3 'Borde izquierdo
            .Range("H:H").ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        costoDirecto = 0
        valorAdministracion = 0
        valorImprevistos = 0
        valorUtilidad = 0
        totalCosto = 0

        With objHojaManoObra
            .Name = "Mano de Obra"

            .Activate()
            .Range("B10").Value = "MANO DE OBRA"
            .Range("B10").Font.Bold = True

            'Cuerpo
            Dim primeraLetra As Char = "A"
            Dim primerNumero As Short = 11
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1

            'Establecer formatos de las columnas de la hoja de cálculo
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataColumn In dtManoDeObra.Columns
                If Letra = "Z" Then
                    Letra = primeraLetra
                    cod_letra = Asc(primeraLetra)
                    cod_LetraIzq += 1
                    LetraIzq = Chr(cod_LetraIzq)
                Else
                    cod_letra += 1
                    Letra = Chr(cod_letra)
                End If
                strColumna = LetraIzq & Letra & Numero
                objCelda = .Range(strColumna, Type.Missing)
                objCelda.Value = c.ColumnName 'ENCABEZADO DE LA TABLA
                objCelda.Font.Bold = True
                objCelda.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                Select Case c.DataType
                    Case GetType(String)
                        objCelda.EntireColumn.NumberFormat = XlFormat.Text
                    Case GetType(Decimal), GetType(Double)
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                    Case Else
                        objCelda.EntireColumn.NumberFormat = XlFormat.General
                End Select
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra & Numero, LetraIzq & Letra & Numero)
            If Letra = "Z" Then
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra)
                cod_LetraIzq += 1
                LetraIzq = Chr(cod_LetraIzq)
            Else
                cod_letra += 1
                Letra = Chr(cod_letra)
            End If
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            Dim i As Integer = Numero + 1

            For Each reg As DataRow In dtManoDeObra.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataColumn In dtManoDeObra.Columns
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra
                    .Range(strColumna & i).Value = IIf(IsDBNull(reg.ToString), "", reg.Item(c.ColumnName)) 'VALOR DE LA CELDA
                Next

                'Cálculo del Costo Directo
                If Not IsDBNull(reg.Item("SUBTOTAL")) Then
                    costoDirecto += reg.Item("SUBTOTAL")
                End If

                i += 1
            Next
            UltimoNumero = i - 1
            valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
            valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
            valorUtilidad = costoDirecto * (porcentajeUtilidad / 100)
            totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

            'Formato de columnas
            .Range("C" & primerNumero, "C" & UltimoNumero).NumberFormat = XlFormat.Currency 'Tarifa/HH
            .Range("D" & primerNumero, "D" & UltimoNumero).NumberFormat = XlFormat.Currency 'Subtotal

            'Pie de página
            Dim numeroPiePagina As Integer = UltimoNumero + 2
            .Range("D" & numeroPiePagina, "F" & numeroPiePagina).Merge()
            .Range("D" & numeroPiePagina, "E" & numeroPiePagina).Value = "COSTOS DIRECTOS"
            .Range("G" & numeroPiePagina).Value = costoDirecto
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Merge()
            .Range("D" & (numeroPiePagina + 1), "E" & (numeroPiePagina + 1)).Value = "ADMINISTRACIÓN"
            .Range("F" & (numeroPiePagina + 1)).Value = porcentajeAdministracion & "%"
            .Range("G" & (numeroPiePagina + 1)).Value = valorAdministracion
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Merge()
            .Range("D" & (numeroPiePagina + 2), "E" & (numeroPiePagina + 2)).Value = "IMPREVISTOS"
            .Range("F" & (numeroPiePagina + 2)).Value = porcentajeImprevistos & "%"
            .Range("G" & (numeroPiePagina + 2)).Value = valorImprevistos
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Merge()
            .Range("D" & (numeroPiePagina + 3), "E" & (numeroPiePagina + 3)).Value = "UTILIDADES"
            .Range("F" & (numeroPiePagina + 3)).Value = porcentajeUtilidad & "%"
            .Range("G" & (numeroPiePagina + 3)).Value = valorUtilidad
            .Range("D" & (numeroPiePagina + 4), "F" & (numeroPiePagina + 4)).Merge()
            .Range("D" & (numeroPiePagina + 4), "E" & (numeroPiePagina + 4)).Value = "TOTAL COSTOS"
            .Range("G" & (numeroPiePagina + 4)).Value = totalCosto

            .Range("G" & numeroPiePagina, "G" & (numeroPiePagina + 4)).NumberFormat = XlFormat.Currency 'Valores Totales
            .Range("D" & (numeroPiePagina + 4), "G" & (numeroPiePagina + 4)).Font.Bold = True 'Total costos

            .Range("B" & primerNumero, "B" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("C" & primerNumero, "C" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "C" & UltimoNumero).Merge(True)

            .Range("A" & primerNumero, "A" & UltimoNumero).Insert(Excel.XlInsertShiftDirection.xlShiftToRight)
            .Range("A" & primerNumero, "H" & UltimoNumero).Rows.BorderAround()
            .Range("A" & primerNumero, "H" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
            .Range("B" & primerNumero, "G" & UltimoNumero).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous

            UltimoNumero += 7
            .Range("A" & 5, "H" & UltimoNumero).Font.Size = 8

            'Dibujar el borde exterior grueso
            Dim objRango As Excel.Range = .Range("A1", "H" & (UltimoNumero))
            objRango.Font.Name = "Arial"
            objRango.Columns.AutoFit()

            .Range("B" & primerNumero, "B" & UltimoNumero).WrapText = True 'Descripción
            .Range("A1", "A" & UltimoNumero).ColumnWidth = 2.3 'Borde izquierdo
            .Range("H1", "H" & UltimoNumero).ColumnWidth = 2.3 'Borde derecho

            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub
#End Region 'Exportar a Excel

End Class 'FormulariosLicitaciones