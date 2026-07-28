Public Class Cl_Convertir_Num_Letras

  Private Const DOT As String = ","

  Public Function NumerosEnPalabras(ByVal Number As String, ByVal Moneda As String) As String
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

    Public Function IntNumToSpanish(ByVal numero As Integer) As String
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

  Private Function EvalPart(ByVal x As Integer) As String
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

  Private Sub ReplaceStringFrom(ByRef s As String, _
      ByVal OldWrd As String, _
      ByVal NewWrd As String, _
      ByVal ptr As Integer)
    s = Left(s, ptr - 1) + NewWrd + Mid(s, Len(OldWrd) + ptr)
  End Sub

  Private Function Singular(ByVal s As String) As String
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

  Private Function CloneChain(ByVal n As Integer, ByVal Chr As String)
    Dim i As Integer
    Dim CharClone As String
    Dim rtn As String
    If Len(Chr) Then
      CharClone = Mid(Chr, 1, 1)
      For i = 1 To n
        rtn = rtn + CharClone
      Next
    End If
    Return rtn
  End Function

  Private Sub ReplaceAll( _
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

    Public Function Meses(ByVal x As Integer) As String
        Dim s As String
        Select Case x
            Case 1 : s = "Enero"
            Case 2 : s = "Febrero"
            Case 3 : s = "Marzo"
            Case 4 : s = "Abril"
            Case 5 : s = "Mayo"
            Case 6 : s = "Junio"
            Case 7 : s = "Julio"
            Case 8 : s = "Agosto"
            Case 9 : s = "Septiembre"
            Case 10 : s = "Octubre"
            Case 11 : s = "Noviembre"
            Case 12 : s = "Diciembre"
        End Select
        Meses = s
    End Function

    Public Function Fun_Fecha_Cadena(ByVal Fecha As Date) As String
        Dim Num_Letras As New Cl_Convertir_Num_Letras
        Fun_Fecha_Cadena = LTrim(RTrim(Num_Letras.IntNumToSpanish(Fecha.Day))) + _
                       " (" + Fecha.Day.ToString + ") días de " + Me.Meses(Fecha.Month) + " de " + Fecha.Year.ToString
    End Function

    Public Function Fun_FormatearCedula(ByVal Cedula As String) As String
        If IsNumeric(Cedula) = True Then
            Dim longitud As Integer = Cedula.Length
            Dim nuevacedula As String = ""
            While Cedula.Length > 3
                nuevacedula = "." + Mid(Cedula, Cedula.Length - 2, 3) + nuevacedula
                Cedula = Mid(Cedula, 1, Cedula.Length - 3)
            End While
            nuevacedula = Cedula + nuevacedula
            Fun_FormatearCedula = nuevacedula
        Else
            Fun_FormatearCedula = Cedula
        End If

    End Function

End Class


