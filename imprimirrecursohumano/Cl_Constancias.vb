Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms
Imports FunBase = FuncionesBase.FuncionesBase
Imports System.Data.SqlClient
Imports MessagingToolkit.QRCode.Codec
Imports MessagingToolkit.QRCode.Codec.Data

Partial Class Cl_Impresión

#Region " 11 - ICA GRAL-F-036 CARNET ISMOCOL S.A."
    Private WithEvents DocImp_ICAGRALF36 As New PrintDocument

    Private Sub DocImpr_ICAGRALF36(sender As Object, e As PrintPageEventArgs) Handles DocImp_ICAGRALF36.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(23, 23) '15, 22)
        'Cara frontal del carnet
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 345, 220)
        e.Graphics.DrawImage(logoIsmocol, 30, 30, 70, 60)
        puntoOrigen.X += 5
        puntoOrigen.Y += 5
        e.Graphics.DrawStringAligned("ICA GRAL F-36 Rev. 3", HorizontalAlignment.Right, Formato_Etiqueta_5R, Brocha, 150, puntoOrigen.X + 320, puntoOrigen.Y + 5)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 105, puntoOrigen.Y + 10)
        Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(1, Idpersona)
        If Not IsNothing(foto) Then
            e.Graphics.DrawImage(foto, puntoOrigen.X + 230, puntoOrigen.Y + 17, 100, 115)
        Else
            e.Graphics.FillRectangle(Brushes.White, puntoOrigen.X + 225, puntoOrigen.Y + 17, 100, 115)
            e.Graphics.DrawStringCentered("Espacio para la foto", Formato_Etiqueta_7R, Brocha, 115, puntoOrigen.X + 215, puntoOrigen.Y + 17)
        End If
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 230, puntoOrigen.Y + 17, 100, 115) 'Foto
        e.Graphics.DrawString("CARNÉ No.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 95, puntoOrigen.Y + 35)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 30, 45, 20)
        e.Graphics.DrawStringAligned(_filaContrato("CODIGOCONTRATO"), HorizontalAlignment.Center, Formato_Etiqueta_10, Brocha, 45, puntoOrigen.X + 160, puntoOrigen.Y + 32)
        e.Graphics.DrawStringAligned(_filaPersona("NOMBRES"), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 75) 'left
        e.Graphics.DrawStringAligned("Nombres", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 85)
        e.Graphics.DrawStringAligned(_filaPersona("APELLIDOS"), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 98) 'Centrado
        e.Graphics.DrawStringAligned("Apellidos", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 108)
        e.Graphics.DrawStringAligned(_filaPersona("GRUPOSANGUINEO"), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 130, puntoOrigen.Y + 123) 'Centrado
        e.Graphics.DrawStringAligned("Grupo Sanguineo", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X + 130, puntoOrigen.Y + 133)
        e.Graphics.DrawStringAligned("C.C. No. " + ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 123)
        e.Graphics.DrawStringAligned("Identificación", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 133)
        e.Graphics.DrawStringAligned(_filaContrato("NOMBREBASECONTRATADO"), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 148)
        e.Graphics.DrawStringAligned("Dependencia / Proyecto", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 158) ' 157
        If Not IsDBNull(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS")) Then
            e.Graphics.DrawStringAligned(Mid(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), 5, 9), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 173) 'left
        End If
        e.Graphics.DrawStringAligned("EPS", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 183)
        'e.Graphics.DrawStringAligned(Mid(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAARL"), 6, 9), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 100, puntoOrigen.Y + 173) 'left
        e.Graphics.DrawStringAligned("COLMENA", HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 100, puntoOrigen.Y + 173)
        e.Graphics.DrawStringAligned("ARL", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X + 100, puntoOrigen.Y + 183)
        e.Graphics.DrawStringAligned(Mid(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), 1, 18), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 200, puntoOrigen.Y + 173) 'left
        e.Graphics.DrawStringAligned("AFP", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X + 200, puntoOrigen.Y + 183)
        Dim descripcion As String = (Trim(_filaContrato("NOMBRETIPOCARGO")))
        Select Case descripcion.Length
            Case Is < 23
                e.Graphics.DrawStringAligned(descripcion, HorizontalAlignment.Center, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 170, puntoOrigen.Y + 140)
                Exit Select
            Case Is <= 32
                e.Graphics.DrawStringAligned(descripcion, HorizontalAlignment.Center, Formato_Etiqueta_6, Brocha, 220, puntoOrigen.X + 170, puntoOrigen.Y + 140)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(descripcion, 1, 30), Formato_Etiqueta_5, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 140)
                e.Graphics.DrawString(Mid(descripcion, 31, 30), Formato_Etiqueta_5, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 150)
                e.Graphics.DrawString(Mid(descripcion, 61, 30), Formato_Etiqueta_5, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 160)
        End Select
        puntoOrigen.Y = puntoOrigen.Y + 10
        'Dim depypro As String = IIf(IsDBNull(filacontratobasico("NUMEROOT")), "", Trim(filacontratobasico("NUMEROOT"))) + " / " + VariablesBase.VariablesBase.NombreProyecto
        'If depypro.Length > 36 Then
        '    e.Graphics.DrawString(IIf(IsDBNull(filacontratobasico("NUMEROOT")), "", Trim(filacontratobasico("NUMEROOT"))), Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + 120, puntoOrigen.Y)
        '    puntoOrigen.Y += 13
        '    e.Graphics.DrawString(VariablesBase.VariablesBase.NombreProyecto, Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + 120, puntoOrigen.Y)
        '    puntoOrigen.Y += 13
        'Else
        '    e.Graphics.DrawString(depypro, Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + 120, puntoOrigen.Y)
        '    puntoOrigen.Y += 20
        'End If

        e.Graphics.DrawString("VALIDO DESDE", Formato_Etiqueta_5, Brocha, puntoOrigen.X, puntoOrigen.Y + 190)
        Dim fechaimprimir As Date = CDate(_filaContrato("FECHAINGRESO"))
        e.Graphics.DrawString(fechaimprimir.ToShortDateString, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 75, puntoOrigen.Y + 190)
        e.Graphics.DrawString("HASTA", Formato_Etiqueta_5, Brocha, puntoOrigen.X + 170, puntoOrigen.Y + 190)
        Dim contratoFijoArray() As Integer = {1, 2, 3, 4}
        Dim contratoObraArray() As Integer = {6, 7, 8, 9}
        Dim contratoTerminoIndeArray() As Integer = {11, 12, 13}
        If contratoFijoArray.Contains(_filaContrato("CODIGOTIPOCONTRATO")) And _filaContrato("LABORCONTRATADA").ToString.Trim.Count = 0 Then
            e.Graphics.DrawString("PLAZO FIJO PACTADO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 190)
        ElseIf contratoTerminoIndeArray.Contains(_filaContrato("CODIGOTIPOCONTRATO")) Then
            e.Graphics.DrawString("INDEFINIDO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 190)
        Else
            e.Graphics.DrawString("LABOR CONTRATADA", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 190)
        End If

        'Reestablecer el punto de origen para iniciar el dibujado de la cara posterior del carnet
        puntoOrigen.X = 380
        puntoOrigen.Y = 23
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 345, 220)
        e.Graphics.DrawStringAligned(_filaPersona("TELEFONOMOVIL"), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 14, puntoOrigen.Y + 20) 'left
        e.Graphics.DrawStringAligned("Contacto Trabajador", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X + 14, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned(_filaPersona("NUMEROCONTACTO"), HorizontalAlignment.Left, Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 120, puntoOrigen.Y + 20) 'left
        e.Graphics.DrawStringAligned("Contacto  Emergencia", HorizontalAlignment.Left, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X + 120, puntoOrigen.Y + 30)
        'e.Graphics.FillRectangle(Brushes.Silver, puntoOrigen.X + 235, puntoOrigen.Y + 55, 100, 100)
        'e.Graphics.DrawStringCentered("Espacio para QR", Formato_Etiqueta_7R, Brocha, 225, puntoOrigen.X + 180, puntoOrigen.Y + 90)
        '----------------------------------------
        'e.Graphics.DrawString("FECHA IMPRESION: " + Date.Now.ToShortDateString, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 238)

        Dim CEDULAENCRIPTADA As String
        CEDULAENCRIPTADA = FuncionesBase.FuncionesBase.Encryptar(_filaPersona("IDENTIFICACION"))
        Dim TIPO As String
        TIPO = FuncionesBase.FuncionesBase.Encryptar("CARNE")
        Dim CORTE As String
        Dim codigoContrato As String
        codigoContrato = _filaContrato("CODIGOCONTRATO")
        CORTE = FuncionesBase.FuncionesBase.Encryptar(codigoContrato)
        Dim linkqr As String
        linkqr = "http://190.0.43.174:7070/publico/wf_ConsultarQR.aspx?CED=" + CEDULAENCRIPTADA + "&&TIPO=" + TIPO + "&&CORTE=" + CORTE

        'linkqr = "hhttp://localhost:63376/publico/wf_ConsultarQR.aspx?CED=" + CEDULAENCRIPTADA + "&&TIPO=" + TIPO + "&&CORTE=" + CORTE

        Dim encoder As New QRCodeEncoder()
        encoder.QRCodeScale = 3
        Dim img As New Bitmap(encoder.Encode(linkqr))
        e.Graphics.DrawImage(img, 380 + 245, 23 + 75, 80, 80)
        '----------------------------
        e.Graphics.DrawString("1. ESTE     CARNÉ      SIRVE      COMO       DOCUMENTO       DE ", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 9, puntoOrigen.Y + 70)
        e.Graphics.DrawString("IDENTIFICACIÓN DENTRO  Y FUERA DE LAS  DEPENDECIAS", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 80)
        e.Graphics.DrawString("DE ISMOCOL S.A.", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 90)
        e.Graphics.DrawString("2. AL   TERMINAR    EL    CONTRATO     DE   TRABAJO     DEBE", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 9, puntoOrigen.Y + 105)
        e.Graphics.DrawString("DEVOLVERSE   A   LA   EMPRESA   PARA  LA  LIQUIDACIÓN", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 115)
        e.Graphics.DrawString("FINAL.", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 125)
        e.Graphics.DrawString("3. EN CASO DE  PÉRDIDA, DEBERÁ PRESENTARSE DENUNCIA", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 9, puntoOrigen.Y + 140)
        e.Graphics.DrawString("ANTE  AUTORIDAD,  SU  REEXPEDICIÓN  TIENE UN  COSTO", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 150)
        e.Graphics.DrawString("DE $5000.", Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 160)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 15, puntoOrigen.Y + 200, puntoOrigen.X + 155, puntoOrigen.Y + 200)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 165, puntoOrigen.Y + 200, puntoOrigen.X + 320, puntoOrigen.Y + 200)
        e.Graphics.DrawStringAligned("FIRMA Y SELLO ISMOCOL S.A.", HorizontalAlignment.Center, Formato_Etiqueta_6R, Brocha, 120, puntoOrigen.X + 35, puntoOrigen.Y + 205)
        e.Graphics.DrawStringAligned("FIRMA EMPLEADO", HorizontalAlignment.Center, Formato_Etiqueta_6R, Brocha, 135, puntoOrigen.X + 185, puntoOrigen.Y + 205) 'e.HasMorePages = False






    End Sub
#End Region


#Region " 0000 -ICH - GRAL - F - 178 CARNET DE AUTORIDAD PARA DETENER EL TRABAJO - ISMOCOL S.A."
    Private WithEvents DocImp_ICHGRALF178 As New PrintDocument

    Private Sub DocImpr_ICHGRALF178(sender As Object, e As PrintPageEventArgs) Handles DocImp_ICHGRALF178.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(50, 50) '15, 22)
        'Cara frontal del carnet
        e.Graphics.FillRectangle(Brushes.Orange, puntoOrigen.X, puntoOrigen.Y + 70, 240, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 240, 335)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 90, puntoOrigen.Y + 10, 60, 50)
        e.Graphics.DrawStringAligned("AUTORIDAD", HorizontalAlignment.Center, Formato_Etiqueta_10, BrochaBlanca, 240, puntoOrigen.X, puntoOrigen.Y + 75)
        e.Graphics.DrawStringAligned("PARA DETENER EL TRABAJO", HorizontalAlignment.Center, Formato_Etiqueta_10, BrochaBlanca, 240, puntoOrigen.X, puntoOrigen.Y + 90)
        e.Graphics.DrawStringAligned("Usted,", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 120)
        Dim nombreCompleto As String = _filaPersona("NOMBRES") + " " + _filaPersona("APELLIDOS")
        Dim descripcion As String = nombreCompleto

        Select Case descripcion.Length
            Case Is < 23
                e.Graphics.DrawStringAligned(descripcion, HorizontalAlignment.Center, Formato_Etiqueta_8RS, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 135)
                Exit Select
            Case Is <= 32
                e.Graphics.DrawStringAligned(descripcion, HorizontalAlignment.Center, Formato_Etiqueta_7RS, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 135)
                Exit Select
            Case Else
                e.Graphics.DrawStringAligned(Mid(descripcion, 1, 30), HorizontalAlignment.Center, Formato_Etiqueta_5RS, Brocha, 190, puntoOrigen.X + 25, puntoOrigen.Y + 132)
                e.Graphics.DrawStringAligned(Mid(descripcion, 31, 30), HorizontalAlignment.Center, Formato_Etiqueta_5RS, Brocha, 190, puntoOrigen.X + 25, puntoOrigen.Y + 142)

        End Select

        e.Graphics.DrawStringAligned("Como empleado de  ISMOCOL S.A.,", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 155)
        e.Graphics.DrawStringAligned("cuenta     con     mi     autorización", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 170)
        e.Graphics.DrawStringAligned("para    detener   cualquier    labor", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 185)
        e.Graphics.DrawStringAligned("que se realice  de forma insegura.", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 200)
        e.Graphics.DrawStringAligned("Nadie   podrá   tomar   represalia", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 215)
        e.Graphics.DrawStringAligned("en su contra.", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 230)
        e.Graphics.DrawStringAligned("Recuerde  que el   trabajo  seguro", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 250)
        e.Graphics.DrawStringAligned("también   es   su   responsabilidad.", HorizontalAlignment.Center, Formato_Etiqueta_8R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 265)
        e.Graphics.DrawStringAligned("ÁLVARO ESCOBAR SAAVEDRA", HorizontalAlignment.Center, Formato_Etiqueta_7I, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 285)
        e.Graphics.DrawStringAligned("Gerente General", HorizontalAlignment.Center, Formato_Etiqueta_7R, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 295)
        e.Graphics.DrawStringAligned("ICH-GRAL-F-178", HorizontalAlignment.Center, Formato_Etiqueta_6, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 320)
        'Reestablecer el punto de origen para iniciar el dibujado de la cara posterior del carnet
        puntoOrigen.X = 290
        puntoOrigen.Y = 50
        'respaldo del carnet
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 240, 335)
        Dim strText As String = Chr(34) & "NINGÚN TRABAJO ES TAN IMPORTANTE,"
        Dim strText1 As String = "NI TAN URGENTE QUE NO PODAMOS"
        Dim strText2 As String = "  TOMARNOS EL TIEMPO PARA"
        Dim strText3 As String = "   HACERLO CON SEGURIDAD" + Chr(34)
        'Dim fnt As Font = New Font("Verdana", 12, FontStyle.Regular)
        Dim SF As New StringFormat
        SF.FormatFlags = StringFormatFlags.DirectionVertical
        e.Graphics.DrawString(strText, Formato_Etiqueta_8, Brushes.Black, puntoOrigen.X + 150, puntoOrigen.Y + 50, SF)
        e.Graphics.DrawString(strText1, Formato_Etiqueta_8, Brushes.Black, puntoOrigen.X + 130, puntoOrigen.Y + 65, SF)
        e.Graphics.DrawString(strText2, Formato_Etiqueta_8, Brushes.Black, puntoOrigen.X + 110, puntoOrigen.Y + 75, SF)
        e.Graphics.DrawString(strText3, Formato_Etiqueta_8, Brushes.Black, puntoOrigen.X + 90, puntoOrigen.Y + 75, SF)

    End Sub
#End Region

