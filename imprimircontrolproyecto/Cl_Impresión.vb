Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports FunBase = FuncionesBase.FuncionesBase

Public Class Cl_Impresión

#Region "Variables para Imprimir"
    Private WithEvents VistaPrevia As New PrintPreviewDialog
    Private ClConvertir As New FuncionesBase.Cl_Convertir_Num_Letras

    Private logoIsmocol As Image = My.Resources.ResourceManager.GetObject("images")
    Private logoCenit As Image = My.Resources.cenit
    Private listaImagenesBD As List(Of Image)

    Private Lapiz As Pen
    Private Lapiz_Grueso As Pen
    Dim lineaPunteada As New Pen(Color.Gray, 1)

    Private Brocha As New SolidBrush(Color.Black)
    Private BrochaRoja As New SolidBrush(Color.Red)
    Private BrochaGrisClaro As New SolidBrush(Color.Silver)
    Private BrochaVerdeClaro As New SolidBrush(Color.LightGreen)
    Private BrochaRojo As New SolidBrush(Color.Red)
    Dim brocharellenoverde As New SolidBrush(Color.WhiteSmoke) 'SolidBrush(Color.FromArgb(57, 172, 65))

    Private Formato_Etiqueta_3 As New Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_3R As New Drawing.Font("Arial", 3.0!, System.Drawing.FontStyle.Regular)

    Private Formato_Etiqueta_4 As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_4R As New Drawing.Font("Arial", 4.0!, System.Drawing.FontStyle.Regular)

    Private Formato_Etiqueta_5 As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_5R As New Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Regular)

    Private Formato_Etiqueta_6 As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_6R As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_6RS As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Underline)

    Private Formato_Etiqueta_7 As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_7R As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_7RS As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_7I As New Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_8 As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_8R As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_8RS As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_8I As New Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Italic)

    Private Formato_Etiqueta_9 As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_9R As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_9RS As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_9RSI As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_9RSN As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_9I As New Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Italic)

    Private Formato_Etiqueta_10 As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_10R As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_10RS As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline)
    Private Formato_Etiqueta_10RSN As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Underline Or System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_10I As New Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Italic)

    Private Formato_Etiqueta_11 As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_11R As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_11RS As New Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Underline)

    Private Formato_Etiqueta_12 As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_12R As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_12RS As New Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline)

    Private Formato_Etiqueta_14 As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_14R As New Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)

    Private Formato_Etiqueta_15 As New Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_16 As New Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_18 As New Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)

    Private Formato_Etiqueta_80 As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Bold)
    Private Formato_Etiqueta_80R As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Regular)
    Private Formato_Etiqueta_80I As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Italic)
    Private Formato_Etiqueta_80RS As New Drawing.Font("Arial", 80.0!, System.Drawing.FontStyle.Underline)

    'Variables de la forma
    Const espacioParrafo As Integer = 20
    Private contadorImpresionCadena As Integer = 0
    Private datosCargados As Boolean = False
    Private contadorPaginasImpresas As UInteger = 0
    Private totalPaginasImpresion As UInteger = 0
    ReadOnly Property ImpresionFinalizada As Boolean
        Get
            Return _impresionFinalizada
        End Get
    End Property
    Private _impresionFinalizada As Boolean = False

    Public Sub New()
        Lapiz = New Pen(Brocha, 1)
        Lapiz_Grueso = New Pen(Brocha, 2)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}
        TablaIdReporte.Columns.Add("Id", System.Type.GetType("System.Int32"))
    End Sub
    Public TablaIdReporte As New DataTable



#End Region

#Region "Métodos de impresión"
    ''' <summary></summary>
    ''' <param name="Valor"></param>
    ''' <returns></returns>
    Private Function FormatearValor(ByVal Valor As Decimal) As String
        Dim pos As Integer = Valor.ToString.IndexOf(",")
        Dim decimales As String
        Dim valorstring As String
        If pos = -1 Then
            decimales = ""
            valorstring = Valor
        Else
            decimales = Mid(Valor.ToString, pos + 1, 3)
            valorstring = Mid(Valor.ToString, 1, Valor.ToString.Length - (Valor.ToString.Length - pos))
            decimales = Replace(decimales, ",00", "")
        End If
        Dim temp As String = ""
        For i = 1 To valorstring.Length
            temp = Mid(valorstring, valorstring.Length - (i - 1), 1) + temp
            If i Mod (3) = 0 And i <> 0 Then
                If i <> valorstring.Length Then
                    temp = "." + temp
                End If
            End If
        Next
        FormatearValor = temp
    End Function

    ''' <summary>
    ''' Indica la coordenada en X de una línea de texto centrada en un ancho determinado.
    ''' </summary>
    ''' <param name="Texto">Línea de texto a centrar.</param>
    ''' <param name="fuente">Fuente.</param>
    ''' <param name="TamañoLinea">Ancho del espacio donde se va a centrar la línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <returns>Coordenada X del texto relativa al tamaño de la línea.</returns>
    Private Function InicioCentradoTexto(Texto As String, fuente As Font, TamañoLinea As Integer, e As PrintPageEventArgs) As Integer
        Dim LongitudTotal As SizeF
        LongitudTotal = e.Graphics.MeasureString(Texto, fuente)
        InicioCentradoTexto = CInt((TamañoLinea / 2) - (LongitudTotal.Width / 2))
    End Function

    ''' <summary>
    ''' Divide un párrafo en líneas de texto según la cantidad de palabras que quepan en la longitud indicada.
    ''' </summary>
    ''' <param name="vectorparrafos">Párrafo a dividir en renglones.</param>
    ''' <param name="fuente">Fuente.</param>
    ''' <param name="LongitudMaxima">Longitud máxima que puede abarcar cada línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <param name="ConLineaSeparacion">Indica si se incluye una línea en blanco intercalada en las líneas del párrafo.</param>
    ''' <returns>Vector con las líneas de texto divididas según la longitud máxima.</returns>
    Private Function TextoAParrafoFuente(vectorparrafos As ArrayList, fuente As Font, LongitudMaxima As Double, e As PrintPageEventArgs, Optional ConLineaSeparacion As Boolean = True) As ArrayList
        Dim TextoEnParrafo As New ArrayList
        For i = 0 To vectorparrafos.Count - 1
            Dim Parrafo As String = vectorparrafos(i)
            Parrafo = Trim(Parrafo)
            Parrafo = Replace(Parrafo, "Retroexcavadora", "Retro excavadora")
            Parrafo = Replace(Parrafo, "COMPRESOR/INTERCOOLER", "COMPRESOR / INTERCOOLER")
            Dim CadenaActual As String = ""
            Dim SiguientePalabra As String = ""
            Dim CadenaRestante As String = Parrafo
            Dim LongitudTotal As SizeF
            Dim LongitudLinea As SizeF
            Dim PosSiguienteSeparador As Integer
            Dim strCaracter As String
            Dim TempCadenaActual As String
            Dim NuevaLinea As Boolean
            If (Parrafo) <> "" Then
                While Trim(CadenaRestante <> "")
                    LongitudTotal = e.Graphics.MeasureString(CadenaRestante, fuente)
                    If LongitudTotal.Width < LongitudMaxima Then
                        TextoEnParrafo.Add(CadenaRestante)
                        CadenaRestante = ""
                    Else
                        CadenaActual = ""
                        SiguientePalabra = ""
                        NuevaLinea = False
                        Do
                            PosSiguienteSeparador = PosicionSiguienteSeparador(CadenaRestante, 1)
                            strCaracter = Mid$(CadenaRestante, PosSiguienteSeparador, 1)
                            SiguientePalabra = Mid$(CadenaRestante, 1, PosSiguienteSeparador)
                            TempCadenaActual = ""
                            If CadenaActual <> "" Then
                                TempCadenaActual = CadenaActual + " " + SiguientePalabra
                            Else
                                TempCadenaActual = SiguientePalabra
                            End If
                            LongitudLinea = e.Graphics.MeasureString(TempCadenaActual + " " + SiguientePalabra, fuente)
                            If LongitudLinea.Width <= LongitudMaxima Then
                                CadenaActual = TempCadenaActual
                                CadenaRestante = Mid$(CadenaRestante, PosSiguienteSeparador + 1, Len(CadenaRestante))
                                Select Case strCaracter
                                    Case vbNewLine, vbLf
                                        NuevaLinea = True
                                        TextoEnParrafo.Add(TempCadenaActual)
                                        CadenaRestante = Mid$(CadenaRestante, PosSiguienteSeparador + 1, Len(CadenaRestante))
                                    Case Else
                                        CadenaActual = TempCadenaActual
                                End Select
                            Else
                                NuevaLinea = True
                                TextoEnParrafo.Add(CadenaActual)
                                CadenaRestante = Mid$(CadenaRestante, 1, Len(CadenaRestante))
                            End If
                        Loop While Not NuevaLinea
                    End If
                End While
                'Quitar los espacios agregados al final.
            End If
            If ConLineaSeparacion = True Then
                TextoEnParrafo.Add("")
            End If
        Next
        TextoAParrafoFuente = TextoEnParrafo
    End Function

    Private Function PosicionSiguienteSeparador(texto As String, Inicio As Integer) As Integer
        Dim lngLongitudTexto = Len(texto)
        Dim strCaracter As String
        For lngPosicion = Inicio To lngLongitudTexto
            strCaracter = Mid$(texto, lngPosicion, 1)
            Select Case strCaracter
                Case vbNewLine, vbLf
                    PosicionSiguienteSeparador = lngPosicion
                    Exit Function
                    ' Si encuentra un espacio en blanco o un tabulador en la última posición recorre la cadena hacia la izquierda hasta encontrar un caracter
                Case " ", vbTab
                    PosicionSiguienteSeparador = lngPosicion
                    Exit Function
                Case Else
            End Select
        Next lngPosicion
        PosicionSiguienteSeparador = 1
    End Function

    ''' <summary>Justifica una línea de texto.</summary>
    ''' <param name="Parrafo">Línea de texto original.</param>
    ''' <param name="fuente">Fuente del texto.</param>
    ''' <param name="longitud">Longitud máxima que debe abarcar la línea de texto.</param>
    ''' <param name="e">Evento de impresión.</param>
    ''' <returns></returns>
    Private Function SubParrafo1(Parrafo As String, fuente As Font, longitud As Double, e As PrintPageEventArgs) As String
        If Parrafo.IndexOf(" ") = -1 Then
            SubParrafo1 = Parrafo
            Exit Function
        End If
        Parrafo = Trim(Parrafo)
        If (Parrafo) <> "" Then
            Dim sz As SizeF = e.Graphics.MeasureString(Parrafo, fuente)
            If sz.Width < longitud / 2 Then
                SubParrafo1 = Parrafo
                Exit Function
            End If
            Dim espacioinicial As String = " "
            Dim temp1 As String = Parrafo
            Dim temp2 As String = ""
            While sz.Width < longitud
                Dim posespacio As Integer
                posespacio = temp1.ToString.IndexOf(espacioinicial)
                If posespacio = -1 Then
                    Exit While
                End If
                temp2 = temp2 + Mid(temp1, 1, posespacio + 1)
                temp1 = Mid(temp1, posespacio + 2, Parrafo.ToString.Length)
                If Trim(temp1) = "" Then
                    Exit While
                End If
                temp2 = temp2 + " "
                sz = e.Graphics.MeasureString(temp2 + temp1, fuente)
            End While
            If sz.Width < longitud Then
                SubParrafo1 = SubParrafo1(temp2 + temp1, fuente, longitud, e)
            Else
                SubParrafo1 = temp2 + temp1
            End If
            Exit Function
        End If
        SubParrafo1 = Parrafo
    End Function
#End Region

