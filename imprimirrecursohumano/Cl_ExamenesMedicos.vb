Imports System.Drawing.Printing
Imports System.Drawing
Imports FunBase = FuncionesBase.FuncionesBase
Imports System.Text
Imports System.Data.SqlClient

Partial Class Cl_Impresión

#Region " 3 - ICA GRAL-F-091 ORDEN PARA CONSULTA MÉDICA Y AUTORIZACIÓN EXÁMENES PREOCUPACIONALES"
    Private WithEvents DocImp_ICAGRALF91 As New PrintDocument
    'Private filaCentroClinicoImprimir As DataRow
    'Private impresionResonancia As Boolean = False
    'Property dtExamenesPreocupacionales As DataTable
    'Property FilaCentroClinico As DataRow
    'Property FilaCentroClinicoResonancia As DataRow
    'Property FechaEnvio As Date = Date.Today
    'Property CodigoMotivoConsultaExamenes As Integer = 0
    'Property NombreCargoPropuesto As String = ""
    'Property OtrosExamenesEE As String = ""
    'Property ObservacionesEE As String = ""


    Private Sub DocImpr_ICAGRALF91(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF91.PrintPage
        'If impresionResonancia Then
        '    filaCentroClinicoImprimir = FilaCentroClinicoResonancia
        'Else
        '    filaCentroClinicoImprimir = FilaCentroClinico
        'End If
        filaCentroClinicoImprimir = FilaCentroClinico
        Dim puntoOrigen As New Point(55, 55)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 710, 975)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 20, puntoOrigen.Y + 7, 90, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y, puntoOrigen.X + 125, 140) 'Vertical
        e.Graphics.DrawString("ORDEN PARA CONSULTA MÉDICA Y", Formato_Etiqueta_10, Brocha, 285, 80)
        e.Graphics.DrawString("AUTORIZACIÓN DE EXÁMENES PREOCUPACIONALES", Formato_Etiqueta_10, Brocha, 225, 100)
        e.Graphics.DrawLine(Lapiz, 640, puntoOrigen.Y, 640, 140) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-091", Formato_Etiqueta_7, Brocha, 664, 70)
        e.Graphics.DrawLine(Lapiz, 640, 97, 765, 97) 'Horizontal
        e.Graphics.DrawString("Revisión No. 5", Formato_Etiqueta_7, Brocha, 670, 115)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 140, puntoOrigen.X + 710, 140) 'Horizontal completa
        puntoOrigen.X = 55
        puntoOrigen.Y = 155
        e.Graphics.DrawString("CIUDAD Y FECHA:", Formato_Etiqueta_8, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 180, 169, 590, 169) 'Horizontal
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & FechaEnvio.ToLongDateString, Formato_Etiqueta_10R, Brocha, 180, puntoOrigen.Y - 1)
        puntoOrigen.X = 55
        puntoOrigen.Y = 200
        e.Graphics.DrawString("Señores:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 120, 214, 590, 214) 'Horizontal
        e.Graphics.DrawString(filaCentroClinicoImprimir("NOMBRECENTROCLINICO"), Formato_Etiqueta_10R, Brocha, 120, puntoOrigen.Y - 1)
        puntoOrigen.X = 55
        puntoOrigen.Y = 225
        e.Graphics.DrawString("Dirección:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 120, 239, 590, 239) 'Horizontal
        Dim Ciudadfecha As String = filaCentroClinicoImprimir("DIRECCION") & ", " & filaCentroClinicoImprimir("CIUDAD")
        If e.Graphics.MeasureString(Ciudadfecha, Formato_Etiqueta_10R).Width <= 470 Then
            e.Graphics.DrawString(Ciudadfecha, Formato_Etiqueta_10R, Brocha, 120, puntoOrigen.Y - 1)
        Else
            e.Graphics.DrawString(Ciudadfecha, Formato_Etiqueta_9R, Brocha, 120, puntoOrigen.Y)
        End If
        puntoOrigen.X = 55
        puntoOrigen.Y = 250
        e.Graphics.DrawString("Teléfono:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 120, 264, 590, 264) 'Horizontal
        e.Graphics.DrawString(filaCentroClinicoImprimir("TELEFONO"), Formato_Etiqueta_10R, Brocha, 120, puntoOrigen.Y - 1)
        puntoOrigen.X = 640
        puntoOrigen.Y = 140
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X, puntoOrigen.Y + 125) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 125, puntoOrigen.X + 125, puntoOrigen.Y + 125) 'Horizontal
        Dim foto As Image = FunBase.DevolverImagenMiniatura(1, Idpersona)
        If Not IsNothing(foto) Then
            e.Graphics.DrawImage(foto, puntoOrigen.X + 1, puntoOrigen.Y + 1, 123, 123)
        Else
            e.Graphics.DrawString("Espacio para la foto", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 10, puntoOrigen.Y + 60)
        End If
        puntoOrigen.X = 55
        puntoOrigen.Y = 280
        e.Graphics.DrawString("Solicitamos atender al señor:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 230, 294, 765, 294) 'Horizontal
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, 230, puntoOrigen.Y - 1)
        puntoOrigen.X = 55
        puntoOrigen.Y = 300
        e.Graphics.DrawString("identificado con cédula de ciudadanía No.", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 330, 314, 550, 314) 'Horizontal
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, 330, puntoOrigen.Y - 1)
        puntoOrigen.X = 560
        puntoOrigen.Y = 300
        e.Graphics.DrawString("de", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 590, 314, 765, 314) 'Horizontal
        e.Graphics.DrawString(_filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_10R, Brocha, 590, puntoOrigen.Y - 1)
        puntoOrigen.X = 55
        puntoOrigen.Y = 320
        e.Graphics.DrawString("quien desempeñará o desempeña el cargo de:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 330, 334, 765, 334) 'Horizontal
        If NombreCargoPropuesto.Length < 50 Then
            e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_10R, Brocha, 330, puntoOrigen.Y - 1)
        Else
            If NombreCargoPropuesto.Length < 80 Then
                e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_9R, Brocha, 330, puntoOrigen.Y - 1)
            Else
                e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_8R, Brocha, 330, puntoOrigen.Y - 1)
            End If
        End If
        puntoOrigen.X = 55
        puntoOrigen.Y = 340
        e.Graphics.DrawString("de acuerdo al motivo de la consulta que se señala en seguida:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        puntoOrigen.X = 200
        puntoOrigen.Y = 370
        e.Graphics.DrawString("1     VALORACIÓN PARED Y CAVIDAD ABDOMINAL", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("2     INGRESO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 18)
        e.Graphics.DrawString("3     PERIÓDICO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 36)
        e.Graphics.DrawString("4     RETIRO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 54)
        e.Graphics.DrawString("5     REUBICACIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 72)
        e.Graphics.DrawString("6     POST-INCAPACIDAD", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 90)
        e.Graphics.DrawLine(Lapiz, 545, 364, 545, 472) 'vertical
        e.Graphics.DrawLine(Lapiz, 590, 364, 590, 472) 'vertical
        e.Graphics.DrawLine(Lapiz, 545, 364, 590, 364) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 382, 590, 382) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 400, 590, 400) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 418, 590, 418) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 436, 590, 436) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 454, 590, 454) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 472, 590, 472) 'Horizontal
        puntoOrigen.X = 55
        puntoOrigen.Y = 495
        e.Graphics.DrawString("Igualmente, practicar los exámenes relacionados a continuación:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        puntoOrigen.X = 200
        puntoOrigen.Y = 520
        e.Graphics.DrawString("1     RMN COLUMNA LUMBO-SACRA SIMPLE", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("2     CUADRO HEMÁTICO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 18)
        e.Graphics.DrawString("3     GLICEMIA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 36)
        e.Graphics.DrawString("4     PARCIAL ORINA (INCLUYE GLUCOSURIA)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 54)
        e.Graphics.DrawString("5     BK BACILOSCOPIA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 72)
        e.Graphics.DrawString("6     SEROLOGÍA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 90)
        e.Graphics.DrawString("7     HEMOCLASIFICACIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 108)
        e.Graphics.DrawString("8     PERFIL LIPÍDICO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 126)
        e.Graphics.DrawString("9     AUDIOMETRÍA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 144)
        e.Graphics.DrawString("10    VISIOMETRÍA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 162)
        e.Graphics.DrawString("11    ESPIROMETRÍA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 180)
        e.Graphics.DrawString("12    NEUROPSICO SENSORIAL", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 198)
        e.Graphics.DrawString("13    E.K.G. ELECTROCARDIOGRAMA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 216)
        e.Graphics.DrawString("14    RX TÓRAX", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 234)
        e.Graphics.DrawLine(Lapiz, 545, 514, 545, 766) 'vertical
        e.Graphics.DrawLine(Lapiz, 590, 514, 590, 766) 'vertical
        e.Graphics.DrawLine(Lapiz, 545, 514, 590, 514) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 532, 590, 532) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 550, 590, 550) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 568, 590, 568) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 586, 590, 586) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 604, 590, 604) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 622, 590, 622) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 640, 590, 640) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 658, 590, 658) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 676, 590, 676) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 694, 590, 694) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 712, 590, 712) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 730, 590, 730) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 748, 590, 748) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 766, 590, 766) 'Horizontal
        'If Not impresionResonancia Then
        Select Case CodigoMotivoConsultaExamenes
            Case 0 '(Resonancia de columna)

            Case 1 'VALORACIÓN PARED Y CAVIDAD ABDOMINAL
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 366)
            Case 2 'Ingreso
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 384)
            Case 3 'Periódico
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 402)
            Case 4 'Retiro
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 420)
            Case 5 'Reubicación
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 438)
            Case 6 'Posincapacidad
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 456)
            Case Else
        End Select
        'End If
        Dim otrosExamenes As New StringBuilder
        Dim observaciones As New StringBuilder
        otrosExamenes.Append(OtrosExamenesEE)
        observaciones.Append("OBSERVACIONES:  ")
        observaciones.Append(ObservacionesEE)
        observaciones.Append(Centrocostoexamen)
        If CodigoMotivoConsultaExamenes = 0 OrElse CodigoMotivoConsultaExamenes = 1 Then
            For Each fila As DataRow In dtExamenesPreocupacionales.Rows
                Select Case fila("CODIGOEXAMENPREOCUPACIONAL") 'Códigos según la tabla [MA_EXAMENPREOCUPACIONAL].
                    Case 1 'Valoración clínica inicial
                        'Equivalente a motivo 1: Valoración de pared y cavidad abdominal.
                    Case 2 'Resonancia nuclear magnética de columna lumbo-sacra simple
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 516) '1  RMN COLUMNA LUMBO-SACRA SIMPLE
                    Case 3 'Vacunas tétano y fiebre amarilla
                        observaciones.Append(" solicitar certificados de vacunas antitetánica y antiamarílica,")
                    Case 4 'Hepatitis B
                        observaciones.Append(" solicitar certificado de vacuna de hepatitis B,")
                        'otrosExamenes.Append(" realizar examen de hepatitis B,") 'Para los cargos: médico.
                    Case 5 'Audiometría
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 660) '9 AUDIOMETRÍA
                    Case 6 'Visiometría
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 678) '10 VISIOMETRÍA
                    Case 7 'Espirometría
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 696) '11 ESPIROMETRÍA
                    Case 8 'EKG Electrocardiograma
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 732) '13 E.K.G. ELECTROCARDIOGRAMA
                    Case 9 'Neuropsico sensorial
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 714) '12 NEUROPSICO SENSORIAL
                    Case 10 'BK Baciloscopia
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 588) '5 BK BACILOSCOPIA
                    Case 11 'Cuadro hemático
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 534) '2 CUADRO HEMÁTICO
                    Case 12 'Parcial orina
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 570) '4  PARCIAL ORINA
                    Case 13 'Perfil lipídico (sobrepeso u obesos)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 642) '8  PERFIL LIPÍDICO
                    Case 14 'RX Tórax
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 750) '14 RX TÓRAX
                    Case 15 'Glicemia
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 552) '3  GLICEMIA
                    Case 16 'PVE Control periódico
                        'Equivalente al motivo 3: Examen periódico.
                    Case 17 'Serología (no se encuentra en la matriz de exámenes)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 606) '6 SEROLOGÍA
                    Case 18 ' Hemoclasificación (no se encuentra en la matriz de exámenes)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 45, 545, 624) '7 HEMOCLASIFICACIÓN
                    Case 19 'Tomografía Axial Computarizada - TAC de columna lumbosacra (no se encuentra en la matriz de exámenes)
                        otrosExamenes.Append(" Tomografía Axial Computarizada - TAC de columna lumbosacra,") 'Para los cargos: médico.
                    Case 20 'Rayos X dinámicos de la columna lumbosacra (no se encuentra en la matriz de exámenes)
                        otrosExamenes.Append(" Rayos X dinámicos de la columna lumbosacra,") 'Para los cargos: médico.
                    Case Else
                End Select
            Next
        End If
        If otrosExamenes.Length > 0 Then
            Dim oe As String = otrosExamenes.ToString
            If oe.EndsWith(",") Then
                oe.Remove(oe.Length - 1) 'Retirar última coma
            End If
            e.Graphics.DrawString(oe, Formato_Etiqueta_8R, Brocha, 200, 785)
        End If
        If observaciones.Length > 0 Then
            Dim obs As String = observaciones.ToString
            If obs.EndsWith(",") Then
                obs.Remove(obs.Length - 1) 'Retirar última coma
            End If
            Dim Cadenas As New ArrayList
            Cadenas.Add(obs)
            Dim Cadena_Total As New ArrayList
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_9R, 708, e)
            Dim texto As New StringBuilder
            Dim PosY As Single = 803
            For i As Integer = 0 To Cadena_Total.Count - 1
                texto.Append(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_9R, 708, e))
                e.Graphics.DrawString(texto.ToString, Formato_Etiqueta_9R, Brocha, 56, PosY)
                PosY += 18
                texto.Clear()
            Next
        End If
        'End If
        puntoOrigen.X = 65
        puntoOrigen.Y = 785
        e.Graphics.DrawString("15  Otros *", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 200, 798, 636, 798) 'Horizontal
        puntoOrigen.X = 55
        puntoOrigen.Y = 805
        'e.Graphics.DrawString("OBSERVACIONES:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, 200, 816, 765, 816) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 56, 834, 765, 834) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 56, 852, 765, 852) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 56, 870, 765, 870) 'Horizontal
        puntoOrigen.X = 55
        puntoOrigen.Y = 875
        e.Graphics.DrawString("* A criterio médico ", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawString("Los costos ocasionados por este servicio serán facturados de acuerdo a las tarifas pactadas a nombre de", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 15)
        e.Graphics.DrawString("ISMOCOL S.A. NIT. 890.209.174-1", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, 110, 930, 110, 1015) 'vertical
        e.Graphics.DrawLine(Lapiz, 335, 930, 335, 1015) 'vertical
        e.Graphics.DrawLine(Lapiz, 110, 930, 335, 930) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 110, 985, 335, 985) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 55, 1000, 335, 1000) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 55, 1015, 335, 1015) 'Horizontal
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_8, Brocha, 112, 930)
        e.Graphics.DrawString("ADMINISTRADOR", Formato_Etiqueta_10, Brocha, 160, 985)
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_7R, Brocha, 60, 1003)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_7R, Brocha, 225, 110, 1003)
        e.Graphics.DrawLine(Lapiz, 440, 1000, 440, 1015) 'vertical
        e.Graphics.DrawLine(Lapiz, 545, 930, 545, 1015) 'vertical
        e.Graphics.DrawLine(Lapiz, 545, 930, 765, 930) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 545, 985, 765, 985) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 440, 1000, 765, 1000) 'Horizontal
        e.Graphics.DrawLine(Lapiz, 440, 1015, 765, 1015) 'Horizontal
        e.Graphics.DrawString("Recibí,", Formato_Etiqueta_8, Brocha, 546, 930)
        e.Graphics.DrawString("PACIENTE", Formato_Etiqueta_10, Brocha, 610, 985)
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_7R, Brocha, 480, 1003)
        e.Graphics.DrawStringCentered(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7R, Brocha, 220, 545, 1003)
        'If Not impresionResonancia AndAlso Not IsNothing(FilaCentroClinicoResonancia) Then
        '    impresionResonancia = True
        '    e.HasMorePages = True
        'Else
        '    e.HasMorePages = False
        _impresionFinalizada = True
        '    impresionResonancia = False
        'End If
    End Sub
