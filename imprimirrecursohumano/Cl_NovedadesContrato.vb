Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms
Imports FunBase = FuncionesBase.FuncionesBase

Partial Class Cl_Impresión

#Region " 13 - ICA GRAL-F-034 CARTA DE TERMINACIÓN DE CONTRATO A TÉRMINO FIJO"
    Public WithEvents DocImp_ICAGRALF34 As New PrintDocument

    Public Sub DocImpr_ICAGRALF34(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF34.PrintPage
        ICAGRALF034(e)
    End Sub

    Public Sub ICAGRALF034(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fechaDocumento As Date
        Dim fechaTerminacion As Date
        Dim fechaContratacion As Date
        Dim puntorec1 As New Point(0, 0)

        fechaContratacion = _filaContrato("FECHAINGRESO")

        If Not IsDBNull(_filaContrato("CODIGOTIPOTERMINACIONCONTRATO")) AndAlso _filaContrato("CODIGOTIPOTERMINACIONCONTRATO") <> 3 Then 'Si se termina por razones diferentes al fin del plazo fijo pactado
            fechaTerminacion = _filaContrato("FECHATERMINACIONCONTRATO")
            fechaDocumento = _filaContrato("FECHATERMINACIONCONTRATO")
        Else 'Término del plazo fijo pactado
            If _dtProrrogasContrato.Rows.Count > 0 Then
                Dim resultado As DataRow = _dtProrrogasContrato.Select("", "CONSECUTIVOPRORROGA DESC")(0)
                fechaDocumento = resultado.Item("FECHAINICIO")
                fechaTerminacion = resultado.Item("FECHAFIN")
            Else
                fechaDocumento = fechaContratacion
                fechaTerminacion = _filaContrato("FECHATERMINOCONTRATOINICIAL")
            End If

            'If _dtProrrogasContrato.Rows.Count > 0 Then
            '    Dim resultado As DataRow = _dtProrrogasContrato.Select("", "CONSECUTIVOPRORROGA DESC")(0)
            '    fechaTerminacion = resultado.Item("FECHAFIN")
            '    If resultado.Item("DIASPRORROGA") > 30 Then
            '        fechaDocumento = fechaTerminacion.AddDays(-30)
            '    Else
            '        fechaDocumento = fechaTerminacion.AddDays(-Math.Ceiling(resultado.Item("DIASPRORROGA") / 2)) 'fechaTerminacion.AddDays(-15)
            '    End If
            'Else
            '    fechaTerminacion = _filaContrato("FECHATERMINOCONTRATOINICIAL")
            '    If (_filaContrato("CODIGOTIPODURACION") = "M" AndAlso _filaContrato("DURACION") > 1) OrElse (_filaContrato("CODIGOTIPODURACION") = "D" AndAlso _filaContrato("DURACION") > 30) Then
            '        fechaDocumento = fechaTerminacion.AddDays(-30)
            '    Else
            '        If (_filaContrato("CODIGOTIPODURACION") = "M" AndAlso _filaContrato("DURACION") = 1) Then
            '            fechaDocumento = fechaTerminacion.AddDays(-15) 'fechaTerminacion.AddDays(-15)
            '        Else
            '            fechaDocumento = fechaTerminacion.AddDays(-Math.Ceiling(_filaContrato("DURACION") / 2)) 'fechaTerminacion.AddDays(-15)
            '        End If
            '    End If
            'End If
        End If


        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(45, 50) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("CARTA DE TERMINACIÓN DE CONTRATO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("A TERMINO FIJO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-034", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 5", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 125)
        puntoOrigen.Y = puntoOrigen.Y + 160
        puntoOrigen.X = 80
        e.Graphics.DrawString("Ciudad y fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.X = puntoOrigen.X + 110
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & fechaDocumento.ToLongDateString, Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        puntoOrigen.X = 80
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", "") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 18)
        e.Graphics.DrawString("Cargo: " & _filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 36)

        e.Graphics.DrawString("Asunto: ", Formato_Etiqueta_10RSN, Brocha, puntoOrigen.X, puntoOrigen.Y + 91)
        e.Graphics.DrawString("Terminación contrato de trabajo por finalización del plazo fijo pactado.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y + 91)

        e.Graphics.DrawString("Cordial saludo,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 155)
        puntoOrigen.Y = puntoOrigen.Y + 220
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Con fundamento en lo establecido en el artículo 61 numeral 1 literal c del Código Sustantivo del Trabajo y la cláusula " & ClausulaTerminacionContrato(_filaContrato("CODIGOTIPOCONTRATO")) & _
            " del contrato, le comunicamos que el contrato de trabajo suscrito con usted el día " & fechaContratacion.Day & " del mes de " & fechaContratacion.ToString("MMMM") & " de " & fechaContratacion.Year & " " & _
            "se dará por terminado el día " & fechaTerminacion.Day & " del mes de " & fechaTerminacion.ToString("MMMM") & " de " & fechaTerminacion.Year & " en " & _
            "la que expirará el plazo fijo pactado.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 615, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 680, e), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadena_Total.Clear()

       Cadenas.Add("En consecuencia, al finalizar la jornada laboral del día de terminación señalado, se debe acercar a " & _
            "la oficina de la Empresa a gestionar el pago de los salarios y prestaciones que se le adeuden y " & _
            "retirar la orden para la práctica del examen médico de retiro. De no presentarse a retirar la orden " & _
            "para el examen dentro de los cinco días hábiles siguientes, se entenderá que ha desistido de este derecho.	")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 615, e)
        For i = 0 To Cadena_Total.Count - 1
            e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 680, e), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("ISMOCOL S.A ", Formato_Etiqueta_10, Brocha, puntoOrigen)
        e.Graphics.DrawString("RECIBÍ,", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 560, puntoOrigen.Y - 75, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 592, puntoOrigen.Y + 32)

        puntoOrigen.Y = puntoOrigen.Y + 25
        e.Graphics.DrawString("FIRMA DEL REPRESENTANTE", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)

        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 35

        puntoOrigen.Y = puntoOrigen.Y + 35
        e.Graphics.DrawString("C.C", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Nómina", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15

    End Sub


#End Region

#Region " 14 - ICA GRAL-F-129 CARTA DE TERMINACIÓN DE CONTRATO DE TRABAJO DE LABOR U OBRA DETERMINADA"
    Private WithEvents DocImp_ICAGRALF129 As New PrintDocument

    Private Sub DocImpr_ICAGRALF129(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF129.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(50, 40)
        Dim fechaIngreso As Date = _filaContrato("FECHAINGRESO")
        Dim fechaTerminacion As Date?

        If Not IsDBNull(_filaContrato("FECHATERMINACIONCONTRATO")) Then
            fechaTerminacion = _filaContrato("FECHATERMINACIONCONTRATO")
        Else
            If FechaterminaciónObraLabor = "#12:00 AM#" Then
            Else
                fechaTerminacion = FechaterminaciónObraLabor
            End If
        End If

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("TERMINACIÓN CONTRATO DE TRABAJO DE LABOR", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("U OBRA DETERMINADA", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA GRAL-F-129", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) '
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100)
        '**************************************************************************************************************************************

       e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 125)
        puntoOrigen.Y += 160
        puntoOrigen.X += 20
        e.Graphics.DrawString("Ciudad y fecha: " & _filaContrato("CIUDADCONTRATADO") & ", " & If(Not IsNothing(fechaTerminacion), fechaTerminacion.Value.ToLongDateString, "___________________________"), Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 60
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", "") & ":", Formato_Etiqueta_12R, Brocha, puntoOrigen)
        puntoOrigen.Y += 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 20
        e.Graphics.DrawString("Cargo: " & _filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 70
        e.Graphics.DrawString("Asunto: ", Formato_Etiqueta_10RSN, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Terminación contrato de trabajo por finalización de la labor determinada.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y)
        puntoOrigen.Y += 60
        e.Graphics.DrawString("Cordial saludo,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 45

        Dim Cadenas As New ArrayList
        Cadenas.Add("Con fundamento en lo establecido en el artículo 61 numeral 1 literal d del Código Sustantivo del Trabajo y la cláusula " & ClausulaTerminacionContrato(_filaContrato("CODIGOTIPOCONTRATO")) & " del contrato, le comunicamos que el contrato de trabajo suscrito con usted el día " & fechaIngreso.Day & " del mes de " & fechaIngreso.ToString("MMMM") & " de " & fechaIngreso.Year & " se dará por terminado el día " & If(Not IsNothing(fechaTerminacion), (fechaTerminacion.Value.Day & " del mes de " & fechaTerminacion.Value.ToString("MMMM") & " de " & fechaTerminacion.Value.Year), "___________________________") & ", " & _
            "fecha en la que concluirá la obra o labor para la cual fue contratado.")
        Cadenas.Add("")
        Cadenas.Add("En consecuencia, al finalizar la jornada laboral del día de terminación señalado, se debe acercar a la oficina de la Empresa a gestionar el pago de los salarios y prestaciones que se le adeuden y retirar la orden para la práctica del examen médico de retiro. De no presentarse a retirar la orden para el examen dentro de los cinco días hábiles siguientes, se entenderá que ha desistido de este derecho.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 720, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 710, e), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioParrafo
        Next
        puntoOrigen.Y += 20
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 60
        e.Graphics.DrawString("ISMOCOL S.A ", Formato_Etiqueta_10, Brocha, puntoOrigen)
        e.Graphics.DrawString("RECIBÍ,", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 560, puntoOrigen.Y - 75, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 592, puntoOrigen.Y + 32)
        puntoOrigen.Y = puntoOrigen.Y + 25
        e.Graphics.DrawString("FIRMA DEL REPRESENTANTE", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 35
        puntoOrigen.Y += 25
        e.Graphics.DrawString("C.C", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Nómina", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
    End Sub
#End Region

#Region " 52 - ICA-GRAL-F-029 RENOVACIÓN CONTRATO DE TRABAJO A TÉRMINO FIJO"
    Public WithEvents DocImp_ICAGRALF29 As New PrintDocument
    Public Sub DocImpr_ICAGRALF29(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF29.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        ICAGRALF29(e)
    End Sub
    Public Sub ICAGRALF29(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim puntoOrigen As New Point(45, 40)
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim resultado() As DataRow
        Dim filaProrroga As DataRow
        Dim vezProrroga As String = ""
        Dim fechaInicio As Date
        Dim fechaFirma As Date
        Dim fechaFin As Date
        Dim anchoParrafo As Integer = 715
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("RENOVACIÓN CONTRATO DE TRABAJO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("A TERMINO FIJO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-029", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 4", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100)
        '*************************************************************************************************************************************      
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 520, puntoOrigen.X + 765, 520)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 785, puntoOrigen.X + 765, 785)
        '********************************************************************
        puntoOrigen.Y += 130
        puntoOrigen.X += 20
        e.Graphics.DrawString("NOMBRE TRABAJADOR: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 180, puntoOrigen.Y)
        puntoOrigen.Y += 20
        e.Graphics.DrawString("IDENTIFICACIÓN: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("ABREVIACION") & " No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 120, puntoOrigen.Y)
        e.Graphics.DrawString(" DE ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 278, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y += 20
        e.Graphics.DrawString("FECHA DE INICIO DEL CONTRATO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("PLAZO INICIAL CONTRATO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 420, puntoOrigen.Y)
        Dim tipoduracion As String
        tipoduracion = _filaContrato("CODIGOTIPODURACION")
        Select Case tipoduracion
            Case "M"
                tipoduracion = "MESES"
            Case "D"
                tipoduracion = "DIAS"
        End Select

        e.Graphics.DrawString(_filaContrato("DURACION") & " " & tipoduracion, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 620, puntoOrigen.Y)
        e.Graphics.DrawString(DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 260, puntoOrigen.Y)
        puntoOrigen.Y += 20
        e.Graphics.DrawString("FECHA DE FINALIZACIÓN INICIAL DEL CONTRATO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToString("d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 345, puntoOrigen.Y)  'modificar la fecha
        e.Graphics.DrawString("CÓDIGO CONTRATO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 510, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 665, puntoOrigen.Y) ' modificar codigo
        puntoOrigen.Y += 20
        Dim x As Single = 280.0F
        Dim y As Single = 340.0F
        For i As Integer = 0 To Cadena_Total.Count - 1
            e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10, anchoParrafo, e), Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioParrafo
        Next
        '********************************************************************
        puntoOrigen.Y += 20
        For j As Integer = 0 To _dtProrrogasContrato.Rows.Count - 1
            resultado = _dtProrrogasContrato.Select("[CONSECUTIVOPRORROGA] = " & j + 1)
            If resultado.Length > 0 Then
                filaProrroga = resultado(0)
                fechaInicio = filaProrroga("FECHAINICIO")
                fechaFirma = filaProrroga("FECHAFIRMA")
                fechaFin = filaProrroga("FECHAFIN")
                Select Case j + 1
                    Case 1
                        vezProrroga = "1"
                    Case 2
                        vezProrroga = "2"
                    Case 3
                        vezProrroga = "3"
                End Select
                Cadenas.Clear()
                Cadena_Total.Clear()
                 Cadenas.Add("En " & _filaContrato("CIUDADCONTRATADO") & " a los " & _
                fechaFirma.Day & " días del mes de " & fechaFirma.ToString("MMMM") & " de " & fechaFirma.Year & ", " & _
                "de conformidad con lo dispuesto en articulo 46 numeral 2 del Código Sustantivo del Trabajo, los contratantes acuerdan prorrogar el contrato de trabajo, por el periodo descrito a continuación: ")
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_9R, anchoParrafo, e)
                For k As Integer = 0 To Cadena_Total.Count - 1
                    e.Graphics.DrawString(SubParrafo1(Cadena_Total(k), Formato_Etiqueta_9R, anchoParrafo, e), Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioParrafo
                Next
                puntoOrigen.Y += 30
                e.Graphics.DrawString("Las demás cláusulas del contrato original continuaran vigentes.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 5)
                puntoOrigen.Y += 15
                Dim drawBrush As New SolidBrush(Color.Black)
                Dim width As Single = 100.0F
                Dim height As Single = 18.0F
                Dim drawFormat As New StringFormat
                Dim drawFormat2 As New StringFormat
                Dim drawFormat3 As New StringFormat
                drawFormat.Alignment = StringAlignment.Center
                drawFormat.LineAlignment = StringAlignment.Center
                drawFormat2.LineAlignment = StringAlignment.Center
                drawFormat3.Alignment = StringAlignment.Near
                'FILA 1
                e.Graphics.DrawRectangle(Lapiz, x, y, width, height)   '1,1
                Dim drawRect As New RectangleF(x, y, width, height)
                e.Graphics.DrawString("Prórroga", Formato_Etiqueta_9R, drawBrush, drawRect, drawFormat)
                e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '1,2
                Dim drawRect11 As New RectangleF(x + width, y, width, height)
                e.Graphics.DrawString("Fecha Inicio", Formato_Etiqueta_9R, drawBrush, drawRect11, drawFormat)
                e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '1,3
                Dim drawRect12 As New RectangleF(x + 2 * width, y, width, height)
                e.Graphics.DrawString("Fecha Fin", Formato_Etiqueta_9R, drawBrush, drawRect12, drawFormat)
                y = y + height
                'FILA 2
                e.Graphics.DrawRectangle(Lapiz, x, y, width, height) '2,1
                Dim drawRect21 As New RectangleF(x, y, width, height)
                e.Graphics.DrawString(vezProrroga, Formato_Etiqueta_9R, drawBrush, drawRect21, drawFormat)
                e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '2,2
                Dim drawRect22 As New RectangleF(x + width, y, width, height)
                e.Graphics.DrawString(fechaInicio, Formato_Etiqueta_9R, drawBrush, drawRect22, drawFormat)
                e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '2,3
                Dim drawRect23 As New RectangleF(x + 2 * width, y, width, height)
                e.Graphics.DrawString(fechaFin, Formato_Etiqueta_9R, drawBrush, drawRect23, drawFormat)
                y = y + height
                puntoOrigen.Y += 60
                e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 630, puntoOrigen.Y - 75, 90, 120)   '' huella
                e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 662, puntoOrigen.Y + 32)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 250, puntoOrigen.Y) 'Horizontal
                e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 5)
                e.Graphics.DrawString("Nombre:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 20)
                e.Graphics.DrawString(_filaBaseConfiguracion("RESIDENTE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 55, puntoOrigen.Y + 21)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 350, puntoOrigen.Y, puntoOrigen.X + 550, puntoOrigen.Y) 'Horizontal
                e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 350, puntoOrigen.Y + 5)
                e.Graphics.DrawString("Nombre:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 350, puntoOrigen.Y + 20)
                Dim Nombre As String = _filaPersona("NOMBRECOMPLETO")
                If Nombre.Length < 25 Then
                    e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 405, puntoOrigen.Y + 21)
                Else
                    If Nombre.Length < 30 Then
                        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 405, puntoOrigen.Y + 21)
                    Else
                        e.Graphics.DrawString(_filaPersona("NOMBRES") + Chr(13) + Chr(10) + _filaPersona("APELLIDOS"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 405, puntoOrigen.Y + 21)

                    End If
                End If
                puntoOrigen.Y += 80
            End If
            y = y + 230.0F
        Next
    End Sub
#End Region

#Region " 55 - ICA GRAL-F-110 OTRO SÍ A CONTRATO DE TRABAJO POR LABOR CONTRATADA"
    Private WithEvents DocImp_ICAGRALF110 As New PrintDocument

    Private Sub DocImpr_ICAGRALF110(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF110.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim fechaFirma As Date = _filaOtrosiContrato("FECHAFIRMA")
        Dim puntoInicio As New Point(40, 50) '(10, 80)
        Dim dimensionesFormato As New Size(750, 980)
        Dim punto As New Point(puntoInicio.X, puntoInicio.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoInicio.X, puntoInicio.Y, dimensionesFormato.Width, dimensionesFormato.Height)
        e.Graphics.DrawImage(logoIsmocol, punto.X + 10, punto.Y + 10, 110, 90)
        e.Graphics.DrawLine(Lapiz, punto.X + 130, punto.Y, punto.X + 130, punto.Y + 110) 'vertical
        e.Graphics.DrawStringCentered("OTRO SI A CONTRATO DE TRABAJO POR LABOR", Formato_Etiqueta_12, Brocha, 460, punto.X + 130, punto.Y + 35)
        e.Graphics.DrawStringCentered("CONTRATADA", Formato_Etiqueta_12, Brocha, 460, punto.X + 130, punto.Y + 55)
        e.Graphics.DrawLine(Lapiz, punto.X + 595, punto.Y, punto.X + 595, punto.Y + 110) 'vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-110", Formato_Etiqueta_10, Brocha, 155, punto.X + 595, punto.Y + 20)
        e.Graphics.DrawLine(Lapiz, punto.X + 595, punto.Y + 55, puntoInicio.X + dimensionesFormato.Width, punto.Y + 55) 'horizontal
        e.Graphics.DrawStringCentered("Revisión No. 3", Formato_Etiqueta_10, Brocha, 155, punto.X + 595, punto.Y + 75)
        e.Graphics.DrawLine(Lapiz, puntoInicio.X, punto.Y + 110, puntoInicio.X + dimensionesFormato.Width, punto.Y + 110) 'horizontal
        '*****************************
        e.Graphics.DrawString("Código: " & _filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10R, Brocha, punto.X + 625, punto.Y + 115)
        punto = New Point(puntoInicio.X + 60, puntoInicio.Y + 150)
        e.Graphics.DrawString("Ciudad y fecha: " & _filaContrato("CIUDADCONTRATADO") & ", " & fechaFirma.ToLongDateString(), Formato_Etiqueta_10R, Brocha, punto.X, punto.Y + 5)
        'e.Graphics.DrawLine(Lapiz, punto.X + 100, punto.Y + 20, punto.X + 275, punto.Y + 20) 'horizontal
        '*****************************
        punto.Y = puntoInicio.Y + 250
        Dim anchoParrafo = 600
        Dim fuenteParrafo As Font
        If _filaOtrosiContrato("LABOROTROSI").ToString.Length <= 200 Then
            fuenteParrafo = Formato_Etiqueta_9R
        Else
            fuenteParrafo = Formato_Etiqueta_8R
        End If
        Dim cadenas As New ArrayList
        cadenas.Add("Los suscritos a saber " & _filaPersona("NOMBRECOMPLETO") & ", mayor de edad identificado con " & _filaPersona("TIPOIDENTIFICACION") & " No. " & _
                    FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " expedida en " & _filaPersona("CIUDADYDEPTOEXPEDICION") & ", " & _
                    "en calidad de trabajador, y " & _filaBaseConfiguracion("RESIDENTE") & ", igualmente mayor, identificado con la Cédula de Ciudadanía No. " & _
                    FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & ", expedida en " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE") & ", obrando " & _
                    "en representación de ISMOCOL S.A., acuerdan modificar la labor para la cual es contratado relacionado en el encabezado del contrato de trabajo " & _
                    "suscrito el " & _filaContrato("FECHAINGRESO") & ", en el sentido que  la labor contratada será " & _filaOtrosiContrato("LABOROTROSI") & ". " & _
                    "Estas labores están comprendidas dentro de las actividades del contrato " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " que ISMOCOL S.A. " & _
                    "ejecuta para " & _filaBaseConfiguracion("CLIENTE") & ". Las demás cláusulas del contrato original continuarán vigentes.")
        'cadenas.Add("")
        cadenas.Add("Para constancia de lo anterior, se firma por triplicado ante testigos en " & _filaOtrosiContrato("LUGARFIRMA") & _
                    ", a los " & fechaFirma.Day & " días del mes de " & FunBase.MesesCompleto(fechaFirma.Month).ToLower & " del año " & fechaFirma.Year & ".")
        Dim cadenasTotal As ArrayList = TextoAParrafoFuente(cadenas, fuenteParrafo, anchoParrafo, e, True)
        For i As Integer = 0 To cadenasTotal.Count - 1
            e.Graphics.DrawString(SubParrafo1(cadenasTotal(i), fuenteParrafo, anchoParrafo, e), fuenteParrafo, Brocha, punto.X, punto.Y + (i * espacioParrafo))
        Next
        '*****************************
        punto.Y = puntoInicio.Y + 640
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_10R, Brocha, punto.X, punto.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10R, Brocha, punto.X, punto.Y + 30)
        e.Graphics.DrawLine(Lapiz, punto.X, punto.Y + 95, punto.X + 180, punto.Y + 95) 'horizontal
        e.Graphics.DrawString("Nombre: " & _filaBaseConfiguracion("RESIDENTE"), Formato_Etiqueta_9R, Brocha, punto.X, punto.Y + 100)
        e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), Formato_Etiqueta_9R, Brocha, punto.X, punto.Y + 115)
        '*****************************
        e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_10R, Brocha, punto.X + 340, punto.Y)
        e.Graphics.DrawLine(Lapiz, punto.X + 340, punto.Y + 95, punto.X + 520, punto.Y + 95) 'horizontal
        e.Graphics.DrawString("Nombre: " & _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, punto.X + 340, punto.Y + 100)
        e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_9R, Brocha, punto.X + 340, punto.Y + 115)
        '*****************************
        punto.Y = puntoInicio.Y + 810
        e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_10R, Brocha, punto.X, punto.Y)
        e.Graphics.DrawLine(Lapiz, punto.X, punto.Y + 95, punto.X + 180, punto.Y + 95) 'horizontal
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_9R, Brocha, punto.X, punto.Y + 100)
        e.Graphics.DrawString("C.C. No.", Formato_Etiqueta_9R, Brocha, punto.X, punto.Y + 115)
        '*****************************
        e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_10R, Brocha, punto.X + 340, punto.Y)
        e.Graphics.DrawLine(Lapiz, punto.X + 340, punto.Y + 95, punto.X + 520, punto.Y + 95) 'horizontal
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_9R, Brocha, punto.X + 340, punto.Y + 100)
        e.Graphics.DrawString("C.C. No.", Formato_Etiqueta_9R, Brocha, punto.X + 340, punto.Y + 115)
    End Sub
#End Region

#Region " 60 - RENUNCIA VOLUNTARIA AL CARGO"
    Private WithEvents DocImp_RenunciaVoluntaria As New PrintDocument

    Public Sub DocImpr_RenunciaVoluntaria(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RenunciaVoluntaria.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        RenunciaVoluntaria(e)
    End Sub
    Public Sub RenunciaVoluntaria(ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        'Private Sub DocImpr_RenunciaVoluntaria(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RenunciaVoluntaria.PrintPage

        Dim Fecha As Date = DateTime.Now.ToShortDateString
        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(150, 155)
        'e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(Fecha, "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y) 'Date.Now.ToLongDateString
        e.Graphics.DrawString("Ciudad y Fecha:_____________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 156
        e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 72
        e.Graphics.DrawString("Asunto: Renuncia voluntaria al cargo.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 53
        e.Graphics.DrawString("Respetados Señores:", Formato_Etiqueta_10R, Brocha, puntoOrigen)

        puntoOrigen.Y = puntoOrigen.Y + 55
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Le informo que a partir del día de hoy, renunció al cargo que vengo desempeñando como " & _filaContrato("NOMBRETIPOCARGO") & " por motivos estrictamente personales. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 550.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 550.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 20

        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Les agradezco la oportunidad brindada y les deseo los mejores éxitos para esta compañía. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 550.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 550.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 50
        '**************************************************

        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 65
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        'e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 50, puntoOrigen.Y + 14, puntoOrigen.X + 310, puntoOrigen.Y + 14) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 50, puntoOrigen.Y + 14, puntoOrigen.X + 310, puntoOrigen.Y + 14) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("C.C.:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 50, puntoOrigen.Y + 14, puntoOrigen.X + 310, puntoOrigen.Y + 14) 'Horizontal

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 350, puntoOrigen.Y - 75, 65, 90)
        e.Graphics.DrawString("Huella", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 360, puntoOrigen.Y + 18)

    End Sub
#End Region

#Region " 71 - ICA GRAL-F-034 CARTA DE TERMINACIÓN DE CONTRATO A TÉRMINO FIJO - ICA-GRAL-F-029 RENOVACIÓN CONTRATO DE TRABAJO A TÉRMINO FIJO"
    Public WithEvents DocImp_ICAGRALF034029 As New PrintDocument

    Private contador As Integer = 1
    Private pendienteimprimir As Boolean = False
    Public Sub DocImpr_ICAGRALF034029(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF034029.PrintPage


        If contador = 1 Then
            ICAGRALF29(e)
            contador = contador + 1
            e.HasMorePages = True

        ElseIf contador > 1 Then
            ICAGRALF034(e)
            e.HasMorePages = False
        End If
        If pendienteimprimir = True Then
            contador = 1
            pendienteimprimir = False
        Else
            contador = 2
            pendienteimprimir = True
        End If



    End Sub

#End Region

#Region " 75 - ICA GRAL-F-034 CARTA DE TERMINACIÓN DE CONTRATO A TÉRMINO FIJO EN BLANCO"
    Public WithEvents DocImp_ICAGRALF34B As New PrintDocument

    Public Sub DocImpr_ICAGRALF34B(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF34B.PrintPage
        ICAGRALF034B(e)
    End Sub

    Public Sub ICAGRALF034B(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim fechaDocumento As Date
        Dim fechaTerminacion As Date
        Dim fechaContratacion As Date
        Dim puntorec1 As New Point(0, 0)

        fechaContratacion = _filaContrato("FECHAINGRESO")

        If Not IsDBNull(_filaContrato("CODIGOTIPOTERMINACIONCONTRATO")) AndAlso _filaContrato("CODIGOTIPOTERMINACIONCONTRATO") <> 3 Then 'Si se termina por razones diferentes al fin del plazo fijo pactado
            fechaTerminacion = _filaContrato("FECHATERMINACIONCONTRATO")
            fechaDocumento = _filaContrato("FECHATERMINACIONCONTRATO")
        Else 'Término del plazo fijo pactado
            If _dtProrrogasContrato.Rows.Count > 0 Then
                Dim resultado As DataRow = _dtProrrogasContrato.Select("", "CONSECUTIVOPRORROGA DESC")(0)
                fechaDocumento = resultado.Item("FECHAINICIO")
                fechaTerminacion = resultado.Item("FECHAFIN")
            Else
                fechaDocumento = fechaContratacion
                fechaTerminacion = _filaContrato("FECHATERMINOCONTRATOINICIAL")
            End If

            'If _dtProrrogasContrato.Rows.Count > 0 Then
            '    Dim resultado As DataRow = _dtProrrogasContrato.Select("", "CONSECUTIVOPRORROGA DESC")(0)
            '    fechaTerminacion = resultado.Item("FECHAFIN")
            '    If resultado.Item("DIASPRORROGA") > 30 Then
            '        fechaDocumento = fechaTerminacion.AddDays(-30)
            '    Else
            '        fechaDocumento = fechaTerminacion.AddDays(-Math.Ceiling(resultado.Item("DIASPRORROGA") / 2)) 'fechaTerminacion.AddDays(-15)
            '    End If
            'Else
            '    fechaTerminacion = _filaContrato("FECHATERMINOCONTRATOINICIAL")
            '    If (_filaContrato("CODIGOTIPODURACION") = "M" AndAlso _filaContrato("DURACION") > 1) OrElse (_filaContrato("CODIGOTIPODURACION") = "D" AndAlso _filaContrato("DURACION") > 30) Then
            '        fechaDocumento = fechaTerminacion.AddDays(-30)
            '    Else
            '        If (_filaContrato("CODIGOTIPODURACION") = "M" AndAlso _filaContrato("DURACION") = 1) Then
            '            fechaDocumento = fechaTerminacion.AddDays(-15) 'fechaTerminacion.AddDays(-15)
            '        Else
            '            fechaDocumento = fechaTerminacion.AddDays(-Math.Ceiling(_filaContrato("DURACION") / 2)) 'fechaTerminacion.AddDays(-15)
            '        End If
            '    End If
            'End If
        End If


        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(45, 50) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("CARTA DE TERMINACIÓN DE CONTRATO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("A TERMINO FIJO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-034", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 5", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 125)
        puntoOrigen.Y = puntoOrigen.Y + 160
        puntoOrigen.X = 80
        e.Graphics.DrawString("Ciudad y fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.X = puntoOrigen.X + 110
        e.Graphics.DrawString("__________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        puntoOrigen.X = 80
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", "") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 18)
        e.Graphics.DrawString("Cargo: " & _filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 36)

        e.Graphics.DrawString("Asunto: ", Formato_Etiqueta_10RSN, Brocha, puntoOrigen.X, puntoOrigen.Y + 91)
        e.Graphics.DrawString("Terminación contrato de trabajo por finalización del plazo fijo pactado.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y + 91)

        e.Graphics.DrawString("Cordial saludo,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 155)
        puntoOrigen.Y = puntoOrigen.Y + 220
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Con fundamento en lo establecido en el artículo 61 numeral 1 literal c del Código Sustantivo del Trabajo y la cláusula " & ClausulaTerminacionContrato(_filaContrato("CODIGOTIPOCONTRATO")) & _
            " del contrato, le comunicamos que el contrato de trabajo suscrito con usted el día ____ del mes de ______________  de ________, se dará por terminado el día ____ del mes de _______________ de ________ en la que expirará el plazo fijo pactado.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 615, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 680, e), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadena_Total.Clear()

        Cadenas.Add("En consecuencia, al finalizar la jornada laboral del día de terminación señalado, se debe acercar a " & _
             "la oficina de la Empresa a gestionar el pago de los salarios y prestaciones que se le adeuden y " & _
             "retirar la orden para la práctica del examen médico de retiro. De no presentarse a retirar la orden " & _
             "para el examen dentro de los cinco días hábiles siguientes, se entenderá que ha desistido de este derecho.	")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 615, e)
        For i = 0 To Cadena_Total.Count - 1
            e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 680, e), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("ISMOCOL S.A ", Formato_Etiqueta_10, Brocha, puntoOrigen)
        e.Graphics.DrawString("RECIBÍ,", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 560, puntoOrigen.Y - 75, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 592, puntoOrigen.Y + 32)

        puntoOrigen.Y = puntoOrigen.Y + 25
        e.Graphics.DrawString("FIRMA DEL REPRESENTANTE", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)

        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 35

        puntoOrigen.Y = puntoOrigen.Y + 35
        e.Graphics.DrawString("C.C", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Nómina", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15

    End Sub


#End Region

#Region " 87 'DECLARACIÓN DE PREEXISTENCIA DE PATOLOGÍA - RENUNCIA ACCIONES JUDICIALES Y RENUNCIA VOLUNTARIA AL CARGO"
    Public WithEvents DocImp_PreexistenciaRenuncia As New PrintDocument

    Private contador1 As Integer = 1
    Private pendienteimprimir1 As Boolean = False
    Public Sub DocImpr_PreexistenciaRenuncia(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_PreexistenciaRenuncia.PrintPage


        If contador1 = 1 Then
            DeclaracionPreexistenciaPatologia(e)
            contador1 = contador1 + 1
            e.HasMorePages = True

        ElseIf contador1 > 1 Then
            RenunciaVoluntaria(e)
            e.HasMorePages = False
        End If
        If pendienteimprimir1 = True Then
            contador1 = 1
            pendienteimprimir1 = False
        Else
            contador1 = 2
            pendienteimprimir1 = True
        End If



    End Sub

#End Region

    Private Function ClausulaTerminacionContrato(codigoTipoContrato As Integer) As String
        Dim fechaIngreso As Date = _filaContrato("FECHAINGRESO")
        If fechaIngreso < "20/03/2021" Then
            Select Case codigoTipoContrato
                Case 1, 2, 3, 6, 7
                    Return "octava"
                Case 4, 5, 9, 10
                    Return "séptima"
                Case Else
                    Return ""
            End Select
        Else
            Return "séptima"
        End If
        
    End Function

End Class