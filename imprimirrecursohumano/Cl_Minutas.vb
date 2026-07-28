Imports System.Drawing.Printing
Imports System.Drawing
Imports FunBase = FuncionesBase.FuncionesBase

Partial Class Cl_Impresión

#Region " 20 - ICA-GRAL-F117 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF117 As New PrintDocument
    Private Cadena_Total_61CONTERFIJO As New ArrayList
    Private Imprimirencabezado_61CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_61CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF117 As Integer = 0

    Private Sub DocImpr_ICAGRALF117(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF117.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-117", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("A UN (1) AÑO PARA TRABAJADORES QUE SON DE", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("A UN (1) AÑO PARA TRABAJADORES QUE SON DE", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_61CONTERFIJO Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 496) 'Vertical '495
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) + "  " + _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If

        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF117 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF117(parrafoMinutaICAGRALF117, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_61CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_61CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_61CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_61CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_61CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_61CONTERFIJO = True
                    Else
                        Imprimirencabezado_61CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF117 += 1
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_61CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF117 = 0
            Imprimirencabezado_61CONTERFIJO = True
            Imprimirpiepagina_61CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 21 - ICA-GRAL-F122 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)"
    Private WithEvents DocImp_ICAGRALF122 As New PrintDocument
    Private Cadena_Total_66CONTERFIJO As New ArrayList
    Private Imprimirencabezado_66CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_66CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF122 As Integer = 0
    Private Sub DocImpr_ICAGRALF122(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF122.PrintPage
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1020)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-122", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO ", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("MANEJO (Convención USO - Ecopetrol)", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("MANEJO (Convención USO - Ecopetrol)", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_66CONTERFIJO Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 496) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF122 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF122(parrafoMinutaICAGRALF122, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_66CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_66CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_66CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_66CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_66CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_66CONTERFIJO = True
                    Else
                        Imprimirencabezado_66CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF122 += 1
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_66CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF122 = 0
            Imprimirencabezado_66CONTERFIJO = True
            Imprimirpiepagina_66CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 22 - ICA-GRAL-F121 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL"
    Private WithEvents DocImp_ICAGRALF121 As New PrintDocument
    Private Cadena_Total_65CONTERFIJO As New ArrayList
    Private Imprimirencabezado_65CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_65CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF121 As Integer = 0
    Private Sub DocImpr_ICAGRALF121(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF121.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-121", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 4", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1)", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("AÑO PARA TRABAJADORES DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("MANEJO CON SALARIO INTEGRAL", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_65CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 400
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 400, puntoOrigen.Y, 400, 495 + 36) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Mensual (sin incluir el factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)

            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Factor prestacional (30% del sueldo mensual):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula((_filaContrato("SALARIO") * 0.3)), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            'e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Salario Integral (incluir Sueldo Mensual más Factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(Math.Round((_filaContrato("SALARIO")) + (_filaContrato("SALARIO") * 0.3))) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If

        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF121 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF121(parrafoMinutaICAGRALF121, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_65CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_65CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_65CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_65CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_65CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_65CONTERFIJO = True
                    Else
                        Imprimirencabezado_65CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF121 += 1
            End If
        Next
        '********************************************************************

        If Imprimirpiepagina_65CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF121 = 0
            Imprimirencabezado_65CONTERFIJO = True
            Imprimirpiepagina_65CONTERFIJO = False
        End If
    End Sub

#End Region

#Region " 23 - ICA-GRAL-F118 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF118 As New PrintDocument
    Private Cadena_Total_62CONTERFIJO As New ArrayList
    Private Imprimirencabezado_62CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_62CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF118 As Integer = 0

    Private Sub DocImpr_ICAGRALF118(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF118.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-118", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("A UN (1) AÑO PARA TRABAJADORES QUE SON DE", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_62CONTERFIJO Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 497) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) + "  " + _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 19
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 1, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF118 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF118(parrafoMinutaICAGRALF118, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_62CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_62CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_62CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_62CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_62CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_62CONTERFIJO = True
                    Else
                        Imprimirencabezado_62CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF118 += 1
            End If
        Next
        '********************************************************************
        '********************************************************************
        If Imprimirpiepagina_62CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF118 = 0
            Imprimirencabezado_62CONTERFIJO = True
            Imprimirpiepagina_62CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 24 - ICA-GRAL-F123 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)"
    Private WithEvents DocImp_ICAGRALF123 As New PrintDocument
    Private Cadena_Total_67CONTERFIJO As New ArrayList
    Private Imprimirencabezado_67CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_67CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF123 As Integer = 0

    Private Sub DocImpr_ICAGRALF123(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF123.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-123", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) ", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, ", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("CONFIANZA Y MANEJO (Convención USO - Ecopetrol)", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_67CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 496) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF123 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF123(parrafoMinutaICAGRALF123, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_67CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_67CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_67CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_67CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_67CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_67CONTERFIJO = True
                    Else
                        Imprimirencabezado_67CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF123 += 1
            End If
        Next
        '********************************************************************

        If Imprimirpiepagina_67CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF123 = 0
            Imprimirencabezado_67CONTERFIJO = True
            Imprimirpiepagina_67CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 25 - ICA-GRAL-F119 CONTRATO DE TRABAJO POR DURACIÓN DE LA OBRA O LABOR DETERMINADA DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF119 As New PrintDocument
    Private Cadena_Total_63CONTERFIJO As New ArrayList
    Private Imprimirencabezado_63CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_63CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF119 As Integer = 0
    Private Sub DocImpr_ICAGRALF119(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF119.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-119", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO POR DURACIÓN DE LA OBRA O", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("LABOR DETERMINADA DE DIRECCIÓN, CONFIANZA Y ", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("MANEJO", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_63CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 460) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'Dim laborContratada As New ArrayList
            'laborContratada.Add("Labor por la cual es contratado: " & _filaContrato("LABORCONTRATADA"))
            'Dim laborTotal As ArrayList = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_8R, 751, e, False)
            'Dim yLabor As Integer = puntoOrigen.Y + 4
            'For i As Integer = 0 To laborTotal.Count - 1
            '    e.Graphics.DrawString(laborTotal(i), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, yLabor)
            '    yLabor += 18
            'Next
            Dim CadenasLaborTotal As ArrayList
            Dim laborContratada As New ArrayList
            laborContratada.Add("Labor por la cual es contratado: " & UCase(_filaContrato("LABORCONTRATADA")))
            CadenasLaborTotal = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_7R, 750, e)
            For j As Integer = 0 To CadenasLaborTotal.Count - 1
                e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_7R, 750, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 2)
                If j < CadenasLaborTotal.Count - 1 Then
                    puntoOrigen.Y = puntoOrigen.Y + 14
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
                End If
            Next
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            Dim textoContratoCliente As String
            textoContratoCliente = "Estas labores están comprendidas dentro de las actividades del contrato: " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " que ISMOCOL S.A. ejecuta para:  " & _filaBaseConfiguracion("CLIENTE")
            If Not _filaBaseConfiguracion("CLIENTE").ToString.EndsWith(".") Then
                textoContratoCliente += "."
            End If
            If e.Graphics.MeasureString(textoContratoCliente, Formato_Etiqueta_8R).Width < 750 Then
                e.Graphics.DrawString(textoContratoCliente, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Else
                LineaTextoAjustado(e, textoContratoCliente, "Arial", 8, FontStyle.Regular, Brocha, 750, puntoOrigen.X, puntoOrigen.Y + 14)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF119 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF119(parrafoMinutaICAGRALF119, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_63CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_63CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_63CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_63CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_63CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_63CONTERFIJO = True
                    Else
                        Imprimirencabezado_63CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF119 += 1
            End If
        Next

        '** * *****************************************************************
        '* * ******************************************************************
        If Imprimirpiepagina_63CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF119 = 0
            Imprimirencabezado_63CONTERFIJO = True
            Imprimirpiepagina_63CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 26 - ICA-GRAL-F124 CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)"
    Private WithEvents DocImp_ICAGRALF124 As New PrintDocument
    Dim Cadena_Total_68CONTERFIJO As New ArrayList
    Dim Imprimirencabezado_68CONTERFIJO As Boolean = True
    Dim Imprimirpiepagina_68CONTERFIJO As Boolean = False
    Dim parrafoMinutaICAGRALF124 As Integer = 0

    Private Sub DocImpr_ICAGRALF124(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF124.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-124", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO POR DURACIÓN DE LA OBRA O", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("LABOR DETERMINADA DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("MANEJO (Convención USO - Ecopetrol)", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_68CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 460) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'Dim laborContratada As New ArrayList
            'laborContratada.Add("Labor por la cual es contratado:  " & _filaContrato("LABORCONTRATADA"))
            'Dim laborTotal As ArrayList = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_8R, 750, e, False)
            'Dim yLabor As Integer = puntoOrigen.Y + 4
            'For i As Integer = 0 To laborTotal.Count - 1
            '    e.Graphics.DrawString(laborTotal(i), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, yLabor)
            '    yLabor += 18
            'Next
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            Dim CadenasLaborTotal As ArrayList
            Dim laborContratada As New ArrayList
            laborContratada.Add("Labor por la cual es contratado: " & UCase(_filaContrato("LABORCONTRATADA")))
            CadenasLaborTotal = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_7R, 750, e)
            For j As Integer = 0 To CadenasLaborTotal.Count - 1
                e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_7R, 750, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 2)
                If j < CadenasLaborTotal.Count - 1 Then
                    puntoOrigen.Y = puntoOrigen.Y + 14
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
                End If
            Next
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            Dim textoContratoCliente As String
            textoContratoCliente = "Estas labores están comprendidas dentro de las actividades del contrato:  " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " que ISMOCOL S.A. ejecuta para:  " & _filaBaseConfiguracion("CLIENTE")
            If Not _filaBaseConfiguracion("CLIENTE").ToString.EndsWith(".") Then
                textoContratoCliente += "."
            End If
            If e.Graphics.MeasureString(textoContratoCliente, Formato_Etiqueta_8R).Width < 750 Then
                e.Graphics.DrawString(textoContratoCliente, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Else
                LineaTextoAjustado(e, textoContratoCliente, "Arial", 8, FontStyle.Regular, Brocha, 750, puntoOrigen.X, puntoOrigen.Y + 14)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF124 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF124(parrafoMinutaICAGRALF124, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_68CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_68CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_68CONTERFIJO(i), Formato_Etiqueta_7R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_68CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_68CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_68CONTERFIJO = True
                    Else
                        Imprimirencabezado_68CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF124 += 1
            End If
        Next

        '** * *****************************************************************
        '* * ******************************************************************
        If Imprimirpiepagina_68CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF124 = 0
            Imprimirencabezado_68CONTERFIJO = True
            Imprimirpiepagina_68CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 27 - ICA-GRAL-F-181 CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL"
    Private WithEvents DocImp_ICAGRALF181 As New PrintDocument
    Dim Cadena_Total_70CONTERFIJO As New ArrayList
    Dim Imprimirencabezado_70CONTERFIJO As Boolean = True
    Dim Imprimirpiepagina_70CONTERFIJO As Boolean = False
    Dim parrafoMinutaICAGRALF181 As Integer = 0

    Private Sub DocImpr_ICAGRALF181(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF181.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-181", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO POR DURACIÓN DE LA OBRA O LABOR", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCIÓN", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("CONFIANZA Y MANEJO CON SALARIO INTEGRAL", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_70CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 400
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 400, puntoOrigen.Y, 400, 496) 'Vertical '400
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Mensual (sin incluir el factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Factor prestacional (30% del sueldo mensual):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula((_filaContrato("SALARIO") * 0.3)), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            'e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Salario Integral (incluir Sueldo Mensual más Factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(Math.Round((_filaContrato("SALARIO")) + (_filaContrato("SALARIO") * 0.3))) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'Dim laborContratada As New ArrayList
            'laborContratada.Add("Labor por la cual es contratado:   " & _filaContrato("LABORCONTRATADA"))
            'Dim laborTotal As ArrayList = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_8R, 750, e, False)
            'Dim yLabor As Integer = puntoOrigen.Y + 4
            'For i As Integer = 0 To laborTotal.Count - 1
            '    e.Graphics.DrawString(laborTotal(i), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, yLabor)
            '    yLabor += 18
            'Next
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            Dim CadenasLaborTotal As ArrayList
            Dim laborContratada As New ArrayList
            laborContratada.Add("Labor por la cual es contratado: " & UCase(_filaContrato("LABORCONTRATADA")))
            CadenasLaborTotal = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_7R, 750, e)
            For j As Integer = 0 To CadenasLaborTotal.Count - 1
                e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_7R, 750, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 2)
                If j < CadenasLaborTotal.Count - 1 Then
                    puntoOrigen.Y = puntoOrigen.Y + 14
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
                End If
            Next
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            Dim textoContratoCliente As String
            textoContratoCliente = "Estas labores están comprendidas dentro de las actividades del contrato: " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " que ISMOCOL S.A. ejecuta para:  " & _filaBaseConfiguracion("CLIENTE")
            If Not _filaBaseConfiguracion("CLIENTE").ToString.EndsWith(".") Then
                textoContratoCliente += "."
            End If
            If e.Graphics.MeasureString(textoContratoCliente, Formato_Etiqueta_8R).Width < 750 Then
                e.Graphics.DrawString(textoContratoCliente, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Else
                LineaTextoAjustado(e, textoContratoCliente, "Arial", 8, FontStyle.Regular, Brocha, 750, puntoOrigen.X, puntoOrigen.Y + 14)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF181 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF181(parrafoMinutaICAGRALF181, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_70CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_70CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_70CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_70CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_70CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_70CONTERFIJO = True
                    Else
                        Imprimirencabezado_70CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF181 += 1
            End If
        Next

        '** * *****************************************************************
        '* * ******************************************************************
        If Imprimirpiepagina_70CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF181 = 0
            Imprimirencabezado_70CONTERFIJO = True
            Imprimirpiepagina_70CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 28 - ICA-GRAL-F120 CONTRATO DE TRABAJO DE LABOR DETERMINADA PARA PERSONAL QUE NO ES DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF120 As New PrintDocument
    Private Cadena_Total_64CONTERFIJO As New ArrayList
    Private Imprimirencabezado_64CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_64CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF120 As Integer = 0

    Private Sub DocImpr_ICAGRALF120(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF120.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-120", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 6", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("LABOR DETERMINADA PARA TRABAJADORES QUE NO", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("SON DE DIRECCIÓN CONFIANZA Y MANEJO", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_64CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 460) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)

            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestará el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'Dim laborContratada As New ArrayList
            'laborContratada.Add("Labor para la cual es contratado:  " & _filaContrato("LABORCONTRATADA"))
            'Dim laborTotal As ArrayList = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_8R, 750, e, False)
            'Dim yLabor As Integer = puntoOrigen.Y + 4
            'For i As Integer = 0 To laborTotal.Count - 1
            '    e.Graphics.DrawString(laborTotal(i), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, yLabor)
            '    yLabor += 18
            'Next
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            Dim CadenasLaborTotal As ArrayList
            Dim laborContratada As New ArrayList
            laborContratada.Add("Labor por la cual es contratado: " & UCase(_filaContrato("LABORCONTRATADA")))
            CadenasLaborTotal = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_7R, 750, e)
            For j As Integer = 0 To CadenasLaborTotal.Count - 1
                e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_7R, 750, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 2)
                If j < CadenasLaborTotal.Count - 1 Then
                    puntoOrigen.Y = puntoOrigen.Y + 14
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
                End If
            Next
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            Dim textoContratoCliente As String
            textoContratoCliente = "Estas labores están comprendidas dentro de las actividades del contrato:  " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " que ISMOCOL S.A. ejecuta para:  " & _filaBaseConfiguracion("CLIENTE")
            If Not _filaBaseConfiguracion("CLIENTE").ToString.EndsWith(".") Then
                textoContratoCliente += "."
            End If
            If e.Graphics.MeasureString(textoContratoCliente, Formato_Etiqueta_8R).Width < 750 Then
                e.Graphics.DrawString(textoContratoCliente, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Else
                LineaTextoAjustado(e, textoContratoCliente, "Arial", 8, FontStyle.Regular, Brocha, 750, puntoOrigen.X, puntoOrigen.Y + 14)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If

        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF120 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF120(parrafoMinutaICAGRALF120, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_64CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_64CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_64CONTERFIJO(i), Formato_Etiqueta_8R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_64CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_64CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 800 Then
                        Imprimirpiepagina_64CONTERFIJO = True
                    Else
                        Imprimirencabezado_64CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF120 += 1
            End If
        Next

        '********************************************************************
        If Imprimirpiepagina_64CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF120 = 0
            Imprimirencabezado_64CONTERFIJO = True
            Imprimirpiepagina_64CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 29 - ICA-GRAL-F125 CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE NO SON DE DIRECCION, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)"
    Private WithEvents DocImp_ICAGRALF125 As New PrintDocument
    Private Cadena_Total_69CONTERFIJO As New ArrayList
    Private Imprimirencabezado_69CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_69CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF125 As Integer = 0

    Private Sub DocImpr_ICAGRALF125(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF125.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-125", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered(" DETERMINADA PARA TRABAJADORES QUE NO SON DE ", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered(" DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_69CONTERFIJO = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 460) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Labor por la cual es contratado:  ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)

            'Dim laborContratada As New ArrayList
            'laborContratada.Add("Labor por la cual es contratado: " & _filaContrato("LABORCONTRATADA"))
            'Dim laborTotal As ArrayList = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_8R, 750, e, False)
            'Dim yLabor As Integer = puntoOrigen.Y + 4
            'For i As Integer = 0 To laborTotal.Count - 1
            '    e.Graphics.DrawString(laborTotal(i), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, yLabor)
            '    yLabor += 18
            'Next
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            'puntoOrigen.Y = puntoOrigen.Y + 18
            Dim CadenasLaborTotal As ArrayList
            Dim laborContratada As New ArrayList
            laborContratada.Add("Labor por la cual es contratado: " & UCase(_filaContrato("LABORCONTRATADA")))
            CadenasLaborTotal = TextoAParrafoFuente(laborContratada, Formato_Etiqueta_7R, 750, e)
            For j As Integer = 0 To CadenasLaborTotal.Count - 1
                e.Graphics.DrawString(SubParrafo1(CadenasLaborTotal(j), Formato_Etiqueta_7R, 750, e), Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y + 2)
                If j < CadenasLaborTotal.Count - 1 Then
                    puntoOrigen.Y = puntoOrigen.Y + 14
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
                End If
            Next
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            Dim textoContratoCliente As String
            textoContratoCliente = "Estas labores están comprendidas dentro de las actividades del contrato:   " & _filaBaseConfiguracion("CODIGOCONTRATOISMOCOL") & " que ISMOCOL S.A. ejecuta para:  " & _filaBaseConfiguracion("CLIENTE")
            If Not _filaBaseConfiguracion("CLIENTE").ToString.EndsWith(".") Then
                textoContratoCliente += "."
            End If
            If e.Graphics.MeasureString(textoContratoCliente, Formato_Etiqueta_8R).Width < 750 Then
                e.Graphics.DrawString(textoContratoCliente, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Else
                LineaTextoAjustado(e, textoContratoCliente, "Arial", 8, FontStyle.Regular, Brocha, 750, puntoOrigen.X, puntoOrigen.Y + 14)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF125 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF125(parrafoMinutaICAGRALF125, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_69CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_69CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_69CONTERFIJO(i), Formato_Etiqueta_7R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_69CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_69CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_69CONTERFIJO = True
                    Else
                        Imprimirencabezado_69CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF125 += 1
            End If
        Next

        '** * *****************************************************************
        '* * ******************************************************************
        If Imprimirpiepagina_69CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF125 = 0
            Imprimirencabezado_69CONTERFIJO = True
            Imprimirpiepagina_69CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 30 - ICA-GRAL-F-183 CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF183 As New PrintDocument
    Private Cadena_Total_72CONTERFIJO As New ArrayList
    Private Imprimirencabezado_72CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_72CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF183 As Integer = 0
    Private Sub DocImpr_ICAGRALF183(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF183.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-183", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("TRABAJADORES QUE SON DE DIRECCIÓN,", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("CONFIANZA Y MANEJO", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_72CONTERFIJO Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 460) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) + "  " + _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2

        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF183 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF183(parrafoMinutaICAGRALF183, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_72CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_72CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_72CONTERFIJO(i), Formato_Etiqueta_7R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_72CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_72CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_72CONTERFIJO = True
                    Else
                        Imprimirencabezado_72CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF183 += 1
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_72CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF183 = 0
            Imprimirencabezado_72CONTERFIJO = True
            Imprimirpiepagina_72CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 31 - ICA-GRAL-F-184 CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL"
    Private WithEvents DocImp_ICAGRALF184 As New PrintDocument
    Private Cadena_Total_73CONTERFIJO As New ArrayList
    Private Imprimirencabezado_73CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_73CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF184 As Integer = 0
    Private Sub DocImpr_ICAGRALF184(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF184.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-184", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("MANEJO CON SALARIO INTEGRAL", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_73CONTERFIJO Then
            Dim SegundaColumnaX As Integer = 400
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 400, puntoOrigen.Y, 400, 496) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Mensual (sin incluir el factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Factor prestacional (30% del sueldo mensual):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula((_filaContrato("SALARIO") * 0.3)), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            'e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Salario Integral (incluir Sueldo Mensual más Factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(Math.Round((_filaContrato("SALARIO")) + (_filaContrato("SALARIO") * 0.3))) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4) '+ "   " + UCase(ClConvertir.IntNumToSpanish(filacontratobasico("SALARIO"))) + " PESOS CON 00 CTVS", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF184 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF184(parrafoMinutaICAGRALF184, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_73CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_73CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_73CONTERFIJO(i), Formato_Etiqueta_7R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_73CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_73CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_73CONTERFIJO = True
                    Else
                        Imprimirencabezado_73CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF184 += 1
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_73CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF184 = 0
            Imprimirencabezado_73CONTERFIJO = True
            Imprimirpiepagina_73CONTERFIJO = False
        End If
    End Sub
#End Region

#Region " 32 - ICA-GRAL-F-182 CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF182 As New PrintDocument
    Private Cadena_Total_71CONTERFIJO As New ArrayList
    Private Imprimirencabezado_71CONTERFIJO As Boolean = True
    Private Imprimirpiepagina_71CONTERFIJO As Boolean = False
    Private parrafoMinutaICAGRALF182 As Integer = 0
    Private Sub DocImpr_ICAGRALF182(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF182.PrintPage
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 750, 1010)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawStringCentered("ICA-GRAL-F-182", Formato_Etiqueta_8, Brocha, 75, 697, 48)
        e.Graphics.DrawLine(Lapiz, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_8, Brocha, 75, 697, 80)
        e.Graphics.DrawLine(Lapiz, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 30, puntoOrigen.Y + 5, 60, 50)
        e.Graphics.DrawStringCentered("CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("TRABAJADORES QUE NO SON DE DIRECCIÓN,", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawStringCentered("CONFIANZA Y MANEJO", Formato_Etiqueta_11, Brocha, 515, puntoOrigen.X + 120, puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_71CONTERFIJO Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, 298, puntoOrigen.Y, 298, 460) 'Vertical '460
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim concatenar As String = _filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION")
            Dim descripcion As String = (concatenar)
            Select Case descripcion.Length
                Case Is < 65
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Is <= 85
                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
                    Exit Select
                Case Else
                    e.Graphics.DrawString(Mid(descripcion, 1, 120), Formato_Etiqueta_5R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End Select
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Correo Electrónico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("EMAIL"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) + "  " + _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2

        End If
        Dim Cadenas As ArrayList
        Dim continuaParrafo As Boolean = False
        For j As Integer = parrafoMinutaICAGRALF182 To 18
            continuaParrafo = False
            Cadenas = New ArrayList
            Cadenas.Add(MinutaICAGRALF182(parrafoMinutaICAGRALF182, _filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            'Cadenas.Add(Environment.NewLine)
            Cadena_Total_71CONTERFIJO = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_7R, 755, e, True)
            For i As Integer = contadorImpresionCadena To Cadena_Total_71CONTERFIJO.Count - 1
                Dim texto As String = SubParrafo1(Cadena_Total_71CONTERFIJO(i), Formato_Etiqueta_7R, 755, e)
                e.Graphics.DrawString(texto, Formato_Etiqueta_7R, Brocha, puntoOrigen.X, puntoOrigen.Y)
                puntoOrigen.Y = puntoOrigen.Y + 13
                If puntoOrigen.Y > 1010 Then
                    Imprimirencabezado_71CONTERFIJO = False
                    contadorImpresionCadena = i + 1
                    continuaParrafo = True
                    e.HasMorePages = True
                    Exit For
                End If
                If i = Cadena_Total_71CONTERFIJO.Count - 1 Then
                    If puntoOrigen.Y < 1010 Then
                        Imprimirpiepagina_71CONTERFIJO = True
                    Else
                        Imprimirencabezado_71CONTERFIJO = False
                        contadorImpresionCadena = i
                        e.HasMorePages = True
                        Exit For
                    End If
                End If
            Next
            If continuaParrafo Then
                Exit Sub
            Else
                contadorImpresionCadena = 0
                parrafoMinutaICAGRALF182 += 1
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_71CONTERFIJO = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 20, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 90, 90, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 630, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 0, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 20, puntoOrigen.Y - 10, puntoOrigen.X + 190, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y - 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 400, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 20, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 400, puntoOrigen.Y)
            contadorImpresionCadena = 0
            parrafoMinutaICAGRALF182 = 0
            Imprimirencabezado_71CONTERFIJO = True
            Imprimirpiepagina_71CONTERFIJO = False
        End If
    End Sub
#End Region



    ''Formatos contrato a termino fijo  anteriores
#Region " 20 - ICA-GRAL-F117 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO  Version Anterior "
    Private WithEvents DocImp_ICAGRALF117v As New PrintDocument
    Private Cadena_Total_61CONTERFIJOv As New ArrayList
    Private Imprimirencabezado_61CONTERFIJOv As Boolean = True
    Private Imprimirpiepagina_61CONTERFIJOv As Boolean = False

    Private Sub DocImpr_ICAGRALF117v(sender As Object, e As PrintPageEventArgs) Handles DocImp_ICAGRALF117v.PrintPage
        Dim puntoOrigen As New Point(45, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-117", Formato_Etiqueta_8, Brocha, 687, 48)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawString("Revisión No. 4", Formato_Etiqueta_8, Brocha, 687, 80)
        e.Graphics.DrawLine(Lapiz_Grueso, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, 63, 44, 75, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("A UN (1) AÑO PARA TRABAJADORES QUE SON DE", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("A UN (1) AÑO PARA TRABAJADORES QUE SON DE", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_61CONTERFIJOv Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar Donde ha sido Contratado:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) + "  " + _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
            Dim Cadenas As New ArrayList
            Cadenas.Add(MinutaICAGRALF117v(_filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            Cadena_Total_61CONTERFIJOv = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e)
        Else
            puntoOrigen = New Point(45, 100)
        End If
        For i As Integer = contadorImpresionCadena To Cadena_Total_61CONTERFIJOv.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_61CONTERFIJOv(i), Formato_Etiqueta_8R, 755, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 13
            If puntoOrigen.Y > 1010 Then
                Imprimirencabezado_61CONTERFIJOv = False
                contadorImpresionCadena = i + 1
                e.HasMorePages = True
                Exit For
            End If
            If i = Cadena_Total_61CONTERFIJOv.Count - 1 Then
                Imprimirpiepagina_61CONTERFIJOv = True
            End If
        Next
        If Imprimirpiepagina_61CONTERFIJOv = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " + _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " + FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) + " DE " + _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 80, 80, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 620, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            contadorImpresionCadena = 0
            Imprimirencabezado_61CONTERFIJOv = True
            Imprimirpiepagina_61CONTERFIJOv = False
        End If
    End Sub
#End Region

#Region " 21 - ICA-GRAL-F122 CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)"
    Private WithEvents DocImp_ICAGRALF122v As New PrintDocument
    Private Cadena_Total_66CONTERFIJOv As New ArrayList
    Private Imprimirencabezado_66CONTERFIJOv As Boolean = True
    Private Imprimirpiepagina_66CONTERFIJOv As Boolean = False

    Private Sub DocImpr_ICAGRALF122v(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF122v.PrintPage
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-122", Formato_Etiqueta_8, Brocha, 687, 48)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, 687, 80)
        e.Graphics.DrawLine(Lapiz_Grueso, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, 63, 44, 75, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA", Formato_Etiqueta_10, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_10, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("(Convención USO - Ecopetrol)", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("(Convención USO - Ecopetrol)", Formato_Etiqueta_10, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_66CONTERFIJOv Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar Donde ha sido Contratado:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
            Dim Cadenas As New ArrayList
            Cadenas.Add(MinutaICAGRALF122v(_filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            Cadena_Total_66CONTERFIJOv = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e)
        End If
        For i As Integer = contadorImpresionCadena To Cadena_Total_66CONTERFIJOv.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_66CONTERFIJOv(i), Formato_Etiqueta_8R, 755, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 13
            If puntoOrigen.Y > 1010 Then
                Imprimirencabezado_66CONTERFIJOv = False
                contadorImpresionCadena = i + 1
                e.HasMorePages = True
                Exit For
            End If
            If i = Cadena_Total_66CONTERFIJOv.Count - 1 Then
                If puntoOrigen.X > 800 Then
                    Imprimirencabezado_66CONTERFIJOv = False
                    contadorImpresionCadena = i
                    e.HasMorePages = True
                    Exit For
                Else
                    Imprimirpiepagina_66CONTERFIJOv = True
                End If
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_66CONTERFIJOv = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 80, 80, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 620, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            contadorImpresionCadena = 0
            Imprimirencabezado_66CONTERFIJOv = True
            Imprimirpiepagina_66CONTERFIJOv = False
        End If
    End Sub
#End Region

#Region " 22 - ICA-GRAL-F121 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES DE DIRECCION, CONFIANZA Y MANEJO CON SALARIO INTEGRAL"
    Private WithEvents DocImp_ICAGRALF121v As New PrintDocument
    Private Cadena_Total_65CONTERFIJOv As New ArrayList
    Private Imprimirencabezado_65CONTERFIJOv As Boolean = True
    Private Imprimirpiepagina_65CONTERFIJOv As Boolean = False

    Private Sub DocImpr_ICAGRALF121v(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF121v.PrintPage
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-121", Formato_Etiqueta_8, Brocha, 687, 48)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, 687, 80)
        e.Graphics.DrawLine(Lapiz_Grueso, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, 63, 44, 75, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1)", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1)", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("AÑO PARA TRABAJADORES DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("AÑO PARA TRABAJADORES DE DIRECCIÓN, CONFIANZA Y", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("MANEJO CON SALARIO INTEGRAL", Formato_Etiqueta_11, Brocha, InicioCentradoTexto("MANEJO CON SALARIO INTEGRAL", Formato_Etiqueta_11, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_65CONTERFIJOv = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar Donde ha sido Contratado:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo mensual (Sin incluir el factor prestacional):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Factor prestacional (30% del sueldo mensual):", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(Math.Round((_filaContrato("SALARIO") * 0.3))), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
            Dim Cadenas As New ArrayList
            Cadenas.Add(MinutaICAGRALF122v(_filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            Cadena_Total_65CONTERFIJOv = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e)
        Else
            puntoOrigen = New Point(40, 100)
        End If
        For i As Integer = contadorImpresionCadena To Cadena_Total_65CONTERFIJOv.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_65CONTERFIJOv(i), Formato_Etiqueta_8R, 755, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 13
            If puntoOrigen.Y > 1010 Then
                Imprimirencabezado_65CONTERFIJOv = False
                contadorImpresionCadena = i + 1
                e.HasMorePages = True
                Exit For
            End If
            If i = Cadena_Total_65CONTERFIJOv.Count - 1 Then
                If puntoOrigen.X > 800 Then
                    Imprimirencabezado_65CONTERFIJOv = False
                    contadorImpresionCadena = i
                    e.HasMorePages = True
                    Exit For
                Else
                    Imprimirpiepagina_65CONTERFIJO = True
                End If
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_65CONTERFIJOv = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " + _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 80, 80, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 620, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            contadorImpresionCadena = 0
            Imprimirencabezado_65CONTERFIJOv = True
            Imprimirpiepagina_65CONTERFIJOv = False
        End If
    End Sub
#End Region

#Region " 23 - ICA-GRAL-F118 CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO"
    Private WithEvents DocImp_ICAGRALF118v As New PrintDocument
    Private Cadena_Total_62CONTERFIJOv As New ArrayList
    Private Imprimirencabezado_62CONTERFIJOv As Boolean = True
    Private Imprimirpiepagina_62CONTERFIJOv As Boolean = False

    Private Sub DocImpr_ICAGRALF118v(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF118v.PrintPage
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-118", Formato_Etiqueta_8, Brocha, 687, 48)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawString("Revisión No. 4", Formato_Etiqueta_8, Brocha, 687, 80)
        e.Graphics.DrawLine(Lapiz_Grueso, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, 63, 44, 75, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A", Formato_Etiqueta_9, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A", Formato_Etiqueta_9, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("UN AÑO PARA TRABAJADORES QUE NO SON DE", Formato_Etiqueta_9, Brocha, InicioCentradoTexto("UN AÑO PARA TRABAJADORES QUE NO SON DE", Formato_Etiqueta_9, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_9, Brocha, InicioCentradoTexto("DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_9, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_62CONTERFIJOv Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar Donde ha sido Contratado:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " & ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
            Dim Cadenas As New ArrayList
            Cadenas.Add(MinutaICAGRALF118v(_filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            Cadena_Total_62CONTERFIJOv = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e)
        Else
            puntoOrigen = New Point(40, 100)
        End If
        For i As Integer = contadorImpresionCadena To Cadena_Total_62CONTERFIJOv.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_62CONTERFIJOv(i), Formato_Etiqueta_8R, 755, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 13
            If puntoOrigen.Y > 1010 Then
                Imprimirencabezado_62CONTERFIJOv = False
                contadorImpresionCadena = i + 1
                e.HasMorePages = True
                Exit For
            End If
            If i = Cadena_Total_62CONTERFIJOv.Count - 1 Then
                Imprimirpiepagina_62CONTERFIJOv = True
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_62CONTERFIJOv = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " + _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " + FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) + " DE " + _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 80, 80, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 620, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            contadorImpresionCadena = 0
            Imprimirencabezado_62CONTERFIJOv = True
            Imprimirpiepagina_62CONTERFIJOv = False
        End If
    End Sub
#End Region

#Region " 24 - ICA-GRAL-F123 CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCION, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)"
    Private WithEvents DocImp_ICAGRALF123v As New PrintDocument
    Private Cadena_Total_67CONTERFIJOv As New ArrayList
    Private Imprimirencabezado_67CONTERFIJOv As Boolean = True
    Private Imprimirpiepagina_67CONTERFIJOv As Boolean = False

    Private Sub DocImpr_ICAGRALF123v(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF123v.PrintPage
        Dim puntoOrigen As New Point(40, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, 750, 990)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y, 675, 100) 'Vertical
        e.Graphics.DrawString("ICA-GRAL-F-123", Formato_Etiqueta_8, Brocha, 687, 48)
        e.Graphics.DrawLine(Lapiz_Grueso, 675, puntoOrigen.Y + 30, puntoOrigen.X + 750, puntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawString("Revisión No. 3", Formato_Etiqueta_8, Brocha, 687, 80)
        e.Graphics.DrawLine(Lapiz_Grueso, 160, puntoOrigen.Y, 160, 100) 'Vertical
        e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, 100, puntoOrigen.X + 750, 100) 'Horizontal
        e.Graphics.DrawImage(logoIsmocol, 63, 44, 75, 50)
        e.Graphics.DrawString("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA", Formato_Etiqueta_10, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO", Formato_Etiqueta_10, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        e.Graphics.DrawString("(Convención USO - Ecopetrol)", Formato_Etiqueta_10, Brocha, InicioCentradoTexto("(Convención USO - Ecopetrol)", Formato_Etiqueta_10, 845, e), puntoOrigen.Y)
        puntoOrigen.Y = puntoOrigen.Y + 20
        If Imprimirencabezado_67CONTERFIJOv = True Then
            Dim SegundaColumnaX As Integer = 300
            Dim TerceraColumnaX As Integer = 450
            Dim CuartaColumnaX As Integer = 550
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombre Empleador:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Domicilio Principal:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("CALLE 100 No. 13-76 PISO 7 BOGOTÁ D.C.", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Código:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CODIGOCONTRATO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Nombres y Apellidos:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("NOMBRECOMPLETO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cédula de Ciudadanía No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Expedida en:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTOEXPEDICION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Libreta Militar No.:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("LIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("LIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Clase:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCLASELIBRETAMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Distrito:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LIBRETAMILITAR")) AndAlso MostrarDato(_filaPersona("NOMBRETIPODISTRITOMILITAR")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPODISTRITOMILITAR"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Licencia de Conducción No:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("LICENCIACONDUCCION")) Then
                e.Graphics.DrawString(_filaPersona("LICENCIACONDUCCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Categoría:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            If Not IsDBNull(_filaPersona("LICENCIACONDUCCION")) AndAlso MostrarDato(_filaPersona("NOMBRETIPOCATEGORIALICENCIA")) Then
                e.Graphics.DrawString(_filaPersona("NOMBRETIPOCATEGORIALICENCIA"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Dirección y Ciudad de Residencia:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("DIRECCION") + ",  " + _filaPersona("CIUDADYDEPTODIRECCION"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y Fecha de Nacimiento:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaPersona("CIUDADYDEPTONACIMIENTO") + ",  " + CDate(_filaPersona("FECHANACIMIENTO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar Donde ha sido Contratado:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOCONTRATADO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar donde prestara el Servicio:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Iniciación de Labores:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(CDate(_filaContrato("FECHAINGRESO")).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Término de duración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            Dim TerminoInicial As String = ClConvertir.NumerosEnPalabras(_filaContrato("DURACION"), "")
            If _filaContrato("CODIGOTIPODURACION") = "M" Then
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Meses", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            Else
                e.Graphics.DrawString(TerminoInicial + " (" + _filaContrato("DURACION").ToString + ")" + " Días", Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            End If
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Fecha de Terminación del Contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(DirectCast(_filaContrato("FECHATERMINOCONTRATOINICIAL"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Lugar y fecha de elaboración del contrato:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("CIUDADYDEPTOLABORES") + ",  " + DirectCast(_filaContrato("FECHAFIRMACONTRATO"), Date).ToLongDateString, Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Sueldo Básico:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString("$ " + ClConvertir.Fun_FormatearCedula(_filaContrato("SALARIO")) & "  " & _filaContrato("TIPOSALARIO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Períodos de Pago:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOPERIODOPAGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            e.Graphics.DrawString("Cargo:", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y + 4)
            e.Graphics.DrawString(_filaContrato("NOMBRETIPOCARGO"), Formato_Etiqueta_8R, Brocha, SegundaColumnaX, puntoOrigen.Y + 4)
            puntoOrigen.Y = puntoOrigen.Y + 18
            e.Graphics.DrawLine(Lapiz_Grueso, puntoOrigen.X, puntoOrigen.Y, puntoOrigen.X + 750, puntoOrigen.Y) 'Horizontal completa
            puntoOrigen.Y = puntoOrigen.Y + 2
            Dim Cadenas As New ArrayList
            Cadenas.Add(MinutaICAGRALF123v(_filaBaseConfiguracion("RESIDENTE"), FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")), _filaBaseConfiguracion("CIUDADYDEPTOEXPIDRESIDENTE")))
            Cadena_Total_67CONTERFIJOv = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 755, e)
        Else
            puntoOrigen = New Point(40, 100)
        End If
        For i As Integer = contadorImpresionCadena To Cadena_Total_67CONTERFIJOv.Count - 1
            Dim texto As String = SubParrafo1(Cadena_Total_67CONTERFIJOv(i), Formato_Etiqueta_8R, 755, e)
            e.Graphics.DrawString(texto, Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y = puntoOrigen.Y + 13
            If puntoOrigen.Y > 1010 Then
                Imprimirencabezado_67CONTERFIJOv = False
                contadorImpresionCadena = i + 1
                e.HasMorePages = True
                Exit For
            End If
            If i = Cadena_Total_67CONTERFIJOv.Count - 1 Then
                If puntoOrigen.X > 800 Then
                    Imprimirencabezado_67CONTERFIJOv = False
                    contadorImpresionCadena = i
                    e.HasMorePages = True
                    Exit For
                Else
                    Imprimirpiepagina_67CONTERFIJOv = True
                End If
            End If
        Next
        '********************************************************************
        If Imprimirpiepagina_67CONTERFIJOv = True Then
            e.Graphics.DrawString("En constancia de lo anterior se firma en la fecha de elaboración indicada en el inicio del presente contrato en dos ejemplares del mismo tenor.", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("EL EMPLEADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("EL TRABAJADOR", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_8, Brocha, puntoOrigen.X, puntoOrigen.Y + 25)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaBaseConfiguracion("IDENTIFICACIONRESIDENTE")) & " DE " & _filaBaseConfiguracion("CIUDADEXPIDRESIDENTE"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. " & FunBase.FormatearIdentificacion(_filaPersona("IDENTIFICACION")) & " DE " & _filaPersona("CIUDADEXPEDICION"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            e.Graphics.DrawRoundedRectangle(puntoOrigen.X + 600, puntoOrigen.Y - 100, 80, 80, 10)
            e.Graphics.DrawString("Huella", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 620, puntoOrigen.Y - 100)
            puntoOrigen.Y += 40
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("TESTIGO", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            puntoOrigen.Y += 100
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y - 10, puntoOrigen.X + 120, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 450, puntoOrigen.Y - 10, puntoOrigen.X + 570, puntoOrigen.Y - 10) 'Horizontal
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X, puntoOrigen.Y)
            e.Graphics.DrawString("C.C. No. ", Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 450, puntoOrigen.Y)
            contadorImpresionCadena = 0
            Imprimirencabezado_67CONTERFIJOv = True
            Imprimirpiepagina_67CONTERFIJOv = False
        End If
    End Sub
#End Region












End Class

''' <summary>
''' Contiene métodos que devuelven cadenas con las minutas de los contratos.
''' </summary>
Friend Module Cl_MinutaContrato


    ''' <summary>
    ''' version anterior Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO.
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF117v(nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Return "Entre los suscritos a saber por una parte " & nombreResidente & ", identificado con Cédula de Ciudadanía No. " & identificacionResidente & _
                " expedida en " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo " & _
                "se denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
                "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas : PRIMERA - " & _
                "OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al cargo descrito " & _
                "anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad  con los reglamentos, manuales, ordenes e " & _
                "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
                "para el cabal cumplimiento de su encargo. SEGUNDA OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "Interno de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento Interno de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales  consagradas en el Reglamento Interno de Trabajo. TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento Interno de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado el trabajador " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento Interno de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo.  QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en " & _
                "el encabezamiento del contrato, un salario total consistente en la suma fija establecida inicialmente. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo " & _
                "no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando el TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso.  PARÁGRAFO SEGUNDO: Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de " & _
                "alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo " & _
                "(Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o " & _
                "cualquier otra bonificación extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Cuando por causa emanada directa o " & _
                "indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no legalizados, herramientas y equipos en custodia, " & _
                "daños a elementos de trabajo, preaviso, etc. y, más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, " & _
                "entendiendo  expresamente las partes que la presenta autorización cumple las condiciones de orden escrita previa, aplicable para  cada caso. PARÁGRAFO " & _
                "CUARTO: Si durante el curso del presente contrato sobrevienen o se modifican los salarios o emolumentos extralegales o convencionales por expresa " & _
                "disposición de la compañía para la cual ISMOCOL S.A. es contratista, o se hayan causado obligaciones de tipo económico con ocasión al vínculo laboral por " & _
                "parte del EMPLEADOR para con el TRABAJADOR, las partes acuerdan que EL EMPLEADOR podrá efectuar el pago de los correspondientes reajustes o reliquidaciones " & _
                "por medio de transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario. SEXTA – JORNADA " & _
                "ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la  jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el  " & _
                "Reglamento Interno de Trabajo, pudiendo hacer  este ajuste o cambios de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. SÉPTIMA - EXCLUSIÓN DE JORNADA MÁXIMA: Por tratarse de que EL TRABAJADOR va a " & _
                "desempeñar un cargo de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima legal de " & _
                "trabajo de que trata el artículo 162 del código sustantivo del Trabajo, por lo tanto no tendrá derecho al reconocimiento económico por laborar horas " & _
                "extras. OCTAVA – TERMINO DE DURACIÓN DEL CONTRATO: El término inicial del contrato será el establecido inicialmente en el encabezado del presente " & _
                "contrato. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Las partes acuerdan " & _
                "expresamente que las prorrogas por un periodo igual o inferior podrán efectuarse en cualquier tiempo. Tratándose de un contrato a término fijo inferior a " & _
                "(1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres (3) periodos iguales o inferiores, si al cabo de los cuales no se " & _
                "notifica su terminación, el término de renovación no podrá ser inferior a (1) un año, y así sucesivamente. En cumplimiento de lo previsto en el Artículo 3 " & _
                "de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de servicios en proporción al tiempo laborado, cualquiera que esta sea. " & _
                "PARÁGRAFO PRIMERO: El contrato también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza  mayor o caso fortuito " & _
                "ó si el contratante para el cual se desarrollen las labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o " & _
                "definitivamente el contrato principal, o reducir los trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, " & _
                "el trabajador se encuentra incapacitado por su EPS o  ARL ya sea por enfermedad general o accidente común, enfermedad profesional o  accidente de " & _
                "trabajo, desde ya se entenderá que los efectos del presente contrato de trabajo serán extendidos por el tiempo que el trabajador permanezca incapacitado " & _
                "conforme a las certificaciones que para tal efecto expida la EPS  o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. PARÁGRAFO TERCERO: " & _
                "Si al momento de finalizar el presente contrato de trabajo, la trabajadora se encuentra en licencia de maternidad debidamente expedida por su EPS, desde " & _
                "ya se entenderá que los efectos del presente contrato de trabajo serán extendidos por el tiempo de vigencia de la licencia en cuestión. NOVENA – PERIODO " & _
                "DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte del término inicial de este contrato, y en todo caso no es superior a (2) dos meses; " & _
                "en caso de prorroga, se entenderá que no hay un nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 7 de la Ley 50/90. Durante este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, " & _
                "sin que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por " & _
                "el Artículo 3 del decreto 617/54. DECIMA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este " & _
                "contrato por cualquier de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65; y, además por parte de EL EMPLEADOR, el incumplimientos de EL " & _
                "TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas en la cláusulas segunda y cuarta, y las demás faltas que para el efecto se " & _
                "califiquen como graves en el espacio reservado para cláusulas adicionales en el presente contrato, el Reglamento Interno de Trabajo, Circulares Normativas " & _
                "y las demás comunicaciones emanadas de EL EMPLEADOR en donde se estipulen. DECIMA PRIMERA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL " & _
                "TRABAJADOR preste sus servicios a EL EMPLEADOR llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de " & _
                "producción y/o administrativo de EL EMPLEADOR estos quedaran de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley " & _
                "Comercial como propiedad industrial. EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo " & _
                "cual EL TRABAJADOR facilitará el cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin " & _
                "cuando así lo solicite EL EMPLEADOR, sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna. DECIMA SEGUNDA - " & _
                "AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: El TRABAJADOR autoriza al EMPLEADOR para almacenar por tiempo indefinido los datos personales " & _
                "(incluyendo datos sensibles) que ha suministrado con ocasión de la suscripción este contrato de trabajo, los cuales sólo serán usados por el EMPLEADOR " & _
                "dentro de los procesos y eventos propios de su ejecución. El TRABAJADOR acepta que sus datos pueden ser transferidos al beneficiario de la obra para la " & _
                "que ha sido vinculado y/o su interventor, solo para fines de auditoría y mantenimiento del control y seguridad al interior de sus instalaciones. El " & _
                "EMPLEADOR realizará un tratamiento responsable y seguro de los datos suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la " & _
                "reglamentan. DECIMA TERCERA - ORDEN PUBLICO: EL TRABAJADOR es consciente y conocedor de las condiciones de orden público que predominan en todo el " & _
                "territorio nacional y por lo tanto asume el riesgo que se deriva de la actividad laboral que va a desarrollar y se compromete a cumplir de manera especial " & _
                "con todas las normas, instrucciones y ordenes que manera particular o general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro " & _
                "o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable por el pago de rescate o concepto similar a favor de sus captores, por expresa " & _
                "disposición y en cumplimiento de lo dispuesto en la ley 40/93 y demás normas reglamentarias. DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente " & _
                "entendido que ISMOCOL S.A., en desarrollo de su objeto social y dentro de las actividades que da origen a la presente relación laboral, actúa como " & _
                "CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como representante ni intermediario de ninguno de sus contratantes, por lo tanto no " & _
                "existe ni existirá en ningún momento relación laboral entre EL TRABAJADOR y los contratantes de ISMOCOL S.A., toda vez que el único y verdadero EMPLEADOR " & _
                "de éste es y será ISMOCOL S.A., así EL TRABAJADOR preste sus servicios de manera temporal o permanente en el (los) proyecto(s) o contrato(s) que EL " & _
                "EMPLEADOR ejecute. DECIMA QUINTA - PREVENCION EN  LAVADO DE ACTIVOS Y FINANCIACION DEL TERRORISMO (LA/FT): Con la firma del presente documento o la " & _
                "entrega de la informacion aqui solicitada, declaro que mis recursos provienen de actividades lícitas y están ligados al desarrollo normal de mis " & _
                "actividades, y que, por lo tanto, los mismos  no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o en cualquier " & _
                "norma que lo sustituya, adicione o modifique; declaro que no me encuentro en las listas internacionales vinculantes para Colombia de conformidad con el " & _
                "derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no  tengo nexos tanto sociales como familiares " & _
                "con personas inmersas en lavado de activos y financiacion del terrorismo.  PARAGRAFO PRIMERO:  Autorizo a ISMOCOL S.A. para utilizar mi informacion " & _
                "personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la empresa, para previnir los riesgos asociados a LA/FT.  " & _
                "PARAGRAFO SEGUNDO: Las partes acuerdan como causal de finalizacion del presente vinculo contractual y de cualquier otro, cualquier evento que genere " & _
                "indicio, sospecha o confirmacion de nexos con LA/FT. PARAGRAFO TERCERO: Con la firma del presente documento me comprometo a comunicar cualquier tipo " & _
                "de anomalia referente a LA-FT a ISMOCOL y a las autoridades  competentes. DECIMA SEXTA - MODIFICACIONES: Cualquier modificación del presente contrato " & _
                "deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones legales y no " & _
                "contiene estipulaciones o condiciones que desmejoren la  situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento."
    End Function

    ''' <summary>
    ''' version anterior Minuta  CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol).
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF122v(nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Return "Entre los suscritos a saber por una parte " & nombreResidente & ", identificado con Cédula de Ciudadanía No. " & identificacionResidente & _
                " expedida en " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
                "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
                "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: PRIMERA - " & _
                "OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al cargo descrito " & _
                "anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
                "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
                "para el cabal cumplimiento de su encargo. SEGUNDA OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "Interno de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento Interno de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código de Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento Interno de Trabajo. TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento Interno de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado el trabajador " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. CUARTA – FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas " & _
                "en el Reglamento Interno de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar " & _
                "al pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo. QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas " & _
                "en el encabezamiento del contrato, un salario total consistente en la suma fija establecida inicialmente. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no " & _
                "hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando el TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso. PARÁGRAFO SEGUNDO: Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, " & _
                "alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún motivo " & _
                "constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo (Artículo " & _
                "15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o cualquier " & _
                "otra bonificación extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Cuando por causa emanada directa o " & _
                "indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no legalizados, herramientas y equipos en custodia, " & _
                "daños a elementos de trabajo, preaviso, etc. y, más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, " & _
                "entendiendo expresamente las partes que la presenta autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO " & _
                "CUARTO: Si durante el curso del presente contrato sobrevienen o se modifican los salarios o emolumentos extralegales por expresa disposición CONVENCIONAL " & _
                "debidamente aprobada por ECOPETROL, o si se llegare causar obligaciones de tipo económico con ocasión al vínculo laboral por parte del EMPLEADOR para con " & _
                "el TRABAJADOR, las partes acuerdan que EL EMPLEADOR podrá efectuar el pago de los correspondientes reajustes o reliquidaciones por medio de transferencia " & _
                "electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario. SEXTA – JORNADA ORDINARIA DE TRABAJO: EL " & _
                "TRABAJADOR se obliga a laborar la jornada ordinaria convencional en los turnos y dentro de las horas señaladas por EL EMPLEADOR, pudiendo hacer este " & _
                "ajuste o cambios de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o tácito de las " & _
                "partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, modificado por el " & _
                "Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no se computan dentro de las mismas, según " & _
                "el Artículo 167 ibídem. SÉPTIMA – EXCLUSIÓN DE JORNADA MÁXIMA: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo de dirección, confianza y " & _
                "manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima convencional ni legal de trabajo de que trata el artículo 162 del " & _
                "Código Sustantivo del Trabajo, por lo tanto no tendrá derecho al reconocimiento económico por laborar horas extras. OCTAVA – TERMINO DE DURACIÓN DEL " & _
                "CONTRATO: El término inicial del contrato será el establecido inicialmente en el encabezado del presente contrato. Si antes de la fecha de vencimiento de " & _
                "este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el contrato, con antelación no inferior a (30) treinta " & _
                "días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Las partes acuerdan expresamente que las prorrogas por un periodo igual o " & _
                "inferior podrán efectuarse en cualquier tiempo. Tratándose de un contrato a término fijo interior a (1) un año, únicamente podrá prorrogarse sucesivamente " & _
                "el contrato hasta por tres (3) periodos iguales o inferiores, si al cabo de los cuales no se notifica su terminación, el término de renovación no podrá " & _
                "ser inferior a (1) un año, y así sucesivamente. En cumplimiento de lo previsto en el Artículo 3 de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago " & _
                "de vacaciones y prima de servicios en proporción al tiempo laborado, cualquiera que esta sea. PARÁGRAFO PRIMERO: El contrato también podrá terminar en " & _
                "cualquier momento y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito ó si el contratante para el cual se desarrollen las " & _
                "labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o definitivamente el contrato principal, o reducir los trabajos " & _
                "contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, el trabajador se encuentra incapacitado por su EPS o ARL ya " & _
                "sea por enfermedad general o accidente común, enfermedad profesional o accidente de trabajo, desde ya se entenderá que los efectos del presente contrato " & _
                "de trabajo serán extendidos por el tiempo que el trabajador permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS o la " & _
                "ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. PARÁGRAFO TERCERO: Si al momento de finalizar el presente contrato de trabajo, la " & _
                "trabajadora se encuentra en licencia de maternidad debidamente expedida por su EPS, desde ya se entenderá que los efectos del presente contrato de " & _
                "trabajo serán extendidos por el tiempo de vigencia de la licencia en cuestión. PARÁGRAFO CUARTO: El contrato también podrá terminar en cualquier momento " & _
                "y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito ó si el contratante ECOPETROL decide por cualquier motivo suspender " & _
                "temporal o definitivamente el contrato principal. NOVENA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte del término " & _
                "inicial de este contrato, y en todo caso no es superior a (2) dos meses; en caso de prórroga, se entenderá que no hay un nuevo periodo de prueba, de " & _
                "acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. Durante este periodo tanto " & _
                "EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización alguna, en forma unilateral " & _
                "de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. DECIMA – JUSTAS CAUSAS PARA DAR POR " & _
                "TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquier de las partes, las enumeradas en el Artículo 7 " & _
                "del Decreto 2351/65; y, además por parte de EL EMPLEADOR, el incumplimientos de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas " & _
                "en la cláusulas segunda y cuarta, y las demás faltas que para el efecto se califiquen como graves en el espacio reservado para cláusulas adicionales en el " & _
                "presente contrato, el Reglamento Interno de Trabajo, Circulares Normativas y las demás comunicaciones emanadas de EL EMPLEADOR en donde se estipulen. " & _
                "DECIMA PRIMERA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR llegare a efectuar algún tipo " & _
                "de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR estos quedaran de propiedad " & _
                "exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. EL EMPLEADOR, tendrá derecho a patentar " & _
                "en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el cumplimiento oportuno de las formalidades " & _
                "exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, sin que por ello EL EMPLEADOR quede " & _
                "obligado al pago de suma de dinero o compensación alguna. DECIMA SEGUNDA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: El TRABAJADOR autoriza al " & _
                "EMPLEADOR para almacenar por tiempo indefinido los datos personales (incluyendo datos sensibles) que ha suministrado con ocasión de la suscripción este " & _
                "contrato de trabajo, los cuales sólo serán usados por el EMPLEADOR dentro de los procesos y eventos propios de su ejecución. El TRABAJADOR acepta que sus " & _
                "datos pueden ser transferidos al beneficiario de la obra para la que ha sido vinculado y/o su interventor, solo para fines de auditoría y mantenimiento " & _
                "del control y seguridad al interior de sus instalaciones. El EMPLEADOR realizará un tratamiento responsable y seguro de los datos suministrados, conforme " & _
                "las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. DECIMA TERCERA - ORDEN PUBLICO: EL TRABAJADOR es consciente y conocedor de las " & _
                "condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la actividad laboral que va a " & _
                "desarrollar y se compromete a cumplir de manera especial con todas las normas instrucciones y ordenes que manera particular o general se hagan en materia " & _
                "de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable por el pago de rescate o " & _
                "concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y demás normas reglamentarias. DECIMA " & _
                "CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social y dentro de las actividades que da " & _
                "origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como representante ni intermediario de " & _
                "ECOPETROL, por lo tanto no existe ni existirá en ningún momento relación laboral entre EL TRABAJADOR y ECOPETROL, toda vez que el único y verdadero " & _
                "EMPLEADOR de éste es y será ISMOCOL S.A. DECIMA QUINTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): Con la firma del presente " & _
                "documento o la entrega de la información aquí solicitada, declaro que mis recursos provienen de actividades lícitas y están ligados al desarrollo normal " & _
                "de mis actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o en " & _
                "cualquier norma que lo sustituya, adicione o modifique; declaro que no me encuentro en las listas internacionales vinculantes para Colombia de conformidad " & _
                "con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tengo nexos tanto sociales como " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: Autorizo a ISMOCOL S.A. para utilizar mi " & _
                "información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la empresa, para prevenir los riesgos asociados a " & _
                "LA/FT. PARÁGRAFO SEGUNDO: Las partes acuerdan como causal de finalización del presente vinculo contractual y de cualquier otro, cualquier evento que " & _
                "genere indicio, sospecha o confirmación de nexos con LA/FT. PARÁGRAFO TERCERO: Con la firma del presente documento me comprometo a comunicar cualquier " & _
                "tipo de anomalía referente a LA-FT a ISMOCOL y a las autoridades competentes. DECIMA SEXTA - MODIFICACIONES: Cualquier modificación del presente contrato " & _
                "deberá efectuarse por escrito mediante otro si. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones legales y " & _
                "convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las " & _
                "partes quedan expresamente comprometidas a darle cabal cumplimiento."
    End Function

    ''' <summary>
    '''version anterior Minuta   Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES DE DIRECCION, CONFIANZA Y MANEJO CON SALARIO INTEGRAL.
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF121v(nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Return "Entre los suscritos a saber por una parte " & nombreResidente & ", identificado con Cédula de Ciudadanía No. " & identificacionResidente & _
                " expedida en " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
                "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
                "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas : PRIMERA - " & _
                "OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al cargo descrito " & _
                "anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
                "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
                "para el cabal cumplimiento de su encargo. SEGUNDA OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "Interno de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento Interno de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones " & _
                "y órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento Interno de Trabajo. TERCERA – FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento Interno de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado el trabajador " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas " & _
                "en el Reglamento Interno de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar " & _
                "al pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo. QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas " & _
                "en el encabezamiento del contrato, un salario total consistente en la suma fija establecida inicialmente. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO " & _
                "PRIMERO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal " & _
                "trabajo no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando el TRABAJADOR llegare a laborar domingos de forma " & _
                "ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso. PARÁGRAFO " & _
                "SEGUNDO: Queda claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro " & _
                "de alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por " & _
                "ningún motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del " & _
                "Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en " & _
                "H.S.E. o cualquier otra bonificación extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Cuando por causa emanada " & _
                "directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste " & _
                "procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no legalizados, herramientas y equipos " & _
                "en custodia, daños a elementos de trabajo, preaviso, etc. y, más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL " & _
                "TRABAJADOR, entendiendo expresamente las partes que la presenta autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. " & _
                "PARÁGRAFO CUARTO: Si durante el curso del presente contrato sobrevienen o se modifican los salarios o emolumentos extralegales o convencionales por expresa " & _
                "disposición de la compañía para la cual ISMOCOL S.A. es contratista, o se hayan causado obligaciones de tipo económico con ocasión al vínculo laboral por " & _
                "parte del EMPLEADOR para con el TRABAJADOR, las partes acuerdan que EL EMPLEADOR podrá efectuar el pago de los correspondientes reajustes o " & _
                "reliquidaciones por medio de transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario. " & _
                "SEXTA – JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL " & _
                "EMPLEADOR en el artículo 29 del Reglamento Interno de Trabajo, pudiendo hacer este ajuste o cambios de horario cuando lo estime conveniente, lo cual es " & _
                "aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma " & _
                "prevista en el artículo 164 del Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de " & _
                "descanso entre las secciones de la jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. SÉPTIMA - EXCLUSIÓN DE JORNADA MÁXIMA: Por " & _
                "tratarse de que EL TRABAJADOR va a desempeñar un cargo de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la " & _
                "jornada máxima legal de trabajo de que trata el artículo 162 del código sustantivo del Trabajo, por lo tanto no tendrá derecho al reconocimiento económico " & _
                "por laborar horas extras. OCTAVA – TERMINO DE DURACIÓN DEL CONTRATO: El término inicial del contrato será el establecido inicialmente en el encabezado del " & _
                "presente contrato. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no " & _
                "prorrogar el contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Las " & _
                "partes acuerdan expresamente que las prorrogas por un periodo igual o inferior podrán efectuarse en cualquier tiempo. PARÁGRAFO PRIMERO: El contrato " & _
                "también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito ó si el contratante para el " & _
                "cual se desarrollen las labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o definitivamente el contrato principal, " & _
                "o reducir los trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, el trabajador se encuentra incapacitado " & _
                "por su EPS o ARL ya sea por enfermedad general o accidente común, enfermedad profesional o accidente de trabajo, desde ya se entenderá que los efectos del " & _
                "presente contrato de trabajo serán extendidos por el tiempo que el trabajador permanezca incapacitado conforme a las certificaciones que para tal efecto " & _
                "expida la EPS o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. PARÁGRAFO TERCERO: Si al momento de finalizar el presente contrato de " & _
                "trabajo, la trabajadora se encuentra en licencia de maternidad debidamente expedida por su EPS, desde ya se entenderá que los efectos del presente contrato " & _
                "de trabajo serán extendidos por el tiempo de vigencia de la licencia en cuestión. NOVENA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la " & _
                "quinta parte del término inicial de este contrato, y en todo caso no es superior a (2) dos meses; en caso de prórroga, se entenderá que no hay un nuevo " & _
                "periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. Durante " & _
                "este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización alguna, en " & _
                "forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. DECIMA – JUSTAS " & _
                "CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquier de las partes, las " & _
                "enumeradas en el Artículo 7 del Decreto 2351/65; y, además por parte de EL EMPLEADOR, el incumplimientos de EL TRABAJADOR de cualquiera de las " & _
                "obligaciones y prohibiciones previstas en la cláusulas segunda y cuarta, y las demás faltas que para el efecto se califiquen como graves en el espacio " & _
                "reservado para cláusulas adicionales en el presente contrato, el Reglamento Interno de Trabajo, Circulares Normativas y las demás comunicaciones emanadas " & _
                "de EL EMPLEADOR en donde se estipulen. DECIMA PRIMERA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL " & _
                "EMPLEADOR llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL " & _
                "EMPLEADOR estos quedaran de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna. DECIMA SEGUNDA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN " & _
                "PERSONAL: El TRABAJADOR autoriza al EMPLEADOR para almacenar por tiempo indefinido los datos personales (incluyendo datos sensibles) que ha suministrado " & _
                "con ocasión de la suscripción este contrato de trabajo, los cuales sólo serán usados por el EMPLEADOR dentro de los procesos y eventos propios de su " & _
                "ejecución. El TRABAJADOR acepta que sus datos pueden ser transferidos al beneficiario de la obra para la que ha sido vinculado y/o su interventor, solo " & _
                "para fines de auditoría y mantenimiento del control y seguridad al interior de sus instalaciones. El EMPLEADOR realizará un tratamiento responsable y " & _
                "seguro de los datos suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. DECIMA TERCERA - ORDEN PÚBLICO: EL " & _
                "TRABAJADOR es consciente y conocedor de las condiciones de orden público que predominan en todo el territorio nacional y por lo tanto asume el riesgo que " & _
                "se deriva de la actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que " & _
                "manera particular o general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es " & _
                "ni será responsable por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley " & _
                "40/93 y demás normas reglamentarias. DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto " & _
                "social y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR " & _
                "y no como representante ni intermediario de ninguno de sus contratantes, por lo tanto no existe ni existirá en ningún momento relación laboral entre EL " & _
                "TRABAJADOR y los contratantes de ISMOCOL S.A., toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A., así EL TRABAJADOR preste sus " & _
                "servicios de manera temporal o permanente en el (los) proyecto(s) o contrato(s) que EL EMPLEADOR ejecute. DECIMA QUINTA - PREVENCIÓN EN LAVADO DE ACTIVOS " & _
                "Y FINANCIACIÓN DEL TERRORISMO (LA/FT): Con la firma del presente documento o la entrega de la información aquí solicitada, declaro que mis recursos " & _
                "provienen de actividades lícitas y están ligados al desarrollo normal de mis actividades, y que, por lo tanto, los mismos no provienen de ninguna " & _
                "actividad ilícita de las contempladas en el Código Penal Colombiano o en cualquier norma que lo sustituya, adicione o modifique; declaro que no me " & _
                "encuentro en las listas internacionales vinculantes para Colombia de conformidad con el derecho internacional (listas de las Naciones Unidas) o en las " & _
                "listas de la OFAC o cualquier otra , y que no tengo nexos tanto sociales como familiares con personas inmersas en lavado de activos y financiación del " & _
                "terrorismo. PARÁGRAFO PRIMERO: Autorizo a ISMOCOL S.A. para utilizar mi información personal en las verificaciones que considere pertinentes en los " & _
                "mecanismos establecidos por la empresa, para prevenir los riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: Las partes acuerdan como causal de finalización " & _
                "del presente vinculo contractual y de cualquier otro, cualquier evento que genere indicio, sospecha o confirmación de nexos con LA/FT. PARÁGRAFO TERCERO: " & _
                "Con la firma del presente documento me comprometo a comunicar cualquier tipo de anomalía referente a LA-FT a ISMOCOL y a las autoridades competentes. " & _
                "DECIMA SEXTA - MODIFICACIONES: Cualquier modificación del presente contrato deberá efectuarse por escrito mediante otro si. El presente contrato ha sido " & _
                "redactado de buena fe, en cumplimiento de las disposiciones legales y no contiene estipulaciones o condiciones que desmejoren la situación del " & _
                "trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan expresamente comprometidas a darle cabal cumplimiento."
    End Function

    ''' <summary>
    ''' version anterior Minuta  CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF118v(nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Return "Entre los suscritos a saber por una parte " & nombreResidente & ", identificado con Cédula de Ciudadanía No. " & identificacionResidente & _
                " expedida en " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo " & _
                "sucesivo se denomina EL EMPLEADOR, y por la otra EL TRABAJADOR, de las condiciones ya dichas, identificados como aparecen al pie de sus firmas, se ha " & _
                "celebrado el presente contrato individual de trabajo, regido además por las siguientes cláusulas: PRIMERA, OBJETO: EL EMPLEADOR contrata los servicios " & _
                "personales de EL TRABAJADOR para desempeñar en forma exclusiva las funciones inherentes al cargo descrito anteriormente así como la ejecución de las " & _
                "tareas ordinarias y anexas al mencionado cargo, de conformidad  con los reglamentos, ordenes, instrucciones que le imparta EL EMPLEADOR, observando en su " & _
                "cumplimiento la diligencia y el cuidado necesario. SEGUNDA OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, " & _
                "Reglamento Interno de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a " & _
                "cumplir con las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el " & _
                "desempeño de las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente " & _
                "servicios laborales a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio " & _
                "antes mencionado personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL " & _
                "EMPLEADOR en ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o " & _
                "destinarlo a cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento " & _
                "de ser contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento Interno de Trabajo, el  " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento Interno de Trabajo. TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento Interno de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado el trabajador " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez o se cause  un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento Interno de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo. QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en " & _
                "el encabezamiento del contrato, un salario total consistente en la suma fija establecida inicialmente. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no " & _
                "hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando el TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso. PARÁGRAFO SEGUNDO: Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, " & _
                "alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún motivo " & _
                "constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo (Artículo 15 " & _
                "Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o cualquier otra " & _
                "bonificación extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Todo trabajo suplementario o en horas extras y todo " & _
                "trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se remunerará conforme a la Ley, así como los correspondientes recargos " & _
                "nocturnos. Para que este trabajo nocturno, suplementario, dominical o festivo sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado previamente según " & _
                "el trámite previsto por la empresa; de no efectuarse no se reconocerá ninguna de estas actividades y se entenderán realizadas por mera liberalidad de EL " & _
                "TRABAJADOR. Cuando por circunstancias de fuerza mayor o necesidades apremiantes del servicio se deba laborar en horas extras, domingos o festivos las labores " & _
                "deberán ejecutarse y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la " & _
                "dependencia que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, suplementario o en días de descanso legalmente " & _
                "obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda dicho. PARÁGRAFO CUARTO: Cuando por causa emanada directa o " & _
                "indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar " & _
                "las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no legalizados, herramientas y equipos en custodia, daños a " & _
                "elementos de trabajo, preaviso, etc. y, más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo " & _
                "expresamente las partes que la presente autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO QUINTO: Si durante el " & _
                "curso del presente contrato sobrevienen o se modifican los salarios o emolumentos extralegales o convencionales por expresa disposición de la compañía para la " & _
                "cual ISMOCOL S.A., es contratista, o se hayan causado obligaciones de tipo económico con ocasión al vínculo laboral por parte del EMPLEADOR para con el " & _
                "TRABAJADOR, las partes acuerdan que EL EMPLEADOR podrá efectuar el pago de los correspondientes reajustes o reliquidaciones por medio de transferencia electrónica " & _
                "o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario. SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a " & _
                "laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR, pudiendo hacer este ajuste o cambios de horario cuando lo estime " & _
                "conveniente. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada " & _
                "no se computan dentro de las mismas, según el Artículo 167 ibídem. SÉPTIMA - TERMINO DE DURACIÓN DEL CONTRATO: El término inicial del contrato será el establecido " & _
                "inicialmente. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Tratándose de un contrato " & _
                "a término fijo inferior a (1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres (3) periodos iguales o inferiores, si al cabo de los " & _
                "cuales el término de renovación no podrá ser inferior a (1) un año; así sucesivamente. En cumplimiento de lo previsto en el Artículo 3 de la Ley 50/90, EL " & _
                "TRABAJADOR tendrá derecho al pago de vacaciones y prima de servicios en proporción al tiempo laborado, cualquiera que esta sea. PARÁGRAFO PRIMERO: El contrato " & _
                "también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito ó si el contratante para el cual se " & _
                "desarrollen las labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o definitivamente el contrato principal, o reducir los " & _
                "trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, el trabajador se encuentra incapacitado por su EPS o  ARL " & _
                "ya sea por enfermedad general o accidente común, enfermedad profesional o  accidente de trabajo, desde ya se entenderá que los efectos del presente contrato de " & _
                "trabajo serán extendidos por el tiempo que el trabajador permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS  o la ARL, " & _
                "según lo establecido el artículo 26 de la Ley 361 de 1997. PARÁGRAFO TERCERO: Si al momento de finalizar el presente contrato de trabajo, la trabajadora se " & _
                "encuentra en licencia de maternidad debidamente expedida por su EPS, desde ya se entenderá que los efectos del presente contrato de trabajo serán extendidos por " & _
                "el tiempo de vigencia de la licencia en cuestión. OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte del término inicial de " & _
                "este contrato, ni excede de (2) dos meses, en caso de prorroga, se entenderá que no hay un nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 " & _
                "del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90.  Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato " & _
                "en cualquier tiempo, sin que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el  Artículo 3 del decreto 617/54. NOVENA- JUSTAS CAUSAS PARA DAR POR TERMINADO DEL CONTRATO : Son justas causas para dar por terminado " & _
                "unilateralmente este contrato por cualquier de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65 ; y, además por parte de EL EMPLEADOR, el " & _
                "incumplimientos de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas en la cláusula segunda, y las demás faltas que para el efecto se " & _
                "califiquen como graves en el espacio reservado para cláusulas adicionales en el presente contrato.  DECIMA - INVENCIÓN Y DESCUBRIMIENTOS : Si durante el tiempo " & _
                "que EL TRABAJADOR preste sus servicios a EL EMPLEADOR llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de " & _
                "producción y/o administrativo de EL EMPLEADOR estos quedaran de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial " & _
                "como propiedad industrial. EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR " & _
                "facilitará el cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL " & _
                "EMPLEADOR, sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna. DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE " & _
                "INFORMACIÓN PERSONAL: El TRABAJADOR autoriza al EMPLEADOR para almacenar por tiempo indefinido los datos personales (incluyendo datos sensibles) que ha " & _
                "suministrado con ocasión de la suscripción este contrato de trabajo, los cuales sólo serán usados por el EMPLEADOR dentro de los procesos y eventos propios de " & _
                "su ejecución. El TRABAJADOR acepta que sus datos pueden ser transferidos al beneficiario de la obra para la que ha sido vinculado y/o su interventor, solo para " & _
                "fines de auditoría y mantenimiento del control y seguridad al interior de sus instalaciones. El EMPLEADOR realizará un tratamiento responsable y seguro de los " & _
                "datos suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. DECIMA SEGUNDA - ORDEN PUBLICO: EL TRABAJADOR es consciente " & _
                "y conocedor de las condiciones de orden público que predominan en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la actividad " & _
                "laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que manera particular o general se hagan " & _
                "en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable por el pago de rescate " & _
                "o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y demás normas reglamentarias. DECIMA " & _
                "TERCERA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social y dentro de las actividades que da origen a " & _
                "la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como representante ni intermediario de ninguno de sus " & _
                "contratantes, por lo tanto no existe ni existirá en ningún momento relación laboral entre EL TRABAJADOR y los contratantes de ISMOCOL S.A., toda vez que el único " & _
                "y verdadero EMPLEADOR de éste es y será ISMOCOL S.A., así EL TRABAJADOR preste sus servicios de manera temporal o permanente en el (los) proyecto(s) o " & _
                "contrato(s) que EL EMPLEADOR ejecute. DECIMA CUARTA - PREVENCION EN  LAVADO DE ACTIVOS Y  FINANCIACION DEL TERRORISMO (LA/FT): Con la firma del presente documento " & _
                "o la entrega de la informacion aqui solicitada, declaro que mis recursos provienen de actividades lícitas y están ligados al desarrollo normal de mis actividades, " & _
                "y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o en cualquier norma  que lo " & _
                "sustituya, adicione o modifique; declaro que no me encuentro en las listas internacionales vinculantes para Colombia de conformidad con el derecho internacional " & _
                "(listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tengo nexos tanto sociales como familiares con personas inmersas en lavado " & _
                "de activos y financiacion del terrorismo. PARAGRAFO PRIMERO: Autorizo a ISMOCOL S.A. para utilizar mi informacion personal en las verificaciones que considere " & _
                "pertinentes en los mecanismos establecidos por la empresa, para previnir los riesgos asociados a LA/FT. PARAGRAFO SEGUNDO: Las partes acuerdan como causal de " & _
                "finalizacion del presente vinculo contractual y de cualquier otro, cualquier evento que genere indicio, sospecha o confirmacion de nexos con LA/FT. PARAGRAFO " & _
                "TERCERO: Con la firma del presente documento me comprometo a comunicar cualquier tipo de anomalia referente a LA-FT a ISMOCOL y a las autoridades competentes. " & _
                "DECIMA QUINTA - Este contrato ha sido redactado estrictamente de acuerdo a la Ley y a la Jurisprudencia y será interpretado de buena fe y en consonancia con " & _
                "el Código Sustantivo del Trabajo cuyo objeto, definido en su Artículo 1 es lograr la justicia en las relaciones entre empleadores y trabajadores."
    End Function

    ''' <summary>
    ''' version anterior Minuta CONTRATO DE TRABAJO A TERMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCION, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF123v(nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Return "Entre los suscritos a saber por una parte " & nombreResidente & ", identificado con Cédula de Ciudadanía No. " & identificacionResidente & _
                " expedida en " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
                "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
                "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: PRIMERA - " & _
                "OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al cargo descrito " & _
                "anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
                "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
                "para el cabal cumplimiento de su encargo. SEGUNDA OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "Interno de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento Interno de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento Interno de Trabajo. TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento Interno de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado el trabajador " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de " & _
                "la Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas " & _
                "en el Reglamento Interno de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar " & _
                "al pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo. QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas " & _
                "en el encabezamiento del contrato, un salario total consistente en la suma fija establecida inicialmente. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no " & _
                "hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando el TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso. PARÁGRAFO SEGUNDO: Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de " & _
                "alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por " & _
                "ningún motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del " & _
                "Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño " & _
                "en H.S.E. o cualquier otra bonificación extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Todo trabajo " & _
                "suplementario o en horas extras y todo trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se remunerará conforme a la Ley, " & _
                "así como los correspondientes recargos nocturnos. Para que este trabajo nocturno, suplementario, dominical o festivo sea reconocido y cancelado, EL " & _
                "EMPLEADOR debe haberlo autorizado previamente según el trámite previsto por la empresa; de no efectuarse no se reconocerá ninguna de estas actividades y " & _
                "se entenderán realizadas por mera liberalidad de EL TRABAJADOR. Cuando por circunstancias de fuerza mayor o necesidades apremiantes del servicio se deba " & _
                "laborar en horas extras, domingos o festivos las labores deberán ejecutarse y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, " & _
                "previo visto bueno de su superior jerárquico o del jefe de la dependencia que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún " & _
                "trabajo nocturno, suplementario o en días de descanso legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda " & _
                "dicho. PARÁGRAFO CUARTO: Cuando por causa emanada directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de " & _
                "EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, " & _
                "anticipos no legalizados, herramientas y equipos en custodia, daños a elementos de trabajo, preaviso, etc. y, más concretamente, a la terminación del " & _
                "presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presenta autorización cumple las condiciones de " & _
                "orden escrita previa, aplicable para cada caso. PARÁGRAFO QUINTO: Si durante el curso del presente contrato sobrevienen o se modifican los salarios o " & _
                "emolumentos extralegales por expresa disposición CONVENCIONAL debidamente aprobada por ECOPETROL, o si se llegare causar obligaciones de tipo económico " & _
                "con ocasión al vínculo laboral por parte del EMPLEADOR para con el TRABAJADOR, las partes acuerdan que EL EMPLEADOR podrá efectuar el pago de los " & _
                "correspondientes reajustes o reliquidaciones por medio de transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR " & _
                "recibió el pago de su salario. SEXTA – JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria convencional en los turnos " & _
                "y dentro de las horas señaladas por EL EMPLEADOR, pudiendo hacer este ajuste o cambios de horario cuando lo estime conveniente, lo cual es aceptado de " & _
                "ante mano por EL TRABAJADOR. Por el acuerdo expreso o tácito de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en " & _
                "el artículo 164 del Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre " & _
                "las secciones de la jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término " & _
                "inicial del contrato será el establecido inicialmente. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a " & _
                "la otra su determinación de no prorrogar el contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al " & _
                "inicialmente pactado. Tratándose de un contrato a término fijo interior a (1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por " & _
                "tres (3) periodos iguales o inferiores, si al cabo de los cuales el término de renovación no podrá ser inferior a (1) un año; así sucesivamente. En " & _
                "cumplimiento de lo previsto en el Artículo 3 de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de servicios en proporción al " & _
                "tiempo laborado, cualquiera que esta sea. PARÁGRAFO PRIMERO: El contrato también podrá terminar en cualquier momento y antes del periodo pactado por " & _
                "circunstancias de fuerza mayor o caso fortuito ó si el contratante para el cual se desarrollen las labores a las que se encuentra asignado, decide por " & _
                "cualquier motivo suspender temporal o definitivamente el contrato principal, o reducir los trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de " & _
                "finalizar el presente contrato de trabajo, el trabajador se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o accidente común, " & _
                "enfermedad profesional o accidente de trabajo, desde ya se entenderá que los efectos del presente contrato de trabajo serán extendidos por el tiempo que " & _
                "el trabajador permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo establecido el artículo 26 de " & _
                "la Ley 361 de 1997. PARÁGRAFO TERCERO: Si al momento de finalizar el presente contrato de trabajo, la trabajadora se encuentra en licencia de maternidad " & _
                "debidamente expedida por su EPS, desde ya se entenderá que los efectos del presente contrato de trabajo serán extendidos por el tiempo de vigencia de la " & _
                "licencia en cuestión. PARÁGRAFO CUARTO: El contrato también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza " & _
                "mayor o caso fortuito ó si el contratante ECOPETROL decide por cualquier motivo suspender temporal o definitivamente el contrato principal. OCTAVA – " & _
                "PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte del término inicial de este contrato, ni excede de (2) dos meses, en caso " & _
                "de prórroga, se entenderá que no hay un nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 7 de la Ley 50/90. Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin " & _
                "que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el " & _
                "Artículo 3 del decreto 617/54. NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este " & _
                "contrato por cualquier de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65; y, además por parte de EL EMPLEADOR, el incumplimientos de EL " & _
                "TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas en la cláusulas segunda y cuarta, y las demás faltas que para el efecto se " & _
                "califiquen como graves en el espacio reservado para cláusulas adicionales en el presente contrato, el Reglamento Interno de Trabajo, Circulares Normativas " & _
                "y las demás comunicaciones emanadas de EL EMPLEADOR en donde se estipulen. DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR " & _
                "preste sus servicios a EL EMPLEADOR llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción " & _
                "y/o administrativo de EL EMPLEADOR estos quedaran de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial " & _
                "como propiedad industrial. EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL " & _
                "TRABAJADOR facilitará el cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así " & _
                "lo solicite EL EMPLEADOR, sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna. DECIMA PRIMERA - AUTORIZACIÓN DE " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: El TRABAJADOR autoriza al EMPLEADOR para almacenar por tiempo indefinido los datos personales (incluyendo datos " & _
                "sensibles) que ha suministrado con ocasión de la suscripción este contrato de trabajo, los cuales sólo serán usados por el EMPLEADOR dentro de los " & _
                "procesos y eventos propios de su ejecución. El TRABAJADOR acepta que sus datos pueden ser transferidos al beneficiario de la obra para la que ha sido " & _
                "vinculado y/o su interventor, solo para fines de auditoría y mantenimiento del control y seguridad al interior de sus instalaciones. El EMPLEADOR " & _
                "realizará un tratamiento responsable y seguro de los datos suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la " & _
                "reglamentan. DECIMA SEGUNDA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y conocedor de las condiciones de orden público que predomina en todo el " & _
                "territorio nacional y por lo tanto asume el riesgo que se deriva de la actividad laboral que va a desarrollar y se compromete a cumplir de manera " & _
                "especial con todas las normas instrucciones y ordenes que manera particular o general se hagan en materia de seguridad física; por lo tanto, en caso " & _
                "de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable por el pago de rescate o concepto similar a favor de sus captores, " & _
                "por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y demás normas reglamentarias. DECIMA TERCERA – CONTRATISTA INDEPENDIENTE: " & _
                "Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social y dentro de las actividades que da origen a la presente relación laboral, " & _
                "actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como representante ni intermediario de ECOPETROL, por lo tanto no existe ni " & _
                "existirá en ningún momento relación laboral entre EL TRABAJADOR y ECOPETROL, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A. " & _
                "DECIMA CUARTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): Con la firma del presente documento o la entrega de la información " & _
                "aquí solicitada, declaro que mis recursos provienen de actividades lícitas y están ligados al desarrollo normal de mis actividades, y que, por lo tanto, " & _
                "los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o en cualquier norma que lo sustituya, adicione o " & _
                "modifique; declaro que no me encuentro en las listas internacionales vinculantes para Colombia de conformidad con el derecho internacional (listas de las " & _
                "Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tengo nexos tanto sociales como familiares con personas inmersas en lavado de " & _
                "activos y financiación del terrorismo. PARÁGRAFO PRIMERO: Autorizo a ISMOCOL S.A. para utilizar mi información personal en las verificaciones que " & _
                "considere pertinentes en los mecanismos establecidos por la empresa, para prevenir los riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: Las partes acuerdan " & _
                "como causal de finalización del presente vinculo contractual y de cualquier otro, cualquier evento que genere indicio, sospecha o confirmación de nexos " & _
                "con LA/FT. PARÁGRAFO TERCERO: Con la firma del presente documento me comprometo a comunicar cualquier tipo de anomalía referente a LA-FT a ISMOCOL y a las " & _
                "autoridades competentes. DECIMA QUINTA - MODIFICACIONES: Cualquier modificación del presente contrato deberá efectuarse por escrito mediante otro si. El " & _
                "presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones legales y convencionales y no contiene estipulaciones o condiciones " & _
                "que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan expresamente comprometidas a darle cabal " & _
                "cumplimiento."
    End Function






    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO.
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF117(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas:"
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " &
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " &
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en " & _
                "el encabezamiento del contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo " & _
                "no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y " & _
                "disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO SEGUNDO : Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de " & _
                "alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo " & _
                "(Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o " & _
                "cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Cuando por causa emanada directa " & _
                "o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no cancelados, herramientas y equipos en custodia, " & _
                "daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos pendientes por descuento, etc., y más " & _
                "concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente " & _
                "autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO CUARTO: Cualquier obligación económica por pagar de " & _
                "El EMPLEADOR a EL TRABAJADOR, aun cuando sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante " & _
                "transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA – JORNADA ORDINARIA " & _
                "DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el " & _
                "Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo " & _
                "de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima legal de trabajo de que trata el artículo 162 " & _
                "del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho al reconocimiento económico por laborar horas extras. "
            Case 7
                Return "SÉPTIMA – TÉRMINO DE DURACIÓN DEL CONTRATO: El término inicial del contrato será el establecido inicialmente en el encabezado del presente " & _
                "contrato. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Las partes acuerdan " & _
                "expresamente que las prórrogas por un periodo igual o inferior podrán efectuarse en cualquier tiempo. Tratándose de un contrato a término fijo inferior a " & _
                "(1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres (3) periodos iguales o inferiores, si al cabo de los cuales no se " & _
                "notifica su terminación, el término de renovación no podrá ser inferior a (1) un año, y así sucesivamente. En cumplimiento de lo previsto en el Artículo 3 " & _
                "de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de servicios en proporción al tiempo laborado, cualquiera que esta sea. " & _
                "PARÁGRAFO PRIMERO: El contrato también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito " & _
                "ó si el contratante para el cual se desarrollen las labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o " & _
                "definitivamente el contrato principal, o reducir los trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, " & _
                "EL TRABAJADOR se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o accidente común, enfermedad laboral o accidente de " & _
                "trabajo, los efectos del contrato de trabajo podrán ser extendidos por el tiempo que EL TRABAJADOR permanezca incapacitado " & _
                "conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única " & _
                "y exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, " & _
                "sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO TERCERO: Si al momento de finalizar el contrato de " & _
                "trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que le genere estabilidad laboral reforzada, " & _
                "los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la Compañía determine que las condiciones " & _
                "de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las " & _
                "prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para " & _
                "prestar su servicio. PARÁGRAFO CUARTO: Si al momento de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA " & _
                "(mujer) de su estado de embarazo, los efectos del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones asistenciales y económicas a cargo del Sistema " & _
                "de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es requerida para prestar su servicio. PARÁGRAFO QUINTO: Para EL " & _
                "TRABAJADOR quien al momento de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su esposa o compañera " & _
                "permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la finalización de la licencia de maternidad de ésta, siempre " & _
                "y cuando la cónyuge o compañera se encuentre afiliada como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL " & _
                "TRABAJADOR. Si cambia el requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos parámetros establecidos por la " & _
                "jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR " & _
                "y su cónyuge o compañera de este, las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda " & _
                " que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la vigencia de su contrato " & _
                "de trabajo y para su propia defensa ante autoridades administrativas y judiciales. "
            Case 8
                Return " OCTAVA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba " & _
                "la quinta parte del término inicial de este contrato, que en todo caso no es superior a (2) dos meses, en caso de prórroga, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. " & _
                "Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización " & _
                "alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. "
            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR. "
            Case 10
                Return " DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna. "
            Case 11
                Return " DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE " & _
                "INFORMACIÓN PERSONAL: EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía. "
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE " & _
                "ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO (Convención USO - Ecopetrol).
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF122(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
               "para el cabal cumplimiento de su encargo. "
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a " & _
                "pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del contrato, un salario total consistente en la suma fija " & _
                "establecida al encabezado. Teniendo en cuenta que EL TRABAJADOR es contratado para la ejecución de un proyecto al que " & _
                "contractualmente deben aplicarse unos beneficios contemplados en la Convención Colectiva de Trabajo suscrita entre ECOPETROL S.A. y " & _
                "la UNION SINDICAL OBRERA-USO, el salario y los beneficios convencionales corresponden a lo dispuesto en la Guía de Aspectos y " & _
                "Condiciones Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, reemplace o " & _
                "adicione mientras se encuentre vigente el presente contrato de trabajo. Dentro de este pago se encuentra incluida la remuneración de los " & _
                "descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "EL TRABAJADOR comprende y acepta los beneficios salariales y no salariales, establecidos en la Guía de Aspectos y Condiciones " & _
                "Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione. " & _
                "PARÁGRAFO SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá " & _
                "derecho a remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, " & _
                "cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta " & _
                "que la remuneración del trabajo sea compensado con descanso el cual podrá ser acumulado y disfrutado dentro de la " & _
                "programación de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto " & _
                "cualquier suministro de alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, " & _
                "se entenderá que lo hace por mera liberalidad y por ningún motivo constituirá salario en especie, igualmente se conviene " & _
                "que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) " & _
                "tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen " & _
                "desempeño en H.S.E. o cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier " & _
                "efecto. PARÁGRAFO CUARTO: Todo trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se " & _
                "remunerará conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este trabajo nocturno, suplementario, dominical " & _
                "o festivo sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado previamente según el trámite previsto por la empresa; de " & _
                "no efectuarse no se reconocerá ninguna de estas actividades y se entenderán realizadas por mera liberalidad de EL TRABAJADOR. " & _
                "Cuando por circunstancias de fuerza mayor o necesidades apremiantes del servicio se deba laborar domingos o festivos las labores deberán " & _
                "ejecutarse y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la " & _
                "dependencia que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, suplementario o en días de " & _
                "descanso legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda dicho. PARÁGRAFO " & _
                "QUINTO: Cuando por causa emanada directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de " & _
                "EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por " & _
                "concepto de préstamos, anticipos no legalizados, herramientas y equipos en custodia, daños a elementos de trabajo, " & _
                "conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos pendientes por descuento, " & _
                "etc., y más concretamente, a la terminación del presente contrato, así lo concretamente, a la terminación " & _
                "del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la " & _
                "presente autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO SEXTO: Si durante el " & _
                "curso del presente contrato se modifican los salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR " & _
                "por expresa disposición de la compañía de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes " & _
                "una vez dicha compañía (cliente) le notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial " & _
                "dispuesto en la Guía de Aspectos y Condiciones Laborales en Actividades Contratadas por ECOPETROL S.A. o el documento que lo " & _
                "modifique, reemplace o adicione. PARÁGRAFO SÉPTIMO: Cualquier obligación económica por pagar de El EMPLEADOR a EL " & _
                "TRABAJADOR, aun cuando sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél " & _
                "mediante transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario. "
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las " & _
                "horas señaladas por EL EMPLEADOR de conformidad con lo dispuesto en la Guía de Aspectos y Condiciones Laborales en Actividades " & _
                "Contratadas por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione, o en su defecto o en caso que esta no aplique " & _
                "en la jornada establecida en el artículo 29 del Reglamento de Trabajo, pudiendo hacer este ajuste o cambios de horario cuando lo estime " & _
                "conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las " & _
                "horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley " & _
                "50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no se computan dentro de las mismas, según el " & _
                "Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo de " & _
                "dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima " & _
                "legal de trabajo de que trata el artículo 162 del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho " & _
                "al reconocimiento económico por laborar horas extras."
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término inicial de este contrato será el establecido al encabezado. Si antes " & _
                "de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado.  " & _
                "Tratándose de un contrato a término fijo inferior a (1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres " & _
                "(3) periodos iguales o inferiores, si al cabo de los cuales el término de renovación no podrá ser inferior a (1) un año; así sucesivamente. " & _
                "En cumplimiento de lo previsto en el Artículo 3 de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de " & _
                "servicios en proporción al tiempo laborado, cualquiera que esta sea. PARÁGRAFO PRIMERO: Si al momento de finalizar " & _
                "el presente contrato de trabajo, EL TRABAJADOR se encuentra incapacitado por su EPS o  ARL ya sea por enfermedad general " & _
                "o accidente común, enfermedad laboral o  accidente de trabajo, los efectos del contrato de trabajo podrán ser extendidos por " & _
                "el tiempo que EL TRABAJADOR permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS  o la ARL, " & _
                "según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR " & _
                "las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL " & _
                "TRABAJADOR aun es requerido para prestar su servicio.  PARÁGRAFO SEGUNDO: Si al momento de finalizar el contrato de trabajo, " & _
                "EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que le genere estabilidad " & _
                "laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la " & _
                "Compañía determine que las condiciones de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO TERCERO: Si al momento " & _
                "de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA (mujer) de su estado de " & _
                "embarazo, los efectos  del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es " & _
                "requerida para prestar su servicio. PARÁGRAFO CUARTO: Para EL TRABAJADOR quien al momento " & _
                "de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su " & _
                "esposa o compañera permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la " & _
                "finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge o compañera se encuentre afiliada " & _
                "como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL TRABAJADOR. Si cambia el " & _
                "requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos " & _
                "parámetros establecidos por la jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR y su cónyuge o compañera de este, las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es " & _
                "requerido para prestar su servicio. PARÁGRAFO QUINTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la " & _
                "vigencia de su contrato de trabajo y para su propia defensa ante autoridades administrativas y judiciales."
            Case 8
                Return "OCTAVA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba " & _
                "la quinta parte del término inicial de este contrato, que en todo caso no es superior a (2) dos meses, en caso de prórroga, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. " & _
                "Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización " & _
                "alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. "
            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES DE DIRECCION, CONFIANZA Y MANEJO CON SALARIO INTEGRAL.
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF121(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " &
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " &
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado " & _
                "EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del " & _
                "contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la remuneración de " & _
                "los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO " & _
                "PRIMERO: EL TRABAJADOR acepta y comprende que el salario indicado en el encabezado del presente contrato retribuye el trabajo " & _
                "ordinadio, y compensa de antemano el valor de las prestaciones, recargos y beneficios tales como los correspondientes al trabajo nocturno, " & _
                "extraordinario y al dominical y festivo, el valor de primas legales, extralegales, las cesantías y sus intereses, subsidios y suministros en especie, " & _
                "lo anterior, en virtud de lo establecido en el artículo 132 del Código Sustantivo del Trabajo. PARÁGRAFO " & _
                "SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a " & _
                "remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL " & _
                "TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la " & _
                "remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y disfrutado dentro de la programación " & _
                "de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda claramente entendido que " & _
                "EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, " & _
                "alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y " & _
                "por ningún motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 " & _
                "del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, " & _
                "de Finalización de Obra, de buen desempeño en H.S.E. o cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de " & _
                "salario para cualquier efecto. PARÁGRAFO CUARTO: Cuando por causa emanada directa o indirectamente de la relación contractual " & _
                "existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones " & _
                "a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no cancelados, herramientas y equipos en " & _
                "custodia, daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos " & _
                "pendientes por descuento, etc., y más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora " & _
                "EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización cumple las condiciones de orden escrita previa, " & _
                "aplicable para cada caso. PARÁGRAFO QUINTO: Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando " & _
                "sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia " & _
                "electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario. "

            Case 6
                Return "SEXTA – JORNADA ORDINARIA " & _
                "DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el " & _
                "Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo " & _
                "de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima legal de trabajo de que trata el artículo 162 " & _
                "del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho al reconocimiento económico por laborar horas extras. "
            Case 7
                Return "SÉPTIMA – TÉRMINO DE DURACIÓN DEL CONTRATO: El término inicial del contrato será el establecido inicialmente en el encabezado del presente " & _
                "contrato. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Las partes acuerdan " & _
                "expresamente que las prórrogas por un periodo igual o inferior podrán efectuarse en cualquier tiempo. Tratándose de un contrato a término fijo inferior a " & _
                "(1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres (3) periodos iguales o inferiores, si al cabo de los cuales no se " & _
                "notifica su terminación, el término de renovación no podrá ser inferior a (1) un año, y así sucesivamente. En cumplimiento de lo previsto en el Artículo 3 " & _
                "de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de servicios en proporción al tiempo laborado, cualquiera que esta sea. " & _
                "PARÁGRAFO PRIMERO: El contrato también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito " & _
                "ó si el contratante para el cual se desarrollen las labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o " & _
                "definitivamente el contrato principal, o reducir los trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, " & _
                "EL TRABAJADOR se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o accidente común, enfermedad laboral o accidente de " & _
                "trabajo, los efectos del contrato de trabajo podrán ser extendidos por el tiempo que EL TRABAJADOR permanezca incapacitado " & _
                "conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única " & _
                "y exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, " & _
                "sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO TERCERO: Si al momento de finalizar el contrato de " & _
                "trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que le genere estabilidad laboral reforzada, " & _
                "los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la Compañía determine que las condiciones " & _
                "de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las " & _
                "prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para " & _
                "prestar su servicio. PARÁGRAFO CUARTO: Si al momento de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA " & _
                "(mujer) de su estado de embarazo, los efectos del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones asistenciales y económicas a cargo del Sistema " & _
                "de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es requerida para prestar su servicio. PARÁGRAFO QUINTO: Para EL " & _
                "TRABAJADOR quien al momento de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su esposa o compañera " & _
                "permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la finalización de la licencia de maternidad de ésta, siempre " & _
                "y cuando la cónyuge o compañera se encuentre afiliada como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL " & _
                "TRABAJADOR. Si cambia el requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos parámetros establecidos por la " & _
                "jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR " & _
                "y su cónyuge o compañera de este, las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda " & _
                " que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la vigencia de su contrato " & _
                "de trabajo y para su propia defensa ante autoridades administrativas y judiciales. "
            Case 8
                Return " OCTAVA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba " & _
                "la quinta parte del término inicial de este contrato, que en todo caso no es superior a (2) dos meses, en caso de prórroga, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. " & _
                "Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización " & _
                "alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. "
            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCIÓN, CONFIANZA Y MANEJO
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF118(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " &
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " &
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a " & _
                "pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del contrato, un salario total consistente en la suma fija " & _
                "establecida al encabezado. Dentro de este pago se encuentra incluida la remuneración de los descansos dominicales y festivos de que " & _
                "tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: Si por cualquier circunstancia EL " & _
                "TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no hubiere sido " & _
                "autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma " & _
                "ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso, " & _
                "el cual podrá ser acumulado y disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos por " & _
                "EL EMPLEADOR. PARÁGRAFO SEGUNDO: Queda claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna " & _
                "clase de salario en especie, por lo tanto cualquier suministro de alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o " & _
                "cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún motivo constituirá salario en especie, igualmente se " & _
                "conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen " & _
                "carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o cualquier " & _
                "otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Todo trabajo " & _
                "suplementario o en horas extras y todo trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se remunerará " & _
                "conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este trabajo nocturno, suplementario, dominical o festivo " & _
                "sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado previamente según el trámite previsto por la empresa; de no efectuarse " & _
                "no se reconocerá ninguna de estas actividades y se entenderán realizadas por mera liberalidad de EL TRABAJADOR. Cuando por circunstancias " & _
                "de fuerza mayor o necesidades apremiantes del servicio se deba laborar en horas extras, domingos o festivos las labores deberán ejecutarse " & _
                "y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la dependencia " & _
                "que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, suplementario o en días de descanso " & _
                "legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda dicho. PARÁGRAFO CUARTO: Cuando " & _
                "por causa emanada directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR " & _
                "y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, " & _
                "anticipos no legalizados, herramientas y equipos en custodia, daños a elementos de trabajo, conceptos pagados " & _
                "a los cuales no tenía derecho, embargos pendientes por descuento, preaviso, etc., y más concretamente, a la terminación del " & _
                "presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización " & _
                "cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO QUINTO: Si durante el curso del presente contrato " & _
                "se modifican los salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR por expresa disposición de la " & _
                "compañía de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes una vez dicha compañía " & _
                "(cliente) le notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial. PARÁGRAFO SEXTO: " & _
                "Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando sobrevenga con posterioridad a la " & _
                "terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia electrónica o consignación a la última cuenta " & _
                "bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA – JORNADA ORDINARIA " & _
                "DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el " & _
                "Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem."
            Case 7
                Return "SÉPTIMA – TÉRMINO DE DURACIÓN DEL CONTRATO: El término inicial del contrato será el establecido inicialmente en el encabezado del presente " & _
                "contrato. Si antes de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado. Las partes acuerdan " & _
                "expresamente que las prórrogas por un periodo igual o inferior podrán efectuarse en cualquier tiempo. Tratándose de un contrato a término fijo inferior a " & _
                "(1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres (3) periodos iguales o inferiores, si al cabo de los cuales no se " & _
                "notifica su terminación, el término de renovación no podrá ser inferior a (1) un año, y así sucesivamente. En cumplimiento de lo previsto en el Artículo 3 " & _
                "de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de servicios en proporción al tiempo laborado, cualquiera que esta sea. " & _
                "PARÁGRAFO PRIMERO: El contrato también podrá terminar en cualquier momento y antes del periodo pactado por circunstancias de fuerza mayor o caso fortuito " & _
                "ó si el contratante para el cual se desarrollen las labores a las que se encuentra asignado, decide por cualquier motivo suspender temporal o " & _
                "definitivamente el contrato principal, o reducir los trabajos contratados. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, " & _
                "EL TRABAJADOR se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o accidente común, enfermedad laboral o accidente de " & _
                "trabajo, los efectos del contrato de trabajo podrán ser extendidos por el tiempo que EL TRABAJADOR permanezca incapacitado " & _
                "conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única " & _
                "y exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, " & _
                "sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO TERCERO: Si al momento de finalizar el contrato de " & _
                "trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que le genere estabilidad laboral reforzada, " & _
                "los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la Compañía determine que las condiciones " & _
                "de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las " & _
                "prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para " & _
                "prestar su servicio. PARÁGRAFO CUARTO: Si al momento de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA " & _
                "(mujer) de su estado de embarazo, los efectos del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones asistenciales y económicas a cargo del Sistema " & _
                "de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es requerida para prestar su servicio. PARÁGRAFO QUINTO: Para EL " & _
                "TRABAJADOR quien al momento de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su esposa o compañera " & _
                "permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la finalización de la licencia de maternidad de ésta, siempre " & _
                "y cuando la cónyuge o compañera se encuentre afiliada como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL " & _
                "TRABAJADOR. Si cambia el requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos parámetros establecidos por la " & _
                "jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR " & _
                "y su cónyuge o compañera de este, las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda " & _
                " que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la vigencia de su contrato " & _
                "de trabajo y para su propia defensa ante autoridades administrativas y judiciales."
            Case 8
                Return " OCTAVA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba " & _
                "la quinta parte del término inicial de este contrato, que en todo caso no es superior a (2) dos meses, en caso de prórroga, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. " & _
                "Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización " & _
                "alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. "
            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO A TÉRMINO FIJO INFERIOR A UN (1) AÑO PARA TRABAJADORES QUE NO SON DE DIRECCION, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF123(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " &
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " &
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga " & _
                "a pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del contrato, un salario total consistente en la " & _
                "suma fija establecida al encabezado. Teniendo en cuenta que EL TRABAJADOR es contratado para la ejecución de un proyecto al que " & _
                "contractualmente deben aplicarse unos beneficios contemplados en la Convención Colectiva de Trabajo suscrita entre ECOPETROL " & _
                "S.A. y la UNION SINDICAL OBRERA-USO, el salario y los beneficios convencionales corresponden a lo dispuesto en la Guía de " & _
                "Aspectos y Condiciones Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, " & _
                "reemplace o adicione mientras se encuentre vigente el presente contrato de trabajo. Dentro de este pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. " & _
                "PARÁGRAFO PRIMERO: EL TRABAJADOR comprende y acepta los beneficios salariales y no salariales, establecidos en la Guía de " & _
                "Aspectos y Condiciones Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, " & _
                "reemplace o adicione. PARÁGRAFO SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día " & _
                "dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, " & _
                "previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo " & _
                "establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso " & _
                "el cual podrá ser acumulado y disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos " & _
                "por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda claramente entendido que EL EMPLEADOR no suministra ni suministrará, " & _
                "ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, alimentación, transporte, " & _
                "lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 " & _
                "del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, " & _
                "Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E.  o cualquier otra bonificación o concepto " & _
                "extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO CUARTO: " & _
                "Todo trabajo suplementario o en horas extras y todo trabajo en día domingo o festivo en los que legalmente debe " & _
                "concederse descanso, se remunerará conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este " & _
                "trabajo nocturno, suplementario, dominical o festivo sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado " & _
                "previamente según el trámite previsto por la empresa; de no efectuarse no se reconocerá ninguna de estas actividades y se " & _
                "entenderán realizadas por mera liberalidad de EL TRABAJADOR. Cuando por circunstancias de fuerza mayor o necesidades " & _
                "apremiantes del servicio se deba laborar en horas extras, domingos o festivos las labores deberán ejecutarse y darse " & _
                "cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la " & _
                "dependencia que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, " & _
                "suplementario o en días de descanso legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, " & _
                "como queda dicho. PARÁGRAFO QUINTO: Cuando por causa emanada directa o indirectamente de la relación " & _
                "contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no legalizados, herramientas y " & _
                "equipos en custodia, daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, " & _
                "embargos pendientes por descuento, etc., y más concretamente, a la terminación del presente contrato, así lo " & _
                "autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización cumple las condiciones de " & _
                "orden escrita previa, aplicable para cada caso. PARÁGRAFO SEXTO: Si durante el curso del presente contrato se modifican los " & _
                "salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR por expresa disposición de la compañía " & _
                "de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes una vez dicha compañía (cliente) le " & _
                "notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial dispuesto en la Guía de Aspectos y " & _
                "Condiciones Laborales en Actividades Contratadas por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione. " & _
                "PARÁGRAFO SÉPTIMO: Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando " & _
                "sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia " & _
                "electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las " & _
                "horas señaladas por EL EMPLEADOR de conformidad con lo dispuesto en la Guía de Aspectos y Condiciones Laborales en Actividades " & _
                "Contratadas por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione, o en su defecto o en caso que esta no aplique " & _
                "en la jornada establecida en el artículo 29 del Reglamento de Trabajo, pudiendo hacer este ajuste o cambios de horario cuando lo estime " & _
                "conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las " & _
                "horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley " & _
                "50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no se computan dentro de las mismas, según el " & _
                "Artículo 167 ibídem."
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término inicial de este contrato será el establecido al encabezado. Si antes " & _
                "de la fecha de vencimiento de este término ninguna de las partes avisare por escrito a la otra su determinación de no prorrogar el " & _
                "contrato, con antelación no inferior a (30) treinta días este se entenderá prorrogado por un periodo igual al inicialmente pactado.  " & _
                "Tratándose de un contrato a término fijo inferior a (1) un año, únicamente podrá prorrogarse sucesivamente el contrato hasta por tres " & _
                "(3) periodos iguales o inferiores, si al cabo de los cuales el término de renovación no podrá ser inferior a (1) un año; así sucesivamente.  " & _
                "En cumplimiento de lo previsto en el Artículo 3 de la Ley 50/90, EL TRABAJADOR tendrá derecho al pago de vacaciones y prima de " & _
                "servicios en proporción al tiempo laborado, cualquiera que esta sea. PARÁGRAFO PRIMERO: Si al momento de finalizar " & _
                "el presente contrato de trabajo, EL TRABAJADOR se encuentra incapacitado por su EPS o  ARL ya sea por enfermedad general " & _
                "o accidente común, enfermedad laboral o  accidente de trabajo, los efectos del contrato de trabajo podrán ser extendidos por " & _
                "el tiempo que EL TRABAJADOR permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS  o la ARL, " & _
                "según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR " & _
                "las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL " & _
                "TRABAJADOR aun es requerido para prestar su servicio.  PARÁGRAFO SEGUNDO: Si al momento de finalizar el contrato de trabajo, " & _
                "EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que le genere estabilidad " & _
                "laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la " & _
                "Compañía determine que las condiciones de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO TERCERO: Si al momento " & _
                "de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA (mujer) de su estado de " & _
                "embarazo, los efectos  del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es " & _
                "requerida para prestar su servicio. PARÁGRAFO CUARTO: Para EL TRABAJADOR quien al momento " & _
                "de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su " & _
                "esposa o compañera permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la " & _
                "finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge o compañera se encuentre afiliada " & _
                "como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL TRABAJADOR. Si cambia el " & _
                "requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos " & _
                "parámetros establecidos por la jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR y su cónyuge o compañera de este, las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es " & _
                "requerido para prestar su servicio. PARÁGRAFO QUINTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la " & _
                "vigencia de su contrato de trabajo y para su propia defensa ante autoridades administrativas y judiciales."

            Case 8
                Return " OCTAVA – PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba " & _
                "la quinta parte del término inicial de este contrato, que en todo caso no es superior a (2) dos meses, en caso de prórroga, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de la Ley 50/90. " & _
                "Durante este periodo EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de indemnización " & _
                "alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo modificado por el Artículo 3 del decreto 617/54. "
            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO POR DURACIÓN DE LA OBRA O LABOR DETERMINADA DE DIRECCIÓN, CONFIANZA Y MANEJO
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF119(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                "cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, " & _
                "manuales, ordenes e instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia " & _
                "y el cuidado necesarios para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo. "
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en " & _
                "el encabezamiento del contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo " & _
                "no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y " & _
                "disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO SEGUNDO : Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de " & _
                "alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo " & _
                "(Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o " & _
                "cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Cuando por causa emanada directa o " & _
                "indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no cancelados, herramientas y equipos en custodia, " & _
                "daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos pendientes por descuento, etc., y más " & _
                "concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente " & _
                " autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO CUARTO: Cualquier obligación económica por pagar de " & _
                "El EMPLEADOR a EL TRABAJADOR, aun cuando sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante " & _
                "transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA – JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el " & _
                "Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo " & _
                "de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima legal de trabajo de que trata el artículo 162 " & _
                "del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho al reconocimiento económico por laborar horas extras. "
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término de duración estará determinado por el tiempo que dure la " & _
                "realización de la labor contratada, de acuerdo a las condiciones generales que se señalan al inicio del presente contrato. La " & _
                "relación laboral sólo se limitará a la ejecución de las labores específicas que se señalaron en el encabezado y no para la realización " & _
                "de la totalidad del contrato principal. El contrato también podrá terminar en cualquier momento y antes de la ejecución del porcentaje " & _
                "mínimo mencionado, cuando la entidad o empresa para la cual EL EMPLEADOR realiza la obra o proyecto, decida por cualquier motivo " & _
                "terminar o suspender el contrato principal, la Orden de Trabajo o los trabajos contratados, entendiéndose que la labor ha concluido. " & _
                "Así mismo, si sobrevienen hechos de terceros, comunidades o de los trabajadores que hacen parte del proyecto para el que fue " & _
                "contratado EL TRABAJADOR, como vías de hecho, perturbación, paros, asonadas, motines, y demás eventos ajenos al normal " & _
                "desarrollo de las actividades inmersas dentro del objeto del presente contrato, las partes acuerdan considerar como culminada la " & _
                "labor u obra dada la imposibilidad de continuar con su ejecución. Para acreditar la terminación o el avance de la labor que limita la " & _
                "duración del presente contrato bastará certificación que en tal sentido expida la Oficina de Control Técnico de la Obra, quien haga " & _
                "sus veces o cualquier otro medio de prueba aceptado por la Ley, sin que sea necesario un término mínimo de anterioridad. " & _
                "PARÁGRAFO PRIMERO: Las partes acuerdan expresamente que cuando por necesidades del servicio o razones técnicas sea " & _
                "necesario ampliar la obra o labor que limitará el contrato, no será necesario la elaboración de uno nuevo, sino bastará efectuar una " & _
                "prórroga mediante otro sí, que podrá efectuarse en cualquier tiempo. PARÁGRAFO SEGUNDO: Si al momento de finalizar el " & _
                "presente contrato de trabajo, EL TRABAJADOR se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o " & _
                "accidente común, enfermedad laboral o accidente de trabajo, los efectos del contrato de trabajo podrán ser extendidos por el tiempo " & _
                "que EL TRABAJADOR permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo " & _
                "establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las " & _
                "prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL " & _
                "TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO TERCERO: Si al momento de finalizar el contrato de " & _
                "trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que genere estabilidad " & _
                "laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la " & _
                "Compañía determine que las condiciones de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO CUARTO: Si al momento " & _
                "de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA (mujer) de su estado de " & _
                "embarazo, los efectos del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es " & _
                "requerida para prestar su servicio. PARÁGRAFO QUINTO: Para EL TRABAJADOR quien al momento " & _
                "de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su " & _
                "esposa o compañera permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la " & _
                "finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge o compañera se encuentre afiliada " & _
                "como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL TRABAJADOR. Si cambia el " & _
                "requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos " & _
                "parámetros establecidos por la jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR y su cónyuge o compañera de este, las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es " & _
                "requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la " & _
                "vigencia de su contrato de trabajo y para su propia defensa ante autoridades administrativas y judiciales. "
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte de la ejecución de la labor " & _
                "contratada, que en todo caso no es superior a (2) dos meses; en caso de ampliación o modificación de la labor, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de " & _
                "la Ley 50/90. Durante este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin " & _
                "que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."
            Case 9
                Return "NOVENA - JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado " & _
                "unilateralmente este contrato por cualquiera de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte " & _
                "de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas " & _
                "en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones emanadas de EL EMPLEADOR. " & _
                "También se considerará que la obra contratada ha concluido, cuando por circunstancias de fuerza mayor, caso fortuito o hechos de " & _
                "terceros, impidan su continuidad."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna. "
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del PREVENCIÓN normaldel presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía. "
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A. "
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."

            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCION, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF124(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a " & _
                "pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del contrato, un salario total consistente en la suma fija " & _
                "establecida al encabezado. Teniendo en cuenta que EL TRABAJADOR es contratado para la ejecución de un proyecto al que " & _
                "contractualmente deben aplicarse unos beneficios contemplados en la Convención Colectiva de Trabajo suscrita entre ECOPETROL S.A. y " & _
                "la UNION SINDICAL OBRERA-USO, el salario y los beneficios convencionales corresponden a lo dispuesto en la Guía de Aspectos y " & _
                "Condiciones Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, reemplace o " & _
                "adicione mientras se encuentre vigente el presente contrato de trabajo. Dentro de este pago se encuentra incluida la remuneración de los " & _
                "descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "EL TRABAJADOR comprende y acepta los beneficios salariales y no salariales, establecidos en la Guía de Aspectos y Condiciones " & _
                "Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione. " & _
                "PARÁGRAFO SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá " & _
                "derecho a remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, " & _
                "cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta " & _
                "que la remuneración del trabajo sea compensado con descanso el cual podrá ser acumulado y disfrutado dentro de la " & _
                "programación de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto " & _
                "cualquier suministro de alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, " & _
                "se entenderá que lo hace por mera liberalidad y por ningún motivo constituirá salario en especie, igualmente se conviene " & _
                "que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) " & _
                "tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen " & _
                "desempeño en H.S.E. o cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier " & _
                "efecto. PARÁGRAFO CUARTO: Todo trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se " & _
                "remunerará conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este trabajo nocturno, suplementario, dominical " & _
                "o festivo sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado previamente según el trámite previsto por la empresa; de " & _
                "no efectuarse no se reconocerá ninguna de estas actividades y se entenderán realizadas por mera liberalidad de EL TRABAJADOR. " & _
                "Cuando por circunstancias de fuerza mayor o necesidades apremiantes del servicio se deba laborar domingos o festivos las labores deberán " & _
                "ejecutarse y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la " & _
                "dependencia que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, suplementario o en días de " & _
                "descanso legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda dicho. PARÁGRAFO " & _
                "QUINTO: Cuando por causa emanada directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de " & _
                "EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por " & _
                "concepto de préstamos, anticipos no legalizados, herramientas y equipos en custodia, daños a elementos de trabajo, " & _
                "conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos pendientes por descuento, " & _
                "etc., y más concretamente, a la terminación del presente contrato, así lo concretamente, a la terminación " & _
                "del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la " & _
                "presente autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO SEXTO: Si durante el " & _
                "curso del presente contrato se modifican los salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR " & _
                "por expresa disposición de la compañía de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes " & _
                "una vez dicha compañía (cliente) le notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial " & _
                "dispuesto en la Guía de Aspectos y Condiciones Laborales en Actividades Contratadas por ECOPETROL S.A. o el documento que lo " & _
                "modifique, reemplace o adicione. PARÁGRAFO SÉPTIMO: Cualquier obligación económica por pagar de El EMPLEADOR a EL " & _
                "TRABAJADOR, aun cuando sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél " & _
                "mediante transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las " & _
                "horas señaladas por EL EMPLEADOR de conformidad con lo dispuesto en la Guía de Aspectos y Condiciones Laborales en Actividades " & _
                "Contratadas por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione, o en su defecto o en caso que esta no aplique " & _
                "en la jornada establecida en el artículo 29 del Reglamento de Trabajo, pudiendo hacer este ajuste o cambios de horario cuando lo estime " & _
                "conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las " & _
                "horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley " & _
                "50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no se computan dentro de las mismas, según el " & _
                "Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo de " & _
                "dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima " & _
                "legal de trabajo de que trata el artículo 162 del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho " & _
                "al reconocimiento económico por laborar horas extras."
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término de duración del presente contrato estará determinado por el tiempo " & _
                "que dure la realización de la labor contratada, de acuerdo a las condiciones generales que se señalan al inicio del presente contrato. Sin " & _
                "embargo, la relación laboral que por medio del presente documento se formaliza sólo se limitará a la ejecución de las labores específicas " & _
                "que se señalaron en el encabezado y no para la realización de la totalidad del contrato principal. El contrato también podrá terminar en " & _
                "cualquier momento y antes de la ejecución del porcentaje mínimo señalado, cuando la entidad o empresa para la cual EL EMPLEADOR " & _
                "realiza la obra o proyecto, decida por cualquier motivo terminar el contrato principal, la Orden de Trabajo o los trabajos contratados, toda " & _
                "vez que se entenderá que la labor para la cual ha sido contratado EL TRABAJADOR ha concluido. Así mismo si el cliente decide por " & _
                "cualquier motivo suspender el contrato principal, la Orden de Trabajo o los trabajos contratados, el contrato de trabajo será suspendido a " & _
                "partir de la notificación que haga y se iniciara el trámite correspondiente ante el Ministerio de Trabajo, según las circunstancias de cada " & _
                "caso, teniendo como consecuencia la interrupción de la obligación del patrono correspondiente al pago del salario, pero mantendrá activa " & _
                "la relación laboral y efectuará los aportes a la seguridad social en salud y pensión mientras dure la suspensión, situación que el " & _
                "TRABAJADOR entiende y acepta. Así mismo, si sobrevienen hechos de terceros, comunidades o de los trabajadores que " & _
                "hacen parte del proyecto para el que fue contratado EL TRABAJADOR, como vías de hecho, perturbación, paros, asonadas, motines, " & _
                "y demás eventos ajenos al normal desarrollo de las actividades inmersas dentro del objeto del presente contrato, las " & _
                "partes acuerdan considerar como culminada la labor u obra dada la imposibilidad de continuar con su ejecución. " & _
                "Para acreditar la terminación o el avance de la labor que limita la duración del presente contrato bastará " & _
                "certificación que en tal sentido expida la Oficina de Control Técnico de la Obra, quien haga sus veces o cualquier otro medio de prueba " & _
                "aceptado por la Ley, sin que sea necesario un término mínimo de anterioridad. PARÁGRAFO PRIMERO: Las partes acuerdan " & _
                "expresamente que cuando por necesidades del servicio o razones técnicas sea necesario ampliar la obra o labor que limitará el contrato, " & _
                "no será necesario la elaboración de uno nuevo, sino bastará efectuar una modificación mediante otrosí, que podrá efectuarse en cualquier " & _
                "tiempo. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, EL TRABAJADOR se encuentra " & _
                "incapacitado por su EPS o  ARL ya sea por enfermedad general o accidente común, enfermedad laboral o  accidente de trabajo, los " & _
                "efectos del contrato de trabajo podrán ser extendidos por el tiempo que EL TRABAJADOR permanezca incapacitado conforme a las " & _
                "certificaciones que para tal efecto expida la EPS  o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio.  PARÁGRAFO TERCERO: Si al " & _
                "momento de finalizar el contrato de trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de " & _
                "salud que genere estabilidad laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el " & _
                "Departamento de Medicina Laboral de la  Compañía determine que las condiciones de salud que motivaron la prolongación del " & _
                "contrato hayan cesado. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y " & _
                "económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su " & _
                "servicio. PARÁGRAFO CUARTO: Si al momento de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por " & _
                "escrito por LA TRABAJADORA (mujer) de su estado de embarazo, los efectos  del contrato de trabajo podrán " & _
                "extenderse incluso hasta la finalización de la licencia de maternidad. Lo anterior única y exclusivamente con el fin de " & _
                "garantizar a LA TRABAJADORA (mujer) las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es requerida para prestar su servicio. " & _
                "PARÁGRAFO QUINTO: Para EL TRABAJADOR quien al momento de finalizar el contrato de trabajo ha anunciado por escrito " & _
                "a EL EMPLEADOR el estado de embarazo de su esposa o compañera permanente, los efectos del contrato de trabajo " & _
                "también podrán extenderse incluso hasta la finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge " & _
                "o compañera se encuentre afiliada como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra " & _
                "afiliado EL TRABAJADOR. Si cambia el requisito establecido por la jurisprudencia para que proceda la estabilidad " & _
                "laboral reforzada del trabajador que va a ser padre, se entenderá que la extensión del contrato de trabajo solo será " & _
                "procedente siempre y cuando se cumplan los nuevos parámetros establecidos por la jurisprudencia o la normatividad " & _
                "que llegue a regular esta situación. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR y su " & _
                "cónyuge o compañera de este, las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en " & _
                "Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR " & _
                "autoriza incondicionalmente a EL EMPLEADOR para que los documentos de su historia clínica puedan ser estudiados y " & _
                "usados por éste para tomar decisiones administrativas sobre su contrato de trabajo y para su propia defensa ante " & _
                "autoridades administrativas y judiciales."
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte de la ejecución de la labor " & _
                "contratada, que en todo caso no es superior a (2) dos meses; en caso de ampliación o modificación de la labor, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de " & _
                "la Ley 50/90. Durante este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin " & _
                "que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."
            Case 9
                Return "NOVENA - JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado " & _
                "unilateralmente este contrato por cualquiera de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte " & _
                "de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas " & _
                "en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones emanadas de EL EMPLEADOR.  " & _
                "También se considerará que la obra contratada ha concluido, cuando por circunstancias de fuerza mayor, caso fortuito o hechos de " & _
                "terceros, impidan su continuidad."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                "EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A. "
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Minuta CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL
    ''' </summary>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF181(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado " & _
                "EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del " & _
                "contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la remuneración de " & _
                "los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO " & _
                "PRIMERO: EL TRABAJADOR acepta y comprende que el salario indicado en el encabezado del presente contrato retribuye el trabajo " & _
                "ordinadio, y compensa de antemano el valor de las prestaciones, recargos y beneficios tales como los correspondientes al trabajo nocturno, " & _
                "extraordinario y al dominical y festivo, el valor de primas legales, extralegales, las cesantías y sus intereses, subsidios y suministros en especie, " & _
                "lo anterior, en virtud de lo establecido en el artículo 132 del Código Sustantivo del Trabajo. PARÁGRAFO " & _
                "SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a " & _
                "remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL " & _
                "TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la " & _
                "remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y disfrutado dentro de la programación " & _
                "de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda claramente entendido que " & _
                "EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, " & _
                "alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y " & _
                "por ningún motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 " & _
                "del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, " & _
                "de Finalización de Obra, de buen desempeño en H.S.E. o cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de " & _
                "salario para cualquier efecto. PARÁGRAFO CUARTO: Cuando por causa emanada directa o indirectamente de la relación contractual " & _
                "existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones " & _
                "a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no cancelados, herramientas y equipos en " & _
                "custodia, daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos " & _
                "pendientes por descuento, etc., y más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora " & _
                "EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización cumple las condiciones de orden escrita previa, " & _
                "aplicable para cada caso. PARÁGRAFO QUINTO: Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando " & _
                "sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia " & _
                "electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro " & _
                "de las horas señaladas por EL EMPLEADOR en el Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo " & _
                "estime conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes " & _
                "podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, " & _
                "modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no " & _
                "se computan dentro de las mismas, según el Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a " & _
                "desempeñar un cargo de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de " & _
                "la jornada máxima legal de trabajo de que trata el artículo 162 del Código Sustantivo del Trabajo, por lo tanto, " & _
                "no tendrá derecho al reconocimiento económico por laborar horas extras."
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término de duración estará determinado por el tiempo que dure la " & _
                "realización de la labor contratada, de acuerdo a las condiciones generales que se señalan al inicio del presente contrato. La " & _
                "relación laboral sólo se limitará a la ejecución de las labores específicas que se señalaron en el encabezado y no para la realización " & _
                "de la totalidad del contrato principal. El contrato también podrá terminar en cualquier momento y antes de la ejecución del porcentaje " & _
                "mínimo mencionado, cuando la entidad o empresa para la cual EL EMPLEADOR realiza la obra o proyecto, decida por cualquier motivo " & _
                "terminar o suspender el contrato principal, la Orden de Trabajo o los trabajos contratados, entendiéndose que la labor ha concluido. " & _
                "Así mismo, si sobrevienen hechos de terceros, comunidades o de los trabajadores que hacen parte del proyecto para el que fue " & _
                "contratado EL TRABAJADOR, como vías de hecho, perturbación, paros, asonadas, motines, y demás eventos ajenos al normal " & _
                "desarrollo de las actividades inmersas dentro del objeto del presente contrato, las partes acuerdan considerar como culminada la " & _
                "labor u obra dada la imposibilidad de continuar con su ejecución. Para acreditar la terminación o el avance de la labor que limita la " & _
                "duración del presente contrato bastará certificación que en tal sentido expida la Oficina de Control Técnico de la Obra, quien haga " & _
                "sus veces o cualquier otro medio de prueba aceptado por la Ley, sin que sea necesario un término mínimo de anterioridad. " & _
                "PARÁGRAFO PRIMERO: Las partes acuerdan expresamente que cuando por necesidades del servicio o razones técnicas sea " & _
                "necesario ampliar la obra o labor que limitará el contrato, no será necesario la elaboración de uno nuevo, sino bastará efectuar una " & _
                "prórroga mediante otro sí, que podrá efectuarse en cualquier tiempo. PARÁGRAFO SEGUNDO: Si al momento de finalizar el " & _
                "presente contrato de trabajo, EL TRABAJADOR se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o " & _
                "accidente común, enfermedad laboral o accidente de trabajo, los efectos del contrato de trabajo podrán ser extendidos por el tiempo " & _
                "que EL TRABAJADOR permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo " & _
                "establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las " & _
                "prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL " & _
                "TRABAJADOR aun es requerido para prestar su servicio.  PARÁGRAFO TERCERO: Si al momento de finalizar el contrato de " & _
                "trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que genere estabilidad " & _
                "laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la " & _
                "Compañía determine que las condiciones de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO CUARTO: Si al momento " & _
                "de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA (mujer) de su estado de " & _
                "embarazo, los efectos  del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es " & _
                "requerida para prestar su servicio. PARÁGRAFO QUINTO: Para EL TRABAJADOR quien al momento " & _
                "de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su " & _
                "esposa o compañera permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la " & _
                "finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge o compañera se encuentre afiliada " & _
                "como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL TRABAJADOR. Si cambia el " & _
                "requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos " & _
                "parámetros establecidos por la jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR y su cónyuge o compañera de este, las prestaciones " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es " & _
                "requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la " & _
                "vigencia de su contrato de trabajo y para su propia defensa ante autoridades administrativas y judiciales."
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte de la ejecución de la labor " & _
                "contratada, que en todo caso no es superior a (2) dos meses; en caso de ampliación o modificación de la labor, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de " & _
                "la Ley 50/90. Durante este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin " & _
                "que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."
            Case 9
                Return "NOVENA - JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado " & _
                "unilateralmente este contrato por cualquiera de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte " & _
                "de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas " & _
                "en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones emanadas de EL EMPLEADOR.  " & _
                "También se considerará que la obra contratada ha concluido, cuando por circunstancias de fuerza mayor, caso fortuito o hechos de " & _
                "terceros, impidan su continuidad."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' CONTRATO DE TRABAJO DE LABOR DETERMINADA PARA PERSONAL QUE NO ES DE DIRECCIÓN, CONFIANZA Y MANEJO
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF120(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                "cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
                "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
                "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en " & _
                "el encabezamiento del contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo " & _
                "no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y " & _
                "disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO SEGUNDO : Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de " & _
                "alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo " & _
                "(Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o " & _
                "cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Todo trabajo " & _
                "suplementario o en horas extras y todo trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se remunerará " & _
                "conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este trabajo nocturno, suplementario, dominical o festivo " & _
                "sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado previamente según el trámite previsto por la empresa; de no efectuarse " & _
                "no se reconocerá ninguna de estas actividades y se entenderán realizadas por mera liberalidad de EL TRABAJADOR. Cuando por circunstancias " & _
                "de fuerza mayor o necesidades apremiantes del servicio se deba labora en horas extras, domingos o festivos las labores deberán ejecutarse " & _
                "y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la dependencia " & _
                "que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, suplementario o en días de descanso " & _
                "legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda dicho. PARÁGRAFO CUARTO: Cuando " & _
                "por causa emanada directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR " & _
                "y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, " & _
                "anticipos no legalizados, herramientas y equipos en custodia, daños a elementos de trabajo, conceptos pagados " & _
                "a los cuales no tenía derecho, embargos pendientes por descuento, preaviso, etc., y  más concretamente, a la terminación del  " & _
                "presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización  " & _
                "cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO QUINTO: Si durante el curso del presente contrato  " & _
                "se modifican los salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR por expresa disposición de la  " & _
                "compañía de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes una vez dicha compañía  " & _
                "(cliente) le notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial. PARÁGRAFO SEXTO:  " & _
                "Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando sobrevenga con posterioridad a la  " & _
                "terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia electrónica o consignación a la última cuenta  " & _
                "bancaria en la que EL TRABAJADOR recibió el pago de su salario. "
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro " & _
                "de las horas señaladas por EL EMPLEADOR en el Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo  " & _
                "estime conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes  " & _
                "podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo,  " & _
                "modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no  " & _
                "se computan dentro de las mismas, según el Artículo 167 ibídem. "
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término de duración estará determinado por el tiempo que dure la " & _
                "realización de la labor contratada, de acuerdo a las condiciones generales que se señalan al inicio del presente contrato. La  " & _
                "relación laboral sólo se limitará a la ejecución de las labores específicas que se señalaron en el encabezado y no para la realización " & _
                "de la totalidad del contrato principal. El contrato también podrá terminar en cualquier momento y antes de la ejecución del porcentaje  " & _
                "mínimo mencionado, cuando la entidad o empresa para la cual EL EMPLEADOR realiza la obra o proyecto, decida por cualquier motivo  " & _
                "terminar o suspender el contrato principal, la Orden de Trabajo o los trabajos contratados, entendiéndose que la labor ha concluido.  " & _
                "Así mismo, si sobrevienen hechos de terceros, comunidades o de los trabajadores que hacen parte del proyecto para el que fue  " & _
                "contratado EL TRABAJADOR, como vías de hecho, perturbación, paros, asonadas, motines, y demás eventos ajenos al normal  " & _
                "desarrollo de las actividades inmersas dentro del objeto del presente contrato, las partes acuerdan considerar como culminada la  " & _
                "labor u obra dada la imposibilidad de continuar con su ejecución. Para acreditar la terminación o el avance de la labor que limita la  " & _
                "duración del presente contrato bastará certificación que en tal sentido expida la Oficina de Control Técnico de la Obra, quien haga  " & _
                "sus veces o cualquier otro medio de prueba aceptado por la Ley, sin que sea necesario un término mínimo de anterioridad.  " & _
                "PARÁGRAFO PRIMERO: Las partes acuerdan expresamente que cuando por necesidades del servicio o razones técnicas sea  " & _
                "necesario ampliar la obra o labor que limitará el contrato, no será necesario la elaboración de uno nuevo, sino bastará efectuar una  " & _
                "prórroga mediante otro sí, que podrá efectuarse en cualquier tiempo. PARÁGRAFO SEGUNDO: Si al momento de finalizar el  " & _
                "presente contrato de trabajo, EL TRABAJADOR se encuentra incapacitado por su EPS o ARL ya sea por enfermedad general o  " & _
                "accidente común, enfermedad laboral o accidente de trabajo, los efectos del contrato de trabajo podrán ser extendidos por el tiempo  " & _
                "que EL TRABAJADOR permanezca incapacitado conforme a las certificaciones que para tal efecto expida la EPS o la ARL, según lo  " & _
                "establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las  " & _
                "prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL  " & _
                "TRABAJADOR aun es requerido para prestar su servicio.  PARÁGRAFO TERCERO: Si al momento de finalizar el contrato de  " & _
                "trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de salud que genere estabilidad " & _
                "laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el Departamento de Medicina Laboral de la  " & _
                "Compañía determine que las condiciones de salud que motivaron la prolongación del contrato hayan cesado. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO CUARTO: Si al momento " & _
                "de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por escrito por LA TRABAJADORA (mujer) de su estado de " & _
                "embarazo, los efectos  del contrato de trabajo podrán extenderse incluso hasta la finalización de la licencia de maternidad. " & _
                "Lo anterior única y exclusivamente con el fin de garantizar a LA TRABAJADORA (mujer) las prestaciones  " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es  " & _
                "requerida para prestar su servicio. PARÁGRAFO QUINTO: Para EL TRABAJADOR quien al momento " & _
                "de finalizar el contrato de trabajo ha anunciado por escrito a EL EMPLEADOR el estado de embarazo de su  " & _
                "esposa o compañera permanente, los efectos del contrato de trabajo también podrán extenderse incluso hasta la " & _
                "finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge o compañera se encuentre afiliada " & _
                "como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra afiliado EL TRABAJADOR. Si cambia el " & _
                "requisito establecido por la jurisprudencia para que proceda la estabilidad laboral reforzada del trabajador que va a ser " & _
                "padre, se entenderá que la extensión del contrato de trabajo solo será procedente siempre y cuando se cumplan los nuevos " & _
                "parámetros establecidos por la jurisprudencia o la normatividad que llegue a regular esta situación. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR y su cónyuge o compañera de este, las prestaciones  " & _
                "asistenciales y económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es  " & _
                "requerido para prestar su servicio. PARÁGRAFO SEXTO:EL TRABAJADOR autoriza incondicionalmente a EL EMPLEADOR para  " & _
                "que los documentos de su historia clínica puedan ser estudiados y usados por éste para tomar decisiones administrativas sobre la  " & _
                "vigencia de su contrato de trabajo y para su propia defensa ante autoridades administrativas y judiciales. "
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte de la ejecución de la labor " & _
                "contratada, que en todo caso no es superior a (2) dos meses; en caso de ampliación o modificación de la labor, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de " & _
                "la Ley 50/90. Durante este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin " & _
                "que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."

            Case 9
                Return "NOVENA - JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado " & _
                "unilateralmente este contrato por cualquiera de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte " & _
                "de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas " & _
                "en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones emanadas de EL EMPLEADOR. " & _
                "También se considerará que la obra contratada ha concluido, cuando por circunstancias de fuerza mayor, caso fortuito o hechos de " & _
                "terceros, impidan su continuidad."

            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                "EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta " & _
                "confidencialidad y reserva de toda la información personal que le sea dada a conocer con ocasión del " & _
                "desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' CONTRATO DE TRABAJO POR DURACIÓN DE OBRA O LABOR DETERMINADA PARA TRABAJADORES QUE NO SON DE DIRECCION, CONFIANZA Y MANEJO (Convención USO - Ecopetrol)
    ''' </summary>
    ''' <param name="nombreResidente">Nombre del residente del proyecto.</param>
    ''' <param name="identificacionResidente">Número de identificación del residente.</param>
    ''' <param name="lugarExpIdResidente">Ciudad o municipio de expedición de la identificación del residente.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF125(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga " & _
                "a pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del contrato, un salario total consistente en la " & _
                "suma fija establecida al encabezado. Teniendo en cuenta que EL TRABAJADOR es contratado para la ejecución de un proyecto al que " & _
                "contractualmente deben aplicarse unos beneficios contemplados en la Convención Colectiva de Trabajo suscrita entre ECOPETROL " & _
                "S.A. y la UNION SINDICAL OBRERA-USO, el salario y los beneficios convencionales corresponden a lo dispuesto en la Guía de " & _
                "Aspectos y Condiciones Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, " & _
                "reemplace o adicione mientras se encuentre vigente el presente contrato de trabajo. Dentro de este pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. " & _
                "PARÁGRAFO PRIMERO: EL TRABAJADOR comprende y acepta los beneficios salariales y no salariales, establecidos en la Guía de " & _
                "Aspectos y Condiciones Laborales en Actividades Contratadas, establecida por ECOPETROL S.A. o el documento que lo modifique, " & _
                "reemplace o adicione. PARÁGRAFO SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día " & _
                "dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, " & _
                "previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo " & _
                "establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso " & _
                "el cual podrá ser acumulado y disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos " & _
                "por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda claramente entendido que EL EMPLEADOR no suministra ni suministrará, " & _
                "ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, alimentación, transporte, " & _
                "lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 " & _
                "del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, " & _
                "Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E.  o cualquier otra bonificación o concepto " & _
                "extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO CUARTO: " & _
                "Todo trabajo suplementario o en horas extras y todo trabajo en día domingo o festivo en los que legalmente debe " & _
                "concederse descanso, se remunerará conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este " & _
                "trabajo nocturno, suplementario, dominical o festivo sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado " & _
                "previamente según el trámite previsto por la empresa; de no efectuarse no se reconocerá ninguna de estas actividades y se " & _
                "entenderán realizadas por mera liberalidad de EL TRABAJADOR. Cuando por circunstancias de fuerza mayor o necesidades " & _
                "apremiantes del servicio se deba laborar en horas extras, domingos o festivos las labores deberán ejecutarse y darse " & _
                "cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la " & _
                "dependencia que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, " & _
                "suplementario o en días de descanso legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, " & _
                "como queda dicho. PARÁGRAFO QUINTO: Cuando por causa emanada directa o indirectamente de la relación " & _
                "contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no legalizados, herramientas y " & _
                "equipos en custodia, daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, " & _
                "embargos pendientes por descuento, etc., y más concretamente, a la terminación del presente contrato, así lo " & _
                "autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización cumple las condiciones de " & _
                "orden escrita previa, aplicable para cada caso. PARÁGRAFO SEXTO: Si durante el curso del presente contrato se modifican los " & _
                "salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR por expresa disposición de la compañía " & _
                "de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes una vez dicha compañía (cliente) le " & _
                "notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial dispuesto en la Guía de Aspectos y " & _
                "Condiciones Laborales en Actividades Contratadas por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione. " & _
                "PARÁGRAFO SÉPTIMO: Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando " & _
                "sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia " & _
                "electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las " & _
                "horas señaladas por EL EMPLEADOR de conformidad con lo dispuesto en la Guía de Aspectos y Condiciones Laborales en Actividades " & _
                "Contratadas por ECOPETROL S.A. o el documento que lo modifique, reemplace o adicione, o en su defecto o en caso que esta no aplique " & _
                "en la jornada establecida en el artículo 29 del Reglamento de Trabajo, pudiendo hacer este ajuste o cambios de horario cuando lo estime " & _
                "conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las " & _
                "horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley " & _
                "50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no se computan dentro de las mismas, según el " & _
                "Artículo 167 ibídem."
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: El término de duración del presente contrato estará determinado por el tiempo " & _
                "que dure la realización de la labor contratada, de acuerdo a las condiciones generales que se señalan al inicio del presente contrato. Sin " & _
                "embargo, la relación laboral que por medio del presente documento se formaliza sólo se limitará a la ejecución de las labores específicas " & _
                "que se señalaron en el encabezado y no para la realización de la totalidad del contrato principal. El contrato también podrá terminar en " & _
                "cualquier momento y antes de la ejecución del porcentaje mínimo señalado, cuando la entidad o empresa para la cual EL EMPLEADOR " & _
                "realiza la obra o proyecto, decida por cualquier motivo terminar el contrato principal, la Orden de Trabajo o los trabajos contratados, toda " & _
                "vez que se entenderá que la labor para la cual ha sido contratado EL TRABAJADOR ha concluido. Así mismo si el cliente decide por " & _
                "cualquier motivo suspender el contrato principal, la Orden de Trabajo o los trabajos contratados, el contrato de trabajo será suspendido a " & _
                "partir de la notificación que haga y se iniciara el trámite correspondiente ante el Ministerio de Trabajo, según las circunstancias de cada " & _
                "caso, teniendo como consecuencia la interrupción de la obligación del patrono correspondiente al pago del salario, pero mantendrá activa " & _
                "la relación laboral y efectuará los aportes a la seguridad social en salud y pensión mientras dure la suspensión, situación que el " & _
                "TRABAJADOR entiende y acepta. Así mismo, si sobrevienen hechos de terceros, comunidades o de los trabajadores que " & _
                "hacen parte del proyecto para el que fue contratado EL TRABAJADOR, como vías de hecho, perturbación, paros, asonadas, motines, " & _
                "y demás eventos ajenos al normal desarrollo de las actividades inmersas dentro del objeto del presente contrato, las " & _
                "partes acuerdan considerar como culminada la labor u obra dada la imposibilidad de continuar con su ejecución. " & _
                "Para acreditar la terminación o el avance de la labor que limita la duración del presente contrato bastará " & _
                "certificación que en tal sentido expida la Oficina de Control Técnico de la Obra, quien haga sus veces o cualquier otro medio de prueba " & _
                "aceptado por la Ley, sin que sea necesario un término mínimo de anterioridad. PARÁGRAFO PRIMERO: Las partes acuerdan " & _
                "expresamente que cuando por necesidades del servicio o razones técnicas sea necesario ampliar la obra o labor que limitará el contrato, " & _
                "no será necesario la elaboración de uno nuevo, sino bastará efectuar una modificación mediante otrosí, que podrá efectuarse en cualquier " & _
                "tiempo. PARÁGRAFO SEGUNDO: Si al momento de finalizar el presente contrato de trabajo, EL TRABAJADOR se encuentra " & _
                "incapacitado por su EPS o  ARL ya sea por enfermedad general o accidente común, enfermedad laboral o  accidente de trabajo, los " & _
                "efectos del contrato de trabajo podrán ser extendidos por el tiempo que EL TRABAJADOR permanezca incapacitado conforme a las " & _
                "certificaciones que para tal efecto expida la EPS  o la ARL, según lo establecido el artículo 26 de la Ley 361 de 1997. Lo anterior única y " & _
                "exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio.  PARÁGRAFO TERCERO: Si al " & _
                "momento de finalizar el contrato de trabajo, EL TRABAJADOR se encuentra con tratamiento médico pendiente o con afectación a su estado de " & _
                "salud que genere estabilidad laboral reforzada, los efectos del contrato de trabajo podrán ser extendidos hasta tanto el " & _
                "Departamento de Medicina Laboral de la  Compañía determine que las condiciones de salud que motivaron la prolongación del " & _
                "contrato hayan cesado. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR las prestaciones asistenciales y " & _
                "económicas a cargo del Sistema de Seguridad Social en Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su " & _
                "servicio. PARÁGRAFO CUARTO: Si al momento de finalizar el contrato de trabajo EL EMPLEADOR se encuentra avisado por " & _
                "escrito por LA TRABAJADORA (mujer) de su estado de embarazo, los efectos  del contrato de trabajo podrán " & _
                "extenderse incluso hasta la finalización de la licencia de maternidad. Lo anterior única y exclusivamente con el fin de " & _
                "garantizar a LA TRABAJADORA (mujer) las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad " & _
                "Social en Salud, sin que se entienda que LA TRABAJADORA (mujer) aun es requerida para prestar su servicio. " & _
                "PARÁGRAFO QUINTO: Para EL TRABAJADOR quien al momento de finalizar el contrato de trabajo ha anunciado por escrito " & _
                "a EL EMPLEADOR el estado de embarazo de su esposa o compañera permanente, los efectos del contrato de trabajo " & _
                "también podrán extenderse incluso hasta la finalización de la licencia de maternidad de ésta, siempre y cuando la cónyuge " & _
                "o compañera se encuentre afiliada como su beneficiaria en la Entidad Prestadora de Salud (EPS) a la cual se encuentra " & _
                "afiliado EL TRABAJADOR. Si cambia el requisito establecido por la jurisprudencia para que proceda la estabilidad " & _
                "laboral reforzada del trabajador que va a ser padre, se entenderá que la extensión del contrato de trabajo solo será " & _
                "procedente siempre y cuando se cumplan los nuevos parámetros establecidos por la jurisprudencia o la normatividad " & _
                "que llegue a regular esta situación. Lo anterior única y exclusivamente con el fin de garantizar a EL TRABAJADOR y su " & _
                "cónyuge o compañera de este, las prestaciones asistenciales y económicas a cargo del Sistema de Seguridad Social en " & _
                "Salud, sin que se entienda que EL TRABAJADOR aun es requerido para prestar su servicio. PARÁGRAFO SEXTO: EL TRABAJADOR " & _
                "autoriza incondicionalmente a EL EMPLEADOR para que los documentos de su historia clínica puedan ser estudiados y " & _
                "usados por éste para tomar decisiones administrativas sobre su contrato de trabajo y para su propia defensa ante " & _
                "autoridades administrativas y judiciales."
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan como periodo de prueba la quinta parte de la ejecución de la labor " & _
                "contratada, que en todo caso no es superior a (2) dos meses; en caso de ampliación o modificación de la labor, se entenderá que no hay un " & _
                "nuevo periodo de prueba, de acuerdo con lo dispuesto por el Artículo 78 del Código Sustantivo del Trabajo modificado por el Artículo 7 de " & _
                "la Ley 50/90. Durante este periodo tanto EL EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin " & _
                "que se cause el pago de indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."
            Case 9
                Return "NOVENA - JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado " & _
                "unilateralmente este contrato por cualquiera de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte " & _
                "de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de cualquiera de las obligaciones y prohibiciones previstas " & _
                "en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones emanadas de EL EMPLEADOR.  " & _
                "También se considerará que la obra contratada ha concluido, cuando por circunstancias de fuerza mayor, caso fortuito o hechos de " & _
                "terceros, impidan su continuidad."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR " & _
                "autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR " & _
                " acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return "DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento."
            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select

    End Function

    ''' <summary>
    ''' CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO
    ''' </summary>
    ''' <param name="nombreResidente">Es el código que asigna Nómina, de acuerdo con el consecutivo que se tiene para referenciar a cada trabajador en la base de datos e histórico de personal.</param>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF182(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No. " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a " & _
                 "pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del contrato, un salario total consistente en la suma fija " & _
                 "establecida al encabezado. Dentro de este pago se encuentra incluida la remuneración de los descansos dominicales y festivos de que " & _
                 "tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: Si por cualquier circunstancia EL " & _
                 "TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo no hubiere sido " & _
                 "autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma " & _
                 "ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso, " & _
                 "el cual podrá ser acumulado y disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos por " & _
                 "EL EMPLEADOR. PARÁGRAFO SEGUNDO: Queda claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna " & _
                 "clase de salario en especie, por lo tanto cualquier suministro de alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o " & _
                 "cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún motivo constituirá salario en especie, igualmente se " & _
                 "conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen " & _
                 "carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o cualquier " & _
                 "otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Todo trabajo " & _
                 "suplementario o en horas extras y todo trabajo en día domingo o festivo en los que legalmente debe concederse descanso, se remunerará " & _
                 "conforme a la Ley, así como los correspondientes recargos nocturnos. Para que este trabajo nocturno, suplementario, dominical o festivo " & _
                 "sea reconocido y cancelado, EL EMPLEADOR debe haberlo autorizado previamente según el trámite previsto por la empresa; de no efectuarse " & _
                 "no se reconocerá ninguna de estas actividades y se entenderán realizadas por mera liberalidad de EL TRABAJADOR. Cuando por circunstancias " & _
                 "de fuerza mayor o necesidades apremiantes del servicio se deba laborar en horas extras, domingos o festivos las labores deberán ejecutarse " & _
                 "y darse cuenta de ellas por escrito a más tardar el día siguiente hábil, previo visto bueno de su superior jerárquico o del jefe de la dependencia " & _
                 "que solicitó el trabajo. EL EMPLEADOR, en consecuencia, no reconocerá ningún trabajo nocturno, suplementario o en días de descanso " & _
                 "legalmente obligatorio que no haya sido autorizado previamente o avisado inmediatamente, como queda dicho. PARÁGRAFO CUARTO: Cuando " & _
                 "por causa emanada directa o indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR " & _
                 "y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, " & _
                 "anticipos no legalizados, herramientas y equipos en custodia, daños a elementos de trabajo, conceptos pagados " & _
                 "a los cuales no tenía derecho, embargos pendientes por descuento, preaviso, etc., y  más concretamente, a la terminación del " & _
                 "presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización " & _
                 "cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO QUINTO: Si durante el curso del presente contrato " & _
                 "se modifican los salarios y/o emolumentos extralegales o convencionales devengados por EL TRABAJADOR por expresa disposición de la " & _
                 "compañía de la cual ISMOCOL S.A. es contratista, EL EMPLEADOR efectuará los correspondientes reajustes una vez dicha compañía " & _
                 "(cliente) le notifique y autorice las correcciones que deban efectuarse para hacer efectivo el aumento salarial. PARÁGRAFO SEXTO: " & _
                 "Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando sobrevenga con posterioridad a la " & _
                 "terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia electrónica o consignación a la última cuenta " & _
                 "bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA - JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro " & _
               "de las horas señaladas por EL EMPLEADOR en el Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo " & _
               "estime conveniente, lo cual es aceptado de ante mano por EL TRABAJADOR. Por el acuerdo expreso o táctico de las partes " & _
               "podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del Código Sustantivo del Trabajo, " & _
               "modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la jornada no " & _
               "se computan dentro de las mismas, según el Artículo 167 ibídem."
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: La duración del presente contrato será indefinida, mientras subsista las causas " & _
                "que le dieron origen y la materia de trabajo."
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan un periodo de prueba de (2) dos meses.  Durante este periodo EL " & _
                "EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de " & _
                "indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."

            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO 
    ''' </summary>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF183(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte " & nombreResidente & " identificado con Cédula de Ciudadanía No. " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " & _
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " & _
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: " & _
                "Como remuneración por la prestación de los servicios del cargo mencionado EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en " & _
                "el encabezamiento del contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la " & _
                "remuneración de los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO PRIMERO: " & _
                "Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a remuneración alguna, si tal trabajo " & _
                "no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL TRABAJADOR llegare a laborar domingos de forma ocasional, " & _
                "conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y " & _
                "disfrutado dentro de la programación de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO SEGUNDO : Queda " & _
                "claramente entendido que EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de " & _
                "alojamiento, alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y por ningún " & _
                "motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 del Código Sustantivo del Trabajo " & _
                "(Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, de Finalización de Obra, de buen desempeño en H.S.E. o " & _
                "cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de salario para cualquier efecto. PARÁGRAFO TERCERO: Cuando por causa emanada directa o " & _
                "indirectamente de la relación contractual existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a " & _
                "efectuar las deducciones a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no cancelados, herramientas y equipos en custodia, " & _
                "daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos pendientes por descuento, etc., y más " & _
                "concretamente, a la terminación del presente contrato, así lo autoriza desde ahora EL TRABAJADOR, entendiendo expresamente las partes que la presente " & _
                " autorización cumple las condiciones de orden escrita previa, aplicable para cada caso. PARÁGRAFO CUARTO: Cualquier obligación económica por pagar de " & _
                "El EMPLEADOR a EL TRABAJADOR, aun cuando sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante " & _
                "transferencia electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA – JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR " & _
                "se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el " & _
                "Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo " & _
                "de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima legal de trabajo de que trata el artículo 162 " & _
                "del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho al reconocimiento económico por laborar horas extras. "
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: La duración del presente contrato será indefinida, mientras subsista las causas " & _
                "que le dieron origen y la materia de trabajo."
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan un periodo de prueba de (2) dos meses.  Durante este periodo EL " & _
                "EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de " & _
                "indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."
            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' CONTRATO DE TRABAJO A TÉRMINO INDEFINIDO PARA TRABAJADORES QUE SON DE DIRECCIÓN, CONFIANZA Y MANEJO CON SALARIO INTEGRAL
    ''' </summary>
    ''' <returns>Cadena con la minuta del contrato.</returns>
    Friend Function MinutaICAGRALF184(parrafo As Integer, nombreResidente As String, identificacionResidente As String, lugarExpIdResidente As String) As String
        Select Case parrafo
            Case 0
                Return "Entre los suscritos a saber por una parte  " & nombreResidente & " identificado con Cédula de Ciudadanía No.  " & _
                identificacionResidente & " expedida en  " & lugarExpIdResidente & ", actuando en nombre y representación de ISMOCOL S.A. y quien en lo sucesivo se " & _
               "denomina EL EMPLEADOR, y por la otra parte la persona identificada e individualizada en el encabezamiento, quien en lo sucesivo se denominará EL " & _
               "TRABAJADOR, de las condiciones ya dichas, se ha celebrado el presente contrato individual de trabajo, regido por las siguientes cláusulas: "
            Case 1
                Return "PRIMERA - OBJETO: EL EMPLEADOR contrata los servicios personales de EL TRABAJADOR para que desempeñe en forma exclusiva las funciones inherentes al " & _
                " cargo descrito anteriormente así como la ejecución de las tareas ordinarias y anexas al mencionado cargo, de conformidad con los reglamentos, manuales, ordenes e " &
               "instrucciones generales y/o particulares que le imparta EL EMPLEADOR o su representante, observando en su desarrollo la diligencia y el cuidado necesarios " &
               "para el cabal cumplimiento de su encargo."
            Case 2
                Return " SEGUNDA - OBLIGACIONES DEL TRABAJADOR: Además de las obligaciones determinadas en la Ley Laboral, Reglamento " & _
                "de Trabajo, Políticas de la Compañía, Manual de Responsabilidades, Circulares Normativas e Informativas, EL TRABAJADOR se compromete a cumplir con " & _
                "las siguientes obligaciones especiales: 1) Poner al servicio de EL EMPLEADOR toda su capacidad normal de trabajo, en forma exclusiva en el desempeño de " & _
                "las funciones propias del cargo mencionado y en las labores anexas y complementarias del mismo. 2) No prestar directa ni indirectamente servicios laborales " & _
                "a otros empleadores, ni a trabajar por cuenta propia en el mismo oficio, durante la vigencia de este contrato. 3.) Prestar el servicio antes mencionado " & _
                "personalmente, en el lugar del territorio de la República de Colombia que indicare EL EMPLEADOR, por tanto las partes convienen que EL EMPLEADOR en " & _
                "ejercicio del jus variandi podrá, en cualquier tiempo, asignarle a EL TRABAJADOR otros cargos u oficios distintos al aquí contratado y/o destinarlo a " & _
                "cualquier otra dependencia o lugar, temporal o definitivamente, traslado y modificaciones que EL TRABAJADOR acepta de antemano en el momento de ser " & _
                "contratado quedando entendido que mientras no se disminuya la remuneración fija pactada no existirá desmejora alguna para EL TRABAJADOR. 4) Realizar " & _
                "personalmente la labor en los términos estipulados; observar y cumplir a cabalidad los preceptos consagrados en el Reglamento de Trabajo, el " & _
                "Reglamento de Higiene y Seguridad Industrial, Manual del Sistema de Administración Ambiental, Manual de Aseguramiento de Calidad, Sistema de Gestión en " & _
                "Seguridad y Salud en el Trabajo, Manual de Derechos Humanos, Código Ética y Convivencia, Plan Vial, Política de No Consumo de Drogas y Alcohol y demás " & _
                "Políticas Corporativas, y acatar y ejecutar las órdenes e instrucciones que de manera general y/o particular le imparta la empresa o sus representantes " & _
                "según el orden jerárquico establecido. 5) No comunicar a terceros, salvo autorización expresa, las informaciones que sean de naturaleza reservada y cuya " & _
                "divulgación pueda ocasionar perjuicios a la empresa, lo cual no obsta para denunciar delitos comunes o violaciones del contrato o de las normas legales de " & _
                "trabajo ante las autoridades competentes. 6) Conservar y restituir en buen estado, salvo deterioro natural ocasionado por su uso legítimo, los bienes, " & _
                "instrumentos, herramientas y útiles que les hayan facilitado y las materias primas sobrantes. 7) Guardar rigurosamente la moral en las relaciones con sus " & _
                "superiores y compañeros. 8) Comunicar oportunamente a la empresa las observaciones que estimen conducentes a evitarle daño y perjuicios. 9) Prestar la " & _
                "colaboración posible en caso de siniestro o riesgo inminentes que afecten o amenacen las personas o las cosas de la empresa. 10) Observar las medidas " & _
                "preventivas higiénicas prescritas por el médico de la empresa o por las autoridades del ramo y observar con suma diligencia y cuidados las instrucciones y " & _
                "órdenes preventivas de Riesgos Profesionales. 11) Registrar en las oficinas de la empresa su domicilio y dirección, y dar aviso oportuno de cualquier " & _
                "cambio que ocurra, si no lo hiciere cualquier comunicación que se envíe a su antiguo domicilio se tendrá por válida. 12) Cumplir cabalmente con sus " & _
                "obligaciones contractuales y las contenidas en los Reglamentos, Circulares Normativas y Políticas de la empresa. 13) Abstenerse de incurrir en cualquiera " & _
                "de las prohibiciones especiales consagradas en el Reglamento de Trabajo. "
            Case 3
                Return "TERCERA - FALTAS LEVES Y SANCIONES: Hace parte del presente contrato de " & _
                "trabajo las conductas tipificadas en el Reglamento de Trabajo de la Compañía como faltas leves, por las cuales podrá ser sancionado EL TRABAJADOR " & _
                "según los criterios para determinar la gravedad de la falta y la aplicabilidad de la sanción, que consistiría en una suspensión del trabajo entre uno (1) " & _
                "y ocho (08) días si la falta es cometida por primera vez y no se causó un perjuicio, demora o cualquier otro tipo de inconveniente a las actividades de la " & _
                "Empresa, y entre nueve (09) y sesenta (60) días si la conducta es cometida por segunda vez y/o se cause un perjuicio, demora o cualquier otro tipo de " & _
                "inconveniente a las actividades de la Empresa. "
            Case 4
                Return "CUARTA - FALTAS GRAVES Y SANCIONES: Hace parte del presente contrato de trabajo las conductas tipificadas en " & _
                "el Reglamento de Trabajo de la Compañía como faltas graves, por las cuales podrá terminarse el contrato de trabajo por justa causa y sin lugar al " & _
                "pago de indemnización alguna, de conformidad con lo dispuesto en el numeral 6 del artículo 62 del Código Sustantivo del Trabajo."
            Case 5
                Return "QUINTA - REMUNERACIÓN: Como remuneración por la prestación de los servicios del cargo mencionado " & _
                "EL EMPLEADOR se obliga a pagar a EL TRABAJADOR, en las oportunidades señaladas en el encabezamiento del " & _
                "contrato, un salario total consistente en la suma fija establecida al encabezado. Dentro de éste pago se encuentra incluida la remuneración de " & _
                "los descansos dominicales y festivos de que tratan los capítulos I y II del título VII del Código Sustantivo de Trabajo. PARÁGRAFO " & _
                "PRIMERO: EL TRABAJADOR acepta y comprende que el salario indicado en el encabezado del presente contrato retribuye el trabajo " & _
                "ordinadio, y compensa de antemano el valor de las prestaciones, recargos y beneficios tales como los correspondientes al trabajo nocturno, " & _
                "extraordinario y al dominical y festivo, el valor de primas legales, extralegales, las cesantías y sus intereses, subsidios y suministros en especie, " & _
                "lo anterior, en virtud de lo establecido en el artículo 132 del Código Sustantivo del Trabajo. PARÁGRAFO " & _
                "SEGUNDO: Si por cualquier circunstancia EL TRABAJADOR prestare sus servicios en día dominical o festivo, no tendrá derecho a " & _
                "remuneración alguna, si tal trabajo no hubiere sido autorizado por EL EMPLEADOR, previamente y por escrito; así mismo, cuando EL " & _
                "TRABAJADOR llegare a laborar domingos de forma ocasional, conforme a lo establecido en el art. 180 del C.S.T., éste acepta que la " & _
                "remuneración del trabajo sea compensado con descanso, el cual podrá ser acumulado y disfrutado dentro de la programación " & _
                "de descansos en los turnos de trabajo establecidos por EL EMPLEADOR. PARÁGRAFO TERCERO: Queda claramente entendido que " & _
                "EL EMPLEADOR no suministra ni suministrará, ninguna clase de salario en especie, por lo tanto cualquier suministro de alojamiento, " & _
                "alimentación, transporte, lavado de ropa, comunicaciones o cualquier otra especie, se entenderá que lo hace por mera liberalidad y " & _
                "por ningún motivo constituirá salario en especie, igualmente se conviene que ninguno de los pagos enumerados en el Artículo 128 " & _
                "del Código Sustantivo del Trabajo (Artículo 15 Ley 50/90) tienen carácter de salario, así mismo, las Primas Técnicas, Bonos Técnicos, " & _
                "de Finalización de Obra, de buen desempeño en H.S.E. o cualquier otra bonificación o concepto extralegal tampoco tendrá el carácter de " & _
                "salario para cualquier efecto. PARÁGRAFO CUARTO: Cuando por causa emanada directa o indirectamente de la relación contractual " & _
                "existan obligaciones de tipo económico a cargo de EL TRABAJADOR y a favor de EL EMPLEADOR, éste procederá a efectuar las deducciones " & _
                "a que hubiera lugar en cualquier tiempo por concepto de préstamos, anticipos no cancelados, herramientas y equipos en " & _
                "custodia, daños a elementos de trabajo, conceptos no adeudados, conceptos pagados a los cuales no tenía derecho, embargos " & _
                "pendientes por descuento, etc., y más concretamente, a la terminación del presente contrato, así lo autoriza desde ahora " & _
                "EL TRABAJADOR, entendiendo expresamente las partes que la presente autorización cumple las condiciones de orden escrita previa, " & _
                "aplicable para cada caso. PARÁGRAFO QUINTO: Cualquier obligación económica por pagar de El EMPLEADOR a EL TRABAJADOR, aun cuando " & _
                "sobrevenga con posterioridad a la terminación del contrato de trabajo, podrá ser pagada a éste por aquél mediante transferencia " & _
                "electrónica o consignación a la última cuenta bancaria en la que EL TRABAJADOR recibió el pago de su salario."
            Case 6
                Return "SEXTA – JORNADA ORDINARIA DE TRABAJO: EL TRABAJADOR se obliga a laborar la jornada ordinaria en los turnos y dentro de las horas señaladas por EL EMPLEADOR en el " & _
                "Reglamento de Trabajo, pudiendo hacer ajuste o cambio de horario cuando lo estime conveniente, lo cual es aceptado de ante mano por EL " & _
                "TRABAJADOR. Por el acuerdo expreso o táctico de las partes podrán repartirse las horas de la jornada ordinaria en la forma prevista en el artículo 164 del " & _
                "Código Sustantivo del Trabajo, modificado por el Artículo 23 de la Ley 50/90, teniendo en cuenta que los tiempos de descanso entre las secciones de la " & _
                "jornada no se computan dentro de las mismas, según el Artículo 167 ibídem. PARÁGRAFO: Por tratarse de que EL TRABAJADOR va a desempeñar un cargo " & _
                "de dirección, confianza y manejo dentro de ISMOCOL S.A., queda excluido de la regulación de la jornada máxima legal de trabajo de que trata el artículo 162 " & _
                "del Código Sustantivo del Trabajo, por lo tanto, no tendrá derecho al reconocimiento económico por laborar horas extras. "
            Case 7
                Return "SÉPTIMA - TÉRMINO DE DURACIÓN DEL CONTRATO: La duración del presente contrato será indefinida, mientras subsista las causas " & _
                "que le dieron origen y la materia de trabajo."
            Case 8
                Return "OCTAVA - PERIODO DE PRUEBA: Las partes acuerdan un periodo de prueba de (2) dos meses.  Durante este periodo EL " & _
                "EMPLEADOR como EL TRABAJADOR podrán terminar el contrato en cualquier tiempo, sin que se cause el pago de " & _
                "indemnización alguna, en forma unilateral de conformidad con el Artículo 80 del Código Sustantivo del Trabajo " & _
                "modificado por el Artículo 3 del decreto 617/54."

            Case 9
                Return "NOVENA – JUSTAS CAUSAS PARA DAR POR TERMINADO EL CONTRATO: Son justas causas para dar por terminado unilateralmente este contrato por cualquiera " & _
                "de las partes, las enumeradas en el Artículo 7 del Decreto 2351/65, y además por parte de EL EMPLEADOR, el incumplimiento por parte de EL TRABAJADOR de " & _
                "cualquiera de las obligaciones y prohibiciones previstas en este contrato, el Reglamento de Trabajo, Circulares Normativas y las demás comunicaciones " & _
                "emanadas de EL EMPLEADOR."
            Case 10
                Return "DECIMA – INVENCIONES Y DESCUBRIMIENTOS: Si durante el tiempo que EL TRABAJADOR preste sus servicios a EL EMPLEADOR " & _
                "llegare a efectuar algún tipo de descubrimientos, invenciones, mejoras en los procedimientos técnicos, de producción y/o administrativo de EL EMPLEADOR " & _
                "estos quedarán de propiedad exclusiva de EL EMPLEADOR, incluso de aquellos que están consagrados en la Ley Comercial como propiedad industrial. " & _
                "EL EMPLEADOR, tendrá derecho a patentar en su nombre o a nombre de terceros esas invenciones y/o mejoras, para lo cual EL TRABAJADOR facilitará el " & _
                "cumplimiento oportuno de las formalidades exigidas, dará su firma, poderes y demás documentos necesarios para tal fin cuando así lo solicite EL EMPLEADOR, " & _
                "sin que por ello EL EMPLEADOR quede obligado al pago de suma de dinero o compensación alguna."
            Case 11
                Return "DECIMA PRIMERA - AUTORIZACIÓN DE TRATAMIENTO DE INFORMACIÓN PERSONAL: " & _
                " EL TRABAJADOR autoriza a EL EMPLEADOR para que realice el tratamiento de su información personal, de conformidad con el Manual " & _
                "de Políticas y Procedimientos para la Protección de Datos Personales. EL EMPLEADOR realizará un tratamiento responsable y seguro de los datos " & _
                "suministrados, conforme las previsiones de la Ley 1581 de 2012 y las normas que la reglamentan. "
            Case 12
                Return "DECIMA SEGUNDA - ACUERDO DE CONFIDENCIALIDAD - " & _
                "TRATAMIENTO DE INFORMACIÓN PERSONAL: EL TRABAJADOR acepta y se compromete a guardar absoluta confidencialidad y reserva de toda la información personal " & _
                "que le sea dada a conocer con ocasión del desarrollo del presente contrato, comprometiéndose a tratar esta información conforme al Manual de Políticas " & _
                "y Procedimientos de Datos Personales de la Compañía, compromiso que tendrá vigencia aún después de finalizar el contrato de trabajo. PARÁGRAFO: EL " & _
                "TRABAJADOR se obliga a no revelar ni divulgar a terceras personas, la información confidencial que haya recibido del EMPLEADOR o de los accionistas, " & _
                "proveedores, clientes, contratistas, comunidad y demás grupos de interés de la Compañía."
            Case 13
                Return "DECIMA TERCERA - ORDEN PÚBLICO: EL TRABAJADOR es consciente y " & _
                "conocedor de las condiciones de orden público que predomina en todo el territorio nacional y por lo tanto asume el riesgo que se deriva de la " & _
                "actividad laboral que va a desarrollar y se compromete a cumplir de manera especial con todas las normas, instrucciones y ordenes que de manera particular o " & _
                "general se hagan en materia de seguridad física; por lo tanto, en caso de secuestro o retención de EL TRABAJADOR, ISMOCOL S.A., no es ni será responsable " & _
                "por el pago de rescate o concepto similar a favor de sus captores, por expresa disposición y en cumplimiento de lo dispuesto en la ley 40/93 y " & _
                "demás normas reglamentarias."
            Case 14
                Return " DECIMA CUARTA – CONTRATISTA INDEPENDIENTE: Queda claramente entendido que ISMOCOL S.A., en desarrollo de su objeto social " & _
                "y dentro de las actividades que da origen a la presente relación laboral, actúa como CONTRATISTA INDEPENDIENTE y por lo tanto verdadero EMPLEADOR y no como " & _
                "representante ni intermediario de la entidad o empresa para la cual presta sus servicios, por lo tanto no existe ni existirá en ningún momento relación " & _
                "laboral entre EL TRABAJADOR y la compañía de la cual ISMOCOL S.A. es contratista, toda vez que el único y verdadero EMPLEADOR de éste es y será ISMOCOL S.A."
            Case 15
                Return "DECIMA QUINTA - ACEPTACIÓN Y COMPROMISO DE LA OBLIGACIÓN DE REPORTAR ACCIDENTES DE TRABAJO: EL TRABAJADOR declara haber recibido capacitación sobre el Reglamento de Trabajo, " & _
                "el Reglamento de Higiene y el Sistema de Gestión de Seguridad y Salud en el Trabajo y Ambiente (SG-SSTA), así como las políticas, normas, planes, " & _
                "procedimientos, instructivos, prácticas seguras y reglas en materia de seguridad, salud en el trabajo y medio ambiente, los riesgos a que estará expuesto, " & _
                "las medidas respectivas para su control, y las obligaciones que como trabajador le imponen el deber de reportar de manera inmediata, eficaz, veraz y " & _
                "completa la ocurrencia de cualquier evento que pueda derivar lesión o enfermedad, tal como accidentes de trabajo o incidentes, enfermedades, dolencias, " & _
                "etc., así como el de asegurar que el reporte se haya tramitado y diligenciado en la forma prevista en el Sistema. "
            Case 16
                Return "DECIMA SEXTA - PREVENCIÓN EN LAVADO DE ACTIVOS Y FINANCIACIÓN DEL TERRORISMO (LA/FT): " & _
                "EL TRABAJADOR declara que sus recursos provienen de actividades lícitas y están ligados al desarrollo " & _
                "normal de sus actividades, y que, por lo tanto, los mismos no provienen de ninguna actividad ilícita de las contempladas en el Código Penal Colombiano o " & _
                "en cualquier norma que lo sustituya, adicione o modifique. Así mismo declara que no se encuentra en las listas internacionales vinculantes para Colombia de " & _
                "conformidad con el derecho internacional (listas de las Naciones Unidas) o en las listas de la OFAC o cualquier otra, y que no tiene nexos sociales ni " & _
                "familiares con personas inmersas en lavado de activos y financiación del terrorismo. PARÁGRAFO PRIMERO: EL TRABAJADOR autoriza a ISMOCOL S.A. " & _
                "para utilizar su información personal en las verificaciones que considere pertinentes en los mecanismos establecidos por la Empresa para prevenir los " & _
                "riesgos asociados a LA/FT. PARÁGRAFO SEGUNDO: EL TRABAJADOR se compromete a comunicar cualquier tipo de anomalía referente a LA/FT a EL EMPLEADOR y a " & _
                "las autoridades competentes. "
            Case 17
                Return "DECIMA SÉPTIMA - MODIFICACIONES: Cualquier modificación del " & _
                "presente contrato deberá efectuarse por escrito mediante otrosí. El presente contrato ha sido redactado de buena fe, en cumplimiento de las disposiciones " & _
                "legales y convencionales y no contiene estipulaciones o condiciones que desmejoren la situación del trabajador, que sean ilícitas o ilegales, por lo tanto las partes quedan " & _
                "expresamente comprometidas a darle cabal cumplimiento. "

            Case 18
                Return "DECIMA OCTAVA - NOTIFICACIONES: Las partes acuerdan como lugar de notificación, la dirección " & _
                "de domicilio del EMPLEADOR, y por parte del TRABAJADOR la dirección de residencia y/o su correo electrónico. PARÁGRAFO PRIMERO: EL TRABAJADOR " & _
                "declara que ante la imposibilidad de recibir correspondencia en la dirección de residencia o en el correo electrónico, autoriza a EL EMPLEADOR " & _
                "para que entregue correspondencia a través de los miembros de la Junta de Acción Comunal del lugar de su contratación o por medio de agremiaciones similares. " & _
                "PARÁGRAFO SEGUNDO: El TRABAJADOR entiende y acepta que puede ser notificado mediante la publicación de aviso que EL EMPLEADOR realice en un lugar de " & _
                "acceso público de las oficinas de la administración del lugar donde fue contratado, por un término de cinco (05) días, en tal caso se considerará surtida " & _
                "la notificación al día siguiente al retiro del aviso."
            Case Else
                Return Nothing
        End Select
    End Function

End Module 'Cl_MinutaContrato