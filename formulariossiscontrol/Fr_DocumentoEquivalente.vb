Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports FormulariosClasesBase

Public Class Fr_DocumentoEquivalente

    Public Editando As Boolean = False
    Public IdDocumento As Integer
    Public Consecutivo As Integer
    Private Año As String = Year(Date.Now)
    Private IdDependencia As Integer
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Fila_Editar_Documento As DataRow
    Private _guardado As Boolean = False
    Public ConsecutivoDian As Integer
    Public Codigosdisponibles As Integer
    Private AcumuladoIngresosBrutos As Double
    Private AcumuladoSigma As Double
    Private AcumuladoValorDocumento As Double
    Private MaxIngresosBrutos As Double

    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property




    Dim dsCargar As New DataSet
    Public Sub CargarTablas()
        IdDependencia = VariablesBase.VariablesBase.IddependenciaSiscontrolActual

        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CargarCombos()
        CargarPersonas()
        BuscarObligacionFacturarProveedor()
        dsCargar = bddatos.CargarMaestrasSiscontrol(11, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdDocumento, 2)

        Cb_TipoDocumento.DataSource = dsCargar.Tables(1)
        Cb_TipoDocumento.ValueMember = "CODIGO"
        Cb_TipoDocumento.DisplayMember = "NOMBRE"

        Cb_TipoMoneda.DataSource = dsCargar.Tables(2)
        Cb_TipoMoneda.ValueMember = "CODIGOTIPOMONEDA"
        Cb_TipoMoneda.DisplayMember = "NOMBRETIPOMONEDA"

        Codigosdisponibles = dsCargar.Tables(3).Rows(0).Item("Disponible")

        Cb_AurorizaDctoSS.DataSource = dsCargar.Tables(4)
        Cb_AurorizaDctoSS.ValueMember = "CODIGO"
        Cb_AurorizaDctoSS.DisplayMember = "NOMBRE"
        Cb_AurorizaDctoSS.SelectedIndex = -1


        If Editando = True Then
            Fila_Editar_Documento = dsCargar.Tables(0).Rows(0)
        Else
            Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
            Me.Cu_CentroCosto1.Editando = 2
            Me.Cu_CentroCosto1.CargarCentro()
        End If
    End Sub

    Private Sub CargarCombos()
        Cu_BuscarPersonaResponsable.CargarDatos()
        Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "CC", "RESPONSABLE", -1)
    End Sub

    Private Sub CargarPersonas()
        Cu_BuscarPersonaResponsable.CargarDatos()
    End Sub

    Public Sub CargarDatosDocumento()

        Consecutivo = Fila_Editar_Documento("CONSECUTIVO")
        Año = Fila_Editar_Documento("AÑO")
        Dtp_Fecha.Value = Fila_Editar_Documento("FECHADOCUMENTOEQUIVALENTE")

        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Fila_Editar_Documento("IDDEPENDENCIA")

        If Not IsDBNull(Fila_Editar_Documento("NIT")) AndAlso Trim(Fila_Editar_Documento("NIT")).Length > 0 Then
            Dim nit As Integer = FuncionesBase.FuncionesBase.ValorRealInt(Fila_Editar_Documento("NIT"))
            If nit > 0 Then
                Tx_IdentificacionNIT.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(nit)
            End If
        End If

        Tx_Proveedor.Text = Fila_Editar_Documento("PROVEEDOR")
        Tx_Concepto.Text = Fila_Editar_Documento("CONCEPTO")
        Tx_ValorDocumento.Text = Replace(CStr(Fila_Editar_Documento("VALORDOCUMENTOEQUIVALENTE")), ".00", "")
        Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue = Fila_Editar_Documento("IDPERSONARESPONSABLEISMOCOL")
        Cb_TipoDocumento.SelectedValue = Fila_Editar_Documento("TIPODOCUMENTO")

        If Year(Fila_Editar_Documento("FECHAVENCIMIENTO")) <> 1900 Then
            Dtp_FechaVencimiento.Value = Fila_Editar_Documento("FECHAVENCIMIENTO")
            Dtp_FechaVencimiento.Checked = True
        End If
        Me.Cu_CentroCosto1.IdCentroCosto = Fila_Editar_Documento("IDCENTROCOSTO")
        Me.Cu_CentroCosto1.Editando = 3
        Me.Cu_CentroCosto1.CargarCentro()

        Cb_TipoMoneda.SelectedValue = Fila_Editar_Documento("CODIGOTIPOMONEDA")
        Lb_Consecutivo.Text = Fila_Editar_Documento("CONSECUTIVOISMOCOL")
        IdDependencia = Fila_Editar_Documento("IDDEPENDENCIA")
        Cb_AurorizaDctoSS.SelectedValue = Fila_Editar_Documento("AUTORIZADESCTSS")
        Lb_Consecutivo.Visible = True
        SubBuscarFacturasSiesa()

    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Guardar_Datos() = True Then
            Close()
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Function Guardar_Datos() As Boolean
        Try

            If Editando = False Then
                BuscarObligacionFacturarProveedor()
            Else
                If Año = Year(Now) Then
                    BuscarObligacionFacturarProveedor()
                End If
            End If
            If ValidarDocumento() Then


                GuardarDocumento()
            Else
                Guardar_Datos = False
                Exit Function
            End If
            Guardar_Datos = _guardado
        Catch ex As Exception
            Guardar_Datos = False
            MessageBox.Show(ex.Message, "Error al guardar los datos." & Environment.NewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GuardarDocumento()

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarDocumentoEquivalente")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@IDDOCUMENTOEQUIVALENTE", IdDocumento)
        Comando.Parameters.AddWithValue("@AÑO", Año)
        Comando.Parameters.AddWithValue("@CONSECUTIVO", Consecutivo)
        Comando.Parameters.AddWithValue("@FECHADOCUMENTOEQUIVALENTE", Dtp_Fecha.Value)
        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", Cb_TipoDocumento.SelectedValue)
        Dim nit As Integer
        Try
            nit = FuncionesBase.FuncionesBase.ValorRealInt(Tx_IdentificacionNIT.Text)
        Catch
        End Try
        If Not IsNothing(nit) AndAlso nit > 0 Then
            Comando.Parameters.AddWithValue("@NIT", nit)
        Else
            Comando.Parameters.AddWithValue("@NIT", "")
        End If

        Comando.Parameters.AddWithValue("@PROVEEDOR", Tx_Proveedor.Text)
        Comando.Parameters.AddWithValue("@CONCEPTO", UCase(Tx_Concepto.Text))
        Comando.Parameters.AddWithValue("@VALORDOCUMENTOEQUIVALENTE", CDec(Trim(Tx_ValorDocumento.Text)))
        If Dtp_FechaVencimiento.Checked Then
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTO", Dtp_FechaVencimiento.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTO", "")
        End If
        Comando.Parameters.AddWithValue("@IDPERSONARESPONSABLE", Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@CODIGOTIPOMONEDA", Cb_TipoMoneda.SelectedValue)
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Cu_CentroCosto1.IdCentroCosto)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        Comando.Parameters.AddWithValue("@CONSECUTIVODIAN", ConsecutivoDian)
        Comando.Parameters.AddWithValue("@AUTORIZADESCTSS", Cb_AurorizaDctoSS.SelectedValue)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim ConsecutivoParam As New SqlParameter("@CONSECUTIVO_MOSTRAR", SqlDbType.NChar, 4)
        ConsecutivoParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(ConsecutivoParam)
        Dim MensajeAlertaParam As New SqlParameter("@MENSAJEALERTA", SqlDbType.Int, 1)
        MensajeAlertaParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(MensajeAlertaParam)
        Dim ConsecutivoDianParam As New SqlParameter("@CONSECUTIVO_DIANMOSTRAR", SqlDbType.Int, 4)
        ConsecutivoDianParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(ConsecutivoDianParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()


        If Editando = False Then
            Dim Consecutivo As String
            Consecutivo = VariablesBase.VariablesBase.AbreviaturaBaseSiscontrol & "-" & CStr(Trim(ConsecutivoParam.Value)) & "-" & Now.Year
            If VariablesBase.VariablesBase.EmpresaSisControlActual = 0 Then
                MsgBox("El consecutivo  Ismocol es: " & Consecutivo & vbCrLf & "El consecutivo Dian es No. IDE: " & ConsecutivoDianParam.Value, MsgBoxStyle.Information, "CONSECUTIVO")
            Else
                MsgBox("El consecutivo  Zamorana es: " & Consecutivo & vbCrLf & "El consecutivo Dian es No. ZDS: " & ConsecutivoDianParam.Value, MsgBoxStyle.Information, "CONSECUTIVO")
            End If
            If MensajeAlertaParam.Value < 500 Then
                MsgBox("Quedan " + CStr(MensajeAlertaParam.Value) + " consecutivos dian disponibles ", MsgBoxStyle.Information, "CONSECUTIVO DIAN")
            End If
        End If

        conn.Close()

        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CC", "RESPONSABLE", Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue)

        Me.Close()

        'If MsgBox("¿Desea imprimir el Documento Soporte?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
        '    Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
        '    Dim Array As New ArrayList
        '    Array.Add(80)
        '    If Editando = False Then
        '        climpresiones.idDocumento = msgParam.Value
        '    Else
        '        climpresiones.idDocumento = IdDocumento
        '    End If

        '    climpresiones.FormatoImprimirSisControl(Array, True, False)
        '    MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        'End If

        If Cb_AurorizaDctoSS.SelectedValue <> "X" Then
            If MsgBox("¿Desea subir el Documento de Autorización Descuentos de Seguridad Social?", MsgBoxStyle.YesNo, "SUBIR DOCUMENTO ICA-GRAL-F-193") = MsgBoxResult.Yes Then

                Dim FrArchivoSS As New FormulariosSisControl.Fr_ArchivoSS
                FrArchivoSS.CargarTablas()
                FrArchivoSS.Tipo = "DS"
                If Editando = True Then
                    FrArchivoSS.IdDocumento = IdDocumento
                Else
                    FrArchivoSS.IdDocumento = msgParam.Value
                End If
                FrArchivoSS.ShowDialog()
            End If
        End If

    End Sub


    Private Function ValidarDocumento() As Boolean

        If Tx_Concepto.Text = "" Then
            MsgBox("Debe Agregar un concepto", MsgBoxStyle.Critical, "CONCEPTO")
            ValidarDocumento = False
            Tx_Concepto.Focus()
            Exit Function
        End If

        'If Dtp_FechaVencimiento.Checked = False Then
        '    MsgBox("Seleccioné fecha de vencimiento", MsgBoxStyle.Critical, "FECHA VENCIMIENTO")
        '    ValidarCobro = False
        '    Dtp_FechaVencimiento.Focus()
        '    Exit Function
        'End If

        If Tx_ValorDocumento.Text = "" Then
            MsgBox("Agrege valor de documento", MsgBoxStyle.Critical, "Valor")
            ValidarDocumento = False
            Tx_ValorDocumento.Focus()
            Exit Function
        End If

        If IsNumeric(Tx_ValorDocumento.Text) = False Then
            MsgBox("Agrege valor de documento", MsgBoxStyle.Critical, "Valor")
            ValidarDocumento = False
            Tx_ValorDocumento.Text = ""
            Tx_ValorDocumento.Focus()
            Exit Function
        End If

        If Trim(Tx_IdentificacionNIT.Text) = "" Then
            MsgBox("Debe seleccionar el Proveedor o Contratista.", MsgBoxStyle.OkOnly, "Guardar Aprobación")
            Tx_IdentificacionNIT.Focus()
            Return False
        End If

        If IsNothing(Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona responsable  ", MsgBoxStyle.Critical, "RESPONSABLE")
            ValidarDocumento = False
            Cu_BuscarPersonaResponsable.Cb_Persona.Focus()
            Exit Function
        End If

        If Cb_AurorizaDctoSS.SelectedIndex < 0 Then
            MsgBox("Seleccione una opción de Autoriza Dcto SS", MsgBoxStyle.Information, "AUTORIZA DCTO SS")
            Cb_AurorizaDctoSS.Focus()
            ValidarDocumento = False
            Exit Function
        End If

        If AcumuladoValorDocumento > MaxIngresosBrutos Then
            MsgBox("Los ingresos brutos totales provenientes de actividades en el año en curso deben ser inferiores a 3500 UVT, para el año " + Año + " es $ " + Format(Val(MaxIngresosBrutos), "#,###.##"), MsgBoxStyle.Information, "Información")
            ValidarDocumento = False
            Exit Function
        End If


        ValidarDocumento = True
    End Function

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_BuscarProveedor_Click(sender As Object, e As EventArgs) Handles Bt_BuscarProveedor.Click
        CargarProveedor()
    End Sub

    Public Sub CargarProveedor()

        If Ll_ValorAcumuladoProveedor.Text.Count > 0 Then
            Ll_ValorAcumuladoProveedor.Text = ""
            AcumuladoIngresosBrutos = 0
            AcumuladoSigma = 0
            AcumuladoValorDocumento = 0
            MaxIngresosBrutos = 0
        End If


        Dim frBuscarContratista As New Fr_BuscarContratista
        frBuscarContratista.Cargar_Tabla()
        frBuscarContratista.ShowDialog()
        comando = New SqlCommand("SELECT * FROM DatosBasicosContratista(@IDCONTRATISTA)", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATISTA", frBuscarContratista.IdContratista)
        adaptador = New SqlDataAdapter(comando)
        Dim dtProveedor As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtProveedor)
            conexion.Close()
            If dtProveedor.Rows.Count > 0 Then
                Dim filaProveedor As DataRow = dtProveedor.Rows(0)
                Tx_IdentificacionNIT.Text = filaProveedor("IDENTIFICACION")
                Tx_Proveedor.Text = filaProveedor("NOMBRE")
                SubBuscarFacturasSiesa()
              
                BuscarObligacionFacturarProveedor()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Sub SubBuscarFacturasSiesa()
        If Tx_IdentificacionNIT.Text.Count > 0 Then

            Dim Comando As New SqlClient.SqlCommand("dbo.TopeFacturacionXProveedor")
            Comando.CommandType = CommandType.StoredProcedure

            Dim nit As Integer
            Try
                nit = FuncionesBase.FuncionesBase.ValorRealInt(Tx_IdentificacionNIT.Text)
            Catch
            End Try
            If Not IsNothing(nit) AndAlso nit > 0 Then
                Comando.Parameters.AddWithValue("@IDENTIFICACION", nit)
            Else
                Comando.Parameters.AddWithValue("@IDENTIFICACION", "")
            End If

            Dim TopeProveedor As New SqlParameter("@TOPE", SqlDbType.Float)
            TopeProveedor.Direction = ParameterDirection.Output
            Comando.Parameters.Add(TopeProveedor)


            Dim valorUVT As New SqlParameter("@UVT", SqlDbType.Float)
            valorUVT.Direction = ParameterDirection.Output
            Comando.Parameters.Add(valorUVT)

            Dim sumSigma As New SqlParameter("@SUMSIGMA", SqlDbType.Float)
            sumSigma.Direction = ParameterDirection.Output
            Comando.Parameters.Add(sumSigma)


            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()

            Dim UVT As Double = valorUVT.Value
            MaxIngresosBrutos = 3500 * UVT
            AcumuladoIngresosBrutos = TopeProveedor.Value
            AcumuladoSigma = sumSigma.Value
        End If
    End Sub


    Public Sub BuscarObligacionFacturarProveedor()
        If Not IsDBNull(AcumuladoSigma) And AcumuladoSigma > 0 Then
            MsgBox("Valor registrado en facturas a la fecha en SIGMA $ " & Format(Val(AcumuladoSigma), "#,###.##") + Chr(13) + Chr(13) + "Nota:" + Chr(13) + " Los ingresos brutos totales provenientes de actividades en el año en curso deben ser inferiores a 3500 UVT, para el año " + Año + " es $ " + Format(Val(MaxIngresosBrutos), "#,###.##"), MsgBoxStyle.Information, "Información")

        End If

        If Not IsDBNull(AcumuladoIngresosBrutos) And AcumuladoIngresosBrutos > 0 Then
            AcumuladoValorDocumento = AcumuladoIngresosBrutos
            If (AcumuladoIngresosBrutos) < MaxIngresosBrutos Then
                Ll_ValorAcumuladoProveedor.Text = "Valor registrado en facturas a la fecha en SIESA: $ " + Format(Val(AcumuladoIngresosBrutos), "#,###.##")
                Ll_ValorAcumuladoProveedor.LinkColor = Drawing.Color.Blue
            Else
                Ll_ValorAcumuladoProveedor.Text = "Valor registrado en facturas a la fecha en SIESA: $ " + Format(Val(AcumuladoIngresosBrutos), "#,###.##")
                Ll_ValorAcumuladoProveedor.LinkColor = Drawing.Color.Red
            End If
           
        End If

        If Tx_ValorDocumento.Text.Count > 0 Then
            Dim cadenas As Integer = FuncionesBase.FuncionesBase.ValorRealInt(Tx_ValorDocumento.Text)
            If cadenas > 0 Then
                AcumuladoValorDocumento = AcumuladoIngresosBrutos + cadenas
                If AcumuladoValorDocumento > MaxIngresosBrutos Then
                    Ll_ValorAcumuladoProveedor.Text = "Valor registrado en facturas a la fecha en SIESA: $ " + Format(Val(AcumuladoIngresosBrutos), "#,###.##")
                    Ll_ValorAcumuladoProveedor.LinkColor = Drawing.Color.Red
                Else
                    Ll_ValorAcumuladoProveedor.Text = "Valor registrado en facturas a la fecha en SIESA: $ " + Format(Val(AcumuladoIngresosBrutos), "#,###.##")
                    Ll_ValorAcumuladoProveedor.LinkColor = Drawing.Color.Blue
                End If
            End If
        End If

    End Sub

    Private Sub Tx_ValorDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_ValorDocumento.KeyPress
        Dim Caja As TextBox = sender
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_ValorDocumento_GotFocus(sender As Object, e As EventArgs) Handles Tx_ValorDocumento.LostFocus
        Try
            Dim Caja As TextBox = sender
            Dim Cadena As String = Replace(Caja.Text, "$", "")
            Cadena = Replace(Cadena, " ", "")
            Cadena = Replace(Cadena, ".", "")

            Dim pos As Integer = Cadena.LastIndexOf(",")
            If pos = Cadena.Length - 3 Then
                'tiene ",00"
                Cadena = Mid(Cadena, 1, Cadena.Length - 3)
            Else
                If pos = Cadena.Length - 2 Then
                    'tiene ",0"
                    Cadena = Mid(Cadena, 1, Cadena.Length - 2)
                End If
            End If
            Cadena = Replace(Cadena, ",", "")
            If IsNumeric(Cadena) = False Then
                Caja.BackColor = Drawing.Color.MintCream
            Else
                Caja.Text = Replace(Format(Cadena, "Currency"), ",00", "")
                Caja.BackColor = Drawing.Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Fr_DocumentoEquivalente_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dtp_Fecha.Enabled = False
    End Sub
End Class