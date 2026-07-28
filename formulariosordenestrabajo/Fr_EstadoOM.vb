Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_EstadoOM
    Public Tipo As String
    Public TablaIdOMS As New DataTable
    Public TablaIdOMSProcedimiento As New DataTable


    Public Sub CargarTabla()
        Select Case Tipo
            Case "OMSI"
                Dgv_OrdenSap.DataSource = TablaIdOMS
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "NROORDENSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Número orden SAP"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Nro SAP"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Case "ESTADO"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Estado OM"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Estado"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i

                Dim dt_estados As New DataTable
                dt_estados.Columns.Add("TIPO")
                dt_estados.Columns.Add("NOMBRE")
                dt_estados.Rows.Add("P", "PLANEACION")
                dt_estados.Rows.Add("N", "PLANEADA")
                dt_estados.Rows.Add("E", "EJECUCION")
                dt_estados.Rows.Add("S", "SUSPENDIDA")
                dt_estados.Rows.Add("X", "CERRADA")
                dt_estados.Rows.Add("C", "CANCELADA")
                dt_estados.Rows.Add("F", "FINALIZADA")
                Cb_Estado.DataSource = dt_estados
                Cb_Estado.DisplayMember = "NOMBRE"
                Cb_Estado.ValueMember = "TIPO"

            Case "OMSA"
                Dgv_OrdenSap.DataSource = TablaIdOMS
                'colocarle estilo
                For i = 0 To Dgv_OrdenSap.ColumnCount - 1
                    Select Case Dgv_OrdenSap.Columns(i).Name
                        Case "NROORDENSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Número orden SAP"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Nro SAP"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Case "ESTADOSAP"
                            Dgv_OrdenSap.Columns(i).Width = 80
                            Dgv_OrdenSap.Columns(i).ToolTipText = "Estado OM"
                            Dgv_OrdenSap.Columns(i).HeaderText = "Estado"
                            Dgv_OrdenSap.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_OrdenSap.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    End Select
                Next i

                Dim dt_estados As New DataTable
                dt_estados.Columns.Add("TIPO")
                dt_estados.Columns.Add("NOMBRE")
                dt_estados.Rows.Add("OTPL", "OTPL - PLANEADA")
                dt_estados.Rows.Add("OTPR", "OTPR - PROGRAMADA")
                dt_estados.Rows.Add("LIB", "LIB - LIBERADA")
                dt_estados.Rows.Add("OTEF", "OTEF - FINALIZADA")
                dt_estados.Rows.Add("OTAU", "OTAU - AUDITADA")
                If FuncionesBase.FuncionesBase.ConsultarPermiso(770) = True Then
                    dt_estados.Rows.Add("OTAP", "OTAP - FACTURADA")
                End If
                dt_estados.Rows.Add("ABI", "ABI - ABIERTA")
                dt_estados.Rows.Add("CTCA", "CTCA - CANCELADA")
                Cb_Estado.DataSource = dt_estados
                Cb_Estado.DisplayMember = "NOMBRE"
                Cb_Estado.ValueMember = "TIPO"

        End Select
    End Sub

    Private Sub Bt_AgregarOMPortapapeles_Click(sender As Object, e As EventArgs) Handles Bt_AgregarOMPortapapeles.Click
        
                Me.Cursor = Cursors.WaitCursor
                Try
                    Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
                    Dim words() As String = Clipboard.GetText().Split(delimiterChars)
                    For i = 0 To words.Length - 1
                        Dim line As String
                        line = Replace(LTrim(RTrim(words(i))), vbLf, "")
                        If line.Length > 0 Then
                            Try

                                Dim fila As DataRow
                                fila = TablaIdOMS.NewRow
                        fila("NROORDENSAP") = line
                        Select Tipo
                            Case "OMSI"
                                fila("ESTADO") = ConsultarEstadoOMSigma(line)
                            Case "OMSA"
                                fila("ESTADOSAP") = ConsultarEstadoOMSap(line)
                        End Select
                        TablaIdOMS.Rows.Add(fila)

                    Catch ex As Exception
                    End Try
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                End Try




    End Sub

    Private Function ConsultarEstadoOMSigma(ByVal IDORDENTRABAJO As Integer) As String
        'Consultar Valor de referencia del equipo
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT DBO.EstadoOMSIGMA(NROORDENSAP) FROM OT_ORDENTRABAJO WHERE  NROORDENSAP = @IDORDENTRABAJO", conexion)
        comando.Parameters.AddWithValue("@IDORDENTRABAJO", IDORDENTRABAJO)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtIdOT As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtIdOT)
            conexion.Close()
            If Not IsDBNull(dtIdOT.Rows(0).Item(0)) Then
                ConsultarEstadoOMSigma = dtIdOT.Rows(0).Item(0)
            Else
                MsgBox("No se encontró el Estado", MsgBoxStyle.Exclamation, "Estado no Encontrado")
                ConsultarEstadoOMSigma = ""
            End If
        Catch ex As Exception
            ConsultarEstadoOMSigma = ""
        Finally
            conexion.Close()
        End Try
    End Function

    Private Function ConsultarEstadoOMSap(ByVal IDORDENTRABAJO As Integer) As String
        'Consultar Valor de referencia del equipo
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT DBO.EstadoOMSAP(NROORDENSAP) FROM OT_ORDENTRABAJO WHERE  NROORDENSAP = @IDORDENTRABAJO", conexion)
        comando.Parameters.AddWithValue("@IDORDENTRABAJO", IDORDENTRABAJO)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtIdOT As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtIdOT)
            conexion.Close()
            If Not IsDBNull(dtIdOT.Rows(0).Item(0)) Then
                ConsultarEstadoOMSap = dtIdOT.Rows(0).Item(0)
            Else
                MsgBox("No se encontró el Estado", MsgBoxStyle.Exclamation, "Estado no Encontrado")
                ConsultarEstadoOMSap = ""
            End If
        Catch ex As Exception
            ConsultarEstadoOMSap = ""
        Finally
            conexion.Close()
        End Try
    End Function

    Private Sub Bt_LimpiarTabla_Click(sender As Object, e As EventArgs) Handles Bt_LimpiarTabla.Click
        Select Case Tipo
            Case "OMSI", "OMSA"
                TablaIdOMS.Clear()
        End Select
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Dgv_OrdenSap_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Dgv_OrdenSap.RowsAdded

        Select Case Tipo
            Case "OMSI", "OMSA"
                Me.Lb_TotalSAP.Text = "Total Ordenes: " + (Me.Dgv_OrdenSap.Rows.Count - 1).ToString
        End Select

    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If MsgBox("Seguro desea cambiar el estado SIGMA de la OM", MsgBoxStyle.YesNo, "Cambiar Estado") = MsgBoxResult.Yes Then

            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Dim Comando As New SqlCommand("dbo.CambiarEstadoOMS", conn)
            'Declaración de parámetros del procedimiento
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)
            Comando.Parameters.Add("@IDBASESISCONTROL", SqlDbType.Int)
            Comando.Parameters.Add("@TIPO", SqlDbType.Int)
            Comando.Parameters.Add("@ESTADO", SqlDbType.Char)
            Comando.Parameters.Add("@ESTADOSAP", SqlDbType.NChar)
            Comando.Parameters.Add("@HOJAENTRADA", SqlDbType.Char)
            Comando.Parameters.Add("@NROFACTURA", SqlDbType.Char)
            Comando.Parameters.Add("@TABLAIDOT", SqlDbType.Structured)
            Comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona
            Comando.Parameters("@IDBASESISCONTROL").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
            Select Tipo
                Case "OMSI"
                    Comando.Parameters("@TIPO").Value = 0
                    Comando.Parameters("@ESTADO").Value = Cb_Estado.SelectedValue
                    Comando.Parameters("@ESTADOSAP").Value = DBNull.Value
                    Comando.Parameters("@HOJAENTRADA").Value = DBNull.Value
                    Comando.Parameters("@NROFACTURA").Value = DBNull.Value
                Case "OMSA"
                    Comando.Parameters("@TIPO").Value = 1
                    Comando.Parameters("@ESTADO").Value = DBNull.Value
                    Comando.Parameters("@ESTADOSAP").Value = Cb_Estado.SelectedValue
                    If Pn_Facturación.Visible = True And Ck_Actualizar.Checked = True Then
                        Comando.Parameters("@TIPO").Value = 2
                        Comando.Parameters("@HOJAENTRADA").Value = Me.Tx_HojaEntrada.Text
                        Comando.Parameters("@NROFACTURA").Value = Me.Tx_Factura.Text
                    Else
                        Comando.Parameters("@HOJAENTRADA").Value = DBNull.Value
                        Comando.Parameters("@NROFACTURA").Value = DBNull.Value
                    End If
            End Select

            ''cargar la tabla TablaIdOMSProcedimiento
            For i = 0 To TablaIdOMS.Rows.Count - 1
                Dim fila As DataRow
                fila = TablaIdOMS(i)
                Dim Fila1 As DataRow
                Fila1 = TablaIdOMSProcedimiento.NewRow
                Fila1("NROORDENSAP") = fila("NROORDENSAP")
                TablaIdOMSProcedimiento.Rows.Add(Fila1)
            Next

            Comando.Parameters("@TABLAIDOT").Value = TablaIdOMSProcedimiento
            Comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            Try
                conn.Open()
                Comando.ExecuteNonQuery()
                conn.Close()

                Select Case Comando.Parameters("@IDMENSAJE").Value
                    Case 0
                        MessageBox.Show("No se pudo realizar la operación.", "No se completo la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Case 1
                        MessageBox.Show("El cambio de estado ha sido exitoso.", "CAMBIO DE ESTADO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If MsgBox("¿Desea actualizar la lista de OM?", MsgBoxStyle.YesNo, "Actualizar lista") = MsgBoxResult.Yes Then
                            Cu_padre.ReactivarPrincipal = True
                        Else
                            Cu_padre.ReactivarPrincipal = False
                        End If
                        Me.Close()
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Public Cu_padre As Object

    Private Sub Cb_Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Estado.SelectedIndexChanged
        Try
            Select Case Me.Cb_Estado.SelectedValue
                Case "OTAP"
                    'dt_estados.Rows.Add("OTAP", "OTAP - FACTURADA")
                    Pn_Facturación.Visible = True
                Case Else
                    Pn_Facturación.Visible = False
            End Select
        Catch ex As Exception

        End Try
       
    End Sub
End Class