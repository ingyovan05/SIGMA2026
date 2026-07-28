Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms

Partial Class Cl_Impresión

#Region " 8 - ICH GRAL-F-081 ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO O ENFERMEDAD LABORAL"
    Private WithEvents DocImp_ICHGRALF81 As New PrintDocument
    'Actualización del formato ICH GRAL-F-081
    Private Sub DocImpr_ICHGRALF81(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF81.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(50, 40)

        '*******************************************************************ENCABEZADO*******************************************************
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 20)
        e.Graphics.DrawStringAligned("DE REPORTAR ACCIDENTES DE TRABAJO O", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 40)
        e.Graphics.DrawStringAligned("ENFERMEDAD LABORAL", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 60)
        e.Graphics.DrawString("ICH-GRAL-F-081", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '************************************************************************************************************************************
        Dim puntorec1 As New Point(660, 30)
        '*******************************************************************
        puntorec1.X = 200
        puntorec1.Y = 80

        puntoOrigen.Y = 180
        puntoOrigen.X = 90

        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_12R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 480, puntoOrigen.Y + 15)
        e.Graphics.DrawString("No. Cédula:", Formato_Etiqueta_12R, Brocha, puntoOrigen.X + 490, puntoOrigen.Y)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 580, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 585, puntoOrigen.Y + 15, puntoOrigen.X + 680, puntoOrigen.Y + 15)

        puntoOrigen.Y += 40
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_12R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 125, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 15, puntoOrigen.X + 480, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Contrato:", Formato_Etiqueta_12R, Brocha, puntoOrigen.X + 490, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 580, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 585, puntoOrigen.Y + 15, puntoOrigen.X + 680, puntoOrigen.Y + 15)

        puntoOrigen.Y += 50
        Dim Cadenas As New ArrayList
        Cadenas.Add("En virtud de las obligaciones contenidas en los artículos 111 (seguridad y salud en el trabajo), 112 (cumplimiento de instrucciones médicas), 113 (cumplimiento de las medidas de higiene y seguridad industrial), 114 (uso de elementos de protección personal), 115 (obligaciones especiales y de estricto cumplimiento en materia de seguridad y salud en el trabajo) 116 (aviso que debe dar el trabajador sobre accidente de trabajo, enfermedad o dolencia física), numerales 13, 15 y 17 del artículo 178 (deberes especiales de los trabajadores) y numerales 5, 8, 9, 10, 11, 12, 15, 17, 18 del artículo 181 (obligaciones especiales de los trabajadores) del Reglamento de Trabajo de ISMOCOL S.A., me comprometo de manera especial a lo siguiente:")
        Cadenas.Add("Aceptar y cumplir la obligación de reportar inmediatemente a mi superior o responsable de HSE, información clara, veraz y completa de cualquier tipo de accidente, lesión o dolencia ocurrida durante la jornada de trabajo, para lo cual emplearé cualquier medio idóneo, preferiblemente por escrito, y verificaré que el reporte ha sido tramitado adecuadamente ante la Administración de la Empresa.")
        Cadenas.Add("Como trabajador de ISMOCOL S.A., declaro haber recibido inducción sobre la Política de Seguridad, Salud en el Trabajo y Ambiental, así como los riesgos a los que estaré expuesto en ejercicio de las funciones de mi cargo, las medidas tomadas para su control, y lo concerniente al Sistema de Gestión en SSTA de la Compañía.")
        Cadenas.Add("Acepto que la Empresa sea exonerada la responsabilidad por reporte extemporaneo, en caso que yo no avise en forma oportuna y veraz del accidente, incidente, evento o dolencia, de conformidad con lo dispuesto en el artículo 221 del Código Sustantivo del Trabajo. Comprendo que no reportar el evento de forma oportuna, puede dar lugar a sanciones disciplinarias o terminación del contrato de trabajo.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 18 'espacioParrafo
        Next

        puntoOrigen.Y += 20
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)

        puntoOrigen.Y += 70
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Cargo: ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Código:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)


    End Sub
#End Region

