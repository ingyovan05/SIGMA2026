Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_ReclasificarContrato
    Property IdContrato_Modificar As Int64 = -1
    Property Guardado As Boolean = False
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private IDConceptoDefecto As Integer
    Private fechaInicioVigencia As Date
    Private fechaFinContrato As Date

    Private Sub Fr_ReclasificarContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(2, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdContrato_Modificar, 2)
        Cb_Cargo_Desempeña.DataSource = dsCargar.Tables(4)
        Cb_Categoria.DataSource = dsCargar.Tables(5)
        Cb_TipoGrupo.DataSource = dsCargar.Tables(6)
        Dim dtTipoSalario As New DataTable
        dtTipoSalario.Columns.Add("CODIGOTIPOSALARIO")
        dtTipoSalario.Columns.Add("NOMBRETIPOSALARIO")
        dtTipoSalario.Rows.Add("M", "Mensual")
        dtTipoSalario.Rows.Add("D", "Diario")
        Cb_TipoSalario.DataSource = dtTipoSalario
        DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.DataSource = dsCargar.Tables(19)
        DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.ValueMember = "CODIGOTIPOCONCEPTOCONTRATO"
        DGVCBC_CODIGOTIPOCONCEPTOCONTRATO.DisplayMember = "NOMBRETIPOCONCEPTOCONTRATO"
        Dim filaConceptoDefecto As DataRow = dsCargar.Tables(19).Rows(0)
        IDConceptoDefecto = filaConceptoDefecto("CODIGOTIPOCONCEPTOCONTRATO")
        Dim filaContrato As DataRow = dsCargar.Tables(0).Rows(0)
        Lb_Codigo.Text = filaContrato("CODIGOCONTRATO")
        Lb_Nombre.Text = dsCargar.Tables(21).Rows(0).Item("NOMBRE")

        Cb_Cargo_Desempeña.SelectedValue = filaContrato("CODIGOTIPOCARGO")
        If Not IsDBNull(filaContrato("CODIGOTIPOCATEGORIA")) Then
            Cb_Categoria.SelectedValue = filaContrato("CODIGOTIPOCATEGORIA")
        Else
            Cb_Categoria.SelectedIndex = -1
        End If
        If Not IsDBNull(filaContrato("CODIGOTIPOGRUPO")) Then
            Cb_TipoGrupo.SelectedValue = filaContrato("CODIGOTIPOGRUPO")
        Else
            Cb_TipoGrupo.SelectedIndex = -1
        End If
        Cb_TipoSalario.SelectedValue = filaContrato("CODIGOTIPOSALARIO")
        Tx_Salario.Text = filaContrato("SALARIO")
        FormatearValor(Tx_Salario)

        Dim filaUltimaVigencia As DataRow = dsCargar.Tables(23).Rows(0) 'Select("", "IDAUDITORIA DESC")
        fechaInicioVigencia = filaUltimaVigencia("FECHAINICIOVIGENCIA")
        fechaFinContrato = filaUltimaVigencia("FECHAFINVIGENCIA")
        Lb_CargoAnterior.Text = filaUltimaVigencia("NOMBRETIPOCARGO")
        Lb_CategoriaAnterior.Text = filaUltimaVigencia("NOMBRETIPOCATEGORIA")
        Lb_GrupoAnterior.Text = filaUltimaVigencia("NOMBRETIPOGRUPO")
        Select Case filaUltimaVigencia("CODIGOTIPOSALARIO")
            Case "D"
                Lb_TipoSalarioAnterior.Text = "Diario"
            Case "M"
                Lb_TipoSalarioAnterior.Text = "Mensual"
            Case Else
                Lb_TipoSalarioAnterior.Text = "No Aplica"
        End Select
        Lb_SalarioAnterior.Text = FormatCurrency(filaUltimaVigencia("SALARIO"), 2)
        Lb_FechaInicioVigencia.Text = fechaInicioVigencia.ToLongDateString
        Dtp_FechaFinVigencia.MinDate = fechaInicioVigencia
        Dtp_FechaFinVigencia.MaxDate = fechaFinContrato
        Dtp_FechaFinVigencia.Checked = False

        Dgv_Conceptos.DataSource = dsCargar.Tables(1)
    End Sub

    Private Sub Fr_ReclasificarContrato_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Cb_Cargo_Desempeña.Select()
    End Sub

    Private Sub Cb_Cargo_Desempeña_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Cargo_Desempeña.SelectedIndexChanged
        If Not IsNothing(Cb_Cargo_Desempeña.DataSource) AndAlso Cb_Cargo_Desempeña.DataSource.Rows.Count > 0 Then
            'Cargar valores preconfigurados por tipo de cargo y base.
            Dim Filas() As DataRow
            Filas = Cb_Cargo_Desempeña.DataSource.Select("CODIGOTIPOCARGO=" & Cb_Cargo_Desempeña.SelectedValue)
            Dim Fila As DataRow = Filas(0)
            If Not IsDBNull(Fila("CODIGOTIPOCATEGORIA")) Then
                Cb_Categoria.SelectedValue = Fila("CODIGOTIPOCATEGORIA")
            Else
                Cb_Categoria.SelectedIndex = -1
            End If
            If Not IsDBNull(Fila("CODIGOTIPOSALARIO")) Then
                Cb_TipoSalario.SelectedValue = Fila("CODIGOTIPOSALARIO")
            Else
                Cb_TipoSalario.SelectedIndex = -1
            End If
            If Not IsDBNull(Fila("CODIGOTIPOGRUPO")) Then
                Cb_TipoGrupo.SelectedValue = Fila("CODIGOTIPOGRUPO")
            Else
                Cb_TipoGrupo.SelectedIndex = -1
            End If
            If Not IsDBNull(Fila("SALARIO")) Then
                Tx_Salario.Text = Format(Fila("SALARIO"), "Currency")
            Else
                Tx_Salario.Text = ""
            End If
        End If
    End Sub

    Private Sub TextBox_Salario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Salario.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub TextBox_Salario_LostFocus(sender As Object, e As EventArgs) Handles Tx_Salario.LostFocus
        Try
            FormatearValor(sender)
        Catch

        End Try
    End Sub

    Private Sub Bt_AgregarConcepto_Click(sender As Object, e As EventArgs) Handles Bt_AgregarConcepto.Click
        Dim fila As DataRow
        fila = Dgv_Conceptos.DataSource.NewRow
        fila("CODIGOTIPOCONCEPTOCONTRATO") = IDConceptoDefecto
        fila("VALOR") = 0
        fila("PERIODICIDAD") = "Mes"
        fila("ACTIVO") = "S"
        Dgv_Conceptos.DataSource.Rows.Add(fila)
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If Guardado Then
            Close()
        Else
            If MessageBox.Show("¿Desea salir sin guardar los cambios?", "SALIR", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            Guardar()
            If Guardado Then
                Close()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If Cb_Cargo_Desempeña.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar el cargo para el cual fue contratado", MsgBoxStyle.Information, "SELECCIONAR TIPO CONTRATO")
            Cb_Cargo_Desempeña.Focus()
            Return False
        End If
        If Cb_Categoria.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar la categoría del cargo", MsgBoxStyle.Information, "SELECCIONAR CATEGORÍA DEL CARGO")
            Cb_Categoria.Focus()
            Return False
        End If
        If Cb_TipoGrupo.SelectedIndex < 0 Then 'Seleccionar grupo para evitar error de parámetro en el procedimiento almacenado.
            MsgBox("Debe seleccionar el grupo del cargo", MsgBoxStyle.Information, "SELECCIONAR GRUPO")
            Cb_TipoGrupo.Focus()
            Return False
        End If
        If Cb_TipoSalario.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar el tipo de salario", MsgBoxStyle.Information, "SELECCIONAR TIPO SALARIO")
            Cb_TipoSalario.Focus()
            Return False
        End If
        If Not IsNumeric(Tx_Salario.Text) Then
            MsgBox("El valor del salario no es válido.", MsgBoxStyle.Critical, "SALARIO NO VÁLIDO")
            Tx_Salario.Focus()
            Return False
        End If
        If Cb_TipoSalario.SelectedValue = "D" Then 'Diario
            If Tx_Salario.Text > 100000 Then
                If MsgBox("El salario es elevado para el tipo de contrato, ¿Desea continuar?", MsgBoxStyle.YesNo, "SALARIO ALTO") = MsgBoxResult.No Then
                    Tx_Salario.Focus()
                    Return False
                End If
            End If
        Else
            If Tx_Salario.Text < 700000 Then
                If MsgBox("El salario es muy bajo para el tipo de contrato, ¿Desea continuar?", MsgBoxStyle.YesNo, "SALARIO BAJO") = MsgBoxResult.No Then
                    Tx_Salario.Focus()
                    Return False
                End If
            End If
        End If
        If Dtp_FechaFinVigencia.Checked = False Then
            MsgBox("Debe indicar la fecha de finalización de la vigencia", MsgBoxStyle.Information, "INDICAR FECHA FIN VIGENCIA")
            Dtp_FechaFinVigencia.Focus()
            Return False
        End If
        If Dgv_Conceptos.Rows.Count = 0 Then
            If MsgBox("No tiene conceptos asociados, ¿Desea Continuar?", MsgBoxStyle.YesNo, "SIN CONCEPTOS") = MsgBoxResult.No Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub Guardar()
        DirectCast(Dgv_Conceptos.DataSource, DataTable).AcceptChanges()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("ReclasificarContrato", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 1)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato_Modificar)
        comando.Parameters.AddWithValue("@CODIGOTIPOCARGO", Cb_Cargo_Desempeña.SelectedValue)
        comando.Parameters.AddWithValue("@CODIGOTIPOCATEGORIA", Cb_Categoria.SelectedValue)
        comando.Parameters.AddWithValue("@CODIGOTIPOGRUPO", Cb_TipoGrupo.SelectedValue)
        comando.Parameters.AddWithValue("@CODIGOTIPOSALARIO", Cb_TipoSalario.SelectedValue)
        comando.Parameters.AddWithValue("@SALARIO", FuncionesBase.FuncionesBase.ValorRealDec(Tx_Salario.Text))
        comando.Parameters.AddWithValue("@FECHAINICIOVIGENCIA", fechaInicioVigencia)
        comando.Parameters.AddWithValue("@FECHAFINVIGENCIA", Dtp_FechaFinVigencia.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@TIP_CONTRATO_CONCEPTO", Dgv_Conceptos.DataSource)
        comando.Parameters.Add(New SqlParameter("@MENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            If Not IsDBNull(comando.Parameters("@MENSAJE").Value) Then
                Select Case comando.Parameters("@MENSAJE").Value
                    Case 0
                        MessageBox.Show("Ocurrió un error al guardar la reclasificación", "Error de conexión")
                    Case 1
                        MessageBox.Show("Se guardaron los cambios.", "Guardado correctamente")
                        Guardado = True
                    Case Else
                        MessageBox.Show("Ocurrió un error al guardar la reclasificación", "Error de conexión")
                End Select
            Else
                MessageBox.Show("Ocurrió un error al guardar la reclasificación", "Error de conexión")
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al guardar la reclasificación", "Error de conexión")
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub FormatearValor(sender As Object)
        Dim Caja As TextBox = sender
        Dim Cadena As String = Replace(Caja.Text, "$", "")
        Cadena = Replace(Cadena, " ", "")
        Cadena = Replace(Cadena, Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator, "")
        If Not IsNumeric(Cadena) Then
            Caja.BackColor = Drawing.Color.Salmon
        Else
            Caja.Text = Format(Cadena, "Currency")
            Caja.BackColor = Drawing.Color.White
        End If
    End Sub

End Class