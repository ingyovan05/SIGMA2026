Imports System.Drawing.Printing
Imports System.Drawing

Partial Public Class Cl_Impresión

#Region " 66 - ASIGNACIÓN AUXILIO DE ALIMENTACIÓN CENIT"
    Private WithEvents DocImp_AsignacionAuxilioAlimentacionCenit As New PrintDocument
    Private _filaAuxilioAlimentacionCenit As DataRow

    Private Sub DocImpr_AsignacionAuxilioAlimentacionCenit(sender As Object, e As PrintPageEventArgs) Handles DocImp_AsignacionAuxilioAlimentacionCenit.PrintPage

        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawString("ASIGNACIÓN AUXILIO DE ALIMENTACIÓN PARA CONTRATOS CON", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 144, puntoOrigen1.Y + 40)
        e.Graphics.DrawString("CENIT TRANSPORTE Y LOGÍSTICA DE HIDROCARBUROS S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 163, puntoOrigen1.Y + 58)
        e.Graphics.DrawString("ICA-GRAL-F- 164", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 637, puntoOrigen1.Y + 75)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 134, puntoOrigen1.Y, puntoOrigen1.X + 134, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen1.X + 12, puntoOrigen1.Y + 8, 110, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y, puntoOrigen1.X + 605, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y + 53, puntoOrigen1.X + 762, puntoOrigen1.Y + 53) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 108, puntoOrigen1.X + 762, puntoOrigen1.Y + 108) 'Horizontal completa
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim puntoOrigen As New Point(33, 129)
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (10,164,170,173)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
        End If
        puntoOrigen.Y += 63
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 50
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y = 420
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Cenit Transporte y Logística de " & _
                    "Hidrocarburos S.A., ISMOCOL S.A., concederá a Usted un beneficio en dinero de naturaleza no " & _
                    "salarial, consistente en un auxilio que no tiene por finalidad la retribución directa del servicio para el " & _
                    "cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino para " & _
                    "buscar su mejor bienestar lo cual sirve para gastos de alimentación.")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "proporcionalmente al tiempo laborado por periodos quincenales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este auxilio de alimentación no constituye salario para ningún efecto, y se imputará a cualquier otra " & _
                    "clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja " & _
                    "expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, entiende y " & _
                    "acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. " & _
                    "Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 45, puntoOrigen.X + 490, puntoOrigen.Y + 45) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 45)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 60, puntoOrigen.X + 490, puntoOrigen.Y + 60) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

#Region " 67 - ASIGNACIÓN AUXILIO DE TRANSPORTE CENIT"
    Private WithEvents DocImp_AsignacionAuxilioTransporteCenit As New PrintDocument
    Private _filaAuxilioTransporteCenit As DataRow

    Private Sub DocImpr_AsignacionAuxilioTransporteCenit(sender As Object, e As PrintPageEventArgs) Handles DocImp_AsignacionAuxilioTransporteCenit.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawString("ASIGNACIÓN AUXILIO DE TRANSPORTE PARA CONTRATOS CON", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 144, puntoOrigen1.Y + 40)
        e.Graphics.DrawString("CENIT TRANSPORTE Y LOGÍSTICA DE HIDROCARBUROS S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 163, puntoOrigen1.Y + 58)
        e.Graphics.DrawString("ICA-GRAL-F- 166", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 637, puntoOrigen1.Y + 75)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 134, puntoOrigen1.Y, puntoOrigen1.X + 134, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen1.X + 12, puntoOrigen1.Y + 8, 110, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y, puntoOrigen1.X + 605, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y + 53, puntoOrigen1.X + 762, puntoOrigen1.Y + 53) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 108, puntoOrigen1.X + 762, puntoOrigen1.Y + 108) 'Horizontal completa
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim puntoOrigen As New Point(33, 129)
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (12,165,171,174)")
        If resultados.Length > 0 Then
            _filaAuxilioTransporteCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioTransporteCenit("VALOR"), 2)
        End If
        puntoOrigen.Y += 63
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 50
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y = 420
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Cenit Transporte y Logística de " & _
                    "Hidrocarburos S.A., ISMOCOL S.A., concederá a Usted un beneficio en dinero de naturaleza no " & _
                    "salarial, consistente en un auxilio que no tiene por finalidad la retribución directa del servicio para el " & _
                    "cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino para " & _
                    "buscar su mejor bienestar lo cual sirve para gastos de transporte.")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "por día calendario por periodos quincenales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este auxilio de transporte no constituye salario para ningún efecto, y se imputará a cualquier otra " & _
                    "clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del " & _
                    "presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar " & _
                    "de acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, " & _
                    "entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono " & _
                    "quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí " & _
                    "establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 45, puntoOrigen.X + 490, puntoOrigen.Y + 45) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 45)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 60, puntoOrigen.X + 490, puntoOrigen.Y + 60) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

#Region " 68 - ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL CENIT"
    Private WithEvents DocImp_AsignacionAuxilioSinIncidenciaSalarialCenit As New PrintDocument
    Private _filaAuxilioSinIncidenciaSalarialCenit As DataRow

    Private Sub DocImpr_AsignacionAuxilioSinIncidenciaSalarialCenit(sender As Object, e As PrintPageEventArgs) Handles DocImp_AsignacionAuxilioSinIncidenciaSalarialCenit.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawString("ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL PARA", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 182, puntoOrigen1.Y + 32)
        e.Graphics.DrawString("CONTRATOS CON CENIT TRANSPORTE Y LOGÍSTICA DE", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 178, puntoOrigen1.Y + 49)
        e.Graphics.DrawString("HIDROCARBUROS S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 294, puntoOrigen1.Y + 65)
        e.Graphics.DrawString("ICA-GRAL-F- 165", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 637, puntoOrigen1.Y + 75)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 134, puntoOrigen1.Y, puntoOrigen1.X + 134, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen1.X + 12, puntoOrigen1.Y + 8, 110, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y, puntoOrigen1.X + 605, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y + 53, puntoOrigen1.X + 762, puntoOrigen1.Y + 53) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 108, puntoOrigen1.X + 762, puntoOrigen1.Y + 108) 'Horizontal completa
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim puntoOrigen As New Point(33, 129)
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (14,172)")
        If resultados.Length > 0 Then
            _filaAuxilioSinIncidenciaSalarialCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioSinIncidenciaSalarialCenit("VALOR"), 2)
        End If
        puntoOrigen.Y += 63
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 50
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y = 420
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Cenit Transporte y Logística de Hidrocarburos " & _
                    "S.A., ISMOCOL S.A., concederá a Usted un beneficio en dinero de naturaleza no salarial, consistente " & _
                    "en un auxilio que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido " & _
                    "contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino por las condiciones físicas de " & _
                    "los lugares y los requerimientos especiales en la ejecución de las Actividades Propias de la Industria " & _
                    "del Petróleo.")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios, pagaderos por " & _
                    "día calendario por periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este auxilio no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o " & _
                    "beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del " & _
                    "presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de " & _
                    "acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, " & _
                    "entiende y acepta que su reconocimiento y procedencia es de mera liberalidad por parte del patrono " & _
                    "quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí " & _
                    "establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 45, puntoOrigen.X + 490, puntoOrigen.Y + 45) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 45)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 60, puntoOrigen.X + 490, puntoOrigen.Y + 60) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

End Class