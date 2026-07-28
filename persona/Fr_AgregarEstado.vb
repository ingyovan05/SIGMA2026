Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.Net.Mail

Public Class Fr_AgregarEstado

    Property IDENTIFICACION As String
    Property TIPO_ As String
    Property IDPERSONA_ As Integer

    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private dsMaestras As DataSet
    Public tipoModulo As String

    Public Sub Cargar(ByVal Tipo As String)
        TIPO_ = Tipo
        Dim Accion As Integer = -1
        Select Case Tipo
            Case "I" 'insertar un registro
                Me.Dgv_Historial.Visible = False
                Me.Lb_Mensaje.Visible = False
                Accion = 3
                Me.Bt_Aceptar.Text = "Guardar"
            Case "C" 'consultar una persona si esta bloqueada
                Me.Dgv_Historial.Visible = False
                Me.Lb_Mensaje.Visible = True
                Me.Lb_Mensaje.Dock = Windows.Forms.DockStyle.Fill
                Me.Lb_Estado.Visible = False
                Accion = 1
                Me.Bt_Aceptar.Visible = False
                Me.Button_Cancelar.Text = "Cerrar"
            Case "H" ' ver el historial de una persona
                Me.Dgv_Historial.Visible = True
                Me.Lb_Mensaje.Visible = False
                Me.Dgv_Historial.Dock = Windows.Forms.DockStyle.Fill
                Me.Height = 300
                Accion = 2
                AplicarFormatoColumnas()
                Me.Bt_Aceptar.Visible = False
                Me.Button_Cancelar.Text = "Cerrar"
            Case "X" ' ver el historial de consultas de una persona
                Me.Dgv_Historial.Visible = True
                Me.Lb_Mensaje.Visible = False
                Me.Dgv_Historial.Dock = Windows.Forms.DockStyle.Fill
                Me.Height = 300
                Accion = 4
                AplicarFormatoColumnas()
                Me.Bt_Aceptar.Visible = False
                Me.Button_Cancelar.Text = "Cerrar"
        End Select

        comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
        comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
        comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
        comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
        comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

        comando.Parameters("@Accion").Value = Accion
        comando.Parameters("@ACCESODENEGADO").Value = ""
        comando.Parameters("@IDPERSONA").Value = -1
        comando.Parameters("@IDENTIFICACION").Value = IDENTIFICACION
        comando.Parameters("@TIPOMODULO").Value = tipoModulo
        comando.Parameters("@TIPOOBSERVACION").Value = ""
        comando.Parameters("@OBSERVACION").Value = ""
        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

        comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

        adaptador = New SqlDataAdapter(comando)
        dsMaestras = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaestras)
            conexion.Close()
            Select Case comando.Parameters("@IDMENSAJE").Value
                Case 1
                    Select Case Tipo
                        Case "I" 'insertar un registro
                            Me.Cb_TipoObservación.DataSource = dsMaestras.Tables(0)
                            Me.Cb_TipoObservación.DisplayMember = "NOMBRE"
                            Me.Cb_TipoObservación.ValueMember = "CODIGO"
                            Dim fila As DataRow
                            fila = dsMaestras.Tables(1).Rows(0)
                            Me.Label_Nombre.Text = "Nombre: " + fila("NOMBRE")
                            Me.Label_Cedula.Text = "Identificación: " + FuncionesBase.FuncionesBase.FormatearIdentificacion(fila("IDENTIFICACION"))
                            If fila("ACCESODENEGADO") = "S" Then
                                Me.Lb_Estado.Text = "ESTADO: ACCESO DENEGADO"
                                Me.Lb_Estado.ForeColor = Drawing.Color.Red
                            Else
                                Me.Lb_Estado.Text = "ESTADO: ACCESO PERMITIDO"
                                Me.Lb_Estado.ForeColor = Drawing.Color.Blue
                            End If
                            IDPERSONA_ = fila("IDPERSONA")
                        Case "C" 'consultar una persona si esta bloqueada
                            Dim fila As DataRow
                            fila = dsMaestras.Tables(0).Rows(0)
                            Me.Label_Nombre.Text = "Nombre: " + fila("NOMBRE")
                            Me.Label_Cedula.Text = "Identificación: " + FuncionesBase.FuncionesBase.FormatearIdentificacion(fila("IDENTIFICACION"))
                            If fila("ACCESODENEGADO") = "S" Then
                                Me.Lb_Mensaje.Text = "ACCESO DENEGADO"
                            Else
                                Me.Lb_Mensaje.Text = "CONTINUAR CON LA VERIFICACION DE ACCESO"
                            End If
                            Me.Lb_Estado.Visible = False
                            IDPERSONA_ = fila("IDPERSONA")
                        Case "H" ' ver el resumen de registros de una persona de una persona
                            Me.Dgv_Historial.DataSource = dsMaestras.Tables(0)
                            Dim fila As DataRow
                            fila = dsMaestras.Tables(1).Rows(0)
                            Me.Label_Nombre.Text = "Nombre: " + fila("NOMBRE")
                            Me.Label_Cedula.Text = "Identificación: " + FuncionesBase.FuncionesBase.FormatearIdentificacion(fila("IDENTIFICACION"))
                            If fila("ACCESODENEGADO") = "S" Then
                                Me.Lb_Estado.Text = "ESTADO: ACCESO DENEGADO"
                                Me.Lb_Estado.ForeColor = Drawing.Color.Red
                            Else
                                Me.Lb_Estado.Text = "ESTADO: ACCESO PERMITIDO"
                                Me.Lb_Estado.ForeColor = Drawing.Color.Blue
                            End If
                            IDPERSONA_ = fila("IDPERSONA")
                        Case "X" 'ver el historial de consultas realizadas a una persona
                            Me.Dgv_Historial.DataSource = dsMaestras.Tables(0)
                            Dim fila As DataRow
                            fila = dsMaestras.Tables(1).Rows(0)
                            Me.Label_Nombre.Text = "Nombre: " + fila("NOMBRE")
                            Me.Label_Cedula.Text = "Identificación: " + FuncionesBase.FuncionesBase.FormatearIdentificacion(fila("IDENTIFICACION"))
                            If fila("ACCESODENEGADO") = "S" Then
                                Me.Lb_Estado.Text = "ESTADO: ACCESO DENEGADO"
                                Me.Lb_Estado.ForeColor = Drawing.Color.Red
                            Else
                                Me.Lb_Estado.Text = "ESTADO: ACCESO PERMITIDO"
                                Me.Lb_Estado.ForeColor = Drawing.Color.Blue
                            End If
                            IDPERSONA_ = fila("IDPERSONA")
                    End Select
                Case 2
                    Me.Lb_Mensaje.Visible = True
                    Me.Lb_Mensaje.Dock = DockStyle.Fill
                    Me.Lb_Mensaje.Text = "No se tiene registro con el nro de identificación digitado"
            End Select

        Catch ex As Exception
            MessageBox.Show("Error al carlos los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        'validar
        If Me.Cb_TipoObservación.SelectedIndex = -1 Then
            MsgBox("Debe indicar el tipo de observación del porque permite o no el acceso de la persona")
            Exit Sub
        End If

        If Rb_No.Checked = False And Rb_Si.Checked = False Then
            MsgBox("Debe seleccionar si la observación permite o no el acceso de la persona")
            Exit Sub
        End If

        If Trim(Me.Tx_Observación.Text) = "" Then
            MsgBox("Debe indicar la observación del porque permite o no el acceso de la persona")
            Exit Sub
        End If

        'Guardar
        comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
        comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
        comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
        comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
        comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

        comando.Parameters("@Accion").Value = 0
        comando.Parameters("@ACCESODENEGADO").Value = IIf(Rb_Si.Checked = True, "S", "N")
        comando.Parameters("@IDPERSONA").Value = IDPERSONA_
        comando.Parameters("@IDENTIFICACION").Value = IDENTIFICACION
        comando.Parameters("@TIPOMODULO").Value = tipoModulo
        comando.Parameters("@TIPOOBSERVACION").Value = Me.Cb_TipoObservación.SelectedValue
        comando.Parameters("@OBSERVACION").Value = Trim(Me.Tx_Observación.Text)
        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

        comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

        adaptador = New SqlDataAdapter(comando)
        dsMaestras = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaestras)
            conexion.Close()
            Select Case comando.Parameters("@IDMENSAJE").Value
                Case 1
                    If Rb_Si.Checked = True Then
                        MsgBox("Se registro correctamente la observación a la persona", MsgBoxStyle.Information, "PERSONA CON ACCESO DENEGADO")
                        CorreoAccesoDenegado(IDPERSONA_)
                    Else
                        MsgBox("Se registro correctamente la observación a la persona", MsgBoxStyle.Information, "PERSONA PERMITIDA")
                        CorreoAccesoDenegado(IDPERSONA_)
                    End If
                    Me.Close()
                Case Else
                    MessageBox.Show("Error al guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CorreoAccesoDenegado(ByVal IdVisitante As Integer)
        Dim Dt_PersonaAcceso As DataTable
        Dim FilaPersonaAcceso As DataRow
        Dim textoContenido As New System.Text.StringBuilder
        Dim asunto As String = ""
        Dim cuerpo As New System.Text.StringBuilder
        Dim archivoFoto As String = ""

        Dim ClConvertir As New FuncionesBase.Cl_Convertir_Num_Letras

        Dim Consulta As New SqlClient.SqlCommand("SELECT * FROM dbo.UltimoRegistroObservacionPersona( @IDPERSONA)")
        Consulta.Parameters.AddWithValue("@IDPERSONA", IdVisitante)


        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Dt_PersonaAcceso = New DataTable
        Try
            Consulta.Connection.Open()
            Adaptador.FillSchema(Dt_PersonaAcceso, SchemaType.Source)
            Adaptador.Fill(Dt_PersonaAcceso)
            Consulta.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Consulta.Connection.Close()
        End Try
        FilaPersonaAcceso = Dt_PersonaAcceso.Rows(0)


        asunto = "CAMBIO EN EL REGISTRO DE ACCESO A ISMOCOL - SIGMA DE: " + CStr(Trim(FilaPersonaAcceso("NombreConsultado")))

        textoContenido.AppendLine("<div style='padding:10px;max-width:1000px;'>")
        textoContenido.AppendLine("    <div style='padding:10px;'/>")
        textoContenido.AppendLine("    <table border='1' style='width:100%;'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>ESTADO QUE SE ESTABLECIÓ:</B> " + CStr(Trim(IIf(FilaPersonaAcceso("ACCESODENEGADO") = "S", "ACCESO DENEGADO", "ACCESO PERMITIDO"))) + "</td>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>IDENTIFICACIÓN PERSONA QUE CAMBIA DE ESTADO :</B> " + FilaPersonaAcceso("IDENTIFICACION").ToString() + "</td>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B> NOMBRE PERSONA QUE CAMBIA DE ESTADO :</B> " + FilaPersonaAcceso("NombreConsultado").ToString() + "</td>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("       <td><B>NÚMERO DE CONTRATO VIGENTE EN ISMOCOL:</B>  " + CStr(Trim(IIf(FilaPersonaAcceso("CODIGOCONTRATO").ToString = "", "SIN CONTRATO", FilaPersonaAcceso("CODIGOCONTRATO").ToString))) + "</td>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>PERSONA QUE REGISTRA CAMBIO DE ESTADO:</B> " + VariablesBase.VariablesBase.Nombre_Usuario + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>FECHA QUE REGISTRA CAMBIO DE ESTADO:</B> " + Convert.ToDateTime(FilaPersonaAcceso("FECHAREGISTRA")).ToString("dd/MM/yyyy',' hh:mm tt") + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>TIPO OBSERVACIÓN:</B> " + Trim(FilaPersonaAcceso("TIPOOBSERVACION")) + "</td>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>OBSERVACIONES:</B> " + Trim(FilaPersonaAcceso("OBSERVACION")) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("        <p><medium>  <CENTER>Por favor no conteste a esta dirección de correo.</CENTER>  </medium></p>")
        textoContenido.AppendLine("     <BR>     <p><medium> <CENTER>Para cualquier consulta comuníquese con soporteaplicaciones@ismocol.com</CENTER> </medium></p> ")
        textoContenido.AppendLine("</div>")

        ' Se arma el html que va a llegar al correo
        cuerpo.AppendLine("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>")
        cuerpo.AppendLine("<html xmlns='http://www.w3.org/1999/xhtml'>")
        cuerpo.AppendLine("    <head>")
        cuerpo.AppendLine("        <meta http-equiv='Content-Type' content='text/html charset=utf-8' />")
        cuerpo.AppendLine("        <title>REGISTRO ESTADO PERSONAL ISMOCOL</title>")
        cuerpo.AppendLine("    </head>")
        cuerpo.AppendLine("    <body>")
        cuerpo.AppendLine("        <center>")
        cuerpo.AppendLine("            " + textoContenido.ToString())
        cuerpo.AppendLine("        </center>")
        cuerpo.AppendLine("    </body>")
        cuerpo.AppendLine("</html>")

        '********************************************** Envío de mail ************************************************/

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String
        Dim correoOrigenClave As String

        correoOrigen = "informacion-noreplicar@ismocol.com"
        correoOrigenClave = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
            mail.To.Add("seguridadfisica@ismocol.com") 'Correo funcionario
        Else
            mail.To.Add("soporteaplicaciones@ismocol.com")
        End If
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo.ToString()

        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        SmtpServer.Send(mail)
    End Sub



    Private Sub Rb_Si_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Si.CheckedChanged
        Me.Lb_ComoQuedara.Text = "SE DENEGARA EL ACCESO"
        Me.Lb_ComoQuedara.ForeColor = Drawing.Color.Red
        Me.Lb_ComoQuedara.Visible = True
    End Sub

    Private Sub Rb_No_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_No.CheckedChanged
        Me.Lb_ComoQuedara.Text = "SE PERMITIRA EL ACCESO"
        Me.Lb_ComoQuedara.ForeColor = Drawing.Color.Green
        Me.Lb_ComoQuedara.Visible = True
    End Sub


    Private Sub Tx_Observación_TextChanged(sender As Object, e As EventArgs) Handles Tx_Observación.TextChanged
        Lb_CanObservación.Text = "(" & Tx_Observación.Text.Length & "/" & Tx_Observación.MaxLength & ")"
    End Sub

    Private Sub Fr_AgregarEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown,
        Dgv_Historial.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                ExportarDatosExcel(Dgv_Historial)
        End Select
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add

        Dim objHojaHistorial As Excel.Worksheet = objLibroExcel.Worksheets(1)



        With objHojaHistorial
            .Name = ("Resumen estado")
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Historial.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Public Sub AplicarFormatoColumnas()
        Select Case TIPO_
            Case "H"
                For i = 0 To Dgv_Historial.ColumnCount - 1
                    Select Case Dgv_Historial.Columns(i).Name
                        Case "Acceso Denegado"
                            Dgv_Historial.Columns(i).Width = 60
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                        Case "Tipo"
                            Dgv_Historial.Columns(i).Width = 90
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Observación"
                            Dgv_Historial.Columns(i).Width = 180
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Registro"
                            Dgv_Historial.Columns(i).Width = 160
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Fecha"
                            Dgv_Historial.Columns(i).Width = 80
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Modulo"
                            Dgv_Historial.Columns(i).Width = 80
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_Historial.Columns(i).Visible = False
                    End Select
                Next
            Case "X"
                For i = 0 To Dgv_Historial.ColumnCount - 1
                    Select Case Dgv_Historial.Columns(i).Name
                        Case "Persona Consulta"
                            Dgv_Historial.Columns(i).Width = 180
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Fecha"
                            Dgv_Historial.Columns(i).Width = 100
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Identificación"
                            Dgv_Historial.Columns(i).Width = 80
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Estado al Consultar"
                            Dgv_Historial.Columns(i).Width = 200
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case "Modulo"
                            Dgv_Historial.Columns(i).Width = 80
                            Dgv_Historial.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_Historial.Columns(i).Visible = False
                    End Select
                Next
        End Select


    End Sub

End Class