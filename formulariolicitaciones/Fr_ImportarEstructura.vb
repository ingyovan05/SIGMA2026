Imports System.ComponentModel
Imports Microsoft.Office.Interop
Imports System.Text.RegularExpressions

''' <summary>
''' Permite la importación de la estructura de una licitación a partir de los datos contenidos en un archivo .xls o en el portapapeles provenientes de una aplicación de hojas de cálculo.
''' </summary>
Public Class Fr_ImportarEstructura

    ''' <summary>
    ''' Almacena la coordenada donde se hace clic en la rejilla para determinar la columna o fila sobre la cual se realiza la acción del menú emergente.
    ''' </summary>
    Private columnaCoordenadaMouse As DataGridView.HitTestInfo

    ''' <summary>
    ''' Cuadro de selección de archivo para la Importación de Estructura de Licitación.
    ''' </summary>
    Private WithEvents ofd As OpenFileDialog

    ''' <summary>
    ''' Almacena el listado cargado desde la opción "Importar Estructura de Licitación" en la sección "Items A.P.U.".
    ''' </summary>
    Private dtItems As DataTable

    ''' <summary>
    ''' la opción "Importar Estructura de Licitación" en la sección "Items A.P.U.".
    ''' </summary>
    Private Structure ColumnasDt
        Const NroItemCliente As String = "NROITEMCLIENTE"
        Const Descripcion As String = "DESCRIPCION"
        Const Unidad As String = "UNIDAD"
        Const Cantidad As String = "CANTIDAD"
        Const NroItemLicitacion As String = "NROITEMLICITACION"
        Const EsCapitulo As String = "ESCAPITULO"
    End Structure


    ''' <summary>
    ''' Constructor. Inicialización de campos.
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        dtItems = New DataTable
    End Sub


    ''' <summary>
    ''' Retorna la estructura de la licitación al control de usuario del módulo de Licitaciones.
    ''' </summary>
    ''' <returns>Tabla de datos con la estructura de la licitación.</returns>
    Public Function GetDtItems() As DataTable
        Return dtItems
    End Function


    ' Carga el formulario e inicializa los campos de la clase.
    Private Sub Fr_ImportarEstructura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FuncionesBase.FuncionesBase.VerificarConfiguracionRegional()
        'Esquema de la tabla que se retorna al control de usuario del módulo.
        dtItems.Columns.Add(ColumnasDt.NroItemCliente, Type.GetType("System.String"))
        dtItems.Columns.Add(ColumnasDt.Descripcion, Type.GetType("System.String"))
        dtItems.Columns.Add(ColumnasDt.Unidad, Type.GetType("System.String"))
        dtItems.Columns.Add(ColumnasDt.Cantidad, Type.GetType("System.Decimal"))
        dtItems.Columns.Add(ColumnasDt.NroItemLicitacion, Type.GetType("System.Byte"))
        dtItems.Columns.Add(ColumnasDt.EsCapitulo, Type.GetType("System.Char"))
        Dgv_Listado.DataSource = New DataTable 'Inicialización de la tabla vinculada a la rejilla para permitir la inserción de datos.
    End Sub


    ' Determina el comportamiento de los atajos de teclado de los comandos copiar y pegar.
    Private Sub Dgv_Listado_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Listado.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then 'Comando Pegar.
            PegarDeExcel()
            e.Handled = True
        ElseIf e.Control And (e.KeyCode = Keys.C) Then 'Comando Copiar
            CopiarAlPortapapeles()
            e.Handled = True
        End If
    End Sub


    ' Ejecuta la función de pegado desde el portapapeles.
    Private Sub Bt_PegarDesdePortapapeles_Click(sender As Object, e As EventArgs) Handles Bt_PegarDesdePortapapeles.Click
        PegarDeExcel()
    End Sub


    ''' <summary>
    ''' Carga los datos de la rejilla al portapapeles.
    ''' </summary>
    Private Sub CopiarAlPortapapeles()
        Dim d As DataObject = Dgv_Listado.GetClipboardContent()
        Clipboard.SetDataObject(d)
    End Sub


    ''' <summary>
    ''' Toma los datos presentes en el portapapeles y los anexa al final de la rejilla.
    ''' Las filas en blanco son descartadas.
    ''' </summary>
    Private Sub PegarDeExcel()
        If Clipboard.ContainsText Then
            Dim dtPegar As New DataTable
            Dim TxtPaste As String = Clipboard.GetText()
            Try
                Dim Lines As String() = Split(Clipboard.GetText, vbCrLf) 'Clipboard.GetText.Split(vbNewLine)
                If Not IsNothing(Lines) AndAlso Lines.Count > 0 Then
                    Dim C As String() = Lines(0).Split(vbTab) 'Determina la cantidad de columnas en base a los elementos de la primera fila del conjunto de datos copiado.
                    If Not IsNothing(C) AndAlso C.Count > 0 Then
                        For i As Integer = 1 To C.Count
                            dtPegar.Columns.Add()
                        Next
                        For Each ln As String In Lines
                            If Regex.Replace(ln, "\s+", "") <> "" Then 'Si la línea no está vacía
                                C = ln.Split(vbTab)
                                dtPegar.Rows.Add(C)
                            End If
                        Next
                        Dgv_Listado.DataSource.Merge(dtPegar)
                        RenombrarColumnas()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("No hay datos para copiar en el portapapeles.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Abre el cuadro de selección de archivo para realizar la importación de estructura de la licitación desde un archivo en formato de Excel (.xls o .xlsx).
    ' El archivo para la importación debe ser preparado únicamente con las columnas que contienen los datos para la creación de los A.P.U.
    Private Sub Bt_ImportarDesdeArchivoXLS_Click(sender As Object, e As EventArgs) Handles Bt_ImportarDesdeArchivoXLS.Click
        ofd = New OpenFileDialog
        ofd.Title = "Abrir Excel"
        ofd.Filter = "Archivo de Excel|*.xls;*.xlsx|Todos los Archivos|*.*"
        ofd.ShowDialog()
    End Sub


    ' Importación de la estructura de la licitación desde un archivo xls.
    ' Toma todos los datos presentes en la primera hoja de un archivo Xls y los anexa al final de la rejilla.
    ' Las filas en blanco son descartadas.
    Private Sub Ofd_FileOk(sender As Object, e As CancelEventArgs) Handles ofd.FileOk
        Cursor = Cursors.WaitCursor
        Dim excelApp As New Excel.Application 'Crea una nueva instancia de la aplicación MSEXCEL.
        Dim libro As Excel.Workbook = excelApp.Workbooks.Open(ofd.FileName) 'Crea un nuevo libro en la aplicación y carga los datos del archivo especificado en el cuadro de diálogo "Abrir Archivo".
        Try
            Dim hoja As Excel.Worksheet = libro.Worksheets(1) 'Selecciona la 1a hoja del libro.
            hoja.Columns.ClearFormats() 'Elimina el formato en todas las columnas de la hoja para evitar seleccionar celdas vacías, que en algún momento contenían datos.
            hoja.Rows.ClearFormats() 'Elimina el formato en todas las filas de la hoja para evitar seleccionar celdas vacías, que en algún momento contenían datos.
            Dim rango As Excel.Range = hoja.UsedRange 'Selecciona todas las celdas que contienen datos.
            Dim dtArchivo As New DataTable
            Dim dr As DataRow
            Dim celda As String = ""
            For Each col As Excel.Range In rango.Columns
                dtArchivo.Columns.Add()
            Next
            For iRow As Integer = 1 To rango.Rows.Count
                dr = dtArchivo.NewRow
                For iCol As Integer = 0 To rango.Columns.Count - 1
                    celda = rango(iRow, iCol + 1).Text.Trim
                    If celda <> "" Then
                        dr.Item(iCol) = celda
                    End If
                Next
                If Not EsFilaVacia(dr) Then
                    dtArchivo.Rows.Add(dr)
                End If
            Next
            Dgv_Listado.DataSource.Merge(dtArchivo)
            RenombrarColumnas()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            libro.Close(0)
            excelApp.Quit()
            Cursor = Cursors.Arrow
        End Try
    End Sub


    ''' <summary>
    ''' Determina si la fila leída del archivo .xls está vacía y se puede descartar del listado.
    ''' </summary>
    ''' <param name="dr">Fila líeda del archivo Xls.</param>
    ''' <returns>Verdadero si todos los elementos de la fila están vacíos. Falso si alguno de los elementos contiene texto.</returns>
    Private Function EsFilaVacia(dr As DataRow)
        For Each item In dr.ItemArray
            If Not IsDBNull(item) AndAlso item <> "" Then
                Return False
            End If
        Next
        Return True
    End Function


    ' Valida los datos y los procesa para guardado.
    Private Sub Bt_Importar_Click(sender As Object, e As EventArgs) Handles Bt_Importar.Click
        Dgv_Listado.DataSource.AcceptChanges()
        'Retirar Columnas excedentes
        For j As Integer = Dgv_Listado.DataSource.Columns.Count - 1 To 4 Step -1
            Dgv_Listado.DataSource.Columns.RemoveAt(j)
        Next
        If validarDatos() Then
            aplicarEsquemaDatos()
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub


    ''' <summary>
    ''' Verifica que no se presenten inconsistencias en los datos de las rejillas.
    ''' </summary>
    Private Function validarDatos() As Boolean
        Dim validarCeldas As Boolean = True
        If Dgv_Listado.DataSource.Columns.Count < 4 Then
            validarDatos = False
            MessageBox.Show("La estructura no cuenta con las 4 columnas necesarias (Ítem, Descripción, Unidad, Cantidad).", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If
        For i As Integer = 0 To Dgv_Listado.Rows.Count - 1
            For j As Integer = 0 To Dgv_Listado.Columns.Count - 1
                Select Case Dgv_Listado.Columns(j).DisplayIndex
                    'Case 0 'Ítem
                    Case 1 'Descripción
                        If IsDBNull(Dgv_Listado.Rows(i).Cells(j).Value) OrElse Dgv_Listado.Rows(i).Cells(j).Value = "" Then
                            Dgv_Listado.Rows(i).Cells(j).ErrorText = "La descripción no debe estar vacía."
                            validarCeldas = False
                        Else
                            Dgv_Listado.Rows(i).Cells(j).ErrorText = ""
                        End If
                        'Case 2 'Unidad
                    Case 3 'Cantidad
                        If Not IsDBNull(Dgv_Listado.Rows(i).Cells(j).Value) AndAlso Dgv_Listado.Rows(i).Cells(j).Value <> "" AndAlso Not IsNumeric(Dgv_Listado.Rows(i).Cells(j).Value) Then
                            Dgv_Listado.Rows(i).Cells(j).ErrorText = "La cantidad debe ser numérica y positiva."
                            validarCeldas = False
                        ElseIf IsNumeric(Dgv_Listado.Rows(i).Cells(j).Value) AndAlso Dgv_Listado.Rows(i).Cells(j).Value < 0 Then
                            Dgv_Listado.Rows(i).Cells(j).ErrorText = "La cantidad debe ser positiva."
                            validarCeldas = False
                        Else
                            Dgv_Listado.Rows(i).Cells(j).ErrorText = ""
                        End If
                End Select
            Next
        Next
        If validarCeldas = False Then
            validarDatos = False
            MessageBox.Show("Se encontraron inconsistencias, por favor revisar las casillas con marca de error.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If
        validarDatos = True
    End Function


    ''' <summary>
    ''' Copia los datos presentes en la rejilla en una tabla que cuenta con esquema de datos para realizar el guardado de la estructura de licitación sin errores.
    ''' </summary>
    Private Sub aplicarEsquemaDatos()
        dtItems.Clear()
        Dim dtActual As DataTable = Dgv_Listado.DataSource.Copy()
        For c As Integer = 0 To Dgv_Listado.Columns.Count - 1 'Asigna nombres a las columnas de las tablas de acuerdo al orden de visualización para realizar el mapeo a la tabla dtItems de manera correcta.
            Select Case Dgv_Listado.Columns(c).DisplayIndex
                Case 0
                    dtActual.Columns(c).ColumnName = ColumnasDt.NroItemCliente
                Case 1
                    dtActual.Columns(c).ColumnName = ColumnasDt.Descripcion
                Case 2
                    dtActual.Columns(c).ColumnName = ColumnasDt.Unidad
                Case 3
                    dtActual.Columns(c).ColumnName = ColumnasDt.Cantidad
            End Select
        Next
        Dim dr As DataRow
        For i As Integer = 0 To dtActual.Rows.Count - 1
            dr = dtItems.NewRow
            dr.Item(ColumnasDt.Descripcion) = dtActual.Rows(i).Item(ColumnasDt.Descripcion).Trim
            If Not IsDBNull(dtActual.Rows(i).Item(ColumnasDt.NroItemCliente)) Then
                dr.Item(ColumnasDt.NroItemCliente) = dtActual.Rows(i).Item(ColumnasDt.NroItemCliente).Trim
            End If
            If Not IsDBNull(dtActual.Rows(i).Item(ColumnasDt.Unidad)) AndAlso dtActual.Rows(i).Item(ColumnasDt.Unidad) <> "" Then
                dr.Item(ColumnasDt.Unidad) = dtActual.Rows(i).Item(ColumnasDt.Unidad).Trim
                dr.Item(ColumnasDt.EsCapitulo) = "N"
                If dtActual.Rows(i).Item(ColumnasDt.Cantidad).Trim <> "" Then
                    dr.Item(ColumnasDt.Cantidad) = FuncionesBase.FuncionesBase.ValorRealDec(dtActual.Rows(i).Item(ColumnasDt.Cantidad))
                Else
                    dr.Item(ColumnasDt.Cantidad) = DBNull.Value
                End If
            Else
                dr.Item(ColumnasDt.EsCapitulo) = "S"
            End If
            dr.Item(ColumnasDt.NroItemLicitacion) = i + 1
            dtItems.Rows.Add(dr)
        Next
    End Sub


    ' Cierre del formulario.
    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub


    ' Renombra las columnas en la rejilla cuando se altera el orden de visualización.
    Private Sub Dgv_Listado_ColumnDisplayIndexChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles Dgv_Listado.ColumnDisplayIndexChanged
        RenombrarColumnas()
    End Sub


    ''' <summary>
    ''' Asigna los nombres de las columnas en la rejilla de manera secuencial desde la primera hasta la cuarta columna.
    ''' </summary>
    Private Sub RenombrarColumnas()
        If Dgv_Listado.Columns.Count >= 4 Then
            For i As Integer = 0 To 3
                Select Case Dgv_Listado.Columns(i).DisplayIndex
                    Case 0
                        Dgv_Listado.Columns(i).HeaderText = "ÍTEM"
                    Case 1
                        Dgv_Listado.Columns(i).HeaderText = "DESCRIPCIÓN"
                    Case 2
                        Dgv_Listado.Columns(i).HeaderText = "UNIDAD"
                    Case 3
                        Dgv_Listado.Columns(i).HeaderText = "CANTIDAD"
                End Select
            Next
        End If
    End Sub


    ' Captura la coordenada de la posición donde se realizó clic derecho sobre la rejilla.
    Private Sub Dgv_Listado_MouseDown(sender As Object, e As MouseEventArgs) Handles Dgv_Listado.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            columnaCoordenadaMouse = sender.HitTest(e.X, e.Y)
        End If
    End Sub


    ' Verifica si se cumplen las condiciones para activar los elementos del menú emergente.
    Private Sub Cms_Listado_Opening(sender As Object, e As CancelEventArgs) Handles Cms_Listado.Opening
        If Clipboard.ContainsText Then
            PegarToolStripMenuItem.Enabled = True
        Else
            PegarToolStripMenuItem.Enabled = False
        End If
        If Dgv_Listado.Columns.Count > 0 Then
            BorrarColumnaToolStripMenuItem.Enabled = True
        Else
            BorrarColumnaToolStripMenuItem.Enabled = False
        End If
    End Sub


    ' Elimina la columna indicada por la coordenada capturada en la rejilla.
    Private Sub BorrarColumnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarColumnaToolStripMenuItem.Click
        Dgv_Listado.DataSource.Columns.RemoveAt(columnaCoordenadaMouse.ColumnIndex)
    End Sub


    ' Ejecuta la función de pegado desde el portapapeles.
    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        PegarDeExcel()
    End Sub

End Class