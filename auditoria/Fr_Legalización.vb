Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Text

Public Class Fr_Legalización
    Public Editando As Boolean
    Public idlegalizacion As Integer = -1
    Public ConsecutivoAsignado As Boolean
    Public ValorConsecutivoAsignado As Integer
    Private IdpersonaLegalización As Integer = -1
    Private Dr_CargaPersona As DataRow
    Private Fila_legalizacion As DataRow
    Private guardado As Boolean = False
    Private Fila_Contrato As DataRow
    Private dtComprobante As DataTable

    Public Sub Cargar_Combos()
        Tx_IdentificaciónPersona.Focus()
        Me.MA_TIPOSALDOTableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOSALDO)
        Me.MA_TIPOLEGALIZACIONTableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOLEGALIZACION)
        Me.MA_TIPOGRUPOTableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOGRUPO)
        Me.MA_TIPOCARGOTableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOCARGO)
        Me.MA_TIPOCATEGORIATableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOCATEGORIA)
        Me.MA_TIPOCONCEPTOADICIONALTableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOCONCEPTOADICIONAL)
        Me.MA_CONCEPTOADICIONALTableAdapter.Fill(Me.Ds_Auditoria.MA_CONCEPTOADICIONAL, Me.Cb_TipoConcepto.SelectedValue)
        Me.MA_TIPOCOMPROBANTETableAdapter.Fill(Me.Ds_Auditoria.MA_TIPOCOMPROBANTE)

        Me.Cb_Cargo.SelectedIndex = 0 ' = -1
        Me.Cb_Categoría.SelectedIndex = -1
        Me.Cb_Grupo.SelectedIndex = -1
        Me.Cb_TipoComprobante.SelectedIndex = -1
        Me.Cb_NombreComprobante.SelectedIndex = -1
        Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
        Me.Cb_TipoSaldo.SelectedIndex = -1
        Me.Cb_Estado.SelectedIndex = -1
        Me.Cb_TipoSaldo.SelectedIndex = -1
        Me.Cb_TipoLegalización.SelectedIndex = -1

        'Cargar datos de las rejillas
        Me.Dgv_Comprobante.AutoGenerateColumns = True
        Me.Dgv_Comprobante.DataSource = Ds_Auditoria.COMPROBANTE
        Me.Dgv_Conceptos.AutoGenerateColumns = True
        Me.Dgv_Conceptos.DataSource = Ds_Auditoria.CONCEPTO

        If Editando Then
            'Cuando se va a editar
            Me.SC_LEGALIZACIONTableAdapter.FillLegalizacion(Ds_Auditoria.SC_LEGALIZACION, idlegalizacion)
            Fila_legalizacion = Me.Ds_Auditoria.SC_LEGALIZACION(0)
            Me.Dtp_FechaLegalización.Value = Fila_legalizacion("FECHALEGALIZACION")
            Me.Tx_IdentificaciónPersona.Text = Trim(FuncionesBase.FuncionesBase.ConsultaridentificacionPersona(Fila_legalizacion("IDPERSONA")))
            CargarPersona()
            Me.Cb_Categoría.SelectedValue = Fila_legalizacion("CODIGOTIPOCATEGORIA")
            Me.Cb_Cargo.SelectedValue = Fila_legalizacion("CODIGOTIPOCARGO")
            Me.Cb_Grupo.SelectedValue = Fila_legalizacion("CODIGOTIPOGRUPO")
            Me.Cb_TipoLegalización.SelectedValue = Fila_legalizacion("CODIGOTIPOLEGALIZACION")
            Me.Tx_ValorViatico.Text = Replace(Format(Fila_legalizacion("VALORVIATICO"), "Currency"), ",00", "")
            Me.Tx_Alimentacion.Text = Replace(Format(Fila_legalizacion("VALORALIMENTACION"), "Currency"), ",00", "")
            Me.Tx_Alojamiento.Text = Replace(Format(Fila_legalizacion("VALORALOJAMIENTO"), "Currency"), ",00", "")
            Me.Tx_Incidental.Text = Replace(Format(Fila_legalizacion("VALORINCIDENTAL"), "Currency"), ",00", "")
            If Me.Tx_ValorViatico.Text <> 0 Then
                Me.Tx_ValorViatico.Enabled = True
                Me.Tx_Alimentacion.Enabled = True
                Me.Tx_Alojamiento.Enabled = True
                Me.Tx_Incidental.Enabled = True
            Else
                Me.Tx_ValorViatico.Enabled = False
                Me.Tx_Alimentacion.Enabled = False
                Me.Tx_Alojamiento.Enabled = False
                Me.Tx_Incidental.Enabled = False
            End If
            Me.DTP_FechaDesde.Value = Fila_legalizacion("FECHADESDE")
            Me.DTP_FechaHasta.Value = Fila_legalizacion("FECHAHASTA")
            Me.Cb_TipoSaldo.SelectedValue = Fila_legalizacion("CODIGOTIPOSALDO")
            Me.Tx_ValorSaldo.Text = Replace(Format(Fila_legalizacion("VALORSALDO"), "Currency"), ",00", "")
            Me.Cu_CentroCosto1.IdCentroCosto = Fila_legalizacion("IDCENTROCOSTO")
            Me.Cu_CentroCosto1.Editando = 1
            Me.Tx_Descripción.Text = Trim(Fila_legalizacion("DESCRIPCION"))
            Me.Tx_Observación.Text = Trim(Fila_legalizacion("OBSERVACIONES"))
            Me.Lb_Consecutivo.Text = "Consecutivo: " & Fila_legalizacion("CONSECUTIVO")
            Dim Estado As String = Fila_legalizacion("ESTADOTIPOLEGALIZACION")
            Select Case Estado
                Case "A"
                    Me.Cb_Estado.SelectedIndex = 0
                Case "L"
                    Me.Cb_Estado.SelectedIndex = 1
                Case "V"
                    Me.Cb_Estado.SelectedIndex = 2
                Case Else
                    Me.Cb_Estado.SelectedIndex = -1
            End Select

            'Cargar comprobante
            Dim AdatadorComprobante As New DatosAuditoria.Ds_AuditoriaTableAdapters.LISTACOMPROBANTETableAdapter
            AdatadorComprobante.Fill(Ds_Auditoria.LISTACOMPROBANTE, idlegalizacion)
            If Ds_Auditoria.LISTACOMPROBANTE.Rows.Count > 0 Then
                For i = 0 To Ds_Auditoria.LISTACOMPROBANTE.Rows.Count - 1
                    Dim Fila As DataRow
                    Fila = Ds_Auditoria.COMPROBANTE.NewRow
                    Fila("CODIGOTIPOCOMPROBANTE") = Ds_Auditoria.LISTACOMPROBANTE.Rows(i).Item("CODIGOTIPOCOMPROBANTE")
                    Fila("ABREVIATURATIPOCOMPROBANTE") = Ds_Auditoria.LISTACOMPROBANTE.Rows(i).Item("ABREVIATURATIPOCOMPROBANTE")
                    Fila("NUMEROCOMPROBANTE") = Ds_Auditoria.LISTACOMPROBANTE.Rows(i).Item("NUMEROCOMPROBANTE")
                    Fila("NOMBRETIPOCOMPROBANTE") = Ds_Auditoria.LISTACOMPROBANTE.Rows(i).Item("NOMBRETIPOCOMPROBANTE")
                    Ds_Auditoria.COMPROBANTE.Rows.Add(Fila)
                Next
            End If

            'Cargar concepto
            Dim AdatadorConcepto As New DatosAuditoria.Ds_AuditoriaTableAdapters.LISTACONCEPTOTableAdapter
            Try
                AdatadorConcepto.Fill(Ds_Auditoria.LISTACONCEPTO, idlegalizacion)
            Catch ex As Exception
                MessageBox.Show("No fue posible cargar el listado de conceptos.", "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If Ds_Auditoria.LISTACONCEPTO.Rows.Count > 0 Then
                For i = 0 To Ds_Auditoria.LISTACONCEPTO.Rows.Count - 1
                    Dim Fila As DataRow
                    Fila = Ds_Auditoria.CONCEPTO.NewRow
                    Fila("CODIGOCONCEPTOADICIONAL") = Ds_Auditoria.LISTACONCEPTO.Rows(i).Item("CODIGOCONCEPTOADICIONAL")
                    Fila("NOMBRECONCEPTOADICIONAL") = Ds_Auditoria.LISTACONCEPTO.Rows(i).Item("NOMBRECONCEPTOADICIONAL")
                    Fila("CODIGOTIPOCONCEPTOADICIONAL") = Ds_Auditoria.LISTACONCEPTO.Rows(i).Item("CODIGOTIPOCONCEPTOADICIONAL")
                    Fila("NOMBRETIPOCONCEPTOADICIONAL") = Ds_Auditoria.LISTACONCEPTO.Rows(i).Item("NOMBRETIPOCONCEPTOADICIONAL")
                    Fila("VALOR") = Format(Ds_Auditoria.LISTACONCEPTO.Rows(i).Item("VALOR"), "###,###,###.##")
                    Fila("CANTIDADDIAS") = Ds_Auditoria.LISTACONCEPTO.Rows(i).Item("CANTIDADDIAS")
                    Ds_Auditoria.CONCEPTO.Rows.Add(Fila)
                Next
            End If
        Else
            'Cuando se va a guardar uno nuevo
        End If
        Me.Cu_CentroCosto1.CargarCentro()
    End Sub

    Private Sub Fr_Legalización_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        Cu_Auditoria.ValorConsecutivoAsignado = -1  '' Cu_Auditoria.ValorConsecutivoAsignado -= 1  modificado
    End Sub

    Private Sub Fr_Legalización_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Lb_Consecutivo.Text = "Consecutivo: " & CStr(ValorConsecutivoAsignado)
        Me.Dgv_Comprobante.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Comprobante.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Conceptos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Conceptos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Cargar_Combos()
    End Sub

    Private Sub Cb_TipoConcepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_TipoConcepto.SelectedIndexChanged
        Me.MA_CONCEPTOADICIONALTableAdapter.Fill(Me.Ds_Auditoria.MA_CONCEPTOADICIONAL, Me.Cb_TipoConcepto.SelectedValue)
    End Sub

    Private Sub Button_Aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Aceptar.Click
        If Validar_Legalización() = True Then
            If Editando = True Then
                Modificar_Legalización()
                guardado = True
                Me.Close()
            Else
                Guardar_Legalización()
                guardado = True
                Cu_Auditoria.ValorConsecutivoAsignado = Cu_Auditoria.ValorConsecutivoAsignado + 1
                LimpiarControles()
            End If
        End If
    End Sub

    Private Sub LimpiarControles()
        Me.Tx_IdentificaciónPersona.Focus()
        ValorConsecutivoAsignado += 1
        Me.Dtp_FechaLegalización.Value = Date.Now
        Me.Tx_IdentificaciónPersona.Text = ""
        Me.Cb_Categoría.SelectedIndex = -1
        Me.Cb_Cargo.SelectedIndex = 0 ' = -1
        Me.Cb_Grupo.SelectedIndex = -1
        Me.Cb_TipoLegalización.SelectedIndex = -1
        Me.Tx_ValorViatico.Text = "0"
        Me.Tx_Alimentacion.Text = "0"
        Me.Tx_Alojamiento.Text = "0"
        Me.Tx_Incidental.Text = "0"
        Me.DTP_FechaDesde.Value = Date.Now
        Me.DTP_FechaHasta.Value = Date.Now
        Me.Cb_TipoSaldo.SelectedIndex = -1
        Me.Tx_ValorSaldo.Text = "0"
        Me.Cb_Estado.SelectedIndex = -1
        Me.Tx_Descripción.Text = ""
        Me.Tx_Observación.Text = ""
        Me.Lb_Consecutivo.Text = "Consecutivo: " & CStr(Cu_Auditoria.ValorConsecutivoAsignado)
        Ds_Auditoria.COMPROBANTE.Clear()
        Ds_Auditoria.CONCEPTO.Clear()
        Me.Dgv_Comprobante.AutoGenerateColumns = True
        Me.Dgv_Comprobante.DataSource = Ds_Auditoria.COMPROBANTE
        Me.Dgv_Conceptos.AutoGenerateColumns = True
        Me.Dgv_Conceptos.DataSource = Ds_Auditoria.CONCEPTO
    End Sub

    Private Sub Guardar_Legalización()
        Dim IdLegalizacion As Long
        IdLegalizacion = FuncionesBase.FuncionesBase.Siguiente("SC_LEGALIZACION", 0)
        Dim Consecutivo As Long
        If ConsecutivoAsignado = True Then
            Consecutivo = ValorConsecutivoAsignado
        Else
            Consecutivo = FuncionesBase.FuncionesBase.Siguiente("SC_CONSECUTIVOLEGALIZACION", 0, Me.Dtp_FechaLegalización.Value)
        End If
        Dim adap As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
        Dim estado As String
        Select Case Me.Cb_Estado.Text
            Case "ACTIVO"
                estado = "A"
            Case "LIQUIDADO"
                estado = "L"
            Case "VACACIONES"
                estado = "V"
            Case Else
                estado = ""
        End Select
        adap.Insert(IdLegalizacion, Me.Dtp_FechaLegalización.Value, IdpersonaLegalización,
                    Me.Cb_Cargo.SelectedValue, Me.Cb_Grupo.SelectedValue, Me.Cb_TipoLegalización.SelectedValue,
                    FuncionesBase.FuncionesBase.ValorRealInt(Me.Tx_ValorViatico.Text), Me.DTP_FechaDesde.Value, Me.DTP_FechaHasta.Value, Me.Cb_TipoSaldo.SelectedValue,
                    FuncionesBase.FuncionesBase.ValorRealInt(Me.Tx_ValorSaldo.Text),
                    estado, Me.Tx_Descripción.Text, Me.Tx_Observación.Text, Date.Now,
                    VariablesBase.VariablesBase.IdPersona, Date.Now,
                    VariablesBase.VariablesBase.IdPersona,
                    Me.Cb_Categoría.SelectedValue, Consecutivo, Tx_Alimentacion.Text, Tx_Alojamiento.Text, Tx_Incidental.Text,
                    Me.Cu_CentroCosto1.IdCentroCosto)
        Guardar_comprobantes(IdLegalizacion)
        Guardar_Concepto(IdLegalizacion)
        MsgBox("Agregar consecutivo: " & Consecutivo, MsgBoxStyle.Information, "Consecutivo")
    End Sub

    Private Sub Modificar_Legalización()
        Dim estado As String
        Select Case Me.Cb_Estado.Text
            Case "ACTIVO"
                estado = "A"
            Case "LIQUIDADO"
                estado = "L"
            Case "VACACIONES"
                estado = "V"
            Case Else
                estado = ""
        End Select
        Dim adap As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
        adap.Update(idlegalizacion, Me.Dtp_FechaLegalización.Value, IdpersonaLegalización,
                         Me.Cb_Cargo.SelectedValue, Me.Cb_Grupo.SelectedValue, Me.Cb_TipoLegalización.SelectedValue,
                        FuncionesBase.FuncionesBase.ValorRealInt(Me.Tx_ValorViatico.Text), Me.DTP_FechaDesde.Value, Me.DTP_FechaHasta.Value, Me.Cb_TipoSaldo.SelectedValue,
                        FuncionesBase.FuncionesBase.ValorRealInt(Me.Tx_ValorSaldo.Text), Me.Cu_CentroCosto1.IdCentroCosto,
                         estado, Me.Tx_Descripción.Text, Me.Tx_Observación.Text,
                        VariablesBase.VariablesBase.IdPersona,
                          Me.Cb_Categoría.SelectedValue, Tx_Alimentacion.Text, Tx_Alojamiento.Text, Tx_Incidental.Text, idlegalizacion)
        Guardar_comprobantes(idlegalizacion)
        Guardar_Concepto(idlegalizacion)
    End Sub

    Private Sub Guardar_comprobantes(ByRef IdLegalizacion As Long)
        Dim adap_Comprobante As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_COMPROBANTETableAdapter
        adap_Comprobante.Delete(IdLegalizacion)
        For i = 0 To Dgv_Comprobante.RowCount - 1
            adap_Comprobante.Insert(IdLegalizacion, Me.Dgv_Comprobante.Rows(i).Cells("CODIGOTIPOCOMPROBANTEDataGridViewTextBoxColumn").Value, Me.Dgv_Comprobante.Rows(i).Cells("NUMEROCOMPROBANTEDataGridViewTextBoxColumn").Value)
        Next
    End Sub

    Private Sub Guardar_Concepto(ByRef IdLegalizacion As Long)
        Dim ada_concepto As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_CONCEPTOADICIONALLEGALIZACIONTableAdapter
        ada_concepto.Delete(IdLegalizacion)
        For i = 0 To Dgv_Conceptos.RowCount - 1
            ada_concepto.Insert(FuncionesBase.FuncionesBase.Siguiente("CONCEPTOADICIONAL"), IdLegalizacion, Me.Dgv_Conceptos.Rows(i).Cells("CODIGOCONCEPTOADICIONALDataGridViewTextBoxColumn").Value, Me.Dgv_Conceptos.Rows(i).Cells("VALORDataGridViewTextBoxColumn").Value, Me.Dgv_Conceptos.Rows(i).Cells("CANTIDADDIAS").Value)
        Next
    End Sub

    Private Function Validar_Legalización() As Boolean
        'Validar fecha OJO CESAR, enviar un mensaje de alerta cuando la fecha de la legalización
        'sea diferente en año a la fecha actual, porque cambiaria el consecutivo que se lleva por año
        Dim message, title As String
        Dim consecutivo As String = ValorConsecutivoAsignado
        Dim Asignadoconsecutivo As String
        Dim thisDate As Date
        Dim thisYear As Integer
        thisDate = Date.Now
        thisYear = Year(thisDate)
        If FuncionesBase.FuncionesBase.ExisteConsecutivo(consecutivo) = True Then
            message = "El consecutivo actual es: " & CStr(consecutivo) & " ¿Ingrese y acepte nuevo consecutivo?"
            title = "Consecutivo"
            Asignadoconsecutivo = InputBox(message, title, consecutivo)
            If IsNumeric(Asignadoconsecutivo) = False Then
                If Asignadoconsecutivo = "" Then
                    MsgBox("el consecutivo " & consecutivo & " Ya fue asignado a una legalización.")
                    Validar_Legalización = False
                    Exit Function
                Else
                    Dim msg1 = "No es valor para un consecutivo: " & Asignadoconsecutivo
                    Dim title1 = "Advertencia"
                    Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                    Dim response1 = MsgBox(msg1, style1, title1)
                    Validar_Legalización = False
                    Exit Function
                End If
            Else
                ValorConsecutivoAsignado = Asignadoconsecutivo
                Cu_Auditoria.ValorConsecutivoAsignado = ValorConsecutivoAsignado
                Validar_Legalización = False
                Me.Lb_Consecutivo.Text = "Consecutivo: " & CStr(ValorConsecutivoAsignado)
                Exit Function
            End If
        End If
        If Tx_IdentificaciónPersona.Text = "" Then
            MsgBox("Cargue la persona.", MsgBoxStyle.Information, "Seleccione Persona")
            Tx_IdentificaciónPersona.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If IdpersonaLegalización = -1 Then
            MsgBox("Debe seleccionar la persona que desea asociar la legalización.", MsgBoxStyle.Information, "Seleccione Persona")
            Validar_Legalización = False
            Exit Function
        End If
        If Me.Cb_Categoría.SelectedIndex = -1 Then
            MsgBox("Falta seleccionar la categoría.", MsgBoxStyle.Information, "Seleccionar Categoría")
            Cb_Categoría.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Me.Cb_Cargo.SelectedIndex = -1 Then
            MsgBox("Falta seleccionar el cargo.", MsgBoxStyle.Information, "Seleccionar Cargo")
            Me.Cb_Cargo.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Me.Cb_Grupo.SelectedIndex = -1 Then
            MsgBox("Falta seleccionar el grupo.", MsgBoxStyle.Information, "Seleccionar Grupo")
            Cb_Grupo.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Me.Cb_TipoLegalización.SelectedIndex = -1 Then
            MsgBox("Falta seleccionar el tipo.", MsgBoxStyle.Information, "Seleccionar Tipo")
            Cb_TipoLegalización.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Me.Cb_TipoLegalización.SelectedIndex <> -1 Then
            If Me.Tx_ValorViatico.Text = "" Then
                Me.Tx_ValorViatico.Text = 0
                Me.Tx_Alimentacion.Text = 0
                Me.Tx_Alojamiento.Text = 0
                Me.Tx_Incidental.Text = 0
            End If
            If IsNumeric(Tx_ValorViatico.Text) = False Then
                MsgBox("Valor de viatico debe ser numerico.", MsgBoxStyle.Information, "Agregar Valor Viatico")
                Tx_ValorViatico.Focus()
                Validar_Legalización = False
                Exit Function
            End If
            If Me.Tx_ValorViatico.Text < 0 Then
                MsgBox("Falta el valor del viático.", MsgBoxStyle.Information, "Agregar Valor Viático")
                Tx_ValorViatico.Focus()
                Validar_Legalización = False
                Exit Function
            End If
        End If
        If Me.Cb_Estado.SelectedIndex = -1 Then
            MsgBox("Seleccione el estado", MsgBoxStyle.Information, "Estado")
            Cb_Estado.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Format(Me.DTP_FechaDesde.Value, "yyyy-MM-dd") > Format(Me.DTP_FechaHasta.Value, "yyyy-MM-dd") Then
            MsgBox("Fecha ""Desde"" no puede ser superior a la fecha ""Hasta"".", MsgBoxStyle.Information, "Error en fecha")
            DTP_FechaDesde.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Not Editando Then
            Dim dtLegalizacionesFechas As DataTable = ExisteLegalizacionEntreFechas()
            If dtLegalizacionesFechas.Rows.Count > 0 Then
                Dim texto As New StringBuilder()
                If dtLegalizacionesFechas.Rows.Count <= 1 Then
                    Dim dr As DataRow = dtLegalizacionesFechas.Rows(0)
                    texto.AppendLine("Las fechas coinciden con las de la legalización " & dr.Item("CONSECUTIVO") & ": desde " & DirectCast(dr.Item("FECHADESDE"), Date).ToShortDateString & " hasta " & DirectCast(dr.Item("FECHAHASTA"), Date).ToShortDateString & ".")
                Else
                    texto.AppendLine("Las fechas coinciden con las de las legalizaciones:")
                    For Each dr As DataRow In dtLegalizacionesFechas.Rows
                        texto.AppendLine("•   " & dr.Item("CONSECUTIVO") & ": desde " & DirectCast(dr.Item("FECHADESDE"), Date).ToShortDateString & " hasta " & DirectCast(dr.Item("FECHAHASTA"), Date).ToShortDateString & ".")
                    Next
                End If
                If MessageBox.Show(texto.ToString & Environment.NewLine & "¿Desea continuar?", "Fechas de legalizaciones existentes", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    DTP_FechaDesde.Focus()
                    Validar_Legalización = False
                    Exit Function
                End If
            End If
        End If
        If Me.Cb_TipoSaldo.SelectedIndex = -1 Then
            MsgBox("Debe Seleccionar un tipo de saldo", MsgBoxStyle.Information, "Tipo Saldo")
            Cb_TipoSaldo.Focus()
            Validar_Legalización = False
            Exit Function
        End If
        If Me.Cb_TipoSaldo.SelectedIndex <> -1 Then
            If Me.Tx_ValorSaldo.Text = "" Then
                Me.Tx_ValorSaldo.Text = 0
            End If
            If IsNumeric(Tx_ValorViatico.Text) = False Then
                MsgBox("Valor de saldo debe ser numérico.", MsgBoxStyle.Information, "Tipo Saldo")
                Tx_ValorViatico.Focus()
                Validar_Legalización = False
                Exit Function
            End If
            If Me.Tx_ValorSaldo.Text < 0 Then
                MsgBox("Agrege un valor al saldo", MsgBoxStyle.Information, "Tipo Saldo")
                Tx_ValorSaldo.Focus()
                Validar_Legalización = False
                Exit Function
            End If
        End If
        Validar_Legalización = True
    End Function

    Private Function ExisteLegalizacionEntreFechas() As DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM SC_VerificarFechasLegalizacion(@IDPERSONA, @FECHADESDE, @FECHAHASTA)", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", IdpersonaLegalización)
        comando.Parameters.AddWithValue("@FECHADESDE", DTP_FechaDesde.Value)
        comando.Parameters.AddWithValue("@FECHAHASTA", DTP_FechaHasta.Value)
        Dim dtLegalizaciones As New DataTable
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dtLegalizaciones)
            Return dtLegalizaciones
        Catch
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Private Sub Tx_IdentificaciónPersona_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Tx_IdentificaciónPersona.KeyPress
        If IsNumeric(Tx_IdentificaciónPersona.Text) = False Then
            Tx_IdentificaciónPersona.Text = ""
        End If
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            CargarPersona()
            Cb_Categoría.Focus()
        End If
    End Sub

    Private Sub Tx_IdentificaciónPersona_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Tx_IdentificaciónPersona.LostFocus
        'Cargar persona
        If Editando = False Then
            CargarPersona()
        End If
    End Sub

    Private Sub CargarPersona()
        Me.Cb_Categoría.SelectedIndex = -1
        Me.Cb_Cargo.SelectedIndex = 0 ' = -1
        Me.Cb_Grupo.SelectedIndex = -1
        Tx_IdentificaciónPersona.Text = Trim(Replace(Replace(Tx_IdentificaciónPersona.Text, ".", ""), ",", ""))
        If FuncionesBase.FuncionesBase.ConsultarIdPersona(Me.Tx_IdentificaciónPersona.Text) <> -1 Then
            Me.Tx_NombrePersona.Text = FuncionesBase.FuncionesBase.ConsultarNombrePersona(Me.Tx_IdentificaciónPersona.Text)
            Me.IdpersonaLegalización = FuncionesBase.FuncionesBase.ConsultarIdPersona(Me.Tx_IdentificaciónPersona.Text)

            Me.ContratoTableAdapter.Fill(Ds_Auditoria.CONTRATO, Trim(Me.Tx_IdentificaciónPersona.Text))
            If Me.Ds_Auditoria.CONTRATO.Count > 0 Then
                Fila_Contrato = Me.Ds_Auditoria.CONTRATO(0)
                Me.Cb_Categoría.SelectedValue = Fila_Contrato("CODIGOTIPOCATEGORIA")
                Me.Cb_Cargo.SelectedValue = Fila_Contrato("CODIGOTIPOCARGO")
                Me.Cb_Grupo.SelectedValue = Fila_Contrato("CODIGOTIPOGRUPO")
            End If
        Else
            Me.Tx_NombrePersona.Text = ""
            Me.IdpersonaLegalización = -1
        End If
    End Sub

    Private Sub Bt_AgregarComprobante_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_AgregarComprobante.Click
        AgregarComprobante()
        Cb_TipoComprobante.Focus()
    End Sub

    Private Sub Tx_NumeroComprobante_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Tx_NumeroComprobante.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            AgregarComprobante()
            Cb_TipoComprobante.Focus()
        End If
    End Sub

    Private Sub AgregarComprobante()
        If Me.Cb_TipoComprobante.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de comprobante")
            Me.Cb_TipoComprobante.Focus()
            Exit Sub
        End If
        Me.Tx_NumeroComprobante.Text = Replace(Replace(Trim(Me.Tx_NumeroComprobante.Text), ".", ""), ",", "")
        If Me.Tx_NumeroComprobante.Text = "" Then
            MsgBox("Se debe digitar el número de comprobante")
            Me.Tx_NumeroComprobante.Focus()
            Exit Sub
        End If
        If IsNumeric(Me.Tx_NumeroComprobante.Text) = False Then
            MsgBox("El número de comprobante debe ser numérico")
            Me.Tx_NumeroComprobante.Focus()
            Exit Sub
        End If
        If Me.Tx_NumeroComprobante.Text < 0 Then
            MsgBox("El número de comprobante debe ser un valor positivo")
            Me.Tx_NumeroComprobante.Focus()
            Exit Sub
        End If
        If CInt(Tx_NumeroComprobante.Text) > 0 AndAlso ExisteComprobante(Cb_TipoComprobante.SelectedValue, Tx_NumeroComprobante.Text) Then
            Dim texto As New StringBuilder()
            If dtComprobante.Rows.Count <= 1 Then
                Dim dr As DataRow = dtComprobante.Rows(0)
                texto.AppendLine("El comprobante " & Me.Cb_TipoComprobante.Text & " con número " & Me.Tx_NumeroComprobante.Text & " se registró en la legalización " & dr.Item("CONSECUTIVO") & " de " & dr.Item("AÑO") & ".")
            Else
                texto.AppendLine("El comprobante " & Me.Cb_TipoComprobante.Text & " con número " & Me.Tx_NumeroComprobante.Text & " se registró en las legalizaciones:")
                For Each dr As DataRow In dtComprobante.Rows
                    texto.AppendLine("•   " & dr.Item("CONSECUTIVO") & " de " & dr.Item("AÑO") & ".")
                Next
            End If
            If MsgBox(texto.ToString & Environment.NewLine & "¿Desea continuar?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If ComprobanteRegistrado() = False Then
            Exit Sub
        End If
        'Agregar Nuevo comprobante local
        Dim Fila As DataRow
        Fila = Ds_Auditoria.COMPROBANTE.NewRow
        Fila("CODIGOTIPOCOMPROBANTE") = Me.Cb_TipoComprobante.SelectedValue
        Fila("ABREVIATURATIPOCOMPROBANTE") = Me.Cb_TipoComprobante.Text
        Fila("NUMEROCOMPROBANTE") = Me.Tx_NumeroComprobante.Text
        Fila("NOMBRETIPOCOMPROBANTE") = Me.Cb_NombreComprobante.Text
        Ds_Auditoria.COMPROBANTE.Rows.Add(Fila)
        Cb_TipoComprobante.SelectedIndex = -1
        Me.Tx_NumeroComprobante.Text = ""
    End Sub

    Private Function ExisteComprobante(codigoComprobante As Integer, numeroComprobante As Integer) As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM SC_ListarComprobanteLegalizacion(@CodigoComprobante, @NumeroComprobante)", conexion)
        comando.Parameters.AddWithValue("@CodigoComprobante", codigoComprobante)
        comando.Parameters.AddWithValue("@NumeroComprobante", numeroComprobante)
        Dim adaptador As New SqlDataAdapter(comando)
        dtComprobante = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtComprobante)
            conexion.Close()
            If dtComprobante.Rows.Count > 0 Then
                ExisteComprobante = True
            Else
                ExisteComprobante = False
            End If
        Catch
            ExisteComprobante = False
        Finally
            conexion.Close()
        End Try
    End Function

    Private Function ComprobanteRegistrado() As Boolean
        Dim Registrado As Boolean = True
        ComprobanteRegistrado = True
        For i = 0 To Dgv_Comprobante.RowCount - 1
            If Cb_TipoComprobante.Text = Me.Dgv_Comprobante.Rows(i).Cells("ABREVIATURATIPOCOMPROBANTEDataGridViewTextBoxColumn").Value And Tx_NumeroComprobante.Text = Me.Dgv_Comprobante.Rows(i).Cells("NUMEROCOMPROBANTEDataGridViewTextBoxColumn").Value Then
                Dim response = MsgBox("Este comprobante ya fue agregado. ¿Desea volver agregar?", MsgBoxStyle.YesNo, "Advertencia")
                If response = MsgBoxResult.Yes Then
                    Registrado = True
                Else
                    Registrado = False
                End If
            End If
        Next
        Return ComprobanteRegistrado = Registrado
    End Function

    Private Sub AgregarConceptos()
        If Me.Cb_TipoConcepto.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo")
            Me.Cb_TipoComprobante.Focus()
            Exit Sub
        End If
        If Me.Cb_Concepto.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el concepto")
            Me.Cb_TipoComprobante.Focus()
            Exit Sub
        End If
        Me.Tx_ValorConcepto.Text = Replace(Replace(Trim(Me.Tx_ValorConcepto.Text), ".", ""), ",", "")
        If Me.Tx_ValorConcepto.Text = "" Then
            MsgBox("Se debe digitar el valor")
            Me.Tx_ValorConcepto.Focus()
            Exit Sub
        End If
        If IsNumeric(Me.Tx_ValorConcepto.Text) = False Then
            MsgBox("El valor debe ser numérico")
            Me.Tx_ValorConcepto.Focus()
            Exit Sub
        End If
        If Me.Tx_ValorConcepto.Text < 0 Then
            MsgBox("El valor debe ser positivo")
            Me.Tx_ValorConcepto.Focus()
            Exit Sub
        End If
        If IsNumeric(Me.Tb_Dias.Text) = False Then
            MsgBox("Agregue cantidad de días")
            Me.Tb_Dias.Focus()
            Exit Sub
        End If
        'Agregar nuevo concepto
        Dim Fila As DataRow
        Fila = Ds_Auditoria.CONCEPTO.NewRow
        Fila("CODIGOCONCEPTOADICIONAL") = Me.Cb_Concepto.SelectedValue
        Fila("NOMBRECONCEPTOADICIONAL") = Me.Cb_Concepto.Text
        Fila("CODIGOTIPOCONCEPTOADICIONAL") = Me.Cb_TipoConcepto.SelectedValue
        Fila("NOMBRETIPOCONCEPTOADICIONAL") = Me.Cb_TipoConcepto.Text
        Fila("VALOR") = FuncionesBase.FuncionesBase.ValorRealInt(Me.Tx_ValorConcepto.Text)
        Fila("CANTIDADDIAS") = Me.Tb_Dias.Text
        Ds_Auditoria.CONCEPTO.Rows.Add(Fila)
        Cb_Concepto.SelectedValue = 1
        Me.Tx_ValorConcepto.Text = ""
        Me.Tb_Dias.Text = ""
    End Sub

    Private Sub Bt_AgregarConcepto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_AgregarConcepto.Click
        AgregarConceptos()
    End Sub

    Private Sub Bt_EliminarComprobante_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_EliminarComprobante.Click
        If Dgv_Comprobante.Rows.Count = 0 Then
            MsgBox("No existen comprobantes")
        Else
            Me.Dgv_Comprobante.Rows.Remove(Me.Dgv_Comprobante.Rows(Dgv_Comprobante.CurrentRow.Index))
        End If
    End Sub

    Private Sub Bt_EliminarConcepto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_EliminarConcepto.Click
        If Dgv_Conceptos.Rows.Count = 0 Then
            MsgBox("No existen conceptos")
        Else
            Me.Dgv_Conceptos.Rows.Remove(Me.Dgv_Conceptos.Rows(Dgv_Conceptos.CurrentRow.Index))
        End If
    End Sub

    Private Sub Tx_IdentificaciónPersona_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Tx_IdentificaciónPersona.TextChanged
        Me.IdpersonaLegalización = -1
        Me.Tx_NombrePersona.Text = ""
    End Sub

    Private Sub Button_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Tb_Dias_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Tb_Dias.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            AgregarConceptos()
            Cb_TipoConcepto.Focus()
        End If
    End Sub

    Private Sub Tx_ValorConcepto_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Tx_ValorConcepto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Tb_Dias.Focus()
        End If
    End Sub

    Private Sub Cb_TipoComprobante_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_TipoComprobante.SelectedIndexChanged
        If Cb_TipoComprobante.Text = "NA" Then
            Tx_NumeroComprobante.Text = 0
        Else
            Tx_NumeroComprobante.Text = ""
        End If
        Tx_NumeroComprobante.Focus()
    End Sub

    Private Sub Cb_TipoLegalización_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_TipoLegalización.SelectedIndexChanged
        If Cb_TipoLegalización.SelectedValue = 1 Then
            Tx_ValorViatico.Enabled = True
            Me.Tx_Alimentacion.Enabled = True
            Me.Tx_Alojamiento.Enabled = True
            Me.Tx_Incidental.Enabled = True
        Else
            Tx_ValorViatico.Enabled = False
            Me.Tx_Alimentacion.Enabled = False
            Me.Tx_Alojamiento.Enabled = False
            Me.Tx_Incidental.Enabled = False
            Tx_ValorViatico.Text = "0"
            Me.Tx_Alimentacion.Text = "0"
            Me.Tx_Alojamiento.Text = "0"
            Me.Tx_Incidental.Text = "0"
            DTP_FechaDesde.Value = Now
            DTP_FechaHasta.Value = Now
        End If
    End Sub

    Private Sub DTP_FechaDesde_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DTP_FechaDesde.ValueChanged
        If Cb_TipoLegalización.SelectedValue = 1 Then 'GASTOS_VIAJE
            If FuncionesBase.FuncionesBase.ConsultarLegalizacionExistente(FuncionesBase.FuncionesBase.ConsultarIdPersona(Tx_IdentificaciónPersona.Text), DTP_FechaDesde.Value, "NULL", idlegalizacion, False) = True Then
                MsgBox("Ya existe una legalización con identificación " & Tx_IdentificaciónPersona.Text & " y fecha " & Format(DTP_FechaDesde.Value, "yyyy-MM-dd") & ". Consecutivo: " & FuncionesBase.FuncionesBase.ConsultarConsecutio_idpersonaFecha(FuncionesBase.FuncionesBase.ConsultarIdPersona(Tx_IdentificaciónPersona.Text), DTP_FechaDesde.Value, "NULL", idlegalizacion, False), MsgBoxStyle.Information, "Legalización")
            End If
        End If
    End Sub

    Private Sub TextBox_Salario_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Tx_ValorSaldo.KeyPress, Tx_Alimentacion.KeyPress, Tx_Alojamiento.KeyPress, Tx_Incidental.KeyPress
        Dim Caja As TextBox = sender
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub TextBox_Salario_Lostfocus(ByVal sender As Object, ByVal e As EventArgs) Handles Tx_ValorViatico.LostFocus, Tx_ValorSaldo.LostFocus, Tx_ValorConcepto.LostFocus, Tx_Alimentacion.LostFocus, Tx_Alojamiento.LostFocus, Tx_Incidental.LostFocus
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
        Catch
        End Try
    End Sub

    Private Sub Bt_BuscarPersona_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_BuscarPersona.Click
        Dim frBuscarPersona As New FormulariosClasesBase.Fr_BuscarPersona
        frBuscarPersona.Cargar_Tabla("P")
        frBuscarPersona.ShowDialog()
        Dim IdpersonaBuscar As String = frBuscarPersona.IdPersona
        Tx_IdentificaciónPersona.Text = FuncionesBase.FuncionesBase.ConsultaridentificacionPersona(IdpersonaBuscar)
        Tx_IdentificaciónPersona.Focus()
    End Sub

    Private Sub Calcularvalorviatico_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Tx_Alimentacion.LostFocus, Tx_Alojamiento.LostFocus, Tx_Incidental.LostFocus
        CalcularValorViatico()
    End Sub

    Private Sub CalcularValorViatico()
        If IsNumeric(Tx_Alimentacion.Text) = False Then
            If Tx_Alimentacion.Text = "" Then
                MsgBox("Valor Alimentación debe ser numérico", MsgBoxStyle.Critical, "Valor alimentación")
                Me.Tx_Alimentacion.Focus()
                Exit Sub
            End If
        End If
        If IsNumeric(Tx_Incidental.Text) = False Then
            If Tx_Alimentacion.Text = "" Then
                MsgBox("Valor Incidental debe ser numérico", MsgBoxStyle.Critical, "Valor incidental")
                Me.Tx_Incidental.Focus()
                Exit Sub
            End If
        End If
        If IsNumeric(Tx_Alojamiento.Text) = False Then
            If Tx_Alimentacion.Text = "" Then
                MsgBox("Valor Alojamiento debe ser numérico", MsgBoxStyle.Critical, "Valor alojamiento")
                Me.Tx_Alojamiento.Focus()
                Exit Sub
            End If
        End If
        Tx_ValorViatico.Text = CStr((CDec(Trim(Tx_Alimentacion.Text)) + CDec(Trim(Tx_Alojamiento.Text)) + CDec(Trim(Tx_Incidental.Text))))
        Try
            Dim Caja As TextBox = Tx_ValorViatico
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
        Catch
        End Try
    End Sub
End Class