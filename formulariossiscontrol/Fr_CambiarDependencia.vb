Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_CambiarDependencia
    Private dt_BaseSC As New DataTable
    Private dt_DependenciaSC As New DataTable
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter

    Private Sub Fr_CambiarDependencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub CargarDatos()
        comando = New SqlCommand("dbo.ListarBasesDependenciasUsuario", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 0)
        comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
        adaptador = New SqlDataAdapter(comando)
        Dim dsBasesDependencias As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsBasesDependencias)
            conexion.Close()
            If Not IsNothing(dsBasesDependencias) Then
                If dsBasesDependencias.Tables.Count > 0 Then
                    dt_BaseSC = dsBasesDependencias.Tables(0)
                    dt_DependenciaSC = dsBasesDependencias.Tables(1)
                End If
            End If
            Cb_Base.DataSource = dt_BaseSC
            Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        If Cb_Dependencia.SelectedValue = 0 Then
            MessageBox.Show("Esta dependencia no es válida para su usuario")
            Exit Sub
        End If
        Dim filaBase As DataRow = dt_BaseSC.Select("IDBASESISCONTROL = " & Cb_Base.SelectedValue)(0)
        Dim filaDependencia As DataRow = dt_DependenciaSC.Select("IDDEPENDENCIA = " & Cb_Dependencia.SelectedValue)(0)
        'Actualizar datos de usuario
        VariablesBase.VariablesBase.IdBaseSiscontrolActual = Cb_Base.SelectedValue
        VariablesBase.VariablesBase.NombreBaseSiscontrol = filaBase("NOMBREBASE")
        VariablesBase.VariablesBase.AbreviaturaBaseSiscontrol = filaBase("ABREVIATURABASE")
        VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Cb_Dependencia.SelectedValue
        VariablesBase.VariablesBase.NombreDependenciaSiscontrol = filaDependencia("NOMBREDEPENDENCIA")
        VariablesBase.VariablesBase.IdCentroCostoSisControl = filaDependencia("IDCENTROCOSTO")
        VariablesBase.VariablesBase.EmpresaSisControlActual = filaDependencia("IDEMPRESA")
        Close()
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Close()
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Base.SelectedIndexChanged
        ActualizarDependencias()
    End Sub

    Private Sub ActualizarDependencias()
        If Cb_Base.SelectedIndex > -1 Then
            Cb_Dependencia.DataSource = dt_DependenciaSC.Select("[IDBASESISCONTROL] = " & Cb_Base.SelectedValue).CopyToDataTable
            'Seleccionar la dependencia actual si la base seleccionada es la base actual.
            If Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
            Else
                Cb_Dependencia.SelectedIndex = 0
            End If
        End If
    End Sub
End Class