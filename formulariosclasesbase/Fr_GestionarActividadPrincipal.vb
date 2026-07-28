Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_GestionarActividadPrincipal

    Private dt_Actividades As DataTable
    Private actividadPrincipal As Integer

    Public Sub New()
        InitializeComponent()
        dt_Actividades = New DataTable
        actividadPrincipal = 0
    End Sub

    Public Function ShowDialog_ActividadPrincipal()
        Me.ShowDialog()
        ShowDialog_ActividadPrincipal = actividadPrincipal
    End Function

    Private Sub Fr_GestionarActividadPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarActividades()
        If Not IsNothing(dt_Actividades) Then
            Dgv_Actividades.DataSource = dt_Actividades
        End If
    End Sub

    Private Sub CargarActividades()
        Dim Conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("GestionarActividadPrincipal", Conexion)
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TablaActividadesPrincipales", Nothing)
        Comando.Parameters.AddWithValue("@ACCION", 3)
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", "")
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", DbType.Int32)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim adaptador As New SqlDataAdapter(Comando)
        Try
            Conexion.Open()
            adaptador.Fill(dt_Actividades)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conexion.Close()
        End Try
    End Sub

    Private Sub Ck_HabilitarCrearActividad_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_HabilitarCrearActividad.CheckedChanged
        If Ck_HabilitarCrearActividad.Checked Then
            Tx_CrearActividad.Enabled = True
            Bt_CrearActividad.Enabled = True
            'dt_Actividades = Dgv_Actividades.DataSource
            Dgv_Actividades.DataSource = Nothing
            Dgv_Actividades.Enabled = False
            Bt_Aceptar.Enabled = False
        Else
            Tx_CrearActividad.Enabled = False
            Bt_CrearActividad.Enabled = False
            If Not IsNothing(dt_Actividades) Then
                Dgv_Actividades.DataSource = dt_Actividades
                Dgv_Actividades.Enabled = True
            Else

            End If
            Bt_Aceptar.Enabled = True
        End If
    End Sub

    Private Sub Bt_CrearActividad_Click(sender As Object, e As EventArgs) Handles Bt_CrearActividad.Click
        Dim NuevaActividad As String
        NuevaActividad = Trim(Tx_CrearActividad.Text)
        If NuevaActividad = "" Then
            Exit Sub
        End If

        Dim Conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlClient.SqlCommand("GestionarActividadPrincipal")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TablaActividadesPrincipales", Nothing)
        Comando.Parameters.AddWithValue("@ACCION", 1)
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", UCase(NuevaActividad))
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
        If Comando.Parameters("@ACTIVIDADPRINCIPAL").Value <= 0 Then
            MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "Crear Actividad Principal")
        Else
            actividadPrincipal = Comando.Parameters("@ACTIVIDADPRINCIPAL").Value
            MsgBox("Se agregó la actividad correctamente", MsgBoxStyle.Information, "Crear Actividad Principal")
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        dt_Actividades = Dgv_Actividades.DataSource

        Dim Conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("GestionarActividadPrincipal", Conexion)
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TablaActividadesPrincipales", dt_Actividades)
        Comando.Parameters.AddWithValue("@ACCION", 4)
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", "")
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Try
            Conexion.Open()
            Comando.ExecuteNonQuery()
            MsgBox("Se actualizaron las actividades principales.", MsgBoxStyle.OkOnly, "CAMBIOS GUARDADOS")
        Catch ex As Exception
            MsgBox("Ocurrió un error al guardar las actividades principales.", MsgBoxStyle.Critical, "NO SE GUARDARON LOS CAMBIOS.")
        Finally
            Conexion.Close()
        End Try
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class