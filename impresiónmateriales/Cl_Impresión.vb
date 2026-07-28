Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Drawing.Text
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System
Imports MessagingToolkit.QRCode.Codec


Public Class Cl_Impresión

#Region "Para Imprimir"
    Private imagen As Image = My.Resources.ResourceManager.GetObject("images")
    Private imagenCSI As Image = My.Resources.ResourceManager.GetObject("csi")
    Private zamorana As Image = My.Resources.ResourceManager.GetObject("zamorana")
    Private imagen_Cancelado As Image = My.Resources.ResourceManager.GetObject("SelloCancelado")
    Private imagen_BD As Image = My.Resources.ResourceManager.GetObject("images")

    ''' <summary>
    ''' Tabla que contiene los centros de operación y/o centros de costos de Zamorana para imprimesión de Logo.
    ''' </summary>
    ''' <remarks>
    ''' Ver/Asignar centros de operación y centros de costos en el método New() de la clase.
    ''' </remarks>
    Private hsCentrosOperacionZamorana As New System.Collections.Generic.HashSet(Of String)

    ''' <summary>
    ''' Tabla que contiene los identificadores de las bodegas de Zamorana para imprimesión de Logo.
    ''' </summary>
    ''' <remarks>
    ''' Ver/Asignar bodegas en el método New() de la clase.
    ''' </remarks>
    Private hsBodegasZamorana As New System.Collections.Generic.HashSet(Of String)

    Public LogoEmpresa As Integer = 0

    Public EA As String

    Dim Lapiz As Pen
    Dim Lapiz_Grueso As Pen
    Dim Brocha As New SolidBrush(Color.Black)
    Dim lineaPunteada As New Pen(Color.Gray, 1)

    Dim Formato_Etiqueta_4 As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_4I As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_4R As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_4RS As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_5 As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_5I As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_5R As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_5RS As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_6 As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_6I As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_6R As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_6RS As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_7 As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_7I As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_7R As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_7RS As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_8 As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_8I As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_8R As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_8RS As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_9 As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_9I As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_9R As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_9RS As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_9RSN As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)

    Dim Formato_Etiqueta_10 As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_10I As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_10R As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_10RS As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_10RSN As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)

    Dim Formato_Etiqueta_11 As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_11I As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_11R As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_11RS As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_11IB As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Bold)

    Dim Formato_Etiqueta_12 As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_12I As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_12R As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_12RS As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_13 As New Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_13I As New Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_13R As New Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_13RS As New Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_14 As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_14I As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_14R As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_14RS As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_15 As New Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_16 As New Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_18 As New Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_20 As New Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_40 As New Drawing.Font("Arial", 40.0!, System.Drawing.FontStyle.Bold)

    Dim Formato_Etiqueta_50 As New Drawing.Font("Arial", 50.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_50R As New Drawing.Font("Arial", 50.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_50I As New Drawing.Font("Arial", 50.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_50RS As New Drawing.Font("Arial", 50.0!, System.Drawing.FontStyle.Underline)

    Dim Formato_Etiqueta_60 As New Drawing.Font("Arial", 60.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_60R As New Drawing.Font("Arial", 60.0!, System.Drawing.FontStyle.Regular)

    Dim Formato_Etiqueta_70 As New Drawing.Font("Arial", 70.0!, System.Drawing.FontStyle.Bold)

    Dim Formato_Etiqueta_80 As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_80I As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_80R As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_80RS As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Underline)

    'Variables de la forma
    Dim Img As Image
    Dim G As Graphics

    Dim EspacioParrafo As Integer = 20
    Dim caracteresporparrafo As Integer = 88

    'Variables para impresión
    Public NombreCargoPropuesto As String
    Public IdCargoPropuesto As Integer
    Public ListaReporte As New ArrayList
    Public Idpersona As Integer = -1
    Dim adap As New Dscomunes.Ds_MaestrosTableAdapters.PERSONABASICOTableAdapter
    Dim ds_perso As New Dscomunes.Ds_Maestros

    Dim ClConvertir As New FuncionesBase.Cl_Convertir_Num_Letras

    Dim contpaginas As Integer = 1
    Dim paginastotal As Integer

    Private contadorPaginasImpresas As UInteger = 0
    Private totalPaginasImpresion As UInteger = 0


    Private Function formatohoraimpresión(ByVal fecha As Date) As String
        Dim resultado As String = ""
        If fecha.Hour.ToString.Length = 1 Then
            resultado = "0" + fecha.Hour.ToString
        Else
            If fecha.Hour > 12 Then
                resultado = (fecha.Hour - 12).ToString
            Else
                resultado = fecha.Hour.ToString
            End If
        End If
        If fecha.Minute.ToString.Length = 1 Then
            resultado = resultado + ":0" + fecha.Minute.ToString
        Else
            resultado = resultado + ":" + fecha.Minute.ToString
        End If
        If fecha.Hour > 12 Then
            resultado = resultado + " am"
        Else
            resultado = resultado + " pm"
        End If
        formatohoraimpresión = resultado
    End Function


    Public Sub New()
        Lapiz = New Pen(Brocha, 1)
        Lapiz_Grueso = New Pen(Brocha, 2)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        hsCentrosOperacionZamorana.Add("018") 'Equipos de Perforación Horizontal Dirigida de Zamorana.
        hsCentrosOperacionZamorana.Add("038") 'Equipos PHD del proyecto Gasoducto Mamonal-Paiva.
        hsBodegasZamorana.Add("CGMP") 'Equipos PHD del proyecto Gasoducto Mamonal-Paiva.
        hsBodegasZamorana.Add("AA72") 'Equipo American Auger.
        hsBodegasZamorana.Add("HK250") 'Equipo Herrenknecht.
        hsBodegasZamorana.Add("PD150") 'Equipo Prime Drilling.
        hsBodegasZamorana.Add("TTX13") 'Equipo Tracto-Technik.
    End Sub


    Public Function PosicionCorte(ByVal Texto As String, ByVal Parrafo As Long) As Long
        Dim lngLongitudTexto As Long
        Dim lngContador As Long
        Dim strCaracter As String = ""
        Dim strIzquierda As String

        lngLongitudTexto = Len(Texto)
        ' Recorre carácter a carácter la cadena
        ' hasta la posición Párrafo.
        ' esta búsqueda se interrumpe si encuentra una carácter
        ' de retorno de carro o salto de línea o si se acaba la cadena
        Do While lngContador < Parrafo And _
                  lngContador <= lngLongitudTexto _
                  And strCaracter <> vbNewLine _
                  And strCaracter <> vbLf
            lngContador = lngContador + 1
            strCaracter = Mid$(Texto, lngContador, 1)
        Loop
        If lngContador < Parrafo Then
            PosicionCorte = lngContador
        Else
            Select Case strCaracter
                Case vbNewLine, vbLf
                    PosicionCorte = lngContador
                    ' Si encuentra un espacio en blanco o un tabulador
                    ' en la última posición recorre la cadena hacia la izquierda
                    ' hasta encontrar un carácter
                Case " ", vbTab
                    Do While (strCaracter = " " Or strCaracter = vbTab)
                        lngContador = lngContador - 1
                        strCaracter = Mid$(Texto, lngContador, 1)
                    Loop
                    PosicionCorte = lngContador + 1
                Case Else
                    ' Busca un espacio en blanco o tabulador a la izquierda
                    ' para efectuar el corte en un blanco
                    PosicionCorte = lngContador
                    Do While (strCaracter <> " " _
                              And strCaracter <> vbTab _
                              And lngContador > 1)
                        lngContador = lngContador - 1
                        strCaracter = Mid$(Texto, lngContador, 1)
                    Loop
                    'Extrae la cadena sin blancos a la derecha
                    strIzquierda = RTrim(Left$(Texto, lngContador))
                    PosicionCorte = Len(strIzquierda)
            End Select
        End If
    End Function


    Public Function SubParrafo(ByVal Texto As String, ByVal Parrafo As Long) As String
        ' Devuelve una cadena contenida en la parte izquierda de Texto
        ' de longitud menor ó igual que el valor de párrafo
        Dim lngContador As Long
        Dim lngLongitudTexto As Long
        Dim lngBlancos As Long
        Dim lngBlancosPorEspacio As Long
        Dim lngEspacios As Long
        Dim lngPosicion As Long
        Dim strCaracter As String
        Dim strLadoIzquierdo As String = ""
        Dim lngEspacioActual As Long
        Dim astrEspacios() As String

        lngLongitudTexto = Len(Texto)
        If lngLongitudTexto = Parrafo Then
            SubParrafo = Texto
        Else
            lngBlancos = Parrafo - lngLongitudTexto
            ' Averiguar el número de espacios en blanco que hay en texto
            For lngPosicion = 1 To lngLongitudTexto
                strCaracter = Mid$(Texto, lngPosicion, 1)
                If strCaracter = " " Then
                    lngEspacios = lngEspacios + 1
                End If
            Next lngPosicion
            If lngEspacios = 0 Then
                SubParrafo = Texto
            Else
                ' Uso la matriz dinámica astrEspacios para almacenar
                ' los blancos a añadir
                ReDim astrEspacios(lngEspacios)
                lngBlancosPorEspacio = lngBlancos \ lngEspacios
                For lngContador = 1 To lngEspacios
                    astrEspacios(lngContador) = Space(lngBlancosPorEspacio)
                Next lngContador
                For lngContador = 1 _
                        To lngBlancos - lngBlancosPorEspacio * lngEspacios
                    astrEspacios(lngContador) = astrEspacios(lngContador) & " "


                Next lngContador
                For lngPosicion = 1 To lngLongitudTexto
                    strCaracter = Mid$(Texto, lngPosicion, 1)
                    strLadoIzquierdo = strLadoIzquierdo & strCaracter
                    If strCaracter = " " Then
                        lngEspacioActual = lngEspacioActual + 1
                        strLadoIzquierdo = strLadoIzquierdo _
                                          & astrEspacios(lngEspacioActual)
                    End If
                Next lngPosicion
                SubParrafo = strLadoIzquierdo
            End If
        End If
    End Function


    Public Function SubParrafo1(ByVal Parrafo As String, ByVal fuente As Drawing.Font, ByVal longitud As Double, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As String
        If Parrafo.IndexOf(" ") = -1 Then
            SubParrafo1 = Parrafo
            Exit Function
        End If

        Parrafo = Trim(Parrafo)
        If (Parrafo) <> "" Then
            Dim sz As SizeF = e.Graphics.MeasureString(Parrafo, fuente)
            If sz.Width < longitud / 1.3 Then
                SubParrafo1 = Parrafo
                Exit Function
            End If
            Dim espacioinicial As String = " "
            Dim temp1 As String = Parrafo
            Dim temp2 As String = ""
            While sz.Width < longitud
                Dim posespacio As Integer
                posespacio = temp1.ToString.IndexOf(espacioinicial)
                If posespacio = -1 Then
                    Exit While
                End If
                temp2 = temp2 + Mid(temp1, 1, posespacio + 1)
                temp1 = Mid(temp1, posespacio + 2, Parrafo.ToString.Length)
                If Trim(temp1) = "" Then
                    Exit While
                End If
                temp2 = temp2 + " "
                sz = e.Graphics.MeasureString(temp2 + temp1, fuente)
            End While
            If sz.Width < longitud Then
                SubParrafo1 = SubParrafo1(temp2 + temp1, fuente, longitud, e)
            Else
                SubParrafo1 = temp2 + temp1
            End If
            Exit Function
        End If
        SubParrafo1 = Parrafo
    End Function


    Public Function PosicionSiguienteSeparador(ByVal texto, ByVal Inicio) As Integer
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


    Public Function TextoAParrafoFuente(ByVal vectorparrafos As ArrayList, ByVal fuente As Drawing.Font, _
                                        ByVal LongitudMaxima As Double, ByVal e As System.Drawing.Printing.PrintPageEventArgs, _
                                        Optional ByVal ConLineaSeparacion As Boolean = True) As ArrayList
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
                            'LongitudLinea = e.Graphics.MeasureString(TempCadenaActual + " " + SiguientePalabra, fuente)
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
                'quitar los espacios agregados al final
            End If
            If ConLineaSeparacion = True Then
                TextoEnParrafo.Add("")
            End If

        Next
        TextoAParrafoFuente = TextoEnParrafo
    End Function


    Public Function InicioCentradoTexto(ByVal Texto As String, ByVal fuente As Drawing.Font, _
                                            ByVal TamañoLinea As Integer, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As Integer
        Dim LongitudTotal As SizeF
        LongitudTotal = e.Graphics.MeasureString(Texto, fuente)
        InicioCentradoTexto = CInt((TamañoLinea / 2) - (LongitudTotal.Width / 2))
    End Function


    ''' <summary>Imprime líneas verticales y horizontales a modo de rejilla con los ejes X y Y rotulados.</summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="color">Color de las líneas.</param>
    ''' <param name="separacionPunteado">Separación de la línea punteada. Para dibujar una línea sólida, asignar el valor 0</param>
    ''' <param name="grosor">Grosor de las líneas.</param>
    ''' <param name="pasoX">Separación de las líneas en el eje X, si no se especifica valor para la separación en el eje Y, se toma este valor como separación de las líneas verticales.</param>
    ''' <param name="pasoY">Separación de las líneas en el eje Y.</param>
    Public Sub ActivarRejilla(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal color As Color, ByVal separacionPunteado As Integer, ByVal grosor As Single, ByVal pasoX As Integer, Optional pasoY As Integer = 0)
        Dim gridPen As Pen = New Pen(color)
        gridPen.Width = grosor
        If separacionPunteado > 0 Then
            gridPen.DashPattern = New Single() {separacionPunteado, separacionPunteado, separacionPunteado, separacionPunteado}
        End If
        Dim numberBrush As Brush = New SolidBrush(color)

        If pasoX > 5 Or pasoX < 400 Then
            For x As Integer = pasoX To e.PageBounds.Right Step pasoX
                e.Graphics.DrawLine(gridPen, x, e.PageBounds.Top, x, e.PageBounds.Bottom)
                e.Graphics.DrawString(x, Formato_Etiqueta_4, numberBrush, x - 4, e.PageBounds.Top + 2)
            Next
            If pasoY < 5 Or pasoY > 500 Then
                pasoY = pasoX
            End If
            For y As Integer = pasoY To e.PageBounds.Bottom Step pasoY
                e.Graphics.DrawString(y, Formato_Etiqueta_4, numberBrush, e.PageBounds.Left + 2, y - 4)
                e.Graphics.DrawLine(gridPen, e.PageBounds.Left, y, e.PageBounds.Right, y)
            Next
        End If
    End Sub


    Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                                  ByVal m_intxAxis As Integer, _
                                  ByVal m_intyAxis As Integer, _
                                  ByVal m_intWidth As Integer, _
                                  ByVal m_intHeight As Integer, _
                                  ByVal m_diameter As Integer)
        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth,
                                      m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location,
                                  New SizeF(m_diameter, m_diameter))
        'top left Arc
        objGraphics.DrawArc(Pens.Black, ArcRect, 180, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2),
                             m_intyAxis,
                             m_intxAxis + m_intWidth - CInt(m_diameter / 2),
                             m_intyAxis)
        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 270, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + m_intWidth,
                             m_intyAxis + CInt(m_diameter / 2),
                             m_intxAxis + m_intWidth,
                             m_intyAxis + m_intHeight - CInt(m_diameter / 2))
        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 0, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2),
                             m_intyAxis + m_intHeight,
                             m_intxAxis + m_intWidth - CInt(m_diameter / 2),
                             m_intyAxis + m_intHeight)
        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(Pens.Black, ArcRect, 90, 90)
        objGraphics.DrawLine(Pens.Black,
                             m_intxAxis, m_intyAxis + CInt(m_diameter / 2),
                             m_intxAxis,
                             m_intyAxis + m_intHeight - CInt(m_diameter / 2))
    End Sub



#End Region

#Region "MATERIALES"

#Region "Variables"
    Dim DsCompras As New Ds_Compras
    Dim DsCancelarCompras As New Ds_Compras
    Dim DsRequisicion As New Ds_Requisicion
    Public IDREQUISICION As Integer
    Dim DAREQUISICION As New Ds_RequisicionTableAdapters.REQUISICIONTableAdapter
    Dim DAITEMREQUISICION As New Ds_RequisicionTableAdapters.ITEMREQUISICIONTableAdapter
    Dim FilaRequisicion As DataRow
    Dim FilaItemRequisicion As DataRow
    Dim ITEMS As Integer = 0
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Public ImpresionFinalizada As Boolean = False
#End Region

#Region "60 - ICS-GRAL-F-01 REQUISICION"
    Dim WithEvents DocImp_RequisiciónICSGRALF01 As New PrintDocument 'Documento a imprimir

    ''' <summary>Espacio vertical ocupado por los ítems de la requisición que disminuye cada vez que se imprime un artículo. Reinicia al pasar a nueva página</summary>
    Dim ESPACIOFILAS_RQ As Integer = 0

    ''' <summary>Cantidad de ítems impresos. Reinicia al terminar la visualización previa.</summary>
    Dim ITEMS_RQ As Integer = 0

    ''' <summary>Cantidad de páginas impresas. No reinicia durante la impresión.</summary>
    Dim TotalImpresoRQ As Integer = 0

    ''' <summary>Determina si ya se cargaron los datos de la requisición para no realizar la consulta nuevamente al imprimir.</summary>
    Dim ImpresionRequisicion As Boolean = False

    ''' <summary>Determina si se debe imprimir el texto de encabezado y la línea separadora debajo.</summary>
    Dim imprimirEncabezado As Boolean = True

    Public RQCancelada As Boolean = False

    ''' <summary>Cantidad de páginas impresas. Reinicia al terminar la visualización previa</summary>
    Dim contpaginasRQ As Integer = 0

    ''' <summary>Cantidad de páginas a imprimir. No reinicia durante la impresión</summary>
    Dim paginastotalRQ As Integer = 0

    ''' <summary>Determina si se debe imprimir el texto de pie de página. Se habilita al terminar la visualización previa</summary>
    Dim imprimirPieDePagina As Boolean = False

    ''' <summary>Alamcena los datos de la requisición a imprimir</summary>
    Private dtRequisicion As New DataTable

    ''' <summary>Almacena los datos de los ítems de la requisición a imprimir</summary>
    Private dtItemRequisicion As New DataTable

    ''*************************************************************************************************************
    Private indiceSticker As Integer = 0
    Private fuenteSticker As Font
    Private pfcSticker As PrivateFontCollection = New PrivateFontCollection()
    Private fontFamilySticker As FontFamily
    Private fuenteStickerCargada As Boolean = False
    Private Const nombreFuenteCodigoBarras As String = "FREE3OF9.TTF"


    Private logoIsmocol As Image = My.Resources.ResourceManager.GetObject("images")

    '*********************************************************************************************************************
    Dim fuente As Font
    Dim fuente1 As Font
    Dim pfc As PrivateFontCollection = New PrivateFontCollection()
    Dim fontFamily As FontFamily


    '
    Private Sub DocImpRequisiciónICSGRALF01(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RequisiciónICSGRALF01.PrintPage

        '***********************************************************
        Try
            If IO.File.Exists("C:\WINDOWS\fonts\FREE3OF9.TF") = False Then
                IO.File.Copy(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF", "C:\WINDOWS\fonts\FREE3OF9.TTF")
            End If
        Catch ex As Exception
        End Try

        pfc.AddFontFile(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF")
        fontFamily = pfc.Families(0)
        fuente = New Font(fontFamily, 20)

        '*****************************************************************************************************


        Brocha.Color = Color.Black
        Const MargenDerecha As Integer = 50

        Dim Cadena_Total_ENCABEZADO As New ArrayList
        Dim CadenasENCABEZADO As New ArrayList

        If dtRequisicion.Rows.Count = 0 Then
            'Cargar datos Requisición.
            comando = New SqlCommand("SELECT * FROM ImpresionRequisicion(@IDREQUISICION)", conexion)
            comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICION)
            adaptador = New SqlDataAdapter(comando)
            Try
                conexion.Open()
                adaptador.Fill(dtRequisicion)
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                conexion.Close()
            End Try

            'Cargar datos ítems de Requisición.
            comando = New SqlCommand("SELECT * FROM ImpresionItemRequisicion(@IDREQUISICION)", conexion)
            comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICION)
            adaptador = New SqlDataAdapter(comando)
            Try
                conexion.Open()
                adaptador.Fill(dtItemRequisicion)
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                conexion.Close()
            End Try

            FilaRequisicion = dtRequisicion(0)
        Else
            ImpresionRequisicion = True
        End If

        If Trim(FilaRequisicion("ENCABEZADO")) = "" Then
            imprimirEncabezado = False
        Else
            CadenasENCABEZADO.AddRange(Split(UCase(Trim(FilaRequisicion("ENCABEZADO"))), Environment.NewLine))
            Dim EncabezadoTemporal As New ArrayList(TextoAParrafoFuente(CadenasENCABEZADO, Formato_Etiqueta_10, 410, e))
            For i As Integer = 0 To EncabezadoTemporal.Count - 1
                If Trim(EncabezadoTemporal(i)) <> "" Then
                    Cadena_Total_ENCABEZADO.Add(EncabezadoTemporal(i))
                End If
            Next
        End If

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaRequisicion("DESTINO"), 3)) OrElse hsBodegasZamorana.Contains(Regex.Replace(Trim(FilaRequisicion("REQUISICION")), "[.]\d+", "")) Then
            If MsgBox("¿Desea imprimir la requisición con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' Logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'ISMOCOL
                e.Graphics.DrawImage(imagen, 55, 20, 130, 104)
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 36, 20, 154, 114)
            Case 2 'ZAMORANA
                e.Graphics.DrawImage(zamorana, 10, 50, 180, 48)
        End Select


        'CUADRO DE CODIGO FORMATO
        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                DrawRoundedRectangle(e.Graphics, 540, 20, 260, 35, 20)
                e.Graphics.DrawLine(Pens.Black, 540, 38, 800, 38)
                e.Graphics.DrawString("ICS - GRAL - F - 01", Formato_Etiqueta_8, Brocha, 620, 23)
                e.Graphics.DrawString("REVISIÓN No. 4", Formato_Etiqueta_8, Brocha, 627, 41)
            Case 1 'CSI
            Case 2 'ZAMORANA
                DrawRoundedRectangle(e.Graphics, 540, 20, 260, 35, 20)
                e.Graphics.DrawLine(Pens.Black, 540, 38, 800, 38)
                e.Graphics.DrawString("ZMS - GRAL - F - 005", Formato_Etiqueta_8, Brocha, 620, 23)
                e.Graphics.DrawString("REVISIÓN No. 0", Formato_Etiqueta_8, Brocha, 627, 41)
        End Select
        'CUADRO DE FECHA Y NUMERO
        DrawRoundedRectangle(e.Graphics, 540, 65, 260, 70, 20)
        e.Graphics.DrawLine(Lapiz, 540, 80, 800, 80)
        e.Graphics.DrawLine(Lapiz, 540, 100, 800, 100)
        e.Graphics.DrawLine(Lapiz, 540, 115, 800, 115)
        ' e.Graphics.DrawLine(LAPIZ, 670, 80, 670, 100)
        e.Graphics.DrawLine(Lapiz, 627, 115, 627, 135)
        e.Graphics.DrawLine(Lapiz, 713, 115, 713, 135)
        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_8, Brocha, 645, 67)
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_8, Brocha, 650, 102)
        'TÍTULO Y TIPO RQ
        e.Graphics.DrawRectangle(Pens.Black, 360, 61, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 505, 61, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 360, 81, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 505, 81, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 360, 101, 10, 10)
        e.Graphics.DrawString("REQUISICIÓN DE MATERIALES", Formato_Etiqueta_12, Brushes.Black, 230, 25)
        e.Graphics.DrawString("EPP / DOTACIÓN", Formato_Etiqueta_8, Brushes.Black, 200, 60)
        e.Graphics.DrawString("MANTENIMIENTO", Formato_Etiqueta_8, Brushes.Black, 400, 60)
        e.Graphics.DrawString("CONSUMO GENERAL", Formato_Etiqueta_8, Brushes.Black, 200, 80)
        e.Graphics.DrawString("EQUIPO CAPITAL", Formato_Etiqueta_8, Brushes.Black, 400, 80)
        e.Graphics.DrawString("MATERIALES ESPECIALES", Formato_Etiqueta_8, Brushes.Black, 200, 100)

        '*************************************************************************************************************
        e.Graphics.DrawString("CURQ ", Formato_Etiqueta_8, Brushes.Black, 400, 124)
        e.Graphics.DrawString(FormatoCodigoBarras(FilaRequisicion("ID")), fuente, Brushes.Black, 435, 115)

        '**************************************************************************************************************************

        'CUADRO DATOS RQ
        DrawRoundedRectangle(e.Graphics, MargenDerecha - 20, 144, 770, 80, 20)
        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, 164, 800, 164)
        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, 184, 800, 184)
        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, 204, 800, 204)
        e.Graphics.DrawRectangle(Pens.Black, 200, 148, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 340, 148, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 572, 148, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 740, 148, 10, 10)
        e.Graphics.DrawString("RECUPERACIÓN DEL GASTO", Formato_Etiqueta_8, Brushes.Black, 32, 147)
        e.Graphics.DrawString("REEMBOLSABLE", Formato_Etiqueta_8, Brushes.Black, 235, 147)
        e.Graphics.DrawString("RECOBRO SUB-CONTRATISTAS", Formato_Etiqueta_8, Brushes.Black, 380, 147)
        e.Graphics.DrawString("OTRO RECOBRO", Formato_Etiqueta_8, Brushes.Black, 632, 147)
        e.Graphics.DrawRectangle(Pens.Black, 140, 168, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 390, 168, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 545, 168, 10, 10)
        e.Graphics.DrawRectangle(Pens.Black, 740, 168, 10, 10)
        e.Graphics.DrawString("INCORPORABLE", Formato_Etiqueta_8, Brushes.Black, 32, 167)
        e.Graphics.DrawString("ÍTEM DE PAGO CONTRACTUAL", Formato_Etiqueta_8, Brushes.Black, 205, 167)
        e.Graphics.DrawString("ÍTEM ADICIONAL", Formato_Etiqueta_8, Brushes.Black, 445, 167)
        e.Graphics.DrawString("ÍTEM MAYOR CANTIDAD", Formato_Etiqueta_8, Brushes.Black, 600, 167)
        e.Graphics.DrawLine(Pens.Black, 203, 184, 203, 224)
        e.Graphics.DrawLine(Pens.Black, 378, 184, 378, 224)
        e.Graphics.DrawLine(Pens.Black, 698, 184, 698, 224)
        e.Graphics.DrawString("DE (FRENTE/CIUDAD)", Formato_Etiqueta_8, Brushes.Black, 32, 187)
        e.Graphics.DrawString("A", Formato_Etiqueta_8, Brushes.Black, 205, 187)
        e.Graphics.DrawString("DESTINO (C.C. MÁS EQUIPO/FRENTE U OT) / ACTIVIDAD ", Formato_Etiqueta_8, Brushes.Black, 380, 187)
        e.Graphics.DrawString("PRIORIDAD", Formato_Etiqueta_8, Brushes.Black, 700, 187)
        ' CUADRO DE ITEMS
        ' horizontales
        DrawRoundedRectangle(e.Graphics, 30, 230, 770, 675, 20)
        e.Graphics.DrawLine(Pens.Black, 640, 245, 800, 245)
        e.Graphics.DrawLine(Pens.Black, 30, 260, 800, 260)
        ' verticales
        e.Graphics.DrawLine(Pens.Black, 65, 230, 65, 860)
        e.Graphics.DrawLine(Pens.Black, 135, 230, 135, 860)
        e.Graphics.DrawLine(Pens.Black, 175, 230, 175, 860)
        e.Graphics.DrawLine(Pens.Black, 585, 230, 585, 860)
        e.Graphics.DrawLine(Pens.Black, 640, 230, 640, 860)
        e.Graphics.DrawLine(Pens.Black, 680, 245, 680, 860)
        e.Graphics.DrawLine(Pens.Black, 720, 230, 720, 860)
        e.Graphics.DrawLine(Pens.Black, 760, 245, 760, 860)

        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_8, Brushes.Black, 30 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_8, 35, e), 241)
        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_8, Brushes.Black, 65 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_8, 70, e), 241)
        e.Graphics.DrawString("U.M.", Formato_Etiqueta_8, Brushes.Black, 135 + InicioCentradoTexto("U.M.", Formato_Etiqueta_8, 40, e), 241)
        e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_8, Brushes.Black, 175 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_8, 410, e), 241)
        e.Graphics.DrawString("CANT", Formato_Etiqueta_8, Brushes.Black, 585 + InicioCentradoTexto("CANT", Formato_Etiqueta_8, 55, e), 241)
        e.Graphics.DrawString("STOCK", Formato_Etiqueta_7, Brushes.Black, 640 + InicioCentradoTexto("STOCK", Formato_Etiqueta_7, 80, e), 233)
        e.Graphics.DrawString("EN TRANSITO", Formato_Etiqueta_7, Brushes.Black, 720 + InicioCentradoTexto("EN TRANSITO", Formato_Etiqueta_7, 80, e), 233)
        e.Graphics.DrawString("LOCAL", Formato_Etiqueta_5, Brushes.Black, 640 + InicioCentradoTexto("LOCAL", Formato_Etiqueta_5, 40, e), 248)
        e.Graphics.DrawString("PRALES.", Formato_Etiqueta_5, Brushes.Black, 680 + InicioCentradoTexto("PRALES.", Formato_Etiqueta_5, 40, e), 248)
        e.Graphics.DrawString("LOCAL", Formato_Etiqueta_5, Brushes.Black, 720 + InicioCentradoTexto("LOCAL", Formato_Etiqueta_5, 40, e), 248)
        e.Graphics.DrawString("PRALES.", Formato_Etiqueta_5, Brushes.Black, 760 + InicioCentradoTexto("PRALES.", Formato_Etiqueta_5, 40, e), 248)
        'CUADRO DE JUSTIFICACIÓN
        e.Graphics.DrawLine(Pens.Black, 30, 860, 800, 860)
        e.Graphics.DrawLine(Pens.Black, 150, 876, 800, 876)
        e.Graphics.DrawLine(Pens.Black, 150, 891, 800, 891)
        e.Graphics.DrawString("JUSTIFICACIÓN: ", Formato_Etiqueta_8, Brushes.Black, 32, 863)
        'CUADRO FIRMAS
        DrawRoundedRectangle(e.Graphics, MargenDerecha - 20, 916, 770, 121, 20)
        e.Graphics.DrawLine(Pens.Black, 30, 946, 800, 946)
        e.Graphics.DrawLine(Pens.Black, 30, 966, 800, 966)
        e.Graphics.DrawLine(Pens.Black, 30, 986, 800, 986)
        e.Graphics.DrawLine(Pens.Black, 30, 1016, 800, 1016)
        e.Graphics.DrawLine(Pens.Black, 100, 916, 100, 1036)
        e.Graphics.DrawLine(Pens.Black, 275, 916, 275, 1036)
        e.Graphics.DrawLine(Pens.Black, 450, 916, 450, 1036)
        e.Graphics.DrawLine(Pens.Black, 625, 916, 625, 1036)
        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_8, Brushes.Black, 32, 948)
        e.Graphics.DrawString("CELULAR", Formato_Etiqueta_8, Brushes.Black, 32, 968)
        e.Graphics.DrawString("FIRMA", Formato_Etiqueta_8, Brushes.Black, 32, 988)
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_8, Brushes.Black, 32, 1018)
        e.Graphics.DrawString("SOLICITADO POR", Formato_Etiqueta_8, Brushes.Black, 139, 923)
        e.Graphics.DrawString("AUTORIZADO POR", Formato_Etiqueta_8, Brushes.Black, 314, 923)
        e.Graphics.DrawString("REVISADO POR BODEGA", Formato_Etiqueta_8, Brushes.Black, 469, 923)
        e.Graphics.DrawString("APROBADO POR", Formato_Etiqueta_8, Brushes.Black, 669, 923)


        Select Case Trim(FilaRequisicion("FAMILIAMATERIAL"))
            Case "ELEMENTOS PROTECCION PERSONAL"
                e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 362, 62)
            Case "MATERIAL DE CONSUMO GENERAL"
                e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 362, 82)
            Case "MATERIALES ESPECIALES"
                e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 362, 102)
            Case "MANTENIMIENTO (REPUESTOS)"
                e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 507, 62)
            Case "EQUIPO CAPITAL Y EQUIPOS DE LA COMPAÑÍA"
                e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 507, 82)
        End Select
        e.Graphics.DrawString(FilaRequisicion("REQUISICION"), Formato_Etiqueta_8, Brushes.Black, 540 + InicioCentradoTexto(FilaRequisicion("REQUISICION"), Formato_Etiqueta_8, 260, e), 85)
        e.Graphics.DrawString("DÍA:  " & FilaRequisicion("DIA"), Formato_Etiqueta_8, Brushes.Black, 545, 118)
        e.Graphics.DrawString("MES:  " & FilaRequisicion("MES"), Formato_Etiqueta_8, Brushes.Black, 635, 118)
        e.Graphics.DrawString("AÑO:  " & FilaRequisicion("AÑO"), Formato_Etiqueta_8, Brushes.Black, 715, 118)
        If FilaRequisicion("TIPORQ") = "R" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 201, 149)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 341, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 573, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 741, 149)
        ElseIf FilaRequisicion("TIPORQ") = "B" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 201, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 341, 149)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 573, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 741, 149)
        ElseIf FilaRequisicion("TIPORQ") = "O" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 201, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 341, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 573, 149)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 741, 149)
        End If
        If FilaRequisicion("ICORPORABLE") <> "N" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 141, 169)
        End If
        If FilaRequisicion("TIPOITEM") = "P" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 391, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 546, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 741, 169)
        ElseIf FilaRequisicion("TIPOITEM") = "A" Then
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 391, 169)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 546, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 741, 169)
        ElseIf FilaRequisicion("TIPOITEM") = "M" Then
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 216, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brushes.Black, 451, 169)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brushes.Black, 741, 169)
        End If
        Dim De As String = Trim(FilaRequisicion("DE"))

        If De.Length < 20 Then
            e.Graphics.DrawString(De, Formato_Etiqueta_6, Brushes.Black, 40, 210)
        Else
            e.Graphics.DrawString(Mid(De, 1, 26), Formato_Etiqueta_5, Brushes.Black, 40, 205)
            e.Graphics.DrawString(Mid(De, 27, 26), Formato_Etiqueta_5, Brushes.Black, 40, 215)
        End If

        e.Graphics.DrawString("DPTO. DE MATERIALES", Formato_Etiqueta_6, Brushes.Black, 220, 210)
        e.Graphics.DrawString(FilaRequisicion("DESTINO"), Formato_Etiqueta_6, Brushes.Black, 380, 210)
        Dim DestinoActividad As String = Trim(FilaRequisicion("ACTIVIDADPRINCIPAL"))

        If DestinoActividad.Count > 40 Then
            e.Graphics.DrawString(Mid(DestinoActividad, 1, 40), Formato_Etiqueta_6, Brushes.Black, 500, 206)
            e.Graphics.DrawString(Mid(DestinoActividad, 41, 40), Formato_Etiqueta_6, Brushes.Black, 500, 215)
        Else
            e.Graphics.DrawString(DestinoActividad, Formato_Etiqueta_6, Brushes.Black, 500, 210)
        End If

        If FilaRequisicion("PRIORIDAD") = "U" Then
            e.Graphics.DrawString("URGENTE", Formato_Etiqueta_6, Brushes.Black, 720, 210)
        Else
            e.Graphics.DrawString("NORMAL", Formato_Etiqueta_6, Brushes.Black, 720, 210)
        End If

        Dim InicioYdeItemRQ As Integer = 0

        'IMPRESIÓN ENCABEZADO
        InicioYdeItemRQ = 263
        ContadorRenglones = 0

        If imprimirEncabezado = True Then ' Si el encabezado es vacío, la variable se marca arriba con FALSE en la carga inicial.
            If Cadena_Total_ENCABEZADO.Count <> 0 Then ' ATENCIÓN: Si FilaRequisicion("ENCABEZADO") = "" entonces Count = 1
                Dim puntoOrigenENCABEZADO As New Point(176, InicioYdeItemRQ)
                Dim texto As String = ""
                For i = 0 To Cadena_Total_ENCABEZADO.Count - 1
                    texto = Cadena_Total_ENCABEZADO(i)
                    texto = SubParrafo1(Cadena_Total_ENCABEZADO(i), Formato_Etiqueta_10, 410, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10, Brocha, puntoOrigenENCABEZADO.X, puntoOrigenENCABEZADO.Y)
                    puntoOrigenENCABEZADO.Y = puntoOrigenENCABEZADO.Y + 15
                    texto = ""
                Next
                ContadorRenglones = Cadena_Total_ENCABEZADO.Count + 1
            End If
        End If

        Dim dashValues As Single() = {3, 3, 3, 3}
        Dim blackPen As New Pen(Color.Gray, 1)
        blackPen.DashPattern = dashValues


        'IMPRESIÓN DE ÍTEMS
        InicioYdeItemRQ += ContadorRenglones * 15
        Dim alturaEncabezado As Integer = ContadorRenglones * 15
        If imprimirEncabezado = True Then
            If Cadena_Total_ENCABEZADO.Count - 1 > 0 Then
                e.Graphics.DrawLine(blackPen, New Point(30, InicioYdeItemRQ - 5), New Point(800, InicioYdeItemRQ - 5))
            End If
        End If

        Dim espacio As Integer = 0
        Dim Cadena_Total_DESCRIPCION_IRQ As New ArrayList
        Dim CadenasDESCRIPCION_IRQ As New ArrayList
        Dim fuente_IRQ As Font = Formato_Etiqueta_8R

        For x As Integer = ITEMS_RQ To dtItemRequisicion.Rows.Count - 1

            FilaItemRequisicion = dtItemRequisicion(x)
            CadenasDESCRIPCION_IRQ.Add(UCase(Trim(FilaItemRequisicion("DESCRIPCION"))))
            Cadena_Total_DESCRIPCION_IRQ = TextoAParrafoFuente(CadenasDESCRIPCION_IRQ, fuente_IRQ, 410, e) ' x1: 585, x2: 184

            Dim espacionecesario As Integer = Cadena_Total_DESCRIPCION_IRQ.Count * 13
            Dim espaciodisponible As Integer

            If imprimirEncabezado = True Then
                espaciodisponible = 570 - alturaEncabezado - ESPACIOFILAS_RQ
            Else
                espaciodisponible = 570 - ESPACIOFILAS_RQ
            End If

            If (espaciodisponible > espacionecesario) Or ITEMS_RQ = dtItemRequisicion.Rows.Count Then

                e.Graphics.DrawString(FilaItemRequisicion("ITEM"), fuente_IRQ, Brushes.Black, 30 + InicioCentradoTexto(FilaItemRequisicion("ITEM"), fuente_IRQ, 35, e), InicioYdeItemRQ + ESPACIOFILAS_RQ)
                e.Graphics.DrawString(FilaItemRequisicion("CODIGO"), fuente_IRQ, Brushes.Black, 72, InicioYdeItemRQ + ESPACIOFILAS_RQ)
                e.Graphics.DrawString(FilaItemRequisicion("UNIDAD"), fuente_IRQ, Brushes.Black, 135 + InicioCentradoTexto(FilaItemRequisicion("UNIDAD"), fuente_IRQ, 37, e), InicioYdeItemRQ + ESPACIOFILAS_RQ)

                If Cadena_Total_DESCRIPCION_IRQ.Count <> 0 Then
                    Dim puntoOrigenDESCRIPCION_IRQ As New Point(176, InicioYdeItemRQ + ESPACIOFILAS_RQ)
                    Dim texto As String = ""
                    For i = 0 To Cadena_Total_DESCRIPCION_IRQ.Count - 1
                        texto = SubParrafo1(Cadena_Total_DESCRIPCION_IRQ(i), fuente_IRQ, 410, e)
                        e.Graphics.DrawString(texto, fuente_IRQ, Brocha, puntoOrigenDESCRIPCION_IRQ.X, puntoOrigenDESCRIPCION_IRQ.Y)
                        puntoOrigenDESCRIPCION_IRQ.Y = puntoOrigenDESCRIPCION_IRQ.Y + 13
                        texto = ""
                    Next
                    e.Graphics.DrawLine(blackPen, New Point(30, puntoOrigenDESCRIPCION_IRQ.Y - 7), New Point(800, puntoOrigenDESCRIPCION_IRQ.Y - 7))
                    espacio = Cadena_Total_DESCRIPCION_IRQ.Count * 13
                    CadenasDESCRIPCION_IRQ.Clear()
                    Cadena_Total_DESCRIPCION_IRQ.Clear()
                End If

                e.Graphics.DrawString(FilaItemRequisicion("CANTIDADSOLICITADA"), fuente_IRQ, Brushes.Black, 590, InicioYdeItemRQ + ESPACIOFILAS_RQ)

                e.Graphics.DrawString(FilaItemRequisicion("CANTIDADEXISTENCIA"), fuente_IRQ, Brushes.Black, 645, InicioYdeItemRQ + ESPACIOFILAS_RQ)
                e.Graphics.DrawString(FilaItemRequisicion("CANTEXISTENCIAPPAL"), fuente_IRQ, Brushes.Black, 685, InicioYdeItemRQ + ESPACIOFILAS_RQ)
                e.Graphics.DrawString(FilaItemRequisicion("CANTADQUISICIONLOCAL"), fuente_IRQ, Brushes.Black, 725, InicioYdeItemRQ + ESPACIOFILAS_RQ)
                e.Graphics.DrawString(FilaItemRequisicion("CANTADQUISICIONPPAL"), fuente_IRQ, Brushes.Black, 765, InicioYdeItemRQ + ESPACIOFILAS_RQ)

                ESPACIOFILAS_RQ += espacio
                ITEMS_RQ += 1
            Else
                Exit For
            End If
        Next
        imprimirEncabezado = False
        If ITEMS_RQ = dtItemRequisicion.Rows.Count Then
            If ESPACIOFILAS_RQ < 600 Then
                e.Graphics.DrawString("--------------ÚLTIMO RENGLÓN--------------", Formato_Etiqueta_10R, Brushes.Black, 175 + InicioCentradoTexto("--------------ÚLTIMO RENGLÓN--------------", Formato_Etiqueta_10R, 410, e), InicioYdeItemRQ + ESPACIOFILAS_RQ)
            End If
        Else
            e.Graphics.DrawString("-----------PASA A LA SIGUIENTE HOJA-----------", Formato_Etiqueta_10R, Brushes.Black, 175 + InicioCentradoTexto("-----------PASA A LA SIGUIENTE HOJA-----------", Formato_Etiqueta_10R, 410, e), InicioYdeItemRQ + ESPACIOFILAS_RQ)
            ESPACIOFILAS_RQ = 0
            e.HasMorePages = True
        End If

        Dim equipoJustifica As String = ""
        If Not IsDBNull(FilaRequisicion("CODIGO")) Then
            If Trim(FilaRequisicion("CODIGO")) <> "" Then
                equipoJustifica = " Equipo: " + Trim(FilaRequisicion("CODIGO"))
            End If
        End If
        Dim justifica As String = Trim(FilaRequisicion("JUSTIFICACION")) + equipoJustifica
        Dim pos As Integer = 0
        If justifica.Length > 100 Then
            If justifica.Length > 200 Then
                Dim justifica1 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica1.LastIndexOf(" ")
                justifica1 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica1, Formato_Etiqueta_7, Brushes.Black, 150, 863)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                Dim justifica2 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica2.LastIndexOf(" ")
                justifica2 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica2, Formato_Etiqueta_7, Brushes.Black, 150, 878)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brushes.Black, 150, 893)
            Else
                Dim justifica1 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica1.LastIndexOf(" ")
                justifica1 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica1, Formato_Etiqueta_7, Brushes.Black, 150, 863)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brushes.Black, 150, 878)
            End If
        Else
            e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brushes.Black, 150, 863)
        End If
        e.Graphics.DrawString(FilaRequisicion("PERSONASOLICITA"), Formato_Etiqueta_5, Brushes.Black, 100 + InicioCentradoTexto(FilaRequisicion("PERSONASOLICITA"), Formato_Etiqueta_5, 175, e), 950)
        e.Graphics.DrawString(FilaRequisicion("PERSONAAUTORIZA"), Formato_Etiqueta_5, Brushes.Black, 275 + InicioCentradoTexto(FilaRequisicion("PERSONAAUTORIZA"), Formato_Etiqueta_5, 175, e), 950)
        e.Graphics.DrawString(FilaRequisicion("PERSONAREVISA"), Formato_Etiqueta_5, Brushes.Black, 450 + InicioCentradoTexto(FilaRequisicion("PERSONAREVISA"), Formato_Etiqueta_5, 175, e), 950)
        e.Graphics.DrawString(FilaRequisicion("PERSONAAPRUEBA"), Formato_Etiqueta_5, Brushes.Black, 625 + InicioCentradoTexto(FilaRequisicion("PERSONAAPRUEBA"), Formato_Etiqueta_5, 175, e), 950)
        e.Graphics.DrawString(FilaRequisicion("SOLICITACEL"), Formato_Etiqueta_6, Brushes.Black, 100 + InicioCentradoTexto(FilaRequisicion("SOLICITACEL"), Formato_Etiqueta_6, 175, e), 970)
        e.Graphics.DrawString(FilaRequisicion("AUTORIZACEL"), Formato_Etiqueta_6, Brushes.Black, 275 + InicioCentradoTexto(FilaRequisicion("AUTORIZACEL"), Formato_Etiqueta_6, 175, e), 970)
        e.Graphics.DrawString(FilaRequisicion("REVISACEL"), Formato_Etiqueta_6, Brushes.Black, 450 + InicioCentradoTexto(FilaRequisicion("REVISACEL"), Formato_Etiqueta_6, 175, e), 970)
        e.Graphics.DrawString(FilaRequisicion("APRUEBACEL"), Formato_Etiqueta_6, Brushes.Black, 625 + InicioCentradoTexto(FilaRequisicion("APRUEBACEL"), Formato_Etiqueta_6, 175, e), 970)

        contpaginasRQ += 1

        Dim PiePagina As String = ""
        If imprimirPieDePagina Then
            PiePagina = "Página " & contpaginasRQ & " de " & paginastotalRQ
        Else
            PiePagina = "Página " & contpaginasRQ
        End If
        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, InicioCentradoTexto(PiePagina, Formato_Etiqueta_6, 950, e) - 50, 1050)

        If ITEMS_RQ = dtItemRequisicion.Rows.Count Then
            ESPACIOFILAS_RQ = 0
            ITEMS_RQ = 0
            imprimirEncabezado = True
            imprimirPieDePagina = True
            paginastotalRQ = contpaginasRQ
            TotalImpresoRQ += contpaginasRQ
            contpaginasRQ = 0
            e.HasMorePages = False
        End If

        If TotalImpresoRQ = (paginastotalRQ * 2) And ImpresionRequisicion Then
            GuardarImpresionRequisicion()
        End If
    End Sub

    Private Sub GuardarImpresionRequisicion()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure

            If RQCancelada = False Then
                Comando.Parameters.AddWithValue("@TIPO", 6)
            Else
                If CANCELACIONPARCIAL Then
                    Comando.Parameters.AddWithValue("@TIPO", 7)
                Else
                    Comando.Parameters.AddWithValue("@TIPO", 8)
                End If
            End If

            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IDREQUISICION)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "61 - ICS-GRAL-F-30 CANCELACION REQUISICION"

    Dim WithEvents DocImp_CancelaciónRequisiciónICSGRALF30 As New PrintDocument 'Documento a imprimir

    ''' <summary>Espacio vertical ocupado por los ítems de la requisición que disminuye cada vez que se imprime un artículo. Reinicia al pasar a nueva página.</summary>
    Dim EspacioFilas_CanRQ As Integer = 0

    ''' <summary></summary>
    Dim EspacioDisponible_CanRQ As Integer = 0

    ''' <summary>Determina si ya se cargaron los datos de la requisición para no realizar la consulta nuevamente al imprimir.</summary>
    Dim Impresion_CanRQ As Boolean = False

    ''' <summary></summary>
    Dim Items_CanRQ As Integer = 0

    ''' <summary></summary>
    Const AlturaFuente As Integer = 10

    Private Sub DocCancelaciónRequisiciónICSGRALF30(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CancelaciónRequisiciónICSGRALF30.PrintPage
        If DsRequisicion.REQUISICION.Rows.Count = 0 Then
            DAREQUISICION.FillBy(DsRequisicion.REQUISICION, IDREQUISICION)
            TipoCancelación = "Cancelación Parcial"
            'Si la requisición no existe en REQUISICION entonces es cancelación total
            If Me.DsRequisicion.REQUISICION.Rows.Count = 0 Then
                TipoCancelación = "Cancelación Total"
                DAREQUISICION.FillRQCANCELADA(DsRequisicion.REQUISICION, IDREQUISICION)
            End If
            If Me.DsRequisicion.REQUISICION.Rows.Count = 0 Then
                e.HasMorePages = False
                Exit Sub
            End If
            FilaRequisicion = DsRequisicion.REQUISICION(0)
            DAITEMREQUISICION.FillByITEMRQCANCELADOS(DsRequisicion.ITEMREQUISICION, IDREQUISICION)
        Else
            Impresion_CanRQ = True
        End If

        Brocha.Color = Color.Black
        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        e.Graphics.RotateTransform(-45.0F)
        e.Graphics.DrawString("CANCELADO", Formato_Etiqueta_80, Brushes.Silver, -500, 600)
        e.Graphics.RotateTransform(45.0F)

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaRequisicion("DESTINO"), 3)) OrElse hsBodegasZamorana.Contains(Regex.Replace(Trim(FilaRequisicion("REQUISICION")), "[.]\d+", "")) Then
            If MsgBox("¿Desea imprimir la requisición con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' 1 = logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'ISMOCOL
                e.Graphics.DrawImage(imagen, 55, 20, 130, 104)
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 36, 20, 154, 114)
            Case 2
                e.Graphics.DrawImage(zamorana, 10, 50, 180, 48) 'ZAMORANA
        End Select

        Select Case LogoEmpresa
            Case 0 'Ismocol S.A.
                DrawRoundedRectangle(e.Graphics, 540, 20, 260, 35, 20) 'CUADRO DE CODIGO FORMATO
                e.Graphics.DrawLine(Lapiz, 540, 38, 800, 38)
                e.Graphics.DrawString("ICS - GRAL - F - 30", Formato_Etiqueta_8, Brocha, 620, 23)
                e.Graphics.DrawString("REVISIÓN No. 2", Formato_Etiqueta_8, Brocha, 627, 41)
            Case 1
            Case 2 'ZAMORANA
                DrawRoundedRectangle(e.Graphics, 540, 20, 260, 35, 20) 'CUADRO DE CODIGO FORMATO
                e.Graphics.DrawLine(Lapiz, 540, 38, 800, 38)
                e.Graphics.DrawString("ZMS - GRAL - F - 006", Formato_Etiqueta_8, Brocha, 620, 23)
                e.Graphics.DrawString("REVISIÓN No. 0", Formato_Etiqueta_8, Brocha, 627, 41)
        End Select
        DrawRoundedRectangle(e.Graphics, 540, 65, 260, 70, 20) 'CUADRO DE FECHA Y NUMERO
        e.Graphics.DrawLine(Lapiz, 540, 80, 800, 80)
        e.Graphics.DrawLine(Lapiz, 540, 100, 800, 100)
        e.Graphics.DrawLine(Lapiz, 540, 115, 800, 115)
        ' e.Graphics.DrawLine(Lapiz, 670, 80, 670, 100)
        e.Graphics.DrawLine(Lapiz, 627, 115, 627, 135)
        e.Graphics.DrawLine(Lapiz, 713, 115, 713, 135)
        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_8, Brocha, 645, 67)

        If TipoCancelación = "Cancelación Total" Then
            e.Graphics.DrawString("FECHA CANCELACION", Formato_Etiqueta_8, Brocha, 620, 102)
            e.Graphics.DrawString("DIA:  " & CDate(FilaRequisicion("fechacancelación")).Day, Formato_Etiqueta_8, Brocha, 545, 118)
            e.Graphics.DrawString("MES:  " & CDate(FilaRequisicion("fechacancelación")).Month, Formato_Etiqueta_8, Brocha, 635, 118)
            e.Graphics.DrawString("AÑO:  " & CDate(FilaRequisicion("fechacancelación")).Year, Formato_Etiqueta_8, Brocha, 715, 118)
        End If

        e.Graphics.DrawString("CANCELACION REQUISICIÓN DE MATERIALES", Formato_Etiqueta_10, Brocha, 200, 40)
        e.Graphics.DrawString(TipoCancelación, Formato_Etiqueta_12, Brocha, 280, 70)
        DrawRoundedRectangle(e.Graphics, 30, 144, 770, 80, 20) 'CUADRO DATOS RQ
        e.Graphics.DrawLine(Lapiz, 30, 164, 800, 164)
        e.Graphics.DrawLine(Lapiz, 30, 184, 800, 184)
        e.Graphics.DrawLine(Lapiz, 30, 204, 800, 204)
        e.Graphics.DrawRectangle(Lapiz, 200, 148, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 340, 148, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 572, 148, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 740, 148, 10, 10)
        e.Graphics.DrawString("RECUPERACION DEL GASTO", Formato_Etiqueta_8, Brocha, 32, 147)
        e.Graphics.DrawString("REEMBOLSABLE", Formato_Etiqueta_8, Brocha, 235, 147)
        e.Graphics.DrawString("RECOBRO SUB-CONTRATISTAS", Formato_Etiqueta_8, Brocha, 380, 147)
        e.Graphics.DrawString("OTRO RECOBRO", Formato_Etiqueta_8, Brocha, 632, 147)
        e.Graphics.DrawRectangle(Lapiz, 140, 168, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 390, 168, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 545, 168, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 740, 168, 10, 10)
        e.Graphics.DrawString("INCORPORABLE", Formato_Etiqueta_8, Brocha, 32, 167)
        e.Graphics.DrawString("ITEM DE PAGO CONTRACTUAL", Formato_Etiqueta_8, Brocha, 205, 167)
        e.Graphics.DrawString("ITEM ADICIONAL", Formato_Etiqueta_8, Brocha, 445, 167)
        e.Graphics.DrawString("ITEM MAYOR CANTIDAD", Formato_Etiqueta_8, Brocha, 600, 167)
        e.Graphics.DrawLine(Lapiz, 203, 184, 203, 224)
        e.Graphics.DrawLine(Lapiz, 378, 184, 378, 224)
        e.Graphics.DrawLine(Lapiz, 698, 184, 698, 224)
        e.Graphics.DrawString("DE (FRENTE/CIUDAD)", Formato_Etiqueta_8, Brocha, 32, 187)
        e.Graphics.DrawString("A", Formato_Etiqueta_8, Brocha, 205, 187)
        e.Graphics.DrawString("DESTINO (C.C. MAS EQUIPO/FRENTE U OT)", Formato_Etiqueta_8, Brocha, 380, 187)
        e.Graphics.DrawString("PRIORIDAD", Formato_Etiqueta_8, Brocha, 700, 187)
        'CUADRO DE ITEMS Y FIRMAS
        DrawRoundedRectangle(e.Graphics, 30, 230, 770, 675, 20)
        e.Graphics.DrawLine(Lapiz, 640, 245, 800, 245)
        e.Graphics.DrawLine(Lapiz, 30, 260, 800, 260)
        e.Graphics.DrawLine(Lapiz, 65, 230, 65, 860)
        e.Graphics.DrawLine(Lapiz, 135, 230, 135, 860)
        e.Graphics.DrawLine(Lapiz, 175, 230, 175, 860)
        e.Graphics.DrawLine(Lapiz, 585, 230, 585, 860)
        e.Graphics.DrawLine(Lapiz, 640, 230, 640, 860)
        e.Graphics.DrawLine(Lapiz, 720, 245, 720, 860)
        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_8, Brocha, 30 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_8, 35, e), 240)
        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_8, Brocha, 65 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_8, 70, e), 240)
        e.Graphics.DrawString("U.M.", Formato_Etiqueta_8, Brocha, 135 + InicioCentradoTexto("U.M.", Formato_Etiqueta_8, 40, e), 240)
        e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_8, Brocha, 175 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_8, 410, e), 240)
        e.Graphics.DrawString("CANT", Formato_Etiqueta_8, Brocha, 585 + InicioCentradoTexto("CANT", Formato_Etiqueta_8, 55, e), 240)
        e.Graphics.DrawString("CANCELADO", Formato_Etiqueta_8, Brocha, 640 + InicioCentradoTexto("CANCELADO", Formato_Etiqueta_8, 160, e), 230)
        e.Graphics.DrawString("TIPO", Formato_Etiqueta_5, Brocha, 640 + InicioCentradoTexto("TIPO", Formato_Etiqueta_5, 80, e), 248)
        e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_5, Brocha, 720 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_5, 80, e), 248)
        e.Graphics.DrawLine(Lapiz, 30, 860, 800, 860) 'CUADRO DE JUSTIFICACION
        e.Graphics.DrawLine(Lapiz, 150, 876, 800, 876)
        e.Graphics.DrawLine(Lapiz, 150, 891, 800, 891)
        e.Graphics.DrawString("JUSTIFICACIÓN: ", Formato_Etiqueta_8, Brocha, 32, 863)
        DrawRoundedRectangle(e.Graphics, 30, 916, 770, 121, 20) 'CUADRO FIRMAS

        e.Graphics.DrawLine(Lapiz, 625, 916, 625, 1036)

        Dim observa As String = "Observación: " + Trim(FilaRequisicion("observacióncancela"))
        If observa.Length > 60 Then
            Dim observa1 As String = Trim(Mid(observa, 1, 60))
            Dim pos As Integer
            pos = observa1.LastIndexOf(" ")
            observa1 = Trim(Mid(observa, 1, pos))
            e.Graphics.DrawString(observa1, Formato_Etiqueta_9, Brocha, 45, 942)
            observa = Trim(Mid(observa, pos + 1, observa.Length))
            e.Graphics.DrawString(observa, Formato_Etiqueta_9, Brocha, 128, 962)
        Else
            e.Graphics.DrawString(Mid(observa, 1, 60), Formato_Etiqueta_9, Brocha, 55, 942)
        End If

        If Trim(FilaRequisicion("observacióncancela")) <> "" Then
            e.Graphics.DrawString("Cancela: " + FilaRequisicion("Cancela"), Formato_Etiqueta_5, Brocha, 55, 1015)
        End If

        e.Graphics.DrawString("JEFES DPTO. DE MATERIALES", Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto("JEFES DPTO. DE MATERIALES", Formato_Etiqueta_5, 190, e), 934)
        e.Graphics.DrawString("(JEFE MATERIALES OBRA)", Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto("(JEFE MATERIALES OBRA)", Formato_Etiqueta_5, 190, e), 944)
        e.Graphics.DrawString(FilaRequisicion("PERSONAREVISA"), Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto(FilaRequisicion("PERSONAREVISA"), Formato_Etiqueta_5, 190, e), 1015)

        e.Graphics.DrawString(FilaRequisicion("FAMILIAMATERIAL"), Formato_Etiqueta_8, Brocha, 240, 102)

        e.Graphics.DrawString(FilaRequisicion("REQUISICION"), Formato_Etiqueta_8, Brocha, 570, 85)
        '   e.Graphics.DrawString(FilaRequisicion("CONSECUTIVO"), Formato_Etiqueta_8, Brocha, 700, 85)

        If FilaRequisicion("TIPORQ") = "R" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 201, 149)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 341, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 573, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 741, 149)
        ElseIf FilaRequisicion("TIPORQ") = "B" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 201, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 341, 149)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 573, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 741, 149)
        ElseIf FilaRequisicion("TIPORQ") = "O" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 201, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 341, 149)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 573, 149)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 741, 149)
        End If
        If FilaRequisicion("ICORPORABLE") <> "N" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 141, 169)
        End If
        If FilaRequisicion("TIPOITEM") = "P" Then
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 391, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 546, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 741, 169)
        ElseIf FilaRequisicion("TIPOITEM") = "A" Then
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 391, 169)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 546, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 741, 169)
        ElseIf FilaRequisicion("TIPOITEM") = "M" Then
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 216, 169)
            e.Graphics.DrawString(" ", Formato_Etiqueta_6, Brocha, 451, 169)
            e.Graphics.DrawString("X", Formato_Etiqueta_6, Brocha, 741, 169)
        End If
        e.Graphics.DrawString(FilaRequisicion("DE"), Formato_Etiqueta_6, Brocha, 40, 210)
        e.Graphics.DrawString("DPTO. DE MATERIALES", Formato_Etiqueta_6, Brocha, 220, 210)
        e.Graphics.DrawString(FilaRequisicion("DESTINO"), Formato_Etiqueta_6, Brocha, 390, 210)
        If FilaRequisicion("PRIORIDAD") = "U" Then
            e.Graphics.DrawString("URGENTE", Formato_Etiqueta_6, Brocha, 720, 210)
        Else
            e.Graphics.DrawString("NORMAL", Formato_Etiqueta_6, Brocha, 720, 210)
        End If


        EspacioFilas_CanRQ = 0
        EspacioDisponible_CanRQ = 560
        Const InicioItemY_CanRQ = 263
        For x As Integer = Items_CanRQ To DsRequisicion.ITEMREQUISICION.Rows.Count - 1
            FilaItemRequisicion = DsRequisicion.ITEMREQUISICION(x)
            Dim Cadenas1 As New ArrayList
            Cadenas1.Add(Trim(FilaItemRequisicion("DESCRIPCION")))
            Dim Cadena_Total1 As New ArrayList
            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_6, 405, e)

            If EspacioFilas_CanRQ + ((Cadena_Total1.Count - 1) * AlturaFuente) + AlturaFuente >= EspacioDisponible_CanRQ Then
                e.Graphics.DrawString("-----------PASA A LA SIGUIENTE HOJA-----------", Formato_Etiqueta_8, Brocha, 175 + InicioCentradoTexto("-----------PASA A LA SIGUIENTE HOJA-----------", Formato_Etiqueta_8, 410, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
                Exit For
            ElseIf EspacioFilas_CanRQ > 0 Then
                e.Graphics.DrawLine(lineaPunteada, 30, InicioItemY_CanRQ + EspacioFilas_CanRQ + 5, 800, InicioItemY_CanRQ + EspacioFilas_CanRQ + 5)
                EspacioFilas_CanRQ += AlturaFuente
            End If

            e.Graphics.DrawString(FilaItemRequisicion("ITEM"), Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto(FilaItemRequisicion("ITEM"), Formato_Etiqueta_6, 35, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            e.Graphics.DrawString(FilaItemRequisicion("CODIGO"), Formato_Etiqueta_6, Brocha, 65 + InicioCentradoTexto(FilaItemRequisicion("CODIGO"), Formato_Etiqueta_6, 70, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            e.Graphics.DrawString(FilaItemRequisicion("U_M"), Formato_Etiqueta_6, Brocha, 135 + InicioCentradoTexto(FilaItemRequisicion("U_M"), Formato_Etiqueta_6, 40, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            e.Graphics.DrawString(FilaItemRequisicion("CANT"), Formato_Etiqueta_6, Brocha, 585 + InicioCentradoTexto(FilaItemRequisicion("CANT"), Formato_Etiqueta_6, 55, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            If FilaItemRequisicion("TIPOCANCELACION") = "T" Then
                e.Graphics.DrawString("Total", Formato_Etiqueta_6, Brocha, 640 + InicioCentradoTexto("Total", Formato_Etiqueta_6, 80, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            Else
                e.Graphics.DrawString("Parcial", Formato_Etiqueta_6, Brocha, 640 + InicioCentradoTexto("Parcial", Formato_Etiqueta_6, 80, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            End If
            e.Graphics.DrawString(FilaItemRequisicion("CANTIDADCANCELADA"), Formato_Etiqueta_6, Brocha, 720 + InicioCentradoTexto(FilaItemRequisicion("CANTIDADCANCELADA"), Formato_Etiqueta_6, 80, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)


            For k = 0 To Cadena_Total1.Count - 2
                e.Graphics.DrawString(Cadena_Total1(k), Formato_Etiqueta_6, Brocha, 180, InicioItemY_CanRQ + EspacioFilas_CanRQ)
                EspacioFilas_CanRQ += AlturaFuente
            Next

            If TipoCancelación = "Cancelación Parcial" Then
                e.Graphics.DrawString(FilaItemRequisicion("OBSERVACIONCANCELACION"), Formato_Etiqueta_6, Brocha, 180, InicioItemY_CanRQ + EspacioFilas_CanRQ)
                EspacioFilas_CanRQ += AlturaFuente
                e.Graphics.DrawString(FilaItemRequisicion("FECHACANCELACION"), Formato_Etiqueta_6, Brocha, 180, InicioItemY_CanRQ + EspacioFilas_CanRQ)
                EspacioFilas_CanRQ += AlturaFuente
                e.Graphics.DrawString(FilaItemRequisicion("CANCELA"), Formato_Etiqueta_6, Brocha, 180, InicioItemY_CanRQ + EspacioFilas_CanRQ)
                EspacioFilas_CanRQ += AlturaFuente
            End If

            Items_CanRQ += 1
        Next


        If Items_CanRQ = DsRequisicion.ITEMREQUISICION.Rows.Count Then
            If EspacioFilas_CanRQ < 600 Then
                e.Graphics.DrawString("--------------ÚLTIMO RENGLON--------------", Formato_Etiqueta_10R, Brocha, 175 + InicioCentradoTexto("--------------ÚLTIMO RENGLON--------------", Formato_Etiqueta_10R, 410, e), InicioItemY_CanRQ + EspacioFilas_CanRQ)
            End If
            EspacioFilas_CanRQ = 0
            Items_CanRQ = 0
            e.HasMorePages = False
        Else
            EspacioFilas_CanRQ = 0
            e.HasMorePages = True
        End If
        Dim justifica As String = Trim(FilaRequisicion("JUSTIFICACION"))
        If justifica.Length > 100 Then
            If justifica.Length > 200 Then
                Dim justifica1 As String = Trim(Mid(justifica, 1, 100))
                Dim pos As Integer
                pos = justifica1.LastIndexOf(" ")
                justifica1 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica1, Formato_Etiqueta_7, Brocha, 150, 863)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                Dim justifica2 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica2.LastIndexOf(" ")
                justifica2 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica2, Formato_Etiqueta_7, Brocha, 150, 877)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brocha, 150, 889)
            Else
                Dim justifica1 As String = Trim(Mid(justifica, 1, 100))
                Dim pos As Integer
                pos = justifica1.LastIndexOf(" ")
                justifica1 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica1, Formato_Etiqueta_7, Brocha, 150, 863)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brocha, 150, 877)
            End If
        Else
            e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brocha, 150, 863)
        End If

        If Impresion_CanRQ Then
            GuardarImpresionRequisicion()
        End If
    End Sub

#End Region

#Region "62 - ICS-GRAL-F-06 ORDEN DE COMPRA"
    Dim WithEvents DocImp_OrdenDeCompraICSGRALF06 As New PrintDocument 'Documento a imprimir

    Public IDORDENDECOMPRA As Integer = -1
    Public copiaparacontabilidad1 As Boolean
    Public copiaparacontabilidad2 As Boolean
    Public copiaparaconsecutivo As Boolean
    Public copiaparafolderpedido As Boolean
    Private _copiaparacontabilidad1 As Boolean
    Private _copiaparacontabilidad2 As Boolean
    Private _copiaparaconsecutivo As Boolean
    Private _copiaparafolderpedido As Boolean

    ''' <summary>Cantidad de Items impresos. Reinicia al terminar la visualización previa.</summary>
    Private ContadorItemOrdenCompra As Integer = 0

    ''' <summary>Determina si se deben cargar los datos de la Orden de compra desde la Base de datos.</summary>
    Private CargarDatasetOrdenCompra As Boolean = True

    ''' <summary>Toma la primera fila de la tabla de órdenes de compra que contiene los datos de la OC a imprimir.</summary>
    Private FilaOrdenCompra As DataRow

    ''' <summary>Determina el número de espacios verticales recorridos en la impresión de items. Reinicia al pasar a una nueva página.</summary>
    Private ContadorRenglones As Integer = 0

    ''' <summary>Determina si se debe imprimir el Encabezado de la Orden de compra en las impresiones de varias páginas.</summary>
    Private imprimirjustificación As Boolean = True

    ''' <summary>Cálculo del valor de los items impresos en una página. Reinicia al terminar la visualización previa.</summary>
    Private parcialtotaloc As Double = 0

    ''' <summary>Indica a qué familia pertenecen los artículos de la Orden de compra.</summary>
    Private FamiliaArticuloOC As String

    ''' <summary>Indica cual es la copia que se está imprimiendo actualmente.</summary>
    Private copiapara As String

    ''' <summary>Indica la cantidad de copias que se van a imprimir.</summary>
    Private copiasOC As Integer = 0

    ''' <summary>Contador de la cantidad de copias impresas.</summary>
    Private contcopiasOC As Integer = 0

    ''' <summary>Indica si ya terminó la visualización previa del documento.</summary>
    Private MarcarImpresa As Boolean = False

    ''' <summary>Contiene el texto separado en líneas del encabezado de la Orden de compra.</summary>
    Private Cadena_Total_ENCABEZADO_OC As New ArrayList

    ''' <summary>Espacio vertical ocupado por los items impresos que permite determinar la posición en la que se imprime el siguiente elemento. Reinicia al pasar a una nueva página.</summary>
    Private ESPACIOFILAS_OC As Integer = 0

    ''' <summary>Cantidad de páginas a imprimir. No reinicia durante la impresión.</summary>
    Private paginastotalOC As Integer = 0

    ''' <summary>Tabla que contiene la información de la orden de compra a imprimir.</summary>
    Private dtOrdenCompra As DataTable

    ''' <summary>Tabal que contiene el listado de ítems de la orden de compra a imprimir.</summary>
    Private dtItemOrdenCompra As DataTable


    Private Sub DocImpOrdenDeCompraICSGRALF06(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_OrdenDeCompraICSGRALF06.PrintPage
        If CargarDatasetOrdenCompra = True Then

            Dim CadenasENCABEZADO As New ArrayList

            _copiaparacontabilidad1 = copiaparacontabilidad1
            _copiaparacontabilidad2 = copiaparacontabilidad2
            _copiaparaconsecutivo = copiaparaconsecutivo
            _copiaparafolderpedido = copiaparafolderpedido

            comando = New SqlCommand("SELECT * FROM ImpresionOrdenCompra(@IDORDENCOMPRA)", conexion)
            comando.Parameters.AddWithValue("@IDORDENCOMPRA", IDORDENDECOMPRA)
            adaptador = New SqlDataAdapter(comando)
            dtOrdenCompra = New DataTable()
            Try
                conexion.Open()
                adaptador.Fill(dtOrdenCompra)
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
            If dtOrdenCompra.Rows.Count = 0 Then
                e.HasMorePages = False
                Exit Sub
            End If
            FilaOrdenCompra = dtOrdenCompra.Rows(0)

            comando = New SqlCommand("SELECT * FROM ImpresionItemOrdenCompra(@IDORDENCOMPRA)", conexion)
            comando.Parameters.AddWithValue("@IDORDENCOMPRA", IDORDENDECOMPRA)
            adaptador = New SqlDataAdapter(comando)
            dtItemOrdenCompra = New DataTable()
            Try
                conexion.Open()
                adaptador.Fill(dtItemOrdenCompra)
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
            If dtItemOrdenCompra.Rows.Count = 0 Then
                e.HasMorePages = False
                Exit Sub
            End If

            CargarDatasetOrdenCompra = False

            If FilaOrdenCompra("IDBODEGA") = 45 Then
                If MsgBox("¿Desea imprimir la orden de compra con el logo de CSI?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                    LogoEmpresa = 1 ' 1 = logo de CSI
                End If
            End If

            'Verificar si el Centro de Costo pertenece a Zamorana.
            If hsCentrosOperacionZamorana.Contains(Left(FilaOrdenCompra("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Regex.Replace(Trim(FilaOrdenCompra("ORDENCOMPRA")), "[-]\d+[A-Z]\d+", "")) Then
                If MsgBox("¿Desea imprimir la orden de compra con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                    LogoEmpresa = 2 ' 1 = logo de Zamorana
                End If
            ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
                LogoEmpresa = 2
            End If

            If Trim(FilaOrdenCompra("ENCABEZADO")) = "" Then
                imprimirjustificación = False
            Else
                CadenasENCABEZADO.AddRange(Split(UCase(Trim(FilaOrdenCompra("ENCABEZADO"))), Environment.NewLine))
                Dim EncabezadoTemporal As New ArrayList(TextoAParrafoFuente(CadenasENCABEZADO, Formato_Etiqueta_10, 305, e))
                For i As Integer = 0 To EncabezadoTemporal.Count - 1
                    If Trim(EncabezadoTemporal(i)) <> "" Then
                        Cadena_Total_ENCABEZADO_OC.Add(EncabezadoTemporal(i))
                    End If
                Next
            End If

            ' DETERMINAR LA FAMILIA A LA QUE PERTENECE LA ORDEN DE COMPRA.
            Dim filaItemOC As DataRow
            filaItemOC = dtItemOrdenCompra.Rows(0)
            FamiliaArticuloOC = filaItemOC("NOMBREFAMILIAMATERIAL")

            If Me.copiaparacontabilidad1 = True Then
                copiasOC = copiasOC + 1
            End If
            If Me.copiaparacontabilidad2 = True Then
                copiasOC = copiasOC + 1
            End If
            If Me.copiaparaconsecutivo = True Then
                copiasOC = copiasOC + 1
            End If
            If Me.copiaparafolderpedido = True Then
                copiasOC = copiasOC + 1
            End If
        End If

        If Me.copiaparacontabilidad1 = True Then
            copiapara = "CONTABILIDAD"
        Else
            If copiaparacontabilidad2 = True Then
                copiapara = "CONTABILIDAD"
            Else
                If copiaparaconsecutivo = True Then
                    copiapara = "ARCHIVO CONSECUTIVO"
                Else
                    If copiaparafolderpedido = True Then
                        copiapara = "FOLDER PEDIDO"
                    End If
                End If
            End If
        End If

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        Brocha.Color = Color.Black

        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawImage(imagen, 35, 20, 90, 70)
                e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_14R, Brushes.Black, InicioCentradoTexto("ISMOCOL S.A.", Formato_Etiqueta_14R, 770, e) - 50, 20)
                e.Graphics.DrawString("NIT. 890.209.174-1", Formato_Etiqueta_14R, Brushes.Black, 400, 20)
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 36, 20, 154, 104)
            Case 2 'ZAMORANA
                e.Graphics.DrawImage(zamorana, 20, 40, 110, 40)
                e.Graphics.DrawString("ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S. NIT. 900.149.238-1", Formato_Etiqueta_9R, Brushes.Black, InicioCentradoTexto("ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S. NIT. 900.149.238-1", Formato_Etiqueta_9R, 270, e) + 270, 30)
        End Select


        ' IDENTIFICADOR OC
        DrawRoundedRectangle(e.Graphics, 140, 50, 530, 38, 20)
        DrawRoundedRectangle(e.Graphics, 30, 93, 640, 128, 20)
        DrawRoundedRectangle(e.Graphics, 640, 125, 160, 96, 20)
        e.Graphics.FillRectangle(Brushes.White, 630, 125, 50, 96)
        DrawRoundedRectangle(e.Graphics, 30, 226, 770, 153, 20)
        DrawRoundedRectangle(e.Graphics, 30, 397, 770, 575, 20)
        e.Graphics.DrawString("ORDEN DE COMPRA", Formato_Etiqueta_12, Brocha, 145, 58)
        'e.Graphics.DrawLine(Lapiz, 360, 50, 360, 120) ' vertical
        'e.Graphics.DrawString("Enviar su factura en Original y Copia,", Formato_Etiqueta_6, Brocha, 370, 55)
        'e.Graphics.DrawString("acompañada   de   una   copia   de   la", Formato_Etiqueta_6, Brocha, 370, 70)
        'e.Graphics.DrawString("presente   orden   de   compra   y   la", Formato_Etiqueta_6, Brocha, 370, 85)
        'e.Graphics.DrawString("Respectiva  Entrada  de  Almacén.", Formato_Etiqueta_6, Brocha, 370, 100)
        e.Graphics.DrawLine(Lapiz, 320, 50, 320, 88) ' vertical
        e.Graphics.DrawString("NÚMERO:", Formato_Etiqueta_8, Brocha, 322, 54)
        e.Graphics.DrawString(FilaOrdenCompra("ORDENCOMPRA"), Formato_Etiqueta_12, Brocha, 430, 50)
        e.Graphics.DrawLine(Lapiz, 320, 69, 670, 69) ' horizontal
        e.Graphics.DrawString("CIUDAD Y FECHA:", Formato_Etiqueta_8, Brocha, 322, 73)
        e.Graphics.DrawString(FilaOrdenCompra("CIUDADYFECHA"), Formato_Etiqueta_10, Brocha, 430, 70)

        Dim CEDULAENCRIPTADA As String
        CEDULAENCRIPTADA = FuncionesBase.FuncionesBase.Encryptar(FilaOrdenCompra("IDORDENCOMPRA"))
        Dim TIPO As String
        TIPO = FuncionesBase.FuncionesBase.Encryptar("OC")
        Dim CORTE As String
        CORTE = FuncionesBase.FuncionesBase.Encryptar(Trim(FilaOrdenCompra("ORDENCOMPRA")))

        Dim linkqr As String
        linkqr = "http://190.0.43.174:7070/publico/wf_ConsultarQR.aspx?CED=" + CEDULAENCRIPTADA + "&&TIPO=" + TIPO + "&&CORTE=" + CORTE

        Dim encoder As New QRCodeEncoder()
        encoder.QRCodeScale = 3
        Dim img As New Bitmap(encoder.Encode(linkqr))
        e.Graphics.DrawImage(img, 680, 15, 100, 100)
        e.Graphics.DrawString("Escanee para validar", Formato_Etiqueta_7, Brocha, 678, 114)


        ' DATOS PROVEEDOR
        e.Graphics.DrawString("RAZÓN SOCIAL O NOMBRE COMPLETO DEL PROVEEDOR:", Formato_Etiqueta_7, Brocha, 35, 98)
        Dim Proveedor As String = FilaOrdenCompra("PROVEEDOR")
        Select Case Proveedor.Length
            Case Is < 73
                e.Graphics.DrawString(Proveedor, Formato_Etiqueta_10, Brocha, 40, 109)
                Exit Select
            Case Is < 90
                e.Graphics.DrawString(Proveedor, Formato_Etiqueta_8, Brocha, 40, 112)
                Exit Select
            Case Else
                e.Graphics.DrawString(Proveedor, Formato_Etiqueta_6, Brocha, 40, 112)
        End Select
        e.Graphics.DrawLine(Lapiz, 30, 125, 680, 125) ' horizontal
        e.Graphics.DrawString("DIRECCIÓN:", Formato_Etiqueta_7, Brocha, 35, 127)
        Dim dirección As String = Trim(FilaOrdenCompra("DIRECCIONPROVEEDOR"))
        Select Case dirección.Length
            Case Is < 40
                e.Graphics.DrawString(dirección, Formato_Etiqueta_10, Brocha, 40, 138)
                Exit Select
            Case Is < 54
                e.Graphics.DrawString(dirección, Formato_Etiqueta_7, Brocha, 40, 138)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(dirección, 1, 54), Formato_Etiqueta_7, Brocha, 40, 135)
                e.Graphics.DrawString(Mid(dirección, 55, 54), Formato_Etiqueta_7, Brocha, 40, 143)
        End Select
        e.Graphics.DrawString("CIUDAD:", Formato_Etiqueta_7, Brocha, 387, 127)
        e.Graphics.DrawString(FilaOrdenCompra("CIUDADPROVEEDOR"), Formato_Etiqueta_9, Brocha, 395, 138)
        e.Graphics.DrawString("TELÉFONO:", Formato_Etiqueta_7, Brocha, 627, 127)
        e.Graphics.DrawString(FilaOrdenCompra("TELEFONO"), Formato_Etiqueta_10, Brocha, 635, 138)
        e.Graphics.DrawLine(Lapiz, 30, 153, 800, 153) ' horizontal
        Dim identifi As String = ClConvertir.Fun_FormatearCedula(Trim(FilaOrdenCompra("IDENTIFICACION")))
        If FilaOrdenCompra("CODIGOTIPOIDENTIFICACION") = 3 Then
            e.Graphics.DrawString("NIT: " + identifi + IIf(IsDBNull(FilaOrdenCompra("DIGITOVERIFICACION")) = True, "", IIf(Trim(FilaOrdenCompra("DIGITOVERIFICACION")) = "", "", "-" + FilaOrdenCompra("DIGITOVERIFICACION"))), Formato_Etiqueta_12, Brocha, 35, 154)
        Else
            e.Graphics.DrawString("C.C.: " + identifi, Formato_Etiqueta_12, Brocha, 42, 154)
        End If
        e.Graphics.DrawString("COTIZACIÓN No. " + IIf(IsDBNull(FilaOrdenCompra("COTIZACION")), "", FilaOrdenCompra("COTIZACION")), Formato_Etiqueta_10, Brocha, 250, 156)
        e.Graphics.DrawLine(Lapiz, 30, 173, 600, 173) ' horizontal
        e.Graphics.DrawString("ACEPTADO POR EL PROVEEDOR FIRMA Y SELLO", Formato_Etiqueta_4, Brocha, 630, 213)
        e.Graphics.DrawLine(Lapiz, 600, 153, 600, 221) ' vertical
        e.Graphics.DrawString("DIRECCIÓN NOTIFICACIÓN:", Formato_Etiqueta_7, Brocha, 35, 175)
        Dim direcciónp As String = Trim(FilaOrdenCompra("DIRECCIONNOTIFICACION"))
        Select Case direcciónp.Length
            Case Is < 36
                e.Graphics.DrawString(direcciónp, Formato_Etiqueta_9, Brocha, 40, 185)
                Exit Select
            Case Is < 45
                e.Graphics.DrawString(direcciónp, Formato_Etiqueta_8, Brocha, 40, 185)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(direcciónp, 1, 45), Formato_Etiqueta_7, Brocha, 40, 183)
                e.Graphics.DrawString(Mid(direcciónp, 46, 45), Formato_Etiqueta_7, Brocha, 40, 191)
        End Select
        e.Graphics.DrawString("CORREO ELECTRÓNICO DE NOTIFICACIÓN:", Formato_Etiqueta_7, Brocha, 330, 175)
        e.Graphics.DrawString(FilaOrdenCompra("CORREONOTIFICACION"), Formato_Etiqueta_9, Brocha, 340, 185)
        e.Graphics.DrawLine(Lapiz, 30, 201, 600, 201) ' horizontal
        e.Graphics.DrawString("PERSONA DE CONTACTO:", Formato_Etiqueta_7, Brocha, 35, 203)
        e.Graphics.DrawString(FilaOrdenCompra("PERSONACONTACTO"), Formato_Etiqueta_9, Brocha, 170, 204)
        ' DATOS OC
        e.Graphics.DrawString("COMPRADOR:", Formato_Etiqueta_7, Brocha, 35, 234)
        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawString(FilaOrdenCompra("COMPRADOR"), Formato_Etiqueta_10, Brocha, 110, 233)
            Case 1 'CSI
                e.Graphics.DrawString(FilaOrdenCompra("COMPRADOR") + "                    CONSORCIO SPIECAPAG-ISMOCOL      NIT. 900.741.263-4", Formato_Etiqueta_10, Brocha, 110, 233)
            Case 2 'ZAMORANA
                e.Graphics.DrawString(FilaOrdenCompra("COMPRADOR"), Formato_Etiqueta_8, Brocha, 110, 233)
        End Select
        e.Graphics.DrawLine(Lapiz, 30, 251, 800, 251) ' horizontal

        e.Graphics.DrawString("DIRECCIÓN ENVÍO:", Formato_Etiqueta_7, Brocha, 35, 259)
        Dim DirEnvio As String = FilaOrdenCompra("DIRECCIONENVIO")
        Select Case DirEnvio.Length
            Case Is < 86
                e.Graphics.DrawString(DirEnvio, Formato_Etiqueta_10, Brocha, 130, 256)
                Exit Select
            Case Is < 98
                e.Graphics.DrawString(DirEnvio, Formato_Etiqueta_8, Brocha, 130, 259)
                Exit Select
            Case Else
                e.Graphics.DrawString(DirEnvio, Formato_Etiqueta_6, Brocha, 130, 259)
        End Select
        e.Graphics.DrawLine(Lapiz, 30, 276, 800, 276) ' horizontal

        e.Graphics.DrawString("CON CARGO A/ CENTRO DE COSTO:", Formato_Etiqueta_7, Brocha, 35, 284)
        e.Graphics.DrawString(FilaOrdenCompra("CARGOA"), Formato_Etiqueta_9, Brocha, 220, 282)
        e.Graphics.DrawLine(Lapiz, 30, 301, 800, 301) ' horizontal

        e.Graphics.DrawString("REQUISICIÓN No.:", Formato_Etiqueta_7, Brocha, 35, 309)
        e.Graphics.DrawString(FilaOrdenCompra("REQUISICION"), Formato_Etiqueta_8, Brocha, 130, 308)
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 252, 309)
        e.Graphics.DrawString(FilaOrdenCompra("FECHASOLICITUDRQ"), Formato_Etiqueta_8, Brocha, 292, 308)
        e.Graphics.DrawString("FAMILIA:", Formato_Etiqueta_7, Brocha, 357, 309)
        e.Graphics.DrawString(FamiliaArticuloOC, Formato_Etiqueta_8, Brocha, 405, 308)

        Select Case FilaOrdenCompra("TIPOITEM")
            Case "P" 'Ítem de Pago Contractual
                e.Graphics.DrawString("TIPO ÍTEM:", Formato_Etiqueta_7, Brocha, 580, 353)
                e.Graphics.DrawString("ÍTEM PAGO CONTRACTUAL", Formato_Etiqueta_8, Brocha, 588, 365)
            Case "A" 'Ítem Adicional
                e.Graphics.DrawString("TIPO ÍTEM:", Formato_Etiqueta_7, Brocha, 580, 353)
                e.Graphics.DrawString("ÍTEM ADICIONAL", Formato_Etiqueta_8, Brocha, 588, 365)
            Case "M" 'Ítem Mayor Cantidad
                e.Graphics.DrawString("TIPO ÍTEM:", Formato_Etiqueta_7, Brocha, 580, 353)
                e.Graphics.DrawString("ÍTEM MAYOR CANTIDAD", Formato_Etiqueta_8, Brocha, 588, 365)
        End Select

        e.Graphics.DrawLine(Lapiz, 30, 326, 800, 326) ' horizontal

        e.Graphics.DrawString("ENTREGAR ANTES DE:", Formato_Etiqueta_7, Brocha, 35, 334)
        e.Graphics.DrawString(CDate(FilaOrdenCompra("FECHAENTREGA")).ToLongDateString, Formato_Etiqueta_10, Brocha, 152, 330)
        e.Graphics.DrawLine(Lapiz, 30, 351, 800, 351) ' horizontal

        e.Graphics.DrawString("ENVIAR COPIA DE LA ORDEN DE COMPRA Y REMISIÓN DEL MATERIAL", Formato_Etiqueta_8, Brocha, 400, 332)

        e.Graphics.DrawString("CONDICIONES DE PAGO:", Formato_Etiqueta_7, Brocha, 35, 353)
        Dim textoCondicionPago As New ArrayList
        textoCondicionPago.Add(FilaOrdenCompra("CONDICIONPAGO"))
        Dim textoCondicionPagoFinal As New ArrayList(TextoAParrafoFuente(textoCondicionPago, Formato_Etiqueta_8, 760, e))
        For i As Integer = 0 To textoCondicionPagoFinal.Count - 1
            e.Graphics.DrawString(textoCondicionPagoFinal(i), Formato_Etiqueta_8, Brocha, 40, 365 + (10 * i))
        Next

        If Not IsDBNull(FilaOrdenCompra("TIPOGERENCIA")) Then
            Dim texto As String = Trim(FilaOrdenCompra("TIPOGERENCIA"))
            Dim fuente As New Font("Arial", 12.0!, FontStyle.Bold)
            Dim sz As SizeF = e.Graphics.MeasureString(texto, fuente)
            e.Graphics.RotateTransform(-90.0F)
            e.Graphics.DrawString(texto, fuente, Brushes.LightGray, New Point(-697.5 - (sz.Width / 2), 12))
            e.Graphics.RotateTransform(90.0F)
        End If

        e.Graphics.DrawString("FAVOR SUMINISTRAR LOS SIGUIENTES ARTÍCULOS", Formato_Etiqueta_8, Brushes.Black, InicioCentradoTexto("FAVOR SUMINISTRAR LOS SIGUIENTES ARTÍCULOS", Formato_Etiqueta_8, 950, e) - 50, 382)


        'IMPRESIÓN DE ÍTEMS DE OC
        Dim iniciolinea As Integer = 397
        Dim FinLinea As Integer = 882

        'Títulos de Columnas
        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_7, Brocha, 30 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_7, 45, e), 407)
        e.Graphics.DrawLine(Lapiz, 75, iniciolinea, 75, FinLinea) ' vertical

        e.Graphics.DrawString("UNIDAD", Formato_Etiqueta_7, Brocha, 75 + InicioCentradoTexto("UNIDAD", Formato_Etiqueta_7, 50, e), 407)
        e.Graphics.DrawLine(Lapiz, 125, iniciolinea, 125, FinLinea) ' vertical

        e.Graphics.DrawString("CANT", Formato_Etiqueta_7, Brocha, 125 + InicioCentradoTexto("CANT", Formato_Etiqueta_7, 50, e), 407)
        e.Graphics.DrawLine(Lapiz, 175, iniciolinea, 175, FinLinea) ' vertical

        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_7, Brocha, 175 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_7, 70, e), 400)
        e.Graphics.DrawString("INVENTARIO", Formato_Etiqueta_7, Brocha, 175 + InicioCentradoTexto("INVENTARIO", Formato_Etiqueta_7, 70, e), 414)
        e.Graphics.DrawLine(Lapiz, 245, iniciolinea, 245, FinLinea) ' vertical

        e.Graphics.DrawString("DESCRIPCIÓN Y NÚMERO DE PARTES", Formato_Etiqueta_7, Brocha, 245 + InicioCentradoTexto("DESCRIPCIÓN Y NÚMERO DE PARTES", Formato_Etiqueta_7, 310, e), 407)
        e.Graphics.DrawLine(Lapiz, 555, iniciolinea, 555, FinLinea) ' vertical

        e.Graphics.DrawString("I.V.A.", Formato_Etiqueta_7, Brocha, 555 + InicioCentradoTexto("I.V.A.", Formato_Etiqueta_7, 35, e), 407)
        e.Graphics.DrawLine(Lapiz, 590, iniciolinea, 590, FinLinea) ' vertical

        e.Graphics.DrawString("VALOR", Formato_Etiqueta_7, Brocha, 590 + InicioCentradoTexto("VALOR", Formato_Etiqueta_7, 210, e), 400)
        e.Graphics.DrawLine(Lapiz, 590, iniciolinea + 15, 800, iniciolinea + 15) ' horizontal

        e.Graphics.DrawString("UNITARIO", Formato_Etiqueta_7, Brocha, 590 + InicioCentradoTexto("UNITARIO", Formato_Etiqueta_7, 95, e), 414)
        e.Graphics.DrawLine(Lapiz, 685, iniciolinea + 15, 685, FinLinea) ' vertical

        e.Graphics.DrawString("TOTAL", Formato_Etiqueta_7, Brocha, 685 + InicioCentradoTexto("TOTAL", Formato_Etiqueta_7, 115, e), 412)

        e.Graphics.DrawLine(Lapiz, 30, 427, 800, 427) ' horizontal

        Dim InicioYdeItemOC As Integer = 432

        'Imprimir Encabezado
        ContadorRenglones = 0

        If imprimirjustificación = True Then ' Si el encabezado es vacío, la variable se marca arriba con FALSE en la carga inicial.
            If Cadena_Total_ENCABEZADO_OC.Count <> 0 Then
                Dim puntoOrigenENCABEZADO As New Point(252, InicioYdeItemOC)
                Dim texto As String = ""
                For i = 0 To Cadena_Total_ENCABEZADO_OC.Count - 1
                    texto = Cadena_Total_ENCABEZADO_OC(i)
                    texto = SubParrafo1(Cadena_Total_ENCABEZADO_OC(i), Formato_Etiqueta_10, 305, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10, Brocha, puntoOrigenENCABEZADO.X, puntoOrigenENCABEZADO.Y)
                    puntoOrigenENCABEZADO.Y = puntoOrigenENCABEZADO.Y + 15
                    texto = ""
                Next
                ContadorRenglones = Cadena_Total_ENCABEZADO_OC.Count + 1
            End If
        End If


        Dim dashValues As Single() = {3, 3, 3, 3}
        Dim blackPen As New Pen(Color.Gray, 1)
        blackPen.DashPattern = dashValues

        'IMPRESIÓN DE ÍTEMS
        InicioYdeItemOC += ContadorRenglones * 15
        Dim alturaEncabezado As Integer = ContadorRenglones * 15
        If imprimirjustificación = True Then
            If Cadena_Total_ENCABEZADO_OC.Count > 0 Then
                e.Graphics.DrawLine(blackPen, New Point(30, InicioYdeItemOC - 5), New Point(800, InicioYdeItemOC - 5)) ' horizontal
            End If
        End If

        Dim espacio As Integer = 0
        Dim Cadena_Total_DESCRIPCION_IOC As New ArrayList
        Dim CadenasDESCRIPCION_IOC As New ArrayList
        Dim fuente_IOC As Font = Formato_Etiqueta_8

        'Dim j As Integer = 0
        For j = ContadorItemOrdenCompra To dtItemOrdenCompra.Rows.Count - 1
            Dim filaItemOC As DataRow
            filaItemOC = dtItemOrdenCompra.Rows(j)

            CadenasDESCRIPCION_IOC.Add(UCase(Trim(filaItemOC("NOMBREDESCRIPTIVO"))))
            Cadena_Total_DESCRIPCION_IOC = TextoAParrafoFuente(CadenasDESCRIPCION_IOC, fuente_IOC, 305, e)

            Dim espacionecesario As Integer = Cadena_Total_DESCRIPCION_IOC.Count * 13
            Dim espaciodisponible As Integer = 430
            If imprimirjustificación = True Then
                espaciodisponible -= alturaEncabezado + ESPACIOFILAS_OC
            Else
                espaciodisponible -= ESPACIOFILAS_OC
            End If

            ' Si no es el último ítem entonces puede ocupar el espacio del TOTALIZADOR.
            If (ContadorItemOrdenCompra <> dtItemOrdenCompra.Rows.Count - 1 And espaciodisponible >= espacionecesario) _
                Or (espaciodisponible - 40 >= espacionecesario) Then 'Or ContadorItemOrdenCompra = dtItemOrdenCompra.Rows.Count Then
                e.Graphics.DrawString(FormatearValorSinSimbolo(filaItemOC("IDITEMORDENCOMPRA"), fuente_IOC, e, 20), fuente_IOC, Brushes.Black, 40, InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(filaItemOC("ABREVIATURA"), fuente_IOC, Brushes.Black, 80, InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(FormatearValorSinSimbolo(filaItemOC("CANTIDAD"), fuente_IOC, e, 40), fuente_IOC, Brushes.Black, 130, InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(filaItemOC("IDARTICULO"), fuente_IOC, Brushes.Black, 180, InicioYdeItemOC + ESPACIOFILAS_OC)

                If Cadena_Total_DESCRIPCION_IOC.Count <> 0 Then
                    Dim puntoOrigenDESCRIPCION_IOC As New Point(252, InicioYdeItemOC + ESPACIOFILAS_OC)
                    Dim texto As String = ""
                    For k = 0 To Cadena_Total_DESCRIPCION_IOC.Count - 1
                        texto = SubParrafo1(Cadena_Total_DESCRIPCION_IOC(k), fuente_IOC, 305, e)
                        e.Graphics.DrawString(texto, fuente_IOC, Brocha, puntoOrigenDESCRIPCION_IOC.X, puntoOrigenDESCRIPCION_IOC.Y)
                        puntoOrigenDESCRIPCION_IOC.Y = puntoOrigenDESCRIPCION_IOC.Y + 13
                        texto = ""
                    Next
                    e.Graphics.DrawLine(blackPen, New Point(30, puntoOrigenDESCRIPCION_IOC.Y - 7), New Point(800, puntoOrigenDESCRIPCION_IOC.Y - 7)) ' horizontal
                    espacio = Cadena_Total_DESCRIPCION_IOC.Count * 13
                    CadenasDESCRIPCION_IOC.Clear()
                    Cadena_Total_DESCRIPCION_IOC.Clear()
                End If

                Dim iva As String = CInt(filaItemOC("IVA")).ToString & "%"
                e.Graphics.DrawString(FormatearValorSinSimbolo(filaItemOC("IVA"), fuente_IOC, e, 15) & "%", fuente_IOC, Brushes.Black, 560, InicioYdeItemOC + ESPACIOFILAS_OC)

                e.Graphics.DrawString(FormatearValor(filaItemOC("VALORUNITARIO"), FilaOrdenCompra("SIMBOLO"), fuente_IOC, e, 80), fuente_IOC, Brushes.Black, 597, InicioYdeItemOC + ESPACIOFILAS_OC)
                If FilaOrdenCompra("SIGLAISO") = "COP" Then
                    e.Graphics.DrawString(FormatearValor(Math.Truncate(filaItemOC("SUBVALORTOTALXITEM")), FilaOrdenCompra("SIMBOLO"), fuente_IOC, e, 80), fuente_IOC, Brushes.Black, 693, InicioYdeItemOC + ESPACIOFILAS_OC)
                Else
                    e.Graphics.DrawString(FormatearValor(filaItemOC("SUBVALORTOTALXITEM"), FilaOrdenCompra("SIMBOLO"), fuente_IOC, e, 80), fuente_IOC, Brushes.Black, 693, InicioYdeItemOC + ESPACIOFILAS_OC)
                End If

                parcialtotaloc = parcialtotaloc + filaItemOC("SUBVALORTOTALXITEM")

                ESPACIOFILAS_OC += espacio
                ContadorItemOrdenCompra += 1
            Else
                Exit For
            End If
        Next

        ' Imprimir observación y TOTALIZADOR (ABAJO)

        ' CUADROS DE FIRMAS
        e.Graphics.DrawLine(Lapiz, 30, 883, 800, 883) ' horizontal
        e.Graphics.DrawLine(Lapiz, 200, 883, 200, 972) ' vertical
        e.Graphics.DrawLine(Lapiz, 390, 883, 390, 972) ' vertical
        e.Graphics.DrawLine(Lapiz, 610, 883, 610, 972) ' vertical
        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawString("JEFES GRUPO COMPRAS", Formato_Etiqueta_5, Brocha, 10 + InicioCentradoTexto("JEFES GRUPO COMPRAS", Formato_Etiqueta_5, 200, e), 886)
                e.Graphics.DrawString("(COMPRADOR LOCAL)", Formato_Etiqueta_5, Brocha, 10 + InicioCentradoTexto("(COMPRADOR LOCAL)", Formato_Etiqueta_5, 200, e), 896)
                e.Graphics.DrawString("JEFES DPTO. DE MATERIALES", Formato_Etiqueta_5, Brocha, 203 + InicioCentradoTexto("JEFES DPTO. DE MATERIALES", Formato_Etiqueta_5, 190, e), 886)
                e.Graphics.DrawString("(JEFE MATERIALES OBRA)", Formato_Etiqueta_5, Brocha, 203 + InicioCentradoTexto("(JEFE MATERIALES OBRA)", Formato_Etiqueta_5, 190, e), 896)
                e.Graphics.DrawString("GERENTE CONSTRUCCIONES / OPERACIONES / MONTAJES", Formato_Etiqueta_5, Brocha, 393 + InicioCentradoTexto("GERENTE CONSTRUCCIONES / OPERACIONES / MONTAJES", Formato_Etiqueta_5, 220, e), 886)
                e.Graphics.DrawString("JEFES DE DEPARTAMENTO", Formato_Etiqueta_5, Brocha, 393 + InicioCentradoTexto("JEFES DE DEPARTAMENTO", Formato_Etiqueta_5, 220, e), 896)
                e.Graphics.DrawString("(ADMINISTRADOR)", Formato_Etiqueta_5, Brocha, 393 + InicioCentradoTexto("(ADMINISTRADOR)", Formato_Etiqueta_5, 220, e), 906)
                e.Graphics.DrawString("GERENTE GENERAL", Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto("GERENTE GENERAL", Formato_Etiqueta_5, 190, e), 886)
                e.Graphics.DrawString("(DIRECTOR DE OBRA)", Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto("(DIRECTOR DE OBRA)", Formato_Etiqueta_5, 190, e), 896)
                e.Graphics.DrawString(FilaOrdenCompra("REVISA"), Formato_Etiqueta_5, Brocha, 10 + InicioCentradoTexto(FilaOrdenCompra("REVISA"), Formato_Etiqueta_5, 200, e), 957)
                e.Graphics.DrawString(FilaOrdenCompra("AUTORIZA"), Formato_Etiqueta_5, Brocha, 203 + InicioCentradoTexto(FilaOrdenCompra("AUTORIZA"), Formato_Etiqueta_5, 190, e), 957)
                e.Graphics.DrawString(FilaOrdenCompra("APRUEBA"), Formato_Etiqueta_5, Brocha, 393 + InicioCentradoTexto(FilaOrdenCompra("APRUEBA"), Formato_Etiqueta_5, 220, e), 957)
                e.Graphics.DrawString(FilaOrdenCompra("GERENCIA"), Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto(FilaOrdenCompra("GERENCIA"), Formato_Etiqueta_5, 190, e), 957)
            Case 1 'CSI
            Case 2 'ZAMORANA
                e.Graphics.DrawString("COMPRADOR", Formato_Etiqueta_5, Brocha, 10 + InicioCentradoTexto("COMPRADOR", Formato_Etiqueta_5, 200, e), 886)
                e.Graphics.DrawString("RESPONSABLE MATERIALES", Formato_Etiqueta_5, Brocha, 203 + InicioCentradoTexto("RESPONSABLE MATERIALES", Formato_Etiqueta_5, 190, e), 886)
                e.Graphics.DrawString("ENCARGADO DE EQUIPOS", Formato_Etiqueta_5, Brocha, 393 + InicioCentradoTexto("ENCARGADO DE EQUIPOS", Formato_Etiqueta_5, 220, e), 886)
                e.Graphics.DrawString("APROBACION FINAL ", Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto("APROBACION FINAL", Formato_Etiqueta_5, 190, e), 886)

                e.Graphics.DrawString(FilaOrdenCompra("REVISA"), Formato_Etiqueta_5, Brocha, 10 + InicioCentradoTexto(FilaOrdenCompra("REVISA"), Formato_Etiqueta_5, 200, e), 957)
                e.Graphics.DrawString(FilaOrdenCompra("AUTORIZA"), Formato_Etiqueta_5, Brocha, 203 + InicioCentradoTexto(FilaOrdenCompra("AUTORIZA"), Formato_Etiqueta_5, 190, e), 957)
                e.Graphics.DrawString(FilaOrdenCompra("APRUEBA"), Formato_Etiqueta_5, Brocha, 393 + InicioCentradoTexto(FilaOrdenCompra("APRUEBA"), Formato_Etiqueta_5, 220, e), 957)
                e.Graphics.DrawString(FilaOrdenCompra("GERENCIA"), Formato_Etiqueta_5, Brocha, 613 + InicioCentradoTexto(FilaOrdenCompra("GERENCIA"), Formato_Etiqueta_5, 190, e), 957)

        End Select

        Dim mensaje As String = "* Los cargos indicados entre paréntesis tienen la responsabilidad en los lugares distintos a Bucaramanga"
        e.Graphics.DrawString(mensaje, Formato_Etiqueta_6, Brushes.Black, InicioCentradoTexto(mensaje, Formato_Etiqueta_6, 950, e) - 50, 977)
        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawString("Toda  notificación  comercial  derivada  de  esta  orden  de compra.  debe  remitirse  a la", Formato_Etiqueta_11R, Brocha, InicioCentradoTexto("Toda notificación comercial derivada de esta orden de compra. debe remitirse a la", Formato_Etiqueta_11R, 678, e), 1000)
                e.Graphics.DrawString("dirección   postal:  carrera 28 # 55 - 69  Bucaramanga, Santander,  Colombia  y al correo", Formato_Etiqueta_11R, Brocha, InicioCentradoTexto("dirección postal: carrera 28 #55-69 Bucaramanga, Santander, Colombia y al correo", Formato_Etiqueta_11R, 685, e), 1020)
                e.Graphics.DrawString("electrónico", Formato_Etiqueta_11R, Brocha, 50, 1040)
                e.Graphics.DrawString("materiales@ismocol.com.", Formato_Etiqueta_11IB, Brocha, 130, 1040)
                e.Graphics.DrawString("Cualquier otra dirección no será tenida en cuenta.", Formato_Etiqueta_11R, Brocha, 320, 1040)
            Case 1 'CSI
                e.Graphics.DrawString("", Formato_Etiqueta_10, Brocha, 90, 990)
            Case 2 'ZAMORANA
                e.Graphics.DrawString("Toda notificación comercial derivada de esta orden de compra, debe remitirse a la dirección", Formato_Etiqueta_11R, Brocha, InicioCentradoTexto("Toda notificación comercial derivada de esta orden de compra. debe remitirse a la dirección", Formato_Etiqueta_11R, 725, e), 1000)
                e.Graphics.DrawString("postal: carrera  28 # 55 - 69  Bucaramanga,  Santander,  Colombia  y  al  correo  electrónico", Formato_Etiqueta_11R, Brocha, InicioCentradoTexto("postal: carrera 28 #55-69 Bucaramanga, Santander, Colombia y al correo electrónico", Formato_Etiqueta_11R, 680, e), 1020)
                e.Graphics.DrawString("contabilidad@zamoranacolombia.com.", Formato_Etiqueta_11IB, Brocha, 40, 1040)
                e.Graphics.DrawString("Cualquier otra dirección no será tenida en cuenta.", Formato_Etiqueta_11R, Brocha, 332, 1040)

        End Select



        Dim PiePagina As String = ""
        If MarcarImpresa Then
            PiePagina = "Página " & contpaginas & " de " & paginastotalOC
        Else
            PiePagina = "Página " & contpaginas
        End If
        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 710, 1010)

        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 695, 1020)

        ' CUADRO FORMATO
        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawRectangle(Lapiz, 688, 977, 100, 30)
                e.Graphics.DrawLine(Lapiz, 688, 992, 788, 992) ' horizontal
                e.Graphics.DrawString("ICS - GRAL - F - 06", Formato_Etiqueta_6, Brushes.Black, 700, 979)
                e.Graphics.DrawString("   REVISIÓN No. 5", Formato_Etiqueta_6, Brushes.Black, 700, 995)
            Case 1 'CSI
            Case 2 'ZAMORANA
                e.Graphics.DrawRectangle(Lapiz, 688, 977, 100, 30)
                e.Graphics.DrawLine(Lapiz, 688, 992, 788, 992) ' horizontal
                e.Graphics.DrawString("ZMS - GRAL - F - 007", Formato_Etiqueta_6, Brushes.Black, 700, 979)
                e.Graphics.DrawString("   REVISIÓN No. 3", Formato_Etiqueta_6, Brushes.Black, 700, 995)
        End Select

        If ContadorItemOrdenCompra = dtItemOrdenCompra.Rows.Count Then
            'IMPRIMIR OBSERVACION Y TOTALIZADOR
            Dim Cadenas As New ArrayList
            Cadenas.Add(Trim(FilaOrdenCompra("OBSERVACION")))
            Dim Cadena_Total As New ArrayList
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6, 305, e)
            For k = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(k), Formato_Etiqueta_6, 305, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_6, Brocha, 250, 819 + (16 * k))
            Next
            Dim SubTotal As Object
            Dim Iva As Object
            Dim Descuento As Object = 0
            If dtItemOrdenCompra.Compute("Sum(DESCUENTOXITEM)", "") > 0 Then

                If FilaOrdenCompra("SIGLAISO") = "COP" Then
                    e.Graphics.DrawString("SUBTOTAL:", Formato_Etiqueta_8, Brocha, 610, 814)
                    SubTotal = dtItemOrdenCompra.Compute("Sum(SUBVALORTOTALXITEM)", "")
                    e.Graphics.DrawString(FormatearValor(CInt(SubTotal), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 814)
                    e.Graphics.DrawString("DESCUENTO:", Formato_Etiqueta_8, Brocha, 600, 830)
                    Descuento = dtItemOrdenCompra.Compute("Sum(DESCUENTOXITEM)", "")
                    e.Graphics.DrawString(FormatearValor(Math.Round(Descuento), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 830)
                    Iva = dtItemOrdenCompra.Compute("Sum(IVAXITEM)", "")
                    e.Graphics.DrawString("IVA:", Formato_Etiqueta_8, Brocha, 654, 846)
                    e.Graphics.DrawString(FormatearValor(Math.Round(Iva), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 846)
                    e.Graphics.DrawString("TOTAL:", Formato_Etiqueta_8, Brocha, 634, 862)
                    e.Graphics.DrawString(FormatearValor(Math.Round(SubTotal + Iva - Descuento), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 862)
                Else
                    e.Graphics.DrawString("SUBTOTAL:", Formato_Etiqueta_8, Brocha, 610, 814)
                    SubTotal = dtItemOrdenCompra.Compute("Sum(SUBVALORTOTALXITEM)", "")
                    e.Graphics.DrawString(FormatearValor(SubTotal, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 814)
                    e.Graphics.DrawString("DESCUENTO:", Formato_Etiqueta_8, Brocha, 600, 830)
                    Descuento = dtItemOrdenCompra.Compute("Sum(DESCUENTOXITEM)", "")
                    e.Graphics.DrawString(FormatearValor(Descuento, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 830)
                    Iva = dtItemOrdenCompra.Compute("Sum(IVAXITEM)", "")
                    e.Graphics.DrawString("IVA:", Formato_Etiqueta_8, Brocha, 654, 846)
                    e.Graphics.DrawString(FormatearValor(Iva, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 846)
                    e.Graphics.DrawString("TOTAL:", Formato_Etiqueta_8, Brocha, 634, 862)
                    e.Graphics.DrawString(FormatearValor(SubTotal + Iva - Descuento, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 862)
                End If

            Else

                If FilaOrdenCompra("SIGLAISO") = "COP" Then
                    e.Graphics.DrawString("SUBTOTAL:", Formato_Etiqueta_8, Brocha, 610, 830)
                    SubTotal = dtItemOrdenCompra.Compute("Sum(SUBVALORTOTALXITEM)", "")
                    e.Graphics.DrawString(FormatearValor(Math.Round(SubTotal), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 830)
                    Iva = dtItemOrdenCompra.Compute("Sum(IVAXITEM)", "")
                    e.Graphics.DrawString("IVA:", Formato_Etiqueta_8, Brocha, 654, 846)
                    e.Graphics.DrawString(FormatearValor(Math.Round(Iva), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 846)
                    e.Graphics.DrawString("TOTAL:", Formato_Etiqueta_8, Brocha, 634, 862)
                    e.Graphics.DrawString(FormatearValor(Math.Round(SubTotal + Iva), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 862)
                Else
                    e.Graphics.DrawString("SUBTOTAL:", Formato_Etiqueta_8, Brocha, 610, 830)
                    SubTotal = dtItemOrdenCompra.Compute("Sum(SUBVALORTOTALXITEM)", "")
                    e.Graphics.DrawString(FormatearValor(SubTotal, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 830)
                    Iva = dtItemOrdenCompra.Compute("Sum(IVAXITEM)", "")
                    e.Graphics.DrawString("IVA:", Formato_Etiqueta_8, Brocha, 654, 846)
                    e.Graphics.DrawString(FormatearValor(Iva, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 846)
                    e.Graphics.DrawString("TOTAL:", Formato_Etiqueta_8, Brocha, 634, 862)
                    e.Graphics.DrawString(FormatearValor(SubTotal + Iva, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 862)
                End If

            End If
            imprimirjustificación = True
            paginastotalOC = contpaginas
            contpaginas = 1
            ContadorRenglones = 0
            ContadorItemOrdenCompra = 0
            contcopiasOC = contcopiasOC + 1
            parcialtotaloc = 0

            ESPACIOFILAS_OC = 0

            If contcopiasOC = copiasOC Then
                e.HasMorePages = False
                contcopiasOC = 0

                copiaparacontabilidad1 = _copiaparacontabilidad1
                copiaparacontabilidad2 = _copiaparacontabilidad2
                copiaparaconsecutivo = _copiaparaconsecutivo
                copiaparafolderpedido = _copiaparafolderpedido

                If MarcarImpresa = True Then
                    GuardarImpresionOrdenCompra()
                Else
                    MarcarImpresa = True
                End If

            Else
                If Me.copiaparacontabilidad1 = True Then
                    Me.copiaparacontabilidad1 = False
                Else
                    If copiaparacontabilidad2 = True Then
                        Me.copiaparacontabilidad2 = False
                    Else
                        If copiaparaconsecutivo = True Then
                            Me.copiaparaconsecutivo = False
                        Else
                            If copiaparafolderpedido = True Then
                                Me.copiaparafolderpedido = False
                            End If
                        End If
                    End If
                End If

                e.HasMorePages = True
            End If

        Else
            'imprimir letrero del valor sumado de los items impresos
            e.Graphics.DrawString("PASAN:", Formato_Etiqueta_8, Brocha, 634, 862)

            If FilaOrdenCompra("SIGLAISO") = "COP" Then
                e.Graphics.DrawString(FormatearValor(Math.Truncate(parcialtotaloc), FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 862)
            Else
                e.Graphics.DrawString(FormatearValor(parcialtotaloc, FilaOrdenCompra("SIMBOLO"), Formato_Etiqueta_8, e, 80) + "  " + FilaOrdenCompra("SIGLAISO"), Formato_Etiqueta_8, Brocha, 689, 862)
            End If

            imprimirjustificación = False
            contpaginas = contpaginas + 1
            ContadorRenglones = 0
            ESPACIOFILAS_OC = 0

            e.HasMorePages = True
        End If
    End Sub

    Private Sub GuardarImpresionOrdenCompra()
        'Guarda información de la impresión , y modifica el campo de impreso
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure

            'If ORDENCOMPRACANCELADA = False Then
            Comando.Parameters.AddWithValue("@TIPO", 9)
            'Else
            '    If CANCELACIONPARCIAL Then
            '        Comando.Parameters.AddWithValue("@TIPO", 10)
            '    Else
            '        Comando.Parameters.AddWithValue("@TIPO", 11)
            '    End If
            'End If

            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IDORDENDECOMPRA)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Function FormatearValorSinSimbolo(ByVal Valor As Double,
                                    ByVal fuente As Drawing.Font,
                                    ByVal e As System.Drawing.Printing.PrintPageEventArgs,
                                    ByVal TamañoColumna As Integer) As String
        Dim temp As String = ""
        Dim ValorEntero As Integer = Fix(Valor)
        If ValorEntero.ToString.Length > 3 Then
            Dim valorstring As String = ValorEntero.ToString
            For i = 1 To valorstring.Length
                temp = Mid(valorstring, valorstring.Length - (i - 1), 1) + temp
                If i Mod (3) = 0 And i <> 0 Then
                    If i <> valorstring.Length Then
                        temp = "." + temp
                    End If

                End If
            Next
        Else
            temp = ValorEntero
        End If

        Dim AgregarCero As String = ""
        If Valor.ToString.IndexOf(".0") > 0 Then
            AgregarCero = "0"
        End If
        If Valor.ToString.IndexOf(",0") > 0 Then
            AgregarCero = "0"
        End If
        If Valor.ToString.IndexOf(".00") > 0 Then
            AgregarCero = "00"
        End If
        If Valor.ToString.IndexOf(",00") > 0 Then
            AgregarCero = "00"
        End If
        If Valor.ToString.IndexOf(".000") > 0 Then
            AgregarCero = "000"
        End If
        If Valor.ToString.IndexOf(",000") > 0 Then
            AgregarCero = "000"
        End If

        If Valor < ValorEntero Then
            temp = (ValorEntero - 1) & "," & AgregarCero & CInt((ValorEntero - Valor) * 100).ToString
        End If

        If (Valor - ValorEntero) > 0 Then
            temp = temp + "," & AgregarCero & CInt((Valor - ValorEntero) * 100).ToString
        End If

        Dim sz As SizeF = e.Graphics.MeasureString(temp, fuente)
        While sz.Width < TamañoColumna
            temp = " " + temp
            sz = e.Graphics.MeasureString(temp, fuente)
        End While
        FormatearValorSinSimbolo = temp

    End Function

    Private Function FormatearValor(ByVal Valor As Decimal, ByVal Simbolo As String,
                                    ByVal fuente As Drawing.Font, ByVal e As System.Drawing.Printing.PrintPageEventArgs,
                                    ByVal TamañoColumna As Integer) As String
        Dim pos As Integer = Valor.ToString.IndexOf(",")

        Dim decimales As String
        Dim valorstring As String
        If pos = -1 Then
            decimales = ""
            valorstring = Valor
        Else
            decimales = Mid(Valor.ToString, pos + 1, 3)
            valorstring = Mid(Valor.ToString, 1, Valor.ToString.Length - (Valor.ToString.Length - pos))
            decimales = Replace(decimales, ",00", "")
        End If

        Dim temp As String = ""
        For i = 1 To valorstring.Length
            temp = Mid(valorstring, valorstring.Length - (i - 1), 1) + temp
            If i Mod (3) = 0 And i <> 0 Then
                If i <> valorstring.Length Then
                    temp = "." + temp
                End If
            End If
        Next
        temp = Simbolo + " " + temp + decimales
        temp = Replace(temp, Simbolo + " .", Simbolo + " ")
        Dim sz As SizeF = e.Graphics.MeasureString(temp, fuente)
        While sz.Width < TamañoColumna
            temp = Simbolo + Replace(temp, Simbolo, " ")
            sz = e.Graphics.MeasureString(temp, fuente)
        End While
        FormatearValor = temp
    End Function

#End Region

#Region "63 - ICS-GRAL-F-07 CANCELACION ORDEN DE COMPRA"
    Private TipoCancelación As String
    Private CargarDataSetOrdenCompraCancelacion As Boolean = True
    Private WithEvents DocImp_CancelaciónOrdenDeCompraICSGRALF07 As New PrintDocument 'Documento a imprimir
    Private Sub DocImpCancelaciónOrdenDeCompraICSGRALF07(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CancelaciónOrdenDeCompraICSGRALF07.PrintPage
        If CargarDataSetOrdenCompraCancelacion = True Then
            Dim CadenasENCABEZADO As New ArrayList

            Dim adap As New Ds_ComprasTableAdapters.IMPRIMIRORDENCOMPRATableAdapter
            adap.FillByIDORDENCOMPRA(DsCompras.IMPRIMIRORDENCOMPRA, IDORDENDECOMPRA)
            TipoCancelación = "Cancelación Parcial"
            'Si la orden de compra no existe en ORDENCOMPRA entonces es cancelación total
            If DsCompras.IMPRIMIRORDENCOMPRA.Rows.Count = 0 Then
                TipoCancelación = "Cancelación Total"
                adap.FillOCCANCELADA(DsCompras.IMPRIMIRORDENCOMPRA, IDORDENDECOMPRA)
            End If
            If DsCompras.IMPRIMIRORDENCOMPRA.Rows.Count = 0 Then
                e.HasMorePages = False
                Exit Sub
            End If
            FilaOrdenCompra = DsCompras.IMPRIMIRORDENCOMPRA.Rows(0)

            Dim adap1 As New Ds_ComprasTableAdapters.IMPRIMIRITEMSORDENCOMPRATableAdapter
            adap1.FillITEMCANCELADOS(DsCompras.IMPRIMIRITEMSORDENCOMPRA, IDORDENDECOMPRA)
            If DsCompras.IMPRIMIRITEMSORDENCOMPRA.Rows.Count = 0 Then
                e.HasMorePages = False
                Exit Sub
            End If

            If FilaOrdenCompra("IDBODEGA") = 45 Then
                If MsgBox("¿Desea imprimir la orden de compra con el logo de CSI?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                    LogoEmpresa = 1 ' 1 = logo de CSI
                End If
            End If

            'Verificar si el Centro de Costo pertenece a Zamorana.
            If hsCentrosOperacionZamorana.Contains(Left(FilaOrdenCompra("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Regex.Replace(Trim(FilaOrdenCompra("ORDENCOMPRA")), "[-]\d+[A-Z]\d+", "")) Then
                If MsgBox("¿Desea imprimir la orden de compra con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                    LogoEmpresa = 2 ' 1 = logo de Zamorana
                End If
            ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
                LogoEmpresa = 2
            End If

            If Trim(FilaOrdenCompra("ENCABEZADO")) = "" Then
                imprimirjustificación = False
            Else
                CadenasENCABEZADO.AddRange(Split(UCase(Trim(FilaOrdenCompra("ENCABEZADO"))), Environment.NewLine))
                Dim EncabezadoTemporal As New ArrayList(TextoAParrafoFuente(CadenasENCABEZADO, Formato_Etiqueta_10, 305, e))
                For i As Integer = 0 To EncabezadoTemporal.Count - 1
                    If Trim(EncabezadoTemporal(i)) <> "" Then
                        Cadena_Total_ENCABEZADO_OC.Add(EncabezadoTemporal(i))
                    End If
                Next
            End If

            CargarDataSetOrdenCompraCancelacion = False
        End If


        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        Brocha.Color = Color.Black

        ' MARCA DE AGUA
        e.Graphics.RotateTransform(-45.0F)
        e.Graphics.DrawString("CANCELADO", Formato_Etiqueta_80, Brushes.Silver, -500, 600)
        e.Graphics.RotateTransform(45.0F)

        Select Case LogoEmpresa
            Case 0
                e.Graphics.DrawImage(imagen, 55, 20, 130, 104) 'ISMOCOL 
                e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_14R, Brocha, 30 + InicioCentradoTexto("ISMOCOL S.A.", Formato_Etiqueta_14R, 770, e), 25)
            Case 1
                e.Graphics.DrawImage(imagenCSI, 36, 20, 154, 104) 'CSI
            Case 2
                e.Graphics.DrawImage(zamorana, 20, 40, 213, 57) 'ZAMORANA
        End Select

        DrawRoundedRectangle(e.Graphics, 250, 50, 550, 70, 20) 'Consecutivo OC y tipo cancelación
        DrawRoundedRectangle(e.Graphics, 30, 130, 770, 100, 20) 'Datos Proveedor
        DrawRoundedRectangle(e.Graphics, 30, 240, 770, 185, 20) 'Detalle OC
        DrawRoundedRectangle(e.Graphics, 30, 455, 770, 575, 20) 'Items OC y Observación cancelación
        e.Graphics.DrawString("CANCELACIÓN ORDEN DE COMPRA", Formato_Etiqueta_11, Brocha, 250 + InicioCentradoTexto("CANCELACIÓN ORDEN DE COMPRA", Formato_Etiqueta_11, 290, e), 55)
        e.Graphics.DrawString(TipoCancelación, Formato_Etiqueta_11, Brocha, 250 + InicioCentradoTexto(TipoCancelación, Formato_Etiqueta_11, 290, e), 85)
        e.Graphics.DrawLine(Lapiz, 540, 50, 540, 120)
        e.Graphics.DrawString("NÚMERO:", Formato_Etiqueta_8, Brocha, 542, 53)
        e.Graphics.DrawString(FilaOrdenCompra("ORDENCOMPRA"), Formato_Etiqueta_12, Brocha, 550, 66)
        e.Graphics.DrawLine(Lapiz, 540, 85, 800, 85)

        If TipoCancelación = "Cancelación Total" Then
            e.Graphics.DrawString("CIUDAD Y FECHA DE CANCELACIÓN:", Formato_Etiqueta_8, Brocha, 542, 87)
            e.Graphics.DrawString(FilaOrdenCompra("CIUDADYFECHA"), Formato_Etiqueta_10, Brocha, 550, 100)
        End If

        e.Graphics.DrawString("RAZÓN SOCIAL O NOMBRE COMPLETO DEL PROVEEDOR:", Formato_Etiqueta_7, Brocha, 42, 135)
        e.Graphics.DrawString(FilaOrdenCompra("PROVEEDOR"), Formato_Etiqueta_10, Brocha, 50, 148)
        e.Graphics.DrawLine(Lapiz, 30, 164, 800, 164)
        e.Graphics.DrawString("DIRECCIÓN:", Formato_Etiqueta_7, Brocha, 42, 167)
        Dim dirección As String = Trim(FilaOrdenCompra("DIRECCIONPROVEEDOR"))
        Select Case dirección.Length
            Case Is < 40
                e.Graphics.DrawString(dirección, Formato_Etiqueta_10, Brocha, 50, 180)
                Exit Select
            Case Is < 50
                e.Graphics.DrawString(dirección, Formato_Etiqueta_7, Brocha, 50, 180)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(dirección, 1, 50), Formato_Etiqueta_7, Brocha, 50, 175)
                e.Graphics.DrawString(Mid(dirección, 51, 50), Formato_Etiqueta_7, Brocha, 50, 185)
        End Select
        e.Graphics.DrawString("CIUDAD:", Formato_Etiqueta_7, Brocha, 387, 167)
        e.Graphics.DrawString(FilaOrdenCompra("CIUDADPROVEEDOR"), Formato_Etiqueta_10, Brocha, 395, 180)
        e.Graphics.DrawString("TELÉFONO:", Formato_Etiqueta_7, Brocha, 627, 167)
        e.Graphics.DrawString(FilaOrdenCompra("TELEFONO"), Formato_Etiqueta_10, Brocha, 635, 180)
        e.Graphics.DrawLine(Lapiz, 30, 196, 800, 196)
        Dim identifi As String = ClConvertir.Fun_FormatearCedula(Trim(FilaOrdenCompra("IDENTIFICACION")))
        If FilaOrdenCompra("CODIGOTIPOIDENTIFICACION") = 3 Then
            e.Graphics.DrawString("NIT: " + identifi + IIf(IsDBNull(FilaOrdenCompra("DIGITOVERIFICACION")) = True, "", IIf(Trim(FilaOrdenCompra("DIGITOVERIFICACION")) = "", "", "-" + FilaOrdenCompra("DIGITOVERIFICACION"))), Formato_Etiqueta_12, Brocha, 76, 205)
        Else
            e.Graphics.DrawString("C.C.: " + identifi, Formato_Etiqueta_12, Brocha, 76, 205)
        End If
        e.Graphics.DrawString("COTIZACIÓN No. " + IIf(IsDBNull(FilaOrdenCompra("COTIZACION")), "", FilaOrdenCompra("COTIZACION")), Formato_Etiqueta_10, Brocha, 400, 210)
        e.Graphics.DrawString("COMPRADOR:", Formato_Etiqueta_7, Brocha, 42, 240)

        Select Case LogoEmpresa
            Case 0
                e.Graphics.DrawString(FilaOrdenCompra("COMPRADOR") + "                    ISMOCOL S.A.     NIT. 890.209.174-1", Formato_Etiqueta_10, Brocha, 50, 253)
                'ISMOCOL 
            Case 1
                e.Graphics.DrawString(FilaOrdenCompra("COMPRADOR") + "                    CONSORCIO SPIECAPAG-ISMOCOL      NIT. 900.741.263-4", Formato_Etiqueta_10, Brocha, 50, 253)
                'CSI
            Case 2
                e.Graphics.DrawString(FilaOrdenCompra("COMPRADOR") + "        ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S.    NIT. 900.149.238-1", Formato_Etiqueta_8, Brocha, 50, 253)
                'ZAMORANA
        End Select

        e.Graphics.DrawLine(Lapiz, 30, 269, 800, 269)
        e.Graphics.DrawString("DIRECCIÓN ENVIO:", Formato_Etiqueta_7, Brocha, 42, 270)
        Dim DirEnvio As String = FilaOrdenCompra("DIRECCIONENVIO")
        Select Case DirEnvio.Length
            Case Is < 70
                e.Graphics.DrawString(FilaOrdenCompra("DIRECCIONENVIO"), Formato_Etiqueta_10, Brocha, 50, 283)
                Exit Select
            Case Is < 140
                e.Graphics.DrawString(FilaOrdenCompra("DIRECCIONENVIO"), Formato_Etiqueta_8, Brocha, 50, 283)
                Exit Select
            Case Else
                e.Graphics.DrawString(FilaOrdenCompra("DIRECCIONENVIO"), Formato_Etiqueta_6, Brocha, 50, 283)
        End Select
        e.Graphics.DrawLine(Lapiz, 30, 299, 800, 299)


        e.Graphics.DrawString("CON CARGO A/ CENTRO DE COSTO:", Formato_Etiqueta_7, Brocha, 42, 300)
        e.Graphics.DrawString(FilaOrdenCompra("CARGOA"), Formato_Etiqueta_9, Brocha, 50, 313)

        e.Graphics.DrawLine(Lapiz, 30, 329, 800, 329)

        e.Graphics.DrawString("REQUISICIÓN No.:", Formato_Etiqueta_7, Brocha, 42, 333)
        e.Graphics.DrawString(FilaOrdenCompra("REQUISICION"), Formato_Etiqueta_8, Brocha, 50, 346)
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 262, 333)
        e.Graphics.DrawString(FilaOrdenCompra("FECHASOLICITUDRQ"), Formato_Etiqueta_8, Brocha, 270, 346)
        e.Graphics.DrawString("FAMILIA:", Formato_Etiqueta_7, Brocha, 357, 333)
        e.Graphics.DrawString(FamiliaArticuloOC, Formato_Etiqueta_8, Brocha, 365, 346)

        Select Case FilaOrdenCompra("TIPOITEM")
            Case "P" 'Ítem de Pago Contractual
                e.Graphics.DrawString("TIPO ÍTEM:", Formato_Etiqueta_7, Brocha, 580, 333)
                e.Graphics.DrawString("ÍTEM PAGO CONTRACTUAL", Formato_Etiqueta_8, Brocha, 588, 346)
            Case "A" 'Ítem Adicional
                e.Graphics.DrawString("TIPO ÍTEM:", Formato_Etiqueta_7, Brocha, 580, 333)
                e.Graphics.DrawString("ÍTEM ADICIONAL", Formato_Etiqueta_8, Brocha, 588, 346)
            Case "M" 'Ítem Mayor Cantidad
                e.Graphics.DrawString("TIPO ÍTEM:", Formato_Etiqueta_7, Brocha, 580, 333)
                e.Graphics.DrawString("ÍTEM MAYOR CANTIDAD", Formato_Etiqueta_8, Brocha, 588, 346)
        End Select

        e.Graphics.DrawLine(Lapiz, 30, 362, 800, 362)

        e.Graphics.DrawString("ENTREGAR ANTES DE:", Formato_Etiqueta_7, Brocha, 42, 362)
        e.Graphics.DrawString(CDate(FilaOrdenCompra("FECHAENTREGA")).ToLongDateString, Formato_Etiqueta_10, Brocha, 50, 375)
        e.Graphics.DrawLine(Lapiz, 30, 391, 800, 391)
        e.Graphics.DrawString("CONDICIONES DE PAGO:", Formato_Etiqueta_7, Brocha, 42, 392)
        e.Graphics.DrawString(FilaOrdenCompra("CONDICIONPAGO"), Formato_Etiqueta_8, Brocha, 50, 405)

        Dim textoArticulos As String = "FAVOR SUMINISTRAR LOS SIGUIENTE ARTÍCULOS"
        e.Graphics.DrawString(textoArticulos, Formato_Etiqueta_8, Brocha, 30 + InicioCentradoTexto(textoArticulos, Formato_Etiqueta_8, 770, e), 435)

        Dim iniciolinea As Integer = 455
        Dim FinLinea As Integer = 940

        e.Graphics.DrawLine(Lapiz, 75, iniciolinea, 75, FinLinea) 'Vertical
        e.Graphics.DrawLine(Lapiz, 125, iniciolinea, 125, FinLinea) 'Vertical
        e.Graphics.DrawLine(Lapiz, 195, iniciolinea, 195, FinLinea) 'Vertical
        e.Graphics.DrawLine(Lapiz, 280, iniciolinea, 280, FinLinea) 'Vertical
        e.Graphics.DrawLine(Lapiz, 590, iniciolinea, 590, FinLinea) 'Vertical
        e.Graphics.DrawLine(Lapiz, 590, iniciolinea + 15, 800, iniciolinea + 15) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 685, iniciolinea + 15, 685, FinLinea) 'Vertical
        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_7, Brocha, 30 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_7, 45, e), 465)
        e.Graphics.DrawString("UNIDAD", Formato_Etiqueta_7, Brocha, 75 + InicioCentradoTexto("UNIDAD", Formato_Etiqueta_7, 50, e), 465)
        e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_7, Brocha, 125 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_7, 70, e), 465)
        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_7, Brocha, 195 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_7, 85, e), 458)
        e.Graphics.DrawString("INVENTARIO", Formato_Etiqueta_7, Brocha, 195 + InicioCentradoTexto("INVENTARIO", Formato_Etiqueta_7, 85, e), 472)
        e.Graphics.DrawString("DESCRIPCIÓN Y NÚMERO DE PARTES", Formato_Etiqueta_7, Brocha, 280 + InicioCentradoTexto("DESCRIPCIÓN Y NÚMERO DE PARTES", Formato_Etiqueta_7, 310, e), 465)
        e.Graphics.DrawString("CANCELADO", Formato_Etiqueta_7, Brocha, 590 + InicioCentradoTexto("CANCELADO", Formato_Etiqueta_7, 210, e), 458)
        e.Graphics.DrawString("TIPO", Formato_Etiqueta_7, Brocha, 590 + InicioCentradoTexto("TIPO", Formato_Etiqueta_7, 95, e), 472)
        e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_7, Brocha, 685 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_7, 115, e), 472)
        e.Graphics.DrawLine(Lapiz, 30, 485, 800, 485) 'Horizontal


        'Imprimir Encabezado
        Dim InicioYdeItemOC As Integer = 490

        ContadorRenglones = 0

        If imprimirjustificación = True Then
            If Cadena_Total_ENCABEZADO_OC.Count <> 0 Then
                Dim puntoOrigenENCABEZADO As New Point(280, InicioYdeItemOC)
                Dim texto As String = ""
                For i = 0 To Cadena_Total_ENCABEZADO_OC.Count - 1
                    texto = Cadena_Total_ENCABEZADO_OC(i)
                    texto = SubParrafo1(Cadena_Total_ENCABEZADO_OC(i), Formato_Etiqueta_10, 305, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10, Brocha, puntoOrigenENCABEZADO.X, puntoOrigenENCABEZADO.Y)
                    puntoOrigenENCABEZADO.Y = puntoOrigenENCABEZADO.Y + 15
                    texto = ""
                Next
                ContadorRenglones = Cadena_Total_ENCABEZADO_OC.Count + 1
            End If
        End If

        Dim dashValues As Single() = {3, 3, 3, 3}
        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = dashValues

        'Impresión de item
        InicioYdeItemOC += ContadorRenglones * 15
        Dim alturaEncabezado As Integer = ContadorRenglones * 15
        If imprimirjustificación = True Then
            If Cadena_Total_ENCABEZADO_OC.Count > 0 Then
                e.Graphics.DrawLine(lineaPunteada, New Point(30, InicioYdeItemOC - 5), New Point(800, InicioYdeItemOC - 5)) ' horizontal
            End If
        End If

        Dim espacio As Integer = 0
        Dim Cadena_Total_DESCRIPCION_IOC As New ArrayList
        Dim CadenasDESCRIPCION_IOC As New ArrayList
        Dim fuente_IOC As Font = Formato_Etiqueta_8

        For j = ContadorItemOrdenCompra To DsCompras.IMPRIMIRITEMSORDENCOMPRA.Rows.Count - 1
            Dim filaItemOC As DataRow
            filaItemOC = DsCompras.IMPRIMIRITEMSORDENCOMPRA.Rows(j)

            CadenasDESCRIPCION_IOC.Add(UCase(Trim(filaItemOC("NOMBREDESCRIPTIVO"))))

            If TipoCancelación = "Cancelación Parcial" Then
                CadenasDESCRIPCION_IOC.Add("Motivo: " + UCase(Trim(filaItemOC("OBSERVACIONCANCELACION"))))
                CadenasDESCRIPCION_IOC.Add("Cancela: " + UCase(Trim(filaItemOC("CANCELA"))))
                CadenasDESCRIPCION_IOC.Add("Fecha: " + filaItemOC("FECHACANCELACION"))

                Dim Temp_DESCRIPCION_IOC As ArrayList = TextoAParrafoFuente(CadenasDESCRIPCION_IOC, fuente_IOC, 305, e)
                For i As Integer = 0 To Temp_DESCRIPCION_IOC.Count - 1
                    If Trim(Temp_DESCRIPCION_IOC(i)) <> "" Then
                        Cadena_Total_DESCRIPCION_IOC.Add(Temp_DESCRIPCION_IOC(i))
                    End If
                Next
                Cadena_Total_DESCRIPCION_IOC.Add("")
            Else
                Cadena_Total_DESCRIPCION_IOC = TextoAParrafoFuente(CadenasDESCRIPCION_IOC, fuente_IOC, 305, e)
            End If

            Dim espacionecesario As Integer = Cadena_Total_DESCRIPCION_IOC.Count * 13
            Dim espaciodisponible As Integer = 455
            If imprimirjustificación = True Then
                espaciodisponible -= alturaEncabezado + ESPACIOFILAS_OC
            Else
                espaciodisponible -= ESPACIOFILAS_OC
            End If

            If (espaciodisponible - 20) >= espacionecesario Then
                e.Graphics.DrawString(filaItemOC("IDITEMORDENCOMPRA"), fuente_IOC, Brocha, 30 + InicioCentradoTexto(filaItemOC("IDITEMORDENCOMPRA"), fuente_IOC, 45, e), InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(filaItemOC("ABREVIATURA"), fuente_IOC, Brocha, 75 + InicioCentradoTexto(filaItemOC("ABREVIATURA"), fuente_IOC, 50, e), InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(FormatearValorSinSimbolo(filaItemOC("CANTIDAD"), fuente_IOC, e, 60), fuente_IOC, Brocha, 130, InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(filaItemOC("IDARTICULO"), fuente_IOC, Brocha, 195 + InicioCentradoTexto(filaItemOC("IDARTICULO"), fuente_IOC, 85, e), InicioYdeItemOC + ESPACIOFILAS_OC)
                Dim textoTipoCancelacion As String = IIf(filaItemOC("TIPOCANCELACION") = "T", "Total", "Parcial")
                e.Graphics.DrawString(textoTipoCancelacion, fuente_IOC, Brocha, 595, InicioYdeItemOC + ESPACIOFILAS_OC)
                e.Graphics.DrawString(FormatearValorSinSimbolo(filaItemOC("CANTIDADCANCELADA"), fuente_IOC, e, 105), fuente_IOC, Brocha, 690, InicioYdeItemOC + ESPACIOFILAS_OC)

                If Cadena_Total_DESCRIPCION_IOC.Count <> 0 Then
                    Dim puntoOrigenDESCRIPCION_IOC As New Point(280, InicioYdeItemOC + ESPACIOFILAS_OC)
                    Dim texto As String = ""
                    For k = 0 To Cadena_Total_DESCRIPCION_IOC.Count - 1
                        texto = SubParrafo1(Cadena_Total_DESCRIPCION_IOC(k), fuente_IOC, 305, e)
                        e.Graphics.DrawString(texto, fuente_IOC, Brocha, puntoOrigenDESCRIPCION_IOC.X, puntoOrigenDESCRIPCION_IOC.Y)
                        puntoOrigenDESCRIPCION_IOC.Y = puntoOrigenDESCRIPCION_IOC.Y + 13
                        texto = ""
                    Next
                    e.Graphics.DrawLine(lineaPunteada, New Point(30, puntoOrigenDESCRIPCION_IOC.Y - 7), New Point(800, puntoOrigenDESCRIPCION_IOC.Y - 7)) ' horizontal
                    espacio = Cadena_Total_DESCRIPCION_IOC.Count * 13
                    CadenasDESCRIPCION_IOC.Clear()
                    Cadena_Total_DESCRIPCION_IOC.Clear()
                End If

                ESPACIOFILAS_OC += espacio
                ContadorItemOrdenCompra += 1
            Else
                Exit For
            End If
        Next


        'Imprimir Observación de cancelación
        e.Graphics.DrawLine(Lapiz, 30, 940, 800, 940) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 600, 940, 600, 1030) 'Vertical
        e.Graphics.DrawString("JEFES DPTO. DE MATERIALES", Formato_Etiqueta_5, Brocha, 600 + InicioCentradoTexto("JEFES DPTO. DE MATERIALES", Formato_Etiqueta_5, 200, e), 944)
        e.Graphics.DrawString("(JEFE MATERIALES OBRA)", Formato_Etiqueta_5, Brocha, 600 + InicioCentradoTexto("(JEFE MATERIALES OBRA)", Formato_Etiqueta_5, 200, e), 954)
        e.Graphics.DrawString(FilaOrdenCompra("AUTORIZA"), Formato_Etiqueta_5, Brocha, 600 + InicioCentradoTexto(FilaOrdenCompra("GERENCIA"), Formato_Etiqueta_5, 200, e), 1015)

        Dim PiePagina As String

        If MarcarImpresa Then
            PiePagina = "Pagina " & contpaginas & " de " & paginastotal
        Else
            PiePagina = "Página " & contpaginas
        End If
        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto(PiePagina, Formato_Etiqueta_6, 770, e), 1050)


        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brocha, 50, 1050)
        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawRectangle(Lapiz, 688, 1035, 100, 30)
                e.Graphics.DrawLine(Lapiz, 688, 1050, 788, 1050) 'Horizontal
                e.Graphics.DrawString("ICS - GRAL - F - 07", Formato_Etiqueta_6, Brocha, 688 + InicioCentradoTexto("ICS - GRAL - F - 07", Formato_Etiqueta_6, 100, e), 1037)
                e.Graphics.DrawString("REVISIÓN No. 2", Formato_Etiqueta_6, Brocha, 688 + InicioCentradoTexto("REVISIÓN No. 2", Formato_Etiqueta_6, 100, e), 1053)
            Case 1
            Case 2 'ZAMORANA
                e.Graphics.DrawRectangle(Lapiz, 688, 1035, 100, 30)
                e.Graphics.DrawLine(Lapiz, 688, 1050, 788, 1050) 'Horizontal
                e.Graphics.DrawString("ZMS - GRAL - F - 008", Formato_Etiqueta_6, Brocha, 688 + InicioCentradoTexto("ZMS - GRAL - F - 008", Formato_Etiqueta_6, 100, e), 1037)
                e.Graphics.DrawString("REVISIÓN No. 0", Formato_Etiqueta_6, Brocha, 688 + InicioCentradoTexto("REVISIÓN No. 0", Formato_Etiqueta_6, 100, e), 1053)
        End Select

        If ContadorItemOrdenCompra = DsCompras.IMPRIMIRITEMSORDENCOMPRA.Count Then
            Dim textoUltimo As String = "--------------ÚLTIMO RENGLON--------------"
            e.Graphics.DrawString(textoUltimo, Formato_Etiqueta_8, Brocha, 280 + InicioCentradoTexto(textoUltimo, Formato_Etiqueta_8, 310, e), InicioYdeItemOC + ESPACIOFILAS_OC)
            'Imprimir observación y TOTALIZADOR
            Dim observa As String = "Observación: " + Trim(FilaOrdenCompra("OBSERVACIONCANCELACION"))
            If observa.Length > 60 Then
                Dim observa1 As String = Trim(Mid(observa, 1, 60))
                Dim pos As Integer
                pos = observa1.LastIndexOf(" ")
                observa1 = Trim(Mid(observa, 1, pos))
                e.Graphics.DrawString(observa1, Formato_Etiqueta_9, Brocha, 45, 950)
                observa = Trim(Mid(observa, pos + 1, observa.Length))
                e.Graphics.DrawString(observa, Formato_Etiqueta_9, Brocha, 128, 965)
            Else
                e.Graphics.DrawString(Mid(observa, 1, 60), Formato_Etiqueta_9, Brocha, 55, 950)
            End If

            If Trim(FilaOrdenCompra("OBSERVACIONCANCELACION")) <> "" Then
                e.Graphics.DrawString("Cancela: " + FilaOrdenCompra("CANCELA"), Formato_Etiqueta_5, Brocha, 55, 1015)
            End If

            imprimirjustificación = True
            paginastotal = contpaginas
            contpaginas = 1
            ContadorRenglones = 0
            ContadorItemOrdenCompra = 0
            ESPACIOFILAS_OC = 0

            e.HasMorePages = False
            If MarcarImpresa = True Then
                GuardarImpresionOrdenCompra()
            End If
            MarcarImpresa = True
        Else
            'imprimir letrero del valor sumado de los items impresos
            Dim textoPasa As String = "-----------PASA A LA SIGUIENTE HOJA-----------"
            e.Graphics.DrawString(textoPasa, Formato_Etiqueta_8, Brocha, 280 + InicioCentradoTexto(textoPasa, Formato_Etiqueta_8, 310, e), InicioYdeItemOC + ESPACIOFILAS_OC)

            imprimirjustificación = False
            contpaginas += 1
            ContadorRenglones = 0
            ESPACIOFILAS_OC = 0

            e.HasMorePages = True
        End If

    End Sub

#End Region

#Region "64 - ICS-GRAL-F-20 ENTRADA DE ALMACEN"

    Dim WithEvents DocImp_EntradaDeAlmacenICSGRALF20 As New PrintDocument 'Documento a imprimir

    ''' <summary>Determinar si se deben cargar los datos de la Entrada de almacén. No reinicia durante la impresión.</summary>
    Public CargarDatasetEntradaAlmacen As Boolean = True

    Public IDENTRADAALMACEN As Integer = -1

    Public ENTRADACANCELADA As Boolean = False

    Public CANCELACIONPARCIAL As Boolean = False

    Public FilaEntradaAlmacen As DataRow

    Dim ContadorItemsEntrada As Integer = 0

    Dim TotalPaginasEntrada As Integer = 0

    Dim Dt_EntradaAlmacen As DataTable

    Dim ImpresionEntrada As Boolean = False

    Dim PaginasImpresasEntrada As Integer

    Dim EntradaParcial As Boolean = False

    Dim TipoEntrada As String = ""

    '
    ' YA DECLARADOS EN SALIDAS DE ALMACEN
    '
    'Dim EquiposAsociados As Boolean = False
    'Dim ConteoEquipos As Integer = -1
    'Dim VectorEquipos As ArrayList

    Private Sub DocImpEntradaDeAlmacenICSGRALF20(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_EntradaDeAlmacenICSGRALF20.PrintPage
        If CargarDatasetEntradaAlmacen = True Then
            Dim Cadena_Consulta As String

            If ENTRADACANCELADA = False Then
                Cadena_Consulta = "SELECT * FROM dbo.ImpresionEntradaAlmacen(" + IDENTRADAALMACEN.ToString + ") AS ImpresionEntradaAlmacen"
            Else
                If CANCELACIONPARCIAL Then
                    Cadena_Consulta = "SELECT   * FROM  dbo.ImpresionEntradaAlmacenCancelada(1," + IDENTRADAALMACEN.ToString + ") AS ImpresionEntradaAlmacen"
                Else
                    Cadena_Consulta = "SELECT   * FROM  dbo.ImpresionEntradaAlmacenCancelada(0," + IDENTRADAALMACEN.ToString + ") AS ImpresionEntradaAlmacen"
                End If

            End If

            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_EntradaAlmacen = New DataTable
            Adaptador.Fill(Dt_EntradaAlmacen)
            Consulta.Connection.Close()
            FilaEntradaAlmacen = Dt_EntradaAlmacen.Rows(0)
            CargarDatasetEntradaAlmacen = False
            'revisar si se van a incluir equipos
            Dim dsEquipos As New DataSet

            TipoEntrada = Trim(FilaEntradaAlmacen("TIPOENTRADA"))

            If TipoEntrada = "T" Then 'TRASLADO DE BODEGA
                'cargar equipos
                dsEquipos = bddatos.ModificarEntradasSalidas(20, 0, 0, 0, Date.Now, 0, Date.Now, "", 0, IDENTRADAALMACEN)
                If dsEquipos.Tables(0).Rows(0)("CONTEO") > 0 Then
                    'tiene equipos asociados a esta remisión, cargarlos
                    EquiposAsociados = True
                End If
            ElseIf TipoEntrada = "S" Then 'si es un retorno de custodia
                'cargar equipos
                dsEquipos = bddatos.ModificarCustodias(7, 0, 0, 0, 0, 0, IDENTRADAALMACEN)
                If dsEquipos.Tables(0).Rows(0)("CONTEO") > 0 Then
                    'tiene equipos asociados a esta remisión, cargarlos
                    EquiposAsociados = True
                End If
            End If
        End If

        If ENTRADACANCELADA = False Then
            If TipoEntrada = "C" Then
                For i = 0 To Dt_EntradaAlmacen.Rows.Count - 1
                    Dim FilaPARCIAL As DataRow
                    FilaPARCIAL = Dt_EntradaAlmacen.Rows(i)
                    'miramos si algún artículo de alguna orden de compra falta por ingresar.
                    If FilaPARCIAL("FALTAxEA") > 0 Then
                        EntradaParcial = True
                    End If
                Next

                If EntradaParcial Then
                    e.Graphics.RotateTransform(-45.0F)
                    e.Graphics.DrawString("ENTRADA", Formato_Etiqueta_80, Brushes.Silver, -360, 600)
                    e.Graphics.DrawString("PARCIAL", Formato_Etiqueta_80, Brushes.Silver, -340, 700)
                    e.Graphics.RotateTransform(45.0F)
                Else
                    e.Graphics.RotateTransform(-45.0F)
                    e.Graphics.DrawString("ORDEN COMPLETA", Formato_Etiqueta_50, Brushes.Silver, -400, 640)
                    e.Graphics.DrawString("PARA FACTURACION", Formato_Etiqueta_50, Brushes.Silver, -460, 720)
                    e.Graphics.RotateTransform(45.0F)
                End If
            End If
        End If

        If FilaEntradaAlmacen("IDBODEGA") = 45 Then
            If MsgBox("¿Desea imprimir la entrada de almacén con el logo de CSI?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 1 ' Logo de CSI
            End If
        End If

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaEntradaAlmacen("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Regex.Replace(Trim(FilaEntradaAlmacen("ENTRADAALMACEN")), "[.]\d+", "")) Then
            If MsgBox("¿Desea imprimir la entrada de almacén con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' Logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Dim Esdevoluciónalproveedor As Boolean = False

        If ENTRADACANCELADA = True Then
            Dim observaciones As String
            If ENTRADACANCELADA = True Then
                observaciones = Trim(FilaEntradaAlmacen("OBSERVACIONCANCELACION"))
            Else
                observaciones = Trim(FilaEntradaAlmacen("OBSERVACION"))
            End If

            If observaciones.IndexOf("(DP)") <> -1 Then
                Esdevoluciónalproveedor = True
                e.Graphics.RotateTransform(-45.0F)
                e.Graphics.DrawString("DEVOLUCIÓN", Formato_Etiqueta_80, Brushes.Silver, -500, 550)
                e.Graphics.DrawString("A PROVEEDOR", Formato_Etiqueta_80, Brushes.Silver, -550, 650)
                e.Graphics.RotateTransform(45.0F)
            Else
                e.Graphics.RotateTransform(-45.0F)
                e.Graphics.DrawString("CANCELADO", Formato_Etiqueta_80, Brushes.Silver, -500, 600)
                e.Graphics.RotateTransform(45.0F)
            End If

        End If

        Brocha.Color = Color.Black

        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawImage(imagen, 46, 56, 75, 60)
                e.Graphics.DrawLine(Lapiz, 124, 50, 124, 124) 'Vertical 2
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 46, 56, 75, 60)
                e.Graphics.DrawLine(Lapiz, 124, 50, 124, 124) 'Vertical 2
            Case 2 'ZAMORANA
                e.Graphics.DrawImage(zamorana, 45, 60, 213, 57)
                e.Graphics.DrawLine(Lapiz, 270, 50, 270, 124) 'Vertical 2
        End Select


        e.Graphics.DrawLine(Lapiz, 40, 50, 800, 50) 'Horizontal 1
        e.Graphics.DrawLine(Lapiz, 40, 124, 800, 124) 'Horizontal 2
        e.Graphics.DrawLine(Lapiz, 700, 86, 800, 86) 'Horizontal 3

        e.Graphics.DrawLine(Lapiz, 40, 50, 40, 124)   'Vertical 1

        e.Graphics.DrawLine(Lapiz, 700, 50, 700, 124) 'Vertical 3
        e.Graphics.DrawLine(Lapiz, 800, 50, 800, 124) 'Vertical 4


        If ENTRADACANCELADA = True Then
            e.Graphics.DrawString("CANCELACION ENTRADA DE ALMACÉN", Formato_Etiqueta_14, Brocha, 220, 60)
        Else
            e.Graphics.DrawString("ENTRADA DE ALMACÉN", Formato_Etiqueta_14, Brocha, 300, 60)

        End If

        If Esdevoluciónalproveedor = False Then
            e.Graphics.DrawString(FilaEntradaAlmacen("TIPOSALIDA"), Formato_Etiqueta_7, Brocha, 350, 80)
        Else
            e.Graphics.DrawString("DEVOLUCIÓN AL PROVEEDOR", Formato_Etiqueta_7, Brocha, 350, 80)
        End If

        Select Case LogoEmpresa
            Case 0 ' ISMOCOL S.A.
                If ENTRADACANCELADA Then
                    e.Graphics.DrawString("ICS-GRAL-F-023", Formato_Etiqueta_7, Brocha, 710, 70)
                    e.Graphics.DrawString("Revisión No.1", Formato_Etiqueta_7, Brocha, 715, 110)
                Else
                    e.Graphics.DrawString("ICS-GRAL-F-20", Formato_Etiqueta_7, Brocha, 720, 70)
                    e.Graphics.DrawString("Revisión No.2", Formato_Etiqueta_7, Brocha, 720, 110)
                End If
            Case 1 'CSI
            Case 2 'ZAMORANA
                e.Graphics.DrawString("ZMS-GRAL-F-009", Formato_Etiqueta_7, Brocha, 708, 70)
                e.Graphics.DrawString("Revisión No.0", Formato_Etiqueta_7, Brocha, 715, 110)
        End Select

        e.Graphics.DrawString("No. " + Trim(FilaEntradaAlmacen("ENTRADAALMACEN")), Formato_Etiqueta_14, Brocha, 300, 130)
        e.Graphics.DrawString("Fecha Impresión:", Formato_Etiqueta_8, Brocha, 600, 130)
        e.Graphics.DrawString(StrConv(Date.Now.ToLongDateString, VbStrConv.ProperCase), Formato_Etiqueta_8R, Brocha, 610, 145)
        e.Graphics.DrawLine(Lapiz, 40, 164, 800, 164) 'Horizontal 4

        e.Graphics.DrawString("Bodega ", Formato_Etiqueta_8, Brocha, 40, 170)
        e.Graphics.DrawString(FilaEntradaAlmacen("BODEGA"), Formato_Etiqueta_8R, Brocha, 50, 185)
        e.Graphics.DrawString("Orden de Compra No. ", Formato_Etiqueta_8, Brocha, 230, 170)
        e.Graphics.DrawString(FilaEntradaAlmacen("ORDENCOMPRA"), Formato_Etiqueta_8R, Brocha, 240, 185)
        e.Graphics.DrawString("Requisición No: ", Formato_Etiqueta_8, Brocha, 430, 170)
        e.Graphics.DrawString(FilaEntradaAlmacen("REQUISICION"), Formato_Etiqueta_8R, Brocha, 440, 185)
        e.Graphics.DrawString("Fecha Recibido: ", Formato_Etiqueta_8, Brocha, 600, 170)
        e.Graphics.DrawString(StrConv(CDate(FilaEntradaAlmacen("FECHARECIBIDO")).ToLongDateString, VbStrConv.ProperCase), Formato_Etiqueta_8R, Brocha, 610, 185)

        e.Graphics.DrawLine(Lapiz, 40, 200, 800, 200) 'Horizontal 5
        e.Graphics.DrawString("Proveedor: ", Formato_Etiqueta_8, Brocha, 40, 205)
        e.Graphics.DrawString(FilaEntradaAlmacen("NOMBREPROVEEDOR"), Formato_Etiqueta_8R, Brocha, 50, 220)

        e.Graphics.DrawString("Comprador: ", Formato_Etiqueta_8, Brocha, 40, 235)
        e.Graphics.DrawString(FilaEntradaAlmacen("PERSONACOMPRA"), Formato_Etiqueta_8R, Brocha, 50, 250)

        e.Graphics.DrawString("No. Remisión: ", Formato_Etiqueta_8, Brocha, 500, 205)
        e.Graphics.DrawString(FilaEntradaAlmacen("NOREMISION"), Formato_Etiqueta_8R, Brocha, 510, 220)
        e.Graphics.DrawString("Fecha Remisión: ", Formato_Etiqueta_8, Brocha, 650, 205)
        If IsDBNull(FilaEntradaAlmacen("FECHAREMISION")) = False Then
            e.Graphics.DrawString(CStr(FilaEntradaAlmacen("FECHAREMISION")), Formato_Etiqueta_8R, Brocha, 660, 220)
        End If
        e.Graphics.DrawLine(Lapiz, 40, 264, 800, 264)    'Horizontal 5
        e.Graphics.DrawLine(Lapiz, 40, 50, 40, 700)   'Vertical
        e.Graphics.DrawLine(Lapiz, 800, 50, 800, 700) 'Vertical


        '
        'Impresión de Ítems de Entrada de Almacén
        '
        e.Graphics.DrawLine(Lapiz, 40, 270, 800, 270)    'Horizontal 5
        e.Graphics.DrawString("Ítem", Formato_Etiqueta_7, Brocha, 40 + InicioCentradoTexto("Ítem", Formato_Etiqueta_7, 30, e), 280)
        e.Graphics.DrawString("Unidad", Formato_Etiqueta_7, Brocha, 70 + InicioCentradoTexto("Unidad", Formato_Etiqueta_7, 50, e), 280)
        e.Graphics.DrawString("Código", Formato_Etiqueta_7, Brocha, 120 + InicioCentradoTexto("Código", Formato_Etiqueta_7, 50, e), 280)
        e.Graphics.DrawString("Descripción", Formato_Etiqueta_7, Brocha, 170 + InicioCentradoTexto("Descripción", Formato_Etiqueta_7, 530, e), 280)
        e.Graphics.DrawString("Cantidad", Formato_Etiqueta_7, Brocha, 700 + InicioCentradoTexto("Cantidad", Formato_Etiqueta_7, 50, e), 280)
        e.Graphics.DrawLine(Lapiz, 40, 270, 40, 900)   'Vertical 1 
        e.Graphics.DrawLine(Lapiz, 70, 270, 70, 900)   'Vertical 2
        e.Graphics.DrawLine(Lapiz, 120, 270, 120, 900) 'Vertical 3
        e.Graphics.DrawLine(Lapiz, 170, 270, 170, 900) 'Vertical 4
        e.Graphics.DrawLine(Lapiz, 700, 270, 700, 900) 'Vertical 5
        e.Graphics.DrawLine(Lapiz, 750, 270, 750, 900) 'Vertical 6
        e.Graphics.DrawLine(Lapiz, 800, 270, 800, 900) 'Vertical 7

        If TipoEntrada = "C" Then
            e.Graphics.DrawString("Cant OC", Formato_Etiqueta_7, Brocha, 750 + InicioCentradoTexto("Cant OC", Formato_Etiqueta_7, 50, e), 280)
        Else
            e.Graphics.DrawString("Pedido", Formato_Etiqueta_7, Brocha, 750 + InicioCentradoTexto("Pedido", Formato_Etiqueta_7, 50, e), 280)
        End If

        e.Graphics.DrawLine(Lapiz, 40, 300, 800, 300)  'Horizontal

        Dim TotalGrilla As Integer = 0
        Dim strEquipos As String = ""
        Dim fuente_IEA As Font = Formato_Etiqueta_8R
        Dim blackPen As New Pen(Color.Gray, 1)
        blackPen.DashPattern = New Single() {3, 3, 3, 3}
        Const InicioYdeItemEA As Integer = 300
        Const EspacioVertical As Integer = 20
        Const espacioTotal As Integer = 600
        Const cantidadRenglones As Integer = espacioTotal / EspacioVertical
        Const separacionTextoFilas As Integer = 3

        For i = ContadorItemsEntrada To Dt_EntradaAlmacen.Rows.Count - 1

            Dim FilaEA As DataRow
            FilaEA = Dt_EntradaAlmacen.Rows(i)
            Dim Cadena_Total1 As ArrayList

            ' Revisar si viene una cadena de la página anterior
            If ConteoEquipos > -1 Then
                Try
                    Cadena_Total1 = New ArrayList
                    Cadena_Total1 = VectorEquipos
                    For k = ConteoEquipos To Cadena_Total1.Count - 1
                        If Trim(Cadena_Total1(k)) = "" Then
                            Cadena_Total1.RemoveAt(k)
                        End If
                    Next

                    For k = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(k), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                        TotalGrilla = TotalGrilla + 1

                        If TotalGrilla >= cantidadRenglones Then
                            ConteoEquipos = k
                            VectorEquipos = Cadena_Total1
                            Exit For
                        End If

                    Next

                    e.Graphics.DrawLine(blackPen, 40, InicioYdeItemEA + (TotalGrilla * EspacioVertical), 800, InicioYdeItemEA + (TotalGrilla * EspacioVertical))  'Horizontal FIN DE HILERA

                Catch ex As Exception
                    Select Case Trim(strEquipos).ToString.Length
                        Case Is < 100
                            e.Graphics.DrawString(strEquipos, fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 2
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(strEquipos, 1, 50), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            e.Graphics.DrawString(Mid(strEquipos, 51, 50), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            Exit Select
                    End Select
                End Try
                If TotalGrilla >= cantidadRenglones Then
                    Exit For
                End If
                VectorEquipos.Clear()
                ConteoEquipos = -1
            End If


            Dim Cadenas1 As New ArrayList
            Cadenas1.Add(Trim(FilaEA("DESCRIPCION")))
            Cadena_Total1 = New ArrayList
            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, fuente_IEA, 520, e)
            For k = 0 To Cadena_Total1.Count - 1
                If Trim(Cadena_Total1(k)) = "" Then
                    Cadena_Total1.RemoveAt(k)
                End If
            Next

            If cantidadRenglones - (TotalGrilla + Cadena_Total1.Count) >= 1 Then
                e.Graphics.DrawString(FilaEA("IDITEMENTRADAALMACEN"), fuente_IEA, Brocha, 40 + InicioCentradoTexto(FilaEA("IDITEMENTRADAALMACEN"), fuente_IEA, 30, e), InicioYdeItemEA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                e.Graphics.DrawString(FilaEA("ABREVIATURA"), fuente_IEA, Brocha, 70 + InicioCentradoTexto(FilaEA("ABREVIATURA"), fuente_IEA, 50, e), InicioYdeItemEA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                e.Graphics.DrawString(FilaEA("IDARTICULO"), fuente_IEA, Brocha, 120 + InicioCentradoTexto(FilaEA("IDARTICULO"), fuente_IEA, 50, e), InicioYdeItemEA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                e.Graphics.DrawString(FilaEA("CANTIDAD"), fuente_IEA, Brocha, 700 + InicioCentradoTexto(FilaEA("CANTIDAD"), fuente_IEA, 50, e), InicioYdeItemEA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)

                If TipoEntrada = "C" Then
                    e.Graphics.DrawString(FilaEA("COMPRADO"), fuente_IEA, Brocha, 750 + InicioCentradoTexto(FilaEA("COMPRADO"), fuente_IEA, 50, e), InicioYdeItemEA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                Else
                    e.Graphics.DrawString(FilaEA("SOLICITADA"), fuente_IEA, Brocha, 750 + InicioCentradoTexto(FilaEA("SOLICITADA"), fuente_IEA, 50, e), InicioYdeItemEA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                End If

                Try
                    For k = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(k), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                        TotalGrilla = TotalGrilla + 1
                    Next
                Catch ex As Exception
                    Select Case Trim(FilaEA("NOMBREDESCRIPTIVO")).ToString.Length
                        Case Is < 100
                            e.Graphics.DrawString(FilaEA("NOMBREDESCRIPTIVO"), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 2
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(FilaEA("NOMBREDESCRIPTIVO"), 1, 50), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            e.Graphics.DrawString(Mid(FilaEA("NOMBREDESCRIPTIVO"), 51, 50), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            Exit Select
                    End Select
                End Try
            Else
                '***EXEDE EL TAMAÑO DE LA GRILLA, SALTAR HOJA***
                e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_7, Brocha, 350, InicioYdeItemEA + (EspacioVertical * (TotalGrilla)) + separacionTextoFilas)
                Exit For
            End If

            'si tiene equipos agregar la cadena con equipos
            If EquiposAsociados = True Then
                Dim dsEquiposImpresion As New DataSet
                'extraer los equipos
                If TipoEntrada = "T" Then 'si es un traslado
                    dsEquiposImpresion = bddatos.ModificarEntradasSalidas(21, 0, Dt_EntradaAlmacen.Rows(i)("IDARTICULO"), 0, Date.Now, 0, Date.Now, "", 0, IDENTRADAALMACEN)
                ElseIf TipoEntrada = "S" Then ' si es una entrada por custodia
                    dsEquiposImpresion = bddatos.ModificarCustodias(6, 0, Dt_EntradaAlmacen.Rows(i)("IDARTICULO"), 0, 0, 0, IDENTRADAALMACEN)
                End If
                Dim strConsecutivos As String = ""
                Dim k As Integer = 0

                strConsecutivos = dsEquiposImpresion.Tables(0).Rows(0)("CODIGO").ToString()

                If dsEquiposImpresion.Tables(0).Rows.Count > 1 Then
                    For k = 1 To dsEquiposImpresion.Tables(0).Rows.Count - 1
                        strConsecutivos += ", " + dsEquiposImpresion.Tables(0).Rows(k)("CODIGO").ToString()
                    Next
                End If

                strEquipos = "Códigos: " + strConsecutivos

                Try
                    Cadenas1.Clear()
                    Cadenas1.Add(Trim(strEquipos))
                    Cadena_Total1 = New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, fuente_IEA, 520, e)
                    For k = 0 To Cadena_Total1.Count - 1
                        If Trim(Cadena_Total1(k)) = "" Then
                            Cadena_Total1.RemoveAt(k)
                        End If
                    Next
                    '***SI EXEDE EL TAMAÑO DE LA GRILLA SALTAR HOJA***
                    If TotalGrilla >= cantidadRenglones Then
                        ConteoEquipos = 0
                        VectorEquipos = Cadena_Total1
                        Exit For
                    End If
                    '******
                    e.Graphics.DrawLine(blackPen, 170, InicioYdeItemEA + (TotalGrilla * EspacioVertical), 700, InicioYdeItemEA + (TotalGrilla * EspacioVertical))  'Horizontal

                    For k = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(k), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                        TotalGrilla = TotalGrilla + 1
                        '***SI EXEDE EL TAMAÑO DE LA GRILLA SALTAR HOJA***
                        If TotalGrilla >= cantidadRenglones Then
                            ConteoEquipos = k
                            VectorEquipos = Cadena_Total1
                            Exit For
                        End If
                        '******'
                    Next

                Catch ex As Exception
                    Select Case Trim(strEquipos).ToString.Length
                        Case Is < 100
                            e.Graphics.DrawString(strEquipos, fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 2
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(strEquipos, 1, 50), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            e.Graphics.DrawString(Mid(strEquipos, 51, 50), fuente_IEA, Brocha, 175, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            Exit Select
                    End Select
                End Try
            End If

            e.Graphics.DrawLine(blackPen, 40, InicioYdeItemEA + (TotalGrilla * EspacioVertical), 800, InicioYdeItemEA + (TotalGrilla * EspacioVertical))  'Horizontal FIN DE HILERA

            ContadorItemsEntrada = ContadorItemsEntrada + 1

            If ENTRADACANCELADA = True And CANCELACIONPARCIAL = True Then
                e.Graphics.DrawString("Motivo: " + FilaEA("OBSERVACIONCANCELACION"), fuente_IEA, Brocha, 185, InicioYdeItemEA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                TotalGrilla = TotalGrilla + 2
            End If

            If TotalGrilla >= cantidadRenglones Then
                Exit For
            End If
        Next
        e.Graphics.DrawLine(Lapiz, 40, 900, 800, 900)  'Horizontal


        e.Graphics.DrawLine(Lapiz, 40, 910, 800, 910)    'Horizontal 1
        Dim observa As String

        If ENTRADACANCELADA = True Then
            observa = Trim(FilaEntradaAlmacen("OBSERVACIONCANCELACION"))
        Else
            observa = Trim(FilaEntradaAlmacen("OBSERVACION"))
        End If

        Select Case TipoEntrada
            Case "D", "H", "S"
                observa += " Entrega a bodega: " & FilaEntradaAlmacen("ENTREGAABODEGA") & "."
        End Select

        If observa.Length > 100 Then
            Dim observa1 As String = Trim(Mid(observa, 1, 100))
            Dim pos As Integer
            pos = observa1.LastIndexOf(" ")
            observa1 = Trim(Mid(observa, 1, pos))
            e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_8, Brocha, 40, 910)
            observa = Trim(Mid(observa, pos + 1, observa.Length))
            e.Graphics.DrawString(observa, Formato_Etiqueta_8, Brocha, 40, 925)
        Else
            e.Graphics.DrawString("Observación: " + Mid(observa, 1, 100), Formato_Etiqueta_8, Brocha, 40, 910)
        End If

        e.Graphics.DrawLine(Lapiz, 40, 940, 800, 940)    'Horizontal 2
        e.Graphics.DrawLine(Lapiz, 40, 1030, 800, 1030)  'Horizontal 3

        e.Graphics.DrawLine(Lapiz, 40, 910, 40, 1030)    'Vertical 1

        e.Graphics.DrawLine(Lapiz, 290, 940, 290, 1030)  'Vertical 1
        e.Graphics.DrawLine(Lapiz, 550, 940, 550, 1030)  'Vertical 1
        e.Graphics.DrawLine(Lapiz, 800, 910, 800, 1030)  'Vertical 2

        e.Graphics.DrawLine(Lapiz, 40, 1000, 800, 1000)  'Horizontal 3

        e.Graphics.DrawString(FilaEntradaAlmacen("PERSONARECIBIO"), Formato_Etiqueta_7, Brocha, 60, 1005)
        e.Graphics.DrawString("           RECIBIDO POR", Formato_Etiqueta_8, Brocha, 60, 1015)

        e.Graphics.DrawString(FilaEntradaAlmacen("PERSONAVERIFICO"), Formato_Etiqueta_7, Brocha, 320, 1005)
        e.Graphics.DrawString("             VERIFICADO POR", Formato_Etiqueta_8, Brocha, 320, 1015)

        e.Graphics.DrawString(FilaEntradaAlmacen("PERSONAAPROBO"), Formato_Etiqueta_7, Brocha, 570, 1005)
        e.Graphics.DrawString("             APROBADO POR", Formato_Etiqueta_8, Brocha, 570, 1015)


        PaginasImpresasEntrada = PaginasImpresasEntrada + 1

        Dim TextoPiePagina As String = ""
        If ImpresionEntrada Then
            TextoPiePagina = "Página " & PaginasImpresasEntrada & " de " & TotalPaginasEntrada
        Else
            TextoPiePagina = "Página " & PaginasImpresasEntrada
        End If
        e.Graphics.DrawString(TextoPiePagina, Formato_Etiqueta_6, Brocha, 40 + InicioCentradoTexto(TextoPiePagina, Formato_Etiqueta_6, 760, e), 1050)

        If ContadorItemsEntrada = Dt_EntradaAlmacen.Rows.Count Then
            If TotalGrilla >= cantidadRenglones Then
                ConteoEquipos = 0
                VectorEquipos.Clear()
            Else
                e.Graphics.DrawString("|--------------------| Última Fila |--------------------|", Formato_Etiqueta_7, Brocha, 350, InicioYdeItemEA + (EspacioVertical * (TotalGrilla)) + separacionTextoFilas)
            End If
            If ImpresionEntrada Then 'And ContadorPaginasEntrada = TotalPaginasEntrada
                GuardarImpresionEntrada() 'Si ya imprimió entra y cambia el valor de impresa en la tabla ENTRADAALMACEN
            Else
                TotalPaginasEntrada = PaginasImpresasEntrada
            End If
            ContadorItemsEntrada = 0
            PaginasImpresasEntrada = 0
            ImpresionEntrada = True
            e.HasMorePages = False
        Else
            e.HasMorePages = True
        End If

    End Sub


    Private Sub GuardarImpresionEntrada()
        'Guarda información de la impresión , y modifica el campo de impreso en la salida de almacén
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure

            If ENTRADACANCELADA = False Then
                Comando.Parameters.AddWithValue("@TIPO", 3)
            Else
                If CANCELACIONPARCIAL Then
                    Comando.Parameters.AddWithValue("@TIPO", 4)
                Else
                    Comando.Parameters.AddWithValue("@TIPO", 5)
                End If
            End If

            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IDENTRADAALMACEN)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "66 - ICS-GRAL-F-24 SALIDA DE MATERIALES"

    Dim WithEvents DocImp_SalidaDeMateriales As New PrintDocument 'Documento a imprimir
    Public CargarDatasetSalidaAlmacen As Boolean = True
    Public IDSALIDAALMACEN As Integer = -1
    Public SALIDACANCELADA As Boolean = False
    Dim FilaSalidaAlmacen As DataRow
    Dim ContadorItemsSalida As Integer = 0
    Dim TotalPaginasSalida As Integer = 0
    Dim Dt_SalidaAlamacen As DataTable
    Dim ImpresionSalida As Boolean = False
    Private ContadorPaginasSalida As Integer = 0
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()

    Dim EquiposAsociados As Boolean = False
    Dim ConteoEquipos As Integer = -1
    Dim VectorEquipos As ArrayList

    Private Sub DocImpSalidaDeMateriales(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_SalidaDeMateriales.PrintPage
        If CargarDatasetSalidaAlmacen = True Then
            Dim Cadena_Consulta As String
            If SALIDACANCELADA = False Then
                Cadena_Consulta = "SELECT * FROM dbo.ImpresionSalidaAlmacen(0," + IDSALIDAALMACEN.ToString + ") AS ImpresionSalidaAlmacen"
            Else
                If CANCELACIONPARCIAL Then
                    Cadena_Consulta = "SELECT * FROM dbo.ImpresionSalidaAlmacenCancelada(1," + IDSALIDAALMACEN.ToString + ") AS ImpresionSalidaAlmacen"
                Else
                    Cadena_Consulta = "SELECT * FROM dbo.ImpresionSalidaAlmacenCancelada(0," + IDSALIDAALMACEN.ToString + ") AS ImpresionSalidaAlmacen"
                End If
            End If

            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_SalidaAlamacen = New DataTable
            Adaptador.Fill(Dt_SalidaAlamacen)
            Consulta.Connection.Close()
            FilaSalidaAlmacen = Dt_SalidaAlamacen.Rows(0)
            CargarDatasetSalidaAlmacen = False
            'Revisar si se van a incluir equipos
            Dim dsEquipos As New DataSet
            If Dt_SalidaAlamacen.Rows(0)("TIPOSALIDA").ToString.Trim = "Traslado de Bodega" Then
                'Consultar equipos
                dsEquipos = bddatos.ModificarEntradasSalidas(18, 0, 0, 0, Date.Now, 0, Date.Now, "", Dt_SalidaAlamacen.Rows(0)("REMISION"), 0)
                If dsEquipos.Tables(0).Rows(0)("CONTEO") > 0 Then
                    'Cargar equipos asociados a esta remisión.
                    EquiposAsociados = True
                End If
            ElseIf Dt_SalidaAlamacen.Rows(0)("TIPOSALIDA").ToString.Trim = "Custodia de Equipo" Then
                'Consultar equipos
                dsEquipos = bddatos.ModificarCustodias(4, 0, 0, 0, 0, IDSALIDAALMACEN, 0)
                If dsEquipos.Tables(0).Rows(0)("CONTEO") > 0 Then
                    'Cargar equipos asociados a esta remisión.
                    EquiposAsociados = True
                End If
            End If
        End If

        If SALIDACANCELADA = True Then
            e.Graphics.RotateTransform(-45.0F)
            e.Graphics.DrawString("CANCELADO", Formato_Etiqueta_80, Brushes.Silver, -500, 600)
            e.Graphics.RotateTransform(45.0F)
        End If

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaSalidaAlmacen("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Trim(FilaSalidaAlmacen("BODEGA"))) Then
            If MsgBox("¿Desea imprimir la requisición con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' Logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Brocha.Color = Color.Black

        Select Case LogoEmpresa
            Case 0 'ISMOCOL S.A.
                e.Graphics.DrawImage(imagen, 46, 56, 75, 60)
                e.Graphics.DrawLine(Lapiz, 124, 50, 124, 124) 'Vertical 2
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 46, 56, 75, 60)
                e.Graphics.DrawLine(Lapiz, 124, 50, 124, 124) 'Vertical 2
            Case 2 'ZAMORANA
                e.Graphics.DrawImage(zamorana, 45, 60, 213, 57)
                e.Graphics.DrawLine(Lapiz, 270, 50, 270, 124) 'Vertical 2
        End Select


        e.Graphics.DrawLine(Lapiz, 40, 50, 800, 50)   'Horizontal 1
        e.Graphics.DrawLine(Lapiz, 40, 124, 800, 124) 'Horizontal 2
        e.Graphics.DrawLine(Lapiz, 700, 86, 800, 86)  'Horizontal 3

        e.Graphics.DrawLine(Lapiz, 40, 50, 40, 124)   'Vertical 1
        e.Graphics.DrawLine(Lapiz, 700, 50, 700, 124) 'Vertical 3
        e.Graphics.DrawLine(Lapiz, 800, 50, 800, 124) 'Vertical 4

        If SALIDACANCELADA Then
            e.Graphics.DrawString("CANCELACION SALIDA DE ALMACÉN", Formato_Etiqueta_14, Brocha, 220, 60)
        Else
            e.Graphics.DrawString("SALIDA DE ALMACÉN", Formato_Etiqueta_14, Brocha, 300, 60)
        End If

        e.Graphics.DrawString(FilaSalidaAlmacen("TIPOSALIDA"), Formato_Etiqueta_7, Brocha, 350, 80)

        Select Case LogoEmpresa
            Case 0 ' ISMOCOL S.A.
                If SALIDACANCELADA Then
                    e.Graphics.DrawString("ICS-GRAL-F-047", Formato_Etiqueta_7, Brocha, 710, 70)
                    e.Graphics.DrawString("Revisión No.1", Formato_Etiqueta_7, Brocha, 715, 110)
                Else
                    e.Graphics.DrawString("ICS-GRAL-F-24", Formato_Etiqueta_7, Brocha, 720, 70)
                    e.Graphics.DrawString("Revisión No.2", Formato_Etiqueta_7, Brocha, 720, 110)
                End If
            Case 1 'CSI
            Case 2 'ZAMORANA
                e.Graphics.DrawString("ZMS-GRAL-F-010", Formato_Etiqueta_7, Brocha, 708, 70)
                e.Graphics.DrawString("Revisión No.0", Formato_Etiqueta_7, Brocha, 715, 110)
        End Select

        e.Graphics.DrawString("No. " + CStr(FilaSalidaAlmacen("CONSECUTIVO")), Formato_Etiqueta_14, Brocha, 300, 130)
        e.Graphics.DrawString("Fecha Impresión:", Formato_Etiqueta_8, Brocha, 600, 130)
        e.Graphics.DrawString(StrConv(Date.Now.ToLongDateString, VbStrConv.ProperCase), Formato_Etiqueta_8R, Brocha, 610, 145)

        e.Graphics.DrawLine(Lapiz, 40, 164, 800, 164) 'Horizontal 4
        If FilaSalidaAlmacen("TIPOSALIDA").ToString.Trim = "Traslado de Bodega" Then
            e.Graphics.DrawString("Bodega Origen", Formato_Etiqueta_8, Brocha, 40, 170)
            e.Graphics.DrawString(FilaSalidaAlmacen("BODEGA"), Formato_Etiqueta_8R, Brocha, 50, 185)
            e.Graphics.DrawString("Bodega Destino", Formato_Etiqueta_8, Brocha, 40, 205)
            e.Graphics.DrawString(FilaSalidaAlmacen("BODDESTINO"), Formato_Etiqueta_8R, Brocha, 50, 220)
        Else
            e.Graphics.DrawString("Bodega ", Formato_Etiqueta_8, Brocha, 40, 170)
            e.Graphics.DrawString(FilaSalidaAlmacen("BODEGA"), Formato_Etiqueta_8R, Brocha, 50, 185)
        End If
        e.Graphics.DrawString("Orden de Compra No. ", Formato_Etiqueta_8, Brocha, 230, 170)
        e.Graphics.DrawString(FilaSalidaAlmacen("ORDENCOMPRA"), Formato_Etiqueta_8R, Brocha, 240, 185)
        e.Graphics.DrawString("Requisición No: ", Formato_Etiqueta_8, Brocha, 430, 170)
        e.Graphics.DrawString(FilaSalidaAlmacen("REQUISICION"), Formato_Etiqueta_8R, Brocha, 440, 185)
        e.Graphics.DrawString("Fecha Despacho: ", Formato_Etiqueta_8, Brocha, 600, 170)
        e.Graphics.DrawString(StrConv(CDate(FilaSalidaAlmacen("FECHADESPACHO")).ToLongDateString, VbStrConv.ProperCase), Formato_Etiqueta_8R, Brocha, 610, 185)

        e.Graphics.DrawLine(Lapiz, 40, 200, 800, 200) 'Horizontal 5
        e.Graphics.DrawString("No. Remisión:", Formato_Etiqueta_8, Brocha, 500, 205)
        e.Graphics.DrawString(FilaSalidaAlmacen("REMISION"), Formato_Etiqueta_8R, Brocha, 500, 225)

        e.Graphics.DrawString("Equipo Asociado:", Formato_Etiqueta_8, Brocha, 600, 205)
        e.Graphics.DrawString(IIf(IsDBNull(FilaSalidaAlmacen("EQUIPO")), "", FilaSalidaAlmacen("EQUIPO")), Formato_Etiqueta_8R, Brocha, 600, 225)

        e.Graphics.DrawLine(Lapiz, 40, 240, 800, 240) 'Horizontal 5
        e.Graphics.DrawString("Destino: " + FilaSalidaAlmacen("DESTINO"), Formato_Etiqueta_7R, Brocha, 40, 250)

        e.Graphics.DrawLine(Lapiz, 40, 50, 40, 300)   'Vertical
        e.Graphics.DrawLine(Lapiz, 800, 50, 800, 300) 'Vertical
        e.Graphics.DrawLine(Lapiz, 40, 264, 800, 264) 'Horizontal 5

        '
        'Impresión de Ítems de Salida de Almacén
        '
        e.Graphics.DrawLine(Lapiz, 40, 270, 800, 270)  'Horizontal 5
        e.Graphics.DrawString("Item", Formato_Etiqueta_7, Brocha, 40 + InicioCentradoTexto("Item", Formato_Etiqueta_7, 30, e), 280)
        e.Graphics.DrawString("Unidad", Formato_Etiqueta_7, Brocha, 70 + InicioCentradoTexto("Unidad", Formato_Etiqueta_7, 50, e), 280)
        e.Graphics.DrawString("Código", Formato_Etiqueta_7, Brocha, 120 + InicioCentradoTexto("Código", Formato_Etiqueta_7, 50, e), 280)
        e.Graphics.DrawString("Descripción", Formato_Etiqueta_7, Brocha, 170 + InicioCentradoTexto("Descripción", Formato_Etiqueta_7, 580, e), 280)
        e.Graphics.DrawString("Cantidad", Formato_Etiqueta_7, Brocha, 750 + InicioCentradoTexto("Cantidad", Formato_Etiqueta_7, 50, e), 280)
        e.Graphics.DrawLine(Lapiz, 40, 270, 40, 900)   'Vertical 1
        e.Graphics.DrawLine(Lapiz, 70, 270, 70, 900)   'Vertical 2
        e.Graphics.DrawLine(Lapiz, 120, 270, 120, 900) 'Vertical 3
        e.Graphics.DrawLine(Lapiz, 170, 270, 170, 900) 'Vertical 4
        e.Graphics.DrawLine(Lapiz, 750, 270, 750, 900) 'Vertical 6
        e.Graphics.DrawLine(Lapiz, 800, 270, 800, 900) 'Vertical 7

        e.Graphics.DrawLine(Lapiz, 40, 300, 800, 300)  'Horizontal

        Dim TotalGrilla As Integer = 0
        Dim strEquipos As String = ""
        Dim fuente_ISA As Font = Formato_Etiqueta_8R
        Dim blackPen As New Pen(Color.Gray, 1)
        blackPen.DashPattern = New Single() {3, 3, 3, 3}
        Const InicioYdeItemSA As Integer = 300
        Const EspacioVertical As Integer = 20
        Const espacioTotal As Integer = 600
        Const cantidadRenglones As Integer = espacioTotal / EspacioVertical
        Const separacionTextoFilas As Integer = 3
        Dim contador As String = ""   ''Agregar contador de Km/H /Pag
        For i = ContadorItemsSalida To Dt_SalidaAlamacen.Rows.Count - 1
            Dim FilaSA As DataRow
            FilaSA = Dt_SalidaAlamacen.Rows(i)
            Dim Cadena_Total1 As ArrayList

            ' Revisar si viene una cadena de la página anterior.
            If ConteoEquipos > -1 Then
                Try
                    Cadena_Total1 = New ArrayList
                    Cadena_Total1 = VectorEquipos
                    For k = ConteoEquipos To Cadena_Total1.Count - 1
                        If Trim(Cadena_Total1(k)) = "" Then
                            Cadena_Total1.RemoveAt(k)
                        End If
                    Next

                    For k = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(k), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                        TotalGrilla = TotalGrilla + 1

                        If TotalGrilla >= cantidadRenglones AndAlso k < Cadena_Total1.Count - 1 Then
                            ConteoEquipos = k
                            VectorEquipos = Cadena_Total1
                            Exit For
                        End If
                    Next

                    e.Graphics.DrawLine(blackPen, 40, InicioYdeItemSA + (TotalGrilla * EspacioVertical), 800, InicioYdeItemSA + (TotalGrilla * EspacioVertical))  'Horizontal FIN DE HILERA

                Catch ex As Exception
                    Select Case Trim(strEquipos).ToString.Length
                        Case Is < 100
                            e.Graphics.DrawString(strEquipos, fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 2
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(strEquipos, 1, 50), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            e.Graphics.DrawString(Mid(strEquipos, 51, 50), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            Exit Select
                    End Select
                End Try
                If TotalGrilla >= cantidadRenglones Then
                    Exit For
                End If
                VectorEquipos.Clear()
                ConteoEquipos = -1
            End If

            Dim Cadenas1 As New ArrayList
            Cadenas1.Add(Trim(FilaSA("NOMBREARTICULO")))
            Cadena_Total1 = New ArrayList
            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, fuente_ISA, 570, e)
            For k = 0 To Cadena_Total1.Count - 1
                If Trim(Cadena_Total1(k)) = "" Then
                    Cadena_Total1.RemoveAt(k)
                End If
            Next

            If cantidadRenglones - (TotalGrilla + Cadena_Total1.Count) >= 1 Then
                e.Graphics.DrawString(FilaSA("ITEM"), fuente_ISA, Brocha, 40 + InicioCentradoTexto(FilaSA("ITEM"), fuente_ISA, 30, e), InicioYdeItemSA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                e.Graphics.DrawString(FilaSA("UNIDAD"), fuente_ISA, Brocha, 70 + InicioCentradoTexto(FilaSA("UNIDAD"), fuente_ISA, 50, e), InicioYdeItemSA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                e.Graphics.DrawString(FilaSA("IDARTICULO"), fuente_ISA, Brocha, 120 + InicioCentradoTexto(FilaSA("IDARTICULO"), fuente_ISA, 50, e), InicioYdeItemSA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)
                e.Graphics.DrawString(FilaSA("CANTIDAD"), fuente_ISA, Brocha, 750 + InicioCentradoTexto(FilaSA("CANTIDAD"), fuente_ISA, 50, e), InicioYdeItemSA + (EspacioVertical * TotalGrilla) + separacionTextoFilas)

                Try
                    For k = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(k), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                        TotalGrilla = TotalGrilla + 1
                    Next
                Catch ex As Exception
                    Select Case Trim(FilaSA("NOMBREARTICULO")).ToString.Length
                        Case Is < 100
                            e.Graphics.DrawString(FilaSA("NOMBREARTICULO"), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 2
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(FilaSA("NOMBREARTICULO"), 1, 50), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            e.Graphics.DrawString(Mid(FilaSA("NOMBREARTICULO"), 51, 50), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            Exit Select
                    End Select
                End Try
            Else
                '***EXCEDE EL TAMAÑO DE LA REJILLA, SALTAR HOJA***
                e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_7, Brocha, 350, InicioYdeItemSA + (EspacioVertical * (TotalGrilla)) + separacionTextoFilas)
                Exit For
            End If

            'Si tiene equipos, agregar la cadena con equipos
            If EquiposAsociados = True Then
                Dim dsEquiposImpresion As New DataSet
                'extraer los equipos
                If Dt_SalidaAlamacen.Rows(0)("TIPOSALIDA").ToString.Trim = "Traslado de Bodega" Then 'si es un traslado
                    dsEquiposImpresion = bddatos.ModificarEntradasSalidas(19, 0, Dt_SalidaAlamacen.Rows(i)("IDARTICULO"), 0, Date.Now, 0, Date.Now, "", Dt_SalidaAlamacen.Rows(i)("REMISION"), 0)
                ElseIf Dt_SalidaAlamacen.Rows(0)("TIPOSALIDA").ToString.Trim = "Custodia de Equipo" Then ' si es una salida por custodia
                    dsEquiposImpresion = bddatos.ModificarCustodias(5, 0, Dt_SalidaAlamacen.Rows(i)("IDARTICULO"), 0, 0, IDSALIDAALMACEN, 0) 'dtSalidaAlamacen.Rows(i)("REMISION"), 0)
                End If
                Dim strConsecutivos As String = ""
                Dim k As Integer = 0

                strConsecutivos = dsEquiposImpresion.Tables(0).Rows(0)("CODIGO").ToString()

                If dsEquiposImpresion.Tables(0).Rows.Count > 1 Then
                    For k = 1 To dsEquiposImpresion.Tables(0).Rows.Count - 1
                        strConsecutivos += ", " + dsEquiposImpresion.Tables(0).Rows(k)("CODIGO").ToString()
                    Next
                End If

                strEquipos = "Códigos: " + strConsecutivos

                Try
                    Cadenas1.Clear()
                    Cadenas1.Add(Trim(strEquipos))
                    Cadena_Total1 = New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, fuente_ISA, 570, e)
                    For k = 0 To Cadena_Total1.Count - 1
                        If Trim(Cadena_Total1(k)) = "" Then
                            Cadena_Total1.RemoveAt(k)
                        End If
                    Next
                    '***SI EXCEDE EL TAMAÑO DE LA REJILLA, SALTAR HOJA***
                    If TotalGrilla >= cantidadRenglones Then
                        ConteoEquipos = 0
                        VectorEquipos = Cadena_Total1
                        Exit For
                    End If
                    '******
                    e.Graphics.DrawLine(blackPen, 170, InicioYdeItemSA + (TotalGrilla * EspacioVertical), 750, InicioYdeItemSA + (TotalGrilla * EspacioVertical)) 'Horizontal

                    For k = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(k), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                        TotalGrilla = TotalGrilla + 1
                        '***SI EXCEDE EL TAMAÑO DE LA REJILLA, SALTAR HOJA***
                        If TotalGrilla >= cantidadRenglones AndAlso k < Cadena_Total1.Count - 1 Then
                            ConteoEquipos = k
                            VectorEquipos = Cadena_Total1
                            Exit For
                        End If
                        '******'
                    Next
                Catch ex As Exception
                    Select Case Trim(strEquipos).ToString.Length
                        Case Is < 100
                            e.Graphics.DrawString(strEquipos, fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 2
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(strEquipos, 1, 50), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            e.Graphics.DrawString(Mid(strEquipos, 51, 50), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                            TotalGrilla = TotalGrilla + 1
                            Exit Select
                    End Select
                End Try
            End If

            e.Graphics.DrawLine(blackPen, 40, InicioYdeItemSA + (TotalGrilla * EspacioVertical), 800, InicioYdeItemSA + (TotalGrilla * EspacioVertical))  'Horizontal FIN DE HILERA

            ContadorItemsSalida = ContadorItemsSalida + 1

            If SALIDACANCELADA = True And CANCELACIONPARCIAL = True Then
                e.Graphics.DrawString("Motivo: " + FilaSA("OBSERVACIONCANCELAITEM"), fuente_ISA, Brocha, 175, InicioYdeItemSA + (TotalGrilla * EspacioVertical) + separacionTextoFilas)
                TotalGrilla = TotalGrilla + 2
            End If

            If TotalGrilla >= cantidadRenglones Then
                Exit For
            End If
        Next
        e.Graphics.DrawLine(Lapiz, 40, 900, 800, 900) 'Horizontal

        e.Graphics.DrawLine(Lapiz, 40, 910, 800, 910) 'Horizontal 1
        If IsDBNull(FilaSalidaAlmacen("CONTADOR")) Then  ''Agregar el registro de contador en la observacion. 
            contador = ""
        Else
            contador = " " + "CONTADOR: " + " " + Trim(FilaSalidaAlmacen("CONTADOR").ToString)
        End If

        Dim observa As String = ""
        If SALIDACANCELADA = True Then
            If CANCELACIONPARCIAL = True Then
                observa = Trim(FilaSalidaAlmacen("OBSERVACIONES"))
            Else
                observa = Trim(FilaSalidaAlmacen("OBSERVACIONCANCELAITEM"))
            End If
        Else
            observa = Trim(FilaSalidaAlmacen("OBSERVACIONES")) + contador
        End If

        If observa.Length > 100 Then
            Dim observa1 As String = Trim(Mid(observa, 1, 100))
            Dim pos As Integer
            pos = observa1.LastIndexOf(" ")
            observa1 = Trim(Mid(observa, 1, pos))
            e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_8, Brocha, 40, 910)
            observa = Trim(Mid(observa, pos + 1, observa.Length))
            e.Graphics.DrawString(observa, Formato_Etiqueta_8, Brocha, 40, 925)
        Else
            e.Graphics.DrawString("Observación: " + Mid(observa, 1, 100), Formato_Etiqueta_8, Brocha, 40, 910)
        End If

        e.Graphics.DrawLine(Lapiz, 40, 940, 800, 940)    'Horizontal 2
        e.Graphics.DrawLine(Lapiz, 40, 1030, 800, 1030)  'Horizontal 3

        e.Graphics.DrawLine(Lapiz, 40, 910, 40, 1030)    'Vertical 1

        e.Graphics.DrawLine(Lapiz, 290, 940, 290, 1030)  'Vertical 1
        e.Graphics.DrawLine(Lapiz, 550, 940, 550, 1030)  'Vertical 1
        e.Graphics.DrawLine(Lapiz, 800, 910, 800, 1030)  'Vertical 2

        e.Graphics.DrawLine(Lapiz, 40, 1000, 800, 1000)
        e.Graphics.DrawString(FilaSalidaAlmacen("PERSONADESPACHA"), Formato_Etiqueta_8, Brocha, 60, 1005)
        e.Graphics.DrawString("           DESPACHADO POR", Formato_Etiqueta_8, Brocha, 60, 1015)
        e.Graphics.DrawString(FilaSalidaAlmacen("PERSONAAUTORIZA"), Formato_Etiqueta_8, Brocha, 320, 1005)
        e.Graphics.DrawString("          AUTORIZADO POR", Formato_Etiqueta_8, Brocha, 320, 1015)
        e.Graphics.DrawString(FilaSalidaAlmacen("PERSONARECIBE"), Formato_Etiqueta_8, Brocha, 570, 1005)
        e.Graphics.DrawString("          RECIBIDO POR", Formato_Etiqueta_8, Brocha, 570, 1015)

        ContadorPaginasSalida = ContadorPaginasSalida + 1

        Dim TextoPiePagina As String = ""
        If ImpresionSalida Then
            TextoPiePagina = "Página " & ContadorPaginasSalida & " de " & TotalPaginasSalida
        Else
            TextoPiePagina = "Página " & ContadorPaginasSalida
        End If
        e.Graphics.DrawString(TextoPiePagina, Formato_Etiqueta_6, Brocha, 40 + InicioCentradoTexto(TextoPiePagina, Formato_Etiqueta_6, 760, e), 1050)

        If ContadorItemsSalida = Dt_SalidaAlamacen.Rows.Count Then
            If TotalGrilla >= cantidadRenglones Then
                ConteoEquipos = -1
                VectorEquipos = Nothing
            Else
                e.Graphics.DrawString("|--------------------| Última Fila |--------------------|", Formato_Etiqueta_7, Brocha, 350, InicioYdeItemSA + (EspacioVertical * (TotalGrilla)) + separacionTextoFilas)
            End If
            If ImpresionSalida Then 'And ContadorPaginasSalida = TotalPaginasSalida
                GuardarImpresion() 'Si ya imprimió entra y cambia el valor de impresa en la tabla SALIDAALMACEN
            Else
                TotalPaginasSalida = ContadorPaginasSalida
            End If

            ContadorItemsSalida = 0
            ContadorPaginasSalida = 0
            ImpresionSalida = True
            e.HasMorePages = False
        Else
            e.HasMorePages = True
        End If

    End Sub

    Private Sub GuardarImpresion()
        'Guarda información de la impresión , y modifica el campo de impreso en la salida de almacén
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento", conn)
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.Add("@TIPO", SqlDbType.Int)
        If SALIDACANCELADA = False Then
            Comando.Parameters("@TIPO").Value = 0
        Else
            If CANCELACIONPARCIAL Then
                Comando.Parameters("@TIPO").Value = 1
            Else
                Comando.Parameters("@TIPO").Value = 2
            End If
        End If
        Comando.Parameters.AddWithValue("@IDDOCUMENTO", IDSALIDAALMACEN)
        Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub


#End Region

#Region "67 - ICS-GRAL-F-022 REMISION DE MATERIALES"


    Dim WithEvents DocImp_RemisiónDeMaterialesICSGRALF022 As New PrintDocument 'Documento a imprimir

    Public IDREMISIONIMPRESION As Int64
    Public copiaparadestinatario As Boolean
    Public copiaparatransportador As Boolean
    Public copiaparaporteriasalida As Boolean
    Public copiaparadestinatarioR As Boolean
    Public copiaparatransportadorR As Boolean
    Public copiaparaporteriasalidaR As Boolean
    Public copiaparaconsecutivoR As Boolean
    Public copiaparadestinatariotemp As Boolean
    Public copiaparatransportadortemp As Boolean
    Public copiaparaconsecutivotemp As Boolean
    Public copiaparaporteriasalidatemp As Boolean
    Public copiaparadestinatarioRtemp As Boolean
    Public copiaparatransportadorRtemp As Boolean
    Public copiaparaporteriasalidaRtemp As Boolean
    Public copiaparaconsecutivoRtemp As Boolean
    Public MediaCarta2 As Boolean
    Public ImpresionCompartida As Boolean
    Public ContadorCopiasCompartido As Integer
    Public ContadorCopiasCompartidoImpresas As Integer = 1
    Public ActivarImpresionVistaPrevia As Boolean

    Private _copiaparadestinatario As Boolean
    Private _copiaparatransportador As Boolean
    Private _copiaparaporteriasalida As Boolean
    Private dt_Remisión As DataTable
    Dim cargardatasetremisión As Boolean = True
    Dim ContadorItemRemisión As Integer = 0
    Dim FilaRemisión As DataRow
    Dim renglonestotalRemisión As Integer = 0
    'para componentes
    Dim completarcomponentes As Boolean = False
    Dim listaComponentes As ArrayList
    Dim paginastotalRemision As Integer = 0
    Dim copiasRemision As Integer = 0
    Dim contcopiasRemision As Integer = 0
    Dim contadorcopias2 As Integer = 0

    Private Sub DocImpRemisiónDeMaterialesICSGRALF022(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RemisiónDeMaterialesICSGRALF022.PrintPage
        If cargardatasetremisión = True Then

            _copiaparadestinatario = copiaparadestinatario
            _copiaparatransportador = copiaparatransportador
            _copiaparaporteriasalida = copiaparaporteriasalida
            _copiaparaconsecutivo = copiaparaconsecutivo
            Dim Cadena_Consulta As String = "SELECT * FROM dbo.ImprimirRemisión(" + IDREMISIONIMPRESION.ToString + ") AS ImprimirRemisión"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            dt_Remisión = New DataTable
            Adaptador.FillSchema(dt_Remisión, SchemaType.Source)
            Adaptador.Fill(dt_Remisión)
            Consulta.Connection.Close()
            FilaRemisión = dt_Remisión.Rows(0)

            cargardatasetremisión = False
            paginastotalRemision = 0
            If Me.copiaparadestinatario = True Then
                copiasRemision += 1
            End If
            If Me.copiaparatransportador = True Then
                copiasRemision += 1
            End If
            If Me.copiaparaconsecutivo = True Then
                copiasRemision += 1
            End If
            If Me.copiaparaporteriasalida = True Then
                copiasRemision += 1
            End If
        End If
Line1:
        'contadorcopias2 = 0
        If Me.copiaparadestinatario = True Then
            copiapara = "DESTINATARIO"
            contadorcopias2 += 1
        Else
            If copiaparatransportador = True Then
                copiapara = "TRANSPORTADOR"
                contadorcopias2 += 1
            Else
                If copiaparaconsecutivo = True Then
                    copiapara = "CONSECUTIVO"
                    contadorcopias2 += 1
                Else
                    If copiaparaporteriasalida = True Then
                        copiapara = "PORTERÍA SALIDA"
                        contadorcopias2 += 1
                        Me.copiaparaporteriasalida = False
                    End If
                End If
            End If
        End If

        Brocha.Color = Color.Black

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaRemisión("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Trim(FilaRemisión("ABREVIATURABODEGAORIGEN"))) Then
            If MsgBox("¿Desea imprimir la requisición con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' Logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Dim AlturaInicioImpresion As Integer

        Dim CantidadArticulos As Integer = dt_Remisión.Rows.Count
        Dim CantidadEquipos As Integer = 0
        For i As Integer = 0 To dt_Remisión.Rows.Count - 1
            Dim filaCantItemRemision As DataRow 'Articulos
            filaCantItemRemision = dt_Remisión.Rows(i)
            Dim dscantequipos As New DataSet 'Equipos asociados al articulo
            dscantequipos = bddatos.ModificarCustodias(9, 0, filaCantItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
            CantidadEquipos += dscantequipos.Tables(0).Rows.Count
        Next

        If MediaCarta2 Then
            'Se Verifica la cantidad de items de la remision
            Dim CantidadLineasOcupa As Integer = 0
            For i As Integer = 0 To dt_Remisión.Rows.Count - 1
                If Trim(dt_Remisión.Rows(i).Item("NOMBREDESCRIPTIVO").ToString).Length < 91 Then
                    CantidadLineasOcupa += 1
                Else
                    If Trim(dt_Remisión.Rows(i).Item("NOMBREDESCRIPTIVO").ToString).Length < 181 Then
                        CantidadLineasOcupa += 2
                    Else
                        CantidadLineasOcupa += 3
                    End If
                End If

                Dim dscantequipos As New DataSet 'Equipos asociados al articulo
                dscantequipos = bddatos.ModificarCustodias(9, 0, dt_Remisión.Rows(i).Item("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                If dscantequipos.Tables(0).Rows.Count > 0 Then
                    Dim CadenaEquipos As String = "Códigos: "
                    For j As Integer = 0 To dscantequipos.Tables(0).Rows.Count - 1
                        CadenaEquipos += dscantequipos.Tables(0).Rows(j)("CODIGO")
                        If j <> dscantequipos.Tables(0).Rows.Count - 1 Then
                            CadenaEquipos += ", "
                        End If
                    Next

                    Dim ArrayEquipos As New ArrayList
                    Dim ArrayEquiposTotal As New ArrayList
                    'ArrayEquipos.Clear()
                    ArrayEquipos.Add(Trim(CadenaEquipos))
                    If dscantequipos.Tables(0).Rows.Count < 3 Then
                        ArrayEquiposTotal = TextoAParrafoFuente(ArrayEquipos, Formato_Etiqueta_5, 310, e)
                    Else
                        ArrayEquiposTotal = TextoAParrafoFuente(ArrayEquipos, Formato_Etiqueta_4, 310, e)
                    End If

                    If ArrayEquiposTotal(ArrayEquiposTotal.Count - 1) = "" Then
                        ArrayEquiposTotal.RemoveAt(ArrayEquiposTotal.Count - 1)
                    End If
                    CantidadLineasOcupa += ArrayEquiposTotal.Count
                End If

            Next

            If CantidadLineasOcupa > 5 Then
                MediaCarta2 = False
                If contadorcopias2 = 1 Then
                    MsgBox("No se pudo imprimir en media carta.")
                End If
            End If

        End If

        If MediaCarta2 = True Then

            'Dim ContadorRenglones As Integer = 0
            Dim CantidadRenglones3 As Integer = 0
            Dim AlturaRenglones As Integer = 15

            Dim Modulo As Integer
            If ImpresionCompartida = True Then
                Modulo = ContadorCopiasCompartidoImpresas Mod 2
            Else
                Modulo = contadorcopias2 Mod 2
            End If
            If Modulo = 1 Then
                AlturaInicioImpresion = 20
            Else
                AlturaInicioImpresion = 550
            End If

            Dim PiePagina As String = ""
            PiePagina = "Página 1 de 1"
            Select Case LogoEmpresa
                Case 0 'ISMOCOL S.A.
                    'Cambiar el tamaño del logo dependiendo si tiene 1 o mas items y se ubica mas arriba
                    e.Graphics.DrawImage(imagen, 35, AlturaInicioImpresion, 60, 55)
                    'Se ubica arriba la caja del formato
                    e.Graphics.DrawRectangle(Lapiz, 700, AlturaInicioImpresion, 100, 30)
                    e.Graphics.DrawLine(Lapiz, 700, AlturaInicioImpresion + 15, 800, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString("ICS - GRAL - F - 022", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 2)
                    e.Graphics.DrawString("   REVISIÓN No. 2", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 18)
                    e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 5)
                    e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 325 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 185, e), AlturaInicioImpresion + 5)
                    e.Graphics.DrawLine(Lapiz, 325, AlturaInicioImpresion + 15, 509, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, Brocha, 325 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, 185, e), AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 590, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 590, AlturaInicioImpresion + 5)
                    DrawRoundedRectangle(e.Graphics, 325, AlturaInicioImpresion, 185, 40, 15)
                Case 1 'CSI
                    e.Graphics.DrawImage(imagenCSI, 35, AlturaInicioImpresion, 60, 55)
                    e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 5)
                    e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 380 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 185, e), AlturaInicioImpresion + 5)
                    e.Graphics.DrawLine(Lapiz, 380, AlturaInicioImpresion + 15, 565, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, Brocha, 380 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, 175, e), AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 690, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 690, AlturaInicioImpresion + 5)
                    DrawRoundedRectangle(e.Graphics, 380, AlturaInicioImpresion, 185, 40, 15)
                Case 2 'ZAMORANA
                    e.Graphics.DrawImage(zamorana, 35, AlturaInicioImpresion, 170, 45)
                    e.Graphics.DrawRectangle(Lapiz, 700, AlturaInicioImpresion, 100, 30)
                    e.Graphics.DrawLine(Lapiz, 700, AlturaInicioImpresion + 15, 800, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString("ZMS - GRAL - F - 011", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 4)
                    e.Graphics.DrawString("   REVISIÓN No. 0", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 18)
                    e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_13, Brushes.Black, 220, AlturaInicioImpresion + 5)
                    e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_13, Brushes.Black, 220, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 380 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 185, e), AlturaInicioImpresion + 5)
                    e.Graphics.DrawLine(Lapiz, 380, AlturaInicioImpresion + 15, 565, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, Brocha, 380 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, 185, e), AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 590, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 590, AlturaInicioImpresion + 5)
                    DrawRoundedRectangle(e.Graphics, 380, AlturaInicioImpresion, 185, 40, 15)
            End Select

            Dim AltRectInicial, AltRectDos, AltRectTres, AltRecCuatro, AltRecCinco As Integer
            AltRectInicial = AlturaInicioImpresion + 60
            AltRectDos = AlturaInicioImpresion + 105
            AltRectTres = AlturaInicioImpresion + 125
            AltRecCuatro = AlturaInicioImpresion + 388
            AltRecCinco = AlturaInicioImpresion + 411
            DrawRoundedRectangle(e.Graphics, 30, AltRectInicial, 770, 35, 15) 'Primer Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRectDos, 770, 15, 10) 'Segundo Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRectTres, 770, 249, 15) 'Tercer Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRecCuatro, 770, 20, 15) 'Cuarto Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRecCinco, 770, 93, 15) 'Quinto Rectangulo redondeado grande

            Dim AltLineasPrimerRec As Integer
            AltLineasPrimerRec = AlturaInicioImpresion + 45
            e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 580, AltLineasPrimerRec) 'horizontal
            e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 130, AltLineasPrimerRec + 50) 'Vertical
            e.Graphics.DrawLine(Lapiz, 320, AltLineasPrimerRec, 320, AltLineasPrimerRec + 50) 'Vertical
            e.Graphics.DrawLine(Lapiz, 420, AltLineasPrimerRec, 420, AltLineasPrimerRec + 50) 'Vertical
            e.Graphics.DrawLine(Lapiz, 580, AltLineasPrimerRec, 580, AltLineasPrimerRec + 15) 'Vertical
            e.Graphics.DrawString("NOMBRE BODEGA", Formato_Etiqueta_6, Brocha, 165, AltLineasPrimerRec + 3)
            e.Graphics.DrawString("CLAVE", Formato_Etiqueta_6, Brocha, 340, AltLineasPrimerRec + 3)
            e.Graphics.DrawString("SA: " + FilaRemisión("SALIDAALMACEN"), Formato_Etiqueta_6, Brocha, 430, AltLineasPrimerRec + 3)
            e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 20)
            Dim bodega As String = Trim(FilaRemisión("BODEGAORIGEN"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 20)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 17)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 27)
                    Else
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 20)
                    End If
            End Select
            e.Graphics.DrawString(FilaRemisión("ABREVIATURABODEGAORIGEN"), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 20)
            e.Graphics.DrawLine(Lapiz, 30, AltLineasPrimerRec + 34, 800, AltLineasPrimerRec + 34)
            e.Graphics.DrawString("CIUDAD Y FECHA", Formato_Etiqueta_7, Brocha, 550, AltLineasPrimerRec + 20)
            e.Graphics.DrawString("DESTINO", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 37)
            bodega = Trim(FilaRemisión("DESTINO"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 37)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                    Else
                        e.Graphics.DrawString(Mid(bodega, 1, 50), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                        e.Graphics.DrawString(Mid(bodega, 50, 100), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                    End If
            End Select
            e.Graphics.DrawString(Trim(FilaRemisión("ABREVIATURADESTINO")), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 37)
            Dim Ciuyfechas As String = Trim(FilaRemisión("CIUDAD").ToString) + "   /  " + FilaRemisión("FECHA")
            e.Graphics.DrawString(Ciuyfechas, Formato_Etiqueta_7, Brocha, 420 + InicioCentradoTexto(Ciuyfechas, Formato_Etiqueta_8, 380, e), AltLineasPrimerRec + 37)
            e.Graphics.DrawString("DESPACHADO VÍA:  " + FilaRemisión("DESPACHADO"), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 50)

            Dim observa As String = Trim(FilaRemisión("OBSERVACION"))
            If observa.Length > 140 Then
                Dim observa1 As String = Trim(Mid(observa, 1, 140))
                Dim pos As Integer
                pos = observa1.LastIndexOf(" ")
                observa1 = Trim(Mid(observa, 1, pos))
                e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_5, Brocha, 35, AltLineasPrimerRec + 60)
                observa = Trim(Mid(observa, pos + 1, observa.Length))
                e.Graphics.DrawString(observa, Formato_Etiqueta_5, Brocha, 83, AltLineasPrimerRec + 67)
            Else
                e.Graphics.DrawString("Observación: " + Mid(observa, 1, 140), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 63)
            End If

            e.Graphics.DrawString("REQUISICIÓN", Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto("REQUISICIÓN", Formato_Etiqueta_6, 90, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 120, AltRectTres, 120, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 150, AltRectTres, 150, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto("UN/M", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 180, AltRectTres, 180, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
            e.Graphics.DrawString("DESPACHADA", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("DESPACHADA", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
            e.Graphics.DrawLine(Lapiz, 240, AltRectTres, 240, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
            e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("ARTÍCULO", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
            e.Graphics.DrawLine(Lapiz, 300, AltRectTres, 300, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, 300 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_7, 320, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 620, AltRectTres, 620, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("ORDEN DE", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("ORDEN DE", Formato_Etiqueta_5, 90, e), AltRectTres + 3)
            e.Graphics.DrawString("COMPRA", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("COMPRA", Formato_Etiqueta_5, 90, e), AltRectTres + 10)
            e.Graphics.DrawLine(Lapiz, 710, AltRectTres, 710, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("# CAJA /", Formato_Etiqueta_4, Brocha, 710 + InicioCentradoTexto("# CAJA /", Formato_Etiqueta_5, 45, e), AltRectTres + 1)
            e.Graphics.DrawString("PAQUETE /", Formato_Etiqueta_4, Brocha, 710 + InicioCentradoTexto("PAQUETE /", Formato_Etiqueta_5, 45, e), AltRectTres + 7)
            e.Graphics.DrawString("BULTO", Formato_Etiqueta_4, Brocha, 710 + InicioCentradoTexto("BULTO", Formato_Etiqueta_5, 45, e), AltRectTres + 14)
            e.Graphics.DrawLine(Lapiz, 755, AltRectTres, 755, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("CANT.", Formato_Etiqueta_5, Brocha, 755 + InicioCentradoTexto("CANT.", Formato_Etiqueta_5, 45, e), AltRectTres + 3)
            e.Graphics.DrawString("RECIBIDA", Formato_Etiqueta_5, Brocha, 755 + InicioCentradoTexto("RECIBIDA", Formato_Etiqueta_5, 45, e), AltRectTres + 10)

            e.Graphics.DrawLine(Lapiz, 30, AltRectTres + 21, 800, AltRectTres + 21) 'horizontal

            Dim lineaPunteada As New Pen(Color.Gray, 1)
            lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

            Dim InicioYdeItemRem As Integer
            InicioYdeItemRem = AlturaInicioImpresion + 147

            ContadorItemRemisión = CantidadArticulos
            contcopiasRemision += 1

            Const CantidadRenglones As Integer = 6
            Const EspacioVertical As Integer = 9

            Dim InicioImpresionItems As Integer
            InicioImpresionItems = AlturaInicioImpresion + 147
            Dim ContadorRenglones2 As Integer = 0

            For i As Integer = 0 To CantidadArticulos - 1
                Dim filaItemRemision As DataRow
                filaItemRemision = dt_Remisión.Rows(i)
                Dim Cadenas1 As New ArrayList
                Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
                Dim Cadena_Total1 As New ArrayList
                Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                Dim tempTexto As String = ""
                tempTexto = IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION"))
                e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 30 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_5, Brocha, 120 + InicioCentradoTexto(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_5, Brocha, 150 + InicioCentradoTexto(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                tempTexto = IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA"))
                e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                ContadorRenglones = 0
                Dim LargoArticulo As Integer = Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                    Case Is < 73
                        e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 91
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 2)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 141
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 71, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + 10)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 181
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 10)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 9)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 181, 90), Formato_Etiqueta_4, Brocha, 302, InicioYdeItemRem + 18)
                        ContadorRenglones = ContadorRenglones + 1
                End Select

                '------------componentes------------
                Dim dsequipos As New DataSet
                dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)

                If dsequipos.Tables(0).Rows.Count > 0 Then
                    'crear la cadena de códigos
                    Dim cadenaEquipos As String
                    cadenaEquipos = "Códigos: "
                    Dim j As Integer
                    For j = 0 To dsequipos.Tables(0).Rows.Count - 1
                        cadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                        If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                            cadenaEquipos += ", "
                        End If
                    Next
                    Cadenas1.Clear()
                    Cadenas1.Add(Trim(cadenaEquipos))
                    Dim formatoetiqueta
                    If dsequipos.Tables(0).Rows.Count < 3 Then
                        Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)
                        formatoetiqueta = Formato_Etiqueta_5
                    Else
                        Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_4, 310, e)
                        formatoetiqueta = Formato_Etiqueta_4
                    End If

                    Dim resta As Integer
                    resta = 0
                    e.Graphics.DrawLine(lineaPunteada, 300, InicioYdeItemRem + (ContadorRenglones * EspacioVertical), 620, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))  'Horizontal
                    For k = 0 To Cadena_Total1.Count - 2
                        If k <> 0 Then
                            resta = 2
                        End If
                        e.Graphics.DrawString(Cadena_Total1(k), formatoetiqueta, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical) - resta)
                        ContadorRenglones = ContadorRenglones + 1
                        If ContadorRenglones >= CantidadRenglones Then
                            'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                            Dim cadena2 As New ArrayList
                            For z = k + 1 To Cadena_Total1.Count - 2
                                cadena2.Add(Cadena_Total1(z))
                            Next
                            listaComponentes = cadena2
                            ContadorItemRemisión = ContadorItemRemisión - 1
                            completarcomponentes = True
                            Exit For
                        End If
                    Next

                End If
                '-----------------------------------
                ContadorRenglones2 += ContadorRenglones
                If ContadorRenglones2 <= CantidadRenglones - 1 Then
                    e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem + (EspacioVertical * ContadorRenglones)) 'horizontal
                End If
                InicioYdeItemRem = InicioYdeItemRem + (ContadorRenglones * EspacioVertical)
            Next

            e.Graphics.DrawLine(Lapiz, 30, InicioImpresionItems + 50, 800, InicioImpresionItems + 50) 'horizontal

            Dim InicioLineas As Integer = InicioImpresionItems + 54

            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 83) 'vertical
            e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 83) 'vertical
            e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 83) 'vertical
            e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 83) 'vertical

            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 160, InicioLineas + 3)
            e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 315, InicioLineas + 3)
            e.Graphics.DrawString("VERIFICA", Formato_Etiqueta_7, Brocha, 510, InicioLineas + 3)
            e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 690, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas) 'horizontal


            e.Graphics.DrawString(FilaRemisión("DIGITA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(FilaRemisión("DIGITA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
            e.Graphics.DrawString(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, Brocha, 280 + InicioCentradoTexto(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
            e.Graphics.DrawString(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, Brocha, 460 + InicioCentradoTexto(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, 170, e), InicioLineas + 53) 'Verifica

            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 32
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17

            e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 89) 'vertical
            e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
            e.Graphics.DrawString("ENVIO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 72) 'vertical
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
            e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 10)
            e.Graphics.DrawString(FilaRemisión("TRANSPORTADOR"), Formato_Etiqueta_7, Brocha, 400, InicioLineas + 10)

            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 22
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            Dim Despacho As String = FilaRemisión("DESPACHADO")

            If Despacho.Length > 50 Then
                e.Graphics.DrawString(Mid(Despacho, 1, 45), Formato_Etiqueta_5, Brocha, 105, InicioLineas)
                e.Graphics.DrawString(Mid(Despacho, 46, 90), Formato_Etiqueta_5, Brocha, 105, InicioLineas + 7)
            Else
                e.Graphics.DrawString(Despacho, Formato_Etiqueta_6, Brocha, 105, InicioLineas + 3)
            End If

            e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawString(FilaRemisión("GUIA"), Formato_Etiqueta_8, Brocha, 400, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 19

            e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_6, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 8, 100, InicioLineas + 11) 'vertical
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 8, 330, InicioLineas + 11) 'vertical
            e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 8, 580, InicioLineas + 11) 'vertical
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas - 4)
            e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas - 4)
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas - 4)
            InicioLineas = InicioLineas + 20

            e.Graphics.DrawString("RECIBEN Y VERIFICAN", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 15
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 2, 100, InicioLineas + 72) 'vertical seccion reciben y verifican
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 2, 330, InicioLineas + 72) 'vertical seccion reciben y verifican
            e.Graphics.DrawLine(Lapiz, 590, InicioLineas - 2, 590, InicioLineas + 72) 'vertical seccion reciben y verifican
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 2, 800, InicioLineas - 2) 'Horizontal seccion reciben y verifican
            e.Graphics.DrawString("SEGURIDAD FÍSICA", Formato_Etiqueta_7, Brocha, 150, InicioLineas)
            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 420, InicioLineas)
            e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7, Brocha, 650, InicioLineas)
            InicioLineas = InicioLineas + 10
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas + 1, 800, InicioLineas + 1) 'horizontal seccion reciben y verifican
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
            InicioLineas = InicioLineas + 30
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
            e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            If ImpresionCompartida = True Then
                If ContadorCopiasCompartido = 1 Or ContadorCopiasCompartido = 3 Or ContadorCopiasCompartido = 5 Or ContadorCopiasCompartido = 7 Then
                    e.Graphics.DrawLine(lineaPunteada, 0, InicioLineas + 23, 1000, InicioLineas + 23) 'horizontal
                End If
            Else
                If contadorcopias2 = 1 Or contadorcopias2 = 3 Then
                    e.Graphics.DrawLine(lineaPunteada, 0, InicioLineas + 23, 1000, InicioLineas + 23) 'horizontal
                End If
            End If


            If ContadorItemRemisión >= dt_Remisión.Rows.Count Then
                If contcopiasRemision = copiasRemision Then
                    e.HasMorePages = False
                    paginastotalRemision = contpaginas
                    contcopiasRemision = 0
                    copiaparadestinatario = _copiaparadestinatario
                    copiaparatransportador = _copiaparatransportador
                    copiaparaporteriasalida = _copiaparaporteriasalida
                    copiaparaconsecutivo = _copiaparaconsecutivo
                Else
                    e.HasMorePages = True

                    If Me.copiaparadestinatario = True Then
                        Me.copiaparadestinatario = False
                        ContadorCopiasCompartidoImpresas += 1
                    Else
                        If copiaparatransportador = True Then
                            Me.copiaparatransportador = False
                            ContadorCopiasCompartidoImpresas += 1
                        Else
                            If copiaparaconsecutivo = True Then
                                Me.copiaparaconsecutivo = False
                                ContadorCopiasCompartidoImpresas += 1
                            Else
                                If copiaparaporteriasalida = True Then
                                    Me.copiaparaporteriasalida = False
                                    ContadorCopiasCompartidoImpresas += 1
                                End If
                            End If
                        End If
                    End If
                End If
                'Reinicio de variables
                contpaginas = 1
                ContadorRenglones = 0
                ContadorItemRemisión = 0
            Else
                contpaginas = contpaginas + 1
                ContadorRenglones = 0
                e.HasMorePages = True
            End If

            If e.HasMorePages = True Then
                If contadorcopias2 = 1 Or contadorcopias2 = 3 Then GoTo Line1
            Else
                contadorcopias2 = 0
            End If

            '*****************************Cuando es mas de un item  en la remision*****************************
        Else
            Select Case LogoEmpresa
                Case 0 'ISMOCOL S.A.
                    'Cambiar el tamaño del logo dependiendo si tiene 1 o mas items y se ubica mas arriba
                    e.Graphics.DrawImage(imagen, 35, 40, 75, 60)
                Case 1 'CSI
                    e.Graphics.DrawImage(imagenCSI, 35, 40, 75, 60)
                Case 2 'ZAMORANA
                    e.Graphics.DrawImage(zamorana, 35, 40, 170, 45)
            End Select

            DrawRoundedRectangle(e.Graphics, 30, 122, 770, 40, 15)
            DrawRoundedRectangle(e.Graphics, 30, 181, 770, 22, 15)
            DrawRoundedRectangle(e.Graphics, 30, 208, 770, 660, 15)
            DrawRoundedRectangle(e.Graphics, 30, 884, 770, 25, 15)
            DrawRoundedRectangle(e.Graphics, 30, 911, 770, 110, 15)


            e.Graphics.DrawString("REMISIÓN DE MATERIALES", Formato_Etiqueta_15, Brushes.Black, InicioCentradoTexto("REMISIÓN DE MATERIALES", Formato_Etiqueta_15, 950, e) - 70, 50)
            e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_8, Brocha, 675, 53)
            e.Graphics.DrawLine(Lapiz, 605, 70, 800, 70)
            e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_16, Brocha, 610 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_16, 185, e), 75)
            DrawRoundedRectangle(e.Graphics, 605, 48, 195, 70, 15)
            e.Graphics.DrawLine(Lapiz, 130, 105, 580, 105) 'horizontal
            e.Graphics.DrawLine(Lapiz, 130, 105, 130, 162) 'Vertical
            e.Graphics.DrawLine(Lapiz, 320, 105, 320, 162) 'Vertical
            e.Graphics.DrawLine(Lapiz, 420, 105, 420, 162) 'Vertical
            e.Graphics.DrawLine(Lapiz, 580, 105, 580, 121) 'Vertical
            e.Graphics.DrawString("NOMBRE BODEGA", Formato_Etiqueta_7, Brocha, 165, 110)
            e.Graphics.DrawString("CLAVE", Formato_Etiqueta_7, Brocha, 340, 110)
            e.Graphics.DrawString("SA: " + FilaRemisión("SALIDAALMACEN"), Formato_Etiqueta_7, Brocha, 430, 110)
            e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_7, Brocha, 35, 128)
            Dim bodega As String = Trim(FilaRemisión("BODEGAORIGEN"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_8, Brocha, 135, 128)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, 124)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, 134)
                    Else
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, 128)
                    End If
            End Select

            e.Graphics.DrawString(FilaRemisión("ABREVIATURABODEGAORIGEN"), Formato_Etiqueta_8, Brocha, 343, 128)
            e.Graphics.DrawLine(Lapiz, 30, 143, 800, 143)

            e.Graphics.DrawString("CIUDAD Y FECHA", Formato_Etiqueta_7, Brocha, 550, 128)
            e.Graphics.DrawString("DESTINO", Formato_Etiqueta_7, Brocha, 35, 148)
            bodega = Trim(FilaRemisión("DESTINO"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_8, Brocha, 135, 148)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, 144)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, 154)
                    Else
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, 148)
                    End If
            End Select
            e.Graphics.DrawString(Trim(FilaRemisión("ABREVIATURADESTINO")), Formato_Etiqueta_8, Brocha, 343, 148)
            Dim Ciuyfechas As String = Trim(FilaRemisión("CIUDAD").ToString) + "   /  " + FilaRemisión("FECHA")
            e.Graphics.DrawString(Ciuyfechas, Formato_Etiqueta_8, Brocha, 420 + InicioCentradoTexto(Ciuyfechas, Formato_Etiqueta_8, 380, e), 148)
            e.Graphics.DrawString("DESPACHADO VÍA:  " + FilaRemisión("DESPACHADO"), Formato_Etiqueta_7, Brocha, 35, 166)
            Dim observa As String = Trim(FilaRemisión("OBSERVACION"))
            If observa.Length > 140 Then
                Dim observa1 As String = Trim(Mid(observa, 1, 140))
                Dim pos As Integer
                pos = observa1.LastIndexOf(" ")
                observa1 = Trim(Mid(observa, 1, pos))
                e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_6, Brocha, 35, 183)
                observa = Trim(Mid(observa, pos + 1, observa.Length))
                e.Graphics.DrawString(observa, Formato_Etiqueta_6, Brocha, 95, 193)
            Else
                e.Graphics.DrawString("Observación: " + Mid(observa, 1, 140), Formato_Etiqueta_6, Brocha, 35, 185)
            End If
            e.Graphics.DrawString("REQUISICIÓN", Formato_Etiqueta_7, Brocha, 30 + InicioCentradoTexto("REQUISICIÓN", Formato_Etiqueta_7, 90, e), 220)
            e.Graphics.DrawLine(Lapiz, 120, 208, 120, 660) 'vertical

            e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 30, e), 220)
            e.Graphics.DrawLine(Lapiz, 150, 208, 150, 660) 'vertical

            e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto("UN/M", Formato_Etiqueta_6, 30, e), 220)
            e.Graphics.DrawLine(Lapiz, 180, 208, 180, 660) 'vertical

            e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_5, 60, e), 215)
            e.Graphics.DrawString("DESPACHADA", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("DESPACHADA", Formato_Etiqueta_5, 60, e), 225)
            e.Graphics.DrawLine(Lapiz, 240, 208, 240, 660) 'vertical

            e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_6, Brocha, 240 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_6, 60, e), 215)
            e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_6, Brocha, 240 + InicioCentradoTexto("ARTÍCULO", Formato_Etiqueta_6, 60, e), 225)
            e.Graphics.DrawLine(Lapiz, 300, 208, 300, 660) 'vertical

            e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, 300 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_7, 320, e), 220)
            e.Graphics.DrawLine(Lapiz, 620, 208, 620, 660) 'vertical

            e.Graphics.DrawString("ORDEN DE", Formato_Etiqueta_6, Brocha, 620 + InicioCentradoTexto("ORDEN DE", Formato_Etiqueta_6, 90, e), 215)
            e.Graphics.DrawString("COMPRA", Formato_Etiqueta_6, Brocha, 620 + InicioCentradoTexto("COMPRA", Formato_Etiqueta_6, 90, e), 225)
            e.Graphics.DrawLine(Lapiz, 710, 208, 710, 660) 'vertical

            e.Graphics.DrawString("# CAJA /", Formato_Etiqueta_5, Brocha, 710 + InicioCentradoTexto("# CAJA /", Formato_Etiqueta_5, 45, e), 212)
            e.Graphics.DrawString("PAQUETE /", Formato_Etiqueta_5, Brocha, 710 + InicioCentradoTexto("PAQUETE /", Formato_Etiqueta_5, 45, e), 220)
            e.Graphics.DrawString("BULTO", Formato_Etiqueta_5, Brocha, 710 + InicioCentradoTexto("BULTO", Formato_Etiqueta_5, 45, e), 228)
            e.Graphics.DrawLine(Lapiz, 755, 208, 755, 660) 'vertical

            e.Graphics.DrawString("CANT.", Formato_Etiqueta_5, Brocha, 755 + InicioCentradoTexto("CANT.", Formato_Etiqueta_5, 45, e), 215)
            e.Graphics.DrawString("RECIBIDA", Formato_Etiqueta_5, Brocha, 755 + InicioCentradoTexto("RECIBIDA", Formato_Etiqueta_5, 45, e), 225)

            e.Graphics.DrawLine(Lapiz, 30, 240, 800, 240) 'horizontal



            Dim lineaPunteada As New Pen(Color.Gray, 1)
            lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

            Const InicioYdeItemRem As Integer = 242
            Const EspacioVertical As Integer = 14
            Const CantidadRenglones As Integer = 30

            '**********cuando se tiene una cadena incompleta de equipos para imprimir de la página anterior
            If completarcomponentes = True Then
                Dim Cadena_Total1 As New ArrayList
                Cadena_Total1 = listaComponentes
                ContadorItemRemisión = ContadorItemRemisión + 1
                Dim varpivote As Boolean = False
                For i = 0 To listaComponentes.Count - 1
                    e.Graphics.DrawString(Cadena_Total1(i), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                    ContadorRenglones = ContadorRenglones + 1
                    If ContadorRenglones > CantidadRenglones Then
                        'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                        Dim cadena2 As New ArrayList
                        For z = i + 1 To Cadena_Total1.Count - 2
                            cadena2.Add(Cadena_Total1(z))
                        Next
                        varpivote = True
                        listaComponentes = cadena2
                        ContadorItemRemisión = ContadorItemRemisión - 1
                        completarcomponentes = True
                        e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                        Exit For
                    End If
                Next

                If ContadorRenglones > 0 And ContadorRenglones <= CantidadRenglones Then
                    e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                End If

                If ContadorRenglones <= CantidadRenglones - 1 Then
                    listaComponentes.Clear()
                    completarcomponentes = False
                End If
            End If

            '**************

            'Dim fuente_Rem As Font = Formato_Etiqueta_8

            'Imprimir item's
            For i = ContadorItemRemisión To dt_Remisión.Rows.Count - 1
                Dim filaItemRemision As DataRow
                filaItemRemision = dt_Remisión.Rows(i)
                Dim Cadenas1 As New ArrayList
                Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
                Dim Cadena_Total1 As New ArrayList
                Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                If ContadorRenglones + Cadena_Total1.Count - 2 >= CantidadRenglones - 1 Then
                    e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                    Exit For
                End If

                Dim tempTexto As String = ""

                tempTexto = IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION"))
                e.Graphics.DrawString(tempTexto, Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_6, 90, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, Brocha, 180 + InicioCentradoTexto(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, Brocha, 240 + InicioCentradoTexto(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                tempTexto = IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA"))
                e.Graphics.DrawString(tempTexto, Formato_Etiqueta_6, Brocha, 620 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_6, 90, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))

                Try
                    For k = 0 To Cadena_Total1.Count - 2
                        e.Graphics.DrawString(Cadena_Total1(k), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                Catch ex As Exception
                    Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                        Case Is < 60
                            e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 120
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 51, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 51, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 101, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 151, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                    End Select
                End Try
                ContadorItemRemisión = ContadorItemRemisión + 1
                If ContadorRenglones >= CantidadRenglones Then
                    Exit For
                End If

                '------------componentes------------
                Dim dsequipos As New DataSet
                dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                If dsequipos.Tables(0).Rows.Count > 0 Then
                    'crear la cadena de códigos
                    Dim cadenaEquipos As String
                    cadenaEquipos = "Códigos: "
                    Dim j As Integer
                    For j = 0 To dsequipos.Tables(0).Rows.Count - 1
                        cadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                        If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                            cadenaEquipos += ", "
                        End If
                    Next
                    Cadenas1.Clear()
                    Cadenas1.Add(Trim(cadenaEquipos))
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                    Dim varpivote As Boolean = False
                    If ContadorRenglones >= CantidadRenglones - 1 Then
                        'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                        Dim cadena2 As New ArrayList
                        For z = 0 To Cadena_Total1.Count - 2
                            cadena2.Add(Cadena_Total1(z))
                        Next
                        varpivote = True
                        listaComponentes = cadena2
                        ContadorItemRemisión = ContadorItemRemisión - 1
                        completarcomponentes = True

                        e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                        e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))

                        Exit For
                    End If
                    e.Graphics.DrawLine(lineaPunteada, 300, InicioYdeItemRem - 3 + (ContadorRenglones * EspacioVertical), 620, InicioYdeItemRem - 3 + (ContadorRenglones * EspacioVertical))  'Horizontal
                    For k = 0 To Cadena_Total1.Count - 2
                        e.Graphics.DrawString(Cadena_Total1(k), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        If ContadorRenglones >= CantidadRenglones - 1 Then
                            'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                            Dim cadena2 As New ArrayList
                            For z = k + 1 To Cadena_Total1.Count - 2
                                cadena2.Add(Cadena_Total1(z))
                            Next
                            varpivote = True
                            listaComponentes = cadena2
                            ContadorItemRemisión = ContadorItemRemisión - 1
                            completarcomponentes = True

                            e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                            e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            Exit For
                        End If
                    Next
                    If varpivote = True Then 'salir del for
                        Exit For
                    End If
                End If
                '-----------------------------------

                If ContadorRenglones <= CantidadRenglones Then
                    e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                End If
            Next

            e.Graphics.DrawLine(Lapiz, 30, 660, 800, 660) 'horizontal

            Dim InicioLineas As Integer = 680

            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 89) 'vertical
            e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 89) 'vertical
            e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 89) 'vertical
            e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 89) 'vertical

            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 160, InicioLineas + 3)
            e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 315, InicioLineas + 3)
            e.Graphics.DrawString("VERIFICA", Formato_Etiqueta_7, Brocha, 510, InicioLineas + 3)
            e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 690, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 32
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 20

            e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 99) 'vertical
            e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
            e.Graphics.DrawString("ENVIO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 82) 'vertical
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 13)
            e.Graphics.DrawString(FilaRemisión("TRANSPORTADOR"), Formato_Etiqueta_7, Brocha, 400, InicioLineas + 13)

            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 32
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            Dim Despacho As String = FilaRemisión("DESPACHADO")

            If Despacho.Length > 50 Then
                e.Graphics.DrawString(Mid(Despacho, 1, 45), Formato_Etiqueta_5, Brocha, 105, InicioLineas)
                e.Graphics.DrawString(Mid(Despacho, 46, 90), Formato_Etiqueta_5, Brocha, 105, InicioLineas + 7)
            Else
                e.Graphics.DrawString(Despacho, Formato_Etiqueta_6, Brocha, 105, InicioLineas + 3)
            End If

            e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawString(FilaRemisión("GUIA"), Formato_Etiqueta_8, Brocha, 400, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 19

            e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 7, 100, InicioLineas + 18) 'vertical
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 7, 330, InicioLineas + 18) 'vertical
            e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 7, 580, InicioLineas + 18) 'vertical
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 1)
            e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 1)
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas + 1)
            InicioLineas = InicioLineas + 20

            e.Graphics.DrawString("RECIBEN Y VERIFICAN", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 90) 'vertical
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 90) 'vertical
            e.Graphics.DrawLine(Lapiz, 590, InicioLineas, 590, InicioLineas + 90) 'vertical
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'Horizontal
            e.Graphics.DrawString("SEGURIDAD FÍSICA", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 1)
            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 420, InicioLineas + 1)
            e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7, Brocha, 650, InicioLineas + 1)
            InicioLineas = InicioLineas + 14
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            InicioLineas = InicioLineas + 34
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            InicioLineas = InicioLineas + 24
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)

            e.Graphics.DrawString(FilaRemisión("DIGITA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(FilaRemisión("DIGITA"), Formato_Etiqueta_5, 180, e), 735)
            e.Graphics.DrawString(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, Brocha, 280 + InicioCentradoTexto(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, 180, e), 735)
            e.Graphics.DrawString(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, Brocha, 460 + InicioCentradoTexto(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, 170, e), 735) 'Verifica
            Dim PiePagina As String = ""
            If Not cargardatasetremisión And paginastotalRemision > 0 Then 'Cuando ya se han cargado los datos de la remisión.
                PiePagina = "Página " & contpaginas & " de " & paginastotalRemision
            Else
                PiePagina = "Página " & contpaginas
            End If
            e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, InicioCentradoTexto(PiePagina, Formato_Etiqueta_6, 950, e) - 50, 1050)
            e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 50, 1050)
            Select Case LogoEmpresa
                Case 0 'ISMOCOL S.A.
                    e.Graphics.DrawRectangle(Lapiz, 688, 1035, 100, 30)
                    e.Graphics.DrawLine(Lapiz, 688, 1050, 788, 1050)
                    e.Graphics.DrawString("ICS - GRAL - F - 022", Formato_Etiqueta_6, Brushes.Black, 700, 1037)
                    e.Graphics.DrawString("   REVISIÓN No. 2", Formato_Etiqueta_6, Brushes.Black, 700, 1053)
                Case 1 'CSI
                Case 2 'ZAMORANA
                    e.Graphics.DrawRectangle(Lapiz, 688, 1035, 100, 30)
                    e.Graphics.DrawLine(Lapiz, 688, 1050, 788, 1050)
                    e.Graphics.DrawString("ZMS - GRAL - F - 011", Formato_Etiqueta_6, Brushes.Black, 700, 1037)
                    e.Graphics.DrawString("   REVISIÓN No. 0", Formato_Etiqueta_6, Brushes.Black, 700, 1053)
            End Select
            If ContadorItemRemisión >= dt_Remisión.Rows.Count Then
                e.Graphics.DrawString("|--------------------| Última Fila |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Última Fila |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                contcopiasRemision += 1
                If contcopiasRemision = copiasRemision Then
                    e.HasMorePages = False
                    paginastotalRemision = contpaginas
                    contcopiasRemision = 0
                    copiaparadestinatario = _copiaparadestinatario
                    copiaparatransportador = _copiaparatransportador
                    copiaparaporteriasalida = _copiaparaporteriasalida
                    copiaparaconsecutivo = _copiaparaconsecutivo
                Else
                    e.HasMorePages = True
                    If Me.copiaparadestinatario = True Then
                        Me.copiaparadestinatario = False
                    Else
                        If copiaparatransportador = True Then
                            Me.copiaparatransportador = False
                        Else
                            If copiaparaconsecutivo = True Then
                                Me.copiaparaconsecutivo = False
                            Else
                                If copiaparaporteriasalida = True Then
                                    Me.copiaparaporteriasalida = False
                                End If
                            End If
                        End If
                    End If
                End If
                'Reinicio de variables
                contpaginas = 1
                ContadorRenglones = 0
                ContadorItemRemisión = 0
            Else
                contpaginas = contpaginas + 1
                ContadorRenglones = 0
                e.HasMorePages = True
            End If
        End If
    End Sub

#End Region

#Region "68 - STICKER ARTICULOS REF: 67*25 C3 x 30 Rótulos"
    Public Tb_Sticker As DataTable
    Dim WithEvents DocImp_STICKERARTICULOSREF_67_25_C3x30 As New PrintDocument 'Documento a imprimir
    Dim CantidadTotalSticker As Integer
    Dim CalcularCantidad As Boolean = True
    Dim VectorStickerId As New ArrayList
    Dim VectorStickerNombre As New ArrayList
    Dim VectorStickerUnidad As New ArrayList
    Public InicioImpresión As Integer = 1
    Dim ContaStickerImpreso As Integer = 1
    Dim ContaStickerVector As Integer = 0

    Private Sub DocImpSTICKERARTICULOSREF_67_25_C3x30(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_STICKERARTICULOSREF_67_25_C3x30.PrintPage
        If CalcularCantidad = True Then
            CantidadTotalSticker = Tb_Sticker.Compute("Sum(Cant)", "")
            paginastotal = -Int((-CantidadTotalSticker + InicioImpresión) / 30)
            CalcularCantidad = False
            For i = 0 To Tb_Sticker.Rows.Count - 1
                Dim cant As Integer = Tb_Sticker.Rows(i).Item("Cant")
                Dim Fila As DataRow
                Fila = Tb_Sticker.Rows(i)
                For j = 1 To cant
                    VectorStickerId.Add(Fila("Cód"))
                    VectorStickerNombre.Add(Fila("Descripción"))
                    VectorStickerUnidad.Add(Fila("Und"))
                Next
            Next
        End If
        Dim imprimir As Boolean = False
        For FilaImpresión = 1 To 10
            For ColumnaImpresión = 1 To 3
                If contpaginas = 1 Then
                    'Ubicar la primera impresión de sticker
                    If InicioImpresión > ContaStickerImpreso Then
                        imprimir = False
                        ContaStickerImpreso = ContaStickerImpreso + 1
                    Else
                        imprimir = True
                    End If
                Else
                    imprimir = True
                End If
                If imprimir = True Then
                    Dim sepvertical As Integer = 100
                    'Imprime
                    e.Graphics.DrawString("Cód:  " + VectorStickerId(ContaStickerVector).ToString, Formato_Etiqueta_12, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString(Date.Now.ToShortDateString, Formato_Etiqueta_6, Brocha, 170 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString("Und: " + VectorStickerUnidad(ContaStickerVector).ToString, Formato_Etiqueta_6, Brocha, 170 + ((ColumnaImpresión - 1) * 270), 49 + ((FilaImpresión - 1) * sepvertical))
                    Dim Descripción As String = VectorStickerNombre(ContaStickerVector)
                    Dim Cadenas1 As New ArrayList
                    Cadenas1.Add(Trim(Descripción))
                    Dim Cadena_Total1 As New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 240, e)
                    Dim Separa As Integer = 10
                    For t = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(t), Formato_Etiqueta_6, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 60 + (t * Separa) + ((FilaImpresión - 1) * sepvertical))
                    Next
                    e.Graphics.DrawString(Mid(VariablesBase.VariablesBase.Nombre_Usuario, 1, 80), Formato_Etiqueta_5, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 122 + ((FilaImpresión - 1) * sepvertical))
                    ContaStickerVector = ContaStickerVector + 1
                    ContaStickerImpreso = ContaStickerImpreso + 1
                End If
                If ContaStickerVector >= CantidadTotalSticker Then
                    Exit For
                End If
            Next
            If ContaStickerVector >= CantidadTotalSticker Then
                Exit For
            End If
        Next

        If ContaStickerVector >= CantidadTotalSticker Then
            contpaginas = 1
            ContaStickerImpreso = 1
            ContaStickerVector = 0
            e.HasMorePages = False
        Else
            contpaginas = contpaginas + 1
            e.HasMorePages = True
        End If


    End Sub


#End Region

#Region "69 - RELACION FACTURAS ORDEN DE COMPRA"
    Dim WithEvents DocImp_RELACION_FACTURA_OC As New PrintDocument 'Documento a imprimir
    Public IDRELACIONDOCUMENTO As Integer
    Private dt_Relacion As New DataTable
    Private PaginasRelacion As Integer = 1
    Private TotalPaginas As Integer
    Private ImpresionPaginas As Integer

    Dim DTRealcion As New Ds_ComprasTableAdapters.RELACIONORDENCOMPRATableAdapter
    Dim ContadorFacturasRelacionadas As Integer = 0

    Public cargardatasetrelacion As Boolean = True
    Dim ImpresionRelacion As Boolean = False

    Private Sub DocImpRELACION_FACTURA_OC(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RELACION_FACTURA_OC.PrintPage
        If dt_Relacion.Rows.Count = 0 Then
            'DTRealcion.Fill(DsCompras.RELACIONORDENCOMPRA, IDRELACIONDOCUMENTO)
            'dt_Relacion = DsCompras.RELACIONORDENCOMPRA
            'Cargar datos Relación Orden Compra.
            comando = New SqlCommand("SELECT * FROM ImpresionRelacionOC(@IDRELACIONDOCUMENTO) ORDER BY Factura, Proveedor, Requisición", conexion)
            comando.Parameters.AddWithValue("@IDRELACIONDOCUMENTO", IDRELACIONDOCUMENTO)
            adaptador = New SqlDataAdapter(comando)
            Try
                conexion.Open()
                adaptador.Fill(dt_Relacion)
                conexion.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                conexion.Close()
            End Try

            'cargardatasetrelacion = False
        Else
            ImpresionRelacion = True
        End If

        Dim FilaDatoRelacion As DataRow
        FilaDatoRelacion = dt_Relacion(0)

        If VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(imagen, 55, 20, 130, 104)
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 55, 20, 130, 104)
            Case 2 'Zamorana
                e.Graphics.DrawImage(zamorana, 50, 40, 235, 62)
        End Select

        e.Graphics.DrawString("RELACIÓN DE FACTURAS COMPRAS", Formato_Etiqueta_11, Brocha, 320, 23)

        Select Case LogoEmpresa
            Case 0 ' Ismocol
                DrawRoundedRectangle(e.Graphics, 800, 20, 265, 20, 10) 'CUADRO FORMATO
                e.Graphics.DrawString("Formato No. " + "ICS-GRAL-F-18", Formato_Etiqueta_9R, Brocha, 805, 24)
                e.Graphics.DrawLine(Lapiz, 970, 20, 970, 40)
                e.Graphics.DrawString("Rev. No. " + " 2", Formato_Etiqueta_9R, Brocha, 975, 24)
            Case 1
            Case 2 'Zamorana
                DrawRoundedRectangle(e.Graphics, 800, 20, 265, 20, 10) 'CUADRO FORMATO
                e.Graphics.DrawString("Formato ZMA-GRAL-F-050", Formato_Etiqueta_9R, Brocha, 805, 24)
                e.Graphics.DrawLine(Lapiz, 970, 20, 970, 40)
                e.Graphics.DrawString("Rev. No. 0", Formato_Etiqueta_9R, Brocha, 975, 24)
        End Select

        DrawRoundedRectangle(e.Graphics, 310, 45, 755, 80, 10) 'CUADRO INICIAL

        e.Graphics.DrawString("No. ", Formato_Etiqueta_9R, Brocha, 310, 50)
        e.Graphics.DrawString(FilaDatoRelacion("AÑO") + FilaDatoRelacion("MES") + FilaDatoRelacion("CONSECUTIVO"), Formato_Etiqueta_9R, Brocha, 330, 68)

        e.Graphics.DrawLine(Lapiz, 570, 45, 570, 85)

        e.Graphics.DrawString("Tipo:", Formato_Etiqueta_9R, Brocha, 575, 50)
        e.Graphics.DrawString("Contabilizar", Formato_Etiqueta_9R, Brocha, 605, 68)
        e.Graphics.DrawLine(Lapiz, 870, 45, 870, 85)

        e.Graphics.DrawString("Fecha: ", Formato_Etiqueta_9R, Brocha, 875, 50)
        e.Graphics.DrawString(FilaDatoRelacion("FECHADOCUMENTO"), Formato_Etiqueta_9R, Brocha, 905, 68)
        e.Graphics.DrawLine(Lapiz, 310, 85, 1065, 85)

        e.Graphics.DrawString("De:", Formato_Etiqueta_9R, Brocha, 310, 90)
        e.Graphics.DrawString(FilaDatoRelacion("NOMBREDEPENDENCIAORIGEN"), Formato_Etiqueta_9R, Brocha, 340, 108)
        e.Graphics.DrawLine(Lapiz, 570, 85, 570, 125)

        e.Graphics.DrawString("A:", Formato_Etiqueta_9R, Brocha, 575, 90)
        e.Graphics.DrawString(FilaDatoRelacion("NOMBREDEPENDENCIADESTINO"), Formato_Etiqueta_9R, Brocha, 605, 108)
        e.Graphics.DrawLine(Lapiz, 800, 85, 800, 125)

        e.Graphics.DrawString("Bodega Registra:", Formato_Etiqueta_9R, Brocha, 805, 90)
        e.Graphics.DrawString(FilaDatoRelacion("BODEGAREGISTRO"), Formato_Etiqueta_9R, Brocha, 835, 108)
        Dim alinearCuadro As Integer = -30 ' Ayuda a alinear la grilla de datos

        DrawRoundedRectangle(e.Graphics, 55 + alinearCuadro, 140, 1040, 590, 1) 'GRILLA DE DATOS
        e.Graphics.DrawString("Factura", Formato_Etiqueta_7R, Brocha, 75 + alinearCuadro, 150)
        e.Graphics.DrawString("Contrato", Formato_Etiqueta_7R, Brocha, 150 + alinearCuadro, 150)
        e.Graphics.DrawString("Requisición", Formato_Etiqueta_7R, Brocha, 265 + alinearCuadro, 150)
        e.Graphics.DrawString("Proveedor", Formato_Etiqueta_7R, Brocha, 460 + alinearCuadro, 150)
        e.Graphics.DrawString("Orden de Compra", Formato_Etiqueta_7R, Brocha, 615 + alinearCuadro, 150)
        e.Graphics.DrawString("Entrada de Almacen", Formato_Etiqueta_7R, Brocha, 755 + alinearCuadro, 150)
        e.Graphics.DrawString("Otro DCTO", Formato_Etiqueta_7R, Brocha, 905 + alinearCuadro, 150)
        e.Graphics.DrawString("Anexo", Formato_Etiqueta_7R, Brocha, 975 + alinearCuadro, 150)
        e.Graphics.DrawString("Fecha Fact", Formato_Etiqueta_7R, Brocha, 1035 + alinearCuadro, 145)
        e.Graphics.DrawString("Fecha Rad.", Formato_Etiqueta_7R, Brocha, 1035 + alinearCuadro, 155)

        'lineas verticales
        e.Graphics.DrawLine(Lapiz, 145 + alinearCuadro, 140, 145 + alinearCuadro, 730) 'Factura
        e.Graphics.DrawLine(Lapiz, 205 + alinearCuadro, 140, 205 + alinearCuadro, 730) 'Contrato
        e.Graphics.DrawLine(Lapiz, 355 + alinearCuadro, 140, 355 + alinearCuadro, 730) 'Requisición
        e.Graphics.DrawLine(Lapiz, 605 + alinearCuadro, 140, 605 + alinearCuadro, 730) 'Proveedor
        e.Graphics.DrawLine(Lapiz, 745 + alinearCuadro, 140, 745 + alinearCuadro, 730) 'Orden de Compra
        e.Graphics.DrawLine(Lapiz, 895 + alinearCuadro, 140, 895 + alinearCuadro, 730) 'Entrada de Almacen
        e.Graphics.DrawLine(Lapiz, 965 + alinearCuadro, 140, 965 + alinearCuadro, 730) 'Otro DCTO
        e.Graphics.DrawLine(Lapiz, 1035 + alinearCuadro, 140, 1035 + alinearCuadro, 730) 'Anexo

        Dim AlinearHorizontal As Integer = -20
        'lineas horizontales
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 170, 1095 + alinearCuadro, 170)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 230 + AlinearHorizontal, 1095 + alinearCuadro, 230 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 270 + AlinearHorizontal, 1095 + alinearCuadro, 270 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 310 + AlinearHorizontal, 1095 + alinearCuadro, 310 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 350 + AlinearHorizontal, 1095 + alinearCuadro, 350 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 390 + AlinearHorizontal, 1095 + alinearCuadro, 390 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 430 + AlinearHorizontal, 1095 + alinearCuadro, 430 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 470 + AlinearHorizontal, 1095 + alinearCuadro, 470 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 510 + AlinearHorizontal, 1095 + alinearCuadro, 510 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 550 + AlinearHorizontal, 1095 + alinearCuadro, 550 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 590 + AlinearHorizontal, 1095 + alinearCuadro, 590 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 630 + AlinearHorizontal, 1095 + alinearCuadro, 630 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 670 + AlinearHorizontal, 1095 + alinearCuadro, 670 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 710 + AlinearHorizontal, 1095 + alinearCuadro, 710 + AlinearHorizontal)
        e.Graphics.DrawLine(Lapiz, 55 + alinearCuadro, 750 + AlinearHorizontal, 1095 + alinearCuadro, 750 + AlinearHorizontal)

        Dim TotalGrilla As Integer = 1

        TotalPaginas = -Int(-dt_Relacion.Rows.Count / 14)

        For i = ContadorFacturasRelacionadas To dt_Relacion.Rows.Count - 1
            Dim FilaRelacion As DataRow

            FilaRelacion = dt_Relacion.Rows(i)

            e.Graphics.DrawString(Mid(FilaRelacion("Factura"), 1, 10), Formato_Etiqueta_8R, Brocha, 65 + alinearCuadro, 140 + (40 * TotalGrilla))
            e.Graphics.DrawString(Mid(FilaRelacion("Factura"), 11, 10), Formato_Etiqueta_8R, Brocha, 65 + alinearCuadro, 140 + (40 * TotalGrilla) + 15)

            e.Graphics.DrawString(Mid(FilaRelacion("Contrato"), 1, 10), Formato_Etiqueta_7R, Brocha, 145 + alinearCuadro, 140 + (40 * TotalGrilla))
            e.Graphics.DrawString(Mid(FilaRelacion("Contrato"), 11, 10), Formato_Etiqueta_7R, Brocha, 145 + alinearCuadro, 140 + (40 * TotalGrilla) + 15)

            e.Graphics.DrawString(FilaRelacion("Requisición"), Formato_Etiqueta_8R, Brocha, 210 + alinearCuadro, 140 + (40 * TotalGrilla))

            Dim proveedor As String = FilaRelacion("Proveedor")
            If proveedor.Length > 30 Then
                Dim proveedor1 As String = Mid(proveedor, 1, 30)
                proveedor1 = Trim(Mid(proveedor, 1, 30))
                e.Graphics.DrawString(proveedor1, Formato_Etiqueta_8R, Brocha, 360 + alinearCuadro, 135 + (40 * TotalGrilla))

                proveedor = Trim(Mid(proveedor, proveedor1.Count + 1, proveedor.Length))
                Dim proveedor2 As String = Trim(Mid(proveedor, 1, 30))
                proveedor2 = Trim(Mid(proveedor, 1, 30))
                e.Graphics.DrawString(proveedor2, Formato_Etiqueta_8R, Brocha, 360 + alinearCuadro, 147 + (40 * TotalGrilla))
            Else
                e.Graphics.DrawString(FilaRelacion("Proveedor"), Formato_Etiqueta_8R, Brocha, 360 + alinearCuadro, 140 + (40 * TotalGrilla))
            End If

            e.Graphics.DrawString(FilaRelacion("Orden de Compra"), Formato_Etiqueta_7R, Brocha, 610 + alinearCuadro, 140 + (40 * TotalGrilla))
            e.Graphics.DrawString(FilaRelacion("Entrada"), Formato_Etiqueta_8R, Brocha, 755 + alinearCuadro, 140 + (40 * TotalGrilla))
            'e.Graphics.DrawString(FilaRelacion("Entrada"), Formato_Etiqueta_8R, Brocha, 760, 210 + (50 * TotalGrilla ))

            Dim Anexo As String = FilaRelacion("Anexo")

            If Anexo.Length > 10 Then
                If Anexo.Length > 20 Then
                    If Anexo.Length > 30 Then
                        e.Graphics.DrawString(Mid(Anexo, 1, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 130 + (40 * TotalGrilla))
                        e.Graphics.DrawString(Mid(Anexo, 11, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 140 + (40 * TotalGrilla))
                        e.Graphics.DrawString(Mid(Anexo, 21, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 150 + (40 * TotalGrilla))
                        e.Graphics.DrawString(Mid(Anexo, 31, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 160 + (40 * TotalGrilla))
                    Else
                        e.Graphics.DrawString(Mid(Anexo, 1, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 130 + (40 * TotalGrilla))
                        e.Graphics.DrawString(Mid(Anexo, 11, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 140 + (40 * TotalGrilla))
                        e.Graphics.DrawString(Mid(Anexo, 21, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 150 + (40 * TotalGrilla))
                    End If
                Else
                    e.Graphics.DrawString(Mid(Anexo, 1, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 135 + (40 * TotalGrilla))
                    e.Graphics.DrawString(Mid(Anexo, 11, 10), Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 145 + (40 * TotalGrilla))
                End If
            Else
                e.Graphics.DrawString(Anexo, Formato_Etiqueta_7R, Brocha, 898 + alinearCuadro, 140 + (40 * TotalGrilla))
            End If

            If IsDBNull(FilaRelacion("Fecha Documento")) = False Then
                e.Graphics.DrawString(CStr((FilaRelacion("Fecha Documento")).Day) + "/" + CStr(CDate(FilaRelacion("Fecha Documento")).Month) + "/" + CStr(CDate(FilaRelacion("Fecha Documento")).Year), Formato_Etiqueta_8R, Brocha, 1040 + alinearCuadro, 135 + (40 * TotalGrilla))
            End If

            If IsDBNull(FilaRelacion("Fecha Radicado")) = False Then
                e.Graphics.DrawString(CStr((FilaRelacion("Fecha Radicado")).day) + "/" + CStr(CDate(FilaRelacion("Fecha Radicado")).Month) + "/" + CStr(CDate(FilaRelacion("Fecha Radicado")).Year), Formato_Etiqueta_8R, Brocha, 1040 + alinearCuadro, 150 + (40 * TotalGrilla))
            End If

            TotalGrilla = TotalGrilla + 1
            ContadorFacturasRelacionadas = ContadorFacturasRelacionadas + 1

            If TotalGrilla > 14 Then
                Exit For
            End If
        Next

        e.Graphics.DrawString("Digitado por: " + FilaDatoRelacion("NombreRegistra"), Formato_Etiqueta_7R, Brocha, 80, 790)
        e.Graphics.DrawLine(Lapiz, 70, 780, 239, 780)

        e.Graphics.DrawLine(Lapiz, 500, 780, 700, 780)
        e.Graphics.DrawString("Jefe Dpto. de materiales", Formato_Etiqueta_7R, Brocha, 510, 790)

        If dt_Relacion.Rows.Count = ContadorFacturasRelacionadas Then
            If ContadorFacturasRelacionadas Mod 14 = 0 And ContadorFacturasRelacionadas <> 0 Then
                e.Graphics.DrawString("Página " & TotalPaginas & " de " & TotalPaginas, Formato_Etiqueta_7R, Brocha, 800, 790)
            Else
                Dim InicioYdeItemOC As Integer = 140
                Dim EspacioVertical As Integer = 40
                e.Graphics.DrawString("|---------------------------------------| Ultima Fila |---------------------------------------|", Formato_Etiqueta_9R, Brocha, 350, InicioYdeItemOC + (EspacioVertical * TotalGrilla))
                e.Graphics.DrawString("Página " & TotalPaginas & " de " & TotalPaginas, Formato_Etiqueta_7R, Brocha, 800, 790)
            End If
            ContadorFacturasRelacionadas = 0
            e.HasMorePages = False
        Else
            e.Graphics.DrawString("Página " & PaginasRelacion & " de " & TotalPaginas, Formato_Etiqueta_7R, Brocha, 800, 790)
            PaginasRelacion = PaginasRelacion
            e.HasMorePages = True
        End If
        ImpresionPaginas = ImpresionPaginas + 1
        If ImpresionRelacion And ImpresionPaginas = (TotalPaginas * 2) Then 'Si ya imprimio entra y cambia el valor de impresa en la tabla SALIDAALMACEN
            GuardarImpresionRelacion()
        End If
    End Sub

    Private Sub GuardarImpresionRelacion()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure

            Comando.Parameters.AddWithValue("@TIPO", 12)

            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IDRELACIONDOCUMENTO)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch

        End Try
    End Sub

#End Region

#Region "73 - ICS-GRAL-F-102 REMISION DE MATERIALES VALORIZADA"

    Dim WithEvents DocImp_RemisiónDeMaterialesValorizada As New PrintDocument 'Documento a imprimir
    Dim ValorTotalRemision As Decimal = 0
    Dim paginastotalRemisionVal As Integer = 0
    Dim copiasRemisionVal As Integer = 0
    Dim contcopiasRemisionVal As Integer = 0
    Dim contadorcopiasRVal As Integer = 0



    Private Sub DocImpRemisiónDeMaterialesValorizada(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RemisiónDeMaterialesValorizada.PrintPage
        If cargardatasetremisión = True Then
            _copiaparadestinatario = copiaparadestinatario
            _copiaparatransportador = copiaparatransportador
            _copiaparaporteriasalida = copiaparaporteriasalida
            _copiaparaconsecutivo = copiaparaconsecutivo

            Dim Cadena_Consulta As String =
           "SELECT * FROM dbo.ImprimirRemisión(" + IDREMISIONIMPRESION.ToString + ") ORDER BY IDITEMSALIDAALMACEN"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            dt_Remisión = New DataTable
            Adaptador.FillSchema(dt_Remisión, SchemaType.Source)
            Adaptador.Fill(dt_Remisión)
            Consulta.Connection.Close()
            FilaRemisión = dt_Remisión.Rows(0)

            cargardatasetremisión = False
            paginastotalRemisionVal = 0
            If Me.copiaparadestinatario = True Then
                copiasRemisionVal += 1
            End If
            If Me.copiaparatransportador = True Then
                copiasRemisionVal += 1
            End If
            If Me.copiaparaconsecutivo = True Then
                copiasRemisionVal += 1
            End If
            If Me.copiaparaporteriasalida = True Then
                copiasRemisionVal += 1
            End If

            'Calcular valor total de la remisión.
            For i = ContadorItemRemisión To dt_Remisión.Rows.Count - 1
                Dim filaItemRemision As DataRow
                filaItemRemision = dt_Remisión.Rows(i)
                ValorTotalRemision += filaItemRemision("VALORUNITARIOIVA") * filaItemRemision("CANTIDAD")
            Next
        End If

Line2:

        If Me.copiaparadestinatario = True Then
            copiapara = "DESTINATARIO"
            contadorcopiasRVal += 1
        Else
            If copiaparatransportador = True Then
                copiapara = "TRANSPORTADOR"
                contadorcopiasRVal += 1
            Else
                If copiaparaconsecutivo = True Then
                    copiapara = "CONSECUTIVO"
                    contadorcopiasRVal += 1
                Else
                    If copiaparaporteriasalida = True Then
                        copiapara = "PORTERÍA SALIDA"
                        contadorcopiasRVal += 1
                        Me.copiaparaporteriasalida = False
                    End If
                End If
            End If
        End If

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10, 10)
        Brocha.Color = Color.Black

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaRemisión("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Trim(FilaRemisión("ABREVIATURABODEGAORIGEN"))) Then
            If MsgBox("¿Desea imprimir la requisición con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' Logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If
        Dim AlturaInicioImpresion As Integer

        Dim CantidadArticulos As Integer = dt_Remisión.Rows.Count
        Dim CantidadEquipos As Integer = 0
        For i As Integer = 0 To dt_Remisión.Rows.Count - 1
            Dim filaCantItemRemision As DataRow 'Articulos
            filaCantItemRemision = dt_Remisión.Rows(i)
            Dim dscantequipos As New DataSet 'Equipos asociados al articulo
            dscantequipos = bddatos.ModificarCustodias(9, 0, filaCantItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
            CantidadEquipos += dscantequipos.Tables(0).Rows.Count
        Next

        'Se Verifica la cantidad de items de la remision
        If MediaCarta2 = True Then
            Dim CantidadLineasOcupa As Integer = 0
            For i As Integer = 0 To dt_Remisión.Rows.Count - 1
                If Trim(dt_Remisión.Rows(i).Item("NOMBREDESCRIPTIVO").ToString).Length < 91 Then
                    CantidadLineasOcupa += 1
                Else
                    If Trim(dt_Remisión.Rows(i).Item("NOMBREDESCRIPTIVO").ToString).Length < 181 Then
                        CantidadLineasOcupa += 2
                    Else
                        CantidadLineasOcupa += 3
                    End If
                End If

                Dim dscantequipos As New DataSet 'Equipos asociados al articulo
                dscantequipos = bddatos.ModificarCustodias(9, 0, dt_Remisión.Rows(i).Item("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                If dscantequipos.Tables(0).Rows.Count > 0 Then
                    Dim CadenaEquipos As String = "Códigos: "
                    For j As Integer = 0 To dscantequipos.Tables(0).Rows.Count - 1
                        CadenaEquipos += dscantequipos.Tables(0).Rows(j)("CODIGO")
                        If j <> dscantequipos.Tables(0).Rows.Count - 1 Then
                            CadenaEquipos += ", "
                        End If
                    Next

                    Dim ArrayEquipos As New ArrayList
                    Dim ArrayEquiposTotal As New ArrayList
                    ArrayEquipos.Add(Trim(CadenaEquipos))
                    If dscantequipos.Tables(0).Rows.Count < 3 Then
                        ArrayEquiposTotal = TextoAParrafoFuente(ArrayEquipos, Formato_Etiqueta_5, 310, e)
                    Else
                        ArrayEquiposTotal = TextoAParrafoFuente(ArrayEquipos, Formato_Etiqueta_4, 310, e)
                    End If

                    If ArrayEquiposTotal(ArrayEquiposTotal.Count - 1) = "" Then
                        ArrayEquiposTotal.RemoveAt(ArrayEquiposTotal.Count - 1)
                    End If
                    CantidadLineasOcupa += ArrayEquiposTotal.Count
                End If

            Next

            If CantidadLineasOcupa > 5 Then
                MediaCarta2 = False
                If contadorcopiasRVal = 1 Then
                    MsgBox("No se pudo imprimir en media carta.")
                End If
            End If
        End If

        If MediaCarta2 = True Then
            Dim Modulo As Integer
            Modulo = contadorcopiasRVal Mod 2
            If Modulo = 1 Then
                AlturaInicioImpresion = 20
            Else
                AlturaInicioImpresion = 550
            End If

            Dim PiePagina As String = ""
            PiePagina = "Página 1 de 1"

            Dim tipoenvio As String = ""
            If Not IsDBNull(FilaRemisión("TIPOENVIO")) Then
                tipoenvio = FilaRemisión("TIPOENVIO")
            Else
                tipoenvio = "N"
            End If


            Select Case LogoEmpresa
                Case 0 'ISMOCOL S.A.
                    'Cambiar el tamaño del logo dependiendo si tiene 1 o mas items y se ubica mas arriba
                    e.Graphics.DrawImage(imagen, 35, AlturaInicioImpresion, 60, 55)
                    'Se ubica arriba la caja del formato
                    e.Graphics.DrawRectangle(Lapiz, 700, AlturaInicioImpresion, 100, 30)
                    e.Graphics.DrawLine(Lapiz, 700, AlturaInicioImpresion + 15, 800, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString("ICS - GRAL - F - 102", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 2)
                    e.Graphics.DrawString("   REVISIÓN No. 1", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 18)
                    e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion - 5)
                    e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 10)
                    e.Graphics.DrawString("VALORIZADA", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 25)
                    e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 445 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 120, e), AlturaInicioImpresion + 4)
                    e.Graphics.DrawLine(Lapiz, 445, AlturaInicioImpresion + 15, 565, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, Brocha, 445 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, 120, e), AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 590, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 590, AlturaInicioImpresion + 5)
                    DrawRoundedRectangle(e.Graphics, 445, AlturaInicioImpresion, 120, 40, 15)

                    Select Case tipoenvio
                        Case "E", "I"
                            'If copiapara <> "TRANSPORTADOR" Then
                            e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 290, AlturaInicioImpresion + 5)
                            e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_11, e, 90), Formato_Etiqueta_13, Brushes.Black, 290, AlturaInicioImpresion + 20)
                            'End If
                            If FilaRemisión("TIPOENVIO") = "E" Then
                                'If True = True Then
                                e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                            ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                                e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                            End If
                        Case Else
                            'If copiapara <> "TRANSPORTADOR" Then
                            e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 290, AlturaInicioImpresion + 5)
                            e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_10, e, 90), Formato_Etiqueta_13, Brushes.Black, 290, AlturaInicioImpresion + 20)
                            'End If
                    End Select
                Case 1 'CSI
                    e.Graphics.DrawImage(imagenCSI, 35, AlturaInicioImpresion, 60, 55)
                    e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion - 5)
                    e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 10)
                    e.Graphics.DrawString("VALORIZADA", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 25)
                    e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 543 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 120, e), AlturaInicioImpresion + 4)
                    e.Graphics.DrawLine(Lapiz, 543, AlturaInicioImpresion + 15, 663, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, Brocha, 543 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, 120, e), AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 680, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 680, AlturaInicioImpresion + 5)
                    DrawRoundedRectangle(e.Graphics, 543, AlturaInicioImpresion, 120, 40, 15)
                    Select Case tipoenvio
                        Case "E", "I"
                            'If copiapara <> "TRANSPORTADOR" Then
                            e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 330, AlturaInicioImpresion + 5)
                            e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_11, e, 90), Formato_Etiqueta_13, Brushes.Black, 330, AlturaInicioImpresion + 20)
                            'End If
                            If FilaRemisión("TIPOENVIO") = "E" Then
                                'If True = True Then
                                e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                            ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                                e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                            End If
                        Case Else
                            'If copiapara <> "TRANSPORTADOR" Then
                            e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 330, AlturaInicioImpresion + 5)
                            e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_10, e, 90), Formato_Etiqueta_13, Brushes.Black, 330, AlturaInicioImpresion + 20)
                            'End If
                    End Select
                Case 2 'ZAMORANA
                    e.Graphics.DrawImage(zamorana, 35, AlturaInicioImpresion, 170, 45)
                    e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_10, Brushes.Black, 220, AlturaInicioImpresion - 5)
                    e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_11, Brushes.Black, 220, AlturaInicioImpresion + 10)
                    e.Graphics.DrawString("VALORIZADA", Formato_Etiqueta_10, Brushes.Black, 220, AlturaInicioImpresion + 25)
                    e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 543 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 120, e), AlturaInicioImpresion + 4)
                    e.Graphics.DrawLine(Lapiz, 543, AlturaInicioImpresion + 15, 663, AlturaInicioImpresion + 15)
                    e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, Brocha, 543 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, 120, e), AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 680, AlturaInicioImpresion + 20)
                    e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 680, AlturaInicioImpresion + 5)
                    DrawRoundedRectangle(e.Graphics, 543, AlturaInicioImpresion, 120, 40, 15)
                    Select Case tipoenvio
                        Case "E", "I"
                            'If copiapara <> "TRANSPORTADOR" Then
                            e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 380, AlturaInicioImpresion + 5)
                            e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_11, e, 90), Formato_Etiqueta_13, Brushes.Black, 380, AlturaInicioImpresion + 20)
                            'End If
                            If FilaRemisión("TIPOENVIO") = "E" Then
                                'If True = True Then
                                e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                            ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                                e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                            End If
                        Case Else
                            'If copiapara <> "TRANSPORTADOR" Then
                            e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 380, AlturaInicioImpresion + 5)
                            e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_10, e, 90), Formato_Etiqueta_13, Brushes.Black, 380, AlturaInicioImpresion + 20)
                            'End If
                    End Select
            End Select


            Dim AltRectInicial, AltRectDos, AltRectTres, AltRecCuatro, AltRecCinco As Integer
            AltRectInicial = AlturaInicioImpresion + 60
            AltRectDos = AlturaInicioImpresion + 105
            AltRectTres = AlturaInicioImpresion + 125
            AltRecCuatro = AlturaInicioImpresion + 388
            AltRecCinco = AlturaInicioImpresion + 411
            DrawRoundedRectangle(e.Graphics, 30, AltRectInicial, 770, 35, 15) 'Primer Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRectDos, 770, 15, 10) 'Segundo Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRectTres, 770, 249, 15) 'Tercer Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRecCuatro, 770, 20, 15) 'Cuarto Rectangulo redondeado grande
            DrawRoundedRectangle(e.Graphics, 30, AltRecCinco, 770, 93, 15) 'Quinto Rectangulo redondeado grande

            Dim AltLineasPrimerRec As Integer
            AltLineasPrimerRec = AlturaInicioImpresion + 45
            e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 580, AltLineasPrimerRec) 'horizontal
            e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 130, AltLineasPrimerRec + 50) 'Vertical
            e.Graphics.DrawLine(Lapiz, 320, AltLineasPrimerRec, 320, AltLineasPrimerRec + 50) 'Vertical
            e.Graphics.DrawLine(Lapiz, 420, AltLineasPrimerRec, 420, AltLineasPrimerRec + 50) 'Vertical
            e.Graphics.DrawLine(Lapiz, 580, AltLineasPrimerRec, 580, AltLineasPrimerRec + 15) 'Vertical
            e.Graphics.DrawString("NOMBRE BODEGA", Formato_Etiqueta_6, Brocha, 165, AltLineasPrimerRec + 3)
            e.Graphics.DrawString("CLAVE", Formato_Etiqueta_6, Brocha, 340, AltLineasPrimerRec + 3)
            e.Graphics.DrawString("SA: " + FilaRemisión("SALIDAALMACEN"), Formato_Etiqueta_6, Brocha, 430, AltLineasPrimerRec + 3)
            e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 20)
            Dim bodega As String = Trim(FilaRemisión("BODEGAORIGEN"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 20)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 17)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 27)
                    Else
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 20)
                    End If
            End Select
            e.Graphics.DrawString(FilaRemisión("ABREVIATURABODEGAORIGEN"), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 20)
            e.Graphics.DrawLine(Lapiz, 30, AltLineasPrimerRec + 34, 800, AltLineasPrimerRec + 34)
            e.Graphics.DrawString("CIUDAD Y FECHA", Formato_Etiqueta_7, Brocha, 550, AltLineasPrimerRec + 20)
            e.Graphics.DrawString("DESTINO", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 37)
            bodega = Trim(FilaRemisión("DESTINO"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 37)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                    Else
                        e.Graphics.DrawString(Mid(bodega, 1, 50), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                        e.Graphics.DrawString(Mid(bodega, 50, 100), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                    End If
            End Select
            e.Graphics.DrawString(Trim(FilaRemisión("ABREVIATURADESTINO")), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 37)
            Dim Ciuyfechas As String = Trim(FilaRemisión("CIUDAD").ToString) + "   /  " + FilaRemisión("FECHA")
            e.Graphics.DrawString(Ciuyfechas, Formato_Etiqueta_7, Brocha, 420 + InicioCentradoTexto(Ciuyfechas, Formato_Etiqueta_8, 380, e), AltLineasPrimerRec + 37)
            e.Graphics.DrawString("DESPACHADO VÍA:  " + FilaRemisión("DESPACHADO"), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 50)

            Dim observa As String = Trim(FilaRemisión("OBSERVACION"))
            If observa.Length > 140 Then
                Dim observa1 As String = Trim(Mid(observa, 1, 140))
                Dim pos As Integer
                pos = observa1.LastIndexOf(" ")
                observa1 = Trim(Mid(observa, 1, pos))
                e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_5, Brocha, 35, AltLineasPrimerRec + 60)
                observa = Trim(Mid(observa, pos + 1, observa.Length))
                e.Graphics.DrawString(observa, Formato_Etiqueta_5, Brocha, 83, AltLineasPrimerRec + 67)
            Else
                e.Graphics.DrawString("Observación: " + Mid(observa, 1, 140), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 63)
            End If


            e.Graphics.DrawString("REQUISICIÓN", Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto("REQUISICIÓN", Formato_Etiqueta_6, 90, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 120, AltRectTres, 120, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 150, AltRectTres, 150, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto("UN/M", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 180, AltRectTres, 180, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
            e.Graphics.DrawString("DESPACHADA", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("DESPACHADA", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
            e.Graphics.DrawLine(Lapiz, 240, AltRectTres, 240, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
            e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("ARTÍCULO", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
            e.Graphics.DrawLine(Lapiz, 300, AltRectTres, 300, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, 300 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_7, 320, e), AltRectTres + 5)
            e.Graphics.DrawLine(Lapiz, 620, AltRectTres, 620, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("ORDEN DE", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("ORDEN DE", Formato_Etiqueta_5, 100, e), AltRectTres + 3)
            e.Graphics.DrawString("COMPRA", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("COMPRA", Formato_Etiqueta_5, 100, e), AltRectTres + 10)
            e.Graphics.DrawLine(Lapiz, 720, AltRectTres, 720, AltRectTres + 72) 'vertical

            e.Graphics.DrawString("VALOR", Formato_Etiqueta_6, Brocha, 720 + InicioCentradoTexto("VALOR", Formato_Etiqueta_6, 80, e), AltRectTres + 5)

            e.Graphics.DrawLine(Lapiz, 30, AltRectTres + 21, 800, AltRectTres + 21) 'horizontal

            Dim lineaPunteada As New Pen(Color.Gray, 1)
            lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

            Dim InicioYdeItemRem As Integer
            InicioYdeItemRem = AlturaInicioImpresion + 147

            ContadorItemRemisión = CantidadArticulos
            contcopiasRemision += 1

            '-----------------------------------

            Const CantidadRenglones As Integer = 6
            Const EspacioVertical As Integer = 9

            Dim InicioImpresionItems As Integer
            InicioImpresionItems = AlturaInicioImpresion + 147
            Dim ContadorRenglones2 As Integer = 0

            For i As Integer = 0 To CantidadArticulos - 1
                Dim filaItemRemision As DataRow
                filaItemRemision = dt_Remisión.Rows(i)
                Dim Cadenas1 As New ArrayList
                Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
                Dim Cadena_Total1 As New ArrayList
                Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                Dim tempTexto As String = ""
                tempTexto = IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION"))
                e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 30 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_5, Brocha, 120 + InicioCentradoTexto(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_5, Brocha, 150 + InicioCentradoTexto(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                tempTexto = IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA"))
                e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                ContadorRenglones = 0
                Dim LargoArticulo As Integer = Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                    Case Is < 73
                        e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 91
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 2)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 141
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 71, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + 10)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 181
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 10)
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 9)
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 181, 90), Formato_Etiqueta_4, Brocha, 302, InicioYdeItemRem + 18)
                        ContadorRenglones = ContadorRenglones + 1
                End Select

                e.Graphics.DrawString(FormatearValor(CDec(filaItemRemision("VALORUNITARIOIVA") * filaItemRemision("CANTIDAD")), "$", Formato_Etiqueta_6, e, 70), Formato_Etiqueta_6, Brocha, _
                         725, InicioYdeItemRem)
                '------------componentes------------

                Dim dsequipos As New DataSet
                'Const EspacioVertical As Integer = 9
                dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                If dsequipos.Tables(0).Rows.Count > 0 Then
                    'crear la cadena de códigos
                    Dim cadenaEquipos As String
                    cadenaEquipos = "Códigos: "
                    Dim j As Integer
                    For j = 0 To dsequipos.Tables(0).Rows.Count - 1
                        cadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                        If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                            cadenaEquipos += ", "
                        End If
                    Next
                    Cadenas1.Clear()
                    Cadenas1.Add(Trim(cadenaEquipos))
                    Dim formatoetiqueta
                    If dsequipos.Tables(0).Rows.Count < 3 Then
                        Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)
                        formatoetiqueta = Formato_Etiqueta_5
                    Else
                        Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_4, 310, e)
                        formatoetiqueta = Formato_Etiqueta_4
                    End If

                    Dim resta As Integer
                    resta = 0
                    e.Graphics.DrawLine(lineaPunteada, 300, InicioYdeItemRem + (ContadorRenglones * EspacioVertical), 620, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))  'Horizontal
                    For k = 0 To Cadena_Total1.Count - 2
                        If k <> 0 Then
                            resta = 2
                        End If
                        e.Graphics.DrawString(Cadena_Total1(k), formatoetiqueta, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical) - resta)
                        ContadorRenglones = ContadorRenglones + 1
                        If ContadorRenglones >= CantidadRenglones Then
                            'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                            Dim cadena2 As New ArrayList
                            For z = k + 1 To Cadena_Total1.Count - 2
                                cadena2.Add(Cadena_Total1(z))
                            Next
                            listaComponentes = cadena2
                            ContadorItemRemisión = ContadorItemRemisión - 1
                            completarcomponentes = True
                            Exit For
                        End If
                    Next

                End If
                '-----------------------------------
                ContadorRenglones2 += ContadorRenglones
                If ContadorRenglones2 <= CantidadRenglones - 1 Then
                    e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem + (EspacioVertical * ContadorRenglones)) 'horizontal
                End If
                InicioYdeItemRem = InicioYdeItemRem + (ContadorRenglones * EspacioVertical)
            Next

            e.Graphics.DrawLine(Lapiz, 30, InicioImpresionItems + 50, 800, InicioImpresionItems + 50) 'horizontal

            Dim InicioLineas As Integer = InicioImpresionItems + 54

            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 83) 'vertical
            e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 83) 'vertical
            e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 83) 'vertical
            e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 83) 'vertical

            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 160, InicioLineas + 3)
            e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 315, InicioLineas + 3)
            e.Graphics.DrawString("VERIFICA", Formato_Etiqueta_7, Brocha, 510, InicioLineas + 3)
            e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 690, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas) 'horizontal


            e.Graphics.DrawString(FilaRemisión("DIGITA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(FilaRemisión("DIGITA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
            e.Graphics.DrawString(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, Brocha, 280 + InicioCentradoTexto(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
            e.Graphics.DrawString(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, Brocha, 460 + InicioCentradoTexto(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, 170, e), InicioLineas + 53) 'Verifica

            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 32
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17

            e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 89) 'vertical
            e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
            e.Graphics.DrawString("ENVIO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 72) 'vertical
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
            e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 10)
            e.Graphics.DrawString(FilaRemisión("TRANSPORTADOR"), Formato_Etiqueta_7, Brocha, 400, InicioLineas + 10)

            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 22
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            Dim Despacho As String = FilaRemisión("DESPACHADO")

            If Despacho.Length > 50 Then
                e.Graphics.DrawString(Mid(Despacho, 1, 45), Formato_Etiqueta_5, Brocha, 105, InicioLineas)
                e.Graphics.DrawString(Mid(Despacho, 46, 90), Formato_Etiqueta_5, Brocha, 105, InicioLineas + 7)
            Else
                e.Graphics.DrawString(Despacho, Formato_Etiqueta_6, Brocha, 105, InicioLineas + 3)
            End If

            e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawString(FilaRemisión("GUIA"), Formato_Etiqueta_8, Brocha, 400, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 19

            e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_6, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 9, 100, InicioLineas + 11) 'vertical
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 9, 330, InicioLineas + 11) 'vertical
            e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 9, 580, InicioLineas + 11) 'vertical
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas - 4)
            e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas - 4)
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas - 4)
            InicioLineas = InicioLineas + 20

            e.Graphics.DrawString("RECIBEN Y VERIFICAN", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 15
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 2, 100, InicioLineas + 72) 'vertical seccion reciben y verifican
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 2, 330, InicioLineas + 72) 'vertical seccion reciben y verifican
            e.Graphics.DrawLine(Lapiz, 590, InicioLineas - 2, 590, InicioLineas + 72) 'vertical seccion reciben y verifican
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 2, 800, InicioLineas - 2) 'Horizontal seccion reciben y verifican
            e.Graphics.DrawString("SEGURIDAD FÍSICA", Formato_Etiqueta_7, Brocha, 150, InicioLineas)
            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 420, InicioLineas)
            e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7, Brocha, 650, InicioLineas)
            InicioLineas = InicioLineas + 10
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas + 1, 800, InicioLineas + 1) 'horizontal seccion reciben y verifican
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
            InicioLineas = InicioLineas + 30
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
            e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)


            If contadorcopiasRVal = 1 Or contadorcopiasRVal = 3 Then
                e.Graphics.DrawLine(lineaPunteada, 0, InicioLineas + 23, 1000, InicioLineas + 23) 'horizontal
            End If

            If ContadorItemRemisión >= dt_Remisión.Rows.Count Then
                If contcopiasRemision = copiasRemisionVal Then
                    e.HasMorePages = False
                    paginastotalRemision = contpaginas
                    contcopiasRemision = 0
                    copiaparadestinatario = _copiaparadestinatario
                    copiaparatransportador = _copiaparatransportador
                    copiaparaporteriasalida = _copiaparaporteriasalida
                    copiaparaconsecutivo = _copiaparaconsecutivo
                Else
                    e.HasMorePages = True
                    If Me.copiaparadestinatario = True Then
                        Me.copiaparadestinatario = False
                    Else
                        If copiaparatransportador = True Then
                            Me.copiaparatransportador = False
                        Else
                            If copiaparaconsecutivo = True Then
                                Me.copiaparaconsecutivo = False
                            Else
                                If copiaparaporteriasalida = True Then
                                    Me.copiaparaporteriasalida = False
                                End If
                            End If
                        End If
                    End If
                End If
                'Reinicio de variables
                contpaginas = 1
                ContadorRenglones = 0
                ContadorItemRemisión = 0
            Else
                contpaginas = contpaginas + 1
                ContadorRenglones = 0
                e.HasMorePages = True
            End If

            If e.HasMorePages = True Then
                If contadorcopiasRVal = 1 Or contadorcopiasRVal = 3 Then GoTo Line2
            Else
                contadorcopiasRVal = 0
            End If

            '**************Cuando la remision tiene mas de un item**************
        Else

            Select Case LogoEmpresa
                Case 0 'ISMOCOL S.A.
                    e.Graphics.DrawImage(imagen, 35, 40, 75, 60)
                Case 1 'CSI
                    e.Graphics.DrawImage(imagenCSI, 35, 40, 75, 60)
                Case 2 'ZAMORANA
                    e.Graphics.DrawImage(zamorana, 35, 40, 170, 45)
            End Select

            DrawRoundedRectangle(e.Graphics, 605, 48, 195, 70, 15)
            DrawRoundedRectangle(e.Graphics, 30, 122, 770, 40, 15)
            DrawRoundedRectangle(e.Graphics, 30, 181, 770, 22, 15)
            DrawRoundedRectangle(e.Graphics, 30, 208, 770, 660, 15)
            DrawRoundedRectangle(e.Graphics, 30, 884, 770, 25, 15)
            DrawRoundedRectangle(e.Graphics, 30, 911, 770, 110, 15)

            Dim tipoenvio As String = ""
            If Not IsDBNull(FilaRemisión("TIPOENVIO")) Then
                tipoenvio = FilaRemisión("TIPOENVIO")
            Else
                tipoenvio = "N"
            End If
            tipoenvio = "I"
            Select Case tipoenvio
                Case "E", "I"
                    e.Graphics.DrawString("REMISIÓN DE MATERIALES VALORIZADA", Formato_Etiqueta_15, Brushes.Black, 110 + InicioCentradoTexto("REMISIÓN DE MATERIALES VALORIZADA", Formato_Etiqueta_15, 490, e), 40)
                    'If copiapara <> "TRANSPORTADOR" Then
                    e.Graphics.DrawString("TOTAL: " + FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_13, e, 140), Formato_Etiqueta_13, Brushes.Black, _
                                          110 + InicioCentradoTexto("TOTAL: " + FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_13, e, 140), Formato_Etiqueta_13, 490, e), 62)
                    'End If
                    If FilaRemisión("TIPOENVIO") = "E" Then
                        e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_12, Brushes.Black, 110 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 490, e), 82)
                    ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                        e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_12, Brushes.Black, 110 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 490, e), 82)
                    End If
                Case Else
                    e.Graphics.DrawString("REMISIÓN DE MATERIALES VALORIZADA", Formato_Etiqueta_15, Brushes.Black, 110 + InicioCentradoTexto("REMISIÓN DE MATERIALES VALORIZADA", Formato_Etiqueta_15, 490, e), 50)
                    'If copiapara <> "TRANSPORTADOR" Then
                    e.Graphics.DrawString("TOTAL: " + FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_13, e, 140), Formato_Etiqueta_13, Brushes.Black, _
                                          110 + InicioCentradoTexto("TOTAL: " + FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_13, e, 140), Formato_Etiqueta_13, 490, e), 75)
                    'End If
            End Select

            e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_8, Brocha, 675, 53)
            e.Graphics.DrawLine(Lapiz, 605, 70, 800, 70)
            e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_16, Brocha, 610 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_16, 185, e), 75)

            e.Graphics.DrawLine(Lapiz, 130, 105, 580, 105) 'horizontal
            e.Graphics.DrawLine(Lapiz, 130, 105, 130, 162) 'Vertical
            e.Graphics.DrawLine(Lapiz, 320, 105, 320, 162) 'Vertical
            e.Graphics.DrawLine(Lapiz, 420, 105, 420, 162) 'Vertical
            e.Graphics.DrawLine(Lapiz, 580, 105, 580, 123) 'Vertical
            e.Graphics.DrawString("NOMBRE BODEGA", Formato_Etiqueta_7, Brocha, 165, 110)
            e.Graphics.DrawString("CLAVE", Formato_Etiqueta_7, Brocha, 340, 110)
            e.Graphics.DrawString("SA: " + FilaRemisión("SALIDAALMACEN"), Formato_Etiqueta_7, Brocha, 430, 110)
            e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_7, Brocha, 35, 128)

            Dim bodega As String = Trim(FilaRemisión("BODEGAORIGEN"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_8, Brocha, 135, 128)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, 124)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, 134)
                    Else
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, 128)
                    End If
            End Select

            e.Graphics.DrawString(FilaRemisión("ABREVIATURABODEGAORIGEN"), Formato_Etiqueta_8, Brocha, 343, 128)
            e.Graphics.DrawLine(Lapiz, 30, 143, 800, 143) 'horizontal

            e.Graphics.DrawString("CIUDAD Y FECHA", Formato_Etiqueta_7, Brocha, 550, 128)
            e.Graphics.DrawString("DESTINO", Formato_Etiqueta_7, Brocha, 35, 148)

            bodega = Trim(FilaRemisión("DESTINO"))
            Select Case bodega.Length
                Case Is < 23
                    e.Graphics.DrawString(bodega, Formato_Etiqueta_8, Brocha, 135, 148)
                Case Else
                    If bodega.Length > 33 Then
                        e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, 144)
                        e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, 154)
                    Else
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, 148)
                    End If
            End Select

            e.Graphics.DrawString(Trim(FilaRemisión("ABREVIATURADESTINO")), Formato_Etiqueta_8, Brocha, 343, 148)
            Dim Ciuyfechas As String = Trim(FilaRemisión("CIUDAD").ToString) + "  /  " + FilaRemisión("FECHA")
            e.Graphics.DrawString(Ciuyfechas, Formato_Etiqueta_8, Brocha, 420 + InicioCentradoTexto(Ciuyfechas, Formato_Etiqueta_8, 380, e), 148)
            e.Graphics.DrawString("DESPACHADO VÍA: " + FilaRemisión("DESPACHADO"), Formato_Etiqueta_7, Brocha, 35, 166)

            Dim observa As String = Trim(FilaRemisión("OBSERVACION"))
            If observa.Length > 140 Then
                Dim observa1 As String = Trim(Mid(observa, 1, 140))
                Dim pos As Integer
                pos = observa1.LastIndexOf(" ")
                observa1 = Trim(Mid(observa, 1, pos))
                e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_6, Brocha, 35, 183)
                observa = Trim(Mid(observa, pos + 1, observa.Length))
                e.Graphics.DrawString(observa, Formato_Etiqueta_6, Brocha, 95, 193)
            Else
                e.Graphics.DrawString("Observación: " + Mid(observa, 1, 140), Formato_Etiqueta_6, Brocha, 35, 185)
            End If

            e.Graphics.DrawString("REQUISICIÓN", Formato_Etiqueta_7, Brocha, 30 + InicioCentradoTexto("REQUISICIÓN", Formato_Etiqueta_7, 90, e), 220)
            e.Graphics.DrawLine(Lapiz, 120, 208, 120, 660) 'Vertical

            e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 30, e), 220)
            e.Graphics.DrawLine(Lapiz, 150, 208, 150, 660) 'Vertical

            e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto("UN/M", Formato_Etiqueta_6, 30, e), 220)
            e.Graphics.DrawLine(Lapiz, 180, 208, 180, 660) 'Vertical

            e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_6, Brocha, 180 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_6, 60, e), 220)
            e.Graphics.DrawLine(Lapiz, 240, 208, 240, 660) 'Vertical

            e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_6, Brocha, 240 + InicioCentradoTexto("ARTÍCULO", Formato_Etiqueta_6, 60, e), 220)
            e.Graphics.DrawLine(Lapiz, 300, 208, 300, 660) 'Vertical

            e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, 300 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_7, 320, e), 220)
            e.Graphics.DrawLine(Lapiz, 620, 208, 620, 660) 'Vertical

            e.Graphics.DrawString("ORDEN DE COMPRA", Formato_Etiqueta_6, Brocha, 620 + InicioCentradoTexto("ORDEN DE COMPRA", Formato_Etiqueta_6, 100, e), 220)
            e.Graphics.DrawLine(Lapiz, 720, 208, 720, 660) 'Vertical

            e.Graphics.DrawString("VALOR", Formato_Etiqueta_6, Brocha, 720 + InicioCentradoTexto("VALOR", Formato_Etiqueta_6, 80, e), 220)

            e.Graphics.DrawLine(Lapiz, 30, 240, 800, 240) 'horizontal

            Dim lineaPunteada As New Pen(Color.Gray, 1)
            lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

            Const InicioYdeItemRem As Integer = 242
            Const EspacioVertical As Integer = 14
            Const CantidadRenglones As Integer = 30

            '**********cuando se tiene una cadena incompleta de equipos para imprimir de la página anterior
            If completarcomponentes = True Then
                Dim Cadena_Total1 As New ArrayList
                Cadena_Total1 = listaComponentes
                ContadorItemRemisión = ContadorItemRemisión + 1
                Dim varpivote As Boolean = False
                For i = 0 To listaComponentes.Count - 1
                    e.Graphics.DrawString(Cadena_Total1(i), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                    ContadorRenglones = ContadorRenglones + 1
                    If ContadorRenglones > CantidadRenglones Then
                        'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                        Dim cadena2 As New ArrayList
                        For z = i + 1 To Cadena_Total1.Count - 2
                            cadena2.Add(Cadena_Total1(z))
                        Next
                        varpivote = True
                        listaComponentes = cadena2
                        ContadorItemRemisión = ContadorItemRemisión - 1
                        completarcomponentes = True
                        e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                        Exit For
                    End If
                Next

                If ContadorRenglones > 0 And ContadorRenglones <= CantidadRenglones Then
                    e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                End If

                If ContadorRenglones <= CantidadRenglones - 1 Then
                    listaComponentes.Clear()
                    completarcomponentes = False
                End If
            End If

            '**************

            Dim fuente_Rem As Font = Formato_Etiqueta_8

            'Imprimir ítems
            For i = ContadorItemRemisión To dt_Remisión.Rows.Count - 1
                Dim filaItemRemision As DataRow
                filaItemRemision = dt_Remisión.Rows(i)
                Dim Cadenas1 As New ArrayList
                Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
                Dim Cadena_Total1 As New ArrayList
                Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                If ContadorRenglones + Cadena_Total1.Count - 2 >= CantidadRenglones - 1 Then
                    e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                    Exit For
                End If

                e.Graphics.DrawString(IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION")), Formato_Etiqueta_6, Brocha, _
                                      30 + InicioCentradoTexto(IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION")), Formato_Etiqueta_6, 90, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, Brocha, _
                                      120 + InicioCentradoTexto(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, Brocha, _
                                      150 + InicioCentradoTexto(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, Brocha, _
                                      180 + InicioCentradoTexto(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, Brocha, _
                                      240 + InicioCentradoTexto(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA")), Formato_Etiqueta_6, Brocha, _
                                      620 + InicioCentradoTexto(IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA")), Formato_Etiqueta_6, 100, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                e.Graphics.DrawString(FormatearValor(CDec(filaItemRemision("VALORUNITARIOIVA") * filaItemRemision("CANTIDAD")), "$", Formato_Etiqueta_6, e, 70), Formato_Etiqueta_6, Brocha, _
                                      725, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))

                Try
                    For k = 0 To Cadena_Total1.Count - 2
                        e.Graphics.DrawString(Cadena_Total1(k), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                Catch ex As Exception
                    Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                        Case Is < 60
                            e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 120
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 51, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 51, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 101, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 151, 50), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            ContadorRenglones = ContadorRenglones + 1
                    End Select
                End Try

                ContadorItemRemisión = ContadorItemRemisión + 1
                If ContadorRenglones >= CantidadRenglones Then
                    Exit For
                End If

                '------------componentes------------
                Dim dsequipos As New DataSet
                dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                If dsequipos.Tables(0).Rows.Count > 0 Then
                    'crear la cadena de códigos
                    Dim cadenaEquipos As String
                    cadenaEquipos = "Códigos: "
                    Dim j As Integer
                    For j = 0 To dsequipos.Tables(0).Rows.Count - 1
                        cadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                        If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                            cadenaEquipos += ", "
                        End If
                    Next
                    Cadenas1.Clear()
                    Cadenas1.Add(Trim(cadenaEquipos))
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                    Dim varpivote As Boolean = False
                    If ContadorRenglones >= CantidadRenglones - 1 Then
                        'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                        Dim cadena2 As New ArrayList
                        For z = 0 To Cadena_Total1.Count - 2
                            cadena2.Add(Cadena_Total1(z))
                        Next
                        varpivote = True
                        listaComponentes = cadena2
                        ContadorItemRemisión = ContadorItemRemisión - 1
                        completarcomponentes = True

                        e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                        e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))

                        Exit For
                    End If
                    e.Graphics.DrawLine(lineaPunteada, 300, InicioYdeItemRem - 3 + (ContadorRenglones * EspacioVertical), 620, InicioYdeItemRem - 3 + (ContadorRenglones * EspacioVertical))  'Horizontal
                    For k = 0 To Cadena_Total1.Count - 2
                        e.Graphics.DrawString(Cadena_Total1(k), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        If ContadorRenglones >= CantidadRenglones - 1 Then
                            'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                            Dim cadena2 As New ArrayList
                            For z = k + 1 To Cadena_Total1.Count - 2
                                cadena2.Add(Cadena_Total1(z))
                            Next
                            varpivote = True
                            listaComponentes = cadena2
                            ContadorItemRemisión = ContadorItemRemisión - 1
                            completarcomponentes = True

                            e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                            e.Graphics.DrawString("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Pasa a la siguiente página |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                            Exit For
                        End If
                    Next

                    If varpivote = True Then 'salir del for
                        Exit For
                    End If
                End If
                '-----------------------------------

                If ContadorRenglones <= CantidadRenglones Then
                    e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem - 3 + (EspacioVertical * ContadorRenglones)) 'horizontal
                End If
            Next

            e.Graphics.DrawLine(Lapiz, 30, 660, 800, 660) 'horizontal

            Dim InicioLineas As Integer = 680

            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 89) 'vertical
            e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 89) 'vertical
            e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 89) 'vertical
            e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 89) 'vertical

            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 160, InicioLineas + 3)
            e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 315, InicioLineas + 3)
            e.Graphics.DrawString("VERIFICA", Formato_Etiqueta_7, Brocha, 510, InicioLineas + 3)
            e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 690, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 32
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 20

            e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 99) 'vertical
            e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
            e.Graphics.DrawString("ENVÍO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 82) 'vertical
            e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 13)
            e.Graphics.DrawString(FilaRemisión("TRANSPORTADOR"), Formato_Etiqueta_7, Brocha, 400, InicioLineas + 13)

            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 32
            e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            Dim Despacho As String = FilaRemisión("DESPACHADO")

            If Despacho.Length > 50 Then
                e.Graphics.DrawString(Mid(Despacho, 1, 45), Formato_Etiqueta_5, Brocha, 105, InicioLineas)
                e.Graphics.DrawString(Mid(Despacho, 46, 90), Formato_Etiqueta_5, Brocha, 105, InicioLineas + 7)
            Else
                e.Graphics.DrawString(Despacho, Formato_Etiqueta_6, Brocha, 105, InicioLineas + 3)
            End If

            e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawString(FilaRemisión("GUIA"), Formato_Etiqueta_8, Brocha, 400, InicioLineas + 3)

            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 17
            e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            InicioLineas = InicioLineas + 19

            e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 7, 100, InicioLineas + 18) 'vertical
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 7, 330, InicioLineas + 18) 'vertical
            e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 7, 580, InicioLineas + 18) 'vertical
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 1)
            e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 1)
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas + 1)
            InicioLineas = InicioLineas + 20

            e.Graphics.DrawString("RECIBEN Y VERIFICAN", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            InicioLineas = InicioLineas + 20
            e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 90) 'vertical
            e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 90) 'vertical
            e.Graphics.DrawLine(Lapiz, 590, InicioLineas, 590, InicioLineas + 90) 'vertical
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'Horizontal
            e.Graphics.DrawString("SEGURIDAD FÍSICA", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 1)
            e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 420, InicioLineas + 1)
            e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7, Brocha, 650, InicioLineas + 1)
            InicioLineas = InicioLineas + 14
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
            InicioLineas = InicioLineas + 34
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
            InicioLineas = InicioLineas + 24
            e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
            e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)

            e.Graphics.DrawString(FilaRemisión("DIGITA"), Formato_Etiqueta_5, Brocha, 110, 735)
            e.Graphics.DrawString(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, Brocha, 283, 735)
            e.Graphics.DrawString(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, Brocha, 465, 735)

            Dim PiePagina As String = ""
            If Not cargardatasetremisión And paginastotalRemisionVal > 0 Then 'Cuando ya se han cargado los datos de la remisión.
                PiePagina = "Página " & contpaginas & " de " & paginastotalRemisionVal
            Else
                PiePagina = "Página " & contpaginas
            End If
            e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, InicioCentradoTexto(PiePagina, Formato_Etiqueta_6, 950, e) - 50, 1050)

            e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 50, 1050)

            Dim formatoStr As String = ""
            Dim RevisionStr As String = ""
            Select Case LogoEmpresa
                Case 0 'ISMOCOL S.A.
                    e.Graphics.DrawRectangle(Lapiz, 688, 1035, 100, 30)
                    e.Graphics.DrawLine(Lapiz, 688, 1050, 788, 1050)
                    formatoStr = "ICS-GRAL-F-102"
                    RevisionStr = "REVISIÓN No. 1"
                    e.Graphics.DrawString(formatoStr, Formato_Etiqueta_6, Brushes.Black, 688 + InicioCentradoTexto(formatoStr, Formato_Etiqueta_6, 100, e), 1037)
                    e.Graphics.DrawString(RevisionStr, Formato_Etiqueta_6, Brushes.Black, 688 + InicioCentradoTexto(RevisionStr, Formato_Etiqueta_6, 100, e), 1053)
                Case 1 'CSI
                Case 2 'ZAMORANA
            End Select

            If ContadorItemRemisión >= dt_Remisión.Rows.Count Then
                e.Graphics.DrawString("|--------------------| Última Fila |--------------------|", Formato_Etiqueta_5, Brocha, 305 + InicioCentradoTexto("|--------------------| Última Fila |--------------------|", Formato_Etiqueta_5, 310, e), InicioYdeItemRem + (ContadorRenglones * EspacioVertical))
                contcopiasRemisionVal += 1
                If contcopiasRemisionVal = copiasRemisionVal Then
                    e.HasMorePages = False
                    paginastotalRemisionVal = contpaginas
                    contcopiasRemisionVal = 0
                    copiaparadestinatario = _copiaparadestinatario
                    copiaparatransportador = _copiaparatransportador
                    copiaparaporteriasalida = _copiaparaporteriasalida
                    copiaparaconsecutivo = _copiaparaconsecutivo
                Else
                    e.HasMorePages = True
                    If Me.copiaparadestinatario = True Then
                        Me.copiaparadestinatario = False
                    Else
                        If copiaparatransportador = True Then
                            Me.copiaparatransportador = False
                        Else
                            If copiaparaconsecutivo = True Then
                                Me.copiaparaconsecutivo = False
                            Else
                                If copiaparaporteriasalida = True Then
                                    Me.copiaparaporteriasalida = False
                                End If
                            End If
                        End If
                    End If
                End If
                'Reinicio de variables
                contpaginas = 1
                ContadorRenglones = 0
                ContadorItemRemisión = 0
            Else
                contpaginas = contpaginas + 1
                ContadorRenglones = 0
                e.HasMorePages = True
            End If
        End If
    End Sub

#End Region

#Region "74 - ICS-GRAL-F-101 REQUISICIÓN DE MAQUINARIA Y EQUIPOS"
    ''' <summary>Objeto del documento a imprimir</summary>
    Private WithEvents DocImp_SolicitudMaquinariaICSGRALF101 As New PrintDocument

    ''' <summary>Identificador de la Solicitud de Maquinaria y Equipo a imprimir</summary>
    Public IdSolicitudMaquinaria As Integer

    ''' <summary></summary>
    Public copiaparaDeptoMaquinariayEquipo As Boolean

    ''' <summary></summary>
    Public copiaparaEquipoCapital As Boolean

    ''' <summary></summary>
    Public copiaparaTransportes As Boolean

    ''' <summary></summary>
    Private sm_CopiaPara As String = ""

    ''' <summary></summary>
    Private sm_Copias As Integer = 0

    ''' <summary></summary>
    Private sm_ContCopias As Integer = 0

    ''' <summary>Espacio vertical ocupado por los ítems de la requisición que disminuye cada vez que se imprime un artículo. Reinicia al pasar a nueva página</summary>
    Private sm_EspacioFilas As Integer = 0

    ''' <summary>Cantidad de ítems impresos. Reinicia al terminar la visualización previa.</summary>
    Private sm_Items As Integer = 0

    ''' <summary>Cantidad de páginas impresas. No reinicia durante la impresión.</summary>
    Private sm_TotalImpreso As Integer = 0

    ''' <summary>Determina si ya se cargaron los datos de la requisición para no realizar la consulta nuevamente al imprimir.</summary>
    Private sm_Impresion As Boolean = False

    ''' <summary>Determina si se debe imprimir el texto de encabezado y la línea separadora debajo.</summary>
    Private sm_ImprimirEncabezado As Boolean = True

    ''' <summary>Cantidad de páginas impresas. Reinicia al terminar la visualización previa</summary>
    Private sm_ContPaginas As Integer = 0

    ''' <summary>Cantidad de páginas a imprimir. No reinicia durante la impresión</summary>
    Private sm_PaginasTotal As Integer = 0

    ''' <summary>Determina si se debe imprimir el texto de pie de página. Se habilita al terminar la visualización previa</summary>
    Private sm_ImprimirPieDePagina As Boolean = False

    ''' <summary></summary>
    Private dtSolicitudMaquinaria As New DataTable

    ''' <summary></summary>
    Private dtItemSolicitudMaquinaria As New DataTable

    ''' <summary></summary>
    Private sm_Fila As DataRow

    ''' <summary></summary>
    Private iSM_Fila As DataRow


    'Método de impresión del documento ICS-GRAL-F-101 Requisición de Maquinaria y Equipo.
    Private Sub DocImpSolicitudMaquinariaICSGRALF101(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_SolicitudMaquinariaICSGRALF101.PrintPage
        '-------------------------------------------------- Inicio Datos --------------------------------------------------
        Dim Cadena_Total_ENCABEZADO As New ArrayList
        Dim CadenasENCABEZADO As New ArrayList

        If dtSolicitudMaquinaria.Rows.Count = 0 Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim sm_Comando As New SqlCommand("SELECT * FROM dbo.DatosSolicitudMaquinaria(@IDSOLICITUDMAQUINARIA)", conexion)
            sm_Comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", IdSolicitudMaquinaria)
            Dim iSM_Comando As New SqlCommand("SELECT * FROM dbo.ListaItemSolicitudMaquinaria(@IDSOLICITUDMAQUINARIA)", conexion)
            iSM_Comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", IdSolicitudMaquinaria)
            Dim sm_Adaptador As New SqlDataAdapter(sm_Comando)
            Dim iSM_Adaptador As New SqlDataAdapter(iSM_Comando)
            Try
                conexion.Open()
                sm_Adaptador.Fill(dtSolicitudMaquinaria)
                conexion.Close()
                conexion.Open()
                iSM_Adaptador.Fill(dtItemSolicitudMaquinaria)
                conexion.Close()
                sm_Fila = dtSolicitudMaquinaria.Rows(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try

            If copiaparaDeptoMaquinariayEquipo = True Then
                sm_Copias += 1
            End If
            If copiaparaEquipoCapital = True Then
                sm_Copias += 1
            End If
            If copiaparaTransportes = True Then
                sm_Copias += 1
            End If
        Else
            sm_Impresion = True
        End If
        If copiaparaDeptoMaquinariayEquipo Then
            sm_CopiaPara = "DEPARTAMENTO DE MAQUINARIA Y EQUIPO"
        Else
            If copiaparaEquipoCapital = True Then
                sm_CopiaPara = "EQUIPO CAPITAL"
            Else
                If copiaparaTransportes = True Then
                    sm_CopiaPara = "TRANSPORTES"
                End If
            End If
        End If


        If Trim(sm_Fila("ENCABEZADO")) = "" Then
            sm_ImprimirEncabezado = False
        Else
            CadenasENCABEZADO.AddRange(Split(UCase(Trim(sm_Fila("ENCABEZADO"))), Environment.NewLine))
            Dim EncabezadoTemporal As New ArrayList(TextoAParrafoFuente(CadenasENCABEZADO, Formato_Etiqueta_10, 410, e))
            For i As Integer = 0 To EncabezadoTemporal.Count - 1
                If Trim(EncabezadoTemporal(i)) <> "" Then
                    Cadena_Total_ENCABEZADO.Add(EncabezadoTemporal(i))
                End If
            Next
        End If

        If VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If
        '-------------------------------------------------- Fin Datos --------------------------------------------------
        '-------------------------------------------------- Inicio Impresión --------------------------------------------------
        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        'Cuadro de Código formato
        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(imagen, 55, 20, 130, 104)
                DrawRoundedRectangle(e.Graphics, 540, 20, 260, 35, 20)
                e.Graphics.DrawLine(Lapiz, 540, 38, 800, 38)
                e.Graphics.DrawString("ICS-GRAL-F-101", Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto("ICS-GRAL-F-101", Formato_Etiqueta_8, 260, e), 23)
                e.Graphics.DrawString("REVISIÓN No. 1", Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto("REVISIÓN No. 1", Formato_Etiqueta_8, 260, e), 41)
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, 36, 20, 154, 114)
            Case 2 'Zamorana
                e.Graphics.DrawImage(zamorana, 10, 50, 180, 48)
                DrawRoundedRectangle(e.Graphics, 540, 20, 260, 35, 20)
                e.Graphics.DrawLine(Lapiz, 540, 38, 800, 38)
                e.Graphics.DrawString("ZMS-GRAL-F-XXX", Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto("ZMS-GRAL-F-XXX", Formato_Etiqueta_8, 260, e), 23)
                e.Graphics.DrawString("REVISIÓN No. 0", Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto("REVISIÓN No. 0", Formato_Etiqueta_8, 260, e), 41)
        End Select

        'Cuadro de fecha y numero
        DrawRoundedRectangle(e.Graphics, 540, 65, 260, 70, 20)
        e.Graphics.DrawLine(Lapiz, 540, 80, 800, 80)
        e.Graphics.DrawLine(Lapiz, 540, 100, 800, 100)
        e.Graphics.DrawLine(Lapiz, 540, 115, 800, 115)
        e.Graphics.DrawLine(Lapiz, 627, 115, 627, 135)
        e.Graphics.DrawLine(Lapiz, 713, 115, 713, 135)
        e.Graphics.DrawString("NÚMERO SOLICITUD", Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto("NÚMERO SOLICITUD", Formato_Etiqueta_8, 260, e), 67)
        e.Graphics.DrawString(sm_Fila("SOLICITUDMAQUINARIA"), Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto(sm_Fila("SOLICITUDMAQUINARIA"), Formato_Etiqueta_8, 260, e), 85)
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_8, Brocha, 540 + InicioCentradoTexto("FECHA", Formato_Etiqueta_8, 260, e), 102)
        e.Graphics.DrawString("DÍA: " & sm_Fila("DIA"), Formato_Etiqueta_8, Brocha, 545, 118)
        e.Graphics.DrawString("MES: " & sm_Fila("MES"), Formato_Etiqueta_8, Brocha, 635, 118)
        e.Graphics.DrawString("AÑO: " & sm_Fila("AÑO"), Formato_Etiqueta_8, Brocha, 715, 118)

        'Título
        e.Graphics.DrawString("REQUISICIÓN DE MAQUINARIA Y EQUIPO", Formato_Etiqueta_12, Brocha, 190 + InicioCentradoTexto("REQUISICIÓN DE MAQUINARIA Y EQUIPO", Formato_Etiqueta_12, 350, e), 20)
        e.Graphics.DrawString("PROYECTO: " & sm_Fila("BODEGA"), Formato_Etiqueta_10, Brocha, 190 + InicioCentradoTexto("PROYECTO: " & sm_Fila("BODEGA"), Formato_Etiqueta_10, 350, e), 45)
        e.Graphics.DrawString("EQUIPO CAPITAL", Formato_Etiqueta_10, Brocha, 190 + InicioCentradoTexto("EQUIPO CAPITAL", Formato_Etiqueta_10, 350, e), 65)

        'Cuadros Departamentos
        e.Graphics.DrawRectangle(Lapiz, 470, 90, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 470, 105, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, 470, 120, 10, 10)
        e.Graphics.DrawString("DEPARTAMENTO DE MAQUINARIA Y EQUIPOS", Formato_Etiqueta_8, Brocha, 200, 90)
        e.Graphics.DrawString("EQUIPO CAPITAL", Formato_Etiqueta_8, Brocha, 200, 105)
        e.Graphics.DrawString("TRANSPORTES", Formato_Etiqueta_8, Brocha, 200, 120)
        e.Graphics.DrawString("X", Formato_Etiqueta_6R, Brocha, 471, 90)
        e.Graphics.DrawString("X", Formato_Etiqueta_6R, Brocha, 471, 105)
        e.Graphics.DrawString("X", Formato_Etiqueta_6R, Brocha, 471, 120)

        'Cuadro de ítems
        DrawRoundedRectangle(e.Graphics, 30, 150, 770, 755, 20)
        '   Horizontales
        e.Graphics.DrawLine(Lapiz, 30, 180, 800, 180)
        '   Verticales
        e.Graphics.DrawLine(Lapiz, 70, 150, 70, 860)
        e.Graphics.DrawLine(Lapiz, 120, 150, 120, 860)
        e.Graphics.DrawLine(Lapiz, 580, 150, 580, 860)
        e.Graphics.DrawLine(Lapiz, 660, 150, 660, 860)
        '   Texto
        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_8, Brocha, 30 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_8, 40, e), 159)
        e.Graphics.DrawString("REF.", Formato_Etiqueta_8, Brocha, 70 + InicioCentradoTexto("REF.", Formato_Etiqueta_8, 50, e), 159)
        e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_8, Brocha, 120 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_8, 460, e), 159)
        e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_6, Brocha, 580 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_6, 80, e), 155)
        e.Graphics.DrawString("REQUERIDA", Formato_Etiqueta_6, Brocha, 580 + InicioCentradoTexto("REQUERIDA", Formato_Etiqueta_6, 80, e), 165)
        e.Graphics.DrawString("FECHA EN QUE", Formato_Etiqueta_6, Brocha, 660 + InicioCentradoTexto("FECHA EN QUE", Formato_Etiqueta_6, 140, e), 155)
        e.Graphics.DrawString("SE REQUIERE", Formato_Etiqueta_6, Brocha, 660 + InicioCentradoTexto("SE REQUIERE", Formato_Etiqueta_6, 140, e), 165)

        'Cuadro de justificación
        e.Graphics.DrawLine(Lapiz, 30, 860, 800, 860)
        e.Graphics.DrawLine(Lapiz, 150, 876, 800, 876)
        e.Graphics.DrawLine(Lapiz, 150, 891, 800, 891)
        e.Graphics.DrawString("JUSTIFICACIÓN:", Formato_Etiqueta_8, Brocha, 32, 863)
        Dim justifica As String = Trim(sm_Fila("JUSTIFICACION"))
        Dim pos As Integer = 0
        If justifica.Length > 100 Then
            If justifica.Length > 200 Then
                Dim justifica1 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica1.LastIndexOf(" ")
                justifica1 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica1, Formato_Etiqueta_7, Brocha, 150, 863)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                Dim justifica2 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica2.LastIndexOf(" ")
                justifica2 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica2, Formato_Etiqueta_7, Brocha, 150, 878)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brocha, 150, 893)
            Else
                Dim justifica1 As String = Trim(Mid(justifica, 1, 100))
                pos = justifica1.LastIndexOf(" ")
                justifica1 = Trim(Mid(justifica, 1, pos))
                e.Graphics.DrawString(justifica1, Formato_Etiqueta_7, Brocha, 150, 863)
                justifica = Trim(Mid(justifica, pos + 1, justifica.Length))
                e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brocha, 150, 878)
            End If
        Else
            e.Graphics.DrawString(justifica, Formato_Etiqueta_7, Brocha, 150, 863)
        End If

        'Cuadro firmas
        DrawRoundedRectangle(e.Graphics, 30, 916, 770, 120, 20)
        '   Horizontales
        e.Graphics.DrawLine(Lapiz, 30, 946, 800, 946)
        e.Graphics.DrawLine(Lapiz, 30, 966, 800, 966)
        e.Graphics.DrawLine(Lapiz, 30, 986, 800, 986)
        e.Graphics.DrawLine(Lapiz, 30, 1016, 800, 1016)
        '   Verticales
        e.Graphics.DrawLine(Lapiz, 100, 916, 100, 1036) 'Encabezados filas
        e.Graphics.DrawLine(Lapiz, 330, 916, 330, 1036) 'Firma1
        e.Graphics.DrawLine(Lapiz, 560, 916, 560, 1036) 'Firma2
        'e.Graphics.DrawLine(Lapiz, 625, 916, 625, 1036) 'Firma3
        '   Texto
        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_8, Brocha, 32, 948)
        e.Graphics.DrawString("CELULAR", Formato_Etiqueta_8, Brocha, 32, 968)
        e.Graphics.DrawString("FIRMA", Formato_Etiqueta_8, Brocha, 32, 988)
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_8, Brocha, 32, 1018)
        e.Graphics.DrawString("DIRECTOR DE PROYECTO", Formato_Etiqueta_8, Brocha, 100 + InicioCentradoTexto("DIRECTOR DE PROYECTO", Formato_Etiqueta_8, 230, e), 924)
        e.Graphics.DrawString(sm_Fila("PERSONASOLICITA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(sm_Fila("PERSONASOLICITA"), Formato_Etiqueta_5, 230, e), 950)
        e.Graphics.DrawString(sm_Fila("SOLICITACEL"), Formato_Etiqueta_6, Brocha, 100 + InicioCentradoTexto(sm_Fila("SOLICITACEL"), Formato_Etiqueta_6, 230, e), 970)
        e.Graphics.DrawString("GERENTE CORRESPONDIENTE", Formato_Etiqueta_8, Brocha, 330 + InicioCentradoTexto("GERENTE CORRESPONDIENTE", Formato_Etiqueta_8, 230, e), 924)
        e.Graphics.DrawString(sm_Fila("PERSONAAUTORIZA"), Formato_Etiqueta_5, Brocha, 330 + InicioCentradoTexto(sm_Fila("PERSONAAUTORIZA"), Formato_Etiqueta_5, 230, e), 950)
        e.Graphics.DrawString(sm_Fila("AUTORIZACEL"), Formato_Etiqueta_6, Brocha, 330 + InicioCentradoTexto(sm_Fila("AUTORIZACEL"), Formato_Etiqueta_6, 230, e), 970)
        e.Graphics.DrawString("GERENTE GENERAL", Formato_Etiqueta_8, Brocha, 560 + InicioCentradoTexto("GERENTE GENERAL", Formato_Etiqueta_8, 240, e), 924)
        e.Graphics.DrawString(sm_Fila("PERSONAAPRUEBA"), Formato_Etiqueta_5, Brocha, 560 + InicioCentradoTexto(sm_Fila("PERSONAAPRUEBA"), Formato_Etiqueta_5, 240, e), 950)
        e.Graphics.DrawString(sm_Fila("APRUEBACEL"), Formato_Etiqueta_6, Brocha, 560 + InicioCentradoTexto(sm_Fila("APRUEBACEL"), Formato_Etiqueta_6, 240, e), 970)

        Dim sm_InicioYdeItem As Integer = 0
        'Impresión encabezado
        sm_InicioYdeItem = 183
        ContadorRenglones = 0
        If sm_ImprimirEncabezado = True Then ' Si el encabezado es vacío, la variable se marca arriba con FALSE en la carga inicial.
            If Cadena_Total_ENCABEZADO.Count > 0 Then ' ¡ATENCIÓN! Si sm_Fila("ENCABEZADO") = "" entonces Count = 1
                Dim puntoOrigenENCABEZADO As New Point(125, sm_InicioYdeItem)
                Dim texto As String = ""
                For i = 0 To Cadena_Total_ENCABEZADO.Count - 1
                    texto = Cadena_Total_ENCABEZADO(i)
                    texto = SubParrafo1(Cadena_Total_ENCABEZADO(i), Formato_Etiqueta_10, 450, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10, Brocha, puntoOrigenENCABEZADO.X, puntoOrigenENCABEZADO.Y)
                    puntoOrigenENCABEZADO.Y = puntoOrigenENCABEZADO.Y + 15
                    texto = ""
                Next
                ContadorRenglones = Cadena_Total_ENCABEZADO.Count + 1
            End If
        End If

        'Impresión de ítems
        sm_InicioYdeItem += ContadorRenglones * 15
        Dim alturaEncabezado As Integer = ContadorRenglones * 15
        If sm_ImprimirEncabezado = True Then
            If Cadena_Total_ENCABEZADO.Count > 0 Then
                e.Graphics.DrawLine(lineaPunteada, New Point(30, sm_InicioYdeItem - 5), New Point(800, sm_InicioYdeItem - 5))
            End If
        End If
        Dim espacio As Integer = 0
        Dim iSM_Cadena_Total_DESCRIPCION As New ArrayList
        Dim iSM_CadenasDESCRIPCION As New ArrayList
        Dim iSM_Fuente As Font = Formato_Etiqueta_8R
        For x As Integer = sm_Items To dtItemSolicitudMaquinaria.Rows.Count - 1
            iSM_Fila = dtItemSolicitudMaquinaria.Rows(x)
            iSM_CadenasDESCRIPCION.Add(UCase(Trim(iSM_Fila("DESCRIPCION"))))
            iSM_Cadena_Total_DESCRIPCION = TextoAParrafoFuente(iSM_CadenasDESCRIPCION, iSM_Fuente, 410, e)
            Dim espacionecesario As Integer = iSM_Cadena_Total_DESCRIPCION.Count * 13
            Dim espaciodisponible As Integer
            If sm_ImprimirEncabezado = True Then
                espaciodisponible = 650 - alturaEncabezado - sm_EspacioFilas
            Else
                espaciodisponible = 650 - sm_EspacioFilas
            End If
            If (espaciodisponible > espacionecesario) Or sm_Items = dtItemSolicitudMaquinaria.Rows.Count Then
                e.Graphics.DrawString(iSM_Fila("IDITEMSOLICITUDMAQUINARIA"), iSM_Fuente, Brocha, 30 + InicioCentradoTexto(iSM_Fila("IDITEMSOLICITUDMAQUINARIA"), iSM_Fuente, 40, e), sm_InicioYdeItem + sm_EspacioFilas)
                e.Graphics.DrawString(iSM_Fila("IDARTICULO"), iSM_Fuente, Brocha, 80, sm_InicioYdeItem + sm_EspacioFilas)

                If iSM_Cadena_Total_DESCRIPCION.Count <> 0 Then
                    Dim iSM_puntoOrigenDESCRIPCION As New Point(130, sm_InicioYdeItem + sm_EspacioFilas)
                    Dim texto As String = ""
                    For i = 0 To iSM_Cadena_Total_DESCRIPCION.Count - 1
                        texto = SubParrafo1(iSM_Cadena_Total_DESCRIPCION(i), iSM_Fuente, 450, e)
                        e.Graphics.DrawString(texto, iSM_Fuente, Brocha, iSM_puntoOrigenDESCRIPCION.X, iSM_puntoOrigenDESCRIPCION.Y)
                        iSM_puntoOrigenDESCRIPCION.Y = iSM_puntoOrigenDESCRIPCION.Y + 13
                        texto = ""
                    Next
                    e.Graphics.DrawLine(lineaPunteada, New Point(30, iSM_puntoOrigenDESCRIPCION.Y - 7), New Point(800, iSM_puntoOrigenDESCRIPCION.Y - 7))
                    espacio = iSM_Cadena_Total_DESCRIPCION.Count * 13
                    iSM_CadenasDESCRIPCION.Clear()
                    iSM_Cadena_Total_DESCRIPCION.Clear()
                End If
                e.Graphics.DrawString(iSM_Fila("CANTIDAD"), iSM_Fuente, Brocha, 590, sm_InicioYdeItem + sm_EspacioFilas)
                e.Graphics.DrawString(CDate(iSM_Fila("FECHAREQUIERE")).ToString("dd \d\e MMMM \d\e yyyy"), Formato_Etiqueta_6R, Brocha, 665, sm_InicioYdeItem + sm_EspacioFilas)
                sm_EspacioFilas += espacio
                sm_Items += 1
            Else
                Exit For
            End If
        Next
        sm_ImprimirEncabezado = False

        If sm_Items = dtItemSolicitudMaquinaria.Rows.Count Then
            If sm_EspacioFilas < 680 Then
                e.Graphics.DrawString("--------------ÚLTIMO RENGLÓN--------------", Formato_Etiqueta_10R, Brocha, 120 + InicioCentradoTexto("--------------ÚLTIMO RENGLÓN--------------", Formato_Etiqueta_10R, 460, e), sm_InicioYdeItem + sm_EspacioFilas)
            End If
        Else
            e.Graphics.DrawString("-----------PASA A LA SIGUIENTE HOJA-----------", Formato_Etiqueta_10R, Brocha, 120 + InicioCentradoTexto("-----------PASA A LA SIGUIENTE HOJA-----------", Formato_Etiqueta_10R, 460, e), sm_InicioYdeItem + sm_EspacioFilas)
            sm_EspacioFilas = 0
            e.HasMorePages = True
        End If

        sm_ContPaginas += 1

        Dim PiePagina As String = ""
        If sm_ImprimirPieDePagina Then
            PiePagina = "Página " & sm_ContPaginas & " de " & sm_PaginasTotal
        Else
            PiePagina = "Página " & sm_ContPaginas
        End If
        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brocha, InicioCentradoTexto(PiePagina, Formato_Etiqueta_6, 950, e) - 50, 1050)
        'e.Graphics.DrawString("DESTINO: " & sm_copiapara, Formato_Etiqueta_6, Brocha, 50, 1050)

        If sm_Items = dtItemSolicitudMaquinaria.Rows.Count Then
            sm_EspacioFilas = 0
            sm_Items = 0
            sm_ImprimirEncabezado = True
            sm_ImprimirPieDePagina = True
            sm_ContCopias += 1
            sm_PaginasTotal = sm_ContPaginas
            sm_TotalImpreso += sm_ContPaginas
            sm_ContPaginas = 0
            'e.HasMorePages = False

            If sm_ContCopias = sm_Copias Then
                e.HasMorePages = False
                sm_ContCopias = 0
                'copiaparacontabilidad1 = _copiaparacontabilidad1
                'copiaparacontabilidad2 = _copiaparacontabilidad2
                'copiaparaconsecutivo = _copiaparaconsecutivo
                'copiaparafolderpedido = _copiaparafolderpedido

                If sm_TotalImpreso = (sm_PaginasTotal * 2) And sm_Impresion Then
                    'GuardarImpresionSolicitudMaquinaria()
                Else
                    'MarcarImpresa = True
                End If
            Else
                If Me.copiaparaDeptoMaquinariayEquipo Then
                    copiaparaDeptoMaquinariayEquipo = False
                Else
                    If copiaparaEquipoCapital = True Then
                        copiaparaEquipoCapital = False
                    Else
                        If copiaparaTransportes = True Then
                            copiaparaTransportes = False
                        End If
                    End If
                End If

                e.HasMorePages = True
            End If
        End If
        '-------------------------------------------------- Fin Impresión --------------------------------------------------
    End Sub

    Private Sub GuardarImpresionSolicitudMaquinaria()
        Try
            Dim comando As New SqlCommand("ImpresionDocumento")
            comando.CommandType = CommandType.StoredProcedure
            'If sm_Cancelada = False Then
            '    comando.Parameters.AddWithValue("@TIPO", 6)
            'Else
            '    If sm_CancelacionParcial Then
            '        comando.Parameters.AddWithValue("@TIPO", 7)
            '    Else
            '        comando.Parameters.AddWithValue("@TIPO", 8)
            '    End If
            'End If
            comando.Parameters.AddWithValue("@IDDOCUMENTO", IDREQUISICION)
            comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            comando.Connection = conn
            Try
                comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "75 - COMPLEMENTO REQUISICIÓN MATERIALES"

    Private WithEvents DocImp_ComplementoRequisicion As New PrintDocument 'Documento a imprimir
    Private dsComplementoRQ As DataSet
    Private comrq_FilaRequisicion As DataRow
    Private comrq_FilaItemRQ As DataRow
    Private comrq_DatosCargados As Boolean = False
    Private comrq_VistaPrevia As Boolean = True
    Private comrq_AlturaFilas As UInteger = 10
    Private comrq_AlturaImpresa As UInteger = 0
    Private comrq_MargenInferiorItems As UInteger = 790
    Private comrq_ItemsImpresosContador As UInteger = 0
    Private comrq_PaginasImpresasContador As UInteger = 0
    Private comrq_TotalPaginas As UInteger = 0
    Private comrq_PosicionItem As UInteger = 0
    Private comrq_CadenaPiePagina As String = ""

    Private Sub DocImpComplementoRequisicion(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ComplementoRequisicion.PrintPage
        'Datos
        If Not comrq_DatosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImpresionComplementoRequisicion", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICION)
            Dim adaptador As New SqlDataAdapter(comando)
            dsComplementoRQ = New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsComplementoRQ)
                conexion.Close()
                If dsComplementoRQ.Tables.Count > 0 Then
                    If dsComplementoRQ.Tables(0).Rows.Count > 0 Then
                        dsComplementoRQ.Tables(0).TableName = "REQUISICION"
                    Else
                        'No hay datos.
                    End If
                    If dsComplementoRQ.Tables(1).Rows.Count > 0 Then
                        dsComplementoRQ.Tables(1).TableName = "ITEMREQUISICION"
                    Else
                        'No hay datos.
                    End If
                Else
                    'No hay datos.
                End If
                comrq_DatosCargados = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else

        End If
        comrq_FilaRequisicion = dsComplementoRQ.Tables("REQUISICION").Rows(0)

        'Impresión
        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)

        e.Graphics.DrawString("REQUISICIÓN: " & comrq_FilaRequisicion("REQUISICION"), Formato_Etiqueta_12, Brocha, (20 - 4), 35)
        e.Graphics.DrawString("FECHA: " & Format(comrq_FilaRequisicion("FECHAREGISTRO"), "dd/MM/yyyy"), Formato_Etiqueta_8, Brocha, (20 - 2), 60)

        e.Graphics.DrawLine(Lapiz, 20, 80, 1050, 80) 'Horizontal.
        e.Graphics.DrawLine(Lapiz, 20, 80, 20, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 20 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 40, e), 85)
        e.Graphics.DrawLine(Lapiz, 60, 80, 60, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_6, Brocha, 60 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_6, 60, e), 85)
        e.Graphics.DrawLine(Lapiz, 120, 80, 120, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("UNIDAD", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("UNIDAD", Formato_Etiqueta_6, 60, e), 85)
        e.Graphics.DrawLine(Lapiz, 180, 80, 180, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_6, Brocha, 180 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_6, 450, e), 85)
        e.Graphics.DrawLine(Lapiz, 630, 80, 630, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("STOCK", Formato_Etiqueta_6, Brocha, 630 + InicioCentradoTexto("STOCK", Formato_Etiqueta_6, 120, e), 80)
        e.Graphics.DrawLine(Lapiz, 630, 90, 750, 90) 'Horizontal.
        e.Graphics.DrawString("LOCAL", Formato_Etiqueta_6, Brocha, 630 + InicioCentradoTexto("LOCAL", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 690, 90, 690, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("PRALES.", Formato_Etiqueta_6, Brocha, 690 + InicioCentradoTexto("PRALES.", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 750, 80, 750, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("TRÁNSITO", Formato_Etiqueta_6, Brocha, 750 + InicioCentradoTexto("TRÁNSITO", Formato_Etiqueta_6, 180, e), 80)
        e.Graphics.DrawLine(Lapiz, 750, 90, 930, 90) 'Horizontal.
        e.Graphics.DrawString("LOCAL", Formato_Etiqueta_6, Brocha, 750 + InicioCentradoTexto("LOCAL", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 810, 90, 810, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("PRALES.", Formato_Etiqueta_6, Brocha, 810 + InicioCentradoTexto("PRALES.", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 870, 90, 870, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("IMPORTADO", Formato_Etiqueta_6, Brocha, 870 + InicioCentradoTexto("IMPORTADO", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 930, 80, 930, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("CONSUMO ÚLT. 3 MESES", Formato_Etiqueta_6, Brocha, 930 + InicioCentradoTexto("CONSUMO ÚLT. 3 MESES", Formato_Etiqueta_6, 120, e), 80)
        e.Graphics.DrawLine(Lapiz, 930, 90, 1050, 90) 'Horizontal.
        e.Graphics.DrawString("LOCAL", Formato_Etiqueta_6, Brocha, 930 + InicioCentradoTexto("LOCAL", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 990, 90, 990, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawString("ISMOCOL", Formato_Etiqueta_6, Brocha, 990 + InicioCentradoTexto("ISMOCOL", Formato_Etiqueta_6, 60, e), 90)
        e.Graphics.DrawLine(Lapiz, 1050, 80, 1050, comrq_MargenInferiorItems) 'Vertical.
        e.Graphics.DrawLine(Lapiz, 20, 100, 1050, 100) 'Horizontal.
        e.Graphics.DrawLine(Lapiz, 20, comrq_MargenInferiorItems, 1050, comrq_MargenInferiorItems) 'Horizontal.

        'Impresión ítems.
        Dim Cadena_Total1 As ArrayList
        comrq_PosicionItem = 100
        For i As Integer = comrq_ItemsImpresosContador To dsComplementoRQ.Tables("ITEMREQUISICION").Rows.Count - 1
            comrq_FilaItemRQ = dsComplementoRQ.Tables("ITEMREQUISICION").Rows(comrq_ItemsImpresosContador)
            Dim Cadenas1 As New ArrayList
            Cadenas1.Add(Trim(comrq_FilaItemRQ("NOMBREDESCRIPTIVO")))
            Cadena_Total1 = New ArrayList
            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_6R, 445, e)
            For k = 0 To Cadena_Total1.Count - 1
                If Trim(Cadena_Total1(k)) = "" Then
                    Cadena_Total1.RemoveAt(k)
                End If
            Next
            If comrq_PosicionItem < (comrq_MargenInferiorItems - (Cadena_Total1.Count * comrq_AlturaFilas)) Then
                Dim comrq_LineasItem As UInteger = 0
                e.Graphics.DrawString(comrq_FilaItemRQ("IDITEMREQUISICION"), Formato_Etiqueta_7R, Brocha, 25, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("IDARTICULO"), Formato_Etiqueta_7R, Brocha, 65, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("ABREVIATURA"), Formato_Etiqueta_7R, Brocha, 120 + InicioCentradoTexto(comrq_FilaItemRQ("ABREVIATURA"), Formato_Etiqueta_7R, 60, e), comrq_PosicionItem + 2)
                For Each linea As String In Cadena_Total1
                    e.Graphics.DrawString(linea, Formato_Etiqueta_6R, Brocha, 185, comrq_PosicionItem + (comrq_LineasItem * comrq_AlturaFilas) + 1)
                    comrq_LineasItem += 1
                Next
                e.Graphics.DrawString(comrq_FilaItemRQ("STOCKLOCAL"), Formato_Etiqueta_7R, Brocha, 635, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("STOCKPRINCIPALES"), Formato_Etiqueta_7R, Brocha, 695, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("TRANSITOLOCAL"), Formato_Etiqueta_7R, Brocha, 755, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("TRANSITOPRINCIPALES"), Formato_Etiqueta_7R, Brocha, 815, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("TRANSITOIMPORTADO"), Formato_Etiqueta_7R, Brocha, 875, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("CONSUMOLOCAL"), Formato_Etiqueta_7R, Brocha, 935, comrq_PosicionItem + 2)
                e.Graphics.DrawString(comrq_FilaItemRQ("CONSUMOPRINCIPALES"), Formato_Etiqueta_7R, Brocha, 995, comrq_PosicionItem + 2)
                comrq_PosicionItem += (comrq_LineasItem * comrq_AlturaFilas) + comrq_AlturaFilas
                comrq_ItemsImpresosContador += 1
                If comrq_PosicionItem < comrq_MargenInferiorItems Then
                    e.Graphics.DrawLine(lineaPunteada, 20, comrq_PosicionItem - CInt(comrq_AlturaFilas / 2), 1050, comrq_PosicionItem - CInt(comrq_AlturaFilas / 2)) 'Horizontal.
                End If
            Else
                If comrq_PosicionItem < (comrq_MargenInferiorItems - comrq_AlturaFilas) Then
                    e.Graphics.DrawString("-- Pasa a la siguiente página --", Formato_Etiqueta_7, Brocha, 180 + InicioCentradoTexto("-- Pasa a la siguiente página --", Formato_Etiqueta_7, 450, e), comrq_PosicionItem + 2)
                End If
                Exit For
            End If
        Next
        comrq_PaginasImpresasContador += 1

        comrq_CadenaPiePagina = "Página " & comrq_PaginasImpresasContador
        If comrq_VistaPrevia Then
            e.Graphics.DrawString(comrq_CadenaPiePagina, Formato_Etiqueta_6, Brocha, InicioCentradoTexto(comrq_CadenaPiePagina, Formato_Etiqueta_6, 1050, e), 800)
        Else
            comrq_CadenaPiePagina += " de " & comrq_TotalPaginas
            e.Graphics.DrawString(comrq_CadenaPiePagina, Formato_Etiqueta_6, Brocha, InicioCentradoTexto(comrq_CadenaPiePagina, Formato_Etiqueta_6, 1050, e), 800)
        End If

        If Not comrq_VistaPrevia Then
            If (comrq_PaginasImpresasContador = comrq_TotalPaginas) Then
                e.Graphics.DrawString("--- Última Fila ---", Formato_Etiqueta_7, Brocha, 200 + InicioCentradoTexto("--- Última Fila ---", Formato_Etiqueta_7, 450, e), comrq_PosicionItem + 2)
                ImpresionFinalizada = True
                e.HasMorePages = False
            Else
                'Reiniciar variables.
                comrq_AlturaImpresa = 0
                e.HasMorePages = True
            End If
        Else
            If comrq_ItemsImpresosContador = dsComplementoRQ.Tables("ITEMREQUISICION").Rows.Count Then
                e.Graphics.DrawString("--- Última Fila ---", Formato_Etiqueta_7, Brocha, 200 + InicioCentradoTexto("--- Última Fila ---", Formato_Etiqueta_7, 450, e), comrq_PosicionItem + 2)
                comrq_VistaPrevia = False
                e.HasMorePages = False
                comrq_TotalPaginas = comrq_PaginasImpresasContador
                'Reiniciar variables.
                comrq_AlturaImpresa = 0
                comrq_ItemsImpresosContador = 0
                comrq_PaginasImpresasContador = 0
            Else
                'Reiniciar variables.
                comrq_AlturaImpresa = 0
                e.HasMorePages = True
            End If
        End If

    End Sub

#End Region

#Region "76 - STICKER ARTICULOS REF: 67*25 C3 x 30 Código de Barras"
    'Dim fuente As Font
    'Dim pfc As PrivateFontCollection = New PrivateFontCollection()
    'Dim fontFamily As FontFamily

    Dim WithEvents DocImp_STICKERARTICULOSREF_67_25_C3x30_CODIGOBARRAS As New PrintDocument 'Documento a imprimir
    Private Sub DocImpSTICKERARTICULOSREF_67_25_C3x30_CODIGOBARRAS(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_STICKERARTICULOSREF_67_25_C3x30_CODIGOBARRAS.PrintPage
        'Obtenemos la fuente que se encuentra en el directorio de la aplicacion
        'y la cargamos 
        Try
            If IO.File.Exists("C:\WINDOWS\fonts\FREE3OF9.TF") = False Then
                IO.File.Copy(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF", "C:\WINDOWS\fonts\FREE3OF9.TTF")
            End If
        Catch ex As Exception
        End Try

        pfc.AddFontFile(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF")
        fontFamily = pfc.Families(0)
        fuente = New Font(fontFamily, 40)

        If CalcularCantidad = True Then
            CantidadTotalSticker = Tb_Sticker.Compute("Sum(Cant)", "")
            paginastotal = -Int((-CantidadTotalSticker + InicioImpresión) / 30)
            CalcularCantidad = False
            For i = 0 To Tb_Sticker.Rows.Count - 1
                Dim cant As Integer = Tb_Sticker.Rows(i).Item("Cant")
                Dim Fila As DataRow
                Fila = Tb_Sticker.Rows(i)
                For j = 1 To cant
                    VectorStickerId.Add(Fila("Cód"))
                    VectorStickerNombre.Add(Fila("Descripción"))
                    VectorStickerUnidad.Add(Fila("Und"))
                Next
            Next
        End If
        Dim imprimir As Boolean = False
        For FilaImpresión = 1 To 10
            For ColumnaImpresión = 1 To 3
                If contpaginas = 1 Then
                    'Ubicar la primera impresión de sticker
                    If InicioImpresión > ContaStickerImpreso Then
                        imprimir = False
                        ContaStickerImpreso = ContaStickerImpreso + 1
                    Else
                        imprimir = True
                    End If
                Else
                    imprimir = True
                End If
                If imprimir = True Then
                    Dim sepvertical As Integer = 100
                    'Imprime
                    e.Graphics.DrawString("Cód:  " + VectorStickerId(ContaStickerVector).ToString, Formato_Etiqueta_12, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString(Date.Now.ToShortDateString, Formato_Etiqueta_6, Brocha, 170 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString("Und: " + VectorStickerUnidad(ContaStickerVector).ToString, Formato_Etiqueta_6, Brocha, 170 + ((ColumnaImpresión - 1) * 270), 49 + ((FilaImpresión - 1) * sepvertical))
                    'codigo de barras
                    e.Graphics.DrawString(FormatoCodigoBarras(VectorStickerId(ContaStickerVector).ToString), fuente, Brushes.Black, 20 + ((ColumnaImpresión - 1) * 270), 60 + ((FilaImpresión - 1) * sepvertical))
                    'usuario
                    e.Graphics.DrawString(Mid(VariablesBase.VariablesBase.Nombre_Usuario, 1, 80), Formato_Etiqueta_5, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 118 + ((FilaImpresión - 1) * sepvertical))
                    ContaStickerVector = ContaStickerVector + 1
                    ContaStickerImpreso = ContaStickerImpreso + 1
                End If
                If ContaStickerVector >= CantidadTotalSticker Then
                    Exit For
                End If
            Next
            If ContaStickerVector >= CantidadTotalSticker Then
                Exit For
            End If
        Next

        If ContaStickerVector >= CantidadTotalSticker Then
            contpaginas = 1
            ContaStickerImpreso = 1
            ContaStickerVector = 0
            e.HasMorePages = False
        Else
            contpaginas = contpaginas + 1
            e.HasMorePages = True
        End If
    End Sub

    Public Function FormatoCodigoBarras(ByVal code As String) As String
        Dim barcode As String = String.Empty
        barcode = String.Format("{0}", code)
        Return "*" + barcode + "*"
    End Function
#End Region

#Region "77 - STICKER ARTICULOS REF: 67*25 C3 x 30 Rótulos Cód Barras FREE3OF9"
    Dim WithEvents DocImp_STICKERARTICULOSREF_67_25_C3x30_ROTULOCODIGOBARRAS As New PrintDocument 'Documento a imprimir

    Private Sub DocImpSTICKERARTICULOSREF_67_25_C3x30_ROTULOCODIGOBARRAS(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_STICKERARTICULOSREF_67_25_C3x30_ROTULOCODIGOBARRAS.PrintPage
        'Obtenemos la fuente que se encuentra en el directorio de la aplicacion y la cargamos.
        Try
            If IO.File.Exists("C:\WINDOWS\fonts\FREE3OF9.TF") = False Then
                IO.File.Copy(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF", "C:\WINDOWS\fonts\FREE3OF9.TTF")
            End If
        Catch ex As Exception
        End Try

        pfc.AddFontFile(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF")
        fontFamily = pfc.Families(0)
        fuente = New Font(fontFamily, 20)

        If CalcularCantidad = True Then
            CantidadTotalSticker = Tb_Sticker.Compute("Sum(Cant)", "")
            paginastotal = -Int((-CantidadTotalSticker + InicioImpresión) / 30)
            CalcularCantidad = False
            For i = 0 To Tb_Sticker.Rows.Count - 1
                Dim cant As Integer = Tb_Sticker.Rows(i).Item("Cant")
                Dim Fila As DataRow
                Fila = Tb_Sticker.Rows(i)
                For j = 1 To cant
                    VectorStickerId.Add(Fila("Cód"))
                    VectorStickerNombre.Add(Fila("Descripción"))
                    VectorStickerUnidad.Add(Fila("Und"))
                Next
            Next
        End If
        Dim imprimir As Boolean = False
        For FilaImpresión = 1 To 10
            For ColumnaImpresión = 1 To 3
                If contpaginas = 1 Then
                    'Ubicar la primera impresión de sticker
                    If InicioImpresión > ContaStickerImpreso Then
                        imprimir = False
                        ContaStickerImpreso = ContaStickerImpreso + 1
                    Else
                        imprimir = True
                    End If
                Else
                    imprimir = True
                End If
                If imprimir = True Then
                    Dim sepvertical As Integer = 100
                    'Imprime
                    e.Graphics.DrawString("Cód:  " + VectorStickerId(ContaStickerVector).ToString, Formato_Etiqueta_12, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))

                    Dim Descripción As String = VectorStickerNombre(ContaStickerVector)
                    Dim Cadenas1 As New ArrayList
                    Cadenas1.Add(Trim(Descripción))
                    Dim Cadena_Total1 As New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_6, 240, e)
                    Dim Separa As Integer = 10
                    For t = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawString(Cadena_Total1(t), Formato_Etiqueta_6, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 60 + (t * Separa) + ((FilaImpresión - 1) * sepvertical))
                    Next

                    'codigo de barras
                    e.Graphics.DrawString(FormatoCodigoBarras(VectorStickerId(ContaStickerVector).ToString), fuente, Brushes.Black, 170 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))
          
                e.Graphics.DrawString(Date.Now.ToShortDateString, Formato_Etiqueta_6, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 118 + ((FilaImpresión - 1) * sepvertical))
                e.Graphics.DrawString("Und: " + VectorStickerUnidad(ContaStickerVector).ToString, Formato_Etiqueta_6, Brocha, 70 + ((ColumnaImpresión - 1) * 270), 118 + ((FilaImpresión - 1) * sepvertical))
                e.Graphics.DrawString(Mid(VariablesBase.VariablesBase.Nombre_Usuario, 1, 80), Formato_Etiqueta_5, Brocha, 150 + ((ColumnaImpresión - 1) * 270), 118 + ((FilaImpresión - 1) * sepvertical))
                ContaStickerVector = ContaStickerVector + 1
                ContaStickerImpreso = ContaStickerImpreso + 1
                End If
                    If ContaStickerVector >= CantidadTotalSticker Then
                        Exit For
                    End If
            Next
            If ContaStickerVector >= CantidadTotalSticker Then
                Exit For
            End If
        Next

        If ContaStickerVector >= CantidadTotalSticker Then
            contpaginas = 1
            ContaStickerImpreso = 1
            ContaStickerVector = 0
            e.HasMorePages = False
        Else
            contpaginas = contpaginas + 1
            e.HasMorePages = True
        End If
    End Sub
#End Region

#Region "78 - Imprimir Remision y remision valorizada media carta combinada"
    Dim WithEvents DocImp_RemisiónDeMaterialesCombinada As New PrintDocument 'Documento a imprimir


    Private Sub DocImpRemisiónDeMaterialesCombinada(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RemisiónDeMaterialesCombinada.PrintPage
        If cargardatasetremisión = True Then

            _copiaparadestinatario = copiaparadestinatario
            _copiaparatransportador = copiaparatransportador
            _copiaparaporteriasalida = copiaparaporteriasalida
            _copiaparaconsecutivo = copiaparaconsecutivo
            Dim Cadena_Consulta As String = "SELECT * FROM dbo.ImprimirRemisión(" + IDREMISIONIMPRESION.ToString + ") AS ImprimirRemisión"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            dt_Remisión = New DataTable
            Adaptador.FillSchema(dt_Remisión, SchemaType.Source)
            Adaptador.Fill(dt_Remisión)
            Consulta.Connection.Close()
            FilaRemisión = dt_Remisión.Rows(0)
            ContadorCopiasCompartidoImpresas = 0
            cargardatasetremisión = False
            paginastotalRemision = 0
            If Me.copiaparadestinatario = True Then
                copiasRemision += 1
            End If
            If Me.copiaparatransportador = True Then
                copiasRemision += 1
            End If
            If Me.copiaparaconsecutivo = True Then
                copiasRemision += 1
            End If
            If Me.copiaparaporteriasalida = True Then
                copiasRemision += 1
            End If
            If Me.copiaparadestinatarioR = True Then
                copiasRemision += 1
            End If
            If Me.copiaparatransportadorR = True Then
                copiasRemision += 1
            End If
            If Me.copiaparaconsecutivoR = True Then
                copiasRemision += 1
            End If
            If Me.copiaparaporteriasalidaR = True Then
                copiasRemision += 1
            End If
        End If
        'Calcular valor total de la remisión.
        For i = ContadorItemRemisión To dt_Remisión.Rows.Count - 1
            Dim filaItemRemision As DataRow
            filaItemRemision = dt_Remisión.Rows(i)
            ValorTotalRemision += filaItemRemision("VALORUNITARIOIVA") * filaItemRemision("CANTIDAD")
        Next
Line3:
        If Me.ActivarImpresionVistaPrevia = True Then
            Me.vistapreviack = False
            If Me.copiaparadestinatariotemp = True Then
                Me.copiaparadestinatario = True
                Me.copiaparadestinatariotemp = False
            Else
                If copiaparatransportadortemp = True Then
                    Me.copiaparatransportador = True
                    Me.copiaparatransportadortemp = False
                Else
                    If copiaparaconsecutivotemp = True Then
                        Me.copiaparaconsecutivo = True
                        Me.copiaparaconsecutivotemp = False
                    Else
                        If copiaparaporteriasalidatemp = True Then
                            Me.copiaparaporteriasalida = True
                            Me.copiaparaporteriasalidatemp = False
                        Else
                            If Me.copiaparadestinatarioRtemp = True Then
                                Me.copiaparadestinatarioR = True
                                Me.copiaparadestinatarioRtemp = False
                            Else
                                If copiaparatransportadorRtemp = True Then
                                    Me.copiaparatransportadorR = True
                                    Me.copiaparatransportadorRtemp = False
                                Else
                                    If copiaparaconsecutivoRtemp = True Then
                                        Me.copiaparaconsecutivoR = True
                                        Me.copiaparaconsecutivoRtemp = False
                                    Else
                                        If copiaparaporteriasalidaRtemp = True Then
                                            Me.copiaparaporteriasalidaR = True
                                            Me.copiaparaporteriasalidaRtemp = False
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Dim Imprimiendo As Integer '0 remision, 1 remision valorizada
        If Me.copiaparadestinatario = True Then
            copiapara = "DESTINATARIO"
            Imprimiendo = 0
            ContadorCopiasCompartidoImpresas += 1
        Else
            If copiaparatransportador = True Then
                copiapara = "TRANSPORTADOR"
                Imprimiendo = 0
                ContadorCopiasCompartidoImpresas += 1
            Else
                If copiaparaconsecutivo = True Then
                    copiapara = "CONSECUTIVO"
                    Imprimiendo = 0
                    ContadorCopiasCompartidoImpresas += 1
                Else
                    If copiaparaporteriasalida = True Then
                        copiapara = "PORTERÍA SALIDA"
                        Imprimiendo = 0
                        ContadorCopiasCompartidoImpresas += 1
                        Me.copiaparaporteriasalida = False
                    Else
                        If Me.copiaparadestinatarioR = True Then
                            copiapara = "DESTINATARIO"
                            Imprimiendo = 1
                            ContadorCopiasCompartidoImpresas += 1
                        Else
                            If copiaparatransportadorR = True Then
                                copiapara = "TRANSPORTADOR"
                                Imprimiendo = 1
                                ContadorCopiasCompartidoImpresas += 1
                            Else
                                If copiaparaconsecutivoR = True Then
                                    copiapara = "CONSECUTIVO"
                                    Imprimiendo = 1
                                    ContadorCopiasCompartidoImpresas += 1
                                Else
                                    If copiaparaporteriasalidaR = True Then
                                        copiapara = "PORTERÍA SALIDA"
                                        Imprimiendo = 1
                                        ContadorCopiasCompartidoImpresas += 1
                                        Me.copiaparaporteriasalidaR = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Brocha.Color = Color.Black

        'Verificar si el Centro de Costo pertenece a Zamorana.
        If hsCentrosOperacionZamorana.Contains(Left(FilaRemisión("CARGOA"), 3)) OrElse hsBodegasZamorana.Contains(Trim(FilaRemisión("ABREVIATURABODEGAORIGEN"))) Then
            If MsgBox("¿Desea imprimir la requisición con el logo de ZAMORANA?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                LogoEmpresa = 2 ' Logo de Zamorana
            End If
        ElseIf VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Dim AlturaInicioImpresion As Integer

        Dim CantidadArticulos As Integer = dt_Remisión.Rows.Count
        Dim CantidadEquipos As Integer = 0
        For i As Integer = 0 To dt_Remisión.Rows.Count - 1
            Dim filaCantItemRemision As DataRow 'Articulos
            filaCantItemRemision = dt_Remisión.Rows(i)
            Dim dscantequipos As New DataSet 'Equipos asociados al articulo
            dscantequipos = bddatos.ModificarCustodias(9, 0, filaCantItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
            CantidadEquipos += dscantequipos.Tables(0).Rows.Count
        Next

        If MediaCarta2 = True Then
            Dim Modulo As Integer
            Modulo = ContadorCopiasCompartidoImpresas Mod 2

            If Modulo = 1 Then
                AlturaInicioImpresion = 20
            Else
                AlturaInicioImpresion = 550
            End If

            Dim PiePagina As String = ""
            PiePagina = "Página 1 de 1"

            If Imprimiendo = 0 Then

                Select Case LogoEmpresa
                    Case 0 'ISMOCOL S.A.
                        'Cambiar el tamaño del logo dependiendo si tiene 1 o mas items y se ubica mas arriba
                        e.Graphics.DrawImage(imagen, 35, AlturaInicioImpresion, 60, 55)
                        'Se ubica arriba la caja del formato
                        e.Graphics.DrawRectangle(Lapiz, 700, AlturaInicioImpresion, 100, 30)
                        e.Graphics.DrawLine(Lapiz, 700, AlturaInicioImpresion + 15, 800, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString("ICS - GRAL - F - 022", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 2)
                        e.Graphics.DrawString("   REVISIÓN No. 2", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 18)
                        e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 5)
                        e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 325 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 185, e), AlturaInicioImpresion + 5)
                        e.Graphics.DrawLine(Lapiz, 325, AlturaInicioImpresion + 15, 509, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, Brocha, 325 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, 185, e), AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 590, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 590, AlturaInicioImpresion + 5)
                        DrawRoundedRectangle(e.Graphics, 325, AlturaInicioImpresion, 185, 40, 15)
                    Case 1 'CSI
                        e.Graphics.DrawImage(imagenCSI, 35, AlturaInicioImpresion, 60, 55)
                        e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 5)
                        e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_13, Brushes.Black, 130, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 380 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 185, e), AlturaInicioImpresion + 5)
                        e.Graphics.DrawLine(Lapiz, 380, AlturaInicioImpresion + 15, 565, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, Brocha, 380 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, 175, e), AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 690, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 690, AlturaInicioImpresion + 5)
                        DrawRoundedRectangle(e.Graphics, 380, AlturaInicioImpresion, 185, 40, 15)
                    Case 2 'ZAMORANA
                        e.Graphics.DrawImage(zamorana, 35, AlturaInicioImpresion, 170, 45)
                        e.Graphics.DrawRectangle(Lapiz, 700, AlturaInicioImpresion, 100, 30)
                        e.Graphics.DrawLine(Lapiz, 700, AlturaInicioImpresion + 15, 800, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString("ZMS - GRAL - F - 011", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 4)
                        e.Graphics.DrawString("   REVISIÓN No. 0", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 18)
                        e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_13, Brushes.Black, 220, AlturaInicioImpresion + 5)
                        e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_13, Brushes.Black, 220, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 380 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 185, e), AlturaInicioImpresion + 5)
                        e.Graphics.DrawLine(Lapiz, 380, AlturaInicioImpresion + 15, 565, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, Brocha, 380 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_10, 185, e), AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 590, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 590, AlturaInicioImpresion + 5)
                        DrawRoundedRectangle(e.Graphics, 380, AlturaInicioImpresion, 185, 40, 15)
                End Select
                Dim AltRectInicial, AltRectDos, AltRectTres, AltRecCuatro, AltRecCinco As Integer
                AltRectInicial = AlturaInicioImpresion + 60
                AltRectDos = AlturaInicioImpresion + 105
                AltRectTres = AlturaInicioImpresion + 125
                AltRecCuatro = AlturaInicioImpresion + 388
                AltRecCinco = AlturaInicioImpresion + 411
                DrawRoundedRectangle(e.Graphics, 30, AltRectInicial, 770, 35, 15) 'Primer Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRectDos, 770, 15, 10) 'Segundo Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRectTres, 770, 249, 15) 'Tercer Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRecCuatro, 770, 20, 15) 'Cuarto Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRecCinco, 770, 93, 15) 'Quinto Rectangulo redondeado grande

                Dim AltLineasPrimerRec As Integer
                AltLineasPrimerRec = AlturaInicioImpresion + 45
                e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 580, AltLineasPrimerRec) 'horizontal
                e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 130, AltLineasPrimerRec + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, 320, AltLineasPrimerRec, 320, AltLineasPrimerRec + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, 420, AltLineasPrimerRec, 420, AltLineasPrimerRec + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, 580, AltLineasPrimerRec, 580, AltLineasPrimerRec + 15) 'Vertical
                e.Graphics.DrawString("NOMBRE BODEGA", Formato_Etiqueta_6, Brocha, 165, AltLineasPrimerRec + 3)
                e.Graphics.DrawString("CLAVE", Formato_Etiqueta_6, Brocha, 340, AltLineasPrimerRec + 3)
                e.Graphics.DrawString("SA: " + FilaRemisión("SALIDAALMACEN"), Formato_Etiqueta_6, Brocha, 430, AltLineasPrimerRec + 3)
                e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 20)
                Dim bodega As String = Trim(FilaRemisión("BODEGAORIGEN"))
                Select Case bodega.Length
                    Case Is < 23
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 20)
                    Case Else
                        If bodega.Length > 33 Then
                            e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 17)
                            e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 27)
                        Else
                            e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 20)
                        End If
                End Select
                e.Graphics.DrawString(FilaRemisión("ABREVIATURABODEGAORIGEN"), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 20)
                e.Graphics.DrawLine(Lapiz, 30, AltLineasPrimerRec + 34, 800, AltLineasPrimerRec + 34)
                e.Graphics.DrawString("CIUDAD Y FECHA", Formato_Etiqueta_7, Brocha, 550, AltLineasPrimerRec + 20)
                e.Graphics.DrawString("DESTINO", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 37)
                bodega = Trim(FilaRemisión("DESTINO"))
                Select Case bodega.Length
                    Case Is < 23
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 37)
                    Case Else
                        If bodega.Length > 33 Then
                            e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                            e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                        Else
                            e.Graphics.DrawString(Mid(bodega, 1, 50), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                            e.Graphics.DrawString(Mid(bodega, 50, 100), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                        End If
                End Select
                e.Graphics.DrawString(Trim(FilaRemisión("ABREVIATURADESTINO")), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 37)
                Dim Ciuyfechas As String = Trim(FilaRemisión("CIUDAD").ToString) + "   /  " + FilaRemisión("FECHA")
                e.Graphics.DrawString(Ciuyfechas, Formato_Etiqueta_7, Brocha, 420 + InicioCentradoTexto(Ciuyfechas, Formato_Etiqueta_8, 380, e), AltLineasPrimerRec + 37)
                e.Graphics.DrawString("DESPACHADO VÍA:  " + FilaRemisión("DESPACHADO"), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 50)

                Dim observa As String = Trim(FilaRemisión("OBSERVACION"))
                If observa.Length > 140 Then
                    Dim observa1 As String = Trim(Mid(observa, 1, 140))
                    Dim pos As Integer
                    pos = observa1.LastIndexOf(" ")
                    observa1 = Trim(Mid(observa, 1, pos))
                    e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_5, Brocha, 35, AltLineasPrimerRec + 60)
                    observa = Trim(Mid(observa, pos + 1, observa.Length))
                    e.Graphics.DrawString(observa, Formato_Etiqueta_5, Brocha, 83, AltLineasPrimerRec + 67)
                Else
                    e.Graphics.DrawString("Observación: " + Mid(observa, 1, 140), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 63)
                End If

                e.Graphics.DrawString("REQUISICIÓN", Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto("REQUISICIÓN", Formato_Etiqueta_6, 90, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 120, AltRectTres, 120, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 150, AltRectTres, 150, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto("UN/M", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 180, AltRectTres, 180, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
                e.Graphics.DrawString("DESPACHADA", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("DESPACHADA", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
                e.Graphics.DrawLine(Lapiz, 240, AltRectTres, 240, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
                e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("ARTÍCULO", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
                e.Graphics.DrawLine(Lapiz, 300, AltRectTres, 300, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, 300 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_7, 320, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 620, AltRectTres, 620, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("ORDEN DE", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("ORDEN DE", Formato_Etiqueta_5, 90, e), AltRectTres + 3)
                e.Graphics.DrawString("COMPRA", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("COMPRA", Formato_Etiqueta_5, 90, e), AltRectTres + 10)
                e.Graphics.DrawLine(Lapiz, 710, AltRectTres, 710, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("# CAJA /", Formato_Etiqueta_4, Brocha, 710 + InicioCentradoTexto("# CAJA /", Formato_Etiqueta_5, 45, e), AltRectTres + 1)
                e.Graphics.DrawString("PAQUETE /", Formato_Etiqueta_4, Brocha, 710 + InicioCentradoTexto("PAQUETE /", Formato_Etiqueta_5, 45, e), AltRectTres + 7)
                e.Graphics.DrawString("BULTO", Formato_Etiqueta_4, Brocha, 710 + InicioCentradoTexto("BULTO", Formato_Etiqueta_5, 45, e), AltRectTres + 14)
                e.Graphics.DrawLine(Lapiz, 755, AltRectTres, 755, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("CANT.", Formato_Etiqueta_5, Brocha, 755 + InicioCentradoTexto("CANT.", Formato_Etiqueta_5, 45, e), AltRectTres + 3)
                e.Graphics.DrawString("RECIBIDA", Formato_Etiqueta_5, Brocha, 755 + InicioCentradoTexto("RECIBIDA", Formato_Etiqueta_5, 45, e), AltRectTres + 10)

                e.Graphics.DrawLine(Lapiz, 30, AltRectTres + 21, 800, AltRectTres + 21) 'horizontal

                Dim lineaPunteada As New Pen(Color.Gray, 1)
                lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

                Dim InicioYdeItemRem As Integer
                InicioYdeItemRem = AlturaInicioImpresion + 147

                ContadorItemRemisión = CantidadArticulos
                contcopiasRemision += 1

                '-----------------------------------

                Const CantidadRenglones As Integer = 6
                Const EspacioVertical As Integer = 9

                Dim InicioImpresionItems As Integer
                InicioImpresionItems = AlturaInicioImpresion + 147
                Dim ContadorRenglones2 As Integer = 0

                For i As Integer = 0 To CantidadArticulos - 1
                    Dim filaItemRemision As DataRow
                    filaItemRemision = dt_Remisión.Rows(i)
                    Dim Cadenas1 As New ArrayList
                    Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
                    Dim Cadena_Total1 As New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                    Dim tempTexto As String = ""
                    tempTexto = IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION"))
                    e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 30 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_5, Brocha, 120 + InicioCentradoTexto(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_5, Brocha, 150 + InicioCentradoTexto(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                    tempTexto = IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA"))
                    e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                    ContadorRenglones = 0
                    Dim LargoArticulo As Integer = Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                    Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                        Case Is < 73
                            e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 91
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 2)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 141
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 71, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + 10)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 181
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 10)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 9)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 181, 90), Formato_Etiqueta_4, Brocha, 302, InicioYdeItemRem + 18)
                            ContadorRenglones = ContadorRenglones + 1
                    End Select

                    '------------componentes------------

                    Dim dsequipos As New DataSet
                    'Const EspacioVertical As Integer = 9
                    dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                    If dsequipos.Tables(0).Rows.Count > 0 Then
                        'crear la cadena de códigos
                        Dim cadenaEquipos As String
                        cadenaEquipos = "Códigos: "
                        Dim j As Integer
                        For j = 0 To dsequipos.Tables(0).Rows.Count - 1
                            cadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                            If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                                cadenaEquipos += ", "
                            End If
                        Next
                        Cadenas1.Clear()
                        Cadenas1.Add(Trim(cadenaEquipos))
                        Dim formatoetiqueta
                        If dsequipos.Tables(0).Rows.Count < 3 Then
                            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)
                            formatoetiqueta = Formato_Etiqueta_5
                        Else
                            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_4, 310, e)
                            formatoetiqueta = Formato_Etiqueta_4
                        End If

                        Dim resta As Integer
                        resta = 0
                        e.Graphics.DrawLine(lineaPunteada, 300, InicioYdeItemRem + (ContadorRenglones * EspacioVertical), 620, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))  'Horizontal
                        For k = 0 To Cadena_Total1.Count - 2
                            If k <> 0 Then
                                resta = 2
                            End If
                            e.Graphics.DrawString(Cadena_Total1(k), formatoetiqueta, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical) - resta)
                            ContadorRenglones = ContadorRenglones + 1
                            If ContadorRenglones >= CantidadRenglones Then
                                'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                                Dim cadena2 As New ArrayList
                                For z = k + 1 To Cadena_Total1.Count - 2
                                    cadena2.Add(Cadena_Total1(z))
                                Next
                                listaComponentes = cadena2
                                ContadorItemRemisión = ContadorItemRemisión - 1
                                completarcomponentes = True
                                Exit For
                            End If
                        Next

                    End If
                    '-----------------------------------
                    ContadorRenglones2 += ContadorRenglones
                    If ContadorRenglones2 <= CantidadRenglones - 1 Then
                        e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem + (EspacioVertical * ContadorRenglones)) 'horizontal
                    End If
                    InicioYdeItemRem = InicioYdeItemRem + (ContadorRenglones * EspacioVertical)
                Next

                e.Graphics.DrawLine(Lapiz, 30, InicioImpresionItems + 50, 800, InicioImpresionItems + 50) 'horizontal

                Dim InicioLineas As Integer = InicioImpresionItems + 54

                e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 83) 'vertical
                e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 83) 'vertical
                e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 83) 'vertical
                e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 83) 'vertical

                e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 160, InicioLineas + 3)
                e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 315, InicioLineas + 3)
                e.Graphics.DrawString("VERIFICA", Formato_Etiqueta_7, Brocha, 510, InicioLineas + 3)
                e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 690, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas) 'horizontal


                e.Graphics.DrawString(FilaRemisión("DIGITA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(FilaRemisión("DIGITA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
                e.Graphics.DrawString(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, Brocha, 280 + InicioCentradoTexto(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
                e.Graphics.DrawString(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, Brocha, 460 + InicioCentradoTexto(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, 170, e), InicioLineas + 53) 'Verifica

                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 32
                e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17

                e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 89) 'vertical
                e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
                e.Graphics.DrawString("ENVIO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 72) 'vertical
                e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
                e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 10)
                e.Graphics.DrawString(FilaRemisión("TRANSPORTADOR"), Formato_Etiqueta_7, Brocha, 400, InicioLineas + 10)

                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 22
                e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                Dim Despacho As String = FilaRemisión("DESPACHADO")

                If Despacho.Length > 50 Then
                    e.Graphics.DrawString(Mid(Despacho, 1, 45), Formato_Etiqueta_5, Brocha, 105, InicioLineas)
                    e.Graphics.DrawString(Mid(Despacho, 46, 90), Formato_Etiqueta_5, Brocha, 105, InicioLineas + 7)
                Else
                    e.Graphics.DrawString(Despacho, Formato_Etiqueta_6, Brocha, 105, InicioLineas + 3)
                End If

                e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
                e.Graphics.DrawString(FilaRemisión("GUIA"), Formato_Etiqueta_8, Brocha, 400, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 19

                e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_6, Brocha, 35, InicioLineas)
                InicioLineas = InicioLineas + 20
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 8, 100, InicioLineas + 11) 'vertical
                e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 8, 330, InicioLineas + 11) 'vertical
                e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 8, 580, InicioLineas + 11) 'vertical
                e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas - 4)
                e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas - 4)
                e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas - 4)
                InicioLineas = InicioLineas + 20

                e.Graphics.DrawString("RECIBEN Y VERIFICAN", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
                InicioLineas = InicioLineas + 15
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 2, 100, InicioLineas + 72) 'vertical seccion reciben y verifican
                e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 2, 330, InicioLineas + 72) 'vertical seccion reciben y verifican
                e.Graphics.DrawLine(Lapiz, 590, InicioLineas - 2, 590, InicioLineas + 72) 'vertical seccion reciben y verifican
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 2, 800, InicioLineas - 2) 'Horizontal seccion reciben y verifican
                e.Graphics.DrawString("SEGURIDAD FÍSICA", Formato_Etiqueta_7, Brocha, 150, InicioLineas)
                e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 420, InicioLineas)
                e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7, Brocha, 650, InicioLineas)
                InicioLineas = InicioLineas + 10
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas + 1, 800, InicioLineas + 1) 'horizontal seccion reciben y verifican
                e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
                InicioLineas = InicioLineas + 30
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
                e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
                e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)

                If ContadorCopiasCompartidoImpresas = 1 Or ContadorCopiasCompartidoImpresas = 3 Or ContadorCopiasCompartidoImpresas = 5 Or ContadorCopiasCompartidoImpresas = 7 Then
                    e.Graphics.DrawLine(lineaPunteada, 0, InicioLineas + 23, 1000, InicioLineas + 23) 'horizontal
                End If

                If ContadorCopiasCompartidoImpresas < copiasRemision Then
                    e.HasMorePages = True
                    ContadorRenglones = 0

                    If Me.vistapreviack = True Then
                        If Me.copiaparadestinatario = True Then
                            Me.copiaparadestinatariotemp = True
                        End If
                        If copiaparatransportador = True Then
                            Me.copiaparatransportadortemp = True
                        End If
                        If copiaparaconsecutivo = True Then
                            Me.copiaparaconsecutivotemp = True
                        End If
                        If copiaparaporteriasalida = True Then
                            Me.copiaparaporteriasalidatemp = True
                        End If
                    End If

                    If Me.copiaparadestinatario = True Then
                        Me.copiaparadestinatario = False
                    Else
                        If copiaparatransportador = True Then
                            Me.copiaparatransportador = False
                        Else
                            If copiaparaconsecutivo = True Then
                                Me.copiaparaconsecutivo = False
                            Else
                                If copiaparaporteriasalida = True Then
                                    Me.copiaparaporteriasalida = False
                                End If
                            End If
                        End If
                    End If
                Else
                    e.HasMorePages = False
                    paginastotalRemision = contpaginas
                    ContadorCopiasCompartidoImpresas = 0
                    If Me.vistapreviack = True Then
                        Me.ActivarImpresionVistaPrevia = True
                        ContadorItemRemisión = 0
                        ValorTotalRemision = 0
                    End If
                End If
                If e.HasMorePages = True Then
                    If ContadorCopiasCompartidoImpresas = 1 Or ContadorCopiasCompartidoImpresas = 3 Or ContadorCopiasCompartidoImpresas = 5 Or ContadorCopiasCompartidoImpresas = 7 Then GoTo Line3
                End If

            Else

                Dim tipoenvio As String = ""
                If Not IsDBNull(FilaRemisión("TIPOENVIO")) Then
                    tipoenvio = FilaRemisión("TIPOENVIO")
                Else
                    tipoenvio = "N"
                End If
                Select Case LogoEmpresa
                    Case 0 'ISMOCOL S.A.
                        'Cambiar el tamaño del logo dependiendo si tiene 1 o mas items y se ubica mas arriba
                        e.Graphics.DrawImage(imagen, 35, AlturaInicioImpresion, 60, 55)
                        'Se ubica arriba la caja del formato
                        e.Graphics.DrawRectangle(Lapiz, 700, AlturaInicioImpresion, 100, 30)
                        e.Graphics.DrawLine(Lapiz, 700, AlturaInicioImpresion + 15, 800, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString("ICS - GRAL - F - 102", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 2)
                        e.Graphics.DrawString("   REVISIÓN No. 1", Formato_Etiqueta_6, Brushes.Black, 710, AlturaInicioImpresion + 18)
                        e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion - 5)
                        e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 10)
                        e.Graphics.DrawString("VALORIZADA", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 25)
                        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 445 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 120, e), AlturaInicioImpresion + 4)
                        e.Graphics.DrawLine(Lapiz, 445, AlturaInicioImpresion + 15, 565, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, Brocha, 445 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, 120, e), AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 590, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 590, AlturaInicioImpresion + 5)
                        DrawRoundedRectangle(e.Graphics, 445, AlturaInicioImpresion, 120, 40, 15)

                        Select Case tipoenvio
                            Case "E", "I"
                                'If copiapara <> "TRANSPORTADOR" Then
                                e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 290, AlturaInicioImpresion + 5)
                                e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_11, e, 90), Formato_Etiqueta_13, Brushes.Black, 290, AlturaInicioImpresion + 20)
                                'End If
                                If FilaRemisión("TIPOENVIO") = "E" Then
                                    'If True = True Then
                                    e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                                ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                                    e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                                End If
                            Case Else
                                'If copiapara <> "TRANSPORTADOR" Then
                                e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 290, AlturaInicioImpresion + 5)
                                e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_10, e, 90), Formato_Etiqueta_13, Brushes.Black, 290, AlturaInicioImpresion + 20)
                                'End If
                        End Select

                    Case 1 'CSI
                        e.Graphics.DrawImage(imagenCSI, 35, AlturaInicioImpresion, 60, 55)
                        e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion - 5)
                        e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 10)
                        e.Graphics.DrawString("VALORIZADA", Formato_Etiqueta_11, Brushes.Black, 130, AlturaInicioImpresion + 25)
                        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 543 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 120, e), AlturaInicioImpresion + 4)
                        e.Graphics.DrawLine(Lapiz, 543, AlturaInicioImpresion + 15, 663, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, Brocha, 543 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, 120, e), AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 680, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 680, AlturaInicioImpresion + 5)
                        DrawRoundedRectangle(e.Graphics, 543, AlturaInicioImpresion, 120, 40, 15)
                        Select Case tipoenvio
                            Case "E", "I"
                                'If copiapara <> "TRANSPORTADOR" Then
                                e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 330, AlturaInicioImpresion + 5)
                                e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_11, e, 90), Formato_Etiqueta_13, Brushes.Black, 330, AlturaInicioImpresion + 20)
                                'End If
                                If FilaRemisión("TIPOENVIO") = "E" Then
                                    'If True = True Then
                                    e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                                ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                                    e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                                End If
                            Case Else
                                'If copiapara <> "TRANSPORTADOR" Then
                                e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 330, AlturaInicioImpresion + 5)
                                e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_10, e, 90), Formato_Etiqueta_13, Brushes.Black, 330, AlturaInicioImpresion + 20)
                                'End If
                        End Select
                    Case 2 'ZAMORANA
                        e.Graphics.DrawImage(zamorana, 35, AlturaInicioImpresion, 170, 45)
                        e.Graphics.DrawString("REMISIÓN DE", Formato_Etiqueta_10, Brushes.Black, 220, AlturaInicioImpresion - 5)
                        e.Graphics.DrawString("MATERIALES", Formato_Etiqueta_11, Brushes.Black, 220, AlturaInicioImpresion + 10)
                        e.Graphics.DrawString("VALORIZADA", Formato_Etiqueta_10, Brushes.Black, 220, AlturaInicioImpresion + 25)
                        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_6, Brocha, 543 + InicioCentradoTexto("NÚMERO", Formato_Etiqueta_6, 120, e), AlturaInicioImpresion + 4)
                        e.Graphics.DrawLine(Lapiz, 543, AlturaInicioImpresion + 15, 663, AlturaInicioImpresion + 15)
                        e.Graphics.DrawString(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, Brocha, 543 + InicioCentradoTexto(FilaRemisión("IDREMISION"), Formato_Etiqueta_9, 120, e), AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(PiePagina, Formato_Etiqueta_6, Brushes.Black, 680, AlturaInicioImpresion + 20)
                        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, 680, AlturaInicioImpresion + 5)
                        DrawRoundedRectangle(e.Graphics, 543, AlturaInicioImpresion, 120, 40, 15)


                        Select Case tipoenvio
                            Case "E", "I"
                                'If copiapara <> "TRANSPORTADOR" Then
                                e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 380, AlturaInicioImpresion + 5)
                                e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_11, e, 90), Formato_Etiqueta_13, Brushes.Black, 380, AlturaInicioImpresion + 20)
                                'End If
                                If FilaRemisión("TIPOENVIO") = "E" Then
                                    'If True = True Then
                                    e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                                ElseIf FilaRemisión("TIPOENVIO") = "I" Then
                                    e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 590 + InicioCentradoTexto("IMPORTACIÓN", Formato_Etiqueta_12, 210, e), AlturaInicioImpresion + 40)
                                End If
                            Case Else
                                'If copiapara <> "TRANSPORTADOR" Then
                                e.Graphics.DrawString("TOTAL", Formato_Etiqueta_10, Brushes.Black, 380, AlturaInicioImpresion + 5)
                                e.Graphics.DrawString(FormatearValor(ValorTotalRemision, "$", Formato_Etiqueta_10, e, 90), Formato_Etiqueta_13, Brushes.Black, 380, AlturaInicioImpresion + 20)
                                'End If
                        End Select
                End Select

                Dim AltRectInicial, AltRectDos, AltRectTres, AltRecCuatro, AltRecCinco As Integer
                AltRectInicial = AlturaInicioImpresion + 60
                AltRectDos = AlturaInicioImpresion + 105
                AltRectTres = AlturaInicioImpresion + 125
                AltRecCuatro = AlturaInicioImpresion + 388
                AltRecCinco = AlturaInicioImpresion + 411
                DrawRoundedRectangle(e.Graphics, 30, AltRectInicial, 770, 35, 15) 'Primer Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRectDos, 770, 15, 10) 'Segundo Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRectTres, 770, 249, 15) 'Tercer Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRecCuatro, 770, 20, 15) 'Cuarto Rectangulo redondeado grande
                DrawRoundedRectangle(e.Graphics, 30, AltRecCinco, 770, 93, 15) 'Quinto Rectangulo redondeado grande

                Dim AltLineasPrimerRec As Integer
                AltLineasPrimerRec = AlturaInicioImpresion + 45
                e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 580, AltLineasPrimerRec) 'horizontal
                e.Graphics.DrawLine(Lapiz, 130, AltLineasPrimerRec, 130, AltLineasPrimerRec + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, 320, AltLineasPrimerRec, 320, AltLineasPrimerRec + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, 420, AltLineasPrimerRec, 420, AltLineasPrimerRec + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, 580, AltLineasPrimerRec, 580, AltLineasPrimerRec + 15) 'Vertical
                e.Graphics.DrawString("NOMBRE BODEGA", Formato_Etiqueta_6, Brocha, 165, AltLineasPrimerRec + 3)
                e.Graphics.DrawString("CLAVE", Formato_Etiqueta_6, Brocha, 340, AltLineasPrimerRec + 3)
                e.Graphics.DrawString("SA: " + FilaRemisión("SALIDAALMACEN"), Formato_Etiqueta_6, Brocha, 430, AltLineasPrimerRec + 3)
                e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 20)
                Dim bodega As String = Trim(FilaRemisión("BODEGAORIGEN"))
                Select Case bodega.Length
                    Case Is < 23
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 20)
                    Case Else
                        If bodega.Length > 33 Then
                            e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 17)
                            e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 27)
                        Else
                            e.Graphics.DrawString(bodega, Formato_Etiqueta_6, Brocha, 135, AltLineasPrimerRec + 20)
                        End If
                End Select
                e.Graphics.DrawString(FilaRemisión("ABREVIATURABODEGAORIGEN"), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 20)
                e.Graphics.DrawLine(Lapiz, 30, AltLineasPrimerRec + 34, 800, AltLineasPrimerRec + 34)
                e.Graphics.DrawString("CIUDAD Y FECHA", Formato_Etiqueta_7, Brocha, 550, AltLineasPrimerRec + 20)
                e.Graphics.DrawString("DESTINO", Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 37)
                bodega = Trim(FilaRemisión("DESTINO"))
                Select Case bodega.Length
                    Case Is < 23
                        e.Graphics.DrawString(bodega, Formato_Etiqueta_7, Brocha, 135, AltLineasPrimerRec + 37)
                    Case Else
                        If bodega.Length > 33 Then
                            e.Graphics.DrawString(Mid(bodega, 1, 33), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                            e.Graphics.DrawString(Mid(bodega, 34, 60), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                        Else
                            e.Graphics.DrawString(Mid(bodega, 1, 50), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 35)
                            e.Graphics.DrawString(Mid(bodega, 50, 100), Formato_Etiqueta_4, Brocha, 135, AltLineasPrimerRec + 43)
                        End If
                End Select
                e.Graphics.DrawString(Trim(FilaRemisión("ABREVIATURADESTINO")), Formato_Etiqueta_7, Brocha, 343, AltLineasPrimerRec + 37)
                Dim Ciuyfechas As String = Trim(FilaRemisión("CIUDAD").ToString) + "   /  " + FilaRemisión("FECHA")
                e.Graphics.DrawString(Ciuyfechas, Formato_Etiqueta_7, Brocha, 420 + InicioCentradoTexto(Ciuyfechas, Formato_Etiqueta_8, 380, e), AltLineasPrimerRec + 37)
                e.Graphics.DrawString("DESPACHADO VÍA:  " + FilaRemisión("DESPACHADO"), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 50)

                Dim observa As String = Trim(FilaRemisión("OBSERVACION"))
                If observa.Length > 140 Then
                    Dim observa1 As String = Trim(Mid(observa, 1, 140))
                    Dim pos As Integer
                    pos = observa1.LastIndexOf(" ")
                    observa1 = Trim(Mid(observa, 1, pos))
                    e.Graphics.DrawString("Observación: " + observa1, Formato_Etiqueta_5, Brocha, 35, AltLineasPrimerRec + 60)
                    observa = Trim(Mid(observa, pos + 1, observa.Length))
                    e.Graphics.DrawString(observa, Formato_Etiqueta_5, Brocha, 95, AltLineasPrimerRec + 67)
                Else
                    e.Graphics.DrawString("Observación: " + Mid(observa, 1, 140), Formato_Etiqueta_6, Brocha, 35, AltLineasPrimerRec + 63)
                End If


                e.Graphics.DrawString("REQUISICIÓN", Formato_Etiqueta_6, Brocha, 30 + InicioCentradoTexto("REQUISICIÓN", Formato_Etiqueta_6, 90, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 120, AltRectTres, 120, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, 120 + InicioCentradoTexto("ÍTEM", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 150, AltRectTres, 150, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, 150 + InicioCentradoTexto("UN/M", Formato_Etiqueta_6, 30, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 180, AltRectTres, 180, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("CANTIDAD", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("CANTIDAD", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
                e.Graphics.DrawString("DESPACHADA", Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto("DESPACHADA", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
                e.Graphics.DrawLine(Lapiz, 240, AltRectTres, 240, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("CÓDIGO", Formato_Etiqueta_5, 60, e), AltRectTres + 3)
                e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto("ARTÍCULO", Formato_Etiqueta_5, 60, e), AltRectTres + 10)
                e.Graphics.DrawLine(Lapiz, 300, AltRectTres, 300, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, 300 + InicioCentradoTexto("DESCRIPCIÓN", Formato_Etiqueta_7, 320, e), AltRectTres + 5)
                e.Graphics.DrawLine(Lapiz, 620, AltRectTres, 620, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("ORDEN DE", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("ORDEN DE", Formato_Etiqueta_5, 90, e), AltRectTres + 3)
                e.Graphics.DrawString("COMPRA", Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto("COMPRA", Formato_Etiqueta_5, 90, e), AltRectTres + 10)
                e.Graphics.DrawLine(Lapiz, 720, AltRectTres, 720, AltRectTres + 72) 'vertical

                e.Graphics.DrawString("VALOR", Formato_Etiqueta_6, Brocha, 720 + InicioCentradoTexto("VALOR", Formato_Etiqueta_6, 80, e), AltRectTres + 5)

                e.Graphics.DrawLine(Lapiz, 30, AltRectTres + 21, 800, AltRectTres + 21) 'horizontal

                Dim lineaPunteada As New Pen(Color.Gray, 1)
                lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

                Dim InicioYdeItemRem As Integer
                InicioYdeItemRem = AlturaInicioImpresion + 147

                ContadorItemRemisión = CantidadArticulos
                contcopiasRemision += 1

                '-----------------------------------

                Const CantidadRenglones As Integer = 6
                Const EspacioVertical As Integer = 9

                Dim InicioImpresionItems As Integer
                InicioImpresionItems = AlturaInicioImpresion + 147
                Dim ContadorRenglones2 As Integer = 0

                For i As Integer = 0 To CantidadArticulos - 1
                    Dim filaItemRemision As DataRow
                    filaItemRemision = dt_Remisión.Rows(i)
                    Dim Cadenas1 As New ArrayList
                    Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
                    Dim Cadena_Total1 As New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)

                    Dim tempTexto As String = ""
                    tempTexto = IIf(IsDBNull(filaItemRemision("REQUISICION")), "", filaItemRemision("REQUISICION"))
                    e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 30 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_5, Brocha, 120 + InicioCentradoTexto(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_5, Brocha, 150 + InicioCentradoTexto(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, 30, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_5, Brocha, 180 + InicioCentradoTexto(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                    e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_5, Brocha, 240 + InicioCentradoTexto(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, 60, e), InicioYdeItemRem)
                    tempTexto = IIf(IsDBNull(filaItemRemision("ORDENCOMPRA")), "", filaItemRemision("ORDENCOMPRA"))
                    e.Graphics.DrawString(tempTexto, Formato_Etiqueta_5, Brocha, 620 + InicioCentradoTexto(tempTexto, Formato_Etiqueta_5, 90, e), InicioYdeItemRem)
                    ContadorRenglones = 0
                    Dim LargoArticulo As Integer = Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                    Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                        Case Is < 73
                            e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 91
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 2)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 141
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 71, 70), Formato_Etiqueta_5, Brocha, 305, InicioYdeItemRem + 10)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Is < 181
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 10)
                            ContadorRenglones = ContadorRenglones + 1
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 91, 90), Formato_Etiqueta_4, Brocha, 305, InicioYdeItemRem + 9)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 181, 90), Formato_Etiqueta_4, Brocha, 302, InicioYdeItemRem + 18)
                            ContadorRenglones = ContadorRenglones + 1
                    End Select

                    e.Graphics.DrawString(FormatearValor(CDec(filaItemRemision("VALORUNITARIOIVA") * filaItemRemision("CANTIDAD")), "$", Formato_Etiqueta_6, e, 70), Formato_Etiqueta_6, Brocha, _
                             725, InicioYdeItemRem)
                    '------------componentes------------

                    Dim dsequipos As New DataSet
                    'Const EspacioVertical As Integer = 9
                    dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("IDARTICULO"), 0, 0, FilaRemisión("IDREMISION"), 0)
                    If dsequipos.Tables(0).Rows.Count > 0 Then
                        'crear la cadena de códigos
                        Dim cadenaEquipos As String
                        cadenaEquipos = "Códigos: "
                        Dim j As Integer
                        For j = 0 To dsequipos.Tables(0).Rows.Count - 1
                            cadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                            If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                                cadenaEquipos += ", "
                            End If
                        Next
                        Cadenas1.Clear()
                        Cadenas1.Add(Trim(cadenaEquipos))
                        Dim formatoetiqueta
                        If dsequipos.Tables(0).Rows.Count < 3 Then
                            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 310, e)
                            formatoetiqueta = Formato_Etiqueta_5
                        Else
                            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_4, 310, e)
                            formatoetiqueta = Formato_Etiqueta_4
                        End If

                        Dim resta As Integer
                        resta = 0
                        e.Graphics.DrawLine(lineaPunteada, 300, InicioYdeItemRem + (ContadorRenglones * EspacioVertical), 620, InicioYdeItemRem + (ContadorRenglones * EspacioVertical))  'Horizontal
                        For k = 0 To Cadena_Total1.Count - 2
                            If k <> 0 Then
                                resta = 2
                            End If
                            e.Graphics.DrawString(Cadena_Total1(k), formatoetiqueta, Brocha, 305, InicioYdeItemRem + (ContadorRenglones * EspacioVertical) - resta)
                            ContadorRenglones = ContadorRenglones + 1
                            If ContadorRenglones >= CantidadRenglones Then
                                'el componente excede la capacidad del documento, calcular las filas que puede ocupar y partir la cadena
                                Dim cadena2 As New ArrayList
                                For z = k + 1 To Cadena_Total1.Count - 2
                                    cadena2.Add(Cadena_Total1(z))
                                Next
                                listaComponentes = cadena2
                                ContadorItemRemisión = ContadorItemRemisión - 1
                                completarcomponentes = True
                                Exit For
                            End If
                        Next

                    End If
                    '-----------------------------------
                    ContadorRenglones2 += ContadorRenglones
                    If ContadorRenglones2 <= CantidadRenglones - 1 Then
                        e.Graphics.DrawLine(lineaPunteada, 30, InicioYdeItemRem + (EspacioVertical * ContadorRenglones), 800, InicioYdeItemRem + (EspacioVertical * ContadorRenglones)) 'horizontal
                    End If
                    InicioYdeItemRem = InicioYdeItemRem + (ContadorRenglones * EspacioVertical)
                Next

                e.Graphics.DrawLine(Lapiz, 30, InicioImpresionItems + 50, 800, InicioImpresionItems + 50) 'horizontal

                Dim InicioLineas As Integer = InicioImpresionItems + 54

                e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 83) 'vertical
                e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 83) 'vertical
                e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 83) 'vertical
                e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 83) 'vertical

                e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 160, InicioLineas + 3)
                e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 315, InicioLineas + 3)
                e.Graphics.DrawString("VERIFICA", Formato_Etiqueta_7, Brocha, 510, InicioLineas + 3)
                e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 690, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas) 'horizontal


                e.Graphics.DrawString(FilaRemisión("DIGITA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(FilaRemisión("DIGITA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
                e.Graphics.DrawString(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, Brocha, 280 + InicioCentradoTexto(FilaRemisión("DESPACHA"), Formato_Etiqueta_5, 180, e), InicioLineas + 53)
                e.Graphics.DrawString(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, Brocha, 460 + InicioCentradoTexto(FilaRemisión("AUTORIZA"), Formato_Etiqueta_5, 170, e), InicioLineas + 53) 'Verifica

                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 13)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 32
                e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17

                e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 89) 'vertical
                e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
                e.Graphics.DrawString("ENVIO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 72) 'vertical
                e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
                e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 10)
                e.Graphics.DrawString(FilaRemisión("TRANSPORTADOR"), Formato_Etiqueta_7, Brocha, 400, InicioLineas + 10)

                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 22
                e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                Dim Despacho As String = FilaRemisión("DESPACHADO")

                If Despacho.Length > 50 Then
                    e.Graphics.DrawString(Mid(Despacho, 1, 45), Formato_Etiqueta_5, Brocha, 105, InicioLineas)
                    e.Graphics.DrawString(Mid(Despacho, 46, 90), Formato_Etiqueta_5, Brocha, 105, InicioLineas + 7)
                Else
                    e.Graphics.DrawString(Despacho, Formato_Etiqueta_6, Brocha, 105, InicioLineas + 3)
                End If

                e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
                e.Graphics.DrawString(FilaRemisión("GUIA"), Formato_Etiqueta_8, Brocha, 400, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 3)
                e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas, 800, InicioLineas) 'horizontal
                InicioLineas = InicioLineas + 19

                e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_6, Brocha, 35, InicioLineas)
                InicioLineas = InicioLineas + 20
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 9, 100, InicioLineas + 11) 'vertical
                e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 9, 330, InicioLineas + 11) 'vertical
                e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 9, 580, InicioLineas + 11) 'vertical
                e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas - 4)
                e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas - 4)
                e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas - 4)
                InicioLineas = InicioLineas + 20

                e.Graphics.DrawString("RECIBEN Y VERIFICAN", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
                InicioLineas = InicioLineas + 15
                e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 2, 100, InicioLineas + 72) 'vertical seccion reciben y verifican
                e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 2, 330, InicioLineas + 72) 'vertical seccion reciben y verifican
                e.Graphics.DrawLine(Lapiz, 590, InicioLineas - 2, 590, InicioLineas + 72) 'vertical seccion reciben y verifican
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 2, 800, InicioLineas - 2) 'Horizontal seccion reciben y verifican
                e.Graphics.DrawString("SEGURIDAD FÍSICA", Formato_Etiqueta_7, Brocha, 150, InicioLineas)
                e.Graphics.DrawString("DIGITADOR", Formato_Etiqueta_7, Brocha, 420, InicioLineas)
                e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7, Brocha, 650, InicioLineas)
                InicioLineas = InicioLineas + 10
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas + 1, 800, InicioLineas + 1) 'horizontal seccion reciben y verifican
                e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas + 10)
                InicioLineas = InicioLineas + 30
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
                e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)
                InicioLineas = InicioLineas + 17
                e.Graphics.DrawLine(Lapiz, 30, InicioLineas - 3, 800, InicioLineas - 3) 'horizontal seccion reciben y verifican
                e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7, Brocha, 35, InicioLineas)


                If ContadorCopiasCompartidoImpresas = 1 Or ContadorCopiasCompartidoImpresas = 3 Or ContadorCopiasCompartidoImpresas = 5 Or ContadorCopiasCompartidoImpresas = 7 Then
                    e.Graphics.DrawLine(lineaPunteada, 0, InicioLineas + 23, 1000, InicioLineas + 23) 'horizontal
                End If

                If Me.vistapreviack = True Then
                    If Me.copiaparadestinatarioR = True Then
                        Me.copiaparadestinatarioRtemp = True
                    End If
                    If copiaparatransportadorR = True Then
                        Me.copiaparatransportadorRtemp = True
                    End If
                    If copiaparaconsecutivoR = True Then
                        Me.copiaparaconsecutivoRtemp = True
                    End If
                    If copiaparaporteriasalidaR = True Then
                        Me.copiaparaporteriasalidaRtemp = True
                    End If
                End If

                If ContadorCopiasCompartidoImpresas < copiasRemision Then
                    e.HasMorePages = True
                    ContadorRenglones = 0
                    If Me.copiaparadestinatarioR = True Then
                        Me.copiaparadestinatarioR = False
                    Else
                        If copiaparatransportadorR = True Then
                            Me.copiaparatransportadorR = False
                        Else
                            If copiaparaconsecutivoR = True Then
                                Me.copiaparaconsecutivoR = False
                            Else
                                If copiaparaporteriasalidaR = True Then
                                    Me.copiaparaporteriasalidaR = False
                                End If
                            End If
                        End If
                    End If
                Else
                    If Me.vistapreviack = True Then
                        ActivarImpresionVistaPrevia = True
                        ContadorItemRemisión = 0
                        ValorTotalRemision = 0
                    End If
                    e.HasMorePages = False
                    paginastotalRemision = contpaginas
                    ContadorCopiasCompartidoImpresas = 0
                End If
                If e.HasMorePages = True Then
                    If ContadorCopiasCompartidoImpresas = 1 Or ContadorCopiasCompartidoImpresas = 3 Or ContadorCopiasCompartidoImpresas = 5 Or ContadorCopiasCompartidoImpresas = 7 Then GoTo Line3
                End If


            End If
        End If
    End Sub


#End Region

#Region "80 - STICKER ARTICULOS REF: 67*25 C3 x 30 Rótulos SISTEMAS"
    'Public Tb_Sticker As DataTable
    Public Fecha As Date
    Dim WithEvents DocImp_STICKERARTICULOSREF_67_25_C3x30_SISTEMAS As New PrintDocument 'Documento a imprimir

    Public CargarDatasetEntradaAlmacen1 As Boolean = True

    'Dim CantidadTotalSticker As Integer
    'Dim CalcularCantidad As Boolean = True
    'Dim VectorStickerId As New ArrayList
    'Dim VectorStickerNombre As New ArrayList
    'Dim VectorStickerUnidad As New ArrayList
    'Public InicioImpresión As Integer = 1
    'Dim ContaStickerImpreso As Integer = 1
    'Dim ContaStickerVector As Integer = 0

    Private Sub DocImpSTICKERARTICULOSREF_67_25_C3x30_SISTEMAS(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_STICKERARTICULOSREF_67_25_C3x30_SISTEMAS.PrintPage

        If CargarDatasetEntradaAlmacen1 = True Then
            Dim Cadena_Consulta1 As String

            Cadena_Consulta1 = "SELECT * FROM dbo.ImpresionEntradaAlmacen(" + IDENTRADAALMACEN.ToString + ") AS ImpresionEntradaAlmacen"

            Dim Consulta1 As New SqlClient.SqlCommand(Cadena_Consulta1)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta1.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta1)
            Consulta1.Connection.Open()
            Dt_EntradaAlmacen = New DataTable
            Adaptador.Fill(Dt_EntradaAlmacen)
            Consulta1.Connection.Close()
            FilaEntradaAlmacen = Dt_EntradaAlmacen.Rows(0)
            CargarDatasetEntradaAlmacen = False
            'revisar si se van a incluir equipos

        End If


        If CalcularCantidad = True Then
            CantidadTotalSticker = Tb_Sticker.Compute("Sum(Cant)", "")
            paginastotal = -Int((-CantidadTotalSticker + InicioImpresión) / 30)
            CalcularCantidad = False
            For i = 0 To Tb_Sticker.Rows.Count - 1
                Dim cant As Integer = Tb_Sticker.Rows(i).Item("Cant")
                Dim Fila As DataRow
                Fila = Tb_Sticker.Rows(i)
                For j = 1 To cant
                    VectorStickerId.Add(Fila("Cód"))
                    VectorStickerNombre.Add(Fila("Descripción"))
                    'VectorStickerUnidad.Add(Fila("Und"))
                Next
            Next
        End If
        Dim imprimir As Boolean = False
        For FilaImpresión = 1 To 10
            For ColumnaImpresión = 1 To 3
                If contpaginas = 1 Then
                    'Ubicar la primera impresión de sticker
                    If InicioImpresión > ContaStickerImpreso Then
                        imprimir = False
                        ContaStickerImpreso = ContaStickerImpreso + 1
                    Else
                        imprimir = True
                    End If
                Else
                    imprimir = True
                End If
                If imprimir = True Then
                    Dim sepvertical As Integer = 100
                    'Imprime
                    e.Graphics.DrawString("Cód:  " + VectorStickerId(ContaStickerVector).ToString, Formato_Etiqueta_12, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))


                    Dim Separa As Integer = 10
                    Dim descripcion As String = VectorStickerNombre(ContaStickerVector)
                    Select Case descripcion.Length
                        Case Is < 33
                            e.Graphics.DrawString(descripcion, Formato_Etiqueta_7, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 52 + (Separa) + ((FilaImpresión - 1) * sepvertical))
                            Exit Select
                        Case Is <= 45
                            e.Graphics.DrawString(descripcion, Formato_Etiqueta_6, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 52 + (Separa) + ((FilaImpresión - 1) * sepvertical))
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(descripcion, 1, 45), Formato_Etiqueta_5, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 48 + (Separa) + ((FilaImpresión - 1) * sepvertical))
                            e.Graphics.DrawString(Mid(descripcion, 46, 85), Formato_Etiqueta_5, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 58 + (Separa) + ((FilaImpresión - 1) * sepvertical))
                    End Select

                    'e.Graphics.DrawString("Cód:  " + VectorStickerId(ContaStickerVector).ToString, Formato_Etiqueta_12, Brocha, 20 + ((ColumnaImpresión - 1) * 270), 40 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString("Fecha EA: " + IIf(IsDBNull(Fecha.Date), "", Fecha.Date), Formato_Etiqueta_7, Brocha, 150 + ((ColumnaImpresión - 1) * 270), 45 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString("RQ: " + IIf(IsDBNull(Tb_Sticker.Rows(0).Item("Requisición").ToString), "", Tb_Sticker.Rows(0).Item("Requisición").ToString), Formato_Etiqueta_8, Brocha, 30 + ((ColumnaImpresión - 1) * 270), 82 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString("OC: " + IIf(IsDBNull(Tb_Sticker.Rows(0).Item("Orden Compra").ToString), "", Tb_Sticker.Rows(0).Item("Orden Compra").ToString), Formato_Etiqueta_8, Brocha, 30 + ((ColumnaImpresión - 1) * 270), 95 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString("EA: " + IIf(IsDBNull(Trim(FilaEntradaAlmacen("ENTRADAALMACEN"))), "", Trim(FilaEntradaAlmacen("ENTRADAALMACEN"))), Formato_Etiqueta_8, Brocha, 30 + ((ColumnaImpresión - 1) * 270), 108 + ((FilaImpresión - 1) * sepvertical))

                    ContaStickerVector = ContaStickerVector + 1
                    ContaStickerImpreso = ContaStickerImpreso + 1
                End If
                If ContaStickerVector >= CantidadTotalSticker Then
                    Exit For
                End If
            Next
            If ContaStickerVector >= CantidadTotalSticker Then
                Exit For
            End If
        Next

        If ContaStickerVector >= CantidadTotalSticker Then
            contpaginas = 1
            ContaStickerImpreso = 1
            ContaStickerVector = 0
            e.HasMorePages = False
        Else
            contpaginas = contpaginas + 1
            e.HasMorePages = True
        End If


    End Sub


#End Region


#End Region

#Region "ACTIVOS FIJOS - EQUIPOS"

#Region "70 - REMISION DE MATERIALES REVISIONES EXTERNAS"
    Public IDMANTENIMIENTOEXTERNO As Integer
    Private dtRemisionMtto As DataTable
    Private FilaRemisionMtto As DataRow
    Private WithEvents DocImp_RemisiónRevisionesExternas As New PrintDocument
    Private Sub DocImpRemisiónRevisionesExternas(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RemisiónRevisionesExternas.PrintPage
        Const MargenIzquierdaMtto As Integer = 50
        If cargardatasetremisión = True Then
            _copiaparadestinatario = copiaparadestinatario
            _copiaparatransportador = copiaparatransportador
            _copiaparaporteriasalida = copiaparaporteriasalida
            _copiaparaconsecutivo = copiaparaconsecutivo

            Dim Conexión As New SqlConnection(My.Settings.CadenaConexión)
            Dim Consulta As New SqlCommand("SELECT * FROM dbo.ImprimirRemisiónMantenimientoExterno(" & IDMANTENIMIENTOEXTERNO & ") AS ImprimirRemisión", Conexión)
            Dim Adaptador As New SqlDataAdapter(Consulta)
            dtRemisionMtto = New DataTable
            Consulta.Connection.Open()
            Adaptador.Fill(dtRemisionMtto)
            Consulta.Connection.Close()
            FilaRemisionMtto = dtRemisionMtto.Rows(0)
            cargardatasetremisión = False
            paginastotal = 0
            If Me.copiaparadestinatario = True Then
                copiasOC = copiasOC + 1
            End If
            If Me.copiaparatransportador = True Then
                copiasOC = copiasOC + 1
            End If
            If Me.copiaparaconsecutivo = True Then
                copiasOC = copiasOC + 1
            End If
            If Me.copiaparaporteriasalida = True Then
                copiasOC = copiasOC + 1
            End If
        End If

        If Me.copiaparadestinatario = True Then
            copiapara = "DESTINATARIO"
        Else
            If copiaparatransportador = True Then
                copiapara = "TRANSPORTADOR"
            Else
                If copiaparaconsecutivo = True Then
                    copiapara = "CONSECUTIVO"
                Else
                    If copiaparaporteriasalida = True Then
                        copiapara = "PORTERÍA SALIDA"
                        Me.copiaparaporteriasalida = False
                    End If
                End If
            End If
        End If

        ' Cálculo del valor de la remisión para la aseguradora.
        Dim valorTotalAsegurado As Decimal = 0.0
        For i As Integer = 0 To dtRemisionMtto.Rows.Count - 1
            valorTotalAsegurado += CDec(Trim(dtRemisionMtto.Rows(i).Item("VALORASEGURADORA")))
        Next

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)
        Brocha.Color = Color.Black

        If VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'ISMOCOL
                e.Graphics.DrawImage(imagen, MargenIzquierdaMtto - 15, 40, 75, 60)
            Case 1 'CSI
                e.Graphics.DrawImage(imagenCSI, MargenIzquierdaMtto - 15, 40, 75, 60)
            Case 2 'ZAMORANA
                e.Graphics.DrawImage(zamorana, MargenIzquierdaMtto - 15, 40, 75, 60)
        End Select

        DrawRoundedRectangle(e.Graphics, 605, 48, 195, 70, 15)
        DrawRoundedRectangle(e.Graphics, MargenIzquierdaMtto - 20, 122, 770, 40, 15)
        DrawRoundedRectangle(e.Graphics, MargenIzquierdaMtto - 20, 181, 770, 22, 15)
        DrawRoundedRectangle(e.Graphics, MargenIzquierdaMtto - 20, 208, 770, 660, 15)
        DrawRoundedRectangle(e.Graphics, MargenIzquierdaMtto - 20, 884, 770, 25, 15)
        DrawRoundedRectangle(e.Graphics, MargenIzquierdaMtto - 20, 911, 770, 110, 15)

        e.Graphics.DrawString("REMISIÓN DE EQUIPOS PARA REVISION EXTERNA", Formato_Etiqueta_12, Brushes.Black, 110 + InicioCentradoTexto("REMISIÓN DE EQUIPOS PARA REVISION EXTERNA", Formato_Etiqueta_12, 490, e), 40)
        If copiapara <> "TRANSPORTADOR" Then
            e.Graphics.DrawString("VALOR TOTAL ASEGURADO: " + FormatearValor(valorTotalAsegurado, "$", Formato_Etiqueta_12, e, 120), Formato_Etiqueta_12, Brushes.Black, _
                                  110 + InicioCentradoTexto("VALOR TOTAL ASEGURADO: " + FormatearValor(valorTotalAsegurado, "$", Formato_Etiqueta_12, e, 120), Formato_Etiqueta_12, 490, e), 60)
        End If

        e.Graphics.DrawString("TIPO " & FilaRemisionMtto("TIPO"), Formato_Etiqueta_12, Brushes.Black, 110 + InicioCentradoTexto("TIPO " & FilaRemisionMtto("TIPO"), Formato_Etiqueta_12, 490, e), 80)
        If Not IsDBNull(FilaRemisionMtto("TIPOENVIO")) Then
            If FilaRemisionMtto("TIPOENVIO") = "E" Then
                e.Graphics.DrawString("EXPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 110 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_11, 490, e), 100)
            ElseIf FilaRemisionMtto("TIPOENVIO") = "I" Then
                e.Graphics.DrawString("IMPORTACIÓN", Formato_Etiqueta_11, Brushes.Black, 110 + InicioCentradoTexto("EXPORTACIÓN", Formato_Etiqueta_11, 490, e), 100)
            End If
        End If

        e.Graphics.DrawString("NÚMERO", Formato_Etiqueta_8, Brocha, 675, 53)
        e.Graphics.DrawLine(Lapiz, 605, 70, 800, 70)
        e.Graphics.DrawString("RE-" + FilaRemisionMtto("NROREMISION"), Formato_Etiqueta_16, Brocha, 610 + InicioCentradoTexto("RE-" + FilaRemisionMtto("NROREMISION"), Formato_Etiqueta_16, 185, e), 75)

        e.Graphics.DrawLine(Lapiz, 130, 122, 130, 162) 'Vertical
        e.Graphics.DrawLine(Lapiz, 480, 122, 480, 162) 'Vertical

        e.Graphics.DrawString("ORIGEN", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, 128)
        e.Graphics.DrawString(FilaRemisionMtto("BODEGAORIGEN"), Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto + 85, 128)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, 143, 800, 143)
        e.Graphics.DrawString("CIUDAD Y FECHA DE ENVÍO", Formato_Etiqueta_7, Brocha, 570, 128)
        e.Graphics.DrawString("DESTINO", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, 148)

        e.Graphics.DrawString(FilaRemisionMtto("CONTRATISTA"), Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto + 85, 148)

        Dim ciuyfech As String
        ciuyfech = Trim(FilaRemisionMtto("CIUDAD").ToString) + "  /  " + FilaRemisionMtto("FECHA")

        e.Graphics.DrawString(ciuyfech, Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto + 450 + InicioCentradoTexto(ciuyfech, Formato_Etiqueta_7, 250, e), 148)

        e.Graphics.DrawString("DIRECCION ENVIO: " + FilaRemisionMtto("DIRECCIONENVIO"), Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, 185)

        Dim tituloitem As Integer = 220

        e.Graphics.DrawString("EQUIPO", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto, tituloitem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto + 85, 208, MargenIzquierdaMtto + 85, 473)

        e.Graphics.DrawString("ÍTEM", Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 90, tituloitem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto + 115, 208, MargenIzquierdaMtto + 115, 473)

        e.Graphics.DrawString("UN/M", Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 117, tituloitem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto + 145, 208, MargenIzquierdaMtto + 145, 473)

        e.Graphics.DrawString("CANT", Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 165, tituloitem - 5)
        e.Graphics.DrawString("DESPACHADA", Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 150, tituloitem + 5)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto + 205, 208, MargenIzquierdaMtto + 205, 473)

        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 225, tituloitem - 5)
        e.Graphics.DrawString("ARTÍCULO", Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 220, tituloitem + 5)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto + 278, 208, MargenIzquierdaMtto + 278, 473)

        e.Graphics.DrawString("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto + 383, tituloitem)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto + 545, 208, MargenIzquierdaMtto + 545, 473)

        e.Graphics.DrawString("SERIE", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto + 600, tituloitem)

        Dim InicioYdeItemOC As Integer = 252
        Dim EspacioVertical As Integer = 16
        For lineas = 0 To 14
            e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioYdeItemOC - 3 + (EspacioVertical * lineas), 800, InicioYdeItemOC - 3 + (EspacioVertical * lineas))
        Next

        'Imprimir descripción del servicio
        Dim Cadenasdescripcion As New ArrayList
        Cadenasdescripcion.Add(Trim(FilaRemisionMtto("DESCRIPCION")))
        Dim Cadena_Totaldescripcion As New ArrayList
        Cadena_Totaldescripcion = TextoAParrafoFuente(Cadenasdescripcion, Formato_Etiqueta_10R, 710, e)
        e.Graphics.DrawString("DESCRIPCION DEL SERVICIO", Formato_Etiqueta_10, Brocha, MargenIzquierdaMtto, 480)
        Dim ContadorRenglonesDescripcion As Integer = 0
        Cadena_Totaldescripcion.Add("VALOR ESTIMADO: " + Format(FilaRemisionMtto("VALORESTIMADO"), "##,##0.00") + " " + FilaRemisionMtto("TIPOMONEDA"))
        For neq = 0 To Cadena_Totaldescripcion.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Totaldescripcion(neq), Formato_Etiqueta_10R, 710, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, MargenIzquierdaMtto, 500 + (ContadorRenglonesDescripcion * EspacioVertical))
            ContadorRenglonesDescripcion = ContadorRenglonesDescripcion + 1
        Next
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioYdeItemOC - 3 + (EspacioVertical * 26), 800, InicioYdeItemOC - 3 + (EspacioVertical * 26))

        'Imprimir item's
        For i = ContadorItemRemisión To dtRemisionMtto.Rows.Count - 1
            Dim filaItemRemision As DataRow
            filaItemRemision = dtRemisionMtto.Rows(i)
            Dim Cadenas1 As New ArrayList
            Cadenas1.Add(Trim(filaItemRemision("NOMBREDESCRIPTIVO")))
            Dim Cadena_Total1 As New ArrayList
            Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 285, e)

            If ContadorRenglones + Cadena_Total1.Count - 2 >= 25 Then
                Exit For
            End If

            e.Graphics.DrawString(IIf(IsDBNull(filaItemRemision("EQUIPO")), "", filaItemRemision("EQUIPO")), Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto - 15, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
            e.Graphics.DrawString(filaItemRemision("IDITEMSALIDAALMACEN"), Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 90, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
            e.Graphics.DrawString(filaItemRemision("UNIDAD"), Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 120, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
            e.Graphics.DrawString(filaItemRemision("CANTIDAD"), Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 170, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
            e.Graphics.DrawString(filaItemRemision("IDARTICULO"), Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 220, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
            e.Graphics.DrawString(IIf(IsDBNull(filaItemRemision("SERIE")), "", filaItemRemision("SERIE")), Formato_Etiqueta_6, Brocha, MargenIzquierdaMtto + 567, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))

            Try
                For k = 0 To Cadena_Total1.Count - 2
                    e.Graphics.DrawString(Cadena_Total1(k), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                    ContadorRenglones = ContadorRenglones + 1
                Next
            Catch ex As Exception
                Select Case Trim(filaItemRemision("NOMBREDESCRIPTIVO")).ToString.Length
                    Case Is < 60
                        e.Graphics.DrawString(filaItemRemision("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Is < 120
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 50), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 51, 50), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 1, 50), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 51, 50), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 101, 50), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString(Mid(filaItemRemision("NOMBREDESCRIPTIVO"), 151, 50), Formato_Etiqueta_5, Brocha, MargenIzquierdaMtto + 283, InicioYdeItemOC + (ContadorRenglones * EspacioVertical))
                        ContadorRenglones = ContadorRenglones + 1
                End Select
            End Try
            ContadorItemRemisión = ContadorItemRemisión + 1
            If ContadorRenglones >= 26 Then
                Exit For
            End If
        Next

        Dim InicioLineas As Integer = 680

        e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 89) 'vertical
        e.Graphics.DrawLine(Lapiz, 280, InicioLineas, 280, InicioLineas + 89) 'vertical
        e.Graphics.DrawLine(Lapiz, 460, InicioLineas, 460, InicioLineas + 89) 'vertical
        e.Graphics.DrawLine(Lapiz, 630, InicioLineas, 630, InicioLineas + 89) 'vertical

        e.Graphics.DrawString("REVISA Y DESPACHA", Formato_Etiqueta_7, Brocha, 100 + InicioCentradoTexto("REVISA Y DESPACHA", Formato_Etiqueta_7, 180, e), InicioLineas + 3)
        e.Graphics.DrawString("SOLICITA SERVICIO", Formato_Etiqueta_7, Brocha, 280 + InicioCentradoTexto("SOLICITA SERVICIO", Formato_Etiqueta_7, 180, e), InicioLineas + 3)
        e.Graphics.DrawString("APRUEBA", Formato_Etiqueta_7, Brocha, 460 + InicioCentradoTexto("APRUEBA", Formato_Etiqueta_7, 170, e), InicioLineas + 3)
        e.Graphics.DrawString("RECIBE CONTRATISTA", Formato_Etiqueta_7, Brocha, 630 + InicioCentradoTexto("RECIBE CONTRATISTA", Formato_Etiqueta_7, 170, e), InicioLineas + 3)
        e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 17
        e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 13)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 32
        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 3)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 20
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 3)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 20
        e.Graphics.DrawLine(Lapiz, 330, InicioLineas, 330, InicioLineas + 99) 'vertical

        Dim esEmpresaTransportadora = False
        Dim esTransportador = False
        If Not IsDBNull(FilaRemisionMtto("EMPRESATRANSPORTADORA")) AndAlso FilaRemisionMtto("EMPRESATRANSPORTADORA") <> "" Then
            esEmpresaTransportadora = True
            esTransportador = False
        ElseIf Not IsDBNull(FilaRemisionMtto("TRANSPORTADOR")) AndAlso FilaRemisionMtto("TRANSPORTADOR") <> "" Then
            esEmpresaTransportadora = False
            esTransportador = True
        Else
            esEmpresaTransportadora = False
            esTransportador = False
        End If
        e.Graphics.DrawString("TRANSPORTADOR", Formato_Etiqueta_7, Brocha, 150, InicioLineas + 3)
        e.Graphics.DrawString("ENVIO POR TRANSPORTADORA", Formato_Etiqueta_7, Brocha, 500, InicioLineas + 3)
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 17
        e.Graphics.DrawLine(Lapiz, 100, InicioLineas, 100, InicioLineas + 82) 'vertical
        e.Graphics.DrawString("FIRMA", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 13)
        e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 13)
        If esEmpresaTransportadora Then
            e.Graphics.DrawString(FilaRemisionMtto("EMPRESATRANSPORTADORA"), Formato_Etiqueta_7R, Brocha, 400, InicioLineas + 13)
        End If
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 32
        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 3)
        If esTransportador Then
            e.Graphics.DrawString(FilaRemisionMtto("TRANSPORTADOR"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto + 60, InicioLineas + 3)
        End If
        e.Graphics.DrawString("GUÍA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
        If esEmpresaTransportadora AndAlso Not IsDBNull(FilaRemisionMtto("GUIA")) Then
            e.Graphics.DrawString(FilaRemisionMtto("GUIA"), Formato_Etiqueta_7R, Brocha, 375, InicioLineas + 3)
        End If
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 17
        e.Graphics.DrawString("CELULAR", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 3)
        If esTransportador AndAlso Not IsDBNull(FilaRemisionMtto("CELULAR")) Then
            e.Graphics.DrawString(FilaRemisionMtto("CELULAR"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto + 60, InicioLineas + 3)
        End If
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
        If esEmpresaTransportadora AndAlso Not IsDBNull(FilaRemisionMtto("FECHADESPACHO")) Then
            e.Graphics.DrawString(FilaRemisionMtto("FECHADESPACHO"), Formato_Etiqueta_7R, Brocha, 385, InicioLineas + 3)
        End If
        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 17
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 3)
        If esTransportador AndAlso Not IsDBNull(FilaRemisionMtto("FECHADESPACHO")) Then
            e.Graphics.DrawString(FilaRemisionMtto("FECHADESPACHO"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto + 60, InicioLineas + 3)
        End If
        e.Graphics.DrawString("NOMBRE RESPONSABLE", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 3)
        If esEmpresaTransportadora AndAlso Not IsDBNull(FilaRemisionMtto("NOMBRERESPONSABLE")) Then
            e.Graphics.DrawString(FilaRemisionMtto("NOMBRERESPONSABLE"), Formato_Etiqueta_7R, Brocha, 470, InicioLineas + 3)
        End If

        e.Graphics.DrawLine(Lapiz, MargenIzquierdaMtto - 20, InicioLineas, 800, InicioLineas)
        InicioLineas = InicioLineas + 19

        e.Graphics.DrawString("SEGURIDAD FÍSICA EN ORIGEN", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas)
        InicioLineas = InicioLineas + 20
        e.Graphics.DrawLine(Lapiz, 100, InicioLineas - 7, 100, InicioLineas + 18) 'vertical
        e.Graphics.DrawLine(Lapiz, 330, InicioLineas - 7, 330, InicioLineas + 18) 'vertical
        e.Graphics.DrawLine(Lapiz, 580, InicioLineas - 7, 580, InicioLineas + 18) 'vertical
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 1)
        e.Graphics.DrawString("FECHA Y HORA:", Formato_Etiqueta_7, Brocha, 340, InicioLineas + 1)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7, Brocha, 590, InicioLineas + 1)
        InicioLineas = InicioLineas + 20

        e.Graphics.DrawString(FilaRemisionMtto("DESPACHA"), Formato_Etiqueta_5, Brocha, 100 + InicioCentradoTexto(FilaRemisionMtto("DESPACHA"), Formato_Etiqueta_5, 180, e), 735)
        e.Graphics.DrawString(FilaRemisionMtto("SOLICITA"), Formato_Etiqueta_5, Brocha, 280 + InicioCentradoTexto(FilaRemisionMtto("SOLICITA"), Formato_Etiqueta_5, 180, e), 735)
        e.Graphics.DrawString(FilaRemisionMtto("APRUEBA"), Formato_Etiqueta_5, Brocha, 460 + InicioCentradoTexto(FilaRemisionMtto("APRUEBA"), Formato_Etiqueta_5, 170, e), 735)
        e.Graphics.DrawString(copiapara, Formato_Etiqueta_8, Brushes.Black, MargenIzquierdaMtto, 1050)
        If FilaRemisionMtto("CERRADA") = "S" Then
            e.Graphics.DrawString("SERVICIO CERRADO", Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 10)
            e.Graphics.DrawString("USUARIO CERRO: " + FilaRemisionMtto("CIERRA"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 30)
            e.Graphics.DrawString("PERSONA RECIBIO: " + FilaRemisionMtto("RECIBE"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 20)
            e.Graphics.DrawString("FECHA RECIBIO : " + FilaRemisionMtto("FECHARECIBIDO"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 40)
            e.Graphics.DrawString("VALOR CIERRE: " + Format(FilaRemisionMtto("VALORCIERRE"), "##,##0.00" + " " + FilaRemisionMtto("TIPOMONEDA")), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 50)
            e.Graphics.DrawString("TIPO USO DESPUES CIERRE: " + FilaRemisionMtto("TIPOUSOCERRADO"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 60)
            e.Graphics.DrawString("OBSERVACION: " + FilaRemisionMtto("OBSERVACION"), Formato_Etiqueta_6R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 80)
        Else
            If FilaRemisionMtto("ANULADA") = "S" Then
                e.Graphics.DrawString("SERVICIO ANULADO", Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 10)
                e.Graphics.DrawString("USUARIO ANULO: " + FilaRemisionMtto("ANULA"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 30)
                e.Graphics.DrawString("FECHA ANULACION : " + FilaRemisionMtto("FECHAANULACION"), Formato_Etiqueta_7R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 40)
                e.Graphics.DrawString("OBSERVACION: " + FilaRemisionMtto("OBERVACIONANULACION"), Formato_Etiqueta_6R, Brocha, MargenIzquierdaMtto - 15, InicioLineas + 60)
            End If
        End If

        If ContadorItemRemisión >= dtRemisionMtto.Rows.Count Then
            contpaginas = 1
            ContadorRenglones = 0
            ContadorItemRemisión = 0
            contcopiasOC = contcopiasOC + 1
            If contcopiasOC = copiasOC Then
                e.HasMorePages = False
                contcopiasOC = 0
                copiaparadestinatario = _copiaparadestinatario
                copiaparatransportador = _copiaparatransportador
                copiaparaporteriasalida = _copiaparaporteriasalida
                copiaparaconsecutivo = _copiaparaconsecutivo
            Else
                e.HasMorePages = True
                If Me.copiaparadestinatario = True Then
                    Me.copiaparadestinatario = False
                Else
                    If copiaparatransportador = True Then
                        Me.copiaparatransportador = False
                    Else
                        If copiaparaconsecutivo = True Then
                            Me.copiaparaconsecutivo = False
                        Else
                            If copiaparaporteriasalida = True Then
                                Me.copiaparaporteriasalida = False
                            End If
                        End If
                    End If
                End If
            End If
        Else
            contpaginas = contpaginas + 1
            ContadorRenglones = 0
            e.HasMorePages = True
        End If
    End Sub
#End Region

#Region "71 - HOJA DE VIDA EQUIPOS - ACTIVOS FIJOS"

    Dim WithEvents DocImp_HojaVidaEquipos As New PrintDocument 'Documento a imprimir


    Public IDEQUIPOHOJADEVIDA As Integer
    Public cmdeequipo As New SqlClient.SqlCommand

    Public datascaracteristicasequipo As New DataSet
    Public datasCustodias As New DataSet
    Public datastraslados As New DataSet
    Public datasestadosuso As New DataSet
    Public datasmantenimientos As New DataSet
    Public datasmateriales As New DataSet

    Public daequipo As New SqlClient.SqlDataAdapter
    Dim ContadorRenglonesHojaVida As Integer = 0

    Dim pendienteimprimir As Boolean = False

    Dim CargaPropiedades As Boolean = False
    Dim CargaCustodias As Boolean = False
    Dim CargaTraslados As Boolean = False
    Dim CargaEstadosUso As Boolean = False
    Dim CargaMantenimientos As Boolean = False
    Dim CargaMateriales As Boolean = False

    Dim ContPropiedades As Integer = 0
    Dim ContCustodias As Integer = 0
    Dim ContTraslados As Integer = 0
    Dim ContEstadosUso As Integer = 0
    Dim ContMantenimientos As Integer = 0
    Dim ContMateriales As Integer = 0

    Dim CodigoEquipoHojaVida As String = ""

    Private Sub DocImpHojaVidaEquipos(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_HojaVidaEquipos.PrintPage
        Dim MargenDerecha As Integer = 50
        Dim InicioDespuesEncabezado As Integer = 100

        If VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        If VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0
                e.Graphics.DrawImage(imagen, MargenDerecha - 15, 40, 75, 60) 'ISMOCOL 
                ' e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_14R, Brushes.Black, InicioCentradoTexto("ISMOCOL S.A.", Formato_Etiqueta_14R, 950, e) - 50, 25)
            Case 1
                e.Graphics.DrawImage(imagenCSI, MargenDerecha - 15, 40, 75, 60) 'CSI
            Case 2
                e.Graphics.DrawImage(zamorana, MargenDerecha - 15, 40, 213, 57) 'ZAMORANA
        End Select

        e.Graphics.DrawString("HOJA DE VIDA DE EQUIPO", Formato_Etiqueta_14, Brushes.Black, 280, 40)
        e.Graphics.DrawString(CodigoEquipoHojaVida, Formato_Etiqueta_12, Brocha, 320, 70)

        'Traer las Propiedades y características

        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmdeequipo.Parameters.Clear()
            cmdeequipo.CommandType = CommandType.StoredProcedure
            cmdeequipo.Connection = sqlconeccion
            cmdeequipo.CommandText = "dbo.GestionarEquipos"
            cmdeequipo.Parameters.Add("@accion", SqlDbType.Int).Value = 37
            cmdeequipo.Parameters.Add("@idproveedor", SqlDbType.Int).Value = -1
            cmdeequipo.Parameters.Add("@idarticulo", SqlDbType.Int).Value = -1
            cmdeequipo.Parameters.Add("@idequipo", SqlDbType.Int).Value = IDEQUIPOHOJADEVIDA
            cmdeequipo.Parameters.Add("@idtipo", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idestado", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idmodelo", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idmarca", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@idbodega", SqlDbType.Int).Value = 1
            cmdeequipo.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = ""
            cmdeequipo.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = ""
            cmdeequipo.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = ""
            cmdeequipo.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = ""
            cmdeequipo.Parameters.Add("@activo", SqlDbType.Bit).Value = 0
            cmdeequipo.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = Date.Now

            If CargaPropiedades = False Then
                daequipo = New SqlClient.SqlDataAdapter(cmdeequipo)
                datascaracteristicasequipo = New DataSet()
                daequipo.Fill(datascaracteristicasequipo)
                sqlconeccion.Close()
                CargaPropiedades = True
            End If

            If datascaracteristicasequipo.Tables(0).Rows.Count > 0 And datascaracteristicasequipo.Tables(0).Rows.Count > ContPropiedades Then
                ContadorRenglones = ContadorRenglones + 1

                e.Graphics.DrawString("*  *  *  *  *  (P)  PROPIEDADES  Y  (C)  CARACTERISTICAS  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                For i = ContPropiedades To datascaracteristicasequipo.Tables(0).Rows.Count - 1
                    Dim filacarac As DataRow
                    filacarac = datascaracteristicasequipo.Tables(0).Rows(i)
                    If IsDBNull(filacarac(2)) Then
                        filacarac(2) = ""
                    End If
                    Select Case filacarac(1)
                        Case "Código"
                            e.Graphics.DrawString(filacarac(2), Formato_Etiqueta_12, Brocha, 320, 70)
                            CodigoEquipoHojaVida = filacarac(2)
                        Case Else
                            If filacarac(2).ToString.Length > 80 Then
                                If filacarac(2).ToString.Length > 160 Then
                                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                    e.Graphics.DrawString("(" + filacarac(0) + ")", Formato_Etiqueta_7, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                                    e.Graphics.DrawString(filacarac(1) + " :", Formato_Etiqueta_7, Brocha, 60, InicioDespuesEncabezado + ContadorRenglones * 15)

                                    e.Graphics.DrawLine(Lapiz, 258, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 258, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawString(Mid(filacarac(2), 1, 80), Formato_Etiqueta_7R, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)
                                    ContadorRenglones = ContadorRenglones + 1
                                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                    e.Graphics.DrawLine(Lapiz, 258, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 258, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawString(Mid(filacarac(2), 81, 80), Formato_Etiqueta_7R, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)
                                    ContadorRenglones = ContadorRenglones + 1
                                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                    e.Graphics.DrawLine(Lapiz, 258, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 258, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawString(Mid(filacarac(2), 161, 80), Formato_Etiqueta_7R, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)

                                Else
                                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                    e.Graphics.DrawString("(" + filacarac(0) + ")", Formato_Etiqueta_7, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                                    e.Graphics.DrawString(filacarac(1) + " :", Formato_Etiqueta_7, Brocha, 60, InicioDespuesEncabezado + ContadorRenglones * 15)

                                    e.Graphics.DrawLine(Lapiz, 258, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 258, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawString(Mid(filacarac(2), 1, 80), Formato_Etiqueta_7R, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)
                                    ContadorRenglones = ContadorRenglones + 1
                                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                    e.Graphics.DrawLine(Lapiz, 258, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 258, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                    e.Graphics.DrawString(Mid(filacarac(2), 81, 80), Formato_Etiqueta_7R, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)
                                End If
                            Else
                                e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                e.Graphics.DrawString("(" + filacarac(0) + ")", Formato_Etiqueta_7, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                                e.Graphics.DrawString(filacarac(1) + " :", Formato_Etiqueta_7, Brocha, 60, InicioDespuesEncabezado + ContadorRenglones * 15)
                                e.Graphics.DrawLine(Lapiz, 258, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 258, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                                e.Graphics.DrawString(filacarac(2), Formato_Etiqueta_7R, Brocha, 260, InicioDespuesEncabezado + ContadorRenglones * 15)
                            End If

                            e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    End Select

                    ContPropiedades = ContPropiedades + 1

                    If ContadorRenglones > 60 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
            End If

            If ContadorRenglones < 55 Then ' si solo quedan 2 espacios es mejor pasar a la otra pagina
                If CargaCustodias = False Then
                    'traer las custodias
                    cmdeequipo.Parameters("@accion").Value = 42
                    datasCustodias.Clear()
                    daequipo = New SqlClient.SqlDataAdapter(cmdeequipo)
                    datasCustodias = New DataSet()
                    daequipo.Fill(datasCustodias)
                    sqlconeccion.Close()
                    CargaCustodias = True
                End If

                If datasCustodias.Tables(0).Rows.Count > 0 And datasCustodias.Tables(0).Rows.Count > ContCustodias Then
                    ContadorRenglones = ContadorRenglones + 1

                    e.Graphics.DrawString("*  *  *  *  *  C  U  S  T  O  D  I  A  S  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 320, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1

                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ESTADO", Formato_Etiqueta_6, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 118, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 118, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ASIGNADO A", Formato_Etiqueta_6, Brocha, 120, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 348, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 348, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("SALIDA CUSTODIA", Formato_Etiqueta_6, Brocha, 350, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 508, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 508, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_6, Brocha, 510, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 578, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 578, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("DEVUELTO BODEGA", Formato_Etiqueta_6, Brocha, 580, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 738, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 738, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_6, Brocha, 740, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    ContadorRenglones = ContadorRenglones + 1

                    For j = ContCustodias To datasCustodias.Tables(0).Rows.Count - 1
                        Dim filacustodia As DataRow
                        filacustodia = datasCustodias.Tables(0).Rows(j)
                        e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        e.Graphics.DrawString(filacustodia("NOMBREESTADO"), Formato_Etiqueta_6R, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 118, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 118, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("ASIGNADO A"), Formato_Etiqueta_6R, Brocha, 120, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 348, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 348, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("SALIDA CUSTODIA"), Formato_Etiqueta_6R, Brocha, 350, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 508, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 508, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("FECHA CUSTODIA"), Formato_Etiqueta_6R, Brocha, 510, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 578, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 578, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("DEVUELTO BODEGA"), Formato_Etiqueta_6R, Brocha, 580, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 738, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 738, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("FECHA DEVOLUCION"), Formato_Etiqueta_6R, Brocha, 740, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        ContCustodias = ContCustodias + 1

                        If ContadorRenglones > 60 Then
                            pendienteimprimir = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next

                End If
            End If

            If ContadorRenglones < 55 Then ' si solo quedan 2 espacios es mejor pasar a la otra pagina
                If CargaTraslados = False Then
                    'traer traslados
                    cmdeequipo.Parameters("@accion").Value = 43
                    datastraslados.Clear()
                    daequipo = New SqlClient.SqlDataAdapter(cmdeequipo)
                    datastraslados = New DataSet()
                    daequipo.Fill(datastraslados)
                    sqlconeccion.Close()
                    CargaTraslados = True
                End If

                If datascaracteristicasequipo.Tables(0).Rows.Count > 0 And datastraslados.Tables(0).Rows.Count > ContTraslados Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawString("*  *  *  *  *  T  R  A  S  L  A  D  O  S  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 320, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1

                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ESTADO", Formato_Etiqueta_6, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 78, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 78, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ENTRADA ALMACEN", Formato_Etiqueta_6, Brocha, 80, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 238, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 238, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_6, Brocha, 240, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 308, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 308, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("BODEGA", Formato_Etiqueta_6, Brocha, 310, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 378, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 378, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("SALIDA ALMACEN", Formato_Etiqueta_6, Brocha, 380, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 538, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_6, Brocha, 540, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 608, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 608, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("BODEGA", Formato_Etiqueta_6, Brocha, 610, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 678, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 678, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("REMISION", Formato_Etiqueta_6, Brocha, 680, InicioDespuesEncabezado + ContadorRenglones * 15)

                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    ContadorRenglones = ContadorRenglones + 1

                    For j = ContTraslados To datastraslados.Tables(0).Rows.Count - 1
                        Dim filatraslados As DataRow
                        filatraslados = datastraslados.Tables(0).Rows(j)
                        e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        e.Graphics.DrawString(filatraslados("ESTADO"), Formato_Etiqueta_6R, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 78, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 78, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("ENTRADAALMACEN"), Formato_Etiqueta_6R, Brocha, 80, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 238, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 238, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("FECHAENTRADA"), Formato_Etiqueta_6R, Brocha, 240, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 308, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 308, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("BODEGAENTRADA"), Formato_Etiqueta_6R, Brocha, 310, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 378, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 378, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("SALIDAALMACEN"), Formato_Etiqueta_6R, Brocha, 380, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 538, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("FECHASALIDA"), Formato_Etiqueta_6R, Brocha, 540, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 608, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 608, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("BODEGADESTINO"), Formato_Etiqueta_6R, Brocha, 610, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 678, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 678, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filatraslados("REMISION"), Formato_Etiqueta_6R, Brocha, 680, InicioDespuesEncabezado + ContadorRenglones * 15)

                        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        ContTraslados = ContTraslados + 1

                        If ContadorRenglones > 60 Then
                            pendienteimprimir = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                End If
            End If

            If ContadorRenglones < 55 Then ' si solo quedan 5 espacios es mejor pasar a la otra pagina
                If CargaEstadosUso = False Then
                    'traer los estados de uso
                    cmdeequipo.Parameters("@accion").Value = 44
                    datasestadosuso.Clear()
                    daequipo = New SqlClient.SqlDataAdapter(cmdeequipo)
                    datasestadosuso = New DataSet()
                    daequipo.Fill(datasestadosuso)
                    sqlconeccion.Close()
                    CargaEstadosUso = True
                End If

                If datasestadosuso.Tables(0).Rows.Count > 0 And datasestadosuso.Tables(0).Rows.Count > ContEstadosUso Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawString("*  *  *  *  *  E  S  T  A  D  O  S    D  E    U  S  O  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 300, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_6, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 78, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 78, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ESTADO ANTERIOR", Formato_Etiqueta_6, Brocha, 80, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 218, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 218, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ESTADO NUEVO", Formato_Etiqueta_6, Brocha, 220, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 363, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 363, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("USUARIO", Formato_Etiqueta_6, Brocha, 365, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, 523, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 523, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("JUSTIFICACION", Formato_Etiqueta_6, Brocha, 525, InicioDespuesEncabezado + ContadorRenglones * 15)

                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    ContadorRenglones = ContadorRenglones + 1

                    For j = ContEstadosUso To datasestadosuso.Tables(0).Rows.Count - 1
                        Dim filacustodia As DataRow
                        filacustodia = datasestadosuso.Tables(0).Rows(j)
                        e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        e.Graphics.DrawString(filacustodia("FECHA"), Formato_Etiqueta_5, Brocha, 35, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 78, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 78, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("ESTADOANTERIOR"), Formato_Etiqueta_5, Brocha, 80, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 218, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 218, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("ESTADONUEVO"), Formato_Etiqueta_5, Brocha, 220, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 363, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 363, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("USUARIO"), Formato_Etiqueta_5, Brocha, 365, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, 523, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 523, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        If filacustodia("JUSTIFICACION").ToString.Length > 50 Then
                            e.Graphics.DrawString(Mid(filacustodia("JUSTIFICACION"), 1, 50), Formato_Etiqueta_5, Brocha, 525, InicioDespuesEncabezado + ContadorRenglones * 15)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, 78, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 78, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, 218, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 218, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, 363, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 363, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, 523, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 523, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawString(Mid(filacustodia("JUSTIFICACION"), 51, 50), Formato_Etiqueta_5, Brocha, 525, InicioDespuesEncabezado + ContadorRenglones * 15)
                        Else
                            e.Graphics.DrawString(filacustodia("JUSTIFICACION"), Formato_Etiqueta_5, Brocha, 525, InicioDespuesEncabezado + ContadorRenglones * 15)
                        End If

                        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        ContEstadosUso = ContEstadosUso + 1

                        If ContadorRenglones > 60 Then
                            pendienteimprimir = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                End If
            End If

            If ContadorRenglones < 55 Then ' si solo quedan 5 espacios es mejor pasar a la otra pagina
                If CargaMantenimientos = False Then
                    'traer los mantenimientos externos
                    cmdeequipo.Parameters("@accion").Value = 45
                    datasmantenimientos.Clear()
                    daequipo = New SqlClient.SqlDataAdapter(cmdeequipo)
                    datasmantenimientos = New DataSet()
                    daequipo.Fill(datasmantenimientos)
                    sqlconeccion.Close()
                    CargaMantenimientos = True
                End If

                Dim _NROREMISION As Integer = 35
                Dim _ANULADA As Integer = _NROREMISION + 25
                Dim _BODEGA As Integer = _ANULADA + 10
                Dim _SERVICIO As Integer = _BODEGA + 60
                Dim _CONTRATISTA As Integer = _SERVICIO + 70
                Dim _FECHAENVIO As Integer = _CONTRATISTA + 80
                Dim _ESTADOANTES As Integer = _FECHAENVIO + 45
                Dim _DESCRIPCION As Integer = _ESTADOANTES + 110
                Dim _CERRADA As Integer = _DESCRIPCION + 150
                Dim _FECHARECIBIDO As Integer = _CERRADA + 10
                Dim _ESTADOUSODESPUES As Integer = _FECHARECIBIDO + 45
                Dim _VALOR As Integer = _ESTADOUSODESPUES + 105

                If datasmantenimientos.Tables(0).Rows.Count > 0 And datasmantenimientos.Tables(0).Rows.Count > ContMantenimientos Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawString("*  *  *  *  *  M  A  N  T  E  N  I  M  I  E  N  T  O  S     E  X  T  E  R  N  O  S  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 240, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("NRO", Formato_Etiqueta_5, Brocha, _NROREMISION, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("A", Formato_Etiqueta_5, Brocha, _ANULADA, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("BODEGA", Formato_Etiqueta_5, Brocha, _BODEGA, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("SERVICIO", Formato_Etiqueta_5, Brocha, _SERVICIO, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("CONTRATISTA", Formato_Etiqueta_5, Brocha, _CONTRATISTA, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _FECHAENVIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHAENVIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_5, Brocha, _FECHAENVIO, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("ESTADO ANTES", Formato_Etiqueta_5, Brocha, _ESTADOANTES, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("DESCRIPCION", Formato_Etiqueta_5, Brocha, _DESCRIPCION, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _CERRADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CERRADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("C", Formato_Etiqueta_5, Brocha, _CERRADA, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("FECHA C", Formato_Etiqueta_5, Brocha, _FECHARECIBIDO, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("ESTADO DESPUES", Formato_Etiqueta_5, Brocha, _ESTADOUSODESPUES, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("VALOR", Formato_Etiqueta_5, Brocha, _VALOR, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    For j = ContMantenimientos To datasmantenimientos.Tables(0).Rows.Count - 1
                        Dim filacustodia As DataRow
                        filacustodia = datasmantenimientos.Tables(0).Rows(j)
                        Dim contratista As String = filacustodia("CONTRATISTA")
                        Dim descripcion As String = filacustodia("DESCRIPCION")
                        If contratista.Length / 20 > 60 - ContadorRenglones Then
                            Exit For
                        End If
                        If descripcion.Length / 30 > 60 - ContadorRenglones Then
                            Exit For
                        End If
                        e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("NROREMISION"), Formato_Etiqueta_5, Brocha, _NROREMISION, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("ANULADA"), Formato_Etiqueta_5, Brocha, _ANULADA, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("BODEGA"), Formato_Etiqueta_4, Brocha, _BODEGA, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("SERVICIO"), Formato_Etiqueta_5, Brocha, _SERVICIO, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("FECHAENVIO"), Formato_Etiqueta_5, Brocha, _FECHAENVIO, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("ESTADOANTES"), Formato_Etiqueta_4, Brocha, _ESTADOANTES, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("CERRADA"), Formato_Etiqueta_5, Brocha, _CERRADA, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        If Not IsDBNull(filacustodia("FECHARECIBIDO")) Then
                            e.Graphics.DrawString(filacustodia("FECHARECIBIDO"), Formato_Etiqueta_5, Brocha, _FECHARECIBIDO, InicioDespuesEncabezado + ContadorRenglones * 15)
                        End If
                        e.Graphics.DrawLine(Lapiz, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("ESTADOUSODESPUES"), Formato_Etiqueta_4, Brocha, _ESTADOUSODESPUES, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(FormatearValor(filacustodia("VALOR"), "$", Formato_Etiqueta_8, e, 80), Formato_Etiqueta_5, Brocha, _VALOR, InicioDespuesEncabezado + ContadorRenglones * 15)

                        If contratista.Length / 20 > descripcion.Length / 30 Then 'se requieren mas lineas para el contratista que para la descripción
                            For lineas = 0 To contratista.Length / 20
                                e.Graphics.DrawString(Mid(contratista, (lineas * 20) + 1, 20), Formato_Etiqueta_4, Brocha, _CONTRATISTA, InicioDespuesEncabezado + ContadorRenglones * 15)
                                e.Graphics.DrawLine(Lapiz, _FECHAENVIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHAENVIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawString(Mid(descripcion, (lineas * 30) + 1, 30), Formato_Etiqueta_5, Brocha, _DESCRIPCION, InicioDespuesEncabezado + ContadorRenglones * 15)
                                e.Graphics.DrawLine(Lapiz, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _CERRADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CERRADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                ContadorRenglones = ContadorRenglones + 1
                            Next
                        Else
                            For lineas = 0 To descripcion.Length / 30
                                e.Graphics.DrawString(Mid(contratista, (lineas * 20) + 1, 20), Formato_Etiqueta_4, Brocha, _CONTRATISTA, InicioDespuesEncabezado + ContadorRenglones * 15)
                                e.Graphics.DrawLine(Lapiz, _FECHAENVIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHAENVIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawString(Mid(descripcion, (lineas * 30) + 1, 30), Formato_Etiqueta_5, Brocha, _DESCRIPCION, InicioDespuesEncabezado + ContadorRenglones * 15)
                                e.Graphics.DrawLine(Lapiz, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ANULADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _BODEGA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SERVICIO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CONTRATISTA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOANTES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _DESCRIPCION - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHARECIBIDO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _CERRADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CERRADA - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _ESTADOUSODESPUES - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _VALOR - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                                ContadorRenglones = ContadorRenglones + 1
                            Next
                        End If
                        ContadorRenglones = ContadorRenglones - 1
                        e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        ContMantenimientos = ContMantenimientos + 1

                        If ContadorRenglones > 60 Then
                            pendienteimprimir = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                End If
            End If

            If ContadorRenglones < 55 Then ' si solo quedan 5 espacios es mejor pasar a la otra pagina
                If CargaMateriales = False Then
                    'traer los materiales asociados en salidas de almacén
                    cmdeequipo.Parameters("@accion").Value = 46
                    datasmateriales.Clear()
                    daequipo = New SqlClient.SqlDataAdapter(cmdeequipo)
                    datasmateriales = New DataSet()
                    daequipo.Fill(datasmateriales)
                    sqlconeccion.Close()
                    CargaMateriales = True
                End If

                Dim _IDARTICULO As Integer = 35
                Dim _NOMBRE As Integer = _IDARTICULO + 40
                Dim _CANTIDAD As Integer = _NOMBRE + 510
                Dim _UNIDAD As Integer = _CANTIDAD + 25
                Dim _SALIDAALMACEN As Integer = _UNIDAD + 25
                Dim _FECHAREGISTRO As Integer = _SALIDAALMACEN + 120

                If datasmateriales.Tables(0).Rows.Count > 0 And datasmateriales.Tables(0).Rows.Count > ContMateriales Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawString("*  *  *  *  *  M  A  T  E  R  I  A  L  E  S  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 320, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                    e.Graphics.DrawString("ID", Formato_Etiqueta_5, Brocha, _IDARTICULO, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("DESCRIPCION DEL ARTICULO", Formato_Etiqueta_5, Brocha, _NOMBRE, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _CANTIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CANTIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("CANT", Formato_Etiqueta_5, Brocha, _CANTIDAD, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _UNIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _UNIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("UND", Formato_Etiqueta_5, Brocha, _UNIDAD, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _SALIDAALMACEN - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SALIDAALMACEN - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("SALIDA ALMACEN", Formato_Etiqueta_5, Brocha, _SALIDAALMACEN + 30, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, _FECHAREGISTRO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHAREGISTRO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("FECHA", Formato_Etiqueta_5, Brocha, _FECHAREGISTRO, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContadorRenglones = ContadorRenglones + 1

                    For j = ContMateriales To datasmateriales.Tables(0).Rows.Count - 1
                        Dim filacustodia As DataRow
                        filacustodia = datasmateriales.Tables(0).Rows(j)
                        e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                        e.Graphics.DrawString(filacustodia("IDARTICULO"), Formato_Etiqueta_5, Brocha, _IDARTICULO, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _CANTIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CANTIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("CANTIDAD"), Formato_Etiqueta_5, Brocha, _CANTIDAD, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _UNIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _UNIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("UNIDAD"), Formato_Etiqueta_5, Brocha, _UNIDAD, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _SALIDAALMACEN - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SALIDAALMACEN - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("SALIDAALMACEN"), Formato_Etiqueta_5, Brocha, _SALIDAALMACEN, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawLine(Lapiz, _FECHAREGISTRO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHAREGISTRO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        e.Graphics.DrawString(filacustodia("FECHAREGISTRO"), Formato_Etiqueta_5, Brocha, _FECHAREGISTRO, InicioDespuesEncabezado + ContadorRenglones * 15)

                        If e.Graphics.MeasureString(filacustodia("NOMBRE").ToString, Formato_Etiqueta_5).Width > 500 Then
                            Dim NOMBRE_1 As String = Mid(filacustodia("NOMBRE"), 1, 100)
                            Dim NOMBRE_2 As String = Mid(filacustodia("NOMBRE"), 101, 100)
                            While e.Graphics.MeasureString(NOMBRE_1, Formato_Etiqueta_5).Width < 500 'Tamaño.Width
                                Dim Tamaño As Double = e.Graphics.MeasureString(NOMBRE_1, Formato_Etiqueta_5).Width
                                If NOMBRE_1.Length = filacustodia("NOMBRE").ToString.Length Then
                                    Exit While
                                End If
                                NOMBRE_1 = NOMBRE_1 + Mid(NOMBRE_2, 1, 1)
                                NOMBRE_2 = Mid(NOMBRE_2, 2, 100)
                            End While
                            NOMBRE_2 = LTrim(RTrim(NOMBRE_2))

                            e.Graphics.DrawString(NOMBRE_1, Formato_Etiqueta_5, Brocha, _NOMBRE, InicioDespuesEncabezado + ContadorRenglones * 15)
                            e.Graphics.DrawLine(Lapiz, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            ContadorRenglones = ContadorRenglones + 1
                            e.Graphics.DrawString(NOMBRE_2, Formato_Etiqueta_5, Brocha, _NOMBRE, InicioDespuesEncabezado + ContadorRenglones * 15)
                            e.Graphics.DrawLine(Lapiz, 30, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 30, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, 800, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)

                            e.Graphics.DrawLine(Lapiz, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, _CANTIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _CANTIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, _UNIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _UNIDAD - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, _SALIDAALMACEN - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _SALIDAALMACEN - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, _FECHAREGISTRO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _FECHAREGISTRO - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        Else
                            e.Graphics.DrawString(filacustodia("NOMBRE"), Formato_Etiqueta_5, Brocha, _NOMBRE, InicioDespuesEncabezado + ContadorRenglones * 15)
                            e.Graphics.DrawLine(Lapiz, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, _NOMBRE - 2, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                            e.Graphics.DrawLine(Lapiz, MargenDerecha - 20, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, 800, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                        End If

                        ContMateriales = ContMateriales + 1

                        If ContadorRenglones > 60 Then
                            pendienteimprimir = True
                            Exit For
                        End If

                        ContadorRenglones = ContadorRenglones + 1
                    Next
                End If
            End If

            If CargaPropiedades = False Or CargaCustodias = False Or CargaTraslados = False Or CargaEstadosUso = False Or CargaMantenimientos = False Or CargaMateriales = False Then
                pendienteimprimir = True
            End If

            If pendienteimprimir = False Then
                If CargaPropiedades = True And datascaracteristicasequipo.Tables(0).Rows.Count > ContPropiedades Then
                    pendienteimprimir = True
                End If
                If CargaCustodias = True And datasCustodias.Tables(0).Rows.Count > ContCustodias Then
                    pendienteimprimir = True
                End If
                If CargaTraslados = True And datastraslados.Tables(0).Rows.Count > ContTraslados Then
                    pendienteimprimir = True
                End If
                If CargaEstadosUso = True And datasestadosuso.Tables(0).Rows.Count > ContEstadosUso Then
                    pendienteimprimir = True
                End If
                If CargaMantenimientos = True And datasmantenimientos.Tables(0).Rows.Count > ContMantenimientos Then
                    pendienteimprimir = True
                End If
                If CargaMateriales = True And datasmateriales.Tables(0).Rows.Count > ContMateriales Then
                    pendienteimprimir = True
                End If
            End If

            If pendienteimprimir = True Then
                e.Graphics.DrawString("CONTINUA SIGUIENTE PAGINA", Formato_Etiqueta_6, Brocha, 650, 1080)
                ContadorRenglones = 0
                e.HasMorePages = True
                pendienteimprimir = False
            Else
                ContadorRenglones = 0
                ContPropiedades = 0
                ContCustodias = 0
                ContTraslados = 0
                ContEstadosUso = 0
                ContMantenimientos = 0
                ContMateriales = 0
                CodigoEquipoHojaVida = ""
                e.HasMorePages = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmdeequipo.Dispose()
        End Try
    End Sub


#End Region

#Region "72 - IMPRESIÓN DE PAZ Y SALVOS ACTIVOS FIJOS"

    Public nombrePersona As String
    Private WithEvents DocImp_ActaDePazySalvo As New PrintDocument
    Public dt_Custodias As New DataTable
    Public dt_CustodiasH As New DataTable
    Dim MargenPaginaTop As Integer
    Dim MargenPaginaBottom As Integer
    Dim MargenPaginaLeft As Integer
    Dim MargenPaginaRight As Integer
    Private inicioDeSeccion As Integer
    Dim inicioDeSeccion1 As Integer = 230
    Private finDeSeccion As Integer
    Private vectorAnchoColumnas As Array = {40, 120, 170, 40, 250, 250}
    Private vectorAnchoColumnasH As Array = {40, 770, 100}
    Private alturaFila As Integer = 30
    Private maximoNumeroDeFilas As Integer = 0
    'Private contadorLineasImpresas As Integer = 1
    Public ArrrayCedulas As New ArrayList
    Dim ContCustodiasE As Integer = 1
    Dim ContCustodiasH As Integer = 0
    Dim pendienteimprimir1 As Boolean = False
    Dim CargaCustodiasE As Boolean = False
    Dim CargaCustodiasH As Boolean = False
    Dim ContadorRenglones1 As Integer = 0


    Private Sub CargarCustodia(ByVal numeroDeCedula As String)
        dt_Custodias = New DataTable
        dt_CustodiasH = New DataTable
        Dim sqlConeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim cmdConsultaCustodias As New SqlClient.SqlCommand("GestionarEquipos")
        Dim AdaptadorCustodias As SqlClient.SqlDataAdapter
        sqlConeccion.Open()
        cmdConsultaCustodias.Parameters.Clear()
        cmdConsultaCustodias.CommandType = CommandType.StoredProcedure
        cmdConsultaCustodias.Connection = sqlConeccion
        cmdConsultaCustodias.CommandText = "dbo.GestionarEquipos"
        cmdConsultaCustodias.Parameters.AddWithValue("@accion", 47)
        cmdConsultaCustodias.Parameters.Add("@idproveedor", SqlDbType.Int).Value = -1
        cmdConsultaCustodias.Parameters.Add("@idarticulo", SqlDbType.Int).Value = -1
        cmdConsultaCustodias.Parameters.Add("@idequipo", SqlDbType.Int).Value = -1
        cmdConsultaCustodias.Parameters.Add("@idtipo", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idestado", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idmodelo", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idmarca", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@idbodega", SqlDbType.Int).Value = 1
        cmdConsultaCustodias.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = ""
        cmdConsultaCustodias.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = ""
        cmdConsultaCustodias.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = ""
        cmdConsultaCustodias.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = numeroDeCedula 'Se utiliza esta variable para pasar el parámetro de identificación de búsqueda.
        cmdConsultaCustodias.Parameters.Add("@activo", SqlDbType.Bit).Value = 0
        cmdConsultaCustodias.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = Date.Now
        'dt_Custodias = New DataTable
        Dim dsCustodias As New DataSet
        AdaptadorCustodias = New SqlClient.SqlDataAdapter(cmdConsultaCustodias)
        AdaptadorCustodias.Fill(dsCustodias)
        cmdConsultaCustodias.Connection.Close()

        If dsCustodias.Tables(0).Rows.Count > 0 Then
            dt_Custodias = dsCustodias.Tables(0)
        End If
        If dsCustodias.Tables(1).Rows.Count > 0 Then
            dt_CustodiasH = dsCustodias.Tables(1)
        End If
    End Sub

    Private Sub DocImpActaDePazySalvo(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ActaDePazySalvo.PrintPage
        Try
            Dim numeroDeCedula As Integer
            nombrePersona = dt_Custodias.Rows(0).Item(1)
            numeroDeCedula = dt_Custodias.Rows(0).Item(9)

            If dt_Custodias.Rows.Count > 0 And dt_CustodiasH.Rows.Count < 1 Then
                paginastotal = Math.Ceiling(((dt_Custodias.Rows.Count - 1) + (dt_CustodiasH.Rows.Count + 2)) / 15)
            ElseIf dt_Custodias.Rows.Count = 0 And dt_CustodiasH.Rows.Count = 15 Then
                paginastotal = Math.Ceiling((dt_CustodiasH.Rows.Count) / 15)
            Else
                paginastotal = Math.Ceiling(((dt_Custodias.Rows.Count - 1) + (dt_CustodiasH.Rows.Count + 3)) / 15)
            End If

            Brocha.Color = Color.Black
            MargenPaginaTop = DocImp_ActaDePazySalvo.DefaultPageSettings.Bounds.Top + 20
            MargenPaginaBottom = DocImp_ActaDePazySalvo.DefaultPageSettings.Bounds.Bottom - 50 '800
            MargenPaginaLeft = DocImp_ActaDePazySalvo.DefaultPageSettings.Bounds.Left + 20
            MargenPaginaRight = DocImp_ActaDePazySalvo.DefaultPageSettings.Bounds.Right - 60 '1040

            'Borde externo.
            DrawRoundedRectangle(e.Graphics, MargenPaginaLeft, MargenPaginaTop + 120, MargenPaginaRight - MargenPaginaLeft, MargenPaginaBottom - (MargenPaginaTop + 120), 15)

            'Título.
            inicioDeSeccion = MargenPaginaTop + 20
            finDeSeccion = inicioDeSeccion + 100

            If VariablesBase.VariablesBase.EmpresaBodegaActual = 2 Then
                LogoEmpresa = 2
            End If

            Select Case LogoEmpresa
                Case 0 'Ismocol
                    e.Graphics.DrawImage(imagen, MargenPaginaLeft + 30, MargenPaginaTop, 130, 104)
                Case 1 'CSI
                    e.Graphics.DrawImage(imagenCSI, MargenPaginaLeft + 30, MargenPaginaTop, 130, 104)
                Case 2 'Zamorna
                    e.Graphics.DrawImage(zamorana, MargenPaginaLeft + 20, MargenPaginaTop + 20, 213, 57)
            End Select

            e.Graphics.DrawString("RESUMEN EQUIPOS Y HERRAMIENTAS EN CUSTODIA ISMOCOL S.A.", Formato_Etiqueta_16, Brocha, InicioCentradoTexto("RESUMEN EQUIPOS Y HERRAMIENTAS EN CUSTODIA ISMOCOL S.A.", Formato_Etiqueta_16, 1200, e), inicioDeSeccion - 2)
            e.Graphics.DrawString("SISTEMA SIGMA", Formato_Etiqueta_16, Brocha, InicioCentradoTexto("SISTEMA SIGMA", Formato_Etiqueta_16, 1100, e), inicioDeSeccion + 38)

            'Sección datos del solicitante.
            inicioDeSeccion = finDeSeccion
            finDeSeccion = inicioDeSeccion + 90
            e.Graphics.DrawString("NOMBRE: " + nombrePersona, Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 20, inicioDeSeccion + 20)
            e.Graphics.DrawString("CÉDULA: " + ClConvertir.Fun_FormatearCedula(numeroDeCedula), Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 20, inicioDeSeccion + 40)
            e.Graphics.DrawString("FECHA DE EXPEDICIÓN: " + Format(Date.Today, "dddd, d \d\e MMMM \d\e yyyy") + " H:" + DateTime.Now.ToString("hh:mm"), Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 20, inicioDeSeccion + 60)
            e.Graphics.DrawString("CANTIDAD DE EQUIPOS: " + (dt_Custodias.Rows.Count - 1).ToString, Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 400, inicioDeSeccion + 60)
            e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, finDeSeccion, MargenPaginaRight, finDeSeccion)

            'Sección Cuadrícula/Rejilla.
            'inicioDeSeccion1 = 230
            'finDeSeccion = inicioDeSeccion + (alturaFila * (15 + 1))
            'finDeSeccion = inicioDeSeccion1 + alturaFila

            If dt_Custodias.Rows.Count > 1 Or dt_CustodiasH.Rows.Count > 0 Then
                If CargaCustodiasE = False Then
                    CargaCustodiasE = True
                End If
                If ContadorRenglones1 < 15 Then
                    If dt_Custodias.Rows.Count > 1 And dt_Custodias.Rows.Count > ContCustodiasE Then
                        ContadorRenglones1 = ContadorRenglones1 + 1
                        Dim posicionColumnaEnX As Integer = MargenPaginaLeft
                        'Encabezados.
                        'For col As Integer = 0 To vectorAnchoColumnas.Length - 1
                        '    posicionColumnaEnX += vectorAnchoColumnas(col)
                        '    e.Graphics.DrawLine(Lapiz, posicionColumnaEnX, inicioDeSeccion, posicionColumnaEnX, finDeSeccion)
                        'Next

                        'e.Graphics.DrawLine(Lapiz, posicionColumnaEnX, inicioDeSeccion, posicionColumnaEnX, posicionColumnaEnX, inicioDeSeccion + 5)
                        posicionColumnaEnX = MargenPaginaLeft + 5
                        e.Graphics.DrawString(dt_Custodias.Columns(0).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        posicionColumnaEnX += vectorAnchoColumnas(0)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        e.Graphics.DrawString(dt_Custodias.Columns(1).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        posicionColumnaEnX += vectorAnchoColumnas(1)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        e.Graphics.DrawString(dt_Custodias.Columns(2).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        posicionColumnaEnX += vectorAnchoColumnas(2)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        e.Graphics.DrawString(dt_Custodias.Columns(3).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        posicionColumnaEnX += vectorAnchoColumnas(3)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        e.Graphics.DrawString(dt_Custodias.Columns(4).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        e.Graphics.DrawString(dt_Custodias.Columns(5).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 15)
                        posicionColumnaEnX += vectorAnchoColumnas(4)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        e.Graphics.DrawString(dt_Custodias.Columns(6).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        posicionColumnaEnX += vectorAnchoColumnas(5)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        e.Graphics.DrawString(dt_Custodias.Columns(7).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                        e.Graphics.DrawString(dt_Custodias.Columns(8).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 15)
                        e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion1 + ContadorRenglones1 * alturaFila, MargenPaginaRight, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                        ContadorRenglones1 = ContadorRenglones1 + 1

                        posicionColumnaEnX = MargenPaginaLeft + 5
                        'Dim posicionFilaEnY As Integer = 1
                        For j = ContCustodiasE To dt_Custodias.Rows.Count - 1

                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(0), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)

                            posicionColumnaEnX += vectorAnchoColumnas(0)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(1), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                            posicionColumnaEnX += vectorAnchoColumnas(1)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(2), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                            posicionColumnaEnX += vectorAnchoColumnas(2)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(3), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                            posicionColumnaEnX += vectorAnchoColumnas(3)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(4), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(5), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 15)
                            posicionColumnaEnX += vectorAnchoColumnas(4)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(6), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                            posicionColumnaEnX += vectorAnchoColumnas(5)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 30, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(7), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 25)
                            e.Graphics.DrawString(dt_Custodias.Rows(j).Item(8), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 15)

                            e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion1 + ContadorRenglones1 * alturaFila, MargenPaginaRight, inicioDeSeccion1 + ContadorRenglones1 * alturaFila)

                            posicionColumnaEnX = MargenPaginaLeft + 5
                            'posicionFilaEnY += 1
                            'If contadorLineasImpresas Mod maximoNumeroDeFilas = 0 Then
                            '    contadorLineasImpresas += 1
                            '    Exit For
                            'End If
                            ContCustodiasE = ContCustodiasE + 1
                            If ContadorRenglones1 > 15 Then
                                pendienteimprimir1 = True
                                Exit For
                            End If
                            ContadorRenglones1 = ContadorRenglones1 + 1
                        Next
                    End If
                End If
                ContadorRenglones1 = ContadorRenglones1 + 1
                If CargaCustodiasH = False Then
                    CargaCustodiasH = True
                End If

                'inicioDeSeccion = inicioDeSeccion + 15 + alturaFila * posicionFilaEnY
                ''finDeSeccion = inicioDeSeccion + (alturaFila * (15 + 1))
                'finDeSeccion = inicioDeSeccion + alturaFila
                If ContadorRenglones1 < 16 Then
                    If dt_CustodiasH.Rows.Count > 0 And dt_CustodiasH.Rows.Count > ContCustodiasH Then
                        ContadorRenglones1 = ContadorRenglones1 + 1
                        e.Graphics.DrawString("CANTIDAD DE HERRAMIENTAS: " + (dt_CustodiasH.Compute("Sum(CANTIDAD)", "").ToString), Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 380, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 75)
                        e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60, MargenPaginaRight, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                        ContadorRenglones1 = ContadorRenglones1 + 1
                        'inicioDeSeccion = inicioDeSeccion + 30 + alturaFila * posicionFilaEnY
                        Dim posicionColumnaEnX As Integer = MargenPaginaLeft
                        'Encabezados.
                        'For col As Integer = 0 To vectorAnchoColumnasH.Length - 1
                        '    posicionColumnaEnX += vectorAnchoColumnasH(col)
                        '    e.Graphics.DrawLine(Lapiz, posicionColumnaEnX, inicioDeSeccion, posicionColumnaEnX, finDeSeccion)
                        'Next

                        'e.Graphics.DrawLine(Lapiz, posicionColumnaEnX, inicioDeSeccion, posicionColumnaEnX, posicionColumnaEnX, inicioDeSeccion + 5)
                        posicionColumnaEnX = MargenPaginaLeft + 5
                        e.Graphics.DrawString(dt_CustodiasH.Columns(0).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                        posicionColumnaEnX += vectorAnchoColumnasH(0)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90)
                        e.Graphics.DrawString(dt_CustodiasH.Columns(1).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                        posicionColumnaEnX += vectorAnchoColumnasH(1)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90)
                        e.Graphics.DrawString(dt_CustodiasH.Columns(2).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                        posicionColumnaEnX += vectorAnchoColumnasH(2)
                        e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90)
                        e.Graphics.DrawString(dt_CustodiasH.Columns(3).ColumnName, Formato_Etiqueta_6, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                        e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60, MargenPaginaRight, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                        ContadorRenglones1 = ContadorRenglones1 + 1
                        'Renglones de datos.
                        'For row As Integer = 1 To maximoNumeroDeFilas
                        '    e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion + alturaFila, MargenPaginaRight, inicioDeSeccion + alturaFila)
                        'Next
                        posicionColumnaEnX = MargenPaginaLeft + 5
                        'Dim posicionFilaEnY As Integer = 1
                        For j = ContCustodiasH To dt_CustodiasH.Rows.Count - 1

                            'e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, ContadorRenglones1 * alturaFila - 50, MargenPaginaRight, ContadorRenglones1 * alturaFila - 50)
                            e.Graphics.DrawString(dt_CustodiasH.Rows(j).Item(0), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)

                            posicionColumnaEnX += vectorAnchoColumnasH(0)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                            Dim descripcion As String = dt_CustodiasH.Rows(j).Item(1).ToString.Trim
                            Select Case descripcion.Length
                                Case Is < 135
                                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                                    Exit Select
                                Case Is <= 145
                                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                                    Exit Select
                                Case Else
                                    e.Graphics.DrawString(Mid(descripcion, 1, 145), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                                    e.Graphics.DrawString(Mid(descripcion, 146, 145), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 75)
                            End Select
                            'e.Graphics.DrawString(dt_CustodiasH.Rows(j).Item(2), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                            posicionColumnaEnX += vectorAnchoColumnasH(1)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                            e.Graphics.DrawString(dt_CustodiasH.Rows(j).Item(2), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                            posicionColumnaEnX += vectorAnchoColumnasH(2)
                            e.Graphics.DrawLine(Lapiz, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 90, posicionColumnaEnX - 5, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                            e.Graphics.DrawString(dt_CustodiasH.Rows(j).Item(3), Formato_Etiqueta_6R, Brocha, posicionColumnaEnX, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 85)
                            e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60, MargenPaginaRight, inicioDeSeccion1 + ContadorRenglones1 * alturaFila - 60)
                            ContCustodiasH = ContCustodiasH + 1
                            posicionColumnaEnX = MargenPaginaLeft + 5
                            'If contadorLineasImpresas Mod maximoNumeroDeFilas = 0 Then
                            '    contadorLineasImpresas += 1
                            '    Exit For
                            'End If
                            If ContadorRenglones1 > 16 Then
                                pendienteimprimir1 = True

                                Exit For
                            End If
                            ContadorRenglones1 = ContadorRenglones1 + 1
                        Next
                    End If
                End If
            Else
                inicioDeSeccion = 610
                e.Graphics.DrawString("PAZ Y SALVO", Formato_Etiqueta_60, Brushes.Silver, InicioCentradoTexto("PAZ Y SALVO", Formato_Etiqueta_60, 1100, e), ((inicioDeSeccion + finDeSeccion) / 2) - 200)
                e.Graphics.DrawString("EN CUSTODIAS", Formato_Etiqueta_60, Brushes.Silver, InicioCentradoTexto("EN CUSTODIAS", Formato_Etiqueta_60, 1100, e), ((inicioDeSeccion + finDeSeccion) / 2) - 100)
                e.Graphics.DrawString("DE EQUIPOS Y", Formato_Etiqueta_60, Brushes.Silver, InicioCentradoTexto("DE EQUIPOS Y", Formato_Etiqueta_60, 1100, e), ((inicioDeSeccion + finDeSeccion) / 2) + 0)
                e.Graphics.DrawString("HERRAMIENTAS DE", Formato_Etiqueta_60, Brushes.Silver, InicioCentradoTexto("HERRAMIENTAS DE", Formato_Etiqueta_60, 1100, e), ((inicioDeSeccion + finDeSeccion) / 2) + 100)
                e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_60, Brushes.Silver, InicioCentradoTexto("ISMOCOL S.A.", Formato_Etiqueta_60, 1100, e), ((inicioDeSeccion + finDeSeccion) / 2) + 200)
                paginastotal = 1
            End If

            'Sección datos del certificador.
            'finDeSeccion = inicioDeSeccion + (alturaFila * (15 + 1))
            'finDeSeccion = inicioDeSeccion + alturaFila
            inicioDeSeccion = 710
            e.Graphics.DrawLine(Lapiz, MargenPaginaLeft, inicioDeSeccion, MargenPaginaRight, inicioDeSeccion)
            e.Graphics.DrawString("BODEGA QUE CERTIFICA: " + VariablesBase.VariablesBase.NombreBodegaActual, Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 20, inicioDeSeccion + 20)
            e.Graphics.DrawString("USUARIO QUE CERTIFICA: " + VariablesBase.VariablesBase.Nombre_Usuario, Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 20, inicioDeSeccion + 40)

            'Sección firma del certificador.
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 400, inicioDeSeccion + 30)
            If dt_Custodias.Rows.Count > 1 Or dt_CustodiasH.Rows.Count > 0 Then
                e.Graphics.DrawLine(Lapiz, MargenPaginaLeft + 450, inicioDeSeccion + 40, MargenPaginaLeft + 680, inicioDeSeccion + 40)
            Else
                If VariablesBase.VariablesBase.IdPersona = 26434 Then
                    Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(4, 128)
                    If Not IsNothing(foto) Then
                        e.Graphics.DrawImage(foto, MargenPaginaLeft + 450, inicioDeSeccion + 1, 250, 100)
                    End If
                ElseIf VariablesBase.VariablesBase.IdPersona = 10954 Then
                    Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(4, 129)
                    If Not IsNothing(foto) Then
                        e.Graphics.DrawImage(foto, MargenPaginaLeft + 450, inicioDeSeccion + 1, 150, 80)
                    End If
                ElseIf VariablesBase.VariablesBase.IdPersona = 31059 Then
                    Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(4, 130)
                    If Not IsNothing(foto) Then
                        e.Graphics.DrawImage(foto, MargenPaginaLeft + 450, inicioDeSeccion + 1, 150, 80)
                    End If
                ElseIf VariablesBase.VariablesBase.IdPersona = 2346 Then
                    Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(4, 131)
                    If Not IsNothing(foto) Then
                        e.Graphics.DrawImage(foto, MargenPaginaLeft + 450, inicioDeSeccion + 1, 150, 80)
                    End If
                ElseIf VariablesBase.VariablesBase.IdPersona = 47024 Then
                    Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(4, 132)
                    If Not IsNothing(foto) Then
                        e.Graphics.DrawImage(foto, MargenPaginaLeft + 450, inicioDeSeccion + 1, 150, 80)
                    End If
                ElseIf VariablesBase.VariablesBase.IdPersona = 46890 Then
                    Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(4, 133)
                    If Not IsNothing(foto) Then
                        e.Graphics.DrawImage(foto, MargenPaginaLeft + 450, inicioDeSeccion + 1, 150, 80)
                    End If
                End If
            End If
            e.Graphics.DrawString("IDENTIFICACIÓN:   " + ClConvertir.Fun_FormatearCedula(VariablesBase.VariablesBase.IdentificaciónUSuario), Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 400, inicioDeSeccion + 60)
            e.Graphics.DrawLine(Lapiz, MargenPaginaLeft + 505, inicioDeSeccion + 74, MargenPaginaLeft + 680, inicioDeSeccion + 74)

            e.Graphics.DrawString("FECHA FIRMA:   " + Date.Today, Formato_Etiqueta_8, Brocha, MargenPaginaLeft + 740, inicioDeSeccion + 60)
            e.Graphics.DrawLine(Lapiz, MargenPaginaLeft + 830, inicioDeSeccion + 74, MargenPaginaLeft + 1000, inicioDeSeccion + 74)

            'Sección Paginado
            contadorPaginasImpresas += 1
            e.Graphics.DrawString("Página " & contadorPaginasImpresas & " de " & paginastotal, Formato_Etiqueta_5, Brocha, MargenPaginaRight - 60, inicioDeSeccion + 100)

            If CargaCustodiasE = False Or CargaCustodiasH = False Then
                pendienteimprimir1 = True
            End If
            pendienteimprimir1 = False
            If pendienteimprimir1 = False Then
                If CargaCustodiasE = True And dt_Custodias.Rows.Count > ContCustodiasE Then
                    pendienteimprimir1 = True
                End If
                If CargaCustodiasH = True And dt_CustodiasH.Rows.Count > ContCustodiasH Then
                    pendienteimprimir1 = True
                End If
            End If

            ContadorRenglones1 = 0

            If pendienteimprimir1 = True Then
                ContadorRenglones1 = 0
                e.HasMorePages = True
                pendienteimprimir = False

            Else
                'ContCustodiasE = 1
                'ContCustodiasH = 0
                e.HasMorePages = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub DocImp_ActaDePazySalvo_EndPrint(sender As Object, e As PrintEventArgs) Handles DocImp_ActaDePazySalvo.EndPrint
        If e.PrintAction = PrintAction.PrintToPreview Then
            ContCustodiasE = 1
            ContCustodiasH = 0
            paginastotal = contadorPaginasImpresas
            contadorPaginasImpresas = 0
        End If
    End Sub

#End Region

#Region "79 - STICKER PARA EQUIPOS CONTINUA (5,1 × 3,2 cm)"
    Private fuenteTitulo As New Font("Tahoma", 7, FontStyle.Bold)
    Public Id As String
    Public Codigo As String
    Public IdEquipo As Integer
    Public Serie As String
    Public Cant As Integer

    Dim VectorStickerSerie As New ArrayList
    Dim VectorStickerCodigo As New ArrayList
    Dim VectorStickerCodBarras As New ArrayList

    Private WithEvents Pd_StickerEquiposIndividual As New PrintDocument
    Private Sub Pd_StickerEquiposIndividual_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles Pd_StickerEquiposIndividual.PrintPage

        'ActivarRejilla(e, Color.LightGray, 3, 0.5, 10)
        '    Const textoCodigo1 As String = "CÓDIGO EQUIPO"
        '    Const textoCodigo2 As String = "ISMOCOL S.A."

        '    If Not fuenteStickerCargada Then
        '        Try
        '            pfcSticker.AddFontFile(VariablesBase.VariablesBase._path & "\" & nombreFuenteCodigoBarras)
        '            fontFamilySticker = pfcSticker.Families(0)
        '            fuenteSticker = New Font(fontFamilySticker, 32)
        '            fuenteStickerCargada = True
        '        Catch ex As Exception
        '            Throw New Exception("La fuente " & nombreFuenteCodigoBarras & "no se encuentra instalada.", ex)
        '        End Try
        '    End If

        '    Dim CodigoBarras As Image = FuncionesBase.FuncionesBase.GenerarCodigoBarras(IdEquipo, 360)
        '    e.Graphics.DrawImage(CodigoBarras, 5, 50, 190, 35)
        '    'e.Graphics.ScaleImage(CodigoBarras, 190, 35)

        '    e.Graphics.DrawRectangle(lineaPunteada, 0, 0, tamannoStickerContinua.Width, tamannoStickerContinua.Height)
        '    e.Graphics.DrawImage(logoIsmocol, 10, 6, tamannoLogoSticker.Width, tamannoLogoSticker.Height)
        '    e.Graphics.DrawStringCentered(textoCodigo1, fuenteTitulo, Brocha, tamannoStickerContinua.Width - tamannoLogoSticker.Width - 22, tamannoLogoSticker.Width + 10, 8)
        '    e.Graphics.DrawStringCentered(textoCodigo2, fuenteTitulo, Brocha, tamannoStickerContinua.Width - tamannoLogoSticker.Width - 22, tamannoLogoSticker.Width + 10, 20)
        '    e.Graphics.DrawString("Cod. Artículo: ", fuenteTitulo, Brocha, tamannoLogoSticker.Width + 35, 35)
        '    e.Graphics.DrawString(Id, Formato_Etiqueta_7, Brocha, tamannoLogoSticker.Width + 95, 35)
        '    e.Graphics.DrawStringCentered(Serie, Formato_Etiqueta_7, Brocha, tamannoStickerContinua.Width, 0, tamannoStickerContinua.Height - 37)
        '    e.Graphics.DrawStringCentered(Codigo, Formato_Etiqueta_9, Brocha, tamannoStickerContinua.Width, 0, tamannoStickerContinua.Height - 27)

        '    If indiceSticker + 1 = Cant Then
        '        e.HasMorePages = False
        '    Else
        '        indiceSticker += 1
        '        e.HasMorePages = True
        '    End If
        'End Sub

        'Private Sub Pd_StickerEquiposIndividual_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles Pd_StickerEquiposIndividual.EndPrint
        '    If e.PrintAction = PrintAction.PrintToPreview Then
        '        indiceSticker = 0
        '    End If
        Const textoCodigo2 As String = "ISMOCOL S.A."
         
        Try
            If IO.File.Exists("C:\WINDOWS\fonts\FREE3OF9.TF") = False Then
                IO.File.Copy(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF", "C:\WINDOWS\fonts\FREE3OF9.TTF")
            End If
        Catch ex As Exception
        End Try

        pfc.AddFontFile(VariablesBase.VariablesBase._path & "\FREE3OF9.TTF")
        fontFamily = pfc.Families(0)
        fuente1 = New Font(fontFamily, 25)

        Dim CodigoBarras As Image = FuncionesBase.FuncionesBase.GenerarCodigoBarras(Serie, 360)

        If CalcularCantidad = True Then
            CantidadTotalSticker = Cant
            paginastotal = -Int((-CantidadTotalSticker + InicioImpresión) / 30)
            CalcularCantidad = False
            'Dim Fila As DataRow
            'Fila = Tb_Sticker.Rows(i)
            For j = 1 To Cant
                VectorStickerId.Add(Id)
                VectorStickerSerie.Add(Serie)
                VectorStickerCodigo.Add(Codigo)
                'VectorStickerCodBarras.Add(CodigoBarras)
            Next

        End If
        Dim imprimir As Boolean = False
        For FilaImpresión = 1 To 10
            For ColumnaImpresión = 1 To 3
                If contpaginas = 1 Then
                    'Ubicar la primera impresión de sticker
                    If InicioImpresión > ContaStickerImpreso Then
                        imprimir = False
                        ContaStickerImpreso = ContaStickerImpreso + 1
                    Else
                        imprimir = True
                    End If
                Else
                    imprimir = True
                End If

                If imprimir = True Then
                    Dim sepvertical As Integer = 100
                    'Imprime
                    e.Graphics.DrawStringCentered(textoCodigo2, fuenteTitulo, Brocha, 300, ((ColumnaImpresión - 1) * 270), 42 + ((FilaImpresión - 1) * sepvertical))

                    e.Graphics.DrawStringCentered("CÓDIGO: " + VectorStickerCodigo(ContaStickerVector).ToString, Formato_Etiqueta_8, Brocha, 300, ((ColumnaImpresión - 1) * 270), 57 + ((FilaImpresión - 1) * sepvertical))

                    e.Graphics.DrawString("Id Artículo:  ", Formato_Etiqueta_7, Brocha, 30 + ((ColumnaImpresión - 1) * 270), 72 + ((FilaImpresión - 1) * sepvertical))
                    e.Graphics.DrawString(VectorStickerId(ContaStickerVector).ToString, Formato_Etiqueta_8, Brocha, 90 + ((ColumnaImpresión - 1) * 270), 72 + ((FilaImpresión - 1) * sepvertical))

                    'codigo de barras
                    If Serie.Length < 16 Then
                        e.Graphics.DrawStringCentered(FormatoCodigoBarras(VectorStickerSerie(ContaStickerVector).ToString), fuente1, Brushes.Black, 300, ((ColumnaImpresión - 1) * 270), 87 + ((FilaImpresión - 1) * sepvertical))
                    Else
                        e.Graphics.DrawImage(CodigoBarras, 10 + ((ColumnaImpresión - 1) * 270), 87 + ((FilaImpresión - 1) * sepvertical), 210, 30)
                    End If

                    Dim Descripción As String = VectorStickerSerie(ContaStickerVector)
                    Dim Cadenas1 As New ArrayList
                    Cadenas1.Add(Trim(Descripción))
                    Dim Cadena_Total1 As New ArrayList
                    Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_5, 240, e)
                    Dim Separa As Integer = 10
                    For t = 0 To Cadena_Total1.Count - 1
                        e.Graphics.DrawStringCentered(Cadena_Total1(t), Formato_Etiqueta_7, Brocha, 300, ((ColumnaImpresión - 1) * 270), 116 + (t * Separa) + ((FilaImpresión - 1) * sepvertical))
                    Next

                    ContaStickerVector = ContaStickerVector + 1
                    ContaStickerImpreso = ContaStickerImpreso + 1
                End If
                If ContaStickerVector >= CantidadTotalSticker Then
                    Exit For
                End If
            Next
            If ContaStickerVector >= CantidadTotalSticker Then
                Exit For
            End If
        Next

        If ContaStickerVector >= CantidadTotalSticker Then
            contpaginas = 1
            ContaStickerImpreso = 1
            ContaStickerVector = 0
            e.HasMorePages = False
        Else
            contpaginas = contpaginas + 1
            e.HasMorePages = True
        End If

    End Sub
#End Region

#End Region


#Region "Rutina de impresión"
    Dim WithEvents VistaPrevia As New PrintPreviewDialog
    Dim vistapreviack As New Boolean 'Para verificar en la impresion de mediacarta si esta activa la vista previa
    Public Sub FormatoImprimirMateriales(ByVal Formatos As ArrayList, ByVal VerVistaPrevia As Boolean, Optional ByVal Doblecara As Boolean = False)
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
                Case 60 'ICS-GRAL-F-01 REQUISICION
                    DocImp_RequisiciónICSGRALF01.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RequisiciónICSGRALF01.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RequisiciónICSGRALF01
                Case 61 'ICS-GRAL-F-30 CANCELACION REQUISICION
                    DocImp_CancelaciónRequisiciónICSGRALF30.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CancelaciónRequisiciónICSGRALF30.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CancelaciónRequisiciónICSGRALF30
                Case 62 'ICS-GRAL-F-06 ORDEN DE COMPRA
                    DocImp_OrdenDeCompraICSGRALF06.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_OrdenDeCompraICSGRALF06.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_OrdenDeCompraICSGRALF06
                Case 63 'ICS-GRAL-F-07 CANCELACION ORDEN DE COMPRA
                    DocImp_CancelaciónOrdenDeCompraICSGRALF07.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CancelaciónOrdenDeCompraICSGRALF07.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CancelaciónOrdenDeCompraICSGRALF07
                Case 64 'ICS-GRAL-F-20 ENTRADA DE ALMACEN
                    DocImp_EntradaDeAlmacenICSGRALF20.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_EntradaDeAlmacenICSGRALF20.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_EntradaDeAlmacenICSGRALF20
                Case 65 'ICS-GRAL-F-34 INGRESO POR DEVOLUCION
                    'DocImp_IngresoPorDevoluciónICSGRALF34.PrinterSettings = PrintDialog1.PrinterSettings
                    'DocImp_IngresoPorDevoluciónICSGRALF34.PrinterSettings.DefaultPageSettings.Landscape = False
                    'VistaPrevia.Document = DocImp_IngresoPorDevoluciónICSGRALF34
                Case 66 'ICS-GRAL-F-24 SALIDA DE MATERIALES
                    DocImp_SalidaDeMateriales.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_SalidaDeMateriales.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_SalidaDeMateriales
                Case 67 'ICS-GRAL-F-022 REMISION DE MATERIALES
                    DocImp_RemisiónDeMaterialesICSGRALF022.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RemisiónDeMaterialesICSGRALF022.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RemisiónDeMaterialesICSGRALF022
                Case 68 'STICKER ARTICULOS REF: 67*25 C3 x 30 Rótulos
                    DocImp_STICKERARTICULOSREF_67_25_C3x30.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_STICKERARTICULOSREF_67_25_C3x30.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_STICKERARTICULOSREF_67_25_C3x30
                Case 69 'RELACION FACTURAS ORDEN DE COMPRA
                    DocImp_RELACION_FACTURA_OC.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RELACION_FACTURA_OC.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_RELACION_FACTURA_OC
                Case 70 'REMISION DE MATERIALES REVISIONES EXTERNAS
                    DocImp_RemisiónRevisionesExternas.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RemisiónRevisionesExternas.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RemisiónRevisionesExternas
                Case 71 'HOJA DE VIDA EQUIPOS - ACTIVOS FIJOS
                    DocImp_HojaVidaEquipos.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_HojaVidaEquipos.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_HojaVidaEquipos
                Case 72 'ACTA DE PAZ Y SALVO

                    Dim salir As Boolean = False
                    For ced = 0 To ArrrayCedulas.Count - 1
                        ContCustodiasE = 1
                        ContCustodiasH = 0
                        CargarCustodia(ArrrayCedulas(ced))
                        VistaPrevia.PrintPreviewControl.Zoom = 1
                        DocImp_ActaDePazySalvo.PrinterSettings = PrintDialog1.PrinterSettings
                        DocImp_ActaDePazySalvo.PrinterSettings.DefaultPageSettings.Landscape = True
                        VistaPrevia.Document = DocImp_ActaDePazySalvo
                        If ArrrayCedulas.Count > 1 Then
                            salir = True
                            If VerVistaPrevia = True Then
                                VistaPrevia.ShowDialog()
                            Else
                                VistaPrevia.Document.Print()
                            End If
                        End If
                        contadorPaginasImpresas = 0
                    Next
                    If salir = True Then
                        Exit Sub
                    End If
                Case 73 'ICS-GRAL-F-102 REMISION DE MATERIALES VALORIZADA
                    DocImp_RemisiónDeMaterialesValorizada.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RemisiónDeMaterialesValorizada.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RemisiónDeMaterialesValorizada
                Case 74 'ICS-GRAL-F-101 REQUISICIÓN DE MAQUINARIA Y EQUIPOS
                    DocImp_SolicitudMaquinariaICSGRALF101.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_SolicitudMaquinariaICSGRALF101.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_SolicitudMaquinariaICSGRALF101
                Case 75 'COMPLEMENTO REQUISICIÓN MATERIALES
                    DocImp_ComplementoRequisicion.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ComplementoRequisicion.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_ComplementoRequisicion
                Case 76 'STICKER ARTICULOS REF: 67*25 C3 x 30 Código de Barras
                    DocImp_STICKERARTICULOSREF_67_25_C3x30_CODIGOBARRAS.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_STICKERARTICULOSREF_67_25_C3x30_CODIGOBARRAS.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_STICKERARTICULOSREF_67_25_C3x30_CODIGOBARRAS
                Case 77 'STICKER ARTICULOS REF: 67*25 C3 x 30 Rótulos Cód Barras FREE3OF9
                    DocImp_STICKERARTICULOSREF_67_25_C3x30_ROTULOCODIGOBARRAS.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_STICKERARTICULOSREF_67_25_C3x30_ROTULOCODIGOBARRAS.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_STICKERARTICULOSREF_67_25_C3x30_ROTULOCODIGOBARRAS
                Case 78 'IMPRESION DE REMISION DE MATERIALES COMBINADA CON VALORIZADA MEDIA CARTA
                    DocImp_RemisiónDeMaterialesCombinada.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RemisiónDeMaterialesCombinada.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RemisiónDeMaterialesCombinada
                Case 79 'STICKER EQUIPOS CONTINUA
                    Pd_StickerEquiposIndividual.PrinterSettings = PrintDialog1.PrinterSettings
                    Pd_StickerEquiposIndividual.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = Pd_StickerEquiposIndividual
                Case 80 'STICKER ARTICULOS REF: 67*25 C3 x 30 Rótulos Sistemas
                    DocImp_STICKERARTICULOSREF_67_25_C3x30_SISTEMAS.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_STICKERARTICULOSREF_67_25_C3x30_SISTEMAS.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_STICKERARTICULOSREF_67_25_C3x30_SISTEMAS
            End Select
            Try
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                If VerVistaPrevia = True Then
                    vistapreviack = True
                    VistaPrevia.ShowDialog()
                Else
                    VistaPrevia.Document.Print()
                End If
            Catch ex As Exception
                MsgBox("No se ha podido completar el proceso de impresión, por favor revisar la configuración.", MsgBoxStyle.Critical, "ERROR")
            End Try
        Next i
    End Sub
#End Region

End Class

Module GraphicsExtensions
    ''' <summary>Draws a string aligned to the right</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringRight(gr As Graphics, text As String, font As Font, brush As Brush, x As Single, y As Single)
        Dim padding As Single = gr.MeasureString(text, font).Width
        gr.DrawString(text, font, brush, x - padding, y)
    End Sub

    ''' <summary>Draws a centered string</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="point">Text coordinates</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringCentered(gr As Graphics, text As String, font As Font, brush As Brush, lineWidth As Integer, point As Point)
        gr.DrawStringCentered(text, font, brush, lineWidth, point.X, point.Y)
    End Sub

    ''' <summary>Draws a centered string</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringCentered(gr As Graphics, text As String, font As Font, brush As Brush, lineWidth As Integer, x As Single, y As Single)
        Dim padding As Single
        padding = (lineWidth / 2) - (gr.MeasureString(text, font).Width / 2)
        gr.DrawString(text, font, brush, x + padding, y)
    End Sub

    <Runtime.CompilerServices.Extension()>
    Sub ScaleImage(gr As Graphics, image As Image, maxWidth As Integer, maxHeight As Integer)
        Dim ratioX = CDbl(maxWidth) / image.Width
        Dim ratioY = CDbl(maxHeight) / image.Height
        Dim ratio = Math.Min(ratioX, ratioY)
        Dim newWidth = CInt((image.Width * ratioX))
        Dim newHeight = CInt((image.Height * ratioY))
        Dim newImage = New Bitmap(maxWidth, maxHeight)


        'Dim y As Integer = (maxHeight / 2) - newHeight / 2
        'Dim x As Integer = (maxWidth / 2) - newWidth / 2
        gr.DrawImage(image, 5, 50, 150, newHeight)

    End Sub


    <Runtime.CompilerServices.Extension()>
    Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, ByVal m_intxAxis As Integer, ByVal m_intyAxis As Integer, ByVal m_intWidth As Integer, ByVal m_intHeight As Integer, ByVal m_diameter As Integer)
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))

        'Top left arc
        objGraphics.DrawArc(Pens.Black, ArcRect, 180, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

        'Top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 270, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        'Bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 0, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

        'Bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(Pens.Black, ArcRect, 90, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
    End Sub
End Module 'GraphicsExtensions