Public Class Cu_Maestro

    Dim adap As SqlClient.SqlDataAdapter
    Dim comando As New SqlClient.SqlCommand
    Dim conexion As New SqlClient.SqlConnection
    Dim Tabla As DataTable

    '    public void CargarDatos()
    '{
    '//cualquiera que sea tu codigo para llenar el DS
    'myDataAdapter.Fill(myDataSet);
    '}

    'y luego tienes otro metodo para hacer los cambios.

    'public void GuardarCambios()
    '{
    'SqlCommandBuilder builder = new SqlCommandBuilder(myDataAdapter);
    'if (myDataSet.HasChanges())
    '{
    'myDataAdapter.Update(MyDataSet);
    '}
    '}



    Private Sub Bt_Cargar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cargar.Click
        Try
            Tabla = New DataTable(Trim(Cb_TablaMaestra.SelectedValue))
            comando.CommandText = "SELECT * FROM " + Trim(Cb_TablaMaestra.SelectedValue)
            adap = New SqlClient.SqlDataAdapter(comando.CommandText, VariablesBase.VariablesBase.Conexion_Remota_Sql_Server)
            adap.Fill(Tabla)
            Me.Dgv_Maestra.DataSource = Tabla
            Me.Bt_Actualizar.Enabled = True
        Catch ex As Exception
            Me.Bt_Actualizar.Enabled = False
            MsgBox("Se presento un problema al intentar cargar la tabla maestra", MsgBoxStyle.Critical, "Problema al cargar la tabla Maestra")
        End Try
    End Sub


    Private Sub Cu_Maestro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Dgv_Maestra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Maestra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        MA_TABLAMAESTRATableAdapter.Fill(Ds_Maestros.MA_TABLAMAESTRA)
    End Sub

    Private Sub Bt_Actualizar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Actualizar.Click
        If MsgBox("¿Seguro que desea guardar los cambios realizados?", MsgBoxStyle.YesNo, "Guardar Cambios") = MsgBoxResult.Yes Then
            Try
                Dim sqlcommandobuelder1 As SqlClient.SqlCommandBuilder
                sqlcommandobuelder1 = New SqlClient.SqlCommandBuilder(adap)
                adap.Update(Tabla)
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar actualizar la tabla maestra")
            End Try
        End If
    End Sub

End Class
