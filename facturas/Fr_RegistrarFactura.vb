Imports System.Data.SqlClient

Public Class Fr_RegistrarFactura

    Dim DsOrdenCompra As New DatosOrdenCompra.Ds_OrdenCompra
    Dim FilaProveedor As DataRow
    Public NumFactura As String = -1

    Private Sub Bt_BuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles Bt_BuscarProveedor.Click
        Dim FrBuscarProveedor As New OrdenCompra.Fr_BuscarProveedor
        FrBuscarProveedor.Cargar_Tabla()
        FrBuscarProveedor.ShowDialog()
        Try
            Me.Tx_Identificación.Text = FrBuscarProveedor.Identificacion
            Cargar_Proveedor()
        Catch ex As Exception
        End Try
    End Sub


    Public Sub Cargar_Proveedor()
        Me.Tx_Identificación.Text = Trim(Me.Tx_Identificación.Text)
        Dim PROVEEDORTableAdapter As New DatosOrdenCompra.Ds_OrdenCompraTableAdapters.PROVEEDORTableAdapter
        PROVEEDORTableAdapter.FillIDENTIFICACION(Me.DsOrdenCompra.PROVEEDOR, Me.Tx_Identificación.Text)
        If Me.DsOrdenCompra.PROVEEDOR.Rows.Count > 0 Then
            FilaProveedor = Me.DsOrdenCompra.PROVEEDOR.Rows(0)
            Me.Tx_DigVerificación.Text = Trim(FilaProveedor("DIGITOVERIFICACION"))
            If Trim(FilaProveedor("NOMBRE")) <> "" Then
                Me.Tx_NombreProveedor.Text = Trim(FilaProveedor("NOMBRE"))
            Else
                Me.Tx_NombreProveedor.Text = Trim(FilaProveedor("NOMBREPROVEEDOR"))
            End If
        Else
            Me.Tx_Identificación.Focus()
        End If
    End Sub

    Private Sub Tx_Identificación_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tx_Identificación.TextChanged
        LimpiarProveedor()
    End Sub

    Private Sub Tx_Identificación_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Tx_Identificación.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F3 Then
            Dim FrBuscarProveedor As New OrdenCompra.Fr_BuscarProveedor
            FrBuscarProveedor.Cargar_Tabla()
            FrBuscarProveedor.ShowDialog()
            Try
                Me.Tx_Identificación.Text = FrBuscarProveedor.Identificacion
                Cargar_Proveedor()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Tx_Identificación_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_Identificación.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Cargar_Proveedor()
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub LimpiarProveedor()
        FilaProveedor = Nothing
        Me.Tx_DigVerificación.Text = ""
        Me.Tx_NombreProveedor.Text = ""
    End Sub

    Public Editando As Boolean
    Public DocumentoEditando As Integer = -1

    Private Function validarfactura() As Boolean
        If Trim(Me.Tx_Identificación.Text) = "" Then
            MsgBox("Debe digitar la identificación del proveedor", MsgBoxStyle.Critical, "IDENTIFICACION")
            Me.Tx_Identificación.Focus()
            validarfactura = False
            Exit Function
        End If
        If IsNothing(FilaProveedor) Then
            MsgBox("Debe digitar el proveedor", MsgBoxStyle.Critical, "PROVEEDOR")
            Me.Tx_Identificación.Focus()
            validarfactura = False
            Exit Function
        End If

        If Trim(Me.Tx_Factura.Text) = "" Then
            MsgBox("Número de factura no valida", MsgBoxStyle.Critical, "Factura")
            validarfactura = False
            Exit Function
        End If
        If Trim(Me.Tx_ValorFactura.Text) = "" Then
            MsgBox("Valor de la factura no valida", MsgBoxStyle.Critical, "Valor Factura")
            validarfactura = False
            Exit Function
        End If

        If Me.Tx_ValorFactura.Text.IndexOf(".") <> -1 Then
            MsgBox("Valor de la factura no valida, el formaro es ########,##", MsgBoxStyle.Critical, "Valor Factura")
            validarfactura = False
            Exit Function
        End If
        Try
            Dim ValorFactura As Decimal
            ValorFactura = CDec(Me.Tx_ValorFactura.Text)
        Catch ex As Exception
            MsgBox("Valor de la factura no valida", MsgBoxStyle.Critical, "Valor Factura")
            validarfactura = False
        End Try


        validarfactura = True
    End Function

    Private Sub Bt_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Guardar.Click
        If Me.Dtp_FechaRadicadoPrincipal.Checked = True Then
            If Me.Dtp_FechaVencimiento.Checked = False Then
                MsgBox("Debe seleccionar la fecha de vencimiento de la factura. Favor seleccionar e intentar nuevamente", MsgBoxStyle.Critical, "Error:")
                Exit Sub
            End If
        ElseIf Me.Dtp_FechaRadicadoBase.Checked = False Then
            MsgBox("Debe seleccionar la fecha de radicado de la base o de la principal. Favor seleccionar e intentar nuevamente", MsgBoxStyle.Critical, "Error:")
            Exit Sub
        End If
        If validarfactura() = False Then
            Exit Sub
        End If
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarFacturaCompras")
        Comando.CommandType = CommandType.StoredProcedure
        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@IDDOCUMENTO", DocumentoEditando)
        Comando.Parameters.AddWithValue("@NUMERODOCUMENTOANTERIOR", Trim(Me.Tx_Factura.Text))

        Comando.Parameters.AddWithValue("@NUMERODOCUMENTO", Trim(Me.Tx_Factura.Text))
        Comando.Parameters.AddWithValue("@IDPROVEEDOR", FilaProveedor("IDPROVEEDOR"))
        If Dtp_FechaDocumento.Checked = False Then
            Comando.Parameters.AddWithValue("@FECHADOCUMENTO", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHADOCUMENTO", Dtp_FechaDocumento.Value)
        End If
        If Dtp_FechaVencimiento.Checked = False Then
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTO", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTO", Dtp_FechaVencimiento.Value)
        End If
        If Dtp_FechaRadicadoBase.Checked = False Then
            Comando.Parameters.AddWithValue("@FECHARADICADOBASE", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHARADICADOBASE", Dtp_FechaRadicadoBase.Value)
        End If
        If Dtp_FechaRadicadoPrincipal.Checked = False Then
            Comando.Parameters.AddWithValue("@FECHARADICADOPRINCIPAL", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHARADICADOPRINCIPAL", Dtp_FechaRadicadoPrincipal.Value)
        End If
        Dim ValorFactura As Decimal
        ValorFactura = CDec(Me.Tx_ValorFactura.Text)
        Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@VALORDOCUMENTO", ValorFactura)
        Comando.Parameters.AddWithValue("@OBSERVACION", Trim(Me.Tx_Observación.Text))
        Comando.Parameters.AddWithValue("@ANEXO", Trim(Me.Tx_Anexos.Text))

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim msgParamDOS As New SqlParameter("@IDMENSAJEEA", SqlDbType.NChar, 30)
        msgParamDOS.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParamDOS)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()

            If Comando.Parameters("@IDMENSAJE").Value > 0 Then
                MsgBox("Ya existe un documento asociado a ese proveedor con ese número", MsgBoxStyle.Exclamation, "Ya Existe la factura")

                If MsgBox("¿Desea editar el documento existe?", MsgBoxStyle.YesNo, "Editar") Then
                    Me.Editando = True
                    Me.DocumentoEditando = Comando.Parameters("@IDMENSAJE").Value
                    Me.Tx_Identificación.Enabled = False
                    Me.Tx_Factura.Enabled = False
                End If
                Exit Sub
            Else
                MsgBox("Se guardo la factura del proveedor correctamente", MsgBoxStyle.Information, "GUARDAR FACTURA PROVEEDOR")
                If MsgBox("¿Desea Salir?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub Bt_Cerrar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cerrar.Click
        If MsgBox("¿Desea Salir?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    'Private Sub Fr_RegistrarFactura_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    If VariablesBase.VariablesBase.IdBodegaActual <> 1 Then
    '        Me.Dtp_FechaRadicadoPrincipal.Enabled = False
    '    End If
    'End Sub

    Private Sub Dtp_FechaRadicadoPrincipal_LostFocus(sender As Object, e As System.EventArgs) Handles Dtp_FechaRadicadoPrincipal.LostFocus
        Me.Dtp_FechaVencimiento.Value = DateAdd(DateInterval.Day, 45, Me.Dtp_FechaRadicadoPrincipal.Value)
        Me.Dtp_FechaVencimiento.Checked = False
    End Sub


End Class