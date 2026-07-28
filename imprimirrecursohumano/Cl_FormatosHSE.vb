Imports System.Drawing.Printing
Imports System.Drawing
Imports FunBase = FuncionesBase.FuncionesBase
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Globalization

Partial Class Cl_Impresión

    Private filaReporte24H As DataRow
    Private filaReportePersona24H As DataRow
    Private filaReporteInv As DataRow
    Private dtTestigos As DataTable
    Private dtAcciones As DataTable
    Private dtLineaTiempo As DataTable
    Private dtEvidencias As DataTable
    Private dtInvestigadores As DataTable
    Private dtCausasActos As DataTable
    Private dtCausasCondiciones As DataTable
    Private dtCausasPersonales As DataTable
    Private dtCausasTrabajo As DataTable

    Private filaExamen As DataRow
    Private dtTareas As DataTable
    Private dtAntecedentesLaborales As DataTable
    Private dtAntecedenetesLaboralesRiesgos As DataTable
    Private dtAntecedentesPatologicos As DataTable
    Private dtHabitos As DataTable
    Private dtVacunacion As DataTable
    Private dtDiagnosticos As DataTable

    Private Sub CargarDataSetFormatosHSE()
        If filaReporte24H Is Nothing Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImpresionFormatosHSE", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IdReporte", IdReporte)
            comando.Parameters.AddWithValue("@TipoInforme", TipoReporte)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsFormatosHSE As New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsFormatosHSE)
                conexion.Close()

                If dsFormatosHSE.Tables(0).Rows.Count > 0 Then
                    filaReporte24H = dsFormatosHSE.Tables(0).Rows(0)
                End If

                If dsFormatosHSE.Tables(1).Rows.Count > 0 Then
                    filaReportePersona24H = dsFormatosHSE.Tables(1).Rows(0)
                End If

                If dsFormatosHSE.Tables(2).Rows.Count > 0 Then
                    filaReporteInv = dsFormatosHSE.Tables(2).Rows(0)
                End If

                If dsFormatosHSE.Tables(3).Rows.Count > 0 Then
                    dtTestigos = dsFormatosHSE.Tables(3)
                End If

                If dsFormatosHSE.Tables(4).Rows.Count > 0 Then
                    dtAcciones = dsFormatosHSE.Tables(4)
                End If

                If dsFormatosHSE.Tables(5).Rows.Count > 0 Then
                    dtLineaTiempo = dsFormatosHSE.Tables(5)
                End If

                If dsFormatosHSE.Tables(6).Rows.Count > 0 Then
                    dtCausasActos = dsFormatosHSE.Tables(6)
                End If

                If dsFormatosHSE.Tables(7).Rows.Count > 0 Then
                    dtCausasCondiciones = dsFormatosHSE.Tables(7)
                End If

                If dsFormatosHSE.Tables(8).Rows.Count > 0 Then
                    dtCausasPersonales = dsFormatosHSE.Tables(8)
                End If

                If dsFormatosHSE.Tables(9).Rows.Count > 0 Then
                    dtCausasTrabajo = dsFormatosHSE.Tables(9)
                End If

                If dsFormatosHSE.Tables(10).Rows.Count > 0 Then
                    dtEvidencias = dsFormatosHSE.Tables(10)
                End If

                If dsFormatosHSE.Tables(11).Rows.Count > 0 Then
                    dtInvestigadores = dsFormatosHSE.Tables(11)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Impresión de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If TipoReporte = 1 Then
                ImpresionReporte24H = True
            Else
                ImpresionReporteInv = True
            End If
        End If
    End Sub

    Private Sub CargarExamen()
        If filaExamen Is Nothing Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImpresionFormatosHSE", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IdReporte", IdExamen)
            comando.Parameters.AddWithValue("@TipoInforme", TipoReporte)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsFormatosHSE As New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsFormatosHSE)
                conexion.Close()
                If dsFormatosHSE.Tables(0).Rows.Count > 0 Then
                    filaExamen = dsFormatosHSE.Tables(0).Rows(0)
                End If

                If dsFormatosHSE.Tables(1).Rows.Count > 0 Then
                    dtTareas = dsFormatosHSE.Tables(1)
                End If

            Catch ex As Exception
            MessageBox.Show(ex.Message, "Impresión Concepto", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ImpresionExamen = True
        End If
    End Sub

    Private Sub CargarHistoriaClinica()
        If filaExamen Is Nothing Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ImpresionFormatosHSE", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IdReporte", IdExamen)
            comando.Parameters.AddWithValue("@TipoInforme", TipoReporte)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsFormatosHSE As New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsFormatosHSE)
                conexion.Close()
                If dsFormatosHSE.Tables(0).Rows.Count > 0 Then
                    filaExamen = dsFormatosHSE.Tables(0).Rows(0)
                End If

                If dsFormatosHSE.Tables(1).Rows.Count > 0 Then
                    dtAntecedentesLaborales = dsFormatosHSE.Tables(1)
                End If
                If dsFormatosHSE.Tables(2).Rows.Count > 0 Then
                    dtAntecedenetesLaboralesRiesgos = dsFormatosHSE.Tables(2)
                End If
                If dsFormatosHSE.Tables(3).Rows.Count > 0 Then
                    dtAntecedentesPatologicos = dsFormatosHSE.Tables(3)
                End If
                If dsFormatosHSE.Tables(4).Rows.Count > 0 Then
                    dtHabitos = dsFormatosHSE.Tables(4)
                End If
                If dsFormatosHSE.Tables(5).Rows.Count > 0 Then
                    dtVacunacion = dsFormatosHSE.Tables(5)
                End If
                If dsFormatosHSE.Tables(6).Rows.Count > 0 Then
                    dtDiagnosticos = dsFormatosHSE.Tables(6)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Impresión Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ImpresionExamen = True
        End If
    End Sub

