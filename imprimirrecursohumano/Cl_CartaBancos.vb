Imports System.Drawing.Printing
Imports System.Drawing

Partial Class Cl_Impresión

#Region " 12 - CARTA BANCO"
    Private WithEvents DocImp_CARTABANCO As New PrintDocument
    '    Dim Sueldo As String

    Private Sub DocImpr_CARTABANCO(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTABANCO.PrintPage
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, 85, 27, 110, 90)
        Dim tab As Integer = 80
        puntoOrigen.Y = 140
        puntoOrigen.X = tab
        puntoOrigen.X = 510
        e.Graphics.DrawString(ConsecutivoCartaBanco.Trim.ToUpper, Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.X = tab
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") + ", " + _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Señores", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        'e.Graphics.DrawString(_filaBaseConfiguracion("ENTIDADFINANCIERA"), Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        'e.Graphics.DrawString(_filaBaseConfiguracion("DIRECCIONENTIDADFINANCIERA"), Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Ciudad", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Asunto : Apertura Cuenta de Ahorros", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        Dim Cadenas As New ArrayList
        Cadenas.Add("Le solicitamos el favor de realizar la apertura de la Cuenta de Ahorros para dispersión de nómina correspondiente a las Personas que relacionamos a" & _
                    " continuación, quienes iniciaran labores con la Empresa:")
        Dim Cadena_Total As New ArrayList
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        e.Graphics.DrawRectangle(Lapiz, 115, puntoOrigen.Y, 600, 25)
        e.Graphics.FillRectangle(BrochaVerdeClaro, 116, puntoOrigen.Y + 1, 599, 23)
        e.Graphics.DrawString("Nombres y Apellidos", Formato_Etiqueta_9, Brocha, 200, puntoOrigen.Y + 5)
        e.Graphics.DrawRectangle(Lapiz, 115, puntoOrigen.Y + 25, 600, 15)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, 116, puntoOrigen.Y + 26)
        e.Graphics.DrawLine(Lapiz, 430, puntoOrigen.Y, 430, puntoOrigen.Y + 40)
        e.Graphics.DrawString("No. Cédula", Formato_Etiqueta_9, Brocha, 434, puntoOrigen.Y + 5)
        e.Graphics.DrawString(_filaPersona("IDENTIFICACION"), Formato_Etiqueta_8R, Brocha, 431, puntoOrigen.Y + 26)
        e.Graphics.DrawLine(Lapiz, 510, puntoOrigen.Y, 510, puntoOrigen.Y + 40)
        e.Graphics.DrawString("Expedida", Formato_Etiqueta_9, Brocha, 585, puntoOrigen.Y + 5)
        e.Graphics.DrawString(_filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, 511, puntoOrigen.Y + 26)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString("La cuenta corriente desde la cual se efectuara la dispersión de fondos es la,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("No. 600-05190-8, código 650", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("ISMOCOL S.A ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("Administrador de Obra Base " + _filaBaseConfiguracion("CIUDADCONTRATACION"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString("Copias:  Consecutivo / Archivo", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 100
        e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55-69 - P.B.X. 6573377 - A.A. 421 - FAX: 6431332 (ADMINISTRACION)", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("   FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VIA PIEDECUESTA", Formato_Etiqueta_10R, Brocha, puntoOrigen)
    End Sub
#End Region

#Region " 62 - CARTA BANCO BBVA"
    Private WithEvents DocImp_CARTABANCOBBVA As New PrintDocument

    Private Sub DocImpr_CARTABANCOBBVA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTABANCOBBVA.PrintPage
        Dim puntoOrigen As New Point(150, 170)
        e.Graphics.DrawString("BUC-ICA- -", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 52
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If IdBase = 0 Then
            e.Graphics.DrawString("Doctora", Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Gloria Elena Garzon Gomez", Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Gerente Oficina Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        Else
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Banco BBVA", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Calle 35 No. 18 - 02", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        If IdBase = 0 Then
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Telefono: 6 331241 / 6 334337", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        ElseIf IdBase = 0 Then
            e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        Else
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 42
        e.Graphics.DrawString("Asunto: Apertura Cuenta de Ahorros", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 38
        If IdBase = 0 Then
            e.Graphics.DrawString("Estimada doctora Gloria Elena:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Estimados Señores:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 45
        '********************************************************************
        Dim Cadenas As New ArrayList
        Dim salario As Double
        If _filaContrato("CODIGOTIPOSALARIO") = "M" Then
            salario = _filaContrato("SALARIO")
        Else
            salario = _filaContrato("SALARIO") * 30
        End If
        Cadenas.Add("Le solicitamos el favor de realizar la apertura de la Cuenta de Ahorros para dispersión de nómina correspondiente al señor(a) " & _filaPersona("NOMBRECOMPLETO") & " Identificado(a) con cédula de ciudadanía No. " & _filaPersona("IDENTIFICACION") & "  de " & _filaPersona("CIUDADEXPEDICION") & ", quien " & _
                    "devengará un salario básico de $ " & salario & ". ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 26
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 113
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 92
        If IdBase = 0 Then
            e.Graphics.DrawString("HORACIO GIL LINARES", Formato_Etiqueta_10, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Jefe Dpto. Administrativo", Formato_Etiqueta_10, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Administrador(a) Base " & _filaBaseConfiguracion("NOMBREBASE") & "", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Copias: Archivo / Consecutivo / Hoja de vida", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("HGL/hpc", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        puntoOrigen.X = puntoOrigen.X + 490
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 95, 23)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 12, puntoOrigen.X + 95, puntoOrigen.Y + 12) 'Horizontal
        e.Graphics.DrawString("ICA-GRAL-F-024", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 14, puntoOrigen.Y + 1)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 12)
    End Sub
#End Region

#Region " 63 - CARTA BANCO BOGOTA"
    Private WithEvents DocImp_CARTABANBOGOTA As New PrintDocument

    Private Sub DocImpr_CARTABANBOGOTA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTABANBOGOTA.PrintPage
        Dim puntoOrigen As New Point(150, 170)
        e.Graphics.DrawString("BUC-ICA- -", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 52
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If IdBase = 0 Then
            e.Graphics.DrawString("Doctora", Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Diana Gabriela Ramirez", Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Jefe de Servicios", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        Else
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Banco de Bogotá", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Calle 52 No. 31 - 21", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 42
        e.Graphics.DrawString("Asunto: Apertura Cuenta de Ahorros", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 38
        If IdBase = 0 Then
            e.Graphics.DrawString("Estimada doctora Diana:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Estimados Señores:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 45
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Le solicitamos el favor de realizar la apertura de la Cuenta de Ahorros para dispersión de nómina correspondiente al señor(a) " & _filaPersona("NOMBRECOMPLETO") & " Identificado(a) con cédula de ciudadanía No. " & _filaPersona("IDENTIFICACION") & "  de " & _filaPersona("CIUDADEXPEDICION") & ", quien " & _
                    "empezará a laborar con la Empresa.")

        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("La  cuenta corriente desde la cual se efectuará la dispersión de fondos es la No. 600051908, código disfon 650.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 26
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 113
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 92
        If IdBase = 0 Then
            e.Graphics.DrawString("HORACIO GIL LINARES", Formato_Etiqueta_10, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Jefe Dpto. Administrativo", Formato_Etiqueta_10, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Administrador(a) Base " & _filaBaseConfiguracion("NOMBREBASE") & "", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Copias: Archivo / Consecutivo / Hoja de vida", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("HGL/hpc", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        puntoOrigen.X = puntoOrigen.X + 490
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 95, 23)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 12, puntoOrigen.X + 95, puntoOrigen.Y + 12) 'Horizontal
        e.Graphics.DrawString("ICA-GRAL-F-024", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 14, puntoOrigen.Y + 1)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 12)
    End Sub
#End Region

#Region " 64 - CARTA BANCOLOMBIA"
    Private WithEvents DocImp_CARTABANCOLOMBIA As New PrintDocument

    Private Sub DocImpr_CARTABANCOLOMBIA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTABANCOLOMBIA.PrintPage
        Dim puntoOrigen As New Point(150, 170)
        e.Graphics.DrawString("BUC-ICA- -", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 52
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 69
        e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Bancolombia", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("                  ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 42
        e.Graphics.DrawString("Asunto: Apertura Cuenta de Ahorros", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 38
        e.Graphics.DrawString("Estimados Señores:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 45
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("ISMOCOL S.A., Identificado con el NIT: 890.209.174, solicito la inscripción de la cuenta de ahorros, de la cual será titular el señor(a) " & _filaPersona("NOMBRECOMPLETO") & " Identificado(a) con cédula de ciudadanía No. " & _filaPersona("IDENTIFICACION") & "  de " & _filaPersona("CIUDADEXPEDICION") & " en el " & _
                    "Convenio de Nómina No. 59918 que actualmente tenemos celebrado con Bancolombia.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("En consecuencia, igualmente solicitamos que la cuenta sea vinculada con las mismas características (plan y Grupo de Cobro), asociadas a este convenio.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 26
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 113
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 92
        If IdBase = 0 Then
            e.Graphics.DrawString("HORACIO GIL LINARES", Formato_Etiqueta_10, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Jefe Dpto. Administrativo", Formato_Etiqueta_10, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Administrador(a) Base " & _filaBaseConfiguracion("NOMBREBASE") & "", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Copias: Archivo / Consecutivo / Hoja de vida", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("HGL/hpc", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        puntoOrigen.X = puntoOrigen.X + 490
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 95, 23)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 12, puntoOrigen.X + 95, puntoOrigen.Y + 12) 'Horizontal
        e.Graphics.DrawString("ICA-GRAL-F-024", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 14, puntoOrigen.Y + 1)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 12)
    End Sub
#End Region

#Region " 65 - CARTA BANCO ITAU"
    Private WithEvents DocImp_CARTABANCOITAU As New PrintDocument

    Private Sub DocImpr_CARTABANCOITAU(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTABANCOITAU.PrintPage
        Dim puntoOrigen As New Point(150, 170)
        e.Graphics.DrawString("BUC-ICA- -", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 52
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 69
        e.Graphics.DrawString("Señores:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("ITAÚ", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Oficina principal", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Carrera 29 No. 45-79", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Telefono: 6 331241 / 6 334337", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 19
        e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 42
        e.Graphics.DrawString("Asunto: Apertura Cuenta de Ahorros", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 38
        e.Graphics.DrawString("Estimados Señores:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 45
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("ISMOCOL S.A., Identificado con el NIT: 890.209.174, solicito la inscripción de la cuenta de ahorros, de la cual será titular el señor(a) " & _filaPersona("NOMBRECOMPLETO") & " Identificado(a) con cédula de ciudadanía No. " & _filaPersona("IDENTIFICACION") & "  de " & _filaPersona("CIUDADEXPEDICION") & " en el " & _
                "Convenio de Nómina No. 59918 que actualmente tenemos celebrado con Itaú.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Dim salario As Double
        If _filaContrato("CODIGOTIPOSALARIO") = "M" Then
            salario = _filaContrato("SALARIO")
        Else
            salario = _filaContrato("SALARIO") * 30
        End If
        Cadenas.Clear()
        Cadenas.Add("Quien devengará un salario basico mensual de $ " & salario & ". ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 26
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 113
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 92
        If IdBase = 0 Then
            e.Graphics.DrawString("HORACIO GIL LINARES", Formato_Etiqueta_10, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Jefe Dpto. Administrativo", Formato_Etiqueta_10, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawString("Administrador(a) Base " & _filaBaseConfiguracion("NOMBREBASE") & "", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Copias: Archivo / Consecutivo / Hoja de vida", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("HGL/hpc", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        puntoOrigen.X = puntoOrigen.X + 490
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 95, 23)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 12, puntoOrigen.X + 95, puntoOrigen.Y + 12) 'Horizontal
        e.Graphics.DrawString("ICA-GRAL-F-024", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 14, puntoOrigen.Y + 1)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 12)
    End Sub
#End Region

End Class