#Region "Consulta Datos Control Proyecto"

    Public TablaId As New DataTable
    Public TablaIdC As New DataTable
    Public TablaIdOE As New DataTable
    Public TablaIdE As New DataTable
    Public FechaCorte As Date
    Private _filaOrdenTrabajo As DataRow
    Private _dtServicios As DataTable
    Private _dtPersonal As DataTable
    Private _dtComplemento As DataTable
    Private _filaComplemento As DataRow
    Private _dtEquipo As DataTable
    Private _dtCIndirecto As DataTable
    Private _dtMateriales As DataTable
    Private _dtManoObra As DataTable
    Private _dtAdicionales As DataTable
    Private _dtTotalServicios As DataTable
    Private _filaTotalServicios As DataRow
    Private _dtDetalle As New DataTable
    Private _dtTotal As New DataTable
    Private _dtResumenOM As New DataTable
    Private _dtObservacion As New DataTable
    Private _dtResidente As New DataTable
    Private _filaObraEjecutada As DataRow
    Private _filaRDEquipo As DataRow
    Public Año As Integer
    Public Mes As Integer
    Public FechaI As Date
    Public FechaF As Date

    Private Sub CargarDatasetOrdenTrabajo()
        _dtServicios = New DataTable
        _dtPersonal = New DataTable
        _dtComplemento = New DataTable
        _dtEquipo = New DataTable
        _dtCIndirecto = New DataTable
        _dtMateriales = New DataTable
        _dtTotalServicios = New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim cmdot As New SqlCommand("dbo.ImpresionOT", conexion)
        cmdot.CommandType = CommandType.StoredProcedure
        cmdot.Parameters.AddWithValue("@TABLAIDOT", TablaId)
        Dim adaptador As New SqlDataAdapter(cmdot)
        Dim dsOrdenTrabajo As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsOrdenTrabajo)
            conexion.Close()
            'Table0 --> Orden de Trabajo
            'Table1 --> Servicios
            'Table2 --> Personal
            'Table3 --> Equipo
            'Table4 --> Costo Indirecto
            'Table5 --> Materiales
            'Tabla6 --> Total Servicios
            'Tabla7 --> Complemento

            If dsOrdenTrabajo.Tables(0).Rows.Count > 0 Then
                _filaOrdenTrabajo = dsOrdenTrabajo.Tables(0).Rows(0)
            End If
            If dsOrdenTrabajo.Tables(1).Rows.Count > 0 Then
                _dtServicios = dsOrdenTrabajo.Tables(1)
            End If
            If dsOrdenTrabajo.Tables(2).Rows.Count > 0 Then
                _dtPersonal = dsOrdenTrabajo.Tables(2)
            End If
            If dsOrdenTrabajo.Tables(3).Rows.Count > 0 Then
                _dtEquipo = dsOrdenTrabajo.Tables(3)
            End If
            If dsOrdenTrabajo.Tables(4).Rows.Count > 0 Then
                _dtCIndirecto = dsOrdenTrabajo.Tables(4)
            End If
            If dsOrdenTrabajo.Tables(5).Rows.Count > 0 Then
                _dtMateriales = dsOrdenTrabajo.Tables(5)
            End If
            If dsOrdenTrabajo.Tables(6).Rows.Count > 0 Then
                _dtTotalServicios = dsOrdenTrabajo.Tables(6)
                _filaTotalServicios = dsOrdenTrabajo.Tables(6).Rows(0)
            End If
            If dsOrdenTrabajo.Tables(7).Rows.Count > 0 Then
                _dtComplemento = dsOrdenTrabajo.Tables(7)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión de Orden de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    Property IdReporteDiario As Int64 = -1
    Private filaReporteDiario As DataRow
    Private Sub CargarDataSetReporteDeTiempo()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImpresionReporteDeTiempo", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDREPORTEDIARIO", IdReporteDiario)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsReporteDeTiempo As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsReporteDeTiempo)
            conexion.Close()
            'Table  --> Reporte Diario
            'Table1 --> Personal
            'Table2 --> Equipo
            'Table3 --> Avance de obra
            'Table4 --> Materiales
            If dsReporteDeTiempo.Tables(0).Rows.Count > 0 Then
                filaReporteDiario = dsReporteDeTiempo.Tables(0).Rows(0)
            End If
            _dtPersonal = dsReporteDeTiempo.Tables(1)
            _dtEquipo = dsReporteDeTiempo.Tables(2)
            _dtServicios = dsReporteDeTiempo.Tables(3)
            _dtMateriales = dsReporteDeTiempo.Tables(4)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión de Reporte de Tiempo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    'Property IdComparativo As Int64 = -2
    Private Sub CargarDatasetComparativo()
        _dtServicios = New DataTable
        _dtEquipo = New DataTable
        _dtCIndirecto = New DataTable
        _dtMateriales = New DataTable
        _dtManoObra = New DataTable
        _dtAdicionales = New DataTable
        _dtComplemento = New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim cmd As New SqlCommand("dbo.ComparativoOrdenesCENIT", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@TIPO", 0)
        cmd.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        cmd.Parameters.AddWithValue("@FECHAI", DBNull.Value)
        cmd.Parameters.AddWithValue("@FECHAF", DBNull.Value)
        cmd.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        cmd.Parameters.AddWithValue("@TABLAIDOT", TablaIdC)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dsOT As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            'Table0 --> Orden de Trabajo
            'Table1 --> Servicios
            'Table2 --> Equipos
            'Table3 --> Costo Indirecto
            'Table4 --> Materiales
            'Table5 --> Mano de obra
            'Tabla6 --> Adicionales
            'Tabla7 --> Complemento

            If dsOT.Tables(0).Rows.Count > 0 Then
                _filaOrdenTrabajo = dsOT.Tables(0).Rows(0)
            End If
            If dsOT.Tables(1).Rows.Count > 0 Then
                _dtServicios = dsOT.Tables(1)
            End If
            If dsOT.Tables(2).Rows.Count > 0 Then
                _dtEquipo = dsOT.Tables(2)
            End If
            If dsOT.Tables(3).Rows.Count > 0 Then
                _dtCIndirecto = dsOT.Tables(3)
            End If
            If dsOT.Tables(4).Rows.Count > 0 Then
                _dtMateriales = dsOT.Tables(4)
            End If
            If dsOT.Tables(5).Rows.Count > 0 Then
                _dtManoObra = dsOT.Tables(5)
            End If
            If dsOT.Tables(6).Rows.Count > 0 Then
                _dtAdicionales = dsOT.Tables(6)
            End If
            If dsOT.Tables(7).Rows.Count > 0 Then
                _dtComplemento = dsOT.Tables(7)
                _filaComplemento = dsOT.Tables(7).Rows(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión de Orden de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Public IDOTSERVICIO As Int64 = -1
    Private Sub CargarDatasetComparativoServicio()
        _dtServicios = New DataTable
        _dtEquipo = New DataTable
        _dtCIndirecto = New DataTable
        _dtMateriales = New DataTable
        _dtManoObra = New DataTable
        _dtAdicionales = New DataTable
        _dtComplemento = New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim cmd As New SqlCommand("dbo.ComparativoOrdenesCENITServicio", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@TIPO", 0)
        cmd.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        cmd.Parameters.AddWithValue("@FECHAI", DBNull.Value)
        cmd.Parameters.AddWithValue("@FECHAF", DBNull.Value)
        cmd.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        cmd.Parameters.AddWithValue("@IDOTSERVICIO", IDOTSERVICIO)
        cmd.Parameters.AddWithValue("@TABLAIDOT", TablaIdC)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dsOT As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            'Table0 --> Orden de Trabajo
            'Table1 --> Servicios
            'Table2 --> Equipos
            'Table3 --> Costo Indirecto
            'Table4 --> Materiales
            'Table5 --> Mano de obra
            'Tabla6 --> Adicionales
            'Tabla7 --> Complemento

            If dsOT.Tables(0).Rows.Count > 0 Then
                _filaOrdenTrabajo = dsOT.Tables(0).Rows(0)
            End If
            If dsOT.Tables(1).Rows.Count > 0 Then
                _dtServicios = dsOT.Tables(1)
            End If
            If dsOT.Tables(2).Rows.Count > 0 Then
                _dtEquipo = dsOT.Tables(2)
            End If
            If dsOT.Tables(3).Rows.Count > 0 Then
                _dtCIndirecto = dsOT.Tables(3)
            End If
            If dsOT.Tables(4).Rows.Count > 0 Then
                _dtMateriales = dsOT.Tables(4)
            End If
            If dsOT.Tables(5).Rows.Count > 0 Then
                _dtManoObra = dsOT.Tables(5)
            End If
            If dsOT.Tables(6).Rows.Count > 0 Then
                _dtAdicionales = dsOT.Tables(6)
            End If
            If dsOT.Tables(7).Rows.Count > 0 Then
                _dtComplemento = dsOT.Tables(7)
                _filaComplemento = dsOT.Tables(7).Rows(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión de Orden de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CargarDatasetRDObraEjecutada()
        _dtDetalle = New DataTable
        _dtObservacion = New DataTable
        _dtResidente = New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim cmdOE As New SqlCommand("dbo.ExpRDCantidadObraEjecutada", conexion)
        cmdOE.CommandType = CommandType.StoredProcedure
        cmdOE.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        cmdOE.Parameters.AddWithValue("@FECHACORTE", FechaCorte)
        cmdOE.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        cmdOE.Parameters.AddWithValue("@TABLAIDOT", TablaIdOE)
        Dim adaptador As New SqlDataAdapter(cmdOE)
        Dim dsRDOE As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsRDOE)
            conexion.Close()
            'Table0 --> Orden de Trabajo
            'Table1 --> Detalle
            'Table2 --> Observación

            If dsRDOE.Tables(0).Rows.Count > 0 Then
                _filaOrdenTrabajo = dsRDOE.Tables(0).Rows(0)
            End If
            If dsRDOE.Tables(1).Rows.Count > 0 Then
                _dtDetalle = dsRDOE.Tables(1)
            End If
            If dsRDOE.Tables(2).Rows.Count > 0 Then
                _dtObservacion = dsRDOE.Tables(2)
            End If
            If dsRDOE.Tables(3).Rows.Count > 0 Then
                _dtResidente = dsRDOE.Tables(3)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión de Orden de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Dim dsE As New DataSet
    Private Sub CargarDatasetControlMensualTransporte()
        _dtDetalle = New DataTable
        _dtTotal = New DataTable
        _dtResumenOM = New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim cmdE As New SqlCommand("dbo.ControlVehiculo", conexion)
        cmdE.CommandType = CommandType.StoredProcedure
        cmdE.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        cmdE.Parameters.AddWithValue("@AÑO", Año)
        cmdE.Parameters.AddWithValue("@MES", Mes)
        cmdE.Parameters.AddWithValue("@TIPO", 0)
        cmdE.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        cmdE.Parameters.AddWithValue("@FECHAI", FechaI)
        cmdE.Parameters.AddWithValue("@FECHAF", FechaF)
        cmdE.Parameters.AddWithValue("@TABLAIDE", TablaIdE)
        Dim adaptador As New SqlDataAdapter(cmdE)

        Try
            conexion.Open()
            adaptador.Fill(dsE)
            conexion.Close()

            'Table0 --> Orden de Trabajo
            'Table1 --> Detalle
            ''Table2 --> Observación

            'If dsE.Tables(0).Rows.Count > 0 Then
            '    _filaRDEquipo = dsE.Tables(0).Rows(0)
            'End If

            'If dsE.Tables(1).Rows.Count > 0 Then
            '    _dtDetalle = dsE.Tables(1)
            'Else
            '    Throw New Exception("No hay reportes entre estas fechas")
            'End If
            'If dsE.Tables(2).Rows.Count > 0 Then
            '    _dtTotal = dsE.Tables(2)
            'End If
            'If dsE.Tables(3).Rows.Count > 0 Then
            '    _dtResumenOM = dsE.Tables(3)
            'End If

        Catch ex As Exception
            Throw New Exception("No hay reportes entre estas fechas")
        Finally
            conexion.Close()
        End Try
    End Sub


#End Region

#Region "  1 - Formato Ordenes de Trabajo"
    Private WithEvents DocImp_OT As New PrintDocument
    Dim pendienteimprimir As Boolean = False
    Dim ContServicios As Integer = 0
    Dim ContPersonal As Integer = 0
    Dim ContComplemento As Integer = 0
    Dim ContEquipo As Integer = 0
    Dim ContCIndirecto As Integer = 0
    Dim ContMateriales As Integer = 0
    Dim ContadorRenglones As Integer = 0
    Dim ContadorExt As Integer = 0
    Dim CargaPropiedades As Boolean = False
    Dim CargaServicios As Boolean = False
    Dim CargaPersonal As Boolean = False
    Dim CargaComplemento As Boolean = False
    Dim CargaEquipos As Boolean = False
    Dim CargaCIndirecto As Boolean = False
    Dim CargaMateriales As Boolean = False
    Dim drawFormat As New StringFormat
    Dim drawFormat1 As New StringFormat

    Private Sub DocImpOT(sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_OT.PrintPage
        Dim InicioDespuesEncabezado As Integer = 485
        Dim ContadorInt As Integer = 0
        Dim puntoOrigen As New Point(55, 52)
        e.Graphics.DrawImage(logoIsmocol, 47, 27, 85, 60)
        e.Graphics.DrawStringCentered("ORDEN DE TRABAJO", Formato_Etiqueta_14, Brushes.Black, 770, puntoOrigen.X, puntoOrigen.Y)
        Dim puntoOrigen1 As New Point(27, 115)
        drawFormat.Alignment = StringAlignment.Far
        drawFormat1.Alignment = StringAlignment.Center
        If CargaPropiedades = False Then
            CargaPropiedades = True
        End If
        If ContadorExt = 0 Then
            If ContadorInt = 0 Then
                e.Graphics.DrawStringCentered("*  *  *  *  *  B A S I C A   *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen.X, puntoOrigen.Y + 50)
                e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X, puntoOrigen1.Y, 770, 370)
                e.Graphics.DrawString("Número Orden de Trabajo:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 2)
                e.Graphics.DrawString(_filaOrdenTrabajo("NROORDENSAP"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 2)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 15, puntoOrigen1.X + 770, puntoOrigen1.Y + 15) 'Horizontal completa
                e.Graphics.DrawString("Es SubOrden:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 17)
                e.Graphics.DrawString(_filaOrdenTrabajo("ESSUBORDEN"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 17)
                If _filaOrdenTrabajo("ESSUBORDEN") = "S" Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 280, puntoOrigen1.Y + 15, puntoOrigen1.X + 280, puntoOrigen1.Y + 30) 'Vertical
                    e.Graphics.DrawString("Orden Padre:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 285, puntoOrigen1.Y + 17)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 410, puntoOrigen1.Y + 15, puntoOrigen1.X + 410, puntoOrigen1.Y + 30) 'Vertical
                    If Not IsDBNull(_filaOrdenTrabajo("NROORDENSAPPADRE")) Then
                        e.Graphics.DrawString(_filaOrdenTrabajo("NROORDENSAPPADRE"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 415, puntoOrigen1.Y + 17)
                    End If
                Else
                    e.Graphics.DrawString(" ", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 285, puntoOrigen1.Y + 17)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 30, puntoOrigen1.X + 770, puntoOrigen1.Y + 30) 'Horizontal completa
                e.Graphics.DrawString("Sub Base:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 32)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBREBASE"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 32)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 45, puntoOrigen1.X + 770, puntoOrigen1.Y + 45) 'Horizontal completa
                e.Graphics.DrawString("Fecha de Creación OT en SAP:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 47)
                e.Graphics.DrawString(_filaOrdenTrabajo("FECHACREACIONSAP"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 47)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 60, puntoOrigen1.X + 770, puntoOrigen1.Y + 60) 'Horizontal completa
                e.Graphics.DrawString("Objeto:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 64)
                Dim objeto As String = _filaOrdenTrabajo("OBJETO").ToString.Trim
                Select Case objeto.Length
                    Case Is < 129
                        e.Graphics.DrawString(objeto, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 65)
                        Exit Select
                    Case Is <= 145
                        e.Graphics.DrawString(objeto, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 67)
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(objeto, 1, 145), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 61)
                        e.Graphics.DrawString(Mid(objeto, 146, 145), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 70)
                End Select
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 80, puntoOrigen1.X + 770, puntoOrigen1.Y + 80) 'Horizontal completa
                e.Graphics.DrawString("Clase Orden SAP:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 82)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBRETIPOCLASEORDEN"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 82)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 95, puntoOrigen1.X + 770, puntoOrigen1.Y + 95) 'Horizontal completa
                e.Graphics.DrawString("Clase Actividad SAP:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 97)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBRETIPOCLASEACTIVIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 97)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 110, puntoOrigen1.X + 770, puntoOrigen1.Y + 110) 'Horizontal completa
                e.Graphics.DrawString("Estado:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 112)
                e.Graphics.DrawString(_filaOrdenTrabajo("ESTADO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 112)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 125, puntoOrigen1.X + 770, puntoOrigen1.Y + 125) 'Horizontal completa
                e.Graphics.DrawString("Fecha de Inicio:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 125)
                e.Graphics.DrawString(_filaOrdenTrabajo("FECHAINICIO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 127)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 280, puntoOrigen1.Y + 125, puntoOrigen1.X + 280, puntoOrigen1.Y + 140) 'Vertical
                e.Graphics.DrawString("Fecha Fín:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 285, puntoOrigen1.Y + 127)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, puntoOrigen1.Y + 125, puntoOrigen1.X + 398, puntoOrigen1.Y + 140) 'Vertical
                e.Graphics.DrawString(_filaOrdenTrabajo("FECHAFIN"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 403, puntoOrigen1.Y + 127)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 538, puntoOrigen1.Y + 125, puntoOrigen1.X + 538, puntoOrigen1.Y + 140) 'Vertical
                e.Graphics.DrawString("Fecha Fín Extremo:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 543, puntoOrigen1.Y + 127)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, puntoOrigen1.Y + 125, puntoOrigen1.X + 688, puntoOrigen1.Y + 140) 'Vertical
                e.Graphics.DrawString(_filaOrdenTrabajo("FECHAFINEXTREMO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 693, puntoOrigen1.Y + 127)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 140, puntoOrigen1.X + 770, puntoOrigen1.Y + 140) 'Horizontal completa
                e.Graphics.DrawString("Fecha de Inicio Ismocol:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 142)
                If Not IsDBNull(_filaOrdenTrabajo("FECHAINICIOISMOCOL")) Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("FECHAINICIOISMOCOL"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 142)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 280, puntoOrigen1.Y + 140, puntoOrigen1.X + 280, puntoOrigen1.Y + 155) 'Vertical
                e.Graphics.DrawString("Fecha Fín Ismocol:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 285, puntoOrigen1.Y + 142)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, puntoOrigen1.Y + 140, puntoOrigen1.X + 398, puntoOrigen1.Y + 155) 'Vertical
                If Not IsDBNull(_filaOrdenTrabajo("FECHAFINISMOCOL")) Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("FECHAFINISMOCOL"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 403, puntoOrigen1.Y + 142)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 155, puntoOrigen1.X + 770, puntoOrigen1.Y + 155) 'Horizontal completa
                e.Graphics.DrawString("Área Atención Primaria:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 157)
                e.Graphics.DrawString(_filaOrdenTrabajo("AREAATENCIONPRIMARIA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 157)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 170, puntoOrigen1.X + 770, puntoOrigen1.Y + 170) 'Horizontal completa
                e.Graphics.DrawString("Tipo Actividad:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 172)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBRETIPOACTIVIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 172)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 185, puntoOrigen1.X + 770, puntoOrigen1.Y + 185) 'Horizontal completa
                e.Graphics.DrawString("Tipo Reparación:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 187)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBRETIPOREPARACION"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 187)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 200, puntoOrigen1.X + 770, puntoOrigen1.Y + 200) 'Horizontal completa
                e.Graphics.DrawString("Ubicación Técnica:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 202)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBREUBICACIONTECNICA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 202)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 215, puntoOrigen1.X + 770, puntoOrigen1.Y + 215) 'Horizontal completa
                e.Graphics.DrawString("Equipo:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 217)
                If Not IsDBNull(_filaOrdenTrabajo("NOMBREEQUIPOSAP")) Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("NOMBREEQUIPOSAP"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 217)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 230, puntoOrigen1.X + 770, puntoOrigen1.Y + 230) 'Horizontal completa
                e.Graphics.DrawString("Abscisa:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 232)
                e.Graphics.DrawString(_filaOrdenTrabajo("ABSCISA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 232)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 245, puntoOrigen1.X + 770, puntoOrigen1.Y + 245) 'Horizontal completa
                e.Graphics.DrawString("Georeferenciación:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 247)
                If Not IsDBNull(Trim(_filaOrdenTrabajo("GEOREFERENCIACION"))) Then
                    e.Graphics.DrawString(Trim(_filaOrdenTrabajo("GEOREFERENCIACION")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 247)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, puntoOrigen1.Y + 245, puntoOrigen1.X + 398, puntoOrigen1.Y + 260) 'Vertical
                e.Graphics.DrawString("Latitud:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 403, puntoOrigen1.Y + 247)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 478, puntoOrigen1.Y + 245, puntoOrigen1.X + 478, puntoOrigen1.Y + 260) 'Vertical
                If Not IsDBNull(_filaOrdenTrabajo("LATITUD")) Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("LATITUD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 483, puntoOrigen1.Y + 247)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, puntoOrigen1.Y + 245, puntoOrigen1.X + 598, puntoOrigen1.Y + 260) 'Vertical
                e.Graphics.DrawString("Longitud:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 603, puntoOrigen1.Y + 247)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, puntoOrigen1.Y + 245, puntoOrigen1.X + 688, puntoOrigen1.Y + 260) 'Vertical
                If Not IsDBNull(_filaOrdenTrabajo("LONGITUD")) Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("LONGITUD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 693, puntoOrigen1.Y + 247)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 260, puntoOrigen1.X + 770, puntoOrigen1.Y + 260) 'Horizontal completa
                e.Graphics.DrawString("Municipio:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 262)
                e.Graphics.DrawString(_filaOrdenTrabajo("NOMBREPOBLACION"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 262)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, puntoOrigen1.Y + 260, puntoOrigen1.X + 398, puntoOrigen1.Y + 275) 'Vertical
                e.Graphics.DrawString("Vereda:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 403, puntoOrigen1.Y + 262)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 478, puntoOrigen1.Y + 260, puntoOrigen1.X + 478, puntoOrigen1.Y + 275) 'Vertical
                e.Graphics.DrawString(_filaOrdenTrabajo("VEREDA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 483, puntoOrigen1.Y + 262)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 275, puntoOrigen1.X + 770, puntoOrigen1.Y + 275) 'Horizontal completa
                e.Graphics.DrawString("Observación:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 279)
                Dim observacion As String = _filaOrdenTrabajo("OBSERVACION").ToString.Trim
                If Not IsDBNull(observacion) Then
                    Select Case observacion.Length
                        Case Is < 129
                            e.Graphics.DrawString(observacion, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 280)
                            Exit Select
                        Case Is <= 145
                            e.Graphics.DrawString(observacion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 282)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(observacion, 1, 145), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 276)
                            e.Graphics.DrawString(Mid(observacion, 146, 145), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 285)
                    End Select
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 295, puntoOrigen1.X + 770, puntoOrigen1.Y + 295) 'Horizontal completa
                e.Graphics.DrawString("Supervisor Ismocol:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 297)
                e.Graphics.DrawString(_filaOrdenTrabajo("supervisor Ismocol"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 297)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 310, puntoOrigen1.X + 770, puntoOrigen1.Y + 310) 'Horizontal completa
                e.Graphics.DrawString("Supervisor Ecopetrol:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 312)
                e.Graphics.DrawString(_filaOrdenTrabajo("Supervisor Ecopetrol"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 312)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 325, puntoOrigen1.X + 770, puntoOrigen1.Y + 325) 'Horizontal completa
                e.Graphics.DrawString("Facturador Responsable:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 327)
                e.Graphics.DrawString(_filaOrdenTrabajo("Facturador"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 327)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 340, puntoOrigen1.X + 770, puntoOrigen1.Y + 340) 'Horizontal completa
                e.Graphics.DrawString("Administración:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 342)
                e.Graphics.DrawString(_filaOrdenTrabajo("PORADMINISTRACION"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 185, puntoOrigen1.Y + 342)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 280, puntoOrigen1.Y + 340, puntoOrigen1.X + 280, puntoOrigen1.Y + 355) 'Vertical
                e.Graphics.DrawString("Impuestos:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 285, puntoOrigen1.Y + 342)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, puntoOrigen1.Y + 340, puntoOrigen1.X + 398, puntoOrigen1.Y + 355) 'Vertical
                e.Graphics.DrawString(_filaOrdenTrabajo("PORIMPUESTOS"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 403, puntoOrigen1.Y + 342)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 478, puntoOrigen1.Y + 340, puntoOrigen1.X + 478, puntoOrigen1.Y + 355) 'Vertical
                e.Graphics.DrawString("Utilidad:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 483, puntoOrigen1.Y + 342)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 538, puntoOrigen1.Y + 340, puntoOrigen1.X + 538, puntoOrigen1.Y + 355) 'Vertical
                e.Graphics.DrawString(_filaOrdenTrabajo("PORUTILIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 543, puntoOrigen1.Y + 342)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, puntoOrigen1.Y + 340, puntoOrigen1.X + 598, puntoOrigen1.Y + 355) 'Vertical
                e.Graphics.DrawString("Total AIU:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 603, puntoOrigen1.Y + 342)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, puntoOrigen1.Y + 340, puntoOrigen1.X + 688, puntoOrigen1.Y + 355) 'Vertical
                e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, puntoOrigen1.Y + 342)
                e.Graphics.DrawString(FormatearValor(_filaOrdenTrabajo("VALORTOTALSAP")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, puntoOrigen1.Y + 342, drawFormat)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 180, puntoOrigen1.Y, puntoOrigen1.X + 180, puntoOrigen1.Y + 370) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 355, puntoOrigen1.X + 770, puntoOrigen1.Y + 355) 'Horizontal completa
                e.Graphics.DrawString("Valor Servicios:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 5, puntoOrigen1.Y + 357)
                e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 180, puntoOrigen1.Y + 357)
                e.Graphics.DrawString(FormatearValor(_filaOrdenTrabajo("VALORTOTALSAP")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 398, puntoOrigen1.Y + 357, drawFormat)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, puntoOrigen1.Y + 355, puntoOrigen1.X + 398, puntoOrigen1.Y + 370) 'Vertical
                e.Graphics.DrawString("Costos:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 403, puntoOrigen1.Y + 357)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 478, puntoOrigen1.Y + 355, puntoOrigen1.X + 478, puntoOrigen1.Y + 370) 'Vertical
                e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 483, puntoOrigen1.Y + 357)
                e.Graphics.DrawString(FormatearValor(_filaTotalServicios("TOTALSERVICIOS")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 598, puntoOrigen1.Y + 357, drawFormat)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, puntoOrigen1.Y + 355, puntoOrigen1.X + 598, puntoOrigen1.Y + 370) 'Vertical
                e.Graphics.DrawString("Diferencia:", Formato_Etiqueta_8, Brocha, puntoOrigen1.X + 603, puntoOrigen1.Y + 357)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, puntoOrigen1.Y + 355, puntoOrigen1.X + 688, puntoOrigen1.Y + 370) 'Vertical
                e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, puntoOrigen1.Y + 357)
                Dim Diferencia As Decimal = (_filaOrdenTrabajo("VALORTOTALSAP") - _filaTotalServicios("TOTALSERVICIOS"))
                If (Diferencia) > 0 Then
                    e.Graphics.DrawString(FormatearValor(Diferencia), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, puntoOrigen1.Y + 357, drawFormat)
                Else
                    e.Graphics.DrawString(FormatearValor(Diferencia), Formato_Etiqueta_7R, BrochaRoja, puntoOrigen1.X + 770, puntoOrigen1.Y + 357, drawFormat)
                End If
            End If

            ContadorExt = 1

        End If
        If CargaServicios = False Then
            CargaServicios = True
        End If
        If ContadorRenglones < 30 Then
            If _dtServicios.Rows.Count > 0 And _dtServicios.Rows.Count > ContServicios Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawStringCentered("*  *  *  *  *  S E R V I C I O S  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Código", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 24, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Descripción", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 223, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Vr Unitario", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 438, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 478, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 478, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("F Inicial", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 508, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("F Final", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Und", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 623, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 668, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Vr Total", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 729, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                Dim filaServicio As DataRow
                For j = ContServicios To _dtServicios.Rows.Count - 1
                    filaServicio = _dtServicios.Rows(j)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaServicio("CODIGOSERVICIO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    Dim observacion As String = filaServicio("NOMBRESERVICIO").ToString.Trim
                    Select Case observacion.Length
                        Case Is < 68
                            e.Graphics.DrawString(observacion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 50, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                            Exit Select
                        Case Is <= 78
                            e.Graphics.DrawString(observacion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 50, InicioDespuesEncabezado + ContadorRenglones * 15 + 8)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(observacion, 1, 78), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 50, InicioDespuesEncabezado + ContadorRenglones * 15 + 3)
                            e.Graphics.DrawString(Mid(observacion, 79, 78), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 50, InicioDespuesEncabezado + ContadorRenglones * 15 + 9)
                    End Select
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 400, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawString(FormatearValor(filaServicio("VALORUNITARIO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 478, InicioDespuesEncabezado + ContadorRenglones * 15 + 5, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 478, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 478, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    If Not IsDBNull(filaServicio("FECHAINICIAL")) Then
                        e.Graphics.DrawString(filaServicio("FECHAINICIAL"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 480, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    If Not IsDBNull(filaServicio("FECHAFINAL")) Then
                        e.Graphics.DrawString(filaServicio("FECHAFINAL"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 540, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaServicio("ABREVIATURA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 600 + InicioCentradoTexto(filaServicio("ABREVIATURA"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaServicio("CANTIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 5, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawString(FormatearValor(filaServicio("VALORTOTAL")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 5, drawFormat)

                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    ContServicios = ContServicios + 1
                    If ContadorRenglones > 35 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
                If pendienteimprimir = False Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("Total: ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    If Not IsDBNull(_dtServicios.Compute("Sum(VALORTOTAL)", "")) Then
                        e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                        e.Graphics.DrawString(FormatearValor(_dtServicios.Compute("Sum(VALORTOTAL)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 5, drawFormat)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                End If
            End If
        End If
        ContadorRenglones = ContadorRenglones + 1
        If CargaPersonal = False Then
            CargaPersonal = True
        End If
        If ContadorRenglones < 30 Then
            If _dtPersonal.Rows.Count > 0 And _dtPersonal.Rows.Count > ContPersonal Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawStringCentered("*  *  *  *  *  P E R S O N A L *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Servicio", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 24, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 257, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 443, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, drawFormat1)
                e.Graphics.DrawString("Contratar", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 443, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Duración", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 493, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Und", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 543, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Unitario", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 608, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 668, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Total", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 731, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                ContadorRenglones = ContadorRenglones + 1
                Dim filaPersonal As DataRow
                For j = ContPersonal To _dtPersonal.Rows.Count - 1
                    filaPersonal = _dtPersonal.Rows(j)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaPersonal("SERVICIO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    Dim cargo As String = filaPersonal("NOMBREPERSONAL").ToString.Trim
                    Select Case cargo.Length
                        Case Is < 58
                            e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)

                            Exit Select
                        Case Is <= 82
                            e.Graphics.DrawString(cargo, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(cargo, 1, 82), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 3)
                            e.Graphics.DrawString(Mid(cargo, 83, 82), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 10)
                    End Select
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaPersonal("CANTIDADCONTRATAR"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 418 + InicioCentradoTexto(filaPersonal("CANTIDADCONTRATAR"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaPersonal("CANTIDADUNIDADESCONTRATAR"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 493, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaPersonal("ABREVIATURA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 520 + InicioCentradoTexto(filaPersonal("ABREVIATURA"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 570, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaPersonal("VALORUNITARIO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaPersonal("CANTIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaPersonal("VALORTOTAL")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    ContPersonal = ContPersonal + 1
                    If ContadorRenglones > 35 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
                If pendienteimprimir = False Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("Total: ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(_dtPersonal.Compute("Sum(VALORTOTAL)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                End If
            End If
        End If
        ContadorRenglones = ContadorRenglones + 1
        If CargaComplemento = False Then
            CargaComplemento = True
        End If
        If ContadorRenglones < 30 Then
            If _dtComplemento.Rows.Count > 0 And _dtComplemento.Rows.Count > ContComplemento Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawStringCentered("*  *  *  *  *  COMPLEMENTO  *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 119, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 238, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 238, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 263, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, drawFormat1)
                e.Graphics.DrawString("Contratar", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 263, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 288, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 288, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Duración", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 313, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 338, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 338, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("D", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 348, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 358, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 358, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("A", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 368, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 378, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 378, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("C", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 388, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("H", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 408, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("M", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 428, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 438, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 438, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Des", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 461, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 488, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 488, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Alm", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 511, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Com", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 561, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 588, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 588, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Hot", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 611, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 638, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 638, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Misc", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 661, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Total", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 731, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                ContadorRenglones = ContadorRenglones + 1
                Dim filaComplemento As DataRow
                For j = ContComplemento To _dtComplemento.Rows.Count - 1
                    filaComplemento = _dtComplemento.Rows(j)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    Dim cargo As String = filaComplemento("NOMBREPERSONAL").ToString.Trim
                    Select Case cargo.Length
                        Case Is < 41
                            e.Graphics.DrawString(cargo, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)

                            Exit Select
                        Case Is <= 56
                            e.Graphics.DrawString(cargo, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(cargo, 1, 56), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 3)
                            e.Graphics.DrawString(Mid(cargo, 57, 56), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 10)
                    End Select
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 238, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 238, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("CANTIDADCONTRATAR"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 238 + InicioCentradoTexto(filaComplemento("CANTIDADCONTRATAR"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 288, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 288, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("CANTIDADUNIDADESCONTRATAR"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 313, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 338, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 338, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("DESAYUNO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 348, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 358, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 358, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("ALMUERZO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 368, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 378, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 378, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("COMIDA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 388, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 398, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("ALOJAMIENTO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 408, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaComplemento("MISCELANIOS"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 428, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 438, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 438, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 440, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaComplemento("VALORDESAYUNO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 488, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 488, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 488, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 490, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaComplemento("VALORALMUERZO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 538, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 540, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaComplemento("VALORCOMIDA")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 588, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 588, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 588, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 590, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaComplemento("VALORALOJAMIENTO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 638, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 638, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 638, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 640, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaComplemento("VALORMISCELANIOS")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(filaComplemento("TOTALCOMPLEMENTO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    ContComplemento = ContComplemento + 1
                    If ContadorRenglones > 35 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
            If pendienteimprimir = False Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("Total: ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(_dtComplemento.Compute("Sum(TOTALCOMPLEMENTO)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                End If
            End If
        End If
        ContadorRenglones = ContadorRenglones + 1
        If CargaEquipos = False Then
            CargaEquipos = True
        End If
        If ContadorRenglones < 30 Then
            If _dtEquipo.Rows.Count > 0 And _dtEquipo.Rows.Count > ContEquipo Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawStringCentered("*  *  *  *  *  E Q U I P O *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Servicio", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 24, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Equipo", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 257, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 443, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, drawFormat1)
                e.Graphics.DrawString("Contratar", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 443, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Duración", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 493, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Und", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 543, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Unitario", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 608, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 668, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Vr Total", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 729, InicioDespuesEncabezado + ContadorRenglones * 15 + 2, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                ContadorRenglones = ContadorRenglones + 1
                Dim filaEquipo As DataRow
                For j = ContEquipo To _dtEquipo.Rows.Count - 1
                    filaEquipo = _dtEquipo.Rows(j)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaEquipo("SERVICIO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    Dim equipo As String = filaEquipo("NOMBREQUIPO").ToString.Trim
                    Select Case equipo.Length
                        Case Is < 58
                            e.Graphics.DrawString(equipo, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)

                            Exit Select
                        Case Is <= 82
                            e.Graphics.DrawString(equipo, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(equipo, 1, 82), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 3)
                            e.Graphics.DrawString(Mid(equipo, 83, 82), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15 + 10)
                    End Select
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 418, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaEquipo("CANTIDADCONTRATAR"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 418 + InicioCentradoTexto(filaEquipo("CANTIDADCONTRATAR"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 468, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaEquipo("CANTIDADUNIDADESCONTRATAR"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 493, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat1)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaEquipo("ABREVIATURA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 520 + InicioCentradoTexto(filaEquipo("ABREVIATURA"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    If Not IsDBNull(filaEquipo("VALORUNITARIO")) Then
                        e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 570, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                        e.Graphics.DrawString(FormatearValor(filaEquipo("VALORUNITARIO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaEquipo("CANTIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    If Not IsDBNull(filaEquipo("VALORTOTAL")) Then
                        e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                        e.Graphics.DrawString(FormatearValor(filaEquipo("VALORTOTAL")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    ContEquipo = ContEquipo + 1
                    If ContadorRenglones > 35 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
                If pendienteimprimir = False Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("Total: ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15 + 7)
                    e.Graphics.DrawString(FormatearValor(_dtEquipo.Compute("Sum(VALORTOTAL)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 7, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 3, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 18, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                End If
            End If
        End If
        ContadorRenglones = ContadorRenglones + 1
        If CargaCIndirecto = False Then
            CargaCIndirecto = True
        End If
        If ContadorRenglones < 30 Then
            If _dtCIndirecto.Rows.Count > 0 And _dtCIndirecto.Rows.Count > ContCIndirecto Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawStringCentered("*  *  *  *  *  C O S T O  D I R E C T O *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Servicio", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 24, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Costo Indirecto", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 332, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Vr Unitario", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 608, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 668, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Vr Total", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 729, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                Dim filaCIndirecto As DataRow
                For j = ContCIndirecto To _dtCIndirecto.Rows.Count - 1
                    filaCIndirecto = _dtCIndirecto.Rows(j)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString(filaCIndirecto("SERVICIO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    If Not IsDBNull(filaCIndirecto("NOMBRECOSTOINDIRECTO")) Then
                        e.Graphics.DrawString(filaCIndirecto("NOMBRECOSTOINDIRECTO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 53, InicioDespuesEncabezado + ContadorRenglones * 15)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    If Not IsDBNull(filaCIndirecto("VALORUNITARIO")) Then
                        e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 570, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawString(FormatearValor(filaCIndirecto("VALORUNITARIO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    If Not IsDBNull(filaCIndirecto("CANTIDAD")) Then
                        e.Graphics.DrawString(filaCIndirecto("CANTIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    If Not IsDBNull(filaCIndirecto("VALORTOTAL")) Then
                        e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15)
                        e.Graphics.DrawString(FormatearValor(filaCIndirecto("VALORTOTAL")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    End If
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContCIndirecto = ContCIndirecto + 1
                    If ContadorRenglones > 35 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
                If pendienteimprimir = False Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("Total: ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawString(FormatearValor(_dtCIndirecto.Compute("Sum(VALORTOTAL)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                End If
            End If
        End If
        If CargaMateriales = False Then
            CargaMateriales = True
        End If
        If ContadorRenglones < 30 Then
            If _dtMateriales.Rows.Count > 0 And _dtMateriales.Rows.Count > ContMateriales Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawStringCentered("*  *  *  *  *  M A T E R I A L E S *  *  *  *  *", Formato_Etiqueta_7, Brocha, 770, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Servicio", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 24, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Código", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 72, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 96, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 96, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Descripción", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 331, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Und", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 543, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Vr Unitario", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 608, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                e.Graphics.DrawString("Cant", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 668, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                e.Graphics.DrawString("Vr Total", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 729, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat1)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                ContadorRenglones = ContadorRenglones + 1
                Dim filaMateriales As DataRow
                For j = ContMateriales To _dtMateriales.Rows.Count - 1
                    filaMateriales = _dtMateriales.Rows(j)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString(filaMateriales("SERVICIO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 48, InicioDespuesEncabezado + ContadorRenglones * 15 + 18)
                    e.Graphics.DrawString(filaMateriales("IDARTICULO"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 96, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 96, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 96, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    Dim descripcion As String = filaMateriales("NOMBREDESCRIPTIVO").ToString.Trim
                    Select Case descripcion.Length
                        Case Is < 71
                            e.Graphics.DrawString(descripcion, Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 98, InicioDespuesEncabezado + ContadorRenglones * 15)
                            Exit Select
                        Case Is <= 90
                            e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 98, InicioDespuesEncabezado + ContadorRenglones * 15 + 3)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(descripcion, 1, 90), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 98, InicioDespuesEncabezado + ContadorRenglones * 15 - 2)
                            e.Graphics.DrawString(Mid(descripcion, 91, 90), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 98, InicioDespuesEncabezado + ContadorRenglones * 15 + 5)
                    End Select
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString(filaMateriales("ABREVIATURA"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 520 + InicioCentradoTexto(filaMateriales("ABREVIATURA"), Formato_Etiqueta_7R, 50, e), InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 568, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 570, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawString(FormatearValor(filaMateriales("VALORUNITARIO")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 648, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString(filaMateriales("CANTIDAD"), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawString(FormatearValor(filaMateriales("VALORTOTAL")), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    ContMateriales = ContMateriales + 1
                    If ContadorRenglones > 35 Then
                        pendienteimprimir = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
                If pendienteimprimir = False Then
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("Total: ", Formato_Etiqueta_7, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones * 15)
                    e.Graphics.DrawString(FormatearValor(_dtMateriales.Compute("Sum(VALORTOTAL)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15, drawFormat)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 - 2, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 598, InicioDespuesEncabezado + ContadorRenglones * 15 + 13, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones * 15 + 13)
                End If
            End If
        End If
        If CargaPropiedades = False Or CargaServicios = False Or CargaPersonal = False Or CargaComplemento = False Or CargaEquipos = False Or CargaCIndirecto = False Or CargaMateriales = False Then
            pendienteimprimir = True
        End If
        If pendienteimprimir = False Then
            If CargaServicios = True And _dtServicios.Rows.Count > ContServicios Then
                pendienteimprimir = True
            End If
            If CargaPersonal = True And _dtPersonal.Rows.Count > ContPersonal Then
                pendienteimprimir = True
            End If
            If CargaComplemento = True And _dtComplemento.Rows.Count > ContComplemento Then
                pendienteimprimir = True
            End If
            If CargaEquipos = True And _dtEquipo.Rows.Count > ContEquipo Then
                pendienteimprimir = True
            End If
            If CargaCIndirecto = True And _dtCIndirecto.Rows.Count > ContCIndirecto Then
                pendienteimprimir = True
            End If
            If CargaMateriales = True And _dtMateriales.Rows.Count > ContMateriales Then
                pendienteimprimir = True
            End If
        End If
        If pendienteimprimir = True Then
            e.Graphics.DrawString("CONTINUA SIGUIENTE PAGINA", Formato_Etiqueta_6, Brocha, 650, 1050)
            ContadorRenglones = 0
            e.HasMorePages = True
            ContadorRenglones = -28
            pendienteimprimir = False
        Else
            ContadorRenglones = 0
            ContServicios = 0
            ContPersonal = 0
            ContComplemento = 0
            ContEquipo = 0
            ContCIndirecto = 0
            ContMateriales = 0
            ContadorExt = 0
            e.HasMorePages = False
        End If
    End Sub
#End Region

#Region " 10 - ICA-OMC-F-01 Reporte dirario de tiempo trabajado (TÉCNICO)"
    Const anchoDocumentoReporteDiario As UInteger = 1030
    Const espaciadorCeldasGrandeReporteDiario As UInteger = 7
    Const espaciadorCeldasMedioReporteDiario As UInteger = 4
    Const espaciadorCeldasPequennoReporteDiario As UInteger = 2
    Private PuntoOrigenReporteDiario As New Point(10, 50)
    Private fuenteConvencionesReporteDiario As New Font("Arial", 4.0!, FontStyle.Bold)
    Private SeccionReporteDiario As UInteger = 1
    Private contadorPersonalReporteDiario As UInteger = 0
    Private contadorEquiposReporteDiario As UInteger = 0
    Private contadorMaterialesReporteDiario As UInteger = 0
    Private contadorAvanceReporteDiario As UInteger = 0
    Private WithEvents DocImp_ReporteDiarioDeTiempo As PrintDocument
    Private Sub EvImp_ReporteDiarioDeTiempo(sender As Object, e As PrintPageEventArgs) Handles DocImp_ReporteDiarioDeTiempo.PrintPage


        Dim puntoY As UInteger = PuntoOrigenReporteDiario.Y
        Dim y As UInteger = 0
        Dim altoBloque As UInteger = 0
        Dim anchoBloque As UInteger = 0
        Dim fechaReporte As Date = filaReporteDiario("FECHAREPORTEDIARIO")
        Dim cadenas As New ArrayList
        Dim cadenasTotalParrafo As New ArrayList

        'e.Graphics.DrawGrid(Color.LightGray, True, 0.5, Formato_Etiqueta_4, PuntoOrigenReporteDiario.X, PuntoOrigenReporteDiario.Y, anchoDocumentoReporteDiario, 710, 10, 10)

        'Encabezado
        altoBloque = 85
        e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, PuntoOrigenReporteDiario.Y, anchoDocumentoReporteDiario, altoBloque)
        e.Graphics.DrawImage(logoIsmocol, PuntoOrigenReporteDiario.X + 5, puntoY + 17, 60, 50)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY, PuntoOrigenReporteDiario.X + 70, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered("REPORTE DIARIO DE TIEMPO TRABAJADO", Formato_Etiqueta_8, Brocha, 730, PuntoOrigenReporteDiario.X + 80, puntoY + 9) 'PuntoY + 3
        'e.Graphics.DrawStringCentered(filaReporteDiario("REPORTEDIARIO"), Formato_Etiqueta_8, Brocha, 730, PuntoOrigenReporteDiario.X + 80, puntoY + 16)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 805, puntoY, PuntoOrigenReporteDiario.X + 805, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered("ICA-OMC-F-01", Formato_Etiqueta_8, Brocha, 220, PuntoOrigenReporteDiario.X + 805, puntoY + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 805, puntoY + 20, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 20) 'horizontal
        e.Graphics.DrawStringCentered("Revisión No. " & "1", Formato_Etiqueta_6, Brocha, 220, PuntoOrigenReporteDiario.X + 805, puntoY + 20)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 30, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 30) 'horizontal
        puntoY += 30
        e.Graphics.DrawString("CONTRATO No.", Formato_Etiqueta_7, Brocha, PuntoOrigenReporteDiario.X + 70, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 165, puntoY, PuntoOrigenReporteDiario.X + 165, puntoY + 55) 'vertical
        e.Graphics.DrawString(filaReporteDiario("CONTRATOISMOCOL"), Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteDiario.X + 170, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 545, puntoY, PuntoOrigenReporteDiario.X + 545, puntoY + 55) 'vertical
        e.Graphics.DrawStringCentered("CENTRO COSTOS", Formato_Etiqueta_7, Brocha, 120, PuntoOrigenReporteDiario.X + 545, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 670, puntoY, PuntoOrigenReporteDiario.X + 670, puntoY + 55) 'vertical
        e.Graphics.DrawString(filaReporteDiario("CENTROCOSTO"), Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteDiario.X + 675, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 805, puntoY, PuntoOrigenReporteDiario.X + 805, puntoY + 55) 'vertical
        e.Graphics.DrawStringCentered("BASE", Formato_Etiqueta_7, Brocha, 75, PuntoOrigenReporteDiario.X + 805, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 880, puntoY, PuntoOrigenReporteDiario.X + 880, puntoY + 40) 'vertical
        e.Graphics.DrawString(filaReporteDiario("NOMBREBASE"), Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteDiario.X + 885, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 15, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 15) 'horizontal
        puntoY += 15
        e.Graphics.DrawString("DISCIPLINA", Formato_Etiqueta_7, Brocha, PuntoOrigenReporteDiario.X + 70, puntoY + 7)
        e.Graphics.DrawString(filaReporteDiario("DISCIPLINA"), Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteDiario.X + 170, puntoY + 7)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 445, puntoY, PuntoOrigenReporteDiario.X + 445, puntoY + 40) 'vertical
        e.Graphics.DrawString("CUADRILLA", Formato_Etiqueta_7, Brocha, PuntoOrigenReporteDiario.X + 70, puntoY + 27)
        If e.Graphics.MeasureString(filaReporteDiario("CUADRILLA"), Formato_Etiqueta_7R).Width > 275 Then
            y = puntoY + 25
            cadenas.Clear()
            cadenas.Add(filaReporteDiario("CUADRILLA"))
            cadenasTotalParrafo.Clear()
            cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_5R, 275, e, False)
            For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 170, y + (i * 7))
            Next
        Else
            e.Graphics.DrawString(filaReporteDiario("CUADRILLA"), Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteDiario.X + 170, puntoY + 27)
        End If
        e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_7, Brocha, 100, PuntoOrigenReporteDiario.X + 445, puntoY + 7)
        e.Graphics.DrawStringCentered(filaReporteDiario("TIEMPO"), Formato_Etiqueta_7R, Brocha, 100, PuntoOrigenReporteDiario.X + 445, puntoY + 27)
        e.Graphics.DrawStringCentered("PARO", Formato_Etiqueta_7, Brocha, 120, PuntoOrigenReporteDiario.X + 545, puntoY + 7)
        e.Graphics.DrawString(filaReporteDiario("PARODESCRIPCION"), Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteDiario.X + 675, puntoY + 7)
        If Not IsDBNull(filaReporteDiario("HORAINICIOPARO")) Then
            e.Graphics.DrawStringCentered(DirectCast(filaReporteDiario("HORAINICIOPARO"), DateTime).ToString("HH:mm"), Formato_Etiqueta_7R, Brocha, 120, PuntoOrigenReporteDiario.X + 545, puntoY + 27)
        End If
        If Not IsDBNull(filaReporteDiario("HORAFINPARO")) Then
            e.Graphics.DrawStringCentered(DirectCast(filaReporteDiario("HORAFINPARO"), DateTime).ToString("HH:mm"), Formato_Etiqueta_7R, Brocha, 135, PuntoOrigenReporteDiario.X + 670, puntoY + 27)
        End If
        e.Graphics.DrawStringCentered("DOMINICAL O", Formato_Etiqueta_7, Brocha, 75, PuntoOrigenReporteDiario.X + 805, puntoY + 2)
        e.Graphics.DrawStringCentered("FESTIVO (S/N)", Formato_Etiqueta_7, Brocha, 75, PuntoOrigenReporteDiario.X + 805, puntoY + 12)
        e.Graphics.DrawStringCentered(filaReporteDiario("DOMINICALOFESTIVO"), Formato_Etiqueta_7R, Brocha, 40, PuntoOrigenReporteDiario.X + 880, puntoY + 7)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 925, puntoY, PuntoOrigenReporteDiario.X + 925, puntoY + 40) 'vertical
        e.Graphics.DrawStringCentered("DÍA", Formato_Etiqueta_7, Brocha, 30, PuntoOrigenReporteDiario.X + 805, puntoY + 27)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 835, puntoY + 25, PuntoOrigenReporteDiario.X + 835, puntoY + 40) 'vertical
        e.Graphics.DrawStringCentered(filaReporteDiario("DIASEMANA"), Formato_Etiqueta_7R, Brocha, 85, PuntoOrigenReporteDiario.X + 835, puntoY + 27)
        e.Graphics.DrawStringCentered("FECHA DD/MM/AAAA", Formato_Etiqueta_7, Brocha, 105, PuntoOrigenReporteDiario.X + 925, puntoY + 7)
        e.Graphics.DrawStringCentered(fechaReporte.Day.ToString("00"), Formato_Etiqueta_7R, Brocha, 35, PuntoOrigenReporteDiario.X + 925, puntoY + 27)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 960, puntoY + 25, PuntoOrigenReporteDiario.X + 960, puntoY + 40) 'vertical
        e.Graphics.DrawStringCentered(fechaReporte.Month.ToString("00"), Formato_Etiqueta_7R, Brocha, 35, PuntoOrigenReporteDiario.X + 960, puntoY + 27)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 995, puntoY + 25, PuntoOrigenReporteDiario.X + 995, puntoY + 40) 'vertical
        e.Graphics.DrawStringCentered(fechaReporte.Year, Formato_Etiqueta_7R, Brocha, 35, PuntoOrigenReporteDiario.X + 995, puntoY + 27)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 25, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 25) 'horizontal
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 40, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 40) 'horizontal completa
        'Fin encabezado

        puntoY = PuntoOrigenReporteDiario.Y + 90
        Select Case SeccionReporteDiario
            Case 1 'Personal
                altoBloque = 550
                anchoBloque = anchoDocumentoReporteDiario
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("CÓDIGO", Formato_Etiqueta_5, Brocha, 50, PuntoOrigenReporteDiario.X, puntoY + 3)
                e.Graphics.DrawStringCentered("EMPLEADO", Formato_Etiqueta_5, Brocha, 50, PuntoOrigenReporteDiario.X, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 50, puntoY, PuntoOrigenReporteDiario.X + 50, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("NOMBRES Y APELLIDOS", Formato_Etiqueta_6, Brocha, 240, PuntoOrigenReporteDiario.X + 50, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 290, puntoY, PuntoOrigenReporteDiario.X + 290, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("CAT.", Formato_Etiqueta_6, Brocha, 30, PuntoOrigenReporteDiario.X + 290, puntoY + 8)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 320, puntoY, PuntoOrigenReporteDiario.X + 320, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_6, Brocha, 180, PuntoOrigenReporteDiario.X + 320, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 500, puntoY, PuntoOrigenReporteDiario.X + 500, puntoY + 495) 'vertical
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 500, puntoY + 10, PuntoOrigenReporteDiario.X + 750, puntoY + 10) 'horizontal
                e.Graphics.DrawStringCentered("HORARIO DE TRABAJO", Formato_Etiqueta_5, Brocha, 110, PuntoOrigenReporteDiario.X + 500, puntoY + 1)
                e.Graphics.DrawStringCentered("HORA INICIO", Formato_Etiqueta_4, Brocha, 45, PuntoOrigenReporteDiario.X + 500, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 545, puntoY + 10, PuntoOrigenReporteDiario.X + 545, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HORA FINAL", Formato_Etiqueta_4, Brocha, 45, PuntoOrigenReporteDiario.X + 545, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 590, puntoY + 10, PuntoOrigenReporteDiario.X + 590, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("UHA", Formato_Etiqueta_4, Brocha, 20, PuntoOrigenReporteDiario.X + 590, puntoY + 12)
                e.Graphics.DrawStringCentered("(S/N)", Formato_Etiqueta_4, Brocha, 20, PuntoOrigenReporteDiario.X + 590, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 610, puntoY, PuntoOrigenReporteDiario.X + 610, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("LIQUIDACIÓN HORAS TRABAJADAS", Formato_Etiqueta_5, Brocha, 135, PuntoOrigenReporteDiario.X + 610, puntoY + 1)
                e.Graphics.DrawStringCentered("HN", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 610, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 645, puntoY + 10, PuntoOrigenReporteDiario.X + 645, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HED", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 645, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 680, puntoY + 10, PuntoOrigenReporteDiario.X + 680, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HEN", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 680, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 715, puntoY + 10, PuntoOrigenReporteDiario.X + 715, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HRN", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 715, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 750, puntoY, PuntoOrigenReporteDiario.X + 750, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("RAC", Formato_Etiqueta_6, Brocha, 30, PuntoOrigenReporteDiario.X + 750, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 780, puntoY, PuntoOrigenReporteDiario.X + 780, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("PRN", Formato_Etiqueta_6, Brocha, 30, PuntoOrigenReporteDiario.X + 780, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 810, puntoY, PuntoOrigenReporteDiario.X + 810, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("CÓD. ACTIVIDAD / TAREA", Formato_Etiqueta_6, Brocha, 220, PuntoOrigenReporteDiario.X + 810, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 25, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 25) 'horizontal completa
                puntoY += 25
                For i As UInteger = 1 To 20
                    y = puntoY + (i * 23.5)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, y, PuntoOrigenReporteDiario.X + anchoBloque, y) 'horizontal completa
                Next
                If contadorPersonalReporteDiario < _dtPersonal.Rows.Count Then
                    For j As UInteger = 0 To 19
                        y = puntoY + (j * 23.5)
                        e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CODIGOCONTRATO"), Formato_Etiqueta_6R, Brocha, 50, PuntoOrigenReporteDiario.X, y + espaciadorCeldasGrandeReporteDiario) 'CÓDIGO EMPLEADO
                        e.Graphics.DrawString(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("NOMBREPERSONA"), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteDiario.X + 52, y + espaciadorCeldasGrandeReporteDiario) 'NOMBRES Y APELLIDOS
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CATEGORIA")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CATEGORIA"), Formato_Etiqueta_6R, Brocha, 30, PuntoOrigenReporteDiario.X + 290, y + espaciadorCeldasGrandeReporteDiario) 'CATEGORÍA
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CARGO")) Then
                            If e.Graphics.MeasureString(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CARGO"), Formato_Etiqueta_6R).Width > 173 Then
                                cadenas.Clear()
                                cadenas.Add(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CARGO"))
                                cadenasTotalParrafo.Clear()
                                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_6R, 175, e, False)
                                For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                                    e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteDiario.X + 322, y + (i * 8)) 'CARGO
                                Next
                            Else
                                e.Graphics.DrawString(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("CARGO"), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteDiario.X + 322, y + espaciadorCeldasGrandeReporteDiario) 'CARGO
                            End If
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORAINICIAL")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORAINICIAL"), Formato_Etiqueta_5R, Brocha, 45, PuntoOrigenReporteDiario.X + 500, y + espaciadorCeldasGrandeReporteDiario) 'HORA INICIO
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORAFINAL")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORAFINAL"), Formato_Etiqueta_5R, Brocha, 45, PuntoOrigenReporteDiario.X + 545, y + espaciadorCeldasGrandeReporteDiario) 'HORA FINAL
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("USOHORAALMUERZO")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("USOHORAALMUERZO"), Formato_Etiqueta_6R, Brocha, 20, PuntoOrigenReporteDiario.X + 590, y + espaciadorCeldasGrandeReporteDiario) 'UHA
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASNORMALES")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASNORMALES"), Formato_Etiqueta_6R, Brocha, 35, PuntoOrigenReporteDiario.X + 610, y + espaciadorCeldasGrandeReporteDiario) 'HN
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASEXTRASDIURNAS")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASEXTRASDIURNAS"), Formato_Etiqueta_6R, Brocha, 35, PuntoOrigenReporteDiario.X + 645, y + espaciadorCeldasGrandeReporteDiario) 'HED
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASEXTRASNOCTURNAS")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASEXTRASNOCTURNAS"), Formato_Etiqueta_6R, Brocha, 35, PuntoOrigenReporteDiario.X + 680, y + espaciadorCeldasGrandeReporteDiario) 'HEN
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASRECARGONOCTURNO")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("HORASRECARGONOCTURNO"), Formato_Etiqueta_6R, Brocha, 30, PuntoOrigenReporteDiario.X + 715, y + espaciadorCeldasGrandeReporteDiario) 'HRN
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("RACIONES")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("RACIONES"), Formato_Etiqueta_6R, Brocha, 30, PuntoOrigenReporteDiario.X + 750, y + espaciadorCeldasGrandeReporteDiario) 'RACIONES
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("ALOJAMIENTO")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("ALOJAMIENTO"), Formato_Etiqueta_6R, Brocha, 30, PuntoOrigenReporteDiario.X + 780, y + espaciadorCeldasGrandeReporteDiario) 'PERNOCTÓ
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("SERVICIO")) Then
                            e.Graphics.DrawString(_dtPersonal.Rows(contadorPersonalReporteDiario).Item("SERVICIO"), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteDiario.X + 812, y + espaciadorCeldasGrandeReporteDiario) 'CÓD. ACTIVIDAD / TAREA
                        End If
                        contadorPersonalReporteDiario += 1
                        If contadorPersonalReporteDiario >= _dtPersonal.Rows.Count Then
                            Exit For
                        End If
                    Next
                End If
                puntoY += 470
                e.Graphics.DrawString("CONVENCIONES PARA NOVEDADES DEL PERSONAL:", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X, puntoY + 2)
                e.Graphics.DrawString("O: Cuando no se labora", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 160, puntoY + 2)
                e.Graphics.DrawString("D: Descanso Compensatorio", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 160, puntoY + 10)
                e.Graphics.DrawString("A: Ausente sin permiso", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 240, puntoY + 2)
                e.Graphics.DrawString("I: Incapacidad por accidente de trabajo", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 240, puntoY + 10)
                e.Graphics.DrawString("IC: Incapacidad por enfermedad común", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 2)
                e.Graphics.DrawString("NDS: No Disponible (personal planta básica)", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 10)
                e.Graphics.DrawString("S: Sancionado", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 480, puntoY + 2)
                e.Graphics.DrawString("ACSP: Ausente con permiso sin pago", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 480, puntoY + 10)
                e.Graphics.DrawString("ACCP: Ausente con permiso con pago", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 590, puntoY + 2)
                e.Graphics.DrawString("P: Presente (personal planta básica)", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 590, puntoY + 10)
                e.Graphics.DrawString("DIS:  Disponible (personal planta básica)", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 700, puntoY + 2)
                e.Graphics.DrawString("V: Viajando", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 700, puntoY + 10)
                e.Graphics.DrawString("VAC: Vacaciones", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 820, puntoY + 2)
                e.Graphics.DrawString("SUS: Suspendido", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 820, puntoY + 10)

                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 20, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 20) 'horizontal completa
                cadenas.Clear()
                cadenas.Add("Observaciones: " & FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONPERSONA")))
                cadenas.Add(FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONCOMPLEMENTO")))
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 21) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 21) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                End If
                puntoY = PuntoOrigenReporteDiario.Y + 645
            Case 2 'Equipos, materiales y avance de obra
                'Equipos
                altoBloque = 275
                anchoBloque = anchoDocumentoReporteDiario
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("EQUIPOS", Formato_Etiqueta_6, Brocha, anchoBloque, PuntoOrigenReporteDiario.X, puntoY)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 10, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 10) 'horizontal completa
                e.Graphics.DrawStringCentered("CÓDIGO EQUIPO", Formato_Etiqueta_5, Brocha, 70, PuntoOrigenReporteDiario.X, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 10, PuntoOrigenReporteDiario.X + 70, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("DESCRIPCIÓN", Formato_Etiqueta_5, Brocha, 270, PuntoOrigenReporteDiario.X + 70, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 340, puntoY + 10, PuntoOrigenReporteDiario.X + 340, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("TOTAL", Formato_Etiqueta_5, Brocha, 40, PuntoOrigenReporteDiario.X + 340, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 380, puntoY + 10, PuntoOrigenReporteDiario.X + 380, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("HI / KI", Formato_Etiqueta_5, Brocha, 40, PuntoOrigenReporteDiario.X + 380, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 420, puntoY + 10, PuntoOrigenReporteDiario.X + 420, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("HF / KF", Formato_Etiqueta_5, Brocha, 50, PuntoOrigenReporteDiario.X + 420, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 470, puntoY + 10, PuntoOrigenReporteDiario.X + 470, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("DISPONIBLE", Formato_Etiqueta_5, Brocha, 60, PuntoOrigenReporteDiario.X + 470, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 530, puntoY + 10, PuntoOrigenReporteDiario.X + 530, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("VARADO", Formato_Etiqueta_5, Brocha, 60, PuntoOrigenReporteDiario.X + 530, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 590, puntoY + 10, PuntoOrigenReporteDiario.X + 590, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("ACTIVIDAD / TAREA", Formato_Etiqueta_5, Brocha, 150, PuntoOrigenReporteDiario.X + 590, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 740, puntoY + 10, PuntoOrigenReporteDiario.X + 740, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_5, Brocha, 290, PuntoOrigenReporteDiario.X + 740, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 30, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 30) 'horizontal completa
                puntoY += 30
                For i As UInteger = 1 To 13
                    y = puntoY + (i * 16.5)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, y, PuntoOrigenReporteDiario.X + anchoBloque, y) 'horizontal completa
                Next
                If contadorEquiposReporteDiario < _dtEquipo.Rows.Count Then
                    For j As UInteger = 0 To 12
                        y = puntoY + (j * 16.5)
                        e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("CODIGOEQUIPO"), Formato_Etiqueta_5R, Brocha, 70, PuntoOrigenReporteDiario.X, y + espaciadorCeldasMedioReporteDiario) 'CÓDIGO EQUIPO
                        If e.Graphics.MeasureString(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("DESCRIPCION"), Formato_Etiqueta_5R).Width > 270 Then
                            cadenas.Clear()
                            cadenas.Add(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("DESCRIPCION"))
                            cadenasTotalParrafo.Clear()
                            cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_5R, 280, e, False)
                            For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                                e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 70, y + (i * 8)) 'CARGO
                            Next
                        Else
                            e.Graphics.DrawString(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("DESCRIPCION"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 70, y + espaciadorCeldasMedioReporteDiario) 'DESCRIPCIÓN
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("TOTAL")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("TOTAL"), Formato_Etiqueta_5R, Brocha, 40, PuntoOrigenReporteDiario.X + 340, y + espaciadorCeldasMedioReporteDiario) 'TOTAL
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("INICIAL")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("INICIAL"), Formato_Etiqueta_5R, Brocha, 40, PuntoOrigenReporteDiario.X + 380, y + espaciadorCeldasMedioReporteDiario) 'HI / KI
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("FINAL")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("FINAL"), Formato_Etiqueta_5R, Brocha, 50, PuntoOrigenReporteDiario.X + 420, y + espaciadorCeldasMedioReporteDiario) 'HF / KF
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("DISPONIBLE")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("DISPONIBLE"), Formato_Etiqueta_5R, Brocha, 60, PuntoOrigenReporteDiario.X + 470, y + espaciadorCeldasMedioReporteDiario) 'DISPONIBLE
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("VARADO")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("VARADO"), Formato_Etiqueta_5R, Brocha, 60, PuntoOrigenReporteDiario.X + 530, y + espaciadorCeldasMedioReporteDiario) 'VARADO
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("SERVICIO")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("SERVICIO"), Formato_Etiqueta_5R, Brocha, 150, PuntoOrigenReporteDiario.X + 590, y + espaciadorCeldasMedioReporteDiario) 'ACTIVIDAD / TAREA
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("OBSERVACION")) Then
                            e.Graphics.DrawString(_dtEquipo.Rows(contadorEquiposReporteDiario).Item("OBSERVACION"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 740, y + espaciadorCeldasMedioReporteDiario) 'OBSERVACIÓN
                        End If
                        contadorEquiposReporteDiario += 1
                        If contadorEquiposReporteDiario >= _dtEquipo.Rows.Count Then
                            Exit For
                        End If
                    Next
                End If
                cadenas.Clear()
                cadenas.Add("Observaciones: " & FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONEQUIPO")))
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 216) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 216) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                End If
                'Fin equipos

                puntoY += 250
                'Materiales
                altoBloque = 270
                anchoBloque = 580
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("MATERIALES", Formato_Etiqueta_6, Brocha, anchoBloque, PuntoOrigenReporteDiario.X, puntoY + 2)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 15, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 15) 'horizontal completa
                e.Graphics.DrawStringCentered("CÓD. ARTÍCULO", Formato_Etiqueta_4, Brocha, 50, PuntoOrigenReporteDiario.X, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 50, puntoY + 15, PuntoOrigenReporteDiario.X + 50, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("MATERIALES / CONSUMIBLES", Formato_Etiqueta_5, Brocha, 400, PuntoOrigenReporteDiario.X + 50, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 450, puntoY + 15, PuntoOrigenReporteDiario.X + 450, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("UND", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 450, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 480, puntoY + 15, PuntoOrigenReporteDiario.X + 480, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 480, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 510, puntoY + 15, PuntoOrigenReporteDiario.X + 510, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("ACTIVIDAD / TAREA", Formato_Etiqueta_5, Brocha, 70, PuntoOrigenReporteDiario.X + 511, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 30, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 30) 'horizontal completa
                puntoY += 30
                For i As UInteger = 1 To 13
                    y = puntoY + (i * 16.15)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, y, PuntoOrigenReporteDiario.X + anchoBloque, y) 'horizontal completa
                Next
                If contadorMaterialesReporteDiario < _dtMateriales.Rows.Count Then
                    For j As UInteger = 0 To 12
                        y = puntoY + (j * 16.15)
                        e.Graphics.DrawStringCentered(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("IDARTICULO"), Formato_Etiqueta_5R, Brocha, 50, PuntoOrigenReporteDiario.X, y + espaciadorCeldasMedioReporteDiario) 'CÓD. ARTÍCULO
                        If e.Graphics.MeasureString(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5R).Width > 400 Then
                            cadenas.Clear()
                            cadenas.Add(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("NOMBREDESCRIPTIVO"))
                            cadenasTotalParrafo.Clear()
                            cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_5R, 400, e, False)
                            If cadenasTotalParrafo.Count > 2 Then
                                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, 400, e, False)
                                For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                                    e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X + 50, (y + 1) + (i * 7)) 'MATERIALES / CONSUMIBLES
                                Next
                            Else
                                For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                                    e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 50, y + (i * 8)) 'MATERIALES / CONSUMIBLES
                                Next
                            End If
                        Else
                            e.Graphics.DrawString(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("NOMBREDESCRIPTIVO"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 50, y + espaciadorCeldasMedioReporteDiario) 'MATERIALES / CONSUMIBLES
                        End If
                        e.Graphics.DrawStringCentered(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("UNIDAD"), Formato_Etiqueta_5R, Brocha, 30, PuntoOrigenReporteDiario.X + 450, y + espaciadorCeldasMedioReporteDiario) 'UND
                        e.Graphics.DrawStringCentered(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("CANTIDAD"), Formato_Etiqueta_5R, Brocha, 30, PuntoOrigenReporteDiario.X + 480, y + espaciadorCeldasMedioReporteDiario) 'CANT
                        If Not IsDBNull(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("SERVICIO")) Then
                            e.Graphics.DrawString(_dtMateriales.Rows(contadorMaterialesReporteDiario).Item("SERVICIO"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 513, y + espaciadorCeldasMedioReporteDiario) 'ACTIVIDAD / TAREA
                        End If
                        contadorMaterialesReporteDiario += 1
                        If contadorMaterialesReporteDiario >= _dtMateriales.Rows.Count Then
                            Exit For
                        End If
                    Next
                End If
                cadenas.Clear()
                cadenas.Add("Observaciones: " & FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONMATERIALES")))
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                End If
                'Fin materiales

                puntoY = puntoY - 30
                'Avance de obra
                altoBloque = 270
                anchoBloque = 430
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X + 600, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("AVANCE DE OBRA", Formato_Etiqueta_6, Brocha, anchoBloque, PuntoOrigenReporteDiario.X + 600, puntoY + 2)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 600, puntoY + 15, PuntoOrigenReporteDiario.X + 600 + anchoBloque, puntoY + 15) 'horizontal completa
                e.Graphics.DrawStringCentered("ACTIVIDAD / TAREA", Formato_Etiqueta_5, Brocha, 70, PuntoOrigenReporteDiario.X + 601, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 670, puntoY + 15, PuntoOrigenReporteDiario.X + 670, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("DETALLE", Formato_Etiqueta_5, Brocha, 300, PuntoOrigenReporteDiario.X + 680, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 970, puntoY + 15, PuntoOrigenReporteDiario.X + 970, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("UND", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 970, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 1000, puntoY + 15, PuntoOrigenReporteDiario.X + 1000, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 1000, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 600, puntoY + 30, PuntoOrigenReporteDiario.X + 600 + anchoBloque, puntoY + 30) 'horizontal completa
                puntoY += 30
                For i As UInteger = 1 To 13
                    y = puntoY + (i * 16.15)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 600, y, PuntoOrigenReporteDiario.X + 600 + anchoBloque, y) 'horizontal completa
                Next
                If contadorAvanceReporteDiario < _dtServicios.Rows.Count Then
                    For j As UInteger = 0 To 12
                        y = puntoY + (j * 16.15)
                        e.Graphics.DrawStringCentered(_dtServicios.Rows(contadorAvanceReporteDiario).Item("SERVICIO"), Formato_Etiqueta_5R, Brocha, 70, PuntoOrigenReporteDiario.X + 600, y + espaciadorCeldasMedioReporteDiario) 'ACTIVIDAD / TAREA
                        Dim detalle As String = _dtServicios.Rows(contadorAvanceReporteDiario).Item("DESCRIPCION").ToString.Trim
                        Select Case detalle.Length
                            Case Is < 70
                                e.Graphics.DrawString(detalle, Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 670, y + espaciadorCeldasMedioReporteDiario)
                                Exit Select
                            Case Is <= 84
                                e.Graphics.DrawString(detalle, Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X + 670, y + espaciadorCeldasMedioReporteDiario + 2)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(detalle, 1, 84), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X + 670, y + espaciadorCeldasMedioReporteDiario - 3)
                                e.Graphics.DrawString(Mid(detalle, 85, 84), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X + 670, y + espaciadorCeldasMedioReporteDiario + 4)
                        End Select
                        e.Graphics.DrawStringCentered(_dtServicios.Rows(contadorAvanceReporteDiario).Item("UNIDAD"), Formato_Etiqueta_5R, Brocha, 30, PuntoOrigenReporteDiario.X + 970, y + espaciadorCeldasMedioReporteDiario) 'UNIDAD
                        e.Graphics.DrawString(_dtServicios.Rows(contadorAvanceReporteDiario).Item("AVANCE"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteDiario.X + 1000, y + espaciadorCeldasMedioReporteDiario) 'CANT
                        contadorAvanceReporteDiario += 1
                        If contadorAvanceReporteDiario >= _dtServicios.Rows.Count Then
                            Exit For
                        End If
                    Next
                End If
                cadenas.Clear()
                cadenas.Add("Observaciones: " & FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONAVANCE")))
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X + 600, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X + 600, y)
                    Next
                End If
                'Fin avance de obra

                puntoY = PuntoOrigenReporteDiario.Y + 645
            Case Else

        End Select

        'Pie de página
        altoBloque = 65
        e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoDocumentoReporteDiario, altoBloque)
        e.Graphics.DrawStringCentered("JEFE DE CUADRILLA", Formato_Etiqueta_6, Brocha, 350, PuntoOrigenReporteDiario.X, puntoY) 'w=270
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X, puntoY + 15)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X, puntoY + 40)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 50, puntoY + 10, PuntoOrigenReporteDiario.X + 50, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered(filaReporteDiario("JEFECUADRILLA"), Formato_Etiqueta_6R, Brocha, 300, PuntoOrigenReporteDiario.X + 50, puntoY + 15)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 350, puntoY, PuntoOrigenReporteDiario.X + 350, puntoY + altoBloque) 'vertical

        e.Graphics.DrawStringCentered("ADMINISTRACIÓN", Formato_Etiqueta_6, Brocha, 340, PuntoOrigenReporteDiario.X + 350, puntoY) 'w=260
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 15)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 40)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 400, puntoY + 10, PuntoOrigenReporteDiario.X + 400, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered(filaReporteDiario("ADMINISTRADOR"), Formato_Etiqueta_6R, Brocha, 290, PuntoOrigenReporteDiario.X + 400, puntoY + 15)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 690, puntoY, PuntoOrigenReporteDiario.X + 690, puntoY + altoBloque) 'vertical

        e.Graphics.DrawStringCentered("SUPERINTENDENTE", Formato_Etiqueta_6, Brocha, 340, PuntoOrigenReporteDiario.X + 690, puntoY) 'w=240
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 690, puntoY + 15)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 690, puntoY + 40)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 740, puntoY + 10, PuntoOrigenReporteDiario.X + 740, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered(filaReporteDiario("SUPERINTENDENTE"), Formato_Etiqueta_6R, Brocha, 290, PuntoOrigenReporteDiario.X + 740, puntoY + 15)
        'e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 770, puntoY, PuntoOrigenReporteDiario.X + 770, puntoY + altoBloque) 'vertical

        'e.Graphics.DrawStringCentered("DIRECCIÓN DE OBRA", Formato_Etiqueta_6, Brocha, 260, PuntoOrigenReporteDiario.X + 770, puntoY)
        'e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 770, puntoY + 15)
        'e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 770, puntoY + 40)
        'e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 840, puntoY + 10, PuntoOrigenReporteDiario.X + 840, puntoY + altoBloque) 'vertical
        'e.Graphics.DrawStringCentered(filaReporteDiario("DIRECTOROBRA"), Formato_Etiqueta_6R, Brocha, 190, PuntoOrigenReporteDiario.X + 840, puntoY + 15)

        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 10, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 10) 'horizontal completa
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 30, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 30) 'horizontal completa

        'Fin pie de página
        contadorPaginasImpresas += 1
        e.Graphics.DrawStringCentered("Página " & contadorPaginasImpresas & If(totalPaginasImpresion > 0, " de " & totalPaginasImpresion, ""), Formato_Etiqueta_5, Brocha, anchoDocumentoReporteDiario, PuntoOrigenReporteDiario.X, 790)

        Select Case SeccionReporteDiario
            Case 1 'Personal
                If contadorPersonalReporteDiario >= _dtPersonal.Rows.Count Then
                    SeccionReporteDiario = 2 'Equipos, materiales y avance de obra
                End If
                e.HasMorePages = True
            Case 2 'Equipos, materiales y avance de obra
                If contadorEquiposReporteDiario >= _dtEquipo.Rows.Count _
                    AndAlso contadorMaterialesReporteDiario >= _dtMateriales.Rows.Count _
                    AndAlso contadorAvanceReporteDiario >= _dtServicios.Rows.Count Then
                    'SeccionReporteDiario = 1 'Personal
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                End If
            Case Else
                e.HasMorePages = False
        End Select
    End Sub

    Private Sub FinImp_ReporteDiarioDeTiempo(sender As Object, e As PrintEventArgs) Handles DocImp_ReporteDiarioDeTiempo.EndPrint
        If e.PrintAction = PrintAction.PrintToPreview Then
            SeccionReporteDiario = 1 'Personal
            contadorPersonalReporteDiario = 0
            contadorEquiposReporteDiario = 0
            contadorMaterialesReporteDiario = 0
            contadorAvanceReporteDiario = 0
            totalPaginasImpresion = contadorPaginasImpresas
            contadorPaginasImpresas = 0
        End If
    End Sub
#End Region

#Region " 11 - ICA-GRAL-F-015 Reporte diario de tiempo trabajado (BÁSICO)"
    Const anchoDocumentoReporteBasico As UInteger = 745
    Const altoDocumentoReporteBasico As UInteger = 990
    Private PuntoOrigenReporteBasico As New Point(35, 30)
    Private SeccionReporteBasico As UInteger = 1
    Private contadorPersonalReporteBasico As UInteger = 0
    Private contadorEquiposReporteBasico As UInteger = 0

    Private WithEvents DocImp_ReporteDiarioDeTiempoBasico As PrintDocument
    Private Sub EvImp_ReporteDiarioDeTiempoBasico(sender As Object, e As PrintPageEventArgs) Handles DocImp_ReporteDiarioDeTiempoBasico.PrintPage
        Dim puntoY As UInteger = PuntoOrigenReporteBasico.Y
        Dim y As UInteger = 0
        Dim altoBloque As UInteger = 0
        Dim anchoBloque As UInteger = 0
        Dim fechaReporte As Date = filaReporteDiario("FECHAREPORTEDIARIO")
        Dim cadenas As New ArrayList
        Dim cadenasTotalParrafo As New ArrayList

        Select Case SeccionReporteBasico
            Case 1 'Personal
                'e.Graphics.DrawGrid(Color.LightGray, True, 0.5, Formato_Etiqueta_4, PuntoOrigenReporteBasico.X, PuntoOrigenReporteBasico.Y, anchoDocumentoReporteBasico, 990, 10)
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteBasico.X, PuntoOrigenReporteBasico.Y, anchoDocumentoReporteBasico, altoDocumentoReporteBasico) 'Borde documento
                'Encabezado
                altoBloque = 100
                e.Graphics.DrawImage(logoIsmocol, PuntoOrigenReporteBasico.X + 25, puntoY + 10, 100, 80)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 140, puntoY, PuntoOrigenReporteBasico.X + 140, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("REPORTE DIARIO DE TIEMPO TRABAJADO", Formato_Etiqueta_12, Brocha, 480, PuntoOrigenReporteBasico.X + 140, puntoY + 30)
                e.Graphics.DrawStringCentered(filaReporteDiario("REPORTEDIARIO"), Formato_Etiqueta_12, Brocha, 480, PuntoOrigenReporteBasico.X + 140, puntoY + 60)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 620, puntoY, PuntoOrigenReporteBasico.X + 620, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("ICA-GRAL-F-015", Formato_Etiqueta_9, Brocha, 125, PuntoOrigenReporteBasico.X + 620, puntoY + 18)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 620, puntoY + 50, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 50) 'horizontal
                e.Graphics.DrawStringCentered("Revisión No. " & "4", Formato_Etiqueta_9, Brocha, 125, PuntoOrigenReporteBasico.X + 620, puntoY + 68)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + altoBloque, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + altoBloque) 'Horizontal completa
                puntoY += altoBloque

                altoBloque = 85
                e.Graphics.DrawString("Contrato No.:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 3)
                e.Graphics.DrawString(filaReporteDiario("CONTRATOISMOCOL"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 140, puntoY + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 140, puntoY + 20, PuntoOrigenReporteBasico.X + 450, puntoY + 20) 'horizontal
                e.Graphics.DrawString("Centro de costos:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 23)
                e.Graphics.DrawString(filaReporteDiario("CENTROCOSTO"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 140, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 140, puntoY + 40, PuntoOrigenReporteBasico.X + 450, puntoY + 40) 'horizontal
                e.Graphics.DrawString("Disciplina:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 43)
                e.Graphics.DrawString(filaReporteDiario("DISCIPLINA"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 140, puntoY + 45)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 140, puntoY + 60, PuntoOrigenReporteBasico.X + 450, puntoY + 60) 'horizontal
                e.Graphics.DrawString("Cuadrilla:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 63)
                e.Graphics.DrawString(filaReporteDiario("CUADRILLA"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 140, puntoY + 65)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 140, puntoY + 80, PuntoOrigenReporteBasico.X + 450, puntoY + 80) 'horizontal
                e.Graphics.DrawStringRight("Fecha:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 3)
                e.Graphics.DrawString(filaReporteDiario("FECHAREPORTEDIARIO"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 540, puntoY + 20, PuntoOrigenReporteBasico.X + 730, puntoY + 20) 'horizontal
                e.Graphics.DrawStringRight("Día:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 23)
                e.Graphics.DrawString(filaReporteDiario("DIASEMANA"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 540, puntoY + 40, PuntoOrigenReporteBasico.X + 650, puntoY + 40) 'horizontal
                e.Graphics.DrawStringRight("Tiempo:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 43)
                e.Graphics.DrawString(filaReporteDiario("TIEMPO"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 45)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 540, puntoY + 60, PuntoOrigenReporteBasico.X + 730, puntoY + 60) 'horizontal
                e.Graphics.DrawStringRight("Paros:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 63)
                e.Graphics.DrawString(filaReporteDiario("PARODESCRIPCION"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 540, puntoY + 65)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 540, puntoY + 80, PuntoOrigenReporteBasico.X + 730, puntoY + 80) 'horizontal
                e.Graphics.DrawStringRight("Festivo:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X + 710, puntoY + 23)
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteBasico.X + 710, puntoY + 23, 14, 14)
                If Not IsDBNull(filaReporteDiario("DOMINICALOFESTIVO")) AndAlso filaReporteDiario("DOMINICALOFESTIVO") = "S" Then
                    e.Graphics.DrawStringCentered("X", Formato_Etiqueta_8, Brocha, 15, PuntoOrigenReporteBasico.X + 710, puntoY + 25)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + altoBloque, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + altoBloque) 'Horizontal completa
                puntoY += altoBloque

                altoBloque = 430
                e.Graphics.DrawStringCentered("Cód", Formato_Etiqueta_8, Brocha, 30, PuntoOrigenReporteBasico.X, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 30, puntoY, PuntoOrigenReporteBasico.X + 30, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Nombre", Formato_Etiqueta_8, Brocha, 160, PuntoOrigenReporteBasico.X + 30, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 190, puntoY, PuntoOrigenReporteBasico.X + 190, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Cat.", Formato_Etiqueta_8, Brocha, 25, PuntoOrigenReporteBasico.X + 190, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 215, puntoY, PuntoOrigenReporteBasico.X + 215, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Cargo", Formato_Etiqueta_8, Brocha, 335, PuntoOrigenReporteBasico.X + 215, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 550, puntoY, PuntoOrigenReporteBasico.X + 550, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("No. de horas", Formato_Etiqueta_8, Brocha, 110, PuntoOrigenReporteBasico.X + 550, puntoY + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 550, puntoY + 20, PuntoOrigenReporteBasico.X + 660, puntoY + 20) 'horizontal
                e.Graphics.DrawStringCentered("Tot.", Formato_Etiqueta_8, Brocha, 20, PuntoOrigenReporteBasico.X + 550, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 570, puntoY + 20, PuntoOrigenReporteBasico.X + 570, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("N", Formato_Etiqueta_8, Brocha, 20, PuntoOrigenReporteBasico.X + 570, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 590, puntoY + 20, PuntoOrigenReporteBasico.X + 590, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("E.D.", Formato_Etiqueta_8, Brocha, 25, PuntoOrigenReporteBasico.X + 590, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 615, puntoY + 20, PuntoOrigenReporteBasico.X + 615, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("E.N.", Formato_Etiqueta_8, Brocha, 25, PuntoOrigenReporteBasico.X + 615, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 640, puntoY + 20, PuntoOrigenReporteBasico.X + 640, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("RN", Formato_Etiqueta_8, Brocha, 20, PuntoOrigenReporteBasico.X + 640, puntoY + 25)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 660, puntoY, PuntoOrigenReporteBasico.X + 660, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Cód. act. / tarea", Formato_Etiqueta_8, Brocha, 90, PuntoOrigenReporteBasico.X + 660, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 40, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 40) 'Horizontal completa
                puntoY += 40

                For i As UInteger = 1 To 20
                    y = puntoY + (i * 19.5)
                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigenReporteBasico.X, y, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, y) 'Horizontal completa
                Next
                If contadorPersonalReporteBasico < _dtPersonal.Rows.Count Then
                    For j As UInteger = 0 To 19
                        y = puntoY + (j * 19.5)
                        e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CODIGOCONTRATO"), Formato_Etiqueta_6R, Brocha, 30, PuntoOrigenReporteBasico.X, y + 5) 'CÓDIGO EMPLEADO
                        e.Graphics.DrawString(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("NOMBREPERSONA"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 30, y + 7) 'NOMBRES Y APELLIDOS
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CATEGORIA")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CATEGORIA"), Formato_Etiqueta_6R, Brocha, 25, PuntoOrigenReporteBasico.X + 190, y + 5) 'CATEGORÍA
                        End If
                        Dim cargo As String = _dtPersonal.Rows(contadorPersonalReporteBasico).Item("CARGO").ToString.Trim
                        Select Case cargo.Length
                            Case Is < 82
                                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 215, y + 5)
                                Exit Select
                            Case Is <= 96
                                e.Graphics.DrawString(cargo, Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 215, y + 5)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(cargo, 1, 96), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 215, y + 3)
                                e.Graphics.DrawString(Mid(cargo, 97, 96), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 215, y + 10)
                        End Select
                        'If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CARGO")) Then
                        '    If e.Graphics.MeasureString(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CARGO"), Formato_Etiqueta_6R).Width > 105 Then
                        '        cadenas.Clear()
                        '        cadenas.Add(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CARGO"))
                        '        cadenasTotalParrafo.Clear()
                        '        cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_6R, 105, e, False)
                        '        For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                        '            e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 255, y + (i * 8)) 'CARGO
                        '        Next
                        '    Else
                        '        e.Graphics.DrawString(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("CARGO"), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 255, y + 5) 'CARGO
                        '    End If
                        'End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("TOTAL")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("TOTAL"), Formato_Etiqueta_6R, Brocha, 20, PuntoOrigenReporteBasico.X + 550, y + 5) 'T
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASNORMALES")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASNORMALES"), Formato_Etiqueta_6R, Brocha, 20, PuntoOrigenReporteBasico.X + 570, y + 5) 'HN
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASEXTRASDIURNAS")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASEXTRASDIURNAS"), Formato_Etiqueta_6R, Brocha, 25, PuntoOrigenReporteBasico.X + 590, y + 5) 'HED
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASEXTRASNOCTURNAS")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASEXTRASNOCTURNAS"), Formato_Etiqueta_6R, Brocha, 25, PuntoOrigenReporteBasico.X + 615, y + 5) 'HEN
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASRECARGONOCTURNO")) Then
                            e.Graphics.DrawStringCentered(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("HORASRECARGONOCTURNO"), Formato_Etiqueta_6R, Brocha, 20, PuntoOrigenReporteBasico.X + 640, y + 5) 'HRN
                        End If
                        If Not IsDBNull(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("SERVICIO")) Then
                            e.Graphics.DrawString(_dtPersonal.Rows(contadorPersonalReporteBasico).Item("SERVICIO"), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 660, y + 5) 'CÓD. ACTIVIDAD / TAREA
                        End If
                        contadorPersonalReporteBasico += 1
                        If contadorPersonalReporteBasico >= _dtPersonal.Rows.Count Then
                            Exit For
                        End If
                    Next
                End If
                puntoY += altoBloque - 40

                altoBloque = 110
                'Primera columna
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY) 'Horizontal completa
                e.Graphics.DrawString("Convenciones:", Formato_Etiqueta_9R, Brocha, PuntoOrigenReporteBasico.X, puntoY)
                e.Graphics.DrawString("O: Cuando no se labora", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 16)
                e.Graphics.DrawString("D: Descanso Compensatorio", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 29)
                e.Graphics.DrawString("A: Ausente sin permiso", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 42)
                e.Graphics.DrawString("I: Incapacidad por accidente de trabajo", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 55)
                e.Graphics.DrawString("IC: Incapacidad por enfermedad común", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 68)
                e.Graphics.DrawString("NDS: No Disponible (personal planta básica)", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 81)
                e.Graphics.DrawString("VAC: Vacaciones", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 94)
                'Segunda columna
                e.Graphics.DrawString("S: Sancionado", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 16)
                e.Graphics.DrawString("ACSP: Ausente con permiso sin pago", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 29)
                e.Graphics.DrawString("ACCP: Ausente con permiso con pago", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 42)
                e.Graphics.DrawString("P: Presente (personal planta básica)", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 55)
                e.Graphics.DrawString("DIS: Disponible (personal planta básica)", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 68)
                e.Graphics.DrawString("V: Viajando", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 81)
                e.Graphics.DrawString("SUS: Suspendido", Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 225, puntoY + 94)
                'Tercera columna
                e.Graphics.DrawString("Categorías del personal", Formato_Etiqueta_9R, Brocha, PuntoOrigenReporteBasico.X + 495, puntoY)
                e.Graphics.DrawString("A: Dirección obra", Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteBasico.X + 495, puntoY + 16)
                e.Graphics.DrawString("B: Supervisión", Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteBasico.X + 495, puntoY + 32)
                e.Graphics.DrawString("C: Admon, Of. Téc, HSE, QC, Seguridad, materiales", Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteBasico.X + 495, puntoY + 48)
                e.Graphics.DrawString("D: Rol diario", Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteBasico.X + 495, puntoY + 63)
                e.Graphics.DrawString("E: Personal apoyo", Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteBasico.X + 495, puntoY + 79)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + altoBloque, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + altoBloque) 'Horizontal completa
                puntoY += altoBloque

                e.Graphics.DrawString("Observaciones sobre trabajos realizados:", Formato_Etiqueta_7R, Brocha, PuntoOrigenReporteBasico.X, puntoY + 2)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 15, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 15) 'Horizontal completa
                puntoY += 15

                altoBloque = 185
                For i As UInteger = 1 To 10
                    y = puntoY + (i * 18.5)
                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigenReporteBasico.X, y, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, y) 'Horizontal completa
                Next
                If FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONPERSONA")).Length + FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONCOMPLEMENTO")).Length > 0 Then
                    cadenas.Clear()
                    cadenas.Add(FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONPERSONA")))
                    cadenas.Add(FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONCOMPLEMENTO")))
                    cadenasTotalParrafo.Clear()
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_8R, anchoDocumentoReporteBasico, e, False)
                    If cadenasTotalParrafo.Count > 0 Then
                        If cadenasTotalParrafo.Count <= 10 Then
                            For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                                y = puntoY + (i * 18.5)
                                e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_8R, anchoDocumentoReporteBasico, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X, y + 2)
                            Next
                        Else
                            cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_6R, anchoDocumentoReporteBasico, e, False)
                            For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                                y = puntoY + (i * 18.5)
                                e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_6R, anchoDocumentoReporteBasico, e), Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X, y + 5)
                            Next
                        End If
                    End If
                End If
                puntoY += altoBloque

                altoBloque = 65
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY) 'Horizontal completa
                e.Graphics.DrawString("Firma", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 35)
                e.Graphics.DrawString("Nombre", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 50)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 85, puntoY, PuntoOrigenReporteBasico.X + 85, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Jefe Cuadrilla", Formato_Etiqueta_9, Brocha, 140, PuntoOrigenReporteBasico.X + 85, puntoY + 2)
                e.Graphics.DrawStringCentered(filaReporteDiario("JEFECUADRILLA"), Formato_Etiqueta_5R, Brocha, 140, PuntoOrigenReporteBasico.X + 85, puntoY + 53)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 225, puntoY, PuntoOrigenReporteBasico.X + 225, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Administración", Formato_Etiqueta_9, Brocha, 180, PuntoOrigenReporteBasico.X + 225, puntoY + 2)
                e.Graphics.DrawStringCentered(filaReporteDiario("ADMINISTRADOR"), Formato_Etiqueta_5R, Brocha, 180, PuntoOrigenReporteBasico.X + 225, puntoY + 53)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 405, puntoY, PuntoOrigenReporteBasico.X + 405, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Superintendente", Formato_Etiqueta_9, Brocha, 175, PuntoOrigenReporteBasico.X + 405, puntoY + 2)
                e.Graphics.DrawStringCentered(filaReporteDiario("SUPERINTENDENTE"), Formato_Etiqueta_5R, Brocha, 175, PuntoOrigenReporteBasico.X + 405, puntoY + 53)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 580, puntoY, PuntoOrigenReporteBasico.X + 580, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Dirección obra", Formato_Etiqueta_9, Brocha, 165, PuntoOrigenReporteBasico.X + 580, puntoY + 2)
                e.Graphics.DrawStringCentered(filaReporteDiario("DIRECTOROBRA"), Formato_Etiqueta_5R, Brocha, 165, PuntoOrigenReporteBasico.X + 580, puntoY + 53)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 20, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 50, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 50) 'Horizontal completa
            Case 2 'Equipos
                'e.Graphics.DrawGrid(Color.LightGray, True, 0.5, Formato_Etiqueta_4, PuntoOrigenReporteBasico.X, PuntoOrigenReporteBasico.Y, anchoDocumentoReporteBasico, 990, 10)
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteBasico.X, PuntoOrigenReporteBasico.Y, anchoDocumentoReporteBasico, altoDocumentoReporteBasico - 20) 'Borde documento

                altoBloque = 60
                e.Graphics.DrawStringCentered("MAQUINARIA EN OBRA", Formato_Etiqueta_11, Brocha, anchoDocumentoReporteBasico, PuntoOrigenReporteBasico.X, puntoY + 10)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 35, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 35) 'Horizontal completa
                e.Graphics.DrawString("Cuadrilla:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 40)
                e.Graphics.DrawString(filaReporteDiario("CUADRILLA"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 85, puntoY + 40)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 85, puntoY + 55, PuntoOrigenReporteBasico.X + 495, puntoY + 55) 'horizontal
                e.Graphics.DrawStringRight("Fecha:", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X + 580, puntoY + 40)
                e.Graphics.DrawString(filaReporteDiario("FECHAREPORTEDIARIO"), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X + 580, puntoY + 40)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 580, puntoY + 55, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 55) 'horizontal
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + altoBloque, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + altoBloque) 'Horizontal completa
                puntoY += altoBloque

                altoBloque = 610
                e.Graphics.DrawStringCentered("Código", Formato_Etiqueta_8, Brocha, 75, PuntoOrigenReporteBasico.X, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 75, puntoY, PuntoOrigenReporteBasico.X + 75, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_8, Brocha, 320, PuntoOrigenReporteBasico.X + 75, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 395, puntoY, PuntoOrigenReporteBasico.X + 395, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("HORAS / TIEMPO / KILOMETRAJE", Formato_Etiqueta_8, Brocha, 205, PuntoOrigenReporteBasico.X + 395, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 395, puntoY + 25, PuntoOrigenReporteBasico.X + 600, puntoY + 25) 'horizontal
                e.Graphics.DrawStringCentered("Tot.", Formato_Etiqueta_8, Brocha, 30, PuntoOrigenReporteBasico.X + 395, puntoY + 30)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 425, puntoY + 25, PuntoOrigenReporteBasico.X + 425, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("HI / KI", Formato_Etiqueta_8, Brocha, 65, PuntoOrigenReporteBasico.X + 425, puntoY + 30)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 480, puntoY + 25, PuntoOrigenReporteBasico.X + 480, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("HF / KF", Formato_Etiqueta_8, Brocha, 70, PuntoOrigenReporteBasico.X + 480, puntoY + 30)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 550, puntoY + 25, PuntoOrigenReporteBasico.X + 550, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("DIS", Formato_Etiqueta_8, Brocha, 25, PuntoOrigenReporteBasico.X + 550, puntoY + 30)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 575, puntoY + 25, PuntoOrigenReporteBasico.X + 575, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("VAR", Formato_Etiqueta_8, Brocha, 25, PuntoOrigenReporteBasico.X + 575, puntoY + 30)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 600, puntoY, PuntoOrigenReporteBasico.X + 600, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Observ.", Formato_Etiqueta_8, Brocha, 70, PuntoOrigenReporteBasico.X + 600, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 670, puntoY, PuntoOrigenReporteBasico.X + 670, puntoY + altoBloque) 'vertical
                e.Graphics.DrawStringCentered("Cód. act. /", Formato_Etiqueta_8, Brocha, 75, PuntoOrigenReporteBasico.X + 670, puntoY + 10)
                e.Graphics.DrawStringCentered("tarea", Formato_Etiqueta_8, Brocha, 75, PuntoOrigenReporteBasico.X + 670, puntoY + 22)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 45, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 45) 'Horizontal completa
                puntoY += 45

                '105 -> 670
                For i As UInteger = 1 To 29
                    y = puntoY + (i * 19.5)
                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigenReporteBasico.X, y, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, y) 'Horizontal completa
                Next
                If contadorEquiposReporteBasico < _dtEquipo.Rows.Count Then
                    For j As UInteger = 0 To 28
                        y = puntoY + (j * 19.5)
                        e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("CODIGOEQUIPO"), Formato_Etiqueta_5R, Brocha, 75, PuntoOrigenReporteBasico.X, y + 5) 'CÓDIGO EQUIPO
                        If FunBase.QuitarCaracteresEnBlanco(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DESCRIPCION")).Length > 0 Then
                            Dim descripcion As String = _dtEquipo.Rows(contadorEquiposReporteBasico).Item("DESCRIPCION").ToString.Trim
                            Select Case descripcion.Length
                                Case Is < 63
                                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, PuntoOrigenReporteBasico.X + 75, y + 5)
                                    Exit Select
                                Case Is <= 74
                                    e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 75, y + 5)
                                    Exit Select
                                Case Else
                                    e.Graphics.DrawString(Mid(descripcion, 1, 74), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 75, y + 3)
                                    e.Graphics.DrawString(Mid(descripcion, 75, 74), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 75, y + 10)
                            End Select
                        End If
                        'If FunBase.QuitarCaracteresEnBlanco(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DESCRIPCION")).Length > 0 Then
                        '    If e.Graphics.MeasureString(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DESCRIPCION"), Formato_Etiqueta_5R).Width > 195 Then
                        '        cadenas.Clear()
                        '        cadenas.Add(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DESCRIPCION"))
                        '        cadenasTotalParrafo.Clear()
                        '        cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_5R, 200, e, False)
                        '        For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                        '            e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 85, y + (i * 8)) 'DESCRIPCIÓN
                        '        Next
                        '    Else
                        '        e.Graphics.DrawString(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DESCRIPCION"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 85, y + 5) 'DESCRIPCIÓN
                        '    End If
                        'End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("TOTAL")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("TOTAL"), Formato_Etiqueta_5R, Brocha, 55, PuntoOrigenReporteBasico.X + 395, y + 5) 'TOTAL
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("INICIAL")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("INICIAL"), Formato_Etiqueta_5R, Brocha, 65, PuntoOrigenReporteBasico.X + 425, y + 5) 'HI / KI
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("FINAL")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("FINAL"), Formato_Etiqueta_5R, Brocha, 90, PuntoOrigenReporteBasico.X + 480, y + 5) 'HF / KF
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DISPONIBLE")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("DISPONIBLE"), Formato_Etiqueta_5R, Brocha, 25, PuntoOrigenReporteBasico.X + 550, y + 5) 'DISPONIBLE
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("VARADO")) Then
                            e.Graphics.DrawStringCentered(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("VARADO"), Formato_Etiqueta_5R, Brocha, 25, PuntoOrigenReporteBasico.X + 575, y + 5) 'VARADO
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("OBSERVACION")) Then
                            e.Graphics.DrawString(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("OBSERVACION"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 600, y + 5) 'OBSERVACIÓN
                        End If
                        If Not IsDBNull(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("SERVICIO")) Then
                            e.Graphics.DrawString(_dtEquipo.Rows(contadorEquiposReporteBasico).Item("SERVICIO"), Formato_Etiqueta_5R, Brocha, PuntoOrigenReporteBasico.X + 670, y + 5) 'ACTIVIDAD / TAREA
                        End If

                        contadorEquiposReporteBasico += 1
                        If contadorEquiposReporteBasico >= _dtEquipo.Rows.Count Then
                            Exit For
                        End If
                    Next
                End If
                puntoY += altoBloque - 45

                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY) 'Horizontal completa
                e.Graphics.DrawString("Observaciones sobre trabajos realizados", Formato_Etiqueta_9, Brocha, PuntoOrigenReporteBasico.X, puntoY + 2)
                e.Graphics.DrawStringCentered("Firmas", Formato_Etiqueta_9, Brocha, 95, PuntoOrigenReporteBasico.X + 650, puntoY + 2)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X, puntoY + 20, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 20) 'Horizontal completa
                puntoY += 20
                For i As UInteger = 1 To 12
                    y = puntoY + (i * 23.33)
                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigenReporteBasico.X, y, PuntoOrigenReporteBasico.X + 650, y) 'horizontal
                Next
                If FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONEQUIPO")).Length > 0 Then
                    cadenas.Clear()
                    cadenas.Add(FunBase.QuitarCaracteresEnBlanco(filaReporteDiario("OBSERVACIONEQUIPO")))
                    cadenasTotalParrafo.Clear()
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_8R, 650, e, False)
                    If cadenasTotalParrafo.Count > 0 Then
                        For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                            y = puntoY + (i * 23.33)
                            e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_8R, 650, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenReporteBasico.X, y + 5)
                        Next
                    End If
                End If

                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY, PuntoOrigenReporteBasico.X + 650, PuntoOrigenReporteBasico.Y + altoDocumentoReporteBasico - 20) 'vertical
                e.Graphics.DrawStringCentered("Jefe de Cuadrilla", Formato_Etiqueta_8R, Brocha, 95, PuntoOrigenReporteBasico.X + 650, puntoY + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 23, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 23) 'horizontal
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 70, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 70) 'horizontal
                e.Graphics.DrawStringCentered("Administración", Formato_Etiqueta_8R, Brocha, 95, PuntoOrigenReporteBasico.X + 650, puntoY + 75)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 93, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 93) 'horizontal
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 140, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 140) 'horizontal
                e.Graphics.DrawStringCentered("Superintendente", Formato_Etiqueta_8R, Brocha, 95, PuntoOrigenReporteBasico.X + 650, puntoY + 145)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 163, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 163) 'horizontal
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 210, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 210) 'horizontal
                e.Graphics.DrawStringCentered("Dirección obra", Formato_Etiqueta_8R, Brocha, 95, PuntoOrigenReporteBasico.X + 650, puntoY + 215)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteBasico.X + 650, puntoY + 233, PuntoOrigenReporteBasico.X + anchoDocumentoReporteBasico, puntoY + 233) 'horizontal
        End Select

        contadorPaginasImpresas += 1
        e.Graphics.DrawStringCentered("Página " & contadorPaginasImpresas & If(totalPaginasImpresion > 0, " de " & totalPaginasImpresion, ""), Formato_Etiqueta_5, Brocha, anchoDocumentoReporteBasico, PuntoOrigenReporteBasico.X, PuntoOrigenReporteBasico.Y + altoDocumentoReporteBasico + 15)

        Select Case SeccionReporteBasico
            Case 1 'Personal
                If contadorPersonalReporteBasico >= _dtPersonal.Rows.Count Then
                    SeccionReporteBasico = 2 'Equipos, materiales y avance de obra
                End If
                e.HasMorePages = True
            Case 2 'Equipos, materiales y avance de obra
                If contadorEquiposReporteBasico >= _dtEquipo.Rows.Count Then
                    'SeccionReporteBasico = 1 'Personal
                    e.HasMorePages = False
                Else
                    e.HasMorePages = True
                End If
            Case Else
                e.HasMorePages = False
        End Select
    End Sub

    Private Sub FinImp_ReporteDiarioDeTiempoBasico(sender As Object, e As PrintEventArgs) Handles DocImp_ReporteDiarioDeTiempoBasico.EndPrint
        If e.PrintAction = PrintAction.PrintToPreview Then
            SeccionReporteBasico = 1 'Personal
            contadorPersonalReporteBasico = 0
            contadorEquiposReporteBasico = 0
            totalPaginasImpresion = contadorPaginasImpresas
            contadorPaginasImpresas = 0
        End If
    End Sub
#End Region

#Region " 12 - ICA-OMC-F-01 Reporte dirario de tiempo trabajado (TÉCNICO) En blanco"
    Private WithEvents DocImp_ReporteDiarioDeTiempoBlanco As PrintDocument
    Private Sub EvImp_ReporteDiarioDeTiempoBlanco(sender As Object, e As PrintPageEventArgs) Handles DocImp_ReporteDiarioDeTiempoBlanco.PrintPage
        Dim puntoY As UInteger = PuntoOrigenReporteDiario.Y
        Dim y As UInteger = 0
        Dim altoBloque As UInteger = 0
        Dim anchoBloque As UInteger = 0
        Dim cadenas As New ArrayList
        Dim cadenasTotalParrafo As New ArrayList

        'e.Graphics.DrawGrid(Color.LightGray, True, 0.5, Formato_Etiqueta_4, PuntoOrigenReporteDiario.X, PuntoOrigenReporteDiario.Y, anchoDocumentoReporteDiario, 710, 10, 10)

        'Encabezado
        altoBloque = 85
        e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, PuntoOrigenReporteDiario.Y, anchoDocumentoReporteDiario, altoBloque)
        e.Graphics.DrawImage(logoIsmocol, PuntoOrigenReporteDiario.X + 5, puntoY + 17, 60, 50)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY, PuntoOrigenReporteDiario.X + 70, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered("REPORTE DIARIO DE TIEMPO TRABAJADO", Formato_Etiqueta_8, Brocha, 730, PuntoOrigenReporteDiario.X + 80, puntoY + 9) 'PuntoY + 3
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 805, puntoY, PuntoOrigenReporteDiario.X + 805, puntoY + altoBloque) 'vertical
        e.Graphics.DrawStringCentered("ICA-OMC-F-01", Formato_Etiqueta_8, Brocha, 220, PuntoOrigenReporteDiario.X + 805, puntoY + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 805, puntoY + 20, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 20) 'horizontal
        e.Graphics.DrawStringCentered("Revisión No. " & "1", Formato_Etiqueta_6, Brocha, 220, PuntoOrigenReporteDiario.X + 805, puntoY + 20)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 30, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 30) 'horizontal
        puntoY += 30
        e.Graphics.DrawString("CONTRATO No.", Formato_Etiqueta_7, Brocha, PuntoOrigenReporteDiario.X + 70, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 165, puntoY, PuntoOrigenReporteDiario.X + 165, puntoY + 55) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 545, puntoY, PuntoOrigenReporteDiario.X + 545, puntoY + 55) 'vertical
        e.Graphics.DrawStringCentered("CENTRO COSTOS", Formato_Etiqueta_7, Brocha, 120, PuntoOrigenReporteDiario.X + 545, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 670, puntoY, PuntoOrigenReporteDiario.X + 670, puntoY + 55) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 805, puntoY, PuntoOrigenReporteDiario.X + 805, puntoY + 55) 'vertical
        e.Graphics.DrawStringCentered("BASE", Formato_Etiqueta_7, Brocha, 75, PuntoOrigenReporteDiario.X + 805, puntoY + 2)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 880, puntoY, PuntoOrigenReporteDiario.X + 880, puntoY + 40) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 15, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 15) 'horizontal
        puntoY += 15
        e.Graphics.DrawString("DISCIPLINA", Formato_Etiqueta_7, Brocha, PuntoOrigenReporteDiario.X + 70, puntoY + 7)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 445, puntoY, PuntoOrigenReporteDiario.X + 445, puntoY + 40) 'vertical
        e.Graphics.DrawString("CUADRILLA", Formato_Etiqueta_7, Brocha, PuntoOrigenReporteDiario.X + 70, puntoY + 27)
        e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_7, Brocha, 100, PuntoOrigenReporteDiario.X + 445, puntoY + 7)
        e.Graphics.DrawStringCentered("PARO", Formato_Etiqueta_7, Brocha, 120, PuntoOrigenReporteDiario.X + 545, puntoY + 7)
        e.Graphics.DrawStringCentered("DOMINICAL O", Formato_Etiqueta_7, Brocha, 75, PuntoOrigenReporteDiario.X + 805, puntoY + 2)
        e.Graphics.DrawStringCentered("FESTIVO (S/N)", Formato_Etiqueta_7, Brocha, 75, PuntoOrigenReporteDiario.X + 805, puntoY + 12)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 925, puntoY, PuntoOrigenReporteDiario.X + 925, puntoY + 40) 'vertical
        e.Graphics.DrawStringCentered("DÍA", Formato_Etiqueta_7, Brocha, 30, PuntoOrigenReporteDiario.X + 805, puntoY + 27)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 835, puntoY + 25, PuntoOrigenReporteDiario.X + 835, puntoY + 40) 'vertical
        e.Graphics.DrawStringCentered("FECHA DD/MM/AAAA", Formato_Etiqueta_7, Brocha, 105, PuntoOrigenReporteDiario.X + 925, puntoY + 7)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 960, puntoY + 25, PuntoOrigenReporteDiario.X + 960, puntoY + 40) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 995, puntoY + 25, PuntoOrigenReporteDiario.X + 995, puntoY + 40) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 25, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 25) 'horizontal
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 40, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 40) 'horizontal completa
        'Fin encabezado

        puntoY = PuntoOrigenReporteDiario.Y + 90
        Select Case SeccionReporteDiario
            Case 1 'Personal
                altoBloque = 550
                anchoBloque = anchoDocumentoReporteDiario
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("CÓDIGO", Formato_Etiqueta_5, Brocha, 50, PuntoOrigenReporteDiario.X, puntoY + 3)
                e.Graphics.DrawStringCentered("EMPLEADO", Formato_Etiqueta_5, Brocha, 50, PuntoOrigenReporteDiario.X, puntoY + 12)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 50, puntoY, PuntoOrigenReporteDiario.X + 50, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("NOMBRES Y APELLIDOS", Formato_Etiqueta_6, Brocha, 240, PuntoOrigenReporteDiario.X + 50, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 290, puntoY, PuntoOrigenReporteDiario.X + 290, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("CAT.", Formato_Etiqueta_6, Brocha, 30, PuntoOrigenReporteDiario.X + 290, puntoY + 8)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 320, puntoY, PuntoOrigenReporteDiario.X + 320, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_6, Brocha, 180, PuntoOrigenReporteDiario.X + 320, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 500, puntoY, PuntoOrigenReporteDiario.X + 500, puntoY + 495) 'vertical
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 500, puntoY + 10, PuntoOrigenReporteDiario.X + 750, puntoY + 10) 'horizontal
                e.Graphics.DrawStringCentered("HORARIO DE TRABAJO", Formato_Etiqueta_5, Brocha, 110, PuntoOrigenReporteDiario.X + 500, puntoY + 1)
                e.Graphics.DrawStringCentered("HORA INICIO", Formato_Etiqueta_4, Brocha, 45, PuntoOrigenReporteDiario.X + 500, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 545, puntoY + 10, PuntoOrigenReporteDiario.X + 545, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HORA FINAL", Formato_Etiqueta_4, Brocha, 45, PuntoOrigenReporteDiario.X + 545, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 590, puntoY + 10, PuntoOrigenReporteDiario.X + 590, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("UHA", Formato_Etiqueta_4, Brocha, 20, PuntoOrigenReporteDiario.X + 590, puntoY + 12)
                e.Graphics.DrawStringCentered("(S/N)", Formato_Etiqueta_4, Brocha, 20, PuntoOrigenReporteDiario.X + 590, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 610, puntoY, PuntoOrigenReporteDiario.X + 610, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("LIQUIDACIÓN HORAS TRABAJADAS", Formato_Etiqueta_5, Brocha, 135, PuntoOrigenReporteDiario.X + 610, puntoY + 1)
                e.Graphics.DrawStringCentered("HN", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 610, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 645, puntoY + 10, PuntoOrigenReporteDiario.X + 645, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HED", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 645, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 680, puntoY + 10, PuntoOrigenReporteDiario.X + 680, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HEN", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 680, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 715, puntoY + 10, PuntoOrigenReporteDiario.X + 715, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("HRN", Formato_Etiqueta_4, Brocha, 35, PuntoOrigenReporteDiario.X + 715, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 750, puntoY, PuntoOrigenReporteDiario.X + 750, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("RAC", Formato_Etiqueta_6, Brocha, 30, PuntoOrigenReporteDiario.X + 750, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 780, puntoY, PuntoOrigenReporteDiario.X + 780, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("PRN", Formato_Etiqueta_6, Brocha, 30, PuntoOrigenReporteDiario.X + 780, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 810, puntoY, PuntoOrigenReporteDiario.X + 810, puntoY + 495) 'vertical
                e.Graphics.DrawStringCentered("CÓD. ACTIVIDAD / TAREA", Formato_Etiqueta_6, Brocha, 220, PuntoOrigenReporteDiario.X + 810, puntoY + 7)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 25, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 25) 'horizontal completa
                puntoY += 25
                For i As UInteger = 1 To 20
                    y = puntoY + (i * 23.5)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, y, PuntoOrigenReporteDiario.X + anchoBloque, y) 'horizontal completa
                Next
                puntoY += 470
                e.Graphics.DrawString("CONVENCIONES PARA NOVEDADES DEL PERSONAL:", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X, puntoY + 2)
                e.Graphics.DrawString("O: Cuando no se labora", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 160, puntoY + 2)
                e.Graphics.DrawString("D: Descanso Compensatorio", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 160, puntoY + 10)
                e.Graphics.DrawString("A: Ausente sin permiso", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 240, puntoY + 2)
                e.Graphics.DrawString("I: Incapacidad por accidente de trabajo", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 240, puntoY + 10)
                e.Graphics.DrawString("IC: Incapacidad por enfermedad común", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 2)
                e.Graphics.DrawString("NDS: No Disponible (personal planta básica)", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 10)
                e.Graphics.DrawString("S: Sancionado", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 480, puntoY + 2)
                e.Graphics.DrawString("ACSP: Ausente con permiso sin pago", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 480, puntoY + 10)
                e.Graphics.DrawString("ACCP: Ausente con permiso con pago", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 590, puntoY + 2)
                e.Graphics.DrawString("P: Presente (personal planta básica)", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 590, puntoY + 10)
                e.Graphics.DrawString("DIS:  Disponible (personal planta básica)", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 700, puntoY + 2)
                e.Graphics.DrawString("V: Viajando", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 700, puntoY + 10)
                e.Graphics.DrawString("VAC: Vacaciones", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 820, puntoY + 2)
                e.Graphics.DrawString("SUS: Suspendido", fuenteConvencionesReporteDiario, Brocha, PuntoOrigenReporteDiario.X + 820, puntoY + 10)

                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 20, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 20) 'horizontal completa
                cadenas.Clear()
                cadenas.Add("Observaciones: ")
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 21) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 21) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                End If

                puntoY = PuntoOrigenReporteDiario.Y + 645
            Case 2 'Equipos, materiales y avance de obra
                'Equipos
                altoBloque = 275
                anchoBloque = anchoDocumentoReporteDiario
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("EQUIPOS", Formato_Etiqueta_6, Brocha, anchoBloque, PuntoOrigenReporteDiario.X, puntoY)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 10, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 10) 'horizontal completa
                e.Graphics.DrawStringCentered("CÓDIGO EQUIPO", Formato_Etiqueta_5, Brocha, 70, PuntoOrigenReporteDiario.X, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 70, puntoY + 10, PuntoOrigenReporteDiario.X + 70, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("DESCRIPCIÓN", Formato_Etiqueta_5, Brocha, 270, PuntoOrigenReporteDiario.X + 70, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 340, puntoY + 10, PuntoOrigenReporteDiario.X + 340, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("TOTAL", Formato_Etiqueta_5, Brocha, 40, PuntoOrigenReporteDiario.X + 340, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 380, puntoY + 10, PuntoOrigenReporteDiario.X + 380, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("HI / KI", Formato_Etiqueta_5, Brocha, 40, PuntoOrigenReporteDiario.X + 380, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 420, puntoY + 10, PuntoOrigenReporteDiario.X + 420, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("HF / KF", Formato_Etiqueta_5, Brocha, 50, PuntoOrigenReporteDiario.X + 420, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 470, puntoY + 10, PuntoOrigenReporteDiario.X + 470, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("DISPONIBLE", Formato_Etiqueta_5, Brocha, 60, PuntoOrigenReporteDiario.X + 470, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 530, puntoY + 10, PuntoOrigenReporteDiario.X + 530, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("VARADO", Formato_Etiqueta_5, Brocha, 60, PuntoOrigenReporteDiario.X + 530, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 590, puntoY + 10, PuntoOrigenReporteDiario.X + 590, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("ACTIVIDAD / TAREA", Formato_Etiqueta_5, Brocha, 150, PuntoOrigenReporteDiario.X + 590, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 740, puntoY + 10, PuntoOrigenReporteDiario.X + 740, puntoY + 244) 'vertical
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_5, Brocha, 290, PuntoOrigenReporteDiario.X + 740, puntoY + 15)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 30, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 30) 'horizontal completa
                puntoY += 30
                For i As UInteger = 1 To 13
                    y = puntoY + (i * 16.5)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, y, PuntoOrigenReporteDiario.X + anchoBloque, y) 'horizontal completa
                Next
                cadenas.Clear()
                cadenas.Add("Observaciones: ")
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 216) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 216) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                End If
                'Fin equipos

                puntoY += 250
                'Materiales
                altoBloque = 270
                anchoBloque = 580
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("MATERIALES", Formato_Etiqueta_6, Brocha, anchoBloque, PuntoOrigenReporteDiario.X, puntoY + 2)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 15, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 15) 'horizontal completa
                e.Graphics.DrawStringCentered("CÓD. ARTÍCULO", Formato_Etiqueta_4, Brocha, 50, PuntoOrigenReporteDiario.X, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 50, puntoY + 15, PuntoOrigenReporteDiario.X + 50, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("MATERIALES / CONSUMIBLES", Formato_Etiqueta_5, Brocha, 400, PuntoOrigenReporteDiario.X + 50, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 450, puntoY + 15, PuntoOrigenReporteDiario.X + 450, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("UND", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 450, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 480, puntoY + 15, PuntoOrigenReporteDiario.X + 480, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 480, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 510, puntoY + 15, PuntoOrigenReporteDiario.X + 510, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("ACTIVIDAD / TAREA", Formato_Etiqueta_5, Brocha, 70, PuntoOrigenReporteDiario.X + 511, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 30, PuntoOrigenReporteDiario.X + anchoBloque, puntoY + 30) 'horizontal completa
                puntoY += 30
                For i As UInteger = 1 To 13
                    y = puntoY + (i * 16.15)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, y, PuntoOrigenReporteDiario.X + anchoBloque, y) 'horizontal completa
                Next
                cadenas.Clear()
                cadenas.Add("Observaciones: ")
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X, y)
                    Next
                End If
                'Fin materiales

                puntoY = puntoY - 30
                'Avance de obra
                altoBloque = 270
                anchoBloque = 430
                e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X + 600, puntoY, anchoBloque, altoBloque)
                e.Graphics.DrawStringCentered("AVANCE DE OBRA", Formato_Etiqueta_6, Brocha, anchoBloque, PuntoOrigenReporteDiario.X + 600, puntoY + 2)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 600, puntoY + 15, PuntoOrigenReporteDiario.X + 600 + anchoBloque, puntoY + 15) 'horizontal completa
                e.Graphics.DrawStringCentered("ACTIVIDAD / TAREA", Formato_Etiqueta_5, Brocha, 70, PuntoOrigenReporteDiario.X + 601, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 670, puntoY + 15, PuntoOrigenReporteDiario.X + 670, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("DETALLE", Formato_Etiqueta_5, Brocha, 300, PuntoOrigenReporteDiario.X + 680, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 970, puntoY + 15, PuntoOrigenReporteDiario.X + 970, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("UND", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 970, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 1000, puntoY + 15, PuntoOrigenReporteDiario.X + 1000, puntoY + 240) 'vertical
                e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 30, PuntoOrigenReporteDiario.X + 1000, puntoY + 17)
                e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 600, puntoY + 30, PuntoOrigenReporteDiario.X + 600 + anchoBloque, puntoY + 30) 'horizontal completa
                puntoY += 30
                For i As UInteger = 1 To 13
                    y = puntoY + (i * 16.15)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 600, y, PuntoOrigenReporteDiario.X + 600 + anchoBloque, y) 'horizontal completa
                Next
                cadenas.Clear()
                cadenas.Add("Observaciones: ")
                cadenasTotalParrafo.Clear()
                cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_4R, anchoBloque, e, False)
                If cadenasTotalParrafo.Count <= 4 Then
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 7)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_4R, anchoBloque, e), Formato_Etiqueta_4R, Brocha, PuntoOrigenReporteDiario.X + 600, y)
                    Next
                Else
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_3R, anchoBloque, e, False)
                    For i As UInteger = 0 To cadenasTotalParrafo.Count - 1
                        y = (puntoY + 211) + (i * 6)
                        e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_3R, anchoBloque, e), Formato_Etiqueta_3R, Brocha, PuntoOrigenReporteDiario.X + 600, y)
                    Next
                End If
                'Fin avance de obra

                puntoY = PuntoOrigenReporteDiario.Y + 645
            Case Else

        End Select

        'Pie de página
        altoBloque = 65
        e.Graphics.DrawRectangle(Lapiz, PuntoOrigenReporteDiario.X, puntoY, anchoDocumentoReporteDiario, altoBloque)
        e.Graphics.DrawStringCentered("JEFE DE CUADRILLA", Formato_Etiqueta_6, Brocha, 350, PuntoOrigenReporteDiario.X, puntoY) 'w=270
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X, puntoY + 15)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X, puntoY + 40)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 50, puntoY + 10, PuntoOrigenReporteDiario.X + 50, puntoY + altoBloque) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 350, puntoY, PuntoOrigenReporteDiario.X + 350, puntoY + altoBloque) 'vertical

        e.Graphics.DrawStringCentered("ADMINISTRACIÓN", Formato_Etiqueta_6, Brocha, 340, PuntoOrigenReporteDiario.X + 350, puntoY) 'w=260
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 15)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 350, puntoY + 40)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 400, puntoY + 10, PuntoOrigenReporteDiario.X + 400, puntoY + altoBloque) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 690, puntoY, PuntoOrigenReporteDiario.X + 690, puntoY + altoBloque) 'vertical

        e.Graphics.DrawStringCentered("SUPERINTENDENTE", Formato_Etiqueta_6, Brocha, 340, PuntoOrigenReporteDiario.X + 690, puntoY) 'w=240
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 690, puntoY + 15)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigenReporteDiario.X + 690, puntoY + 40)
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X + 740, puntoY + 10, PuntoOrigenReporteDiario.X + 740, puntoY + altoBloque) 'vertical

        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 10, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 10) 'horizontal completa
        e.Graphics.DrawLine(Lapiz, PuntoOrigenReporteDiario.X, puntoY + 30, PuntoOrigenReporteDiario.X + anchoDocumentoReporteDiario, puntoY + 30) 'horizontal completa
        'Fin pie de página
        contadorPaginasImpresas += 1
        e.Graphics.DrawStringCentered("Página " & contadorPaginasImpresas & If(totalPaginasImpresion > 0, " de " & totalPaginasImpresion, ""), Formato_Etiqueta_5, Brocha, anchoDocumentoReporteDiario, PuntoOrigenReporteDiario.X, 790)

        Select Case SeccionReporteDiario
            Case 1 'Personal
                SeccionReporteDiario = 2 'Equipos, materiales y avance de obra
                e.HasMorePages = True
            Case 2 'Equipos, materiales y avance de obra
                e.HasMorePages = False
            Case Else
                e.HasMorePages = False
        End Select
    End Sub

    Private Sub FinImp_ReporteDiarioDeTiempoBlanco(sender As Object, e As PrintEventArgs) Handles DocImp_ReporteDiarioDeTiempoBlanco.EndPrint
        If e.PrintAction = PrintAction.PrintToPreview Then
            SeccionReporteDiario = 1 'Personal
            totalPaginasImpresion = contadorPaginasImpresas
            contadorPaginasImpresas = 0
        End If
    End Sub
#End Region

#Region "  14 - Formato Análisis Comparativo"
    Private WithEvents DocImp_OT_AnálisisComparativo As New PrintDocument
    Dim pendienteimprimirOT As Boolean = False
    Dim ContServiciosOT As Integer = 0
    Dim ContEquipoOT As Integer = 0
    Dim ContCIndirectoOT As Integer = 0
    Dim ContMaterialesOT As Integer = 0
    Dim ContManoObra As Integer = 0
    Dim ContComplementoOT As Integer = 0
    Dim ContAdicionales As Integer = 0
    Dim ContCuadros As Integer = 0
    Dim ContadorExtOT As Integer = 0
    Dim CargaPropiedadesOT As Boolean = False
    Dim CargaServiciosOT As Boolean = False
    Dim CargaEquiposOT As Boolean = False
    Dim CargaCIndirectoOT As Boolean = False
    Dim CargaMaterialesOT As Boolean = False
    Dim CargaManoObra As Boolean = False
    Dim CargaAdicionales As Boolean = False
    Dim CargaComplementoOT As Boolean = False
    Dim CargaCuadros As Boolean = False
    Dim drawFormat2 As New StringFormat
    Dim drawFormat3 As New StringFormat

    Private Formato_Valores_R As New Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)

    Private TamañoRenglon As Integer = 15
    Private RenglonesxHoja As Integer = 50
    Private Sub DocImpOT_AnálisisComparativo(sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_OT_AnálisisComparativo.PrintPage

        Dim InicioDespuesEncabezado As Integer = 140
        Dim ContadorInt As Integer = 0
        Dim ContadorIntCuadros As Integer = 0
        Dim puntoOrigen As New Point(6, 59)
        Dim puntoOrigen1 As New Point(6, 116)
        Dim Fecha As Date = Date.Now

        If CargaPropiedadesOT = False Then
            CargaPropiedadesOT = True
        End If
        If ContadorExt = 0 Then
            If ContadorInt = 0 Then
                e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, 780, 31)
                e.Graphics.DrawImage(logoIsmocol, puntoOrigen.X + 290, puntoOrigen.Y + 5, 28, 22)
                e.Graphics.DrawString("ISMOCOL S.A.", Formato_Etiqueta_6, Brocha, puntoOrigen.X + 370, puntoOrigen.Y + 3)
                e.Graphics.DrawString("CONTRATO No. " + _filaOrdenTrabajo("NROCONTRATO"), Formato_Etiqueta_6, Brocha, puntoOrigen.X + 355, puntoOrigen.Y + 17)
                e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y + 35, 780, 15)
                e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen.X + 1, puntoOrigen.Y + 35, 779, 15)
                e.Graphics.DrawString("ANALISIS DE ORDENES DE TRABAJO POR ACTIVIDAD", Formato_Etiqueta_6, Brocha, puntoOrigen.X + 260, puntoOrigen.Y + 37)
                drawFormat2.Alignment = StringAlignment.Far
                drawFormat3.Alignment = StringAlignment.Center

                e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X, puntoOrigen1.Y, 780, 36)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, puntoOrigen1.Y + 15, puntoOrigen1.X + 780, puntoOrigen1.Y + 15) 'Horizontal
                e.Graphics.DrawStringCentered("ORDEN PRINCIPAL", Formato_Etiqueta_5, Brocha, 70, puntoOrigen1.X, puntoOrigen1.Y + 3)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 115, puntoOrigen1.Y, puntoOrigen1.X + 115, puntoOrigen1.Y + 15) 'Vertical
                e.Graphics.DrawStringCentered("SUB ORDEN", Formato_Etiqueta_5, Brocha, 50, puntoOrigen1.X + 115, puntoOrigen1.Y + 3)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 165, puntoOrigen1.Y, puntoOrigen1.X + 165, puntoOrigen1.Y + 15) 'Vertical
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 70, puntoOrigen1.Y, puntoOrigen1.X + 70, puntoOrigen1.Y + 35) 'Vertical
                If _filaOrdenTrabajo("ESSUBORDEN") = "S" Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("NROORDENSAP"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 168, puntoOrigen1.Y + 3)
                Else
                    e.Graphics.DrawString("", Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 168, puntoOrigen1.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 210, puntoOrigen1.Y, puntoOrigen1.X + 210, puntoOrigen1.Y + 15) 'Vertical
                e.Graphics.DrawStringCentered("ESTADO ISM", Formato_Etiqueta_5, Brocha, 50, puntoOrigen1.X + 210, puntoOrigen1.Y + 3)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 260, puntoOrigen1.Y, puntoOrigen1.X + 260, puntoOrigen1.Y + 15) 'Vertical
                e.Graphics.DrawStringCentered(_filaOrdenTrabajo("ESTADO"), Formato_Etiqueta_5R, Brocha, 73, puntoOrigen1.X + 260, puntoOrigen1.Y + 3)
                e.Graphics.DrawStringCentered("DESCRIPCIÓN OT", Formato_Etiqueta_5, Brocha, 70, puntoOrigen1.X, puntoOrigen1.Y + 20)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 70, puntoOrigen1.Y, puntoOrigen1.X + 70, puntoOrigen1.Y + 35) 'Vertical
                If _filaOrdenTrabajo("ESSUBORDEN") = "N" Then
                    e.Graphics.DrawString(_filaOrdenTrabajo("NROORDENSAP"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 73, puntoOrigen1.Y + 3)
                Else
                    e.Graphics.DrawString(_filaOrdenTrabajo("NROORDENSAPPADRE"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 73, puntoOrigen1.Y + 3)
                End If
                Dim descripcion As String = _filaOrdenTrabajo("OBJETO").ToString.Trim
                Select Case descripcion.Length
                    Case Is < 53
                        e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 73, puntoOrigen1.Y + 20)
                        Exit Select
                    Case Is <= 58
                        e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 73, puntoOrigen1.Y + 19)
                        Exit Select
                    Case Else
                        e.Graphics.DrawString(Mid(descripcion, 1, 58), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 73, puntoOrigen1.Y + 16)
                        e.Graphics.DrawString(Mid(descripcion, 59, 58), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 73, puntoOrigen1.Y + 26)
                End Select

                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 333, puntoOrigen1.Y, puntoOrigen1.X + 333, puntoOrigen1.Y + 35) 'Vertical
                e.Graphics.DrawString("FECHA IMPR.", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 338, puntoOrigen1.Y + 3)
                e.Graphics.DrawString(Fecha.ToShortDateString, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 391, puntoOrigen1.Y + 3)
                e.Graphics.DrawStringCentered("FECHA INI. ISM", Formato_Etiqueta_5, Brocha, 55, puntoOrigen1.X + 333, puntoOrigen1.Y + 16)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 333, puntoOrigen1.Y + 25, puntoOrigen1.X + 438, puntoOrigen1.Y + 25) 'Horizontal
                e.Graphics.DrawStringCentered("FECHA FIN ISM", Formato_Etiqueta_5, Brocha, 55, puntoOrigen1.X + 333, puntoOrigen1.Y + 27)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 388, puntoOrigen1.Y, puntoOrigen1.X + 388, puntoOrigen1.Y + 35) 'Vertical
                If IsDBNull(_filaOrdenTrabajo("FECHAINICIOISMOCOL")) Then
                    'If _filaOrdenTrabajo("FECHAINICIOISMOCOL") = "01/01/1900" Then
                    e.Graphics.DrawString("", Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 391, puntoOrigen1.Y + 15)
                Else
                    e.Graphics.DrawString(_filaOrdenTrabajo("FECHAINICIOISMOCOL"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 391, puntoOrigen1.Y + 15)
                End If
                If IsDBNull(_filaOrdenTrabajo("FECHAFINISMOCOL")) Then
                    'If _filaOrdenTrabajo("FECHAFINISMOCOL") = "01/01/1900" Then
                    e.Graphics.DrawString("", Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 391, puntoOrigen1.Y + 26)
                Else
                    e.Graphics.DrawString(_filaOrdenTrabajo("FECHAFINISMOCOL"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 391, puntoOrigen1.Y + 26)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 438, puntoOrigen1.Y, puntoOrigen1.X + 438, puntoOrigen1.Y + 35) 'Vertical
                e.Graphics.DrawStringCentered("FECHA INICIO", Formato_Etiqueta_5, Brocha, 55, puntoOrigen1.X + 438, puntoOrigen1.Y + 3)
                e.Graphics.DrawStringCentered("FECHA CORTE", Formato_Etiqueta_5, Brocha, 55, puntoOrigen1.X + 438, puntoOrigen1.Y + 20)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 493, puntoOrigen1.Y, puntoOrigen1.X + 493, puntoOrigen1.Y + 35) 'Vertical
                e.Graphics.DrawString(_filaOrdenTrabajo("FECHAINICIO"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 496, puntoOrigen1.Y + 3)
                e.Graphics.DrawString(_filaOrdenTrabajo("FECHAFIN"), Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 496, puntoOrigen1.Y + 20)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 543, puntoOrigen1.Y, puntoOrigen1.X + 543, puntoOrigen1.Y + 35) 'Vertical
                e.Graphics.DrawStringCentered("AREA", Formato_Etiqueta_5, Brocha, 46, puntoOrigen1.X + 543, puntoOrigen1.Y + 5)
                e.Graphics.DrawStringCentered(_filaOrdenTrabajo("AREAEJECUCION"), Formato_Etiqueta_5R, Brocha, 46, puntoOrigen1.X + 543, puntoOrigen1.Y + 20)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, puntoOrigen1.Y, puntoOrigen1.X + 589, puntoOrigen1.Y + 35) 'Vertical
                e.Graphics.DrawStringCentered("SUB BASE: " + _filaOrdenTrabajo("NOMBREBASE"), Formato_Etiqueta_6R, Brocha, 150, puntoOrigen1.X + 610, puntoOrigen1.Y + 3)
                e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, puntoOrigen1.Y + 15, puntoOrigen1.X + 683, puntoOrigen1.Y + 35) 'Vertical
                e.Graphics.DrawStringCentered("TOTALES", Formato_Etiqueta_7, Brocha, 76, puntoOrigen1.X + 600, puntoOrigen1.Y + 20)
                e.Graphics.DrawStringCentered("CONTROL", Formato_Etiqueta_7, Brocha, 76, puntoOrigen1.X + 695, puntoOrigen1.Y + 20)
            End If
                ContadorExt = 1
                ContadorRenglones = ContadorRenglones + 1
            End If
            If CargaServiciosOT = False Then
                CargaServiciosOT = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If _dtServicios.Rows.Count > 0 And _dtServicios.Rows.Count > ContServiciosOT Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1) 'Horizontal
                    e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, 780, 13)
                    e.Graphics.DrawString("ITEM A COSTO DIRECTO", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 173, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("PROGRAMADO", Formato_Etiqueta_5, Brocha, 164, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("EJECUTADO", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("POR EJECUTAR", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Servicio", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_5, Brocha, 320, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Unidad", Formato_Etiqueta_5, Brocha, 49, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Cant.", Formato_Etiqueta_5, Brocha, 30, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Vr. Unitario", Formato_Etiqueta_5, Brocha, 58, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 76, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 71, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    Dim filaServicio As DataRow
                    For j = ContServiciosOT To _dtServicios.Rows.Count - 1
                        filaServicio = _dtServicios.Rows(j)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaServicio("CODIGOSERVICIO"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        Dim descripcion As String = filaServicio("DESCRIPCION").ToString.Trim
                        Select Case descripcion.Length
                            Case Is < 64
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                                Exit Select
                            Case Is <= 72
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(descripcion, 1, 72), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                                e.Graphics.DrawString(Mid(descripcion, 73, 72), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 9)
                        End Select
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaServicio("UNID"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 401, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaServicio("CANTIDADPROGRAMADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 440, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 460, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaServicio("VALORUNITARIOPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaServicio("VALORTOTALPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaServicio("CANTIDADEJECUTADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaServicio("VALORTOTALEJECUTADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaServicio("CANTIDADPENDIENTE"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 694, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaServicio("VALORTOTALPENDIENTE")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        ContServiciosOT = ContServiciosOT + 1
                        If ContadorRenglones > 55 Then
                            pendienteimprimirOT = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                    If pendienteimprimirOT = False Then
                        e.Graphics.DrawString("TOTAL A FACTURAR ", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 438, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 6)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtServicios.Compute("Sum(VALORTOTALPROGRAMADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtServicios.Compute("Sum(VALORTOTALPROGRAMADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtServicios.Compute("Sum(VALORTOTALEJECUTADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 594, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtServicios.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtServicios.Compute("Sum(VALORTOTALPENDIENTE)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtServicios.Compute("Sum(VALORTOTALPENDIENTE)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                End If
            End If

            If CargaEquiposOT = False Then
                CargaEquiposOT = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If _dtEquipo.Rows.Count > 0 And _dtEquipo.Rows.Count > ContEquipoOT Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1) 'Horizontal
                    e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, 780, 13)
                    e.Graphics.DrawString("COSTO EQUIPO, ORDENES DE SERVICIO Y/O SUBCONTRATOS DE EQUIPOS (INCLUYE IVA)", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 50, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS ESTIMADOS", Formato_Etiqueta_5, Brocha, 164, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS REALES", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("SALDO", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Item", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_5, Brocha, 218, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    ' e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
                    '  e.Graphics.DrawStringCentered("FACTURA", Formato_Etiqueta_5, Brocha, 35, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
                    '  e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
                    ' e.Graphics.DrawStringCentered("PROVEEDOR", Formato_Etiqueta_5, Brocha, 67, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Unidad", Formato_Etiqueta_5, Brocha, 49, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Cant.", Formato_Etiqueta_5, Brocha, 30, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Vr. Unitario", Formato_Etiqueta_5, Brocha, 58, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 76, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 71, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    Dim filaEquipo As DataRow
                    For j = ContEquipoOT To _dtEquipo.Rows.Count - 1
                        filaEquipo = _dtEquipo.Rows(j)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaEquipo("ITEM"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        Dim descripcion As String = filaEquipo("DESCRIPCION").ToString.Trim
                        Select Case descripcion.Length
                            Case Is < 63
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                                Exit Select
                            Case Is <= 71
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(descripcion, 1, 71), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                                e.Graphics.DrawString(Mid(descripcion, 72, 71), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 9)
                        End Select
                        ' e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
                        '   e.Graphics.DrawString(filaEquipo("FACTURA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 292, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
                        '  e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
                        ' e.Graphics.DrawString(filaEquipo("PROVEEDOR"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaEquipo("UNID"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 401, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaEquipo("CANTIDADPROGRAMADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 440, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 460, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaEquipo("VALORUNITARIOPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaEquipo("VALORTOTALPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaEquipo("CANTIDADEJECUTADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaEquipo("VALORTOTALEJECUTADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaEquipo("CANTIDADPENDIENTE"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 694, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaEquipo("VALORTOTALPENDIENTE")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        ContEquipoOT = ContEquipoOT + 1
                        If ContadorRenglones > 55 Then
                            pendienteimprimirOT = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                    If pendienteimprimirOT = False Then
                        e.Graphics.DrawString("SUB TOTALES EQUIPOS", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 420, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 6)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtEquipo.Compute("Sum(VALORTOTALPROGRAMADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtEquipo.Compute("Sum(VALORTOTALPROGRAMADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtEquipo.Compute("Sum(VALORTOTALEJECUTADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 594, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtEquipo.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtEquipo.Compute("Sum(VALORTOTALPENDIENTE)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtEquipo.Compute("Sum(VALORTOTALPENDIENTE)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                End If
            End If

            If CargaCIndirectoOT = False Then
                CargaCIndirectoOT = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If _dtCIndirecto.Rows.Count > 0 And _dtCIndirecto.Rows.Count > ContCIndirectoOT Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1) 'Horizontal
                    e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, 780, 13)
                    e.Graphics.DrawString("COSTO ORDENES DE SERVICIOS Y/O SUBCONTRATOS (INCLUYE IVA)", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 113, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS ESTIMADOS", Formato_Etiqueta_5, Brocha, 164, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS REALES", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("SALDO", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Item", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_5, Brocha, 218, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
                    ' e.Graphics.DrawStringCentered("FACTURA", Formato_Etiqueta_5, Brocha, 35, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
                    ' e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
                    ' e.Graphics.DrawStringCentered("PROVEEDOR", Formato_Etiqueta_5, Brocha, 67, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Unidad", Formato_Etiqueta_5, Brocha, 49, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Cant.", Formato_Etiqueta_5, Brocha, 30, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Vr. Unitario", Formato_Etiqueta_5, Brocha, 58, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 76, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 71, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    Dim filaCIndirecto As DataRow
                    For j = ContCIndirectoOT To _dtCIndirecto.Rows.Count - 1
                        filaCIndirecto = _dtCIndirecto.Rows(j)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaCIndirecto("ITEM"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        Dim descripcion As String = filaCIndirecto("DESCRIPCION").ToString.Trim
                        Select Case descripcion.Length
                            Case Is < 44
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                                Exit Select
                            Case Is <= 50
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(descripcion, 1, 50), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                                e.Graphics.DrawString(Mid(descripcion, 51, 50), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 9)
                        End Select
                        ' e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
                        '  e.Graphics.DrawString(filaCIndirecto("FACTURA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 292, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
                        ' e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
                        ' e.Graphics.DrawString(filaCIndirecto("PROVEEDOR"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaCIndirecto("UNID"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 401, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaCIndirecto("CANTIDADPROGRAMADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 440, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 460, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaCIndirecto("VALORUNITARIOPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaCIndirecto("VALORTOTALPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaCIndirecto("CANTIDADEJECUTADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaCIndirecto("VALORTOTALEJECUTADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaCIndirecto("CANTIDADPENDIENTE"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 694, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaCIndirecto("VALORTOTALPENDIENTE")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        ContCIndirectoOT = ContCIndirectoOT + 1
                        If ContadorRenglones > 55 Then
                            pendienteimprimirOT = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                    If pendienteimprimirOT = False Then
                        e.Graphics.DrawString("SUB TOTALES COSTOS DIRECTO", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 380, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 6)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtCIndirecto.Compute("Sum(VALORTOTALPROGRAMADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtCIndirecto.Compute("Sum(VALORTOTALPROGRAMADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtCIndirecto.Compute("Sum(VALORTOTALEJECUTADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 594, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtCIndirecto.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtCIndirecto.Compute("Sum(VALORTOTALPENDIENTE)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtCIndirecto.Compute("Sum(VALORTOTALPENDIENTE)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                End If
            End If

            If CargaMaterialesOT = False Then
                CargaMaterialesOT = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If _dtMateriales.Rows.Count > 0 And _dtMateriales.Rows.Count > ContMaterialesOT Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1) 'Horizontal
                    e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, 780, 13)
                    e.Graphics.DrawString("COSTO ISMOCOL POR MATERIALES Y/O CONSUMIBLES (INCLUYE IVA)", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 113, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS ESTIMADOS", Formato_Etiqueta_5, Brocha, 164, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS REALES", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("SALDO", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Item", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_5, Brocha, 218, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
                    'e.Graphics.DrawStringCentered("FACTURA", Formato_Etiqueta_5, Brocha, 35, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
                    'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
                    'e.Graphics.DrawStringCentered("PROVEEDOR", Formato_Etiqueta_5, Brocha, 67, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Unidad", Formato_Etiqueta_5, Brocha, 49, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Cant.", Formato_Etiqueta_5, Brocha, 30, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Vr. Unitario", Formato_Etiqueta_5, Brocha, 58, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 76, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 71, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    Dim filaMateriales As DataRow
                    For j = ContMaterialesOT To _dtMateriales.Rows.Count - 1
                        filaMateriales = _dtMateriales.Rows(j)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaMateriales("ITEM"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        Dim descripcion As String = filaMateriales("DESCRIPCION").ToString.Trim
                        Select Case descripcion.Length
                            Case Is < 44
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                                Exit Select
                            Case Is <= 50
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(descripcion, 1, 50), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                                e.Graphics.DrawString(Mid(descripcion, 51, 50), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 9)
                        End Select
                        'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 274, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
                        'e.Graphics.DrawString(filaMateriales("FACTURA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 292, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
                        'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 309, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
                        'e.Graphics.DrawString(filaMateriales("PROVEEDOR"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaMateriales("UNID"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 401, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaMateriales("CANTIDADPROGRAMADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 440, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 460, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaMateriales("VALORUNITARIOPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaMateriales("VALORTOTALPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaMateriales("CANTIDADEJECUTADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaMateriales("VALORTOTALEJECUTADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaMateriales("CANTIDADPENDIENTE"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 694, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaMateriales("VALORTOTALPENDIENTE")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        ContMaterialesOT = ContMaterialesOT + 1
                        If ContadorRenglones > 55 Then
                            pendienteimprimirOT = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                    If pendienteimprimirOT = False Then
                        e.Graphics.DrawString("SUBTOTAL MATERIALES", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 420, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 6)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtMateriales.Compute("Sum(VALORTOTALPROGRAMADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtMateriales.Compute("Sum(VALORTOTALPROGRAMADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtMateriales.Compute("Sum(VALORTOTALEJECUTADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 594, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtMateriales.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtMateriales.Compute("Sum(VALORTOTALPENDIENTE)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtMateriales.Compute("Sum(VALORTOTALPENDIENTE)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                End If
            End If

            If CargaManoObra = False Then
                CargaManoObra = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If _dtManoObra.Rows.Count > 0 And _dtManoObra.Rows.Count > ContManoObra Then
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1) 'Horizontal
                    e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 1, 780, 13)
                    e.Graphics.DrawString("COSTO ISMOCOL POR PERSONAL(INCLUYE FACTOR SALARIAL Y PRESTACIONAL)", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 113, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS ESTIMADOS", Formato_Etiqueta_5, Brocha, 164, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("COSTOS REALES", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawStringCentered("SALDO", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Ítem", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_5, Brocha, 320, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("No. Días", Formato_Etiqueta_5, Brocha, 49, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Cant.", Formato_Etiqueta_5, Brocha, 30, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Vr. Unitario", Formato_Etiqueta_5, Brocha, 58, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 76, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 71, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 14, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("CANT", Formato_Etiqueta_5, Brocha, 23, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    Dim filaManoObra As DataRow
                    For j = ContManoObra To _dtManoObra.Rows.Count - 1
                        filaManoObra = _dtManoObra.Rows(j)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaManoObra("ITEM"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        Dim descripcion As String = filaManoObra("DESCRIPCION").ToString.Trim
                        Select Case descripcion.Length
                            Case Is < 64
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                                Exit Select
                            Case Is <= 72
                                e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                                Exit Select
                            Case Else
                                e.Graphics.DrawString(Mid(descripcion, 1, 72), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                                e.Graphics.DrawString(Mid(descripcion, 73, 72), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 9)
                        End Select
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 376, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaManoObra("NRODIAS"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 401, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaManoObra("CANTIDADPROGRAMADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 440, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 455, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 460, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaManoObra("VALORUNITARIOPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaManoObra("VALORTOTALPROGRAMADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaManoObra("CANTIDADEJECUTADA"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 600, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaManoObra("VALORTOTALEJECUTADA")), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString(filaManoObra("CANTIDADPENDIENTE"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 694, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                        e.Graphics.DrawString(FormatearValor(filaManoObra("VALORTOTALPENDIENTE")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        ContManoObra = ContManoObra + 1
                        If ContadorRenglones > 55 Then
                            pendienteimprimirOT = True
                            Exit For
                        End If
                        ContadorRenglones = ContadorRenglones + 1
                    Next
                    If pendienteimprimirOT = False Then
                        e.Graphics.DrawString("SUBTOTAL PERSONAL", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 428, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 6)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtManoObra.Compute("Sum(VALORTOTALPROGRAMADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtManoObra.Compute("Sum(VALORTOTALPROGRAMADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtManoObra.Compute("Sum(VALORTOTALEJECUTADA)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 594, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtManoObra.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        If Not IsDBNull(_dtManoObra.Compute("Sum(VALORTOTALPENDIENTE)", "")) Then
                            e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 688, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                            e.Graphics.DrawString(FormatearValor(_dtManoObra.Compute("Sum(VALORTOTALPENDIENTE)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                        End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                End If
            End If

            If CargaComplementoOT = False Then
                CargaComplementoOT = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If _dtComplemento.Rows.Count > 0 And _dtComplemento.Rows.Count > ContComplementoOT Then
                    'ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Ítem", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Concepto", Formato_Etiqueta_5, Brocha, 457, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Planeado", Formato_Etiqueta_5, Brocha, 99, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Ejecutado", Formato_Etiqueta_5, Brocha, 94, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    e.Graphics.DrawStringCentered("Por  Ejecutar", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 13)
                    ContadorRenglones = ContadorRenglones + 1

                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)
                    e.Graphics.DrawString("1", Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 18)
                    e.Graphics.DrawString("2", Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23, drawFormat3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 36, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 36)
                    e.Graphics.DrawString("3", Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41, drawFormat3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 54, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 54)
                    e.Graphics.DrawString("4", Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59, drawFormat3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 72, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 72)
                    e.Graphics.DrawString("5", Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77, drawFormat3)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)

                    e.Graphics.DrawString("Desayuno", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 60, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 4)
                    e.Graphics.DrawString("Almuerzo", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 60, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 22)
                    e.Graphics.DrawString("Comida", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 60, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 40)
                    e.Graphics.DrawString("Alojamiento", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 60, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 58)
                    e.Graphics.DrawString("Miscelaneos", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 60, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 76)

                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALDESAYUNOPLANEADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALALMUERZOPLANEADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALCOMIDAPLANEADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALALOJAMIENTOPLANEADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALMISCELANIOSPLANEADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77, drawFormat2)

                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALDESAYUNOEJECUTADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALALMUERZOEJECUTADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALCOMIDAEJECUTADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALALOJAMIENTOEJECUTADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALMISCELANIOSEJECUTADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77, drawFormat2)

                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALDESAYUNOPOREJECUTAR")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 5, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALALMUERZOPOREJECUTAR")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 23, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALCOMIDAPOREJECUTAR")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALALOJAMIENTOPOREJECUTAR")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 59, drawFormat2)
                    e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77)
                    e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALMISCELANIOSPOREJECUTAR")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 77, drawFormat2)
                    e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90)
                    ContComplementoOT = ContComplementoOT + 1
                    If ContadorRenglones > 55 Then
                        pendienteimprimirOT = True
                    End If
                    'ContadorRenglones = ContadorRenglones + 1
                    If pendienteimprimirOT = False Then
                        e.Graphics.DrawString("TOTAL FACTURAR", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 428, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 108)

                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95)
                        e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALPLANEADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95, drawFormat2)

                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 108)

                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 617, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95)
                        e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALEJECUTADO")), Formato_Valores_R, Brocha, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95, drawFormat2)

                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 108)

                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95)
                        e.Graphics.DrawString(FormatearValor(_filaComplemento("TOTALPOREJECUTAR")), Formato_Valores_R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 95, drawFormat2)

                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 90, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 108)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 108, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 108)
                    End If
                    ContadorRenglones = ContadorRenglones + 7
                End If
            End If

            'If CargaAdicionales = False Then
            '    CargaAdicionales = True
            'End If
            'If ContadorRenglones < 50 Then
            '    If _dtAdicionales.Rows.Count > 0 And _dtAdicionales.Rows.Count > ContAdicionales Then
            '        'ContadorRenglones = ContadorRenglones + 1
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 1, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 1) 'Horizontal
            '        e.Graphics.FillRectangle(brocharellenoverde, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 1, 780, 13)
            '        e.Graphics.DrawString("COSTO ISMOCOL POR HORAS EXTRAS Y GASTOS DE VIAJES", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 113, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 3)
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
            '        ContadorRenglones = ContadorRenglones + 1
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 14, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 14, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
            '        e.Graphics.DrawStringCentered("Ítem", Formato_Etiqueta_5, Brocha, 56, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
            '        e.Graphics.DrawStringCentered("Descripción", Formato_Etiqueta_5, Brocha, 650, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
            '        e.Graphics.DrawStringCentered("Valor Total", Formato_Etiqueta_5, Brocha, 74, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon)
            '        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 13)
            '        ContadorRenglones = ContadorRenglones + 1
            '        Dim filaAdicionales As DataRow
            '        For j = ContAdicionales To _dtAdicionales.Rows.Count - 1
            '            filaAdicionales = _dtAdicionales.Rows(j)
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            'e.Graphics.DrawString(filaAdicionales("ITEM"), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 28, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat3)
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            'Dim descripcion As String = filaAdicionales("DESCRIPCION").ToString.Trim
            '            'Select Case descripcion.Length
            '            '    Case Is < 68
            '            '        e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5)
            '            '        Exit Select
            '            '    Case Is <= 76
            '            '        e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 8)
            '            '        Exit Select
            '            '    Case Else
            '            '        e.Graphics.DrawString(Mid(descripcion, 1, 76), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 3)
            '            '        e.Graphics.DrawString(Mid(descripcion, 77, 76), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 56, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 9)
            '            'End Select
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon - 2, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            e.Graphics.DrawString("$ ", Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 711, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5)
            '            e.Graphics.DrawString(FormatearValor(filaAdicionales("VALORTOTAL")), Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat2)
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            ContAdicionales = ContAdicionales + 1
            '            If ContadorRenglones > 55 Then
            '                pendienteimprimirOT = True
            '                Exit For
            '            End If
            '            ContadorRenglones = ContadorRenglones + 1
            '        Next
            '        If pendienteimprimirOT = False Then
            '            e.Graphics.DrawString("SUBTOTAL PERSONAL", Formato_Etiqueta_5, Brocha, puntoOrigen1.X + 428, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 6)
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 2, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            'If Not IsDBNull(_dtServicios.Compute("Sum(VALORTOTAL)", "")) Then
            '            '    e.Graphics.DrawString("$ ", Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 690, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5)
            '            '    e.Graphics.DrawString(FormatearValor(_dtServicios.Compute("Sum(VALORTOTAL)", "").ToString), Formato_Etiqueta_7R, Brocha, puntoOrigen1.X + 770, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 5, drawFormat)
            '            'End If
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 2, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '            e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 18)
            '        End If
            '    End If
            'End If


            If CargaCuadros = False Then
                CargaCuadros = True
            End If
            If ContadorRenglones < RenglonesxHoja Then
                If ContCuadros = 0 Then
                    If ContadorInt = 0 Then
                        ContadorRenglones = ContadorRenglones + 1
                        e.Graphics.DrawString("UTILIDAD PROG. (SIN AIU)", Formato_Etiqueta_4, Brocha, puntoOrigen1.X + 515, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 9)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, 76, 20)
                        'Sumar todos los subtotales en planeación
                        Dim TotalPlaneacion As Decimal = 0
                        Dim TotalEjecución As Decimal = 0
                        Dim TotalPendiente As Decimal = 0

                        Dim TotalFacturarPlaneado As Decimal = 0
                        Dim TotalFacturarEjecutado As Decimal = 0
                        Dim TotalFacturarPendiente As Decimal = 0

                        Dim PorcentajeTotalPlaneacion As Decimal = 0
                        Dim PorcentajeTotalEjecución As Decimal = 0
                        Dim PorcentajeTotalPendiente As Decimal = 0


                        If _dtServicios.Rows.Count > 0 Then
                            TotalFacturarPlaneado = _dtServicios.Compute("Sum(VALORTOTALPROGRAMADA)", "")
                            TotalFacturarEjecutado = _dtServicios.Compute("Sum(VALORTOTALEJECUTADA)", "")
                            TotalFacturarPendiente = _dtServicios.Compute("Sum(VALORTOTALPENDIENTE)", "")
                        End If

                        If _dtEquipo.Rows.Count > 0 Then
                            TotalPlaneacion = _dtEquipo.Compute("Sum(VALORTOTALPROGRAMADA)", "")
                            TotalEjecución = _dtEquipo.Compute("Sum(VALORTOTALEJECUTADA)", "")
                            TotalPendiente = _dtEquipo.Compute("Sum(VALORTOTALPENDIENTE)", "")
                        End If

                        If _dtCIndirecto.Rows.Count > 0 Then
                            TotalPlaneacion = TotalPlaneacion + _dtCIndirecto.Compute("Sum(VALORTOTALPROGRAMADA)", "")
                            TotalEjecución = TotalEjecución + _dtCIndirecto.Compute("Sum(VALORTOTALEJECUTADA)", "")
                            TotalPendiente = TotalPendiente + _dtCIndirecto.Compute("Sum(VALORTOTALPENDIENTE)", "")
                        End If

                        If _dtMateriales.Rows.Count > 0 Then
                            TotalPlaneacion = TotalPlaneacion + _dtMateriales.Compute("Sum(VALORTOTALPROGRAMADA)", "")
                            TotalEjecución = TotalEjecución + _dtMateriales.Compute("Sum(VALORTOTALEJECUTADA)", "")
                            TotalPendiente = TotalPendiente + _dtMateriales.Compute("Sum(VALORTOTALPENDIENTE)", "")
                        End If


                        If _dtManoObra.Rows.Count > 0 Then
                            TotalPlaneacion = TotalPlaneacion + _dtManoObra.Compute("Sum(VALORTOTALPROGRAMADA)", "")
                            TotalEjecución = TotalEjecución + _dtManoObra.Compute("Sum(VALORTOTALEJECUTADA)", "")
                            TotalPendiente = TotalPendiente + _dtManoObra.Compute("Sum(VALORTOTALPENDIENTE)", "")
                        End If

                        If _dtComplemento.Rows.Count > 0 Then
                            TotalPlaneacion = TotalPlaneacion + _dtComplemento.Compute("Sum(TOTALPLANEADO)", "")
                            TotalEjecución = TotalEjecución + _dtComplemento.Compute("Sum(TOTALEJECUTADO)", "")
                            TotalPendiente = TotalPendiente + _dtComplemento.Compute("Sum(TOTALPOREJECUTAR)", "")
                        End If

                        If TotalFacturarPlaneado <> 0 Then
                            PorcentajeTotalPlaneacion = 100 * ((TotalFacturarPlaneado - TotalPlaneacion) / TotalFacturarPlaneado)

                        End If
                        If TotalFacturarEjecutado <> 0 Then
                            PorcentajeTotalEjecución = 100 * ((TotalFacturarEjecutado - TotalEjecución) / TotalFacturarEjecutado)

                        End If
                        If TotalFacturarPendiente <> 0 Then
                            PorcentajeTotalPendiente = 100 * ((TotalFacturarPendiente - TotalPendiente) / TotalFacturarPendiente)
                        End If


                        PorcentajeTotalPlaneacion = Math.Round(PorcentajeTotalPlaneacion, 4, MidpointRounding.ToEven)
                        PorcentajeTotalEjecución = Math.Round(PorcentajeTotalEjecución, 4, MidpointRounding.ToEven)
                        PorcentajeTotalPendiente = Math.Round(PorcentajeTotalPendiente, 4, MidpointRounding.ToEven)

                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 518, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2)
                        e.Graphics.DrawString(FormatearValor((TotalFacturarPlaneado - TotalPlaneacion).ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 585, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, drawFormat2)
                        e.Graphics.DrawString("% " + PorcentajeTotalPlaneacion.ToString, Formato_Valores_R, Brocha, puntoOrigen1.X + 535, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)

                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 615, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2)
                        e.Graphics.DrawString(FormatearValor((TotalFacturarEjecutado - TotalEjecución).ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 680, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, drawFormat2)
                        e.Graphics.DrawString("% " + PorcentajeTotalEjecución.ToString, Formato_Valores_R, Brocha, puntoOrigen1.X + 625, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)

                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen1.X + 710, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3)
                        e.Graphics.DrawString(FormatearValor((TotalFacturarPendiente - TotalPendiente).ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 775, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 3, drawFormat2)
                        ' e.Graphics.DrawString("% " + PorcentajeTotalPendiente.ToString, Formato_Valores_R, Brocha, puntoOrigen1.X + 720, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 8)

                        'Dim Diferencia As Decimal = (FormatearValor(_dtServicios.Compute("Sum(VALORTOTALPROGRAMADA)", "")) - (FormatearValor(_dtEquipo.Compute("Sum(VALORTOTALPROGRAMADA)", ""))))
                        'If (FormatearValor(Diferencia)) > 0 Then
                        '    e.Graphics.DrawString(Diferencia, Formato_Etiqueta_5R, Brocha, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon, drawFormat2)
                        'End If
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 513, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8, puntoOrigen1.X + 589, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                        e.Graphics.DrawString("UTILIDAD REAL (SIN AIU)", Formato_Etiqueta_4, Brocha, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 9)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, 71, 20)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 612, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8, puntoOrigen1.X + 683, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8)
                        e.Graphics.DrawString("DESVIACIÓN", Formato_Etiqueta_4, Brocha, puntoOrigen1.X + 726, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 9)
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, 74, 20)
                        'e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 706, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 8, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones *  TamañoRenglon + 8)
                        ContadorRenglones = ContadorRenglones + 1 * 2
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, 780, 35)
                        e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_5, Brocha, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)

                        ContadorRenglones = ContadorRenglones + 1 * 3
                        e.Graphics.DrawRectangle(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, 780, 88)
                        e.Graphics.DrawStringCentered("ANALISIS DE COSTOS (IU INCLUIDO)", Formato_Etiqueta_5, Brocha, 425, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8) 'horizontal
                        e.Graphics.DrawStringCentered("COSTOS - ISMOCOL", Formato_Etiqueta_5, Brocha, 250, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 10)
                        e.Graphics.DrawStringCentered("FACTURADO", Formato_Etiqueta_5, Brocha, 175, puntoOrigen1.X + 250, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 10)
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 19, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 19) 'horizontal
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 30, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 30) 'horizontal
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41, puntoOrigen1.X + 780, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 41) 'horizontal
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 52, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 52) 'horizontal
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 63, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 63) 'horizontal
                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 74, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 74) 'horizontal
                        e.Graphics.DrawStringCentered("EQUIPOS", Formato_Etiqueta_5R, Brocha, 140, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 21)
                        e.Graphics.DrawStringCentered("COSTO DIRECTO", Formato_Etiqueta_5R, Brocha, 140, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 32)
                        e.Graphics.DrawStringCentered("MATERIALES", Formato_Etiqueta_5R, Brocha, 140, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 43)
                        e.Graphics.DrawStringCentered("PERSONAL", Formato_Etiqueta_5R, Brocha, 140, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 54)
                        e.Graphics.DrawStringCentered("COMPLEMENTO", Formato_Etiqueta_5R, Brocha, 140, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 65)
                        e.Graphics.DrawStringCentered("TOTAL COSTOS", Formato_Etiqueta_5, Brocha, 140, puntoOrigen1.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 76)

                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 120, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 19, puntoOrigen1.X + 120, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 86) ' vertical

                        If _dtEquipo.Rows.Count > 0 Then
                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 125, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 20)
                            e.Graphics.DrawString(FormatearValor(_dtEquipo.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 210, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 20, drawFormat2)
                        End If
                        If _dtCIndirecto.Rows.Count > 0 Then
                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 125, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 31)
                            e.Graphics.DrawString(FormatearValor(_dtCIndirecto.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 210, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 31, drawFormat2)
                        End If
                        If _dtMateriales.Rows.Count > 0 Then
                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 125, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 42)
                            e.Graphics.DrawString(FormatearValor(_dtMateriales.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 210, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 42, drawFormat2)
                        End If
                        If _dtManoObra.Rows.Count > 0 Then
                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 125, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 53)
                            e.Graphics.DrawString(FormatearValor(_dtManoObra.Compute("Sum(VALORTOTALEJECUTADA)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 210, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 53, drawFormat2)
                        End If
                        If _dtComplemento.Rows.Count > 0 Then
                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 125, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 64)
                            e.Graphics.DrawString(FormatearValor(_dtComplemento.Compute("Sum(TOTALEJECUTADO)", "").ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 210, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 64, drawFormat2)
                        End If

                        e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 125, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 75)
                        e.Graphics.DrawString(FormatearValor(TotalEjecución.ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 210, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 75, drawFormat2)

                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 230, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 8, puntoOrigen1.X + 230, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 86) ' vertical
                        e.Graphics.DrawStringCentered("VALOR FACTURADO", Formato_Etiqueta_5R, Brocha, 88, puntoOrigen1.X + 240, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 21)
                        e.Graphics.DrawStringCentered("I.U. (IMPREVISTOS Y UTILIDAD)", Formato_Etiqueta_4R, Brocha, 88, puntoOrigen1.X + 240, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 32)
                        e.Graphics.DrawStringCentered("TOTAL FACTURADO", Formato_Etiqueta_5R, Brocha, 88, puntoOrigen1.X + 240, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 43)
                        e.Graphics.DrawStringCentered("GANANCIA", Formato_Etiqueta_5R, Brocha, 88, puntoOrigen1.X + 240, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 54)
                        e.Graphics.DrawStringCentered("PORCENTAJE (I.U. INCLUIDO)", Formato_Etiqueta_4, Brocha, 88, puntoOrigen1.X + 240, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 65)

                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 338, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 19, puntoOrigen1.X + 338, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 86) ' vertical

                        Dim PORADMINISTRACION As Decimal = _filaOrdenTrabajo("PORADMINISTRACION")
                        Dim PORIMPUESTOS As Decimal = _filaOrdenTrabajo("PORIMPUESTOS")
                        Dim PORUTILIDAD As Decimal = _filaOrdenTrabajo("PORUTILIDAD")


                        Dim ValorFacturadoIU As Decimal = TotalFacturarEjecutado * ((PORIMPUESTOS + PORUTILIDAD) / 100)
                        Dim TotalFacturado As Decimal = TotalFacturarEjecutado + ValorFacturadoIU
                        Dim Ganancia As Decimal = TotalFacturado - TotalEjecución

                        If ValorFacturadoIU <> 0 Then
                            Dim PorcentajeIU As Decimal = Math.Round(((TotalFacturado - TotalEjecución) / TotalFacturado) * 100, 4, MidpointRounding.ToEven)

                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 20)
                            e.Graphics.DrawString(FormatearValor(TotalFacturarEjecutado.ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 400, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 20, drawFormat2)

                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 31)
                            e.Graphics.DrawString(FormatearValor(ValorFacturadoIU.ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 400, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 31, drawFormat2)

                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 42)
                            e.Graphics.DrawString(FormatearValor(TotalFacturado.ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 400, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 42, drawFormat2)

                            e.Graphics.DrawString("$", Formato_Valores_R, Brocha, puntoOrigen1.X + 343, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 53)
                            e.Graphics.DrawString(FormatearValor(Ganancia.ToString), Formato_Valores_R, Brocha, puntoOrigen1.X + 400, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 53, drawFormat2)

                            e.Graphics.DrawString("% " + PorcentajeIU.ToString, Formato_Valores_R, Brocha, puntoOrigen1.X + 400, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 64, drawFormat2)

                        End If



                        e.Graphics.DrawLine(Lapiz, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon - 2, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 86) ' vertical

                        e.Graphics.DrawStringCentered("FACTURADOR", Formato_Etiqueta_5, Brocha, 355, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 32)
                        e.Graphics.DrawStringCentered("PROFESIONAL DE MANTENIMIENTO", Formato_Etiqueta_5, Brocha, 355, puntoOrigen1.X + 425, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglon + 76)
                        If ContadorRenglones > 55 Then
                            pendienteimprimirOT = True
                        End If
                        ContCuadros = 1
                    End If
                End If
            End If

            If CargaServiciosOT = False Or CargaEquiposOT = False Or CargaCIndirectoOT = False Or CargaMaterialesOT = False Or CargaManoObra = False Or CargaComplementoOT = False Or CargaCuadros = False Then
                pendienteimprimirOT = True
            End If
            If pendienteimprimirOT = False Then
                If CargaServiciosOT = True And _dtServicios.Rows.Count > ContServiciosOT Then
                    pendienteimprimirOT = True
                End If

                If CargaEquiposOT = True And _dtEquipo.Rows.Count > ContEquipoOT Then
                    pendienteimprimirOT = True
                End If
                If CargaCIndirectoOT = True And _dtCIndirecto.Rows.Count > ContCIndirectoOT Then
                    pendienteimprimirOT = True
                End If
                If CargaMaterialesOT = True And _dtMateriales.Rows.Count > ContMaterialesOT Then
                    pendienteimprimirOT = True
                End If
                If CargaManoObra = True And _dtManoObra.Rows.Count > ContManoObra Then
                    pendienteimprimirOT = True
                End If
                If CargaComplementoOT = True And _dtComplemento.Rows.Count > ContComplementoOT Then
                    pendienteimprimirOT = True
                End If
                If CargaCuadros = True And ContCuadros = 0 Then
                    pendienteimprimirOT = True
                End If
            End If
            If pendienteimprimirOT = True Then
                e.Graphics.DrawString("CONTINUA SIGUIENTE PAGINA", Formato_Etiqueta_6, Brocha, 650, 1050)
                ContadorRenglones = 0
                e.HasMorePages = True
                ContadorRenglones = -7
                pendienteimprimirOT = False
            Else
                ContadorRenglones = 0
                ContServiciosOT = 0
                ContEquipoOT = 0
                ContCIndirectoOT = 0
                ContMaterialesOT = 0
                ContManoObra = 0
                ContComplementoOT = 0
                ContCuadros = 0
                ContadorExt = 0
                e.HasMorePages = False
            End If
    End Sub
#End Region

#Region " 15 - Reporte Diario de Cantidad de Obra Ejecutada"

    Private WithEvents DocImp_ObraEjecutada As New PrintDocument
    Dim pendienteimprimirOE As Boolean = False
    Private PuntoOrigen As New Point(32, 25)
    Const anchoDocumento As UInteger = 765
    Dim altoDocumento As UInteger = 0
    Const espaciadorCeldasGrandeOE As UInteger = 7
    Const espaciadorCeldasMedioOE As UInteger = 4
    Const espaciadorCeldasPequennoOE As UInteger = 2
    Dim drawFormatOE As New StringFormat
    Dim CargaDetalles As Boolean = False
    Dim CargaObservacion As Boolean = False
    Dim ContDetalle As Integer = 0
    Dim ContObservacion As Integer = 0
    Private TamañoRenglonOE As Integer = 25
    Private RenglonesxHojaOE As Integer = 24
    Private Sub DocImpObraEjecutada(sender As Object, ByVal e As PrintPageEventArgs) Handles DocImp_ObraEjecutada.PrintPage


        Dim puntoY As UInteger = PuntoOrigen.Y
        Dim y As UInteger = 0
        Dim InicioDespuesEncabezado As Integer = 225
        drawFormatOE.Alignment = StringAlignment.Far
        Dim fechaC As Date = _filaOrdenTrabajo("FECHA")
        Dim cadenas As New ArrayList
        Dim cadenasTotalParrafo As New ArrayList
        'Dim altoBloque As UInteger = 0
        'Dim anchoBloque As UInteger = 0
        'Dim cadenas As New ArrayList
        'Dim cadenasTotalParrafo As New ArrayList

        'e.Graphics.DrawGrid(Color.LightGray, True, 0.5, Formato_Etiqueta_4, PuntoOrigenReporteDiario.X, PuntoOrigenReporteDiario.Y, anchoDocumentoReporteDiario, 710, 10, 10)

        'Encabezado
        altoDocumento = 977
        e.Graphics.DrawRectangle(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, anchoDocumento, altoDocumento)
        If _filaOrdenTrabajo("IDBASE") = 121 Or _filaOrdenTrabajo("IDBASE") = 122 Or _filaOrdenTrabajo("IDBASE") = 123 Or _filaOrdenTrabajo("IDBASE") = 124 Or _filaOrdenTrabajo("IDBASE") = 125 Then
        Else
            e.Graphics.DrawImage(logoCenit, PuntoOrigen.X + 25, puntoY + 5, 65, 45)
        End If
        e.Graphics.DrawStringCentered("REPORTE DIARIO DE CANTIDAD DE OBRA EJECUTADA", Formato_Etiqueta_8, Brocha, 651, PuntoOrigen.X + 144, puntoY + 15)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 50, PuntoOrigen.X + anchoDocumento, puntoY + 50) 'horizontal
        e.Graphics.DrawString("CONTRATO No:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 60)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 80, PuntoOrigen.X + anchoDocumento, puntoY + 80) 'horizontal
        e.Graphics.DrawString("SISTEMA DE TRANSPORTE:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 90)
        e.Graphics.DrawString("No. OT SAP:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 408, puntoY + 90)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 112, PuntoOrigen.X + anchoDocumento, puntoY + 112) 'horizontal
        e.Graphics.DrawString("CORREDOR:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 122)
        e.Graphics.DrawString("OBJETO OT:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 408, puntoY + 122)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 138, PuntoOrigen.X + anchoDocumento, puntoY + 138) 'horizontal
        e.Graphics.DrawString("ABSCISA:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 148)
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 408, puntoY + 148)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 164, PuntoOrigen.X + anchoDocumento, puntoY + 164) 'horizontal
        e.Graphics.DrawString("COORDENADAS:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 174)
        e.Graphics.DrawString("% AVANCE OM:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 408, puntoY + 174)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 190, PuntoOrigen.X + anchoDocumento, puntoY + 190) 'horizontal
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 144, puntoY, PuntoOrigen.X + 144, puntoY + 190) 'vertical
        e.Graphics.DrawString(_filaOrdenTrabajo("CONTRATO"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 147, puntoY + 60)
        e.Graphics.DrawString(_filaOrdenTrabajo("SISTEMATRANSPORTE"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 147, puntoY + 90)
        Try
            e.Graphics.DrawString(_filaOrdenTrabajo("CORREDOR"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 147, puntoY + 122)
        Catch ex As Exception
        End Try
        e.Graphics.DrawString(_filaOrdenTrabajo("ABSCISA"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 147, puntoY + 148)
        e.Graphics.DrawString(_filaOrdenTrabajo("GEOREFERENCIACION"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 147, puntoY + 174)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 405, puntoY + 80, PuntoOrigen.X + 405, puntoY + 190) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 483, puntoY + 80, PuntoOrigen.X + 483, puntoY + 190) 'vertical
        e.Graphics.DrawString(_filaOrdenTrabajo("NROORDENSAP"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 486, puntoY + 90)
        Dim objeto As String = _filaOrdenTrabajo("OBJETO").ToString.Trim
        Select Case objeto.Length
            Case Is < 60
                e.Graphics.DrawString(objeto, Formato_Etiqueta_7, Brocha, PuntoOrigen.X + 486, puntoY + 122)
                Exit Select
            Case Is <= 71
                e.Graphics.DrawString(objeto, Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 486, puntoY + 122)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(objeto, 1, 71), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 486, puntoY + 115)
                e.Graphics.DrawString(Mid(objeto, 72, 71), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 486, puntoY + 125)
        End Select

        If Not IsDBNull(_filaOrdenTrabajo("PORAVANCEOM")) Then
            e.Graphics.DrawString(_filaOrdenTrabajo("PORAVANCEOM"), Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 486, puntoY + 174)
        End If

        e.Graphics.DrawString(fechaC.ToLongDateString, Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 486, puntoY + 148)

        If CargaDetalles = False Then
            CargaDetalles = True
        End If
        If ContadorRenglones < RenglonesxHojaOE Then
            If _dtDetalle.Rows.Count > 0 And _dtDetalle.Rows.Count > ContDetalle Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 208, PuntoOrigen.X + anchoDocumento, puntoY + 208) 'horizontal
                e.Graphics.DrawStringCentered("ITEM", Formato_Etiqueta_6, Brocha, 55, PuntoOrigen.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 10)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 55, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 17, PuntoOrigen.X + 55, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                e.Graphics.DrawStringCentered("DESCRIPCIÓN ACTIVIDAD MANTENIMIENTO", Formato_Etiqueta_6, Brocha, 361, PuntoOrigen.X + 55, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 10)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 17, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                e.Graphics.DrawStringCentered("UNIDAD DE", Formato_Etiqueta_6, Brocha, 60, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 15)
                e.Graphics.DrawStringCentered("MEDIDA", Formato_Etiqueta_6, Brocha, 60, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 17, PuntoOrigen.X + 490, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_6, Brocha, 60, PuntoOrigen.X + 490, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 15)
                e.Graphics.DrawStringCentered("PLANEADA", Formato_Etiqueta_6, Brocha, 60, PuntoOrigen.X + 490, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 17, PuntoOrigen.X + 550, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_6, Brocha, 60, PuntoOrigen.X + 550, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 15)
                e.Graphics.DrawStringCentered("EJECUTADA", Formato_Etiqueta_6, Brocha, 60, PuntoOrigen.X + 550, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 17, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_6, Brocha, 80, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 15)
                e.Graphics.DrawStringCentered("EJECUTADA", Formato_Etiqueta_6, Brocha, 80, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 5)
                e.Graphics.DrawStringCentered("ACUMULADA", Formato_Etiqueta_6, Brocha, 80, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 690, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 17, PuntoOrigen.X + 690, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                e.Graphics.DrawStringCentered("% DE AVANCE", Formato_Etiqueta_6, Brocha, 80, PuntoOrigen.X + 690, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 15)
                e.Graphics.DrawStringCentered("EJECUTADO", Formato_Etiqueta_6, Brocha, 80, PuntoOrigen.X + 690, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18, PuntoOrigen.X + anchoDocumento, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'horizontal
                ContadorRenglones = ContadorRenglones + 1

                For j = ContDetalle To _dtDetalle.Rows.Count - 1
                    e.Graphics.DrawStringCentered(_dtDetalle.Rows(ContDetalle).Item("CODIGOSERVICIO"), Formato_Etiqueta_6R, Brocha, 55, PuntoOrigen.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE) 'ITEM
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 55, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 7, PuntoOrigen.X + 55, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                    Dim descripcion As String = _dtDetalle.Rows(ContDetalle).Item("DESCRIPCION").ToString.Trim
                    Select Case descripcion.Length
                        Case Is < 66
                            e.Graphics.DrawString(descripcion, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 58, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE)
                            Exit Select
                        Case Is <= 82
                            e.Graphics.DrawString(descripcion, Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 58, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE)
                            Exit Select
                        Case Else
                            e.Graphics.DrawString(Mid(descripcion, 1, 82), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 58, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 5)
                            e.Graphics.DrawString(Mid(descripcion, 83, 82), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 58, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 5)
                    End Select
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 7, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                    If Not IsDBNull(_dtDetalle.Rows(ContDetalle).Item("UNID")) Then
                        e.Graphics.DrawStringCentered(_dtDetalle.Rows(ContDetalle).Item("UNID"), Formato_Etiqueta_6R, Brocha, 60, PuntoOrigen.X + 430, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE) 'UNIDAD DE MEDIDA
                    End If
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 7, PuntoOrigen.X + 490, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                    If Not IsDBNull(_dtDetalle.Rows(ContDetalle).Item("CANTIDADPROGRAMADA")) Then
                        e.Graphics.DrawString(_dtDetalle.Rows(ContDetalle).Item("CANTIDADPROGRAMADA"), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 545, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE, drawFormatOE) 'CANTIDAD EJECUTADA
                    End If
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 7, PuntoOrigen.X + 550, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                    If Not IsDBNull(_dtDetalle.Rows(ContDetalle).Item("CANTIDADEJECUTADADIACORTE")) Then
                        e.Graphics.DrawString(_dtDetalle.Rows(ContDetalle).Item("CANTIDADEJECUTADADIACORTE"), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 605, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE, drawFormatOE) 'CANTIDAD EJECUTADA
                    End If
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 7, PuntoOrigen.X + 610, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                    If Not IsDBNull(_dtDetalle.Rows(ContDetalle).Item("CANTIDADEJECUTADAACUMULADAHASTACORTE")) Then
                        e.Graphics.DrawString(_dtDetalle.Rows(ContDetalle).Item("CANTIDADEJECUTADAACUMULADAHASTACORTE"), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 685, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE, drawFormatOE) 'CANTIDAD EJECUTADA ACUMULADA
                    End If
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 690, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 7, PuntoOrigen.X + 690, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'vertical
                    If Not IsDBNull(_dtDetalle.Rows(ContDetalle).Item("PORAVANCEEJECUTADO")) Then
                        e.Graphics.DrawString(_dtDetalle.Rows(ContDetalle).Item("PORAVANCEEJECUTADO"), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 760, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE, drawFormatOE) '% DE AVANCE EJECUTADO
                    End If
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18, PuntoOrigen.X + anchoDocumento, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE + 18) 'horizontal
                    ContDetalle = ContDetalle + 1
                    If ContadorRenglones > 24 Then
                        pendienteimprimirOE = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
            End If
        End If

        ContadorRenglones = ContadorRenglones + 1
        If CargaObservacion = False Then
            CargaObservacion = True
        End If
        If ContadorRenglones < RenglonesxHojaOE Then
            If _dtObservacion.Rows.Count > 0 And _dtObservacion.Rows.Count > ContObservacion Then
                ContadorRenglones = ContadorRenglones + 1
                e.Graphics.DrawString("OBSERVACIONES:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 53)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 40, PuntoOrigen.X + anchoDocumento, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 40) 'horizontal
                ContadorRenglones = ContadorRenglones + 1

                For j = ContObservacion To _dtObservacion.Rows.Count - 1
                    'ContadorRenglones = ContadorRenglones + 1
                    If e.Graphics.MeasureString(_dtObservacion.Rows(ContObservacion).Item("OBSERVACION"), Formato_Etiqueta_6R).Width > anchoDocumento Then
                        cadenas.Clear()
                        cadenas.Add(FunBase.QuitarCaracteresEnBlanco(_dtObservacion.Rows(ContObservacion).Item("OBSERVACION")))
                        cadenasTotalParrafo.Clear()
                        cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_6R, anchoDocumento - 10, e, False)
                        For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                            y = i
                            e.Graphics.DrawString(SubParrafo1(cadenasTotalParrafo(i), Formato_Etiqueta_6R, anchoDocumento - 10, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 3, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 55 + (y * 11))
                        Next
                        ContadorRenglones = ContadorRenglones + 1
                    Else
                        'ContadorRenglones = ContadorRenglones + y
                        e.Graphics.DrawString(FunBase.QuitarCaracteresEnBlanco(_dtObservacion.Rows(ContObservacion).Item("OBSERVACION")), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 3, InicioDespuesEncabezado + ContadorRenglones * TamañoRenglonOE - 55 + (y * 5))
                    End If
                    'ContadorRenglones = ContadorRenglones + 1
                    ContObservacion = ContObservacion + 1
                    If ContadorRenglones > 22 Then
                        pendienteimprimirOE = True
                        Exit For
                    End If
                    ContadorRenglones = ContadorRenglones + 1
                Next
                ContadorRenglones = ContadorRenglones + 1
            End If
        End If

        puntoY = 20
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 848, PuntoOrigen.X + anchoDocumento, puntoY + 848) 'horizontal
        e.Graphics.DrawStringCentered("Por ISMOCOL S.A.", Formato_Etiqueta_6, Brocha, 390, PuntoOrigen.X, puntoY + 858)
        e.Graphics.DrawStringCentered("CONTRATISTA EJECUTOR", Formato_Etiqueta_6, Brocha, 390, PuntoOrigen.X, puntoY + 868)
        Try
            e.Graphics.DrawStringCentered(_dtResidente.Rows(0).Item("RESIDENTE"), Formato_Etiqueta_6, Brocha, 290, PuntoOrigen.X + 100, puntoY + 901)
        Catch ex As Exception
        End Try
        e.Graphics.DrawStringCentered("Por CENIT", Formato_Etiqueta_6, Brocha, 375, PuntoOrigen.X + 390, puntoY + 858)
        e.Graphics.DrawStringCentered("LIDER INTEGRAL DE MANTENIMIENTO", Formato_Etiqueta_6, Brocha, 375, PuntoOrigen.X + 390, puntoY + 868)
        e.Graphics.DrawStringCentered(_filaOrdenTrabajo("LIDERMANTENIMIENTO"), Formato_Etiqueta_6, Brocha, 295, PuntoOrigen.X + 470, puntoY + 901)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 890, PuntoOrigen.X + anchoDocumento, puntoY + 890) 'horizontal
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 901)
        e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 393, puntoY + 901)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 913, PuntoOrigen.X + anchoDocumento, puntoY + 913) 'horizontal
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 924)
        e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 393, puntoY + 924)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 936, PuntoOrigen.X + anchoDocumento, puntoY + 936) 'horizontal
        e.Graphics.DrawString("CARGO:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 947)
        e.Graphics.DrawString("CARGO:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 393, puntoY + 947)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, puntoY + 959, PuntoOrigen.X + anchoDocumento, puntoY + 959) 'horizontal
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 3, puntoY + 970)
        e.Graphics.DrawString("FECHA:", Formato_Etiqueta_6, Brocha, PuntoOrigen.X + 393, puntoY + 970)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 100, puntoY + 890, PuntoOrigen.X + 100, puntoY + 982) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 390, puntoY + 848, PuntoOrigen.X + 390, puntoY + 982) 'vertical
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 470, puntoY + 890, PuntoOrigen.X + 470, puntoY + 982) 'vertical


        If CargaDetalles = False Or CargaObservacion = False Then
            pendienteimprimirOE = True
        End If
        pendienteimprimirOE = False
        If pendienteimprimirOE = False Then
            If CargaDetalles = True And _dtDetalle.Rows.Count > ContDetalle Then
                pendienteimprimirOE = True
            End If

            If CargaObservacion = True And _dtObservacion.Rows.Count > ContObservacion Then
                pendienteimprimirOE = True
            End If
        End If
        ContadorRenglones = 0
        If pendienteimprimirOE = True Then
            ContadorRenglones = 0
            e.HasMorePages = True
            pendienteimprimirOT = False
        Else
            'ContadorRenglones = 0
            ContDetalle = 0
            ContObservacion = 0
            e.HasMorePages = False
            'ContDetalle = 0
            'ContObservacion = 0
            'ContadorRenglones = 0
        End If
    End Sub

#End Region

#Region " 16 - ICA-GRAL-F-082 CONTROL MENSUAL DE TRANSPORTES"
    Private WithEvents DocImp_ICAGRALF082 As New PrintDocument
    Private contadorDetalle As UInteger = 0
    Dim drawFormatE As New StringFormat
    Private contadorEquipos As Integer = 0


    Private Sub DocImpr_ICAGRALF082(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICAGRALF082.PrintPage

        Dim _filaRDEquipo As DataRow()
        Dim FilasDetalle As DataRow()
        Dim FilaTotales As DataRow()
        Dim FilaResumenOM As DataRow()

        _filaRDEquipo = dsE.Tables(0).Select("CODIGOEQUIPO='" + TablaIdE.Rows(contadorEquipos).Item("CODIGOEQUIPO") + "'")
        FilasDetalle = dsE.Tables(1).Select("CODIGOEQUIPO='" + TablaIdE.Rows(contadorEquipos).Item("CODIGOEQUIPO") + "'")
        FilaTotales = dsE.Tables(2).Select("CODIGOEQUIPO='" + TablaIdE.Rows(contadorEquipos).Item("CODIGOEQUIPO") + "'")
        FilaResumenOM = dsE.Tables(3).Select("CODIGOEQUIPO='" + TablaIdE.Rows(contadorEquipos).Item("CODIGOEQUIPO") + "'")


        Dim cadenas As New ArrayList
        Dim cadenasTotalParrafo As New ArrayList
        Dim Fecha As Date = DateTime.Now.ToShortDateString
        Dim Mes As Date
        Mes = FilasDetalle(contadorDetalle).Item("FECHAREPORTEDIARIO")
        drawFormatE.Alignment = StringAlignment.Far
        Dim anchodocumento As Integer = 741
        Brocha.Color = Color.Black
        Dim puntoOrigen As New Point(39, 42)
        e.Graphics.DrawRectangle(Lapiz, puntoOrigen.X, puntoOrigen.Y, anchodocumento, 960)
        e.Graphics.DrawStringCentered("CONTROL MENSUAL DE TRANSPORTES", Formato_Etiqueta_12, Brocha, 458, puntoOrigen.X + 142, puntoOrigen.Y + 22)
        e.Graphics.DrawStringCentered("POR REPORTE DE TIEMPO", Formato_Etiqueta_12, Brocha, 458, puntoOrigen.X + 142, puntoOrigen.Y + 42)
        e.Graphics.DrawStringCentered(_filaRDEquipo(0).Item("CODIGOEQUIPO"), Formato_Etiqueta_12, Brocha, 458, puntoOrigen.X + 142, puntoOrigen.Y + 72)
        'e.Graphics.DrawStringCentered("ICA-GRAL-F-082", Formato_Etiqueta_8, Brocha, 161, puntoOrigen.X + 580, puntoOrigen.Y + 20)
        'e.Graphics.DrawStringCentered("Revisión No. 2", Formato_Etiqueta_8, Brocha, 161, puntoOrigen.X + 580, puntoOrigen.Y + 60)
        Dim puntoY As UInteger = puntoOrigen.Y
        Dim puntoX As UInteger = puntoOrigen.X
        Dim y As UInteger = 0
        Dim X As UInteger = 0
        '*******************************************************************
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 152, puntoOrigen.Y, puntoOrigen.X + 152, puntoOrigen.Y + 97) 'Vertical
        e.Graphics.DrawImage(logoIsmocol, 69, 50, 100, 80)
        'e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y, puntoOrigen.X + 580, puntoOrigen.Y + 97) 'Vertical
        'e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 580, puntoOrigen.Y + 50, puntoOrigen.X + 741, puntoOrigen.Y + 50) 'Horizontal 
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 97, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 97) 'Horizontal completa

        e.Graphics.DrawString("CLASE DE VEHÍCULO:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 105)
        Dim clase As String = _filaRDEquipo(0).Item("CLASE").ToString.Trim
        Select Case clase.Length
            Case Is < 89
                e.Graphics.DrawString(clase, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 135, puntoY + 109)
                Exit Select
            Case Is <= 99
                e.Graphics.DrawString(clase, Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 135, puntoY + 109)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(clase, 1, 99), Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 135, puntoY + 99)
                e.Graphics.DrawString(Mid(clase, 100, 99), Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 135, puntoY + 109)
        End Select

        'e.Graphics.DrawString(_filaRDEquipo(0).Item("CLASE"), Formato_Etiqueta_6, Brocha, puntoOrigen.X + 135, puntoY + 109)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 130, puntoOrigen.Y + 119, puntoOrigen.X + 580, puntoOrigen.Y + 119) 'Horizontal 
        e.Graphics.DrawString("PROPIETARIO:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 127)
        Dim propietario As String = _filaRDEquipo(0).Item("PROPIETARIO").ToString.Trim
        Select Case propietario.Length
            Case Is < 48
                e.Graphics.DrawString(propietario, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 95, puntoY + 130)
                Exit Select
            Case Is <= 58
                e.Graphics.DrawString(propietario, Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 95, puntoY + 130)
                Exit Select
            Case Else
                e.Graphics.DrawString(Mid(propietario, 1, 58), Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 95, puntoY + 120)
                e.Graphics.DrawString(Mid(propietario, 59, 58), Formato_Etiqueta_5R, Brocha, puntoOrigen.X + 95, puntoY + 130)
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 90, puntoOrigen.Y + 140, puntoOrigen.X + 327, puntoOrigen.Y + 140) 'Horizontal 
        e.Graphics.DrawString("CONTRATO No:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 146)
        e.Graphics.DrawString(_filaRDEquipo(0).Item("CONTRATO"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 100, puntoY + 146)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 95, puntoOrigen.Y + 159, puntoOrigen.X + 190, puntoOrigen.Y + 159) 'Horizontal 

        e.Graphics.DrawString("MODELO:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 337, puntoOrigen.Y + 127)
        e.Graphics.DrawString(_filaRDEquipo(0).Item("MODELO"), Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 400, puntoY + 130)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 395, puntoOrigen.Y + 140, puntoOrigen.X + 570, puntoOrigen.Y + 140) 'Horizontal 
        e.Graphics.DrawString("MES LABORADO:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 210, puntoOrigen.Y + 146)
        e.Graphics.DrawString(Mes.ToString("MMMM").ToUpper, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 315, puntoOrigen.Y + 146)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 310, puntoOrigen.Y + 159, puntoOrigen.X + 397, puntoOrigen.Y + 159) 'Horizontal 
        e.Graphics.DrawString("AÑO:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 407, puntoOrigen.Y + 146)
        e.Graphics.DrawString(FilasDetalle(contadorDetalle).Item("AÑO").ToString, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 452, puntoOrigen.Y + 146)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 437, puntoOrigen.Y + 159, puntoOrigen.X + 497, puntoOrigen.Y + 159) 'Horizontal 

        e.Graphics.DrawString("PLACA No:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 590, puntoOrigen.Y + 105)
        If Not IsDBNull(_filaRDEquipo(0).Item("PLACA")) Then
            e.Graphics.DrawString(_filaRDEquipo(0).Item("PLACA"), Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 655, puntoY + 107)
        End If
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 650, puntoOrigen.Y + 119, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 119) 'Horizontal 
        e.Graphics.DrawString("BASE:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 580, puntoOrigen.Y + 127)
        Dim Base As String = FilasDetalle(contadorDetalle).Item("BASE").ToString.Trim
        Select Case Base.Length
            Case Is < 15
                e.Graphics.DrawString(Base, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 622, puntoY + 128)
                Exit Select
            Case Is <= 20
                e.Graphics.DrawString(Base, Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 622, puntoY + 130)
                Exit Select
        End Select
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 617, puntoOrigen.Y + 140, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 140) 'Horizontal 
        e.Graphics.DrawString("FECHA IMPRESIÓN:", Formato_Etiqueta_8, Brocha, puntoOrigen.X + 507, puntoOrigen.Y + 146)
        e.Graphics.DrawString(Fecha, Formato_Etiqueta_8R, Brocha, puntoOrigen.X + 622, puntoOrigen.Y + 146)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 617, puntoOrigen.Y + 159, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 159) 'Horizontal 

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 162, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 162) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 23, puntoOrigen.Y + 180, puntoOrigen.X + 254, puntoOrigen.Y + 180) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 202, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 202) 'Horizontal completa
        For i As UInteger = 1 To 31
            puntoY = 244
            y = puntoY + (i * 20)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, y, puntoOrigen.X + anchodocumento, y) 'horizontal completa
        Next

        e.Graphics.DrawString("DÍA", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 2, puntoOrigen.Y + 175)

        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 23, puntoOrigen.Y + 162, puntoOrigen.X + 23, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawStringCentered("ESTADO", Formato_Etiqueta_7R, Brocha, 86, puntoOrigen.X + 23, puntoOrigen.Y + 165)
        e.Graphics.DrawString("TRAB", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 25, puntoOrigen.Y + 185)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 52, puntoOrigen.Y + 180, puntoOrigen.X + 52, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawString("DISP", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 54, puntoOrigen.Y + 185)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 79, puntoOrigen.Y + 180, puntoOrigen.X + 79, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawString("VRDO", Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 81, puntoOrigen.Y + 185)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 109, puntoOrigen.Y + 162, puntoOrigen.X + 109, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawStringCentered("KILOMETRAJE / HOROMETRO", Formato_Etiqueta_6R, Brocha, 145, puntoOrigen.X + 109, puntoOrigen.Y + 165)
        e.Graphics.DrawStringCentered("KM / H", Formato_Etiqueta_6R, Brocha, 42, puntoOrigen.X + 109, puntoOrigen.Y + 182)
        e.Graphics.DrawStringCentered("INICIAL", Formato_Etiqueta_6R, Brocha, 42, puntoOrigen.X + 109, puntoOrigen.Y + 192)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 151, puntoOrigen.Y + 180, puntoOrigen.X + 151, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawStringCentered("KM / H", Formato_Etiqueta_6R, Brocha, 42, puntoOrigen.X + 151, puntoOrigen.Y + 182)
        e.Graphics.DrawStringCentered("FINAL", Formato_Etiqueta_6R, Brocha, 42, puntoOrigen.X + 151, puntoOrigen.Y + 192)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 193, puntoOrigen.Y + 180, puntoOrigen.X + 193, puntoOrigen.Y + 847) 'vertical
        e.Graphics.DrawStringCentered("KM / H", Formato_Etiqueta_6R, Brocha, 61, puntoOrigen.X + 193, puntoOrigen.Y + 182)
        e.Graphics.DrawStringCentered("TOTAL", Formato_Etiqueta_6R, Brocha, 61, puntoOrigen.X + 193, puntoOrigen.Y + 192)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 254, puntoOrigen.Y + 162, puntoOrigen.X + 254, puntoOrigen.Y + 847) 'vertical
        e.Graphics.DrawStringCentered("REPORTE", Formato_Etiqueta_6R, Brocha, 77, puntoOrigen.X + 254, puntoOrigen.Y + 172)
        e.Graphics.DrawStringCentered("DIARIO", Formato_Etiqueta_6R, Brocha, 77, puntoOrigen.X + 254, puntoOrigen.Y + 182)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 337, puntoOrigen.Y + 162, puntoOrigen.X + 337, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawStringCentered("OM", Formato_Etiqueta_6R, Brocha, 60, puntoOrigen.X + 337, puntoOrigen.Y + 177)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 162, puntoOrigen.X + 407, puntoOrigen.Y + 822) 'vertical
        e.Graphics.DrawStringCentered("SERVICIO", Formato_Etiqueta_6R, Brocha, 60, puntoOrigen.X + 407, puntoOrigen.Y + 177)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 467, puntoOrigen.Y + 162, puntoOrigen.X + 467, puntoOrigen.Y + 847) 'vertical
        e.Graphics.DrawStringCentered("NOMBRE DEL SUPERVISOR", Formato_Etiqueta_6R, Brocha, 193, puntoOrigen.X + 467, puntoOrigen.Y + 177)
        e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 660, puntoOrigen.Y + 162, puntoOrigen.X + 660, puntoOrigen.Y + 847) 'vertical
        e.Graphics.DrawStringCentered("VALOR", Formato_Etiqueta_6R, Brocha, 81, puntoOrigen.X + 660, puntoOrigen.Y + 175)

            If FilasDetalle.Length > 0 And FilasDetalle.Length > contadorDetalle Then
                For j As UInteger = 0 To 31
                    puntoY = 250
                    y = puntoY + (j * 20)

                    e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("DIA"), Formato_Etiqueta_6R, Brocha, 23, puntoOrigen.X, y) 'ITEM
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("TRABAJO")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("TRABAJO"), Formato_Etiqueta_6R, Brocha, 29, puntoOrigen.X + 23, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("DISPONIBLE")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("DISPONIBLE"), Formato_Etiqueta_6R, Brocha, 27, puntoOrigen.X + 52, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("VARADO")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("VARADO"), Formato_Etiqueta_6R, Brocha, 30, puntoOrigen.X + 79, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("INICIAL")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("INICIAL"), Formato_Etiqueta_6R, Brocha, 42, puntoOrigen.X + 109, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("FINAL")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("FINAL"), Formato_Etiqueta_6R, Brocha, 42, puntoOrigen.X + 151, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("TOTAL")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("TOTAL"), Formato_Etiqueta_6R, Brocha, 61, puntoOrigen.X + 193, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("REPORTEDIARIO")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("REPORTEDIARIO"), Formato_Etiqueta_6R, Brocha, 77, puntoOrigen.X + 254, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("NROORDENSAP")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("NROORDENSAP"), Formato_Etiqueta_6R, Brocha, 60, puntoOrigen.X + 337, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("SERVICIO")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("SERVICIO"), Formato_Etiqueta_6R, Brocha, 60, puntoOrigen.X + 407, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("SUPERVISOR")) Then
                        e.Graphics.DrawStringCentered(FilasDetalle(contadorDetalle).Item("SUPERVISOR"), Formato_Etiqueta_6R, Brocha, 193, puntoOrigen.X + 467, y)
                    End If
                    If Not IsDBNull(FilasDetalle(contadorDetalle).Item("VALOREQUIPO")) Then
                        e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen.X + 665, y)
                        e.Graphics.DrawString(FormatearValor(FilasDetalle(contadorDetalle).Item("VALOREQUIPO")), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + anchodocumento - 5, y, drawFormatE)
                    End If

                    contadorDetalle += 1
                    If contadorDetalle >= FilasDetalle.Length Then
                        Exit For
                    End If
                Next
            End If

            If FilaTotales.Length > 0 Then
                e.Graphics.DrawString("TOTAL DÍAS TRABAJADOS:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 827)
                If Not IsDBNull(FilaTotales(0).Item("TOTALDIAS")) Then
                    e.Graphics.DrawString(FilaTotales(0).Item("TOTALDIAS"), Formato_Valores_R, Brocha, puntoOrigen.X + 198, puntoOrigen.Y + 827)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 847, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 847) 'Horizontal completa
                e.Graphics.DrawString("TOTAL KM / H:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 259, puntoOrigen.Y + 827)
                If Not IsDBNull(FilaTotales(0).Item("TOTALKMH")) Then
                    e.Graphics.DrawString(FilaTotales(0).Item("TOTALKMH"), Formato_Valores_R, Brocha, puntoOrigen.X + 472, puntoOrigen.Y + 827)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 567, puntoOrigen.Y + 822, puntoOrigen.X + 567, puntoOrigen.Y + 847) 'vertical
                e.Graphics.DrawString("TOTAL:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 572, puntoOrigen.Y + 827)
                e.Graphics.DrawString("$ ", Formato_Valores_R, Brocha, puntoOrigen.X + 665, puntoOrigen.Y + 827)
                If Not IsDBNull(FilaTotales(0).Item("VALORTORAL")) Then
                    e.Graphics.DrawString(FormatearValor(FilaTotales(0).Item("VALORTORAL")), Formato_Valores_R, Brocha, puntoOrigen.X + anchodocumento - 5, puntoOrigen.Y + 827, drawFormatE)
                End If
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 874, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 874) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 77, puntoOrigen.Y + 877, puntoOrigen.X + 77, puntoOrigen.Y + 959) 'vertical
                e.Graphics.DrawLine(Lapiz, puntoOrigen.X + 407, puntoOrigen.Y + 877, puntoOrigen.X + 407, puntoOrigen.Y + 959) 'vertical
                e.Graphics.DrawString("RESUMEN VALOR X OM:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 857)
            End If
            For j = ContObservacion To FilaResumenOM.Length - 1
                puntoX = 165
                X = puntoX + (j * 120)
                If e.Graphics.MeasureString(FilaResumenOM(ContObservacion).Item("RESUMEN"), Formato_Etiqueta_6R).Width > anchodocumento Then
                    cadenas.Clear()
                    cadenas.Add(FunBase.QuitarCaracteresEnBlanco(FilaResumenOM(ContObservacion).Item("RESUMEN")))
                    cadenasTotalParrafo.Clear()
                    cadenasTotalParrafo = TextoAParrafoFuente(cadenas, Formato_Etiqueta_6R, 770, e, False)
                    For i As Integer = 0 To cadenasTotalParrafo.Count - 1
                        e.Graphics.DrawString(cadenasTotalParrafo(i), Formato_Etiqueta_6R, Brocha, puntoOrigen.X + 100, puntoOrigen.Y + 857)
                    Next
                    ContadorRenglones = ContadorRenglones + 1
                Else
                    e.Graphics.DrawString(FunBase.QuitarCaracteresEnBlanco(FilaResumenOM(ContObservacion).Item("RESUMEN")), Formato_Etiqueta_6R, Brocha, X, puntoOrigen.Y + 857)
                End If
                ContObservacion = ContObservacion + 1
            Next
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 877, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 877) 'Horizontal completa
            e.Graphics.DrawStringCentered("FACTURADOR ENCARGADO", Formato_Etiqueta_7R, Brocha, 330, puntoOrigen.X + 77, puntoOrigen.Y + 882)
            e.Graphics.DrawStringCentered(_filaRDEquipo(0).Item("FACTURADOR"), Formato_Valores_R, Brocha, 330, puntoOrigen.X + 77, puntoOrigen.Y + 927)
            e.Graphics.DrawStringCentered("DIRECTOR DE OBRA / RESIDENTE", Formato_Etiqueta_7R, Brocha, 330, puntoOrigen.X + 407, puntoOrigen.Y + 882)
            e.Graphics.DrawStringCentered(_filaRDEquipo(0).Item("RESIDENTE"), Formato_Valores_R, Brocha, 330, puntoOrigen.X + 407, puntoOrigen.Y + 927)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 895, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 895) 'Horizontal completa
            e.Graphics.DrawString("FIRMA:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 905)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 924, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 924) 'Horizontal completa
            e.Graphics.DrawString("NOMBRE:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 927)
            e.Graphics.DrawLine(Lapiz, puntoOrigen.X, puntoOrigen.Y + 942, puntoOrigen.X + anchodocumento, puntoOrigen.Y + 942) 'Horizontal completa
            e.Graphics.DrawString("FECHA:", Formato_Etiqueta_7R, Brocha, puntoOrigen.X + 5, puntoOrigen.Y + 945)

            If contadorEquipos > TablaIdE.Rows.Count - 2 Then
                e.HasMorePages = False
                contadorEquipos = 0
            Else
                e.HasMorePages = True
                contadorDetalle = 0
                contadorEquipos = contadorEquipos + 1

            End If


    End Sub

    Private Sub DocImp_ICAGRALF082_EndPrint(sender As Object, e As PrintEventArgs) Handles DocImp_ICAGRALF082.EndPrint
        If e.PrintAction = PrintAction.PrintToPreview Then
            contadorDetalle = 0
            ContObservacion = 0
        End If
    End Sub


#End Region


#Region "Rutina de impresión"
    Public Sub ImprimirFormatos(ByVal Formatos As ArrayList, ByVal VerVistaPrevia As Boolean, Optional ByVal Doblecara As Boolean = False)

        If TablaId.Rows.Count > 0 Then
            CargarDatasetOrdenTrabajo()
        End If
        If IdReporteDiario > -1 Then
            CargarDataSetReporteDeTiempo()
        End If

        If TablaIdC.Rows.Count > 0 Then
            If IDOTSERVICIO <> -1 Then
                CargarDatasetComparativoServicio()
            Else
                CargarDatasetComparativo()
            End If

        End If

        If TablaIdOE.Rows.Count > 0 Then
            CargarDatasetRDObraEjecutada()
        End If

        If TablaIdE.Rows.Count > 0 Then
            Try
                CargarDatasetControlMensualTransporte()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "No se encontraron datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If



        Dim PrintDialog1 As New PrintDialog()
        If PrintDialog1.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If
        Dim i As Integer
        Dim wimpresoras As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            wimpresoras = PrinterSettings.InstalledPrinters.Item(i)
            If InStr(1, wimpresoras, PrintDialog1.PrinterSettings.PrinterName, CompareMethod.Text) > 0 Then
                PrintDialog1.PrinterSettings.PrinterName = wimpresoras
            End If
        Next
        VistaPrevia.PrintPreviewControl.Zoom = 1.5
        VistaPrevia.WindowState = FormWindowState.Maximized
        If PrintDialog1.PrinterSettings.CanDuplex Then
            If Doblecara = True Then
                PrintDialog1.PrinterSettings.Duplex = Duplex.Horizontal
            End If
        End If



        For i = 0 To Formatos.Count - 1
            Select Case CInt(Formatos(i))
                Case 1 'Formato Ordenes de Trabajo
                    DocImp_OT.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_OT.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_OT
                Case 10 'ICA-OMC-F-01 Reporte dirario de tiempo trabajado (TÉCNICO)
                    DocImp_ReporteDiarioDeTiempo = New PrintDocument
                    DocImp_ReporteDiarioDeTiempo.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ReporteDiarioDeTiempo.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_ReporteDiarioDeTiempo
                Case 11 'ICA-GRAL-F-015 Reporte diario de tiempo trabajado (BÁSICO)
                    DocImp_ReporteDiarioDeTiempoBasico = New PrintDocument
                    DocImp_ReporteDiarioDeTiempoBasico.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ReporteDiarioDeTiempoBasico.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ReporteDiarioDeTiempoBasico
                Case 12 'ICA-OMC-F-01 Reporte dirario de tiempo trabajado (TÉCNICO) en Blanco
                    DocImp_ReporteDiarioDeTiempoBlanco = New PrintDocument
                    DocImp_ReporteDiarioDeTiempoBlanco.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ReporteDiarioDeTiempoBlanco.PrinterSettings.DefaultPageSettings.Landscape = True
                    VistaPrevia.Document = DocImp_ReporteDiarioDeTiempoBlanco
                Case 13 'ICA-OMC-F-01 Reporte dirario de tiempo trabajado (TÉCNICO) en bloque
                    For ind = 0 To TablaIdReporte.Rows.Count - 1
                        PuntoOrigenReporteDiario.X = 10
                        PuntoOrigenReporteDiario.Y = 50
                        SeccionReporteDiario = 1
                        contadorPersonalReporteDiario = 0
                        contadorEquiposReporteDiario = 0
                        contadorMaterialesReporteDiario = 0
                        contadorAvanceReporteDiario = 0
                        Dim fila As DataRow
                        fila = TablaIdReporte.Rows(ind)
                        IdReporteDiario = fila(0)
                        CargarDataSetReporteDeTiempo()
                        DocImp_ReporteDiarioDeTiempo = New PrintDocument
                        DocImp_ReporteDiarioDeTiempo.PrinterSettings = PrintDialog1.PrinterSettings
                        DocImp_ReporteDiarioDeTiempo.PrinterSettings.DefaultPageSettings.Landscape = True
                        DocImp_ReporteDiarioDeTiempo.Print()
                        VerVistaPrevia = False
                    Next
                Case 14 'Formato Ordenes de Trabajo
                    DocImp_OT_AnálisisComparativo.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_OT_AnálisisComparativo.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_OT_AnálisisComparativo
                Case 15 'Formato Obra Ejecutada CENIT
                    DocImp_ObraEjecutada.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ObraEjecutada.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ObraEjecutada
                    If PrintDialog1.PrinterSettings.CanDuplex Then
                        If Doblecara = True Then
                            PrintDialog1.PrinterSettings.Duplex = Duplex.Vertical
                        End If
                    End If
                Case 16 'ICA-GRAL-F-082 CONTROL MENSUAL DE TRANSPORTES
                    Dim salir As Boolean = False
                    contadorEquipos = 0
                    contadorDetalle = 0
                    ContObservacion = 0
                    DocImp_ICAGRALF082.PrinterSettings = PrintDialog1.PrinterSettings
                    DocImp_ICAGRALF082.PrinterSettings.DefaultPageSettings.Landscape = False
                    VistaPrevia.Document = DocImp_ICAGRALF082

                    If TablaIdE.Rows.Count > 0 Then
                        salir = True
                        If VerVistaPrevia = True Then
                            VistaPrevia.ShowDialog()
                        Else
                            VistaPrevia.Document.Print()
                        End If
                    End If
                    If salir = True Then
                        Exit Sub
                    End If
            End Select
            Try
                Cursor.Current = Cursors.WaitCursor
                If VerVistaPrevia = True Then
                    VistaPrevia.ShowDialog()
                Else
                    If Formatos(i) <> 13 Then
                        VistaPrevia.Document.Print()
                    End If
                End If
            Catch ex As Exception
                MsgBox("No se ha podido completar el proceso de impresión, por favor revisar la configuración.", MsgBoxStyle.Critical, "ERROR")
            End Try
        Next
    End Sub
#End Region

End Class 'Cl_Impresión

''' <summary>Extension methods for the System.Drawing.Graphics class</summary>
Module GraphicsExtensions

    <Runtime.CompilerServices.Extension()>
    Sub DrawGrid(gr As Graphics, colorLinea As Color, esPunteada As Boolean, separacionPunteado As Single, grosorLinea As Single, fuente As Font, puntoX As Single, puntoY As Single, w As Single, h As Single, pasoX As Single, pasoY As Single)
        If pasoX > 0 AndAlso pasoX < w Then
            Dim gridPen As Pen = New Pen(colorLinea)
            gridPen.Width = grosorLinea
            If esPunteada Then
                If separacionPunteado > 0 Then
                    gridPen.DashPattern = New Single() {separacionPunteado, separacionPunteado, separacionPunteado, separacionPunteado}
                Else
                    gridPen.DashStyle = Drawing2D.DashStyle.Dash
                End If
            End If
            Dim numberBrush As Brush = New SolidBrush(colorLinea)
            For x As Integer = puntoX To puntoX + w Step pasoX
                gr.DrawLine(gridPen, x, puntoY, x, puntoY + h)
                gr.DrawString((x - puntoX).ToString, fuente, numberBrush, x - (gr.MeasureString((x - puntoX).ToString, fuente).Width / 2), puntoY)
            Next
            If pasoY <= 0 OrElse pasoY >= h Then
                pasoY = pasoX
            End If
            For y As Integer = puntoY To puntoY + h Step pasoY
                gr.DrawString((y - puntoY).ToString, fuente, numberBrush, puntoX, y - (gr.MeasureString((y - puntoY).ToString, fuente).Height / 2))
                gr.DrawLine(gridPen, puntoX, y, puntoX + w, y)
            Next
        Else
            Throw New ArgumentException("El valor de separación de las líneas debe estar definido entre el tamaño de los bordes de la página.", "pasoX")
            Exit Sub
        End If
    End Sub
    <Runtime.CompilerServices.Extension()>
    Sub DrawGrid(gr As Graphics, colorLinea As Color, esPunteada As Boolean, grosorLinea As Single, fuente As Font, puntoX As Single, puntoY As Single, w As Single, h As Single, pasoX As Single, Optional pasoY As Single = 0)
        DrawGrid(gr, colorLinea, esPunteada, 0, grosorLinea, fuente, puntoX, puntoY, w, h, pasoX, pasoY)
    End Sub
    <Runtime.CompilerServices.Extension()>
    Sub DrawGrid(gr As Graphics, colorLinea As Color, separacionPunteado As Single, grosorLinea As Single, fuente As Font, puntoX As Single, puntoY As Single, w As Single, h As Single, pasoX As Single, Optional pasoY As Single = 0)
        If separacionPunteado > 0 Then
            DrawGrid(gr, colorLinea, True, separacionPunteado, grosorLinea, fuente, puntoX, puntoY, w, h, pasoX, pasoY)
        Else
            DrawGrid(gr, colorLinea, False, grosorLinea, fuente, puntoX, puntoY, w, h, pasoX, pasoY)
        End If
    End Sub


    ''' <summary>Draws a centered string</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="point">Text coordinates</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringCentered(gr As Graphics, text As String, font As Font, brush As Brush, lineWidth As Integer, point As Point)
        gr.DrawStringCentered(text, font, brush, lineWidth, point.X, point.Y)
    End Sub

    ''' <summary>Draws a centered string</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="lineWidth"></param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringCentered(gr As Graphics, text As String, font As Font, brush As Brush, lineWidth As Integer, x As Single, y As Single)
        Dim padding As Single
        padding = (lineWidth / 2) - (gr.MeasureString(text, font).Width / 2)
        gr.DrawString(text, font, brush, x + padding, y)
    End Sub

    ''' <summary>Draws a string aligned to the right</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="point">Text coordinates</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringRight(gr As Graphics, text As String, font As Font, brush As Brush, point As Point)
        gr.DrawStringRight(text, font, brush, point.X, point.Y)
    End Sub

    ''' <summary>Draws a string aligned to the right</summary>
    ''' <param name="gr">Graphics</param>
    ''' <param name="text">Text string</param>
    ''' <param name="font">Text font</param>
    ''' <param name="brush">Text fill color</param>
    ''' <param name="x">Text X axis coordinate</param>
    ''' <param name="y">Text Y axis coordinate</param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawStringRight(gr As Graphics, text As String, font As Font, brush As Brush, x As Single, y As Single)
        Dim padding As Single
        padding = gr.MeasureString(text, font).Width
        gr.DrawString(text, font, brush, x - padding, y)
    End Sub

    ''' <summary></summary>
    ''' <param name="objGraphics"></param>
    ''' <param name="m_intxAxis"></param>
    ''' <param name="m_intyAxis"></param>
    ''' <param name="m_intWidth"></param>
    ''' <param name="m_intHeight"></param>
    ''' <param name="m_diameter"></param>
    <Runtime.CompilerServices.Extension()>
    Sub DrawRoundedRectangle(objGraphics As Graphics, m_intxAxis As Integer, m_intyAxis As Integer, m_intWidth As Integer, m_intHeight As Integer, m_diameter As Integer)
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
        ' top left Arc
        objGraphics.DrawArc(Pens.Black, ArcRect, 180, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)
        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 270, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(Pens.Black, ArcRect, 0, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)
        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(Pens.Black, ArcRect, 90, 90)
        objGraphics.DrawLine(Pens.Black, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
    End Sub
End Module 'GraphicsExtensions