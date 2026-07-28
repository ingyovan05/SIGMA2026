Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Partial Class Cl_Impresión

#Region " 9 - ASIGNACIÓN BONO DE PRODUCCIÓN"
    Private WithEvents DocImp_BONOPRODUCCION As New PrintDocument

    Private Sub DocImpr_BONOPRODUCCION(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_BONOPRODUCCION.PrintPage
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, 80, 50, 90, 70)
        Dim tab As Integer = 80
        puntoOrigen.Y = 140
        puntoOrigen.X = tab
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Codigo: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = tab
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 45
        e.Graphics.DrawString("Asunto: Asignación Bono de produccion.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Apreciado Sr. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Apreciada Sra. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("La Empresa, en forma extralegal y a titulo de mera liberalidad, ha decidido conceder a Usted  un beneficio en dinero de naturaleza no salarial, " & _
                    "consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                    "sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto " & _
                    "en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente,como también el cumplimiento y puesta en práctica de " & _
                    "las políticas de aseguramiento de la calidad de la Compañía.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero  está cuantificado en la suma de $        por dia laborado en periodos quincenales " & _
                    "vencidos y se entiende vigente a partir del                        .El pago de este bono estará supeditado a que realice como mínimo (2) pegas diarias en diámetro de 30'' pulgadas en condiciones normales de opreación " & _
                    "duranre el día laborado cumpliendo con los requisitos de calidad establecidos por la compañia.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este bono de producción no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores  en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                            "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicara la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 41)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 55, puntoOrigen.X + 557, puntoOrigen.Y + 55) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 63)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 77, puntoOrigen.X + 557, puntoOrigen.Y + 77) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 99, puntoOrigen.X + 557, puntoOrigen.Y + 99) 'Horizontal
        e.Graphics.DrawString("Huella", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 602, puntoOrigen.Y + 10)
        e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 567, puntoOrigen.Y, 100, 100, 50)
    End Sub
#End Region

