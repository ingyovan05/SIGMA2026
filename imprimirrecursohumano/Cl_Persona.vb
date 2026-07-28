Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Data.SqlClient
Imports FunBase = FuncionesBase.FuncionesBase
Imports System.Windows.Forms
Imports MessagingToolkit.QRCode.Codec
Imports MessagingToolkit.QRCode.Codec.Data
Imports System.Drawing.Imaging

Partial Class Cl_Impresión

#Region " 2 - ICA GRAL-F-068 DOCUMENTOS Y TRÁMITE PARA VINCULACIÓN DE NUEVOS EMPLEADOS"
    Public WithEvents DocImp_ICAGRALF68 As New PrintDocument
    Private Nueva_PaginaF68 As Integer = 1


    Private Sub DocImpr_ICAGRALF68(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF68.PrintPage


        Dim puntoOrigen As New Point(30, 50)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 980)
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 10, puntoOrigen.Y + 12, 105, 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 120, puntoOrigen.Y, puntoOrigen.X + 120, puntoOrigen.Y + 110) 'Vertical
        e.Graphics.DrawStringCentered("DOCUMENTOS Y TRÁMITE PARA VINCULACIÓN", Formato_Etiqueta_12, Brocha, 480, puntoOrigen.X + 120, puntoOrigen.Y + 37)
        e.Graphics.DrawStringCentered("DE NUEVOS EMPLEADOS", Formato_Etiqueta_12, Brocha, 480, puntoOrigen.X + 120, puntoOrigen.Y + 57)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 595, puntoOrigen.Y, puntoOrigen.X + 595, puntoOrigen.Y + 110) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-068", Formato_Etiqueta_8, Brocha, 155, puntoOrigen.X + 600, puntoOrigen.Y + 22)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 595, puntoOrigen.Y + 55, puntoOrigen.X + 750, puntoOrigen.Y + 55) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 7", Formato_Etiqueta_8, Brocha, 155, puntoOrigen.X + 600, puntoOrigen.Y + 76)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 110, puntoOrigen.X + 750, puntoOrigen.Y + 110) 'Horizontal completa

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Select Case (Nueva_PaginaF68)
            Case 1
                e.Graphics.DrawString("NOMBRE DEL", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 110)
                e.Graphics.DrawString("TRABAJADOR:", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 125)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 120, puntoOrigen.Y + 110, puntoOrigen.X + 120, puntoOrigen.Y + 140) 'Vertical
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 125, puntoOrigen.Y + 118)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y + 110, puntoOrigen.X + 450, puntoOrigen.Y + 140) 'Vertical
                e.Graphics.DrawStringCentered("CARGO:", Formato_Etiqueta_9, Brocha, 80, puntoOrigen.X + 450, puntoOrigen.Y + 118)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 530, puntoOrigen.Y + 110, puntoOrigen.X + 530, puntoOrigen.Y + 140) 'Vertical
                Const anchoCargo As Integer = 255
                If e.Graphics.MeasureString(NombreCargoPropuesto, Formato_Etiqueta_9R).Width < anchoCargo Then
                    e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 535, puntoOrigen.Y + 118)
                Else
                    Dim y As Integer = puntoOrigen.Y + 110
                    Dim fuente As Font = Formato_Etiqueta_8R
                    Dim cadenas As New ArrayList
                    cadenas.Add(NombreCargoPropuesto)
                    Dim cadenasTotal As ArrayList = TextoAParrafoFuente(cadenas, fuente, anchoCargo, e, False)
                    For i As Integer = 0 To cadenasTotal.Count - 1
                        e.Graphics.DrawString(cadenasTotal(i), fuente, Brocha, puntoOrigen.X + 535, y + i * 10)
                    Next
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 140, puntoOrigen.X + 750, puntoOrigen.Y + 140) 'Horizontal completa

                puntoOrigen.Y += 140
                Dim puntoCuadroReqEntrArch As New Point(puntoOrigen.X + 640, puntoOrigen.Y + 5)
                puntoOrigen.X += 10
                puntoOrigen.Y += 18
                e.Graphics.DrawString("1   Requerimiento de Personal", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 5)
                e.Graphics.DrawString("(Aprobada por la Gerencia General en Bucaramanga o por el Director de Obra", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 182, puntoOrigen.Y + 5)
                e.Graphics.DrawString("en los Proyectos)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 18, puntoOrigen.Y + 20)

                e.Graphics.DrawString("2   Oferta de Vacantes", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 45)
                e.Graphics.DrawString("*    Formato ICA-GRAL-F-150 Autorización de Publicación de Vacante.", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 65)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 85)
                e.Graphics.DrawString("Evidencia de la Publicación de Vacante.", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 85)

                e.Graphics.DrawString("3   Reclutamiento de Personal", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 110)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 130)
                e.Graphics.DrawString("Formato ICA-GRAL-F-153 Autorización para tratamiento de Datos Personales", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 130)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 150)
                e.Graphics.DrawString("Formato ICA-GRAL-F-357 Consentimiento informado", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 150)
                e.Graphics.DrawString("*    Formato ICA GRAL F-44 (Selección de Administradora en los Sistemas de Pensión y Salud)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 170)
                e.Graphics.DrawString("*    Certificado de Residencia o carta de territorialidad (personal local)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 190)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 210)
                e.Graphics.DrawString("Evidencia de postulación del candidato a la vacante", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 210)
                e.Graphics.DrawString("*    Hoja de Vida", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 230)
                e.Graphics.DrawString("*    Formato ICA GRAL F-97 Registro de Datos Personales", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 250)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 270)
                e.Graphics.DrawString("Fotocopias ampliadas 150% de los siguientes documentos: cédula (4) , licencia de conducción (1)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 270)
                e.Graphics.DrawString("para conductores, tarjeta de operador de acuerdo al equipo a operar (1) para los operadores", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 285)
                e.Graphics.DrawString("*    Certificados de estudios", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 305)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 325)
                e.Graphics.DrawString("Fotocopia del diploma o matrícula profesional", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 325)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 345)
                e.Graphics.DrawString("Certificados de Trabajo relacionados en la hoja de vida", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 345)
                e.Graphics.DrawString("4   Verificaciones Administrativas", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 370)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 390)
                e.Graphics.DrawString("Verificaciones de Seguridad Física, Seguridad Social y SAGRLAFT", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 390)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 410)
                e.Graphics.DrawString("Verificación de SIMIT / RUNT - Resolución 1565 de 2014 (para conductores)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 410)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 430)
                e.Graphics.DrawString("Verificación de certificaciones de operador de maquinaria - Ejemplo: CC&S, Grumas… (para operadores)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 430)
                e.Graphics.DrawString("5   Evaluación de Competencias - Validación de Requisitos", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 455)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 475)
                e.Graphics.DrawString("Formato ICA-GRAL-F-155 Evaluación de Competencias - Validación de Requisitos (o el formato", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 475)
                e.Graphics.DrawString("establecido en el Proyecto)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 17, puntoOrigen.Y + 490)
                e.Graphics.DrawString("6  Documentos", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 515)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 535)
                e.Graphics.DrawString("Registro Fotográfico del candidato", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 535)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 555)
                e.Graphics.DrawString("Certificado de Afiliación a fondo de Pensiones y EPS (expedición inferior a 30 días)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 555)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 575)
                e.Graphics.DrawString("Certificado de Historia Laboral expedido por el Fondo de Pensiones (expedición inferior a 30 días)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 575)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 595)
                e.Graphics.DrawString("Certificado de la cuenta bancaria (expedición inferior a 30 días)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 595)
                e.Graphics.DrawString("*    Certificado de Inscripción al Servicio Público de Empleo", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 615)
                e.Graphics.DrawString("*    Fotocopia del carnet de vacunación: Fiebre Amarilla, Tétano (Todos)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 635)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 655)
                e.Graphics.DrawString("Fotocopia del carnet de Vacuna Hepatitis B (para Profesionales de la salud)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 655)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 675)
                e.Graphics.DrawString("Certificado de Antecedentes Judiciales - Policía (expedición inferior a 30 días)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 675)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 695)
                e.Graphics.DrawString("Certificado de Antecedentes Disciplinarios - Procuraduría (expedición inferior a 30 días)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 695)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 715)
                e.Graphics.DrawString("Certificado de Antecedentes Fiscales - Contraloría (expedición inferior a 30 días)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 715)
                e.Graphics.DrawString("*    Libreta Militar", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 735)
                e.Graphics.DrawString("*    Una (1) Referencia Personal", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 755)


                e.Graphics.FillRectangle(BrochaGrisClaro, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 15)
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 50)
                e.Graphics.DrawStringCentered("REQ.", Formato_Etiqueta_6, Brocha, 30, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 3)
                e.Graphics.DrawStringCentered("ENTR.", Formato_Etiqueta_6, Brocha, 30, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 3)
                e.Graphics.DrawStringCentered("ARCH.", Formato_Etiqueta_6, Brocha, 30, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 3)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 15, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 15) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 50) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 50) 'Vertical

                puntoCuadroReqEntrArch.Y += 75
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 40)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 20, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 20) 'Horizontal

                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 40) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 40) 'Vertical

                puntoCuadroReqEntrArch.Y += 65
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 235)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 20, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 20) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 40, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 40) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 60, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 60) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 80, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 80) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 100, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 100) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 120, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 120) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 140, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 140) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 175, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 175) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 195, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 195) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 215, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 215) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 235) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 235) 'Vertical

                puntoCuadroReqEntrArch.Y += 260
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 60)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 20, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 20) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 40, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 40) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 60) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 60) 'Vertical

                puntoCuadroReqEntrArch.Y += 85
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 40)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 40) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 40) 'Vertical

                puntoCuadroReqEntrArch.Y += 60
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 240)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 20, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 20) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 40, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 40) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 60, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 60) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 80, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 80) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 100, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 100) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 120, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 120) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 140, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 140) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 160, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 160) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 180, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 180) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 200, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 200) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 220, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 220) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 240) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 240) 'Vertical




                e.Graphics.DrawStringCentered("1" & " de " & "2", Formato_Etiqueta_9R, Brocha, 750, 30, 1050)
            Case 2
                puntoOrigen.X += 10
                e.Graphics.DrawString("7   Preselección y selección de Candidatos", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 123)
                e.Graphics.DrawString("(Bucaramanga y Piedecuesta)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 255, puntoOrigen.Y + 123)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 148)
                e.Graphics.DrawString("Formato ICA-GRAL-F-090: Entrevista Técnica", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 148)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 168)
                e.Graphics.DrawString("Entrevista Psicotécnica o específica", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 168)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 188)
                e.Graphics.DrawString("Formato ICA-GRAL-F-092: Informe final de selección", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 188)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 208)
                e.Graphics.DrawString("Formato ICA-GRAL-F-106: Visita Domiciliaria", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 208)
                e.Graphics.DrawString("8   Valoración Médica de Ingreso, Exámenes de Laboratorio, Paraclínicos y de Conductores: ", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 233)
                e.Graphics.DrawString("(Según matriz de exámenes ocupacionales por cargo ICH-GRAL-F-301)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 248)
                e.Graphics.DrawString("1. Formato ICA-GRAL-F-091: Orden de exámenes ocupacionales de ingreso:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 268)
                e.Graphics.DrawString("Exámenes de Laboratorio y Paraclínicos teniendo en cuenta el cargo del aspirante (Si no tiene evidencias", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 288)
                e.Graphics.DrawString("que impidan el ejercicio del cargo, se remite a examen de Pared Abdominal)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 303)
                e.Graphics.DrawString("2. Formato ICH GRAL F-359: Valoración Pared y Cavidad Abdominal", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 323)
                e.Graphics.DrawString("(Si no tiene evidencias patológicas, se remite al examen de Resonancia Magnética)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 338)
                e.Graphics.DrawString("3. Formato ICH-GRAL-F-360: Registro de Resonancia Magnética Nuclear de Columna Lumbo-sacra", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 358)
                e.Graphics.DrawString("Simple", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 373)
                e.Graphics.DrawString("(Si en el municipio no hay disponibilidad de este examen, o donde los aspirantes no puedan retornar durante", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 393)
                e.Graphics.DrawString("la misma jornada  (ida y regreso) se autoriza el examen de Tomografía Axial Computarizada - TAC; y si no", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 408)
                e.Graphics.DrawString("se cuenta con estas tecnologías, se puede realizar examen de Rayos X Dinámicos de Columna Lumbosacra)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 423)
                e.Graphics.DrawString("*   Exámenes Psicosensométricos - artículo 5 de la Ley 1383 de 2010 (para conductores)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 443)
                e.Graphics.DrawString("*   Evaluación de competencias Teorico-prácticas (para conductores)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 463)
                e.Graphics.DrawString("4. Formato ICH-GRAL-F-302: Valoración Médica de Ingreso", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 483)
                e.Graphics.DrawString("(asegurar las firmas del Paciente y del Médico Especialista con el respectivo sello)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 503)
                e.Graphics.DrawString("9   Documentos a diligenciar", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 528)
                e.Graphics.DrawString("*    Formato ICA-GRAL-F-127 (Autorización Descuento Sindical)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 548)
                e.Graphics.DrawString("*    Formato ICH GRAL F-14 (Compromiso y Aceptación de la Política de No consumo sus. Psicoactivas y", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 568)
                e.Graphics.DrawString("Alcohol)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 583)
                e.Graphics.DrawString("*    Formato ICH GRAL F-81 (Aceptación y Compromiso de la Obligación de Reportar Accidentes de Trabajo)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 603)
                e.Graphics.DrawString("*    Formato ICS GRAL F-203 (Compromiso y Aceptación de la política y plan estratégico de Seguridad Vial)", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 623)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 643)
                e.Graphics.DrawString("Compromiso con la Seguridad Vial, Salud y Medio Ambiente", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 643)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 663)
                e.Graphics.DrawString("Firma de Contrato de Trabajo (asegurar las firmas del Empleador, Trabajador y Testigos)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 663)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 683)
                e.Graphics.DrawString("Carta de asignación de auxilios y/o bonos (asegurar las firmas del Empleador y Trabajador)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 683)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 703)
                e.Graphics.DrawString("Afiliación a la  EPS, AFP, ARL y CCF", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 703)
                e.Graphics.DrawString("*    Carné de Empleado de ISMOCOL S.A.", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 723)
                e.Graphics.DrawString("*", Formato_Etiqueta_9I, Brocha, puntoOrigen.X, puntoOrigen.Y + 743)
                e.Graphics.DrawString("Presentación de nuevo empleado", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 743)
                e.Graphics.DrawString("10 Formato ICS-GRAL-F-32 Entrega de Elementos de Protección Personal", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 768)
                e.Graphics.DrawString("(Personal de campo/Talleres) ", Formato_Etiqueta_9I, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 783)
                e.Graphics.DrawString("11 Formato ICA-GRAL-F-069: Programa de Inducción. Formato", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 808)
                e.Graphics.DrawString("12 Formato ICA-GRAL-F-14: Registros de Empleados Nuevos y Novedades", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 833)
                e.Graphics.DrawString("13", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 858)
                e.Graphics.DrawString("Evidencia de cierre de la Vacante", Formato_Etiqueta_9RSN, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 858)
                e.Graphics.DrawString("14", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 883)
                e.Graphics.DrawString("Digitalización de los documentos", Formato_Etiqueta_9RSN, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 883)
                e.Graphics.DrawString("15", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 908)
                e.Graphics.DrawString("Organización y archivo de acuerdo a la lista de chequeo: ICA-GRAL-L-001", Formato_Etiqueta_9RSN, Brocha, puntoOrigen.X + 19, puntoOrigen.Y + 908)

                puntoOrigen.Y += 140
                Dim puntoCuadroReqEntrArch As New Point(puntoOrigen.X + 640, puntoOrigen.Y + 5)

                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 80)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 20, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 20) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 40, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 40) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 60, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 60) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 80) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 80) 'Vertical

                puntoCuadroReqEntrArch.Y += 120
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 255)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 55, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 55) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 90, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 90) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 175, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 175) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 195, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 195) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 215, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 215) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 255) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 255) 'Vertical

                puntoCuadroReqEntrArch.Y += 280
                e.Graphics.DrawRectangle(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y, 90, 385)
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 20, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 20) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 55, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 55) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 75, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 75) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 95, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 95) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 115, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 115) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 135, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 135) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 155, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 155) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 175, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 175) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 195, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 195) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 220, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 220) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 260, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 260) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 285, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 285) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 310, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 310) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 335, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 335) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X, puntoCuadroReqEntrArch.Y + 360, puntoCuadroReqEntrArch.X + 90, puntoCuadroReqEntrArch.Y + 360) 'Horizontal
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 30, puntoCuadroReqEntrArch.Y + 385) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y, puntoCuadroReqEntrArch.X + 60, puntoCuadroReqEntrArch.Y + 385) 'Vertical
                e.Graphics.DrawStringCentered("2" & " de " & "2", Formato_Etiqueta_9R, Brocha, 750, 30, 1050)
        End Select

        If Nueva_PaginaF68 = 1 Then
            e.HasMorePages = True
            Nueva_PaginaF68 += 1
        Else
            e.HasMorePages = False
            Nueva_PaginaF68 = 1
        End If
    End Sub
#End Region

#Region " 4 - ICA GRAL-F-097 REGISTRO DE DATOS PERSONALES"

    Private WithEvents DocImp_ICAGRALF97 As New PrintDocument

    Private Sub DocImpr_ICAGRALF97(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF97.PrintPage

        If Not datosCargados Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM ListaDocumentos(@ACCION, @IDDOCUMENTO, @REVISION) ORDER BY [IDDOCUMENTO]", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1) 'Listar por IdDocumentoImprimir y Revisión
            comando.Parameters.AddWithValue("@IDDOCUMENTO", 32) 'ICA GRAL-F-097
            comando.Parameters.AddWithValue("@REVISION", 2) 'Rev. 2
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
                e.Graphics.DrawString(_filaPersona("APELLIDOS"), Formato_Etiqueta_8R, Brocha, 40, 166)
                e.Graphics.DrawString(_filaPersona("NOMBRES"), Formato_Etiqueta_8R, Brocha, 395, 166)

                Select Case _filaPersona("TIPOIDENTIFICACION")
                    Case "Cédula de ciudadanía"
                        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, 373, 385)
                    Case "Cédula de extranjería"
                        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, 567, 385)
                End Select

                Select Case _filaPersona("GENERO")
                    Case "M"
                        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, 749, 235)
                    Case "F"
                        e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, 683, 235)
                End Select
                e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, 275, 408)
                e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, 368, 431)
            Case 2 'Página 2

            Case 3 'Página 3

            Case 4 'Página 4

        End Select
        contadorPaginasImpresas += 1
        If contadorPaginasImpresas <= listaImagenesBD.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub DocImprFin_ICAGRALF97(ByVal sender As Object, ByVal e As PrintEventArgs) Handles DocImp_ICAGRALF97.EndPrint
        If e.PrintAction = PrintAction.PrintToPrinter Then
            datosCargados = False
        ElseIf e.PrintAction = PrintAction.PrintToPreview Then
            contadorPaginasImpresas = 0
        End If
    End Sub
#End Region

