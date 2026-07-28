Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_Contratos

    Public Editando As Boolean = False
    Public IdContratos As Integer
    Private _guardado As Boolean = False
    Private IdDependencia As Integer
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Fila_Editar_Contratos As DataRow
    Private miles As String = Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator

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

        dsCargar = bddatos.CargarMaestrasSiscontrol(13, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdContratos, 2)

        Cb_AurorizaDctoSS.DataSource = dsCargar.Tables(1)
        Cb_AurorizaDctoSS.ValueMember = "CODIGO"
        Cb_AurorizaDctoSS.DisplayMember = "NOMBRE"
        Cb_AurorizaDctoSS.SelectedIndex = -1

        If Editando = True Then
            Fila_Editar_Contratos = dsCargar.Tables(0).Rows(0)
        Else
        End If
    End Sub

    Public Sub CargarDatosContratos()


        Dtp_Fecha.Value = Fila_Editar_Contratos("FECHACONTRATO")

        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Fila_Editar_Contratos("IDDEPENDENCIA")

        If Not IsDBNull(Fila_Editar_Contratos("NIT")) AndAlso Trim(Fila_Editar_Contratos("NIT")).Length > 0 Then
            Dim nit As Integer = FuncionesBase.FuncionesBase.ValorRealInt(Fila_Editar_Contratos("NIT"))
            If nit > 0 Then
                Tx_IdentificacionNIT.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(nit)
            End If
        End If

        Tx_Proveedor.Text = Fila_Editar_Contratos("PROVEEDOR")

        Tb_NroContrato.Text = Fila_Editar_Contratos("NROCONTRATO")

        Tb_NroFactura.Text = Fila_Editar_Contratos("NROFACTURA")

        Tb_ValorFactura.Text = Replace(CStr(Fila_Editar_Contratos("VALORFACTURA")), ".00", "")

        Cb_AurorizaDctoSS.SelectedValue = Fila_Editar_Contratos("AUTORIZADESCTSS")

        IdDependencia = Fila_Editar_Contratos("IDDEPENDENCIA")
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
            If ValidarContratos() Then
                GuardarContratos()
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

    Private Sub GuardarContratos()

        Dim Comando As New SqlClient.SqlCommand("GestionarContratosSiscontrol")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@IDCONTRATO", IdContratos)
        Comando.Parameters.AddWithValue("@FECHACONTRATO", Dtp_Fecha.Value)
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
        Comando.Parameters.AddWithValue("@NROCONTRATO", Trim(Tb_NroContrato.Text))
        Comando.Parameters.AddWithValue("@NROFACTURA", Trim(Tb_NroFactura.Text))
        Comando.Parameters.AddWithValue("@VALORFACTURA", CDec(Trim(Tb_ValorFactura.Text)))
        Comando.Parameters.AddWithValue("@AUTORIZADESCTSS", Cb_AurorizaDctoSS.SelectedValue)
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()

        conn.Close()

        Me.Close()

        MsgBox("Registro Guardado", MsgBoxStyle.Information, "GUARDADO")

        If Cb_AurorizaDctoSS.SelectedValue <> "X" Then
            If MsgBox("¿Desea subir el Documento de Autorización Descuentos de Seguridad Social?", MsgBoxStyle.YesNo, "SUBIR DOCUMENTO ICA-GRAL-F-193") = MsgBoxResult.Yes Then

                Dim FrArchivoSS As New FormulariosSisControl.Fr_ArchivoSS
                FrArchivoSS.CargarTablas()
                FrArchivoSS.Tipo = "CO"
                If Editando = True Then
                    FrArchivoSS.IdDocumento = IdContratos
                Else
                    FrArchivoSS.IdDocumento = msgParam.Value
                End If
                FrArchivoSS.ShowDialog()
            End If
        End If

    End Sub

    Private Function ValidarContratos() As Boolean

        If Tb_NroContrato.Text = "" Then
            MsgBox("Debe Agregar un Nro. de Contrato", MsgBoxStyle.Critical, "NRO. CONTRATO")
            ValidarContratos = False
            Tb_NroContrato.Focus()
            Exit Function
        End If

        'If Dtp_FechaVencimiento.Checked = False Then
        '    MsgBox("Seleccioné fecha de vencimiento", MsgBoxStyle.Critical, "FECHA VENCIMIENTO")
        '    ValidarCobro = False
        '    Dtp_FechaVencimiento.Focus()
        '    Exit Function
        'End If

        If Tb_NroFactura.Text = "" Then
            MsgBox("Debe Agregar un Nro. de Factura", MsgBoxStyle.Critical, "NRO. FACTURA")
            ValidarContratos = False
            Tb_NroFactura.Focus()
            Exit Function
        End If

        If IsNumeric(Tb_ValorFactura.Text) = False Then
            MsgBox("Agregue valor de la factura", MsgBoxStyle.Critical, "VALOR FACTURA")
            ValidarContratos = False
            Tb_ValorFactura.Text = ""
            Tb_ValorFactura.Focus()
            Exit Function
        End If

        If Trim(Tx_IdentificacionNIT.Text) = "" Then
            MsgBox("Debe seleccionar el Proveedor o Contratista.", MsgBoxStyle.OkOnly, "")
            Tx_IdentificacionNIT.Focus()
            Return False
        End If

        If Cb_AurorizaDctoSS.SelectedIndex < 0 Then
            MsgBox("Seleccione una opción de Autoriza Dcto SS", MsgBoxStyle.Information, "AUTORIZA DCTO SS")
            Cb_AurorizaDctoSS.Focus()
            ValidarContratos = False
            Exit Function
        End If

        ValidarContratos = True
    End Function

    Private Sub Bt_BuscarProveedor_Click(sender As Object, e As EventArgs) Handles Bt_BuscarProveedor.Click
        CargarProveedor()
    End Sub

    Public Sub CargarProveedor()
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
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Tb_ValorFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_ValorFactura.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tb_ValorFactura_LostFocus(sender As Object, e As EventArgs) Handles Tb_ValorFactura.LostFocus
        Dim Caja As TextBox = sender
        Dim Cadena As String = Replace(Caja.Text, "$", "")
        Cadena = Replace(Cadena, " ", "")
        Cadena = Replace(Cadena, miles, "")
        If Not IsNumeric(Cadena) Then
            Caja.BackColor = Drawing.Color.Salmon
        Else
            Caja.Text = Format(Cadena, "Currency")
            Caja.BackColor = Drawing.Color.White
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class