#Region " 15 - CERTIFICADO INDUCCIÓN" 'CAPACITACIÓN
    Private WithEvents DocImp_CERTIFICADOINDUCCION As New PrintDocument

    Private Sub DocImpr_CERTIFICADOINDUCCION(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CERTIFICADOINDUCCION.PrintPage
        Dim puntoOrigen As New Point(20, 22)
        Dim InicioLineaX As Integer = 15
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 580, 80)
        e.Graphics.DrawString("ISMOCOL S.A", Formato_Etiqueta_12, Brocha, 300, 30)
        e.Graphics.DrawString("DEPARTAMENTO DE H.S.E.", Formato_Etiqueta_10, Brocha, 260, 50)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawString("Grupo:GRL     Titulo:  CERTIFICADO DE INDUCCION", Formato_Etiqueta_10, Brocha, 180, 80)
        '*******************************************************************
        puntorec1.X = 230
        puntorec1.Y = 80
        e.Graphics.DrawLine(Lapiz_Grueso, InicioLineaX + 105, puntoOrigen.Y, 120, puntoOrigen.Y + 80) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 23, 27, 95, 70)
        e.Graphics.DrawLine(Lapiz_Grueso, 120, 70, InicioLineaX + 580, 70) 'Horizontal
        puntoOrigen.Y = 140
        puntoOrigen.X = InicioLineaX + 10
        e.Graphics.DrawString("CERTIFICADO DE INDUCCION", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("CERTIFICADO DE INDUCCION", Formato_Etiqueta_10, 15 + 580, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 10
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 460, puntoOrigen.Y, 100, 20)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 480, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 60
        Dim Cuerpo As String
        Cuerpo = "Yo " + _filaPersona("NOMBRECOMPLETO") + " identificad" & If(_filaPersona("GENERO") = "F", "a", "o") & "con la cédula de ciudadanía No. " + _filaPersona("IDENTIFICACION") + " " + ", hago constar que el día " + _filaContrato("FECHAINGRESO").ToLongDateString + " recibi durante _____ horas, el curso de inducción sobre el reglamento interno de trabajo y reglamento de higiene y seguridad industrial, asuntos laborales, Salud Ocupacional, Medio Ambiente, Calidad y Política de Drogas y Alcohol, No Consumo de Tabaco y Cigarrillo, Seguridad Vial y Derechos Humanos como requisito para ingresar a laborar en el proyecto de:"
        Dim Cadenas As New ArrayList
        Cadenas.Add(Cuerpo)
        Dim Cadena_Total As New ArrayList
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 570, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 570, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        e.Graphics.DrawString("EJECUCIÓN DE OBRAS Y TRABAJOS DE MANTENIMIENTO DE SISTEMAS DE", Formato_Etiqueta_10RSN, Brocha, puntoOrigen.X, puntoOrigen.Y - 15)
        e.Graphics.DrawString("TRANSPORTE DE HIDROCARBUROS - ZONA LLANOS - ANDINA.", Formato_Etiqueta_10RSN, Brocha, puntoOrigen.X, puntoOrigen.Y + 5)
        puntoOrigen.Y = puntoOrigen.Y + 30
        Cuerpo = "Manifiesto que recibí información sobre el reglamento interno de trabajo, higiene y seguridad industrial, Obligaciones y derechos derivados de la afiliación al Sistema de Seguridad Social (ARL, EPS y AFP) y a la caja de Compensación, salarios, beneficios, Salud Ocupacional, Medio Ambiente, Calidad, Política de Derechos Humanos, no consumo de drogas, alcohol, Tabaco y Cigarrillo, responsabilidades asignadas y notificación de los riesgos inherentes de mi cargo, todo lo cual me comprometo a cumplir a cabalidad."
        Cadenas.Clear()
        Cadenas.Add(Cuerpo)
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 570, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 570, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString("Con Copia", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Hoja de Vida", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y)
        'Segunda parte
        puntoOrigen.X = 620
        puntoOrigen.Y = 22
        InicioLineaX = puntoOrigen.X
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 10, 27, 90, 70)
        puntoOrigen.Y = 120
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") + ", " + _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Señor:", Formato_Etiqueta_8, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Señora:", Formato_Etiqueta_8, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Presente", Formato_Etiqueta_8, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("REF. :", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("POLITICA DE SALUD OCUPACIONAL, AMBIENTAL, CALIDAD, DROGAS", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 35, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString(" Y ALCOHOL, NO CONSUMO DE TABACO Y CIGARRILLO Y SEGURIDAD VIAL.", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 35, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        If _filaPersona("GENERO") = "M" Then
            e.Graphics.DrawString("Estimado Señor:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        Else
            e.Graphics.DrawString("Estimado Señora:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 40
        Cadenas.Clear()
        Cadenas.Add("Al expresarle mi saludo de bienvenida al proyecto, deseo manifestarle que uno de los aspectos fundamentales en nuestro trabajo es el cumplimiento de las políticas, normas y procedimientos de Salud Ocupacional y Medio Ambiente, las cuales deben ser parte esencial de nuestra labor diaria.")
        Cadenas.Add("En la inducción que se le ha brindado, usted ha recibido copia de la política de: Derechos Humanos, Salud Ocupacional, Ambiental, Calidad, Drogas y Alcohol, no consumo de Tabaco y Cigarrillo, Seguridad Vial y demás información sobre sus responsabilidades.")
        Cadenas.Add("Es nuestro compromiso mantener un lugar agradable de trabajo dentro de las más altas normas de Seguridad y Calidad.")
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_9R, 450, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_9R, 450, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
        Next
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString(_filaBaseConfiguracion("RESIDENTE"), Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("___________________________", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y - 18)
        e.Graphics.DrawString("Recibi:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
        e.Graphics.DrawString("___________________________", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 250, puntoOrigen.Y - 18)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("Profesional Residente", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString(_filaBaseConfiguracion("COORDINADORHSE"), Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("___________________________", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y - 18)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("Profesional de HSE", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
    End Sub
#End Region

#Region " 18 - ICQ GRAL-F-011 CONSTANCIA DE ENTREGA DE DOCUMENTOS"

    Private WithEvents DocImp_ICQGRALF11 As New PrintDocument

    Private Sub DocImpr_ICQGRALF11(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICQGRALF11.PrintPage

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 771, 995)
        e.Graphics.DrawStringAligned("CONSTANCIA DE ENTREGA DE DOCUMENTOS  ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 40)
        e.Graphics.DrawString("ICQ-GRAL-F-011", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 768, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 768, puntoOrigen.Y + 100) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 10
        puntoOrigen.X = puntoOrigen.X + 10

        e.Graphics.DrawString("AREA FRENTE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 109)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 60
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 109)
                Exit Select
            Case Else
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 109)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 105, puntoOrigen.Y + 123, puntoOrigen.X + 552, puntoOrigen.Y + 123) 'Horizontal
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 560, puntoOrigen.Y + 109)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 610, puntoOrigen.Y + 109)
        e.Graphics.DrawString("LUGAR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 130)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 105, puntoOrigen.Y + 144, puntoOrigen.X + 552, puntoOrigen.Y + 144) 'Horizontal
        e.Graphics.DrawString(_filaContrato("NOMBREBASECONTRATADO") + " / " + "ADMINISTRACIÓN", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 130)
        e.Graphics.DrawString("DOCUMENTO:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 157) '+27
        e.Graphics.DrawString("CARNET EMPLEADO  /  COPIA CONTRATO  /  COPIA DE AFILIACIONES A SEGURIDAD SOCIAL  /  CARTA DE ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 157)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 105, puntoOrigen.Y + 171, puntoOrigen.X + 758, puntoOrigen.Y + 171) 'Horizontal +14

        e.Graphics.DrawString("PRESENTACIÓN / FUNCIONES Y RESPONSABILIDADES / CERTIFICADO DE AUTORIDAD PARA DETENER EL TRABAJO.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 180)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 105, puntoOrigen.Y + 194, puntoOrigen.X + 758, puntoOrigen.Y + 194) 'Horizontal +14


        e.Graphics.DrawString("EPS:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 204)

        e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 204)
        e.Graphics.DrawString("ARL:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 400, puntoOrigen.Y + 204)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAARL"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 435, puntoOrigen.Y + 204)

        e.Graphics.DrawString("CCF:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 106, puntoOrigen.Y + 227)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 228)
        If _filaContrato("FECHAAFILIACIONAFP") Is DBNull.Value Then
        ElseIf _filaContrato("FECHAINGRESO") = _filaContrato("FECHAAFILIACIONAFP") Then
            e.Graphics.DrawString("AFP:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 400, puntoOrigen.Y + 228)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 435, puntoOrigen.Y + 228)
        Else
            _filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP") = ""
            'e.Graphics.DrawString("", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 400, puntoOrigen.Y + 204)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 105, puntoOrigen.Y + 217, puntoOrigen.X + 760, puntoOrigen.Y + 217) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 105, puntoOrigen.Y + 240, puntoOrigen.X + 758, puntoOrigen.Y + 240) 'Horizontal
        e.Graphics.DrawString("CÓDIGO =   " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 258)
        '********************************************************************
        e.Graphics.DrawString("Manifiesto que he recibido el material descrito anteriormente. En constancia firmo,", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y + 258)
        puntoOrigen.Y = puntoOrigen.Y + 288
        e.Graphics.DrawLine(Lapiz, 42, puntoOrigen.Y, puntoOrigen.X + 760, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X - 9, puntoOrigen.Y + 1, 769, 19)
        e.Graphics.DrawString(" 1.", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 133, puntoOrigen.Y + 3)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 22, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 378, puntoOrigen.Y + 3)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 25)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
        End Select
        e.Graphics.DrawString("No. Cédula", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 515, puntoOrigen.Y + 3)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 493, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 661, puntoOrigen.Y + 3)
        Dim puntorec As New Point(puntoOrigen)

        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawLine(Lapiz, 42, puntoOrigen.Y, puntoOrigen.X + 760, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 27
        'Completar lineas horizontales
        e.Graphics.DrawLine(Lapiz, 42, puntoOrigen.Y, puntoOrigen.X + 760, puntoOrigen.Y) 'Horizontal completa
        Dim conlineas As Integer
        For conlineas = 0 To 30
            If puntoOrigen.Y < 1045 Then
                e.Graphics.DrawLine(Lapiz, 42, puntoOrigen.Y, puntoOrigen.X + 760, puntoOrigen.Y) 'Horizontal completa
                puntoOrigen.Y = puntoOrigen.Y + 27
            Else
                Exit For
            End If
        Next

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 8, puntorec.Y, puntoOrigen.X - 8, 1033) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntorec.Y, puntoOrigen.X + 21, 1033) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 291, puntorec.Y, puntoOrigen.X + 291, 1033) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 492, puntorec.Y, puntoOrigen.X + 492, 1033) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 601, puntorec.Y, puntoOrigen.X + 601, 1033) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 760, puntorec.Y, puntoOrigen.X + 760, 1033) 'Vertical
    End Sub
#End Region

#Region " 19 - CONSTANCIA DE ENTREGA COPIA DE CONTRATO Y CARNET"
    Private WithEvents DocImp_CONSTANCIACONTRATOCARNET As New PrintDocument

    Private Sub DocImpr_CONSTANCIACONTRATOCARNET(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CONSTANCIACONTRATOCARNET.PrintPage
        e.Graphics.DrawString("CONSTANCIA DE ENTREGA COPIA DE CONTRATO Y CARNET", Formato_Etiqueta_8R, Brocha, 10, 10)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_14, Brocha, 350, 64)
        e.Graphics.DrawString("CONSTANCIA DE ENTREGA COPIA DEL CONTRATO Y CARNET", Formato_Etiqueta_14, Brocha, 140, 140)
        e.Graphics.DrawImage(logoIsmocol, 63, 44, 100, 70)
        e.Graphics.DrawString("CÓDIGO: ", Formato_Etiqueta_10, Brocha, 63, 300)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10, Brocha, 140, 300)
        Dim Cadenas As New ArrayList
        Dim Cadena_Total_71CONTERFIJO As New ArrayList
        Cadenas.Add("Yo, " & _filaPersona("NOMBRECOMPLETO") & " identificado como aparece al pie de mi firma, certifico que en la fecha he recibido copia debidamente " & _
                    "firmada del contrato y carnet que me identifica como trabajador de Ismocol S.A.")
        Cadena_Total_71CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 755, e)
        For i = 0 To Cadena_Total_71CONTERFIJO.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_71CONTERFIJO(i), Formato_Etiqueta_10R, 755, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, 63, 450 + (i * 15))
        Next
        e.Graphics.DrawString("________________________________________________", Formato_Etiqueta_8, Brocha, 63, 580)
        e.Graphics.DrawString("C.C. No. " & _filaPersona("IDENTIFICACION") & " De " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_10, Brocha, 63, 600)
    End Sub
#End Region

#Region " 32 - ICS GRAL-F-032 ENTREGA DE DOTACIÓN AL PERSONAL"
    Private WithEvents DocImp_ICSGRALF32 As New PrintDocument

    Private Sub DocImpr_ICSGRALF32(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICSGRALF32.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Const anchoDocumento As UInteger = 980
        Const altoDocumento As UInteger = 730
        Dim puntoOrigen As New Point(20, 20)
        Dim fechaIngreso As Date = _filaContrato("FECHAINGRESO")
        Dim fechaEntrega As Date = DateAdd(DateInterval.Day, -1, _filaContrato("FECHAENTREGADOTACION"))

        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, anchoDocumento, altoDocumento)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 110, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 170, puntoOrigen.Y, puntoOrigen.X + 170, puntoOrigen.Y + 100) 'vertical
        e.Graphics.DrawStringCentered("ENTREGA DE DOTACIÓN AL PERSONAL", Formato_Etiqueta_12, Brocha, 665, puntoOrigen.X + 170, puntoOrigen.Y + 41)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 835, puntoOrigen.Y, puntoOrigen.X + 835, puntoOrigen.Y + 100) 'vertical
        e.Graphics.DrawStringCentered("ICS-GRAL-F-032", Formato_Etiqueta_9, Brocha, 145, puntoOrigen.X + 835, puntoOrigen.Y + 19)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 835, puntoOrigen.Y + 50, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 50) 'horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_9, Brocha, 145, puntoOrigen.X + 835, puntoOrigen.Y + 68)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 100) 'horizontal completa

        puntoOrigen.Y = 120
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 5, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 5) 'horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 20, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 20) 'horizontal completa
        e.Graphics.DrawString("PROYECTO / BASE", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 7)
        e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 220, puntoOrigen.Y + 5, puntoOrigen.X + 220, puntoOrigen.Y + 50) 'vertical
        e.Graphics.DrawString("NOMBRE DEL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 222, puntoOrigen.Y + 7)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 225, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 645, puntoOrigen.Y + 5, puntoOrigen.X + 645, puntoOrigen.Y + 50) 'vertical
        e.Graphics.DrawString("CÉDULA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 647, puntoOrigen.Y + 7)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 810, puntoOrigen.Y + 5, puntoOrigen.X + 810, puntoOrigen.Y + 50) 'vertical
        e.Graphics.DrawStringCentered("FECHA DE INGRESO", Formato_Etiqueta_8, Brocha, 170, puntoOrigen.X + 810, puntoOrigen.Y + 7)
        e.Graphics.DrawStringCentered("DD", Formato_Etiqueta_7, Brocha, 55, puntoOrigen.X + 810, puntoOrigen.Y + 20)
        e.Graphics.DrawStringCentered(fechaIngreso.ToString("dd"), Formato_Etiqueta_7R, Brocha, 55, puntoOrigen.X + 810, puntoOrigen.Y + 35)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 865, puntoOrigen.Y + 20, puntoOrigen.X + 865, puntoOrigen.Y + 50) 'vertical
        e.Graphics.DrawStringCentered("MM", Formato_Etiqueta_7, Brocha, 55, puntoOrigen.X + 865, puntoOrigen.Y + 20)
        e.Graphics.DrawStringCentered(fechaIngreso.ToString("MM"), Formato_Etiqueta_7R, Brocha, 55, puntoOrigen.X + 865, puntoOrigen.Y + 35)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 925, puntoOrigen.Y + 20, puntoOrigen.X + 925, puntoOrigen.Y + 50) 'vertical
        e.Graphics.DrawStringCentered("AA", Formato_Etiqueta_7, Brocha, 55, puntoOrigen.X + 925, puntoOrigen.Y + 20)
        e.Graphics.DrawStringCentered(fechaIngreso.ToString("yy"), Formato_Etiqueta_7R, Brocha, 55, puntoOrigen.X + 925, puntoOrigen.Y + 35)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 810, puntoOrigen.Y + 30, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 30) 'horizontal

        puntoOrigen.Y = 170
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + anchoDocumento, puntoOrigen.Y) 'horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 15, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 15) 'horizontal completa
        e.Graphics.DrawString("CARGO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 2)
        If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_7R).Width > 200 Then
            e.Graphics.DrawString(Mid(_filaContrato("NOMBRETIPOCARGO"), 1, 30).Trim, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 20)
            e.Graphics.DrawString(Mid(_filaContrato("NOMBRETIPOCARGO"), 31, 30).Trim, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 30)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 25)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 220, puntoOrigen.Y, puntoOrigen.X + 220, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawStringCentered("DOTACION 1", Formato_Etiqueta_8, Brocha, 140, puntoOrigen.X + 220, puntoOrigen.Y + 2)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 285, puntoOrigen.Y + 25, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y, puntoOrigen.X + 360, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawStringCentered("DOTACION 2", Formato_Etiqueta_8, Brocha, 140, puntoOrigen.X + 360, puntoOrigen.Y + 2)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 425, puntoOrigen.Y + 25, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 500, puntoOrigen.Y, puntoOrigen.X + 500, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawStringCentered("DOTACION 3", Formato_Etiqueta_8, Brocha, 145, puntoOrigen.X + 500, puntoOrigen.Y + 2)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 565, puntoOrigen.Y + 25, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 645, puntoOrigen.Y, puntoOrigen.X + 645, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawString("CÓDIGO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 647, puntoOrigen.Y + 2)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 810, puntoOrigen.Y, puntoOrigen.X + 810, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawStringCentered("FECHA DE ENTREGA", Formato_Etiqueta_8, Brocha, 170, puntoOrigen.X + 810, puntoOrigen.Y + 2)
        e.Graphics.DrawStringCentered("DD", Formato_Etiqueta_7, Brocha, 55, puntoOrigen.X + 810, puntoOrigen.Y + 15)
        e.Graphics.DrawStringCentered(fechaEntrega.ToString("dd"), Formato_Etiqueta_7R, Brocha, 55, puntoOrigen.X + 810, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 865, puntoOrigen.Y + 15, puntoOrigen.X + 865, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawStringCentered("MM", Formato_Etiqueta_7, Brocha, 55, puntoOrigen.X + 865, puntoOrigen.Y + 15)
        e.Graphics.DrawStringCentered(fechaEntrega.ToString("MM"), Formato_Etiqueta_7R, Brocha, 55, puntoOrigen.X + 865, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 925, puntoOrigen.Y + 15, puntoOrigen.X + 925, puntoOrigen.Y + 45) 'vertical
        e.Graphics.DrawStringCentered("AA", Formato_Etiqueta_7, Brocha, 55, puntoOrigen.X + 925, puntoOrigen.Y + 15)
        e.Graphics.DrawStringCentered(fechaEntrega.ToString("yy"), Formato_Etiqueta_7R, Brocha, 55, puntoOrigen.X + 925, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 810, puntoOrigen.Y + 25, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 25) 'horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 45, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 45) 'horizontal completa

        puntoOrigen.Y = 215
        e.Graphics.DrawStringCentered("ELEMENTOS DE PROTECCIÓN PERSONAL", Formato_Etiqueta_8, Brocha, anchoDocumento, puntoOrigen.X, puntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 20, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 20) 'horizontal completa
        e.Graphics.DrawStringCentered("DESCRIPCIÓN", Formato_Etiqueta_8, Brocha, 290, puntoOrigen.X, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 290, puntoOrigen.Y + 20, puntoOrigen.X + 290, puntoOrigen.Y + 170) 'vertical
        e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 290, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 20, puntoOrigen.X + 360, puntoOrigen.Y + 170) 'vertical
        e.Graphics.DrawStringCentered("SI", Formato_Etiqueta_8, Brocha, 35, puntoOrigen.X + 360, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 395, puntoOrigen.Y + 20, puntoOrigen.X + 395, puntoOrigen.Y + 170) 'vertical
        e.Graphics.DrawStringCentered("NO", Formato_Etiqueta_8, Brocha, 35, puntoOrigen.X + 395, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 430, puntoOrigen.Y + 20, puntoOrigen.X + 430, puntoOrigen.Y + 170) 'vertical
        e.Graphics.DrawStringCentered("N/A", Formato_Etiqueta_8, Brocha, 40, puntoOrigen.X + 430, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 470, puntoOrigen.Y + 20, puntoOrigen.X + 470, puntoOrigen.Y + 170) 'vertical
        e.Graphics.DrawStringCentered("FIRMA TRABAJADOR", Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 470, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 690, puntoOrigen.Y + 20, puntoOrigen.X + 690, puntoOrigen.Y + 170) 'vertical
        e.Graphics.DrawStringCentered("CARACTERISTICAS DE LOS EPP", Formato_Etiqueta_8, Brocha, 290, puntoOrigen.X + 690, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 40, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 40) 'horizontal completa

        e.Graphics.DrawString("Casco", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 44)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 44, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 44, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 44, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 59, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 59) 'horizontal completa
        e.Graphics.DrawString("Monogafas", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 63)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 63, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 63, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 63, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 77, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 77) 'horizontal completa
        e.Graphics.DrawString("Protectores Auditivos", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 81)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 81, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 81, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 81, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 96, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 96) 'horizontal completa
        e.Graphics.DrawString("Respirador", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 100)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 100, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 100, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 100, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 114, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 114) 'horizontal completa
        e.Graphics.DrawString("Barbuquejo", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 119)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 119, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 119, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 119, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 133, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 133) 'horizontal completa
        e.Graphics.DrawString("Tafilete", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 137)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 137, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 137, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 137, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 151, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 151) 'horizontal completa
        e.Graphics.DrawString("Guantes Tipo:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 155)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 156, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 156, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 156, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 170, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 170) 'horizontal completa

        puntoOrigen.Y = 385
        e.Graphics.DrawStringCentered("DOTACIÓN", Formato_Etiqueta_8, Brocha, anchoDocumento, puntoOrigen.X, puntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 20, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 20) 'horizontal completa
        e.Graphics.DrawStringCentered("DESCRIPCIÓN", Formato_Etiqueta_8, Brocha, 240, puntoOrigen.X, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 220, puntoOrigen.Y + 20, puntoOrigen.X + 220, puntoOrigen.Y + 187) 'vertical
        e.Graphics.DrawStringCentered("TALLA", Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 290, puntoOrigen.Y + 20, puntoOrigen.X + 290, puntoOrigen.Y + 205) 'vertical
        e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 290, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 20, puntoOrigen.X + 360, puntoOrigen.Y + 205) 'vertical
        e.Graphics.DrawStringCentered("SI", Formato_Etiqueta_8, Brocha, 35, puntoOrigen.X + 360, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 395, puntoOrigen.Y + 20, puntoOrigen.X + 395, puntoOrigen.Y + 205) 'vertical
        e.Graphics.DrawStringCentered("NO", Formato_Etiqueta_8, Brocha, 35, puntoOrigen.X + 395, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 430, puntoOrigen.Y + 20, puntoOrigen.X + 430, puntoOrigen.Y + 205) 'vertical
        e.Graphics.DrawStringCentered("N/A", Formato_Etiqueta_8, Brocha, 40, puntoOrigen.X + 430, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 470, puntoOrigen.Y + 20, puntoOrigen.X + 470, puntoOrigen.Y + 205) 'vertical
        e.Graphics.DrawStringCentered("FIRMA TRABAJADOR", Formato_Etiqueta_8, Brocha, 220, puntoOrigen.X + 470, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 690, puntoOrigen.Y + 20, puntoOrigen.X + 690, puntoOrigen.Y + 205) 'vertical
        e.Graphics.DrawStringCentered("CARACTERISTICAS DE LOS EPP", Formato_Etiqueta_8, Brocha, 290, puntoOrigen.X + 690, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 40, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 40) 'horizontal completa

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 40, puntoOrigen.X + 100, puntoOrigen.Y + 150) 'vertical
        e.Graphics.DrawString("Ropa", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 63)
        e.Graphics.DrawString("Braga", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 102, puntoOrigen.Y + 44)
        e.Graphics.DrawStringCentered(_filaPersona("TALLACAMISA"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 44)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 44, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 44, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 44, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 58, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 58) 'horizontal
        e.Graphics.DrawString("Pantalón", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 102, puntoOrigen.Y + 63)
        e.Graphics.DrawStringCentered(_filaPersona("TALLAPANTALON"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 63)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 63, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 63, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 63, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 77, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 77) 'horizontal
        e.Graphics.DrawString("Camisa", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 102, puntoOrigen.Y + 81)
        e.Graphics.DrawStringCentered(_filaPersona("TALLACAMISA"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 81)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 81, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 81, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 81, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 95, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 95) 'horizontal completa
        e.Graphics.DrawString("Botas de", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 110)
        e.Graphics.DrawString("Seguridad", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 125)
        e.Graphics.DrawString("Cordón", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 102, puntoOrigen.Y + 99)
        e.Graphics.DrawStringCentered(_filaPersona("NUMEROCALZADO"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 99)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 99, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 99, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 99, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 113, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 113) 'horizontal
        e.Graphics.DrawString("Caña Alta", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 102, puntoOrigen.Y + 118)
        e.Graphics.DrawStringCentered(_filaPersona("NUMEROCALZADO"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 118)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 118, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 118, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 118, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 132, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 132) 'horizontal
        e.Graphics.DrawString("Caucho", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 102, puntoOrigen.Y + 136)
        e.Graphics.DrawStringCentered(_filaPersona("NUMEROCALZADO"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 136)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 136, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 136, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 136, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 150, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 150) 'horizontal completa
        e.Graphics.DrawString("Capa Impermeable", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 154)
        e.Graphics.DrawStringCentered(_filaPersona("TALLACAMISA"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 154)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 154, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 154, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 154, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 168, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 168) 'horizontal completa
        e.Graphics.DrawString("Conjunto Impermeable", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 173)
        e.Graphics.DrawStringCentered(_filaPersona("TALLACAMISA"), Formato_Etiqueta_8, Brocha, 70, puntoOrigen.X + 220, puntoOrigen.Y + 173)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 173, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 173, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 173, 10, 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 187, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 187) 'horizontal completa
        e.Graphics.DrawString("Porta Carnet", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 191)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 372, puntoOrigen.Y + 191, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 191, 10, 10)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 445, puntoOrigen.Y + 191, 10, 10)

        puntoOrigen.Y = 590
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + anchoDocumento, puntoOrigen.Y) 'horizontal completa
        e.Graphics.DrawStringCentered("Al recibir los elementos relacionados, se me informan las instrucciones de uso, mantenimiento y reposición.", Formato_Etiqueta_7, Brocha, anchoDocumento, puntoOrigen.X, puntoOrigen.Y + 4)
        e.Graphics.DrawStringCentered("Me comprometo a hacer un buen uso de ellos permanentemente", Formato_Etiqueta_7, Brocha, anchoDocumento, puntoOrigen.X, puntoOrigen.Y + 16)

        puntoOrigen.Y = 620
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + anchoDocumento, puntoOrigen.Y) 'horizontal completa
        e.Graphics.DrawString("OBSERVACIONES:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 5)
        e.Graphics.DrawString(LTrim(RTrim(_filaContrato("FRENTETRABAJO"))), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 170, puntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 170, puntoOrigen.Y + 15, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 15) 'horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 35, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 35) 'horizontal completa

        'puntoOrigen.Y = 640
        'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + anchoDocumento, puntoOrigen.Y) 'horizontal completa
        'e.Graphics.DrawString("ORDEN DE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
        'e.Graphics.DrawString("TRABAJO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 23, puntoOrigen.Y + 10)
        'e.Graphics.DrawString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y + 5)

        puntoOrigen.Y = 660
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + anchoDocumento, puntoOrigen.Y) 'horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 70, puntoOrigen.Y, puntoOrigen.X + 70, puntoOrigen.Y + 90) 'vertical
        e.Graphics.DrawStringCentered("Administración / Jefe de Personal", Formato_Etiqueta_7, Brocha, 290, puntoOrigen.X + 70, puntoOrigen.Y + 5)
        If _filaContrato("IDBASESISCONTROL") = 122 Then
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_7R, Brocha, 290, puntoOrigen.X + 70, puntoOrigen.Y + 25)
        Else
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_7R, Brocha, 290, puntoOrigen.X + 70, puntoOrigen.Y + 25)
        End If

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y, puntoOrigen.X + 360, puntoOrigen.Y + 90) 'vertical
        e.Graphics.DrawStringCentered("Jefe de Bodega", Formato_Etiqueta_7, Brocha, 330, puntoOrigen.X + 360, puntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEBODEGA"), Formato_Etiqueta_7R, Brocha, 330, puntoOrigen.X + 360, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 690, puntoOrigen.Y, puntoOrigen.X + 690, puntoOrigen.Y + 90) 'vertical
        e.Graphics.DrawStringCentered("Coordinador HSE", Formato_Etiqueta_7, Brocha, 290, puntoOrigen.X + 690, puntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("COORDINADORHSE"), Formato_Etiqueta_7R, Brocha, 290, puntoOrigen.X + 690, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 20, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 20) 'horizontal completa
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 40, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 40) 'horizontal completa
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 50)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 70, puntoOrigen.X + anchoDocumento, puntoOrigen.Y + 70) 'horizontal completa
        e.Graphics.DrawString("Fecha:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 75)
        e.Graphics.DrawStringCentered(fechaEntrega, Formato_Etiqueta_7, Brocha, 290, puntoOrigen.X + 70, puntoOrigen.Y + 75)
        e.Graphics.DrawStringCentered(fechaEntrega, Formato_Etiqueta_7, Brocha, 330, puntoOrigen.X + 360, puntoOrigen.Y + 75)
        e.Graphics.DrawStringCentered(fechaEntrega, Formato_Etiqueta_7, Brocha, 290, puntoOrigen.X + 690, puntoOrigen.Y + 75)
    End Sub
#End Region

#Region " 33 - ICA GRAL-F-046 PAZ Y SALVO PARA LIQUIDACIÓN FINAL CONTRATO"
    Private WithEvents DocImp_ICAGRALF46 As New PrintDocument

    Private Sub DocImpr_ICAGRALF46(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF46.PrintPage
        Dim puntoOrigen As New Point(21, 16)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 739, 570)
        e.Graphics.DrawString("PAZ Y SALVO", Formato_Etiqueta_14, Brocha, 310, 35)
        e.Graphics.DrawString("PARA LIQUIDACION FINAL DE CONTRATO", Formato_Etiqueta_14, Brocha, 180, 65)
        e.Graphics.DrawString("ICA-GRAL-F-046", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 630, puntoOrigen.Y + 18)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 635, puntoOrigen.Y + 66)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 141, puntoOrigen.Y, puntoOrigen.X + 141, puntoOrigen.Y + 94) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 31, 18, 120, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 606, puntoOrigen.Y, puntoOrigen.X + 606, puntoOrigen.Y + 94) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 606, puntoOrigen.Y + 48, puntoOrigen.X + 739, puntoOrigen.Y + 48) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 94, puntoOrigen.X + 739, puntoOrigen.Y + 94) 'Horizontal Completa
        puntoOrigen.Y = puntoOrigen.Y + 94
        puntoOrigen.X = puntoOrigen.X + 20
        e.Graphics.DrawString("CERTIFICAMOS QUE " & If(_filaPersona("GENERO") = "F", "LA", "EL") & " SEÑOR" & If(_filaPersona("GENERO") = "F", "A", "") & ":", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 13)
        Dim nombre As String = _filaPersona("NOMBRECOMPLETO").ToString.Trim
        Select Case nombre.Length
            Case Is < 36
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 13)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 13)
                Exit Select
            Case Else
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 13)
        End Select
        e.Graphics.DrawString("COD: ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y + 13)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_11RS, Brocha, puntoOrigen.X + 600, puntoOrigen.Y + 13)
        puntoOrigen.Y = puntoOrigen.Y + 77
        e.Graphics.DrawString("C.C. No: ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("IDENTIFICACION"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 60, puntoOrigen.Y) 'ClConvertir.Fun_FormatearCedula()
        e.Graphics.DrawString("QUIEN OCUPA EL CARGO DE:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 230, puntoOrigen.Y)
        Dim Cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case Cargo.Length
            Case Is < 44
                e.Graphics.DrawString(Cargo, Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y)
                Exit Select
            Case Is <= 52
                e.Graphics.DrawString(Cargo, Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 2)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(Cargo, 1, 52), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y - 4)
                e.Graphics.DrawString(Mid(Cargo, 53, 52), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 8)
        End Select
        'e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 420, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("EN LA BASE DE:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 100, puntoOrigen.Y + 3)
        e.Graphics.DrawString("SE ENCUENTRA A PAZ Y SALVO CON LA COMPAÑIA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 230, puntoOrigen.Y)
        e.Graphics.DrawString("SI", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 600, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 618, puntoOrigen.Y, 15, 15)
        e.Graphics.DrawString("NO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 648, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 675, puntoOrigen.Y, 15, 15)
        puntoOrigen.Y = puntoOrigen.Y + 22
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 38, puntoOrigen.Y, puntoOrigen.X + 720, puntoOrigen.Y) 'Horizontal
        e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 61, puntoOrigen.Y + 11)
        e.Graphics.DrawString("JEFE DE CONTABILIDAD", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 214, puntoOrigen.Y + 5)
        e.Graphics.DrawString("JEFE DE CAMPAMENTO (**)", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 208, puntoOrigen.Y + 20)
        e.Graphics.DrawString("JEFE INMEDIATO", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 5)
        e.Graphics.DrawString("SUPERVISOR (**)", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 20)
        e.Graphics.DrawString("JEFE ADMINISTRATIVO", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 580, puntoOrigen.Y + 5)
        e.Graphics.DrawString("ADMINISTRADOR (**)", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 587, puntoOrigen.Y + 20)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 33, puntoOrigen.X + 720, puntoOrigen.Y + 33) 'Horizontal
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X - 20, puntoOrigen.Y + 36)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEBODEGA"), Formato_Etiqueta_5R, Brocha, 143, puntoOrigen.X + 38, puntoOrigen.Y + 38)
        e.Graphics.DrawStringCentered(_filaContrato("JEFEINMEDIATO"), Formato_Etiqueta_5R, Brocha, 170, puntoOrigen.X + 380, puntoOrigen.Y + 38)
        If _filaContrato("IDBASESISCONTROL") = 122 Then
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_5R, Brocha, 170, puntoOrigen.X + 550, puntoOrigen.Y + 38)
        Else
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_5R, Brocha, 170, puntoOrigen.X + 550, puntoOrigen.Y + 38)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 51, puntoOrigen.X + 720, puntoOrigen.Y + 51) 'Horizontal
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X - 20, puntoOrigen.Y + 73)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 112, puntoOrigen.X + 720, puntoOrigen.Y + 112) 'Horizontal
        e.Graphics.DrawString("Fecha:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X - 20, puntoOrigen.Y + 115)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 130, puntoOrigen.X + 720, puntoOrigen.Y + 130) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 38, puntoOrigen.Y, puntoOrigen.X + 38, puntoOrigen.Y + 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 179, puntoOrigen.Y, puntoOrigen.X + 179, puntoOrigen.Y + 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 380, puntoOrigen.Y, puntoOrigen.X + 380, puntoOrigen.Y + 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 550, puntoOrigen.Y, puntoOrigen.X + 550, puntoOrigen.Y + 130) 'Vertical
        puntoOrigen.Y = puntoOrigen.Y + 145
        e.Graphics.DrawString("FECHA INGRESO:   " + CDate(_filaContrato("FECHAINGRESO")).ToShortDateString, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("FECHA RETIRO:      " & If(Not IsDBNull(_filaContrato("FECHATERMINACIONCONTRATO")), CDate(_filaContrato("FECHATERMINACIONCONTRATO")).ToShortDateString, ""), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("OBSERVACIONES: ______________________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Frente de Trabajo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 120, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 215, puntoOrigen.Y + 2)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("_______________________________________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("_______________________________________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("AUTORIZACION PARA CANCELAR Vo. Bo. (1):", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("(1)", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("EN BUCARAMANGA JEFE DEL DEPARTAMENTO ADMINISTRATIVO/SUBGERENTE ADMINISTRATIVO FINANCIERO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("EN LOS FRENTES DIRECTOR DE OBRA O INGENIERO RESIDENTE", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("(**)", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("LOS CARGOS INDICADOS ENTRE PARENTESIS TIENEN RESPONSABILIDAD EN LUGARES DISTINTOS A BUCARAMANGA", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
    End Sub
#End Region

#Region " 33+ ICA GRAL-F-046 PAZ Y SALVO PARA LIQUIDACIÓN FINAL CONTRATO + CONTROL DE SEGUIMIENTO"
    Private WithEvents DocImp_ICAGRALF_46 As New PrintDocument
    Private Sub DocImpr_ICAGRALF_46(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF_46.PrintPage
        Dim puntoOrigen As New Point(50, 16)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 739, 570)
        e.Graphics.DrawString("PAZ Y SALVO", Formato_Etiqueta_14, Brocha, 310 + 29, 35)
        e.Graphics.DrawString("PARA LIQUIDACION FINAL DE CONTRATO", Formato_Etiqueta_14, Brocha, 180 + 29, 65)
        e.Graphics.DrawString("ICA-GRAL-F-046", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 630, puntoOrigen.Y + 18)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 635, puntoOrigen.Y + 66)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 141, puntoOrigen.Y, puntoOrigen.X + 141, puntoOrigen.Y + 94) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 53, 18, 120, 90)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 606, puntoOrigen.Y, puntoOrigen.X + 606, puntoOrigen.Y + 94) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 606, puntoOrigen.Y + 48, puntoOrigen.X + 739, puntoOrigen.Y + 48) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 94, puntoOrigen.X + 739, puntoOrigen.Y + 94) 'Horizontal Completa
        puntoOrigen.Y = puntoOrigen.Y + 94
        puntoOrigen.X = puntoOrigen.X + 20
        e.Graphics.DrawString("CERTIFICAMOS QUE " & If(_filaPersona("GENERO") = "F", "LA", "EL") & " SEÑOR" & If(_filaPersona("GENERO") = "F", "A", "") & ":", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 13)

        Dim nombre As String = _filaPersona("NOMBRECOMPLETO").ToString.Trim
        Select Case nombre.Length
            Case Is < 36
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 13)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 13)
                Exit Select
            Case Else
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 13)
        End Select
        e.Graphics.DrawString("COD: ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 550, puntoOrigen.Y + 13)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_11RS, Brocha, puntoOrigen.X + 600, puntoOrigen.Y + 13)
        puntoOrigen.Y = puntoOrigen.Y + 77
        e.Graphics.DrawString("C.C. No: ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("IDENTIFICACION"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 60, puntoOrigen.Y) 'ClConvertir.Fun_FormatearCedula()
        e.Graphics.DrawString("QUIEN OCUPA EL CARGO DE:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 230, puntoOrigen.Y)
        Dim Cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case Cargo.Length
            Case Is < 44
                e.Graphics.DrawString(Cargo, Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y)
                Exit Select
            Case Is <= 52
                e.Graphics.DrawString(Cargo, Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 2)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(Cargo, 1, 52), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y - 4)
                e.Graphics.DrawString(Mid(Cargo, 53, 52), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 8)
        End Select
        'e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 420, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("EN LA BASE DE:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 100, puntoOrigen.Y + 3)
        e.Graphics.DrawString("SE ENCUENTRA A PAZ Y SALVO CON LA COMPAÑIA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 230, puntoOrigen.Y)
        e.Graphics.DrawString("SI", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 600, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 618, puntoOrigen.Y, 15, 15)
        e.Graphics.DrawString("NO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 648, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 675, puntoOrigen.Y, 15, 15)
        puntoOrigen.Y = puntoOrigen.Y + 22
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 38, puntoOrigen.Y, puntoOrigen.X + 720, puntoOrigen.Y) 'Horizontal
        e.Graphics.DrawString("JEFE DE BODEGA", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 61, puntoOrigen.Y + 11)
        e.Graphics.DrawString("JEFE DE CONTABILIDAD", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 214, puntoOrigen.Y + 5)
        e.Graphics.DrawString("JEFE DE CAMPAMENTO (**)", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 208, puntoOrigen.Y + 20)
        e.Graphics.DrawString("JEFE INMEDIATO", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 5)
        e.Graphics.DrawString("SUPERVISOR (**)", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 20)
        e.Graphics.DrawString("JEFE ADMINISTRATIVO", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 580, puntoOrigen.Y + 5)
        e.Graphics.DrawString("ADMINISTRADOR (**)", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 587, puntoOrigen.Y + 20)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 33, puntoOrigen.X + 720, puntoOrigen.Y + 33) 'Horizontal
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X - 20, puntoOrigen.Y + 36)
        'e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEBODEGA"), Formato_Etiqueta_5R, Brocha, 143, puntoOrigen.X + 38, puntoOrigen.Y + 38)
        e.Graphics.DrawStringCentered(_filaContrato("JEFEINMEDIATO"), Formato_Etiqueta_5R, Brocha, 170, puntoOrigen.X + 380, puntoOrigen.Y + 38)
        If _filaContrato("IDBASESISCONTROL") = 122 Then
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_5R, Brocha, 170, puntoOrigen.X + 550, puntoOrigen.Y + 38)
        Else
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_5R, Brocha, 170, puntoOrigen.X + 550, puntoOrigen.Y + 38)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 51, puntoOrigen.X + 720, puntoOrigen.Y + 51) 'Horizontal
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X - 20, puntoOrigen.Y + 73)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 112, puntoOrigen.X + 720, puntoOrigen.Y + 112) 'Horizontal
        e.Graphics.DrawString("Fecha:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X - 20, puntoOrigen.Y + 115)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 20, puntoOrigen.Y + 130, puntoOrigen.X + 720, puntoOrigen.Y + 130) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 38, puntoOrigen.Y, puntoOrigen.X + 38, puntoOrigen.Y + 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 179, puntoOrigen.Y, puntoOrigen.X + 179, puntoOrigen.Y + 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 380, puntoOrigen.Y, puntoOrigen.X + 380, puntoOrigen.Y + 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 550, puntoOrigen.Y, puntoOrigen.X + 550, puntoOrigen.Y + 130) 'Vertical
        puntoOrigen.Y = puntoOrigen.Y + 145
        e.Graphics.DrawString("FECHA INGRESO:   " + CDate(_filaContrato("FECHAINGRESO")).ToShortDateString, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("FECHA RETIRO:      " & If(Not IsDBNull(_filaContrato("FECHATERMINACIONCONTRATO")), CDate(_filaContrato("FECHATERMINACIONCONTRATO")).ToShortDateString, ""), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("OBSERVACIONES: ______________________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Frente de Trabajo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 120, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 215, puntoOrigen.Y + 2)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("_______________________________________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("_______________________________________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("AUTORIZACION PARA CANCELAR Vo. Bo. (1):", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("(1)", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("EN BUCARAMANGA JEFE DEL DEPARTAMENTO ADMINISTRATIVO/SUBGERENTE ADMINISTRATIVO FINANCIERO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("EN LOS FRENTES DIRECTOR DE OBRA O INGENIERO RESIDENTE", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString("(**)", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("LOS CARGOS INDICADOS ENTRE PARENTESIS TIENEN RESPONSABILIDAD EN LUGARES DISTINTOS A BUCARAMANGA", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
        'Seguimiento MEDICO

        Dim drawFont As New Font("Arial", 6)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim x As Single = 70.0F
        Dim y As Single = 650.0F
        Dim width As Single = 140.0F
        Dim height As Single = 30.0F
        Dim drawRect As New RectangleF(x + width, y, width, height)
        Dim drawFormat As New StringFormat
        Dim drawFormat2 As New StringFormat
        Dim drawFormat3 As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat2.LineAlignment = StringAlignment.Center
        drawFormat3.Alignment = StringAlignment.Near

        e.Graphics.DrawStringAligned("CONTROL SEGUIMIENTO MÉDICO", HorizontalAlignment.Center, Formato_Etiqueta_14, Brocha, 240, 300, puntoOrigen.Y + 50)
        'FILA 1
        'e.Graphics.DrawRectangle(blackPen, x, y, width, height)   '1,1
        'e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '1,2
        e.Graphics.DrawString("SEGURIDAD SOCIAL", Formato_Etiqueta_9R, drawBrush, drawRect, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '1,3
        Dim drawRect12 As New RectangleF(x + 2 * width, y, width, height)
        e.Graphics.DrawString("SEGUIMIENTO INCAPACIDADES", Formato_Etiqueta_9R, drawBrush, drawRect12, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '1,4
        Dim drawRect13 As New RectangleF(x + 3 * width, y, width, height)
        e.Graphics.DrawString("JEFE DPTO HSE", Formato_Etiqueta_9R, drawBrush, drawRect13, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 1,5
        Dim drawRect14 As New RectangleF(x + 4 * width, y, width, height)
        e.Graphics.DrawString("COORDINADOR MÉDICO", Formato_Etiqueta_9R, drawBrush, drawRect14, drawFormat)
        y = y + height
        'FILA 2
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height) '2,1
        Dim drawRect21 As New RectangleF(x, y, width, height)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_9R, drawBrush, drawRect21, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '2,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 2,5
        y = y + height
        'FILA 3
        e.Graphics.DrawRectangle(Lapiz, x, y, width, 2 * height) '3,1
        Dim drawRect31 As New RectangleF(x, y, width, 2 * height)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_9R, drawBrush, drawRect31, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, 2 * height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, 2 * height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, 2 * height)  '2,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, 2 * height)  ' 2,5
        y = y + 2 * height
        'FILA 4
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height)
        Dim drawRect41 As New RectangleF(x, y, width, height)
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_9R, drawBrush, drawRect41, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '3,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '3,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '3,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 3,5
        y = y + height
        'FILA 5
        e.Graphics.DrawRectangle(Lapiz, x, y, width, 5 * height)
        Dim drawRect51 As New RectangleF(x, y, width, 5 * height)
        e.Graphics.DrawString("OBSERVACIONES:", Formato_Etiqueta_9R, drawBrush, drawRect51, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, 5 * height)  '4,2
        Dim drawRect52 As New RectangleF(x + width, y, width, 5 * height)
        e.Graphics.DrawString("Observaciones:", Formato_Etiqueta_7R, drawBrush, drawRect52, drawFormat3)
        e.Graphics.DrawLine(Lapiz_Gris, x + width, y + height, x + 5 * width, y + height)
        e.Graphics.DrawLine(Lapiz_Gris, x + width, y + 2 * height, x + 5 * width, y + 2 * height)
        e.Graphics.DrawLine(Lapiz_Gris, x + width, y + 3 * height, x + 5 * width, y + 3 * height)
        e.Graphics.DrawLine(Lapiz_Gris, x + width, y + 4 * height, x + 5 * width, y + 4 * height)
        e.Graphics.DrawLine(Lapiz_Gris, x + width, y + 5 * height, x + 5 * width, y + 5 * height)
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, 5 * height) '4,3
        Dim drawRect53 As New RectangleF(x + 2 * width, y, width, 5 * height)
        e.Graphics.DrawString("Observaciones:", Formato_Etiqueta_7R, drawBrush, drawRect53, drawFormat3)
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, 5 * height)  '4,4
        Dim drawRect54 As New RectangleF(x + 3 * width, y, width, 5 * height)
        e.Graphics.DrawString("Observaciones:", Formato_Etiqueta_7R, drawBrush, drawRect54, drawFormat3)
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, 5 * height)  ' 4,5
        Dim drawRect55 As New RectangleF(x + 4 * width, y, width, 5 * height)
        e.Graphics.DrawString("Observaciones:", Formato_Etiqueta_7R, drawBrush, drawRect55, drawFormat3)
        y = y + 5 * height
        'FILA 6
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height)
        Dim drawRect61 As New RectangleF(x, y, width, height)
        e.Graphics.DrawString("APROBACIONES:", Formato_Etiqueta_9R, drawBrush, drawRect61, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '5,2
        Dim drawRect62 As New RectangleF(x + width, y, width, height)
        e.Graphics.DrawString("Vo.Bo. Liquidación:                                Si___                      No ___            ", Formato_Etiqueta_7R, drawBrush, drawRect62, drawFormat3)
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '5,3
        Dim drawRect63 As New RectangleF(x + 2 * width, y, width, height)
        e.Graphics.DrawString("Vo.Bo. Liquidación:                                Si___                      No ___            ", Formato_Etiqueta_7R, drawBrush, drawRect63, drawFormat3)
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '5,4
        Dim drawRect64 As New RectangleF(x + 3 * width, y, width, height)
        e.Graphics.DrawString("Vo.Bo. Liquidación:                                Si___                      No ___            ", Formato_Etiqueta_7R, drawBrush, drawRect64, drawFormat3)
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 5,5
        Dim drawRect65 As New RectangleF(x + 4 * width, y, width, height)
        e.Graphics.DrawString("Vo.Bo. Liquidación:                                Si___                      No ___            ", Formato_Etiqueta_7R, drawBrush, drawRect65, drawFormat3)


        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("EL TRABAJADOR SOLICITÓ EXAMEN MÉDICO DE RETIRO:   SI ___    NO ___", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 400)
    End Sub
#End Region

#Region " 36 - RECIBIDO ORDEN PARA EXAMEN MÉDICO DE RETIRO"
    Private WithEvents DocImp_EXAMENRETIRO As New PrintDocument

    Private Sub DocImpr_EXAMENRETIRO(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_EXAMENRETIRO.PrintPage
        Dim puntoOrigen As New Point(45, 22)
        Dim InicioLineaX As Integer = 45
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        e.Graphics.DrawString("ISMOCOL S.A", Formato_Etiqueta_16, Brocha, 280, 50)
        Dim puntorec1 As New Point(660, 30)
        '*******************************************************************
        puntorec1.X = 230
        puntorec1.Y = 80
        e.Graphics.DrawLine(Lapiz_Grueso, InicioLineaX + 105, puntoOrigen.Y, InicioLineaX + 105, 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 55, 27, 90, 70) 'ISMOCOL 
        e.Graphics.DrawLine(Lapiz_Grueso, InicioLineaX, 100, puntoOrigen.X + 750, 100) 'Horizontal completa
        puntoOrigen.Y = 160
        puntoOrigen.X = 80
        Dim FechaTerminacion As String = ""
        If IsDBNull(_filaContrato("FECHATERMINACIONCONTRATO")) Then
            e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO"), Formato_Etiqueta_12R, Brocha, puntoOrigen)
            FechaTerminacion = "_________________"
        Else
            e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") + " " + _filaContrato("FECHATERMINACIONCONTRATO").ToLongDateString, Formato_Etiqueta_12R, Brocha, puntoOrigen)
            FechaTerminacion = _filaContrato("FECHATERMINACIONCONTRATO").ToLongDateString
        End If
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_15, Brocha, puntoOrigen.X + 600, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 120
        e.Graphics.DrawString("RECIBIDO ORDEN PARA EXAMEN MEDICO DE RETIRO", Formato_Etiqueta_14, Brocha, InicioCentradoTexto("RECIBIDO ORDEN PARA EXAMEN MEDICO DE RETIRO", Formato_Etiqueta_14, 15 + 800, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 150
        Dim Cuerpo As String
        Cuerpo = "Yo " & _filaPersona("NOMBRECOMPLETO") & _
            " identificado (a) con la cédula de ciudadanía No. " & ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")) & " " & "de " & _filaPersona("CIUDADEXPEDICION") & _
            ", recibí de ISMOCOL S.A. la orden de servicios para practicarme el Examen Médico de Retiro y asumo la responsabilidad de practicarme estos exámenes."
        Dim Cadenas As New ArrayList
        Cadenas.Add(Cuerpo)
        Dim Cadena_Total As New ArrayList
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_12R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_12R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo + 10
        Next
        puntoOrigen.Y = puntoOrigen.Y + 120
        e.Graphics.DrawString("_____________________________", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 25
        e.Graphics.DrawString("C.C.", Formato_Etiqueta_12R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 60
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Con Copia", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Hoja de Vida", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Consecutivo", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Archivo", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y)
    End Sub
#End Region

#Region " 50 - ICA GRAL-F-112 CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN"
    Private WithEvents DocImp_ICAGRALF112 As New PrintDocument

    Private Sub DocImpr_ICAGRALF112(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF112.PrintPage
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM ListaDocumentos(@ACCION, @IDDOCUMENTO, @REVISION) ORDER BY [IDDOCUMENTO]", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1) 'Listar por IdDocumentoImprimir y Revisión
            comando.Parameters.AddWithValue("@IDDOCUMENTO", 50) 'ICA GRAL-F-012
            comando.Parameters.AddWithValue("@REVISION", 5) 'Rev. 5
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtDocumentos As New DataTable
            Try
                adaptador.Fill(dtDocumentos)
                If dtDocumentos.Rows.Count > 0 Then
                    listaImagenesBD = New List(Of Image)
                    For k = 0 To dtDocumentos.Rows.Count - 1
                        Dim filadoc As DataRow = dtDocumentos.Rows(k)

                        Dim byteBLOBData(-1) As [Byte]
                        byteBLOBData = CType(filadoc("BLOB"), [Byte]())
                        Dim stmBLOBData As New IO.MemoryStream(byteBLOBData)
                        listaImagenesBD.Add(Image.FromStream(stmBLOBData))
                    Next
                    datosCargados = True
                Else
                    Throw New Exception("No se encontraron datos de impresión.")
                End If
            Catch ex As Exception
                Throw New Exception("No se encontraron datos de impresión.", ex)
            Finally
                conexion.Close()
            End Try
        End If
        e.Graphics.DrawImage(listaImagenesBD.Item(contadorPaginasImpresas), -30, -40, 850, 1100) 'e.PageBounds.Left - 30, e.PageBounds.Top - 40, e.PageBounds.Right, e.PageBounds.Bottom)
        Select Case (contadorPaginasImpresas + 1)
            Case 1 'Página 1
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, 120, 147)
                e.Graphics.DrawString(Trim(_filaContrato("NOMBRETIPOCARGO")) + " - " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, 180, 174)
                e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, 100, 201)
                e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_8R, Brocha, 450, 201)
            Case 2 'Página 2

            Case 3 'Página 3

            Case 4 'Página 4

            Case 5 'Página 4

        End Select
        contadorPaginasImpresas += 1
        If contadorPaginasImpresas <= listaImagenesBD.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            contadorPaginasImpresas = 0
        End If

    End Sub
#End Region

#Region " 53 - PAZ Y SALVO LABORAL"
    Private WithEvents DocImp_PAZYSALVOLAB As New PrintDocument

    Private Sub DocImpr_PAZYSALVOLAB(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_PAZYSALVOLAB.PrintPage
        Dim puntoOrigen As New Point(51, 175)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 725, 81)
        e.Graphics.DrawString("PAZ Y SALVO LABORAL", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 259, puntoOrigen.Y + 30)
        e.Graphics.DrawString("CERTIFICO", Formato_Etiqueta_16, Brocha, puntoOrigen.X + 300, puntoOrigen.Y + 145)
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 270
        puntoOrigen.X = puntoOrigen.X + 10
        Dim Cadenas As New ArrayList
        Cadenas.Add("Que he recibido de la empresa INGENIERIA, SERVICIOS, Y CONSTRUCCION DE OLEODUCTOS DE COLOMBIA ISMOCOL S.A con NIT 890.209.174 los salarios, las prestaciones sociales e indemnizaciones correspondientes al contrato de trabajo " & _
                    "del período comprendido del        al              ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y
        Cadenas.Clear()
        Cadenas.Add("En consecuencia ISMOCOL S.A, se encuentra a PAZ y SALVO por todo concepto con el suscrito. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y - 70
        e.Graphics.DrawString("En constancia firmo:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 140)
        e.Graphics.DrawString("Firma;", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 185)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 287, puntoOrigen.X + 500, puntoOrigen.Y + 287) 'Horizontal
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 293)
        e.Graphics.DrawString("C.C.: " & _filaPersona("IDENTIFICACION") & "", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 312)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 540, puntoOrigen.Y + 200, 78, 80)
    End Sub
#End Region

#Region " 56 - ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN"
    Private WithEvents DocImp_ICQGRALF10 As New PrintDocument
    Private Sub DocImpr_ICQGRALF10(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICQGRALF10.PrintPage
        Dim puntoOrigen As New Point(20, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 765, 970)
        e.Graphics.DrawString("REGISTRO DE INDUCCIÓN - ENTRENAMIENTO - CAPACITACIÓN ", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 165, puntoOrigen.Y + 35)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawString("ICQ-GRAL-F-010", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 655, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 660, puntoOrigen.Y + 56)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 41, puntoOrigen.X + 765, puntoOrigen.Y + 41) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 82, puntoOrigen.X + 765, puntoOrigen.Y + 82) 'Horizontal completa

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 30, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 87)
        e.Graphics.DrawString("INDUCCIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 46, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 140, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ENTRENAMIENTO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 156, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 290, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CAPACITACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 306, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 430, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CHARLA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 446, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("REUNIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 546, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 640, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ACTIVIDAD", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 84)
        e.Graphics.DrawString("LÚDICA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 96)

        e.Graphics.DrawString("AREA FRENTE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 125)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 55
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 126)
            Case Else
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 129)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 139, puntoOrigen.X + 531, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 125)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_7, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 126)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 139, puntoOrigen.X + 750, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("LUGAR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 150)
        e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 164, puntoOrigen.X + 531, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("DURACIÓN:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 150)
        e.Graphics.DrawString("2 HORAS", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 164, puntoOrigen.X + 750, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("CAPACITADOR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 175)
        e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 189, puntoOrigen.X + 531, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 175)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 189, puntoOrigen.X + 750, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("TEMAS:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 40, puntoOrigen.Y + 240)
        e.Graphics.DrawString("INDUCCION ADMINISTRATIVA; REGLAMENTO INTERNO DE TRABAJO; SISTEMA GENERAL DE SEGURIDAD SOCIAL INTEGRAL;", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 230)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 240, puntoOrigen.X + 750, puntoOrigen.Y + 240) 'Horizontal
        e.Graphics.DrawString("JORNADA LABORAL; PAGO DE NOMINA; PERMISOS; DEBERES, DERECHOS, OBLIGACIONES Y PROHIBICIONES; DIVULGACION ", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 243)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 253, puntoOrigen.X + 750, puntoOrigen.Y + 253) 'Horizontal
        e.Graphics.DrawString("POLITICAS CORPORATIVAS; DIVULGACIÓN CODIGO DE ETICA; COMITÉ DE CONVIVENCIA LABORAL; SEGURIDAD VIAL Y", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 256)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 266, puntoOrigen.X + 750, puntoOrigen.Y + 266) 'Horizontal
        e.Graphics.DrawString("SEGURIDAD FISICA; DIVULGACIÓN PROGRAMA DE PQRS; PROCESO DISCIPLINARIO; ESCALA DE FALTAS", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 269)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 279, puntoOrigen.X + 750, puntoOrigen.Y + 279) 'Horizontal
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 290, puntoOrigen.X + 765, puntoOrigen.Y + 290) 'Horizontal
        e.Graphics.DrawString("Manifiesto que he recibido y entendido en todo su alcance el tema tratado y me comprometo a cumplir con el procedimiento o contenido de los temas y", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 296)
        e.Graphics.DrawString("responsabilidades a mi asignadas. En constancia firmo,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 312)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 326, puntoOrigen.X + 765, puntoOrigen.Y + 326) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 332
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 1, 763, 19)
        e.Graphics.DrawString(" 1.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 133, puntoOrigen.Y + 3)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 22, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 378, puntoOrigen.Y + 3)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 25)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
        End Select
        e.Graphics.DrawString("No. Cédula", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 512, puntoOrigen.Y + 3)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 493, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 661, puntoOrigen.Y + 3)
        Dim puntorec As New Point(puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 5
        puntoOrigen.Y = puntoOrigen.Y + 22
        'Completar lineas horizontales
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 745, puntoOrigen.Y) 'Horizontal completa
        Dim conlineas As Integer
        For conlineas = 0 To 24
            If puntoOrigen.Y < 1000 Then
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 764, puntoOrigen.Y) 'Horizontal completa
                puntoOrigen.Y = puntoOrigen.Y + 27
            Else
                Exit For
            End If
        Next
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntorec.Y, puntoOrigen.X + 21, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 291, puntorec.Y, puntoOrigen.X + 291, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 492, puntorec.Y, puntoOrigen.X + 492, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 601, puntorec.Y, puntoOrigen.X + 601, 1010) 'Vertical
    End Sub
#End Region

#Region " 58 - ICH-GRAL-F-357 CONSENTIMIENTO INFORMADO"
    Private WithEvents DocImp_ICHGRALF357 As New PrintDocument

    Private Sub DocImpr_ICHGRALF357(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF357.PrintPage
        Dim puntoOrigen As New Point(55, 53)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 708, 950)
        e.Graphics.DrawString("CONSENTIMIENTO INFORMADO", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 240, puntoOrigen.Y + 43)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawString("ICH-GRAL-F-357", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 588, puntoOrigen.Y + 20)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 594, puntoOrigen.Y + 70)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y, puntoOrigen.X + 125, puntoOrigen.Y + 101) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 10, puntoOrigen.Y + 10, 100, 80)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 563, puntoOrigen.Y, puntoOrigen.X + 563, puntoOrigen.Y + 101) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 563, puntoOrigen.Y + 50, puntoOrigen.X + 708, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 101, puntoOrigen.X + 708, puntoOrigen.Y + 101) 'Horizontal completa
        puntoOrigen.X = puntoOrigen.X + 11
        puntoOrigen.Y = puntoOrigen.Y + 101
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 37, 142, 52)
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 38, 140, 23)
        e.Graphics.DrawString("Fecha", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 50, puntoOrigen.Y + 43)
        e.Graphics.DrawString(Date.Today, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + InicioCentradoTexto(Date.Today, Formato_Etiqueta_10R, 142, e), puntoOrigen.Y + 72)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 61, puntoOrigen.X + 142, puntoOrigen.Y + 61) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 492, puntoOrigen.Y + 37, 192, 52)
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 493, puntoOrigen.Y + 38, 190, 23)
        e.Graphics.DrawString("HC", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 572, puntoOrigen.Y + 43)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 492 + InicioCentradoTexto(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, 192, e), puntoOrigen.Y + 72)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 492, puntoOrigen.Y + 61, puntoOrigen.X + 684, puntoOrigen.Y + 61) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 108, 190, 52)
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 109, 188, 23)
        e.Graphics.DrawString("PRIMER APELLIDO", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 27, puntoOrigen.Y + 114)
        e.Graphics.DrawString(_filaPersona("PRIMERAPELLIDO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + InicioCentradoTexto(_filaPersona("PRIMERAPELLIDO"), Formato_Etiqueta_10R, 190, e), puntoOrigen.Y + 142)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 131, puntoOrigen.X + 190, puntoOrigen.Y + 131) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 203, puntoOrigen.Y + 108, 195, 52)
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 204, puntoOrigen.Y + 109, 193, 23)
        e.Graphics.DrawString("SEGUNDO APELLIDO", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 223, puntoOrigen.Y + 114)
        e.Graphics.DrawString(_filaPersona("SEGUNDOAPELLIDO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 203 + InicioCentradoTexto(_filaPersona("SEGUNDOAPELLIDO"), Formato_Etiqueta_10R, 195, e), puntoOrigen.Y + 142)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 203, puntoOrigen.Y + 131, puntoOrigen.X + 398, puntoOrigen.Y + 131) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 414, puntoOrigen.Y + 108, 270, 52)
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 415, puntoOrigen.Y + 109, 268, 23)
        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 514, puntoOrigen.Y + 114)
        e.Graphics.DrawString(_filaPersona("NOMBRES"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 414 + InicioCentradoTexto(_filaPersona("NOMBRES"), Formato_Etiqueta_10R, 270, e), puntoOrigen.Y + 142)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 414, puntoOrigen.Y + 131, puntoOrigen.X + 684, puntoOrigen.Y + 131) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y + 208, 684, 408)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y + 658, 684, 175)
        puntoOrigen.Y = puntoOrigen.Y + 218
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Yo tal como firmo, me manifiesto informado de los actos médicos del Programa de Vigilancia Epidemiológico de ISMOCOL S.A. (Examen médico ocupacional de ingreso, " & _
                    "periódico, tareas críticas, reenganche, retiro, valoración posincapacidad, valoración biomecánica, valoración psíquica en riesgos psicosocial, valoración de trabajadoras " & _
                    "gestantes y demás actos médicos), autorizo la práctica de alcoholimetrías, pruebas clínicas y paraclínicas y acato sus resultados, los cuales hacen parte del Programa de Vigilancia Epidemiológica en procura de preservar mi salud. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Me comprometo a colaborar con el Programa de Vigilancia Epidemiológica de ISMOCOL S.A., a suministrar información clara, veraz " & _
                    "y sin omitir conscientemente datos de mi estado real de salud.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Autorizo para que mis resultados sean custodiados en forma física o electrónica, por los médicos que intervienen dentro del programa de Vigilancia Epidemiológica de ISMOCOL S.A.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 10
        '********************************************************************
        Cadenas.Clear()
        Cadenas.Add("Todo lo anterior respetando mis derechos a la confidencialidad, inalterabilidad de resultados, cuidado y disponibilidad; descritos en la Resolución 1918 de 2009 y la Resolución 0839 de 2017.")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        e.Graphics.DrawString("FIRMA DEL PACIENTE", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 105, puntoOrigen.Y + 160)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 260, puntoOrigen.Y + 174, puntoOrigen.X + 650, puntoOrigen.Y + 174) 'Horizontal
        e.Graphics.DrawString("C.C.", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 188)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 260, puntoOrigen.Y + 202, puntoOrigen.X + 470, puntoOrigen.Y + 202) 'Horizontal
        e.Graphics.DrawString("de", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 470, puntoOrigen.Y + 188)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 490, puntoOrigen.Y + 202, puntoOrigen.X + 650, puntoOrigen.Y + 202) 'Horizontal
    End Sub
