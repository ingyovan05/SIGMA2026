Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Cl_Impresión

#Region "Variables para Imprimir"
    Private WithEvents VistaPrevia As New PrintPreviewDialog
    Private ClConvertir As New FuncionesBase.Cl_Convertir_Num_Letras

    Private logoIsmocol As Image = My.Resources.ResourceManager.GetObject("images")
    Private logoFuneraria As Image = My.Resources.imageoliv
    Private listaImagenesBD As List(Of Image)

    Private Lapiz As Pen
    Dim Lapiz_Gris As New Pen(Color.Silver, 1)
    Private Lapiz_Grueso As Pen
    Private Lapiz_Mediano As New Pen(Color.Black, 2)
    Private Brocha As New SolidBrush(Color.Black)
    Private BrochaBlanca As New SolidBrush(Color.White)
    Private BrochaGrisClaro As New SolidBrush(Color.Silver)
    Private BrochaVerdeClaro As New SolidBrush(Color.LightGreen)
    Private BrochaRojo As New SolidBrush(Color.Red)

    Private Formato_Etiqueta_4 As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_5 As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_5R As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_5RS As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Underline)

    Private Formato_Etiqueta_6 As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_6R As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_6RS As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_6RSI As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Italic)

    Private Formato_Etiqueta_7 As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_7R As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_7RS As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_7I As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_7IR As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular)

    Private Formato_Etiqueta_8 As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_8R As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_8RS As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_8I As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_8RIS As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_8IS As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic)

    Private Formato_Etiqueta_9 As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_9R As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_9RS As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_9RSI As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_9RSN As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_9I As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_9IR As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_10 As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_10R As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_10RS As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_10RSN As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_10I As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Italic)

    Private Formato_Etiqueta_11 As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_11R As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_11RS As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Underline)

    Private Formato_Etiqueta_12 As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_12R As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_12RS As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline)

    Private Formato_Etiqueta_14 As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_14R As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)

    Private Formato_Etiqueta_15 As New Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_16 As New Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_18 As New Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_80 As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_80R As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_80I As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_80RS As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Underline)

    '    'Variables de la forma
    Const espacioParrafo As Integer = 20
    Private contadorImpresionCadena As Integer = 0
    Private datosCargados As Boolean = False
    Private contadorPaginasImpresas As UInteger = 0
#End Region

