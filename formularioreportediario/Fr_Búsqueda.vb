Public Class Fr_Búsqueda

    Public Tipo As String
    Public Resultado As Int64 = -1
    Public Resultado1 As String
    Public Resultado2 As Double
    Public Resultado3 As Integer
    Public Resultado4 As Integer
    Dim Idbase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual

    Dim bddatos As New FuncionesBase.ClaseCargarMaestras
    Dim dsCargar As New DataSet

    Public Sub CargarTablas()
        Select Case Tipo
            Case "C"
                dsCargar = bddatos.CargarMaestras(10, VariablesBase.VariablesBase.IdBaseSiscontrolActual, 3, 0) ' cargar ubicaciones
        End Select


        If dsCargar.Tables.Count > 0 Then
            Dgv_Buscar.DataSource = dsCargar.Tables(0)
        Else
            MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
            Exit Sub
        End If
        Me.Dgv_Buscar.AutoGenerateColumns = True
        Me.Dgv_Buscar.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Dgv_Buscar.ReadOnly = True

        Select Case Tipo
            Case "C" 'Costos
                For i = 0 To Dgv_Buscar.ColumnCount - 1
                    Dgv_Buscar.Columns(i).Visible = True
                    If Idbase = 121 Or Idbase = 122 Or Idbase = 123 Or Idbase = 124 Or Idbase = 125 Then
                        Select Case Dgv_Buscar.Columns(i).Name
                            Case "IDCOSTOINDIRECTO"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Id"
                            Case "Prog"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                            Case "Orden Sap"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Orden Sap"
                            Case "Cod. Ismocol"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Cod. Ismocol"
                            Case "Nombre"
                                Dgv_Buscar.Columns(i).Width = 300
                            Case "Objeto"
                                Dgv_Buscar.Columns(i).Width = 300
                            Case Else
                                Dgv_Buscar.Columns(i).Visible = False
                        End Select
                    Else
                        Select Case Dgv_Buscar.Columns(i).Name
                            Case "IDCOSTOINDIRECTO"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Id"
                            Case "Prog"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                            Case "Orden Sap"
                                Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_Buscar.Columns(i).HeaderText = "Orden Sap"
                            Case "Nombre"
                                Dgv_Buscar.Columns(i).Width = 300
                            Case "Objeto"
                                Dgv_Buscar.Columns(i).Width = 300
                            Case Else
                                Dgv_Buscar.Columns(i).Visible = False
                        End Select
                    End If
                Next
                Me.ComboBox_Filtrar.SelectedIndex = 0

                Me.Cb_Unidad.DataSource = dsCargar.Tables(1)
                Me.Cb_Unidad.ValueMember = "CODIGOTIPOUNIDAD"
                Me.Cb_Unidad.DisplayMember = "DESCRIPCION"
        End Select
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Select Case Tipo
            Case "C" 'Costos Indirectos
                Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDCOSTOINDIRECTO").Value
                Resultado1 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Nombre").Value
                Resultado2 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("VALORUNITARIO").Value
                Resultado3 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("CODIGOTIPOUNIDAD").Value
                Resultado4 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDORDENTRABAJO").Value
        End Select

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Tb_Descripción_TextChanged(sender As Object, e As EventArgs) Handles Tb_Descripción.TextChanged
        Select Case Tipo
            Case "C"
                If Cb_Filtrar.Checked = True Then
                    Dim vista As New DataView(dsCargar.Tables(0))
                    Me.Dgv_Buscar.SuspendLayout()
                    Me.Dgv_Buscar.DataSource = vista
                    Me.Dgv_Buscar.ResumeLayout()
                    Dim Columna As String = ""
                    Select Case Me.ComboBox_Filtrar.SelectedIndex
                        Case 0
                            If IsNumeric(Trim(Tb_Descripción.Text)) Then
                                vista.RowFilter = String.Format("CONVERT([Orden Sap], System.String) LIKE '%{0}%'", Tb_Descripción.Text)
                            End If
                        Case 1
                            Columna = "Nombre"
                            vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                        Case 2
                            Columna = "Objeto"
                            vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                        Case 3
                            Columna = "Cod. Ismocol"
                            vista.RowFilter = String.Format("CONVERT([Cod. Ismocol], System.String) like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                    End Select
                End If
        End Select
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub Fr_Búsqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarTablas()
    End Sub

    Private Sub Dgv_Buscar_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_Buscar.DoubleClick
        Select Case Tipo
            Case "C" 'Costos Indirectos
                Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDCOSTOINDIRECTO").Value
                Resultado1 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Nombre").Value
                Resultado2 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("VALORUNITARIO").Value
                Resultado3 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("CODIGOTIPOUNIDAD").Value
                Resultado4 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDORDENTRABAJO").Value
        End Select
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Ll_AgregarCostoDirecto_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_AgregarCostoDirecto.LinkClicked
        Me.Dgv_Buscar.Visible = False
        Me.Pn_superior.Height = 166
        Pn_BotonesInferiores.Visible = False
        Me.Height = 203

        Me.Gb_Filtro.Enabled = False
        Me.Lb_Orden.Visible = True
        Me.Lb_Cantidad.Visible = True
        Me.Lb_ValorUnitario.Visible = True
        Me.Lb_Costo.Visible = True
        Me.Lb_Total.Visible = True
        Me.Tx_CostoDirecto.Visible = True
        Me.Ll_AgregarCostoDirecto.Visible = False
        Me.Tx_Total.Visible = True
        Me.Tx_Cantidad.Visible = True
        Me.Tx_ValorUnitario.Visible = True
        Me.Bt_Cancelar.Visible = True
        Me.Bt_Guardar.Visible = True
        Me.Tx_Total.Visible = True
        AOT.Visible = True
        Lb_Letrero.Visible = True
        Lb_Unidad.Visible = True
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        habilitarcontroles()
    End Sub

    Private Sub habilitarcontroles()
        Me.Dgv_Buscar.Visible = True
        Me.Pn_superior.Height = 75
        Pn_BotonesInferiores.Visible = True
        Me.Height = 368
        Me.Gb_Filtro.Enabled = True
        Me.Lb_Orden.Visible = False
        Me.Lb_Cantidad.Visible = False
        Me.Lb_ValorUnitario.Visible = False
        Me.Lb_Costo.Visible = False
        Me.Lb_Total.Visible = False
        Me.Tx_CostoDirecto.Visible = False
        Me.Tx_CostoDirecto.Text = ""
        Me.Ll_AgregarCostoDirecto.Visible = True
        Me.Tx_Total.Visible = False
        Me.Tx_Total.Text = ""
        Me.Tx_Cantidad.Visible = False
        Me.Tx_Cantidad.Text = ""
        Me.Tx_ValorUnitario.Visible = False
        Me.Tx_ValorUnitario.Text = ""
        Me.Bt_Cancelar.Visible = False
        Me.Bt_Cancelar.Visible = False
        Me.Tx_Total.Visible = False
        AOT.Visible = False
        AOT.Identificador = -1
        AOT.Ll_Asociar.Text = "XXXXXXXXXXXXXX"
        Me.Lb_Letrero.Visible = False
        Me.Lb_Unidad.Visible = False

    End Sub
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If Me.Tx_CostoDirecto.Text = "" Then
            MsgBox("Debe diligenciar la descripción del costo directo y/o orden de servicio", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Me.Tx_ValorUnitario.Text = "" Then
            MsgBox("Debe diligenciar el valor unitario del costo directo y/o orden de servicio", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Me.Tx_Cantidad.Text = "" Then
            MsgBox("Debe diligenciar la cantidad del costo directo y/o orden de servicio", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Me.AOT.Identificador = -1 Then
            MsgBox("Debe seleccionar la orden de mantenimiento a la cual pertenece el costo directo y/o orden de servicio", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Me.Cb_Unidad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la unidad del costo directo", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("¿Seguro desea guardar este costo directo y/o orden de servicio, una vez registrado no se podra modificar?", MsgBoxStyle.YesNo, "GUARDAR") = MsgBoxResult.Yes Then
            GuardarCostoDirecto()
            habilitarcontroles()
        End If

    End Sub

    Dim VALOR As String

    Private Sub GuardarCostoDirecto()
        VALOR = AOT.Ll_Asociar.Text
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim datas As New DataSet
        Dim cmde As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Try
            'Cargar datos del usuario
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.AgregarCostoDirectoNoProgramado"
            cmde.Parameters.Add("@TIPO", SqlDbType.NVarChar).Value = 0
            cmde.Parameters.Add("@IDORDENTRABAJO", SqlDbType.NVarChar).Value = AOT.Identificador
            cmde.Parameters.Add("@NOMBRECOSTOINDIRECTO", SqlDbType.NVarChar).Value = Me.Tx_CostoDirecto.Text
            cmde.Parameters.Add("@VALORUNITARIO", SqlDbType.NVarChar).Value = Me.Tx_ValorUnitario.Text
            cmde.Parameters.Add("@CANTIDAD", SqlDbType.NVarChar).Value = Me.Tx_Cantidad.Text
            cmde.Parameters.Add("@VALORTOTAL", SqlDbType.NVarChar).Value = Me.Tx_Total.Text
            cmde.Parameters.Add("@CODIGOSERVICIO", SqlDbType.NVarChar).Value = ""
            cmde.Parameters.Add("@CODIGOTIPOUNIDAD", SqlDbType.NVarChar).Value = Me.Cb_Unidad.SelectedValue
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
            CargarTablas()
        Catch ex As Exception
            MsgBox("Error al guardar, verifique e intente de nuevo")
            sqlconeccion.Close()
        End Try
        Me.Tb_Descripción.Focus()
        Me.Tb_Descripción.Text = VALOR
    End Sub

    Private Sub Tx_ValorUnitario_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Tx_ValorUnitario.KeyPress, Tx_Cantidad.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_Cantidad_TextChanged(sender As Object, e As EventArgs) Handles Tx_Cantidad.TextChanged, Tx_ValorUnitario.TextChanged
        Try
            Me.Tx_Total.Text = Me.Tx_ValorUnitario.Text * Me.Tx_Cantidad.Text
        Catch ex As Exception
        End Try
    End Sub

End Class