#End Region

#Region " 59 - DECLARACIÓN DE PREEXISTENCIA DE PATOLOGÍA - RENUNCIA ACCIONES JUDICIALES"
    Private WithEvents DocImp_DeclaracionPreexistenciaPatologia As New PrintDocument

    Public Sub DocImpr_DeclaracionPreexistenciaPatologia(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_DeclaracionPreexistenciaPatologia.PrintPage
        DeclaracionPreexistenciaPatologia(e)
    End Sub

    Public Sub DeclaracionPreexistenciaPatologia(ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        'Private Sub DocImpr_DeclaracionPreexistenciaPatologia(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_DeclaracionPreexistenciaPatologia.PrintPage
        Dim puntoOrigen As New Point(120, 145)
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_10RS, Brocha, puntoOrigen.X + 110, puntoOrigen.Y)
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 52
        e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("Bucaramanga", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 52
        e.Graphics.DrawString("Asunto: Declaración de preexistencia de patología - renuncia acciones judiciales", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 53
        e.Graphics.DrawString("Cordial saludo.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 52
        Dim Cadenas As New ArrayList
        Cadenas.Add("Por medio del presente escrito hago constar que las afecciones que me fueron encontradas en el examen médico de ingreso, existen desde antes de iniciar el vínculo laboral para el cual me he postulado. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 20
        Cadenas.Clear()
        Cadenas.Add("Por lo anterior manifiesto de manera consciente y voluntaria, que RENUNCIO a cualquier acción judicial, constitucional o extrajudicial en contra de ISMOCOL S.A., para obtener estabilidad laboral reforzada por mi condición de salud. " & _
                    "Así mismo, me comprometo a observar, acatar y cumplir las medidas, normas e instrucciones de higiene, seguridad y salud en el trabajo de ISMOCOL S.A., las autoridades del ramo, el médico tratante y el Departamento de HSE. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 20
        Cadenas.Clear()
        Cadenas.Add("Lo anterior en reconocimiento a la oportunidad de trabajo que me brinda la Empresa, aun teniendo una patología con la que puedo prestar el servicio en el cargo al cual estoy siendo postulado. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 600.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 600.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        '********************************************************************
        puntoOrigen.Y = puntoOrigen.Y + 50
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 65
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 60, puntoOrigen.Y + 14, puntoOrigen.X + 200, puntoOrigen.Y + 14) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 60, puntoOrigen.Y + 14, puntoOrigen.X + 200, puntoOrigen.Y + 14) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("C.C.:", Formato_Etiqueta_8R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 60, puntoOrigen.Y + 14, puntoOrigen.X + 200, puntoOrigen.Y + 14) 'Horizontal
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 250, puntoOrigen.Y - 75, 65, 90)
        e.Graphics.DrawString("Huella", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 260, puntoOrigen.Y + 18)
    End Sub
#End Region

#Region " 80 - ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN OCENSA"
    Private WithEvents DocImp_ICQGRALF10OCENSA As New PrintDocument
    Private Sub DocImpr_ICQGRALF10OCENSA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICQGRALF10OCENSA.PrintPage
        Dim puntoOrigen As New Point(20, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 765, 975)
        e.Graphics.DrawString("REGISTRO DE INDUCCIÓN - ENTRENAMIENTO - CAPACITACIÓN ", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 165, puntoOrigen.Y + 35)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawString("ICQ-GRAL-F-010", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 655, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 660, puntoOrigen.Y + 56)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 41, puntoOrigen.X + 765, puntoOrigen.Y + 41) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 82, puntoOrigen.X + 765, puntoOrigen.Y + 82) 'Horizontal completa

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 30, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 87)
        e.Graphics.DrawString("INDUCCIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 46, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 140, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ENTRENAMIENTO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 156, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 290, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CAPACITACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 306, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 430, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CHARLA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 446, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("REUNIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 546, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 640, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ACTIVIDAD", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 84)
        e.Graphics.DrawString("LÚDICA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 96)

        e.Graphics.DrawString("AREA FRENTE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 125)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 55
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 126)
            Case Else
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 129)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 139, puntoOrigen.X + 531, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 125)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_7, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 126)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 139, puntoOrigen.X + 750, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("LUGAR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 150)
        e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 164, puntoOrigen.X + 531, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("DURACIÓN:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 150)
        If _filaContrato("IDBASESISCONTROL") = 121 Then
            e.Graphics.DrawString("4 HORAS", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 149)
        Else
            e.Graphics.DrawString("2 HORAS", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 149)
        End If

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 164, puntoOrigen.X + 750, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("CAPACITADOR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 175)
        If _filaContrato("IDBASESISCONTROL") = 125 Then
            e.Graphics.DrawString("", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("COORDINADORHSE"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 189, puntoOrigen.X + 531, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 175)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 189, puntoOrigen.X + 750, puntoOrigen.Y + 189) 'Horizontal

        e.Graphics.DrawString("TEMAS:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 200)
        e.Graphics.DrawString("*MISIÓN / VISIÓN *NUESTRA FILOSOFÍA HSE *ATRIBUTOS OCENSA * VALORES ISMOCOL *LA ETICA DEL CUIDADO (OCENSA) *DECALOGO", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y + 202)
        e.Graphics.DrawString("CULTURA CORP.", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 75, puntoOrigen.Y + 214)

        puntoOrigen.Y = puntoOrigen.Y + 225
        Dim Cadenas As New ArrayList
        Cadenas.Add("* POLÍTICAS CORPORATIVAS DE ISMOCOL S.A. Y OCENSA * OBJETIVOS Y METAS EN SST * REGLAS PARA LA VIDA * REQUISITOS PARA INICIAR UNA ACTIVIDAD * PTW * CERTIFICADOS DE APOYO * ART * PROCEDIMIENTOS SEGUROS * INSPECCIÓN DE HTAS Y EQUI. * ¿QUÉ HACER ANTES DE EJECUTAR UNA ACTIVIDAD * A&C * REPORTE DE ACTOS Y CONDICIONES SUBESTANDAR * INCIDENTES * ¿QUÉ ESTÁ HACIENDO USTED PARA CUIDARSE? * PRIORIZACIÓN DE RIESGOS * REPRESENTANTE DE LOS SISTEMAS DE GESTIÓN SGC SGSST SGA * EPP * MEDICINA PREVENTIVA Y CONTROL DE SALUD * COPASST * PLAN DE EMERGENCIAS * PAEMED * PESVE * REGLAMENTO PARA USO Y MANEJO DE VEHÍCULOS DE LA COMPAÑÍA CIRCULAR N°128-2017 PROHIBICIÓN USO DE MOTOCICLETAS O SERVICIOS INFORMALES EN ACTIVIDADES LABORALES * ACCIDENTES DE TRÁNSITO * ASPECTOS E IMPACTOS AMBIENTALES SIGNIFICATIVOS * OBLIGACIONES AMBIENTALES * OBJETIVOS Y METAS AMBIENTALES * MANEJO DE RESIDUOS * ETIQUETADO DE PRODUCTOS QUÍMICOS HMIS III * PROGRAMA DE USO RACIONAL DE AGUA, ENERGÍA Y COMBUSTIBLE * REGLAMENTO DE TRABAJO * REGLAMENTO DE HIGIENE Y SEGURIDAD INDUSTRIAL * PQRS * COMITÉ DE CONVIVENCIA LABORAL * SISTEMA GENERAL DE SEGURIDAD SOCIAL INTEGRAL * CÓDIGO DE CONDUCTA * SEGURIDAD FÍSICA * CIRCULAR NORMATIVA N°151-2021 REV. N°0 AUTORIDAD PARA DETENER LOS TRABAJOS INSEGUROS. ")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 740.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 740.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 10
        Next

        puntoOrigen.Y = puntoOrigen.Y - 295
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 290, puntoOrigen.X + 765, puntoOrigen.Y + 290) 'Horizontal
        e.Graphics.DrawString("Manifiesto que he recibido y entendido en todo su alcance el tema tratado y me comprometo a cumplir con el procedimiento o contenido de los temas y", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 296)
        e.Graphics.DrawString("responsabilidades a mi asignadas. En constancia firmo,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 312)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 326, puntoOrigen.X + 765, puntoOrigen.Y + 326) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 332
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 1, 763, 19)
        e.Graphics.DrawString(" 1.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 133, puntoOrigen.Y + 3)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 22, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 378, puntoOrigen.Y + 3)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 25)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
        End Select
        e.Graphics.DrawString("No. Cédula", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 512, puntoOrigen.Y + 3)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 493, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 661, puntoOrigen.Y + 3)
        Dim puntorec As New Point(puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 5
        puntoOrigen.Y = puntoOrigen.Y + 22
        'Completar lineas horizontales
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 745, puntoOrigen.Y) 'Horizontal completa
        Dim conlineas As Integer
        For conlineas = 0 To 24
            If puntoOrigen.Y < 1000 Then
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 764, puntoOrigen.Y) 'Horizontal completa
                puntoOrigen.Y = puntoOrigen.Y + 27
            Else
                Exit For
            End If
        Next
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntorec.Y, puntoOrigen.X + 21, 1015) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 291, puntorec.Y, puntoOrigen.X + 291, 1015) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 492, puntorec.Y, puntoOrigen.X + 492, 1015) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 601, puntorec.Y, puntoOrigen.X + 601, 1015) 'Vertical
    End Sub
