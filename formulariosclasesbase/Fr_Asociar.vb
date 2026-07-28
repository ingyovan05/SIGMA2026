Imports System.Data.SqlClient

Public Class Fr_Asociar
    Public Tipo As String
    Public Resultado As String
    Public Identificador As Integer = -1

    Dim dsCargar As New DataSet

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        If Dgv_Buscar.SelectedRows.Count > 0 Then

            Select Case Tipo
                Case "OC" ' Orden de Compra
                    Try
                        Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenCompra").Value
                        Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("OrdenCompra").Value
                    Catch ex As Exception
                    End Try

                Case "OT" ' Orden de Mantenimiento
                    Try
                        Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenTrabajo").Value
                        Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("OrdenSap").Value
                    Catch ex As Exception
                    End Try
            End Select
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Debe selecionar algun valor", MsgBoxStyle.Critical, "Mensaje")
        End If

    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub Bt_Buscar_Click(sender As Object, e As EventArgs) Handles Bt_Buscar.Click
        If Trim(Me.Tb_Identificador.Text) <> "" Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.BuscarOC_OM", conexion)
            Me.dsCargar.Clear()
            Select Case Tipo
                Case "OC"
                    comando.Parameters.AddWithValue("@TIPO", 0)
                    Select Case ComboBox_Filtrar.SelectedIndex
                        Case 0
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "ORDENCOMPRA")
                    End Select
                Case "OT"
                    comando.Parameters.AddWithValue("@TIPO", 1)
                    Select Case ComboBox_Filtrar.SelectedIndex
                        Case 0
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "NROORDENSAP")
                        Case 1
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "OBJETO")
                        Case 2
                            comando.Parameters.AddWithValue("@CAMPOBUSQUEDA", "CODIGOORDENCLIENTE")
                    End Select
            End Select
            comando.Parameters.AddWithValue("@IDENTIFICADOR", Trim(Me.Tb_Identificador.Text))
            comando.CommandType = CommandType.StoredProcedure
            Dim adaptador As New SqlDataAdapter(comando)
            Try
                conexion.Open()
                adaptador.Fill(dsCargar)
                conexion.Close()
            Catch ex As Exception
                MsgBox("No se cargaron los recursospara exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
                Exit Sub
            Finally
                conexion.Close()
            End Try

            Me.Dgv_Buscar.DataSource = dsCargar.Tables(0)

            Me.Dgv_Buscar.AutoGenerateColumns = True
            'Me.Dgv_Buscar.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None 
            Me.Dgv_Buscar.ReadOnly = True

            Select Case Tipo
                Case "OC" 'Orden de Compra
                    For i = 0 To Dgv_Buscar.ColumnCount - 1
                        Dgv_Buscar.Columns(i).Visible = True
                        Select Case Dgv_Buscar.Columns(i).Name
                            Case "IdOrdenCompra"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Id"
                            Case "OrdenCompra"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Orden de Compra"
                            Case Else
                                Dgv_Buscar.Columns(i).Visible = False
                        End Select
                    Next
                Case "OT" 'Orden de mantenimiento
                    Dim idbase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    If idbase = 121 Or idbase = 122 Or idbase = 123 Or idbase = 124 Or idbase = 125 Then
                        For i = 0 To Dgv_Buscar.ColumnCount - 1
                            Dgv_Buscar.Columns(i).Visible = True
                            Select Case Dgv_Buscar.Columns(i).Name
                                Case "IdOrdenTrabajo"
                                    Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                    Dgv_Buscar.Columns(i).HeaderText = "Id"
                                Case "OrdenSap"
                                    Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                    Dgv_Buscar.Columns(i).HeaderText = "Orden Sap"
                                Case "CodigoIsmocol"
                                    Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                    Dgv_Buscar.Columns(i).HeaderText = "Cod. Ismocol"
                                Case "Objeto"
                                    Dgv_Buscar.Columns(i).Width = 400
                                    Dgv_Buscar.Columns(i).HeaderText = "Objeto Orden Sap"
                                Case Else
                                    Dgv_Buscar.Columns(i).Visible = False
                            End Select
                        Next
                    Else
                        For i = 0 To Dgv_Buscar.ColumnCount - 1
                            Dgv_Buscar.Columns(i).Visible = True
                            Select Case Dgv_Buscar.Columns(i).Name
                                Case "IdOrdenTrabajo"
                                    Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                    Dgv_Buscar.Columns(i).HeaderText = "Id"
                                Case "OrdenSap"
                                    Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                    Dgv_Buscar.Columns(i).HeaderText = "Orden Sap"
                                Case "Objeto"
                                    Dgv_Buscar.Columns(i).Width = 400
                                    Dgv_Buscar.Columns(i).HeaderText = "Objeto Orden Sap"
                                Case Else
                                    Dgv_Buscar.Columns(i).Visible = False
                            End Select
                        Next
                    End If
            End Select
        End If
    End Sub

    Private Sub Bt_SinAsociar_Click(sender As Object, e As EventArgs) Handles Bt_SinAsociar.Click
        Me.Resultado = "SIN ASOCIAR " + Tipo
        Me.Identificador = -1
        Me.Close()
    End Sub

    Private Sub Dgv_Buscar_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_Buscar.DoubleClick
        Select Case Tipo
            Case "OC" ' Orden de Compra
                Try
                    Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenCompra").Value
                    Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("OrdenCompra").Value
                Catch ex As Exception
                End Try

            Case "OT" ' Orden de Mantenimiento
                Try
                    Identificador = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IdOrdenTrabajo").Value
                    Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("OrdenSap").Value
                Catch ex As Exception
                End Try
        End Select
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Fr_Asociar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dgv_Buscar.MultiSelect = False
    End Sub

    Private Sub Tb_Identificador_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Tb_Identificador.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Bt_Buscar.PerformClick()
        End If
    End Sub

End Class