Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Text
Imports System.Drawing.Text
Imports System.IO
Imports MessagingToolkit.QRCode.Codec

Public Class Cl_Impresión

#Region "Para Imprimir"
    Private logoIsmocol As Image = My.Resources.ResourceManager.GetObject("images")
    Private logoZamorana As Image = My.Resources.ResourceManager.GetObject("zamorana")
    Public LogoEmpresa As Integer = 0

    Dim Lapiz As Pen
    Dim Lapiz_Grueso As Pen
    Dim Brocha As New SolidBrush(Color.Black)
    Dim lineaPunteada As Pen

    Dim Formato_Etiqueta_4 As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_5 As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_5R As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_6 As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_6R As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_6I As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_6RS As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_7 As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_7R As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_7RS As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_7I As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_8 As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_8R As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_8RS As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_8I As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_9 As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_9R As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_9RS As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_9RSN As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_9I As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_10 As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_10R As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_10RS As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_10RSN As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_10I As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Italic)
    Dim Formato_Etiqueta_11 As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_11R As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_11RS As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_12 As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_12R As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_12RS As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline)
    Dim Formato_Etiqueta_13 As New Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_14 As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_14R As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_15 As New Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_16 As New Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_18 As New Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_80 As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Bold)
    Dim Formato_Etiqueta_80R As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Regular)
    Dim Formato_Etiqueta_80I As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Italic)
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
    Dim FilaDatosVISITANTE As DataRow
    Public idVisitante As String = 0
    Public idDocumento As String = 0

    Public Sub New()
        Brocha = New SolidBrush(Color.Black)
        Lapiz = New Pen(Brocha, 1)
        Lapiz_Grueso = New Pen(Brocha, 2)
        lineaPunteada = New Pen(Color.Gray, 0.5)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}
    End Sub


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

    Private Function PosicionCorte(ByVal Texto As String, ByVal Parrafo As Long) As Long
        Dim lngLongitudTexto As Long
        Dim lngContador As Long
        Dim strCaracter As String = ""
        Dim strIzquierda As String
        lngLongitudTexto = Len(Texto)
        ' Recorre carácter a carácter la cadena
        ' hasta la posición Parrafo.
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

    Private Function SubParrafo(ByVal Texto As String, ByVal Parrafo As Long) As String
        ' Devuelve una cadena contenida en la parte izquierda de Texto
        ' de longitud menor ó igual que el valor de Parrafo
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



    Private Function SubParrafo1(ByVal Parrafo As String, ByVal fuente As Drawing.Font, ByVal longitud As Double, ByVal e As System.Drawing.Printing.PrintPageEventArgs) As String
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

    Private Function PosicionSiguienteSeparador(ByVal texto, ByVal Inicio) As Integer
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
                'quitar los espacios agregados al final
            End If
            If ConLineaSeparacion = True Then
                TextoEnParrafo.Add("")
            End If
        Next
        TextoAParrafoFuente = TextoEnParrafo
    End Function

    Private Function InicioCentradoTexto(Texto As String, fuente As Font, TamañoLinea As Integer, e As PrintPageEventArgs) As Integer
        Dim LongitudTotal As SizeF
        LongitudTotal = e.Graphics.MeasureString(Texto, fuente)
        InicioCentradoTexto = CInt((TamañoLinea / 2) - (LongitudTotal.Width / 2))
    End Function

    Private Function FormatearValor(ByVal Valor As Decimal) As String
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
        FormatearValor = temp
    End Function

    Private Const DOT As String = ","

#Region "Numero a letras Pesos"


    Public Shared Function NumerosEnPalabras(ByVal Number As String, ByVal Moneda As String) As String
        Dim s As String
        Dim DecimalPlace As Integer
        Dim IntPart As String
        Dim Cents As String
        s = Format(Val(Number), "0.00")
        DecimalPlace = InStr(s, DOT)

        If DecimalPlace Then
            IntPart = Left(s, DecimalPlace - 1)
            Cents = Left(Mid(s, DecimalPlace + 1, 2), 2)
        Else
            IntPart = s
            Cents = ""
        End If

        If IntPart = "0" Or IntPart = "" Then
            s = "Cero "
        ElseIf Len(IntPart) > 7 Then
            s = IntNumToSpanish(Val(Left(IntPart, Len(IntPart) - 6))) + _
            "Millones " + IntNumToSpanish(Val(Right(IntPart, 6)))
        Else
            s = IntNumToSpanish(Val(IntPart))
        End If

        If Right(s, 9) = "Millones " Or Right(s, 7) = "Millón " Then
            s = s + "de "
        End If

        Select Case s
            Case "Un ", "Una "
                s = s & Singular(Moneda)
            Case Else
                s = s & Moneda
        End Select
        s = s & " "

        If Val(Cents) Then
            Cents = "con " + IntNumToSpanish(Val(Cents)) + "Centavos"
        Else
            Cents = ""
        End If
        Return (Trim(s + Cents))
    End Function

    Public Shared Function IntNumToSpanish(ByVal numero As Integer) As String
        Dim ptr As Integer
        Dim n As Integer
        Dim i As Integer
        Dim s As String
        Dim rtn As String
        Dim tem As String

        s = CStr(numero)
        n = Len(s)
        tem = ""
        i = n
        Do Until i = 0
            tem = EvalPart(Val(Mid(s, n - i + 1, 1) + CloneChain(i - 1, "0")))
            If Not tem = "Cero" Then
                rtn = rtn + tem + " "
            End If
            i = i - 1
        Loop

        '//Filters
        '//filterThousands

        ReplaceAll(rtn, " Mil Mil", " Un Mil")
        Do
            ptr = InStr(rtn, "Mil ")
            If ptr Then
                If InStr(ptr + 1, rtn, "Mil ") Then
                    ReplaceStringFrom(rtn, "Mil ", "", ptr)
                Else : Exit Do
                End If
            Else : Exit Do
            End If
        Loop

        '//filterHundreds
        ptr = 0
        Do
            ptr = InStr(ptr + 1, rtn, "Cien ")
            If ptr Then
                tem = Left(Mid(rtn, ptr + 5), 1)
                If tem = "M" Or tem = "" Then
                Else
                    ReplaceStringFrom(rtn, "Cien", "Ciento", ptr)
                End If
            End If
        Loop Until ptr = 0

        '//filterMisc
        ReplaceAll(rtn, "Diez Un", "Once")
        ReplaceAll(rtn, "Diez Dos", "Doce")
        ReplaceAll(rtn, "Diez Tres", "Trece")
        ReplaceAll(rtn, "Diez Cuatro", "Catorce")
        ReplaceAll(rtn, "Diez Cinco", "Quince")
        ReplaceAll(rtn, "Diez Seis", "Dieciséis")
        ReplaceAll(rtn, "Diez Siete", "Diecisiete")
        ReplaceAll(rtn, "Diez Ocho", "Dieciocho")
        ReplaceAll(rtn, "Diez Nueve", "Diecinueve")
        ReplaceAll(rtn, "Veinte Un", "Veintiún")
        ReplaceAll(rtn, "Veinte Dos", "Veintidós")
        ReplaceAll(rtn, "Veinte Tres", "Veintitrés")
        ReplaceAll(rtn, "Veinte Cuatro", "Veinticuatro")
        ReplaceAll(rtn, "Veinte Cinco", "Veinticinco")
        ReplaceAll(rtn, "Veinte Seis", "Veintiséis")
        ReplaceAll(rtn, "Veinte Siete", "Veintisiete")
        ReplaceAll(rtn, "Veinte Ocho", "Veintiocho")
        ReplaceAll(rtn, "Veinte Nueve", "Veintinueve")
        ReplaceAll(rtn, "Veintiúno", "Veintiuno")


        '//filterOne
        If Left(rtn, 1) = "M" Then
            rtn = "Un " + rtn
        End If

        '//Un Mil...
        If Left(rtn, 7) = "Un Mil " Then
            rtn = Mid(rtn, 4)
        End If

        '//addAnd
        For i = 65 To 88
            If Not i = 77 Then
                ReplaceAll(rtn, "a " + Chr(i), "* y " + Chr(i))
            End If
        Next
        ReplaceAll(rtn, "*", "a")
        Dim temp As String
        temp = Mid(rtn, 1, 3)

        If temp = "Uno" Then
            rtn = "Un" + Mid(rtn, 4, rtn.Length)
        End If
        ReplaceAll(rtn, "Onceo", "Once")
        IntNumToSpanish = rtn

    End Function

    Private Shared Function Singular(ByVal s As String) As String
        If Len(s) >= 2 Then
            If Right(s, 1) = "s" Then
                If Right(s, 2) = "es" Then
                    Singular = Left(s, Len(s) - 2)
                Else
                    Singular = Left(s, Len(s) - 1)
                End If
            Else
                Singular = s
            End If
        End If
    End Function

    Private Shared Function EvalPart(ByVal x As Integer) As String
        Dim rtn As String
        Dim s As String
        Dim i As Integer

        Do
            Select Case x
                Case 0 : s = "Cero"
                Case 1 : s = "Uno"
                Case 2 : s = "Dos"
                Case 3 : s = "Tres"
                Case 4 : s = "Cuatro"
                Case 5 : s = "Cinco"
                Case 6 : s = "Seis"
                Case 7 : s = "Siete"
                Case 8 : s = "Ocho"
                Case 9 : s = "Nueve"
                Case 10 : s = "Diez"
                Case 20 : s = "Veinte"
                Case 30 : s = "Treinta"
                Case 40 : s = "Cuarenta"
                Case 50 : s = "Cincuenta"
                Case 60 : s = "Sesenta"
                Case 70 : s = "Setenta"
                Case 80 : s = "Ochenta"
                Case 90 : s = "Noventa"
                Case 100 : s = "Cien"
                Case 200 : s = "Doscientos"
                Case 300 : s = "Trescientos"
                Case 400 : s = "Cuatrocientos"
                Case 500 : s = "Quinientos"
                Case 600 : s = "Seiscientos"
                Case 700 : s = "Setecientos"
                Case 800 : s = "Ochocientos"
                Case 900 : s = "Novecientos"
                Case 1000 : s = "Mil"
                Case 1000000 : s = "Millón"
            End Select

            If s = "" Then
                i = i + 1
                x = x / 1000
                If x = 0 Then i = 0
            Else
                Exit Do
            End If
        Loop Until i = 0

        rtn = s
        Select Case i
            Case 0 : s = ""
            Case 1 : s = " Mil"
            Case 2 : s = " Millones"
            Case 3 : s = " Billones"
        End Select
        EvalPart = rtn + s
        Exit Function

    End Function

#End Region

#Region "Numero a letras Otras Monedas Revisión 1"

    'Argumentos:
    'Numero = Valor que deseamos convertir en texto
    'Estilo = Formato de salida
    '           1 = MAYÚSCULAS
    '           2 = minúsculas
    '           3 = Tipo Titulo
    'Los valores negativos los convierte a positivos
    'El valor mínimo en 0, el valor máximo es  9,999,999,999,999.99
    'La fuente original no lo sé con seguridad, pero en el foro de emagister Excel un amigo lo publicó hace muchos años (Armando montes).
    'Descargado de www.excelnegocios.com
    'Gustavo A. Sebastiani: Solo he realizado unas minúsculas modificaciones, por tanto no me declaro en ningún momento autor de la fórmula.

    Public Function NumeLetrasOtrasMonedasV1(ByVal numero As Double, conector As String, moneda As String, ByVal Estilo As Integer) As String
        Dim NumTmp As String
        Dim c01 As Integer
        Dim c02 As Integer
        Dim pos As Integer
        Dim dig As Integer
        Dim cen As Integer
        Dim dec As Integer
        Dim uni As Integer
        Dim letra1 As String
        Dim letra2 As String
        Dim letra3 As String
        Dim Leyenda As String
        Dim TFNumero As String

        If numero < 0 Then numero = Math.Abs(numero)

        NumTmp = Format(numero, "000000000000000.00")        'Le da un formato fijo
        c01 = 1
        pos = 1
        TFNumero = ""
        'Para extraer tres dígitos cada vez
        Do While c01 <= 5
            c02 = 1
            Do While c02 <= 3
                'Extrae un dígito cada vez de izquierda a derecha
                dig = Val(Mid(NumTmp, pos, 1))
                Select Case c02
                    Case 1 : cen = dig
                    Case 2 : dec = dig
                    Case 3 : uni = dig
                End Select
                c02 = c02 + 1
                pos = pos + 1
            Loop
            letra3 = Centena(uni, dec, cen)
            letra2 = Decena(uni, dec)
            letra1 = Unidad(uni, dec)

            Select Case c01
                Case 1
                    If cen + dec + uni = 1 Then
                        Leyenda = "Billon "
                    ElseIf cen + dec + uni > 1 Then
                        Leyenda = "Billones "
                    End If
                Case 2
                    If cen + dec + uni >= 1 And Val(Mid(NumTmp, 7, 3)) = 0 Then
                        Leyenda = "Mil Millones "
                    ElseIf cen + dec + uni >= 1 Then
                        Leyenda = "Mil "
                    End If
                Case 3
                    If cen + dec = 0 And uni = 1 Then
                        Leyenda = "Millon "
                    ElseIf cen > 0 Or dec > 0 Or uni > 1 Then
                        Leyenda = "Millones "
                    End If
                Case 4
                    If cen + dec + uni >= 1 Then
                        Leyenda = "Mil "
                    End If
                Case 5
                    If cen + dec + uni >= 1 Then
                        Leyenda = ""
                    End If
            End Select

            c01 = c01 + 1
            TFNumero = TFNumero + letra3 + letra2 + letra1 + Leyenda

            Leyenda = ""
            letra1 = ""
            letra2 = ""
            letra3 = ""
        Loop
        TFNumero = TFNumero & conector

        Select Case Estilo
            Case 1
                TFNumero = StrConv(TFNumero, vbUpperCase)
                moneda = StrConv(moneda, vbUpperCase)
            Case 2
                TFNumero = StrConv(TFNumero, vbLowerCase)
                moneda = StrConv(moneda, vbLowerCase)
            Case Else
                TFNumero = StrConv(TFNumero, vbProperCase)
                moneda = StrConv(moneda, vbProperCase)
        End Select

        TFNumero = TFNumero & " " & Mid(NumTmp, 17) & "/100 "

        NumeLetrasOtrasMonedasV1 = TFNumero & moneda

    End Function

    Private Function Centena(ByVal uni As Integer, ByVal dec As Integer, _
                             ByVal cen As Integer) As String
        Dim cTexto As String

        Select Case cen
            Case 1
                If dec + uni = 0 Then
                    cTexto = "cien "
                Else
                    cTexto = "ciento "
                End If
            Case 2 : cTexto = "doscientos "
            Case 3 : cTexto = "trescientos "
            Case 4 : cTexto = "cuatrocientos "
            Case 5 : cTexto = "quinientos "
            Case 6 : cTexto = "seiscientos "
            Case 7 : cTexto = "setecientos "
            Case 8 : cTexto = "ochocientos "
            Case 9 : cTexto = "novecientos "
            Case Else : cTexto = ""
        End Select
        Centena = cTexto

    End Function

    Private Function Decena(ByVal uni As Integer, ByVal dec As Integer) As String
        Dim cTexto As String

        Select Case dec
            Case 1
                Select Case uni
                    Case 0 : cTexto = "diez "
                    Case 1 : cTexto = "once "
                    Case 2 : cTexto = "doce "
                    Case 3 : cTexto = "trece "
                    Case 4 : cTexto = "catorce "
                    Case 5 : cTexto = "quince "
                    Case 6 To 9 : cTexto = "dieci"
                End Select
            Case 2
                If uni = 0 Then
                    cTexto = "veinte "
                ElseIf uni > 0 Then
                    cTexto = "veinti"
                End If
            Case 3 : cTexto = "treinta "
            Case 4 : cTexto = "cuarenta "
            Case 5 : cTexto = "cincuenta "
            Case 6 : cTexto = "sesenta "
            Case 7 : cTexto = "setenta "
            Case 8 : cTexto = "ochenta "
            Case 9 : cTexto = "noventa "
            Case Else : cTexto = ""
        End Select

        If uni > 0 And dec > 2 Then cTexto = cTexto + "y "

        Decena = cTexto

    End Function

    Private Function Unidad(ByVal uni As Integer, ByVal dec As Integer) As String
        Dim cTexto As String

        If dec <> 1 Then
            Select Case uni
                Case 1 : cTexto = "un "
                Case 2 : cTexto = "dos "
                Case 3 : cTexto = "tres "
                Case 4 : cTexto = "cuatro "
                Case 5 : cTexto = "cinco "
            End Select
        End If
        Select Case uni
            Case 6 : cTexto = "seis "
            Case 7 : cTexto = "siete "
            Case 8 : cTexto = "ocho "
            Case 9 : cTexto = "nueve "
        End Select

        Unidad = cTexto

    End Function


#End Region

    Private Shared Function CloneChain(ByVal n As Integer, ByVal Chr As String)
        Dim i As Integer
        Dim CharClone As String
        Dim rtn As String = ""
        If Len(Chr) Then
            CharClone = Mid(Chr, 1, 1)
            For i = 1 To n
                rtn = rtn + CharClone
            Next
        End If
        Return rtn
    End Function

    Private Shared Sub ReplaceAll( _
      ByRef s As String, _
      ByVal OldWrd As String, _
      ByVal NewWrd As String)
        Dim ptr As Integer
        Do
            ptr = InStr(s, OldWrd)
            If ptr Then
                s = Left(s, ptr - 1) + NewWrd + Mid(s, Len(OldWrd) + ptr)
            End If
        Loop Until ptr = 0
    End Sub

    Private Shared Sub ReplaceStringFrom(ByRef s As String, _
      ByVal OldWrd As String, _
      ByVal NewWrd As String, _
      ByVal ptr As Integer)
        s = Left(s, ptr - 1) + NewWrd + Mid(s, Len(OldWrd) + ptr)
    End Sub

    Private Sub ImprimirRejilla(ByVal e As PrintPageEventArgs, ByVal color As Color, ByVal separacionPunteado As Integer, ByVal grosor As Single, ByVal pasoX As Integer, Optional pasoY As Integer = 0)
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

    Private Function MaxOfValues(ParamArray values As Integer()) As Integer
        Return Enumerable.Max(values)
    End Function
#End Region