#End Region

#Region " 81 - ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN ODC"
    Private WithEvents DocImp_ICQGRALF10ODC As New PrintDocument
    Private Sub DocImpr_ICQGRALF10ODC(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICQGRALF10ODC.PrintPage
        Dim puntoOrigen As New Point(20, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 765, 970)
        e.Graphics.DrawString("REGISTRO DE INDUCCIÓN - ENTRENAMIENTO - CAPACITACIÓN ", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 165, puntoOrigen.Y + 35)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawString("ICQ-GRAL-F-010", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 655, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 660, puntoOrigen.Y + 56)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 41, puntoOrigen.X + 765, puntoOrigen.Y + 41) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 82, puntoOrigen.X + 765, puntoOrigen.Y + 82) 'Horizontal completa

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 30, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 87)
        e.Graphics.DrawString("INDUCCIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 46, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 140, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ENTRENAMIENTO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 156, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 290, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CAPACITACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 306, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 430, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CHARLA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 446, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("REUNIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 546, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 640, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ACTIVIDAD", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 84)
        e.Graphics.DrawString("LÚDICA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 96)

        e.Graphics.DrawString("AREA FRENTE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 125)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 55
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 126)
            Case Else
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 129)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 139, puntoOrigen.X + 531, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 125)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_7, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 126)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 139, puntoOrigen.X + 750, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("LUGAR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 150)
        e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 164, puntoOrigen.X + 531, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("DURACIÓN:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 150)
        e.Graphics.DrawString("4 HORAS", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 164, puntoOrigen.X + 750, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("CAPACITADOR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 175)
        If _filaContrato("IDBASESISCONTROL") = 125 Then
            e.Graphics.DrawString("", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("COORDINADORHSE"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 189, puntoOrigen.X + 531, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 175)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 189, puntoOrigen.X + 750, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("TEMAS:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 200)
        e.Graphics.DrawString("* MISIÓN / VISIÓN * NUESTRA FILOSOFÍA HSE * VALORES ISMOCOL * POLÍTICAS CORPORATIVAS DE ISMOCOL S.A. PRINCIPIOS ÉTICOS ODC ", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 65, puntoOrigen.Y + 204)

        puntoOrigen.Y = puntoOrigen.Y + 215
        Dim Cadenas As New ArrayList
        Cadenas.Add("* POLÍTICAS ODC * CERTIFICACIONES DE LOS SG * OBJETIVOS Y METAS EN SST * REGLAS FUNDAMENTALES QUE SALVAN VIDAS ECP * PTW * CERTIFICADOS DE APOYO * AR * PROCEDIMIENTOS SEGUROS * INSPECCIÓN DE HTAS Y EQUIPOS * ¿QUÉ HACER ANTES DE EJECUTAR UNA ACTIVIDAD * MANUAL CONTROL Y PERMISOS DE TRABAJO ODC * A&C Y FALLAS DE CONTROL * INCIDENTES * PRIORIZACIÓN DE RIESGOS * REQUISITOS LEGALES * REPRESENTANTE DE LOS SISTEMAS DE GESTIÓN SGC SGSST SGA * EPP * COPASST * PLAN DE EMERGENCIAS * PAEMED * PESVE * REGLAMENTO PARA USO Y MANEJO DE VEHÍCULOS DE LA COMPAÑÍA CIRCULAR N°128-2017 PROHIBICIÓN USO DE MOTOCICLETAS O SERVICIOS INFORMALES EN ACTIVIDADES LABORALES * ACCIDENTES DE TRÁNSITO * ASPECTOS E IMPACTOS AMBIENTALES SIGNIFICATIVOS * OBLIGACIONES AMBIENTALES * OBJETIVOS Y METAS AMBIENTALES * ASPECTO E IMPACTO AMBIENTAL * MANEJO DE RESIDUOS * ETIQUETADO DE PRODUCTOS QUÍMICOS HMIS III * PROGRAMA DE USO RACIONAL DE AGUA, ENERGÍA Y COMBUSTIBLE * PQRS * COMITÉ DE CONVIVENCIA LABORAL * SEGURIDAD FÍSICA * CIRCULAR NORMATIVA N°151-2021 REV. N°0 AUTORIDAD PARA DETENER LOS TRABAJOS INSEGUROS.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 740.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 740.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 10
        Next

        puntoOrigen.Y = puntoOrigen.Y - 295
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 290, puntoOrigen.X + 765, puntoOrigen.Y + 290) 'Horizontal
        e.Graphics.DrawString("Manifiesto que he recibido y entendido en todo su alcance el tema tratado y me comprometo a cumplir con el procedimiento o contenido de los temas y", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 296)
        e.Graphics.DrawString("responsabilidades a mi asignadas. En constancia firmo,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 312)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 326, puntoOrigen.X + 765, puntoOrigen.Y + 326) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 332
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 1, 763, 19)
        e.Graphics.DrawString(" 1.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 133, puntoOrigen.Y + 3)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 22, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 378, puntoOrigen.Y + 3)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 25)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
        End Select
        e.Graphics.DrawString("No. Cédula", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 512, puntoOrigen.Y + 3)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 493, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 661, puntoOrigen.Y + 3)
        Dim puntorec As New Point(puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 5
        puntoOrigen.Y = puntoOrigen.Y + 22
        'Completar lineas horizontales
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 745, puntoOrigen.Y) 'Horizontal completa
        Dim conlineas As Integer
        For conlineas = 0 To 24
            If puntoOrigen.Y < 1000 Then
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 764, puntoOrigen.Y) 'Horizontal completa
                puntoOrigen.Y = puntoOrigen.Y + 27
            Else
                Exit For
            End If
        Next
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntorec.Y, puntoOrigen.X + 21, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 291, puntorec.Y, puntoOrigen.X + 291, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 492, puntorec.Y, puntoOrigen.X + 492, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 601, puntorec.Y, puntoOrigen.X + 601, 1010) 'Vertical
    End Sub
#End Region

#Region " 82 - CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN - OCENSA"
    Private WithEvents DocImp_ICAMOCEF077 As New PrintDocument

    Private Sub DocImpr_ICAMOCEF077(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAMOCEF077.PrintPage
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM ListaDocumentos(@ACCION, @IDDOCUMENTO, @REVISION) ORDER BY [IDDOCUMENTO]", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1) 'Listar por IdDocumentoImprimir y Revisión
            comando.Parameters.AddWithValue("@IDDOCUMENTO", 82) 'ICA-MOCE-F-077
            comando.Parameters.AddWithValue("@REVISION", 1) 'Rev. 1
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtDocumentos As New DataTable
            Try
                adaptador.Fill(dtDocumentos)
                If dtDocumentos.Rows.Count > 0 Then
                    listaImagenesBD = New List(Of Image)
                    For k = 0 To dtDocumentos.Rows.Count - 1
                        Dim filadoc As DataRow = dtDocumentos.Rows(k)

                        Dim byteBLOBData(-1) As [Byte]
                        byteBLOBData = CType(filadoc("BLOB"), [Byte]())
                        Dim stmBLOBData As New IO.MemoryStream(byteBLOBData)
                        listaImagenesBD.Add(Image.FromStream(stmBLOBData))
                    Next
                    datosCargados = True
                Else
                    Throw New Exception("No se encontraron datos de impresión.")
                End If
            Catch ex As Exception
                Throw New Exception("No se encontraron datos de impresión.", ex)
            Finally
                conexion.Close()
            End Try
        End If
        e.Graphics.DrawImage(listaImagenesBD.Item(contadorPaginasImpresas), -30, -40, 850, 1100) 'e.PageBounds.Left - 30, e.PageBounds.Top - 40, e.PageBounds.Right, e.PageBounds.Bottom)
        Select Case (contadorPaginasImpresas + 1)
            Case 1 'Página 1
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, 160, 127)
                e.Graphics.DrawString(Trim(_filaContrato("NOMBRETIPOCARGO")) + " - " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, 210, 154)
                e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, 130, 181)
                e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_8R, Brocha, 460, 181)
            Case 2 'Página 2

            Case 3 'Página 3

            Case 4 'Página 4

            Case 5 'Página 5

            Case 6 'Página 6

        End Select
        contadorPaginasImpresas += 1
        If contadorPaginasImpresas <= listaImagenesBD.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            contadorPaginasImpresas = 0
        End If

    End Sub
#End Region

#Region " 84 - CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN - ODC"
    Private WithEvents DocImp_ICAMOCEF076 As New PrintDocument

    Private Sub DocImpr_ICAMOCEF076(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAMOCEF076.PrintPage
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM ListaDocumentos(@ACCION, @IDDOCUMENTO, @REVISION) ORDER BY [IDDOCUMENTO]", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1) 'Listar por IdDocumentoImprimir y Revisión
            comando.Parameters.AddWithValue("@IDDOCUMENTO", 84) 'ICA-MOCE-F-076
            comando.Parameters.AddWithValue("@REVISION", 1) 'Rev. 1
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtDocumentos As New DataTable
            Try
                adaptador.Fill(dtDocumentos)
                If dtDocumentos.Rows.Count > 0 Then
                    listaImagenesBD = New List(Of Image)
                    For k = 0 To dtDocumentos.Rows.Count - 1
                        Dim filadoc As DataRow = dtDocumentos.Rows(k)

                        Dim byteBLOBData(-1) As [Byte]
                        byteBLOBData = CType(filadoc("BLOB"), [Byte]())
                        Dim stmBLOBData As New IO.MemoryStream(byteBLOBData)
                        listaImagenesBD.Add(Image.FromStream(stmBLOBData))
                    Next
                    datosCargados = True
                Else
                    Throw New Exception("No se encontraron datos de impresión.")
                End If
            Catch ex As Exception
                Throw New Exception("No se encontraron datos de impresión.", ex)
            Finally
                conexion.Close()
            End Try
        End If
        e.Graphics.DrawImage(listaImagenesBD.Item(contadorPaginasImpresas), -30, -40, 850, 1100) 'e.PageBounds.Left - 30, e.PageBounds.Top - 40, e.PageBounds.Right, e.PageBounds.Bottom)
        Select Case (contadorPaginasImpresas + 1)
            Case 1 'Página 1
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, 140, 135)
                e.Graphics.DrawString(Trim(_filaContrato("NOMBRETIPOCARGO")) + " - " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, 190, 162)
                e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, 120, 189)
                e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_8R, Brocha, 450, 189)
            Case 2 'Página 2

            Case 3 'Página 3

            Case 4 'Página 4

            Case 5 'Página 5

            Case 6 'Página 6

        End Select
        contadorPaginasImpresas += 1
        If contadorPaginasImpresas <= listaImagenesBD.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            contadorPaginasImpresas = 0
        End If

    End Sub
