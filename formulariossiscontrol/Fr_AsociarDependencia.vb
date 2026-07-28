Public Class Fr_AsociarDependencia

    Public TipoMovimiento As Integer

    Dim DsSobre As New DatosSisControl.Ds_Siscontrol
    'Dim sc_DependenciaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_DEPENDENCIATableAdapter
    Dim sc_FuncionariosTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_FUNCIONARIOTableAdapter
    Dim CargarDatosGrilla As Boolean = False
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Dim dsCargar As New DataSet
    Public Sub CargarDatos()

        dsCargar = bddatos.CargarMaestrasSiscontrol(8, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, 1)
        Me.Cu_BuscarPersona.CargarDatos()
        'Me.sc_DependenciaTableAdapter.Fill(DsSobre.SC_DEPENDENCIA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.Cb_Dependencia.DataSource = Me.DsSobre.SC_DEPENDENCIA
        Me.Cb_Dependencia.DataSource = Me.dsCargar.Tables(0)
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CargarDatosGrilla = True
        CargarGrilla()
    End Sub

    Private Sub CargarGrilla()
        If CargarDatosGrilla Then
            Select Case TipoMovimiento
                Case 1 'Personas Asociadas
                    Me.sc_FuncionariosTableAdapter.FillASOCIADO(DsSobre.SC_FUNCIONARIO, Me.Cb_Dependencia.SelectedValue)
                Case 2 'Usuarios de la dependencia 
                    Me.sc_FuncionariosTableAdapter.FillUSUARIO(DsSobre.SC_FUNCIONARIO, Me.Cb_Dependencia.SelectedValue)
            End Select
            Me.Dgv_PersonasAsociadas.SuspendLayout()
            Me.Dgv_PersonasAsociadas.DataSource = Me.DsSobre.SC_FUNCIONARIO
            Me.Dgv_PersonasAsociadas.ResumeLayout()
            For i = 0 To Dgv_PersonasAsociadas.ColumnCount - 1
                Dgv_PersonasAsociadas.Columns(i).Visible = True
                Select Case Dgv_PersonasAsociadas.Columns(i).Name
                    Case "Funcionario"
                        Dgv_PersonasAsociadas.Columns(i).Width = 400
                    Case "Dependencia"
                        Dgv_PersonasAsociadas.Columns(i).Width = 200
                    Case Else
                        Dgv_PersonasAsociadas.Columns(i).Visible = False
                End Select
            Next
        End If
    End Sub

    Private Sub Btn_Asociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Asociar.Click

        Dim Comando As New SqlClient.SqlCommand("AsociarUsuarioDependencia")
        Comando.CommandType = CommandType.StoredProcedure
        Select Case TipoMovimiento
            Case 1 'Personas Asociadas
                Comando.Parameters.AddWithValue("@TIPO", 0)
            Case 2 'Usuarios de la dependencia 
                Comando.Parameters.AddWithValue("@TIPO", 1)
        End Select
        Comando.Parameters.AddWithValue("@IDPERSONA", Cu_BuscarPersona.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()

        CargarGrilla()
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Cb_Dependencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Dependencia.SelectedIndexChanged
        CargarGrilla()
    End Sub
End Class