#End Region

#Region " 57 - ORDEN PARA CONSULTA MÉDICA DE RETIRO"
    Private WithEvents DocImp_OrdenConsultaMedicaRetiro As New PrintDocument

    Private Sub DocImpr_OrdenConsultaMedicaRetiro(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_OrdenConsultaMedicaRetiro.PrintPage
        e.Graphics.DrawString("ORDEN PARA CONSULTA MÉDICA DE RETIRO", Formato_Etiqueta_8R, Brocha, 10, 10)
    End Sub
#End Region

#Region " 73 - ICA GRAL-F-163 APLICACION PREVENTIVA PARA EVITAR CONTAGIO CON COVID - 19"
    Private WithEvents DocImp_ICAGRALF163 As New PrintDocument


    Private Sub DocImpr_ICAGRALF163(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF163.PrintPage
        Dim fechaEncuesta As Date
        fechaEncuesta = _filaEncuesta("FECHAENCUESTA")

        Dim puntoOrigen As New Point(39, 50)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 741, 830)
        e.Graphics.DrawString("APLICACIÓN PREVENTIVA PARA EVITAR CONTAGIO CON COVID - 19", Formato_Etiqueta_10, Brocha, 173, 90)
        e.Graphics.DrawString("ICA-GRAL-F-163", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 629, 65)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 634, 115)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 124, puntoOrigen.Y, puntoOrigen.X + 124, puntoOrigen.Y + 98) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 614, puntoOrigen.Y, puntoOrigen.X + 614, puntoOrigen.Y + 98) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 10, puntoOrigen.Y + 5, 110, 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 614, 100, puntoOrigen.X + 741, 100) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 98, puntoOrigen.X + 741, puntoOrigen.Y + 98) 'Horizontal completa
        Dim puntoOrigen1 As New Point(39, 148)
        e.Graphics.DrawString("Nombre Trabajador", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 10)
        e.Graphics.DrawString(_filaEncuesta("NOMBRE"), Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 120, puntoOrigen1.Y + 12)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 115, puntoOrigen1.Y + 24, puntoOrigen.X + 390, puntoOrigen1.Y + 24) 'Horizontal
        e.Graphics.DrawString("Cédula", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 400, puntoOrigen1.Y + 10)
        e.Graphics.DrawString(_filaEncuesta("IDENTIFICACION"), Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 450, puntoOrigen1.Y + 12)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 445, puntoOrigen1.Y + 24, puntoOrigen.X + 731, puntoOrigen1.Y + 24) 'Horizontal
        e.Graphics.DrawString("Proyecto", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 30)
        e.Graphics.DrawString(_filaEncuesta("PROYECTO"), Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 65, puntoOrigen1.Y + 32)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 44, puntoOrigen.X + 390, puntoOrigen1.Y + 44) 'Horizontal
        e.Graphics.DrawString("Base", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 400, puntoOrigen1.Y + 30)
        e.Graphics.DrawString(_filaEncuesta("BASE"), Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 450, puntoOrigen1.Y + 32)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 445, puntoOrigen1.Y + 44, puntoOrigen.X + 731, puntoOrigen1.Y + 44) 'Horizontal
        e.Graphics.DrawString("Fecha", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 55)
        e.Graphics.DrawStringCentered(fechaEncuesta.Day, Formato_Etiqueta_7, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 55)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 90, puntoOrigen1.Y + 50, puntoOrigen1.X + 90, puntoOrigen1.Y + 70) 'Vertical
        e.Graphics.DrawStringCentered(fechaEncuesta.Month, Formato_Etiqueta_7, Brocha, 30, puntoOrigen1.X + 90, puntoOrigen1.Y + 55)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 120, puntoOrigen1.Y + 50, puntoOrigen1.X + 120, puntoOrigen1.Y + 70) 'Vertical
        e.Graphics.DrawStringCentered(fechaEncuesta.Year, Formato_Etiqueta_7, Brocha, 40, puntoOrigen1.X + 120, puntoOrigen1.Y + 55)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 50, 100, 20)
        e.Graphics.DrawString("Edad", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 400, puntoOrigen1.Y + 55)
        e.Graphics.DrawStringCentered(_filaEncuesta("EDAD"), Formato_Etiqueta_7, Brocha, 30, puntoOrigen1.X + 445, puntoOrigen1.Y + 55)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 445, puntoOrigen1.Y + 50, 30, 20)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 480, puntoOrigen1.Y + 55)
        Dim cargo As String = _filaEncuesta("CARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 525, puntoOrigen1.Y + 57)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6, Brocha, puntoOrigen1.X + 525, puntoOrigen1.Y + 57)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6, Brocha, puntoOrigen1.X + 525, puntoOrigen1.Y + 47)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6, Brocha, puntoOrigen1.X + 525, puntoOrigen1.Y + 57)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 520, puntoOrigen1.Y + 69, puntoOrigen.X + 731, puntoOrigen1.Y + 69) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 75, puntoOrigen.X + 741, puntoOrigen1.Y + 75) 'Horizontal
        'e.Graphics.DrawString("La encuesta es adelantada por personal de salud de ISMOCOL S.A y la movilidad es aprobada únicamente por la Coordinación Médica  y comunicada ", Formato_Etiqueta_7IR, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 80)
        'e.Graphics.DrawString("a la Alta Gerencia.", Formato_Etiqueta_7IR, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 92)
        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 105, puntoOrigen.X + 741, puntoOrigen1.Y + 105) 'Horizontal
        Dim version As Integer = _filaEncuesta("V")
        If _filaEncuesta("V") = 2 Then


            e.Graphics.DrawString("SINTOMAS:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 10, puntoOrigen1.Y + 90)
            e.Graphics.DrawString("1. ¿Tiene tos continua improductiva o que la gente conoce como tos seca?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 115)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 134)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 134, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 134)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 134, 30, 15)
            If _filaEncuesta("R1") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 135)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 135)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 155, puntoOrigen.X + 741, puntoOrigen1.Y + 155) 'Horizontal
            e.Graphics.DrawString("2.  Tiene dificultad respiratoria (le cuesta trabajo respirar y al hacerlo le duelen las costillas), dolor en el pecho o fatiga?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 165)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 184)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 184, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 184)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 184, 30, 15)
            If _filaEncuesta("R2") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 185)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 185)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 205, puntoOrigen.X + 741, puntoOrigen1.Y + 205) 'Horizontal
            e.Graphics.DrawString("3. ¿Tiene fiebre comprobada con termómetro igual o superior a 38 °C o escalofríos?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 215)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 234)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 234, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 234)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 234, 30, 15)
            If _filaEncuesta("R3") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 235)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 235)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 255, puntoOrigen.X + 741, puntoOrigen1.Y + 255) 'Horizontal
            e.Graphics.DrawString("4. ¿Presenta secreción nasal, estornudos o dolor de garganta?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 265)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 284)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 284, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 284)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 284, 30, 15)
            If _filaEncuesta("R4") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 285)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 285)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 305, puntoOrigen.X + 741, puntoOrigen1.Y + 305) 'Horizontal
            e.Graphics.DrawString("5. ¿Siente dolor de cabeza, pérdida de fuerza, dolores musculares o articulares moderados?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 315)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 334)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 334, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 334)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 334, 30, 15)
            If _filaEncuesta("R5") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 335)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 335)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 355, puntoOrigen.X + 741, puntoOrigen1.Y + 355) 'Horizontal
            e.Graphics.DrawString("6. ¿Nota tener pérdida de olfato, la boca tiene un sabor raro o no les encuentra gusto a las comidas? ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 365)
            e.Graphics.DrawString("", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 379)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 393)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 393, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 393)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 393, 30, 15)
            If _filaEncuesta("R6") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 394)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 394)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 415, puntoOrigen.X + 741, puntoOrigen1.Y + 415) 'Horizontal
            e.Graphics.DrawString("7. ¿Presenta vómito o deposiciones líquidas por más de cinco veces al día?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 425)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 444)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 444, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 444)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 444, 30, 15)
            If _filaEncuesta("R7") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 445)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 445)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 465, puntoOrigen.X + 741, puntoOrigen1.Y + 465) 'Horizontal


            e.Graphics.DrawString("CONTACTOS:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 10, puntoOrigen1.Y + 480)
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 500, puntoOrigen.X + 741, puntoOrigen1.Y + 500)
            puntoOrigen1.Y = puntoOrigen1.Y + 30

            e.Graphics.DrawString("8. ¿Ha tenido contacto estrecho (por más de 15 minutos y a menos de 2 metros de distancia) con una persona confirmada con COVID-19 en las últimas dos semanas?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 475)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 494)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 494, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 494)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 494, 30, 15)
            If _filaEncuesta("R8") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 495)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 495)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 515, puntoOrigen.X + 741, puntoOrigen1.Y + 515) 'Horizontal

            e.Graphics.DrawString("COMORBILIDADES O TRATAMIENTOS:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 10, puntoOrigen1.Y + 530)
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 550, puntoOrigen.X + 741, puntoOrigen1.Y + 550)
            puntoOrigen1.Y = puntoOrigen1.Y + 20
            puntoOrigen1.Y = puntoOrigen1.Y + 20

            e.Graphics.DrawString("9. ¿Sufre de diabetes, obesidad, hipertensión, enfermedades cardiovasculares?", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 525)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 544)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 544, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 544)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 544, 30, 15)
            If _filaEncuesta("R9") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 545)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 545)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 565, puntoOrigen.X + 741, puntoOrigen1.Y + 565) 'Horizontal

            puntoOrigen1.Y = puntoOrigen1.Y - 60
            'e.Graphics.DrawString("10. ¿En los últimos dos años a recibido tratamiento para cáncer, lupus, enfermedades autoinmunes?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 575)
            'e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 594)
            'e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 594, 30, 15)
            'e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 594)
            'e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 594, 30, 15)
            'If _filaEncuesta("R10") = "S" Then
            '    e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 595)
            'Else
            '    e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 595)
            'End If
            'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 615, puntoOrigen.X + 741, puntoOrigen1.Y + 615) 'Horizontal
            'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 630, puntoOrigen.X + 741, puntoOrigen1.Y + 630) 'Horizontal
            e.Graphics.DrawString("Diligenciado", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 700)
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 70, puntoOrigen1.Y + 714, puntoOrigen.X + 340, puntoOrigen1.Y + 714) 'Horizontal
            e.Graphics.DrawString("Reviso Medicina Laboral", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 350, puntoOrigen1.Y + 700)
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 480, puntoOrigen1.Y + 714, puntoOrigen.X + 731, puntoOrigen1.Y + 714) 'Horizontal

        Else
            e.Graphics.DrawString("1. ¿Tiene fiebre comprobada con termómetro superior a 38°c?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 115)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 134)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 134, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 134)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 134, 30, 15)
            If _filaEncuesta("R1") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 135)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 135)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 155, puntoOrigen.X + 741, puntoOrigen1.Y + 155) 'Horizontal
            e.Graphics.DrawString("2.  ¿Tiene tos continúa improductiva (que no desgarra) o que la que la gente conoce como tos seca?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 165)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 184)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 184, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 184)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 184, 30, 15)
            If _filaEncuesta("R2") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 185)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 185)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 205, puntoOrigen.X + 741, puntoOrigen1.Y + 205) 'Horizontal
            e.Graphics.DrawString("3.  ¿Tiene dificultad respiratoria (le cuesta trabajo respirar y al respirar le duelen las costillas)?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 215)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 234)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 234, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 234)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 234, 30, 15)
            If _filaEncuesta("R3") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 235)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 235)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 255, puntoOrigen.X + 741, puntoOrigen1.Y + 255) 'Horizontal
            e.Graphics.DrawString("4.  ¿Siente pérdida de la fuerza y/o dolores musculares?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 265)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 284)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 284, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 284)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 284, 30, 15)
            If _filaEncuesta("R4") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 285)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 285)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 305, puntoOrigen.X + 741, puntoOrigen1.Y + 305) 'Horizontal
            e.Graphics.DrawString("5.  ¿Ha notado tener pérdida del olfato, la boca tiene un sabor raro o no le encuentra gusto a las comidas?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 315)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 334)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 334, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 334)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 334, 30, 15)
            If _filaEncuesta("R5") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 335)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 335)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 355, puntoOrigen.X + 741, puntoOrigen1.Y + 355) 'Horizontal
            e.Graphics.DrawString("6. ¿En los últimos 30 días usted ha tenido contacto físico (tocado, abrazado, besado, acariciado)  con familiar o amigo que haya regresado de un ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 365)
            e.Graphics.DrawString("viaje del exterior?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 379)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 393)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 393, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 393)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 393, 30, 15)
            If _filaEncuesta("R6") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 394)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 394)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 415, puntoOrigen.X + 741, puntoOrigen1.Y + 415) 'Horizontal
            e.Graphics.DrawString("7. ¿Sabe de haber tenido contacto directo o indirecto a través de un tercero, con una persona diagnósticada y confirmada con coronavirus??", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 425)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 444)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 444, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 444)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 444, 30, 15)
            If _filaEncuesta("R7") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 445)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 445)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 465, puntoOrigen.X + 741, puntoOrigen1.Y + 465) 'Horizontal
            e.Graphics.DrawString("8. ¿Sufre de Asma o Enfermedades respiratorias crónicas?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 475)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 494)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 494, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 494)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 494, 30, 15)
            If _filaEncuesta("R8") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 495)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 495)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 515, puntoOrigen.X + 741, puntoOrigen1.Y + 515) 'Horizontal
            e.Graphics.DrawString("9. ¿Sufre de diabetes, obesidad, hipertensión, enfermedades cardiovasculares?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 525)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 544)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 544, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 544)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 544, 30, 15)
            If _filaEncuesta("R9") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 545)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 545)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 565, puntoOrigen.X + 741, puntoOrigen1.Y + 565) 'Horizontal
            e.Graphics.DrawString("10. ¿En los últimos dos años a recibido tratamiento para cáncer, lupus, enfermedades autoinmunes?", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 575)
            e.Graphics.DrawString("SI", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 25, puntoOrigen1.Y + 594)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 60, puntoOrigen1.Y + 594, 30, 15)
            e.Graphics.DrawString("NO", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 300, puntoOrigen1.Y + 594)
            e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 335, puntoOrigen1.Y + 594, 30, 15)
            If _filaEncuesta("R10") = "S" Then
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 60, puntoOrigen1.Y + 595)
            Else
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_9, Brocha, 30, puntoOrigen1.X + 335, puntoOrigen1.Y + 595)
            End If
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 615, puntoOrigen.X + 741, puntoOrigen1.Y + 615) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 630, puntoOrigen.X + 741, puntoOrigen1.Y + 630) 'Horizontal
            e.Graphics.DrawString("Diligenciado", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 700)
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 70, puntoOrigen1.Y + 714, puntoOrigen.X + 340, puntoOrigen1.Y + 714) 'Horizontal
            e.Graphics.DrawString("Reviso Medicina Laboral", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 350, puntoOrigen1.Y + 700)
            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 480, puntoOrigen1.Y + 714, puntoOrigen.X + 731, puntoOrigen1.Y + 714) 'Horizontal


        End If





    End Sub
