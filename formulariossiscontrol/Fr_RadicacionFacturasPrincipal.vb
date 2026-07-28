Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.ComponentModel

''' <summary>
''' 
''' </summary>
Public Class Fr_RadicacionFacturasPrincipal
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dtFacturasCorrespondencia As DataTable
    Private dtFacturacionElectronica As DataTable
    Private guardado As Boolean = False
    Private caracteresPermitidosNit As String = "0123456789" & Convert.ToChar(Keys.Back) & Convert.ToChar(Keys.Delete) & Convert.ToChar(Keys.Enter)
    Private valorNit As Nullable(Of Integer)
    Private cmVacio As New ContextMenu
    Private formularioCargado As Boolean = False

    ' 
    Private Sub Fr_RadicacionFacturasPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dtp_FechaDesde.MaxDate = DateTime.Today
        Dtp_FechaHasta.MaxDate = DateAdd(DateInterval.Day, 7, DateTime.Today)
        Dtp_FechaDesde.Value = DateAdd(DateInterval.Day, -1, DateTime.Today)
        Tx_Nit.ContextMenu = cmVacio
        formularioCargado = True
    End Sub


    ' 
    Private Sub Dtp_FechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaDesde.ValueChanged
        Dtp_FechaHasta.MinDate = Dtp_FechaDesde.Value
        ReiniciarTemporizador()
    End Sub


    Private Sub Dtp_FechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaHasta.ValueChanged
        ReiniciarTemporizador()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarFacturasCorrespondencia()
        If Not IsNothing(Dgv_Listado.DataSource) Then
            Dgv_Listado.DataSource.Clear()
        End If
        comando = New SqlCommand("SELECT * FROM SC_RadicacionFacturasContabilidad(@FECHAI, @FECHAF, @PENDIENTESRADICAR, @NIT, @DE, @NUMERODOCUMENTO)", conexion)
        comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaDesde.Value)
        comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaHasta.Value)
        comando.Parameters.AddWithValue("@PENDIENTESRADICAR", If(Ck_PendientesRadicar.Checked, "N", "S")) 'RADICADOCONTABILIDAD
        comando.Parameters.AddWithValue("@NIT", If(IsNothing(valorNit), DBNull.Value, valorNit))
        comando.Parameters.AddWithValue("@DE", Trim(Tx_Proveedor.Text))
        comando.Parameters.AddWithValue("@NUMERODOCUMENTO", Trim(Tx_Factura.Text))
        adaptador = New SqlDataAdapter(comando)
        dtFacturasCorrespondencia = New DataTable()
        Try
            conexion.Open()
            adaptador.Fill(dtFacturasCorrespondencia)
            conexion.Close()
            If dtFacturasCorrespondencia.Rows.Count > 0 Then
                Dgv_Listado.DataSource = dtFacturasCorrespondencia
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarFacturacionElectronica()
        If Not IsNothing(Dgv_FacturaElectronica.DataSource) Then
            Dgv_FacturaElectronica.DataSource.Clear()
        End If
        comando = New SqlCommand("SELECT * FROM SC_RadicaFacturaElectronicaContabilidad(@FECHAI, @FECHAF, @PENDIENTESRADICAR, @NIT, @DE, @NUMERODOCUMENTO)", conexion)
        comando.Parameters.AddWithValue("@FECHAI", Dtp_FechaDesde.Value)
        comando.Parameters.AddWithValue("@FECHAF", Dtp_FechaHasta.Value)
        comando.Parameters.AddWithValue("@PENDIENTESRADICAR", If(Ck_PendientesRadicar.Checked, "N", "S")) 'RADICADOCONTABILIDAD
        comando.Parameters.AddWithValue("@NIT", If(IsNothing(valorNit), DBNull.Value, valorNit))
        comando.Parameters.AddWithValue("@DE", Trim(Tx_Proveedor.Text))
        comando.Parameters.AddWithValue("@NUMERODOCUMENTO", Trim(Tx_Factura.Text))
        adaptador = New SqlDataAdapter(comando)
        dtFacturacionElectronica = New DataTable()
        Try
            conexion.Open()
            adaptador.Fill(dtFacturacionElectronica)
            conexion.Close()
            If dtFacturacionElectronica.Rows.Count > 0 Then
                Dgv_FacturaElectronica.DataSource = dtFacturacionElectronica
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ReiniciarTemporizador()
        If formularioCargado Then
            Ti_AplicaFiltro.Stop()
            Ti_AplicaFiltro.Start()
        End If
    End Sub


    ' 
    Private Sub Ti_AplicaFiltro_Tick(sender As Object, e As EventArgs) Handles Ti_AplicaFiltro.Tick
        Ti_AplicaFiltro.Stop()
        Filtrar()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Filtrar()
        CargarFacturasCorrespondencia()
        Tp_CorrespRecibida.Text = "Correspondencia Recibida (" & dtFacturasCorrespondencia.Rows.Count & ")"
        CargarFacturacionElectronica()
        Tp_FacturaElectronica.Text = "Facturación Electrónica (" & dtFacturacionElectronica.Rows.Count & ")"
        If dtFacturasCorrespondencia.Rows.Count > 0 OrElse dtFacturacionElectronica.Rows.Count > 0 Then
            Bt_LimpiarMarcas.Enabled = True
            Bt_Guardar.Enabled = True
        Else
            Bt_LimpiarMarcas.Enabled = False
            Bt_Guardar.Enabled = False
            'MessageBox.Show("No se encontraron documentos que cumplan con los criterios seleccionados.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' 
    Private Sub Bt_BorrarFiltro_Click(sender As Object, e As EventArgs) Handles Bt_BorrarFiltro.Click
        BorrarFiltro()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub BorrarFiltro()
        If Not guardado Then
            If Not ContinuarPorCambios() Then
                Exit Sub
            End If
        End If
        dtFacturasCorrespondencia.Clear()
        Tp_CorrespRecibida.Text = "Correspondencia Recibida"
        dtFacturacionElectronica.Clear()
        Tp_FacturaElectronica.Text = "Facturación Electrónica"
        Tx_Nit.Text = ""
        valorNit = Nothing
        Tx_Proveedor.Text = ""
        Tx_Factura.Text = ""
        Ck_PendientesRadicar.Checked = True
        Dtp_FechaDesde.Select()
        Bt_LimpiarMarcas.Enabled = False
        Bt_Guardar.Enabled = False
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ExistenCambios() As Boolean
        If Not IsNothing(Dgv_Listado.DataSource) AndAlso Not IsNothing(Dgv_FacturaElectronica.DataSource) Then
            Dim tempCantRegistros As Integer = 0
            tempCantRegistros += dtFacturasCorrespondencia.Select(Col_MarcarRadicado.DataPropertyName & " = '" & Col_MarcarRadicado.TrueValue & "'").Length
            tempCantRegistros += dtFacturacionElectronica.Select(Col_FE_MarcarRadicado.DataPropertyName & " = '" & Col_FE_MarcarRadicado.TrueValue & "'").Length
            Return (tempCantRegistros > 0)
        Else
            Return False
        End If
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ContinuarPorCambios() As Boolean
        If ExistenCambios() Then
            Dim dr As DialogResult
            dr = MessageBox.Show("Se han realizado modificaciones" & Environment.NewLine & "¿Desea descartar los cambios?", "Cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Return dr = Windows.Forms.DialogResult.Yes
        Else
            Return True
        End If
    End Function


    ' 
    Private Sub Bt_LimpiarMarcas_Click(sender As Object, e As EventArgs) Handles Bt_LimpiarMarcas.Click
        For Each drCorrespondencia As DataRow In dtFacturasCorrespondencia.Rows
            drCorrespondencia.Item(Col_MarcarRadicado.DataPropertyName) = Col_MarcarRadicado.FalseValue
        Next
        For Each drFacturaElectronica As DataRow In dtFacturacionElectronica.Rows
            drFacturaElectronica.Item(Col_FE_MarcarRadicado.DataPropertyName) = Col_FE_MarcarRadicado.FalseValue
        Next
    End Sub


    ' 
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        GuardarRadicado()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GuardarRadicado()
        Dim dtRadicadoCorrespondencia As New DataTable
        Dim dtRadicadoFacturaElectronica As New DataTable

        dtRadicadoCorrespondencia.Columns.Add("IDRECEPCION")
        dtRadicadoFacturaElectronica.Columns.Add("IDRECEPCION")

        If dtFacturasCorrespondencia.Rows.Count > 0 Then
            Dim dr As DataRow()
            dr = dtFacturasCorrespondencia.Select(Col_MarcarRadicado.DataPropertyName & " = '" & Col_MarcarRadicado.TrueValue & "'")
            If dr.Length > 0 Then
                dtRadicadoCorrespondencia = dr.CopyToDataTable().DefaultView.ToTable(False, Col_IdRecepcion.DataPropertyName)
            End If
        End If
        If dtFacturacionElectronica.Rows.Count > 0 Then
            Dim dr As DataRow()
            dr = dtFacturacionElectronica.Select(Col_FE_MarcarRadicado.DataPropertyName & " = '" & Col_FE_MarcarRadicado.TrueValue & "'")
            If dr.Length > 0 Then
                dtRadicadoFacturaElectronica = dr.CopyToDataTable().DefaultView.ToTable(False, Col_FE_IdAprobacion.DataPropertyName)
            End If
        End If
        comando = New SqlCommand("dbo.MarcarSC_RadicadoContabilidad", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TablaRADICADO", dtRadicadoCorrespondencia)
        comando.Parameters.AddWithValue("@TablaFE_RADICADO", dtRadicadoFacturaElectronica)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            conexion.Close()
        End Try
        MessageBox.Show("Cambios guardados.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        guardado = True
        BorrarFiltro()
        Filtrar()
    End Sub


    '
    Private Sub Tx_Radicacion_TextChanged(sender As Object, e As EventArgs) Handles Tx_Proveedor.TextChanged, Tx_Factura.TextChanged
        ReiniciarTemporizador()
    End Sub


    '
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If ContinuarPorCambios() Then
            Close()
        End If
    End Sub


    ' 
    Private Sub Cms_OpcionesListado_Opening(sender As Object, e As CancelEventArgs) Handles Cms_OpcionesListado.Opening
        Select Case Tc_ListadoFacturacion.SelectedTab.Name
            Case Tp_CorrespRecibida.Name
                Tsmi_EditarValor.Visible = True
                Tss_Separador1.Visible = True
                If Not IsNothing(Dgv_Listado.DataSource) AndAlso Dgv_Listado.DataSource.Rows.Count > 0 Then
                    Tsmi_DesmarcarSeleccionadas.Enabled = True
                    Tsmi_MarcarSeleccionadas.Enabled = True
                    Tsmi_EditarValor.Enabled = True
                Else
                    Tsmi_DesmarcarSeleccionadas.Enabled = False
                    Tsmi_MarcarSeleccionadas.Enabled = False
                    Tsmi_EditarValor.Enabled = False
                End If
            Case Tp_FacturaElectronica.Name
                Tsmi_EditarValor.Visible = False
                Tss_Separador1.Visible = False
                If Not IsNothing(Dgv_FacturaElectronica.DataSource) AndAlso Dgv_FacturaElectronica.DataSource.Rows.Count > 0 Then
                    Tsmi_DesmarcarSeleccionadas.Enabled = True
                    Tsmi_MarcarSeleccionadas.Enabled = True
                Else
                    Tsmi_DesmarcarSeleccionadas.Enabled = False
                    Tsmi_MarcarSeleccionadas.Enabled = False
                End If
        End Select
    End Sub


    ' 
    Private Sub Tsmi_MarcarSeleccionadas_Click(sender As Object, e As EventArgs) Handles Tsmi_MarcarSeleccionadas.Click
        Select Case Tc_ListadoFacturacion.SelectedTab.Name
            Case Tp_CorrespRecibida.Name
                For Each row As DataGridViewRow In Dgv_Listado.SelectedRows
                    For Each dr As DataRow In dtFacturasCorrespondencia.Rows
                        If dr.Item(Col_IdRecepcion.DataPropertyName) = row.Cells(Col_IdRecepcion.Name).Value Then
                            dr.Item(Col_MarcarRadicado.DataPropertyName) = Col_MarcarRadicado.TrueValue
                        End If
                    Next
                Next
            Case Tp_FacturaElectronica.Name
                For Each row As DataGridViewRow In Dgv_FacturaElectronica.SelectedRows
                    For Each dr As DataRow In dtFacturacionElectronica.Rows
                        If dr.Item(Col_FE_IdAprobacion.DataPropertyName) = row.Cells(Col_FE_IdAprobacion.Name).Value Then
                            dr.Item(Col_FE_MarcarRadicado.DataPropertyName) = Col_FE_MarcarRadicado.TrueValue
                        End If
                    Next
                Next
        End Select
    End Sub


    ' 
    Private Sub Tsmi_DesmarcarSeleccionadas_Click(sender As Object, e As EventArgs) Handles Tsmi_DesmarcarSeleccionadas.Click
        Select Case Tc_ListadoFacturacion.SelectedTab.Name
            Case Tp_CorrespRecibida.Name
                For Each row As DataGridViewRow In Dgv_Listado.SelectedRows
                    For Each dr As DataRow In dtFacturasCorrespondencia.Rows
                        If dr.Item(Col_IdRecepcion.DataPropertyName) = row.Cells(Col_IdRecepcion.Name).Value Then
                            dr.Item(Col_MarcarRadicado.DataPropertyName) = Col_MarcarRadicado.FalseValue
                        End If
                    Next
                Next
            Case Tp_FacturaElectronica.Name
                For Each row As DataGridViewRow In Dgv_FacturaElectronica.SelectedRows
                    For Each dr As DataRow In dtFacturacionElectronica.Rows
                        If dr.Item(Col_FE_IdAprobacion.DataPropertyName) = row.Cells(Col_FE_IdAprobacion.Name).Value Then
                            dr.Item(Col_FE_MarcarRadicado.DataPropertyName) = Col_FE_MarcarRadicado.FalseValue
                        End If
                    Next
                Next
        End Select
    End Sub


    '
    Private Sub Tsmi_EditarValor_Click(sender As Object, e As EventArgs) Handles Tsmi_EditarValor.Click
        Dim posActual As Integer = -1
        Dim idRecepcion As Integer = -1
        Dim nroDocumento As String = ""
        Dim valorActual As Decimal = 0
        Dim valorNuevoStr As String = ""
        Dim valorNuevoDec As Decimal = 0
        posActual = Dgv_Listado.SelectedRows(0).Index
        idRecepcion = Dgv_Listado.SelectedRows(0).Cells(Col_IdRecepcion.Name).Value
        nroDocumento = Dgv_Listado.SelectedRows(0).Cells(Col_Consecutivo.Name).Value
        valorActual = Dgv_Listado.SelectedRows(0).Cells(Col_Valor.Name).Value
        valorNuevoStr = InputBox("Ingrese el valor del documento con número " & nroDocumento, "Modificar valor de documento", valorActual.ToString)
        If Trim(valorNuevoStr) <> "" Then
            valorNuevoDec = FuncionesBase.FuncionesBase.ValorRealDec(valorNuevoStr)
            If valorNuevoDec > 0 Then
                comando = New SqlCommand("CambiarSC_ValorCorrespondenciaRecibida", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@IDRECEPCION", idRecepcion)
                comando.Parameters.AddWithValue("@VALOR", valorNuevoDec)
                comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    conexion.Close()
                    BorrarFiltro()
                    Filtrar()
                    Dgv_Listado.ClearSelection()
                    If posActual < Dgv_Listado.Rows.Count Then
                        Dgv_Listado.Rows(posActual).Selected = True
                        Dgv_Listado.FirstDisplayedScrollingRowIndex = Dgv_Listado.SelectedRows(0).Index
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conexion.Close()
                End Try
            Else
                MessageBox.Show("Se ingresó un valor inválido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se modificó el valor del documento.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    '
    Private Sub Dgv_MouseDown(sender As Object, e As MouseEventArgs) Handles Dgv_Listado.MouseDown, Dgv_FacturaElectronica.MouseDown
        Dim dgv As DataGridView = sender
        If e.Button = MouseButtons.Right Then
            Dim hit = dgv.HitTest(e.X, e.Y)
            dgv.ClearSelection()
            dgv.Rows(hit.RowIndex).Selected = True
        End If
    End Sub


    '
    Private Sub Tx_Nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Nit.KeyPress
        If Not caracteresPermitidosNit.Contains(e.KeyChar) Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then 'Retira el caractér "." que tiene un código equivalente a "Keys.Delete".
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub Tx_Radicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Nit.KeyPress, Tx_Proveedor.KeyPress, Tx_Factura.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    '
    Private Sub Tx_Nit_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Nit.KeyDown
        If e.Control And e.KeyCode.ToString = "V" Then
            'Tx_Nit.Paste()
        ElseIf e.Control And e.KeyCode.ToString = "C" Then
            Tx_Nit.Copy()
        End If
    End Sub

    '
    Private Sub Tx_Nit_Validating(sender As Object, e As CancelEventArgs) Handles Tx_Nit.Validating
        Dim cadena As String = Tx_Nit.Text
        cadena = Trim(Regex.Replace(cadena, "[^0-9]", ""))
        If cadena <> "" Then
            valorNit = CInt(cadena)
        Else
            valorNit = Nothing
        End If
    End Sub

    '
    Private Sub Tx_Nit_Validated(sender As Object, e As EventArgs) Handles Tx_Nit.Validated
        If Not IsNothing(valorNit) Then
            Tx_Nit.Text = Format(valorNit, "N0")
        Else
            Tx_Nit.Text = ""
        End If
        ReiniciarTemporizador()
    End Sub

    '
    Private Sub Tx_Nit_Enter(sender As Object, e As EventArgs) Handles Tx_Nit.Enter
        If Not IsNothing(valorNit) Then
            Tx_Nit.Text = valorNit
        End If
        Tx_Nit.Select()
    End Sub

    Private Sub Ck_PendientesRadicar_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_PendientesRadicar.CheckedChanged
        ReiniciarTemporizador()
    End Sub

End Class