Public Class Fr_Búsqueda

    Public Tipo As String
    Public Resultado As String
    Public Resultado1 As String


    Dim bddatos As New FuncionesBase.ClaseCargarMaestras
    Dim dsCargar As New DataSet

    Public Sub CargarTablas()


        Select Case Tipo
            Case "U"
                dsCargar = bddatos.CargarMaestras(10, VariablesBase.VariablesBase.IdBaseSiscontrolActual, 1, 0) ' cargar ubicaciones
            Case "E"
                dsCargar = bddatos.CargarMaestras(10, VariablesBase.VariablesBase.IdBaseSiscontrolActual, 2, 0) 'cargar equipos
        End Select


        If dsCargar.Tables.Count > 0 Then
            Dgv_Buscar.DataSource = dsCargar.Tables(0)
        Else
            MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
            Exit Sub
        End If
        'ComboBox_Filtrar.SelectedIndex = 1
        'Me.Dgv_Buscar.DataSource = Nothing
        Me.Dgv_Buscar.AutoGenerateColumns = True
        Me.Dgv_Buscar.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Dgv_Buscar.ReadOnly = True

        Select Case Tipo
            Case "U" 'Ubicaciones Tecnicas
                For i = 0 To Dgv_Buscar.ColumnCount - 1
                    Dgv_Buscar.Columns(i).Visible = True
                    Select Case Dgv_Buscar.Columns(i).Name
                        Case "Codigo"
                            Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_Buscar.Columns(i).HeaderText = "Código"
                        Case "Nombre"
                            Dgv_Buscar.Columns(i).Width = 350
                        Case "Emplazamiento"
                            Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                        Case Else
                            Dgv_Buscar.Columns(i).Visible = False
                    End Select
                Next
            Case "E" 'Equipos
                For i = 0 To Dgv_Buscar.ColumnCount - 1
                    Dgv_Buscar.Columns(i).Visible = True
                    Select Case Dgv_Buscar.Columns(i).Name
                        Case "Codigo"
                            Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                        Case "Nombre"
                            Dgv_Buscar.Columns(i).Width = 350
                        Case "Ubicación Técnica"
                            Dgv_Buscar.Columns(i).AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
                        Case Else
                            Dgv_Buscar.Columns(i).Visible = False
                    End Select
                Next
        End Select
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Select Case Tipo
            Case "U" 'Ubicaciones Tecnicas
                Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Codigo").Value
                Resultado1 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Nombre").Value
            Case "E" 'Equipos
                Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Codigo").Value
                Resultado1 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Nombre").Value
        End Select
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Tb_Descripción_TextChanged(sender As Object, e As EventArgs) Handles Tb_Descripción.TextChanged
        Select Case Tipo
            Case "U"
                If Cb_Filtrar.Checked = True Then
                    Dim vista As New DataView(dsCargar.Tables(0))
                    Me.Dgv_Buscar.SuspendLayout()
                    Me.Dgv_Buscar.DataSource = vista
                    Me.Dgv_Buscar.ResumeLayout()
                    Dim Columna As String = ""
                    Select Case Me.ComboBox_Filtrar.SelectedIndex
                        Case 0
                            Columna = "Codigo"
                        Case 1
                            Columna = "Nombre"
                        Case 2
                            Columna = "Emplazamiento"
                    End Select
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                End If
            Case "E"
                If Cb_Filtrar.Checked = True Then
                    Dim vista As New DataView(dsCargar.Tables(0))
                    Me.Dgv_Buscar.SuspendLayout()
                    Me.Dgv_Buscar.DataSource = vista
                    Me.Dgv_Buscar.ResumeLayout()
                    Dim Columna As String = ""
                    Select Case Me.ComboBox_Filtrar.SelectedIndex
                        Case 0
                            Columna = "Codigo"
                            If IsNumeric(Trim(Tb_Descripción.Text)) Then
                                vista.RowFilter = String.Format("CONVERT(Codigo, System.String) LIKE '%{0}%'", Trim(Me.Tb_Descripción.Text))
                            End If

                        Case 1
                            Columna = "Nombre"
                            vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
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
            Case "U" 'Ubicaciones Tecnicas
                Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Codigo").Value
                Resultado1 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Nombre").Value
            Case "E" 'Equipos
                Resultado = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Codigo").Value
                Resultado1 = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("Nombre").Value
        End Select
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class