#Region "Métodos para imprimir"
    Public Sub New()
        Brocha = New SolidBrush(Color.Black)
        Lapiz = New Pen(Brocha, 1)
        Lapiz_Grueso = New Pen(Brocha, 2)
    End Sub

    ''' <summary>
    ''' Justifica una línea de texto.
    ''' </summary>
    ''' <param name="Parrafo">Línea de texto original.</param>
    ''' <param name="fuente">Fuente del texto.</param>
    ''' <param name="longitud">Longitud máxima que debe abarcar la línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <returns></returns>
    Private Function SubParrafo1(Parrafo As String, fuente As Font, longitud As Double, e As PrintPageEventArgs) As String
        If Parrafo.IndexOf(" ") = -1 Then
            SubParrafo1 = Parrafo
            Exit Function
        End If
        Parrafo = Trim(Parrafo)
        If (Parrafo) <> "" Then
            Dim sz As SizeF = e.Graphics.MeasureString(Parrafo, fuente)
            If sz.Width < longitud / 2 Then
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


    Private Function PosicionSiguienteSeparador(texto As String, Inicio As Integer) As Integer
        Dim lngLongitudTexto = Len(texto)
        Dim strCaracter As String
        For lngPosicion = Inicio To lngLongitudTexto
            strCaracter = Mid$(texto, lngPosicion, 1)
            Select Case strCaracter
                Case vbNewLine, vbLf
                    PosicionSiguienteSeparador = lngPosicion
                    Exit Function
                    ' Si encuentra un espacio en blanco o un tabulador en la última posición recorre la cadena hacia la izquierda hasta encontrar un caracter
                Case " ", vbTab
                    PosicionSiguienteSeparador = lngPosicion
                    Exit Function
                Case Else
            End Select
        Next lngPosicion
        PosicionSiguienteSeparador = 1
    End Function

    ''' <summary>
    ''' Divide un párrafo en líneas de texto según la cantidad de palabras que quepan en la longitud indicada.
    ''' </summary>
    ''' <param name="vectorparrafos">Párrafo a dividir en renglones.</param>
    ''' <param name="fuente">Fuente.</param>
    ''' <param name="LongitudMaxima">Longitud máxima que puede abarcar cada línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <param name="ConLineaSeparacion">Indica si se incluye una línea en blanco intercalada en las líneas del párrafo.</param>
    ''' <returns>Vector con las líneas de texto divididas según la longitud máxima.</returns>
    Private Function TextoAParrafoFuente(vectorparrafos As ArrayList, fuente As Font, LongitudMaxima As Double, e As PrintPageEventArgs, Optional ConLineaSeparacion As Boolean = True) As ArrayList
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
                            LongitudLinea = e.Graphics.MeasureString(TempCadenaActual + " " + SiguientePalabra, fuente)
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
                'Quitar los espacios agregados al final.
            End If
            If ConLineaSeparacion = True Then
                TextoEnParrafo.Add("")
            End If
        Next
        TextoAParrafoFuente = TextoEnParrafo
    End Function

    ''' <summary>
    ''' Divide un párrafo en líneas de texto según la cantidad de palabras que quepan en la longitud indicada.
    ''' </summary>
    ''' <param name="vectorparrafos">Párrafo a dividir en renglones.</param>
    ''' <param name="fuente">Fuente.</param>
    ''' <param name="LongitudMaxima">Longitud máxima que puede abarcar cada línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <param name="ConLineaSeparacion">Indica si se incluye una línea en blanco intercalada en las líneas del párrafo.</param>
    ''' <returns>Vector con las líneas de texto divididas según la longitud máxima.</returns>
    Private Function TextoAParrafoFuente2(vectorparrafos As ArrayList, fuente As Font, LongitudMaxima As Double, e As PrintPageEventArgs, Optional ConLineaSeparacion As Boolean = True) As ArrayList
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
                            'LongitudLinea = e.Graphics.MeasureString(TempCadenaActual + " " + SiguientePalabra, fuente)
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
                                Dim TamañoPalabra As Integer = 0
                                If Trim(CadenaActual) = "" Then
                                    For j As Integer = 0 To CadenaRestante.Length 'Cambiar a 0
                                        LongitudLinea = e.Graphics.MeasureString(CadenaActual, fuente)
                                        If LongitudLinea.Width < LongitudMaxima - 10 Then
                                            CadenaActual += CadenaRestante(j)
                                            TamañoPalabra = j
                                        End If
                                    Next
                                    TextoEnParrafo.Add(CadenaActual)
                                    CadenaRestante = Mid$(CadenaRestante, TamañoPalabra + 2, Len(CadenaRestante))
                                Else
                                    TextoEnParrafo.Add(CadenaActual)
                                    CadenaRestante = Mid$(CadenaRestante, 1, Len(CadenaRestante))
                                End If
                            End If
                        Loop While Not NuevaLinea
                    End If
                End While
                'Quitar los espacios agregados al final.
            End If
            If ConLineaSeparacion = True Then
                TextoEnParrafo.Add("")
            End If
        Next
        TextoAParrafoFuente2 = TextoEnParrafo
    End Function

    ''' <summary>
    ''' Indica la coordenada en X de una línea de texto centrada en un ancho determinado.
    ''' </summary>
    ''' <param name="Texto">Línea de texto a centrar.</param>
    ''' <param name="fuente">Fuente.</param>
    ''' <param name="TamañoLinea">Ancho del espacio donde se va a centrar la línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <returns>Coordenada X del texto relativa al tamaño de la línea.</returns>
    Private Function InicioCentradoTexto(Texto As String, fuente As Font, TamañoLinea As Integer, e As PrintPageEventArgs) As Integer
        Dim LongitudTotal As SizeF
        LongitudTotal = e.Graphics.MeasureString(Texto, fuente)
        InicioCentradoTexto = CInt((TamañoLinea / 2) - (LongitudTotal.Width / 2))
    End Function


    ''' <summary>
    ''' Dibuja una cadena de texto con tamaño variable sujeto al ancho máximo indicado.
    ''' </summary>
    ''' <param name="e">Evento impresión</param>
    ''' <param name="cadena">Línea de texto a imprimir.</param>
    ''' <param name="nombreFuente">Nombre del tipo de fuente.</param>
    ''' <param name="tamannoFuenteReferencia">Tamaño inicial del texto.</param>
    ''' <param name="estiloFuente">Estilos de fuente (negrita, cursiva, etc).</param>
    ''' <param name="brochaTexto">Color del texto.</param>
    ''' <param name="anchoLinea">Ancho máximo que puede ocupar la línea de texto.</param>
    ''' <param name="x">Posición X donde se imprime la línea de texto.</param>
    ''' <param name="y">Posición Y donde se imprime la línea de texto </param>
    Private Sub LineaTextoAjustado(e As PrintPageEventArgs, cadena As String, nombreFuente As String, tamannoFuenteReferencia As Single, estiloFuente As FontStyle, brochaTexto As Brush, anchoLinea As Single, x As UInteger, y As UInteger)
        Dim medida As New SizeF
        Dim fuente As New Font(nombreFuente, tamannoFuenteReferencia, estiloFuente)
        Dim salto As Single = fuente.Size
        medida = e.Graphics.MeasureString(cadena, fuente)
        While Math.Abs(anchoLinea - medida.Width) > (anchoLinea * 0.01) 'medida.Width > anchoLinea OrElse
            salto = salto / 2
            If medida.Width > anchoLinea Then
                fuente = New Font(fuente.Name, fuente.Size - salto)
            Else
                fuente = New Font(fuente.Name, fuente.Size + salto)
            End If
            medida = e.Graphics.MeasureString(cadena, fuente)
        End While
        e.Graphics.DrawString(cadena, fuente, brochaTexto, x, y - (medida.Height * 0.85))
    End Sub


    ''' <summary>Imprime líneas verticales y horizontales a modo de rejilla con los ejes X y Y rotulados.</summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="colorLinea">Color de las líneas.</param>
    ''' <param name="esPunteada">Indica si la línea debe dibujarse punteada (verdadero) o sólida (falso).</param>
    ''' <param name="separacionPunteado">Separación de la línea punteada. Para dibujar una línea sólida, asignar el valor 0</param>
    ''' <param name="grosorLinea">Grosor de las líneas.</param>
    ''' <param name="pasoX">Separación de las líneas en el eje X, si no se especifica valor para la separación en el eje Y, se toma este valor como separación de las líneas verticales.</param>
    ''' <param name="pasoY">Separación de las líneas en el eje Y.</param>
    Private Sub DibujarRejilla(e As PrintPageEventArgs, colorLinea As Color, esPunteada As Boolean, separacionPunteado As Single, grosorLinea As Single, fuente As Font, pasoX As Single, pasoY As Single)
        If pasoX > 0 AndAlso pasoX < e.PageBounds.Right Then
            Dim gridPen As Pen = New Pen(colorLinea)
            gridPen.Width = grosorLinea
            If esPunteada Then
                If separacionPunteado > 0 Then
                    gridPen.DashPattern = New Single() {separacionPunteado, separacionPunteado, separacionPunteado, separacionPunteado}
                Else
                    gridPen.DashStyle = Drawing2D.DashStyle.Dash
                End If
            End If
            Dim numberBrush As Brush = New SolidBrush(colorLinea)
            For x As Integer = pasoX To e.PageBounds.Right Step pasoX
                e.Graphics.DrawLine(gridPen, x, e.PageBounds.Top, x, e.PageBounds.Bottom)
                e.Graphics.DrawString(x.ToString, fuente, numberBrush, x - (e.Graphics.MeasureString(x.ToString, fuente).Width / 2), e.PageBounds.Top)
            Next
            If pasoY <= 0 OrElse pasoY >= e.PageBounds.Bottom Then
                pasoY = pasoX
            End If
            For y As Integer = pasoY To e.PageBounds.Bottom Step pasoY
                e.Graphics.DrawString(y.ToString, fuente, numberBrush, e.PageBounds.Left, y - (e.Graphics.MeasureString(y.ToString, fuente).Height / 2))
                e.Graphics.DrawLine(gridPen, e.PageBounds.Left, y, e.PageBounds.Right, y)
            Next
        Else
            'MessageBox.Show("El valor de separación de las líneas debe estar definido entre el tamaño de los bordes de la página.", "Dibujar rejilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub
    ''' <summary>Imprime líneas verticales y horizontales a modo de rejilla con los ejes X y Y rotulados.</summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="colorLinea">Color de las líneas.</param>
    ''' <param name="esPunteada">Indica si la línea debe dibujarse punteada (verdadero) o sólida (falso).</param>
    ''' <param name="grosorLinea">Grosor de las líneas.</param>
    ''' <param name="pasoX">Separación de las líneas en el eje X, si no se especifica valor para la separación en el eje Y, se toma este valor como separación de las líneas verticales.</param>
    ''' <param name="pasoY">Separación de las líneas en el eje Y.</param>
    Private Sub DibujarRejilla(e As PrintPageEventArgs, colorLinea As Color, esPunteada As Boolean, grosorLinea As Single, fuente As Font, pasoX As Single, Optional pasoY As Single = 0)
        DibujarRejilla(e, colorLinea, esPunteada, 0, grosorLinea, fuente, pasoX, pasoY)
    End Sub
    ''' <summary>Imprime líneas verticales y horizontales a modo de rejilla con los ejes X y Y rotulados.</summary>
    ''' <param name="e">Evento de impresión del documento.</param>
    ''' <param name="colorLinea">Color de las líneas.</param>
    ''' <param name="separacionPunteado">Separación de la línea punteada. Para dibujar una línea sólida, asignar el valor 0</param>
    ''' <param name="grosorLinea">Grosor de las líneas.</param>
    ''' <param name="pasoX">Separación de las líneas en el eje X, si no se especifica valor para la separación en el eje Y, se toma este valor como separación de las líneas verticales.</param>
    ''' <param name="pasoY">Separación de las líneas en el eje Y.</param>
    Private Sub DibujarRejilla(e As PrintPageEventArgs, colorLinea As Color, separacionPunteado As Single, grosorLinea As Single, fuente As Font, pasoX As Single, Optional pasoY As Single = 0)
        If separacionPunteado > 0 Then
            DibujarRejilla(e, colorLinea, True, separacionPunteado, grosorLinea, fuente, pasoX, pasoY)
        Else
            DibujarRejilla(e, colorLinea, False, grosorLinea, fuente, pasoX, pasoY)
        End If
    End Sub