#Region " 16 - ICH GRAL-F-014 COMPROMISO Y ACEPTACIÓN DE LA POLÍTICA DE NO CONSUMO DE SUSTANCIAS PSICOACTIVAS Y ALCOHOL"
    Private WithEvents DocImp_ICHGRALF14 As New PrintDocument

    Private Sub DocImpr_ICHGRALF14(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF14.PrintPage

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        Dim puntoOrigen As New Point(50, 40)
        '*******************************************************************ENCABEZADO*******************************************************
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("COMPROMISO Y ACEPTACIÓN DE LA POLÍTICA DE", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 20)
        e.Graphics.DrawStringAligned("NO CONSUMO DE SUSTANCIAS PSICOACTIVAS", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 40)
        e.Graphics.DrawStringAligned("Y ALCOHOL", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 60)
        e.Graphics.DrawString("ICH-GRAL-F-014", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 4", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '************************************************************************************************************************************
        Dim puntorec1 As New Point(660, 30)
        '*******************************************************************
        puntorec1.X = 200
        puntorec1.Y = 90
      
        puntoOrigen.Y = 240
        puntoOrigen.X = 80

        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString("_________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y)
        e.Graphics.DrawString("No. Cedula:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 470, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y - 2)
        e.Graphics.DrawString("______________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y - 2)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString("_________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y)
        e.Graphics.DrawString("Contrato:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 470, puntoOrigen.Y)
        Dim temp_string As String = _filaContrato("CIUDADCONTRATADO") + ", " + Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy")
        If temp_string.Length < 45 Then
            e.Graphics.DrawString(temp_string, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(temp_string, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y - 2)
        End If
        e.Graphics.DrawString("______________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y - 2)
        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo * 3
        Dim Cadenas As New ArrayList
        Cadenas.Add("Como trabajador de ISMOCOL S.A., declaro haber recibido inducción sobre la Política de no consumo de sustancias psicoactivas y alcohol, y estar enterado de los efectos nocivos y secuelas de su consumo antes o durante el trabajo.")
        Cadenas.Add("Para verificar el cumplimiento de esta Política de no consumo de sustancias psicoactivas y alcohol, ISMOCOL S.A. podrá practicarme muestras de sangre, de orina o de aire espirado, con el objeto de establecer que no ingresé a las áreas de trabajo bajo la influencia de estas sustancias. Esta muestra podrá ser tomada de manera directa o aleatoria.")
        Cadenas.Add("En virtud de las obligaciones contenidas en los artículos 156 y siguientes del capítulo XXIV normas especiales sobre sustancias psicoactivas y alcohol, numerales 5, 21 y 22 del artículo 178 (deberes especiales de los trabajadores), numerales 21 y 39 del artículo 181 (obligaciones especiales del trabajador), numerales 5 y 10 del artículo 182 (prohibiciones especiales para el trabajador) del Reglamento de Trabajo, me comprometo a:")
        Cadenas.Add("Cumplir con la Política de no consumo de sustancias psicoactivas y alcohol y demás normas referentes al consumo de estas sustancias. Para tal efecto acepto que me sean practicados los exámenes o pruebas necesarios para determinar su cumplimiento. En caso de negarme, asumiré las consecuencias que esta determinación conlleve, según lo dispuesto en el Reglamento de Trabajo y demás normas aplicables.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 70
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Cargo: ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Código:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
    End Sub
#End Region

#Region " 17 - ICS GRAL-F203 COMPROMISO Y ACEPTACIÓN DE LA POLÍTICA Y PLAN ESTRATÉGICO DE SEGURIDAD VIAL PESV"
    Private WithEvents DocImp_ICSGRALF203 As New PrintDocument

    Private Sub DocImpr_ICSGRALF203(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICSGRALF203.PrintPage
        Brocha.Color = Color.Black
        Dim renglon As Integer = 255 'Espacio entre líneas horizontales
        Const alturaLinea As Integer = 20
        e.Graphics.DrawRectangle(Lapiz_Grueso, 40, 20, 730, 945)
        e.Graphics.DrawImage(logoIsmocol, 60, 30, 110, 85)
        e.Graphics.DrawLine(Lapiz, 185, 20, 185, 120) 'División vertical entre el título y el logo de Ismocol
        e.Graphics.DrawString("COMPROMISO Y ACEPTACIÓN DE LA POLÍTICA Y PLAN", Formato_Etiqueta_11, Brocha, 195, 50)
        e.Graphics.DrawString("ESTRATÉGICO DE SEGURIDAD VIAL - ""PESV""", Formato_Etiqueta_11, Brocha, 230, 70)
        e.Graphics.DrawLine(Lapiz, 625, 20, 625, 120) 'División vertical entre el título y el número del formato
        e.Graphics.DrawString("ICS-GRAL-F-203", Formato_Etiqueta_9, Brocha, 650, 45)
        e.Graphics.DrawLine(Lapiz, 625, 70, 770, 70) 'División horizontal entre el número del formato y la revisión del formato
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_9, Brocha, 655, 95)
        e.Graphics.DrawLine(Lapiz, 40, 120, 770, 120) 'División horizontal entre el título del formato y los datos de la orden de trabajo
        e.Graphics.DrawString("CÓDIGO: " & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, 570, 135)
  


        e.Graphics.DrawString("Nombres y Apellidos: ", Formato_Etiqueta_10R, Brocha, 61, renglon)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, 207, renglon + 2)
        e.Graphics.DrawLine(Lapiz, 205, renglon + 15, 490, renglon + 15) 'Línea horizontal de ciudad y fecha
        e.Graphics.DrawString("No. Cédula: ", Formato_Etiqueta_10R, Brocha, 510, renglon)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, 602, renglon)
        e.Graphics.DrawLine(Lapiz, 600, renglon + 15, 750, renglon + 15) 'Línea horizontal de ciudad y fecha
        renglon += 70
        e.Graphics.DrawString("Ciudad y Fecha: ", Formato_Etiqueta_10R, Brocha, 61, renglon)
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & " - " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, 207, renglon)
        e.Graphics.DrawLine(Lapiz, 205, renglon + 15, 490, renglon + 15) 'Línea horizontal de ciudad y fecha
        e.Graphics.DrawString("Dependencia: ", Formato_Etiqueta_10R, Brocha, 510, renglon)
        Dim dependencia As String = Trim(_filaContrato("FRENTETRABAJO"))
        Select Case dependencia.Length
            Case Is < 21
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_10R, Brocha, 600, renglon)
                Exit Select
            Case Is < 33
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6R, Brocha, 600, renglon + 5)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(dependencia, 1, 33), Formato_Etiqueta_6R, Brocha, 600, renglon - 5)
                e.Graphics.DrawString(Mid(dependencia, 32, 33), Formato_Etiqueta_6R, Brocha, 600, renglon + 5)
        End Select
        e.Graphics.DrawLine(Lapiz, 600, renglon + 15, 750, renglon + 15) 'Línea horizontal de ciudad y fecha
        Dim Cadenas As New ArrayList
        renglon += 75
        Cadenas.Add("Como trabajador de ISMOCOL S.A. y/o contratista declaro haber recibido inducción sobre el Plan Estratégico de Seguridad Vial - ''PESV'' de la empresa, así como de la " & _
                    "Política de Control y Seguimiento de la Seguridad Vial, aplicable a todos los conductores propios, contratistas y demás partes interesadas. De igual " & _
                    "manera manifiesto tener conocimiento de quiénes integran el Comité de Seguridad Vial de la compañía.")
        Dim Cadena_Total_203 As New ArrayList
        Cadena_Total_203 = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 700, e)
        Dim texto As String = ""
        For i As Integer = 0 To Cadena_Total_203.Count - 1
            texto = SubParrafo1(Cadena_Total_203(i), Formato_Etiqueta_10R, 700, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, 61, renglon)
            renglon += alturaLinea
        Next
        renglon += 50
        Cadenas.Clear()
        Cadenas.Add("Conforme a lo anterior me comprometo a dar cumplimiento a la referida Política y todas las demás normas referentes a la seguridad vial, las cuales " & _
                    "hacen parte de mis obligaciones especiales como trabajador.")
        Cadena_Total_203 = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 700, e)
        texto = ""
        For i As Integer = 0 To Cadena_Total_203.Count - 1
            texto = SubParrafo1(Cadena_Total_203(i), Formato_Etiqueta_10R, 700, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, 61, renglon)
            renglon += alturaLinea
        Next
        renglon += 20
        e.Graphics.DrawString("Atentamente;", Formato_Etiqueta_10R, Brocha, 61, renglon)
        renglon += 85
        e.Graphics.DrawLine(Lapiz, 61, renglon + 15, 550, renglon + 15) 'Línea horizontal de ciudad y fecha
        renglon += 20
        e.Graphics.DrawString("FIRMA DEL TRABAJADOR Y/O CONTRATISTA", Formato_Etiqueta_11, Brocha, 61, renglon)
    End Sub
