Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class Fr_Busqueda

    Public Tipo As String
    Public Identificador As Integer = -1

    Dim dsCargar As New DataSet

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        If Dgv_Buscar.SelectedRows.Count > 0 Then
            Select Case Tipo
                Case "OS" ' Orden de Servicio
                    Try
                        Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenServicio").Value
                    Catch ex As Exception
                    End Try

                Case "OC" ' Orden de Compra
                    Try
                        Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenCompra").Value
                    Catch ex As Exception
                    End Try
            End Select
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Debe selecionar algun valor", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub

    Private Sub Bt_Buscar_Click(sender As Object, e As EventArgs) Handles Bt_Buscar.Click

        If Trim(Me.Tb_Identificador.Text) <> "" Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.BuscarOS_OC", conexion)
            Me.dsCargar.Clear()
            Select Case Tipo
                Case "OS"
                    comando.Parameters.AddWithValue("@TIPO", 0)
                    comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                    comando.Parameters.AddWithValue("@IDBODEGA", DBNull.Value)
                    Select Case ComboBox_Filtrar.SelectedIndex
                        Case 0
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "dbo.CodigoOrdenServicio(OS.IDORDENESSERVICIO)")
                        Case 1
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "C.NOMBRE")
                        Case 2
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "C.IDENTIFICACION ")
                    End Select
                Case "OC"
                    comando.Parameters.AddWithValue("@TIPO", 1)
                    comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
                    comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                    Select Case ComboBox_Filtrar.SelectedIndex
                        Case 0
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "ORDENCOMPRA")
                        Case 1
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "P.NOMBRE")
                        Case 2
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "P.IDENTIFICACION ")
                    End Select
            End Select
            comando.Parameters.AddWithValue("@IDENTIFICADOR", Trim(Me.Tb_Identificador.Text))
            comando.Parameters.Add(New SqlParameter("@MENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            comando.CommandType = CommandType.StoredProcedure
            Dim adaptador As New SqlDataAdapter(comando)
            Try
                conexion.Open()
                adaptador.Fill(dsCargar)
                conexion.Close()
                If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
                    Select Case comando.Parameters("@Mensaje").Value
                        Case 1
                            Me.Dgv_Buscar.DataSource = dsCargar.Tables(0)

                        Case Else
                            MessageBox.Show("Resultados mayores a 100, Por favor especificar mejor la busqueda", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Select
                End If


                Me.Dgv_Buscar.AutoGenerateColumns = True
                Me.Dgv_Buscar.ReadOnly = True

                Select Case Tipo
                    Case "OS" 'Orden de Servicio
                        For i = 0 To Dgv_Buscar.ColumnCount - 1
                            Dgv_Buscar.Columns(i).Visible = True
                            Select Case Dgv_Buscar.Columns(i).Name
                                Case "IdOrdenServicio"
                                    Dgv_Buscar.Columns(i).Width = 60
                                    Dgv_Buscar.Columns(i).HeaderText = "Id"
                                Case "Orden Servicio"
                                    Dgv_Buscar.Columns(i).Width = 100
                                Case "ValorTotal"
                                    Dgv_Buscar.Columns(i).HeaderText = "Orden de Servicio"
                                    Dgv_Buscar.Columns(i).Width = 80
                                    Dgv_Buscar.Columns(i).HeaderText = "Vr Total"
                                Case "Proveedor"
                                    Dgv_Buscar.Columns(i).Width = 200
                                Case "Nit"
                                    Dgv_Buscar.Columns(i).Width = 80

                                Case Else
                                    Dgv_Buscar.Columns(i).Visible = False
                            End Select
                        Next
                    Case "OC" 'Orden de Compra
                        For i = 0 To Dgv_Buscar.ColumnCount - 1
                            Dgv_Buscar.Columns(i).Visible = True
                            Select Case Dgv_Buscar.Columns(i).Name
                                Case "IdOrdenCompra"
                                    Dgv_Buscar.Columns(i).Width = 60
                                    Dgv_Buscar.Columns(i).HeaderText = "Id"
                                Case "Orden Compra"
                                    Dgv_Buscar.Columns(i).Width = 150
                                    Dgv_Buscar.Columns(i).HeaderText = "Orden de Compra"
                                Case "ValorTotal"
                                    Dgv_Buscar.Columns(i).Width = 80
                                    Dgv_Buscar.Columns(i).HeaderText = "Vr Total"
                                Case "Proveedor"
                                    Dgv_Buscar.Columns(i).Width = 200
                                Case "Nit"
                                    Dgv_Buscar.Columns(i).Width = 80
                                Case Else
                                    Dgv_Buscar.Columns(i).Visible = False
                            End Select
                        Next
                End Select
            Catch ex As Exception
                MsgBox("No se cargaron los datos para mostrar.", MsgBoxStyle.Critical, "Error mostrar datos")
                Exit Sub
            Finally
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub Dgv_Buscar_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_Buscar.DoubleClick
        If Dgv_Buscar.SelectedRows.Count > 0 Then
            Select Case Tipo
                Case "OS" ' Orden de Servicio
                    Try
                        Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenServicio").Value
                    Catch ex As Exception
                    End Try

                Case "OC" ' Orden de Compra
                    Try
                        Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenCompra").Value
                    Catch ex As Exception
                    End Try
            End Select
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Debe selecionar algun valor", MsgBoxStyle.Critical, "Mensaje")
        End If
    End Sub


    Private Sub Tb_Identificador_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Tb_Identificador.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Bt_Buscar.PerformClick()
        End If
    End Sub

    Private Sub Fr_Busqueda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Dgv_Buscar.MultiSelect = False
    End Sub
End Class