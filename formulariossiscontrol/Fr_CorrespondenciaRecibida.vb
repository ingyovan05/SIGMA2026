Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports VarBase = VariablesBase.VariablesBase

Public Class Fr_CorrespondenciaRecibida
    ''' <summary>Indica si el documento recibido se visualiza para editar.</summary>
    Public Editando As Boolean = False

    Public Clonar As Boolean = False

    ''' <summary>El documento se muestra en modo de lectura.</summary>
    Public SoloLectura As Boolean = False

    ''' <summary>Identificador del documento recibido a gestionar.</summary>
    Public IdCorrespondencia As Integer

    Private IdBaseActual As Integer = VarBase.IdBaseSiscontrolActual
    Private CargaPersona As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dsRecepcion As DataSet
    Private dtDependencias As DataTable
    Private Fila_Contratista As DataRow
    Private DsCorrespondenciaRecibida As New DatosSisControl.Ds_Siscontrol
    Private valorNit As Nullable(Of Integer)
    Private caracteresPermitidosNit As String = "0123456789" & Convert.ToChar(Keys.Back) & Convert.ToChar(Keys.Delete)
    Private Temp_IdDependencia As Integer = -1
    Private idGerencia As Integer?
    Private consecutivo As Long?
    Private radicoNuevamente As Boolean = False
    Private idSticker As Long = 0

    Private Sub Fr_CorrespondenciaRecibida_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Fr_CorrespondenciaRecibida_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If SoloLectura Then
            Bt_Cancelar.Select()
        Else
            Dtp_Fecha.Select()
        End If
    End Sub

    Private Sub Fr_CorrespondenciaRecibida_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Temp_IdDependencia <> -1 Then
            VarBase.IddependenciaSiscontrolActual = Temp_IdDependencia
        End If
    End Sub

    ''' <summary></summary>
    Public Sub CambiarDependenciaParaAsociar()
        Temp_IdDependencia = VarBase.IddependenciaSiscontrolActual
        VarBase.IddependenciaSiscontrolActual = Cb_Dependencia.SelectedValue
    End Sub

    ''' <summary>Cargar datos iniciales de envío y recepción de correspondencia.</summary>
    ''' <param name="accion"></param>
    ''' <param name="idRecepcion"></param>
    Public Sub Cargar_Datos(accion As Integer, Optional idRecepcion As Integer = -1)
        comando = New SqlCommand("CargarMaestrasSisControl", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdDependencia", SqlDbType.Int)
        comando.Parameters.Add("@Identificador", SqlDbType.BigInt)
        comando.Parameters.Add("@Tipo", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdPersona", SqlDbType.Int)
        comando.Parameters("@Accion").Value = 5
        comando.Parameters("@IdDependencia").Value = VarBase.IddependenciaSiscontrolActual
        comando.Parameters("@Identificador").Value = IdCorrespondencia
        If Editando Then
            comando.Parameters("@Tipo").Value = 2
        Else
            comando.Parameters("@Tipo").Value = 1
        End If
        comando.Parameters("@IdPersona").Value = VariablesBase.VariablesBase.IdPersona
        adaptador = New SqlDataAdapter(comando)
        dsRecepcion = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsRecepcion)
            conexion.Close()
            '- 0	SC_RECEPCION
            '- 1	SC_BASE
            '- 2	SC_DEPENDENCIA
            '- 3	SC_DOCUMENTO
            '- 4	SC_GERENCIA
            '- 5	SC_STICKER

            Cb_Base.DataSource = dsRecepcion.Tables(1)
            Dim idBasexDefecto As Integer = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "CR", "BASE", -1)
            If Cb_Base.DataSource.Select(Cb_Base.ValueMember & " = " & idBasexDefecto).Length > 0 Then
                Cb_Base.SelectedValue = idBasexDefecto
            Else
                Cb_Base.SelectedValue = VarBase.IdBaseSiscontrolActual
            End If
            VarBase.IdBaseSiscontrolActual = Cb_Base.SelectedValue
            Cb_TipoDocumento.DataSource = dsRecepcion.Tables(3)
            Cb_TipoDocumento.SelectedIndex = -1
            Dim idDependenciaxDefecto As Integer = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "CR", "DEPENDENCIA", -1)
            If dtDependencias.Select(Cb_Dependencia.ValueMember & " = " & idDependenciaxDefecto).Count > 0 Then
                Cb_Dependencia.SelectedValue = idDependenciaxDefecto
            Else
                Cb_Dependencia.SelectedIndex = 0
            End If
            CargaPersona = True
            CargarPersonaPorDependencia()
            Dtp_FechaDocumento.Checked = False
            Dtp_FechaVencimiento.Checked = False
            If Editando Then
                LlenarCampos(dsRecepcion.Tables(0).Rows(0))
                If SoloLectura Then
                    BloquearCamposSoloLectura()
                End If
                If Clonar Then
                    Me.Dtp_Fecha.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary></summary>
    ''' <param name="idRecepcion"></param>
    Private Sub Cargar_Recepcion(idRecepcion As Integer)
        comando = New SqlCommand("SELECT * FROM SC_CR_Recepcion(@IDRECEPCION)", conexion)
        comando.Parameters.AddWithValue("@IDRECEPCION", idRecepcion)
        adaptador = New SqlDataAdapter(comando)
        Dim dtRecepcion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtRecepcion)
            conexion.Close()
            If dtRecepcion.Rows.Count > 0 Then
                LlenarCampos(dtRecepcion.Rows(0))
            Else
                MessageBox.Show("No se encontró el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary></summary>
    ''' <param name="fila"></param>
    Private Sub LlenarCampos(fila As DataRow)
        IdCorrespondencia = fila("IDRECEPCION")
        Dtp_Fecha.Value = fila("FECHARECEPCION")
        Dtp_Fecha.Enabled = False
        Cb_TipoDocumento.SelectedValue = fila("TIPO")
        Cb_Base.SelectedValue = fila("IDBASEPARA")
        Cb_Dependencia.SelectedValue = fila("IDDEPENDENCIAPARA")
        VarBase.IddependenciaSiscontrolBusqueda = fila("IDDEPENDENCIAPARA")
        Cu_BuscarPersonaFuncionario.CargarDatos()
        Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = fila("IDPERSONAFUNCIONARIO")
        Cu_BuscarPersonaFuncionario.CargarCajaTexto()
        If Not IsDBNull(fila("NIT")) AndAlso Trim(fila("NIT")).Length > 0 Then
            Dim nit As Integer = FuncionesBase.FuncionesBase.ValorRealInt(fila("NIT"))
            If nit > 0 Then
                Tx_Nit.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(nit)
                Cargar_Contratista()
            End If
        Else
            Tx_De.Text = Trim(fila("DE"))
        End If
        Tx_NroRadicado.Text = Trim(fila("NRORADICADO"))
        Tx_Descripcion.Text = Trim(fila("DESCRIPCION"))
        Tx_NroDocumento.Text = Trim(fila("NUMERODOCUMENTO"))
        If Not IsDBNull(fila("FECHADOCUMENTO")) AndAlso Year(fila("FECHADOCUMENTO")) <> "1900" Then
            Dtp_FechaDocumento.Value = fila("FECHADOCUMENTO")
            Dtp_FechaDocumento.Checked = True
        End If
        If Not IsDBNull(fila("FECHAVENCIMIENTODOCUMENTO")) AndAlso Year(fila("FECHAVENCIMIENTODOCUMENTO")) <> "1900" Then
            Dtp_FechaVencimiento.Value = fila("FECHAVENCIMIENTODOCUMENTO")
            Dtp_FechaVencimiento.Checked = True
        End If
        Dim valor As Decimal
        If Decimal.TryParse(Trim(fila("VALOR")), valor) Then
            CuTx_ValorDocumento.Valor = valor
        End If
        Tx_Memo.Text = Trim(fila("MEMO"))
        If Not IsDBNull(fila("NUMEROSTICKER")) Then
            Tx_Sticker.Text = fila("NUMEROSTICKER")
        End If
    End Sub

    ''' <summary></summary>
    ''' <returns></returns>
    Private Function IdEmpresaSeleccionada() As Integer
        If Cb_Dependencia.SelectedValue IsNot Nothing Then
            Return dtDependencias.Select(Cb_Dependencia.ValueMember & " = " & Cb_Dependencia.SelectedValue)(0).Item("IDEMPRESA")
        Else
            Return VarBase.EmpresaSisControlActual
        End If
    End Function

    ''' <summary></summary>
    Private Sub BloquearCamposSoloLectura()
        Dtp_Fecha.Enabled = False
        Cb_TipoDocumento.Enabled = False
        Cb_Base.Enabled = False
        Cb_Dependencia.Enabled = False
        Cu_BuscarPersonaFuncionario.Tx_TextoCódigo.ReadOnly = True
        Cu_BuscarPersonaFuncionario.Enabled = False
        Cu_AsociarPersonaBodega1.Enabled = False
        Tx_Nit.ReadOnly = True
        Tx_De.ReadOnly = True
        Bt_BuscarDe.Enabled = False
        Tx_NroRadicado.ReadOnly = True
        Ck_Automatico.Enabled = False
        Tx_Descripcion.ReadOnly = True
        Tx_NroDocumento.ReadOnly = True
        Dtp_FechaDocumento.Enabled = False
        Dtp_FechaVencimiento.Enabled = False
        CuTx_ValorDocumento.SoloLectura = True
        CuTx_ValorDocumento.Enabled = False
        Tx_Memo.Enabled = False
        Tx_Sticker.ReadOnly = True
        Bt_BuscarSticker.Enabled = False
        Bt_Guardar.Visible = False
        Bt_Cancelar.Text = "Cerrar"
    End Sub

    ''' <summary></summary>
    Private Sub BloquearCamposPorGerencia()
        Cb_Dependencia.Enabled = False
        Cu_BuscarPersonaFuncionario.Tx_TextoCódigo.ReadOnly = True
        Cu_BuscarPersonaFuncionario.Enabled = False
        Cu_AsociarPersonaBodega1.Enabled = False
    End Sub

    ''' <summary></summary>
    Private Sub HabilitarCamposPorGerencia()
        Cb_Dependencia.Enabled = True
        Cu_BuscarPersonaFuncionario.Tx_TextoCódigo.ReadOnly = False
        Cu_BuscarPersonaFuncionario.Enabled = True
        Cu_AsociarPersonaBodega1.Enabled = True
    End Sub

    ''' <summary></summary>
    Private Sub CargarFuncionarioPorGerencia()
        Select Case idGerencia
            Case 0 'Gerencia General
                Cb_Dependencia.SelectedValue = 0
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = 1439 '34122 'Álvaro Escobar Saavedra
            Case 1 'Gerencia de Construcciones
                Cb_Dependencia.SelectedValue = 4
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = 3035 'Eduardo Augusto Silva Mejía
            Case 2 'Gerencia de Operaciones
                Cb_Dependencia.SelectedValue = 2
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = 1473 'Oscar Mauricio Escobar Parada
            Case 3 'Gerencia de Montajes
                Cb_Dependencia.SelectedValue = 3
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = 184 'Carlos Augusto Patiño Murillo
            Case 4 'Gerencia Administrativa
                Cb_Dependencia.SelectedValue = 1
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = 1441 'Horacio Gil Linares
            Case 5 'Gerencia de Servicios Técnicos
                Cb_Dependencia.SelectedValue = 2
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = 1473 'Oscar Mauricio Escobar Parada
            Case Else
                Cb_Dependencia.SelectedIndex = -1
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedIndex = -1
        End Select
    End Sub

    Private Function NombreGerencia(idGerenciaParam As Integer) As String
        Select Case idGerenciaParam
            Case 0
                Return "Gerencia General"
            Case 1
                Return "Gerencia de Construcciones"
            Case 2
                Return "Gerencia de Operaciones"
            Case 3
                Return "Gerencia de Montajes"
            Case 4
                Return "Gerencia Administrativa"
            Case 5
                Return "Gerencia de Servicios Técnicos"
            Case Else
                Return ""
        End Select
    End Function

    ''' <summary></summary>
    Private Sub CargarGerencia(idDependencia As Integer)
        comando = New SqlCommand("SELECT dbo.IdGerenciaXDependencia(@IDDEPENDENCIA)", conexion)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", idDependencia)
        Dim gerencia As Integer
        Try
            conexion.Open()
            gerencia = comando.ExecuteScalar()
            conexion.Close()
            idGerencia = gerencia
            If Cb_Base.SelectedValue = 0 AndAlso Not PuedeElegirDependenciasEnPrincipal() Then
                CargarFuncionarioPorGerencia()
            End If
        Catch ex As Exception
            idGerencia = Nothing
            'Throw New Exception("No se encontraron datos.", ex)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Function PuedeElegirDependenciasEnPrincipal() As Boolean
        Return (IdBaseActual = 0 OrElse IdBaseActual = 127 OrElse VarBase.EmpresaSisControlActual = 2)
    End Function

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarCorrespondencia() Then
            If Not Editando Then
                Dim verificoRadicadoExistente As Boolean
                verificoRadicadoExistente = BuscarRadicarRegistroExistente()
                If Not verificoRadicadoExistente Then
                    Exit Sub
                End If
            End If
            GuardarCorrespondencia()
        End If
    End Sub

    ''' <summary></summary>
    Private Sub GuardarCorrespondencia()
        comando = New SqlCommand("dbo.GestionarCorrespondenciarecibida", conexion)
        comando.CommandType = CommandType.StoredProcedure
        If Not Editando Then
            comando.Parameters.AddWithValue("@TIPOACCION", 1)
        Else
            comando.Parameters.AddWithValue("@TIPOACCION", 2)
        End If
        comando.Parameters.AddWithValue("@IDRECEPCION", IdCorrespondencia)
        comando.Parameters.AddWithValue("@FECHARECEPCION", Dtp_Fecha.Value)
        comando.Parameters.AddWithValue("@TIPO", Cb_TipoDocumento.SelectedValue)
        comando.Parameters.AddWithValue("@DE", Trim(Tx_De.Text))
        comando.Parameters.AddWithValue("@NRORADICADO", Trim(Tx_NroRadicado.Text))
        comando.Parameters.AddWithValue("@DESCRIPCION", UCase(Trim(Tx_Descripcion.Text)))
        comando.Parameters.AddWithValue("@VALOR", CuTx_ValorDocumento.Valor)
        Dim nit As Integer
        Try
            nit = FuncionesBase.FuncionesBase.ValorRealInt(Tx_Nit.Text)
        Catch
        End Try
        If Not IsNothing(nit) AndAlso nit > 0 Then
            comando.Parameters.AddWithValue("@NIT", nit)
        Else
            comando.Parameters.AddWithValue("@NIT", "")
        End If
        comando.Parameters.AddWithValue("@IDPERSONAFUNCIONARIO", Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue)
        comando.Parameters.AddWithValue("@IDUSUARIO", VarBase.IdPersona)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBaseActual)
        comando.Parameters.AddWithValue("@IDDEPENDENCIAPARA", Cb_Dependencia.SelectedValue)
        comando.Parameters.AddWithValue("@NUMERODOCUMENTO", Trim(Tx_NroDocumento.Text))
        If Dtp_FechaDocumento.Checked Then
            comando.Parameters.AddWithValue("@FECHADOCUMENTO", Dtp_FechaDocumento.Value)
        Else
            comando.Parameters.AddWithValue("@FECHADOCUMENTO", DBNull.Value)
        End If
        If Dtp_FechaVencimiento.Checked Then
            comando.Parameters.AddWithValue("@FECHAVENCIMIENTODOCUMENTO", Dtp_FechaVencimiento.Value)
        Else
            comando.Parameters.AddWithValue("@FECHAVENCIMIENTODOCUMENTO", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@MEMO", Trim(Tx_Memo.Text))
        If Not IsNothing(idGerencia) Then
            comando.Parameters.AddWithValue("@IDGERENCIA", idGerencia)
        Else
            comando.Parameters.AddWithValue("@IDGERENCIA", DBNull.Value)
        End If
        If idSticker > 0 Then
            comando.Parameters.AddWithValue("@IDSTICKER", idSticker)
        Else
            comando.Parameters.AddWithValue("@IDSTICKER", DBNull.Value)
        End If
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.BigInt)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(msgParam.Value) Then
                If msgParam.Value < 0 Then
                    MsgBox("El consecutivo " & CStr(msgParam.Value * -1) & ", Posee las mismas características.", MsgBoxStyle.Exclamation, "")
                    Exit Sub
                Else
                    If Editando = False Then
                        MsgBox("El consecutivo es: " & CStr(msgParam.Value), MsgBoxStyle.Information, "CONSECUTIVO")
                        consecutivo = msgParam.Value
                    End If
                End If
            End If
            FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CR", "TIPODOCUMENTO", Cb_TipoDocumento.SelectedValue)
            FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CR", "FUNCIONARIO", Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue)
            FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CR", "BASE", Cb_Base.SelectedValue)
            FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CR", "DEPENDENCIA", Cb_Dependencia.SelectedValue)
            If radicoNuevamente Then
                Try
                    EnviarCorreoRadicadoContabilidad()
                Catch
                End Try
            End If
            If Ck_Automatico.Checked = True Then
                If MsgBox("¿Desea agregar otro documento?", MsgBoxStyle.YesNo, "RECEPCIÓN") = MsgBoxResult.Yes Then
                    Limpiar()
                Else
                    Close()
                End If
            Else
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

#Region "Validar"
    ''' <summary></summary>
    ''' <returns></returns>
    Private Function ValidarCorrespondencia() As Boolean
        If Cb_TipoDocumento.SelectedIndex < 0 OrElse Cb_TipoDocumento.SelectedValue <= 0 Then
            MsgBox("Seleccione el tipo de documento.", MsgBoxStyle.Exclamation, "Tipo Documento")
            Cb_TipoDocumento.Focus()
            Return False
        End If
        If Cb_Base.SelectedIndex < 0 OrElse Cb_Base.SelectedValue < 0 Then
            MsgBox("Seleccione la base destino.", MsgBoxStyle.Exclamation, "Base Destino")
            Cb_Dependencia.Focus()
            Return False
        End If
        If Cb_Dependencia.SelectedIndex < 0 OrElse Cb_Dependencia.SelectedValue < 0 Then
            MsgBox("Seleccione la dependencia destino.", MsgBoxStyle.Exclamation, "Dependencia Destino")
            Cb_Dependencia.Focus()
            Return False
        End If
        If Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Seleccione el funcionario.", MsgBoxStyle.Exclamation, "Funcionario")
            Cu_BuscarPersonaFuncionario.Cb_Persona.Focus()
            Return False
        End If
        If Tx_De.TextLength = 0 AndAlso Tx_Nit.Text.Length <= 0 Then 'Permitir enviar desde las bases
            Dim dr As DialogResult = MessageBox.Show("No ha indicado el remitente del documento." & Environment.NewLine & "¿Desea continuar sin incluir remitente?", "De", MessageBoxButtons.YesNo)
            If dr = DialogResult.No Then
                Tx_Nit.Select()
                Return False
            End If
        End If
        If Tx_Descripcion.Text = "" Then
            MsgBox("Agregue una descripción.", MsgBoxStyle.Exclamation, "Descripción")
            Tx_Descripcion.Focus()
            Return False
        End If

        Dim TextoString As String = Tx_Descripcion.Text
        Dim TextoArray() As String = Split(TextoString)
        For i As Integer = 0 To TextoArray.Length - 1
            If TextoArray(i).Length > 15 Then
                MsgBox("La palabra '" & TextoArray(i).ToString & "' tiene muchos caracteres.", MsgBoxStyle.Exclamation, "Descripción")
                Return False
            End If
        Next

        If IdBaseActual = 0 Then 'Si la base es Buc-Principal.
            'Si el tipo de documento es Cuenta de cobro (2), Factura (3) o Nota crédito (14)
            If Cb_TipoDocumento.SelectedValue = 2 OrElse Cb_TipoDocumento.SelectedValue = 3 OrElse Cb_TipoDocumento.SelectedValue = 14 Then
                If Trim(Tx_NroDocumento.Text) = "" Then
                    MsgBox("Debe ingresar el número del documento.", MsgBoxStyle.Exclamation, "Nro. Documento")
                    Tx_NroDocumento.Focus()
                    Tx_NroDocumento.Text = ""
                    Return False
                End If
            End If
        End If

        If Not ValidarSticker() Then
            MsgBox("El número de sticker no es válido.", MsgBoxStyle.Exclamation, "Sticker")
            Tx_Sticker.Select()
            Return False
        End If

        Return True
    End Function

    Private Function ValidarSticker() As Boolean
        If Tx_Sticker.Text.Length > 8 Then


            Return False
        Else
            If Tx_Sticker.Text.Length > 0 Then

                Dim id As Long?
                comando = New SqlCommand("SELECT dbo.SC_IdStickerPorNumero(@NUMEROSTICKER,@IDRECEPCON,@IdDependencia)", conexion)
                comando.Parameters.AddWithValue("NUMEROSTICKER", Tx_Sticker.Text)
                comando.Parameters.AddWithValue("IDRECEPCON", IdCorrespondencia)
                comando.Parameters.AddWithValue("IdDependencia", VarBase.IddependenciaSiscontrolActual)
                conexion.Open()
                id = comando.ExecuteScalar()
                conexion.Close()
                If Not IsNothing(id) AndAlso Not IsDBNull(id) AndAlso Not id = 0 Then
                    idSticker = id.Value
                    Return True
                Else
                    idSticker = 0
                    Return False
                End If
            Else
                idSticker = 0
                Return True
            End If
        End If
    End Function

#End Region 'Validar

    ''' <summary></summary>
    Private Sub Limpiar()
        If Trim(Tx_NroRadicado.Text) <> "" Then
            Tx_NroRadicado.Text = CInt(Trim(Tx_NroRadicado.Text)) + 1
        Else
            Tx_NroRadicado.Text = 1
        End If
        consecutivo = Nothing
        radicoNuevamente = False
    End Sub

    Private Sub Bt_BuscarDe_Click(sender As Object, e As EventArgs) Handles Bt_BuscarDe.Click
        Dim fr_buscarcontratista As New Fr_BuscarContratista
        fr_buscarcontratista.Cargar_Tabla()
        fr_buscarcontratista.ShowDialog()
        Try
            Dim nit As Integer = FuncionesBase.FuncionesBase.ValorRealInt(fr_buscarcontratista.Identificacion)
            Tx_Nit.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(nit)
            Cargar_Contratista()
        Catch ex As Exception
            MessageBox.Show("La identificación del contratista no tiene el formato válido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary></summary>
    Public Sub Cargar_Contratista()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim nit As Integer = FuncionesBase.FuncionesBase.ValorRealInt(Tx_Nit.Text)
            If nit > 0 Then
                comando = New SqlCommand("SELECT * FROM DatosContratista(@IDENTIFICACION)", conexion)
                comando.Parameters.AddWithValue("@IDENTIFICACION", nit)
                adaptador = New SqlDataAdapter(comando)
                Dim dtContratista As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtContratista)
                    conexion.Close()
                    If dtContratista.Rows.Count > 0 Then
                        Fila_Contratista = dtContratista.Rows(0)
                        Tx_De.Text = Trim(Fila_Contratista("Nombre"))
                    End If
                Catch ex As Exception
                    MessageBox.Show("No fue posible cargar los datos del proveedor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conexion.Close()
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("La identificación del contratista no tiene el formato válido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor.Current = Cursors.Default
    End Sub

#Region "Eventos caja de texto NIT"
    Private Sub Tx_Nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Nit.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Cargar_Contratista()
            e.Handled = True
        ElseIf Not caracteresPermitidosNit.Contains(e.KeyChar) Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then 'Retira el caractér "." que tiene un código equivalente a "Keys.Delete".
            e.Handled = True
        End If
        If Not e.Handled Then
            Tx_De.Text = ""
        End If
    End Sub

    Private Sub Tx_Nit_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Nit.KeyDown
        If e.Control And e.KeyCode.ToString = "V" Then
            'Tx_Nit.Paste() 'No habilitar el comando de pegado para evitar el ingreso de valores inválidos.
        ElseIf e.Control And e.KeyCode.ToString = "C" Then
            Tx_Nit.Copy()
        End If
    End Sub

    Private Sub Tx_Nit_Validating(sender As Object, e As CancelEventArgs) Handles Tx_Nit.Validating
        If sender.Text.Length > 0 Then
            Dim num As Nullable(Of Integer)
            Try
                num = FuncionesBase.FuncionesBase.ValorRealInt(sender.Text)
            Catch
            End Try
            If Not IsNothing(num) Then
                valorNit = num
                If valorNit < 0 Then
                    sender.BackColor = Drawing.Color.Red
                Else
                    sender.BackColor = Drawing.Color.White
                End If
            Else
                sender.BackColor = Drawing.Color.Red
            End If
        Else
            valorNit = Nothing
        End If
    End Sub

    Private Sub Tx_Nit_Validated(sender As Object, e As EventArgs) Handles Tx_Nit.Validated
        If Not IsNothing(valorNit) Then
            Dim nit As Integer = valorNit
            Tx_Nit.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(nit)
        End If
    End Sub

    Private Sub Tx_Nit_Enter(sender As Object, e As EventArgs) Handles Tx_Nit.Enter
        FuncionesBase.FuncionesBase.EnfocarCajaTexto(Tx_Nit)
    End Sub
#End Region 'Eventos caja de texto NIT

#Region "Volver a radicar"
    ''' <summary>Busca los registros de correspondencia recibida con los mismos datos que se ingresaron en la ventana y si encuentra una versión anterior pregunta si se desea radicar el documento nuevamente.</summary>
    ''' <returns>
    ''' Verdadero si se encontraron registros y se toma alguna de las decisiones para continuar con el guardado (sí, no).
    ''' Falso si se presenta un error en la búsqueda o se decide no continuar con el guardado (cancelar).
    ''' </returns>
    ''' <remarks>Cuando se radica un documento nuevamente, se modifica su número de documento para agregarle un prefijo alfabético (e.g. registro anterior: "A1515", registro nuevo "1515").</remarks>
    Private Function BuscarRadicarRegistroExistente() As Boolean
        Dim dtRecepcion As DataTable
        dtRecepcion = BuscarExistente() 'Si existen registros anteriores los carga.
        If Not IsNothing(dtRecepcion) AndAlso dtRecepcion.Rows.Count > 0 Then 'Si existen registros anteriores.
            Return RadicarExistente(dtRecepcion) 'Muestra un cuadro de diálogo para confirmar la modificación del registro anterior (agregar prefijo).
        Else 'No existen registros anteriores.
            Return True
        End If
    End Function


    ''' <summary></summary>
    ''' <returns></returns>
    Private Function BuscarExistente() As DataTable
        comando = New SqlCommand("SELECT * FROM SC_CR_RadicadoRecepcion(@NIT, @DE, @NUMERODOCUMENTO, @IDBASESISCONTROL) ORDER BY IDRECEPCION DESC", conexion)
        Dim nit As Integer
        Try
            nit = FuncionesBase.FuncionesBase.ValorRealInt(Tx_Nit.Text)
        Catch
        End Try
        If Not IsNothing(nit) AndAlso nit > 0 Then
            comando.Parameters.AddWithValue("@NIT", nit)
        Else
            comando.Parameters.AddWithValue("@NIT", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@DE", Trim(Tx_De.Text))
        Dim nroDocumento As String = Trim(Tx_NroDocumento.Text)
        If nroDocumento.Length > 0 Then
            comando.Parameters.AddWithValue("@NUMERODOCUMENTO", nroDocumento)
        Else
            comando.Parameters.AddWithValue("@NUMERODOCUMENTO", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBaseActual)
        adaptador = New SqlDataAdapter(comando)
        Dim dtRecepcion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtRecepcion)
            conexion.Close()
            Return dtRecepcion
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing 'Cancelar el proceso de guardado.
        Finally
            conexion.Close()
        End Try
    End Function


    ''' <summary></summary>
    ''' <param name="dtRecepcion"></param>
    ''' <returns></returns>
    Private Function RadicarExistente(dtRecepcion As DataTable) As Boolean
        If dtRecepcion.Rows.Count > 0 Then 'Si existen registros anteriores.
            Dim prefijo As Char = ""
            If dtRecepcion.Rows.Count = 1 Then 'Si tiene un solo registro existente.
                prefijo = dtRecepcion.Rows(0).Item("NUMERODOCUMENTO").ToString.Substring(0, 1)
            Else 'Tiene más registros anteriores.
                prefijo = dtRecepcion.Rows(1).Item("NUMERODOCUMENTO").ToString.Substring(0, 1)
            End If
            Dim prefijoAscii As Integer = AscW(prefijo)
            If dtRecepcion.Rows.Count > 1 AndAlso (prefijoAscii >= 65 AndAlso prefijoAscii < 90) Then 'Si el prefijo está en el rango ASCII de la letra A mayúscula a la letra Z mayúscula
                prefijo = ChrW(prefijoAscii + 1)
            ElseIf Char.IsDigit(prefijo) Then
                prefijo = "A"
            Else
                prefijo = ""
            End If
            Dim drRecepcion2 As DataRow = dtRecepcion.Rows(0)
            Dim idRecepcionAnterior As Integer = drRecepcion2.Item("IDRECEPCION")
            Dim drResultado As DialogResult
            drResultado = MessageBox.Show("El registro con consecutivo " & drRecepcion2.Item("CONSECUTIVO") & " tiene los mismos datos ingresados:" _
                            & Environment.NewLine _
                            & Environment.NewLine & "Fecha de recepción: " & drRecepcion2.Item("FECHARECEPCION") _
                            & Environment.NewLine & "Tipo de documento: " & drRecepcion2.Item("TIPODOCUMENTO") _
                            & Environment.NewLine & "Para dependencia: " & drRecepcion2.Item("NOMBREDEPENDENCIA") _
                            & Environment.NewLine & "Gerencia: " & drRecepcion2.Item("NOMBREGERENCIA") _
                            & Environment.NewLine & "Funcionario: " & drRecepcion2.Item("PERSONAFUNCIONARIO") _
                            & Environment.NewLine & "NIT: " & FuncionesBase.FuncionesBase.FormatearIdentificacion(drRecepcion2.Item("NIT")) _
                            & Environment.NewLine & "De: " & drRecepcion2.Item("DE") _
                            & Environment.NewLine & "Radicado No.: " & drRecepcion2.Item("NRORADICADO") _
                            & Environment.NewLine & "Descripción: " & drRecepcion2.Item("DESCRIPCION") _
                            & Environment.NewLine & "No. documento: " & drRecepcion2.Item("NUMERODOCUMENTO") _
                            & Environment.NewLine & "Fecha del documento: " & drRecepcion2.Item("FECHADOCUMENTO") _
                            & Environment.NewLine & "Fecha de vencimiento" & drRecepcion2.Item("FECHAVENCIMIENTODOCUMENTO") _
                            & Environment.NewLine & "Valor: " & drRecepcion2.Item("VALOR") _
                            & Environment.NewLine & "Memo: " & drRecepcion2.Item("MEMO") _
                            & Environment.NewLine _
                            & Environment.NewLine & "¿Desea Radicar nuevamente el registro anterior?", "Radicar registro existente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case drResultado
                Case DialogResult.Yes 'Modificar registro existente.
                    comando = New SqlCommand("dbo.GestionarCorrespondenciarecibida", conexion)
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.AddWithValue("@TIPOACCION", 3) 'Actualizar radicado para documentos devueltos.
                    comando.Parameters.AddWithValue("@IDRECEPCION", idRecepcionAnterior) 'IdCorrespondencia
                    comando.Parameters.AddWithValue("@FECHARECEPCION", DBNull.Value)
                    comando.Parameters.AddWithValue("@TIPO", DBNull.Value)
                    comando.Parameters.AddWithValue("@DE", DBNull.Value)
                    comando.Parameters.AddWithValue("@NRORADICADO", DBNull.Value)
                    comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
                    comando.Parameters.AddWithValue("@VALOR", DBNull.Value)
                    comando.Parameters.AddWithValue("@NIT", DBNull.Value)
                    comando.Parameters.AddWithValue("@IDPERSONAFUNCIONARIO", DBNull.Value)
                    comando.Parameters.AddWithValue("@IDUSUARIO", VarBase.IdPersona)
                    comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBaseActual)
                    comando.Parameters.AddWithValue("@IDDEPENDENCIAPARA", DBNull.Value)
                    comando.Parameters.AddWithValue("@NUMERODOCUMENTO", prefijo & drRecepcion2.Item("NUMERODOCUMENTO"))
                    comando.Parameters.AddWithValue("@FECHADOCUMENTO", DBNull.Value)
                    comando.Parameters.AddWithValue("@FECHAVENCIMIENTODOCUMENTO", DBNull.Value)
                    comando.Parameters.AddWithValue("@MEMO", DBNull.Value)
                    comando.Parameters.AddWithValue("@IDGERENCIA", DBNull.Value)
                    If idSticker > 0 Then
                        comando.Parameters.AddWithValue("@IDSTICKER", idSticker)
                    Else
                        comando.Parameters.AddWithValue("@IDSTICKER", DBNull.Value)
                    End If
                    Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.BigInt)
                    msgParam.Direction = ParameterDirection.Output
                    comando.Parameters.Add(msgParam)
                    Try
                        conexion.Open()
                        comando.ExecuteNonQuery()
                        conexion.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Finally
                        conexion.Close()
                    End Try
                    radicoNuevamente = True
                    Return True
                Case DialogResult.No 'No modificar registros existentes y continuar con el guardado.
                    Return True
                Case DialogResult.Cancel 'Cancelar el proceso de guardado.
                    Return False
                Case Else
                    Return False
            End Select
        Else 'No existen registros anteriores.
            Return True
        End If
    End Function

    Private Sub EnviarCorreoRadicadoContabilidad(Optional drRecepcionAnterior As DataRow = Nothing)
        Dim correoOrigen As String = VarBase.correoCorrespondencia
        Dim correoDestino As String = "contabilidad1@ismocol.com"
        Dim conCopiaCorreos As New List(Of String) From {"contabilidad@ismocol.com", "contabilidad2@ismocol.com"}
        Dim asunto As String = "Seguimiento de Correspondencia SisControl - SIGMA"
        Dim cuerpo As New StringBuilder
        Dim textoContenido As New StringBuilder
        textoContenido.AppendLine("<div style='padding:10px;max-width:1000px;'>")
        textoContenido.AppendLine("    <table style='width:100%;' border='1'>")
        textoContenido.AppendLine("        <tr style='border-width:1px;border-style:solid;text-align:center;'>")
        textoContenido.AppendLine("            <td style='width:100px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' height='60' width='60' alt='Logo Ismocol S.A.'/></td>")
        textoContenido.AppendLine("            <td><center><b>" & asunto & "</b></center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='2'><center><b>REGISTRO EXISTENTE DE CORRESPONDENCIA RADICADO NUEVAMENTE</b></center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    <div style='padding:10px;'/>")
        textoContenido.AppendLine("    <table border='1' style='width:100%;'>")
        textoContenido.AppendLine("        <p>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Consecutivo:</b> " & consecutivo & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Usuario registró:</b> " & VarBase.Nombre_Usuario & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Fecha de registro:</b> " & DateTime.Now & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Base registra:</b> " & VarBase.AbreviaturaBaseSiscontrol & " - " & VarBase.NombreBaseSiscontrol & If(IdBaseActual = 0, " - " & VarBase.NombreDependenciaSiscontrol, "") & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Fecha de recepción:</b> " & Dtp_Fecha.Value & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Tipo de documento:</b> " & Cb_TipoDocumento.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Para dependencia:</b> " & Cb_Base.Text & " - " & Cb_Dependencia.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Gerencia:</b> " & NombreGerencia(idGerencia) & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Funcionario:</b> " & Cu_BuscarPersonaFuncionario.Cb_Persona.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>NIT:</b> " & Tx_Nit.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>De:</b> " & Tx_De.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Radicado No.:</b> " & Tx_NroRadicado.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Descripción:</b> " & Tx_Descripcion.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>No. documento:</b> " & Tx_NroDocumento.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Fecha del documento:</b> " & If(Dtp_FechaDocumento.Checked, Dtp_FechaDocumento.Value, "") & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Fecha de vencimiento:</b> " & If(Dtp_FechaVencimiento.Checked, Dtp_FechaVencimiento.Value, "") & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Valor:</b> " & CuTx_ValorDocumento.Texto & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Memo:</b> " & Tx_Memo.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><b>Sticker:</b> " & VarBase.AbreviaturaBaseSiscontrol & "-" & Tx_Sticker.Text & "</td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        </p>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='3'><CENTER>Por favor no conteste a esta dirección de correo.</CENTER></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td colspan='3'><CENTER>Para cualquier consulta comuníquese con <a href='mailto:desarrolloaplicaciones@ismocol.com'>desarrolloaplicaciones@ismocol.com</a></CENTER></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("</div>")
        FuncionesBase.FuncionesBase.EnviarCorreo(textoContenido.ToString, asunto, correoOrigen, correoDestino, conCopiaCorreos, False, "", True)
    End Sub

#End Region 'Volver a radicar

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Base.SelectedIndexChanged
        VarBase.IdBaseSiscontrolActual = Cb_Base.SelectedValue
        CargarDependencias()
        If IdEmpresaSeleccionada() = 0 Then
            If Cb_Base.SelectedValue = 0 AndAlso Not PuedeElegirDependenciasEnPrincipal() Then
                CargarGerencia(VarBase.IddependenciaSiscontrolActual)
                BloquearCamposPorGerencia()
            Else
                HabilitarCamposPorGerencia()
            End If
        Else
            HabilitarCamposPorGerencia()
        End If
    End Sub

    ''' <summary></summary>
    Public Sub CargarDependencias()
        comando = New SqlCommand("ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        If PuedeElegirDependenciasEnPrincipal() Then
            comando.Parameters("@ACCION").Value = 11 'Cargar todas las dependencias activas de la base (incluyendo Gerencia).
        Else
            comando.Parameters("@ACCION").Value = 3 'Cargar todas las dependencias activas de la base (excluyendo Gerencia).
        End If
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", Cb_Base.SelectedValue)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VarBase.IddependenciaSiscontrolActual)
        adaptador = New SqlDataAdapter(comando)
        dtDependencias = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtDependencias)
            conexion.Close()
            Cb_Dependencia.DataSource = dtDependencias
            'Cb_Dependencia.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cb_Dependencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Dependencia.SelectedIndexChanged
        If Not IsNothing(Cb_Dependencia.SelectedValue) Then
            VarBase.IddependenciaSiscontrolBusqueda = Cb_Dependencia.SelectedValue
            CargarPersonaPorDependencia()
            CargarGerencia(Cb_Dependencia.SelectedValue)
        End If
    End Sub

    ''' <summary></summary>
    Private Sub CargarPersonaPorDependencia()
        If Cb_Base.SelectedValue = 0 AndAlso Not PuedeElegirDependenciasEnPrincipal() Then
            CargarFuncionarioPorGerencia()
        Else
            If CargaPersona AndAlso Not IsNothing(Cb_Dependencia.SelectedValue) Then
                Cu_BuscarPersonaFuncionario.CargarDatos()
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "CR", "FUNCIONARIO", -1)
            End If
        End If
    End Sub

    ''' <summary>Para cargar al asociar una persona.</summary>
    ''' <param name="IDPERSONA"></param>
    ''' <param name="NOMBRECOMPONENTE"></param>
    Public Sub cargarpersonalasociadobodega(Optional IDPERSONA As Integer = -1, Optional NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue
            Cu_BuscarPersonaFuncionario.CargarDatos()
            Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = temp
            Cu_BuscarPersonaFuncionario.CargarCajaTexto()
        Catch
        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaFuncionario.Name
                Cu_BuscarPersonaFuncionario.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

    Private Sub Tx_NroDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_NroDocumento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            If Trim(Tx_NroDocumento.Text).Length > 0 AndAlso (Trim(Tx_Nit.Text).Length > 0 OrElse Trim(Tx_De.Text).Length > 0) Then
                Dim dtRecepcion As DataTable
                dtRecepcion = BuscarExistente()
                If Not IsNothing(dtRecepcion) AndAlso dtRecepcion.Rows.Count > 0 Then
                    Cargar_Recepcion(dtRecepcion.Rows(0).Item("IDRECEPCION"))
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Fr_CorrespondenciaRecibida_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        VarBase.IdBaseSiscontrolActual = IdBaseActual
    End Sub

    Private Sub Bt_BuscarSticker_Click(sender As Object, e As EventArgs) Handles Bt_BuscarSticker.Click
        Using frBuscarSticker As New Fr_BuscarSticker
            If IdCorrespondencia > 0 Then
                frBuscarSticker.IdRecepcion = IdCorrespondencia
            End If
            Dim dr As DialogResult
            dr = frBuscarSticker.ShowDialog()
            If dr = DialogResult.OK Then
                idSticker = frBuscarSticker.IdSticker
                Tx_Sticker.Text = frBuscarSticker.NumeroSticker
            End If
        End Using
    End Sub

End Class 'Fr_CorrespondenciaRecibida