#Region " 5 - ICA GRAL-F-064 REQUERIMIENTO DE PERSONAL TERMINO FIJO"
    Private WithEvents DocImp_ICAGRALF64 As New PrintDocument
    Public nombreCargo As String
    Private Sub DocImpr_ICAGRALF64(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF64.PrintPage
        Dim puntoOrigen As New Point(39, 50)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 741, 990)
        e.Graphics.DrawString("REQUERIMIENTO DE PERSONAL Y APROBACIÓN PARA", Formato_Etiqueta_12, Brocha, 168, 55)
        e.Graphics.DrawString("CONTRATACIÓN", Formato_Etiqueta_12, Brocha, 330, 75)
        e.Graphics.DrawString("CONTRATO:", Formato_Etiqueta_11, Brocha, 173, 100)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 235, puntoOrigen.Y + 70, puntoOrigen.X + 550, puntoOrigen.Y + 70) 'Horizontal
        e.Graphics.DrawString("No. y Nombre", Formato_Etiqueta_8R, Brocha, 188, 130)
        e.Graphics.DrawString("ICA-GRAL-F-064", Formato_Etiqueta_9, Brocha, 654, 65)
        e.Graphics.DrawString("Revisión No. 4", Formato_Etiqueta_9, Brocha, 659, 115)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 129, puntoOrigen.Y, puntoOrigen.X + 129, puntoOrigen.Y + 98) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 586, puntoOrigen.Y, puntoOrigen.X + 586, puntoOrigen.Y + 98) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 10, puntoOrigen.Y + 5, 110, 85)
        e.Graphics.DrawLine(Lapiz, 625, 100, 780, 100) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 148, puntoOrigen.X + 741, 148) 'Horizontal completa
        puntoOrigen = New Point(45, 156)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 729, 875)
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y, 728, 25)
        e.Graphics.DrawString("DATOS GENERALES", Formato_Etiqueta_10, Brocha, 345, 160)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 25, puntoOrigen.X + 729, puntoOrigen.Y + 25) 'Horizontal completa
        e.Graphics.DrawString("CARGO (CÓDIGO*1):", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 170, puntoOrigen.Y + 45, puntoOrigen.X + 370, puntoOrigen.Y + 45) 'Horizontal
        'e.Graphics.DrawString(NombreCargoPropuesto, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 320, puntoOrigen.Y + 45)  Nombre cargo  

        Const anchoCargo As Integer = 255
        Dim concatenar As String = (NombreCargoPropuesto).ToString
        If e.Graphics.MeasureString(concatenar, Formato_Etiqueta_9R).Width < anchoCargo Then
            e.Graphics.DrawString(concatenar, Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 172, puntoOrigen.Y + 30)
        Else
            Dim y As Integer = puntoOrigen.Y + 110
            Dim fuente As Font = Formato_Etiqueta_8R
            Dim cadenas As New ArrayList
            cadenas.Add(concatenar)
            Dim cadenasTotal As ArrayList = TextoAParrafoFuente(cadenas, fuente, anchoCargo, e, False)
            For i As Integer = 0 To cadenasTotal.Count - 1
                e.Graphics.DrawString(cadenasTotal(i), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 172, puntoOrigen.Y + 25 + i * 8)
            Next
        End If

        e.Graphics.DrawString("DEPENDENCIA: ", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 415, puntoOrigen.Y + 30)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 550, puntoOrigen.Y + 45, puntoOrigen.X + 729, puntoOrigen.Y + 45) 'Horizontal
        e.Graphics.DrawString("JUSTIFICACION Y OBSERVACIONES:", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 55)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 260, puntoOrigen.Y + 70, puntoOrigen.X + 729, puntoOrigen.Y + 70) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 96, puntoOrigen.X + 729, puntoOrigen.Y + 96) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 117, puntoOrigen.X + 729, puntoOrigen.Y + 117) 'Horizontal
        e.Graphics.DrawString("MOTIVO DE CONTRATACIÓN", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 125)
        e.Graphics.DrawString("POR RETIRO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 147)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 162, puntoOrigen.X + 170, puntoOrigen.Y + 162) 'Horizontal
        e.Graphics.DrawString("PROMOCIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 169)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 185, puntoOrigen.X + 170, puntoOrigen.Y + 185) 'Horizontal
        e.Graphics.DrawString("POR PERMISO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 192)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 208, puntoOrigen.X + 170, puntoOrigen.Y + 208) 'Horizontal
        e.Graphics.DrawString("VACACIONES", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 217)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 231, puntoOrigen.X + 170, puntoOrigen.Y + 231) 'Horizontal
        e.Graphics.DrawString("INCAPACIDAD", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 237)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 254, puntoOrigen.X + 170, puntoOrigen.Y + 254) 'Horizontal
        e.Graphics.DrawString("TEMPORAL", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 235, puntoOrigen.Y + 147)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 162, puntoOrigen.X + 458, puntoOrigen.Y + 162) 'Horizontal
        e.Graphics.DrawString("RENOVACIÓN CONTRATO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 235, puntoOrigen.Y + 169)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 185, puntoOrigen.X + 458, puntoOrigen.Y + 185) 'Horizontal
        e.Graphics.DrawString("ADICIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 235, puntoOrigen.Y + 192)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 208, puntoOrigen.X + 458, puntoOrigen.Y + 208) 'Horizontal
        e.Graphics.DrawString("OTROS", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 235, puntoOrigen.Y + 217)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 231, puntoOrigen.X + 458, puntoOrigen.Y + 231) 'Horizontal
        e.Graphics.DrawString("DURACIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 235, puntoOrigen.Y + 237)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 254, puntoOrigen.X + 458, puntoOrigen.Y + 254) 'Horizontal
        e.Graphics.DrawString("CREACIÓN DEL CARGO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 503, puntoOrigen.Y + 147)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 658, puntoOrigen.Y + 162, puntoOrigen.X + 708, puntoOrigen.Y + 162) 'Horizontal
        e.Graphics.DrawString("LICENCIA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 503, puntoOrigen.Y + 169)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 658, puntoOrigen.Y + 185, puntoOrigen.X + 708, puntoOrigen.Y + 185) 'Horizontal
        e.Graphics.DrawString("TRASLADO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 503, puntoOrigen.Y + 192)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 658, puntoOrigen.Y + 208, puntoOrigen.X + 708, puntoOrigen.Y + 208) 'Horizontal
        e.Graphics.DrawString("CUAL?", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 503, puntoOrigen.Y + 217)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 558, puntoOrigen.Y + 231, puntoOrigen.X + 708, puntoOrigen.Y + 231) 'Horizontal
        e.Graphics.DrawString("DÍAS", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 503, puntoOrigen.Y + 237)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 558, puntoOrigen.Y + 254, puntoOrigen.X + 708, puntoOrigen.Y + 254) 'Horizontal
        e.Graphics.DrawString("FECHA EN QUE DEBE SER CUBIERTA LA VACANTE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 282)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 299, puntoOrigen.X + 729, puntoOrigen.Y + 299) 'Horizontal
        e.Graphics.DrawString("LUGAR DE CONTRATACION:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 307)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 208, puntoOrigen.Y + 324, puntoOrigen.X + 410, puntoOrigen.Y + 324) 'Horizontal
        e.Graphics.DrawString("BASE DEL TRABAJO:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 420, puntoOrigen.Y + 307)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 558, puntoOrigen.Y + 324, puntoOrigen.X + 729, puntoOrigen.Y + 324) 'Horizontal
        e.Graphics.DrawString("REQUERIMIENTOS ESPECIALES:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 332)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 208, puntoOrigen.Y + 349, puntoOrigen.X + 729, puntoOrigen.Y + 349) 'Horizontal
        e.Graphics.DrawString("*1.   PARA CARGOS NUEVOS, ADJUNTAR LA DESCRIPCIÓN DEL CARGO.", Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 357)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 382, puntoOrigen.X + 729, puntoOrigen.Y + 382) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 398, puntoOrigen.X + 729, puntoOrigen.Y + 398) 'Horizontal
        e.Graphics.DrawString("SOLICITADO POR", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 60, puntoOrigen.Y + 403)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 228, puntoOrigen.Y + 398, puntoOrigen.X + 228, puntoOrigen.Y + 526) 'Vertical
        e.Graphics.DrawString("AUTORIZADO POR", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 288, puntoOrigen.Y + 403)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 458, puntoOrigen.Y + 398, puntoOrigen.X + 458, puntoOrigen.Y + 526) 'Vertical
        e.Graphics.DrawString("APROBACIÓN GERENCIA", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 518, puntoOrigen.Y + 403)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 423, puntoOrigen.X + 729, puntoOrigen.Y + 423) 'Horizontal
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 90, puntoOrigen.Y + 425)
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 318, puntoOrigen.Y + 425)
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 578, puntoOrigen.Y + 425)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 442, puntoOrigen.X + 729, puntoOrigen.Y + 442) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 467, puntoOrigen.X + 458, puntoOrigen.Y + 467) 'Horizontal
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y + 470)
        e.Graphics.DrawString("Firma", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 328, puntoOrigen.Y + 470)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 486, puntoOrigen.X + 458, puntoOrigen.Y + 486) 'Horizontal
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 526, 728, 25)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 526, puntoOrigen.X + 729, puntoOrigen.Y + 526) 'Horizontal
        e.Graphics.DrawString("POSIBLES CANDIDATOS", Formato_Etiqueta_9, Brocha, 330, puntoOrigen.Y + 531)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 551, puntoOrigen.X + 729, puntoOrigen.Y + 551) 'Horizontal
        e.Graphics.DrawString("Código de la Oferta SPE:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 561)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 170, puntoOrigen.Y + 551, puntoOrigen.X + 170, puntoOrigen.Y + 582) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 410, puntoOrigen.Y + 551, puntoOrigen.X + 410, puntoOrigen.Y + 582) 'Vertical
        e.Graphics.DrawString("Operador donde se ofertó:", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 561)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y + 551, puntoOrigen.X + 580, puntoOrigen.Y + 679) 'Vertical
        e.Graphics.DrawString("Teléfono", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 627, puntoOrigen.Y + 587)

        If Not IsDBNull(_filaPersona("TELEFONOMOVIL")) Then
            e.Graphics.DrawString(_filaPersona("TELEFONOMOVIL"), Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 627, puntoOrigen.Y + 607)
        End If

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 582, puntoOrigen.X + 729, puntoOrigen.Y + 582) 'Horizontal
        e.Graphics.DrawString("Nombres y Apellidos", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 30, puntoOrigen.Y + 587)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_6RS, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 612)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 205, puntoOrigen.Y + 582, puntoOrigen.X + 205, puntoOrigen.Y + 679) 'Vertical
        e.Graphics.DrawString("No. de cédula", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 213, puntoOrigen.Y + 587)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 213, puntoOrigen.Y + 612)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 317, puntoOrigen.Y + 582, puntoOrigen.X + 317, puntoOrigen.Y + 679) 'Vertical
        e.Graphics.DrawString("Dirección", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 317, puntoOrigen.Y + 587)

        If Not IsDBNull(_filaPersona("DIRECCION")) Then
         Dim descripcion As String = (Trim(_filaPersona("DIRECCION")))
            Select Case descripcion.Length
                Case Is < 45
                    e.Graphics.DrawStringAligned(descripcion, HorizontalAlignment.Center, Formato_Etiqueta_8RS, Brocha, 220, puntoOrigen.X + 330, puntoOrigen.Y + 612)
                    Exit Select
                Case Is <= 50
                    e.Graphics.DrawStringAligned(descripcion, HorizontalAlignment.Center, Formato_Etiqueta_6RS, Brocha, 220, puntoOrigen.X + 330, puntoOrigen.Y + 612)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 60), Formato_Etiqueta_5RS, Brocha, puntoOrigen.X + 330, puntoOrigen.Y + 610)
                    e.Graphics.DrawString(Mid(descripcion, 61, 30), Formato_Etiqueta_5RS, Brocha, puntoOrigen.X + 330, puntoOrigen.Y + 618)

            End Select
                  End If


        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 604, puntoOrigen.X + 729, puntoOrigen.Y + 604) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 629, puntoOrigen.X + 729, puntoOrigen.Y + 629) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 654, puntoOrigen.X + 729, puntoOrigen.Y + 654) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 679, puntoOrigen.X + 729, puntoOrigen.Y + 679) 'Horizontal
        e.Graphics.FillRectangle(BrochaGrisClaro, puntoOrigen.X + 1, puntoOrigen.Y + 692, 728, 29)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 692, puntoOrigen.X + 729, puntoOrigen.Y + 692) 'Horizontal
        e.Graphics.DrawString("USO EXCLUSIVO DE ADMINISTRACIÓN", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 245, puntoOrigen.Y + 699)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 721, puntoOrigen.X + 729, puntoOrigen.Y + 721) 'Horizontal
        e.Graphics.DrawString("Grupo Salarial:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 751)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 766, puntoOrigen.X + 225, puntoOrigen.Y + 766) 'Horizontal
        e.Graphics.DrawString("Rango Salarial:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 325, puntoOrigen.Y + 751)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 435, puntoOrigen.Y + 766, puntoOrigen.X + 575, puntoOrigen.Y + 766) 'Horizontal
        e.Graphics.DrawString("Categoría:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 581, puntoOrigen.Y + 751)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 655, puntoOrigen.Y + 766, puntoOrigen.X + 705, puntoOrigen.Y + 766) 'Horizontal
        e.Graphics.DrawString("Salario de Enganche:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 781)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 165, puntoOrigen.Y + 796, puntoOrigen.X + 315, puntoOrigen.Y + 796) 'Horizontal
        e.Graphics.DrawString("Clase de Contrato:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 781)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 545, puntoOrigen.Y + 796, puntoOrigen.X + 705, puntoOrigen.Y + 796) 'Horizontal
        e.Graphics.DrawString("Otros Beneficios:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 806)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 821, puntoOrigen.X + 315, puntoOrigen.Y + 821) 'Horizontal
        e.Graphics.DrawString("Duración:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 801)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 545, puntoOrigen.Y + 821, puntoOrigen.X + 705, puntoOrigen.Y + 821) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 846, puntoOrigen.X + 315, puntoOrigen.Y + 846) 'Horizontal
        e.Graphics.DrawString("Nombre:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 856)
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 410, puntoOrigen.Y + 856)
    End Sub
#End Region

#Region " 6 - ICA GRAL-F-067 REQUERIMIENTO Y APROBACIÓN PARA CONTRATACIÓN DE PERSONAL DE ROL DIARIO"
    Private WithEvents DocImp_ICAGRALF67 As New PrintDocument

    Private Sub DocImpr_ICAGRALF67(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF67.PrintPage
        Dim puntoOrigen As New Point(50, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 741, 977)
        e.Graphics.DrawString("REQUERIMIENTO Y APROBACIÓN PARA CONTRATACIÓN", Formato_Etiqueta_12, Brocha, 173, 80)
        e.Graphics.DrawString("DE PERSONAL DE ROL DIARIO", Formato_Etiqueta_12, Brocha, 278, 105)
        e.Graphics.DrawString("ICA-GRAL-F-067", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 629, 65)
        e.Graphics.DrawString("Revisión No. 2", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 634, 115)
        Dim puntorec1 As New Point(500, 55)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 124, puntoOrigen.Y, puntoOrigen.X + 124, puntoOrigen.Y + 172) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 614, puntoOrigen.Y, puntoOrigen.X + 614, puntoOrigen.Y + 98) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 10, puntoOrigen.Y + 5, 110, 85)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 614, 100, puntoOrigen.X + 741, 100) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 98, puntoOrigen.X + 741, puntoOrigen.Y + 98) 'Horizontal completa
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 103)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 123, puntoOrigen.X + 741, puntoOrigen.Y + 123) 'Horizontal 
        e.Graphics.DrawString("Proyecto", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 128)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 443, puntoOrigen.Y + 123, puntoOrigen.X + 443, puntoOrigen.Y + 148) 'Vertical
        e.Graphics.DrawString("Contrato No:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 443, puntoOrigen.Y + 128)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 535, puntoOrigen.Y + 123, puntoOrigen.X + 535, puntoOrigen.Y + 148) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 148, puntoOrigen.X + 741, puntoOrigen.Y + 148) 'Horizontal 
        e.Graphics.DrawString("Frente/O.T.:", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 153)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 172, puntoOrigen.X + 741, puntoOrigen.Y + 172) 'Horizontal 
        e.Graphics.DrawString("Labor Contratada (1):", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 178)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 268, puntoOrigen.Y + 172, puntoOrigen.X + 268, puntoOrigen.Y + 196) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 196, puntoOrigen.X + 741, puntoOrigen.Y + 196) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 204, puntoOrigen.X + 741, puntoOrigen.Y + 204) 'Horizontal 
        e.Graphics.DrawString("NOMBRES Y APELLIDOS", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 55, puntoOrigen.Y + 211)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 268, puntoOrigen.Y + 204, puntoOrigen.X + 268, puntoOrigen.Y + 720) 'Vertical

        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_7RS, Brocha, puntoOrigen.X, puntoOrigen.Y + 245)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_7RS, Brocha, puntoOrigen.X + 269, puntoOrigen.Y + 245)
        e.Graphics.DrawString("C.C.#", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 295, puntoOrigen.Y + 211)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 361, puntoOrigen.Y + 204, puntoOrigen.X + 361, puntoOrigen.Y + 720) 'Vertical
        e.Graphics.DrawString("CARGO (2)", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 361, puntoOrigen.Y + 206)
        e.Graphics.DrawString("(Código)", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 371, puntoOrigen.Y + 221)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 443, puntoOrigen.Y + 204, puntoOrigen.X + 443, puntoOrigen.Y + 720) 'Vertical
        e.Graphics.DrawString("No oferta de la", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 443, puntoOrigen.Y + 206)
        e.Graphics.DrawString("Vacante", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 464, puntoOrigen.Y + 221)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 535, puntoOrigen.Y + 204, puntoOrigen.X + 535, puntoOrigen.Y + 720) 'Vertical
        e.Graphics.DrawString("FECHA", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 551, puntoOrigen.Y + 206)
        e.Graphics.DrawString("INGRESO", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 541, puntoOrigen.Y + 221)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 614, puntoOrigen.Y + 204, puntoOrigen.X + 614, puntoOrigen.Y + 720) 'Vertical
        e.Graphics.DrawString("TIPO DE", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 645, puntoOrigen.Y + 206)
        e.Graphics.DrawString("CONTRATO (3)", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 624, puntoOrigen.Y + 221)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 240, puntoOrigen.X + 741, puntoOrigen.Y + 240) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 264, puntoOrigen.X + 741, puntoOrigen.Y + 264) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 288, puntoOrigen.X + 741, puntoOrigen.Y + 288) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 312, puntoOrigen.X + 741, puntoOrigen.Y + 312) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 336, puntoOrigen.X + 741, puntoOrigen.Y + 336) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 360, puntoOrigen.X + 741, puntoOrigen.Y + 360) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 384, puntoOrigen.X + 741, puntoOrigen.Y + 384) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 408, puntoOrigen.X + 741, puntoOrigen.Y + 408) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 432, puntoOrigen.X + 741, puntoOrigen.Y + 432) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 456, puntoOrigen.X + 741, puntoOrigen.Y + 456) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 480, puntoOrigen.X + 741, puntoOrigen.Y + 480) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 504, puntoOrigen.X + 741, puntoOrigen.Y + 504) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 528, puntoOrigen.X + 741, puntoOrigen.Y + 528) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 552, puntoOrigen.X + 741, puntoOrigen.Y + 552) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 576, puntoOrigen.X + 741, puntoOrigen.Y + 576) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 600, puntoOrigen.X + 741, puntoOrigen.Y + 600) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 624, puntoOrigen.X + 741, puntoOrigen.Y + 624) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 648, puntoOrigen.X + 741, puntoOrigen.Y + 648) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 672, puntoOrigen.X + 741, puntoOrigen.Y + 672) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 696, puntoOrigen.X + 741, puntoOrigen.Y + 696) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 720, puntoOrigen.X + 741, puntoOrigen.Y + 720) 'Horizontal 
        e.Graphics.DrawString("Convenciones:", Formato_Etiqueta_9, Brocha, puntoOrigen.X, puntoOrigen.Y + 725)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 123, puntoOrigen.Y + 720, puntoOrigen.X + 123, puntoOrigen.Y + 744) 'Vertical
        e.Graphics.DrawString("(1) Indicar la labor a realizar, la cual debe ser especifica y medible.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 123, puntoOrigen.Y + 725)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 744, puntoOrigen.X + 741, puntoOrigen.Y + 744) 'Horizontal
        e.Graphics.DrawString("(2) El cargo debe corresponder al de escala de salarios. Si", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 749)
        e.Graphics.DrawString("el cargo no existe adjuntar la descripción del cargo.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 762)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 360, puntoOrigen.Y + 744, puntoOrigen.X + 360, puntoOrigen.Y + 783) 'Vertical
        e.Graphics.DrawString("(3) L.C.: Labor Contratada -T.F.: Término Fijo (Indicar número", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 360, puntoOrigen.Y + 749)
        e.Graphics.DrawString("de días)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 360, puntoOrigen.Y + 762)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 783, puntoOrigen.X + 741, puntoOrigen.Y + 783) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 787, puntoOrigen.X + 741, puntoOrigen.Y + 787) 'Horizontal
        e.Graphics.DrawString("Observaciones:", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 792)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 123, puntoOrigen.Y + 787, puntoOrigen.X + 123, puntoOrigen.Y + 808) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 808, puntoOrigen.X + 741, puntoOrigen.Y + 808) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 829, puntoOrigen.X + 741, puntoOrigen.Y + 829) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 850, puntoOrigen.X + 741, puntoOrigen.Y + 850) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 871, puntoOrigen.X + 741, puntoOrigen.Y + 871) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 123, puntoOrigen.Y + 871, puntoOrigen.X + 123, puntoOrigen.Y + 977) 'Vertical
        e.Graphics.DrawString("SOLICITANTE", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 144, puntoOrigen.Y + 874)
        e.Graphics.DrawString("(Jefe de Frente /", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 143, puntoOrigen.Y + 891)
        e.Graphics.DrawString("Capataz / Supervisor)", Formato_Etiqueta_9, Brocha, puntoOrigen.X + 131, puntoOrigen.Y + 904)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 268, puntoOrigen.Y + 871, puntoOrigen.X + 268, puntoOrigen.Y + 977) 'Vertical
        e.Graphics.DrawString("DIRECTOR DE OBRA / INGENIERO", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 293, puntoOrigen.Y + 881)
        e.Graphics.DrawString("RESIDENTE", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 368, puntoOrigen.Y + 896)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 545, puntoOrigen.Y + 871, puntoOrigen.X + 545, puntoOrigen.Y + 977) 'Vertical
        e.Graphics.DrawString("ADMINISTRADOR", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 580, puntoOrigen.Y + 886)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 919, puntoOrigen.X + 741, puntoOrigen.Y + 919) 'Horizontal
        e.Graphics.DrawString("Firma", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 938)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 954, puntoOrigen.X + 741, puntoOrigen.Y + 954) 'Horizontal
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_10, Brocha, puntoOrigen.X, puntoOrigen.Y + 960)
    End Sub
