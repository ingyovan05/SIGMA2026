Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient

Public Class Fr_ImprimirSticker


    Dim Tb_Sticker As New DataTable("STICKER")

    Public IdEA As Integer
    Public Tipo As String
    Public FechaEA As Date
    Public EA As Integer

    Public Tb_Sticker_EA As New DataTable("STICKER")

    Private Sub Fr_ImprimirSticker_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If Tipo = "EAS" Then
            If Me.Tb_Sticker.Columns.Count = 0 Then
                Me.Tb_Sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                Me.Tb_Sticker.Columns.Add("Descripción")
                Me.Tb_Sticker.Columns.Add("Requisición")
                Me.Tb_Sticker.Columns.Add("Orden Compra")
                Me.Tb_Sticker.Columns.Add("Cant", Type.GetType("System.Int32"))
            End If
            Me.Dgv_Sticker.DataSource = Tb_Sticker

            For i = 0 To Dgv_Sticker.ColumnCount - 1
                Select Case Dgv_Sticker.Columns(i).Name
                    Case "Cód"
                        Dgv_Sticker.Columns(i).Width = 80
                        Exit Select
                    Case "Descripción"
                        Dgv_Sticker.Columns(i).Width = 400
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Requisición"
                        Dgv_Sticker.Columns(i).Width = 80
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Orden Compra"
                        Dgv_Sticker.Columns(i).Width = 80
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Cant"
                        Dgv_Sticker.Columns(i).Width = 80
                        Exit Select
                    Case Else
                        Dgv_Sticker.Columns(i).Visible = False
                End Select
            Next i
        Else
            If Me.Tb_Sticker.Columns.Count = 0 Then
                Me.Tb_Sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                Me.Tb_Sticker.Columns.Add("Und")
                Me.Tb_Sticker.Columns.Add("Descripción")
                Me.Tb_Sticker.Columns.Add("Cant", Type.GetType("System.Int32"))
            End If
            Me.Dgv_Sticker.DataSource = Tb_Sticker

            For i = 0 To Dgv_Sticker.ColumnCount - 1
                Select Case Dgv_Sticker.Columns(i).Name
                    Case "Cód"
                        Dgv_Sticker.Columns(i).Width = 80
                        Exit Select
                    Case "Und"
                        Dgv_Sticker.Columns(i).Width = 80
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Descripción"
                        Dgv_Sticker.Columns(i).Width = 500
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Cant"
                        Dgv_Sticker.Columns(i).Width = 80
                        Exit Select
                    Case Else
                        Dgv_Sticker.Columns(i).Visible = False
                End Select
            Next i
        End If

        If Tipo = "EA" Then
            Cb_Formato.SelectedIndex = 0

            'donde cargas Tb_Sticker_EA en Tb_Sticker
            Me.Tb_Sticker = Tb_Sticker_EA
            Me.Dgv_Sticker.DataSource = Tb_Sticker
        ElseIf Tipo = "EAS" Then
            Cb_Formato.SelectedIndex = 3
            'donde cargas Tb_Sticker_EA en Tb_Sticker
            Me.Tb_Sticker = Tb_Sticker_EA
            Me.Dgv_Sticker.DataSource = Tb_Sticker

            If Me.Tb_Sticker.Columns.Count = 0 Then
                Me.Tb_Sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                Me.Tb_Sticker.Columns.Add("Descripción")
                Me.Tb_Sticker.Columns.Add("Requisición")
                Me.Tb_Sticker.Columns.Add("Orden Compra")
                Me.Tb_Sticker.Columns.Add("Cant", Type.GetType("System.Int32"))
            End If
            Me.Dgv_Sticker.DataSource = Tb_Sticker

            For i = 0 To Dgv_Sticker.ColumnCount - 1
                Select Case Dgv_Sticker.Columns(i).Name
                    Case "Cód"
                        Dgv_Sticker.Columns(i).Width = 80
                        Exit Select
                    Case "Descripción"
                        Dgv_Sticker.Columns(i).Width = 400
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Requisición"
                        Dgv_Sticker.Columns(i).Width = 80
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Orden Compra"
                        Dgv_Sticker.Columns(i).Width = 80
                        Dgv_Sticker.Columns(i).ReadOnly = True
                        Exit Select
                    Case "Cant"
                        Dgv_Sticker.Columns(i).Width = 80
                        Exit Select
                    Case Else
                        Dgv_Sticker.Columns(i).Visible = False
                End Select
            Next i
        End If


    End Sub


    Public Sub AgregarItem()

        Dim ItemsEA As New DataTable()
        Dim Cadena_Consulta As String = "SELECT * FROM DetalleItemsEASticker(" & IdEA & ")"
        Dim Consulta As New SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Adaptador.FillSchema(ItemsEA, SchemaType.Source)
        Adaptador.Fill(ItemsEA)
        Consulta.Connection.Close()
        Dgv_Sticker.DataSource = ItemsEA

    End Sub




    Dim Estilo_Celda_Error As New DataGridViewCellStyle
    Dim Estilo_Celda As New DataGridViewCellStyle
    Dim articulos As New DataTable("ListarArticulos")

    Private Sub ELiminarFilaVacia()
        Try
            For i = 0 To Dgv_Sticker.Rows.Count - 2
                If IsDBNull(Me.Dgv_Sticker.Rows(i).Cells("Descripción").Value) = True Then
                    Me.Dgv_Sticker.Rows.RemoveAt(i)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Dgv_Sticker_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Sticker.CellEndEdit
        If IsDBNull(Me.Dgv_Sticker.Item(e.ColumnIndex, e.RowIndex).Value) = True Then
            Me.Dgv_Sticker.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If
        If Trim(Me.Dgv_Sticker.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
            If e.RowIndex > 0 Then
                Me.Dgv_Sticker.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_Sticker.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Me.Dgv_Sticker.Rows.RemoveAt(e.RowIndex)
                Catch ex As Exception

                End Try
            End If
            Exit Sub
        End If
        Dim IDARTICULO As Integer = -1
        If IsDBNull(Me.Dgv_Sticker.Item("Cód", e.RowIndex).Value) = False Then
            If IsNumeric(Me.Dgv_Sticker.Item("Cód", e.RowIndex).Value) = True Then
                IDARTICULO = Me.Dgv_Sticker.Item("Cód", e.RowIndex).Value
            End If
        End If
        Dim CANTIDAD As Integer = -1
        If IsDBNull(Me.Dgv_Sticker.Item("Cant", e.RowIndex).Value) = False Then
            If IsNumeric(Me.Dgv_Sticker.Item("Cant", e.RowIndex).Value) = True Then
                CANTIDAD = Me.Dgv_Sticker.Item("Cant", e.RowIndex).Value
            End If

        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_Sticker.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_Sticker.Rows(e.RowIndex).ErrorText = ""

        'Validar Articulo
        Select Case e.ColumnIndex
            Case 0
                If ValidarItemsRQ(IDARTICULO) = True Then
                    Dim FilasArticulos As DataRow()
                    Dim FilaArticulo As DataRow
                    Dim NuevaFilaItem As DataRow

                    articulos = New DataTable("ListarArticulos_1")
                    Dim Cadena_Consulta As String =
                        "SELECT * FROM " + _
                        " dbo.DatosArticuloXBodegaImprimirSticker(" & IDARTICULO & "," & VariablesBase.VariablesBase.IdBodegaActual & ") AS ListarArticulos_1"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()

                    Adaptador.FillSchema(articulos, SchemaType.Source)
                    Adaptador.Fill(articulos)
                    FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)


                    If FilasArticulos.Length > 0 Then
                        FilaArticulo = FilasArticulos(0)
                        NuevaFilaItem = Tb_Sticker.NewRow
                        NuevaFilaItem("Cód") = IDARTICULO
                        NuevaFilaItem("Und") = FilaArticulo("UND")
                        NuevaFilaItem("Descripción") = Trim(FilaArticulo("NOMBRE"))
                        NuevaFilaItem("Cant") = 0 'DBNull.Value

                        If Me.Tb_Sticker.Rows.Count = Me.Dgv_Sticker.CurrentCell.RowIndex Then
                            Try
                                Me.Dgv_Sticker.Rows.RemoveAt(e.RowIndex)
                            Catch ex As Exception
                            End Try
                            Tb_Sticker.Rows.Add(NuevaFilaItem)
                        Else
                            Dgv_Sticker.Rows(e.RowIndex).Cells(0).Value = NuevaFilaItem("Cód")
                            Dgv_Sticker.Rows(e.RowIndex).Cells(1).Value = NuevaFilaItem("Und")
                            Dgv_Sticker.Rows(e.RowIndex).Cells(2).Value = NuevaFilaItem("Descripción")
                            Dgv_Sticker.Rows(e.RowIndex).Cells(3).Value = NuevaFilaItem("Cant")

                        End If



                    Else
                        MsgBox("No se encontro un articulo con ese código", MsgBoxStyle.Exclamation, "Articulo no Encontrado")
                        Try
                            Me.Dgv_Sticker.Rows.RemoveAt(e.RowIndex)
                        Catch ex As Exception
                        End Try
                    End If
                Else
                    MsgBox("El item que desea ingresar, ya se encuentra incluido", MsgBoxStyle.Critical, "Item Repetido")
                    Try
                        Me.Dgv_Sticker.Rows.RemoveAt(e.RowIndex)
                    Catch ex As Exception
                    End Try
                End If
            Case 3
                If Trim(CANTIDAD) = "" Then
                    Me.Dgv_Sticker.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                    Me.Dgv_Sticker.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es valido"
                Else
                    If IsNumeric(CANTIDAD) = False Then
                        Me.Dgv_Sticker.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Me.Dgv_Sticker.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es valido"
                    Else
                        If CANTIDAD < 1 Then
                            Me.Dgv_Sticker.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Me.Dgv_Sticker.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es valido"
                        End If
                    End If
                End If
        End Select
        ELiminarFilaVacia()
    End Sub


    Private Function ValidarItemsRQ(ByVal IdArticulo As Integer) As Boolean
        Dim filas As DataRow()
        filas = Me.Tb_Sticker.Select("Cód=" + IdArticulo.ToString)
        If filas.Length > 0 Then
            ValidarItemsRQ = False
            Exit Function
        End If
        ValidarItemsRQ = True
    End Function

    Private Sub Dgv_Sticker_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles Dgv_Sticker.SelectionChanged
        Try
            Me.Tx_Descripción.Text = Dgv_Sticker.Rows(Dgv_Sticker.CurrentRow.Index).Cells("Descripción").Value
        Catch ex As Exception
            Me.Tx_Descripción.Text = ""
        End Try
    End Sub
    Dim NombreFamilia As String

    Private Sub Dgv_Sticker_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Dgv_Sticker.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F3 Then
            Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
            NombreFamilia = "-1"
            FrBuscarArtículo.Familia = NombreFamilia
            FrBuscarArtículo._Tipo = "T"
            FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de busqueda por familia, falta implementar
            FrBuscarArtículo.ShowDialog()
            If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
                If FrBuscarArtículo.Actualizar = False Then
                    Exit Sub
                End If
            End If

            If ValidarItemsRQ(FrBuscarArtículo.IdArtículo) = True Then
                Dim FilasArticulos As DataRow()
                articulos = New DataTable("ListarArticulos_1")
                Dim Cadena_Consulta As String =
                    "SELECT * FROM " + _
                    " dbo.DatosArticuloXBodegaImprimirSticker(" & FrBuscarArtículo.IdArtículo.ToString & "," & VariablesBase.VariablesBase.IdBodegaActual & ") AS ListarArticulos_1"
                Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta.Connection = Conexión
                Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                Consulta.Connection.Open()
                Adaptador.FillSchema(articulos, SchemaType.Source)
                Adaptador.Fill(articulos)
                FilasArticulos = articulos.Select("ID=" + FrBuscarArtículo.IdArtículo.ToString)
                If FilasArticulos.Length > 0 Then
                    Dim FilaArticulo As DataRow
                    FilaArticulo = FilasArticulos(0)
                    Dim NuevaFilaItem As DataRow
                    FilaArticulo = FilasArticulos(0)
                    NuevaFilaItem = Tb_Sticker.NewRow
                    NuevaFilaItem("Cód") = FrBuscarArtículo.IdArtículo
                    NuevaFilaItem("Und") = FilaArticulo("UND")
                    NuevaFilaItem("Descripción") = Trim(FilaArticulo("NOMBRE"))
                    NuevaFilaItem("Cant") = 0 'DBNull.Value
                    Tb_Sticker.Rows.Add(NuevaFilaItem)
                Else
                    ' no existe un articulo con este codigo
                    MsgBox("No se encontro un articulo con ese código", MsgBoxStyle.Exclamation, "Articulo no Encontrado")
                End If
            Else
                MsgBox("El item que desea ingresar, ya se encuentra incluido en la requisición", MsgBoxStyle.Critical, "Item Repetido")
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then 'SI PRESIONA PARA ELIMINAR FILA
            Try
                Me.Dgv_Sticker.Rows.RemoveAt(Dgv_Sticker.CurrentCell.RowIndex)
            Catch ex As Exception
            End Try
            Try
                Tb_Sticker.AcceptChanges()
            Catch ex As Exception
            End Try
        End If
        ELiminarFilaVacia()
    End Sub

    Private Sub Dgv_Sticker_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Dgv_Sticker.DataError
        ''http ://msdn.microsoft.com/es-es/library/t4a23xx4(v=vs.110).aspx
        If e.Exception IsNot Nothing AndAlso _
        e.Context = DataGridViewDataErrorContexts.Commit Then
            MessageBox.Show("Favor comunicarse con el personal de sistemas")
        End If
    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub


    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If validar() = True Then
            If MsgBox("¿Desea imprimir los sticker's", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Select Case Me.Cb_Formato.SelectedIndex
                    Case 0
                        Array.Add(68)
                    Case 1
                        Array.Add(76)
                    Case 2
                        Array.Add(77)
                    Case 3
                        If VariablesBase.VariablesBase.IdBodegaActual = 20 Or VariablesBase.VariablesBase.IdBodegaActual = 71 Then
                            Array.Add(80)
                        Else
                            MessageBox.Show("Favor cambiar el tipo de formato")
                            Exit Sub
                        End If
                End Select
                climpresiones.Fecha = FechaEA
                climpresiones.IDENTRADAALMACEN = EA
                climpresiones.Tb_Sticker = Tb_Sticker
                climpresiones.InicioImpresión = Me.Nud_InicioImpresión.Value
                climpresiones.FormatoImprimirMateriales(Array, True, False)
                MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
            End If
        End If
    End Sub

    Private Function validar() As Boolean
        ELiminarFilaVacia()
        If Me.Cb_Formato.SelectedIndex = -1 Then
            MsgBox("Seleccione el formato a usar", MsgBoxStyle.Critical, "Verificar Formato")
            validar = False
            Exit Function
        End If
        For i = 0 To Me.Tb_Sticker.Rows.Count - 1
            If Me.Tb_Sticker.Rows(i).Item("Cant") <= 0 Then
                MsgBox("Las cantidades no son correctas", MsgBoxStyle.Critical, "Verificar Cantidades")
                validar = False
                Exit Function
            End If
        Next
        validar = True
    End Function

End Class