#Region "70 - ICS-GRAL-F-05 Rv No.5 ORDEN DE SERVICIO "

    Dim WithEvents DocImp_ORDENSERVICIO As New PrintDocument 'Documento a imprimir
    Dim CargarDatasetOrdeServicio As Boolean = True
    Dim Impresion As Boolean = False
    Dim Dt_OrdeServicio As DataTable
    Dim FilaOrdeServicio As DataRow
    Dim IDRELACIONDOCUMENTO As Integer
    Public IdOrdenServicio As Integer = -1
    Public Formatoorden As Boolean = False
    Public OrdenCierre As Boolean = False



    Private Sub DocImpORDENSERVICIO(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ORDENSERVICIO.PrintPage
        If CargarDatasetOrdeServicio = True Then
            Dim Cadena_Consulta As String

            Cadena_Consulta = "SELECT * FROM  dbo.ImpresionOrdenServicio(" + IdOrdenServicio.ToString + ") AS ImpresionOrdenServicio"

            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdeServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdeServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdeServicio)
            Consulta.Connection.Close()
            FilaOrdeServicio = Dt_OrdeServicio.Rows(0)
            CargarDatasetOrdeServicio = False
        Else
            Impresion = True
        End If

        If Formatoorden Then

            If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
                LogoEmpresa = 2
            End If

            Select Case LogoEmpresa
                Case 0 'Ismocol
                    e.Graphics.DrawImage(logoIsmocol, 50, 40, 90, 75)
                Case 1 'CSI
                Case 2 'Zamorana
                    e.Graphics.DrawImage(logoZamorana, 40, 80, 110, 35)
            End Select

            DrawRoundedRectangle(e.Graphics, 515, 60, 180, 40, 20)
            'e.Graphics.DrawLine(Lapiz, 520, 50, 600, 50)

            If OrdenCierre Then

                e.Graphics.DrawString("ACTA DE CIERRE", Formato_Etiqueta_18, Brocha, 290, 40)
                DrawRoundedRectangle(e.Graphics, 50, 120, 740, 500, 20)
                e.Graphics.DrawString("FACTURA No.", Formato_Etiqueta_7R, Brocha, 60, 535)
                e.Graphics.DrawString("FECHA FACTURA", Formato_Etiqueta_7R, Brocha, 291, 535)
                e.Graphics.DrawString("VALOR", Formato_Etiqueta_7R, Brocha, 406, 535)

                e.Graphics.DrawString("OBSERVACIONES:", Formato_Etiqueta_7R, Brocha, 60, 575)

                e.Graphics.DrawString("SERVICIOS RECIBIDOS A SATISFACIÓN:", Formato_Etiqueta_7R, Brocha, 530, 495)
                e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7R, Brocha, 530, 545)
                e.Graphics.DrawString("POR:", Formato_Etiqueta_7R, Brocha, 530, 555)

                e.Graphics.DrawLine(Lapiz, 290, 495, 290, 570)
                e.Graphics.DrawLine(Lapiz, 530, 495, 530, 570)

                e.Graphics.DrawLine(Lapiz, 405, 530, 405, 570)

                e.Graphics.DrawLine(Lapiz, 50, 530, 530, 530)

                e.Graphics.DrawLine(Lapiz, 50, 570, 790, 570)

            Else
                DrawRoundedRectangle(e.Graphics, 50, 120, 740, 410, 20)
                e.Graphics.DrawString("VALOR ESTIMADO", Formato_Etiqueta_7R, Brocha, 530, 495)
                e.Graphics.DrawLine(Lapiz, 290, 495, 290, 530)
                e.Graphics.DrawLine(Lapiz, 530, 495, 530, 530)

            End If

            e.Graphics.DrawString("ORDEN DE PRESTACIÓN DE SERVICIOS No.", Formato_Etiqueta_12, Brocha, 150, 70)


            Select Case LogoEmpresa
                Case 0
                    e.Graphics.DrawString("ISMOCOL S.A.          NIT. 890.209.174-1", Formato_Etiqueta_11, Brocha, 200, 90)
                Case 1
                Case 2
                    e.Graphics.DrawString("ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S.  NIT. 900.149.238-1", Formato_Etiqueta_8, Brocha, 160, 100)
            End Select


            Dim CEDULAENCRIPTADA As String
            CEDULAENCRIPTADA = FuncionesBase.FuncionesBase.Encryptar(IdOrdenServicio)
            Dim TIPO As String
            TIPO = FuncionesBase.FuncionesBase.Encryptar("OS")
            Dim CORTE As String
            CORTE = FuncionesBase.FuncionesBase.Encryptar(FilaOrdeServicio("ORDENSERVICIO"))

            Dim linkqr As String
            linkqr = "http://190.0.43.174:7070/publico/wf_ConsultarQR.aspx?CED=" + CEDULAENCRIPTADA + "&&TIPO=" + TIPO + "&&CORTE=" + CORTE

            Dim encoder As New QRCodeEncoder()
            encoder.QRCodeScale = 3
            Dim img As New Bitmap(encoder.Encode(linkqr))
            e.Graphics.DrawImage(img, 700, 20, 90, 90)
            e.Graphics.DrawString("Escanee para validar", Formato_Etiqueta_6, Brocha, 702, 110)




            e.Graphics.DrawString("NOMBRE COMPLETO DEL CONTRATISTA", Formato_Etiqueta_7R, Brocha, 60, 125)
            e.Graphics.DrawString("DIRECCIÓN DEL CONTRATISTA", Formato_Etiqueta_7R, Brocha, 60, 155)

            e.Graphics.DrawLine(Lapiz, 50, 150, 790, 150)
            e.Graphics.DrawLine(Lapiz, 50, 180, 420, 180)
            e.Graphics.DrawLine(Lapiz, 50, 240, 790, 240)
            e.Graphics.DrawLine(Lapiz, 420, 120, 420, 240)

            e.Graphics.DrawString("IMPORTANTE: Conforme a los términos especificados, solicitamos", Formato_Etiqueta_6R, Brocha, 80, 190)
            e.Graphics.DrawString("los  servicios  descritos  a  continuación.   Al  aceptar  esta  orden  el contratista", Formato_Etiqueta_6R, Brocha, 80, 200)
            e.Graphics.DrawString("acepta dichos términos y condiciones.", Formato_Etiqueta_6R, Brocha, 80, 210)

            e.Graphics.DrawString("MUNICIPIO DONDE SE EJECUTARA EL SERVICIO               FECHA EMISIÓN", Formato_Etiqueta_7R, Brocha, 430, 125)
            e.Graphics.DrawLine(Lapiz, 420, 120, 420, 240)
            e.Graphics.DrawLine(Lapiz, 690, 120, 690, 150)

            e.Graphics.DrawString("Se debe indicar el número de esta Orden en sus Facturas. El original de esta", Formato_Etiqueta_6R, Brocha, 450, 165)
            e.Graphics.DrawString("orden de servicio debe enviarse firmada y sellada junto con el original y copia", Formato_Etiqueta_6R, Brocha, 450, 175)
            Select Case LogoEmpresa
                Case 0 'Ismocol S.A.
                    e.Graphics.DrawString("de la correspondiente factura a Ismocol S.A.", Formato_Etiqueta_6R, Brocha, 450, 185)
                Case 1
                Case 2
                    e.Graphics.DrawString("de la correspondiente factura a ZAMORANA", Formato_Etiqueta_6R, Brocha, 450, 185)
            End Select

            e.Graphics.DrawString("EN ", Formato_Etiqueta_6R, Brocha, 438, 210)
            e.Graphics.DrawLine(Lapiz, 450, 222, 750, 222)
            e.Graphics.DrawString("(Proyecto/Base donde se contrató el servicio)", Formato_Etiqueta_7R, Brocha, 500, 225)

            e.Graphics.DrawString("DESCRIPCIÓN DEL SERVICIO SOLICITADO (INCLUYE EL EQUIPO NECESARIO)", Formato_Etiqueta_7R, Brocha, 210, 245)

            e.Graphics.DrawLine(Lapiz, 50, 260, 790, 260)
            e.Graphics.DrawLine(Lapiz, 50, 284, 790, 284)
            e.Graphics.DrawLine(Lapiz, 50, 308, 790, 308)
            e.Graphics.DrawLine(Lapiz, 50, 332, 790, 332)
            e.Graphics.DrawLine(Lapiz, 50, 356, 790, 356)
            e.Graphics.DrawLine(Lapiz, 50, 380, 790, 380)

            e.Graphics.DrawString("REMUNERACIÓN CONVENIDA:", Formato_Etiqueta_7R, Brocha, 60, 380)
            e.Graphics.DrawLine(Lapiz, 50, 410, 790, 410)

            e.Graphics.DrawString("ACEPTADO POR EL CONTRATISTA (FIRMA):", Formato_Etiqueta_8, Brocha, 60, 415)

            Select Case LogoEmpresa
                Case 0
                    e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_5R, Brocha, 620, 415)
                Case 1
                Case 2
                    e.Graphics.DrawString("ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S.", Formato_Etiqueta_5R, Brocha, 520, 415)
            End Select


            e.Graphics.DrawLine(Lapiz, 60, 470, 450, 470)
            e.Graphics.DrawString("NIT./C.C. No.", Formato_Etiqueta_8R, Brocha, 60, 475)

            e.Graphics.DrawLine(Lapiz, 470, 470, 780, 470)
            e.Graphics.DrawString("Firma autorizada", Formato_Etiqueta_8R, Brocha, 600, 475)

            e.Graphics.DrawLine(Lapiz, 50, 495, 790, 495)

            e.Graphics.DrawString("SOLICITADO POR:", Formato_Etiqueta_7R, Brocha, 60, 495)
            e.Graphics.DrawString("CARGUESE A CENTRO DE COSTO No.", Formato_Etiqueta_7R, Brocha, 291, 495)


            'e.Graphics.DrawLine(Lapiz, 50, 570, 790, 570)

            Dim LineaY As Integer
            Dim LineaX As Integer
            LineaX = 55



            If OrdenCierre Then
                LineaY = 580
                'DrawRoundedRectangle(e.Graphics, 50, 575, 740, 460, 20)
                Dim alineacionY As Integer = 410
                Select Case LogoEmpresa
                    Case 0 'Ismocol S.A.
                        e.Graphics.DrawRectangle(Lapiz, 710, 1037 - alineacionY, 80, 20)
                        e.Graphics.DrawLine(Lapiz, 710, 1047 - alineacionY, 790, 1047 - alineacionY)
                        e.Graphics.DrawString("ICS-GRAL-F-041", Formato_Etiqueta_6R, Brocha, 712, 1037 - alineacionY)
                        e.Graphics.DrawString("REVISIÓN No. 2", Formato_Etiqueta_6R, Brocha, 711, 1047 - alineacionY)
                    Case 1
                    Case 2 'ZAMORANA
                        e.Graphics.DrawRectangle(Lapiz, 710, 1037 - alineacionY, 80, 20)
                        e.Graphics.DrawLine(Lapiz, 710, 1047 - alineacionY, 790, 1047 - alineacionY)
                        e.Graphics.DrawString("ZMS-GRAL-F-004", Formato_Etiqueta_6R, Brocha, 712, 1037 - alineacionY)
                        e.Graphics.DrawString("REVISIÓN No. 1", Formato_Etiqueta_6R, Brocha, 711, 1047 - alineacionY)
                End Select
            Else
                LineaY = 540
                DrawRoundedRectangle(e.Graphics, 50, 535, 740, 500, 20)
                Select Case LogoEmpresa
                    Case 0 'Ismocol S.A.
                        e.Graphics.DrawRectangle(Lapiz, 710, 1037, 80, 20)
                        e.Graphics.DrawLine(Lapiz, 710, 1047, 790, 1047)
                        e.Graphics.DrawString("ICS-GRAL-F-05", Formato_Etiqueta_6R, Brocha, 712, 1037)
                        e.Graphics.DrawString("REVISIÓN No. 6", Formato_Etiqueta_6R, Brocha, 711, 1047)
                    Case 1
                    Case 2 'ZAMORANA
                        e.Graphics.DrawRectangle(Lapiz, 710, 1037, 80, 20)
                        e.Graphics.DrawLine(Lapiz, 710, 1047, 790, 1047)
                        e.Graphics.DrawString("ZMS-GRAL-F-003", Formato_Etiqueta_6R, Brocha, 712, 1037)
                        e.Graphics.DrawString("REVISIÓN No. 2", Formato_Etiqueta_6R, Brocha, 711, 1047)
                End Select
            End If


            If OrdenCierre = False Then


                e.Graphics.DrawString("TÉRMINOS    DEL CONTRATO", Formato_Etiqueta_8, Brocha, 310, LineaY)

                LineaY = LineaY + 15

                e.Graphics.DrawString("Con la firma del presente documento, declaro que mis recursos tienen un origen lícito y que mi ocupación económica se desarrolla dentro del marco legal y normativo", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("correspondiente. Adicionalmente declaro que todas las actividades e ingresos que percibo provienen de actividades lícitas y que no me encuentro en ninguna lista de", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("reporte internacional vinculantes para Colombia de  conformidad con  el derecho internacional (listas de las Naciones Unidas) o  en las listas  de la OFAC o  cualquier", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10

                Select Case LogoEmpresa
                    Case 0

                        e.Graphics.DrawString("otra; asi  mismo me  comprometo a comunicar  cualquier tipo  de  anomalía  referente  a Lavado  de Activos  y  Financiación del  Terrorismo  LA-FT a  Ismocol  y a las", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                        LineaY = LineaY + 10
                        e.Graphics.DrawString("autoridades competentes.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)

                    Case 1
                    Case 2

                        e.Graphics.DrawString("otra;  asi  mismo  me  comprometo a  comunicar  cualquier  tipo  de  anomalía  referente  a  Lavado de Activos y  Financiación  del  Terrorismo   LA-FT a ZAMORANA", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                        LineaY = LineaY + 10
                        e.Graphics.DrawString("PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S. y a las autoridades competentes.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)

                End Select

                LineaY = LineaY + 15

                e.Graphics.DrawString("EL   CONTRATISTA   se  obliga  a  ejecutar   las  obras  o  labores   especificadas,  asumiendo   todos  los   riesgos   propios  de  la   actividad   contratada   con  sus", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("propios  medios,  trabajadores,  equipos,  instrumentos  y  materiales  requeridos,  y  tendrá  libertad  y  autonomía  técnica  y  directiva  en  la  ejecución  del  servicio", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("solicitado,    siendo  de  su  cargo obtener  los permisos que  fueren necesarios  para  la completa realización del trabajo,  a menos que respecto de esos permisos se", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("establezca lo contrario.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("EL CONTRATISTA   procederá  con  verdadera  autonomía  técnica  y directiva  ,  en  calidad  de  contratista   independiente  y no  como  trabajador,  representante o", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("intermediario de LA COMPAÑIA, por lo tanto, se obliga a cumplir con todas las disposiciones legales relacionadas con la ejecución de este  contrato,  siendo  además", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("su exclusiva  responsabilidad  las indemnizaciones   derivadas  de  accidentes  o  enfermedades  que   él, sus empleados,  subcontratistas  o cualquier  personal bajo", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("su dirección, adquieran en desarrollo de la actividad contratada.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("EL CONTRATISTA  autoriza a LA COMPAÑíA  para retener hasta el  QUINCE POR CIENTO ( 15%) del valor del contrato hasta que demuestre que ha pagado a sus", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("trabajadores  los salarios,  prestaciones, indemnizaciones  y  demás acreencias a que tengan derecho conforme a la ley, o haya cumplido cualquier obligación que se", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("advierta que ha dejado de cumplir.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("EL CONTRATISTA  responderá  por las lesiones o perjuicios causados a las personas, así como por los daños a bienes muebles e inmuebles y los perjuicios que de", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("allí se deriven, cuando sea consecuencia de la ejecución de la labor que se le ha encomendado,  tales como los ocasionados por negligencia, imprudencia, impericia", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("o violación a reglamentos, por parte del mismo contratista, sus empleados, subcontratistas o cualquier personal bajo su dirección. Ocurrido un daño a LA COMPAÑIA", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("se reserva  el derecho  de hacer efectivas  las pólizas    que  para  el efecto  haya  adquirido  EL CONTRATISTA,  y/o retener  las sumas  que  esté adeudando  a EL", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("CONTRATISTA, hasta que éste le demuestre que ha reparado los daños y perjuicios ocasionados, o que ha sido absuelto jurídicamente de la obligación de reparar.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("EL CONTRATISTA declara que conoce todos los riesgos de la actividad a realizar, siendo su obligación y responsabilidad tomar los contratos de seguros necesarios", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("para cubrir sus  bienes, materiales  y  equipos; incluyendo  su  personal y/o  cualquier tipo  de daño  que pueda  causar  a terceros,  en tal  sentido,  exonera de toda", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("responsabilidad a la compañía por la  inexistencia de cobertura u objeciones que presenten las aseguradoras, siendo EL CONTRATISTA quien asumirá el  costo del", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("daño por siniestros que eventualmente sufra o cause con la prestación del servicio aquí pactado.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("En aquellos  casos  en  que  el trabajo se realice en las instalaciones o  sobre bienes  de LA COMPAÑIA, el CONTRATISTA y sus trabajadores observarán todas las", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("reglas en seguridad física, Salud y seguridad en el trabajo (SST), protección al medio ambiente y confidencialidad que LA COMPAÑIA prescriba como necesarias.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("EL CONTRATISTA no pagará comisión u honorarios de ninguna clase, ni concederá rebajas  o favores  a ningún  empleado  de  la COMPAÑIA. Cualquier funcionario", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("autorizado  por la COMPAÑíA   podrá practicar  una  auditoría  de  cualquier  documento   en poder  de  EL CONTRATISTA, siempre que tenga relación con el trabajo", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("ejecutado, con el propósito de investigar la existencia  del  otorgamiento  de  tales  comisiones,  honorarios o rebajas, así como  de corroborar  el cumplimiento  de las", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("obligaciones  derivadas  de  este contrato. Para  el  efecto  EL CONTRATISTA deberá conservar toda la documentación  relacionada con el trabajo ejecutado,  por  un", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("periodo no menor de dos (2) años contados a partir de la terminación del mismo.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("En caso de incumplimiento total o  parcial EL CONTRATISTA se obliga a pagar a favor  de LA COMPAÑIA, a titulo de pena, una suma equivalente al veinte por ciento", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("(20%)  del  valor  total  del  servicio  contratado,  sin  perjuicio  del cobro de  las indemnizaciones  y/o pólizas a que hubiere lugar. El pago de esta pena no exime a EL", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("CONTRATISTA   del cumplimiento  de  sus obligaciones.  EL CONTRATISTA  renuncia  expresamente  a  ser  requerido  para  constituirse  en  mora, basta  el simple", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("incumplimiento.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("EL CONTRATISTA se compromete no ceder o subcontratar este convenio en forma total o parcial, a menos que cuente con la autorización escrita de LA COMPAÑIA.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 15

                e.Graphics.DrawString("Esta orden  de  servicios  terminará  por  su vencimiento, por  el  cumplimiento  del  objeto, o cuando en cualquier momento y a completa discreción LA COMPAÑIA lo", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("estime conveniente, para  lo cual deberá dar aviso escrito a EL CONTRATISTA por lo menos con quince (15) días de anticipación. No obstante, podrá  ser  terminada", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("de inmediato cuando EL CONTRATISTA no cumpla con las obligaciones pactadas, incurra en falsedad,  caiga en insolvencia o cualquier otro acto incompatible con el", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("de servicio a juicio de LA COMPAÑIA. En este  caso LA  COMPAÑíA pagará a EL CONTRATISTA el trabajo que haya ejecutado hasta el momento de la cancelación", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)
                LineaY = LineaY + 10
                e.Graphics.DrawString("o suspensión.", Formato_Etiqueta_7R, Brocha, LineaX, LineaY)

            End If
        End If


        ' e.Graphics.DrawString(FilaOrdeServicio("AÑO"), Formato_Etiqueta_8, Brocha, 100, 100)
        e.Graphics.DrawStringCentered(Trim(FilaOrdeServicio("ABREVIATURABASE")) + " - " + CStr(FilaOrdeServicio("CONSECUTIVO")) + " - " + CStr(FilaOrdeServicio("AÑO")), Formato_Etiqueta_11, Brocha, 180, 515, 68)

        Dim ClConvertir As New FuncionesBase.Cl_Convertir_Num_Letras

        Dim identifi As String

        identifi = ClConvertir.Fun_FormatearCedula(Trim(FilaOrdeServicio("IDENTIFICACION")))


        e.Graphics.DrawString("NIT/CC:  " + identifi, Formato_Etiqueta_6, Brocha, 270, 125)
        e.Graphics.DrawString(FilaOrdeServicio("NOMBRE"), Formato_Etiqueta_7, Brocha, 60, 138)
        Dim fecha As DateTime
        fecha = FilaOrdeServicio("FECHA")
        e.Graphics.DrawString(Trim(FilaOrdeServicio("NOMBREPOBLACION")), Formato_Etiqueta_7, Brocha, 440, 138)
        e.Graphics.DrawString(UCase(fecha), Formato_Etiqueta_7, Brocha, 710, 138)

        e.Graphics.DrawString(FilaOrdeServicio("DIRECCION"), Formato_Etiqueta_7, Brocha, 60, 168)
        e.Graphics.DrawString(Trim(FilaOrdeServicio("ABREVIATURABASE")) + " - " + Trim(FilaOrdeServicio("NOMBREBASE")), Formato_Etiqueta_8, Brocha, 460, 210)

        Dim Cadena_Total_DESCRIPCION As New ArrayList
        Dim ConImpresiónCadenaDESCRIPCION As Integer = 0
        Dim puntoOrigenDESCRIPCION As New Point(50, 265)
        Dim CadenasDESCRIPCION As New ArrayList
        CadenasDESCRIPCION.Add(Trim(FilaOrdeServicio("DESCRIPCION")))
        Cadena_Total_DESCRIPCION = TextoAParrafoFuente(CadenasDESCRIPCION, Formato_Etiqueta_8, 710, e)

        Dim i As Integer
        For i = ConImpresiónCadenaDESCRIPCION To Cadena_Total_DESCRIPCION.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_DESCRIPCION(i), Formato_Etiqueta_8, 710, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8, Brocha, puntoOrigenDESCRIPCION.X, puntoOrigenDESCRIPCION.Y)
            puntoOrigenDESCRIPCION.Y = puntoOrigenDESCRIPCION.Y + 24
        Next

        If OrdenCierre Then
            Select Case FilaOrdeServicio("SIGLAISO")
                Case "COP"
                    e.Graphics.DrawString(UCase(NumerosEnPalabras(FilaOrdeServicio("VALORCIERRE"), "")) + " " + CStr(Trim(FilaOrdeServicio("TIPOMONEDA"))), Formato_Etiqueta_8, Brocha, 80, 393)
                Case "USD"
                    e.Graphics.DrawString(NumeLetrasOtrasMonedasV1(FilaOrdeServicio("VALORCIERRE"), "CON", "DOLARES", 1), Formato_Etiqueta_8, Brocha, 80, 393)
                Case "EUR"
                    e.Graphics.DrawString(NumeLetrasOtrasMonedasV1(FilaOrdeServicio("VALORCIERRE"), "CON", "EUROS", 1), Formato_Etiqueta_8, Brocha, 80, 393)
                Case Else
                    e.Graphics.DrawString(UCase(NumerosEnPalabras(FilaOrdeServicio("VALORCIERRE"), "")) + " " + CStr(Trim(FilaOrdeServicio("TIPOMONEDA"))), Formato_Etiqueta_8, Brocha, 80, 393)
            End Select

            e.Graphics.DrawString(FilaOrdeServicio("SIMBOLO") + " " + Format(FilaOrdeServicio("VALORCIERRE"), "##,##0.00") + " " + FilaOrdeServicio("SIGLAISO"), Formato_Etiqueta_8, Brocha, 420, 550)

        Else
            Select Case FilaOrdeServicio("SIGLAISO")
                Case "COP"
                    e.Graphics.DrawString(UCase(NumerosEnPalabras(FilaOrdeServicio("VALORFACTURA"), "")) + " " + CStr(Trim(FilaOrdeServicio("TIPOMONEDA"))), Formato_Etiqueta_8, Brocha, 80, 393)
                Case "USD"
                    e.Graphics.DrawString(NumeLetrasOtrasMonedasV1(FilaOrdeServicio("VALORFACTURA"), "CON", "DOLARES", 1), Formato_Etiqueta_8, Brocha, 80, 393)
                Case "EUR"
                    e.Graphics.DrawString(NumeLetrasOtrasMonedasV1(FilaOrdeServicio("VALORFACTURA"), "CON", "EUROS", 1), Formato_Etiqueta_8, Brocha, 80, 393)
                Case Else
                    e.Graphics.DrawString(UCase(NumerosEnPalabras(FilaOrdeServicio("VALORFACTURA"), "")) + " " + CStr(Trim(FilaOrdeServicio("TIPOMONEDA"))), Formato_Etiqueta_8, Brocha, 80, 393)
            End Select

            e.Graphics.DrawString(FilaOrdeServicio("SIMBOLO") + " " + Format(FilaOrdeServicio("VALORFACTURA"), "##,##0.00") + " " + FilaOrdeServicio("SIGLAISO"), Formato_Etiqueta_8, Brocha, 530, 510)

        End If

        If FilaOrdeServicio("SOLICITADOPOR").ToString.Count > 30 Then
            e.Graphics.DrawString(FilaOrdeServicio("SOLICITADOPOR"), Formato_Etiqueta_7, Brocha, 60, 510)
        Else
            e.Graphics.DrawString(FilaOrdeServicio("SOLICITADOPOR"), Formato_Etiqueta_8, Brocha, 60, 510)
        End If

        e.Graphics.DrawString(Trim(FilaOrdeServicio("CENTROCOSTO")), Formato_Etiqueta_8, Brocha, 300, 510)

        If OrdenCierre Then
            If IsDBNull(FilaOrdeServicio("FECHARECIBE")) = False Then
                e.Graphics.DrawString(FilaOrdeServicio("FECHARECIBE"), Formato_Etiqueta_8, Brocha, 570, 545)
            End If

            If FilaOrdeServicio("PERSONARECIBE").ToString.Count > 30 Then
                e.Graphics.DrawString(FilaOrdeServicio("PERSONARECIBE"), Formato_Etiqueta_7, Brocha, 565, 555)
            Else
                e.Graphics.DrawString(FilaOrdeServicio("PERSONARECIBE"), Formato_Etiqueta_8, Brocha, 565, 555)
            End If

            e.Graphics.DrawString(FilaOrdeServicio("FACTURA"), Formato_Etiqueta_10, Brocha, 80, 550)

            If IsDBNull(FilaOrdeServicio("FECHAFACTURA")) = False Then
                e.Graphics.DrawString(FilaOrdeServicio("FECHAFACTURA"), Formato_Etiqueta_8, Brocha, 310, 550)
            End If

            Dim Cadena_Total_OBSERVACION As New ArrayList
            Dim ConImpresiónCadenaOBSERVACION As Integer = 0
            Dim puntoOrigenOBSERVACION As New Point(60, 590)
            Dim CadenasOBSERVACION As New ArrayList
            CadenasOBSERVACION.Add(Trim(FilaOrdeServicio("OBSERVACION")))
            Cadena_Total_OBSERVACION = TextoAParrafoFuente(CadenasOBSERVACION, Formato_Etiqueta_7, 700, e)
            Dim j As Integer
            For j = ConImpresiónCadenaOBSERVACION To Cadena_Total_OBSERVACION.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_OBSERVACION(j), Formato_Etiqueta_7, 700, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_7, Brocha, puntoOrigenOBSERVACION.X, puntoOrigenOBSERVACION.Y - 5)
                puntoOrigenOBSERVACION.Y = puntoOrigenOBSERVACION.Y + 10
            Next
        End If

        If Impresion = True Then
            IDRELACIONDOCUMENTO = IdOrdenServicio
            GuardarImpresionRelacion()
        End If
    End Sub

    Private Sub GuardarImpresionRelacion()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure

            Comando.Parameters.AddWithValue("@TIPO", 13)

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
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "71 - SOBRE "
    Dim WithEvents DocImp_SOBRE As New PrintDocument 'Documento a imprimir
    Dim CargarDatasetSOBRE As Boolean = True
    Dim ImpresionSOBRE As Boolean = False
    Dim Dt_SOBRE As DataTable
    Dim FilaSOBRE As DataRow
    Public IdSOBRE As Integer = -1

    Private Sub DocImpSOBRE(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_SOBRE.PrintPage
        If CargarDatasetSOBRE = True Then
            Dim Cadena_Consulta As String
            Cadena_Consulta = "SELECT   * FROM  dbo.ImpresionSobre(" + IdSOBRE.ToString + ") AS ImpresionSobre"

            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_SOBRE = New DataTable
            Adaptador.FillSchema(Dt_SOBRE, SchemaType.Source)
            Adaptador.Fill(Dt_SOBRE)
            Consulta.Connection.Close()
            FilaSOBRE = Dt_SOBRE.Rows(0)
            CargarDatasetOrdeServicio = False

            If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
                LogoEmpresa = 2
            End If

            Select Case LogoEmpresa
                Case 0 'Ismocol
                    e.Graphics.DrawImage(logoIsmocol, 46, 56, 75, 60)
                Case 1 'CSI
                Case 2 'Zamorana
                    e.Graphics.DrawImage(logoZamorana, 46, 56, 75, 60)
            End Select


            e.Graphics.DrawLine(Lapiz, 40, 50, 800, 50) 'Horizontal 1
            e.Graphics.DrawLine(Lapiz, 40, 124, 800, 124) 'Horizontal 2
            e.Graphics.DrawLine(Lapiz, 700, 86, 800, 86) 'Horizontal 3

            e.Graphics.DrawLine(Lapiz, 40, 50, 40, 124)   'Vertical 1
            e.Graphics.DrawLine(Lapiz, 124, 50, 124, 124) 'Vertical 2
            e.Graphics.DrawLine(Lapiz, 700, 50, 700, 124) 'Vertical 3

            e.Graphics.DrawLine(Lapiz, 800, 50, 800, 124) 'Vertical 4
            e.Graphics.DrawString("SOBRE No.", Formato_Etiqueta_12, Brocha, 703, 63)
            e.Graphics.DrawLine(Lapiz, 40, 124, 40, 300) 'V
            e.Graphics.DrawString(FilaSOBRE("AÑO") + " - " + CStr(FilaSOBRE("CONSECUTIVO")), Formato_Etiqueta_12, Brocha, 705, 90)
            e.Graphics.DrawLine(Lapiz, 800, 124, 800, 300) 'V

            'e.Graphics.DrawString(FilaSOBRE("DESCRIPCION"), Formato_Etiqueta_15, Brocha, 130, 55)

            Dim DESCRIPCION As String
            DESCRIPCION = Trim(FilaSOBRE("DESCRIPCION"))
            If DESCRIPCION.Length <= 43 Then
                e.Graphics.DrawString(DESCRIPCION, Formato_Etiqueta_15, Brocha, 145, 55)
            Else

                If DESCRIPCION.Length <= 60 Then
                    Dim Cadenas2 As New ArrayList
                    Cadenas2.Add(Trim(FilaSOBRE("DESCRIPCION")))
                    Dim Cadena_Total2 As New ArrayList
                    Cadena_Total2 = TextoAParrafoFuente(Cadenas2, Formato_Etiqueta_14, 550, e)

                    For k = 0 To Cadena_Total2.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total2(k), Formato_Etiqueta_14, 550, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_14, Brocha, 130, 55 - 3 + (k * 20))
                    Next
                Else
                    Dim Cadenas2 As New ArrayList
                    Cadenas2.Add(Trim(FilaSOBRE("DESCRIPCION")))
                    Dim Cadena_Total2 As New ArrayList
                    Cadena_Total2 = TextoAParrafoFuente(Cadenas2, Formato_Etiqueta_11, 550, e)

                    For k = 0 To Cadena_Total2.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total2(k), Formato_Etiqueta_14, 550, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_11, Brocha, 130, 55 - 3 + (k * 20))
                    Next


                End If


            End If


            e.Graphics.DrawString("FECHA DE ENVÍO: " + Date.Today, Formato_Etiqueta_12, Brocha, 40, 129)
            e.Graphics.DrawLine(Lapiz, 40, 150, 800, 150)

            e.Graphics.DrawString("REMITE: " + FilaSOBRE("De") + ", " + FilaSOBRE("CARGODE"), Formato_Etiqueta_14, Brocha, 40, 155)
            ' e.Graphics.DrawString(FilaSOBRE("De") + ", " + FilaSOBRE("CARGODE"), Formato_Etiqueta_15, Brocha, 120, 130)



            Dim direccion As String = FilaSOBRE("DIRRECION").ToString.Trim
            Select Case direccion.Length
                Case Is < 55
                    e.Graphics.DrawString(direccion, Formato_Etiqueta_15, Brocha, 120, 200)
                    Exit Select
                Case Is <= 60
                    e.Graphics.DrawString(direccion, Formato_Etiqueta_13, Brocha, 120, 200)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(direccion, 1, 60), Formato_Etiqueta_13, Brocha, 120, 200)
                    e.Graphics.DrawString(Mid(direccion, 61, 60), Formato_Etiqueta_13, Brocha, 120, 220)
            End Select

            'e.Graphics.DrawString(FilaSOBRE("DIRRECION"), Formato_Etiqueta_15, Brocha, 120, 180)
            e.Graphics.DrawString(FilaSOBRE("NOMBREPOBLACION"), Formato_Etiqueta_15, Brocha, 120, 260)
            ' e.Graphics.DrawString(FilaSOBRE("De"), Formato_Etiqueta_12, Brocha, 120, 190)

            e.Graphics.DrawLine(Lapiz, 40, 300, 800, 300) 'H

            Select Case LogoEmpresa
                Case 0
                    e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_18, Brocha, 140, 310)
                    e.Graphics.DrawString("NIT.890.209.174-1", Formato_Etiqueta_18, Brocha, 340, 310)
                Case 1

                Case 2
                    e.Graphics.DrawString("ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S.", Formato_Etiqueta_12, Brocha, 140, 300)
                    e.Graphics.DrawString("NIT.900.149.238-1", Formato_Etiqueta_12, Brocha, 340, 320)
            End Select


            e.Graphics.DrawLine(Lapiz, 40, 350, 800, 350) 'H
            e.Graphics.DrawLine(Lapiz, 40, 1000, 800, 1000) 'H

            e.Graphics.DrawLine(Lapiz, 40, 300, 40, 1000) 'V
            e.Graphics.DrawLine(Lapiz, 800, 300, 800, 1000) 'V

            e.Graphics.DrawString("Señor", Formato_Etiqueta_16, Brocha, 120, 380)
            e.Graphics.DrawString(FilaSOBRE("Para"), Formato_Etiqueta_16, Brocha, 120, 420)
            e.Graphics.DrawString(FilaSOBRE("ENTIDAD"), Formato_Etiqueta_16, Brocha, 120, 460)
            ' e.Graphics.DrawString(FilaSOBRE("DIRECCIONPARA"), Formato_Etiqueta_16, Brocha, 120, 500)

            Dim Dirrecion As String
            Dirrecion = Trim(FilaSOBRE("DIRECCIONPARA"))
            If Dirrecion.Length <= 50 Then
                e.Graphics.DrawString(Dirrecion, Formato_Etiqueta_15, Brocha, 120, 490)
            Else
                Dim Cadenas2 As New ArrayList
                Cadenas2.Add(Trim(FilaSOBRE("DIRECCIONPARA")))
                Dim Cadena_Total2 As New ArrayList
                Cadena_Total2 = TextoAParrafoFuente(Cadenas2, Formato_Etiqueta_14, 650, e)
                For k = 0 To Cadena_Total2.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total2(k), Formato_Etiqueta_14, 650, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_14, Brocha, 120, 490 + (k * 18))

                Next

            End If


            e.Graphics.DrawString(FilaSOBRE("NOMBREPOBLACIONPARA"), Formato_Etiqueta_16, Brocha, 120, 540)
            'e.Graphics.DrawString(FilaSOBRE("AÑO"), Formato_Etiqueta_8, Brocha, 60, 138)

            Dim TELEFONO As String = FilaSOBRE("TELEFONO")
            If TELEFONO <> "" Then
                e.Graphics.DrawString("Teléfono: " + TELEFONO, Formato_Etiqueta_16, Brocha, 120, 570)
            End If

            e.Graphics.DrawLine(Lapiz, 80, 750, 750, 750) 'H
            e.Graphics.DrawLine(Lapiz, 80, 860, 750, 860) 'H

            e.Graphics.DrawLine(Lapiz, 80, 750, 80, 860) 'Vce
            e.Graphics.DrawLine(Lapiz, 750, 750, 750, 860) 'V

            e.Graphics.DrawString("Centro de Costos: " + FilaSOBRE("CENTROCOSTO"), Formato_Etiqueta_15, Brocha, 100, 760)
            e.Graphics.DrawString("Empresa Transportadora:", Formato_Etiqueta_15, Brocha, 100, 810)
            e.Graphics.DrawString(Trim(FilaSOBRE("NOMBRE")) + "   " + FilaSOBRE("GUIA"), Formato_Etiqueta_14, Brocha, 100, 830)
        Else
            Impresion = True
        End If
    End Sub

#End Region

#Region "72 - LISTA CORRESPONDENCIA "
    Dim WithEvents DocImp_LISTACORRESPONDENCIA As New PrintDocument 'Documento a imprimir
    Dim CargarDatasetLISTACORRESPONDENCIA As Boolean = True
    Dim ImpresionLISTACORRESPONDENCIA As Boolean = False
    Dim Dt_LISTACORRESPONDENCIA As DataTable
    Dim FilaLISTACORRESPONDENCIA As DataRow
    Public IdLISTACORRESPONDENCIA As Integer = -1
    Public TipoCorrespondencia As String
    Public CorrespondenciaDesde As DateTime
    Public CorrespondenciaHasta As DateTime
    Public Desde As Integer
    Public Hasta As Integer
    Public Cb_Año As String
    Public IDDEPENDENCIA As Integer
    Dim FilasImpresas As Integer = 0
    Dim PaginasImpresas As Integer

    Private Sub DocImpLISTACORRESPONDENCIA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_LISTACORRESPONDENCIA.PrintPage
        If CargarDatasetLISTACORRESPONDENCIA = True Then
            PaginasImpresas = 1
            Dim Cadena_Consulta As String
            Cadena_Consulta = "SELECT * FROM  dbo.InformeCorrespondencia('" + TipoCorrespondencia + "' , " + CStr(Desde) + " , " + CStr(Hasta) + "  , 1 , " + VariablesBase.VariablesBase.IdBaseSiscontrolActual.ToString + " ,  '" + Cb_Año + "') AS InformeCorrespondencia"

            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_LISTACORRESPONDENCIA = New DataTable
            Adaptador.FillSchema(Dt_LISTACORRESPONDENCIA, SchemaType.Source)
            Adaptador.Fill(Dt_LISTACORRESPONDENCIA)
            Consulta.Connection.Close()

            CargarDatasetLISTACORRESPONDENCIA = False
        Else
            Impresion = True
        End If

        Select Case TipoCorrespondencia
            Case "E"
                e.Graphics.DrawString("RELACION CORRESPONDENCIA EXTERNA", Formato_Etiqueta_12, Brocha, 430, 60)
            Case "I"
                e.Graphics.DrawString("RELACION CORRESPONDENCIA INTERNA", Formato_Etiqueta_12, Brocha, 430, 60)
            Case "G"
                e.Graphics.DrawString("RELACION CORRESPONDENCIA GERENCIA", Formato_Etiqueta_12, Brocha, 430, 60)
            Case "F"
                e.Graphics.DrawString("RELACION CORRESPONDENCIA FAX", Formato_Etiqueta_12, Brocha, 430, 60)

        End Select

        e.Graphics.DrawString("FECHA DE INFORME : " + Date.Now.ToShortDateString, Formato_Etiqueta_12, Brocha, 430, 130)



        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, 46, 56, 75, 60)
            Case 1 'CSI
            Case 2 'ZAMORANA
                e.Graphics.DrawImage(logoZamorana, 46, 56, 75, 60)
        End Select



        e.Graphics.DrawLine(Lapiz, 40, 50, 1050, 50) 'Horizontal 1
        e.Graphics.DrawLine(Lapiz, 40, 124, 1050, 124) 'Horizontal 2
        e.Graphics.DrawLine(Lapiz, 40, 160, 1050, 160) 'Horizontal 3
        e.Graphics.DrawLine(Lapiz, 40, 800, 1050, 800) 'Horizontal 4

        e.Graphics.DrawLine(Lapiz, 40, 50, 40, 800)   'Vertical inicial
        e.Graphics.DrawLine(Lapiz, 1050, 50, 1050, 800) 'Vertical final

        For i As Integer = 1 To 31
            e.Graphics.DrawLine(Lapiz, 40, 160 + (i * 20), 1050, 160 + (i * 20)) 'Horizontal 2
        Next

        e.Graphics.DrawLine(Lapiz, 80, 160, 80, 800) ' Consecutivo
        e.Graphics.DrawLine(Lapiz, 150, 160, 150, 800) ' fecha
        e.Graphics.DrawLine(Lapiz, 280, 160, 280, 800) ' empresa
        e.Graphics.DrawLine(Lapiz, 450, 160, 450, 800) ' Dirigido a 
        e.Graphics.DrawLine(Lapiz, 550, 160, 550, 800) ' Ciudad
        e.Graphics.DrawLine(Lapiz, 750, 160, 750, 800) ' Asunto
        e.Graphics.DrawLine(Lapiz, 900, 160, 900, 800) ' Elaborado por  / Firmado

        e.Graphics.DrawString("CONS", Formato_Etiqueta_8, Brocha, 40, 160)
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_8, Brocha, 90, 160)
        e.Graphics.DrawString("EMPRESA", Formato_Etiqueta_8, Brocha, 190, 160)
        e.Graphics.DrawString("DIRIGIDO A:", Formato_Etiqueta_8, Brocha, 340, 160)
        e.Graphics.DrawString("CIUDAD", Formato_Etiqueta_8, Brocha, 480, 160)
        e.Graphics.DrawString("ASUNTO", Formato_Etiqueta_8, Brocha, 610, 160)
        e.Graphics.DrawString("ELABORADO POR:", Formato_Etiqueta_8, Brocha, 760, 160)
        e.Graphics.DrawString("FIRMADO", Formato_Etiqueta_8, Brocha, 930, 160)
        Dim CantidadFilas As Integer = Dt_LISTACORRESPONDENCIA.Rows.Count
        Dim TotalPAginas As Integer
        TotalPAginas = -Int(-CantidadFilas / 31)

        Dim UltimaFila As Integer
        Dim Imprimir As Integer = 0
        While Imprimir <= 30
            FilaLISTACORRESPONDENCIA = Dt_LISTACORRESPONDENCIA.Rows(FilasImpresas)
            Dim Salto As Integer
            Salto = 181 + (20 * Imprimir)
            e.Graphics.DrawString(FilaLISTACORRESPONDENCIA("Consecutivo"), Formato_Etiqueta_6, Brocha, 45, Salto)
            e.Graphics.DrawString(CDate(FilaLISTACORRESPONDENCIA("Fecha")).ToShortDateString.ToString, Formato_Etiqueta_6, Brocha, 85, Salto)

            Dim Empresa As String
            Empresa = FilaLISTACORRESPONDENCIA("Empresa")

            If Empresa.Length <= 29 Then
                e.Graphics.DrawString(Empresa, Formato_Etiqueta_5R, Brocha, 151, Salto)
            Else
                e.Graphics.DrawString(Mid(Empresa, 1, 29), Formato_Etiqueta_5R, Brocha, 151, Salto)
                e.Graphics.DrawString(Mid(Empresa, 30, 59).ToString, Formato_Etiqueta_5R, Brocha, 151, Salto + 10)
            End If

            Dim Dirigido As String
            Dirigido = FilaLISTACORRESPONDENCIA("Dirigido")

            If Dirigido.Length <= 36 Then
                e.Graphics.DrawString(Dirigido, Formato_Etiqueta_5R, Brocha, 285, Salto)
            Else
                e.Graphics.DrawString(Mid(Dirigido, 1, 36), Formato_Etiqueta_5R, Brocha, 285, Salto)
                e.Graphics.DrawString(Mid(Dirigido, 37, 72).ToString, Formato_Etiqueta_5R, Brocha, 285, Salto + 10)
            End If

            ' e.Graphics.DrawString(FilaLISTACORRESPONDENCIA("Dirigido"), Formato_Etiqueta_5R, Brocha, 285, Salto)
            e.Graphics.DrawString(FilaLISTACORRESPONDENCIA("Ciudad"), Formato_Etiqueta_5R, Brocha, 450, Salto)

            Dim Asunto As String
            Asunto = Trim(FilaLISTACORRESPONDENCIA("Asunto"))

            If Asunto.Length <= 36 Then
                e.Graphics.DrawString(Asunto, Formato_Etiqueta_5R, Brocha, 550, Salto)
            Else
                e.Graphics.DrawString(Mid(Asunto, 1, 36), Formato_Etiqueta_5R, Brocha, 550, Salto)
                e.Graphics.DrawString(Mid(Asunto, 37, 70).ToString, Formato_Etiqueta_5R, Brocha, 550, Salto + 10)
            End If

            e.Graphics.DrawString(FilaLISTACORRESPONDENCIA("Elaborado"), Formato_Etiqueta_5R, Brocha, 750, Salto)
            e.Graphics.DrawString(FilaLISTACORRESPONDENCIA("Firmado"), Formato_Etiqueta_5R, Brocha, 900, Salto)
            UltimaFila = Salto
            FilasImpresas = FilasImpresas + 1
            Imprimir = Imprimir + 1

            If CantidadFilas = FilasImpresas Then
                Exit While
            End If
        End While

        If CantidadFilas = FilasImpresas Then
            If FilasImpresas Mod 31 = 0 And FilasImpresas <> 0 Then
            Else
                e.Graphics.DrawString("|-------------------------------------------------| Ultima Fila |-------------------------------------------------|", Formato_Etiqueta_8, Brocha, 300, UltimaFila + 20)
            End If
            FilasImpresas = 0
            e.HasMorePages = False
            e.Graphics.DrawString("Pagina " + CStr(PaginasImpresas) + " de " + CStr(TotalPAginas), Formato_Etiqueta_7, Brocha, 500, 805)
            PaginasImpresas = 1
        Else
            e.HasMorePages = True
            e.Graphics.DrawString("Pagina " + CStr(PaginasImpresas) + " de " + CStr(TotalPAginas), Formato_Etiqueta_7, Brocha, 500, 805)
            PaginasImpresas = PaginasImpresas + 1
        End If
    End Sub
#End Region

#Region "73 - LISTA RECEPCION "
    Private WithEvents DocImp_LISTARECEPCION As New PrintDocument 'Documento a imprimir
    Public IdLISTALISTARECEPCION As Integer = -1
    Public ListaFecha As Boolean
    Const AlturaFilasRecepcion As Integer = 10
    Const maxEspacioFilasRecepcion As Integer = 300
    Private cargarListaRecepcion As Boolean = True
    Private dtListaRecepcion As DataTable
    Private filaListaRecepcion As DataRow
    Private itemsImpresosRecepcion As Integer = 0
    Private vistaPreviaListaRecepcion As Boolean = True
    Private paginasImpresasRecepcion As UInteger
    Private totalPaginasRecepcion As UInteger = 0

    Const textoPieDePagina As String = "FAVOR DEVOLVER CON FIRMA Y FECHA DE RECIBIDO A RECEPCIÓN"
    Private nroRelacion As Integer
    Private tituloListaRecepcion As String = ""
    Private RelacionRecepcion As String = ""
    Private fechaListaRecepcion As String = ""
    Private margenIzquierdaRecepcion As Integer = 20
    Private margenDerechaRecepcion As Integer = 800
    Private anchoDocumentoRecepcion As Integer = margenDerechaRecepcion - margenIzquierdaRecepcion


    Private Sub DocImpLISTALISTARECEPCION(sender As Object, e As PrintPageEventArgs) Handles DocImp_LISTARECEPCION.PrintPage
        If cargarListaRecepcion Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim cadenaConsulta As String = ""
            cadenaConsulta = "SELECT * FROM dbo.SC_ImpresionListadoRecepcion(@FECHADESDE, @FECHAHASTA, @DEPENDENCIA, @IDBASESISCONTROL)"
            Dim comando As New SqlCommand(cadenaConsulta, conexion)
            comando.Parameters.AddWithValue("@FECHADESDE", CorrespondenciaDesde)
            comando.Parameters.AddWithValue("@FECHAHASTA", CorrespondenciaHasta)
            comando.Parameters.AddWithValue("@DEPENDENCIA", IDDEPENDENCIA)
            comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim Adaptador As New SqlDataAdapter(comando)
            dtListaRecepcion = New DataTable()
            Try
                conexion.Open()
                Adaptador.Fill(dtListaRecepcion)
                conexion.Close()
                cargarListaRecepcion = False
                nroRelacion = dtListaRecepcion.Rows(0).Item("NORELACION") + 1
                tituloListaRecepcion = "RELACIÓN CORRESPONDENCIA DEPARTAMENTO " & dtListaRecepcion.Rows(0).Item("NOMBREDEPENDENCIA")
                RelacionRecepcion = "NRO. RELACIÓN: " & nroRelacion
                fechaListaRecepcion = "FECHA DE INFORME: " & Date.Now.ToShortDateString
            Catch ex As Exception
                Exit Sub
            Finally
                conexion.Close()
            End Try
        Else
            Impresion = True
        End If


        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If

        Dim colListaRecep_NumFila As New Cl_ColumnaImpresión(20, 20)
        Dim colListaRecep_Para As New Cl_ColumnaImpresión(160, colListaRecep_NumFila)
        Dim colListaRecep_De As New Cl_ColumnaImpresión(160, colListaRecep_Para)
        Dim colListaRecep_Memorando As New Cl_ColumnaImpresión(100, colListaRecep_De)
        Dim colListaRecep_NumDocumento As New Cl_ColumnaImpresión(100, colListaRecep_Memorando)
        Dim colListaRecep_Tipo As New Cl_ColumnaImpresión(80, colListaRecep_NumDocumento)
        Dim colListaRecep_Observacion As New Cl_ColumnaImpresión(160, colListaRecep_Tipo)

        'ImprimirRejilla(e, Color.LightGray, 3, 0.5, 10)

        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaRecepcion, 40, anchoDocumentoRecepcion, 440) 'Borde

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, 45, 50, 75, 60)
            Case 1 'CSI
            Case 2 'Zamorana
                e.Graphics.DrawImage(logoZamorana, 25, 60, 110, 40)
        End Select
        e.Graphics.DrawLine(Lapiz, 140, 40, 140, 120) 'Vertical "Logo"

        e.Graphics.DrawString(tituloListaRecepcion, Formato_Etiqueta_12, Brocha, 140 + InicioCentradoTexto(tituloListaRecepcion, Formato_Etiqueta_12, 680, e), 60)
        e.Graphics.DrawString(RelacionRecepcion, Formato_Etiqueta_12, Brocha, 140 + InicioCentradoTexto(RelacionRecepcion, Formato_Etiqueta_12, 680, e), 80)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaRecepcion, 120, margenDerechaRecepcion, 120) 'Horizontal "Título"

        e.Graphics.DrawString(fechaListaRecepcion, Formato_Etiqueta_10, Brocha, margenIzquierdaRecepcion + InicioCentradoTexto(fechaListaRecepcion, Formato_Etiqueta_10, anchoDocumentoRecepcion, e), 122)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaRecepcion, 140, margenDerechaRecepcion, 140) 'Horizontal "Fecha"

        e.Graphics.DrawString("PARA", Formato_Etiqueta_8, Brocha, colListaRecep_Para.Izquierda + InicioCentradoTexto("PARA", Formato_Etiqueta_8, colListaRecep_Para.Ancho, e), 144)
        e.Graphics.DrawString("DE", Formato_Etiqueta_8, Brocha, colListaRecep_De.Izquierda + InicioCentradoTexto("DE", Formato_Etiqueta_8, colListaRecep_De.Ancho, e), 144)
        e.Graphics.DrawString("MEMORANDO", Formato_Etiqueta_8, Brocha, colListaRecep_Memorando.Izquierda + InicioCentradoTexto("MEMORANDO", Formato_Etiqueta_8, colListaRecep_Memorando.Ancho, e), 144)
        e.Graphics.DrawString("NUM. DOC.", Formato_Etiqueta_8, Brocha, colListaRecep_NumDocumento.Izquierda + InicioCentradoTexto("NUM. DOC", Formato_Etiqueta_8, colListaRecep_NumDocumento.Ancho, e), 144)
        e.Graphics.DrawString("TIPO", Formato_Etiqueta_8, Brocha, colListaRecep_Tipo.Izquierda + InicioCentradoTexto("TIPO", Formato_Etiqueta_8, colListaRecep_Tipo.Ancho, e), 144)
        e.Graphics.DrawString("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, colListaRecep_Observacion.Izquierda + InicioCentradoTexto("OBSERVACIÓN", Formato_Etiqueta_8, colListaRecep_Observacion.Ancho, e), 144)
        e.Graphics.DrawLine(Lapiz, colListaRecep_NumFila.Derecha, 140, colListaRecep_NumFila.Derecha, 460) 'Vertical [#fila]
        e.Graphics.DrawLine(Lapiz, colListaRecep_Para.Derecha, 140, colListaRecep_Para.Derecha, 460) 'Vertical "Para"
        e.Graphics.DrawLine(Lapiz, colListaRecep_De.Derecha, 140, colListaRecep_De.Derecha, 460) 'Vertical "De"
        e.Graphics.DrawLine(Lapiz, colListaRecep_Memorando.Derecha, 140, colListaRecep_Memorando.Derecha, 460) 'Vertical "Memorando"
        e.Graphics.DrawLine(Lapiz, colListaRecep_Tipo.Derecha, 140, colListaRecep_Tipo.Derecha, 460) 'Vertical "Tipo"
        e.Graphics.DrawLine(Lapiz, colListaRecep_NumDocumento.Derecha, 140, colListaRecep_NumDocumento.Derecha, 460) 'Vertical "Num. Doc."
        e.Graphics.DrawLine(Lapiz, margenIzquierdaRecepcion, 160, margenDerechaRecepcion, 160) 'Horizontal encabezado

        Dim espacioImpresoHoja As Integer = 0
        Dim cadenaPara As String = ""
        Dim alturaPara As UInteger = 0
        Dim cadenaDe As String = ""
        Dim alturaDe As UInteger = 0
        Dim cadenaTipo As String = ""
        Dim alturaTipo As UInteger = 0
        Dim cadenaObservacion As String = ""
        Dim alturaObservacion As UInteger = 0
        Dim posicionFilaRecepcion As Integer = 160
        Dim cantidadFilasActual As Integer = 0

        For i = itemsImpresosRecepcion To dtListaRecepcion.Rows.Count - 1
            filaListaRecepcion = dtListaRecepcion.Rows(itemsImpresosRecepcion)
            cantidadFilasActual = 0

            cadenaPara = Trim(filaListaRecepcion("Para"))
            alturaPara = e.Graphics.MeasureString(cadenaPara, Formato_Etiqueta_6R, colListaRecep_Para.Ancho).Height \ AlturaFilasRecepcion

            cadenaDe = Trim(filaListaRecepcion("De"))
            alturaDe = e.Graphics.MeasureString(cadenaDe, Formato_Etiqueta_6R, colListaRecep_De.Ancho).Height \ AlturaFilasRecepcion

            cadenaTipo = Trim(filaListaRecepcion("Tipo Documento"))
            alturaTipo = e.Graphics.MeasureString(cadenaTipo, Formato_Etiqueta_6R, colListaRecep_Tipo.Ancho).Height \ AlturaFilasRecepcion

            cadenaObservacion = Trim(filaListaRecepcion("Descripción"))
            alturaObservacion = e.Graphics.MeasureString(cadenaObservacion, Formato_Etiqueta_6R, colListaRecep_Observacion.Ancho).Height \ AlturaFilasRecepcion

            cantidadFilasActual = MaxOfValues(alturaPara, alturaDe, alturaTipo, alturaObservacion)

            If espacioImpresoHoja + (cantidadFilasActual * AlturaFilasRecepcion) < maxEspacioFilasRecepcion Then 'Si la fila cabe en la hoja actual
                'Número de fila
                e.Graphics.DrawString(CStr(itemsImpresosRecepcion + 1), Formato_Etiqueta_6R, Brocha, colListaRecep_NumFila.Izquierda + InicioCentradoTexto(CStr(itemsImpresosRecepcion + 1), Formato_Etiqueta_6R, colListaRecep_NumFila.Ancho, e), posicionFilaRecepcion + 1)

                'Para
                e.Graphics.DrawString(cadenaPara, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_Para.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_Para.Ancho, alturaPara * AlturaFilasRecepcion))

                'De
                e.Graphics.DrawString(cadenaDe, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_De.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_De.Ancho, alturaDe * AlturaFilasRecepcion))

                'Memorando
                e.Graphics.DrawString(filaListaRecepcion("Memo"), Formato_Etiqueta_6R, Brocha, colListaRecep_Memorando.Izquierda + 2, posicionFilaRecepcion + 1)

                'Número Documento
                e.Graphics.DrawStringRight(filaListaRecepcion("Numero Documento"), Formato_Etiqueta_6R, Brocha, colListaRecep_NumDocumento.Derecha - 2, posicionFilaRecepcion + 1)

                'Tipo
                e.Graphics.DrawString(cadenaTipo, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_Tipo.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_Tipo.Ancho, alturaTipo * AlturaFilasRecepcion))

                'Observación
                e.Graphics.DrawString(cadenaObservacion, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_Observacion.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_Observacion.Ancho, alturaObservacion * AlturaFilasRecepcion))

                If espacioImpresoHoja + (cantidadFilasActual * AlturaFilasRecepcion) < maxEspacioFilasRecepcion - AlturaFilasRecepcion Then 'Si hay espacio para una línea de texto más.
                    e.Graphics.DrawLine(lineaPunteada, margenIzquierdaRecepcion, posicionFilaRecepcion + (cantidadFilasActual * AlturaFilasRecepcion), margenDerechaRecepcion, posicionFilaRecepcion + (cantidadFilasActual * AlturaFilasRecepcion)) 'Horizontal Renglones abajo
                End If

                If (espacioImpresoHoja + (cantidadFilasActual * AlturaFilasRecepcion) = maxEspacioFilasRecepcion - AlturaFilasRecepcion) AndAlso itemsImpresosRecepcion < dtListaRecepcion.Rows.Count Then 'Si pasa a la siguiente hoja.
                    e.Graphics.DrawString("-- Pasa a la siguiente página --", Formato_Etiqueta_6, Brocha, margenIzquierdaRecepcion + InicioCentradoTexto("-- Pasa a la siguiente página --", Formato_Etiqueta_6, anchoDocumentoRecepcion, e), posicionFilaRecepcion + (cantidadFilasActual * AlturaFilasRecepcion))
                End If

                itemsImpresosRecepcion += 1
                espacioImpresoHoja += cantidadFilasActual * AlturaFilasRecepcion
                posicionFilaRecepcion += cantidadFilasActual * AlturaFilasRecepcion
            Else
                Exit For
            End If
        Next

        e.Graphics.DrawLine(Lapiz, margenIzquierdaRecepcion, 460, margenDerechaRecepcion, 460) ' Horizontal Pie de Página
        e.Graphics.DrawString(textoPieDePagina, Formato_Etiqueta_8R, Brocha, margenIzquierdaRecepcion + InicioCentradoTexto(textoPieDePagina, Formato_Etiqueta_8R, anchoDocumentoRecepcion, e), 464)

        paginasImpresasRecepcion += 1

        Dim textoPaginado As String = "Página " & paginasImpresasRecepcion
        If Not vistaPreviaListaRecepcion Then
            textoPaginado += " de " & totalPaginasRecepcion
        End If
        e.Graphics.DrawString(textoPaginado, Formato_Etiqueta_6R, Brocha, InicioCentradoTexto(textoPaginado, Formato_Etiqueta_6R, margenDerechaRecepcion, e), 484)

        If itemsImpresosRecepcion >= dtListaRecepcion.Rows.Count Then
            If espacioImpresoHoja + AlturaFilasRecepcion <= maxEspacioFilasRecepcion Then
                e.Graphics.DrawString("--- Última fila ---", Formato_Etiqueta_6, Brocha, margenIzquierdaRecepcion + InicioCentradoTexto("--- Última fila ---", Formato_Etiqueta_6, anchoDocumentoRecepcion, e), posicionFilaRecepcion + 2)
            End If
            itemsImpresosRecepcion = 0
            e.HasMorePages = False
            If Not vistaPreviaListaRecepcion Then
                GuardarImpresoRecepcion()
            Else
                totalPaginasRecepcion = paginasImpresasRecepcion
                paginasImpresasRecepcion = 0
                vistaPreviaListaRecepcion = False
            End If
        Else
            e.HasMorePages = True
        End If
    End Sub


    Private Sub GuardarImpresoRecepcion()
        Dim Dt_OrdenServicio As DataTable
        Dim Cadena_Consulta_Update As String = ""
        Dim IDCORRES As String = ""
        Dim Fila As Integer
        Fila = dtListaRecepcion.Rows.Count
        For i As Integer = 0 To Fila - 1
            filaListaRecepcion = dtListaRecepcion.Rows(i)
            IDCORRES = filaListaRecepcion("IDRECEPCION")
            Cadena_Consulta_Update = "UPDATE SC_RECEPCION SET IMPRESA = 'S', NUMERORELACION = " & nroRelacion & " WHERE IDRECEPCION IN (" & IDCORRES & ")"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
        Next
    End Sub

#End Region

#Region "74 - BOLETA DE SALIDA "
    Dim WithEvents DocImp_BOLETASALIDA As New PrintDocument 'Documento a imprimir
    Dim CargarDatasetBOLETASALIDA As Boolean = True
    Dim ImpresionBOLETASALIDA As Boolean = False
    Dim Dt_BOLETASALIDA As DataTable
    Dim FilaBOLETASALIDA As DataRow
    Public IdBOLETASALIDA As Integer = -1

    Private Sub DocImpBOLETASALIDA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_BOLETASALIDA.PrintPage
        If CargarDatasetBOLETASALIDA = True Then
            Dim Cadena_Consulta As String
            Cadena_Consulta = "SELECT   * FROM  dbo.ImpresionBoletaSalida(" + IdBOLETASALIDA.ToString + ") AS ImpresionBoletaSalida"

            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_BOLETASALIDA = New DataTable
            Adaptador.FillSchema(Dt_BOLETASALIDA, SchemaType.Source)
            Adaptador.Fill(Dt_BOLETASALIDA)
            Consulta.Connection.Close()
            FilaBOLETASALIDA = Dt_BOLETASALIDA.Rows(0)
            CargarDatasetBOLETASALIDA = False
        Else
            Impresion = True
        End If

        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, 46, 56, 95, 80)
            Case 1 'CSI
            Case 2 'Zamorana
                e.Graphics.DrawImage(logoZamorana, 46, 56, 95, 80)
        End Select

        e.Graphics.DrawRectangle(Lapiz, 40, 50, 760, 950)

        e.Graphics.DrawLine(Lapiz, 150, 50, 150, 150)
        e.Graphics.DrawLine(Lapiz, 650, 100, 800, 100)
        e.Graphics.DrawLine(Lapiz, 650, 50, 650, 150)


        e.Graphics.DrawString("BOLETA DE SALIDA", Formato_Etiqueta_14, Brocha, 315, 90)

        Select Case LogoEmpresa
            Case 0 'Ismocol S.A.
                e.Graphics.DrawString("ICA-GRAL-F-130", Formato_Etiqueta_9, Brocha, 680, 75)
                e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_9, Brocha, 680, 120)
            Case 1
            Case 2 'ZAMORANA

        End Select

        e.Graphics.DrawLine(Lapiz, 40, 150, 800, 150)

        e.Graphics.DrawString("Nombre Trabajador:", Formato_Etiqueta_10R, Brocha, 70, 180)
        e.Graphics.DrawString("Firma del Trabajador:", Formato_Etiqueta_10R, Brocha, 70, 250)
        e.Graphics.DrawLine(Lapiz, 220, 260, 750, 260)

        e.Graphics.DrawString("Fecha", Formato_Etiqueta_10R, Brocha, 70, 320)
        e.Graphics.DrawString("Dependencia:", Formato_Etiqueta_10R, Brocha, 400, 320)

        e.Graphics.DrawString("Hora Salida:", Formato_Etiqueta_10R, Brocha, 70, 390)
        e.Graphics.DrawString("Hora de Llegada:", Formato_Etiqueta_10R, Brocha, 400, 390)

        e.Graphics.DrawString("Tipo de diligencia:", Formato_Etiqueta_10R, Brocha, 70, 460)
        e.Graphics.DrawString("Descripción diligencia:", Formato_Etiqueta_10R, Brocha, 70, 530)
        'e.Graphics.DrawString("______________________________________________________________________________________", Formato_Etiqueta_10R, Brocha, 70, 600)
        e.Graphics.DrawString("Autorización Jefe del Departamento:", Formato_Etiqueta_10R, Brocha, 70, 670)
        e.Graphics.DrawString("Autorización Jefe Dpto. Administrativo:", Formato_Etiqueta_10R, Brocha, 70, 740)
        e.Graphics.DrawLine(Lapiz, 310, 685, 750, 685)
        e.Graphics.DrawLine(Lapiz, 310, 755, 750, 755)
        e.Graphics.DrawString("Firma Vigilante a la Salida ____________________________________________ Hora:________________", Formato_Etiqueta_10R, Brocha, 70, 810)
        e.Graphics.DrawString("Firma Vigilante a la Entrada ___________________________________________ Hora:________________", Formato_Etiqueta_10R, Brocha, 70, 880)

        e.Graphics.DrawString("Nota:  En  una  diligencia  personal,  se  entiende  que  el  trabajador  NO  está  cumpliendo", Formato_Etiqueta_12R, Brocha, 70, 950)
        e.Graphics.DrawString("órdenes  del   empleador  y  en  caso de   cualquier   accidente  éste   NO   se  considerará", Formato_Etiqueta_12R, Brocha, 70, 965)
        e.Graphics.DrawString("Accidente   de   Trabajo. ", Formato_Etiqueta_12R, Brocha, 70, 980)

        e.Graphics.DrawString(Trim(FilaBOLETASALIDA("ABREVIATURABASE")) + "-" + FilaBOLETASALIDA("AÑO") + "-" + FilaBOLETASALIDA("CONSECUTIVO").ToString, Formato_Etiqueta_12, Brocha, 355, 110)

        e.Graphics.DrawString(FilaBOLETASALIDA("PERSONASOLICITA"), Formato_Etiqueta_12, Brocha, 200, 180)
        e.Graphics.DrawString(FilaBOLETASALIDA("FECHA"), Formato_Etiqueta_12, Brocha, 120, 320)
        e.Graphics.DrawString(FilaBOLETASALIDA("NOMBREDEPENDENCIA"), Formato_Etiqueta_12, Brocha, 530, 320)




        If FilaBOLETASALIDA("HORASALIDA") <> "1900-01-01 00:00:00.000" Then

            Dim horasalida As Date = FilaBOLETASALIDA("HORASALIDA")
            If horasalida.Hour > 12 Then
                e.Graphics.DrawString(Format(FilaBOLETASALIDA("HORASALIDA"), "hh:mm:ss tt") + " pm", Formato_Etiqueta_12, Brocha, 200, 390)
            Else
                e.Graphics.DrawString(Format(FilaBOLETASALIDA("HORASALIDA"), "hh:mm:ss tt") + " am", Formato_Etiqueta_12, Brocha, 200, 390)
            End If


        End If


        If FilaBOLETASALIDA("HORAENTRADA") <> "1900-01-01 00:00:00.000" Then
            Dim horallegada As Date = FilaBOLETASALIDA("HORAENTRADA")

            If horallegada.Hour > 12 Then
                e.Graphics.DrawString(Format(FilaBOLETASALIDA("HORAENTRADA"), "hh:mm:ss tt") + " pm", Formato_Etiqueta_12, Brocha, 530, 390)
            Else
                e.Graphics.DrawString(Format(FilaBOLETASALIDA("HORAENTRADA"), "hh:mm:ss tt") + " am", Formato_Etiqueta_12, Brocha, 530, 390)
            End If

        End If

        If FilaBOLETASALIDA("TIPODILIGENCIA") = "L" Then
            e.Graphics.DrawString(("LABORAL"), Formato_Etiqueta_12, Brocha, 200, 460)
        Else
            e.Graphics.DrawString(("PERSONAL"), Formato_Etiqueta_12, Brocha, 200, 460)
        End If

        Dim TextoDesc As String = FilaBOLETASALIDA("DESCRIPCION")

        If TextoDesc.Length < 50 Then
            e.Graphics.DrawString(Mid(TextoDesc, 1, 50), Formato_Etiqueta_12, Brocha, 210, 530)
        Else
            e.Graphics.DrawString(Mid(TextoDesc, 1, 50), Formato_Etiqueta_12, Brocha, 210, 530)
            e.Graphics.DrawString(Mid(TextoDesc, 51, 150), Formato_Etiqueta_12, Brocha, 70, 600)
        End If
        e.Graphics.DrawString(FilaBOLETASALIDA("PERSONAJEFEDEPARTAMENTO"), Formato_Etiqueta_8R, Brocha, 450, 690)
        e.Graphics.DrawString(FilaBOLETASALIDA("PERSONAJEFEADMINISTRATIVO"), Formato_Etiqueta_8R, Brocha, 450, 760)




    End Sub

#End Region

#Region "75 - FORMULARIO POLÍTICA PARA TRATAMIENTO DE DATOS PERSONALES "
    Dim WithEvents DocImp_POLITICADATOSPERSONALES As New PrintDocument

    Private Sub DocImpPOLITICADATOSPERSONALES(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_POLITICADATOSPERSONALES.PrintPage
        Try
            Dim ComandoDatos As New SqlClient.SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)")
            ComandoDatos.Parameters.AddWithValue("@ACCION", 1)
            ComandoDatos.Parameters.AddWithValue("@VARIABLE", idVisitante)
            ComandoDatos.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Dim dt_Visitante As New DataTable
            ComandoDatos.Connection = Conexion
            Dim Adaptador As New SqlClient.SqlDataAdapter(ComandoDatos)
            ComandoDatos.Connection.Open()
            Adaptador.FillSchema(dt_Visitante, SchemaType.Source)
            Adaptador.Fill(dt_Visitante)
            ComandoDatos.Connection.Close()
            FilaDatosVISITANTE = dt_Visitante.Rows(0)
        Catch ex As Exception

        End Try

        Dim MargenDerecha = e.PageBounds.Right - 110
        Dim MargenInferior = e.PageBounds.Bottom - 100
        Dim MargenIzquierda = e.PageBounds.Left + 40
        Dim MargenSuperior = e.PageBounds.Top + 40

        Dim PosYSeccion As Integer = MargenSuperior

        'Borde de página
        DrawRoundedRectangle(e.Graphics, MargenIzquierda - 20, MargenSuperior - 20, MargenDerecha + 20, MargenInferior + 20, 16)

        'Logo

        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, MargenIzquierda - 10, MargenSuperior - 10, 100, 80)
            Case 1 'CSI
            Case 2 'Zamorana
                e.Graphics.DrawImage(logoZamorana, MargenIzquierda - 10, MargenSuperior - 10, 100, 80)
        End Select



        e.Graphics.DrawLine(Lapiz, 140, MargenSuperior - 20, 140, 120) 'Vertical
        e.Graphics.DrawString("REGISTRO DE VISITANTES", Formato_Etiqueta_14, Brocha, InicioCentradoTexto("REGISTRO DE VISITANTES", Formato_Etiqueta_16, 640, e) + 160, PosYSeccion)
        e.Graphics.DrawString("POLÍTICA PARA EL TRATAMIENTO DE DATOS PERSONALES", Formato_Etiqueta_14, Brocha, InicioCentradoTexto("POLÍTICA PARA EL TRATAMIENTO DE DATOS PERSONALES", Formato_Etiqueta_14, 640, e) + 145, PosYSeccion + 40)
        e.Graphics.DrawLine(Lapiz, MargenIzquierda - 20, 120, MargenDerecha + 40, 120) 'Horizontal

        PosYSeccion = 160
        e.Graphics.DrawRectangle(Lapiz, MargenDerecha - 140, PosYSeccion, 160, 120)
        Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(2, idVisitante)
        If Not IsNothing(foto) Then
            e.Graphics.DrawImage(foto, MargenDerecha - 140, PosYSeccion, 160, 120)
        Else
            e.Graphics.DrawStringCentered("Espacio para la foto", Formato_Etiqueta_7R, Brocha, 160, MargenDerecha - 140, PosYSeccion + 60)
        End If
        e.Graphics.DrawString("Id. visita: " + FilaDatosVISITANTE("Año") + "-" + FilaDatosVISITANTE("Consecutivo").ToString(), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion)
        e.Graphics.DrawString("Nombre del visitante: " + StrConv(FilaDatosVISITANTE("Nombre"), VbStrConv.ProperCase), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 40)
        e.Graphics.DrawString("Identificación: " + ClConvertir.Fun_FormatearCedula(RTrim(FilaDatosVISITANTE("Cedula"))), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 80)
        e.Graphics.DrawString("Empresa: " + FilaDatosVISITANTE("Empresa"), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 120)
        e.Graphics.DrawString("E.P.S.: " + FilaDatosVISITANTE("EPS"), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 160)
        e.Graphics.DrawString("Dependencia: " + StrConv(FilaDatosVISITANTE("Dependencia"), VbStrConv.ProperCase), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 200)
        e.Graphics.DrawString("Funcionario: " + StrConv(FilaDatosVISITANTE("Funcionario"), VbStrConv.ProperCase), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 240)
        e.Graphics.DrawString("Fecha y hora de visita: " + Convert.ToDateTime(FilaDatosVISITANTE("Fecha")).ToString("dd/MM/yyyy',' hh:mm tt"), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 280)

        PosYSeccion = 500
        Dim TextoAceptaPolDatos As New ArrayList
        Dim AnchoTextoPolDatos As Integer = 680
        Dim FuenteTextoPolDatos As Font = Formato_Etiqueta_13

        Select Case LogoEmpresa
            Case 0
                With TextoAceptaPolDatos
                    .Add("Manifiesto que conozco y acepto la política que tiene establecida ISMOCOL S.A. para el tratamiento de datos personales, " & _
                    "así como también los derechos que tengo como titular de la información, cuales son los datos que me serán solicitados, " & _
                    "el tratamiento y finalidad a la cual son sometidos mis datos personales en cada una de sus bases de datos, " & _
                    "la facultad que tengo de responder o no a los datos sensibles que me sean solicitados y la identificación plena del responsable del " & _
                    "tratamiento de mi información personal.")
                    .Add(Environment.NewLine)
                    .Add("Como consecuencia de lo anterior, AUTORIZO a ISMOCOL S.A. para que realice el tratamiento de mis datos personales de conformidad con " & _
                    "la Política de Tratamiento de Datos Personales, la cual nuevamente declaro conocer.")
                End With
            Case 1
            Case 2
                With TextoAceptaPolDatos
                    .Add("Manifiesto que conozco y acepto la política que tiene establecida ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S. para el tratamiento de datos personales, " & _
                    "así como también los derechos que tengo como titular de la información, cuales son los datos que me serán solicitados, " & _
                    "el tratamiento y finalidad a la cual son sometidos mis datos personales en cada una de sus bases de datos, " & _
                    "la facultad que tengo de responder o no a los datos sensibles que me sean solicitados y la identificación plena del responsable del " & _
                    "tratamiento de mi información personal.")
                    .Add(Environment.NewLine)
                    .Add("Como consecuencia de lo anterior, AUTORIZO a ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S. para que realice el tratamiento de mis datos personales de conformidad con " & _
                    "la Política de Tratamiento de Datos Personales, la cual nuevamente declaro conocer.")
                End With
        End Select


        TextoAceptaPolDatos = TextoAParrafoFuente(TextoAceptaPolDatos, FuenteTextoPolDatos, AnchoTextoPolDatos, e, False)
        For i As Integer = 0 To TextoAceptaPolDatos.Count - 1
            Dim texto As String = SubParrafo1(TextoAceptaPolDatos(i), FuenteTextoPolDatos, AnchoTextoPolDatos, e)
            e.Graphics.DrawString(texto, FuenteTextoPolDatos, Brocha, MargenIzquierda + 20, PosYSeccion + (i * 20))
        Next

        PosYSeccion = 800
        e.Graphics.DrawRectangle(Lapiz, MargenIzquierda, PosYSeccion, 20, 20)
        Select Case LogoEmpresa
            Case 0
                e.Graphics.DrawString("He leído y ACEPTO la Política de Seguridad y Privacidad de Datos Personales de ISMOCOL S.A.", Formato_Etiqueta_10R, Brocha, MargenIzquierda + 30, PosYSeccion)
            Case 1
            Case 2
                e.Graphics.DrawString("He leído y ACEPTO la Política de Seguridad y Privacidad de Datos Personales de ZAMORANA", Formato_Etiqueta_10R, Brocha, MargenIzquierda + 30, PosYSeccion)
        End Select
        e.Graphics.DrawRectangle(Lapiz, MargenIzquierda, PosYSeccion + 40, 20, 20)
        e.Graphics.DrawString("He visto el video de seguridad del edificio.", Formato_Etiqueta_10R, Brocha, MargenIzquierda + 30, PosYSeccion + 40)

        PosYSeccion = 900
        e.Graphics.DrawString("Firma: ", Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion)
        e.Graphics.DrawLine(Lapiz, 110, PosYSeccion + 20, 340, PosYSeccion + 20)
        e.Graphics.DrawString("Identificación: ", Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 40)
        e.Graphics.DrawLine(Lapiz, 170, PosYSeccion + 60, 340, PosYSeccion + 60)
        e.Graphics.DrawString("Fecha: ", Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion + 80)
        e.Graphics.DrawLine(Lapiz, 110, PosYSeccion + 100, 340, PosYSeccion + 100)

    End Sub
#End Region

#Region "76 STICKER VISITANTE (4 × 2 in)"
    Dim WithEvents DocImp_STICKERVISITANTE As New PrintDocument 'Documento a imprimir

    Private Sub DocImpSTICKERVISITANTE(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_STICKERVISITANTE.PrintPage
        Try
            Dim ComandoDatos As New SqlClient.SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)")
            ComandoDatos.Parameters.AddWithValue("@ACCION", 1)
            ComandoDatos.Parameters.AddWithValue("@VARIABLE", idVisitante)
            ComandoDatos.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Dim dt_Visitante As New DataTable
            ComandoDatos.Connection = Conexion
            Dim Adaptador As New SqlClient.SqlDataAdapter(ComandoDatos)
            ComandoDatos.Connection.Open()
            Adaptador.FillSchema(dt_Visitante, SchemaType.Source)
            Adaptador.Fill(dt_Visitante)
            ComandoDatos.Connection.Close()
            FilaDatosVISITANTE = dt_Visitante.Rows(0)
        Catch ex As Exception

        End Try

        Dim MargenDerecha As Integer = e.PageBounds.Right - 20
        Dim MargenInferior As Integer = e.PageBounds.Bottom - 20
        Dim MargenIzquierda As Integer = e.PageBounds.Left + 20
        Dim MargenSuperior As Integer = e.PageBounds.Top + 20

        Dim PosYSeccion As Integer = MargenSuperior
        Dim FuenteTexto As Font = Formato_Etiqueta_8R

        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, MargenDerecha - 50, PosYSeccion, 50, 40) 'Logo
            Case 1 'CSI
            Case 2 'Zamorana
                e.Graphics.DrawImage(logoZamorana, MargenDerecha - 50, PosYSeccion, 50, 40) 'Logo
        End Select


        e.Graphics.DrawString("VISITANTE", Formato_Etiqueta_18, Brocha, InicioCentradoTexto("VISITANTE", Formato_Etiqueta_18, (e.PageBounds.Right), e), PosYSeccion - 5)

        PosYSeccion = 50
        e.Graphics.DrawString(StrConv(FilaDatosVISITANTE("Nombre"), VbStrConv.ProperCase), Formato_Etiqueta_14R, Brocha, MargenIzquierda, PosYSeccion)
        PosYSeccion = 75
        e.Graphics.DrawString("IDENTIFICACIÓN: " + ClConvertir.Fun_FormatearCedula(RTrim(FilaDatosVISITANTE("Cedula"))), FuenteTexto, Brocha, MargenIzquierda, PosYSeccion + 0.0!)
        e.Graphics.DrawString("ID VISITA: " + FilaDatosVISITANTE("Año") + "-" + FilaDatosVISITANTE("Consecutivo").ToString(), FuenteTexto, Brocha, MargenIzquierda, PosYSeccion + 13.75!)
        e.Graphics.DrawString("FECHA Y HORA: " + Convert.ToDateTime(FilaDatosVISITANTE("Fecha")).ToString("dd/MM/yyyy',' hh:mm tt"), FuenteTexto, Brocha, MargenIzquierda, PosYSeccion + 27.5!)
        e.Graphics.DrawString("DEPENDENCIA: " + StrConv(FilaDatosVISITANTE("Dependencia"), VbStrConv.ProperCase), FuenteTexto, Brocha, MargenIzquierda, PosYSeccion + 41.25!)
        e.Graphics.DrawString("FUNCIONARIO: " + StrConv(FilaDatosVISITANTE("Funcionario"), VbStrConv.ProperCase), FuenteTexto, Brocha, MargenIzquierda, PosYSeccion + 55.0!)

        PosYSeccion = 150
        'CÓDIGO DE BARRAS'
        Dim CadenaCodigo As String = "VIS" + FilaDatosVISITANTE("IDVISITANTE").ToString().PadLeft(8, "0"c)
        Dim CodigoBarras As Image = FuncionesBase.FuncionesBase.GenerarCodigoBarras(CadenaCodigo, 360)
        e.Graphics.DrawImage(CodigoBarras, MargenIzquierda, PosYSeccion, 360, 20)
        e.Graphics.DrawString(CadenaCodigo, Formato_Etiqueta_6, Brocha, InicioCentradoTexto(CadenaCodigo, Formato_Etiqueta_6, (e.PageBounds.Right), e), PosYSeccion + 20)
        'CÓDIGO DE BARRAS
    End Sub
#End Region

#Region "77 - STICKERS RECEPCIÓN HOJA X 30 (6,7 × 2,5 cm)"
    ''' <summary>Tabla con los datos de los stickers de recepción y envío de documentos.</summary>
    Public dtNumeroSticker As DataTable

    Private indiceSticker As Integer = 0
    Private fuenteSticker As Font
    Private pfcSticker As PrivateFontCollection = New PrivateFontCollection()
    Private fontFamilySticker As FontFamily
    Private fuenteStickerCargada As Boolean = False
    Private Const nombreFuenteCodigoBarras As String = "FREE3OF9.TTF"

    Private WithEvents Pd_StickerRecepcion As New PrintDocument
    Private Sub Pd_StickerRecepcion_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles Pd_StickerRecepcion.PrintPage
        Const altoSticker As Integer = 100
        Const anchoSticker As Integer = 262
        Const anchoCodigoBarras As Integer = 175
        Const separacionHorizontalStickers As Integer = 12
        Const separacionVerticalStickers As Integer = 0
        Const textoCodigo1 As String = "CÓDIGO ÚNICO SEGUIMIENTO DE"
        Const textoCodigo2 As String = "CORRESPONDENCIA ISMOCOL S.A."
        Dim filaSticker As DataRow
        Dim drGrupo As DataRow = dtNumeroSticker.Rows(indiceSticker)

        If Not fuenteStickerCargada Then
            Try
                pfcSticker.AddFontFile(VariablesBase.VariablesBase._path & "\" & nombreFuenteCodigoBarras)
                fontFamilySticker = pfcSticker.Families(0)
                fuenteSticker = New Font(fontFamilySticker, 32)
                fuenteStickerCargada = True
            Catch ex As Exception
                Throw New Exception("La fuente " & nombreFuenteCodigoBarras & "no se encuentra instalada.", ex)
            End Try
        End If

        'ImprimirRejilla(e, Color.LightGray, 3, 0.5, 10, 10)
        e.Graphics.DrawString("Base: " & VariablesBase.VariablesBase.NombreBaseSiscontrol, Formato_Etiqueta_10, Brocha, 0, 0)
        e.Graphics.DrawStringCentered("Grupo: " & drGrupo.Item("GRUPO"), Formato_Etiqueta_9, Brocha, 810, 0, 0)
        e.Graphics.DrawStringRight("Hoja: " & drGrupo.Item("HOJA"), Formato_Etiqueta_9, Brocha, 800, 0)

        Dim puntoInicial As New Point(0, 30)
        For jVertical As Integer = 1 To 10
            For iHorizontal As Integer = 1 To 3
                filaSticker = dtNumeroSticker.Rows(indiceSticker)
                'e.Graphics.DrawRectangle(lineaPunteada, _
                'puntoInicial.X + ((anchoSticker + separacionHorizontalStickers) * (iHorizontal - 1)), _
                'puntoInicial.Y + ((altoSticker + separacionVerticalStickers) * (jVertical - 1)), _
                'anchoSticker, altoSticker)
                e.Graphics.DrawImage(logoIsmocol, _
                                     puntoInicial.X + ((anchoSticker + separacionHorizontalStickers) * (iHorizontal - 1) + 5), _
                                     puntoInicial.Y + ((altoSticker + separacionVerticalStickers) * (jVertical - 1) + 30), _
                                     48, 40)
                e.Graphics.DrawStringCentered(textoCodigo1, Formato_Etiqueta_6, Brocha, anchoCodigoBarras, _
                                              puntoInicial.X + ((anchoSticker + separacionHorizontalStickers) * (iHorizontal - 1) + (anchoSticker - anchoCodigoBarras - 20)), _
                                              puntoInicial.Y + ((altoSticker + separacionVerticalStickers) * (jVertical - 1) + 12))
                e.Graphics.DrawStringCentered(textoCodigo2, Formato_Etiqueta_6, Brocha, anchoCodigoBarras, _
                                              puntoInicial.X + ((anchoSticker + separacionHorizontalStickers) * (iHorizontal - 1) + (anchoSticker - anchoCodigoBarras - 20)), _
                                              puntoInicial.Y + ((altoSticker + separacionVerticalStickers) * (jVertical - 1) + 22))
                e.Graphics.DrawStringCentered(FormatoCodigoBarras(filaSticker.Item("NUMEROSTICKER")), fuenteSticker, Brushes.Black, anchoCodigoBarras, _
                                              puntoInicial.X + ((anchoSticker + separacionHorizontalStickers) * (iHorizontal - 1) + (anchoSticker - anchoCodigoBarras - 20)), _
                                              puntoInicial.Y + ((altoSticker + separacionVerticalStickers) * (jVertical - 1) + 38))
                e.Graphics.DrawStringCentered(filaSticker.Item("ETIQUETA"), Formato_Etiqueta_10R, Brocha, anchoCodigoBarras, _
                                              puntoInicial.X + ((anchoSticker + separacionHorizontalStickers) * (iHorizontal - 1) + (anchoSticker - anchoCodigoBarras - 20)), _
                                              puntoInicial.Y + ((altoSticker + separacionVerticalStickers) * (jVertical - 1) + (altoSticker - 22)))
                indiceSticker += 1
            Next
        Next

        If indiceSticker < dtNumeroSticker.Rows.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub Pd_StickerRecepcion_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles Pd_StickerRecepcion.EndPrint
        indiceSticker = 0
    End Sub

    ''' <summary>
    ''' Convierte una cadena de texto para imprimirse con fuente de código de barras.
    ''' </summary>
    ''' <param name="code">Cadena a codificar.</param>
    ''' <returns>Cadena formateada para ser impresa con fuente de código de barras.</returns>
    ''' <remarks></remarks>
    Public Function FormatoCodigoBarras(ByVal code As String) As String
        Dim barcode As String = String.Empty
        barcode = String.Format("{0}", code)
        Return "*" + barcode + "*"
    End Function
#End Region

#Region "78 - LISTA ENVÍO DE DOCUMENTOS RECEPCIÓN "
    Public NumeroRelacionEnvio As Integer
    Property Impreso As Boolean = False
    Const AlturaFilasEnvioDocsRecepcion As Integer = 10
    Const maxEspacioFilasEnvioDocsRecepcion As Integer = 300
    Const margenIzquierdaEnvioDocsRecepcion As Integer = 20
    Const margenDerechaEnvioDocsRecepcion As Integer = 800
    Private anchoDocumentoEnvioDocsRecepcion As Integer = margenDerechaEnvioDocsRecepcion - margenIzquierdaEnvioDocsRecepcion
    Private cargarListaEnvioDocsRecepcion As Boolean = True
    Private itemsImpresosEnvioDocsRecepcion As UInteger = 0
    Private vistaPreviaListaEnvioDocsRecepcion As Boolean = True
    Private paginasImpresasEnvioDocsRecepcion As UInteger = 0
    Private totalPaginasEnvioDocsRecepcion As UInteger = 0
    Private dtListaEnvioDocsRecepcion As DataTable
    Private filaListaEnvioDocsRecepcion As DataRow
    Private WithEvents DocImp_ListaEnvioDocsRecepcion As New PrintDocument
    Private Sub DocImp_ListaEnvioDocsRecepcion_PrintPage(sender As Object, e As PrintPageEventArgs) Handles DocImp_ListaEnvioDocsRecepcion.PrintPage
        If cargarListaEnvioDocsRecepcion Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim cadenaConsulta As String = ""
            cadenaConsulta = "SELECT * FROM SC_ImpresionListaEnvioDocsRecepcion(@NUMERORELACION)"
            Dim comando As New SqlCommand(cadenaConsulta, conexion)
            comando.Parameters.AddWithValue("@NUMERORELACION", NumeroRelacionEnvio)
            Dim Adaptador As New SqlDataAdapter(comando)
            dtListaEnvioDocsRecepcion = New DataTable()
            Try
                conexion.Open()
                Adaptador.Fill(dtListaEnvioDocsRecepcion)
                conexion.Close()
                cargarListaEnvioDocsRecepcion = False
            Catch ex As Exception
                Exit Sub
            Finally
                conexion.Close()
            End Try
        Else
            Impresion = True
        End If
        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If
        Dim colListaRecep_NumFila As New Cl_ColumnaImpresión(20, 20)
        Dim colListaRecep_Para As New Cl_ColumnaImpresión(160, colListaRecep_NumFila)
        Dim colListaRecep_De As New Cl_ColumnaImpresión(160, colListaRecep_Para)
        Dim colListaRecep_Memorando As New Cl_ColumnaImpresión(100, colListaRecep_De)
        Dim colListaRecep_NumDocumento As New Cl_ColumnaImpresión(100, colListaRecep_Memorando)
        Dim colListaRecep_Tipo As New Cl_ColumnaImpresión(80, colListaRecep_NumDocumento)
        Dim colListaRecep_Observacion As New Cl_ColumnaImpresión(160, colListaRecep_Tipo)
        'ImprimirRejilla(e, Color.LightGray, 3, 0.5, 10)
        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaEnvioDocsRecepcion, 40, anchoDocumentoEnvioDocsRecepcion, 440) 'Borde
        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, 45, 50, 75, 60)
            Case 1 'CSI
            Case 2 'Zamorana
                e.Graphics.DrawImage(logoZamorana, 25, 60, 110, 40)
        End Select
        e.Graphics.DrawLine(Lapiz, 140, 40, 140, 120) 'Vertical "Logo"

        If Not IsDBNull(dtListaEnvioDocsRecepcion.Rows(0).Item("DEPENDENCIAENVIO")) Then
            e.Graphics.DrawStringCentered("RELACIÓN CORRESPONDENCIA DEPARTAMENTO " & dtListaEnvioDocsRecepcion.Rows(0).Item("DEPENDENCIAENVIO"), Formato_Etiqueta_12, Brocha, 680, 140, 54)
        Else
            e.Graphics.DrawStringCentered("RELACIÓN CORRESPONDENCIA ENVIADA A TERCERO", Formato_Etiqueta_12, Brocha, 680, 140, 54)
        End If
        e.Graphics.DrawStringCentered("NRO. RELACIÓN: " & NumeroRelacionEnvio, Formato_Etiqueta_12, Brocha, 680, 140, 75)
        e.Graphics.DrawStringCentered("USUARIO ENVÍA: " & dtListaEnvioDocsRecepcion.Rows(0).Item("USUARIOENVIA"), Formato_Etiqueta_9I, Brocha, 680, 140, 98)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaEnvioDocsRecepcion, 120, margenDerechaEnvioDocsRecepcion, 120) 'Horizontal "Título"
        e.Graphics.DrawStringCentered("FECHA DE INFORME: " & Date.Now.ToShortDateString, Formato_Etiqueta_10, Brocha, anchoDocumentoEnvioDocsRecepcion, margenIzquierdaEnvioDocsRecepcion, 122)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaEnvioDocsRecepcion, 140, margenDerechaEnvioDocsRecepcion, 140) 'Horizontal "Fecha"

        e.Graphics.DrawStringCentered("PARA", Formato_Etiqueta_8, Brocha, colListaRecep_Para.Ancho, colListaRecep_Para.Izquierda, 144) 'PARA
        e.Graphics.DrawStringCentered("REMITENTE", Formato_Etiqueta_8, Brocha, colListaRecep_De.Ancho, colListaRecep_De.Izquierda, 144) 'DE
        e.Graphics.DrawStringCentered("MEMORANDO", Formato_Etiqueta_8, Brocha, colListaRecep_Memorando.Ancho, colListaRecep_Memorando.Izquierda, 144)
        e.Graphics.DrawStringCentered("NÚM. DOC.", Formato_Etiqueta_8, Brocha, colListaRecep_NumDocumento.Ancho, colListaRecep_NumDocumento.Izquierda, 144)
        e.Graphics.DrawStringCentered("TIPO", Formato_Etiqueta_8, Brocha, colListaRecep_Tipo.Ancho, colListaRecep_Tipo.Izquierda, 144)
        e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, colListaRecep_Observacion.Ancho, colListaRecep_Observacion.Izquierda, 144)
        e.Graphics.DrawLine(Lapiz, colListaRecep_NumFila.Derecha, 140, colListaRecep_NumFila.Derecha, 460) 'Vertical [#fila]
        e.Graphics.DrawLine(Lapiz, colListaRecep_Para.Derecha, 140, colListaRecep_Para.Derecha, 460) 'Vertical "Para"
        e.Graphics.DrawLine(Lapiz, colListaRecep_De.Derecha, 140, colListaRecep_De.Derecha, 460) 'Vertical "De"
        e.Graphics.DrawLine(Lapiz, colListaRecep_Memorando.Derecha, 140, colListaRecep_Memorando.Derecha, 460) 'Vertical "Memorando"
        e.Graphics.DrawLine(Lapiz, colListaRecep_Tipo.Derecha, 140, colListaRecep_Tipo.Derecha, 460) 'Vertical "Tipo"
        e.Graphics.DrawLine(Lapiz, colListaRecep_NumDocumento.Derecha, 140, colListaRecep_NumDocumento.Derecha, 460) 'Vertical "Núm. Doc."
        e.Graphics.DrawLine(Lapiz, margenIzquierdaEnvioDocsRecepcion, 160, margenDerechaEnvioDocsRecepcion, 160) 'Horizontal encabezado

        Dim espacioImpresoHoja As Integer = 0
        Dim cadenaPara As String = ""
        Dim alturaPara As UInteger = 0
        Dim cadenaDe As String = ""
        Dim alturaDe As UInteger = 0
        Dim cadenaTipo As String = ""
        Dim alturaTipo As UInteger = 0
        Dim cadenaObservacion As String = ""
        Dim alturaObservacion As UInteger = 0
        Dim posicionFilaRecepcion As Integer = 160
        Dim cantidadFilasActual As Integer = 0

        For i As UInteger = itemsImpresosEnvioDocsRecepcion To dtListaEnvioDocsRecepcion.Rows.Count - 1
            filaListaEnvioDocsRecepcion = dtListaEnvioDocsRecepcion.Rows(itemsImpresosEnvioDocsRecepcion)
            cantidadFilasActual = 0

            cadenaPara = Trim(filaListaEnvioDocsRecepcion("Para"))
            alturaPara = e.Graphics.MeasureString(cadenaPara, Formato_Etiqueta_6R, colListaRecep_Para.Ancho).Height \ AlturaFilasEnvioDocsRecepcion

            cadenaDe = Trim(filaListaEnvioDocsRecepcion("De"))
            alturaDe = e.Graphics.MeasureString(cadenaDe, Formato_Etiqueta_6R, colListaRecep_De.Ancho).Height \ AlturaFilasEnvioDocsRecepcion

            cadenaTipo = Trim(filaListaEnvioDocsRecepcion("Tipo Documento"))
            alturaTipo = e.Graphics.MeasureString(cadenaTipo, Formato_Etiqueta_6R, colListaRecep_Tipo.Ancho).Height \ AlturaFilasEnvioDocsRecepcion

            cadenaObservacion = Trim(filaListaEnvioDocsRecepcion("Descripción"))
            alturaObservacion = e.Graphics.MeasureString(cadenaObservacion, Formato_Etiqueta_6R, colListaRecep_Observacion.Ancho).Height \ AlturaFilasEnvioDocsRecepcion

            cantidadFilasActual = MaxOfValues(alturaPara, alturaDe, alturaTipo, alturaObservacion)

            If espacioImpresoHoja + (cantidadFilasActual * AlturaFilasEnvioDocsRecepcion) < maxEspacioFilasEnvioDocsRecepcion Then 'Si la fila cabe en la hoja actual
                'Número de fila
                e.Graphics.DrawStringCentered((itemsImpresosEnvioDocsRecepcion + 1).ToString, Formato_Etiqueta_6R, Brocha, colListaRecep_NumFila.Ancho, colListaRecep_NumFila.Izquierda, posicionFilaRecepcion + 1)

                'Para
                e.Graphics.DrawString(cadenaPara, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_Para.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_Para.Ancho, alturaPara * AlturaFilasEnvioDocsRecepcion))

                'De
                e.Graphics.DrawString(cadenaDe, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_De.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_De.Ancho, alturaDe * AlturaFilasEnvioDocsRecepcion))

                'Memorando
                e.Graphics.DrawString(filaListaEnvioDocsRecepcion("Memo"), Formato_Etiqueta_6R, Brocha, colListaRecep_Memorando.Izquierda + 2, posicionFilaRecepcion + 1)

                'Número Documento
                e.Graphics.DrawStringRight(filaListaEnvioDocsRecepcion("Numero Documento"), Formato_Etiqueta_6R, Brocha, colListaRecep_NumDocumento.Derecha - 2, posicionFilaRecepcion + 1)

                'Tipo
                e.Graphics.DrawString(cadenaTipo, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_Tipo.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_Tipo.Ancho, alturaTipo * AlturaFilasEnvioDocsRecepcion))

                'Observación
                e.Graphics.DrawString(cadenaObservacion, Formato_Etiqueta_6R, Brocha, New Rectangle(colListaRecep_Observacion.Izquierda + 2, posicionFilaRecepcion + 1, colListaRecep_Observacion.Ancho, alturaObservacion * AlturaFilasEnvioDocsRecepcion))

                If espacioImpresoHoja + (cantidadFilasActual * AlturaFilasEnvioDocsRecepcion) < maxEspacioFilasEnvioDocsRecepcion - AlturaFilasEnvioDocsRecepcion Then 'Si hay espacio para una línea de texto más.
                    e.Graphics.DrawLine(lineaPunteada, margenIzquierdaEnvioDocsRecepcion, posicionFilaRecepcion + (cantidadFilasActual * AlturaFilasEnvioDocsRecepcion), margenDerechaEnvioDocsRecepcion, posicionFilaRecepcion + (cantidadFilasActual * AlturaFilasEnvioDocsRecepcion)) 'Horizontal Renglones abajo
                End If

                If (espacioImpresoHoja + (cantidadFilasActual * AlturaFilasEnvioDocsRecepcion) = maxEspacioFilasEnvioDocsRecepcion - AlturaFilasEnvioDocsRecepcion) AndAlso itemsImpresosEnvioDocsRecepcion < dtListaEnvioDocsRecepcion.Rows.Count Then 'Si pasa a la siguiente hoja.
                    e.Graphics.DrawStringCentered("-- Pasa a la siguiente página --", Formato_Etiqueta_6, Brocha, anchoDocumentoEnvioDocsRecepcion, margenIzquierdaEnvioDocsRecepcion, posicionFilaRecepcion + (cantidadFilasActual * AlturaFilasEnvioDocsRecepcion))
                End If

                itemsImpresosEnvioDocsRecepcion += 1
                espacioImpresoHoja += cantidadFilasActual * AlturaFilasEnvioDocsRecepcion
                posicionFilaRecepcion += cantidadFilasActual * AlturaFilasEnvioDocsRecepcion
            Else
                Exit For
            End If
        Next

        e.Graphics.DrawLine(Lapiz, margenIzquierdaEnvioDocsRecepcion, 460, margenDerechaEnvioDocsRecepcion, 460) ' Horizontal Pie de Página
        e.Graphics.DrawStringCentered("FAVOR DEVOLVER CON FIRMA Y FECHA DE RECIBIDO", Formato_Etiqueta_8R, Brocha, anchoDocumentoEnvioDocsRecepcion, margenIzquierdaEnvioDocsRecepcion, 464)
        paginasImpresasEnvioDocsRecepcion += 1

        e.Graphics.DrawStringCentered("Página " & paginasImpresasEnvioDocsRecepcion & If(Not vistaPreviaListaEnvioDocsRecepcion, " de " & totalPaginasEnvioDocsRecepcion, ""), Formato_Etiqueta_6R, Brocha, anchoDocumentoEnvioDocsRecepcion, margenIzquierdaEnvioDocsRecepcion, 484)

        If itemsImpresosEnvioDocsRecepcion >= dtListaEnvioDocsRecepcion.Rows.Count Then
            If espacioImpresoHoja + AlturaFilasEnvioDocsRecepcion <= maxEspacioFilasEnvioDocsRecepcion Then
                e.Graphics.DrawStringCentered("--- Última fila ---", Formato_Etiqueta_6, Brocha, anchoDocumentoEnvioDocsRecepcion, margenIzquierdaEnvioDocsRecepcion, posicionFilaRecepcion + 2)
            End If
            e.HasMorePages = False
        Else
            e.HasMorePages = True
        End If
    End Sub

    Private Sub DocImp_ListaEnvioDocsRecepcion_EndPrint(sender As Object, e As PrintEventArgs) Handles DocImp_ListaEnvioDocsRecepcion.EndPrint
        If e.PrintAction = PrintAction.PrintToPrinter Then
            Impreso = True
            'If dtListaEnvioDocsRecepcion.Columns.Contains("BASE") Then
            'dtListaEnvioDocsRecepcion.Columns.Remove("BASE")
            'End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Consecutivo") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Consecutivo")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("De") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("De")
            End If
            'If dtListaEnvioDocsRecepcion.Columns.Contains("NIT") Then
            'dtListaEnvioDocsRecepcion.Columns.Remove("NIT")
            'End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Tipo Documento") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Tipo Documento")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Descripción") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Descripción")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Numero Documento") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Numero Documento")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Memo") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Memo")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("NOMBREDEPENDENCIA") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("NOMBREDEPENDENCIA")
            End If
            'If dtListaEnvioDocsRecepcion.Columns.Contains("NOMBREGERENCIA") Then
            'dtListaEnvioDocsRecepcion.Columns.Remove("NOMBREGERENCIA")
            'End If
            'If dtListaEnvioDocsRecepcion.Columns.Contains("NUMEROSTICKER") Then
            'dtListaEnvioDocsRecepcion.Columns.Remove("NUMEROSTICKER")
            'End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("ETIQUETA") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("ETIQUETA")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Fecha Recepción") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Fecha Recepción")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Para") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Para")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("Valor") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("Valor")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("DEPENDENCIAENVIO") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("DEPENDENCIAENVIO")
            End If
            If dtListaEnvioDocsRecepcion.Columns.Contains("USUARIOENVIA") Then
                dtListaEnvioDocsRecepcion.Columns.Remove("USUARIOENVIA")
            End If
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("MarcarSC_RecepcionTrazabilidad", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@Accion", 3) 'Marcar impreso
            comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
            comando.Parameters.AddWithValue("@NOMBRETERCERO", DBNull.Value)
            comando.Parameters.AddWithValue("@IDDEPENDENCIAACTUAL", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            comando.Parameters.AddWithValue("@TablaRECEPCION", dtListaEnvioDocsRecepcion)
            comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                Throw New Exception("Ocurrió un error al intentar guardar los datos.", ex)
            Finally
                conexion.Close()
            End Try
        ElseIf e.PrintAction = PrintAction.PrintToPreview Then
            itemsImpresosEnvioDocsRecepcion = 0
            If vistaPreviaListaEnvioDocsRecepcion Then
                totalPaginasEnvioDocsRecepcion = paginasImpresasEnvioDocsRecepcion
                paginasImpresasEnvioDocsRecepcion = 0
                vistaPreviaListaEnvioDocsRecepcion = False
            End If
        End If
    End Sub
#End Region

#Region "79 - STICKER RECEPCIÓN CONTINUA (5,1 × 3,2 cm)"
    Private tamannoStickerContinua As New Size(200, 125)
    Private tamannoLogoSticker As New Size(48, 40)
    Private fuenteTitulo As New Font("Tahoma", 6, FontStyle.Bold)

    Private WithEvents Pd_StickerRecepcionIndividual As New PrintDocument
    Private Sub Pd_StickerRecepcionIndividual_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles Pd_StickerRecepcionIndividual.PrintPage
        Const textoCodigo1 As String = "CÓDIGO ÚNICO SEGUIMIENTO"
        Const textoCodigo2 As String = "DE CORRESPONDENCIA"
        Const textoCodigo3 As String = "ISMOCOL S.A."

        If Not fuenteStickerCargada Then
            Try
                pfcSticker.AddFontFile(VariablesBase.VariablesBase._path & "\" & nombreFuenteCodigoBarras)
                fontFamilySticker = pfcSticker.Families(0)
                fuenteSticker = New Font(fontFamilySticker, 32)
                fuenteStickerCargada = True
            Catch ex As Exception
                Throw New Exception("La fuente " & nombreFuenteCodigoBarras & "no se encuentra instalada.", ex)
            End Try
        End If

        'ImprimirRejilla(e, Color.LightGray, 3, 0.5, 10, 5)
        Dim filaSticker As DataRow = dtNumeroSticker.Rows(indiceSticker)
        Dim scb As New SizeF(e.Graphics.MeasureString(FormatoCodigoBarras(filaSticker.Item("NUMEROSTICKER")), fuenteSticker))
        Dim tamannoCodigoBarras As New Size(scb.Width, scb.Height)

        e.Graphics.DrawRectangle(lineaPunteada, 0, 0, tamannoStickerContinua.Width, tamannoStickerContinua.Height)
        e.Graphics.DrawImage(logoIsmocol, 10, 10, tamannoLogoSticker.Width, tamannoLogoSticker.Height)
        e.Graphics.DrawStringCentered(textoCodigo1, fuenteTitulo, Brocha, tamannoStickerContinua.Width - tamannoLogoSticker.Width - 20, tamannoLogoSticker.Width + 10, 12)
        e.Graphics.DrawStringCentered(textoCodigo2, fuenteTitulo, Brocha, tamannoStickerContinua.Width - tamannoLogoSticker.Width - 20, tamannoLogoSticker.Width + 10, 25)
        e.Graphics.DrawStringCentered(textoCodigo3, fuenteTitulo, Brocha, tamannoStickerContinua.Width - tamannoLogoSticker.Width - 20, tamannoLogoSticker.Width + 10, 37)
        e.Graphics.DrawStringCentered(FormatoCodigoBarras(filaSticker.Item("NUMEROSTICKER")), fuenteSticker, Brushes.Black, tamannoStickerContinua.Width, 0, 61)
        e.Graphics.DrawStringCentered(filaSticker.Item("ETIQUETA"), Formato_Etiqueta_10, Brocha, tamannoStickerContinua.Width, 0, tamannoStickerContinua.Height - 23)

        If indiceSticker = dtNumeroSticker.Rows.Count - 1 Then
            e.HasMorePages = False
        Else
            indiceSticker += 1
            e.HasMorePages = True
            '#If DEBUG Then
            'e.HasMorePages = False
            '#End If
        End If
    End Sub

    Private Sub Pd_StickerRecepcionIndividual_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles Pd_StickerRecepcionIndividual.EndPrint
        If e.PrintAction = PrintAction.PrintToPreview Then
            indiceSticker = 0
        End If
    End Sub
#End Region

#Region "80 - DOCUMENTO SOPORTE"


    Private WithEvents DocImp_DocumentoEquivalente As New PrintDocument
    Dim CargarDatasetDocumentoSoporte As Boolean = True
    Dim ImpresionDS As Boolean = False
    Private _filaDocumento As DataRow
    Private _filaResolucion As DataRow
    Const margenIzquierdaDocumentoEquivalente As Integer = 30
    Const margenDerechaDocumentoEquivalente As Integer = 790
    Private anchoDocumentoDocumentoEquivalente As Integer = margenDerechaDocumentoEquivalente - margenIzquierdaDocumentoEquivalente
    Private Sub DocImpDocumentoEquivalente_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_DocumentoEquivalente.PrintPage

        If CargarDatasetDocumentoSoporte = True Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImpresionDocumentoEquivalente", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IDDOCUMENTO", idDocumento)
            comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            comando.Parameters.AddWithValue("@IDEMPRESA", VariablesBase.VariablesBase.EmpresaSisControlActual)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsDocumento As New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsDocumento)
                conexion.Close()
                'Table0 --> Documento
                If dsDocumento.Tables(0).Rows.Count > 0 Then
                    _filaDocumento = dsDocumento.Tables(0).Rows(0)
                End If
                If dsDocumento.Tables(1).Rows.Count > 0 Then
                    _filaResolucion = dsDocumento.Tables(1).Rows(0)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Impresión Documento Equivalente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
            CargarDatasetDocumentoSoporte = False
        Else
            ImpresionDS = True
        End If

        If _filaDocumento("Anulada") = "S" Then
            e.Graphics.RotateTransform(-45.0F)
            e.Graphics.DrawString("ANULADO", Formato_Etiqueta_80, Brushes.Silver, -400, 600)
            e.Graphics.RotateTransform(45.0F)
        End If

        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaDocumentoEquivalente, 80, anchoDocumentoDocumentoEquivalente, 820) 'Borde

        If VariablesBase.VariablesBase.EmpresaSisControlActual = 2 Then
            LogoEmpresa = 2
        End If

        Select Case LogoEmpresa
            Case 0 'Ismocol
                e.Graphics.DrawImage(logoIsmocol, margenIzquierdaDocumentoEquivalente + 30, 100, 120, 94)
            Case 1 'CSI
            Case 2 'Zamorana
                e.Graphics.DrawImage(logoZamorana, margenIzquierdaDocumentoEquivalente + 30, 100, 188, 50)
        End Select
        ' e.Graphics.DrawLine(Lapiz, 140, 40, 140, 120) 'Vertical "Logo"

        DrawRoundedRectangle(e.Graphics, 570, 100, 200, 35, 20)
        e.Graphics.DrawLine(Pens.Black, 570, 117, 770, 117)



        Select Case LogoEmpresa
            Case 0
                e.Graphics.DrawString("ICA - GRAL - F - 180", Formato_Etiqueta_8, Brocha, 620, 104)
                e.Graphics.DrawString("REVISIÓN No. 1", Formato_Etiqueta_8, Brocha, 628, 120)
                e.Graphics.DrawStringCentered("ISMOCOL S.A.", Formato_Etiqueta_12, Brocha, anchoDocumentoDocumentoEquivalente, margenIzquierdaDocumentoEquivalente, 100)
                e.Graphics.DrawStringCentered("NIT 890.209.174-1", Formato_Etiqueta_8, Brocha, anchoDocumentoDocumentoEquivalente, margenIzquierdaDocumentoEquivalente, 118)
            Case 1
            Case 2
                e.Graphics.DrawString("ZMA - GRAL - F - 58", Formato_Etiqueta_8, Brocha, 620, 104)
                e.Graphics.DrawString("REVISIÓN No. 0", Formato_Etiqueta_8, Brocha, 628, 120)
                e.Graphics.DrawStringCentered("ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S.", Formato_Etiqueta_7, Brocha, anchoDocumentoDocumentoEquivalente, margenIzquierdaDocumentoEquivalente, 100)
                e.Graphics.DrawStringCentered("NIT. 900.149.238-1", Formato_Etiqueta_7, Brocha, anchoDocumentoDocumentoEquivalente, margenIzquierdaDocumentoEquivalente, 118)
        End Select




        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaDocumentoEquivalente + 490, 205, 250, 58)
        e.Graphics.DrawStringCentered("DOCUMENTO SOPORTE DE ADQUISICIONES", Formato_Etiqueta_7, Brocha, 250, margenIzquierdaDocumentoEquivalente + 490, 208)
        e.Graphics.DrawStringCentered("EFECTUADAS A NO OBLIGADOS A FACTURAR", Formato_Etiqueta_7, Brocha, 250, margenIzquierdaDocumentoEquivalente + 490, 222)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente + 490, 235, 770, 235)
        Select Case LogoEmpresa
            Case 0
                e.Graphics.DrawStringCentered("No. IDE: " + CStr(_filaDocumento("Dian")) + " ", Formato_Etiqueta_9, Brocha, 250, margenIzquierdaDocumentoEquivalente + 490, 242)
            Case 1
            Case 2
                e.Graphics.DrawStringCentered("No. ZDS: " + CStr(_filaDocumento("Dian")) + " ", Formato_Etiqueta_9, Brocha, 250, margenIzquierdaDocumentoEquivalente + 490, 242)
        End Select


        e.Graphics.DrawString("Vendedor y/o prestador del servicio", Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 20, 275)
        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaDocumentoEquivalente + 20, 300, 720, 75)
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 23, 308)
        Dim proveedor As String = _filaDocumento("PROVEEDOR").ToString.Trim
        e.Graphics.DrawString(Mid(proveedor, 1, 70), Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 65, 308)
        e.Graphics.DrawString("Identificación:", Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 23, 324)
        e.Graphics.DrawString(_filaDocumento("Nit"), Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 90, 324)
        e.Graphics.DrawString("Dirección:", Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 23, 342)
        e.Graphics.DrawString(Mid(_filaDocumento("Direccion"), 1, 65), Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 70, 342)
        e.Graphics.DrawString("Teléfono:", Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 23, 361)
        e.Graphics.DrawString(_filaDocumento("Telefono"), Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 70, 361)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente + 490, 300, margenIzquierdaDocumentoEquivalente + 490, 375)
        e.Graphics.DrawString("Fecha:", Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 495, 308)
        e.Graphics.DrawString(Format(_filaDocumento("FECHADOCUMENTOEQUIVALENTE"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 540, 322)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente + 490, 338, 770, 338)

        'Descripción
        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaDocumentoEquivalente + 20, 405, 720, 320)
        e.Graphics.DrawStringCentered("DESCRIPCIÓN", Formato_Etiqueta_7, Brocha, anchoDocumentoDocumentoEquivalente - 40, margenIzquierdaDocumentoEquivalente + 20, 410)
        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente + 20, 423, 770, 423)
        Dim puntoOrigen1 As New Point(55, 430)

        Dim Cadenas1 As New ArrayList
        Cadenas1.Add(_filaDocumento("Descripcion"))
        Dim Cadena_Total1 As New ArrayList
        Cadena_Total1.Clear()
        Cadena_Total1 = TextoAParrafoFuente(Cadenas1, Formato_Etiqueta_7R, 700.2627, e)
        For i As Integer = 0 To Cadena_Total1.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total1(i), Formato_Etiqueta_7R, 700.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, puntoOrigen1.Y)
            puntoOrigen1.Y = puntoOrigen1.Y + EspacioParrafo - 5
        Next

        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente + 20, 683, 770, 683)
        e.Graphics.DrawString("Valor en letras:", Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 23, 703)

        Select Case _filaDocumento("SIGLAISO")
            Case "COP"
                Dim ValorEnLetras As String = UCase(NumerosEnPalabras(_filaDocumento("Total"), ""))
                Select Case ValorEnLetras.Length
                    Case Is < 73
                        e.Graphics.DrawString(ValorEnLetras + " " + CStr(Trim(_filaDocumento("TIPOMONEDA"))), Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        Exit Select
                    Case Is <= 90
                        e.Graphics.DrawString(ValorEnLetras + " " + CStr(Trim(_filaDocumento("TIPOMONEDA"))), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(ValorEnLetras, 1, 90), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        e.Graphics.DrawString(Mid(ValorEnLetras, 91, 90) + " " + CStr(Trim(_filaDocumento("TIPOMONEDA"))), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 713)
                End Select

            Case "USD"
                Dim ValorEnLetras As String = NumeLetrasOtrasMonedasV1(_filaDocumento("Total"), "CON", "DOLARES", 1)
                Select Case ValorEnLetras.Length
                    Case Is < 73
                        e.Graphics.DrawString(ValorEnLetras, Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        Exit Select
                    Case Is <= 90
                        e.Graphics.DrawString(ValorEnLetras, Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(ValorEnLetras, 1, 90), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        e.Graphics.DrawString(Mid(ValorEnLetras, 91, 90), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 713)
                End Select
            Case "EUR"
                Dim ValorEnLetras As String = NumeLetrasOtrasMonedasV1(_filaDocumento("Total"), "CON", "EUROS", 1)
                Select Case ValorEnLetras.Length
                    Case Is < 73
                        e.Graphics.DrawString(ValorEnLetras, Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        Exit Select
                    Case Is <= 90
                        e.Graphics.DrawString(ValorEnLetras, Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(ValorEnLetras, 1, 90), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
                        e.Graphics.DrawString(Mid(ValorEnLetras, 91, 90), Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 100, 713)
                End Select
            Case Else
                e.Graphics.DrawString(UCase(NumerosEnPalabras(_filaDocumento("Total"), "")) + " " + CStr(Trim(_filaDocumento("TIPOMONEDA"))), Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 100, 703)
        End Select
        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente + 580, 683, margenIzquierdaDocumentoEquivalente + 580, 725)
        e.Graphics.DrawString("TOTAL:", Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 583, 703)
        e.Graphics.DrawString(FormatearValor(_filaDocumento("Total")), Formato_Etiqueta_7, Brocha, margenIzquierdaDocumentoEquivalente + 618, 703)

        Dim puntoOrigen2 As New Point(50, 738)
        Dim Cadenas2 As New ArrayList
        Select Case LogoEmpresa
            Case 0
                Cadenas2.Add("AUTORIZACIÓN NUMERACIÓN DE FACTURACIÓN MODALIDAD DOCUMENTO SOPORTE No. " + CStr(_filaResolucion("RESOLUCIONDIAN")) + ", Numeración: AUTORIZADA Rango desde : IDE " + CStr(_filaResolucion("VALORINICIAL")) + " hasta IDE " + CStr(_filaResolucion("VALORFINAL")) + ". Vigencia desde " + _filaResolucion("VIGENCIA") + ".")
            Case 1
            Case 2
                Cadenas2.Add("AUTORIZACIÓN NUMERACIÓN DE FACTURACIÓN MODALIDAD DOCUMENTO SOPORTE No. " + CStr(_filaResolucion("RESOLUCIONDIAN")) + ", Numeración: AUTORIZADA Rango desde : ZDS " + CStr(_filaResolucion("VALORINICIAL")) + " hasta ZDS " + CStr(_filaResolucion("VALORFINAL")) + ". Vigencia desde " + _filaResolucion("VIGENCIA") + ".")
        End Select
        Dim Cadena_Total2 As New ArrayList
        Cadena_Total2.Clear()
        Cadena_Total2 = TextoAParrafoFuente(Cadenas2, Formato_Etiqueta_6R, 860.2627, e)
        For i As Integer = 0 To Cadena_Total2.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total2(i), Formato_Etiqueta_6R, 860.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_5R, Brocha, puntoOrigen2.X, puntoOrigen2.Y)
            puntoOrigen2.Y = puntoOrigen2.Y + EspacioParrafo - 10
        Next

        'e.Graphics.DrawString("AUTORIZACIÓN NUMERACIÓN DE FACTURACIÓN MODALIDAD DOCUMENTO SOPORTE No. " + CStr(_filaResolucion("RESOLUCIONDIAN")) + ", Numeración: AUTORIZADA Rango desde : IDE " + CStr(_filaResolucion("VALORINICIAL")) + " hasta IDE " + CStr(_filaResolucion("VALORFINAL")) + ". Vigencia desde " + _filaResolucion("VIGENCIA") + ". ", Formato_Etiqueta_5R, Brocha, margenIzquierdaDocumentoEquivalente + 20, 738)

        e.Graphics.DrawLine(Lapiz, margenIzquierdaDocumentoEquivalente, 778, anchoDocumentoDocumentoEquivalente + 30, 778)

        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaDocumentoEquivalente + 20, 807, 460, 20)
        e.Graphics.DrawString("CON CARGO AL CENTRO DE COSTOS:", Formato_Etiqueta_8, Brocha, margenIzquierdaDocumentoEquivalente + 23, 813)
        e.Graphics.DrawString(_filaDocumento("Centro Costo"), Formato_Etiqueta_8, Brocha, margenIzquierdaDocumentoEquivalente + 245, 813)
        e.Graphics.DrawString("Consecutivo interno:", Formato_Etiqueta_7R, Brocha, margenIzquierdaDocumentoEquivalente + 487, 813)
        e.Graphics.DrawRectangle(Lapiz, margenIzquierdaDocumentoEquivalente + 580, 807, 160, 20)
        If _filaDocumento("TIPODOCUMENTO") = "C" Then
            e.Graphics.DrawStringCentered(Trim(_filaDocumento("AbreviaturaBase")) + " - " + CStr(_filaDocumento("Consecutivo")) + " - " + CStr(_filaDocumento("Año")), Formato_Etiqueta_7R, Brocha, 138, margenIzquierdaDocumentoEquivalente + 580, 813)
        End If
        e.Graphics.DrawString("ELABORÓ:", Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 20, 872)
        e.Graphics.DrawString(_filaDocumento("Elaboro"), Formato_Etiqueta_6R, Brocha, margenIzquierdaDocumentoEquivalente + 70, 872)
        e.Graphics.DrawString("REVISÓ:", Formato_Etiqueta_6, Brocha, margenIzquierdaDocumentoEquivalente + 480, 872)
        e.Graphics.DrawString(_filaDocumento("Reviso"), Formato_Etiqueta_6R, Brocha, margenIzquierdaDocumentoEquivalente + 520, 872)

        Dim puntoOrigen As New Point(30, 912)
        Dim Cadenas As New ArrayList
        Select Case LogoEmpresa
            Case 0
                Cadenas.Add("El presente documento no constituye un título valor según el artículo 619 del código de comercio, solo constituye un documento interno de ISMOCOL S.A. " & _
                            "Cuando se realicen las transacciones con sujetos no obligados a expedir factura de venta y/o documento equivalente como soporte que prueba la respectiva transacción, " & _
                            "de acuerdo a lo establecido en el DR 358 de 2020, artículo 1.6.1.4.12 que regula el Decreto Único reglamentario en materia tributaria 1625 de 2016, artículo 55 de la Resolución 00042 de 5 de mayo de 2020. ")
                Cadenas.Add("Esta comunicación contiene información confidencial y también puede contener información privilegiada. Es para uso exclusivo de ISMOCOL S.A., cualquier distribución, copia o uso de esta comunicación o la información " & _
                            "que contiene esta estrictamente prohibida. Cualquier uso por parte de terceros debe estar autorizado por ISMOCOL S.A.")
            Case 1
            Case 2
                Cadenas.Add("El presente documento no constituye un título valor según el artículo 619 del código de comercio, solo constituye un documento interno de ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S " & _
                            "Cuando se realicen las transacciones con sujetos no obligados a expedir factura de venta y/o documento equivalente como soporte que prueba la respectiva transacción, " & _
                            "de acuerdo a lo establecido en el DR 358 de 2020, artículo 1.6.1.4.12 que regula el Decreto Único reglamentario en materia tributaria 1625 de 2016, artículo 55 de la Resolución 00042 de 5 de mayo de 2020. ")
                Cadenas.Add("Esta comunicación contiene información confidencial y también puede contener información privilegiada. Es para uso exclusivo de ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S, cualquier distribución, copia o uso de esta comunicación o la información " & _
                            "que contiene esta estrictamente prohibida. Cualquier uso por parte de terceros debe estar autorizado por ZAMORANA PERFORACIONES DIRIGIDAS DE COLOMBIA S.A.S")
        End Select

        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 767.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_6R, 767.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_6R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + EspacioParrafo - 5
        Next

        If ImpresionDS = True Then
            IDRELACIONDOCUMENTO = idDocumento
            GuardarImpresionRelacionDS()
        End If
    End Sub

    Private Sub GuardarImpresionRelacionDS()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure

            Comando.Parameters.AddWithValue("@TIPO", 14)

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
        Catch ex As Exception

        End Try

    End Sub

#End Region


#Region "Rutina de impresión"
    Dim WithEvents VistaPrevia As New PrintPreviewDialog

    ''' <summary>
    ''' Imprime los documentos indicados en el arreglo de formatos.
    ''' </summary>
    ''' <param name="Formatos">Arreglo de formatos a imprimir.</param>
    ''' <param name="VerVistaPrevia">Indica si se debe mostrar una ventana de previsualización antes de enviar a impresión.</param>
    ''' <param name="Doblecara">Indica si se deben usar las dos caras de las hojas para la impresión.</param>
    ''' <remarks></remarks>
    Public Sub FormatoImprimirSisControl(ByVal Formatos As ArrayList, ByVal VerVistaPrevia As Boolean, Optional ByVal Doblecara As Boolean = False)
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
                Case 70 'ICS-GRAL-F-05 Rv No.5 ORDEN DE SERVICIO
                    DocImp_ORDENSERVICIO.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ORDENSERVICIO.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ORDENSERVICIO
                Case 71 'SOBRE
                    DocImp_SOBRE.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_SOBRE.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_SOBRE
                Case 72 'LISTACORRESPONDENCIA
                    DocImp_LISTACORRESPONDENCIA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_LISTACORRESPONDENCIA.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_LISTACORRESPONDENCIA
                Case 73 'LISTARECEPCION"
                    DocImp_LISTARECEPCION.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_LISTARECEPCION.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_LISTARECEPCION
                Case 74 'BOLETA DE SALIDA
                    DocImp_BOLETASALIDA.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_BOLETASALIDA.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_BOLETASALIDA
                Case 75 'FORMULARIO POLÍTICA PARA TRATAMIENTO DE DATOS PERSONALES"
                    VistaPrevia.PrintPreviewControl.Zoom = 1
                    DocImp_POLITICADATOSPERSONALES.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_POLITICADATOSPERSONALES.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_POLITICADATOSPERSONALES
                Case 76 'STICKER VISITANTE
                    'VistaPrevia.PrintPreviewControl.Zoom = 1
                    DocImp_STICKERVISITANTE.PrinterSettings = PrintDialog1.PrinterSettings
                    'DocImp_STICKERVISITANTE.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_STICKERVISITANTE
                Case 77 'STICKERS RECEPCION HOJA X 30
                    VistaPrevia.PrintPreviewControl.Zoom = 1
                    Pd_StickerRecepcion.PrinterSettings = PrintDialog1.PrinterSettings
                    VistaPrevia.Document = Pd_StickerRecepcion
                Case 78 'LISTA ENVÍO DE DOCUMENTOS RECEPCIÓN
                    DocImp_ListaEnvioDocsRecepcion.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ListaEnvioDocsRecepcion.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ListaEnvioDocsRecepcion
                Case 79 'STICKER RECEPCIÓN CONTINUA
                    Pd_StickerRecepcionIndividual.PrinterSettings = PrintDialog1.PrinterSettings
                    Pd_StickerRecepcionIndividual.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("5.1 x 3.2 cm", tamannoStickerContinua.Width, tamannoStickerContinua.Height)
                    Pd_StickerRecepcionIndividual.PrinterSettings.DefaultPageSettings.Color = False
                    VistaPrevia.Document = Pd_StickerRecepcionIndividual
                Case 80 'DOCUMENTO EQUIVALENTE
                    DocImp_DocumentoEquivalente.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_DocumentoEquivalente.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_DocumentoEquivalente
            End Select
            Try
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                If VerVistaPrevia = True Then
                    VistaPrevia.ShowDialog()
                Else
                    VistaPrevia.Document.Print()
                End If
            Catch ex As Exception
                MsgBox("No se ha podido completar el proceso de impresión, por favor revisar configuración.", MsgBoxStyle.Critical, "ERROR")
            End Try
        Next i
    End Sub
#End Region 'Rutina de impresión

End Class 'Cl_Impresión


''' <summary>
''' Permite definir el espacio que ocupa una columna de una tabla.
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

''' <summary>
''' Extension methods for the System.Drawing.Graphics class
''' </summary>
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