Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Net.Mail

Public Class Fr_Visitante

    'Dim DsVisitante As New DatosSisControl.Ds_Siscontrol
    'Dim sc_DependenciaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_DEPENDENCIATableAdapter

    Public Editando As Boolean = False
    Public CargoPersonas As Boolean = False
    Public IdVisitante As Integer
    Private Consecutivo As Integer
    Private Año As String = Year(Date.Now)
    Private TomoFoto As Boolean = False
    Private FirmoPolitica As Boolean = False
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Dim Temp_IdDependencia As Integer = -1

Private Sub Fr_Persona_Closed() Handles MyBase.FormClosed
        PictureBox_Foto_Persona.Image.Dispose()
        Dim appPath As String
        Try
            appPath = Application.StartupPath + "\" + IdVisitante.ToString + ".jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Cargardatos()
        CargarCombos()
        If Editando Then
            Dim dt As New DataTable
            Dim conn As New SqlConnection(My.Settings.CadenaConexión)
            Dim Comando As New SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)", conn)
            Comando.Parameters.AddWithValue("@ACCION", 1)
            Comando.Parameters.AddWithValue("@VARIABLE", IdVisitante)
            Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim da As New SqlDataAdapter(Comando)
            conn.Open()
            da.Fill(dt)
            conn.Close()
            If dt.Rows.Count > 0 Then
                PoblarControles(dt.Rows(0), True)
            End If
        End If
    End Sub

    Dim dsCargar As New DataSet
    Private Sub CargarCombos()
        dsCargar = bddatos.CargarMaestrasSiscontrol(7, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdVisitante, 1)
        'Me.sc_DependenciaTableAdapter.Fill(DsVisitante.SC_DEPENDENCIA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.Cb_Dependencia.DataSource = Me.DsVisitante.SC_DEPENDENCIA
        Me.Cb_Dependencia.DataSource = Me.dsCargar.Tables(0)
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CargoPersonas = True
        CargarPersonas()
    End Sub

    Private Sub CargarPersonas()
        If CargoPersonas Then
            VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Cb_Dependencia.SelectedValue

            Cu_BuscarPersonaFuncionario.CargarDatos()

            'Cb_Dependencia.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "V", "DEPENDENCIA", -1)
            Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "V", "FUNCIONARIO", -1)

        End If
    End Sub

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarVisitante() Then
            GuardarVisitante()
            If TomoFoto Then
                FuncionesBase.FuncionesBase.SubirFotoImagenMiniaturaBD(IdVisitante, Me.PictureBox_Foto_Persona.Image, _
                                                 "SC_FOTOVISITANTE", "vis_" + IdVisitante.ToString + ".jpg", _
                                                  160, 120)
                Dim Vista_Foto As Image
                Vista_Foto = New Bitmap(PictureBox_Foto_Persona.Image)
                Vista_Foto.Save(Application.StartupPath + "\Temp2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                Vista_Foto.Dispose()

                If Editando = False Then
                    GoogleDrive.SubirFoto(3, IdVisitante, Application.StartupPath + "\Temp2.jpg", False)
                Else
                    GoogleDrive.SubirFoto(3, IdVisitante, Application.StartupPath + "\Temp2.jpg", True)
                End If
            End If

            If Not FirmoPolitica Then
                If MsgBox("¿Desea imprimir el Formulario de Aceptación de la Política de Datos Personales?", MsgBoxStyle.YesNo, "IMPRESIÓN POLÍTICA DE DATOS") = MsgBoxResult.Yes Then
                    Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                    Dim Array As New ArrayList
                    Array.Add(75)
                    climpresiones.idVisitante = IdVisitante
                    climpresiones.FormatoImprimirSisControl(Array, True, False)
                End If
            End If

            If MsgBox("¿Desea imprimir el Sticker de Visitante?", MsgBoxStyle.YesNo, "IMPRESIÓN STICKER VISITA") = MsgBoxResult.Yes Then
                Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(76)
                climpresiones.idVisitante = IdVisitante
                climpresiones.FormatoImprimirSisControl(Array, True, False)
            End If

            'ENVIAR CORREO ANUNCIO A FUNCIONARIO
            If Not Editando Then
                CorreoAnuncioVisitante(IdVisitante, Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue)
            End If

            Me.Close()
            PictureBox_Foto_Persona.Image.Dispose()
            Dim appPath As String
            Try
                appPath = Application.StartupPath + "\Temp.jpg"
                If My.Computer.FileSystem.FileExists(appPath) Then
                    My.Computer.FileSystem.DeleteFile(appPath)
                End If
            Catch ex As Exception
            End Try
            Try
                appPath = Application.StartupPath + "\Temp2.jpg"
                If My.Computer.FileSystem.FileExists(appPath) Then
                    My.Computer.FileSystem.DeleteFile(appPath)
                End If
            Catch ex As Exception
            End Try
            Try
                appPath = Application.StartupPath + "\Temp3.jpg"
                If My.Computer.FileSystem.FileExists(appPath) Then
                    My.Computer.FileSystem.DeleteFile(appPath)
                End If
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub GuardarVisitante()
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarVisita")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@IDVISITANTE", IdVisitante)
        Comando.Parameters.AddWithValue("@AÑO", Año)
        Comando.Parameters.AddWithValue("@CONSECUTIVO", Consecutivo)
        Comando.Parameters.AddWithValue("@FECHAVISITA", DateTime.Now)
        Comando.Parameters.AddWithValue("@EMPRESA", UCase(Tx_Proveedor.Text))
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAFUNCIONARIO", Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@CEDULA", UCase(Tx_Identificacion.Text))
        Comando.Parameters.AddWithValue("@NOMBRE", UCase(Tx_Visitante.Text))
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAMODIFICACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAANULACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@ANULADA", "N")
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@EPS", UCase(Tx_EPS.Text))
        If Ck_RevisoVideo.Checked = True Then
            Comando.Parameters.AddWithValue("@VIOVIDEOSEGURIDAD", "S")
        Else
            Comando.Parameters.AddWithValue("@VIOVIDEOSEGURIDAD", "N")
        End If
        If Ck_AceptoPolitica.Checked = True Then
            Comando.Parameters.AddWithValue("@ACEPTOPOLITICADATOS", "S")
        Else
            Comando.Parameters.AddWithValue("@ACEPTOPOLITICADATOS", "N")
        End If
        Comando.Parameters.AddWithValue("@OBSERVACION", Trim(Tx_Observacion.Text))

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()
        IdVisitante = Comando.Parameters("@IDMENSAJE").Value
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "V", "DEPENDENCIA", Cb_Dependencia.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "V", "FUNCIONARIO", Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue)
    End Sub

    Private Function ValidarVisitante() As Boolean
        If Trim(Tx_Visitante.Text) = "" Then
            MsgBox("Debe Agregar el nombre ", MsgBoxStyle.Critical, "NOMBRE")
            Me.Tx_Visitante.Focus()
            ValidarVisitante = False
            Exit Function
        End If

        If Trim(Tx_Identificacion.Text) = "" Or Tx_Identificacion.Text.Length <= 5 Or FuncionesBase.FuncionesBase.ValorRealDec(Tx_Identificacion.Text) <= 0 Then
            MsgBox("Debe Agregar la identificación", MsgBoxStyle.Critical, "IDENTIFICACIÓN")
            Me.Tx_Identificacion.Focus()
            ValidarVisitante = False
            Exit Function
        End If

        If IsNothing(Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione funcionario", MsgBoxStyle.Critical, "FUNCIONARIO")
            ValidarVisitante = False
            Cu_BuscarPersonaFuncionario.Cb_Persona.Focus()
            Exit Function
        End If

        If Not Editando Then
            If Not TomoFoto Then
                MsgBox("Debe Agregar la foto de visitante", MsgBoxStyle.Critical, "FOTO VISITANTE")
                ValidarVisitante = False
                Button_Cargar_Foto_Persona.Focus()
                Exit Function
            End If
        End If

        ValidarVisitante = True
    End Function

    Private Sub Bt_BuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_BuscarProveedor.Click
        Dim FrContratista As New Fr_BuscarContratista
        FrContratista.Cargar_Tabla()
        FrContratista.ShowDialog()
        Try
            Me.Tx_Proveedor.Text = UCase(FrContratista.NombreContratista)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Cb_Dependencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Dependencia.SelectedIndexChanged
        CargarPersonas()
    End Sub

    Private Sub Fr_CorrespondenciaRecibida_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Temp_IdDependencia <> -1 Then
            VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Temp_IdDependencia
            CargarPersonas()
        End If
    End Sub

    Public Sub CambiarDependenciaParaAsociar()
        Temp_IdDependencia = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Me.Cb_Dependencia.SelectedValue
    End Sub

    Private Sub Button_Cargar_Foto_Persona_Click(sender As Object, e As EventArgs) Handles Button_Cargar_Foto_Persona.Click
        Dim FrTomarFoto As New FormulariosClasesBase.Fr_TomarFoto
        Dim dr As DialogResult = FrTomarFoto.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            PictureBox_Foto_Persona.Image = FrTomarFoto.imagen.Image
            TomoFoto = True
        End If
    End Sub

    Private Sub PictureBox_Foto_Persona_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox_Foto_Persona.DoubleClick
        If TomoFoto Or (Editando And PictureBox_Foto_Persona.Image IsNot Nothing) Then
            Dim FrMostrarFoto As New FormulariosClasesBase.Fr_MostrarFoto
            If TomoFoto Then
                FrMostrarFoto.Set_Pb_Foto_Image(PictureBox_Foto_Persona.Image)
            Else
                Try
                    Dim Foto As Boolean = GoogleDrive.DescargarFotos("vis_" + IdVisitante.ToString, "Visitante")
                    If Foto Then
                        Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                        Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                        Dim imagen As Image = Image.FromStream(filestream)
                        filestream.Close()
                        FrMostrarFoto.Set_Pb_Foto_Image(imagen)
                    End If
                Catch
                End Try
            End If
            FrMostrarFoto.ShowDialog()
        End If
    End Sub

    Private Sub Tx_Identificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Identificacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Editando = False Then
                Dim dt As New DataTable
                Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                Dim Comando As New SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)", conn)
                Comando.Parameters.AddWithValue("@ACCION", 3)
                Comando.Parameters.AddWithValue("@VARIABLE", Tx_Identificacion.Text)
                Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                Dim da As New SqlDataAdapter(Comando)
                conn.Open()
                da.Fill(dt)
                conn.Close()
                If dt.Rows.Count > 0 Then
                    PoblarControles(dt.Rows(0), False)
                End If
            End If
        ElseIf InStr(1, "0123456789" & Convert.ToChar(Keys.Back), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        Else

        End If
    End Sub

    Private Sub PoblarControles(ByVal Fila As DataRow, ByVal IncluyeFoto As Boolean)

        Tx_Visitante.Text = Trim(Fila("Nombre"))
        Tx_Proveedor.Text = Trim(Fila("Empresa"))
        Cb_Dependencia.SelectedValue = Fila("IDDEPENDENCIA")
        Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = Fila("IDPERSONAFUNCIONARIO")
        Me.Tx_EPS.Text = IIf(Fila("EPS") Is DBNull.Value, "", Trim(Fila("EPS")))

        IdVisitante = Fila("IDVISITANTE")
        Año = Fila("Año")
        Consecutivo = Fila("Consecutivo")
        If Fila("VIOVIDEOSEGURIDAD") Is DBNull.Value Then
            Me.Ck_RevisoVideo.Checked = False
        Else
            If Fila("VIOVIDEOSEGURIDAD") = "S" Then
                Me.Ck_RevisoVideo.Checked = True
            Else
                Me.Ck_RevisoVideo.Checked = False
            End If
        End If
        If Fila("ACEPTOPOLITICADATOS") Is DBNull.Value Then
            Me.Ck_AceptoPolitica.Checked = False
        Else
            If Fila("ACEPTOPOLITICADATOS") = "S" Then
                FirmoPolitica = True
                Me.Ck_AceptoPolitica.Checked = True
            Else
                Me.Ck_AceptoPolitica.Checked = False
            End If
        End If

        If Editando = True Then
            Tx_Identificacion.Text = Trim(Fila("Cedula"))
            If IncluyeFoto Then
                                Try
                    Dim Foto As Boolean = GoogleDrive.DescargarFotos("vis_" + IdVisitante.ToString, "Visitante")
                    If Foto Then
                        Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                        Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                        PictureBox_Foto_Persona.Image = Image.FromStream(filestream)
                        filestream.Close()
                    Else
                        MsgBox("Error al cargar la imagen")
                    End If
                Catch
                End Try
            End If
            Lb_ConsecutivoVisita.Visible = True
            Lb_ConsecutivoVisita.Text = ""
            Lb_ConsecutivoVisita.Text += CStr(Fila("Consecutivo")) + "-" + Fila("Año")
            Lb_ConsecutivoVisita.Text += ", "
            Lb_ConsecutivoVisita.Text += "Fecha Visita: " + CStr(Fila("Fecha"))
            If Not IsDBNull(Fila("FECHASALIDA")) Then
                Lb_ConsecutivoVisita.Text += ", "
                Lb_ConsecutivoVisita.Text += "Fecha Salida: " + CStr(Fila("FECHASALIDA")) + " "
            End If
        End If

    End Sub

    Private Sub CorreoAnuncioVisitante(ByVal IdVisitante As Integer, ByVal IdFuncionario As Integer)
        Dim Dt_Visitante As DataTable
        Dim FilaVisitante As DataRow
        Dim textoContenido As New System.Text.StringBuilder
        Dim asunto As String = ""
        Dim cuerpo As New System.Text.StringBuilder
        Dim archivoFoto As String = ""

        Dim ClConvertir As New FuncionesBase.Cl_Convertir_Num_Letras

        Dim Consulta As New SqlClient.SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)")
        Consulta.Parameters.AddWithValue("@ACCION", 1)
        Consulta.Parameters.AddWithValue("@VARIABLE", IdVisitante)
        Consulta.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)

        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Dt_Visitante = New DataTable
        Try
            Consulta.Connection.Open()
            Adaptador.FillSchema(Dt_Visitante, SchemaType.Source)
            Adaptador.Fill(Dt_Visitante)
            Consulta.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Consulta.Connection.Close()
        End Try
        FilaVisitante = Dt_Visitante.Rows(0)

        archivoFoto = Trim(FuncionesBase.FuncionesBase.DevolverRutaArchivoImagen(2, IdVisitante))

        asunto = "REGISTRO DE VISITANTES SISCONTROL - SIGMA: " + CStr(Trim(FilaVisitante("NOMBRE")))

        textoContenido.AppendLine("<div style='padding:10px;max-width:1000px;'>")
        textoContenido.AppendLine("    <table style='width:100%;' border='1'>")
        textoContenido.AppendLine("        <tr style='border-width:1px;border-style:solid;text-align:center;'>")
        textoContenido.AppendLine("            <td style='width:100px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' height='60' width='60'/></td>")
        textoContenido.AppendLine("            <td><CENTER><B>REGISTRO DE VISITANTES SISCONTROL - SIGMA</B></CENTER></td>")
        textoContenido.AppendLine("            <td><CENTER><B>VISITANTE " + FilaVisitante("Año") + "-" + FilaVisitante("Consecutivo").ToString() + "</B></CENTER></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    <div style='padding:10px;'/>")
        textoContenido.AppendLine("    <table border='1' style='width:100%;'>")
        textoContenido.AppendLine("        <p>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>NOMBRE DEL VISITANTE:</B> " + StrConv(Trim(FilaVisitante("NOMBRE")), VbStrConv.ProperCase) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>IDENTIFICACIÓN:</B> " + ClConvertir.Fun_FormatearCedula(Trim(FilaVisitante("Cedula"))) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>EMPRESA:</B> " + Trim(FilaVisitante("EMPRESA")) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>DEPENDENCIA:</B> " + StrConv(Trim(FilaVisitante("DEPENDENCIA")), VbStrConv.ProperCase) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>FUNCIONARIO:</B> " + StrConv(Trim(FilaVisitante("FUNCIONARIO")), VbStrConv.ProperCase) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>FECHA Y HORA DE VISITA:</B> " + Convert.ToDateTime(FilaVisitante("Fecha")).ToString("dd/MM/yyyy',' hh:mm tt") + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><B>OBSERVACIONES:</B> " + Trim(FilaVisitante("OBSERVACION")) + "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td>* Se adjunta foto del visitante.</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        </p>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='3'><CENTER>Por favor no conteste a esta dirección de correo.</CENTER></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='3'><CENTER>Para cualquier consulta comuníquese con desarrolloaplicaciones@ismocol.com</CENTER></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("</div>")

        ' Se arma el html que va a llegar al correo
        cuerpo.AppendLine("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>")
        cuerpo.AppendLine("<html xmlns='http://www.w3.org/1999/xhtml'>")
        cuerpo.AppendLine("    <head>")
        cuerpo.AppendLine("        <meta http-equiv='Content-Type' content='text/html charset=utf-8' />")
        cuerpo.AppendLine("        <title>REGISTRO VISITANTES SISCONTROL</title>")
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
            Dim Comando As New SqlClient.SqlCommand("SELECT dbo.CorreoCorporativo(@IDPERSONA)")
            Comando.Parameters.AddWithValue("@IDPERSONA", IdFuncionario)
            Dim Conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Dim Dt_CorreoFuncionario As New DataTable
            Comando.Connection = Conn
            Dim Adp As New SqlClient.SqlDataAdapter(Comando)
            Try
                Comando.Connection.Open()
                Adp.FillSchema(Dt_CorreoFuncionario, SchemaType.Source)
                Adp.Fill(Dt_CorreoFuncionario)
                Comando.Connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Comando.Connection.Close()
            End Try

            mail.To.Add(Dt_CorreoFuncionario.Rows(0).Item(0)) 'Correo funcionario
        Else
            mail.To.Add("desarrolloaplicaciones@ismocol.com")
        End If
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo.ToString()
        Dim att As New Attachment(archivoFoto, System.Net.Mime.MediaTypeNames.Application.Octet)
        att.Name = System.IO.Path.GetFileName(archivoFoto)
        mail.Attachments.Add(att)

        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        SmtpServer.Send(mail)
    End Sub

End Class