#End Region

#Region " 49 - .ICH-GRAL-F-177 COMPROMISO CON LA SEGURIDAD, SALUD EN EL TRABAJO Y MEDIO AMBIENTE"

    Private WithEvents DocImp_COMPSEGSALMEDAMBIENTE As New PrintDocument

    Private Sub DocImpr_COMPSEGSALMEDAMBIENTE(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_COMPSEGSALMEDAMBIENTE.PrintPage
        'e.Graphics.DrawString("LISTA DE CHEQUEO PARA LA ORDENACIÓN DE HISTORIAS LABORALES", Formato_Etiqueta_8R, Brocha, 10, 10)

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(40, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("COMPROMISO CON LA SEGURIDAD, SALUD", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("EN EL TRABAJO Y MEDIO AMBIENTE", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICH-GRAL-F-177", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************
        puntoOrigen.Y = 220
        puntoOrigen.X = 100

        '********************************************************************
       
        Dim Cadenas As New ArrayList
        Cadenas.Add("Yo, " & _filaPersona("NOMBRECOMPLETO") & "  identificad" & If(_filaPersona("GENERO") = "F", "a", "o") & " con cedula de ciudadanía nro. " & ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")) & " de " & _filaPersona("CIUDADYDEPTOEXPEDICION") & "  quien a partir de hoy " & _filaContrato("FECHAINGRESO").ToLongDateString & " me desempeñaré como " & Trim(_filaContrato("NOMBRETIPOCARGO")) & " en " & _filaContrato("CIUDADCONTRATADO") & ", me comprometo " & _
         "a cumplir con el Reglamento de Trabajo y de Higiene y Seguridad Industrial, los pilares del comportamiento seguro, las políticas, normas, planes,  " & _
         "procedimientos, instructivos, prácticas seguras y reglas que en materia de seguridad industrial, salud en el trabajo y medio ambiente, me sean impartidas " & _
         "para proteger mi salud y la de mis compañeros, así como los recursos de ISMOCOL S.A. o del cliente que me son entregados para el desarrollo de mi trabajo. ")

        Cadenas.Add("Además, soy consciente de la autoridad que tengo para, de manera responsable, detener los trabajos inseguros.")

        Cadenas.Add(" En caso de omisión o negligencia frente al anterior compromiso, que ponga en peligro o lesione mi integridad, la de mis compañeros o de terceros, " &
                    "ponga en peligro o afecte al medio ambiente y todo tipo de bienes de propiedad de ISMOCOL S.A. o de terceros, conozco y entiendo que podré ser sancionado dentro un " &
               "proceso disciplinario, o terminado mi contrato de trabajo con justa causa, según la gravedad de la falta. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
              puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        puntoOrigen.Y = puntoOrigen.Y + 20
        '**************************************************
        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        'e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y += 70
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Cargo: ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Código:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Fecha::", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
    End Sub
#End Region

#Region " 61 - ICQ-OMC-M-01 ANEXO 1. ROLES, RESPONSABILIDAD Y AUTORIDAD"
    Private WithEvents DocImp_RolesResponsabilidadAutoridad As New PrintDocument

    Private Sub DocImpr_RolesResponsabilidadAutoridad(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_RolesResponsabilidadAutoridad.PrintPage
        e.Graphics.DrawString("ICQ-OMC-M-01 ANEXO 1. ROLES, RESPONSABILIDAD Y AUTORIDAD", Formato_Etiqueta_8R, Brocha, 10, 10)
    End Sub
#End Region


#Region " 79 - ICH-MOCE-F-183 COMPROMISO DE CUMPLIMIENTO:   POLITICA Y MANUAL DE DERECHOS HUMANOS  CÓDIGO DE ÉTICA Y CONVIVENCIA "
    Private WithEvents DocImp_ICHMOCEF183 As New PrintDocument
    
    Private Sub DocImpr_ICHMOCEF183(sender As Object, e As PrintPageEventArgs) Handles DocImp_ICHMOCEF183.PrintPage
        Dim puntoOrigen As New Point(48, 69)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 742, 930)
        e.Graphics.DrawStringCentered("COMPROMISO DE CUMPLIMIENTO: POLITICA Y ", Formato_Etiqueta_10, Brocha, 411, puntoOrigen.X + 144, puntoOrigen.Y + 30)
        e.Graphics.DrawStringCentered("MANUAL DE DERECHOS HUMANOS  CÓDIGO DE ÉTICA Y", Formato_Etiqueta_10, Brocha, 411, puntoOrigen.X + 144, puntoOrigen.Y + 48)
        e.Graphics.DrawStringCentered("CONVIVENCIA", Formato_Etiqueta_10, Brocha, 471, puntoOrigen.X + 134, puntoOrigen.Y + 65)
        e.Graphics.DrawStringCentered("ICH-MOCE-F-183", Formato_Etiqueta_9, Brocha, 187, puntoOrigen.X + 555, puntoOrigen.Y + 20)
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_9, Brocha, 187, puntoOrigen.X + 555, puntoOrigen.Y + 75)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 144, puntoOrigen.Y, puntoOrigen.X + 144, puntoOrigen.Y + 108) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 12, puntoOrigen.Y + 8, 120, 95)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 555, puntoOrigen.Y, puntoOrigen.X + 555, puntoOrigen.Y + 108) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 555, puntoOrigen.Y + 53, puntoOrigen.X + 742, puntoOrigen.Y + 53) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 108, puntoOrigen.X + 742, puntoOrigen.Y + 108) 'Horizontal completa
        puntoOrigen.Y = 195
        puntoOrigen.X = 70
        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString("___________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y)
        e.Graphics.DrawString("No. Cedula:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 470, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y - 2)
        e.Graphics.DrawString("____________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y - 2)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString("___________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y)
        e.Graphics.DrawString("Contrato:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 470, puntoOrigen.Y)
        Dim temp_string As String = _filaContrato("CIUDADCONTRATADO") + ", " + Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy")
        If temp_string.Length < 45 Then
            e.Graphics.DrawString(temp_string, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(temp_string, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y - 2)
        End If
        e.Graphics.DrawString("____________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y)
        e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y - 2)
        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo * 3
        Dim Cadenas As New ArrayList
        Cadenas.Add("Como trabajador de ISMOCOL S.A. certifico que recibí capacitación sobre:")
        Cadenas.Add("• POLÍTICA DE DERECHOS HUMANOS Y MANUAL DE DERECHOS HUMANOS DE ISMOCOL S.A., por lo tanto declaro haberme enterado de los derechos fundamentales que tiene la persona humana por la simple condición de existir, de la obligación jurídica y moral de respetarlos y promoverlos, de cómo son implementados en la Empresa, así como de los mecanismos existentes en la misma para defenderlos.")
        Cadenas.Add("• POLÍTICA DE DERECHOS HUMANOS DE OCENSA, por lo tanto declaro conocer su contenido y la obligación de cumplimiento que como trabajador de la empresa contratista ISMOCOL S.A. tengo.")
        Cadenas.Add("• CÓDIGO DE ÉTICA Y CONVIVENCIA DE ISMOCOL S.A., por lo tanto declaro que entiendo los comportamientos y conductas que debo asumir como trabajador de ISMOCOL S.A. durante el desarrollo de mi contrato de trabajo, en mi relacionamiento con los grupos de interés y con el medio ambiente.")
        Cadenas.Add("Conforme lo anterior, manifiesto que me comprometo a cumplir y acatar los deberes y obligaciones que consagran cada uno de los anteriores documentos, seré respetuoso de los derechos humanos fundamentales dentro y fuera de la Empresa y responderé de forma ética y transparente en el ejercicio de mis funciones como trabajador de ISMOCOL S.A.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_11R, 706.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_11R, 706.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_11R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        e.Graphics.DrawString("En constancia firmo:", Formato_Etiqueta_11R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 80
        e.Graphics.DrawString("______________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Nombres y Apellidos", Formato_Etiqueta_11R, Brocha, puntoOrigen.X, puntoOrigen.Y + 15)
    End Sub
#End Region


End Class