Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_BuscarEnfermedades
    Public dtEnfermedades As New DataTable
    Public dtGrupos As New DataTable
    Public dtFiltro As New DataTable
    Public IdEnfermedad As Integer = 0
    Public NombreEnfermedad As String = ""
    Public Resultado As Boolean = False
    Public Sub CargarEnfermedades()
        Dgv_Enfermedades.DataSource = dtEnfermedades
    End Sub
    Public Sub ComportamientoPredeterminado()
        dtFiltro.Clear()
        dtFiltro.Columns.Add("ID")
        dtFiltro.Columns.Add("NOMBRE")
        dtFiltro.Rows.Add("NOMBREENFERMEDAD", "Nombre de la enfermedad")
        dtFiltro.Rows.Add("IDENFERMEDAD", "Id")
        dtFiltro.Rows.Add("CODIGOENFERMEDAD", "Codigo CIE10")
        dtFiltro.Rows.Add("GRUPOENFERMEDAD", "Grupo de la enfermedad")

        Cb_Busqueda.DataSource = dtFiltro
        Cb_Busqueda.ValueMember = "ID"
        Cb_Busqueda.DisplayMember = "NOMBRE"
    End Sub

    Public Sub CambiarIndex() Handles Cb_Busqueda.SelectedIndexChanged
        Tb_busqueda.Text = ""
        If Cb_Busqueda.SelectedValue.ToString = "CODIGOENFERMEDAD" Then
            Tb_busqueda.MaxLength = 4
        Else
            Tb_busqueda.MaxLength = 260
        End If
        dtEnfermedades.DefaultView.RowFilter = String.Empty
    End Sub

    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_busqueda.KeyPress
        If Cb_Busqueda.SelectedValue.ToString = "IDENFERMEDAD" Then
            If InStr(1, "0123456789," & Chr(8), e.KeyChar) = 0 Then
                e.Handled = True
                e.KeyChar = CChar("")
            End If
        End If
    End Sub

    Public Sub FiltrarArticulos() Handles Tb_busqueda.TextChanged
        Dim Columna As String = Cb_Busqueda.SelectedValue.ToString
        If Columna = "IDENFERMEDAD" Then
            If Trim(Tb_busqueda.Text.ToString) <> "" Then
                dtEnfermedades.DefaultView.RowFilter = Columna + " =" + Tb_busqueda.Text.ToString
            End If
        Else
            Dim Texto As String = Tb_busqueda.Text.ToString
            Dim pabla() As String
            pabla = Split(Trim(Texto), "  ")
            While pabla.Count > 1
                Texto = Replace(Trim(Texto), "  ", " ")
                pabla = Split(Trim(Texto), "  ")
            End While
            pabla = Split(Trim(Texto), " ")
            Select Case Cb_Busqueda.SelectedIndex
                Case 0, 2, 3 'Nombre enfermedad
                    Dim filtroFilas As New StringBuilder
                    For i As Integer = 0 To pabla.Count - 1
                        filtroFilas.Append(Cb_Busqueda.SelectedValue & " like '%" & pabla(i) & "%' ")
                        If i < pabla.Count - 1 Then
                            filtroFilas.Append("AND ")
                        End If
                    Next
                    'dtEnfermedades.DefaultView.RowFilter = Columna + " like '%" + Tb_busqueda.Text.ToString + "%'"
                    dtEnfermedades.DefaultView.RowFilter = filtroFilas.ToString
            End Select

        End If
    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        If Dgv_Enfermedades.SelectedCells IsNot Nothing Then
            IdEnfermedad = Dgv_Enfermedades.CurrentRow.Cells("DGVT_IDENFERMEDAD").Value
            NombreEnfermedad = Dgv_Enfermedades.CurrentRow.Cells("DGVT_NOMBREENFERMEDAD").Value
            Resultado = True
            Me.Close()
        End If
    End Sub

    Private Sub Dgv_Enfermedades_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Dgv_Enfermedades.DoubleClick
        Aceptar.PerformClick()
    End Sub
    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        Me.Close()
    End Sub
    Private Sub Dgv_Enfermedades_Click(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv_Enfermedades.CellMouseDown
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim cellRectangle = Dgv_Enfermedades.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                Dim punto As New System.Drawing.Point(e.X + cellRectangle.Left, e.Y + cellRectangle.Top)
                Dgv_Enfermedades.CurrentCell = Dgv_Enfermedades.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Cms_AsignarGrupoEnfermedad.Show(Dgv_Enfermedades, punto)
            End If
        End If
    End Sub
    Private Sub AsignarGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarGrupoToolStripMenuItem.Click
        Dim Fr_AsignarGrupos As New Form
        Dim Bt_Aceptar As New Button
        Dim Bt_Cancelar As New Button
        Dim Lb_Enfermedad As New Label
        Dim Lb_Grupo As New Label
        Dim Cb_Grupos As New ComboBox
        Dim TamañoForm As Integer = 0
        Dim Registrar As Boolean = False
        Dim Guardado As Boolean = False

        Dim PuntoInicial As New System.Drawing.Point(10, 10)
        Dim NombreEnfermedad As String = Me.Dgv_Enfermedades.CurrentRow.Cells(1).Value.ToString + " - " + Me.Dgv_Enfermedades.CurrentRow.Cells(2).Value.ToString
        Dim IdEnfermedad As Integer = Me.Dgv_Enfermedades.CurrentRow.Cells(0).Value
        Dim TamañoLabel As Integer = 20

        TamañoLabel = NombreEnfermedad.Length / 50

        If TamañoLabel = 1 Or TamañoLabel = 0 Then
            TamañoLabel = 20
            TamañoForm = 130
        Else
            If TamañoLabel = 2 Then
                TamañoForm = 140
            Else
                If TamañoLabel = 3 Then
                    TamañoForm = 155
                Else
                    If TamañoLabel = 4 Then
                        TamañoForm = 170
                    Else
                        If TamañoLabel = 5 Then
                            TamañoForm = 185
                        End If
                    End If
                End If
            End If
            TamañoLabel = TamañoLabel * 15
        End If

        With Lb_Enfermedad
            .Text = NombreEnfermedad
            .Location = New System.Drawing.Point(10, 10)
            .AutoSize = False
            .Size = New System.Drawing.Size(370, TamañoLabel)
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With

        TamañoLabel = TamañoLabel + 10

        With Cb_Grupos
            .Size = New System.Drawing.Size(200, 20)
            .Location = New System.Drawing.Point(90, TamañoLabel)
            .DataSource = dtGrupos
            .DisplayMember = "NOMBRE"
            .ValueMember = "ID"
        End With

        TamañoLabel = TamañoLabel + 20

        With Bt_Aceptar
            .Location = New System.Drawing.Point(105, TamañoLabel + 10)
            .Name = "Bt_Aceptar"
            .Size = New System.Drawing.Size(80, 23)
            .TabIndex = 9
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(195, TamañoLabel + 10)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(80, 23)
            .TabIndex = 10
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_AsignarGrupos
            .Text = "Asignar grupo"
            .ShowIcon = False
            .Size = New System.Drawing.Size(400, TamañoForm)
            .MaximumSize = New System.Drawing.Size(400, TamañoForm)
            .MinimumSize = New System.Drawing.Size(400, TamañoForm)
            .Controls.Add(Lb_Enfermedad)
            .Controls.Add(Cb_Grupos)
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
            .StartPosition = FormStartPosition.CenterScreen
        End With

        AddHandler Bt_Aceptar.Click, Sub()
                                        If Cb_Grupos.SelectedIndex = -1 Then
                                             Registrar = False
                                         Else
                                             Registrar = True
                                         End If

                                         If Registrar Then
                                             Guardado = GuardarGrupo(IdEnfermedad, Cb_Grupos.SelectedValue)
                                         End If

                                         If Guardado Then
                                             Fr_AsignarGrupos.Close()
                                         End If
                                     End Sub
        AddHandler Bt_Cancelar.Click, Sub()
                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then
                                              Fr_AsignarGrupos.Close()
                                          End If
                                      End Sub

        Fr_AsignarGrupos.ShowDialog()
    End Sub
    
    Private Function GuardarGrupo(IdEnfermedad As Integer, IdGrupo As Integer) As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim datas As New DataSet
        Dim da As New SqlDataAdapter
        Dim Comando As New SqlCommand("dbo.GestionarExamenMedicoConcepto")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TIPO", 2)
        Comando.Parameters.AddWithValue("@IDEXAMENMEDICO", DBNull.Value)
        Comando.Parameters.AddWithValue("@RECOMENDADOCARGO", DBNull.Value)
        Comando.Parameters.AddWithValue("@APTOTIPOTRABAJO", DBNull.Value)
        Comando.Parameters.AddWithValue("@PROGRAMASVIGILANCIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CONCEPTO", DBNull.Value)
        Comando.Parameters.AddWithValue("@RECOMENDACIONES", DBNull.Value)
        Comando.Parameters.AddWithValue("@LABORATORIOSREALIZADOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@OTROSLABORATORIOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@PERSONAMODIFICA", DBNull.Value)
        Comando.Parameters.AddWithValue("@IDENFERMEDAD", IdEnfermedad)
        Comando.Parameters.AddWithValue("@IDGRUPOENFERMEDAD", IdGrupo)
        conexion.Open()
        Comando.Connection = conexion
        Try
            da = New SqlClient.SqlDataAdapter(Comando)
            datas = New DataSet()
            da.Fill(datas)
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.ToString)
        End Try

        If datas.Tables(0).Rows(0).Item(0) = 0 Then
            MsgBox("Grupo de enfermedad editado")
            dtEnfermedades = datas.Tables(1)
            Dgv_Enfermedades.DataSource = dtEnfermedades
            Dgv_Enfermedades.Refresh()
            Return True
        Else
            Return False
        End If
    End Function
End Class