#Region " 97 - Formato Reporte 24 Horas"
    Private WithEvents DocImp_ICHGRALF03 As New PrintDocument

    Public Property IdReporte As Integer
    Public Property TipoReporte As Integer

    Dim brocharellenogris As New SolidBrush(Color.FromArgb(214, 214, 214))

    Dim ImpresionReporte24H As Boolean = False
    Private Sub DocImpr_ICHGRALF03(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF03.PrintPage
        CargarDataSetFormatosHSE()
        Dim Cadenas As New ArrayList
        Dim CadenasTotal As New ArrayList
        Const espaciointerlineado As Integer = 20
        Dim TamañoYR24 As Integer = 0
        Dim PuntoOrigen As New Point(55, 55)
        'e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen.X, PuntoOrigen.Y, 730, 975) 'Rectangulo principal
        e.Graphics.DrawImage(logoIsmocol, PuntoOrigen.X + 20, PuntoOrigen.Y + 7, 90, 70)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 125, PuntoOrigen.Y, PuntoOrigen.X + 125, 140) 'Vertical
        e.Graphics.DrawString("REPORTE 24 HORAS DEL INCIDENTE", Formato_Etiqueta_12, Brocha, 180 + InicioCentradoTexto("REPORTE 24 HORAS DEL INCIDENTE", Formato_Etiqueta_12, 480, e), 90)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y, 660, 140) 'Vertical
        e.Graphics.DrawStringCentered("ICH-GRAL-F-003", Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 15)
        e.Graphics.DrawLine(Lapiz, 660, 97, 785, 97) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 4", Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 55)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, 140, PuntoOrigen.X + 730, 140) 'Horizontal completa

        PuntoOrigen.Y += 85 '140
        e.Graphics.DrawString("Reporte No.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 75, 140, PuntoOrigen.X + 75, PuntoOrigen.Y + 20)
        e.Graphics.DrawString(filaReporte24H("NUMEROREPORTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 230, 140, PuntoOrigen.X + 230, PuntoOrigen.Y + 20)
        e.Graphics.DrawString("Contrato No.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 235, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, 140, PuntoOrigen.X + 310, PuntoOrigen.Y + 20)
        e.Graphics.DrawString(filaReporte24H("CONTRATO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 315, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 420, 140, PuntoOrigen.X + 420, PuntoOrigen.Y + 20)
        e.Graphics.DrawString("Base", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 425, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 460, 140, PuntoOrigen.X + 460, PuntoOrigen.Y + 20)
        Dim Base As String = Trim(filaReporte24H("BASE").ToString)
        Select Case Base.Length
            Case Is < 51
                e.Graphics.DrawString(Base, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 465, PuntoOrigen.Y + 5)
            Case Else
                Cadenas.Add(Base)
                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_5R, 260, e)
                Dim otralinea As Integer = 7
                Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                For i As Integer = 0 To CadenasTotal.Count - 1
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_5R, 260, e), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 465, puntoobservacion)
                    puntoobservacion += otralinea
                Next
        End Select

        Cadenas.Clear()
        CadenasTotal.Clear()

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

        PuntoOrigen.Y += 20 '160
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawString("1.   TIPO DE INCIDENTE", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("TIPOINCIDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawString("2.   CONSECUENCIA", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 250, PuntoOrigen.Y, PuntoOrigen.X + 250, PuntoOrigen.Y + 40)
        e.Graphics.DrawString(filaReporte24H("CONSECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa

        PuntoOrigen.Y += 40 '200
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("3.   INFORMACIÓN DEL INCIDENTE", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

        PuntoOrigen.Y += 20 '220
        e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawString("Empresa", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("EMPLEADOR").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 40)

        e.Graphics.DrawString("Dependencia", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 3)
        Dim Dependencia As String = Trim(filaReporte24H("AREA").ToString)
        Select Case Dependencia.Length
            Case Is < 32
                e.Graphics.DrawString(Dependencia, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 23)
            Case Is < 50
                e.Graphics.DrawString(Dependencia, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 25)
            Case Else
                Cadenas.Add(Dependencia)
                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 177, e)
                Dim otralinea As Integer = 7
                Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                For i As Integer = 0 To CadenasTotal.Count - 1
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 177, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 187, puntoobservacion)
                    puntoobservacion += otralinea
                Next
        End Select

        Cadenas.Clear()
        CadenasTotal.Clear()

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 364, PuntoOrigen.Y, PuntoOrigen.X + 364, PuntoOrigen.Y + 40)

        e.Graphics.DrawString("Actividad Principal", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 3)
        Dim ActividadPrincipal As String = Trim(filaReporte24H("ACTIVIDADPRINCIPAL").ToString)
        Select Case ActividadPrincipal.Length
            Case Is < 32
                e.Graphics.DrawString(ActividadPrincipal, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 23)
            Case Is < 50
                e.Graphics.DrawString(ActividadPrincipal, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 25)
            Case Else
                Cadenas.Add(ActividadPrincipal)
                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 177, e)
                Dim otralinea As Integer = 7
                Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                For i As Integer = 0 To CadenasTotal.Count - 1
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 177, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 369, puntoobservacion)
                    puntoobservacion += otralinea
                Next
        End Select

        Cadenas.Clear()
        CadenasTotal.Clear()

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 546, PuntoOrigen.Y, PuntoOrigen.X + 546, PuntoOrigen.Y + 40)

        e.Graphics.DrawString("Sitio específico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 3)
        Dim SitioEspecifico As String = Trim(filaReporte24H("SITIOINCIDENTE").ToString)
        Select Case SitioEspecifico.Length
            Case Is < 32
                e.Graphics.DrawString(SitioEspecifico, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 23)
            Case Is < 50
                e.Graphics.DrawString(SitioEspecifico, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 25)
            Case Else
                Cadenas.Add(SitioEspecifico)
                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 177, e)
                Dim otralinea As Integer = 7
                Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                For i As Integer = 0 To CadenasTotal.Count - 1
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 177, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 551, puntoobservacion)
                    puntoobservacion += otralinea
                Next
        End Select

        Cadenas.Clear()
        CadenasTotal.Clear()

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa

        PuntoOrigen.Y += 40 '260
        Dim FechaAccidente As DateTime = filaReporte24H("FECHAACCIDENTE")
        e.Graphics.DrawString("Fecha del incidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(FechaAccidente.ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 117, PuntoOrigen.Y, PuntoOrigen.X + 117, PuntoOrigen.Y + 40)

        e.Graphics.DrawString("Hora del incidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 122, PuntoOrigen.Y + 3)
        Dim HoraAccidente As DateTime
        HoraAccidente = Convert.ToDateTime(filaReporte24H("HORAACCIDENTE").ToString)
        HoraAccidente = HoraAccidente.ToShortTimeString
        e.Graphics.DrawString(HoraAccidente, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 127, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 225, PuntoOrigen.Y, PuntoOrigen.X + 225, PuntoOrigen.Y + 40)

        e.Graphics.DrawString("Reportado por", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 230, PuntoOrigen.Y + 3)
        Dim Reporta As String = filaReporte24H("PERSONAREPORTA").ToString
        Select Case Reporta.Length
            Case Is < 35
                e.Graphics.DrawString(Reporta, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 230, PuntoOrigen.Y + 23)
            Case Is < 49
                e.Graphics.DrawString(Reporta, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 230, PuntoOrigen.Y + 25)
            Case Else
                Cadenas.Add(Reporta)
                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 260, e)
                Dim otralinea As Integer = 7
                Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                For i As Integer = 0 To CadenasTotal.Count - 1
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 260, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 230, puntoobservacion)
                    puntoobservacion += otralinea
                Next
        End Select

        Cadenas.Clear()
        CadenasTotal.Clear()
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, PuntoOrigen.Y, PuntoOrigen.X + 490, PuntoOrigen.Y + 40)

        e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 3)
        Dim cargo As String = filaReporte24H("CARGO").ToString
        Select Case cargo.Length
            Case Is < 45
                e.Graphics.DrawString(cargo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 23)
            Case Else
                e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 25)
        End Select
        e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa

        PuntoOrigen.Y += 40 '300
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("4.   DESCRIPCIÓN DEL INCIDENTE", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

        PuntoOrigen.Y += 20 '320
        Dim DescripcionIncidente As String = Replace(filaReporte24H("DESCRIPCIONINCIDENTE").ToString, vbLf, "")

        Cadenas.Add(Replace(filaReporte24H("DESCRIPCIONINCIDENTE").ToString.ToLower, vbLf, ""))
        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)

        For j As Integer = 0 To CadenasTotal.Count - 1
            e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, PuntoOrigen.Y + 5)
            If j < CadenasTotal.Count - 1 Then
                PuntoOrigen.Y += espaciointerlineado
            End If
        Next
        Cadenas.Clear()
        CadenasTotal.Clear()

        'PuntoOrigen.Y += 90 '410 
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)

        e.Graphics.DrawStringCentered("5.   EN CASO DE LESIONADO", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawString("Nombre del lesionado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 282, PuntoOrigen.Y + 20, PuntoOrigen.X + 282, PuntoOrigen.Y + 60)
        e.Graphics.DrawString("Cédula", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 374, PuntoOrigen.Y + 20, PuntoOrigen.X + 374, PuntoOrigen.Y + 60)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 379, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 666, PuntoOrigen.Y + 20, PuntoOrigen.X + 666, PuntoOrigen.Y + 60)
        e.Graphics.DrawString("Edad", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 671, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 40, PuntoOrigen.X + 728, PuntoOrigen.Y + 40) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 60, PuntoOrigen.X + 730, PuntoOrigen.Y + 60) 'Horizontal completa

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y + 60, PuntoOrigen.X + 145, PuntoOrigen.Y + 80)
        e.Graphics.DrawString("Diagnóstico de la lesión", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 63)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 80, PuntoOrigen.X + 728, PuntoOrigen.Y + 80) 'Horizontal completa

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 195, PuntoOrigen.Y + 80, PuntoOrigen.X + 195, PuntoOrigen.Y + 100)
        e.Graphics.DrawString("Atención inmediata suministrada", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 83)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 100, PuntoOrigen.X + 730, PuntoOrigen.Y + 100) 'Horizontal completa

        If filaReporte24H("TIPOINCIDENTE") = "Salud" Then

            Dim Lesionado As String = filaReportePersona24H("PERSONAACCIDENTE").ToString
            Select Case Lesionado.Length
                Case Is < 35
                    e.Graphics.DrawString(Lesionado, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 43)
                Case Is < 50
                    e.Graphics.DrawString(Lesionado, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 43)
                Case Else
                    Cadenas.Add(Lesionado)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 275, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 41
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 275, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select
            Cadenas.Clear()
            CadenasTotal.Clear()

            e.Graphics.DrawString(filaReportePersona24H("IDENTIFICACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 42)
            e.Graphics.DrawString(filaReportePersona24H("CARGO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 379, PuntoOrigen.Y + 43)
            e.Graphics.DrawString(filaReportePersona24H("FECHANACIMIENTO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 671, PuntoOrigen.Y + 43)
            e.Graphics.DrawString(filaReportePersona24H("DIAGNOSTICO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 63)

            Dim atencion As String = filaReportePersona24H("TIPOATENCIONINMEDIATA").ToString
            If atencion = "Traslado a centro de Atención" Then
                atencion += ": " + filaReportePersona24H("TRASLADO").ToString
            End If
            e.Graphics.DrawString(atencion, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 200, PuntoOrigen.Y + 83)
        End If

        PuntoOrigen.Y += 100 '510 
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("6.   PÉRDIDA POTENCIAL", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

        Dim TipoPerdida As String
        If filaReporte24H("TIPOINCIDENTE").ToString = "Salud" Then
            TipoPerdida = "Afectación personal"
        Else
            If filaReporte24H("TIPOINCIDENTE").ToString = "Seguridad" Then
                TipoPerdida = "Daño a propiedad"
            Else
                If filaReporte24H("TIPOINCIDENTE").ToString = "Ambiental" Then
                    TipoPerdida = "Afectación ambiental"
                Else
                    TipoPerdida = ""
                End If
            End If
        End If

        PuntoOrigen.Y += 20 '530 '505
        e.Graphics.DrawString("Tipo de perdida", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(TipoPerdida, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 222, PuntoOrigen.Y, PuntoOrigen.X + 222, PuntoOrigen.Y + 40)
        e.Graphics.DrawString("Categoria resultante", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 227, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("CATEGORIAPERDIDAPOTENCIAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 227, PuntoOrigen.Y + 23)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 250, PuntoOrigen.Y + 20, PuntoOrigen.X + 250, PuntoOrigen.Y + 40)
        e.Graphics.DrawString(filaReporte24H("NOMBREMATRIZPERDIDA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 23)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 566, PuntoOrigen.Y, PuntoOrigen.X + 566, PuntoOrigen.Y + 40)
        e.Graphics.DrawString("Potencial", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 571, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("NIVELPERDIDAPOTENCIAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 571, PuntoOrigen.Y + 23)

        e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa

        PuntoOrigen.Y += 40 '570 
        e.Graphics.DrawStringCentered("¿Cómo pudo haberse evitado este incidente?", Formato_Etiqueta_8, Brocha, 730, 55, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa

        PuntoOrigen.Y += 20 '590 
        Dim EvitadoIncidente As String = Replace(filaReporte24H("EVITADOINCIDENTE").ToString, vbLf, "")
        Cadenas.Add(EvitadoIncidente)
        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
        End If
        For j As Integer = 0 To CadenasTotal.Count - 1
            e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, PuntoOrigen.Y + 2)
            If j <= CadenasTotal.Count - 1 Then
                PuntoOrigen.Y += espaciointerlineado
            End If
        Next

        'PuntoOrigen.Y += 60 '650 
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y, PuntoOrigen.X + 728, PuntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("7.   ACCIONES INMEDIATADAS TOMADAS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20 '670 

        e.Graphics.DrawString("No.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 1, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 22, PuntoOrigen.Y, PuntoOrigen.X + 22, PuntoOrigen.Y + 80)
        e.Graphics.DrawString("Acción".ToString, Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 27, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa

        PuntoOrigen.Y += 20 '690 

        e.Graphics.DrawString("1.", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("ACCIONESINMEDIATAS_1").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 27, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20)

        PuntoOrigen.Y += 20 '710
        e.Graphics.DrawString("2.", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("ACCIONESINMEDIATAS_2").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 27, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20)

        PuntoOrigen.Y += 20 '730
        e.Graphics.DrawString("3.", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawString(filaReporte24H("ACCIONESINMEDIATAS_3").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 27, PuntoOrigen.Y + 3)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20)

        PuntoOrigen.Y += 20 '750
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("8.   ANEXOS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

        Dim Anexos As String = filaReporte24H("ANEXOS").ToString
        Dim CadenaAnexos As String = ""
        Dim OtrosAnexos As String = ""
        Dim coma As String = ""
        Dim ch As Char = Anexos(0)
        If ch = "S" Then
            CadenaAnexos += "Dibujos/Diagramas"
            coma = ", "
        Else
            coma = ""
        End If
        ch = Anexos(1)
        If ch = "S" Then
            CadenaAnexos += coma + "Fotos/Videos"
            coma = ", "
        Else
            coma = ""
        End If
        ch = Anexos(2)
        If ch = "S" Then
            CadenaAnexos += coma + "Informes médicos"
            coma = ", "
        Else
            coma = ""
        End If
        ch = Anexos(3)
        If ch = "S" Then
            CadenaAnexos += coma + "Otros: " + filaReporte24H("OTROSANEXOS").ToString
        End If

        PuntoOrigen.Y += 20 '770 

        e.Graphics.DrawString(CadenaAnexos, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20 '790 
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("9.   VALIDACIÓN", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

        PuntoOrigen.Y += 20 '810 

        e.Graphics.DrawLine(Lapiz_Mediano, PuntoOrigen.X + 130, PuntoOrigen.Y, PuntoOrigen.X + 130, PuntoOrigen.Y + 230)
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered("Director de Obra", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 130, PuntoOrigen.Y + 3)
        e.Graphics.DrawStringCentered(filaReporte24H("DIRECTOROBRA").ToString, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 130, PuntoOrigen.Y + 68)
        e.Graphics.DrawStringCentered(Date.Today, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 130, PuntoOrigen.Y + 98)
        e.Graphics.DrawLine(Lapiz_Mediano, PuntoOrigen.X + 430, PuntoOrigen.Y, PuntoOrigen.X + 430, PuntoOrigen.Y + 230)
        e.Graphics.DrawStringCentered("Coordinador HSE", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered(filaReporte24H("COORDINADORHSE").ToString, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 430, PuntoOrigen.Y + 68)
        e.Graphics.DrawStringCentered(Date.Today, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 430, PuntoOrigen.Y + 98)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawString("Firma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 28)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 60, PuntoOrigen.X + 730, PuntoOrigen.Y + 60) 'Horizontal completa
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 68)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 90, PuntoOrigen.X + 730, PuntoOrigen.Y + 90) 'Horizontal completa
        e.Graphics.DrawString("Fecha", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 98)
        e.Graphics.DrawLine(Lapiz_Mediano, PuntoOrigen.X, PuntoOrigen.Y + 115, PuntoOrigen.X + 730, PuntoOrigen.Y + 115) 'Horizontal completa

        PuntoOrigen.Y += 115 '935 
        e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
        e.Graphics.DrawStringCentered("Responsable de la actividad", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered(filaReporte24H("RESPONSABLEACTIVIDAD").ToString, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 130, PuntoOrigen.Y + 68)
        e.Graphics.DrawStringCentered(Date.Today, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 130, PuntoOrigen.Y + 98)
        e.Graphics.DrawStringCentered("Médico / Enfermero", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered(filaReporte24H("MEDICOENFERMERO").ToString, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 430, PuntoOrigen.Y + 68)
        e.Graphics.DrawStringCentered(Date.Today, Formato_Etiqueta_8R, Brocha, 300, PuntoOrigen.X + 430, PuntoOrigen.Y + 98)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawString("Firma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 28)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 60, PuntoOrigen.X + 730, PuntoOrigen.Y + 60) 'Horizontal completa
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 68)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 90, PuntoOrigen.X + 730, PuntoOrigen.Y + 90) 'Horizontal completa
        e.Graphics.DrawString("Fecha", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 98)

        PuntoOrigen.Y += 115 '1025 
        TamañoYR24 = PuntoOrigen.Y - 55
        Dim PuntoOrigen2 As New Point(55, 55)
        e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen2.X, PuntoOrigen2.Y, 730, TamañoYR24)

        e.Graphics.DrawStringCentered("Página 1 de 1", Formato_Etiqueta_8, Brocha, e.PageBounds.Width, 0, PuntoOrigen.Y + 20)

        If ImpresionReporte24H = True Then
            BloquearReporte24H()
        End If
    End Sub

    Private Sub BloquearReporte24H()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TIPO", 15)
            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IdReporte)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region " 98 - Formato Reporte Investigacion"
    Private WithEvents DocImp_ICHGRALF04 As New PrintDocument
    Dim ImpresionReporteInv As Boolean = False

    Dim ContadorPaginasReporteInv As Integer = 0
    Dim PaginasTotalReporteInv As Integer = 0
    Dim ImprimirPieDePagina As Boolean = False

    'variables para identificar los bloques de información que se estan imprimiendo
    Dim BloqueContratoADescripcion As Boolean = False
    Dim BloqueLineaTiempo As Boolean = False
    Dim BloqueImpresion As Integer = 0

    'Contadores para llevar la cuenta en caso de que no se impriman todos los item en una pagina
    Dim LTFaltantei As Integer = 0
    Dim TestigosFaltantei As Integer = 0
    Dim EvidenciasFaltantei As Integer = 0
    Dim CausasActosFaltantei As Integer = 0
    Dim CausasCondicionesFaltantei As Integer = 0
    Dim CausasPersonalesFaltantei As Integer = 0
    Dim CausasTrabajoFaltantei As Integer = 0
    Dim AccionesFaltantei As Integer = 0
    Dim InvestigadoresFaltantei As Integer = 0

    'Contador para dejar espacio en blanco seccion de causalidad cuando no hay ninguna
    Dim EspacioCausalidad As Integer = 0
    'Variable para guardar el tamaño maximo de la pagina
    Dim TamañoY As Integer

    Dim Terminado As Boolean = False
    Dim SubCadenaFaltante As New ArrayList
    Dim Pendientes As Boolean = True
    Dim Cadenas As New ArrayList
    Dim CadenasTotal As New ArrayList

    Private Sub DocImpr_ICHGRALF04(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF04.PrintPage
        If ContadorPaginasReporteInv = 0 Then
            CargarDataSetFormatosHSE()
        End If

        Const espaciointerlineado As Integer = 20

        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        Dim CantidadRenglones As Integer = 0
        Dim ContadorRenglones As Integer = 0

        Dim PuntoOrigen As New Point(55, 55)
        TamañoY = 985
        'e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen.X, PuntoOrigen.Y, 730, 975) 'Rectangulo principal
        e.Graphics.DrawImage(logoIsmocol, PuntoOrigen.X + 20, PuntoOrigen.Y + 7, 90, 70)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 125, PuntoOrigen.Y, PuntoOrigen.X + 125, 140) 'Vertical
        e.Graphics.DrawString("INVESTIGACIÓN DE INCIDENTES Y", Formato_Etiqueta_12, Brocha, 180 + InicioCentradoTexto("INVESTIGACIÓN DE INCIDENTES Y", Formato_Etiqueta_12, 480, e), 80)
        e.Graphics.DrawStringCentered("ENFERMEDAD LABORAL", Formato_Etiqueta_12, Brocha, 480, 180, 100)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y, 660, 140) 'Vertical
        e.Graphics.DrawStringCentered("ICH-GRAL-F-004", Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 15)
        e.Graphics.DrawLine(Lapiz, 660, 97, 785, 97) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 5", Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 55)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, 140, PuntoOrigen.X + 730, 140) 'Horizontal completa

        PuntoOrigen.Y += 85 '140
        ContadorRenglones = (1040 - PuntoOrigen.Y) / 20

        If BloqueContratoADescripcion = False Then
            Terminado = False

            e.Graphics.DrawString("Reporte No.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 75, 140, PuntoOrigen.X + 75, PuntoOrigen.Y + 20)
            e.Graphics.DrawString(filaReporte24H("NUMEROREPORTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 230, 140, PuntoOrigen.X + 230, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Contrato No.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 235, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, 140, PuntoOrigen.X + 310, PuntoOrigen.Y + 20)
            e.Graphics.DrawString(filaReporte24H("CONTRATO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 315, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 420, 140, PuntoOrigen.X + 420, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Base", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 425, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 460, 140, PuntoOrigen.X + 460, PuntoOrigen.Y + 20)
            Dim Base As String = Trim(filaReporte24H("BASE").ToString)
            Select Case Base.Length
                Case Is < 51
                    e.Graphics.DrawString(Base, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 465, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Base)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_5R, 260, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_5R, 260, e), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 465, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select

            ContadorRenglones -= 1

            Cadenas.Clear()
            CadenasTotal.Clear()

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

            PuntoOrigen.Y += 20 '160
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawString("1.   TIPO DE INCIDENTE", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporte24H("TIPOINCIDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawString("2.   CONSECUENCIA", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 250, PuntoOrigen.Y, PuntoOrigen.X + 250, PuntoOrigen.Y + 40)
            e.Graphics.DrawString(filaReporteInv("TIPOCONSECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40 '200
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("3.   INFORMACIÓN GENERAL DEL INCIDENTE", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            ContadorRenglones -= 1

            PuntoOrigen.Y += 20 '220
            e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawString("Empresa", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporte24H("EMPLEADOR").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 282, PuntoOrigen.Y, PuntoOrigen.X + 282, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Dependencia", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 3)
            Dim Dependencia As String = Trim(filaReporte24H("AREA").ToString)
            Select Case Dependencia.Length
                Case Is < 31
                    e.Graphics.DrawString(Dependencia, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 23)
                Case Is < 41
                    e.Graphics.DrawString(Dependencia, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 25)
                Case Else
                    Cadenas.Add(Dependencia)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 177, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 177, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 287, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select

            Cadenas.Clear()
            CadenasTotal.Clear()

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 464, PuntoOrigen.Y, PuntoOrigen.X + 464, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Actividad Principal", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 469, PuntoOrigen.Y + 3)
            Dim ActividadPrincipal As String = Trim(filaReporte24H("ACTIVIDADPRINCIPAL").ToString)
            Select Case ActividadPrincipal.Length
                Case Is < 46
                    e.Graphics.DrawString(ActividadPrincipal, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 469, PuntoOrigen.Y + 23)
                Case Is < 51
                    e.Graphics.DrawString(ActividadPrincipal, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 469, PuntoOrigen.Y + 25)
                Case Else
                    Cadenas.Add(ActividadPrincipal)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 255, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 255, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 469, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select

            Cadenas.Clear()
            CadenasTotal.Clear()

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40
            Dim FechaAccidente As DateTime = filaReporteInv("FECHAACCIDENTE").ToString
            e.Graphics.DrawString("Fecha del incidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(FechaAccidente.ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 117, PuntoOrigen.Y, PuntoOrigen.X + 117, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Hora del incidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 122, PuntoOrigen.Y + 3)
            Dim HoraAccidente As DateTime
            HoraAccidente = Convert.ToDateTime(filaReporteInv("HORAACCIDENTE").ToString)
            e.Graphics.DrawString(HoraAccidente.ToString("hh:mm tt"), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 127, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 225, PuntoOrigen.Y, PuntoOrigen.X + 225, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Reportado por", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 230, PuntoOrigen.Y + 3)
            Dim Reporta As String = filaReporte24H("PERSONAREPORTA").ToString
            Select Case Reporta.Length
                Case Is < 35
                    e.Graphics.DrawString(Reporta, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 230, PuntoOrigen.Y + 23)
                Case Is < 49
                    e.Graphics.DrawString(Reporta, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 230, PuntoOrigen.Y + 25)
                Case Else
                    Cadenas.Add(Reporta)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 260, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 260, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 230, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select

            Cadenas.Clear()
            CadenasTotal.Clear()
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, PuntoOrigen.Y, PuntoOrigen.X + 490, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 3)
            Dim cargo As String = filaReporte24H("CARGO").ToString
            Select Case cargo.Length
                Case Is < 45
                    e.Graphics.DrawString(cargo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 23)
                Case Else
                    e.Graphics.DrawString(cargo, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 25)
            End Select
            e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40 '300
            e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawString("Día de la semana", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("DIADELACCIDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Jornada de trabajo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("JORNADAHABITUAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 364, PuntoOrigen.Y, PuntoOrigen.X + 364, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Jornada en que sucede", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("JORNADAINCIDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 546, PuntoOrigen.Y, PuntoOrigen.X + 546, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Tiempo laborado en la jornada", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 3)
            Dim HorasLaboradas As String = ""
            If filaReporteInv("HORASLABORADASDIA").ToString <> "" Then
                HorasLaboradas = Convert.ToDateTime(filaReporteInv("HORASLABORADASDIA").ToString).ToString("HH:mm")
            End If

            e.Graphics.DrawString(HorasLaboradas, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 23)

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40 '340
            e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawString("Labor que se desarrollaba", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("OTROTRABAJOHABITUAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 595, PuntoOrigen.Y, PuntoOrigen.X + 595, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("¿Es la labor habitual?", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 600, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("TRABAJOHABITUAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 600, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40 '380
            e.Graphics.DrawString("Zona", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporte24H("ZONAOCURRIO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 55, PuntoOrigen.Y, PuntoOrigen.X + 55, PuntoOrigen.Y + 40)

            e.Graphics.DrawString("Municipio", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 60, PuntoOrigen.Y + 3)
            Dim Municipio As String = Trim(filaReporte24H("MUNICIPIO").ToString)
            Select Case Municipio.Length
                Case Is < 45
                    e.Graphics.DrawString(Municipio, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 62, PuntoOrigen.Y + 23)
                Case Is < 60
                    e.Graphics.DrawString(Municipio, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 62, PuntoOrigen.Y + 25)
                Case Else
                    Cadenas.Add(Municipio)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 335, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 335, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 62, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select

            Cadenas.Clear()
            CadenasTotal.Clear()
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 392, PuntoOrigen.Y, PuntoOrigen.X + 392, PuntoOrigen.Y + 40)


            e.Graphics.DrawString("Departamento", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 397, PuntoOrigen.Y + 3)
            Dim Departamento As String = Trim(filaReporte24H("DEPARTAMENTO").ToString)
            Select Case Departamento.Length
                Case Is < 45
                    e.Graphics.DrawString(Departamento, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 397, PuntoOrigen.Y + 23)
                Case Is < 60
                    e.Graphics.DrawString(Departamento, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 397, PuntoOrigen.Y + 25)
                Case Else
                    Cadenas.Add(Departamento)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 335, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 335, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 397, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
            End Select
            Cadenas.Clear()
            CadenasTotal.Clear()

            e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40 '420
            e.Graphics.DrawString("Lugar de ocurrencia", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("LUGARACCIDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 120, PuntoOrigen.Y, PuntoOrigen.X + 120, PuntoOrigen.Y + 40)


            e.Graphics.DrawString("Sitio específico de ocurrencia", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 3)
            Dim Sitio As String = Replace(Trim(filaReporteInv("SITIOINCIDENTE").ToString), vbLf, "")
            e.Graphics.DrawString(Sitio, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 23)

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 600, PuntoOrigen.Y, PuntoOrigen.X + 600, PuntoOrigen.Y + 40)
            e.Graphics.DrawString("Condición del clima", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 605, PuntoOrigen.Y + 3)
            e.Graphics.DrawString(filaReporteInv("CLIMA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 605, PuntoOrigen.Y + 23)

            e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            ContadorRenglones -= 2

            PuntoOrigen.Y += 40 '460
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("4.   DESCRIPCIÓN DEL INCIDENTE", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            ContadorRenglones -= 1

            PuntoOrigen.Y += 20 '480
            Dim DescripcionIncidente As String = Replace(filaReporteInv("DESCRIPCIONINCIDENTE").ToString, vbLf, "")

            Cadenas.Add(Replace(filaReporteInv("DESCRIPCIONINCIDENTE").ToString.ToLower, vbLf, ""))
            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)

            For j As Integer = 0 To CadenasTotal.Count - 1
                e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, PuntoOrigen.Y + 5)
                If j < CadenasTotal.Count - 1 Then
                    PuntoOrigen.Y += espaciointerlineado
                    ContadorRenglones -= 1
                End If

            Next
            Cadenas.Clear()
            CadenasTotal.Clear()

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
            BloqueContratoADescripcion = True
        End If

        If BloqueLineaTiempo = False Then
            e.Graphics.DrawStringCentered("Linea de tiempo", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            ContadorRenglones -= 1

            PuntoOrigen.Y += 20 '600
            e.Graphics.DrawString("Fecha", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 100, PuntoOrigen.Y, PuntoOrigen.X + 100, PuntoOrigen.Y + 20)

            e.Graphics.DrawString("Hora", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 105, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 20)

            e.Graphics.DrawString("Descripción de los hechos", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            ContadorRenglones -= 1

            PuntoOrigen.Y += 20

            'Se imprime las cadenas faltantes
            Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
            Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

            Dim suma As Integer = 0
            If SubCadenaFaltante.Count > 0 Then
                Dim FilaLineaTiempo As DataRow = dtLineaTiempo.Rows(LTFaltantei - 1)
                Dim Renglones As Integer = 0
                e.Graphics.DrawString(Convert.ToDateTime(FilaLineaTiempo("FECHA").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                e.Graphics.DrawString(Convert.ToDateTime(FilaLineaTiempo("HORA").ToString).ToShortTimeString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 105, InicioYdeLineaTiempo + 3)
                Dim DescripcionLT As String = Replace(FilaLineaTiempo("DESCRIPCION").ToString, vbLf, "")
                Dim otralinea As Integer = 20
                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                For j As Integer = 0 To SubCadenaFaltante.Count - 1
                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 530, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, puntoobservacion + 3)
                        puntoobservacion += otralinea
                        Renglones += 1
                        ContadorRenglones -= 1
                    End If
                Next
                InicioYdeLineaTiempo += Renglones * 20
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 100, InicioYdeLineaTiempo - 20, PuntoOrigen.X + 100, InicioYdeLineaTiempo)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, InicioYdeLineaTiempo - 20, PuntoOrigen.X + 200, InicioYdeLineaTiempo)
                e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo)
                Cadenas.Clear()
                CadenasTotal.Clear()
                SubCadenaFaltante.Clear()
                suma += Renglones * 20
                PuntoOrigen.Y += suma
                Pendientes = False
            End If

            If dtLineaTiempo IsNot Nothing Then
                If dtLineaTiempo.Rows.Count > 0 Then
                    suma = 0
                    For i As Integer = LTFaltantei To dtLineaTiempo.Rows.Count - 1
                        If ContadorRenglones > 0 Then
                            Dim FilaLineaTiempo As DataRow = dtLineaTiempo.Rows(i)
                            Dim Renglones As Integer = 0
                            e.Graphics.DrawString(Convert.ToDateTime(FilaLineaTiempo("FECHA").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                            e.Graphics.DrawString(Convert.ToDateTime(FilaLineaTiempo("HORA").ToString).ToShortTimeString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 105, InicioYdeLineaTiempo + 3)
                            Dim DescripcionLT As String = Replace(FilaLineaTiempo("DESCRIPCION").ToString, vbLf, "")
                            Select Case DescripcionLT.ToString.Length
                                Case Is < 60
                                    e.Graphics.DrawString(DescripcionLT, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, InicioYdeLineaTiempo + 3)
                                    Renglones += 1
                                    ContadorRenglones -= 1
                                    Pendientes = False
                                Case Else
                                    Cadenas.Add(Trim(DescripcionLT))
                                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 530, e)
                                    Dim otralinea As Integer = 20
                                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                    If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                        CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                    End If
                                    For j As Integer = 0 To CadenasTotal.Count - 1
                                        If ContadorRenglones > 0 Then
                                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 530, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, puntoobservacion + 3)
                                            puntoobservacion += otralinea
                                            Renglones += 1
                                            ContadorRenglones -= 1
                                            Pendientes = False
                                        Else
                                            SubCadenaFaltante.Add(CadenasTotal(j))
                                            Pendientes = True
                                        End If
                                    Next
                                    Cadenas.Clear()
                                    CadenasTotal.Clear()
                            End Select

                            If Pendientes = False Then
                                BloqueLineaTiempo = True
                            Else
                                BloqueLineaTiempo = False
                            End If

                            LTFaltantei += 1
                            InicioYdeLineaTiempo += Renglones * 20
                            suma += Renglones * 20
                            If i < dtLineaTiempo.Rows.Count - 1 Then
                                If ContadorRenglones > 0 Then
                                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo)
                                End If
                            End If
                        Else
                            TamañoY = PuntoOrigen.Y - 55
                            If i <= dtLineaTiempo.Rows.Count - 1 Then
                                BloqueLineaTiempo = False
                            End If
                        End If
                    Next
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 100, InicioYdeLineaTiempo2, PuntoOrigen.X + 100, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, InicioYdeLineaTiempo2, PuntoOrigen.X + 200, InicioYdeLineaTiempo)
                    PuntoOrigen.Y += suma

                End If
            Else
                BloqueLineaTiempo = True
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
            End If


        End If

        If BloqueImpresion = 0 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("5.   INFORMACIÓN DEL LESIONADO", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                BloqueImpresion = 1
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 1 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.DrawString("Nombre del lesionado o involucrado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 282, PuntoOrigen.Y, PuntoOrigen.X + 282, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cédula", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 374, PuntoOrigen.Y, PuntoOrigen.X + 374, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Fecha de nacimiento", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 379, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 524, PuntoOrigen.Y, PuntoOrigen.X + 524, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Edad", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 529, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 624, PuntoOrigen.Y, PuntoOrigen.X + 624, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Genero", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 629, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim Lesionado As String = filaReportePersona24H("PERSONAACCIDENTE").ToString
                    Select Case Lesionado.Length
                        Case Is < 35
                            e.Graphics.DrawString(Lesionado, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                        Case Is < 50
                            e.Graphics.DrawString(Lesionado, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                        Case Else
                            Cadenas.Add(Lesionado)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 275, e)
                            Dim otralinea As Integer = 7
                            Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 275, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, puntoobservacion)
                                puntoobservacion += otralinea
                            Next
                    End Select
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    e.Graphics.DrawString(filaReportePersona24H("IDENTIFICACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(Convert.ToDateTime(filaReportePersona24H("FECHANACIMIENTO").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 379, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReportePersona24H("EDAD").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 529, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReportePersona24H("GENERO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 629, PuntoOrigen.Y + 23)

                End If
                BloqueImpresion = 2
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 2 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Fecha de ingreso", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Tipo de Vinculación", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 395, PuntoOrigen.Y, PuntoOrigen.X + 395, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 400, PuntoOrigen.Y + 5)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    e.Graphics.DrawString(Convert.ToDateTime(filaReportePersona24H("FECHAINICIOCONTRATO").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReportePersona24H("TIPOVINCULACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReportePersona24H("CARGO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 400, PuntoOrigen.Y + 23)
                End If
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                BloqueImpresion = 3
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 3 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Experiencia ocupacional", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cargo actual", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 364, PuntoOrigen.Y, PuntoOrigen.X + 364, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Número de dias en el sitio", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 546, PuntoOrigen.Y, PuntoOrigen.X + 546, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Fecha de regreso al trabajo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 3)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim años As Integer = filaReporteInv("AÑOSEXPERIENCIASOCUPACIONAL").ToString
                    Dim stringaños As String = IIf(años = 1, " Año", " Años")
                    Dim meses As Integer = filaReporteInv("MESESEXPERIENCIASOCUPACIONAL").ToString
                    Dim stringmeses As String = IIf((meses) = 1, " Mes", " Meses")
                    Dim exp As String = años.ToString + stringaños + " " + meses.ToString + stringmeses
                    e.Graphics.DrawString(exp, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReportePersona24H("INICIOCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReporteInv("DIASTRABAJANDOSITIO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 369, PuntoOrigen.Y + 23)
                    Dim regreso As String = ""
                    If filaReporteInv("FECHAREGRESOTRABAJO").ToString <> "" Then
                        regreso = Convert.ToDateTime(filaReporteInv("FECHAREGRESOTRABAJO").ToString).ToShortDateString()
                    End If
                    e.Graphics.DrawString(regreso, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 23)
                End If
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                BloqueImpresion = 4
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 4 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Tipo de lesión", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 95, PuntoOrigen.Y, PuntoOrigen.X + 95, PuntoOrigen.Y + 20)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim TipoLesion As String = filaReporteInv("TIPOLESION").ToString
                    If TipoLesion = "Otro tipo lesion" Then
                        TipoLesion += ": " + filaReporteInv("OTROTIPOLESION").ToString
                    End If
                    e.Graphics.DrawString(TipoLesion, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 100, PuntoOrigen.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                BloqueImpresion = 5
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 5 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Parte del cuerpo afectada", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 152, PuntoOrigen.Y, PuntoOrigen.X + 152, PuntoOrigen.Y + 20)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim ParteAfectada As String = filaReporteInv("PARTECUERPOAFECTADA").ToString
                    If ParteAfectada = "Otra parte del cuerpo" Then
                        ParteAfectada += ": " + filaReporteInv("OTRAPARTECUERPOAFECTADA").ToString
                    End If
                    e.Graphics.DrawString(ParteAfectada, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 157, PuntoOrigen.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                BloqueImpresion = 6
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 6 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Agente del accidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 132, PuntoOrigen.Y, PuntoOrigen.X + 132, PuntoOrigen.Y + 20)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim AgenteAccidente As String = filaReporteInv("AGENTEACCIDENTE").ToString
                    If AgenteAccidente = "Otro agente accidente" Then
                        AgenteAccidente += ": " + filaReporteInv("OTROAGENTEACCIDENTE").ToString
                    End If
                    e.Graphics.DrawString(AgenteAccidente, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 137, PuntoOrigen.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                BloqueImpresion = 7
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If
        If BloqueImpresion = 7 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Mecanismos o forma del accidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 197, PuntoOrigen.Y, PuntoOrigen.X + 197, PuntoOrigen.Y + 20)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim Mecanismo As String = filaReporteInv("MECANISMO").ToString
                    If Mecanismo = "Otro mecanismo accidente" Then
                        Mecanismo += ": " + filaReporteInv("OTROMECANISMO").ToString
                    End If
                    e.Graphics.DrawString(Mecanismo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 202, PuntoOrigen.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                BloqueImpresion = 8
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 8 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Atención inmediata suministrada", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 190, PuntoOrigen.Y, PuntoOrigen.X + 190, PuntoOrigen.Y + 20)
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim AtencionInmediata As String = filaReportePersona24H("TIPOATENCIONINMEDIATA").ToString
                    If AtencionInmediata = "Traslado a centro de Atención" Then
                        AtencionInmediata += ": " + filaReportePersona24H("TRASLADO").ToString
                    End If
                    e.Graphics.DrawString(AtencionInmediata, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 195, PuntoOrigen.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                BloqueImpresion = 9
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 9 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawStringCentered("Comentarios del Médico/Enfermero", Formato_Etiqueta_8, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim Comentario As String = Replace(filaReporteInv("COMENTARIOMEDICO").ToString, vbLf, "")
                    If Trim(Comentario) <> "" Then
                        Cadenas.Add(Comentario)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If

                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresion = 9
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 10
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 10 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.DrawString("Nombre", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 272, PuntoOrigen.Y, PuntoOrigen.X + 272, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 277, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 444, PuntoOrigen.Y, PuntoOrigen.X + 444, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Hora", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 449, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 514, PuntoOrigen.Y, PuntoOrigen.X + 514, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Fecha", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 519, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 584, PuntoOrigen.Y, PuntoOrigen.X + 584, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Firma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 589, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                    Dim Medico As String = filaReporteInv("MEDICO").ToString
                    Select Case Medico.Length
                        Case Is < 35
                            e.Graphics.DrawString(Medico, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                        Case Is < 50
                            e.Graphics.DrawString(Medico, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                        Case Else
                            Cadenas.Add(Medico)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 265, e)
                            Dim otralinea As Integer = 7
                            Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 265, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, puntoobservacion)
                                puntoobservacion += otralinea
                            Next
                    End Select
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    Dim CargoMedico As String = filaReporteInv("CARGOMEDICO").ToString
                    Select Case CargoMedico.Length
                        Case Is < 30
                            e.Graphics.DrawString(CargoMedico, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 277, PuntoOrigen.Y + 23)
                        Case Is < 40
                            e.Graphics.DrawString(CargoMedico, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 272, PuntoOrigen.Y + 23)
                        Case Else
                            Cadenas.Add(CargoMedico)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 172, e)
                            Dim otralinea As Integer = 7
                            Dim puntoobservacion As Integer = PuntoOrigen.Y + 21
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 172, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 272, puntoobservacion)
                                puntoobservacion += otralinea
                            Next
                    End Select
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    Dim hora As String = ""
                    If filaReporteInv("HORAATENCION").ToString <> "" Then
                        hora = Convert.ToDateTime(filaReporteInv("HORAATENCION").ToString).ToShortTimeString
                    End If

                    e.Graphics.DrawString(hora, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 449, PuntoOrigen.Y + 23)
                    Dim fecha As String = ""
                    If filaReporteInv("FECHAATENCION").ToString <> "" Then
                        fecha = Convert.ToDateTime(filaReporteInv("FECHAATENCION").ToString).ToShortDateString
                    End If
                    e.Graphics.DrawString(fecha, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 519, PuntoOrigen.Y + 23)

                End If
                BloqueImpresion = 11
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 11 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("6.   INFORMACIÓN DE LA AFECTACIÓN AMBIENTAL", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                BloqueImpresion = 12
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 12 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Sustancia/Elemento involucrado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 282, PuntoOrigen.Y, PuntoOrigen.X + 282, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Unidad", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 340, PuntoOrigen.Y, PuntoOrigen.X + 340, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cantidad", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Afectación", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 405, PuntoOrigen.Y + 3)
                If filaReporte24H("TIPOINCIDENTE") = "Ambiental" Then
                    e.Graphics.DrawString(filaReporteInv("SUSTANCIA_PROCESO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReporteInv("UNIDAD").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 287, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReporteInv("CANTIDAD").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(Replace(filaReporteInv("OBSERVACION").ToString, vbLf, ""), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 405, PuntoOrigen.Y + 23)
                End If
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                BloqueImpresion = 13
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 13 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Nombre del involucrado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 340, PuntoOrigen.Y, PuntoOrigen.X + 340, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                If filaReporte24H("TIPOINCIDENTE") = "Ambiental" Then
                    e.Graphics.DrawString(filaReporteInv("INVOLUCRADO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReporteInv("CARGOINVOLUCRADO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 23)
                End If
                BloqueImpresion = 14
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 14 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawStringCentered("Atención prestada", Formato_Etiqueta_8, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim AtencionPrestada As String = Replace(filaReporteInv("RESUMENATENCIONPRESTADA").ToString, vbLf, "")
                    If filaReporte24H("TIPOINCIDENTE") = "Ambiental" Then
                        If Trim(AtencionPrestada) <> "" Then
                            Cadenas.Add(AtencionPrestada)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                            Dim Renglones As Integer = 0
                            Dim otralinea As Integer = 20
                            Dim puntoobservacion As Integer = PuntoOrigen.Y
                            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                            End If
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                If ContadorRenglones > 0 Then
                                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                    puntoobservacion += otralinea
                                    ContadorRenglones -= 1
                                    Renglones += 1
                                Else
                                    SubCadenaFaltante.Add(CadenasTotal(i))
                                End If

                            Next
                            suma += Renglones * 20
                            Cadenas.Clear()
                            CadenasTotal.Clear()
                            BloqueImpresion = 14
                            PuntoOrigen.Y += suma
                        Else
                            PuntoOrigen.Y += 20
                            ContadorRenglones -= 1
                        End If
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 15
                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    End If
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If


        If BloqueImpresion = 15 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("7.   INFORMACIÓN DE PERDIDAS O DAÑOS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                BloqueImpresion = 16
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 16 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Proceso afectado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 340, PuntoOrigen.Y, PuntoOrigen.X + 340, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Daño generado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 3)
                If filaReporte24H("TIPOINCIDENTE") = "Seguridad" Then
                    e.Graphics.DrawString(filaReporteInv("SUSTANCIA_PROCESO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(Replace(filaReporteInv("OBSERVACION").ToString, vbLf, ""), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 23)
                End If
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                BloqueImpresion = 17
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 17 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Nombre del involucrado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 340, PuntoOrigen.Y, PuntoOrigen.X + 340, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                If filaReporte24H("TIPOINCIDENTE") = "Seguridad" Then
                    e.Graphics.DrawString(filaReporteInv("INVOLUCRADO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                    e.Graphics.DrawString(filaReporteInv("CARGOINVOLUCRADO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 345, PuntoOrigen.Y + 23)
                End If
                BloqueImpresion = 18
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 18 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawStringCentered("Atención prestada", Formato_Etiqueta_8, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim AtencionPrestada As String = Replace(filaReporteInv("RESUMENATENCIONPRESTADA").ToString, vbLf, "")
                    If filaReporte24H("TIPOINCIDENTE") = "Seguridad" Then
                        If Trim(AtencionPrestada) <> "" Then
                            Cadenas.Add(AtencionPrestada)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                            Dim Renglones As Integer = 0
                            Dim otralinea As Integer = 20
                            Dim puntoobservacion As Integer = PuntoOrigen.Y
                            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                            End If
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                If ContadorRenglones > 0 Then
                                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                    puntoobservacion += otralinea
                                    ContadorRenglones -= 1
                                    Renglones += 1
                                Else
                                    SubCadenaFaltante.Add(CadenasTotal(i))
                                End If

                            Next
                            suma += Renglones * 20
                            Cadenas.Clear()
                            CadenasTotal.Clear()
                            PuntoOrigen.Y += suma

                            BloqueImpresion = 18
                        Else
                            PuntoOrigen.Y += 20
                            ContadorRenglones -= 1
                        End If
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 19
                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    End If
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 19 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("8.   VALORACIÓN DEL INCIDENTE - PÉRDIDAS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                BloqueImpresion = 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 20 Then
            If ContadorRenglones >= 3 Then

                e.Graphics.DrawString("8.1  Pérdida potencial", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                Dim TipoPerdida As String
                If filaReporte24H("TIPOINCIDENTE").ToString = "Salud" Then
                    TipoPerdida = "Afectación personal"
                Else
                    If filaReporte24H("TIPOINCIDENTE").ToString = "Seguridad" Then
                        TipoPerdida = "Daño a propiedad"
                    Else
                        If filaReporte24H("TIPOINCIDENTE").ToString = "Ambiental" Then
                            TipoPerdida = "Afectación ambiental"
                        Else
                            TipoPerdida = ""
                        End If
                    End If
                End If
                e.Graphics.DrawString("Tipo de perdida", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawString(TipoPerdida, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 222, PuntoOrigen.Y, PuntoOrigen.X + 222, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Categoria resultante", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 227, PuntoOrigen.Y + 3)
                e.Graphics.DrawString(filaReporteInv("CATEGORIAPERDIDAPOTENCIAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 227, PuntoOrigen.Y + 23)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 250, PuntoOrigen.Y + 20, PuntoOrigen.X + 250, PuntoOrigen.Y + 40)
                e.Graphics.DrawString(filaReporteInv("NOMBREMATRIZPERDIDA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 23)

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 566, PuntoOrigen.Y, PuntoOrigen.X + 566, PuntoOrigen.Y + 40)
                e.Graphics.DrawString("Potencial", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 571, PuntoOrigen.Y + 3)
                e.Graphics.DrawString(filaReporteInv("NIVELPERDIDAPOTENCIAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 571, PuntoOrigen.Y + 23)

                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
                BloqueImpresion = 21
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If


        If BloqueImpresion = 21 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("8.2  ¿Cuál pudo haber sido la peor consecuencia de este evento?", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 5)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim PeorConsecuencia As String = Replace(filaReporteInv("PEORCONSECUENCIA").ToString, vbLf, "")
                    If Trim(PeorConsecuencia) <> "" Then
                        Cadenas.Add(PeorConsecuencia)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If

                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresion = 21
                        PuntoOrigen.Y += suma
                    Else
                        ContadorRenglones -= 1
                        PuntoOrigen.Y += 20
                    End If

                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 22
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If


        If BloqueImpresion = 22 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("8.3  Costos estimados del incidente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Especificar", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                BloqueImpresion = 23
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        Dim TotalCostosIncidente As Decimal = 0
        If BloqueImpresion = 23 Then
            If ContadorRenglones > 0 Then
                If filaReporte24H("TIPOINCIDENTE").ToString = "Salud" Then
                    e.Graphics.DrawString("Lesión", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                    TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSDAÑOS")), 0, filaReporteInv("COSTOSDAÑOS").ToString))
                    e.Graphics.DrawString("$" + filaReporteInv("COSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                    e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                Else
                    If filaReporte24H("TIPOINCIDENTE").ToString = "Seguridad" Then
                        e.Graphics.DrawString("Daños a la propiedad", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                        TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSDAÑOS")), 0, filaReporteInv("COSTOSDAÑOS").ToString))
                        e.Graphics.DrawString("$" + filaReporteInv("COSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                        e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    Else
                        If filaReporte24H("TIPOINCIDENTE").ToString = "Ambiental" Then
                            e.Graphics.DrawString("Daños al ambiente", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                            TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSDAÑOS")), 0, filaReporteInv("COSTOSDAÑOS").ToString))
                            e.Graphics.DrawString("$" + filaReporteInv("COSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                            e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                            PuntoOrigen.Y += 20
                            ContadorRenglones -= 1
                        End If
                    End If
                End If
                BloqueImpresion = 24
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 24 Then
            If ContadorRenglones > 0 Then
                If filaReporte24H("TIPOINCIDENTE").ToString = "Seguridad" Then
                    e.Graphics.DrawString("Reparaciones", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                    TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSREPARACIONES")), 0, filaReporteInv("COSTOSREPARACIONES").ToString))
                    e.Graphics.DrawString("$" + filaReporteInv("COSTOSREPARACIONES").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                    e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSREPARACIONES").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                Else
                    If filaReporte24H("TIPOINCIDENTE").ToString = "Ambiental" Then
                        e.Graphics.DrawString("Perdida del producto", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                        TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSPERDIDA")), 0, filaReporteInv("COSTOSPERDIDA").ToString))
                        e.Graphics.DrawString("$" + filaReporteInv("COSTOSPERDIDA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                        e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSPERDIDA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                BloqueImpresion = 25
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If


        End If

        If BloqueImpresion = 25 Then
            If ContadorRenglones > 0 Then
                If filaReporte24H("TIPOINCIDENTE").ToString = "Ambiental" Then
                    e.Graphics.DrawString("Reparaciones", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                    TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSREPARACIONES")), 0, filaReporteInv("COSTOSREPARACIONES").ToString))
                    e.Graphics.DrawString("$" + filaReporteInv("COSTOSREPARACIONES").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                    e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSDAÑOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                End If
                BloqueImpresion = 26
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If

        End If

        If BloqueImpresion = 26 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Investigación", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSINVESTIGACION")), 0, filaReporteInv("COSTOSINVESTIGACION").ToString))
                e.Graphics.DrawString("$" + filaReporteInv("COSTOSINVESTIGACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSINVESTIGACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 27
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 27 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Otros", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("OTROSCOSTOS")), 0, filaReporteInv("OTROSCOSTOS").ToString))
                e.Graphics.DrawString("$" + filaReporteInv("OTROSCOSTOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaReporteInv("DESCRIPCIONOTROSCOSTOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 28
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 28 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Acciones correctivas", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                TotalCostosIncidente += Convert.ToDecimal(IIf(IsDBNull(filaReporteInv("COSTOSACCIONESCORRECTIVAS")), 0, filaReporteInv("COSTOSACCIONESCORRECTIVAS").ToString))
                e.Graphics.DrawString("$" + filaReporteInv("COSTOSACCIONESCORRECTIVAS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaReporteInv("DESCRIPCIONCOSTOSACCIONESCORRECTIVAS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 300, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 29
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 29 Then
            If ContadorRenglones > 0 Then
                e.Graphics.DrawString("Total", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 145, PuntoOrigen.Y, PuntoOrigen.X + 145, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("$" + TotalCostosIncidente.ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 150, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 295, PuntoOrigen.Y, PuntoOrigen.X + 295, PuntoOrigen.Y + 20)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 30
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 30 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("8.4  Pérdida real del evento", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                BloqueImpresion = 31
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 31 Then
            If ContadorRenglones > 0 Then
                If filaReporte24H("TIPOINCIDENTE").ToString <> "Casi-Accidente" Then
                    e.Graphics.DrawString(filaReporteInv("CATEGORIAPERDIDAREAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                    e.Graphics.DrawString("Categoria resultante: " + filaReporteInv("PERDIDAREAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 55, PuntoOrigen.Y + 3)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 50, PuntoOrigen.Y, PuntoOrigen.X + 50, PuntoOrigen.Y + 20)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                BloqueImpresion = 32
                PuntoOrigen.Y += 20
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If


        If BloqueImpresion = 32 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("9.   TESTIGOS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1

                PuntoOrigen.Y += 20 '600
                e.Graphics.DrawString("Nombre", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 20)

                e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)

                e.Graphics.DrawString("Observaciones", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 405, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                'Se imprime las cadenas faltantes
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                Dim suma As Integer = 0
                If SubCadenaFaltante.Count > 0 Then
                    Dim FilaTestigos As DataRow = dtTestigos.Rows(TestigosFaltantei - 1)
                    Dim Renglones As Integer = 0
                    Dim NombreTestigo As String = FilaTestigos("Nombre").ToString
                    Select Case NombreTestigo.Length
                        Case Is < 26
                            e.Graphics.DrawString(NombreTestigo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                        Case Is < 40
                            e.Graphics.DrawString(NombreTestigo, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                        Case Else
                            Cadenas.Add(NombreTestigo)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 330, e)
                            Dim otralinea1 As Integer = 7
                            Dim puntoobservacion1 As Integer = PuntoOrigen.Y + 1
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 330, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, puntoobservacion1)
                                puntoobservacion1 += otralinea1
                            Next
                    End Select
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    Dim CargoTestigo As String = FilaTestigos("Cargo").ToString
                    Select Case CargoTestigo.Length
                        Case Is < 26
                            e.Graphics.DrawString(CargoTestigo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, InicioYdeLineaTiempo + 3)
                        Case Is < 40
                            e.Graphics.DrawString(CargoTestigo, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 205, InicioYdeLineaTiempo + 3)
                        Case Else
                            Cadenas.Add(CargoTestigo)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 330, e)
                            Dim otralinea2 As Integer = 7
                            Dim puntoobservacion2 As Integer = PuntoOrigen.Y + 1
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 330, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 205, puntoobservacion2)
                                puntoobservacion2 += otralinea2
                            Next
                    End Select
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    Dim DescripcionLT As String = Replace(FilaTestigos("DESCRIPCION").ToString, vbLf, "")
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 330, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 405, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, InicioYdeLineaTiempo - 20, PuntoOrigen.X + 200, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, InicioYdeLineaTiempo - 20, PuntoOrigen.X + 400, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo)
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If
                If dtTestigos IsNot Nothing Then
                    If dtTestigos.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = TestigosFaltantei To dtTestigos.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaTestigos As DataRow = dtTestigos.Rows(k)
                                Dim Renglones As Integer = 0
                                Dim NombreTestigo As String = FilaTestigos("Nombre").ToString
                                Select Case NombreTestigo.Length
                                    Case Is < 26
                                        e.Graphics.DrawString(NombreTestigo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                    Case Is < 40
                                        e.Graphics.DrawString(NombreTestigo, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                    Case Else
                                        Cadenas.Add(NombreTestigo)
                                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 330, e)
                                        Dim otralinea As Integer = 7
                                        Dim puntoobservacion As Integer = PuntoOrigen.Y + 1
                                        For i As Integer = 0 To CadenasTotal.Count - 1
                                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 330, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, puntoobservacion)
                                            puntoobservacion += otralinea
                                        Next
                                End Select
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                Dim CargoTestigo As String = FilaTestigos("Cargo").ToString
                                Select Case CargoTestigo.Length
                                    Case Is < 26
                                        e.Graphics.DrawString(CargoTestigo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, InicioYdeLineaTiempo + 3)
                                    Case Is < 40
                                        e.Graphics.DrawString(CargoTestigo, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 205, InicioYdeLineaTiempo + 3)
                                    Case Else
                                        Cadenas.Add(CargoTestigo)
                                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 330, e)
                                        Dim otralinea As Integer = 7
                                        Dim puntoobservacion As Integer = PuntoOrigen.Y + 1
                                        For i As Integer = 0 To CadenasTotal.Count - 1
                                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 330, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 205, puntoobservacion)
                                            puntoobservacion += otralinea
                                        Next
                                End Select
                                Cadenas.Clear()
                                CadenasTotal.Clear()
                                Dim DescripcionLT As String = ""
                                DescripcionLT = Replace(FilaTestigos("DESCRIPCION").ToString, vbLf, "")
                                Select Case DescripcionLT.Length
                                    Case Is < 60
                                        e.Graphics.DrawString(DescripcionLT, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 405, InicioYdeLineaTiempo + 3)
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Case Else
                                        Cadenas.Add(Trim(DescripcionLT))
                                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 330, e)
                                        Dim otralinea As Integer = 20
                                        Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                        End If
                                        For j As Integer = 0 To CadenasTotal.Count - 1
                                            If ContadorRenglones > 0 Then
                                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 330, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 405, puntoobservacion + 3)
                                                puntoobservacion += otralinea
                                                Renglones += 1
                                                ContadorRenglones -= 1
                                                Pendientes = False
                                            Else
                                                SubCadenaFaltante.Add(CadenasTotal(j))
                                                Pendientes = True
                                            End If
                                        Next
                                        Cadenas.Clear()
                                        CadenasTotal.Clear()
                                End Select

                                If Pendientes = False Then
                                    BloqueImpresion = 33
                                Else
                                    BloqueImpresion = 32
                                End If

                                TestigosFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20
                                suma += Renglones * 20
                                If k < dtTestigos.Rows.Count - 1 Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo)
                                    End If
                                End If

                            Else
                                If k <= dtTestigos.Rows.Count - 1 Then
                                    BloqueImpresion = 32
                                End If
                            End If
                        Next
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, InicioYdeLineaTiempo2, PuntoOrigen.X + 200, InicioYdeLineaTiempo)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, InicioYdeLineaTiempo2, PuntoOrigen.X + 400, InicioYdeLineaTiempo)
                        PuntoOrigen.Y += suma
                    Else
                        BloqueImpresion = 33
                    End If
                Else
                    BloqueImpresion = 33
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If


        If BloqueImpresion = 33 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("10.   IDENTIFICACIÓN DE PELIGROS Y ASPECTOS AMBIENTALES", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                Dim Pregunta1 As String = ""
                Dim TipoIncidente As String = filaReporte24H("TIPOINCIDENTE").ToString
                If filaReporte24H("TIPOINCIDENTE").ToString = "Seguridad" Or filaReporte24H("TIPOINCIDENTE").ToString = "Salud" Or filaReporte24H("TIPOINCIDENTE").ToString = "Casi-Accidente" Then
                    Pregunta1 = "¿Indicar si hay deficiencias en la identificación de peligros, evaluación de riesgos, e implementación de controles?"
                Else
                    If filaReporte24H("TIPOINCIDENTE").ToString = "Ambiental" Then
                        Pregunta1 = "¿Indicar si hay deficiencias en la identificación, evaluación de aspectos ambientales, e implementación de controles?"
                    End If
                End If

                e.Graphics.DrawString(Pregunta1, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                Dim Respuesta As String = Replace(filaReporteInv("RESPUESTA10_1").ToString, vbLf, "")
                Dim RtaSiNo As String = Replace(filaReporteInv("RESPUESTA10_1_SI_NO").ToString, vbLf, "")
                Dim Rta As String = ""
                If Trim(RtaSiNo) = "S" Then
                    Rta = "Si ¿Cuáles Fueron? " + Respuesta
                Else
                    If Trim(RtaSiNo) = "N" Then
                        Rta = "No ¿Cuáles Fueron? " + Respuesta
                    End If
                End If
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawString(Rta, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
                BloqueImpresion = 34
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 34 Then
            If ContadorRenglones >= 2 Then
                Dim Pregunta2 As String = "¿Se habían identificado conductas o condiciones riesgosas previas o durante el incidente?"
                e.Graphics.DrawString(Pregunta2, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                Dim Respuesta As String = Replace(filaReporteInv("RESPUESTA10_2").ToString, vbLf, "")
                Dim RtaSiNo As String = Replace(filaReporteInv("RESPUESTA10_2_SI_NO").ToString, vbLf, "")
                Dim Rta As String = ""
                If Trim(RtaSiNo) = "S" Then
                    Rta = "Si ¿Dónde se identificaron y cómo se divulgaron? " + Respuesta
                Else
                    If Trim(RtaSiNo) = "N" Then
                        Rta = "No ¿Dónde se identificaron y cómo se divulgaron?" + Respuesta
                    End If
                End If
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                e.Graphics.DrawString(Rta, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 23)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
                ContadorRenglones -= 2
                PuntoOrigen.Y += 40
                BloqueImpresion = 36
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 36 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("11.   EVIDENCIAS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                BloqueImpresion = 37
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 37 Then
            If ContadorRenglones > 0 Then
                'Se imprime las cadenas faltantes
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                Dim suma As Integer = 0
                If SubCadenaFaltante.Count > 0 Then
                    Dim FilaEvidencias As DataRow = dtEvidencias.Rows(EvidenciasFaltantei - 1)
                    Dim Renglones As Integer = 0
                    e.Graphics.DrawString(FilaEvidencias("NOMBRETIPOEVIDENCIAYCAUSA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                    Dim Evidencia As String = Replace(FilaEvidencias("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Evidencia)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 530, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigen.Y + 1
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 530, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 65, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 60, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 60, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If

                If dtEvidencias IsNot Nothing Then
                    If dtEvidencias.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = EvidenciasFaltantei To dtEvidencias.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaEvidencias As DataRow = dtEvidencias.Rows(k)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString(FilaEvidencias("NOMBRETIPOEVIDENCIAYCAUSA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                Dim Evidencia As String = Replace(FilaEvidencias("DESCRIPCION").ToString, vbLf, "")

                                Cadenas.Add(Evidencia)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 530, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 530, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 65, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltante.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresion = 38
                                Else
                                    BloqueImpresion = 37
                                End If

                                EvidenciasFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20
                                suma += Renglones * 20
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 60, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 60, InicioYdeLineaTiempo)

                                If k < dtEvidencias.Rows.Count - 1 Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                                    End If
                                End If

                            Else
                                If k <= dtEvidencias.Rows.Count - 1 Then
                                    BloqueImpresion = 37
                                End If
                            End If
                        Next

                        PuntoOrigen.Y += suma
                    End If
                Else
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                    BloqueImpresion = 38
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 38 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("12.   ANÁLISIS DE CAUSAS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                BloqueImpresion = 39
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 39 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("12.1   Causas inmediatas", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, PuntoOrigen.Y, PuntoOrigen.X + 360, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Descripción", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 365, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                Dim suma As Integer = 0
                If SubCadenaFaltante.Count > 0 Then
                    Dim FilaCausas As DataRow = dtCausasActos.Rows(CausasActosFaltantei - 1)
                    Dim Renglones As Integer = 0
                    e.Graphics.DrawString("Acto Inseguro", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                    Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                    Select Case TipoCausa.Length
                        Case Is < 43
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 51
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 61
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                    End Select

                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigen.Y + 1
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                    End If

                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If

                If dtCausasActos IsNot Nothing Then
                    If dtCausasActos.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = CausasActosFaltantei To dtCausasActos.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaCausas As DataRow = dtCausasActos.Rows(k)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString("Acto Inseguro", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                                Select Case TipoCausa.Length
                                    Case Is < 43
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 51
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 61
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                End Select

                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltante.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresion = 40
                                Else
                                    BloqueImpresion = 39
                                End If

                                CausasActosFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20
                                suma += Renglones * 20
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                                If k < dtCausasActos.Rows.Count Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                                    End If
                                End If
                            Else
                                If k <= dtCausasActos.Rows.Count - 1 Then
                                    BloqueImpresion = 39
                                End If
                            End If
                        Next

                        PuntoOrigen.Y += suma
                    End If
                Else
                    BloqueImpresion = 40
                    'PuntoOrigen.Y += 20
                    EspacioCausalidad += 1
                    'ContadorRenglones -= 1
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 40 Then
            If ContadorRenglones >= 2 Then
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y
                Dim suma As Integer = 0

                If SubCadenaFaltante.Count > 0 Then
                    e.Graphics.DrawString("12.1   Causas inmediatas", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, PuntoOrigen.Y, PuntoOrigen.X + 360, PuntoOrigen.Y + 20)
                    e.Graphics.DrawString("Descripción", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 365, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1

                    Dim FilaCausas As DataRow = dtCausasCondiciones.Rows(CausasCondicionesFaltantei - 1)
                    Dim Renglones As Integer = 0
                    e.Graphics.DrawString("Condición Insegura", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                    Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                    Select Case TipoCausa.Length
                        Case Is < 43
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 51
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 61
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                    End Select

                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigen.Y + 1
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                    End If

                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If
                If dtCausasCondiciones IsNot Nothing Then
                    If dtCausasCondiciones.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = CausasCondicionesFaltantei To dtCausasCondiciones.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaCausas As DataRow = dtCausasCondiciones.Rows(k)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString("Condicion Insegura", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                                Select Case TipoCausa.Length
                                    Case Is < 43
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 51
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 61
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                End Select

                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltante.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresion = 41
                                Else
                                    BloqueImpresion = 40
                                End If

                                CausasCondicionesFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20
                                suma += Renglones * 20
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)
                                If k < dtCausasCondiciones.Rows.Count - 1 Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                                    End If
                                End If
                            Else
                                If k <= dtCausasCondiciones.Rows.Count - 1 Then
                                    BloqueImpresion = 40
                                End If
                            End If
                        Next

                        PuntoOrigen.Y += suma
                    End If
                Else
                    'PuntoOrigen.Y += 20
                    'ContadorRenglones -= 1
                    EspacioCausalidad += 1
                    BloqueImpresion = 41
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 41 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.DrawString("12.1   Causas básicas", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, PuntoOrigen.Y, PuntoOrigen.X + 360, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Descripción", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 365, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                Dim suma As Integer = 0
                If SubCadenaFaltante.Count > 0 Then
                    Dim FilaCausas As DataRow = dtCausasPersonales.Rows(CausasPersonalesFaltantei - 1)
                    Dim Renglones As Integer = 0
                    e.Graphics.DrawString("Factor personal", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                    Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                    Select Case TipoCausa.Length
                        Case Is < 43
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 51
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 61
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                    End Select

                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigen.Y + 1
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                    End If

                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If

                If dtCausasPersonales IsNot Nothing Then
                    If dtCausasPersonales.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = CausasPersonalesFaltantei To dtCausasPersonales.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaCausas As DataRow = dtCausasPersonales.Rows(k)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString("Factor personal", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                                Select Case TipoCausa.Length
                                    Case Is < 43
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 51
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 61
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                End Select

                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltante.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresion = 42
                                Else
                                    BloqueImpresion = 41
                                End If

                                CausasPersonalesFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20
                                suma += Renglones * 20
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                                If k < dtCausasPersonales.Rows.Count Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                                    End If
                                End If
                            Else
                                If k <= dtCausasPersonales.Rows.Count - 1 Then
                                    BloqueImpresion = 41
                                End If
                            End If
                        Next

                        PuntoOrigen.Y += suma
                    End If
                Else
                    'PuntoOrigen.Y += 20
                    'ContadorRenglones -= 1
                    EspacioCausalidad += 1
                    BloqueImpresion = 42
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 42 Then
            If ContadorRenglones >= 2 Then
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim suma As Integer = 0

                If SubCadenaFaltante.Count > 0 Then
                    e.Graphics.DrawString("12.1   Causas básicas", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, PuntoOrigen.Y, PuntoOrigen.X + 360, PuntoOrigen.Y + 20)
                    e.Graphics.DrawString("Descripción", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 365, PuntoOrigen.Y + 3)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1

                    Dim FilaCausas As DataRow = dtCausasTrabajo.Rows(CausasTrabajoFaltantei - 1)
                    Dim Renglones As Integer = 0
                    e.Graphics.DrawString("Factor del trabajo", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                    Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                    Select Case TipoCausa.Length
                        Case Is < 43
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 51
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                        Case Is < 61
                            e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                    End Select

                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigen.Y + 1
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa

                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If

                If dtCausasTrabajo IsNot Nothing Then
                    If dtCausasTrabajo.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = CausasTrabajoFaltantei To dtCausasTrabajo.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaCausas As DataRow = dtCausasTrabajo.Rows(k)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString("Factor del trabajo", Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                                Dim TipoCausa As String = FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString
                                Select Case TipoCausa.Length
                                    Case Is < 43
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 51
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                    Case Is < 61
                                        e.Graphics.DrawString(TipoCausa, Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 115, InicioYdeLineaTiempo + 3)
                                End Select

                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 300, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltante.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresion = 43
                                Else
                                    BloqueImpresion = 42
                                End If

                                CausasTrabajoFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20
                                suma += Renglones * 20
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 110, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 110, InicioYdeLineaTiempo)
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, InicioYdeLineaTiempo - suma, PuntoOrigen.X + 360, InicioYdeLineaTiempo)

                                If k < dtCausasTrabajo.Rows.Count - 1 Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo) 'Horizontal completa
                                    End If
                                End If
                            Else
                                If k <= dtCausasTrabajo.Rows.Count - 1 Then
                                    BloqueImpresion = 42
                                End If
                            End If
                        Next

                        PuntoOrigen.Y += suma
                    End If
                Else
                    'PuntoOrigen.Y += 20
                    'ContadorRenglones -= 1
                    If EspacioCausalidad = 3 Then
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                    BloqueImpresion = 43
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 43 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("13.   PLAN DE ACCIÓN", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1

                PuntoOrigen.Y += 20

                e.Graphics.DrawString("No.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 1, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 25, PuntoOrigen.Y, PuntoOrigen.X + 25, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Acción".ToString, Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 30, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 260, PuntoOrigen.Y, PuntoOrigen.X + 260, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Cargo del responsable", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 265, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, PuntoOrigen.Y, PuntoOrigen.X + 490, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Prioridad", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 495, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, PuntoOrigen.Y, PuntoOrigen.X + 550, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Fecha límite", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 555, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 630, PuntoOrigen.Y, PuntoOrigen.X + 630, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Fecha terminado", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 635, PuntoOrigen.Y + 3)
                ContadorRenglones -= 1

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa

                PuntoOrigen.Y += 20

                'Se imprime las cadenas faltantes
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                Dim suma As Integer = 0
                If SubCadenaFaltante.Count > 0 Then
                    Dim FilaAcciones As DataRow = dtAcciones.Rows(AccionesFaltantei - 1)
                    Dim Renglones As Integer = 0

                    e.Graphics.DrawString(AccionesFaltantei, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 215, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 30, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next

                    Dim Nombre As String = Replace(FilaAcciones("NOMBRE").ToString, vbLf, "")
                    Select Case Nombre.Length
                        Case Is < 30
                            e.Graphics.DrawString(Nombre, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 265, InicioYdeLineaTiempo + 3)
                        Case Is < 49
                            e.Graphics.DrawString(Nombre, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 265, InicioYdeLineaTiempo + 3)
                        Case Else
                            Cadenas.Add(Nombre)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 330, e)
                            Dim otralinea1 As Integer = 7
                            Dim puntoobservacion1 As Integer = PuntoOrigen.Y + 1
                            For i As Integer = 0 To CadenasTotal.Count - 1
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 330, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 265, puntoobservacion1)
                                puntoobservacion1 += otralinea1
                            Next
                    End Select
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    e.Graphics.DrawString(FilaAcciones("PRIORIDAD").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 495, InicioYdeLineaTiempo + 3)

                    Dim fechalimite As String = ""
                    If FilaAcciones("FECHALIMITE").ToString <> "" Then
                        fechalimite = Convert.ToDateTime(FilaAcciones("FECHALIMITE").ToString).ToShortDateString()
                    End If

                    e.Graphics.DrawString(fechalimite, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 555, InicioYdeLineaTiempo + 3)

                    Dim fechaterminado As String = ""
                    If FilaAcciones("FECHATERMINADO").ToString <> "" Then
                        fechaterminado = Convert.ToDateTime(FilaAcciones("FECHATERMINADO").ToString).ToShortDateString()
                    End If
                    e.Graphics.DrawString(fechaterminado, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 635, InicioYdeLineaTiempo + 3)

                    InicioYdeLineaTiempo += Renglones * 20

                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 25, InicioYdeLineaTiempo2, PuntoOrigen.X + 25, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 260, InicioYdeLineaTiempo2, PuntoOrigen.X + 260, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, InicioYdeLineaTiempo2, PuntoOrigen.X + 490, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, InicioYdeLineaTiempo2, PuntoOrigen.X + 550, InicioYdeLineaTiempo)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 630, InicioYdeLineaTiempo2, PuntoOrigen.X + 630, InicioYdeLineaTiempo)

                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo)

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                    Pendientes = False
                End If

                If dtAcciones IsNot Nothing Then
                    If dtAcciones.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = AccionesFaltantei To dtAcciones.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaAcciones As DataRow = dtAcciones.Rows(k)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString(k + 1, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYdeLineaTiempo + 3)

                                Dim Accion As String = Replace(FilaAcciones("ACCION").ToString, vbLf, "")

                                Cadenas.Add(Accion)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 215, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 215, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 30, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglones -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltante.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                Dim Nombre As String = Replace(FilaAcciones("NOMBRE").ToString, vbLf, "")
                                Select Case Nombre.Length
                                    Case Is < 30
                                        e.Graphics.DrawString(Nombre, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 265, InicioYdeLineaTiempo + 3)
                                    Case Is < 49
                                        e.Graphics.DrawString(Nombre, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 265, InicioYdeLineaTiempo + 3)
                                    Case Else
                                        Cadenas.Add(Nombre)
                                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 330, e)
                                        Dim otralinea1 As Integer = 7
                                        Dim puntoobservacion1 As Integer = PuntoOrigen.Y + 1
                                        For i As Integer = 0 To CadenasTotal.Count - 1
                                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 330, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 265, puntoobservacion1)
                                            puntoobservacion1 += otralinea1
                                        Next
                                End Select
                                Cadenas.Clear()
                                CadenasTotal.Clear()
                                e.Graphics.DrawString(FilaAcciones("PRIORIDAD").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 495, InicioYdeLineaTiempo + 3)

                                Dim fechalimite As String = ""
                                If FilaAcciones("FECHALIMITE").ToString <> "" Then
                                    fechalimite = Convert.ToDateTime(FilaAcciones("FECHALIMITE").ToString).ToShortDateString()
                                End If

                                e.Graphics.DrawString(fechalimite, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 555, InicioYdeLineaTiempo + 3)

                                Dim fechaterminado As String = ""
                                If FilaAcciones("FECHATERMINADO").ToString <> "" Then
                                    fechaterminado = Convert.ToDateTime(FilaAcciones("FECHATERMINADO").ToString).ToShortDateString()
                                End If
                                e.Graphics.DrawString(fechaterminado, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 635, InicioYdeLineaTiempo + 3)
                                If Pendientes = False Then
                                    BloqueImpresion = 44
                                Else
                                    BloqueImpresion = 43
                                End If

                                AccionesFaltantei += 1
                                InicioYdeLineaTiempo += Renglones * 20 '15
                                suma += Renglones * 20

                                If k < dtAcciones.Rows.Count - 1 Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYdeLineaTiempo, PuntoOrigen.X + 730, InicioYdeLineaTiempo)
                                    End If
                                End If
                            Else
                                If k <= dtAcciones.Rows.Count - 1 Then
                                    BloqueImpresion = 43
                                End If
                            End If
                        Next

                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 25, InicioYdeLineaTiempo2, PuntoOrigen.X + 25, InicioYdeLineaTiempo)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 260, InicioYdeLineaTiempo2, PuntoOrigen.X + 260, InicioYdeLineaTiempo)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 490, InicioYdeLineaTiempo2, PuntoOrigen.X + 490, InicioYdeLineaTiempo)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, InicioYdeLineaTiempo2, PuntoOrigen.X + 550, InicioYdeLineaTiempo)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 630, InicioYdeLineaTiempo2, PuntoOrigen.X + 630, InicioYdeLineaTiempo)

                        PuntoOrigen.Y += suma
                    End If
                Else
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                    BloqueImpresion = 44
                End If

            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If



        If BloqueImpresion = 44 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("14.   GRUPO INVESTIGADOR", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                e.Graphics.DrawString("NOMBRE", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 300, PuntoOrigen.Y, PuntoOrigen.X + 300, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("ROL EN EL GRUPO".ToString, Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 305, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 500, PuntoOrigen.Y, PuntoOrigen.X + 500, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("FECHA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 505, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 600, PuntoOrigen.Y, PuntoOrigen.X + 600, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("FIRMA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 605, PuntoOrigen.Y + 3)

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 1, PuntoOrigen.Y + 20, PuntoOrigen.X + 728, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                'Se imprime las cadenas faltantes
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                Dim suma As Integer = 0
                If dtInvestigadores IsNot Nothing Then
                    If dtInvestigadores.Rows.Count > 0 Then
                        suma = 0
                        For k As Integer = InvestigadoresFaltantei To dtInvestigadores.Rows.Count - 1
                            If ContadorRenglones > 0 Then
                                Dim FilaInvestigador As DataRow = dtInvestigadores.Rows(k)
                                Dim Renglones As Integer = 0

                                e.Graphics.DrawString(FilaInvestigador("Nombre").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                                Dim Rol As String = FilaInvestigador("Rol").ToString
                                Select Case Rol.Length
                                    Case Is < 35
                                        e.Graphics.DrawString(Rol, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 305, PuntoOrigen.Y + 3)
                                        ContadorRenglones -= 1
                                    Case Else
                                        Cadenas.Add(Rol)
                                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 190, e)
                                        Dim otralinea1 As Integer = 7
                                        Dim puntoobservacion1 As Integer = PuntoOrigen.Y + 1
                                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                        End If
                                        For i As Integer = 0 To CadenasTotal.Count - 1
                                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 190, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 305, puntoobservacion1)
                                            puntoobservacion1 += otralinea1
                                            ContadorRenglones -= 1
                                        Next
                                        Cadenas.Clear()
                                        CadenasTotal.Clear()
                                End Select

                                Dim fecha As String = ""
                                If FilaInvestigador("Fecha").ToString <> "" Then
                                    fecha = Convert.ToDateTime(FilaInvestigador("Fecha").ToString).ToShortDateString()
                                End If
                                e.Graphics.DrawString(fecha, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 505, PuntoOrigen.Y + 3)

                                InvestigadoresFaltantei += 1
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 300, PuntoOrigen.Y, PuntoOrigen.X + 300, PuntoOrigen.Y + 20)
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 500, PuntoOrigen.Y, PuntoOrigen.X + 500, PuntoOrigen.Y + 20)
                                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 600, PuntoOrigen.Y, PuntoOrigen.X + 600, PuntoOrigen.Y + 20)
                                PuntoOrigen.Y += 20
                                If k < dtInvestigadores.Rows.Count - 1 Then
                                    If ContadorRenglones > 0 Then
                                        e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y)
                                    End If
                                End If
                            Else
                                If k <= dtAcciones.Rows.Count - 1 Then
                                    BloqueImpresion = 44
                                Else
                                    BloqueImpresion = 45
                                End If
                            End If
                        Next
                    End If
                Else
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                    BloqueImpresion = 45
                End If

                If CadenasTotal.Count = 0 Then
                    BloqueImpresion = 45
                    If ContadorRenglones > 0 Then
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                    End If
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 45 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("15.  CONCEPTO Y RECOMENDACIONES", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                e.Graphics.DrawString("Departamento HSE", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim Comentario As String = Replace(filaReporteInv("OBSERVACIONHSE").ToString, vbLf, "")
                    If Trim(Comentario) <> "" Then
                        Cadenas.Add(Comentario)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresion = 45
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 46
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 46 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Nombre de quien realizó el concepto o recomendación", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Firma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 405, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 605, PuntoOrigen.Y, PuntoOrigen.X + 605, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Fecha del concepto", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.DrawString(filaReporteInv("NOMBREHSE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 605, PuntoOrigen.Y, PuntoOrigen.X + 605, PuntoOrigen.Y + 20)
                Dim fecha As String = ""
                If filaReporteInv("FECHAOBSERVACIONHSE").ToString <> "" Then
                    fecha = Convert.ToDateTime(filaReporteInv("FECHAOBSERVACIONHSE").ToString).ToShortDateString()
                End If
                e.Graphics.DrawString(fecha, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 47
            Else
                BloqueImpresion = 46
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 47 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.DrawString("Asesor jurídico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim Comentario As String = Replace(filaReporteInv("OBSERVACIONASESORJURIDICO").ToString, vbLf, "")
                    If Trim(Comentario) <> "" Then
                        Cadenas.Add(Comentario)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresion = 47
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 48
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 48 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawString("Nombre de quien realizó el concepto o recomendación", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Firma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 405, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 605, PuntoOrigen.Y, PuntoOrigen.X + 605, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Fecha del concepto", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.DrawString(filaReporteInv("NOMBREASESOR").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 605, PuntoOrigen.Y, PuntoOrigen.X + 605, PuntoOrigen.Y + 20)
                Dim fecha As String = ""
                If filaReporteInv("FECHAOBSERVACIONASESORJURIDICO").ToString <> "" Then
                    fecha = Convert.ToDateTime(filaReporteInv("FECHAOBSERVACIONASESORJURIDICO").ToString).ToShortDateString()
                End If
                e.Graphics.DrawString(fecha, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 49
            Else
                BloqueImpresion = 48
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 49 Then
            If ContadorRenglones >= 3 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("16.  APROBACIÓN INFORME", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20
                e.Graphics.DrawString("Nombre de quien aprueba", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Firma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 405, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 605, PuntoOrigen.Y, PuntoOrigen.X + 605, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Fecha de aprobación", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz_Gris, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim Aprueba As String = filaReporteInv("APRUEBA").ToString
                Select Case Aprueba.Length
                    Case Is < 25
                        e.Graphics.DrawString(Aprueba, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                    Case Is < 41
                        e.Graphics.DrawString(Aprueba, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                    Case Else
                        Cadenas.Add(Aprueba)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 180, e)
                        Dim otralinea1 As Integer = 7
                        Dim puntoobservacion1 As Integer = PuntoOrigen.Y + 1
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 180, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 5, puntoobservacion1)
                            puntoobservacion1 += otralinea1
                            ContadorRenglones -= 1
                        Next
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                End Select

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 20)
                Dim Cargo As String = filaReporteInv("CARGOAPRUEBA").ToString
                Select Case Aprueba.Length
                    Case Is < 25
                        e.Graphics.DrawString(Cargo, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 5)
                    Case Is < 41
                        e.Graphics.DrawString(Cargo, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 205, PuntoOrigen.Y + 5)
                    Case Else
                        Cadenas.Add(Cargo)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 180, e)
                        Dim otralinea1 As Integer = 7
                        Dim puntoobservacion1 As Integer = PuntoOrigen.Y + 1
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 180, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 205, puntoobservacion1)
                            puntoobservacion1 += otralinea1
                            ContadorRenglones -= 1
                        Next
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                End Select

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 605, PuntoOrigen.Y, PuntoOrigen.X + 605, PuntoOrigen.Y + 20)
                Dim fecha As String = ""
                If filaReporteInv("FECHAAPROBACION").ToString <> "" Then
                    fecha = Convert.ToDateTime(filaReporteInv("FECHAAPROBACION").ToString).ToShortDateString()
                End If
                e.Graphics.DrawString(fecha, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresion = 50
            Else
                BloqueImpresion = 49
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If

        If BloqueImpresion = 50 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("17.  GRUPOS DE INTERÉS NOTIFICADOS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo + 5
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma 'InicioYdeLineaTiempo
                Else

                    Dim GruposInteres As String = ""
                    Dim entidadnotificada As String
                    Dim st As Char
                    Dim coma As String = ", "
                    entidadnotificada = filaReporteInv("ENTIDADNOTIFICADA").ToString
                    st = entidadnotificada(0)
                    If st = "S" Then
                        GruposInteres += "ARL" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(1)
                    If st = "S" Then
                        GruposInteres += "EPS" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(2)
                    If st = "S" Then
                        GruposInteres += "CAR" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(3)
                    If st = "S" Then
                        GruposInteres += "Organismo de certificación" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(4)
                    If st = "S" Then
                        GruposInteres += "Dirección territorial del ministerio de trabajo" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(5)
                    If st = "S" Then
                        GruposInteres += "Autoridad ambiental" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(6)
                    If st = "S" Then
                        GruposInteres += "Cliente" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = entidadnotificada(7)
                    If st = "S" Then
                        GruposInteres += coma + "otra entidad: " + filaReporteInv("OTRAENTIDADNOTIFICADA").ToString
                    End If

                    If Trim(GruposInteres) <> "" Then
                        Cadenas.Add(GruposInteres)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y + 5
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                        BloqueImpresion = 50
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = 51
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                End If
            Else
                TamañoY = PuntoOrigen.Y - 55
            End If
        End If



        If BloqueImpresion = 51 Then
            If ContadorRenglones >= 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("18.  ANEXOS", Formato_Etiqueta_10, Brocha, 730, 55, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                ContadorRenglones -= 1
                PuntoOrigen.Y += 20

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo + 5
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else

                    Dim CadenaAnexos As String = ""
                    Dim Anexo As String
                    Dim st As Char
                    Dim coma As String = ", "
                    Anexo = filaReporteInv("ANEXOS").ToString
                    st = Anexo(0)
                    If st = "S" Then
                        CadenaAnexos += "Dibujos/Diagramas" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = Anexo(1)
                    If st = "S" Then
                        CadenaAnexos += "Fotos/Grabaciones" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = Anexo(2)
                    If st = "S" Then
                        CadenaAnexos += "Documentos/Registros" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = Anexo(3)
                    If st = "S" Then
                        CadenaAnexos += "Reporte 24 Horas" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = Anexo(4)
                    If st = "S" Then
                        CadenaAnexos += "Alerta de seguridad" + coma
                        coma = ", "
                    Else
                        coma = ""
                    End If
                    st = Anexo(5)
                    If st = "S" Then
                        CadenaAnexos += coma + "otros anexos: " + filaReporteInv("OTROSANEXOS").ToString
                    End If

                    If Trim(CadenaAnexos) <> "" Then
                        Cadenas.Add(CadenaAnexos)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y + 5
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                        BloqueImpresion = 51
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                TamañoY = PuntoOrigen.Y - 55

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresion = -1
                    Terminado = True
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                End If
            End If
        End If
        '------ Finalizacion del documento ------
        Dim PuntoOrigen2 As New Point(55, 55)
        e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen2.X, PuntoOrigen2.Y, 730, TamañoY)

        ContadorPaginasReporteInv += 1

        Dim CantidadPaginas As String = ""
        If ImprimirPieDePagina Then
            CantidadPaginas = "Página " + ContadorPaginasReporteInv.ToString + " de " + PaginasTotalReporteInv.ToString
        Else
            CantidadPaginas = "Página " + ContadorPaginasReporteInv.ToString
        End If

        e.Graphics.DrawStringCentered(CantidadPaginas, Formato_Etiqueta_8, Brocha, e.PageBounds.Width, 0, PuntoOrigen.Y + 20)

        If ImpresionReporteInv = True Then
            If ContadorPaginasReporteInv = PaginasTotalReporteInv Then
                BloquearReporteInv()
            End If
        End If

        If Terminado = True Then
            ImprimirPieDePagina = True
            PaginasTotalReporteInv = ContadorPaginasReporteInv
            e.HasMorePages = False
            ContadorPaginasReporteInv = 0
            BloqueContratoADescripcion = False
            BloqueLineaTiempo = False
            BloqueImpresion = 0
            LTFaltantei = 0
            TestigosFaltantei = 0
            EvidenciasFaltantei = 0
            CausasActosFaltantei = 0
            CausasCondicionesFaltantei = 0
            CausasPersonalesFaltantei = 0
            CausasTrabajoFaltantei = 0
            AccionesFaltantei = 0
            InvestigadoresFaltantei = 0
            Exit Sub
        Else
            e.HasMorePages = True
        End If

    End Sub

    Private Sub BloquearReporteInv()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TIPO", 16)
            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IdReporte)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "100 - Formato Alerta de seguridad ICH-GRAL-F-142"
    Private WithEvents DocImp_ICHGRALF142 As New PrintDocument

    Dim ImpresionReporteAlerta As Boolean = False

    Dim ContadorPaginasReporteAlerta As Integer = 0
    Dim PaginasTotalReporteAlerta As Integer = 0

    'variables para identificar los bloques de información que se estan imprimiendo
    Dim BloqueImpresionIzquierdo As Integer = 0
    Dim BloqueImpresionDerecho As Integer = 0
    Dim TerminadoIzquierdo As Boolean = False
    Dim TerminadoDerecho As Boolean = False
    Dim SubCadenaFaltanteIzquierda As New ArrayList
    Dim SubCadenaFaltanteDerecha As New ArrayList

    'Variable para guardar el tamaño maximo de la pagina
    Dim TamañoYAlerta As Integer

    Private Sub DocImpr_ICHGRALF142(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF142.PrintPage
        If ContadorPaginasReporteAlerta = 0 Then
            CargarDataSetFormatosHSE()
        End If

        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        Dim CantidadRenglones As Integer = 0
        Dim ContadorRenglonesIzquierdo As Integer = 0
        Dim ContadorRenglonesDerecho As Integer = 0

        Dim PuntoOrigen As New Point(55, 55)
        Dim PuntoOrigenIzquierdo As New Point(55, 55)
        Dim PuntoOrigenDerecho As New Point(55, 55)
        TamañoYAlerta = 985

        e.Graphics.DrawImage(logoIsmocol, PuntoOrigen.X + 20, PuntoOrigen.Y + 7, 90, 70)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 125, PuntoOrigen.Y, PuntoOrigen.X + 125, 140) 'Vertical
        e.Graphics.DrawStringCentered("ALERTA DE SEGURIDAD", Formato_Etiqueta_12, Brocha, 480, 180, 90)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y, 660, 140) 'Vertical
        e.Graphics.DrawStringCentered("ICH-GRAL-F-142", Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 15)
        e.Graphics.DrawLine(Lapiz, 660, 97, 785, 97) 'Horizontal
        e.Graphics.DrawStringCentered("Revisión No. 1", Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 55)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, 140, PuntoOrigen.X + 730, 140) 'Horizontal completa

        PuntoOrigen.Y += 85 '140
        PuntoOrigenIzquierdo.Y += 85
        PuntoOrigenDerecho.Y += 85
        ContadorRenglonesIzquierdo = (1040 - PuntoOrigen.Y) / 20
        ContadorRenglonesDerecho = (1040 - PuntoOrigen.Y) / 20

        If BloqueImpresionDerecho = 0 Then
            If ContadorRenglonesDerecho >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 350, PuntoOrigenDerecho.Y + 1, 380, 19)
                e.Graphics.DrawString("RESUMEN DE CAUSAS BÁSICAS", Formato_Etiqueta_10, Brocha, PuntoOrigenDerecho.X + 365, PuntoOrigenDerecho.Y + 5)
                ContadorRenglonesDerecho -= 1
                PuntoOrigenDerecho.Y += 20
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenDerecho.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenDerecho.Y
                If SubCadenaFaltanteDerecha.Count > 0 Then
                    Dim FilaCausas As DataRow = dtCausasPersonales.Rows(CausasPersonalesFaltantei - 1)
                    Dim Renglones As Integer = 0
                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigenDerecho.Y + 1
                    For j As Integer = 0 To SubCadenaFaltanteDerecha.Count - 1
                        If ContadorRenglonesDerecho > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteDerecha(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglonesDerecho -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteDerecha.Clear()
                    'suma += Renglones * 20
                    PuntoOrigenDerecho.Y += Renglones * 20
                    Pendientes = False
                End If

                If dtCausasPersonales IsNot Nothing Then
                    If dtCausasPersonales.Rows.Count > 0 Then
                        For i As Integer = CausasPersonalesFaltantei To dtCausasPersonales.Rows.Count - 1
                            If ContadorRenglonesDerecho > 0 Then
                                Dim FilaCausas As DataRow = dtCausasPersonales.Rows(i)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString(FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString + ": ", Formato_Etiqueta_8, Brocha, PuntoOrigenDerecho.X + 365, PuntoOrigenDerecho.Y + 5)
                                ContadorRenglonesDerecho -= 1
                                PuntoOrigenDerecho.Y += 20
                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = PuntoOrigenDerecho.Y + 1
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglonesDerecho > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglonesDerecho -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltanteDerecha.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                PuntoOrigenDerecho.Y += Renglones * 20
                                Cadenas.Clear()
                                CadenasTotal.Clear()


                                If Pendientes = False Then
                                    BloqueImpresionDerecho = 1
                                Else
                                    BloqueImpresionDerecho = 0
                                End If
                                CausasPersonalesFaltantei += 1
                            Else
                                If i <= dtCausasPersonales.Rows.Count - 1 Then
                                    BloqueImpresionDerecho = 0
                                End If
                            End If
                        Next
                    End If
                Else
                    BloqueImpresionDerecho = 1
                    PuntoOrigenDerecho.Y += 20
                    ContadorRenglonesDerecho -= 1
                End If
            End If
        End If

        If BloqueImpresionDerecho = 1 Then

            Dim InicioYdeLineaTiempo As Integer = PuntoOrigenDerecho.Y
            Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenDerecho.Y
            If SubCadenaFaltanteDerecha.Count > 0 Then
                Dim FilaCausas As DataRow = dtCausasTrabajo.Rows(CausasTrabajoFaltantei - 1)
                Dim Renglones As Integer = 0
                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                Cadenas.Add(Causa)
                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                Dim otralinea2 As Integer = 20
                Dim puntoobservacion2 As Integer = PuntoOrigenDerecho.Y + 1
                For j As Integer = 0 To SubCadenaFaltanteDerecha.Count - 1
                    If ContadorRenglonesDerecho > 0 Then
                        e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteDerecha(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion2 + 3)
                        puntoobservacion2 += otralinea2
                        Renglones += 1
                        ContadorRenglones -= 1
                    End If
                Next
                Cadenas.Clear()
                CadenasTotal.Clear()

                InicioYdeLineaTiempo += Renglones * 20

                Cadenas.Clear()
                CadenasTotal.Clear()
                SubCadenaFaltanteDerecha.Clear()
                PuntoOrigenDerecho.Y += Renglones * 20
                Pendientes = False
            End If

            If dtCausasTrabajo IsNot Nothing Then
                If dtCausasTrabajo.Rows.Count > 0 Then
                    For i As Integer = CausasTrabajoFaltantei To dtCausasTrabajo.Rows.Count - 1
                        If ContadorRenglonesDerecho > 0 Then
                            Dim FilaCausas As DataRow = dtCausasTrabajo.Rows(i)
                            Dim Renglones As Integer = 0
                            e.Graphics.DrawString(FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString + ": ", Formato_Etiqueta_8, Brocha, PuntoOrigenDerecho.X + 365, PuntoOrigenDerecho.Y + 5)
                            ContadorRenglonesDerecho -= 1
                            PuntoOrigenDerecho.Y += 20
                            Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                            Cadenas.Add(Causa)
                            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                            Dim otralinea As Integer = 20
                            Dim puntoobservacion As Integer = PuntoOrigenDerecho.Y + 1
                            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                            End If
                            For j As Integer = 0 To CadenasTotal.Count - 1
                                If ContadorRenglonesDerecho > 0 Then
                                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion + 3)
                                    puntoobservacion += otralinea
                                    Renglones += 1
                                    ContadorRenglonesDerecho -= 1
                                    Pendientes = False
                                Else
                                    SubCadenaFaltanteDerecha.Add(CadenasTotal(j))
                                    Pendientes = True
                                End If
                            Next
                            PuntoOrigenDerecho.Y += Renglones * 20
                            Cadenas.Clear()
                            CadenasTotal.Clear()


                            If Pendientes = False Then
                                BloqueImpresionDerecho = 2
                            Else
                                BloqueImpresionDerecho = 1
                            End If
                            CausasTrabajoFaltantei += 1
                        Else
                            If i <= dtCausasTrabajo.Rows.Count - 1 Then
                                BloqueImpresionDerecho = 1
                            End If
                        End If
                    Next
                End If
            Else
                BloqueImpresionDerecho = 2
                PuntoOrigenDerecho.Y += 20
                ContadorRenglonesDerecho -= 1
            End If
        End If

        If BloqueImpresionDerecho = 2 Then
            If ContadorRenglonesDerecho >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 350, PuntoOrigenDerecho.Y + 1, 380, 19)
                e.Graphics.DrawString("PUNTOS A RECORDAR", Formato_Etiqueta_10, Brocha, PuntoOrigenDerecho.X + 365, PuntoOrigenDerecho.Y + 5)
                ContadorRenglonesDerecho -= 1
                PuntoOrigenDerecho.Y += 20

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenDerecho.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenDerecho.Y

                If SubCadenaFaltanteDerecha.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltanteDerecha.Count - 1
                        If ContadorRenglonesDerecho > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteDerecha(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglonesDerecho -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteDerecha.Clear()
                    suma += Renglones * 20
                    PuntoOrigenDerecho.Y += suma
                    BloqueImpresionDerecho = 3
                Else
                    Dim Descripcion As String = Replace(filaReporteInv("OBSERVACIONHSE").ToString, vbLf, "")
                    If Trim(Descripcion) <> "" Then
                        Cadenas.Add(Descripcion)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigenDerecho.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglonesDerecho > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 365, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglonesDerecho -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltanteDerecha.Add(CadenasTotal(i))
                            End If

                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                        If SubCadenaFaltanteDerecha.Count > 0 Then
                            BloqueImpresionDerecho = 2
                        Else
                            BloqueImpresionDerecho = 3
                        End If

                        PuntoOrigenDerecho.Y += suma
                    Else
                        PuntoOrigenDerecho.Y += 20
                        ContadorRenglonesDerecho -= 1
                        BloqueImpresionDerecho = 3
                    End If
                End If
            End If
        End If

        If BloqueImpresionDerecho = 3 Then
            If ContadorRenglonesDerecho >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 350, PuntoOrigenDerecho.Y + 1, 380, 19)
                e.Graphics.DrawString("ACCIONES PREVENTIVAS / CORRECTIVAS", Formato_Etiqueta_10, Brocha, PuntoOrigenDerecho.X + 365, PuntoOrigenDerecho.Y + 5)
                ContadorRenglonesDerecho -= 1
                PuntoOrigenDerecho.Y += 20
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenDerecho.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenDerecho.Y
                If SubCadenaFaltanteDerecha.Count > 0 Then
                    Dim FilaCausas As DataRow = dtAcciones.Rows(AccionesFaltantei - 1)
                    Dim Renglones As Integer = 0
                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigenDerecho.Y + 1
                    For j As Integer = 0 To SubCadenaFaltanteDerecha.Count - 1
                        If ContadorRenglonesDerecho > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteDerecha(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglonesDerecho -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteDerecha.Clear()
                    PuntoOrigenDerecho.Y += Renglones * 20
                    Pendientes = False
                End If

                If dtAcciones IsNot Nothing Then
                    If dtAcciones.Rows.Count > 0 Then
                        For i As Integer = AccionesFaltantei To dtAcciones.Rows.Count - 1
                            If ContadorRenglonesDerecho > 0 Then
                                Dim FilaAccion As DataRow = dtAcciones.Rows(i)
                                Dim Renglones As Integer = 0
                                Dim Accion As String = (i + 1).ToString + ". " + FilaAccion("ACCION").ToString
                                Cadenas.Add(Accion)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 360, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = PuntoOrigenDerecho.Y + 1
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglonesDerecho > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 360, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenDerecho.X + 365, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglonesDerecho -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltanteDerecha.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                PuntoOrigenDerecho.Y += Renglones * 20
                                Cadenas.Clear()
                                CadenasTotal.Clear()


                                If Pendientes = False Then
                                    BloqueImpresionDerecho = 4
                                Else
                                    BloqueImpresionDerecho = 3
                                End If
                                AccionesFaltantei += 1
                            Else
                                If i <= dtAcciones.Rows.Count - 1 Then
                                    BloqueImpresionDerecho = 3
                                End If
                            End If
                        Next
                    End If
                Else
                    BloqueImpresionDerecho = 4
                    PuntoOrigenDerecho.Y += 20
                    ContadorRenglonesDerecho -= 1
                End If
            End If
        End If

        If BloqueImpresionDerecho = 4 Then
            If ContadorRenglonesDerecho >= 13 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 350, PuntoOrigenDerecho.Y + 1, 380, 19)
                e.Graphics.DrawString("DIAGRAMAS O REGISTRO FOTOGRÁFICO", Formato_Etiqueta_10, Brocha, PuntoOrigenDerecho.X + 365, PuntoOrigenDerecho.Y + 5)
                ContadorRenglonesDerecho -= 13
                PuntoOrigenDerecho.Y += 13 * 20 'Renglones * Espacio renglones
                BloqueImpresionDerecho = 5
                TerminadoDerecho = True
            End If
        End If

        If BloqueImpresionIzquierdo = 0 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigenIzquierdo.Y + 1, 360, 19)
                e.Graphics.DrawString("INCIDENTE", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenIzquierdo.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenIzquierdo.Y

                If SubCadenaFaltanteIzquierda.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltanteIzquierda.Count - 1
                        If ContadorRenglonesIzquierdo > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteIzquierda(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglonesIzquierdo -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteIzquierda.Clear()
                    suma += Renglones * 20
                    PuntoOrigenIzquierdo.Y += suma
                Else
                    Dim Incidente As String = ""
                    If filaReporte24H("TIPOINCIDENTE") = "Salud" Then
                        Incidente = Replace(filaReporteInv("COMENTARIOMEDICO").ToString, vbLf, "")
                    Else
                        If filaReporte24H("TIPOINCIDENTE") = "Seguridad" Then
                            Incidente = Replace(filaReporteInv("SUSTANCIA_PROCESO").ToString, vbLf, "")
                        Else
                            If filaReporte24H("TIPOINCIDENTE") = "AMBIENTAL" Then
                                Incidente = Replace(filaReporteInv("SUSTANCIA_PROCESO").ToString, vbLf, "")
                            End If
                        End If
                    End If
                    If Trim(Incidente) <> "" Then
                        Cadenas.Add(Incidente)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigenIzquierdo.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglonesIzquierdo > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglonesIzquierdo -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltanteIzquierda.Add(CadenasTotal(i))
                            End If

                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                        If SubCadenaFaltanteIzquierda.Count > 0 Then
                            BloqueImpresionIzquierdo = 0
                        Else
                            BloqueImpresionIzquierdo = 1
                        End If

                        PuntoOrigenIzquierdo.Y += suma
                    Else
                        PuntoOrigenIzquierdo.Y += 20
                        ContadorRenglonesIzquierdo -= 1
                        BloqueImpresionIzquierdo = 1
                    End If
                End If
            End If
        End If

        If BloqueImpresionIzquierdo = 1 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigenIzquierdo.Y + 1, 355, 19)
                e.Graphics.DrawString("ACTIVIDAD", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20
                Dim Actividad As String = Replace(filaReporte24H("ACTIVIDADPRINCIPAL").ToString, vbLf, "")
                e.Graphics.DrawString(Actividad, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20
                BloqueImpresionIzquierdo = 2
            End If
        End If

        If BloqueImpresionIzquierdo = 2 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigenIzquierdo.Y + 1, 355, 19)
                e.Graphics.DrawString("DEPARTAMENTO", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20
                Dim Actividad As String = Replace(filaReporte24H("AREA").ToString, vbLf, "")
                e.Graphics.DrawString(Actividad, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20
                BloqueImpresionIzquierdo = 3
            End If
        End If

        If BloqueImpresionIzquierdo = 3 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigenIzquierdo.Y + 1, 355, 19)
                e.Graphics.DrawString("DESCRIPCIÓN BREVE DEL INCIDENTE", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenIzquierdo.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenIzquierdo.Y

                If SubCadenaFaltanteIzquierda.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltanteIzquierda.Count - 1
                        If ContadorRenglonesIzquierdo > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteIzquierda(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglonesIzquierdo -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteIzquierda.Clear()
                    suma += Renglones * 20
                    PuntoOrigenIzquierdo.Y += suma
                Else
                    Dim Incidente As String = filaReporteInv("DESCRIPCIONINCIDENTE").ToString
                    Incidente = Replace(Incidente, vbLf, "")
                    If Trim(Incidente) <> "" Then
                        Cadenas.Add(Incidente)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigenIzquierdo.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglonesIzquierdo > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglonesIzquierdo -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltanteIzquierda.Add(CadenasTotal(i))
                            End If

                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                        If SubCadenaFaltanteIzquierda.Count > 0 Then
                            BloqueImpresionIzquierdo = 3
                        Else
                            BloqueImpresionIzquierdo = 4
                        End If

                        PuntoOrigenIzquierdo.Y += suma
                    Else
                        PuntoOrigenIzquierdo.Y += 20
                        ContadorRenglonesIzquierdo -= 1
                        BloqueImpresionIzquierdo = 3
                    End If
                End If
            End If
        End If

        If BloqueImpresionIzquierdo = 4 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigenIzquierdo.Y + 1, 355, 19)
                e.Graphics.DrawString("¿QUÉ ESTUVO MAL?", Formato_Etiqueta_10, Brocha, PuntoOrigen.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenIzquierdo.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenIzquierdo.Y

                If SubCadenaFaltanteIzquierda.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltanteIzquierda.Count - 1
                        If ContadorRenglonesIzquierdo > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteIzquierda(j), Formato_Etiqueta_8R, 300, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglonesIzquierdo -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteIzquierda.Clear()
                    suma += Renglones * 20
                    PuntoOrigenIzquierdo.Y += suma
                Else
                    Dim Incidente As String = Replace(filaReporteInv("QUEESTUVOMAL").ToString, vbLf, "")
                    If Trim(Incidente) <> "" Then
                        Cadenas.Add(Incidente)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigenIzquierdo.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglonesIzquierdo > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglonesIzquierdo -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltanteIzquierda.Add(CadenasTotal(i))
                            End If

                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()
                        If SubCadenaFaltanteIzquierda.Count > 0 Then
                            BloqueImpresionIzquierdo = 4
                        Else
                            BloqueImpresionIzquierdo = 5
                        End If

                        PuntoOrigenIzquierdo.Y += suma
                    Else
                        PuntoOrigenIzquierdo.Y += 20
                        ContadorRenglonesIzquierdo -= 1
                        BloqueImpresionIzquierdo = 5
                    End If
                End If
            End If
        End If

        If BloqueImpresionIzquierdo = 5 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigenIzquierdo.Y + 1, 355, 19)
                e.Graphics.DrawString("RESUMEN DE CAUSAS INMEDIATA", Formato_Etiqueta_10, Brocha, PuntoOrigenIzquierdo.X + 5, PuntoOrigenIzquierdo.Y + 5)
                ContadorRenglonesIzquierdo -= 1
                PuntoOrigenIzquierdo.Y += 20
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenIzquierdo.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenIzquierdo.Y
                If SubCadenaFaltanteIzquierda.Count > 0 Then
                    Dim FilaCausas As DataRow = dtCausasActos.Rows(CausasActosFaltantei - 1)
                    Dim Renglones As Integer = 0

                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigenIzquierdo.Y + 1
                    For j As Integer = 0 To SubCadenaFaltanteIzquierda.Count - 1
                        If ContadorRenglonesIzquierdo > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteIzquierda(j), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglonesIzquierdo -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteIzquierda.Clear()
                    PuntoOrigenIzquierdo.Y += Renglones * 20
                    Pendientes = False
                    BloqueImpresionIzquierdo = 6
                End If

                If dtCausasActos IsNot Nothing Then
                    If dtCausasActos.Rows.Count > 0 Then
                        For i As Integer = CausasActosFaltantei To dtCausasActos.Rows.Count - 1
                            If ContadorRenglonesIzquierdo > 0 Then
                                Dim FilaCausas As DataRow = dtCausasActos.Rows(i)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString(FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString + ": ", Formato_Etiqueta_8, Brocha, PuntoOrigenIzquierdo.X + 5, PuntoOrigenIzquierdo.Y + 5)
                                ContadorRenglonesIzquierdo -= 1
                                PuntoOrigenIzquierdo.Y += 20
                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = PuntoOrigenIzquierdo.Y + 1
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglonesIzquierdo > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglonesIzquierdo -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltanteIzquierda.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                PuntoOrigenIzquierdo.Y += Renglones * 20
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresionIzquierdo = 6
                                Else
                                    BloqueImpresionIzquierdo = 5
                                End If
                                CausasActosFaltantei += 1
                            Else
                                If i <= dtCausasActos.Rows.Count - 1 Then
                                    BloqueImpresionIzquierdo = 5
                                End If
                            End If
                        Next
                    End If
                Else
                    BloqueImpresionIzquierdo = 6
                    PuntoOrigenIzquierdo.Y += 20
                    ContadorRenglonesIzquierdo -= 1
                End If
            End If
        End If

        If BloqueImpresionIzquierdo = 6 Then
            If ContadorRenglonesIzquierdo >= 2 Then
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigenIzquierdo.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigenIzquierdo.Y
                If SubCadenaFaltanteIzquierda.Count > 0 Then
                    Dim FilaCausas As DataRow = dtCausasCondiciones.Rows(CausasCondicionesFaltantei - 1)
                    Dim Renglones As Integer = 0
                    Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                    Cadenas.Add(Causa)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                    Dim otralinea2 As Integer = 20
                    Dim puntoobservacion2 As Integer = PuntoOrigenIzquierdo.Y + 1
                    For j As Integer = 0 To SubCadenaFaltanteIzquierda.Count - 1
                        If ContadorRenglonesIzquierdo > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltanteIzquierda(j), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion2 + 3)
                            puntoobservacion2 += otralinea2
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()

                    InicioYdeLineaTiempo += Renglones * 20

                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltanteIzquierda.Clear()
                    PuntoOrigenIzquierdo.Y += Renglones * 20
                    Pendientes = False
                    BloqueImpresionIzquierdo = 7
                    TerminadoIzquierdo = True
                End If

                If dtCausasCondiciones IsNot Nothing Then
                    If dtCausasCondiciones.Rows.Count > 0 Then
                        For i As Integer = CausasCondicionesFaltantei To dtCausasCondiciones.Rows.Count - 1
                            If ContadorRenglonesIzquierdo > 0 Then
                                Dim FilaCausas As DataRow = dtCausasCondiciones.Rows(i)
                                Dim Renglones As Integer = 0
                                e.Graphics.DrawString(FilaCausas("NOMBRETIPOEVIDENCIAYCAUSA").ToString + ": ", Formato_Etiqueta_8, Brocha, PuntoOrigenIzquierdo.X + 5, PuntoOrigenIzquierdo.Y + 5)
                                ContadorRenglonesIzquierdo -= 1
                                PuntoOrigenIzquierdo.Y += 20
                                Dim Causa As String = Replace(FilaCausas("DESCRIPCION").ToString, vbLf, "")
                                Cadenas.Add(Causa)
                                CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 350, e)
                                Dim otralinea As Integer = 20
                                Dim puntoobservacion As Integer = PuntoOrigenIzquierdo.Y + 1
                                If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                    CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                End If
                                For j As Integer = 0 To CadenasTotal.Count - 1
                                    If ContadorRenglonesIzquierdo > 0 Then
                                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 350, e), Formato_Etiqueta_8R, Brocha, PuntoOrigenIzquierdo.X + 5, puntoobservacion + 3)
                                        puntoobservacion += otralinea
                                        Renglones += 1
                                        ContadorRenglonesIzquierdo -= 1
                                        Pendientes = False
                                    Else
                                        SubCadenaFaltanteIzquierda.Add(CadenasTotal(j))
                                        Pendientes = True
                                    End If
                                Next
                                PuntoOrigenIzquierdo.Y += Renglones * 20
                                Cadenas.Clear()
                                CadenasTotal.Clear()

                                If Pendientes = False Then
                                    BloqueImpresionIzquierdo = 7
                                    TerminadoIzquierdo = True
                                Else
                                    BloqueImpresionIzquierdo = 6
                                End If
                                CausasCondicionesFaltantei += 1
                            Else
                                If i <= dtCausasCondiciones.Rows.Count - 1 Then
                                    BloqueImpresionIzquierdo = 6
                                End If
                            End If
                        Next
                    End If
                Else
                    TerminadoIzquierdo = True
                    BloqueImpresionIzquierdo = 7
                    PuntoOrigenIzquierdo.Y += 20
                    ContadorRenglonesIzquierdo -= 1
                End If
            End If
        End If

        'Comparo la altura maxima
        If PuntoOrigenDerecho.Y > PuntoOrigenIzquierdo.Y Then
            TamañoYAlerta = PuntoOrigenDerecho.Y
        Else
            TamañoYAlerta = PuntoOrigenIzquierdo.Y
        End If

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 350, PuntoOrigen.Y + 1, 10, TamañoYAlerta - 140)
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 5, TamañoYAlerta - 140)
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 725, PuntoOrigen.Y + 1, 5, TamañoYAlerta - 140)
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, TamañoYAlerta, 730, 20)
        TamañoYAlerta += 20

        Dim PuntoOrigen2 As New Point(55, 55)
        e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen2.X, PuntoOrigen2.Y, 730, TamañoYAlerta - 55)

        ContadorPaginasReporteAlerta += 1
        Dim CantidadPaginas As String = ""
        If ImprimirPieDePagina Then
            CantidadPaginas = "Página " + ContadorPaginasReporteAlerta.ToString + " de " + PaginasTotalReporteAlerta.ToString
        Else
            CantidadPaginas = "Página " + ContadorPaginasReporteAlerta.ToString
        End If
        e.Graphics.DrawStringCentered(CantidadPaginas, Formato_Etiqueta_8, Brocha, e.PageBounds.Width, 0, TamañoYAlerta + 20)

        If TerminadoDerecho = True And TerminadoIzquierdo = True Then
            e.Graphics.DrawString("FECHA DE PUBLICACIÓN " + Today.ToShortDateString, Formato_Etiqueta_8, Brocha, PuntoOrigenIzquierdo.X + 365, TamañoYAlerta - 15)
            e.HasMorePages = False
            ImprimirPieDePagina = True
            PaginasTotalReporteAlerta = ContadorPaginasReporteAlerta
            ContadorPaginasReporteAlerta = 0
            BloqueImpresionIzquierdo = 0
            BloqueImpresionDerecho = 0
            CausasActosFaltantei = 0
            CausasCondicionesFaltantei = 0
            CausasPersonalesFaltantei = 0
            CausasTrabajoFaltantei = 0
            AccionesFaltantei = 0
            TerminadoDerecho = False
            TerminadoIzquierdo = False
            Exit Sub
        Else
            e.HasMorePages = True
        End If
    End Sub

#End Region

#Region "101 - Formato Concepto Examen Medico Ingreso ICH-GRAL-F-302 , Periodico ICH-GRAL-F-355 y Egreso ICH-GRAL-F-351"
    Private WithEvents DocImp_ICHGRALF355 As New PrintDocument

    Dim ImpresionExamen As Boolean = False

    Dim ContadorPaginasExamen As Integer = 0
    Dim PaginasTotalExamen As Integer = 0
    Dim TerminadoExamen As Boolean = False

    ''variables para identificar los bloques de información que se estan imprimiendo
    Dim BloqueImpresionExamen As Integer = 0
    Dim BloqueTareas As Boolean = False

    'Variable para guardar el tamaño maximo de la pagina
    Dim TamañoYExamen As Integer

    Dim TareaFaltantei As Integer = 0

    Dim PendientesTarea As Boolean
    Dim PendientesAgente As Boolean
    Dim PendientesFrecuencia As Boolean

    Private Sub DocImpr_ICHGRALF355(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF355.PrintPage
        If ContadorPaginasExamen = 0 Then
            CargarExamen()
        End If
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim TipoExamen As String = filaExamen("TIPOEXAMEN").ToString
        Dim Titulo As String = ""
        Dim ICH As String = ""
        Dim Revision As String = ""
        Dim TipoExamenLegalidad = ""
        If TipoExamen = "I" Then
            Titulo = "EXAMEN MÉDICO INGRESO"
            ICH = "ICH-GRAL-F-302"
            Revision = "Revisión No. 7"
            TipoExamenLegalidad = "De Ingreso"
        Else
            If TipoExamen = "P" Then
                Titulo = "EXAMEN MÉDICO PERIÓDICO"
                ICH = "ICH-GRAL-F-355"
                Revision = "Revisión No. 4"
                TipoExamenLegalidad = "Periodico"
            Else
                Titulo = "EXAMEN MÉDICO EGRESO"
                ICH = "ICH-GRAL-F-351"
                Revision = "Revisión No. 3"
                TipoExamenLegalidad = "De Egreso"
            End If
        End If

        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        Dim CantidadRenglones As Integer = 0
        Dim ContadorRenglones As Integer = 0

        Dim PuntoOrigen As New Point(55, 30)
        TamañoYExamen = 985

        e.Graphics.DrawImage(logoIsmocol, PuntoOrigen.X + 20, PuntoOrigen.Y + 7, 90, 70)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 125, PuntoOrigen.Y, PuntoOrigen.X + 125, PuntoOrigen.Y + 85) 'Vertical
        e.Graphics.DrawStringCentered(Titulo, Formato_Etiqueta_12, Brocha, 480, 180, PuntoOrigen.Y + 35)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y, 660, PuntoOrigen.Y + 85) 'Vertical
        e.Graphics.DrawStringCentered(ICH, Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 15)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y + 42, 785, PuntoOrigen.Y + 42) 'Horizontal
        e.Graphics.DrawStringCentered(Revision, Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 55)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 85, PuntoOrigen.X + 730, PuntoOrigen.Y + 85) 'Horizontal completa

        PuntoOrigen.Y += 85 '140
        ContadorRenglones = (1040 - PuntoOrigen.Y) / 20

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("CONCEPTO", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20
        ContadorRenglones -= 1

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 149, 19)
        e.Graphics.DrawString("FECHA DEL EXAMEN", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 150, PuntoOrigen.Y, PuntoOrigen.X + 150, PuntoOrigen.Y + 20)
        e.Graphics.DrawString(Convert.ToDateTime(filaExamen("FECHAEXAMENMEDICO").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 155, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 250, PuntoOrigen.Y, PuntoOrigen.X + 250, PuntoOrigen.Y + 20)

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 251, PuntoOrigen.Y + 1, 49, 19)
        e.Graphics.DrawString("C.C.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 300, PuntoOrigen.Y, PuntoOrigen.X + 300, PuntoOrigen.Y + 20)
        e.Graphics.DrawString(filaExamen("IDENTIFICACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 305, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20
        ContadorRenglones -= 1

        If TipoExamen = "I" Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("DATOS PERSONALES", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("NOMBRE COMPLETO", Formato_Etiqueta_8, Brocha, 500, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 500, PuntoOrigen.Y, PuntoOrigen.X + 500, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("FECHA DE NACIMIENTO", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 690, PuntoOrigen.Y, PuntoOrigen.X + 690, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("RH", Formato_Etiqueta_8, Brocha, 40, PuntoOrigen.X + 690, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            e.Graphics.DrawStringCentered(filaExamen("PERSONA").ToString, Formato_Etiqueta_8R, Brocha, 500, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(Convert.ToDateTime(filaExamen("FECHANACIMIENTO").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("GRUPOSANGUINEO").ToString, Formato_Etiqueta_8R, Brocha, 40, PuntoOrigen.X + 690, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("PROFESIÓN", Formato_Etiqueta_8, Brocha, 243, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 243, PuntoOrigen.Y, PuntoOrigen.X + 243, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("FONDO DE PENSIÓN", Formato_Etiqueta_8, Brocha, 243, PuntoOrigen.X + 243, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 486, PuntoOrigen.Y, PuntoOrigen.X + 486, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("EPS", Formato_Etiqueta_8, Brocha, 243, PuntoOrigen.X + 486, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.DrawStringCentered(filaExamen("NOMBRETIPOPROFESION").ToString, Formato_Etiqueta_8R, Brocha, 243, PuntoOrigen.X, PuntoOrigen.Y + 5)
            Dim AFP As String = filaExamen("AFP").ToString
            Select Case AFP.Length
                Case Is < 41
                    e.Graphics.DrawStringCentered(AFP, Formato_Etiqueta_8R, Brocha, 243, PuntoOrigen.X + 243, PuntoOrigen.Y + 5)
                Case Is < 50
                    e.Graphics.DrawStringCentered(AFP, Formato_Etiqueta_7R, Brocha, 243, PuntoOrigen.X + 243, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(AFP)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 240, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 240, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 245, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            Dim EPS As String = filaExamen("EPS").ToString
            Select Case EPS.Length
                Case Is < 40
                    e.Graphics.DrawStringCentered(EPS, Formato_Etiqueta_8R, Brocha, 243, PuntoOrigen.X + 486, PuntoOrigen.Y + 5)
                Case Is < 50
                    e.Graphics.DrawStringCentered(EPS, Formato_Etiqueta_7R, Brocha, 243, PuntoOrigen.X + 486, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(EPS)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 240, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 240, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 488, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("CIUDAD", Formato_Etiqueta_8, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 180, PuntoOrigen.Y, PuntoOrigen.X + 180, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("DIRECCIÓN", Formato_Etiqueta_8, Brocha, 270, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 450, PuntoOrigen.Y, PuntoOrigen.X + 450, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("MOVIL", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 540, PuntoOrigen.Y, PuntoOrigen.X + 540, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("CORREO", Formato_Etiqueta_8, Brocha, 180, PuntoOrigen.X + 540, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.DrawStringCentered(filaExamen("NOMBREPOBLACION").ToString, Formato_Etiqueta_8R, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            Dim Direccion As String = filaExamen("DIRECCION").ToString
            Select Case Direccion.Length
                Case Is < 41
                    e.Graphics.DrawStringCentered(Direccion, Formato_Etiqueta_8R, Brocha, 270, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Is < 47
                    e.Graphics.DrawStringCentered(Direccion, Formato_Etiqueta_7R, Brocha, 270, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Direccion)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 265, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 265, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 182, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            e.Graphics.DrawStringCentered(filaExamen("TELEFONOMOVIL").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("CORREOELECTRONICO").ToString, Formato_Etiqueta_8R, Brocha, 180, PuntoOrigen.X + 540, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("PROYECTO", Formato_Etiqueta_8, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 180, PuntoOrigen.Y, PuntoOrigen.X + 180, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("BASE", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 560, PuntoOrigen.Y, PuntoOrigen.X + 560, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("MUNICIPIO", Formato_Etiqueta_8, Brocha, 170, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            e.Graphics.DrawStringCentered(filaExamen("PROYECTO").ToString, Formato_Etiqueta_8R, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            Dim Base As String = filaExamen("NOMBREBASE").ToString
            Select Case Base.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(Base, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Is < 31
                    e.Graphics.DrawStringCentered(Base, Formato_Etiqueta_7R, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Base)
                    CadenasTotal = TextoAParrafoFuente2(Cadenas, Formato_Etiqueta_6R, 185, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 185, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 182, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            Dim Cargo As String = filaExamen("CARGO").ToString
            Select Case Cargo.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(Cargo, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                Case Is < 31
                    e.Graphics.DrawStringCentered(Cargo, Formato_Etiqueta_7R, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Cargo)
                    CadenasTotal = TextoAParrafoFuente2(Cadenas, Formato_Etiqueta_6R, 185, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 185, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 372, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            e.Graphics.DrawStringCentered(filaExamen("CIUDADCONTRATO").ToString, Formato_Etiqueta_8R, Brocha, 170, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
        Else

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("NOMBRE COMPLETO", Formato_Etiqueta_8, Brocha, 450, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("PROYECTO", Formato_Etiqueta_8, Brocha, 150, PuntoOrigen.X + 400, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, PuntoOrigen.Y, PuntoOrigen.X + 550, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("BASE", Formato_Etiqueta_8, Brocha, 140, PuntoOrigen.X + 550, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 690, PuntoOrigen.Y, PuntoOrigen.X + 690, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("EDAD", Formato_Etiqueta_8, Brocha, 40, PuntoOrigen.X + 690, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.DrawStringCentered(filaExamen("PERSONA").ToString, Formato_Etiqueta_8R, Brocha, 450, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("PROYECTO").ToString, Formato_Etiqueta_8R, Brocha, 150, PuntoOrigen.X + 400, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("NOMBREBASE").ToString, Formato_Etiqueta_8R, Brocha, 140, PuntoOrigen.X + 550, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("EDAD").ToString, Formato_Etiqueta_8R, Brocha, 40, PuntoOrigen.X + 690, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 39)
            e.Graphics.DrawStringCentered("DEPENDENCIA", Formato_Etiqueta_8, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 15)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 180, PuntoOrigen.Y, PuntoOrigen.X + 180, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 15)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("EPS", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 15)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 560, PuntoOrigen.Y, PuntoOrigen.X + 560, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("TIEMPO EN", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 560, PuntoOrigen.Y + 10)
            e.Graphics.DrawStringCentered("EL CARGO", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 560, PuntoOrigen.Y + 20)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 650, PuntoOrigen.Y, PuntoOrigen.X + 650, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("FECHA DE", Formato_Etiqueta_7, Brocha, 80, PuntoOrigen.X + 650, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered("INGRESO A", Formato_Etiqueta_7, Brocha, 80, PuntoOrigen.X + 650, PuntoOrigen.Y + 15)
            e.Graphics.DrawStringCentered("LA EMPRESA", Formato_Etiqueta_7, Brocha, 80, PuntoOrigen.X + 650, PuntoOrigen.Y + 25)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 40, PuntoOrigen.X + 730, PuntoOrigen.Y + 40) 'Horizontal completa
            PuntoOrigen.Y += 40
            ContadorRenglones -= 2

            e.Graphics.DrawStringCentered(filaExamen("NOMBREDEPENDENCIA").ToString, Formato_Etiqueta_8R, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 180, PuntoOrigen.Y, PuntoOrigen.X + 180, PuntoOrigen.Y + 20)
            Dim Cargo As String = filaExamen("CARGO").ToString
            Select Case Cargo.Length
                Case Is < 26
                    e.Graphics.DrawStringCentered(Cargo, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Is < 41
                    e.Graphics.DrawStringCentered(Cargo, Formato_Etiqueta_7R, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Cargo)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 190, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 190, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 180, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 20)
            Dim EPS As String = filaExamen("EPS").ToString
            Select Case EPS.Length
                Case Is < 25
                    e.Graphics.DrawStringCentered(EPS, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                Case Is < 40
                    e.Graphics.DrawStringCentered(EPS, Formato_Etiqueta_7R, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                Case Is < 60
                    Cadenas.Add(EPS)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_6R, 200, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 190, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 370, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                Case Else
                    Cadenas.Add(EPS)
                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_5R, 210, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_5R, 190, e), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 370, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 560, PuntoOrigen.Y, PuntoOrigen.X + 560, PuntoOrigen.Y + 20)
            Dim TiempoCargo As String
            TiempoCargo = filaExamen("TIEMPOCARGOAÑOS").ToString + IIf(Convert.ToInt32(filaExamen("TIEMPOCARGOAÑOS").ToString) = 1, " año", " años").ToString + ", " + filaExamen("TIEMPOCARGOMESES").ToString + IIf(Convert.ToInt32(filaExamen("TIEMPOCARGOMESES").ToString) = 1, " mes", " meses").ToString
            e.Graphics.DrawStringCentered(TiempoCargo, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 650, PuntoOrigen.Y, PuntoOrigen.X + 650, PuntoOrigen.Y + 20)
            Dim FechaIngreso As String = filaExamen("FECHAINGRESOEMPRESA").ToString
            If FechaIngreso <> "" Then
                FechaIngreso = Convert.ToDateTime(FechaIngreso).ToShortDateString
            End If

            e.Graphics.DrawStringCentered(FechaIngreso, Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 650, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
        End If

        If TipoExamen <> "I" Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("DESCRIPCIÓN DEL CARGO", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("TAREA", Formato_Etiqueta_8, Brocha, 305, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 325, PuntoOrigen.Y, PuntoOrigen.X + 325, PuntoOrigen.Y + 20)
            e.Graphics.DrawStringCentered("AGENTE", Formato_Etiqueta_8, Brocha, 240, PuntoOrigen.X + 325, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 565, PuntoOrigen.Y, PuntoOrigen.X + 565, PuntoOrigen.Y + 20)
            e.Graphics.DrawStringCentered("MAGNITUD", Formato_Etiqueta_8, Brocha, 75, PuntoOrigen.X + 565, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 640, PuntoOrigen.Y, PuntoOrigen.X + 640, PuntoOrigen.Y + 20)
            e.Graphics.DrawStringCentered("FRECUENCIA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 640, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            'Se imprime las cadenas faltantes
            Dim InicioYTarea As Integer = PuntoOrigen.Y
            Dim InicioYTarea2 As Integer = PuntoOrigen.Y

            Dim suma As Integer = 0
            If dtTareas IsNot Nothing Then
                If dtTareas.Rows.Count > 0 Then
                    suma = 0
                    For i As Integer = TareaFaltantei To dtTareas.Rows.Count - 1
                        If ContadorRenglones > 0 Then
                            Dim FilaTarea As DataRow = dtTareas.Rows(i)
                            Dim Renglones As Integer = 0
                            Dim CantidadRenglonesTarea As Integer = 0
                            Dim CantidadRenglonesAgente As Integer = 0
                            Dim CantidadRenglonesFrecuencia As Integer = 0
                            Dim Tarea As String = Replace(FilaTarea("TAREA").ToString, vbLf, "")
                            Dim Agente As String = Replace(FilaTarea("AGENTE").ToString, vbLf, "")
                            Dim Magnitud As String = ""
                            Dim Frecuencia As String = Replace(FilaTarea("FRECUENCIA").ToString, vbLf, "")

                            If FilaTarea("MAGNITUD").ToString = "D" Then
                                Magnitud += "Día"
                            Else
                                If FilaTarea("MAGNITUD").ToString = "S" Then
                                    Magnitud += "Semana"

                                Else
                                    If FilaTarea("MAGNITUD").ToString = "M" Then
                                        Magnitud += "Mes"
                                    Else
                                        If FilaTarea("MAGNITUD").ToString = "A" Then
                                            Magnitud += "Año"
                                        End If
                                    End If
                                End If
                            End If

                            Select Case Tarea.Length
                                Case Is < 40
                                    e.Graphics.DrawString(Tarea, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, InicioYTarea + 3)
                                    CantidadRenglonesTarea += 1
                                Case Is < 50
                                    e.Graphics.DrawString(Tarea, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 5, InicioYTarea + 3)
                                    CantidadRenglonesTarea += 1
                                Case Else
                                    Cadenas.Add(Trim(Tarea))
                                    CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 320, e)
                                    Dim otralinea As Integer = 20
                                    Dim puntoobservacion As Integer = InicioYTarea
                                    If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                        CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                                    End If
                                    Dim ContadorRenglonesTemp As Integer = ContadorRenglones
                                    For j As Integer = 0 To CadenasTotal.Count - 1
                                        If ContadorRenglonesTemp > 0 Then
                                            e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 320, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 3, puntoobservacion + 3)
                                            puntoobservacion += otralinea
                                            CantidadRenglonesTarea += 1
                                            ContadorRenglonesTemp -= 1
                                            PendientesTarea = False
                                        Else
                                            SubCadenaFaltante.Add(CadenasTotal(j))
                                            PendientesTarea = True
                                        End If
                                    Next
                                    Cadenas.Clear()
                                    CadenasTotal.Clear()
                            End Select

                            Select Case Agente.Length
                                Case Is < 41
                                    e.Graphics.DrawString(Agente, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 330, InicioYTarea + 3)
                                    CantidadRenglonesAgente += 1
                                Case Is < 51
                                    e.Graphics.DrawString(Agente, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 330, InicioYTarea + 3)
                                    CantidadRenglonesAgente += 1
                            End Select

                            e.Graphics.DrawString(Magnitud, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 570, InicioYTarea + 3)


                            e.Graphics.DrawString(Frecuencia, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 645, InicioYTarea + 3)

                            If PendientesAgente = False And PendientesTarea = False And PendientesFrecuencia = False Then
                                BloqueTareas = True
                            Else
                                BloqueTareas = False
                            End If

                            If CantidadRenglonesAgente > CantidadRenglonesTarea And CantidadRenglonesAgente > CantidadRenglonesFrecuencia Then
                                Renglones = CantidadRenglonesAgente
                            Else
                                If CantidadRenglonesTarea > CantidadRenglonesFrecuencia Then
                                    Renglones = CantidadRenglonesTarea
                                Else
                                    Renglones = CantidadRenglonesFrecuencia
                                End If
                            End If

                            TareaFaltantei += 1
                            ContadorRenglones -= Renglones
                            InicioYTarea += Renglones * 20
                            suma += Renglones * 20
                            If i < dtTareas.Rows.Count - 1 Then
                                If ContadorRenglones > 0 Then
                                    e.Graphics.DrawLine(lineaPunteada, PuntoOrigen.X, InicioYTarea, PuntoOrigen.X + 730, InicioYTarea)
                                End If
                            End If
                        Else
                            TamañoY = PuntoOrigen.Y - 55
                            If i <= dtTareas.Rows.Count - 1 Then
                                BloqueTareas = False
                            End If
                        End If
                    Next
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 325, InicioYTarea2, PuntoOrigen.X + 325, InicioYTarea)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 565, InicioYTarea2, PuntoOrigen.X + 565, InicioYTarea)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 640, InicioYTarea2, PuntoOrigen.X + 640, InicioYTarea)
                    PuntoOrigen.Y += suma
                End If
            Else
                BloqueTareas = True
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
            End If
        End If

        If TipoExamen = "I" Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("DICTAMEN", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 169, 19)
            e.Graphics.DrawString("Recomendado para el cargo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 170, PuntoOrigen.Y, PuntoOrigen.X + 170, PuntoOrigen.Y + 20)
            e.Graphics.DrawString(IIf(filaExamen("RECOMENDADOCARGO").ToString = "S", "Si", "No"), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            Dim RecomendadoTrabajo As String = filaExamen("APTOTIPOTRABAJO").ToString

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Recomendado trabajo en alturas", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(RecomendadoTrabajo(0) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 205, PuntoOrigen.Y + 1, 219, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Recomendado trabajo en excavaciones", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 425, PuntoOrigen.Y, PuntoOrigen.X + 425, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(RecomendadoTrabajo(1) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 445, PuntoOrigen.Y + 1, 259, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 445, PuntoOrigen.Y, PuntoOrigen.X + 445, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Recomendado trabajo en espacios confinados", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 705, PuntoOrigen.Y, PuntoOrigen.X + 705, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(RecomendadoTrabajo(2) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 710, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
        End If

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        e.Graphics.DrawStringCentered("CONCEPTO MEDICO", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20
        Dim Concepto As String = filaExamen("CONCEPTO").ToString
        If Concepto.Length > 0 Then
            Cadenas.Add(Trim(Concepto))
            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 750, e)
            Dim otralinea As Integer = 20
            Dim puntoobservacion As Integer = PuntoOrigen.Y
            Dim Renglones As Integer = 0
            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
            End If
            For j As Integer = 0 To CadenasTotal.Count - 1
                If ContadorRenglones > 0 Then
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                    puntoobservacion += otralinea
                    ContadorRenglones -= 1
                    Renglones += 1
                End If
            Next
            PuntoOrigen.Y += Renglones * 20
            Cadenas.Clear()
            CadenasTotal.Clear()
        End If
        PuntoOrigen.Y += 20
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
        e.Graphics.DrawStringCentered("RECOMENDACIONES", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20

        Dim Recomendaciones As String = filaExamen("RECOMENDACIONES").ToString
        If Recomendaciones.Length > 0 Then
            Cadenas.Add(Trim(Recomendaciones))
            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 750, e)
            Dim otralinea As Integer = 20
            Dim puntoobservacion As Integer = PuntoOrigen.Y
            Dim Renglones As Integer = 0
            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
            End If
            For j As Integer = 0 To CadenasTotal.Count - 1
                If ContadorRenglones > 0 Then
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                    puntoobservacion += otralinea
                    ContadorRenglones -= 1
                    Renglones += 1
                End If
            Next
            PuntoOrigen.Y += Renglones * 20
            Cadenas.Clear()
            CadenasTotal.Clear()
        End If
        PuntoOrigen.Y += 20
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa

        If TipoExamen = "I" Or TipoExamen = "P" Then
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("PROGRAMAS DE VIGILANCIA EPIDEMIOLÓGICA QUE LE APLICAN", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
            PuntoOrigen.Y += 20

            Dim Vigilancia As String = filaExamen("PROGRAMASVIGILANCIA").ToString
            Dim ch As Char = Vigilancia(0)
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawString("Biomecánico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 121, PuntoOrigen.Y, PuntoOrigen.X + 121, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 126, PuntoOrigen.Y + 5)
            End If

            ch = Vigilancia(1)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 183, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Auditivo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 303, PuntoOrigen.Y, PuntoOrigen.X + 303, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 308, PuntoOrigen.Y + 5)
            End If
            ch = Vigilancia(2)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 364, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 363, PuntoOrigen.Y, PuntoOrigen.X + 363, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Cardiovascular", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 368, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 484, PuntoOrigen.Y, PuntoOrigen.X + 484, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 490, PuntoOrigen.Y + 5)
            End If

            ch = Vigilancia(3)
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 547, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 546, PuntoOrigen.Y, PuntoOrigen.X + 546, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Respiratorio", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 667, PuntoOrigen.Y, PuntoOrigen.X + 667, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 672, PuntoOrigen.Y + 5)
            End If

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20

            ch = Vigilancia(4)
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawString("Dermatológico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 121, PuntoOrigen.Y, PuntoOrigen.X + 121, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 126, PuntoOrigen.Y + 5)
            End If
            ch = Vigilancia(5)
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 183, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Psicosocial", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 303, PuntoOrigen.Y, PuntoOrigen.X + 303, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 308, PuntoOrigen.Y + 5)
            End If


            Try
                ch = Vigilancia(6)
            Catch ex As Exception
                ch = ""
            End Try

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 364, PuntoOrigen.Y + 1, 120, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 363, PuntoOrigen.Y, PuntoOrigen.X + 363, PuntoOrigen.Y + 20)
            e.Graphics.DrawString("Visual", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 368, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 484, PuntoOrigen.Y, PuntoOrigen.X + 484, PuntoOrigen.Y + 20)
            If ch = "S" Then
                e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 490, PuntoOrigen.Y + 5)
            End If
            PuntoOrigen.Y += 20
        End If


        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa

        'PuntoOrigen.Y += 20
        If TipoExamen = "I" Or TipoExamen = "P" Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 730, 19)
            e.Graphics.DrawStringCentered("EXAMENES PARACLINICOS REALIZADOS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            Dim Laboratorios As String = filaExamen("LABORATORIOSREALIZADOS").ToString

            'e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Audiometria", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(0) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 205, PuntoOrigen.Y + 1, 219, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Glicemia Basal", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 425, PuntoOrigen.Y, PuntoOrigen.X + 425, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(5) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 445, PuntoOrigen.Y + 1, 259, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 445, PuntoOrigen.Y, PuntoOrigen.X + 445, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("KOH, Coprológico, Frotis Faringeo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 705, PuntoOrigen.Y, PuntoOrigen.X + 705, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(10) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 710, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Visiometría", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(1) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 205, PuntoOrigen.Y + 1, 219, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Perfil Hepático", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 425, PuntoOrigen.Y, PuntoOrigen.X + 425, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(6) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 445, PuntoOrigen.Y + 1, 259, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 445, PuntoOrigen.Y, PuntoOrigen.X + 445, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Rx Columna Dinámica", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 705, PuntoOrigen.Y, PuntoOrigen.X + 705, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(11) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 710, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20


            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Espirometría", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(2) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 205, PuntoOrigen.Y + 1, 219, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Test de Fobias", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 425, PuntoOrigen.Y, PuntoOrigen.X + 425, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(7) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 445, PuntoOrigen.Y + 1, 259, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 445, PuntoOrigen.Y, PuntoOrigen.X + 445, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("RMN Columna Lumbosacra", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 705, PuntoOrigen.Y, PuntoOrigen.X + 705, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(12) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 710, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Cuadro Hemático", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(3) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 205, PuntoOrigen.Y + 1, 219, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Electrocardiograma", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 425, PuntoOrigen.Y, PuntoOrigen.X + 425, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(8) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 445, PuntoOrigen.Y + 1, 259, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 445, PuntoOrigen.Y, PuntoOrigen.X + 445, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Sensopsicométrico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 705, PuntoOrigen.Y, PuntoOrigen.X + 705, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(13) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 710, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Perfil Lipídico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(4) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 205, PuntoOrigen.Y + 1, 219, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Rx Tórax", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 425, PuntoOrigen.Y, PuntoOrigen.X + 425, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(9) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 430, PuntoOrigen.Y + 5)

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 445, PuntoOrigen.Y + 1, 259, 19)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 445, PuntoOrigen.Y, PuntoOrigen.X + 445, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString("Parcial de Orina", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 705, PuntoOrigen.Y, PuntoOrigen.X + 705, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(14) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 710, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 184, 19)
            e.Graphics.DrawString("Otros", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 185, PuntoOrigen.Y, PuntoOrigen.X + 185, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(IIf(Laboratorios(15) = "S", "X", ""), Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 190, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 205, PuntoOrigen.Y, PuntoOrigen.X + 205, PuntoOrigen.Y + 20) 'Linea Vertical
            e.Graphics.DrawString(filaExamen("OTROSLABORATORIOS").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 210, PuntoOrigen.Y + 5)
            PuntoOrigen.Y += 20
        End If

        e.Graphics.DrawLine(Lapiz_Mediano, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa

        If TipoExamen = "I" Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("LEGALIDAD", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
        End If

        Dim Texto As String = ""
        Texto += "Este documento hace parte de la historia clínica electrónica ocupacional y su contenido pleno es inmodificable. El trabajador manifiesta"
        Texto += " conocer el contenido registrado en el ""Examen Médico " + TipoExamenLegalidad + """; el cual cumple con lo dispuesto en la Resolución 2346 de 2007."
        Texto += " Se manifiesta informado de las medidas preventivas y correctivas en el cuidado de su salud. Autoriza al suscrito Médico para que"
        Texto += " custodie su Historia Clínica Ocupacional cumpliendo con el ordenamiento de la Resolución 1918 de 2009 y Resolución 839 de 2017."
        Texto += " Su uso y copias solo pueden ser divulgadas en el momento y modo descritos por la Ley."
        If Texto.Length > 0 Then
            Cadenas.Add(Trim(Texto))
            CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
            Dim otralinea As Integer = 20
            Dim puntoobservacion As Integer = PuntoOrigen.Y
            Dim Renglones As Integer = 0
            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
            End If
            For j As Integer = 0 To CadenasTotal.Count - 1
                If ContadorRenglones > 0 Then
                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                    puntoobservacion += otralinea
                    ContadorRenglones -= 1
                    Renglones += 1
                End If
            Next
            PuntoOrigen.Y += Renglones * 20
            Cadenas.Clear()
            CadenasTotal.Clear()
        End If
        e.Graphics.DrawLine(Lapiz_Mediano, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 365, PuntoOrigen.Y, PuntoOrigen.X + 365, PuntoOrigen.Y + 60)
        PuntoOrigen.Y += 60

        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa

        e.Graphics.DrawStringCentered("Firma del Trabajador", Formato_Etiqueta_8, Brocha, 365, PuntoOrigen.X, PuntoOrigen.Y + 5)
        e.Graphics.DrawStringCentered("Firma Médico Especialista S.O.", Formato_Etiqueta_8, Brocha, 365, PuntoOrigen.X + 365, PuntoOrigen.Y + 5)

        TamañoYExamen = PuntoOrigen.Y + 20
        Dim PuntoOrigen2 As New Point(55, 30)
        e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen2.X, PuntoOrigen2.Y, 730, TamañoYExamen - 30)

        ContadorPaginasExamen += 1
        Dim CantidadPaginas As String = ""
        If ImprimirPieDePagina Then
            CantidadPaginas = "Página " + ContadorPaginasExamen.ToString + " de " + PaginasTotalExamen.ToString
        Else
            CantidadPaginas = "Página " + ContadorPaginasExamen.ToString
        End If
        e.Graphics.DrawStringCentered(CantidadPaginas, Formato_Etiqueta_8, Brocha, e.PageBounds.Width, 0, TamañoYExamen + 10)
        TerminadoExamen = True

        If ImpresionExamen = True Then
            If ContadorPaginasExamen = PaginasTotalExamen Then
                BloquearExamen()
            End If
        End If

        If TerminadoExamen = True Then
            e.HasMorePages = False
            ImprimirPieDePagina = True
            PaginasTotalExamen = ContadorPaginasExamen
            ContadorPaginasExamen = 0
            BloqueImpresionExamen = 0
            BloqueTareas = False
            TareaFaltantei = 0
            TerminadoExamen = False
            Exit Sub
        Else
            e.HasMorePages = True
        End If
    End Sub

    Private Sub BloquearExamen()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TIPO", 17)
            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IdExamen)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "105 - Formato Historia Clinica Examen Medico Ingreso ICH-GRAL-F-302"
    Private WithEvents DocImp_ICHGRALF302 As New PrintDocument

    'Contadores para llevar la cuenta en caso de que no se impriman todos los item en una pagina
    Dim AntecedentesLaboralesFaltantei As Integer = 0
    Dim RiesgosLaboralesFaltantei As Integer = 0
    Dim VacunacionFaltantei As Integer = 0
    Dim DiagnosticoFaltantei As Integer = 0
    Dim ContadorPaginasHC As Integer = 0
    Dim PaginasTotalHC As Integer = 0


    Private Sub DocImpr_ICHGRALF302(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF302.PrintPage
        If ContadorPaginasHC = 0 Then
            CargarHistoriaClinica()
        End If
        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)
        Dim TipoExamen As String = filaExamen("TIPOEXAMEN").ToString
        Dim Titulo As String = "EXAMEN MÉDICO INGRESO"
        Dim ICH As String = "ICH-GRAL-F-302"
        Dim Revision As String = "Revisión No. 7"

        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        Dim CantidadRenglones As Integer = 0
        Dim ContadorRenglones As Integer = 0

        Dim PuntoOrigen As New Point(55, 30)
        TamañoYExamen = 985

        Dim TamañoImagenX As Integer = 80
        e.Graphics.DrawImage(logoIsmocol, PuntoOrigen.X + 10, PuntoOrigen.Y + 5, TamañoImagenX, TamañoImagenX - 20)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 100, PuntoOrigen.Y, PuntoOrigen.X + 100, PuntoOrigen.Y + 70) 'Vertical
        e.Graphics.DrawStringCentered(Titulo, Formato_Etiqueta_12, Brocha, 480, 180, PuntoOrigen.Y + 25)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y, 660, PuntoOrigen.Y + 70) 'Vertical
        e.Graphics.DrawStringCentered(ICH, Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 10)
        e.Graphics.DrawLine(Lapiz, 660, PuntoOrigen.Y + 35, 785, PuntoOrigen.Y + 35) 'Horizontal
        e.Graphics.DrawStringCentered(Revision, Formato_Etiqueta_9, Brocha, 125, 660, PuntoOrigen.Y + 45)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 70, PuntoOrigen.X + 730, PuntoOrigen.Y + 70) 'Horizontal completa

        PuntoOrigen.Y += 70
        ContadorRenglones = (1040 - PuntoOrigen.Y) / 20

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 149, 19)
        e.Graphics.DrawString("FECHA DEL EXAMEN", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 150, PuntoOrigen.Y, PuntoOrigen.X + 150, PuntoOrigen.Y + 20)
        e.Graphics.DrawString(Convert.ToDateTime(filaExamen("FECHAEXAMENMEDICO").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 155, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 250, PuntoOrigen.Y, PuntoOrigen.X + 250, PuntoOrigen.Y + 20)

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 251, PuntoOrigen.Y + 1, 49, 19)
        e.Graphics.DrawString("C.C.", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 255, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 300, PuntoOrigen.Y, PuntoOrigen.X + 300, PuntoOrigen.Y + 20)
        e.Graphics.DrawString(filaExamen("IDENTIFICACION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 305, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz_Mediano, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20
        ContadorRenglones -= 1

        If BloqueImpresionExamen = 0 Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("DATOS PERSONALES", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("NOMBRE COMPLETO", Formato_Etiqueta_8, Brocha, 350, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 350, PuntoOrigen.Y, PuntoOrigen.X + 350, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("FECHA DE NACIMIENTO", Formato_Etiqueta_8, Brocha, 150, PuntoOrigen.X + 350, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 500, PuntoOrigen.Y, PuntoOrigen.X + 500, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("EDAD", Formato_Etiqueta_8, Brocha, 50, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 550, PuntoOrigen.Y, PuntoOrigen.X + 550, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("RH", Formato_Etiqueta_8, Brocha, 40, PuntoOrigen.X + 550, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 600, PuntoOrigen.Y, PuntoOrigen.X + 600, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("DOMINANCIA", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X + 600, PuntoOrigen.Y + 5)

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.DrawStringCentered(filaExamen("NOMBRE").ToString, Formato_Etiqueta_8R, Brocha, 350, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(Convert.ToDateTime(filaExamen("FECHANACIMIENTO").ToString).ToShortDateString, Formato_Etiqueta_8R, Brocha, 150, PuntoOrigen.X + 350, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("EDAD").ToString, Formato_Etiqueta_8R, Brocha, 50, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("GRUPOSANGUINEO").ToString, Formato_Etiqueta_8R, Brocha, 40, PuntoOrigen.X + 550, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("DOMINANCIA").ToString, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X + 600, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("GENERO", Formato_Etiqueta_8, Brocha, 60, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 60, PuntoOrigen.Y, PuntoOrigen.X + 60, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("ESTADO CIVIL", Formato_Etiqueta_8, Brocha, 100, PuntoOrigen.X + 60, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 160, PuntoOrigen.Y, PuntoOrigen.X + 160, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("ESCOLARIDAD", Formato_Etiqueta_8, Brocha, 100, PuntoOrigen.X + 160, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 260, PuntoOrigen.Y, PuntoOrigen.X + 260, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("PROFESIÓN", Formato_Etiqueta_8, Brocha, 155, PuntoOrigen.X + 260, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 415, PuntoOrigen.Y, PuntoOrigen.X + 415, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("EPS", Formato_Etiqueta_8, Brocha, 155, PuntoOrigen.X + 415, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 570, PuntoOrigen.Y, PuntoOrigen.X + 570, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("FONDO DE PENSIÓN", Formato_Etiqueta_8, Brocha, 155, PuntoOrigen.X + 570, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.DrawStringCentered(filaExamen("GENERO").ToString, Formato_Etiqueta_8R, Brocha, 60, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("ESTADOCIVIL").ToString, Formato_Etiqueta_8R, Brocha, 100, PuntoOrigen.X + 60, PuntoOrigen.Y + 5)
            e.Graphics.DrawStringCentered(filaExamen("ESCOLARIDAD").ToString, Formato_Etiqueta_8R, Brocha, 100, PuntoOrigen.X + 160, PuntoOrigen.Y + 5)
            Dim Profesion As String = filaExamen("ESCOLARIDAD").ToString
            Dim TamañoProfesion As Integer = Profesion.Length
            Select Case Profesion.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(Profesion, Formato_Etiqueta_8R, Brocha, 155, PuntoOrigen.X + 260, PuntoOrigen.Y + 5)
                Case Is < 26
                    e.Graphics.DrawStringCentered(Profesion, Formato_Etiqueta_7R, Brocha, 155, PuntoOrigen.X + 260, PuntoOrigen.Y + 5)
                Case Is < 31
                    e.Graphics.DrawStringCentered(Profesion, Formato_Etiqueta_6R, Brocha, 155, PuntoOrigen.X + 260, PuntoOrigen.Y + 5)
                Case Is < 61
                    e.Graphics.DrawString(Profesion.Substring(0, 30), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 263, PuntoOrigen.Y + 2)
                    TamañoProfesion = TamañoProfesion - 30
                    e.Graphics.DrawString(Profesion.Substring(30, TamañoProfesion), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 263, PuntoOrigen.Y + 10)
                Case Else
                    e.Graphics.DrawString(Profesion.Substring(0, 34), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 262, PuntoOrigen.Y)
                    e.Graphics.DrawString(Profesion.Substring(34, 34), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 262, PuntoOrigen.Y + 6)
                    TamañoProfesion = TamañoProfesion - 68
                    e.Graphics.DrawString(Profesion.Substring(68, TamañoProfesion), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 262, PuntoOrigen.Y + 12)
            End Select

            Dim EPS As String = filaExamen("EPS").ToString
            Select Case EPS.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(EPS, Formato_Etiqueta_8R, Brocha, 155, PuntoOrigen.X + 415, PuntoOrigen.Y + 5)
                Case Else
                    e.Graphics.DrawStringCentered(EPS, Formato_Etiqueta_7R, Brocha, 155, PuntoOrigen.X + 415, PuntoOrigen.Y + 5)
            End Select

            Dim AFP As String = filaExamen("AFP").ToString
            Select Case AFP.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(AFP, Formato_Etiqueta_8R, Brocha, 155, PuntoOrigen.X + 570, PuntoOrigen.Y + 5)
                Case Else
                    e.Graphics.DrawStringCentered(AFP, Formato_Etiqueta_7R, Brocha, 155, PuntoOrigen.X + 570, PuntoOrigen.Y + 5)
            End Select

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("CIUDAD", Formato_Etiqueta_8, Brocha, 200, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("DIRECCIÓN", Formato_Etiqueta_8, Brocha, 250, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 450, PuntoOrigen.Y, PuntoOrigen.X + 450, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("MOVIL", Formato_Etiqueta_8, Brocha, 70, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 520, PuntoOrigen.Y, PuntoOrigen.X + 520, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("CORREO ELECTRÓNICO", Formato_Etiqueta_8, Brocha, 210, PuntoOrigen.X + 520, PuntoOrigen.Y + 5)

            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            Dim Ciudad As String = Trim(filaExamen("CIUDAD").ToString)
            Dim TamañoCiudad = Ciudad.Length
            Select Case Ciudad.Length
                Case Is < 31
                    e.Graphics.DrawStringCentered(Ciudad, Formato_Etiqueta_8R, Brocha, 200, PuntoOrigen.X, PuntoOrigen.Y + 5)
                Case Is < 41
                    e.Graphics.DrawStringCentered(Ciudad, Formato_Etiqueta_6R, Brocha, 200, PuntoOrigen.X, PuntoOrigen.Y + 5)
                Case Is < 51
                    e.Graphics.DrawStringCentered(Ciudad, Formato_Etiqueta_5R, Brocha, 200, PuntoOrigen.X, PuntoOrigen.Y + 5)
                Case Is < 81
                    e.Graphics.DrawString(Ciudad.Substring(0, 40), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X, PuntoOrigen.Y + 2)
                    TamañoCiudad = TamañoCiudad - 40
                    e.Graphics.DrawString(Ciudad.Substring(40, TamañoCiudad), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X, PuntoOrigen.Y + 10)
                Case Else
                    e.Graphics.DrawString(Ciudad.Substring(0, 39), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 2, PuntoOrigen.Y)
                    e.Graphics.DrawString(Ciudad.Substring(39, 39), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 2, PuntoOrigen.Y + 6)
                    TamañoCiudad = TamañoCiudad - 78
                    e.Graphics.DrawString(Ciudad.Substring(78, TamañoCiudad), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 2, PuntoOrigen.Y + 12)
            End Select

            Dim Direccion As String = Trim(filaExamen("DIRECCION").ToString)
            Dim TamañoDireccion = Direccion.Length
            Select Case Direccion.Length
                Case Is < 36
                    e.Graphics.DrawStringCentered(Direccion, Formato_Etiqueta_8R, Brocha, 250, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                Case Is < 41
                    e.Graphics.DrawStringCentered(Direccion, Formato_Etiqueta_7R, Brocha, 250, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                Case Is < 61
                    e.Graphics.DrawStringCentered(Direccion, Formato_Etiqueta_5R, Brocha, 250, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                Case Is < 91
                    e.Graphics.DrawString(Direccion.Substring(0, 45), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 200, PuntoOrigen.Y + 2)
                    TamañoDireccion = TamañoDireccion - 45
                    e.Graphics.DrawString(Direccion.Substring(45, TamañoDireccion), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 200, PuntoOrigen.Y + 10)
                Case Else
                    e.Graphics.DrawString(Direccion.Substring(0, 50), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 202, PuntoOrigen.Y)
                    e.Graphics.DrawString(Direccion.Substring(50, 50), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 202, PuntoOrigen.Y + 6)
                    TamañoDireccion = TamañoDireccion - 100
                    e.Graphics.DrawString(Direccion.Substring(100, TamañoDireccion), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 202, PuntoOrigen.Y + 12)
            End Select

            e.Graphics.DrawStringCentered(filaExamen("TELEFONOMOVIL").ToString, Formato_Etiqueta_8R, Brocha, 70, PuntoOrigen.X + 450, PuntoOrigen.Y + 5)

            Dim Correo As String = Trim(filaExamen("CORREOELECTRONICO").ToString)
            Dim TamañoCorreo = Correo.Length
            Select Case Correo.Length
                Case Is < 31
                    e.Graphics.DrawStringCentered(Correo, Formato_Etiqueta_8R, Brocha, 210, PuntoOrigen.X + 520, PuntoOrigen.Y + 5)
                Case Is < 41
                    e.Graphics.DrawStringCentered(Correo, Formato_Etiqueta_6R, Brocha, 210, PuntoOrigen.X + 520, PuntoOrigen.Y + 5)
                Case Is < 51
                    e.Graphics.DrawStringCentered(Correo, Formato_Etiqueta_5R, Brocha, 210, PuntoOrigen.X + 520, PuntoOrigen.Y + 5)
                Case Else
                    e.Graphics.DrawString(Correo.Substring(0, 30), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 525, PuntoOrigen.Y + 2)
                    TamañoCorreo = TamañoCorreo - 30
                    e.Graphics.DrawString(Correo.Substring(30, TamañoCorreo), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 525, PuntoOrigen.Y + 10)
            End Select
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("PROYECTO Y SEDE", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1

            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("PROYECTO", Formato_Etiqueta_8, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 180, PuntoOrigen.Y, PuntoOrigen.X + 180, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("BASE", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_8, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 560, PuntoOrigen.Y, PuntoOrigen.X + 560, PuntoOrigen.Y + 40)
            e.Graphics.DrawStringCentered("MUNICIPIO", Formato_Etiqueta_8, Brocha, 170, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            e.Graphics.DrawStringCentered(filaExamen("PROYECTO").ToString, Formato_Etiqueta_8R, Brocha, 180, PuntoOrigen.X, PuntoOrigen.Y + 5)
            Dim Base As String = filaExamen("BASE").ToString
            Select Case Base.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(Base, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Is < 31
                    e.Graphics.DrawStringCentered(Base, Formato_Etiqueta_7R, Brocha, 190, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Base)
                    CadenasTotal = TextoAParrafoFuente2(Cadenas, Formato_Etiqueta_6R, 185, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 185, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 182, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            Dim Cargo As String = filaExamen("CARGO").ToString
            Select Case Cargo.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(Cargo, Formato_Etiqueta_8R, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                Case Is < 31
                    e.Graphics.DrawStringCentered(Cargo, Formato_Etiqueta_7R, Brocha, 190, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                Case Else
                    Cadenas.Add(Cargo)
                    CadenasTotal = TextoAParrafoFuente2(Cadenas, Formato_Etiqueta_6R, 185, e)
                    Dim otralinea As Integer = 7
                    Dim puntoobservacion As Integer = PuntoOrigen.Y + 2
                    For i As Integer = 0 To CadenasTotal.Count - 1
                        e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_6R, 185, e), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 372, puntoobservacion)
                        puntoobservacion += otralinea
                    Next
                    Cadenas.Clear()
                    CadenasTotal.Clear()
            End Select

            Dim CiudadContrato As String = Trim(filaExamen("CIUDADCONTRATO").ToString)

            Dim TamañoCiudadContrato = CiudadContrato.Length
            Select Case CiudadContrato.Length
                Case Is < 21
                    e.Graphics.DrawStringCentered(CiudadContrato, Formato_Etiqueta_8R, Brocha, 170, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
                Case Is < 31
                    e.Graphics.DrawStringCentered(CiudadContrato, Formato_Etiqueta_6R, Brocha, 170, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
                Case Is < 41
                    e.Graphics.DrawStringCentered(CiudadContrato, Formato_Etiqueta_5R, Brocha, 170, PuntoOrigen.X + 560, PuntoOrigen.Y + 5)
                Case Is < 61
                    e.Graphics.DrawString(CiudadContrato.Substring(0, 30), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 565, PuntoOrigen.Y + 2)
                    TamañoCiudadContrato = TamañoCiudadContrato - 30
                    e.Graphics.DrawString(CiudadContrato.Substring(30, TamañoCiudadContrato), Formato_Etiqueta_6R, Brocha, PuntoOrigen.X + 565, PuntoOrigen.Y + 10)
                Case Else
                    e.Graphics.DrawString(CiudadContrato.Substring(0, 39), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 562, PuntoOrigen.Y)
                    e.Graphics.DrawString(CiudadContrato.Substring(39, 39), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 562, PuntoOrigen.Y + 6)
                    TamañoCiudadContrato = TamañoCiudadContrato - 78
                    e.Graphics.DrawString(CiudadContrato.Substring(78, TamañoCiudadContrato), Formato_Etiqueta_5R, Brocha, PuntoOrigen.X + 562, PuntoOrigen.Y + 12)
            End Select
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa

            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            BloqueImpresionExamen = 1
        End If

        If BloqueImpresionExamen = 1 Then
            e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
            e.Graphics.DrawStringCentered("ANTECEDENTES LABORALES", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
            PuntoOrigen.Y += 20
            ContadorRenglones -= 1
            BloqueImpresionExamen = 2
        End If

        If dtAntecedentesLaborales IsNot Nothing Then


            For i As Integer = AntecedentesLaboralesFaltantei To dtAntecedentesLaborales.Rows.Count - 1
                Dim FilaAntecedentes As DataRow = dtAntecedentesLaborales.Rows(i)

                If BloqueImpresionExamen = 2 Then
                    If ContadorRenglones > 1 Then
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                        e.Graphics.DrawStringCentered("EMPRESA", Formato_Etiqueta_8, Brocha, 370, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("TIEMPO TRABAJADO", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 500, PuntoOrigen.Y, PuntoOrigen.X + 500, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("ARL", Formato_Etiqueta_8, Brocha, 230, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1


                        e.Graphics.DrawStringCentered(FilaAntecedentes("NOMBREEMPRESA").ToString, Formato_Etiqueta_8R, Brocha, 370, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        Dim TiempoTrabajado As String = ""
                        If Not IsDBNull(FilaAntecedentes("TIEMPOTRABAJADOANOS")) And FilaAntecedentes("TIEMPOTRABAJADOANOS").ToString <> "" Then
                            If FilaAntecedentes("TIEMPOTRABAJADOANOS").ToString = "1" Then
                                TiempoTrabajado += FilaAntecedentes("TIEMPOTRABAJADOANOS").ToString + " año"
                            Else
                                TiempoTrabajado += FilaAntecedentes("TIEMPOTRABAJADOANOS").ToString + " años"
                            End If
                        End If
                        If Not IsDBNull(FilaAntecedentes("TIEMPOTRABAJADOMESES")) And FilaAntecedentes("TIEMPOTRABAJADOMESES").ToString <> "" Then
                            If TiempoTrabajado <> "" Then
                                TiempoTrabajado += " y "
                            End If

                            If FilaAntecedentes("TIEMPOTRABAJADOMESES") = 1 Then
                                TiempoTrabajado += FilaAntecedentes("TIEMPOTRABAJADOMESES").ToString + "mes"
                            Else
                                TiempoTrabajado += FilaAntecedentes("TIEMPOTRABAJADOMESES").ToString + "meses"
                            End If
                        End If
                        e.Graphics.DrawStringCentered(TiempoTrabajado, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("ARL").ToString), Formato_Etiqueta_8R, Brocha, 230, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)

                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                        BloqueImpresionExamen = 3
                    Else
                        TamañoYExamen = PuntoOrigen.Y - 30
                    End If
                End If


                If BloqueImpresionExamen = 3 Then
                    If ContadorRenglones > 1 Then
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                        e.Graphics.DrawStringCentered("JORNADA", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 80, PuntoOrigen.Y, PuntoOrigen.X + 80, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("TURNO", Formato_Etiqueta_8, Brocha, 120, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_8, Brocha, 450, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1

                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("JORNADA").ToString), Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        Dim Turno As String = FilaAntecedentes("TURNO").ToString
                        If Turno <> "" Then
                            If Turno = "1" Then
                                Turno = Turno + " hora"
                            Else
                                Turno = Turno + " horas"
                            End If
                        End If
                        e.Graphics.DrawStringCentered(Turno, Formato_Etiqueta_8R, Brocha, 120, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("CARGO").ToString), Formato_Etiqueta_8R, Brocha, 450, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                        BloqueImpresionExamen = 4
                    Else
                        TamañoYExamen = PuntoOrigen.Y - 30
                    End If
                End If

                If BloqueImpresionExamen = 4 Then
                    If ContadorRenglones > 2 Then
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                        e.Graphics.DrawStringCentered("ALTERACIÓN ESTADO DE SALUD EN EL PERIODO TRABAJADO", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1

                        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                        e.Graphics.DrawStringCentered("IT", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 80, PuntoOrigen.Y, PuntoOrigen.X + 80, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("ORIGEN", Formato_Etiqueta_8, Brocha, 120, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("DÍAS IT", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 280, PuntoOrigen.Y, PuntoOrigen.X + 280, PuntoOrigen.Y + 40)
                        e.Graphics.DrawStringCentered("SECUELA", Formato_Etiqueta_8, Brocha, 450, PuntoOrigen.X + 280, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1

                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("INCAPACIDAD").ToString), Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("ORIGEN").ToString), Formato_Etiqueta_8R, Brocha, 120, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("DIASINCAPACIDAD").ToString), Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                        e.Graphics.DrawStringCentered(Trim(FilaAntecedentes("SECUELA").ToString), Formato_Etiqueta_8R, Brocha, 450, PuntoOrigen.X + 280, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                        BloqueImpresionExamen = 5
                    Else
                        TamañoYExamen = PuntoOrigen.Y - 30
                    End If
                End If

                If BloqueImpresionExamen = 5 Then
                    If ContadorRenglones > 1 Then
                        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                        e.Graphics.DrawStringCentered("TIPO DE RIESGO", Formato_Etiqueta_8, Brocha, 370, PuntoOrigen.X, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 20)
                        e.Graphics.DrawStringCentered("AGENTE CAUSAL", Formato_Etiqueta_8, Brocha, 360, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1

                        Dim dtRiesgos As DataTable = Nothing
                        Try
                            dtRiesgos = dtAntecedenetesLaboralesRiesgos.Select("IDITEMANTECEDENTELABORAL =" + FilaAntecedentes("IDITEMANTECEDENTELABORAL").ToString).CopyToDataTable
                            If dtRiesgos IsNot Nothing Then

                                For j As Integer = RiesgosLaboralesFaltantei To dtRiesgos.Rows.Count - 1
                                    If ContadorRenglones > 1 Then
                                        e.Graphics.DrawStringCentered(dtRiesgos.Rows(j).Item("RIESGO").ToString, Formato_Etiqueta_8R, Brocha, 370, PuntoOrigen.X, PuntoOrigen.Y + 5)
                                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 20)
                                        e.Graphics.DrawStringCentered(dtRiesgos.Rows(j).Item("CAUSAL").ToString, Formato_Etiqueta_8R, Brocha, 360, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                                        PuntoOrigen.Y += 20
                                        ContadorRenglones -= 1
                                        RiesgosLaboralesFaltantei += 1
                                    End If
                                Next
                            End If

                            If AntecedentesLaboralesFaltantei = dtAntecedentesLaborales.Rows.Count - 1 And RiesgosLaboralesFaltantei = dtRiesgos.Rows.Count Then

                                BloqueImpresionExamen = 6

                                If ContadorRenglones < 1 Then
                                    TamañoYExamen = PuntoOrigen.Y - 30
                                End If
                            End If

                            If AntecedentesLaboralesFaltantei < dtAntecedentesLaborales.Rows.Count - 1 Then
                                BloqueImpresionExamen = 2
                                AntecedentesLaboralesFaltantei += 1
                            End If

                            If RiesgosLaboralesFaltantei = dtRiesgos.Rows.Count Then
                                RiesgosLaboralesFaltantei = 0
                            End If

                        Catch ex As Exception
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 20)
                            PuntoOrigen.Y += 20
                            ContadorRenglones -= 1
                            RiesgosLaboralesFaltantei += 1
                            AntecedentesLaboralesFaltantei += 1
                            If AntecedentesLaboralesFaltantei < dtAntecedentesLaborales.Rows.Count - 1 Then
                                BloqueImpresionExamen = 2
                                AntecedentesLaboralesFaltantei += 1
                                RiesgosLaboralesFaltantei = 0
                            Else
                                BloqueImpresionExamen = 6
                            End If

                        End Try



                    Else
                        TamañoYExamen = PuntoOrigen.Y - 30
                    End If
                End If

            Next

        Else
            If BloqueImpresionExamen = 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("EMPRESA", Formato_Etiqueta_8, Brocha, 370, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TIEMPO TRABAJADO", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 500, PuntoOrigen.Y, PuntoOrigen.X + 500, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("ARL", Formato_Etiqueta_8, Brocha, 230, PuntoOrigen.X + 500, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 40
                ContadorRenglones -= 2
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("JORNADA", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 80, PuntoOrigen.Y, PuntoOrigen.X + 80, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TURNO", Formato_Etiqueta_8, Brocha, 120, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("CARGO", Formato_Etiqueta_8, Brocha, 450, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 40
                ContadorRenglones -= 2
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("ALTERACIÓN ESTADO DE SALUD EN EL PERIODO TRABAJADO", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 2
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("IT", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 80, PuntoOrigen.Y, PuntoOrigen.X + 80, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("ORIGEN", Formato_Etiqueta_8, Brocha, 120, PuntoOrigen.X + 80, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 200, PuntoOrigen.Y, PuntoOrigen.X + 200, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("DÍAS IT", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 200, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 280, PuntoOrigen.Y, PuntoOrigen.X + 280, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("SECUELA", Formato_Etiqueta_8, Brocha, 450, PuntoOrigen.X + 280, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 40
                ContadorRenglones -= 2
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("TIPO DE RIESGO", Formato_Etiqueta_8, Brocha, 370, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 370, PuntoOrigen.Y, PuntoOrigen.X + 370, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("AGENTE CAUSAL", Formato_Etiqueta_8, Brocha, 360, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 40
                ContadorRenglones -= 2
                BloqueImpresionExamen = 6
            End If
        End If

        If BloqueImpresionExamen = 6 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("ANTECEDENTES DE SALUD EN LA FAMILIA", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                Dim FilaAntecedenteFamiliar As DataRow = Nothing
                FilaAntecedenteFamiliar = dtAntecedentesPatologicos.Select("IDANTECEDENTE = 'F'").FirstOrDefault()
                If FilaAntecedenteFamiliar IsNot Nothing Then
                    e.Graphics.DrawString(FilaAntecedenteFamiliar("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 7
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 7 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("ANTECEDENTES GINECOBSTÉTRICOS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                Dim FilaAntecedenteClinico As DataRow = Nothing
                FilaAntecedenteClinico = dtAntecedentesPatologicos.Select("IDANTECEDENTE = 'G'").FirstOrDefault
                If FilaAntecedenteClinico IsNot Nothing Then
                    e.Graphics.DrawString(FilaAntecedenteClinico("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 8
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 8 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("ANTECEDENTES DE SALUD PERSONALES", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 9
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 9 Then
            If ContadorRenglones > 0 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 119, 19)
                e.Graphics.DrawString("CLÍNICOS", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 120, PuntoOrigen.Y, PuntoOrigen.X + 120, PuntoOrigen.Y + 20)
                Dim FilaAntecedenteClinico As DataRow = Nothing
                FilaAntecedenteClinico = dtAntecedentesPatologicos.Select("IDANTECEDENTE = 'P'").FirstOrDefault
                If FilaAntecedenteClinico IsNot Nothing Then
                    e.Graphics.DrawString(FilaAntecedenteClinico("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 10
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If
        If BloqueImpresionExamen = 10 Then
            If ContadorRenglones > 0 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 119, 19)
                e.Graphics.DrawString("ALÉRGICOS", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 120, PuntoOrigen.Y, PuntoOrigen.X + 120, PuntoOrigen.Y + 20)
                Dim FilaAntecedenteClinico As DataRow = Nothing
                FilaAntecedenteClinico = dtAntecedentesPatologicos.Select("IDANTECEDENTE = 'A'").FirstOrDefault
                If FilaAntecedenteClinico IsNot Nothing Then
                    e.Graphics.DrawString(FilaAntecedenteClinico("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 11
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If
        If BloqueImpresionExamen = 11 Then
            If ContadorRenglones > 0 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 119, 19)
                e.Graphics.DrawString("QUIRÚRGICOS", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 120, PuntoOrigen.Y, PuntoOrigen.X + 120, PuntoOrigen.Y + 20)
                Dim FilaAntecedenteClinico As DataRow = Nothing
                FilaAntecedenteClinico = dtAntecedentesPatologicos.Select("IDANTECEDENTE = 'Q'").FirstOrDefault
                If FilaAntecedenteClinico IsNot Nothing Then
                    e.Graphics.DrawString(FilaAntecedenteClinico("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawString(FilaAntecedenteClinico("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 12
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If
        If BloqueImpresionExamen = 12 Then
            If ContadorRenglones > 0 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 119, 19)
                e.Graphics.DrawString("MEDICAMENTOSOS", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 120, PuntoOrigen.Y, PuntoOrigen.X + 120, PuntoOrigen.Y + 20)
                Dim FilaAntecedenteClinico As DataRow = Nothing
                FilaAntecedenteClinico = dtAntecedentesPatologicos.Select("IDANTECEDENTE = 'M'").FirstOrDefault
                If FilaAntecedenteClinico IsNot Nothing Then
                    e.Graphics.DrawString(FilaAntecedenteClinico("DESCRIPCIONANTECEDENTE").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 125, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 13
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 13 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("HABITOS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 14
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 14 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("FUMADOR", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 130, PuntoOrigen.Y, PuntoOrigen.X + 130, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 220, PuntoOrigen.Y, PuntoOrigen.X + 220, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("FRECUENCIA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, PuntoOrigen.Y, PuntoOrigen.X + 310, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 390, PuntoOrigen.Y, PuntoOrigen.X + 390, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 390, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim FilaHabito As DataRow = dtHabitos.Select("IDHABITO = 1").FirstOrDefault
                If FilaHabito IsNot Nothing Then
                    e.Graphics.DrawStringCentered(FilaHabito("APLICA").ToString, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                    Dim Tiempo As String = ""
                    If FilaHabito("APLICA").ToString <> "No" Then
                        If FilaHabito("NUMTIEMPO").ToString <> "0" Then
                            Tiempo = FilaHabito("NUMTIEMPO").ToString + " " + FilaHabito("Tiempo").ToString
                            e.Graphics.DrawStringCentered(Tiempo, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("FRECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("INTENSIDAD").ToString, Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                        End If
                    End If
                    e.Graphics.DrawString(FilaHabito("ABANDONOHABITO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 395, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 15
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 15 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("BEBEDOR", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 130, PuntoOrigen.Y, PuntoOrigen.X + 130, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 220, PuntoOrigen.Y, PuntoOrigen.X + 220, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("FRECUENCIA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, PuntoOrigen.Y, PuntoOrigen.X + 310, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 390, PuntoOrigen.Y, PuntoOrigen.X + 390, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 390, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim FilaHabito As DataRow = dtHabitos.Select("IDHABITO = 2").FirstOrDefault
                If FilaHabito IsNot Nothing Then
                    e.Graphics.DrawStringCentered(FilaHabito("APLICA").ToString, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                    Dim Tiempo As String = ""
                    If FilaHabito("APLICA").ToString <> "No" Then
                        If FilaHabito("NUMTIEMPO").ToString <> "0" Then
                            Tiempo = FilaHabito("NUMTIEMPO").ToString + " " + FilaHabito("Tiempo").ToString
                            e.Graphics.DrawStringCentered(Tiempo, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("FRECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("INTENSIDAD").ToString, Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                        End If
                    End If
                    e.Graphics.DrawString(FilaHabito("ABANDONOHABITO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 395, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 16
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 16 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("PSICOTROPICOS", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 130, PuntoOrigen.Y, PuntoOrigen.X + 130, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 220, PuntoOrigen.Y, PuntoOrigen.X + 220, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("FRECUENCIA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, PuntoOrigen.Y, PuntoOrigen.X + 310, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 390, PuntoOrigen.Y, PuntoOrigen.X + 390, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 390, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim FilaHabito As DataRow = dtHabitos.Select("IDHABITO = 5").FirstOrDefault
                If FilaHabito IsNot Nothing Then
                    e.Graphics.DrawStringCentered(FilaHabito("APLICA").ToString, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                    Dim Tiempo As String = ""
                    If FilaHabito("APLICA").ToString <> "No" Then
                        If FilaHabito("NUMTIEMPO").ToString <> "0" Then
                            Tiempo = FilaHabito("NUMTIEMPO").ToString + " " + FilaHabito("Tiempo").ToString
                            e.Graphics.DrawStringCentered(Tiempo, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("FRECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("INTENSIDAD").ToString, Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                        End If
                    End If
                    e.Graphics.DrawString(FilaHabito("ABANDONOHABITO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 395, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 17
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 17 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("TRANSP. MOTO", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 130, PuntoOrigen.Y, PuntoOrigen.X + 130, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 220, PuntoOrigen.Y, PuntoOrigen.X + 220, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("FRECUENCIA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, PuntoOrigen.Y, PuntoOrigen.X + 310, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 390, PuntoOrigen.Y, PuntoOrigen.X + 390, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 390, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim FilaHabito As DataRow = dtHabitos.Select("IDHABITO = 4").FirstOrDefault
                If FilaHabito IsNot Nothing Then
                    e.Graphics.DrawStringCentered(FilaHabito("APLICA").ToString, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                    Dim Tiempo As String = ""
                    If FilaHabito("APLICA").ToString <> "No" Then
                        If FilaHabito("NUMTIEMPO").ToString <> "0" Then
                            Tiempo = FilaHabito("NUMTIEMPO").ToString + " " + FilaHabito("Tiempo").ToString
                            e.Graphics.DrawStringCentered(Tiempo, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("FRECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("INTENSIDAD").ToString, Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                        End If
                    End If
                    e.Graphics.DrawString(FilaHabito("ABANDONOHABITO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 395, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 18
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 18 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("DEPORTE", Formato_Etiqueta_8, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 130, PuntoOrigen.Y, PuntoOrigen.X + 130, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TIEMPO", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 220, PuntoOrigen.Y, PuntoOrigen.X + 220, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("FRECUENCIA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 310, PuntoOrigen.Y, PuntoOrigen.X + 310, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("CANTIDAD", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 390, PuntoOrigen.Y, PuntoOrigen.X + 390, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("OBSERVACIÓN", Formato_Etiqueta_8, Brocha, 300, PuntoOrigen.X + 390, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim FilaHabito As DataRow = dtHabitos.Select("IDHABITO = 3").FirstOrDefault
                If FilaHabito IsNot Nothing Then
                    e.Graphics.DrawStringCentered(FilaHabito("APLICA").ToString, Formato_Etiqueta_8R, Brocha, 130, PuntoOrigen.X, PuntoOrigen.Y + 5)
                    Dim Tiempo As String = ""
                    If FilaHabito("APLICA").ToString <> "No" Then
                        If FilaHabito("NUMTIEMPO").ToString <> "0" Then
                            Tiempo = FilaHabito("NUMTIEMPO").ToString + " " + FilaHabito("Tiempo").ToString
                            e.Graphics.DrawStringCentered(Tiempo, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 130, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("FRECUENCIA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 220, PuntoOrigen.Y + 5)
                            e.Graphics.DrawStringCentered(FilaHabito("INTENSIDAD").ToString, Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 310, PuntoOrigen.Y + 5)
                        End If
                    End If
                    e.Graphics.DrawString(FilaHabito("ABANDONOHABITO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 395, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 19
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 19 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("REVISIÓN POR SISTEMAS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim RevisionSistemas As String = Replace(filaExamen("REVISIONPORSISTEMA").ToString, vbLf, "")
                    If Trim(RevisionSistemas) <> "" Then
                        Cadenas.Add(RevisionSistemas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 20
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 20
                Else
                    BloqueImpresionExamen = 19
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 20 Then
            If ContadorRenglones > 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("SIGNOS VITALES Y DATOS ANTROPOMÉTRICOS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("T. SISTÓLICA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 90, PuntoOrigen.Y, PuntoOrigen.X + 90, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("T. DIASTÓLICA", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 90, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 180, PuntoOrigen.Y, PuntoOrigen.X + 180, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("F.C.", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 270, PuntoOrigen.Y, PuntoOrigen.X + 270, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("F.R.", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 270, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 360, PuntoOrigen.Y, PuntoOrigen.X + 360, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("PESO", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 360, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 440, PuntoOrigen.Y, PuntoOrigen.X + 440, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("TALLA", Formato_Etiqueta_8, Brocha, 80, PuntoOrigen.X + 440, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 520, PuntoOrigen.Y, PuntoOrigen.X + 520, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("IMC", Formato_Etiqueta_8, Brocha, 90, PuntoOrigen.X + 520, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 610, PuntoOrigen.Y, PuntoOrigen.X + 610, PuntoOrigen.Y + 40)
                e.Graphics.DrawStringCentered("PERIM. ADBOMEN", Formato_Etiqueta_8, Brocha, 120, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.DrawStringCentered(filaExamen("TENSIONSISTOLICA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawStringCentered(filaExamen("TENSIONDIASTOLICA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 90, PuntoOrigen.Y + 5)
                e.Graphics.DrawStringCentered(filaExamen("FRECUENCIACARDIACA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 180, PuntoOrigen.Y + 5)
                e.Graphics.DrawStringCentered(filaExamen("FRECUENCIARESPIRATORIA").ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 270, PuntoOrigen.Y + 5)
                e.Graphics.DrawStringCentered(filaExamen("PESO").ToString + " Kg", Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 360, PuntoOrigen.Y + 5)
                e.Graphics.DrawStringCentered(filaExamen("TALLA").ToString + " m", Formato_Etiqueta_8R, Brocha, 80, PuntoOrigen.X + 440, PuntoOrigen.Y + 5)
                Dim IMC As Double = 0
                IMC = Format(Convert.ToDecimal(filaExamen("PESO").ToString) / (Convert.ToDecimal(filaExamen("TALLA").ToString) * Convert.ToDecimal(filaExamen("TALLA").ToString)), "0.00")
                e.Graphics.DrawStringCentered(IMC.ToString, Formato_Etiqueta_8R, Brocha, 90, PuntoOrigen.X + 520, PuntoOrigen.Y + 5)
                e.Graphics.DrawStringCentered(filaExamen("PERIMETROABDOMEN").ToString, Formato_Etiqueta_8R, Brocha, 120, PuntoOrigen.X + 610, PuntoOrigen.Y + 5)
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                BloqueImpresionExamen = 21
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 21 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("VALORACIÓN FÍSICA", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim RevisionSistemas As String = Replace(filaExamen("EVIDENCIASCLINICASSIGNOSVITALES").ToString, vbLf, "")
                    If Trim(RevisionSistemas) <> "" Then
                        Cadenas.Add(RevisionSistemas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 22
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 22
                Else
                    BloqueImpresionExamen = 21
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 22 Then
            If ContadorRenglones > 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("PRUEBAS FUNCIONALES POSITIVAS EN EVIDENCIAS CLÍNICAS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("HOMBROS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("HOMBROS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 23
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 23
                Else
                    BloqueImpresionExamen = 22
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 23 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("CODOS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("CODOS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 24
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If

                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 24
                Else
                    BloqueImpresionExamen = 23
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 24 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("MUÑECAS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("MUÑECAS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 25
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 25
                Else
                    BloqueImpresionExamen = 24
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 25 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("MANOS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("MANOS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 26
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 26
                Else
                    BloqueImpresionExamen = 25
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 26 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("DEDOS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("DEDOS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 27
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 27
                Else
                    BloqueImpresionExamen = 26
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 27 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("CADERA", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("CADERAS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 28
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 28
                Else
                    BloqueImpresionExamen = 27
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 28 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("RODILLAS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("RODILLAS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 29
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 29
                Else
                    BloqueImpresionExamen = 28
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 29 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("TOBILLOS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("TOBILLOS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 30
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 30
                Else
                    BloqueImpresionExamen = 29
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 30 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("PIES", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("PIES").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 31
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 31
                Else
                    BloqueImpresionExamen = 30
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 31 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("COLUMNA", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = filaExamen("COLUMNA").ToString + filaExamen("COLUMNA2").ToString + filaExamen("COLUMNA3").ToString + filaExamen("COLUMNA4").ToString
                    EvidenciasClinicas = Replace(EvidenciasClinicas, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 32
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 32
                Else
                    BloqueImpresionExamen = 31
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 32 Then
            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("COMENTARIOS DE LAS EVIDENCIAS OBSERVADAS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("EVIDENCIASCLINICAS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        BloqueImpresionExamen = 33
                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 33
                Else
                    BloqueImpresionExamen = 32
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 33 Then
            If ContadorRenglones > 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("ESTUDIOS CLÍNICOS Y PARACLÍNICOS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("CUADRO HEMATICO", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("CUADROHEMATICO").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                Dim Texto As String = filaExamen("OBSERVACIONESCUADROHEMATICO").ToString
                If Texto <> "" Then
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 34
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 34 Then
            If ContadorRenglones > 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("QUÍMICA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("QUIMICA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                Dim Texto As String = filaExamen("OBSERVACIONESQUIMICA").ToString
                If Texto <> "" Then
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 35
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 35 Then
            If ContadorRenglones > 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("GLICEMIA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("GLICEMIA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                Dim Texto As String = filaExamen("ESTADOGLICEMIA").ToString
                If Texto <> "" Then
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 36
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 36 Then
            If ContadorRenglones > 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("PARCIAL DE ORINA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)

                Dim ParcialOrina As String = filaExamen("PARCIALORINA").ToString
                Dim Texto As String = ""
                If ParcialOrina <> "" Then
                    Dim po As Char = ParcialOrina(0)
                    If po = "S" Then
                        Texto += "Normal"
                    Else
                        po = ParcialOrina(1)
                        If po = "S" Then
                            Texto += "Bacterias: Si, "
                        Else
                            Texto += "Bacterias: No, "
                        End If
                        po = ParcialOrina(2)
                        If po = "S" Then
                            Texto += "Proteinura: Si, "
                        Else
                            Texto += "Proteinura: No, "
                        End If
                        po = ParcialOrina(3)
                        If po = "S" Then
                            Texto += "Glucosuria: Si, "
                        Else
                            Texto += "Glucosuria: No, "
                        End If
                        po = ParcialOrina(4)
                        If po = "S" Then
                            Texto += "Calcio+++: Si, "
                        Else
                            Texto += "Calcio+++: No, "
                        End If
                        po = ParcialOrina(5)
                        If po = "S" Then
                            Texto += "Sangre+++: Si, "
                        Else
                            Texto += "Sandre+++: No, "
                        End If
                        po = ParcialOrina(6)
                        If po = "S" Then
                            Texto += "Albúmina: Si, "
                        Else
                            Texto += "Albúmina: No, "
                        End If
                        po = ParcialOrina(7)
                        If po = "S" Then
                            Texto += "Eritocitocis: Si, "
                        Else
                            Texto += "Eritocitosis: No, "
                        End If
                        po = ParcialOrina(8)
                        If po = "S" Then
                            Texto += "Creatinuria: Si "
                        Else
                            Texto += "Creatinuria: No "
                        End If
                    End If
                End If

                If Texto = "Normal" Then
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                Else
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                End If


                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 37
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 37 Then
            If ContadorRenglones > 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("FUNCIÓN RENAL", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("FUNCIONRENAL").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                Dim Texto As String = filaExamen("ESTADOFUNCIONRENAL").ToString
                If Texto <> "" Then
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 38
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 38 Then
            If ContadorRenglones > 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("FUNCIÓN HEPÁTICA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("FUNCIONHEPATICA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("OBSERVACIONES", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                Dim Texto As String = filaExamen("ESTADOFUNCIONHEPATICA").ToString
                If Texto <> "" Then
                    e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                End If
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 39
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 39 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("TÓXICA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)

                Dim Cadena As String = filaExamen("PSICOFARMACOS").ToString
                Dim Texto As String = ""
                If Cadena <> "" Then
                    Dim po As Char = Cadena(0)
                    If po = "S" Then
                        Texto += "Negativo"
                    Else
                        po = Cadena(1)
                        If po = "S" Then
                            Texto += "Marihuana(+): Si, "
                        Else
                            Texto += "Marihuana(+): No, "
                        End If
                        po = Cadena(2)
                        If po = "S" Then
                            Texto += "Cocaina(+): Si"
                        Else
                            Texto += "Cocaina(+): No"
                        End If
                    End If
                End If
                e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 40
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 40 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("AUDIOMETRÍA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("AUDIOMETRIA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 41
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 41 Then
            If ContadorRenglones > 2 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("VISIOMETRÍA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)

                Dim Cadena As String = filaExamen("VISIOMETRIA").ToString
                Dim Texto As String = ""
                If Cadena <> "" Then
                    Dim po As Char = Cadena(0)
                    If po = "S" Then
                        Texto += "Normal"
                    Else
                        po = Cadena(1)
                        If po = "S" Then
                            Texto += "Alt. V. Cerca: Si, "
                        Else
                            Texto += "Alt. V. Cerca: No, "
                        End If
                        po = Cadena(2)
                        If po = "S" Then
                            Texto += "Alt. V. Lejos: Si, "
                        Else
                            Texto += "Alt. V. Lejos: No, "
                        End If
                        po = Cadena(3)
                        If po = "S" Then
                            Texto += "Alt. Movilidad: Si, "
                        Else
                            Texto += "Alt. Movilidad: No, "
                        End If
                        po = Cadena(4)
                        If po = "S" Then
                            Texto += "Alt. Parpados: Si, "
                        Else
                            Texto += "Alt. Parpados: No, "
                        End If
                        po = Cadena(5)
                        If po = "S" Then
                            Texto += "Alt. Conjuntiva: Si"
                        Else
                            Texto += "Alt. Conjuntiva: No"
                        End If
                    End If
                End If
                e.Graphics.DrawString(Texto, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("OTRAS ALTERACIONES", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawString(filaExamen("ESTADOFUNCIONHEPATICA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 42
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 42 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("ESPIROMETRÍA", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("ESPIROMETRIA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 43
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 43 Then
            If ContadorRenglones > 1 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawString("EKG", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString(filaExamen("EKG").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 139, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 140, PuntoOrigen.Y, PuntoOrigen.X + 140, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("CONCLUSIÓN EKG", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawString(filaExamen("EKGCONCLUSION").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 145, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 44
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        'ContadorRenglones = 2
        If BloqueImpresionExamen = 44 Then

            If ContadorRenglones > 1 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 728, 19)
                e.Graphics.DrawStringCentered("IMÁGENES DIAGNÓSTICAS", Formato_Etiqueta_8, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim suma As Integer = 0
                Dim InicioYdeLineaTiempo As Integer = PuntoOrigen.Y
                Dim InicioYdeLineaTiempo2 As Integer = PuntoOrigen.Y

                If SubCadenaFaltante.Count > 0 Then
                    Dim Renglones As Integer = 0
                    Dim otralinea As Integer = 20
                    Dim puntoobservacion As Integer = InicioYdeLineaTiempo
                    For j As Integer = 0 To SubCadenaFaltante.Count - 1
                        If ContadorRenglones > 0 Then
                            e.Graphics.DrawString(SubParrafo1(SubCadenaFaltante(j), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X, puntoobservacion + 3)
                            puntoobservacion += otralinea
                            Renglones += 1
                            ContadorRenglones -= 1
                        End If
                    Next
                    InicioYdeLineaTiempo += Renglones * 20
                    Cadenas.Clear()
                    CadenasTotal.Clear()
                    SubCadenaFaltante.Clear()
                    suma += Renglones * 20
                    PuntoOrigen.Y += suma
                Else
                    Dim EvidenciasClinicas As String = Replace(filaExamen("IMAGENESDIAGNOSTICAS").ToString, vbLf, "")
                    If Trim(EvidenciasClinicas) <> "" Then
                        Cadenas.Add(EvidenciasClinicas)
                        CadenasTotal = TextoAParrafoFuente(Cadenas, Formato_Etiqueta_8R, 730, e)
                        Dim Renglones As Integer = 0
                        Dim otralinea As Integer = 20
                        Dim puntoobservacion As Integer = PuntoOrigen.Y
                        If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                            CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                        End If
                        For i As Integer = 0 To CadenasTotal.Count - 1
                            If ContadorRenglones > 0 Then
                                e.Graphics.DrawString(SubParrafo1(CadenasTotal(i), Formato_Etiqueta_8R, 730, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, puntoobservacion + 5)
                                puntoobservacion += otralinea
                                ContadorRenglones -= 1
                                Renglones += 1
                            Else
                                SubCadenaFaltante.Add(CadenasTotal(i))
                            End If
                        Next
                        suma += Renglones * 20
                        Cadenas.Clear()
                        CadenasTotal.Clear()

                        PuntoOrigen.Y += suma
                    Else
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                    End If
                End If
                If CadenasTotal.Count = 0 And SubCadenaFaltante.Count = 0 Then
                    BloqueImpresionExamen = 45
                Else
                    BloqueImpresionExamen = 44
                    TamañoYExamen = PuntoOrigen.Y - 30
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 45 Then
            If ContadorRenglones > 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("INMUNIZACIONES", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("VACUNA", Formato_Etiqueta_8, Brocha, 365, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 365, PuntoOrigen.Y, PuntoOrigen.X + 365, PuntoOrigen.Y + 20)
                e.Graphics.DrawStringCentered("FECHA VACUNACIÓN", Formato_Etiqueta_8, Brocha, 365, PuntoOrigen.X + 365, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                If dtVacunacion IsNot Nothing Then
                    For i As Integer = VacunacionFaltantei To dtVacunacion.Rows.Count - 1
                        e.Graphics.DrawString(dtVacunacion.Rows(i).Item("NOMBREVACUNA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                        e.Graphics.DrawString(dtVacunacion.Rows(i).Item("FECHAVACUNA").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 370, PuntoOrigen.Y + 5)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 365, PuntoOrigen.Y, PuntoOrigen.X + 365, PuntoOrigen.Y + 20)
                        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                        PuntoOrigen.Y += 20
                        ContadorRenglones -= 1
                        VacunacionFaltantei += 1
                    Next
                Else
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 365, PuntoOrigen.Y, PuntoOrigen.X + 365, PuntoOrigen.Y + 20)
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                End If

                If VacunacionFaltantei = dtVacunacion.Rows.Count Then
                    BloqueImpresionExamen = 46
                Else
                    BloqueImpresionExamen = 45
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 46 Then
            If ContadorRenglones > 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("DIAGNÓSTICOS", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("CODIGO", Formato_Etiqueta_8, Brocha, 70, PuntoOrigen.X, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 70, PuntoOrigen.Y, PuntoOrigen.X + 70, PuntoOrigen.Y + 20)
                e.Graphics.DrawStringCentered("DIAGNÓSTICO", Formato_Etiqueta_8, Brocha, 330, PuntoOrigen.X + 70, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + 20)
                e.Graphics.DrawStringCentered("IMPRESIÓN DIAGNOSTICA", Formato_Etiqueta_8, Brocha, 330, PuntoOrigen.X + 400, PuntoOrigen.Y + 5)

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                If dtDiagnosticos IsNot Nothing Then
                    For i As Integer = DiagnosticoFaltantei To dtDiagnosticos.Rows.Count - 1
                        Dim Fila As DataRow = Nothing
                        Fila = dtDiagnosticos.Rows(i)
                        Dim TamañoEnfermedad As Integer = e.Graphics.MeasureString(Fila("NOMBREENFERMEDAD").ToString, Formato_Etiqueta_8R).Width
                        Dim RenglonesEnfermedad As Integer = 0
                        Dim TamañoDiagnostico As Integer = e.Graphics.MeasureString(Fila("DESCRIPCIONENFERMEDAD").ToString, Formato_Etiqueta_8R).Width
                        Dim RenglonesDiagnostico As Integer = 0
                        Dim CantidadRenglonesDiagnostico As Double = 0
                        If TamañoEnfermedad > TamañoDiagnostico Then
                            CantidadRenglonesDiagnostico = TamañoEnfermedad / 330
                        Else
                            CantidadRenglonesDiagnostico = TamañoDiagnostico / 330
                        End If
                        If CantidadRenglonesDiagnostico < ContadorRenglones Then
                            e.Graphics.DrawString(Fila("CODIGOENFERMEDAD").ToString, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                            Cadenas.Add(Fila("NOMBREENFERMEDAD").ToString)
                            CadenasTotal = TextoAParrafoFuente2(Cadenas, Formato_Etiqueta_8R, 330, e)
                            Dim Renglones As Integer = 0
                            Dim otralinea As Integer = 20
                            Dim puntoobservacion As Integer = PuntoOrigen.Y
                            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                            End If
                            RenglonesEnfermedad = CadenasTotal.Count
                            For j As Integer = 0 To CadenasTotal.Count - 1
                                If ContadorRenglones > 0 Then
                                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(j), Formato_Etiqueta_8R, 330, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 70, puntoobservacion + 5)
                                    puntoobservacion += otralinea
                                End If
                            Next
                            Cadenas.Clear()
                            CadenasTotal.Clear()
                            puntoobservacion = PuntoOrigen.Y
                            Cadenas.Add(Fila("DESCRIPCIONENFERMEDAD").ToString)
                            CadenasTotal = TextoAParrafoFuente2(Cadenas, Formato_Etiqueta_8R, 330, e)
                            If CadenasTotal(CadenasTotal.Count - 1) = "" Then
                                CadenasTotal.RemoveAt(CadenasTotal.Count - 1)
                            End If
                            RenglonesDiagnostico = CadenasTotal.Count
                            For k As Integer = 0 To CadenasTotal.Count - 1
                                If ContadorRenglones > 0 Then
                                    e.Graphics.DrawString(SubParrafo1(CadenasTotal(k), Formato_Etiqueta_8R, 330, e), Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 400, puntoobservacion + 5)
                                    puntoobservacion += otralinea
                                End If
                            Next
                            Cadenas.Clear()
                            CadenasTotal.Clear()
                            Dim CantRenglonesTemp As Integer = 0
                            If RenglonesEnfermedad > RenglonesDiagnostico Then
                                CantRenglonesTemp = RenglonesEnfermedad
                            Else
                                CantRenglonesTemp = RenglonesDiagnostico
                            End If
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 70, PuntoOrigen.Y, PuntoOrigen.X + 70, PuntoOrigen.Y + CantRenglonesTemp * 20)
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 400, PuntoOrigen.Y, PuntoOrigen.X + 400, PuntoOrigen.Y + CantRenglonesTemp * 20)
                            PuntoOrigen.Y += CantRenglonesTemp * 20
                            ContadorRenglones -= CantRenglonesTemp
                            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                            If i = dtDiagnosticos.Rows.Count - 1 Then
                                BloqueImpresionExamen = 47
                            End If
                            DiagnosticoFaltantei += 1
                        Else
                            TamañoYExamen = PuntoOrigen.Y - 30
                            Exit For
                        End If
                    Next
                Else
                    e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                    PuntoOrigen.Y += 20
                    ContadorRenglones -= 1
                    BloqueImpresionExamen = 47
                End If
            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 47 Then
            If ContadorRenglones > 2 Then
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y, PuntoOrigen.X + 730, PuntoOrigen.Y) 'Horizontal completa
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 729, 19)
                e.Graphics.DrawStringCentered("PROGRAMAS DE VIGILANCIA EPIDMIOLÓGICA QUE LE APLICAN", Formato_Etiqueta_10, Brocha, 730, PuntoOrigen.X, PuntoOrigen.Y + 3)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1

                Dim Vigilancia As String = filaExamen("PROGRAMASVIGILANCIA").ToString
                Dim ch As Char = Vigilancia(0)
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawString("Biomecánico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 121, PuntoOrigen.Y, PuntoOrigen.X + 121, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 126, PuntoOrigen.Y + 5)
                End If

                ch = Vigilancia(1)

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 183, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Auditivo", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 303, PuntoOrigen.Y, PuntoOrigen.X + 303, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 308, PuntoOrigen.Y + 5)
                End If
                ch = Vigilancia(2)

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 364, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 363, PuntoOrigen.Y, PuntoOrigen.X + 363, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Cardiovascular", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 368, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 484, PuntoOrigen.Y, PuntoOrigen.X + 484, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 490, PuntoOrigen.Y + 5)
                End If

                ch = Vigilancia(3)
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 547, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 546, PuntoOrigen.Y, PuntoOrigen.X + 546, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Respiratorio", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 551, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 667, PuntoOrigen.Y, PuntoOrigen.X + 667, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 672, PuntoOrigen.Y + 5)
                End If

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20

                ch = Vigilancia(4)
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawString("Dermatológico", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 121, PuntoOrigen.Y, PuntoOrigen.X + 121, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 126, PuntoOrigen.Y + 5)
                End If
                ch = Vigilancia(5)
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 183, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 182, PuntoOrigen.Y, PuntoOrigen.X + 182, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Psicosocial", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 187, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 303, PuntoOrigen.Y, PuntoOrigen.X + 303, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 308, PuntoOrigen.Y + 5)
                End If

                Try
                    ch = Vigilancia(6)
                Catch ex As Exception
                    ch = ""
                End Try

                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 364, PuntoOrigen.Y + 1, 120, 19)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 363, PuntoOrigen.Y, PuntoOrigen.X + 363, PuntoOrigen.Y + 20)
                e.Graphics.DrawString("Visual", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 368, PuntoOrigen.Y + 5)
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 484, PuntoOrigen.Y, PuntoOrigen.X + 484, PuntoOrigen.Y + 20)
                If ch = "S" Then
                    e.Graphics.DrawString("X", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 490, PuntoOrigen.Y + 5)
                End If

                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 730, PuntoOrigen.Y + 20) 'Horizontal completa
                PuntoOrigen.Y += 20
                ContadorRenglones -= 1
                BloqueImpresionExamen = 48

            Else
                TamañoYExamen = PuntoOrigen.Y - 30
            End If
        End If

        If BloqueImpresionExamen = 48 Then
            Terminado = True
            TamañoYExamen = PuntoOrigen.Y - 30
        End If

        '------ Finalizacion del documento ------
        Dim PuntoOrigen2 As New Point(55, 30)
        e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen2.X, PuntoOrigen2.Y, 730, TamañoYExamen)

        ContadorPaginasHC += 1

        Dim CantidadPaginas As String = ""
        If ImprimirPieDePagina Then
            CantidadPaginas = "Página " + ContadorPaginasHC.ToString + " de " + PaginasTotalHC.ToString
        Else
            CantidadPaginas = "Página " + ContadorPaginasHC.ToString
        End If

        e.Graphics.DrawStringCentered(CantidadPaginas, Formato_Etiqueta_8, Brocha, e.PageBounds.Width, 0, PuntoOrigen.Y + 20)

        If ImpresionExamen = True Then
            If ContadorPaginasHC = PaginasTotalHC Then
                BloquearExamenHistoria()
            End If
        End If

        If Terminado = True Then
            ImprimirPieDePagina = True
            PaginasTotalHC = ContadorPaginasHC
            e.HasMorePages = False
            ContadorPaginasHC = 0
            AntecedentesLaboralesFaltantei = 0
            RiesgosLaboralesFaltantei = 0
            VacunacionFaltantei = 0
            DiagnosticoFaltantei = 0
            BloqueImpresionExamen = 0
            Terminado = False
            Exit Sub
        Else
            e.HasMorePages = True
        End If

    End Sub

    Private Sub BloquearExamenHistoria()
        Try
            Dim Comando As New SqlClient.SqlCommand("ImpresionDocumento")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TIPO", 18)
            Comando.Parameters.AddWithValue("@IDDOCUMENTO", IdExamen)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "106 - Formato Resumen Estadistico ICH-GRAL-F-009"
    Private WithEvents DocImp_ICHGRALF009 As New PrintDocument

    Public Property TipoResumen As Integer
    Public Property AñoResumen As String
    Public Property BasesResumen As String

    Dim ImpresionResumen As Boolean = False

    Dim ContadorPaginasResumen As Integer = 0
    Dim PaginasTotalResumen As Integer = 0

    Dim dtResumenEst As DataTable
    Private Sub CargarDataSetResumenEst()
        If dtResumenEst Is Nothing Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ResumenEstadisticoxBase", conexion)
            'Dim Base As String = ""
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@Tipo", TipoResumen)
            comando.Parameters.AddWithValue("@Base", BasesResumen)
            comando.Parameters.AddWithValue("@Año", AñoResumen)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dsFormatosHSE As New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsFormatosHSE)
                conexion.Close()

                If dsFormatosHSE.Tables(0).Rows.Count > 0 Then
                    dtResumenEst = dsFormatosHSE.Tables(0)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Impresión de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'ImpresionReporteInv = True
        End If
    End Sub

    Private Sub DocImpr_ICHGRALF009(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImp_ICHGRALF009.PrintPage
        e.PageSettings.Landscape = True
        If ContadorPaginasResumen = 0 Then
            CargarDataSetResumenEst()
        End If

        'DibujarRejilla(e, Color.LightGray, True, 0.5, Formato_Etiqueta_4, 10)

        Dim Titulo As String = "RESUMEN ESTADÍSTICO POR PERIODOS MENSUALES"
        Dim ICH As String = "ICH-GRAL-F-009"
        Dim Revision As String = "Revisión No. 11"

        Dim lineaPunteada As New Pen(Color.Gray, 1)
        lineaPunteada.DashPattern = New Single() {3, 3, 3, 3}

        Dim CantidadRenglones As Integer = 0

        Dim PuntoOrigen As New Point(30, 40)
        TamañoY = 1040

        Dim TamañoImagenX As Integer = 70
        e.Graphics.DrawImage(logoIsmocol, PuntoOrigen.X + 15, PuntoOrigen.Y + 5, TamañoImagenX, TamañoImagenX - 20)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 100, PuntoOrigen.Y, PuntoOrigen.X + 100, PuntoOrigen.Y + 60) 'Vertical
        e.Graphics.DrawStringCentered(Titulo, Formato_Etiqueta_12, Brocha, 820, PuntoOrigen.X + 100, PuntoOrigen.Y + 20)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 920, PuntoOrigen.Y, PuntoOrigen.X + 920, PuntoOrigen.Y + 60) 'Vertical
        e.Graphics.DrawStringCentered(ICH, Formato_Etiqueta_9, Brocha, 120, PuntoOrigen.X + 920, PuntoOrigen.Y + 8)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 920, PuntoOrigen.Y + 30, PuntoOrigen.X + 1040, PuntoOrigen.Y + 30) 'Horizontal
        e.Graphics.DrawStringCentered(Revision, Formato_Etiqueta_9, Brocha, 120, PuntoOrigen.X + 920, PuntoOrigen.Y + 38)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 60, PuntoOrigen.X + 1040, PuntoOrigen.Y + 60) 'Horizontal completa
        PuntoOrigen.Y += 60

        e.Graphics.DrawString("Proyecto/Base:", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawString("Año:", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 920, PuntoOrigen.Y + 5)
        BasesResumen = BasesResumen.Replace(" ", "")
        e.Graphics.DrawString(BasesResumen, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 100, PuntoOrigen.Y + 5)
        e.Graphics.DrawString(AñoResumen, Formato_Etiqueta_8R, Brocha, PuntoOrigen.X + 950, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 1040, PuntoOrigen.Y + 20) 'Horizontal completa
        PuntoOrigen.Y += 20

        e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, PuntoOrigen.Y + 1, 1039, 19)
        e.Graphics.DrawString("INCIDENTE", Formato_Etiqueta_8, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 350, PuntoOrigen.Y, PuntoOrigen.X + 350, PuntoOrigen.Y + 20)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, PuntoOrigen.Y + 20, PuntoOrigen.X + 1040, PuntoOrigen.Y + 20) 'Horizontal completa

        Dim Meses() As String = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames
        Dim DistanciaMeses As Integer = PuntoOrigen.X + 350
        Dim AlturaMeses As Integer = PuntoOrigen.Y
        Dim InicioFilasY As Integer = PuntoOrigen.Y + 20
        Dim InicioFilasX As Integer = PuntoOrigen.X + 350
        PuntoOrigen.Y += 20

        Dim AlturaIncidentes As Integer = PuntoOrigen.Y
        Dim Incidentes As New ArrayList
        Incidentes.Add("Primeros auxilios")
        Incidentes.Add("Fatalidad (Muerte)")
        Incidentes.Add("Lesiones con Tiempo Perdido ")
        Incidentes.Add("Eventos con trabajo restringido")
        Incidentes.Add("Eventos con reubicación laboral")
        Incidentes.Add("Eventos con tratamiento médico")
        Incidentes.Add("Eventos con pérdida de conciencia")
        Incidentes.Add("Casos por enfermedad laboral")
        Incidentes.Add("Casi-Accidentes")
        Incidentes.Add("Accidentes de Tránsito")
        Incidentes.Add("Daño a la propiedad  (No incluyen daños por accidentes de tránsito)")
        Incidentes.Add("Incidentes ambientales")
        Incidentes.Add("Personal contratado  ")
        Incidentes.Add("Total horas ordinarias")
        Incidentes.Add("Total  horas trabajadas")
        Incidentes.Add("Días cargados por ATEL")
        Incidentes.Add("Días de incapacidad por ATEL")
        Incidentes.Add("Días de incapacidad por enfermedad comun")
        Incidentes.Add("Número de días de trabajo programados en la empresa")
        Incidentes.Add("# Vehículos utilizados (propios + contratistas)")
        Incidentes.Add("Total de kilómetros recorridos (propios + contratistas)")
        Incidentes.Add("# Inspecciones realizadas a vehículos (propios + contratistas)")
        Incidentes.Add("# Conductores (propios + contratistas)")
        Incidentes.Add("Horas de capacitación")
        Incidentes.Add("Índice de capacitación / recreación")
        Incidentes.Add("Índice de Frecuencia (IF)")
        Incidentes.Add("Índice de Frecuencia Total de Casos Registrables (TRIF)")
        Incidentes.Add("Frecuencia de accidentalidad")
        Incidentes.Add("Severidad de accidentalidad")
        Incidentes.Add("Proporción de accidentes de trabajo mortales (%)")
        Incidentes.Add("Prevalencia de enfermedad laboral ")
        Incidentes.Add("Incidencia de la enfermedad laboral ")
        Incidentes.Add("Ausentismo por causa médica (laboral y común) (%)")
        Incidentes.Add("Costos Directos e Indirectos ATEL y Casi - Accidentes ($) (Ítem 1 al 9)")
        Incidentes.Add("Costos por Daños: Propiedad, Terceros, Ambiente ($) (Ítem 10 al 12)")
        Incidentes.Add("Total Costos de Incidentes  ($) (" + Convert.ToChar(931) + " ítem 37 y 38)")

        Dim dtResumen2 As New DataTable
        dtResumen2 = dtResumenEst.Clone
        Dim FilaPrimAux As DataRow = dtResumenEst.Select("INCIDENTE = 'Primeros Auxilios'").FirstOrDefault
        Dim FilaTratamientoMedico As DataRow = dtResumenEst.Select("INCIDENTE = 'Tratamiento Médico'").FirstOrDefault
        Dim FilaTrabajoRestringido As DataRow = dtResumenEst.Select("INCIDENTE = 'Trabajo restringido'").FirstOrDefault
        Dim FilaReubLab As DataRow = dtResumenEst.Select("INCIDENTE = 'Reubicación Laboral'").FirstOrDefault
        Dim FilaPerdidaConoc As DataRow = dtResumenEst.Select("INCIDENTE = 'Perdida de Conocimiento'").FirstOrDefault
        Dim FilaLesionIncap As DataRow = dtResumenEst.Select("INCIDENTE = 'Lesión incapacitante'").FirstOrDefault
        Dim FilaFatalidad As DataRow = dtResumenEst.Select("INCIDENTE = 'Fatalidad'").FirstOrDefault
        Dim FilaEnfLaboral As DataRow = dtResumenEst.Select("INCIDENTE = 'Enfermedad Laboral'").FirstOrDefault
        Dim FilaCasiAccidentes As DataRow = dtResumenEst.Select("INCIDENTE = 'Ninguno'").FirstOrDefault
        Dim dtSeguridad As DataTable = dtResumenEst.Select("IDTIPO = 5").CopyToDataTable
        Dim dtAccidentesTransito As DataTable = dtResumenEst.Select("INCIDENTE = 'Accidente de Transito'").CopyToDataTable

        Dim FilaSeguridad As DataRow = dtSeguridad.NewRow
        Dim dtAmbiental As DataTable = dtResumenEst.Select("IDTIPO = 6").CopyToDataTable
        Dim FilaAmbiental As DataRow = dtAmbiental.NewRow


        dtResumen2.ImportRow(FilaPrimAux)
        dtResumen2.ImportRow(FilaFatalidad)
        dtResumen2.ImportRow(FilaLesionIncap)
        dtResumen2.ImportRow(FilaTrabajoRestringido)
        dtResumen2.ImportRow(FilaReubLab)
        dtResumen2.ImportRow(FilaTratamientoMedico)
        dtResumen2.ImportRow(FilaPerdidaConoc)
        dtResumen2.ImportRow(FilaEnfLaboral)
        dtResumen2.ImportRow(FilaCasiAccidentes)
        dtResumen2.ImportRow(dtAccidentesTransito.Select("INCIDENTE = 'Accidente de Transito'").FirstOrDefault)

        FilaSeguridad(0) = "Seguridad"
        For i As Integer = 3 To dtSeguridad.Columns.Count - 1
            Dim Suma As Integer = 0
            For j As Integer = 0 To dtSeguridad.Rows.Count - 1
                If dtSeguridad.Rows(j).Item(0) <> "Accidente de Transito" Then
                    Dim Valor As Integer = IIf(IsDBNull(dtSeguridad.Rows(j).Item(i)), 0, dtSeguridad.Rows(j).Item(i).ToString)
                    Suma += Valor
                End If
            Next
            FilaSeguridad(i) = Suma
        Next
        dtSeguridad.Rows.Add(FilaSeguridad)

        FilaAmbiental(0) = "Ambiental"
        For i As Integer = 3 To dtAmbiental.Columns.Count - 1
            Dim Suma As Integer = 0
            For j As Integer = 0 To dtAmbiental.Rows.Count - 1
                Dim Valor As Integer = IIf(IsDBNull(dtAmbiental.Rows(j).Item(i)), 0, dtAmbiental.Rows(j).Item(i).ToString)
                Suma += Valor
            Next
            FilaAmbiental(i) = Suma
        Next
        dtAmbiental.Rows.Add(FilaAmbiental)
        dtResumen2.ImportRow(dtSeguridad.Select("INCIDENTE = 'Seguridad'").FirstOrDefault)
        dtResumen2.ImportRow(dtAmbiental.Select("INCIDENTE = 'Ambiental'").FirstOrDefault)
        dtResumen2.AcceptChanges()

        For i As Integer = 1 To 36
            e.Graphics.DrawString(i.ToString + ".", Formato_Etiqueta_7, Brocha, PuntoOrigen.X + 5, AlturaIncidentes + 3)
            e.Graphics.DrawString(Incidentes(i - 1).ToString, Formato_Etiqueta_7R, Brocha, PuntoOrigen.X + 25, AlturaIncidentes + 3)
            AlturaIncidentes += 15
            e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, AlturaIncidentes, PuntoOrigen.X + 1040, AlturaIncidentes) 'Horizontal completa
            If i = 12 Then
                e.Graphics.FillRectangle(brocharellenogris, PuntoOrigen.X + 1, AlturaIncidentes + 1, 1040, 4)
                AlturaIncidentes += 5
                e.Graphics.DrawLine(Lapiz, PuntoOrigen.X, AlturaIncidentes, PuntoOrigen.X + 1040, AlturaIncidentes) 'Horizontal completa
            End If
        Next

        For i As Integer = 0 To 12
            If i < 12 Then
                e.Graphics.DrawStringCentered(Meses(i).Substring(0, 3).ToUpper, Formato_Etiqueta_8, Brocha, 53, DistanciaMeses, AlturaMeses + 5)
            Else
                e.Graphics.DrawStringCentered("TOTAL", Formato_Etiqueta_8, Brocha, 53, DistanciaMeses, AlturaMeses + 5)
            End If
            DistanciaMeses += 53
            e.Graphics.DrawLine(Lapiz, DistanciaMeses, AlturaMeses, DistanciaMeses, AlturaIncidentes)
        Next
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 350, PuntoOrigen.Y, PuntoOrigen.X + 350, AlturaIncidentes)

        For i As Integer = 0 To dtResumen2.Rows.Count - 1
            Dim PuntoX As Integer = InicioFilasX
            For j As Integer = 3 To 15
                Dim Valor As String = IIf(IsDBNull(dtResumen2.Rows(i).Item(j)), 0, dtResumen2.Rows(i).Item(j).ToString)
                e.Graphics.DrawStringCentered(Valor, Formato_Etiqueta_7R, Brocha, 53, PuntoX, InicioFilasY + 3)
                PuntoX += 53
            Next
            InicioFilasY += 15
        Next

        Dim FilaPersonalContratado As DataRow = dtResumenEst.Select("INCIDENTE = 'Personal contratado'").FirstOrDefault
        Dim FilaTotalHorasOrdinarias As DataRow = dtResumenEst.Select("INCIDENTE = 'Total horas ordinarias'").FirstOrDefault
        Dim FilaTotalHorasTrabajadas As DataRow = dtResumenEst.Select("INCIDENTE = 'Total  horas trabajadas'").FirstOrDefault
        Dim FilaDiasCargadosATEL As DataRow = dtResumenEst.Select("INCIDENTE = 'Días cargados por ATEL'").FirstOrDefault
        Dim FilaDiasIncapacidadATEL As DataRow = dtResumenEst.Select("INCIDENTE = 'Días de incapacidad por ATEL'").FirstOrDefault
        Dim FilaDiasIncapacidadComun As DataRow = dtResumenEst.Select("INCIDENTE = 'Días de incapacidad por enfermedad comun'").FirstOrDefault
        Dim FilaDiasTrabajoProgramado As DataRow = dtResumenEst.Select("INCIDENTE = 'Número de días de trabajo programados en la empresa'").FirstOrDefault
        Dim FIlaVehiculosPropios As DataRow = dtResumenEst.Select("INCIDENTE = 'Número de vehículos utilizados (propios + contratistas)'").FirstOrDefault
        Dim FilaTotalKilometros As DataRow = dtResumenEst.Select("INCIDENTE = 'Total de kilómetros recorridos (propios + contratistas)'").FirstOrDefault
        Dim FilaInspecciones As DataRow = dtResumenEst.Select("INCIDENTE = 'Número de inspecciones realizadas a vehículos (propios + contratistas)'").FirstOrDefault
        Dim FilaConductores As DataRow = dtResumenEst.Select("INCIDENTE = 'Número de conductores (propios + contratistas)'").FirstOrDefault
        Dim FilaHorasCapacitacion As DataRow = dtResumenEst.Select("INCIDENTE = 'Horas de capacitación'").FirstOrDefault
        Dim FilaCostosDirectos As DataRow = dtResumenEst.Select("INCIDENTE = 'Costos Directos e Indirectos ATEL y Casi - Accidentes'").FirstOrDefault
        Dim FilaCostosDaños As DataRow = dtResumenEst.Select("INCIDENTE = 'Costos por Daños: Propiedad, Terceros, Ambiente'").FirstOrDefault

        Dim dtResumen3 As New DataTable
        dtResumen3 = dtResumenEst.Clone
        dtResumen3.ImportRow(FilaPersonalContratado)
        dtResumen3.ImportRow(FilaTotalHorasOrdinarias)
        dtResumen3.ImportRow(FilaTotalHorasTrabajadas)
        dtResumen3.ImportRow(FilaDiasCargadosATEL)
        dtResumen3.ImportRow(FilaDiasIncapacidadATEL)
        dtResumen3.ImportRow(FilaDiasIncapacidadComun)
        dtResumen3.ImportRow(FilaDiasTrabajoProgramado)
        dtResumen3.ImportRow(FIlaVehiculosPropios)
        dtResumen3.ImportRow(FilaTotalKilometros)
        dtResumen3.ImportRow(FilaInspecciones)
        dtResumen3.ImportRow(FilaConductores)
        dtResumen3.ImportRow(FilaHorasCapacitacion)
        dtResumen3.AcceptChanges()
        Dim FilaIndiceCapacitacion As DataRow = dtResumen3.NewRow
        Dim FilaIndiceFrecuencia As DataRow = dtResumen3.NewRow
        Dim FilaFrecuenciaTotal As DataRow = dtResumen3.NewRow
        Dim FilaFrecuenciaAccidentalidad As DataRow = dtResumen3.NewRow
        Dim FilaSeveridadAccidentalidad As DataRow = dtResumen3.NewRow
        Dim FilaProporcionAccidentesTrabajo As DataRow = dtResumen3.NewRow
        Dim FilaPrevalenciaEnfermedad As DataRow = dtResumen3.NewRow
        Dim FilaIncidenciaEnfermedad As DataRow = dtResumen3.NewRow
        Dim FilaAusentismo As DataRow = dtResumen3.NewRow
        Dim FilaTotalCostos As DataRow = dtResumen3.NewRow

        Dim FilaValoresPrevalencia As DataRow = dtResumen3.NewRow
        Dim Sumatoria As Integer = 0
        For i As Integer = 3 To dtResumenEst.Columns.Count - 1
            Sumatoria += FilaEnfLaboral(i)
            FilaValoresPrevalencia(i) = Sumatoria
        Next


        For i As Integer = 3 To dtResumenEst.Columns.Count - 1
            Dim ValorPersonalContratado As Integer = FilaPersonalContratado(i)
            'Dim ValorTotalHorasOrdinarias As Integer = FilaTotalHorasOrdinarias(i)
            Dim ValorTotalHorasTrabajadas As Integer = FilaTotalHorasTrabajadas(i)
            Dim ValorDiasCargadosATEL As Integer = FilaDiasCargadosATEL(i)
            Dim ValorDiasIncapacidadATEL As Integer = FilaDiasIncapacidadATEL(i)
            Dim ValorDiasIncapacidadComun As Integer = FilaDiasIncapacidadComun(i)
            Dim ValorDiasTrabajoProgramado As Integer = FilaDiasTrabajoProgramado(i)
            'Dim ValorVehiculosPropios As Integer = FIlaVehiculosPropios(i)
            'Dim ValorTotalKilometros As Integer = FilaTotalKilometros(i)
            'Dim ValorInspecciones As Integer = FilaInspecciones(i)
            'Dim ValorConductores As Integer = FilaConductores(i)
            Dim ValorHorasCapacitacion As Integer = FilaHorasCapacitacion(i)
            Dim ValorCostosDirectos As Integer = FilaCostosDirectos(i)
            Dim ValorCostosDaños As Integer = FilaCostosDaños(i)
            Dim ValorPrimAux As Integer = FilaPrimAux(i)
            Dim ValorTratamientoMedico As Integer = FilaTratamientoMedico(i)
            Dim ValorTrabajoRestringido As Integer = FilaTrabajoRestringido(i)
            Dim ValorReubLab As Integer = FilaReubLab(i)
            Dim ValorPerdidaConoc As Integer = FilaPerdidaConoc(i)
            Dim ValorLesionIncap As Integer = FilaLesionIncap(i)
            Dim ValorFatalidad As Integer = FilaFatalidad(i)
            Dim ValorEnfLaboral As Integer = FilaEnfLaboral(i)
            Dim ValorPrevalencia As Integer = FilaValoresPrevalencia(i)

            If ValorTotalHorasTrabajadas = 0 Then
                FilaIndiceCapacitacion(i) = 0
                FilaIndiceFrecuencia(i) = 0
                FilaFrecuenciaTotal(i) = 0
            Else
                FilaIndiceCapacitacion(i) = (ValorHorasCapacitacion / ValorTotalHorasTrabajadas) * 100
                FilaIndiceFrecuencia(i) = ((ValorFatalidad + ValorLesionIncap) / ValorTotalHorasTrabajadas) * 1000000
                FilaFrecuenciaTotal(i) = ((ValorFatalidad + ValorLesionIncap + ValorTrabajoRestringido + ValorReubLab + ValorTratamientoMedico + ValorPerdidaConoc) / ValorTotalHorasTrabajadas) * 1000000
            End If

            If ValorPersonalContratado = 0 Then
                FilaFrecuenciaAccidentalidad(i) = 0
                FilaSeveridadAccidentalidad(i) = 0
                FilaPrevalenciaEnfermedad(i) = 0
                FilaIncidenciaEnfermedad(i) = 0
            Else
                FilaFrecuenciaAccidentalidad(i) = ((ValorPrimAux + ValorFatalidad + ValorLesionIncap) + ValorTrabajoRestringido + ValorReubLab + ValorTratamientoMedico + ValorPerdidaConoc / ValorPersonalContratado) * 100
                FilaSeveridadAccidentalidad(i) = ((ValorDiasCargadosATEL + ValorDiasIncapacidadATEL) / ValorPersonalContratado) * 100
                FilaPrevalenciaEnfermedad(i) = (ValorPrevalencia / ValorPersonalContratado) * 100000
                FilaIncidenciaEnfermedad(i) = (ValorEnfLaboral / ValorPersonalContratado) * 100000
            End If

            If (ValorLesionIncap + ValorTrabajoRestringido + ValorReubLab + ValorTratamientoMedico + ValorPerdidaConoc) = 0 Then
                FilaProporcionAccidentesTrabajo(i) = 0
            Else
                FilaProporcionAccidentesTrabajo(i) = ValorFatalidad / (ValorLesionIncap + ValorTrabajoRestringido + ValorReubLab + ValorTratamientoMedico + ValorPerdidaConoc)
            End If

            If (ValorDiasTrabajoProgramado * ValorPersonalContratado) = 0 Then
                FilaAusentismo(i) = 0
            Else
                FilaAusentismo(i) = (ValorDiasIncapacidadATEL + ValorDiasIncapacidadComun) / (ValorDiasTrabajoProgramado * ValorPersonalContratado) * 100
            End If
            FilaTotalCostos(i) = ValorCostosDirectos + ValorCostosDaños
        Next

        dtResumen3.Rows.Add(FilaIndiceCapacitacion)
        dtResumen3.Rows.Add(FilaIndiceFrecuencia)
        dtResumen3.Rows.Add(FilaFrecuenciaTotal)
        dtResumen3.Rows.Add(FilaFrecuenciaAccidentalidad)
        dtResumen3.Rows.Add(FilaSeveridadAccidentalidad)
        dtResumen3.Rows.Add(FilaProporcionAccidentesTrabajo)
        dtResumen3.Rows.Add(FilaPrevalenciaEnfermedad)
        dtResumen3.Rows.Add(FilaIncidenciaEnfermedad)
        dtResumen3.Rows.Add(FilaAusentismo)
        dtResumen3.ImportRow(FilaCostosDirectos)
        dtResumen3.ImportRow(FilaCostosDaños)
        dtResumen3.Rows.Add(FilaTotalCostos)

        dtResumen3.AcceptChanges()
        InicioFilasY += 5
        For i As Integer = 0 To dtResumen3.Rows.Count - 1
            Dim PuntoX As Integer = InicioFilasX
            For j As Integer = 3 To 15
                Dim Valor As String = IIf(IsDBNull(dtResumen3.Rows(i).Item(j)), 0, dtResumen3.Rows(i).Item(j).ToString)
                Dim Posicion As Integer = Valor.IndexOf(",")
                If Posicion > 0 Then
                    Valor = Valor.Substring(0, Posicion + 3)
                End If
                If e.Graphics.MeasureString(Valor, Formato_Etiqueta_7R).Width < 53 Then
                    e.Graphics.DrawStringCentered(Valor, Formato_Etiqueta_7R, Brocha, 53, PuntoX, InicioFilasY + 3)
                ElseIf e.Graphics.MeasureString(Valor, Formato_Etiqueta_6R).Width < 53 Then
                    e.Graphics.DrawStringCentered(Valor, Formato_Etiqueta_6R, Brocha, 53, PuntoX, InicioFilasY + 3)
                Else
                    e.Graphics.DrawStringCentered(Valor, Formato_Etiqueta_5R, Brocha, 53, PuntoX, InicioFilasY + 3)
                End If

                PuntoX += 53
            Next
            InicioFilasY += 15
        Next

        PuntoOrigen.Y = AlturaIncidentes

        e.Graphics.DrawString("Responsable HSE", Formato_Etiqueta_7, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 5)
        e.Graphics.DrawString("Gerente/Director Obra/Residente", Formato_Etiqueta_7, Brocha, PuntoOrigen.X + 620, PuntoOrigen.Y + 5)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_7, Brocha, PuntoOrigen.X + 5, PuntoOrigen.Y + 80)
        e.Graphics.DrawString("Nombre", Formato_Etiqueta_7, Brocha, PuntoOrigen.X + 620, PuntoOrigen.Y + 80)
        e.Graphics.DrawLine(Lapiz, PuntoOrigen.X + 615, PuntoOrigen.Y, PuntoOrigen.X + 615, PuntoOrigen.Y + 135)

        '------ Finalizacion del documento ------
        Dim PuntoOrigen2 As New Point(30, 40)
        e.Graphics.DrawRectangle(Lapiz_Grueso, PuntoOrigen2.X, PuntoOrigen2.Y, 1040, 780)
    End Sub
#End Region

End Class
