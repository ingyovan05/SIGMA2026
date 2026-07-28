Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_HistoricoTrabajadorvb
    Public identificacion As String
    Public añoRegistra As Integer


    Public Sub Cargar_Tabla(Optional identificacion As String = "", Optional año As Integer = -1)
        Cursor.Current = Cursors.WaitCursor
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.SC_ListarHistoricoTrabajador(@ACCION, @IDENTIFICACION, @AÑO)", conexion)
        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDENTIFICACION", SqlDbType.VarChar, 15)
        comando.Parameters.Add("@AÑO", SqlDbType.Char, 4)
        If IsNumeric(Cb_Año.SelectedItem) Then 'Histórico persona
            comando.Parameters("@ACCION").Value = 0
            comando.Parameters("@IDENTIFICACION").Value = identificacion
            comando.Parameters("@AÑO").Value = año
        Else 'Todo
            comando.Parameters("@ACCION").Value = 1
            comando.Parameters("@IDENTIFICACION").Value = DBNull.Value
            comando.Parameters("@AÑO").Value = DBNull.Value
        End If
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtHistoricoPersona As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtHistoricoPersona)
            conexion.Close()
            'Lb_Nombre.Text = "Nombre: " & dtHistoricoPersona.Rows(0).Item("NOMBRE")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Close()
            Exit Sub
        Finally
            conexion.Close()
        End Try
        Dgv_Historico.SuspendLayout()
        Dgv_Historico.DataSource = dtHistoricoPersona
        Dgv_Historico.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Historico.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Historico.AutoResizeColumns()
        Dgv_Historico.ResumeLayout()
    End Sub


    Private Sub Fr_HistoricoTrabajadorvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim año As Integer
        año = 2014
        While año <> Date.Now.Year + 1
            Cb_Año.Items.Add(año)
            año = año + 1
        End While
        Cb_Año.Items.Add("Todo")
        Tb_Identificacion.Text = identificacion
        Cb_Año.SelectedItem = añoRegistra
        Cargar_Tabla(identificacion, añoRegistra)
    End Sub


    Private Sub Bt_CargarHistorico_Click(sender As Object, e As EventArgs) Handles Bt_CargarHistorico.Click
        If IsNumeric(Cb_Año.SelectedItem) Then
            Cargar_Tabla(Trim(Tb_Identificacion.Text), CInt(Cb_Año.SelectedItem))
        Else
            Cargar_Tabla()
        End If
    End Sub


    Private Sub Tb_Identificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_Identificacion.KeyPress
        Dgv_Historico.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Historico.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Try
            Cargar_Tabla(Trim(Tb_Identificacion.Text), CInt(Cb_Año.SelectedItem))
        Catch

        End Try
    End Sub


    Private Sub Btn_ExportarHistorico_Click(sender As Object, e As EventArgs) Handles Btn_ExportarHistorico.Click
        FuncionesBase.FuncionesBase.GridAExcel(Dgv_Historico, "Historico trabajador " & Date.Now)
    End Sub


    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Dgv_Historico_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_Historico.SelectionChanged
        Try
            Lb_Nombre.Text = "Nombre: " & Dgv_Historico.Rows(Dgv_Historico.CurrentCell.RowIndex).Cells(DgvTx_Nombre.Name).Value
        Catch
            Lb_Nombre.Text = "Nombre:"
        End Try
    End Sub
End Class