#End Region


#Region " 85 - ICA GRAL-F-091 ORDEN PARA VALORACIONES MÉDICAS, EXÁMENES DE LABORATORIO, PARACLÍNICOS Y EXÁMENES DE CONDUCTORES"
    Private WithEvents DocImp_ICAGRALF091 As New PrintDocument
    Private filaCentroClinicoImprimir As DataRow
    Private impresionResonancia As Boolean = False
    Property dtExamenesPreocupacionales As DataTable
    Property FilaCentroClinico As DataRow
    Property FilaCentroClinicoResonancia As DataRow
    Property FechaEnvio As Date = Date.Today
    Property CodigoMotivoConsultaExamenes As Integer = 0
    Property NombreCargoPropuesto As String = ""

    Property IdExamen As Integer = 0

    Property OtrosExamenesEE As String = ""
    Property ObservacionesEE As String = ""

    Property TareasCriticas As String

    Private BloquearEdiciónExamen As Boolean = False
    Property Centrocostoexamen As String = ""

    Private Sub DocImpr_ICAGRALF091(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF091.PrintPage
        'If impresionResonancia Then
        '    filaCentroClinicoImprimir = FilaCentroClinicoResonancia
        'Else
        '    filaCentroClinicoImprimir = FilaCentroClinico
        'End If
        Dim FechaVigencia As Date
        Dim conexion1 As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando1 As New SqlCommand("Select dbo.DiasHabiles(@FechaI,@Dias) as FECHA", conexion1)
        comando1.Parameters.AddWithValue("@FechaI", FechaEnvio)
        comando1.Parameters.AddWithValue("@Dias", 5)
        Dim adaptador1 As New SqlDataAdapter(comando1)
        Dim dtFecha As New DataTable
        Try
            conexion1.Open()
            adaptador1.Fill(dtFecha)

        Catch ex As Exception
        Finally
            conexion1.Close()
        End Try

        Dim fila As DataRow
        fila = dtFecha.Rows(0)

        FechaVigencia = fila("FECHA")

        filaCentroClinicoImprimir = FilaCentroClinico
        Dim puntoOrigen As New Point(46, 33)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 751, 975)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 12, puntoOrigen.Y + 5, 100, 78)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 118, puntoOrigen.Y, puntoOrigen.X + 118, puntoOrigen.Y + 88) 'Vertical
        e.Graphics.DrawStringCentered("ORDEN PARA VALORACIONES MÉDICAS, ", Formato_Etiqueta_10, Brocha, 484, puntoOrigen.X + 116, puntoOrigen.Y + 20)
        e.Graphics.DrawStringCentered("EXÁMENES DE LABORATORIO, PARACLÍNICOS Y", Formato_Etiqueta_10, Brocha, 484, puntoOrigen.X + 116, puntoOrigen.Y + 40)
        e.Graphics.DrawStringCentered("EXÁMENES DE CONDUCTORES", Formato_Etiqueta_10, Brocha, 484, puntoOrigen.X + 116, puntoOrigen.Y + 57)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 620, puntoOrigen.Y, puntoOrigen.X + 620, puntoOrigen.Y + 88) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-091", Formato_Etiqueta_7, Brocha, 151, puntoOrigen.X + 610, puntoOrigen.Y + 18)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 620, puntoOrigen.Y + 43, puntoOrigen.X + 751, puntoOrigen.Y + 43) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 6", Formato_Etiqueta_7, Brocha, 151, puntoOrigen.X + 610, puntoOrigen.Y + 60)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 88, puntoOrigen.X + 751, puntoOrigen.Y + 88) 'Horizontal completa

        puntoOrigen.X = 59
        puntoOrigen.Y = puntoOrigen.Y + 88
        e.Graphics.DrawString("CIUDAD Y FECHA:", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 10)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 103, puntoOrigen.Y + 22, puntoOrigen.X + 408, puntoOrigen.Y + 22) 'Horizontal

        e.Graphics.DrawString("Examen No.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 447, puntoOrigen.Y + 9)
        e.Graphics.DrawString(IdExamen, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 515, puntoOrigen.Y + 8)

        ' e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 444, puntoOrigen.Y + 22, puntoOrigen.X + 578, puntoOrigen.Y + 22) 'Horizontal
        e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & FechaEnvio.ToLongDateString, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 108, puntoOrigen.Y + 8)

        e.Graphics.DrawString("Señores:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 40)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 103, puntoOrigen.Y + 52, puntoOrigen.X + 578, puntoOrigen.Y + 52) 'Horizontal
        e.Graphics.DrawString(filaCentroClinicoImprimir("NOMBRECENTROCLINICO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 108, puntoOrigen.Y + 38)
        e.Graphics.DrawString("Dirección:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 58)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 103, puntoOrigen.Y + 70, puntoOrigen.X + 578, puntoOrigen.Y + 70) 'Horizontal
        Dim Ciudadfecha As String = filaCentroClinicoImprimir("DIRECCION") & ", " & filaCentroClinicoImprimir("CIUDAD")
        If e.Graphics.MeasureString(Ciudadfecha, Formato_Etiqueta_9R).Width <= 470 Then
            e.Graphics.DrawString(Ciudadfecha, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 108, puntoOrigen.Y + 56)

        Else
            e.Graphics.DrawString(Ciudadfecha, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 108, puntoOrigen.Y + 57)
        End If
        e.Graphics.DrawString("Teléfono:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 74)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 103, puntoOrigen.Y + 86, puntoOrigen.X + 578, puntoOrigen.Y + 86) 'Horizontal
        e.Graphics.DrawString(filaCentroClinicoImprimir("TELEFONO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 108, puntoOrigen.Y + 72)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 607, puntoOrigen.Y, puntoOrigen.X + 607, puntoOrigen.Y + 157) 'Vertical

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 607, puntoOrigen.Y + 157, puntoOrigen.X + 738, puntoOrigen.Y + 157) 'Horizontal

        Dim foto As Image = FunBase.DevolverImagenMiniatura(1, Idpersona)
        If Not IsNothing(foto) Then
            e.Graphics.DrawImage(foto, puntoOrigen.X + 612, puntoOrigen.Y + 3, 120, 150)
        Else
            e.Graphics.DrawString("Espacio para la foto", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 588, puntoOrigen.Y + 60)
        End If

        If _filaPersona("GENERO") = "M" Then

            e.Graphics.DrawString("Solicitamos atender al señor:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 105)
        Else
            e.Graphics.DrawString("Solicitamos atender a la señora:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 105)
        End If

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 180, puntoOrigen.Y + 117, puntoOrigen.X + 578, puntoOrigen.Y + 117) 'Horizontal

        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 180, puntoOrigen.Y + 103)

        e.Graphics.DrawString("con número de identificación:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 126)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 180, puntoOrigen.Y + 138, puntoOrigen.X + 355, puntoOrigen.Y + 138) 'Horizontal

        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 180, puntoOrigen.Y + 124)

        e.Graphics.DrawString("de", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 368, puntoOrigen.Y + 126)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 391, puntoOrigen.Y + 138, puntoOrigen.X + 578, puntoOrigen.Y + 138) 'Horizontal
        e.Graphics.DrawString(_filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 396, puntoOrigen.Y + 124)

        e.Graphics.DrawString("quien desempeñará o desempeña el cargo de:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 145)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 267, puntoOrigen.Y + 157, puntoOrigen.X + 578, puntoOrigen.Y + 157) 'Horizontal

        If NombreCargoPropuesto.Length < 51 Then
            e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 272, puntoOrigen.Y + 143)
        Else
            If NombreCargoPropuesto.Length < 57 Then
                e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 272, puntoOrigen.Y + 144)
            Else
                e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 272, puntoOrigen.Y + 146)
            End If
        End If

        e.Graphics.DrawString("con número de contacto:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 163)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 143, puntoOrigen.Y + 175, puntoOrigen.X + 240, puntoOrigen.Y + 175) 'Horizontal
        e.Graphics.DrawString(_filaPersona("TELEFONOMOVIL"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 148, puntoOrigen.Y + 161)
        e.Graphics.DrawString("de acuerdo al motivo de la consulta que se señala en seguida:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 242, puntoOrigen.Y + 163)

        e.Graphics.DrawString("1.     INGRESO", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 200)
        e.Graphics.DrawString("Formato ICH-GRAL-F-302", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 24, puntoOrigen.Y + 213)
        e.Graphics.DrawString("2.     INGRESO ATENCIÓN A EMERGENCIAS", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 230)
        e.Graphics.DrawString("Formato ICH-GRAL-F-302", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 24, puntoOrigen.Y + 243)
        e.Graphics.DrawString("3.     RETIRO", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 260)
        e.Graphics.DrawString("Formato ICH-GRAL-F-351", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 24, puntoOrigen.Y + 273)
        e.Graphics.DrawString("4.     PERIÓDICO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 387, puntoOrigen.Y + 185)
        e.Graphics.DrawString("Formato ICH-GRAL-F-355", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 198)
        e.Graphics.DrawString("5.     POST-INCAPACIDAD", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 387, puntoOrigen.Y + 215)
        e.Graphics.DrawString("Formato ICH-GRAL-F-353", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 228)
        e.Graphics.DrawString("6.     REUBICACIÓN", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 387, puntoOrigen.Y + 245)
        e.Graphics.DrawString("Formato ICH-GRAL-F-361", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 258)
        e.Graphics.DrawString("7.     OTRO MOTIVO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 387, puntoOrigen.Y + 275)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 267, puntoOrigen.Y + 200, 35, 16)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 267, puntoOrigen.Y + 230, 35, 16)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 267, puntoOrigen.Y + 260, 35, 16)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 587, puntoOrigen.Y + 185, 35, 16)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 587, puntoOrigen.Y + 215, 35, 16)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 587, puntoOrigen.Y + 245, 35, 16)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 587, puntoOrigen.Y + 275, 35, 16)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 308, puntoOrigen.X + 738, puntoOrigen.Y + 308) 'Horizontal
        e.Graphics.DrawString("TAREAS CRÍTICAS:", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 318)

        e.Graphics.DrawString("ALTURAS", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 147, puntoOrigen.Y + 318)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 217, puntoOrigen.Y + 315, 35, 16)
        If Mid(TareasCriticas, 1, 1) = "S" Then
            e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 217, puntoOrigen.Y + 315)
        End If

        e.Graphics.DrawString("ESPACIOS CONFINADOS", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 297, puntoOrigen.Y + 318)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 447, puntoOrigen.Y + 315, 35, 16)
        If Mid(TareasCriticas, 2, 1) = "S" Then
            e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 447, puntoOrigen.Y + 315)
        End If

        e.Graphics.DrawString("INMERSIONES", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 537, puntoOrigen.Y + 318)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 643, puntoOrigen.Y + 315, 35, 16)
        If Mid(TareasCriticas, 3, 1) = "S" Then
            e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 643, puntoOrigen.Y + 315)
        End If

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 338, puntoOrigen.X + 738, puntoOrigen.Y + 338) 'Horizontal

        e.Graphics.DrawString("VALORACIÓN PARED Y CAVIDAD ABDOMINAL:", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 348)
        e.Graphics.DrawString("Formato ICH-GRAL-F-359", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 297, puntoOrigen.Y + 350)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 447, puntoOrigen.Y + 345, 35, 16)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 368, puntoOrigen.X + 738, puntoOrigen.Y + 368) 'Horizontal
        e.Graphics.DrawString("EXÁMENES DE LABORATORIO, CLÍNICOS Y PARACLÍNICOS: ", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 378)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 483, puntoOrigen.X + 738, puntoOrigen.Y + 483) 'Horizontal
        e.Graphics.DrawString("EXAMEN DE COLUMNA LUMBAR: ", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 493)

        e.Graphics.DrawString("RMN COLUMNA LUMBO-SACRA SIMPLE", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 493)
        e.Graphics.DrawString("Formato ICH GRAL F-360", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 440, puntoOrigen.Y + 495)
        e.Graphics.DrawString("TAC DE COLUMNA LUMBAR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 508)
        e.Graphics.DrawString("RX DE COLUMNA LUMBAR DINÁMICAS", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 525)

        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 557, puntoOrigen.Y + 488, 35, 48)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 557, puntoOrigen.Y + 504, puntoOrigen.X + 592, puntoOrigen.Y + 504) 'vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 557, puntoOrigen.Y + 520, puntoOrigen.X + 592, puntoOrigen.Y + 520) 'vertical

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 543, puntoOrigen.X + 738, puntoOrigen.Y + 543) 'Horizontal
        e.Graphics.DrawString("EXÁMENES PARA CONDUCTORES: ", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 553)

        e.Graphics.DrawString("EVALUACIÓN PSICOSENSOMÉTRICA OCUPACIONAL", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 553)
        e.Graphics.DrawString("EVALUACIÓN DE COMPETENCIAS TEORICO - PRÁCTICAS", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 568)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 557, puntoOrigen.Y + 548, 35, 32)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 557, puntoOrigen.Y + 564, puntoOrigen.X + 592, puntoOrigen.Y + 564) 'vertical

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 586, puntoOrigen.X + 738, puntoOrigen.Y + 586) 'Horizontal
        e.Graphics.DrawString("EVALUACIÓN MÉDICA OCUPACIONAL:", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 596)
        e.Graphics.DrawString("Formato ICH GRAL F-302", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 230, puntoOrigen.Y + 598)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 362, puntoOrigen.Y + 594, 35, 16)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 415, puntoOrigen.Y + 586, puntoOrigen.X + 415, puntoOrigen.Y + 616) 'vertical
        e.Graphics.DrawString("CENTRO DE COSTOS:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 430, puntoOrigen.Y + 596)
        e.Graphics.DrawString(Centrocostoexamen, Formato_Etiqueta_8, Brocha, puntoOrigen.X + 580, puntoOrigen.Y + 596)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 616, puntoOrigen.X + 738, puntoOrigen.Y + 616) 'Horizontal

        e.Graphics.DrawString("VIGENCIA:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 626)
        e.Graphics.DrawString("El presente documento tendrá validez hasta el próximo: ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 70, puntoOrigen.Y + 626)
        e.Graphics.DrawString(FechaVigencia.ToLongDateString, Formato_Etiqueta_11, Brocha, puntoOrigen.X + 390, puntoOrigen.Y + 624)


        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 643, puntoOrigen.X + 738, puntoOrigen.Y + 643) 'Horizontal

        Select Case CodigoMotivoConsultaExamenes
            Case 2 'Ingreso
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 267, puntoOrigen.Y + 201)
            Case 7 'Ingreso Atención de Emergencias
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 267, puntoOrigen.Y + 231)
            Case 4 ' Retiro
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 267, puntoOrigen.Y + 261)
            Case 3 'Periódico
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 587, puntoOrigen.Y + 186)
            Case 6 'Post-Incapacidad
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 587, puntoOrigen.Y + 216)
            Case 5 'Rehubicación
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 587, puntoOrigen.Y + 246)
            Case 8 'Otro Motivo
                e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 587, puntoOrigen.Y + 276)
            Case Else
        End Select


        'e.Graphics.DrawString("OBSERVACIONES:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 724)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 668, puntoOrigen.X + 738, puntoOrigen.Y + 668) 'vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 685, puntoOrigen.X + 738, puntoOrigen.Y + 685) 'vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 13, puntoOrigen.Y + 702, puntoOrigen.X + 738, puntoOrigen.Y + 702) 'vertical

        Dim observaciones As New StringBuilder
        observaciones.Append("OBSERVACIONES:  ")
        observaciones.Append(" ").Append(ObservacionesEE)


        'Revisar Las 5 partes del formato
        Dim FilasExamenes() As DataRow
        Dim filaexamen As DataRow

        '1 . Valoracion
        FilasExamenes = dtExamenesPreocupacionales.Select("CODIGOEXAMENPREOCUPACIONAL=1 and PRACTICAR='S'")
        If FilasExamenes.Length > 0 Then
            e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 447, puntoOrigen.Y + 346)
        End If
        '2. Laboratorios
        FilasExamenes = dtExamenesPreocupacionales.Select("(TIPO='LAB' or TIPO='PAR' or TIPO='OTR') and PRACTICAR='S'")
        If FilasExamenes.Length > 0 Then
            Dim ContadorExa As Integer = 1

            For Exa = 0 To FilasExamenes.Length - 1
                filaexamen = FilasExamenes(Exa)
                Dim NombreExamen As String = filaexamen("NOMBREEXAMENPREOCUPACIONAL").ToString.Trim
                Dim CodigoExamen As Integer = filaexamen("CODIGOEXAMENPREOCUPACIONAL")
                Dim Formato As Drawing.Font

                Select Case CodigoExamen
                    Case 25, 26
                        Formato = Formato_Etiqueta_6R
                    Case 27
                        Formato = Formato_Etiqueta_5R
                    Case 8
                        Formato = Formato_Etiqueta_7R
                    Case Else
                        Formato = Formato_Etiqueta_8R
                End Select

                Select Case ContadorExa
                    Case 1
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 400)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 317, puntoOrigen.Y + 396, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 317, puntoOrigen.Y + 397)
                    Case 2
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 416)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 317, puntoOrigen.Y + 412, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 317, puntoOrigen.Y + 413)
                    Case 3
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 432)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 317, puntoOrigen.Y + 428, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 317, puntoOrigen.Y + 429)
                    Case 4
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 448)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 317, puntoOrigen.Y + 444, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 317, puntoOrigen.Y + 445)
                    Case 5
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 464)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 317, puntoOrigen.Y + 460, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 317, puntoOrigen.Y + 461)
                    Case 6
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 372, puntoOrigen.Y + 400)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 693, puntoOrigen.Y + 396, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 693, puntoOrigen.Y + 397)
                    Case 7
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 372, puntoOrigen.Y + 416)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 693, puntoOrigen.Y + 412, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 693, puntoOrigen.Y + 413)
                    Case 8
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 372, puntoOrigen.Y + 432)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 693, puntoOrigen.Y + 428, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 693, puntoOrigen.Y + 429)
                    Case 9
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 372, puntoOrigen.Y + 448)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 693, puntoOrigen.Y + 444, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 693, puntoOrigen.Y + 445)
                    Case 10
                        e.Graphics.DrawString(NombreExamen, Formato, Brocha, puntoOrigen.X + 372, puntoOrigen.Y + 464)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 693, puntoOrigen.Y + 460, 35, 16)
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 693, puntoOrigen.Y + 461)
                End Select
                ContadorExa = ContadorExa + 1
            Next

        End If
        '3 Columna

        FilasExamenes = dtExamenesPreocupacionales.Select("TIPO='CLU' and PRACTICAR='S'")
        If FilasExamenes.Length > 0 Then

            filaexamen = FilasExamenes(0)
            Select Case filaexamen("CODIGOEXAMENPREOCUPACIONAL")
                Case 2
                    e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 557, puntoOrigen.Y + 489) '1  RMN COLUMNA LUMBO-SACRA SIMPLE
                Case 19
                    e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 557, puntoOrigen.Y + 505) '1  RMN COLUMNA LUMBO-SACRA SIMPLE
                Case 20
                    e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 557, puntoOrigen.Y + 521) '1  RMN COLUMNA LUMBO-SACRA SIMPLE
            End Select
        End If

        '4 Conductores
        FilasExamenes = dtExamenesPreocupacionales.Select("TIPO='CON' and PRACTICAR='S'")
        If FilasExamenes.Length > 0 Then
            For i = 0 To FilasExamenes.Length - 1
                filaexamen = FilasExamenes(i)
                Select Case filaexamen("CODIGOEXAMENPREOCUPACIONAL")
                    Case 21
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 557, puntoOrigen.Y + 549) '
                    Case 22
                        e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 557, puntoOrigen.Y + 565) '
                End Select
            Next

        End If

        '5 Evaluacion medica ocupacional
        FilasExamenes = dtExamenesPreocupacionales.Select("CODIGOEXAMENPREOCUPACIONAL=23 and PRACTICAR='S'")
        If FilasExamenes.Length > 0 Then
            e.Graphics.DrawStringCentered("X", Formato_Etiqueta_10, Brocha, 35, puntoOrigen.X + 362, puntoOrigen.Y + 595)
        End If

        If observaciones.Length > 0 Then
            Dim obs As String = observaciones.ToString
            If obs.EndsWith(",") Then
                obs.Remove(obs.Length - 1) 'Retirar última coma
            End If
            Dim Cadenas As New ArrayList
            Cadenas.Add(obs)
            Dim Cadena_Total As New ArrayList
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_9R, 708, e)
            Dim texto As New StringBuilder
            Dim PosY As Single = puntoOrigen.Y + 650
            For i As Integer = 0 To Cadena_Total.Count - 1
                texto.Append(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_9R, 708, e))
                e.Graphics.DrawString(texto.ToString, Formato_Etiqueta_9R, Brocha, puntoOrigen.X, PosY)
                PosY += 18
                texto.Clear()
            Next
        End If
        Dim nota As String
        nota = "NOTAS: 1.La facturación debe remitirse a nombre de ISMOCOL S.A. identificado con NIT. 890.209.174-1 de acuerdo a las tarifas pactadas. 2." + _
                 "Los servicios solicitados se deberán prestar dentro de la vigencia indicada en el documento 3.Antes de realizar el examen de Columna Lumbar por " + _
                 "motivo de ingreso, se debe verificar que el paciente sea Apto en la Valoración de Pared y Cavidad Abdominal y en los exámenes de Laboratorio, " + _
                 "Clínicos y Paraclínicos; en caso de que el paciente no sea recomendado para el cargo se debe suspender el proceso."

        Dim CadenasNota As New ArrayList
        CadenasNota.Add(nota)
        Dim Cadena_TotalNota As New ArrayList
        Cadena_TotalNota = TextoAParrafoFuente(CadenasNota, Formato_Etiqueta_6R, 708, e)


        Dim texto1 As New StringBuilder
        Dim Pos1Y As Single = puntoOrigen.Y + 705
        For i As Integer = 0 To Cadena_TotalNota.Count - 1
            texto1.Append(SubParrafo1(Cadena_TotalNota(i), Formato_Etiqueta_6R, 720, e))
            e.Graphics.DrawString(texto1.ToString, Formato_Etiqueta_6R, Brocha, puntoOrigen.X, Pos1Y)
            Pos1Y += 18
            texto1.Clear()
        Next


        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 43, puntoOrigen.Y + 792, 200, 84)
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 45, puntoOrigen.Y + 795)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 43, puntoOrigen.Y + 845, puntoOrigen.X + 243, puntoOrigen.Y + 845) 'Horizontal
        If VariablesBase.VariablesBase.IddependenciaSiscontrolActual = 13 Then
            e.Graphics.DrawStringCentered("DPTO. MÉDICO", Formato_Etiqueta_9, Brocha, 200, puntoOrigen.X + 43, puntoOrigen.Y + 847)
        Else
            e.Graphics.DrawStringCentered("ADMINISTRADOR", Formato_Etiqueta_9, Brocha, 200, puntoOrigen.X + 43, puntoOrigen.Y + 847)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 3, puntoOrigen.Y + 862, puntoOrigen.X + 243, puntoOrigen.Y + 862) 'Horizontal
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X - 2, puntoOrigen.Y + 865)

        If VariablesBase.VariablesBase.IddependenciaSiscontrolActual = 13 Then
            Dim Medico As String = _filaBaseConfiguracion("MEDICO").ToString
            If Medico.Length < 32 Then
                e.Graphics.DrawStringCentered(Medico, Formato_Etiqueta_7R, Brocha, 200, puntoOrigen.X + 43, puntoOrigen.Y + 865)
            Else
                e.Graphics.DrawStringCentered(Medico, Formato_Etiqueta_6R, Brocha, 200, puntoOrigen.X + 43, puntoOrigen.Y + 865)
            End If
        Else
            Dim Administrador As String = _filaBaseConfiguracion("ADMINISTRADOR").ToString
            If Administrador.Length < 32 Then
                e.Graphics.DrawStringCentered(Administrador, Formato_Etiqueta_7R, Brocha, 200, puntoOrigen.X + 43, puntoOrigen.Y + 865)
            Else
                e.Graphics.DrawStringCentered(Administrador, Formato_Etiqueta_6R, Brocha, 200, puntoOrigen.X + 43, puntoOrigen.Y + 865)
            End If
        End If

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 3, puntoOrigen.Y + 876, puntoOrigen.X + 43, puntoOrigen.Y + 876) 'horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X - 3, puntoOrigen.Y + 862, puntoOrigen.X + -3, puntoOrigen.Y + 876) 'Vertical
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 377, puntoOrigen.Y + 792, 200, 84)
        e.Graphics.DrawString("Recibí,", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 379, puntoOrigen.Y + 795)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 377, puntoOrigen.Y + 845, puntoOrigen.X + 577, puntoOrigen.Y + 845) 'Horizontal
        e.Graphics.DrawStringCentered("PACIENTE", Formato_Etiqueta_9, Brocha, 200, puntoOrigen.X + 377, puntoOrigen.Y + 848)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 327, puntoOrigen.Y + 862, 250, 14)
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 331, puntoOrigen.Y + 865)
        Dim Paciente As String = _filaPersona("NOMBRECOMPLETO").ToString
        If Paciente.Length < 32 Then
            e.Graphics.DrawStringCentered(Paciente, Formato_Etiqueta_7R, Brocha, 200, puntoOrigen.X + 377, puntoOrigen.Y + 865)
        Else
            e.Graphics.DrawStringCentered(Paciente, Formato_Etiqueta_6R, Brocha, 200, puntoOrigen.X + 377, puntoOrigen.Y + 865)
        End If
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 618, puntoOrigen.Y + 767, 110, 110)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 618, puntoOrigen.Y + 862, puntoOrigen.X + 728, puntoOrigen.Y + 862) 'Horizontal
        e.Graphics.DrawStringCentered("Huella", Formato_Etiqueta_8R, Brocha, 110, puntoOrigen.X + 618, puntoOrigen.Y + 865)


        _impresionFinalizada = True

        If BloquearEdiciónExamen = True Then
            Dim comando As SqlCommand
            Dim adaptador As SqlDataAdapter
            Dim conexion As New SqlConnection
            conexion.ConnectionString = My.Settings.CadenaConexión

            comando = New SqlCommand("UPDATE ENVIOEXAMEN set PERMITIREDICION='N' where IDENVIOEXAMEN=@IDENVIOEXAMEN", conexion)
            comando.Parameters.AddWithValue("@IDENVIOEXAMEN", IdExamen)
            adaptador = New SqlDataAdapter(comando)

            Try
                comando.Connection.Open()
                comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se pudo guardar el bloqueo de edición del examen")
            Finally
                conexion.Close()
            End Try
        End If
        BloquearEdiciónExamen = True

    End Sub
#End Region

End Class
