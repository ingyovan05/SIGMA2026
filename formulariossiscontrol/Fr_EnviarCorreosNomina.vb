Imports System.Net.Mail.MailMessage
Imports System.Threading
Imports System.IO
Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions.Regex
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Text

Public Class Fr_EnviarCorreosNomina
    Dim objStreamWriter As StreamWriter
    'Pass the file path and the file name to the StreamWriter constructor.

    Dim excel As Object
    Dim libro As Object
    Dim hoja As Object
    Dim mendeb As String = ""
    Dim mencre As String = ""
    Dim debito As Integer = 0
    Dim credito As Integer = 0
    Dim ENVIADOTOTAL As Double = False
    Dim x As Integer = 2
    Dim minuto As Integer
    Dim bandera As Boolean = True
    Dim nombrearchivo As String = "\correosnominaenviados_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
    Private Excel03ConString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"
    Private Excel07ConString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"

    Private Sub Bt_Abrir_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Abrir.Click
        Bt_EnviarCorreos.Enabled = False
        Bt_ExportarEnviados.Enabled = False
        Bt_ExportarNoEnviados.Enabled = False
        Dgv_CorreosSinEnviar.Rows.Clear()
        Dgv_CorreosEnviados.Rows.Clear()
        Ofd_AbrirExcel.ShowDialog()
    End Sub

    Private Sub Ofd_AbrirExcel_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Ofd_AbrirExcel.FileOk
        'abrir excel en el datagrid
        Dim filePath As String = Ofd_AbrirExcel.FileName
        Lb_NombreArchivo.Text = filePath 'muestro la ruta del archivo
        Dim extension As String = Path.GetExtension(filePath) 'extraigo la extension, si es xls o xlsx
        Dim header As String = "YES" 'para mostrar el encabezado poner YES o NO
        Dim conStr As String, sheetName As String

        conStr = String.Empty
        Select Case extension
            Case ".xls"
                'Excel 97-03
                conStr = String.Format(Excel03ConString, filePath, header)
                Exit Select

            Case ".xlsx"
                'Excel 07
                conStr = String.Format(Excel07ConString, filePath, header)
                Exit Select

            Case Else
                MsgBox("Solo se permiten archivos de excel")
                Exit Sub
                Exit Select
        End Select

        'obtengo el nombre de la primera hoja de calculo del archivo.
        Try
            Using con As New OleDbConnection(conStr)
                Using cmd As New OleDbCommand()
                    cmd.Connection = con
                    con.Open()
                    Dim dtExcelSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                    sheetName = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al abrir el archivo, asegurese de que no lo tiene abierto con otra aplicacion")
            Exit Sub
        End Try
        'leo los datos de la primera hoja de calculo.
        Using con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                Using oda As New OleDbDataAdapter()
                    Dim dt As New DataTable()
                    cmd.CommandText = (Convert.ToString("SELECT * From [") & sheetName) + "]"
                    cmd.Connection = con
                    con.Open()
                    oda.SelectCommand = cmd
                    oda.Fill(dt)
                    con.Close()

                    '1 validacion. validar que los campos tengan un minimo de columnas de 16 y un maximo de 17 en caso de que ya tenga la fila de errores de correos no enviados
                    Dim columnas As Integer
                    columnas = dt.Columns.Count
                    If columnas <> 17 Then
                        MsgBox("el numero de columnas no coincide con el formato establecido.")
                        Exit Sub
                    End If

                    '2 validacion. validar que tenga mas de 1 fila
                    Dim filas As Integer
                    filas = dt.Rows.Count
                    If filas < 2 Then
                        MsgBox("debe haber por lo menos una fila aparte del encabezado.")
                        Exit Sub
                    End If

                    '3 validacion. validar que los nombres de las columnas son correctos
                    'deshabilitado para no generar confucsiones con los titulos de las columnas
                    'If ValidarNombresColumnas(dt) = False Then
                    '    Exit Sub
                    'End If

                    'limpio la tabla para quitar todas las filas que se encuentran vacias
                    dt = LimpiarTabla(dt)
                    If dt.Rows.Count = 0 Then
                        MsgBox("La tabla esta vacia, o puede haber un error con el tipo de campo de fecha en el excel, por favor verificar que sea correcto")
                        Exit Sub
                    End If

                    'limpio los espacios de lso nombres de las columnas
                    Dim i As Integer
                    For i = 0 To 15
                        dt.Columns(i).ColumnName = dt.Columns(i).ColumnName.Trim
                    Next

                    'lleno la grilla.
                    Dgv_Datos.DataSource = dt
                    'ordeno por cedulas
                    Dgv_Datos.Sort(Dgv_Datos.Columns(2), ComponentModel.ListSortDirection.Descending)
                    Lb_ConteoRegistros.Text = "Cantidad de Registros: " + Dgv_Datos.RowCount.ToString()
                    Bt_EnviarCorreos.Enabled = True
                End Using
            End Using
        End Using
        'validar campos
        ValidarCampos()
    End Sub

    Function ValidarNombresColumnas(ByVal dt As DataTable) As Boolean
        Dim campo() As String = {"NRO", "CODIGO", "CEDULA", "CARGO", "FRENTE", "N#FRENTE", "APELLIDOS", "NOMBRES", "F#INGRESO", "S#BASICO", "CONCEPTO", "NOMBRE DEL CONCEPTO", "CANT", "VALOR", "DETALLE", "CORREO ELECTRONICO"}
        Dim campoformato() As String = {"NRO", "CODIGO", "CEDULA", "CARGO", "FRENTE", "N.FRENTE", "APELLIDOS", "NOMBRES", "F.INGRESO", "S.BASICO", "CONCEPTO", "NOMBRE DEL CONCEPTO", "CANT", "VALOR", "DETALLE", "CORREO ELECTRONICO"}
        ValidarNombresColumnas = True
        Dim i, val As Integer
        val = 0
        For i = 0 To 15
            If dt.Columns(i).ColumnName.Trim.ToUpper = campo(i).Trim.ToUpper Then
                'el nombre de columan es correcto, no hacer nada
            Else
                MsgBox("el nombre de la columna " + campoformato(i) + " no coincide con el establecido en el formato, asegurese de que esta escrito corectamente, puede ser un problema de espacios entre palabras o de signos de puntuación")
                val = 1
                Exit For
            End If
        Next
        If val = 1 Then
            ValidarNombresColumnas = False
        End If
    End Function

    Function LimpiarTabla(ByVal dt As DataTable) As DataTable
        'buscar solo por la 1 fila, si esta vacia mirar que los demas campos esten vacios, si estan vacios borrar la fila
        Dim i, k, vacio As Integer
        Dim j As Integer
        j = dt.Rows.Count - 1
        For i = 0 To j
            If i > j Then
                Exit For
            End If
            If dt.Rows(i)(0).ToString.Trim = "" Then
                'revisar toda la fila para saber si esta vacia
                vacio = 0
                For k = 0 To 15
                    If dt.Rows(i)(k).ToString.Trim = "" Then
                        vacio = vacio + 1
                    End If
                Next
                If vacio = 16 Then
                    'borrar fila
                    dt.Rows.Remove(dt.Rows(i))
                    i = i - 1
                    j = j - 1
                    If j = 0 And i = 0 Then
                        LimpiarTabla = dt
                        Exit Function
                    End If
                End If
            End If
        Next
        LimpiarTabla = dt
    End Function

    Public Sub ValidarCampos()
        'revisar fila por fila si los campos son correctos
        Lb_Progreso.Text = "Validando campos"
        Dgv_CorreosSinEnviar.Rows.Clear()
        Dgv_CorreosEnviados.Rows.Clear()
        'limpio los espacios de los nombres de las columnas
        Dim i As Integer
        'Dim j As Integer
        Try
            For i = 0 To Dgv_Datos.RowCount - 1
                Pb_carga.Value = Int(i * 100 / (Dgv_Datos.RowCount - 1))
                If IsDBNull(Dgv_Datos.Rows(i).Cells(0).Value) = True Then
                    AgregarError(i, "columna NRO vacia, igual a 0 ó no es un número")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(1).Value) = True Then
                    AgregarError(i, "columna CODIGO vacia, igual a 0 ó no es un número")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(2).Value) = True Then
                    AgregarError(i, "columna CEDULA vacia, igual a 0 ó no es un número")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(3).Value) = True Then
                    AgregarError(i, "columna CARGO vacia")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(6).Value) = True Then
                    AgregarError(i, "columna APELLIDOS vacia")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(7).Value) = True Then
                    AgregarError(i, "columna NOMBRES vacia")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(10).Value) = True Then
                    AgregarError(i, "columna CONCEPTO vacia, igual a 0 ó no es un número")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(13).Value) = True Then
                    AgregarError(i, "columna VALOR vacia, igual a 0 ó no es un número")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(14).Value) = True Then
                    AgregarError(i, "columna DETALLE vacia")

                ElseIf IsDBNull(Dgv_Datos.Rows(i).Cells(15).Value) = True Then
                    AgregarError(i, "columna CORREO ELECTRONICO vacia")

                ElseIf Dgv_Datos.Rows(i).Cells(10).Value < 1 Or (Dgv_Datos.Rows(i).Cells(10).Value - Int(Dgv_Datos.Rows(i).Cells(10).Value)) <> 0 Then
                    AgregarError(i, "El concepto debe ser un entero positivo")

                ElseIf FuncionesBase.FuncionesBase.validarDireccionCorreo(Dgv_Datos.Rows(i).Cells(15).Value.ToString().Trim) = False Then
                    AgregarError(i, "CORREO ELECTRONICO no válido")

                Else
                    'Si pasa todos los controles quiere decir que es valido
                    AgregarValido(i)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error en validacion")
        End Try
        Pb_carga.Value = 0
        Lb_CorreosSinEnviar.Text = "Correos Inválidos: " + Dgv_CorreosSinEnviar.RowCount.ToString
        Lb_CorreosEnviados.Text = "Correos Válidos: " + Dgv_CorreosEnviados.RowCount.ToString
        If Dgv_CorreosSinEnviar.RowCount > 0 Then
            Bt_ExportarNoEnviados.Enabled = True
        End If

        If Dgv_CorreosEnviados.RowCount > 0 Then
            Bt_ExportarEnviados.Enabled = True
        End If
    End Sub

    Private Sub Bt_EnviarCorreos_Click(sender As System.Object, e As System.EventArgs) Handles Bt_EnviarCorreos.Click
        Pb_carga.Minimum = 0
        Pb_carga.Maximum = Dgv_Datos.RowCount
        DeshabilitarControles()
        bgw_correos.RunWorkerAsync()
    End Sub

    Private Sub DeshabilitarControles()
        Bt_Abrir.Enabled = False
        Bt_DescargarFormato.Enabled = False
        Bt_EnviarCorreos.Enabled = False
        Bt_ExportarEnviados.Enabled = False
        Bt_ExportarNoEnviados.Enabled = False
        Me.ControlBox = False
    End Sub

    Private Sub HabilitarControles()
        Bt_Abrir.Enabled = True
        Bt_DescargarFormato.Enabled = True
        Bt_EnviarCorreos.Enabled = True
        Bt_ExportarEnviados.Enabled = True
        Bt_ExportarNoEnviados.Enabled = True
        Me.ControlBox = True
    End Sub

    Public Sub AgregarError(ByVal i As Integer, ByVal TipoError As String)
        Dim j As Integer
        Dgv_CorreosSinEnviar.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        For j = 0 To 15
            Dgv_CorreosSinEnviar.Rows(Dgv_CorreosSinEnviar.RowCount - 1).Cells(j).Value = Dgv_Datos.Rows(i).Cells(j).Value
        Next
        Dgv_CorreosSinEnviar.Rows(Dgv_CorreosSinEnviar.RowCount - 1).Cells(16).Value = TipoError
    End Sub

    Public Sub AgregarErrorEnvio(ByVal i As Integer, ByVal TipoError As String)
        Dim j As Integer
        Dgv_CorreosSinEnviar.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        For j = 0 To 15
            Dgv_CorreosSinEnviar.Rows(Dgv_CorreosSinEnviar.RowCount - 1).Cells(j).Value = Dgv_CorreosEnviados.Rows(i).Cells(j).Value
        Next
        Dgv_CorreosSinEnviar.Rows(Dgv_CorreosSinEnviar.RowCount - 1).Cells(16).Value = TipoError
    End Sub

    Public Sub AgregarValido(ByVal i As Integer)
        Dim j As Integer
        Dgv_CorreosEnviados.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
        For j = 0 To 15
            Dgv_CorreosEnviados.Rows(Dgv_CorreosEnviados.RowCount - 1).Cells(j).Value = Dgv_Datos.Rows(i).Cells(j).Value
        Next
    End Sub


    Private Sub Fr_EnviarCorreosNomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dgv_Datos.AutoGenerateColumns = False
    End Sub

    Private Sub Bt_ExportarNoEnviados_Click(sender As System.Object, e As System.EventArgs) Handles Bt_ExportarNoEnviados.Click
        If Dgv_CorreosSinEnviar.RowCount = 0 Then
            MsgBox("tabla vacia")
            Exit Sub
        End If
        FuncionesBase.FuncionesBase.ExportarDatosExcel(Dgv_CorreosSinEnviar, "Correos No Enviados")
    End Sub

    Private Sub Bt_ExportarEnviados_Click(sender As System.Object, e As System.EventArgs) Handles Bt_ExportarEnviados.Click
        If Dgv_CorreosEnviados.RowCount = 0 Then
            MsgBox("tabla vacia")
            Exit Sub
        End If
        FuncionesBase.FuncionesBase.ExportarDatosExcel(Dgv_CorreosEnviados, "Correos Enviados")
    End Sub

    Private Sub EnviarCorreos()
        If Dgv_CorreosEnviados.RowCount = 0 Then
            MsgBox("no hay correos para enviar")
            Exit Sub
        End If

        VariablesBase.VariablesBase.TablaCorreosEnviados.Clear()

        Dim conteo As Integer = 0
        Dim fila As Integer
        For fila = 0 To Dgv_Datos.RowCount - 2
            If Dgv_Datos.Rows(fila).Cells("CORREO_ELECTRONICO").Value <> Dgv_Datos.Rows(fila + 1).Cells("CORREO_ELECTRONICO").Value Then
                conteo += 1
            End If
        Next
        If Dgv_Datos.Rows(Dgv_Datos.RowCount - 1).Cells("CORREO_ELECTRONICO").Value <> Dgv_Datos.Rows(Dgv_Datos.RowCount - 2).Cells("CORREO_ELECTRONICO").Value Then
            conteo += 1
        End If
        If conteo = 0 Then
            conteo = 1
        End If
        ''hacer el conteo de correos sin repetir
        'If 1350 - dsconteo.Tables(0).Rows(0)(0) - conteo < 0 Then
        '    MsgBox("El dia de hoy se han enviado " + dsconteo.Tables(0).Rows(0)(0).ToString + " Correos, el envio maximo de correos al dia es de 1350 y usted esta intentando enviar " + Dgv_CorreosEnviados.RowCount.ToString + ", lo sentimos pero debe esperar hasta el dia de mañana o reducir el numero de correos para enviar la cantidad deseada ")

        '    Exit Sub
        'End If

        'MsgBox("Se van a Enviar: " + conteo.ToString + " Correos, hoy se han enviado: " + dsconteo.Tables(0).Rows(0)("ENVIADOS").ToString + "correos", MsgBoxStyle.OkOnly, "CONFIRMACION DE ENVIO")

        MsgBox("Se van a Enviar: " + conteo.ToString + "correos", MsgBoxStyle.OkOnly, "CONFIRMACION DE ENVIO")

        'Pb_carga.Minimum = 0
        'Pb_carga.Maximum = Dgv_Datos.RowCount
        Dim cuerpo As String
        Dim i, iPivote, ipivote2, val As Integer
        Dim totalDEV, totalDED As Double
        Dim nfi2 As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
        Dim nfi0 As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
        nfi0.NumberDecimalDigits = 0
        'Dim j As Integer
        For i = 0 To Dgv_CorreosEnviados.RowCount - 1
            Try
                'Lb_Progreso.Text =
                bgw_correos.ReportProgress(i, "Verificando Correos" + Dgv_CorreosEnviados.Rows(i).Cells(6).Value.ToString.Trim.ToUpper + " " + Dgv_CorreosEnviados.Rows(i).Cells(7).Value.ToString.Trim.ToUpper)
                val = 0 ' para revisar si se saltaron filas por devengaciones y deducidos
                'CAPTURO TODAS LAS VARIABLES POR SI ESTAN VACIAS PARA QUE NO LANCEN ERROR
                cuerpo = ""
                'crear cuerpo
                cuerpo = "<center>"
                cuerpo += "<div style =""padding:10px; max-width :1000px; "">"
                cuerpo += "<table style =""width:100%;"">"
                cuerpo += "    <tr style=""border:1px solid;"">"
                cuerpo += "        <td style=""width:170px; text-align:center; padding:10px;""><img src=""http://190.0.43.174:7070/imagenes/logo.png"" width=""150px"" /></td>"
                cuerpo += "        <td style=""text-align:center; padding:5px;""><b>ISMOCOL S.A.<br />Calle 100 No. 13-76 Piso 7° - Edificio Mansarovar - BOGOTÁ D.C.<br />CRA. 28 No. 55-69 - BUCARAMANGA</b><br />LIQUIDACIÓN: "
                cuerpo += "            " + Dgv_CorreosEnviados.Rows(i).Cells(14).Value.ToString + "<br />" 'DETALLE
                cuerpo += "            " + Dgv_CorreosEnviados.Rows(i).Cells(4).Value.ToString + "&nbsp;&nbsp;&nbsp;&nbsp;" + Dgv_CorreosEnviados.Rows(i).Cells(5).Value.ToString 'FRENTE Y # DE FRENTE
                cuerpo += "        </td>"
                cuerpo += "        <td>SISTEMA DE NÓMINA<br />"
                cuerpo += Date.Now.ToString 'fecha actual
                cuerpo += "        </td>"
                cuerpo += "    </tr>"
                cuerpo += "</table>"
                cuerpo += "<hr style=""border-style:groove;"" />"
                cuerpo += "<table  style=""width:100%;"" border='1' cellpadding='7' cellspacing='0'>"
                cuerpo += "    <tr>"
                cuerpo += "        <td><b>Código del Empleado:</b></td>"
                cuerpo += "        <td>" + Dgv_CorreosEnviados.Rows(i).Cells(1).Value.ToString + "</td>"
                cuerpo += "        <td><b>Cargo:</b></td>"
                cuerpo += "        <td>" + Dgv_CorreosEnviados.Rows(i).Cells(3).Value.ToString + "</td>"
                cuerpo += "        <td><b>F. Ingreso</b></td>"
                Dim culture As New CultureInfo("pt-BR")
                cuerpo += "        <td>" + Date.Parse(Dgv_CorreosEnviados.Rows(i).Cells(8).Value).ToString("d", culture) + "</td>"
                cuerpo += "        <td><b>Sueldo:</b></td>"
                cuerpo += "        <td style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(9).Value).ToString("C") + "</td>"
                cuerpo += "    </tr>"
                cuerpo += "    <tr>"
                cuerpo += "        <td><b>Nombre:</b></td>"
                cuerpo += "        <td colspan='5'>" + Dgv_CorreosEnviados.Rows(i).Cells(6).Value.ToString.Trim.ToUpper + " " + Dgv_CorreosEnviados.Rows(i).Cells(7).Value.ToString.Trim.ToUpper + "</td>"
                cuerpo += "        <td><b>Documento:</b></td>"
                cuerpo += "        <td style=""text-align:center;"">" + Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(2).Value).ToString("N", nfi0) + "</td>"
                cuerpo += "    </tr>"
                cuerpo += "    <tr>"
                cuerpo += "        <td colspan='8' style=""text-align:center; background-color:silver;""><b>DEVENGADOS</b></td>"
                cuerpo += "    </tr>"
                cuerpo += "    <tr>"
                cuerpo += "        <td style=""text-align:center;"">CODIGO</td>"
                cuerpo += "        <td colspan='4' style=""text-align:center;"">CONCEPTO</td>"
                cuerpo += "        <td style=""text-align:center;"">CANTIDAD</td>"
                'cuerpo += "        <td colspan=""3"" style=""text-align:center;"">BASICO</td>"
                cuerpo += "        <td colspan=""2"" style=""text-align:center;"">TOTAL</td>"
                cuerpo += "    </tr>"

                'CALCULAR TODOS LOS DEVENGADOS, las filas estan ordenadas por cedulas +++++++++++++++++++
                totalDEV = 0
                totalDED = 0
                Dim z As Integer
                z = i + 1
                iPivote = i
                If z > Dgv_CorreosEnviados.Rows.Count - 1 Then 'la ultima fila es un unico registro 
                    'revisar si el valor es devengado
                    If Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value < 2000 Or Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value > 2999 Then 'empiezan por 1 o 3 son devengados
                        cuerpo += "<tr>"
                        cuerpo += "    <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value.ToString + "</td>" 'codigo del concepto
                        cuerpo += "    <td colspan='4' style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(11).Value.ToString + "</td>" 'concepto
                        cuerpo += "    <td  style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(12).Value.ToString + "</td>" 'cantidad
                        'cuerpo += "    <td colspan='3'  style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(iPivote).Cells(9).Value).ToString("C2") + "</td>" 'basico
                        cuerpo += "    <td colspan='2'  style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value).ToString("C2") + "</td>" 'total
                        cuerpo += "</tr>"
                        totalDEV = Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value
                        cuerpo += "    <tr>"
                        cuerpo += "        <td colspan='8' style=""text-align:center;"">TOTAL DEVENGADOS: <b>" + totalDEV.ToString("C2") + "</b></td>"
                        cuerpo += "    </tr>"
                        '+++++++++++++++++++++

                        cuerpo += "    <tr>"
                        cuerpo += "        <td colspan='8' style=""text-align:center; background-color:silver;""><b>DEDUCIDOS</b></td>"
                        cuerpo += "    </tr>"
                        cuerpo += "    <tr>"
                        cuerpo += "        <td style=""text-align:center;"">CODIGO</td>"
                        cuerpo += "        <td colspan='5' style=""text-align:center;"">CONCEPTO</td>"
                        cuerpo += "        <td colspan ='2' style=""text-align:center;"">CUOTA</td>"
                        cuerpo += "    </tr>"
                    Else
                        'deducido
                        cuerpo += "    <tr>"
                        cuerpo += "        <td colspan='8' style=""text-align:center; background-color:silver;""><b>DEDUCIDOS</b></td>"
                        cuerpo += "    </tr>"
                        cuerpo += "    <tr>"
                        cuerpo += "        <td style=""text-align:center;"">CODIGO</td>"
                        cuerpo += "        <td colspan='5' style=""text-align:center;"">CONCEPTO</td>"
                        cuerpo += "        <td colspan ='2' style=""text-align:center;"">CUOTA</td>"
                        cuerpo += "    </tr>"
                        cuerpo += "    <tr>"
                        cuerpo += "        <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(10).Value.ToString + "</td>" 'codigo
                        cuerpo += "        <td colspan='5' style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(11).Value.ToString + "</td>" ' concepto
                        cuerpo += "        <td colspan ='2' style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(13).Value).ToString("C2") + "</td>" 'valor
                        cuerpo += "    </tr>"
                        totalDED = Dgv_CorreosEnviados.Rows(i).Cells(13).Value
                    End If
                Else
                    If Dgv_CorreosEnviados.Rows(i).Cells(2).Value.ToString.Trim = Dgv_CorreosEnviados.Rows(i + 1).Cells(2).Value.ToString.Trim Then
                        'hay mas de un valor devengado, crear las lineas en la tabla donde se devenga para la misma persona
                        val = 1 ' al final del ciclo se saltan las posiciones que se encontraron
                        iPivote = i
                        While Dgv_CorreosEnviados.Rows(iPivote).Cells(2).Value.ToString.Trim = Dgv_CorreosEnviados.Rows(iPivote + 1).Cells(2).Value.ToString.Trim
                            iPivote += 1
                            ipivote2 = iPivote
                            If iPivote + 1 >= Dgv_CorreosEnviados.RowCount Then
                                Exit While
                            End If
                        End While
                        For iPivote = i To ipivote2
                            'revisar si el valor es devengado
                            If Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value < 2000 Or Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value > 2999 Then 'empiezan por 1 o 3 son devengados
                                cuerpo += "<tr>"
                                cuerpo += "    <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value.ToString + "</td>" 'codigo del concepto
                                cuerpo += "    <td colspan='4' style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(11).Value.ToString + "</td>" 'concepto
                                cuerpo += "    <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(12).Value.ToString + "</td>" 'cantidad
                                'cuerpo += "    <td colspan='3'  style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(iPivote).Cells(9).Value).ToString("C2") + "</td>" 'basico
                                cuerpo += "    <td colspan='2'  style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value).ToString("C2") + "</td>" 'total
                                cuerpo += "</tr>"
                                totalDEV += Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value
                            Else
                                'no se hace nada porque es un deducido
                            End If
                        Next
                    Else
                        val = 0
                        'revisar si el valor es devengado
                        If Dgv_CorreosEnviados.Rows(i).Cells(10).Value < 2000 Or Dgv_CorreosEnviados.Rows(i).Cells(10).Value > 2999 Then 'empiezan por 1 o 3 son devengados
                            cuerpo += "<tr>"
                            cuerpo += "    <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(10).Value.ToString + "</td>" 'codigo del concepto
                            cuerpo += "    <td colspan='4' style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(11).Value.ToString + "</td>" 'concepto
                            cuerpo += "    <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(12).Value.ToString + "</td>" 'cantidad
                            'cuerpo += "    <td colspan='3' style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(iPivote).Cells(9).Value).ToString("C2") + "</td>" 'basico
                            cuerpo += "    <td colspan='2' style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(13).Value).ToString("C2") + "</td>" 'total 
                            totalDEV += Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value
                            cuerpo += "</tr>"
                        Else
                            'no se hace nada porque es un deducido
                        End If
                    End If

                    cuerpo += "    <tr>"
                    cuerpo += "        <td colspan='8' style=""text-align:center;"">TOTAL DEVENGADOS: <b>" + totalDEV.ToString("C2") + "</b></td>"
                    cuerpo += "    </tr>"
                    '+++++++++++++++++++++

                    cuerpo += "    <tr>"
                    cuerpo += "        <td colspan='8' style=""text-align:center; background-color:silver;""><b>DEDUCIDOS</b></td>"
                    cuerpo += "    </tr>"
                    cuerpo += "    <tr>"
                    cuerpo += "        <td style=""text-align:center;"">CODIGO</td>"
                    cuerpo += "        <td colspan='5' style=""text-align:center;"">CONCEPTO</td>"
                    cuerpo += "        <td colspan ='2' style=""text-align:center;"">CUOTA</td>"
                    cuerpo += "    </tr>"

                    'CALCULAR TODOS LOS DEDUCIDOS -----------
                    totalDED = 0
                    If val = 1 Then
                        'existen mas de 1 valor para la misma persona
                        For iPivote = i To ipivote2
                            'revisar si el valor es devengado
                            If Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value > 1999 And Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value < 3000 Then 'si empieza por 2 es un deducido
                                cuerpo += "    <tr>"
                                cuerpo += "        <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(10).Value.ToString + "</td>" 'codigo
                                cuerpo += "        <td colspan='5' style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(iPivote).Cells(11).Value.ToString + "</td>" ' concepto
                                cuerpo += "        <td colspan ='2' style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value).ToString("C2") + "</td>" 'valor
                                cuerpo += "    </tr>"
                                totalDED += Dgv_CorreosEnviados.Rows(iPivote).Cells(13).Value
                            Else
                                'no se hace nada porque debe ser un devengado
                            End If
                        Next
                    Else
                        'existe solo un unico valor
                        If Dgv_CorreosEnviados.Rows(i).Cells(10).Value > 1999 And Dgv_CorreosEnviados.Rows(i).Cells(10).Value < 3000 Then 'si empieza por 2 es un deducido
                            cuerpo += "    <tr>"
                            cuerpo += "        <td style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(10).Value.ToString + "</td>" 'codigo
                            cuerpo += "        <td colspan='5' style=""text-align:center;"">" + Dgv_CorreosEnviados.Rows(i).Cells(11).Value.ToString + "</td>" ' concepto
                            cuerpo += "        <td colspan ='2' style=""text-align:right"">" + Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(13).Value).ToString("C2") + "</td>" 'valor
                            cuerpo += "    </tr>"
                            totalDED += Dgv_CorreosEnviados.Rows(i).Cells(13).Value
                        Else
                            'no se hace nada porque debe ser un devengado
                        End If
                    End If
                End If
                cuerpo += "    <tr>"
                cuerpo += "        <td colspan='8' style=""text-align:center;"">TOTAL DEDUCIDOS: <b>" + totalDED.ToString("C2") + "</b></td>"
                cuerpo += "    </tr>"
                '--------------
                cuerpo += "    <tr>"
                cuerpo += "        <td colspan='8' style=""text-align:center; background-color:silver;""></td>"
                cuerpo += "    </tr>"
                cuerpo += "    <tr>"
                cuerpo += "        <td colspan='8' style=""text-align:center; font-size:larger;""><b>TOTAL NETO A PAGAR: " + (totalDEV - totalDED).ToString("C2") + "</b></td>"
                cuerpo += "    </tr>"
                cuerpo += "</table><hr style=""border-style:groove;"" />"
                cuerpo += "<p style=""text-align:left"">ENVÍO RELACIÓN DE PAGO POR NOMINA Y SUS RESPECTIVOS DESCUENTOS. "
                cuerpo += "ESTE CORREO FUE EMITIDO AUTOMÁTICAMENTE, FAVOR NO CONTESTAR. CUALQUIER INQUIETUD FAVOR REMITIRSE AL SIGUIENTE CORREO ELECTRÓNICO: nomina@ismocol.com</p>"
                If val = 1 Then 'si habia mas de un pago a la misma persona se pone como posicion el ultimo registro de esa persona para que continue con la siguiente
                    i = ipivote2
                End If
                'cierro el cuerpo
                cuerpo += "     </div>"
                cuerpo += "</center>"

            Catch ex As Exception
                MsgBox("error al crear cuerpo")
                'grabo la ultima posicion de envio y termino el procedimiento
                MsgBox(ex.ToString)
                bgw_correos.ReportProgress(i, "AgregarErrorEnvio")
                bgw_correos.ReportProgress(i, "Error de envio en este registro")
                'Lb_CorreosSinEnviar.Text = "Error de envio en este registro"
                'limpio los correos que no se enviaron para mostrarle al usuario solo los que lograron enviarse
                bgw_correos.ReportProgress(i, "BorrarDesdeEnviados")
                ''BorrarDesdeEnviados(i)
                'bgw_correos.ReportProgress(i, "Guardando tablas en la base de datos")
                ''Lb_Progreso.Text = "Guardando tablas en la base de datos"
                'Try
                '    GuardarTabla()
                '    MsgBox("Registros alcanzados a enviar Guardados en la base de datos")
                'Catch ex2 As Exception
                '    MsgBox("Error al guardar en la base de datos")
                'End Try
                HabilitarControles()
                Exit Sub
            End Try
            'ENVIAR EL CORREO
            Try
                'SI SE DESEA SOLO GRABAR LOS REGISTROS SIN ENVIAR CORREOS COMENTAR LA LINEA DE ABAJO
                enviarConfirmacion(cuerpo, Dgv_CorreosEnviados.Rows(i).Cells(14).Value.ToString, Dgv_CorreosEnviados.Rows(i).Cells(15).Value.ToString, i) 'envio de correo
                'enviarConfirmacion(cuerpo, Dgv_CorreosEnviados.Rows(i).Cells(14).Value.ToString, "desprendibles.nomina@ismocol.com", i) 'envio de correo
                'System.Threading.Thread.Sleep(200)
            Catch ex As Exception
                'grabo la ultima posicion de envio y termino el procedimiento
                MsgBox(ex.ToString)
                bgw_correos.ReportProgress(i, "AgregarErrorEnvio")
                'Lb_CorreosSinEnviar.Text = "Error de envio en este registro"
                bgw_correos.ReportProgress(i, "Error de envio en este registro")
                bgw_correos.ReportProgress(i, "BorrarDesdeEnviados")
                'BorrarDesdeEnviados(i)
                'bgw_correos.ReportProgress(i, "Guardando tablas en la base de datos")
                ''Lb_Progreso.Text = "Guardando tablas en la base de datos"
                'Try
                '    GuardarTabla()
                '    MsgBox("Registros alcanzados a enviar Guardados en la base de datos")
                'Catch ex3 As Exception
                '    MsgBox("Error al guardar en la base de datos")
                'End Try
                'HabilitarControles()
                'Exit Sub
            End Try
        Next
        MsgBox("Correos Enviados con exito,", MsgBoxStyle.OkOnly, "CONFIRMACION DE ENVIO")

        If MsgBox("¿Visualizar el registro de envío de correos?", MsgBoxStyle.YesNo, "Visualizar registro correos") = MsgBoxResult.Yes Then
            visorCorreos(nombrearchivo)
        End If
        'Pb_carga.Value = 0
        'bgw_correos.ReportProgress(100, "Guardando tablas en la base de datos")
        ''Lb_Progreso.Text = "Guardando tablas en la base de datos"
        'Try
        '    GuardarTabla()
        '    MsgBox("Registros Guardados")
        'Catch ex As Exception
        '    MsgBox("Error al guardar en la base de datos")
        '    HabilitarControles()
        'End Try
    End Sub

    Public Sub enviarConfirmacion(ByVal textoContenido As String, ByVal asunto As String, ByVal CorreoPara As String, ByVal conteo As Integer)
       
        If IO.File.Exists(VariablesBase.VariablesBase._path + nombrearchivo) = True Then

            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + nombrearchivo, True)

        Else
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\" + nombrearchivo)
        End If
        'Open the file.

        Dim correoOrigen As String
        Dim correoOrigenClave As String

        correoOrigen = "desprendibles.nomina@ismocol.com" 'cambiar este correo 
        correoOrigenClave = "Dpg98765" 'y esta clave

        Try
            ' Se arma el html que va a llegar al correo
            Dim cuerpo As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
            cuerpo += "<html xmlns=""http://www.w3.org/1999/xhtml"">"
            cuerpo += "<head>"
            cuerpo += "<meta http-equiv=""Content-Type"" content=""text/html charset=utf-8"" />"
            cuerpo += "<title>REQUISICIÓN</title>"
            cuerpo += "</head>"
            cuerpo += "<body>"
            cuerpo += "<center>"
            cuerpo += textoContenido
            cuerpo += "</center>"
            cuerpo += "</body>"
            cuerpo += "</html>"

            '********************************************** Envío de mail ************************************************/

            Dim correoDestino As String = CorreoPara
            Dim SmtpServer As New SmtpClient("smtp-relay.gmail.com", 587)
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
            SmtpServer.EnableSsl = True
            Dim mail As New MailMessage(correoOrigen, Trim(correoDestino).Replace(" ", "").Replace(vbCrLf, "").Replace(vbLf, ""), asunto, cuerpo)
            mail.IsBodyHtml = True
            mail.Priority = MailPriority.Normal
            'QUITAR PARA HQUE FUNCIONE
            SmtpServer.Send(mail)
            'Write a line of text.
            objStreamWriter.WriteLine(CorreoPara + ">" + "SI>" + Date.Now.ToString + ">" + correoOrigen)
            FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(CorreoPara, "SI", correoOrigen)
            objStreamWriter.Close()
            System.Threading.Thread.Sleep(VariablesBase.VariablesBase.TiempoEsperaEnvioCorreo) 'Pausa para que el servidor de correo no lo tome como SPAM y presente bloqueo, sugerencia de personal tecnico de google
        Catch ex As Exception
            'Write a line of text.
            objStreamWriter.WriteLine(CorreoPara + ">" + "NO>" + Date.Now.ToString + ">" + correoOrigen)
            FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(CorreoPara, "NO", correoOrigen)
            objStreamWriter.Close()
        End Try

    End Sub

    Public Sub visorCorreos(ByVal nombre As String)
        Dim FrVisorRegistrosCorreo As New FormulariosClasesBase.Fr_VisorRegistrosCorreo
        FrVisorRegistrosCorreo._nombreArchivo = nombre.ToString
        FrVisorRegistrosCorreo.ShowDialog()
    End Sub


    Public Sub BorrarDesdeEnviados(ByVal desde As Integer)
        Dim total As Integer = Dgv_CorreosEnviados.RowCount - 1 - desde
        Dim i As Integer
        For i = 0 To total
            Dgv_CorreosEnviados.Rows.Remove(Dgv_CorreosEnviados.Rows(desde))
        Next
        Lb_CorreosEnviados.Text = "Correos enviados hasta el error: " + Dgv_CorreosEnviados.RowCount.ToString + " puede exportarlos si desea."
    End Sub

    Private Sub Bt_DescargarFormato_Click(sender As System.Object, e As System.EventArgs) Handles Bt_DescargarFormato.Click
        'DESCARGAR LA HOJA DE EJEMPLO
        Dim FILE_NAME As String = "D:\prognet\adminrecursosismocol\datossiscontrol\Plantilla Ejemplo Nomina.xls"
        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        Else
            MsgBox("Lo Sentimos, archivo no encontrado.")
        End If
    End Sub

    'Dim bddatos As New DatosSisControl.ClaseDatosSisControl

    'Public Sub GuardarTabla()
    '    Dim i As Integer = 0
    '    Dim dsguardar As New DataSet
    '    For i = 0 To Dgv_CorreosEnviados.RowCount - 1
    '        'Pb_carga.Value = Int(i * 100 / (Dgv_Datos.RowCount - 1))
    '        'revisar campos y lso que esten nulos volverlos vacios
    '        Dim NRO, CODIGO, CONCEPTO, CANT, FRENTE As Integer
    '        Dim CARGO, N_FRENTE, APELLIDOS, NOMBRES, NOMBRE_CONCEPTO, DETALLE, CORREO_ELECTRONICO As String
    '        Dim CEDULA, S_BASICO, VALOR As Double
    '        Dim F_INGRESO As Date
    '        NRO = Integer.Parse(Dgv_CorreosEnviados.Rows(i).Cells(0).Value).ToString
    '        CODIGO = Integer.Parse(Dgv_CorreosEnviados.Rows(i).Cells(1).Value.ToString)
    '        CEDULA = Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(2).Value.ToString)
    '        CARGO = Dgv_CorreosEnviados.Rows(i).Cells(3).Value.ToString
    '        FRENTE = Integer.Parse(Dgv_CorreosEnviados.Rows(i).Cells(4).Value.ToString)
    '        N_FRENTE = Dgv_CorreosEnviados.Rows(i).Cells(5).Value.ToString
    '        APELLIDOS = Dgv_CorreosEnviados.Rows(i).Cells(6).Value.ToString
    '        NOMBRES = Dgv_CorreosEnviados.Rows(i).Cells(7).Value.ToString
    '        F_INGRESO = Date.Parse(Dgv_CorreosEnviados.Rows(i).Cells(8).Value).ToString
    '        S_BASICO = Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(9).Value.ToString)
    '        CONCEPTO = Integer.Parse(Dgv_CorreosEnviados.Rows(i).Cells(10).Value.ToString)
    '        NOMBRE_CONCEPTO = Dgv_CorreosEnviados.Rows(i).Cells(11).Value.ToString
    '        If IsDBNull(Dgv_CorreosEnviados.Rows(i).Cells(12).Value) = True Then
    '            CANT = 0
    '        Else
    '            CANT = Integer.Parse(Dgv_CorreosEnviados.Rows(i).Cells(12).Value.ToString)
    '        End If
    '        VALOR = Double.Parse(Dgv_CorreosEnviados.Rows(i).Cells(13).Value.ToString)
    '        DETALLE = Dgv_CorreosEnviados.Rows(i).Cells(14).Value.ToString
    '        CORREO_ELECTRONICO = Dgv_CorreosEnviados.Rows(i).Cells(15).Value.ToString
    '        'guardar los registros en la base de datos
    '        dsguardar = bddatos.ModificarDesprendibles(1, 0, NRO, CODIGO, CEDULA, CARGO, FRENTE, N_FRENTE, APELLIDOS, NOMBRES, F_INGRESO, S_BASICO, CONCEPTO, NOMBRE_CONCEPTO, CANT, VALOR, DETALLE, CORREO_ELECTRONICO, Date.Now)

    '    Next
    '    'Lb_Progreso.Text = "Finalizado"
    '    'Pb_carga.Value = 0
    'End Sub

    Private Sub bgw_correos_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles bgw_correos.ProgressChanged
        Pb_carga.Minimum = 0
        Pb_carga.Maximum = Dgv_Datos.RowCount
        If e.ProgressPercentage = 100 Then
            Pb_carga.Value = Dgv_Datos.RowCount
            'HabilitarControles()
        Else
            Pb_carga.Value = e.ProgressPercentage
        End If

        Lb_Progreso.Text = e.UserState.ToString
        If e.UserState = "Error de envio en este registro" Then
            Lb_CorreosSinEnviar.Text = "Error de envio en este registro"
        End If
        If e.UserState = "BorrarDesdeEnviados" Then
            BorrarDesdeEnviados(e.ProgressPercentage)
        End If
        If e.UserState = "AgregarErrorEnvio" Then
            AgregarErrorEnvio(e.ProgressPercentage, "Error Inesperado en creación del cuerpo de correo, intente enviar los campos a partir de este regitro, datos tecnicos: ")
        End If
    End Sub

    Private Sub bgw_correos_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bgw_correos.DoWork
        EnviarCorreos()
    End Sub

    Private Sub bgw_correos_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_correos.RunWorkerCompleted
        HabilitarControles()

    End Sub
End Class