#End Region

#Region " 86 - ICH-MOCE-F-079 CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA POLÍTICA DE SEGURIDAD, SALUD EN EL TRABAJO Y AMBIENTAL (SSTA)"
    Private WithEvents DocImp_ICHMOCEF079 As New PrintDocument
    Private Sub DocImpr_ICHMOCEF079(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHMOCEF079.PrintPage
        Dim puntoOrigen As New Point(45, 42)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 740, 942)
        e.Graphics.DrawStringCentered("CONSTANCIA Y EVALUACIÓN DE LA EFICACIA", Formato_Etiqueta_10, Brocha, 470, puntoOrigen.X + 158, puntoOrigen.Y + 22)
        e.Graphics.DrawStringCentered("DE LA POLÍTICA DE SEGURIDAD, SALUD EN EL TRABAJO Y", Formato_Etiqueta_10, Brocha, 470, puntoOrigen.X + 158, puntoOrigen.Y + 40)
        e.Graphics.DrawStringCentered("AMBIENTAL (SSTA)", Formato_Etiqueta_10, Brocha, 470, puntoOrigen.X + 158, puntoOrigen.Y + 56)
        e.Graphics.DrawStringCentered("ICH-MOCE-F-079", Formato_Etiqueta_8, Brocha, 112, puntoOrigen.X + 628, puntoOrigen.Y + 15)
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_8, Brocha, 112, puntoOrigen.X + 628, puntoOrigen.Y + 56)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 158, puntoOrigen.Y, puntoOrigen.X + 158, puntoOrigen.Y + 90) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 35, puntoOrigen.Y + 10, 95, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 628, puntoOrigen.Y, puntoOrigen.X + 628, puntoOrigen.Y + 90) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 628, puntoOrigen.Y + 41, puntoOrigen.X + 740, puntoOrigen.Y + 41) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 90, puntoOrigen.X + 740, puntoOrigen.Y + 90) 'Horizontal completa 

        puntoOrigen.X = puntoOrigen.X + 5
        puntoOrigen.Y = puntoOrigen.Y + 90

        e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 17)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 158, puntoOrigen.Y + 17)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 153, puntoOrigen.Y + 31, puntoOrigen.X + 695, puntoOrigen.Y + 31) 'Horizontal
        e.Graphics.DrawString("CARGO - CÓDIGO", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 38)
        e.Graphics.DrawString(Trim(_filaContrato("NOMBRETIPOCARGO")) + " - " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 158, puntoOrigen.Y + 38)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 153, puntoOrigen.Y + 52, puntoOrigen.X + 695, puntoOrigen.Y + 52) 'Horizontal
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 60)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 158, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 153, puntoOrigen.Y + 74, puntoOrigen.X + 695, puntoOrigen.Y + 74) 'Horizontal

        e.Graphics.DrawString("Certifico Haber recibido la Inducción Respectiva, y en constancia de ello, realizo el proceso de Evaluación Correspondiente.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 103)
        e.Graphics.DrawString("Marque con una X la respuesta correcta.", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 119)

        e.Graphics.DrawString("1.  ¿El cumplimiento a La política de Seguridad, Salud en el Trabajo y Ambiental  es un compromiso de?", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 155)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 180, 25, 75)
        e.Graphics.DrawString("a.   No es compromiso de nadie, solo para el que quiera cumplirla.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 182)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 195, puntoOrigen.X + 80, puntoOrigen.Y + 195) 'Horizontal
        e.Graphics.DrawString("b.   Para ISMOCOL S.A., sus trabajadores, proveedores, subcontratistas, visitantes e invitados en general.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 197)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 210, puntoOrigen.X + 80, puntoOrigen.Y + 210) 'Horizontal
        e.Graphics.DrawString("c.   Las Comunidades del área de influencia del proyecto.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 212)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 225, puntoOrigen.X + 80, puntoOrigen.Y + 225) 'Horizontal
        e.Graphics.DrawString("d.   Ejército, Policía, Bomberos, Cruz roja, entre otros.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 227)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 240, puntoOrigen.X + 80, puntoOrigen.Y + 240) 'Horizontal
        e.Graphics.DrawString("c.   Tema desconocido.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 242)

        e.Graphics.DrawString("2.  Una de las prioridades establecida mediante la política de Seguridad, Salud en el Trabajo y Ambiental  es:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 270)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 295, 25, 60)
        e.Graphics.DrawString("a.   Promover los conflictos dentro y fuera de la organización.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 297)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 310, puntoOrigen.X + 80, puntoOrigen.Y + 310) 'Horizontal
        e.Graphics.DrawString("b.   Prevenir lesiones personales,  enfermedades laborales, daños materiales, afectación de procesos y contaminación ambiental.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 312)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 325, puntoOrigen.X + 80, puntoOrigen.Y + 325) 'Horizontal
        e.Graphics.DrawString("c.   Velar por condiciones salariales favorables para los trabajadores.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 327)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 340, puntoOrigen.X + 80, puntoOrigen.Y + 340) 'Horizontal
        e.Graphics.DrawString("d.   Hacer cumplir el horario laboral a los trabajadores", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 342)

        e.Graphics.DrawString("3.  La sigla SSTA, significa:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 370)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 395, 25, 60)
        e.Graphics.DrawString("a.   Sociedad Segura de Trabajadores.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 397)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 410, puntoOrigen.X + 80, puntoOrigen.Y + 410) 'Horizontal
        e.Graphics.DrawString("b.   Seguridad, Salud en el Trabajo y Ambiental", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 412)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 425, puntoOrigen.X + 80, puntoOrigen.Y + 425) 'Horizontal
        e.Graphics.DrawString("c.   Sistema Social de Transito", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 427)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 440, puntoOrigen.X + 80, puntoOrigen.Y + 440) 'Horizontal
        e.Graphics.DrawString("d.   Sindicato Social de Trabajadores", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 442)

        e.Graphics.DrawString("4.  ¿Es responsabilidad de los trabajadores y subcontratistas mejorar el desempeño en SSTA?", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 470)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 495, 25, 30)
        e.Graphics.DrawString("a.   Falso (F)", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 497)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 510, puntoOrigen.X + 80, puntoOrigen.Y + 510) 'Horizontal
        e.Graphics.DrawString("b.   Verdadero (V)", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 512)

        e.Graphics.DrawString("5.  ¿Cómo apoya ISMOCOL S.A el compromiso con la Seguridad, Salud en el Trabajo y Ambiental?", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 540)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 565, 25, 45)
        e.Graphics.DrawString("a.   Brindando soporte y acompañamiento a las actividades que se desarrollen en temas de SSTA", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 567)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 580, puntoOrigen.X + 80, puntoOrigen.Y + 580) 'Horizontal
        e.Graphics.DrawString("b.   Asignando recursos humanos, técnicos, físicos y económicos para apoyar el SG-SSTA", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 582)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 595, puntoOrigen.X + 80, puntoOrigen.Y + 595) 'Horizontal
        e.Graphics.DrawString("c.   a y b son correctas.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 63, puntoOrigen.Y + 597)

        e.Graphics.DrawString("Marque el nivel de satisfacción con respecto a la inducción corporativa", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 95, puntoOrigen.Y + 642)
        e.Graphics.DrawString("___ Muy satisfecho", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 95, puntoOrigen.Y + 672)
        e.Graphics.DrawString("___ Satisfecho", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 225, puntoOrigen.Y + 672)
        e.Graphics.DrawString("___ Insatisfecho", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 355, puntoOrigen.Y + 672)
        e.Graphics.DrawString("___ Muy Insatisfecho", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 485, puntoOrigen.Y + 672)

        e.Graphics.DrawString("Firma del Trabajador___________________________________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 55, puntoOrigen.Y + 722)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 5, puntoOrigen.Y + 742, puntoOrigen.X + 735, puntoOrigen.Y + 742) 'Horizontal
        e.Graphics.DrawStringCentered("ESPACIO PARA SER DILIGENCIADO POR ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, 740, puntoOrigen.X, puntoOrigen.Y + 744)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 5, puntoOrigen.Y + 758, puntoOrigen.X + 735, puntoOrigen.Y + 758) 'Horizontal

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 758, 610, 25)
        e.Graphics.DrawString("CALIFICACIÓN OBTENIDA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 60, puntoOrigen.Y + 766)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 370, puntoOrigen.Y + 758, puntoOrigen.X + 370, puntoOrigen.Y + 783) 'Vertical
        e.Graphics.DrawString("PUNTOS", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 610, puntoOrigen.Y + 766)


        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 800, 610, 52)
        e.Graphics.DrawString("FORTALEZAS", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 60, puntoOrigen.Y + 806)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 55, puntoOrigen.Y + 822, puntoOrigen.X + 665, puntoOrigen.Y + 822) 'Horizontal
        e.Graphics.DrawString("DEBILIDADES", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 60, puntoOrigen.Y + 828)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 370, puntoOrigen.Y + 800, puntoOrigen.X + 370, puntoOrigen.Y + 852) 'Vertical

    End Sub
#End Region

#Region " 96 - ICA GRAL-F-031 SECCION NOMINA NOVEDADES LIQUIDACION FINAL CONTRATO"
    Private WithEvents DocImp_ICAGRALF031 As New PrintDocument

    Private Sub DocImpr_ICAGRALF031(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF031.PrintPage



        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(40, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("SECCIÓN NOMINA  ", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned(" NOVEDADES LIQUIDACIÓN FINAL CONTRATO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA GRAL-F-031", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 150
        puntoOrigen.X = puntoOrigen.X + 20
        Dim tabs As Integer = 100

        e.Graphics.DrawString("CÓDIGO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + tabs - 20, puntoOrigen.Y)
        e.Graphics.DrawString("FECHA INGRESO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 4 * tabs - 40, puntoOrigen.Y)
        e.Graphics.DrawString("" + CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + (6 * tabs) - 60, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20

        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        Dim nombre As String = _filaPersona("NOMBRECOMPLETO").ToString.Trim
        Select Case nombre.Length
            Case Is < 36
                e.Graphics.DrawString(nombre, Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + tabs - 20, puntoOrigen.Y)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(nombre, Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + tabs - 20, puntoOrigen.Y)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(nombre, 1, 50), Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + tabs - 20, puntoOrigen.Y + 2)
        End Select
        e.Graphics.DrawString("FECHA RETIRO: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 4 * tabs - 40, puntoOrigen.Y)
        e.Graphics.DrawString("" & If(Not IsDBNull(_filaContrato("FECHATERMINACIONCONTRATO")), CDate(_filaContrato("FECHATERMINACIONCONTRATO")).ToLongDateString, ""), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20

        e.Graphics.DrawString("CARGO:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        Dim Cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case Cargo.Length
            Case Is < 36
                e.Graphics.DrawString(Cargo, Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + tabs - 20, puntoOrigen.Y)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(Cargo, Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + tabs, puntoOrigen.Y + 2)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(Cargo, 1, 50), Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + tabs, puntoOrigen.Y + 2)

        End Select

        e.Graphics.DrawString("FECHA DE LIQUIDACIÓN:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 4 * tabs - 40, puntoOrigen.Y)
        e.Graphics.DrawString("" & If(Not IsDBNull(_filaContrato("FECHATERMINACIONCONTRATO")), CDate(_filaContrato("FECHATERMINACIONCONTRATO")).ToLongDateString, ""), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y)

        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("C.C:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("IDENTIFICACION"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + tabs - 20, puntoOrigen.Y) 'ClConvertir.Fun_FormatearCedula()
        e.Graphics.DrawString("MOTIVO DE LA ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 4 * tabs - 40, puntoOrigen.Y)

        Dim motivo As String = _filaContrato("NOMBRETIPOTERMINACIONCONTRATO").ToString.Trim
        Select Case motivo.Length
            Case Is < 16
                e.Graphics.DrawString(motivo, Formato_Etiqueta_8RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y)
                Exit Select
            Case Is <= 22
                e.Graphics.DrawString(motivo, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(motivo, 1, 28), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y)
                e.Graphics.DrawString(Mid(motivo, 29, 28), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y + 15)
                e.Graphics.DrawString(Mid(motivo, 57, 28), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 6 * tabs - 60, puntoOrigen.Y + 15)
        End Select
        puntoOrigen.Y = puntoOrigen.Y + 15

        e.Graphics.DrawString("LIQUIDACIÓN:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 4 * tabs - 40, puntoOrigen.Y)
        Dim drawFont As New Font("Arial", 6)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim x As Single = 60.0F
        Dim y As Single = 350.0F
        Dim width As Single = 90.0F
        Dim height As Single = 30.0F

        Dim drawFormat As New StringFormat
        Dim drawFormat2 As New StringFormat
        Dim drawFormat3 As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat2.LineAlignment = StringAlignment.Center
        drawFormat3.Alignment = StringAlignment.Near

        e.Graphics.DrawStringAligned("DEVENGADO", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 240, 300, puntoOrigen.Y + 50)
        'FILA 1
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height)   '1,1
        Dim drawRect As New RectangleF(x, y, width, height)
        e.Graphics.DrawString("DOMINICAL                       (009)", Formato_Etiqueta_5R, drawBrush, drawRect, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '1,2
        Dim drawRect11 As New RectangleF(x + width, y, width, height)
        e.Graphics.DrawString("COMPENSATORIOS             (008)", Formato_Etiqueta_5R, drawBrush, drawRect11, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '1,3
        Dim drawRect12 As New RectangleF(x + 2 * width, y, width, height)
        e.Graphics.DrawString("SALDO FAVOR                  (046)", Formato_Etiqueta_5R, drawBrush, drawRect12, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '1,4
        Dim drawRect13 As New RectangleF(x + 3 * width, y, width, height)
        e.Graphics.DrawString("SALDO CARGO                  (068)", Formato_Etiqueta_5R, drawBrush, drawRect13, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 1,5
        Dim drawRect14 As New RectangleF(x + 4 * width, y, width, height)
        e.Graphics.DrawString("PRIMA TÉCNICA               (035)", Formato_Etiqueta_5R, drawBrush, drawRect14, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 1,6
        Dim drawRect15 As New RectangleF(x + 5 * width, y, width, height)
        e.Graphics.DrawString("BONOS                             (031)", Formato_Etiqueta_5R, drawBrush, drawRect15, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 1,7
        Dim drawRect16 As New RectangleF(x + 6 * width, y, width, height)
        e.Graphics.DrawString("INDEMNIZACIÓN                (027)", Formato_Etiqueta_5R, drawBrush, drawRect16, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 1,7
        Dim drawRect17 As New RectangleF(x + 7 * width, y, width, height)
        e.Graphics.DrawString("OTROS ", Formato_Etiqueta_5R, drawBrush, drawRect17, drawFormat)
        y = y + height
        'FILA 2
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height) '2,1
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '2,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 2,5
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 2,6
        y = y + height
        'FILA 3
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height) '3,1
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '2,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 2,5
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 2,6
        y = y + height
        'FILA 4
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '3,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '3,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '3,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 3,5
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 2,6
        y = y + height
        x = 60.0F
        y = 540.0F
        e.Graphics.DrawStringAligned("DESCUENTOS Y/O DEDUCCIONES", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 240, 300, 500)
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat2.LineAlignment = StringAlignment.Center
        drawFormat3.Alignment = StringAlignment.Near
        'FILA 1
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height)   '1,1 
        Dim drawRectt As New RectangleF(x, y, width, height)
        e.Graphics.DrawString("PRESTAMOS                      (067)", Formato_Etiqueta_5R, drawBrush, drawRectt, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '1,2
        Dim drawRect111 As New RectangleF(x + width, y, width, height)
        e.Graphics.DrawString("ANTICIPO SALARIO                (069)", Formato_Etiqueta_5R, drawBrush, drawRect111, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '1,3
        Dim drawRect122 As New RectangleF(x + 2 * width, y, width, height)
        e.Graphics.DrawString("SALDO CARGO                     (068)", Formato_Etiqueta_5R, drawBrush, drawRect122, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '1,4
        Dim drawRect133 As New RectangleF(x + 3 * width, y, width, height)
        e.Graphics.DrawString("LLAMADA TELEF                 (062)", Formato_Etiqueta_5R, drawBrush, drawRect133, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 1,5
        Dim drawRect144 As New RectangleF(x + 4 * width, y, width, height)
        e.Graphics.DrawString("COOPERATIVA                     (061)", Formato_Etiqueta_5R, drawBrush, drawRect144, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 1,6
        Dim drawRect155 As New RectangleF(x + 5 * width, y, width, height)
        e.Graphics.DrawString("EMBARGO                         (060)", Formato_Etiqueta_5R, drawBrush, drawRect155, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 1,7
        Dim drawRect166 As New RectangleF(x + 6 * width, y, width, height)
        e.Graphics.DrawString("PENSION VOLUNTARIA                (078)", Formato_Etiqueta_5R, drawBrush, drawRect166, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 1,7
        Dim drawRect177 As New RectangleF(x + 7 * width, y, width, height)
        e.Graphics.DrawString("OTROS ", Formato_Etiqueta_5R, drawBrush, drawRect177, drawFormat)
        y = y + height
        'FILA 2
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height) '2,1
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '2,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 2,5
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 2,6
        y = y + height
        'FILA 3
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height) '3,1
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '2,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 2,5
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 2,6
        y = y + height
        'FILA 4
        e.Graphics.DrawRectangle(Lapiz, x, y, width, height)
        e.Graphics.DrawRectangle(Lapiz, x + width, y, width, height)  '3,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width, y, width, height) '3,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width, y, width, height)  '3,4
        e.Graphics.DrawRectangle(Lapiz, x + 4 * width, y, width, height)  ' 3,5
        e.Graphics.DrawRectangle(Lapiz, x + 5 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 6 * width, y, width, height)  ' 2,6
        e.Graphics.DrawRectangle(Lapiz, x + 7 * width, y, width, height)  ' 2,6
        y = y + height
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("OBSERVACIONES: ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, 700)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + tabs + 20, 710, puntoOrigen.X + 720, 710)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + tabs + 20, 725, puntoOrigen.X + 720, 725)
        e.Graphics.DrawString(_filaContrato("GLOSASOPENDIENTES"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + tabs + 20, 698)


        ' tercera tabla
        width = 180.0F
        height = 15.0F
        x = 60.0F
        y = 780.0F
        Dim drawFormatt As New StringFormat
        Dim drawFormat23t As New StringFormat
        Dim drawFormat33t As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat2.LineAlignment = StringAlignment.Center
        drawFormat3.Alignment = StringAlignment.Near

        y = y + height

        'FILA 2
        e.Graphics.DrawRectangle(Lapiz, x, y, width / 2, height)   '1,1

        Dim drawRect21 As New RectangleF(x - 90 + width, y, width + 30, height)
        e.Graphics.DrawString("ELABORÓ", Formato_Etiqueta_9R, drawBrush, drawRect21, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width - 90, y, width + 30, height)  '1,2
        Dim drawRect22 As New RectangleF(x + 2 * width - 60, y, width + 30, height)
        e.Graphics.DrawString("REVISÓ", Formato_Etiqueta_9R, drawBrush, drawRect22, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width - 60, y, width + 30, height) '1,3
        Dim drawRect23 As New RectangleF(x + 3 * width - 30, y, width + 30, height)
        e.Graphics.DrawString("APROBÓ", Formato_Etiqueta_9R, drawBrush, drawRect23, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width - 30, y, width + 30, height)  '1,4

        y = y + height
        'FILA 
        e.Graphics.DrawRectangle(Lapiz, x, y, width / 2, 3 * height) '2,1
        Dim drawRect31 As New RectangleF(x, y, width / 2, 3 * height)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_9R, drawBrush, drawRect31, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width - 90, y, width + 30, 3 * height)  '2,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width - 60, y, width + 30, 3 * height) '2,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width - 30, y, width + 30, 3 * height)  '2,4
        y = y + 3 * height

        'FILA 4
        e.Graphics.DrawRectangle(Lapiz, x, y, width / 2, height) '3,1
        Dim drawRect41 As New RectangleF(x, y, width / 2, height)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_9R, drawBrush, drawRect41, drawFormat)
        e.Graphics.DrawRectangle(Lapiz, x + width - 90, y, width + 30, height)  '3,2
        e.Graphics.DrawRectangle(Lapiz, x + 2 * width - 60, y, width + 30, height) '3,3
        e.Graphics.DrawRectangle(Lapiz, x + 3 * width - 30, y, width + 30, height)  '3,4

        y = y + height
        'FILA 5



    End Sub
#End Region

#Region "  FORMATO DE AFILIACIÓN-SEGURO EXEQUIAL-COFUNERARIA LOS OLIVOS- NUMERAL 7.3 INSTRUCTIVO PARA LA APLICACIÓN DE CONDICIONES LABORALES PARA CONTRATISTAS VERSION 4 OCENSA"
    Private WithEvents DocImp_FormatoAfiliacionSeguro As New PrintDocument

    Private Nueva_Pagina As Integer = 1


#End Region
    Private Sub DocImpr_FormatoAfiliacionSeguro(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_FormatoAfiliacionSeguro.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        Dim fechaDocumento As Date = Date.Now
        If VariablesBase.VariablesBase.AbreviaturaBaseSiscontrol = "BUC" Then


            Dim puntoOrigen As New Point(40, 60)
            e.Graphics.DrawString("CÓDIGO No.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 590, puntoOrigen.Y - 15)
            If Not IsNothing(_filaContrato) Then

                e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X + 695, puntoOrigen.Y - 15)
            Else
                e.Graphics.DrawString("", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 695, puntoOrigen.Y - 15)
            End If





            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 665, puntoOrigen.Y - 20, 100, 20)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 975)
            e.Graphics.DrawStringCentered("FORMATO DE AFILIACIÓN - PLAN EXEQUIAL - LOS OLIVOS - ", Formato_Etiqueta_8, Brocha, 700, puntoOrigen.X + 90, puntoOrigen.Y + 15)
            e.Graphics.DrawStringCentered("PERSONAL ESTABLECIMIENTO BÁSICO ", Formato_Etiqueta_8, Brocha, 700, puntoOrigen.X + 90, puntoOrigen.Y + 35)
            Dim puntorec1 As New Point(660, 30)
            '******************************************************************
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 82) 'Vertical
            e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 85, 70)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 60, puntoOrigen.X + 765, puntoOrigen.Y + 60) 'Horizontal
            e.Graphics.DrawStringCentered("PLAN EXEQUIAL No. 1714", Formato_Etiqueta_8, Brocha, 760, puntoOrigen.X + 60, puntoOrigen.Y + 65)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 82, puntoOrigen.X + 765, puntoOrigen.Y + 82) 'Horizontal completa
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 30, puntoOrigen.Y + 97, 12, 12)
            e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 97)
            e.Graphics.DrawString("REGISTRO INICIAL", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 46, puntoOrigen.Y + 97)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 300, puntoOrigen.Y + 97, 12, 12)
            e.Graphics.DrawString("MODIFICACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 316, puntoOrigen.Y + 97)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 600, puntoOrigen.Y + 97, 12, 12)
            e.Graphics.DrawString("REINTEGRO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 616, puntoOrigen.Y + 97)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 115, puntoOrigen.X + 765, puntoOrigen.Y + 115) 'Horizontal completa
            e.Graphics.DrawStringCentered("Este formato debe ser diligenciado en su totalidad con puño y letra del trabajador con datos precisos y reales.", Formato_Etiqueta_9, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 125)
            puntoOrigen.Y = puntoOrigen.Y + 150
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 200) 'Vertical
            e.Graphics.DrawStringRight("FECHA DE INGRESO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)

            If Not IsNothing(_filaContrato) Then
                e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            Else
                e.Graphics.DrawString(Format(Date.Today, "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("NOMBRE TRABAJADOR:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("CÉDULA:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("FECHA DE NACIMIENTO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(Format(_filaPersona("FECHANACIMIENTO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("CIUDAD RESIDENCIA:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(" ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("DIRECCIÓN RESIDENCIA:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(" ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("BARRIO RESIDENCIA:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(" ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("NÚMERO TELÉFONO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(" ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("CORREO ELECTRÓNICO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString(" ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawStringRight("ESTADO CIVIL:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 20

            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 10
            e.Graphics.DrawString("Bajo la gravedad del juramento el trabajador manifiesta con su firma que la información arriba relacionada es veraz y real. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 5)
            puntoOrigen.Y = puntoOrigen.Y + 40
            e.Graphics.DrawString("FIRMA DEL TRABAJADOR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 220, puntoOrigen.Y + 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 390, puntoOrigen.Y + 30, puntoOrigen.X + 560, puntoOrigen.Y + 30) 'Horizontal
            e.Graphics.DrawString("C.C.: " & _filaPersona("IDENTIFICACION") & "", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 350, puntoOrigen.Y + 40)
            puntoOrigen.Y = puntoOrigen.Y + 80

            e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y - 75, 90, 120)   '' huella
            e.Graphics.DrawString("Huella", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 612, puntoOrigen.Y + 32)


        Else


            Select Case (Nueva_Pagina)
                Case 1
                    Dim puntoOrigen As New Point(40, 60)
                    e.Graphics.DrawString("CONSECUTIVO No.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 272, puntoOrigen.Y - 15)
                    e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 380, puntoOrigen.Y - 20, 100, 20)
                    e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 975)
                    e.Graphics.DrawString("FORMATO DE AFILIACIÓN-SEGURO EXEQUIAL-COFUNERARIA LOS OLIVOS- NUMERAL 7.3 INSTRUCTIVO  ", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 15)
                    e.Graphics.DrawString("PARA LA APLICACIÓN DE CONDICIONES LABORALES PARA CONTRATISTAS VERSION 4 OCENSA ", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 190, puntoOrigen.Y + 35)
                    Dim puntorec1 As New Point(660, 30)
                    '******************************************************************
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 82) 'Vertical
                    e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 85, 70)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 60, puntoOrigen.X + 765, puntoOrigen.Y + 60) 'Horizontal
                    e.Graphics.DrawString("PÓLIZA DE SEGURO EXEQUIAL No. ", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 310, puntoOrigen.Y + 65)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 82, puntoOrigen.X + 765, puntoOrigen.Y + 82) 'Horizontal completa
                    e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 30, puntoOrigen.Y + 97, 12, 12)
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 97)
                    e.Graphics.DrawString("REGISTRO INICIAL", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 46, puntoOrigen.Y + 97)
                    e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 300, puntoOrigen.Y + 97, 12, 12)
                    e.Graphics.DrawString("MODIFICACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 316, puntoOrigen.Y + 97)
                    e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 600, puntoOrigen.Y + 97, 12, 12)
                    e.Graphics.DrawString("REINTEGRO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 616, puntoOrigen.Y + 97)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 115, puntoOrigen.X + 765, puntoOrigen.Y + 115) 'Horizontal completa
                    e.Graphics.DrawStringCentered("Este formato debe ser diligenciado en su totalidad con puño y letra del trabajador con datos precisos y reales.", Formato_Etiqueta_9, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 125)
                    puntoOrigen.Y = puntoOrigen.Y + 150
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 120) 'Vertical
                    e.Graphics.DrawStringRight("FECHA DE REGISTRO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
                    e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawStringRight("NOMBRE TRABAJADOR:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
                    e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawStringRight("CÉDULA:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
                    e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawStringRight("FECHA DE NACIMIENTO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
                    e.Graphics.DrawString(Format(_filaPersona("FECHANACIMIENTO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawStringRight("ESTADO CIVIL:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
                    e.Graphics.DrawString(_filaPersona("NOMBRETIPOESTADOCIVIL"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawStringRight("CÓDIGO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 5)
                    e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
                    puntoOrigen.Y = puntoOrigen.Y + 10
                    e.Graphics.DrawString("Diligenciar así:", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 1)
                    puntoOrigen.Y = puntoOrigen.Y + 15
                    e.Graphics.DrawString("Módulo 1:  Trabajador casado o con compañera permanente y con hijos, o soltero con hijos.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 15
                    e.Graphics.DrawString("Módulo 2: Trabajador soltero sin hijos.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.RotateTransform(-90)
                    e.Graphics.DrawString("MÓDULO 1", Formato_Etiqueta_9, Brocha, -530, 42)
                    e.Graphics.RotateTransform(90)
                    e.Graphics.DrawStringCentered("INFORMACIÓN BÁSICA - GRUPO FAMILIAR - TRABAJADOR CASADO O CON COMPAÑERA PERMANENTE Y ", Formato_Etiqueta_8, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("CON HIJOS, O SOLTERO CON HIJOS", Formato_Etiqueta_8, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 20)
                    puntoOrigen.Y = puntoOrigen.Y + 40
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    ''Columnas y filas 1
                    e.Graphics.DrawString("PARENTESCO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 15)
                    e.Graphics.DrawString("NOMBRE COMPLETO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 190, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("FECHA DE ", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 385, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("NACIMIENTO ", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 385, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("A/M/D", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 385, puntoOrigen.Y + 25)
                    e.Graphics.DrawString("EDAD", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 495, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("TIPO DE", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 525, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("DOCUMENTO", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 525, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("DE IDENTIDAD", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 525, puntoOrigen.Y + 25)
                    e.Graphics.DrawStringCentered("NÚMERO DE", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 640, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("DOCUMENTO", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 640, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("DE IDENTIDAD", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 640, puntoOrigen.Y + 25)
                    puntoOrigen.Y = puntoOrigen.Y + 40
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("A. MADRE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("B. PADRE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("C. CONYÚGUE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("D. HIJO 1", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("E. HIJO 2", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("F. HIJO 3", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("G. HIJO 4", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("H. HIJO 5", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y - 240, puntoOrigen.X + 21, 630) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y - 200, puntoOrigen.X + 100, 630) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 390, puntoOrigen.Y - 200, puntoOrigen.X + 390, 630) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 490, puntoOrigen.Y - 200, puntoOrigen.X + 490, 630) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y - 200, puntoOrigen.X + 530, 630) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 640, puntoOrigen.Y - 200, puntoOrigen.X + 640, 630) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.RotateTransform(-90)
                    e.Graphics.DrawString("MÓDULO 2", Formato_Etiqueta_9, Brocha, -770, 42)
                    e.Graphics.RotateTransform(90)
                    e.Graphics.DrawStringCentered("INFORMACIÓN BÁSICA - GRUPO FAMILIAR-TRABAJADOR SOLTERO SIN HIJOS", Formato_Etiqueta_8, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("", Formato_Etiqueta_8, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 20)
                    puntoOrigen.Y = puntoOrigen.Y + 40
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y - 40, puntoOrigen.X + 21, puntoOrigen.Y + 200) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y, puntoOrigen.X + 100, puntoOrigen.Y + 200) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 390, puntoOrigen.Y, puntoOrigen.X + 390, puntoOrigen.Y + 200) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 490, puntoOrigen.Y, puntoOrigen.X + 490, puntoOrigen.Y + 200) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y, puntoOrigen.X + 530, puntoOrigen.Y + 200) 'Vertical
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 640, puntoOrigen.Y, puntoOrigen.X + 640, puntoOrigen.Y + 200) 'Vertical
                    ''Columnas y filas 1
                    e.Graphics.DrawString("PARENTESCO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 15)
                    e.Graphics.DrawString("NOMBRE COMPLETO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 190, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("FECHA DE ", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 385, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("NACIMIENTO ", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 385, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("A/M/D", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 385, puntoOrigen.Y + 25)
                    e.Graphics.DrawString("EDAD", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 495, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("TIPO DE", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 525, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("DOCUMENTO", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 525, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("DE IDENTIDAD", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 525, puntoOrigen.Y + 25)
                    e.Graphics.DrawStringCentered("NÚMERO DE", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 640, puntoOrigen.Y + 5)
                    e.Graphics.DrawStringCentered("DOCUMENTO", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 640, puntoOrigen.Y + 15)
                    e.Graphics.DrawStringCentered("DE IDENTIDAD", Formato_Etiqueta_7, Brocha, 110, puntoOrigen.X + 640, puntoOrigen.Y + 25)
                    puntoOrigen.Y = puntoOrigen.Y + 40
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("A. MADRE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("B. PADRE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("C. CONYÚGUE", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("D. HERMANO 1", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("E. HERMANO 2", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("F. HERMANO 3", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("G. HERMANO 4", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawString("H. HERMANO 5", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + 10
                    e.Graphics.DrawString("Bajo la gravedad del juramento el trabajador manifiesta con su firma que la información arriba relacionada es veraz y real. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 5)
                    puntoOrigen.Y = puntoOrigen.Y + 40
                    e.Graphics.DrawString("FIRMA DEL TRABAJADOR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 220, puntoOrigen.Y + 20)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 390, puntoOrigen.Y + 30, puntoOrigen.X + 560, puntoOrigen.Y + 30) 'Horizontal
                    e.Graphics.DrawString("C.C.: " & _filaPersona("IDENTIFICACION") & "", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 350, puntoOrigen.Y + 40)

                Case 2
                    Dim Cadena_Total As New ArrayList
                    Dim puntoOrigen As New Point(50, 60)
                    Const anchoParrafo As Integer = 730
                    Const espacioRenglon As Integer = 16
                    e.Graphics.DrawStringCentered("AUTORIZACIÓN DEL TRATAMIENTO DE DATOS PERSONALES", Formato_Etiqueta_9, Brocha, 780, puntoOrigen.X, puntoOrigen.Y + 15)
                    e.Graphics.DrawImage(logoFuneraria, puntoOrigen.X + 620, puntoOrigen.Y - 20, 125, 54)
                    puntoOrigen.Y = puntoOrigen.Y + 60


                    Cadenas.Add("Autorizo de manera previa, informada y expresa el tratamiento de los datos personales, suministrados a Cofuneraria Los Olivos, aceptando lo reglamentado en la política de tratamiento de datos personales de Cofuneraria Los Olivos identificada con NIT, 800.140.071-5, la cual puede ser consultada en www.bucaramanga.osolivos.co 1) AUTORIZO a Cofuneraria Los Olivos o a los terceros que representen los intereses de la entidad, a que mis datos sean recolectados, almacenados, usados, circulados, suprimidos, intercambiados, para ser utilizados con las siguientes finalidades: a) Tramitar la solicitud de vinculación como afiliado. b) A realizar actividades propias de confirmación y verificación de datos suministrados. c) A recibir información por parte de Cofuneraria Los Olivos respecto a campañas comerciales actuales y futuras, promoción de productos y servicios, y demás comunicaciones necesarias para mantenerme enterado de las mencionadas actividades: mediante: llamada telefónica, mensaje de texto, mensaje por whatsApp, correo electrónico, Facebook, Twiter, Instagram o cualquier red social de integración, entre otros. d) A dar ejecución y cumplimiento de los contratos que se celebren con Cofuneraria Los Olivos. e) Control y prevención del fraude. f) Liquidación y pago de siniestros. g) Elaboración de estudios técnicos, actuariales, estadísticos, encuestas y análisis de tendencia de mercado. h) A dar cumplimiento integral del plan exequial, seguro, servicio funerario o cualquier producto o servicio contratado con Cofuneraria Los Olivos i) Realizar encuestas de satisfacción concerniente a los servicios prestados por Cofuneraria Los Olivos. j) A recibir mensajes relacionados con la gestión de cobro y recuperación de cartera, ya sea directamente o mediante un tercero contratado para tal función. k) Controlar el cumplimiento de requisitos para acceder al Sistema General de Seguridad Social Integral. l) Poder recibir de manera automática e incluir información en registros de nuestro servidor. m) Procesamiento de pagos con tarjeta de crédito, débito o recaudo a través de terceros.")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("2) ACEPTO que Cofuneraria Los Olivos o quien haga sus veces, para que, con fines de calidad, confirmación y suministro de información, gestión de cobranza y/o probatoria, para descargos de funcionarios, determinar el grado de responsabilidad de los funcionarios en un proceso disciplinario interno, realice la grabación de llamadas o conversaciones que por cualquier medio ocurran entre las partes.")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("3) DECLARO que la información consignada en este documento es verídica y asumo plena responsabilidad por la veracidad de los mismos, comprometiéndome a actualizarlos como mínimo una vez al año, anexando los soportes que sean necesarios para ello, todo bajo el principio de buena fe.")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("4) DECLARO que he sido informado de los derechos de consulta, reclamo y rectificación que tengo como titular de mis datos personales conforme a los lineamientos de la política de tratamiento de datos personales de Cofuneraria Los Olivos. De igual manera he sido informado que me pueden solicitar información personal en otros momentos, y que soy libre de proporcionarla o no.")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("5) AUTORIZO a Cofuneraria Los Olivos a tomar mi(s) impresión(es) dactilar(es) y fotografía personal, si es el caso, por cualquier medio físico y/o electrónico, para almacenar esta información en sus bases de datos con el fin de establecer y cotejar mi plena identificación e individualización en el uso de los productos y servicios de Cofuneraria Los Olivos. He sido informado del carácter facultativo de la entrega de esta información que potencialmente puede ser sensible, considerando sin embargo que la misma es necesaria para garantizar la seguridad de los afiliados, clientes y/o usuarios.")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("DECLARACIÓN SOBRE INFORMACIÓN DE TERCEROS REFERENCIADOS: que la información suministrada de terceros beneficiarios podrá ser tratada por Cofuneraria Los Olivos, asimismo que estos fueron informados previamente y han manifestado su consentimiento sobre la posibilidad de que sean contactados con el fin de ampliarlos requerimientos de información, y poder llevar a cabo el trámite de afiliación y cualquier otra finalidad en relación con los productos y/o servicio que ofrece Cofuneraria Los Olivos. ")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("CONOCIMIENTOS DE DERECHOS Y GARANTÍAS. He sido informado sobre los derechos que me asisten como titular de mis datos personales entregados a Cofuneraria Los Olivos por ende autorizo al tratamiento de los mismos conforme a los lineamientos establecidos en la política de privacidad que se puede consultar en sitio web: www.bucaramangalosolivos.co")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("Nota: Este servicio, no está dirigido a niños, niñas y adolescentes por lo que se le solicita, abstenerse de seguir adelante con el registro y/o servicio en caso de que usted sea una persona menor de dieciocho (18) años. Salvo que el menor de edad sea casado o tenga unión marital de hecho, o un núcleo familiar propio.")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    Cadenas.Add("Autorizo a los " + Format(_filaContrato("FECHAINGRESO"), "dd") + " días del mes de " + Format(_filaContrato("FECHAINGRESO"), "MMMM") + " del año " + Format(_filaContrato("FECHAINGRESO"), "yyyy") + ", en la ciudad de " + _filaContrato("CIUDADCONTRATADO") + ".")

                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, anchoParrafo, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, anchoParrafo, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y += espacioRenglon
                    Next
                    Cadenas.Clear()
                    puntoOrigen.Y = puntoOrigen.Y + 13

                    puntoOrigen.Y = puntoOrigen.Y + 30

                    e.Graphics.DrawString("Nombre", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y - 13)
                    e.Graphics.DrawString("Firma", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 370, puntoOrigen.Y - 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 60, puntoOrigen.Y, puntoOrigen.X + 350, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y, puntoOrigen.X + 700, puntoOrigen.Y) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    e.Graphics.DrawString("C.C.", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y - 13)
                    e.Graphics.DrawString("Firma del funcionario ", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 370, puntoOrigen.Y - 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 60, puntoOrigen.Y, puntoOrigen.X + 350, puntoOrigen.Y) 'Horizontal
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 500, puntoOrigen.Y, puntoOrigen.X + 700, puntoOrigen.Y)


            End Select
            Nueva_Pagina += 1
            If Nueva_Pagina = 2 Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
                Nueva_Pagina = 1






            End If


        End If


    End Sub

    Friend Function MinutaOlivos(parrafo As Integer) As String
        Select Case parrafo
            Case 0
                Return ""
            Case 1
                Return " "
            Case 2
                Return ""
            Case 3
                Return ""
            Case 4
                Return ""
            Case 5
                Return ""
            Case 6
                Return ""
            Case 7
                Return ""
            Case 8
                Return ""

            Case Else
                Return Nothing
        End Select
    End Function

#Region " 97 - ICQ-GRAL-F-010 REGISTRO DE INDUCCIÓN  - TGTU"
    Private WithEvents DocImp_ICQGRALF10TGTU As New PrintDocument
    Private Sub DocImpr_ICQGRALF10TGTU(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICQGRALF10TGTU.PrintPage
        Dim puntoOrigen As New Point(20, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 765, 970)
        e.Graphics.DrawString("REGISTRO DE INDUCCIÓN - ENTRENAMIENTO - CAPACITACIÓN ", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 165, puntoOrigen.Y + 35)
        Dim puntorec1 As New Point(660, 30)
        e.Graphics.DrawString("ICQ-GRAL-F-010", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 655, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 660, puntoOrigen.Y + 56)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 82) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 41, puntoOrigen.X + 765, puntoOrigen.Y + 41) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 82, puntoOrigen.X + 765, puntoOrigen.Y + 82) 'Horizontal completa

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 30, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 87)
        e.Graphics.DrawString("INDUCCIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 46, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 140, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ENTRENAMIENTO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 156, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 290, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CAPACITACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 306, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 430, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("CHARLA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 446, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("REUNIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 546, puntoOrigen.Y + 87)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 640, puntoOrigen.Y + 87, 12, 12)
        e.Graphics.DrawString("ACTIVIDAD", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 84)
        e.Graphics.DrawString("LÚDICA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 656, puntoOrigen.Y + 96)

        e.Graphics.DrawString("AREA FRENTE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 125)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 55
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 126)
            Case Else
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 129)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 139, puntoOrigen.X + 531, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 125)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_7, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 126)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 139, puntoOrigen.X + 750, puntoOrigen.Y + 139) 'Horizontal
        e.Graphics.DrawString("LUGAR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 150)
        e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 164, puntoOrigen.X + 531, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("DURACIÓN:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 150)
        e.Graphics.DrawString("4 HORAS", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 633, puntoOrigen.Y + 149)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 164, puntoOrigen.X + 750, puntoOrigen.Y + 164) 'Horizontal
        e.Graphics.DrawString("CAPACITADOR:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 175)
        If _filaContrato("IDBASESISCONTROL") = 125 Then
            e.Graphics.DrawString("", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("COORDINADORHSE"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 135, puntoOrigen.Y + 175)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y + 189, puntoOrigen.X + 531, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 553, puntoOrigen.Y + 175)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 189, puntoOrigen.X + 750, puntoOrigen.Y + 189) 'Horizontal
        e.Graphics.DrawString("TEMAS:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 200)
        e.Graphics.DrawString(" FASE I -  *MISIÓN / VISIÓN  *NUESTRA FILOSOFÍA HSE  * VALORES ISMOCOL  * POLÍTICAS CORPORATIVAS", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 65, puntoOrigen.Y + 204)

        puntoOrigen.Y = puntoOrigen.Y + 215
        Dim Cadenas As New ArrayList
        Cadenas.Add("DE ISMOCOL S.A PRINCIPIOS ÉTICOS  * POLÍTICAS ECP  * CERTIFICACIONES DE LOS SG  * OBJETIVOS Y METAS EN SST  *REGLAS FUNDAMENTALES QUE SALVAN VIDAS ECP  * PTW CERTIFICADOS DE APOYO  * AR  * PROCEDIMIENTOS SEGUROS  * INSPECCIÓN DE HTAS Y EQUIPOS  * QUÉ HACER ANTES DE EJECUTAR UNA ACTIVIDAD  * MANUAL Y CONTROL DE PERMISOS DE TRABAJO ECP  * A&C Y FALLAS DE CONTROL  * INCIDENTES PRIORIZACIÓN DE RIESGOS  * REQUISITOS LEGALES  * REPRESENTANTE DE LOS SISTEMAS DE GESTIÓN SGC SGSST SGA  * COPASST  * PLAN DE EMERGENCIAS * PAEMED  *  PESVE  * REGLAMENTO PARA USO Y MANEJO DE VEHÍCULOS DE LA COMPAÑÍA CIRCULAR  N° 128-2017 PROHIBICIÓN DE USO DE MOTOCICLETAS O SERVICIOS INFORMALES EN ACTIVIDADES LABORALES  * ACCIDENTES DE TRÁNSITO  * ASPECTOS E IMPACTOS AMBIENTALES SIGNIFICATIVOS  * OBLIGACIONES AMBIENTALES OBJETIVOS Y METAS AMBIENTALES  *ASPECTO E IMPACTO AMBIENTAL  * MANEJO DE RESIDUOS  * ETIQUETADO DE PRODUCTOS QUÍMICOS HMIS III  * PROGRAMA DE USO RACIONAL DE AGUA, ENERGÍA Y COMBUSTIBLE  *PQRS  * MANEJO DE ENTORNO * CANALES DE COMUNICACIÓN  * COMITÉ DE CONVIVENCIA LABORAL  * SEGURIDAD FÍSICA * CIRCULAR NORMATIVA N° 151-2021 REV. N° 0 AUTORIDAD PARA DETENER LOS TRABAJOS INSEGUROS.")
        Dim Cadena_Total As New ArrayList
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 740.2627, e)
        Dim i As Integer
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 740.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 10
        Next

        puntoOrigen.Y = puntoOrigen.Y - 295
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 290, puntoOrigen.X + 765, puntoOrigen.Y + 290) 'Horizontal
        e.Graphics.DrawString("Manifiesto que he recibido y entendido en todo su alcance el tema tratado y me comprometo a cumplir con el procedimiento o contenido de los temas y", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 296)
        e.Graphics.DrawString("responsabilidades a mi asignadas. En constancia firmo,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 312)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y + 326, puntoOrigen.X + 765, puntoOrigen.Y + 326) 'Horizontal
        puntoOrigen.Y = puntoOrigen.Y + 332
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 1, 763, 19)
        e.Graphics.DrawString(" 1.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 133, puntoOrigen.Y + 3)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 22, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 378, puntoOrigen.Y + 3)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 25)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 291, puntoOrigen.Y + 35)
        End Select
        e.Graphics.DrawString("No. Cédula", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 512, puntoOrigen.Y + 3)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 493, puntoOrigen.Y + 35)
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 661, puntoOrigen.Y + 3)
        Dim puntorec As New Point(puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 765, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 5
        puntoOrigen.Y = puntoOrigen.Y + 22
        'Completar lineas horizontales
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 745, puntoOrigen.Y) 'Horizontal completa
        Dim conlineas As Integer
        For conlineas = 0 To 24
            If puntoOrigen.Y < 1000 Then
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 764, puntoOrigen.Y) 'Horizontal completa
                puntoOrigen.Y = puntoOrigen.Y + 27
            Else
                Exit For
            End If
        Next
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 21, puntorec.Y, puntoOrigen.X + 21, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 291, puntorec.Y, puntoOrigen.X + 291, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 492, puntorec.Y, puntoOrigen.X + 492, 1010) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 601, puntorec.Y, puntoOrigen.X + 601, 1010) 'Vertical
    End Sub
#End Region


#Region " 82 - CONSTANCIA Y EVALUACIÓN DE LA EFICACIA DE LA INDUCCIÓN - TGTU"
    Private WithEvents DocImp_ICHTGTUF010 As New PrintDocument

    Private Sub DocImpr_ICHTGTUF010(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHTGTUF010.PrintPage
        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM ListaDocumentos(@ACCION, @IDDOCUMENTO, @REVISION) ORDER BY [IDDOCUMENTO]", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1) 'Listar por IdDocumentoImprimir y Revisión
            comando.Parameters.AddWithValue("@IDDOCUMENTO", 108) 'ICA-MOCE-F-077
            comando.Parameters.AddWithValue("@REVISION", 1) 'Rev. 1
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtDocumentos As New DataTable
            Try
                adaptador.Fill(dtDocumentos)
                If dtDocumentos.Rows.Count > 0 Then
                    listaImagenesBD = New List(Of Image)
                    For k = 0 To dtDocumentos.Rows.Count - 1
                        Dim filadoc As DataRow = dtDocumentos.Rows(k)

                        Dim byteBLOBData(-1) As [Byte]
                        byteBLOBData = CType(filadoc("BLOB"), [Byte]())
                        Dim stmBLOBData As New IO.MemoryStream(byteBLOBData)
                        listaImagenesBD.Add(Image.FromStream(stmBLOBData))
                    Next
                    datosCargados = True
                Else
                    Throw New Exception("No se encontraron datos de impresión.")
                End If
            Catch ex As Exception
                Throw New Exception("No se encontraron datos de impresión.", ex)
            Finally
                conexion.Close()
            End Try
        End If
        e.Graphics.DrawImage(listaImagenesBD.Item(contadorPaginasImpresas), -30, -40, 850, 1100) 'e.PageBounds.Left - 30, e.PageBounds.Top - 40, e.PageBounds.Right, e.PageBounds.Bottom)
        Select Case (contadorPaginasImpresas + 1)
            Case 1 'Página 1
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, 160, 152)
                e.Graphics.DrawString(Trim(_filaContrato("NOMBRETIPOCARGO")) + " - " + _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, 210, 179)
                e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, 130, 201)
                e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_8R, Brocha, 460, 201)
            Case 2 'Página 2

            Case 3 'Página 3

            Case 4 'Página 4

            Case 5 'Página 5

            Case 6 'Página 6

        End Select
        contadorPaginasImpresas += 1
        If contadorPaginasImpresas <= listaImagenesBD.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            contadorPaginasImpresas = 0
        End If

    End Sub
#End Region

End Class