#End Region

#Region " 7 - ICA GRAL-F-044 SELECCIÓN DE SISTEMAS DE PENSIÓN Y SALUD"
    Private WithEvents DocImp_ICAGRALF44 As New PrintDocument

    Private Sub DocImpr_ICAGRALF44(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF44.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        '*******************************************************************ENCABEZADO*******************************************************
        Dim puntoOrigen As New Point(40, 40) '(10, 80)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 765, 1010)
        e.Graphics.DrawStringAligned("SELECCIÓN DE ADMINISTRADORA EN LOS", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 30)
        e.Graphics.DrawStringAligned("SISTEMAS DE PENSIÓN Y SALUD", HorizontalAlignment.Center, Formato_Etiqueta_12, Brocha, 445, puntoOrigen.X + 155, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ICA GRAL-F-044", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 640, puntoOrigen.Y + 15)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_10, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 65)
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 135, puntoOrigen.Y, puntoOrigen.X + 135, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 17, 85, 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y, puntoOrigen.X + 633, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 633, puntoOrigen.Y + 50, puntoOrigen.X + 765, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 765, puntoOrigen.Y + 100) 'Horizontal completa
        '**************************************************************************************************************************************

        Dim puntorec1 As New Point(660, 30)
        '*******************************************************************
        puntorec1.X = 200
        puntorec1.Y = 80
        '*******************************************************************
        puntoOrigen.Y = 180
        puntoOrigen.X = 80
        e.Graphics.DrawString("Ciudad y Fecha:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.X = puntoOrigen.X + 110
        If Not IsNothing(_filaContrato) Then
            e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_10RS, Brocha, puntoOrigen) 'Date.Now.ToLongDateString
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOBASE") & ", " & Date.Today.ToLongDateString, Formato_Etiqueta_10RS, Brocha, puntoOrigen) 'Date.Now.ToLongDateString
        End If

        puntoOrigen.X = 80
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("Señores", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_10, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("Ciudad", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        Dim Tab As Integer = 30
        e.Graphics.DrawString("Yo, identificado con el nombre  y cédula, como aparecen al pie  de   mi firma, en  forma libre, espontánea y ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("sin presiones, me permito indicar las entidades del Sistema de Seguridad Social a las cuales me encuentro ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("afiliado: ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        e.Graphics.DrawString("a)", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.X = puntoOrigen.X + Tab
        e.Graphics.DrawString("En el Sistema de Pensiones", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Administradora de Pensiones (A.F.P.): __________________________________________, a  la  cual ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("solicito consignar  los  aportes  por concepto de pensión, como prueba adjunto certificado  de  afiliación ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("a ésta entidad con expedición inferior a treinta (30) días. ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = puntoOrigen.X - Tab
        e.Graphics.DrawString("b)", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.X = puntoOrigen.X + Tab
        e.Graphics.DrawString("Seguro de Vida:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Les  informo   que   en   los  últimos  tres (3) años  he  cotizado  al  sistema   de  seguridad   social  en  ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("pensiones __________________  semanas.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = puntoOrigen.X - Tab
        e.Graphics.DrawString("c)", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.X = puntoOrigen.X + Tab
        e.Graphics.DrawString("En el Sistema de Salud:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("Entidad Promotora de Salud (E.P.S.): __________________________________________, a  la  cual ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("solicito  gestionar  la  afiliación,  así  como  la  consignación  de  los  aportes  por  concepto  de  salud, ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("como  prueba  adjunto  certificado  de  afiliación  a  ésta  entidad  con  expedición  inferior   a   treinta ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("(30) días.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 40
        puntoOrigen.X = puntoOrigen.X - Tab
        e.Graphics.DrawString("Manifiesto  que  he  sido informado sobre el derecho de afiliar  a  mi núcleo familiar a la  Entidad promotora ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("de  salud  (EPS),   así  como   a    la    caja    de   compensación.  (C.C.F.)  indicada   por   la    Compañía.", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50
        e.Graphics.DrawString("Cordialmente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        puntoOrigen.Y = puntoOrigen.Y + 50


     
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
        puntoOrigen.Y += 30
        e.Graphics.DrawString("Cédula: ", Formato_Etiqueta_10R, Brocha, puntoOrigen)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " de " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_10, Brocha, puntoOrigen.X + 160, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 160, puntoOrigen.Y + 15, puntoOrigen.X + 490, puntoOrigen.Y + 15)
      

    End Sub
#End Region

#Region " 35 - ICA GRAL-F-069 PROGRAMA DE INDUCCIÓN PERSONALIZADO PERSONAL MENSUALIZADO"
    Private WithEvents DocImp_ICAGRALF69 As New PrintDocument


    Private Function TrabajadorNuevoTunja() As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("select count(IDCONTRATO) from contrato where ESTADOCONTRATO='T' and IDPERSONA = @IDPERSONA", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", Idpersona)
        Dim esNuevo As Boolean
        Try
            comando.Connection.Open()
            esNuevo = comando.ExecuteScalar()
            comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Connection.Close()
        End Try
        If esNuevo = True Then
            Return True
        End If
        Return False
    End Function

    Private Sub DocImpr_ICAGRALF69(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF69.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(45, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1015)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-069", Formato_Etiqueta_8, Brocha, 687, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_8, Brocha, 687, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered(" PROGRAMA DE INDUCCIÓN ", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20

        Dim puntorec1 As New Point(660, 30)

        '*******************************************************************
        puntorec1.X = 200
        puntorec1.Y = 80
        puntoOrigen.Y = 110
        e.Graphics.DrawString("NOMBRE DEL TRABAJADOR:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawString("" & _filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_12, Brocha, puntoOrigen.X + 660, puntoOrigen.Y-3)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 190, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("FECHA DE INGRESO:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y)
        e.Graphics.DrawString("DEPENDENCIA:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 28
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                Exit Select
            Case Is <= 48
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y + 3)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(dependencia, 1, 48), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y - 2)
                e.Graphics.DrawString(Mid(dependencia, 49, 48), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y + 8)
        End Select
        puntoOrigen.Y = puntoOrigen.Y + 18
        e.Graphics.DrawString("TRABAJADOR NUEVO EN LA EMPRESA: SI           NO", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 270, puntoOrigen.Y, 20, 15)
        e.Graphics.DrawString(IIf(TrabajadorNuevoTunja() = False, "X", ""), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 273, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 330, puntoOrigen.Y, 20, 15)
        e.Graphics.DrawString(IIf(TrabajadorNuevoTunja() = True, "X", ""), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 333, puntoOrigen.Y)
        e.Graphics.DrawString("CARGO:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        If cargo.Length > 36 Then
            If cargo.Length > 43 Then
                e.Graphics.DrawString(Mid(cargo, 1, 43), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y - 5)
                e.Graphics.DrawString(Mid(cargo, 44, cargo.Length - 43), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y + 10)
            Else
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y + 2)
            End If
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 20
        For j = 0 To 2
            e.Graphics.DrawLine(Lapiz, 50, puntoOrigen.Y, puntoOrigen.X + 748, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 3
            e.Graphics.DrawString("ACTIVIDAD " + (j + 1).ToString, Formato_Etiqueta_9, Brocha, puntoOrigen.X + 310, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 15
            e.Graphics.DrawLine(Lapiz, 50, puntoOrigen.Y, puntoOrigen.X + 748, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 5
            e.Graphics.DrawString("DEPENDENCIA: _________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EXPOSITOR: ___________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 350, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawString("FECHA: ________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("DURACIÓN: ______________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 170, puntoOrigen.Y)
            e.Graphics.DrawString("LUGAR: _______________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 350, puntoOrigen.Y)
            Select Case j
                Case 0
                    e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    If _filaContrato("IDBASESISCONTROL") = 122 Then
                        e.Graphics.DrawString(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    Else
                        e.Graphics.DrawString(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    End If
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("2 Horas", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add(" TEMAS: INDUCCIÓN ADMINISTRATIVA: MISIÓN Y VISIÓN DE LA COMPAÑÍA, REGLAMENTO DE TRABAJO; DERECHOS Y DEBERES DEL SISTEMA GENERAL DE SEGURIDAD SOCIAL Y RIESGO LABORALES ; SALARIOS; JORNADA LABORAL; HORARIO DE TRABAJO; PAGO DE NÓMINA; PERMISOS; DEBERES, DERECHOS; OBLIGACIONES Y PROHIBICIONES; DIVULGACIÓN POLÍTICAS CORPORATIVAS; VALORES CORPORATIVOS; DIVULGACIÓN CÓDIGO DE ÉTICA; DIVULGACIÓN DE DERECHOS HUMANOS; COMITÉ PARITARIO EN SEGURIDAD Y SALUD EN EL TRABAJO - COPASST; COMITÉ DE CONVIVENCIA LABORAL: ACOSO LABORAL; ACUERDOS CON LAS COMUNIDADES; GRUPOS DE INTERÉS; SEGURIDAD VIAL Y SEGURIDAD FÍSICA; COMUNICACIONES INTERNAS Y EXTERNAS DE LA COMPAÑÍA; COMPETENCIAS DE TODOS LOS EMPLEADOS; DIVULGACIÓN PROGRAMA DE PQRS; PROCESO DISCIPLINARIO; ESCALA DE FALTAS; MANUAL INTERNO DE POLÍTICAS Y PROCEDIMIENTOS PARA EL SISTEMA DE AUTOCONTROL Y GESTIÓN DEL RIESGO INTEGRAL LA/FT/FPADM - SAGRILAFT; ENTREGA DE FOLLETOS.")
                    Dim Cadena_Total As New ArrayList


                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 750.2627, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_6R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_6RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2 - 2
                    Next
                    e.Graphics.DrawLine(Lapiz, 50, puntoOrigen.Y - 20, puntoOrigen.X + 748, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
                Case 1
                    e.Graphics.DrawString("HSE", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaBaseConfiguracion("COORDINADORHSE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("4 Horas", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add(" TEMAS:  INDUCCIÓN SSTA: 1. VIDEO CORPORATIVO / 2. MISIÓN – VISIÓN / 3. VALORES CORPORATIVOS / 4. REPRESENTANTE SG SSTA / 5. CERTIFICADOS SISTEMAS DE GESTIÓN SSTA / 6. POLÍTICAS CORPORATIVAS (SSTA, NO CONSUMO DE SUSTANCIAS PSICOACTIVAS Y ALCOHOL, NO CONSUMO DE TABACO Y CIGARRILLO, CONTROL Y SEGUIMIENTO DE LA SEGURIDAD VIAL, PREVENTIVA DE ACOSO LABORAL) / 7. OBJETIVOS Y METAS SSTA / 8. CIRCULARES NORMATIVAS E INFORMATIVAS DE SSTA / 9. ASPECTOS LEGALES SG-SSTA – REGLAMENTO HIGIENE Y SEGURIDAD – REGLAMENTO DE TRABAJO / 10. FUNCIONAMIENTO COPASST / 11. FUNCIONAMIENTO COMITÉ DE CONVIVENCIA LABORAL / 12. FACTORES DE RIESGOS – FÍSICOS - QUÍMICOS – BIOLÓGICOS – BIOMECÁNICOS – CONDICIONES DE SEGURIDAD (MECÁNICOS - ELÉCTRICOS - LOCATIVOS - TECNOLÓGICO - VIAL - PÚBLICO - TRABAJO EN ALTURA Y ESPACIO CONFINADO) - PSICOSOCIAL Y FENÓMENOS NATURALES (SISMO - TERREMOTO - VENDAVAL - INUNDACIÓN - DERRUMBE - PRECIPITACIONES) Y SUS CONTROLES (ACTIVIDADES DE ALTO RIESGO, RUTINARIAS Y NO RUTINARIAS) / 13. REQUISITOS PARA INICIAR UNA ACTIVIDAD (ANÁLISIS DE RIESGO EN EL TRABAJO - PROCEDIMIENTO SEGURO DE TRABAJO - PERMISO DE TRABAJO - CERTIFICADOS DE APOYO) / 14. AUTORIDAD PARA DETENER LOS TRABAJOS INSEGUROS / 15 ELEMENTOS DE PROTECCIÓN PERSONAL / 16. INSPECCIÓN DE MAQUINARIA, EQUIPOS Y HERRAMIENTAS / 17. OBSERVACIÓN DE TAREAS (REPORTE DE ACTOS Y CONDICIONES INSEGURAS) / 18. PROTOCOLO DE BIOSEGURIDAD Y MEDIDAS PREVENTIVAS PARA EVITAR CONTAGIO DE COVID-19. / 19. ASPECTOS E IMPACTOS AMBIENTALES / 20. MANEJO DE RESIDUOS SÓLIDOS / 21. MANEJO DE RESIDUOS LÍQUIDOS / 22. USO EFICIENTE DE AGUA Y ENERGÍA / 23. FAUNA Y FLORA EN ÁREAS DE TRABAJO / 24. PLAN DE EMERGENCIAS (RUTA DE EVACUACIÓN - PUNTO DE ENCUENTRO – MEDEVAC) / 25. REPORTE DE INCIDENTES Y EMERGENCIAS / 26. ROLES Y RESPONSABILIDADES EN SSTA / 27. OBLIGACIONES SST DEL EMPLEADOR / TRABAJADOR / 28. MEDIOS DE COMUNICACIÓN, PARTICIPACIÓN Y CONSULTA / 29. GESTIÓN DOCUMENTAL (PLATAFORMA SYNERGY) / 30. CONTRIBUCIÓN A LA EFICACIA DEL SG SSTA.")
                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 750.2627, e)
                    Dim i As Integer
                    For i = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_6R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_6RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2 - 2
                    Next
                    e.Graphics.DrawLine(Lapiz, 50, puntoOrigen.Y - 20, puntoOrigen.X + 748, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
                Case 2
                    e.Graphics.DrawString("CALIDAD", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaBaseConfiguracion("COORDINADORQAQC"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("2 Horas", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add("TEMAS: PRESENTACIÓN DE LA COMPAÑÍA; CERTIFICACIONES; POLÍTICA DE CALIDAD; ALCANCE DEL CONTRATO; SISTEMA DE GESTIÓN DE CALIDAD EN OBRA (PLAN DE CALIDAD, OBJETIVOS DE CALIDAD, PLAN DE INSPECCIÓN Y ENSAYO), PLANEACIÓN DE LAS ACTIVIDADES CONSTRUCTIVAS ORGANIGRAMA; EQUIPOS DE SEGUIMIENTO Y MEDICIÓN; CONSULTA TÉCNICA; AUDITORIAS; TRATAMIENTO PRODUCTO NO CONFORME; NO CONFORMIDADES; ACCIONES PREVENTIVAS Y CORRECTIVAS; BITÁCORA DE OBRA; REQUISITOS DEL CLIENTE; INFORMACIÓN DOCUMENTADA (ICQ-GRAL-P-01); OBJETIVOS CORPORATIVOS; PLATAFORMA SYNERGY; APLICACIÓN DEL PROCEDIMIENTO DE GESTION DEL CAMBIO ICQ-GRAL-P-02.")
                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 750.2627, e)
                    Dim i As Integer
                    For i = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_6R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_6RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2 - 2
                    Next
                    e.Graphics.DrawLine(Lapiz, 50, puntoOrigen.Y - 20, puntoOrigen.X + 748, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
            End Select
        Next
        e.Graphics.DrawLine(Lapiz, 50, puntoOrigen.Y, puntoOrigen.X + 748, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 5
        e.Graphics.DrawString("Manifiesto que he recibido y entendido en todo su alcance los temas tratados y me comprometo a cumplir con el procedimiento", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 15
        e.Graphics.DrawString(" o contenido de los temas y responsabilidades asignadas. En constancia, firmo.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("FIRMA DEL TRABAJADOR: ____________________________________    C.C. No. _____________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        'e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y + 15)
    End Sub
#End Region

#Region " 37 - ICA GRAL-F-014 REGISTRO DE EMPLEADOS NUEVOS Y NOVEDADES"
    Private WithEvents DocImp_ICAGRALF14 As New PrintDocument
    Property inicialF14 As String = "X"
    Property modificaciónF14 As String = ""

    Private Sub DocImpr_ICAGRALF14(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF14.PrintPage
        Dim _filaAuxilioAlimentacionICAGRALF14 As DataRow
        Dim _filaAuxilioTransporteICAGRALF14 As DataRow
        Dim _filaAuxilioSinIncidenciaSalarialICAGRALF14 As DataRow
        Dim _filaBonoTecnicoICAGRALF14 As DataRow
        Dim resultados() As DataRow
        Dim valorAuxilioAlimentacion As String = ""
         Dim valorAuxilioUsoHerramienta As String = ""
        Dim valorAuxilioTransporte As String = ""
        Dim valorAuxilioSinIncidenciaSalarial As String = ""
        Dim valorBonoTecnico As String = ""
        Dim periodicidadAlimentacion As String = ""
        Dim periodicidadTransporte As String = ""
        Dim periodicidadSinIncidenciaSalarial As String = ""
        Dim periodicidadTecnico As String = ""
        Dim periodicidadAuxilioUsoHerramienta As String = ""
        Dim bonoxmantenimiento As String = ""
        Dim periodicidadbonoxmantenimiento As String = ""
        'Consultar conceptos
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (10,164)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionICAGRALF14 = resultados(0)
            valorAuxilioAlimentacion = FormatCurrency(_filaAuxilioAlimentacionICAGRALF14("VALOR"), 2)
            periodicidadAlimentacion = _filaAuxilioAlimentacionICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (12,165)")
        If resultados.Length > 0 Then
            _filaAuxilioTransporteICAGRALF14 = resultados(0)
            valorAuxilioTransporte = FormatCurrency(_filaAuxilioTransporteICAGRALF14("VALOR"), 2)
            periodicidadTransporte = _filaAuxilioTransporteICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 14")
        If resultados.Length > 0 Then
            _filaAuxilioSinIncidenciaSalarialICAGRALF14 = resultados(0)
            valorAuxilioSinIncidenciaSalarial = FormatCurrency(_filaAuxilioSinIncidenciaSalarialICAGRALF14("VALOR"), 2)
            periodicidadSinIncidenciaSalarial = _filaAuxilioSinIncidenciaSalarialICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 105")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorBonoTecnico = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadTecnico = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorAuxilioUsoHerramienta = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadAuxilioUsoHerramienta = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 175")
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 113")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            bonoxmantenimiento = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadbonoxmantenimiento = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If

        Const InicioLineaX As Integer = 10
        Const espaciointerlineado As Integer = 15
        Const altorectangulo As Integer = 15
        Const lonrectangulo1 As Integer = 185
        Const lonrectangulo2 As Integer = 135
        Dim telefonos As String = ""
        Dim TerminoInicial As String = ""
        Dim Cuerpo As String = ""
        Dim nombreARL As String = ""
        Dim Vencimiento As Date
        Dim CadenasLabor As New ArrayList
        Dim CadenasLaborTotal As New ArrayList
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim puntoOrigen As New Point(10, 36)
        Dim puntorecfinal As New Point(puntoOrigen)
        Dim brocharellenoverde As New SolidBrush(Color.FromArgb(204, 255, 204))
        Dim brocharellenoazul As New SolidBrush(Color.FromArgb(204, 255, 255))

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 15, puntoOrigen.Y + 8, 100, 80)
        e.Graphics.DrawString("REGISTRO DE EMPLEADOS NUEVOS Y NOVEDADES", Formato_Etiqueta_12, Brocha, 170, 68)
        e.Graphics.DrawString("SECCIÓN NÓMINA", Formato_Etiqueta_12, Brocha, 320, 87)
        e.Graphics.DrawString("ICA-GRAL-F-014", Formato_Etiqueta_8, Brocha, 684, 56)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_8, Brocha, 690, 102)
        e.Graphics.DrawLine(Lapiz, InicioLineaX + 125, puntoOrigen.Y, 135, 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, 662, puntoOrigen.Y, 662, 130) 'Vertical
        e.Graphics.DrawLine(Lapiz, 662, 85, InicioLineaX + 785, 85) 'Horizontal
        e.Graphics.DrawLine(Lapiz, InicioLineaX, 130, puntoOrigen.X + 785, 130) 'Horizontal completa
        puntoOrigen.Y = 135
        puntoOrigen.X = 10

        e.Graphics.DrawString("INICIAL", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 113, puntoOrigen.Y, 12, 12)
        e.Graphics.DrawString(inicialF14, Formato_Etiqueta_9, Brocha, puntoOrigen.X + 113, puntoOrigen.Y - 1)
        e.Graphics.DrawString("CODIGO", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 610, puntoOrigen.Y + 16)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 652, puntoOrigen.Y + 12, 133, 17)
        e.Graphics.DrawStringCentered(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10, Brocha, 133, puntoOrigen.X + 654, puntoOrigen.Y + 14)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("MODIFICACION", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 113, puntoOrigen.Y, 12, 12)
        e.Graphics.DrawString(modificaciónF14, Formato_Etiqueta_9, Brocha, puntoOrigen.X + 113, puntoOrigen.Y - 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("CONTRATO U OBRA:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 190, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 295, puntoOrigen.Y + 15, puntoOrigen.X + 545, puntoOrigen.Y + 15) 'Horizontal completa
        e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " - " & _filaContrato("NOMBREBASECONTRATADO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 295, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado + 5
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoverde, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("INFORMACION PERSONAL", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("INFORMACION PERSONAL", Formato_Etiqueta_10, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        Dim Xcol1 As Integer = puntoOrigen.X
        Dim Xcol2 As Integer = puntoOrigen.X + 230
        Dim Xcol3 As Integer = puntoOrigen.X + 428
        Dim Xcol4 As Integer = puntoOrigen.X + 650
        e.Graphics.DrawString("Cédula No.:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Lugar Expedición:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Apellidos:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaPersona("APELLIDOS"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Fecha Nacimiento:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(DirectCast(_filaPersona("FECHANACIMIENTO"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nombres:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString(_filaPersona("NOMBRES"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Lugar Nacimiento:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Estado Civil", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Soltero / Casado / Unión Libre / Viudo)", Formato_Etiqueta_5, Brocha, Xcol1 + 65, puntoOrigen.Y)
        e.Graphics.DrawString(_filaPersona("NOMBRETIPOESTADOCIVIL"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Sexo (M / F)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaPersona("GENERO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nombre de Cónyuge", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        If Not IsDBNull(_filaPersona("NOMBRECOMPLETOCONYUGE")) Then
            If e.Graphics.MeasureString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
            End If
        End If
        e.Graphics.DrawString("Cédula Cónyuge", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaPersona("IDENTIFICACIONCONYUGE")) Then
            e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACIONCONYUGE")), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Licencia Conducción", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) Then
            If MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
            End If
        End If
        e.Graphics.DrawString("Libreta Militar", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) Then
            If MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Categoría", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        If Not IsDBNull(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
            If MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
            End If
        End If
        e.Graphics.DrawString("Distrito", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
            If MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Educación", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Prim. / Medios / Técn. / Univers. / Postgrados)", Formato_Etiqueta_5, Brocha, Xcol1 + 60, puntoOrigen.Y)
        If Not IsDBNull(_filaPersona("NOMBRENIVELEDUCATIVO")) Then
            e.Graphics.DrawString(_filaPersona("NOMBRENIVELEDUCATIVO"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Profesión", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("NOMBRETIPOPROFESION")) Then
            e.Graphics.DrawString(_filaPersona("NOMBRETIPOPROFESION"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Ciudad de Residencia Permanente", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        If e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Teléfono de Residencia Permanente", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaPersona("TELEFONO")) Then
            telefonos = _filaPersona("TELEFONO")
        End If
        If telefonos = "" Then
            telefonos = _filaPersona("TELEFONOMOVIL")
        Else
            telefonos = telefonos & "-" & _filaPersona("TELEFONOMOVIL")
        End If
        e.Graphics.DrawString(telefonos, Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Dirección de Residencia Permanente", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("DIRECCION")) Then
            e.Graphics.DrawString(_filaPersona("DIRECCION"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado + 5
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Seguridad Social", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Seguridad Social", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("EPS - Salud", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Fecha Afiliación:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaContrato("FECHAAFILIACIONEPS")) Then
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHAAFILIACIONEPS"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("AFP - Pensión", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Fecha Afiliación:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaContrato("FECHAAFILIACIONAFP")) Then
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHAAFILIACIONAFP"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Fondo de Cesantías", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1 - 40, altorectangulo)
        If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Fecha Afiliación:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaContrato("FECHAAFILIACIONAFC")) Then
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHAAFILIACIONAFC"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Valor UPC (Aporte Voluntario Salud)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("se pagaran en la EPS a la cual este afiliado el empleado", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Valor Aporte Voluntario Pensión", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString("Nombre Fondo Pensiones Voluntarias", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
            End If
        End If

        puntoOrigen.Y += espaciointerlineado + 3
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Deducciones Retención en la Fuente", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Deducciones Retención en la Fuente", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("Concepto de la Deducción:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Vivie. / Educ. / Salud)", Formato_Etiqueta_5, Brocha, Xcol1 + 140, puntoOrigen.Y - 1)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString("Valor de la Deducción:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Si suministra información en este modulo, se debe adjuntar solicitud del trabajador acompañada de la certificación expedida por la entidad beneficiaria del pago", Formato_Etiqueta_6R, Brocha, InicioCentradoTexto("Si suministra información en este modulo, se debe adjuntar solicitud del trabajador acompañada de la certificación expedida por la entidad beneficiaria del pago", Formato_Etiqueta_7R, InicioLineaX + 850, e), puntoOrigen.Y + 3)

        puntoOrigen.Y += espaciointerlineado
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoverde, InicioLineaX + 1, puntoOrigen.Y + 1, 785, 16)
        e.Graphics.DrawString("INFORMACION LABORAL", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("INFORMACION LABORAL", Formato_Etiqueta_7R, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Vinculación Laboral", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 150, puntoOrigen.Y + 1)
        e.Graphics.DrawString("Forma de Pago", Formato_Etiqueta_8, Brocha, Xcol3 + 100, puntoOrigen.Y + 1)
        e.Graphics.DrawLine(Lapiz, Xcol3, puntoOrigen.Y, Xcol3, puntoOrigen.Y + espaciointerlineado * 5 + 3)
        e.Graphics.DrawLine(Lapiz, Xcol3, puntoOrigen.Y + espaciointerlineado * 5 + 3, InicioLineaX + 785, puntoOrigen.Y + espaciointerlineado * 5 + 3) 'Horizontal completa

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 8
        e.Graphics.DrawString("Frente de Trabajo (O.T.)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If e.Graphics.MeasureString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_8).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("FRENTETRABAJO"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Cheque o Abono en cuenta", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOPAGO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Cargo del Escalafón o Tabla Salarial", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 3, lonrectangulo1, altorectangulo)
        If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Banco", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 3, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaContrato("NOMBREENTIDADFINANCIERA")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_8).Width <= lonrectangulo2 Then
                e.Graphics.DrawString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
                e.Graphics.DrawString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 1)
            End If
        End If
        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Fecha de Ingreso", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(DirectCast(_filaContrato("FECHAINGRESO"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Numero de Cuenta", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaContrato("NUMEROCUENTA")) Then
            e.Graphics.DrawString(_filaContrato("NUMEROCUENTA"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If
        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Sueldo Básico", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 3, lonrectangulo1, altorectangulo)
        If _filaContrato("TIPODURACION") <> "M" Then
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        Else
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula((_filaContrato("SALARIO") * 30)), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Tipo de Cuenta (Ahorros / Corriente)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 3, lonrectangulo2, altorectangulo - 2)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOCUENTA"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Tipo Salario (Diario / Mensual / Integral)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If _filaContrato("CODIGOTIPOSALARIO") = "M" Then
            e.Graphics.DrawString("Mensual", Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        Else
            e.Graphics.DrawString("Diario", Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Suministro de Campamento (Si o No)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(If(_filaContrato("SUMINISTROCAMPAMENTO") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Jornada de Trabajo (Completa / Media)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaContrato("TIPOJORNADA"), Formato_Etiqueta_8, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 3, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString("Completa", Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Suministro de Transporte (Si o No)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 3, lonrectangulo2, altorectangulo)
        e.Graphics.DrawString(If(_filaContrato("SUMINISTROTRANSPORTE") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Clase de Pago (Quincenal / Mensual)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Otros Pagos o Emolumentos", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Otros Pagos o Emolumentos", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.DrawString("Auxilios Extralegales o Convencionales", Formato_Etiqueta_8, Brocha, Xcol1, puntoOrigen.Y + 2)
        e.Graphics.DrawString("Bonificaciones Extralegales", Formato_Etiqueta_8, Brocha, Xcol3, puntoOrigen.Y + 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.FillRectangle(brocharellenoverde, Xcol1, puntoOrigen.Y + 2, lonrectangulo1 + 220, altorectangulo)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol3 - 2, puntoOrigen.Y + 2, lonrectangulo2 + 225, altorectangulo)
        If valorAuxilioAlimentacion <> "" Then
            e.Graphics.DrawString("Auxilio de Alimentación:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioAlimentacion & "  " & periodicidadAlimentacion, Formato_Etiqueta_8R, Brocha, Xcol2, puntoOrigen.Y + 4)
        End If
        If valorBonoTecnico <> "" Then
            e.Graphics.DrawString("Bono Técnico:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorBonoTecnico & "  " & periodicidadTecnico, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If
        puntoOrigen.Y += espaciointerlineado
        If valorAuxilioTransporte <> "" Then
            e.Graphics.DrawString("Auxilio de Transporte:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioTransporte & "  " & periodicidadTransporte, Formato_Etiqueta_8R, Brocha, Xcol2, puntoOrigen.Y + 4)
        End If
        puntoOrigen.Y += espaciointerlineado
        e.Graphics.FillRectangle(brocharellenoverde, Xcol1, puntoOrigen.Y + 2, lonrectangulo1 + 220, altorectangulo)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol3 - 2, puntoOrigen.Y + 2, lonrectangulo2 + 225, altorectangulo)
        If valorAuxilioSinIncidenciaSalarial <> "" Then
            e.Graphics.DrawString("Auxilio sin incidencia salarial:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioSinIncidenciaSalarial & "  " & periodicidadSinIncidenciaSalarial, Formato_Etiqueta_8R, Brocha, Xcol2, puntoOrigen.Y + 4)
        End If
        If valorAuxilioUsoHerramienta <> "" Then
            e.Graphics.DrawString("Auxilio Uso Herramienta: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioUsoHerramienta & "  " & periodicidadAuxilioUsoHerramienta, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If
        If bonoxmantenimiento <> "" Then
            e.Graphics.DrawString("Bono Mantenimiento Equipo: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(bonoxmantenimiento & "  " & periodicidadbonoxmantenimiento, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Especificar si los valores son mensuales o diarios", Formato_Etiqueta_6R, Brocha, InicioCentradoTexto("Especificar si los valores son mensuales o diarios", Formato_Etiqueta_7, InicioLineaX + 800, e), puntoOrigen.Y + 10)
        '*************************************************************************************
        puntoOrigen.Y += espaciointerlineado + 6
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Contrato de Trabajo", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Contrato de Trabajo", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("Tipo (Indefinido / Término Fijo / Obra)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        Select Case _filaContrato("CODIGOTIPOCONTRATO")
            Case 1, 2, 3, 4, 5 'Término fijo
                e.Graphics.DrawString("Término Fijo", Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
            Case 6, 7, 8, 9, 10 'Obra o labor
                e.Graphics.DrawString("Obra", Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
            Case 11, 12 'Término indefinido
                e.Graphics.DrawString("Indefinido", Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
            Case Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOCONTRATO"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y + 2)
        End Select
        e.Graphics.DrawString("Duración", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(para contratos a termino fijo)", Formato_Etiqueta_5, Brocha, Xcol3 + 50, puntoOrigen.Y)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If _filaContrato("DURACION") > 0 Then
            TerminoInicial = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
                Vencimiento = FunBase.Calcular_Fecha_terminación_Contrato(_filaContrato("FECHAINGRESO"), "M", _filaContrato("DURACION"))
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
                Vencimiento = FunBase.Calcular_Fecha_terminación_Contrato(_filaContrato("FECHAINGRESO"), "D", _filaContrato("DURACION"))
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Descripción de la obra", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Fecha Vencimiento", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(para contratos a T.F.)", Formato_Etiqueta_5, Brocha, Xcol3 + 100, puntoOrigen.Y)
        e.Graphics.FillRectangle(brocharellenoverde, InicioLineaX + 1, puntoOrigen.Y + 16, 785, espaciointerlineado - 3)
        If _filaContrato("DURACION") > 0 Then
            e.Graphics.DrawString(Vencimiento.ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
            puntoOrigen.Y += espaciointerlineado
        End If

        puntoOrigen.Y += espaciointerlineado
        CadenasLabor.Add(_filaContrato("LABORCONTRATADA"))
        CadenasLaborTotal = TextoAParrafoFuente(CadenasLabor, Formato_Etiqueta_5, 790, e)
        For j As Integer = 0 To CadenasLaborTotal.Count - 1
            e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_8R, 790, e), Formato_Etiqueta_5, Brocha, Xcol1, puntoOrigen.Y + 2)
            If j < CadenasLaborTotal.Count - 1 Then
                puntoOrigen.Y += espaciointerlineado
            End If
        Next

        puntoOrigen.Y += 4
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y - 4, InicioLineaX + 785, puntoOrigen.Y - 4) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Afiliaciones", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Afiliaciones", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("Sede Riesgo ARL No.", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 3, lonrectangulo1, altorectangulo)
        nombreARL = _filaContrato("NOMBRETIPOENTIDADADMINISTRADORAARL")
        If e.Graphics.MeasureString(nombreARL, Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(nombreARL, Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(nombreARL, Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(nombreARL, Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(nombreARL, Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Valor Cuotas o Aportes Sindicales", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Caja de Compensación", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Aporta al FIC (Si o No)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 3, lonrectangulo2, altorectangulo)
        e.Graphics.DrawString(If(_filaContrato("APORTAFIC") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("El empleado ha cotizado 50 semanas en los últimos tres años al sistema de seguridad social en pensiones (Si o No) ?", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(If(_filaContrato("COTIZO50SEMANASULTIMOAÑO") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Si no ha aportado 50 semanas cuantas le faltan ?", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2 + 120, puntoOrigen.Y - 3, lonrectangulo1 - 120, altorectangulo)
        If _filaContrato("COTIZO50SEMANASULTIMOAÑO") = "S" Then
            e.Graphics.DrawString("0", Formato_Etiqueta_8, Brocha, Xcol2 + 121, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("SEMANASFALTAN"), Formato_Etiqueta_8, Brocha, Xcol2 + 121, puntoOrigen.Y - 2)
        End If
        e.Graphics.DrawString("Requiere Colectivo de Vida (Si o No) ?", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 3, lonrectangulo2, altorectangulo)
        e.Graphics.DrawString(If(_filaContrato("REQUIERECOLECTIVOVIDA") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nota: Para trabajadores menores de 20 años, el numero de semanas cotizadas al sistema son 26.", Formato_Etiqueta_7R, Brocha, Xcol1, puntoOrigen.Y + 2)

        puntoOrigen.Y += espaciointerlineado
        'Líneas observaciones
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 16, InicioLineaX + 785, puntoOrigen.Y + 16) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 32, InicioLineaX + 785, puntoOrigen.Y + 32) 'Horizontal completa
        'Líneas firmas
        e.Graphics.DrawLine(Lapiz_Grueso, InicioLineaX, puntoOrigen.Y + 48, InicioLineaX + 785, puntoOrigen.Y + 48) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 63, InicioLineaX + 785, puntoOrigen.Y + 63) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 93, InicioLineaX + 785, puntoOrigen.Y + 93) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 196, puntoOrigen.Y + 48, puntoOrigen.X + 196, puntoOrigen.Y + 109) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 393, puntoOrigen.Y + 48, puntoOrigen.X + 393, puntoOrigen.Y + 109) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 589, puntoOrigen.Y + 48, puntoOrigen.X + 589, puntoOrigen.Y + 109) 'Vertical

        puntoOrigen.Y += espaciointerlineado
        puntoOrigen.Y = puntoOrigen.Y - 13

        Dim puntoobservación As Integer = puntoOrigen.Y + 3

        Dim observacion As String = Trim(_filaContrato("OBSERVACION"))
        Select Case observacion.Length
            Case Is < 100
                e.Graphics.DrawString("Observaciones: " + RTrim(LTrim(_filaPersona("EMAIL"))) + ", " + StrConv(_filaContrato("OBSERVACION"), VbStrConv.ProperCase), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoobservación)
                Exit Select
            Case Else
                Cuerpo = "Observaciones: " + RTrim(LTrim(_filaPersona("EMAIL"))) + ", " + StrConv(_filaContrato("OBSERVACION"), VbStrConv.ProperCase)
                Cadenas.Add(Cuerpo)
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 790, e)
                For i As Integer = 0 To Cadena_Total.Count - 1
                    e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 790, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoobservación)
                    puntoobservación += espaciointerlineado
                Next

                puntoobservación = puntoobservación - 2 * espaciointerlineado
        End Select


        e.Graphics.DrawRectangle(Lapiz_Grueso, puntorecfinal.X, puntorecfinal.Y, 785, puntoOrigen.Y + 70)

        puntoOrigen.Y += (espaciointerlineado * 2)
        e.Graphics.DrawStringCentered("Reportó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X, puntoOrigen.Y + 18)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X, puntoOrigen.Y + 50)
        e.Graphics.DrawStringCentered("Asistente de Personal", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X, puntoOrigen.Y + 63)

        e.Graphics.DrawStringCentered("Revisó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 18)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 50)
        e.Graphics.DrawStringCentered("Administrador", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 63)

        e.Graphics.DrawStringCentered("Autorizó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 18)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("RESIDENTE"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 50)
        e.Graphics.DrawStringCentered("Jefe Dpto. Admón. y Serv. Adtivo / Dir.Obra", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 63)

        e.Graphics.DrawStringCentered("Registro en Nómina", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 589, puntoOrigen.Y + 18)

    End Sub
#End Region

#Region " 38 - ICA GRAL-L-001 LISTA DE CHEQUEO PARA LA ORDENACIÓN DE HISTORIAS LABORALES"
    Private WithEvents DocImp_ICAGRALL1 As New PrintDocument
    Private Nueva_PaginaL001 As Integer = 1

    Private Sub DocImpr_ICAGRALL1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALL1.PrintPage
        Dim puntoOrigen As New Point(40, 50)
        e.Graphics.DrawString("LISTA DE CHEQUEO PARA LA ORDENACIÓN DE", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 172, puntoOrigen.Y + 33)
        e.Graphics.DrawString("HISTORIAS LABORALES", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 265, puntoOrigen.Y + 55)
        e.Graphics.DrawStringCentered("ICA-GRAL-L-001", Formato_Etiqueta_8, Brocha, 156, puntoOrigen.X + 584, puntoOrigen.Y + 20)
        e.Graphics.DrawStringCentered("Revisión No. 10", Formato_Etiqueta_8, Brocha, 156, puntoOrigen.X + 584, puntoOrigen.Y + 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 145, puntoOrigen.Y, puntoOrigen.X + 145, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 584, puntoOrigen.Y, puntoOrigen.X + 584, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 58, 65, 110, 80)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 584, puntoOrigen.Y + 50, puntoOrigen.X + 740, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 740, puntoOrigen.Y + 100) 'Horizontal completa
        Select Case (Nueva_PaginaL001)
            Case 1
                e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 740, 980)
                puntoOrigen.Y = puntoOrigen.Y + 100
                e.Graphics.DrawString("Las carpetas de cada trabajador debe contener el siguiente ordenamiento, según los documentos y trámite para su vinculación.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 7)
                e.Graphics.DrawString("Aquellos documentos adicionales que no se encuentren dentro de este listado se adjuntarán en otros soportes, teniendo en cuenta", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 22)
                e.Graphics.DrawString("su orden original.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 40)
                '***
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X + 150, puntoOrigen.Y + 63)
                e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8, Brocha, puntoOrigen.X + 550, puntoOrigen.Y + 63)

                e.Graphics.DrawString("APLICA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 675, puntoOrigen.Y + 63)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 673, puntoOrigen.Y + 58, puntoOrigen.X + 673, puntoOrigen.Y + 838) 'Vertical
                e.Graphics.DrawString("SI", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 678, puntoOrigen.Y + 83)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 698, puntoOrigen.Y + 78, puntoOrigen.X + 698, puntoOrigen.Y + 838) 'Vertical
                e.Graphics.DrawString("NO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 701, puntoOrigen.Y + 83)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 723, puntoOrigen.Y + 58, puntoOrigen.X + 723, puntoOrigen.Y + 838) 'Vertical
                '***
                puntoOrigen.Y = puntoOrigen.Y + 100
                puntoOrigen.X = puntoOrigen.X + 10
                e.Graphics.DrawString("1    Lista de chequeo para la ordenación de historias laborales (ICA-GRAL-L-001)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                e.Graphics.DrawString("2", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 20)
                e.Graphics.DrawString(" Documentos y Trámite para Vinculación de Nuevos Empleados (ICA-GRAL-F-068)", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 20)
                e.Graphics.DrawString("3    Requerimiento de personal", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 40)
                e.Graphics.DrawString("4    Contrato laboral", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 60)
                e.Graphics.DrawString("5    Carta de asignación de auxilios y/o bonos", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 80)
                e.Graphics.DrawString("6    Autorización Publicación de Vacante (ICA-GRAL-F-150)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 100)
                e.Graphics.DrawString("7    Registro de postulación de la oferta al Servicio Público de Empleo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 120)
                e.Graphics.DrawString("8    Certificado de inscripción del candidato al Servicio Público de Empleo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 140)
                e.Graphics.DrawString("9    Certificado de Residencia (personal local)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 160)
                e.Graphics.DrawString("10  Informe final de Selección. Para Procesos de selección y Contratación (ICA-GRAL-F-092)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 180)
                e.Graphics.DrawString("11  Evaluación de Competencias - Validación de Requisitos. Para Procesos de Selección y Contratación en", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 200)
                e.Graphics.DrawString(" Proyectos (ICA-GRAL-F-155 o el formato establecido en el Proyecto)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 220)
                e.Graphics.DrawString("12  Resumen del proceso descargado de plataforma Servicio Público de Empleo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 240)
                e.Graphics.DrawString("13  Certificado de Ausencia de perfil del Servicio Público de Empleo en caso de que aplique", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 260)
                e.Graphics.DrawString("14  Evidencia de postulación del candidato a la vacante", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 280)
                e.Graphics.DrawString("15  Evidencia de cierre de la Vacante", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 300)
                e.Graphics.DrawString("16  Hoja de vida", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 320)
                e.Graphics.DrawString("17  Fotocopia ampliada al 150% de la Cédula de Ciudadanía ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 340)
                e.Graphics.DrawString("18  Fotocopia ampliada al 150% de la Libreta Militar", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 360)
                e.Graphics.DrawString("19  Fotocopia ampliada al 150% de la Licencia Profesional", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 380)
                e.Graphics.DrawString("20  Fotocopia ampliada al 150% de la Licencia de conducción de acuerdo al vehiculo a operar (para conductores)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 400)
                e.Graphics.DrawString("21  Certificados de estudio", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 420)
                e.Graphics.DrawString("22  Certificados laborales", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 440)
                e.Graphics.DrawString("23  Referencias personales", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 460)
                e.Graphics.DrawString("24  Certificado de afiliación expedido por EPS y AFP", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 480)
                e.Graphics.DrawString("25  Certificado de Historia Laboral expedido por el Fondo de Pensiones", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 500)
                e.Graphics.DrawString("26  Certificado de la cuenta bancaria", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 520)
                e.Graphics.DrawString("27  ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 540)
                e.Graphics.DrawString("Certificado de Antecedentes Judiciales - Policía", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 540)
                e.Graphics.DrawString("28  ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 560)
                e.Graphics.DrawString("Certificado de Antecedentes Disciplinarios - Procuraduría", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 560)
                e.Graphics.DrawString("29  ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 580)
                e.Graphics.DrawString("Certificado de Antecedentes Fiscales - Contraloría", Formato_Etiqueta_9RSI, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 580)
                e.Graphics.DrawString("30  Consentimiento informado (ICH-GRAL-F-357)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 600)
                e.Graphics.DrawString("31  Orden de exámenes médicos de ingreso", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 620)
                e.Graphics.DrawString("32  Concepto médico de ingreso", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 640)
                e.Graphics.DrawString("33  Declaración de preexistencia de patología en caso de que aplique", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 660)
                e.Graphics.DrawString("34  Fotocopia del carnet de vacunación", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 680)
                e.Graphics.DrawString("35  Autorización para tratamiento de datos personales (ICA-GRAL-F-153)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 700)
                e.Graphics.DrawString("36  Registro de Datos Personales (ICA-GRAL-F-097)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 720)

                Dim conlineas As Integer
                For conlineas = 0 To 12
                    If puntoOrigen.Y < 1060 Then
                        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 663, puntoOrigen.Y - 42, puntoOrigen.X + 713, puntoOrigen.Y - 42) 'Horizontal
                        puntoOrigen.Y = puntoOrigen.Y + 20
                    Else
                        Exit For
                    End If
                Next
                Dim conlineas1 As Integer
                For conlineas1 = 0 To 25
                    If puntoOrigen.Y < 1060 Then
                        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 663, puntoOrigen.Y - 22, puntoOrigen.X + 713, puntoOrigen.Y - 22) 'Horizontal
                        puntoOrigen.Y = puntoOrigen.Y + 20
                    Else
                        Exit For
                    End If
                Next



            Case 2
                e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 740, 660)
                e.Graphics.DrawString("APLICA", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 675, puntoOrigen.Y + 124)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 673, puntoOrigen.Y + 119, puntoOrigen.X + 673, puntoOrigen.Y + 619) 'Vertical
                e.Graphics.DrawString("SI", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 678, puntoOrigen.Y + 144)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 698, puntoOrigen.Y + 139, puntoOrigen.X + 698, puntoOrigen.Y + 619) 'Vertical
                e.Graphics.DrawString("NO", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 701, puntoOrigen.Y + 144)
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 723, puntoOrigen.Y + 119, puntoOrigen.X + 723, puntoOrigen.Y + 619) 'Vertical
                '***
                puntoOrigen.Y = puntoOrigen.Y + 162
                puntoOrigen.X = puntoOrigen.X + 10
                e.Graphics.DrawString("37  Registro de empleados nuevos y novedades sección nómina (ICA-GRAL-F-014)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 0)
                e.Graphics.DrawString("38  Selección de Administradora en los Sistemas de Pensión y Salud (ICA-GRAL-F-044)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 20)
                e.Graphics.DrawString("39  Afiliación de la EPS, AFP, ARL y Caja de Compensación Familiar", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 40)
                e.Graphics.DrawString("40  Certificado de declarante  ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 60)
                e.Graphics.DrawString("41  Autorización de descuento sindical ", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 80)
                e.Graphics.DrawString("42  Programa de Inducción (ICA-GRAL-F-069)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 100)
                e.Graphics.DrawString("43  Constancia y Evaluación de la Eficacia de la Inducción (ICA-GRAL-F-112)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 120)
                e.Graphics.DrawString("44  Aceptación y compromiso de la Política de No consumo de sustancias Psicoactivas y Alcohol (ICH-GRAL-F-014)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 140)
                e.Graphics.DrawString("45  Aceptación y compromiso de la obligación de reportar accidentes de trabajo (ICH-GRAL-F-081)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 160)
                e.Graphics.DrawString("46  Compromiso y aceptación de la política y plan estratégico de seguridad vial - PESV (ICS-GRAL-F-203)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 180)
                e.Graphics.DrawString("47  Constancia entrega de documentos (ICQ-GRAL-F-011)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 200)
                e.Graphics.DrawString("48  Funciones y Responsabilidades del cargo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 220)
                e.Graphics.DrawString("49  Entrega de dotación al personal (ICS-GRAL-F-32)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 240)
                e.Graphics.DrawString("50  Presentación del empleado nuevo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 260)
                e.Graphics.DrawString("51  Otros soportes (registros adicionales exigidos por el cliente, volantes de pago, prórrogas, otro síes, etc.)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 280)
                e.Graphics.DrawString("52  Carta de terminación de contrato", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 300)
                e.Graphics.DrawString("53  Orden para examen médico de retiro", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 320)
                e.Graphics.DrawString("54  Novedades liquidación final del contrato", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 340)
                e.Graphics.DrawString("55  Paz y salvo para liquidación final de contrato (ICA-GRAL-F-046)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 360)
                e.Graphics.DrawString("56  Contrato de transacción (Acta de liquidación final)", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 380)
                e.Graphics.DrawString("57  Liquidación final del contrato de trabajo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 400)
                e.Graphics.DrawString("58  Reliquidación contrato de trabajo", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 420)
                e.Graphics.DrawString("59  Certificado laboral de ISMOCOL", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y + 440)
                Dim conlineas As Integer
                For conlineas = 0 To 25
                    If puntoOrigen.Y < 750 Then
                        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 663, puntoOrigen.Y - 43, puntoOrigen.X + 713, puntoOrigen.Y - 43) 'Horizontal
                        puntoOrigen.Y = puntoOrigen.Y + 20
                    Else
                        Exit For
                    End If
                Next
        End Select
        Nueva_PaginaL001 += 1
        If Nueva_PaginaL001 = 2 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            Nueva_PaginaL001 = 1
        End If
    End Sub
#End Region

#Region " 39 - ICA GRAL-F-153 AUTORIZACIÓN PARA EL TRATAMIENTO DE DATOS PERSONALES"
    Private WithEvents DocImp_ICAGRALF153 As New PrintDocument

    Private Sub DocImpr_ICAGRALF153(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF153.PrintPage
        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(41, 43)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 730, 978)
        e.Graphics.DrawString("AUTORIZACIÓN PARA EL TRATAMIENTO DE DATOS", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 150, puntoOrigen.Y + 33)
        e.Graphics.DrawString("PERSONALES", Formato_Etiqueta_12, Brocha, puntoOrigen.X + 308, puntoOrigen.Y + 55)
        e.Graphics.DrawString("ICA-GRAL-F-153", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 614, puntoOrigen.Y + 20)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 620, puntoOrigen.Y + 70)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 145, puntoOrigen.Y, puntoOrigen.X + 145, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 584, puntoOrigen.Y, puntoOrigen.X + 584, puntoOrigen.Y + 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 60, 53, 110, 80) '(25, 27, 130, 104)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 584, puntoOrigen.Y + 50, puntoOrigen.X + 730, puntoOrigen.Y + 50) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 100, puntoOrigen.X + 730, puntoOrigen.Y + 100) 'Horizontal completa

        puntoOrigen.X = puntoOrigen.X + 32
        puntoOrigen.Y = puntoOrigen.Y + 208

        e.Graphics.DrawString("(Ciudad),(fecha)                                                                 ", Formato_Etiqueta_11R, Brocha, puntoOrigen.X, puntoOrigen.Y)


        'If IsNothing(_filaContrato) TrabajadorNuevo=true Then

        '    e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & DateTime.Now.ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y - 1)

        'Else
        '    'Dim ciudad As String = IIf(IsDBNull(_filaBaseConfiguracion("CIUDADCONTRATACION")), VariablesBase.VariablesBase.CidadActual, Trim(_filaBaseConfiguracion("CIUDADCONTRATACION")))
        '    'e.Graphics.DrawString(ciudad & ", ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 1)
        '    e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y - 1)
        'End If   _filaBaseConfiguracion("CIUDADCONTRATACION") 

        If Not IsNothing(_filaContrato) Then
            e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_10RS, Brocha, puntoOrigen.X + 150, puntoOrigen.Y) 'Date.Now.ToLongDateString
        Else
            e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & Date.Today.ToLongDateString, Formato_Etiqueta_10RS, Brocha, puntoOrigen.X + 150, puntoOrigen.Y) 'Date.Now.ToLongDateString
        End If




            'e.Graphics.DrawString(_filaBaseConfiguracion("CIUDADCONTRATACION") & ", " & _filaContrato("FECHAINGRESO").ToLongDateString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 1)
            puntoOrigen.Y = puntoOrigen.Y + 111
            '********************************************************************
            Dim Cadenas As New ArrayList
            Cadenas.Add("Yo, " & _filaPersona("NOMBRECOMPLETO") & ", mayor de edad, identificado como aparece al pie de mi nombre y firma, por medio del presente escrito, " & _
            "CERTIFICO que la Empresa ISMOCOL S.A., me ha dado a conocer la Política que tiene establecida para el tratamiento de datos personales, así como también los derechos " & _
            "que tengo como  titular de la información, mencionando cuales son los datos que me serán solicitados, el tratamiento y finalidad a la cual son sometidos mis datos " & _
            "personales en cada una de sus bases de datos, la facultad que tengo de responder o no a los datos sensibles o a los datos sobre niños, niñas o adolescentes que me sean " & _
            "solicitados y la identificación y ubicación plena del responsable del tratamiento de mi información personal.")
            Dim Cadena_Total As New ArrayList
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
            Dim i As Integer
            For i = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
            Next
            puntoOrigen.Y = puntoOrigen.Y + 20

            '********************************************************************
            Cadenas.Clear()
            Cadenas.Add("Como consecuencia de lo anterior, AUTORIZO a ISMOCOL S.A., para que realice el tratamiento de mis datos personales, de conformidad con su Política de Tratamiento de " & _
            "Datos Personales, la cual nuevamente declaro conocer.")
            Cadena_Total.Clear()
            Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_10R, 676.2627, e)
            For i = 0 To Cadena_Total.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_10R, 676.2627, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
            Next

            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_10R, Brocha, puntoOrigen)
            e.Graphics.DrawString("Firma", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 80)
            e.Graphics.DrawString("Nombre Completo: ________________________________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 120)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 140, puntoOrigen.Y + 119)
            e.Graphics.DrawString("C.C.: __________________________ de ______________________________", Formato_Etiqueta_10R, Brocha, puntoOrigen.X, puntoOrigen.Y + 160)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y + 159)
            e.Graphics.DrawString(_filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 270, puntoOrigen.Y + 159)
    End Sub
#End Region

#Region " 47 - DETERMINACIÓN DE LA CLASIFICACIÓN DE LAS PERSONAS NATURALES EN LAS CATEGORÍAS TRIBUTARIAS ESTABLECIDAS EN EL ARTÍCULO 329 DEL ESTATUTO TRIBUTARIO"
    Private WithEvents DocImp_CLASIFPERSONASNATURALES As New PrintDocument

    Private Sub DocImpr_CLASIFPERSONASNATURALES(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_CLASIFPERSONASNATURALES.PrintPage

        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(40, 22)
        Dim puntorec1 As New Point(660, 30)
        Dim tab As Integer = 80
        puntoOrigen.Y = 210
        puntoOrigen.X = tab
        e.Graphics.DrawString("Lugar y Fecha:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CIUDADCONTRATADO") & "            " & Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 131, puntoOrigen.Y)
        e.Graphics.DrawString("Señores", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 50)
        e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 63)
        puntoOrigen.Y = puntoOrigen.Y + 75
        e.Graphics.DrawString("Ciudad", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 50
        e.Graphics.DrawString("Asunto:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString("Determinación de la clasificación de las personas naturales en las categorías Tributarias establecidas en", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 131, puntoOrigen.Y - 20)
        e.Graphics.DrawString("el artículo 329 del Estatuto Tributario.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 131, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        '********************************************************************
        Dim Cadenas As New ArrayList
        Cadenas.Add("Dando cumplimiento con lo establecido en el articulo 1 del Decreto 1070 del 28 de mayo de 2013 , el cual cita: ''Determinación de la clasificación de las Personas Naturales en las Categorias Tributarias establecidas en el articulo 329 del Estatuto " & _
                    "Tributario. Las personas naturales residentes en el país deberán reportar anualmente a sus pagadores o agentes de retención la información necesaria para determinar la categoría tributaria a que pertenecen de acuerdo con lo previsto en el articulo 329 de Estatuto Tributario ")
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
        Cadenas.Add("Me permito manifestar bajo la gravedad de juramento, que: ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 676.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 676.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y + 5
        '********************************************************************
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 586, puntoOrigen.Y - 19, 84, 19)
        e.Graphics.DrawString("SI", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 587, puntoOrigen.Y - 17)
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X + 628, puntoOrigen.Y - 19, puntoOrigen.X + 628, puntoOrigen.Y) 'Vertical
        e.Graphics.DrawString("NO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 17)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 670, 235)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 70, puntoOrigen.X + 670, puntoOrigen.Y + 70) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 163, puntoOrigen.X + 670, puntoOrigen.Y + 163) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 191, puntoOrigen.X + 670, puntoOrigen.Y + 191) 'Horizontal
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 586, puntoOrigen.Y, puntoOrigen.X + 586, puntoOrigen.Y + 235) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 628, puntoOrigen.Y, puntoOrigen.X + 628, puntoOrigen.Y + 235) 'Vertical
        '**************************************************
        puntoOrigen.Y = puntoOrigen.Y + 250
        e.Graphics.DrawString("Atentamente,", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 79, puntoOrigen.X + 250, puntoOrigen.Y + 79) 'Horizontal
        e.Graphics.DrawString("Firma:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 84)
        e.Graphics.DrawString("Nombre y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 119)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 105, puntoOrigen.Y + 118)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 133, puntoOrigen.X + 400, puntoOrigen.Y + 133) 'Horizontal
        e.Graphics.DrawString("Identificación:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 154)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 105, puntoOrigen.Y + 153)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 168, puntoOrigen.X + 400, puntoOrigen.Y + 168) 'Horizontal
        e.Graphics.DrawString("Nit.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 189)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 100, puntoOrigen.Y + 203, puntoOrigen.X + 400, puntoOrigen.Y + 203) 'Horizontal
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 650, puntoOrigen.Y + 189)
        puntoOrigen.Y = puntoOrigen.Y - 249
        puntoOrigen.X += 1
        Cadenas.Clear()
        Cadenas.Add("1. Los ingresos en el año gravable inmediatamente anterior provienen o no de la prestación de servicios de manera personal o del desarrollo de una actividad económica por cuenta y riesgo del empleador o contratante, " & _
                    "en una proporción igual o superior a un ochenta por ciento (80%) del total de los ingresos percibidos por el contribuyente en dicho periodo fiscal. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 584.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 584.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 17
        Cadenas.Clear()
        Cadenas.Add("2. Los ingresos en el año gravable inmediatamante anterior provienen o no de la prestación de servicios personales mediante el ejercicio de profesiones liberales o de la prestación de servicios técnicos que no " & _
                    "requieran la utilización de materiales o insumos especializados, o de maquinaria o equipo especializado, en una proporción igual o superior a un ochenta por ciento (80%) del total de los ingresos percibidos por el contribuyente en dicho periodo fiscal. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 584.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 584.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        Cadenas.Clear()
        Cadenas.Add("3. Estoy obligado(a) a presentar declaración de renta por el año gravable inmediatamente anterior. ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 584.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 584.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
        puntoOrigen.Y = puntoOrigen.Y - 10
        Cadenas.Clear()
        Cadenas.Add("4. Mis ingresos totales en el año gravable inmediatamente anterior superaron mil cuatrocientas (1.400) UVT es decir: (1.400x33.156) es igual a ($46.418.400). ")
        Cadena_Total.Clear()
        Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 584.2627, e)
        For i = 0 To Cadena_Total.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_8R, 584.2627, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 2
        Next
    End Sub
#End Region

#Region " 69 - CARNET CALIFICACION PERSONAL"
    Dim ContadorRenglones As Integer = 0

    Private WithEvents DocImp_CARNETCALIFICACIONPERSONAL As New PrintDocument
    Private Sub DocImprCARNETCALIFICACIONPERSONAL(sender As Object, e As PrintPageEventArgs) Handles DocImp_CARNETCALIFICACIONPERSONAL.PrintPage
        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(20, 20) '15, 22)
        'Cara frontal del carnet
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 350, 255)
        e.Graphics.DrawImage(logoIsmocol, 25, 25, 75, 65)
        puntoOrigen.X += 5
        puntoOrigen.Y += 5
        'cargar datos del contrato y calificaciones
        e.Graphics.DrawStringAligned("ISMOCOL S.A.", HorizontalAlignment.Center, Formato_Etiqueta_10, Brocha, 225, puntoOrigen.X + 75, puntoOrigen.Y)
        Select Case IdBase
            Case 121, 122, 123, 124, 125
                e.Graphics.DrawStringAligned("ICQ-MOCE-F-076 Rev. 0", HorizontalAlignment.Center, Formato_Etiqueta_6R, Brocha, 150, puntoOrigen.X + 75, puntoOrigen.Y + 17)
            Case Else
                e.Graphics.DrawStringAligned("ICQ-OMC-F-019 Rev. 0", HorizontalAlignment.Center, Formato_Etiqueta_6R, Brocha, 150, puntoOrigen.X + 75, puntoOrigen.Y + 17)

        End Select






        Dim foto As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(1, Idpersona)
        If Not IsNothing(foto) Then
            e.Graphics.DrawImage(foto, puntoOrigen.X + 225, puntoOrigen.Y + 17, 100, 115)
        Else
            e.Graphics.FillRectangle(Brushes.White, puntoOrigen.X + 225, puntoOrigen.Y + 17, 110, 115)
            e.Graphics.DrawStringCentered("Espacio para la foto", Formato_Etiqueta_7R, Brocha, 115, puntoOrigen.X + 225, puntoOrigen.Y + 17)
        End If
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 225, puntoOrigen.Y + 17, 100, 115) 'Foto
        e.Graphics.DrawString("CARNÉ DE", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 110, puntoOrigen.Y + 30)
        e.Graphics.DrawString("COMPETENCIAS", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 95, puntoOrigen.Y + 45)
        e.Graphics.DrawStringAligned(_filaPersona("NOMBRES"), HorizontalAlignment.Center, Formato_Etiqueta_10, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 68) 'Centrado
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 83, puntoOrigen.X + 220, puntoOrigen.Y + 83)
        e.Graphics.DrawStringAligned("NOMBRES", HorizontalAlignment.Center, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 88)
        e.Graphics.DrawStringAligned(_filaPersona("APELLIDOS"), HorizontalAlignment.Center, Formato_Etiqueta_10, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 105) 'Centrado
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 120, puntoOrigen.X + 220, puntoOrigen.Y + 120)
        e.Graphics.DrawStringAligned("APELLIDOS", HorizontalAlignment.Center, Formato_Etiqueta_6R, Brocha, 220, puntoOrigen.X, puntoOrigen.Y + 122)
        e.Graphics.DrawString("CARGO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y + 135)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 43, puntoOrigen.Y + 148, puntoOrigen.X + 325, puntoOrigen.Y + 148)
        If IsNothing(_filaContrato) Then
            Dim cargo1 As String
            cargo1 = InputBox("Escriba el cargo que tiene la persona.", "Ingrese El Cargo", "")
            Select Case cargo1.Length
                Case Is < 40
                    e.Graphics.DrawString(cargo1, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 43, puntoOrigen.Y + 136)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(cargo1, Formato_Etiqueta_5, Brocha, puntoOrigen.X + 43, puntoOrigen.Y + 139)
            End Select
        Else
            Dim cargo As String = Trim(_filaContrato("NOMBRETIPOCARGO"))
            Select Case cargo.Length
                Case Is < 40
                    e.Graphics.DrawString(cargo, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 43, puntoOrigen.Y + 136)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(cargo, Formato_Etiqueta_5, Brocha, puntoOrigen.X + 43, puntoOrigen.Y + 139)
            End Select
        End If
        e.Graphics.DrawString("CEDULA:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 85, puntoOrigen.Y + 156)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 143, puntoOrigen.Y + 169, puntoOrigen.X + 325, puntoOrigen.Y + 169)
        e.Graphics.DrawString(FuncionesBase.FuncionesBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 143, puntoOrigen.Y + 156)
        e.Graphics.DrawString("BASE:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 85, puntoOrigen.Y + 175)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 125, puntoOrigen.Y + 188, puntoOrigen.X + 325, puntoOrigen.Y + 188)
        If IsNothing(_filaContrato) Then
            Dim Base As String
            Base = InputBox("Escriba La base  a la que pertenece la persona.", "Ingrese La Base", "")
            e.Graphics.DrawString(Base, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 175)
        Else
            e.Graphics.DrawString(_filaContrato("NOMBREBASECONTRATADO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 130, puntoOrigen.Y + 175)
        End If
        e.Graphics.DrawString("MENTOR:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 85, puntoOrigen.Y + 200)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 143, puntoOrigen.Y + 222, puntoOrigen.X + 325, puntoOrigen.Y + 222)

        Dim mentor As String = ""
        If IsNothing(_filaContrato) Then
            Dim Mentor1 As String
            Mentor1 = InputBox("Escriba el nombre completo del mentor.", "Nombre Mentor", "")
            e.Graphics.DrawStringCentered(Mentor1, Formato_Etiqueta_7R, Brocha, 182, puntoOrigen.X + 145, puntoOrigen.Y + 224)
        Else
            Select Case _filaContrato("IDBASESISCONTROL")
                Case 95, 97, 98, 94, 103, 107, 108
                    mentor = "DIEGO MAURICIO ROZO VILLAMIZAR"
                Case 99, 100, 105, 109, 101, 102, 96, 106, 119
                    mentor = "ALVARO ENRIQUE URICOECHEA SUAREZ"
            End Select
            e.Graphics.DrawString(mentor, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 145, puntoOrigen.Y + 224)
        End If

        e.Graphics.DrawString("FECHA IMPRESION: " + Date.Now.ToShortDateString, Formato_Etiqueta_6, Brocha, puntoOrigen.X + 120, puntoOrigen.Y + 238)

        Dim CEDULAENCRIPTADA As String
        CEDULAENCRIPTADA = FuncionesBase.FuncionesBase.Encryptar(_filaPersona("IDENTIFICACION"))
        Dim TIPO As String
        TIPO = FuncionesBase.FuncionesBase.Encryptar("CALP")
        Dim CORTE As String
        Dim cortefecha As DateTime
        cortefecha = CDate(Date.Now)
        CORTE = FuncionesBase.FuncionesBase.Encryptar(
            IIf(CStr(cortefecha.Day).Length < 2, "0" + CStr(cortefecha.Day), CStr(cortefecha.Day)) + _
            IIf(CStr(cortefecha.Month).Length < 2, "0" + CStr(cortefecha.Month), CStr(cortefecha.Month)) + _
            CStr(cortefecha.Year))

        Dim linkqr As String
        linkqr = "http://190.0.43.174:7070/publico/wf_ConsultarQR.aspx?CED=" + CEDULAENCRIPTADA + "&&TIPO=" + TIPO + "&&CORTE=" + CORTE

        Dim encoder As New QRCodeEncoder()
        encoder.QRCodeScale = 3
        Dim img As New Bitmap(encoder.Encode(linkqr))
        e.Graphics.DrawImage(img, 25, 180, 80, 80)

        'Reestablecer el punto de origen para iniciar el dibujado de la cara posterior del carnet
        puntoOrigen.X = 380
        puntoOrigen.Y = 20
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 350, 255)
        puntoOrigen.X += 5
        puntoOrigen.Y += 5

        Dim puntocalificacion As Point
        puntocalificacion.X = puntoOrigen.X + 2
        puntocalificacion.Y = puntoOrigen.Y + 20

        Dim puntofechainicio As Point
        puntofechainicio.X = puntoOrigen.X + 255
        puntofechainicio.Y = puntoOrigen.Y + 20

        Dim puntofechafin As Point
        puntofechafin.X = puntoOrigen.X + 300
        puntofechafin.Y = puntoOrigen.Y + 20

        e.Graphics.DrawString("ACTIVIDADES CALIFICADAS", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 40, puntoOrigen.Y)
        e.Graphics.DrawString("F. Inicio", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 255, puntoOrigen.Y)
        e.Graphics.DrawString("F. Fin", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 305, puntoOrigen.Y)

        ' 4	CP_CALIFICACIONPERSONALLISTADO
        Dim bddatos As New FuncionesBase.ClaseCargarMaestras
        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(9, Idpersona, -1, 1)
        For cal = 0 To dsCargar.Tables(4).Rows.Count - 1
            Dim filacalificación As DataRow
            filacalificación = dsCargar.Tables(4).Rows(cal)

            If Not IsDBNull(filacalificación("FECHAPROGRAMADAINICIO")) AndAlso filacalificación("ESTADO") = "I" Then
                'Capacitación programada.
            Else
                ContadorRenglones = ContadorRenglones + 1
                If ContadorRenglones < 21 Then
                    If Not IsDBNull(filacalificación("FECHAINICIO")) Then
                        e.Graphics.DrawString(CDate(filacalificación("FECHAINICIO")).ToShortDateString, Formato_Etiqueta_5, Brocha, puntofechainicio.X, puntofechainicio.Y)
                    End If
                    If Not IsDBNull(filacalificación("FECHAVALIDAHASTA")) Then
                        e.Graphics.DrawString(CDate(filacalificación("FECHAVALIDAHASTA")).ToShortDateString, Formato_Etiqueta_5, Brocha, puntofechafin.X, puntofechafin.Y)
                    End If
                    Dim actividad As String = filacalificación("NOMBREACTIVIDADCAPACITACION")
                    e.Graphics.DrawString(Mid(actividad, 1, 70), Formato_Etiqueta_5, Brocha, puntocalificacion.X, puntocalificacion.Y)
                    puntocalificacion.Y = puntocalificacion.Y + 10
                    puntofechainicio.Y = puntofechainicio.Y + 10
                    puntofechafin.Y = puntofechafin.Y + 10
                Else
                    e.Graphics.DrawString("Nota: esta persona posee más act. calificadas, para verlas por favor escanee el código QR.", Formato_Etiqueta_5, Brocha, puntocalificacion.X, puntocalificacion.Y)
                End If
            End If
        Next
        e.Graphics.DrawString("NOTA: EN ESTE DOCUMENTO SE RELACIONAN LAS ACTIVIDADES EN LAS CUALES EL TRABAJADOR SE ENCUENTRA", Formato_Etiqueta_4, Brocha, puntoOrigen.X + 10, puntoOrigen.Y + 230)
        e.Graphics.DrawString("CALIFICADO DENTRO DEL ALCANCE DE SU CARGO. ESTE DOCUMENTO ES INTRANSFERIBLE", Formato_Etiqueta_4, Brocha, puntoOrigen.X + 50, puntoOrigen.Y + 240)
    End Sub
#End Region

#Region " 70 - ICA GRAL-F-014 REGISTRO DE EMPLEADOS NUEVOS Y NOVEDADES Revisión 2"
    Private WithEvents DocImp_ICAGRALF14RV2 As New PrintDocument
    Property inicialF14RV2 As String = "X"
    Property modificaciónF14RV2 As String = ""

    Private Sub DocImpr_ICAGRALF14RV2(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF14RV2.PrintPage
        Dim _filaAuxilioAlimentacionICAGRALF14 As DataRow
        Dim _filaAuxilioTransporteICAGRALF14 As DataRow
        Dim _filaAuxilioSinIncidenciaSalarialICAGRALF14 As DataRow
        Dim _filaBonoTecnicoICAGRALF14 As DataRow
        Dim resultados() As DataRow
        Dim valorAuxilioAlimentacion As String = ""
        Dim valorAuxilioTransporte As String = ""
        Dim valorAuxilioSinIncidenciaSalarial As String = ""
        Dim valorBonoTecnico As String = ""
        Dim periodicidadAlimentacion As String = ""
        Dim periodicidadTransporte As String = ""
        Dim periodicidadSinIncidenciaSalarial As String = ""
        Dim periodicidadTecnico As String = ""
        Dim valorAuxilioUsoHerramienta As String = ""
        Dim periodicidadAuxilioUsoHerramienta As String = ""
        Dim valorBonoxMantenimiento As String = ""
        Dim periodicidadbonoxmantenimiento As String = ""
        Dim valorPrimaPerforacion As String = ""
        Dim periodicidadPrimaPerforacion As String = ""
        Dim valorPrimaMantPozos As String = ""
        Dim periodicidadPrimaMantPozos As String = ""

        'Consultar conceptos  
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (3,10,164,84,168,170,173)")
        If resultados.Length > 0 Then
            _filaAuxilioAlimentacionICAGRALF14 = resultados(0)
            valorAuxilioAlimentacion = FormatCurrency(_filaAuxilioAlimentacionICAGRALF14("VALOR"), 2)
            periodicidadAlimentacion = _filaAuxilioAlimentacionICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (12,165,83,169,171,174)")
        If resultados.Length > 0 Then
            _filaAuxilioTransporteICAGRALF14 = resultados(0)
            valorAuxilioTransporte = FormatCurrency(_filaAuxilioTransporteICAGRALF14("VALOR"), 2)
            periodicidadTransporte = _filaAuxilioTransporteICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] IN (14,85,172)")
        If resultados.Length > 0 Then
            _filaAuxilioSinIncidenciaSalarialICAGRALF14 = resultados(0)
            valorAuxilioSinIncidenciaSalarial = FormatCurrency(_filaAuxilioSinIncidenciaSalarialICAGRALF14("VALOR"), 2)
            periodicidadSinIncidenciaSalarial = _filaAuxilioSinIncidenciaSalarialICAGRALF14("PERIODICIDAD")
        End If
        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 105")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorBonoTecnico = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadTecnico = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If

        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 175")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorAuxilioUsoHerramienta = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadAuxilioUsoHerramienta = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If

        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] = 113")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorBonoxMantenimiento = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadbonoxmantenimiento = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If

        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] in ( 117)")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorPrimaPerforacion = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadPrimaPerforacion = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If

        resultados = _dtConceptosContrato.Select("[CODIGOTIPOCONCEPTOCONTRATO] in ( 118)")
        If resultados.Length > 0 Then
            _filaBonoTecnicoICAGRALF14 = resultados(0)
            valorPrimaMantPozos = FormatCurrency(_filaBonoTecnicoICAGRALF14("VALOR"), 2)
            periodicidadPrimaMantPozos = _filaBonoTecnicoICAGRALF14("PERIODICIDAD")
        End If



        Const InicioLineaX As Integer = 10
        Const espaciointerlineado As Integer = 15
        Const altorectangulo As Integer = 15
        Const lonrectangulo1 As Integer = 235
        Const lonrectangulo2 As Integer = 255
        Const lonrectangulo3 As Integer = 195
        Const lonrectangulo4 As Integer = 195
        'Const lonrectangulo4 As Integer = 125
        Dim telefonos As String = ""
        Dim TerminoInicial As String = ""
        Dim Cuerpo As String = ""
        Dim nombreARL As String = ""
        Dim Vencimiento As Date
        Dim CadenasLabor As New ArrayList
        Dim CadenasLaborTotal As New ArrayList
        Dim Cadenas As New ArrayList
        Dim Cadena_Total As New ArrayList
        Dim puntoOrigen As New Point(10, 26)
        Dim puntorecfinal As New Point(puntoOrigen)
        Dim brocharellenoverde As New SolidBrush(Color.FromArgb(204, 255, 204))
        Dim brocharellenoazul As New SolidBrush(Color.FromArgb(204, 255, 255))

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 25, puntoOrigen.Y + 2, 80, 60)
        e.Graphics.DrawString("REGISTRO DE EMPLEADOS NUEVOS Y NOVEDADES", Formato_Etiqueta_11, Brocha, 170, 58)
        e.Graphics.DrawString("SECCIÓN NÓMINA", Formato_Etiqueta_11, Brocha, 320, 77)
        e.Graphics.DrawString("ICA-GRAL-F-014", Formato_Etiqueta_8, Brocha, 684, 56)
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, 690, 87)
        e.Graphics.DrawLine(Lapiz, InicioLineaX + 125, puntoOrigen.Y, 135, 109) 'Vertical
        e.Graphics.DrawLine(Lapiz, 662, puntoOrigen.Y, 662, 109) 'Vertical
        e.Graphics.DrawLine(Lapiz, 662, 77, InicioLineaX + 785, 77) 'Horizontal
        e.Graphics.DrawLine(Lapiz, InicioLineaX, 109, puntoOrigen.X + 785, 109) 'Horizontal completa
        puntoOrigen.Y = 117
        puntoOrigen.X = 10

        e.Graphics.DrawString("INICIAL", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 113, puntoOrigen.Y, 12, 12)
        e.Graphics.DrawString(inicialF14, Formato_Etiqueta_9, Brocha, puntoOrigen.X + 113, puntoOrigen.Y - 1)
        e.Graphics.DrawString("CÓDIGO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 560, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X + 652, puntoOrigen.Y - 2, 128, 17)
        e.Graphics.DrawStringCentered(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_10, Brocha, 128, puntoOrigen.X + 654, puntoOrigen.Y)

        e.Graphics.DrawString("CONTRATO/CLIENTE:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 190, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 295, puntoOrigen.Y + 13, puntoOrigen.X + 500, puntoOrigen.Y + 13) 'Horizontal completa
        e.Graphics.DrawString(_filaBaseConfiguracion("CODIGOCONTRATOISMOCOL"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 295, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("MODIFICACION", Formato_Etiqueta_7, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 113, puntoOrigen.Y, 12, 12)
        e.Graphics.DrawString(modificaciónF14, Formato_Etiqueta_9, Brocha, puntoOrigen.X + 113, puntoOrigen.Y - 1)

        e.Graphics.DrawString("BASE O PROYECTO:", Formato_Etiqueta_7, Brocha, puntoOrigen.X + 190, puntoOrigen.Y)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 295, puntoOrigen.Y + 12, puntoOrigen.X + 500, puntoOrigen.Y + 12) 'Horizontal completa
        e.Graphics.DrawString(_filaContrato("NOMBREBASECONTRATADO"), Formato_Etiqueta_9, Brocha, puntoOrigen.X + 295, puntoOrigen.Y - 2)


        puntoOrigen.Y += espaciointerlineado + 2
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoverde, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("INFORMACION PERSONAL", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("INFORMACION PERSONAL", Formato_Etiqueta_10, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        Dim Xcol1 As Integer = puntoOrigen.X
        Dim Xcol2 As Integer = puntoOrigen.X + 150
        Dim Xcol3 As Integer = puntoOrigen.X + 390
        Dim Xcol4 As Integer = puntoOrigen.X + 530
        Dim Xcol5 As Integer = puntoOrigen.X + 190
        Dim Xcol6 As Integer = puntoOrigen.X + 590
        e.Graphics.DrawString("Cédula No.:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Lugar Expedición:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Apellidos:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaPersona("APELLIDOS"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Fecha Expedición Cédula:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("FECHAEXPEDICION")) Then
            e.Graphics.DrawString(DirectCast(_filaPersona("FECHAEXPEDICION"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nombres:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        e.Graphics.DrawString(_filaPersona("NOMBRES"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Lugar Nacimiento:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Estado Civil", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaPersona("NOMBRETIPOESTADOCIVIL"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Fecha Nacimiento", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaPersona("FECHANACIMIENTO"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nivel Educativo", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        If Not IsDBNull(_filaPersona("NOMBRENIVELEDUCATIVO")) Then
            If MostrarDato(_filaPersona("NOMBRENIVELEDUCATIVO")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRENIVELEDUCATIVO"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
            End If
        End If

        e.Graphics.DrawString("Género (M / F): ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("GENERO")), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nombre Conyugue", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("NOMBRECOMPLETOCONYUGE")) Then
            If e.Graphics.MeasureString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETOCONYUGE"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
            End If
        End If

        e.Graphics.DrawString("Cédula del Cónyugue:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("IDENTIFICACIONCONYUGE")) Then
            e.Graphics.DrawString(ClConvertir.Fun_FormatearCedula(_filaPersona("IDENTIFICACIONCONYUGE")), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If


        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Licencia Conducción y Cat:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1 - 45, altorectangulo)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2 + 195, puntoOrigen.Y - 5, lonrectangulo1 - 195, altorectangulo)
        If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) Then
            If MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
            End If
        End If
        If Not IsDBNull(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
            If MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8, Brocha, Xcol2 + 195, puntoOrigen.Y - 3)
            End If
        End If
        e.Graphics.DrawString("Libreta Militar:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) Then
            If MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
            End If
        End If


        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Profesión u Oficio:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("NOMBRETIPOPROFESION")) Then
            If MostrarDato(_filaPersona("NOMBRETIPOPROFESION")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOPROFESION"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 3)
            End If
        End If

        e.Graphics.DrawString("Distrito Militar:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
            If MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Correo Eléctronico:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo1, altorectangulo)
        If Not IsDBNull(_filaPersona("EMAIL")) Then
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Teléfono Móvil:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaPersona("TELEFONO")) Then
            telefonos = _filaPersona("TELEFONO")
        End If
        If telefonos = "" Then
            telefonos = _filaPersona("TELEFONOMOVIL")
        Else
            telefonos = telefonos & "-" & _filaPersona("TELEFONOMOVIL")
        End If
        e.Graphics.DrawString(telefonos, Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_7, Brocha, Xcol2, puntoOrigen.Y - 3)
        ElseIf e.Graphics.MeasureString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_6, Brocha, Xcol2, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_5, Brocha, Xcol2, puntoOrigen.Y - 1)
        End If
        e.Graphics.DrawString("Teléfono  de Residencia:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaPersona("TELEFONO")) Then
            telefonos = _filaPersona("TELEFONO")
        End If
        If telefonos = "" Then
            telefonos = _filaPersona("TELEFONOMOVIL")
        Else
            telefonos = telefonos & "-" & _filaPersona("TELEFONOMOVIL")
        End If
        e.Graphics.DrawString(telefonos, Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Dirección de Residencia:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2, puntoOrigen.Y - 5, lonrectangulo2 + 380, altorectangulo)
        If Not IsDBNull(_filaPersona("DIRECCION")) Then
            e.Graphics.DrawString(_filaPersona("DIRECCION"), Formato_Etiqueta_8, Brocha, Xcol2, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Seguridad Social", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Seguridad Social", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("EPS - Salud", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5 - 70, puntoOrigen.Y - 5, lonrectangulo3 + 70, altorectangulo)
        If MostrarDato(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_7, Brocha, Xcol5 - 70, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_6, Brocha, Xcol5 - 70, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPS"), Formato_Etiqueta_5, Brocha, Xcol5 - 70, puntoOrigen.Y - 1)
            End If
        End If
        e.Graphics.DrawString("Fecha Afiliación:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaContrato("FECHAAFILIACIONEPS")) Then
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHAAFILIACIONEPS"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("AFP - Pensión", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If MostrarDato(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_7, Brocha, Xcol5 - 70, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_6, Brocha, Xcol5 - 70, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFP"), Formato_Etiqueta_5, Brocha, Xcol5 - 70, puntoOrigen.Y - 1)
            End If
        End If
        e.Graphics.DrawString("Fecha Afiliación:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaContrato("FECHAAFILIACIONAFP")) Then
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHAAFILIACIONAFP"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Total semanas cotizadas en Pensión", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 5, lonrectangulo3, altorectangulo)
        If Not IsDBNull(_filaContrato("TOTALSEMANASAFP")) Then

            If MostrarDato(_filaContrato("TOTALSEMANASAFP")) Then

                e.Graphics.DrawString(_filaContrato("TOTALSEMANASAFP"), Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 3)

            End If
        End If

        e.Graphics.DrawString("Fecha última cotización en Pensión:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4 + 50, puntoOrigen.Y - 5, lonrectangulo2 - 50, altorectangulo)
        If Not IsDBNull(_filaContrato("FECHAEXPEDICION50SEMANAS")) Then

            Dim temp_string As String = Format(_filaContrato("FECHAEXPEDICION50SEMANAS"), "yyyyMMd")
            e.Graphics.DrawString(temp_string, Formato_Etiqueta_8, Brocha, Xcol4 + 50, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Fondo de Cesantías", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)

        If MostrarDato(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_7, Brocha, Xcol5 - 70, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_6, Brocha, Xcol5 - 70, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAAFC"), Formato_Etiqueta_5, Brocha, Xcol5 - 70, puntoOrigen.Y - 1)
            End If
        End If
        e.Graphics.DrawString("Fecha Afiliación:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)

        If Not IsDBNull(_filaContrato("FECHAAFILIACIONAFC")) Then
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHAAFILIACIONAFC"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol4, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Valor UPC (Aporte Voluntario Salud)", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 5, lonrectangulo3, altorectangulo)
        If Not IsDBNull(_filaContrato("VALORUPC")) Then
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula(_filaContrato("VALORUPC")), Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("* se pagarán en la EPS a la cual este afiliado el empleado", Formato_Etiqueta_8, Brocha, Xcol3, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Valor Aporte Voluntario Pensión", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)

        If Not IsDBNull(_filaContrato("VALORAPORTEVOLUNTARIOPENSION")) Then
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula(_filaContrato("VALORAPORTEVOLUNTARIOPENSION")), Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Nombre Entidad FVP:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)

        If Not IsDBNull(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV")) Then
            If MostrarDato(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV")) Then
                If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
                    e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
                ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
                    e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
                Else
                    e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAEPV"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
                End If
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Valor Ahorro Fomento Construcción:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 5, lonrectangulo3, altorectangulo)
        If Not IsDBNull(_filaContrato("VALORAFCONSTRUCCION")) Then
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula(_filaContrato("VALORAFCONSTRUCCION")), Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Nombre Entidad Ahorro FC:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4, puntoOrigen.Y - 5, lonrectangulo2, altorectangulo)
        If Not IsDBNull(_filaContrato("NOMBREENTIDADAFCONSTRUCCION")) Then
            If MostrarDato(_filaContrato("NOMBREENTIDADAFCONSTRUCCION")) Then
                If e.Graphics.MeasureString(_filaContrato("NOMBREENTIDADAFCONSTRUCCION"), Formato_Etiqueta_7).Width <= lonrectangulo2 Then
                    e.Graphics.DrawString(_filaContrato("NOMBREENTIDADAFCONSTRUCCION"), Formato_Etiqueta_7, Brocha, Xcol4, puntoOrigen.Y - 3)
                ElseIf e.Graphics.MeasureString(_filaContrato("NOMBREENTIDADAFCONSTRUCCION"), Formato_Etiqueta_6).Width <= lonrectangulo2 Then
                    e.Graphics.DrawString(_filaContrato("NOMBREENTIDADAFCONSTRUCCION"), Formato_Etiqueta_6, Brocha, Xcol4, puntoOrigen.Y - 2)
                Else
                    e.Graphics.DrawString(_filaContrato("NOMBREENTIDADAFCONSTRUCCION"), Formato_Etiqueta_5, Brocha, Xcol4, puntoOrigen.Y - 1)
                End If
            End If
        End If


        puntoOrigen.Y += espaciointerlineado + 3
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Deducciones Retención en la Fuente", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Deducciones Retención en la Fuente", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("Concepto de la Deducción", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Vivienda / Salud):", Formato_Etiqueta_5, Brocha, Xcol1 + 140, puntoOrigen.Y)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5 + 20, puntoOrigen.Y - 5, lonrectangulo1 + 80, altorectangulo)
        If Not IsDBNull(_filaContrato("CONCEPTODEDUCIONRETEFUENTE")) Then
            e.Graphics.DrawString(_filaContrato("CONCEPTODEDUCIONRETEFUENTE"), Formato_Etiqueta_8, Brocha, Xcol5 + 20, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Valor de la Deducción:", Formato_Etiqueta_8R, Brocha, Xcol4, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6 + 70, puntoOrigen.Y - 5, lonrectangulo2 - 130, altorectangulo)
        If Not IsDBNull(_filaContrato("VALORDEDUCIONRETEFUENTE")) AndAlso _filaContrato("VALORDEDUCIONRETEFUENTE") >= 0 Then
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula(_filaContrato("VALORDEDUCIONRETEFUENTE")), Formato_Etiqueta_8, Brocha, Xcol6 + 70, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Certificado de Dependencia Económica (Si o No) ?", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaPersona("CERTIFICADODEPENDECIAECONOMICA"), Formato_Etiqueta_8, Brocha, Xcol2 + 121, puntoOrigen.Y - 2)

        e.Graphics.DrawString("*Si suministra información en este modulo, se debe adjuntar solicitud del trabajador acompañada de la certificación", Formato_Etiqueta_5, Brocha, Xcol3 - 10, puntoOrigen.Y - 3)
        e.Graphics.DrawString("expedida por la entidad beneficiaria del pago", Formato_Etiqueta_5, Brocha, Xcol4 - 30, puntoOrigen.Y + 3)
        puntoOrigen.Y += espaciointerlineado
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoverde, InicioLineaX + 1, puntoOrigen.Y + 1, 785, 16)
        e.Graphics.DrawString("INFORMACION LABORAL", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("INFORMACION LABORAL", Formato_Etiqueta_7R, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Vinculación Laboral", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 150, puntoOrigen.Y + 1)
        e.Graphics.DrawString("Forma de Pago", Formato_Etiqueta_8, Brocha, Xcol3 + 100, puntoOrigen.Y + 1)
        e.Graphics.DrawLine(Lapiz, Xcol3, puntoOrigen.Y, Xcol3, puntoOrigen.Y + espaciointerlineado)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, Xcol3, puntoOrigen.Y + 5, InicioLineaX + 785, puntoOrigen.Y + 5) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, Xcol3, puntoOrigen.Y + 5, Xcol3, puntoOrigen.Y + espaciointerlineado * 5 + 5)
        e.Graphics.DrawLine(Lapiz, Xcol3, puntoOrigen.Y + espaciointerlineado * 5 + 5, InicioLineaX + 785, puntoOrigen.Y + espaciointerlineado * 5 + 5) 'Horizontal completa

        puntoOrigen.Y += 8
        e.Graphics.DrawString("Frente de Trabajo (O.T.) o (O.M):", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 3, lonrectangulo3, altorectangulo)
        Dim frentetrabajo As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case frentetrabajo.Length
            Case Is < 33
                e.Graphics.DrawString(frentetrabajo, Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 2)
                Exit Select
            Case Is <= 40
                e.Graphics.DrawString(frentetrabajo, Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y - 1)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(frentetrabajo, 1, 40), Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y - 5)
                e.Graphics.DrawString(Mid(frentetrabajo, 41, 40), Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y + 3)
        End Select

        e.Graphics.DrawString("Clase de Pago (Quincenal / Mensual):", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6, puntoOrigen.Y - 3, lonrectangulo4, altorectangulo)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Cargo del Escalafón o Tabla Salarial", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        Select Case cargo.Length
            Case Is < 40
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 2)
                Exit Select
            Case Is <= 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y - 1)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(cargo, 1, 45), Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y - 5)
                e.Graphics.DrawString(Mid(cargo, 46, 45), Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y + 3)
        End Select

        e.Graphics.DrawString("Cheque o Abono en Cuenta:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(_filaContrato("NOMBRETIPOPAGO"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Fecha de Ingreso", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 3, lonrectangulo3, altorectangulo)
        e.Graphics.DrawString(DirectCast(_filaContrato("FECHAINGRESO"), Date).ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Banco a Consignar:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6, puntoOrigen.Y - 3, lonrectangulo4, altorectangulo)
        If Not IsDBNull(_filaContrato("NOMBREENTIDADFINANCIERA")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_8).Width <= lonrectangulo3 Then
                e.Graphics.DrawString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_7).Width <= lonrectangulo3 Then
                e.Graphics.DrawString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_7, Brocha, Xcol6, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBREENTIDADFINANCIERA"), Formato_Etiqueta_6, Brocha, Xcol6, puntoOrigen.Y - 1)
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Sueldo Básico", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If _filaContrato("TIPODURACION") <> "M" Then
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")), Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
        Else
            e.Graphics.DrawString("$" & ClConvertir.Fun_FormatearCedula((_filaContrato("SALARIO") * 30)), Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
        End If
        e.Graphics.DrawString("Número de Cuenta:", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaContrato("NUMEROCUENTA")) Then
            e.Graphics.DrawString(_filaContrato("NUMEROCUENTA"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)
        End If


        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Tipo Salario ", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Diario / Mensual / Integral):", Formato_Etiqueta_6, Brocha, Xcol1 + 65, puntoOrigen.Y)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 3, lonrectangulo3, altorectangulo)
        If _filaContrato("CODIGOTIPOCONTRATO") = 3 Then
            e.Graphics.DrawString("Integral", Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
        Else
            If _filaContrato("CODIGOTIPOSALARIO") = "M" Then
                e.Graphics.DrawString("Mensual", Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
            Else
                e.Graphics.DrawString("Diario", Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
            End If
            e.Graphics.DrawString("Tipo de Cuenta (Ahorros / Corriente):", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        End If
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6, puntoOrigen.Y - 4, lonrectangulo4, altorectangulo)
        If MostrarDato(_filaContrato("NOMBRETIPOCUENTA")) Then
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCUENTA"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Jornada de Trabajo ", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Completa / Media):", Formato_Etiqueta_6, Brocha, Xcol1 + 100, puntoOrigen.Y - 1)
        e.Graphics.DrawString(_filaContrato("TIPOJORNADA"), Formato_Etiqueta_8, Brocha, Xcol5, puntoOrigen.Y - 3)
        e.Graphics.DrawString("Suministro de Campamento (Si o No)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(If(_filaContrato("SUMINISTROCAMPAMENTO") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Centro Operaciones:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5, puntoOrigen.Y - 3, lonrectangulo3, altorectangulo)
        Dim centrooperaciones As String = _filaContrato("CENTROOPERACIONES").ToString.Trim
        Select Case centrooperaciones.Length
            Case Is < 33
                e.Graphics.DrawString(centrooperaciones, Formato_Etiqueta_7, Brocha, Xcol5, puntoOrigen.Y - 2)
                Exit Select
            Case Is <= 39
                e.Graphics.DrawString(centrooperaciones, Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y - 1)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(centrooperaciones, 1, 39), Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y - 5)
                e.Graphics.DrawString(Mid(centrooperaciones, 40, 39), Formato_Etiqueta_6, Brocha, Xcol5, puntoOrigen.Y + 3)
        End Select
        e.Graphics.DrawString("Suministro de Transporte (Si o No)", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6, puntoOrigen.Y - 3, lonrectangulo4, altorectangulo)
        e.Graphics.DrawString(If(_filaContrato("SUMINISTROTRANSPORTE") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol6, puntoOrigen.Y - 3)

        puntoOrigen.Y += espaciointerlineado
        '*************************************************************************************
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Otros Pagos o Emolumentos", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Otros Pagos o Emolumentos", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.DrawString("Auxilios Extralegales o Convencionales", Formato_Etiqueta_8, Brocha, Xcol1 + 90, puntoOrigen.Y + 2)
        e.Graphics.DrawString("Bonificaciones Extralegales", Formato_Etiqueta_8, Brocha, Xcol3 + 120, puntoOrigen.Y + 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.FillRectangle(brocharellenoverde, Xcol1, puntoOrigen.Y + 2, lonrectangulo1 + 150, altorectangulo)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol3 - 2, puntoOrigen.Y + 2, lonrectangulo2 + 140, altorectangulo)
        If valorAuxilioAlimentacion <> "" Then
            e.Graphics.DrawString("Auxilio de Alimentación: ", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioAlimentacion & "  " & periodicidadAlimentacion, Formato_Etiqueta_8R, Brocha, Xcol2, puntoOrigen.Y + 4)
        End If
        If valorBonoTecnico <> "" Then
            e.Graphics.DrawString("Bono Técnico: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorBonoTecnico & "  " & periodicidadTecnico, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If
        puntoOrigen.Y += espaciointerlineado
        If valorAuxilioTransporte <> "" Then
            e.Graphics.DrawString("Auxilio de Transporte: ", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioTransporte & "  " & periodicidadTransporte, Formato_Etiqueta_8R, Brocha, Xcol2, puntoOrigen.Y + 4)
        End If
        puntoOrigen.Y += espaciointerlineado
        e.Graphics.FillRectangle(brocharellenoverde, Xcol1, puntoOrigen.Y + 2, lonrectangulo1 + 150, altorectangulo)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol3 - 2, puntoOrigen.Y + 2, lonrectangulo2 + 140, altorectangulo)
        If valorAuxilioSinIncidenciaSalarial <> "" Then
            e.Graphics.DrawString("Auxilio sin incidencia salarial: ", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioSinIncidenciaSalarial & "  " & periodicidadSinIncidenciaSalarial, Formato_Etiqueta_8R, Brocha, Xcol2, puntoOrigen.Y + 4)
        End If
        If valorAuxilioUsoHerramienta <> "" Then
            e.Graphics.DrawString("Auxilio Uso Herramienta: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorAuxilioUsoHerramienta & "  " & periodicidadAuxilioUsoHerramienta, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If
        If valorBonoxMantenimiento <> "" Then
            e.Graphics.DrawString("Bono Mantenimiento Equipo: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorBonoxMantenimiento & "  " & periodicidadbonoxmantenimiento, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If
        If valorPrimaPerforacion <> "" Then
            e.Graphics.DrawString("Prima Técnica Perforación: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorPrimaMantPozos & "  " & periodicidadPrimaPerforacion, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If
        If valorPrimaMantPozos <> "" Then
            e.Graphics.DrawString("Prima Técnica Perforación: ", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y + 4)
            e.Graphics.DrawString(valorPrimaMantPozos & "  " & periodicidadPrimaPerforacion, Formato_Etiqueta_8R, Brocha, Xcol4 + 30, puntoOrigen.Y + 4)
        End If


        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Especificar si los valores son mensuales o diarios", Formato_Etiqueta_6R, Brocha, InicioCentradoTexto("Especificar si los valores son mensuales o diarios", Formato_Etiqueta_7, InicioLineaX + 800, e), puntoOrigen.Y + 10)
        '*************************************************************************************
        puntoOrigen.Y += espaciointerlineado + 6
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Contrato de Trabajo", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Contrato de Trabajo", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("Tipo de Contrato ", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.DrawString("(Indefinido / Término Fijo / Obra):", Formato_Etiqueta_5, Brocha, Xcol1 + 85, puntoOrigen.Y - 1)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol5 + 10, puntoOrigen.Y - 3, lonrectangulo3 - 80, altorectangulo)
        Select Case _filaContrato("CODIGOTIPOCONTRATO")
            Case 1, 2, 3, 4, 5 'Término fijo
                e.Graphics.DrawString("Término Fijo", Formato_Etiqueta_8, Brocha, Xcol5 + 10, puntoOrigen.Y - 3)
            Case 6, 7, 8, 9, 10 'Obra o labor
                e.Graphics.DrawString("Obra", Formato_Etiqueta_8, Brocha, Xcol5 + 10, puntoOrigen.Y - 3)
            Case 11, 12 'Término indefinido
                e.Graphics.DrawString("Indefinido", Formato_Etiqueta_8, Brocha, Xcol5 + 10, puntoOrigen.Y - 3)
            Case Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOCONTRATO"), Formato_Etiqueta_8, Brocha, Xcol5 + 10, puntoOrigen.Y + 2)
        End Select
        e.Graphics.DrawString("Duración:", Formato_Etiqueta_8R, Brocha, Xcol3 - 70, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4 - 155, puntoOrigen.Y - 5, lonrectangulo2 - 80, altorectangulo)
        If _filaContrato("DURACION") > 0 Then
            TerminoInicial = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + If(_filaContrato("DURACION") = 1, " Mes", " Meses"), Formato_Etiqueta_8, Brocha, Xcol4 - 155, puntoOrigen.Y - 3)
                Vencimiento = FunBase.Calcular_Fecha_terminación_Contrato(_filaContrato("FECHAINGRESO"), "M", _filaContrato("DURACION"))
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8, Brocha, Xcol4 - 155, puntoOrigen.Y - 3)
                Vencimiento = FunBase.Calcular_Fecha_terminación_Contrato(_filaContrato("FECHAINGRESO"), "D", _filaContrato("DURACION"))
            End If
        End If
        e.Graphics.DrawString("Fecha Vencimiento:", Formato_Etiqueta_8R, Brocha, Xcol4 + 25, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6 + 70, puntoOrigen.Y - 5, lonrectangulo2 - 130, altorectangulo)
        If _filaContrato("DURACION") > 0 Then
            e.Graphics.DrawString(Vencimiento.ToShortDateString, Formato_Etiqueta_8, Brocha, Xcol6 + 70, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Descripción de la obra:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        puntoOrigen.Y += espaciointerlineado
        CadenasLabor.Add(_filaContrato("LABORCONTRATADA"))
        CadenasLaborTotal = TextoAParrafoFuente(CadenasLabor, Formato_Etiqueta_5, 820, e)
        For j As Integer = 0 To CadenasLaborTotal.Count - 1
            e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_8R, 820, e), Formato_Etiqueta_5, Brocha, Xcol1, puntoOrigen.Y + 2)
            If j < CadenasLaborTotal.Count - 1 Then
                puntoOrigen.Y += espaciointerlineado
            End If
        Next

        puntoOrigen.Y += 4
        '*************************************************************************************
        Select Case _filaContrato("CODIGOTIPOCONTRATO")
            Case 1, 2, 3, 4, 5 'Término fijo
                e.Graphics.DrawLine(Lapiz, InicioLineaX + 130, puntoOrigen.Y - 10, InicioLineaX + 785, puntoOrigen.Y - 10) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 4, InicioLineaX + 785, puntoOrigen.Y + 4) 'Horizontal completa
            Case 6, 7, 8, 9, 10 'Obra o labor
                e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y - 25, InicioLineaX + 785, puntoOrigen.Y - 25) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y - 10, InicioLineaX + 785, puntoOrigen.Y - 10) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 5, InicioLineaX + 785, puntoOrigen.Y + 5) 'Horizontal completa
            Case 11, 12 'Término indefinido
                e.Graphics.DrawLine(Lapiz, InicioLineaX + 130, puntoOrigen.Y - 10, InicioLineaX + 785, puntoOrigen.Y - 10) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 4, InicioLineaX + 785, puntoOrigen.Y + 4) 'Horizontal completa
            Case Else
                e.Graphics.DrawString("", Formato_Etiqueta_8, Brocha, Xcol5 + 10, puntoOrigen.Y + 2)
        End Select

        puntoOrigen.Y += espaciointerlineado - 4
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenoazul, InicioLineaX + 1, puntoOrigen.Y + 1, 785, espaciointerlineado - 2)
        e.Graphics.DrawString("Afiliaciones", Formato_Etiqueta_8, Brocha, InicioCentradoTexto("Afiliaciones", Formato_Etiqueta_8, InicioLineaX + 800, e), puntoOrigen.Y + 1)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa

        puntoOrigen.Y += 10
        e.Graphics.DrawString("Sede Riesgo ARP No.:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol2 - 25, puntoOrigen.Y - 3, lonrectangulo1 + 30, altorectangulo)
        If MostrarDato(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORAARL")) Then
            nombreARL = _filaContrato("NOMBRETIPOENTIDADADMINISTRADORAARL")
            If e.Graphics.MeasureString(nombreARL, Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(nombreARL, Formato_Etiqueta_7, Brocha, Xcol2 - 25, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(nombreARL, Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(nombreARL, Formato_Etiqueta_6, Brocha, Xcol2 - 25, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(nombreARL, Formato_Etiqueta_5, Brocha, Xcol2 - 25, puntoOrigen.Y - 1)
            End If
        End If
        e.Graphics.DrawString("Afiliado a Sindicato (Si o No):", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol4 + 20, puntoOrigen.Y - 5, lonrectangulo2 - 230, altorectangulo)
        If Not IsDBNull(_filaContrato("AFILIADOSINDICATO")) Then
            e.Graphics.DrawString(If(_filaContrato("AFILIADOSINDICATO") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4 + 20, puntoOrigen.Y - 2)
        End If
        e.Graphics.DrawString("Cual?", Formato_Etiqueta_8R, Brocha, Xcol4 + 50, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6 + 40, puntoOrigen.Y - 5, lonrectangulo2 - 100, altorectangulo)
        If Not IsDBNull(_filaContrato("NOMBRESINDICATO")) Then
            If MostrarDato(_filaContrato("NOMBRESINDICATO")) Then
                Dim nombresindicato As String = _filaContrato("NOMBRESINDICATO").ToString.Trim
                Select Case nombresindicato.Length
                    Case Is < 17
                        e.Graphics.DrawString(nombresindicato, Formato_Etiqueta_7, Brocha, Xcol6 + 40, puntoOrigen.Y - 2)
                        Exit Select
                    Case Is <= 22
                        e.Graphics.DrawString(nombresindicato, Formato_Etiqueta_6, Brocha, Xcol6 + 40, puntoOrigen.Y - 1)
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(nombresindicato, 1, 22), Formato_Etiqueta_6, Brocha, Xcol6 + 40, puntoOrigen.Y - 5)
                        e.Graphics.DrawString(Mid(nombresindicato, 23, 22), Formato_Etiqueta_6, Brocha, Xcol6 + 40, puntoOrigen.Y + 3)
                End Select
            End If
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Caja de Compensación:", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If MostrarDato(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF")) Then
            If e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_7).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_7, Brocha, Xcol2 - 25, puntoOrigen.Y - 3)
            ElseIf e.Graphics.MeasureString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_6).Width <= lonrectangulo1 Then
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_6, Brocha, Xcol2 - 25, puntoOrigen.Y - 2)
            Else
                e.Graphics.DrawString(_filaContrato("NOMBRETIPOENTIDADADMINISTRADORACCF"), Formato_Etiqueta_5, Brocha, Xcol2 - 25, puntoOrigen.Y - 1)
            End If
        End If
        e.Graphics.DrawString("Aporta Sindicato (Si o No):", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(If(_filaContrato("DESCUENTOSINDICATO") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol4 + 20, puntoOrigen.Y - 2)
        e.Graphics.DrawString("% Aporte:", Formato_Etiqueta_8R, Brocha, Xcol4 + 50, puntoOrigen.Y - 3)
        If Not IsDBNull(_filaContrato("PORCENTAJESINDICATO")) Then
            e.Graphics.DrawString(_filaContrato("PORCENTAJESINDICATO"), Formato_Etiqueta_8, Brocha, Xcol6 + 40, puntoOrigen.Y - 3)
        End If

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("El empleado ha cotizado 50 semanas en los últimos tres años al sistema de seguridad social en pensiones (Si o No) ?", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        e.Graphics.FillRectangle(brocharellenoverde, Xcol6 + 40, puntoOrigen.Y - 5, lonrectangulo2 - 100, altorectangulo)
        e.Graphics.DrawString(If(_filaContrato("COTIZO50SEMANASULTIMOAÑO") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol6 + 40, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Si no ha aportado 50 semanas cuantas le faltan ?", Formato_Etiqueta_8R, Brocha, Xcol1, puntoOrigen.Y - 3)
        If _filaContrato("COTIZO50SEMANASULTIMOAÑO") = "S" Then
            e.Graphics.DrawString("0", Formato_Etiqueta_8, Brocha, Xcol2 + 121, puntoOrigen.Y - 2)
        Else
            e.Graphics.DrawString(_filaContrato("SEMANASFALTAN"), Formato_Etiqueta_8, Brocha, Xcol2 + 121, puntoOrigen.Y - 2)
        End If
        e.Graphics.DrawString("Requiere Colectivo de Vida (Si o No) ?", Formato_Etiqueta_8R, Brocha, Xcol3, puntoOrigen.Y - 3)
        e.Graphics.DrawString(If(_filaContrato("REQUIERECOLECTIVOVIDA") = "S", "SI", "NO"), Formato_Etiqueta_8, Brocha, Xcol6 + 40, puntoOrigen.Y - 2)

        puntoOrigen.Y += espaciointerlineado
        e.Graphics.DrawString("Nota: Para trabajadores menores de 20 años, el numero de semanas cotizadas al sistema son 26.", Formato_Etiqueta_7R, Brocha, Xcol1 + 200, puntoOrigen.Y + 2)

        puntoOrigen.Y += espaciointerlineado
        'Líneas observaciones
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y, InicioLineaX + 785, puntoOrigen.Y) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX + 80, puntoOrigen.Y + 17, InicioLineaX + 785, puntoOrigen.Y + 17) 'Horizontal completa
        'Líneas firmas
        puntoOrigen.Y = puntoOrigen.Y - 15
        e.Graphics.DrawLine(Lapiz_Grueso, InicioLineaX, puntoOrigen.Y + 48, InicioLineaX + 785, puntoOrigen.Y + 48) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 63, InicioLineaX + 785, puntoOrigen.Y + 63) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz_Gris, InicioLineaX, puntoOrigen.Y + 108, InicioLineaX + 785, puntoOrigen.Y + 108) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, InicioLineaX, puntoOrigen.Y + 121, InicioLineaX + 785, puntoOrigen.Y + 121) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 196, puntoOrigen.Y + 48, puntoOrigen.X + 196, puntoOrigen.Y + 134) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 393, puntoOrigen.Y + 48, puntoOrigen.X + 393, puntoOrigen.Y + 134) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 589, puntoOrigen.Y + 48, puntoOrigen.X + 589, puntoOrigen.Y + 134) 'Vertical

        puntoOrigen.Y += espaciointerlineado
        puntoOrigen.Y = puntoOrigen.Y - 13

        Dim puntoobservación As Integer = puntoOrigen.Y + 18

        Dim observacion As String = Trim(_filaContrato("OBSERVACION"))
        Select Case observacion.Length
            Case Is < 100
                e.Graphics.DrawString("Observaciones: " + StrConv(_filaContrato("OBSERVACION"), VbStrConv.ProperCase), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoobservación)
                Exit Select
            Case Else
                Cuerpo = "Observaciones: " + StrConv(_filaContrato("OBSERVACION"), VbStrConv.ProperCase)
                Cadenas.Add(Cuerpo)
                Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 790, e)
                For i As Integer = 0 To Cadena_Total.Count - 1
                    e.Graphics.DrawString(SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 790, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoobservación)
                    puntoobservación += espaciointerlineado
                Next

                puntoobservación = puntoobservación - 2 * espaciointerlineado
        End Select


        e.Graphics.DrawRectangle(Lapiz_Grueso, puntorecfinal.X, puntorecfinal.Y, 785, puntoOrigen.Y + 105)

        puntoOrigen.Y += (espaciointerlineado * 2)
        e.Graphics.DrawStringCentered("Reportó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X, puntoOrigen.Y + 18)
        e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFEPERSONAL"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X, puntoOrigen.Y + 78)
        e.Graphics.DrawStringCentered("Asistente de Personal", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X, puntoOrigen.Y + 90)

        If IdBase = 0 Then
            e.Graphics.DrawStringCentered("Revisó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 18)
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("JEFERRHHBASEPRINCIPAL"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 78)
            e.Graphics.DrawStringCentered("Jefe de Personal", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 90)

            e.Graphics.DrawStringCentered("Autorizó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 18)
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 78)
            e.Graphics.DrawStringCentered("Jefe Dpto. Admón. y Serv. Adtivo / Dir.Obra", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 90)
        Else
            e.Graphics.DrawStringCentered("Revisó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 18)
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("ADMINISTRADOR"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 78)
            e.Graphics.DrawStringCentered("Administrador", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 196, puntoOrigen.Y + 90)

            e.Graphics.DrawStringCentered("Autorizó", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 18)
            e.Graphics.DrawStringCentered(_filaBaseConfiguracion("RESIDENTE"), Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 78)
            e.Graphics.DrawStringCentered("Jefe Dpto. Admón. y Serv. Adtivo / Dir.Obra", Formato_Etiqueta_6R, Brocha, 196, puntoOrigen.X + 393, puntoOrigen.Y + 90)
        End If


        e.Graphics.DrawStringCentered("Registro en Nómina", Formato_Etiqueta_8R, Brocha, 196, puntoOrigen.X + 589, puntoOrigen.Y + 18)
        e.Graphics.DrawStringCentered("Nombre", Formato_Etiqueta_6R, BrochaGrisClaro, 196, puntoOrigen.X + 589, puntoOrigen.Y + 78)

    End Sub
#End Region

#Region " 83 - ICA GRAL-F-069 PROGRAMA DE INDUCCIÓN   OCENSA TUNJA"
    Private WithEvents DocImp_ICAGRALF069TUNJA As New PrintDocument


    Private Function TrabajadorNuevo() As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("select count(IDCONTRATO) from contrato where ESTADOCONTRATO='T' and IDPERSONA = @IDPERSONA", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", Idpersona)
        Dim esNuevo As Boolean
        Try
            comando.Connection.Open()
            esNuevo = comando.ExecuteScalar()
            comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Connection.Close()
        End Try
        If esNuevo = True Then
            Return True
        End If
        Return False
    End Function

    Private Sub DocImpr_ICAGRALF069TUNJA(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF069TUNJA.PrintPage
        Dim puntoOrigen As New Point(15, 22)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        Dim puntorec1 As New Point(660, 30)
        '*******************************************************************
        puntorec1.X = 200
        puntorec1.Y = 80
        e.Graphics.DrawString("PROGRAMA DE INDUCCIÓN", Formato_Etiqueta_14, Brocha, 260, 53)
        e.Graphics.DrawString("ICA-GRAL-F-069", Formato_Etiqueta_8, Brocha, 660, 35)
        e.Graphics.DrawString("Revisión No. 1", Formato_Etiqueta_8, Brocha, 665, 75)
        e.Graphics.DrawLine(Lapiz_Grueso, 120, puntoOrigen.Y, 120, 100) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 18, 27, 100, 70)
        e.Graphics.DrawLine(Lapiz_Grueso, 650, 60, puntoOrigen.X + 750, 60) 'Horizontal
        e.Graphics.DrawLine(Lapiz_Grueso, 650, puntoOrigen.Y, 650, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal completa
        puntoOrigen.Y = 120
        puntoOrigen.X = 18
        e.Graphics.DrawString("NOMBRE DEL TRABAJADOR:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 190, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("FECHA DE INGRESO:", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawString(Format(_filaContrato("FECHAINGRESO"), "d \d\e MMMM \d\e yyyy"), Formato_Etiqueta_9RS, Brocha, puntoOrigen.X + 140, puntoOrigen.Y)
        e.Graphics.DrawString("DEPENDENCIA:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
        Dim dependencia As String = _filaContrato("FRENTETRABAJO").ToString.Trim
        Select Case dependencia.Length
            Case Is < 28
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_10R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                Exit Select
            Case Is <= 48
                e.Graphics.DrawString(dependencia, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y + 3)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(dependencia, 1, 48), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y - 2)
                e.Graphics.DrawString(Mid(dependencia, 49, 48), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y + 8)
        End Select
        puntoOrigen.Y = puntoOrigen.Y + 30
        e.Graphics.DrawString("TRABAJADOR NUEVO EN LA EMPRESA: SI           NO", Formato_Etiqueta_9R, Brocha, puntoOrigen)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 270, puntoOrigen.Y, 20, 15)
        e.Graphics.DrawString(IIf(TrabajadorNuevo() = False, "X", ""), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 273, puntoOrigen.Y)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X + 330, puntoOrigen.Y, 20, 15)
        e.Graphics.DrawString(IIf(TrabajadorNuevo() = True, "X", ""), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 333, puntoOrigen.Y)
        e.Graphics.DrawString("CARGO:", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
        Dim cargo As String = _filaContrato("NOMBRETIPOCARGO").ToString.Trim
        If cargo.Length > 36 Then
            If cargo.Length > 43 Then
                e.Graphics.DrawString(Mid(cargo, 1, 43), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y - 5)
                e.Graphics.DrawString(Mid(cargo, 44, cargo.Length - 43), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y + 10)
            Else
                e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y + 2)
            End If
        Else
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 460, puntoOrigen.Y)
        End If
        puntoOrigen.Y = puntoOrigen.Y + 30
        For j = 0 To 4
            e.Graphics.DrawLine(Lapiz_Grueso, 15, puntoOrigen.Y, puntoOrigen.X + 748, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 3
            e.Graphics.DrawString("ACTIVIDAD " + (j + 1).ToString, Formato_Etiqueta_9, Brocha, puntoOrigen.X + 310, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 15
            e.Graphics.DrawLine(Lapiz_Grueso, 15, puntoOrigen.Y, puntoOrigen.X + 748, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 5
            e.Graphics.DrawString("DEPENDENCIA: _________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EXPOSITOR: ___________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 350, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 20
            e.Graphics.DrawString("FECHA: ________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("DURACIÓN: ______________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 170, puntoOrigen.Y)
            e.Graphics.DrawString("LUGAR: _______________________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 350, puntoOrigen.Y)
            Select Case j
                Case 0
                    e.Graphics.DrawString("HSE", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("PROFESIONAL HSE", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("1 HORA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add("TEMAS: Inducción HSE: 1. video corporativo - 2. Misión, visión - 3. Nuestra filosofía en HSE - 4. Valores de ISMOCOL - " & _
                                "5. Políticas corporativas - 6. Certificaciones SG - 7. Reglamento de trabajo - 8. Reglamento de Higiene y Seguridad Industrial - " & _
                                "9. Permisos de trabajo, AST, procedimientos - 10. Inspección de herramientas y equipos - 11. Planeación del trabajo - " & _
                                "12. Reporte de A&C - 13. Reporte obligatorio de incidentes - 14. Riesgos prioritarios - 15. Matriz de peligros (biológico, físico, " & _
                                "químico, psicosocial, biomecánico, condiciones de seguridad y fenómenos naturales - 16. sistema de seguridad social integral (ARL, EPS, AFP, Caja de Compensación Familiar) - " & _
                                "17. aspecto legales del SG-SST - 18. uso y cuidado de los elementos de protección personal - 19. COPASST - 20. competencias - " & _
                                "21. plan de emergencia - 22. PAEMED - 23. medio ambiente (obligaciones del proyecto, objetivos ambientales) - 24. aspectos de impactos ambientales - " & _
                                "25. Manejo de residuos sólidos y líquidos - 26. Etiquetado de productos químicos - 27. seguridad vial. - 28. Seguridad física. - 29. Código de ética de ISMOCOL. - " & _
                                "30. Atención de PQR´S. - 31. Comité de convivencia laboral. 32. Reporte de la dirección ante el (SG-SST). ")
                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 750.2627, e)
                    For i As Integer = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 8
                    Next
                    e.Graphics.DrawLine(Lapiz, 15, puntoOrigen.Y - 10, puntoOrigen.X + 748, puntoOrigen.Y - 10)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
                Case 1
                    e.Graphics.DrawString("GESTIÓN SOCIAL", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("PROFESIONAL SOCIAL", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("1 HORA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add("TEMAS: 1. Código de ética y convivencia, - 2. Política de Derechos Humanos, - 3. Política de Responsabilidad, Social Empresarial. - " & _
                                "4. Valores Corporativos (compromiso, Convivencia, Honestidad, Respeto, Disciplina), - 5. Derechos Humanos, - 6, Comité de Convivencia Laboral. - " & _
                                "7. Acuerdos con las comunidades. -8. PQRS. - 9. Acoso Laboral.")

                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 750.2627, e)
                    Dim i As Integer
                    For i = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 8
                    Next
                    e.Graphics.DrawLine(Lapiz, 15, puntoOrigen.Y - 10, puntoOrigen.X + 748, puntoOrigen.Y - 10)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
                Case 2
                    e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("ADMINISTRADOR", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("1 HORA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add("TEMAS: 1. Reglamento de Trabajo (Deberes, Derechos, Obligaciones y Prohibiciones - Proceso Disciplinario - Escala de Faltas). " & _
                                "2. Contrato de Trabajo - 3. Sistema General de Seguridad Social Integral - 4. Jornada laboral - 5. Salarios, Pago de nomina - " & _
                                "6. Prestaciones sociales. 7. Permisos - 8. Funciones y responsabilidades. 9. Seguridad Física. ")
                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 750.2627, e)
                    Dim i As Integer
                    For i = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 8
                    Next
                    e.Graphics.DrawLine(Lapiz, 15, puntoOrigen.Y - 10, puntoOrigen.X + 748, puntoOrigen.Y - 10)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
                Case 3
                    e.Graphics.DrawString("ADMINISTRACIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("COORDINADOR DE NOMINA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("1 HORA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add("TEMAS: Proceso de Contratación personal nuevo, Divulgación Formatos para requisición de personal, Solicitud de Permisos, " & _
                                "Autorización para trabajo en dominicales y festivos, salida de la base - Fechas de corte de nomina y pagos nomina, " & _
                                "Incapacidades por enfermedad general, Reporte de Novedades de nomina, liquidación de prestaciones sociales")
                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 750.2627, e)
                    Dim i As Integer
                    For i = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 8
                    Next
                    e.Graphics.DrawLine(Lapiz, 15, puntoOrigen.Y - 10, puntoOrigen.X + 748, puntoOrigen.Y - 10)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
                Case 4
                    e.Graphics.DrawString("CONSTRUCCIÓN", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y - 20)
                    e.Graphics.DrawString("LÍDER OPERATIVO O ADMNISTRATIVO", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y - 20)
                    e.Graphics.DrawString(_filaContrato("FECHAINGRESO"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y)
                    e.Graphics.DrawString("1 HORA", Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 250, puntoOrigen.Y)
                    e.Graphics.DrawString(_filaBaseConfiguracion("NOMBREBASE"), Formato_Etiqueta_9R, Brocha, puntoOrigen.X + 500, puntoOrigen.Y)
                    puntoOrigen.Y = puntoOrigen.Y + 20
                    Dim Cadenas As New ArrayList
                    Cadenas.Add("TEMAS: 1). Compromisos Contractuales. 2) Protocolos de seguridad física. 3) Procesos de mantenimiento. 4). Manejo de Excavaciones. 5). Obras Civiles. ")
                    Dim Cadena_Total As New ArrayList
                    Cadena_Total.Clear()
                    Cadena_Total = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 750.2627, e)
                    Dim i As Integer
                    For i = 0 To Cadena_Total.Count - 1
                        Dim texto As String = SubParrafo1(Cadena_Total(i), Formato_Etiqueta_7R, 750.2627, e)
                        e.Graphics.DrawString(texto, Formato_Etiqueta_7RS, Brocha, puntoOrigen.X, puntoOrigen.Y)
                        puntoOrigen.Y = puntoOrigen.Y + espacioParrafo - 8
                    Next
                    e.Graphics.DrawLine(Lapiz, 15, puntoOrigen.Y - 10, puntoOrigen.X + 748, puntoOrigen.Y - 10)
                    e.Graphics.DrawString("FIRMA EXPOSITOR:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 510, puntoOrigen.Y + 15, puntoOrigen.X + 748, puntoOrigen.Y + 15) 'Horizontal
                    puntoOrigen.Y = puntoOrigen.Y + espacioParrafo
            End Select
        Next
        e.Graphics.DrawLine(Lapiz_Grueso, 15, puntoOrigen.Y, puntoOrigen.X + 748, puntoOrigen.Y) 'Horizontal completa
        puntoOrigen.Y = puntoOrigen.Y + 10
        e.Graphics.DrawString("Manifiesto que he recibido y entendido en todo su alcance los temas tratados y me comprometo a cumplir con el procedimiento", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString(" o contenido de los temas y responsabilidades asignadas. En constancia, firmo.", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 40
        e.Graphics.DrawString("FIRMA DEL TRABAJADOR: ____________________________________    C.C. No. _____________________________________", Formato_Etiqueta_9R, Brocha, puntoOrigen.X, puntoOrigen.Y)
        e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 50, puntoOrigen.Y + 15)
    End Sub
#End Region

End Class