#End Region

#Region "Variables y Métodos Recurso Humano"
    Private ConsecutivoCartaBanco As String = ""
    Private cadenasSinInfoNoMostrar As New List(Of String)({"sin información", "sin informacion", "no aplica"})
    Private Function MostrarDato(textoDato As String) As Boolean
        Return Not cadenasSinInfoNoMostrar.Contains(Trim(textoDato).ToLower())
    End Function
#End Region

#Region "Consulta Datos Recurso Humano"
    Property Idpersona As Integer
    Property IdContrato As Integer
    Property IdBase As Integer
    Property IdCargoPropuesto As Integer

    Property FechaterminaciónObraLabor As Date

    ReadOnly Property ImpresionFinalizada As Boolean
        Get
            Return _impresionFinalizada
        End Get
    End Property
    Private _impresionFinalizada As Boolean = False
    Private _filaContrato As DataRow
    Private _filaPersona As DataRow
    Private _dtParientePersona As DataTable
    Private _dtConceptosContrato As DataTable
    Private _dtProrrogasContrato As DataTable
    Private _filaBaseConfiguracion As DataRow
    Private _filaOtrosiContrato As DataRow
    Private _filaEncuesta As DataRow
    Private _filaFechaExamen As DataRow

    Private Sub CargarDatasetRecursoHumano()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImpresionRecursoHumano", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDPERSONA", Idpersona)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        comando.Parameters.AddWithValue("@IDBASE", IdBase)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRecursoHumano As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsRecursoHumano)
            conexion.Close()
            'Table0 --> Persona
            'Table1 --> Pariente Persona
            'Table2 -->
            'Table3 --> Contrato
            'Table4 --> Conceptos Contrato
            'Table5 --> Prórrogas Contrato
            'Table6 --> Configuración Base
            'Table7 --> Otrosí Contrato
            'Table8 --> Encuesta Covid-19

            If dsRecursoHumano.Tables(0).Rows.Count > 0 Then
                _filaPersona = dsRecursoHumano.Tables(0).Rows(0)
            End If
            
            _dtParientePersona = dsRecursoHumano.Tables(1)
            If dsRecursoHumano.Tables(2).Rows.Count > 0 Then
                '_filaContratoBasico = dsRecursoHumano.Tables(2).Rows(0)
            End If
            If dsRecursoHumano.Tables(3).Rows.Count > 0 Then
                _filaContrato = dsRecursoHumano.Tables(3).Rows(0)
            End If
            _dtConceptosContrato = dsRecursoHumano.Tables(4)
            _dtProrrogasContrato = dsRecursoHumano.Tables(5)
            If dsRecursoHumano.Tables(6).Rows.Count > 0 Then
                _filaBaseConfiguracion = dsRecursoHumano.Tables(6).Rows(0)
            End If
            If dsRecursoHumano.Tables(7).Rows.Count > 0 Then
                _filaOtrosiContrato = dsRecursoHumano.Tables(7).Rows(0)
            End If
            If dsRecursoHumano.Tables(8).Rows.Count > 0 Then
                _filaEncuesta = dsRecursoHumano.Tables(8).Rows(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión de Recurso Humano", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub
#End Region

#Region "Rutina Impresión"
    Public Sub FormatosImprimir(Formatos As ArrayList, VerVistaPrevia As Boolean, Optional Doblecara As Boolean = False)
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
        CargarDatasetRecursoHumano()
        For i = 0 To Formatos.Count - 1
            Select Case CInt(Formatos(i))
                Case 1 'AUTORIZACIÓN EXÁMENES PREOCUPACIONALES DPTO. MÉDICO
                    DocImp_AutorizacionExamenesDeptoMedico.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AutorizacionExamenesDeptoMedico.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AutorizacionExamenesDeptoMedico
                Case 2 'ICA GRAL-F-068 DOCUMENTOS Y TRÁMITE PARA VINCULACIÓN DE NUEVOS EMPLEADOS
                    DocImp_ICAGRALF68.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF68.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF68
                Case 3 'ICA GRAL-F-091 ORDEN PARA CONSULTA MÉDICA Y AUTORIZACIÓN EXÁMENES PREOCUPACIONALES
                    DocImp_ICAGRALF91.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF91.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF91
                Case 4 'ICA GRAL-F-097 REGISTRO DE DATOS PERSONALES
                    DocImp_ICAGRALF97.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF97.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF97
                Case 5 'ICA GRAL-F-064 REQUERIMIENTO DE PERSONAL TERMINO FIJO
                    DocImp_ICAGRALF64.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF64.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF64
                Case 6 'ICA GRAL-F-067 REQUERIMIENTO Y APROBACIÓN PARA CONTRATACIÓN DE PERSONAL ROL DIARIO
                    DocImp_ICAGRALF67.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF67.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF67
                Case 7 'ICA GRAL-F-044 SELECCIÓN DE ADMINISTRADORA EN LOS SISTEMAS DE PENSION Y SALUD
                    DocImp_ICAGRALF44.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF44.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF44
                Case 8 'ICH GRAL-F-081 ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO
                    DocImp_ICHGRALF81.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF81.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF81
                Case 9 'ASIGNACIÓN BONO DE PRODUCCIÓN
                    DocImp_BONOPRODUCCION.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_BONOPRODUCCION.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_BONOPRODUCCION
                Case 10 'ASIGNACIÓN BONO TÉCNICO
                    DocImp_BONOTECNICO.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_BONOTECNICO.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_BONOTECNICO
                Case 11 'ICA GRAL-F-036 CARNET ISMOCOL S.A.
                    DocImp_ICAGRALF36.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF36.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF36
                Case 12 'CARTA BANCO
                    While Trim(ConsecutivoCartaBanco).Length = 0
                        ConsecutivoCartaBanco = InputBox("Número de Consecutivo del documento en SisControl", "Información Requerida - CARTA BANCO")
                    End While
                    DocImp_CARTABANCO.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTABANCO.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTABANCO
                Case 13 'ICA GRAL-F-034 CARTA DE TERMINACION DE CONTRATO A TERMINO FIJO
                    DocImp_ICAGRALF34.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF34.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF34
                Case 14 'ICA GRAL-F-129 - CARTA DE TERMINACIÓN DE CONTRATO DE TRABAJO DE LABOR U OBRA DETERMINADA
                    DocImp_ICAGRALF129.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF129.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF129
                Case 15 'CERTIFICADO INDUCCIÓN 'CAPACITACIÓN
                    DocImp_CERTIFICADOINDUCCION.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CERTIFICADOINDUCCION.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_CERTIFICADOINDUCCION
                Case 16 'ICH GRAL-F-014 COMPROMISO Y ACEPTACIÓN DE LA POLÍTICA DE SUSTANCIAS PSICOACTIVAS Y ALCOHOL
                    DocImp_ICHGRALF14.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF14.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF14
                Case 17 'ICS GRAL-F-203 COMPROMISO Y ACEPTACIÓN DE LA POLÍTICA Y PLAN ESTRATÉGICO DE SEGURIDAD VIAL PESV
                    DocImp_ICSGRALF203.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICSGRALF203.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICSGRALF203
                Case 18 'ICQ GRAL-F-011 CONSTANCIA DE ENTREGA DE DOCUMENTOS
                    DocImp_ICQGRALF11.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICQGRALF11.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICQGRALF11
                Case 19 'CONSTANCIA DE ENTREGA COPIA DE CONTRATO Y CARNET
                    DocImp_CONSTANCIACONTRATOCARNET.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CONSTANCIACONTRATOCARNET.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CONSTANCIACONTRATOCARNET
                Case 20 'ICA-GRAL-F-117 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF117.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF117.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF117
                Case 21 'ICA-GRAL-F-122 CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
                    DocImp_ICAGRALF122.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF122.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF122
                Case 22 'ICA-GRAL-F-121 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL
                    DocImp_ICAGRALF121.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF121.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF121
                Case 23 'ICA-GRAL-F-118 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF118.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF118.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF118
                Case 24 'ICA-GRAL-F-123 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
                    DocImp_ICAGRALF123.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF123.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF123
                Case 25 'ICA-GRAL-F-119 CONTRATO DE TRABAJO POR DURACIÓN DE LA OBRA O LABOR DETERMINADA DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF119.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF119.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF119
                Case 26 'ICA-GRAL-F-124 CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
                    DocImp_ICAGRALF124.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF124.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF124
                Case 27 'ICA-GRAL-F-181 CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL
                    DocImp_ICAGRALF181.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF181.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF181
                Case 28 'ICA-GRAL-F-120 CONTRATO DE TRABAJO POR DURACIÓN DE LABOR DETERMINADA PARA PERSONAL QUE NO ES DE DIRECCIÓN CONFIANZA Y MANEJO
                    DocImp_ICAGRALF120.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF120.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF120
                Case 29 'ICA-GRAL-F-125 CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
                    DocImp_ICAGRALF125.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF125.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF125
                Case 30 'ICA-GRAL-F-183 CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF183.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF183.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF183
                Case 31 'ICA-GRAL-F-184 CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF184.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF184.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF184
                Case 32 'ICS GRAL-F-032 ENTREGA DE DOTACIÓN AL PERSONAL
                    DocImp_ICSGRALF32.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICSGRALF32.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_ICSGRALF32
                Case 33 'ICA GRAL-F-046 PAZ Y SALVO PARA LIQUIDACIÓN FINAL CONTRATO
                    DocImp_ICAGRALF46.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF46.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF46
                Case 34 'PRESENTACION DE NUEVO EMPLEADO
                    DocImp_PresentacionNuevoEmpleado.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_PresentacionNuevoEmpleado.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_PresentacionNuevoEmpleado
                Case 35 'ICA GRAL-F-069 PROGRAMA DE INDUCCIÓN PERSONALIZADO PERSONAL MENSUALIZADO
                    DocImp_ICAGRALF69.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF69.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF69
                Case 36 'RECIBIDO ORDEN PARA EXAMEN MÉDICO DE RETIRO
                    DocImp_EXAMENRETIRO.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_EXAMENRETIRO.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_EXAMENRETIRO
                Case 37 'ICA GRAL-F-014 REGISTRO DE EMPLEADOS NUEVOS Y NOVEDADES
                    DocImp_ICAGRALF14.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF14.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF14
                Case 38 'ICA GRAL-L-001 LISTA DE CHEQUEO PARA LA ORDENACIÓN DE HISTORIAS LABORALES
                    DocImp_ICAGRALL1.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALL1.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALL1
                Case 39 'ICA GRAL-F-153 AUTORIZACIÓN PARA EL TRATAMIENTO DE DATOS PERSONALES
                    DocImp_ICAGRALF153.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF153.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF153
                Case 40 'NOTIFICACIÓN AUMENTO DE SALARIO
                    DocImp_CARTAAUMSALARIO.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTAAUMSALARIO.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTAAUMSALARIO
                Case 41 'ASIGNACIÓN AUXILIO DE HABITACIÓN
                    DocImp_AUXHABITACION.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AUXHABITACION.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AUXHABITACION
                Case 42 'ASIGNACIÓN AUXILIO EXTRALEGALES
                    DocImp_AUXEXTRALEGALES.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AUXEXTRALEGALES.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AUXEXTRALEGALES
                Case 43 'ASIGNACIÓN AUXILIO DE ALIMENTACIÓN
                    DocImp_AUXALIMENTACION.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AUXALIMENTACION.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AUXALIMENTACION
                Case 44 'ASIGNACIÓN AUXILIO DE TRANSPORTE
                    DocImp_AUXTRANSPORTE.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AUXTRANSPORTE.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AUXTRANSPORTE
                Case 45 'ASIGNACIÓN BONO DE BUEN MANTENIMIENTO Y CUIDADO DEL EQUIPO
                    DocImp_BONOMANTEQUIPO.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_BONOMANTEQUIPO.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_BONOMANTEQUIPO
                Case 46 'ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL
                    DocImp_AUXSININCIDSALARIAL.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AUXSININCIDSALARIAL.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AUXSININCIDSALARIAL
                Case 47 'DETERMINACIÓN DE LA CLASIFICACIÓN DE LAS PERSONAS NATURALES EN LAS CATEGORIAS TRIBUTARIAS ESTABLECIDAS EN EL ARTICULO 329 DEL ESTATUTO TRIBUTARIO
                    DocImp_CLASIFPERSONASNATURALES.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CLASIFPERSONASNATURALES.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CLASIFPERSONASNATURALES
                Case 48 'ICA GRAL-F-127 AUTORIZACIÓN DESCUENTO APORTE SINDICAL
                    DocImp_ICAGRALF127.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF127.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF127
                Case 49 'COMPROMISO CON LA SEGURIDAD, SALUD Y MEDIO AMBIENTE
                    DocImp_COMPSEGSALMEDAMBIENTE.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_COMPSEGSALMEDAMBIENTE.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_COMPSEGSALMEDAMBIENTE
                Case 50 'ICA GRAL-F-112 CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN
                    DocImp_ICAGRALF112.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF112.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF112
                Case 51 'RENUNCIA VOLUNTARIA AL CARGO
                    DocImp_CARTAACEPRENUNCIA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTAACEPRENUNCIA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTAACEPRENUNCIA
                Case 52 'ICA-GRAL-F-029 RENOVACIÓN CONTRATO DE TRABAJO A TÉRMINO FIJO
                    DocImp_ICAGRALF29.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF29.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF29
                Case 53 'PAZ Y SALVO LABORAL
                    DocImp_PAZYSALVOLAB.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_PAZYSALVOLAB.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_PAZYSALVOLAB
                Case 54 'CARTA BONO SOLDADOR (BONO DE PRODUCCIÓN)
                    DocImp_CartaBonoSoldador.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CartaBonoSoldador.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CartaBonoSoldador
                Case 55 'ICA GRAL-F-110 OTRO SÍ A CONTRATO DE TRABAJO POR LABOR CONTRATADA
                    DocImp_ICAGRALF110.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF110.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF110
                Case 56 'ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN
                    DocImp_ICQGRALF10.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICQGRALF10.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICQGRALF10
                Case 57 'ORDEN PARA CONSULTA MÉDICA DE RETIRO
                    DocImp_OrdenConsultaMedicaRetiro.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_OrdenConsultaMedicaRetiro.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_OrdenConsultaMedicaRetiro
                Case 58 'ICH-GRAL-F-357 CONSENTIMIENTO INFORMADO
                    DocImp_ICHGRALF357.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF357.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF357
                Case 59 'DECLARACIÓN DE PREEXISTENCIA DE PATOLOGÍA - RENUNCIA ACCIONES JUDICIALES
                    DocImp_DeclaracionPreexistenciaPatologia.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_DeclaracionPreexistenciaPatologia.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_DeclaracionPreexistenciaPatologia
                Case 60 'RENUNCIA VOLUNTARIA AL CARGO
                    DocImp_RenunciaVoluntaria.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RenunciaVoluntaria.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RenunciaVoluntaria
                Case 61 'ICQ-OMC-M-01 ANEXO 1. ROLES, RESPONSABILIDAD Y AUTORIDAD
                    DocImp_RolesResponsabilidadAutoridad.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_RolesResponsabilidadAutoridad.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_RolesResponsabilidadAutoridad
                Case 62 'CARTA BANCO BBVA"
                    DocImp_CARTABANCOBBVA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTABANCOBBVA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTABANCOBBVA
                Case 63 'CARTA BANCO BOGOTA"
                    DocImp_CARTABANBOGOTA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTABANBOGOTA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTABANBOGOTA
                Case 64 'CARTA BANCOLOMBIA"
                    DocImp_CARTABANCOLOMBIA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTABANCOLOMBIA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTABANCOLOMBIA
                Case 65 'CARTA BANCO ITAU"
                    DocImp_CARTABANCOITAU.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARTABANCOITAU.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARTABANCOITAU
                Case 66 'ASIGNACIÓN AUXILIO DE ALIMENTACIÓN CENIT
                    DocImp_AsignacionAuxilioAlimentacionCenit.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AsignacionAuxilioAlimentacionCenit.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AsignacionAuxilioAlimentacionCenit
                Case 67 'ASIGNACIÓN AUXILIO DE TRANSPORTE CENIT
                    DocImp_AsignacionAuxilioTransporteCenit.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AsignacionAuxilioTransporteCenit.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AsignacionAuxilioTransporteCenit
                Case 68 'ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL CENIT
                    DocImp_AsignacionAuxilioSinIncidenciaSalarialCenit.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AsignacionAuxilioSinIncidenciaSalarialCenit.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AsignacionAuxilioSinIncidenciaSalarialCenit
                Case 69 'CARNET CALIFICACION PERSONAL
                    DocImp_CARNETCALIFICACIONPERSONAL.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_CARNETCALIFICACIONPERSONAL.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_CARNETCALIFICACIONPERSONAL
                Case 70 'ICA GRAL-F-014 REGISTRO DE EMPLEADOS NUEVOS Y NOVEDADES revisión 2
                    DocImp_ICAGRALF14RV2.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF14RV2.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF14RV2
                Case 71 'ICA GRAL-F-034 CARTA DE TERMINACIÓN DE CONTRATO A TÉRMINO FIJO - ICA-GRAL-F-029 RENOVACIÓN CONTRATO DE TRABAJO A TÉRMINO FIJO
                    DocImp_ICAGRALF034029.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF034029.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF034029
                Case 72 'ICA GRAL-F-175 ASIGNACIÓN BONO DE PAZ LABORAL POR DIA LABORADO
                    DocImp_ICAGRALF175.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF175.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF175
                Case 73 'ICA GRAL-F-163 APLICACION PREVENTIVA PARA EVITAR CONTAGIO CON COVID - 19
                    DocImp_ICAGRALF163.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF163.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF163
                Case 74 'ICA GRAL-F-179 ACUERDO DE CONFIDENCIALIDAD LABORAL PARA CONTRATOS CON CENIT TRANSPORTE Y LOGISTICA DE HIDROCARBUROS
                    DocImp_ICAGRALF179.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF179.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF179
                Case 75 'ICA GRAL-F-034 CARTA DE TERMINACION DE CONTRATO A TERMINO FIJO (Solo Nombre)
                    DocImp_ICAGRALF34B.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF34B.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF34B
                Case 76 'ICA-GRAL-F-172 ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. - OCENSA
                    DocImp_ICAGRALF172.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF172.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF172
                Case 77 'ICA-GRAL-F-171 ASIGNACIÓN AUXILIO DE ALIMENTACIÓN PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. -OCENSA
                    DocImp_AsignacionAuxilioAlimentacionOcensa.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AsignacionAuxilioAlimentacionOcensa.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AsignacionAuxilioAlimentacionOcensa
                Case 78 'ICA-GRAL-F-170 ASIGNACIÓN AUXILIO DE TRANSPORTE PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. - OCENSA 
                    DocImp_AsignacionAuxilioTransporteOcensa.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_AsignacionAuxilioTransporteOcensa.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_AsignacionAuxilioTransporteOcensa
                Case 79 'ICH-MOCE-F-183 COMPROMISO DE CUMPLIMIENTO:   POLITICA Y MANUAL DE DERECHOS HUMANOS  CÓDIGO DE ÉTICA Y CONVIVENCIA 
                    DocImp_ICHMOCEF183.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHMOCEF183.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHMOCEF183
                Case 80 'ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN OCENSA
                    DocImp_ICQGRALF10OCENSA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICQGRALF10OCENSA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICQGRALF10OCENSA
                Case 81 'ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN ODC 
                    DocImp_ICQGRALF10ODC.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICQGRALF10ODC.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICQGRALF10ODC
                Case 82 'ICA MOCE-F-077 CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN - OCENSA
                    DocImp_ICAMOCEF077.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAMOCEF077.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAMOCEF077
                Case 83 'ICA GRAL-F-069 PROGRAMA DE INDUCCIÓN TUNJA
                    DocImp_ICAGRALF069TUNJA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF069TUNJA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF069TUNJA
                Case 84 'ICA MOCE-F-076 CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN - ODC
                    DocImp_ICAMOCEF076.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAMOCEF076.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAMOCEF076
                Case 85 'ICA GRAL-F-091 ORDEN PARA VALORACIONES MÉDICAS, EXÁMENES DE LABORATORIO, PARACLINICOS Y EXÁMENES DE CONDUCTORES
                    DocImp_ICAGRALF091.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF091.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF091
                Case 86 'ICA GRAL-F-091 ORDEN PARA VALORACIONES MÉDICAS, EXÁMENES DE LABORATORIO, PARACLINICOS Y EXÁMENES DE CONDUCTORES
                    DocImp_ICHMOCEF079.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHMOCEF079.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHMOCEF079
                Case 87 'DECLARACIÓN DE PREEXISTENCIA DE PATOLOGÍA - RENUNCIA ACCIONES JUDICIALES Y RENUNCIA VOLUNTARIA AL CARGO
                    DocImp_PreexistenciaRenuncia.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_PreexistenciaRenuncia.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_PreexistenciaRenuncia
                Case 88 'ICA-GRAL-F-182 Término indefinido que no son de dirección, confianza y manejo
                    DocImp_ICAGRALF182.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF182.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF182

                Case 89 'ICA-GRAL-F-117 V CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF117v.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF117v.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF117v
                Case 90 'ICA-GRAL-F-122 V CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
                    DocImp_ICAGRALF122v.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF122v.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF122v
                Case 91 'ICA-GRAL-F-121 V CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL
                    DocImp_ICAGRALF121v.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF121v.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF121v
                Case 92 'ICA-GRAL-F-118  V CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO
                    DocImp_ICAGRALF118v.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF118v.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF118v
                Case 93 'ICA-GRAL-F-123 v CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
                    DocImp_ICAGRALF123v.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF123v.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF123v
                Case 94 'ICH - GRAL - F - 178 CARNET DE AUTORIDAD PARA DETENER EL TRABAJO - ISMOCOL S.A.'
                    DocImp_ICHGRALF178.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF178.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF178
                Case 95 'ICA GRAL-F-046 PAZ Y SALVO PARA LIQUIDACIÓN FINAL CONTRATO + CONTROL DE SEGUIMIENTO
                    DocImp_ICAGRALF_46.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF_46.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF_46
                Case 96 'ICA GRAL-F-031 SECCION NOMINA NOVEDADES LIQUIDACION DINAL DEL CONTRATO
                    DocImp_ICAGRALF031.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF031.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF031
                Case 97 'Formato Reporte 24 Horas
                    DocImp_ICHGRALF03.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF03.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF03
                Case 98 'Formato Reporte Investigacion
                    DocImp_ICHGRALF04.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF04.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF04
                Case 99 'ICA GRAL-F-178 ASIGNACIÓN AUXILIO POR USO DE HERRAMIENTA MENOR
                    DocImp_ICAGRALF178.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF178.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF178
                Case 100 'Formato Alerta De Seguridad
                    DocImp_ICHGRALF142.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF142.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF142
                Case 101 'Formato Concepto Examen Medico ICH-GRAL-F-355
                    DocImp_ICHGRALF355.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF355.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF355
                Case 102 'ICA GRAL-F-190  Formato prima técnica de perforación   
                    DocImp_ICAGRALF190.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF190.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF190
                Case 103 'ICA-GRAL-F-191 FORMATO ASIGNACIÓN DE PRIMA TÉCNICA DE PERFORACIÓN 
                    DocImp_ICAGRALF191.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF191.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF191
                Case 104 'FORMATO DE AFILIACIÓN-SEGURO EXEQUIAL-COFUNERARIA LOS OLIVOS- 
                    DocImp_FormatoAfiliacionSeguro.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_FormatoAfiliacionSeguro.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_FormatoAfiliacionSeguro
                Case 105 'Formato Historia Clinica Examen Medico Ingreso ICH-GRAL-F-302
                    DocImp_ICHGRALF302.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF302.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHGRALF302
                Case 106 'Formato Resumen Estadistico ICH-GRAL-F-009
                    DocImp_ICHGRALF009.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHGRALF009.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_ICHGRALF009
                Case 107 'ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN TGTU 
                    DocImp_ICQGRALF10TGTU.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICQGRALF10TGTU.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICQGRALF10TGTU
                Case 108 'ICH-TGTU-F-010 CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN 
                    DocImp_ICHTGTUF010.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICHTGTUF010.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICHTGTUF010
                Case Else
                    'ICA GRAL-F-092	R3	INFORME FINAL DE SELECCIÓN (archivo Excel)
                    'ICA GRAL-F-032	R4	SOLICITUD DE PERMISO
                    MessageBox.Show("No se encontró el documento a imprimir", "Impresión Recursos Humanos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
            Try
                Cursor.Current = Cursors.WaitCursor
                If VerVistaPrevia = True Then
                    VistaPrevia.ShowDialog()
                Else
                    VistaPrevia.Document.Print()
                End If
                Cursor.Current = Cursors.Default
            Catch ex As Exception
                MessageBox.Show("No se ha podido completar el proceso de impresión, por favor revise la configuración.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub
#End Region

End Class 'Cl_Impresión

''' <summary>
''' Extension methods for the System.Drawing.Graphics class
''' </summary>
Module GraphicsExtensions

    ''' <summary>Draws an aligned string</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="alignment">Text horizontal alignment</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="point">Text coordinates</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringAligned(gr As Graphics, text As String, alignment As HorizontalAlignment, font As Font, brush As Brush, lineWidth As Integer, point As Point)
        gr.DrawStringAligned(text, alignment, font, brush, lineWidth, point.X, point.Y)
    End Sub

    ''' <summary>Draws an aligned string</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="alignment">Text horizontal alignment</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringAligned(gr As Graphics, text As String, alignment As HorizontalAlignment, font As Font, brush As Brush, lineWidth As Integer, x As Single, y As Single)
        Select Case alignment
            Case HorizontalAlignment.Center
                gr.DrawStringCentered(text, font, brush, lineWidth, x, y)
            Case HorizontalAlignment.Right
                gr.DrawStringRight(text, font, brush, x, y)
            Case Else 'HorizontalAlignment.Left
                gr.DrawString(text, font, brush, x, y)
        End Select
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
    ''' <param name="brush">Text fill color</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringCentered(gr As Graphics, text As String, font As Font, brush As Brush, lineWidth As Integer, x As Single, y As Single)
        Dim padding As Single
        padding = (lineWidth / 2) - (gr.MeasureString(text, font).Width / 2)
        gr.DrawString(text, font, brush, x + padding, y)
    End Sub

    ''' <summary>Draws a string aligned to the right</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="point">Text coordinates</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringRight(gr As Graphics, text As String, font As Font, brush As Brush, point As Point)
        gr.DrawStringRight(text, font, brush, point.X, point.Y)
    End Sub

    ''' <summary>Draws a string aligned to the right</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringRight(gr As Graphics, text As String, font As Font, brush As Brush, x As Single, y As Single)
        Dim padding As Single
        padding = gr.MeasureString(text, font).Width
        gr.DrawString(text, font, brush, x - padding, y)
    End Sub

    ''' <summary></summary>
    ''' <param name="objGraphics"></param>
    ''' <param name="m_intxAxis"></param>
    ''' <param name="m_intyAxis"></param>
    ''' <param name="m_intWidth"></param>
    ''' <param name="m_intHeight"></param>
    ''' <param name="m_diameter"></param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawRoundedRectangle(objGraphics As Graphics, m_intxAxis As Integer, m_intyAxis As Integer, m_intWidth As Integer, m_intHeight As Integer, m_diameter As Integer)
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
        ' top left Arc
        objGraphics.DrawArc(Pens.Black, ArcRect, 180, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)
        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 270, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 0, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)
        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(Pens.Black, ArcRect, 90, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
    End Sub
End Module 'GraphicsExtensions