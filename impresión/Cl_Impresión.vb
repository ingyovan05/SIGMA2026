Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

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

#End Region 'Variables de Impresión.

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

End Class


''' <summary>
''' 
''' </summary>
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