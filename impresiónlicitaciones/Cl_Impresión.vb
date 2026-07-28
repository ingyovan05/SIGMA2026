Imports System.Drawing.Printing
Imports System.Data.SqlClient

''' <summary>
''' 
''' </summary>
Public Class Cl_Impresión

#Region "Variables de Impresión"

    ''' <summary>
    ''' Lapiz base en la impresión de documentos.
    ''' Usado en el dibujado de líneas y bordes.
    ''' </summary>
    Protected Lapiz As Pen

    ''' <summary>
    ''' Brocha base en la impresión de documentos.
    ''' Usada en el relleno de texto y figuras.
    ''' </summary>
    Protected Brocha As New SolidBrush(Color.Black)

    ''' <summary>
    ''' Línea punteada para separar elementos en un listado.
    ''' </summary>
    Protected lineaPunteada As New Pen(Color.Gray, 1)

    ''' <summary>
    ''' 
    ''' </summary>
    Protected WithEvents VistaPrevia As New PrintPreviewDialog

    ''' <summary>
    ''' 
    ''' </summary>
    Protected cantidadPaginasImpresas As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Protected totalPaginas As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Protected itemsImpresos As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Protected datosCargados As Boolean = False

    ''' <summary>
    ''' Indica si se debe imprimir la cantidad total de páginas en el pie de página.
    ''' </summary>
    Protected imprimirPieDePagina As Boolean = False

    ''' <summary>
    ''' 
    ''' </summary>
    Private _margenDerecho As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Private _margenInferior As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Private _margenIzquierdo As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Private _margenSuperior As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Private _altoPagina As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Private _anchoPagina As Integer = 0

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected Property MargenDerecho As Integer
        Get
            Return _margenDerecho
        End Get
        Private Set(value As Integer)
            _margenDerecho = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected Property MargenInferior As Integer
        Get
            Return _margenInferior
        End Get
        Private Set(value As Integer)
            _margenInferior = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected Property MargenIzquierdo As Integer
        Get
            Return _margenIzquierdo
        End Get
        Private Set(value As Integer)
            _margenIzquierdo = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected Property MargenSuperior As Integer
        Get
            Return _margenSuperior
        End Get
        Private Set(value As Integer)
            _margenSuperior = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected ReadOnly Property AltoPagina As Integer
        Get
            Return MargenInferior - MargenSuperior
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected ReadOnly Property AnchoPagina As Integer
        Get
            Return MargenDerecho - MargenIzquierdo
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected ReadOnly Property CentroVerticalPagina As Integer
        Get
            Return (MargenInferior - MargenSuperior) \ 2
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Protected ReadOnly Property CentroHorizontalPagina As Integer
        Get
            Return (MargenDerecho - MargenIzquierdo) \ 2
        End Get
    End Property


    ''' <summary>
    ''' 
    ''' </summary>
    Protected PiePagina As String = ""

    ' ''' <summary>
    ' ''' Determina si se imprimió el documento luego de haber sido previsualizado.
    ' ''' </summary>
    'Public ImpresionFinalizada As Boolean = False

    'Variables de LICITACIONES

    ''' <summary>
    ''' Contiene el identificador de la licitación involucrada en la impresión.
    ''' </summary>
    Public IdLicitacion As Integer = -1

    ''' <summary>
    ''' Determina si se imprimió el documento luego de haber sido previsualizado.
    ''' </summary>
    Public ImpresionFinalizada As Boolean = False

    ''' <summary>
    ''' 
    ''' </summary>
    Dim dtLicitacion As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Dim dtItemsAPU As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Dim dtMaquinariaEquipo As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Dim dtMateriales As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Dim dtManoDeObra As DataTable

#End Region 'Variables de Impresión

#Region "Métodos de Impresión"

    ' 
    Public Sub New()
        Lapiz = New Pen(Brocha, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="margen"></param>
    Protected Sub AsignarMargenes(e As PrintPageEventArgs, margen As Integer)
        AsignarMargenes(e, margen, margen, margen, margen)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="margenVertical"></param>
    ''' <param name="margenHorizontal"></param>
    Protected Sub AsignarMargenes(e As PrintPageEventArgs, margenVertical As Integer, margenHorizontal As Integer)
        AsignarMargenes(e, margenVertical, margenHorizontal, margenVertical, margenHorizontal)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="margenSuperior"></param>
    ''' <param name="margenIzquierdo"></param>
    ''' <param name="margenInferior"></param>
    ''' <param name="margenDerecho"></param>
    Protected Sub AsignarMargenes(e As PrintPageEventArgs, margenSuperior As Integer, margenIzquierdo As Integer, margenInferior As Integer, margenDerecho As Integer)
        _margenSuperior = e.PageBounds.Top + margenSuperior
        _margenIzquierdo = e.PageBounds.Left + margenIzquierdo
        _margenInferior = e.PageBounds.Bottom - margenInferior
        _margenDerecho = e.PageBounds.Right - margenDerecho
    End Sub


    ''' <summary>Crea un objeto fuente de la familia "Arial" en base al tamaño y estilo indicados.</summary>
    ''' <param name="emSize">Tamaño de la fuente.</param>
    ''' <param name="fontStyleChars">
    ''' Estilo de fuente del texto.
    ''' Los posibles estilos que se pueden combinar son:
    ''' I: Cursiva (Italic).
    ''' N: Negrita (Bold).
    ''' S: Subrayado (Underline).
    ''' R: regular, no aplica ningún otro estilo.
    ''' </param>
    ''' <returns>Objeto fuente.</returns>
    Protected Function Formato_Etiqueta(emSize As Single, Optional fontStyleChars As String = "R") As Font
        If fontStyleChars.Contains("R") Then 'Regular, sin estilos.
            Return New Font("Arial", emSize, FontStyle.Regular)
        ElseIf fontStyleChars.Contains("I") AndAlso fontStyleChars.Contains("N") AndAlso fontStyleChars.Contains("S") Then
            Return New Font("Arial", emSize, FontStyle.Italic Or FontStyle.Bold Or FontStyle.Underline)
        ElseIf fontStyleChars.Contains("I") AndAlso fontStyleChars.Contains("N") Then
            Return New Font("Arial", emSize, FontStyle.Italic Or FontStyle.Bold)
        ElseIf fontStyleChars.Contains("I") AndAlso fontStyleChars.Contains("S") Then
            Return New Font("Arial", emSize, FontStyle.Italic Or FontStyle.Underline)
        ElseIf fontStyleChars.Contains("N") AndAlso fontStyleChars.Contains("S") Then
            Return New Font("Arial", emSize, FontStyle.Bold Or FontStyle.Underline)
        ElseIf fontStyleChars = "I" Then
            Return New Font("Arial", emSize, FontStyle.Italic)
        ElseIf fontStyleChars = "N" Then
            Return New Font("Arial", emSize, FontStyle.Bold)
        ElseIf fontStyleChars = "S" Then
            Return New Font("Arial", emSize, FontStyle.Underline)
        Else
            Return New Font("Arial", emSize, FontStyle.Regular)
        End If
    End Function


    ''' <summary>Ajusta una o varias líneas de texto dentro de márgenes horizontales.</summary>
    ''' <param name="vectorparrafos">Arreglo que contiene las líneas de texto.</param>
    ''' <param name="fuente">La fuente que se aplicó al texto.</param>
    ''' <param name="LongitudMaxima">Distancia a la cual se encuentra el márgen derecho desde la posición X de dibujado del texto.</param>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="ConLineaSeparacion">Insertar líneas en blanco intercaladas en el texto.</param>
    ''' <returns>Arreglo con líneas de texto separadas de forma tal que al imprimirse se ajusten a los márgenes</returns>
    Protected Function TextoAParrafoFuente(vectorparrafos As ArrayList, fuente As Font, LongitudMaxima As Double, e As PrintPageEventArgs, Optional ConLineaSeparacion As Boolean = False) As ArrayList
        Dim TextoEnParrafo As New ArrayList
        For i = 0 To vectorparrafos.Count - 1
            Dim Parrafo As String = vectorparrafos(i)
            Parrafo = Trim(Parrafo)
            Dim CadenaActual As String = ""
            Dim SiguientePalabra As String = ""
            Dim CadenaRestante As String = Parrafo
            Dim LongitudTotal As SizeF
            Dim LongitudLinea As SizeF
            Dim PosSiguienteSeparador As Integer
            Dim strCaracter As String
            Dim TempCadenaActual As String
            Dim NuevaLinea As Boolean
            If (Parrafo) <> "" Then
                While Trim(CadenaRestante <> "")
                    LongitudTotal = e.Graphics.MeasureString(CadenaRestante, fuente)
                    If LongitudTotal.Width < LongitudMaxima Then
                        TextoEnParrafo.Add(CadenaRestante)
                        CadenaRestante = ""
                    Else
                        CadenaActual = ""
                        SiguientePalabra = ""
                        NuevaLinea = False
                        Do
                            PosSiguienteSeparador = PosicionSiguienteSeparador(CadenaRestante, 1)
                            strCaracter = Mid$(CadenaRestante, PosSiguienteSeparador, 1)
                            SiguientePalabra = Mid$(CadenaRestante, 1, PosSiguienteSeparador)
                            TempCadenaActual = ""
                            If CadenaActual <> "" Then
                                TempCadenaActual = CadenaActual + " " + SiguientePalabra
                            Else
                                TempCadenaActual = SiguientePalabra
                            End If
                            LongitudLinea = e.Graphics.MeasureString(TempCadenaActual, fuente)
                            If LongitudLinea.Width <= LongitudMaxima Then
                                CadenaActual = TempCadenaActual
                                CadenaRestante = Mid$(CadenaRestante, PosSiguienteSeparador + 1, Len(CadenaRestante))
                                Select Case strCaracter
                                    Case vbNewLine, vbLf
                                        NuevaLinea = True
                                        TextoEnParrafo.Add(TempCadenaActual)
                                        CadenaRestante = Mid$(CadenaRestante, PosSiguienteSeparador + 1, Len(CadenaRestante))
                                    Case Else
                                        CadenaActual = TempCadenaActual
                                End Select
                            Else
                                NuevaLinea = True
                                TextoEnParrafo.Add(CadenaActual)
                                CadenaRestante = Mid$(CadenaRestante, 1, Len(CadenaRestante))
                            End If
                        Loop While Not NuevaLinea
                    End If
                End While
                'Quitar los espacios agregados al final
            End If
            If ConLineaSeparacion = True Then
                TextoEnParrafo.Add("")
            End If
        Next
        TextoAParrafoFuente = TextoEnParrafo
    End Function


    ''' <summary>Encuentra la posición del primer caracter en blanco de una cadena de texto.</summary>
    ''' <param name="texto">Texto del que se identifican los caracteres en blanco.</param>
    ''' <param name="Inicio">Posición a partir de la cual se empieza a buscar el siguiente caracter en blanco</param>
    ''' <returns>Posición donde se encuentra el siguiente caracter en blanco en el texto</returns>
    Protected Function PosicionSiguienteSeparador(texto As String, Inicio As Integer) As Integer
        Dim lngLongitudTexto = Len(texto)
        Dim strCaracter As String
        For lngPosicion = Inicio To lngLongitudTexto
            strCaracter = Mid$(texto, lngPosicion, 1)
            Select Case strCaracter
                Case vbNewLine, vbLf
                    PosicionSiguienteSeparador = lngPosicion
                    Exit Function
                    ' Si encuentra un espacio en blanco o un tabulador
                    ' en la última posición recorre la cadena hacia la izquierda
                    ' hasta encontrar un carácter
                Case " ", vbTab
                    PosicionSiguienteSeparador = lngPosicion
                    Exit Function
                Case Else
            End Select
        Next lngPosicion
        PosicionSiguienteSeparador = 1
    End Function


    ''' <summary>Indica la posición en el eje X donde se debe ubicar una línea de texto para aparecer centrada en la impresión.</summary>
    ''' <param name="Texto">La línea de texto que se va a centrar.</param>
    ''' <param name="fuente">La fuente que se aplicó al texto.</param>
    ''' <param name="TamañoLinea">El tamaño de la región donde se ubica el texto a centrar.</param>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <returns>La posición en el eje X en la que se debe dibujar el texto.</returns>
    Protected Function InicioCentradoTexto(Texto As String, fuente As Font, TamañoLinea As Integer, e As PrintPageEventArgs) As Integer
        Dim LongitudTotal As SizeF
        LongitudTotal = e.Graphics.MeasureString(Texto, fuente)
        InicioCentradoTexto = CInt((TamañoLinea / 2) - (LongitudTotal.Width / 2))
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="texto"></param>
    ''' <param name="fuente"></param>
    ''' <param name="anchoLinea"></param>
    ''' <param name="posicionY"></param>
    Protected Sub TextoCentrado(e As PrintPageEventArgs, texto As String, fuente As Font, anchoLinea As Integer, posicionX As Integer, posicionY As Integer)
        e.Graphics.DrawString(texto, fuente, Brocha, posicionX + InicioCentradoTexto(texto, fuente, anchoLinea, e), posicionY)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="texto"></param>
    ''' <param name="anchoLinea"></param>
    ''' <param name="posicionY"></param>
    ''' <param name="emSize"></param>
    ''' <param name="fontStyle"></param>
    Protected Sub TextoCentrado(e As PrintPageEventArgs, texto As String, anchoLinea As Integer, posicionX As Integer, posicionY As Integer, emSize As Single, Optional fontStyle As String = "R")
        e.Graphics.DrawString(texto, Formato_Etiqueta(emSize, fontStyle), Brocha, posicionX + InicioCentradoTexto(texto, Formato_Etiqueta(emSize, fontStyle), anchoLinea, e), posicionY)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="valor"></param>
    ''' <param name="fuente"></param>
    ''' <param name="anchoLinea"></param>
    ''' <param name="posicionX"></param>
    ''' <param name="posicionY"></param>
    ''' <param name="simboloMoneda"></param>
    Protected Sub TextoFormatoMoneda(e As PrintPageEventArgs, valor As Decimal, fuente As Font, anchoLinea As Integer, posicionX As Integer, posicionY As Integer, Optional simboloMoneda As String = "$")
        Dim ancho As Integer
        Dim texto As String
        texto = Format(valor, "N0")
        ancho = e.Graphics.MeasureString(texto, fuente).Width
        e.Graphics.DrawString(Trim(simboloMoneda), fuente, Brocha, posicionX, posicionY)
        e.Graphics.DrawString(texto, fuente, Brocha, posicionX + (anchoLinea - ancho), posicionY)
    End Sub


    ''' <summary>
    ''' Imprime una línea de texto alineada a la derecha, imprimiendo desde la izquierda de la posición horizontal indicada.
    ''' </summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="texto">Cadena de texto a imprimir.</param>
    ''' <param name="fuente">Estilo del texto</param>
    ''' <param name="posicionX">Posición horizontal donde se termina de imprimir la línea de texto.</param>
    ''' <param name="posicionY">Posición vertical desde donde se imprime la línea de texto.</param>
    Protected Sub TextoDerecha(e As PrintPageEventArgs, texto As String, fuente As Font, posicionX As Integer, posicionY As Integer)
        Dim ancho As Integer
        ancho = e.Graphics.MeasureString(texto, fuente).Width
        e.Graphics.DrawString(texto, fuente, Brocha, posicionX - ancho, posicionY)
    End Sub


    ''' <summary>Imprime líneas verticales y horizontales a modo de rejilla con los ejes X y Y rotulados.</summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="color">Color de las líneas.</param>
    ''' <param name="separacionPunteado">Separación de la línea punteada. Para dibujar una línea sólida, asignar el valor 0</param>
    ''' <param name="grosor">Grosor de las líneas.</param>
    ''' <param name="pasoX">Separación de las líneas en el eje X, si no se especifica valor para la separación en el eje Y, se toma este valor como separación de las líneas verticales.</param>
    ''' <param name="pasoY">Separación de las líneas en el eje Y.</param>
    Protected Sub ActivarRejilla(e As PrintPageEventArgs, color As Color, separacionPunteado As Integer, grosor As Single, pasoX As Integer, Optional pasoY As Integer = 0)
        Dim gridPen As Pen = New Pen(color)
        gridPen.Width = grosor
        If separacionPunteado > 0 Then
            gridPen.DashPattern = New Single() {separacionPunteado, separacionPunteado, separacionPunteado, separacionPunteado}
        End If
        Dim numberBrush As Brush = New SolidBrush(color)

        If pasoX > 5 Or pasoX < 400 Then
            For x As Integer = pasoX To e.PageBounds.Right Step pasoX
                e.Graphics.DrawLine(gridPen, x, e.PageBounds.Top, x, e.PageBounds.Bottom)
                e.Graphics.DrawString(x, Formato_Etiqueta(4, "N"), numberBrush, x - 4, e.PageBounds.Top + 2)
            Next
            If pasoY < 5 Or pasoY > 500 Then
                pasoY = pasoX
            End If
            For y As Integer = pasoY To e.PageBounds.Bottom Step pasoY
                e.Graphics.DrawString(y, Formato_Etiqueta(4, "N"), numberBrush, e.PageBounds.Left + 2, y - 4)
                e.Graphics.DrawLine(gridPen, e.PageBounds.Left, y, e.PageBounds.Right, y)
            Next
        End If
    End Sub


    ''' <summary>Dibuja un rectángulo con bordes redondeados.</summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="m_intxAxis">Punto inicial en el eje X.</param>
    ''' <param name="m_intyAxis">Punto inicial en el eje Y.</param>
    ''' <param name="m_intWidth">Ancho del rectángulo.</param>
    ''' <param name="m_intHeight">Altura del rectángulo.</param>
    ''' <param name="m_diameter">Diámetro del borde redondeado.</param>
    Protected Sub DrawRoundedRectangle(e As PrintPageEventArgs, m_intxAxis As Integer, m_intyAxis As Integer, m_intWidth As Integer, m_intHeight As Integer, m_diameter As Integer)
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
        'Top left arc
        e.Graphics.DrawArc(Pens.Black, ArcRect, 180, 90)
        e.Graphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)
        'Top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        e.Graphics.DrawArc(Pens.Black, ArcRect, 270, 90)
        e.Graphics.DrawLine(Pens.Black, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
        'Bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        e.Graphics.DrawArc(Pens.Black, ArcRect, 0, 90)
        e.Graphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)
        'Bottom left arc
        ArcRect.X = BaseRect.Left
        e.Graphics.DrawArc(Pens.Black, ArcRect, 90, 90)
        e.Graphics.DrawLine(Pens.Black, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
    End Sub

#End Region 'Métodos de Impresión

#Region "1 - LISTADO DE PRECIOS UNITARIOS"

    ''' <summary>
    ''' Indica si se deben usar los valores de los ítems que contemplan los porcentajes de Administración, Imprevistos y Utilidad de la Licitación.
    ''' </summary>
    Public valoresConAIU As Boolean = False ' Con/Sin AIU --> formatos aparte?

    ''' <summary>
    ''' 
    ''' </summary>
    Private WithEvents DocImp_Licitacion As New PrintDocument

    ' Impresión de Listado de Precios Unitarios de Licitación.
    Private Sub DocImpLicitacion(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_Licitacion.PrintPage
        AsignarMargenes(e, 40, 40, 60, 40)
        Dim posicionY As Integer = MargenSuperior

        Dim colItem As New Cl_ColumnaImpresión(60, MargenIzquierdo)
        Dim colDescripcion As New Cl_ColumnaImpresión(320, colItem)
        Dim colUnidad As New Cl_ColumnaImpresión(60, colDescripcion)
        Dim colCantidad As New Cl_ColumnaImpresión(70, colUnidad)
        Dim colValorUnitario As New Cl_ColumnaImpresión(130, colCantidad)
        Dim colValorTotal As New Cl_ColumnaImpresión(130, colValorUnitario)

        Const alturaItems As Integer = 20
        Const espacioDisponibleItems As Integer = 1060
        Dim vectorParrafos As New ArrayList
        Const desfaseTexto As Integer = 3

        '--------
        ' Carga de datos
        '--------
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImprExpLIC_ListadoDePrecios", conexion) 'LIC_ExportarItems
            comando.CommandType = CommandType.StoredProcedure
            If valoresConAIU Then
                comando.Parameters.AddWithValue("@TIPO", 1) 'Ítems con A.I.U.
            Else
                comando.Parameters.AddWithValue("@TIPO", 0) 'Ítems sin A.I.U.
            End If
            comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsListadoPrecios As New DataSet 'Contiene los datos de los ítems de la licitación que se ubican en el cuerpo del listado de precios.
            Try
                conexion.Open()
                adaptador.Fill(dsListadoPrecios)
                conexion.Close()
                If dsListadoPrecios.Tables.Count > 0 Then
                    dtLicitacion = dsListadoPrecios.Tables(0)
                    dtItemsAPU = dsListadoPrecios.Tables(1)
                    If dtItemsAPU.Rows.Count > 0 Then
                        datosCargados = True
                    Else
                        MsgBox("No hay ítems para imprimir.", MsgBoxStyle.Information, "Impresión Ítems A.P.U.")
                        Exit Sub
                    End If
                Else
                    MsgBox("No hay ítems para imprimir.", MsgBoxStyle.Information, "Impresión Ítems A.P.U.")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("No se cargaron los Ítems A.P.U. a imprimir.", MsgBoxStyle.Critical, "Error Impresión Ítems A.P.U.")
                Exit Sub
            Finally
                conexion.Close()
            End Try
        End If

        '--------
        ' Impresión
        '--------
        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 20)

        'Borde
        DrawRoundedRectangle(e, MargenIzquierdo, MargenSuperior, AnchoPagina, AltoPagina, 10)

        'Título
        TextoCentrado(e, dtLicitacion.Rows(0).Item("CONTRATISTA").ToString.ToUpper(), Formato_Etiqueta(20, "N"), AnchoPagina, MargenIzquierdo, posicionY + 10)
        'Subtítulo
        TextoCentrado(e, "PRESUPUESTO DE CONSTRUCCIÓN", Formato_Etiqueta(16, "N"), AnchoPagina, MargenIzquierdo, posicionY + 50)

        'Encabezado
        posicionY += 100
        e.Graphics.DrawString("PROPONENTE: " & dtLicitacion.Rows(0).Item("CLIENTE"), Formato_Etiqueta(8), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
        e.Graphics.DrawString("OBRA: " & dtLicitacion.Rows(0).Item("PROYECTO"), Formato_Etiqueta(8), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 20)
        e.Graphics.DrawString("FECHA: " & Date.Today, Formato_Etiqueta(8), Brocha, CentroHorizontalPagina + 20, posicionY + desfaseTexto + 20)

        'Cuerpo
        posicionY += 60
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
        TextoCentrado(e, "ÍTEM", Formato_Etiqueta(8, "N"), colItem.Ancho, colItem.Izquierda, posicionY + desfaseTexto)
        e.Graphics.DrawLine(Lapiz, colItem.Derecha, posicionY, colItem.Derecha, posicionY + 20)
        TextoCentrado(e, "DESCRIPCIÓN", Formato_Etiqueta(8, "N"), colDescripcion.Ancho, colDescripcion.Izquierda, posicionY + desfaseTexto)
        e.Graphics.DrawLine(Lapiz, colDescripcion.Derecha, posicionY, colDescripcion.Derecha, posicionY + 20)
        TextoCentrado(e, "UNIDAD", Formato_Etiqueta(8, "N"), colUnidad.Ancho, colUnidad.Izquierda, posicionY + desfaseTexto)
        e.Graphics.DrawLine(Lapiz, colUnidad.Derecha, posicionY, colUnidad.Derecha, posicionY + 20)
        TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colCantidad.Ancho, colCantidad.Izquierda, posicionY + desfaseTexto)
        e.Graphics.DrawLine(Lapiz, colCantidad.Derecha, posicionY, colCantidad.Derecha, posicionY + 20)
        TextoCentrado(e, "VALOR UNITARIO", Formato_Etiqueta(8, "N"), colValorUnitario.Ancho, colValorUnitario.Izquierda, posicionY + desfaseTexto)
        e.Graphics.DrawLine(Lapiz, colValorUnitario.Derecha, posicionY, colValorUnitario.Derecha, posicionY + 20)
        TextoCentrado(e, "COSTO PARCIAL", Formato_Etiqueta(8, "N"), colValorTotal.Ancho, colValorTotal.Izquierda, posicionY + desfaseTexto)

        posicionY += 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
        Dim posicionItem As Integer = posicionY
        For i As Integer = itemsImpresos To dtItemsAPU.Rows.Count - 1
            vectorParrafos.Add(dtItemsAPU.Rows(i).Item("DESCRIPCIÓN"))
            vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colDescripcion.Ancho - 10, e)
            If posicionItem + (vectorParrafos.Count * alturaItems) > espacioDisponibleItems Then
                Exit For
            End If
            If dtItemsAPU.Rows(i).Item("ESCAPITULO") = "S" Then
                e.Graphics.DrawString(dtItemsAPU.Rows(i).Item("ÍTEM"), Formato_Etiqueta(8, "N"), Brocha, colItem.Izquierda + 5, posicionItem + desfaseTexto)
                For j As Integer = 0 To vectorParrafos.Count - 1
                    e.Graphics.DrawString(vectorParrafos(j), Formato_Etiqueta(8, "N"), Brocha, colDescripcion.Izquierda + 5, (j * alturaItems) + posicionItem + desfaseTexto)
                Next
            Else
                e.Graphics.DrawString(dtItemsAPU.Rows(i).Item("ÍTEM"), Formato_Etiqueta(8), Brocha, colItem.Izquierda + 5, posicionItem + desfaseTexto)
                For j As Integer = 0 To vectorParrafos.Count - 1
                    e.Graphics.DrawString(vectorParrafos(j), Formato_Etiqueta(8), Brocha, colDescripcion.Izquierda + 5, (j * alturaItems) + posicionItem + desfaseTexto)
                Next
                TextoCentrado(e, dtItemsAPU.Rows(i).Item("UNIDAD"), Formato_Etiqueta(8), colUnidad.Ancho, colUnidad.Izquierda, posicionItem + desfaseTexto)
                e.Graphics.DrawString(Format(dtItemsAPU.Rows(i).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colCantidad.Izquierda + 5, posicionItem + desfaseTexto)
                If Not IsDBNull(dtItemsAPU.Rows(i).Item("VALOR UNITARIO")) Then
                    TextoFormatoMoneda(e, dtItemsAPU.Rows(i).Item("VALOR UNITARIO"), Formato_Etiqueta(8), colValorUnitario.Ancho - 10, colValorUnitario.Izquierda + 5, posicionItem + desfaseTexto)
                End If
                If Not IsDBNull(dtItemsAPU.Rows(i).Item("COSTO PARCIAL")) Then
                    TextoFormatoMoneda(e, dtItemsAPU.Rows(i).Item("COSTO PARCIAL"), Formato_Etiqueta(8), colValorTotal.Ancho - 10, colValorTotal.Izquierda + 5, posicionItem + desfaseTexto)
                End If
            End If
            posicionItem += vectorParrafos.Count * alturaItems
            itemsImpresos += 1
            e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            vectorParrafos.Clear()
        Next

        e.Graphics.DrawLine(Lapiz, colItem.Derecha, posicionY, colItem.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colDescripcion.Derecha, posicionY, colDescripcion.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colUnidad.Derecha, posicionY, colUnidad.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colCantidad.Derecha, posicionY, colCantidad.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colValorUnitario.Derecha, posicionY, colValorUnitario.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colValorTotal.Derecha, posicionY, colValorTotal.Derecha, posicionItem)
        posicionY = posicionItem
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)


        posicionY += 20
        If itemsImpresos >= dtItemsAPU.Rows.Count Then
            Dim costosDirectos As Decimal = 0
            Dim valorAdministracion As Decimal = 0
            Dim valorImprevistos As Decimal = 0
            Dim valorUtilidad As Decimal = 0
            Dim totalCostos As Decimal = 0

            'Calcular Costos Directos
            For i As Integer = 0 To dtItemsAPU.Rows.Count - 1
                If dtItemsAPU.Rows(i).Item("ESCAPITULO") = "N" Then
                    costosDirectos += dtItemsAPU.Rows(i).Item("COSTO PARCIAL")
                End If
            Next

            valorAdministracion = costosDirectos * (dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION") / 100)
            valorImprevistos = costosDirectos * (dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS") / 100)
            valorUtilidad = costosDirectos * (dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD") / 100)

            totalCostos = costosDirectos + valorAdministracion + valorImprevistos + valorUtilidad

            'Costos directos
            e.Graphics.DrawString("COSTOS DIRECTOS", Formato_Etiqueta(8), Brocha, colCantidad.Izquierda + 5, posicionY + 0)
            TextoFormatoMoneda(e, costosDirectos, Formato_Etiqueta(8), colValorTotal.Ancho - 10, colValorTotal.Izquierda + 5, posicionY + 0) '685

            'Costos indirectos
            e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta(8), Brocha, colCantidad.Izquierda + 5, posicionY + 20)
            TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION"), "0.####") & "%", Formato_Etiqueta(8), colValorUnitario.Derecha - 5, posicionY + 20)
            TextoFormatoMoneda(e, valorAdministracion, Formato_Etiqueta(8), colValorTotal.Ancho - 10, colValorTotal.Izquierda + 5, posicionY + 20)

            e.Graphics.DrawString("IMPREVISTOS", Formato_Etiqueta(8), Brocha, colCantidad.Izquierda + 5, posicionY + 40)
            TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS"), "0.####") & "%", Formato_Etiqueta(8), colValorUnitario.Derecha - 5, posicionY + 40)
            TextoFormatoMoneda(e, valorImprevistos, Formato_Etiqueta(8), colValorTotal.Ancho - 10, colValorTotal.Izquierda + 5, posicionY + 40)

            e.Graphics.DrawString("UTILIDADES", Formato_Etiqueta(8), Brocha, colCantidad.Izquierda + 5, posicionY + 60)
            TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD"), "0.####") & "%", Formato_Etiqueta(8), colValorUnitario.Derecha - 5, posicionY + 60)
            TextoFormatoMoneda(e, valorUtilidad, Formato_Etiqueta(8), colValorTotal.Ancho - 10, colValorTotal.Izquierda + 5, posicionY + 60)

            'Valor de la oferta [costos directos + costos indirectos] antes de IVA
            e.Graphics.DrawString("TOTAL COSTOS", Formato_Etiqueta(8, "N"), Brocha, colCantidad.Izquierda + 5, posicionY + 80)
            TextoFormatoMoneda(e, totalCostos, Formato_Etiqueta(8, "N"), colValorTotal.Ancho - 10, colValorTotal.Izquierda + 5, posicionY + 80)

            ' I.V.A.
            'porcentajeIVA
            'valorTotalIVA

            ' Valor total de la oferta [costos directos + costos indirectos] incluido el I.V.A.
        End If
        posicionY += 120
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)

        cantidadPaginasImpresas += 1


        If imprimirPieDePagina Then
            PiePagina = "Página " & cantidadPaginasImpresas & " de " & totalPaginas
        Else
            PiePagina = "Página " & cantidadPaginasImpresas
        End If
        TextoCentrado(e, PiePagina, Formato_Etiqueta(7, "N"), AnchoPagina, MargenIzquierdo, MargenInferior + 10)

        If itemsImpresos < dtItemsAPU.Rows.Count Then
            e.HasMorePages = True
        Else
            If totalPaginas > 0 AndAlso cantidadPaginasImpresas = (totalPaginas * 2) Then
                ImpresionFinalizada = True
            Else
                imprimirPieDePagina = True
                totalPaginas = cantidadPaginasImpresas
                cantidadPaginasImpresas = 0
                itemsImpresos = 0 'Reiniciar la variable de clase.
            End If
            e.HasMorePages = False
        End If
    End Sub

#End Region 'IMPRESIÓN LICITACIÓN

#Region "2 - DESGLOSE DE PRECIOS"

    ''' <summary>
    ''' Contiene los identificadores de los Ítems A.P.U. a imprimir.
    ''' Se envía como parámetro del procedimiento que lista los ítems para la impresión.
    ''' </summary>
    Public listadoAPU As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Private WithEvents DocImp_APU As New PrintDocument


    ' Impresión de Desglose de Precios de Licitación.
    Private Sub DocImpAPU(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_APU.PrintPage
        AsignarMargenes(e, 40, 40, 60, 40)
        Dim posicionY As Integer = MargenSuperior
        Const anchoColumnaTotales As Integer = 130

        'Definición de Columnas de la sección Mano de Obra.
        Dim colMO_Descripcion As New Cl_ColumnaImpresión(300, MargenIzquierdo)
        Dim colMO_Cantidad As New Cl_ColumnaImpresión(100, colMO_Descripcion)
        Dim colMO_Tarifa As New Cl_ColumnaImpresión(120, colMO_Cantidad)
        Dim colMO_Rendimiento As New Cl_ColumnaImpresión(120, colMO_Tarifa)
        Dim colMO_ValorParcial As New Cl_ColumnaImpresión(anchoColumnaTotales, colMO_Rendimiento)

        'Definición de Columnas de la sección Maquinaria y Equipo.
        Dim colME_Descripcion As New Cl_ColumnaImpresión(300, MargenIzquierdo)
        Dim colME_Cantidad As New Cl_ColumnaImpresión(100, colME_Descripcion)
        Dim colME_Tarifa As New Cl_ColumnaImpresión(120, colME_Cantidad)
        Dim colME_Rendimiento As New Cl_ColumnaImpresión(120, colME_Tarifa)
        Dim colME_ValorParcial As New Cl_ColumnaImpresión(anchoColumnaTotales, colME_Rendimiento)

        'Definición de Columnas de la sección Materiales.
        Dim colMa_Descripcion As New Cl_ColumnaImpresión(300, MargenIzquierdo)
        Dim colMa_Unidad As New Cl_ColumnaImpresión(100, colMa_Descripcion)
        Dim colMa_Cantidad As New Cl_ColumnaImpresión(120, colMa_Unidad)
        Dim colMa_Valor As New Cl_ColumnaImpresión(120, colMa_Cantidad)
        Dim colMa_ValorParcial As New Cl_ColumnaImpresión(anchoColumnaTotales, colMa_Valor)

        Const alturaItems As Integer = 20
        Const espacioDisponibleItems As Integer = 1060
        Dim vectorParrafos As New ArrayList
        Const desfaseTexto As Integer = 3

        Dim filasManoDeObra As DataRow()
        Dim filasMaquinariaEquipo As DataRow()
        Dim filasMateriales As DataRow()

        Dim posicionItem As Integer = 0
        Dim subtotalMaquinaria As Decimal = 0
        Dim subtotalMateriales As Decimal = 0
        Dim subtotalManoObra As Decimal = 0
        Dim maValorParcial As Decimal = 0
        Dim meValorParcial As Decimal = 0
        Dim moValorParcial As Decimal = 0

        Dim costoDirecto As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim precioUnitario As Decimal = 0

        '--------
        ' Carga de datos
        '--------
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImprExpLIC_DesgloseAPU", conexion)
            comando.CommandType = CommandType.StoredProcedure
            If listadoAPU Is Nothing Then
                comando.Parameters.AddWithValue("@TIPO", 0) 'Todos los ítems de la Licitación.
            Else
                comando.Parameters.AddWithValue("@TIPO", 1) 'Listado de ítems seleccionados en tabla parámetro
            End If
            comando.Parameters.AddWithValue("@TablaItemsAPU", listadoAPU)
            comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsDeslgoseItems As New DataSet 'Contiene las tablas con los datos de la licitación, ítems A.P.U. y recursos para la impresión.
            Try
                conexion.Open()
                adaptador.Fill(dsDeslgoseItems)
                conexion.Close()
                If dsDeslgoseItems.Tables.Count > 0 Then
                    dtLicitacion = dsDeslgoseItems.Tables(0)
                    dtItemsAPU = dsDeslgoseItems.Tables(1)
                    dtMaquinariaEquipo = dsDeslgoseItems.Tables(2)
                    dtMateriales = dsDeslgoseItems.Tables(3)
                    dtManoDeObra = dsDeslgoseItems.Tables(4)
                    If dtItemsAPU.Rows.Count > 0 Then
                        datosCargados = True
                    Else
                        MsgBox("No hay ítems para imprimir.", MsgBoxStyle.Information, "Impresión Ítems A.P.U.")
                        Exit Sub
                    End If
                Else
                    MsgBox("No hay ítems para imprimir.", MsgBoxStyle.Information, "Impresión Ítems A.P.U.")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("No se cargaron los Ítems A.P.U. a imprimir.", MsgBoxStyle.Critical, "Error Impresión Ítems A.P.U.")
                Exit Sub
            Finally
                conexion.Close()
            End Try
        Else

        End If

        '--------
        ' Impresión
        '--------
        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 20)

        'Borde
        DrawRoundedRectangle(e, MargenIzquierdo, MargenSuperior, AnchoPagina, AltoPagina, 10)

        'Título
        TextoCentrado(e, dtLicitacion.Rows(0).Item("CONTRATISTA"), Formato_Etiqueta(20, "N"), AnchoPagina, MargenIzquierdo, posicionY + 10)

        'Subtítulo
        TextoCentrado(e, dtLicitacion.Rows(0).Item("PROYECTO"), Formato_Etiqueta(16, "N"), AnchoPagina, MargenIzquierdo, posicionY + 50)
        TextoCentrado(e, "DESGLOSE DE PRECIOS", Formato_Etiqueta(16, "N"), AnchoPagina, MargenIzquierdo, posicionY + 80)

        posicionY += 140

        'Encabezado
        'e.Graphics.DrawString("OBJETO: " & , Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
        e.Graphics.DrawString("PROPONENTE: " & dtLicitacion.Rows(0).Item("CLIENTE"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 0)
        e.Graphics.DrawString("FECHA: " & Date.Today, Formato_Etiqueta(8, "N"), Brocha, CentroHorizontalPagina + 20, posicionY + desfaseTexto + 0)
        'e.Graphics.DrawString("CAPÍTULO: ", Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 40)
        e.Graphics.DrawString("UNIDAD DE MEDIDA: " & dtItemsAPU.Rows(itemsImpresos).Item("ABREVIATURA"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 20)

        e.Graphics.DrawString("ÍTEM: " & dtItemsAPU.Rows(itemsImpresos).Item("NROITEMCLIENTE"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 40)
        e.Graphics.DrawString("DESCRIPCIÓN: " & dtItemsAPU.Rows(itemsImpresos).Item("DESCRIPCION"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 120, posicionY + desfaseTexto + 40)
        e.Graphics.DrawString("CANTIDAD: " & Format(dtItemsAPU.Rows(itemsImpresos).Item("CANTIDADESTIMADA"), "0.####"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 620, posicionY + desfaseTexto + 40)

        'e.Graphics.DrawString("REND(UND/DÍA): " & Format(dtItemsAPU.Rows(itemsImpresos).Item("RENDIMIENTO"), "0.####"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 220, posicionY + desfaseTexto + 120)
        'Dim rdias As Decimal = (dtItemsAPU.Rows(itemsImpresos).Item("CANTIDADESTIMADA") * dtItemsAPU.Rows(itemsImpresos).Item("RENDIMIENTO")) / dtLicitacion.Rows(0).Item("HORASDIARIAS")
        'e.Graphics.DrawString("DÍAS: " & Format(rdias, "0.####"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 420, posicionY + desfaseTexto + 120)

        filasMaquinariaEquipo = dtMaquinariaEquipo.Select("IDAPU=" & dtItemsAPU.Rows(itemsImpresos).Item("IDAPU"))
        filasMateriales = dtMateriales.Select("IDAPU=" & dtItemsAPU.Rows(itemsImpresos).Item("IDAPU"))
        filasManoDeObra = dtManoDeObra.Select("IDAPU=" & dtItemsAPU.Rows(itemsImpresos).Item("IDAPU"))

        posicionY += 100

        'Cuerpo

        'Maquinaria y Equipos
        e.Graphics.DrawString("1. MAQUINARIA Y EQUIPO", Formato_Etiqueta(10, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
        posicionY += 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
        TextoCentrado(e, "DESCRIPCIÓN", Formato_Etiqueta(8, "N"), colME_Descripcion.Ancho, colME_Descripcion.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colME_Cantidad.Ancho, colME_Cantidad.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "TARIFA/HORA", Formato_Etiqueta(8, "N"), colME_Tarifa.Ancho, colME_Tarifa.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "RENDIMIENTO", Formato_Etiqueta(6, "N"), colME_Rendimiento.Ancho, colME_Rendimiento.Izquierda, posicionY + desfaseTexto - 3)
        TextoCentrado(e, "hr / und", Formato_Etiqueta(6, "N"), colME_Rendimiento.Ancho, colME_Rendimiento.Izquierda, posicionY + desfaseTexto + 7)
        TextoCentrado(e, "VALOR PARCIAL", Formato_Etiqueta(8, "N"), colME_ValorParcial.Ancho, colME_ValorParcial.Izquierda, posicionY + desfaseTexto)
        posicionItem = posicionY + 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
        For i As Integer = 0 To filasMaquinariaEquipo.Length - 1
            vectorParrafos.Add(filasMaquinariaEquipo(i).Item("DESCRIPCIÓN"))
            vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colME_Descripcion.Ancho - 10, e)
            If posicionItem + (vectorParrafos.Count * alturaItems) > espacioDisponibleItems Then
                Exit For
            End If
            e.Graphics.DrawString(Format(dtMaquinariaEquipo.Rows(i).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colME_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
            TextoFormatoMoneda(e, dtMaquinariaEquipo.Rows(i).Item("TARIFA/HORA"), Formato_Etiqueta(8), colME_Tarifa.Ancho - 10, colME_Tarifa.Izquierda + 5, posicionItem + desfaseTexto)
            e.Graphics.DrawString(Format(dtMaquinariaEquipo.Rows(i).Item("RENDIMIENTO hr/und"), "0.####"), Formato_Etiqueta(8), Brocha, colME_Rendimiento.Izquierda + 5, posicionItem + desfaseTexto)
            meValorParcial = dtMaquinariaEquipo.Rows(i).Item("VALOR PARCIAL")
            TextoFormatoMoneda(e, meValorParcial, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionItem + desfaseTexto)
            subtotalMaquinaria += meValorParcial
            For n As Integer = 0 To vectorParrafos.Count - 1
                e.Graphics.DrawString(vectorParrafos(n), Formato_Etiqueta(8), Brocha, colME_Descripcion.Izquierda + 5, (n * alturaItems) + posicionItem + desfaseTexto)
            Next
            posicionItem += vectorParrafos.Count * alturaItems
            e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            vectorParrafos.Clear()
        Next
        e.Graphics.DrawLine(Lapiz, colME_Descripcion.Derecha, posicionY, colME_Descripcion.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colME_Cantidad.Derecha, posicionY, colME_Cantidad.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colME_Tarifa.Derecha, posicionY, colME_Tarifa.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colME_Rendimiento.Derecha, posicionY, colME_Rendimiento.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
        posicionY = posicionItem
        'SUBTOTAL
        e.Graphics.DrawString("SUBTOTAL", Formato_Etiqueta(8, "N"), Brocha, colME_Tarifa.Izquierda + 5, posicionY + desfaseTexto)
        TextoFormatoMoneda(e, subtotalMaquinaria, Formato_Etiqueta(8, "N"), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto)
        posicionY += 20

        posicionY += 20
        'Materiales
        e.Graphics.DrawString("2. MATERIALES", Formato_Etiqueta(10, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
        posicionY += 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
        TextoCentrado(e, "DESCRIPCIÓN", Formato_Etiqueta(8, "N"), colMa_Descripcion.Ancho, colMa_Descripcion.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "UNIDAD", Formato_Etiqueta(8, "N"), colMa_Unidad.Ancho, colMa_Unidad.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colMa_Cantidad.Ancho, colMa_Cantidad.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "VALOR UNITARIO", Formato_Etiqueta(8, "N"), colMa_Valor.Ancho, colMa_Valor.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "VALOR PARCIAL", Formato_Etiqueta(8, "N"), colMa_ValorParcial.Ancho, colMa_ValorParcial.Izquierda, posicionY + desfaseTexto)
        posicionItem = posicionY + 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
        For j As Integer = 0 To filasMateriales.Length - 1
            vectorParrafos.Add(filasMateriales(j).Item("DESCRIPCIÓN"))
            vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colMa_Descripcion.Ancho - 10, e)
            If posicionItem + (vectorParrafos.Count * alturaItems) > espacioDisponibleItems Then
                Exit For
            End If
            TextoCentrado(e, dtMateriales.Rows(j).Item("UNIDAD"), Formato_Etiqueta(8), colMa_Unidad.Ancho - 10, colMa_Unidad.Izquierda + 5, posicionItem + desfaseTexto)
            e.Graphics.DrawString(Format(dtMateriales.Rows(j).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colMa_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
            TextoFormatoMoneda(e, dtMateriales.Rows(j).Item("VALOR UNITARIO"), Formato_Etiqueta(8), colMa_Valor.Ancho - 10, colMa_Valor.Izquierda + 5, posicionItem + desfaseTexto)
            maValorParcial = dtMateriales.Rows(j).Item("VALOR PARCIAL")
            TextoFormatoMoneda(e, maValorParcial, Formato_Etiqueta(8), colMa_ValorParcial.Ancho - 10, colMa_ValorParcial.Izquierda + 5, posicionItem + desfaseTexto)
            subtotalMateriales += maValorParcial
            For n As Integer = 0 To vectorParrafos.Count - 1
                e.Graphics.DrawString(vectorParrafos(n), Formato_Etiqueta(8), Brocha, colMa_Descripcion.Izquierda + 5, (n * alturaItems) + posicionItem + desfaseTexto)
            Next
            posicionItem += vectorParrafos.Count * alturaItems
            e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            vectorParrafos.Clear()
        Next
        e.Graphics.DrawLine(Lapiz, colMa_Descripcion.Derecha, posicionY, colMa_Descripcion.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colMa_Unidad.Derecha, posicionY, colMa_Unidad.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colMa_Cantidad.Derecha, posicionY, colMa_Cantidad.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colMa_Valor.Derecha, posicionY, colMa_Valor.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
        posicionY = posicionItem
        'SUBTOTAL
        e.Graphics.DrawString("SUBTOTAL", Formato_Etiqueta(8, "N"), Brocha, colMa_Valor.Izquierda + 5, posicionY + desfaseTexto)
        TextoFormatoMoneda(e, subtotalMateriales, Formato_Etiqueta(8, "N"), colMa_ValorParcial.Ancho - 10, colMa_ValorParcial.Izquierda + 5, posicionY + desfaseTexto)
        posicionY += 20

        posicionY += 20
        'Mano de Obra
        e.Graphics.DrawString("3. MANO DE OBRA", Formato_Etiqueta(10, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
        posicionY += 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
        TextoCentrado(e, "CARGO", Formato_Etiqueta(8, "N"), colMO_Descripcion.Ancho, colMO_Descripcion.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colMO_Cantidad.Ancho, colMO_Cantidad.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "TARIFA / H.H.", Formato_Etiqueta(8, "N"), colMO_Tarifa.Ancho, colMO_Tarifa.Izquierda, posicionY + desfaseTexto)
        TextoCentrado(e, "RENDIMIENTO", Formato_Etiqueta(6, "N"), colMO_Rendimiento.Ancho, colMO_Rendimiento.Izquierda, posicionY + desfaseTexto - 3)
        TextoCentrado(e, "hr / und", Formato_Etiqueta(6, "N"), colMO_Rendimiento.Ancho, colMO_Rendimiento.Izquierda, posicionY + desfaseTexto + 7)
        TextoCentrado(e, "VALOR PARCIAL", Formato_Etiqueta(8, "N"), colMO_ValorParcial.Ancho, colMO_ValorParcial.Izquierda, posicionY + desfaseTexto)
        posicionItem = posicionY + 20
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
        Dim rendimientoManoDeObra As Decimal = 0
        For k As Integer = 0 To filasManoDeObra.Length - 1
            vectorParrafos.Add(filasManoDeObra(k).Item("CARGO"))
            vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colMO_Descripcion.Ancho - 10, e)
            If posicionItem + (vectorParrafos.Count * alturaItems) > espacioDisponibleItems Then
                Exit For
            End If
            e.Graphics.DrawString(Format(dtManoDeObra.Rows(k).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colMO_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
            TextoFormatoMoneda(e, dtManoDeObra.Rows(k).Item("TARIFA / H.H."), Formato_Etiqueta(8), colMO_Tarifa.Ancho - 10, colMO_Tarifa.Izquierda + 5, posicionItem + desfaseTexto)
            e.Graphics.DrawString(Format(dtManoDeObra.Rows(k).Item("RENDIMIENTO hr/und"), "0.####"), Formato_Etiqueta(8), Brocha, colMO_Rendimiento.Izquierda + 5, posicionItem + desfaseTexto)
            moValorParcial = dtManoDeObra.Rows(k).Item("VALOR PARCIAL")
            TextoFormatoMoneda(e, moValorParcial, Formato_Etiqueta(8), colMO_ValorParcial.Ancho - 10, colMO_ValorParcial.Izquierda + 5, posicionItem + desfaseTexto)
            subtotalManoObra += moValorParcial
            For n As Integer = 0 To vectorParrafos.Count - 1
                e.Graphics.DrawString(vectorParrafos(n), Formato_Etiqueta(8), Brocha, colMO_Descripcion.Izquierda + 5, (n * alturaItems) + posicionItem + desfaseTexto)
            Next
            posicionItem += vectorParrafos.Count * alturaItems
            e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            vectorParrafos.Clear()
        Next
        e.Graphics.DrawLine(Lapiz, colMO_Descripcion.Derecha, posicionY, colMO_Descripcion.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colMO_Cantidad.Derecha, posicionY, colMO_Cantidad.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colMO_Tarifa.Derecha, posicionY, colMO_Tarifa.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, colMO_Rendimiento.Derecha, posicionY, colMO_Rendimiento.Derecha, posicionItem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
        posicionY = posicionItem
        'SUBTOTAL
        e.Graphics.DrawString("SUBTOTAL", Formato_Etiqueta(8, "N"), Brocha, colMO_Rendimiento.Izquierda + 5, posicionY + desfaseTexto)
        TextoFormatoMoneda(e, subtotalManoObra, Formato_Etiqueta(8, "N"), colMO_ValorParcial.Ancho - 10, colMO_ValorParcial.Izquierda + 5, posicionY + desfaseTexto)
        posicionY += 20

        'Totales
        posicionY += 40

        'Calcular Costo Directo
        costoDirecto = subtotalMaquinaria + subtotalMateriales + subtotalManoObra
        valorAdministracion = costoDirecto * (dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION") / 100)
        valorImprevistos = costoDirecto * (dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS") / 100)
        valorUtilidad = costoDirecto * (dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD") / 100)

        precioUnitario = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

        e.Graphics.DrawString("TOTAL COSTO DIRECTO", Formato_Etiqueta(8), Brocha, 445, posicionY + 0)
        TextoFormatoMoneda(e, costoDirecto, Formato_Etiqueta(8), anchoColumnaTotales - 10, (MargenDerecho - anchoColumnaTotales) + 5, posicionY + 0)

        'Costos indirectos
        e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta(8), Brocha, 445, posicionY + 20)
        TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION"), "0.####") & "%", Formato_Etiqueta(8), (MargenDerecho - anchoColumnaTotales) - 5, posicionY + 20)
        TextoFormatoMoneda(e, valorAdministracion, Formato_Etiqueta(8), anchoColumnaTotales - 10, (MargenDerecho - anchoColumnaTotales) + 5, posicionY + 20)

        e.Graphics.DrawString("IMPREVISTOS", Formato_Etiqueta(8), Brocha, 445, posicionY + 40)
        TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS"), "0.####") & "%", Formato_Etiqueta(8), (MargenDerecho - anchoColumnaTotales) - 5, posicionY + 40)
        TextoFormatoMoneda(e, valorImprevistos, Formato_Etiqueta(8), anchoColumnaTotales - 10, (MargenDerecho - anchoColumnaTotales) + 5, posicionY + 40)

        e.Graphics.DrawString("UTILIDADES", Formato_Etiqueta(8), Brocha, 445, posicionY + 60)
        TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD"), "0.####") & "%", Formato_Etiqueta(8), (MargenDerecho - anchoColumnaTotales) - 5, posicionY + 60)
        TextoFormatoMoneda(e, valorUtilidad, Formato_Etiqueta(8), anchoColumnaTotales - 10, (MargenDerecho - anchoColumnaTotales) + 5, posicionY + 60)

        e.Graphics.DrawString("PRECIO UNITARIO TOTAL", Formato_Etiqueta(8, "N"), Brocha, 445, posicionY + 80)
        TextoFormatoMoneda(e, precioUnitario, Formato_Etiqueta(8, "N"), anchoColumnaTotales - 10, (MargenDerecho - anchoColumnaTotales) + 5, posicionY + 80)

        posicionY += 120
        'e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)

        itemsImpresos += 1
        cantidadPaginasImpresas += 1


        If imprimirPieDePagina Then
            PiePagina = "Página " & cantidadPaginasImpresas & " de " & totalPaginas
        Else
            PiePagina = "Página " & cantidadPaginasImpresas
        End If
        TextoCentrado(e, PiePagina, Formato_Etiqueta(7, "N"), AnchoPagina, MargenIzquierdo, MargenInferior + 10)

        If itemsImpresos < dtItemsAPU.Rows.Count Then
            e.HasMorePages = True
        Else
            imprimirPieDePagina = True
            totalPaginas = cantidadPaginasImpresas
            cantidadPaginasImpresas = 0
            itemsImpresos = 0 'Revisar si variable local o variable de clase.
            subtotalMaquinaria = 0
            subtotalMateriales = 0
            subtotalManoObra = 0
            e.HasMorePages = False
        End If
    End Sub

#End Region 'IMPRESIÓN ÍTEMS A.P.U.

#Region "3 - RESUMEN DE RECURSOS"

    Private meCantidadImpresos As Integer = 0
    Private maCantidadImpresos As Integer = 0
    Private moCantidadImpresos As Integer = 0
    Private totalMaquinaria As Decimal = 0
    Private totalMateriales As Decimal = 0
    Private totalManoObra As Decimal = 0

    ''' <summary>
    ''' 
    ''' </summary>
    Private WithEvents DocImp_Recursos As New PrintDocument


    ' Impresión de Resumen de Recursos de Licitación.
    Private Sub DocImpRecursos(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_Recursos.PrintPage
        AsignarMargenes(e, 40, 40, 60, 40)
        Dim posicionY As Integer = MargenSuperior
        Const anchoColumnaTotales As Integer = 130

        'Definición de Columnas de la sección Maquinaria y Equipo.
        Dim colME_Descripcion As New Cl_ColumnaImpresión(400, MargenIzquierdo)
        Dim colME_Cantidad As New Cl_ColumnaImpresión(120, colME_Descripcion)
        Dim colME_Tarifa As New Cl_ColumnaImpresión(120, colME_Cantidad)
        Dim colME_ValorParcial As New Cl_ColumnaImpresión(anchoColumnaTotales, colME_Tarifa)

        'Definición de Columnas de la sección Materiales.
        Dim colMa_Descripcion As New Cl_ColumnaImpresión(300, MargenIzquierdo)
        Dim colMa_Unidad As New Cl_ColumnaImpresión(100, colMa_Descripcion)
        Dim colMa_Cantidad As New Cl_ColumnaImpresión(120, colMa_Unidad)
        Dim colMa_Valor As New Cl_ColumnaImpresión(120, colMa_Cantidad)
        Dim colMa_ValorParcial As New Cl_ColumnaImpresión(anchoColumnaTotales, colMa_Valor)

        'Definición de Columnas de la sección Mano de Obra.
        Dim colMO_Descripcion As New Cl_ColumnaImpresión(400, MargenIzquierdo)
        Dim colMO_Cantidad As New Cl_ColumnaImpresión(120, colMO_Descripcion)
        Dim colMO_Tarifa As New Cl_ColumnaImpresión(120, colMO_Cantidad)
        Dim colMO_ValorParcial As New Cl_ColumnaImpresión(anchoColumnaTotales, colMO_Tarifa)

        Const alturaItems As Integer = 20
        Const espacioDisponibleItems As Integer = 1060
        Dim vectorParrafos As New ArrayList
        Const desfaseTexto As Integer = 3

        Dim valorAdministracion As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim valorTotalRecurso As Decimal = 0

        '--------
        ' Carga de datos
        '--------
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImprExpLIC_ResumenDeRecursos", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@TIPO", DBNull.Value)
            comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
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
                    datosCargados = True
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
        Else

        End If

        '--------
        ' Impresión
        '--------
        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 20)

        'Borde
        DrawRoundedRectangle(e, MargenIzquierdo, MargenSuperior, AnchoPagina, AltoPagina, 10)

        'Título
        TextoCentrado(e, dtLicitacion.Rows(0).Item("CONTRATISTA"), Formato_Etiqueta(20, "N"), AnchoPagina, MargenIzquierdo, posicionY + 10)

        'Subtítulo
        TextoCentrado(e, "RESUMEN DE RECURSOS", Formato_Etiqueta(16, "N"), AnchoPagina, MargenIzquierdo, posicionY + 50)

        posicionY += 100
        'Encabezado
        e.Graphics.DrawString("PROPONENTE:" & dtLicitacion.Rows(0).Item("CLIENTE"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 0)
        e.Graphics.DrawString("OBRA: " & dtLicitacion.Rows(0).Item("PROYECTO"), Formato_Etiqueta(8, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto + 20)
        e.Graphics.DrawString("FECHA: " & Date.Today, Formato_Etiqueta(8, "N"), Brocha, CentroHorizontalPagina + 20, posicionY + desfaseTexto + 20)

        'Cuerpo
        Dim posicionItem As Integer = 0
        posicionY += 80

        'Maquinaria y Equipo
        If meCantidadImpresos < dtMaquinariaEquipo.Rows.Count Then
            Dim alturaTotalizadorMaquinaria As Integer = 1 * alturaItems 'Un renglón
            e.Graphics.DrawString("MAQUINARIA Y EQUIPO", Formato_Etiqueta(10, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
            posicionY += 20
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
            TextoCentrado(e, "DESCRIPCIÓN", Formato_Etiqueta(8, "N"), colME_Descripcion.Ancho, colME_Descripcion.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colME_Cantidad.Ancho, colME_Cantidad.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "TARIFA/HORA", Formato_Etiqueta(8, "N"), colME_Tarifa.Ancho, colME_Tarifa.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "SUBTOTAL", Formato_Etiqueta(8, "N"), colME_ValorParcial.Ancho, colME_ValorParcial.Izquierda, posicionY + desfaseTexto)
            posicionItem = posicionY + 20
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            For i As Integer = meCantidadImpresos To dtMaquinariaEquipo.Rows.Count - 1
                vectorParrafos.Add(dtMaquinariaEquipo.Rows(i).Item("DESCRIPCIÓN"))
                vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colME_Descripcion.Ancho - 10, e)
                If posicionItem + (vectorParrafos.Count * alturaItems) + alturaTotalizadorMaquinaria > espacioDisponibleItems Then
                    Exit For
                End If
                totalMaquinaria += dtMaquinariaEquipo.Rows(i).Item("SUBTOTAL")
                e.Graphics.DrawString(Format(dtMaquinariaEquipo.Rows(i).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colME_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
                TextoFormatoMoneda(e, dtMaquinariaEquipo.Rows(i).Item("TARIFA/HORA"), Formato_Etiqueta(8), colME_Tarifa.Ancho - 10, colME_Tarifa.Izquierda + 5, posicionItem + desfaseTexto)
                TextoFormatoMoneda(e, dtMaquinariaEquipo.Rows(i).Item("SUBTOTAL"), Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionItem + desfaseTexto)
                For n As Integer = 0 To vectorParrafos.Count - 1
                    e.Graphics.DrawString(vectorParrafos(n), Formato_Etiqueta(8), Brocha, colME_Descripcion.Izquierda + 5, (n * alturaItems) + posicionItem + desfaseTexto)
                Next
                meCantidadImpresos += 1
                posicionItem += vectorParrafos.Count * alturaItems
                e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
                vectorParrafos.Clear()
            Next
            e.Graphics.DrawLine(Lapiz, colME_Descripcion.Derecha, posicionY, colME_Descripcion.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colME_Cantidad.Derecha, posicionY, colME_Cantidad.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colME_Tarifa.Derecha, posicionY, colME_Tarifa.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            posicionY = posicionItem
            posicionY += 20
            'TOTALES
            If posicionY + alturaTotalizadorMaquinaria < espacioDisponibleItems Then
                'e.Graphics.DrawString("TOTAL", Formato_Etiqueta(8, "N"), Brocha, colME_Tarifa.Izquierda + 5, posicionY + desfaseTexto)
                'TextoFormatoMoneda(e, totalMaquinaria, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto)

                valorAdministracion = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION") / 100)
                valorImprevistos = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS") / 100)
                valorUtilidad = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD") / 100)

                valorTotalRecurso = totalMaquinaria + valorAdministracion + valorImprevistos + valorUtilidad

                e.Graphics.DrawString("TOTAL COSTO DIRECTO", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 0)
                TextoFormatoMoneda(e, totalMaquinaria, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 0)

                'Costos indirectos
                e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 20)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 20)
                TextoFormatoMoneda(e, valorAdministracion, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 20)

                e.Graphics.DrawString("IMPREVISTOS", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 40)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 40)
                TextoFormatoMoneda(e, valorImprevistos, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 40)

                e.Graphics.DrawString("UTILIDADES", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 60)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 60)
                TextoFormatoMoneda(e, valorUtilidad, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 60)

                e.Graphics.DrawString("PRECIO UNITARIO TOTAL", Formato_Etiqueta(8, "N"), Brocha, 445, posicionY + desfaseTexto + 80)
                TextoFormatoMoneda(e, valorTotalRecurso, Formato_Etiqueta(8, "N"), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 80)

                cantidadPaginasImpresas += 1

                If imprimirPieDePagina Then
                    PiePagina = "Página " & cantidadPaginasImpresas & " de " & totalPaginas
                Else
                    PiePagina = "Página " & cantidadPaginasImpresas
                End If
                TextoCentrado(e, PiePagina, Formato_Etiqueta(7, "N"), AnchoPagina, MargenIzquierdo, MargenInferior + 10)

                e.HasMorePages = True
                Exit Sub
            End If
        End If

        'Materiales
        If maCantidadImpresos < dtMateriales.Rows.Count Then
            Dim alturaTotalizadorMateriales As Integer = 1 * alturaItems 'Un renglón
            e.Graphics.DrawString("MATERIALES", Formato_Etiqueta(10, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
            posicionY += 20
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
            TextoCentrado(e, "DESCRIPCIÓN", Formato_Etiqueta(8, "N"), colMa_Descripcion.Ancho, colMa_Descripcion.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "UNIDAD", Formato_Etiqueta(8, "N"), colMa_Unidad.Ancho, colMa_Unidad.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colMa_Cantidad.Ancho, colMa_Cantidad.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "VALOR", Formato_Etiqueta(8, "N"), colMa_Valor.Ancho, colMa_Valor.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "SUBTOTAL", Formato_Etiqueta(8, "N"), colMa_ValorParcial.Ancho, colMa_ValorParcial.Izquierda, posicionY + desfaseTexto)
            posicionItem = posicionY + 20
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            For j As Integer = maCantidadImpresos To dtMateriales.Rows.Count - 1
                vectorParrafos.Add(dtMateriales.Rows(j).Item("DESCRIPCIÓN"))
                vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colMa_Descripcion.Ancho - 10, e)
                If posicionItem + (vectorParrafos.Count * alturaItems) + alturaTotalizadorMateriales > espacioDisponibleItems Then
                    Exit For
                End If
                totalMateriales += dtMateriales.Rows(j).Item("SUBTOTAL")
                TextoCentrado(e, dtMateriales.Rows(j).Item("UNIDAD"), Formato_Etiqueta(8), colMa_Unidad.Ancho - 10, colMa_Unidad.Izquierda + 5, posicionItem + desfaseTexto)
                e.Graphics.DrawString(Format(dtMateriales.Rows(j).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colMa_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
                TextoFormatoMoneda(e, dtMateriales.Rows(j).Item("VALOR"), Formato_Etiqueta(8), colMa_Valor.Ancho - 10, colMa_Valor.Izquierda + 5, posicionItem + desfaseTexto)
                TextoFormatoMoneda(e, dtMateriales.Rows(j).Item("SUBTOTAL"), Formato_Etiqueta(8), colMa_ValorParcial.Ancho - 10, colMa_ValorParcial.Izquierda + 5, posicionItem + desfaseTexto)
                For n As Integer = 0 To vectorParrafos.Count - 1
                    e.Graphics.DrawString(vectorParrafos(n), Formato_Etiqueta(8), Brocha, colMa_Descripcion.Izquierda + 5, (n * alturaItems) + posicionItem + desfaseTexto)
                Next
                maCantidadImpresos += 1
                posicionItem += vectorParrafos.Count * alturaItems
                e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
                vectorParrafos.Clear()
            Next
            e.Graphics.DrawLine(Lapiz, colMa_Descripcion.Derecha, posicionY, colMa_Descripcion.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colMa_Unidad.Derecha, posicionY, colMa_Unidad.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colMa_Cantidad.Derecha, posicionY, colMa_Cantidad.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colMa_Valor.Derecha, posicionY, colMa_Valor.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            posicionY = posicionItem
            posicionY += 20
            'TOTALES
            If posicionY + alturaTotalizadorMateriales < espacioDisponibleItems Then
                'e.Graphics.DrawString("TOTAL", Formato_Etiqueta(8, "N"), Brocha, colMa_Valor.Izquierda + 5, posicionY + desfaseTexto)
                'TextoFormatoMoneda(e, totalMateriales, Formato_Etiqueta(8, "N"), colMa_ValorParcial.Ancho - 10, colMa_ValorParcial.Izquierda + 5, posicionY + desfaseTexto)

                valorAdministracion = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION") / 100)
                valorImprevistos = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS") / 100)
                valorUtilidad = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD") / 100)

                valorTotalRecurso = totalMaquinaria + valorAdministracion + valorImprevistos + valorUtilidad

                e.Graphics.DrawString("TOTAL COSTO DIRECTO", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 0)
                TextoFormatoMoneda(e, totalMaquinaria, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 0)

                'Costos indirectos
                e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 20)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 20)
                TextoFormatoMoneda(e, valorAdministracion, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 20)

                e.Graphics.DrawString("IMPREVISTOS", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 40)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 40)
                TextoFormatoMoneda(e, valorImprevistos, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 40)

                e.Graphics.DrawString("UTILIDADES", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 60)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 60)
                TextoFormatoMoneda(e, valorUtilidad, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 60)

                e.Graphics.DrawString("PRECIO UNITARIO TOTAL", Formato_Etiqueta(8, "N"), Brocha, 445, posicionY + desfaseTexto + 80)
                TextoFormatoMoneda(e, valorTotalRecurso, Formato_Etiqueta(8, "N"), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 80)

                cantidadPaginasImpresas += 1

                If imprimirPieDePagina Then
                    PiePagina = "Página " & cantidadPaginasImpresas & " de " & totalPaginas
                Else
                    PiePagina = "Página " & cantidadPaginasImpresas
                End If
                TextoCentrado(e, PiePagina, Formato_Etiqueta(7, "N"), AnchoPagina, MargenIzquierdo, MargenInferior + 10)

                e.HasMorePages = True
                Exit Sub
            End If
        End If

        'Mano de Obra
        If moCantidadImpresos < dtManoDeObra.Rows.Count Then
            Dim alturaTotalizadorManoObra As Integer = 1 * alturaItems 'Un renglón
            e.Graphics.DrawString("MANO DE OBRA", Formato_Etiqueta(10, "N"), Brocha, MargenIzquierdo + 20, posicionY + desfaseTexto)
            posicionY += 20
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionY, MargenDerecho, posicionY)
            TextoCentrado(e, "DESCRIPCIÓN", Formato_Etiqueta(8, "N"), colMO_Descripcion.Ancho, colMO_Descripcion.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "CANTIDAD", Formato_Etiqueta(8, "N"), colMO_Cantidad.Ancho, colMO_Cantidad.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "TARIFA/HH", Formato_Etiqueta(8, "N"), colMO_Tarifa.Ancho, colMO_Tarifa.Izquierda, posicionY + desfaseTexto)
            TextoCentrado(e, "SUBTOTAL", Formato_Etiqueta(8, "N"), colMO_ValorParcial.Ancho, colMO_ValorParcial.Izquierda, posicionY + desfaseTexto)
            posicionItem = posicionY + 20
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            Dim rendimientoManoDeObra As Decimal = 0
            For k As Integer = moCantidadImpresos To dtManoDeObra.Rows.Count - 1
                vectorParrafos.Add(dtManoDeObra.Rows(k).Item("DESCRIPCIÓN"))
                vectorParrafos = TextoAParrafoFuente(vectorParrafos, Formato_Etiqueta(8), colMO_Descripcion.Ancho - 10, e)
                If posicionItem + (vectorParrafos.Count * alturaItems) + alturaTotalizadorManoObra > espacioDisponibleItems Then
                    Exit For
                End If
                totalManoObra += dtManoDeObra.Rows(k).Item("SUBTOTAL")
                'TextoCentrado(e, dtManoDeObra.Rows(k).Item("CANTIDAD"), Formato_Etiqueta(8), colMO_Cantidad.Ancho - 10, colMO_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
                e.Graphics.DrawString(Format(dtManoDeObra.Rows(k).Item("CANTIDAD"), "0.####"), Formato_Etiqueta(8), Brocha, colMO_Cantidad.Izquierda + 5, posicionItem + desfaseTexto)
                TextoFormatoMoneda(e, dtManoDeObra.Rows(k).Item("TARIFA/HH"), Formato_Etiqueta(8), colMO_Tarifa.Ancho - 10, colMO_Tarifa.Izquierda + 5, posicionItem + desfaseTexto)
                TextoFormatoMoneda(e, dtManoDeObra.Rows(k).Item("SUBTOTAL"), Formato_Etiqueta(8), colMO_ValorParcial.Ancho - 10, colMO_ValorParcial.Izquierda + 5, posicionItem + desfaseTexto)
                For n As Integer = 0 To vectorParrafos.Count - 1
                    e.Graphics.DrawString(vectorParrafos(n), Formato_Etiqueta(8), Brocha, colMO_Descripcion.Izquierda + 5, (n * alturaItems) + posicionItem + desfaseTexto)
                Next
                moCantidadImpresos += 1
                posicionItem += vectorParrafos.Count * alturaItems
                e.Graphics.DrawLine(lineaPunteada, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
                vectorParrafos.Clear()
            Next
            e.Graphics.DrawLine(Lapiz, colMO_Descripcion.Derecha, posicionY, colMO_Descripcion.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colMO_Cantidad.Derecha, posicionY, colMO_Cantidad.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, colMO_Tarifa.Derecha, posicionY, colMO_Tarifa.Derecha, posicionItem)
            e.Graphics.DrawLine(Lapiz, MargenIzquierdo, posicionItem, MargenDerecho, posicionItem)
            posicionY = posicionItem
            posicionY += 20
            'TOTALES
            If posicionY + alturaTotalizadorManoObra < espacioDisponibleItems Then
                'e.Graphics.DrawString("TOTAL", Formato_Etiqueta(8, "N"), Brocha, colMO_Tarifa.Izquierda + 5, posicionY + desfaseTexto)
                'TextoFormatoMoneda(e, totalManoObra, Formato_Etiqueta(8, "N"), colMO_ValorParcial.Ancho - 10, colMO_ValorParcial.Izquierda + 5, posicionY + desfaseTexto)

                valorAdministracion = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION") / 100)
                valorImprevistos = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS") / 100)
                valorUtilidad = totalMaquinaria * (dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD") / 100)

                valorTotalRecurso = totalMaquinaria + valorAdministracion + valorImprevistos + valorUtilidad

                e.Graphics.DrawString("TOTAL COSTO DIRECTO", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 0)
                TextoFormatoMoneda(e, totalMaquinaria, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 0)

                'Costos indirectos
                e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 20)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 20)
                TextoFormatoMoneda(e, valorAdministracion, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 20)

                e.Graphics.DrawString("IMPREVISTOS", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 40)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 40)
                TextoFormatoMoneda(e, valorImprevistos, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 40)

                e.Graphics.DrawString("UTILIDADES", Formato_Etiqueta(8), Brocha, 445, posicionY + desfaseTexto + 60)
                TextoDerecha(e, Format(dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD"), "0.####") & "%", Formato_Etiqueta(8), colME_Tarifa.Derecha - 5, posicionY + desfaseTexto + 60)
                TextoFormatoMoneda(e, valorUtilidad, Formato_Etiqueta(8), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 60)

                e.Graphics.DrawString("PRECIO UNITARIO TOTAL", Formato_Etiqueta(8, "N"), Brocha, 445, posicionY + desfaseTexto + 80)
                TextoFormatoMoneda(e, valorTotalRecurso, Formato_Etiqueta(8, "N"), colME_ValorParcial.Ancho - 10, colME_ValorParcial.Izquierda + 5, posicionY + desfaseTexto + 80)

                'e.HasMorePages = True
                'Exit Sub
            End If
        End If

        cantidadPaginasImpresas += 1

        If imprimirPieDePagina Then
            PiePagina = "Página " & cantidadPaginasImpresas & " de " & totalPaginas
        Else
            PiePagina = "Página " & cantidadPaginasImpresas
        End If
        TextoCentrado(e, PiePagina, Formato_Etiqueta(7, "N"), AnchoPagina, MargenIzquierdo, MargenInferior + 10)

        If meCantidadImpresos < dtMaquinariaEquipo.Rows.Count OrElse maCantidadImpresos < dtMateriales.Rows.Count OrElse moCantidadImpresos < dtManoDeObra.Rows.Count Then
            e.HasMorePages = True
        Else
            imprimirPieDePagina = True
            totalPaginas = cantidadPaginasImpresas
            cantidadPaginasImpresas = 0
            meCantidadImpresos = 0
            maCantidadImpresos = 0
            moCantidadImpresos = 0
            totalMaquinaria = 0
            totalMateriales = 0
            totalManoObra = 0
            e.HasMorePages = False
        End If
    End Sub

#End Region 'IMPRESIÓN RECURSOS

#Region "Métodos de Impresión"

    ''' <summary></summary>
    ''' <param name="Formatos"></param>
    ''' <param name="VerVistaPrevia"></param>
    ''' <param name="Doblecara"></param>
    Public Sub FormatoImprimirLicitaciones(ByVal Formatos As ArrayList, ByVal VerVistaPrevia As Boolean, Optional ByVal Doblecara As Boolean = False)
        Dim PrintDialog1 As New PrintDialog()
        If PrintDialog1.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If
        Dim i As Integer
        Dim wimpresoras As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            wimpresoras = PrinterSettings.InstalledPrinters.Item(i)
            If InStr(1, wimpresoras, PrintDialog1.PrinterSettings.PrinterName, CompareMethod.Text) > 0 Then
                PrintDialog1.PrinterSettings.PrinterName = wimpresoras
            End If
        Next
        VistaPrevia.PrintPreviewControl.Zoom = 1.5
        VistaPrevia.WindowState = FormWindowState.Maximized
        If PrintDialog1.PrinterSettings.CanDuplex Then
            If Doblecara = True Then
                PrintDialog1.PrinterSettings.Duplex = Duplex.Vertical
            End If
        End If
        For i = 0 To Formatos.Count - 1
            Select Case CInt(Formatos(i))
                Case 1 'LISTADO DE PRECIOS UNITARIOS - Licitación
                    DocImp_Licitacion.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_Licitacion.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_Licitacion
                    VistaPrevia.PrintPreviewControl.Zoom = 1
                Case 2 'DESGLOSE DE PRECIOS - Ítems A.P.U.
                    DocImp_APU.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_APU.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_APU
                    VistaPrevia.PrintPreviewControl.Zoom = 1
                Case 3 'RESUMEN DE RECURSOS
                    DocImp_Recursos.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_Recursos.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_Recursos
                    VistaPrevia.PrintPreviewControl.Zoom = 1
            End Select
            Try
                Cursor.Current = Cursors.WaitCursor
                If VerVistaPrevia = True Then
                    VistaPrevia.ShowDialog()
                Else
                    VistaPrevia.Document.Print()
                End If
            Catch ex As Exception
                MsgBox("No se ha podido completar el proceso de impresión, por favor revisar la configuración.", MsgBoxStyle.Critical, "ERROR")
            End Try
        Next i
    End Sub

#End Region 'Métodos de Impresión

End Class 'Cl_Impresión


Public Class Cl_ColumnaImpresión

    ''' <summary>
    ''' 
    ''' </summary>
    Private _ancho As Integer

    ''' <summary>
    ''' 
    ''' </summary>
    Private _izquierda As Integer

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property Ancho As Integer
        Get
            Return _ancho
        End Get
        Private Set(value As Integer)
            _ancho = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property Izquierda As Integer
        Get
            Return _izquierda
        End Get
        Private Set(value As Integer)
            _izquierda = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ReadOnly Property Derecha As Integer
        Get
            Return Izquierda + Ancho
        End Get
    End Property


    ' 
    Public Sub New(ancho As Integer, izquierda As Integer)
        _izquierda = izquierda
        _ancho = ancho
    End Sub


    ' 
    Public Sub New(ancho As Integer, columnaAnterior As Cl_ColumnaImpresión)
        Me.Izquierda = columnaAnterior.Derecha
        Me.Ancho = ancho
    End Sub

End Class 'Cl_ColumnaImpresión