Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_ArticulosSinValorReferencia
    Public Property TIPO As Integer
    Public Property IDREMISIONVALORIZADA As Integer
    Dim dt As New DataTable
    Dim datosCargados As Boolean = False
    Dim Estilo_Celda As New DataGridViewCellStyle
    Dim Estilo_Celda_Error As New DataGridViewCellStyle

    Private Sub Fr_ArticulosSinValorReferencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Dgv_ArticulosSinValorReferencia.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ArticulosSinValorReferencia.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Estilo_Celda.BackColor = Color.White
        Estilo_Celda_Error.BackColor = Color.Red
    End Sub

    Public Sub Cargar()
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarValoresReferenciaArticulos")
        Comando.CommandType = CommandType.StoredProcedure
        If IDREMISIONVALORIZADA > 0 Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
            Comando.Parameters.AddWithValue("@IDREMISION", IDREMISIONVALORIZADA)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 3)
            Comando.Parameters.AddWithValue("@IDREMISION", -1)
        End If
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim da As New SqlClient.SqlDataAdapter
        Comando.Connection = conn
        dt.Clear()
        da = New SqlClient.SqlDataAdapter(Comando)
        conn.Open()
        da.FillSchema(dt, SchemaType.Source)
        da.Fill(dt)
        conn.Close()
        Me.Dgv_ArticulosSinValorReferencia.DataSource = dt
        datosCargados = True
    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If ValidarValoresRemision() = False Then
            MsgBox("No ha indicado valores de referencia correctos para todos los artículos.", MsgBoxStyle.Critical, "VALORES DE REFERENCIA INCORRECTOS")
            Exit Sub
        End If

        dt = Dgv_ArticulosSinValorReferencia.DataSource
        dt.Columns.Remove("NOMBREDESCRIPTIVO")
        dt.Columns.Add("IDUSUARIOMODIFICAREF")
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i).Item("IDUSUARIOMODIFICAREF") = VariablesBase.VariablesBase.IdPersona
        Next

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarValoresReferenciaArticulos")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TIPO", 2)
        Comando.Parameters.AddWithValue("@IDREMISION", IDREMISIONVALORIZADA)
        Comando.Parameters.AddWithValue("@TableValoresReferenciaArticulos", dt)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No fue posible Guardar los Valores. " + ex.Message, MsgBoxStyle.Critical)
        Finally
            conn.Close()
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Function ValidarValoresRemision() As Boolean
        Dim Valido As Boolean = True
        For i As Integer = 0 To Dgv_ArticulosSinValorReferencia.RowCount - 1
            If IsDBNull(Dgv_ArticulosSinValorReferencia.Rows(i).Cells("VALORREFERENCIA").Value) Then
                Valido = False
            ElseIf FuncionesBase.FuncionesBase.ValorRealDec(Dgv_ArticulosSinValorReferencia.Rows(i).Cells("VALORREFERENCIA").Value) <= 0 Then
                Valido = False
            End If
        Next
        Return If(Valido, True, False)
    End Function

    Private Sub Dgv_ArticulosSinValorReferencia_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_ArticulosSinValorReferencia.CellValueChanged
        If datosCargados Then
            If Not IsDBNull(sender.Rows(e.RowIndex).Cells("VALORREFERENCIA").Value) Then
                If CStr(sender.Rows(e.RowIndex).Cells("VALORREFERENCIA").Value) <> "" Then
                    If FuncionesBase.FuncionesBase.ValorRealDec(sender.Rows(e.RowIndex).Cells("VALORREFERENCIA").Value) > 0 Then
                        sender.Rows(e.RowIndex).DefaultCellStyle = Nothing
                        Exit Sub
                    End If
                End If
            End If
            sender.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
            sender.Rows(e.RowIndex).ErrorText = "El Valor de Referencia no es válido"
        End If
    End Sub

    Private Sub Dgv_ArticulosSinValorReferencia_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Dgv_ArticulosSinValorReferencia.EditingControlShowing
        If Dgv_ArticulosSinValorReferencia.CurrentCell.ColumnIndex = Dgv_ArticulosSinValorReferencia.Columns("VALORREFERENCIA").Index Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_KeyPress
        End If
    End Sub

    Private Sub Dgv_ArticulosSinValorReferencia_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Dgv_ArticulosSinValorReferencia.DataError
        e.Cancel = True
    End Sub
End Class