#Region "ICA-GRAL-F-167 ASIGNACIÓN BONO TÉCNICO POR DIA EN OBRA"
    Private WithEvents DocImp_ICAGRALF167 As New PrintDocument
    Private Sub DocImpr_ICAGRALF167(sender As Object, e As PrintPageEventArgs) Handles DocImp_ICAGRALF167.PrintPage

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(50, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ASIGNACIÓN DE BONO TÉCNICO ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("POR DÍA EN OBRA", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA GRAL-F-167", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************

        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim valor As String = "$____________"
        puntoOrigen.Y += 63
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 125)
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
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente, como también el cumplimiento y puesta en práctica de las políticas de aseguramiento de la calidad de la Compañía. Además, busca estimular su compromiso para que no se presenten situaciones que afecten el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "por día calendario por periodos quincenales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & " Este bono no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones disfrutadas. Igualmente, no se cancelará cuando se presenten situaciones que alteren el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales.")
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
        e.Graphics.DrawString("C.C.:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub


#End Region

#Region "ICA-GRAL-F-168 ASIGNACIÓN BONO TÉCNICO POR DIA LABORADO"
    Private WithEvents DocImp_ICAGRALF168 As New PrintDocument
    Private Sub DocImpr_ICAGRALF168(sender As Object, e As PrintPageEventArgs) Handles DocImp_ICAGRALF168.PrintPage

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(50, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ASIGNACIÓN DE BONO TÉCNICO ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("POR DÍA EN LABORADO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA GRAL-F-168", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************

        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim valor As String = "$____________"
        '*******************************************************************
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 125)
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
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente, como también el cumplimiento y puesta en práctica de las políticas de aseguramiento de la calidad de la Compañía. Además, busca estimular su compromiso para que no se presenten situaciones que afecten el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "por día calendario por periodos quincenales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & " Este bono no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones disfrutadas. Igualmente, no se cancelará cuando se presenten situaciones que alteren el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales.")
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
        e.Graphics.DrawString("C.C.:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub


#End Region

#Region " 10 - ASIGNACIÓN BONO TÉCNICO"
    Private WithEvents DocImp_BONOTECNICO As New PrintDocument
    Private _filaBonoTecnicoCenit As DataRow

    Private Sub DocImpr_BONOTECNICO(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_BONOTECNICO.PrintPage
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 105")
        If resultados.Length > 0 Then
            _filaBonoTecnicoCenit = resultados(0)
        End If
        Dim puntoOrigen As New Point(20, 20)
        Const anchoParrafo As Integer = 730
        Const espacioRenglon As Integer = 16
        Dim formatoCalidad As String = ""
        Dim revisionFormato As String = ""
        Dim periodicidad As String = "            "
        Dim parrafoValor As String = ""
        Dim adicionPrimerParrafo As String = ""
        Dim adicionParrafo As String = ""
        Dim adicionPalabra As String = ""
        Dim valorBono As String = "$            "
        Dim cartaNueva As Boolean = False
        Dim reconocimientoEspecial As Boolean = False

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        If Not IsNothing(_filaBonoTecnicoCenit) Then
            valorBono = FormatCurrency(_filaBonoTecnicoCenit("VALOR"), 2)
            Select Case _filaBonoTecnicoCenit("PERIODICIDAD")
                Case "Día Calendario"
                    cartaNueva = False
                    periodicidad = "Día Calendario"
                    adicionPalabra = "en "
                Case "Día Laborado"
                    cartaNueva = True
                    formatoCalidad = "ICA-GRAL-F-168"
                    revisionFormato = "Revisión No. 2"
                    periodicidad = "Día Laborado"
                    adicionPrimerParrafo = " Además, busca estimular su compromiso para que no se presenten situaciones que afecten el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales. "
                    parrafoValor = "Este bono no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneradas o no remuneradas, incapacidades y vacaciones disfrutadas." & _
                                   " Igualmente, no se cancelará cuando se presenten situaciones que alteren el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales."
                    adicionParrafo = "diarios pagaderos proporcionalmente"
                    adicionPalabra = "por "

                Case "Día Obra"
                    cartaNueva = True
                    formatoCalidad = "ICA-GRAL-F-167"
                    revisionFormato = "Revisión No. 1"
                    periodicidad = "Día en Obra"
                    parrafoValor = "Para los días en obra se tendrán en cuenta los días domingo y festivos no laborados. " & _
                                   "Este bono no se pagará los días de permiso o licencia remunerada y no remunerada, días de incapacidad y vacaciones disfrutadas."
                    adicionPalabra = "en "
                    adicionParrafo = "diarios pagaderos proporcionalmente"
                Case "Mes"
                    cartaNueva = False
                    periodicidad = "Mes"
                Case "DORE" 'Día en obra reconocimiento especial
                    cartaNueva = True
                    formatoCalidad = "ICA-GRAL-F-169"
                    revisionFormato = "Revisión No. 1"
                    periodicidad = "Día en Obra"
                    reconocimientoEspecial = True
                    adicionPrimerParrafo = " Además de lo anterior, la Empresa le otorga esta bonificación como un reconocimiento especial por las características del lugar, del entorno y las condiciones particulares en que se presta el servicio."
                    parrafoValor = "Este bono no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneradas o no remuneradas, incapacidades y vacaciones disfrutadas."
                Case Else
                    cartaNueva = False
                    
            End Select
        End If
        If cartaNueva Then
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1015)
            e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 13, puntoOrigen.Y + 10, 110, 90)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 110) 'vertical

            e.Graphics.DrawStringCentered("ASIGNACIÓN DE BONO TÉCNICO", Formato_Etiqueta_10, Brocha, 475, puntoOrigen.X + 135, puntoOrigen.Y + 37 - If(reconocimientoEspecial, 10, 0))
            e.Graphics.DrawStringCentered("POR " & periodicidad.ToUpper, Formato_Etiqueta_10, Brocha, 475, puntoOrigen.X + 135, puntoOrigen.Y + 57 - If(reconocimientoEspecial, 10, 0))
            If reconocimientoEspecial Then
                e.Graphics.DrawStringCentered("RECONOCIMIENTO ESPECIAL", Formato_Etiqueta_10, Brocha, 475, puntoOrigen.X + 135, puntoOrigen.Y + 67)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 610, puntoOrigen.Y, puntoOrigen.X + 610, puntoOrigen.Y + 110) 'vertical
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 610, puntoOrigen.Y + 55, puntoOrigen.X + 765, puntoOrigen.Y + 55) 'horizontal
            e.Graphics.DrawStringCentered(formatoCalidad, Formato_Etiqueta_9, Brocha, 155, puntoOrigen.X + 610, puntoOrigen.Y + 20)
            e.Graphics.DrawStringCentered(revisionFormato, Formato_Etiqueta_9, Brocha, 155, puntoOrigen.X + 610, puntoOrigen.Y + 75)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 110, puntoOrigen.X + 765, puntoOrigen.Y + 110) 'Horizontal completa

            puntoOrigen.Y = 200
            puntoOrigen.X = 40
            '*******************************************************************
            e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y - 20)
            e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
            'e.Graphics.DrawString("Codigo: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
            puntoOrigen.Y += 30
            e.Graphics.DrawString("Señor (a)", Formato_Etiqueta_8R, Brocha, puntoOrigen)
            puntoOrigen.Y += 15
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y - 2)
            puntoOrigen.Y += 15
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y - 2)
            puntoOrigen.Y += 20
            e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 60
            e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_8R, Brocha, puntoOrigen)
            puntoOrigen.Y += 30
            Cadenas.Clear()
            Cadenas.Add("La Empresa, en forma extralegal y a titulo de mera liberalidad, ha decidido conceder a Usted  un beneficio en dinero de naturaleza no salarial, " & _
                        "consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                        "sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución " & _
                        "del proyecto en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente, como también el cumplimiento y puesta en práctica de " & _
                        "las políticas de aseguramiento de la calidad de la Compañía." & adicionPrimerParrafo)
            Cadena_Total.Clear()
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
            For i As Integer = 0 To Cadena_Total.Count - 1
                e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y += espacioRenglon
            Next




            Cadenas.Clear()
            Cadenas.Add("Este beneficio extralegal en dinero esta cuantificado en la suma de " & valorBono & " " & adicionParrafo & " por " & periodicidad.ToLower & ", " & _
                        "" & adicionPalabra & "periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". " & parrafoValor)
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
            For i As Integer = 0 To Cadena_Total.Count - 1
                e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y += espacioRenglon
            Next
            Cadenas.Clear()
            Cadenas.Add("Este bono técnico no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
            For i As Integer = 0 To Cadena_Total.Count - 1
                e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y += espacioRenglon
            Next
            Cadenas.Clear()
            Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                        "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
            For i As Integer = 0 To Cadena_Total.Count - 1
                e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y += espacioRenglon
            Next

            puntoOrigen.Y = (puntoOrigen.Y \ 10) * 10
            e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
            e.Graphics.DrawString("Acepto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 40)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 50, puntoOrigen.X + 490, puntoOrigen.Y + 50) 'horizontal
            e.Graphics.DrawString("C.C:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 70, puntoOrigen.X + 490, puntoOrigen.Y + 70) 'horizontal
            e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 80)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 90, puntoOrigen.X + 490, puntoOrigen.Y + 90) 'horizontal
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 520, puntoOrigen.Y - 20, 80, 100)
            e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_8R, Brocha, 80, puntoOrigen.X + 520, puntoOrigen.Y + 90)
            puntoOrigen.Y += 125
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y - 2)
            e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 15)
        Else
            puntoOrigen = New Point(80, 140)
            e.Graphics.DrawImage(logoIsmocol, 80, 50, 90, 70)
            e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
            e.Graphics.DrawString("Código: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 40
            e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", "") & ":", Formato_Etiqueta_8R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 30
            e.Graphics.DrawString("Asunto: Asignación Bono Técnico.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 30
            e.Graphics.DrawString("Apreciado Sr" & If(_filaPersona("GENERO") = "F", "a", "") & ". " + _filaPersona("NOMBRES") & ":", Formato_Etiqueta_8R, Brocha, puntoOrigen)
            puntoOrigen.Y = puntoOrigen.Y + 30

            Cadenas.Clear()
            Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, " & _
                        "consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                        "sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución " & _
                        "del proyecto en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente, como también el cumplimiento y puesta en práctica de " & _
                        "las políticas de aseguramiento de la calidad de la Compañía. Además, busca estimular su compromiso para que no se presenten situaciones que afecten el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales.")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
            Dim i As Integer
            For i = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
            Next
            puntoOrigen.Y = puntoOrigen.Y - 10
            Cadenas.Clear()
            Cadenas.Add("Este beneficio extralegal en dinero esta cuantificado en la suma de " & valorBono & " por " & periodicidad.ToLower & ", en periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
            For i = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
            Next
            puntoOrigen.Y = puntoOrigen.Y - 10
            Cadenas.Clear()
            Cadenas.Add("Este bono técnico no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro, " & _
                        "este bono no se genera durante los periodos de vacaciones, permisos o licencias renumeradas y no renumeradas, descansos compensatorios, descanso obligatorio e incapacidades.")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
            For i = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
            Next
            puntoOrigen.Y = puntoOrigen.Y - 10
            '********************************************************************
            Cadenas.Clear()
            Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                        "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
            For i = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
            Next
            puntoOrigen.Y = puntoOrigen.Y - 10

            e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 40
            e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
            e.Graphics.DrawString("Acepto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 41)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 55, puntoOrigen.X + 557, puntoOrigen.Y + 55) 'Horizontal
            e.Graphics.DrawString("C.C. No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 63)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 77, puntoOrigen.X + 557, puntoOrigen.Y + 77) 'Horizontal
            e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 85)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 99, puntoOrigen.X + 557, puntoOrigen.Y + 99) 'Horizontal
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 602, puntoOrigen.Y + 10)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 567, puntoOrigen.Y, 100, 100, 50)
            puntoOrigen.Y = puntoOrigen.Y + 118
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)

            puntoOrigen.Y = puntoOrigen.Y + 55
            e.Graphics.DrawString("''Ningún trabajo es tan importante ni tan urgente, que no podamos tomarnos el tiempo para hacerlo con", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 95, puntoOrigen.Y)
            e.Graphics.DrawString("seguridad''.", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 13)
            e.Graphics.DrawString("BOGOTÁ, CALLE 100 No. 13-76 - PISO 7 - EDIFICIO TORRE MANSAROVAR", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 160, puntoOrigen.Y + 29)
            e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55 - 69 - P.B.X. 657 33 77 - A.A. 421 - FAX: 643 13 32 (ADMINISTRACIÓN)", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 90, puntoOrigen.Y + 38)
            e.Graphics.DrawString("FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VÍA PIEDECUESTA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 47)
        End If
    End Sub
#End Region

#Region " 34 - PRESENTACIÓN DE NUEVO EMPLEADO"
    Private WithEvents DocImp_PresentacionNuevoEmpleado As New PrintDocument

    Private Sub DocImpr_PresentacionNuevoEmpleado(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_PresentacionNuevoEmpleado.PrintPage
        'e.Graphics.DrawString("PRESENTACIÓN DE NUEVO EMPLEADO", Formato_Etiqueta_8R, Brocha, 10, 10)

        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(18, 39)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 764, 990)
        e.Graphics.DrawString("PRESENTACION DE NUEVO EMPLEADO", Formato_Etiqueta_12, Brocha, 230, puntoOrigen.Y + 50)
        e.Graphics.DrawString("CONTRATO No " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_11, Brocha, 300, puntoOrigen.Y + 70)

        'Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 2, puntoOrigen.Y + 2, 130, 100)
        puntoOrigen.Y = 170

        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("PARA", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + _filaContrato("JEFEINMEDIATO"), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("CARGO", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + _filaContrato("CARGOJEFEINMEDIATO"), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("DE", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": DPTO. ADMINISTRATIVO ", Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("ASUNTO", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": INGRESO DE EMPLEADO NUEVO", Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("LUGAR Y FECHA", Formato_Etiqueta_11R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + _filaContrato("CIUDADYDEPTOCONTRATADO") + ", " + Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 49
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Presentamos la persona identificada a continuación quien ingresa a laborar bajo su dependencia y antes de iniciar labores efectuar la inducción especifica de las labores a realizar y asi mismo incluirlo a partir de la fecha de ingreso en los reportes diarios de tiempo trabajado con su respectivo código y cargo.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10, 763.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 763.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        puntoOrigen.Y = puntoOrigen.Y + 20
        '********************************************************************
        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("CODIGO", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("CEDULA", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("CARGO", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + _filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("FECHA DE INGRESO", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": " + Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("FRENTE / DEPENDENCIA", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 55
                e.Graphics.DrawString(": " + dependencia, Formato_Etiqueta_11, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
                Exit Select
            Case Else
                e.Graphics.DrawString(": " + dependencia, Formato_Etiqueta_7, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 3)
        End Select
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(": ", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 210, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 78
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 78
        If _filaContrato("IDBASESISCONTROL") = 122 Then
            e.Graphics.DrawString(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_11, Brocha, puntoOrigen.X, puntoOrigen.Y)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_11, Brocha, puntoOrigen.X, puntoOrigen.Y)
        End If
        e.Graphics.DrawString("_________________________________", Formato_Etiqueta_12R, Brocha, puntoOrigen.X - 2, puntoOrigen.Y + 3)
        e.Graphics.DrawString("_______________________________________", Formato_Etiqueta_12R, Brocha, puntoOrigen.X + 395, puntoOrigen.Y + 3)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("ADMINISTRADOR", Formato_Etiqueta_12, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Recibido Por", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 42
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 764, puntoOrigen.Y) 'Horizontal
        e.Graphics.DrawString("Nota : UNA VEZ FIRMADA POR EL ENTERADO, DEVOLVERLA A LA OFICINA DE PERSONAL", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 20, puntoOrigen.X + 764, puntoOrigen.Y + 20) 'Horizontal
        e.Graphics.DrawString("VACANTE:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y + 26)
        e.Graphics.DrawString(_filaContrato("NUMEROVACANTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 610, puntoOrigen.Y + 26)
    End Sub
#End Region

#Region " 40 - NOTIFICACIÓN DE AUMENTO DE SALARIO"
    Private WithEvents DocImp_CARTAAUMSALARIO As New PrintDocument

    Private Sub DocImpr_CARTAAUMSALARI0(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTAAUMSALARIO.PrintPage
        Dim puntoOrigen As New Point(150, 60)
        e.Graphics.DrawImage(logoIsmocol, 150, 60, 90, 65)

        puntoOrigen.Y = puntoOrigen.Y + 125
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 70
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 90
        e.Graphics.DrawString("Asunto: Notificación de Aumento de Salario", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 53
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Apreciado  " + _filaPersona("NOMBRES"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Apreciada " + _filaPersona("NOMBRES"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 36
        '********************************************************************
        Dim Cadenas As New ArrayList
        Dim salario As Double
        If _filaContrato("CODIGOTIPOSALARIO") = "M" Then
            salario = _filaContrato("SALARIO")
        Else
            salario = _filaContrato("SALARIO") * 30
        End If
        Cadenas.Add("Nos complace informarle que revisada la escala salarial usted ha sido clasificado en el grupo " & _filaContrato("NOMBRETIPOGRUPO") & ", Categoria " & _filaContrato("NOMBRETIPOCATEGORIA") & ", " & _filaContrato("NOMBRETIPOCARGO") & ", con un salario de $ " & salario & " efectivo a partir " & _
                    "del  ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 600.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10

        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Al comunicarle lo anterior deseamos felicitarle y esperamos seguir contando con su valiosa colaboración. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 600.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        '********************************************************************

        puntoOrigen.Y = puntoOrigen.Y + 22
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 35
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 90
        e.Graphics.DrawString("ALVARO ESCOBAR SAAVEDRA", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("Gerente General", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 88
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 45
        e.Graphics.DrawString("AES / hgl 592 - 91,042,977 - 9911", Formato_Etiqueta_6R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 112
        e.Graphics.DrawString("''Ningún trabajo es tan importante ni tan urgente, que no podamos tomarnos el tiempo para hacerlo con", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
        e.Graphics.DrawString("seguridad''.", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 250, puntoOrigen.Y + 13)
        e.Graphics.DrawString("BOGOTÁ, CALLE 100 No. 13-76 - PISO7 - EDIFICIO TORRE MANSAROVAR", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 92, puntoOrigen.Y + 29)
        e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55 - 69 - P.B.X.  6573377 - A.A. 421 - FAX: 6431332 (ADMINISTRACIÓN)", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 38)
        e.Graphics.DrawString("FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VIA PIEDECUESTA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 50, puntoOrigen.Y + 47)
    End Sub
#End Region

#Region " 41 - ASIGNACIÓN AUXILIO DE HABITACIÓN"
    Private WithEvents DocImp_AUXHABITACION As New PrintDocument

    Private Sub DocImpr_AUXHABITACION(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_AUXHABITACION.PrintPage
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, 80, 50, 90, 70)
        Dim tab As Integer = 80
        puntoOrigen.Y = 140
        puntoOrigen.X = tab
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Codigo: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = tab
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 45
        e.Graphics.DrawString("Asunto: Asignación Auxilio De Habitación", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Apreciado Sr. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Apreciada Sra. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("La Empresa, en forma extralegal y a titulo de mera liberalidad, ha decidido conceder a Usted  un beneficio en dinero de naturaleza no salarial, " & _
                    "consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                    "sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto " & _
                    "en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente,como también el cumplimiento y puesta en práctica de " & _
                    "las políticas de aseguramiento de la calidad de la Compañía.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero  está cuantificado en la suma de $        diarios pagaderos porporcionalmente " & _
                    "al tiempo laborado por periodos quincenales vencidos y se entiende vigente a partir del                           .")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este auxilio de habitación no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores  en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                    "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 41)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 55, puntoOrigen.X + 557, puntoOrigen.Y + 55) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 63)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 77, puntoOrigen.X + 557, puntoOrigen.Y + 77) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 99, puntoOrigen.X + 557, puntoOrigen.Y + 99) 'Horizontal
        e.Graphics.DrawString("Huella", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 602, puntoOrigen.Y + 10)
        e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 567, puntoOrigen.Y, 100, 100, 50)
        '**************************************************
        puntoOrigen.Y = puntoOrigen.Y + 118
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        puntoOrigen.Y = puntoOrigen.Y + 68
        e.Graphics.DrawString("''Ningún trabajo es tan importante ni tan urgente, que no podamos tomarnos el tiempo para hacerlo con", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 95, puntoOrigen.Y)
        e.Graphics.DrawString("seguridad''.", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 13)
        e.Graphics.DrawString("BOGOTÁ, CALLE 100 No. 13-76 - PISO7 - EDIFICIO TORRE MANSAROVAR", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 160, puntoOrigen.Y + 29)
        e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55 - 69 - P.B.X.  6573377 - A.A. 421", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 170, puntoOrigen.Y + 38)
        e.Graphics.DrawString("FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VIA PIEDECUESTA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 47)
    End Sub
#End Region

#Region " 42 - ASIGNACIÓN AUXILIO EXTRALEGALES"
    Private WithEvents DocImp_AUXEXTRALEGALES As New PrintDocument
    Private _filaAuxilioExtralegalAlimentacion As DataRow
    Private _filaAuxilioExtralegalTransporte As DataRow

    Private Sub DocImpr_AUXEXTRALEGALES(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_AUXEXTRALEGALES.PrintPage
        DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, 80, 50, 90, 70)
        Dim tab As Integer = 80
        puntoOrigen.Y = 140
        puntoOrigen.X = tab
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Codigo: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = tab
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 45
        e.Graphics.DrawString("Asunto: Asignación Auxilio Extralegales", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Apreciado Sr. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Apreciada Sra. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Cenit Transporte y Logística de Hidrocarburos S.A., " & _
                    "ISMOCOL S.A., concederá a Usted unos beneficios en dinero de naturaleza no salarial, consiste en unos auxilios extralegales que no tienen por finalidad la retribución " & _
                    "directa del servicio para el cual usted ha sido contratado, ni para enriquecer su patrimonio, sino que constituyen una contribución para su alimentación y transporte, para generarle un mayor bienestar. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Estos beneficios extralegales en dinero  están cuantificados en los conceptos y sumas que se relacionan a continuación, pagaderos en la forma y los periodos que se indican: ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 670, 69)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 3, puntoOrigen.Y + 3, 663, 63)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 3, puntoOrigen.Y + 24, puntoOrigen.X + 666, puntoOrigen.Y + 24) 'Horizontal
        e.Graphics.DrawString("Auxilio De Alimentación", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 51, puntoOrigen.Y + 29)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 3, puntoOrigen.Y + 45, puntoOrigen.X + 666, puntoOrigen.Y + 45) 'Horizontal
        e.Graphics.DrawString("Auxilio De Transporte", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 56, puntoOrigen.Y + 50)
        e.Graphics.DrawString("Concepto", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 91, puntoOrigen.Y + 8)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 238, puntoOrigen.Y + 3, puntoOrigen.X + 238, puntoOrigen.Y + 66) 'Vertical
        e.Graphics.DrawString("Valor Diario", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 253, puntoOrigen.Y + 8)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 333, puntoOrigen.Y + 3, puntoOrigen.X + 333, puntoOrigen.Y + 66) 'Vertical
        e.Graphics.DrawString("Forma Pago", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 378, puntoOrigen.Y + 8)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 498, puntoOrigen.Y + 3, puntoOrigen.X + 498, puntoOrigen.Y + 66) 'Vertical
        e.Graphics.DrawString("Periodo Pago", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 540, puntoOrigen.Y + 8)
        If Not IsNothing(_filaAuxilioExtralegalAlimentacion) Then
            e.Graphics.DrawStringCentered(FormatCurrency(_filaAuxilioExtralegalAlimentacion("VALOR"), 2), Formato_Etiqueta_8R, Brocha, 90, puntoOrigen.X + 240, puntoOrigen.Y + 29) 'Valor Diario
            e.Graphics.DrawStringCentered(_filaAuxilioExtralegalAlimentacion("PERIODICIDAD"), Formato_Etiqueta_8R, Brocha, 160, puntoOrigen.X + 335, puntoOrigen.Y + 29) 'Forma Pago
            e.Graphics.DrawStringCentered(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, 165, puntoOrigen.X + 500, puntoOrigen.Y + 29) 'Periodo Pago
        End If
        If Not IsNothing(_filaAuxilioExtralegalTransporte) Then
            e.Graphics.DrawStringCentered(FormatCurrency(_filaAuxilioExtralegalTransporte("VALOR"), 2), Formato_Etiqueta_8R, Brocha, 90, puntoOrigen.X + 240, puntoOrigen.Y + 50) 'Valor Diario
            e.Graphics.DrawStringCentered(_filaAuxilioExtralegalTransporte("PERIODICIDAD"), Formato_Etiqueta_8R, Brocha, 160, puntoOrigen.X + 335, puntoOrigen.Y + 50) 'Forma Pago
            e.Graphics.DrawStringCentered(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, 165, puntoOrigen.X + 500, puntoOrigen.Y + 50) 'Periodo Pago
        End If
        puntoOrigen.Y = puntoOrigen.Y + 80
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Los beneficios materia del presente documento se entienden vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                    "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 41)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 55, puntoOrigen.X + 557, puntoOrigen.Y + 55) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 63)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 77, puntoOrigen.X + 557, puntoOrigen.Y + 77) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 99, puntoOrigen.X + 557, puntoOrigen.Y + 99) 'Horizontal
        e.Graphics.DrawString("Huella", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 602, puntoOrigen.Y + 10)
        e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 567, puntoOrigen.Y, 100, 100, 50)
        '**************************************************
        puntoOrigen.Y = puntoOrigen.Y + 118
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        puntoOrigen.Y = puntoOrigen.Y + 68
        e.Graphics.DrawString("''Ningún trabajo es tan importante ni tan urgente, que no podamos tomarnos el tiempo para hacerlo con", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 95, puntoOrigen.Y)
        e.Graphics.DrawString("seguridad''.", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 13)
        e.Graphics.DrawString("BOGOTÁ, CALLE 100 No. 13-76 - PISO7 - EDIFICIO TORRE MANSAROVAR", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 160, puntoOrigen.Y + 29)
        e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55 - 69 - P.B.X.  6573377 - A.A. 421", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 170, puntoOrigen.Y + 38)
        e.Graphics.DrawString("FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VIA PIEDECUESTA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 47)
    End Sub
#End Region

#Region " 43 - ASIGNACIÓN AUXILIO DE ALIMENTACIÓN"
    Private WithEvents DocImp_AUXALIMENTACION As New PrintDocument

    Private Sub DocImpr_AUXALIMENTACION(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_AUXALIMENTACION.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawString("ASIGNACIÓN AUXILIO DE ALIMENTACIÓN", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 234, puntoOrigen1.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-174", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
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
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (3, 53, 64)")
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
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, concederá a Usted un beneficio en dinero de naturaleza no salarial, " & _
                    "consistente en un auxilio que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                    "sino para buscar su mejor bienestar lo cual sirve para gastos de alimentación.")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "proporcionalmente al tiempo laborado por periodos quincenales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". " & _
                    "Este auxilio no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio," & _
                    "permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones disfrutadas.")
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

#Region " 44 - ASIGNACIÓN AUXILIO DE TRANSPORTE"
    Private WithEvents DocImp_AUXTRANSPORTE As New PrintDocument

    Private Sub DocImpr_AUXTRANSPORTE(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_AUXTRANSPORTE.PrintPage
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, 80, 50, 90, 70)
        Dim tab As Integer = 80
        puntoOrigen.Y = 140
        puntoOrigen.X = tab
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Codigo: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = tab
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 45
        e.Graphics.DrawString("Asunto: Asignación Auxilio De Transporte", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Apreciado Sr. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Apreciada Sra. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("La Empresa, en forma extralegal y a titulo de mera liberalidad, ha decidido conceder a Usted  un beneficio en dinero de naturaleza no salarial, " & _
                    "consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                    "sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto " & _
                    "en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente,como también el cumplimiento y puesta en práctica de " & _
                    "las políticas de aseguramiento de la calidad de la Compañía.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero  está cuantificado en la suma de $        pagaderos proporcionalmente al tiempo, " & _
                    "laborado por periodos quincenales vencidos y se entiende vigente a partir del                           .")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este auxilio de transporte no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores  en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                    "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 41)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 55, puntoOrigen.X + 557, puntoOrigen.Y + 55) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 63)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 77, puntoOrigen.X + 557, puntoOrigen.Y + 77) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 99, puntoOrigen.X + 557, puntoOrigen.Y + 99) 'Horizontal
        e.Graphics.DrawString("Huella", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 602, puntoOrigen.Y + 10)
        e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 567, puntoOrigen.Y, 100, 100, 50)
        '**************************************************
        puntoOrigen.Y = puntoOrigen.Y + 118
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        puntoOrigen.Y = puntoOrigen.Y + 68
        e.Graphics.DrawString("''Ningún trabajo es tan importante ni tan urgente, que no podamos tomarnos el tiempo para hacerlo con", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 95, puntoOrigen.Y)
        e.Graphics.DrawString("seguridad''.", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 13)
        e.Graphics.DrawString("BOGOTÁ, CALLE 100 No. 13-76 - PISO7 - EDIFICIO TORRE MANSAROVAR", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 160, puntoOrigen.Y + 29)
        e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55 - 69 - P.B.X.  6573377 - A.A. 421", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 170, puntoOrigen.Y + 38)
        e.Graphics.DrawString("FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VIA PIEDECUESTA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 47)
    End Sub
#End Region

#Region " 45 - ASIGNACIÓN BONO DE BUEN MANTENIMIENTO Y CUIDADO DEL EQUIPO"
    Private WithEvents DocImp_BONOMANTEQUIPO As New PrintDocument

    Private Sub DocImpr_BONOMANTEQUIPO(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_BONOMANTEQUIPO.PrintPage
        
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(45, 50) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("BONO POR BUEN MANTENIMIENTO ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("Y CUIDADO DEL EQUIPO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-187", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList

        Dim periocidad As String = "$____________"
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (113)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
            periocidad = _filaAuxilioAlimentacionCenit("PERIODICIDAD")
        End If
        puntoOrigen.Y += 120
        puntoOrigen.X += 18

        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 590, puntoOrigen.Y + 5)

        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        'e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        
        e.Graphics.DrawString("Asunto:", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(" Bono por buen mantenimiento y cuidado del equipo.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 60, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y += 40
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, consistente en un bono por buen mantenimiento y cuidado del equipo que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para enriquecer su patrimonio, sino que tiene por finalidad motivar el buen mantenimiento y operación del equipo a su cargo. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("La empresa ha cuantificado este beneficio extralegal en la suma de " & valor & " pagaderos por " & periocidad & " proporcionalmente por periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este bono no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones " &
                    "disfrutadas. Igualmente, no se cancelará cuando se presenten situaciones que impidan el uso del equipo o interrumpan el normal desarrollo de las jornadas laborales. Finalmente, podrá ser suspendido este auxilio en cualquier momento sin previo aviso.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este bono por buen mantenimiento y cuidado del equipo no constituye salario para ningún efecto y se imputara a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, entiende y acepta que su reconocimiento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 16)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 61)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 75, puntoOrigen.X + 557, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 83)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 97, puntoOrigen.X + 557, puntoOrigen.Y + 97) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 105)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 119, puntoOrigen.X + 557, puntoOrigen.Y + 119) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y + 20, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 612, puntoOrigen.Y + 10)

        puntoOrigen.Y += 105
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

#Region " 46 - ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL"
    Private WithEvents DocImp_AUXSININCIDSALARIAL As New PrintDocument
    Private _filaAuxilioSinIncidenciaSalarial As DataRow

    Private Sub DocImpr_AUXSININCIDSALARIAL(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_AUXSININCIDSALARIAL.PrintPage
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawImage(logoIsmocol, 80, 50, 90, 70)
        Dim tab As Integer = 80
        puntoOrigen.Y = 140
        puntoOrigen.X = tab
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Codigo: " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = tab
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 45
        e.Graphics.DrawString("Asunto: Asignación Auxilio Sin Incidencia Salarial", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Apreciado Sr. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Apreciada Sra. " + _filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Cenit Transporte y Logística de Hidrocarburos S.A., " & _
                    "ISMOCOL S.A., en forma extralegal y a titulo de meral liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, consiste en un auxilio que no tiene por finalidad la retribución " & _
                    "directa del servicio para el cual usted ha sido contratado, ni para enriquecer su patrimonio, sino como un reconocimiento a la capacidad operativa y técnica, dada la especialidad y conocimientos que us ha acreditado para las actividades asignadas en la ejecución del proyecto. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        If Not IsNothing(_filaAuxilioSinIncidenciaSalarial) Then
            Cadenas.Add("Este beneficio extralegales en dinero está cuantificado en la suma de " & FormatCurrency(_filaAuxilioSinIncidenciaSalarial("VALOR"), 2) & ", por periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". ")
        Else
            Cadenas.Add("Este beneficio extralegales en dinero está cuantificado en la suma de $" & "            " & ", por periodos quincenales vencidos y se entiende vigente a partir del " & "                                 " & ". ")
        End If
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Este auxilio no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores  en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, " & _
                    "y deja constancia que conoce, entiende y acepta que su reconocimento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Atentamente", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 28)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 41)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 55, puntoOrigen.X + 557, puntoOrigen.Y + 55) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 63)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 77, puntoOrigen.X + 557, puntoOrigen.Y + 77) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 320, puntoOrigen.Y + 99, puntoOrigen.X + 557, puntoOrigen.Y + 99) 'Horizontal
        e.Graphics.DrawString("Huella", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 602, puntoOrigen.Y + 10)
        e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 567, puntoOrigen.Y, 100, 100, 50)
        '**************************************************
        puntoOrigen.Y = puntoOrigen.Y + 118
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        puntoOrigen.Y = puntoOrigen.Y + 68
        e.Graphics.DrawString("''Ningún trabajo es tan importante ni tan urgente, que no podamos tomarnos el tiempo para hacerlo con", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 95, puntoOrigen.Y)
        e.Graphics.DrawString("seguridad''.", Formato_Etiqueta_7I, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 13)
        e.Graphics.DrawString("BOGOTÁ, CALLE 100 No. 13-76 - PISO7 - EDIFICIO TORRE MANSAROVAR", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 160, puntoOrigen.Y + 29)
        e.Graphics.DrawString("BUCARAMANGA, CARRERA 28 No. 55 - 69 - P.B.X.  6573377 - A.A. 421", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 170, puntoOrigen.Y + 38)
        e.Graphics.DrawString("FAX: 6436361 - (COMPRAS) - MANTENIMIENTO: 6555015 - 6555023/6 - KM 12 VIA PIEDECUESTA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 47)
    End Sub
#End Region

#Region " 48 - ICA GRAL-F-127 AUTORIZACIÓN DESCUENTO APORTE SINDICAL"
    Private WithEvents DocImp_ICAGRALF127 As New PrintDocument

    Private Sub DocImpr_ICAGRALF127(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF127.PrintPage
        'e.Graphics.DrawString("ICA GRAL-F-044 SELECCIÓN DE SISTEMAS DE PENSIÓN Y SALUD", Formato_Etiqueta_8R, Brocha, 10, 10)
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(51, 20)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 741, 940)
        e.Graphics.DrawString("AUTORIZACIÓN DESCUENTO APORTE SINDICAL", Formato_Etiqueta_12, Brocha, 220, puntoOrigen.Y + 42) '(Formato_Etiqueta_10, Brocha, 280, 25)
        e.Graphics.DrawString("ICA-GRAL-F-127", Formato_Etiqueta_8, Brocha, 675, puntoOrigen.Y + 20)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_8, Brocha, 680, puntoOrigen.Y + 70)
        Dim puntorec1 As New Point(660, 30)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 142, puntoOrigen.Y, puntoOrigen.X + 142, puntoOrigen.Y + 101) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 71, 30, 100, 80)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 600, puntoOrigen.Y, puntoOrigen.X + 600, puntoOrigen.Y + 101) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 600, puntoOrigen.Y + 50, puntoOrigen.X + 741, puntoOrigen.Y + 50) 'Horizontal 
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 101, puntoOrigen.X + 741, puntoOrigen.Y + 101) 'Horizontal completa
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, 570, 135)
        puntoOrigen.Y = puntoOrigen.Y + 101
        puntoOrigen.X = puntoOrigen.X + 32
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 78)
        e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_10RS, Brocha, puntoOrigen.X + 110, puntoOrigen.Y + 78) 'Date.Now.ToLongDateString
        puntoOrigen.Y = puntoOrigen.Y + 156
        e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 28
        e.Graphics.DrawString("Base:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_10RS, Brocha, puntoOrigen.X + 60, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 69
        e.Graphics.DrawString("Afiliado a sindicato:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        e.Graphics.DrawString("SI    (__) Nombre del sindicato:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 200, puntoOrigen.Y + 14, puntoOrigen.X + 600, puntoOrigen.Y + 14) 'Horizontal 
        puntoOrigen.Y = puntoOrigen.Y + 49
        e.Graphics.DrawString("NO  (__)", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 68
        e.Graphics.DrawString("Autorizo descontar de mi salario básico la cuota sindical ordinaria:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        e.Graphics.DrawString("SI    (__) Nombre del sindicato:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 200, puntoOrigen.Y + 14, puntoOrigen.X + 600, puntoOrigen.Y + 14) 'Horizontal 
        puntoOrigen.Y = puntoOrigen.Y + 49
        e.Graphics.DrawString("NO  (__)", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 85
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 85, puntoOrigen.Y + 14, puntoOrigen.X + 400, puntoOrigen.Y + 14) 'Horizontal 
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(StrConv(_filaPersona("NOMBRECOMPLETO"), VbStrConv.ProperCase), Formato_Etiqueta_10RS, Brocha, puntoOrigen.X + 80, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("C.C.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.X = puntoOrigen.X + 80
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")) & " de " & _filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_10RS, Brocha, puntoOrigen)
    End Sub
#End Region

#Region " 51 - ICA GRAL-F-185 - CARTA ACEPTACIÓN RENUNCIA"



    Private WithEvents DocImp_CARTAACEPRENUNCIA As New PrintDocument

    Private Sub DocImpr_CARTAACEPRENUNCIA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CARTAACEPRENUNCIA.PrintPage

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
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ACEPTACIÓN RENUNCIA", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 160, puntoOrigen.Y + 40)
        e.Graphics.DrawString("ICA GRAL-F-185", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 120)
        puntoOrigen.Y += 150
        puntoOrigen.X += 20
        e.Graphics.DrawString("Ciudad y fecha: " & _filaContrato("CIUDADCONTRATADO") & ", " & If(Not IsNothing(fechaTerminacion), fechaTerminacion.Value.ToLongDateString, "                            "), Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 60
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", "") & ":", Formato_Etiqueta_12R, Brocha, puntoOrigen)
        puntoOrigen.Y += 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_12, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 20
        e.Graphics.DrawString("Cargo: " & _filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 70
        e.Graphics.DrawString("Asunto: ", Formato_Etiqueta_10RSN, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Aceptación Renuncia.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y)
        puntoOrigen.Y += 60
        e.Graphics.DrawString("Cordial saludo,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 45
        Dim Cadenas As New ArrayList
        Cadenas.Add("Le comunicamos que la empresa aceptó su renuncia al cargo de " & _filaContrato("NOMBRETIPOCARGO") & ", como es su deseo, efectiva a partir del día " & If(Not IsNothing(fechaTerminacion), fechaTerminacion.Value.ToLongDateString & ".", "                            "))

        Cadenas.Add("En consecuencia, su vinculo laboral concluirá a la finalización de la jornada del día " & If(Not IsNothing(fechaTerminacion), fechaTerminacion.Value.ToLongDateString, "                             ") & ". ")

        Cadenas.Add("Con lo anterior, podrá acercarse a la oficina de la Empresa a gestionar el pago de los salarios y prestaciones que se le adeuden, y retirar la orden para la práctica del examen médico de retiro. De no presentarse a retirar la orden para el examen dentro de los cinco días hábiles siguientes, se entenderá que ha desistido de este derecho.")

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
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y - 75, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 612, puntoOrigen.Y + 32)
        puntoOrigen.Y = puntoOrigen.Y + 25
        e.Graphics.DrawString("FIRMA DEL REPRESENTANTE", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 320, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 35
        puntoOrigen.Y += 25
        e.Graphics.DrawString("C.C.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Nómina", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 60, puntoOrigen.Y)
        e.Graphics.DrawString("Hoja de Vida", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 60, puntoOrigen.Y + 15)
    End Sub
#End Region

#Region " 54 - CARTA BONO SOLDADOR (BONO DE PRODUCCIÓN)"
    Private WithEvents DocImp_CartaBonoSoldador As New PrintDocument

    Private Sub DocImpr_CartaBonoSoldador(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CartaBonoSoldador.PrintPage
        e.Graphics.DrawString("CARTA BONO SOLDADOR (BONO DE PRODUCCIÓN)", Formato_Etiqueta_8R, Brocha, 10, 10)
    End Sub
#End Region

#Region " 72 - ASIGNACIÓN BONO DE PAZ LABORAL POR DIA LABORADO"
    Private WithEvents DocImp_ICAGRALF175 As New PrintDocument

    Private Sub DocImpr_ICAGRALF175(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF175.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawString("ASIGNACIÓN BONO DE PAZ LABORAL", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 234, puntoOrigen1.Y + 40)
        e.Graphics.DrawString("POR DÍA LABORADO", Formato_Etiqueta_10, Brocha, puntoOrigen1.X + 295, puntoOrigen1.Y + 58)
        e.Graphics.DrawString("ICA-GRAL-F- 175", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
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
        'Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (10,164)")
        'If resultados.Length > 0 Then
        '    _filaAuxilioAlimentacionCenit = resultados(0)
        '    valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
        'End If
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
        Cadenas.Add("La Empresa, en forma extralegal y a titulo de mera liberalidad, concederá a Usted  un beneficio en dinero de naturaleza no salarial, " & _
                    "consistente en un bono que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, " & _
                    "si no que busca estimular su compromiso para que no se presenten situaciones que afecten el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "proporcionalmente por día laborado por periodos quincenales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". " & _
                    "Este bono no se pagará los días de permiso o licencia remunerada y no remunerada, días de incapacidad y vacaciones disfrutadas. " & _
                    "Igualmente, no se cancelará cuando se presenten situaciones que alteren el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este bono de paz laboral no constituye salario para ningún efecto, y se imputará a cualquier otra " & _
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

#Region " 74 - ACUERDO DE CONFIDENCIALIDAD LABORAL PARA CONTRATOS CON CENIT TRANSPORTE Y LOGISTICA DE HIDROCARBUROS "
    Private WithEvents DocImp_ICAGRALF179 As New PrintDocument
    Private Nueva_Pagina179 As Integer = 1
    Private Sub DocImpr_ICAGRALF179(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF179.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawStringCentered("ACUERDO DE CONFIDENCIALIDAD LABORAL", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 28)
        e.Graphics.DrawStringCentered("PARA CONTRATOS CON CENIT TRANSPORTE Y", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 48)
        e.Graphics.DrawStringCentered("LOGISTICA DE HIDROCARBUROS", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 68)
        e.Graphics.DrawString("ICA-GRAL-F- 179", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 637, puntoOrigen1.Y + 75)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 134, puntoOrigen1.Y, puntoOrigen1.X + 134, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen1.X + 12, puntoOrigen1.Y + 8, 110, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y, puntoOrigen1.X + 605, puntoOrigen1.Y + 108) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 605, puntoOrigen1.Y + 53, puntoOrigen1.X + 762, puntoOrigen1.Y + 53) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 108, puntoOrigen1.X + 762, puntoOrigen1.Y + 108) 'Horizontal completa
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, 570, 135)
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim puntoOrigen As New Point(33, 129)
        Dim fechaContratacion As Date
        fechaContratacion = _filaContrato("FECHAINGRESO")

        Select Case (Nueva_Pagina179)
            Case 1
                puntoOrigen.Y += 38
                Cadenas.Add("Entre los suscritos ISMOCOL S.A. (EMPLEADOR), sociedad comercial identificada con NIT. 890.209.174-1, representada en este acto por " + _filaBaseConfiguracion("RESIDENTE") + ", identificado con  " & _
                            "la C.C. No. " & FuncionesBase.FuncionesBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) + " de " + _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE") + ", obrando como representante del EMPLEADOR, y  " + _filaPersona("NOMBRECOMPLETO") + " (TRABAJADOR), identificado con la c.c. " & FuncionesBase.FuncionesBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) + " de " + _filaPersona("CIUDADEXPEDICION") + ", " & _
                            "han convenido pactar un acuerdo de confidencialidad laboral, el cual se regulará por las siguientes cláusulas: ")
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i As Integer = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("PRIMERO. OBJETO: Por virtud de esta declaración el TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o del cliente CENIT " & _
                            "TRANSPORTE Y LOGISTICA DE HIDROCARBUROS. ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i As Integer = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("SEGUNDO. INFORMACIÓN CONFIDENCIAL: Para el objetivo de este Acuerdo se considerará como Información Confidencial, sin limitarse a las siguientes: Cualquier información, observación, reporte, " & _
                            "comunicación, datos, material escrito, oral, audio-visual, registro, documento, dibujos, fotografías, planos, esquemas, software, invención, descubrimiento, mejora, desarrollo, instrumento, máquina, aparato,  " & _
                            "aplicación, diseño, sistema, idea promocional, lista de clientes y proveedores, práctica, normativas internas, información de precios, procesos, pruebas, concepto, fórmulas, métodos, información de mercado, técnicas,  " & _
                            "productos, organización, control de comercialización, publicidad, estrategias de negocio o fondos del EMPLEADOR, sus accionistas, sociedades matrices y subordinadas, o del cliente CENIT TRANSPORTES Y " & _
                            "LOGISTICA DE HIDROCARBUROS, que hubiesen sido conocidas por el TRABAJADOR con razón o con LOGISTICA DE HIDROCARBUROS, que hubiesen sido conocidas por el TRABAJADOR con razón o con ocasión del ejercicio de sus funciones. ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("También se considerará información confidencial toda aquella de las mismas características ya mencionadas, cuando provenga de los clientes, contratistas o proveedores del EMPLEADOR, aun cuando sea divulgada  " & _
                            "de manera directa por el mismo cliente, contratista o proveedor al TRABAJADOR. ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("Cualquier análisis, trabajo, compilación, investigación, informe y cualquier otro documento que el trabajador prepare con base en la Información Confidencial, también se considera amparada por este Acuerdo. ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("TERCERO. DURACIÓN DEL ACUERDO: Este Acuerdo de Confidencialidad inicia desde el día " & fechaContratacion.Day & " de " & fechaContratacion.ToString("MMMM") & " de " & fechaContratacion.Year & ", que es la fecha de inicio del contrato de trabajo suscrito entre Las Partes, y permanecerá vigente aún después de terminada la relación laboral por tiempo indefinido.   ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("CUARTO. OBLIGACIONES DEL TRABAJADOR: ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("Tratar con estricta reserva toda la Información Confidencial recibida directa o indirectamente del EMPLEADOR, sus clientes, contratistas y proveedores. ")
                Cadenas.Add("Emplear la Información Confidencial única y exclusivamente para el desarrollo de sus labores al servicio del EMPLEADOR.  ")
                Cadenas.Add("No manejar, emplear, usar, explotar, o divulgar la Información Confidencial a ninguna persona o entidad por ningún motivo " & _
                            "en contravención a lo dispuesto en este Acuerdo, incluso con posterioridad a la finalización del contrato de trabajo, salvo que sea expresamente autorizado por escrito a hacerlo por el EMPLEADOR. ")
                Cadenas.Add("Devolver inmediatamente se le solicite por parte del EMPLEADOR o a la terminación del contrato de trabajo, toda la Información Confidencial que se le haya proporcionado, o a la que haya tenido acceso. ")
                Cadenas.Add("Notificar al EMPLEADOR de cualquier descubrimiento que haya hecho, considerándose esto como Información Confidencial.  ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo - 15, e)
                For i = 0 To Cadena_Total.Count - 1
                    Select Case i
                        Case 0
                            e.Graphics.DrawString("a)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        Case 2
                            e.Graphics.DrawString("b)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        Case 5
                            e.Graphics.DrawString("c)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        Case 10
                            e.Graphics.DrawString("d)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        Case 14
                            e.Graphics.DrawString("e)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    End Select
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo - 15, e)
                    If Trim(texto) <> "" Then
                        e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 15, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    End If
                Next
            Case 2
                puntoOrigen.Y += 38
                Cadenas.Clear()
                Cadenas.Add("Notificar al EMPLEADOR en caso de recibir un requerimiento de autoridad administrativa o judicial donde se le conmine a revelar Información Confidencial, con el fin de que el EMPLEADOR pueda formular la  " & _
                            "oposición que corresponda. En caso de verse obligado a revelar Información Confidencial, hacer su mejor esfuerzo para garantizar el mayor grado de confidencialidad posible. ")
                Cadenas.Add("Tomar las precauciones que sean necesarias para evitar la divulgación, fuga o uso no autorizado de Información Confidencial, protegiéndola de la misma manera que protege su información confidencial personal. ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo - 15, e)
                For i = 0 To Cadena_Total.Count - 1
                    Select Case i
                        Case 0
                            e.Graphics.DrawString("f)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        Case 6
                            e.Graphics.DrawString("g)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    End Select
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo - 15, e)
                    If Trim(texto) <> "" Then
                        e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 15, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    End If
                Next
                puntoOrigen.Y += espacioRenglon
                Cadenas.Clear()
                Cadenas.Add("QUINTO. FACULTADES DEL EMPLEADOR: ")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
                    e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y += espacioRenglon
                Next
                Cadenas.Clear()
                Cadenas.Add("El EMPLEADOR puede disponer libremente de toda su Información Confidencial, por lo que el TRABAJADOR no tendrá ninguna autoridad para ejercer cualquier derecho o privilegio en lo que  " & _
                            "concierne a la información perteneciente exclusivamente al EMPLEADOR poseída por o asignada a esta última conforme a este Acuerdo y las leyes colombianas. ")
                Cadenas.Add("Toda la Información Confidencial creada, inventada, concebida o descubierta por el TRABAJADOR que esté sujeta a derechos de autor explícitamente, corresponde a trabajos propios de la labor contratada y " & _
                            "son de propiedad del EMPLEADOR.")
                Cadena_Total.Clear()
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
                For i = 0 To Cadena_Total.Count - 1
                    Select Case i
                        Case 0
                            e.Graphics.DrawString("a)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        Case 4
                            e.Graphics.DrawString("b)", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    End Select
                    Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo - 15, e)
                    If Trim(texto) <> "" Then
                        e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 15, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    End If
                Next


                '**************************************************
                e.Graphics.DrawString("En constancia se firma a los " & fechaContratacion.Day & " días del mes " & fechaContratacion.ToString("MMMM") & " de  " & fechaContratacion.Year & " .", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 15)
                puntoOrigen.Y += 30
                e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
                e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 370, puntoOrigen.Y + 30)
                e.Graphics.DrawString(_filaBaseConfiguracion("RESIDENTE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 133)
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 370, puntoOrigen.Y + 133)
                e.Graphics.DrawString("C.C. " & FuncionesBase.FuncionesBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) + "  de " + _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE") + "", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 160)
                e.Graphics.DrawString("C.C. " & FuncionesBase.FuncionesBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) + "  de " + _filaPersona("CIUDADEXPEDICION") + "", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 370, puntoOrigen.Y + 160)

        End Select
        Nueva_Pagina179 += 1
        If Nueva_Pagina179 = 2 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            Nueva_Pagina179 = 1
        End If


    End Sub
#End Region

#Region " 76 -ICA-GRAL-F-172 ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. -OCENSA"
    Private WithEvents DocImp_ICAGRALF172 As New PrintDocument
    Private _filaAuxilioSinIncidenciaSalarialOcensa As DataRow

    Private Sub DocImpr_ICAGRALF172(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF172.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawStringCentered("ASIGNACIÓN AUXILIO SIN INCIDENCIA SALARIAL", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 32)
        e.Graphics.DrawStringCentered("PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. - OCENSA", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 49)
        e.Graphics.DrawString("ICA-GRAL-F-172", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
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
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] =85")
        If resultados.Length > 0 Then
            _filaAuxilioSinIncidenciaSalarialOcensa = resultados(0)
            valor = FormatCurrency(_filaAuxilioSinIncidenciaSalarialOcensa("VALOR"), 2)
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
        'e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y = 420
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Oleoducto Central S.A. - OCENSA, ISMOCOL S.A., concederá a " & _
                    "Usted un beneficio en dinero de naturaleza no salarial, consistente en un auxilio que no tiene por finalidad la retribución " & _
                    "directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino por " & _
                    "las condiciones físicas de los lugares y los requerimientos especiales en la ejecución de las Actividades Propias de la " & _
                    "Industria del Petróleo. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next

        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios, pagaderos por día calendario por " & _
                    "periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". " & _
                    "Este auxilio se liquidará en los casos de incapacidad, permiso remunerado, o licencias remuneradas (Luto, Maternidad, Paternidad). No habrá lugar a su " & _
                    "reconocimiento en los casos en los que éste sea imputable al trabajador, como ausencias injustificadas al trabajo, permisos no remunerados y en los casos de suspensión de contrato previstos en el art. 51 del CST. ")
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
        e.Graphics.DrawString("C.C:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 45)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 60, puntoOrigen.X + 490, puntoOrigen.Y + 60) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

#Region " 77 - ICA-GRAL-F-171 ASIGNACIÓN AUXILIO DE ALIMENTACIÓN PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. -OCENSA"
    Private WithEvents DocImp_AsignacionAuxilioAlimentacionOcensa As New PrintDocument
    Private _filaAuxilioAlimentacionOcensa As DataRow

    Private Sub DocImpr_AsignacionAuxilioAlimentacionOcensa(sender As Object, e As PrintPageEventArgs) Handles DocImp_AsignacionAuxilioAlimentacionOcensa.PrintPage

        Dim puntoOrigen1 As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz_Mediano, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawStringCentered("ASIGNACIÓN AUXILIO DE ALIMENTACIÓN", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 40)
        e.Graphics.DrawStringCentered("PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. - OCENSA", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 58)
        e.Graphics.DrawString("ICA-GRAL-F-171", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
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
        Dim puntoOrigen As New Point(50, 129)
        Dim valor As String = "$____________"
        Dim periocidad As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (84,168)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionOcensa = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionOcensa("VALOR"), 2)
            periocidad = _filaAuxilioAlimentacionOcensa("PERIODICIDAD")
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
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Oleoducto Central S.A. - OCENSA, ISMOCOL S.A., concederá a " & _
                    "Usted un beneficio en dinero de naturaleza no salarial, consistente en un auxilio que no tiene por finalidad la retribución " & _
                    "directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino " & _
                    "para buscar su mejor bienestar lo cual sirve para gastos de alimentación. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "por " & periocidad.ToLower & " por periodos quincenales vencidos y se entiende vigente a " & _
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
        e.Graphics.DrawString("C.C.:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

#Region " 78 - ICA-GRAL-F-170 ASIGNACIÓN AUXILIO DE TRANSPORTE PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. - OCENSA "
    Private WithEvents DocImp_AsignacionAuxilioTransporteOcensa As New PrintDocument
    Private _filaAuxilioTransporteOcensa As DataRow

    Private Sub DocImpr_AsignacionAuxilioTransporteOcensa(sender As Object, e As PrintPageEventArgs) Handles DocImp_AsignacionAuxilioTransporteOcensa.PrintPage
        Dim puntoOrigen1 As New Point(18, 19)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen1.X, puntoOrigen1.Y, 762, 1010)
        e.Graphics.DrawStringCentered("ASIGNACIÓN AUXILIO DE TRANSPORTE ", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 40)
        e.Graphics.DrawStringCentered("PARA CONTRATOS CON OLEODUCTO CENTRAL S.A. - OCENSA", Formato_Etiqueta_10, Brocha, 471, puntoOrigen1.X + 134, puntoOrigen1.Y + 58)
        e.Graphics.DrawString("ICA-GRAL-F- 170", Formato_Etiqueta_9, Brocha, puntoOrigen1.X + 631, puntoOrigen1.Y + 20)
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
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (83,169)")
        If resultados.Length > 0 Then
            _filaAuxilioTransporteOcensa = resultados(0)
            valor = FormatCurrency(_filaAuxilioTransporteOcensa("VALOR"), 2)
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
        Cadenas.Add("En cumplimiento de las obligaciones establecidas por Oleoducto Central S.A. - OCENSA, ISMOCOL S.A., concederá a " & _
                    "Usted un beneficio en dinero de naturaleza no salarial, consistente en un auxilio que no tiene por finalidad la retribución " & _
                    "directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino " & _
                    "para buscar su mejor bienestar lo cual sirve para gastos de transporte. ")
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
        e.Graphics.DrawString("C.C.:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 290, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 340, puntoOrigen.Y + 75, puntoOrigen.X + 490, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y, 80, 100)
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_9R, Brocha, 80, puntoOrigen.X + 510, puntoOrigen.Y + 100)
        puntoOrigen.Y += 80
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub
#End Region

#Region " 79 - ICA GRAL-F-178 ASIGNACIÓN AUXILIO POR USO DE HERRAMIENTA MENOR"

    Public WithEvents DocImp_ICAGRALF178 As New PrintDocument

    Public Sub DocImpr_ICAGRALF178(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF178.PrintPage
        ICAGRALF178(e)
    End Sub

    Public Sub ICAGRALF178(ByVal e As System.Drawing.Printing.PrintPageEventArgs)


        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(45, 50) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ASIGNACIÓN AUXILIO POR", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("USO DE HERRAMIENTA MENOR", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-178", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList

        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (175)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
        End If
        puntoOrigen.Y += 120
        puntoOrigen.X += 18

        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 570, puntoOrigen.Y + 5)

        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y += 40
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, " & _
                    "consistente en un auxilio que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino que se genera en compensación por el uso de herramienta menor de su propiedad en actividades de la Compañía.")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " diarios pagaderos " & _
                    "proporcionalmente por día laborado por periodos mensuales vencidos y se entiende vigente a " & _
                    "partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ". " & _
                    "Este auxilio no se pagará los días de permiso o licencia remunerada y no remunerada, días de incapacidad y vacaciones disfrutadas. " & _
                    "Igualmente, no se cancelará cuando se presenten situaciones que impidan el uso de la herramienta menor o " & _
                    "interrumpan el normal desarrollo de las jornadas laborales. Para el pago se deberá diligenciar un cuadro de " & _
                    "control mensual de alquiler de herramienta firmado y autorizado donde efectivamente se evidencie el uso de " & _
                    "la herramienta. Finalmente, podrá ser suspendido este auxilio en cualquier momento sin previo aviso.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este auxilio por uso de herramienta menor no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
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
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 16)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 61)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 75, puntoOrigen.X + 557, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 83)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 97, puntoOrigen.X + 557, puntoOrigen.Y + 97) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 105)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 119, puntoOrigen.X + 557, puntoOrigen.Y + 119) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y + 20, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 612, puntoOrigen.Y + 10)

        puntoOrigen.Y += 105
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub


#End Region
   
#Region " 80 - ICA GRAL-F-187 BONO POR BUEN MANTENIMIENTO Y CUIDADO DEL EQUIPO"

    Public WithEvents DocImp_ICAGRALF187 As New PrintDocument

    Public Sub DocImpr_ICAGRALF187(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF187.PrintPage
        ICAGRALF187(e)
    End Sub

    Public Sub ICAGRALF187(ByVal e As System.Drawing.Printing.PrintPageEventArgs)


        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(45, 50) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("BONO POR BUEN MANTENIMIENTO ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("Y CUIDADO DEL EQUIPO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-187", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList

        Dim periocidad As String = "$____________"
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (175)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
            periocidad = _filaAuxilioAlimentacionCenit("PERIODICIDAD")
        End If
        puntoOrigen.Y += 120
        puntoOrigen.X += 18

        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 590, puntoOrigen.Y + 5)

        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        'puntoOrigen.Y += 15
        'e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        'puntoOrigen.Y += 15
        'e.Graphics.DrawString("Presente", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Asunto:", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(" Bono por buen mantenimiento y cuidado del equipo.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 60, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y += 40
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido conceder a Usted un beneficio en dinero de naturaleza no salarial, consistente en un bono por buen mantenimiento y cuidado del equipo que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para enriquecer su patrimonio, sino que tiene por finalidad motivar el buen mantenimiento y operación del equipo a su cargo. ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("La empresa ha cuantificado este beneficio extralegal en la suma de " & valor & " pagaderos por " & periocidad & " proporcionalmente por periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este bono no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones " &
                    "disfrutadas. Igualmente, no se cancelará cuando se presenten situaciones que impidan el uso del equipo o interrumpan el normal desarrollo de las jornadas laborales. Finalmente, podrá ser suspendido este auxilio en cualquier momento sin previo aviso.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este bono por buen mantenimiento y cuidado del equipo no constituye salario para ningún efecto y se imputara a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, entiende y acepta que su reconocimiento y procedencia es de mera liberalidad por parte del patrono quien se reserva el derecho a suprimirlo cuando lo estimare conveniente. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Sírvase suscribir la copia del presente en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 16)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 61)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 75, puntoOrigen.X + 557, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 83)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 97, puntoOrigen.X + 557, puntoOrigen.Y + 97) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 105)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 119, puntoOrigen.X + 557, puntoOrigen.Y + 119) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y + 20, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 612, puntoOrigen.Y + 10)

        puntoOrigen.Y += 105
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub


#End Region

#Region " 81 - ICA GRAL-F-190  Asignación Prima Técnica Perforación"

    Public WithEvents DocImp_ICAGRALF190 As New PrintDocument

    Public Sub DocImpr_ICAGRALF190(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF190.PrintPage
        ICAGRALF190(e)
    End Sub

    Public Sub ICAGRALF190(ByVal e As System.Drawing.Printing.PrintPageEventArgs)


        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(40, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ASIGNACIÓN DE PRIMA ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("TÉCNICA DE PERFORACIÓN", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-190", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList

        Dim periocidad As String = "____________"
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (117)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
            periocidad = _filaAuxilioAlimentacionCenit("PERIODICIDAD")
        End If
        puntoOrigen.Y += 120
        puntoOrigen.X += 18

        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 590, puntoOrigen.Y + 5)

        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Asunto:", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Asignación de prima técnica de perforación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 60, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y += 40
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido concederle un beneficio en dinero de naturaleza no salarial, consistente en una prima técnica que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente, como también el cumplimiento y puesta en práctica de las políticas de aseguramiento de la calidad de la Compañía.  ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " pagaderos por " & periocidad & ", proporcionalmente por periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este concepto no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones disfrutadas. Igualmente, no se cancelará cuando se presenten situaciones que alteren el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales. Finalmente, podrá ser suspendido este beneficio en cualquier momento sin previo aviso. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Esta Prima Técnica de Perforación no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, entiende y acepta que su reconocimiento y procedencia es de mera liberalidad por parte de la Empresa. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Si usted está de acuerdo, sírvase firmar en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 16)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 61)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 75, puntoOrigen.X + 557, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 83)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 97, puntoOrigen.X + 557, puntoOrigen.Y + 97) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 105)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 119, puntoOrigen.X + 557, puntoOrigen.Y + 119) 'Horizontal

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 630, puntoOrigen.Y + 20, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 660, puntoOrigen.Y + 10)

        puntoOrigen.Y += 105
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub


#End Region

#Region " 82 - ICA GRAL-F-191 Asignación Prima Técnica Mantenimiento"

    Public WithEvents DocImp_ICAGRALF191 As New PrintDocument

    Public Sub DocImpr_ICAGRALF191(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF191.PrintPage
        ICAGRALF191(e)
    End Sub

    Public Sub ICAGRALF191(ByVal e As System.Drawing.Printing.PrintPageEventArgs)


        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(40, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ASIGNACIÓN DE PRIMA TÉCNICA ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("DE MANTENIMIENTO DE POZOS", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA-GRAL-F-191", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************  
        Const espacioRenglon As Integer = 16
        Const anchoParrafo As Integer = 730
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList

        Dim periocidad As String = "____________"
        Dim valor As String = "$____________"
        Dim resultados() As DataRow = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (118)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionCenit = resultados(0)
            valor = FormatCurrency(_filaAuxilioAlimentacionCenit("VALOR"), 2)
            periocidad = _filaAuxilioAlimentacionCenit("PERIODICIDAD")
        End If
        puntoOrigen.Y += 120
        puntoOrigen.X += 18

        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 590, puntoOrigen.Y + 5)

        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Señor" & If(_filaPersona("GENERO") = "F", "a", ""), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 15
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Asunto:", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Asignación de prima técnica de mantenimiento de pozos.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 60, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Apreciad" & If(_filaPersona("GENERO") = "F", "a", "o") & " señor" & If(_filaPersona("GENERO") = "F", "a", "") & " " & _filaPersona("NOMBRES") & ":", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y += 40
        Cadenas.Add("La Empresa, en forma extralegal y a título de mera liberalidad, ha decidido concederle un beneficio en dinero de naturaleza no salarial, consistente en una prima técnica que no tiene por finalidad la retribución directa del servicio para el cual usted ha sido contratado, ni para su beneficio, ni para enriquecer su patrimonio, sino que constituye un reconocimiento a la capacidad operativa y técnica dada la especialidad y conocimientos que usted ha acreditado y el grado de importancia de estos conocimientos para la ejecución del proyecto en la actividad para la cual usted ha sido contratado. De igual manera se busca estimular y premiar su buen desempeño en salud ocupacional y medio ambiente, como también el cumplimiento y puesta en práctica de las políticas de aseguramiento de la calidad de la Compañía.   ")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este beneficio extralegal en dinero está cuantificado en la suma de " & valor & " pagaderos por " & periocidad & ", proporcionalmente por periodos quincenales vencidos y se entiende vigente a partir del " & DirectCast(_filaContrato("FECHAINGRESO"), Date).ToString("d \d\e MMMM \d\e yyyy") & ".")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Este concepto no se pagará los días de descanso obligatorio, descanso remunerado, descanso compensatorio, permisos o licencias remuneras o no remuneradas, incapacidades y vacaciones disfrutadas. Igualmente, no se cancelará cuando se presenten situaciones que alteren el ambiente laboral o interrumpan el normal desarrollo de las jornadas laborales. Finalmente, podrá ser suspendido este beneficio en cualquier momento sin previo aviso.  ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i As Integer = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Esta Prima Técnica de Mantenimiento de Pozos no constituye salario para ningún efecto, y se imputará a cualquier otra clase de bono o beneficio extralegal que la empresa concediere a sus trabajadores en el futuro.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        Cadenas.Clear()
        Cadenas.Add("Igualmente, con fundamento en el artículo 128 del Código Sustantivo del Trabajo, con la firma del presente documento, Usted en calidad de empleado deja expreso consentimiento y manifiesta estar de acuerdo con la naturaleza no salarial de este beneficio económico, y deja constancia que conoce, entiende y acepta que su reconocimiento y procedencia es de mera liberalidad por parte de la Empresa. Si por la vigencia aquí establecida hubiere reconocimientos retroactivos oportunamente indicará la fecha y el monto de su pago.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, anchoParrafo, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, anchoParrafo, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += espacioRenglon
        Next
        '**************************************************
        e.Graphics.DrawString("Si usted está de acuerdo, sírvase firmar en señal de aceptación.", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 40
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 16)
        e.Graphics.DrawString("Acepto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 61)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 75, puntoOrigen.X + 557, puntoOrigen.Y + 75) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 83)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 97, puntoOrigen.X + 557, puntoOrigen.Y + 97) 'Horizontal
        e.Graphics.DrawString("C.C.No:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 105)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 119, puntoOrigen.X + 557, puntoOrigen.Y + 119) 'Horizontal

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 630, puntoOrigen.Y + 20, 90, 120)   '' huella
        e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 660, puntoOrigen.Y + 10)

        puntoOrigen.Y += 105
        e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Copia: Hoja de Vida", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
    End Sub


#End Region



End Class