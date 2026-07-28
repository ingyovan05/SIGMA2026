Public Class Fr_EditarTablaMaestra

    Private _TablaMaestra As String
    Dim adap As SqlClient.SqlDataAdapter
    Dim comando As New SqlClient.SqlCommand
    Dim conexion As New SqlClient.SqlConnection
    Dim Tabla As DataTable

    Public Property TablaMaestra() As String
        Get
            Return CType(_TablaMaestra, String)
        End Get
        Set(value As String)
            _TablaMaestra = value
        End Set
    End Property

    Public Sub Cargar()
        Try
            Tabla = New DataTable(Trim(_TablaMaestra))
            comando.CommandText = "SELECT * FROM " + Trim(_TablaMaestra)
            adap = New SqlClient.SqlDataAdapter(comando.CommandText, VariablesBase.VariablesBase.Conexion_Remota_Sql_Server)
            adap.Fill(Tabla)
            Me.Dgv_Maestra.DataSource = Tabla
            Me.Bt_Actualizar.Enabled = True
        Catch ex As Exception
            Me.Bt_Actualizar.Enabled = False
            MsgBox("Se presento un problea al intentar cargar la tabla maestra", MsgBoxStyle.Critical, "Problema al cargar la tabla Maestra")
        End Try
    End Sub

    Private Sub Bt_Actualizar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Actualizar.Click
        If MsgBox("¿Seguro que desea guardar los cambios realizados?", MsgBoxStyle.YesNo, "Guardar Cambios") = MsgBoxResult.Yes Then
            Try
                Dim sqlcommandobuelder1 As SqlClient.SqlCommandBuilder
                sqlcommandobuelder1 = New SqlClient.SqlCommandBuilder(adap)
                adap.Update(Tabla)
                Me.Close()
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar actualizar la tabla maestra")
            End Try
        End If

    End Sub

    Private Sub Button_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Fr_EditarTablaMaestra_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Dgv_Maestra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Maestra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub
End Class